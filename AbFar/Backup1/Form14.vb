Imports System.IO
Public Class Form14
    Public address As String
    Public man As Boolean = False
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Then
            MsgBox("اطلاعات ورودی ناقص است", , "پیغام")

        Else
            address = Form1.TextBox3.Text
            Dim ocm As New System.Data.OleDb.OleDbCommand
            Dim ocn As New System.Data.OleDb.OleDbConnection
            Dim oda As New System.Data.OleDb.OleDbDataAdapter
            Dim dt As New DataTable
            ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
            "atabase Password=" + Me.TextBox10.Text + ""
            ocm.Connection = ocn
            ocm.CommandText = "DELETE * FROM Form"
            ocm.Parameters.Clear()
            ocn.Open()
            ocm.ExecuteNonQuery()
            ocn.Close()
            ocm.Dispose()
            ocn.Dispose()
            ocm.Connection = ocn
            address = Form1.TextBox3.Text
            ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
            "atabase Password=" + Me.TextBox10.Text + ""
            ocm.CommandText = "INSERT INTO Form (Ostan,Shahr,Name,Address)VALUES(@p1,@p2,@p3,@p4)"
            ocm.Parameters.Clear()
            ocm.Parameters.AddWithValue("@p1", TextBox1.Text)
            ocm.Parameters.AddWithValue("@p2", TextBox2.Text)
            ocm.Parameters.AddWithValue("@p3", TextBox3.Text)
            ocm.Parameters.AddWithValue("@p4", TextBox4.Text)
            ocn.Open()
            ocm.ExecuteNonQuery()
            ocn.Close()

            ocm.Dispose()
            ocn.Dispose()
            MsgBox("مشخصات با موفقیت ثبت شد", , "پیغام")

        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        GroupBox1.Visible = True
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        GroupBox1.Visible = False
    End Sub

    Private Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
        Close()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        GroupBox2.Visible = True
        If (File.Exists("c:\windows\system32\adr.txt")) Then
            Dim MyReader As StreamReader = File.OpenText("c:\windows\system32\adr.txt")
            TextBox7.Text = MyReader.ReadToEnd()
            MyReader.Close()
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        GroupBox2.Visible = False
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        If TextBox7.Text = "" Or TextBox10.Text = "" Then
            MsgBox("هر دو فیلد باید پر شوند", , "پیغام")
        Else
            If (File.Exists("c:\windows\system32\pas.txt")) Then
                File.WriteAllText("c:\windows\system32\pas.txt", TextBox10.Text)
            Else
                Dim Mycreator As StreamWriter = File.AppendText("c:\windows\system32\pas.txt")
                Mycreator.Write(TextBox10.Text)
                Mycreator.Close()

            End If
            If (File.Exists("c:\windows\system32\adr.txt")) Then
                File.WriteAllText("c:\windows\system32\adr.txt", TextBox7.Text)
            Else
                Dim Mycreator As StreamWriter = File.AppendText("c:\windows\system32\adr.txt")
                Mycreator.Write(TextBox7.Text)
                Mycreator.Close()

            End If
            MsgBox("تغییرات با موفقیت ثبت شد", , "پیغام")
            Form1.TextBox3.Text = TextBox7.Text
        End If
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        GroupBox3.Visible = True
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        
        If TextBox8.Text = "" Or TextBox9.Text = "" Then
            MsgBox("اطلاعات ورودی ناقص است", , "پیغام")

        Else
            Dim con As New System.Data.OleDb.OleDbConnection
            Dim ocm As New System.Data.OleDb.OleDbCommand
            Dim ocn As New System.Data.OleDb.OleDbConnection
            Dim oda As New System.Data.OleDb.OleDbDataAdapter
            Dim dt As New DataTable
            address = Form1.TextBox3.Text
            ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
            "atabase Password=" + Me.TextBox10.Text + ""
            ocm.Connection = ocn
            ocm.CommandText = "SELECT * FROM code where (user='" & TextBox6.Text & "' and ID='" & TextBox8.Text & "')"
            oda.SelectCommand = ocm
            If oda.Fill(dt) Then
                Button11.Enabled = True
                ocn.Close()
                ocm.Dispose()
                ocn.Dispose()
                ocm.Connection = ocn
                TextBox8.Enabled = False
                TextBox9.Enabled = False
                Button11.Enabled = True
            Else
                MsgBox("ورودی نامعتبر", , "پیغام")
                TextBox8.Text = ""
                TextBox9.Text = ""
            End If
        End If
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        GroupBox3.Visible = False
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        address = Form1.TextBox3.Text
        Dim ocm As New System.Data.OleDb.OleDbCommand
        Dim ocn As New System.Data.OleDb.OleDbConnection
        Dim oda As New System.Data.OleDb.OleDbDataAdapter
        Dim dt As New DataTable
        ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
            "atabase Password=" + Me.TextBox10.Text + ""
        ocm.Connection = ocn
        ocm.CommandText = "update code SET ID='" & TextBox9.Text & "' where user='" & TextBox6.Text & "'"
        ocn.Open()
        ocm.ExecuteNonQuery()
        ocn.Close()
        ocm.Dispose()
        ocn.Dispose()
        MsgBox("مشخصات با موفقیت ثبت شد", , "پیغام")
        TextBox8.Enabled = True
        TextBox9.Enabled = True
        TextBox8.Text = ""
        TextBox9.Text = ""
        Button11.Enabled = False
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        man = True
        Form8.Show()
        Form8.GroupBox3.Enabled = True
    End Sub
End Class