
Partial Class AssistanceServices
    Inherits System.Web.UI.Page

    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        Me.Title = "RCMD / F&M College Assistance"
    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        CType(Me.Master.FindControl("header6"), HtmlGenericControl).Visible = True
        CType(Me.Master.FindControl("header2"), HtmlGenericControl).Style.Add("background-Image", "none")
        CType(Me.Master.FindControl("header2"), HtmlGenericControl).Style.Add("background-color", "#f4f4f4")
        CType(Me.Master.FindControl("header2"), HtmlGenericControl).Style.Add("padding-top", "50px")
        CType(Me.Master.FindControl("header2"), HtmlGenericControl).Style.Add("height", "100px")
        CType(Me.Master.FindControl("header2"), HtmlGenericControl).InnerHtml = "Assistance Services"
        CType(Me.Master.FindControl("header6"), HtmlGenericControl).Visible = True
    End Sub
End Class
