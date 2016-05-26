using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wcfReprocesos.Entidades
{
    public class clsRM266BE : clsReprocesosBaseBE
    {
        #region "Declaración de variables/Propiedades de GeneraMedios Nivel lógico"
        public Int32 iNroFormularioRepro { get; set; }
        public String iNumeroResolucion { get; set; }
        public DateTime? fFechaResolucion { get; set; }
        public DateTime fFechaNacimientoNueva { get; set; }
        public String sMatriculaNueva { get; set; }
        public Int32 iRes { get; set; }
        public Int64 iNUP { get; set; }
        public Boolean bRegistroAPS { get; set; }
        public Int64 iIdTramite { get; set; }
        public Int32 iIdTipoTramite { get; set; }
        public Int32 iIdGrupoBeneficio { get; set; }
        public Int32 iIdOficina { get; set; }
        public Int32 iIdOficinaArea { get; set; }
        public Int32 iNroAsignacion { get; set; }
        public Int32 iIdUsuario { get; set; }
        public Int32 iNoFormularioCalculo { get; set; }
        public Int32 iIdTipoFormularioCalculo { get; set; }
        public Int32 iNroCertificado { get; set; }
        public Int32 iNuevoNumeroCertificado { get; set; }
        #endregion
    }
}