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
    public class AirportRepository : Repositorio<Airport>, IAirportRepository
    {
        private readonly ApplicationDbContext _db;

        public AirportRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;    
        }
        public void Actualizar(Airport airport)
        {
            var airportBD = _db.Airports.FirstOrDefault(b => b.Id== airport.Id);
            if (airportBD != null)
            {
                airportBD.Name= airport.Name;
                airportBD.IATACode= airport.IATACode;
                airportBD.Location = airport.Location;
                
                _db.SaveChanges();
            }
        }


    }
}
