using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frBiblioAPP
{
    public partial class RegistroUsuarios : Form
    {
        Control_Usuarios usuarios = new Control_Usuarios();
        public RegistroUsuarios()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            datosUsuarios us = new datosUsuarios();
            us.Nombre = txtNombre.Text;
            us.Apellido = txtApellido.Text;
            us.CodigoUsuario =txtCodeuser.Text;
            us.rolUser = cmbRol.Text;
            us.Password = txtContra.Text;
            us.correoElectronico = txtCorreo.Text;

            Control_Usuarios usuarios = new Control_Usuarios();
            usuarios.guardarUsuarios(us);

        }

     
    }
}
