Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.OleDb
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Text
Imports System.Windows.Forms
Imports CrystalDecisions.CrystalReports.Engine
Public Class Form5
#Region "Var"
    Public address As String
    Public i As Integer = 0
    Public n As Integer = 0
    Public BL As Boolean = False
    Public B As Boolean = False
    Public allow As Boolean = False
    Dim count As Integer = 0
    Public key As Boolean = True
    Public test As Boolean = True
    Public t As Boolean = True
    Private da As OleDbDataAdapter
    Private ds As New DataSet
    Dim rpt As New CrystalReport3
    Dim rpt1 As New CrystalReport9
#End Region
    Friend class2 As New class1
    Public Function Stext()
        TextBox12.Text = ""
        TextBox13.Text = ""
        TextBox14.Text = ""
        TextBox15.Text = ""
        TextBox16.Text = ""
        TextBox17.Text = ""
        TextBox18.Text = ""
        TextBox19.Text = ""
        TextBox20.Text = ""
        Return 0
    End Function
    Private Function SetupThePrinting() As Boolean
        Try
            Dim MyPrintDialog As PrintDialog = New PrintDialog()
            MyPrintDialog.AllowCurrentPage = False
            MyPrintDialog.AllowPrintToFile = False
            MyPrintDialog.AllowSelection = False
            MyPrintDialog.AllowSomePages = False
            MyPrintDialog.PrintToFile = False
            MyPrintDialog.ShowHelp = False
            MyPrintDialog.ShowNetwork = False

            If Not (MyPrintDialog.ShowDialog() = DialogResult.OK) Then
                Return False
            End If
            myprintdocument.DocumentName = "لوله گذاری"
            myprintdocument.PrinterSettings = MyPrintDialog.PrinterSettings
            myprintdocument.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings
            myprintdocument.DefaultPageSettings.Margins = New Margins(40, 40, 40, 40)


            class2.DataGridViewPrinter(DataGridView1, myprintdocument, True, True, "لوله گذاری", New Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, True)
            Return True
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
       
    End Function
    Public Function RRO()
        TextBox21.ReadOnly = False
        TextBox22.ReadOnly = False
        TextBox23.ReadOnly = False
        TextBox24.ReadOnly = False
        TextBox25.ReadOnly = False
        TextBox26.ReadOnly = False
        TextBox27.ReadOnly = False
        TextBox28.ReadOnly = False
        TextBox29.ReadOnly = False
        Return 0
    End Function
    Public Function SRO()
        TextBox21.ReadOnly = True
        TextBox22.ReadOnly = True
        TextBox23.ReadOnly = True
        TextBox24.ReadOnly = True
        TextBox25.ReadOnly = True
        TextBox26.ReadOnly = True
        TextBox27.ReadOnly = True
        TextBox28.ReadOnly = True
        TextBox29.ReadOnly = True
        Return 0
    End Function
    Dim shamsiDate As New Globalization.PersianCalendar
    Dim num As Integer = 1
    Public y As Integer
    Public x As Integer

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Try
            Dim ocm As New System.Data.OleDb.OleDbCommand
            Dim oda As New System.Data.OleDb.OleDbDataAdapter
            Dim ocn As New System.Data.OleDb.OleDbConnection
            If (ComboBox3.Text = "روز" Or ComboBox4.Text = "ماه" Or TextBox7.Text = "") Or ComboBox1.Text = "" Or ComboBox6.Text = "" Or ComboBox2.Text = "" Or TextBox10.Text = "" Then
                MsgBox("مشخصات فرم گزارش کامل نیست", , "پیغام")
            Else
                If count > 12 Then
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
                    ListBox7.Items.Add(TextBox1.Text)
                    ListBox8.Items.Add(TextBox2.Text)
                    ListBox9.Items.Add(TextBox3.Text)

                    address = Form1.TextBox3.Text
                    ocn.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + "")
                    ocm.Connection = ocn
                    ocm.CommandText = "INSERT INTO LooleGozari (address,SLA,tools,AD,SL,ML,NL,Y,M,D,roosta,bakhsh,eslah,tosea,NUM) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15)"
                    ocm.Parameters.Clear()
                    ocm.Parameters.AddWithValue("@p1", TextBox3.Text)
                    ocm.Parameters.AddWithValue("@p2", TextBox2.Text)
                    ocm.Parameters.AddWithValue("@p3", TextBox1.Text)
                    ocm.Parameters.AddWithValue("@p4", TextBox10.Text)
                    ocm.Parameters.AddWithValue("@p5", TextBox9.Text)
                    ocm.Parameters.AddWithValue("@p6", TextBox8.Text)
                    ocm.Parameters.AddWithValue("@p7", ComboBox6.Text)
                    ocm.Parameters.AddWithValue("@p8", TextBox7.Text)
                    ocm.Parameters.AddWithValue("@p9", ComboBox4.Text)
                    ocm.Parameters.AddWithValue("@p10", ComboBox3.Text)
                    ocm.Parameters.AddWithValue("@p11", ComboBox2.Text)
                    ocm.Parameters.AddWithValue("@p12", ComboBox1.Text)

                    If RadioButton1.Checked = True Then
                        ocm.Parameters.AddWithValue("@p13", "")
                        ocm.Parameters.AddWithValue("@p14", ComboBox7.Text)
                    Else
                        ocm.Parameters.AddWithValue("@p13", "اصلاح")
                        ocm.Parameters.AddWithValue("@p14", "")
                    End If
                    ocm.Parameters.AddWithValue("@p15", count)


                    ocn.Open()
                    ocm.ExecuteNonQuery()
                    ocn.Close()
                    ocm.Dispose()
                    ocn.Dispose()

                    TextBox1.Text = ""
                    TextBox2.Text = ""
                    TextBox3.Text = ""
                    TextBox4.Text = ""
                    TextBox5.Text = ""
                    TextBox6.Text = ""
                    TextBox7.Text = ""
                    TextBox8.Text = ""
                    TextBox9.Text = ""
                    TextBox10.Text = ""
                    ComboBox3.Text = "روز"
                    ComboBox4.Text = "ماه"
                    ComboBox6.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
        
    End Sub

    Private Sub Form5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        y = Me.Size.Height
        x = Me.Size.Width
        GroupBox4.Location = New System.Drawing.Point((x / 2), 5)
        GroupBox6.Location = New System.Drawing.Point(49, (y / 5))
        Button3.Location = New System.Drawing.Point(15, (y / 5) + 544)
        Button44.Location = New System.Drawing.Point(15, (y / 5))
        TextBox69.Text = ""
        TextBox68.Text = ""
        TextBox67.Text = ""
        TextBox66.Text = ""
        TextBox65.Text = ""
        TextBox64.Text = ""
        TextBox63.Text = ""
        TextBox62.Text = ""
        TextBox61.Text = ""
        TextBox45.Text = ""
        TextBox12.Text = ""
        TextBox13.Text = ""
        TextBox14.Text = ""
        TextBox15.Text = ""
        TextBox16.Text = ""
        TextBox17.Text = ""
        TextBox18.Text = ""
        TextBox19.Text = ""
        TextBox20.Text = ""
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            If allow Then
                Dim ocn As New System.Data.OleDb.OleDbConnection
                Dim ocm As New System.Data.OleDb.OleDbCommand
                Dim oda As New System.Data.OleDb.OleDbDataAdapter
                Dim ds As New DataSet()
                address = Form1.TextBox3.Text
                Button42_Click(sender, e)
                ocn.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + "")
                ocm.Connection = ocn
                ocm.CommandText = "update LooleGozari SET NUM=0"
                ocn.Open()
                ocm.ExecuteNonQuery()
                ocn.Close()
                ocm.Dispose()
                ocn.Dispose()
                Close()
            Else
                Dim ocn As New System.Data.OleDb.OleDbConnection
                Dim ocm As New System.Data.OleDb.OleDbCommand
                Dim oda As New System.Data.OleDb.OleDbDataAdapter
                Dim ds As New DataSet()
                address = Form1.TextBox3.Text
                Button42_Click(sender, e)
                ocn.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + "")
                ocm.Connection = ocn
                ocm.CommandText = "DELETE FROM LooleGozari WHERE NUM >'" & 0 & "'"
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

    Private Sub ComboBox1_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.DropDown
        test = True
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
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
                        TextBox5.Text = TextBox4.Text
                        TextBox4.DataBindings.Add(New Binding("Text", ds, "Roostaha.roosta"))
                        ComboBox2.Items.Add(TextBox4.Text)
                        Me.BindingContext(ds, "Roostaha").Position += 1
                        TextBox4.DataBindings.Clear()
                        If TextBox4.Text = TextBox5.Text Then
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
                        TextBox5.Text = TextBox4.Text
                        TextBox4.DataBindings.Add(New Binding("Text", ds, "Roostaha.roosta"))
                        ComboBox2.Items.Add(TextBox4.Text)
                        Me.BindingContext(ds, "Roostaha").Position += 1
                        TextBox4.DataBindings.Clear()
                        If TextBox4.Text = TextBox5.Text Then
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

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Try
            If Not GroupBox1.Visible And t Then
                Dim ocn As New System.Data.OleDb.OleDbConnection
                Dim ocm As New System.Data.OleDb.OleDbCommand
                Dim oda As New System.Data.OleDb.OleDbDataAdapter
                Dim ds As New DataSet()

                ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\Data.mdb"
                ocm.Connection = ocn
                ocm.CommandText = "SELECT * FROM Roostaha"
                oda.SelectCommand = ocm
                da = New OleDbDataAdapter(ocm.CommandText, ocn)
                da.Fill(ds, "Roostaha")

                Do
                    TextBox47.Text = TextBox46.Text
                    TextBox46.DataBindings.Add(New Binding("Text", ds, "Roostaha.roosta"))
                    ComboBox12.Items.Add(TextBox46.Text)
                    Me.BindingContext(ds, "Roostaha").Position += 1
                    TextBox46.DataBindings.Clear()
                    If TextBox46.Text = TextBox47.Text Then
                        Exit Do
                    End If
                Loop

                oda.Dispose()
                ocm.Dispose()
                ocn.Dispose()
                GroupBox1.Visible = True
                t = False
            ElseIf Not GroupBox1.Visible Then
                GroupBox1.Visible = True
            Else
                GroupBox1.Visible = False
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
        
    End Sub

    Private Sub Button45_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button45.Click
        If Not GroupBox2.Visible Then
            GroupBox2.Visible = True
        Else
            GroupBox2.Visible = False
        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        Try
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
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
       
    End Sub

    Private Sub Button42_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button42.Click
        Try
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
                TextBox5.Text = TextBox4.Text
                TextBox4.DataBindings.Add(New Binding("Text", ds, "Roostaha.roosta"))
                ComboBox2.Items.Add(TextBox4.Text)
                Me.BindingContext(ds, "Roostaha").Position += 1
                TextBox4.DataBindings.Clear()
                If TextBox4.Text = TextBox5.Text Then
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

    Private Sub Button43_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button43.Click
        n = 0
        key = False
        GroupBox5.Visible = True
        Button7.Enabled = False
        Button6.Enabled = False
        Button11.Enabled = False
        Button5.Enabled = False
        TextBox7.Text = ""
        Button41.Enabled = True
        Button40.Enabled = True
        Button39.Enabled = True
        Button38.Enabled = True
        Button37.Enabled = True
        Button36.Enabled = True
        Button35.Enabled = True
        Button34.Enabled = True
        Button33.Enabled = True
        Button31.Enabled = True
    End Sub
#Region "keyboard2"
    Private Sub Button29_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button29.Click
        Button6.Enabled = True
        Button11.Enabled = True
        Button5.Enabled = True
        TextBox7.Text = ""
        key = True
        GroupBox5.Visible = False
    End Sub
    Private Sub Button30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button30.Click
        TextBox7.Text = ""
        Button41.Enabled = True
        Button40.Enabled = True
        Button39.Enabled = True
        Button38.Enabled = True
        Button37.Enabled = True
        Button36.Enabled = True
        Button35.Enabled = True
        Button34.Enabled = True
        Button33.Enabled = True
        Button31.Enabled = True
        n = 0
    End Sub
    Private Sub Button31_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button31.Click
        TextBox7.Text += "0"
        n += 1
        If n > 3 Then
            Button41.Enabled = False
            Button40.Enabled = False
            Button39.Enabled = False
            Button38.Enabled = False
            Button37.Enabled = False
            Button36.Enabled = False
            Button35.Enabled = False
            Button34.Enabled = False
            Button33.Enabled = False
            Button31.Enabled = False
        End If
    End Sub
    Private Sub Button32_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button32.Click
        If n >= 4 Then
            Button7.Enabled = True
            Button6.Enabled = True
            Button11.Enabled = True
            Button5.Enabled = True
            key = True
            GroupBox5.Visible = False
        Else
            MsgBox("چهار رقم برای سال وروردی الزامیست", , "پیغام")
        End If
    End Sub
    Private Sub Button33_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button33.Click
        TextBox7.Text += "9"
        n += 1
        If n > 3 Then
            Button41.Enabled = False
            Button40.Enabled = False
            Button39.Enabled = False
            Button38.Enabled = False
            Button37.Enabled = False
            Button36.Enabled = False
            Button35.Enabled = False
            Button34.Enabled = False
            Button33.Enabled = False
            Button31.Enabled = False
        End If
    End Sub
    Private Sub Button34_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button34.Click
        TextBox7.Text += "8"
        n += 1
        If n > 3 Then
            Button41.Enabled = False
            Button40.Enabled = False
            Button39.Enabled = False
            Button38.Enabled = False
            Button37.Enabled = False
            Button36.Enabled = False
            Button35.Enabled = False
            Button34.Enabled = False
            Button33.Enabled = False
            Button31.Enabled = False
        End If
    End Sub
    Private Sub Button35_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button35.Click
        TextBox7.Text += "7"
        n += 1
        If n > 3 Then
            Button41.Enabled = False
            Button40.Enabled = False
            Button39.Enabled = False
            Button38.Enabled = False
            Button37.Enabled = False
            Button36.Enabled = False
            Button35.Enabled = False
            Button34.Enabled = False
            Button33.Enabled = False
            Button31.Enabled = False
        End If
    End Sub
    Private Sub Button36_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button36.Click
        TextBox7.Text += "6"
        n += 1
        If n > 3 Then
            Button41.Enabled = False
            Button40.Enabled = False
            Button39.Enabled = False
            Button38.Enabled = False
            Button37.Enabled = False
            Button36.Enabled = False
            Button35.Enabled = False
            Button34.Enabled = False
            Button33.Enabled = False
            Button31.Enabled = False
        End If
    End Sub
    Private Sub Button37_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button37.Click
        TextBox7.Text += "5"
        n += 1
        If n > 3 Then
            Button41.Enabled = False
            Button40.Enabled = False
            Button39.Enabled = False
            Button38.Enabled = False
            Button37.Enabled = False
            Button36.Enabled = False
            Button35.Enabled = False
            Button34.Enabled = False
            Button33.Enabled = False
            Button31.Enabled = False
        End If
    End Sub
    Private Sub Button38_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button38.Click
        TextBox7.Text += "4"
        n += 1
        If n > 3 Then
            Button41.Enabled = False
            Button40.Enabled = False
            Button39.Enabled = False
            Button38.Enabled = False
            Button37.Enabled = False
            Button36.Enabled = False
            Button35.Enabled = False
            Button34.Enabled = False
            Button33.Enabled = False
            Button31.Enabled = False
        End If
    End Sub
    Private Sub Button39_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button39.Click
        TextBox7.Text += "3"
        n += 1
        If n > 3 Then
            Button41.Enabled = False
            Button40.Enabled = False
            Button39.Enabled = False
            Button38.Enabled = False
            Button37.Enabled = False
            Button36.Enabled = False
            Button35.Enabled = False
            Button34.Enabled = False
            Button33.Enabled = False
            Button31.Enabled = False
        End If
    End Sub
    Private Sub Button40_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button40.Click
        TextBox7.Text += "2"
        n += 1
        If n > 3 Then
            Button41.Enabled = False
            Button40.Enabled = False
            Button39.Enabled = False
            Button38.Enabled = False
            Button37.Enabled = False
            Button36.Enabled = False
            Button35.Enabled = False
            Button34.Enabled = False
            Button33.Enabled = False
            Button31.Enabled = False
        End If
    End Sub
    Private Sub Button41_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button41.Click
        TextBox7.Text += "1"
        n += 1
        If n > 3 Then
            Button41.Enabled = False
            Button40.Enabled = False
            Button39.Enabled = False
            Button38.Enabled = False
            Button37.Enabled = False
            Button36.Enabled = False
            Button35.Enabled = False
            Button34.Enabled = False
            Button33.Enabled = False
            Button31.Enabled = False
        End If
    End Sub
    Private Sub TextBox7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox7.Click
        If key = True Then
            TextBox7.Text = ""
        End If
    End Sub
    Private Sub TextBox7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox7.KeyPress
        If Not key = True Then
            e.Handled = True
        End If
    End Sub
#End Region

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

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Try
            If count = 0 Then
                MsgBox("گزارشی ثبت نشده است", , "پیغام")
            Else
                allow = True
                Dim r As Integer = 0
                CrystalReportViewer1.Size = New System.Drawing.Size(x, y)
                CrystalReportViewer1.Location = New System.Drawing.Point(1, 1)
                Button13.Location = New System.Drawing.Point(x - 112, 5)

                For i = 0 To count - 1
                    r = i
                    TextBox45.Text += Convert.ToString(r + 1) & vbCrLf
                    TextBox12.Text += ListBox1.Items.Item(i) & vbCrLf
                    TextBox13.Text += ListBox2.Items.Item(i) & vbCrLf
                    TextBox14.Text += ListBox3.Items.Item(i) & vbCrLf
                    TextBox15.Text += ListBox4.Items.Item(i) & vbCrLf
                    TextBox16.Text += ListBox5.Items.Item(i) & vbCrLf
                    TextBox17.Text += ListBox6.Items.Item(i) & vbCrLf
                    TextBox18.Text += ListBox7.Items.Item(i) & vbCrLf
                    TextBox19.Text += ListBox8.Items.Item(i) & vbCrLf
                    TextBox20.Text += ListBox9.Items.Item(i) & vbCrLf
                Next i
                rpt.SetParameterValue("A1", TextBox45.Text)
                rpt.SetParameterValue("A2", TextBox13.Text)
                rpt.SetParameterValue("A3", TextBox12.Text)
                rpt.SetParameterValue("A4", TextBox14.Text)
                rpt.SetParameterValue("A5", TextBox15.Text)
                rpt.SetParameterValue("A6", TextBox16.Text)
                rpt.SetParameterValue("A7", TextBox17.Text)
                rpt.SetParameterValue("A8", TextBox18.Text)
                rpt.SetParameterValue("A9", TextBox19.Text)
                rpt.SetParameterValue("A10", TextBox20.Text)


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

    Private Sub Button44_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button44.Click
        If Not GroupBox6.Visible Then
            GroupBox6.Visible = True
        Else
            GroupBox6.Visible = False
        End If
    End Sub

    Private Sub Button28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button28.Click
        Try
            Label10.Visible = False
            If ComboBox5.SelectedItem = "" Then
                MsgBox("نام روستا را وارد کنید", , "پیغام")
            Else
                address = Form1.TextBox3.Text
                Dim ocn As New System.Data.OleDb.OleDbConnection
                Dim ocm As New System.Data.OleDb.OleDbCommand
                Dim oda As New System.Data.OleDb.OleDbDataAdapter
                Dim dt As New DataTable

                ocn.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + "")
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
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
        
    End Sub

    Private Sub Button17_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button17.Click
        Button28.Visible = True
        Button17.Visible = False
        Button1.Enabled = False
        Button1.Visible = False
        TextBox11.Enabled = True
        ComboBox5.Enabled = True
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            address = Form1.TextBox3.Text
            Dim ocn As New System.Data.OleDb.OleDbConnection
            Dim ocm As New System.Data.OleDb.OleDbCommand
            Dim oda As New System.Data.OleDb.OleDbDataAdapter
            Dim ds As New DataSet()

            ocn.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + "")
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
            ListBox7.SelectedIndex = list
            ListBox8.SelectedIndex = list
            ListBox9.SelectedIndex = list
            ListBox1.Items.Remove(ListBox1.SelectedItem)
            ListBox2.Items.Remove(ListBox2.SelectedItem)
            ListBox3.Items.Remove(ListBox3.SelectedItem)
            ListBox4.Items.Remove(ListBox4.SelectedItem)
            ListBox5.Items.Remove(ListBox5.SelectedItem)
            ListBox6.Items.Remove(ListBox6.SelectedItem)
            ListBox7.Items.Remove(ListBox7.SelectedItem)
            ListBox8.Items.Remove(ListBox8.SelectedItem)
            ListBox9.Items.Remove(ListBox9.SelectedItem)
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
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
        
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try
            If allow Then
                Dim ocn As New System.Data.OleDb.OleDbConnection
                Dim ocm As New System.Data.OleDb.OleDbCommand
                Dim oda As New System.Data.OleDb.OleDbDataAdapter
                Dim ds As New DataSet()
                address = Form1.TextBox3.Text
                Button42_Click(sender, e)
                ocn.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + "")
                ocm.Connection = ocn
                ocm.CommandText = "update LooleGozari SET NUM=0"
                ocn.Open()
                ocm.ExecuteNonQuery()
                ocn.Close()
                ocm.Dispose()
                ocn.Dispose()
                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox4.Text = ""
                TextBox8.Text = ""
                TextBox9.Text = ""
                TextBox10.Text = ""
                ListBox1.Items.Clear()
                ListBox2.Items.Clear()
                ListBox3.Items.Clear()
                ListBox4.Items.Clear()
                ListBox5.Items.Clear()
                ListBox6.Items.Clear()
                ListBox7.Items.Clear()
                ListBox8.Items.Clear()
                ListBox9.Items.Clear()
                ComboBox3.Text = "روز"
                ComboBox4.Text = "ماه"
                count = 0
                t = True
                allow = False

            Else
                Dim ocn As New System.Data.OleDb.OleDbConnection
                Dim ocm As New System.Data.OleDb.OleDbCommand
                Dim oda As New System.Data.OleDb.OleDbDataAdapter
                Dim ds As New DataSet()
                address = Form1.TextBox3.Text
                Button42_Click(sender, e)
                ocn.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + "")
                ocm.Connection = ocn
                ocm.CommandText = "DELETE FROM LooleGozari WHERE NUM >'" & 0 & "'"
                ocn.Open()
                ocm.ExecuteNonQuery()
                ocn.Close()
                ocm.Dispose()
                ocn.Dispose()
                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox4.Text = ""
                TextBox8.Text = ""
                TextBox9.Text = ""
                TextBox10.Text = ""
                ListBox1.Items.Clear()
                ListBox2.Items.Clear()
                ListBox3.Items.Clear()
                ListBox4.Items.Clear()
                ListBox5.Items.Clear()
                ListBox6.Items.Clear()
                ListBox7.Items.Clear()
                ListBox8.Items.Clear()
                ListBox9.Items.Clear()
                ComboBox3.Text = "روز"
                ComboBox4.Text = "ماه"
                count = 0
                t = True
                allow = False
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
       
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        TextBox10.Text = ""
        ComboBox3.Text = "روز"
        ComboBox4.Text = "ماه"
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        TextBox20.DataBindings.Clear()
        TextBox19.DataBindings.Clear()
        TextBox18.DataBindings.Clear()
        TextBox17.DataBindings.Clear()
        TextBox16.DataBindings.Clear()
        TextBox15.DataBindings.Clear()
        TextBox14.DataBindings.Clear()
        TextBox13.DataBindings.Clear()
        TextBox12.DataBindings.Clear()
        TextBox58.DataBindings.Clear()
        TextBox59.DataBindings.Clear()
        TextBox45.Text = ""
        TextBox12.Text = ""
        TextBox13.Text = ""
        TextBox14.Text = ""
        TextBox15.Text = ""
        TextBox16.Text = ""
        TextBox17.Text = ""
        TextBox18.Text = ""
        TextBox19.Text = ""
        TextBox20.Text = ""
        CrystalReportViewer1.ReportSource = rpt
        CrystalReportViewer1.Visible = False
        Button13.Visible = False
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click

        Try
            Dim pc As Integer = 0

            If ComboBox8.Text = "روز" Or ComboBox9.Text = "ماه" Or TextBox6.Text = "سال" Or TextBox6.Text = "" Or ComboBox11.Text = "روز" Or ComboBox10.Text = "ماه" Or TextBox33.Text = "سال" Or TextBox33.Text = "" Or ComboBox13.Text = "" Then
                MsgBox("فیلد ها را تکمیل کنید", , "پیغام")
            ElseIf ((Convert.ToInt32(ComboBox9.Text)) > (Convert.ToInt32(ComboBox10.Text)) And (Convert.ToInt32(TextBox6.Text)) >= (Convert.ToInt32(TextBox33.Text))) Or ((Convert.ToInt32(ComboBox9.Text)) = (Convert.ToInt32(ComboBox10.Text)) And (Convert.ToInt32(TextBox6.Text)) = (Convert.ToInt32(TextBox33.Text)) And (Convert.ToInt32(ComboBox8.Text)) > (Convert.ToInt32(ComboBox11.Text))) Then
                MsgBox("خطا در تاریخ ورودی", , "پیغام")
            Else

                address = Form1.TextBox3.Text
                Dim con As New System.Data.OleDb.OleDbConnection
                Dim strSql As String
                Dim strCon As String = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + "")
                If ComboBox13.Text = "نام روستا" Then

                    Dim ocm As New System.Data.OleDb.OleDbCommand
                    Dim oda As New System.Data.OleDb.OleDbDataAdapter

                    strSql = "SELECT * FROM LooleGozari where (roosta = '" & ComboBox12.SelectedItem & "' AND ((((Y + M + D) >='" & TextBox6.Text + ComboBox9.Text + ComboBox8.Text & "') AND ((Y + M + D) <='" & TextBox33.Text + ComboBox10.Text + ComboBox11.Text & "'))))"
                    con = New OleDb.OleDbConnection(strCon)
                    con.Open()
                    da = New OleDb.OleDbDataAdapter(strSql, con)
                    If da.Fill(ds, "LooleGozari") Then

                        CrystalReportViewer1.Size = New System.Drawing.Size(x, y)
                        CrystalReportViewer1.Location = New System.Drawing.Point(1, 1)
                        Button13.Location = New System.Drawing.Point(x - 115, 5)

                        Stext()

                        TextBox20.DataBindings.Add(New Binding("Text", ds, "LooleGozari.address"))
                        TextBox19.DataBindings.Add(New Binding("Text", ds, "LooleGozari.SLA"))
                        TextBox18.DataBindings.Add(New Binding("Text", ds, "LooleGozari.tools"))
                        TextBox17.DataBindings.Add(New Binding("Text", ds, "LooleGozari.AD"))
                        TextBox16.DataBindings.Add(New Binding("Text", ds, "LooleGozari.SL"))
                        TextBox15.DataBindings.Add(New Binding("Text", ds, "LooleGozari.ML"))
                        TextBox14.DataBindings.Add(New Binding("Text", ds, "LooleGozari.Y"))
                        TextBox13.DataBindings.Add(New Binding("Text", ds, "LooleGozari.M"))
                        TextBox12.DataBindings.Add(New Binding("Text", ds, "LooleGozari.D"))
                        TextBox58.DataBindings.Add(New Binding("Text", ds, "LooleGozari.eslah"))
                        TextBox59.DataBindings.Add(New Binding("Text", ds, "LooleGozari.tosea"))

                        Do
                            TextBox70.Text = TextBox20.Text
                            TextBox71.Text = TextBox18.Text
                            TextBox72.Text = TextBox17.Text
                            TextBox69.Text += TextBox59.Text & vbCrLf
                            TextBox68.Text += TextBox58.Text & vbCrLf
                            TextBox67.Text += TextBox14.Text + "/" + TextBox13.Text + "/" + TextBox12.Text & vbCrLf
                            TextBox66.Text += TextBox15.Text & vbCrLf
                            TextBox65.Text += TextBox16.Text & vbCrLf
                            TextBox64.Text += TextBox17.Text & vbCrLf
                            TextBox63.Text += TextBox18.Text & vbCrLf
                            TextBox62.Text += TextBox19.Text & vbCrLf
                            TextBox61.Text += TextBox20.Text & vbCrLf
                            pc += 1
                            Me.BindingContext(ds, "LooleGozari").Position += 1
                            If TextBox70.Text = TextBox20.Text And TextBox71.Text = TextBox18.Text And TextBox72.Text = TextBox17.Text Then
                                Exit Do
                            End If
                        Loop

                        rpt1.SetParameterValue("R1", ComboBox12.SelectedItem)
                        rpt1.SetParameterValue("R2", TextBox34.Text)
                        rpt1.SetParameterValue("R3", (TextBox6.Text + "/" + ComboBox9.SelectedItem + "/" + ComboBox8.SelectedItem))
                        rpt1.SetParameterValue("R4", (TextBox33.Text + "/" + ComboBox10.SelectedItem + "/" + ComboBox11.SelectedItem))
                        rpt1.SetParameterValue("R5", Convert.ToString(pc))
                        rpt1.SetParameterValue("B1", TextBox69.Text)
                        rpt1.SetParameterValue("B2", TextBox68.Text)
                        rpt1.SetParameterValue("B3", TextBox67.Text)
                        rpt1.SetParameterValue("B4", TextBox66.Text)
                        rpt1.SetParameterValue("B5", TextBox65.Text)
                        rpt1.SetParameterValue("B6", TextBox64.Text)
                        rpt1.SetParameterValue("B7", TextBox63.Text)
                        rpt1.SetParameterValue("B8", TextBox62.Text)
                        rpt1.SetParameterValue("B9", TextBox61.Text)
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
                ElseIf ComboBox13.Text = "نام بخش" Then
                    Dim ocn As New System.Data.OleDb.OleDbConnection
                    Dim ocm As New System.Data.OleDb.OleDbCommand
                    Dim oda As New System.Data.OleDb.OleDbDataAdapter
                    Dim dt As New DataTable

                    ocn.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + "")
                    ocm.Connection = ocn
                    If ComboBox14.Text = "کل روستاها" Then
                        ocm.CommandText = "SELECT * FROM Loolegozari"
                    Else
                        ocm.CommandText = "SELECT * FROM LooleGozari where (Bakhsh Like'%" & ComboBox14.Text & "%' AND ((((Y + M + D) >='" & TextBox6.Text + ComboBox9.Text + ComboBox8.Text & "') AND ((Y + M + D) <='" & TextBox33.Text + ComboBox10.Text + ComboBox11.Text & "'))))"
                    End If

                    oda.SelectCommand = ocm
                    oda.Fill(dt)

                    GroupBox7.Visible = True
                    DataGridView1.Visible = True
                    DataGridView1.Size = New Size(Me.Size.Width, Me.Height - 100)


                    Button4.Location = New Point(15, Me.Height - 65)
                    Button10.Location = New Point(180, Me.Height - 65)
                    Button10.Visible = True
                    Button4.Visible = True

                    GroupBox7.Location = New Point(10, 5)
                    GroupBox7.Size = New Size(Me.Size.Width - 30, Me.Height - 10)

                    DataGridView1.DataSource = dt

                    GroupBox7.BringToFront()
                    DataGridView1.BringToFront()

                    DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True

                    DataGridView1.Columns(0).HeaderText = "آدرس"
                    DataGridView1.Columns(1).HeaderText = "سایز لوله اصلی"
                    DataGridView1.Columns(2).HeaderText = "وسایل بکار بده شده"
                    DataGridView1.Columns(3).HeaderText = "انجام دهنده"
                    DataGridView1.Columns(4).HeaderText = "سایز لوله"
                    DataGridView1.Columns(5).HeaderText = "متراژ لوله"
                    DataGridView1.Columns(6).HeaderText = "نوع لوله"
                    DataGridView1.Columns(7).HeaderText = "سال"
                    DataGridView1.Columns(8).HeaderText = "ماه"
                    DataGridView1.Columns(9).HeaderText = "روز"
                    DataGridView1.Columns(10).HeaderText = "روستا"
                    DataGridView1.Columns(11).HeaderText = "بخش"
                    DataGridView1.Columns(12).HeaderText = "اصلاح و بازسازی شبکه بهره برداری"
                    DataGridView1.Columns(13).HeaderText = "میزان توسعه شبکه توزیع و انتقال"
                    DataGridView1.Columns(14).HeaderText = "ردیف"
                    DataGridView1.Columns(14).Visible = False


                ElseIf ComboBox13.Text = "سایز لوله" Then

                    Dim ocn As New System.Data.OleDb.OleDbConnection
                    Dim ocm As New System.Data.OleDb.OleDbCommand
                    Dim oda As New System.Data.OleDb.OleDbDataAdapter
                    Dim dt As New DataTable

                    ocn.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + "")
                    ocm.Connection = ocn

                    ocm.CommandText = "SELECT * FROM LooleGozari where (SL = '" & TextBox73.Text & "' AND ((((Y + M + D) >='" & TextBox6.Text + ComboBox9.Text + ComboBox8.Text & "') AND ((Y + M + D) <='" & TextBox33.Text + ComboBox10.Text + ComboBox11.Text & "'))))"


                    oda.SelectCommand = ocm
                    oda.Fill(dt)

                    GroupBox7.Visible = True
                    DataGridView1.Visible = True
                    DataGridView1.Size = New Size(Me.Size.Width, Me.Height - 100)


                    Button4.Location = New Point(15, Me.Height - 65)
                    Button10.Location = New Point(180, Me.Height - 65)
                    Button10.Visible = True
                    Button4.Visible = True

                    GroupBox7.Location = New Point(10, 5)
                    GroupBox7.Size = New Size(Me.Size.Width - 30, Me.Height - 10)

                    DataGridView1.DataSource = dt

                    GroupBox7.BringToFront()
                    DataGridView1.BringToFront()

                    DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True

                    DataGridView1.Columns(0).HeaderText = "آدرس"
                    DataGridView1.Columns(1).HeaderText = "سایز لوله اصلی"
                    DataGridView1.Columns(2).HeaderText = "وسایل بکار بده شده"
                    DataGridView1.Columns(3).HeaderText = "انجام دهنده"
                    DataGridView1.Columns(4).HeaderText = "سایز لوله"
                    DataGridView1.Columns(5).HeaderText = "متراژ لوله"
                    DataGridView1.Columns(6).HeaderText = "نوع لوله"
                    DataGridView1.Columns(7).HeaderText = "سال"
                    DataGridView1.Columns(8).HeaderText = "ماه"
                    DataGridView1.Columns(9).HeaderText = "روز"
                    DataGridView1.Columns(10).HeaderText = "روستا"
                    DataGridView1.Columns(11).HeaderText = "بخش"
                    DataGridView1.Columns(12).HeaderText = "اصلاح و بازسازی شبکه بهره برداری"
                    DataGridView1.Columns(13).HeaderText = "میزان توسعه شبکه توزیع و انتقال"
                    DataGridView1.Columns(14).HeaderText = "ردیف"
                    DataGridView1.Columns(14).Visible = False


                End If


            End If
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
       
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Not GroupBox3.Visible Then
            GroupBox3.Visible = True
        Else
            GroupBox3.Visible = False
        End If
    End Sub

    Private Sub ComboBox12_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox12.SelectedIndexChanged
        Try
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
            Button9.Enabled = True
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

    Private Sub TextBox6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox6.Click
        TextBox6.Text = ""
    End Sub

    Private Sub TextBox33_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox33.Click
        TextBox33.Text = ""
    End Sub
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

    Private Sub ComboBox6_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox6.DropDown
        Try
            Dim ocn As New System.Data.OleDb.OleDbConnection
            Dim ocm As New System.Data.OleDb.OleDbCommand
            Dim oda As New System.Data.OleDb.OleDbDataAdapter
            Dim ds As New DataSet()

            address = Form1.TextBox3.Text
            TextBox4.Text = ""
            TextBox5.Text = ""
            If Not B Then
                ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
         "atabase Password=" + Form14.TextBox10.Text + ""
                ocm.Connection = ocn
                ocm.CommandText = "SELECT * FROM Noeloole"
                oda.SelectCommand = ocm
                da = New OleDbDataAdapter(ocm.CommandText, ocn)
                da.Fill(ds, "NOeloole")

                Do
                    TextBox5.Text = TextBox4.Text
                    TextBox4.DataBindings.Add(New Binding("Text", ds, "Noeloole.Name"))
                    TextBox4.DataBindings.Clear()
                    If TextBox4.Text = TextBox5.Text Then
                        Exit Do
                    End If
                    ComboBox6.Items.Add(TextBox4.Text)
                    Me.BindingContext(ds, "Noeloole").Position += 1

                Loop
                B = True
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
        
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        ComboBox7.Visible = True
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        ComboBox7.Visible = False
    End Sub


    Private Sub Label28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label28.Click

    End Sub

    Private Sub ComboBox13_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox13.SelectedIndexChanged
        Button9.Enabled = False
        ComboBox12.Text = ""
        TextBox34.Text = ""
        ComboBox14.Text = ""
        TextBox73.Text = ""
        If ComboBox13.Text = "نام روستا" Then
            ComboBox12.Visible = True
            TextBox34.Visible = True
            Label12.Visible = True
            Label13.Visible = True
            ComboBox14.Visible = False
            Label27.Visible = False
            TextBox73.Visible = False
            Label28.Visible = False
        ElseIf ComboBox13.Text = "نام بخش" Then
            ComboBox14.Visible = True
            Label27.Visible = True
            TextBox73.Visible = False
            Label28.Visible = False
            ComboBox12.Visible = False
            TextBox34.Visible = False
            Label12.Visible = False
            Label13.Visible = False
        ElseIf ComboBox13.Text = "سایز لوله" Then
            TextBox73.Visible = True
            Label28.Visible = True
            ComboBox12.Visible = False
            TextBox34.Visible = False
            Label12.Visible = False
            Label13.Visible = False
            ComboBox14.Visible = False
            Label27.Visible = False
        End If
    End Sub

    Private Sub ComboBox14_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox14.SelectedIndexChanged
        Button9.Enabled = True
    End Sub



    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        GroupBox7.Visible = False
        GroupBox7.SendToBack()
        ComboBox14.Text = ""
        TextBox73.Text = ""
        ComboBox12.Text = ""
        TextBox34.Text = ""
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        If (SetupThePrinting()) Then

            Dim MyPrintPreviewDialog As PrintPreviewDialog = New PrintPreviewDialog()
            MyPrintPreviewDialog.Document = MyPrintDocument
            MyPrintPreviewDialog.ShowDialog()
        End If
    End Sub

    Private Sub TextBox73_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox73.TextChanged
        Button9.Enabled = True
    End Sub

    Private Sub MyPrintDocument_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles MyPrintDocument.PrintPage
        Dim more As Boolean = class2.DrawDataGridView(e.Graphics)
        If (more = True) Then
            e.HasMorePages = True
        End If
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        If (Not GroupBox8.Visible) Then

            If Form1.Label1.Text = "مدیریت" Then
                GroupBox8.Visible = True
            Else

                MsgBox("عدم امکان دسترسی به این بخش توسط کارمندان", , "پیغام")
            End If

        Else

            GroupBox8.Visible = False
        End If

    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        Try
            If TextBox74.Text = "" Then
                MsgBox("نوع لوله را وارد نمایید", , "")
            Else
                Dim ocm As New System.Data.OleDb.OleDbCommand
                Dim ocn As New System.Data.OleDb.OleDbConnection
                Dim oda As New System.Data.OleDb.OleDbDataAdapter
                address = Form1.TextBox3.Text
                ocn.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                    "atabase Password=" + Form14.TextBox10.Text + "")
                ocm.Connection = ocn
                ocm.CommandText = "INSERT INTO Noeloole (Name)VALUES(@p1)"
                ocm.Parameters.Clear()
                ocm.Parameters.AddWithValue("@p1", TextBox74.Text)
                ocn.Open()
                ocm.ExecuteNonQuery()
                ocn.Close()
                ocm.Dispose()
                ocn.Dispose()
                MsgBox("مشخصات با موفقیت ثبت شد", , "پیغام")
                TextBox74.Text = ""
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
        
    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        form24.show()
        Me.Close()
    End Sub
End Class