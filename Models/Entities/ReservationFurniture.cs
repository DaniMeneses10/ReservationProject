using System;

namespace ReservationsProject.Models.Entities
{
    public class ReservationFurniture
    {
        public Guid ReservationFurnitureID { get; set; }
        public Guid ReservationID { get; set; }
        public Guid FurnitureID { get; set; }
    }
}
