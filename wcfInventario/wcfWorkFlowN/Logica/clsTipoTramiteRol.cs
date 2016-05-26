using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfWorkFlowN.Entidades;
using wcfWorkFlowN.Datos;

namespace wcfWorkFlowN.Logica {

    public class clsTipoTramiteRol : clsTipoTramiteRolBE {

        clsTipoTramiteRolDA ObjSolicTrmteDA = new clsTipoTramiteRolDA();

        public Boolean Adicion() {
            if (iIdRol == iIdRolSup) {
                sMensajeError = "El rol y el rol superior no pueden ser el mismo";
                return(false);
            }

            ObjSolicTrmteDA.iIdConexion = iIdConexion;
            ObjSolicTrmteDA.sIdTipoTramite = sIdTipoTramite;
            ObjSolicTrmteDA.iIdRol = iIdRol;
            ObjSolicTrmteDA.iIdRolSup = iIdRolSup;
            Boolean AnsOK = ObjSolicTrmteDA.Adicion();
            sMensajeError = ObjSolicTrmteDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean Modificacion() {
            ObjSolicTrmteDA.iIdConexion = iIdConexion;
            ObjSolicTrmteDA.sIdTipoTramite = sIdTipoTramite;
            ObjSolicTrmteDA.iIdRol = iIdRol;
            ObjSolicTrmteDA.bFlagUnico = bFlagUnico;
            Boolean AnsOK = ObjSolicTrmteDA.Modificacion();
            sMensajeError = ObjSolicTrmteDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean Eliminacion() {
            ObjSolicTrmteDA.iIdConexion = iIdConexion;
            ObjSolicTrmteDA.sIdTipoTramite = sIdTipoTramite;
            ObjSolicTrmteDA.iIdRol = iIdRol;
            Boolean AnsOK = ObjSolicTrmteDA.Eliminacion();
            sMensajeError = ObjSolicTrmteDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean ObtieneFila() {
            ObjSolicTrmteDA.iIdConexion = iIdConexion;
            ObjSolicTrmteDA.sIdTipoTramite = sIdTipoTramite;
            ObjSolicTrmteDA.iIdRol = iIdRol;
            Boolean AnsOK = ObjSolicTrmteDA.ObtieneFila();
            DSet = ObjSolicTrmteDA.DSet;
            sMensajeError = ObjSolicTrmteDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean ObtieneRolesRegistrados() {
            ObjSolicTrmteDA.iIdConexion = iIdConexion;
            ObjSolicTrmteDA.sIdTipoTramite = sIdTipoTramite;
            Boolean AnsOK = ObjSolicTrmteDA.ObtieneRolesRegistrados();
            DSet = ObjSolicTrmteDA.DSet;
            sMensajeError = ObjSolicTrmteDA.sMensajeError;
            return (AnsOK);
        }

    }
}