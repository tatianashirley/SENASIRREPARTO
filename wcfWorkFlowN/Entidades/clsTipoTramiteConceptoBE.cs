using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wcfWorkFlowN.Entidades {

    public class clsTipoTramiteConceptoBE : clsWorkflowBaseBE {

        public string sIdTipoTramite {get; set;}
        public string sIdConcepto {get; set;}
        public Int16 iOrden {get; set;}
        public Boolean bFlagSolicitud {get; set;}
        public Boolean bFlagModificable {get; set;}
        public Boolean bFlagObligatorio {get; set;}
        public Boolean bFlagDeterminaFlujo {get; set;}
        public Int32? iValorInt {get; set;}
        public Decimal? mValorMoney {get; set;}
        public Double? dValorFloat {get; set;}
        public String sValorChar {get; set;}
        public DateTime? fValorDate {get; set;}
        public Int32? iValorCatalog {get; set;}
        public Boolean? bValorBoolean { get; set; }

    }

}