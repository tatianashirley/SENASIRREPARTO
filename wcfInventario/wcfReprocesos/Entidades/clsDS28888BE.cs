using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wcfReprocesos.Entidades
{
    public class clsDS28888BE : clsReprocesosBaseBE
    {
        #region "Declaración de variables/Propiedades de GeneraMedios Nivel lógico"
        public Int64 iIdTramite { get; set; }
        public Int32 iIdTipoTramite { get; set; }
        public Int32 iIdGrupoBeneficio { get; set; }
        public Int64 iNUP { get; set; }
        public Int32 iNroCertificado { get; set; }
        public DateTime fFechaCalc { get; set; }
        public Int32 iIdUsuario { get; set; }
        public Int32 iNroFormularioRepro { get; set; }
        #endregion
    }
}