using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wcfEmisionCertificadoCC.Entidades
{
    public class clsStockCorrelativoBE
    {
        public int PartidaLote { get; set; }
        public string Fecha { get; set; }
        //public int IdTipoCertificado { get; set; }
        public int IdTipoCertificado { get; set; }
        public string Certificado { get; set; }
        public int NumeroInicial { get; set; }
        public int NumeroFinal { get; set; }
        public int Cantidad { get; set; }
        public int Saldo { get; set; }
        public string Observacion { get; set; }
        public int RegistroActivo { get; set; }
        public int existedatos { get; set; }
    }
}