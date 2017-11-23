using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAO;
using Modelo;

namespace TestConsola
{
    class Program
    {
        static void Main(string[] args)
        {

            DAO_DetalleCompra dao = new DAO_DetalleCompra();
            foreach (CL_DetalleCompra item in dao.listarDetalleCompra())
            {
                Console.WriteLine("Usuario: " + item.Compra.UsuarioCompra.Nombre);
                Console.WriteLine("Compra fecha: " + item.Compra.FechaCompra);
                Console.WriteLine("Producto: "+item.Producto.NombreProducto);
                Console.WriteLine("Cantidad: " + item.Cantidad);
            }
            Console.ReadKey();
        }
    }
}
