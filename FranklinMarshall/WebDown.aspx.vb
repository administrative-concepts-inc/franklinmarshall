
Partial Class Help
    Inherits System.Web.UI.Page

    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        If Session("MasterPageFile") <> "" Then
            Me.MasterPageFile = Session("MasterPageFile")
        End If
        Me.Title = "Website Down for Maintenance"
        CType(Me.Master.FindControl("header3"), HtmlGenericControl).InnerText = "Website Down for Maintenance"
    End Sub
End Class
