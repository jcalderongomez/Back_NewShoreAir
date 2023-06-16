using Backend.API.DataAcces.Repositorio.IRepositorio;

namespace Backend.API.DataAcces.Repositorio.IRepositorio
{
    public interface IUnidadTrabajo : IDisposable 
    {

        IAirportRepository Airport { get; }

        IFlightRepository Flight{ get; }
        IRouteFlightRepository RouteFlight{ get; }

        Task Guardar();
    }
}