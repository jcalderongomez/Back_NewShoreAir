using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Backed.API.Models;

namespace Backend.API.DataAcces.Configuration
{
    public class FlightConfiguracion : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.AirportOriginId).IsRequired();
            builder.Property(x => x.AirportDestineId).IsRequired();
            builder.Property(x => x.DepartureTime).IsRequired().HasMaxLength(50);
            builder.Property(x => x.ArrivalTime).IsRequired().HasMaxLength(50);
            builder.Property(x => x.RouteFlightId).IsRequired().HasMaxLength(50);


            //Relation
            builder.HasOne(x => x.AirportOrigin).WithMany()
                              .HasForeignKey(x => x.AirportOriginId)
                              .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.AirportDestine).WithMany()
                  .HasForeignKey(x => x.AirportDestineId)
                  .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
