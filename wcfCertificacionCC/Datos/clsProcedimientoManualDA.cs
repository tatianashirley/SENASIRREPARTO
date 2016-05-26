using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Configuration;
using System.Reflection;
using System.Globalization;
using System.Text;
using System.Xml;
using System.Resources;
using SQLSPExecuter;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace wcfCertificacionCC.Datos
{
    public class clsProcedimientoManualDA
    {
        string sMensajeError = "";
        Database db = null;
        public clsProcedimientoManualDA()
        {
            db = DatabaseFactory.CreateDatabase("cnnsenarit");
        }

        public bool CalculoAniosMeses(int iIdConexion, string cOperacion, string sFechaInicio, string sFechaFin, ref string sMensajeError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "CertificacionCC.PR_FormularioCalculoCC", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_FechaInicio", sFechaInicio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_FechaFin", sFechaFin);

                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                    else
                    {
                        DSetTmp = ObjSPExec.p_DataSetResultado;
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }
        public bool ComibolSalarioConvenio(int iIdConexion, string cOperacion, string sRUC,int iIdTramite,int iIdGrupoBeneficio, ref string sMensajeError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "CertificacionCC.PR_FormularioCalculoCC", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sRUC", sRUC);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTramite", iIdTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdGrupoBeneficio", iIdGrupoBeneficio);    

                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                    else
                    {
                        DSetTmp = ObjSPExec.p_DataSetResultado;
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }
        public bool ListaAprobaciones(int iIdConexion,string cOperacion, int iIdTramite,int  iIdGrupoBeneficio, int iVersion,ref string sMensajeError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "CertificacionCC.PR_SalarioCotizable", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTramite", iIdTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdGrupoBeneficio", iIdGrupoBeneficio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iVersion", iVersion);
                

                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                    else
                    {
                        DSetTmp = ObjSPExec.p_DataSetResultado;
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }
        public bool InsertaComponentes(int iIdConexion, string cOperacion, int iIdTramite, int iIdGrupoBeneficio, int iComponente, string sRUC, int iIdTipoDocumento, string sPeriodoSalario, string sSalarioCotizable, string sSalarioCotizableActualizado, int iMonedaSalario, int ?iIdParametrizacion, string sGlosa, int iCertificado,int iMitas,string sSector,string sDetalleGeneral, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "CertificacionCC.PR_SalarioCotizable", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTramite", iIdTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdGrupoBeneficio", iIdGrupoBeneficio);

                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sRUC", sRUC);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iComponente", iComponente);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTipoDocSalario", iIdTipoDocumento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sPeriodoSalario", sPeriodoSalario);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sSalarioCotizable", sSalarioCotizable);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sSalarioCotizableAct", sSalarioCotizableActualizado);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdMonedaSalario", iMonedaSalario);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdParametrizacion", iIdParametrizacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sGlosaSalario", sGlosa);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@b_bCertificacion", iCertificado);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iMitas", iMitas);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sSector", sSector);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sDescripcionGeneral", sDetalleGeneral);

                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoNonQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                        
                    }


                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }
        public bool ActualizaDensidad(int iIdConexion, string cOperacion, int iIdTramite, int iIdGrupoBeneficio, int iVersion, int iComponente, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "CertificacionCC.PR_SalarioCotizableParteII", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTramite", iIdTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdGrupoBeneficio", iIdGrupoBeneficio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iVersion", iVersion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iComponente", iComponente);
                
                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoNonQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();

                    }


                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }
        public bool DatosProcedimientoManual(int iIdConexion, string cOperacion, int iIdTramite, int iIdGrupoBeneficio, ref string sMensajeError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "CertificacionCC.PR_SalarioCotizable", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTramite", iIdTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdGrupoBeneficio", iIdGrupoBeneficio);

                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                    else
                    {
                        DSetTmp = ObjSPExec.p_DataSetResultado;
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }
        public bool ModificaOrdenComponente(int iIdConexion, string cOperacion, int iIdTramite, int iIdGrupoBeneficio, int iVersion, int iComponente, string sRUC,string cSubOperacion, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "CertificacionCC.PR_SalarioCotizable", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sSubOperacion", cSubOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTramite", iIdTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdGrupoBeneficio", iIdGrupoBeneficio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sRUC", sRUC);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iComponente", iComponente);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iVersion", iVersion);
                

                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoNonQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }


                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }

        public bool InsertaActualizacionCC(int iIdConexion, string cOperacion, int iIdTramite, int iIdGrupoBeneficio, int iVersion, int iComponente, string sRUC, string sFechaAfiliacion, string sFechaBaja,string sFechaAfiliacionAnt, string sFechaBajaAnt, int iPeriodoVerificado,int iIdParametrizacion, string sGlosa,int iAnio,int iMes, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "CertificacionCC.PR_ActualizacionCC_Manual", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);                
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTramite", iIdTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdGrupoBeneficio", iIdGrupoBeneficio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sRUC", sRUC);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iComponente", iComponente);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iVersion", iVersion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fFechaAfiliacion", sFechaAfiliacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fFechaBajaAfilia", sFechaBaja);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fFechaAfiliacionAnt", sFechaAfiliacionAnt);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fFechaBajaAfiliaAnt", sFechaBajaAnt);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_bPeriodoVerificado", iPeriodoVerificado);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdParametrizacion", iIdParametrizacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sGlosaCertificacion", sGlosa);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_mAnioCotiza", iAnio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_mMesesCotiza", iMes);

                
                

                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoNonQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }


                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }
        
        public bool ListaActualizacionCC(int iIdConexion,string  cOperacion,int iIdTramite,int iIdGrupoBeneficio,int iVersion,string sRuc,int iComponente, ref string sMensajeError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "CertificacionCC.PR_ActualizacionCC_Manual", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTramite", iIdTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdGrupoBeneficio", iIdGrupoBeneficio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sRUC", sRuc);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iComponente", iComponente);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iVersion", iVersion);

                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                    else
                    {
                        DSetTmp = ObjSPExec.p_DataSetResultado;
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }
        public bool Apruebaconinforme_Certificacion(int iIdConexion, string cOperacion, int iIdTramite, int iIdGrupoBeneficio, int iVersion, string sInforme, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "CertificacionCC.PR_SalarioCotizable", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTramite", iIdTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdGrupoBeneficio", iIdGrupoBeneficio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iVersion", iVersion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sInforme", sInforme);


                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoNonQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }


                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }
        public bool IngresaInforme(int iIdConexion, string cOperacion, int iIdTramite, int iIdGrupoBeneficio, int iVersion, string sInforme, int iIdTipoInforme,ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "CertificacionCC.PR_SalarioCotizable", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTramite", iIdTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdGrupoBeneficio", iIdGrupoBeneficio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iVersion", iVersion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_IdTipoInforme", iIdTipoInforme);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sInforme", sInforme);


                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoNonQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }


                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }
        public bool ActualizaInforme_Certificacion(int iIdConexion, string cOperacion, int iIdTramite, int iIdGrupoBeneficio, string sNroControl, string sInforme,int iIdTipoInforme, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "CertificacionCC.PR_SalarioCotizable", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTramite", iIdTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdGrupoBeneficio", iIdGrupoBeneficio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNroControl", sNroControl);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sInforme", sInforme);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_IdTipoInforme", iIdTipoInforme);


                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoNonQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }


                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }
        public bool EliminarInforme_Certificacion(int iIdConexion, string cOperacion, int iIdTramite, int iIdGrupoBeneficio, string sNroControl, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "CertificacionCC.PR_SalarioCotizable", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTramite", iIdTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdGrupoBeneficio", iIdGrupoBeneficio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNroControl", sNroControl);
                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoNonQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }


                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }
        public bool LevantaInforme_Certificacion(int iIdConexion, string cOperacion, int iIdTramite, int iIdGrupoBeneficio, string sNroControl, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "CertificacionCC.PR_SalarioCotizableParteII", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTramite", iIdTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdGrupoBeneficio", iIdGrupoBeneficio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNroControl", sNroControl);
                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoNonQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }


                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }

        public bool ListaInforme(int iIdConexion, string cOperacion, int iIdTramite, int iIdGrupoBeneficio, ref string sMensajeError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "CertificacionCC.PR_SalarioCotizable", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTramite", iIdTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdGrupoBeneficio", iIdGrupoBeneficio);


                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                    else
                    {
                        DSetTmp = ObjSPExec.p_DataSetResultado;
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }
        
        public bool ObtenerUltimoRUC(int iIdConexion,string cOperacion,int iIdTramite,int iIdGrupoBeneficio,int iVersion,int iComponente, ref string sMensajeError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "CertificacionCC.PR_ActualizacionCC_Manual", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTramite", iIdTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdGrupoBeneficio", iIdGrupoBeneficio);                
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iVersion", iVersion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iComponente", iComponente);

                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                    else
                    {
                        DSetTmp = ObjSPExec.p_DataSetResultado;
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }
       
    }


}