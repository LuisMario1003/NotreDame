using NotreDame.DAL;
using NotreDame.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotreDame.BLL
{
    public class CategoriaBLL
    {
        private CategoriaDAL _categoriaDAL = new CategoriaDAL();

        public void RegistrarCategoria(Categoria categoria)
        {
            _categoriaDAL.AgregarCategoria(categoria);
        }

        public List<Categoria> ObtenerCategorias()
        {
            return _categoriaDAL.ObtenerCategorias();
        }

        public Categoria ObtenerCategoriaPorId(int categoriaID)
        {
            return _categoriaDAL.ObtenerCategoriaPorId(categoriaID);
        }

        public void ActualizarCategoria(Categoria categoria)
        {
            _categoriaDAL.ActualizarCategoria(categoria);
        }

        public void EliminarCategoria(int categoriaID)
        {
            _categoriaDAL.EliminarCategoria(categoriaID);
        }
    }
}
