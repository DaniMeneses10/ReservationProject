using ReservationsProject.Database;
using ReservationsProject.Interfaces;
using ReservationsProject.Models.Entities;
using ReservationsProject.Models.Requests;
using ReservationsProject.Models.Responses;
using ReservationsProject.Models.Validator;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using static ReservationsProject.Common.Constants;

namespace ReservationsProject.Services
{
    public class ReservationService
    {
        ReservationDBContext _context;
        IUserService _userservice;
        IReservationValidator _reservationValidator;
        public ReservationService(ReservationDBContext context, 
                                    IUserService userService,
                                    IReservationValidator reservationValidator)
        {
            _userservice = userService;
            _context = context;
            _reservationValidator = reservationValidator;
        }

        public ReservationResponse CreateReservation(ReservationRequest request)
        {
            var reservation = request.reservation;
            var furnituresList = request.FurnituresList;

            var validationErrors = _reservationValidator.Validate(request);

            if (validationErrors.Any())
            {
                return new ReservationResponse { IsSuccessful = false, Errors = validationErrors };
            }

            var building = this._context.Buildings.Where(x => x.BuildingID == reservation.BuildingID).FirstOrDefault();

            var newReservation = new Reservation();
            newReservation.ReservationID = Guid.NewGuid();
            newReservation.BuildingID = reservation.BuildingID;
            newReservation.ClientID = reservation.ClientID;
            newReservation.EventDate = reservation.EventDate;
            newReservation.StartTime = reservation.StartTime;
            newReservation.EndTime = reservation.EndTime;
                        
            double sumTotalFurnituresValues = furnituresList.Sum(x => x.HourlyRate);

            newReservation.TotalPrice = CalculateTotalPrice(sumTotalFurnituresValues, reservation, building );            

            _context.Reservations.Add(newReservation);
            
            foreach(var item in furnituresList)
            {
                item.IsAvailable = false;

                var newReservationFurniture = new ReservationFurniture();
                newReservationFurniture.ReservationFurnitureID = Guid.NewGuid();
                newReservationFurniture.ReservationID = reservation.ReservationID;
                newReservationFurniture.FurnitureID = item.FurnitureID;

                _context.ReservationsFurnitures.Add(newReservationFurniture);
            }

            _context.SaveChanges();
            
            return new ReservationResponse { IsSuccessful = true, Errors = validationErrors };
        } 

        public double CalculateTotalPrice(double sumFurnitures, Reservation reservation, Building building)
        {
            var TotalPrice = sumFurnitures * reservation.TotalHours + building.HourlyRate * reservation.TotalHours;
            return TotalPrice;
        }
    }
}
