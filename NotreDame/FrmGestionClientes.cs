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
    public partial class FrmGestionClientes : Form
    {
        private ClienteBLL clienteBLL = new ClienteBLL();

        public FrmGestionClientes()
        {
            InitializeComponent();
            CargarClientes();
        }

        private void CargarClientes()
        {
            dgvClientes.DataSource = clienteBLL.ObtenerClientes();
        }
        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Telefono = txtTelefono.Text
            };
            clienteBLL.AgregarCliente(cliente);
            CargarClientes();
            LimpiarCampos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                Cliente cliente = new Cliente
                {
                    ClienteId = Convert.ToInt32(dgvClientes.SelectedRows[0].Cells["ClienteId"].Value),
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Telefono = txtTelefono.Text
                };
                clienteBLL.ActualizarCliente(cliente);
                CargarClientes();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Seleccione un cliente para editar.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                int clienteId = Convert.ToInt32(dgvClientes.SelectedRows[0].Cells["ClienteId"].Value);
                clienteBLL.EliminarCliente(clienteId);
                CargarClientes();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Seleccione un cliente para eliminar.");
            }
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtNombre.Text = dgvClientes.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                txtApellido.Text = dgvClientes.Rows[e.RowIndex].Cells["Apellido"].Value.ToString();
                txtTelefono.Text = dgvClientes.Rows[e.RowIndex].Cells["Telefono"].Value.ToString();
            }
        }
        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtTelefono.Text = "";
        }

        private void lblReservas_Click(object sender, EventArgs e)
        {
            FrmGestionReservas frmGestionReservas = new FrmGestionReservas();
            frmGestionReservas.Show();
            this.Hide();
        }

        private void lblHabitaciones_Click(object sender, EventArgs e)
        {
            FrmGestionHabitaciones frmGestionHabitaciones = new FrmGestionHabitaciones();
            frmGestionHabitaciones.Show();
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
