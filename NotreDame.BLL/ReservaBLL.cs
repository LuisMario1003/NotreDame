using NotreDame.DAL;
using NotreDame.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotreDame.BLL
{
    public class ReservaBLL
    {
        private ReservaDAL _reservaDAL = new ReservaDAL();
        private HabitacionDAL _habitacionDAL = new HabitacionDAL();

        public void RegistrarReserva(Reserva reserva)
        {
            Habitacion habitacion = _habitacionDAL.ObtenerHabitacionPorId(reserva.HabitacionID);
            if (habitacion != null && habitacion.Categoria != null)
            {
                int dias = (reserva.FechaFin - reserva.FechaInicio).Days;
                reserva.MontoTotal = dias * habitacion.Categoria.Precio;
            }
            _reservaDAL.AgregarReserva(reserva);
        }

        public List<Reserva> ObtenerReservas()
        {
            return _reservaDAL.ObtenerReservas();
        }

        public Reserva ObtenerReservaPorId(int reservaID)
        {
            return _reservaDAL.ObtenerReservaPorId(reservaID);
        }

        public void ActualizarReserva(Reserva reserva)
        {
            _reservaDAL.ActualizarReserva(reserva);
        }

        public void EliminarReserva(int reservaID)
        {
            _reservaDAL.EliminarReserva(reservaID);
        }

    }
}
