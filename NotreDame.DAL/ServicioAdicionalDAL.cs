using MySql.Data.MySqlClient;
using NotreDame.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotreDame.DAL
{
    public class ServicioAdicionalDAL
    {
        public void AgregarServicioAdicional(ServicioAdicional servicio)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("INSERT INTO ServicioAdicional (CodigoServicio, Nombre, Precio) VALUES (@CodigoServicio, @Nombre, @Precio)", connection))
                {
                    command.Parameters.AddWithValue("@CodigoServicio", servicio.CodigoServicio);
                    command.Parameters.AddWithValue("@Nombre", servicio.Nombre);
                    command.Parameters.AddWithValue("@Precio", servicio.Precio);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<ServicioAdicional> ObtenerServiciosAdicionales()
        {
            List<ServicioAdicional> servicios = new List<ServicioAdicional>();
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("SELECT * FROM ServicioAdicional", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            servicios.Add(new ServicioAdicional
                            {
                                ServicioID = reader.GetInt32("ServicioID"),
                                CodigoServicio = reader.GetString("CodigoServicio"),
                                Nombre = reader.GetString("Nombre"),
                                Precio = reader.GetDecimal("Precio")
                            });
                        }
                    }
                }
            }
            return servicios;
        }

        public ServicioAdicional ObtenerServicioAdicionalPorId(int servicioID)
        {
            ServicioAdicional servicio = null;
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("SELECT * FROM ServicioAdicional WHERE ServicioID = @ServicioID", connection))
                {
                    command.Parameters.AddWithValue("@ServicioID", servicioID);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            servicio = new ServicioAdicional
                            {
                                ServicioID = reader.GetInt32("ServicioID"),
                                CodigoServicio = reader.GetString("CodigoServicio"),
                                Nombre = reader.GetString("Nombre"),
                                Precio = reader.GetDecimal("Precio")
                            };
                        }
                    }
                }
            }
            return servicio;
        }

        public void ActualizarServicioAdicional(ServicioAdicional servicio)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("UPDATE ServicioAdicional SET CodigoServicio = @CodigoServicio, Nombre = @Nombre, Precio = @Precio WHERE ServicioID = @ServicioID", connection))
                {
                    command.Parameters.AddWithValue("@CodigoServicio", servicio.CodigoServicio);
                    command.Parameters.AddWithValue("@Nombre", servicio.Nombre);
                    command.Parameters.AddWithValue("@Precio", servicio.Precio);
                    command.Parameters.AddWithValue("@ServicioID", servicio.ServicioID);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void EliminarServicioAdicional(int servicioID)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("DELETE FROM ServicioAdicional WHERE ServicioID = @ServicioID", connection))
                {
                    command.Parameters.AddWithValue("@ServicioID", servicioID);
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
