using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frBiblioAPP
{
    internal class datosLibros
    {
        public string idLibro {  get; set; }
        public string tituloLibro { get; set; }
        public string autor {  get; set; }
        public string fechaPublicacion {  get; set; }
        public string editorial { get; set; }
        public string categoria { get; set; }
        public int cantidad {  get; set; }
        public string estado { get; set; }
    }
}
