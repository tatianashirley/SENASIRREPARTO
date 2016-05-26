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
    public class clsNotificacionesDA
    {
        Database db = null;

        public clsNotificacionesDA()
        {
            db = DatabaseFactory.CreateDatabase("cnnsenarit");
        }
        public bool ObtieneDatos(int iIdConexion, string cOperacion, /*string Tipo,int IdArea,*/string IdTramite, string IdBeneficio, ref string sMensajeError, ref DataSet DSetTmp)
        {
            
            if (IdTramite == "")
                IdTramite = null;
            if (IdBeneficio == "")
                IdBeneficio = null;
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
                //bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdArea", IdArea);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Tramite", IdTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@GrupoBeneficio", IdBeneficio);

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
        //Obtiene valor si IdOficina = IdOficinaNotificacion and IdOficina = IdOficinaUsuario
        public bool HabilitaBoton(int iIdConexion, string cOperacion, Int32 IdTramite,Int32 IdGrupoB, ref string sMensajeError, ref DataSet DSetTmp)
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
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTramite", IdTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdGrupoBeneficio", IdGrupoB);

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

        public bool ObtieneFechaCalculo(int iIdConexion, string cOperacion,Int64 IdTramite,Int32 IdGrupoB,Int32 IdDocumento,Int32 NroDocumento,string FechaT,ref string sMensajeError, ref DataSet DSetTmp)
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
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTramite", IdTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdGrupoBeneficio", IdGrupoB);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdDocumento", IdDocumento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iNroDocumento", NroDocumento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Fecha", FechaT);

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

         public bool ActualizaDocumento(int iIdConexion, string cOperacion, /*string Tipo,*/Int64 Tramite, int GrupoBeneficio, int IdDocumento, string FechaDocumento,int NroDocumento,string FechaNot,string Obs,int IdtipoNot,int Bandera,ref string sMensajeError)
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
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTipoNotificacion", IdtipoNot);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iTipoCodigoImpresion", Bandera);

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

         public bool ObtieneDatos(int iIdConexion, string cOperacion, string Tipo, Int64 Tramite, Int32 GrupoBeneficio,string FechaDoc,Int32 NroDoc,Int32 IdDoc,string Direccion, ref string sMensajeError, ref DataSet DSetTmp)
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
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Tipo", Tipo);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTramite", Tramite);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdGrupoBeneficio", GrupoBeneficio);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Fecha", FechaDoc);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iNroDocumento", NroDoc);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdDocumento", IdDoc);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Direccion", Direccion);
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
        //Obtiene los codigos que estan listos para imprimir en el reporte
         public bool ObtieneDatosCodigos(int iIdConexion, string cOperacion, Int64 Tramite, Int32 GrupoBeneficio, string FechaDoc, Int32 NroDoc, Int32 IdDoc, ref string sMensajeError, ref DataSet DSetTmp)
         {
             ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Notificacion.PR_Reportes", cOperacion);
             if (!ObjSPExec.p_bEstadoOK)
             {
                 sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
             }
             else
             {
                 bool bAsignacionOK = true;
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTramite", Tramite);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdGrupoBeneficio", GrupoBeneficio);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@FechaIni", FechaDoc);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iNroDocumento", NroDoc);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdDocumento", IdDoc);
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

        //PARA PRESENTACION DE RECURSOS
         public bool ObtieneRecursos(int iIdConexion, string cOperacion,/* string Tipo,*/ int IdArea,Int64 IdTramite, ref string sMensajeError, ref DataSet DSetTmp)
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
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdArea", IdArea);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTramite", IdTramite);
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

      

         //Obtiene datos de un registro para su modificacion
         public bool CargaDatosNotificacion(int iIdConexion, string cOperacion, Int64 Tramite, int GrupoBeneficio, int IdDocumento, string FechaDocumento, int NroDocumento, ref string sMensajeError, ref DataSet DSetTmp)
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
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTramite", Tramite);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdGrupoBeneficio", GrupoBeneficio);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Fecha", FechaDocumento);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdDocumento", IdDocumento);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iNroDocumento", NroDocumento);
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

         //Obtiene datos de codigos para impresion
         public bool DatosImpresion(int iIdConexion, string cOperacion, Int64 Tramite, int GrupoBeneficio, int IdDocumento, string FechaDocumento, int NroDocumento,Int32 TipoTramite, ref string sMensajeError, ref DataSet DSetTmp)
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
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTramite", Tramite);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdGrupoBeneficio", GrupoBeneficio);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Fecha", FechaDocumento);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdDocumento", IdDocumento);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iNroDocumento", NroDocumento);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@TipoTramite", TipoTramite);

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
        //Registra en tablas los codigos generados de Impresion
         public bool RegistraRecursoRenuncia(int iIdConexion, string cOperacion, Int64 Tramite, int GrupoBeneficio, int IdDocumento, string FechaDocumento, int NroDocumento, string Encriptado, string CodigoImp, Int32 TipoTramite, ref string sMensajeError)
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
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTramite", Tramite);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdGrupoBeneficio", GrupoBeneficio);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Fecha", FechaDocumento);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdDocumento", IdDocumento);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iNroDocumento", NroDocumento);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@encriptado", Encriptado);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@codigoImp", CodigoImp);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@TipoTramite", TipoTramite);
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

         public bool ExisteDocumento(int iIdConexion, string cOperacion, Int64 IdTramite, Int32 IdGrupoB, ref string sMensajeError, ref DataSet DSetTmp)
         {
             ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Notificacion.PR_Reportes", cOperacion);
             if (!ObjSPExec.p_bEstadoOK)
             {
                 sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
             }
             else
             {
                 bool bAsignacionOK = true;
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTramite", IdTramite);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdGrupoBeneficio", IdGrupoB);
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

         public bool ExisteDocumentoSinNotificar(int iIdConexion, string cOperacion, Int64 IdTramite, Int32 IdGrupoB, ref string sMensajeError, ref DataSet DSetTmp)
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
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTramite", IdTramite);
                 bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdGrupoBeneficio", IdGrupoB);
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