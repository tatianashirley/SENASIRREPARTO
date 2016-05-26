using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfEnvioAPS.Entidades;
using wcfEnvioAPS.Datos;
using System.Data;

namespace wcfEnvioAPS.Logica
{
    public class clsContrlEnvios : clsControlEnviosBE
    {
        #region "Declaración de funciones/Procedimientos Capa Logica"

        clsContrlEnviosDA objContrlEnviosDA = new clsContrlEnviosDA();

        /// <summary>
        /// Lista Numeros de Envios Registrados APS
        /// </summary>
        /// <returns></returns>
        public Boolean ListaNumeroEnviosRegistradosAPS()
        {
            objContrlEnviosDA.iIdConexion = iIdConexion;
            Boolean AnsOK = objContrlEnviosDA.ListaNumeroEnviosRegistradosAPSDA();
            DSet = objContrlEnviosDA.DSet;
            sMensajeError = objContrlEnviosDA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>
        /// Lista Envios y Detalles
        /// </summary>
        /// <returns></returns>
        public Boolean SelectEnvioDetalleAPS()
        {
            objContrlEnviosDA.iIdConexion = iIdConexion;
            objContrlEnviosDA.sNumeroEnvio = sNumeroEnvio;
            Boolean AnsOK = objContrlEnviosDA.SelectEnvioDetalleAPSDA();
            DSet = objContrlEnviosDA.DSet;
            sMensajeError = objContrlEnviosDA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>
        /// Lista Archivos Medios Enviados
        /// </summary>
        /// <returns></returns>
        public Boolean ListaMediosEnviados()
        {
            objContrlEnviosDA.iIdConexion = iIdConexion;            
            objContrlEnviosDA.fFechaCorte = fFechaCorte;
            objContrlEnviosDA.iIdEntidad = iIdEntidad;
            objContrlEnviosDA.sNumeroEnvio = sNumeroEnvio;
            Boolean AnsOK = objContrlEnviosDA.ListaMediosEnviadosDA();
            DSet = objContrlEnviosDA.DSet;
            sMensajeError = objContrlEnviosDA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>
        /// Obtiene una tupla específica de MedioEnvioAPS
        /// </summary>
        /// <returns></returns>
        public Boolean GetRowMedioEnvioAPS()
        {
            objContrlEnviosDA.iIdConexion = iIdConexion;
            objContrlEnviosDA.sNumeroEnvio = sNumeroEnvio;
            objContrlEnviosDA.iIdEntidad = iIdEntidad;
            Boolean AnsOK = objContrlEnviosDA.GetRowMedioEnvioAPSDA();
            DSet = objContrlEnviosDA.DSet;
            sMensajeError = objContrlEnviosDA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>
        /// Actualiza Envios Medios Cites
        /// </summary>
        /// <returns></returns>
        public Boolean ActualizaCitesEnvioAPS()
        {
            objContrlEnviosDA.iIdConexion = iIdConexion;
            objContrlEnviosDA.sNumeroEnvio = sNumeroEnvio;
            objContrlEnviosDA.iIdEntidad = iIdEntidad;
            objContrlEnviosDA.iNumeroCite = iNumeroCite;
            objContrlEnviosDA.fFechaCite = fFechaCite;
            objContrlEnviosDA.fFechaRecepcion = fFechaRecepcion;
            Boolean AnsOK = objContrlEnviosDA.ActualizaCitesEnvioAPSDA();
            DSet = objContrlEnviosDA.DSet;
            sMensajeError = objContrlEnviosDA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>
        /// CIERRE de Envio
        /// </summary>
        /// <returns></returns>
        public Boolean CierreEnvioAPS()
        {
            objContrlEnviosDA.iIdConexion = iIdConexion;
            objContrlEnviosDA.sNumeroEnvio = sNumeroEnvio;
            Boolean AnsOK = objContrlEnviosDA.CierreEnvioAPSDA();
            sMensajeError = objContrlEnviosDA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>
        /// rptCtrlCites_Detalle01
        /// </summary>
        /// <returns></returns>
        public Boolean CtrlCites_Detalle01()
        {
            objContrlEnviosDA.iIdConexion = iIdConexion;
            Boolean AnsOK = objContrlEnviosDA.CtrlCites_Detalle01DA();
            DSet = objContrlEnviosDA.DSet;
            sMensajeError = objContrlEnviosDA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>
        /// Lista Entidades
        /// </summary>
        /// <returns></returns>
        public DataTable ListaEntidades(int IdTipoClasificador)
        {
            return (objContrlEnviosDA.ListaEntidadesDA(IdTipoClasificador));
        }
        #endregion
    }
}