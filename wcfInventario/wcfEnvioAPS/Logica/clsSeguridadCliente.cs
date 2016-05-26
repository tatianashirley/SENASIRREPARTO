using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfEnvioAPS.Datos;
using System.Data;

namespace wcfEnvioAPS.Logica
{
    public class clsSeguridadCliente
    {
        DataTable dt = new DataTable();
        clsSeguridadClienteDA ObjSeguridadClienteDA = new clsSeguridadClienteDA();
        Int32 iIdConexion = 0;
        string sMensajeError = null;

        public string CuentaUsuario(int IdConexion)
        {
            DataTable sourceTable = ObjSeguridadClienteDA.ListaDatosConexionDA(IdConexion);
            return (sourceTable.Rows[0][1].ToString());
        }
    }
}