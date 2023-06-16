using AutoMapper;
using Backed.API.Models;
using Backed.API.Models.Dto;
using Backend.API.DataAcces.Repositorio.IRepositorio;
using Microsoft.AspNetCore.Mvc;

namespace Backend.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlightController : ControllerBase
    {
        private readonly IUnidadTrabajo _unidadTrabajo;
        private readonly ILogger<FlightController> _logger;
        private readonly IMapper _mapper;
        protected ResponseDto _response;

        public FlightController(IUnidadTrabajo unidadTrabajo, ILogger<FlightController> logger,
                    IMapper mapper)
        {
            _unidadTrabajo = unidadTrabajo;
            _logger = logger;
            _mapper = mapper;
            _response = new ResponseDto();
        }




        [HttpGet]
        public async Task<ActionResult<List<FlightDto>>> GetFlights()
        {
            _logger.LogInformation("Listado de Flightes");
            var lista = await _unidadTrabajo.Flight.ObtenerTodos(incluirPropiedades: "RouteFlight");
            _response.Result = lista;
            _response.DisplayMessage = "Listado de Flights";

            return Ok(_response);
        }

        [HttpGet("{id}", Name = "GetFlight")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FlightDto>> GetCliente(int id)
        {
            if (id == 0)
            {
                _logger.LogError("Debe enviar el id");
                _response.DisplayMessage = "Debe enviar el id";
                _response.IsSuccess = false;
                return BadRequest(_response);
            }
            var airport = await _unidadTrabajo.Flight.Obtener(id);
            if (airport == null)
            {
                _logger.LogError("Flight no existe");
                _response.DisplayMessage = "Flight no existe";
                _response.IsSuccess = false;
                return BadRequest(_response);
            }

            _response.Result = airport;
            _response.DisplayMessage = "Datos de la airport" + airport.Id;
            return Ok(_response); //Status code = 200
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<FlightDto>> PostFlight([FromBody] FlightDto airportDto)
        {
            if (airportDto == null)
            {
                _response.DisplayMessage = "Información incorrecta";
                _response.IsSuccess = false;
                return BadRequest(_response);
            }

            //if (!ModelState.IsValid) {
            //    return BadRequest(ModelState);
            //}

            //var airportExiste = await _unidadTrabajo.Flight.ObtenerTodos(m=>m.Nombre.ToLower() == airportDto.Nombre.ToLower());
            //if (airportExiste != null) {
            //    ModelState.AddModelError("Nombre duplicado","Nombre del módulo ya existe");
            //    return BadRequest(ModelState);
            //}

            var airport = _mapper.Map<Flight>(airportDto);

            await _unidadTrabajo.Flight.Agregar(airport);
            await _unidadTrabajo.Guardar();
            return CreatedAtRoute("GetFlight", new { id = airportDto.Id }, airportDto); //Status code = 201
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> PutFlight(int id, [FromBody] FlightDto airportDto)
        {
            if (id != airportDto.Id)
            {
                return BadRequest("Id de la airport no existe");
            }

            //if (!ModelState.IsValid) {
            //    return BadRequest("Id airport no coincide");
            //}

            //var airportExiste = await _unidadTrabajo.Flight.ObtenerTodos(c => c.Nombre.ToLower() == airportDto.Nombre.ToLower()
            //                                                && c.Id != airportDto.Id);

            //if (airportExiste != null) {
            //    ModelState.AddModelError("Nombre Duplicado", "Nombre del módulo ya existe");
            //    return BadRequest(ModelState);
            //}

            var airport = _mapper.Map<Flight>(airportDto);

            _unidadTrabajo.Flight.Actualizar(airport);
            await _unidadTrabajo.Guardar();
            return Ok(airport);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteFlight(int id)
        {
            var airport = await _unidadTrabajo.Flight.Obtener(id);
            if (airport == null)
            {
                return NotFound();
            }
            _unidadTrabajo.Flight.Remover(airport);
            await _unidadTrabajo.Guardar();
            return NoContent();
        }
    }

    }
