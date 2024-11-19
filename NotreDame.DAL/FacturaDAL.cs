using MySql.Data.MySqlClient;
using NotreDame.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotreDame.DAL
{
    public class FacturaDAL
    {
        public void AgregarFactura(Factura factura, List<int> serviciosSeleccionados)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("INSERT INTO Factura (CodigoFactura, ReservaID, Fecha, MontoTotal) VALUES (@CodigoFactura, @ReservaID, @Fecha, @MontoTotal)", connection))
                {
                    command.Parameters.AddWithValue("@CodigoFactura", factura.CodigoFactura);
                    command.Parameters.AddWithValue("@ReservaID", factura.ReservaID);
                    command.Parameters.AddWithValue("@Fecha", factura.Fecha);
                    command.Parameters.AddWithValue("@MontoTotal", factura.MontoTotal);
                    command.ExecuteNonQuery();

                    factura.FacturaID = (int)command.LastInsertedId;
                }

                foreach (int servicioID in serviciosSeleccionados)
                {
                    using (var command = new MySqlCommand("INSERT INTO FacturaServicioAdicional (FacturaID, ServicioID) VALUES (@FacturaID, @ServicioID)", connection))
                    {
                        command.Parameters.AddWithValue("@FacturaID", factura.FacturaID);
                        command.Parameters.AddWithValue("@ServicioID", servicioID);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public List<Factura> ObtenerFacturas()
        {
            List<Factura> facturas = new List<Factura>();
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("SELECT * FROM Factura", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            facturas.Add(new Factura
                            {
                                FacturaID = reader.GetInt32("FacturaID"),
                                CodigoFactura = reader.GetString("CodigoFactura"),
                                ReservaID = reader.GetInt32("ReservaID"),
                                Fecha = reader.GetDateTime("Fecha"),
                                MontoTotal = reader.GetDecimal("MontoTotal")
                            });
                        }
                    }
                }
            }
            return facturas;
        }

        //public Factura ObtenerFacturaPorId(int facturaID)
        //{
        //    Factura factura = null;
        //    using (var connection = DatabaseHelper.GetConnection())
        //    {
        //        connection.Open();
        //        using (var command = new MySqlCommand("SELECT * FROM Factura WHERE FacturaID = @FacturaID", connection))
        //        {
        //            command.Parameters.AddWithValue("@FacturaID", facturaID);
        //            using (var reader = command.ExecuteReader())
        //            {
        //                if (reader.Read())
        //                {
        //                    factura = new Factura
        //                    {
        //                        FacturaID = reader.GetInt32("FacturaID"),
        //                        CodigoFactura = reader.GetString("CodigoFactura"),
        //                        ReservaID = reader.GetInt32("ReservaID"),
        //                        Fecha = reader.GetDateTime("Fecha"),
        //                        MontoTotal = reader.GetDecimal("MontoTotal")
        //                    };
        //                }
        //            }
        //        }
        //    }
        //    return factura;
        //}

        public Factura ObtenerFacturaPorId(int facturaID)
        {
            Factura factura = null;
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string query = @"
            SELECT f.FacturaID, f.CodigoFactura, f.ReservaID, f.Fecha, f.MontoTotal,
                   r.ClienteID, r.HabitacionID,
                   c.Nombre AS ClienteNombre, c.Telefono AS ClienteTelefono, c.Genero AS ClienteGenero, c.Cedula AS ClienteCedula,
                   h.CodigoHabitacion, h.Numero, h.Estado, cat.Nombre AS CategoriaNombre
            FROM Factura f
            INNER JOIN Reserva r ON f.ReservaID = r.ReservaID
            INNER JOIN Cliente c ON r.ClienteID = c.ClienteID
            INNER JOIN Habitacion h ON r.HabitacionID = h.HabitacionID
            INNER JOIN Categoria cat ON h.CategoriaID = cat.CategoriaID
            WHERE f.FacturaID = @FacturaID";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FacturaID", facturaID);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            factura = new Factura
                            {
                                FacturaID = reader.GetInt32("FacturaID"),
                                CodigoFactura = reader.GetString("CodigoFactura"),
                                ReservaID = reader.GetInt32("ReservaID"),
                                Fecha = reader.GetDateTime("Fecha"),
                                MontoTotal = reader.GetDecimal("MontoTotal"),
                                Cliente = new Cliente
                                {
                                    ClienteID = reader.GetInt32("ClienteID"),
                                    Nombre = reader.GetString("ClienteNombre"),
                                    Telefono = reader.GetString("ClienteTelefono"),
                                    Genero = reader.GetString("ClienteGenero"),
                                    Cedula = reader.GetString("ClienteCedula")
                                },
                                Habitacion = new Habitacion
                                {
                                    CodigoHabitacion = reader.GetString("CodigoHabitacion"),
                                    Numero = reader.GetString("Numero"),
                                    Estado = reader.GetString("Estado"),
                                    Categoria = new Categoria { Nombre = reader.GetString("CategoriaNombre") }
                                }
                            };
                        }
                    }
                }
            }
            return factura;
        }


        public void ActualizarFactura(Factura factura, List<int> serviciosSeleccionados)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("UPDATE Factura SET CodigoFactura = @CodigoFactura, ReservaID = @ReservaID, Fecha = @Fecha, MontoTotal = @MontoTotal WHERE FacturaID = @FacturaID", connection))
                {
                    command.Parameters.AddWithValue("@CodigoFactura", factura.CodigoFactura);
                    command.Parameters.AddWithValue("@ReservaID", factura.ReservaID);
                    command.Parameters.AddWithValue("@Fecha", factura.Fecha);
                    command.Parameters.AddWithValue("@MontoTotal", factura.MontoTotal);
                    command.Parameters.AddWithValue("@FacturaID", factura.FacturaID);
                    command.ExecuteNonQuery();
                }

                using (var command = new MySqlCommand("DELETE FROM FacturaServicioAdicional WHERE FacturaID = @FacturaID", connection))
                {
                    command.Parameters.AddWithValue("@FacturaID", factura.FacturaID);
                    command.ExecuteNonQuery();
                }

                foreach (int servicioID in serviciosSeleccionados)
                {
                    using (var command = new MySqlCommand("INSERT INTO FacturaServicioAdicional (FacturaID, ServicioID) VALUES (@FacturaID, @ServicioID)", connection))
                    {
                        command.Parameters.AddWithValue("@FacturaID", factura.FacturaID);
                        command.Parameters.AddWithValue("@ServicioID", servicioID);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public void EliminarFactura(int facturaID)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("DELETE FROM FacturaServicioAdicional WHERE FacturaID = @FacturaID", connection))
                {
                    command.Parameters.AddWithValue("@FacturaID", facturaID);
                    command.ExecuteNonQuery();
                }
                using (var command = new MySqlCommand("DELETE FROM Factura WHERE FacturaID = @FacturaID", connection))
                {
                    command.Parameters.AddWithValue("@FacturaID", facturaID);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<ServicioAdicional> ObtenerServiciosAdicionalesPorFacturaId(int facturaID)
        {
            List<ServicioAdicional> servicios = new List<ServicioAdicional>();
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string query = @"
            SELECT sa.ServicioID, sa.Nombre, sa.Precio
            FROM FacturaServicioAdicional fsa
            INNER JOIN ServicioAdicional sa ON fsa.ServicioID = sa.ServicioID
            WHERE fsa.FacturaID = @FacturaID";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FacturaID", facturaID);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            servicios.Add(new ServicioAdicional
                            {
                                ServicioID = reader.GetInt32("ServicioID"),
                                Nombre = reader.GetString("Nombre"),
                                Precio = reader.GetDecimal("Precio")
                            });
                        }
                    }
                }
            }
            return servicios;
        }


    }
}
