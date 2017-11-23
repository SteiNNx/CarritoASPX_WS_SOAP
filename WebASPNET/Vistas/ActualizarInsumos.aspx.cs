using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Modelo;
using System.Xml.Serialization;
using System.Xml;
using System.Text;
using System.IO;

namespace WebASPNET.Vistas
{
    public partial class Registro_Insumos : System.Web.UI.Page
    {
        ServiceReference1.Service1Client serv = new ServiceReference1.Service1Client();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<CL_Producto> productos = serv.productoListar().ToList();
                ddl_producto.DataTextField = "NombreProducto";
                ddl_producto.DataValueField = "IdProducto";
                ddl_producto.DataSource = productos;
                ddl_producto.DataBind();
                llenar();
            }
            
        }

        private void llenar()
        {
            CL_Producto producto = serv.productoListar().Where(x => x.IdProducto == Convert.ToInt32(ddl_producto.SelectedValue)).First();
            txt_precio.Text = Convert.ToString(producto.PrecioProducto);
            txt_stock.Text = Convert.ToString(producto.Stock);
            if (producto.Habilitado=="HABILITADO")
            {
                rb_si.Checked = true;
                rb_no.Checked = false;
            }
            else
            {
                rb_no.Checked = true;
                rb_si.Checked = false;
            }
        }

        protected void btn_actualizar_Click(object sender, EventArgs e)
        {
            try
            {
                CL_Producto aux_pro = serv.productoListar().Where(x=>x.NombreProducto==ddl_producto.SelectedItem.Text).First();

                aux_pro.PrecioProducto = Convert.ToInt32(txt_precio.Text);
                aux_pro.Stock = Convert.ToInt32(txt_stock.Text);
                string dia = Convert.ToDateTime(aux_pro.DiaCombo).ToString("yyyy-MM-dd");
                aux_pro.DiaCombo = dia;
                if (rb_si.Checked)
                {
                    aux_pro.Habilitado = "HABILITADO";
                }
                else
                {
                    aux_pro.Habilitado = "DESHABILITADO";
                }
                string xmlProducto = SerializeProducto<CL_Producto>(aux_pro);

                bool resp = serv.productoActualizar(xmlProducto);
                if (resp)
                {
                    lbl_mensaje.Text = "Producto Actualizado";
                }

            }
            catch (Exception ex)
            {
                Logg.Mensaje(ex.Message);
            }
        }

        protected void ddl_producto_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenar();
        }


        public static string SerializeProducto<CL_Producto>(CL_Producto value)
        {

            if (value == null)
            {
                return null;
            }

            XmlSerializer serializer = new XmlSerializer(typeof(CL_Producto));

            XmlWriterSettings settings = new XmlWriterSettings()
            {
                Encoding = new UnicodeEncoding(false, false), // no BOM in a .NET string
                Indent = false,
                OmitXmlDeclaration = false
            };

            using (StringWriter textWriter = new StringWriter())
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(textWriter, settings))
                {
                    serializer.Serialize(xmlWriter, value);
                }
                return textWriter.ToString();
            }
        }
    }
}