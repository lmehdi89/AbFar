Imports System.IO
Public Class Form26
    Public address As String
    Public Function Toshamsi() As String
        Dim x As New System.Globalization.PersianCalendar()
        Dim y As String = x.GetYear(Today)
        Dim m As String = x.GetMonth(Today)
        Dim d As String = x.GetDayOfMonth(Today)
        If Len(Trim(d)) < 2 Then
            d = "0" & d
        End If
        If Len(Trim(m)) < 2 Then
            m = "0" & m
        End If
        TextBox4.Text = y + "/" + m + "/" + d
        Return 0
    End Function
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Form26_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Toshamsi()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TextBox5.Text = Label1.Text + " : " + TextBox1.Text + "                    " + TextBox4.Text & vbCrLf & TextBox2.Text + " : " + Label2.Text & vbCrLf & TextBox3.Text & vbCrLf & vbCrLf & "****************************************" & vbCrLf & vbCrLf
        address = Form1.TextBox3.Text
        Dim ocm As New System.Data.OleDb.OleDbCommand
        Dim oda As New System.Data.OleDb.OleDbDataAdapter
        Dim ocn As New System.Data.OleDb.OleDbConnection

        ocn.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
        "atabase Password=" + Form14.TextBox10.Text + "")
        ocm.Connection = ocn
        ocm.CommandText = "INSERT INTO MSG (MSG) VALUES (@p1)"
        ocm.Parameters.Clear()
        ocm.Parameters.AddWithValue("@p1", TextBox5.Text)
        ocn.Open()
        ocm.ExecuteNonQuery()
        ocn.Close()
        ocm.Dispose()
        ocn.Dispose()
        TextBox5.Text = ""
        TextBox3.Text = ""
        TextBox2.Text = ""
        TextBox1.Text = ""

    End Sub
End Class