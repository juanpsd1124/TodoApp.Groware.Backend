using System.Collections.Specialized;

namespace TodoApp.Groware.DtoModel
{
    public class TareaSalidaDto
    {
        public int idTarea { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public string duracionNum { get; set; }
        public string duracionTipo { get; set; }
        public string fechaInicio { get; set; } 
        public string FechaFinal { get; set; }  

    }
}