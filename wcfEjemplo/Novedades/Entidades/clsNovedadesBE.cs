using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace wcfEjemplo.Entidades
{
    public class clsNovedadesBE
    {
        public Int64 retorno_proc { get; set; }
		public string resultado_proc { get; set; }

        public Int64 IdTipoActualizacion { get; set; }
        public Int64 IdActualizacion { get; set; }
        public string CodigoActualizacion { get; set; }
        public string DescripcionActualizacion { get; set; }
        public string Descripcion { get; set; }
        public string FuncionarioRegistro { get; set; }
        public string FuncionarioAprobacion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public Int64 EstadoActualizacion { get; set; }
        public Int64 EstadoRegistro { get; set; }
        public string DescEstado { get; set; }
        public string Matricula { get; set; }
        public string Matricula_cys { get; set; }
        public string Tramite { get; set; }
        public string Certificado { get; set; }
        public string ClaseCC { get; set; }
        public string FechaEmision { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string CI { get; set; }
        public string NUA { get; set; }
        public string ComplementoSEGIP { get; set; }
        public string IdTipoDocumento { get; set; }
        public string IdDocumentoExpedido { get; set; }
        public string NumRa { get; set; }
        public string FechaRa { get; set; }
        public string fila { get; set; }
        public string FechaNac { get; set; }
        public string IdTipoCertificado { get; set; }
        public string TipoCertificado { get; set; }
        public string TipoBeneficio { get; set; }
        public string IdFuente { get; set; }
        public string IdSexo { get; set; }


    }
}