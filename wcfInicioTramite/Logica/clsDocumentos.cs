using System.Data;
using wcfInicioTramite.Datos;
using wcfInicioTramite.Documentos.Entidades;

namespace wcfInicioTramite.Logica
{
    public class clsDocumentos : clsDocumentosBE
    {
        clsDocumentosDA ObjDocumentosDA = new clsDocumentosDA();

        //Obtener documentos para el tramite
        public DataTable ObtenerDocumentos()
        {
            ObjDocumentosDA.iIdConexion = this.iIdConexion;
            ObjDocumentosDA.cOperacion = this.cOperacion;
            ObjDocumentosDA.TipoTramite = this.TipoTramite;
            ObjDocumentosDA.IdTipoPersona = this.IdTipoPersona;
            ObjDocumentosDA.IdSector = this.IdSector;
            if (ObjDocumentosDA.ObtenerDocumentos())
            {
                return (ObjDocumentosDA.DSetTmp != null && ObjDocumentosDA.DSetTmp.Tables != null && ObjDocumentosDA.DSetTmp.Tables.Count > 0 ? ObjDocumentosDA.DSetTmp.Tables[0] : null);
            }
            else
            {
                this.sMensajeError = ObjDocumentosDA.sMensajeError;
                return (null);
            }
        }
        //Obtener documentos para el tramite WF
        public DataTable ObtenerDocumentosWF(int iIdConexion, string cOperacion, long iTipoTramite, long iTipoPersona, long iGrupoSector, ref string sMensajeError, ref long lSesion)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjDocumentosDA.ObtenerDocumentosWF(iIdConexion, cOperacion, iTipoTramite, iTipoPersona, iGrupoSector, ref sMensajeError, ref DSetTmp, ref lSesion))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }

        //Registrar documentos para el tramite
        public bool RegistrarDocumentos(int iIdConexion, string cOperacion, clsDocumentos objDocumentos, ref string sMensajeError)
        {
            if (ObjDocumentosDA.RegistrarDocumentos(iIdConexion, cOperacion, objDocumentos, ref sMensajeError))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Obtener documentos para la renuncia
        public DataTable ObtenerDocumentosRenuncia(int iIdConexion, string cOperacion, long iTipoTramite, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjDocumentosDA.ObtenerDocumentosRenuncia(iIdConexion, cOperacion, iTipoTramite, ref sMensajeError, ref DSetTmp))
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