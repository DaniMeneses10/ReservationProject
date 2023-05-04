using System;

namespace ReservationsProject.Models.Entities
{
    public class Reservation
    {
        public Guid ReservationID { get; set; }
        public Guid BuildingID { get; set; }                
        public Guid ClientID { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double TotalPrice { get; set; }
        public int TotalHours { get; set; }
        public string EventType { get; set; }
    }
}
