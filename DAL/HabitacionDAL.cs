using Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class HabitacionDAL
    {
        private Conexion conexion = new Conexion();

        public List<Habitacion> ObtenerHabitaciones()
        {
            List<Habitacion> listaHabitaciones = new List<Habitacion>();
            string query = "SELECT * FROM habitaciones";

            using (MySqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Habitacion habitacion = new Habitacion
                    {
                        HabitacionId = reader.GetInt32("habitacion_id"),
                        Numero = reader.GetInt32("numero"),
                        Categoria = reader.GetString("categoria"),
                        Precio = reader.GetDecimal("precio"),
                        Estado = reader.GetString("estado")
                    };
                    listaHabitaciones.Add(habitacion);
                }
            }
            return listaHabitaciones;
        }

        public void InsertarHabitacion(Habitacion habitacion)
        {
            string query = "INSERT INTO habitaciones (numero, categoria, precio, estado) VALUES (@numero, @categoria, @precio, @estado)";

            using (MySqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@numero", habitacion.Numero);
                cmd.Parameters.AddWithValue("@categoria", habitacion.Categoria);
                cmd.Parameters.AddWithValue("@precio", habitacion.Precio);
                cmd.Parameters.AddWithValue("@estado", habitacion.Estado);
                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizarHabitacion(Habitacion habitacion)
        {
            string query = "UPDATE habitaciones SET numero = @numero, categoria = @categoria, precio = @precio, estado = @estado WHERE habitacion_id = @habitacionId";

            using (MySqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@numero", habitacion.Numero);
                cmd.Parameters.AddWithValue("@categoria", habitacion.Categoria);
                cmd.Parameters.AddWithValue("@precio", habitacion.Precio);
                cmd.Parameters.AddWithValue("@estado", habitacion.Estado);
                cmd.Parameters.AddWithValue("@habitacionId", habitacion.HabitacionId);
                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarHabitacion(int habitacionId)
        {
            string query = "DELETE FROM habitaciones WHERE habitacion_id = @habitacionId";

            using (MySqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@habitacionId", habitacionId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
