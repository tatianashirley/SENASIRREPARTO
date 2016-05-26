using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using System.Collections.Generic;
using System.Text;
using System.Data.Common;

using wcfEjemplo.Entidades;
using wcfEjemplo.Datos;

namespace wcfEjemplo.Logica
{
    public class clsMenu : clsMenuBE
    {
        //public List<clsMenu> ListarMenu(int Pagina, int Rango)
        //{
        //    //clsMenu p;
        //    //clsMenuDA permiso = new clsMenuDA();
        //    //List<clsMenu> ListaPermiso = new List<clsMenu>();

        //    //using (IDataReader dr = permiso.ListarMenu(Pagina, Rango))
        //    //{
        //    //    while (dr.Read())
        //    //    {
        //    //        p = new clsMenu();

        //    //        p.IdMenu = (int)dr["IdMenu"];
        //    //        p.IdSistema = (int)dr["IdSistema"];
        //    //        p.Descripcion = (string)dr["Descripcion"];
        //    //        p.PadreId = (int)dr["PadreId"];
        //    //        p.Posicion = (int)dr["Posicion"];
        //    //        p.Formulario = (string)dr["Formulario"];
        //    //        p.RutaFormulario = (string)dr["RutaFormulario"];
        //    //        p.IdRol = (int)dr["IdRol"];
        //    //        p.Imagen = (string)dr["Imagen"];
        //    //        p.IdEstado = (int)dr["IdEstado"];

        //    //        ListaPermiso.Add(p);
        //    //    }
        //    //}
        //    //return ListaPermiso;
        //}

        //public void AdicionarMenu(int IdSsistema, string Descripcion, int PadreId, int Posicion, string Formulario, string RutaFormulario, int IdRol, string Imagen, int IdEstado)
        //{
        //    //try
        //    //{
        //    //    clsMenuDA adi = new clsMenuDA();
        //    //    adi.AdicionarMenu(IdSsistema, Descripcion, PadreId, Posicion, Formulario, RutaFormulario, IdRol, Imagen, IdEstado);
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    throw ex;
        //    //}
        //}

        //public Boolean EliminarMenu(int Cod)
        //{
        //    //clsMenuDA eliR = new clsMenuDA();
        //    //return eliR.EliminarMenu(Cod);
        //}

        //public void ModificarMenu(int Cod, int IdSsistema, string Descripcion, int PadreId, int Posicion, string Formulario, string RutaFormulario, int IdRol, string Imagen, int IdEstado)
        //{
        //    try
        //    {
        //        //clsMenuDA cb = new clsMenuDA();
        //        //cb.ModificarMenu(Cod, IdSsistema, Descripcion, PadreId, Posicion, Formulario, RutaFormulario, IdRol, Imagen, IdEstado);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public List<clsMenu> ObtenerMenu(int Cod)
        //{
        //    clsMenu p;
        //    clsMenuDA permiso = new clsMenuDA();

        //    List<clsMenu> ListaPermiso = new List<clsMenu>();
        //    using (IDataReader dr = permiso.ObtenerMenu(Cod))
        //    {
        //        while (dr.Read())
        //        {
        //            p = new clsMenu();

        //            p.IdMenu = (int)dr["IdMenu"];
        //            p.IdSistema = (int)dr["IdSistema"];
        //            p.Descripcion = (string)dr["Descripcion"];
        //            p.PadreId = (int)dr["PadreId"];
        //            p.Posicion = (int)dr["Posicion"];
        //            p.Formulario = (string)dr["Formulario"];
        //            p.RutaFormulario = (string)dr["RutaFormulario"];
        //            p.IdRol = (int)dr["IdRol"];
        //            p.Imagen = (string)dr["Imagen"];
        //            p.IdEstado = (int)dr["IdEstado"];

        //            ListaPermiso.Add(p);
        //        }
        //    }
        //    return ListaPermiso;
        //}

        //public List<clsMenu> VerificarMenu(string sMenu)
        //{
        //    //clsMenu p;
        //    //clsMenuDA permiso = new clsMenuDA();
        //    //List<clsMenu> ListaPermiso = new List<clsMenu>();
        //    //using (IDataReader dr = permiso.VerificarMenu(sMenu))
        //    //{

        //    //    while (dr.Read())
        //    //    {
        //    //        p = new clsMenu();

        //    //        p.IdMenu = (int)dr["IdMenu"];
        //    //        p.IdSistema = (int)dr["IdSistema"];
        //    //        p.Descripcion = (string)dr["Descripcion"];
        //    //        p.PadreId = (int)dr["PadreId"];
        //    //        p.Posicion = (int)dr["Posicion"];
        //    //        p.Formulario = (string)dr["Formulario"];
        //    //        p.RutaFormulario = (string)dr["RutaFormulario"];
        //    //        p.IdRol = (int)dr["IdRol"];
        //    //        p.Imagen = (string)dr["Imagen"];
        //    //        p.IdEstado = (int)dr["IdEstado"];

        //    //        ListaPermiso.Add(p);
        //    //    }
        //    //}
        //    //return ListaPermiso;
        //}

        //public List<clsMenu> ContarMenu()
        //{
        //    //clsMenu p;
        //    //clsMenuDA permiso = new clsMenuDA();
        //    //List<clsMenu> ListaMenu = new List<clsMenu>();
        //    //using (IDataReader dr = permiso.ContarMenu())
        //    //{
        //    //    while (dr.Read())
        //    //    {
        //    //        p = new clsMenu();
        //    //        p.TotalMenu = (int)dr["ContarMenu"];

        //    //        ListaMenu.Add(p);
        //    //    }
        //    //}
        //    //return ListaMenu;
        //}

    }
}