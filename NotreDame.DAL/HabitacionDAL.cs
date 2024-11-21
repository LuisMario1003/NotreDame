using MySql.Data.MySqlClient;
using NotreDame.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotreDame.DAL
{
    public class HabitacionDAL
    {
        public void AgregarHabitacion(Habitacion habitacion)
        {
            using (var connection = ConexionDB.GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("INSERT INTO Habitacion (CodigoHabitacion, Numero, Estado, CategoriaID) VALUES (@CodigoHabitacion, @Numero, @Estado, @CategoriaID)", connection))
                {
                    command.Parameters.AddWithValue("@CodigoHabitacion", habitacion.CodigoHabitacion);
                    command.Parameters.AddWithValue("@Numero", habitacion.Numero);
                    command.Parameters.AddWithValue("@Estado", habitacion.Estado);
                    command.Parameters.AddWithValue("@CategoriaID", habitacion.CategoriaID);
                    command.ExecuteNonQuery();
                }
            }
        }
        public DataTable ObtenerHabitaciones()
        {
            DataTable habitacionesTable = new DataTable();
            using (var connection = ConexionDB.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM Habitacion";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(habitacionesTable);
                    }
                }
            }
            return habitacionesTable;
        }
        public Habitacion ObtenerHabitacionPorId(int habitacionID)
        {
            Habitacion habitacion = null;
            using (var connection = ConexionDB.GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("SELECT * FROM Habitacion WHERE HabitacionID = @HabitacionID", connection))
                {
                    command.Parameters.AddWithValue("@HabitacionID", habitacionID);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            habitacion = new Habitacion
                            {
                                HabitacionID = reader.GetInt32("HabitacionID"),
                                CodigoHabitacion = reader.GetString("CodigoHabitacion"),
                                Numero = reader.GetString("Numero"),
                                Estado = reader.GetString("Estado"),
                                CategoriaID = reader.GetInt32("CategoriaID"),
                                Categoria = new CategoriaDAL().ObtenerCategoriaPorId(reader.GetInt32("CategoriaID"))
                            };
                        }
                    }
                }
            }
            return habitacion;
        }

        public void ActualizarHabitacion(Habitacion habitacion)
        {
            using (var connection = ConexionDB.GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("UPDATE Habitacion SET CodigoHabitacion = @CodigoHabitacion, Numero = @Numero, Estado = @Estado, CategoriaID = @CategoriaID WHERE HabitacionID = @HabitacionID", connection))
                {
                    command.Parameters.AddWithValue("@CodigoHabitacion", habitacion.CodigoHabitacion);
                    command.Parameters.AddWithValue("@Numero", habitacion.Numero);
                    command.Parameters.AddWithValue("@Estado", habitacion.Estado);
                    command.Parameters.AddWithValue("@CategoriaID", habitacion.CategoriaID);
                    command.Parameters.AddWithValue("@HabitacionID", habitacion.HabitacionID);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void EliminarHabitacion(int habitacionID)
        {
            using (var connection = ConexionDB.GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("DELETE FROM Habitacion WHERE HabitacionID = @HabitacionID", connection))
                {
                    command.Parameters.AddWithValue("@HabitacionID", habitacionID);
                    command.ExecuteNonQuery();
                }
            }
        }
        public void CambiarEstado(int habitacionID, string nuevoEstado)
        {
            using (var connection = ConexionDB.GetConnection())
            {
                connection.Open();
                string query = "UPDATE Habitacion SET Estado = @NuevoEstado WHERE HabitacionID = @HabitacionID";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NuevoEstado", nuevoEstado);
                    command.Parameters.AddWithValue("@HabitacionID", habitacionID);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
