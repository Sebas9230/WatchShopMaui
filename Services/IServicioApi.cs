using HolaMundo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolaMundo.Services
{
    public interface IServicioApi
    {
        //Contacto
        public Task<List<Contacto>> ListarContactos();
        public Task<Contacto> ObtenerContacto(string cedula);
        public Task<string> GuardarContacto(Contacto contacto);
        public Task<string> EditarContacto(string cedula, Contacto contacto);
        public Task<string> BorrarContacto(string cedula);

        //Producto
        public Task<List<Producto>> ListarProductos();
        public Task<Producto> ObtenerProducto(string codeNumber);
        public Task<string> GuardarProducto(Producto producto);
        //public Task<string> EditarProducto(string codeNumber, Producto producto);
        //public Task<string> BorrarProducto(string codeNumber);


        ////ClienteCompra
        public Task<List<ClienteCompra>> ListarClienteCompras();
        public Task<ClienteCompra> ObtenerClienteCompra(string cedula);
        public Task<string> GuardarClienteCompra(ClienteCompra clienteCompra);
        //public Task<string> EditarClienteCompra(string cedula, ClienteCompra clienteCompra);
        //public Task<string> BorrarClienteCompra(string cedula);
    }
}
