using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wcfSeguridad.Entidades {

    public class clsRolUsuarioBE {
        public Int64 iIdConexion { get; set; }
        public string sOperacion { get; set; }
        public Int64 iSesionTrabajo { get; set; }
        public string sSSN { get; set; }
        public string sMensajeError { get; set; }

        public DataSet DSet { get; set; }

        public Int32 iIdRol { get; set; }
        public Int32 iIdUsuario { get; set; }
        public Int32 iIdOficina { get; set; }
        public DateTime fFechaVigencia { get; set; }
        public DateTime fFechaExpiracion { get; set; }
        public Int32 iIdEstado { get; set; }
        public Int32 iIdRolUsuario { get; set; }
    }

}