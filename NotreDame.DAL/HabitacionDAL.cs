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
            using (var connection = DatabaseHelper.GetConnection())
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
            using (var connection = DatabaseHelper.GetConnection())
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

        //public List<Habitacion> ObtenerHabitaciones()
        //{
        //    List<Habitacion> habitaciones = new List<Habitacion>();
        //    using (var connection = DatabaseHelper.GetConnection())
        //    {
        //        connection.Open();
        //        string query = @"
        //    SELECT h.HabitacionID, h.CodigoHabitacion, h.Numero, h.Estado, h.CategoriaID, c.Nombre AS CategoriaNombre 
        //    FROM Habitacion h
        //    INNER JOIN Categoria c ON h.CategoriaID = c.CategoriaID";
        //        using (var command = new MySqlCommand(query, connection))
        //        {
        //            using (var reader = command.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    habitaciones.Add(new Habitacion
        //                    {
        //                        HabitacionID = reader.GetInt32("HabitacionID"),
        //                        CodigoHabitacion = reader.GetString("CodigoHabitacion"),
        //                        Numero = reader.GetString("Numero"),
        //                        Estado = reader.GetString("Estado"),
        //                        CategoriaID = reader.GetInt32("CategoriaID"),
        //                        Categoria = new Categoria { Nombre = reader.GetString("CategoriaNombre") }
        //                    });
        //                }
        //            }
        //        }
        //    }
        //    return habitaciones;

        //}

        public Habitacion ObtenerHabitacionPorId(int habitacionID)
        {
            Habitacion habitacion = null;
            using (var connection = DatabaseHelper.GetConnection())
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
            using (var connection = DatabaseHelper.GetConnection())
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
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("DELETE FROM Habitacion WHERE HabitacionID = @HabitacionID", connection))
                {
                    command.Parameters.AddWithValue("@HabitacionID", habitacionID);
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
