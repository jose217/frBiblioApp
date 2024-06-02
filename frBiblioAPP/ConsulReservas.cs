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
    public partial class frConsulReservas : Form
    {
        DataTable dataTable;
        controlReservaciones controlRes = new controlReservaciones();

        public frConsulReservas()
        {
            InitializeComponent();
            this.Load += new EventHandler(frConsulReservas_Load);

        }

        private void frConsulReservas_Load(object sender, EventArgs e) {
            CargarDatos();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CargarDatos()
        {
            dataTable = new DataTable();
            dataTable.Columns.Add("idReservacion");
            dataTable.Columns.Add("Usuario");
            dataTable.Columns.Add("correoUsuario");
            dataTable.Columns.Add("dias_reservacion");
            dataTable.Columns.Add("fecha_reservacion");
            dataTable.Columns.Add("codigoLibro");

            List<DatosReservaciones> reservaciones = controlRes.ObtenerReservaciones();

            foreach (var reservacion in reservaciones)
            {
                dataTable.Rows.Add(reservacion.idReservacion, reservacion.Usuario, reservacion.correoUsuario, reservacion.dias_reservacion, reservacion.fecha_reservacion, reservacion.codigoLibro);
            }

            ReservacionesConsult.DataSource = dataTable;
        }
    }
}
