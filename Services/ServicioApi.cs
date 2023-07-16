using HolaMundo.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HolaMundo.Services
{
    public class ServicioApi : IServicioApi
    {

        private static string _baseUrl;

        public ServicioApi()
        {
           _baseUrl = "https://apiwatchshoptest.azurewebsites.net/";
        }

        //Contacto
        public async Task<List<Contacto>> ListarContactos()
        {
            List<Contacto> productos = new List<Contacto>();
            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var response = await cliente.GetAsync("/api/v1/contacto");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ResultadoApi>(json_response);
                productos = resultado.listaContactos;
            }
            return productos;
        }

        public async Task<Contacto> ObtenerContacto(string cedula)
        {
            Contacto producto = new Contacto();
            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var response = await cliente.GetAsync($"/api/v1/contacto/{cedula}");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ResultadoApi>(json_response);
                producto = resultado.contacto;
            }
            return producto;
        }

        public async Task<string> GuardarContacto(Contacto contacto)
        {
            string httpsResponseCode = HttpStatusCode.BadRequest.ToString();
            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var content = new StringContent(JsonConvert.SerializeObject(contacto), Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync("/api/v1/contacto/", content);
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ResultadoApi>(json_response);
                httpsResponseCode = resultado.httpResponseCode;
            }
            return httpsResponseCode;
        }

        public async Task<string> BorrarContacto(string cedula)
        {
            string httpsResponseCode = HttpStatusCode.BadRequest.ToString();
            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var response = await cliente.DeleteAsync($"/api/v1/contacto/{cedula}");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ResultadoApi>(json_response);
                httpsResponseCode = resultado.httpResponseCode;
            }
            return httpsResponseCode;
        }

        public async Task<string> EditarContacto(string cedula, Contacto contacto)
        {
            string httpsResponseCode = HttpStatusCode.BadRequest.ToString();
            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var content = new StringContent(JsonConvert.SerializeObject(contacto), Encoding.UTF8, "application/json");
            var response = await cliente.PutAsync($"/api/v1/contacto/{cedula}", content);
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ResultadoApi>(json_response);
                httpsResponseCode = resultado.httpResponseCode;
            }
            return httpsResponseCode;
        }


        //Producto
        public async Task<List<Producto>> ListarProductos()
        {
            List<Producto> productos = new List<Producto>();
            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var response = await cliente.GetAsync("/api/v1/petshop");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ResultadoApi>(json_response);
                productos = resultado.listaProductos;
            }
            return productos;
        }


        public async Task<Producto> ObtenerProducto(string codeNumber)
        {
            Producto producto = new Producto();
            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var response = await cliente.GetAsync($"/api/v1/petshop/{codeNumber}");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ResultadoApi>(json_response);
                producto = resultado.producto;
            }
            return producto;
        }

        public async Task<string> GuardarProducto(Producto producto)
        {
            string httpsResponseCode = HttpStatusCode.BadRequest.ToString();
            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var content = new StringContent(JsonConvert.SerializeObject(producto), Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync("/api/v1/petshop/", content);
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ResultadoApi>(json_response);
                httpsResponseCode = resultado.httpResponseCode;
            }
            return httpsResponseCode;
        }


        //ClienteCompra
        public async Task<List<ClienteCompra>> ListarClienteCompras()
        {
            List<ClienteCompra> productos = new List<ClienteCompra>();
            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var response = await cliente.GetAsync("/api/v1/clientecompras");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ResultadoApi>(json_response);
                productos = resultado.listaClienteCompras;
            }
            return productos;
        }

        public async Task<ClienteCompra> ObtenerClienteCompra(string codigoCompra)
        {
            ClienteCompra clienteCompra = new ClienteCompra();
            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var response = await cliente.GetAsync($"/api/v1/clientecompras/{codigoCompra}");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ResultadoApi>(json_response);
                clienteCompra = resultado.clienteCompra;
            }
            return clienteCompra;
        }

        public async Task<string> GuardarClienteCompra(ClienteCompra clienteCompra)
        {
            string httpsResponseCode = HttpStatusCode.BadRequest.ToString();
            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var content = new StringContent(JsonConvert.SerializeObject(clienteCompra), Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync("/api/v1/clientecompras/", content);
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ResultadoApi>(json_response);
                httpsResponseCode = resultado.httpResponseCode;
            }
            return httpsResponseCode;
        }
    }
}
