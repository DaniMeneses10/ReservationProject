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

    }
}
