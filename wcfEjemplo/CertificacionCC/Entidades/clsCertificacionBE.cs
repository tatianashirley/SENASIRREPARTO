using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wcfEjemplo.CertificacionCC.Entidades
{
    public class clsCertificacionBE
    {
        public int IdTramite { get; set; }
        public int IdGrupoBeneficio { get; set; }
        public DateTime FechaAfiliacion { get; set; }
        public DateTime FechaBajaAfilia { get; set; }
        public decimal SalarioCotizableT { get; set; }
        public int CampoAplicacionCerti { get; set; }
        public int idUsuarioRegistro { get; set; }
        public Int64 RUC { get; set; }
        public int IdTipoDocSalario { get; set; }
        public DateTime PeriodoSalario { get; set; }
        public decimal SalarioCotizable { get; set; }
        public int IdEstadoSalario { get; set; }
        public int IdTipoCertificaSalarioCotizable { get; set; }
        public string mensaje { get; set; }
        public int retorno_proc { get; set; }

    }
}