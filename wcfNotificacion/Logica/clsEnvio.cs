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
    public class clsEnvio
    {
        clsEnvioDA Envio = new clsEnvioDA();
        public DataTable ObtieneDatos(int IdConexion, string cOperacion,/* string Tipo,*/ ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (Envio.ObtieneDatos(IdConexion, cOperacion,/* Tipo,*/ ref sMensajeError, ref DSetTmp))
            {
                return DSetTmp.Tables[0];
            }
            else
            {
                return (null);                                                                                                                                                                           
            }
        }
        public DataTable DatosNotificacionEnvio(int iIdConexion, string cOperacion, Int64 IdTramite, Int32 IdGrupoB, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (Envio.DatosNotificacionEnvio(iIdConexion, cOperacion,IdTramite,IdGrupoB,ref sMensajeError, ref DSetTmp))
            {
                return DSetTmp.Tables[0];
            }
            else
            {
                return (null);
            }
        }
        public DataTable ListaFuncionarios(int iIdConexion, string cOperacion,int regional, ref string sMensajeError) 
        {   
            DataSet DSetTmp = new DataSet();
            if (Envio.ListaFuncionarios(iIdConexion, cOperacion,regional,ref sMensajeError, ref DSetTmp))
            {
                return DSetTmp.Tables[0];
            }
            else 
            {
                return (null);
            }
        }
        public DataTable ListaOficinas(int IdConexion, string cOperacion, /*string Tipo,*/int Bandera,ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (Envio.ListaOficinas(IdConexion, cOperacion,/* Tipo, */Bandera,ref sMensajeError, ref DSetTmp))
            {
                return DSetTmp.Tables[0];
            }
            else
            {
                return (null);
            }
        }
        public bool RegistroEnvio(int iIdConexion, string cOperacion,/* string Tipo,*/ Int64 Tramite, Int32 IdGrupobeneficio, string FechaDocumento, Int32 NroDocumento, Int32 IdDocumento, string CiteDesc, string FechaCite, string FechaEnv, Int32 IdUsrDest,Int32 IdOficina,string Observacion,ref string sMensajeError)
        {
            bool Respuesta = Envio.RegistroEnvio(iIdConexion, cOperacion,/* Tipo,*/ Tramite, IdGrupobeneficio, FechaDocumento, NroDocumento, IdDocumento, 
                CiteDesc, FechaCite, FechaEnv, IdUsrDest,IdOficina,Observacion, ref sMensajeError);
            return (Respuesta);
        }

        public DataTable DocsUltimoEnvio(int IdConexion, string cOperacion, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (Envio.DocsUltimoEnvio(IdConexion, cOperacion, ref sMensajeError, ref DSetTmp))
            {
                return DSetTmp.Tables[0];
            }
            else
            {
                return (null);
            }
        }
        public DataTable DocsUltimoEnvio(int IdConexion, string cOperacion,Int64 IdTramite,Int32 IdGrupoBeneficio, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (Envio.DocsUltimoEnvio(IdConexion, cOperacion,IdTramite,IdGrupoBeneficio, ref sMensajeError, ref DSetTmp))
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