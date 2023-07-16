using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;


namespace HolaMundo.Models
{
    public class Producto
    {
        public string price { get; set; }
        public string quantity { get; set; }
        public string picture { get; set; }
        public string name { get; set; }

        public string codeNumber { get; set; }
    }
}
