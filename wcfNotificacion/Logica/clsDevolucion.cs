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
    public class clsDevolucion
    {
        clsDevolucionDA Documento = new clsDevolucionDA();
        public DataTable ObtieneDatos(int IdConexion, string cOperacion,/* string Tipo,*/ ref string sMensajeError) 
        {
            DataSet DSetTmp = new DataSet();
            if (Documento.ObtieneDatos(IdConexion, cOperacion, /*Tipo,*/ ref sMensajeError, ref DSetTmp))
                return DSetTmp.Tables[0];
            else
                return null;
        }

        public DataTable DocsUltimosDevueltos(int IdConexion, string cOperacion, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (Documento.DocsUltimosDevueltos(IdConexion, cOperacion, ref sMensajeError, ref DSetTmp))
                return DSetTmp.Tables[0];
            else
                return null;
        }

        public DataTable DocumentosDevolucion(int iIdConexion, string cOperacion, Int64 IdTramite, Int32 IdGrupoB, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (Documento.DocumentosDevolucion(iIdConexion, cOperacion, IdTramite,IdGrupoB, ref sMensajeError, ref DSetTmp))
                return DSetTmp.Tables[0];
            else
                return null;
        }

        public bool RegistraDevolucion(int IdConexion, string cOperacion, /*string Tipo,*/ Int64 Tramite, Int32 GrupoBeneficio, Int32 IdDocumento,string FechaDocumento,Int32 NroDocumento,string CiteDescDev, string FechaCiteDev,string FechaDev,string Observacion,ref string sMensajeError) 
        {
            bool Respuesta = Documento.RegistraDevolucion(IdConexion, cOperacion,/* Tipo,*/ Tramite, GrupoBeneficio, IdDocumento, FechaDocumento, NroDocumento, CiteDescDev,FechaCiteDev,FechaDev,Observacion,ref sMensajeError);
            return Respuesta;
        }
        public DataTable DocsUltimosDevueltos(int IdConexion, string cOperacion,Int64 IdTramite,Int32 IdGrupoBeneficio, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (Documento.DocsUltimosDevueltos(IdConexion, cOperacion,IdTramite,IdGrupoBeneficio, ref sMensajeError, ref DSetTmp))
                return DSetTmp.Tables[0];
            else
                return null;
        }
    }
}