using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;

namespace wcfWFArticulador.Datos
{
    public class clsWFArticuladorBaseDA
    {
        #region "Declaración de variables/Propiedades"

        public Int64 iIdConexion { get; set; }
        public string sOperacion { get; set; }
        public Int64 iSesionTrabajo { get; set; }
        public string sSSN { get; set; }
        public string sMensajeError { get; set; }
        public byte iNivelError { get; set; }

        public DataSet DSet { get; set; }
        public Int32 NroFilas { get; set; }

        #endregion
    }
}