using System;
using System.Data;
using wcfPagoUnico.Datos;
using wcfPagoUnico.Entidades;

namespace wcfPagoUnico.Logica
{
    public class clsPUPersona
    {
        clsPUPersonaDA ObjPersonaDA = new clsPUPersonaDA();

        //Registrar Persona
        public long RegistrarPersona(int iIdConexion, string cOperacion, ref clsPUPersonaB objPersona, ref string sMensajeError)
        {
            if (ObjPersonaDA.RegistrarPersona(iIdConexion, cOperacion, ref objPersona, ref sMensajeError))
            {
                if (ObjPersonaDA.RegistraTitularDH(iIdConexion, cOperacion, ref objPersona, ref sMensajeError, objPersona.NUP))
                {
                    return objPersona.NUP;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        //Busqueda Avanzada de Persona
        public DataTable BusquedaAvanzada(int iIdConexion, string cOperacion, string sApellidoPaterno, string sApellidoMaterno, string sPrimerNombre, string sSegundoNombre, string sFechaNacimiento, string sMatricula, int NumeroTramite, long NumeroCertidicado, string sNumeroDocumento, string ComplementoSEGIP, int IdDocumentoExpedido, ref string sMensajeError)
        {
            if (sFechaNacimiento=="")
            {
                sFechaNacimiento="01/01/1900";
            }
            DataSet DSetTmp = new DataSet();
            if (ObjPersonaDA.BusquedaAvanzada(iIdConexion, cOperacion, sApellidoPaterno, sApellidoMaterno, sPrimerNombre, sSegundoNombre, sNumeroDocumento, sFechaNacimiento, sMatricula, NumeroTramite, NumeroCertidicado, ComplementoSEGIP, IdDocumentoExpedido, ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }

        //Busqueda por CUA
        public DataTable BusquedaNUP(int iIdConexion, string cOperacion, long vNUP, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjPersonaDA.BusquedaNUP(iIdConexion, cOperacion, vNUP, ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }

        //Registra la fecha de fallecimiento del titular
        public long RegistrarFechaFallecimientoPersona(int iIdConexion, string cOperacion, ref string sMensajeError,
            long vNUP, DateTime vFechaFallecimmiento, string vGlosario)
        {
            if (ObjPersonaDA.RegistrarFechaFallecimientoPersona(iIdConexion, cOperacion, ref sMensajeError, vNUP, vFechaFallecimmiento, vGlosario))
            {
                return Convert.ToInt64(sMensajeError);
            }
            else
            {
                return 0;
            }
        }

        //Buscar personas derechohabientes por NUP del titular
        public DataTable BuscaDH(int iIdConexion, string cOperacion, long vNUP, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjPersonaDA.BuscaDH(iIdConexion, cOperacion, vNUP, ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }

        //Obtiene los datos de las personas por NUP del titular
        public DataTable ObtieneDatosPersona(long vNUP, string vOpcion)
        {
            DataTable dt = new DataTable();
            clsPUPersonaDA val = new clsPUPersonaDA();
            IDataReader dr = val.ObtieneDatosPersona(vNUP, vOpcion);
            dt.Load(dr);
            return dt;
        }

    }
}