using NotreDame.DAL;
using NotreDame.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotreDame.BLL
{
    public class HabitacionBLL
    {
        private HabitacionDAL _habitacionDAL = new HabitacionDAL();

        public void RegistrarHabitacion(Habitacion habitacion)
        {
            _habitacionDAL.AgregarHabitacion(habitacion);
        }

        public List<Habitacion> ObtenerHabitaciones()
        {
            return _habitacionDAL.ObtenerHabitaciones();
        }

        public Habitacion ObtenerHabitacionPorId(int habitacionID)
        {
            return _habitacionDAL.ObtenerHabitacionPorId(habitacionID);
        }

        public void ActualizarHabitacion(Habitacion habitacion)
        {
            _habitacionDAL.ActualizarHabitacion(habitacion);
        }

        public void EliminarHabitacion(int habitacionID)
        {
            _habitacionDAL.EliminarHabitacion(habitacionID);
        }

    }
}
