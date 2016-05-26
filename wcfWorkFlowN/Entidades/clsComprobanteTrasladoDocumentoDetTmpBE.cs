using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wcfWorkFlowN.Entidades {

    public class clsComprobanteTrasladoDocumentoDetTmpBE : clsWorkflowBaseBE {

        public Int64 iSesion { get; set; }
        public Int64 iIdInstancia { get; set; }
        public Int32 iSecuencia { get; set; }
        public string sComentario { get; set; }
        public Boolean bFlagAceptacion { get; set; }
        public Int32 iIdUsuario { get; set; }

    }

}