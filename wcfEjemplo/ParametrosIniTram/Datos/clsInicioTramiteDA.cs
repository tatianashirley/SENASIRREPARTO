using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using conexion;

namespace wcfEjemplo.ParametrosIniTram.Datos
{
    public class clsInicioTramiteDA
    {
        //Database db = null;
        string cnxCadena = "";

        public clsInicioTramiteDA()
        {
            //db = DatabaseFactory.CreateDatabase("cnnstrD");
             cnxCadena = ConfigurationManager.ConnectionStrings["cnnstr"].ToString();

        }
        public string DA_inicioTramitepersona(SqlParameter[] persona, SqlParameter[] tramite, SqlParameter[,] salarioAutomatico, SqlParameter[] personaIniciaTramite, SqlParameter[,] paramdatoGRegEmpresaManual, SqlParameter[,] paramdatoGSalarioAutomaticoForm02, string tipocc)
        {
            string res="";
            int idc,idt,i,idcpit;
            conexion1 con_tran = new conexion1();
            SqlConnection conn = con_tran.openConnection(con_tran.cnxCadena);
            SqlTransaction Tramite_Trans = conn.BeginTransaction();
            try
            {
                //--------------AUTOMATICO SALARIO
                SqlParameter[] salarioAutomaticoV = new SqlParameter[9];
                salarioAutomaticoV[0] = new SqlParameter("@IdTramite", SqlDbType.Int);
                salarioAutomaticoV[1] = new SqlParameter("@IdGrupoBeneficio", SqlDbType.Int);
                salarioAutomaticoV[2] = new SqlParameter("@Version", SqlDbType.Int);
                salarioAutomaticoV[3] = new SqlParameter("@RUC", SqlDbType.VarChar, 50);
                salarioAutomaticoV[4] = new SqlParameter("@IdTipoDocSalario", SqlDbType.Int);
                salarioAutomaticoV[5] = new SqlParameter("@PeriodoSalario", SqlDbType.VarChar, 25);
                salarioAutomaticoV[6] = new SqlParameter("@SalarioCotizable", SqlDbType.VarChar, 50);
                salarioAutomaticoV[7] = new SqlParameter("@IdMonedaSalario", SqlDbType.Int);
                salarioAutomaticoV[8] = new SqlParameter("@IdConexion", SqlDbType.VarChar, 50);
                //------------------------------REGISTRO EMPRESAS PERSONA AUTOMATICO
                SqlParameter[] EmpresasalarioAutomatico = new SqlParameter[10];
                EmpresasalarioAutomatico[0] = new SqlParameter("@s_iIdConexion", SqlDbType.BigInt);
                EmpresasalarioAutomatico[1] = new SqlParameter("@s_cOperacion", SqlDbType.VarChar, 1);
                EmpresasalarioAutomatico[2] = new SqlParameter("@s_IdTramite", SqlDbType.Int);
                EmpresasalarioAutomatico[3] = new SqlParameter("@s_idGrupoBeneficio", SqlDbType.Int);
                EmpresasalarioAutomatico[4] = new SqlParameter("@s_IdEmpresa", SqlDbType.VarChar,50);
                EmpresasalarioAutomatico[5] = new SqlParameter("@s_PeriodoInicio", SqlDbType.VarChar, 25);
                EmpresasalarioAutomatico[6] = new SqlParameter("@s_Monto", SqlDbType.VarChar, 50);
                EmpresasalarioAutomatico[7] = new SqlParameter("@s_IdMoneda", SqlDbType.Int);
                EmpresasalarioAutomatico[8] = new SqlParameter("@s_IdSector", SqlDbType.Int);
                EmpresasalarioAutomatico[9] = new SqlParameter("@s_IdTipoDocSalario", SqlDbType.Int);
                
                //-----------------------------REGISTRO EMPRESAS PERSONA MANUAL
                SqlParameter[] EmpresaRegmanual = new SqlParameter[14];
                EmpresaRegmanual[0] = new SqlParameter("@s_iIdConexion", SqlDbType.BigInt);
                EmpresaRegmanual[0].IsNullable = true;
                EmpresaRegmanual[1] = new SqlParameter("@s_cOperacion", SqlDbType.VarChar, 1);
                EmpresaRegmanual[1].IsNullable = true;
                EmpresaRegmanual[2] = new SqlParameter("@s_IdTramite", SqlDbType.Int);
                EmpresaRegmanual[2].IsNullable = true;
                EmpresaRegmanual[3] = new SqlParameter("@s_idGrupoBeneficio", SqlDbType.Int);
                EmpresaRegmanual[3].IsNullable = true;
                EmpresaRegmanual[4] = new SqlParameter("@s_IdEmpresa", SqlDbType.VarChar, 50);
                EmpresaRegmanual[4].IsNullable = true;
                EmpresaRegmanual[5] = new SqlParameter("@s_NombreEmpresaDeclarada", SqlDbType.VarChar,50);
                EmpresaRegmanual[5].IsNullable = true;
                EmpresaRegmanual[6] = new SqlParameter("@s_PeriodoInicio", SqlDbType.VarChar, 15);
                EmpresaRegmanual[6].IsNullable = true;
                EmpresaRegmanual[7] = new SqlParameter("@s_PeriodoFin", SqlDbType.VarChar, 15);
                EmpresaRegmanual[7].IsNullable = true;
                EmpresaRegmanual[8] = new SqlParameter("@s_Monto", SqlDbType.VarChar, 50);
                EmpresaRegmanual[8].IsNullable = true;
                EmpresaRegmanual[9] = new SqlParameter("@s_IdMoneda", SqlDbType.Int);
                EmpresaRegmanual[9].IsNullable = true;
                EmpresaRegmanual[10] = new SqlParameter("@s_NroPatronalRucAlt", SqlDbType.VarChar, 50);
                EmpresaRegmanual[10].IsNullable = true;
                EmpresaRegmanual[11] = new SqlParameter("@s_IdSector", SqlDbType.Int);
                EmpresaRegmanual[11].IsNullable = true;
                EmpresaRegmanual[12] = new SqlParameter("@s_IdTipoDocSalario", SqlDbType.Int);
                EmpresaRegmanual[12].IsNullable = true;
                EmpresaRegmanual[13] = new SqlParameter("@o_Salida", SqlDbType.VarChar, 1000);
                EmpresaRegmanual[13].IsNullable = true;
                EmpresaRegmanual[13].Direction = ParameterDirection.Output;

                SqlHelper.ExecuteNonQuery(Tramite_Trans, CommandType.StoredProcedure, "[Tramite].[PR_PersonaInsert]", persona);
                idc = Convert.ToInt32(persona[28].SqlValue.ToString());
                tramite[1].Value = idc;
                //
                if (Convert.ToUInt32(tramite[10].Value) != 526)
                {

                    SqlHelper.ExecuteNonQuery(Tramite_Trans, CommandType.StoredProcedure, "[Tramite].[PR_InsertIniciadorTPersona]", personaIniciaTramite);
                    idcpit = Convert.ToInt32(personaIniciaTramite[14].SqlValue.ToString());
                }
                
                SqlHelper.ExecuteNonQuery(Tramite_Trans, CommandType.StoredProcedure, "[Tramite].[InsertarInicio]", tramite);
                idt = Convert.ToInt32(tramite[11].SqlValue.ToString());
                if (tipocc == "AUTOMATICO")
                {
                    for (i = 0; i < Convert.ToUInt32(salarioAutomatico[0, 9].Value); i++)
                    {
                        salarioAutomaticoV[0].Value = idt;
                        salarioAutomaticoV[1].Value = salarioAutomatico[i, 1].Value;
                        salarioAutomaticoV[2].Value = salarioAutomatico[i, 2].Value;
                        salarioAutomaticoV[3].Value = salarioAutomatico[i, 3].Value;
                        salarioAutomaticoV[4].Value = salarioAutomatico[i, 4].Value;
                        salarioAutomaticoV[5].Value = salarioAutomatico[i, 5].Value;
                        salarioAutomaticoV[6].Value = salarioAutomatico[i, 6].Value;
                        salarioAutomaticoV[7].Value = salarioAutomatico[i, 7].Value;
                        salarioAutomaticoV[8].Value = salarioAutomatico[i, 8].Value;
                        SqlHelper.ExecuteNonQuery(Tramite_Trans, CommandType.StoredProcedure, "[Tramite].[InsertaSalario]", salarioAutomaticoV);

                    }

                    for (i = 0; i < Convert.ToUInt32(paramdatoGSalarioAutomaticoForm02[0, 10].Value); i++)
                    {
                        EmpresasalarioAutomatico[0].Value = paramdatoGSalarioAutomaticoForm02[i, 0].Value;
                        EmpresasalarioAutomatico[1].Value = paramdatoGSalarioAutomaticoForm02[i, 1].Value;
                        EmpresasalarioAutomatico[2].Value = idt;
                        EmpresasalarioAutomatico[3].Value = paramdatoGSalarioAutomaticoForm02[i, 3].Value;
                        EmpresasalarioAutomatico[4].Value = paramdatoGSalarioAutomaticoForm02[i, 4].Value;
                        EmpresasalarioAutomatico[5].Value = paramdatoGSalarioAutomaticoForm02[i, 5].Value;
                        EmpresasalarioAutomatico[6].Value = paramdatoGSalarioAutomaticoForm02[i, 6].Value;
                        EmpresasalarioAutomatico[7].Value = paramdatoGSalarioAutomaticoForm02[i, 7].Value;
                        EmpresasalarioAutomatico[8].Value = paramdatoGSalarioAutomaticoForm02[i, 8].Value;
                        EmpresasalarioAutomatico[9].Value = paramdatoGSalarioAutomaticoForm02[i, 9].Value;
                        SqlHelper.ExecuteNonQuery(Tramite_Trans, CommandType.StoredProcedure, "[Tramite].[PR_InsertEmpresaPersonaRegistro]", EmpresasalarioAutomatico);

                    }
                }
                if(tipocc=="MANUAL")
                {
                    for (i = 0; i < Convert.ToUInt32(paramdatoGRegEmpresaManual[0, 14].Value); i++)
                    {
                        EmpresaRegmanual[0].Value = paramdatoGRegEmpresaManual[i, 0].Value;
                        EmpresaRegmanual[1].Value = paramdatoGRegEmpresaManual[i, 1].Value;
                        EmpresaRegmanual[2].Value = idt;
                        EmpresaRegmanual[3].Value = paramdatoGRegEmpresaManual[i, 3].Value;
                        EmpresaRegmanual[4].Value = paramdatoGRegEmpresaManual[i, 4].Value;
                        EmpresaRegmanual[5].Value = paramdatoGRegEmpresaManual[i, 5].Value;
                        EmpresaRegmanual[6].Value = paramdatoGRegEmpresaManual[i, 6].Value;
                        EmpresaRegmanual[7].Value = paramdatoGRegEmpresaManual[i, 7].Value;
                        EmpresaRegmanual[8].Value = paramdatoGRegEmpresaManual[i, 8].Value;
                        EmpresaRegmanual[9].Value = paramdatoGRegEmpresaManual[i, 9].Value;
                        EmpresaRegmanual[10].Value = paramdatoGRegEmpresaManual[i, 10].Value;
                        EmpresaRegmanual[11].Value = paramdatoGRegEmpresaManual[i, 11].Value;
                        EmpresaRegmanual[12].Value = paramdatoGRegEmpresaManual[i, 12].Value;
                        //EmpresaRegmanual[13].Value = paramdatoGRegEmpresaManual[i, 13].Value;
                        SqlHelper.ExecuteNonQuery(Tramite_Trans, CommandType.StoredProcedure, "[Tramite].[PR_InsertEmpresaPersonaRegistro]", EmpresaRegmanual);

                    }
                }

                Tramite_Trans.Commit();
                res = Convert.ToString(idt);
            }
            catch (Exception excp1)
            {
                Tramite_Trans.Rollback();
                //throw (new Exception(excp1.Message));
                res = "Datos no fueron Guardados!!" + excp1.Message;
            }

            return res;
        }
        public string Validacion_AutomaticaDA(SqlParameter[] param)
        {
            string res = "";
            try
            {

                conexion1 con_sel = new conexion1();
                //DataSet sel_dataset = new DataSet();
                SqlHelper.ExecuteDataset(con_sel.cnxCadena, CommandType.StoredProcedure, "[Tramite].[PR_ValSalTram]", param);
                res = (param[2].SqlValue.ToString());
                return res;
            }
            catch (Exception excp1)
            {
                res = "Datos no fueron Guardados!!" + excp1.Message;
            }
            return res;
        }
        public string DA_RegistroPreRenuncia(SqlParameter[] param)
        {
            string res = "";
            conexion1 con_tran = new conexion1();
            SqlConnection conn = con_tran.openConnection(con_tran.cnxCadena);
            SqlTransaction Tramite_Trans = conn.BeginTransaction();            
            try
            {
                SqlHelper.ExecuteNonQuery(Tramite_Trans, CommandType.StoredProcedure, "[Tramite].[PR_PreReunuciaAutomatica]", param);
                Tramite_Trans.Commit();
                res = "ok";
            }
            catch (Exception excp1)
            {
                Tramite_Trans.Rollback();
                res = "Datos no fueron Guardados!!" + excp1.Message;
                //throw (new Exception(excp1.Message));
            }

            return res;
        }
        public string DA_ConfirmacionPreRenuncia(SqlParameter[] param)
        {
            string res = "";
            conexion1 con_tran = new conexion1();
            SqlConnection conn = con_tran.openConnection(con_tran.cnxCadena);
            SqlTransaction Tramite_Trans = conn.BeginTransaction();
            try
            {
                SqlHelper.ExecuteNonQuery(Tramite_Trans, CommandType.StoredProcedure, "[Tramite].[PR_ConfReunuciaAutomatica]", param);
                Tramite_Trans.Commit();
                res = (param[5].SqlValue.ToString());
            }
            catch (Exception excp1)
            {
                Tramite_Trans.Rollback();
                //throw (new Exception(excp1.Message));
                res = "Datos no fueron Guardados!!" + excp1.Message;
            }

            return res;
        }
        //--------------------FFAA
        public DataSet DA_Datos_ffaa(SqlParameter[] lista)
        {
            try
            {

                DataSet sel_dataset = new DataSet();
                sel_dataset = SqlHelper.ExecuteDataset(cnxCadena, CommandType.StoredProcedure, "[Persona].[PR_BusquedaPersonaFFAA]", lista);
                return sel_dataset;
            }
            catch (Exception excp1)
            {
                throw (new Exception(excp1.Message));
            }


        }
        public string[] DA_InsertaTram_ffaa(string[] lista)
        {
            try
            {
                // //string res = "";
                // string[] result = new string[0];
                // //DataSet sel_dataset = new DataSet();
                //SqlHelper.ExecuteDataset(cnxCadena, CommandType.StoredProcedure, "[Tramite].[PR_InsertaInicioAutomaticoFFAA]", lista);
                // return sel_dataset;

                //string cadena = ConfigurationManager.ConnectionStrings["cnnstrD"].ConnectionString;
                SqlConnection conn = new SqlConnection(cnxCadena);
                SqlCommand cmd = new SqlCommand("Tramite.PR_InsertaInicioAutomaticoFFAA", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                if (lista[0] != "")
                    cmd.Parameters.Add("@nua", SqlDbType.VarChar, 30).Value = lista[0];
                else
                    cmd.Parameters.Add("@nua", SqlDbType.VarChar, 30).Value = DBNull.Value;

                if (lista[1] != "")
                    cmd.Parameters.Add("@matricula", SqlDbType.VarChar, 15).Value = lista[1];
                else
                    cmd.Parameters.Add("@matricula", SqlDbType.VarChar, 15).Value = DBNull.Value;

                if (lista[2] != "")
                    cmd.Parameters.Add("@idconexion", SqlDbType.VarChar, 50).Value = lista[2];
                else
                    cmd.Parameters.Add("@idconexion", SqlDbType.VarChar, 50).Value = DBNull.Value;

                if (lista[3] != "")
                    cmd.Parameters.Add("@idecivil", SqlDbType.BigInt).Value = Convert.ToInt64(lista[3]);
                else
                    cmd.Parameters.Add("@idecivil", SqlDbType.BigInt).Value = DBNull.Value;

                if (lista[4] != "")
                    cmd.Parameters.Add("@mail", SqlDbType.VarChar, 50).Value = lista[4];
                else
                    cmd.Parameters.Add("@mail", SqlDbType.VarChar, 50).Value = DBNull.Value;

                if (lista[5] != "")
                    cmd.Parameters.Add("@celular", SqlDbType.VarChar, 15).Value = lista[5];
                else
                    cmd.Parameters.Add("@celular", SqlDbType.VarChar, 15).Value = DBNull.Value;


                if (lista[6] != "")
                    cmd.Parameters.Add("@direccion", SqlDbType.VarChar, 100).Value = lista[6];
                else
                    cmd.Parameters.Add("@direccion", SqlDbType.VarChar, 100).Value = DBNull.Value;

                if (lista[7] != "")
                    cmd.Parameters.Add("@idlocalidad", SqlDbType.BigInt).Value = Convert.ToInt64(lista[7]);
                else
                    cmd.Parameters.Add("@idlocalidad", SqlDbType.BigInt).Value = DBNull.Value;

                if (lista[8] != "")
                    cmd.Parameters.Add("@telefono", SqlDbType.VarChar, 20).Value = lista[8];
                else
                    cmd.Parameters.Add("@telefono", SqlDbType.VarChar, 20).Value = DBNull.Value;

                if (lista[9] != "")
                    cmd.Parameters.Add("@opc", SqlDbType.BigInt).Value = Convert.ToInt64(lista[9]);
                else
                    cmd.Parameters.Add("@opc", SqlDbType.BigInt).Value = DBNull.Value;


                if (lista[10] != "")
                    cmd.Parameters.Add("@obsfondo", SqlDbType.VarChar, 250).Value = lista[10];
                else
                    cmd.Parameters.Add("@obsfondo", SqlDbType.VarChar, 250).Value = DBNull.Value;

                cmd.Parameters.Add("@tramite_new_manual", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;

                conn.Open();
                cmd.ExecuteNonQuery();
                string[] result = new string[1];
                result[0] = Convert.ToString(cmd.Parameters["@tramite_new_manual"].Value);

                return result;
            }
            catch (Exception excp1)
            {
                throw (new Exception(excp1.Message));
            }


        }

        public DataSet DA_ValidaDatosRepetidos(SqlParameter[] lista)
        {
            try
            {

                DataSet sel_dataset = new DataSet();
                sel_dataset = SqlHelper.ExecuteDataset(cnxCadena, CommandType.StoredProcedure, "[Tramite].[PR_VerificaPersonaInicio]", lista);
                return sel_dataset;
            }
            catch (Exception excp1)
            {
                throw (new Exception(excp1.Message));
            }


        }
        //-----------------------------end FFAA
    }
}