using SQLSPExecuter;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using wcfWFArticulador.Entidades;

namespace wcfWFArticulador.Tramite.Datos
{
    public class clsSeguimientoTramiteDA : clsSeguimientoTramiteBE
    {
        //Procedimiento para obtener datos tramite
        public bool ObtenerDatosTramite()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "WFArticulador.PR_ListarTramites", cOperacion);

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
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Tipo", TipoConsulta);
                
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