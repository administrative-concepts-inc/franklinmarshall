Imports Microsoft.VisualBasic
Imports system.Data
Imports System.Data.SqlClient
Imports System.Net.Mail
Imports System
Imports System.IO

Partial Class GenericErrorPage
    Inherits System.Web.UI.Page

    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        If Session("MasterPageFile") <> "" Then
            Me.MasterPageFile = Session("MasterPageFile")
        End If
    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        CType(Me.Master.FindControl("header6"), HtmlGenericControl).Visible = True
        CType(Me.Master.FindControl("header2"), HtmlGenericControl).Style.Add("background-Image", "none")
        CType(Me.Master.FindControl("header2"), HtmlGenericControl).Style.Add("background-color", "#f4f4f4")
        CType(Me.Master.FindControl("header2"), HtmlGenericControl).Style.Add("padding-top", "80px")
        CType(Me.Master.FindControl("header2"), HtmlGenericControl).Style.Add("height", "200px")
        CType(Me.Master.FindControl("header2"), HtmlGenericControl).InnerText = "Website Error"

        If Not Session("ErrorDone") = True Then
            If Not Request("aspxerrorpath") Is Nothing Then
                Dim HTMLbody As String = "<html><body>"
                HTMLbody &= "<br /><b>Date:" & Now() & "</b> <br /><br />"
                HTMLbody &= "<b>Request URL:</b>" & Request.Url.ToString & " <br /><br />"
                HTMLbody &= "IP Address:" & WebInfo.GetIP(Me.Request) & " <br /><br />"
                HTMLbody &= "Response.StatusCode :" & Response.StatusCode & " <br /><br />"
                HTMLbody &= "Response.Status :" & Response.Status & " <br /><br />"
                For Each o As Object In Session.Contents
                    HTMLbody &= "<b>" & o.ToString & "</b>" & "-" & Session(o.ToString).ToString & "<br /><br />"
                Next
                HTMLbody &= "</body><br/><br/></html>"
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
            End If
        End If
    End Sub
End Class
