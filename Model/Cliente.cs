using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    using System;

    namespace Model
    {
        public class Cliente
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public DateTime FechaNacimiento { get; set; }
            public string Membresia { get; set; }
            public DateTime FechaVencimientoMembresia { get; set; }

            public int DiasRestantesMembresia()
            {
                return (FechaVencimientoMembresia - DateTime.Now).Days;
            }
        }
    }

}
