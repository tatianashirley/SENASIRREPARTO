using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wcfEjemplo.Entidades
{
    public class clsTopeSalarialBE
    {
        public DateTime Fecha { get; set; }
        public decimal SalarioCotizable { get; set; }
        public decimal IdMoneda { get; set; }

        public string DescripcionDetalleClasificador { get; set; }
    }
}