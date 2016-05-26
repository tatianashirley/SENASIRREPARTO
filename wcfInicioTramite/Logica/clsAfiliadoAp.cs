using wcfInicioTramite.Datos;
using wcfInicioTramite.Entidades;

namespace wcfInicioTramite.Logica
{
    public class clsAfiliadoAp : clsAfiliadoApBE
    {
        clsAfiliadoApDA objAfiliadoAp = new clsAfiliadoApDA();

        //Obtener datos asignacion
        public bool Buscar()
        {
            objAfiliadoAp.iIdConexion = this.iIdConexion;
            objAfiliadoAp.cOperacion = this.cOperacion;
            objAfiliadoAp.NUA = this.NUA;
            objAfiliadoAp.NumeroIdentificacion = this.NumeroIdentificacion;
            objAfiliadoAp.PrimerApellido = this.PrimerApellido;
            objAfiliadoAp.SegundoApellido = this.SegundoApellido;
            objAfiliadoAp.PrimerNombre = this.PrimerNombre;
            objAfiliadoAp.SegundoNombre = this.SegundoNombre;
            this.sRespuesta = objAfiliadoAp.Buscar();
            this.sMensajeError = objAfiliadoAp.sMensajeError;
            this.DSetTmp = objAfiliadoAp.DSetTmp;
            return (this.sRespuesta);
        }

        //Registrar datos asignacion
        public bool Registrar()
        {
            objAfiliadoAp.iIdConexion = this.iIdConexion;
            objAfiliadoAp.cOperacion = this.cOperacion;
            objAfiliadoAp.CodAFP = this.CodAFP;
            objAfiliadoAp.NUA = this.NUA;
            objAfiliadoAp.FechaNacimiento = this.FechaNacimiento;
            objAfiliadoAp.TipoIdentificacion = this.TipoIdentificacion;
            objAfiliadoAp.NumeroIdentificacion = this.NumeroIdentificacion;
            objAfiliadoAp.PrimerApellido = this.PrimerApellido;
            objAfiliadoAp.SegundoApellido = this.SegundoApellido;
            objAfiliadoAp.PrimerNombre = this.PrimerNombre;
            objAfiliadoAp.SegundoNombre = this.SegundoNombre;
            objAfiliadoAp.ApellidoConyuge = this.ApellidoConyuge;
            objAfiliadoAp.Motivo = this.Motivo;
            this.sRespuesta = objAfiliadoAp.Registrar();
            this.sMensajeError = objAfiliadoAp.sMensajeError;
            return (this.sRespuesta);
        }

        //Actualizar datos asignacion
        public bool Actualizar()
        {
            objAfiliadoAp.iIdConexion = this.iIdConexion;
            objAfiliadoAp.cOperacion = this.cOperacion;
            objAfiliadoAp.CodAFP = this.CodAFP;
            objAfiliadoAp.NUA = this.NUA;
            objAfiliadoAp.FechaNacimiento = this.FechaNacimiento;
            objAfiliadoAp.TipoIdentificacion = this.TipoIdentificacion;
            objAfiliadoAp.NumeroIdentificacion = this.NumeroIdentificacion;
            objAfiliadoAp.PrimerApellido = this.PrimerApellido;
            objAfiliadoAp.SegundoApellido = this.SegundoApellido;
            objAfiliadoAp.PrimerNombre = this.PrimerNombre;
            objAfiliadoAp.SegundoNombre = this.SegundoNombre;
            objAfiliadoAp.ApellidoConyuge = this.ApellidoConyuge;
            objAfiliadoAp.Motivo = this.Motivo;
            this.sRespuesta = objAfiliadoAp.Actualizar();
            this.sMensajeError = objAfiliadoAp.sMensajeError;
            return (this.sRespuesta);
        }
    }
}