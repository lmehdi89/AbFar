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

Public Class Form18
    Friend class2 As New class1
    Dim rpt As New CrystalReport17
    Public address As String
    Public sabt As Boolean = False
    Public y As Integer
    Public x As Integer
    Private da As OleDbDataAdapter
    Private ds As New DataSet
    Public test As Boolean = True


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
        MyPrintDocument.DocumentName = "پروژه های" + ComboBox17.Text
        MyPrintDocument.PrinterSettings = MyPrintDialog.PrinterSettings
        MyPrintDocument.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings
        MyPrintDocument.DefaultPageSettings.Margins = New Margins(40, 40, 40, 40)


        class2.DataGridViewPrinter(DataGridView1, myprintdocument, True, True, "پروژه های " + ComboBox17.Text, New Font("Tahoma", 10, FontStyle.Bold, GraphicsUnit.Point), Color.Black, True)
        Return True
    End Function
    Private Sub Form18_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        y = Me.Size.Height
        x = Me.Size.Width

        GroupBox1.Location = New System.Drawing.Point((x / 15), 5)

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If (ComboBox16.Text = "" Or ComboBox1.Text = "") Then
            MsgBox("فیلدها را تکمیل کنید", , "پیغام")
        Else
            TextBox49.Enabled = True
            If InStr(TextBox49.Text, ComboBox1.Text) = 0 Then
                TextBox49.Text += ComboBox1.Text + " _ "
                TextBox49.Enabled = False
            Else
                TextBox49.Enabled = False
                MsgBox("نام این روستا قبلا در این پروژه ثبت شده است", , "پیغام")
            End If

            If InStr(TextBox58.Text, ComboBox16.Text) = 0 Then
                TextBox58.Text += ComboBox16.Text + " _ "
            End If
        End If
        ComboBox16.Visible = True
        ComboBox16.Text = ""
        ComboBox1.Text = ""
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
        Form1.Button8_Click(sender, e)
    End Sub

    Private Sub ComboBox6_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox6.SelectedIndexChanged
        If ComboBox6.Text = "دارد" Then
            ComboBox6.Visible = False
            TextBox10.Visible = True
            Label16.Visible = True
        End If
    End Sub

    Private Sub ComboBox7_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox7.SelectedIndexChanged
        If ComboBox7.Text = "دارد" Then
            ComboBox7.Visible = False
            TextBox11.Visible = True
            Label17.Visible = True
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        address = Form1.TextBox3.Text
        Dim ocm As New System.Data.OleDb.OleDbCommand
        Dim oda As New System.Data.OleDb.OleDbDataAdapter
        Dim ocn As New System.Data.OleDb.OleDbConnection
        Dim st As String = "test"
        If TextBox49.Text = "" Then
            MsgBox("مشخصات فرم گزارش کامل نیست", , "پیغام")
        Else
            
            address = Form1.TextBox3.Text
            Dim dt As New DataTable
            ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
            "atabase Password=" + Form14.TextBox10.Text + ""
            ocm.Connection = ocn
            ocm.CommandText = "SELECT * FROM Projects where name='" & TextBox54.Text & "'"
            oda.SelectCommand = ocm
            If oda.Fill(dt) Then
                MsgBox("خطای نام پروژه تکراری", , "پیغام")
                ocn.Close()
                ocm.Dispose()
                ocn.Dispose()
            Else
                ocm.CommandText = "INSERT INTO projects (Tel1,Abdar,bishtar,CEB,TKM,TK,shiretakhlie,shirehava,TH,NL,tooleshabake,HF,mohavatesazi,masahat,vazeiat,otaghak,GTB,VTB,GK,VK,NK,KWMP2,NPS2,KWMP1,NPS1,VHD,HD,siklon,filter1,PPM2,PPM1,TMK,HK,NKZ,JLKP,TKP,SKP,SRAMH,SLKMH,SLVMH,ertefa,fasele,hajm2,SLK,SLV,hajm1,floter1,SHdebi,num2,SHtakhlie,num1,makanHCH,darpoosh,SLmakesh,SLchah,Eertefa,NS,debiM,omghpomp,omghchah,manba,count1,Byear,Eyear,Bakhsh,Roostaha,Name) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17,@p18,@p19,@p20,@p21,@p22,@p23,@p24,@p25,@p26,@p27,@p28,@p29,@p30,@p31,@p32,@p33,@p34,@p35,@p36,@p37,@p38,@p39,@p40,@p41,@p42,@p43,@p44,@p45,@p46,@p47,@p48,@p49,@p50,@p51,@p52,@p53,@p54,@p55,@p56,@p57,@p58,@p59,@p60,@p61,@p62,@p63,@p64,@p65,@p66,@p67)"
                ocm.Parameters.Clear()
                ocm.Parameters.AddWithValue("@p1", TextBox47.Text)
                ocm.Parameters.AddWithValue("@p2", TextBox46.Text)
                ocm.Parameters.AddWithValue("@p3", TextBox48.Text)
                ocm.Parameters.AddWithValue("@p4", TextBox45.Text)
                ocm.Parameters.AddWithValue("@p5", TextBox44.Text)
                ocm.Parameters.AddWithValue("@p6", TextBox43.Text)
                ocm.Parameters.AddWithValue("@p7", TextBox42.Text)
                ocm.Parameters.AddWithValue("@p8", TextBox41.Text)
                ocm.Parameters.AddWithValue("@p9", TextBox40.Text)
                ocm.Parameters.AddWithValue("@p10", TextBox39.Text)
                ocm.Parameters.AddWithValue("@p11", TextBox38.Text)
                ocm.Parameters.AddWithValue("@p12", TextBox37.Text)
                ocm.Parameters.AddWithValue("@p13", ComboBox15.Text)
                ocm.Parameters.AddWithValue("@p14", TextBox36.Text)
                ocm.Parameters.AddWithValue("@p15", ComboBox14.Text)
                ocm.Parameters.AddWithValue("@p16", TextBox35.Text)
                ocm.Parameters.AddWithValue("@p17", TextBox34.Text)
                ocm.Parameters.AddWithValue("@p18", TextBox33.Text)
                ocm.Parameters.AddWithValue("@p19", TextBox32.Text)
                ocm.Parameters.AddWithValue("@p20", TextBox31.Text)
                ocm.Parameters.AddWithValue("@p21", TextBox30.Text)
                ocm.Parameters.AddWithValue("@p22", TextBox29.Text)
                ocm.Parameters.AddWithValue("@p23", TextBox28.Text)
                ocm.Parameters.AddWithValue("@p24", TextBox27.Text)
                ocm.Parameters.AddWithValue("@p25", TextBox26.Text)
                ocm.Parameters.AddWithValue("@p26", ComboBox13.Text)
                ocm.Parameters.AddWithValue("@p27", ComboBox12.Text)
                ocm.Parameters.AddWithValue("@p28", ComboBox11.Text)
                ocm.Parameters.AddWithValue("@p29", ComboBox10.Text)
                ocm.Parameters.AddWithValue("@p30", TextBox24.Text)
                ocm.Parameters.AddWithValue("@p31", TextBox25.Text)
                ocm.Parameters.AddWithValue("@p32", TextBox23.Text)
                ocm.Parameters.AddWithValue("@p33", TextBox22.Text)
                ocm.Parameters.AddWithValue("@p34", ComboBox9.Text)
                ocm.Parameters.AddWithValue("@p35", TextBox21.Text)
                ocm.Parameters.AddWithValue("@p36", TextBox20.Text)
                ocm.Parameters.AddWithValue("@p37", TextBox19.Text)
                ocm.Parameters.AddWithValue("@p38", TextBox18.Text)
                ocm.Parameters.AddWithValue("@p39", TextBox17.Text)
                ocm.Parameters.AddWithValue("@p40", TextBox16.Text)
                ocm.Parameters.AddWithValue("@p41", TextBox15.Text)
                ocm.Parameters.AddWithValue("@p42", TextBox14.Text)
                ocm.Parameters.AddWithValue("@p43", TextBox13.Text)
                ocm.Parameters.AddWithValue("@p44", TextBox52.Text)
                ocm.Parameters.AddWithValue("@p45", TextBox53.Text)
                ocm.Parameters.AddWithValue("@p46", TextBox12.Text)
                ocm.Parameters.AddWithValue("@p47", ComboBox8.Text)
                ocm.Parameters.AddWithValue("@p48", ComboBox7.Text)
                ocm.Parameters.AddWithValue("@p49", TextBox11.Text)
                ocm.Parameters.AddWithValue("@p50", ComboBox6.Text)
                ocm.Parameters.AddWithValue("@p51", TextBox10.Text)
                ocm.Parameters.AddWithValue("@p52", TextBox9.Text)
                ocm.Parameters.AddWithValue("@p53", ComboBox5.Text)
                ocm.Parameters.AddWithValue("@p54", TextBox8.Text)
                ocm.Parameters.AddWithValue("@p55", TextBox7.Text)
                ocm.Parameters.AddWithValue("@p56", TextBox6.Text)
                ocm.Parameters.AddWithValue("@p57", ComboBox4.Text)
                ocm.Parameters.AddWithValue("@p58", TextBox5.Text)
                ocm.Parameters.AddWithValue("@p59", TextBox4.Text)
                ocm.Parameters.AddWithValue("@p60", TextBox3.Text)
                ocm.Parameters.AddWithValue("@p61", ComboBox3.Text)
                ocm.Parameters.AddWithValue("@p62", ComboBox2.Text)
                ocm.Parameters.AddWithValue("@p63", TextBox2.Text)
                ocm.Parameters.AddWithValue("@p64", TextBox1.Text)
                ocm.Parameters.AddWithValue("@p65", TextBox58.Text)
                ocm.Parameters.AddWithValue("@p66", TextBox49.Text)
                ocm.Parameters.AddWithValue("@p67", TextBox54.Text)
                ocn.Open()
                ocm.ExecuteNonQuery()
                ocn.Close()
                ocm.Dispose()
                ocn.Dispose()
                MsgBox("ثبت پروژه با موفقیت انحام شد", , "پیغام")
                sabt = True
            End If
        End If
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged
        If ComboBox3.Text = "چاه" Then
            TextBox3.Enabled = True
        Else
            TextBox3.Text = ""
            TextBox3.Enabled = False
        End If
    End Sub


    Private Sub TextBox6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox6.Click
        TextBox6.BringToFront()
    End Sub

    Private Sub Label10_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label10.MouseHover
        Label10.BringToFront()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If sabt Then

            CrystalReportViewer1.Size = New System.Drawing.Size(x, y)
            CrystalReportViewer1.Location = New System.Drawing.Point(1, 1)
            Button13.Location = New System.Drawing.Point(x - 115, 5)
            rpt.SetParameterValue("P1", TextBox49.Text)
            rpt.SetParameterValue("P2", TextBox1.Text)
            rpt.SetParameterValue("P3", TextBox2.Text)
            rpt.SetParameterValue("P4", ComboBox2.Text)
            rpt.SetParameterValue("P5", ComboBox3.Text)
            rpt.SetParameterValue("P6", TextBox3.Text)
            rpt.SetParameterValue("P7", TextBox4.Text)
            rpt.SetParameterValue("P8", TextBox5.Text)
            rpt.SetParameterValue("P9", ComboBox4.Text)
            rpt.SetParameterValue("P10", TextBox6.Text)
            rpt.SetParameterValue("P11", TextBox7.Text)
            rpt.SetParameterValue("P12", TextBox8.Text)
            rpt.SetParameterValue("P13", ComboBox5.Text)
            rpt.SetParameterValue("P14", TextBox9.Text)
            rpt.SetParameterValue("P15", ComboBox6.Text + "  " + TextBox10.Text + "  " + "عدد")
            rpt.SetParameterValue("P16", ComboBox7.Text + "  " + TextBox11.Text + "  " + "عدد")
            rpt.SetParameterValue("P17", ComboBox8.Text)
            rpt.SetParameterValue("P18", TextBox12.Text)
            rpt.SetParameterValue("P19", TextBox53.Text)
            rpt.SetParameterValue("P20", TextBox52.Text)
            rpt.SetParameterValue("P21", TextBox13.Text)
            rpt.SetParameterValue("P22", TextBox14.Text)
            rpt.SetParameterValue("P23", TextBox15.Text)
            rpt.SetParameterValue("P24", TextBox16.Text)
            rpt.SetParameterValue("P25", TextBox17.Text)
            rpt.SetParameterValue("P26", TextBox18.Text)
            rpt.SetParameterValue("P27", TextBox19.Text)
            rpt.SetParameterValue("P28", TextBox20.Text)
            rpt.SetParameterValue("P29", TextBox21.Text)
            rpt.SetParameterValue("P30", TextBox46.Text)
            rpt.SetParameterValue("P31", TextBox47.Text)
            rpt.SetParameterValue("P32", TextBox48.Text)
            rpt.SetParameterValue("P33", ComboBox9.Text)
            rpt.SetParameterValue("P34", TextBox22.Text)
            rpt.SetParameterValue("P35", TextBox23.Text)
            rpt.SetParameterValue("P36", TextBox24.Text)
            rpt.SetParameterValue("P37", TextBox25.Text)
            rpt.SetParameterValue("P38", ComboBox10.Text)
            rpt.SetParameterValue("P39", ComboBox11.Text)
            rpt.SetParameterValue("P40", ComboBox12.Text)
            rpt.SetParameterValue("P41", ComboBox13.Text)
            rpt.SetParameterValue("P42", TextBox26.Text)
            rpt.SetParameterValue("P43", TextBox27.Text)
            rpt.SetParameterValue("P44", TextBox28.Text)
            rpt.SetParameterValue("P45", TextBox29.Text)
            rpt.SetParameterValue("P46", TextBox30.Text)
            rpt.SetParameterValue("P47", TextBox31.Text)
            rpt.SetParameterValue("P48", TextBox32.Text)
            rpt.SetParameterValue("P49", TextBox33.Text)
            rpt.SetParameterValue("P50", TextBox34.Text)
            rpt.SetParameterValue("P51", TextBox35.Text)
            rpt.SetParameterValue("P52", ComboBox14.Text)
            rpt.SetParameterValue("P53", TextBox36.Text)
            rpt.SetParameterValue("P54", ComboBox15.Text)
            rpt.SetParameterValue("P55", TextBox37.Text)
            rpt.SetParameterValue("P56", TextBox38.Text)
            rpt.SetParameterValue("P57", TextBox39.Text)
            rpt.SetParameterValue("P58", TextBox40.Text)
            rpt.SetParameterValue("P59", TextBox41.Text)
            rpt.SetParameterValue("P60", TextBox42.Text)
            rpt.SetParameterValue("P61", TextBox43.Text)
            rpt.SetParameterValue("P62", TextBox44.Text)
            rpt.SetParameterValue("P63", TextBox45.Text)
            rpt.SetParameterValue("P", TextBox54.Text)
            CrystalReportViewer1.ReportSource = rpt

            CrystalReportViewer1.Visible = True
            CrystalReportViewer1.BringToFront()
            Button13.Visible = True
            Button13.BringToFront()
            sabt = False
        Else
            MsgBox("پروژه ای ثبت نشده است", , "پیغام")
        End If
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        sabt = False
        CrystalReportViewer1.Visible = False
        Button13.Visible = False
        Button3_Click(sender, e)
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim ocn As New System.Data.OleDb.OleDbConnection
        Dim ocm As New System.Data.OleDb.OleDbCommand
        Dim oda As New System.Data.OleDb.OleDbDataAdapter
        address = Form1.TextBox3.Text
        If RadioButton1.Checked Then
            If ComboBox17.Text = "" Then
                MsgBox("نام بخش را انتخاب کنید", , "پیغام")
            Else


                Dim dt As New DataTable

                ocn.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
            "atabase Password=" + Form14.TextBox10.Text + "")
                ocm.Connection = ocn
                If ComboBox17.Text = "کل روستاها" Then
                    ocm.CommandText = "SELECT * FROM projects"
                Else
                    ocm.CommandText = "SELECT * FROM projects where Bakhsh Like'%" & ComboBox17.Text & "%'"
                End If

                oda.SelectCommand = ocm
                oda.Fill(dt)

                GroupBox3.Visible = True
                DataGridView1.Visible = True
                DataGridView1.Size = New Size(Me.Size.Width - 25, Me.Height - 100)


                Button2.Location = New Point(15, Me.Height - 65)
                Button10.Location = New Point(180, Me.Height - 65)
                Button10.Visible = True
                Button2.Visible = True

                GroupBox3.Location = New Point(5, 5)
                GroupBox3.Size = New Size(Me.Size.Width - 10, Me.Height - 10)

                DataGridView1.DataSource = dt

                GroupBox3.BringToFront()
                DataGridView1.BringToFront()

                DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True

                DataGridView1.Columns(0).HeaderText = "تلفن"
                DataGridView1.Columns(1).HeaderText = "آبدار"
                DataGridView1.Columns(2).HeaderText = "توضیحات ضروری"
                DataGridView1.Columns(3).HeaderText = "کد اشتراک برق"
                DataGridView1.Columns(4).HeaderText = "تعداد کل خانوار مشترک"
                DataGridView1.Columns(5).HeaderText = "تعداد کل خانوار"
                DataGridView1.Columns(6).HeaderText = "تعداد شیر های تخلیه"
                DataGridView1.Columns(7).HeaderText = "تعداد شیر های هوای منصوبه"
                DataGridView1.Columns(8).HeaderText = "تعداد حوضچه های موجود "
                DataGridView1.Columns(9).HeaderText = "نوع لوله"
                DataGridView1.Columns(10).HeaderText = "طول شبکه تحت پوشش"
                DataGridView1.Columns(11).HeaderText = "حفاظات فیزیکی"
                DataGridView1.Columns(12).HeaderText = "محوطه سازی"
                DataGridView1.Columns(13).HeaderText = "مساحت تاسیسات"
                DataGridView1.Columns(14).HeaderText = "وضعیت تاسیسات"
                DataGridView1.Columns(15).HeaderText = "وضعیت اتاقکهای تاسیسات"
                DataGridView1.Columns(16).HeaderText = "قدرت تابلو برق"
                DataGridView1.Columns(17).HeaderText = "وضعیت تابلو برق"
                DataGridView1.Columns(18).HeaderText = "قدرت خازن"
                DataGridView1.Columns(19).HeaderText = "وضعیت خازن"
                DataGridView1.Columns(20).HeaderText = "نوع خازن"
                DataGridView1.Columns(21).HeaderText = "کیلووات مصرفی پمپ"
                DataGridView1.Columns(22).HeaderText = "نوع پمپ سانترفیوژ"
                DataGridView1.Columns(23).HeaderText = "کیلووات مصرفی پمپ"
                DataGridView1.Columns(24).HeaderText = "نوع پمپ شناور"
                DataGridView1.Columns(25).HeaderText = "وضعیت هوادهی"
                DataGridView1.Columns(26).HeaderText = "هوادهی"
                DataGridView1.Columns(27).HeaderText = "سیلکون"
                DataGridView1.Columns(28).HeaderText = "فیلتر"
                DataGridView1.Columns(29).HeaderText = "پی پی ام آهن"
                DataGridView1.Columns(30).HeaderText = "پی پی ام منگنز"
                DataGridView1.Columns(31).HeaderText = "تعداد مخزن کلریناتور"
                DataGridView1.Columns(32).HeaderText = "حجم کلریناتور)لیتر("
                DataGridView1.Columns(33).HeaderText = "نوع کلرزن"
                DataGridView1.Columns(34).HeaderText = "جنس لوله خط پمپاژ"
                DataGridView1.Columns(35).HeaderText = "طول خط پمپاژ"
                DataGridView1.Columns(36).HeaderText = "سایز خط پمپاژ"
                DataGridView1.Columns(37).HeaderText = "سال رنگ آمیزی مخزن"
                DataGridView1.Columns(38).HeaderText = "سایز لوله خروجی مخزن"
                DataGridView1.Columns(39).HeaderText = "سایز لوله ورودی مخزن"
                DataGridView1.Columns(40).HeaderText = "ارتفاع مخزن هوایی"
                DataGridView1.Columns(41).HeaderText = "فاصله تاسیسات تا مخزن"
                DataGridView1.Columns(42).HeaderText = "حجم مخزن هوایی"
                DataGridView1.Columns(43).HeaderText = "سایز لوله خروجی"
                DataGridView1.Columns(44).HeaderText = "سایز لوله ورودی"
                DataGridView1.Columns(45).HeaderText = "حجم مخزن زمینی"
                DataGridView1.Columns(46).HeaderText = "نوع فلوتر"
                DataGridView1.Columns(47).HeaderText = "شیر های دبی گیر"
                DataGridView1.Columns(48).HeaderText = "تعداد"
                DataGridView1.Columns(49).HeaderText = "شیرهای تخلیه"
                DataGridView1.Columns(50).HeaderText = "تعداد"
                DataGridView1.Columns(51).HeaderText = "مکان حفر چاه"
                DataGridView1.Columns(52).HeaderText = "در پوش چاه"
                DataGridView1.Columns(53).HeaderText = "سایز لوله مکش"
                DataGridView1.Columns(54).HeaderText = "سایز لوله چاه"
                DataGridView1.Columns(55).HeaderText = "اختلاف ارتفاع از سطح چاه تا پای مخزن"
                DataGridView1.Columns(56).HeaderText = "نوع سیستم"
                DataGridView1.Columns(57).HeaderText = "دبی مجاز بهره برداری"
                DataGridView1.Columns(58).HeaderText = "عمق نصب پمپ"
                DataGridView1.Columns(59).HeaderText = "عمق چاه"
                DataGridView1.Columns(60).HeaderText = "منبع تامین آب"
                DataGridView1.Columns(61).HeaderText = "کنتور جمعی"
                DataGridView1.Columns(62).HeaderText = "سال بهره برداری از تاسیسات"
                DataGridView1.Columns(63).HeaderText = "سال احداث"
                DataGridView1.Columns(64).HeaderText = "بخش"
                DataGridView1.Columns(65).HeaderText = "روستا"
                DataGridView1.Columns(66).HeaderText = "نام پروژه"


                
                DataGridView1.Columns(12).Width = "45"
                DataGridView1.Columns(13).Width = "45"
                DataGridView1.Columns(14).Width = "45"
                DataGridView1.Columns(18).Width = "45"
                DataGridView1.Columns(19).Width = "45"
                DataGridView1.Columns(26).Width = "45"
                DataGridView1.Columns(27).Width = "45"
                DataGridView1.Columns(28).Width = "45"
                DataGridView1.Columns(29).Width = "45"
                DataGridView1.Columns(30).Width = "45"
                DataGridView1.Columns(35).Width = "45"
                DataGridView1.Columns(48).Width = "32"
                DataGridView1.Columns(50).Width = "32"
                DataGridView1.Columns(52).Width = "45"
                DataGridView1.Columns(59).Width = "45"
                DataGridView1.Columns(63).Width = "45"
            End If

        ElseIf RadioButton2.Checked Then
            If TextBox55.Text = "" Then
                MsgBox("نام پروژه را وارد کنید", , "پیغام")
            Else

                Dim con As New System.Data.OleDb.OleDbConnection
                Dim strSql As String
                Dim strCon As String = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
            "atabase Password=" + Form14.TextBox10.Text + "")

                strSql = "SELECT * FROM projects where name = '" & TextBox55.Text & "'"
                con = New OleDb.OleDbConnection(strCon)
                con.Open()
                da = New OleDb.OleDbDataAdapter(strSql, con)
                If da.Fill(ds, "projects") Then
                    MsgBox("انتقال موارد یافت شده", , "پیغام")
                    TextBox1.DataBindings.Add(New Binding("Text", ds, "projects.Eyear"))
                    TextBox2.DataBindings.Add(New Binding("Text", ds, "projects.Byear"))
                    TextBox3.DataBindings.Add(New Binding("Text", ds, "projects.Omghchah"))
                    TextBox4.DataBindings.Add(New Binding("Text", ds, "projects.Omghpomp"))
                    TextBox5.DataBindings.Add(New Binding("Text", ds, "projects.DebiM"))
                    TextBox6.DataBindings.Add(New Binding("Text", ds, "projects.Ertefa"))
                    TextBox7.DataBindings.Add(New Binding("Text", ds, "projects.SLChah"))
                    TextBox8.DataBindings.Add(New Binding("Text", ds, "projects.SLMakesh"))
                    TextBox9.DataBindings.Add(New Binding("Text", ds, "projects.MakanHCh"))
                    TextBox10.DataBindings.Add(New Binding("Text", ds, "projects.Num1"))
                    TextBox11.DataBindings.Add(New Binding("Text", ds, "projects.Num2"))
                    TextBox12.DataBindings.Add(New Binding("Text", ds, "projects.Hajm1"))
                    TextBox13.DataBindings.Add(New Binding("Text", ds, "projects.Hajm2"))
                    TextBox14.DataBindings.Add(New Binding("Text", ds, "projects.Fasele"))
                    TextBox15.DataBindings.Add(New Binding("Text", ds, "projects.Ertefa"))
                    TextBox16.DataBindings.Add(New Binding("Text", ds, "projects.SLVMH"))
                    TextBox17.DataBindings.Add(New Binding("Text", ds, "projects.SLKMH"))
                    TextBox18.DataBindings.Add(New Binding("Text", ds, "projects.SRAMH"))
                    TextBox19.DataBindings.Add(New Binding("Text", ds, "projects.SKP"))
                    TextBox20.DataBindings.Add(New Binding("Text", ds, "projects.TKP"))
                    TextBox21.DataBindings.Add(New Binding("Text", ds, "projects.JLKP"))
                    TextBox22.DataBindings.Add(New Binding("Text", ds, "projects.HK"))
                    TextBox23.DataBindings.Add(New Binding("Text", ds, "projects.TMK"))
                    TextBox24.DataBindings.Add(New Binding("Text", ds, "projects.PPM2"))
                    TextBox25.DataBindings.Add(New Binding("Text", ds, "projects.PPM1"))
                    TextBox26.DataBindings.Add(New Binding("Text", ds, "projects.NPS1"))
                    TextBox27.DataBindings.Add(New Binding("Text", ds, "projects.KWMP1"))
                    TextBox28.DataBindings.Add(New Binding("Text", ds, "projects.NPS2"))
                    TextBox29.DataBindings.Add(New Binding("Text", ds, "projects.KWMP2"))
                    TextBox30.DataBindings.Add(New Binding("Text", ds, "projects.NK"))
                    TextBox31.DataBindings.Add(New Binding("Text", ds, "projects.VK"))
                    TextBox32.DataBindings.Add(New Binding("Text", ds, "projects.GK"))
                    TextBox33.DataBindings.Add(New Binding("Text", ds, "projects.VTB"))
                    TextBox34.DataBindings.Add(New Binding("Text", ds, "projects.GTB"))
                    TextBox35.DataBindings.Add(New Binding("Text", ds, "projects.otaghak"))
                    TextBox36.DataBindings.Add(New Binding("Text", ds, "projects.Masahat"))
                    TextBox37.DataBindings.Add(New Binding("Text", ds, "projects.HF"))
                    TextBox38.DataBindings.Add(New Binding("Text", ds, "projects.Tooleshabake"))
                    TextBox39.DataBindings.Add(New Binding("Text", ds, "projects.NL"))
                    TextBox40.DataBindings.Add(New Binding("Text", ds, "projects.TH"))
                    TextBox41.DataBindings.Add(New Binding("Text", ds, "projects.Shirehava"))
                    TextBox42.DataBindings.Add(New Binding("Text", ds, "projects.Shiretakhlie"))
                    TextBox43.DataBindings.Add(New Binding("Text", ds, "projects.Tk"))
                    TextBox44.DataBindings.Add(New Binding("Text", ds, "projects.TKM"))
                    TextBox45.DataBindings.Add(New Binding("Text", ds, "projects.CEB"))
                    TextBox46.DataBindings.Add(New Binding("Text", ds, "projects.Abdar"))
                    TextBox47.DataBindings.Add(New Binding("Text", ds, "projects.Tel1"))
                    TextBox48.DataBindings.Add(New Binding("Text", ds, "projects.bishtar"))
                    TextBox49.DataBindings.Add(New Binding("Text", ds, "projects.Roostaha"))
                    TextBox52.DataBindings.Add(New Binding("Text", ds, "projects.SLK"))
                    TextBox53.DataBindings.Add(New Binding("Text", ds, "projects.SLV"))
                    TextBox54.DataBindings.Add(New Binding("Text", ds, "projects.name"))
                    ComboBox2.DataBindings.Add(New Binding("Text", ds, "projects.count1"))
                    ComboBox3.DataBindings.Add(New Binding("Text", ds, "projects.manba"))
                    ComboBox4.DataBindings.Add(New Binding("Text", ds, "projects.NS"))
                    ComboBox5.DataBindings.Add(New Binding("Text", ds, "projects.darpoosh"))
                    ComboBox6.DataBindings.Add(New Binding("Text", ds, "projects.shtakhlie"))
                    ComboBox7.DataBindings.Add(New Binding("Text", ds, "projects.shdebi"))
                    ComboBox8.DataBindings.Add(New Binding("Text", ds, "projects.floter1"))
                    ComboBox9.DataBindings.Add(New Binding("Text", ds, "projects.NKZ"))
                    ComboBox10.DataBindings.Add(New Binding("Text", ds, "projects.filter1"))
                    ComboBox11.DataBindings.Add(New Binding("Text", ds, "projects.siklon"))
                    ComboBox12.DataBindings.Add(New Binding("Text", ds, "projects.HD"))
                    ComboBox13.DataBindings.Add(New Binding("Text", ds, "projects.VHD"))
                    ComboBox14.DataBindings.Add(New Binding("Text", ds, "projects.vazeiat"))
                    ComboBox15.DataBindings.Add(New Binding("Text", ds, "projects.mohavatesazi"))
                    sabt = True
                    TextBox1.DataBindings.Clear()
                    TextBox2.DataBindings.Clear()
                    TextBox3.DataBindings.Clear()
                    TextBox4.DataBindings.Clear()
                    TextBox5.DataBindings.Clear()
                    TextBox6.DataBindings.Clear()
                    TextBox7.DataBindings.Clear()
                    TextBox8.DataBindings.Clear()
                    TextBox9.DataBindings.Clear()
                    TextBox10.DataBindings.Clear()
                    TextBox11.DataBindings.Clear()
                    TextBox12.DataBindings.Clear()
                    TextBox13.DataBindings.Clear()
                    TextBox14.DataBindings.Clear()
                    TextBox15.DataBindings.Clear()
                    TextBox16.DataBindings.Clear()
                    TextBox17.DataBindings.Clear()
                    TextBox18.DataBindings.Clear()
                    TextBox19.DataBindings.Clear()
                    TextBox20.DataBindings.Clear()
                    TextBox21.DataBindings.Clear()
                    TextBox22.DataBindings.Clear()
                    TextBox23.DataBindings.Clear()
                    TextBox24.DataBindings.Clear()
                    TextBox25.DataBindings.Clear()
                    TextBox26.DataBindings.Clear()
                    TextBox27.DataBindings.Clear()
                    TextBox28.DataBindings.Clear()
                    TextBox29.DataBindings.Clear()
                    TextBox30.DataBindings.Clear()
                    TextBox31.DataBindings.Clear()
                    TextBox32.DataBindings.Clear()
                    TextBox33.DataBindings.Clear()
                    TextBox34.DataBindings.Clear()
                    TextBox35.DataBindings.Clear()
                    TextBox36.DataBindings.Clear()
                    TextBox37.DataBindings.Clear()
                    TextBox38.DataBindings.Clear()
                    TextBox39.DataBindings.Clear()
                    TextBox40.DataBindings.Clear()
                    TextBox41.DataBindings.Clear()
                    TextBox42.DataBindings.Clear()
                    TextBox43.DataBindings.Clear()
                    TextBox44.DataBindings.Clear()
                    TextBox45.DataBindings.Clear()
                    TextBox46.DataBindings.Clear()
                    TextBox47.DataBindings.Clear()
                    TextBox48.DataBindings.Clear()
                    TextBox49.DataBindings.Clear()
                    TextBox52.DataBindings.Clear()
                    TextBox53.DataBindings.Clear()
                    TextBox54.DataBindings.Clear()
                    ComboBox2.DataBindings.Clear()
                    ComboBox3.DataBindings.Clear()
                    ComboBox4.DataBindings.Clear()
                    ComboBox5.DataBindings.Clear()
                    ComboBox6.DataBindings.Clear()
                    ComboBox7.DataBindings.Clear()
                    ComboBox8.DataBindings.Clear()
                    ComboBox9.DataBindings.Clear()
                    ComboBox10.DataBindings.Clear()
                    ComboBox11.DataBindings.Clear()
                    ComboBox12.DataBindings.Clear()
                    ComboBox13.DataBindings.Clear()
                    ComboBox14.DataBindings.Clear()
                    ComboBox15.DataBindings.Clear()
                Else
                    MsgBox("پروژه مورد نظر یافت نشد", , "پیغام")
                End If
            End If
        End If



        DataGridView1.Visible = True
    End Sub

    Private Sub ComboBox16_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox16.Click
        Label1.Text = "ابتدا بخش را وارد کنید"
    End Sub

    Private Sub ComboBox16_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox16.DropDown
        test = True
        Label1.Text = "ابتدا بخش را وارد کنید"
    End Sub

    Private Sub ComboBox16_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox16.SelectedIndexChanged
        If Not test Then
            Exit Sub
        Else
            Dim ocn As New System.Data.OleDb.OleDbConnection
            Dim ocm As New System.Data.OleDb.OleDbCommand
            Dim oda As New System.Data.OleDb.OleDbDataAdapter
            Dim ds As New DataSet()

            ComboBox1.Items.Clear()
            ComboBox1.Text = ""
            If Not ComboBox16.SelectedItem = "کل روستاها" Then


                ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\Data.mdb"
                ocm.Connection = ocn
                ocm.CommandText = "SELECT roosta FROM Roostaha where bakhsh='" & ComboBox16.SelectedItem & "'"
                oda.SelectCommand = ocm
                da = New OleDbDataAdapter(ocm.CommandText, ocn)
                da.Fill(ds, "Roostaha")

                Do
                    TextBox56.Text = TextBox57.Text
                    TextBox57.DataBindings.Add(New Binding("Text", ds, "Roostaha.roosta"))
                    ComboBox1.Items.Add(TextBox57.Text)
                    Me.BindingContext(ds, "Roostaha").Position += 1
                    TextBox57.DataBindings.Clear()
                    If TextBox57.Text = TextBox56.Text Then
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
                    TextBox56.Text = TextBox57.Text
                    TextBox57.DataBindings.Add(New Binding("Text", ds, "Roostaha.roosta"))
                    ComboBox1.Items.Add(TextBox57.Text)
                    Me.BindingContext(ds, "Roostaha").Position += 1
                    TextBox57.DataBindings.Clear()
                    If TextBox57.Text = TextBox56.Text Then
                        Exit Do
                    End If
                Loop
                oda.Dispose()
                ocm.Dispose()
                ocn.Dispose()
            End If
        End If
        ComboBox16.Visible = False
        Label1.Text = "اکنون نام روستا را انتخاب کنید"
    End Sub


    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Label1.Text = "روستای تحت پوشش"
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
        ComboBox16.DataBindings.Add(New Binding("text", ds, "Roostaha.bakhsh"))
        ComboBox16.DataBindings.Clear()
        oda.Dispose()
        ocm.Dispose()
        ocn.Dispose()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        GroupBox3.Visible = False
        GroupBox3.SendToBack()
        ComboBox17.Text = ""
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
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

    Private Sub Button8_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        ComboBox16.Text = ""
        ComboBox16.Visible = True
        ComboBox1.Text = ""
        ComboBox1.Visible = False
    End Sub
End Class