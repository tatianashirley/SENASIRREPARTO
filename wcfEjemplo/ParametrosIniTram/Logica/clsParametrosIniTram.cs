using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using wcfEjemplo.ParametrosIniTram.Datos;

namespace wcfEjemplo.ParametrosIniTram.Logica
{
    public class clsParametrosIniTram
    {
        public DataSet log_BusqRenunAutomatica(SqlParameter[] lista)//acceso al sector
        {
            clsParametrosIniTramDA ad = new clsParametrosIniTramDA();
            DataSet ds = ad.DA_BusqRenunAutomatica(lista);
            return ds;
        }
        public DataSet log_Sector(SqlParameter[] lista)//acceso al sector
        {
            clsParametrosIniTramDA ad = new clsParametrosIniTramDA();            
            DataSet ds = ad.DA_Sector(lista);
            return ds;
        }
        public DataSet log_Doc_salario(SqlParameter[] lista)//acceso al sector
        {
            clsParametrosIniTramDA ad = new clsParametrosIniTramDA();
            DataSet ds = ad.DA_Doc_salario(lista);
            return ds;
        }
        public string inicioTramitepersona(SqlParameter[] persona, SqlParameter[] tramite, SqlParameter[,] salarioAutomatico, SqlParameter[] personaIniciaTramite,SqlParameter[,] paramdatoGRegEmpresaManual,SqlParameter[,] paramdatoGSalarioAutomaticoForm02,string tipocc)
        {
            string result = "";
            clsInicioTramiteDA da = new clsInicioTramiteDA();
            result = da.DA_inicioTramitepersona(persona, tramite, salarioAutomatico, personaIniciaTramite, paramdatoGRegEmpresaManual, paramdatoGSalarioAutomaticoForm02, tipocc);
            return result;
        }
        public string Validacion_Automatica(SqlParameter[] param)
        {
            string result = "";
            clsInicioTramiteDA da = new clsInicioTramiteDA();
            result = da.Validacion_AutomaticaDA(param);
            return result;
        }
        public string Registro_Prerenuncia(SqlParameter[] param)
        {
            string result = "";
            clsInicioTramiteDA da = new clsInicioTramiteDA();
            result = da.DA_RegistroPreRenuncia(param);
            return result;
        }
        public string Registro_ConfirmacionRenuncia(SqlParameter[] param)
        {
            string result = "";
            clsInicioTramiteDA da = new clsInicioTramiteDA();
            result = da.DA_ConfirmacionPreRenuncia(param);
            return result;
        }
        public string Registro_CancelarRenuncia(SqlParameter[] param)
        {
            string result = "";
            clsInicioTramiteDA da = new clsInicioTramiteDA();
            result = da.DA_RegistroPreRenuncia(param);
            return result;
        }
        public DataSet log_datosPersonalesreport(SqlParameter[] lista)//acceso al sector
        {
            clsParametrosIniTramDA ad = new clsParametrosIniTramDA();
            DataSet ds = ad.DA_log_datosPersonalesreport(lista);
            return ds;
        }
        //-----------------FFAA
        public DataSet Datos_ffaa(SqlParameter[] lista)//acceso al sector
        {
            clsInicioTramiteDA ad = new clsInicioTramiteDA();
            DataSet ds = ad.DA_Datos_ffaa(lista);
            return ds;
        }
        public string[] InsertaTram_ffaa(string nua, string matricula, string idconexion, int idecivil, string mail, string celular, string direccion, int idlocalidad, string telefono
            , int opc, string obsfondo)//acceso al sector
        {

            string[] lista = new string[11];
            lista[0] = nua;
            lista[1] = matricula;
            lista[2] = idconexion;
            lista[3] = idecivil.ToString();
            lista[4] = mail;
            lista[5] = celular;
            lista[6] = direccion;
            lista[7] = idlocalidad.ToString();
            lista[8] = telefono;
            lista[9] = opc.ToString();
            lista[10] = obsfondo;

            //string result = "";
            string[] result = new string[1];
            //DataSet sel_dataset = new DataSet();
            clsInicioTramiteDA ad = new clsInicioTramiteDA();
            result = ad.DA_InsertaTram_ffaa(lista);
            return result;

        }


        public DataSet ValidaDatosRepetidos(SqlParameter[] lista)//acceso al sector
        {
            clsInicioTramiteDA ad = new clsInicioTramiteDA();
            DataSet ds = ad.DA_ValidaDatosRepetidos(lista);
            return ds;
        }
        //----------------------------------------end
    }
}