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
using wcfServicioIntercambioPago.Datos;
using wcfServicioIntercambioPago.Entidades;
namespace wcfServicioIntercambioPago.Logica
{
    public class clsConciliacion
    {
        clsConciliacionDA Concil = new clsConciliacionDA();

        public bool ActualizaComprobante(int iIdConexion, string cOperacion, string Entidad, string Periodo, string Comprobante, ref string sMensajeError)
        {
            bool Respuesta = Concil.ActualizaComprobante(iIdConexion, cOperacion, Entidad, Periodo, Comprobante, ref sMensajeError);
            return (Respuesta);
        }

        public DataTable FiltrosConciliacion(int iIdConexion, string cOperacion, string TipoFiltro, string Entidad, string TipoMedio
                                    , string PeriodoInicio, string PeriodoFinal, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (Concil.FiltrosConciliacion(iIdConexion, cOperacion, TipoFiltro, Entidad, TipoMedio, PeriodoInicio, PeriodoFinal, ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }
    }
}