using Backed.API.DataAcces.Data;
using Backed.API.Models;
using Backend.API.DataAcces.Repositorio;
using Backend.API.DataAcces.Repositorio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backed.API.DataAcces.Repository
{
    public class RouteFlightRepository : Repositorio<RouteFlight>,IRouteFlightRepository
    {
        private readonly ApplicationDbContext _db;

        public RouteFlightRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;    
        }
        public void Actualizar(RouteFlight routeFlight)
        {
            var routeFlightBD = _db.RouteFlights.FirstOrDefault(b => b.Id== routeFlight.Id);
            if (routeFlightBD != null)
            {
                routeFlightBD.RouteName = routeFlight.RouteName;
                _db.SaveChanges();
            }
        }
    }
}
