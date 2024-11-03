using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ReservaBLL
    {
        private ReservaDAL reservaDAL = new ReservaDAL();
        private ReservaServicioDAL reservaServicioDAL = new ReservaServicioDAL();
        private FacturaDAL facturaDAL = new FacturaDAL();

        public List<Reserva> ObtenerReservas()
        {
            return reservaDAL.ObtenerReservas();
        }

        public void AgregarReserva(Reserva reserva)
        {
            reservaDAL.InsertarReserva(reserva);
        }

        public void ActualizarReserva(Reserva reserva)
        {
            reservaDAL.ActualizarReserva(reserva);
        }

        public void EliminarReserva(int reservaId)
        {
            reservaDAL.EliminarReserva(reservaId);
        }
        public void AgregarServicioAReserva(int reservaId, int servicioId)
        {
            reservaServicioDAL.AgregarServicioAReserva(reservaId, servicioId);
        }

        public List<ServicioAdicional> ObtenerServiciosDeReserva(int reservaId)
        {
            return reservaServicioDAL.ObtenerServiciosDeReserva(reservaId);
        }

        public decimal CalcularTotalReserva(int reservaId)
        {
            return facturaDAL.CalcularTotalReserva(reservaId);
        }
    }
}
