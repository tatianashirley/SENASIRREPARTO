using SQLSPExecuter;
using wcfInicioTramite.Entidades;

namespace wcfInicioTramite.Datos
{
    public class clsObservadoDA : clsObservadoBE
    {
        //Procedimiento para registrar tramite observado
        public bool Registrar()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Tramite.PR_Observado", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdObservado", IdObservado);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNumeroDocumento", NumeroDocumento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iCUA", CUA);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sMatricula", Matricula);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sTabla", Tabla);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sPrimerApellido", PrimerApellido);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sSegundoApellido", SegundoApellido);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sPrimerNombre", PrimerNombre);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sAutorizador", Autorizador);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sMotivo", Motivo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sObservacion", Observaciones);

                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                    else
                    {
                        int lIdObservado = 0;
                        ObjSPExec.ObtenerValorParametro("@i_iIdObservado", ref lIdObservado);
                        IdObservado = lIdObservado;
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }
    }
}