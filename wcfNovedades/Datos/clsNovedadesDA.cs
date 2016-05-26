using System;
using System.Data;
using System.Globalization;
using System.Text;
using System.Xml;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data.SqlClient;
using System.Resources;
using System.Collections.Generic;
using System.Configuration;

//using wcfNovedades.Entidades;
using SQLSPExecuter;

namespace wcfNovedades.Datos
{
    public class clsNovedadesDA
    {
         Database db = null;
         string sMensajeError = "";
         
        //wcfSeguridad.Datos.cla

         public clsNovedadesDA()
        {
            db = DatabaseFactory.CreateDatabase("cadena");
        }

         /* Lista Clasificador por Tipos */
         public IDataReader ListarClasifporTipo(int tipoclasificador)
         {
             DbCommand cmd = db.GetStoredProcCommand("Novedades.PR_ListarClasifporTipo", tipoclasificador);
             IDataReader dataReader = db.ExecuteReader(cmd);
             return dataReader;
         }

         /* Lista tipos de Tipos de Novedades*/
         public IDataReader ListarNovedadesPorTipo(int CodTipo, DateTime fechainicio, DateTime fechafin,string estado)
         {
             DbCommand cmd = db.GetStoredProcCommand("Novedades.PR_ListarNovedadesTipo", CodTipo, fechainicio, fechafin,estado);
             IDataReader dataReader = db.ExecuteReader(cmd);
             return dataReader;
         }

         public bool ListarNovedadesPorTipo1(string cOperacion, int iIdConexion, ref string sMensajeError, int CodTipo, DateTime fechainicio, DateTime fechafin, string estado, ref DataSet DSetTmp)
         {
             ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Novedades.PR_ListarNovedadesTipo", cOperacion);
             //ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "CertificacionCC.PR_ListarTramitesNoAsigna", cOperacion);

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
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdTipoActualizacion", CodTipo);
                 
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@fechainicio", fechainicio);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@fechafin", fechafin);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@estado", estado);
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

         /* Lista tipos de Tipos de Novedades*/
         public IDataReader ListarNovedadesporCUA(string cua, string estado)
         {
             DbCommand cmd = db.GetStoredProcCommand("Novedades.PR_ListarNovedadesporCUA", cua, estado);
             IDataReader dataReader = db.ExecuteReader(cmd);
             return dataReader;
         }

         public bool ListarNovedadesporCUA1(string cOperacion, int iIdConexion, string cua, string estado, ref DataSet DSetTmp)
         {
             ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Novedades.PR_ListarNovedadesporCUA", cOperacion);

             if (!ObjSPExec.p_bEstadoOK)
             {
                 sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
             }
             else
             {
                 bool bAsignacionOK = true;
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@cua", cua);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@estado", estado);
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

         public bool ApruebaNovedad(int iIdConexion, string cOperacion, string sSessionTrabajo, string sSNN, ref string sMensajeError,
                     int IdActualizacion, int Estado, string DocumentoAprobacion, string IdUsuarioAprobacion, ref string mensaje)
         {
             ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Novedades.PR_NovedadesApRec", "U");
             if (!ObjSPExec.p_bEstadoOK)
             {
                 sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
             }
             else
             {
                 bool bAsignacionOK = true;
                 // parametros generales
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", sSessionTrabajo);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", sSNN);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@o_sMensajeError", sMensajeError);
                 // parametros especificos	del procedimiento
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdActualizacion", IdActualizacion);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Estado", Estado);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@DocumentoAprobacion", DocumentoAprobacion);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdUsuarioAprobacion", IdUsuarioAprobacion);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@mensaje", mensaje);
                 

                 if (bAsignacionOK)
                 {
                     if (!ObjSPExec.EjecutarProcedimientoNonQry())
                     {
                         sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                         
                     }
                     else
                     {
                         ObjSPExec.ObtenerValorParametro("@mensaje", ref mensaje);
                     }

                 }
             }
             return (ObjSPExec.p_bEstadoOK);
         }
 /*       
         public void ApruebaNovedad(int IdActualizacion, int Estado	, string DocumentoAprobacion, string IdUsuarioAprobacion, out string mensaje, out int retorno_proc)
         {
             mensaje = "";
             retorno_proc = 0;
             DbCommand cmd = db.GetStoredProcCommand("Novedades.PR_NovedadesApRec", IdActualizacion, Estado, DocumentoAprobacion, IdUsuarioAprobacion, 
                 mensaje, retorno_proc);
             db.ExecuteReader(cmd);
             mensaje = Convert.ToString(db.GetParameterValue(cmd, "@mensaje"));
             retorno_proc = Convert.ToInt32(db.GetParameterValue(cmd, "@retorno_proc"));

         }
 */

         public void EliminaNovedad(int IdActualizacion, string IdUsuarioAprobacion, out string mensaje, out int retorno_proc)
         {
             mensaje = "";
             retorno_proc = 0;
             DbCommand cmd = db.GetStoredProcCommand("Novedades.PR_NovedadesElimina", IdActualizacion, IdUsuarioAprobacion,mensaje, retorno_proc);
             db.ExecuteReader(cmd);
             mensaje = Convert.ToString(db.GetParameterValue(cmd, "@mensaje"));
             retorno_proc = Convert.ToInt32(db.GetParameterValue(cmd, "@retorno_proc"));
         }

         public void AplicaNovedad(int IdActualizacion, out string mensaje, out int retorno_proc)
         {
             SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString.ToString());
             SqlCommand cmd = new SqlCommand("Novedades.PR_NovedadesAplica", conn);
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@IdActualizacion", SqlDbType.Int);
             cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
             cmd.Parameters.Add("@retorno_proc", SqlDbType.Int).Direction = ParameterDirection.Output;
             cmd.Parameters["@IdActualizacion"].Value = IdActualizacion;
             conn.Open();
             cmd.ExecuteNonQuery();
             mensaje = Convert.ToString(cmd.Parameters["@mensaje"].Value);
             retorno_proc = Convert.ToInt32(cmd.Parameters["@retorno_proc"].Value);
         }

         public void Form02ValidaCerti(int no_certif, string claseCC,out string mensaje, out int retorno_proc)
         {
             SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString.ToString());
             SqlCommand cmd = new SqlCommand("Novedades.PR_Form02ValidaCerti", conn);
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@no_certif", SqlDbType.Int);
             cmd.Parameters.Add("@claseCC", SqlDbType.VarChar, 2);
             cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
             cmd.Parameters.Add("@retorno_proc", SqlDbType.Int).Direction = ParameterDirection.Output;
             cmd.Parameters["@no_certif"].Value = no_certif;
             cmd.Parameters["@claseCC"].Value = claseCC;
             conn.Open();
             cmd.ExecuteNonQuery();
             mensaje = Convert.ToString(cmd.Parameters["@mensaje"].Value);
             retorno_proc = Convert.ToInt32(cmd.Parameters["@retorno_proc"].Value);
         }
		 
         public bool Form02ValidaCerti1(int iIdConexion, string cOperacion, int no_certif, string claseCC, ref string mensaje)
         {
             ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Novedades.PR_Form02ValidaCerti", "I");
             if (!ObjSPExec.p_bEstadoOK)
             {
                 mensaje = ObjSPExec.ObtenerPilaMensajesError();
             }
             else
             {
                 bool bAsignacionOK = true;
                 // parametros generales
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                 // parametros especificos	del procedimiento
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@no_certif", no_certif);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@claseCC", claseCC);

                 if (bAsignacionOK)
                 {
                     if (!ObjSPExec.EjecutarProcedimientoNonQry())
                     {
                         mensaje = ObjSPExec.ObtenerPilaMensajesError();

                     }
                     else
                     {
                         ObjSPExec.ObtenerValorParametro("@mensaje", ref mensaje);
                     }

                 }
             }
             return (ObjSPExec.p_bEstadoOK);
         }		 

         public IDataReader Form02BuscaCerti(int no_certif, string claseCC)
         {
             DbCommand cmd = db.GetStoredProcCommand("Novedades.PR_Form02BuscaCerti", no_certif,claseCC);
             IDataReader dataReader = db.ExecuteReader(cmd);
             return dataReader;
         }
		 
         public bool Form02BuscaCerti1(int iIdConexion,string cOperacion,int no_certif, string claseCC, ref string sMensajeError,ref DataSet DSetTmp)
         {
             ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Novedades.PR_Form02BuscaCerti", "Q");
             if (!ObjSPExec.p_bEstadoOK)
             {
                 sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
             }
             else
             {
                 bool bAsignacionOK = true;

                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@no_certif", no_certif);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@claseCC", claseCC);
                 

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

 
         public void Form02ValidaInsercion(string NumeroDocumento, string ComplementoSEGIP, string NumRa, string FechaRa, out string mensaje, out int retorno_proc)
         {
             mensaje = "";
             retorno_proc = 0;
             DbCommand cmd = db.GetStoredProcCommand("Novedades.PR_Form02ValidaInsercion", NumeroDocumento, ComplementoSEGIP, NumRa, FechaRa, mensaje, retorno_proc);
             db.ExecuteReader(cmd);
             mensaje = Convert.ToString(db.GetParameterValue(cmd, "@mensaje"));
             retorno_proc = Convert.ToInt32(db.GetParameterValue(cmd, "@retorno_proc"));
         }

         public bool Form02ValidaInsercion1(string NumeroDocumento, string ComplementoSEGIP, string NumRa, string FechaRa, ref string mensaje_error, ref int retorno_proc)
         {
             ClassSPExec ObjSPExec = new ClassSPExec(retorno_proc, "Novedades.PR_Form02ValidaInsercion", "I");
             if (!ObjSPExec.p_bEstadoOK)
             {
                 mensaje_error = ObjSPExec.ObtenerPilaMensajesError();
             }
             else
             {
                 bool bAsignacionOK = true;
                 // parametros especificos	del procedimiento
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NumeroDocumento", NumeroDocumento);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@ComplementoSEGIP", ComplementoSEGIP);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NumRa", NumRa);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@FechaRa", FechaRa);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@mensaje", mensaje_error);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@retorno_proc", retorno_proc);

                 if (bAsignacionOK)
                 {
                     if (!ObjSPExec.EjecutarProcedimientoNonQry())
                     {
                         mensaje_error = ObjSPExec.ObtenerPilaMensajesError();

                     }
                     else
                     {
                         ObjSPExec.ObtenerValorParametro("@mensaje", ref mensaje_error);
                     }

                 }
             }
             return (ObjSPExec.p_bEstadoOK);
         }


        public bool Form02Ins(int iIdConexion, string cOperacion, string sSessionTrabajo, string sSNN, ref string sMensajeError,
            string NUP, string CUA, string PrimerApellido,string SegundoApellido, string PrimerNombre, string SegundoNombre,
             string NumeroDocumento,string IdUsuarioRegistro, string IdInstitucionSolicitante,string DocumentoRespaldo, string IdTipoDocumento, string IdDocumentoExpedido,
             string ComplementoSEGIP, string NumRa, string FechaRa, string NroCertificado, string IdTipoCC, ref string mensaje)
         {
             ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Novedades.PR_Form02Ins", "I");
             if (!ObjSPExec.p_bEstadoOK)
             {
                 sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
             }
             else
             {
                 bool bAsignacionOK = true;
                 // parametros generales
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", sSessionTrabajo);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", sSNN);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@o_sMensajeError", sMensajeError);
                 // parametros especificos	del procedimiento
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NUP", NUP);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@CUA", CUA);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@PrimerApellido", PrimerApellido);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@SegundoApellido", SegundoApellido);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@PrimerNombre", PrimerNombre);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@SegundoNombre", SegundoNombre);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NumeroDocumento", NumeroDocumento);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@DocumentoRespaldo", DocumentoRespaldo);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdTipoDocumento", IdTipoDocumento);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdDocumentoExpedido", IdDocumentoExpedido);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@ComplementoSEGIP", ComplementoSEGIP);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NumRa", NumRa);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@FechaRa", FechaRa);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NroCertificado", NroCertificado);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdTipoCC", IdTipoCC);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdUsuarioRegistro", IdUsuarioRegistro);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdInstitucionSolicitante", IdInstitucionSolicitante);
				 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Aprueba", false);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@mensaje", mensaje);

                 if (bAsignacionOK)
                 {
                     if (!ObjSPExec.EjecutarProcedimientoNonQry())
                     {
                         sMensajeError = ObjSPExec.ObtenerPilaMensajesError();

                     }
                     else
                     {
                         ObjSPExec.ObtenerValorParametro("@mensaje", ref mensaje);
                     }

                 }
             }
             return (ObjSPExec.p_bEstadoOK);
         }


         public IDataReader ListarTitDH(int IdConexion, string cOperacion, int iSesionTrabajo,string sSSN , out string sMensajeError,string ci, string cua, string app, string apm, string nom1, string nom2, string tipo)
         {
             sMensajeError = "";
             DbCommand cmd = db.GetStoredProcCommand("Novedades.PR_ListarTitDH", IdConexion, cOperacion, iSesionTrabajo,sSSN, sMensajeError, ci, cua, app, apm, nom1, nom2, tipo);
             IDataReader dataReader = db.ExecuteReader(cmd);
             return dataReader;
         }

         public bool ListarTitDH1(int iIdConexion, string cOperacion, int iSesionTrabajo,string sSSN , ref string sMensajeError,string ci, string cua, string app, string apm, string nom1, 
             string nom2, string tipo, ref DataSet DSetTmp)
         {
             ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Novedades.PR_ListarTitDH", cOperacion);
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

                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@ci", ci);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@cua", cua);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@app", app);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@apm", apm);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@nom1", nom1);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@nom2", nom2);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@tipo", tipo);                 


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

         public IDataReader PR_Form03ListarTit(string IdTipoCertificado, string NumeroCertificado, string NUPTitular)
         {
             DbCommand cmd = db.GetStoredProcCommand("Novedades.PR_Form03ListarTit", IdTipoCertificado, NumeroCertificado, NUPTitular);
             IDataReader dataReader = db.ExecuteReader(cmd);
             return dataReader;
         }
         public IDataReader Form04ListarDH(string IdTipoCertificado, string NumeroCertificado, string NUPDerechohabiente)
         {
             DbCommand cmd = db.GetStoredProcCommand("Novedades.PR_Form04ListarDH", IdTipoCertificado, NumeroCertificado, NUPDerechohabiente);
             IDataReader dataReader = db.ExecuteReader(cmd);
             return dataReader;
         }

         public bool Form04ListarDH1(int iIdConexion,string cOperacion,string IdTipoCertificado, string NumeroCertificado, string NUPDerechohabiente, ref string sMensajeError,ref DataSet DSetTmp)
         {
             ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Novedades.PR_Form04ListarDH", "Q");
             if (!ObjSPExec.p_bEstadoOK)
             {
                 sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
             }
             else
             {
                 bool bAsignacionOK = true;

                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdTipoCertificado", IdTipoCertificado);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NumeroCertificado", NumeroCertificado);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NUPDerechohabiente", NUPDerechohabiente);
                 

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
		 
         public bool Form03ListarTit1(int iIdConexion,string cOperacion,string IdTipoCertificado, string NumeroCertificado, string NUPTitular, ref string sMensajeError,ref DataSet DSetTmp)
         {
             ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Novedades.PR_Form03ListarTit", "Q");
             if (!ObjSPExec.p_bEstadoOK)
             {
                 sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
             }
             else
             {
                 bool bAsignacionOK = true;

                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdTipoCertificado", IdTipoCertificado);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NumeroCertificado", NumeroCertificado);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NUPTitular", NUPTitular);
                 

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

         public void PersonaIns(int IdFuncionarioRegistro, int IdTipoDocumento, int IdEstadoCivil, int IdEntidadGestora, int IdSexo, int IdEstadoint, 
             int CUA, string Matricula, string NUB, string NumeroDocumento, string ComplementoSEGIP, string IdDocumentoExpedido, string PrimerNombre, 
             string SegundoNombre, string PrimerApellido, string SegundoApellido, string ApellidoCasada, string FechaNacimiento, 
             string FechaFallecimiento, int IdPaisResidencia, string CorreoElectronico, string Celular, string Direccion, int idLocalidad, string Telefono, 
             string RegistroActivo, out string mensaje, out int retorno_proc, out int nup_insertado)
         {
             SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString.ToString());
             SqlCommand cmd = new SqlCommand("Novedades.PR_PersonaIns", conn);
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@IdFuncionarioRegistro", SqlDbType.Int).Value = IdFuncionarioRegistro;
             cmd.Parameters.Add("@IdTipoDocumento", SqlDbType.Int).Value = IdTipoDocumento;
             cmd.Parameters.Add("@IdEstadoCivil", SqlDbType.Int).Value = IdEstadoCivil;
             cmd.Parameters.Add("@IdEntidadGestora", SqlDbType.Int).Value = IdEntidadGestora;
             cmd.Parameters.Add("@IdSexo", SqlDbType.Int).Value = IdSexo;
             cmd.Parameters.Add("@IdEstadoint", SqlDbType.Int).Value = IdEstadoint;
             cmd.Parameters.Add("@CUA", SqlDbType.Int).Value = CUA;
             cmd.Parameters.Add("@Matricula", SqlDbType.VarChar).Value = Matricula;
             cmd.Parameters.Add("@NUB", SqlDbType.VarChar).Value = NUB;
             cmd.Parameters.Add("@NUB", SqlDbType.VarChar).Value = NUB;
             cmd.Parameters.Add("@NumeroDocumento", SqlDbType.VarChar).Value = NumeroDocumento;
             cmd.Parameters.Add("@ComplementoSEGIP", SqlDbType.VarChar).Value = ComplementoSEGIP;
             cmd.Parameters.Add("@IdDocumentoExpedido", SqlDbType.VarChar).Value = IdDocumentoExpedido;
             cmd.Parameters.Add("@PrimerNombre", SqlDbType.VarChar).Value = PrimerNombre;
             cmd.Parameters.Add("@SegundoNombre", SqlDbType.VarChar).Value = SegundoNombre;
             cmd.Parameters.Add("@PrimerApellido", SqlDbType.VarChar).Value = PrimerApellido;
             cmd.Parameters.Add("@SegundoApellido", SqlDbType.VarChar).Value = SegundoApellido;
             cmd.Parameters.Add("@ApellidoCasada", SqlDbType.VarChar).Value = ApellidoCasada;
             cmd.Parameters.Add("@FechaNacimiento", SqlDbType.VarChar).Value = FechaNacimiento;
             cmd.Parameters.Add("@FechaFallecimiento", SqlDbType.VarChar).Value = FechaFallecimiento;
             cmd.Parameters.Add("@IdPaisResidencia", SqlDbType.Int).Value = IdPaisResidencia;
             cmd.Parameters.Add("@CorreoElectronico", SqlDbType.VarChar).Value = CorreoElectronico;
             cmd.Parameters.Add("@Celular", SqlDbType.VarChar).Value = Celular;
             cmd.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = Celular;
             cmd.Parameters.Add("@idLocalidad", SqlDbType.Int).Value = idLocalidad;
             cmd.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = Telefono;
             cmd.Parameters.Add("@RegistroActivo", SqlDbType.VarChar).Value = RegistroActivo;

             cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
             cmd.Parameters.Add("@retorno_proc", SqlDbType.Int).Direction = ParameterDirection.Output;
             cmd.Parameters.Add("@nup_insertado", SqlDbType.Int).Direction = ParameterDirection.Output;

             conn.Open();
             cmd.ExecuteNonQuery();
             mensaje = Convert.ToString(cmd.Parameters["@mensaje"].Value);
             retorno_proc = Convert.ToInt32(cmd.Parameters["@retorno_proc"].Value);
             nup_insertado = Convert.ToInt32(cmd.Parameters["nup_insertado"].Value);
         }
/*
         public void Form04Ins(string NUPAsegurado, string NUPDerechohabiente, string IdEntidadGestora,string IdTipoDocumento, string IdDocumentoExpedido, string NumeroDocumento, string ComplementoSEGIP, string PrimerApellido,
             string SegundoApellido, string PrimerNombre,string SegundoNombre,string IdSexo,string FechaNacimiento, string PeriodoInicio, string RegistroActivo,
             string EstadoVersion, string IdUsuarioRegistro, string IdInstitucionSolicitante, out string mensaje, out int retorno_proc)
         {

             mensaje = "";
             retorno_proc = 0;
             DbCommand cmd = db.GetStoredProcCommand("Novedades.PR_Form04Ins", NUPAsegurado, NUPDerechohabiente, IdEntidadGestora, IdTipoDocumento, IdDocumentoExpedido, NumeroDocumento, ComplementoSEGIP, PrimerApellido,
              SegundoApellido, PrimerNombre, SegundoNombre, IdSexo, FechaNacimiento, PeriodoInicio, RegistroActivo, EstadoVersion, IdUsuarioRegistro, IdInstitucionSolicitante, mensaje, retorno_proc);
             db.ExecuteReader(cmd);
             mensaje = Convert.ToString(db.GetParameterValue(cmd, "@mensaje"));
             retorno_proc = Convert.ToInt32(db.GetParameterValue(cmd, "@retorno_proc"));
         }
*/
         public bool Form04Ins(int iIdConexion, string cOperacion, string sSessionTrabajo, string sSNN, ref string sMensajeError,
                    string NUPAsegurado, string NUPDerechohabiente, string IdEntidadGestora,string IdTipoDocumento, string IdDocumentoExpedido, string NumeroDocumento, string ComplementoSEGIP, string PrimerApellido,
                    string SegundoApellido, string PrimerNombre, string SegundoNombre, string IdSexo, string FechaNacimiento, string FechaInicioVigencia, string RegistroActivo,
                    string EstadoVersion, string IdUsuarioRegistro, string IdInstitucionSolicitante, ref string mensaje)
         {
             ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Novedades.PR_Form04Ins", "I");
             if (!ObjSPExec.p_bEstadoOK)
             {
                 sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
             }
             else
             {
                 bool bAsignacionOK = true;
                 // parametros generales
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", sSessionTrabajo);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", sSNN);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@o_sMensajeError", sMensajeError);
                 // parametros especificos	del procedimiento
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NUPAsegurado", NUPAsegurado);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NUPDerechohabiente", NUPDerechohabiente);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdEntidadGestora", IdEntidadGestora);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdTipoDocumento", IdTipoDocumento);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdDocumentoExpedido", IdDocumentoExpedido);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NumeroDocumento", NumeroDocumento);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@ComplementoSEGIP", ComplementoSEGIP);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@PrimerApellido", PrimerApellido);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@SegundoApellido", SegundoApellido);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@PrimerNombre", PrimerNombre);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@SegundoNombre", SegundoNombre);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdSexo", IdSexo);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@FechaNacimiento", FechaNacimiento);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@FechaInicioVigencia", FechaInicioVigencia);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@EstadoVersion", EstadoVersion);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@RegistroActivo", RegistroActivo);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdUsuarioRegistro", IdUsuarioRegistro);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdInstitucionSolicitante", IdInstitucionSolicitante);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@mensaje", mensaje);

                 if (bAsignacionOK)
                 {
                     if (!ObjSPExec.EjecutarProcedimientoNonQry())
                     {
                         sMensajeError = ObjSPExec.ObtenerPilaMensajesError();

                     }
                     else
                     {
                         ObjSPExec.ObtenerValorParametro("@mensaje", ref mensaje);
                     }

                 }
             }
             return (ObjSPExec.p_bEstadoOK);
         }

         public bool Form03Ins(int iIdConexion, string cOperacion, string sSessionTrabajo, string sSNN, ref string sMensajeError,
                     string NUPAsegurado, string NumeroCertificado, string IdTipoCertificado, string IdEntidadGestora, string IdTipoDocumento, string IdDocumentoExpedido, string NumeroDocumento, string ComplementoSEGIP,
                     string IdSexo, string RegistroActivo, string FechaSolicitud, string TipoCambio1, string TipoCambio2, string TipoAjuste, string PorcentajeAjuste, string SalarioBase,
                     string AniosInsalubres, string MontoAjustado, string NumeroSolicitud, string PeriodoSolicitud,
                     string IdUsuarioRegistro, string IdInstitucionSolicitante, ref string mensaje)
         {
             ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Novedades.PR_Form03Ins", "I");
             if (!ObjSPExec.p_bEstadoOK)
             {
                 sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
             }
             else
             {
                 bool bAsignacionOK = true;
                 // parametros generales
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", sSessionTrabajo);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", sSNN);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@o_sMensajeError", sMensajeError);
                 // parametros especificos	del procedimiento
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NUPAsegurado", NUPAsegurado);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NumeroCertificado", NumeroCertificado);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdTipoCertificado", IdTipoCertificado);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdEntidadGestora", IdEntidadGestora);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdTipoDocumento", IdTipoDocumento);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdDocumentoExpedido", IdDocumentoExpedido);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NumeroDocumento", NumeroDocumento);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@ComplementoSEGIP", ComplementoSEGIP);
				 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdSexo", IdSexo);
				 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@RegistroActivo", RegistroActivo);
				 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@FechaSolicitud", FechaSolicitud);
				 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@TipoCambio1", TipoCambio1);
				 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@TipoCambio2", TipoCambio2);
				 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@TipoAjuste", TipoAjuste);
				 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@PorcentajeAjuste", PorcentajeAjuste);
				 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@SalarioBase", SalarioBase);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@AniosInsalubres", AniosInsalubres);
				 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@MontoAjustado", MontoAjustado);
				 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NumeroSolicitud", NumeroSolicitud);		
				 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@PeriodoSolicitud", PeriodoSolicitud);
				 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdUsuarioRegistro", IdUsuarioRegistro);
				 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdInstitucionSolicitante", IdInstitucionSolicitante);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@mensaje", mensaje);

                 if (bAsignacionOK)
                 {
                     if (!ObjSPExec.EjecutarProcedimientoNonQry())
                     {
                         sMensajeError = ObjSPExec.ObtenerPilaMensajesError();

                     }
                     else
                     {
                         ObjSPExec.ObtenerValorParametro("@mensaje", ref mensaje);
                     }

                 }
             }
             return (ObjSPExec.p_bEstadoOK);
         }


/*
         public void Form03Ins(string NUPAsegurado, string NumeroCertificado, string IdTipoCertificado, string IdEntidadGestora, string IdTipoDocumento, string IdDocumentoExpedido, string NumeroDocumento, string ComplementoSEGIP, 
             string IdSexo, string RegistroActivo, string FechaSolicitud, string TipoCambio1,string TipoCambio2, string TipoAjuste, string PorcentajeAjuste, string SalarioBase,
             string AniosInsalubres, string MontoAjustado, string NumeroSolicitud, string PeriodoSolicitud,
             string IdUsuarioRegistro, string IdInstitucionSolicitante, out string mensaje, out int retorno_proc)
         {
             mensaje = "";
             retorno_proc = 0;
             DbCommand cmd = db.GetStoredProcCommand("Novedades.PR_Form03Ins",  NUPAsegurado,  NumeroCertificado,  IdTipoCertificado,  IdEntidadGestora,  IdTipoDocumento,  IdDocumentoExpedido,  NumeroDocumento,  ComplementoSEGIP, 
              IdSexo,  RegistroActivo,  FechaSolicitud,  TipoCambio1, TipoCambio2,  TipoAjuste,  PorcentajeAjuste,  SalarioBase,
              AniosInsalubres,  MontoAjustado,  NumeroSolicitud,  PeriodoSolicitud, IdUsuarioRegistro,  IdInstitucionSolicitante, mensaje,retorno_proc);
             db.ExecuteReader(cmd);
             mensaje = Convert.ToString(db.GetParameterValue(cmd, "@mensaje"));
             retorno_proc = Convert.ToInt32(db.GetParameterValue(cmd, "@retorno_proc"));
             
         }
 */

         public void Form04ValidaInsercion(string NUPDerechohabiente, string NumeroDocumento, string ComplementoSEGIP, string Nacimiento, string IniPago, out string mensaje, out int retorno_proc)
         {
             SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString.ToString());
             SqlCommand cmd = new SqlCommand("Novedades.PR_Form04ValidaInsercion", conn);
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@NUPDerechohabiente", SqlDbType.VarChar, 50).Value = NUPDerechohabiente;
             cmd.Parameters.Add("@NumeroDocumento", SqlDbType.VarChar, 50).Value = NumeroDocumento;
             cmd.Parameters.Add("@ComplementoSEGIP", SqlDbType.VarChar, 50).Value = ComplementoSEGIP;
             cmd.Parameters.Add("@Nacimiento", SqlDbType.VarChar, 50).Value = Nacimiento;
             cmd.Parameters.Add("@IniPago", SqlDbType.VarChar, 50).Value = IniPago;
             cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
             cmd.Parameters.Add("@retorno_proc", SqlDbType.Int).Direction = ParameterDirection.Output;
             conn.Open();
             cmd.ExecuteNonQuery();
             mensaje = Convert.ToString(cmd.Parameters["@mensaje"].Value);
             retorno_proc = Convert.ToInt32(cmd.Parameters["@retorno_proc"].Value);
         }
         public void Form03ValidaInsercion(string IdHabilitacionTitularCC,string NUPTitular, string NumeroDocumento, string ComplementoSEGIP,
             string FechaSolicitud, string RegistroActivo, string TipoAjuste, string PorcentajeAjuste, string MontoAjustado,string TipoCambio2, string TipoCambio1, out string mensaje, out int retorno_proc)
         {
             mensaje = "";
             retorno_proc = 0;
             DbCommand cmd = db.GetStoredProcCommand("Novedades.PR_Form03ValidaInsercion", IdHabilitacionTitularCC, NUPTitular, NumeroDocumento, ComplementoSEGIP,
              FechaSolicitud, RegistroActivo, TipoAjuste, PorcentajeAjuste, MontoAjustado, TipoCambio2, TipoCambio1, mensaje, retorno_proc);
             db.ExecuteReader(cmd);
             mensaje = Convert.ToString(db.GetParameterValue(cmd, "@mensaje"));
             retorno_proc = Convert.ToInt32(db.GetParameterValue(cmd, "@retorno_proc"));
         }
         public IDataReader ListarNovesPrueba(int IdActualizacion)
         {
             DbCommand cmd = db.GetStoredProcCommand("Novedades.PR_ListarNovesPrueba", IdActualizacion);
             IDataReader dataReader = db.ExecuteReader(cmd);
             return dataReader;
         }

         public DataSet ListarNovesPruebaDataSet(int IdActualizacion)
         {
             DbCommand cmd = db.GetStoredProcCommand("Novedades.PR_ListarNovesPrueba", IdActualizacion);
             DataSet dataTabla = db.ExecuteDataSet(cmd);
             return dataTabla;
         }

         public DataTable ListarNovesPruebaTabla(int IdActualizacion)
         {
             SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString.ToString());
             SqlDataAdapter adap = new SqlDataAdapter("Novedades.PR_ListarNovesPrueba", conn);
             DataTable dt = new DataTable();
             adap.SelectCommand.Parameters.Add("@IdActualizacion", SqlDbType.Int).Value = IdActualizacion;
             adap.Fill(dt);
             return dt;

         }

         public DataTable ReporteNovedadesId(int IdActualizacion)
         {
             SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString.ToString());
             conn.Open();
             SqlDataAdapter adap = new SqlDataAdapter("Novedades.PR_ReporteNovedadesId", conn);
             DataTable dt = new DataTable();
             adap.SelectCommand.Parameters.Add("@IdActualizacion", SqlDbType.Int).Value = IdActualizacion;
             adap.Fill(dt);
             conn.Close();
             return dt;
         }

         public DataSet ReporteNovedadesIdDataSet(int IdActualizacion)
         {
             DbCommand cmd = db.GetStoredProcCommand("Novedades.PR_ReporteNovedadesId", IdActualizacion);
             DataSet dataTabla = db.ExecuteDataSet(cmd);
             return dataTabla;
         }

         public IDataReader ListaDatosConexion(int IdConexion)
         {
             DbCommand cmd = db.GetStoredProcCommand("Seguridad.PR_ListaDatosConexion", IdConexion);
             IDataReader dataReader = db.ExecuteReader(cmd);
             return dataReader;
         }


    }
}

