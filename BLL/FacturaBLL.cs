using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class FacturaBLL
    {
        private FacturaDAL facturaDAL = new FacturaDAL();

        public List<Factura> ObtenerFacturas()
        {
            return facturaDAL.ObtenerFacturas();
        }

        public void AgregarFactura(Factura factura)
        {
            facturaDAL.InsertarFactura(factura);
        }
    }
}
