using wcfInicioTramite.Datos;
using wcfInicioTramite.Entidades;

namespace wcfInicioTramite.Logica
{
    public class clsEmpresaPersona : clsEmpresaPersonaBE
    {
        clsEmpresaPersonaDA objEmpresaPersona = new clsEmpresaPersonaDA();

        //Registrar Empresa 
        public bool Registrar()
        {
            objEmpresaPersona.iIdConexion = this.iIdConexion;
            objEmpresaPersona.cOperacion = this.cOperacion;
            objEmpresaPersona.IdEmpresaPersona = this.IdEmpresaPersona;
            objEmpresaPersona.IdTramite = this.IdTramite;
            objEmpresaPersona.idGrupoBeneficio = this.idGrupoBeneficio;
            objEmpresaPersona.IdEmpresa = this.IdEmpresa;
            objEmpresaPersona.NombreEmpresaDeclarada = this.NombreEmpresaDeclarada;
            objEmpresaPersona.Observacion = this.Observacion;
            objEmpresaPersona.PeriodoInicio = this.PeriodoInicio;
            objEmpresaPersona.PeriodoFin = this.PeriodoFin;
            objEmpresaPersona.Monto = this.Monto;
            objEmpresaPersona.IdMoneda = this.IdMoneda;
            objEmpresaPersona.EstadoRegistro = this.EstadoRegistro;
            objEmpresaPersona.NroPatronalRucAlt = this.NroPatronalRucAlt;
            objEmpresaPersona.IdSector = this.IdSector;
            objEmpresaPersona.IdTipoDocSalario = this.IdTipoDocSalario;
            objEmpresaPersona.IdSectorSSLP = this.IdSectorSSLP;
            objEmpresaPersona.ValidaPFA = this.ValidaPFA;
            objEmpresaPersona.MatriculaORG = this.MatriculaORG;
            this.sRespuesta = objEmpresaPersona.Registrar();
            this.sMensajeError = objEmpresaPersona.sMensajeError;
            return (this.sRespuesta);
        }

        //Modificar Empresa 
        public bool Modificar()
        {
            objEmpresaPersona.iIdConexion = this.iIdConexion;
            objEmpresaPersona.cOperacion = this.cOperacion;
            objEmpresaPersona.IdEmpresaPersona = this.IdEmpresaPersona;
            objEmpresaPersona.IdTramite = this.IdTramite;
            objEmpresaPersona.idGrupoBeneficio = this.idGrupoBeneficio;
            objEmpresaPersona.IdEmpresa = this.IdEmpresa;
            objEmpresaPersona.NombreEmpresaDeclarada = this.NombreEmpresaDeclarada;
            objEmpresaPersona.Observacion = this.Observacion;
            objEmpresaPersona.PeriodoInicio = this.PeriodoInicio;
            objEmpresaPersona.PeriodoFin = this.PeriodoFin;
            objEmpresaPersona.Monto = this.Monto;
            objEmpresaPersona.IdMoneda = this.IdMoneda;
            objEmpresaPersona.EstadoRegistro = this.EstadoRegistro;
            objEmpresaPersona.NroPatronalRucAlt = this.NroPatronalRucAlt;
            objEmpresaPersona.IdSector = this.IdSector;
            objEmpresaPersona.IdTipoDocSalario = this.IdTipoDocSalario;
            objEmpresaPersona.IdTipoTramite = this.IdTipoTramite;
            objEmpresaPersona.Version = this.Version;
            objEmpresaPersona.Componente=this.Componente;
            objEmpresaPersona.PeriodoSalario=this.PeriodoSalario;
            objEmpresaPersona.IdMonedaSalario=this.IdMonedaSalario;
            objEmpresaPersona.Motivo=this.Motivo;
            this.sRespuesta = objEmpresaPersona.Modificar();
            this.sMensajeError = objEmpresaPersona.sMensajeError;
            return (this.sRespuesta);
        }

        //Obtener Grilla Empresas
        public bool ObtenerLista()
        {
            objEmpresaPersona.iIdConexion = this.iIdConexion;
            objEmpresaPersona.cOperacion = this.cOperacion;
            objEmpresaPersona.IdTramite = this.IdTramite;
            objEmpresaPersona.idGrupoBeneficio = this.idGrupoBeneficio;
            this.sRespuesta = objEmpresaPersona.ObtenerLista();
            this.sMensajeError = objEmpresaPersona.sMensajeError;
            this.DSetTmp = objEmpresaPersona.DSetTmp;
            return (this.sRespuesta);
        }
    }
}