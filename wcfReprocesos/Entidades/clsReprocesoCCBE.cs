using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wcfReprocesos.Entidades
{
    public class clsReprocesoCCBE : clsReprocesosBaseBE
    {
        #region "Declaración de variables/Propiedades de GeneraMedios Nivel lógico"
        public String iNumeroResolucion { get; set; }
        public DateTime? iFechaResolucion { get; set; }
        public Int64 iIdTramite { get; set; }
        public String sIdTramite { get; set; }
        public Int64 iNUP { get; set; }
        public Int32 iIdTipoTramite { get; set; }
        public Int32 iIdGrupoBeneficio { get; set; }
        public Int32 iNoFormularioCalculo { get; set; }
        public DateTime? fFechaCalculo { get; set; }
        public Decimal dMontoCCAceptado { get; set; }
        public Decimal dSalarioCotizableActualizadoTotal { get; set; }
        public Decimal dDensidadTotal { get; set; }
        public Int32 iSIP_impresion { get; set; }
        public Boolean bRegistroAPS { get; set; }
        public Boolean bCursoPago { get; set; }
        public Int32 iIdUsuario { get; set; }
        public Int32 iNroCertificado { get; set; }
        public Int32 iIdTipoCC { get; set; }
        public Int32 iIdTipoReproceso { get; set; }
        public Int32 iIdEstadoReproceso { get; set; }
        public Int32 iIdEstadoTramite { get; set; }
        public String cCodigoReproceso { get; set; }
        public Int32 iNroFormularioRepro { get; set; }
        public Boolean bBandejaTrabajo { get; set; }
        #endregion
    }
}