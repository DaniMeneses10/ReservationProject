using Microsoft.AspNetCore.Mvc;
using ReservationsProject.Interfaces;
using ReservationsProject.Models.Entities;
using ReservationsProject.Models.Requests;
using ReservationsProject.Models.Responses;

namespace ReservationsProject.Controllers
{
    [Route("api/Reservation")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        IReservationService _reservationService;
        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpPost]
        [Route("CreateReservation")]
        public ReservationResponse CreateReservation(ReservationRequest request)
        {
            return this._reservationService.CreateReservation(request);
        }
    }
}
