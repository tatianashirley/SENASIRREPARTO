using wcfInicioTramite.Datos;
using wcfInicioTramite.Entidades;

namespace wcfInicioTramite.Logica
{
    public class clsPoderNotariado : clsPoderNotariadoBE
    {
        clsPoderNotariadoDA objPoderNotariadoDA = new clsPoderNotariadoDA();

        //Obtener Poder Notariado
        public bool Obtener()
        {
            objPoderNotariadoDA.iIdConexion = this.iIdConexion;
            objPoderNotariadoDA.cOperacion = this.cOperacion;
            objPoderNotariadoDA.IdTramite = this.IdTramite;
            objPoderNotariadoDA.IdGrupoBeneficio = this.IdGrupoBeneficio;
            this.sRespuesta = objPoderNotariadoDA.Obtener();
            this.sMensajeError = objPoderNotariadoDA.sMensajeError;
            this.DSetTmp = objPoderNotariadoDA.DSetTmp;
            return (this.sRespuesta);
        }

        //Registrar Poder Notariado
        public bool Registrar()
        {
            objPoderNotariadoDA.iIdConexion = this.iIdConexion;
            objPoderNotariadoDA.cOperacion = this.cOperacion;
            objPoderNotariadoDA.IdTramite = this.IdTramite;
            objPoderNotariadoDA.IdGrupoBeneficio = this.IdGrupoBeneficio;
            objPoderNotariadoDA.NroPoder = this.NroPoder;
            objPoderNotariadoDA.Administracion = this.Administracion;
            objPoderNotariadoDA.VigenciaDesde = this.VigenciaDesde;
            objPoderNotariadoDA.VigenciaHasta = this.VigenciaHasta;
            objPoderNotariadoDA.IdTramite = this.IdTramite;
            objPoderNotariadoDA.IdGrupoBeneficio = this.IdGrupoBeneficio;
            objPoderNotariadoDA.PrimerNombre = this.PrimerNombre;
            objPoderNotariadoDA.SegundoNombres = this.SegundoNombres;
            objPoderNotariadoDA.PrimerApellido = this.PrimerApellido;
            objPoderNotariadoDA.SegundoApellido = this.SegundoApellido;
            objPoderNotariadoDA.ApellidoCasada = this.ApellidoCasada;
            objPoderNotariadoDA.NumeroDocumento = this.NumeroDocumento;
            objPoderNotariadoDA.ComplementoSEGIP = this.ComplementoSEGIP;
            objPoderNotariadoDA.IdTipoDocumento = this.IdTipoDocumento;
            objPoderNotariadoDA.DocumentoExpedido = this.DocumentoExpedido;
            objPoderNotariadoDA.Direccion = this.Direccion;
            objPoderNotariadoDA.Celular = this.Celular;
            objPoderNotariadoDA.CelularReferencia = this.CelularReferencia;
            objPoderNotariadoDA.Telefono = this.Telefono;
            objPoderNotariadoDA.IdRegional = this.IdRegional;

            this.sRespuesta = objPoderNotariadoDA.Registrar();
            this.sMensajeError = objPoderNotariadoDA.sMensajeError;
            return (this.sRespuesta);
        }

        //Actualizar Poder Notariado
        public bool Actualizar()
        {
            objPoderNotariadoDA.iIdConexion = this.iIdConexion;
            objPoderNotariadoDA.cOperacion = this.cOperacion;
            objPoderNotariadoDA.IdTramite = this.IdTramite;
            objPoderNotariadoDA.IdGrupoBeneficio = this.IdGrupoBeneficio;
            objPoderNotariadoDA.NroPoder = this.NroPoder;
            objPoderNotariadoDA.Administracion = this.Administracion;
            objPoderNotariadoDA.VigenciaDesde = this.VigenciaDesde;
            objPoderNotariadoDA.VigenciaHasta = this.VigenciaHasta;
            objPoderNotariadoDA.IdTramite = this.IdTramite;
            objPoderNotariadoDA.IdGrupoBeneficio = this.IdGrupoBeneficio;
            objPoderNotariadoDA.PrimerNombre = this.PrimerNombre;
            objPoderNotariadoDA.SegundoNombres = this.SegundoNombres;
            objPoderNotariadoDA.PrimerApellido = this.PrimerApellido;
            objPoderNotariadoDA.SegundoApellido = this.SegundoApellido;
            objPoderNotariadoDA.ApellidoCasada = this.ApellidoCasada;
            objPoderNotariadoDA.NumeroDocumento = this.NumeroDocumento;
            objPoderNotariadoDA.ComplementoSEGIP = this.ComplementoSEGIP;
            objPoderNotariadoDA.IdTipoDocumento = this.IdTipoDocumento;
            objPoderNotariadoDA.DocumentoExpedido = this.DocumentoExpedido;
            objPoderNotariadoDA.Direccion = this.Direccion;
            objPoderNotariadoDA.Celular = this.Celular;
            objPoderNotariadoDA.CelularReferencia = this.CelularReferencia;
            objPoderNotariadoDA.Telefono = this.Telefono;
            objPoderNotariadoDA.Observacion = this.Observacion;
            this.sRespuesta = objPoderNotariadoDA.Actualizar();
            this.sMensajeError = objPoderNotariadoDA.sMensajeError;
            return (this.sRespuesta);
        }
    }
}