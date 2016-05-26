using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfWorkFlowN.Entidades;
using wcfWorkFlowN.Datos;

namespace wcfWorkFlowN.Logica {

    public class clsFlujoNodoPredecesorProceso : clsFlujoNodoPredecesorProcesoBE {

        clsFlujoNodoPredecesorProcesoDA ObjFNodoPredProcDA = new clsFlujoNodoPredecesorProcesoDA();

        public Boolean Adicion() {
            ObjFNodoPredProcDA.iIdConexion = iIdConexion;
            ObjFNodoPredProcDA.iIdFlujo = iIdFlujo;
            ObjFNodoPredProcDA.iIdNodoPred = iIdNodoPred;
            ObjFNodoPredProcDA.iIdNodo = iIdNodo;
            ObjFNodoPredProcDA.iSecuencia = iSecuencia;
            ObjFNodoPredProcDA.iIdProcedimiento = iIdProcedimiento;
            ObjFNodoPredProcDA.bFLagExitoProc = bFLagExitoProc;
            ObjFNodoPredProcDA.sPrmOperacion = sPrmOperacion;
            ObjFNodoPredProcDA.bFlagCbteAcepDoc = bFlagCbteAcepDoc;
            ObjFNodoPredProcDA.bFlagAceptacion = bFlagAceptacion;

            Boolean AnsOK = ObjFNodoPredProcDA.Adicion();
            sMensajeError = ObjFNodoPredProcDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean Modificacion() {
            ObjFNodoPredProcDA.iIdConexion = iIdConexion;
            ObjFNodoPredProcDA.iIdFlujo = iIdFlujo;
            ObjFNodoPredProcDA.iIdNodoPred = iIdNodoPred;
            ObjFNodoPredProcDA.iIdNodo = iIdNodo;
            ObjFNodoPredProcDA.iSecuencia = iSecuencia;
            ObjFNodoPredProcDA.iIdProcedimiento = iIdProcedimiento;
            ObjFNodoPredProcDA.bFLagExitoProc = bFLagExitoProc;
            ObjFNodoPredProcDA.sPrmOperacion = sPrmOperacion;
            ObjFNodoPredProcDA.bFlagCbteAcepDoc = bFlagCbteAcepDoc;
            ObjFNodoPredProcDA.bFlagAceptacion = bFlagAceptacion;

            Boolean AnsOK = ObjFNodoPredProcDA.Modificacion();
            sMensajeError = ObjFNodoPredProcDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean Eliminacion() {
            ObjFNodoPredProcDA.iIdConexion = iIdConexion;
            ObjFNodoPredProcDA.iIdFlujo = iIdFlujo;
            ObjFNodoPredProcDA.iIdNodoPred = iIdNodoPred;
            ObjFNodoPredProcDA.iIdNodo = iIdNodo;
            ObjFNodoPredProcDA.iSecuencia = iSecuencia;
            ObjFNodoPredProcDA.iIdProcedimiento = iIdProcedimiento;
            Boolean AnsOK = ObjFNodoPredProcDA.Eliminacion();
            sMensajeError = ObjFNodoPredProcDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean ObtieneFila() {
            ObjFNodoPredProcDA.iIdConexion = iIdConexion;
            ObjFNodoPredProcDA.iIdFlujo = iIdFlujo;
            ObjFNodoPredProcDA.iIdNodoPred = iIdNodoPred;
            ObjFNodoPredProcDA.iIdNodo = iIdNodo;
            ObjFNodoPredProcDA.iSecuencia = iSecuencia;
            ObjFNodoPredProcDA.iIdProcedimiento = iIdProcedimiento;
            Boolean AnsOK = ObjFNodoPredProcDA.ObtieneFila();
            DSet = ObjFNodoPredProcDA.DSet;
            sMensajeError = ObjFNodoPredProcDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean ObtieneProcesosXTransicion() {
            ObjFNodoPredProcDA.iIdConexion = iIdConexion;
            ObjFNodoPredProcDA.iIdFlujo = iIdFlujo;
            ObjFNodoPredProcDA.iIdNodoPred = iIdNodoPred;
            ObjFNodoPredProcDA.iIdNodo = iIdNodo;
            Boolean AnsOK = ObjFNodoPredProcDA.ObtieneProcesosXTransicion();
            DSet = ObjFNodoPredProcDA.DSet;
            sMensajeError = ObjFNodoPredProcDA.sMensajeError;
            return (AnsOK);
        }

    }

}