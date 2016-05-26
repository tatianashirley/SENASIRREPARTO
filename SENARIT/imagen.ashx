<%@ WebHandler Language="VB" Class="imagen" %>

Imports System
Imports System.Web

Public Class imagen : Implements IHttpHandler
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        
        context.Response.ContentType = "image/png"
        
        Dim path As String = "Imagenes/"
        Dim imagen As String = context.Request.QueryString("imagen")
        
        If IsNothing(imagen) Then
            context.Response.WriteFile(path & "16parar.png")
        Else
            context.Response.WriteFile(path & imagen & ".jpg")
        End If
        
    End Sub
 
    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class