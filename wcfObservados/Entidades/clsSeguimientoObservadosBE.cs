using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wcfObservados.Entidades
{
    public class clsSeguimientoObservadosBE
    {
        public int IdFormulario { get; set; }
        public Int64 IdTramite { get; set; }
        public int IdGrupoBeneficio { get; set; }
        public int IdTipoAccion { get; set; }
        public string TipoAccion { get; set; }
        public int IdEtapa { get; set; }
        public string FechaFormulario { get; set; }
        public string NombreInteresado { get; set; }
        public int HojaRuta { get; set; }
        public string FechaHojaRuta { get; set; }
        public string Gestion { get; set; }
        public int IdAreaDestino { get; set; }
        public int NumeroFojas { get; set; }
        public string DescripcionDoc { get; set; }
        public string TextoObservacion { get; set; }
        public int RegistroActivo { get; set; }
        public int existedatos { get; set; }
    }
    public class clsDatosTramitePersonaBE
    {
        //tramite
        public Int64 IdTramite { get; set; }
        public int IdGrupoBeneficio { get; set; }
        public int IdTipoTramite { get; set; }
        public string TipoTramite { get; set; }
       // public int Procedimiento { get; set; }
        public string fechainicio { get; set; }
        
        //blic string FechaFormulario { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Sexo { get; set; }
        public string FechaNacimiento { get; set; }
        public string FechaFallecimiento { get; set; }
        public string NumeroDocumento { get; set; }
        public string ComplementoSEGIP { get; set; }
        public int  IdTipoDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public string Matricula { get; set; }
        public int IdEstadoCivil { get; set; }
        public string EstadoCivil { get; set; }
        public string CUA { get; set; }
        public int IdEntidadGestora { get; set; }
        public string EntidadGestora { get; set; }
        public string  Direccion{ get; set; }
    }
    public class clsDatosUsuarioBE
    {
        //datos usuario
       // public int IdConexion { get; set; }
        public int IdUsuario { get; set; }
        public string CuentaUsuario { get; set; }
        public string Nombre { get; set; }
        public int IdOficina { get; set; }
        public string Oficina { get; set; }
        public string Area { get; set; }
    }
    public class clsDatosCorrespondenciaBE
    {
        //tramite
        public int Num_Recep { get; set; }
        public int Num_Guia { get; set; }
        public string Fecha_Recep { get; set; }
        public int Gestion { get; set; }
        public string Referencia { get; set; }
        public int existedatos { get; set; }
    }

    public class clsOficinaAreaBE
    {
        public int IdOficina { get; set; }
        public int IdArea { get; set; }
        public string Descripcion { get; set; }

    }

}