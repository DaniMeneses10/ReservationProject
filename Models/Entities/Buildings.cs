namespace ReservationsProject.Models.Entities
{
    public class Buildings
    {
        public int BuildingID { get; set; }
        public int OwnerID { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public double HourlyRate { get; set; }
    }
}
