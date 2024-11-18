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
    public partial class FrmGestionCategorias : Form
    {
        private CategoriaBLL _categoriaBLL = new CategoriaBLL();
        public FrmGestionCategorias()
        {
            InitializeComponent();
            CargarCategorias();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        //private void btnAgregarCategoria_Click(object sender, EventArgs e)
        //{
        //    Categoria categoria = new Categoria
        //    {
        //        Nombre = txtNombre.Text,
        //        Precio = decimal.Parse(txtPrecio.Text)
        //    };
        //    _categoriaBLL.RegistrarCategoria(categoria);
        //    MessageBox.Show("Categoría registrada exitosamente.");
        //    CargarCategorias();
        //}

        //private void btnEditarCategoria_Click(object sender, EventArgs e)
        //{
        //    if (dgvCategorias.SelectedRows.Count > 0)
        //    {
        //        int categoriaID = Convert.ToInt32(dgvCategorias.SelectedRows[0].Cells["CategoriaID"].Value);
        //        Categoria categoria = new Categoria
        //        {
        //            CategoriaID = categoriaID,
        //            Nombre = txtNombre.Text,
        //            Precio = decimal.Parse(txtPrecio.Text)
        //        };
        //        _categoriaBLL.ActualizarCategoria(categoria);
        //        MessageBox.Show("Categoría actualizada exitosamente.");
        //        CargarCategorias();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Por favor, seleccione una categoría para editar.");
        //    }
        //}

        //private void btnEliminarCategoria_Click(object sender, EventArgs e)
        //{
        //    if (dgvCategorias.SelectedRows.Count > 0)
        //    {
        //        int categoriaID = Convert.ToInt32(dgvCategorias.SelectedRows[0].Cells["CategoriaID"].Value);
        //        _categoriaBLL.EliminarCategoria(categoriaID);
        //        MessageBox.Show("Categoría eliminada exitosamente.");
        //        CargarCategorias();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Por favor, seleccione una categoría para eliminar.");
        //    }
        //}

        private void CargarCategorias()
        {
            dgvCategorias.DataSource = _categoriaBLL.ObtenerCategorias();
        }

        private void dgvCategorias_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCategorias.SelectedRows.Count > 0)
            {
                txtNombre.Text = dgvCategorias.SelectedRows[0].Cells["Nombre"].Value.ToString();
                txtPrecio.Text = dgvCategorias.SelectedRows[0].Cells["Precio"].Value.ToString();
            }
        }

        private void lblHabitaciones_Click(object sender, EventArgs e)
        {
            FrmGestionHabitaciones frmGestionHabitaciones = new FrmGestionHabitaciones();
            frmGestionHabitaciones.Show();
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

        private void btnGuardarCategoria_Click(object sender, EventArgs e)
        {
            Categoria categoria = new Categoria
            {
                Nombre = txtNombre.Text,
                Precio = decimal.Parse(txtPrecio.Text)
            };
            _categoriaBLL.RegistrarCategoria(categoria);
            MessageBox.Show("Categoría registrada exitosamente.");
            CargarCategorias();
        }

        private void btnEditarCategoria_Click_1(object sender, EventArgs e)
        {
            if (dgvCategorias.SelectedRows.Count > 0)
            {
                int categoriaID = Convert.ToInt32(dgvCategorias.SelectedRows[0].Cells["CategoriaID"].Value);
                Categoria categoria = new Categoria
                {
                    CategoriaID = categoriaID,
                    Nombre = txtNombre.Text,
                    Precio = decimal.Parse(txtPrecio.Text)
                };
                _categoriaBLL.ActualizarCategoria(categoria);
                MessageBox.Show("Categoría actualizada exitosamente.");
                CargarCategorias();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una categoría para editar.");
            }
        }

        private void btnEliminarCategoria_Click_1(object sender, EventArgs e)
        {
            if (dgvCategorias.SelectedRows.Count > 0)
            {
                int categoriaID = Convert.ToInt32(dgvCategorias.SelectedRows[0].Cells["CategoriaID"].Value);
                _categoriaBLL.EliminarCategoria(categoriaID);
                MessageBox.Show("Categoría eliminada exitosamente.");
                CargarCategorias();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una categoría para eliminar.");
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
