using Backed.API.DataAcces.Data;
using Backed.API.Models;
using Backend.API.DataAcces.Repositorio.IRepositorio;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backed.API.DataAcces.Repository
{
    public class UnidadTrabajo : IUnidadTrabajo
    {
        private readonly ApplicationDbContext _db;
        private readonly IConfiguration _configuration;

        public IAirportRepository Airport{ get; private set; }
        
        public IFlightRepository Flight { get; private set; }
        public IRouteFlightRepository RouteFlight{ get; private set; }

        public UnidadTrabajo(ApplicationDbContext db, IConfiguration configuration)
        {
            _db = db;
            _configuration = configuration;
            Airport= new AirportRepository(_db);            
            Flight = new FlightRepository(_db);
            RouteFlight = new RouteFlightRepository(_db);
            
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task Guardar()
        {
            await _db.SaveChangesAsync();
        }
    }
}

