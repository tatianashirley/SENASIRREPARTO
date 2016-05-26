using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfWorkFlowN.Entidades;
using wcfWorkFlowN.Datos;

namespace wcfWorkFlowN.Logica {

    public class clsInstanciaNodo : clsInstanciaNodoBE {

        clsInstanciaNodoDA ObjINodoDA = new clsInstanciaNodoDA();

        public Boolean ObtieneActividadesXUsuario() {
            ObjINodoDA.iIdConexion = iIdConexion;
            ObjINodoDA.iIdTramite = iIdTramite;
            ObjINodoDA.fFechaDesde = fFechaDesde;
            ObjINodoDA.fFechaHasta = fFechaHasta;
            ObjINodoDA.sNombreAsegurado = sNombreAsegurado;
            ObjINodoDA.iIdNodo = (Int16)((iIdNodo < 0) ? 0 : iIdNodo);
            Boolean AnsOK = ObjINodoDA.ObtieneActividadesXUsuario();
            DSet = ObjINodoDA.DSet;
            sMensajeError = ObjINodoDA.sMensajeError;
            iNivelError = ObjINodoDA.iNivelError;
            return (AnsOK);
        }

        public Boolean ObtieneTransicionesPosibles() {
            ObjINodoDA.iIdConexion = iIdConexion;
            ObjINodoDA.iIdInstancia = iIdInstancia;
            ObjINodoDA.iSecuencia = iSecuencia;
            ObjINodoDA.bFlagManual = bFlagManual;
            Boolean AnsOK = ObjINodoDA.ObtieneTransicionesPosibles();
            DSet = ObjINodoDA.DSet;
            sMensajeError = ObjINodoDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean ObtieneTransicionesParaAsignacion() {
            ObjINodoDA.iIdConexion = iIdConexion;
            Boolean AnsOK = ObjINodoDA.ObtieneTransicionesParaAsignacion();
            DSet = ObjINodoDA.DSet;
            sMensajeError = ObjINodoDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean ObtieneTransicionesParaGeneracionDeCbte() {
            ObjINodoDA.iIdConexion = iIdConexion;
            ObjINodoDA.iIdInstancia = iIdInstancia;
            ObjINodoDA.iSecuencia = iSecuencia;
            Boolean AnsOK = ObjINodoDA.ObtieneTransicionesParaGeneracionDeCbte();
            DSet = ObjINodoDA.DSet;
            sMensajeError = ObjINodoDA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>
        /// Obtiene las actividades para realizar asignaciones dado el nemónico del nodo origen
        /// </summary>
        /// <param name="sNemoNodoOrig"></param>
        /// <returns></returns>
        public Boolean ObtieneActividadesParaAsignacion() {
            ObjINodoDA.iIdConexion = iIdConexion;
            ObjINodoDA.iIdTramite = iIdTramite;
            ObjINodoDA.fFechaDesde = fFechaDesde;
            ObjINodoDA.fFechaHasta = fFechaHasta;
            ObjINodoDA.sNombreAsegurado = sNombreAsegurado;

            Boolean AnsOK = ObjINodoDA.ObtieneActividadesParaAsignacion(sNemoNodoOrig, sNemoNodoDest);
            DSet = ObjINodoDA.DSet;
            sMensajeError = ObjINodoDA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>   
        /// Obtiene las actividades para generar comprobante de traslado de documentos dado el nemónico del nodo origen
        /// </summary>
        /// <returns></returns>
        public Boolean ObtieneActividadesParaGeneracionCbte() {
            ObjINodoDA.iIdConexion = iIdConexion;
            ObjINodoDA.iSesionTrabajo = iSesionTrabajo;
            Boolean AnsOK = ObjINodoDA.ObtieneActividadesParaGeneracionCbte(sNemoNodoOrig);
            DSet = ObjINodoDA.DSet;
            sMensajeError = ObjINodoDA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>
        /// Devuelve verdadero si existen actividades habilotadas para las asignaciones
        /// </summary>
        /// <param name="sNemoNodoOrig">Nemónico de la actividad origen</param>
        /// <returns></returns>
        public Boolean ExistenActividadesParaAsignacion() {
            ObjINodoDA.iIdConexion = iIdConexion;
            Boolean AnsOK = ObjINodoDA.ExistenActividadesParaAsignacion();
            sMensajeError = ObjINodoDA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>
        /// Devuelve verdadero si existen transiciones que deben confirmarse a través de un comprobante de traslado de documentos
        /// </summary>
        /// <returns></returns>
        public bool ExistenActividadesParaGenerarConCbte() {
            ObjINodoDA.iIdConexion = iIdConexion;
            Boolean AnsOK = ObjINodoDA.ExistenActividadesParaGenerarConCbte();
            sMensajeError = ObjINodoDA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>
        /// Devuelve verdadero si existen transiciones que deben realizarse a través de un comprobante de traslado de documentos
        /// </summary>
        /// <returns></returns>
        public Boolean ExistenActividadesParaAceptarConCbte() {
            ObjINodoDA.iIdConexion = iIdConexion;
            Boolean AnsOK = ObjINodoDA.ExistenActividadesParaAceptarConCbte();
            sMensajeError = ObjINodoDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean ObtieneHistorialEjecucion() {
            ObjINodoDA.iIdConexion = iIdConexion;
            ObjINodoDA.iIdInstancia = iIdInstancia;
            Boolean AnsOK = ObjINodoDA.ObtieneHistorialEjecucion();
            DSet = ObjINodoDA.DSet;
            sMensajeError = ObjINodoDA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>
        /// Obtiene los trámites 
        /// </summary>
        /// <returns></returns>
        public Boolean ObtieneTramitesXUsuario() {
            ObjINodoDA.iIdConexion = iIdConexion;
            ObjINodoDA.iIdOficina = iIdOficina;
            ObjINodoDA.iIdArea = iIdArea;
            ObjINodoDA.iIdUsuario = iIdUsuario;
            ObjINodoDA.sEstado = sEstado;
            ObjINodoDA.fFechaDesde = fFechaDesde;
            ObjINodoDA.fFechaHasta = fFechaHasta;

            Boolean AnsOK = ObjINodoDA.ObtieneTramitesXUsuario();
            DSet = ObjINodoDA.DSet;
            sMensajeError = ObjINodoDA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>
        /// Recupera una fila a partir de la llave primaria 
        /// </summary>
        /// <returns></returns>
        public Boolean ObtieneFila() {
            ObjINodoDA.iIdConexion = iIdConexion;
            ObjINodoDA.iIdInstancia = iIdInstancia;
            ObjINodoDA.iSecuencia = iSecuencia; 
            Boolean AnsOK = ObjINodoDA.ObtieneFila();
            DSet = ObjINodoDA.DSet;
            sMensajeError = ObjINodoDA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>
        /// Realiza la transición hacia una o varias actividades
        /// </summary>
        /// <returns></returns>
        public Boolean RealizaTransicion() {
            ObjINodoDA.iIdConexion = iIdConexion;
            ObjINodoDA.iIdInstancia = iIdInstancia;
            ObjINodoDA.iSecuencia = iSecuencia;
            ObjINodoDA.sComentarios = sComentarios;
            ObjINodoDA.sIdListaNodoTrg = sIdListaNodoTrg;
            ObjINodoDA.bFlagManual = bFlagManual;
            Boolean AnsOK = ObjINodoDA.RealizaTransicion();
            sMensajeError = ObjINodoDA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>
        /// Devuelve la actividad activa de un trámite en ejecución
        /// </summary>
        /// <returns></returns>
        public Boolean ObtieneActividadActiva() {
            ObjINodoDA.iIdConexion = iIdConexion;
            ObjINodoDA.iIdTramite = iIdTramite;
            ObjINodoDA.iIdGrupoBeneficio = iIdGrupoBeneficio;
            ObjINodoDA.sNemoNodoOrig = sNemoNodoOrig;
            ObjINodoDA.sEstado = sEstado;
            Boolean AnsOK = ObjINodoDA.ObtieneActividadActiva();
            iIdInstancia = ObjINodoDA.iIdInstancia;
            iSecuencia = ObjINodoDA.iSecuencia;
            sMensajeError = ObjINodoDA.sMensajeError;
            return (AnsOK);
        }
    }
}