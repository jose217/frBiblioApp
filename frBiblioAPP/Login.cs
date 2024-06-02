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
    public partial class Login : Form
    {
        Control_Usuarios usuarios = new Control_Usuarios();
        public Login()
        {
            InitializeComponent();
        }
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            Reservar reservar =new Reservar();
            Menu menu = new Menu();
            //consulta comprobando que el user y contraseña son correctas en la BD
            //si son correctas abrir el menu:
            string userRol = usuarios.obtenerRolUser(txtUsername.Text);
            if (usuarios.validarUser(txtUsername.Text, txtPassword.Text))
            {
                //si el rol es administrador que muestre el menu para administradores
                if (userRol == "Administrador")
                {
                    Hide();
                    menu.ShowDialog();
                    Show();
                }
                else
                {
                    Hide();
                    reservar.ShowDialog();
                    Show();

                }
            }
            else
            {
                MessageBox.Show("Error, usuario o contraseña incorrectos.","Error",MessageBoxButtons.OK);
                txtPassword.Text = "";
                txtUsername.Text = "";
                txtUsername.Focus();
               
            }

            
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
        }
    }
}
