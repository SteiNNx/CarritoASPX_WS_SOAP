using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Modelo;

namespace WebASPNET.Vistas
{
    public partial class Home : System.Web.UI.Page
    {
        ServiceReference1.Service1Client serv = new ServiceReference1.Service1Client();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected List<CL_Producto> listarCombos()
        {
            return serv.productoListar().Where(x=>x.EsCombo=="SI").ToList();
        }

        protected void btn_comprar_Click(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                Logg.Mensaje(ex.Message);
            }
        }
    }
}