using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wcfWorkFlowN.Entidades {

    public class clsFlujoNodoConceptoBE : clsWorkflowBaseBE {
        public Int32 iIdFlujo {get; set;}
        public Int16 iIdNodo {get; set;}
        public String sIdTipoTramite {get; set;}
        public String sIdConcepto {get; set;}
        public Boolean bFlagObligatorio {get; set;}
        public Boolean bFlagModificable {get; set;}
        public String sEstado {get; set;}
        public Int32? iValorInt { get; set; }
        public Decimal? mValorMoney { get; set; }
        public Double? dValorFloat { get; set; }
        public String sValorChar { get; set; }
        public DateTime? fValorDate { get; set; }
        public Int32? iValorCatalog { get; set; }
        public Boolean? bValorBoolean { get; set; }

    }

}