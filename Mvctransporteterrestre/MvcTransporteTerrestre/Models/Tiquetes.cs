using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvctransporteterrestre.Models
{
    public class Tiquetes
    {
        public string IdTiquete { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public string Fecha { get; set; }
        public decimal Precio { get; set; }
        public Int64 Cantidad { get; set; }
        public decimal Subtotal { get; set; }

    }
}