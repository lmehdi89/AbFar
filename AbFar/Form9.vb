Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Public Class Form9
    Public address As String
    Public test As Boolean = True
    Public f As Boolean = True
    Public allow As Boolean = False
    Public num As Integer = 0
    Public i As Integer = 0
    Public y As Integer
    Public x As Integer
    Private da As OleDbDataAdapter
    Private ds As New DataSet
    Public BL As Boolean = False
    Dim rpt As New CrystalReport12
    Dim rpt1 As New CrystalReport14
    Public Function RRO()
        TextBox13.ReadOnly = False
        TextBox14.ReadOnly = False
        TextBox15.ReadOnly = False
        TextBox16.ReadOnly = False
        TextBox17.ReadOnly = False
        TextBox18.ReadOnly = False
        Return 0
    End Function
    Public Function SRO()
        TextBox13.ReadOnly = True
        TextBox14.ReadOnly = True
        TextBox16.ReadOnly = True
        TextBox17.ReadOnly = True
        TextBox18.ReadOnly = True
        TextBox19.ReadOnly = True
        Return 0
    End Function
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            If allow Then
                address = Form1.TextBox3.Text
                Dim ocn As New System.Data.OleDb.OleDbConnection
                Dim ocm As New System.Data.OleDb.OleDbCommand
                Dim oda As New System.Data.OleDb.OleDbDataAdapter
                Dim ds As New DataSet()

                ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + ""
                ocm.Connection = ocn
                ocm.CommandText = "update Tamirat1 SET NUM=0"
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

                ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + ""
                ocm.Connection = ocn
                ocm.CommandText = "DELETE FROM Tamirat1 WHERE NUM >'" & 0 & "'"
                ocn.Open()
                ocm.ExecuteNonQuery()
                ocn.Close()
                ocm.Dispose()
                ocn.Dispose()
                Close()
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
       
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        CrystalReportViewer1.Visible = False
        Button13.Visible = False
        TextBox25.Text = ""
        TextBox26.Text = ""
        TextBox27.Text = ""
        TextBox28.Text = ""
        TextBox29.Text = ""
        TextBox30.Text = ""
        TextBox31.Text = ""
        TextBox32.Text = ""
        TextBox36.Text = ""
        TextBox37.Text = ""
        TextBox38.Text = ""
        TextBox39.Text = ""
        TextBox40.Text = ""
        TextBox35.Text = ""
        TextBox25.DataBindings.Clear()
        TextBox26.DataBindings.Clear()
        TextBox27.DataBindings.Clear()
        TextBox28.DataBindings.Clear()
        TextBox29.DataBindings.Clear()
        TextBox30.DataBindings.Clear()
        TextBox31.DataBindings.Clear()
        TextBox32.DataBindings.Clear()

    End Sub


    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If Not GroupBox2.Visible Then
            GroupBox2.Visible = True
        Else
            GroupBox2.Visible = False
        End If
    End Sub

    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click
        If Not GroupBox4.Visible Then
            GroupBox4.Visible = True
        Else
            GroupBox4.Visible = False
        End If
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        If Not GroupBox3.Visible Then
            GroupBox3.Visible = True
        Else
            GroupBox3.Visible = False
        End If
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Try
            Dim ocm As New System.Data.OleDb.OleDbCommand
            Dim oda As New System.Data.OleDb.OleDbDataAdapter
            Dim ocn As New System.Data.OleDb.OleDbConnection

            If num < 8 Then

                test = True
                If TextBox4.Text = "" Or ComboBox3.Text = "" Or ComboBox4.Text = "" Or (ComboBox1.Text = "" Or ComboBox1.Text = "روز") Or (ComboBox2.Text = "" Or ComboBox2.Text = "ماه") Or TextBox7.Text = "" Then
                    MsgBox("مشخصات فرم کامل نیست", , "پیغام")
                Else
                    address = Form1.TextBox3.Text
                    ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + ""
                    ocm.Connection = ocn
                    ocm.CommandText = "INSERT INTO Tamirat1 (bishtar,HBR,sharh,pomp,ejra,Y,M,D,roosta,bakhsh,NUM) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)"
                    ocm.Parameters.Clear()
                    ocm.Parameters.AddWithValue("@p1", TextBox2.Text)
                    ocm.Parameters.AddWithValue("@p2", TextBox1.Text)
                    ocm.Parameters.AddWithValue("@p3", TextBox9.Text)
                    ocm.Parameters.AddWithValue("@p4", ComboBox5.Text)
                    ocm.Parameters.AddWithValue("@p5", TextBox4.Text)
                    ocm.Parameters.AddWithValue("@p6", TextBox7.Text)
                    ocm.Parameters.AddWithValue("@p7", ComboBox2.Text)
                    ocm.Parameters.AddWithValue("@p8", ComboBox1.Text)
                    ocm.Parameters.AddWithValue("@p9", ComboBox3.Text)
                    ocm.Parameters.AddWithValue("@p10", ComboBox4.Text)
                    ocm.Parameters.AddWithValue("@p11", num)


                    ocn.Open()
                    ocm.ExecuteNonQuery()
                    ocn.Close()
                    ocm.Dispose()
                    ocn.Dispose()
                    num += 1
                    If num = 1 Then
                        TextBox22.ReadOnly = False
                        TextBox22.Text = TextBox4.Text
                        TextBox22.ReadOnly = True
                        TextBox22.BackColor = Color.White
                        TextBox4.Enabled = False
                    End If
                    ListBox2.Items.Add(ComboBox3.SelectedItem)
                    ListBox3.Items.Add(TextBox7.Text + "/" + ComboBox2.Text + "/" + ComboBox1.Text)
                    ListBox4.Items.Add(ComboBox5.Text)
                    ListBox5.Items.Add(TextBox9.Text)
                    ListBox6.Items.Add(TextBox1.Text)
                    ListBox7.Items.Add(TextBox2.Text)

                    TextBox7.Text = ""
                    ComboBox5.Text = ""
                    TextBox9.Text = ""
                    TextBox1.Text = ""
                    TextBox2.Text = ""

                End If
            Else
                MsgBox("فرم جدید ایجاد کنید", , "پیغام")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
        
    End Sub

    Private Sub Form9_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        y = Me.Size.Height
        x = Me.Size.Width

        GroupBox1.Location = New System.Drawing.Point((x / 2), y / 35)
        Button3.Location = New System.Drawing.Point((x / 2), (y / 35) + 735)
        Button1.Location = New System.Drawing.Point(15, (y / 5))
        GroupBox5.Location = New System.Drawing.Point(45, y / 5)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If Not GroupBox5.Visible And f Then
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
                TextBox21.DataBindings.Add(New Binding("Text", ds, "Form.Shahr"))
                f = False
                GroupBox5.Visible = True
                TextBox21.DataBindings.Clear()
            ElseIf Not GroupBox5.Visible Then
                GroupBox5.Visible = True
            Else
                GroupBox5.Visible = False
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
        
    End Sub

    Private Sub Button42_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button42.Click
        Try
            ComboBox3.Text = ""
            ComboBox4.Text = ""
            ComboBox4.Items.Clear()
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
                TextBox24.Text = TextBox23.Text
                TextBox23.DataBindings.Add(New Binding("Text", ds, "Roostaha.roosta"))
                ComboBox4.Items.Add(TextBox23.Text)
                Me.BindingContext(ds, "Roostaha").Position += 1
                TextBox23.DataBindings.Clear()
                If TextBox23.Text = TextBox24.Text Then
                    Exit Do
                End If
            Loop
            oda.Dispose()
            ocm.Dispose()
            ocn.Dispose()
            Button42.Visible = False
            test = True
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
        
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox4.SelectedIndexChanged
        Try
            If Not test Then
                Exit Sub
            Else
                Dim ocn As New System.Data.OleDb.OleDbConnection
                Dim ocm As New System.Data.OleDb.OleDbCommand
                Dim oda As New System.Data.OleDb.OleDbDataAdapter
                Dim ds As New DataSet()

                ComboBox3.Items.Clear()
                ComboBox3.Text = ""

                If Not ComboBox4.SelectedItem = "کل روستاها" Then


                    ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\Data.mdb"
                    ocm.Connection = ocn
                    ocm.CommandText = "SELECT roosta FROM Roostaha where bakhsh='" & ComboBox1.SelectedItem & "'"
                    oda.SelectCommand = ocm
                    da = New OleDbDataAdapter(ocm.CommandText, ocn)
                    da.Fill(ds, "Roostaha")

                    Do
                        TextBox24.Text = TextBox23.Text
                        TextBox23.DataBindings.Add(New Binding("Text", ds, "Roostaha.roosta"))
                        ComboBox3.Items.Add(TextBox23.Text)
                        Me.BindingContext(ds, "Roostaha").Position += 1
                        TextBox23.DataBindings.Clear()
                        If TextBox23.Text = TextBox24.Text Then
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
                        TextBox24.Text = TextBox23.Text
                        TextBox23.DataBindings.Add(New Binding("Text", ds, "Roostaha.roosta"))
                        ComboBox3.Items.Add(TextBox23.Text)
                        Me.BindingContext(ds, "Roostaha").Position += 1
                        TextBox23.DataBindings.Clear()
                        If TextBox23.Text = TextBox24.Text Then
                            Exit Do
                        End If
                    Loop
                    oda.Dispose()
                    ocm.Dispose()
                    ocn.Dispose()
                End If
                Button42.Visible = True
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
       
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged
        Try
            test = False
            Dim ocn As New System.Data.OleDb.OleDbConnection
            Dim ocm As New System.Data.OleDb.OleDbCommand
            Dim oda As New System.Data.OleDb.OleDbDataAdapter
            Dim ds As New DataSet()
            ComboBox3.Text = ComboBox3.SelectedText
            ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\Data.mdb"
            ocm.Connection = ocn
            ocm.CommandText = "SELECT bakhsh FROM Roostaha where roosta='" & ComboBox3.SelectedItem & "'"
            oda.SelectCommand = ocm
            da = New OleDbDataAdapter(ocm.CommandText, ocn)
            da.Fill(ds, "Roostaha")
            ComboBox4.DataBindings.Add(New Binding("text", ds, "Roostaha.bakhsh"))
            ComboBox4.DataBindings.Clear()
            oda.Dispose()
            ocm.Dispose()
            ocn.Dispose()
            Button42.Visible = True
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
        
    End Sub

    Private Sub TextBox7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox7.KeyPress
        If Not IsNumeric(e.KeyChar) And e.KeyChar <> Convert.ToChar(Keys.Back) And e.KeyChar <> Convert.ToChar(Keys.Delete) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If Not IsNumeric(e.KeyChar) And e.KeyChar <> Convert.ToChar(Keys.Back) And e.KeyChar <> Convert.ToChar(Keys.Delete) Then
            e.Handled = True
        End If
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        Try
            If allow Then
                address = Form1.TextBox3.Text
                Dim ocn As New System.Data.OleDb.OleDbConnection
                Dim ocm As New System.Data.OleDb.OleDbCommand
                Dim oda As New System.Data.OleDb.OleDbDataAdapter
                Dim ds As New DataSet()

                ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + ""
                ocm.Connection = ocn
                ocm.CommandText = "update Tamirat1 SET NUM=0"
                ocn.Open()
                ocm.ExecuteNonQuery()
                ocn.Close()
                ocm.Dispose()
                ocn.Dispose()
                Button42_Click(sender, e)
                TextBox7.Text = ""
                ComboBox1.Text = "روز"
                ComboBox2.Text = "ماه"
                ComboBox5.Text = ""
                TextBox9.Text = ""
                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox4.Text = ""
                TextBox4.Enabled = True

                ListBox2.Items.Clear()
                ListBox3.Items.Clear()
                ListBox4.Items.Clear()
                ListBox5.Items.Clear()
                ListBox6.Items.Clear()
                ListBox7.Items.Clear()
                num = 0
                test = True
                allow = False
            Else
                address = Form1.TextBox3.Text
                Dim ocn As New System.Data.OleDb.OleDbConnection
                Dim ocm As New System.Data.OleDb.OleDbCommand
                Dim oda As New System.Data.OleDb.OleDbDataAdapter
                Dim ds As New DataSet()

                ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + ""
                ocm.Connection = ocn
                ocm.CommandText = "DELETE FROM Tamirat1 WHERE NUM >'" & 0 & "'"
                ocn.Open()
                ocm.ExecuteNonQuery()
                ocn.Close()
                ocm.Dispose()
                ocn.Dispose()
                Button42_Click(sender, e)
                TextBox7.Text = ""
                ComboBox1.Text = "روز"
                ComboBox2.Text = "ماه"
                ComboBox5.Text = ""
                TextBox9.Text = ""
                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox4.Text = ""
                TextBox4.Enabled = True

                ListBox2.Items.Clear()
                ListBox3.Items.Clear()
                ListBox4.Items.Clear()
                ListBox5.Items.Clear()
                ListBox6.Items.Clear()
                ListBox7.Items.Clear()
                num = 0
                test = True
                allow = False
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
        
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            If num = 0 Then
                MsgBox("گزارشی ثبت نشده است", , "پیغام")
            Else
                allow = True
                Dim r As Integer = 0
                CrystalReportViewer1.Size = New System.Drawing.Size(x, y)
                CrystalReportViewer1.Location = New System.Drawing.Point(1, 1)
                Button13.Location = New System.Drawing.Point(x - 112, 5)

                For i = 0 To num - 1
                    TextBox25.Text += ListBox2.Items.Item(i) & vbCrLf
                    TextBox26.Text += ListBox3.Items.Item(i) & vbCrLf
                    TextBox27.Text += ListBox4.Items.Item(i) & vbCrLf
                    TextBox28.Text += ListBox5.Items.Item(i) & vbCrLf
                    TextBox29.Text += ListBox6.Items.Item(i) & vbCrLf
                    TextBox30.Text += ListBox7.Items.Item(i) & vbCrLf
                Next i
                rpt.SetParameterValue("E1", TextBox21.Text)
                rpt.SetParameterValue("E2", TextBox22.Text)
                rpt.SetParameterValue("E3", TextBox25.Text)
                rpt.SetParameterValue("E4", TextBox26.Text)
                rpt.SetParameterValue("E5", TextBox27.Text)
                rpt.SetParameterValue("E6", TextBox28.Text)
                rpt.SetParameterValue("E7", TextBox29.Text)
                rpt.SetParameterValue("E8", TextBox30.Text)

                CrystalReportViewer1.ReportSource = rpt
                CrystalReportViewer1.Visible = True
                CrystalReportViewer1.BringToFront()
                Button13.Visible = True
                Button13.BringToFront()
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
       
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Button42_Click(sender, e)
        TextBox7.Text = ""
        ComboBox1.Text = "روز"
        ComboBox2.Text = "ماه"
        ComboBox5.Text = ""
        TextBox9.Text = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        Try
            Dim ocn As New System.Data.OleDb.OleDbConnection
            Dim ocm As New System.Data.OleDb.OleDbCommand
            Dim oda As New System.Data.OleDb.OleDbDataAdapter
            Dim PC As Integer = 0

            If ComboBox12.Text = "روز" Or ComboBox9.Text = "ماه" Or TextBox10.Text = "سال" Or TextBox10.Text = "" Or ComboBox11.Text = "روز" Or ComboBox10.Text = "ماه" Or TextBox33.Text = "سال" Or TextBox33.Text = "" Or ComboBox8.Text = "" Then
                MsgBox("فیلد ها را تکمیل کنید", , "پیغام")
            ElseIf ((Convert.ToInt32(ComboBox9.Text)) > (Convert.ToInt32(ComboBox10.Text)) And (Convert.ToInt32(TextBox10.Text)) >= (Convert.ToInt32(TextBox33.Text))) Or ((Convert.ToInt32(ComboBox9.Text)) = (Convert.ToInt32(ComboBox10.Text)) And (Convert.ToInt32(TextBox10.Text)) = (Convert.ToInt32(TextBox33.Text)) And (Convert.ToInt32(ComboBox12.Text)) > (Convert.ToInt32(ComboBox11.Text))) Then
                MsgBox("خطا در تاریخ ورودی", , "پیغام")
            Else
                address = Form1.TextBox3.Text
                Dim con As New System.Data.OleDb.OleDbConnection
                Dim strSql As String
                Dim strCon As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + ""

                strSql = "SELECT * FROM Tamirat1 where roosta = '" & ComboBox8.SelectedItem & "' AND ((((Y + M + D) >='" & TextBox10.Text + ComboBox9.Text + ComboBox12.Text & "') AND ((Y + M + D)<='" & TextBox33.Text + ComboBox10.Text + ComboBox11.Text & "')))"
                con = New OleDb.OleDbConnection(strCon)
                con.Open()
                da = New OleDb.OleDbDataAdapter(strSql, con)
                If da.Fill(ds, "Tamirat1") Then

                    CrystalReportViewer1.Size = New System.Drawing.Size(x, y)
                    CrystalReportViewer1.Location = New System.Drawing.Point(1, 1)
                    Button13.Location = New System.Drawing.Point(x - 115, 5)


                    TextBox25.DataBindings.Add(New Binding("Text", ds, "Tamirat1.bishtar"))
                    TextBox26.DataBindings.Add(New Binding("Text", ds, "Tamirat1.HBR"))
                    TextBox27.DataBindings.Add(New Binding("Text", ds, "Tamirat1.sharh"))
                    TextBox28.DataBindings.Add(New Binding("Text", ds, "Tamirat1.pomp"))
                    TextBox29.DataBindings.Add(New Binding("Text", ds, "Tamirat1.ejra"))
                    TextBox30.DataBindings.Add(New Binding("Text", ds, "Tamirat1.Y"))
                    TextBox31.DataBindings.Add(New Binding("Text", ds, "Tamirat1.M"))
                    TextBox32.DataBindings.Add(New Binding("Text", ds, "Tamirat1.D"))

                    Do
                        TextBox3.Text = TextBox28.Text
                        TextBox5.Text = TextBox27.Text

                        TextBox36.Text += TextBox25.Text & vbCrLf
                        TextBox37.Text += TextBox26.Text & vbCrLf
                        TextBox38.Text += TextBox27.Text & vbCrLf
                        TextBox39.Text += TextBox28.Text & vbCrLf
                        TextBox40.Text += TextBox29.Text & vbCrLf
                        PC += 1
                        TextBox35.Text += TextBox30.Text + "/" + TextBox31.Text + "/" + TextBox32.Text & vbCrLf
                        Me.BindingContext(ds, "Tamirat1").Position += 1

                        If TextBox5.Text = TextBox27.Text And TextBox3.Text = TextBox28.Text Then
                            Exit Do
                        End If
                    Loop

                    rpt1.SetParameterValue("F1", ComboBox8.Text)
                    rpt1.SetParameterValue("F2", TextBox6.Text)
                    rpt1.SetParameterValue("F3", (TextBox10.Text + "/" + ComboBox9.SelectedItem + "/" + ComboBox12.SelectedItem))
                    rpt1.SetParameterValue("F4", (TextBox33.Text + "/" + ComboBox10.SelectedItem + "/" + ComboBox11.SelectedItem))
                    rpt1.SetParameterValue("F5", PC)
                    rpt1.SetParameterValue("F6", TextBox35.Text)
                    rpt1.SetParameterValue("F7", TextBox39.Text)
                    rpt1.SetParameterValue("F8", TextBox38.Text)
                    rpt1.SetParameterValue("F9", TextBox37.Text)
                    rpt1.SetParameterValue("F10", TextBox36.Text)
                    rpt1.SetParameterValue("F11", TextBox40.Text)
                    CrystalReportViewer1.ReportSource = rpt1

                    CrystalReportViewer1.Visible = True
                    CrystalReportViewer1.BringToFront()
                    Button13.Visible = True
                    Button13.BringToFront()

                    oda.Dispose()
                    ocm.Dispose()
                    con.Dispose()
                Else
                    MsgBox("موردی یافت نشد", , "پیغام")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
       
    End Sub

    Private Sub ComboBox8_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox8.SelectedIndexChanged
        Try
            Dim ds As New DataSet()
            Dim strSql As String
            Dim strCon As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\Data.mdb"
            Dim da As OleDb.OleDbDataAdapter
            Dim con As OleDb.OleDbConnection

            strSql = "select * from Roostaha where roosta= '" & ComboBox8.Text & "'"
            con = New OleDb.OleDbConnection(strCon)
            con.Open()
            da = New OleDb.OleDbDataAdapter(strSql, con)
            da.Fill(ds, "Roostaha")

            TextBox6.DataBindings.Add(New Binding("text", ds, "Roostaha.bakhsh"))
            TextBox6.DataBindings.Clear()
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
        
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox2.Text = "07" Or ComboBox2.Text = "08" Or ComboBox2.Text = "09" Or ComboBox2.Text = "10" Or ComboBox2.Text = "11" Or ComboBox2.Text = "12" Then
            If ComboBox1.SelectedItem = "31" Then
                ComboBox1.SelectedItem = "30"
            End If
        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        If ComboBox2.Text = "07" Or ComboBox2.Text = "08" Or ComboBox2.Text = "09" Or ComboBox2.Text = "10" Or ComboBox2.Text = "11" Or ComboBox2.Text = "12" Then
            If ComboBox1.SelectedItem = "31" Then
                ComboBox1.SelectedItem = "30"
            End If
        End If
    End Sub

    Private Sub ComboBox12_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox12.SelectedIndexChanged
        If ComboBox9.Text = "07" Or ComboBox9.Text = "08" Or ComboBox9.Text = "09" Or ComboBox9.Text = "10" Or ComboBox9.Text = "11" Or ComboBox9.Text = "12" Then
            If ComboBox12.SelectedItem = "31" Then
                ComboBox12.SelectedItem = "30"
            End If
        End If
    End Sub

    Private Sub ComboBox9_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox9.SelectedIndexChanged
        If ComboBox9.Text = "07" Or ComboBox9.Text = "08" Or ComboBox9.Text = "09" Or ComboBox9.Text = "10" Or ComboBox9.Text = "11" Or ComboBox9.Text = "12" Then
            If ComboBox12.SelectedItem = "31" Then
                ComboBox12.SelectedItem = "30"
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

    Private Sub ComboBox10_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox10.SelectedIndexChanged
        If ComboBox10.Text = "07" Or ComboBox10.Text = "08" Or ComboBox10.Text = "09" Or ComboBox10.Text = "10" Or ComboBox10.Text = "11" Or ComboBox10.Text = "12" Then
            If ComboBox11.SelectedItem = "31" Then
                ComboBox11.SelectedItem = "30"
            End If
        End If
    End Sub

    Private Sub TextBox10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox10.Click
        TextBox10.Text = ""
    End Sub

    Private Sub TextBox33_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox33.Click
        TextBox33.Text = ""
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Try
            TextBox12.Visible = False
            If ComboBox6.SelectedItem = "" Or TextBox11.Text = "" Then
                MsgBox("مقادیر فیلد ها را وارد کنید", , "پیغام")
            Else
                address = Form1.TextBox3.Text
                Dim ocn As New System.Data.OleDb.OleDbConnection
                Dim ocm As New System.Data.OleDb.OleDbCommand
                Dim oda As New System.Data.OleDb.OleDbDataAdapter
                Dim dt As New DataTable

                ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + ""
                ocm.Connection = ocn
                ocm.CommandText = "SELECT * FROM Tamirat1 where roosta ='" & ComboBox6.SelectedItem & "' and NUM ='" & TextBox11.Text & "'"
                oda.SelectCommand = ocm
                If oda.Fill(dt) Then
                    Button6.Visible = False
                    Button41.Visible = True
                    Button7.Enabled = True
                    Button7.Visible = True
                    ComboBox6.Enabled = False
                    dt.Dispose()
                    oda.Dispose()
                    ocm.Dispose()
                    ocn.Dispose()
                Else
                    TextBox12.Visible = True
                    dt.Dispose()
                    oda.Dispose()
                    ocm.Dispose()
                    ocn.Dispose()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
       
    End Sub

    Private Sub Button41_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button41.Click
        Button6.Visible = True
        Button41.Visible = False
        Button7.Enabled = False
        Button7.Visible = False
        ComboBox6.Enabled = True
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Try
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
            ListBox1.Enabled = True
            Dim list As Integer = ListBox1.Items.IndexOf(TextBox11.Text)
            ListBox1.SelectedIndex = list
            ListBox2.SelectedIndex = list
            ListBox3.SelectedIndex = list
            ListBox4.SelectedIndex = list
            ListBox5.SelectedIndex = list
            ListBox6.SelectedIndex = list
            ListBox7.SelectedIndex = list
            ListBox1.Items.Remove(ListBox1.SelectedItem)
            ListBox2.Items.Remove(ListBox2.SelectedItem)
            ListBox3.Items.Remove(ListBox3.SelectedItem)
            ListBox4.Items.Remove(ListBox4.SelectedItem)
            ListBox5.Items.Remove(ListBox5.SelectedItem)
            ListBox6.Items.Remove(ListBox6.SelectedItem)
            ListBox7.Items.Remove(ListBox7.SelectedItem)
            ListBox1.Enabled = False
            ComboBox6.Text = ""
            TextBox11.Text = ""
            ComboBox6.Enabled = True
            Button41.Visible = False
            Button7.Visible = False
            Button7.Enabled = False
            Button6.Visible = True
            num = num - 1
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
       
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
End Class