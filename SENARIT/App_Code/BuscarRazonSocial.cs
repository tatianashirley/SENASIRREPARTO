using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
[System.Web.Script.Services.ScriptService]
public class BuscarRazonSocial : System.Web.Services.WebService
{

    //constructor
    public BuscarRazonSocial()
    {
        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]

    public string[] wsBuscarRazonSocial(string prefixText)
    {
        //string connstring = ConfigurationManager.ConnectionStrings["cnnPersonal"].ConnectionString;
        string connstring = ConfigurationManager.ConnectionStrings["cnnsenarit"].ConnectionString;

        using (SqlConnection con = new SqlConnection(connstring))
        {
            //SqlCommand comando = new SqlCommand("SELECT TOP(50) NombreCompleto FROM vPersonal WHERE NombreCompleto LIKE '%' + @param + '%'", con);
            //SqlCommand comando = new SqlCommand("select TOP(10) 'RUC:'+RUC+'/RAZON SOCIAL: '+NombreEmpresa AS NombreEmpresa from Clasificador.Empresa WHERE (UPPER(NombreEmpresa) like '%' + @param + '%' or RUC like '%' + @param + '%' ) AND RegistroActivo=1", con);            
            ////SqlCommand comando = new SqlCommand("select NombreEmpresa from Clasificador.Empresa WHERE UPPER(NombreEmpresa) like '%' + @param + '%' AND RegistroActivo=1", con);
            //comando.Parameters.AddWithValue("@param", prefixText.ToUpper());

            con.Open();
            SqlCommand comando = new SqlCommand("CertificacionCC.PR_BuscaEmpresa", con);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@param", prefixText.ToUpper()));

            SqlDataReader dr = default(SqlDataReader);             
            //comando.Connection.Open();
            dr = comando.ExecuteReader();
            List<string> items = new List<string>();
            while (dr.Read())
            {
                //items.Add(dr["NombreCompleto"].ToString());                
                items.Add(dr["NombreEmpresa"].ToString());
            }
            comando.Connection.Close();
            return items.ToArray();
        }
    }

    //[WebMethod]
    //public string HelloWorld() {
    //    return "Hola a todos";
    //}

}
