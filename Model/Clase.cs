using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Model
{
    public class Clase
    {
        public int Id { get; set; } // Identificador único de la clase
        public string Nombre { get; set; } // Nombre de la clase
        public DateTime Horario { get; set; } // Fecha y hora de la clase
        public int CupoMaximo { get; set; } // Máximo de clientes permitidos
        public string EntrenadorAsignado { get; set; } // Nombre del entrenador
        public List<string> Reservas { get; set; } // Lista de nombres de clientes que reservaron

        // Constructor para inicializar la lista de reservas
        public Clase()
        {
            Reservas = new List<string>();
        }
    }
}

