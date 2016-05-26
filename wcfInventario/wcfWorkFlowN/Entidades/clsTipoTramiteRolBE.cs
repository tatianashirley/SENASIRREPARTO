using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wcfWorkFlowN.Entidades {

    public class clsTipoTramiteRolBE  : clsWorkflowBaseBE {

        public string sIdTipoTramite { get; set; }
        public Int32 iIdRol { get; set; }
        public Int32 iIdRolSup { get; set; }
        public Byte iNivel { get; set; }
        public Boolean bFlagUnico { get; set; }

    }

}