using Model.Model;
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
    public class Reserva
    {
        public int Id { get; set; }
        public Clase Clase { get; set; } // Clase asociada a la reserva
        public Cliente Cliente { get; set; } // Cliente que realiza la reserva
        public DateTime FechaReserva { get; set; }
        public DateTime FechaHoraReserva { get; set; } // Fecha y hora de la clase reservada
    }
}

