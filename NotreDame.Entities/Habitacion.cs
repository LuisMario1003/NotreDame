using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotreDame.Entities
{
    public class Habitacion
    {
        public int HabitacionID { get; set; }
        public string CodigoHabitacion { get; set; } // Campo actualizado
        public string Numero { get; set; } 
        public string Estado { get; set; } 
        public int CategoriaID { get; set; } 
        public Categoria Categoria { get; set; }
        public string CategoriaNombre => Categoria?.Nombre; // Propiedad adicional para el nombre de la categoría
    }
}
