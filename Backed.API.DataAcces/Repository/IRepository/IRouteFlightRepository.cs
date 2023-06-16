using Backed.API.Models;

namespace Backend.API.DataAcces.Repositorio.IRepositorio
{
    public interface IRouteFlightRepository: IRepositorio<RouteFlight>
    {
        void Actualizar(RouteFlight routeFlight);

    }
}
