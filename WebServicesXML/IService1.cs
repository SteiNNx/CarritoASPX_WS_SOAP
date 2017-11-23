using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

using Modelo;

namespace WebServicesXML
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
    {
        //Metodos Abstractos USUARIO
        [OperationContract]
        bool usuarioGrabarXML(string xmlUsuario);
        [OperationContract]
        bool usuarioActualizarXML(string xmlUsuario);
        [OperationContract]
        List<CL_Usuario> usuarioListar();
        [OperationContract]
        bool usuarioEliminar(int cod);
        [OperationContract]
        CL_Usuario usuarioLogin(string user,string password);
        [OperationContract]
        List<string> locales();

        //Metodos Abstractos COMPRA
        [OperationContract]
        bool compraAgregar(string xmlCompra);
        [OperationContract]
        bool compraActualizar(string xmlCompra);
        [OperationContract]
        List<CL_Compra> compraListar();


        //Metodos Abstractos DetalleCompra
        [OperationContract]
        bool detalleCompraAgregar(string xmlDetalleCompra);
        [OperationContract]
        bool detalleCompraActualizar(string xmlDetalleCompra);
        [OperationContract]
        List<CL_DetalleCompra> detalleCompraListar();

        //Metodos Abstractos Productos
        [OperationContract]
        List<CL_Producto> productoListar();
        [OperationContract]
        bool productoAgregar(string xmlProducto);
        [OperationContract]
        bool productoActualizar(string xmlProducto);
    }

}
