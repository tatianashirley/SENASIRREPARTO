using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using wcfSeguridad.Datos;
using System.Security.Cryptography;
using System.Text;

namespace wcfSeguridad.Logica
{
    public class clsConexionFallida
    {
        DataTable dt = new DataTable();        
        clsConexionFallidaDA ObjConexionFallidaDA = new clsConexionFallidaDA();        


        public bool ConexionFallidaAdiciona(string sCuentaUsuario, string sNombreEstacion, string sIpAddress, ref string sMensajeError)
        {
            bool bAsignacionOK = ObjConexionFallidaDA.ConexionFallidaAdiciona(sCuentaUsuario, sNombreEstacion, sIpAddress, ref sMensajeError);
            return (bAsignacionOK);
        }
        public DataTable ConexionDB(string sCuentaUsuario, string sOperacion, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjConexionFallidaDA.ConexionDB(sCuentaUsuario,sOperacion, ref sMensajeError, ref DSetTmp))
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