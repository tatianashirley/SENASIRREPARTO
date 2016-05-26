using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace SQLSPExecuterT
{
   public class ClassSPExecT
    {
        #region "Declaración de variables"

            private string w_sNombreProcedimiento;
            private bool w_RemplazarCeroPorDBNull = true;
            private bool w_RemplazarCadenaVaciaPorDBNull = true;
            private Int32 w_iValorRetornoProcedimiento = 0;
            private Int32 w_iFilasAfectadas = 0;
            private Int64 w_iIdConexion = 0;
            private string w_sOperacion = "";
            private bool w_bEstadoOK = false;
            private byte w_iNivelError = 0;
            private Int32 w_iSegsTimeout = 0; 

            private Stack<string> w_PilaMsjError = new Stack<string>();
            private System.Data.DataSet DSResultado;

            private System.Data.SqlClient.SqlConnection w_Conexion;
            private System.Data.SqlClient.SqlCommand w_ComandoSQL;
            private System.Data.SqlClient.SqlDataAdapter w_SQLDA;

        #endregion

        #region "Propiedades"

            public System.Data.DataSet p_DataSetResultado {
                get { return DSResultado; }
                set { DSResultado = value; }
            }

            public bool p_RemplazarCeroPorDBNull {
                get { return w_RemplazarCeroPorDBNull; }
                set { w_RemplazarCeroPorDBNull = value; }
            }

            public bool p_RemplazarCadenaVaciaPorDBNull {
                get { return w_RemplazarCadenaVaciaPorDBNull; }
                set { w_RemplazarCadenaVaciaPorDBNull = value; }
            }

            public Int32 p_ValorRetornoProcedimiento {
                get { return w_iValorRetornoProcedimiento; }
            }

            public bool p_bEstadoOK {
                get { return w_bEstadoOK; }
            }

            public byte p_iNivelError {
                get {
                    string sMensaje = w_PilaMsjError.Peek();
                    string[] sSeperadores1 = new string[] { "\n" };
                    string[] sSeperadores2 = new string[] { "|" };
                    string[] sArregloMensaje1;
                    string[] sArregloMensaje2;

                    if (sMensaje.Contains("#DBMS#")) {
                        w_iNivelError = 1;
                    } else if (sMensaje.Contains("#SPEXECUTER#")) {
                        w_iNivelError = 1;
                    } else if (sMensaje.Contains("#STOREDPROC#")) {
                        sMensaje = sMensaje.Replace("#STOREDPROC#", "");
                        sArregloMensaje1 = sMensaje.Split(sSeperadores1, StringSplitOptions.None);
                        string msj1 = sArregloMensaje1[0];
                        sArregloMensaje2 = msj1.Split(sSeperadores2, StringSplitOptions.None);
                        w_iNivelError = byte.Parse(sArregloMensaje2[3]);
                    }
                    return w_iNivelError;
                }
            }

            public Int32 p_SegsTimeout {
                get { return w_iSegsTimeout; }
                set { w_iSegsTimeout = value; }
            }

        #endregion

        #region "Métodos privados"

            private bool ObtieneParametros() {
                try {
                    w_ComandoSQL = new System.Data.SqlClient.SqlCommand();
                    w_ComandoSQL.Connection = w_Conexion;
                    w_ComandoSQL.CommandType = System.Data.CommandType.StoredProcedure;
                    w_ComandoSQL.CommandText = w_sNombreProcedimiento;
                    System.Data.SqlClient.SqlCommandBuilder.DeriveParameters(w_ComandoSQL);
                    return (true);
                } catch (Exception ex) {
                    w_PilaMsjError.Push("#DBMS#" + ex.Message);
                    return (false);
                }
            }

            private string AplicaFormatoMsjError(string sMensaje) {
                string sMensajeFormateado = "";
                string[] sSeperadores1 = new string[] { "\n" };
                string[] sSeperadores2 = new string[] { "|" };
                string[] sArregloMensaje1;
                string[] sArregloMensaje2;

                if (sMensaje.Contains("#DBMS#")) {
                    sMensajeFormateado = sMensaje.Replace("#DBMS#", "");
                } else if (sMensaje.Contains("#SPEXECUTER#")) {
                    sMensajeFormateado = sMensaje.Replace("#SPEXECUTER#", "");
                } else if (sMensaje.Contains("#STOREDPROC#")) {
                    sMensaje = sMensaje.Replace("#STOREDPROC#", "");
                    sArregloMensaje1 = sMensaje.Split(sSeperadores1, StringSplitOptions.None);
                    foreach (string msj1 in sArregloMensaje1) {
                        sArregloMensaje2 = msj1.Split(sSeperadores2, StringSplitOptions.None);
                        sMensajeFormateado += "Nro. Error: "  + sArregloMensaje2[0] + " ";
                        sMensajeFormateado += "Descripción: " + sArregloMensaje2[1] + " ";
                        sMensajeFormateado += "Transacción: " + sArregloMensaje2[2] + " ";
                        sMensajeFormateado += "Severidad: " + sArregloMensaje2[3] + " ";
                        sMensajeFormateado += "Procedimiento: " + sArregloMensaje2[4] + " ";
                        sMensajeFormateado += "\n";
                    }
                }
                return (sMensajeFormateado);
            }

            private bool ObtieneTimeOut(System.Data.SqlClient.SqlConnection Cnn, string sNombreProcedimiento, string sOperacion) {
                if (string.IsNullOrEmpty(w_sOperacion)) {
                    w_iSegsTimeout = 30; 
                    return (true); 
                }
                try {
                    System.Data.DataSet DSet = new System.Data.DataSet();
                    System.Data.SqlClient.SqlCommand Cmd = new System.Data.SqlClient.SqlCommand();
                    Cmd.Connection = Cnn;
                    Cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    Cmd.CommandText = "Seguridad.PR_Transaccion";
                    System.Data.SqlClient.SqlCommandBuilder.DeriveParameters(Cmd);
                    Cmd.Parameters["@s_iIdConexion"].Value = w_iIdConexion;
                    Cmd.Parameters["@s_cOperacion"].Value = 'W';
                    Cmd.Parameters["@i_sNombreProcedimiento"].Value = sNombreProcedimiento;
                    Cmd.Parameters["@i_sOperacionTrn"].Value = sOperacion;

                    using (System.Data.SqlClient.SqlDataAdapter Adpt = new System.Data.SqlClient.SqlDataAdapter(Cmd)) {
                        Adpt.Fill(DSet);
                    }

                    if (int.Parse(Cmd.Parameters["@RETURN_VALUE"].Value.ToString()) == 1) {
                        w_PilaMsjError.Push("#STOREDPROC#" + Cmd.Parameters["@o_sMensajeError"].Value.ToString());
                        w_bEstadoOK = false;
                        w_iSegsTimeout = 30;
                        return (false);
                    } else if (int.Parse(Cmd.Parameters["@RETURN_VALUE"].Value.ToString()) == 2) {
                        w_bEstadoOK = true;
                        w_iSegsTimeout = 30;
                        return (true);
                    } else {
                        if (DSet.Tables.Count > 0) {
                            if (DSet.Tables[0].Rows.Count > 0) {
                                if (Convert.IsDBNull(DSet.Tables[0].Rows[0]["SegsTimeout"])){
                                    w_iSegsTimeout = 30;
                                    return (true);
                                } else {
                                    w_iSegsTimeout = Int32.Parse(DSet.Tables[0].Rows[0]["SegsTimeout"].ToString());
                                    return (true);
                                }
                            }
                        }
                    }

                    w_iSegsTimeout = 30;
                    return (true);

                } catch (Exception ex) {
                    w_PilaMsjError.Push("#DBMS#" + ex.Message);
                    w_bEstadoOK = false;
                    w_iSegsTimeout = 30;
                    return (false);
                }
            }

        #endregion

        #region "Métodos públicos"

            public ClassSPExecT(Int64 iIdConexion, string sNombreProcedimiento, string sOperacion = "") {
                w_Conexion = new System.Data.SqlClient.SqlConnection();
                try {
                    w_iIdConexion = iIdConexion;
                    w_sOperacion = sOperacion;
                    w_Conexion.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["cnnsenarit"].ToString();
                    w_Conexion.Open();
                    w_sNombreProcedimiento = sNombreProcedimiento;
                    w_bEstadoOK = ObtieneParametros();

                    if (iIdConexion != 0) {
                        AsignarValorParametro("@s_iIdConexion", iIdConexion);
                    }

                    if (sOperacion != "") {
                        AsignarValorParametro("@s_cOperacion", sOperacion);
                    }

                    if (!ObtieneTimeOut(w_Conexion, sNombreProcedimiento, sOperacion)) {
                        w_PilaMsjError.Push("#SPEXECUTER#Existieron problemas al recuperar la definición de la transacción");
                        w_bEstadoOK = false;
                    } 
                } catch (Exception ex) {
                    w_PilaMsjError.Push("#DBMS#" + ex.Message);
                    w_PilaMsjError.Push("#SPEXECUTER#No se pudo establecer la conexión con el DBMS");
                    w_bEstadoOK = false;
                }
            }

            ~ClassSPExecT() {
                try {
                    w_Conexion.Close();
                } catch {
                    w_bEstadoOK = false;
                    return;
                }
            }

            public Boolean CerrarConexion() {
                try {
                    w_Conexion.Close();
                    return (true);
                } catch (Exception ex) {
                    w_PilaMsjError.Push("#DBMS#" + ex.Message);
                    w_bEstadoOK = false;
                    return (false);
                }                
            }

            public string ObtenerPilaMensajesError() {
                string sTodosMensajes = ""; 
                foreach (string sMensaje in w_PilaMsjError) {
                    sTodosMensajes += AplicaFormatoMsjError(sMensaje) + "\n";
                }
                if (sTodosMensajes == "") {
                    sTodosMensajes = "No existen mensajes de error";
                }
                return (sTodosMensajes);
            }

            public string ObtenerDefinicionParametros() {
                string sParametros = "";
                foreach (System.Data.SqlClient.SqlParameter prm in w_ComandoSQL.Parameters) {
                    if (Convert.IsDBNull(prm.Value) || prm.Value == null ) {
                        sParametros += prm.ParameterName + "; " + prm.SqlDbType.ToString() + "; " + prm.Size.ToString() + "; " + prm.Direction.ToString() + "; value=NULL" + "\n";
                    } else {
                        sParametros += prm.ParameterName + "; " + prm.SqlDbType.ToString() + "; " + prm.Size.ToString() + "; " + prm.Direction.ToString() + "; value=" + prm.Value.ToString() + "\n";
                    }
                }
                if (sParametros == "") {
                    sParametros = "No existen parámetros";
                }
                return (sParametros);
            }

            public Boolean AsignarValorParametro(string NombrePrametro, object Valor) {
                try {
                    if (NombrePrametro == "@s_cOperacion") {
                        w_sOperacion = (string)Valor;
                    }
                    if (NombrePrametro == "@s_iIdConexion") {
                        w_iIdConexion = Int64.Parse(Valor.ToString());
                    }
    
                    w_ComandoSQL.Parameters[NombrePrametro].Value = Valor;
                    return (true);
                } catch (Exception ex) {
                    w_PilaMsjError.Push("#DBMS#" + ex.Message);
                }
                return (false);
            }

            public Boolean ObtenerValorParametro(string NombreParametro, ref bool Valor) {
                try {
                    if (!Convert.IsDBNull(w_ComandoSQL.Parameters[NombreParametro].Value)) {
                        Valor = (bool) w_ComandoSQL.Parameters[NombreParametro].Value;
                    } else {
                        Valor = false;
                    }
                    return (true);
                } catch (Exception ex) {
                    w_PilaMsjError.Push("#DBMS#" + ex.Message);
                    w_bEstadoOK = false;
                }
                return (false);
            }
    
            public Boolean ObtenerValorParametro(string NombreParametro,ref byte Valor) {
                try {
                    if (!Convert.IsDBNull(w_ComandoSQL.Parameters[NombreParametro].Value)) {
                        Valor = (byte)w_ComandoSQL.Parameters[NombreParametro].Value;
                    } else {
                        Valor = 0; 
                    }
                    return (true);
                } catch (Exception ex) {
                    w_PilaMsjError.Push("#DBMS#" + ex.Message);
                    w_bEstadoOK = false;
                }
                return (false);
            }

            public Boolean ObtenerValorParametro(string NombreParametro,ref Int16 Valor) {
                try {
                    if (!Convert.IsDBNull(w_ComandoSQL.Parameters[NombreParametro].Value)) {
                        Valor = (Int16)w_ComandoSQL.Parameters[NombreParametro].Value;
                    } else {
                        Valor = 0; 
                    }
                    return (true);
                } catch (Exception ex) {
                    w_PilaMsjError.Push("#DBMS#" + ex.Message);
                    w_bEstadoOK = false;
                }
                return (false);
            }

            public Boolean ObtenerValorParametro(string NombreParametro,ref Int32 Valor) {
                try {
                    if (!Convert.IsDBNull(w_ComandoSQL.Parameters[NombreParametro].Value)) {
                        Valor = (Int32)w_ComandoSQL.Parameters[NombreParametro].Value;
                    } else {
                        Valor = 0;
                    }
                    return (true);
                } catch (Exception ex) {
                    w_PilaMsjError.Push("#DBMS#" + ex.Message);
                    w_bEstadoOK = false;
                }
                return (false);
            }

            public Boolean ObtenerValorParametro(string NombreParametro,ref Int64 Valor) {
                try {
                    if (!Convert.IsDBNull(w_ComandoSQL.Parameters[NombreParametro].Value)) {
                        Valor = (Int64)w_ComandoSQL.Parameters[NombreParametro].Value;
                    } else {
                        Valor = 0;
                    }
                    return (true);
                } catch (Exception ex) {
                    w_PilaMsjError.Push("#DBMS#" + ex.Message);
                    w_bEstadoOK = false;
                }
                return (false);
            }

            public Boolean ObtenerValorParametro(string NombreParametro, ref decimal Valor) {
                try {
                    if (!Convert.IsDBNull(w_ComandoSQL.Parameters[NombreParametro].Value)) {
                        Valor = (decimal)w_ComandoSQL.Parameters[NombreParametro].Value;
                    } else {
                        Valor = 0;
                    }
                    return (true);
                } catch (Exception ex) {
                    w_PilaMsjError.Push("#DBMS#" + ex.Message);
                    w_bEstadoOK = false;
                }
                return (false);
            }

            public Boolean ObtenerValorParametro(string NombreParametro, ref double Valor) {
                try {
                    if (!Convert.IsDBNull(w_ComandoSQL.Parameters[NombreParametro].Value)) {
                        Valor = (double)w_ComandoSQL.Parameters[NombreParametro].Value;
                    } else {
                        Valor = 0;
                    }
                    return (true);
                } catch (Exception ex) {
                    w_PilaMsjError.Push("#DBMS#" + ex.Message);
                    w_bEstadoOK = false;
                }
                return (false);
            }

            public Boolean ObtenerValorParametro(string NombreParametro, ref DateTime Valor) {
                try {
                    if (!Convert.IsDBNull(w_ComandoSQL.Parameters[NombreParametro].Value)) {
                        Valor = (DateTime)w_ComandoSQL.Parameters[NombreParametro].Value;
                    } else {
                        Valor = DateTime.Parse( "01/01/1900");
                    }
                }
                catch (Exception ex) {
                    w_PilaMsjError.Push("#DBMS#" + ex.Message);
                    w_bEstadoOK = false;
                }
                return (false);
            }

            public Boolean ObtenerValorParametro(string NombreParametro, ref string Valor) {
                try {
                    if (!Convert.IsDBNull(w_ComandoSQL.Parameters[NombreParametro].Value)) {
                        Valor = w_ComandoSQL.Parameters[NombreParametro].Value.ToString();
                    } else {
                        Valor = "";
                    }
                } catch (Exception ex) {
                    w_PilaMsjError.Push("#DBMS#" + ex.Message);
                    w_bEstadoOK = false;
                }
                return (false);
            }

            // Ejecuta un procedimiento que devuelve un conjunto de resutados
            public Boolean EjecutarProcedimientoQry() {
                try {
                    foreach (System.Data.SqlClient.SqlParameter prm in w_ComandoSQL.Parameters) {
                        if (prm.Direction.ToString().ToLower() != "returnvalue") {
                            if (prm.SqlDbType.ToString().ToLower() == "varchar" || prm.SqlDbType.ToString().ToLower() == "char") {
                                if (!Convert.IsDBNull(prm.Value) && prm.Value != null) {
                                    if (w_RemplazarCadenaVaciaPorDBNull && String.IsNullOrEmpty((string) prm.Value)) {
                                        prm.Value = DBNull.Value;
                                    }
                                }
                            } else if (prm.SqlDbType.ToString().ToLower() == "bigint" || prm.SqlDbType.ToString().ToLower() == "int" || prm.SqlDbType.ToString().ToLower() == "smallint" || prm.SqlDbType.ToString().ToLower() == "tinyint" || prm.SqlDbType.ToString().ToLower() == "money" || prm.SqlDbType.ToString().ToLower() == "float") {
                                if (!Convert.IsDBNull(prm.Value) && prm.Value != null) {
                                    if (w_RemplazarCeroPorDBNull && Int64.Parse(prm.Value.ToString()) == 0) {
                                        prm.Value = DBNull.Value;
                                    }
                                }
                            } else if (!(prm.SqlDbType.ToString().ToLower() == "date" || prm.SqlDbType.ToString().ToLower() == "datetime" || prm.SqlDbType.ToString().ToLower() == "varbinary" || prm.SqlDbType.ToString().ToLower() == "binary" || prm.SqlDbType.ToString().ToLower() == "bit")) {
                                w_PilaMsjError.Push("#SPEXECUTER#El tipo de dato del parámetro especificado es desconocido");
                                w_bEstadoOK = false;
                                return (false);
                            }
                        }
                    } // end foreach 

                    w_ComandoSQL.CommandTimeout = w_iSegsTimeout;
                    w_SQLDA = new System.Data.SqlClient.SqlDataAdapter();
                    DSResultado = new System.Data.DataSet();
                    w_SQLDA.SelectCommand = w_ComandoSQL;
                    w_SQLDA.Fill( DSResultado);

                    // Captura de errores
                    w_iValorRetornoProcedimiento = int.Parse(w_ComandoSQL.Parameters["@RETURN_VALUE"].Value.ToString());
                    if (w_iValorRetornoProcedimiento != 0) {
                        w_PilaMsjError.Push("#STOREDPROC#" + w_ComandoSQL.Parameters["@o_sMensajeError"].Value.ToString());
                        w_bEstadoOK = false;
                        return (false);
                    }
                    return (true);
                } catch (System.Data.SqlClient.SqlException XcpSQL) {
                    for (Int32 i = 0; i <= XcpSQL.Errors.Count - 1; i++ ) {
                        w_PilaMsjError.Push("#DBMS#" + XcpSQL.Message);
                    }
                    w_bEstadoOK = false;
                }
                w_bEstadoOK = false;
                return (false);
            }

            // Ejecuta un procedimiento que NO devuelve un conjunto de resutados
            public Boolean EjecutarProcedimientoNonQry() {
                try {
                    foreach (System.Data.SqlClient.SqlParameter prm in w_ComandoSQL.Parameters) {
                        if (prm.Direction.ToString().ToLower() != "returnvalue") {
                            if (prm.SqlDbType.ToString().ToLower() == "varchar" || prm.SqlDbType.ToString().ToLower() == "char") {
                                if (!Convert.IsDBNull(prm.Value) && prm.Value != null) {
                                    if (w_RemplazarCadenaVaciaPorDBNull && String.IsNullOrEmpty((string)prm.Value)) {
                                        prm.Value = DBNull.Value;
                                    }
                                }
                            } else if (prm.SqlDbType.ToString().ToLower() == "bigint" || prm.SqlDbType.ToString().ToLower() == "int" || prm.SqlDbType.ToString().ToLower() == "smallint" || prm.SqlDbType.ToString().ToLower() == "tinyint" || prm.SqlDbType.ToString().ToLower() == "money" || prm.SqlDbType.ToString().ToLower() == "float") {
                                if (!Convert.IsDBNull(prm.Value) && prm.Value != null) {
                                    if (w_RemplazarCeroPorDBNull && Int64.Parse(prm.Value.ToString()) == 0) {
                                        prm.Value = DBNull.Value;
                                    }
                                }
                            } else if (!(prm.SqlDbType.ToString().ToLower() == "date" || prm.SqlDbType.ToString().ToLower() == "datetime" || prm.SqlDbType.ToString().ToLower() == "varbinary" || prm.SqlDbType.ToString().ToLower() == "binary" || prm.SqlDbType.ToString().ToLower() == "bit")) {
                                w_PilaMsjError.Push("#SPEXECUTER#" + "El tipo de dato del parámetro especificado es desconocido");
                                w_bEstadoOK = false;
                                return (false);
                            }
                        }
                    } // end foreach 

                    w_ComandoSQL.CommandTimeout = w_iSegsTimeout;
                    w_iFilasAfectadas = w_ComandoSQL.ExecuteNonQuery();

                    // Captura de errores
                    w_iValorRetornoProcedimiento = int.Parse(w_ComandoSQL.Parameters["@RETURN_VALUE"].Value.ToString());
                    if (w_iValorRetornoProcedimiento != 0) {
                        w_PilaMsjError.Push("#STOREDPROC#" + w_ComandoSQL.Parameters["@o_sMensajeError"].Value.ToString());
                        w_bEstadoOK = false;
                        return (false);
                    }
                    return (true);
                } catch (System.Data.SqlClient.SqlException XcpSQL) {
                    for (Int32 i = 0; i <= XcpSQL.Errors.Count - 1; i++) {
                        w_PilaMsjError.Push("#DBMS#" + XcpSQL.Message);
                    }
                }
                w_bEstadoOK = false;
                return (false);
            }
        #endregion 

    }
}
