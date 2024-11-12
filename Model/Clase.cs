using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Model
{
    using Model;


    public class Clase
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime Horario { get; set; }
        public int CupoMaximo { get; set; }
        public Entrenador EntrenadorAsignado { get; set; }
        public List<Cliente> Reservas { get; set; }  // Clientes que reservaron
    }

}
