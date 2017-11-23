using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebASPNET.Vistas
{
    public partial class ListadoVentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Dictionary<string, string> list = new Dictionary<string, string>();
                for (int i = 1; i < 52 + 1; i++)
                {
                    list.Add(Convert.ToString(i), Convert.ToString(i));
                }
                ddl_semana.DataSource = list;
                ddl_semana.DataTextField = "Value";
                ddl_semana.DataValueField = "Key";
                ddl_semana.DataBind();
                ddl_semana.SelectedIndex = 45;
                llenar();
            }




        }

        private void llenar()
        {
            int seman = Convert.ToInt32(ddl_semana.SelectedItem.Text);
            ServiceReference1.Service1Client serv = new ServiceReference1.Service1Client();

            List<CL_Compra> listaCompFiltrada = serv.compraListar().Where(x => Math.Round(((Convert.ToDateTime(x.FechaCompra).DayOfYear+3) / 7.00), 0) == seman).ToList();
            List<CL_DetalleCompra> listaDet = serv.detalleCompraListar().ToList();

            var query = from l_com in listaCompFiltrada
                        join l_det in listaDet
                        on l_com.IdCompra equals l_det.Compra.IdCompra
                        select new { l_com.IdCompra,l_com.UsuarioCompra.Nombre, l_com.FechaCompra, l_det.Producto.NombreProducto, l_det.Producto.PrecioProducto, l_det.Cantidad };

            int total = 0;
            foreach (var item in query)
            {
                total += item.Cantidad * item.PrecioProducto;
            }

            gv_ventas_por_semanas.DataSource = query.ToList();
            gv_ventas_por_semanas.DataBind();
            lbl_mensaje.Text = "El Precio Total Semana "+ddl_semana.SelectedItem.Text+" es: " + total;
            if (total==0)
            {
                lbl_mensaje.Text = "No Hay Ventas en esta Semana: " + ddl_semana.SelectedItem.Text;
            }

        }

        protected void btn_seman_Click(object sender, EventArgs e)
        {
            llenar();
        }
    }
}