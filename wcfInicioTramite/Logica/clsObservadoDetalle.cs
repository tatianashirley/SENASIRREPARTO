using wcfInicioTramite.Datos;
using wcfInicioTramite.Entidades;

namespace wcfInicioTramite.Logica
{
    public class clsObservadoDetalle : clsObservadoDetalleBE
    {
        clsObservadoDetalleDA ObjObservadoDetalleDA = new clsObservadoDetalleDA();

        public bool Registrar()
        {
            ObjObservadoDetalleDA.iIdConexion = this.iIdConexion;
            ObjObservadoDetalleDA.cOperacion = this.cOperacion;
            ObjObservadoDetalleDA.IdObservado = this.IdObservado;
            ObjObservadoDetalleDA.Tramite = this.Tramite;
            ObjObservadoDetalleDA.Tipo = this.Tipo;
            ObjObservadoDetalleDA.NumeroDocumento = this.NumeroDocumento;
            ObjObservadoDetalleDA.CUA = this.CUA;
            ObjObservadoDetalleDA.Matricula = this.Matricula;
            ObjObservadoDetalleDA.PrimeroApellido = this.PrimeroApellido;
            ObjObservadoDetalleDA.SegundoApellido = this.SegundoApellido;
            ObjObservadoDetalleDA.Nombres = this.Nombres;
            ObjObservadoDetalleDA.FechaNacimiento = this.FechaNacimiento;
            ObjObservadoDetalleDA.Sector = this.Sector;
            ObjObservadoDetalleDA.DHMatricula = this.DHMatricula;
            ObjObservadoDetalleDA.EstadoObservado = this.EstadoObservado;
            this.sRespuesta = ObjObservadoDetalleDA.Registrar();
            this.sMensajeError = ObjObservadoDetalleDA.sMensajeError;
            return (this.sRespuesta);
        }
    }
}