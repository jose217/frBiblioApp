using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace frBiblioAPP
{
    internal class Conexion
    {
        SqlConnection conn;

        //constructor para que la conexion sea automatica
        public Conexion()
        {
            try
            {
                conn = new SqlConnection("Data Source=JRAMOS\\MSSQLSERVER02;Initial Catalog=Biblioteca; Integrated Security=True;");
                conn.Open();
                //MessageBox.Show("Conectado correctamente");
                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error, al conectar con la base de datos: "+ex.Message);
                
            }
            
        }
        
        /*
         los parametros reciben la clase datosLibros con un objeto que se comunica con la
        interfaz grafica para que se encargue de las consultas
         */
        
        
      
    }
}
