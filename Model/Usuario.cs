using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    using System;
    using System.Collections.Generic;

    namespace Model
    {
        public class Entrenador
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string PuntosFuertes { get; set; }  // Ejemplo: "Fuerza, Cardio"
            public List<Horario> Horarios { get; set; }  // Lista de horarios disponibles para el entrenador
        }

        public class Cliente
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Correo { get; set; }
            public string Telefono { get; set; }
            public string Membresia { get; set; }
        }

        public class Clase
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public List<Horario> Horarios { get; set; } // Horarios en los que se ofrece la clase
        }

        public class Horario
        {
            public DayOfWeek Dia { get; set; }  // Día de la semana (Lunes, Martes, etc.)
            public TimeSpan HoraInicio { get; set; }  // Hora de inicio de la clase
        }

        public class Usuario
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }

}
