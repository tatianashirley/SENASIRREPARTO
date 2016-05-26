using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using wcfCertificacionCC.Datos;
using System.Security.Cryptography;
using System.Text;

namespace wcfCertificacionCC.Logica
{
    public class clsReprogramacion
    {
        DataTable dt = new DataTable();
        clsReprogramacionDA ObjReprogramacionDA = new clsReprogramacionDA();        
        Int32 iIdConexion = 0;
        string sMensajeError = null;

        public bool ProgramacionReasigna(int iIdConexion,string cOperacion,int iIdUsuarioAntiguo,int iIdProgramacionAntigua, int iIdUsuarioNuevo,int iIdProgramacionNueva, ref string sMensajeError)
       {
           bool bAsignacionOK = ObjReprogramacionDA.ProgramacionReasigna( iIdConexion, cOperacion, iIdUsuarioAntiguo, iIdProgramacionAntigua,  iIdUsuarioNuevo, iIdProgramacionNueva, ref sMensajeError);
           return (bAsignacionOK);
       }
       
    }
}