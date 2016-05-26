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

    public class clsDocumentosDA
    {
        Database db = null;

        public clsDocumentosDA()
        {
            db = DatabaseFactory.CreateDatabase("cnnstr");
        }


        /* Lista Documentos para inicio de trámite por prestación */
        public IDataReader ListarDocumentosPrestacion(string prestacion)
        {
            DbCommand cmd = db.GetStoredProcCommand("Clasificador.ListarDocumentosInicioTramite", prestacion);
            IDataReader dataReader = db.ExecuteReader(cmd);
            return dataReader;
        }

        public IDataReader ListarDocumentos(Int64 s_iIdConexion, string s_cOperacion, int s_iSesionTrabajo, string s_sSSN, string i_sIdTipoTramite)
        {
            DbCommand cmd = db.GetStoredProcCommand("Workflow.PR_SolicitudTramite", s_iIdConexion, s_cOperacion, s_iSesionTrabajo, s_sSSN, "", DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value,
                i_sIdTipoTramite, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value);
            IDataReader dataReader = db.ExecuteReader(cmd);
            return dataReader;
        }

        public void VerificarPrestacion(long s_iIdConexion, string s_cOperacion, int s_iSesionTrabajo, string s_sSSN, int i_iSecuencia, int i_iIdHisInstancia, 
            string i_sIdTipoTramite, string i_sIdConcepto, string i_sTipoDato, bool i_bFlagInicio, int i_iValorInt, decimal i_mValorMoney, decimal i_dValorFloat, 
            string i_sValorChar, DateTime i_fValorDate, int i_iValorCatalog, bool i_bValorBoolean)
        {
            DbCommand cmd = db.GetStoredProcCommand("Workflow.PR_SolicitudTramiteConceptoTmp", s_iIdConexion, s_cOperacion, s_iSesionTrabajo, s_sSSN, "", i_iSecuencia, i_iIdHisInstancia, 
                                    i_sIdTipoTramite, i_sIdConcepto,i_sTipoDato, i_bFlagInicio, i_iValorInt, i_mValorMoney, i_dValorFloat, i_sValorChar,DBNull.Value , i_iValorCatalog, i_bValorBoolean);
            db.ExecuteReader(cmd);
        }

        public void InsertarDocumento(int idTipodocumento, string Descripcion, string Resumen, int IdEstadoDocumento, string NumeroDocumento, DateTime FechaDocumento,
                                        string Ruta, bool Digital, bool RegistroActivo, int s_iIdConexion, string s_cOperacion, Int64 s_iSesionTrabajo, string s_sSSN, string o_sMensajeError, int i_iIdHisInstancia,
                                        string i_sIdTipoTramite, int i_iIdTipoDocumento)
        {
            DbCommand cmd = db.GetStoredProcCommand("Documentos.PR_InsertaDocumento", idTipodocumento, Descripcion, Resumen, IdEstadoDocumento, NumeroDocumento, DBNull.Value,
                                        DBNull.Value, false, true, s_iIdConexion, s_cOperacion, s_iIdConexion, DBNull.Value, DBNull.Value, i_iIdHisInstancia
                                                , i_sIdTipoTramite, i_iIdTipoDocumento);
            db.ExecuteReader(cmd);
        }

        public string[] SolicitudGrabarTramite(Int64 s_iIdConexion, string s_cOperacion, int s_iSesionTrabajo, string s_sSSN, string i_sIdTipoTramite, int i_iIdHisInstancia,
            int i_iIdRol, int i_iIdUsuario, DateTime i_fFechaHoraRegistro, DateTime i_fFechaHoraInicio, DateTime i_fFechaHoraTermino, int i_sEstado, int o_iIdSolicitud, string i_sCodigoTramite, string i_sDescripcion)
        {
            string cadena = ConfigurationManager.ConnectionStrings["cnnstrD"].ConnectionString;
            SqlConnection conn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand("Workflow.PR_SolicitudTramite", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            if (s_iIdConexion != 0)
                cmd.Parameters.Add("@s_iIdConexion", SqlDbType.Int).Value = s_iIdConexion;
            else
                cmd.Parameters.Add("@s_iIdConexion", SqlDbType.Int).Value = DBNull.Value;

            if (s_cOperacion != "")
                cmd.Parameters.Add("@s_cOperacion", SqlDbType.Char,1).Value = s_cOperacion;
            else
                cmd.Parameters.Add("@s_cOperacion", SqlDbType.Char, 1).Value = DBNull.Value;

            if (s_iSesionTrabajo != 0)
                cmd.Parameters.Add("@s_iSesionTrabajo", SqlDbType.Int).Value = s_iSesionTrabajo;
            else
                cmd.Parameters.Add("@s_iSesionTrabajo", SqlDbType.Int).Value = DBNull.Value;

            if (s_sSSN != "")
                cmd.Parameters.Add("@s_sSSN", SqlDbType.VarChar,40).Value = s_sSSN;
            else
                cmd.Parameters.Add("@s_sSSN", SqlDbType.VarChar, 40).Value = DBNull.Value;

            if (i_sDescripcion != "")
                cmd.Parameters.Add("@i_sDescripcion", SqlDbType.VarChar, 500).Value = i_sDescripcion;
            else
                cmd.Parameters.Add("@i_sDescripcion", SqlDbType.VarChar, 500).Value = DBNull.Value;

            if (i_sCodigoTramite != "")
                cmd.Parameters.Add("@i_sCodigoTramite", SqlDbType.VarChar,20).Value = i_sCodigoTramite;
            else
                cmd.Parameters.Add("@i_sCodigoTramite", SqlDbType.VarChar,20).Value = DBNull.Value;

            if (i_iIdHisInstancia != 0)
                cmd.Parameters.Add("@i_iIdHisInstancia", SqlDbType.Int).Value = i_iIdHisInstancia;
            else
                cmd.Parameters.Add("@i_iIdHisInstancia", SqlDbType.Int).Value = DBNull.Value;

            if (i_sIdTipoTramite != "")
                cmd.Parameters.Add("@i_sIdTipoTramite", SqlDbType.VarChar, 20).Value = i_sIdTipoTramite;
            else
                cmd.Parameters.Add("@i_sIdTipoTramite", SqlDbType.VarChar, 20).Value = DBNull.Value;

            if (i_iIdRol != 0)
                cmd.Parameters.Add("@i_iIdRol", SqlDbType.Int).Value = i_iIdRol;
            else
                cmd.Parameters.Add("@i_iIdRol", SqlDbType.Int).Value = DBNull.Value;

            if (i_iIdUsuario != 0)
                cmd.Parameters.Add("@i_iIdUsuario", SqlDbType.Int).Value = i_iIdUsuario;
            else
                cmd.Parameters.Add("@i_iIdUsuario", SqlDbType.Int).Value = DBNull.Value;

            if (i_sEstado != 0)
                cmd.Parameters.Add("@i_sEstado", SqlDbType.Char,1).Value = i_sEstado;
            else
                cmd.Parameters.Add("@i_sEstado", SqlDbType.Char, 1).Value = DBNull.Value;

            cmd.Parameters.Add("@o_sMensajeError", SqlDbType.VarChar, 1000).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@o_iIdSolicitud", SqlDbType.BigInt).Direction = ParameterDirection.Output;

            conn.Open();
            cmd.ExecuteNonQuery();
            string[] result = new string[2];
            result[0] = Convert.ToString(cmd.Parameters["@o_sMensajeError"].Value);
            if (cmd.Parameters["@o_iIdSolicitud"].Value != DBNull.Value)
                result[1] = Convert.ToInt32(cmd.Parameters["@o_iIdSolicitud"].Value).ToString();
            else
                result[1] = "0";

            return result;
        }

        public void IntanciarTramite(Int64 s_iIdConexion, string s_cOperacion, int s_iSesionTrabajo, string s_sSSN, int i_iIdInstancia, int i_iIdHisInstancia, string i_iIdTipoTramite,
            int i_iIdFlujo, DateTime i_fFechaHoraInicio, DateTime i_fFechaHoraFin,int i_iIdOficina, int i_iIdRol, int i_iIdUsuario, int o_iIdSolicitud,int i_sEstado, 
            DateTime i_fCambioEstadoFechaHora,string i_sCancelaJustificacion, int i_sCancelaIdOficina,int i_sCancelaIdRol,int i_sCancelaIdUsuario)
        {
            DbCommand cmd = db.GetStoredProcCommand("Workflow.PR_Instancia", s_iIdConexion, s_cOperacion, s_iSesionTrabajo, s_sSSN, "",i_iIdInstancia, i_iIdHisInstancia, i_iIdTipoTramite,
            i_iIdFlujo, DBNull.Value, DBNull.Value, i_iIdOficina, i_iIdRol, i_iIdUsuario, o_iIdSolicitud, i_sEstado, 
            DBNull.Value ,i_sCancelaJustificacion, i_sCancelaIdOficina,i_sCancelaIdRol,i_sCancelaIdUsuario);
            db.ExecuteReader(cmd);
        }
    }
}