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
    public partial class Menu : Form
    {
    
        public Menu()
        {
            InitializeComponent();
        }
       
        Login lg = new Login();
        
       
        private void btnReservar_Click(object sender, EventArgs e)
        {
            Reservar reservar = new Reservar();
            Hide();
            reservar.ShowDialog();
            Show();        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            RegistroLibros registrolibros = new RegistroLibros();
            Hide();
            registrolibros.ShowDialog();
            Show();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            RegistroUsuarios registroUsuarios = new RegistroUsuarios();
            Hide();
            registroUsuarios.ShowDialog();
            Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
