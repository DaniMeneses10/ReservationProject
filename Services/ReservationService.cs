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
    public class ReservationService : IReservationService
    {
        ReservationDBContext _context;        
        IReservationValidator _reservationValidator;
        public ReservationService(ReservationDBContext context,                                     
                                    IReservationValidator reservationValidator)
        {            
            _context = context;
            _reservationValidator = reservationValidator;
        }

        public ReservationResponse CreateReservation(ReservationRequest request)
        {
            var reservation = request.reservation;
            var furnituresList = request.FurnituresList;

            var validationErrors = _reservationValidator.Validate(request);

            if (validationErrors == null)
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

            TimeSpan difference = reservation.EndTime - reservation.StartTime;
            reservation.TotalHours = (int)difference.TotalHours;
            newReservation.TotalHours = reservation.TotalHours;

            newReservation.EventType = reservation.EventType;
                        
            double sumTotalFurnituresValues = furnituresList.Sum(x => x.HourlyRate);

            newReservation.TotalPrice = CalculateTotalPrice(sumTotalFurnituresValues, reservation, building );            

            _context.Reservations.Add(newReservation);
            
            foreach(var item in furnituresList)
            {
                var newReservationFurniture = new ReservationFurniture();
                newReservationFurniture.ReservationFurnitureID = Guid.NewGuid();
                newReservationFurniture.ReservationID = newReservation.ReservationID;
                newReservationFurniture.FurnitureID = item.FurnitureID;

                _context.ReservationsFurnitures.Add(newReservationFurniture);
            }

            _context.SaveChanges();
            
            return new ReservationResponse { IsSuccessful = true, Errors = validationErrors };
        } 

        public double CalculateTotalPrice(double sumFurnitures, Reservation reservation, Building building)
        {
            double TotalPrice = sumFurnitures * reservation.TotalHours + (double)building.HourlyRate * reservation.TotalHours;
                        
            return TotalPrice;
        }
    }
}
