using Dapper;
using Newtonsoft.Json;
using System.Data;
using System.Text.Json.Serialization;
using System.Threading;
using TodoApp.Groware.Datos.Contexto;
using TodoApp.Groware.Datos.Repositorios.Interfaces;
using TodoApp.Groware.DtoModel;
using TodoApp.Groware.Entidades;

namespace TodoApp.Groware.Datos.Repositorios.Implementaciones
{
    public class TareasRepositorio : ITareasRepositorio
    {
        private readonly DapperContext _context;

        public TareasRepositorio(DapperContext context)
        {
            _context = context;
        }

        public IEnumerable<TareaSalidaDto> ObtenerTareas()
        {

            using (var connection = _context.CreateConnection())
            {
                var query = "ObtenerTareas";
                var result = connection.QuerySingle<string>(query, commandType: CommandType.StoredProcedure);
                var tareas = JsonConvert.DeserializeObject<IEnumerable<TareaSalidaDto>>(result);
                return tareas;
            }
        }

        public TareaSalidaDto AgregarTarea(Tarea tarea)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "AgregarTarea";
                var parameters = new DynamicParameters();
                parameters.Add("titulo", tarea.titulo);
                parameters.Add("descripcion", tarea.descripcion);
                parameters.Add("responsable", tarea.responsable);
                parameters.Add("estado", tarea.estado);
                parameters.Add("duracionNum", tarea.duracion);
                parameters.Add("duracionTipo", tarea.duracionTipo);
                parameters.Add("fechaInicio", tarea.fechaInicio);
                parameters.Add("fechaFinal", tarea.fechaFinal);

                var result = connection.QuerySingle<TareaSalidaDto>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result;
            }

        }

        public TareaSalidaDto ModificarTarea(ModificarTareaDto tarea)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "ModificarTarea";
                var parameters = new DynamicParameters();
                parameters.Add("idTarea", tarea.Id);
                parameters.Add("titulo", tarea.titulo);
                parameters.Add("descripcion", tarea.descripcion);
                parameters.Add("responsable", tarea.responsable);
                parameters.Add("estado", tarea.estado);
                parameters.Add("duracionNum", tarea.duracion);
                parameters.Add("duracionTipo", tarea.duracionTipo);
                parameters.Add("fechaInicio", tarea.fechaInicio);
                parameters.Add("fechaFinal", tarea.fechaFinal);
                var result = connection.QuerySingle<TareaSalidaDto>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public bool EliminarTarea(int idTarea)  
        {
            using (var connection = _context.CreateConnection()) {
                var query = "EliminarTarea";
                var parameters = new DynamicParameters();
                parameters.Add("idTarea", idTarea);
                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0 ;
            } 
        }
    }
}
