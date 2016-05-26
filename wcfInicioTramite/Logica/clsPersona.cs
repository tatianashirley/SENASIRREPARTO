using System.Data;
using wcfInicioTramite.Datos;
using wcfInicioTramite.Entidades;

namespace wcfInicioTramite.Logica
{
    public class clsPersona : clsPersonaBE
    {
        clsPersonaDA ObjPersonaDA = new clsPersonaDA();

        //Buscar Persona por Identificador
        public DataTable BuscarPorIdentificador(int iIdConexion, string cOperacion, string sTipoBusqueda, string sTipoDocumento, string sNumeroDocumento, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjPersonaDA.BuscarPorIdentificador(iIdConexion, cOperacion, sTipoBusqueda, sTipoDocumento, sNumeroDocumento, ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }

        //Buscar Persona por Avanzada
        public DataTable BuscarPorAvanzada(int iIdConexion, string cOperacion, string sTipoBusqueda, string sApellidoPaterno, string sApellidoMaterno, string sPrimerNombre, string sSegundoNombre, string sNumeroDocumento, string sFechaNacimiento, string sPrecision, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjPersonaDA.BuscarPorAvanzada(iIdConexion, cOperacion, sTipoBusqueda, sApellidoPaterno, sApellidoMaterno, sPrimerNombre, sSegundoNombre, sNumeroDocumento, sFechaNacimiento, sPrecision, ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }

        //Obtener datos persona FFAA
        public DataTable ObtenerDatosPersonaFFAA(int iIdConexion, string cOperacion, string sNumeroDocumento, string sNUA, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjPersonaDA.ObtenerDatosPersonaFFAA(iIdConexion, cOperacion, sNumeroDocumento, sNUA, ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }

        //Registrar Persona
        public long RegistrarPersona(int iIdConexion, string cOperacion, ref clsPersona objPersona, ref string sMensajeError)
        {
            if (ObjPersonaDA.RegistrarPersona(iIdConexion, cOperacion, ref objPersona, ref sMensajeError))
            {
                return objPersona.NUP;
            }
            else
            {
                return 0;
            }
        }

        //Obtener datos Persona
        public DataTable BuscarPersona(int iIdConexion, string cOperacion, ref clsPersona objPersona, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjPersonaDA.BuscarPersona(iIdConexion, cOperacion, ref objPersona, ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }

        //Obtener datos Persona
        public DataTable ObtenerPersona(int iIdConexion, string cOperacion, ref clsPersona objPersona, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjPersonaDA.ObtenerPersona(iIdConexion, cOperacion, ref objPersona, ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }

        //Obtener datos referencial
        public DataTable ObtenerDatosReferencial(int iIdConexion, string cOperacion, ref clsPersona objPersona, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjPersonaDA.ObtenerDatosReferencial(iIdConexion, cOperacion, ref objPersona, ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }
    }
}