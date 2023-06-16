using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Backed.API.Models;

namespace Backend.API.DataAcces.Configuration
{
    public class RouteFlightConfiguracion : IEntityTypeConfiguration<RouteFlight>
    {
        public void Configure(EntityTypeBuilder<RouteFlight> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.RouteName).IsRequired();

        }
    }
}
