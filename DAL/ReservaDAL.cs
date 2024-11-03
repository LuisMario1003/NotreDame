using Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ReservaDAL
    {
        private Conexion conexion = new Conexion();

        public List<Reserva> ObtenerReservas()
        {
            List<Reserva> listaReservas = new List<Reserva>();
            string query = "SELECT * FROM reservas";

            using (MySqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Reserva reserva = new Reserva
                    {
                        ReservaId = reader.GetInt32("reserva_id"),
                        ClienteId = reader.GetInt32("cliente_id"),
                        HabitacionId = reader.GetInt32("habitacion_id"),
                        FechaInicio = reader.GetDateTime("fecha_inicio"),
                        FechaFin = reader.GetDateTime("fecha_fin"),
                        Estado = reader.GetString("estado")
                    };
                    listaReservas.Add(reserva);
                }
            }
            return listaReservas;
        }

        public void InsertarReserva(Reserva reserva)
        {
            string query = "INSERT INTO reservas (cliente_id, habitacion_id, fecha_inicio, fecha_fin, estado) VALUES (@clienteId, @habitacionId, @fechaInicio, @fechaFin, @estado)";

            using (MySqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@clienteId", reserva.ClienteId);
                cmd.Parameters.AddWithValue("@habitacionId", reserva.HabitacionId);
                cmd.Parameters.AddWithValue("@fechaInicio", reserva.FechaInicio);
                cmd.Parameters.AddWithValue("@fechaFin", reserva.FechaFin);
                cmd.Parameters.AddWithValue("@estado", reserva.Estado);
                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizarReserva(Reserva reserva)
        {
            string query = "UPDATE reservas SET cliente_id = @clienteId, habitacion_id = @habitacionId, fecha_inicio = @fechaInicio, fecha_fin = @fechaFin, estado = @estado WHERE reserva_id = @reservaId";

            using (MySqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@clienteId", reserva.ClienteId);
                cmd.Parameters.AddWithValue("@habitacionId", reserva.HabitacionId);
                cmd.Parameters.AddWithValue("@fechaInicio", reserva.FechaInicio);
                cmd.Parameters.AddWithValue("@fechaFin", reserva.FechaFin);
                cmd.Parameters.AddWithValue("@estado", reserva.Estado);
                cmd.Parameters.AddWithValue("@reservaId", reserva.ReservaId);
                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarReserva(int reservaId)
        {
            string query = "DELETE FROM reservas WHERE reserva_id = @reservaId";

            using (MySqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@reservaId", reservaId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
