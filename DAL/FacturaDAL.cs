using Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FacturaDAL
    {
        private Conexion conexion = new Conexion();

        public List<Factura> ObtenerFacturas()
        {
            List<Factura> listaFacturas = new List<Factura>();
            string query = "SELECT * FROM facturacion";

            using (MySqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Factura factura = new Factura
                    {
                        FacturaId = reader.GetInt32("factura_id"),
                        ReservaId = reader.GetInt32("reserva_id"),
                        Total = reader.GetDecimal("total"),
                        FechaEmision = reader.GetDateTime("fecha_emision")
                    };
                    listaFacturas.Add(factura);
                }
            }
            return listaFacturas;
        }

        public void InsertarFactura(Factura factura)
        {
            string query = "INSERT INTO facturacion (reserva_id, total, fecha_emision) VALUES (@reservaId, @total, @fechaEmision)";

            using (MySqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@reservaId", factura.ReservaId);
                cmd.Parameters.AddWithValue("@total", factura.Total);
                cmd.Parameters.AddWithValue("@fechaEmision", factura.FechaEmision);
                cmd.ExecuteNonQuery();
            }
        }
        public decimal CalcularTotalReserva(int reservaId)
        {
            decimal total = 0;
            string query = @"SELECT SUM(h.precio) AS total_habitacion, COALESCE(SUM(sa.precio), 0) AS total_servicios
                     FROM reservas r
                     INNER JOIN habitaciones h ON r.habitacion_id = h.habitacion_id
                     LEFT JOIN reservas_servicios rs ON r.reserva_id = rs.reserva_id
                     LEFT JOIN servicios_adicionales sa ON rs.servicio_id = sa.servicio_id
                     WHERE r.reserva_id = @reservaId";
            using (MySqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@reservaId", reservaId);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    total = reader.GetDecimal("total_habitacion") + reader.GetDecimal("total_servicios");
                }
            }
            return total;
        }
    }
}
