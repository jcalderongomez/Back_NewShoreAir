using Backed.API.Models;

namespace Backend.API.DataAcces.Repositorio.IRepositorio
{
    public interface IFlightRepository : IRepositorio<Flight>
    {
        void Actualizar(Flight flight);

    }
}
