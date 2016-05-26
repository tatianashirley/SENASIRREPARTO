using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfReprocesos.Entidades;
using wcfReprocesos.Datos;
using System.Data;

namespace wcfReprocesos.Logica
{
    public class clsDatosAfiliado : clsDatosAfiliadoBE
    {
        #region "Declaración de funciones/Procedimientos Capa Logica"

        clsDatosAfiliadoDA objDatosAfiliadoDA = new clsDatosAfiliadoDA();

        /// <summary>
        /// Obtiene Datos del Afiliado (paginado)
        /// </summary>
        /// <returns></returns>
        public Boolean ObtieneDatosAfiliadoPag()
        {
            objDatosAfiliadoDA.iIdConexion = iIdConexion;
            objDatosAfiliadoDA.iPageIndex = iPageIndex;
            objDatosAfiliadoDA.iPageSize = iPageSize;
            objDatosAfiliadoDA.iIdTramite = iIdTramite;
            objDatosAfiliadoDA.sPrimerApellido = sPrimerApellido;
            objDatosAfiliadoDA.sSegundoApellido = sSegundoApellido;
            Boolean AnsOK = objDatosAfiliadoDA.ObtieneDatosAfiliadoPagDA();
            DSet = objDatosAfiliadoDA.DSet;
            iRecordCount = objDatosAfiliadoDA.iRecordCount;

            sMensajeError = objDatosAfiliadoDA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>
        /// Obtiene Datos Específicos de un Afiliado APS
        /// </summary>
        /// <returns></returns>
        public Boolean ObtieneDatosEspecificosAfiliado()
        {
            objDatosAfiliadoDA.iIdConexion = iIdConexion;
            objDatosAfiliadoDA.iNUP = iNUP;
            objDatosAfiliadoDA.iIdTramite = iIdTramite;
            objDatosAfiliadoDA.iIdGrupoBeneficio = iIdGrupoBeneficio;
            Boolean AnsOK = objDatosAfiliadoDA.ObtieneDatosEspecificosAfiliadoDA();
            DSet = objDatosAfiliadoDA.DSet;

            sMensajeError = objDatosAfiliadoDA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>
        /// Obtiene Estado del Beneficio
        /// </summary>
        /// <returns></returns>
        public Boolean ObtieneEstadoDelBeneficio()
        {
            objDatosAfiliadoDA.iIdConexion = iIdConexion;
            objDatosAfiliadoDA.iIdTramite = iIdTramite;
            objDatosAfiliadoDA.iIdGrupoBeneficio = iIdGrupoBeneficio;
            Boolean AnsOK = objDatosAfiliadoDA.ObtieneEstadoDelBeneficioDA();
            DSet = objDatosAfiliadoDA.DSet;

            sMensajeError = objDatosAfiliadoDA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>
        /// Obtiene Datos Recalculo
        /// </summary>
        /// <returns></returns>
        public Boolean ObtieneDatosRecalculo()
        {
            objDatosAfiliadoDA.iIdConexion = iIdConexion;
            objDatosAfiliadoDA.iIdTramite = iIdTramite;
            objDatosAfiliadoDA.iIdGrupoBeneficio = iIdGrupoBeneficio;
            objDatosAfiliadoDA.fFechaCalc = fFechaCalc;
            Boolean AnsOK = objDatosAfiliadoDA.ObtieneDatosRecalculoDA();
            DSet = objDatosAfiliadoDA.DSet;

            sMensajeError = objDatosAfiliadoDA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>
        /// Obtiene Salario Cotizable y Actualización CC
        /// </summary>
        /// <returns></returns>
        public Boolean ObtieneSalarioCotizable()
        {
            objDatosAfiliadoDA.iIdConexion = iIdConexion;
            objDatosAfiliadoDA.iIdTramite = iIdTramite;
            objDatosAfiliadoDA.iIdGrupoBeneficio = iIdGrupoBeneficio;
            Boolean AnsOK = objDatosAfiliadoDA.ObtieneSalarioCotizableDA();
            DSet = objDatosAfiliadoDA.DSet;

            sMensajeError = objDatosAfiliadoDA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>
        /// Obtiene Datos de los EnviosAPS por Tramite
        /// </summary>
        /// <returns></returns>
        public Boolean ObtieneDatosEnviosAPSxTramite()
        {
            objDatosAfiliadoDA.iIdConexion = iIdConexion;
            objDatosAfiliadoDA.iIdTramite = iIdTramite;
            objDatosAfiliadoDA.iIdTipoTramite = iIdTipoTramite;
            objDatosAfiliadoDA.iNroCertificado = iNroCertificado;
            Boolean AnsOK = objDatosAfiliadoDA.ObtieneDatosEnviosAPSxTramiteDA();
            DSet = objDatosAfiliadoDA.DSet;

            sMensajeError = objDatosAfiliadoDA.sMensajeError;
            return (AnsOK);
        }
        #endregion
    }
}