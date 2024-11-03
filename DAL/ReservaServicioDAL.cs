using Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ReservaServicioDAL
    {
        private Conexion conexion = new Conexion();

        public void AgregarServicioAReserva(int reservaId, int servicioId)
        {
            string query = "INSERT INTO reservas_servicios (reserva_id, servicio_id) VALUES (@reservaId, @servicioId)";
            using (MySqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@reservaId", reservaId);
                cmd.Parameters.AddWithValue("@servicioId", servicioId);
                cmd.ExecuteNonQuery();
            }
        }

        public List<ServicioAdicional> ObtenerServiciosDeReserva(int reservaId)
        {
            List<ServicioAdicional> listaServicios = new List<ServicioAdicional>();
            string query = "SELECT s.* FROM servicios_adicionales s INNER JOIN reservas_servicios rs ON s.servicio_id = rs.servicio_id WHERE rs.reserva_id = @reservaId";
            using (MySqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@reservaId", reservaId);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ServicioAdicional servicio = new ServicioAdicional
                    {
                        ServicioId = reader.GetInt32("servicio_id"),
                        Nombre = reader.GetString("nombre"),
                        Precio = reader.GetDecimal("precio")
                    };
                    listaServicios.Add(servicio);
                }
            }
            return listaServicios;
        }
    }
}
