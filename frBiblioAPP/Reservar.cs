using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frBiblioAPP
{
    public partial class Reservar : Form
    {
        Control_Libros _libros = new Control_Libros();
        controlReservaciones _reservaciones = new controlReservaciones();
        DataTable dt;
        public Reservar()
        {
            InitializeComponent();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btncunsulReservas_Click(object sender, EventArgs e)
        {
            frConsulReservas consulReservas = new frConsulReservas();
            Hide();
            consulReservas.ShowDialog();
            Show();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Reservar_Load(object sender, EventArgs e)
        {
            //dataGridView1
            CargarDatos();
        }

        private void CargarDatos()
        {
            dt = new DataTable();
            dt.Columns.Add("idLibro");
            dt.Columns.Add("tituloLibro");
            dt.Columns.Add("autor");
            dt.Columns.Add("estado");

            List<datosLibros> libros = _libros.ObtenerTodosLibros();

            foreach (var libro in libros)
            {
                dt.Rows.Add(libro.idLibro, libro.tituloLibro, libro.autor, libro.estado);
            }

            dataGridView1.DataSource = dt;
        }

        private void cmbCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(codReservacionTxt.Text)) {
                MessageBox.Show("Codigo del libro no debe quedar vacio", "Campos vacíos", MessageBoxButtons.OK);
                return;
            }

            string fecha = DateTime.Now.ToString("yyyy-MM-dd");

            DatosReservaciones datosReservaciones = new DatosReservaciones { 
                
                Usuario = "122003",
                correoUsuario = "juanitobazuca@hotmail.com",  
                dias_reservacion = fecha,
                fecha_reservacion = fecha,
                codigoLibro = codReservacionTxt.Text
            };

            _reservaciones.guardarReservacion(datosReservaciones);
        }
    }
}
