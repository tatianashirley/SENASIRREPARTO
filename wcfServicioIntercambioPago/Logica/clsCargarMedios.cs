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
    public class clsCargarMedios: clsCargaMediosBE
    {
        //Inserta en las temporales
        public Boolean InsertaTemporal(string TipoMedio,int Periodo,string Entidad, string Planilla, string PeriodoPlanilla
                                        ,Int64 CUA, int NumeroCertificado, string TipoCC, Int64 CI, int CodigoTransaccion
                                        ,double MontoTransaccion, string FechaInicio, string FechaFinal, int regional)
        {
            clsCargarMediosDA ins = new clsCargarMediosDA();
            return ins.InsertaTemporal(TipoMedio, Periodo, Entidad, Planilla, PeriodoPlanilla, CUA, NumeroCertificado, TipoCC,
                                        CI, CodigoTransaccion, MontoTransaccion, FechaInicio, FechaFinal, regional);
        }

        // Elimina de la temporales
        public Boolean EliminarTemporal(string TipoMedio,string IdEntidad, int Envio)
        {
            clsCargarMediosDA eli = new clsCargarMediosDA();
            return eli.EliminaTemporal(TipoMedio, IdEntidad, Envio);
        }
        public string InsertaBulk(DataTable TablaOrigen,string TablaDestino)
        {
            clsCargarMediosDA ins = new clsCargarMediosDA();
            return ins.insertaBulk(TablaOrigen, TablaDestino);
        }
    }
}