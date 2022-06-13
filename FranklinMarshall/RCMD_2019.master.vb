
Partial Class RCMD_2019_Master
    Inherits System.Web.UI.MasterPage

    Public header As HtmlGenericControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        label4.Text = "©" & Today.Year.ToString & " Administrative Concepts, Inc. All rights reserved.<br/>"
        If Session("TestSiteID") Is Nothing OrElse Session("TestSiteID") <> 100 Then
            divTestMode.Visible = False
        Else
            divTestMode.Visible = True
        End If
    End Sub
End Class

