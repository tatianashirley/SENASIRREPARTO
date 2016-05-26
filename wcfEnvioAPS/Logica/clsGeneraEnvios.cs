using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfEnvioAPS.Entidades;
using wcfEnvioAPS.Datos;

namespace wcfEnvioAPS.Logica
{
    public class clsGeneraEnvios : clsGeneraEnviosBE
    {
        #region "Declaración de funciones/Procedimientos Capa Logica"

        clsGeneraEnviosDA objGeneraEnviosDA = new clsGeneraEnviosDA();

        /// <summary>
        /// Realiza la Generación de Envios APS (Alta) x Certificado
        /// </summary>
        /// <returns></returns>
        public Boolean AltaGeneraEnvioXcertificado()
        {
            objGeneraEnviosDA.iIdConexion = iIdConexion;
            objGeneraEnviosDA.fFechaCorte = fFechaCorte;
            objGeneraEnviosDA.sNumeroResolucionA = sNumeroResolucionA;
            objGeneraEnviosDA.fFechaResolucionA = fFechaResolucionA;
            objGeneraEnviosDA.sNumeroResolucionM = sNumeroResolucionM;
            objGeneraEnviosDA.fFechaResolucionM = fFechaResolucionM;
            objGeneraEnviosDA.sLoteCertificados = sLoteCertificados;
            Boolean AnsOK = objGeneraEnviosDA.AltaGeneraEnvioXcertificadoDA();
            DSet = objGeneraEnviosDA.DSet;
            sMensajeError = objGeneraEnviosDA.sMensajeError;
            return (AnsOK);
        }
        /// <summary>
        /// Realiza la Generación de Envios APS (Modificacion) x Certificado
        /// </summary>
        /// <returns></returns>
        public Boolean ModificacionGeneraEnvioXcertificado()
        {
            objGeneraEnviosDA.iIdConexion = iIdConexion;
            objGeneraEnviosDA.fFechaCorte = fFechaCorte;
            objGeneraEnviosDA.sLoteCertificados = sLoteCertificados;
            Boolean AnsOK = objGeneraEnviosDA.ModificacionGeneraEnvioXcertificadoDA();
            DSet = objGeneraEnviosDA.DSet;
            sMensajeError = objGeneraEnviosDA.sMensajeError;
            return (AnsOK);
        }
        /// <summary>
        /// Realiza la Generación de Envios APS (Baja) x Certificado
        /// </summary>
        /// <returns></returns>
        public Boolean BajasGeneraEnvioXcertificado()
        {
            objGeneraEnviosDA.iIdConexion = iIdConexion;
            objGeneraEnviosDA.fFechaCorte = fFechaCorte;
            objGeneraEnviosDA.sLoteCertificados = sLoteCertificados;
            Boolean AnsOK = objGeneraEnviosDA.BajasGeneraEnvioXcertificadoDA();
            DSet = objGeneraEnviosDA.DSet;
            sMensajeError = objGeneraEnviosDA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>
        /// Realiza la Exclusión de Certificados de Envios APS generados
        /// </summary>
        /// <returns></returns>
        public Boolean ExcluyeCertificadoMedioEnvioAPS()
        {
            objGeneraEnviosDA.iIdConexion = iIdConexion;
            objGeneraEnviosDA.sNumeroEnvio = sNumeroEnvio;
            objGeneraEnviosDA.iFila = iFila;
            Boolean AnsOK = objGeneraEnviosDA.ExcluyeCertificadoMedioEnvioAPSDA();
            DSet = objGeneraEnviosDA.DSet;
            sMensajeError = objGeneraEnviosDA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>
        /// Genera Reporte RMCC01
        /// </summary>
        /// <returns></returns>
        public Boolean ObtieneDetalleEnvio()
        {
            objGeneraEnviosDA.iIdConexion = iIdConexion;
            objGeneraEnviosDA.sNumeroEnvio = sNumeroEnvio;
            objGeneraEnviosDA.iIdEntidad = iIdEntidad;
            Boolean AnsOK = objGeneraEnviosDA.ObtieneDetalleEnvioDA();
            DSet = objGeneraEnviosDA.DSet;
            sMensajeError = objGeneraEnviosDA.sMensajeError;
            return (AnsOK);
        }
        #endregion
    }
}