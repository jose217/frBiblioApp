using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frBiblioAPP
{
    internal class Control_Libros : Conexion
    {
        SqlConnection conn = new SqlConnection("Data Source=JRAMOS\\MSSQLSERVER02;Initial Catalog=Biblioteca; Integrated Security=True;");

        public void guardarLibros(datosLibros Libros)
        {
            try
            {
                string consulSql = "sp_ingresar_libros";
                using (SqlCommand cmd = new SqlCommand(consulSql, conn))
                {
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idLibro", Libros.idLibro);
                    cmd.Parameters.AddWithValue("@tituloLibro", Libros.tituloLibro);
                    cmd.Parameters.AddWithValue("@autor", Libros.autor);
                    cmd.Parameters.AddWithValue("@fechaPublicacion", Libros.fechaPublicacion);
                    cmd.Parameters.AddWithValue("@editorial", Libros.editorial);
                    cmd.Parameters.AddWithValue("@categoria", Libros.categoria);
                    cmd.Parameters.AddWithValue("@cantidad", Libros.cantidad);
                    cmd.Parameters.AddWithValue("@estado", Libros.estado);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Registros guardados correctamente.", "Éxito al guardar", MessageBoxButtons.OK);
            }
            catch (SqlException ex) when (ex.Number == 2627) // Número de error para clave duplicada en SQL Server
            {
                MessageBox.Show("Error, el id ya existe.", "Ups!", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar los registros: {ex.Message}", "Ups!", MessageBoxButtons.OK);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }


        public List<datosLibros> ObtenerTodosLibros()
        {
            List<datosLibros> libros = new List<datosLibros>();

            try
            {
                // Consulta SQL para obtener todos los libros
                string consultaSql = "SELECT * FROM Libros";

                // Abrir la conexión
                conn.Open();

                // Ejecutar la consulta SQL
                SqlCommand cmd = new SqlCommand(consultaSql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                // Leer los resultados y crear objetos datosLibros
                while (reader.Read())
                {
                    datosLibros libro = new datosLibros
                    {
                        idLibro = reader["idLibro"].ToString(),
                        tituloLibro = reader["tituloLibro"].ToString(),
                        autor = reader["autor"].ToString(),
                        fechaPublicacion = reader["fechaPublicacion"].ToString(),
                        editorial = reader["editorial"].ToString(),
                        categoria = reader["categoria"].ToString(),
                        cantidad = Convert.ToInt32(reader["cantidad"]),
                        estado = reader["estado"].ToString()
                    };
                    libros.Add(libro);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener libros: " + ex.Message);
            }
            finally
            {
                // Cerrar la conexión
                conn.Close();
            }

            return libros;
        }

        public void EliminarLibro(string idLibro)
        {
            try
            {
                // Consulta SQL para eliminar un libro por su ID
                string consultaSql = "DELETE FROM Libros WHERE idLibro = @idLibro";

                // Abrir la conexión
                conn.Open();

                // Crear el comando SQL con la consulta y los parámetros
                SqlCommand cmd = new SqlCommand(consultaSql, conn);
                cmd.Parameters.AddWithValue("@idLibro", idLibro);

                // Ejecutar el comando SQL
                cmd.ExecuteNonQuery();

                MessageBox.Show("Libro eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el libro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Cerrar la conexión
                conn.Close();
            }
        }

        public void ActualizarDatoLibro(String idLibro, string tituloLibro, string autor, DateTime fechaPublicacion, string editorial, string categoria, int cantidad, string estado)
        {
            try
            {
                // Consulta SQL para actualizar un solo campo del libro
                string consultaSql = "UPDATE Libros SET tituloLibro = @tituloLibro, autor = @autor, fechaPublicacion = @fechaPublicacion, editorial = @editorial, categoria = @categoria, cantidad = @cantidad, estado = @estado WHERE idLibro = @idLibro";

                // Abrir la conexión
                conn.Open();

                // Crear el comando SQL con la consulta y los parámetros
                SqlCommand cmd = new SqlCommand(consultaSql, conn);
                cmd.Parameters.AddWithValue("@idLibro", idLibro);
                cmd.Parameters.AddWithValue("@tituloLibro", tituloLibro);
                cmd.Parameters.AddWithValue("@autor", autor);
                cmd.Parameters.AddWithValue("@fechaPublicacion", fechaPublicacion);
                cmd.Parameters.AddWithValue("@editorial", editorial);
                cmd.Parameters.AddWithValue("@categoria", categoria);
                cmd.Parameters.AddWithValue("@cantidad", cantidad);
                cmd.Parameters.AddWithValue("@estado", estado);

                // Ejecutar la consulta
                cmd.ExecuteNonQuery();

                MessageBox.Show("Dato del libro actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el dato del libro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Cerrar la conexión
                conn.Close();
            }
        }


        public List<datosLibros> ObtenerTodosLibrosDisponibles()
        {
            List<datosLibros> libros = new List<datosLibros>();

            try
            {
                // Consulta SQL para obtener todos los libros
                string consultaSql = "SELECT idLibro, tituloLibro, autor, estado FROM Libros WHERE estado = 'Disponible'";

                // Abrir la conexión
                conn.Open();

                // Ejecutar la consulta SQL
                SqlCommand cmd = new SqlCommand(consultaSql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                // Leer los resultados y crear objetos datosLibros
                while (reader.Read())
                {
                    datosLibros libro = new datosLibros
                    {
                        idLibro = reader["idLibro"].ToString(),
                        tituloLibro = reader["tituloLibro"].ToString(),
                        autor = reader["autor"].ToString(),
                        estado = reader["estado"].ToString()
                    };
                    libros.Add(libro);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener libros: " + ex.Message);
            }
            finally
            {
                // Cerrar la conexión
                conn.Close();
            }

            return libros;
        }

    }


}
