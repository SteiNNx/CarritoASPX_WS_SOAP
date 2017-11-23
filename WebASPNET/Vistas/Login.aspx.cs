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
using System.Web.Security;


namespace WebASPNET.Vistas
{
    public partial class Login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            try
            {
                string nombre = Login1.UserName;
                string password = Login1.Password;

                CL_Usuario user = null;
                ServiceReference1.Service1Client serv = new ServiceReference1.Service1Client();
                user = serv.usuarioLogin(nombre,password);
                if (user!=null)
                {
                    FormsAuthentication.RedirectFromLoginPage(Login1.UserName, false);
                    Session["iniciada"] = true;
                    Session["objectUser"] = user;

                }

            }
            catch (Exception)
            {

                throw;
            }
        }



        public static string Serialize<CL_Usuario>(CL_Usuario value)
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