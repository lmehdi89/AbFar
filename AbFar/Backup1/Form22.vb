Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Public Class Form22
    Public address As String
    Public f As Boolean = True
    Public test As Boolean = True
    Public allow As Boolean = False
    Public y As Integer
    Public x As Integer
    Public c As Integer = 1
    Dim i As Integer
    Dim rpt As New CrystalReport19
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
            TextBox4.DataBindings.Add(New Binding("Text", ds, "Form.Ostan"))
            TextBox8.DataBindings.Add(New Binding("Text", ds, "Form.Ostan"))
            TextBox3.DataBindings.Add(New Binding("Text", ds, "Form.Shahr"))
            TextBox5.DataBindings.Add(New Binding("Text", ds, "Form.Shahr"))
            TextBox10.DataBindings.Add(New Binding("Text", ds, "Form.Shahr"))
            TextBox9.DataBindings.Add(New Binding("Text", ds, "Form.Name"))
            TextBox11.DataBindings.Add(New Binding("Text", ds, "Form.Address"))

            oda.Dispose()
            ocm.Dispose()
            ocn.Dispose()
            GroupBox2.Visible = True
            f = False
            TextBox2.ReadOnly = True
            TextBox2.BackColor = Color.White
            TextBox3.ReadOnly = True
            TextBox3.BackColor = Color.White
            TextBox4.ReadOnly = True
            TextBox4.BackColor = Color.White
            TextBox5.ReadOnly = True
            TextBox5.BackColor = Color.White
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

    Private Sub Form22_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        y = Me.Size.Height
        x = Me.Size.Width

        Toshamsi()
        TextBox1.ReadOnly = True
        TextBox12.ReadOnly = True
        TextBox13.ReadOnly = True
        TextBox1.BackColor = Color.White
        TextBox12.BackColor = Color.White
        TextBox13.BackColor = Color.White

        GroupBox1.Location = New System.Drawing.Point((x / 2) + 150, (y / 10))
        GroupBox2.Location = New System.Drawing.Point(5, y / 20)
        Button1.Location = New System.Drawing.Point((x / 2) + 150, (y / 10) + 320)
        Button48.Location = New System.Drawing.Point(5, (y / 20) - 20)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim ocm As New System.Data.OleDb.OleDbCommand
        Dim oda As New System.Data.OleDb.OleDbDataAdapter
        Dim ocn As New System.Data.OleDb.OleDbConnection

        If TextBox34.Text = "" Or ComboBox1.Text = "" Or ComboBox2.Text = "" Or TextBox29.Text = "" Or TextBox30.Text = "" Then
            MsgBox("نقص در اطلاعات ورودی", , "پیغام")

        ElseIf (TextBox33.Text = "سال" Or TextBox33.Text = "") Or (ComboBox10.Text = "ماه" Or ComboBox11.Text = "روز") Then
            MsgBox("نقص در تاریخ ورودی", , "پیغام")
        Else

            TextBox7.Text = TextBox34.Text
            TextBox34.Enabled = False
            TextBox35.Text = TextBox33.Text + "/" + ComboBox10.Text + "/" + ComboBox11.Text
            ListBox2.Items.Add(ComboBox1.Text)
            ListBox3.Items.Add(TextBox29.Text)
            ListBox4.Items.Add(ComboBox2.Text)
            ListBox5.Items.Add(TextBox30.Text)
            ListBox6.Items.Add(TextBox31.Text)
            ListBox7.Items.Add(TextBox35.Text)
            ListBox8.Items.Add(TextBox32.Text)

            address = Form1.TextBox3.Text
            ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
            "atabase Password=" + Form14.TextBox10.Text + ""
            ocm.Connection = ocn
            ocm.CommandText = "INSERT INTO GozareshOS (bish,Y,M,D,sharh,nKH,roosta,Pname,bakhsh,num) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)"
            ocm.Parameters.Clear()
            ocm.Parameters.AddWithValue("@p1", TextBox32.Text)
            ocm.Parameters.AddWithValue("@p2", TextBox33.Text)
            ocm.Parameters.AddWithValue("@p3", ComboBox10.Text)
            ocm.Parameters.AddWithValue("@p4", ComboBox11.Text)
            ocm.Parameters.AddWithValue("@p5", TextBox31.Text)
            ocm.Parameters.AddWithValue("@p6", TextBox30.Text)
            ocm.Parameters.AddWithValue("@p7", ComboBox2.Text)
            ocm.Parameters.AddWithValue("@p8", TextBox29.Text)
            ocm.Parameters.AddWithValue("@p9", ComboBox1.Text)
            ocm.Parameters.AddWithValue("@p10", "1")
            ocn.Open()
            ocm.ExecuteNonQuery()
            ocn.Close()
            ocm.Dispose()
            ocn.Dispose()
            ComboBox1.Text = ""
            TextBox29.Text = ""
            ComboBox2.Text = ""
            TextBox30.Text = ""
            TextBox31.Text = ""
            TextBox35.Text = ""
            TextBox32.Text = ""
            TextBox33.Text = "سال"
            ComboBox10.Text = "ماه"
            ComboBox11.Text = "روز"
            allow = True
            c = c + 1
        End If
    End Sub

   
    Private Sub TextBox33_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox33.Click
        TextBox33.Text = ""
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
            TextBox38.Text = TextBox36.Text
            TextBox36.DataBindings.Add(New Binding("Text", ds, "Roostaha.roosta"))
            ComboBox2.Items.Add(TextBox36.Text)
            Me.BindingContext(ds, "Roostaha").Position += 1
            TextBox36.DataBindings.Clear()
            If TextBox36.Text = TextBox38.Text Then
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

    Private Sub ComboBox1_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.DropDown
        test = True
    End Sub

    Private Sub ComboBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboBox1.KeyDown
        e.SuppressKeyPress = True
    End Sub

    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox1.KeyPress
        e.Handled = True
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
                    TextBox38.Text = TextBox36.Text
                    TextBox36.DataBindings.Add(New Binding("Text", ds, "Roostaha.roosta"))
                    ComboBox2.Items.Add(TextBox36.Text)
                    Me.BindingContext(ds, "Roostaha").Position += 1
                    TextBox36.DataBindings.Clear()
                    If TextBox36.Text = TextBox38.Text Then
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
                    TextBox38.Text = TextBox36.Text
                    TextBox36.DataBindings.Add(New Binding("Text", ds, "Roostaha.roosta"))
                    ComboBox2.Items.Add(TextBox36.Text)
                    Me.BindingContext(ds, "Roostaha").Position += 1
                    TextBox36.DataBindings.Clear()
                    If TextBox36.Text = TextBox38.Text Then
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

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If allow Then
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
                ocm.CommandText = "update GozareshOS SET NUM=0"
                ocn.Open()
                ocm.ExecuteNonQuery()
                ocn.Close()
                ocm.Dispose()
                ocn.Dispose()
                ListBox2.Items.Clear()
                ListBox3.Items.Clear()
                ListBox4.Items.Clear()
                ListBox5.Items.Clear()
                ListBox6.Items.Clear()
                ListBox7.Items.Clear()
                ListBox8.Items.Clear()
                ComboBox1.Text = ""
                TextBox29.Text = ""
                ComboBox2.Text = ""
                TextBox30.Text = ""
                TextBox31.Text = ""
                TextBox35.Text = ""
                TextBox32.Text = ""
                TextBox33.Text = "سال"
                ComboBox10.Text = "ماه"
                ComboBox11.Text = "روز"
                allow = False
                c = 1
            ElseIf result = MsgBoxResult.No Then
                address = Form1.TextBox3.Text
                Dim ocn As New System.Data.OleDb.OleDbConnection
                Dim ocm As New System.Data.OleDb.OleDbCommand
                Dim oda As New System.Data.OleDb.OleDbDataAdapter
                Dim ds As New DataSet()

                ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
            "atabase Password=" + Form14.TextBox10.Text + ""
                ocm.Connection = ocn
                ocm.CommandText = "DELETE FROM GozareshOS WHERE NUM >'" & 0 & "'"
                ocn.Open()
                ocm.ExecuteNonQuery()
                ocn.Close()
                ocm.Dispose()
                ocn.Dispose()
                ListBox2.Items.Clear()
                ListBox3.Items.Clear()
                ListBox4.Items.Clear()
                ListBox5.Items.Clear()
                ListBox6.Items.Clear()
                ListBox7.Items.Clear()
                ListBox8.Items.Clear()
                ComboBox1.Text = ""
                TextBox29.Text = ""
                ComboBox2.Text = ""
                TextBox30.Text = ""
                TextBox31.Text = ""
                TextBox35.Text = ""
                TextBox32.Text = ""
                TextBox33.Text = "سال"
                ComboBox10.Text = "ماه"
                ComboBox11.Text = "روز"
                allow = False
                c = 1
            End If
        Else
            MsgBox("شما مجاز به ایجاد گزارش جدید نیستید", , "پیغام")
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If c = 1 Then
            MsgBox("گزارشی ثبت نشده است", , "پیغام")
        Else
            CrystalReportViewer1.Size = New System.Drawing.Size(x, y)
            CrystalReportViewer1.Location = New System.Drawing.Point(1, 1)
            Button13.Location = New System.Drawing.Point(x - 115, 5)

            For i = 0 To c - 2
                TextBox37.Text += ListBox2.Items.Item(i) & vbCrLf
                TextBox39.Text += ListBox3.Items.Item(i) & vbCrLf
                TextBox40.Text += ListBox4.Items.Item(i) & vbCrLf
                TextBox41.Text += ListBox5.Items.Item(i) & vbCrLf
                TextBox42.Text += ListBox6.Items.Item(i) & vbCrLf
                TextBox43.Text += ListBox7.Items.Item(i) & vbCrLf
                TextBox44.Text += ListBox8.Items.Item(i) & vbCrLf
            Next i
            TextBox45.Text = TextBox13.Text + "/" + TextBox12.Text + "/" + TextBox1.Text
            rpt.SetParameterValue("s1", TextBox45.Text)
            rpt.SetParameterValue("s2", TextBox2.Text)
            rpt.SetParameterValue("s3", TextBox3.Text)
            rpt.SetParameterValue("s4", TextBox7.Text)
            rpt.SetParameterValue("s5", TextBox2.Text)
            rpt.SetParameterValue("s6", TextBox2.Text)
            rpt.SetParameterValue("s7", TextBox3.Text)
            rpt.SetParameterValue("s8", TextBox9.Text)
            rpt.SetParameterValue("s9", TextBox3.Text)
            rpt.SetParameterValue("s10", TextBox37.Text)
            rpt.SetParameterValue("s11", TextBox39.Text)
            rpt.SetParameterValue("s12", TextBox40.Text)
            rpt.SetParameterValue("s13", TextBox41.Text)
            rpt.SetParameterValue("s14", TextBox42.Text)
            rpt.SetParameterValue("s15", TextBox43.Text)
            rpt.SetParameterValue("s16", TextBox44.Text)
            rpt.SetParameterValue("s17", TextBox11.Text)
            CrystalReportViewer1.ReportSource = rpt

            CrystalReportViewer1.Visible = True
            CrystalReportViewer1.BringToFront()
            Button13.Visible = True
            Button13.BringToFront()
            TextBox37.Text = ""
            TextBox39.Text = ""
            TextBox40.Text = ""
            TextBox41.Text = ""
            TextBox42.Text = ""
            TextBox43.Text = ""
            TextBox44.Text = ""

            address = Form1.TextBox3.Text
            Dim ocn As New System.Data.OleDb.OleDbConnection
            Dim ocm As New System.Data.OleDb.OleDbCommand
            Dim oda As New System.Data.OleDb.OleDbDataAdapter
            Dim ds As New DataSet()

            ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
        "atabase Password=" + Form14.TextBox10.Text + ""
            ocm.Connection = ocn
            ocm.CommandText = "update GozareshOS SET NUM=0"
            ocn.Open()
            ocm.ExecuteNonQuery()
            ocn.Close()
            ocm.Dispose()
            ocn.Dispose()
            ListBox2.Items.Clear()
            ListBox3.Items.Clear()
            ListBox4.Items.Clear()
            ListBox5.Items.Clear()
            ListBox6.Items.Clear()
            ListBox7.Items.Clear()
            ListBox8.Items.Clear()
            ComboBox1.Text = ""
            TextBox29.Text = ""
            ComboBox2.Text = ""
            TextBox30.Text = ""
            TextBox31.Text = ""
            TextBox35.Text = ""
            TextBox32.Text = ""
            TextBox33.Text = "سال"
            ComboBox10.Text = "ماه"
            ComboBox11.Text = "روز"
            c = 1
            allow = False
        End If
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        CrystalReportViewer1.Visible = False
        Button13.Visible = False
    End Sub

    Private Sub TextBox33_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox33.KeyPress
        If Not IsNumeric(e.KeyChar) And e.KeyChar <> Convert.ToChar(Keys.Back) And e.KeyChar <> Convert.ToChar(Keys.Delete) Then
            e.Handled = True
        End If
    End Sub
End Class