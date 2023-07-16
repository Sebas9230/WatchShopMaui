using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolaMundo.Models
{
    internal class ResultadoApi
    {
        public string httpResponseCode { get; set; }

        public List<Producto> listaProductos { get; set; }

        public Producto producto { get; set; }

        public List<Contacto> listaContactos { get; set; }

        public Contacto contacto { get; set; }

        public List<ClienteCompra> listaClienteCompras { get; set; }

        public ClienteCompra clienteCompra { get; set; }
    }
}
