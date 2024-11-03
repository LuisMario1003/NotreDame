using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Habitacion
    {
        public int HabitacionId { get; set; }
        public int Numero { get; set; }
        public string Categoria { get; set; }
        public decimal Precio { get; set; }
        public string Estado { get; set; }  // Disponible o Ocupada
    }
}
