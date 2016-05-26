using wcfInicioTramite.Datos;
using wcfInicioTramite.Entidades;

namespace wcfInicioTramite.Logica
{
    public class clsObservado : clsObservadoBE
    {
        clsObservadoDA ObjObservadoDA = new clsObservadoDA();

        public bool Registrar()
        {
            ObjObservadoDA.iIdConexion = this.iIdConexion;
            ObjObservadoDA.cOperacion = this.cOperacion;
            ObjObservadoDA.NumeroDocumento = this.NumeroDocumento;
            ObjObservadoDA.CUA = this.CUA;
            ObjObservadoDA.Matricula = this.Matricula;
            ObjObservadoDA.Tabla = this.Tabla;
            ObjObservadoDA.PrimerApellido = this.PrimerApellido;
            ObjObservadoDA.SegundoApellido = this.SegundoApellido;
            ObjObservadoDA.PrimerNombre = this.PrimerNombre;
            ObjObservadoDA.Autorizador = this.Autorizador;
            ObjObservadoDA.Motivo = this.Motivo;
            ObjObservadoDA.Observaciones = this.Observaciones;            
            this.sRespuesta = ObjObservadoDA.Registrar();
            this.IdObservado = ObjObservadoDA.IdObservado;
            this.sMensajeError = ObjObservadoDA.sMensajeError;
            return (this.sRespuesta);
        }
    }
}