Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Public Class Form10
    Public address As String
    Public BL As Boolean = False
    Public f As Boolean = True
    Public allow As Boolean = False
    Public test As Boolean = True
    Dim count As Integer = 0
    Public t As Boolean = True
    Private da As OleDbDataAdapter
    Private ds As New DataSet
    Public y As Integer
    Public x As Integer
    Dim rpt As New CrystalReport15
    Dim rpt1 As New CrystalReport16
    Private Sub GroupBox4_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GroupBox4.MouseDown
        BL = True
    End Sub
    Private Sub GroupBox4_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GroupBox4.MouseMove
        If e.Y <= 20 And e.X <= 25 Then
            GroupBox4.Cursor = Cursors.SizeAll
        Else
            GroupBox4.Cursor = Cursors.Default
        End If
        If BL And e.Y <= 20 And e.X <= 25 Then
            GroupBox4.Location = New Point((GroupBox4.Location.X) + e.X, (GroupBox4.Location.Y) + e.Y)
        End If
    End Sub
    Private Sub GroupBox4_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GroupBox4.MouseUp
        BL = False
    End Sub

    Private Sub TextBox7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox7.KeyPress
        If Not IsNumeric(e.KeyChar) And e.KeyChar <> Convert.ToChar(Keys.Back) And e.KeyChar <> Convert.ToChar(Keys.Delete) Then
            e.Handled = True
        End If
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged
        If ComboBox4.Text = "07" Or ComboBox4.Text = "08" Or ComboBox4.Text = "09" Or ComboBox4.Text = "10" Or ComboBox4.Text = "11" Or ComboBox4.Text = "12" Then
            If ComboBox3.SelectedItem = "31" Then
                ComboBox3.SelectedItem = "30"
            End If
        End If
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox4.SelectedIndexChanged
        If ComboBox4.Text = "07" Or ComboBox4.Text = "08" Or ComboBox4.Text = "09" Or ComboBox4.Text = "10" Or ComboBox4.Text = "11" Or ComboBox4.Text = "12" Then
            If ComboBox3.SelectedItem = "31" Then
                ComboBox3.SelectedItem = "30"
            End If
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If Not test Then
            Exit Sub
        Else
            Dim ocn As New System.Data.OleDb.OleDbConnection
            Dim ocm As New System.Data.OleDb.OleDbCommand
            Dim oda As New System.Data.OleDb.OleDbDataAdapter
            Dim ds As New DataSet()

            ComboBox2.Items.Clear()
            ComboBox2.Text = ""

            If Not ComboBox1.SelectedItem = "کل روستاها" Then


                ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\Data.mdb"
                ocm.Connection = ocn
                ocm.CommandText = "SELECT roosta FROM Roostaha where bakhsh='" & ComboBox1.SelectedItem & "'"
                oda.SelectCommand = ocm
                da = New OleDbDataAdapter(ocm.CommandText, ocn)
                da.Fill(ds, "Roostaha")

                Do
                    TextBox2.Text = TextBox1.Text
                    TextBox1.DataBindings.Add(New Binding("Text", ds, "Roostaha.roosta"))
                    ComboBox2.Items.Add(TextBox1.Text)
                    Me.BindingContext(ds, "Roostaha").Position += 1
                    TextBox1.DataBindings.Clear()
                    If TextBox1.Text = TextBox2.Text Then
                        Exit Do
                    End If
                Loop

                oda.Dispose()
                ocm.Dispose()
                ocn.Dispose()
            Else


                ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\Data.mdb"
                ocm.Connection = ocn
                ocm.CommandText = "SELECT roosta FROM Roostaha"
                oda.SelectCommand = ocm
                da = New OleDbDataAdapter(ocm.CommandText, ocn)
                da.Fill(ds, "Roostaha")

                Do
                    TextBox2.Text = TextBox1.Text
                    TextBox1.DataBindings.Add(New Binding("Text", ds, "Roostaha.roosta"))
                    ComboBox2.Items.Add(TextBox1.Text)
                    Me.BindingContext(ds, "Roostaha").Position += 1
                    TextBox1.DataBindings.Clear()
                    If TextBox1.Text = TextBox2.Text Then
                        Exit Do
                    End If
                Loop
                oda.Dispose()
                ocm.Dispose()
                ocn.Dispose()
            End If
            Button42.Visible = True
        End If
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Dim ocm As New System.Data.OleDb.OleDbCommand
        Dim oda As New System.Data.OleDb.OleDbDataAdapter
        Dim ocn As New System.Data.OleDb.OleDbConnection
        If (ComboBox3.Text = "روز" Or ComboBox4.Text = "ماه" Or TextBox7.Text = "") Or ComboBox1.Text = "" Or ComboBox2.Text = "" Then
            MsgBox("مشخصات فرم گزارش کامل نیست", , "پیغام")
        Else
            If count > 14 Then
                MsgBox("فرم گزارش جدید ایجاد کنید", , "پیغام")
            Else
                count += 1
                t = False
                ListBox1.Items.Add(ComboBox2.SelectedItem)
                ListBox2.Items.Add(ComboBox1.SelectedItem)
                ListBox3.Items.Add(TextBox7.Text + "/" + ComboBox4.Text + "/" + ComboBox3.Text)
                ListBox4.Items.Add(TextBox8.Text)
                ListBox5.Items.Add(TextBox9.Text)
                ListBox6.Items.Add(TextBox10.Text)
                address = Form1.TextBox3.Text
                ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
            "atabase Password=" + Form14.TextBox10.Text + ""
                ocm.Connection = ocn
                ocm.CommandText = "INSERT INTO Tamirat2 (bishtar,tools,ellat,Y,M,D,roosta,bakhsh,NUM) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)"
                ocm.Parameters.Clear()
                ocm.Parameters.AddWithValue("@p1", TextBox10.Text)
                ocm.Parameters.AddWithValue("@p2", TextBox9.Text)
                ocm.Parameters.AddWithValue("@p3", TextBox8.Text)
                ocm.Parameters.AddWithValue("@p4", TextBox7.Text)
                ocm.Parameters.AddWithValue("@p5", ComboBox4.Text)
                ocm.Parameters.AddWithValue("@p6", ComboBox3.Text)
                ocm.Parameters.AddWithValue("@p7", ComboBox2.Text)
                ocm.Parameters.AddWithValue("@p8", ComboBox1.Text)
                ocm.Parameters.AddWithValue("@p9", count)

                ocn.Open()
                ocm.ExecuteNonQuery()
                ocn.Close()
                ocm.Dispose()
                ocn.Dispose()

                TextBox10.Text = ""
                TextBox7.Text = ""
                TextBox8.Text = ""
                TextBox9.Text = ""
                TextBox10.Text = ""
                ComboBox3.Text = "روز"
                ComboBox4.Text = "ماه"
                Button42_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub Button42_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button42.Click
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox2.Items.Clear()
        Dim ocn As New System.Data.OleDb.OleDbConnection
        Dim ocm As New System.Data.OleDb.OleDbCommand
        Dim oda As New System.Data.OleDb.OleDbDataAdapter
        Dim ds As New DataSet()

        ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\Data.mdb"
        ocm.Connection = ocn
        ocm.CommandText = "SELECT roosta FROM Roostaha"
        oda.SelectCommand = ocm
        da = New OleDbDataAdapter(ocm.CommandText, ocn)
        da.Fill(ds, "Roostaha")

        Do
            TextBox2.Text = TextBox1.Text
            TextBox1.DataBindings.Add(New Binding("Text", ds, "Roostaha.roosta"))
            ComboBox2.Items.Add(TextBox1.Text)
            Me.BindingContext(ds, "Roostaha").Position += 1
            TextBox1.DataBindings.Clear()
            If TextBox1.Text = TextBox2.Text Then
                Exit Do
            End If
        Loop
        oda.Dispose()
        ocm.Dispose()
        ocn.Dispose()
        Button42.Visible = False
        test = True
    End Sub

    Private Sub Button45_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button45.Click
        If Not GroupBox2.Visible Then
            GroupBox2.Visible = True
        Else
            GroupBox2.Visible = False
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Not GroupBox3.Visible Then
            GroupBox3.Visible = True
        Else
            GroupBox3.Visible = False
        End If
    End Sub

    Private Sub Button44_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button44.Click
        If Not GroupBox6.Visible And f Then
            address = Form1.TextBox3.Text
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
            TextBox3.DataBindings.Add(New Binding("Text", ds, "Form.Shahr"))
            f = False
            GroupBox6.Visible = True
            TextBox3.DataBindings.Clear()
        ElseIf Not GroupBox6.Visible Then
            GroupBox6.Visible = True
        Else
            GroupBox6.Visible = False
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Button42_Click(sender, e)
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        TextBox10.Text = ""
        ComboBox3.Text = "روز"
        ComboBox4.Text = "ماه"
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If allow Then
            address = Form1.TextBox3.Text
            Dim ocn As New System.Data.OleDb.OleDbConnection
            Dim ocm As New System.Data.OleDb.OleDbCommand
            Dim oda As New System.Data.OleDb.OleDbDataAdapter
            Dim ds As New DataSet()

            Button42_Click(sender, e)
            ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
            "atabase Password=" + Form14.TextBox10.Text + ""
            ocm.Connection = ocn
            ocm.CommandText = "update Tamirat2 SET NUM=0"
            ocn.Open()
            ocm.ExecuteNonQuery()
            ocn.Close()
            ocm.Dispose()
            ocn.Dispose()
            TextBox7.Text = ""
            TextBox8.Text = ""
            TextBox9.Text = ""
            TextBox10.Text = ""
            ComboBox3.Text = "روز"
            ComboBox4.Text = "ماه"
            ListBox1.Items.Clear()
            ListBox2.Items.Clear()
            ListBox3.Items.Clear()
            ListBox4.Items.Clear()
            ListBox5.Items.Clear()
            ListBox6.Items.Clear()

            count = 0
            t = True
            allow = False

        Else
            address = Form1.TextBox3.Text
            Dim ocn As New System.Data.OleDb.OleDbConnection
            Dim ocm As New System.Data.OleDb.OleDbCommand
            Dim oda As New System.Data.OleDb.OleDbDataAdapter
            Dim ds As New DataSet()

            Button42_Click(sender, e)
            ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
            "atabase Password=" + Form14.TextBox10.Text + ""
            ocm.Connection = ocn
            ocm.CommandText = "DELETE FROM Tamirat2 WHERE NUM >'" & 0 & "'"
            ocn.Open()
            ocm.ExecuteNonQuery()
            ocn.Close()
            ocm.Dispose()
            ocn.Dispose()
            TextBox7.Text = ""
            TextBox8.Text = ""
            TextBox9.Text = ""
            TextBox10.Text = ""
            ComboBox3.Text = "روز"
            ComboBox4.Text = "ماه"
            ListBox1.Items.Clear()
            ListBox2.Items.Clear()
            ListBox3.Items.Clear()
            ListBox4.Items.Clear()
            ListBox5.Items.Clear()
            ListBox6.Items.Clear()
            count = 0
            t = True
            allow = False
        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        test = False
        Dim ocn As New System.Data.OleDb.OleDbConnection
        Dim ocm As New System.Data.OleDb.OleDbCommand
        Dim oda As New System.Data.OleDb.OleDbDataAdapter
        Dim ds As New DataSet()
        ComboBox2.Text = ComboBox2.SelectedText
        ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\Data.mdb"
        ocm.Connection = ocn
        ocm.CommandText = "SELECT bakhsh FROM Roostaha where roosta='" & ComboBox2.SelectedItem & "'"
        oda.SelectCommand = ocm
        da = New OleDbDataAdapter(ocm.CommandText, ocn)
        da.Fill(ds, "Roostaha")
        ComboBox1.DataBindings.Add(New Binding("text", ds, "Roostaha.bakhsh"))
        ComboBox1.DataBindings.Clear()
        oda.Dispose()
        ocm.Dispose()
        ocn.Dispose()
        Button42.Visible = True
    End Sub

    Private Sub Form10_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        y = Me.Size.Height
        x = Me.Size.Width
        GroupBox4.Location = New System.Drawing.Point((x / 2), (y / 20))
        GroupBox6.Location = New System.Drawing.Point(49, (y / 5))
        Button3.Location = New System.Drawing.Point((x / 2), (y / 20) + 610)
        Button44.Location = New System.Drawing.Point(15, (y / 5))
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If allow Then
            address = Form1.TextBox3.Text
            Dim ocn As New System.Data.OleDb.OleDbConnection
            Dim ocm As New System.Data.OleDb.OleDbCommand
            Dim oda As New System.Data.OleDb.OleDbDataAdapter
            Dim ds As New DataSet()

            Button42_Click(sender, e)
            ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
            "atabase Password=" + Form14.TextBox10.Text + ""
            ocm.Connection = ocn
            ocm.CommandText = "update Tamirat2 SET NUM=0"
            ocn.Open()
            ocm.ExecuteNonQuery()
            ocn.Close()
            ocm.Dispose()
            ocn.Dispose()
            Close()
        Else
            address = Form1.TextBox3.Text
            Dim ocn As New System.Data.OleDb.OleDbConnection
            Dim ocm As New System.Data.OleDb.OleDbCommand
            Dim oda As New System.Data.OleDb.OleDbDataAdapter
            Dim ds As New DataSet()

            Button42_Click(sender, e)
            ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
            "atabase Password=" + Form14.TextBox10.Text + ""
            ocm.Connection = ocn
            ocm.CommandText = "DELETE FROM Tamirat2 WHERE NUM >'" & 0 & "'"
            ocn.Open()
            ocm.ExecuteNonQuery()
            ocn.Close()
            ocm.Dispose()
            ocn.Dispose()
            Close()
        End If
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        If count = 0 Then
            MsgBox("گزارشی ثبت نشده است", , "پیغام")
        Else
            allow = True
            Dim i As Integer = 0
            CrystalReportViewer1.Size = New System.Drawing.Size(x, y)
            CrystalReportViewer1.Location = New System.Drawing.Point(1, 1)
            Button13.Location = New System.Drawing.Point(x - 115, 5)

            For i = 0 To count - 1
                TextBox4.Text += ListBox1.Items.Item(i) & vbCrLf
                TextBox5.Text += ListBox2.Items.Item(i) & vbCrLf
                TextBox12.Text += ListBox3.Items.Item(i) & vbCrLf
                TextBox13.Text += ListBox4.Items.Item(i) & vbCrLf
                TextBox14.Text += ListBox5.Items.Item(i) & vbCrLf
                TextBox15.Text += ListBox6.Items.Item(i) & vbCrLf
            Next i
            rpt.SetParameterValue("G1", TextBox3.Text)
            rpt.SetParameterValue("G2", TextBox12.Text)
            rpt.SetParameterValue("G3", TextBox4.Text)
            rpt.SetParameterValue("G4", TextBox5.Text)
            rpt.SetParameterValue("G5", TextBox13.Text)
            rpt.SetParameterValue("G6", TextBox14.Text)
            rpt.SetParameterValue("G7", TextBox15.Text)


            CrystalReportViewer1.ReportSource = rpt
            CrystalReportViewer1.Visible = True
            CrystalReportViewer1.BringToFront()
            Button13.Visible = True
            Button13.BringToFront()
        End If
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        TextBox4.Text = ""
        TextBox12.Text = ""
        TextBox13.Text = ""
        TextBox14.Text = ""
        TextBox15.Text = ""
        TextBox5.Text = ""
        TextBox22.Text = ""
        TextBox23.Text = ""
        TextBox24.Text = ""
        TextBox25.Text = ""
        CrystalReportViewer1.ReportSource = rpt
        CrystalReportViewer1.Visible = False
        Button13.Visible = False
    End Sub

    Private Sub Button28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button28.Click
        Label10.Visible = False
        If ComboBox5.SelectedItem = "" Then
            MsgBox("نام روستا را وارد کنید", , "پیغام")
        Else
            address = Form1.TextBox3.Text
            Dim ocn As New System.Data.OleDb.OleDbConnection
            Dim ocm As New System.Data.OleDb.OleDbCommand
            Dim oda As New System.Data.OleDb.OleDbDataAdapter
            Dim dt As New DataTable

            ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
            "atabase Password=" + Form14.TextBox10.Text + ""
            ocm.Connection = ocn
            ocm.CommandText = "SELECT * FROM LooleGozari where roosta ='" & ComboBox5.SelectedItem & "' and NUM ='" & TextBox11.Text & "'"
            oda.SelectCommand = ocm
            If oda.Fill(dt) Then
                Button28.Visible = False
                Button17.Visible = True
                Button1.Enabled = True
                Button1.Visible = True
                TextBox11.Enabled = False
                ComboBox5.Enabled = False
                dt.Dispose()
                oda.Dispose()
                ocm.Dispose()
                ocn.Dispose()
            Else
                Label10.Visible = True
                dt.Dispose()
                oda.Dispose()
                ocm.Dispose()
                ocn.Dispose()
            End If
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ocn As New System.Data.OleDb.OleDbConnection
        Dim ocm As New System.Data.OleDb.OleDbCommand
        Dim oda As New System.Data.OleDb.OleDbDataAdapter
        Dim ds As New DataSet()
        address = Form1.TextBox3.Text
        ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
            "atabase Password=" + Form14.TextBox10.Text + ""
        ocm.Connection = ocn
        ocm.CommandText = "DELETE FROM LooleGozari WHERE NUM ='" & TextBox11.Text & "'"
        ocn.Open()
        ocm.ExecuteNonQuery()
        ocn.Close()
        ocm.Dispose()
        ocn.Dispose()
        ListBox10.Enabled = True
        Dim list As Integer = ListBox10.Items.IndexOf(TextBox11.Text)
        ListBox1.SelectedIndex = list
        ListBox2.SelectedIndex = list
        ListBox3.SelectedIndex = list
        ListBox4.SelectedIndex = list
        ListBox5.SelectedIndex = list
        ListBox6.SelectedIndex = list
        ListBox1.Items.Remove(ListBox1.SelectedItem)
        ListBox2.Items.Remove(ListBox2.SelectedItem)
        ListBox3.Items.Remove(ListBox3.SelectedItem)
        ListBox4.Items.Remove(ListBox4.SelectedItem)
        ListBox5.Items.Remove(ListBox5.SelectedItem)
        ListBox6.Items.Remove(ListBox6.SelectedItem)
        ListBox10.Enabled = False
        ComboBox5.Text = ""
        TextBox11.Text = ""
        TextBox11.Enabled = True
        ComboBox5.Enabled = True
        Button17.Visible = False
        Button1.Visible = False
        Button1.Enabled = False
        Button28.Visible = True
        count = count - 1
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        If Not GroupBox1.Visible Then
            GroupBox1.Visible = True
        Else
            GroupBox1.Visible = False
        End If
    End Sub

    Private Sub Button17_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button17.Click
        Button28.Visible = True
        Button17.Visible = False
        Button1.Enabled = False
        Button1.Visible = False
        TextBox11.Enabled = True
        ComboBox5.Enabled = True
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Dim ocn As New System.Data.OleDb.OleDbConnection
        Dim ocm As New System.Data.OleDb.OleDbCommand
        Dim oda As New System.Data.OleDb.OleDbDataAdapter
        Dim pc As Integer = 0

        If ComboBox8.Text = "روز" Or ComboBox9.Text = "ماه" Or TextBox6.Text = "سال" Or TextBox6.Text = "" Or ComboBox11.Text = "روز" Or ComboBox10.Text = "ماه" Or TextBox33.Text = "سال" Or TextBox33.Text = "" Or ComboBox12.Text = "" Then
            MsgBox("فیلد ها را تکمیل کنید", , "پیغام")
        ElseIf ((Convert.ToInt32(ComboBox9.Text)) > (Convert.ToInt32(ComboBox10.Text)) And (Convert.ToInt32(TextBox6.Text)) >= (Convert.ToInt32(TextBox33.Text))) Or ((Convert.ToInt32(ComboBox9.Text)) = (Convert.ToInt32(ComboBox10.Text)) And (Convert.ToInt32(TextBox6.Text)) = (Convert.ToInt32(TextBox33.Text)) And (Convert.ToInt32(ComboBox8.Text)) > (Convert.ToInt32(ComboBox11.Text))) Then
            MsgBox("خطا در تاریخ ورودی", , "پیغام")
        Else

            address = Form1.TextBox3.Text
            Dim con As New System.Data.OleDb.OleDbConnection
            Dim strSql As String
            Dim strCon As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
            "atabase Password=" + Form14.TextBox10.Text + ""

            strSql = "SELECT * FROM Tamirat2 where (roosta = '" & ComboBox12.SelectedItem & "' AND ((((Y + M + D) >='" & TextBox6.Text + ComboBox9.Text + ComboBox8.Text & "') AND ((Y + M + D) <='" & TextBox33.Text + ComboBox10.Text + ComboBox11.Text & "'))))"
            con = New OleDb.OleDbConnection(strCon)
            con.Open()
            da = New OleDb.OleDbDataAdapter(strSql, con)
            If da.Fill(ds, "Tamirat2") Then

                CrystalReportViewer1.Size = New System.Drawing.Size(x, y)
                CrystalReportViewer1.Location = New System.Drawing.Point(1, 1)
                Button13.Location = New System.Drawing.Point(x - 115, 5)

                TextBox16.DataBindings.Add(New Binding("Text", ds, "Tamirat2.bishtar"))
                TextBox17.DataBindings.Add(New Binding("Text", ds, "Tamirat2.tools"))
                TextBox18.DataBindings.Add(New Binding("Text", ds, "Tamirat2.ellat"))
                TextBox19.DataBindings.Add(New Binding("Text", ds, "Tamirat2.Y"))
                TextBox20.DataBindings.Add(New Binding("Text", ds, "Tamirat2.M"))
                TextBox21.DataBindings.Add(New Binding("Text", ds, "Tamirat2.D"))

                Do
                    TextBox27.Text = TextBox18.Text
                    TextBox22.Text += TextBox16.Text & vbCrLf
                    TextBox23.Text += TextBox17.Text & vbCrLf
                    TextBox24.Text += TextBox19.Text + "/" + TextBox20.Text + "/" + TextBox21.Text & vbCrLf
                    TextBox25.Text += TextBox18.Text & vbCrLf
                    pc += 1
                    Me.BindingContext(ds, "Tamirat2").Position += 1
                    If TextBox27.Text = TextBox18.Text Then
                        Exit Do
                    End If
                Loop

                rpt1.SetParameterValue("H1", ComboBox12.SelectedItem)
                rpt1.SetParameterValue("H2", TextBox34.Text)
                rpt1.SetParameterValue("H3", (TextBox6.Text + "/" + ComboBox9.SelectedItem + "/" + ComboBox8.SelectedItem))
                rpt1.SetParameterValue("H4", (TextBox33.Text + "/" + ComboBox10.SelectedItem + "/" + ComboBox11.SelectedItem))
                rpt1.SetParameterValue("H5", pc)
                rpt1.SetParameterValue("H6", TextBox24.Text)
                rpt1.SetParameterValue("H7", TextBox25.Text)
                rpt1.SetParameterValue("H8", TextBox23.Text)
                rpt1.SetParameterValue("H9", TextBox22.Text)
                CrystalReportViewer1.ReportSource = rpt1

                CrystalReportViewer1.Visible = True
                CrystalReportViewer1.BringToFront()
                Button13.Visible = True
                Button13.BringToFront()

                oda.Dispose()
                ocm.Dispose()
                con.Dispose()

                TextBox16.DataBindings.Clear()
                TextBox17.DataBindings.Clear()
                TextBox18.DataBindings.Clear()
                TextBox19.DataBindings.Clear()
                TextBox20.DataBindings.Clear()
                TextBox21.DataBindings.Clear()
            Else
                MsgBox("موردی یافت نشد", , "پیغام")
            End If
        End If
    End Sub

    Private Sub ComboBox11_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox11.SelectedIndexChanged
        If ComboBox10.Text = "07" Or ComboBox10.Text = "08" Or ComboBox10.Text = "09" Or ComboBox10.Text = "10" Or ComboBox10.Text = "11" Or ComboBox10.Text = "12" Then
            If ComboBox11.SelectedItem = "31" Then
                ComboBox11.SelectedItem = "30"
            End If
        End If
    End Sub

    Private Sub ComboBox8_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox8.SelectedIndexChanged
        If ComboBox9.Text = "07" Or ComboBox9.Text = "08" Or ComboBox9.Text = "09" Or ComboBox9.Text = "10" Or ComboBox9.Text = "11" Or ComboBox9.Text = "12" Then
            If ComboBox8.SelectedItem = "31" Then
                ComboBox8.SelectedItem = "30"
            End If
        End If
    End Sub

    Private Sub ComboBox9_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox9.SelectedIndexChanged
        If ComboBox9.Text = "07" Or ComboBox9.Text = "08" Or ComboBox9.Text = "09" Or ComboBox9.Text = "10" Or ComboBox9.Text = "11" Or ComboBox9.Text = "12" Then
            If ComboBox8.SelectedItem = "31" Then
                ComboBox8.SelectedItem = "30"
            End If
        End If
    End Sub

    Private Sub ComboBox10_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox10.SelectedIndexChanged
        If ComboBox10.Text = "07" Or ComboBox10.Text = "08" Or ComboBox10.Text = "09" Or ComboBox10.Text = "10" Or ComboBox10.Text = "11" Or ComboBox10.Text = "12" Then
            If ComboBox11.SelectedItem = "31" Then
                ComboBox11.SelectedItem = "30"
            End If
        End If
    End Sub

    Private Sub ComboBox12_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox12.SelectedIndexChanged
        Dim ocn As New System.Data.OleDb.OleDbConnection
        Dim ocm As New System.Data.OleDb.OleDbCommand
        Dim oda As New System.Data.OleDb.OleDbDataAdapter
        Dim ds As New DataSet()
        ComboBox2.Text = ComboBox2.SelectedText
        ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\Data.mdb"
        ocm.Connection = ocn
        ocm.CommandText = "SELECT bakhsh FROM Roostaha where roosta='" & ComboBox12.SelectedItem & "'"
        oda.SelectCommand = ocm
        da = New OleDbDataAdapter(ocm.CommandText, ocn)
        da.Fill(ds, "Roostaha")
        TextBox34.DataBindings.Add(New Binding("text", ds, "Roostaha.bakhsh"))
        TextBox34.DataBindings.Clear()
        oda.Dispose()
        ocm.Dispose()
        ocn.Dispose()
    End Sub

    Private Sub TextBox6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox6.Click
        TextBox6.Text = ""
    End Sub

    Private Sub TextBox33_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox33.Click
        TextBox33.Text = ""
    End Sub
End Class