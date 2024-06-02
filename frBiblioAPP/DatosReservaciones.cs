using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frBiblioAPP
{
    internal class DatosReservaciones
    {
        public int idReservacion { get; set; }
        public string Usuario { get; set; }
        public string correoUsuario { get; set; }
        public string dias_reservacion { get; set; }
	    public string fecha_reservacion { get; set; }
        public string codigoLibro { get; set; }
    }
}
