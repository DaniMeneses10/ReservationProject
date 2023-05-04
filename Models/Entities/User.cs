using System;

namespace ReservationsProject.Models.Entities
{
    public class User
    {
        public  int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Cellphone { get; set; }
        public string Type { get; set; }
        public DateTime BirthDate { get; set; }
        public string Status { get; set; }
        public bool IsHost { get; set; }
        public DateTime DeleteDate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
