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
    public partial class FrmGestionHabitaciones : Form
    {
        private HabitacionBLL _habitacionBLL = new HabitacionBLL();
        private CategoriaBLL _categoriaBLL = new CategoriaBLL();

        public FrmGestionHabitaciones()
        {
            InitializeComponent();
            CargarCategorias();
            CargarHabitaciones();
        }
        private void CargarHabitaciones()
        {
            DataTable habitacionesTable = _habitacionBLL.ObtenerHabitaciones(); // Suponiendo que ObtenerHabitaciones devuelva un DataTable
            dgvHabitaciones.DataSource = habitacionesTable;
        }
        private void CargarCategorias()
        {
            cbCategoria.DataSource = _categoriaBLL.ObtenerCategorias();
            cbCategoria.DisplayMember = "Nombre";
            cbCategoria.ValueMember = "CategoriaID";
        }

        private void dgvHabitaciones_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHabitaciones.SelectedRows.Count > 0)
            {
                txtCodigoHabitacion.Text = dgvHabitaciones.SelectedRows[0].Cells["CodigoHabitacion"].Value.ToString();
                txtNumero.Text = dgvHabitaciones.SelectedRows[0].Cells["Numero"].Value.ToString();
                cbEstado.SelectedItem = dgvHabitaciones.SelectedRows[0].Cells["Estado"].Value.ToString();
                cbCategoria.SelectedValue = dgvHabitaciones.SelectedRows[0].Cells["CategoriaID"].Value;
            }

        }
        private void LimpiarCampos()
        {
            txtCodigoHabitacion.Clear();
            txtNumero.Clear();
            cbEstado.SelectedIndex = -1;
            cbCategoria.SelectedIndex = -1;
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

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblHabitaciones_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregarHabitacion_Click(object sender, EventArgs e)
        {
            Habitacion habitacion = new Habitacion
            {
                CodigoHabitacion = txtCodigoHabitacion.Text,
                Numero = txtNumero.Text,
                Estado = cbEstado.SelectedItem.ToString(),
                CategoriaID = (int)cbCategoria.SelectedValue
            };
            _habitacionBLL.RegistrarHabitacion(habitacion);
            MessageBox.Show("Habitación registrada exitosamente.");
            LimpiarCampos();
            CargarHabitaciones();
        }

        private void btnEditarHabitacion_Click_1(object sender, EventArgs e)
        {
            if (dgvHabitaciones.SelectedRows.Count > 0)
            {
                int habitacionID = Convert.ToInt32(dgvHabitaciones.SelectedRows[0].Cells["HabitacionID"].Value);
                Habitacion habitacion = new Habitacion
                {
                    HabitacionID = habitacionID,
                    CodigoHabitacion = txtCodigoHabitacion.Text,
                    Numero = txtNumero.Text,
                    Estado = cbEstado.SelectedItem.ToString(),
                    CategoriaID = (int)cbCategoria.SelectedValue
                };
                _habitacionBLL.ActualizarHabitacion(habitacion);
                MessageBox.Show("Habitación actualizada exitosamente.");
                LimpiarCampos();
                CargarHabitaciones();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una habitación para editar.");
            }
        }

        private void btnEliminarHabitacion_Click_1(object sender, EventArgs e)
        {
            if (dgvHabitaciones.SelectedRows.Count > 0)
            {
                int habitacionID = Convert.ToInt32(dgvHabitaciones.SelectedRows[0].Cells["HabitacionID"].Value);
                _habitacionBLL.EliminarHabitacion(habitacionID);
                MessageBox.Show("Habitación eliminada exitosamente.");
                CargarHabitaciones();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una habitación para eliminar.");
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

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            label3.ForeColor= Color.Red;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor= Color.Black;
        }

        private void txtBuscarCodigo_TextChanged(object sender, EventArgs e)
        {
            FiltrarHabitacionesPorCodigo();
        }

        private void FiltrarHabitacionesPorCodigo()
        {
            string codigo = txtBuscarCodigo.Text.ToLower();

            (dgvHabitaciones.DataSource as DataTable).DefaultView.RowFilter = $"CodigoHabitacion LIKE '%{codigo}%'";
        }

    }
}
