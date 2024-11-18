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

        public Factura ObtenerFacturaPorId(int facturaID)
        {
            Factura factura = null;
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("SELECT * FROM Factura WHERE FacturaID = @FacturaID", connection))
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
                                MontoTotal = reader.GetDecimal("MontoTotal")
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

    }
}
