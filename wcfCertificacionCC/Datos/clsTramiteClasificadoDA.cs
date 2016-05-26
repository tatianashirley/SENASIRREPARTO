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

namespace wcfCertificacionCC.Datos
{
    public class clsTramiteClasificadoDA
    {
        string sMensajeError = "";

        public bool ListarTramitesClasificados(int iIdConexion, string cOperacion, string sSessionTrabajo, string sSNN, ref string sMensajeError,
            DateTime FechaInicio, DateTime FechaFin, int clasinicio, int clasfin, int numregistros, string NumeroDocumento, int CUA, string Tramite, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "CertificacionCC.PR_ListarTramitesClasificados", cOperacion);
            ObjSPExec.p_RemplazarCeroPorDBNull = false;

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", sSessionTrabajo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@o_sMensajeError", sMensajeError);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@FechaInicio", FechaInicio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@FechaFin", FechaFin);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@clasinicio", clasinicio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@clasfin", clasfin);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@numregistros", numregistros);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NumeroDocumento", NumeroDocumento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@CUA", CUA);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Tramite", Tramite);

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

        public bool ListarClasificacionTramite(int iIdConexion,string cOperacion,ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "CertificacionCC.PR_ListarClasificacionTramite", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                //bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                //bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                //bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", sSessionTrabajo);
                //bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@o_sMensajeError", sMensajeError);
                //bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@FechaInicio", FechaInicio);
                //bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@FechaFin", FechaFin);
                //bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@clasinicio", clasinicio);
                //bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@clasfin", clasfin);
                //bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@numregistros", numregistros);
                //bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NumeroDocumento", NumeroDocumento);
                //bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@CUA", CUA);
                //bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Tramite", Tramite);

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

        public bool ReClasificarTramite(int iIdConexion, string cOperacion, string sSessionTrabajo, string sSNN, ref string sMensajeError, int IdTramiteClasificado, int IdClasificacionTramite)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "CertificacionCC.PR_ReClasificarTramite", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", sSessionTrabajo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", sSNN);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@o_sMensajeError", sMensajeError);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdTramiteClasificado", IdTramiteClasificado);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdClasificacionTramite", IdClasificacionTramite);


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

        public bool ListarTramitesNoAsigna(int iIdConexion, string cOperacion, string sSessionTrabajo, string sSNN, ref string sMensajeError, int ClasificacionTramite, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "CertificacionCC.PR_ListarTramitesNoAsigna", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;

                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", sSessionTrabajo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", sSNN);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@o_sMensajeError", sMensajeError);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdClasificacionTramite", ClasificacionTramite);

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