using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotreDame
{
    public partial class FrmGestionHabitaciones : Form
    {
        private HabitacionBLL habitacionBLL = new HabitacionBLL();

        public FrmGestionHabitaciones()
        {
            InitializeComponent();
            CargarHabitaciones();
        }

        private void CargarHabitaciones()
        {
            dgvHabitaciones.DataSource = habitacionBLL.ObtenerHabitaciones();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Habitacion habitacion = new Habitacion
            {
                Numero = int.Parse(txtNumero.Text),
                Categoria = txtCategoria.Text,
                Precio = decimal.Parse(txtPrecio.Text),
                Estado = cmbEstado.SelectedItem.ToString()
            };
            habitacionBLL.AgregarHabitacion(habitacion);
            CargarHabitaciones();
            LimpiarCampos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvHabitaciones.SelectedRows.Count > 0)
            {
                Habitacion habitacion = new Habitacion
                {
                    HabitacionId = Convert.ToInt32(dgvHabitaciones.SelectedRows[0].Cells["HabitacionId"].Value),
                    Numero = int.Parse(txtNumero.Text),
                    Categoria = txtCategoria.Text,
                    Precio = decimal.Parse(txtPrecio.Text),
                    Estado = cmbEstado.SelectedItem.ToString()
                };
                habitacionBLL.ActualizarHabitacion(habitacion);
                CargarHabitaciones();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Seleccione una habitación para editar.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvHabitaciones.SelectedRows.Count > 0)
            {
                int habitacionId = Convert.ToInt32(dgvHabitaciones.SelectedRows[0].Cells["HabitacionId"].Value);
                habitacionBLL.EliminarHabitacion(habitacionId);
                CargarHabitaciones();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Seleccione una habitación para eliminar.");
            }
        }
        private void dgvHabitaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtNumero.Text = dgvHabitaciones.Rows[e.RowIndex].Cells["Numero"].Value.ToString();
                txtCategoria.Text = dgvHabitaciones.Rows[e.RowIndex].Cells["Categoria"].Value.ToString();
                txtPrecio.Text = dgvHabitaciones.Rows[e.RowIndex].Cells["Precio"].Value.ToString();
                cmbEstado.SelectedItem = dgvHabitaciones.Rows[e.RowIndex].Cells["Estado"].Value.ToString();
            }
        }

        private void LimpiarCampos()
        {
            txtNumero.Text = "";
            txtCategoria.Text = "";
            txtPrecio.Text = "";
            cmbEstado.SelectedIndex = -1;
        }

        private void lblClientes_Click(object sender, EventArgs e)
        {
            FrmGestionClientes frmGestionClientes = new FrmGestionClientes();
            frmGestionClientes.Show();
            this.Hide();
        }

        private void lblReservas_Click(object sender, EventArgs e)
        {
            FrmGestionReservas frmGestionReservas = new FrmGestionReservas();
            frmGestionReservas.Show();
            this.Hide();
        }

        private void lblFacturas_Click(object sender, EventArgs e)
        {
            FrmGestionFacturas frmGestionFactura = new FrmGestionFacturas();
            frmGestionFactura.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
