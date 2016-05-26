using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Globalization;
using System.Text;
using System.Xml;
using System.Data.Common;
using System.Resources;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using wcfServicioIntercambioPago.Entidades;

namespace wcfServicioIntercambioPago.Datos
{
    public class clsCargarMediosDA
    {
        Database db = null;

        public clsCargarMediosDA()
        {
            db = DatabaseFactory.CreateDatabase("cadena");
        }
        //Inserta cada registro de los medios en la temporal correspondiente
        public Boolean InsertaTemporal(string TipoMedio,int Periodo,string Entidad, string Planilla, string PeriodoPlanilla
                                        ,Int64 CUA, int NumeroCertificado, string TipoCC, Int64 CI, int CodigoTransaccion
                                        ,double MontoTransaccion, string FechaInicio, string FechaFinal, int regional)
        {
            try
            {
                DbCommand dbCommand = db.GetStoredProcCommand("PagoCC.PR_InsertaTemporal", TipoMedio,Periodo,Entidad,Planilla
                                                                ,PeriodoPlanilla,CUA,NumeroCertificado,TipoCC,CI,CodigoTransaccion
                                                                ,MontoTransaccion,FechaInicio,FechaFinal,regional);
                db.ExecuteNonQuery(dbCommand);
                return true;
            }
            catch
            {
                return false;
            }
        }
        //Inserta toda la tabla de c# a las temporales
        public string insertaBulk(DataTable TablaOrigen,string TablaDestino)
        {
            //string cnx = "integrated security = SSPI;data source =(local);initial catalog = BioMod; Application Name=BioMod";
            string cn = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
            using (SqlConnection ConexionBulk = new SqlConnection(cn))
            {
                ConexionBulk.Open();
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(ConexionBulk))
                {
                    bulkCopy.DestinationTableName =TablaDestino;
                    try
                    {
                        bulkCopy.WriteToServer(TablaOrigen);
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                    finally
                    {
                        ConexionBulk.Close();
                    }
                    return null;
                }
            }
        }
        //Elimina fisicamente de las tablas temporales
        public Boolean EliminaTemporal(string TipoMedio,string IdEntidad, int Envio)
        {
            try
            {
                DbCommand dbCommand = db.GetStoredProcCommand("PagoCC.PR_EliminaTemporal", TipoMedio,IdEntidad,Envio);
                db.ExecuteNonQuery(dbCommand);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}