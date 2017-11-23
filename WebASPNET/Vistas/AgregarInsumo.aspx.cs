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
    public partial class AgregarInsumo : System.Web.UI.Page
    {
        ServiceReference1.Service1Client serv = new ServiceReference1.Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            rb_no.Checked = true;
        }

        protected void btn_grabar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_nombre.Text == "") { lbl_mensaje.Text = "Ingrese Nombre"; return; }
                if (txt_precio.Text == "") { lbl_mensaje.Text = "Ingrese Precio"; return; }
                if (txt_stock.Text == ""||Convert.ToInt32(txt_stock.Text)<1) { lbl_mensaje.Text = "Ingrese Stock"; return; }
                
                CL_Producto aux_pro = new CL_Producto();
                aux_pro.NombreProducto = txt_nombre.Text;
                aux_pro.PrecioProducto = Convert.ToInt32(txt_precio.Text);
                aux_pro.Stock = Convert.ToInt32(txt_stock.Text);
                if (rb_si.Checked)
                {
                    aux_pro.EsCombo = "SI";
                }
                else
                {
                    aux_pro.EsCombo = "NO";
                }
                aux_pro.DiaCombo = "2017-11-11";
                aux_pro.Habilitado = "HABILITADO";
                string xmlProducto = SerializeProducto<CL_Producto>(aux_pro);

                bool resp = serv.productoAgregar(xmlProducto);
                if (resp)
                {
                    lbl_mensaje.Text = "Agrego Producto";
                }
                else
                {
                    lbl_mensaje.Text = "No Agrego Producto";
                }
            }
            catch (Exception)
            {

                throw;
            }
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