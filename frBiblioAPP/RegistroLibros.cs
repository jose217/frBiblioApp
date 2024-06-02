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
    public partial class RegistroLibros : Form
    {
        Control_Libros libro = new Control_Libros();
        DataTable dataTable;
        public RegistroLibros()
        {
            InitializeComponent();
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar si los campos están llenos
                if (string.IsNullOrEmpty(txtid.Text) || string.IsNullOrEmpty(txtTitulo.Text) ||
                    string.IsNullOrEmpty(txtAutor.Text) || string.IsNullOrEmpty(txtEditorial.Text) ||
                    string.IsNullOrEmpty(cmbCategoria.Text) || string.IsNullOrEmpty(txtCantidad.Text) ||
                    string.IsNullOrEmpty(txtEstado.Text))
                {
                    MessageBox.Show("Todos los campos deben estar llenos.", "Campos vacíos", MessageBoxButtons.OK);
                    return;
                }

                // Validar si cantidad es un número válido
                if (!int.TryParse(txtCantidad.Text, out int cantidad))
                {
                    MessageBox.Show("La cantidad debe ser un número entero.", "Formato incorrecto", MessageBoxButtons.OK);
                    return;
                }

                string fecha = dateFecha.Value.ToString("yyyy-MM-dd");

                datosLibros lb = new datosLibros
                {
                    idLibro = txtid.Text,
                    tituloLibro = txtTitulo.Text,
                    autor = txtAutor.Text,
                    fechaPublicacion = fecha,
                    editorial = txtEditorial.Text,
                    categoria = cmbCategoria.Text,
                    cantidad = cantidad,
                    estado = txtEstado.Text
                };

                libro.guardarLibros(lb);
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar el libro: {ex.Message}", "Error", MessageBoxButtons.OK);
            }
        }


        private void RegistroLibros_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            dataTable = new DataTable();
            dataTable.Columns.Add("idLibro");
            dataTable.Columns.Add("tituloLibro");
            dataTable.Columns.Add("autor");
            dataTable.Columns.Add("fechaPublicacion");
            dataTable.Columns.Add("editorial");
            dataTable.Columns.Add("categoria");
            dataTable.Columns.Add("cantidad");
            dataTable.Columns.Add("estado");

            List<datosLibros> libros = libro.ObtenerTodosLibros();

            foreach (var libro in libros)
            {
                dataTable.Rows.Add(libro.idLibro, libro.tituloLibro, libro.autor, libro.fechaPublicacion, libro.editorial, libro.categoria, libro.cantidad, libro.estado);
            }

            GridLibros.DataSource = dataTable;
        }

        private void GridLibros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (GridLibros.SelectedRows.Count > 0)
            {
                // Obtener el id del libro seleccionado
                string idLibro = GridLibros.SelectedRows[0].Cells["idLibro"].Value.ToString();

                // Eliminar el libro
                libro.EliminarLibro(idLibro);

                // Volver a cargar los datos en el DataGridView
                CargarDatos();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un libro para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /**
        private void GridLibros_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Obtener la fila y la columna editadas
            DataGridViewRow row = GridLibros.Rows[e.RowIndex];
            DataGridViewCell cell = row.Cells[e.ColumnIndex];

            // Obtener el nombre de la columna
            string columnName = GridLibros.Columns[e.ColumnIndex].Name;

            // Obtener el ID del libro editado
            string idLibro = row.Cells["idLibro"].Value.ToString();

            // Obtener el nuevo valor editado
            string newValue = cell.Value.ToString();

            // Actualizar el libro en la base de datos
            libro.ActualizarDatoLibro(idLibro, columnName, newValue);
        }*/

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable changes = dataTable.GetChanges();

            if (changes != null)
            {
                foreach (DataRow row in changes.Rows)
                {
                    // Aquí puedes obtener los valores modificados y realizar la actualización en la base de datos
                    String idLibro = row["idLibro"].ToString();
                    string tituloLibro = row["tituloLibro"].ToString();
                    string autor = row["autor"].ToString();
                    DateTime fechaPublicacion = Convert.ToDateTime(row["fechaPublicacion"]);
                    string editorial = row["editorial"].ToString();
                    string categoria = row["categoria"].ToString();
                    int cantidad = int.Parse(row["cantidad"].ToString());
                    string estado = row["estado"].ToString();

                    // Actualiza la base de datos con los valores modificados
                    libro.ActualizarDatoLibro(idLibro, tituloLibro, autor, fechaPublicacion, editorial, categoria, cantidad, estado);
                }

                // Aceptamos los cambios en el DataTable
                dataTable.AcceptChanges();
            }
        }
    }
}
