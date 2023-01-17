Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Public Class Form6
    Public address As String
    Public f As Boolean = True
    Public BL As Boolean = False
    Public s As Integer = 1
    Public rpt As New CrystalReport4
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
        TextBox1.Text = d
        TextBox12.Text = m
        TextBox13.Text = y
        Return 0
    End Function

    Private Sub Button48_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button48.Click
        If Not GroupBox2.Visible And f Then
            address = Form1.TextBox3.Text
            Dim ocn As New System.Data.OleDb.OleDbConnection
            Dim ocm As New System.Data.OleDb.OleDbCommand
            Dim oda As New System.Data.OleDb.OleDbDataAdapter

            Dim ds As New DataSet()
            Dim strSql As String
            Dim strCon As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
            "atabase Password=" + Form14.TextBox10.Text + ""
            Dim da As OleDb.OleDbDataAdapter
            Dim con As OleDb.OleDbConnection
            strSql = "select * from Form"
            con = New OleDb.OleDbConnection(strCon)
            con.Open()
            da = New OleDb.OleDbDataAdapter(strSql, con)
            da.Fill(ds, "Form")
            TextBox2.DataBindings.Add(New Binding("Text", ds, "Form.Ostan"))
            TextBox3.DataBindings.Add(New Binding("Text", ds, "Form.Shahr"))
            TextBox10.DataBindings.Add(New Binding("Text", ds, "Form.Shahr"))
            TextBox9.DataBindings.Add(New Binding("Text", ds, "Form.Name2"))
            TextBox11.DataBindings.Add(New Binding("Text", ds, "Form.Address"))

            ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\Data.mdb"
            ocm.Connection = ocn
            ocm.CommandText = "SELECT * FROM Roostaha"
            oda.SelectCommand = ocm
            da = New OleDbDataAdapter(ocm.CommandText, ocn)
            da.Fill(ds, "Roostaha")

            Do
                TextBox16.Text = TextBox15.Text
                TextBox15.DataBindings.Add(New Binding("Text", ds, "Roostaha.roosta"))
                ComboBox1.Items.Add(TextBox15.Text)
                Me.BindingContext(ds, "Roostaha").Position += 1
                TextBox15.DataBindings.Clear()
                If TextBox15.Text = TextBox16.Text Then
                    Exit Do
                End If
            Loop

            oda.Dispose()
            ocm.Dispose()
            ocn.Dispose()
            GroupBox2.Visible = True
            f = False
            TextBox2.ReadOnly = True
            TextBox2.BackColor = Color.White
            TextBox3.ReadOnly = True
            TextBox3.BackColor = Color.White
            TextBox9.ReadOnly = True
            TextBox9.BackColor = Color.White
            TextBox10.ReadOnly = True
            TextBox10.BackColor = Color.White
            TextBox11.ReadOnly = True
        ElseIf Not GroupBox2.Visible Then
            GroupBox2.Visible = True
        Else
            GroupBox2.Visible = False
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox4.BorderStyle = BorderStyle.None Then
            Dim result As Integer = MsgBox("آيا گزارش جاری را ذخیره می کنید؟", MsgBoxStyle.YesNoCancel)
            If result = MsgBoxResult.Yes Then
                address = Form1.TextBox3.Text
                Dim ocn As New System.Data.OleDb.OleDbConnection
                Dim ocm As New System.Data.OleDb.OleDbCommand
                Dim oda As New System.Data.OleDb.OleDbDataAdapter
                Dim ds As New DataSet()

                ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
            "atabase Password=" + Form14.TextBox10.Text + ""
                ocm.Connection = ocn
                ocm.CommandText = "update Gozaresh SET NUM=0"
                ocn.Open()
                ocm.ExecuteNonQuery()
                ocn.Close()
                ocm.Dispose()
                ocn.Dispose()
                TextBox14.Visible = False
                ComboBox1.Visible = True
                ComboBox1.Text = ""
                TextBox4.Text = ""
                TextBox5.Text = ""
                TextBox6.Text = ""
                TextBox7.Text = ""
                TextBox8.Text = ""
                TextBox4.BorderStyle = BorderStyle.FixedSingle
                TextBox5.BorderStyle = BorderStyle.FixedSingle
                TextBox6.BorderStyle = BorderStyle.FixedSingle
                TextBox7.BorderStyle = BorderStyle.FixedSingle
                TextBox8.BorderStyle = BorderStyle.FixedSingle
                Close()
            ElseIf result = MsgBoxResult.No Then
                address = Form1.TextBox3.Text
                Dim ocn As New System.Data.OleDb.OleDbConnection
                Dim ocm As New System.Data.OleDb.OleDbCommand
                Dim oda As New System.Data.OleDb.OleDbDataAdapter
                Dim ds As New DataSet()

                ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
            "atabase Password=" + Form14.TextBox10.Text + ""
                ocm.Connection = ocn
                ocm.CommandText = "DELETE FROM Gozaresh WHERE NUM >'" & 0 & "'"
                ocn.Open()
                ocm.ExecuteNonQuery()
                ocn.Close()
                ocm.Dispose()
                ocn.Dispose()
                TextBox14.Visible = False
                ComboBox1.Visible = True
                ComboBox1.Text = ""
                TextBox4.Text = ""
                TextBox5.Text = ""
                TextBox6.Text = ""
                TextBox7.Text = ""
                TextBox8.Text = ""
                TextBox4.BorderStyle = BorderStyle.FixedSingle
                TextBox5.BorderStyle = BorderStyle.FixedSingle
                TextBox6.BorderStyle = BorderStyle.FixedSingle
                TextBox7.BorderStyle = BorderStyle.FixedSingle
                TextBox8.BorderStyle = BorderStyle.FixedSingle
                Close()
            End If
        Else
            Close()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim ocm As New System.Data.OleDb.OleDbCommand
        Dim oda As New System.Data.OleDb.OleDbDataAdapter
        Dim ocn As New System.Data.OleDb.OleDbConnection

        If ComboBox1.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or TextBox8.Text = "" Then
            MsgBox("مشخصات فرم گزارش کامل نیست", , "پیغام")
        Else
            address = Form1.TextBox3.Text
            ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
            "atabase Password=" + Form14.TextBox10.Text + ""
            ocm.Connection = ocn
            ocm.CommandText = "INSERT INTO Gozaresh (roosta,LN,LG,LGE,LP,Y,M,D,NUM) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)"
            ocm.Parameters.Clear()
            ocm.Parameters.AddWithValue("@p1", ComboBox1.SelectedItem)
            ocm.Parameters.AddWithValue("@p2", TextBox4.Text)
            ocm.Parameters.AddWithValue("@p3", TextBox5.Text)
            ocm.Parameters.AddWithValue("@p4", TextBox6.Text)
            ocm.Parameters.AddWithValue("@p5", TextBox8.Text)
            ocm.Parameters.AddWithValue("@p6", TextBox13.Text)
            ocm.Parameters.AddWithValue("@p7", TextBox12.Text)
            ocm.Parameters.AddWithValue("@p8", TextBox1.Text)
            ocm.Parameters.AddWithValue("@p9", s)
            ocn.Open()
            ocm.ExecuteNonQuery()
            ocn.Close()
            ocm.Dispose()
            ocn.Dispose()
            TextBox14.Visible = True
            TextBox14.Text = ComboBox1.SelectedItem
            ComboBox1.Visible = False
            TextBox7.ReadOnly = False
            TextBox7.Text = TextBox4.Text - TextBox5.Text
            TextBox7.ReadOnly = True
            TextBox4.BorderStyle = BorderStyle.None
            TextBox5.BorderStyle = BorderStyle.None
            TextBox6.BorderStyle = BorderStyle.None
            TextBox7.BorderStyle = BorderStyle.None
            TextBox8.BorderStyle = BorderStyle.None
        End If
    End Sub

    Private Sub Form6_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Toshamsi()
        TextBox1.ReadOnly = True
        TextBox12.ReadOnly = True
        TextBox13.ReadOnly = True
        TextBox1.BackColor = Color.White
        TextBox12.BackColor = Color.White
        TextBox13.BackColor = Color.White
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If TextBox4.BorderStyle = BorderStyle.None Then
            Dim result As Integer = MsgBox("آيا گزارش جاری را ذخیره می کنید؟", MsgBoxStyle.YesNoCancel)
            If result = MsgBoxResult.Yes Then
                address = Form1.TextBox3.Text
                Dim ocn As New System.Data.OleDb.OleDbConnection
                Dim ocm As New System.Data.OleDb.OleDbCommand
                Dim oda As New System.Data.OleDb.OleDbDataAdapter
                Dim ds As New DataSet()

                ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
            "atabase Password=" + Form14.TextBox10.Text + ""
                ocm.Connection = ocn
                ocm.CommandText = "update Gozaresh SET NUM=0"
                ocn.Open()
                ocm.ExecuteNonQuery()
                ocn.Close()
                ocm.Dispose()
                ocn.Dispose()
                TextBox14.Visible = False
                ComboBox1.Visible = True
                ComboBox1.Text = ""
                TextBox4.Text = ""
                TextBox5.Text = ""
                TextBox6.Text = ""
                TextBox7.Text = ""
                TextBox8.Text = ""
                TextBox4.BorderStyle = BorderStyle.FixedSingle
                TextBox5.BorderStyle = BorderStyle.FixedSingle
                TextBox6.BorderStyle = BorderStyle.FixedSingle
                TextBox7.BorderStyle = BorderStyle.FixedSingle
                TextBox8.BorderStyle = BorderStyle.FixedSingle

            ElseIf result = MsgBoxResult.No Then
                address = Form1.TextBox3.Text
                Dim ocn As New System.Data.OleDb.OleDbConnection
                Dim ocm As New System.Data.OleDb.OleDbCommand
                Dim oda As New System.Data.OleDb.OleDbDataAdapter
                Dim ds As New DataSet()

                ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
            "atabase Password=" + Form14.TextBox10.Text + ""
                ocm.Connection = ocn
                ocm.CommandText = "DELETE FROM Gozaresh WHERE NUM >'" & 0 & "'"
                ocn.Open()
                ocm.ExecuteNonQuery()
                ocn.Close()
                ocm.Dispose()
                ocn.Dispose()
                TextBox14.Visible = False
                ComboBox1.Visible = True
                ComboBox1.Text = ""
                TextBox4.Text = ""
                TextBox5.Text = ""
                TextBox6.Text = ""
                TextBox7.Text = ""
                TextBox8.Text = ""
                TextBox4.BorderStyle = BorderStyle.FixedSingle
                TextBox5.BorderStyle = BorderStyle.FixedSingle
                TextBox6.BorderStyle = BorderStyle.FixedSingle
                TextBox7.BorderStyle = BorderStyle.FixedSingle
                TextBox8.BorderStyle = BorderStyle.FixedSingle

            End If
        Else
            MsgBox("شما مجاز به ایجاد گزارش جدید نیستید", , "پیغام")
        End If
    End Sub


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If TextBox4.BorderStyle = BorderStyle.None Then
            TextBox17.Text = TextBox13.Text + "/" + TextBox12.Text + "/" + TextBox1.Text
            rpt.SetParameterValue("A1", TextBox2.Text)
            rpt.SetParameterValue("A2", TextBox3.Text)
            rpt.SetParameterValue("A3", TextBox17.Text)
            rpt.SetParameterValue("A4", TextBox3.Text)
            rpt.SetParameterValue("A5", TextBox14.Text)
            rpt.SetParameterValue("A6", TextBox4.Text)
            rpt.SetParameterValue("A7", TextBox5.Text)
            rpt.SetParameterValue("A8", TextBox6.Text)
            rpt.SetParameterValue("A9", TextBox7.Text)
            rpt.SetParameterValue("A10", TextBox8.Text)
            rpt.SetParameterValue("A11", TextBox9.Text)
            rpt.SetParameterValue("A12", TextBox3.Text)
            rpt.SetParameterValue("A13", TextBox11.Text)
            CrystalReportViewer1.ReportSource = rpt
            CrystalReportViewer1.PrintReport()
            TextBox14.Visible = False
            ComboBox1.Visible = True
            ComboBox1.Text = ""
            TextBox4.Text = ""
            TextBox5.Text = ""
            TextBox6.Text = ""
            TextBox7.Text = ""
            TextBox8.Text = ""
            TextBox4.BorderStyle = BorderStyle.FixedSingle
            TextBox5.BorderStyle = BorderStyle.FixedSingle
            TextBox6.BorderStyle = BorderStyle.FixedSingle
            TextBox7.BorderStyle = BorderStyle.FixedSingle
            TextBox8.BorderStyle = BorderStyle.FixedSingle
        Else
            MsgBox("گزارشی ثبت نشده است", , "پیغام")
        End If
    End Sub
    Private Sub GroupBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GroupBox1.MouseDown
        BL = True
    End Sub
    Private Sub GroupBox1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GroupBox1.MouseMove
        If e.Y <= 20 And e.X <= 25 Then
            GroupBox1.Cursor = Cursors.SizeAll
        Else
            GroupBox1.Cursor = Cursors.Default
        End If
        If BL And e.Y <= 20 And e.X <= 25 Then
            GroupBox1.Location = New Point((GroupBox1.Location.X) + e.X, (GroupBox1.Location.Y) + e.Y)
        End If
    End Sub
    Private Sub GroupBox1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GroupBox1.MouseUp
        BL = False
    End Sub

    Private Sub TextBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress
        If Not IsNumeric(e.KeyChar) And e.KeyChar <> Convert.ToChar(Keys.Back) And e.KeyChar <> Convert.ToChar(Keys.Delete) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox5.KeyPress
        If Not IsNumeric(e.KeyChar) And e.KeyChar <> Convert.ToChar(Keys.Back) And e.KeyChar <> Convert.ToChar(Keys.Delete) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox6.KeyPress
        If Not IsNumeric(e.KeyChar) And e.KeyChar <> Convert.ToChar(Keys.Back) And e.KeyChar <> Convert.ToChar(Keys.Delete) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox8_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox8.KeyPress
        If Not IsNumeric(e.KeyChar) And e.KeyChar <> Convert.ToChar(Keys.Back) And e.KeyChar <> Convert.ToChar(Keys.Delete) Then
            e.Handled = True
        End If
    End Sub
End Class