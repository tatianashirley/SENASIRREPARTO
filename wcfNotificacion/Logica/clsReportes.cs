using System;
using System.Data;
using System.Linq;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using wcfNotificacion.Datos;

namespace wcfNotificacion.Logica
{
    public class clsReportes
    {
        clsReportesDA Reporte = new clsReportesDA();

        public DataTable Vencidos_Pendiente(int iIdConexion, string cOperacion, Int32 IdOficina, Int32 TipoReporte, string TipoDocumento, string FechaIni, string FechaFin, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (Reporte.Vencidos_Pendiente(iIdConexion,cOperacion,IdOficina,TipoReporte,TipoDocumento,FechaIni,FechaFin,ref sMensajeError,ref DSetTmp))
            {
                return DSetTmp.Tables[0];
            }
            else
            {
                return (null);
            }
        }
        public DataTable CuentaUsuario(int iIdConexion, string cOperacion,ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (Reporte.CuentaUsuario(iIdConexion, cOperacion, ref sMensajeError, ref DSetTmp))
            {
                return DSetTmp.Tables[0];
            }
            else
            {
                return (null);
            }
        }

        public DataTable ListadoDocumentos(int iIdConexion, string cOperacion, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (Reporte.ListadoDocumentos(iIdConexion, cOperacion, ref sMensajeError, ref DSetTmp))
            {
                return DSetTmp.Tables[0];
            }
            else
            {
                return (null);
            }
        }

        /* Listados para generacion de Grillas y Reportes */
        public DataTable DocumentosEnv_Dev(int iIdConexion, string cOperacion, Int32 IdReporte, string IdDocumento, string Regional,string FechaIni,string FechaFin, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (Reporte.DocumentosEnv_Dev(iIdConexion, cOperacion, IdReporte,IdDocumento,Regional,FechaIni,FechaFin,ref sMensajeError, ref DSetTmp))
            {
                return DSetTmp.Tables[0];
            }
            else
            {
                return (null);
            }
        }

        public DataTable Regional(int iIdConexion, string cOperacion, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (Reporte.Regional(iIdConexion, cOperacion, ref sMensajeError, ref DSetTmp))
            {
                return DSetTmp.Tables[0];
            }
            else
            {
                return (null);
            }
        }
        public DataTable Procedimiento(int iIdConexion, string cOperacion, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (Reporte.Procedimiento(iIdConexion, cOperacion, ref sMensajeError, ref DSetTmp))
            {
                return DSetTmp.Tables[0];
            }
            else
            {
                return (null);
            }
        }
    }
}