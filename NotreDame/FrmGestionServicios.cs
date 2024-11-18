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
    public partial class FrmGestionServicios : Form
    {
        private ServicioAdicionalBLL _servicioAdicionalBLL = new ServicioAdicionalBLL();
        public FrmGestionServicios()
        {
            InitializeComponent();
            CargarServicios();
        }
        //private void btnGuardarServicio_Click(object sender, EventArgs e)
        //{
        //    ServicioAdicional servicio = new ServicioAdicional
        //    {
        //        CodigoServicio = txtCodigoServicio.Text,
        //        Nombre = txtNombre.Text,
        //        Precio = decimal.Parse(txtPrecio.Text)
        //    };
        //    _servicioAdicionalBLL.RegistrarServicioAdicional(servicio);
        //    MessageBox.Show("Servicio adicional registrado exitosamente.");
        //    CargarServicios();
        //}

        //private void btnEditarServicio_Click(object sender, EventArgs e)
        //{
        //    if (dgvServicios.SelectedRows.Count > 0)
        //    {
        //        int servicioID = Convert.ToInt32(dgvServicios.SelectedRows[0].Cells["ServicioID"].Value);
        //        ServicioAdicional servicio = new ServicioAdicional
        //        {
        //            ServicioID = servicioID,
        //            CodigoServicio = txtCodigoServicio.Text,
        //            Nombre = txtNombre.Text,
        //            Precio = decimal.Parse(txtPrecio.Text)
        //        };
        //        _servicioAdicionalBLL.ActualizarServicioAdicional(servicio);
        //        MessageBox.Show("Servicio adicional actualizado exitosamente.");
        //        CargarServicios();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Por favor, seleccione un servicio para editar.");
        //    }
        //}

        //private void btnEliminarServicio_Click(object sender, EventArgs e)
        //{
        //    if (dgvServicios.SelectedRows.Count > 0)
        //    {
        //        int servicioID = Convert.ToInt32(dgvServicios.SelectedRows[0].Cells["ServicioID"].Value);
        //        _servicioAdicionalBLL.EliminarServicioAdicional(servicioID);
        //        MessageBox.Show("Servicio adicional eliminado exitosamente.");
        //        CargarServicios();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Por favor, seleccione un servicio para eliminar.");
        //    }
        //}

        private void CargarServicios()
        {
            dgvServicios.DataSource = _servicioAdicionalBLL.ObtenerServiciosAdicionales();
        }

        private void dgvServicios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvServicios.SelectedRows.Count > 0)
            {
                txtCodigoServicio.Text = dgvServicios.SelectedRows[0].Cells["CodigoServicio"].Value.ToString();
                txtNombre.Text = dgvServicios.SelectedRows[0].Cells["Nombre"].Value.ToString();
                txtPrecio.Text = dgvServicios.SelectedRows[0].Cells["Precio"].Value.ToString();
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

        private void btnAgregarServicio_Click(object sender, EventArgs e)
        {
            ServicioAdicional servicio = new ServicioAdicional
            {
                CodigoServicio = txtCodigoServicio.Text,
                Nombre = txtNombre.Text,
                Precio = decimal.Parse(txtPrecio.Text)
            };
            _servicioAdicionalBLL.RegistrarServicioAdicional(servicio);
            MessageBox.Show("Servicio adicional registrado exitosamente.");
            CargarServicios();
        }

        private void btnEditarServicio_Click_1(object sender, EventArgs e)
        {
            if (dgvServicios.SelectedRows.Count > 0)
            {
                int servicioID = Convert.ToInt32(dgvServicios.SelectedRows[0].Cells["ServicioID"].Value);
                ServicioAdicional servicio = new ServicioAdicional
                {
                    ServicioID = servicioID,
                    CodigoServicio = txtCodigoServicio.Text,
                    Nombre = txtNombre.Text,
                    Precio = decimal.Parse(txtPrecio.Text)
                };
                _servicioAdicionalBLL.ActualizarServicioAdicional(servicio);
                MessageBox.Show("Servicio adicional actualizado exitosamente.");
                CargarServicios();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un servicio para editar.");
            }
        }

        private void btnEliminarServicio_Click_1(object sender, EventArgs e)
        {
            if (dgvServicios.SelectedRows.Count > 0)
            {
                int servicioID = Convert.ToInt32(dgvServicios.SelectedRows[0].Cells["ServicioID"].Value);
                _servicioAdicionalBLL.EliminarServicioAdicional(servicioID);
                MessageBox.Show("Servicio adicional eliminado exitosamente.");
                CargarServicios();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un servicio para eliminar.");
            }
        }

        private void lblSalir(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblHabitaciones_MouseEnter(object sender, EventArgs e)
        {
            lblHabitaciones.ForeColor = Color.Goldenrod;
        }

        private void lblHabitaciones_MouseLeave(object sender, EventArgs e)
        {
            lblHabitaciones.ForeColor = Color.Black;
        }

        private void lblCategorias_MouseEnter(object sender, EventArgs e)
        {
            lblCategorias.ForeColor = Color.Goldenrod;
        }

        private void lblCategorias_MouseLeave(object sender, EventArgs e)
        {
            lblCategorias.ForeColor = Color.Black;
        }

        private void lblClientes_MouseEnter(object sender, EventArgs e)
        {
            lblClientes.ForeColor = Color.Goldenrod;
        }

        private void lblClientes_MouseLeave(object sender, EventArgs e)
        {
            lblClientes.ForeColor = Color.Black;
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
            label2.ForeColor = Color.Black;
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Red;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Black;
        }
    }
}
