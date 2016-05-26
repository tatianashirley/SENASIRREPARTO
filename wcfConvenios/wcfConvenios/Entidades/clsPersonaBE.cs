using System;

namespace wcfConvenios.Entidades
{
    public class clsPersonaBE : clsBase
    {
        public Int64 NUP { get; set; }
        public int IdTipoDocumento { get; set; }
        public int IdEstadoCivil { get; set; }
        public int IdEntidadGestora { get; set; }
        public int IdRegional { get; set; }
        public int IdSexo { get; set; }
        public int IdEstado { get; set; }
        public int IdCajaSalud { get; set; }
        public Int64 CUA { get; set; }
        public string Matricula { get; set; }
        public Int64 NUB { get; set; }

        public string NumeroDocumento { get; set; }
        public string ComplementoSEGIP { get; set; }
        public Int64 DocumentoExpedido { get; set; }

        public string PrimerNombre { get; set; }
        public string SegundoNombres { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string ApellidoCasada { get; set; }

        public DateTime FechaNacimiento { get; set; }
        public bool EsFFAA { get; set; }
        public DateTime FechaFallecimiento { get; set; }
        public int IdPaisResidencia { get; set; }

        public string CorreoElectronico { get; set; }
        public string Celular { get; set; }
        public string CelularReferencia { get; set; }
        public string Direccion { get; set; }
        public int IdLocalidad { get; set; }
        public string Telefono { get; set; }
        public int RegistroActivo { get; set; }

        public string Color { get; set; }
        public int TotalPersona { get; set; }
        public string PrestacionHabilitada { get; set; }
        public string Igualdad { get; set; }
        public string Tabla { get; set; }

        public string mensaje { get; set; }
        public int retorno_proc { get; set; }

        public string motivo { get; set; }
    }
}