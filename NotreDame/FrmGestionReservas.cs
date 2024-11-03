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
    public partial class FrmGestionReservas : Form
    {
        private ReservaBLL reservaBLL = new ReservaBLL();

        public FrmGestionReservas()
        {
            InitializeComponent();
            CargarReservas();
        }

        private void CargarReservas()
        {
            dgvReservas.DataSource = reservaBLL.ObtenerReservas();
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Reserva reserva = new Reserva
            {
                ClienteId = int.Parse(txtClienteId.Text),
                HabitacionId = int.Parse(txtHabitacionId.Text),
                FechaInicio = dtpFechaInicio.Value,
                FechaFin = dtpFechaFin.Value,
                Estado = cmbEstado.SelectedItem.ToString()
            };
            reservaBLL.AgregarReserva(reserva);
            CargarReservas();
            LimpiarCampos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvReservas.SelectedRows.Count > 0)
            {
                Reserva reserva = new Reserva
                {
                    ReservaId = Convert.ToInt32(dgvReservas.SelectedRows[0].Cells["ReservaId"].Value),
                    ClienteId = int.Parse(txtClienteId.Text),
                    HabitacionId = int.Parse(txtHabitacionId.Text),
                    FechaInicio = dtpFechaInicio.Value,
                    FechaFin = dtpFechaFin.Value,
                    Estado = cmbEstado.SelectedItem.ToString()
                };
                reservaBLL.ActualizarReserva(reserva);
                CargarReservas();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Seleccione una reserva para editar.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvReservas.SelectedRows.Count > 0)
            {
                int reservaId = Convert.ToInt32(dgvReservas.SelectedRows[0].Cells["ReservaId"].Value);
                reservaBLL.EliminarReserva(reservaId);
                CargarReservas();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Seleccione una reserva para eliminar.");
            }
        }
        private void dgvReservas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtClienteId.Text = dgvReservas.Rows[e.RowIndex].Cells["ClienteId"].Value.ToString();
                txtHabitacionId.Text = dgvReservas.Rows[e.RowIndex].Cells["HabitacionId"].Value.ToString();
                dtpFechaInicio.Value = Convert.ToDateTime(dgvReservas.Rows[e.RowIndex].Cells["FechaInicio"].Value);
                dtpFechaFin.Value = Convert.ToDateTime(dgvReservas.Rows[e.RowIndex].Cells["FechaFin"].Value);
                cmbEstado.SelectedItem = dgvReservas.Rows[e.RowIndex].Cells["Estado"].Value.ToString();
            }
        }

        private void LimpiarCampos()
        {
            txtClienteId.Text = "";
            txtHabitacionId.Text = "";
            cmbEstado.SelectedIndex = -1;
        }

        private void lblClientes_Click(object sender, EventArgs e)
        {
            FrmGestionClientes frmGestionClientes = new FrmGestionClientes();
            frmGestionClientes.Show();
            this.Hide();
        }

        private void lblHabitaciones_Click(object sender, EventArgs e)
        {
            FrmGestionHabitaciones frmGestionHabitaciones = new FrmGestionHabitaciones();
            frmGestionHabitaciones.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void lblFacturas_Click(object sender, EventArgs e)
        {
            FrmGestionFacturas frmGestionFactura = new FrmGestionFacturas();
            frmGestionFactura.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
