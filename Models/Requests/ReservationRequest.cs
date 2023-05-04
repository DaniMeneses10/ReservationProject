using ReservationsProject.Models.Entities;
using System.Collections.Generic;

namespace ReservationsProject.Models.Requests
{
    public class ReservationRequest
    {
        public Reservation reservation { get; set; }
        public List<Furniture> FurnituresList { get; set; }        
    }
}
