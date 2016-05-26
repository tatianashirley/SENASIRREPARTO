using SQLSPExecuter;
using System.Data;
using wcfInicioTramite.Entidades;
using wcfInicioTramite.Logica;

namespace wcfInicioTramite.Datos
{

    public class clsAfiliadoApDA : clsAfiliadoApBE
    {
        //Procedimiento para buscar datos afiliado AP
        public bool Buscar()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Referencial.PR_AFILIADOS_AP", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNUA", NUA);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNUM_IDENTIFICACION", NumeroIdentificacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sPRIMER_APELLIDO", PrimerApellido);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sSEGUNDO_APELLIDO", SegundoApellido);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sPRIMER_NOMBRE", PrimerNombre);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sSEGUNDO_NOMBRE", SegundoNombre);
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

        //Procedimiento para registrar afiliado ap
        public bool Registrar()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Referencial.PR_AFILIADOS_AP", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sCOD_AFP", CodAFP);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNUA", NUA);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fFEC_NACIMIENTO", FechaNacimiento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sTIP_IDENTIFICACION", TipoIdentificacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNUM_IDENTIFICACION", NumeroIdentificacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sPRIMER_APELLIDO", PrimerApellido);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sSEGUNDO_APELLIDO", SegundoApellido);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sPRIMER_NOMBRE", PrimerNombre);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sSEGUNDO_NOMBRE", SegundoNombre);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sAPELLIDO_CONYUGUE", ApellidoConyuge);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sMOTIVO", Motivo);
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

        //Procedimiento para actualizar afiliado ap
        public bool Actualizar()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Referencial.PR_AFILIADOS_AP", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sCOD_AFP", CodAFP);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNUA", NUA);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fFEC_NACIMIENTO", FechaNacimiento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sTIP_IDENTIFICACION", TipoIdentificacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNUM_IDENTIFICACION", NumeroIdentificacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sPRIMER_APELLIDO", PrimerApellido);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sSEGUNDO_APELLIDO", SegundoApellido);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sPRIMER_NOMBRE", PrimerNombre);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sSEGUNDO_NOMBRE", SegundoNombre);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sAPELLIDO_CONYUGUE", ApellidoConyuge);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sMOTIVO", Motivo);
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
    }
}