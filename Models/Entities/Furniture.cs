using System;

namespace ReservationsProject.Models.Entities
{
    public class Furniture
    {
        public Guid FurnitureID { get; set; }
        public bool IsAvailable { get; set; }
        public string Description { get; set; }
        public double HourlyRate { get; set; }
    }
}
