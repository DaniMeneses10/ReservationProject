using ReservationsProject.Models.Entities;
using ReservationsProject.Models.Requests;
using System;
using System.Collections.Generic;

namespace ReservationsProject.Interfaces
{
    public interface IReservationValidator
    {
        List<string> Validate(ReservationRequest request);
        string ValidateUser(Guid userID);
        string ValidateBuildingAvailability(Reservation reservation);
        string ValidateFurnituresAvailability(ReservationRequest request);
    }
}
