namespace Gimnasio.Models
{
    public class ReporteClasesPopulares
    {
        public string Clase { get; set; }
        public TimeSpan? Horario { get; set; }
        public int TotalReservas { get; set; }
    }
}