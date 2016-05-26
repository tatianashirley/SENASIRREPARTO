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
    public class clsRecepcion
    {
        clsRecepcionDA Documento = new clsRecepcionDA();
        public DataTable ObtieneDatos(int IdConexion, string cOperacion,/* string Tipo,*/ ref string sMensajeError) 
        {   
            DataSet DSetTmp = new DataSet();
            if (Documento.ObtieneDatos(IdConexion, cOperacion, /*Tipo,*/ ref sMensajeError, ref DSetTmp))
                return DSetTmp.Tables[0];
            else
                return (null);

        }

        public bool RegistraRecepcion(int iIdConexion, string cOperacion,/* string Tipo,*/ Int64 Tramite, int GrupoBeneficio, string FechaDocumento, int NroDocumento, int IdDocumento, string FecNot, ref string sMensajeError)
        {
            bool bAsignacionOK = Documento.RegistraRecepcion(iIdConexion, cOperacion/*, Tipo*/, Tramite, GrupoBeneficio, IdDocumento, FechaDocumento, NroDocumento, FecNot, ref sMensajeError);
            return (bAsignacionOK);

        }

        public DataTable DocumentosRecepcionNotificacion(int iIdConexion, string cOperacion, Int64 IdTramite, Int32 IdGrupo, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (Documento.DocumentosRecepcionNotificacion(iIdConexion, cOperacion, IdTramite,IdGrupo,ref sMensajeError, ref DSetTmp))
                return DSetTmp.Tables[0];
            else
                return (null);

        }
        public DataTable DocsRecepcion(int IdConexion, string cOperacion,Int64 IdTramite,Int32 IdGrupoBeneficio, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (Documento.DocsRecepcion(IdConexion, cOperacion,IdTramite,IdGrupoBeneficio, ref sMensajeError, ref DSetTmp))
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