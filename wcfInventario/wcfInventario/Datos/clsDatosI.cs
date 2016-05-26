using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Configuration;
using System.Reflection;
using System.Globalization;
using System.Text;
using System.Xml;
using System.Resources;
using SQLSPExecuter;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace wfcInventario.Datos
{
  
    public class clsDatosI
    {
        Database db = null;

        public void clsDatos()
        {
            db = DatabaseFactory.CreateDatabase("cadena");
        }

        public bool ObtieneDatos(int iIdConexion, string cOperacion, string Tipo, string Paterno, string Materno, string Nombre1
                             , string NumeroDocumento, string Matricula, string NroTramite, string CUA, Int64 NUP,
            int Nave, int Estante ,int ID, ref string sMensajeError, ref DataSet DSetTmp)
        {

            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Inventario.PR_Busqueda", cOperacion);
          
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Tipo", Tipo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Paterno", Paterno);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Materno", Materno);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Nombre1", Nombre1);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@CI", NumeroDocumento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Matricula", Matricula);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NroTramite", NroTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@CUA", CUA);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NUP", NUP);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Nave", Nave);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Estante", Estante);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@ID", ID);

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


        public bool InsertaRegistro
        (
            int iIdConexion, string cOperacion, string GrupoBeneficio, string NroTramite, Int32 NroDocumento,
            string matricula, Int32 Nave, Int32 Estante, Int32 CodigoCaja, string CodigoCajaHistorica,
            Int64 CodigoDigitalizacion , string Observacion,ref string sMensajeError
        )
        {

            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Inventario.PR_RegistraUbicacion", cOperacion);
          
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_IdTramite", NroTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_IdGrupoBeneficio", GrupoBeneficio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_Matricula", matricula);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_Nave", Nave);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_Estante", Estante);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_CodigoCaja", CodigoCaja);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_CajaHistorica", CodigoCajaHistorica);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_CodigoDigitalizacion", CodigoDigitalizacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_Observacion", Observacion);

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


        public bool ModificaRegistro
        (
            int iIdConexion, string cOperacion, Int32 Nave, Int32 Estante, Int32 CodigoCaja,string NroTramite,
            string matricula,
            string CodigoCajaHistorica,Int64 CodigoDigitalizacion, 
            string Observacion, ref string sMensajeError
        )
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Inventario.PR_ModificaUbicacion", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_Nave", Nave);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_IdTramite", NroTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_Matricula", matricula);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_Estante", Estante);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_CodigoCaja", CodigoCaja);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_CajaHistorica", CodigoCajaHistorica);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_CodigoDigitalizacion", CodigoDigitalizacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_Observacion", Observacion);

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

        public bool RehubicacionRegistro
        (
          int iIdConexion, string cOperacion, Int32 Nave, Int32 Estante, Int32 CodigoCaja, string NroTramite,
            string matricula,
            string CodigoCajaHistorica, Int64 CodigoDigitalizacion,
            string Observacion, string IdGrupoBeneficio, ref string sMensajeError
        )
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Inventario.PR_RehubicaExpediente", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_Nave", Nave);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_IdTramite", NroTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_IdGrupoBeneficio", IdGrupoBeneficio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_Matricula", matricula);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_Estante", Estante);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_CodigoCaja", CodigoCaja);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_CajaHistorica", CodigoCajaHistorica);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_CodigoDigitalizacion", CodigoDigitalizacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_Observacion", Observacion);

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

        public bool InsertaRegistroAsignacion
        (
            int iIdConexion, string cOperacion, string tramite, string matricula, Int32 IdUsuario, 
            ref string sMensajeError
        )
        {

            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Inventario.PR_RegistraAsignacion", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_idTramite", tramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_Matricula", matricula);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_idUsuarioAsignado", IdUsuario);

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


        public bool InsertaRegistroDevolucion
        (
            int iIdConexion, string cOperacion, Int32 IdRegistro,
            ref string sMensajeError
        )
        {

            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Inventario.PR_RegistraDevolucion", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_idRegistro", IdRegistro);

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


    }
}