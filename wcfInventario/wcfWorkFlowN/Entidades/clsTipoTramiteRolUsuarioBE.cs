using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wcfWorkFlowN.Entidades {

    public class clsTipoTramiteRolUsuarioBE  : clsWorkflowBaseBE {

        public string sIdTipoTramite { get; set; }
        public Int32 iIdRol { get; set; }
        public Int32 iIdUsuario { get; set; }
        public Int32 iIdUsuarioSuperior { get; set; }
        public string sEstado { get; set; }

    }

}