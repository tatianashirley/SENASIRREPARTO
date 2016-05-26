using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfReprocesos.Entidades;
using wcfReprocesos.Datos;
using System.Data;

namespace wcfReprocesos.Logica
{
    public class clsDS28888 : clsDS28888BE
    {
        #region "Declaración de funciones/Procedimientos Capa Logica"

        clsDS28888DA objDS8888DA = new clsDS28888DA();

        /// <summary>
        /// Obtiene Salario Cotizable
        /// </summary>
        /// <returns></returns>
        public Boolean ObtieneSalarioCotizable()
        {
            objDS8888DA.iIdConexion = iIdConexion;
            objDS8888DA.iIdTramite = iIdTramite;
            objDS8888DA.iIdGrupoBeneficio = iIdGrupoBeneficio;
            Boolean AnsOK = objDS8888DA.ObtieneSalarioCotizableDA();
            DSet = objDS8888DA.DSet;

            sMensajeError = objDS8888DA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>
        /// Cambia de Estado a Salario Cotizable para su Reproceso
        /// </summary>
        /// <returns></returns>
        public Boolean HabilitaCertificacion()
        {
            objDS8888DA.iIdConexion = iIdConexion;
            objDS8888DA.iIdTramite = iIdTramite;
            objDS8888DA.iIdGrupoBeneficio = iIdGrupoBeneficio;
            objDS8888DA.iNroCertificado = iNroCertificado;
            objDS8888DA.iIdTipoTramite = iIdTipoTramite;
            objDS8888DA.iIdUsuario = iIdUsuario;
            objDS8888DA.iNroFormularioRepro = iNroFormularioRepro;
            Boolean AnsOK = objDS8888DA.HabilitaCertificacionDA();
            DSet = objDS8888DA.DSet;

            sMensajeError = objDS8888DA.sMensajeError;
            return (AnsOK);
        }
        #endregion
    }
}