using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace HolaMundo.Models
{
    public class Contacto
    {
        public string imagen { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }

        [PrimaryKey]
        public string cedula { get; set; }

        //Credenciales
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}