using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wcfEmisionCertificadoCC.Entidades
{
    public class clsDatosCertificadoBE
    {
        public Int64 Idtramite { get; set; }
        public int IdGrupoBeneficio { get; set; }
        public int IdTipoFormularioCalculo { get; set; }
        public int NoFormularioCalculo { get; set; }
        public int IdTipoCC { get; set; }
        public int NroCertificado { get; set; }
        public string FechaEmision { get; set; }
        public int IdOficinaEmisionCC { get; set; }
        public int IdUsuarioEmision { get; set; }
        public string FechaImpresionCC { get; set; }
        public int IdUsuarioImpresion { get; set; }
        public int CertificadoActivo { get; set; }
        public int RegistroAPS { get; set; }
        public int IdEnvioAltaAPS { get; set; }
        public int CursoPago { get; set; }
        public int NroCertificadoReemplazo { get; set; }
        public int IdEstado { get; set; }
        public int RegistroActivo { get; set; }
    }
}