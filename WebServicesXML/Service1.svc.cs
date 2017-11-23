using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;



using System.Xml.Serialization;
using Modelo;
using DAO;
using System.IO;
using System.Xml;

namespace WebServicesXML
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {

        #region WebServices Usuario
        public bool usuarioGrabarXML(string xmlUsuario)
        {
            try
            {
                CL_Usuario aux_user = DeserializeUsuario<CL_Usuario>(xmlUsuario);
                DAO_Usuario dao_user = new DAO_Usuario();
                int resp = dao_user.agregarUsuario(aux_user);
                if (resp > 0) { return true; } else { return false; }
            }
            catch (Exception ex)
            {
                Logg.Mensaje(ex.Message);
                return false;
            }
        }


        public bool usuarioActualizarXML(string xmlUsuario)
        {
            try
            {
                CL_Usuario aux_user = DeserializeUsuario<CL_Usuario>(xmlUsuario);
                DAO_Usuario dao_user = new DAO_Usuario();
                int resp = dao_user.actualizarUsuario(aux_user);
                if (resp > 0) { return true; } else { return false; }
            }
            catch (Exception ex)
            {
                Logg.Mensaje(ex.Message);
                return false;
            }
        }



        public List<CL_Usuario> usuarioListar()
        {
            try
            {
                DAO_Usuario dao_user = new DAO_Usuario();
                return dao_user.listarUsuarios();
            }
            catch (Exception ex)
            {
                Logg.Mensaje(ex.Message);
                return null;
            }
        }
        public CL_Usuario usuarioLogin(string p_user, string p_password)
        {
            try
            {
                DAO_Usuario dao_us = new DAO_Usuario();

                CL_Usuario user = null;
                user = dao_us.listarUsuarios().Where(x => x.User == p_user && x.Password == p_password).First();
                return user;
            }
            catch (Exception ex)
            {
                Logg.Mensaje(ex.Message);
                return null;
            }
        }

        public bool usuarioEliminar(int cod)
        {
            try
            {
                DAO_Usuario dao_user = new DAO_Usuario();
                int resp = dao_user.eliminarUsuario(cod);
                if (resp > 0) { return true; } else { return false; }
            }
            catch (Exception ex)
            {
                Logg.Mensaje(ex.Message);
                return false;
            }
        }
        public List<string> locales()
        {
            DAO_Usuario dao = new DAO_Usuario() ;
            return dao.obtenerLocales();
        }
        #endregion

        #region WebServices Compra
        public bool compraAgregar(string xmlCompra)
        {
            try
            {
                CL_Compra aux_user = DeserializeCompra<CL_Compra>(xmlCompra);
                DAO_Compra dao_user = new DAO_Compra();
                int resp = dao_user.agregarCompra(aux_user);
                if (resp > 0) { return true; } else { return false; }
            }
            catch (Exception ex)
            {
                Logg.Mensaje(ex.Message);
                return false;
            }
        }

        public bool compraActualizar(string xmlCompra)
        {
            try
            {
                CL_Compra aux_user = DeserializeCompra<CL_Compra>(xmlCompra);
                DAO_Compra dao_user = new DAO_Compra();
                int resp = dao_user.actualizarCompra(aux_user);
                if (resp > 0) { return true; } else { return false; }
            }
            catch (Exception ex)
            {
                Logg.Mensaje(ex.Message);
                return false;
            }
        }

        public List<CL_Compra> compraListar()
        {
            try
            {
                DAO_Compra dao_user = new DAO_Compra();
                return dao_user.listarCompra();
            }
            catch (Exception ex)
            {
                Logg.Mensaje(ex.Message);
                return null;
            }
        }
        #endregion

        #region WebServices DetalleCompra
        public bool detalleCompraAgregar(string xmlDetalleCompra)
        {
            try
            {
                CL_DetalleCompra aux_user = DeserializeDetalleCompra<CL_DetalleCompra>(xmlDetalleCompra);
                DAO_DetalleCompra dao_user = new DAO_DetalleCompra();
                int resp = dao_user.agregarDetalleCompra(aux_user);
                if (resp > 0) { return true; } else { return false; }
            }
            catch (Exception ex)
            {
                Logg.Mensaje(ex.Message);
                return false;
            }
        }

        public bool detalleCompraActualizar(string xmlDetalleCompra)
        {
            try
            {
                CL_DetalleCompra aux_user = DeserializeDetalleCompra<CL_DetalleCompra>(xmlDetalleCompra);
                DAO_DetalleCompra dao_user = new DAO_DetalleCompra();
                int resp = dao_user.agregarDetalleCompra(aux_user);
                if (resp > 0) { return true; } else { return false; }
            }
            catch (Exception ex)
            {
                Logg.Mensaje(ex.Message);
                return false;
            }
        }

        public List<CL_DetalleCompra> detalleCompraListar()
        {
            try
            {
                DAO_DetalleCompra dao_user = new DAO_DetalleCompra();
                return dao_user.listarDetalleCompra();
            }
            catch (Exception ex)
            {
                Logg.Mensaje(ex.Message);
                return null;
            }
        }
        #endregion

        #region WebServices Producto

        public List<CL_Producto> productoListar()
        {
            DAO_Producto dao_pro = new DAO_Producto();
            return dao_pro.listarProductos();
        }

        public bool productoAgregar(string xmlProducto)
        {
            try
            {
                CL_Producto produc = DeserializeProducto<CL_Producto>(xmlProducto);
                DAO_Producto dao = new DAO_Producto();
                int resp = dao.agregarProducto(produc);
                if (resp > 0) { return true; } else { return false; }
            }
            catch (Exception ex)
            {
                Logg.Mensaje(ex.Message);
                return false;
            }

        }

        public bool productoActualizar(string xmlProducto)
        {
            try
            {
                CL_Producto produc = DeserializeProducto<CL_Producto>(xmlProducto);
                DAO_Producto dao = new DAO_Producto();
                int resp = dao.actualizarProducto(produc);
                if (resp > 0) { return true; } else { return false; }
            }
            catch (Exception ex)
            {
                Logg.Mensaje(ex.Message);
                return false;
            }
        }
        #endregion

        //Metodo Para Deserializar un xml y Convertirlo a objeto Usuario
        public static CL_Usuario DeserializeUsuario<CL_Usuario>(string xml)
        {

            if (string.IsNullOrEmpty(xml))
            {
                return default(CL_Usuario);
            }

            XmlSerializer serializer = new XmlSerializer(typeof(CL_Usuario));

            XmlReaderSettings settings = new XmlReaderSettings();
            // No settings need modifying here

            using (StringReader textReader = new StringReader(xml))
            {
                using (XmlReader xmlReader = XmlReader.Create(textReader, settings))
                {
                    return (CL_Usuario)serializer.Deserialize(xmlReader);
                }
            }
        }
        //Metodo Para Deserializar un xml y Convertirlo a objeto Compra
        public static CL_Compra DeserializeCompra<CL_Compra>(string xml)
        {

            if (string.IsNullOrEmpty(xml))
            {
                return default(CL_Compra);
            }

            XmlSerializer serializer = new XmlSerializer(typeof(CL_Compra));

            XmlReaderSettings settings = new XmlReaderSettings();
            // No settings need modifying here

            using (StringReader textReader = new StringReader(xml))
            {
                using (XmlReader xmlReader = XmlReader.Create(textReader, settings))
                {
                    return (CL_Compra)serializer.Deserialize(xmlReader);
                }
            }
        }
        //Metodo Para Deserializar un xml y Convertirlo a objeto DetalleCompra
        public static CL_DetalleCompra DeserializeDetalleCompra<CL_DetalleCompra>(string xml)
        {

            if (string.IsNullOrEmpty(xml))
            {
                return default(CL_DetalleCompra);
            }

            XmlSerializer serializer = new XmlSerializer(typeof(CL_DetalleCompra));

            XmlReaderSettings settings = new XmlReaderSettings();
            // No settings need modifying here

            using (StringReader textReader = new StringReader(xml))
            {
                using (XmlReader xmlReader = XmlReader.Create(textReader, settings))
                {
                    return (CL_DetalleCompra)serializer.Deserialize(xmlReader);
                }
            }
        }
        //Metodo Para Deserializar un xml y Convertirlo a objeto DetalleCompra
        public static CL_Producto DeserializeProducto<CL_Producto>(string xml)
        {

            if (string.IsNullOrEmpty(xml))
            {
                return default(CL_Producto);
            }

            XmlSerializer serializer = new XmlSerializer(typeof(CL_Producto));

            XmlReaderSettings settings = new XmlReaderSettings();
            // No settings need modifying here

            using (StringReader textReader = new StringReader(xml))
            {
                using (XmlReader xmlReader = XmlReader.Create(textReader, settings))
                {
                    return (CL_Producto)serializer.Deserialize(xmlReader);
                }
            }
        }

        
    }
}
