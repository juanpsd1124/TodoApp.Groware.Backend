namespace TodoApp.Groware.Entidades
{
    public class Tarea
    {
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public string responsable { get; set; }
        public int estado { get; set; }
        public int duracion { get; set;}
        public string duracionTipo { get; set; }
        public string fechaInicio { get; set; }
        public string fechaFinal { get; set; }

    }
}