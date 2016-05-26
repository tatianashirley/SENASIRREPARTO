using System;
using System.Data;
using System.Globalization;
using System.Text;
using System.Xml;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Resources;
using System.Collections.Generic;

using wcfServicioIntercambioPago.Entidades;
using SQLSPExecuter;

namespace wcfServicioIntercambioPago.Datos
{
    
    public class clsServicioIntercambioDA
    {
        Database db = null;

        public clsServicioIntercambioDA()
        {
            db = DatabaseFactory.CreateDatabase("cadena");
        }
        /*********************propios de Intercambio**********************/
        //public IDataReader ListarTipoArchivo(int IdArchivo, string Tipo)
        //{
        //    DbCommand cmd = db.GetStoredProcCommand("Intercambio.PR_ListarTipoIntercambio",IdArchivo,Tipo);
        //    IDataReader dataReader = db.ExecuteReader(cmd);
        //    return dataReader;
        //}
        //public IDataReader ListarCamposArchivo(int IdArchivo, string Tipo)
        //{
        //    DbCommand cmd = db.GetStoredProcCommand("Intercambio.PR_ListarCampoIntercambio",IdArchivo,Tipo);
        //    IDataReader dataReader = db.ExecuteReader(cmd);
        //    return dataReader;
        //}
        //public IDataReader ObtenerArchivoIntercambio(string NombreArchivo)
        //{
        //    DbCommand cmd = db.GetStoredProcCommand("Intercambio.PR_ListarArchivoIntercambio", NombreArchivo);
        //    IDataReader dataReader = db.ExecuteReader(cmd);
        //    return dataReader;
        //}

        // registro el medio de intercambio */
        //public void RegistrarEnvio(string TipoMedio,string Estado, string NombreArchivo)
        //{
        //    DbCommand cmd = db.GetStoredProcCommand("Intercambio.PR_RegistraArchivoIntercambio", TipoMedio,Estado,NombreArchivo);
        //    db.ExecuteNonQuery(cmd);
        //}
        //// actualizar registro de Envio*/
        //public void ModificarEnvio(string NombreArchivo, string Tipo)
        //{
        //    DbCommand cmd = db.GetStoredProcCommand("Intercambio.PR_ModificaArchivoIntercambio", NombreArchivo,Tipo);
        //    db.ExecuteNonQuery(cmd);
        //}
        //// registro error intercambio */
        //public void RegistrarErrorEnvio(int IdControlArchivo, int Fila, int Campo, string Descripcion)
        //{
        //    DbCommand cmd = db.GetStoredProcCommand("Intercambio.PR_RegistraErroresArchivo",IdControlArchivo,Fila,Campo,Descripcion);
        //    db.ExecuteNonQuery(cmd);
        //}

        /*******con modulos de seguridad*********************/
        public bool ListarArchivoIntercambio(int iIdConexion, string cOperacion, string NombreArchivo, ref string sMensajeError,  ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Intercambio.PR_ListarArchivoIntercambio", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NombreArchivo", NombreArchivo);


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

        public bool ModificaArchivoIntercambio(int iIdConexion, string cOperacion, string NombreArchivo, string Estado
                                                , ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Intercambio.PR_ModificaArchivoIntercambio", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NombreArchivo", NombreArchivo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Estado", Estado);

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

        public bool RegistraArchivoIntercambio(int iIdConexion, string cOperacion, string TipoMedio, string Estado, string NombreArchivo
                                                , ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Intercambio.PR_RegistraArchivoIntercambio", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@TipoMedio", TipoMedio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Estado", Estado);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NombreArchivo", NombreArchivo);

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

        public bool RegistraErroresArchivo(int iIdConexion, string cOperacion, int IdControlArchivo, int Fila, int Campo, string Descripcion
                                                , ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Intercambio.PR_RegistrarErroresArchivo", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdControlArchivoRecibido", IdControlArchivo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Fila", Fila);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Campo", Campo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Descripcion", Descripcion);

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