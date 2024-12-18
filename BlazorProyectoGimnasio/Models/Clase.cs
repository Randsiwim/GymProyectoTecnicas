namespace Gimnasio.Models
{
    public class Clase
    {
        public int ClaseID { get; set; }
        public string Nombre { get; set; } // Este campo no puede ser null
        public TimeSpan? Horario { get; set; } // Nullable
        public int? Cupo { get; set; } // Nullable
        public int? EntrenadorID { get; set; } // Foreign Key nullable
        public virtual Usuario Entrenador { get; set; }
    }

}
