using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wcfEmisionCertificadoCC.Entidades
{
    public class clsTipoCambioBE
    {
        public DateTime Fecha { get; set; }
        public string Periodo { get; set; }
        public int IdMoneda { get; set; }
        public string Moneda { get; set; }
        public string Resolucion { get; set; }
        public string FechaResolucion { get; set; }
        public string TasaCambio { get; set; }
        public int RegistroActivo { get; set; }
        public int existedatos { get; set; }
   }
}