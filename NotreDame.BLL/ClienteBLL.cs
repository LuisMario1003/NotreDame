using NotreDame.DAL;
using NotreDame.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotreDame.BLL
{
    public class ClienteBLL
    {
        private ClienteDAL _clienteDAL = new ClienteDAL();

        public void RegistrarCliente(Cliente cliente)
        {
            _clienteDAL.AgregarCliente(cliente);
        }

        public List<Cliente> ObtenerClientes()
        {
            return _clienteDAL.ObtenerClientes();
        }

        public Cliente ObtenerClientePorId(int clienteID)
        {
            return _clienteDAL.ObtenerClientes().FirstOrDefault(c => c.ClienteID == clienteID);
        }

        public void ActualizarCliente(Cliente cliente)
        {
            _clienteDAL.ActualizarCliente(cliente);
        }

        public void EliminarCliente(int clienteID)
        {
            _clienteDAL.EliminarCliente(clienteID);
        }

    }
}
