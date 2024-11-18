using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotreDame
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void lblUsuarios_Click(object sender, EventArgs e)
        {

        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void lblHabitaciones_Click(object sender, EventArgs e)
        {
            FrmGestionHabitaciones frmGestionHabitaciones = new FrmGestionHabitaciones();
            frmGestionHabitaciones.Show();
            this.Hide();
        }

        private void lblCategorias_Click(object sender, EventArgs e)
        {
            FrmGestionCategorias frmGestionCategorias = new FrmGestionCategorias();
            frmGestionCategorias.Show();
            this.Hide();
        }

        private void lblClientes_Click(object sender, EventArgs e)
        {
            FrmGestionClientes frmGestionClientes = new FrmGestionClientes();
            frmGestionClientes.Show();
            this.Hide();
        }

        private void lblReservas_Click(object sender, EventArgs e)
        {
            FrmGestionReserva frmGestionReserva = new FrmGestionReserva();
            frmGestionReserva.Show();
            this.Hide();
        }

        private void lblFacturas_Click(object sender, EventArgs e)
        {
            FrmGestionFactura frmGestionFactura = new FrmGestionFactura();
            frmGestionFactura.ShowDialog();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblNombreUbicacion_Click(object sender, EventArgs e)
        {
            AbrirUbicacionEnGoogleMaps();
        }
        private void AbrirUbicacionEnGoogleMaps()
        {
            // URL de Google Maps con la ubicación del motel
            string url = "https://maps.app.goo.gl/G6NQTndkgo6rrdSL6"; // Cambia esta URL a la ubicación deseada

            try
            {
                Process.Start(url);
            }
            catch (Exception)
            {
                // Si ocurre una excepción, intentar abrir con el comando "start" de cmd
                try
                {
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo abrir el navegador: " + ex.Message);
                }
            }
        }

        private void lblHabitaciones_MouseEnter(object sender, EventArgs e)
        {
            lblHabitaciones.ForeColor = Color.Goldenrod;
        }

        private void lblHabitaciones_MouseLeave(object sender, EventArgs e)
        {
            lblHabitaciones.ForeColor= Color.Black;
        }

        private void lblCategorias_MouseEnter(object sender, EventArgs e)
        {
            lblCategorias.ForeColor= Color.Goldenrod;
        }

        private void lblCategorias_MouseLeave(object sender, EventArgs e)
        {
            lblCategorias.ForeColor = Color.Black;
        }

        private void lblClientes_MouseEnter(object sender, EventArgs e)
        {
            lblClientes.ForeColor= Color.Goldenrod;
        }

        private void lblClientes_MouseLeave(object sender, EventArgs e)
        {
            lblClientes.ForeColor = Color.Black;
        }

        private void lblReservas_MouseEnter(object sender, EventArgs e)
        {
            lblReservas.ForeColor= Color.Goldenrod;
        }

        private void lblReservas_MouseLeave(object sender, EventArgs e)
        {
            lblReservas.ForeColor = Color.Black;
        }

        private void lblFacturas_MouseEnter(object sender, EventArgs e)
        {
            lblFacturas.ForeColor= Color.Goldenrod;
        }

        private void lblFacturas_MouseLeave(object sender, EventArgs e)
        {
            lblFacturas.ForeColor = Color.Black;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            FrmGestionServicios frmGestionServicios = new FrmGestionServicios();
            frmGestionServicios.Show();
            this.Hide();
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            label2.ForeColor= Color.Goldenrod;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Black;
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.ForeColor= Color.Red;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Black;
        }
    }
}
