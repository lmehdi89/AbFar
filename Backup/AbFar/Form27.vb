Imports System.IO
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Public Class Form27
    Public address As String
    Private da As OleDbDataAdapter
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
        TextBox1.Text = y + "/" + m + "/" + d
        Return 0
    End Function
    Private Sub Form27_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Toshamsi()
        TextBox1.Enabled = False
        address = Form1.TextBox3.Text
        Dim ocn As New System.Data.OleDb.OleDbConnection
        Dim ocm As New System.Data.OleDb.OleDbCommand
        Dim oda As New System.Data.OleDb.OleDbDataAdapter
        Dim ds As New DataSet()
        Dim i As Integer = 0

        address = Form1.TextBox3.Text

        ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
        "atabase Password=" + Form14.TextBox10.Text + ""
        ocm.Connection = ocn
        ocm.CommandText = "SELECT * FROM MSG"
        oda.SelectCommand = ocm
        da = New OleDbDataAdapter(ocm.CommandText, ocn)
        da.Fill(ds, "MSG")
        i = Me.BindingContext(ds, "MSG").Count
        If Not i = 0 Then
            Dim j As Integer = 0
            For j = 1 To i
                TextBox3.DataBindings.Add(New Binding("Text", ds, "MSG.MSG"))
                TextBox2.Text += TextBox3.Text
                TextBox3.DataBindings.Clear()
            Next j
            oda.Dispose()
            ocm.Dispose()
            ocn.Dispose()
            ds.Clear()
        Else
            MsgBox("پیامی وجود ندارد", , "پیغام")
        End If
        TextBox2.ReadOnly = True
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Close()
    End Sub
End Class