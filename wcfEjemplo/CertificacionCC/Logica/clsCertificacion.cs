using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using wcfEjemplo.CertificacionCC.Datos;
using wcfEjemplo.CertificacionCC.Entidades;

namespace wcfEjemplo.CertificacionCC.Logica
{
    public class clsCertificacion : clsCertificacionBE
    {
        public string[] InicioAutomatico(Int64 IdTramite,int IdGrupoBeneficio,DateTime FechaAfiliacion,DateTime FechaBajaAfilia,decimal SalarioCotizableT,int CampoAplicacionCerti,
           int idUsuarioRegistro, Int64 RUC, int IdTipoDocSalario, string PeriodoSalario, decimal SalarioCotizable, int IdEstadoSalario, int IdTipoCertifica, int IdTipoCertificaSalarioCotizable)
        {
            clsCertificacionDA c = new clsCertificacionDA();
            string[] datos = new string[2];
            datos = c.InicioAutomatico(IdTramite, IdGrupoBeneficio, FechaAfiliacion, FechaBajaAfilia, SalarioCotizableT, CampoAplicacionCerti,
                                        idUsuarioRegistro, RUC, IdTipoDocSalario, PeriodoSalario, SalarioCotizable, IdEstadoSalario, IdTipoCertifica,
                                        IdTipoCertificaSalarioCotizable);
            return datos;
        }
    }
}