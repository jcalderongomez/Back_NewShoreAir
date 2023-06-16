
using Backed.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Backed.API.DataAcces.Data
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) 
        {
            
        }

        public DbSet<Airport> Airports { get; set; }
        public DbSet<RouteFlight> RouteFlights { get; set; }

        public DbSet<Flight> Flights { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
