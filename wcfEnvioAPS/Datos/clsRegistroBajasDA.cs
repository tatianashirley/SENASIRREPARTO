using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfEnvioAPS.Entidades;
using SQLSPExecuter;

namespace wcfEnvioAPS.Datos
{
    public class clsRegistroBajasDA : clsEnvioAPSBaseDA
    {
        #region "Declaración de variables o parametros para las funciones/Procedimientos Capa Datos"
        //public string sIdConcepto { get; set; }
        public Int32 iNroCertificado { get; set; }
        public Int32 iIdTipoTramite { get; set; }
        public Int64 iNUP { get; set; }
        public string sNumeroResolucionA { get; set; }
        public string fFechaResolucionA { get; set; }
        public string mensaje { get; set; }
        public Boolean bAprueba { get; set; }
        #endregion

        #region "Declaración de funciones/Procedimientos Capa Datos"
        /// <summary>
        /// Registra Bajas
        /// </summary>
        /// <returns></returns>
        public bool RegistraBajaCertificadoDA()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Novedades.PR_Form05Ins", "I");
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "I");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);

                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NroCertificado", iNroCertificado);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdTipoTramite", iIdTipoTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NumRa", sNumeroResolucionA);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@FechaRa", fFechaResolucionA);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Aprueba", bAprueba);
                //sMensajeError = ObjSPExec.ObtenerPilaMensajesError();

                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                    else
                    {
                        string varMensaje="";
                        //DSet = ObjSPExec.p_DataSetResultado;
                        ObjSPExec.ObtenerValorParametro("@mensaje", ref varMensaje);
                        mensaje = varMensaje;
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }

        /// <summary>
        /// Selecciona Historial de Envios APS
        /// </summary>
        /// <returns></returns>
        public bool SeleccionaHistorialEnviosAPSDA()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "EnvioMedios.PR_EnvioAPS_RegistroBajas", "B");
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "B");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);

                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iNroCertificado", iNroCertificado);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTipoTramite", iIdTipoTramite);
                //bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTramite", iIdTramite);
                //bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fFechaDesde", fFechaDesde);
                //bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fFechaHasta", fFechaHasta);
                //bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNombreAsegurado", sNombreAsegurado);
                //sMensajeError = ObjSPExec.ObtenerPilaMensajesError();

                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                    else
                    {
                        DSet = ObjSPExec.p_DataSetResultado;
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }

        /// <summary>
        /// Selecciona datos de Pagos de un Certificado
        /// </summary>
        /// <returns></returns>
        public bool SeleccionaDatosPagosCertificadoDA()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "EnvioMedios.PR_EnvioAPS_RegistroBajas", "V");
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "V");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);

                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iNroCertificado", iNroCertificado);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iNUP", iNUP);
                //bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fFechaDesde", fFechaDesde);
                //bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fFechaHasta", fFechaHasta);
                //bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNombreAsegurado", sNombreAsegurado);
                //sMensajeError = ObjSPExec.ObtenerPilaMensajesError();

                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                    else
                    {
                        DSet = ObjSPExec.p_DataSetResultado;
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }

        #endregion
    }
}