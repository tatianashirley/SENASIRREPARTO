using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfReprocesos.Entidades;
using wcfReprocesos.Datos;
using System.Data;

namespace wcfReprocesos.Logica
{
    public class clsRECLAMACIONES : clsRECLAMACIONESBE
    {
        #region "Declaración de funciones/Procedimientos Capa Logica"

        clsRECLAMACIONESDA objRECLAMACIONESDA = new clsRECLAMACIONESDA();

        /// <summary>
        /// Obtiene Salario Cotizable
        /// </summary>
        /// <returns></returns>
        public Boolean ObtieneSalarioCotizable()
        {
            objRECLAMACIONESDA.iIdConexion = iIdConexion;
            objRECLAMACIONESDA.iIdTramite = iIdTramite;
            objRECLAMACIONESDA.iIdGrupoBeneficio = iIdGrupoBeneficio;
            Boolean AnsOK = objRECLAMACIONESDA.ObtieneSalarioCotizableDA();
            DSet = objRECLAMACIONESDA.DSet;

            sMensajeError = objRECLAMACIONESDA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>
        /// Cambia de Estado a Salario Cotizable para su Reproceso
        /// </summary>
        /// <returns></returns>
        public Boolean HabilitaCertificacion()
        {
            objRECLAMACIONESDA.iIdConexion = iIdConexion;
            objRECLAMACIONESDA.iIdTramite = iIdTramite;
            objRECLAMACIONESDA.iIdGrupoBeneficio = iIdGrupoBeneficio;
            objRECLAMACIONESDA.iNroCertificado = iNroCertificado;
            objRECLAMACIONESDA.iIdTipoTramite = iIdTipoTramite;
            objRECLAMACIONESDA.iIdUsuario = iIdUsuario;
            objRECLAMACIONESDA.iNroFormularioRepro = iNroFormularioRepro;
            Boolean AnsOK = objRECLAMACIONESDA.HabilitaCertificacionDA();
            DSet = objRECLAMACIONESDA.DSet;

            sMensajeError = objRECLAMACIONESDA.sMensajeError;
            return (AnsOK);
        }
        #endregion
    }
}