using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Groware.DtoModel;
using TodoApp.Groware.Entidades;
using TodoApp.Groware.Utils;

namespace TodoApp.Groware.Negocio.Tareas
{
    public interface ITareasNegocio
    {
        Response<IEnumerable<TareaSalidaDto>> ObtenerMovimientos();
        Response<TareaSalidaDto> AgregarTarea(Tarea tarea);

    }
}
