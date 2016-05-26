using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfReprocesos.Entidades;
using wcfReprocesos.Datos;
using System.Data;

namespace wcfReprocesos.Logica
{
    public class clsReprocesoCC : clsReprocesoCCBE
    {
        #region "Declaración de funciones/Procedimientos Capa Logica"

        clsReprocesoCCDA objReprocesoCCDA = new clsReprocesoCCDA();

        public DataTable ImprimeCertificados()
        {
            objReprocesoCCDA.iIdConexion = iIdConexion;
            objReprocesoCCDA.iIdTramite = iIdTramite;
            objReprocesoCCDA.iIdGrupoBeneficio = iIdGrupoBeneficio;
            DataTable objDataTable = new DataTable();
            objDataTable=objReprocesoCCDA.ImprimeCertificadosDA();
            return objDataTable;
        }

        /// <summary>
        /// Lista Tipos Reprocesos
        /// </summary>
        /// <returns></returns>
        public Boolean ListaTiposReprocesos()
        {
            objReprocesoCCDA.iIdConexion = iIdConexion;
            Boolean AnsOK = objReprocesoCCDA.ListaTiposReprocesosDA();
            DSet = objReprocesoCCDA.DSet;

            sMensajeError = objReprocesoCCDA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>
        /// Lista Estados Reprocesos
        /// </summary>
        /// <returns></returns>
        public Boolean ListaEstadosReprocesos()
        {
            objReprocesoCCDA.iIdConexion = iIdConexion;
            Boolean AnsOK = objReprocesoCCDA.ListaEstadosReprocesosDA();
            DSet = objReprocesoCCDA.DSet;

            sMensajeError = objReprocesoCCDA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>
        /// Inserta Formulario Reprocesos
        /// </summary>
        /// <returns></returns>
        public Boolean InsertaFormularioReproceso()
        {
            objReprocesoCCDA.iNumeroResolucion = iNumeroResolucion;
            objReprocesoCCDA.iFechaResolucion = iFechaResolucion;
            objReprocesoCCDA.iIdConexion = iIdConexion;
            objReprocesoCCDA.iIdTramite = iIdTramite;
            objReprocesoCCDA.iNUP = iNUP;
            objReprocesoCCDA.iIdTipoTramite = iIdTipoTramite;
            objReprocesoCCDA.iIdGrupoBeneficio = iIdGrupoBeneficio;
            //objReprocesoCCDA.iNoFormularioCalculo = iNoFormularioCalculo;
            //objReprocesoCCDA.fFechaCalculo = fFechaCalculo;
            //objReprocesoCCDA.dMontoCCAceptado = dMontoCCAceptado;
            //objReprocesoCCDA.dSalarioCotizableActualizadoTotal = dSalarioCotizableActualizadoTotal;
            //objReprocesoCCDA.dDensidadTotal = dDensidadTotal;
            //objReprocesoCCDA.iSIP_impresion = iSIP_impresion;
            //objReprocesoCCDA.bRegistroAPS = bRegistroAPS;
            //objReprocesoCCDA.bCursoPago = bCursoPago;
            objReprocesoCCDA.iIdUsuario = iIdUsuario;
            objReprocesoCCDA.iNroCertificado = iNroCertificado;
            //objReprocesoCCDA.iIdTipoCC = iIdTipoCC;
            objReprocesoCCDA.cCodigoReproceso = cCodigoReproceso;
            Boolean AnsOK = objReprocesoCCDA.InsertaFormularioReprocesoDA();
            DSet = objReprocesoCCDA.DSet;
            iNroFormularioRepro = objReprocesoCCDA.iNroFormularioRepro;

            sMensajeError = objReprocesoCCDA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>
        /// Cancela Formulario Reprocesos
        /// </summary>
        /// <returns></returns>
        public Boolean CancelaFormularioReproceso()
        {
            objReprocesoCCDA.iIdConexion = iIdConexion;
            objReprocesoCCDA.iIdTramite = iIdTramite;
            objReprocesoCCDA.iIdGrupoBeneficio = iIdGrupoBeneficio;
            Boolean AnsOK = objReprocesoCCDA.CancelaFormularioReprocesoDA();
            DSet = objReprocesoCCDA.DSet;

            sMensajeError = objReprocesoCCDA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>
        /// Obtiene Detalle de un Formulario de Reproceso
        /// </summary>
        /// <returns></returns>
        public Boolean ObtieneFormReproDetalle()
        {
            objReprocesoCCDA.iIdConexion = iIdConexion;
            objReprocesoCCDA.iNroFormularioRepro = iNroFormularioRepro;
            Boolean AnsOK = objReprocesoCCDA.ObtieneFormReproDetalleDA();
            DSet = objReprocesoCCDA.DSet;

            sMensajeError = objReprocesoCCDA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>
        /// Obtiene Formularios de Reprocesos
        /// </summary>
        /// <returns></returns>
        public Boolean ObtieneFormulariosReprocesos()
        {
            objReprocesoCCDA.iIdConexion = iIdConexion;
            objReprocesoCCDA.iIdTramite = iIdTramite;
            objReprocesoCCDA.iIdGrupoBeneficio = iIdGrupoBeneficio;
            Boolean AnsOK = objReprocesoCCDA.ObtieneFormulariosReprocesosDA();
            DSet = objReprocesoCCDA.DSet;

            sMensajeError = objReprocesoCCDA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>
        /// Busca Formularios de Reprocesos
        /// </summary>
        /// <returns></returns>
        public Boolean BuscaFormulariosReprocesos()
        {
            objReprocesoCCDA.iIdConexion = iIdConexion;
            objReprocesoCCDA.sIdTramite = sIdTramite;
            objReprocesoCCDA.iIdEstadoReproceso = iIdEstadoReproceso;
            objReprocesoCCDA.iIdTipoReproceso = iIdTipoReproceso;
            objReprocesoCCDA.bBandejaTrabajo = bBandejaTrabajo;
            Boolean AnsOK = objReprocesoCCDA.BuscaFormulariosReprocesosDA();
            DSet = objReprocesoCCDA.DSet;

            sMensajeError = objReprocesoCCDA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>
        /// Obtiene un Formulario de Reproceso Específico
        /// </summary>
        /// <returns></returns>
        public Boolean ObtieneFormularioReprocesoEspecifico()
        {
            objReprocesoCCDA.iIdConexion = iIdConexion;
            objReprocesoCCDA.iNroFormularioRepro = iNroFormularioRepro;
            Boolean AnsOK = objReprocesoCCDA.ObtieneFormularioReprocesoEspecificoDA();
            DSet = objReprocesoCCDA.DSet;

            sMensajeError = objReprocesoCCDA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>
        /// Obtiene Salario Cotizable Trámite de un Formulario de Reproceso Específico
        /// </summary>
        /// <returns></returns>
        public Boolean ObtieneSalarioCotizable()
        {
            objReprocesoCCDA.iIdConexion = iIdConexion;
            objReprocesoCCDA.iNroFormularioRepro = iNroFormularioRepro;
            Boolean AnsOK = objReprocesoCCDA.ObtieneSalarioCotizableDA();
            DSet = objReprocesoCCDA.DSet;

            sMensajeError = objReprocesoCCDA.sMensajeError;
            return (AnsOK);
        }
        #endregion
    }
}