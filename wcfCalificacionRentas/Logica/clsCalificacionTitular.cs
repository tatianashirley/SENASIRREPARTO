using System;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;

using System.Linq;
using System.Web;
//using System.Data.Sql
using System.Data.Common;






namespace wcfCalificacionRentas.Logica
{
    public class clsCalificacionTitular
    {
        Database db = null;

        public clsCalificacionTitular()
        {
            db = DatabaseFactory.CreateDatabase("cadena");
        }
        public string RegistrarDatosEjemplo(string Nombre, DateTime fecha, decimal valor, int idConexion, string Operacion)
        {
            string m = null;
            try
            {
                DbCommand cmd = db.GetStoredProcCommand("dbo.PR_RegistraEmpresa2", Nombre, fecha, valor, idConexion, Operacion);
                db.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                m= ex.Message;
            }
            return m;
       }
        public string RegistrarNuevoBeneficio(string NUPAsegurado, int IDGrupoBeneficio, int IDCampoAplicacion, DateTime FechaOtorgamiento,int EstadoBeneficio,int TipoResolucion, int claseresolucion, int idConexion, string Operacion)
        {
            string m = null;
            try
            {
                DbCommand cmd = db.GetStoredProcCommand("E_Calificacion.PR_RegistraTitular", NUPAsegurado, IDGrupoBeneficio, IDCampoAplicacion,FechaOtorgamiento,EstadoBeneficio, TipoResolucion, claseresolucion, idConexion, Operacion);
                db.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                m = ex.Message;
            }
            return m;
        }
        public DataSet ComboTipoBeneficio()
        {
                DbCommand cmd = db.GetStoredProcCommand("dbo.PR_ClasificadorResolucion");
                db.ExecuteNonQuery(cmd);
                IDataReader dr = db.ExecuteReader(cmd);
                DataTable dt = new DataTable();
                dt.Load(dr);
                DataSet ds = new DataSet();
                ds.Tables.Add(dt);
                return ds;
        }

       public DataTable ObtClasificadorTipoResolucion(int IdConexion, string Operacion)
       { 
           DbCommand cmd = db.GetStoredProcCommand("E_Calificacion.PR_ClasificadoresRenta", IdConexion, Operacion);
           db.ExecuteNonQuery(cmd);
           IDataReader dr = db.ExecuteReader(cmd);   
           DataTable dt = new DataTable();
               dt.Load(dr);
               //DataSet ds = new DataSet();
               //ds.Tables.Add(dt);
               return dt;
        }
       public DataTable ObtClasificadorTipoRenta(int IdConexion, string Operacion)
       {
           DbCommand cmd = db.GetStoredProcCommand("E_Calificacion.PR_ClasificadoresRenta", IdConexion, Operacion);
           db.ExecuteNonQuery(cmd);
           IDataReader dr = db.ExecuteReader(cmd);
           DataTable dt = new DataTable();
           dt.Load(dr);
           //DataSet ds = new DataSet();
           //ds.Tables.Add(dt);
           return dt;
       }
       public IDataReader ListarDeAseguradoSegunFiltro(string appaterno, string apmaterno, string pnombre, string snombre, string ci, string matricula, int IdConexion, string Operacion)
       {
           
               DbCommand cmd = db.GetStoredProcCommand("Persona.PR_BuscaPersonaR", appaterno, apmaterno, pnombre, snombre, ci, matricula, IdConexion, Operacion);
               IDataReader dataReader = db.ExecuteReader(cmd);
               db.ExecuteNonQuery(cmd);
               return dataReader;
           //return m;    
       }

    }
}