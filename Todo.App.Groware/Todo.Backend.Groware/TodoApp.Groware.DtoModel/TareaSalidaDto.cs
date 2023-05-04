using System.Collections.Specialized;

namespace TodoApp.Groware.DtoModel
{
    public class TareaSalidaDto
    {
        public int idTarea { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public string estado { get; set; }
        public string duracionNum { get; set; }
        public string duracionTipo { get; set; }
        public string fechaInicio { get; set; } 
        public string fechaFinal { get; set; }  

    }
}