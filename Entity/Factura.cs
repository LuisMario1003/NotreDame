using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Factura
    {
        public int FacturaId { get; set; }
        public int ReservaId { get; set; }
        public decimal Total { get; set; }
        public DateTime FechaEmision { get; set; }
    }
}
