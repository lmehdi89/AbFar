Imports System.IO
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Public Class Form16
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox2.Text = "" Or TextBox1.Text = "" Then
            MsgBox("اطلاعات ورودی ناقص است", , "پیغام")

        Else
            Dim con As New System.Data.OleDb.OleDbConnection
            Dim ocm As New System.Data.OleDb.OleDbCommand
            Dim ocn As New System.Data.OleDb.OleDbConnection
            Dim oda As New System.Data.OleDb.OleDbDataAdapter
            Dim dt As New DataTable
            ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\data.mdb"
            ocm.Connection = ocn
            ocm.CommandText = "SELECT * FROM code where (user='" & TextBox3.Text & "' and ID='" & TextBox2.Text & "')"
            oda.SelectCommand = ocm
            If oda.Fill(dt) Then
                Button2.Enabled = True
                ocn.Close()
                ocm.Dispose()
                ocn.Dispose()
                ocm.Connection = ocn
                TextBox1.Enabled = False
                TextBox2.Enabled = False
            Else
                MsgBox("ورودی نامعتبر", , "پیغام")
                TextBox1.Text = ""
                TextBox2.Text = ""
            End If
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim ocm As New System.Data.OleDb.OleDbCommand
        Dim ocn As New System.Data.OleDb.OleDbConnection
        Dim oda As New System.Data.OleDb.OleDbDataAdapter
        Dim dt As New DataTable
        ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\Data.mdb"
        ocm.Connection = ocn
        ocm.CommandText = "update code SET ID='" & TextBox1.Text & "' where user='" & TextBox3.Text & "'"
        ocn.Open()
        ocm.ExecuteNonQuery()
        ocn.Close()
        ocm.Dispose()
        ocn.Dispose()
        MsgBox("مشخصات با موفقیت ثبت شد", , "پیغام")
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox1.Text = ""
        TextBox2.Text = ""
        Button2.Enabled = False
    End Sub
End Class