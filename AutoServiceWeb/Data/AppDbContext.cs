using AutoServiceWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoServiceWeb.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<ServiceOrder> ServiceOrders { get; set; }
    }
}