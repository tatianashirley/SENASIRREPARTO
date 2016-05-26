using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wcfWorkFlowN.Entidades {
    public class clsTransicionMasivaDetBE : clsWorkflowBaseBE {

        public Int32 iIdTransicionMsva {get; set;}
        public Int16 iSecuencia {get; set;}
        public Int64 iIdInstanciaEjecucion {get; set;}
        public Int32 iSecuenciaEjecucion {get; set;}
        public Int32 iIdFlujo {get; set;}
        public Int16 iIdNodo  {get; set;}
        public byte iNivelOficina {get; set;}
        public Int32 iIdOficina {get; set;}
        public Int32 iIdArea {get; set;}
        public Int32 iIdRol {get; set;}
        public Int32 iIdUsuario {get; set;}
        public Int32 iIdNodoPred  {get; set;}
        public string sNemoNodoOrig  {get; set;}
        public string sNemoNodoDest { get; set; }

        public List <string> Lista = new List<string>();

    }
}