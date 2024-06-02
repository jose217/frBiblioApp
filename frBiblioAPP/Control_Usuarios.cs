using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frBiblioAPP
{
    internal class Control_Usuarios
    {
        SqlConnection conn = new SqlConnection("Data Source=JRAMOS\\MSSQLSERVER02;Initial Catalog=Biblioteca; Integrated Security=True;");

        public void guardarUsuarios(datosUsuarios Usuario)
        {
            try
            {
                //agregar validacion para que no puedan ingresar usuarios con el mismo codigo...
                string consulSql = "sp_guardar_usuarios";
                SqlCommand cmd = new SqlCommand(consulSql, conn);
                conn.Open();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", Usuario.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", Usuario.Apellido);
                cmd.Parameters.AddWithValue("@CodigoUsuario", Usuario.CodigoUsuario);
                cmd.Parameters.AddWithValue("@rolUsuario", Usuario.rolUser);
                cmd.Parameters.AddWithValue("@userPassword", Usuario.Password);
                cmd.Parameters.AddWithValue("@correoElectronico", Usuario.correoElectronico);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Registros guardados correctamente.", "Éxito al guardar", MessageBoxButtons.OK);
            }
            catch (Exception er)
            {
                Console.WriteLine(er);
                MessageBox.Show("Error, debe llenar todos los campos.", "Ups!", MessageBoxButtons.OK);
            }

        }
        public int obtenerIdUser(string codigoUsuario)
        {
            try
            {
                conn.Open();
                string consulta = "SELECT IdUsuario FROM Usuarios WHERE CodigoUsuario = @codigoUsuario";
                SqlCommand cmd = new SqlCommand(consulta, conn);
                cmd.Parameters.AddWithValue("@CodigoUsuario", codigoUsuario);
                var resultado = cmd.ExecuteScalar();

                conn.Close();
                //si el resultado de la consulta es diferente de un valor nulo devuelve el id, sino 0
                return resultado != null ? Convert.ToInt32(resultado) : 0;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al acceder al id del usuario: " + ex.Message);
                return 0;
            }

        }
        public string obtenerRolUser(string codigoUsuario)
        {
            try
            {
                conn.Open();
                string consulta = "SELECT rolUsuario FROM Usuarios WHERE CodigoUsuario = @codigoUsuario";
                SqlCommand cmd = new SqlCommand(consulta, conn);
                cmd.Parameters.AddWithValue("@CodigoUsuario", codigoUsuario);
                var resultado = Convert.ToString(cmd.ExecuteScalar());

                conn.Close();
                //si el resultado de la consulta es administrado devuelve el rol, sino devuelve usuario comun
                return resultado == "Administrador" ? "Administrador" : "Usuario";
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al acceder al rol del usuario: " + ex.Message);
                return null;

            }


        }
        //metodo para validar usuario y password
        public bool validarUser(string CodigoUsuario, string userPassword)
        {
            string consulta = "SELECT COUNT(*) FROM Usuarios WHERE CodigoUsuario = @CodigoUsuario AND userPassword = @userPassword";
            try
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand(consulta, conn);
                cmd.Parameters.AddWithValue("@CodigoUsuario", CodigoUsuario);
                cmd.Parameters.AddWithValue("@userPassword", userPassword);
                int cantidad = (int)cmd.ExecuteScalar();
                conn.Close();
                //devuelve true si las credenciales son validas
                return cantidad > 0;
            }
            catch (Exception ex)
            {
                //por si hay una excepcion durante la consulta de datos
                MessageBox.Show("Error al validar las credenciales: " + ex.Message);
                return false;
            }



        }
    }
}
