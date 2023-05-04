using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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



    }
}
