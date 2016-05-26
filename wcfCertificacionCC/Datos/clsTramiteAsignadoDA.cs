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
    public class clsTramiteAsignadoDA
    {
        string sMensajeError = "";

        public bool ListarTramitesNoAsignados(int iIdConexion, string cOperacion, string sSessionTrabajo, string sSNN, ref string sMensajeError,
            DateTime FechaInicio, DateTime FechaFin, int clasinicio, int clasfin, int numregistros, string NumeroDocumento, int CUA, string Tramite, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "CertificacionCC.PR_ListarTramitesNoAsigna", cOperacion);
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

        public bool ListarTramitesAsignados(int iIdConexion, string cOperacion, string sSessionTrabajo, string sSNN, ref string sMensajeError,
            DateTime FechaInicio, DateTime FechaFin, int clasinicio, int clasfin, int numregistros, string NumeroDocumento, int CUA, string Tramite, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "CertificacionCC.PR_ListarTramitesAsignados", cOperacion);
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

        public bool ListarTramitesEnAT(int iIdConexion, string cOperacion, string sSessionTrabajo, string sSNN, ref string sMensajeError,
                    DateTime FechaInicio, DateTime FechaFin, int numregistros, string NumeroDocumento, int CUA, string Tramite, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "CertificacionCC.PR_ListarTramitesEnAT", cOperacion);
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

        public bool ListarTramitesAsignados_ParaAT(int iIdConexion, string cOperacion, string sSessionTrabajo, string sSNN, ref string sMensajeError,
                    DateTime FechaInicio, DateTime FechaFin,int clasinicio, int clasfin, int numregistros, string NumeroDocumento, int CUA, string Tramite, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "CertificacionCC.PR_ListarTramitesAsignados_ParaAT", cOperacion);
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

        public bool ListarTramitesReasigna(int iIdConexion, string cOperacion, string sSessionTrabajo, string sSNN, ref string sMensajeError,
                    DateTime FechaInicio, DateTime FechaFin, int clasinicio, int clasfin, int numregistros, string NumeroDocumento, int CUA, string Tramite, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "CertificacionCC.PR_ListarTramitesReasigna", cOperacion);
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
        public bool ListaEquiposDeTrabajoOPersonalizada(int iIdConexion, string cOperacion, ref string sMensajeError, ref DataSet DSetTmp)
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
        public bool ListaParametrosWF(int iIdConexion,string cOperacion,int iIdTramite,int iIdGrupoBeneficio, ref string sMensajeError, ref DataSet DSetTmp)
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
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@iIdTramite", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@iIdGrupoBeneficio", cOperacion);


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

        public bool AsignaTramite(int iIdConexion, string cOperacion, int IdUsuario, int IdRol,int IdTramiteClasificado,string sObservaciones, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "CertificacionCC.PR_AsignarTramite", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdUsuario", IdUsuario);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdRol", IdRol);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdTramiteClasificado", IdTramiteClasificado);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Observacion", sObservaciones);
                

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

        public bool AsignaTramitePorTramite(int iIdConexion, string cOperacion, int IdTramite, int IdGrupoBeneficio, int IdUsuarioAsignado, string sObservaciones, ref string sMensajeError)
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
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdTramite", IdTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdGrupoBeneficio", IdGrupoBeneficio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdUsuarioAsignado", IdUsuarioAsignado);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Observacion", sObservaciones);


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

        public bool AsignarTramite_Usuario_Articulador(int iIdConexion, string cOperacion, int IdUsuario, int IdRol, int IdTramiteClasificado, string sObservaciones, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "CertificacionCC.PR_AsignarTramite_Usuario_Articulador", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdUsuario", IdUsuario);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdRol", IdRol);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdTramiteClasificado", IdTramiteClasificado);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Observacion", sObservaciones);


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
        public bool AsignaTramite_Revisor(int iIdConexion, string cOperacion, int IdUsuarioRevisor, int IdRol, int IdTramiteClasificado, string sObservaciones, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "CertificacionCC.PR_AsignarTramite_Revisor", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdUsuarioRevisor", IdUsuarioRevisor);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdRol", IdRol);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdTramiteClasificado", IdTramiteClasificado);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Observacion", sObservaciones);


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

        public bool AsignaTramite_Revisor_Articulador(int iIdConexion, string cOperacion, int IdUsuarioRevisor, int IdRol, int IdTramiteClasificado, string sObservaciones, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "CertificacionCC.PR_AsignarTramite_Revisor_Articulador", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdUsuarioRevisor", IdUsuarioRevisor);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdRol", IdRol);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdTramiteClasificado", IdTramiteClasificado);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Observacion", sObservaciones);


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

        public bool DevuelveTramite_AT(int iIdConexion, string cOperacion, int IdTramiteAsignado, DateTime FechaDevolucion, string @ObservacionDevolucion, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "CertificacionCC.PR_DevuelveTramite_AT", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@o_sMensajeError", sMensajeError);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdTramiteAsignado", IdTramiteAsignado);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@FechaDevolucion", FechaDevolucion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@ObservacionDevolucion", @ObservacionDevolucion);


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

        public bool UsuariosAsignaPorTipo(int iIdConexion, string cOperacion, string TipoUsuario, ref string sMensajeError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "CertificacionCC.PR_UsuariosAsignaPorTipo", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@TipoUsuario", TipoUsuario);


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

        public bool AsignaTramite_DesdeAT(int iIdConexion, int IdTramiteAsignado, int IdRolUsuarioAsignado, string ObservacionDevolucion, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "CertificacionCC.PR_AsignaTramite_DesdeAT", "I");
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@o_sMensajeError", sMensajeError);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdTramiteAsignado", IdTramiteAsignado);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdRolUsuarioAsignado", IdRolUsuarioAsignado);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@ObservacionDevolucion", ObservacionDevolucion);


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

        public bool ReAsignaTramite_DesdeAT(int iIdConexion, int IdTramiteAsignado, int IdRolUsuarioAsignado, string ObservacionDevolucion, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "CertificacionCC.PR_ReAsignaTramite_DesdeAT", "I");
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@o_sMensajeError", sMensajeError);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdTramiteAsignado", IdTramiteAsignado);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdRolUsuarioAsignado", IdRolUsuarioAsignado);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@ObservacionDevolucion", ObservacionDevolucion);


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

        public bool ReAsignaTramite(int iIdConexion, int IdTramiteAsignado, int IdRolUsuarioAsignado, string ObservacionDevolucion, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "CertificacionCC.PR_ReAsignarTramite", "I");
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@o_sMensajeError", sMensajeError);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdTramiteAsignado", IdTramiteAsignado);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdRolUsuarioAsignado", IdRolUsuarioAsignado);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@ObservacionDevolucion", ObservacionDevolucion);


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
    }
}