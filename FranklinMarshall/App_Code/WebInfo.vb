Imports Microsoft.VisualBasic

Public Class WebInfo
    Public Shared Function GetIP(ByRef Request As System.Web.HttpRequest) As String
        Dim IPAddress As String = Request.ServerVariables("REMOTE_ADDR")
        If Not Request.Headers("X-Forwarded-For") Is Nothing Then
            IPAddress = Request.Headers("X-Forwarded-For")
        End If
        Return IPAddress
    End Function
End Class
