using ReservationsProject.Models.Entities;
using ReservationsProject.Models.Requests;
using ReservationsProject.Models.Responses;

namespace ReservationsProject.Interfaces
{
    public interface IReservationService
    {
        ReservationResponse CreateReservation(ReservationRequest request);
        double CalculateTotalPrice(double sumFurnitures, Reservation reservation, Building building);
    }
}
