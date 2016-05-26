using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wcfWorkFlowN.Entidades
{

    public class clsHisRestriccionBE : clsWorkflowBaseBE
    {
        //public Int32 iIdHisInstancia { get; set; }
        public Int32 iIdRestriccion { get; set; }
        public string sDescripcion { get; set; }
        public string sIdConcepto { get; set; }
        public Int32 iIdTipoDocumento { get; set; }
        public string sTipoDato { get; set; }
        public string sComentarios { get; set; }
        public string sTipoRestriccion { get; set; }
        public Int32? iValor1Int { get; set; }
        public decimal? mValor1Money { get; set; }
        public double? dValor1Float { get; set; }
        public string sValor1Char { get; set; }
        public DateTime? fValor1Date { get; set; }
        public Int32? iValor1Catalog { get; set; }
        public Boolean? bValor1Bit { get; set; }
        public Int32? iValor2Int { get; set; }
        public decimal? mValor2Money { get; set; }
        public double? dValor2Float { get; set; }
        public DateTime? fValor2Date { get; set; }
        public Boolean bFlagNegacion { get; set; }
        public Int32 iIdRestriccionDesde { get; set; }
        public Int32 iIdRestriccionHasta { get; set; }
        public Int32 iIdHisInstancia { get; set; }

    }

}