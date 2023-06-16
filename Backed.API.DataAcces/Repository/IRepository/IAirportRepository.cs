using Backed.API.Models;

namespace Backend.API.DataAcces.Repositorio.IRepositorio
{
    public interface IAirportRepository: IRepositorio<Airport>
    {
        void Actualizar(Airport airportOrigin);

    }
}
