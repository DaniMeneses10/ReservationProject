using ReservationsProject.Models.Entities;
using ReservationsProject.Models.Requests;
using System;
using System.Collections.Generic;
using static ReservationsProject.Common.Constants;
using System.ComponentModel.DataAnnotations;
using ReservationsProject.Database;
using ReservationsProject.Interfaces;
using System.Linq;

namespace ReservationsProject.Models.Validator
{
    public class ReservationValidator : IReservationValidator
    {
        ReservationDBContext _context;        
        public ReservationValidator(ReservationDBContext context)
        {            
            _context = context;
        }
        public List<string> Validate(ReservationRequest request)
        {
            var errorsList = new List<string>();
            
            ValidateUser(request.reservation.ClientID);
            
            ValidateBuildingAvailability(request.reservation);

            ValidateFurnituresAvailability(request);            

            return errorsList;
        }

        public bool ValidateUser(Guid userID)
        {
            var user = this._context.Users.Where(x => x.UserID == userID).FirstOrDefault();
            
            var today = DateTime.Today;
            var age = today.Year - user.BirthDate.Year;

            if (age <= 21)
                throw new ValidationException("A minor user cannot book or host");

            if (user.Status != UserStatus.AVAILABLE)
                throw new ValidationException("User is blocked to book");

            return true;
        }

        public bool ValidateBuildingAvailability(Reservation reservation)
        {
            var reservations = this._context.Reservations.Where(x => x.EventDate == reservation.EventDate
                                                                    && x.StartTime == reservation.StartTime
                                                                    && x.EndTime == reservation.EndTime
                                                                    && x.BuildingID == reservation.BuildingID).ToList();

            if (reservations.Count > 0)
                throw new ValidationException("There is not availability for this dates");

            if (reservation.StartTime.DayOfWeek == DayOfWeek.Sunday)
            {
                throw new ValidationException("Reservations are not allowed on Sundays.");
            }
            else if (reservation.StartTime.DayOfWeek >= DayOfWeek.Monday && reservation.StartTime.DayOfWeek <= DayOfWeek.Thursday)
            {
                if (!(reservation.StartTime.TimeOfDay >= new TimeSpan(7, 30, 0) && reservation.StartTime.TimeOfDay <= new TimeSpan(21, 0, 0)))
                    throw new ValidationException("Reservation is not allowed outside of business hours.");

            }
            else if (reservation.StartTime.DayOfWeek >= DayOfWeek.Friday && reservation.StartTime.DayOfWeek <= DayOfWeek.Saturday)
            {
                if (!(reservation.StartTime.TimeOfDay >= new TimeSpan(15, 0, 0) && reservation.StartTime.TimeOfDay <= new TimeSpan(23, 0, 0)))
                    throw new ValidationException("Reservation is not allowed outside of business hours.");
            }

            return true;
        }

        public bool ValidateFurnituresAvailability(ReservationRequest request)
        {
            var furnituresList = request.FurnituresList;
            
            foreach(var item in furnituresList)
            {
                if (!item.IsAvailable)
                {
                    throw new ValidationException($"{item.Description} is not available");
                }            
            }

            return true;
        }
    }        
}
