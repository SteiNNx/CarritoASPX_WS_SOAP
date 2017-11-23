using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Modelo;
using System.Xml.Serialization;
using System.Text;
using System.Xml;
using System.IO;

namespace WebASPNET.Vistas
{
    public partial class GestionarPersonal : System.Web.UI.Page
    {
        ServiceReference1.Service1Client serv = new ServiceReference1.Service1Client();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<CL_Usuario> userPersonal = serv.usuarioListar().Where(x => x.TipoUsuario == "Personal" && x.Habilitado=="HABILITADO").ToList();
                Dictionary<string, string> list = new Dictionary<string, string>();
                foreach (CL_Usuario item in userPersonal)
                {
                    list.Add(item.User, item.Nombre + " " + item.Apellido);
                }
                ddl_personal.DataSource = list;
                ddl_personal.DataTextField = "Value";
                ddl_personal.DataValueField = "Key";
                ddl_personal.DataBind();

                List<string> listaLocales = serv.locales().ToList();
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
                llenar();
            }
        }

        private void llenar()
        {
            CL_Usuario user = serv.usuarioListar().Where(x => x.User == ddl_personal.SelectedValue).First();
            txt_nombre.Text = user.Nombre;
            txt_apellido.Text = user.Apellido;
            ddl_local.SelectedValue = user.Local;
        }

        protected void ddl_personal_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenar();
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

        protected void btn_actualizar_Click(object sender, EventArgs e)
        {
            try
            {
                CL_Usuario aux_user = serv.usuarioListar().Where(x=>x.User==ddl_personal.SelectedValue).First();
                aux_user.Nombre = txt_nombre.Text;
                aux_user.Apellido = txt_apellido.Text;
                aux_user.Local = ddl_local.SelectedValue;
                string xmlUser = SerializeUser<CL_Usuario>(aux_user);

                bool resp = serv.usuarioActualizarXML(xmlUser);
                if (resp)
                {
                    lbl_mensaje.Text = "Actualizo Usuario";
                }
            }
            catch(Exception ex)
            {
                Logg.Mensaje(ex.Message);
            }
        }

        protected void btn_despedir_Click(object sender, EventArgs e)
        {
            try
            {
                CL_Usuario aux_user = serv.usuarioListar().Where(x => x.User == ddl_personal.SelectedValue).First();
                
                bool resp = serv.usuarioEliminar(aux_user.IdUsuario);
                if (resp)
                {
                    lbl_mensaje.Text = "Elimino Usuario";
                }
            }
            catch (Exception ex)
            {
                Logg.Mensaje(ex.Message);
            }
        }

        
    }
    
}