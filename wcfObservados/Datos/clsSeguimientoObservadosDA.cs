using System;
using System.Data;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Linq;
using System.Data.Common;
using System.Web;

using SQLSPExecuter; //libreria de seguridad

using wcfObservados.Entidades;

namespace wcfObservados.Datos
{
    public class clsSeguimientoObservadosDA
    {
          Database db = null;
          public clsSeguimientoObservadosDA()
        {
            db = DatabaseFactory.CreateDatabase("cnnsenarit");
        }
        /* Adiciona un Seguimiento Observados */

          public bool AdicionarSeguimientoObservados(int iIdConexion, string cOperacion, Int64 tram, int ben, int tipoaccion, int etapa, string nombreint, int hojaruta,string fechahruta, int IdAreaDestino, int fojas, string observacion, int RegistroActivo,Int32 TipoObs,string CodFicha, ref string sMensajeError)
        {
           
                //DateTime fhojaruta = Convert.ToDateTime(fechahruta); 
            
            //DbCommand cmd = db.GetStoredProcCommand("Tramite.PR_FormularioRevisionAdicionar", tram, ben, tipoaccion, etapa, nombreint, hojaruta,IdAreaDestino, fojas, observacion, RegistroActivo); 
            //db.ExecuteNonQuery(cmd);
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Tramite.PR_FormularioRevisionTransacciones", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTramite", tram);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdGrupoBeneficio", ben);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTipoAccion", tipoaccion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdEtapa", etapa);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNombreInteresado", nombreint);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iHojaRuta", hojaruta);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@FechaRuta", fechahruta);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdAreaDestino", IdAreaDestino);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iNumeroFojas", fojas);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sTextoObservacion", observacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_bRegistroActivo", RegistroActivo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdTipoObs", TipoObs);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sCodFicha", CodFicha);
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
        /* Modificar un Tipo de Cambio */
          public bool ModificarSeguimientoObservados(int iIdConexion, string cOperacion, int form, Int64 tram, int ben, string nombreint, int fojas, string observacion, int RegistroActivo,int iIdTipoAccion, ref string sMensajeError)
          {
              //DbCommand cmd = db.GetStoredProcCommand("Tramite.PR_FormularioRevisionModificar", form, tram, ben, nombreint, fojas, observacion, RegistroActivo);
              //db.ExecuteNonQuery(cmd);
              ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Tramite.PR_FormularioRevisionTransacciones", cOperacion);
              if (!ObjSPExec.p_bEstadoOK)
              {
                  sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
              }
              else
              {
                  bool bAsignacionOK = true;
                  bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                  bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion); 
                  bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdFormulario", form);
                  bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTramite", tram);
                  bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdGrupoBeneficio", ben);
                  bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNombreInteresado", nombreint);
                  bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iNumeroFojas", fojas);
                  bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sTextoObservacion", observacion);
                  bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_bRegistroActivo", RegistroActivo);
                  bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTipoAccion", iIdTipoAccion);

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
            //Modifica los datos del formulario de revision que es de derivacion o registro de documentacion
          public bool ModificarFormularioDocumentos(int iIdConexion, string cOperacion, Int64 tram, int ben, int tipoaccion, int etapa, string nombreint, int hojaruta, string fechahruta, string IdAreaDestino, int fojas, string observacion, int RegistroActivo, Int32 TipoObs,Int32 IdForm, ref string sMensajeError)
          {     int iIdAreaDestino = 0;
              if(IdAreaDestino != "" && IdAreaDestino != null)
                   iIdAreaDestino = Convert.ToInt32(IdAreaDestino);

              ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Tramite.PR_FormularioRevisionTransacciones", cOperacion);
              if (!ObjSPExec.p_bEstadoOK)
              {
                  sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
              }
              else
              {
                  bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTramite", tram);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdGrupoBeneficio", ben);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTipoAccion", tipoaccion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdEtapa", etapa);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNombreInteresado", nombreint);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iHojaRuta", hojaruta);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@FechaRuta", fechahruta);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdAreaDestino", iIdAreaDestino);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iNumeroFojas", fojas);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sTextoObservacion", observacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_bRegistroActivo", RegistroActivo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdTipoObs", TipoObs);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdFormulario", IdForm);

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
        /* Elimina logicamente un Tipo de Cambio */
          public bool EliminarSeguimientoObservados(int iIdConexion, string cOperacion, int form, ref string sMensajeError)
        {
            try
            {
                //DbCommand dbCommand = db.GetStoredProcCommand("Tramite.PR_FormularioRevisionEliminar", form);
                //db.ExecuteNonQuery(dbCommand);
                //return true;
                ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Tramite.PR_FormularioRevisionTransacciones", cOperacion);
                if (!ObjSPExec.p_bEstadoOK)
                {
                    sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                }
                else
                {
                    bool bAsignacionOK = true;
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdFormulario", form);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_bRegistroActivo", 0);
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
            catch
            {
                return false;
            }
        }

        /*Obtiene Datos del beneficiario o Listado de Revisiones por Beneficario*/
          public bool DatosBeneficiario(int iIdConexion, string cOperacion, Int64 Tramite,Int32 GrupoB, ref string sMensajeError, ref DataSet DSetTmp)
          {
              ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Tramite.PR_FormularioRevisionTransacciones", cOperacion);
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
                  bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdGrupoBeneficio", GrupoB);
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
        //Verifica si tiene acceso al link
          public bool VerificaAcceso(int iIdConexion, string cOperacion,string NoCrentaTramite,int iIdGrupoBeneficio, ref string sMensajeError, ref DataSet DSetTmp)
          {
              ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Tramite.PR_FormularioRevisionTransacciones", cOperacion);
              if (!ObjSPExec.p_bEstadoOK)
              {
                  sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
              }
              else
              {
                  bool bAsignacionOK = true;
                  bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                  bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                  bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_NumeroCrenta", NoCrentaTramite);
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


        /* GESTIONES */
          public bool Gestiones(int iIdConexion, string cOperacion,  ref string sMensajeError, ref DataSet DSetTmp)
          {
              ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Tramite.PR_FormularioRevisionTransacciones", cOperacion);
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

          public bool BandejaObservados(int iIdConexion, string cOperacion, ref string sMensajeError, ref DataSet DSetTmp)
          {
              ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Tramite.PR_FormularioRevisionTransacciones", cOperacion);
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

        /* LISTAR DATOS DEL MODAL DDL LISTA DE ACCIONES */
          public bool ListarAcciones(int iIdConexion, string cOperacion, ref string sMensajeError, ref DataSet DSetTmp)
          {
              ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Tramite.PR_FormularioRevisionTransacciones", cOperacion);
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
            
        /* LISTA DE AREAS A LAS QUE SE DERIVA EL DOCUMENTO */
          public bool AreasOficina(int iIdConexion, string cOperacion, Int32 IdOficina ,ref string sMensajeError, ref DataSet DSetTmp)
          {
              ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Tramite.PR_FormularioRevisionTransacciones", cOperacion);
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
                  bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdOficina", IdOficina);
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

        /* Verifica si existe Hoja de Ruta */
          public bool HojaRutas(int iIdConexion, string cOperacion, Int32 Hoja,Int32 Gestion, ref string sMensajeError, ref DataSet DSetTmp)
          {
              ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Tramite.PR_FormularioRevisionTransacciones", cOperacion);
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
                  bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@HojaR", Hoja);
                  bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Gestion", Gestion);
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
        /* Datos del Registro seleccionado, para realizar modificaciones */
          public bool DatosVer(int iIdConexion, string cOperacion,Int32 Codigo, ref string sMensajeError, ref DataSet DSetTmp)
          {
              ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Tramite.PR_FormularioRevisionTransacciones", cOperacion);
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
                  bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Cod", Codigo);
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
          /* Listado de Tipos de Observaciones */
          public bool ddlObservados(int iIdConexion, string cOperacion,ref string sMensajeError, ref DataSet DSetTmp)
          {
              ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Tramite.PR_FormularioRevisionTransacciones", cOperacion);
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

        /* PARA IMPRESION DE LOS DATOS */
          public DataTable ImprimirDatos(Int64 Tramite, int benefi)
          {
              DataTable DSetTmp = new DataTable();
              DbCommand cmd = db.GetStoredProcCommand("Tramite.PR_ObtenerDatosPersonaTramite", Tramite, benefi);
              IDataReader dataReader = db.ExecuteReader(cmd);
              DSetTmp.Load(dataReader);
              return DSetTmp;
          }

        /* Lista tipos de Cambio */
        public IDataReader ListarSeguimientoObservados(Int64 Tramite, int benefi)
        {
            DbCommand cmd = db.GetStoredProcCommand("Tramite.PR_FormularioRevisionListar", Tramite,  benefi);
            IDataReader dataReader = db.ExecuteReader(cmd);
            return dataReader;
        }
        /* Obtener tipos de Cambio*/
        public IDataReader ObtenerSeguimientoObservados(int cod)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("Tramite.PR_FormularioRevisionObtener", cod);
            IDataReader dataReader = db.ExecuteReader(dbCommand);
            return dataReader;

        }
        /* Verificar Tipos de Cambio*/
        public IDataReader VerificarSeguimientoObservados(DateTime Fecha,  int Resolucion)
           {
               string fec = Convert.ToString(Fecha).Substring(0, 10);
               DbCommand dbCommand = db.GetStoredProcCommand("Tramite.PR_FormularioRevisionVerificar", fec, Resolucion);
               IDataReader dataReader = db.ExecuteReader(dbCommand);
               return dataReader;
           }
        public bool ListaRegionales(int iIdConexion, string cOperacion, ref string sMensajeError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Tramite.PR_FormularioRevisionTransacciones", cOperacion);
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

        public bool ListaObservaciones(int iIdConexion, string cOperacion, ref string sMensajeError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Tramite.PR_FormularioRevisionTransacciones", cOperacion);
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
     }
      
}