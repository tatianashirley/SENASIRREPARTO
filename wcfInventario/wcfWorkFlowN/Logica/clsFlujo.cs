using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfWorkFlowN.Entidades;
using wcfWorkFlowN.Datos;

namespace wcfWorkFlowN.Logica {

    public class clsFlujo : clsFlujoBE {

        clsFlujoDA ObjFlujoDA = new clsFlujoDA();

        public Boolean Adicion() {
            ObjFlujoDA.iIdConexion = iIdConexion;
            ObjFlujoDA.iIdFlujo = iIdFlujo; 
            ObjFlujoDA.sDescripcion = sDescripcion;
            ObjFlujoDA.sIdTipoTramite = sIdTipoTramite;
            ObjFlujoDA.sComentarios = sComentarios;
            ObjFlujoDA.iDuracionMaxDias = iDuracionMaxDias;
            ObjFlujoDA.iDuracionMaxHoras = iDuracionMaxHoras;
            ObjFlujoDA.iIdGrupoRestriccion = iIdGrupoRestriccion;
            ObjFlujoDA.bFlagUnRechazo = bFlagUnRechazo;
            ObjFlujoDA.iNivelOficina =iNivelOficina;
            ObjFlujoDA.iIdOficina = iIdOficina;
            ObjFlujoDA.iIdArea = iIdArea;
            ObjFlujoDA.iIdRol = iIdRol;
            ObjFlujoDA.iIdUsuario = iIdUsuario;
            ObjFlujoDA.iPrioridad = iPrioridad;
            Boolean AnsOK = ObjFlujoDA.Adicion();
            sMensajeError = ObjFlujoDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean Modificacion() {
            ObjFlujoDA.iIdConexion = iIdConexion;
            ObjFlujoDA.iIdFlujo = iIdFlujo; 
            ObjFlujoDA.sDescripcion = sDescripcion;
            ObjFlujoDA.sIdTipoTramite = sIdTipoTramite;
            ObjFlujoDA.sComentarios = sComentarios;
            ObjFlujoDA.iDuracionMaxDias = iDuracionMaxDias;
            ObjFlujoDA.iDuracionMaxHoras = iDuracionMaxHoras;
            ObjFlujoDA.iIdGrupoRestriccion = iIdGrupoRestriccion;
            ObjFlujoDA.bFlagUnRechazo = bFlagUnRechazo;
            ObjFlujoDA.iNivelOficina =iNivelOficina;
            ObjFlujoDA.iIdOficina = iIdOficina;
            ObjFlujoDA.iIdArea = iIdArea;
            ObjFlujoDA.iIdRol = iIdRol;
            ObjFlujoDA.iIdUsuario = iIdUsuario;
            ObjFlujoDA.iPrioridad = iPrioridad;
            Boolean AnsOK = ObjFlujoDA.Modificacion();
            sMensajeError = ObjFlujoDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean Eliminacion() {
            ObjFlujoDA.iIdConexion = iIdConexion;
            ObjFlujoDA.iIdFlujo = iIdFlujo;
            Boolean AnsOK = ObjFlujoDA.Eliminacion();
            sMensajeError = ObjFlujoDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean ObtieneFila() {
            ObjFlujoDA.iIdConexion = iIdConexion;
            ObjFlujoDA.iIdFlujo = iIdFlujo;
            Boolean AnsOK = ObjFlujoDA.ObtieneFila();
            DSet = ObjFlujoDA.DSet;
            sMensajeError = ObjFlujoDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean ObtieneFlujosXTipoTramite() {
            ObjFlujoDA.iIdConexion = iIdConexion;
            ObjFlujoDA.sIdTipoTramite = sIdTipoTramite;
            Boolean AnsOK = ObjFlujoDA.ObtieneFlujosXTipoTramite();
            DSet = ObjFlujoDA.DSet;
            sMensajeError = ObjFlujoDA.sMensajeError;
            return (AnsOK);

            //clsInstanciaNodo ObjINodo = new clsInstanciaNodo();
            //ObjINodo.iIdConexion = MiConexion;
            //ObjINodo.iIdTramite = MiTramite;
            //ObjINodo.iIdGrupoBeneficio = MiGrupoBeneficio;
            //ObjINodo.sNemoNodoOrig = "NOTIFICACION";
            //ObjINodo.sEstado = "I";
            //if (ObjINodo.ObtieneActividadActiva()) {
            //    clsInstanciaNodoConcepto ObjINodoCpto = new clsInstanciaNodoConcepto();
            //    ObjINodoCpto.iIdConexion = MiConexion;
            //    ObjINodoCpto.iIdInstancia = ObjINodo.iIdInstancia;
            //    ObjINodoCpto.iSecuencia = ObjINodo.iSecuencia;
            //    ObjINodoCpto.sIdConcepto = "FCALC_AUTO";
            //    ObjINodoCpto.bValorBoolean = true; 
            //}
        }

    }

}