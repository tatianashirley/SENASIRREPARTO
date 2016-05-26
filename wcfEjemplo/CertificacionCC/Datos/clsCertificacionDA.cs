using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace wcfEjemplo.CertificacionCC.Datos
{
    public class clsCertificacionDA
    {
         Database db = null;

         public clsCertificacionDA()
        {
            db = DatabaseFactory.CreateDatabase("cnnstrD");
        }

         public string[] InicioAutomatico(Int64 IdTramite, int IdGrupoBeneficio, DateTime FechaAfiliacion, DateTime FechaBajaAfilia, decimal SalarioCotizableT, int CampoAplicacionCerti,
            int idUsuarioRegistro, Int64 RUC, int IdTipoDocSalario, string PeriodoSalario, decimal SalarioCotizable, int IdEstadoSalario, int IdTipoCertifica, int IdTipoCertificaSalarioCotizable)
        {
            string cadena = ConfigurationManager.ConnectionStrings["cnnstrD"].ConnectionString;
            SqlConnection conn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand("CertificacionCC.InsercionAutomatico", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            if (IdTramite != 0)
                cmd.Parameters.Add("@IdTramite", SqlDbType.BigInt).Value = IdTramite;
            else
                cmd.Parameters.Add("@IdTramite", SqlDbType.BigInt).Value = DBNull.Value;

            if (IdGrupoBeneficio != 0)
                cmd.Parameters.Add("@IdGrupoBeneficio", SqlDbType.Int).Value = IdGrupoBeneficio;
            else
                cmd.Parameters.Add("@IdGrupoBeneficio", SqlDbType.Int).Value = DBNull.Value;

            if (FechaAfiliacion != DateTime.MinValue)
                cmd.Parameters.Add("@FechaAfiliacion", SqlDbType.Date).Value = FechaAfiliacion;
            else
                cmd.Parameters.Add("@FechaAfiliacion", SqlDbType.Date).Value = DBNull.Value;

            if (FechaBajaAfilia != DateTime.MinValue)
                cmd.Parameters.Add("@FechaBajaAfilia", SqlDbType.Date).Value = FechaBajaAfilia;
            else
                cmd.Parameters.Add("@FechaBajaAfilia", SqlDbType.Date).Value = DBNull.Value;

            if (SalarioCotizableT != 0)
                cmd.Parameters.Add("@SalarioCotizableT", SqlDbType.Decimal).Value = SalarioCotizableT;
            else
                cmd.Parameters.Add("@SalarioCotizableT", SqlDbType.Decimal).Value = DBNull.Value;

            if (CampoAplicacionCerti != 0)
                cmd.Parameters.Add("@CampoAplicacionCerti", SqlDbType.Int).Value = CampoAplicacionCerti;
            else
                cmd.Parameters.Add("@CampoAplicacionCerti", SqlDbType.Int).Value = DBNull.Value;

            if (idUsuarioRegistro != 0)
                cmd.Parameters.Add("@idUsuarioRegistro", SqlDbType.Int).Value = idUsuarioRegistro;
            else
                cmd.Parameters.Add("@idUsuarioRegistro", SqlDbType.Int).Value = DBNull.Value;

            if (RUC != 0)
                cmd.Parameters.Add("@RUC", SqlDbType.BigInt).Value = RUC;
            else
                cmd.Parameters.Add("@RUC", SqlDbType.BigInt).Value = DBNull.Value;

            if (IdTipoDocSalario != 0)
                cmd.Parameters.Add("@IdTipoDocSalario", SqlDbType.Int).Value = IdTipoDocSalario;
            else
                cmd.Parameters.Add("@IdTipoDocSalario", SqlDbType.Int).Value = DBNull.Value;

            if (PeriodoSalario != "")
                cmd.Parameters.Add("@vPeriodoSalario", SqlDbType.VarChar,6).Value = PeriodoSalario;
            else
                cmd.Parameters.Add("@vPeriodoSalario", SqlDbType.VarChar, 6).Value = DBNull.Value;

            if (SalarioCotizable != 0)
                cmd.Parameters.Add("@SalarioCotizable", SqlDbType.Decimal).Value = SalarioCotizable;
            else
                cmd.Parameters.Add("@SalarioCotizable", SqlDbType.Decimal).Value = DBNull.Value;

            if (IdEstadoSalario != 0)
                cmd.Parameters.Add("@IdEstadoSalario", SqlDbType.Int).Value = IdEstadoSalario;
            else
                cmd.Parameters.Add("@IdEstadoSalario", SqlDbType.Int).Value = DBNull.Value;

            if (IdTipoCertificaSalarioCotizable != 0)
                cmd.Parameters.Add("@IdTipoCertificaSalarioCotizable", SqlDbType.Int).Value = IdTipoCertificaSalarioCotizable;
            else
                cmd.Parameters.Add("@IdTipoCertificaSalarioCotizable", SqlDbType.Int).Value = DBNull.Value;

            cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@retorno_proc", SqlDbType.Int).Direction = ParameterDirection.Output;

             string PARAMETROS = IdTramite.ToString()+","+IdGrupoBeneficio.ToString()+","+FechaAfiliacion.ToString()+","+FechaBajaAfilia.ToString()+","+SalarioCotizableT.ToString()+","+CampoAplicacionCerti.ToString()+","+
            idUsuarioRegistro.ToString() + "," + RUC.ToString() + "," + IdTipoDocSalario.ToString() + "," + PeriodoSalario + "," + SalarioCotizable.ToString() + "," + IdEstadoSalario.ToString() + "," + IdTipoCertifica.ToString() + "," + IdTipoCertificaSalarioCotizable.ToString();

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