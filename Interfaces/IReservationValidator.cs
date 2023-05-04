using ReservationsProject.Models.Entities;
using ReservationsProject.Models.Requests;
using System;
using System.Collections.Generic;

namespace ReservationsProject.Interfaces
{
    public interface IReservationValidator
    {
        List<string> Validate(ReservationRequest request);
        bool ValidateUser(Guid userID);
        bool ValidateBuildingAvailability(Reservation reservation);
        bool ValidateFurnituresAvailability(ReservationRequest request);
    }
}
