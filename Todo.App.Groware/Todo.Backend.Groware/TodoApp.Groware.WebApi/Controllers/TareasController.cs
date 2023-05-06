using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using TodoApp.Groware.DtoModel;
using TodoApp.Groware.Entidades;
using TodoApp.Groware.Negocio.Tareas;

namespace TodoApp.Groware.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareasController : Controller
    {
        private readonly ITareasNegocio _tareasNegocio;

        public TareasController(ITareasNegocio tareasNegocio)
        {
            _tareasNegocio = tareasNegocio;
        }

        [HttpGet("ObtenerTareas")]
        public IActionResult ObtenerTareas()
        {
            var response = _tareasNegocio.ObtenerMovimientos();
            if (response.IsSuccess) { return Ok(response); }

            return BadRequest(response.Message);

        }

        [HttpPost("AgregarTarea")]
        public IActionResult ObtenerTareas([FromBody] Tarea tarea)
        {
            if (tarea == null)
            {
                return BadRequest();
            }
            var response = _tareasNegocio.AgregarTarea(tarea);

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpPut("ModificarTarea")]
        public IActionResult ObtenerTareas([FromBody] ModificarTareaDto tarea)
        {
            if (tarea == null)
            {
                return BadRequest();
            }
            var response = _tareasNegocio.ModificarTarea(tarea);

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);

        }

        [HttpDelete("EliminarTarea/{idTarea}")]
        public IActionResult EliminarTarea(string idTarea) 
        {
            if (idTarea == null)
            {
                return BadRequest();
            }
            var response = _tareasNegocio.EliminarTarea( int.Parse(idTarea) );

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }
    }
}
