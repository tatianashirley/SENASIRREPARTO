using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

using wcfGeo.Logica;

using System.Drawing;

public partial class wfrmLocalidades : System.Web.UI.Page
{
    int Estado;

    //**Auditoria
    //clsAuditoria audi = new clsAuditoria();
    //**Fin Auditoria

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["CodUsuario"] == null)
        //{
        //    Response.Redirect("~/Login.aspx");
        //}
        //else
        //{
        //    lblCodUsuario.Text = Session["CodUsuario"].ToString();
        //    lblRol.Text = Session["CodRol"].ToString();
        //}

        if (!Page.IsPostBack)
        {
            ContarRegistros();
            txtPagina.Text = txtTotalPaginas.Text;
            ValidarBotones();
            
            ListarRegistros();
            
            //CargarComboDeModulos();
        }
    }

    //protected void CargarComboDeModulos()
    //{
    //    clsModulos adm = new clsModulos();

    //    ddlSelModulo.DataSource = adm.ListarModulos(0, 0);
    //    ddlSelModulo.DataValueField = "IdModulo";
    //    ddlSelModulo.DataTextField = "DescripcionModulo";
    //    ddlSelModulo.DataBind();
    //}

    protected void ListarRegistros()
    {
        //clsLocalidad admi = new clsLocalidad();
        //gvDatos.DataSource = admi.ListarDepartamentos();
        //gvDatos.DataBind();
    }


    protected void Limpiar()
    {
        txtDepartamento.Text = "";
        chbEstado.Checked = true;
        lblObservaciones.Text = "";
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Limpiar();
    }

    /// -------------------------------------
    /// Carga datos especificos al Formulario
    /// -------------------------------------
    protected void VerDatos()
    {
        int Cod = Convert.ToInt32(lblCodigo.Text);

        clsDepartamento tp1 = new clsDepartamento();
        foreach (clsDepartamento tp2 in tp1.ObtenerDepartamento())
        {
            txtDepartamento.Text = tp2.NombreDepartamento.Trim();

            //if (tp2.IdEstado == 1)
            //{
            //    chbEstado.Checked = true;
            //}
            //else
            //{
            //    chbEstado.Checked = false;
            //}
        }
    }

    protected void btnAccionar_Click(object sender, EventArgs e)
     {
         int CodUso = 0;

         if (chbEstado.Checked)
         {
             Estado = 1;
         }
         else
         {
             Estado = 0;
         }

         //if (btnAccionar.Text == "Adicionar")
         //{
         //    if (txtAbreviacionRol.Text.Length >=1 && txtDescripcion.Text.Length >= 3)
         //    {
         //        clsDepartamento tp1 = new clsDepartamento();
         //        foreach (clsDepartamento tp2 in tp1.VerificarAbreviacionRol(txtAbreviacionRol.Text.ToUpper(), txtDescripcion.Text.ToUpper(), Convert.ToInt32(ddlModulo.SelectedValue)))
         //        {
         //            CodUso = tp2.IdRol;
         //        }
         //        if (CodUso == 0)
         //        {
         //            clsDepartamento adi = new clsDepartamento();
         //            adi.AdicionarRol(Convert.ToInt32(ddlModulo.SelectedValue), txtAbreviacionRol.Text.ToUpper(), txtDescripcion.Text.ToUpper(), Estado);
         //            lblObservaciones.Text = "Adicion Satisfactoria";

         //            Limpiar();

         //            ContarRegistros();
         //            txtPagina.Text = txtTotalPaginas.Text;

         //            ListarRegistros();
         //        }
         //        else
         //        {
         //            lblObservaciones.Text = "La Abreviacion o Rol ya estan registrados en el contexto";
         //        }
         //    }
         //    else
         //    {
         //        lblObservaciones.Text = "Abreviacion y/o Descripcion No Valida";
         //    }

         //}

         //if (btnAccionar.Text == "Eliminar")
         //{
         //    int Cod;

         //    clsDepartamento eli = new clsDepartamento();
         //    Cod = Convert.ToInt32(lblCodigo.Text);

         //    eli.EliminarRol(Cod);
         //    lblObservaciones.Text = "Eliminacion Satisfactoria";

         //    Limpiar();
         //    ListarRegistros();
         //}

         //if (btnAccionar.Text == "Modificar")
         //{
         //    int Cod = Convert.ToInt32(lblCodigo.Text);

         //    if (txtAbreviacionRol.Text.Length >= 1 && txtDescripcion.Text.Length >= 3)
         //    {
         //        //clsDepartamento tp1 = new clsDepartamento();
         //        //foreach (clsDepartamento tp2 in tp1.VerificarRol(txtDescripcion.Text.ToUpper()))
         //        //{
         //        //    roluso = tp2.Descripcion.Trim();
         //        //}

         //        //if (roluso == "")
         //        //{
         //           clsDepartamento modi = new clsDepartamento();
         //           modi.ModificarRol(Cod, Convert.ToInt32(ddlModulo.SelectedValue), txtAbreviacionRol.Text.ToUpper(), txtDescripcion.Text.ToUpper(), Estado);
         //           lblObservaciones.Text = "Modificacion Satisfactoria";

         //           Limpiar();
         //           ListarRegistros();
         //        //}
         //        //else
         //        //{
         //        //    lblObservaciones.Text = "El Login ya esta Registrado";
         //        //}
         //    }
         //    else
         //    {
         //        lblObservaciones.Text = "Abreviacion y/o Descripcion No Valida";
         //    }

         //}

     }

    #region habilitacion

    protected void imgNuevo_Click(object sender, ImageClickEventArgs e)
    {
        //Limpiar();

        //btnAccionar.Text = "Adicionar";
        //lblTitulo.Text = "Adicion de Rol";

        //if(ddlSelModulo.SelectedValue != "0")
        //{
        //    ddlModulo.SelectedValue = ddlSelModulo.SelectedValue;

        //    ddlModulo.Enabled = false;
        //    txtAbreviacionRol.Enabled = true;
        //    txtDescripcion.Enabled = true;
        //    chbEstado.Enabled = true;

        //    this.pnlDatos_ModalPopupExtender.Show();
        //}
        //else
        //{
        //    lblObservaciones.Text = "Seleccion Modulo";
        //}
    }

    protected void gvRoles_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //string valor;
        //int val;

        //GridViewRow row = gvDatos.Rows[e.RowIndex];
        //val = row.RowIndex;
        //valor = gvDatos.Rows[val].Cells[1].Text;
        //lblCodigo.Text = valor;

        //Limpiar();

        //btnAccionar.Text = "Eliminar";
        //lblTitulo.Text = "Eliminacion de Rol";

        //ddlModulo.Enabled = false;
        //txtAbreviacionRol.Enabled = false;
        //txtDescripcion.Enabled = false;
        //chbEstado.Enabled = false;

        //VerDatos();
        //this.pnlDatos_ModalPopupExtender.Show();
    }

    protected void gvRoles_RowEditing(object sender, GridViewEditEventArgs e)
    {
        //string valor;
        //int val;
        //GridViewRow row = gvDatos.Rows[e.NewEditIndex];
        //val = row.RowIndex;
        //valor = gvDatos.Rows[val].Cells[1].Text;
        //lblCodigo.Text = valor;

        //Limpiar();

        //btnAccionar.Text = "Modificar";
        //lblTitulo.Text = "Modificacion de Rol";

        //ddlModulo.Enabled = false;
        //txtAbreviacionRol.Enabled = true;
        //txtDescripcion.Enabled = true;
        //chbEstado.Enabled = true;

        //VerDatos();
        //this.pnlDatos_ModalPopupExtender.Show();
    }

    #endregion

    protected void gvRoles_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int DEstado;
            DEstado = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "IdEstado"));

            if (DEstado == 1)
            {
                HyperLink hlnk = new HyperLink();
                hlnk.NavigateUrl = "";
                hlnk.ImageUrl = "~/Imagenes/16Activo.png";
                e.Row.Cells[1].Controls.Add(hlnk);
            }
            if (DEstado == 0)
            {
                e.Row.BackColor = Color.Silver;
                e.Row.ForeColor = Color.Lavender;
                //e.Row.Cells[2].BackColor = Color.FromName("#c6efce");
                HyperLink hlnk = new HyperLink();
                hlnk.NavigateUrl = "";
                hlnk.ImageUrl = "~/Imagenes/16Inactivo.png";
                e.Row.Cells[1].Controls.Add(hlnk);
                if (rbTipoMuestra.SelectedIndex == 1)
                    e.Row.Visible = false;
            }
        }
    }
  
    protected void rbTipoMuestra_SelectedIndexChanged(object sender, EventArgs e)
    {
        ListarRegistros();
    }

    #region paginacion

    protected void ContarRegistros()
    {
        int divisor;

        clsLocalidad tp1 = new clsLocalidad();
        foreach (clsLocalidad tp2 in tp1.ContarLocalidades())
        {
            txtTotal.Text = tp2.TotalR.ToString();
        }

        divisor = Convert.ToInt32(txtTotal.Text) / Convert.ToInt32(txtRango.Text);

        if (Convert.ToInt32(txtTotal.Text) % Convert.ToInt32(txtRango.Text) > 0)
        {
            txtTotalPaginas.Text = Convert.ToString(divisor + 1);
        }
        else
        {
            txtTotalPaginas.Text = Convert.ToString(divisor);
        }
    }

    protected void ValidarBotones()
    {
        if (Convert.ToInt32(txtPagina.Text) == 1)
        {
            btnAnt.Enabled = false;
            btnIni.Enabled = false;
        }
        else
        {
            btnAnt.Enabled = true;
            btnIni.Enabled = true;
        }
        if (Convert.ToInt32(txtPagina.Text) == Convert.ToInt32(txtTotalPaginas.Text))
        {
            btnSig.Enabled = false;
            btnFin.Enabled = false;
        }
        else
        {
            btnSig.Enabled = true;
            btnFin.Enabled = true;
        }
    }

    protected void btnIni_Click(object sender, EventArgs e)
    {
        txtPagina.Text = "1";
        ListarRegistros();
        ContarRegistros();
        ValidarBotones();
    }
    protected void btnAnt_Click(object sender, EventArgs e)
    {
        txtPagina.Text = Convert.ToString(Convert.ToInt32(txtPagina.Text) - 1);
        ListarRegistros();
        ContarRegistros();
        ValidarBotones();
    }
    protected void btnSig_Click(object sender, EventArgs e)
    {
        txtPagina.Text = Convert.ToString(Convert.ToInt32(txtPagina.Text) + 1);
        ListarRegistros();
        ContarRegistros();
        ValidarBotones();
    }
    protected void btnFin_Click(object sender, EventArgs e)
    {
        txtPagina.Text = txtTotalPaginas.Text;
        ListarRegistros();
        ContarRegistros();
        ValidarBotones();
    }

    #endregion


}