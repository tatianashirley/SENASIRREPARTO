using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;

namespace wcfEnvioAPS.Datos
{
    public class clsEnvioAPSBaseDA
    {
        #region "Declaración de variables/Propiedades basicas de seguridad y autenticación"

        public Int64 iIdConexion { get; set; }
        public string sOperacion { get; set; }
        public Int64 iSesionTrabajo { get; set; }
        public string sSSN { get; set; }
        public string sMensajeError { get; set; }

        public DataSet DSet { get; set; }
        #endregion
    }
}