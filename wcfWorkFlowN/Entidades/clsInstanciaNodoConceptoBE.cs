using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfWorkFlowN.Entidades;
using wcfWorkFlowN.Datos;

namespace wcfWorkFlowN.Entidades {
    public class clsInstanciaNodoConceptoBE : clsWorkflowBaseBE {

        public Int64 iIdInstancia { get; set; }
        public Int32 iSecuencia { get; set; }
        public Int32 iIdHisInstancia { get; set; }
        public Int32 iIdFlujo { get; set; }
        public Int16 iIdNodo { get; set; }
        public String sIdConcepto { get; set; }
        public string sComentarios { get; set; }
        public Int32? iValorInt { get; set; }
        public Decimal? mValorMoney { get; set; }
        public Double? dValorFloat { get; set; }
        public String sValorChar { get; set; }
        public DateTime? fValorDate { get; set; }
        public Int32? iValorCatalog { get; set; }
        public Boolean? bValorBoolean { get; set; }

        public String sTipoDato { get; set; }

        public String sValorGenerico0 = "SINASIGNAR"; 

        public String sValorGenerico {
            get { return sValorGenerico0; }
            set { sValorGenerico0 = value; }
        }

    }
}