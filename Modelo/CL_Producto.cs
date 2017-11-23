using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class CL_Producto
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public int PrecioProducto { get; set; }
        public string EsCombo{ get; set; }
        public string DiaCombo{ get; set; }
        public int Stock { get; set; }
        public string Habilitado{ get; set; }
        public CL_Producto()
        {

        }
    }
}
