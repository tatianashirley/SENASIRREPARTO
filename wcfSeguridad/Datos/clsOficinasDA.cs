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
    public class clsOficinasDA
    {

        public bool OficinaLista(int iIdConexion,string cOperacion, ref string sMensajeError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Seguridad.PR_Oficina", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);

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

        public bool OficinaListaPorOficinaPrincipal(int iIdConexion, string cOperacion, int iIdOficinaPrincipal, ref string sMensajeError, ref string sNivelError,ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Seguridad.PR_Oficina", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdOficinaSuperior", iIdOficinaPrincipal);

                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                        sNivelError = ObjSPExec.p_iNivelError.ToString();
                    }
                    else
                    {
                        DSetTmp = ObjSPExec.p_DataSetResultado;
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }        

        public bool LocalidadLista(int iIdConexion,string cOperacion,int iIdDepartamento, ref string sMensajeError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Seguridad.PR_Oficina", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdDepartamento", iIdDepartamento);

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

        public bool OficinaAdiciona(int iIdConexion, string cOperacion, string sOficina, int iIdOficinaSuperior, string sCodigo, string sNivel, string sDireccion, int iTelefono,int iLocalidad, int iIdTipoOficina, int iIdEstado,int iFlagCC, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Seguridad.PR_Oficina", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;

                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sCodigo", sCodigo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNombre", sOficina);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdOficinaSuperior", iIdOficinaSuperior);                
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iNivel", sNivel);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sDireccion", sDireccion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iTelefono", iTelefono);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdLocalidad", iLocalidad);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTipoOficina", iIdTipoOficina);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_bFlagImprimeCC", iFlagCC);
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

        public bool OficinaModifica(int iIdConexion, string cOperacion, int iIdOficina, string sOficina, int iIdOficinaSuperior, string sCodigo, string sNivel, string sDireccion, int iTelefono, int iLocalidad, int iIdTipoOficina, int iIdEstado, int iFlagCC, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Seguridad.PR_Oficina", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdOficina", iIdOficina);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNombre", sOficina);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdOficinaSuperior", iIdOficinaSuperior);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sCodigo", sCodigo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iNivel", sNivel);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sDireccion", sDireccion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iTelefono", iTelefono);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdLocalidad", iLocalidad);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTipoOficina", iIdTipoOficina);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdEstado", iIdEstado);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_bFlagImprimeCC", iFlagCC);

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

        public bool ListaOficinasxIdOficinas(int iIdConexion,string cOperacion,int  IdOficina, ref string sMensajeError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Seguridad.PR_Oficina", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdOficina", IdOficina);
               

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

        public bool UsuarioOficinaLista(int iIdConexion, string cOperacion,int  iIdUsuario,  ref string  sMensajeError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Seguridad.PR_Oficina", cOperacion);
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

        public bool ObtieneNivelesDeOficina(int iIdConexion, ref string sMensajeError, ref DataSet DSetNiveles) {

            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Seguridad.PR_Oficina", "S");

            if (!ObjSPExec.p_bEstadoOK) {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            } else {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "S");
               
                if (bAsignacionOK) {
                    if (!ObjSPExec.EjecutarProcedimientoQry()) {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    } else {
                        DSetNiveles = ObjSPExec.p_DataSetResultado;
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }

    }


}