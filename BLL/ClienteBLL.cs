using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ClienteBLL
    {
        private ClienteDAL clienteDAL = new ClienteDAL();

        public List<Cliente> ObtenerClientes()
        {
            return clienteDAL.ObtenerClientes();
        }

        public void AgregarCliente(Cliente cliente)
        {
            clienteDAL.InsertarCliente(cliente);
        }

        public void ActualizarCliente(Cliente cliente)
        {
            clienteDAL.ActualizarCliente(cliente);
        }

        public void EliminarCliente(int clienteId)
        {
            clienteDAL.EliminarCliente(clienteId);
        }
    }
}
