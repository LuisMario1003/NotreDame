using NotreDame.DAL;
using NotreDame.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotreDame.BLL
{
    public class FacturaBLL
    {
        private FacturaDAL _facturaDAL = new FacturaDAL();
        private ReservaBLL _reservaBLL = new ReservaBLL();
        private ServicioAdicionalBLL _servicioAdicionalBLL = new ServicioAdicionalBLL();

        public void RegistrarFactura(Factura factura, List<int> serviciosSeleccionados)
        {
            decimal montoTotal = CalcularMontoTotal(factura.ReservaID, serviciosSeleccionados);
            factura.MontoTotal = montoTotal;

            _facturaDAL.AgregarFactura(factura, serviciosSeleccionados);
        }

        public List<Factura> ObtenerFacturas()
        {
            return _facturaDAL.ObtenerFacturas();
        }

        public Factura ObtenerFacturaPorId(int facturaID)
        {
            return _facturaDAL.ObtenerFacturaPorId(facturaID);
        }

        public void ActualizarFactura(Factura factura, List<int> serviciosSeleccionados)
        {
            decimal montoTotal = CalcularMontoTotal(factura.ReservaID, serviciosSeleccionados);
            factura.MontoTotal = montoTotal;

            _facturaDAL.ActualizarFactura(factura, serviciosSeleccionados);
        }

        public void EliminarFactura(int facturaID)
        {
            _facturaDAL.EliminarFactura(facturaID);
        }

        private decimal CalcularMontoTotal(int reservaID, List<int> serviciosSeleccionados)
        {
            Reserva reserva = _reservaBLL.ObtenerReservaPorId(reservaID);
            decimal montoTotal = reserva.MontoTotal;

            foreach (int servicioID in serviciosSeleccionados)
            {
                ServicioAdicional servicio = _servicioAdicionalBLL.ObtenerServicioAdicionalPorId(servicioID);
                montoTotal += servicio.Precio;
            }

            return montoTotal;
        }

    }
}
