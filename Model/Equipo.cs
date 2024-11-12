using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    using Model;
    public class Equipo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCompra { get; set; }
        public int VidaUtilMeses { get; set; }
        public bool EnUso { get; set; }
        // Método para verificar vida útil
    }

}
