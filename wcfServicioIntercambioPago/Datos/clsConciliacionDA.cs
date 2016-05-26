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
using wcfServicioIntercambioPago.Entidades;
using SQLSPExecuter;

namespace wcfServicioIntercambioPago.Datos
{
    public class clsConciliacionDA
    {
          Database db = null;

          public clsConciliacionDA()
        {
            db = DatabaseFactory.CreateDatabase("cadena");
        }

          public bool ActualizaComprobante(int iIdConexion, string cOperacion, string Entidad, string Periodo, string Comprobante, ref string sMensajeError)
          {
              ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "PagoCC.PR_ActualizaComprobante", cOperacion);
              if (!ObjSPExec.p_bEstadoOK)
              {
                  sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
              }
              else
              {
                  bool bAsignacionOK = true;
                  bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                  bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                  bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Entidad", Entidad);
                  bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Periodo", Periodo);
                  bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Comprobante", Comprobante);

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

          public bool FiltrosConciliacion(int iIdConexion, string cOperacion, string TipoFiltro, string Entidad, string TipoMedio
                                    , string PeriodoInicio, string PeriodoFinal, ref string sMensajeError, ref DataSet DSetTmp)
          {
              ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "PagoCC.PR_FiltrosConciliacion", cOperacion);

              if (!ObjSPExec.p_bEstadoOK)
              {
                  sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
              }
              else
              {
                  bool bAsignacionOK = true;
                  bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                  bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                  bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@TipoFiltro", TipoFiltro);
                  bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Entidad", Entidad);
                  bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@TipoMedio", TipoMedio);
                  bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@PeriodoInicio", PeriodoInicio);
                  bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@PeriodoFin", PeriodoFinal);


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