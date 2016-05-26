using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;

namespace wcfEnvioAPS.Entidades
{
    public class clsControlEnviosBE : clsEnvioAPSbaseBE
    {
        #region "Declaración de variables/Propiedades de GeneraMedios Nivel lógico"
        public String sNumeroEnvio { get; set; }
        public DateTime fFechaCorte { get; set; }
        public Int32 iIdEntidad { get; set; }
        public Int32 iNumeroCite { get; set; }
        public DateTime fFechaCite { get; set; }
        public DateTime fFechaRecepcion { get; set; }
        #endregion
    }
}