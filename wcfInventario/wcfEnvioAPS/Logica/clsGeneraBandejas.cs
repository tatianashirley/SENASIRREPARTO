using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfEnvioAPS.Entidades;
using wcfEnvioAPS.Datos;
using System.Data;

namespace wcfEnvioAPS.Logica
{
    public class clsGeneraBandejas : clsGeneraBandejasBE
    {
        #region "Declaración de funciones/Procedimientos Capa Logica"

        clsGeneraBandejasDA objGeneraBandejasDA = new clsGeneraBandejasDA();

        /// <summary>
        /// Genera Listado Preliminar de Altas (paginado)
        /// </summary>
        /// <returns></returns>
        public Boolean ListadoPreliminarEnvioAPSPag()
        {
            objGeneraBandejasDA.iIdConexion = iIdConexion;
            objGeneraBandejasDA.fFechaCorte = fFechaCorte;
            objGeneraBandejasDA.iPageIndex = iPageIndex;
            objGeneraBandejasDA.iPageSize = iPageSize;
            Boolean AnsOK = objGeneraBandejasDA.ListadoPreliminarAltasPagDA();
            DSet = objGeneraBandejasDA.DSet;
            iRecordCountA = objGeneraBandejasDA.iRecordCountA;
            iRecordCount = objGeneraBandejasDA.iRecordCount;

            sMensajeError = objGeneraBandejasDA.sMensajeError;
            return (AnsOK);
        }
        /// <summary>
        /// Genera Listado Preliminar de Altas
        /// </summary>
        /// <returns></returns>
        public Boolean ListadoPreliminarEnvioAPS()
        {
            objGeneraBandejasDA.iIdConexion = iIdConexion;
            objGeneraBandejasDA.fFechaCorte = fFechaCorte;
            Boolean AnsOK = objGeneraBandejasDA.ListadoPreliminarAltasDA();
            DSet = objGeneraBandejasDA.DSet;
            iRecordCountA = objGeneraBandejasDA.iRecordCountA;
            iRecordCount = objGeneraBandejasDA.iRecordCount;

            sMensajeError = objGeneraBandejasDA.sMensajeError;
            return (AnsOK);
        }
        /// <summary>
        /// Genera Bandeja Preliminares de Altas, Modificaciones, Bajas (paginado)
        /// </summary>
        /// <returns></returns>
        public Boolean GeneraBandejaPreliminarPag()
        {
            objGeneraBandejasDA.iIdConexion = iIdConexion;
            objGeneraBandejasDA.fFechaCorte = fFechaCorte;
            objGeneraBandejasDA.iPageIndex = iPageIndex;
            objGeneraBandejasDA.iPageSize = iPageSize;
            objGeneraBandejasDA.cClaseEnvio = cClaseEnvio;
            Boolean AnsOK = objGeneraBandejasDA.GeneraBandejaPreliminarPagDA();
            DSet = objGeneraBandejasDA.DSet;
            iRecordCountA = objGeneraBandejasDA.iRecordCountA;
            iRecordCount = objGeneraBandejasDA.iRecordCount;

            sMensajeError = objGeneraBandejasDA.sMensajeError;
            return (AnsOK);
        }
        #endregion
    }
}