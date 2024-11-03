using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class HabitacionBLL
    {
        private HabitacionDAL habitacionDAL = new HabitacionDAL();

        public List<Habitacion> ObtenerHabitaciones()
        {
            return habitacionDAL.ObtenerHabitaciones();
        }

        public void AgregarHabitacion(Habitacion habitacion)
        {
            habitacionDAL.InsertarHabitacion(habitacion);
        }

        public void ActualizarHabitacion(Habitacion habitacion)
        {
            habitacionDAL.ActualizarHabitacion(habitacion);
        }

        public void EliminarHabitacion(int habitacionId)
        {
            habitacionDAL.EliminarHabitacion(habitacionId);
        }
    }
}
