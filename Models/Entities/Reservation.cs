using System;

namespace ReservationsProject.Models.Entities
{
    public class Reservation
    {
        public int ReservationID { get; set; }
        public int BuildingID { get; set; }                
        public int ClientID { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double TotalPrice { get; set; }
        public int TotalHours { get; set; }
        public string EventType { get; set; }
    }
}
