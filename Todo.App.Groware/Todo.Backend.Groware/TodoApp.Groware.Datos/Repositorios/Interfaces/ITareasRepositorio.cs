using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Groware.DtoModel;
using TodoApp.Groware.Entidades;

namespace TodoApp.Groware.Datos.Repositorios.Interfaces
{
    public interface ITareasRepositorio
    {
        public IEnumerable<TareaSalidaDto> ObtenerTareas();

        public TareaSalidaDto AgregarTarea(Tarea tarea);

        public TareaSalidaDto ModificarTarea(ModificarTareaDto tarea);

        public bool EliminarTarea(int idTarea);

    }
}
