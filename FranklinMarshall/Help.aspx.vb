Imports System.Data
Imports System.Data.SqlClient
Imports System
Imports Common
Partial Class Help
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
        CType(Me.Master.FindControl("header2"), HtmlGenericControl).InnerText = "Website Help"
    End Sub

    Protected Sub lnkcomments_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkcomments.Click
        dvcomments.Visible = "True"
        dvthankyou.Visible = "False"
        txtName.Text = ""
        txtEmail.Text = ""
        txtComment.Text = ""
        txtComment.Text = ""

    End Sub

    Protected Sub btnsubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsubmit.Click

        Dim sessiondetails As String = ""
        If Session IsNot Nothing Then
            For Each o As Object In Session.Contents
                Select Case o.ToString.Trim
                    Case "MasterPageFile", "AllowDomPart", "PrevNext"
                    Case Else
                        sessiondetails &= o.ToString & "-" & Session(o.ToString).ToString & vbCrLf
                End Select
            Next
        End If

        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("csACIweb").ConnectionString)
        Dim cmd As New SqlCommand
        cmd.Connection = cn
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        cmd.Parameters.Clear()

        cmd.CommandText = "INSERT INTO WebTickets (URL,Name,EmailId,Comment,SessionDetails,Clear ) values(@URL,@Name,@EmailId,@Comment,@SessionDetails,@Clear) "
        cmd.Parameters.Add("@URL", SqlDbType.VarChar, 150).Value = Request.Url.ToString
        cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = txtName.Text
        cmd.Parameters.Add("@EmailId", SqlDbType.VarChar).Value = txtEmail.Text
        cmd.Parameters.Add("@Comment", SqlDbType.text).Value = txtComment.Text
        cmd.Parameters.Add("@SessionDetails", SqlDbType.text)

        If sessiondetails = "" Then
            cmd.Parameters("@SessionDetails").Value = DBNull.Value
        Else
            cmd.Parameters("@SessionDetails").Value = sessiondetails
        End If

        cmd.Parameters.Add("@Clear", SqlDbType.Bit, 50).Value = False
        cn.Open()
        cmd.ExecuteScalar()
        cn.Close()
        dvthankyou.Visible = "True"
        dvcomments.Visible = "False"

    End Sub
End Class
