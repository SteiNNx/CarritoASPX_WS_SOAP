using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class CL_Usuario
    {
        public int  IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Password { get; set; }
        public string TipoUsuario { get; set; }
        public string User{ get; set; }
        public string Local { get; set; }
        public string Habilitado { get; set; }
        public CL_Usuario()
        {

        }
    }
}
