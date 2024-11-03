using Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ClienteDAL
    {
        private Conexion conexion = new Conexion();

        public List<Cliente> ObtenerClientes()
        {
            List<Cliente> listaClientes = new List<Cliente>();
            string query = "SELECT * FROM clientes";

            using (MySqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Cliente cliente = new Cliente
                    {
                        ClienteId = reader.GetInt32("cliente_id"),
                        Nombre = reader.GetString("nombre"),
                        Apellido = reader.GetString("apellido"),
                        Telefono = reader.GetString("telefono")
                    };
                    listaClientes.Add(cliente);
                }
            }
            return listaClientes;
        }

        public void InsertarCliente(Cliente cliente)
        {
            string query = "INSERT INTO clientes (nombre, apellido, telefono) VALUES (@nombre, @apellido, @telefono)";

            using (MySqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nombre", cliente.Nombre);
                cmd.Parameters.AddWithValue("@apellido", cliente.Apellido);
                cmd.Parameters.AddWithValue("@telefono", cliente.Telefono);
                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizarCliente(Cliente cliente)
        {
            string query = "UPDATE clientes SET nombre = @nombre, apellido = @apellido, telefono = @telefono WHERE cliente_id = @clienteId";

            using (MySqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nombre", cliente.Nombre);
                cmd.Parameters.AddWithValue("@apellido", cliente.Apellido);
                cmd.Parameters.AddWithValue("@telefono", cliente.Telefono);
                cmd.Parameters.AddWithValue("@clienteId", cliente.ClienteId);
                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarCliente(int clienteId)
        {
            string query = "DELETE FROM clientes WHERE cliente_id = @clienteId";

            using (MySqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@clienteId", clienteId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
