using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfWorkFlowN.Entidades;
using wcfWorkFlowN.Datos;

namespace wcfWorkFlowN.Logica {

    public class clsFlujoNodo : clsFlujoNodoBE {

        clsFlujoNodoDA ObjFlujoNodoDA = new clsFlujoNodoDA();

        public Boolean Adicion() {
            ObjFlujoNodoDA.iIdConexion = iIdConexion;
            ObjFlujoNodoDA.iIdFlujo = iIdFlujo; 
            ObjFlujoNodoDA.iIdNodo = iIdNodo;
            ObjFlujoNodoDA.sDescripcion = sDescripcion;
            ObjFlujoNodoDA.sComentarios = sComentarios;
            ObjFlujoNodoDA.iDuracionMaxDias = iDuracionMaxDias;
            ObjFlujoNodoDA.iDuracionMaxHoras = iDuracionMaxHoras;
            ObjFlujoNodoDA.iNivelOficina = iNivelOficina;
            ObjFlujoNodoDA.iIdOficina = iIdOficina;
            ObjFlujoNodoDA.iIdArea = iIdArea;
            ObjFlujoNodoDA.iIdRol = iIdRol;
            ObjFlujoNodoDA.iIdUsuario = iIdUsuario;
            ObjFlujoNodoDA.bFlagRechazo = bFlagRechazo;
            ObjFlujoNodoDA.bFlagFicticio = bFlagFicticio;
            ObjFlujoNodoDA.bFlagSincronizador = bFlagSincronizador;
            ObjFlujoNodoDA.bFlagTerminal = bFlagTerminal;
            ObjFlujoNodoDA.iIdEstadoTramite = iIdEstadoTramite;
            ObjFlujoNodoDA.sNemonico = sNemonico;
            ObjFlujoNodoDA.sEstado = sEstado;
            Boolean AnsOK = ObjFlujoNodoDA.Adicion();
            sMensajeError = ObjFlujoNodoDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean Modificacion() {
            ObjFlujoNodoDA.iIdConexion = iIdConexion;
            ObjFlujoNodoDA.iIdFlujo = iIdFlujo; 
            ObjFlujoNodoDA.iIdNodo = iIdNodo;
            ObjFlujoNodoDA.sDescripcion = sDescripcion;
            ObjFlujoNodoDA.sComentarios = sComentarios;
            ObjFlujoNodoDA.iDuracionMaxDias = iDuracionMaxDias;
            ObjFlujoNodoDA.iDuracionMaxHoras = iDuracionMaxHoras;
            ObjFlujoNodoDA.iNivelOficina = iNivelOficina;
            ObjFlujoNodoDA.iIdOficina = iIdOficina;
            ObjFlujoNodoDA.iIdArea = iIdArea;
            ObjFlujoNodoDA.iIdRol = iIdRol;
            ObjFlujoNodoDA.iIdUsuario = iIdUsuario;
            ObjFlujoNodoDA.bFlagRechazo = bFlagRechazo;
            ObjFlujoNodoDA.bFlagFicticio = bFlagFicticio;
            ObjFlujoNodoDA.bFlagSincronizador = bFlagSincronizador;
            ObjFlujoNodoDA.bFlagTerminal = bFlagTerminal;
            ObjFlujoNodoDA.iIdEstadoTramite = iIdEstadoTramite;
            ObjFlujoNodoDA.sNemonico = sNemonico;
            ObjFlujoNodoDA.sEstado = sEstado;
            Boolean AnsOK = ObjFlujoNodoDA.Modificacion();
            sMensajeError = ObjFlujoNodoDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean Eliminacion() {
            ObjFlujoNodoDA.iIdConexion = iIdConexion;
            ObjFlujoNodoDA.iIdFlujo = iIdFlujo; 
            ObjFlujoNodoDA.iIdNodo = iIdNodo;
            ObjFlujoNodoDA.sDescripcion = sDescripcion;
            ObjFlujoNodoDA.sComentarios = sComentarios;
            ObjFlujoNodoDA.iDuracionMaxDias = iDuracionMaxDias;
            ObjFlujoNodoDA.iDuracionMaxHoras = iDuracionMaxHoras;
            ObjFlujoNodoDA.iNivelOficina = iNivelOficina;
            ObjFlujoNodoDA.iIdOficina = iIdOficina;
            ObjFlujoNodoDA.iIdArea = iIdArea;
            ObjFlujoNodoDA.iIdRol = iIdRol;
            ObjFlujoNodoDA.iIdUsuario = iIdUsuario;
            ObjFlujoNodoDA.bFlagRechazo = bFlagRechazo;
            ObjFlujoNodoDA.bFlagFicticio = bFlagFicticio;
            ObjFlujoNodoDA.bFlagSincronizador = bFlagSincronizador;
            ObjFlujoNodoDA.bFlagTerminal = bFlagTerminal;
            ObjFlujoNodoDA.iIdEstadoTramite = iIdEstadoTramite;
            ObjFlujoNodoDA.sNemonico = sNemonico;
            ObjFlujoNodoDA.sEstado = sEstado;
            Boolean AnsOK = ObjFlujoNodoDA.Eliminacion();
            sMensajeError = ObjFlujoNodoDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean ObtieneFila() {
            ObjFlujoNodoDA.iIdConexion = iIdConexion;
            ObjFlujoNodoDA.iSesionTrabajo = iSesionTrabajo;
            ObjFlujoNodoDA.iIdFlujo = iIdFlujo;
            ObjFlujoNodoDA.iIdNodo = iIdNodo;
            Boolean AnsOK = ObjFlujoNodoDA.ObtieneFila();
            DSet = ObjFlujoNodoDA.DSet;
            sMensajeError = ObjFlujoNodoDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean ObtieneNodosXFlujo() {
            ObjFlujoNodoDA.iIdConexion = iIdConexion;
            ObjFlujoNodoDA.iSesionTrabajo = iSesionTrabajo;
            ObjFlujoNodoDA.iIdFlujo = iIdFlujo;
            ObjFlujoNodoDA.iIdNodo = iIdNodo;
            Boolean AnsOK = ObjFlujoNodoDA.ObtieneNodosXFlujo();
            DSet = ObjFlujoNodoDA.DSet;
            sMensajeError = ObjFlujoNodoDA.sMensajeError;
            return (AnsOK);
        }


    }

}