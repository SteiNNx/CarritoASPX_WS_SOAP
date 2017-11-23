using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Modelo;
using MySql.Data.MySqlClient;

namespace DAO
{
    public class DAO_Compra
    {
        private MySqlConnection cone;

        public DAO_Compra()
        {
            cone = new CL_Conexion().obtenerConexion();
        }

        public List<CL_Compra> listarCompra()
        {
            List<CL_Compra> lista = new List<CL_Compra>();
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "SELECT * FROM COMPRA P INNER JOIN USUARIO U ON(P.IDUSUARIO=U.IDUSUARIO)";
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
                    aux_compra.FechaCompra = Convert.ToDateTime(dr["fechaCompra"].ToString()).ToString("dd-MM-yyyy");
                    CL_Usuario aux_user = new CL_Usuario();
                    aux_user.IdUsuario = Convert.ToInt32(dr["idUsuario"].ToString());
                    aux_user.Nombre = dr["Nombre"].ToString();
                    aux_user.Apellido = dr["Apellido"].ToString();
                    aux_user.TipoUsuario = dr["TipoUsuario"].ToString();
                    aux_user.User = dr["user"].ToString();
                    aux_user.Local = dr["local"].ToString();
                    aux_user.Habilitado = dr["habilitado"].ToString();
                    aux_compra.UsuarioCompra = aux_user;
                    lista.Add(aux_compra);
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

        public int agregarCompra(CL_Compra p_compr)
        {
            int resp = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = string.Format("INSERT INTO COMPRA(fechaCompra,idUsuario)"
                    + " VALUES('{0}',{1})"
                    , p_compr.FechaCompra,p_compr.UsuarioCompra.IdUsuario);
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

        public int actualizarCompra(CL_Compra p_compr)
        {
            int resp = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = string.Format("UPDATE COMPRA SET fechaCompra = '{0}'"
                    + ", idUsuario={1} WHERE idCompra={2}"
                    , p_compr.FechaCompra,p_compr.UsuarioCompra.IdUsuario,p_compr.IdCompra);
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

        public int maxId()
        {
            int resp = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "SELECT max(idCompra) as MAX FROM compra ;";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = cone;
                if (cone.State != System.Data.ConnectionState.Open)
                {
                    cone.Open();
                }
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    resp = Convert.ToInt32(dr["MAX"].ToString());
                }
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
