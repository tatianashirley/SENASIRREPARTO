using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfReprocesos.Entidades;
using wcfReprocesos.Datos;
using System.Data;

namespace wcfReprocesos.Logica
{
    public class clsRM266 : clsRM266BE
    {
        #region "Declaración de funciones/Procedimientos Capa Logica"

        clsRM266DA objRM266DA = new clsRM266DA();

        /// <summary>
        /// Obtiene Datos de una Persona
        /// </summary>
        /// <returns></returns>
        public Boolean ObtieneDatosPersona()
        {
            objRM266DA.iIdConexion = iIdConexion;
            objRM266DA.iIdTramite = iIdTramite;
            objRM266DA.iIdGrupoBeneficio = iIdGrupoBeneficio;
            Boolean AnsOK = objRM266DA.ObtieneDatosPersonaDA();
            DSet = objRM266DA.DSet;

            sMensajeError = objRM266DA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>
        /// Obtiene Certificados pertenecientes a un tramite
        /// </summary>
        /// <returns></returns>
        public Boolean ObtieneCertificadosTramite()
        {
            objRM266DA.iIdConexion = iIdConexion;
            objRM266DA.iIdTramite = iIdTramite;
            objRM266DA.iIdGrupoBeneficio = iIdGrupoBeneficio;
            objRM266DA.iNroCertificado = iNroCertificado;
            Boolean AnsOK = objRM266DA.ObtieneCertificadosTramiteDA();
            DSet = objRM266DA.DSet;

            sMensajeError = objRM266DA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>
        /// Anula Certificado Original
        /// </summary>
        /// <returns></returns>
        public Boolean AnulaCertificado()
        {
            objRM266DA.iIdConexion = iIdConexion;
            objRM266DA.iNroCertificado = iNroCertificado;
            objRM266DA.iIdTipoTramite = iIdTipoTramite;
            objRM266DA.iNroFormularioRepro = iNroFormularioRepro;
            Boolean AnsOK = objRM266DA.AnulaCertificadoDA();
            DSet = objRM266DA.DSet;
            sMensajeError = objRM266DA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>
        /// Modifica Fecha de Nacimiento a través de Novedades REPROCESOS
        /// </summary>
        /// <returns></returns>
        public Boolean ModificaFechaNacimiento()
        {
            objRM266DA.iIdConexion = iIdConexion;

            objRM266DA.iNoFormularioCalculo = iNoFormularioCalculo;
            objRM266DA.iIdTipoFormularioCalculo = iIdTipoFormularioCalculo;
            objRM266DA.iNroCertificado = iNroCertificado;

            objRM266DA.iNumeroResolucion = iNumeroResolucion;
            objRM266DA.fFechaResolucion = fFechaResolucion;
            objRM266DA.fFechaNacimientoNueva = fFechaNacimientoNueva;
            objRM266DA.sMatriculaNueva = sMatriculaNueva;
            objRM266DA.iNroFormularioRepro = iNroFormularioRepro;

            Boolean AnsOK = objRM266DA.ModificaFechaNacimientoDA();
            DSet = objRM266DA.DSet;

            sMensajeError = objRM266DA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>
        /// Modifica Fecha de Nacimiento a través de Novedades Tramite sin Certificado Impreso
        /// </summary>
        /// <returns></returns>
        public Boolean ModFechaNacimiento()
        {
            objRM266DA.iIdConexion = iIdConexion;

            objRM266DA.iNumeroResolucion = iNumeroResolucion;
            objRM266DA.fFechaResolucion = fFechaResolucion;
            objRM266DA.fFechaNacimientoNueva = fFechaNacimientoNueva;
            objRM266DA.sMatriculaNueva = sMatriculaNueva;
            objRM266DA.iIdTramite = iIdTramite;
            objRM266DA.iIdGrupoBeneficio = iIdGrupoBeneficio;

            Boolean AnsOK = objRM266DA.ModFechaNacimientoDA();
            DSet = objRM266DA.DSet;

            sMensajeError = objRM266DA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>
        /// RM266 Inserta Nuevo Certificado Recalculado
        /// </summary>
        /// <returns></returns>
        public Boolean ProcesaNuevoCertificado()
        {
            objRM266DA.iIdConexion = iIdConexion;
            objRM266DA.iNroFormularioRepro = iNroFormularioRepro;
            objRM266DA.bRegistroAPS = bRegistroAPS;
            objRM266DA.iNroCertificado = iNroCertificado;
            objRM266DA.iIdTipoTramite = iIdTipoTramite;
            objRM266DA.iIdOficina = iIdOficina;
            objRM266DA.iIdOficinaArea = iIdOficinaArea;
            objRM266DA.iNroAsignacion = iNroAsignacion;
            objRM266DA.iIdUsuario = iIdUsuario;
            Boolean AnsOK = objRM266DA.ProcesaNuevoCertificadoDA();
            DSet = objRM266DA.DSet;
            iNuevoNumeroCertificado = objRM266DA.iNuevoNumeroCertificado;

            sMensajeError = objRM266DA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>
        /// Obtiene Bandeja de Certificados Asignados por Oficina
        /// </summary>
        /// <returns></returns>
        public Boolean ObtieneBandejaCertificadosAsignadosOficina()
        {
            objRM266DA.iIdConexion = iIdConexion;
            objRM266DA.iIdOficina = iIdOficina;
            objRM266DA.iIdOficinaArea = iIdOficinaArea;
            objRM266DA.iIdTipoTramite = iIdTipoTramite;
            Boolean AnsOK = objRM266DA.ObtieneBandejaCertificadosAsignadosOficinaDA();
            DSet = objRM266DA.DSet;

            sMensajeError = objRM266DA.sMensajeError;
            return (AnsOK);
        }

        #endregion
    }
}