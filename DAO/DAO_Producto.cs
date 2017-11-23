using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Modelo;
using MySql.Data.MySqlClient;

namespace DAO
{
    public class DAO_Producto
    {
        private MySqlConnection cone;

        public DAO_Producto()
        {
            cone = new CL_Conexion().obtenerConexion();
        }

        public List<CL_Producto> listarProductos()
        {
            List<CL_Producto> lista = new List<CL_Producto>();
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "SELECT * FROM PRODUCTO";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = cone;
                if (cone.State != System.Data.ConnectionState.Open)
                {
                    cone.Open();
                }
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    CL_Producto aux_producto = new CL_Producto();
                    aux_producto.IdProducto = Convert.ToInt32(dr["idProducto"].ToString());
                    aux_producto.NombreProducto = dr["NombreProducto"].ToString();
                    aux_producto.PrecioProducto =Convert.ToInt32(dr["PrecioProducto"].ToString());
                    aux_producto.EsCombo = dr["EsCombo"].ToString();
                    aux_producto.Stock = Convert.ToInt32(dr["stock"].ToString());
                    aux_producto.DiaCombo = dr["DiaCombo"].ToString();
                    aux_producto.Habilitado = dr["habilitado"].ToString();
                    lista.Add(aux_producto);
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

        public int agregarProducto(CL_Producto p_prod)
        {
            int resp = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = string.Format("INSERT INTO PRODUCTO(NombreProducto,PrecioProducto,EsCombo,DiaCombo,stock,habilitado)"
                    +" VALUES('{0}',{1},'{2}','{3}',{4},'{5}')"
                    ,p_prod.NombreProducto,p_prod.PrecioProducto,p_prod.EsCombo,p_prod.DiaCombo,p_prod.Stock,p_prod.Habilitado);
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

        public int actualizarProducto(CL_Producto p_pro)
        {
            int resp = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = string.Format("UPDATE PRODUCTO SET NombreProducto = '{0}'" 
                    +", PrecioProducto={1} , EsCombo ='{2}' , DiaCombo = '{3}' , stock={4} ,habilitado = '{5}' WHERE idProducto = {6}"
                    ,p_pro.NombreProducto,p_pro.PrecioProducto,p_pro.EsCombo,p_pro.DiaCombo,p_pro.Stock,p_pro.Habilitado,p_pro.IdProducto);
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

        public int eliminarProducto(int id)
        {
            int resp = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "UPDATE PRODUCTO SET habilitado = 'NOHABILITADO' WHERE idProducto =" + id + "";
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
