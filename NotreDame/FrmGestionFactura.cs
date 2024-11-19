using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
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
    public partial class FrmGestionFactura : Form
    {
        private FacturaBLL _facturaBLL = new FacturaBLL();
        private ReservaBLL _reservaBLL = new ReservaBLL();
        private ServicioAdicionalBLL _servicioAdicionalBLL = new ServicioAdicionalBLL();

        public FrmGestionFactura()
        {
            InitializeComponent();
            CargarReservas();
            CargarServiciosAdicionales();
            CargarFacturas();
        }
        //private void btnGuardarFactura_Click(object sender, EventArgs e)
        //{
        //    List<int> serviciosSeleccionados = new List<int>();
        //    foreach (var item in clbServicios.CheckedItems)
        //    {
        //        ServicioAdicional servicio = (ServicioAdicional)item;
        //        serviciosSeleccionados.Add(servicio.ServicioID);
        //    }

        //    Factura factura = new Factura
        //    {
        //        CodigoFactura = txtCodigoFactura.Text,
        //        ReservaID = (int)cbReserva.SelectedValue,
        //        Fecha = DateTime.Now
        //    };

        //    _facturaBLL.RegistrarFactura(factura, serviciosSeleccionados);
        //    MessageBox.Show("Factura registrada exitosamente.");
        //    CargarFacturas();
        //}

        //private void btnEditarFactura_Click(object sender, EventArgs e)
        //{
        //    if (dgvFacturas.SelectedRows.Count > 0)
        //    {
        //        List<int> serviciosSeleccionados = new List<int>();
        //        foreach (var item in clbServicios.CheckedItems)
        //        {
        //            ServicioAdicional servicio = (ServicioAdicional)item;
        //            serviciosSeleccionados.Add(servicio.ServicioID);
        //        }

        //        int facturaID = Convert.ToInt32(dgvFacturas.SelectedRows[0].Cells["FacturaID"].Value);
        //        Factura factura = new Factura
        //        {
        //            FacturaID = facturaID,
        //            CodigoFactura = txtCodigoFactura.Text,
        //            ReservaID = (int)cbReserva.SelectedValue,
        //            Fecha = DateTime.Now
        //        };

        //        _facturaBLL.ActualizarFactura(factura, serviciosSeleccionados);
        //        MessageBox.Show("Factura actualizada exitosamente.");
        //        CargarFacturas();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Por favor, seleccione una factura para editar.");
        //    }
        //}

        //private void btnEliminarFactura_Click(object sender, EventArgs e)
        //{
        //    if (dgvFacturas.SelectedRows.Count > 0)
        //    {
        //        int facturaID = Convert.ToInt32(dgvFacturas.SelectedRows[0].Cells["FacturaID"].Value);
        //        _facturaBLL.EliminarFactura(facturaID);
        //        MessageBox.Show("Factura eliminada exitosamente.");
        //        CargarFacturas();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Por favor, seleccione una factura para eliminar.");
        //    }
        //}

        private void CargarFacturas()
        {
            dgvFacturas.DataSource = _facturaBLL.ObtenerFacturas();
            dgvFacturas.Columns["FacturaID"].Visible = false; // Oculta el ID de la factura
            dgvFacturas.Columns["CodigoFactura"].HeaderText = "Código de Factura";
            dgvFacturas.Columns["ReservaID"].HeaderText = "ID de Reserva";
            dgvFacturas.Columns["MontoTotal"].HeaderText = "Monto Total";
        }

        private void CargarReservas()
        {
            cbReserva.DataSource = _reservaBLL.ObtenerReservas();
            cbReserva.DisplayMember = "CodigoReserva";
            cbReserva.ValueMember = "ReservaID";
        }

        private void CargarServiciosAdicionales()
        {
            clbServicios.DataSource = _servicioAdicionalBLL.ObtenerServiciosAdicionales();
            clbServicios.DisplayMember = "Nombre";
            clbServicios.ValueMember = "ServicioID";
        }

        private void dgvFacturas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvFacturas.SelectedRows.Count > 0)
            {
                txtCodigoFactura.Text = dgvFacturas.SelectedRows[0].Cells["CodigoFactura"].Value.ToString();
                cbReserva.SelectedValue = dgvFacturas.SelectedRows[0].Cells["ReservaID"].Value;
                // Agrega lógica adicional si es necesaria
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

        private void btnAgregarFactura_Click(object sender, EventArgs e)
        {

            List<int> serviciosSeleccionados = new List<int>();
            foreach (var item in clbServicios.CheckedItems)
            {
                ServicioAdicional servicio = (ServicioAdicional)item;
                serviciosSeleccionados.Add(servicio.ServicioID);
            }

            Factura factura = new Factura
            {
                CodigoFactura = txtCodigoFactura.Text,
                ReservaID = (int)cbReserva.SelectedValue,
                Fecha = DateTime.Now
            };

            _facturaBLL.RegistrarFactura(factura, serviciosSeleccionados);
            MessageBox.Show("Factura registrada exitosamente.");
            CargarFacturas();
        }

        private void btnEditarFactura_Click_1(object sender, EventArgs e)
        {
            if (dgvFacturas.SelectedRows.Count > 0)
            {
                List<int> serviciosSeleccionados = new List<int>();
                foreach (var item in clbServicios.CheckedItems)
                {
                    ServicioAdicional servicio = (ServicioAdicional)item;
                    serviciosSeleccionados.Add(servicio.ServicioID);
                }

                int facturaID = Convert.ToInt32(dgvFacturas.SelectedRows[0].Cells["FacturaID"].Value);
                Factura factura = new Factura
                {
                    FacturaID = facturaID,
                    CodigoFactura = txtCodigoFactura.Text,
                    ReservaID = (int)cbReserva.SelectedValue,
                    Fecha = DateTime.Now
                };

                _facturaBLL.ActualizarFactura(factura, serviciosSeleccionados);
                MessageBox.Show("Factura actualizada exitosamente.");
                CargarFacturas();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una factura para editar.");
            }
        }

        private void btnEliminarFactura_Click_1(object sender, EventArgs e)
        {
            if (dgvFacturas.SelectedRows.Count > 0)
            {
                int facturaID = Convert.ToInt32(dgvFacturas.SelectedRows[0].Cells["FacturaID"].Value);
                _facturaBLL.EliminarFactura(facturaID);
                MessageBox.Show("Factura eliminada exitosamente.");
                CargarFacturas();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una factura para eliminar.");
            }
        }
        private void LimpiarCampos()
        {
            txtCodigoFactura.Clear();
            cbReserva.SelectedIndex = -1;
            foreach (int i in clbServicios.CheckedIndices)
            {
                clbServicios.SetItemCheckState(i, CheckState.Unchecked);
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
        // Método para exportar la factura seleccionada a PDF
        //private void ExportarFacturaSeleccionadaAPdf(string archivo)
        //{
        //    if (dgvFacturas.SelectedRows.Count == 0)
        //    {
        //        MessageBox.Show("Por favor, seleccione una factura para exportar.");
        //        return;
        //    }

        //    int facturaID = Convert.ToInt32(dgvFacturas.SelectedRows[0].Cells["FacturaID"].Value);
        //    Factura factura = _facturaBLL.ObtenerFacturaPorId(facturaID);

        //    using (var writer = new PdfWriter(archivo))
        //    {
        //        using (var pdf = new PdfDocument(writer))
        //        {
        //            var document = new Document(pdf);

        //            // Definir estilos de fuente
        //            var bold = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
        //            var normal = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

        //            // Título del documento
        //            document.Add(new Paragraph("Factura").SetTextAlignment(TextAlignment.CENTER).SetFontSize(20).SetFont(bold));

        //            document.Add(new Paragraph($"Código de Factura: {factura.CodigoFactura}")
        //                .SetFontSize(14)
        //                .SetFont(bold));

        //            document.Add(new Paragraph($"ID de Reserva: {factura.ReservaID}")
        //                .SetFontSize(12)
        //                .SetFont(normal));

        //            document.Add(new Paragraph($"Fecha: {factura.Fecha}")
        //                .SetFontSize(12)
        //                .SetFont(normal));

        //            document.Add(new Paragraph($"Monto Total: {factura.MontoTotal:C}")
        //                .SetFontSize(12)
        //                .SetFont(normal));
        //        }
        //    }

        //    MessageBox.Show("Factura exportada exitosamente a PDF.");
        //}

        private void ExportarFacturaSeleccionadaAPdf(string archivo)
        {
            if (dgvFacturas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione una factura para exportar.");
                return;
            }

            int facturaID = Convert.ToInt32(dgvFacturas.SelectedRows[0].Cells["FacturaID"].Value);
            Factura factura = _facturaBLL.ObtenerFacturaPorId(facturaID);

            using (var writer = new PdfWriter(archivo))
            {
                using (var pdf = new PdfDocument(writer))
                {
                    var document = new Document(pdf);

                    var bold = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                    var normal = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

                    document.Add(new Paragraph("Factura NotreDame").SetTextAlignment(TextAlignment.CENTER).SetFontSize(20).SetFont(bold));

                    document.Add(new Paragraph($"Código de Factura: {factura.CodigoFactura}").SetFontSize(14).SetFont(bold));
                    document.Add(new Paragraph($"Fecha: {factura.Fecha}").SetFontSize(12).SetFont(normal));
                    document.Add(new Paragraph($"Monto Total: {factura.MontoTotal:C}").SetFontSize(12).SetFont(normal));

                    document.Add(new Paragraph("Información del Cliente").SetFontSize(14).SetFont(bold));
                    document.Add(new Paragraph($"Nombre: {factura.Cliente.Nombre}").SetFontSize(12).SetFont(normal));
                    document.Add(new Paragraph($"Teléfono: {factura.Cliente.Telefono}").SetFontSize(12).SetFont(normal));
                    document.Add(new Paragraph($"Género: {factura.Cliente.Genero}").SetFontSize(12).SetFont(normal));
                    document.Add(new Paragraph($"Cédula: {factura.Cliente.Cedula}").SetFontSize(12).SetFont(normal));

                    document.Add(new Paragraph("Información de la Habitación").SetFontSize(14).SetFont(bold));
                    document.Add(new Paragraph($"Código de Habitación: {factura.Habitacion.CodigoHabitacion}").SetFontSize(12).SetFont(normal));
                    document.Add(new Paragraph($"Número: {factura.Habitacion.Numero}").SetFontSize(12).SetFont(normal));
                    document.Add(new Paragraph($"Estado: {factura.Habitacion.Estado}").SetFontSize(12).SetFont(normal));
                    document.Add(new Paragraph($"Categoría: {factura.Habitacion.Categoria.Nombre}").SetFontSize(12).SetFont(normal));

                    document.Add(new Paragraph("Servicios Adicionales").SetFontSize(14).SetFont(bold));
                    if (factura.ServiciosAdicionales != null && factura.ServiciosAdicionales.Count > 0)
                    {
                        foreach (var servicio in factura.ServiciosAdicionales)
                        {
                            document.Add(new Paragraph($"{servicio.Nombre}: {servicio.Precio:C}").SetFontSize(12).SetFont(normal));
                        }
                    }
                    else
                    {
                        document.Add(new Paragraph("No se añadieron servicios adicionales.").SetFontSize(12).SetFont(normal));
                    }
                }
            }

            MessageBox.Show("Factura exportada exitosamente a PDF.");
        }

        private void btnExportarFacturaPdf_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                saveFileDialog.Title = "Guardar Factura como PDF";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ExportarFacturaSeleccionadaAPdf(saveFileDialog.FileName);
                }
            }
        }


        //private void btnExportarFacturaPdf_Click(object sender, EventArgs e)
        //{
        //    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
        //    {
        //        saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
        //        saveFileDialog.Title = "Guardar Factura como PDF";
        //        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        //        {
        //            ExportarFacturaSeleccionadaAPdf(saveFileDialog.FileName);
        //        }
        //    }
        //}

    }
}
