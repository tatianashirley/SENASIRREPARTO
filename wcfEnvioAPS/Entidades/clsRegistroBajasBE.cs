using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wcfEnvioAPS.Entidades
{
    public class clsRegistroBajasBE : clsEnvioAPSbaseBE
    {
        #region "Declaración de variables/Propiedades de GeneraMedios Nivel lógico"
        public Int32 iNroCertificado { get; set; }
        public Int32 iIdTipoTramite { get; set; }
        public Int64 iNUP { get; set; }
        public string sNumeroResolucionA { get; set; }
        public string fFechaResolucionA { get; set; }
        public string mensaje { get; set; }
        public Boolean bAprueba { get; set; }
        #endregion
    }
}