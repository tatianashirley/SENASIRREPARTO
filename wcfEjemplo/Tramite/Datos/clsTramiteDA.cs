using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace wcfEjemplo.Tramite.Datos
{
    public class clsTramiteDA
    {
        Database db = null;
        public clsTramiteDA()
        {
            db = DatabaseFactory.CreateDatabase("cnnstr");
        }

        public string[] InsertarTramite(string[] datos)
        {
            string cadena = ConfigurationManager.ConnectionStrings["cnnstrD"].ConnectionString;
            SqlConnection conn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand("Tramite.InsertarInicio", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            if (datos[0]!="")
                cmd.Parameters.Add("@NUP", SqlDbType.BigInt).Value = Convert.ToInt64(datos[0]);
            else
                cmd.Parameters.Add("@NUP", SqlDbType.BigInt).Value = DBNull.Value;

            if (datos[1] != "")
                cmd.Parameters.Add("@IdGrupoBeneficio", SqlDbType.Int).Value = Convert.ToInt16(datos[1]);
            else
                cmd.Parameters.Add("@IdGrupoBeneficio", SqlDbType.BigInt).Value = DBNull.Value;

            if (datos[2] != "")
                cmd.Parameters.Add("@IdBeneficio", SqlDbType.Int).Value = Convert.ToInt16(datos[2]);
            else
                cmd.Parameters.Add("@IdBeneficio", SqlDbType.BigInt).Value = DBNull.Value;

            if (datos[3] != "")
                cmd.Parameters.Add("@IdSubBeneficio", SqlDbType.Int).Value = Convert.ToInt16(datos[3]);
            else
                cmd.Parameters.Add("@IdSubBeneficio", SqlDbType.BigInt).Value = DBNull.Value;

            if (datos[4] != "")
                cmd.Parameters.Add("@IdTipoTramite", SqlDbType.Int).Value = Convert.ToInt16(datos[4]);
            else
                cmd.Parameters.Add("@IdTipoTramite", SqlDbType.BigInt).Value = DBNull.Value;

            if (datos[5] != "")
                cmd.Parameters.Add("@IdInstancia", SqlDbType.Int).Value = Convert.ToInt16(datos[5]);
            else
                cmd.Parameters.Add("@IdInstancia", SqlDbType.BigInt).Value = DBNull.Value;

            if (datos[6] != "")
                cmd.Parameters.Add("@IdClaseExpediente", SqlDbType.Int).Value = Convert.ToInt16(datos[6]);
            else
                cmd.Parameters.Add("@IdClaseExpediente", SqlDbType.BigInt).Value = DBNull.Value;

            if (datos[7] != "")
                cmd.Parameters.Add("@IdSector", SqlDbType.Int).Value = Convert.ToInt16(datos[7]);
            else
                cmd.Parameters.Add("@IdSector", SqlDbType.BigInt).Value = DBNull.Value;

            if (datos[8] != "")
                cmd.Parameters.Add("@IdOficinaRegistro", SqlDbType.Int).Value = Convert.ToInt16(datos[8]);
            else
                cmd.Parameters.Add("@IdOficinaRegistro", SqlDbType.BigInt).Value = DBNull.Value;

            if(datos[9] != "")
                cmd.Parameters.Add("@NUPIniciaTramite", SqlDbType.BigInt).Value=Convert.ToInt64(datos[9]);
            else
                cmd.Parameters.Add("@NUPIniciaTramite", SqlDbType.BigInt).Value = DBNull.Value;

            if (datos[10] != "")
                cmd.Parameters.Add("@IdTipoIniciaTramite", SqlDbType.Int).Value = Convert.ToInt16(datos[10]);
            else
                cmd.Parameters.Add("@IdTipoIniciaTramite", SqlDbType.BigInt).Value = DBNull.Value;

            if (datos[11] != "")
                cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar, 500).Value = datos[11];
            else
                cmd.Parameters.Add("@Observaciones", SqlDbType.BigInt).Value = DBNull.Value;

            if (datos[12] != "")
                cmd.Parameters.Add("@IdEstadoTramite", SqlDbType.Int).Value = Convert.ToInt16(datos[12]);
            else
                cmd.Parameters.Add("@IdEstadoTramite", SqlDbType.BigInt).Value = DBNull.Value;

            if (datos[13] != "")
                cmd.Parameters.Add("@IdTipoProcesoRegistroTramite", SqlDbType.Int).Value = Convert.ToInt16(datos[13]);
            else
                cmd.Parameters.Add("@IdTipoProcesoRegistroTramite", SqlDbType.BigInt).Value = DBNull.Value;

            if (datos[14] != "")
                cmd.Parameters.Add("@EstadoHabilitacion", SqlDbType.Int).Value = Convert.ToInt16(datos[14]);
            else
                cmd.Parameters.Add("@EstadoHabilitacion", SqlDbType.BigInt).Value = DBNull.Value;

            if (datos[15] != "")
                cmd.Parameters.Add("@DocumentoHabilitacion", SqlDbType.VarChar, 100).Value = datos[15];
            else
                cmd.Parameters.Add("@DocumentoHabilitacion", SqlDbType.BigInt).Value = DBNull.Value;

            cmd.Parameters.Add("@IdTramite", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@mensaje", SqlDbType.VarChar,200).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@retorno_proc", SqlDbType.Int).Direction = ParameterDirection.Output;


            conn.Open();
            cmd.ExecuteNonQuery();
            string[] result = new string[3];
            result[0] = Convert.ToString(cmd.Parameters["@mensaje"].Value);

            if ((cmd.Parameters["@retorno_proc"].Value) != DBNull.Value)
                result[1] =(cmd.Parameters["@retorno_proc"].Value).ToString();
            else
                result[1] = "-1";

                result[2] = (cmd.Parameters["@IdTramite"].Value).ToString();

            return result;
        }

        public string[] EmpresaPersonaRegistroIns(Int64 Tramite, int idGrupoBeneficio, decimal IdEmpresa, string NombreEmpresaDeclarada, string PeriodoInicio,
            string PeriodoFin, decimal Monto, int IdMoneda)
        {
            string cadena = ConfigurationManager.ConnectionStrings["cnnstrD"].ConnectionString;
            SqlConnection conn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand("Tramite.PR_EmpresaPersonaRegistroIns", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            if (Tramite != 0)
                cmd.Parameters.Add("@IdTramite", SqlDbType.Int).Value = Tramite;
            else
                cmd.Parameters.Add("@IdTramite", SqlDbType.Int).Value = DBNull.Value;

            if (idGrupoBeneficio != 0)
                cmd.Parameters.Add("@idGrupoBeneficio", SqlDbType.Int).Value = idGrupoBeneficio;
            else
                cmd.Parameters.Add("@idGrupoBeneficio", SqlDbType.Int).Value = DBNull.Value;

            if (IdEmpresa != 0)
                cmd.Parameters.Add("@IdEmpresa", SqlDbType.Int).Value = IdEmpresa;
            else
                cmd.Parameters.Add("@IdEmpresa", SqlDbType.Int).Value = DBNull.Value;

            if (NombreEmpresaDeclarada != "")
                cmd.Parameters.Add("@NombreEmpresaDeclarada", SqlDbType.VarChar,50).Value = NombreEmpresaDeclarada;
            else
                cmd.Parameters.Add("@NombreEmpresaDeclarada", SqlDbType.VarChar, 50).Value = DBNull.Value;

            if (PeriodoInicio != "")
                cmd.Parameters.Add("@PeriodoInicio", SqlDbType.VarChar,6).Value = PeriodoInicio;
            else
                cmd.Parameters.Add("@PeriodoInicio", SqlDbType.VarChar, 6).Value = DBNull.Value;

            if (PeriodoFin != "")
                cmd.Parameters.Add("@PeriodoFin", SqlDbType.VarChar, 6).Value = PeriodoFin;
            else
                cmd.Parameters.Add("@PeriodoFin", SqlDbType.VarChar, 6).Value = DBNull.Value;

            if (Monto != 0)
                cmd.Parameters.Add("@Monto", SqlDbType.Decimal).Value = Monto;
            else
                cmd.Parameters.Add("@Monto", SqlDbType.Decimal).Value = DBNull.Value;

            if (IdMoneda != 0)
                cmd.Parameters.Add("@IdMoneda", SqlDbType.Int).Value = IdMoneda;
            else
                cmd.Parameters.Add("@IdMoneda", SqlDbType.Int).Value = DBNull.Value;

            cmd.Parameters.Add("@mensaje", SqlDbType.VarChar,200).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@retorno_proc", SqlDbType.Int).Direction = ParameterDirection.Output;

            string parametros = Tramite + "," + idGrupoBeneficio + "," + IdEmpresa + "," + NombreEmpresaDeclarada + "," + PeriodoInicio + "," + PeriodoFin + "," +
                Monto;

            conn.Open();
            cmd.ExecuteNonQuery();
            string[] result = new string[2];
            result[0] = Convert.ToString(cmd.Parameters["@mensaje"].Value);
            if (cmd.Parameters["@retorno_proc"].Value != DBNull.Value)
                result[1] = Convert.ToInt32(cmd.Parameters["@retorno_proc"].Value).ToString();
            else
                result[1] = "0";

            return result;
        }
    }
}