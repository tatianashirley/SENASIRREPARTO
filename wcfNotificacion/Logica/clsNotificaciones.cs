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
    public class clsNotificaciones
    {   
        clsNotificacionesDA Pendiente = new clsNotificacionesDA();
        // PARA OBTENER SIN NOTIFICAR
        public DataTable ObtieneDatos(int IdConexion, string cOperacion,/* string Tipo, int IdArea,*/string IdTramite, string IdBeneficio, ref string sMensajeError) 
        {
            DataSet DSetTmp = new DataSet();
            if (Pendiente.ObtieneDatos(IdConexion, cOperacion/*, Tipo, IdArea,*/,IdTramite,IdBeneficio,ref sMensajeError, ref DSetTmp))
            {
                return DSetTmp.Tables[0];
            }
            else 
            {
                return (null);
            }
        }
        // PARA RECURSO DE RECLAMACION
        public DataTable ObtieneRecursos(int IdConexion, string cOperacion/*, string Tipo*/, int IdArea,Int64 IdTramite, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (Pendiente.ObtieneRecursos(IdConexion, cOperacion,/* Tipo,*/ IdArea, IdTramite, ref sMensajeError, ref DSetTmp))
            {
                return DSetTmp.Tables[0];
            }
            else
            {
                return (null);
            }
        }

        public DataTable ObtieneFechaCalculo(int iIdConexion, string cOperacion, Int64 IdTramite, Int32 IdGrupoB, Int32 IdDocumento, Int32 NroDocumento, string FechaT, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (Pendiente.ObtieneFechaCalculo(iIdConexion, cOperacion,IdTramite,IdGrupoB,IdDocumento,NroDocumento,FechaT, ref sMensajeError, ref DSetTmp))
            {
                return DSetTmp.Tables[0];
            }
            else
            {
                return (null);
            }
        }

        // Carga datos de la notiticacion para su modificacion
        public DataTable CargaDatosNotificacion(int iIdConexion, string cOperacion, Int64 Tramite, int GrupoBeneficio, int IdDocumento, string FechaDocumento, int NroDocumento, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (Pendiente.CargaDatosNotificacion(iIdConexion, cOperacion,Tramite, GrupoBeneficio,IdDocumento,FechaDocumento,NroDocumento, ref sMensajeError, ref DSetTmp))
            {
                return DSetTmp.Tables[0];
            }
            else
            {
                return (null);
            }
        }

        public DataTable HabilitaBoton(int iIdConexion, string cOperacion, Int32 IdTramite, Int32 IdGrupoB, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (Pendiente.HabilitaBoton(iIdConexion, cOperacion, IdTramite, IdGrupoB, ref sMensajeError, ref DSetTmp))
            {
                return DSetTmp.Tables[0];
            }
            else
            {
                return (null);
            }
        }

        public bool ActualizaDocumento(int iIdConexion, string cOperacion,/* string Tipo,*/ Int64 Tramite, int GrupoBeneficio, string FechaDocumento, int NroDocumento, int IdDocumento, string FecNot, string Obs, int IdTipoNot,int Bandera, ref string sMensajeError)
        {
            bool bAsignacionOK = Pendiente.ActualizaDocumento(iIdConexion, cOperacion,/* Tipo, */Tramite, GrupoBeneficio, IdDocumento, FechaDocumento, NroDocumento, FecNot, Obs,IdTipoNot,Bandera, ref sMensajeError);
            return (bAsignacionOK);
        }

        public bool RegistraRecursoRenuncia(int iIdConexion, string cOperacion,Int64 Tramite, int GrupoBeneficio, string FechaDocumento, int NroDocumento, int IdDocumento,string Encriptado, string CodigoImp,Int32 TipoTramite, ref string sMensajeError)
        {
            bool bAsignacionOK = Pendiente.RegistraRecursoRenuncia(iIdConexion, cOperacion,Tramite, GrupoBeneficio, IdDocumento, FechaDocumento, NroDocumento,Encriptado,CodigoImp,TipoTramite, ref sMensajeError);
            return (bAsignacionOK);
        }

        //PARA OBTENER LA DIRECCION
        public DataTable ObtieneDatos(int iIdConexion, string cOperacion, string Tipo, Int64 Tramite, int GrupoBeneficio,string FechaDoc,Int32 NroDoc,Int32 IdDoc,string Direccion, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();

            if (Pendiente.ObtieneDatos(iIdConexion, cOperacion, Tipo, Tramite, GrupoBeneficio, FechaDoc,NroDoc,IdDoc,Direccion,ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }

        //PARA OBTENER Datos del codigo a imprimir
        public DataTable DatosImpresion(int iIdConexion, string cOperacion, Int64 Tramite, int GrupoBeneficio, int IdDocumento, string FechaDocumento, int NroDocumento,Int32 TipoTramite, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();

            if (Pendiente.DatosImpresion(iIdConexion, cOperacion,Tramite, GrupoBeneficio, IdDocumento, FechaDocumento, NroDocumento,TipoTramite,ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }

        //PARA OBTENER DATOS DE CODIFICACION
        public DataTable ObtieneDatosCodigos(int iIdConexion, string cOperacion, Int64 Tramite, int GrupoBeneficio, string FechaDoc, Int32 NroDoc, Int32 IdDoc,  ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();

            if (Pendiente.ObtieneDatosCodigos(iIdConexion, cOperacion, Tramite, GrupoBeneficio, FechaDoc, NroDoc, IdDoc, ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }

        public DataTable ExisteDocumento(int iIdConexion, string cOperacion, Int64 IdTramite, Int32 IdGrupoB, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (Pendiente.ExisteDocumento(iIdConexion, cOperacion, IdTramite, IdGrupoB, ref sMensajeError, ref DSetTmp))
            {
                return DSetTmp.Tables[0];
            }
            else
            {
                return (null);
            }
        }
        //Verifica si existe Formularios de Calculo sin notificar para un trámite en particular
        public DataTable ExisteDocumentoSinsNotificar(int iIdConexion, string cOperacion, Int64 Tramite, int GrupoBeneficio,ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();

            if (Pendiente.ExisteDocumentoSinNotificar(iIdConexion, cOperacion, Tramite, GrupoBeneficio, ref sMensajeError, ref DSetTmp))
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