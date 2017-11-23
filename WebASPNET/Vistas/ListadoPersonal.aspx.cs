using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Modelo;
using System.Data;

namespace WebASPNET.Vistas
{
    public partial class ListadoPersonal : System.Web.UI.Page
    {
        ServiceReference1.Service1Client serv = new ServiceReference1.Service1Client();

        protected void Page_Load(object sender, EventArgs e)
        {
            var per = serv.usuarioListar().Where(x=>x.TipoUsuario=="Personal");

            gv_personal.DataSource = from datos in per select new { datos.Nombre,datos.Apellido,datos.Local};
            gv_personal.DataBind();
        }

        protected string obtenerDatos()
        {
            List<CL_Usuario> listaUser = serv.usuarioListar().ToList();
            var groups = listaUser.GroupBy(n => n.Local)
            .Select(n => new
            {
                MetricName = n.Key,
                MetricCount = n.Count()
            }
            )
            .OrderBy(n => n.MetricName);
            //
            DataTable datos = new DataTable();

            datos.Columns.Add(new DataColumn("Productos", typeof(string)));
            datos.Columns.Add(new DataColumn("Stock", typeof(string)));

            foreach (var item in groups.ToList())
            {
                datos.Rows.Add(new object[] { item.MetricName, item.MetricCount });
            }

            string strDatos = "[['Local', 'Cantidad Personal'],";
            foreach (DataRow item in datos.Rows)
            {
                strDatos = strDatos + "[";
                strDatos = strDatos + "'" + item[0] + "'" + "," + item[1];
                strDatos = strDatos + "],";

            }
            strDatos = strDatos.TrimEnd(',');
            strDatos = strDatos + "]";
            return strDatos;
        }
    }
}