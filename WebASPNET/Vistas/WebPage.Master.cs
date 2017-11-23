using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Modelo;

namespace WebASPNET.Vistas
{
    public partial class WebPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CL_Usuario user = (CL_Usuario) Session["objectUser"];
            if (user==null)
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}