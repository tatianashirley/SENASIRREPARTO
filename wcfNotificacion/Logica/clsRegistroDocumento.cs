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
    public class clsRegistroDocumento
    {   
        clsRegistroDocumentosDA Documento = new clsRegistroDocumentosDA();

        public DataTable ObtieneDatos(int iIdConexion, string cOperacion,string Matricula, string Tramite, string NroDocumento, string PrimerApellido, string SegundoApellido,
            string Nombre, ref string sMensajeError)
        {   
            DataSet DSetTmp = new DataSet();
            
           if (Documento.ObtieneDatos(iIdConexion,cOperacion,Matricula,Tramite,NroDocumento,PrimerApellido,SegundoApellido,Nombre,ref sMensajeError,ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }
        // 9 argumentos
        public bool RegistraDocumento(int iIdConexion, string cOperacion,/* string Tipo,*/ Int64 Tramite, int IdGrupobeneficio,string FechaDocumento,
            int NroDocumento, int IdDocumento, ref string sMensajeError)
        {
            bool Respuesta = Documento.RegistraDocumento(iIdConexion, cOperacion,/* Tipo,*/ Tramite, IdGrupobeneficio, FechaDocumento, NroDocumento, IdDocumento, ref sMensajeError);
            return (Respuesta);
        }
        //6 argumentos
        public bool RegistraDocumento(int iIdConexion, string cOperacion,/* string Tipo,*/ Int64 Tramite, int IdGrupobeneficio,string Obs, ref string sMensajeError)
        {
            bool Respuesta = Documento.RegistraDocumento(iIdConexion, cOperacion,/* Tipo,*/ Tramite, IdGrupobeneficio,Obs,ref sMensajeError);
            return (Respuesta);
        }

        public bool RegistraNotas(int iIdConexion, string cOperacion, Int64 Tramite, int IdGrupobeneficio, string FechaDocumento, int NroDocumento, int IdDocumento, string FechaNot, string Obs, ref string sMensajeError)
        {
            bool Respuesta = Documento.RegistraNotas(iIdConexion, cOperacion,Tramite, IdGrupobeneficio, FechaDocumento, NroDocumento, IdDocumento,FechaNot,Obs, ref sMensajeError);
            return (Respuesta);
        }

        public DataTable ObtieneDatos(int iIdConexion, string cOperacion, Int64 Tramite, int GrupoBeneficio, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();

            if (Documento.ObtieneDatos(iIdConexion, cOperacion, Tramite, GrupoBeneficio, ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }
        public bool ActualizaDocumento(int iIdConexion, string cOperacion,/* string Tipo,*/Int64 Tramite,int GrupoBeneficio,string FechaDocumento,int NroDocumento,int IdDocumento,string FecNot,string Obs,int IdTipoNotificacion, ref string sMensajeError)
        {
            bool bAsignacionOK = Documento.ActualizaDocumento(iIdConexion, cOperacion,/* Tipo,*/Tramite,GrupoBeneficio,IdDocumento,FechaDocumento,NroDocumento,FecNot,Obs,IdTipoNotificacion,ref sMensajeError);
            return (bAsignacionOK);
        }

        public bool ModificaDocumento(int iIdConexion, string cOperacion,/* string Tipo,*/ Int64 Tramite, int GrupoBeneficio, int IdDocumento, string FechaDocumento, int NroDocumento, string FechaNot, string FechaRec, ref string sMensajeError) 
        {
            bool Respuesta = Documento.ModificaDatos(iIdConexion,cOperacion,/*Tipo,*/Tramite,GrupoBeneficio,IdDocumento,FechaDocumento,NroDocumento,FechaNot,FechaRec,ref sMensajeError);
            return Respuesta;
        }

        public DataTable ddlDocumentos(int iIdConexion, string cOperacion, Int32 Area, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();

            if (Documento.ddlDocumentos(iIdConexion, cOperacion,Area, ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }
        public DataTable DatosDocumento(int iIdConexion, string cOperacion, Int32 IdDoc, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();

            if (Documento.DatosDocumento(iIdConexion, cOperacion, IdDoc, ref sMensajeError, ref DSetTmp))
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