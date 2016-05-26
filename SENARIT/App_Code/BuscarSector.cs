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
public class BuscarSector : System.Web.Services.WebService
{

    //constructor
    public BuscarSector()
    {
        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]

    public string[] wsBuscarSector(string prefixText)
    {
        
        string connstring = ConfigurationManager.ConnectionStrings["cnnsenarit"].ConnectionString;

        using (SqlConnection con = new SqlConnection(connstring))
        {            
            con.Open();
            SqlCommand comando = new SqlCommand("CertificacionCC.PR_BuscarSector", con);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@param", prefixText.ToUpper()));

            SqlDataReader dr = default(SqlDataReader);             
            //comando.Connection.Open();
            dr = comando.ExecuteReader();
            List<string> items = new List<string>();
            while (dr.Read())
            {
                //items.Add(dr["NombreCompleto"].ToString());                
                items.Add(dr["Descripcion"].ToString());
            }
            comando.Connection.Close();
            return items.ToArray();
        }
    }

   
}
