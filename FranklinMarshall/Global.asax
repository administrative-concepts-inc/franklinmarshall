<%@ Application Language="VB" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="System.Net.Mail" %>
<%@ Import Namespace="System" %>

<script runat="server">
    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application startup
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application shutdown
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when an unhandled error occurs
        Dim ctx As HttpContext = HttpContext.Current
        Dim exception1 As Exception = ctx.Server.GetLastError

        Dim errorInfo As String = ""
        If exception1 IsNot Nothing Then
            errorInfo = "<br>Offending URL:  " + ctx.Request.Url.ToString() & vbCrLf & _
                        "<br>Source: " + exception1.Source & vbCrLf & _
                        "<br>Message:  " + exception1.Message
            If exception1.InnerException IsNot Nothing Then
                errorInfo &= "<br>InnerException Message: " + exception1.InnerException.Message.ToString & vbCrLf & _
                             "<br>StackTrace: " + exception1.StackTrace.ToString
            Else
                errorInfo &= "<br>InnerException Message: " & vbCrLf & _
                             "<br>StackTrace:"
            End If

        End If

        Dim HTMLbody As String = "<html><body>"
        HTMLbody &= "<br /><b>Date:" & Now() & "</b> <br /><br />"
        HTMLbody &= "<b> Session Variable: </b>"

        If HttpContext.Current.Session IsNot Nothing Then
            For Each o As Object In Session.Contents
                HTMLbody &= "<b>" & o.ToString & "</b>" & "-" & Session(o.ToString).ToString & "<br /><br />"
            Next
        End If
        HTMLbody &= "<b>IP Address: <b/>" & WebInfo.GetIP(Me.Request)
        HTMLbody &= "<br /><br /><b>Error info: <b/><br />"
        HTMLbody &= errorInfo & "</body><br/><br/></html>"

        Try
            Dim MailObj As New System.Net.Mail.SmtpClient
            MailObj.Host = "aciexch2010.visit-aci.com"
            Dim msg As New MailMessage("Error@visit-aci.com", "WebErrors@visit-aci.com", "Franklin & Marshall College Info Site Error", HTMLbody)
            msg.IsBodyHtml = True
            MailObj.Send(msg)
        Catch ex As Exception
            Try
                Dim EmailError As String = "<html><body>"
                EmailError &= "<br /><b>Date:" & Now() & "</b> <br /><br />"
                EmailError &= "<b>Request URL:</b>" & Request.Url.ToString & " <br /><br />"
                EmailError &= "Error Sending Email. Please check status of email server."
                EmailError &= "<b>" & ex.Message & "</b><br /><br />"
                EmailError &= "</body><br/><br/></html>"
                Dim file As String = "C:\Weblog\InfoSites_WebErrors.html"
                Dim sw As New StreamWriter(file, True)
                sw.Write(sw.NewLine & EmailError)
                sw.Close()
            Catch ex2 As Exception
            End Try
        End Try

        Try
            Dim file As String = "C:\Weblog\InfoSites_WebErrors.html"
            Dim sw As New StreamWriter(file, True)
            sw.Write(sw.NewLine & HTMLbody)
            sw.Close()
        Catch ex3 As Exception
            Try
                Dim LogError As String = "<html><body>"
                LogError &= "<br /><b>Date:" & Now() & "</b> <br /><br />"
                LogError &= "<b>Request URL:</b>" & Request.Url.ToString & " <br /><br />"
                LogError &= "Error writing to Weblog. Please check status of file://aciweb3/c$/WebLog/InfoSites_WebErrors.html."
                LogError &= "<b>" & ex3.Message & "</b><br /><br />"
                LogError &= "</body><br/><br/></html>"
                Dim MailObj As New System.Net.Mail.SmtpClient
                MailObj.Host = "aciexch2010.visit-aci.com"
                Dim msg As New MailMessage("Error@visit-aci.com", "WebErrors@visit-aci.com", "Error sending email - Franklin & Marshall College Info Site", LogError)
                msg.IsBodyHtml = False
                MailObj.Send(msg)
            Catch ex4 As Exception
            End Try
        End Try
        Server.ClearError()
        Session("ErrorDone") = True
        Response.Redirect("GenericErrorPage.aspx")
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a new session is started
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a session ends. 
        ' Note: The Session_End event is raised only when the sessionstate mode
        ' is set to InProc in the Web.config file. If session mode is set to StateServer 
        ' or SQLServer, the event is not raised.
    End Sub
</script>