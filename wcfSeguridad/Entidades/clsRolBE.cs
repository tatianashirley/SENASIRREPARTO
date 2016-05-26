using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wcfSeguridad.Entidades {

    public class clsRolBE {

        public Int32 iIdRol {get; set;}
        public String sDescripcion {get; set;}
        public String sSQLUser {get; set;}
        public Int32 iIdModulo {get; set;}
        public Int32 iIdEstado { get; set; }

    }

}