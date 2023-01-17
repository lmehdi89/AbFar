Imports System.Data.OleDb
Imports System.Data
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Text
Imports System.Windows.Forms
Imports CrystalDecisions.CrystalReports.Engine

Public Class Form3


#Region "var"
    Dim ocn1 As New System.Data.OleDb.OleDbConnection
    Dim ocm1 As New System.Data.OleDb.OleDbCommand
    Dim dt1 As New DataTable
    Dim oda1 As New OleDbDataAdapter
    Friend class2 As New class1
    Public address As String
    Public y As Integer
    Public x As Integer
    Public n As Integer = 0
    Public t As Boolean = True
    Public f As Boolean = True
    Public key As Boolean = True
    Public test As Boolean = True
    Public BL As Boolean = False
    Private da As OleDbDataAdapter
    Private ds As New DataSet
    Dim LP As Integer = 0
    Dim i As Integer
    Dim rpt As New CrystalReport2
    Dim rpt1 As New CrystalReport6
    Dim b As Boolean = False
    Public Shared stri As String

#End Region

    Public Function Stext()
        TextBox31.Text = ""
        TextBox37.Text = ""
        TextBox40.Text = ""
        TextBox41.Text = ""
        TextBox42.Text = ""
        TextBox43.Text = ""
        TextBox44.Text = ""
        TextBox45.Text = ""
        TextBox46.Text = ""
        TextBox47.Text = ""
        TextBox48.Text = ""
        TextBox49.Text = ""
        TextBox50.Text = ""
        TextBox57.Text = ""
        Return 0
    End Function

    Private Function SetupThePrinting() As Boolean

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
        MyPrintDocument.DocumentName = "شکستگی های " + TextBox62.Text
        MyPrintDocument.PrinterSettings = MyPrintDialog.PrinterSettings
        MyPrintDocument.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings
        MyPrintDocument.DefaultPageSettings.Margins = New Margins(40, 40, 40, 40)


        class2.DataGridViewPrinter(DataGridView1, MyPrintDocument, True, True, "شکستگی های " + TextBox62.Text, New Font("Tahoma", 10, FontStyle.Bold, GraphicsUnit.Point), Color.Black, True)
        Return True
    End Function

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
        TextBox28.Text = m
        TextBox29.Text = y
        Return 0
    End Function
    Dim shamsiDate As New Globalization.PersianCalendar
    Dim count As Integer = 0
    Dim NUM As Integer = 0
    Dim DEL As Boolean = True
    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        stext()

        y = Me.Size.Height
        x = Me.Size.Width

        Call Toshamsi()

        GroupBox5.Location = New System.Drawing.Point((x / 2), (y / 20))
        GroupBox3.Location = New System.Drawing.Point(25, y / 20)
        Button3.Location = New System.Drawing.Point((x / 2), (y / 20) + 705)
        Button48.Location = New System.Drawing.Point(25, (y / 20) - 10)

        TextBox4.Text = "سال"
        TextBox2.Text = TextBox29.Text + "/" + TextBox28.Text + "/" + TextBox1.Text

        address = Form1.TextBox3.Text
        Dim ocn As New System.Data.OleDb.OleDbConnection
        Dim ocm As New System.Data.OleDb.OleDbCommand
        Dim oda As New System.Data.OleDb.OleDbDataAdapter
        Dim ds As New DataSet()

        ocn.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
    "atabase Password=" + Form14.TextBox10.Text + "")
        ocm.Connection = ocn
        ocm.CommandText = "update Shekastegi SET NUM=0"
        ocn.Open()
        ocm.ExecuteNonQuery()
        ocn.Close()
        ocm.Dispose()
        ocn.Dispose()

    End Sub
    Private Sub TextBox4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox4.Click
        TextBox4.Text = ""
        TextBox4.TextAlign = HorizontalAlignment.Left
        TextBox4.Font = New System.Drawing.Font("B Nazanin", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        TextBox4.ForeColor = Color.Black
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        If Not LP = 0 Then
            Dim result As Integer = MsgBox("آيا گزارش جاری را ذخیره می کنید؟", MsgBoxStyle.YesNoCancel)
            If result = MsgBoxResult.Yes Then
                address = Form1.TextBox3.Text
                Dim ocn As New System.Data.OleDb.OleDbConnection
                Dim ocm As New System.Data.OleDb.OleDbCommand
                Dim oda As New System.Data.OleDb.OleDbDataAdapter
                Dim ds As New DataSet()

                ocn.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
            "atabase Password=" + Form14.TextBox10.Text + "")
                ocm.Connection = ocn
                ocm.CommandText = "update Shekastegi SET NUM=0"
                ocn.Open()
                ocm.ExecuteNonQuery()
                ocn.Close()
                ocm.Dispose()
                ocn.Dispose()
                Form1.Show()
                Close()

            ElseIf result = MsgBoxResult.No Then
                address = Form1.TextBox3.Text
                Dim ocn As New System.Data.OleDb.OleDbConnection
                Dim ocm As New System.Data.OleDb.OleDbCommand
                Dim oda As New System.Data.OleDb.OleDbDataAdapter
                Dim ds As New DataSet()

                Button42_Click(sender, e)
                TextBox3.ReadOnly = False
                ocn.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
            "atabase Password=" + Form14.TextBox10.Text + "")
                ocm.Connection = ocn
                ocm.CommandText = "DELETE FROM Shekastegi WHERE NUM >'" & 0 & "'"
                ocn.Open()
                ocm.ExecuteNonQuery()
                ocn.Close()
                ocm.Dispose()
                ocn.Dispose()
                Form1.Show()
                Close()
            End If
        Else
            Form1.Show()
            Close()
        End If
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If LP = 0 Then
            MsgBox("گزارشی ثبت نشده است", , "پیغام")
        Else

            CrystalReportViewer1.Size = New System.Drawing.Size(x, y)
            CrystalReportViewer1.Location = New System.Drawing.Point(1, 1)
            Button13.Location = New System.Drawing.Point(x - 115, 5)

            Stext()
            address = Form1.TextBox3.Text
            Dim strSql As String
            Dim strCon As String = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
            "atabase Password=" + Form14.TextBox10.Text + "")
            Dim con As OleDb.OleDbConnection
            strSql = "SELECT * FROM Shekastegi where NUM >'" & 0 & "'"
            con = New OleDb.OleDbConnection(strCon)
            con.Open()
            da = New OleDb.OleDbDataAdapter(strSql, con)
            da.Fill(ds, "Shekastegi")
            TextBox45.DataBindings.Add(New Binding("Text", ds, "Shekastegi.roosta"))
            TextBox46.DataBindings.Add(New Binding("Text", ds, "Shekastegi.address"))
            TextBox47.DataBindings.Add(New Binding("Text", ds, "Shekastegi.SL"))
            TextBox48.DataBindings.Add(New Binding("Text", ds, "Shekastegi.NL"))
            TextBox49.DataBindings.Add(New Binding("Text", ds, "Shekastegi.tedad"))
            TextBox50.DataBindings.Add(New Binding("Text", ds, "Shekastegi.reporter"))

            For i = 1 To LP

                TextBox31.Text = TextBox45.Text
                TextBox53.Text += TextBox31.Text + "،"
                TextBox37.Text += TextBox45.Text & vbCrLf & vbCrLf
                TextBox40.Text += TextBox46.Text & vbCrLf & vbCrLf
                TextBox41.Text += TextBox47.Text & vbCrLf & vbCrLf
                TextBox42.Text += TextBox48.Text & vbCrLf & vbCrLf
                TextBox43.Text += TextBox49.Text & vbCrLf & vbCrLf
                TextBox44.Text += TextBox50.Text & vbCrLf & vbCrLf
                Me.BindingContext(ds, "Shekastegi").Position += 1

            Next i

            rpt.SetParameterValue("P2", TextBox2.Text)
            rpt.SetParameterValue("P3", TextBox3.Text)
            rpt.SetParameterValue("P6", TextBox3.Text)
            rpt.SetParameterValue("P11", TextBox5.Text)
            Label4.Text = Convert.ToString(NUM)
            rpt.SetParameterValue("P4", Label4.Text)
            rpt.SetParameterValue("P5", TextBox53.Text)
            rpt.SetParameterValue("P7", TextBox15.Text)
            rpt.SetParameterValue("P8", TextBox16.Text)
            rpt.SetParameterValue("P9", TextBox13.Text)
            rpt.SetParameterValue("P10", TextBox14.Text)
            rpt.SetParameterValue("A1", TextBox37.Text)
            rpt.SetParameterValue("A2", TextBox40.Text)
            rpt.SetParameterValue("A3", TextBox41.Text)
            rpt.SetParameterValue("A4", TextBox42.Text)
            rpt.SetParameterValue("A5", TextBox43.Text)
            rpt.SetParameterValue("A6", TextBox44.Text)
            CrystalReportViewer1.ReportSource = rpt


            CrystalReportViewer1.Visible = True
            CrystalReportViewer1.BringToFront()
            Button13.Visible = True
            Button13.BringToFront()
        End If
    End Sub
    Private Sub Button13_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button13.Click

    End Sub
    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        address = Form1.TextBox3.Text
        Dim ocm As New System.Data.OleDb.OleDbCommand
        Dim oda As New System.Data.OleDb.OleDbDataAdapter
        Dim ocn As New System.Data.OleDb.OleDbConnection

        If ComboBox1.Text = "" Or ComboBox2.Text = "" Or TextBox3.Text = "" Or TextBox9.Text = "" Or TextBox9.Text = "0" Then
            MsgBox("مشخصات فرم گزارش کامل نیست", , "پیغام")
        ElseIf count > 10 Then
            MsgBox("فرم گزارش جدید ایجاد کنید", , "پیغام")
        Else
            TextBox30.Text = TextBox3.Text
            TextBox32.Text = TextBox3.Text
            TextBox3.ReadOnly = True
            LP += 1
            ocn.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
            "atabase Password=" + Form14.TextBox10.Text + "")
            ocm.Connection = ocn
            ocm.CommandText = "INSERT INTO Shekastegi (reporter,mokhatab,tedad,NL,SL,address,roosta,Y,M,D,bakhsh,NUM,vazeiat) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13)"
            ocm.Parameters.Clear()
            ocm.Parameters.AddWithValue("@p1", TextBox10.Text)
            ocm.Parameters.AddWithValue("@p2", TextBox3.Text)
            ocm.Parameters.AddWithValue("@p3", TextBox9.Text)
            ocm.Parameters.AddWithValue("@p4", ComboBox3.Text)
            ocm.Parameters.AddWithValue("@p5", TextBox7.Text)
            ocm.Parameters.AddWithValue("@p6", TextBox6.Text)
            ocm.Parameters.AddWithValue("@p7", ComboBox2.Text)
            ocm.Parameters.AddWithValue("@p8", TextBox29.Text)
            ocm.Parameters.AddWithValue("@p9", TextBox28.Text)
            ocm.Parameters.AddWithValue("@p10", TextBox1.Text)
            ocm.Parameters.AddWithValue("@p11", ComboBox1.Text)
            ocm.Parameters.AddWithValue("@p12", LP)
            ocm.Parameters.AddWithValue("@p13", False)
            ocn.Open()
            ocm.ExecuteNonQuery()
            ocn.Close()
            ocm.Dispose()
            ocn.Dispose()

            Select Case count
                Case 0
                    TextBox17.Text = " 1 _ " + ComboBox2.Text + " _ " + TextBox6.Text + " _ " + TextBox7.Text + " _ " + ComboBox3.Text + " _ " + TextBox9.Text + " مورد " + " _ " + TextBox10.Text

                Case 1
                    TextBox18.Text = " 2 _ " + ComboBox2.Text + " _ " + TextBox6.Text + " _ " + TextBox7.Text + " _ " + ComboBox3.Text + " _ " + TextBox9.Text + " مورد " + " _ " + TextBox10.Text

                Case 2
                    TextBox19.Text = " 3 _ " + ComboBox2.Text + " _ " + TextBox6.Text + " _ " + TextBox7.Text + " _ " + ComboBox3.Text + " _ " + TextBox9.Text + " مورد " + " _ " + TextBox10.Text

                Case 3
                    TextBox20.Text = " 4 _ " + ComboBox2.Text + " _ " + TextBox6.Text + " _ " + TextBox7.Text + " _ " + ComboBox3.Text + " _ " + TextBox9.Text + " مورد " + " _ " + TextBox10.Text

                Case 4
                    TextBox21.Text = " 5 _ " + ComboBox2.Text + " _ " + TextBox6.Text + " _ " + TextBox7.Text + " _ " + ComboBox3.Text + " _ " + TextBox9.Text + " مورد " + " _ " + TextBox10.Text

                Case 5
                    TextBox22.Text = " 6 _ " + ComboBox2.Text + " _ " + TextBox6.Text + " _ " + TextBox7.Text + " _ " + ComboBox3.Text + " _ " + TextBox9.Text + " مورد " + " _ " + TextBox10.Text

                Case 6
                    TextBox23.Text = " 7 _ " + ComboBox2.Text + " _ " + TextBox6.Text + " _ " + TextBox7.Text + " _ " + ComboBox3.Text + " _ " + TextBox9.Text + " مورد " + " _ " + TextBox10.Text

                Case 7
                    TextBox24.Text = " 8 _ " + ComboBox2.Text + " _ " + TextBox6.Text + " _ " + TextBox7.Text + " _ " + ComboBox3.Text + " _ " + TextBox9.Text + " مورد " + " _ " + TextBox10.Text

                Case 8
                    TextBox25.Text = " 9 _ " + ComboBox2.Text + " _ " + TextBox6.Text + " _ " + TextBox7.Text + " _ " + ComboBox3.Text + " _ " + TextBox9.Text + " مورد " + " _ " + TextBox10.Text

                Case 9
                    TextBox26.Text = " 10 _ " + ComboBox2.Text + " _ " + TextBox6.Text + " _ " + TextBox7.Text + " _ " + ComboBox3.Text + " _ " + TextBox9.Text + " مورد " + " _ " + TextBox10.Text

                Case 10
                    TextBox27.Text = " 11 _ " + ComboBox2.Text + " _ " + TextBox6.Text + " _ " + TextBox7.Text + " _ " + ComboBox3.Text + " _ " + TextBox9.Text + " مورد " + " _ " + TextBox10.Text

            End Select
            count += 1
            NUM += Convert.ToInt32(TextBox9.Text)
            TextBox6.Text = ""
            TextBox7.Text = ""
            ComboBox3.Text = ""
            TextBox9.Text = ""
            TextBox10.Text = ""
            t = False
        End If

    End Sub
    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Button42_Click(sender, e)
        TextBox6.Text = ""
        TextBox7.Text = ""
        ComboBox3.Text = ""
        TextBox9.Text = ""
        TextBox10.Text = ""
    End Sub

    Private Sub Button14_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        Dim ocn As New System.Data.OleDb.OleDbConnection
        Dim ocm As New System.Data.OleDb.OleDbCommand
        Dim stp As Integer = 1

        ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\Data.mdb"
        ocm.Connection = ocn
        ocm.CommandText = "DELETE FROM Shekastegi WHERE NUM=@p12"
        ocm.Parameters.Clear()
        ocm.Parameters.AddWithValue("@p12", TextBox11.Text)
        ocn.Open()
        ocm.ExecuteNonQuery()
        ocn.Close()
        ocm.Dispose()
        ocn.Dispose()
        stp = Convert.ToInt32(TextBox11.Text)
        Select Case stp
            Case 1
                TextBox17.Text = "1 _ "
            Case 2
                TextBox18.Text = "2 _ "
            Case 3
                TextBox19.Text = "3 _ "
            Case 4
                TextBox20.Text = "4 _ "
            Case 5
                TextBox21.Text = "5 _ "
            Case 6
                TextBox22.Text = "6 _ "
            Case 7
                TextBox23.Text = "7 _ "
            Case 8
                TextBox24.Text = "8 _ "
            Case 9
                TextBox25.Text = "9 _ "
            Case 10
                TextBox26.Text = "10 _ "
            Case 11
                TextBox27.Text = "11 _ "
        End Select
        Button14.Visible = False
        Button41.Visible = False
        Button1.Visible = True
        TextBox11.Text = ""
    End Sub

    Private Sub TextBox9_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox9.KeyPress
        If Not IsNumeric(e.KeyChar) And e.KeyChar <> Convert.ToChar(Keys.Back) And e.KeyChar <> Convert.ToChar(Keys.Delete) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox11_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox11.Click
        TextBox11.Text = ""
        TextBox12.Visible = False
    End Sub
    Private Sub TextBox11_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox11.KeyPress
        If Not IsNumeric(e.KeyChar) And e.KeyChar <> Convert.ToChar(Keys.Back) And e.KeyChar <> Convert.ToChar(Keys.Delete) Then
            e.Handled = True
        End If
    End Sub
    Private Sub ComboBox1_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.DropDown
        test = True
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
                    TextBox36.Text = TextBox35.Text
                    TextBox35.DataBindings.Add(New Binding("Text", ds, "Roostaha.roosta"))
                    ComboBox2.Items.Add(TextBox35.Text)
                    Me.BindingContext(ds, "Roostaha").Position += 1
                    TextBox35.DataBindings.Clear()
                    If TextBox35.Text = TextBox36.Text Then
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
                    TextBox36.Text = TextBox35.Text
                    TextBox35.DataBindings.Add(New Binding("Text", ds, "Roostaha.roosta"))
                    ComboBox2.Items.Add(TextBox35.Text)
                    Me.BindingContext(ds, "Roostaha").Position += 1
                    TextBox35.DataBindings.Clear()
                    If TextBox35.Text = TextBox36.Text Then
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
    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click
        If Not t Then
            Dim result As Integer = MsgBox("آيا گزارش جاری را ذخیره می کنید؟", MsgBoxStyle.YesNoCancel)
            If result = MsgBoxResult.Yes Then
                address = Form1.TextBox3.Text
                Dim ocn As New System.Data.OleDb.OleDbConnection
                Dim ocm As New System.Data.OleDb.OleDbCommand
                Dim oda As New System.Data.OleDb.OleDbDataAdapter
                Dim ds As New DataSet()

                Button42_Click(sender, e)
                TextBox3.ReadOnly = False
                ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                    "atabase Password=" + Form14.TextBox10.Text + ""
                ocm.Connection = ocn
                ocm.CommandText = "update Shekastegi SET NUM=0"
                ocn.Open()
                ocm.ExecuteNonQuery()
                ocn.Close()
                ocm.Dispose()
                ocn.Dispose()
                TextBox3.Text = ""
                Label4.Text = ""
                TextBox17.Text = ""
                TextBox18.Text = ""
                TextBox19.Text = ""
                TextBox20.Text = ""
                TextBox21.Text = ""
                TextBox22.Text = ""
                TextBox23.Text = ""
                TextBox24.Text = ""
                TextBox25.Text = ""
                TextBox26.Text = ""
                TextBox27.Text = ""
                TextBox30.Text = ""
                TextBox32.Text = ""
                count = 0
                LP = 0
                t = True

            ElseIf result = MsgBoxResult.No Then
                address = Form1.TextBox3.Text
                Dim ocn As New System.Data.OleDb.OleDbConnection
                Dim ocm As New System.Data.OleDb.OleDbCommand
                Dim oda As New System.Data.OleDb.OleDbDataAdapter
                Dim ds As New DataSet()

                Button42_Click(sender, e)
                TextBox3.ReadOnly = False
                ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                    "atabase Password=" + Form14.TextBox10.Text + ""
                ocm.Connection = ocn
                ocm.CommandText = "DELETE FROM Shekastegi WHERE NUM >'" & 0 & "'"
                ocn.Open()
                ocm.ExecuteNonQuery()
                ocn.Close()
                ocm.Dispose()
                ocn.Dispose()
                TextBox3.Text = ""
                Label4.Text = ""
                TextBox17.Text = ""
                TextBox18.Text = ""
                TextBox19.Text = ""
                TextBox20.Text = ""
                TextBox21.Text = ""
                TextBox22.Text = ""
                TextBox23.Text = ""
                TextBox24.Text = ""
                TextBox25.Text = ""
                TextBox26.Text = ""
                TextBox27.Text = ""
                TextBox30.Text = ""
                TextBox32.Text = ""
                count = 0
                LP = 0
                t = True
            End If
        Else
            MsgBox("شما مجاز به ایجاد گزارش جدید نیستید", , "پیغام")
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim ocn As New System.Data.OleDb.OleDbConnection
        Dim ocm As New System.Data.OleDb.OleDbCommand
        Dim oda As New System.Data.OleDb.OleDbDataAdapter
        Dim PC As Int64
        address = Form1.TextBox3.Text
        If ComboBox8.Text = "روز" Or ComboBox9.Text = "ماه" Or TextBox4.Text = "سال" Or TextBox4.Text = "" Or ComboBox11.Text = "روز" Or ComboBox10.Text = "ماه" Or TextBox33.Text = "سال" Or TextBox33.Text = "" Or ComboBox4.Text = "" Then
            MsgBox("فیلد ها را تکمیل کنید", , "پیغام")
        ElseIf ((Convert.ToInt32(ComboBox9.Text)) > (Convert.ToInt32(ComboBox10.Text)) And (Convert.ToInt32(TextBox4.Text)) >= (Convert.ToInt32(TextBox33.Text))) Or ((Convert.ToInt32(ComboBox9.Text)) = (Convert.ToInt32(ComboBox10.Text)) And (Convert.ToInt32(TextBox4.Text)) = (Convert.ToInt32(TextBox33.Text)) And (Convert.ToInt32(ComboBox8.Text)) > (Convert.ToInt32(ComboBox11.Text))) Then
            MsgBox("خطا در تاریخ ورودی", , "پیغام")
        Else
            If ComboBox4.Text = "براساس نام روستا" Then
                If ComboBox12.Text = "" Then
                    MsgBox("نام روستا را وارد کنید", , "پیغام")
                Else

                    Dim con As New System.Data.OleDb.OleDbConnection
                    Dim strSql As String
                    Dim strCon As String = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                    "atabase Password=" + Form14.TextBox10.Text + "")

                    strSql = "SELECT * FROM Shekastegi where roosta = '" & ComboBox12.SelectedItem & "' AND ((((Y + M + D) >='" & TextBox4.Text + ComboBox9.Text + ComboBox8.Text & "') AND ((Y + M + D)<='" & TextBox33.Text + ComboBox10.Text + ComboBox11.Text & "')))"
                    con = New OleDb.OleDbConnection(strCon)
                    con.Open()
                    da = New OleDb.OleDbDataAdapter(strSql, con)
                    If da.Fill(ds, "Shekastegi") Then

                        CrystalReportViewer1.Size = New System.Drawing.Size(x, y)
                        CrystalReportViewer1.Location = New System.Drawing.Point(1, 1)
                        Button13.Location = New System.Drawing.Point(x - 115, 5)

                        Stext()

                        TextBox45.DataBindings.Add(New Binding("Text", ds, "Shekastegi.mokhatab"))
                        TextBox46.DataBindings.Add(New Binding("Text", ds, "Shekastegi.address"))
                        TextBox47.DataBindings.Add(New Binding("Text", ds, "Shekastegi.SL"))
                        TextBox48.DataBindings.Add(New Binding("Text", ds, "Shekastegi.NL"))
                        TextBox49.DataBindings.Add(New Binding("Text", ds, "Shekastegi.tedad"))
                        TextBox50.DataBindings.Add(New Binding("Text", ds, "Shekastegi.reporter"))
                        TextBox54.DataBindings.Add(New Binding("Text", ds, "Shekastegi.Y"))
                        TextBox55.DataBindings.Add(New Binding("Text", ds, "Shekastegi.M"))
                        TextBox56.DataBindings.Add(New Binding("Text", ds, "Shekastegi.D"))

                        Do
                            TextBox58.Text = TextBox46.Text
                            TextBox59.Text = TextBox45.Text

                            TextBox37.Text += TextBox45.Text & vbCrLf
                            TextBox40.Text += TextBox46.Text & vbCrLf
                            TextBox41.Text += TextBox47.Text & vbCrLf
                            TextBox42.Text += TextBox48.Text & vbCrLf
                            TextBox43.Text += TextBox49.Text & vbCrLf
                            PC += Convert.ToInt64(TextBox49.Text)
                            TextBox31.Text = Convert.ToString(PC)
                            TextBox44.Text += TextBox50.Text & vbCrLf
                            TextBox57.Text += TextBox54.Text + "/" + TextBox55.Text + "/" + TextBox56.Text & vbCrLf
                            Me.BindingContext(ds, "Shekastegi").Position += 1

                            If TextBox58.Text = TextBox46.Text And TextBox59.Text = TextBox45.Text Then
                                Exit Do
                            End If
                        Loop

                        rpt1.SetParameterValue("A1", ComboBox12.SelectedItem)
                        rpt1.SetParameterValue("A2", TextBox34.Text)
                        rpt1.SetParameterValue("A3", (TextBox4.Text + "/" + ComboBox9.SelectedItem + "/" + ComboBox8.SelectedItem))
                        rpt1.SetParameterValue("A4", (TextBox33.Text + "/" + ComboBox10.SelectedItem + "/" + ComboBox11.SelectedItem))
                        rpt1.SetParameterValue("A5", TextBox57.Text)
                        rpt1.SetParameterValue("A6", TextBox31.Text)
                        rpt1.SetParameterValue("A7", TextBox40.Text)
                        rpt1.SetParameterValue("A8", TextBox41.Text)
                        rpt1.SetParameterValue("A9", TextBox42.Text)
                        rpt1.SetParameterValue("A10", TextBox43.Text)
                        rpt1.SetParameterValue("A11", TextBox37.Text)
                        rpt1.SetParameterValue("A12", TextBox44.Text)
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
            ElseIf ComboBox4.Text = "براساس نام بخش" Then

                If ComboBox5.Text = "" Then
                    MsgBox("نام بخش را وارد کنید", , "پیغام")
                Else


                    Dim dt As New DataTable

                    ocn.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + "")
                    ocm.Connection = ocn
                    If ComboBox5.Text = "کل روستاها" Then
                        ocm.CommandText = "SELECT * FROM Shekastegi"
                    Else
                        ocm.CommandText = "SELECT * FROM Shekastegi where Bakhsh Like'%" & ComboBox5.Text & "%' AND ((((Y + M + D) >='" & TextBox4.Text + ComboBox9.Text + ComboBox8.Text & "') AND ((Y + M + D)<='" & TextBox33.Text + ComboBox10.Text + ComboBox11.Text & "')))"

                    End If

                    oda.SelectCommand = ocm
                    If oda.Fill(dt) Then

                        GroupBox9.Visible = True
                        DataGridView1.Visible = True
                        DataGridView1.Size = New Size(Me.Size.Width, Me.Height - 100)


                        Button6.Location = New Point(15, Me.Height - 65)
                        Button5.Location = New Point(180, Me.Height - 65)
                        Button6.Visible = True
                        Button5.Visible = True

                        GroupBox9.Location = New Point(20, 5)
                        GroupBox9.Size = New Size(Me.Size.Width - 30, Me.Height - 10)

                        DataGridView1.DataSource = dt

                        GroupBox9.BringToFront()
                        DataGridView1.BringToFront()

                        DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True

                        DataGridView1.Columns(0).HeaderText = "گزارش دهنده"
                        DataGridView1.Columns(1).HeaderText = "مخاطب گزارش"
                        DataGridView1.Columns(2).HeaderText = "تعداد"
                        DataGridView1.Columns(3).HeaderText = "نوع لوله"
                        DataGridView1.Columns(4).HeaderText = "سایز لوله"
                        DataGridView1.Columns(5).HeaderText = "آدرس محل"
                        DataGridView1.Columns(6).HeaderText = "روستا "
                        DataGridView1.Columns(7).HeaderText = "سال"
                        DataGridView1.Columns(8).HeaderText = "ماه"
                        DataGridView1.Columns(9).HeaderText = "روز"
                        DataGridView1.Columns(10).HeaderText = "بخش"
                        DataGridView1.Columns(11).Visible = False
                        DataGridView1.Columns(12).HeaderText = "وضعیت"
                    Else
                        MsgBox("موردی یافت نشد", , "پیغام")
                    End If
                End If

            ElseIf ComboBox4.Text = "براساس سایز لوله" Then

                If TextBox61.Text = "" Then
                    MsgBox("سایز لوله را وارد کنید", , "پیغام")
                Else


                    Dim dt As New DataTable

                    ocn.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + "")
                    ocm.Connection = ocn

                    ocm.CommandText = "SELECT * FROM Shekastegi where SL ='" & TextBox61.Text & "' AND ((((Y + M + D) >='" & TextBox4.Text + ComboBox9.Text + ComboBox8.Text & "') AND ((Y + M + D)<='" & TextBox33.Text + ComboBox10.Text + ComboBox11.Text & "')))"


                    oda.SelectCommand = ocm
                    If oda.Fill(dt) Then

                        GroupBox9.Visible = True
                        DataGridView1.Visible = True
                        DataGridView1.Size = New Size(Me.Size.Width, Me.Height - 100)


                        Button6.Location = New Point(15, Me.Height - 65)
                        Button5.Location = New Point(180, Me.Height - 65)
                        Button6.Visible = True
                        Button5.Visible = True

                        GroupBox9.Location = New Point(20, 5)
                        GroupBox9.Size = New Size(Me.Size.Width - 30, Me.Height - 10)

                        DataGridView1.DataSource = dt

                        GroupBox9.BringToFront()
                        DataGridView1.BringToFront()

                        DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True

                        DataGridView1.Columns(0).HeaderText = "گزارش دهنده"
                        DataGridView1.Columns(1).HeaderText = "مخاطب گزارش"
                        DataGridView1.Columns(2).HeaderText = "تعداد"
                        DataGridView1.Columns(3).HeaderText = "نوع لوله"
                        DataGridView1.Columns(4).HeaderText = "سایز لوله"
                        DataGridView1.Columns(5).HeaderText = "آدرس محل"
                        DataGridView1.Columns(6).HeaderText = "روستا "
                        DataGridView1.Columns(7).HeaderText = "سال"
                        DataGridView1.Columns(8).HeaderText = "ماه"
                        DataGridView1.Columns(9).HeaderText = "روز"
                        DataGridView1.Columns(10).HeaderText = "بخش"
                        DataGridView1.Columns(11).Visible = False
                        DataGridView1.Columns(12).HeaderText = "وضعیت"
                    Else
                        MsgBox("موردی یافت نشد", , "پیغام")
                    End If
                End If

            End If

        End If
    End Sub


#Region "comboboxs"
    Private Sub ComboBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboBox1.KeyDown
        e.SuppressKeyPress = True
    End Sub
    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox1.KeyPress
        e.Handled = True
    End Sub
    Private Sub ComboBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = True
    End Sub
    Private Sub ComboBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = True
    End Sub
    Private Sub ComboBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = True
    End Sub
    Private Sub ComboBox5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = True
    End Sub
    Private Sub ComboBox6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = True
    End Sub
    Private Sub ComboBox7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = True
    End Sub
    Private Sub ComboBox8_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox8.KeyPress
        e.Handled = True
    End Sub
    Private Sub ComboBox8_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox8.SelectedIndexChanged
        If ComboBox9.Text = "07" Or ComboBox9.Text = "08" Or ComboBox9.Text = "09" Or ComboBox9.Text = "10" Or ComboBox9.Text = "11" Or ComboBox9.Text = "12" Then
            If ComboBox8.SelectedItem = "31" Then
                ComboBox8.SelectedItem = "30"
            End If
        End If
    End Sub
    Private Sub ComboBox9_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox9.KeyPress
        e.Handled = True
    End Sub
    Private Sub ComboBox9_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox9.SelectedIndexChanged
        If ComboBox9.Text = "07" Or ComboBox9.Text = "08" Or ComboBox9.Text = "09" Or ComboBox9.Text = "10" Or ComboBox9.Text = "11" Or ComboBox9.Text = "12" Then
            If ComboBox8.SelectedItem = "31" Then
                ComboBox8.SelectedItem = "30"
            End If
        End If
    End Sub
    Private Sub ComboBox10_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox10.KeyPress
        e.Handled = True
    End Sub
    Private Sub ComboBox10_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox10.SelectedIndexChanged
        If ComboBox10.Text = "07" Or ComboBox10.Text = "08" Or ComboBox10.Text = "09" Or ComboBox10.Text = "10" Or ComboBox10.Text = "11" Or ComboBox10.Text = "12" Then
            If ComboBox11.SelectedItem = "31" Then
                ComboBox11.SelectedItem = "30"
            End If
        End If
    End Sub
    Private Sub ComboBox11_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox11.KeyPress
        e.Handled = True
    End Sub
    Private Sub ComboBox11_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox11.SelectedIndexChanged
        If ComboBox10.Text = "07" Or ComboBox10.Text = "08" Or ComboBox10.Text = "09" Or ComboBox10.Text = "10" Or ComboBox10.Text = "11" Or ComboBox10.Text = "12" Then
            If ComboBox11.SelectedItem = "31" Then
                ComboBox11.SelectedItem = "30"
            End If
        End If
    End Sub
    Private Sub ComboBox12_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox12.SelectedIndexChanged
        Dim ds As New DataSet()
        Dim strSql As String
        Dim strCon As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\Data.mdb"
        Dim da As OleDb.OleDbDataAdapter
        Dim con As OleDb.OleDbConnection

        strSql = "select * from Roostaha where roosta= '" & ComboBox12.Text & "'"
        con = New OleDb.OleDbConnection(strCon)
        con.Open()
        da = New OleDb.OleDbDataAdapter(strSql, con)
        da.Fill(ds, "Roostaha")

        TextBox34.DataBindings.Add(New Binding("text", ds, "Roostaha.bakhsh"))
        TextBox34.DataBindings.Clear()
    End Sub
    Private Sub ComboBox12_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox12.KeyPress
        e.Handled = True
    End Sub
#End Region

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        n = 0
        key = False
        GroupBox7.Visible = True
        ComboBox8.Enabled = False
        ComboBox9.Enabled = False
        ComboBox10.Enabled = False
        ComboBox11.Enabled = False
        ComboBox12.Enabled = False
        TextBox33.Enabled = False
        Button4.Enabled = False
        Button9.Enabled = False
        TextBox4.Text = ""
        Button10.Enabled = True
        Button15.Enabled = True
        Button17.Enabled = True
        Button18.Enabled = True
        Button19.Enabled = True
        Button20.Enabled = True
        Button21.Enabled = True
        Button22.Enabled = True
        Button23.Enabled = True
        Button25.Enabled = True
    End Sub
#Region "keyboard1"
    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        TextBox4.Text += "1"
        n += 1
        If n > 3 Then
            Button10.Enabled = False
            Button15.Enabled = False
            Button17.Enabled = False
            Button18.Enabled = False
            Button19.Enabled = False
            Button20.Enabled = False
            Button21.Enabled = False
            Button22.Enabled = False
            Button23.Enabled = False
            Button25.Enabled = False
        End If
    End Sub
    Private Sub Button15_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        TextBox4.Text += "2"
        n += 1
        If n > 3 Then
            Button10.Enabled = False
            Button15.Enabled = False
            Button17.Enabled = False
            Button18.Enabled = False
            Button19.Enabled = False
            Button20.Enabled = False
            Button21.Enabled = False
            Button22.Enabled = False
            Button23.Enabled = False
            Button25.Enabled = False
        End If
    End Sub
    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click
        TextBox4.Text += "3"
        n += 1
        If n > 3 Then
            Button10.Enabled = False
            Button15.Enabled = False
            Button17.Enabled = False
            Button18.Enabled = False
            Button19.Enabled = False
            Button20.Enabled = False
            Button21.Enabled = False
            Button22.Enabled = False
            Button23.Enabled = False
            Button25.Enabled = False
        End If
    End Sub
    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Click
        TextBox4.Text += "4"
        n += 1
        If n > 3 Then
            Button10.Enabled = False
            Button15.Enabled = False
            Button17.Enabled = False
            Button18.Enabled = False
            Button19.Enabled = False
            Button20.Enabled = False
            Button21.Enabled = False
            Button22.Enabled = False
            Button23.Enabled = False
            Button25.Enabled = False
        End If
    End Sub
    Private Sub Button19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button19.Click
        TextBox4.Text += "5"
        n += 1
        If n > 3 Then
            Button10.Enabled = False
            Button15.Enabled = False
            Button17.Enabled = False
            Button18.Enabled = False
            Button19.Enabled = False
            Button20.Enabled = False
            Button21.Enabled = False
            Button22.Enabled = False
            Button23.Enabled = False
            Button25.Enabled = False
        End If
    End Sub
    Private Sub Button20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button20.Click
        TextBox4.Text += "6"
        n += 1
        If n > 3 Then
            Button10.Enabled = False
            Button15.Enabled = False
            Button17.Enabled = False
            Button18.Enabled = False
            Button19.Enabled = False
            Button20.Enabled = False
            Button21.Enabled = False
            Button22.Enabled = False
            Button23.Enabled = False
            Button25.Enabled = False
        End If
    End Sub
    Private Sub Button21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button21.Click
        TextBox4.Text += "7"
        n += 1
        If n > 3 Then
            Button10.Enabled = False
            Button15.Enabled = False
            Button17.Enabled = False
            Button18.Enabled = False
            Button19.Enabled = False
            Button20.Enabled = False
            Button21.Enabled = False
            Button22.Enabled = False
            Button23.Enabled = False
            Button25.Enabled = False
        End If
    End Sub
    Private Sub Button22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button22.Click
        TextBox4.Text += "8"
        n += 1
        If n > 3 Then
            Button10.Enabled = False
            Button15.Enabled = False
            Button17.Enabled = False
            Button18.Enabled = False
            Button19.Enabled = False
            Button20.Enabled = False
            Button21.Enabled = False
            Button22.Enabled = False
            Button23.Enabled = False
            Button25.Enabled = False
        End If
    End Sub
    Private Sub Button23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button23.Click
        TextBox4.Text += "9"
        n += 1
        If n > 3 Then
            Button10.Enabled = False
            Button15.Enabled = False
            Button17.Enabled = False
            Button18.Enabled = False
            Button19.Enabled = False
            Button20.Enabled = False
            Button21.Enabled = False
            Button22.Enabled = False
            Button23.Enabled = False
            Button25.Enabled = False
        End If
    End Sub
    Private Sub Button24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button24.Click
        TextBox4.Text = ""
        Button10.Enabled = True
        Button15.Enabled = True
        Button17.Enabled = True
        Button18.Enabled = True
        Button19.Enabled = True
        Button20.Enabled = True
        Button21.Enabled = True
        Button22.Enabled = True
        Button23.Enabled = True
        Button25.Enabled = True
        n = 0
    End Sub
    Private Sub Button25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button25.Click
        TextBox4.Text += "0"
        n += 1
        If n > 3 Then
            Button10.Enabled = False
            Button15.Enabled = False
            Button17.Enabled = False
            Button18.Enabled = False
            Button19.Enabled = False
            Button20.Enabled = False
            Button21.Enabled = False
            Button22.Enabled = False
            Button23.Enabled = False
            Button25.Enabled = False
        End If
    End Sub
    Private Sub Button26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button26.Click
        If n >= 4 Then
            ComboBox8.Enabled = True
            ComboBox9.Enabled = True
            ComboBox10.Enabled = True
            ComboBox11.Enabled = True
            ComboBox12.Enabled = True
            TextBox33.Enabled = True
            Button4.Enabled = True
            Button9.Enabled = True
            key = True
            GroupBox7.Visible = False
        Else
            MsgBox("چهار رقم برای سال وروردی الزامیست", , "پیغام")
        End If
    End Sub
    Private Sub Button27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button27.Click
        ComboBox8.Enabled = True
        ComboBox9.Enabled = True
        ComboBox10.Enabled = True
        ComboBox11.Enabled = True
        ComboBox12.Enabled = True
        TextBox33.Enabled = True
        Button4.Enabled = True
        Button9.Enabled = True
        TextBox4.Text = "سال"
        key = True
        GroupBox7.Visible = False
    End Sub
    Private Sub TextBox4_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox4.Click
        If key = True Then
            TextBox4.Text = ""
        End If
    End Sub
    Private Sub TextBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress
        If Not key = True Then
            e.Handled = True
        End If
    End Sub
#End Region

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        n = 0
        key = False
        GroupBox8.Visible = True
        ComboBox8.Enabled = False
        ComboBox9.Enabled = False
        ComboBox10.Enabled = False
        ComboBox11.Enabled = False
        ComboBox12.Enabled = False
        TextBox4.Enabled = False
        Button4.Enabled = False
        Button8.Enabled = False
        TextBox33.Text = ""
        Button40.Enabled = True
        Button39.Enabled = True
        Button38.Enabled = True
        Button37.Enabled = True
        Button36.Enabled = True
        Button35.Enabled = True
        Button34.Enabled = True
        Button33.Enabled = True
        Button32.Enabled = True
        Button30.Enabled = True
    End Sub
#Region "keyboard2"
    Private Sub Button28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button28.Click
        ComboBox8.Enabled = True
        ComboBox9.Enabled = True
        ComboBox10.Enabled = True
        ComboBox11.Enabled = True
        ComboBox12.Enabled = True
        TextBox4.Enabled = True
        Button4.Enabled = True
        Button8.Enabled = True
        TextBox33.Text = "سال"
        key = True
        GroupBox8.Visible = False
    End Sub
    Private Sub Button29_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button29.Click
        TextBox33.Text = ""
        Button40.Enabled = True
        Button39.Enabled = True
        Button38.Enabled = True
        Button37.Enabled = True
        Button36.Enabled = True
        Button35.Enabled = True
        Button34.Enabled = True
        Button33.Enabled = True
        Button32.Enabled = True
        Button30.Enabled = True
        n = 0
    End Sub
    Private Sub Button30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button30.Click
        TextBox33.Text += "0"
        n += 1
        If n > 3 Then
            Button40.Enabled = False
            Button39.Enabled = False
            Button38.Enabled = False
            Button37.Enabled = False
            Button36.Enabled = False
            Button35.Enabled = False
            Button34.Enabled = False
            Button33.Enabled = False
            Button32.Enabled = False
            Button30.Enabled = False
        End If
    End Sub
    Private Sub Button31_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button31.Click
        If n >= 4 Then
            ComboBox8.Enabled = True
            ComboBox9.Enabled = True
            ComboBox10.Enabled = True
            ComboBox11.Enabled = True
            ComboBox12.Enabled = True
            TextBox4.Enabled = True
            Button4.Enabled = True
            Button8.Enabled = True
            key = True
            GroupBox8.Visible = False
        Else
            MsgBox("چهار رقم برای سال وروردی الزامیست", , "پیغام")
        End If
    End Sub
    Private Sub Button32_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button32.Click
        TextBox33.Text += "9"
        n += 1
        If n > 3 Then
            Button40.Enabled = False
            Button39.Enabled = False
            Button38.Enabled = False
            Button37.Enabled = False
            Button36.Enabled = False
            Button35.Enabled = False
            Button34.Enabled = False
            Button33.Enabled = False
            Button32.Enabled = False
            Button30.Enabled = False
        End If
    End Sub
    Private Sub Button33_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button33.Click
        TextBox33.Text += "8"
        n += 1
        If n > 3 Then
            Button40.Enabled = False
            Button39.Enabled = False
            Button38.Enabled = False
            Button37.Enabled = False
            Button36.Enabled = False
            Button35.Enabled = False
            Button34.Enabled = False
            Button33.Enabled = False
            Button32.Enabled = False
            Button30.Enabled = False
        End If
    End Sub
    Private Sub Button34_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button34.Click
        TextBox33.Text += "7"
        n += 1
        If n > 3 Then
            Button40.Enabled = False
            Button39.Enabled = False
            Button38.Enabled = False
            Button37.Enabled = False
            Button36.Enabled = False
            Button35.Enabled = False
            Button34.Enabled = False
            Button33.Enabled = False
            Button32.Enabled = False
            Button30.Enabled = False
        End If
    End Sub
    Private Sub Button35_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button35.Click
        TextBox33.Text += "6"
        n += 1
        If n > 3 Then
            Button40.Enabled = False
            Button39.Enabled = False
            Button38.Enabled = False
            Button37.Enabled = False
            Button36.Enabled = False
            Button35.Enabled = False
            Button34.Enabled = False
            Button33.Enabled = False
            Button32.Enabled = False
            Button30.Enabled = False
        End If
    End Sub
    Private Sub Button36_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button36.Click
        TextBox33.Text += "5"
        n += 1
        If n > 3 Then
            Button40.Enabled = False
            Button39.Enabled = False
            Button38.Enabled = False
            Button37.Enabled = False
            Button36.Enabled = False
            Button35.Enabled = False
            Button34.Enabled = False
            Button33.Enabled = False
            Button32.Enabled = False
            Button30.Enabled = False
        End If
    End Sub
    Private Sub Button37_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button37.Click
        TextBox33.Text += "4"
        n += 1
        If n > 3 Then
            Button40.Enabled = False
            Button39.Enabled = False
            Button38.Enabled = False
            Button37.Enabled = False
            Button36.Enabled = False
            Button35.Enabled = False
            Button34.Enabled = False
            Button33.Enabled = False
            Button32.Enabled = False
            Button30.Enabled = False
        End If
    End Sub
    Private Sub Button38_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button38.Click
        TextBox33.Text += "3"
        n += 1
        If n > 3 Then
            Button40.Enabled = False
            Button39.Enabled = False
            Button38.Enabled = False
            Button37.Enabled = False
            Button36.Enabled = False
            Button35.Enabled = False
            Button34.Enabled = False
            Button33.Enabled = False
            Button32.Enabled = False
            Button30.Enabled = False
        End If
    End Sub
    Private Sub Button39_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button39.Click
        TextBox33.Text += "2"
        n += 1
        If n > 3 Then
            Button40.Enabled = False
            Button39.Enabled = False
            Button38.Enabled = False
            Button37.Enabled = False
            Button36.Enabled = False
            Button35.Enabled = False
            Button34.Enabled = False
            Button33.Enabled = False
            Button32.Enabled = False
            Button30.Enabled = False
        End If
    End Sub
    Private Sub Button40_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button40.Click
        TextBox33.Text += "1"
        n += 1
        If n > 3 Then
            Button40.Enabled = False
            Button39.Enabled = False
            Button38.Enabled = False
            Button37.Enabled = False
            Button36.Enabled = False
            Button35.Enabled = False
            Button34.Enabled = False
            Button33.Enabled = False
            Button32.Enabled = False
            Button30.Enabled = False
        End If
    End Sub
    Private Sub TextBox33_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox33.Click
        If key = True Then
            TextBox33.Text = ""
        End If
    End Sub
    Private Sub TextBox33_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox33.KeyPress
        If Not key = True Then
            e.Handled = True
        End If
    End Sub
#End Region


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
            TextBox36.Text = TextBox35.Text
            TextBox35.DataBindings.Add(New Binding("Text", ds, "Roostaha.roosta"))
            ComboBox2.Items.Add(TextBox35.Text)
            Me.BindingContext(ds, "Roostaha").Position += 1
            TextBox35.DataBindings.Clear()
            If TextBox35.Text = TextBox36.Text Then
                Exit Do
            End If
        Loop
        oda.Dispose()
        ocm.Dispose()
        ocn.Dispose()
        ComboBox1.Enabled = True
        ComboBox2.Enabled = True
        Button42.Visible = False
        test = True
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        address = Form1.TextBox3.Text
        Dim ocn As New System.Data.OleDb.OleDbConnection
        Dim ocm As New System.Data.OleDb.OleDbCommand
        Dim oda As New System.Data.OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        If TextBox11.Text = "" Or TextBox11.Text = "0" Then
            MsgBox("ورودی نامعتبر", , "پیغام")
        Else
            ocn.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
            "atabase Password=" + Form14.TextBox10.Text + "")
            ocm.Connection = ocn
            ocm.CommandText = "SELECT * FROM Shekastegi where NUM='" & TextBox11.Text & "'"
            oda.SelectCommand = ocm
            If oda.Fill(dt) Then
                Button1.Visible = False
                Button41.Visible = True
                Button14.Visible = True
            Else
                TextBox12.Visible = True
            End If
            oda.Dispose()
            ocm.Dispose()
            ocn.Dispose()

        End If
    End Sub

    Private Sub Button41_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button41.Click
        Button1.Visible = True
        Button41.Visible = False
        Button14.Visible = False
        TextBox11.Text = ""
    End Sub

    Private Sub Button47_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button47.Click
        If Not GroupBox1.Visible Then
            GroupBox1.Visible = True
        Else
            GroupBox1.Visible = False
        End If
    End Sub

    Private Sub Button48_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button48.Click
        If Not GroupBox3.Visible And f Then
            address = Form1.TextBox3.Text
            Dim ds As New DataSet()
            Dim strSql As String
            Dim strCon As String = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
            "atabase Password=" + Form14.TextBox10.Text + "")
            Dim da As OleDb.OleDbDataAdapter
            Dim con As OleDb.OleDbConnection
            strSql = "select * from Form"
            con = New OleDb.OleDbConnection(strCon)
            con.Open()
            da = New OleDb.OleDbDataAdapter(strSql, con)
            da.Fill(ds, "Form")
            TextBox13.DataBindings.Add(New Binding("Text", ds, "Form.Ostan"))
            TextBox14.DataBindings.Add(New Binding("Text", ds, "Form.Shahr"))
            TextBox16.DataBindings.Add(New Binding("Text", ds, "Form.Shahr"))
            TextBox15.DataBindings.Add(New Binding("Text", ds, "Form.Name"))
            TextBox5.DataBindings.Add(New Binding("Text", ds, "Form.Address"))

            GroupBox3.Visible = True
            f = False
        ElseIf Not GroupBox3.Visible Then
            GroupBox3.Visible = True
        Else
            GroupBox3.Visible = False
        End If
    End Sub
    Private Sub GroupBox5_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GroupBox5.MouseDown
        BL = True
    End Sub
    Private Sub GroupBox5_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GroupBox5.MouseMove
        If e.Y <= 20 And e.X <= 25 Then
            GroupBox5.Cursor = Cursors.SizeAll
        Else
            GroupBox5.Cursor = Cursors.Default
        End If
        If BL And e.Y <= 20 And e.X <= 25 Then
            GroupBox5.Location = New Point((GroupBox5.Location.X) + e.X, (GroupBox5.Location.Y) + e.Y)
        End If
    End Sub
    Private Sub GroupBox5_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GroupBox5.MouseUp
        BL = False
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
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


    Private Sub Button45_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button45.Click
        If Not GroupBox2.Visible Then
            GroupBox2.Visible = True
        Else
            GroupBox2.Visible = False
        End If
    End Sub

    Private Sub Button46_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button46.Click
        If Not GroupBox4.Visible Then
            GroupBox4.Visible = True
        Else
            GroupBox4.Visible = False
        End If
    End Sub

    Private Sub ComboBox3_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox3.DropDown
        Dim ocn As New System.Data.OleDb.OleDbConnection
        Dim ocm As New System.Data.OleDb.OleDbCommand
        Dim oda As New System.Data.OleDb.OleDbDataAdapter
        Dim ds As New DataSet()

        address = Form1.TextBox3.Text
        TextBox60.Text = ""
        TextBox8.Text = ""
        If Not B Then
            ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
     "atabase Password=" + Form14.TextBox10.Text + ""
            ocm.Connection = ocn
            ocm.CommandText = "SELECT * FROM Noeloole"
            oda.SelectCommand = ocm
            da = New OleDbDataAdapter(ocm.CommandText, ocn)
            da.Fill(ds, "NOeloole")

            Do
                TextBox8.Text = TextBox60.Text
                TextBox60.DataBindings.Add(New Binding("Text", ds, "Noeloole.Name"))
                TextBox60.DataBindings.Clear()
                If TextBox60.Text = TextBox8.Text Then
                    Exit Do
                End If
                ComboBox3.Items.Add(TextBox60.Text)
                Me.BindingContext(ds, "Noeloole").Position += 1

            Loop
            B = True
        End If
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox4.SelectedIndexChanged
        If ComboBox4.Text = "براساس نام روستا" Then
            ComboBox12.Visible = True
            TextBox34.Visible = True
            Label12.Visible = True
            Label13.Visible = True
            Label5.Visible = False
            ComboBox5.Visible = False
            TextBox61.Visible = False
            Label17.Visible = False
        ElseIf ComboBox4.Text = "براساس نام بخش" Then
            ComboBox12.Visible = False
            TextBox34.Visible = False
            Label12.Visible = False
            Label13.Visible = False
            Label5.Visible = True
            ComboBox5.Visible = True
            TextBox61.Visible = False
            Label17.Visible = False
        ElseIf ComboBox4.Text = "براساس سایز لوله" Then
            ComboBox12.Visible = False
            TextBox34.Visible = False
            Label12.Visible = False
            Label13.Visible = False
            Label5.Visible = False
            ComboBox5.Visible = False
            TextBox61.Visible = True
            Label17.Visible = True
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        GroupBox9.Visible = False
        GroupBox9.SendToBack()
        DataGridView1.ReadOnly = True
        Button43.Visible = False
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If (SetupThePrinting()) Then
            Dim MyPrintPreviewDialog As PrintPreviewDialog = New PrintPreviewDialog()
            MyPrintPreviewDialog.Document = MyPrintDocument
            MyPrintPreviewDialog.ShowDialog()
        End If
    End Sub

    Private Sub MyPrintDocument_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles MyPrintDocument.PrintPage
        Dim more As Boolean = class2.DrawDataGridView(e.Graphics)
        If (more = True) Then
            e.HasMorePages = True
        End If
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click

        address = Form1.TextBox3.Text

        Dim dta As New OleDbDataAdapter("SELECT * FROM Shekastegi where Vazeiat=off", "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
"atabase Password=" + Form14.TextBox10.Text + "")
        Dim ds As New DataSet
        Dim bs As New BindingSource
        ds.Clear()
        dta.Fill(ds, "shekastegi")
        bs.DataSource = ds
        bs.DataMember = "shekastegi"
        Me.DataGridView1.DataSource = bs


        DataGridView1.ReadOnly = False
        GroupBox9.Visible = True
        DataGridView1.Visible = True
        DataGridView1.Size = New Size(Me.Size.Width, Me.Height - 100)


        Button6.Location = New Point(15, Me.Height - 65)
        Button5.Location = New Point(180, Me.Height - 65)
        Button43.Location = New Point(345, Me.Height - 65)
        Button6.Visible = True
        Button5.Visible = True
        Button43.Visible = True

        GroupBox9.Location = New Point(20, 5)
        GroupBox9.Size = New Size(Me.Size.Width, Me.Height - 10)



        GroupBox9.BringToFront()
        DataGridView1.BringToFront()
        DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        GroupBox9.BringToFront()
        DataGridView1.Columns(0).HeaderText = "گزارش دهنده"
        DataGridView1.Columns(1).HeaderText = "مخاطب گزارش"
        DataGridView1.Columns(2).HeaderText = "تعداد"
        DataGridView1.Columns(3).HeaderText = "نوع لوله"
        DataGridView1.Columns(4).HeaderText = "سایز لوله"
        DataGridView1.Columns(5).HeaderText = "آدرس محل"
        DataGridView1.Columns(6).HeaderText = "روستا "
        DataGridView1.Columns(7).HeaderText = "سال"
        DataGridView1.Columns(8).HeaderText = "ماه"
        DataGridView1.Columns(9).HeaderText = "روز"
        DataGridView1.Columns(10).HeaderText = "بخش"
        DataGridView1.Columns(11).Visible = False
        DataGridView1.Columns(12).HeaderText = "وضعیت"


        TextBox63.DataBindings.Clear()
        TextBox63.DataBindings.Add("text", bs, "Vazeiat", True, DataSourceUpdateMode.OnValidation)

        TextBox64.DataBindings.Clear()
        TextBox64.DataBindings.Add("text", bs, "D", True, DataSourceUpdateMode.OnValidation)

        TextBox65.DataBindings.Clear()
        TextBox65.DataBindings.Add("text", bs, "M", True, DataSourceUpdateMode.OnValidation)

        TextBox66.DataBindings.Clear()
        TextBox66.DataBindings.Add("text", bs, "Y", True, DataSourceUpdateMode.OnValidation)

        TextBox67.DataBindings.Clear()
        TextBox67.DataBindings.Add("text", bs, "roosta", True, DataSourceUpdateMode.OnValidation)

        TextBox68.DataBindings.Clear()
        TextBox68.DataBindings.Add("text", bs, "address", True, DataSourceUpdateMode.OnValidation)

        TextBox69.DataBindings.Clear()
        TextBox69.DataBindings.Add("text", bs, "SL", True, DataSourceUpdateMode.OnValidation)

        TextBox70.DataBindings.Clear()
        TextBox70.DataBindings.Add("text", bs, "NL", True, DataSourceUpdateMode.OnValidation)

        TextBox71.DataBindings.Clear()
        TextBox71.DataBindings.Add("text", bs, "tedad", True, DataSourceUpdateMode.OnValidation)

    End Sub

    Private Sub Button43_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button43.Click
        address = Form1.TextBox3.Text

        Dim dta As New OleDbDataAdapter("SELECT * FROM Shekastegi where Vazeiat=off", "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
"atabase Password=" + Form14.TextBox10.Text + "")
        Dim ds As New DataSet
        Dim bs As New BindingSource
        ds.Clear()
        dta.Fill(ds, "shekastegi")
        bs.DataSource = ds
        bs.DataMember = "shekastegi"
        Me.DataGridView1.DataSource = bs


        DataGridView1.ReadOnly = False
        GroupBox9.Visible = True
        DataGridView1.Visible = True
        DataGridView1.Size = New Size(Me.Size.Width, Me.Height - 100)


        ' Button6.Location = New Point(15, Me.Height - 65)
        'Button5.Location = New Point(180, Me.Height - 65)
        'Button43.Location = New Point(345, Me.Height - 65)
        Button6.Visible = True
        Button5.Visible = True
        Button43.Visible = True

        GroupBox9.Location = New Point(20, 5)
        GroupBox9.Size = New Size(Me.Size.Width, Me.Height - 10)



        GroupBox9.BringToFront()
        DataGridView1.BringToFront()
        DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        GroupBox9.BringToFront()
        DataGridView1.Columns(0).HeaderText = "گزارش دهنده"
        DataGridView1.Columns(1).HeaderText = "مخاطب گزارش"
        DataGridView1.Columns(2).HeaderText = "تعداد"
        DataGridView1.Columns(3).HeaderText = "نوع لوله"
        DataGridView1.Columns(4).HeaderText = "سایز لوله"
        DataGridView1.Columns(5).HeaderText = "آدرس محل"
        DataGridView1.Columns(6).HeaderText = "روستا "
        DataGridView1.Columns(7).HeaderText = "سال"
        DataGridView1.Columns(8).HeaderText = "ماه"
        DataGridView1.Columns(9).HeaderText = "روز"
        DataGridView1.Columns(10).HeaderText = "بخش"
        DataGridView1.Columns(11).Visible = False
        DataGridView1.Columns(12).HeaderText = "وضعیت"


        TextBox63.DataBindings.Clear()
        TextBox63.DataBindings.Add("text", bs, "Vazeiat", True, DataSourceUpdateMode.OnValidation)

        TextBox64.DataBindings.Clear()
        TextBox64.DataBindings.Add("text", bs, "D", True, DataSourceUpdateMode.OnValidation)

        TextBox65.DataBindings.Clear()
        TextBox65.DataBindings.Add("text", bs, "M", True, DataSourceUpdateMode.OnValidation)

        TextBox66.DataBindings.Clear()
        TextBox66.DataBindings.Add("text", bs, "Y", True, DataSourceUpdateMode.OnValidation)

        TextBox67.DataBindings.Clear()
        TextBox67.DataBindings.Add("text", bs, "roosta", True, DataSourceUpdateMode.OnValidation)

        TextBox68.DataBindings.Clear()
        TextBox68.DataBindings.Add("text", bs, "address", True, DataSourceUpdateMode.OnValidation)

        TextBox69.DataBindings.Clear()
        TextBox69.DataBindings.Add("text", bs, "SL", True, DataSourceUpdateMode.OnValidation)

        TextBox70.DataBindings.Clear()
        TextBox70.DataBindings.Add("text", bs, "NL", True, DataSourceUpdateMode.OnValidation)

        TextBox71.DataBindings.Clear()
        TextBox71.DataBindings.Add("text", bs, "tedad", True, DataSourceUpdateMode.OnValidation)


    End Sub

    Private Sub DataGridView1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEnter
        stri = TextBox63.Text

    End Sub



    Private Sub DataGridView1_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        Dim con As New OleDbConnection
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
    "atabase Password=" + Form14.TextBox10.Text + ""

        If stri = "False" Then

            con.Open()
            Dim command As New OleDbCommand
            command.Connection = con
            command.CommandText = "update shekastegi set vazeiat=yes  where d = '" & TextBox64.Text & "' and m = '" & TextBox65.Text & "' and y = '" & TextBox66.Text & "' and roosta = '" & TextBox67.Text & "' and address = '" & TextBox68.Text & "' and sl = '" & TextBox69.Text & "' and nl = '" & TextBox70.Text & "' and tedad = '" & TextBox71.Text & "'"
            command.Parameters.AddWithValue("vazeiat", Trim("yes"))
            command.ExecuteNonQuery()
            con.Close()
        ElseIf stri = "True" Then

            con.Open()
            Dim command As New OleDbCommand
            command.Connection = con
            command.CommandText = "update shekastegi set vazeiat=no  where d = '" & TextBox64.Text & "' and m = '" & TextBox65.Text & "' and y = '" & TextBox66.Text & "' and roosta = '" & TextBox67.Text & "' and address = '" & TextBox68.Text & "' and sl = '" & TextBox69.Text & "' and nl = '" & TextBox70.Text & "' and tedad = '" & TextBox71.Text & "'"
            command.Parameters.AddWithValue("vazeiat", Trim("no"))
            command.ExecuteNonQuery()
            con.Close()
        End If
    End Sub

   
End Class