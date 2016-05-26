using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfReprocesos.Entidades;
using wcfReprocesos.Datos;
using System.Data;

namespace wcfReprocesos.Logica
{
    public class clsRenumera : clsRenumeraBE
    {
        #region "Declaración de funciones/Procedimientos Capa Logica"

        clsRenumeraDA objRenumeraDA = new clsRenumeraDA();

        /// <summary>
        /// Obtiene Certificados pertenecientes a un tramite
        /// </summary>
        /// <returns></returns>
        public Boolean ObtieneCertificadosTramite()
        {
            objRenumeraDA.iIdConexion = iIdConexion;
            objRenumeraDA.iIdTramite = iIdTramite;
            objRenumeraDA.iIdGrupoBeneficio = iIdGrupoBeneficio;
            objRenumeraDA.iNroCertificado = iNroCertificado;
            Boolean AnsOK = objRenumeraDA.ObtieneCertificadosTramiteDA();
            DSet = objRenumeraDA.DSet;

            sMensajeError = objRenumeraDA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>
        /// Obtiene Datos de Certificado
        /// </summary>
        /// <returns></returns>
        public Boolean ObtieneDatosCertificado()
        {
            objRenumeraDA.iIdConexion = iIdConexion;
            objRenumeraDA.iNroCertificado = iNroCertificado;
            objRenumeraDA.iIdTipoTramite = iIdTipoTramite;
            Boolean AnsOK = objRenumeraDA.ObtieneDatosCertificadoDA();
            DSet = objRenumeraDA.DSet;

            sMensajeError = objRenumeraDA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>
        /// Renumera Certificados
        /// </summary>
        /// <returns></returns>
        public Boolean RenumeraCertificado()
        {
            objRenumeraDA.iIdConexion = iIdConexion;
            objRenumeraDA.iNroFormularioRepro = iNroFormularioRepro;
            objRenumeraDA.bRegistroAPS = bRegistroAPS;
            objRenumeraDA.iNroCertificado = iNroCertificado;
            objRenumeraDA.iIdTipoTramite = iIdTipoTramite;
            objRenumeraDA.iIdOficina = iIdOficina;
            objRenumeraDA.iIdOficinaArea = iIdOficinaArea;
            objRenumeraDA.iNroAsignacion = iNroAsignacion;
            objRenumeraDA.iIdUsuarioImpresion = iIdUsuarioImpresion;
            Boolean AnsOK = objRenumeraDA.RenumeraCertificadoDA();
            DSet = objRenumeraDA.DSet;
            iNuevoNumeroCertificado = objRenumeraDA.iNuevoNumeroCertificado;

            sMensajeError = objRenumeraDA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>
        /// Obtiene Bandeja de Certificados Asignados por Oficina
        /// </summary>
        /// <returns></returns>
        public Boolean ObtieneBandejaCertificadosAsignadosOficina()
        {
            objRenumeraDA.iIdConexion = iIdConexion;
            objRenumeraDA.iIdOficina = iIdOficina;
            objRenumeraDA.iIdOficinaArea = iIdOficinaArea;
            objRenumeraDA.iIdTipoTramite = iIdTipoTramite;
            Boolean AnsOK = objRenumeraDA.ObtieneBandejaCertificadosAsignadosOficinaDA();
            DSet = objRenumeraDA.DSet;

            sMensajeError = objRenumeraDA.sMensajeError;
            return (AnsOK);
        }
        #endregion
    }
}