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
    internal class controlReservaciones : Conexion
    {
        SqlConnection conn = new SqlConnection("Data Source=JRAMOS\\MSSQLSERVER02;Initial Catalog=Biblioteca; Integrated Security=True;");

        public List<DatosReservaciones> ObtenerReservaciones()
        {
            List<DatosReservaciones> Res = new List<DatosReservaciones>();

            try
            {
                // Consulta SQL para obtener todos los libros
                string consultaSql = "SELECT * FROM Reservaciones";

                // Abrir la conexión
                conn.Open();

                // Ejecutar la consulta SQL
                SqlCommand cmd = new SqlCommand(consultaSql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                // Leer los resultados y crear objetos datosLibros
                while (reader.Read())
                {
                    DatosReservaciones reservacion = new DatosReservaciones
                    {
                        idReservacion = int.Parse(reader["idReservacion"].ToString()),
                        Usuario = reader["Usuario"].ToString(),
                        correoUsuario = reader["correoUsuario"].ToString(),
                        dias_reservacion = reader["dias_reservacion"].ToString(),
                        fecha_reservacion = reader["fecha_reservacion"].ToString(),
                        codigoLibro = reader["codigoLibro"].ToString()
                    };
                    Res.Add(reservacion);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener Reservaciones: " + ex.Message);
            }
            finally
            {
                // Cerrar la conexión
                conn.Close();
            }

            return Res;
        }

        public void guardarReservacion(DatosReservaciones reservacion)
        {
            try
            {
                string consulSql = "sp_ingresar_reservacion";
                using (SqlCommand cmd = new SqlCommand(consulSql, conn))
                {
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Usuario", reservacion.Usuario);
                    cmd.Parameters.AddWithValue("@correoUsuario", reservacion.correoUsuario);
                    cmd.Parameters.AddWithValue("@dias_reservacion", reservacion.dias_reservacion);
                    cmd.Parameters.AddWithValue("@fecha_reservacion", reservacion.fecha_reservacion);
                    cmd.Parameters.AddWithValue("@codigoLibro", reservacion.codigoLibro);
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
    }
}
