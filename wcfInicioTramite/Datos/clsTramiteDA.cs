using SQLSPExecuter;
using System.Data;
using wcfInicioTramite.Tramite.Entidades;
using wcfInicioTramite.Tramite.Logica;

namespace wcfInicioTramite.Tramite.Datos
{
    public class clsTramiteDA : clsTramiteBE
    {
        //Procedimiento para obtener parametros 
        public bool ObtenerParametros(int iIdConexion, string cOperacion, string sParametro, ref string sMensajeError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Tramite.PR_ObtenerParametros", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sParametro", sParametro);

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

        //Procedimiento para obtener clasificador


        public bool ObtenerClasificador(int iIdConexion, string cOperacion, int iTabla, ref string sMensajeError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Tramite.PR_ObtenerClasificadores", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iTabla", iTabla);

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

        //Procedimiento para obtener clasificador por descripcion
        public bool ObtenerClasificadorPorDescripcion(int iIdConexion, string cOperacion, int iTipo, string sDescripcionClasificador, ref string sMensajeError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Tramite.PR_ObtenerClasificadorPorDescripcion", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTipoClasificador", iTipo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sDescripcionClasificador", sDescripcionClasificador);

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

        //Procedimiento para buscar empresas
        public bool BuscarEmpresa(int iIdConexion, string cOperacion, string sNombreEmpresa, string sRucEmpresa, ref string sMensajeError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Tramite.PR_BuscarEmpresa", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNombreEmpresa", sNombreEmpresa);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sRucEmpresa", sRucEmpresa);

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

        //Procedimiento para buscar paises
        public bool BuscarPais()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Tramite.PR_BuscarPais", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sPais", Pais);

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

        //Procedimiento para buscar localidades
        public bool BuscarLocalidad()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Tramite.PR_BuscarLocalidad", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sLocalidad", Localidad);

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

        //Procedimiento para validar CUA
        public bool ValidarCUA()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Tramite.PR_ValidarCUA", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sApellidoPaterno", PrimerApellido);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sApellidoMaterno", SegundoApellido);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sPrimerNombre", Nombre);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sSegundoNombre", SegundoNombre);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sSexo", Sexo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNua", Nua);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNumeroDocumento", NumeroDocumento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sMatricula", Matricula);
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

        //Procedimiento para validar inicio tramite
        public bool ValidarInicio()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Tramite.PR_ValidarInicio", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sApellidoPaterno", PrimerApellido);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sApellidoMaterno", SegundoApellido);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNombre", Nombre);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNumeroDocumento", NumeroDocumento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNua", Nua);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sMatricula", Matricula);
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

        //Procedimiento para obtener datos del inicio tramite
        public bool ObtenerInicioTramite()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Tramite.PR_TramitePersona", cOperacion);

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
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdGrupoBeneficio", IdGrupoBeneficio);
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

        //Procedimiento para registrar tramite persona
        public bool RegistrarTramite(int iIdConexion, string cOperacion, ref clsTramite cTramite, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Tramite.PR_TramitePersona", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTramite", cTramite.IdTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdGrupoBeneficio", cTramite.IdGrupoBeneficio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdBeneficio", cTramite.IdBeneficio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdSubBeneficio", cTramite.IdSubBeneficio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTipoTramite", cTramite.IdTipoTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdOrigen", cTramite.IdOrigen);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdSector", cTramite.IdSector);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iNUP", cTramite.NUP);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iNUPIniciaTramite", cTramite.NUPIniciaTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTipoIniciaTramite", cTramite.IdTipoIniciaTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sObservaciones", cTramite.Observaciones);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdEstadoTramite", cTramite.IdEstadoTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdClaseRenta", cTramite.IdClaseRenta);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNumeroTramiteCrenta", cTramite.NumeroTramiteCRENTA);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdObservado", cTramite.IdObservado);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_bRegistroActivo", cTramite.RegistroActivo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdOficinaNotificacion", cTramite.IdOficinaNotificacion);

                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                    else
                    {
                        long lIdTramite = 0;
                        ObjSPExec.ObtenerValorParametro("@i_iIdTramite", ref lIdTramite);
                        cTramite.IdTramite = lIdTramite;
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }

        //Procedimiento para validar inicio tramite
        public bool ValidarProcesoAutomatico(int iIdConexion, string cOperacion, long iIdTramite, ref int bValidoManual, ref string sMensajeValidacion, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Tramite.PR_ValidarSalario", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdTramite", iIdTramite);

                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                    else
                    {
                        ObjSPExec.ObtenerValorParametro("@s_bValidoManual", ref bValidoManual);
                        ObjSPExec.ObtenerValorParametro("@s_sMensaje", ref sMensajeValidacion);
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }

        //Procedimiento para registrar tramite persona
        public bool RegistrarTramiteFFAA(int iIdConexion, string cOperacion, string sNUA, int iIdContinuo, long iIdTramite, string sObservaciones, ref string sDetalleTramite, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Tramite.PR_TramiteFFAA", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNUA", sNUA);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdContinuo", iIdContinuo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTramiteManual", iIdTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sObservaciones", sObservaciones);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sDetalleTramite", sDetalleTramite);

                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                    else
                    {
                        string sDetalle = "";
                        ObjSPExec.ObtenerValorParametro("i_sDetalleTramite", ref sDetalle);
                        sDetalleTramite = sDetalle;
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }

        //Procedimiento para obtener reporte tramite
        public bool ObtenerDatosReporte(int iIdConexion, string cOperacion, long IdTramite, string sTipoInf, ref string sMensajeError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Tramite.PR_Reporte", cOperacion);

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
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sTipoInformacion", sTipoInf);

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

        //Procedimiento para buscar tramite para renuncua automatica
        public bool BuscarTramite(int iIdConexion, string cOperacion, string iIdTramite, int iIdGrupoBeneficio, string sPrimerNombre, string sSegundoNombre, string sPrimerApellido, string sSegundoApellido, string sNumeroDocumento, string sCUA, string sMatricula, string sEstadoTramite, ref string sMensajeError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Tramite.PR_BuscarTramite", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdTramite", iIdTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdGrupoBeneficio", iIdGrupoBeneficio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sPrimerNombre", sPrimerNombre);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSegundoNombre", sSegundoNombre);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sPrimerApellido", sPrimerApellido);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSegundoApellido", sSegundoApellido);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sNumeroDocumento", sNumeroDocumento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sCUA", sCUA);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sMatricula", sMatricula);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sEstadoTramite", sEstadoTramite);

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

        //Procedimiento para buscar tramite para renuncua automatica
        public bool BuscarTramiteReparto(int iIdConexion, string cOperacion, string iIdTramite, string sPrimerNombre, string sSegundoNombre, string sPrimerApellido, string sSegundoApellido, string sNumeroDocumento, string sCUA, string sMatricula, string sEstadoTramite, ref string sMensajeError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Tramite.PR_BuscarTramite_Reparto", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdTramite", iIdTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sPrimerNombre", sPrimerNombre);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSegundoNombre", sSegundoNombre);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sPrimerApellido", sPrimerApellido);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSegundoApellido", sSegundoApellido);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sNumeroDocumento", sNumeroDocumento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sCUA", sCUA);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sMatricula", sMatricula);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sEstadoTramite", sEstadoTramite);

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

        //Procedimiento para obtener reporte tramite
        public bool RenunciaTramite(int iIdConexion, string cOperacion, long IdTramite, int iIdGrupoBeneficio, string sObservaciones, ref long lIdTramite, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Tramite.PR_RenunciaAutomatica", cOperacion);

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
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdGrupoBeneficio", iIdGrupoBeneficio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sObservaciones", sObservaciones);
                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                    else
                    {
                        ObjSPExec.ObtenerValorParametro("@i_iNewIdTramite", ref lIdTramite);
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }

        //Procedimiento para registrar tramite workflow
        public bool IniciarTramite(int iIdConexion, string cOperacion, ref clsTramite cTramite, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Tramite.PR_IniciaTramite", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", cTramite.sesion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTramite", cTramite.IdTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdGrupoBeneficio", cTramite.IdGrupoBeneficio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdFlujo", cTramite.IdFlujoTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_bValidoManual", cTramite.validoManual);
                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }

        //Procedimiento para modificar oficina notificacion
        public bool ModificarOficina()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Novedades.PR_TramiteModNotif", cOperacion);

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
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdOficinaNotificacion", IdOficinaNotificacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Glosa", Observaciones);
                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }

        //Procedimiento para obtener clasificador SSLP
        public bool ObtenerClasificadorSSLP()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Tramite.PR_ObtenerClasificadoresSSLP", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdSector", IdSector);

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

        //Procedimiento para validar flujo tramite
        public bool ControlEstados(ref string sURL)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Tramite.PR_ControlEstados", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdTramite", IdTramite);
                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                    else
                    {
                        ObjSPExec.ObtenerValorParametro("@s_sURL", ref sURL);
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }

        //Procedimiento para flujo tramite
        public bool FlujoTramiteDA()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "WFArticulador.PR_FlujoTramite", cOperacion);
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
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Tipo", Tipo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdTramite", IdTramite);

                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }

        //Procedimiento para consulta de tramite
        public bool ConsultaTramiteDA()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Tramite.PR_ConsultaTramite", cOperacion);
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
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdTramite", IdTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sTipoTramite", Tipo);

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