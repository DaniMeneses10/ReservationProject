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
        IUserService _userservice;
        public ReservationService(IUserService userService)
        {
            _userservice = userService;
        }

        public ReservationResponse CreateReservation(ReservationRequest request)
        {
            var reservation = request.reservation;
            var furnituresList = request.FurnituresList;

            var validationErrors = ReservationValidator.Validate(request);

            if (validationErrors.Any())
            {
                return new ReservationResponse { IsSuccessful = false, Errors = validationErrors };
            }

            var building = this._context.Building.Where(x => x.BuildingID == reservation.BuildingID).ToList();

            var newReservation = new Reservation();
            newReservation.ReservationID = reservation.ReservationID;
            newReservation.BuildingID = reservation.BuildingID;
            newReservation.ClientID = reservation.ClientID;
            newReservation.EventDate = reservation.EventDate;
            newReservation.StartTime = reservation.StartTime;
            newReservation.EndTime = reservation.EndTime;

            double sumTotalFurnituresValues = furnituresList.Sum(x => x.HourlyRate);
            newReservation.TotalPrice = (sumTotalFurnituresValues * reservation.TotalHours + building.HourlyRate * reservation.TotalHours);  

            _context.Reservations.Add(newReservation);

            foreach(var item in furnituresList)
            {
                item.IsAvailable = false;

                var newReservationFurniture = new ReservationFurniture();
                newReservationFurniture.ReservationID = reservation.ReservationID;
                newReservationFurniture.FurnitureID = item.FurnitureID;

                _context.ReservationsFurnitures.Add(newReservationFurniture);
            }

            _context.SaveChanges();
            
            return new ReservationResponse { IsSuccessful = true, Errors = validationErrors }; ;

        }        
    }
}
