using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class CL_DetalleCompra
    {
        public CL_Compra Compra{ get; set; }
        public CL_Producto Producto { get; set; }
        public int Cantidad { get; set; }
        public CL_DetalleCompra()
        {

        }
    }
}
