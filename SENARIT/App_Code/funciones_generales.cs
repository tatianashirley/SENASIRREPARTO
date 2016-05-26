using Microsoft.VisualBasic;
using System.Data;
using System.Data.SqlClient;

public class funciones_generales
{
	public funciones_generales()
	{

	}

    //=dw= INICIA: Funciones JAVA =dw=
    public string fgsCerrar()
    {
        return "<script language='JavaScript'>" +
             "var ventana = window.self; ventana.opener = window.self; ventana.close();" + "</script>";
    }  
}