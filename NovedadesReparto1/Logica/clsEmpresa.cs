using System;
using System.Data;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;

using System.Data.Common;
using System.Collections.Generic;



namespace wcfNovedadesReparto.Logica
{
    
    public class clsEmpresa
    {
        Database db = null;

        public clsEmpresa()
        {
            db = DatabaseFactory.CreateDatabase("cadena");
        }
        //* Insert   */        
        public string RegistrarDatos(string Nombre, DateTime Fecha, decimal Valor, int IdConexion, string Operacion)
        {
            string m = null;
            try
            {
                DbCommand cmd = db.GetStoredProcCommand("dbo.PR_RegistraEmpresa", Nombre, Fecha, Valor, IdConexion, Operacion);
                db.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                m = ex.Message;
            }
            return m;
        }
           
    }
}