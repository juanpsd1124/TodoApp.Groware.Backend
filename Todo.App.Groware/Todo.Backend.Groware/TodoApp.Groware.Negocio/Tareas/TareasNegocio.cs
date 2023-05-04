using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Groware.Datos.Repositorios.Interfaces;
using TodoApp.Groware.DtoModel;
using TodoApp.Groware.Entidades;
using TodoApp.Groware.Utils;

namespace TodoApp.Groware.Negocio.Tareas
{
    public class TareasNegocio : ITareasNegocio
    {
        private readonly IUnitOfWork _unitOfWork;

        public TareasNegocio(IUnitOfWork unitOfWork) 
        { 
            _unitOfWork = unitOfWork;
        }

        public Response<IEnumerable<TareaSalidaDto>> ObtenerMovimientos()
        {
            var response = new Response<IEnumerable<TareaSalidaDto>>();

            try 
            {
                var tareas = _unitOfWork.Tareas.ObtenerTareas();
                response.Data = tareas;

                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public Response<TareaSalidaDto> AgregarTarea(Tarea tarea) 
        { 
            var response = new Response<TareaSalidaDto>();

            try 
            {
                var tareaAgregada = _unitOfWork.Tareas.AgregarTarea(tarea);
                response.Data = tareaAgregada;
                if (response.Data != null) 
                {
                    response.IsSuccess = true;
                    response.Message = "Tarea agregada exitosamente";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;

        }
    }
}
