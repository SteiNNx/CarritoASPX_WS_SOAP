using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace WebASPNET.Vistas
{
    public partial class ListadoDeProductos : System.Web.UI.Page
    {
        ServiceReference1.Service1Client serv = new ServiceReference1.Service1Client();

        protected void Page_Load(object sender, EventArgs e)
        {
            var op = serv.productoListar();
            gv_stock_productos.DataSource = from datos in op select new { datos.IdProducto,datos.NombreProducto,datos.PrecioProducto,datos.Stock};
            gv_stock_productos.DataBind();

        }
        protected string obtenerDatos()
        {
            DataTable datos = new DataTable();

            datos.Columns.Add(new DataColumn("Productos",typeof(string)));
            datos.Columns.Add(new DataColumn("Stock", typeof(string)));

            foreach (var item in serv.productoListar())
            {
                datos.Rows.Add(new object[] {item.NombreProducto,item.Stock });
            }

            string strDatos="[['Producto', 'Stock'],";
            foreach (DataRow item in datos.Rows)
            {
                strDatos = strDatos + "[";
                strDatos = strDatos + "'"+item[0]+"'"+","+item[1];
                strDatos = strDatos + "],";

            }
            strDatos = strDatos.TrimEnd(',');
            strDatos = strDatos + "]";
            return strDatos;
        } 
    }
}