using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wcfWorkFlowN.Entidades {

    public class clsFlujoNodoBE : clsWorkflowBaseBE {

        public Int32 iIdFlujo {get; set;}
        public Int16 iIdNodo  {get; set;}
        public String sDescripcion {get; set;}
        public String sComentarios  {get; set;}
        public Int16 iDuracionMaxDias {get; set;}
        public Int16 iDuracionMaxHoras {get; set;}
        public Byte iNivelOficina {get; set;}
        public Int32 iIdOficina {get; set;}
        public Int32 iIdArea {get; set;}
        public Int32 iIdRol {get; set;}
        public Int32 iIdUsuario {get; set;}
        public Boolean bFlagRechazo {get; set;}
        public Boolean bFlagFicticio {get; set;}
        public Boolean bFlagSincronizador {get; set;}
        public Boolean bFlagTerminal {get; set;}
        public Int32 iIdEstadoTramite {get; set;}
        public String sNemonico {get; set;}
        public String sEstado { get; set; }

    }

}