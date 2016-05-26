using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using conexion;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace wcfEjemplo.ParametrosIniTram.Datos
{
    public class clsParametrosIniTramDA
    {
        Database db = null;
        string cnxCadena = "";

        public clsParametrosIniTramDA()
        {
            //db = DatabaseFactory.CreateDatabase("cnnstrD");
            cnxCadena = ConfigurationManager.ConnectionStrings["cnnsenarit"].ToString();

        }
        public DataSet DA_Sector(SqlParameter[] lista)
        {
            try
            {
                               
                DataSet sel_dataset = new DataSet();
                sel_dataset = SqlHelper.ExecuteDataset(cnxCadena, CommandType.StoredProcedure, "[Tramite].[PR_TramiteConsParam]", lista);
                return sel_dataset;
            }
            catch (Exception excp1)
            {
                throw (new Exception(excp1.Message));
            }

        
        }
        public DataSet DA_log_datosPersonalesreport(SqlParameter[] lista)
        {
            try
            {
                               
                DataSet sel_dataset = new DataSet();
                sel_dataset = SqlHelper.ExecuteDataset(cnxCadena, CommandType.StoredProcedure, "[Tramite].[PR_ReporteTramiteCC]", lista);
                return sel_dataset;
            }
            catch (Exception excp1)
            {
                throw (new Exception(excp1.Message));
            }

        
        }
        public DataSet DA_Doc_salario(SqlParameter[] lista)
        {
            try
            {
                               
                DataSet sel_dataset = new DataSet();
                sel_dataset = SqlHelper.ExecuteDataset(cnxCadena, CommandType.StoredProcedure, "[Tramite].[PR_TramiteConsParam]", lista);
                return sel_dataset;
            }
            catch (Exception excp1)
            {
                throw (new Exception(excp1.Message));
            }

        
        }

        public string DA_inicioTramitepersona(SqlParameter[] persona, SqlParameter[] tramite, SqlParameter[,] empresaautomatico, SqlParameter[,] salarioAutomatico)
        {
            string res = "";
             conexion1 con_tran= new conexion1();
            SqlConnection conn = con_tran.openConnection(con_tran.cnxCadena);
            SqlTransaction Tramite_Trans = conn.BeginTransaction();
            int id=0;
           
            string fecharegistro = "", idc = "", idc2 = "";
            try
            {
                SqlHelper.ExecuteNonQuery(Tramite_Trans, CommandType.StoredProcedure, "[Novedades].[PR_PersonaIns]", persona);
                id = Convert.ToInt32(persona[28].SqlValue.ToString());
                SqlHelper.ExecuteNonQuery(Tramite_Trans, CommandType.StoredProcedure, "[Novedades].[PR_PersonaIns]", persona);
                id = Convert.ToInt32(persona[28].SqlValue.ToString());

            }
            catch (Exception excp1)
            {
                throw (new Exception(excp1.Message));
            }

            return res;
        }
        public DataSet DA_BusqRenunAutomatica(SqlParameter[] lista)
        {
            try
            {

                DataSet sel_dataset = new DataSet();
                sel_dataset = SqlHelper.ExecuteDataset(cnxCadena, CommandType.StoredProcedure, "[Tramite].[PR_ParamReunuciaAutomatica]", lista);
                return sel_dataset;
            }
            catch (Exception excp1)
            {
                throw (new Exception(excp1.Message));
            }


        }
        
    }
}