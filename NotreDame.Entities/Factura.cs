using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotreDame.Entities
{
    public class Factura
    {
        public int FacturaID { get; set; }
        public string CodigoFactura { get; set; } // Nuevo campo
        public int ReservaID { get; set; }
        public DateTime Fecha { get; set; }
        public decimal MontoTotal { get; set; }
        public Cliente Cliente { get; set; }
        public Habitacion Habitacion { get; set; }
        public List<ServicioAdicional> ServiciosAdicionales { get; set; } // Asegúrate de obtener esta lista en el DAL


    }
}
