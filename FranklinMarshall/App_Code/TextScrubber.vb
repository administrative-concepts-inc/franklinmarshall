Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports system.Data

Public Class TextScrubber
    Public Shared Function Cleaner(ByVal STRTemp As String) As String
        Dim TXT As String = STRTemp.Trim
        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("csACIweb").ConnectionString)
        Dim cmd As New SqlCommand("select char(charnumber) as testchar, repvarchar from WebTextReplacements", cn)
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New Datatable
        da.Fill(dt)
        Dim dChar As New System.Collections.Generic.Dictionary(Of String, String)
        If dt.Rows.Count > 0 Then
            For Each dr As DataRow In dt.Rows
                If Not dChar.ContainsKey(dr("testchar").ToString) AndAlso dr("testchar").ToString <> "" Then
                    dChar.Add(dr("testchar").ToString, dr("repvarchar").ToString)
                End If
            Next
        End If
        Dim pair As System.Collections.Generic.KeyValuePair(Of String, String)
        For Each pair In dChar
            If TXT.Contains(pair.Key) Then
                TXT = TXT.Replace(pair.Key, pair.Value)
            End If
        Next
        TXT = Regex.Replace(TXT, "[^\u0000-\u007F]", Space(1))
        Return TXT
    End Function
End Class
