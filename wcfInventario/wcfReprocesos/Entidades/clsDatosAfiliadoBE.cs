using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wcfReprocesos.Entidades
{
    public class clsDatosAfiliadoBE : clsReprocesosBaseBE
    {
        #region "Declaración de variables/Propiedades de GeneraMedios Nivel lógico"
        public Int32 iPageIndex { get; set; }
        public Int32 iPageSize { get; set; }
        public Int32 iRecordCount { get; set; }
        public Int64 iIdTramite { get; set; }
        public Int32 iIdGrupoBeneficio { get; set; }
        public Int32 iIdTipoTramite { get; set; }
        public String sPrimerApellido { get; set; }
        public String sSegundoApellido { get; set; }
        public Int64 iNUP { get; set; }
        public Int32 iNroCertificado { get; set; }
        public DateTime fFechaCalc { get; set; }
        #endregion
    }
}