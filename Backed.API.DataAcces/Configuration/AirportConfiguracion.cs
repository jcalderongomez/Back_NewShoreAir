using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Backed.API.Models;

namespace Backend.API.DataAcces.Configuration
{
    public class AirportConfiguracion : IEntityTypeConfiguration<Airport>
    {
        public void Configure(EntityTypeBuilder<Airport> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.IATACode).IsRequired().HasMaxLength(5);
            builder.Property(x => x.Location).IsRequired().HasMaxLength(50);
        }
    }
}
