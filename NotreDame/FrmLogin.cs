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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            IniciarSesion();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void LimpiarCampos() 
        {
            txtContraseña.Clear() ;
            txtUsuario .Clear() ;
        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e) 
        {
            if (e.KeyChar == (char)Keys.Enter) 
            { 
                IniciarSesion(); 
            }
        }

        private void IniciarSesion() 
        { 
            string usuario = txtUsuario.Text; 
            string contraseña = txtContraseña.Text; 
            if (usuario == "admon" && contraseña == "12345") 
            {
                //MessageBox.Show("Inicio de sesión exitoso.");
                Principal principal = new Principal();
                principal.Show();
                this.Hide();
            } 
            else 
            { 
                MessageBox.Show("Usuario o contraseña incorrectos. Intente nuevamente.");
                LimpiarCampos(); 
            } 
        }
    }
}
