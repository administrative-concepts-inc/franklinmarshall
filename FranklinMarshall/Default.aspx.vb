
Imports System.Data
Imports System.Data.SqlClient
Imports Common

Partial Class RCMDinfosite_Default
    Inherits System.Web.UI.Page
    Dim lParam As SortedList(Of Integer, String)

    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        Me.Title = "RCMD / Franklin & Marshall College"
    End Sub
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        CType(Me.Master.FindControl("header2"), HtmlGenericControl).Style.Remove("background-Image")
        CType(Me.Master.FindControl("header2"), HtmlGenericControl).Style.Remove("background-color")
        CType(Me.Master.FindControl("header2"), HtmlGenericControl).Style.Remove("padding-top")
        CType(Me.Master.FindControl("header2"), HtmlGenericControl).Style.Remove("height")
        CType(Me.Master.FindControl("header2"), HtmlGenericControl).Style.Add("background-image", "url('Images/city-background.jpg')")
        CType(Me.Master.FindControl("header2"), HtmlGenericControl).Style.Add("background-repeat", "no-repeat")
        CType(Me.Master.FindControl("header2"), HtmlGenericControl).Style.Add("background-size", "cover")
        CType(Me.Master.FindControl("header2"), HtmlGenericControl).Style.Add("background-position", "center")
        CType(Me.Master.FindControl("header2"), HtmlGenericControl).Style.Add("height", "250px")
        CType(Me.Master.FindControl("header2"), HtmlGenericControl).Style.Add("text-align", "center")
        CType(Me.Master.FindControl("header2"), HtmlGenericControl).Style.Add("font-size", "24pt")
        CType(Me.Master.FindControl("header4"), HtmlGenericControl).Style.Remove("background-Image")
        CType(Me.Master.FindControl("header4"), HtmlGenericControl).Style.Remove("background-color")
        CType(Me.Master.FindControl("header4"), HtmlGenericControl).Style.Remove("padding-top")
        CType(Me.Master.FindControl("header4"), HtmlGenericControl).Style.Remove("height")
        CType(Me.Master.FindControl("header4"), HtmlGenericControl).Style.Add("padding", "3%")
        CType(Me.Master.FindControl("hlRCMDlogo"), HyperLink).Style.Remove("background-Image")
        CType(Me.Master.FindControl("hlRCMDlogo"), HyperLink).Style.Remove("background-color")
        CType(Me.Master.FindControl("hlRCMDlogo"), HyperLink).Style.Remove("padding-top")
        CType(Me.Master.FindControl("hlRCMDlogo"), HyperLink).Style.Remove("height")
        CType(Me.Master.FindControl("hlRCMDlogo"), HyperLink).Style.Add("padding", "10px 40px 80px 40px")
        CType(Me.Master.FindControl("header6"), HtmlGenericControl).Visible = False
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        EditPageFlows(Session("PrevNext"), "Default.aspx", Nothing, Nothing, False, False)
    End Sub

End Class
