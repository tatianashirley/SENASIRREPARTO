using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace wcfEjemplo.Datos
{
    public class clsSalarioReferencialDA
    {
        Database db = null;

        public clsSalarioReferencialDA()
        {
            db = DatabaseFactory.CreateDatabase("cnnstrD");
        }

        public string[] ValidaSalario(string Matricula, int IdTipoDocSalario, string PeriodoSalario, decimal SalarioCotizable, decimal IdMonedaSalario,
            int CantidadSalarios)
        {
            string cadena = ConfigurationManager.ConnectionStrings["cnnstrD"].ConnectionString;
            SqlConnection conn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand("Referencial.ValidaSalario", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@matricula", SqlDbType.VarChar,10).Value = Matricula;
            cmd.Parameters.Add("@IdTipoDocSalario", SqlDbType.Int).Value = IdTipoDocSalario;
            cmd.Parameters.Add("@PeriodoSalario", SqlDbType.VarChar, 50).Value = PeriodoSalario;
            cmd.Parameters.Add("@SalarioCotizable", SqlDbType.Decimal,18).Value = SalarioCotizable;
            cmd.Parameters.Add("@IdMonedaSalario", SqlDbType.Int).Value = IdMonedaSalario;
            cmd.Parameters.Add("@CantidadSalarios", SqlDbType.Int).Value = CantidadSalarios;

            cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@estadoFinal", SqlDbType.Int).Direction = ParameterDirection.Output;

            conn.Open();
            cmd.ExecuteNonQuery();
            string[] result = new string[2];
            result[0] = Convert.ToString(cmd.Parameters["@mensaje"].Value);
            if (cmd.Parameters["@estadoFinal"].Value != DBNull.Value)
                result[1] = Convert.ToInt32(cmd.Parameters["@estadoFinal"].Value).ToString();
            else
                result[1] = "0";

            return result;
        }

        public IDataReader SalarioFuerzasArmadas(string NumeroDocumento, string NUA)
        {
            DbCommand cmd = db.GetStoredProcCommand("Referencial.FuerzasArmadas",NumeroDocumento,NUA);
            IDataReader dataReader = db.ExecuteReader(cmd);
            return dataReader;
        }
    }
}