using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{

    public class Factura
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }  
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public string Descripcion { get; set; }
    }

}
