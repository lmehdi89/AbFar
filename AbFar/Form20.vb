Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Public Class Form20
    Public lp As Integer
    Public y As Integer
    Public x As Integer
    Public address As String
    Public test As Boolean = True
    Public BL As Boolean = False
    Private da As OleDbDataAdapter
    Dim rD As New CrystalReport18
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
        TextBox18.Text = y
        Return 0
    End Function
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Button1.Enabled = True
        Button2.Enabled = False
        GroupBox3.Visible = False
        GroupBox2.Visible = True
        Button13_Click(sender, e)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Button1.Enabled = False
        Button2.Enabled = True
        GroupBox3.Visible = True
        GroupBox2.Visible = False
        Button42_Click(sender, e)
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        If GroupBox4.Visible Then
            GroupBox4.Visible = False
        Else
            GroupBox4.Visible = True
        End If
    End Sub


    Private Sub Button6_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Button3.Enabled = True
        Button6.Enabled = False
        GroupBox5.Visible = False
        GroupBox6.Visible = True
        Button15_Click(sender, e)
        ComboBox16.Text = "دوره 1"
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Button3.Enabled = False
        Button6.Enabled = True
        GroupBox5.Visible = True
        GroupBox6.Visible = False
        Button14_Click(sender, e)
        TextBox12.Text = ""
        TextBox16.Text = ""
        ComboBox17.Text = "دوره 1"
        ComboBox15.Text = "دوره 1"
        CheckBox1.Checked = False
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        Select Case ComboBox2.Text
            Case "دوره 1"
                TextBox3.Text = "فروردین"
            Case "دوره 2"
                TextBox3.Text = "اردیبهشت"
            Case "دوره 3"
                TextBox3.Text = "خرداد"
            Case "دوره 4"
                TextBox3.Text = "تیر"
            Case "دوره 5"
                TextBox3.Text = "مرداد"
            Case "دوره 6"
                TextBox3.Text = "شهریور"
            Case "دوره 7"
                TextBox3.Text = "مهر"
            Case "دوره 8"
                TextBox3.Text = "آبان"
            Case "دوره 9"
                TextBox3.Text = "آذر"
            Case "دوره 10"
                TextBox3.Text = "دی"
            Case "دوره 11"
                TextBox3.Text = "بهمن"
            Case "دوره 12"
                TextBox3.Text = "اسفند"
        End Select
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Close()
    End Sub

    Private Sub ComboBox13_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox13.DropDown
        test = True
    End Sub

    Private Sub ComboBox13_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboBox13.KeyDown
        e.SuppressKeyPress = True
    End Sub

    Private Sub ComboBox13_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox13.KeyPress
        e.Handled = True
    End Sub

    Private Sub ComboBox13_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox13.SelectedIndexChanged
        Try
            If Not test Then
                Exit Sub
            Else
                Dim ocn As New System.Data.OleDb.OleDbConnection
                Dim ocm As New System.Data.OleDb.OleDbCommand
                Dim oda As New System.Data.OleDb.OleDbDataAdapter
                Dim ds As New DataSet()

                ComboBox1.Items.Clear()
                ComboBox1.Text = ""
                If Not ComboBox13.SelectedItem = "کل روستاها" Then


                    ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\Data.mdb"
                    ocm.Connection = ocn
                    ocm.CommandText = "SELECT roosta FROM Roostaha where bakhsh='" & ComboBox13.SelectedItem & "'"
                    oda.SelectCommand = ocm
                    da = New OleDbDataAdapter(ocm.CommandText, ocn)
                    da.Fill(ds, "Roostaha")

                    Do
                        TextBox14.Text = TextBox8.Text
                        TextBox8.DataBindings.Add(New Binding("Text", ds, "Roostaha.roosta"))
                        ComboBox1.Items.Add(TextBox8.Text)
                        Me.BindingContext(ds, "Roostaha").Position += 1
                        TextBox8.DataBindings.Clear()
                        If TextBox8.Text = TextBox14.Text Then
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
                        TextBox14.Text = TextBox8.Text
                        TextBox8.DataBindings.Add(New Binding("Text", ds, "Roostaha.roosta"))
                        ComboBox1.Items.Add(TextBox8.Text)
                        Me.BindingContext(ds, "Roostaha").Position += 1
                        TextBox8.DataBindings.Clear()
                        If TextBox8.Text = TextBox14.Text Then
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

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
            test = False
            Dim ocn As New System.Data.OleDb.OleDbConnection
            Dim ocm As New System.Data.OleDb.OleDbCommand
            Dim oda As New System.Data.OleDb.OleDbDataAdapter
            Dim ds As New DataSet()
            ComboBox1.Text = ComboBox1.SelectedText
            ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\Data.mdb"
            ocm.Connection = ocn
            ocm.CommandText = "SELECT bakhsh FROM Roostaha where roosta='" & ComboBox1.SelectedItem & "'"
            oda.SelectCommand = ocm
            da = New OleDbDataAdapter(ocm.CommandText, ocn)
            da.Fill(ds, "Roostaha")
            ComboBox13.DataBindings.Add(New Binding("text", ds, "Roostaha.bakhsh"))
            ComboBox13.DataBindings.Clear()
            oda.Dispose()
            ocm.Dispose()
            ocn.Dispose()
            Button42.Visible = True
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
       
    End Sub

    Private Sub Button42_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button42.Click
        Try
            ComboBox1.Text = ""
            ComboBox13.Text = ""
            ComboBox13.Items.Clear()
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
                TextBox14.Text = TextBox8.Text
                TextBox8.DataBindings.Add(New Binding("Text", ds, "Roostaha.roosta"))
                ComboBox1.Items.Add(TextBox8.Text)
                Me.BindingContext(ds, "Roostaha").Position += 1
                TextBox8.DataBindings.Clear()
                If TextBox8.Text = TextBox14.Text Then
                    Exit Do
                End If
            Loop
            oda.Dispose()
            ocm.Dispose()
            ocn.Dispose()
            ComboBox1.Enabled = True
            ComboBox13.Enabled = True
            Button42.Visible = False
            test = True
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
        
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox4.Text = ""
        Button42_Click(sender, e)
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try
            Dim ocm As New System.Data.OleDb.OleDbCommand
            Dim oda As New System.Data.OleDb.OleDbDataAdapter
            Dim ocn As New System.Data.OleDb.OleDbConnection
            Dim dt As New DataTable
            If ComboBox1.Text = "" Or ComboBox13.Text = "" Or TextBox1.Text = "" Or TextBox15.Text = "" Or TextBox4.Text = "" Then
                MsgBox("مشخصات فرم گزارش کامل نیست", , "پیغام")
            Else
                address = Form1.TextBox3.Text
                ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + ""
                ocm.Connection = ocn
                ocm.CommandText = "SELECT * FROM GhabzD where ( roosta='" & ComboBox1.Text & "' and T='" & TextBox15.Text & "')"
                oda.SelectCommand = ocm
                If oda.Fill(dt) Then
                    Select Case TextBox3.Text
                        Case "اسفند"

                            address = Form1.TextBox3.Text
                            ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + ""
                            ocm.Connection = ocn
                            ocm.CommandText = "SELECT * FROM GhabzD where D12<>'""'"
                            oda.SelectCommand = ocm
                            If oda.Fill(dt) Then
                                MsgBox("اطلاعات قبلی موجود است", , "پیغام")
                            Else
                                address = Form1.TextBox3.Text
                                ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + ""
                                ocm.Connection = ocn
                                ocm.CommandText = "INSERT INTO GhabzD (D12,D11,D10,D9,D8,D7,D6,D5,D4,D3,D2,D1,T,mandeD,roosta,bakhsh,IDD) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17)"
                                ocm.Parameters.Clear()

                                Select Case TextBox3.Text
                                    Case "اسفند"

                                        ocm.Parameters.AddWithValue("@p1", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")

                                    Case "بهمن"

                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p2", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")

                                    Case "دی"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")

                                    Case "آذر"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "آبان"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "مهر"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "شهریور"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "مرداد"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "تیر"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "خرداد"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "اردیبهشت"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "فروردین"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", TextBox4.Text)

                                End Select

                                ocm.Parameters.AddWithValue("@p13", TextBox15.Text)
                                ocm.Parameters.AddWithValue("@p14", TextBox2.Text)
                                ocm.Parameters.AddWithValue("@p15", ComboBox1.Text)
                                ocm.Parameters.AddWithValue("@p16", ComboBox13.Text)
                                ocm.Parameters.AddWithValue("@p17", TextBox1.Text)

                                ocn.Open()
                                ocm.ExecuteNonQuery()
                                ocn.Close()
                                ocm.Dispose()
                                ocn.Dispose()

                                TextBox1.Text = ""
                                TextBox2.Text = ""
                                TextBox4.Text = ""
                                TextBox15.Text = ""
                                Button42_Click(sender, e)
                            End If

                        Case "بهمن"

                            address = Form1.TextBox3.Text
                            ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + ""
                            ocm.Connection = ocn
                            ocm.CommandText = "SELECT * FROM GhabzD where D11<>'""'"
                            oda.SelectCommand = ocm
                            If oda.Fill(dt) Then
                                MsgBox("اطلاعات قبلی موجود است", , "پیغام")
                            Else
                                address = Form1.TextBox3.Text
                                ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + ""
                                ocm.Connection = ocn
                                ocm.CommandText = "INSERT INTO GhabzD (D12,D11,D10,D9,D8,D7,D6,D5,D4,D3,D2,D1,T,mandeD,roosta,bakhsh,IDD) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17)"
                                ocm.Parameters.Clear()

                                Select Case TextBox3.Text
                                    Case "اسفند"

                                        ocm.Parameters.AddWithValue("@p1", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")

                                    Case "بهمن"

                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p2", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")

                                    Case "دی"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")

                                    Case "آذر"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "آبان"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "مهر"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "شهریور"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "مرداد"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "تیر"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "خرداد"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "اردیبهشت"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "فروردین"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", TextBox4.Text)

                                End Select

                                ocm.Parameters.AddWithValue("@p13", TextBox15.Text)
                                ocm.Parameters.AddWithValue("@p14", TextBox2.Text)
                                ocm.Parameters.AddWithValue("@p15", ComboBox1.Text)
                                ocm.Parameters.AddWithValue("@p16", ComboBox13.Text)
                                ocm.Parameters.AddWithValue("@p17", TextBox1.Text)

                                ocn.Open()
                                ocm.ExecuteNonQuery()
                                ocn.Close()
                                ocm.Dispose()
                                ocn.Dispose()

                                TextBox1.Text = ""
                                TextBox2.Text = ""
                                TextBox4.Text = ""
                                TextBox15.Text = ""
                                Button42_Click(sender, e)
                            End If

                        Case "دی"

                            address = Form1.TextBox3.Text
                            ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + ""
                            ocm.Connection = ocn
                            ocm.CommandText = "SELECT * FROM GhabzD where D10<>'""'"
                            oda.SelectCommand = ocm
                            If oda.Fill(dt) Then
                                MsgBox("اطلاعات قبلی موجود است", , "پیغام")
                            Else
                                address = Form1.TextBox3.Text
                                ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + ""
                                ocm.Connection = ocn
                                ocm.CommandText = "INSERT INTO GhabzD (D12,D11,D10,D9,D8,D7,D6,D5,D4,D3,D2,D1,T,mandeD,roosta,bakhsh,IDD) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17)"
                                ocm.Parameters.Clear()

                                Select Case TextBox3.Text
                                    Case "اسفند"

                                        ocm.Parameters.AddWithValue("@p1", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")

                                    Case "بهمن"

                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p2", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")

                                    Case "دی"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")

                                    Case "آذر"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "آبان"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "مهر"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "شهریور"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "مرداد"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "تیر"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "خرداد"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "اردیبهشت"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "فروردین"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", TextBox4.Text)

                                End Select

                                ocm.Parameters.AddWithValue("@p13", TextBox15.Text)
                                ocm.Parameters.AddWithValue("@p14", TextBox2.Text)
                                ocm.Parameters.AddWithValue("@p15", ComboBox1.Text)
                                ocm.Parameters.AddWithValue("@p16", ComboBox13.Text)
                                ocm.Parameters.AddWithValue("@p17", TextBox1.Text)

                                ocn.Open()
                                ocm.ExecuteNonQuery()
                                ocn.Close()
                                ocm.Dispose()
                                ocn.Dispose()

                                TextBox1.Text = ""
                                TextBox2.Text = ""
                                TextBox4.Text = ""
                                TextBox15.Text = ""
                                Button42_Click(sender, e)
                            End If

                        Case "آذر"

                            address = Form1.TextBox3.Text
                            ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + ""
                            ocm.Connection = ocn
                            ocm.CommandText = "SELECT * FROM GhabzD where D9<>'""'"
                            oda.SelectCommand = ocm
                            If oda.Fill(dt) Then
                                MsgBox("اطلاعات قبلی موجود است", , "پیغام")
                            Else
                                address = Form1.TextBox3.Text
                                ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + ""
                                ocm.Connection = ocn
                                ocm.CommandText = "INSERT INTO GhabzD (D12,D11,D10,D9,D8,D7,D6,D5,D4,D3,D2,D1,T,mandeD,roosta,bakhsh,IDD) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17)"
                                ocm.Parameters.Clear()

                                Select Case TextBox3.Text
                                    Case "اسفند"

                                        ocm.Parameters.AddWithValue("@p1", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")

                                    Case "بهمن"

                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p2", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")

                                    Case "دی"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")

                                    Case "آذر"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "آبان"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "مهر"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "شهریور"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "مرداد"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "تیر"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "خرداد"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "اردیبهشت"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "فروردین"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", TextBox4.Text)

                                End Select

                                ocm.Parameters.AddWithValue("@p13", TextBox15.Text)
                                ocm.Parameters.AddWithValue("@p14", TextBox2.Text)
                                ocm.Parameters.AddWithValue("@p15", ComboBox1.Text)
                                ocm.Parameters.AddWithValue("@p16", ComboBox13.Text)
                                ocm.Parameters.AddWithValue("@p17", TextBox1.Text)

                                ocn.Open()
                                ocm.ExecuteNonQuery()
                                ocn.Close()
                                ocm.Dispose()
                                ocn.Dispose()

                                TextBox1.Text = ""
                                TextBox2.Text = ""
                                TextBox4.Text = ""
                                TextBox15.Text = ""
                                Button42_Click(sender, e)
                            End If

                        Case "آبان"

                            address = Form1.TextBox3.Text
                            ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + ""
                            ocm.Connection = ocn
                            ocm.CommandText = "SELECT * FROM GhabzD where D8<>'""'"
                            oda.SelectCommand = ocm
                            If oda.Fill(dt) Then
                                MsgBox("اطلاعات قبلی موجود است", , "پیغام")
                            Else
                                address = Form1.TextBox3.Text
                                ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + ""
                                ocm.Connection = ocn
                                ocm.CommandText = "INSERT INTO GhabzD (D12,D11,D10,D9,D8,D7,D6,D5,D4,D3,D2,D1,T,mandeD,roosta,bakhsh,IDD) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17)"
                                ocm.Parameters.Clear()

                                Select Case TextBox3.Text
                                    Case "اسفند"

                                        ocm.Parameters.AddWithValue("@p1", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")

                                    Case "بهمن"

                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p2", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")

                                    Case "دی"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")

                                    Case "آذر"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "آبان"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "مهر"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "شهریور"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "مرداد"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "تیر"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "خرداد"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "اردیبهشت"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "فروردین"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", TextBox4.Text)

                                End Select

                                ocm.Parameters.AddWithValue("@p13", TextBox15.Text)
                                ocm.Parameters.AddWithValue("@p14", TextBox2.Text)
                                ocm.Parameters.AddWithValue("@p15", ComboBox1.Text)
                                ocm.Parameters.AddWithValue("@p16", ComboBox13.Text)
                                ocm.Parameters.AddWithValue("@p17", TextBox1.Text)

                                ocn.Open()
                                ocm.ExecuteNonQuery()
                                ocn.Close()
                                ocm.Dispose()
                                ocn.Dispose()

                                TextBox1.Text = ""
                                TextBox2.Text = ""
                                TextBox4.Text = ""
                                TextBox15.Text = ""
                                Button42_Click(sender, e)
                            End If

                        Case "مهر"

                            address = Form1.TextBox3.Text
                            ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + ""
                            ocm.Connection = ocn
                            ocm.CommandText = "SELECT * FROM GhabzD where D7<>'""'"
                            oda.SelectCommand = ocm
                            If oda.Fill(dt) Then
                                MsgBox("اطلاعات قبلی موجود است", , "پیغام")
                            Else
                                address = Form1.TextBox3.Text
                                ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + ""
                                ocm.Connection = ocn
                                ocm.CommandText = "INSERT INTO GhabzD (D12,D11,D10,D9,D8,D7,D6,D5,D4,D3,D2,D1,T,mandeD,roosta,bakhsh,IDD) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17)"
                                ocm.Parameters.Clear()

                                Select Case TextBox3.Text
                                    Case "اسفند"

                                        ocm.Parameters.AddWithValue("@p1", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")

                                    Case "بهمن"

                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p2", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")

                                    Case "دی"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")

                                    Case "آذر"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "آبان"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "مهر"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "شهریور"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "مرداد"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "تیر"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "خرداد"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "اردیبهشت"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "فروردین"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", TextBox4.Text)

                                End Select

                                ocm.Parameters.AddWithValue("@p13", TextBox15.Text)
                                ocm.Parameters.AddWithValue("@p14", TextBox2.Text)
                                ocm.Parameters.AddWithValue("@p15", ComboBox1.Text)
                                ocm.Parameters.AddWithValue("@p16", ComboBox13.Text)
                                ocm.Parameters.AddWithValue("@p17", TextBox1.Text)

                                ocn.Open()
                                ocm.ExecuteNonQuery()
                                ocn.Close()
                                ocm.Dispose()
                                ocn.Dispose()

                                TextBox1.Text = ""
                                TextBox2.Text = ""
                                TextBox4.Text = ""
                                TextBox15.Text = ""
                                Button42_Click(sender, e)
                            End If

                        Case "اشهریور"

                            address = Form1.TextBox3.Text
                            ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + ""
                            ocm.Connection = ocn
                            ocm.CommandText = "SELECT * FROM GhabzD where D6<>'""'"
                            oda.SelectCommand = ocm
                            If oda.Fill(dt) Then
                                MsgBox("اطلاعات قبلی موجود است", , "پیغام")
                            Else
                                address = Form1.TextBox3.Text
                                ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + ""
                                ocm.Connection = ocn
                                ocm.CommandText = "INSERT INTO GhabzD (D12,D11,D10,D9,D8,D7,D6,D5,D4,D3,D2,D1,T,mandeD,roosta,bakhsh,IDD) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17)"
                                ocm.Parameters.Clear()

                                Select Case TextBox3.Text
                                    Case "اسفند"

                                        ocm.Parameters.AddWithValue("@p1", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")

                                    Case "بهمن"

                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p2", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")

                                    Case "دی"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")

                                    Case "آذر"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "آبان"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "مهر"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "شهریور"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "مرداد"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "تیر"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "خرداد"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "اردیبهشت"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "فروردین"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", TextBox4.Text)

                                End Select

                                ocm.Parameters.AddWithValue("@p13", TextBox15.Text)
                                ocm.Parameters.AddWithValue("@p14", TextBox2.Text)
                                ocm.Parameters.AddWithValue("@p15", ComboBox1.Text)
                                ocm.Parameters.AddWithValue("@p16", ComboBox13.Text)
                                ocm.Parameters.AddWithValue("@p17", TextBox1.Text)

                                ocn.Open()
                                ocm.ExecuteNonQuery()
                                ocn.Close()
                                ocm.Dispose()
                                ocn.Dispose()

                                TextBox1.Text = ""
                                TextBox2.Text = ""
                                TextBox4.Text = ""
                                TextBox15.Text = ""
                                Button42_Click(sender, e)
                            End If

                        Case "مرداد"

                            address = Form1.TextBox3.Text
                            ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + ""
                            ocm.Connection = ocn
                            ocm.CommandText = "SELECT * FROM GhabzD where D5<>'""'"
                            oda.SelectCommand = ocm
                            If oda.Fill(dt) Then
                                MsgBox("اطلاعات قبلی موجود است", , "پیغام")
                            Else
                                address = Form1.TextBox3.Text
                                ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + ""
                                ocm.Connection = ocn
                                ocm.CommandText = "INSERT INTO GhabzD (D12,D11,D10,D9,D8,D7,D6,D5,D4,D3,D2,D1,T,mandeD,roosta,bakhsh,IDD) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17)"
                                ocm.Parameters.Clear()

                                Select Case TextBox3.Text
                                    Case "اسفند"

                                        ocm.Parameters.AddWithValue("@p1", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")

                                    Case "بهمن"

                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p2", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")

                                    Case "دی"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")

                                    Case "آذر"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "آبان"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "مهر"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "شهریور"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "مرداد"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "تیر"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "خرداد"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "اردیبهشت"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "فروردین"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", TextBox4.Text)

                                End Select

                                ocm.Parameters.AddWithValue("@p13", TextBox15.Text)
                                ocm.Parameters.AddWithValue("@p14", TextBox2.Text)
                                ocm.Parameters.AddWithValue("@p15", ComboBox1.Text)
                                ocm.Parameters.AddWithValue("@p16", ComboBox13.Text)
                                ocm.Parameters.AddWithValue("@p17", TextBox1.Text)

                                ocn.Open()
                                ocm.ExecuteNonQuery()
                                ocn.Close()
                                ocm.Dispose()
                                ocn.Dispose()

                                TextBox1.Text = ""
                                TextBox2.Text = ""
                                TextBox4.Text = ""
                                TextBox15.Text = ""
                                Button42_Click(sender, e)
                            End If

                        Case "تیر"

                            address = Form1.TextBox3.Text
                            ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + ""
                            ocm.Connection = ocn
                            ocm.CommandText = "SELECT * FROM GhabzD where D4<>'""'"
                            oda.SelectCommand = ocm
                            If oda.Fill(dt) Then
                                MsgBox("اطلاعات قبلی موجود است", , "پیغام")
                            Else
                                address = Form1.TextBox3.Text
                                ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + ""
                                ocm.Connection = ocn
                                ocm.CommandText = "INSERT INTO GhabzD (D12,D11,D10,D9,D8,D7,D6,D5,D4,D3,D2,D1,T,mandeD,roosta,bakhsh,IDD) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17)"
                                ocm.Parameters.Clear()

                                Select Case TextBox3.Text
                                    Case "اسفند"

                                        ocm.Parameters.AddWithValue("@p1", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")

                                    Case "بهمن"

                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p2", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")

                                    Case "دی"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")

                                    Case "آذر"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "آبان"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "مهر"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "شهریور"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "مرداد"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "تیر"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "خرداد"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "اردیبهشت"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "فروردین"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", TextBox4.Text)

                                End Select

                                ocm.Parameters.AddWithValue("@p13", TextBox15.Text)
                                ocm.Parameters.AddWithValue("@p14", TextBox2.Text)
                                ocm.Parameters.AddWithValue("@p15", ComboBox1.Text)
                                ocm.Parameters.AddWithValue("@p16", ComboBox13.Text)
                                ocm.Parameters.AddWithValue("@p17", TextBox1.Text)

                                ocn.Open()
                                ocm.ExecuteNonQuery()
                                ocn.Close()
                                ocm.Dispose()
                                ocn.Dispose()

                                TextBox1.Text = ""
                                TextBox2.Text = ""
                                TextBox4.Text = ""
                                TextBox15.Text = ""
                                Button42_Click(sender, e)
                            End If

                        Case "خرداد"

                            address = Form1.TextBox3.Text
                            ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + ""
                            ocm.Connection = ocn
                            ocm.CommandText = "SELECT * FROM GhabzD where D3<>'""'"
                            oda.SelectCommand = ocm
                            If oda.Fill(dt) Then
                                MsgBox("اطلاعات قبلی موجود است", , "پیغام")
                            Else
                                address = Form1.TextBox3.Text
                                ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + ""
                                ocm.Connection = ocn
                                ocm.CommandText = "INSERT INTO GhabzD (D12,D11,D10,D9,D8,D7,D6,D5,D4,D3,D2,D1,T,mandeD,roosta,bakhsh,IDD) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17)"
                                ocm.Parameters.Clear()

                                Select Case TextBox3.Text
                                    Case "اسفند"

                                        ocm.Parameters.AddWithValue("@p1", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")

                                    Case "بهمن"

                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p2", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")

                                    Case "دی"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")

                                    Case "آذر"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "آبان"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "مهر"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "شهریور"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "مرداد"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "تیر"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "خرداد"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "اردیبهشت"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "فروردین"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", TextBox4.Text)

                                End Select

                                ocm.Parameters.AddWithValue("@p13", TextBox15.Text)
                                ocm.Parameters.AddWithValue("@p14", TextBox2.Text)
                                ocm.Parameters.AddWithValue("@p15", ComboBox1.Text)
                                ocm.Parameters.AddWithValue("@p16", ComboBox13.Text)
                                ocm.Parameters.AddWithValue("@p17", TextBox1.Text)

                                ocn.Open()
                                ocm.ExecuteNonQuery()
                                ocn.Close()
                                ocm.Dispose()
                                ocn.Dispose()

                                TextBox1.Text = ""
                                TextBox2.Text = ""
                                TextBox4.Text = ""
                                TextBox15.Text = ""
                                Button42_Click(sender, e)
                            End If

                        Case "اردیبهشت"

                            address = Form1.TextBox3.Text
                            ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + ""
                            ocm.Connection = ocn
                            ocm.CommandText = "SELECT * FROM GhabzD where D2<>'""'"
                            oda.SelectCommand = ocm
                            If oda.Fill(dt) Then
                                MsgBox("اطلاعات قبلی موجود است", , "پیغام")
                            Else
                                address = Form1.TextBox3.Text
                                ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + ""
                                ocm.Connection = ocn
                                ocm.CommandText = "INSERT INTO GhabzD (D12,D11,D10,D9,D8,D7,D6,D5,D4,D3,D2,D1,T,mandeD,roosta,bakhsh,IDD) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17)"
                                ocm.Parameters.Clear()

                                Select Case TextBox3.Text
                                    Case "اسفند"

                                        ocm.Parameters.AddWithValue("@p1", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")

                                    Case "بهمن"

                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p2", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")

                                    Case "دی"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")

                                    Case "آذر"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "آبان"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "مهر"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "شهریور"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "مرداد"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "تیر"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "خرداد"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "اردیبهشت"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "فروردین"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", TextBox4.Text)

                                End Select

                                ocm.Parameters.AddWithValue("@p13", TextBox15.Text)
                                ocm.Parameters.AddWithValue("@p14", TextBox2.Text)
                                ocm.Parameters.AddWithValue("@p15", ComboBox1.Text)
                                ocm.Parameters.AddWithValue("@p16", ComboBox13.Text)
                                ocm.Parameters.AddWithValue("@p17", TextBox1.Text)

                                ocn.Open()
                                ocm.ExecuteNonQuery()
                                ocn.Close()
                                ocm.Dispose()
                                ocn.Dispose()

                                TextBox1.Text = ""
                                TextBox2.Text = ""
                                TextBox4.Text = ""
                                TextBox15.Text = ""
                                Button42_Click(sender, e)
                            End If

                        Case "فروردین"

                            address = Form1.TextBox3.Text
                            ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + ""
                            ocm.Connection = ocn
                            ocm.CommandText = "SELECT * FROM GhabzD where D1<>'""'"
                            oda.SelectCommand = ocm
                            If oda.Fill(dt) Then
                                MsgBox("اطلاعات قبلی موجود است", , "پیغام")
                            Else
                                address = Form1.TextBox3.Text
                                ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + ""
                                ocm.Connection = ocn
                                ocm.CommandText = "INSERT INTO GhabzD (D12,D11,D10,D9,D8,D7,D6,D5,D4,D3,D2,D1,T,mandeD,roosta,bakhsh,IDD) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17)"
                                ocm.Parameters.Clear()

                                Select Case TextBox3.Text
                                    Case "اسفند"

                                        ocm.Parameters.AddWithValue("@p1", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")

                                    Case "بهمن"

                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p2", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")

                                    Case "دی"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")

                                    Case "آذر"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "آبان"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "مهر"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "شهریور"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "مرداد"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "تیر"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "خرداد"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "اردیبهشت"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", TextBox4.Text)
                                        ocm.Parameters.AddWithValue("@p12", "")


                                    Case "فروردین"

                                        ocm.Parameters.AddWithValue("@p1", "")
                                        ocm.Parameters.AddWithValue("@p2", "")
                                        ocm.Parameters.AddWithValue("@p3", "")
                                        ocm.Parameters.AddWithValue("@p4", "")
                                        ocm.Parameters.AddWithValue("@p5", "")
                                        ocm.Parameters.AddWithValue("@p6", "")
                                        ocm.Parameters.AddWithValue("@p7", "")
                                        ocm.Parameters.AddWithValue("@p8", "")
                                        ocm.Parameters.AddWithValue("@p9", "")
                                        ocm.Parameters.AddWithValue("@p10", "")
                                        ocm.Parameters.AddWithValue("@p11", "")
                                        ocm.Parameters.AddWithValue("@p12", TextBox4.Text)

                                End Select

                                ocm.Parameters.AddWithValue("@p13", TextBox15.Text)
                                ocm.Parameters.AddWithValue("@p14", TextBox2.Text)
                                ocm.Parameters.AddWithValue("@p15", ComboBox1.Text)
                                ocm.Parameters.AddWithValue("@p16", ComboBox13.Text)
                                ocm.Parameters.AddWithValue("@p17", TextBox1.Text)

                                ocn.Open()
                                ocm.ExecuteNonQuery()
                                ocn.Close()
                                ocm.Dispose()
                                ocn.Dispose()

                                TextBox1.Text = ""
                                TextBox2.Text = ""
                                TextBox4.Text = ""
                                TextBox15.Text = ""
                                Button42_Click(sender, e)
                            End If

                    End Select
                Else
                    address = Form1.TextBox3.Text
                    ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + ""
                    ocm.Connection = ocn
                    ocm.CommandText = "INSERT INTO GhabzD (D12,D11,D10,D9,D8,D7,D6,D5,D4,D3,D2,D1,T,mandeD,roosta,bakhsh,IDD) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17)"
                    ocm.Parameters.Clear()

                    Select Case TextBox3.Text
                        Case "اسفند"

                            ocm.Parameters.AddWithValue("@p1", TextBox4.Text)
                            ocm.Parameters.AddWithValue("@p2", "")
                            ocm.Parameters.AddWithValue("@p3", "")
                            ocm.Parameters.AddWithValue("@p4", "")
                            ocm.Parameters.AddWithValue("@p5", "")
                            ocm.Parameters.AddWithValue("@p6", "")
                            ocm.Parameters.AddWithValue("@p7", "")
                            ocm.Parameters.AddWithValue("@p8", "")
                            ocm.Parameters.AddWithValue("@p9", "")
                            ocm.Parameters.AddWithValue("@p10", "")
                            ocm.Parameters.AddWithValue("@p11", "")
                            ocm.Parameters.AddWithValue("@p12", "")

                        Case "بهمن"

                            ocm.Parameters.AddWithValue("@p6", "")
                            ocm.Parameters.AddWithValue("@p2", TextBox4.Text)
                            ocm.Parameters.AddWithValue("@p3", "")
                            ocm.Parameters.AddWithValue("@p4", "")
                            ocm.Parameters.AddWithValue("@p5", "")
                            ocm.Parameters.AddWithValue("@p6", "")
                            ocm.Parameters.AddWithValue("@p7", "")
                            ocm.Parameters.AddWithValue("@p8", "")
                            ocm.Parameters.AddWithValue("@p9", "")
                            ocm.Parameters.AddWithValue("@p10", "")
                            ocm.Parameters.AddWithValue("@p11", "")
                            ocm.Parameters.AddWithValue("@p12", "")

                        Case "دی"

                            ocm.Parameters.AddWithValue("@p1", "")
                            ocm.Parameters.AddWithValue("@p2", "")
                            ocm.Parameters.AddWithValue("@p3", TextBox4.Text)
                            ocm.Parameters.AddWithValue("@p4", "")
                            ocm.Parameters.AddWithValue("@p5", "")
                            ocm.Parameters.AddWithValue("@p6", "")
                            ocm.Parameters.AddWithValue("@p7", "")
                            ocm.Parameters.AddWithValue("@p8", "")
                            ocm.Parameters.AddWithValue("@p9", "")
                            ocm.Parameters.AddWithValue("@p10", "")
                            ocm.Parameters.AddWithValue("@p11", "")
                            ocm.Parameters.AddWithValue("@p12", "")

                        Case "آذر"

                            ocm.Parameters.AddWithValue("@p1", "")
                            ocm.Parameters.AddWithValue("@p2", "")
                            ocm.Parameters.AddWithValue("@p3", "")
                            ocm.Parameters.AddWithValue("@p4", TextBox4.Text)
                            ocm.Parameters.AddWithValue("@p5", "")
                            ocm.Parameters.AddWithValue("@p6", "")
                            ocm.Parameters.AddWithValue("@p7", "")
                            ocm.Parameters.AddWithValue("@p8", "")
                            ocm.Parameters.AddWithValue("@p9", "")
                            ocm.Parameters.AddWithValue("@p10", "")
                            ocm.Parameters.AddWithValue("@p11", "")
                            ocm.Parameters.AddWithValue("@p12", "")


                        Case "آبان"

                            ocm.Parameters.AddWithValue("@p1", "")
                            ocm.Parameters.AddWithValue("@p2", "")
                            ocm.Parameters.AddWithValue("@p3", "")
                            ocm.Parameters.AddWithValue("@p4", "")
                            ocm.Parameters.AddWithValue("@p5", TextBox4.Text)
                            ocm.Parameters.AddWithValue("@p6", "")
                            ocm.Parameters.AddWithValue("@p7", "")
                            ocm.Parameters.AddWithValue("@p8", "")
                            ocm.Parameters.AddWithValue("@p9", "")
                            ocm.Parameters.AddWithValue("@p10", "")
                            ocm.Parameters.AddWithValue("@p11", "")
                            ocm.Parameters.AddWithValue("@p12", "")


                        Case "مهر"

                            ocm.Parameters.AddWithValue("@p1", "")
                            ocm.Parameters.AddWithValue("@p2", "")
                            ocm.Parameters.AddWithValue("@p3", "")
                            ocm.Parameters.AddWithValue("@p4", "")
                            ocm.Parameters.AddWithValue("@p5", "")
                            ocm.Parameters.AddWithValue("@p6", TextBox4.Text)
                            ocm.Parameters.AddWithValue("@p7", "")
                            ocm.Parameters.AddWithValue("@p8", "")
                            ocm.Parameters.AddWithValue("@p9", "")
                            ocm.Parameters.AddWithValue("@p10", "")
                            ocm.Parameters.AddWithValue("@p11", "")
                            ocm.Parameters.AddWithValue("@p12", "")


                        Case "شهریور"

                            ocm.Parameters.AddWithValue("@p1", "")
                            ocm.Parameters.AddWithValue("@p2", "")
                            ocm.Parameters.AddWithValue("@p3", "")
                            ocm.Parameters.AddWithValue("@p4", "")
                            ocm.Parameters.AddWithValue("@p5", "")
                            ocm.Parameters.AddWithValue("@p6", "")
                            ocm.Parameters.AddWithValue("@p7", TextBox4.Text)
                            ocm.Parameters.AddWithValue("@p8", "")
                            ocm.Parameters.AddWithValue("@p9", "")
                            ocm.Parameters.AddWithValue("@p10", "")
                            ocm.Parameters.AddWithValue("@p11", "")
                            ocm.Parameters.AddWithValue("@p12", "")


                        Case "مرداد"

                            ocm.Parameters.AddWithValue("@p1", "")
                            ocm.Parameters.AddWithValue("@p2", "")
                            ocm.Parameters.AddWithValue("@p3", "")
                            ocm.Parameters.AddWithValue("@p4", "")
                            ocm.Parameters.AddWithValue("@p5", "")
                            ocm.Parameters.AddWithValue("@p6", "")
                            ocm.Parameters.AddWithValue("@p7", "")
                            ocm.Parameters.AddWithValue("@p8", TextBox4.Text)
                            ocm.Parameters.AddWithValue("@p9", "")
                            ocm.Parameters.AddWithValue("@p10", "")
                            ocm.Parameters.AddWithValue("@p11", "")
                            ocm.Parameters.AddWithValue("@p12", "")


                        Case "تیر"

                            ocm.Parameters.AddWithValue("@p1", "")
                            ocm.Parameters.AddWithValue("@p2", "")
                            ocm.Parameters.AddWithValue("@p3", "")
                            ocm.Parameters.AddWithValue("@p4", "")
                            ocm.Parameters.AddWithValue("@p5", "")
                            ocm.Parameters.AddWithValue("@p6", "")
                            ocm.Parameters.AddWithValue("@p7", "")
                            ocm.Parameters.AddWithValue("@p8", "")
                            ocm.Parameters.AddWithValue("@p9", TextBox4.Text)
                            ocm.Parameters.AddWithValue("@p10", "")
                            ocm.Parameters.AddWithValue("@p11", "")
                            ocm.Parameters.AddWithValue("@p12", "")


                        Case "خرداد"

                            ocm.Parameters.AddWithValue("@p1", "")
                            ocm.Parameters.AddWithValue("@p2", "")
                            ocm.Parameters.AddWithValue("@p3", "")
                            ocm.Parameters.AddWithValue("@p4", "")
                            ocm.Parameters.AddWithValue("@p5", "")
                            ocm.Parameters.AddWithValue("@p6", "")
                            ocm.Parameters.AddWithValue("@p7", "")
                            ocm.Parameters.AddWithValue("@p8", "")
                            ocm.Parameters.AddWithValue("@p9", "")
                            ocm.Parameters.AddWithValue("@p10", TextBox4.Text)
                            ocm.Parameters.AddWithValue("@p11", "")
                            ocm.Parameters.AddWithValue("@p12", "")


                        Case "اردیبهشت"

                            ocm.Parameters.AddWithValue("@p1", "")
                            ocm.Parameters.AddWithValue("@p2", "")
                            ocm.Parameters.AddWithValue("@p3", "")
                            ocm.Parameters.AddWithValue("@p4", "")
                            ocm.Parameters.AddWithValue("@p5", "")
                            ocm.Parameters.AddWithValue("@p6", "")
                            ocm.Parameters.AddWithValue("@p7", "")
                            ocm.Parameters.AddWithValue("@p8", "")
                            ocm.Parameters.AddWithValue("@p9", "")
                            ocm.Parameters.AddWithValue("@p10", "")
                            ocm.Parameters.AddWithValue("@p11", TextBox4.Text)
                            ocm.Parameters.AddWithValue("@p12", "")


                        Case "فروردین"

                            ocm.Parameters.AddWithValue("@p1", "")
                            ocm.Parameters.AddWithValue("@p2", "")
                            ocm.Parameters.AddWithValue("@p3", "")
                            ocm.Parameters.AddWithValue("@p4", "")
                            ocm.Parameters.AddWithValue("@p5", "")
                            ocm.Parameters.AddWithValue("@p6", "")
                            ocm.Parameters.AddWithValue("@p7", "")
                            ocm.Parameters.AddWithValue("@p8", "")
                            ocm.Parameters.AddWithValue("@p9", "")
                            ocm.Parameters.AddWithValue("@p10", "")
                            ocm.Parameters.AddWithValue("@p11", "")
                            ocm.Parameters.AddWithValue("@p12", TextBox4.Text)

                    End Select

                    ocm.Parameters.AddWithValue("@p13", TextBox15.Text)
                    ocm.Parameters.AddWithValue("@p14", TextBox2.Text)
                    ocm.Parameters.AddWithValue("@p15", ComboBox1.Text)
                    ocm.Parameters.AddWithValue("@p16", ComboBox13.Text)
                    ocm.Parameters.AddWithValue("@p17", TextBox1.Text)

                    ocn.Open()
                    ocm.ExecuteNonQuery()
                    ocn.Close()
                    ocm.Dispose()
                    ocn.Dispose()

                    TextBox1.Text = ""
                    TextBox2.Text = ""
                    TextBox4.Text = ""
                    TextBox15.Text = ""
                    Button42_Click(sender, e)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
        
    End Sub

    Private Sub ComboBox14_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox14.DropDown
        test = True
    End Sub

    Private Sub ComboBox14_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboBox14.KeyDown
        e.SuppressKeyPress = True
    End Sub

    Private Sub ComboBox14_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox14.KeyPress
        e.Handled = True
    End Sub

    Private Sub ComboBox14_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox14.SelectedIndexChanged
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
                If Not ComboBox14.SelectedItem = "کل روستاها" Then


                    ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\Data.mdb"
                    ocm.Connection = ocn
                    ocm.CommandText = "SELECT roosta FROM Roostaha where bakhsh='" & ComboBox14.SelectedItem & "'"
                    oda.SelectCommand = ocm
                    da = New OleDbDataAdapter(ocm.CommandText, ocn)
                    da.Fill(ds, "Roostaha")

                    Do
                        TextBox14.Text = TextBox8.Text
                        TextBox8.DataBindings.Add(New Binding("Text", ds, "Roostaha.roosta"))
                        ComboBox3.Items.Add(TextBox8.Text)
                        Me.BindingContext(ds, "Roostaha").Position += 1
                        TextBox8.DataBindings.Clear()
                        If TextBox8.Text = TextBox14.Text Then
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
                        TextBox14.Text = TextBox8.Text
                        TextBox8.DataBindings.Add(New Binding("Text", ds, "Roostaha.roosta"))
                        ComboBox3.Items.Add(TextBox8.Text)
                        Me.BindingContext(ds, "Roostaha").Position += 1
                        TextBox8.DataBindings.Clear()
                        If TextBox8.Text = TextBox14.Text Then
                            Exit Do
                        End If
                    Loop
                    oda.Dispose()
                    ocm.Dispose()
                    ocn.Dispose()
                End If
                Button13.Visible = True
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
            ComboBox14.DataBindings.Add(New Binding("text", ds, "Roostaha.bakhsh"))
            ComboBox14.DataBindings.Clear()
            oda.Dispose()
            ocm.Dispose()
            ocn.Dispose()
            Button13.Visible = True
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
       
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        Try
            ComboBox14.Text = ""
            ComboBox3.Text = ""
            ComboBox3.Items.Clear()
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
                TextBox14.Text = TextBox8.Text
                TextBox8.DataBindings.Add(New Binding("Text", ds, "Roostaha.roosta"))
                ComboBox3.Items.Add(TextBox8.Text)
                Me.BindingContext(ds, "Roostaha").Position += 1
                TextBox8.DataBindings.Clear()
                If TextBox8.Text = TextBox14.Text Then
                    Exit Do
                End If
            Loop
            oda.Dispose()
            ocm.Dispose()
            ocn.Dispose()
            ComboBox3.Enabled = True
            ComboBox14.Enabled = True
            Button13.Visible = False
            test = True
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
       
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

    Private Sub TextBox9_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox9.Click
        TextBox9.Text = ""
    End Sub

    Private Sub TextBox10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox10.Click
        TextBox10.Text = ""
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox4.Text = ""
        Button13_Click(sender, e)
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Try
            Dim ocm As New System.Data.OleDb.OleDbCommand
            Dim oda As New System.Data.OleDb.OleDbDataAdapter
            Dim ocn As New System.Data.OleDb.OleDbConnection
            If ComboBox14.Text = "" Or ComboBox3.Text = "" Or TextBox6.Text = "" Or TextBox5.Text = "" Then
                MsgBox("مشخصات فرم گزارش کامل نیست", , "پیغام")
            ElseIf ComboBox8.Text = "روز" Or ComboBox9.Text = "ماه" Or TextBox10.Text = "سال" Or TextBox10.Text = "" Or ComboBox11.Text = "روز" Or ComboBox10.Text = "ماه" Or TextBox9.Text = "سال" Or TextBox9.Text = "" Then
                MsgBox("فیلد ها را تکمیل کنید", , "پیغام")
            ElseIf ((Convert.ToInt32(ComboBox10.Text)) > (Convert.ToInt32(ComboBox9.Text)) And (Convert.ToInt32(TextBox9.Text)) >= (Convert.ToInt32(TextBox10.Text)) Or ((Convert.ToInt32(ComboBox10.Text)) = (Convert.ToInt32(ComboBox9.Text)) And (Convert.ToInt32(TextBox10.Text)) = (Convert.ToInt32(TextBox9.Text)) And (Convert.ToInt32(ComboBox11.Text)) > (Convert.ToInt32(ComboBox8.Text)))) Then
                MsgBox("خطا در تاریخ ورودی", , "پیغام")
            Else
                't = False
                Call Toshamsi()
                address = Form1.TextBox3.Text
                ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + ""
                ocm.Connection = ocn
                ocm.CommandText = "INSERT INTO GhabzA (T,bishtar,D6A,D5A,D4A,D3A,D2A,D1A,Y2,M2,D2,Y1,M1,D1,mandeA,roosta,bakhsh,IDA) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17,@p18)"
                ocm.Parameters.Clear()

                ocm.Parameters.AddWithValue("@p18", TextBox18.Text)
                ocm.Parameters.AddWithValue("@p17", TextBox11.Text)

                Select Case ComboBox4.Text
                    Case "دوره 6"

                        ocm.Parameters.AddWithValue("@p1", TextBox5.Text)
                        ocm.Parameters.AddWithValue("@p2", "")
                        ocm.Parameters.AddWithValue("@p3", "")
                        ocm.Parameters.AddWithValue("@p4", "")
                        ocm.Parameters.AddWithValue("@p5", "")
                        ocm.Parameters.AddWithValue("@p6", "")


                    Case "دوره 5"

                        ocm.Parameters.AddWithValue("@p6", "")
                        ocm.Parameters.AddWithValue("@p2", TextBox5.Text)
                        ocm.Parameters.AddWithValue("@p3", "")
                        ocm.Parameters.AddWithValue("@p4", "")
                        ocm.Parameters.AddWithValue("@p5", "")
                        ocm.Parameters.AddWithValue("@p6", "")

                    Case "دوره 4"

                        ocm.Parameters.AddWithValue("@p1", "")
                        ocm.Parameters.AddWithValue("@p2", "")
                        ocm.Parameters.AddWithValue("@p3", TextBox5.Text)
                        ocm.Parameters.AddWithValue("@p4", "")
                        ocm.Parameters.AddWithValue("@p5", "")
                        ocm.Parameters.AddWithValue("@p6", "")

                    Case "دوره 3"

                        ocm.Parameters.AddWithValue("@p1", "")
                        ocm.Parameters.AddWithValue("@p2", "")
                        ocm.Parameters.AddWithValue("@p3", "")
                        ocm.Parameters.AddWithValue("@p4", TextBox5.Text)
                        ocm.Parameters.AddWithValue("@p5", "")
                        ocm.Parameters.AddWithValue("@p6", "")

                    Case "دوره 2"

                        ocm.Parameters.AddWithValue("@p1", "")
                        ocm.Parameters.AddWithValue("@p2", "")
                        ocm.Parameters.AddWithValue("@p3", "")
                        ocm.Parameters.AddWithValue("@p4", "")
                        ocm.Parameters.AddWithValue("@p5", TextBox5.Text)
                        ocm.Parameters.AddWithValue("@p6", "")

                    Case "دوره 1"

                        ocm.Parameters.AddWithValue("@p1", "")
                        ocm.Parameters.AddWithValue("@p2", "")
                        ocm.Parameters.AddWithValue("@p3", "")
                        ocm.Parameters.AddWithValue("@p4", "")
                        ocm.Parameters.AddWithValue("@p5", "")
                        ocm.Parameters.AddWithValue("@p6", TextBox5.Text)


                End Select

                ocm.Parameters.AddWithValue("@p7", TextBox10.Text)
                ocm.Parameters.AddWithValue("@p8", ComboBox9.Text)
                ocm.Parameters.AddWithValue("@p9", ComboBox8.Text)
                ocm.Parameters.AddWithValue("@p10", TextBox9.Text)
                ocm.Parameters.AddWithValue("@p11", ComboBox10.Text)
                ocm.Parameters.AddWithValue("@p12", ComboBox11.Text)

                ocm.Parameters.AddWithValue("@p13", TextBox7.Text)
                ocm.Parameters.AddWithValue("@p14", ComboBox3.Text)
                ocm.Parameters.AddWithValue("@p15", ComboBox14.Text)
                ocm.Parameters.AddWithValue("@p16", TextBox6.Text)


                ocn.Open()
                ocm.ExecuteNonQuery()
                ocn.Close()
                ocm.Dispose()
                ocn.Dispose()

                TextBox6.Text = ""
                TextBox11.Text = ""
                TextBox7.Text = ""
                TextBox5.Text = ""
                ComboBox11.Text = "روز"
                ComboBox10.Text = "ماه"
                ComboBox8.Text = "روز"
                ComboBox9.Text = "ماه"
                TextBox10.Text = "سال"
                TextBox9.Text = "سال"
                Button13_Click(sender, e)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
        
    End Sub

    Private Sub ComboBox5_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox5.DropDown
        test = True
    End Sub

    Private Sub ComboBox5_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboBox5.KeyDown
        e.SuppressKeyPress = True
    End Sub

    Private Sub ComboBox5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox5.KeyPress
        e.Handled = True
    End Sub

    Private Sub ComboBox5_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox5.SelectedIndexChanged
        Try
            If Not test Then
                Exit Sub
            Else
                Dim ocn As New System.Data.OleDb.OleDbConnection
                Dim ocm As New System.Data.OleDb.OleDbCommand
                Dim oda As New System.Data.OleDb.OleDbDataAdapter
                Dim ds As New DataSet()

                ComboBox6.Items.Clear()
                ComboBox6.Text = ""
                If Not ComboBox5.SelectedItem = "کل روستاها" Then


                    ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\Data.mdb"
                    ocm.Connection = ocn
                    ocm.CommandText = "SELECT roosta FROM Roostaha where bakhsh='" & ComboBox5.SelectedItem & "'"
                    oda.SelectCommand = ocm
                    da = New OleDbDataAdapter(ocm.CommandText, ocn)
                    da.Fill(ds, "Roostaha")

                    Do
                        TextBox14.Text = TextBox8.Text
                        TextBox8.DataBindings.Add(New Binding("Text", ds, "Roostaha.roosta"))
                        ComboBox6.Items.Add(TextBox8.Text)
                        Me.BindingContext(ds, "Roostaha").Position += 1
                        TextBox8.DataBindings.Clear()
                        If TextBox8.Text = TextBox14.Text Then
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
                        TextBox14.Text = TextBox8.Text
                        TextBox8.DataBindings.Add(New Binding("Text", ds, "Roostaha.roosta"))
                        ComboBox6.Items.Add(TextBox8.Text)
                        Me.BindingContext(ds, "Roostaha").Position += 1
                        TextBox8.DataBindings.Clear()
                        If TextBox8.Text = TextBox14.Text Then
                            Exit Do
                        End If
                    Loop
                    oda.Dispose()
                    ocm.Dispose()
                    ocn.Dispose()
                End If
                Button14.Visible = True
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
      
    End Sub

    Private Sub ComboBox6_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox6.SelectedIndexChanged
        Try
            test = False
            Dim ocn As New System.Data.OleDb.OleDbConnection
            Dim ocm As New System.Data.OleDb.OleDbCommand
            Dim oda As New System.Data.OleDb.OleDbDataAdapter
            Dim ds As New DataSet()
            ComboBox6.Text = ComboBox6.SelectedText
            ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\Data.mdb"
            ocm.Connection = ocn
            ocm.CommandText = "SELECT bakhsh FROM Roostaha where roosta='" & ComboBox6.SelectedItem & "'"
            oda.SelectCommand = ocm
            da = New OleDbDataAdapter(ocm.CommandText, ocn)
            da.Fill(ds, "Roostaha")
            ComboBox5.DataBindings.Add(New Binding("text", ds, "Roostaha.bakhsh"))
            ComboBox5.DataBindings.Clear()
            oda.Dispose()
            ocm.Dispose()
            ocn.Dispose()
            Button14.Visible = True
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
       
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        Try
            ComboBox5.Text = ""
            ComboBox6.Text = ""
            ComboBox6.Items.Clear()
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
                TextBox14.Text = TextBox8.Text
                TextBox8.DataBindings.Add(New Binding("Text", ds, "Roostaha.roosta"))
                ComboBox6.Items.Add(TextBox8.Text)
                Me.BindingContext(ds, "Roostaha").Position += 1
                TextBox8.DataBindings.Clear()
                If TextBox8.Text = TextBox14.Text Then
                    Exit Do
                End If
            Loop
            oda.Dispose()
            ocm.Dispose()
            ocn.Dispose()
            ComboBox5.Enabled = True
            ComboBox6.Enabled = True
            Button14.Visible = False
            test = True
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
        
    End Sub

    Private Sub ComboBox7_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox7.SelectedIndexChanged
        Try
            If Not test Then
                Exit Sub
            Else
                Dim ocn As New System.Data.OleDb.OleDbConnection
                Dim ocm As New System.Data.OleDb.OleDbCommand
                Dim oda As New System.Data.OleDb.OleDbDataAdapter
                Dim ds As New DataSet()

                ComboBox12.Items.Clear()
                ComboBox12.Text = ""
                If Not ComboBox5.SelectedItem = "کل روستاها" Then


                    ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\Data.mdb"
                    ocm.Connection = ocn
                    ocm.CommandText = "SELECT roosta FROM Roostaha where bakhsh='" & ComboBox7.SelectedItem & "'"
                    oda.SelectCommand = ocm
                    da = New OleDbDataAdapter(ocm.CommandText, ocn)
                    da.Fill(ds, "Roostaha")

                    Do
                        TextBox14.Text = TextBox8.Text
                        TextBox8.DataBindings.Add(New Binding("Text", ds, "Roostaha.roosta"))
                        ComboBox12.Items.Add(TextBox8.Text)
                        Me.BindingContext(ds, "Roostaha").Position += 1
                        TextBox8.DataBindings.Clear()
                        If TextBox8.Text = TextBox14.Text Then
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
                        TextBox14.Text = TextBox8.Text
                        TextBox8.DataBindings.Add(New Binding("Text", ds, "Roostaha.roosta"))
                        ComboBox12.Items.Add(TextBox8.Text)
                        Me.BindingContext(ds, "Roostaha").Position += 1
                        TextBox8.DataBindings.Clear()
                        If TextBox8.Text = TextBox14.Text Then
                            Exit Do
                        End If
                    Loop
                    oda.Dispose()
                    ocm.Dispose()
                    ocn.Dispose()
                End If
                Button15.Visible = True
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
        
    End Sub

    Private Sub ComboBox7_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox7.DropDown
        test = True
    End Sub

    Private Sub ComboBox7_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboBox7.KeyDown
        e.SuppressKeyPress = True
    End Sub

    Private Sub ComboBox7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox7.KeyPress
        e.Handled = True
    End Sub


    Private Sub ComboBox12_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox12.SelectedIndexChanged
        Try
            test = False
            Dim ocn As New System.Data.OleDb.OleDbConnection
            Dim ocm As New System.Data.OleDb.OleDbCommand
            Dim oda As New System.Data.OleDb.OleDbDataAdapter
            Dim ds As New DataSet()
            ComboBox12.Text = ComboBox12.SelectedText
            ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\Data.mdb"
            ocm.Connection = ocn
            ocm.CommandText = "SELECT bakhsh FROM Roostaha where roosta='" & ComboBox12.SelectedItem & "'"
            oda.SelectCommand = ocm
            da = New OleDbDataAdapter(ocm.CommandText, ocn)
            da.Fill(ds, "Roostaha")
            ComboBox7.DataBindings.Add(New Binding("text", ds, "Roostaha.bakhsh"))
            ComboBox7.DataBindings.Clear()
            oda.Dispose()
            ocm.Dispose()
            ocn.Dispose()
            Button15.Visible = True
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
        
    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        Try
            ComboBox7.Text = ""
            ComboBox12.Text = ""
            ComboBox12.Items.Clear()
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
                TextBox14.Text = TextBox8.Text
                TextBox8.DataBindings.Add(New Binding("Text", ds, "Roostaha.roosta"))
                ComboBox12.Items.Add(TextBox8.Text)
                Me.BindingContext(ds, "Roostaha").Position += 1
                TextBox8.DataBindings.Clear()
                If TextBox8.Text = TextBox14.Text Then
                    Exit Do
                End If
            Loop
            oda.Dispose()
            ocm.Dispose()
            ocn.Dispose()
            ComboBox7.Enabled = True
            ComboBox12.Enabled = True
            Button15.Visible = False
            test = True
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
        
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Try
            DataGridView1.DataSource = 0
            If TextBox12.Text = "" Or TextBox16.Text = "" Then
                MsgBox("خطای فیلد های خالی", , "پیغام")
            Else
                If CheckBox1.Checked Then
                    If TextBox12.Text > TextBox16.Text Or (TextBox12.Text = TextBox16.Text And ComboBox17.SelectedIndex > ComboBox15.SelectedIndex) Or (ComboBox17.SelectedIndex > ComboBox15.SelectedIndex) Then
                        MsgBox("خطای سال/دوره ورودی", , "پیغام")
                    Else
                        address = Form1.TextBox3.Text
                        Dim ocn As New System.Data.OleDb.OleDbConnection
                        Dim ocm As New System.Data.OleDb.OleDbCommand
                        Dim oda As New System.Data.OleDb.OleDbDataAdapter
                        Dim dt As New DataTable

                        ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + ""
                        ocm.Connection = ocn
                        ocm.CommandText = "SELECT * FROM GhabzD  where (T >= '" & TextBox12.Text & " ' and T <= '" & TextBox16.Text & " ')"
                        oda.SelectCommand = ocm
                        oda.Fill(dt)
                        DataGridView1.DataSource = dt

                        DataGridView1.Columns(0).HeaderText = "دوره 12 اسفند"
                        DataGridView1.Columns(0).Width = 70
                        DataGridView1.Columns(1).HeaderText = "دوره 11 بهمن"
                        DataGridView1.Columns(1).Width = 70
                        DataGridView1.Columns(2).HeaderText = "دوره 10 دی"
                        DataGridView1.Columns(2).Width = 70
                        DataGridView1.Columns(3).HeaderText = "دوره 9 آذر"
                        DataGridView1.Columns(3).Width = 70
                        DataGridView1.Columns(4).HeaderText = "دوره 8 آبان"
                        DataGridView1.Columns(4).Width = 70
                        DataGridView1.Columns(5).HeaderText = "دوره 7 مهر"
                        DataGridView1.Columns(5).Width = 70
                        DataGridView1.Columns(6).HeaderText = "دوره 6 شهریور"
                        DataGridView1.Columns(6).Width = 70
                        DataGridView1.Columns(7).HeaderText = "دوره 5 مرداد"
                        DataGridView1.Columns(7).Width = 70
                        DataGridView1.Columns(8).HeaderText = "دوره 4 تیر"
                        DataGridView1.Columns(8).Width = 70
                        DataGridView1.Columns(9).HeaderText = "دوره 3 خرداد"
                        DataGridView1.Columns(9).Width = 70
                        DataGridView1.Columns(10).HeaderText = "دوره 2 اردیبهشت"
                        DataGridView1.Columns(10).Width = 70
                        DataGridView1.Columns(11).HeaderText = "دوره 1 فروردین"
                        DataGridView1.Columns(11).Width = 70
                        DataGridView1.Columns(12).HeaderText = "سال"
                        DataGridView1.Columns(12).Width = 45
                        DataGridView1.Columns(13).HeaderText = "بدهی از سال گذشته"
                        'DataGridView1.Columns(13).Width = 70
                        DataGridView1.Columns(14).HeaderText = "نام روستا"
                        DataGridView1.Columns(15).HeaderText = "بخش"
                        DataGridView1.Columns(15).Width = 70
                        DataGridView1.Columns(16).HeaderText = "شماره اشتراک"
                        'DataGridView1.Columns(16).Width = 70

                        DataGridView1.Columns(16).Visible = False
                        For lp = 0 To 10 - ComboBox15.SelectedIndex
                            DataGridView1.Columns(lp).Visible = False
                        Next lp
                        For lp = 12 - ComboBox17.SelectedIndex To 11
                            DataGridView1.Columns(lp).Visible = False
                        Next lp
                        dt.Dispose()
                        oda.Dispose()
                        ocm.Dispose()
                        ocn.Dispose()
                    End If
                Else
                    If ComboBox5.Text = "" Or ComboBox6.Text = "" Or TextBox12.Text = "" Or TextBox16.Text = "" Then
                        MsgBox("خطای فیلد های خالی", , "پیغام")
                    ElseIf TextBox12.Text > TextBox16.Text Or (TextBox12.Text = TextBox16.Text And ComboBox17.SelectedIndex > ComboBox15.SelectedIndex) Then
                        MsgBox("خطای سال/دوره ورودی", , "پیغام")
                    Else
                        address = Form1.TextBox3.Text
                        Dim ocn As New System.Data.OleDb.OleDbConnection
                        Dim ocm As New System.Data.OleDb.OleDbCommand
                        Dim oda As New System.Data.OleDb.OleDbDataAdapter
                        Dim dt As New DataTable
                        ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + ""
                        ocm.Connection = ocn
                        ocm.CommandText = "SELECT * FROM GhabzD where (T >= '" & TextBox12.Text & " ' and T <= '" & TextBox16.Text & " ' and roosta = '" & ComboBox6.Text & "')"
                        oda.SelectCommand = ocm
                        oda.Fill(dt)
                        DataGridView1.DataSource = dt

                        DataGridView1.Columns(0).HeaderText = "دوره 12 اسفند"
                        DataGridView1.Columns(0).Width = 70
                        DataGridView1.Columns(1).HeaderText = "دوره 11 بهمن"
                        DataGridView1.Columns(1).Width = 70
                        DataGridView1.Columns(2).HeaderText = "دوره 10 دی"
                        DataGridView1.Columns(2).Width = 70
                        DataGridView1.Columns(3).HeaderText = "دوره 9 آذر"
                        DataGridView1.Columns(3).Width = 70
                        DataGridView1.Columns(4).HeaderText = "دوره 8 آبان"
                        DataGridView1.Columns(4).Width = 70
                        DataGridView1.Columns(5).HeaderText = "دوره 7 مهر"
                        DataGridView1.Columns(5).Width = 70
                        DataGridView1.Columns(6).HeaderText = "دوره 6 شهریور"
                        DataGridView1.Columns(6).Width = 70
                        DataGridView1.Columns(7).HeaderText = "دوره 5 مرداد"
                        DataGridView1.Columns(7).Width = 70
                        DataGridView1.Columns(8).HeaderText = "دوره 4 تیر"
                        DataGridView1.Columns(8).Width = 70
                        DataGridView1.Columns(9).HeaderText = "دوره 3 خرداد"
                        DataGridView1.Columns(9).Width = 70
                        DataGridView1.Columns(10).HeaderText = "دوره 2 اردیبهشت"
                        DataGridView1.Columns(10).Width = 70
                        DataGridView1.Columns(11).HeaderText = "دوره 1 فروردین"
                        DataGridView1.Columns(11).Width = 70
                        DataGridView1.Columns(12).HeaderText = "سال"
                        DataGridView1.Columns(12).Width = 45
                        DataGridView1.Columns(13).HeaderText = "بدهی از سال گذشته"
                        'DataGridView1.Columns(13).Width = 70
                        DataGridView1.Columns(14).HeaderText = "نام روستا"
                        DataGridView1.Columns(15).HeaderText = "بخش"
                        DataGridView1.Columns(15).Width = 70
                        DataGridView1.Columns(16).HeaderText = "شماره اشتراک"
                        'DataGridView1.Columns(16).Width = 70

                        DataGridView1.Columns(16).Visible = False
                        For lp = 0 To 10 - ComboBox15.SelectedIndex
                            DataGridView1.Columns(lp).Visible = False
                        Next lp
                        For lp = 12 - ComboBox17.SelectedIndex To 11
                            DataGridView1.Columns(lp).Visible = False
                        Next lp

                        dt.Dispose()
                        oda.Dispose()
                        ocm.Dispose()
                        ocn.Dispose()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
        
    End Sub

    Private Sub Form20_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        y = Me.Size.Height
        x = Me.Size.Width

        GroupBox1.Location = New System.Drawing.Point((x / 30), 3)
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            ComboBox5.Text = ""
            ComboBox6.Text = ""
            ComboBox5.Enabled = False
            ComboBox6.Enabled = False
        Else
            ComboBox5.Enabled = True
            ComboBox6.Enabled = True
        End If
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Try
            DataGridView1.DataSource = 0
            If TextBox17.Text = "" Then
                MsgBox("خطای فیلد های خالی", , "پیغام")
            Else
                If CheckBox2.Checked Then
                    If ComboBox16.SelectedIndex > ComboBox18.SelectedIndex Then
                        MsgBox("خطای سال/دوره ورودی", , "پیغام")
                    Else
                        address = Form1.TextBox3.Text
                        Dim ocn As New System.Data.OleDb.OleDbConnection
                        Dim ocm As New System.Data.OleDb.OleDbCommand
                        Dim oda As New System.Data.OleDb.OleDbDataAdapter
                        Dim dt As New DataTable
                        ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + ""
                        ocm.Connection = ocn
                        ocm.CommandText = "SELECT * FROM GhabzA  where (T = '" & TextBox17.Text & " ')"
                        oda.SelectCommand = ocm
                        oda.Fill(dt)
                        DataGridView1.DataSource = dt

                        DataGridView1.Columns(1).HeaderText = "توضیحات"
                        DataGridView1.Columns(2).HeaderText = "دوره 6"
                        DataGridView1.Columns(3).HeaderText = "دوره 5"
                        DataGridView1.Columns(4).HeaderText = "دوره 4"
                        DataGridView1.Columns(5).HeaderText = "دوره 3"
                        DataGridView1.Columns(6).HeaderText = "دوره 2"
                        DataGridView1.Columns(7).HeaderText = "دوره 1"
                        DataGridView1.Columns(8).HeaderText = "تا سال"
                        DataGridView1.Columns(8).Width = 64
                        DataGridView1.Columns(9).HeaderText = "تا ماه"
                        DataGridView1.Columns(9).Width = 25
                        DataGridView1.Columns(10).HeaderText = "تا روز"
                        DataGridView1.Columns(10).Width = 25
                        DataGridView1.Columns(11).HeaderText = "از سال"
                        DataGridView1.Columns(11).Width = 64
                        DataGridView1.Columns(12).HeaderText = "از ماه"
                        DataGridView1.Columns(12).Width = 25
                        DataGridView1.Columns(13).HeaderText = "از روز"
                        DataGridView1.Columns(13).Width = 25
                        DataGridView1.Columns(14).HeaderText = "بدهی از سال گذشته"
                        DataGridView1.Columns(15).HeaderText = "نام روستا"
                        DataGridView1.Columns(16).HeaderText = "بخش"
                        DataGridView1.Columns(17).HeaderText = "شماره اشتراک"

                        DataGridView1.Columns(0).Visible = False
                        DataGridView1.Columns(16).Visible = False
                        For lp = 2 To 6 - ComboBox18.SelectedIndex
                            DataGridView1.Columns(lp).Visible = False
                        Next lp
                        For lp = 8 - ComboBox16.SelectedIndex To 7
                            DataGridView1.Columns(lp).Visible = False
                        Next lp
                        dt.Dispose()
                        oda.Dispose()
                        ocm.Dispose()
                        ocn.Dispose()
                    End If
                Else
                    If ComboBox7.Text = "" Or ComboBox12.Text = "" Or TextBox17.Text = "" Then
                        MsgBox("خطای فیلد های خالی", , "پیغام")
                    ElseIf ComboBox16.SelectedIndex > ComboBox18.SelectedIndex Then
                        MsgBox("خطای سال/دوره ورودی", , "پیغام")
                    Else
                        address = Form1.TextBox3.Text
                        Dim ocn As New System.Data.OleDb.OleDbConnection
                        Dim ocm As New System.Data.OleDb.OleDbCommand
                        Dim oda As New System.Data.OleDb.OleDbDataAdapter
                        Dim dt As New DataTable
                        ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + ""
                        ocm.Connection = ocn
                        ocm.CommandText = "SELECT * FROM GhabzA where (T = '" & TextBox17.Text & " ' and roosta = '" & ComboBox12.Text & "')"
                        oda.SelectCommand = ocm
                        oda.Fill(dt)
                        DataGridView1.DataSource = dt

                        DataGridView1.Columns(1).HeaderText = "توضیحات"
                        DataGridView1.Columns(2).HeaderText = "دوره 6"
                        DataGridView1.Columns(3).HeaderText = "دوره 5"
                        DataGridView1.Columns(4).HeaderText = "دوره 4"
                        DataGridView1.Columns(5).HeaderText = "دوره 3"
                        DataGridView1.Columns(6).HeaderText = "دوره 2"
                        DataGridView1.Columns(7).HeaderText = "دوره 1"
                        DataGridView1.Columns(8).HeaderText = "تا سال"
                        DataGridView1.Columns(8).Width = 64
                        DataGridView1.Columns(9).HeaderText = "تا ماه"
                        DataGridView1.Columns(9).Width = 25
                        DataGridView1.Columns(10).HeaderText = "تا روز"
                        DataGridView1.Columns(10).Width = 25
                        DataGridView1.Columns(11).HeaderText = "از سال"
                        DataGridView1.Columns(11).Width = 64
                        DataGridView1.Columns(12).HeaderText = "از ماه"
                        DataGridView1.Columns(12).Width = 25
                        DataGridView1.Columns(13).HeaderText = "از روز"
                        DataGridView1.Columns(13).Width = 25
                        DataGridView1.Columns(14).HeaderText = "بدهی از سال گذشته"
                        DataGridView1.Columns(15).HeaderText = "نام روستا"
                        DataGridView1.Columns(16).HeaderText = "بخش"
                        DataGridView1.Columns(17).HeaderText = "شماره اشتراک"

                        DataGridView1.Columns(0).Visible = False
                        DataGridView1.Columns(16).Visible = False
                        For lp = 2 To 6 - ComboBox18.SelectedIndex
                            DataGridView1.Columns(lp).Visible = False
                        Next lp
                        For lp = 8 - ComboBox16.SelectedIndex To 7
                            DataGridView1.Columns(lp).Visible = False
                        Next lp
                        dt.Dispose()
                        oda.Dispose()
                        ocm.Dispose()
                        ocn.Dispose()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
       
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            ComboBox7.Text = ""
            ComboBox12.Text = ""
            ComboBox7.Enabled = False
            ComboBox12.Enabled = False
        Else
            ComboBox7.Enabled = True
            ComboBox12.Enabled = True
        End If
    End Sub

    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click
        If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PrintDocument1.Print()
        End If

    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        DataGridView1.Width = 1400
        DataGridView1.Height = 800
        Dim b As New Bitmap(DataGridView1.Width, DataGridView1.Height)
        DataGridView1.DrawToBitmap(b, New Rectangle(0, 0, 1400, 800))
        e.Graphics.DrawImage(b, New Point(0, 0))
        DataGridView1.Width = 1152
        DataGridView1.Height = 182
    End Sub

    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click
        If PrintDialog2.ShowDialog = Windows.Forms.DialogResult.OK Then
            PrintDocument2.Print()
        End If

    End Sub

    Private Sub PrintDocument2_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument2.PrintPage
        DataGridView1.Width = 1400
        DataGridView1.Height = 800
        Dim b As New Bitmap(DataGridView1.Width, DataGridView1.Height)
        DataGridView1.DrawToBitmap(b, New Rectangle(0, 0, 1400, 800))
        e.Graphics.DrawImage(b, New Point(0, 0))
        DataGridView1.Width = 1152
        DataGridView1.Height = 182
    End Sub
End Class