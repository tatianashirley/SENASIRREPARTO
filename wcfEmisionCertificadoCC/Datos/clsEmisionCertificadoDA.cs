using System;
using System.Data;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Linq;
using System.Data.Common;
using System.Web;
using wcfEmisionCertificadoCC.Entidades;
using SQLSPExecuter;

namespace wcfEmisionCertificadoCC.Datos
{
	public class clsEmisionCertificadoDA
	{
		#region "Declaración de variables o parametros para las funciones/Procedimientos Capa Datos"
		public Int32 iNroCertificadoReemplazo { get; set; }
		#endregion

		Database db = null;
		public clsEmisionCertificadoDA()
		{
			db = DatabaseFactory.CreateDatabase("cnnsenarit");
		}
		/* Adiciona un Tipo de Cambio */
	   public void AdicionarEmisionCertificado(Int64 Tramite, int benefi, int tipoformc, int nroform, int tipocc, int tipocert,int NroCertificado, string FechaEmision, int IdOficina, int IdUsuarioEmi,string FechaImpresion,  int IdUsuarioImp)
		{
			//string fec = Convert.ToString(FechaResolucion);
			DbCommand cmd = db.GetStoredProcCommand("EmisionCC.PR_CertificadoCCAdicionar", Tramite, benefi, tipoformc, nroform, tipocc, tipocert, NroCertificado, FechaEmision, IdOficina, IdUsuarioEmi, FechaImpresion, IdUsuarioImp);
			db.ExecuteNonQuery(cmd);
		}
	  /* actualizar y adiciona datos*/ 
	  public void AdicionarActualizarEmisionCertificado(Int64 Tramite, int benefi, int tipoformc, int nroform, int tipocc, int tipocert, int NroCertificado,int NumeroAsig, string FechaEmision, int IdOficina, int IdUsuarioEmi, string montoaceptado,string TotalGanado,string DensidadTotal,string SalCotActTot,string SalCotAct)
		{
			//string fec = Convert.ToString(FechaResolucion);
			DbCommand cmd = db.GetStoredProcCommand("EmisionCC.PR_CertificadoCCAdicionarActualizar", Tramite, benefi, tipoformc, nroform, tipocc, tipocert, NroCertificado, NumeroAsig, FechaEmision, IdOficina, IdUsuarioEmi, montoaceptado,TotalGanado,DensidadTotal,SalCotActTot,SalCotAct);
			db.ExecuteNonQuery(cmd);
		}

	  //Reemplazo de Codigo
	  public bool AdicionarActualizarEmisionCertificado(int iIdConexion, string cOperacion, Int64 Tramite, Int32 benefi, int tipoformc, int nroform, int tipocc, int tipocert,
		  int NroCertificado, int NumeroAsig, string FechaEmision, int IdOficina, int IdUsuarioEmi, string montoaceptado, string TotalGanado,
		  string DensidadTotal, string SalCotActTot, string SalCotAct, ref string sMensajeError)
	  {
		  ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "EmisionCC.PR_CertificadoCCAdicionarActualizar", cOperacion);
		  if (!ObjSPExec.p_bEstadoOK)
		  {
			  sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
		  }
		  else
		  {
			  bool bAsignacionOK = true;
			  bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
			  bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
			  bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdTramite", Tramite);
			  bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@GrupoB", benefi);
			  bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdTipoForm", tipoformc);
			  bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NoForm", nroform);
			  bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdTipoCC", tipocc);
			  bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@TipoTramite", tipocert);
			  bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NroCertificado", NroCertificado);
			  bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NroAsignacion", NumeroAsig);
			  bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@FechahaEmision", FechaEmision);
			  bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdOficina", @IdOficina);
			  bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdUsrEmision", IdUsuarioEmi);
			  bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@MontoAceptado", montoaceptado);
			  bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@TotalGanado", TotalGanado);
			  bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@DensidadTotal", DensidadTotal);
			  bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@SalCotAct", SalCotActTot);
			  bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@SalAct", SalCotAct);

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
		
		public void ActualizarCertificadoCC(Int64 Tramite, int benefi, int idtipoformc, int nroform, int tipocc)
		{
			//string fec = Convert.ToString(FechaResolucion);
			DbCommand cmd = db.GetStoredProcCommand("EmisionCC.PR_CertificadoCCActualizarAlImprimir", Tramite, benefi, idtipoformc, nroform, tipocc);
			db.ExecuteNonQuery(cmd);
		}

		//Reemplazo de Codigo
		public bool ActualizarCertificadoCC(int iIdConexion, string cOperacion, Int64 Tramite, Int32 benefi, Int32 tipoformc, Int32 nroform,Int32 tipocc, ref string sMensajeError)
		{
			ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "EmisionCC.PR_CertificadoCCActualizarAlImprimir", cOperacion);
			if (!ObjSPExec.p_bEstadoOK)
			{
				sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
			}
			else
			{
				bool bAsignacionOK = true;
				bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
				bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
				bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdTramite", Tramite);
				bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@GrupoB", benefi);
				bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdTipoForm", tipoformc);
				bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NoForm", nroform);
				bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@tipocc", tipocc);

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

	  public bool RegistraImpresion(Int64 idTramite,int idGrupoB,int idTipoFormulario)
	  {
		  try
		  {
			  DbCommand dbCommand = db.GetStoredProcCommand("EmisionCC.PR_RegistraImpresion", idTramite, idGrupoB, idTipoFormulario);
			  db.ExecuteNonQuery(dbCommand);
			  return true;
		  }
		  catch
		  {
			  return false;
		  }
	  }

		/* Elimina logicamente un Tipo de Cambio */
		public Boolean EliminarEmisionCertificado(int NumeroAsignacion)
		{
			try
			{
				DbCommand dbCommand = db.GetStoredProcCommand("EmisionCC.PR_AsignacionCorrelativoCCEliminar", NumeroAsignacion);
				db.ExecuteNonQuery(dbCommand);
				return true;
			}
			catch
			{
				return false;
			}
		}
		/* Modificar un Tipo de Cambio */
		public void ModificarEmisionCertificado(int numeroasig, int IdOficina, int IdTipoCertificado, DateTime FechaAsignacion, DateTime FechaEnvio, int NumeroInicial, int NumeroFinal, string Observacion, int RegistroActivo)
		{
			DbCommand cmd = db.GetStoredProcCommand("EmisionCC.PR_AsignacionCorrelativoCCModificar", numeroasig, IdOficina, IdTipoCertificado, FechaAsignacion, FechaEnvio, NumeroInicial, NumeroFinal, Observacion, RegistroActivo);
			db.ExecuteNonQuery(cmd);
		}
	   
		/* Lista tipos de Cambio */
		public IDataReader ListarEmisionCertificado(int cod)
		{
			DbCommand cmd = db.GetStoredProcCommand("EmisionCC.PR_AsignacionCorrelativoCCListar", cod);
			IDataReader dataReader = db.ExecuteReader(cmd);
			return dataReader;
		}
		/* Verificar Tipos de Cambio*/
		public IDataReader VerificarEmisionCertificado(int IdOficina, int IdTipoCertificado, int NumeroInicial, int NumeroFinal)
		{
			//  string fec = Convert.ToString(Fecha);

			//string fec1 = fec.Substring(1, 10);
			DbCommand dbCommand = db.GetStoredProcCommand("EmisionCC.PR_AsignacionCorrelativoCCVerificar", IdOficina, IdTipoCertificado, NumeroInicial, NumeroFinal);
			IDataReader dataReader = db.ExecuteReader(dbCommand);
			return dataReader;
		}
		/* Obtener  */
		public IDataReader ObtenerEmisionCertificado(Int64 Tramite, int GrupoB, int TipoForm, int NoFormCalculo)
		{
			DbCommand dbCommand = db.GetStoredProcCommand("EmisionCC.PR_CertificadoCCObtener", Tramite, GrupoB, TipoForm, NoFormCalculo); 
			IDataReader dataReader = db.ExecuteReader(dbCommand);
			return dataReader;
		}
		/* Obtenero */
		public IDataReader ObtenerCertificadoImpreso(Int64 Tramite, int GrupoB, int TipoForm, int NoFormCalculo)
		{
			DbCommand dbCommand = db.GetStoredProcCommand("EmisionCC.PR_CertificadoCCVerificarImpresion", Tramite, GrupoB, TipoForm, NoFormCalculo);
			IDataReader dataReader = db.ExecuteReader(dbCommand);
			return dataReader;
		}

		//Reemplazo de Codigo
		public bool ObtenerCertificadoImpreso(int IdConexion, string cOperacion, Int64 Tramite, Int32 GrupoB,Int32 TipoForm,Int32 NoFormCalculo, ref string sMensajeError, ref DataSet DSetTmp)
		{
			ClassSPExec ObjSPExec = new ClassSPExec(IdConexion, "EmisionCC.PR_CertificadoCCVerificarImpresion", cOperacion);
			if (!ObjSPExec.p_bEstadoOK)
			{
				sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
			}
			else
			{
				bool bAsignacionOK = true;
				bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", IdConexion);
				bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
				bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdTramite", Tramite);
				bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@GrupoB", GrupoB);
				bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@TipoForm", TipoForm);
				bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NoFormCalculo", NoFormCalculo);
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


		/* Obtenero */
		public IDataReader ObtenerCertificadoCC(Int64 Tramite, int GrupoB, int TipoForm, int NoFormCalculo)
		{
			DbCommand dbCommand = db.GetStoredProcCommand("EmisionCC.PR_CertificadoCCObtenerExiste", Tramite, GrupoB, TipoForm, NoFormCalculo);
			IDataReader dataReader = db.ExecuteReader(dbCommand);
			return dataReader;
		}
		/* Obtener nuevo calculo de monto cc */
		public IDataReader CalcularMontosAlaFecha(int idtipoformc, int idtipocer, int idtipcc, string MontoCC, string fechagen)
		{
			//(24abril2015) CertificacionCC.FN_MontoCCResumen
			DbCommand dbCommand = db.GetStoredProcCommand("CertificacionCC.FN_MontoCCResumen", idtipoformc, idtipocer, idtipcc, MontoCC, fechagen);
			IDataReader dataReader = db.ExecuteReader(dbCommand);
			return dataReader;
		}
		//07/04/2015
		/*Obtener nuevo calculo de monto CC --FUNCION ACTUALIZADA*/
		public DataTable CalcularMontosAlaFecha(Int64 IdTramite, Int32 IdGupoBeneficio, string fechaAct)
		{   
			//(20150427) CertificacionCC.FN_MontoCCResumen
			DataTable DSetTmp = new DataTable();
			DbCommand dbCommand = db.GetStoredProcCommand("EmisionCC.PR_CertificadoCCCalculoMontoCC", IdTramite, IdGupoBeneficio, fechaAct);
			IDataReader dataReader = db.ExecuteReader(dbCommand);
			DSetTmp.Load(dataReader);
			return DSetTmp;
		}

		//Reemplazo de Codigo
		public bool CalcularMontosaLaFecha(int IdConexion, string cOperacion, Int64 Tramite, Int32 GrupoB, string FechaAct, Int32 TipoForm, Int32 IdTipoCC, ref string sMensajeError, ref DataSet DSetTmp)
		{
			ClassSPExec ObjSPExec = new ClassSPExec(IdConexion, "EmisionCC.PR_CalculoMontoCCCertificado", cOperacion);
			if (!ObjSPExec.p_bEstadoOK)
			{
				sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
			}
			else
			{
				bool bAsignacionOK = true;
				bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", IdConexion);
				bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
				bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdTramite", Tramite);
				bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@GrupoB", GrupoB);
				bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Fecha", FechaAct);
				bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTipoCC", IdTipoCC);
				bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@tipoFormulario", TipoForm);
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

		public bool BandejaEmisionCC(int IdConexion, string cOperacion, string NroCrenta, int iIdGrupoBeneficio, ref string sMensajeError, ref DataSet DSetTmp)
		{
			//ClassSPExec ObjSPExec = new ClassSPExec(IdConexion, "EmisionCC.PR_CertificadoCCCalculoMontoCC", cOperacion); PROCESO BUENO
			ClassSPExec ObjSPExec = new ClassSPExec(IdConexion, "EmisionCC.PR_CertificadoCCCalculoMontoCC", cOperacion);
			if (!ObjSPExec.p_bEstadoOK)
			{
				sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
			}
			else
			{
				bool bAsignacionOK = true;
				bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", IdConexion);
				bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
				bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NroCrenta", NroCrenta);
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

		//Reemplazo de Codigo
		public bool Impresion(int iIdConexion, string cOperacion, Int64 IdTramite, Int32 IdGupoBeneficio,Int32 IdTipoFormulario,Int32 NroFormulario, ref string sMensajeError, ref DataSet DSetTmp)
		{
			ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "EmisionCC.PR_CertificadoCCDatosCompletos", cOperacion);
			if (!ObjSPExec.p_bEstadoOK)
			{
				sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
			}
			else
			{
				bool bAsignacionOK = true;
				bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
				bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
				bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Tramite", IdTramite);
				bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@GrupoB", IdGupoBeneficio);
				bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@TipoForm", IdTipoFormulario);
				bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NoFormCalculo", NroFormulario);
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

		//PARA LA IMPRESION
		public DataTable Impresion(Int64 IdTramite, Int32 IdGupoBeneficio,Int32 IdTipoFormulario,Int32 NroFormulario)
		{
			//OBTIENE DATOS PARA LA IMPRESION
			DataTable DSetTmp = new DataTable();
			DbCommand dbCommand = db.GetStoredProcCommand("EmisionCC.PR_CertificadoCCDatosCompletos", IdTramite, IdGupoBeneficio,IdTipoFormulario,NroFormulario);
			IDataReader dataReader = db.ExecuteReader(dbCommand);
			DSetTmp.Load(dataReader);
			return DSetTmp;
		}
		//Reemplazo de Codigo
		public bool ObtenerFormularioCalculoCC(int iIdConexion, string cOperacion, Int64 Tramite, Int32 GrupoB, ref string sMensajeError, ref DataSet DSetTmp)
		{
			ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "CertificacionCC.PR_FormularioCalculoCCObtener", cOperacion);
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

		//Reemplazo de Codigo
		public bool DatosCertificadoCompleto(int iIdConexion, string cOperacion, Int64 Tramite, Int32 GrupoB, ref string sMensajeError, ref DataSet DSetTmp)
		{
			ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "EmisionCC.PR_Renumeracion", cOperacion);
			if (!ObjSPExec.p_bEstadoOK)
			{
				sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
			}
			else
			{
				bool bAsignacionOK = true;
				bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
				bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
				bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdTramite", Tramite);
				bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdGrupo", GrupoB);
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

		//Actualiza el Nro de Certificado para adicionar el nuevo registro
		public bool ReimpresionCertificadoCC(int iIdConexion, string cOperacion, Int64 Tramite, Int32 GrupoB,Int32 NroCertificado,string Observacion,Int32 IdArea,Int32 TipoTramite,
			Int32 NroAsig,Int32 Decision,Int32 NroFormularioCalculo,Int32 CertActual, ref string sMensajeError)
		{
			ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "EmisionCC.PR_Renumeracion", cOperacion);
			if (!ObjSPExec.p_bEstadoOK)
			{
				sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
			}
			else
			{
				bool bAsignacionOK = true;
				bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
				bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
				bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdTramite", Tramite);
				bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdGrupo", GrupoB);
				bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iNroCertificado", NroCertificado);
				bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sGlosaObservacionBaja", Observacion);
				bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdArea", IdArea);
				bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTipoTramite", TipoTramite);
				bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NroAsignacion", NroAsig);
				bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Decision", Decision);
				bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iNoFormularioCalculo", NroFormularioCalculo);
				bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NroCertificadoAnt", CertActual);
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
		//Actualiza el Nro de Certificado para adicionar el nuevo registro
		public bool CertificadoReprocesado(int iIdConexion, string cOperacion, Int64 Tramite, Int32 GrupoB, Int32 NroCertificado,Int32 TipoTramite,Int32 TipoReproceso, Int32 NroFormularioRepro, Int32 iNoFormularioCalculo, ref string sMensajeError)
		{
			ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "EmisionCC.PR_CertificadoCCReprocesos", cOperacion);
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
				bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdGrupoBeneficio", GrupoB);
				bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iNroCertificado", NroCertificado);
				bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTipoTramite", TipoTramite);
				bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@TipoReproceso", TipoReproceso);
				bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NroReproceso", NroFormularioRepro);
				bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iNoFormularioCalculo", iNoFormularioCalculo);
				bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@o_iNroCertificadoReemplazo", iNroCertificadoReemplazo);
				
				if (bAsignacionOK)
				{
					if (!ObjSPExec.EjecutarProcedimientoQry())
					{
						sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
					}
					else
					{
						int iNroCertificadoReemplazoTmp = 0;
						ObjSPExec.ObtenerValorParametro("@o_iNroCertificadoReemplazo", ref iNroCertificadoReemplazoTmp);
						iNroCertificadoReemplazo = iNroCertificadoReemplazoTmp;
					}
				}
			}
			return (ObjSPExec.p_bEstadoOK);
		}
		public bool ObtieneParametros(int iIdConexion, string cOperacion, Int64 Tramite, Int32 GrupoB, Int32 IdTipoTramite,Int32 NroCertificado, ref string sMensajeError, ref DataSet DSetTmp)
		{
			ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "EmisionCC.PR_CertificadoCCReprocesos", cOperacion);
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
				bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdGrupoBeneficio", GrupoB);
				bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTipoTramite", IdTipoTramite);
				bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iNroCertificado", NroCertificado);
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

		public bool ValoresCC(int iIdConexion, string cOperacion, ref string sMensajeError, ref DataSet DSetTmp)
		{
			ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "EmisionCC.PR_ResolucionSello", cOperacion);
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
	


	//INICIO DE NUEVA CLASE (MODIFICAR)

	public class clsFormularioCalculoCCDA
	{
		Database db2 = null;
		public clsFormularioCalculoCCDA()
		{
			db2 = DatabaseFactory.CreateDatabase("cadena");
		}
		/* Obtener FormularioCalculoCC */
		public IDataReader ObtenerFormularioCalculoCC(Int64 tra,int ben)
		{
			DbCommand cmd = db2.GetStoredProcCommand("CertificacionCC.PR_FormularioCalculoCCObtener ", tra,ben);
			IDataReader dataReader = db2.ExecuteReader(cmd);
			return dataReader;
		}
	}
	public class clsCertificadoCCDA
	{
		Database db2 = null;
		public clsCertificadoCCDA()
		{
			db2 = DatabaseFactory.CreateDatabase("cadena");
		}
		/* Obtener FormularioCalculoCC */
		public IDataReader ObtenerCertificadoCC(int tra, int ben,int tipoformcal, int nroformcal)
		{
			DbCommand cmd = db2.GetStoredProcCommand("CertificacionCC.PR_CertificadoCCObtener", tra, ben,tipoformcal,nroformcal);
			IDataReader dataReader = db2.ExecuteReader(cmd);
			return dataReader;
		}
	}
	public class clsComponenteCCDA
	{ 
		 Database db2 = null;
		 public clsComponenteCCDA()
		{
			db2 = DatabaseFactory.CreateDatabase("cadena");
		}
		/* Obtener FormularioCalculoCC */
		public IDataReader ObtenerComponenteCC(Int64 tra,int ben)
		{
			DbCommand cmd = db2.GetStoredProcCommand("CertificacionCC.PR_ComponenteCCObtener ", tra, ben);
			IDataReader dataReader = db2.ExecuteReader(cmd);
			return dataReader;
		}
	}
	public class clsDatosPersonaDA
	{
		Database db2 = null;
		public clsDatosPersonaDA()
		{
			db2 = DatabaseFactory.CreateDatabase("cadena");
		}
		/* Obtener FormularioCalculoCC */
		public IDataReader ObtenerDatosPersona(Int64 tra, int ben)
		{
			DbCommand cmd = db2.GetStoredProcCommand("EmisionCC.PR_DatosPersonaObtener ", tra, ben);
			IDataReader dataReader = db2.ExecuteReader(cmd);
			return dataReader;
		}
	}
}
