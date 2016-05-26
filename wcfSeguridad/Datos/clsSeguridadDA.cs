using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Configuration;
using System.Reflection;



using System.Globalization;
using System.Text;
using System.Xml;

using System.Resources;
using SQLSPExecuter;


namespace wcfSeguridad.Datos
{
    public class clsSeguridadDA
    {
         Database db = null;
         Int32 iIdConexion = 0;
         string sMensajeError = "";

         public clsSeguridadDA()
        {
            db = DatabaseFactory.CreateDatabase("cnnsenarit");
        }
        SqlConnection xconSenarit = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnsenarit"].ConnectionString.ToString());
        
    #region MODULO SEGURIDAD Y CONEXION DEL USUARIO
      
            public DataTable privilegiosUsuario(string nick)
            {
                try
                {
                    xconSenarit.Open();
                    DataTable dt = new DataTable();
                    SqlDataAdapter adap = new SqlDataAdapter("Seguridad.PR_ObtenerUsuarioLogin", xconSenarit);
                    adap.SelectCommand.CommandType = CommandType.StoredProcedure;
                    
                    adap.SelectCommand.Parameters.Add("@CuentaUsuario", SqlDbType.VarChar).Value = nick;
                    adap.Fill(dt);
                    xconSenarit.Close();
                    return dt;                 

                }
                catch
                {
                    xconSenarit.Close();
                    return null;

                }
            }
            public DataTable menuprivilegiosUsuario(int IdConexion, string Operacion, string SesionTrabajo, string SSN)
            {
                try
                {
                    //xconSenarit.Close();
                    xconSenarit.Open();
                    DataTable dt = new DataTable();
                    //SqlDataAdapter adap = new SqlDataAdapter("Seguridad.PR_MenuPrivilegiosUsuario", xconSenarit);
                    SqlDataAdapter adap = new SqlDataAdapter("Seguridad.PR_Menu", xconSenarit);
                    adap.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adap.SelectCommand.Parameters.Add("@s_iIdConexion", SqlDbType.VarChar).Value = IdConexion;
                    adap.SelectCommand.Parameters.Add("@s_cOperacion", SqlDbType.VarChar).Value = Operacion;
                    //adap.SelectCommand.Parameters.Add("@s_iSesionTrabajo", SqlDbType.VarChar).Value = SesionTrabajo;
                    //adap.SelectCommand.Parameters.Add("@s_sSSN", SqlDbType.VarChar).Value = SSN;
                    //adap.SelectCommand.Parameters.Add("@IdUser", SqlDbType.VarChar).Value = IdUser;
                    //adap.SelectCommand.Parameters.Add("@IdOficina", SqlDbType.VarChar).Value = IdOficina;
                    //adap.SelectCommand.Parameters.Add("@IdRol", SqlDbType.VarChar).Value = IdRol;
                    adap.Fill(dt);
                    xconSenarit.Close();
                    return dt;
                }
                catch
                {
                    xconSenarit.Close();
                    return null;

                }
            }
            public DataTable ListaOficinasUsuario(int IdUser)
            {
                try
                {
                    xconSenarit.Open();
                    DataTable dt = new DataTable();
                    SqlDataAdapter adap = new SqlDataAdapter("Seguridad.PR_ListaOficinasUsuario", xconSenarit);
                    adap.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adap.SelectCommand.Parameters.Add("@IdUser", SqlDbType.Int).Value = IdUser;
                    adap.Fill(dt);
                    xconSenarit.Close();
                    return dt;
                }
                catch
                {
                    xconSenarit.Close();
                    return null;

                }

            }
            public DataTable ListaModulosUsuario(int IdUser)
            {
                try
                {
                    xconSenarit.Open();
                    DataTable dt = new DataTable();
                    SqlDataAdapter adap = new SqlDataAdapter("Seguridad.PR_ListaModulosUsuario", xconSenarit);
                    adap.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adap.SelectCommand.Parameters.Add("@IdUser", SqlDbType.Int).Value = IdUser;
                    adap.Fill(dt);
                    xconSenarit.Close();
                    return dt;
                }
                catch
                {
                    xconSenarit.Close();
                    return null;

                }

            }
            public DataTable ListaRolesUsuario(int IdUser, int IdOficina)
            {
                try
                {
                    xconSenarit.Open();
                    DataTable dt = new DataTable();
                    SqlDataAdapter adap = new SqlDataAdapter("Seguridad.PR_ListaRolesUsuario", xconSenarit);
                    adap.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adap.SelectCommand.Parameters.Add("@IdUser", SqlDbType.Int).Value = IdUser;
                    adap.SelectCommand.Parameters.Add("@IdOficina", SqlDbType.Int).Value = IdOficina;
                    adap.Fill(dt);
                    xconSenarit.Close();
                    return dt;
                }
                catch
                {
                    xconSenarit.Close();
                    return null;

                }
            }
            public DataTable ListaProcedimientoconParametro(int IdModulo)
            {
                try
                {
                    xconSenarit.Open();
                    DataTable dt = new DataTable();
                    SqlDataAdapter adap = new SqlDataAdapter("Seguridad.PR_ListaProcedimiento", xconSenarit);
                    adap.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adap.SelectCommand.Parameters.Add("@i_iIdModulo", SqlDbType.Int).Value = IdModulo;                    
                    adap.Fill(dt);
                    xconSenarit.Close();
                    return dt;
                }
                catch
                {
                    xconSenarit.Close();
                    return null;

                }
            }

            public Int32 Conexion(string iIdConexion, string sOperacion, string sSSN,string NombreEstacion,string IpAddres,string MacAddress, int iIdUsuario, string sCuentaUsuario, int iIdRol, int iIdOficina, int iIdModulo)
            {
                xconSenarit.Open();
                SqlCommand cmd = new SqlCommand("Seguridad.PR_Conexion", xconSenarit);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter IdConexion = new SqlParameter("@o_iIdConexion", SqlDbType.Int);
                IdConexion.Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@i_iIdConexion", SqlDbType.VarChar).Value = iIdConexion;
                cmd.Parameters.Add("@i_cOperacion", SqlDbType.VarChar).Value = sOperacion;
                cmd.Parameters.Add("@i_sSSN", SqlDbType.VarChar).Value = sSSN;
                //cmd.Parameters.Add("@i_iIdEstacion", SqlDbType.VarChar).Value = iIdEstacion;
                cmd.Parameters.Add("@i_sNombreEstacion", SqlDbType.VarChar).Value = NombreEstacion;
                cmd.Parameters.Add("@i_sIPAddress", SqlDbType.VarChar).Value = IpAddres;
                cmd.Parameters.Add("@i_sMACAddress", SqlDbType.VarChar).Value = MacAddress;
                cmd.Parameters.Add("@i_iIdUsuario", SqlDbType.Int).Value = iIdUsuario;
                cmd.Parameters.Add("@i_sCuentaUsuario", SqlDbType.VarChar).Value = sCuentaUsuario;
                cmd.Parameters.Add("@i_iIdRol", SqlDbType.Int).Value = iIdRol;
                cmd.Parameters.Add("@i_iIdOficina", SqlDbType.Int).Value = iIdOficina;
                cmd.Parameters.Add("@i_iIdModulo", SqlDbType.Int).Value = iIdModulo;
                cmd.Parameters.Add(IdConexion);

                int rowsAffected = cmd.ExecuteNonQuery();
                xconSenarit.Close();
                return Convert.ToInt32(cmd.Parameters["@o_iIdConexion"].Value);
            }
            public Int32 HabilitaTransaccion(String iIdConexion, string Operacion, string iSesionTrabajo, string sSSN, string iIdRol, int IdTransaccion)
            {
                xconSenarit.Open();
                SqlCommand cmd = new SqlCommand("Seguridad.PR_TransaccionAutorizada", xconSenarit);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter AutorizaTransaccion = new SqlParameter("@o_bTrnAutorizadaOK", SqlDbType.Int);
                AutorizaTransaccion.Direction = ParameterDirection.Output;

                cmd.Parameters.Add("@s_iIdConexion", SqlDbType.VarChar).Value = iIdConexion;
                cmd.Parameters.Add("@s_cOperacion", SqlDbType.VarChar).Value = Operacion;
                cmd.Parameters.Add("@s_iSesionTrabajo", SqlDbType.VarChar).Value = sSSN;
                cmd.Parameters.Add("@s_sSSN", SqlDbType.VarChar).Value = sSSN;
                cmd.Parameters.Add("@i_iIdRol", SqlDbType.Int).Value = iIdRol;
                cmd.Parameters.Add("@i_iIdTransaccion", SqlDbType.Int).Value = IdTransaccion;

                cmd.Parameters.Add(AutorizaTransaccion);

                int rowsAffected = cmd.ExecuteNonQuery();
                xconSenarit.Close();
                return Convert.ToInt32(cmd.Parameters["@o_bTrnAutorizadaOK"].Value);
            }
            public void CerrarConexion(int iIdConexion, string sOperacion)
            {
                try
                {
                    xconSenarit.Open();
                    SqlDataAdapter adap = new SqlDataAdapter("Seguridad.PR_Conexion", xconSenarit);
                    adap.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adap.SelectCommand.Parameters.Add("@i_iIdConexion", SqlDbType.VarChar).Value = iIdConexion;
                    adap.SelectCommand.Parameters.Add("@i_cOperacion", SqlDbType.VarChar).Value = sOperacion;
                    adap.SelectCommand.ExecuteNonQuery();
                    xconSenarit.Close();
                }
                catch (SqlException ex)
                {
                    xconSenarit.Close();
                    System.Console.Write("error........." + ex);

                }
            }
            public Int32 PermisosUrl(int IdConexion, string URL)
            {
                int Semaforo = 0;
                DbCommand cmd = db.GetStoredProcCommand("Seguridad.PR_PermisosUrl", IdConexion, URL, Semaforo);
                db.ExecuteReader(cmd);
                Semaforo = Convert.ToInt32(db.GetParameterValue(cmd, "@Semaforo"));
                return Semaforo;

            }
    #endregion
    #region MODULO USUARIO
           //public DataTable BusquedaUsuarioRRHH(int iCi)
           // {
           //     try
           //     {
           //         xconSenarit.Open();
           //         DataTable dt = new DataTable();
           //         SqlDataAdapter adap = new SqlDataAdapter("Seguridad.PR_ListaUsuariosRRHH", xconSenarit);
           //         adap.SelectCommand.CommandType = CommandType.StoredProcedure;
           //         adap.SelectCommand.Parameters.Add("@i_iCi", SqlDbType.Int).Value = iCi;
           //         adap.Fill(dt);
           //         xconSenarit.Close();
           //         return dt;

           //     }
           //     catch
           //     {
           //         return null;
           //     }
           // }
            //public DataTable ContarUsuario()
            //{
            //    try
            //    {
            //        xconSenarit.Open();
            //        DataTable dt = new DataTable();
            //        SqlDataAdapter adap = new SqlDataAdapter("Seguridad.PR_ContarUsuarios", xconSenarit);
            //        adap.SelectCommand.CommandType = CommandType.StoredProcedure;

            //        adap.Fill(dt);
            //        xconSenarit.Close();
            //        return dt;
            //    }
            //    catch
            //    {
            //        xconSenarit.Close();
            //        return null;

            //    }
            //}
            //public DataTable ListarUsuariosV(int Pagina, int Rango)
            //{
            //    try
            //    {
            //        xconSenarit.Open();
            //        DataTable dt = new DataTable();
            //        SqlDataAdapter adap = new SqlDataAdapter("Seguridad.PR_ListarUsuariosV", xconSenarit);
            //        adap.SelectCommand.CommandType = CommandType.StoredProcedure;
            //        adap.SelectCommand.Parameters.Add("@Pagina", SqlDbType.Int).Value = Pagina;
            //        adap.SelectCommand.Parameters.Add("@Rango", SqlDbType.Int).Value = Rango;

            //        adap.Fill(dt);
            //        xconSenarit.Close();
            //        return dt;
            //    }
            //    catch
            //    {
            //        xconSenarit.Close();
            //        return null;

            //    }
            //}
            //public DataTable ObtenerUsuarioV(int CodUsuario)
            //{
            //    try
            //    {
            //        xconSenarit.Open();
            //        DataTable dt = new DataTable();
            //        SqlDataAdapter adap = new SqlDataAdapter("Seguridad.PR_ObtenerUsuarioV", xconSenarit);
            //        adap.SelectCommand.CommandType = CommandType.StoredProcedure;
            //        adap.SelectCommand.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = CodUsuario;

            //        adap.Fill(dt);
            //        xconSenarit.Close();
            //        return dt;
            //    }
            //    catch
            //    {
            //        xconSenarit.Close();
            //        return null;

            //    }

            //}
            //public void ModificarUsuario(int CodUsuario, int IdEstado)
            //{
            //    try
            //    {
            //        xconSenarit.Open();
            //        SqlDataAdapter adap = new SqlDataAdapter("Seguridad.PR_ModificarUsuario", xconSenarit);
            //        adap.SelectCommand.CommandType = CommandType.StoredProcedure;
            //        adap.SelectCommand.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = CodUsuario;
            //        adap.SelectCommand.Parameters.Add("@IdEstado", SqlDbType.Int).Value = IdEstado;
            //        adap.SelectCommand.ExecuteNonQuery();
            //        xconSenarit.Close();
            //    }
            //    catch (SqlException ex)
            //    {
            //        xconSenarit.Close();
            //        System.Console.Write("error........." + ex);

            //    }
            //}
            //public void EliminarUsuario(int CodUsuario)
            //{
            //    try
            //    {
            //        xconSenarit.Open();
            //        SqlDataAdapter adap = new SqlDataAdapter("Seguridad.PR_EliminarUsuario", xconSenarit);
            //        adap.SelectCommand.CommandType = CommandType.StoredProcedure;
            //        adap.SelectCommand.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = CodUsuario;
            //        adap.SelectCommand.ExecuteNonQuery();
            //        xconSenarit.Close();
            //    }
            //    catch (SqlException ex)
            //    {
            //        xconSenarit.Close();
            //        System.Console.Write("error........." + ex);

            //    }
            //}
            public DataTable BusquedaUsuario(String Parametro, int Opcion)
            {
                try
                {
                    xconSenarit.Open();
                    DataTable dt = new DataTable();
                    SqlDataAdapter adap = new SqlDataAdapter("Seguridad.PR_BusquedaUsuario", xconSenarit);
                    adap.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adap.SelectCommand.Parameters.Add("@Parametro", SqlDbType.VarChar).Value = Parametro;
                    adap.SelectCommand.Parameters.Add("@Opcion", SqlDbType.Int).Value = Opcion;
                    adap.Fill(dt);
                    xconSenarit.Close();
                    return dt;
                }
                catch
                {
                    xconSenarit.Close();
                    return null;

                }
            }
            public IDataReader UsuarioLista(string Operacion,string Usuario,string LoginUsuario)
            {
                DbCommand cmd = db.GetStoredProcCommand("Seguridad.PR_UsuarioLista",Operacion,Usuario,LoginUsuario);
                IDataReader dataReader = db.ExecuteReader(cmd);
                return dataReader;
            }
            public IDataReader UsuarioListaModuloRol(int IdUsuario)
            {
                DbCommand cmd = db.GetStoredProcCommand("Seguridad.PR_UsuarioListaModuloRol", IdUsuario);
                IDataReader dataReader = db.ExecuteReader(cmd);
                return dataReader;
            }
            public bool UsuarioObtenerId(int iIdConexion, string cOperacion,int iIdUsuario, int Carnet, string ClaveUsuario, int IdOficina, int IdArea, ref int IdUsuario, ref string sMensajeError)
            {
                ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Seguridad.PR_UsuarioAsignacion", cOperacion);
                if (!ObjSPExec.p_bEstadoOK)
                {
                    sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                }
                else
                {
                    bool bAsignacionOK = true;
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iCarnet", Carnet);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sCuentaUsuario", ClaveUsuario);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdOficina", IdOficina);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdArea", IdArea);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdUsuario", iIdUsuario);
                    
                    
                    
                    if (bAsignacionOK)
                    {
                        if (!ObjSPExec.EjecutarProcedimientoNonQry())
                        {
                            sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                        }
                        else
                        {
                            
                            //ObjSPExec.ObtenerValorParametro("@o_iIdUsuario",ref IdUsuario);
                            IdUsuario = Convert.ToInt32(iIdUsuario);
                        }

                    }
                }
                return (ObjSPExec.p_bEstadoOK);
            }
      
            public bool UsuarioRol(int iIdConexion, string cOperacion, int IdRol, int IdUsuario,string sFechaExpiracion, ref string sMensajeError)
            {
                ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Seguridad.PR_RolUsuario", cOperacion);
                if (!ObjSPExec.p_bEstadoOK)
                {
                    sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                }
                else
                {
                    bool bAsignacionOK = true;
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdRol", IdRol);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdUsuario", IdUsuario);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fFechaExpiracion", sFechaExpiracion);



                    if (bAsignacionOK)
                    {
                        if (!ObjSPExec.EjecutarProcedimientoNonQry())
                        {
                            sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                        }
                    }
                }
                return (ObjSPExec.p_bEstadoOK);

            }


            public bool UsuarioRestauraPassword(int iIdConexion, string cOperacion, string sSessionTrabajo, string sSNN, int iIdUsuario, string sClaveUsuario, ref string sMensajeError)
            {
                ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Seguridad.PR_Usuario", cOperacion);
                if (!ObjSPExec.p_bEstadoOK)
                {
                    sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                }
                else
                {
                    bool bAsignacionOK = true;
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);                    
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sClaveUsuario", sClaveUsuario);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdUsuario", iIdUsuario);



                    if (bAsignacionOK)
                    {
                        if (!ObjSPExec.EjecutarProcedimientoNonQry())
                        {
                            sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                        }
                    }
                }
                return (ObjSPExec.p_bEstadoOK);

            }
            public bool UsuarioRolBaja(int iIdConexion, string cOperacion, string sSessionTrabajo, string sSNN,int iIdRolUsuario, int iIdRol, int iIdUsuario, ref string sMensajeError)
            {
                ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Seguridad.PR_RolUsuario", cOperacion);
                if (!ObjSPExec.p_bEstadoOK)
                {
                    sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                }
                else
                {
                    bool bAsignacionOK = true;
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdRolUsuario", iIdRolUsuario);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdRol", iIdRol);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdUsuario", iIdUsuario);



                    if (bAsignacionOK)
                    {
                        if (!ObjSPExec.EjecutarProcedimientoNonQry())
                        {
                            sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                        }
                    }
                }
                return (ObjSPExec.p_bEstadoOK);

            }
            public bool UsuarioSa(int iIdUsuario)
            {
                string Mensaje = null;
                DbCommand cmd = db.GetStoredProcCommand("Seguridad.PR_UsuarioSA", iIdUsuario, Mensaje);
                db.ExecuteReader(cmd);
                Mensaje = Convert.ToString(db.GetParameterValue(cmd, "@o_sMensajeError"));
                if (Mensaje == "1")
                {
                    return true;
                }
                {
                    return false;
                }

            }
            #endregion
    #region ROL
            public DataTable ListaOficinas()
            {
                try
                {
                    xconSenarit.Open();
                    DataTable dt = new DataTable();
                    SqlDataAdapter adap = new SqlDataAdapter("Seguridad.PR_ListaOficinas", xconSenarit);
                    adap.SelectCommand.CommandType = CommandType.StoredProcedure;                
                    adap.Fill(dt);
                    xconSenarit.Close();
                    return dt;
                }
                catch
                {
                    xconSenarit.Close();
                    return null;

                }
            }
            public DataTable ListaAreas(int IdOficina)
            {
                try
                {
                    xconSenarit.Open();
                    DataTable dt = new DataTable();
                    SqlDataAdapter adap = new SqlDataAdapter("Seguridad.PR_ListaAreas", xconSenarit);
                    adap.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adap.SelectCommand.Parameters.Add("@i_iIdOficina", SqlDbType.VarChar).Value = IdOficina;
                    adap.Fill(dt);
                    xconSenarit.Close();
                    return dt;
                }
                catch
                {
                    xconSenarit.Close();
                    return null;

                }
            }
            public IDataReader ListaRol()
            {
                DbCommand cmd = db.GetStoredProcCommand("Seguridad.PR_RolLista");
                IDataReader dataReader = db.ExecuteReader(cmd);
                return dataReader;
            }
            public bool ListaRolActualizar(int iIdConexion,string cOperacion,string sSessionTrabajo,string sSNN,int IdRol,string sIdTransaccion,string sIdMenuSuperior,ref DataSet DSetTmp)
            {
                ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Seguridad.PR_RolTransaccionAutorizada", cOperacion);
                if (!ObjSPExec.p_bEstadoOK)
                {
                    sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                }
                else
                {
                    bool bAsignacionOK = true;
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdRol", IdRol);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdMenuSuperior", sIdMenuSuperior);
                    
                    
                    if (bAsignacionOK)
                    {
                        if (!ObjSPExec.EjecutarProcedimientoQry())
                        {
                            sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                        }
                        else
                        {
                            DSetTmp = ObjSPExec.p_DataSetResultado;
                        }
                    }
                }
                return (ObjSPExec.p_bEstadoOK);
            }
            public bool TransaccionAutorizadaElimina(int iIdConexion, string cOperacion, string sSessionTrabajo, string sSNN, int iIdRol, int iIdTransaccion, string sIdMenuSuperior, ref string sMensajeError)
            {
                ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Seguridad.PR_RolTransaccionAutorizada", cOperacion);
                if (!ObjSPExec.p_bEstadoOK)
                {
                    sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                }
                else
                {
                    bool bAsignacionOK = true;
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdRol", iIdRol);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTransaccion", iIdTransaccion);
                    
                    

                    if (bAsignacionOK)
                    {
                        if (!ObjSPExec.EjecutarProcedimientoNonQry())
                        {
                            sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                        }
                    }
                }
                return (ObjSPExec.p_bEstadoOK);

            }
            public bool TransaccionAutorizadaInserta(int iIdConexion, string cOperacion, string sSessionTrabajo, string sSNN, int iIdRol, int iIdTransaccion,  ref string sMensajeError)
            {
                ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Seguridad.PR_RolTransaccionAutorizada", cOperacion);
                if (!ObjSPExec.p_bEstadoOK)
                {
                    sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                }
                else
                {
                    bool bAsignacionOK = true;
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdRol", iIdRol);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTransaccion", iIdTransaccion);

                    if (bAsignacionOK)
                    {
                        if (!ObjSPExec.EjecutarProcedimientoNonQry())
                        {
                            sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                        }
                    }
                }
                return (ObjSPExec.p_bEstadoOK);

            }

            public IDataReader ListaRolconParametro(int IdModulo)
            {
                DbCommand cmd = db.GetStoredProcCommand("Seguridad.PR_RolListaconParametro",IdModulo);
                IDataReader dataReader = db.ExecuteReader(cmd);
                return dataReader;
            }
            //public void InsertarRol(string DetalleRol, int IdModulo, int IdEstado,int IdMenuSuperior,out int IdRol,out string Mensaje)
            //{
            //    Mensaje = null;
            //    IdRol = 0;
            //    DbCommand cmd = db.GetStoredProcCommand("Seguridad.PR_RolInserta", DetalleRol, IdModulo, IdEstado, IdMenuSuperior, IdRol, Mensaje);
            //    db.ExecuteReader(cmd);
            //    IdRol = Convert.ToInt32(db.GetParameterValue(cmd, "@o_iIdRol"));
            //    Mensaje = Convert.ToString(db.GetParameterValue(cmd, "@o_sMensajeError"));
            //}
            public bool InsertarRol(int iIdConexion, string cOperacion, string DetalleRol, int iIdModulo, int iIdEstado, int IdMenuSuperior,string DetRol, ref int iIdRol, ref string sMensajeError)
            {
                ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Seguridad.PR_Rol", cOperacion);
                if (!ObjSPExec.p_bEstadoOK)
                {
                    sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                }
                else
                {
                    bool bAsignacionOK = true;
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sDescripcion", DetalleRol);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdModulo", iIdModulo);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdEstado", iIdEstado);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdMenuSuperior", IdMenuSuperior);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sComentarios", DetRol);

                    if (bAsignacionOK)
                    {
                        if (!ObjSPExec.EjecutarProcedimientoNonQry())
                        {
                            sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                        }
                        else
                        {
                            //ObjSPExec.ObtenerValorParametro("@o_iIdRol", ref iIdRol);
                        }
                    }
                }
                return (ObjSPExec.p_bEstadoOK);
            }
            public bool RolActualiza(int iIdConexion, string cOperacion, string sSessionTrabajo, string sSNN, int iIdRol, string sDetalleRol, int iIdModulo, int iIdEstadoRol,string sDetRol, ref String sMensajeError)
            {
                ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Seguridad.PR_Rol", cOperacion);
                if (!ObjSPExec.p_bEstadoOK)
                {
                    sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                }
                else
                {
                    bool bAsignacionOK = true;
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdRol", iIdRol);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sDescripcion", sDetalleRol);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdModulo", iIdModulo);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdEstado", iIdEstadoRol);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sComentarios", sDetRol);

                    if (bAsignacionOK)
                    {
                        if (!ObjSPExec.EjecutarProcedimientoNonQry())
                        {
                            sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                        }
                    }
                }
                return (ObjSPExec.p_bEstadoOK);

            }

        
 
            public bool InsertarTransaccionAutorizada(int iIdConexion, string cOperacion, int iIdRol, int CodTransaccion,ref string sMensajeError)
            {
                ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Seguridad.PR_TransaccionAutorizada", cOperacion);
                if (!ObjSPExec.p_bEstadoOK)
                {
                    sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                }
                else
                {
                    bool bAsignacionOK = true;
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdRol", iIdRol);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTransaccion", CodTransaccion);
                    

                    if (bAsignacionOK)
                    {
                        if (!ObjSPExec.EjecutarProcedimientoNonQry())
                        {
                            sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                        }
                    }
                }
                return (ObjSPExec.p_bEstadoOK);

            }

    #endregion
    #region MODULOS
        
              
                public bool InsertarModulo(int iIdConexion, string cOperacion, string sDetalleModulo, string sAbreviatura, int iTipo, ref string sMensajeError)
                {
                    ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Seguridad.PR_Modulo", cOperacion);
                    if (!ObjSPExec.p_bEstadoOK)
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                    else
                    {
                        bool bAsignacionOK = true;
                        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);                        
                        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sDescripcionModulo", sDetalleModulo);
                        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sSiglaModulo", sAbreviatura);
                        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iTipo", iTipo);
                        

                        if (bAsignacionOK)
                        {
                            if (!ObjSPExec.EjecutarProcedimientoNonQry())
                            {
                                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                            }
                        }
                    }
                    return (ObjSPExec.p_bEstadoOK);

                }
               
                        
        public bool ActualizarModulo(int iIdConexion, string cOperacion, int iIdModulo, string sDetalleModulo, string sAbreviatura, int iEstado, ref string sMensajeError)
                {
                    ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Seguridad.PR_Modulo", cOperacion);
                    if (!ObjSPExec.p_bEstadoOK)
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                    else
                    {
                        bool bAsignacionOK = true;
                        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdModulo", iIdModulo);
                        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sDescripcionModulo", sDetalleModulo);
                        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sSiglaModulo", sAbreviatura);
                        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdEstado", iEstado);

                        if (bAsignacionOK)
                        {
                            if (!ObjSPExec.EjecutarProcedimientoNonQry())
                                
                            {
                                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();                                
                            }
                        }
                    }
                    return (ObjSPExec.p_bEstadoOK);
                    
                }

                public bool ListaModulos(int iIdConexion,string cOperacion,ref DataSet DSet ) {
                    ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Seguridad.PR_Modulo",cOperacion);
                    if (!ObjSPExec.p_bEstadoOK) {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    } 
                    else
                    {
                        if (!ObjSPExec.EjecutarProcedimientoQry()) 
                        {
                            sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                        } 
                        else
                        {
                            DSet = ObjSPExec.p_DataSetResultado;
                        }
                    }
                    return (ObjSPExec.p_bEstadoOK);
                }
                public bool ListaModulosconParametro(int iIdConexion, string cOperacion,int iIdModulo, ref DataSet DSetTmp)
                {
                    ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Seguridad.PR_Modulo", cOperacion);
                    if (!ObjSPExec.p_bEstadoOK)
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                    else
                    {
                        bool bAsignacionOK = true;
                        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdModulo", iIdModulo);                        

                        if (bAsignacionOK)
                        {
                            if (!ObjSPExec.EjecutarProcedimientoQry())
                            {
                                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                            }
                            else
                            {
                                DSetTmp = ObjSPExec.p_DataSetResultado;
                            }
                            
                        }
                    }
                    return (ObjSPExec.p_bEstadoOK);
                }


    #endregion
    #region MENU
                public IDataReader ListaMenu(string sBMenuSuperior,string sBMenu)
                {
                    DbCommand cmd = db.GetStoredProcCommand("Seguridad.PR_MenuLista",sBMenuSuperior,sBMenu);
                    IDataReader dataReader = db.ExecuteReader(cmd);
                    return dataReader;
                }
                public IDataReader ListaMenuconParametro(int IdTransaccion)
                {
                    DbCommand cmd = db.GetStoredProcCommand("Seguridad.PR_MenuListaconParametro",IdTransaccion);
                    IDataReader dataReader = db.ExecuteReader(cmd);
                    return dataReader;
                }
                public IDataReader ListaMenuSuperior()
                {
                    DbCommand cmd = db.GetStoredProcCommand("Seguridad.PR_MenuListaPrincipal");
                    IDataReader dataReader = db.ExecuteReader(cmd);
                    return dataReader;
                }
                public IDataReader ListaMenuPadre()
                {
                    DbCommand cmd = db.GetStoredProcCommand("Seguridad.PR_MenuListaMenuPadre");
                    IDataReader dataReader = db.ExecuteReader(cmd);
                    return dataReader;
                }


                //public String InsertarMenu(string DetalleMenu, int IdMenuSuperior, int Orden, string URL, int IdEstado)
                //{
                //    String Mensaje=null;
                //    DbCommand cmd = db.GetStoredProcCommand("Seguridad.PR_MenuInserta", DetalleMenu, IdMenuSuperior, Orden, URL, IdEstado,Mensaje);
                //    db.ExecuteReader(cmd);
                //    Mensaje = Convert.ToString(db.GetParameterValue(cmd, "@o_sMensajeError"));
                //    return Mensaje;

                //}

                public bool InsertarMenu(int iIdConexion, string cOperacion, string DetalleMenu, int IdMenuSuperior, int Orden, string URL, int IdEstado, ref string sMensajeError)
                {
                    ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Seguridad.PR_Menu", cOperacion);
                    if (!ObjSPExec.p_bEstadoOK)
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                    else
                    {
                        bool bAsignacionOK = true;
                        ObjSPExec.p_RemplazarCeroPorDBNull = false;
                        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sDescripcion", DetalleMenu);
                        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdMenuSuperior", IdMenuSuperior);
                        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iOrden", Orden);
                        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sURL", URL);
                        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdEstado", IdEstado);

                        if (bAsignacionOK)
                        {
                            if (!ObjSPExec.EjecutarProcedimientoNonQry())
                                
                            {
                                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();                                
                            }
                        }
                    }
                    return (ObjSPExec.p_bEstadoOK);
                    
                }

                public IDataReader ListaMenuxIdMenu(int IdMenu)
                {
                    DbCommand cmd = db.GetStoredProcCommand("Seguridad.PR_MenuListaxIdMenu",IdMenu);
                    IDataReader dataReader = db.ExecuteReader(cmd);
                    return dataReader;
                }

                //public void ActualizarMenu(int IdMenu,string DetalleMenu,int IdMenuSuperior,int Orden,string URL,int IdEstado, out int Semaforo, out string Mensaje)
                //{
                //    Mensaje = null;
                //    Semaforo = 0;
                //    DbCommand cmd = db.GetStoredProcCommand("Seguridad.PR_MenuActualiza", IdMenu,DetalleMenu,IdMenuSuperior,Orden,URL,IdEstado,Semaforo,Mensaje);
                //    db.ExecuteReader(cmd);
                //    Semaforo = Convert.ToInt32(db.GetParameterValue(cmd, "@Semaforo"));
                //    Mensaje = Convert.ToString(db.GetParameterValue(cmd, "@o_sMensajeError"));
                //}
                public bool ActualizarMenu(int iIdConexion, string cOperacion, int iIdMenu, string sDetalleMenu, int iIdMenuSuperior, int iOrden, string sURL, int iIdEstado, ref string sMensajeError)
                {
                    ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Seguridad.PR_Menu", cOperacion);
                    if (!ObjSPExec.p_bEstadoOK)
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                    else
                    {
                        bool bAsignacionOK = true;
                        ObjSPExec.p_RemplazarCeroPorDBNull = false;
                        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdMenu", iIdMenu);
                        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sDescripcion", sDetalleMenu);
                        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdMenuSuperior", iIdMenuSuperior);
                        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iOrden", iOrden);
                        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sURL", sURL);
                        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdEstado", iIdEstado);

                        if (bAsignacionOK)
                        {
                            if (!ObjSPExec.EjecutarProcedimientoNonQry())
                            {
                                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                            }
                        }
                    }
                    return (ObjSPExec.p_bEstadoOK);

                }
    #endregion
                public DataTable ListaDatosConexion(int iIdConexion)
                {
                    try
                    {
                        xconSenarit.Open();
                        DataTable dt = new DataTable();
                        SqlDataAdapter adap = new SqlDataAdapter("Seguridad.PR_ListaDatosConexion", xconSenarit);
                        adap.SelectCommand.CommandType = CommandType.StoredProcedure;
                        adap.SelectCommand.Parameters.Add("@IdConexion", SqlDbType.Int).Value = iIdConexion;
                        adap.Fill(dt);
                        xconSenarit.Close();
                        return dt;
                    }
                    catch
                    {
                        xconSenarit.Close();
                        return null;

                    }

                }
                public DataTable Version()
                {
                    try
                    {
                        xconSenarit.Open();
                        DataTable dt = new DataTable();
                        SqlDataAdapter adap = new SqlDataAdapter("Seguridad.PR_ConsultaVersion", xconSenarit);
                        adap.SelectCommand.CommandType = CommandType.StoredProcedure;                        
                        adap.Fill(dt);
                        xconSenarit.Close();
                        return dt;
                    }
                    catch
                    {
                        xconSenarit.Close();
                        return null;

                    }

                }
               


    }
}