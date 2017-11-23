using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Modelo;
using MySql.Data.MySqlClient;

namespace DAO
{
    public class DAO_Usuario
    {
        private MySqlConnection cone;

        public DAO_Usuario()
        {
            cone = new CL_Conexion().obtenerConexion();
        }

        public List<CL_Usuario> listarUsuarios()
        {
            List<CL_Usuario> lista = new List<CL_Usuario>();
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "SELECT * FROM USUARIO";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = cone;
                if (cone.State != System.Data.ConnectionState.Open)
                {
                    cone.Open();
                }
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    CL_Usuario aux_user = new CL_Usuario();
                    aux_user.IdUsuario = Convert.ToInt32(dr["idUsuario"].ToString());
                    aux_user.Nombre = dr["Nombre"].ToString();
                    aux_user.Apellido = dr["Apellido"].ToString();
                    aux_user.Password = dr["Password"].ToString();
                    aux_user.TipoUsuario = dr["TipoUsuario"].ToString();
                    aux_user.User = dr["user"].ToString();
                    aux_user.Local = dr["local"].ToString();
                    aux_user.Habilitado = dr["habilitado"].ToString();
                    lista.Add(aux_user);
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

        public int agregarUsuario(CL_Usuario p_user)
        {
            int resp = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "INSERT INTO USUARIO(Nombre,Apellido,Password,TipoUsuario,user,local,habilitado) "
                    + "VALUES('" + p_user.Nombre + "','"
                    + p_user.Apellido + "','"
                    + p_user.Password + "','"
                    + p_user.TipoUsuario + "','"
                    + p_user.User + "','"
                    + p_user.Local + "','HABILITADO'"
                    + ")";
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

        public int actualizarUsuario(CL_Usuario p_user)
        {
            int resp = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "UPDATE USUARIO SET Nombre='" + p_user.Nombre + "',"
                    + "Apellido = '" + p_user.Apellido + "',"
                    + "Password = '" + p_user.Password + "',"
                    + "TipoUsuario = '" + p_user.TipoUsuario + "', "
                    + "user = '" + p_user.User + "',"
                    + "local= '" + p_user.Local + "',"
                    + "habilitado='" + p_user.Habilitado + "'"
                    + "WHERE idUsuario =" + p_user.IdUsuario + "";
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

        public int eliminarUsuario(int id)
        {
            int resp = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "UPDATE USUARIO SET habilitado='DESHABILITADO' WHERE idUsuario =" + id + "";
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

        //SELECT DISTINCT(local) from usuario;

        public List<string> obtenerLocales()
        {
            List<string> lista = new List<string>();
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "SELECT DISTINCT(local) as local from usuario";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = cone;
                if (cone.State != System.Data.ConnectionState.Open)
                {
                    cone.Open();
                }
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string aux = "";
                    aux = dr["local"].ToString();
                    lista.Add(aux);
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
    }
}
