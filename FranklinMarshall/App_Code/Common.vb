Imports Microsoft.VisualBasic
Imports system.Data
Imports System.Data.SqlClient
Imports System.Net.Mail

Public Class Common
    Public Shared Sub EditPageFlows(ByRef lPageFlows As SortedList(Of String, PageFlow), ByVal ThisPage As String, _
    ByVal PrevPage As String, ByVal NextPage As String, ByVal UsePrev As Boolean, ByVal UseNext As Boolean)
        If lPageFlows Is Nothing Then
            lPageFlows = New SortedList(Of String, PageFlow)
        End If
        Dim pf As PageFlow
        If lPageFlows.ContainsKey(ThisPage) Then
            pf = lPageFlows(ThisPage)
        Else
            pf = New PageFlow(PrevPage, NextPage)
            lPageFlows.Add(ThisPage, pf)
        End If
        If UsePrev Then
            pf.PrevPage = PrevPage
        End If
        If UseNext Then
            pf.NextPage = NextPage
        End If
    End Sub

    Public Shared Sub CountDeps(ByRef Spouses As Integer, ByRef DomesticPartners As Integer, ByRef Children As Integer, ByVal EnrollmentID As Integer)
        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("csACIweb").ConnectionString)
        Dim cmd As New SqlCommand("select count(*) from WebDependents where EnrollmentID=@EnrollmentID and Relationship=@Relationship", cn)
        cmd.Parameters.Add("@EnrollmentID", SqlDbType.Int).Value = EnrollmentID
        cmd.Parameters.Add("@Relationship", SqlDbType.VarChar, 1).Value = "S"
        cn.Open()
        Spouses = cmd.ExecuteScalar
        cmd.Parameters("@Relationship").Value = "P"
        DomesticPartners = cmd.ExecuteScalar()
        cmd.Parameters("@Relationship").Value = "C"
        Children = cmd.ExecuteScalar
        cn.Close()
    End Sub

    Public Shared Sub SendEnrollmentEmail(ByVal EnrollmentID As Integer, ByVal TestMode As Boolean)
        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("csACIweb").ConnectionString)
        Dim cmd As New SqlCommand("select gpno, MemberID, EmailSent, Email, FirstName, LastName, Policy, Answer from WebPrimaries as p" & _
            " join WebAddresses as a on a.EnrollmentID=p.EnrollmentID and a.AddressType='Permanent'" & _
            " join WebCoverage as c on c.EnrollmentID=p.EnrollmentID" & _
            " join WebInfo as i on i.EnrollmentID=p.EnrollmentID and i.Question = 'Program'" & _
            " where p.EnrollmentID=@EnrollmentID", cn)
        cmd.Parameters.Add("@EnrollmentID", SqlDbType.Int).Value = EnrollmentID
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        cn.Open()
        da.Fill(dt)
        cn.Close()
        If dt.Rows.Count > 0 Then
            Dim dr As DataRow = dt.Rows(0)
            If IsDBNull(dr("EmailSent")) Then
                cmd.CommandText = "select 1 as Display, 'Student Account' as Source, convert(varchar(100), TransID) as OrderNum, " & _
                    "Premium, AdminFee, BrokerAdminFee from AccountTransactions where EnrollmentID=@EnrollmentID " & _
                    "union select 2, 'Credit Card', ordernum, Premium, AdminFee, BrokerAdminFee from CCTransactions where OrderType='SALE' and approved='APPROVED' and EnrollmentID=@EnrollmentID " & _
                    "union select 3, 'eCheck', TrackingCode, Premium, AdminFee, BrokerAdminFee from CheckTransactions where ReturnCode='000' and EnrollmentID=@EnrollmentID order by Display"
                Dim dtPayments As New DataTable
                cn.Open()
                da.Fill(dtPayments)
                cn.Close()

                Dim HTMLbody As String = "<html><body>"
                HTMLbody &= "Thank You for your insurance enrollment.<br /><br />"
                HTMLbody &= "Transaction #: " & EnrollmentID & "<br /><br />"

                For Each drP As DataRow In dtPayments.Rows
                    Select Case drP("Source").ToString
                        Case "Student Account"
                            If drP("Premium") > 17.5 Then
                                'dr("Answer").ToString = "Intl" Then
                                HTMLbody &= "Your student account will be charged: " & FormatCurrency(drP("Premium") + drP("AdminFee") + drP("BrokerAdminFee"), 2, True, False) & " USD<br />"
                                HTMLbody &= "Confirmation #: " & drP("OrderNum").ToString & "<br /><br />"
                            Else
                                HTMLbody &= "Student account: No Additional Amount Due<br />"
                                HTMLbody &= "Confirmation #: " & drP("OrderNum").ToString & "<br /><br />"
                            End If
                        Case "Credit Card"
                            HTMLbody &= "Your credit card has been charged: " & FormatCurrency(drP("Premium") + drP("AdminFee") + drP("BrokerAdminFee"), 2, True, False) & " USD<br />"
                            HTMLbody &= "Confirmation #: " & drP("OrderNum").ToString & "<br /><br />"
                        Case "eCheck"
                            HTMLbody &= "Your account has been debited: " & FormatCurrency(drP("Premium") + drP("AdminFee") + drP("BrokerAdminFee"), 2, True, False) & " USD<br />"
                            HTMLbody &= "Confirmation #: " & drP("OrderNum").ToString & "<br /><br />"
                    End Select
                Next

                HTMLbody &= "Name: " & dr("FirstName").ToString & " " & dr("LastName").ToString & "<br />"
                HTMLbody &= "Member ID #: " & dr("MemberID").ToString & "<br />"
                HTMLbody &= "Policy: " & dr("Policy").ToString & "<br /><br />"

                HTMLbody &= "To view claim status, get claim forms and more visit <a href='http://www.visit-aci.com'>http://www.visit-aci.com</a>"

                HTMLbody &= "<br /><br />This is an automatically generated email.  Please do not reply to this email.  Further questions can be sent to RCMD.Global@rcmd.com"

                If TestMode Then
                    HTMLbody &= "<br /><br />This is a TEST ENROLLMENT and is NOT VALID."
                End If

                HTMLbody &= "</body></html>"

                Try
                    Dim MailObj As New System.Net.Mail.SmtpClient
                    MailObj.Host = "aciexch2010.visit-aci.com"
                    Dim msg As MailMessage
                    If TestMode <> True Then
                        msg = New MailMessage("rcmd@acitpa.com", dr("Email").ToString, "Enrollment Confirmation", HTMLbody)
                    Else
                        msg = New MailMessage("enrollment@visit-aci.com", dr("Email").ToString, "Enrollment Confirmation", HTMLbody)
                    End If
                    msg.ReplyTo = New MailAddress("RCMD.Global@rcmd.com")
                    msg.IsBodyHtml = True
                    MailObj.Send(msg)

                    cmd.CommandText = "update WebPrimaries set EmailSent=getdate() where EnrollmentID=@EnrollmentID"
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()
                Catch ex As Exception
                End Try
            End If
        End If
    End Sub

    Public Shared Function validZip(ByVal StateName As String, ByVal zipcode As String) As Boolean
        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("csACIweb").ConnectionString)
        Dim cmd As New SqlCommand("select zipcode from ZipCodes where  ZipCode='" & CStr(zipcode).Trim & "'  and  upper(State)='" & CStr(StateName).Trim.ToUpper & "'", cn)
        cmd.Parameters.Add("@zip", SqlDbType.VarChar).Value = CStr(zipcode).Trim
        cmd.Parameters.Add("@state", SqlDbType.VarChar).Value = CStr(StateName).Trim.ToUpper
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        cn.Open()
        da.Fill(dt)
        cn.Close()
        If dt.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

End Class

Public Class PageFlow
    Public PrevPage As String
    Public NextPage As String

    Public Sub New(ByVal sPrevPage As String, ByVal sNextPage As String)
        PrevPage = sPrevPage
        NextPage = sNextPage
    End Sub
End Class