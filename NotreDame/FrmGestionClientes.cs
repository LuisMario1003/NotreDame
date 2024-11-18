using NotreDame.Entities;
using NotreDame.BLL;
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
        private ClienteBLL _clienteBLL = new ClienteBLL();
        public FrmGestionClientes()
        {
            InitializeComponent();
            CargarClientes();

        }

        //private void btnEditarCliente_Click(object sender, EventArgs e)
        //{
        //    if (dgvClientes.SelectedRows.Count > 0)
        //    {
        //        int clienteID = Convert.ToInt32(dgvClientes.SelectedRows[0].Cells["ClienteID"].Value);
        //        Cliente cliente = new Cliente
        //        {
        //            ClienteID = clienteID,
        //            Nombre = txtNombre.Text,
        //            Telefono = txtTelefono.Text,
        //            Genero = cbGenero.SelectedItem.ToString(),
        //            Cedula = txtCedula.Text
        //        };
        //        _clienteBLL.ActualizarCliente(cliente);
        //        MessageBox.Show("Cliente actualizado exitosamente.");
        //        CargarClientes();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Por favor, seleccione un cliente para editar.");
        //    }
        //}

        //private void btnEliminarCliente_Click(object sender, EventArgs e)
        //{
        //    if (dgvClientes.SelectedRows.Count > 0)
        //    {
        //        int clienteID = Convert.ToInt32(dgvClientes.SelectedRows[0].Cells["ClienteID"].Value);
        //        _clienteBLL.EliminarCliente(clienteID);
        //        MessageBox.Show("Cliente eliminado exitosamente.");
        //        CargarClientes();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Por favor, seleccione un cliente para eliminar.");
        //    }
        //}

        private void CargarClientes()
        {
            dgvClientes.DataSource = _clienteBLL.ObtenerClientes();
        }

        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                txtNombre.Text = dgvClientes.SelectedRows[0].Cells["Nombre"].Value.ToString();
                txtTelefono.Text = dgvClientes.SelectedRows[0].Cells["Telefono"].Value.ToString();
                cbGenero.SelectedItem = dgvClientes.SelectedRows[0].Cells["Genero"].Value.ToString();
                txtCedula.Text = dgvClientes.SelectedRows[0].Cells["Cedula"].Value.ToString();
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

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardarCliente_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente 
            { 
                Nombre = txtNombre.Text, 
                Telefono = txtTelefono.Text, 
                Genero = cbGenero.SelectedItem.ToString(), 
                Cedula = txtCedula.Text 
            }; 
            _clienteBLL.RegistrarCliente(cliente); 
            MessageBox.Show("Cliente registrado exitosamente."); 
            CargarClientes();
        }

        private void btnEditarCliente_Click_1(object sender, EventArgs e)
        {
            if(dgvClientes.SelectedRows.Count > 0)
            {
                int clienteID = Convert.ToInt32(dgvClientes.SelectedRows[0].Cells["ClienteID"].Value);
                Cliente cliente = new Cliente
                {
                    ClienteID = clienteID,
                    Nombre = txtNombre.Text,
                    Telefono = txtTelefono.Text,
                    Genero = cbGenero.SelectedItem.ToString(),
                    Cedula = txtCedula.Text
                };
                _clienteBLL.ActualizarCliente(cliente);
                MessageBox.Show("Cliente actualizado exitosamente.");
                CargarClientes();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un cliente para editar.");
            }
        }

        private void btnEliminarCliente_Click_1(object sender, EventArgs e)
        {
            if(dgvClientes.SelectedRows.Count > 0)
            {
                int clienteID = Convert.ToInt32(dgvClientes.SelectedRows[0].Cells["ClienteID"].Value);
                _clienteBLL.EliminarCliente(clienteID);
                MessageBox.Show("Cliente eliminado exitosamente.");
                CargarClientes();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un cliente para eliminar.");
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

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            label2.ForeColor= Color.Goldenrod;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Black;
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            label3.ForeColor= Color.Red;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor= Color.Black;
        }
    }
}
