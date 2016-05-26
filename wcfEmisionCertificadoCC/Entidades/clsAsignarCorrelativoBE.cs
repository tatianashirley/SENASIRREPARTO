using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wcfEmisionCertificadoCC.Entidades
{
    public class clsAsignarCorrelativoBE
    {
        public string EstadoStock { get; set; }
        public int NumeroAsignacion { get; set; }
        public int IdOficina { get; set; }
        public int IdTipoTramite { get; set; }
        public string Oficina { get; set; }
        public string TipoCertificado { get; set; }
        public string FechaAsignacion { get; set; }
        public string FechaEnvio { get; set; }
        public int NumeroInicial { get; set; }
        public int NumeroFinal { get; set; }
        public int UltimoNumeroAplicado { get; set; }
        public int Cantidad { get; set; }
        public string Observacion { get; set; }
        public int RegistroActivo { get; set; }
        public int existedatos { get; set; }
    }
    public class clsOficinaBE
    {
        public int IdOficina { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int FlagImprimeCC { get; set; }
    }
}
