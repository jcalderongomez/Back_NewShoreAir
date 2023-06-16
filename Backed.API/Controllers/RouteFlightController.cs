using AutoMapper;
using Backed.API.Models;
using Backed.API.Models.Dto;
using Backend.API.DataAcces.Repositorio.IRepositorio;
using Microsoft.AspNetCore.Mvc;

namespace Backend.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RouteFlightController : ControllerBase
    {
        private readonly IUnidadTrabajo _unidadTrabajo;
        private readonly ILogger<RouteFlightController> _logger;
        private readonly IMapper _mapper;
        protected ResponseDto _response;

        public RouteFlightController(IUnidadTrabajo unidadTrabajo, ILogger<RouteFlightController> logger, 
                    IMapper mapper)
        {
            _unidadTrabajo = unidadTrabajo;
            _logger = logger;
            _mapper = mapper;
            _response = new ResponseDto();
        }

        [HttpGet]
        public async Task<ActionResult<List<RouteFlightDto>>> GetRouteFlights()
        {
            _logger.LogInformation("Listado de RouteFlightes");
            var lista = await _unidadTrabajo.RouteFlight.ObtenerTodos();
            _response.Result = lista;
            _response.DisplayMessage = "Listado de RouteFlights";

            return Ok(_response);
        }

        [HttpGet("{id}", Name = "GetRouteFlight")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RouteFlightDto>> GetCliente(int id)
        {
            if (id == 0) 
            {
                _logger.LogError("Debe enviar el id");
                _response.DisplayMessage = "Debe enviar el id";
                _response.IsSuccess = false;
                return BadRequest(_response);
            }
            var routeFlight = await _unidadTrabajo.RouteFlight.Obtener(id);
            if (routeFlight == null) {
                _logger.LogError("RouteFlight no existe");
                _response.DisplayMessage = "RouteFlight no existe";
                _response.IsSuccess = false;
                return BadRequest(_response);
            }

            _response.Result = routeFlight;
            _response.DisplayMessage = "Datos de la routeFlight" + routeFlight.Id;
            return Ok(_response); //Status code = 200
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RouteFlightDto>> PostRouteFlight([FromBody] RouteFlightDto routeFlightDto)
        {
            if(routeFlightDto == null)
            {
                _response.DisplayMessage = "Información incorrecta";
                _response.IsSuccess = false;
                return BadRequest(_response);
            }

            //if (!ModelState.IsValid) {
            //    return BadRequest(ModelState);
            //}

            //var routeFlightExiste = await _unidadTrabajo.RouteFlight.ObtenerTodos(m=>m.Nombre.ToLower() == routeFlightDto.Nombre.ToLower());
            //if (routeFlightExiste != null) {
            //    ModelState.AddModelError("Nombre duplicado","Nombre del módulo ya existe");
            //    return BadRequest(ModelState);
            //}

            var routeFlight = _mapper.Map<RouteFlight>(routeFlightDto);

            await _unidadTrabajo.RouteFlight.Agregar(routeFlight);
            await _unidadTrabajo.Guardar();
            return CreatedAtRoute("GetRouteFlight", new { id = routeFlightDto.Id }, routeFlightDto); //Status code = 201
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> PutRouteFlight(int id, [FromBody] RouteFlightDto routeFlightDto) { 
            if(id != routeFlightDto.Id){
                return BadRequest("Id de la routeFlight no existe");
            }

            //if (!ModelState.IsValid) {
            //    return BadRequest("Id routeFlight no coincide");
            //}

            //var routeFlightExiste = await _unidadTrabajo.RouteFlight.ObtenerTodos(c => c.Nombre.ToLower() == routeFlightDto.Nombre.ToLower()
            //                                                && c.Id != routeFlightDto.Id);

            //if (routeFlightExiste != null) {
            //    ModelState.AddModelError("Nombre Duplicado", "Nombre del módulo ya existe");
            //    return BadRequest(ModelState);
            //}
            
            var routeFlight = _mapper.Map<RouteFlight>(routeFlightDto);
            
            _unidadTrabajo.RouteFlight.Actualizar(routeFlight);
            await _unidadTrabajo.Guardar();
            return Ok(routeFlight);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteRouteFlight(int id)
        {
            var routeFlight = await _unidadTrabajo.RouteFlight.Obtener(id);
            if (routeFlight == null) {
                return NotFound();
            }
            _unidadTrabajo.RouteFlight.Remover(routeFlight);
            await _unidadTrabajo.Guardar();
            return NoContent();
        }
    }
}
