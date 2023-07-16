using SQLite;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HolaMundo.Models
{
    public class ClienteCompra
    {
        //public int idCliente { get; set; }
        public string nombreCliente { get; set; }
        public string valorCompra { get; set; }

        [PrimaryKey]
        public string codigoCompra { get; set; }

        public string cedula { get; set; }
    }
}
