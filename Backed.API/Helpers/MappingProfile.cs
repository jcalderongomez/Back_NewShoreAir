using AutoMapper;
using Backed.API.Models;
using Backed.API.Models.Dto;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Backed.API.Helpers
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            
            CreateMap<Flight, FlightDto>().ReverseMap();
            CreateMap<Airport,AirportDto>().ReverseMap();
            CreateMap<RouteFlight, RouteFlightDto>().ReverseMap();
        }



    }
}
