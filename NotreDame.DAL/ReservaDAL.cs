using MySql.Data.MySqlClient;
using NotreDame.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotreDame.DAL
{
    public class ReservaDAL
    {
        public void AgregarReserva(Reserva reserva)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("INSERT INTO Reserva (CodigoReserva, ClienteID, HabitacionID, FechaInicio, FechaFin, MontoTotal) VALUES (@CodigoReserva, @ClienteID, @HabitacionID, @FechaInicio, @FechaFin, @MontoTotal)", connection))
                {
                    command.Parameters.AddWithValue("@CodigoReserva", reserva.CodigoReserva);
                    command.Parameters.AddWithValue("@ClienteID", reserva.ClienteID);
                    command.Parameters.AddWithValue("@HabitacionID", reserva.HabitacionID);
                    command.Parameters.AddWithValue("@FechaInicio", reserva.FechaInicio);
                    command.Parameters.AddWithValue("@FechaFin", reserva.FechaFin);
                    command.Parameters.AddWithValue("@MontoTotal", reserva.MontoTotal);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Reserva> ObtenerReservas()
        {
            List<Reserva> reservas = new List<Reserva>();
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("SELECT * FROM Reserva", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            reservas.Add(new Reserva
                            {
                                ReservaID = reader.GetInt32("ReservaID"),
                                CodigoReserva = reader.GetString("CodigoReserva"),
                                ClienteID = reader.GetInt32("ClienteID"),
                                HabitacionID = reader.GetInt32("HabitacionID"),
                                FechaInicio = reader.GetDateTime("FechaInicio"),
                                FechaFin = reader.GetDateTime("FechaFin"),
                                MontoTotal = reader.GetDecimal("MontoTotal")
                            });
                        }
                    }
                }
            }
            return reservas;
        }

        public Reserva ObtenerReservaPorId(int reservaID)
        {
            Reserva reserva = null;
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("SELECT * FROM Reserva WHERE ReservaID = @ReservaID", connection))
                {
                    command.Parameters.AddWithValue("@ReservaID", reservaID);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            reserva = new Reserva
                            {
                                ReservaID = reader.GetInt32("ReservaID"),
                                CodigoReserva = reader.GetString("CodigoReserva"),
                                ClienteID = reader.GetInt32("ClienteID"),
                                HabitacionID = reader.GetInt32("HabitacionID"),
                                FechaInicio = reader.GetDateTime("FechaInicio"),
                                FechaFin = reader.GetDateTime("FechaFin"),
                                MontoTotal = reader.GetDecimal("MontoTotal")
                            };
                        }
                    }
                }
            }
            return reserva;
        }

        public void ActualizarReserva(Reserva reserva)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("UPDATE Reserva SET CodigoReserva = @CodigoReserva, ClienteID = @ClienteID, HabitacionID = @HabitacionID, FechaInicio = @FechaInicio, FechaFin = @FechaFin, MontoTotal = @MontoTotal WHERE ReservaID = @ReservaID", connection))
                {
                    command.Parameters.AddWithValue("@CodigoReserva", reserva.CodigoReserva);
                    command.Parameters.AddWithValue("@ClienteID", reserva.ClienteID);
                    command.Parameters.AddWithValue("@HabitacionID", reserva.HabitacionID);
                    command.Parameters.AddWithValue("@FechaInicio", reserva.FechaInicio);
                    command.Parameters.AddWithValue("@FechaFin", reserva.FechaFin);
                    command.Parameters.AddWithValue("@MontoTotal", reserva.MontoTotal);
                    command.Parameters.AddWithValue("@ReservaID", reserva.ReservaID);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void EliminarReserva(int reservaID)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("DELETE FROM Reserva WHERE ReservaID = @ReservaID", connection))
                {
                    command.Parameters.AddWithValue("@ReservaID", reservaID);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
