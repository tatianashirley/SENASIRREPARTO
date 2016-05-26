using System.Collections.Generic;
using System.Data;
using SQLSPExecuter;
using System;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Configuration;
using wcfPagoUnico.Entidades;

namespace wcfPagoUnico.Datos
{
    public class clsPUProcesosDA
    {
        //Registra documentos con solicitante
        public bool RegistraDocumentos(int iIdConexion, string cOperacion, ref string sMensajeError, List<int>Documento, long vCUA, long vNUP, ref long NUPResultado)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "PagoU.PR_RegistraDocumento", cOperacion);

            foreach (int doc in Documento)
            {
                if (!ObjSPExec.p_bEstadoOK)
                {
                    sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                }
                else
                {
                    bool bAsignacionOK = true;
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iCUA", vCUA);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iNUP", vNUP);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdDocumento", doc);

                    if (bAsignacionOK)
                    {
                        if (!ObjSPExec.EjecutarProcedimientoQry())
                        {
                            sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                        }
                        else
                        {
                            long lNup = 0;
                            ObjSPExec.ObtenerValorParametro("@i_iNUP", ref lNup);
                            NUPResultado = lNup;
                            //ObjSPExec.p_bEstadoOK = true;
                        }
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }

        //Obtiene los documentos que fueron presentados por el titular o DH
        public bool ObtieneDocumentos(int iIdConexion, string cOperacion, ref string sMensajeError, ref DataSet DSetTmp, long vCUA)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "PagoU.PR_ObtieneDocumentos", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@vCUA", vCUA);

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

        //Obtiene el clasificador de los porcentajes que se debe asignar a un DH
        public IDataReader ObtieneClasiPorcentaje()
        {
            Database db = null;
            db = DatabaseFactory.CreateDatabase("cadena");

            DbCommand cmd = db.GetStoredProcCommand("PagoU.PR_ObtieneClasiPorcentaje");
            cmd.CommandTimeout = 0;
            IDataReader dr = db.ExecuteReader(cmd);
            return dr;
        }

        //Actualiza los datos del certificado
        public long ActualizaCertificado(int iIdConexion, string cOperacion, ref string sMensajeError, long NUP, string HojaRuta, long Tramite, int NumeroCertificado, long AniosInsalubres, string PersonaSol, DataTable tDH, string TipoSolicitud)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;

                using (var conn = new SqlConnection(cs))
                {
                    using (var cmd = new SqlCommand("PagoU.PR_ActualizaCertificado", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@s_iIdConexion", iIdConexion);
                        cmd.Parameters.AddWithValue("@s_cOperacion", cOperacion);
                        cmd.Parameters.AddWithValue("@i_iNUP", NUP);
                        cmd.Parameters.AddWithValue("@i_sHojaRuta", HojaRuta);
                        cmd.Parameters.AddWithValue("@vTramite", Tramite);
                        cmd.Parameters.AddWithValue("@NumeroCertificado", NumeroCertificado);
                        cmd.Parameters.AddWithValue("@vAniosInsalubres", AniosInsalubres);
                        cmd.Parameters.AddWithValue("@vPersonaSol", PersonaSol);
                        cmd.Parameters.AddWithValue("@tDH", tDH);
                        cmd.Parameters.AddWithValue("@TipoSolicitud", TipoSolicitud);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        return NUP;
                    }
                }
            }
            catch (Exception ex)
            {
                sMensajeError = sMensajeError + " " + ex.Message + "\n" + ex.StackTrace;
                return 0;
            }
        }

        //Actualiza los estados del PU
        public bool ActualizaEstadosPU(int IdConexion, string cOperacion, ref string sMensajeError, long NUPTitular, long NUPDH, int Estado, long Tramite, int NumeroCertificado, ref long NUPRes)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(IdConexion, "PagoU.PR_ActualizaEstadosPU", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                ObjSPExec.p_RemplazarCeroPorDBNull = false;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", IdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@vNUPTitular", NUPTitular);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@vNUPDH", NUPDH);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iEstado", Estado);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@vTramite", Tramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NumeroCertificado", NumeroCertificado);
                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                    else
                    {
                        ObjSPExec.ObtenerValorParametro("@i_iNUP", ref NUPRes);
                        if (NUPRes == 0)
                        {
                            switch (Estado)
                            {
                                case 31510:
                                    sMensajeError = "Los datos que desea cambiar de estado no esta CALIFICADO";
                                    break;
                                case 31509:
                                    sMensajeError = "Los datos que desea cambiar de estado no esta AUTORIZADO";
                                    break;
                            }
                        }
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }

        //Obtiene datos del Titular o DH solicitante.
        public bool ObtieneDatosSolicitantes(int IdConexion, string cOperacion, ref string sMensajeError, string vMatricula, string vNroDocumento, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(IdConexion, "Persona.PR_ObtieneDatosSolicitantes", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", IdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sMatricula", vMatricula);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@vNumeroDocumento", vNroDocumento);

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

        //Genera el numero de cheque.
        public bool GeneraChequePU(int IdConexion, string cOperacion, ref string sMensajeError, int vIdBanco, int vC31, int vAnioProc, int vMesProc, ref long NUPResultado)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(IdConexion, "PagoU.PR_GeneraChequePU", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", IdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdBanco", vIdBanco);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iC31", vC31);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@vAnioProc", vAnioProc);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@vMesProc", vMesProc);
                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                    else
                    {
                        long lNup = 0;
                        ObjSPExec.ObtenerValorParametro("@i_iNUP", ref NUPResultado);
                        switch (NUPResultado)
                        {
                            case 0:
                                sMensajeError = "Uno o varios registros que desea procesar, no se encuentran en estado REVISADO.";
                                break;
                            case -1:
                                sMensajeError = "El documento C31 ingresado no se encuentra registrado, por favor registre primero el documento C31.";
                                break;
                        } 
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }

        //Resgistra la resolucion que fue otorgada a la solicitud de pago del PU.
        public bool RegistraResolucion(int IdConexion, string cOperacion, ref string sMensajeError, long vNUPTitular, long vNUPDH, long vResolucion, DateTime vFechaReso, ref long NUPResultado)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(IdConexion, "PagoU.PR_RegistraResolucion", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                ObjSPExec.p_RemplazarCeroPorDBNull = false;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", IdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iNUPTitular", vNUPTitular);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iNUPDH", vNUPDH);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iResolucion", vResolucion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fFechaResolucion", vFechaReso);
                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                    else
                    {
                        long lNup = 0;
                        ObjSPExec.ObtenerValorParametro("@i_iNUP", ref NUPResultado);
                        if (NUPResultado == 0)
                        {
                            sMensajeError = "La solicitud de la Matricula ingresada, no se encuentra REVISADO";
                        }
                        if (NUPResultado == -1)
                        {
                            sMensajeError = "El número de resolución ya se encuentra registrada.";
                        }

                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }

        //Lista todos las personas Titulares o DH para pagar el PU por mes
        public bool ListarAprobadosMes(int IdConexion, string cOperacion, ref string sMensajeError, int vAnio, int vMes, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(IdConexion, "PagoU.PR_ListarAprobadosMes", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", IdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@vAnio", vAnio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@vMes", vMes);

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

        //Registra el documento C31.
        public bool RegistraC31(int IdConexion, string cOperacion, ref string sMensajeError, clsPUC31 C31, ref long vResultado)
        {
            try
            {
                ClassSPExec ObjSPExec = new ClassSPExec(IdConexion, "PagoU.PR_RegistraC31", cOperacion);

                if (!ObjSPExec.p_bEstadoOK)
                {
                    sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                }
                else
                {
                    bool bAsignacionOK = true;
                    ObjSPExec.p_RemplazarCeroPorDBNull = false;
                    ObjSPExec.p_RemplazarCadenaVaciaPorDBNull = false;
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", IdConexion);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iC31", C31.C31);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iAniop", C31.Aniop);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iAnio", C31.Anio);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sEnt", C31.Ent);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iDad", C31.Dad);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iUes", C31.Ues);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iC31_Rev", C31.C31_Rev);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iMes", C31.Mes);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sFte", C31.Fte);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sOrg", C31.Org);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sGlosa", C31.Glosa);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sTip", C31.Tip);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sCpl", C31.Cpl);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sCpd", C31.Cpd);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_mTotal", C31.Total);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_mRetension", C31.Retension);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sIns", C31.Ins);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sTco", C31.Tco);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sSeg", C31.Seg);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iAnioProceso", C31.AnioProceso);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iMesProceso", C31.MesProceso);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sSeguros", C31.Seguros);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sCodigo", C31.Codigo);

                    if (bAsignacionOK)
                    {
                        if (!ObjSPExec.EjecutarProcedimientoQry())
                        {
                            sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                        }
                        else
                        {
                            ObjSPExec.ObtenerValorParametro("@Resul", ref vResultado);
                            if (vResultado == -1)
                            {
                                sMensajeError = "Documento C31, ya fue registrado en el mes, por favor verifique.";
                            }
                            if (vResultado == -2)
                            {
                                sMensajeError = "Documento C31, existente en la gestion, por favor verifique.";
                            }
                        }
                    }
                    else
                    {
                        sMensajeError = "Error al asginar datos a los parametros.";
                    }

                }
                return (ObjSPExec.p_bEstadoOK);
            }
            catch (Exception ex)
            {
                sMensajeError = ex.Message + "\n" + ex.StackTrace;
                return false;
            }

        }

        //Obtiene el C31 de un anio y mes de procesos dados.
        public bool ObtieneC31(int IdConexion, string cOperacion, ref string sMensajeError, int vAnioProc, int vMesProc, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(IdConexion, "PagoU.PR_ObtieneC31", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", IdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iAnio", vAnioProc);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iMes", vMesProc);

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

        //Obtiene el C31 en general.
        public bool ObtieneGeneralC31(int IdConexion, string cOperacion, ref string sMensajeError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(IdConexion, "PagoU.PR_ObtieneC31", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                ObjSPExec.p_RemplazarCeroPorDBNull = false;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", IdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iAnio", 0);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iMes", 0);

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

        //Modifica los datos del C31 de un anio y mes de procesos dados.
        public bool ModificaC31(int iIdConexion, string cOperacion, ref string sMensajeError, int vC31, decimal vTotal, int vAnioProceso, int vMesProceso, ref long Resultado)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "PagoU.PR_ModificaC31", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                ObjSPExec.p_RemplazarCeroPorDBNull = false;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iC31", vC31);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_mTotal", vTotal);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iAnioProceso", vAnioProceso);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iMesProceso", vMesProceso);
                
                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                    else
                    {
                        long lNup = 0;
                        ObjSPExec.ObtenerValorParametro("@Res", ref Resultado);
                        if (Resultado==0)
                        {
                                sMensajeError="No se encontro el documento C31 ingresado para ser modificado."; 
                        }
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }

        //Genera los datos necesarios para crear el medio para el C31.
        public bool GeneraMediosC31(int IdConexion, string cOperacion, ref string sMensajeError, int vC31, int vAnio, int vMes, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(IdConexion, "PagoU.PR_GeneraMediosC31", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", IdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iC31", vC31);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iAnio", vAnio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iMes", vMes);

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

        //Genera los datos necesarios para crear el medio para el PU.
        public bool GeneraMediosPU(int IdConexion, string cOperacion, ref string sMensajeError, int vC31, int vAnio, int vMes, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(IdConexion, "PagoU.PR_GeneraMediosPU", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", IdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@vAnio", vAnio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@vMes", vMes);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@vC31", vC31);

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

        //Devuelve si el NUP ingresado tiene un cheque en estado Revertido o los montos antriores y actualizados
        public bool ChequeRevertido(int IdConexion, string cOperacion, ref string sMensajeError, long vNUP, ref int Cantidad)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(IdConexion, "PagoU.PR_ChequeRevertido", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", IdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iNUP", vNUP);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@vOpcion", 1);

                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                    else
                    {
                        DataSet DSetTmp = new DataSet();
                        DSetTmp = ObjSPExec.p_DataSetResultado;
                        Cantidad = Convert.ToInt16(DSetTmp.Tables[0].Rows[0]["CANTIDAD"].ToString());
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }

        //Devuelve si el NUP ingresado tiene un cheque en estado Revertido o los montos antriores y actualizados
        public bool MontosCertificado(int IdConexion, string cOperacion, ref string sMensajeError, long vNUP, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(IdConexion, "PagoU.PR_ChequeRevertido", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", IdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iNUP", vNUP);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@vOpcion", 2);

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

        //Dar de baja el documento C31 y las presolicitudes los certificados.
        public bool AnulaC31(int iIdConexion, ref string sMensajeError, int vAnio, int vMes, ref int Resultado)
        {
            string cOperacion = "U";
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "PagoU.PR_AnularRegistros", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iAnio", vAnio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iMes", vMes);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@vOpcion", 1);

                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                    else
                    {
                        ObjSPExec.ObtenerValorParametro("@vResultado", ref Resultado);
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }

        //Dar de baja el documento C31 y las presolicitudes los certificados.
        public bool AnularCheque(int iIdConexion, ref string sMensajeError, int vNumeroCheque, int vNumeroBanco, ref int Resultado)
        {
            string cOperacion = "U";
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "PagoU.PR_AnularRegistros", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@vNumeroCheque", vNumeroCheque);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@vNumeroBanco", vNumeroBanco);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@vOpcion", 2);

                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                    else
                    {
                        ObjSPExec.ObtenerValorParametro("@vResultado", ref Resultado);
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }


        //Lista los cheques generados en un determinado ao y mes ingresados.
        public bool ListadoChequesGenerados(int IdConexion, string cOperacion, ref string sMensajeError, int vAnio, int vMes, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(IdConexion, "PagoU.PR_ListadoChequesGenerados", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", IdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iAnio", vAnio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iMes", vMes);

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