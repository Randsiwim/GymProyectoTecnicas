using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    using Model;
    public class Entrenador
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string PuntosFuertes { get; set; }
        public List<Clase> ClasesAsignadas { get; set; }  // Clases que imparte
    }

}
