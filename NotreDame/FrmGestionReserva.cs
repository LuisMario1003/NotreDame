using NotreDame.BLL;
using NotreDame.Entities;
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
    public partial class FrmGestionReserva : Form
    {
        private ReservaBLL _reservaBLL = new ReservaBLL();
        private ClienteBLL _clienteBLL = new ClienteBLL();
        private HabitacionBLL _habitacionBLL = new HabitacionBLL();

        public FrmGestionReserva()
        {
            InitializeComponent();
            CargarHabitaciones();
            CargarReservas();
            CargarClientes();
        }
        //private void btnGuardarReserva_Click(object sender, EventArgs e)
        //{
        //    Reserva reserva = new Reserva
        //    {
        //        CodigoReserva = txtCodigoReserva.Text,
        //        ClienteID = (int)cbCliente.SelectedValue,
        //        HabitacionID = (int)cbHabitacion.SelectedValue,
        //        FechaInicio = dtpFechaInicio.Value,
        //        FechaFin = dtpFechaFin.Value
        //    };
        //    _reservaBLL.RegistrarReserva(reserva);
        //    MessageBox.Show("Reserva registrada exitosamente.");
        //    CargarReservas();
        //}

        //private void btnEditarReserva_Click(object sender, EventArgs e)
        //{
        //    if (dgvReservas.SelectedRows.Count > 0)
        //    {
        //        int reservaID = Convert.ToInt32(dgvReservas.SelectedRows[0].Cells["ReservaID"].Value);
        //        Reserva reserva = new Reserva
        //        {
        //            ReservaID = reservaID,
        //            CodigoReserva = txtCodigoReserva.Text,
        //            ClienteID = (int)cbCliente.SelectedValue,
        //            HabitacionID = (int)cbHabitacion.SelectedValue,
        //            FechaInicio = dtpFechaInicio.Value,
        //            FechaFin = dtpFechaFin.Value
        //        };
        //        _reservaBLL.ActualizarReserva(reserva);
        //        MessageBox.Show("Reserva actualizada exitosamente.");
        //        CargarReservas();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Por favor, seleccione una reserva para editar.");
        //    }
        //}

        //private void btnEliminarReserva_Click(object sender, EventArgs e)
        //{
        //    if (dgvReservas.SelectedRows.Count > 0)
        //    {
        //        int reservaID = Convert.ToInt32(dgvReservas.SelectedRows[0].Cells["ReservaID"].Value);
        //        _reservaBLL.EliminarReserva(reservaID);
        //        MessageBox.Show("Reserva eliminada exitosamente.");
        //        CargarReservas();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Por favor, seleccione una reserva para eliminar.");
        //    }
        //}

        private void CargarReservas()
        {
            dgvReservas.DataSource = _reservaBLL.ObtenerReservas();
        }

        private void CargarClientes()
        {
            cbCliente.DataSource = _clienteBLL.ObtenerClientes();
            cbCliente.DisplayMember = "Nombre";
            cbCliente.ValueMember = "ClienteID";
        }

        private void CargarHabitaciones()
        {
            cbHabitacion.DataSource = _habitacionBLL.ObtenerHabitaciones();
            cbHabitacion.DisplayMember = "CodigoHabitacion";
            cbHabitacion.ValueMember = "HabitacionID";
        }

        private void dgvReservas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvReservas.SelectedRows.Count > 0)
            {
                txtCodigoReserva.Text = dgvReservas.SelectedRows[0].Cells["CodigoReserva"].Value.ToString();
                cbCliente.SelectedValue = dgvReservas.SelectedRows[0].Cells["ClienteID"].Value;
                cbHabitacion.SelectedValue = dgvReservas.SelectedRows[0].Cells["HabitacionID"].Value;
                dtpFechaInicio.Value = Convert.ToDateTime(dgvReservas.SelectedRows[0].Cells["FechaInicio"].Value);
                dtpFechaFin.Value = Convert.ToDateTime(dgvReservas.SelectedRows[0].Cells["FechaFin"].Value);
            }
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

        private void lblFacturas_Click(object sender, EventArgs e)
        {
            FrmGestionFactura frmGestionFactura = new FrmGestionFactura();
            frmGestionFactura.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            FrmGestionServicios frmGestionServicios = new FrmGestionServicios();
            frmGestionServicios.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Principal principal = new Principal();
            principal.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAgregarReserva_Click(object sender, EventArgs e)
        {
            Reserva reserva = new Reserva
            {
                CodigoReserva = txtCodigoReserva.Text,
                ClienteID = (int)cbCliente.SelectedValue,
                HabitacionID = (int)cbHabitacion.SelectedValue,
                FechaInicio = dtpFechaInicio.Value,
                FechaFin = dtpFechaFin.Value
            };
            _reservaBLL.RegistrarReserva(reserva);
            MessageBox.Show("Reserva registrada exitosamente.");
            CargarReservas();
        }

        private void btnEditarReserva_Click_1(object sender, EventArgs e)
        {
            if (dgvReservas.SelectedRows.Count > 0)
            {
                int reservaID = Convert.ToInt32(dgvReservas.SelectedRows[0].Cells["ReservaID"].Value);
                Reserva reserva = new Reserva
                {
                    ReservaID = reservaID,
                    CodigoReserva = txtCodigoReserva.Text,
                    ClienteID = (int)cbCliente.SelectedValue,
                    HabitacionID = (int)cbHabitacion.SelectedValue,
                    FechaInicio = dtpFechaInicio.Value,
                    FechaFin = dtpFechaFin.Value
                };
                _reservaBLL.ActualizarReserva(reserva);
                MessageBox.Show("Reserva actualizada exitosamente.");
                CargarReservas();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una reserva para editar.");
            }
        }

        private void btnEliminarReserva_Click_1(object sender, EventArgs e)
        {
            if (dgvReservas.SelectedRows.Count > 0)
            {
                int reservaID = Convert.ToInt32(dgvReservas.SelectedRows[0].Cells["ReservaID"].Value);
                _reservaBLL.EliminarReserva(reservaID);
                MessageBox.Show("Reserva eliminada exitosamente.");
                CargarReservas();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una reserva para eliminar.");
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
            lblCategorias.ForeColor = Color.Goldenrod;
        }

        private void lblCategorias_MouseLeave(object sender, EventArgs e)
        {
            lblCategorias.ForeColor= Color.Black;
        }

        private void lblClientes_MouseEnter(object sender, EventArgs e)
        {
            lblClientes.ForeColor = Color.Goldenrod;
        }

        private void lblClientes_MouseLeave(object sender, EventArgs e)
        {
            lblClientes.ForeColor= Color.Black;
        }

        private void lblReservas_MouseEnter(object sender, EventArgs e)
        {
            lblReservas.ForeColor = Color.Goldenrod;
        }

        private void lblReservas_MouseLeave(object sender, EventArgs e)
        {
            lblReservas.ForeColor= Color.Black;
        }

        private void lblFacturas_MouseEnter(object sender, EventArgs e)
        {
            lblFacturas.ForeColor = Color.Goldenrod;
        }

        private void lblFacturas_MouseLeave(object sender, EventArgs e)
        {
            lblFacturas.ForeColor= Color.Black;
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Goldenrod;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor= Color.Black;
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Red;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.ForeColor= Color.Black;
        }
    }
}
