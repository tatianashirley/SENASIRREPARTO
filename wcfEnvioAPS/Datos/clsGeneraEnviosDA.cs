using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfEnvioAPS.Entidades;
using SQLSPExecuter;

namespace wcfEnvioAPS.Datos
{
    public class clsGeneraEnviosDA : clsEnvioAPSBaseDA
    {
        #region "Declaración de variables o parametros para las funciones/Procedimientos Capa Datos"
        public string fFechaCorte { get; set; }
        public string sNumeroResolucionA { get; set; }
        public string fFechaResolucionA { get; set; }
        public string sNumeroResolucionM { get; set; }
        public string fFechaResolucionM { get; set; }
        public string sLoteCertificados { get; set; }
        public string sNumeroEnvio { get; set; }
        public int iFila { get; set; }
        public int iIdEntidad { get; set; }
        #endregion

        #region "Declaración de funciones/Procedimientos Capa Datos"
        /// <summary>
        /// Realiza la Generación de Envios APS (Alta) x Certificado
        /// </summary>
        /// <returns></returns>
        public bool AltaGeneraEnvioXcertificadoDA()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "EnvioMedios.PR_EnvioAPS_GeneraEnvios", "A");
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "A");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);

                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fFechaCorte", fFechaCorte);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNumeroResolucionA", sNumeroResolucionA);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fFechaResolucionA", fFechaResolucionA);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNumeroResolucionM", sNumeroResolucionM);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fFechaResolucionM", fFechaResolucionM);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sLoteCertificados", sLoteCertificados);
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
        /// Realiza la Generación de Envios APS (Modificacion) x Certificado
        /// </summary>
        /// <returns></returns>
        public bool ModificacionGeneraEnvioXcertificadoDA()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "EnvioMedios.PR_EnvioAPS_GeneraEnvios", "M");
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "M");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);

                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fFechaCorte", fFechaCorte);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sLoteCertificados", sLoteCertificados);
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
        /// Realiza la Generación de Envios APS (Baja) x Certificado
        /// </summary>
        /// <returns></returns>
        public bool BajasGeneraEnvioXcertificadoDA()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "EnvioMedios.PR_EnvioAPS_GeneraEnvios", "B");
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

                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fFechaCorte", fFechaCorte);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sLoteCertificados", sLoteCertificados);
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
        /// Realiza la Exclusión de Certificados de Envios APS generados
        /// </summary>
        /// <returns></returns>
        public bool ExcluyeCertificadoMedioEnvioAPSDA()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "EnvioMedios.PR_EnvioAPS_GeneraEnvios", "E");
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "E");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);

                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNumeroEnvio", sNumeroEnvio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iFila", iFila);
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
        /// Obtiene Detalle Reporte RMCC01
        /// </summary>
        /// <returns></returns>
        public bool ObtieneDetalleEnvioDA()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "EnvioMedios.PR_EnvioAPS_GeneraEnvios", "R");
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "R");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);

                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNumeroEnvio", sNumeroEnvio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdEntidad", iIdEntidad);
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