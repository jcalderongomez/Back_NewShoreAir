using Backed.API.DataAcces.Data;
using Backed.API.Models;
using Backed.API.Models.Dto;
using Backend.API.DataAcces.Repositorio;
using Backend.API.DataAcces.Repositorio.IRepositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backed.API.DataAcces.Repository
{
    public class FlightRepository : Repositorio<Flight>,IFlightRepository
    {
        private readonly ApplicationDbContext _db;

        public FlightRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;    
        }
        public void Actualizar(Flight flight)
        {
            var flightBD = _db.Flights.FirstOrDefault(b => b.Id== flight.Id);
            if (flightBD != null)
            {
                flightBD.AirportOrigin= flight.AirportOrigin;
                flightBD.AirportDestine = flight.AirportDestine;
                flightBD.DepartureTime = flight.DepartureTime;
                flightBD.ArrivalTime= flight.ArrivalTime;
                flightBD.RouteFlight= flight.RouteFlight;

                _db.SaveChanges();
            }
        }
    }
}
