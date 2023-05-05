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
            var errorsElement = new List<string>();

            var userErrors = ValidateUser(request.reservation.ClientID);   

            var availabilityErrors = ValidateBuildingAvailability(request.reservation);            

            var furnituresErrors = ValidateFurnituresAvailability(request);

            errorsElement.Add(userErrors);
            errorsElement.Add(availabilityErrors);
            errorsElement.Add(furnituresErrors);

            return errorsElement;
        }

        public string ValidateUser(Guid userID)
        {
            var user = this._context.Users.Where(x => x.UserID == userID).FirstOrDefault();
            
            var today = DateTime.Today;
            var age = today.Year - user.BirthDate?.Year;

            var userErrors = new List<string>();

            if (age <= 21)
                return ("A minor user cannot book or host");

            if (user.Status != UserStatus.AVAILABLE)
                return("User is blocked to book");

            return "";
        }

        public string ValidateBuildingAvailability(Reservation reservation)
        {
            var reservations = this._context.Reservations.Where(x => x.EventDate == reservation.EventDate
                                                                    && x.StartTime == reservation.StartTime
                                                                    && x.EndTime == reservation.EndTime
                                                                    && x.BuildingID == reservation.BuildingID).ToList();

            var availabilityErrors = new List<string>();

            if (reservation.EventType == null)
                return ("There is not an Event Type selected");

            if (reservations.Count > 0)
                return("There is not availability for this dates");

            if (reservation.StartTime.DayOfWeek == DayOfWeek.Sunday)
            {
                return("Reservations are not allowed on Sundays.");
            }
            else if (reservation.StartTime.DayOfWeek >= DayOfWeek.Monday && reservation.StartTime.DayOfWeek <= DayOfWeek.Thursday)
            {
                if (!(reservation.StartTime.TimeOfDay >= new TimeSpan(7, 30, 0) && reservation.StartTime.TimeOfDay <= new TimeSpan(21, 0, 0)))
                    return("Reservation must be from Monday to Thursday from 7:30am to 9:00pm and Friday and Saturday from 3:00pm to 11:00 pm ");

            }
            else if (reservation.StartTime.DayOfWeek >= DayOfWeek.Friday && reservation.StartTime.DayOfWeek <= DayOfWeek.Saturday)
            {
                if (!(reservation.StartTime.TimeOfDay >= new TimeSpan(15, 0, 0) && reservation.StartTime.TimeOfDay <= new TimeSpan(23, 0, 0)))
                    return ("Reservation must be from Monday to Thursday from 7:30am to 9:00pm and Friday and Saturday from 3:00pm to 11:00 pm ");
            }

            return "";
        }

        public string ValidateFurnituresAvailability(ReservationRequest request)
        {
            var reservation = request.reservation;
            var furnituresList = request.FurnituresList;
                        
            var furnituresErrors = new List<string>();

            if (furnituresList.Count > 10)
                furnituresErrors.Add("Is not possible to add more than 10 elements.");                        
                        
            foreach(var item1 in furnituresList)
            {
                var reservationFurniture = _context.ReservationsFurnitures.Where(x => x.FurnitureID == item1.FurnitureID).ToList();

                foreach(var item2 in reservationFurniture)
                {
                    var reservationItem = _context.Reservations.Where(x => x.ReservationID == item2.ReservationID).First();

                    if(reservation.StartTime >= reservationItem.StartTime && reservation.StartTime <= reservationItem.EndTime)
                    {
                        return ("In The Start Date the furniture is in use");
                    }
                    else if (reservation.EndTime >= reservationItem.StartTime && reservation.EndTime <= reservationItem.EndTime)
                    {
                        return ("In The End Date the furniture is in use");
                    }
                    else if (reservationItem.StartTime < reservation.StartTime && reservationItem.EndTime < reservation.EndTime )
                    {
                        return ("In those Dates the furniture is in use");
                    }
                    else if (reservationItem.StartTime > reservation.StartTime && reservationItem.EndTime > reservation.EndTime)
                    {
                        return ("In those Dates the furniture is in use");
                    }
                }           
            }

            return "";
        }
    }        
}
