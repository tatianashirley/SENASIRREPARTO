using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfWorkFlowN.Entidades;
using wcfWorkFlowN.Datos;

namespace wcfWorkFlowN.Logica {

    public class clsFlujoNodoPredecesor : clsFlujoNodoPredecesorBE {

        clsFlujoNodoPredecesorDA ObjFNodoPredDA = new clsFlujoNodoPredecesorDA();

        public Boolean Adicion() {
            if (iIdNodoPred == iIdNodo) {
                sMensajeError = "Una actividad no puede ser predecesora de sí misma";
                return (false);
            }

            ObjFNodoPredDA.iIdConexion = iIdConexion;
            ObjFNodoPredDA.iIdFlujo = iIdFlujo;
            ObjFNodoPredDA.iIdNodoPred = iIdNodoPred;
            ObjFNodoPredDA.iIdNodo = iIdNodo;
            ObjFNodoPredDA.iIdGrupoRestriccion = iIdGrupoRestriccion;
            ObjFNodoPredDA.bFLagGeneraCbteRspldo = bFLagGeneraCbteRspldo;
            ObjFNodoPredDA.bFlagImrimeCbteRspldo = bFlagImrimeCbteRspldo;
            ObjFNodoPredDA.bFlagTransicionMasiva = bFlagTransicionMasiva;
            ObjFNodoPredDA.iNodoParalelo = iNodoParalelo;
            ObjFNodoPredDA.sReglaNodoParalelo = sReglaNodoParalelo;
            ObjFNodoPredDA.bFlagManual = bFlagManual;
            ObjFNodoPredDA.bFlagAlerta = bFlagAlerta;
            ObjFNodoPredDA.sMensajeAlerta = sMensajeAlerta;
            ObjFNodoPredDA.bFlagAnonimo = bFlagAnonimo;
            ObjFNodoPredDA.bFlagRetroceso = bFlagRetroceso;
            ObjFNodoPredDA.bFlagUsuarioActual = bFlagUsuarioActual;
            ObjFNodoPredDA.sDescripcion = sDescripcion;

            Boolean AnsOK = ObjFNodoPredDA.Adicion();
            sMensajeError = ObjFNodoPredDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean Modificacion() {
            ObjFNodoPredDA.iIdConexion = iIdConexion;
            ObjFNodoPredDA.iIdFlujo = iIdFlujo;
            ObjFNodoPredDA.iIdNodo = iIdNodo;
            ObjFNodoPredDA.iIdNodoPred = iIdNodoPred;
            ObjFNodoPredDA.iIdGrupoRestriccion = iIdGrupoRestriccion;
            ObjFNodoPredDA.bFLagGeneraCbteRspldo = bFLagGeneraCbteRspldo;
            ObjFNodoPredDA.bFlagImrimeCbteRspldo = bFlagImrimeCbteRspldo;
            ObjFNodoPredDA.bFlagTransicionMasiva = bFlagTransicionMasiva;
            ObjFNodoPredDA.iNodoParalelo = iNodoParalelo;
            ObjFNodoPredDA.sReglaNodoParalelo = sReglaNodoParalelo;
            ObjFNodoPredDA.bFlagManual = bFlagManual;
            ObjFNodoPredDA.bFlagAlerta = bFlagAlerta;
            ObjFNodoPredDA.sMensajeAlerta = sMensajeAlerta;
            ObjFNodoPredDA.bFlagAnonimo = bFlagAnonimo;
            ObjFNodoPredDA.bFlagRetroceso = bFlagRetroceso;
            ObjFNodoPredDA.bFlagUsuarioActual = bFlagUsuarioActual;
            ObjFNodoPredDA.sDescripcion = sDescripcion;
            Boolean AnsOK = ObjFNodoPredDA.Modificacion();
            sMensajeError = ObjFNodoPredDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean Eliminacion() {
            ObjFNodoPredDA.iIdConexion = iIdConexion;
            ObjFNodoPredDA.iIdFlujo = iIdFlujo;
            ObjFNodoPredDA.iIdNodoPred = iIdNodoPred;
            ObjFNodoPredDA.iIdNodo = iIdNodo;
            Boolean AnsOK = ObjFNodoPredDA.Eliminacion();
            sMensajeError = ObjFNodoPredDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean ObtieneFila() {
            ObjFNodoPredDA.iIdConexion = iIdConexion;
            ObjFNodoPredDA.iIdFlujo = iIdFlujo;
            ObjFNodoPredDA.iIdNodoPred = iIdNodoPred;
            ObjFNodoPredDA.iIdNodo = iIdNodo;
            Boolean AnsOK = ObjFNodoPredDA.ObtieneFila();
            DSet = ObjFNodoPredDA.DSet;
            sMensajeError = ObjFNodoPredDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean ObtienePrecedenciasXFlujo() {
            ObjFNodoPredDA.iIdConexion = iIdConexion;
            ObjFNodoPredDA.iIdFlujo = iIdFlujo;
            Boolean AnsOK = ObjFNodoPredDA.ObtienePrecedenciasXFlujo();
            DSet = ObjFNodoPredDA.DSet;
            sMensajeError = ObjFNodoPredDA.sMensajeError;
            return (AnsOK);
        }


    }

}