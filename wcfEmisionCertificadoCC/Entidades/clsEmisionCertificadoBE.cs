using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wcfEmisionCertificadoCC.Entidades
{
    public class clsEmisionCertificadoBE
    {
        public Int64 Idtramite { get; set; }
        public int IdGrupoBeneficio { get; set; }
        public int IdTipoFormularioCalculo { get; set; }
        public int NoFormularioCalculo { get; set; } 
        public int IdTipoCC { get; set; }
        public int IdTipoCertificado{ get; set; }
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
        public int existedatos { get; set; }
        public string nuevovalor { get; set; }
        public Int32 iNroCertificadoReemplazo { get; set; }
    }
    
    public class clsFormularioCalculoCCBE   
    {
        public Int64 Idtramite { get; set; }
        public int IdGrupoBeneficio { get; set; }
        public string DescripcionGrupoBeneficio { get; set; }
        public int NoFormularioCalculo { get; set; }
        public int IdTipoFormularioCalculo { get; set; }
        public string DescripcionTipoFormulario { get; set; }
         public int IdTipoCC { get; set; }
         public string TipoCC { get; set; }
         public int IdTipoTramite { get; set; }
        public int NoResolucionCCR { get; set; }
        public decimal MontoCC { get; set; }
        public string FechaGeneracion { get; set; }  
        public int IdUsuarioGeneracion { get; set; }
        public string FechaNotificacion { get; set; }
        public int IdUsuarioNotificacion { get; set; }
        public decimal MontoCCAceptado { get; set; }
        public string FechaAceptacion { get; set; }  
        public int IdUsuarioAceptacion { get; set; }
        public string FechaRevRR { get; set; }
        public int IdUsuarioRevRR { get; set; }
        public string Observaciones { get; set; }
        public int EstadoCalculoCC { get; set; }
        public int RegistroActivo { get; set; }
        public int IdEstado { get; set;}
    }
    public class clsComponenteCCBE
    {
        public Int64 Idtramite { get; set; }
        public int IdGrupoBeneficio { get; set; }
        public int NoComponente { get; set; }
        public int NoVersionComponente { get; set; }
       public decimal DensidadAportes { get; set; }
        public int EstadoComponente { get; set; }
        public int RegistroActivo { get; set; }
    }
    public class clsDatosPersonaBE
    {
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string ci { get; set; }
        public string cua { get; set; }
        public string fechanac { get; set; }
    }
    public class clsReporteCertificadoCCBE
    {
        public Int64 Idtramite { get; set; }
        public int IdGrupoBeneficio { get; set; }

        public int IdTipoFormularioCalculo { get; set; }
        public int IdTipoCC { get; set; }
        public int NroCertificado { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string ci { get; set; }
        public string cua { get; set; }
        public DateTime fechanac { get; set; }

        public decimal tasacambio { get; set; }
        public int resolucion { get; set; }

        public decimal densidadAportes { get; set; }
        public decimal monto { get; set; }
        public string montoliteral { get; set; }

        public string departamento  { get; set; }

        public string FechaEmision { get; set; }
        public int IdUsuario { get; set; }

        public DateTime hora { get; set; }
    }
    
}