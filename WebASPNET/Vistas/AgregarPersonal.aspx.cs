using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Modelo;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System.Text;

namespace WebASPNET.Vistas
{
    public partial class AgregarPersonal : System.Web.UI.Page
    {
        ServiceReference1.Service1Client serv = new ServiceReference1.Service1Client();

        protected void Page_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> list2 = new Dictionary<string, string>();
            /*foreach (string item2 in listaLocales)
            {
                list2.Add(item2, item2);
            }*/
            list2.Add("Puente Alto", "Puente Alto");
            list2.Add("Pirque", "Pirque");
            list2.Add("Florida", "Florida");
            ddl_local.DataSource = list2;
            ddl_local.DataTextField = "Value";
            ddl_local.DataValueField = "Key";
            ddl_local.DataBind();
        }

        protected void btn_grabar_Click(object sender, EventArgs e)
        {
            try
            {
                CL_Usuario user = new CL_Usuario();
                user.Nombre = txt_nombre.Text;
                user.Apellido = txt_apellido.Text;
                user.Local = ddl_local.SelectedValue;
                user.Habilitado = "HABILITADO";
                user.Password = "1234";
                user.TipoUsuario = "Personal";

                string xmlUser = SerializeUser<CL_Usuario>(user);

                bool resp = serv.usuarioGrabarXML(xmlUser);
                if (resp)
                {
                    lbl_mensaje.Text = "Usuario Agregado";
                }
                else
                {
                    lbl_mensaje.Text = "Usuario No Agregado";
                }
            }
            catch (Exception ex)
            {
                Logg.Mensaje(ex.Message);
            }
        }

        public static string SerializeUser<CL_Usuario>(CL_Usuario value)
        {

            if (value == null)
            {
                return null;
            }

            XmlSerializer serializer = new XmlSerializer(typeof(CL_Usuario));

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