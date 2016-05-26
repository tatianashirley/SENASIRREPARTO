using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using wcfEjemplo.Tramite.Datos;
using wcfEjemplo.Tramite.Entidades;

namespace wcfEjemplo.Tramite.Logica
{
    public class clsTramite : clsTramiteBE
    {
        public string[] InsertarTramite(string NUP, string IdGrupoBeneficio, string IdBeneficio, string IdSubBeneficio, string IdTipoTramite, string IdFlujoTramite,
            string IdClaseExpediente, string IdSector, string IdOficinaRegistro, string NUPIniciaTramite, string IdTipoIniciaTramite, string Observaciones,
            string IdEstadoTramite, string IdTipoProcesoRegistroTramite, string EstadoHabilitacion, string DocumentoHabilitacion)
        {
            string[] datos = new string[16];
            datos[0] = NUP;
            datos[1] = IdGrupoBeneficio;
            datos[2] = IdBeneficio;
            datos[3] = IdSubBeneficio;
            datos[4] = IdTipoTramite;
            datos[5] = IdFlujoTramite;
            datos[6] = IdClaseExpediente;
            datos[7] = IdSector;
            datos[8] = IdOficinaRegistro;
            datos[9] = NUPIniciaTramite;
            datos[10] = IdTipoIniciaTramite;
            datos[11] = Observaciones;
            datos[12] = IdEstadoTramite;
            datos[13] = IdTipoProcesoRegistroTramite;
            datos[14] = EstadoHabilitacion;
            datos[15] = DocumentoHabilitacion;

            string[] result = new string[3];
            clsTramiteDA permiso = new clsTramiteDA();
            result = permiso.InsertarTramite(datos);

            return result;
        }

        public string[] EmpresaPersonaRegistroIns(Int64 Tramite, int idGrupoBeneficio, decimal IdEmpresa, string NombreEmpresaDeclarada, string PeriodoInicio,
            string PeriodoFin, decimal Monto, int IdMoneda)
        {
            string[] result = new string[2];
            clsTramiteDA permiso = new clsTramiteDA();
            result = permiso.EmpresaPersonaRegistroIns(Tramite, idGrupoBeneficio, IdEmpresa, NombreEmpresaDeclarada, PeriodoInicio, PeriodoFin, Monto, IdMoneda);

            return result; 
        }
    }
}