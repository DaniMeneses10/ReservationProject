using Microsoft.EntityFrameworkCore;
using ReservationsProject.Models.Entities;


namespace ReservationsProject.Database
{
    public class ReservationDBContext : DbContext
    {
        public ReservationDBContext(DbContextOptions<ReservationDBContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<ReservationFurniture> ReservationsFurnitures { get; set; }
        public DbSet<Furniture> Furnitures { get; set; }

    }
}
