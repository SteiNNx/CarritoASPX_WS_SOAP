using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Modelo;
using MySql.Data.MySqlClient;

namespace DAO
{
    public class DAO_DetalleCompra
    {
        private MySqlConnection cone;

        public DAO_DetalleCompra()
        {
            cone = new CL_Conexion().obtenerConexion();
        }

        public List<CL_DetalleCompra> listarDetalleCompra()
        {
            List<CL_DetalleCompra> lista = new List<CL_DetalleCompra>();
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "SELECT * FROM COMPRA C INNER JOIN USUARIO U ON(C.IDUSUARIO=U.IDUSUARIO)"
                    + " INNER JOIN DETALLECOMPRA D ON(D.IDCOMPRA=C.IDCOMPRA)"
                    + " INNER JOIN PRODUCTO P ON(P.IDPRODUCTO=D.IDPRODUCTO)";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = cone;
                if (cone.State != System.Data.ConnectionState.Open)
                {
                    cone.Open();
                }
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    CL_Compra aux_compra = new CL_Compra();
                    aux_compra.IdCompra = Convert.ToInt32(dr["idCompra"].ToString());
                    aux_compra.FechaCompra = dr["fechaCompra"].ToString();
                    CL_Usuario aux_user = new CL_Usuario();
                    aux_user.IdUsuario = Convert.ToInt32(dr["idUsuario"].ToString());
                    aux_user.Nombre = dr["Nombre"].ToString();
                    aux_user.Apellido = dr["Apellido"].ToString();
                    aux_user.TipoUsuario = dr["TipoUsuario"].ToString();
                    aux_user.User = dr["user"].ToString();
                    aux_user.Local = dr["local"].ToString();
                    aux_user.Habilitado = dr["habilitado"].ToString();
                    aux_compra.UsuarioCompra = aux_user;


                    CL_Producto aux_producto = new CL_Producto();
                    aux_producto.IdProducto = Convert.ToInt32(dr["idProducto"].ToString());
                    aux_producto.NombreProducto = dr["NombreProducto"].ToString();
                    aux_producto.PrecioProducto = Convert.ToInt32(dr["PrecioProducto"].ToString());
                    aux_producto.EsCombo = dr["EsCombo"].ToString();
                    aux_producto.Stock = Convert.ToInt32(dr["stock"].ToString());
                    aux_producto.DiaCombo = dr["DiaCombo"].ToString();
                    aux_producto.Habilitado = dr["habilitado"].ToString();

                    CL_DetalleCompra aux_detalle = new CL_DetalleCompra();
                    aux_detalle.Producto = aux_producto;
                    aux_detalle.Compra = aux_compra;
                    aux_detalle.Cantidad = Convert.ToInt32(dr["Cantidad"].ToString());

                    lista.Add(aux_detalle);
                }
                cone.Close();
            }
            catch (Exception ex)
            {
                Logg.Mensaje(ex.Message);
                if (cone.State != System.Data.ConnectionState.Closed) { cone.Close(); };
                return null;
            }
            return lista;
        }

        public int agregarDetalleCompra(CL_DetalleCompra p_detalle)
        {
            int resp = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = string.Format("INSERT INTO DETALLECOMPRA(idCompra,idProducto,Cantidad)"
                    + " VALUES({0},{1},{2})"
                    , p_detalle.Compra.IdCompra, p_detalle.Producto.IdProducto, p_detalle.Cantidad);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = cone;
                if (cone.State != System.Data.ConnectionState.Open)
                {
                    cone.Open();
                }
                resp = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Logg.Mensaje(ex.Message);
                if (cone.State != System.Data.ConnectionState.Closed) { cone.Close(); };
                return 0;
            }
            return resp;
        }

        public int actualizarDetalleCompraCantidad(CL_DetalleCompra p_detalle)
        {
            int resp = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = string.Format("UPDATE DETALLECOMPRA SET "
                    + "Cantidad = {0}  WHERE idCompra = {1} and idProducto = {2}"
                    , p_detalle.Cantidad,p_detalle.Compra.IdCompra,p_detalle.Producto.IdProducto);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = cone;
                if (cone.State != System.Data.ConnectionState.Open)
                {
                    cone.Open();
                }
                resp = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Logg.Mensaje(ex.Message);
                if (cone.State != System.Data.ConnectionState.Closed) { cone.Close(); };
                return 0;
            }

            return resp;
        }
    }
}
