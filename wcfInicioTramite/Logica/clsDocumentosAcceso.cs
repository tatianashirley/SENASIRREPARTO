using wcfInicioTramite.Datos;
using wcfInicioTramite.Entidades;

namespace wcfInicioTramite.Logica
{
    public class clsDocumentosAcceso : clsDocumentoAccesoBE
    {
        clsDocumentosAccesoDA ObjDocumentoAccesoDA = new clsDocumentosAccesoDA();

        //Registrar Documentos Acceso
        public bool Registrar()
        {
            ObjDocumentoAccesoDA.iIdConexion = this.iIdConexion;
            ObjDocumentoAccesoDA.cOperacion = this.cOperacion;
            ObjDocumentoAccesoDA.IdTramite = this.IdTramite;
            ObjDocumentoAccesoDA.IdRequisito = this.IdRequisito;
            ObjDocumentoAccesoDA.IdCausa = this.IdCausa;
            ObjDocumentoAccesoDA.IdTipoDocumento = this.IdTipoDocumento;
            ObjDocumentoAccesoDA.Matricula = this.Matricula;
            this.sRespuesta = ObjDocumentoAccesoDA.Registrar();
            this.sMensajeError = ObjDocumentoAccesoDA.sMensajeError;
            return (this.sRespuesta);
        }
    }
}