using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class CL_Compra
    {
        public int IdCompra { get; set; }
        public string FechaCompra { get; set; }
        public CL_Usuario UsuarioCompra{ get; set; }
        public CL_Compra()
        {

        }
    }
}
