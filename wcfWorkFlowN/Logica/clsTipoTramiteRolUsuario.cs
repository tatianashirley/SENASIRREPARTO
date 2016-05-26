using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfWorkFlowN.Entidades;
using wcfWorkFlowN.Datos;

namespace wcfWorkFlowN.Logica {

    public class clsTipoTramiteRolUsuario : clsTipoTramiteRolUsuarioBE {

        clsTipoTramiteRolUsuarioDA ObjTTrmteRolUsrDA = new clsTipoTramiteRolUsuarioDA();

        public Boolean Adicion() {
            ObjTTrmteRolUsrDA.iIdConexion = iIdConexion;
            ObjTTrmteRolUsrDA.sIdTipoTramite = sIdTipoTramite;
            ObjTTrmteRolUsrDA.iIdRol = iIdRol;
            ObjTTrmteRolUsrDA.iIdUsuario = iIdUsuario;
            ObjTTrmteRolUsrDA.iIdUsuarioSuperior = iIdUsuarioSuperior;
            Boolean AnsOK = ObjTTrmteRolUsrDA.Adicion();
            sMensajeError = ObjTTrmteRolUsrDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean Modificacion() {
            ObjTTrmteRolUsrDA.iIdConexion = iIdConexion;
            ObjTTrmteRolUsrDA.sIdTipoTramite = sIdTipoTramite;
            ObjTTrmteRolUsrDA.iIdRol = iIdRol;
            ObjTTrmteRolUsrDA.iIdUsuario = iIdUsuario;
            ObjTTrmteRolUsrDA.iIdUsuarioSuperior = iIdUsuarioSuperior;
            Boolean AnsOK = ObjTTrmteRolUsrDA.Modificacion();
            sMensajeError = ObjTTrmteRolUsrDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean Eliminacion() {
            ObjTTrmteRolUsrDA.iIdConexion = iIdConexion;
            ObjTTrmteRolUsrDA.sIdTipoTramite = sIdTipoTramite;
            ObjTTrmteRolUsrDA.iIdRol = iIdRol;
            ObjTTrmteRolUsrDA.iIdUsuario = iIdUsuario;
            Boolean AnsOK = ObjTTrmteRolUsrDA.Eliminacion();
            sMensajeError = ObjTTrmteRolUsrDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean ObtieneFila() {
            ObjTTrmteRolUsrDA.iIdConexion = iIdConexion;
            ObjTTrmteRolUsrDA.sIdTipoTramite = sIdTipoTramite;
            ObjTTrmteRolUsrDA.iIdRol = iIdRol;
            ObjTTrmteRolUsrDA.iIdUsuario = iIdUsuario;
            Boolean AnsOK = ObjTTrmteRolUsrDA.ObtieneFila();
            DSet = ObjTTrmteRolUsrDA.DSet;
            sMensajeError = ObjTTrmteRolUsrDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean ObtieneUsuariosRegistradosXRol() {
            ObjTTrmteRolUsrDA.iIdConexion = iIdConexion;
            ObjTTrmteRolUsrDA.sIdTipoTramite = sIdTipoTramite;
            ObjTTrmteRolUsrDA.iIdRol = iIdRol;
            Boolean AnsOK = ObjTTrmteRolUsrDA.ObtieneUsuariosRegistradosXRol();
            DSet = ObjTTrmteRolUsrDA.DSet;
            sMensajeError = ObjTTrmteRolUsrDA.sMensajeError;
            return (AnsOK);
        }


    }

}