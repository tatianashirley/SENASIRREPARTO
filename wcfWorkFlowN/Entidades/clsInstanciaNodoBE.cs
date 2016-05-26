using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfWorkFlowN.Entidades;
using wcfWorkFlowN.Datos;

namespace wcfWorkFlowN.Entidades  {

    public class clsInstanciaNodoBE : clsWorkflowBaseBE {

        public Int64 iIdInstancia { get; set; }
        public Int32 iSecuencia { get; set; }
        public Int32 iIdHisInstancia { get; set; }
        public string sIdTipoTramite { get; set; }
        public Int64 iIdSolicitud { get; set; }
        public Int32 iIdFlujo { get; set; }
        public Int16 iIdNodo { get; set; }
        public Int16 iContador { get; set; }
        public DateTime fFechaHrInicio { get; set; }
        public DateTime fFechaHrFin { get; set; }
        public Byte iNivelOficina { get; set; }
        public Int32? iIdOficina { get; set; }
        public Int32? iIdArea { get; set; }
        public Int32 iIdRol { get; set; }
        public Int32 iIdUsuario { get; set; }
        public string sComentarios { get; set; }
        public Int32 iSecuenciaPred { get; set; }
        public Int16 iIdNodoPred { get; set; }
        public Boolean bFlagCbteTrasladoDoc { get; set; }
        public Boolean bFlagCbteTrasladoDocOK { get; set; }
        public Int64 iIdCbteTrasladoDoc { get; set; }
        public string sEstado { get; set; }

        public string sIdListaNodoTrg { get; set; }
        public Int32 iIdUsuarioTrg { get; set; }
        public Boolean bFlagDesdeCbteTrasdoDoc { get; set; }

        public string sNemoNodoOrig { get; set; }
        public string sNemoNodoDest { get; set; }

        public Int64 iIdTramite { get; set; }
        public Int32 iIdGrupoBeneficio { get; set; }
        public DateTime? fFechaDesde { get; set; }
        public DateTime? fFechaHasta	{ get; set; }
        public string sNombreAsegurado { get; set; }
        public Boolean bFlagManual { get; set; }

    }
}