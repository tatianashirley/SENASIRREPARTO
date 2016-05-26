using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfEnvioAPS.Entidades;
using wcfEnvioAPS.Datos;

namespace wcfEnvioAPS.Logica
{
    public class clsRegistroBajas : clsRegistroBajasBE
    {
        #region "Declaración de funciones/Procedimientos Capa Logica"

        clsRegistroBajasDA objRegistroBajasDA = new clsRegistroBajasDA();

        /// <summary>
        /// Registra Bajas
        /// </summary>
        /// <returns></returns>
        public Boolean RegistraBajaCertificado()
        {
            objRegistroBajasDA.iIdConexion = iIdConexion;
            objRegistroBajasDA.iNroCertificado = iNroCertificado;
            objRegistroBajasDA.iIdTipoTramite = iIdTipoTramite;
            objRegistroBajasDA.sNumeroResolucionA = sNumeroResolucionA;
            objRegistroBajasDA.fFechaResolucionA = fFechaResolucionA;
            objRegistroBajasDA.bAprueba = bAprueba;
            Boolean AnsOK = objRegistroBajasDA.RegistraBajaCertificadoDA();
            //DSet = objRegistroBajasDA.DSet;
            mensaje = objRegistroBajasDA.mensaje;
            sMensajeError = objRegistroBajasDA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>
        /// Selecciona Historial de Envios APS
        /// </summary>
        /// <returns></returns>
        public Boolean SeleccionaHistorialEnviosAPS()
        {
            objRegistroBajasDA.iIdConexion = iIdConexion;
            objRegistroBajasDA.iNroCertificado = iNroCertificado;
            objRegistroBajasDA.iIdTipoTramite = iIdTipoTramite;
            Boolean AnsOK = objRegistroBajasDA.SeleccionaHistorialEnviosAPSDA();
            DSet = objRegistroBajasDA.DSet;
            sMensajeError = objRegistroBajasDA.sMensajeError;
            return (AnsOK);
        }
        
        /// <summary>
        /// Selecciona datos de Pagos de un Certificado
        /// </summary>
        /// <returns></returns>
        public Boolean SeleccionaDatosPagosCertificado()
        {
            objRegistroBajasDA.iIdConexion = iIdConexion;
            objRegistroBajasDA.iNroCertificado = iNroCertificado;
            objRegistroBajasDA.iNUP = iNUP;
            Boolean AnsOK = objRegistroBajasDA.SeleccionaDatosPagosCertificadoDA();
            DSet = objRegistroBajasDA.DSet;
            sMensajeError = objRegistroBajasDA.sMensajeError;
            return (AnsOK);
        }        
        #endregion
    }
}