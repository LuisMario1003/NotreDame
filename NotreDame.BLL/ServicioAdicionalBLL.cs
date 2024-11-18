using NotreDame.DAL;
using NotreDame.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotreDame.BLL
{
    public class ServicioAdicionalBLL
    {
        private ServicioAdicionalDAL _servicioAdicionalDAL = new ServicioAdicionalDAL();

        public void RegistrarServicioAdicional(ServicioAdicional servicio)
        {
            _servicioAdicionalDAL.AgregarServicioAdicional(servicio);
        }

        public List<ServicioAdicional> ObtenerServiciosAdicionales()
        {
            return _servicioAdicionalDAL.ObtenerServiciosAdicionales();
        }

        public ServicioAdicional ObtenerServicioAdicionalPorId(int servicioID)
        {
            return _servicioAdicionalDAL.ObtenerServicioAdicionalPorId(servicioID);
        }

        public void ActualizarServicioAdicional(ServicioAdicional servicio)
        {
            _servicioAdicionalDAL.ActualizarServicioAdicional(servicio);
        }

        public void EliminarServicioAdicional(int servicioID)
        {
            _servicioAdicionalDAL.EliminarServicioAdicional(servicioID);
        }
    }
}
