using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Globalization;
using System.Text;
using System.Xml;
using System.Data.Common;
using System.Resources;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using SQLSPExecuter;
namespace wcfNotificacion.Datos
{
    public class clsRegistroDocumentosDA
    {
        Database db = null;

        public clsRegistroDocumentosDA()
        {
            db = DatabaseFactory.CreateDatabase("cnnsenarit");
        }

        public bool ObtieneDatos(int iIdConexion, string cOperacion,string Matricula, string Tramite, string NroDocumento, string PrimerApellido, string SegundoApellido, string Nombre, ref string sMensajeError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Notificacion.PR_Notificacion", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                //bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Tipo", Tipo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Tramite", Tramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Matricula", Matricula);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Carnet", NroDocumento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Paterno", PrimerApellido);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Materno", SegundoApellido);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Nombre", Nombre);

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

        public bool ddlDocumentos(int iIdConexion, string cOperacion, Int32 Area, ref string sMensajeError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Notificacion.PR_Consultas", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Area", Area);

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

        public bool DatosDocumento(int iIdConexion, string cOperacion, Int32 IdDoc, ref string sMensajeError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Notificacion.PR_Consultas", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdDoc", IdDoc);

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

        public bool RegistraDocumento(int iIdConexion, string cOperacion/*,string Tipo*/, Int64 Tramite, int IdGrupobeneficio, string FechaDocumento, int NroDocumento, int IdDocumento,ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Notificacion.PR_Notificacion", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                //bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Tipo", Tipo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTramite", Tramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdGrupoBeneficio", IdGrupobeneficio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Fecha", FechaDocumento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iNroDocumento", NroDocumento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdDocumento", IdDocumento);
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

        public bool RegistraDocumento(int iIdConexion, string cOperacion, /*string Tipo,*/ Int64 Tramite, int IdGrupobeneficio,string Obs, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Notificacion.PR_Notificacion", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                //bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Tipo", Tipo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTramite", Tramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdGrupoBeneficio", IdGrupobeneficio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Obs", Obs);
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

        public bool ObtieneDatos(int iIdConexion, string cOperacion, Int64 Tramite, int GrupoBeneficio,ref string sMensajeError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Notificacion.PR_Notificacion", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                //bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Tipo", Tipo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTramite", Tramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdGrupoBeneficio", GrupoBeneficio);

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

        public bool ActualizaDocumento(int iIdConexion, string cOperacion,/* string Tipo,*/Int64 Tramite, int GrupoBeneficio, int IdDocumento, string FechaDocumento,int NroDocumento,string FechaNot,string Obs,int IdTipoNotificacion,ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Notificacion.PR_Notificacion", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                //bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Tipo", Tipo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTramite", Tramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdGrupoBeneficio", GrupoBeneficio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Fecha", FechaDocumento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdDocumento", IdDocumento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iNroDocumento", NroDocumento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@FecNot", FechaNot);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Obs", Obs);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTipoNotificacion", IdTipoNotificacion);

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
        public bool ModificaDatos(int iIdConexion, string cOperacion, /*string Tipo,*/ Int64 Tramite, int GrupoBeneficio, int IdDocumento, string FechaDocumento, int NroDocumento, string FechaNot, string FechaRec, ref string sMensajeError)
        {   
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Notificacion.PR_Notificacion", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                //bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Tipo", Tipo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTramite", Tramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdGrupoBeneficio", GrupoBeneficio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Fecha", FechaDocumento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdDocumento", IdDocumento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iNroDocumento", NroDocumento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@FecNot", FechaNot);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@FecRec", FechaRec);

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

        public bool RegistraNotas(int iIdConexion, string cOperacion, Int64 Tramite, int IdGrupobeneficio, string FechaDocumento, int NroDocumento, int IdDocumento,string FechaNot,string Obs, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Notificacion.PR_Consultas", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                //bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Tipo", Tipo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTramite", Tramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdGrupoBeneficio", IdGrupobeneficio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Fecha", FechaDocumento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iNroDocumento", NroDocumento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdDocumento", IdDocumento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@FecNoti", FechaNot);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Obs", Obs);
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