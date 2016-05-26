using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wcfWorkFlowN.Entidades {

    public class clsFlujoNodoPredecesorBE : clsWorkflowBaseBE {

        public Int32 iIdFlujo {get; set;}
        public Int16 iIdNodoPred {get; set;}
        public Int16 iIdNodo {get; set;}
        public Int32 iIdGrupoRestriccion {get; set;}
        public Boolean bFLagGeneraCbteRspldo {get; set;}
        public Boolean bFlagImrimeCbteRspldo {get; set;}
        public Boolean bFlagTransicionMasiva {get; set;}
        public Int16 iNodoParalelo {get; set;}
        public String sReglaNodoParalelo {get; set;}
        public Boolean bFlagManual {get; set;}
        public Boolean bFlagAlerta {get; set;}
        public String sMensajeAlerta { get; set;}
        public Boolean bFlagAnonimo { get; set;}
        public Boolean bFlagRetroceso { get; set; }
        public Boolean bFlagUsuarioActual { get; set; }
        public String sDescripcion { get; set; }

    }

}