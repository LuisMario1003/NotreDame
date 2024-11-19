using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotreDame.Entities
{
    public class Reserva
    {
        public int ReservaID { get; set; }
        public string CodigoReserva { get; set; }
        public int ClienteID { get; set; }
        public int HabitacionID { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal MontoTotal { get; set; }
        public Cliente Cliente { get; set; }
        public Habitacion Habitacion { get; set; }
        public List<ServicioAdicional> ServiciosAdicionales { get; set; } // Asegúrate de obtener esta lista en el DAL

    }
}
