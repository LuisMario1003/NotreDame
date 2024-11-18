using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotreDame.Entities
{
    public class ServicioAdicional
    {
        public int ServicioID { get; set; }
        public string CodigoServicio { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
    }
}
