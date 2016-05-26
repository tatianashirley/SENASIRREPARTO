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
    public class clsProcedimientoValidoManualDA
    {
        string sMensajeError = "";
        Database db = null;
        public clsProcedimientoValidoManualDA()
        {
            db = DatabaseFactory.CreateDatabase("cnnsenarit");
        }
        public bool DatosProcedimientoValidoManual(int iIdConexion, string cOperacion, int iIdTramite, int iIdGrupoBeneficio,ref string sMensajeError, ref DataSet DSetTmp)
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
        public IDataReader ListaDetalleClasificador(int TipoClas)
        {
            DbCommand cmd = db.GetStoredProcCommand("Clasificador.PR_ListarDetalleClasificador", TipoClas);
            IDataReader dataReader = db.ExecuteReader(cmd);
            return dataReader;
        }
        public IDataReader DescripcionRuc(string RUC)
        {
            DbCommand cmd = db.GetStoredProcCommand("Clasificador.PR_Descripcion_RUC", RUC);
            IDataReader dataReader = db.ExecuteReader(cmd);
            return dataReader;
        }        
        public bool InsertaModificaComponentes(int iIdConexion, string cOperacion, int iIdTramite, int iIdGrupoBeneficio, int iComponente, string sRUC, int iIdTipoDocumento, string sPeriodoSalario, string sSalarioCotizable, string sSalarioCotizableActualizado, int iMonedaSalario, int ?iIdParametrizacion, string sGlosa, int iCertificado,string sSector, ref string sMensajeError)
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
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sSector", sSector);
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
        public IDataReader CalculoSalarioCotizableActualizado(int iIdTramite, int iIdGrupoBeneficio, string sFechaCalculo, string sTipoAct, string sPeriodoSalario, string sSalarioCotizable, string sRUC)
        {
            DbCommand cmd = db.GetStoredProcCommand("CertificacionCC.PR_CalculaSalarioCotizableAct_Tramite", iIdTramite, iIdGrupoBeneficio, sFechaCalculo, sTipoAct, sPeriodoSalario, sSalarioCotizable, sRUC,sMensajeError);
            IDataReader dataReader = db.ExecuteReader(cmd);
            return dataReader;
        }

        public bool EliminayAprueba_Certificacion(int iIdConexion, string cOperacion, int iIdTramite, int iIdGrupoBeneficio, int iVersion, string sRUC, int iComponente, ref string sMensajeError)
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

        public bool ApruebaRechaza_CCR(int iIdConexion, string cOperacion, int iIdTramite, int iIdGrupoBeneficio, int iVersion, string sRUC, int iComponente,int iEstadoAprobacion, ref string sMensajeError)
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
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iVersion", iVersion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iEstadoAprobacion", iEstadoAprobacion);


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
        public bool RecursoReclamacion(int iIdConexion, string cOperacion, int iIdTramite, int iIdGrupoBeneficio,int iVersion,int iComponente,int iAnulaCerti, ref string sMensajeError)
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
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iComponente", iComponente);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iAnulaCerti", iAnulaCerti);
                


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
        public bool AsignacionWFArticulador(int iIdConexion, string cOperacion, int iIdTramite, int iIdGrupoBeneficio,int iIdUsuarioSuperior,string sObservacion, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "CertificacionCC.PR_AsignarTramite_PorTramite", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdTramite", iIdTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdGrupoBeneficio", iIdGrupoBeneficio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdUsuarioAsignado", iIdUsuarioSuperior);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Observacion", sObservacion);
                


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
        public bool Rechaza_Certificacion(int iIdConexion, string cOperacion, int iIdTramite, int iIdGrupoBeneficio,  ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "CertificacionCC.PR_RechazarTramite_PorTramite", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdTramite", iIdTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdGrupoBeneficio", iIdGrupoBeneficio);
                
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
        public bool ObtenerTipoMoneda(int iIdConexion, string cOperacion, string sPeriodoSalario, ref string sMensajeError, ref DataSet DSetTmp)
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
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sPeriodoSalario", sPeriodoSalario);
                

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