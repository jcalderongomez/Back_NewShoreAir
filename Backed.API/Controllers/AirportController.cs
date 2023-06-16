using AutoMapper;
using Backed.API.Models;
using Backed.API.Models.Dto;
using Backend.API.DataAcces.Repositorio.IRepositorio;
using Microsoft.AspNetCore.Mvc;

namespace Backend.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AirportController : ControllerBase
    {
        private readonly IUnidadTrabajo _unidadTrabajo;
        private readonly ILogger<AirportController> _logger;
        private readonly IMapper _mapper;
        protected ResponseDto _response;

        public AirportController(IUnidadTrabajo unidadTrabajo, ILogger<AirportController> logger, 
                    IMapper mapper)
        {
            _unidadTrabajo = unidadTrabajo;
            _logger = logger;
            _mapper = mapper;
            _response = new ResponseDto();
        }

        [HttpGet]
        public async Task<ActionResult<List<AirportDto>>> GetAirports()
        {
            _logger.LogInformation("Listado de Airportes");
            var lista = await _unidadTrabajo.Airport.ObtenerTodos();
            _response.Result = lista;
            _response.DisplayMessage = "Listado de Airports";

            return Ok(_response);
        }

        [HttpGet("{id}", Name = "GetAirport")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AirportDto>> GetCliente(int id)
        {
            if (id == 0) 
            {
                _logger.LogError("Debe enviar el id");
                _response.DisplayMessage = "Debe enviar el id";
                _response.IsSuccess = false;
                return BadRequest(_response);
            }
            var airport = await _unidadTrabajo.Airport.Obtener(id);
            if (airport == null) {
                _logger.LogError("Airport no existe");
                _response.DisplayMessage = "Airport no existe";
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
        public async Task<ActionResult<AirportDto>> PostAirport([FromBody] AirportDto airportDto)
        {
            if(airportDto == null)
            {
                _response.DisplayMessage = "Información incorrecta";
                _response.IsSuccess = false;
                return BadRequest(_response);
            }

            //if (!ModelState.IsValid) {
            //    return BadRequest(ModelState);
            //}

            //var airportExiste = await _unidadTrabajo.Airport.ObtenerTodos(m=>m.Nombre.ToLower() == airportDto.Nombre.ToLower());
            //if (airportExiste != null) {
            //    ModelState.AddModelError("Nombre duplicado","Nombre del módulo ya existe");
            //    return BadRequest(ModelState);
            //}

            var airport = _mapper.Map<Airport>(airportDto);

            await _unidadTrabajo.Airport.Agregar(airport);
            await _unidadTrabajo.Guardar();
            return CreatedAtRoute("GetAirport", new { id = airportDto.Id }, airportDto); //Status code = 201
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> PutAirport(int id, [FromBody] AirportDto airportDto) { 
            if(id != airportDto.Id){
                return BadRequest("Id de la airport no existe");
            }

            //if (!ModelState.IsValid) {
            //    return BadRequest("Id airport no coincide");
            //}

            //var airportExiste = await _unidadTrabajo.Airport.ObtenerTodos(c => c.Nombre.ToLower() == airportDto.Nombre.ToLower()
            //                                                && c.Id != airportDto.Id);

            //if (airportExiste != null) {
            //    ModelState.AddModelError("Nombre Duplicado", "Nombre del módulo ya existe");
            //    return BadRequest(ModelState);
            //}
            
            var airport = _mapper.Map<Airport>(airportDto);
            
            _unidadTrabajo.Airport.Actualizar(airport);
            await _unidadTrabajo.Guardar();
            return Ok(airport);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteAirport(int id)
        {
            var airport = await _unidadTrabajo.Airport.Obtener(id);
            if (airport == null) {
                return NotFound();
            }
            _unidadTrabajo.Airport.Remover(airport);
            await _unidadTrabajo.Guardar();
            return NoContent();
        }
    }
}
