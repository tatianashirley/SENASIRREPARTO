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
    public class clsUsuarioDA
    {
        string sMensajeError = "";
        public bool ListaUsuarios(int iIdConexion,string cOperacion,string sLogin, ref string sMensajeError, ref DataSet DSetTmp)
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
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sCuentaUsuario", sLogin);
                


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
        public bool UsuarioAdicion(int iIdConexion, string cOperacion, int iCarnet, string sCuentaUsuario, DateTime fFechaVigencia, DateTime? fFechaExpiracion, int iTipoUsuario, int iIdEstado, string sClaveUsuario, ref string sMensajeError)
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
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iCarnet", iCarnet);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sCuentaUsuario", sCuentaUsuario);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fFechaVigencia", fFechaVigencia);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fFechaExpiracion", fFechaExpiracion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTipoUsuario", iTipoUsuario);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdEstado", iIdEstado);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sClaveUsuario", sClaveUsuario);
                



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

        public bool UsuarioModifica(int iIdConexion, string cOperacion, int iIdUsuario, int iCarnet, string sCuentaUsuario, DateTime fFechaVigencia, string fFechaExpiracion, int iTipoUsuario, int iIdEstado, string sClaveUsuario, ref string sMensajeError)
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
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdUsuario", iIdUsuario);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iCarnet", iCarnet);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sCuentaUsuario", sCuentaUsuario);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fFechaVigencia", fFechaVigencia);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fFechaExpiracion", fFechaExpiracion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTipoUsuario", iTipoUsuario);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdEstado", iIdEstado);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sClaveUsuario", sClaveUsuario);

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
        public bool UsuarioPorId(int iIdConexion,string cOperacion, int iIdUsuario, ref DataSet DSetTmp)
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
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdUsuario", iIdUsuario);


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

        //public bool UsuarioModificaPassword(int iIdConexion, string cOperacion, int iIdUsuario, string sClaveUsuario, ref string sMensajeError)
        //{
        //    ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Seguridad.PR_Usuario", cOperacion);
        //    if (!ObjSPExec.p_bEstadoOK)
        //    {
        //        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
        //    }
        //    else
        //    {
        //        bool bAsignacionOK = true;
        //        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
        //        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
        //        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdUsuario", iIdUsuario);                
        //        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sClaveUsuario", sClaveUsuario);

        //        if (bAsignacionOK)
        //        {
        //            if (!ObjSPExec.EjecutarProcedimientoNonQry())
        //            {
        //                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
        //            }

        //        }
        //    }
        //    return (ObjSPExec.p_bEstadoOK);
        //}

        //public bool ObtieneNroTransaccion(int iIdConexion, string cOperacion, int iIdProcedimiento, ref string sMensajeError, ref DataSet DSetTmp)
        //{
        //    ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Seguridad.PR_Transaccion", cOperacion);
        //    if (!ObjSPExec.p_bEstadoOK)
        //    {
        //        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
        //    }
        //    else
        //    {
        //        bool bAsignacionOK = true;
        //        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
        //        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
        //        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdProcedimiento", iIdProcedimiento);


        //        if (bAsignacionOK)
        //        {
        //            if (!ObjSPExec.EjecutarProcedimientoQry())
        //            {
        //                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
        //            }
        //            else
        //            {
        //                DSetTmp = ObjSPExec.p_DataSetResultado;
        //            }
        //        }
        //    }
        //    return (ObjSPExec.p_bEstadoOK);
        //}

    }


}