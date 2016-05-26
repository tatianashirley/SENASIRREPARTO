using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfWorkFlowN.Entidades;
using wcfWorkFlowN.Datos;

namespace wcfWorkFlowN.Logica {

    public class clsTransicionMasiva : clsTransicionMasivaBE {

        clsTransicionMasivaDA ObjTranMsvaDA = new clsTransicionMasivaDA();

        public Boolean ProcesaAsignacion() {
            ObjTranMsvaDA.iIdConexion = iIdConexion;
            ObjTranMsvaDA.iIdTransicionMsva = iIdTransicionMsva;
            Boolean AnsOK = ObjTranMsvaDA.ProcesaAsignacion();
            sMensajeError = ObjTranMsvaDA.sMensajeError;
            return (AnsOK);
        }



    }

}