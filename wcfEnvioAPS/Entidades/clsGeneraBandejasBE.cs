using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;

namespace wcfEnvioAPS.Entidades
{
    public class clsGeneraBandejasBE : clsEnvioAPSbaseBE
    {
        #region "Declaración de variables/Propiedades de GeneraMedios Nivel lógico"
        public DateTime fFechaCorte { get; set; }
        public Int32 iPageIndex { get; set; }
        public Int32 iPageSize { get; set; }
        public Int32 iRecordCountA { get; set; }
        public Int32 iRecordCount { get; set; }
        public String cClaseEnvio { get; set; }
        public String sOrderBy { get; set; }
        #endregion
    }
}