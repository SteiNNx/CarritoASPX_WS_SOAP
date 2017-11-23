using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Modelo;
using DAO;
using System.Data;
using System.Globalization;
using System.Xml.Serialization;
using System.Xml;
using System.Text;
using System.IO;

namespace WebASPNET.Vistas
{
    public partial class Productos : System.Web.UI.Page
    {
        ServiceReference1.Service1Client serv = new ServiceReference1.Service1Client();
        DataTable aux_table;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {

            }
            else
            {
                List<CL_Producto> productos = serv.productoListar().Where(x=>x.Habilitado=="HABILITADO").ToList();
                DropDownList1.DataTextField = "NombreProducto";
                DropDownList1.DataValueField = "IdProducto";
                DropDownList1.DataSource = productos;
                DropDownList1.DataBind();
                if (Request.QueryString["dato"]!=null)
                {
                    string valor = Request.QueryString["dato"].ToString();
                    lbl_mensaje.Text = valor;
                    int idProd=serv.productoListar().Where(x => x.NombreProducto == valor).First().IdProducto;
                    DropDownList1.SelectedValue = idProd.ToString();
                    lbl_mensaje.Text = DropDownList1.SelectedValue;
                }
                
                llenar();

            }

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenar();
        }

        private void llenar()
        {
            CL_Producto producto = serv.productoListar().Where(x => x.IdProducto == Convert.ToInt32(DropDownList1.SelectedValue)).First();
            lbl_precio.Text = Convert.ToString(producto.PrecioProducto);
            lbl_stock.Text = Convert.ToString(producto.Stock);
            Dictionary<string, string> list = new Dictionary<string, string>();
            for (int i = 1; i < Convert.ToInt32(lbl_stock.Text)+1; i++)
            {
                list.Add(Convert.ToString(i), Convert.ToString(i));
            }
            DropDownList2.DataSource = list;
            DropDownList2.DataTextField = "Value";
            DropDownList2.DataValueField = "Key";
            DropDownList2.DataBind();
        }

        protected void btn_agregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["tablaCompra"] == null)
                {
                    aux_table = new DataTable();
                    aux_table.Columns.Add("ID");
                    aux_table.Columns.Add("Nombre Producto");
                    aux_table.Columns.Add("Precio");
                    aux_table.Columns.Add("Cantidad");
                }
                else
                {
                    aux_table =(DataTable) Session["tablaCompra"];
                }
                
                DataRow dr = aux_table.NewRow();
                dr["ID"] = DropDownList1.SelectedValue ;
                dr["Nombre Producto"] = DropDownList1.SelectedItem.Text;
                dr["Precio"] = lbl_precio.Text;
                dr["Cantidad"] = DropDownList2.SelectedItem.Text;

                aux_table.Rows.Add(dr);
                Session["tablaCompra"] = aux_table;
                gv_carro.DataSource = aux_table;
                gv_carro.DataBind();
            }
            catch (Exception ex)
            {
                Logg.Mensaje(ex.Message);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                CL_Usuario aux_user = (CL_Usuario)Session["objectUser"];
                CL_Compra compra = new CL_Compra();
                compra.UsuarioCompra = aux_user;
                string date = DateTime.Now.ToString("yyyy-MM-dd");
                compra.FechaCompra = date;
                //lbl_mensaje.Text = aux_user.IdUsuario + "|" + date;

                string compraSerialziado = Serialize<CL_Compra>(compra);

                bool resp = serv.compraAgregar(compraSerialziado);
                if (resp)
                {
                    List<CL_DetalleCompra> listaDetalleCompra = new List<CL_DetalleCompra>();
                    foreach (GridViewRow gvr in gv_carro.Rows)
                    {
                        CL_DetalleCompra aux_det = new CL_DetalleCompra();
                        CL_Producto pro  = new CL_Producto();
                        pro.IdProducto =Convert.ToInt32(gvr.Cells[0].Text);
                        aux_det.Producto = pro;
                        CL_Compra com = new CL_Compra();
                        DAO_Compra dao = new DAO_Compra();
                        com.IdCompra = dao.maxId();
                        aux_det.Compra = com;
                        aux_det.Cantidad = Convert.ToInt32(gvr.Cells[3].Text);
                        listaDetalleCompra.Add(aux_det);
                    }
                    foreach (CL_DetalleCompra item in listaDetalleCompra)
                    {
                        string xmlDetalle= SerializeDetalle<CL_DetalleCompra>(item);
                        serv.detalleCompraAgregar(xmlDetalle);
                    }
                    lbl_mensaje.Text += "Compra Exitosa";

                    Session.Remove("tablaCompra");
                }
                else
                {
                    lbl_mensaje.Text += "Compra No Exitosa,Intentelo Mas Tarde";
                }
            }
            catch (Exception ex)
            {
                Logg.Mensaje(ex.Message);
            }
        }


        public static string Serialize<CL_Compra>(CL_Compra value)
        {

            if (value == null)
            {
                return null;
            }

            XmlSerializer serializer = new XmlSerializer(typeof(CL_Compra));

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
        public static string SerializeDetalle<CL_DetalleCompra>(CL_DetalleCompra value)
        {

            if (value == null)
            {
                return null;
            }

            XmlSerializer serializer = new XmlSerializer(typeof(CL_DetalleCompra));

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