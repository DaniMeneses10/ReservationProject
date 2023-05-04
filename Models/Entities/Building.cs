using System;

namespace ReservationsProject.Models.Entities
{
    public class Building
    {
        public Guid BuildingID { get; set; }
        public Guid OwnerID { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public double HourlyRate { get; set; }
    }
}
