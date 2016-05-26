using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;

namespace wcfEnvioAPS.Entidades
{
    public class clsGeneraEnviosBE : clsEnvioAPSbaseBE
    {
        #region "Declaración de variables/Propiedades de GeneraMedios Nivel lógico"
        public string fFechaCorte { get; set; }
        public string sNumeroResolucionA { get; set; }
        public string fFechaResolucionA { get; set; }
        public string sNumeroResolucionM { get; set; }
        public string fFechaResolucionM { get; set; }
        public string sLoteCertificados { get; set; }
        public string sNumeroEnvio { get; set; }
        public int iFila { get; set; }
        #endregion
    }
}