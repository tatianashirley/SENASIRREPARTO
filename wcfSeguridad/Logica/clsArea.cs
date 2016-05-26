using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using wcfSeguridad.Datos;
using System.Security.Cryptography;
using System.Text;

namespace wcfSeguridad.Logica
{
    public class clsArea
    {
        DataTable dt = new DataTable();
        clsSeguridadDA ObjSeguridadDA = new clsSeguridadDA();
        clsAreaDA ObjAreaDA = new clsAreaDA();

        public DataTable ListaArea(int iIdConexion,string cOperacion,int iIdOficina,ref int iNivelError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjAreaDA.ListaArea(iIdConexion,cOperacion,iIdOficina,ref iNivelError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }


        public bool AreaAdicionar(int iIdConexion,string cOperacion,string sDetalleArea,int iIdOficina,int iIdAreaSuperior,string sResponsable,int iIdEstado, ref string sMensajeError)
        {
            bool bAsignacionOK = ObjAreaDA.AreaAdicionar(iIdConexion, cOperacion, sDetalleArea, iIdOficina, iIdAreaSuperior, sResponsable, iIdEstado, ref sMensajeError);
            return (bAsignacionOK);
        }
        public bool AreaModificar(int iIdConexion,string cOperacion,int iIdOficina,int iIdArea,string sDescripcionArea,int iIdEstado, ref string sMensajeError)
        {
            bool bAsignacionOK = ObjAreaDA.AreaModificar(iIdConexion, cOperacion, iIdOficina,iIdArea,sDescripcionArea, iIdEstado,ref sMensajeError);
            return (bAsignacionOK);
        }


        public DataTable ListaAreaxIdOficina(int iIdConexion,string cOperacion,int iIdArea,int iIdOficina, ref int iNivelError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjAreaDA.ListaAreaxIdOficina(iIdConexion, cOperacion, iIdArea, iIdOficina, ref  iNivelError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }
        //public DataTable ObtieneNroTransaccion(int iIdConexion, string cOperacion, int iIdProcedimiento, ref string sMensajeError)
        //{
        //    DataSet DSetTmp = new DataSet();
        //    if (ObjTransaccionDA.ObtieneNroTransaccion(iIdConexion, cOperacion, iIdProcedimiento, ref sMensajeError, ref DSetTmp))
        //    {
        //        return (DSetTmp.Tables[0]);
        //    }
        //    else
        //    {
        //        return (null);
        //    }
        //}
        

        

    }
}