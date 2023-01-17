Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Public Class Form8
    Public address As String
    Private da As OleDbDataAdapter
    Dim test As Boolean = False
    Dim num As Integer = 1
    Dim mony As Int64 = 0
    Dim i As Integer = 0
    Dim count As Integer = 0
    Public y As Integer
    Public c As Integer = 0
    Public BL As Boolean = False
    Public f As Boolean = True
    Public t As Boolean = True
    Public x As Integer
    Public rpt As New CrystalReport11



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
        TextBox16.Text = d
        TextBox28.Text = m
        TextBox29.Text = y
        Return 0
    End Function
    Private Sub Form8_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If Form14.man Then
                y = Me.Size.Height
                x = Me.Size.Width
                GroupBox4.Location = New System.Drawing.Point((x / 2), (y / 20))
                Button26.Location = New System.Drawing.Point((x / 2), (y / 20) + 625)
                Button26.Enabled = False
                Button27.Location = New System.Drawing.Point((x / 2), (y / 20) + 665)
                Button27.Enabled = True
                GroupBox6.Location = New System.Drawing.Point(45, y / 10)
                Button48.Location = New System.Drawing.Point(10, y / 10)
            Else
                y = Me.Size.Height
                x = Me.Size.Width
                GroupBox4.Location = New System.Drawing.Point((x / 2), (y / 20))
                Button26.Location = New System.Drawing.Point((x / 2), (y / 20) + 625)
                Button27.Location = New System.Drawing.Point((x / 2), (y / 20) + 665)
                GroupBox6.Location = New System.Drawing.Point(45, y / 10)
                Button48.Location = New System.Drawing.Point(10, y / 10)
                Me.TextBox4.Text = Form7.Label18.Text
                TextBox17.Text = TextBox4.Text
                TextBox4.ReadOnly = False
                TextBox4.BackColor = Color.White
                TextBox17.Enabled = False

                Call Toshamsi()
                address = Form1.TextBox3.Text
                TextBox3.Text = TextBox29.Text + "/" + TextBox28.Text + "/" + TextBox16.Text
                Dim da As New OleDbDataAdapter
                Dim ds As New DataSet
                Dim strSql As String
                Dim strCon As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + ""
                Dim con As OleDb.OleDbConnection
                strSql = "SELECT * FROM Darkhast where ID='" & TextBox4.Text & "'"
                con = New OleDb.OleDbConnection(strCon)
                con.Open()
                da = New OleDb.OleDbDataAdapter(strSql, con)
                da.Fill(ds, "Darkhast")
                TextBox24.DataBindings.Add(New Binding("Text", ds, "Darkhast.name"))
                For i = 1 To TextBox32.Text
                    ListBox1.Items.Add(TextBox24.Text)
                    Me.BindingContext(ds, "Darkhast").Position += 1
                Next i
                TextBox24.DataBindings.Clear()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
       
    End Sub

    Private Sub Button22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button22.Click
        Try
            If TextBox22.Text = "" Or TextBox20.Text = "" Then
                MsgBox("اطلاعات ورودی ناقص است", , "پیغام")
            Else
                test = False
                address = Form1.TextBox3.Text
                Dim ocm As New System.Data.OleDb.OleDbCommand
                Dim oda As New System.Data.OleDb.OleDbDataAdapter
                Dim ocn As New System.Data.OleDb.OleDbConnection
                count += 1
                ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + ""
                ocm.Connection = ocn
                ocm.CommandText = "INSERT INTO Kharid (bishtar,mony2,mony1,unit,tedad,name,Y,M,D,ID,NUM) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)"
                ocm.Parameters.Clear()
                ocm.Parameters.AddWithValue("@p1", TextBox18.Text)
                If Not TextBox19.Text = "" Then
                    ocm.Parameters.AddWithValue("@p2", ((Convert.ToInt64(TextBox19.Text)) * (Convert.ToInt64(TextBox22.Text))))
                Else
                    ocm.Parameters.AddWithValue("@p2", "")
                End If
                ocm.Parameters.AddWithValue("@p3", TextBox19.Text)
                ocm.Parameters.AddWithValue("@p4", TextBox20.Text)
                ocm.Parameters.AddWithValue("@p5", TextBox22.Text)
                ocm.Parameters.AddWithValue("@p6", ListBox1.SelectedItem)
                ocm.Parameters.AddWithValue("@p7", TextBox29.Text)
                ocm.Parameters.AddWithValue("@p8", TextBox28.Text)
                ocm.Parameters.AddWithValue("@p9", TextBox16.Text)
                ocm.Parameters.AddWithValue("@p10", TextBox17.Text)
                ocm.Parameters.AddWithValue("@p11", count)
                ocn.Open()
                ocm.ExecuteNonQuery()
                ocn.Close()
                ocm.Dispose()
                ocn.Dispose()
                If Not TextBox19.Text = "" Then
                    mony += ((Convert.ToInt64(TextBox19.Text)) * (Convert.ToInt64(TextBox22.Text)))
                End If

                ListBox2.Items.Add(ListBox1.SelectedItem)
                ListBox3.Items.Add(TextBox22.Text)
                ListBox4.Items.Add(TextBox20.Text)
                ListBox5.Items.Add(TextBox19.Text)
                If Not TextBox19.Text = "" Then
                    ListBox6.Items.Add(Convert.ToString((Convert.ToInt64(TextBox19.Text)) * (Convert.ToInt64(TextBox22.Text))))
                Else
                    ListBox6.Items.Add(" ")
                End If
                ListBox7.Items.Add(TextBox18.Text)
                ListBox1.Items.Remove(ListBox1.SelectedItem)
                TextBox19.Text = ""
                TextBox22.Text = ""
                TextBox20.Text = ""
                TextBox18.Text = ""
                TextBox5.ReadOnly = False
                TextBox5.Text = Convert.ToString(mony)
                TextBox5.ReadOnly = True
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
       
    End Sub

    Private Sub Button45_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button45.Click
        If GroupBox2.Visible Then
            GroupBox2.Visible = False
        Else
            GroupBox2.Visible = True
        End If
    End Sub

    Private Sub Button46_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button46.Click
        If GroupBox3.Visible Then
            GroupBox3.Visible = False
        Else
            GroupBox3.Visible = True
        End If
    End Sub

    Private Sub Button47_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button47.Click
        Try
            If Not GroupBox5.Visible And t Then
                Dim ocn As New System.Data.OleDb.OleDbConnection
                Dim ocm As New System.Data.OleDb.OleDbCommand
                Dim oda As New System.Data.OleDb.OleDbDataAdapter
                Dim ds As New DataSet()

                ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\Data.mdb"
                ocm.Connection = ocn
                ocm.CommandText = "SELECT name FROM Kala"
                oda.SelectCommand = ocm
                da = New OleDbDataAdapter(ocm.CommandText, ocn)
                da.Fill(ds, "Kala")

                Do
                    TextBox15.Text = TextBox14.Text
                    TextBox14.DataBindings.Add(New Binding("Text", ds, "Kala.name"))
                    ComboBox1.Items.Add(TextBox14.Text)
                    Me.BindingContext(ds, "Kala").Position += 1
                    TextBox14.DataBindings.Clear()
                    If TextBox14.Text = TextBox15.Text Then
                        Exit Do
                    End If
                Loop

                oda.Dispose()
                ocm.Dispose()
                ocn.Dispose()
                t = False
                GroupBox5.Visible = True
            ElseIf Not GroupBox5.Visible Then
                GroupBox5.Visible = True
            Else
                GroupBox5.Visible = False
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
        
    End Sub

    Private Sub Button48_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button48.Click
        Try
            If Not GroupBox6.Visible And f Then
                address = Form1.TextBox3.Text
                Dim ds As New DataSet()
                Dim strSql As String
                Dim strCon As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + ""
                Dim da As OleDb.OleDbDataAdapter
                Dim con As OleDb.OleDbConnection
                strSql = "select Ostan,Shahr from Form"
                con = New OleDb.OleDbConnection(strCon)
                con.Open()
                da = New OleDb.OleDbDataAdapter(strSql, con)
                da.Fill(ds, "Form")

                TextBox1.DataBindings.Add(New Binding("Text", ds, "Form.Ostan"))
                TextBox2.DataBindings.Add(New Binding("Text", ds, "Form.Shahr"))
                GroupBox6.Visible = True
                f = False

            ElseIf Not GroupBox6.Visible() Then
                GroupBox6.Visible = True
            Else
                GroupBox6.Visible = False
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
        
    End Sub

    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click
        Try
            DataGridView1.Refresh()
            Dim ocn As New System.Data.OleDb.OleDbConnection
            Dim ocm As New System.Data.OleDb.OleDbCommand
            Dim oda As New System.Data.OleDb.OleDbDataAdapter
            Dim dt As New DataTable

            If RadioButton3.Checked Then

                address = Form1.TextBox3.Text
                ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + ""
                ocm.Connection = ocn
                ocm.CommandText = "SELECT bishtar,mony2,mony1,unit,tedad,name,Y,M,D,ID FROM Kharid where name ='" & ComboBox2.Text & "'"
                oda.SelectCommand = ocm
                oda.Fill(dt)
                DataGridView1.DataSource = dt

                DataGridView1.Columns(0).HeaderText = "توضیحات"
                DataGridView1.Columns(1).HeaderText = "برآورد قیمت کل"
                DataGridView1.Columns(2).HeaderText = "برآورد قیمت واحد"
                DataGridView1.Columns(3).HeaderText = "واحد کالا"
                DataGridView1.Columns(4).HeaderText = "تعداد"
                DataGridView1.Columns(5).HeaderText = "نام کالا"
                DataGridView1.Columns(6).HeaderText = "سال"
                DataGridView1.Columns(6).Width = 64
                DataGridView1.Columns(7).HeaderText = "ماه"
                DataGridView1.Columns(8).Width = 25
                DataGridView1.Columns(8).HeaderText = "روز"
                DataGridView1.Columns(8).Width = 25
                DataGridView1.Columns(9).HeaderText = "شماره درخواست"

                dt.Dispose()
                oda.Dispose()
                ocm.Dispose()
                ocn.Dispose()
            Else
                address = Form1.TextBox3.Text
                ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + ""
                ocm.Connection = ocn
                ocm.CommandText = "SELECT bishtar,mony2,mony1,unit,tedad,name,Y,M,D,ID FROM Kharid where ID ='" & TextBox12.Text & "'"
                oda.SelectCommand = ocm
                oda.Fill(dt)
                DataGridView1.DataSource = dt

                DataGridView1.Columns(0).HeaderText = "توضیحات"
                DataGridView1.Columns(1).HeaderText = "برآورد قیمت کل"
                DataGridView1.Columns(2).HeaderText = "برآورد قیمت واحد"
                DataGridView1.Columns(3).HeaderText = "واحد کالا"
                DataGridView1.Columns(4).HeaderText = "تعداد"
                DataGridView1.Columns(5).HeaderText = "نام کالا"
                DataGridView1.Columns(6).HeaderText = "سال"
                DataGridView1.Columns(6).Width = 64
                DataGridView1.Columns(7).HeaderText = "ماه"
                DataGridView1.Columns(7).Width = 25
                DataGridView1.Columns(8).HeaderText = "روز"
                DataGridView1.Columns(8).Width = 25
                DataGridView1.Columns(9).HeaderText = "شماره درخواست"

                DataGridView1.Visible = True

                dt.Dispose()
                oda.Dispose()
                ocm.Dispose()
                ocn.Dispose()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
        
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
    Private Sub Button28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        GroupBox4.Enabled = True
        GroupBox6.Enabled = True
        Button27.Enabled = True
        Button26.Enabled = True
        Button48.Enabled = True
    End Sub

    Private Sub Button27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button27.Click
        Try
            Dim ocn As New System.Data.OleDb.OleDbConnection
            Dim ocm As New System.Data.OleDb.OleDbCommand
            Dim oda As New System.Data.OleDb.OleDbDataAdapter
            Dim ds As New DataSet()
            address = Form1.TextBox3.Text
            ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + ""
            ocm.Connection = ocn
            ocm.CommandText = "update Darkhast SET NUM=0"
            ocn.Open()
            ocm.ExecuteNonQuery()
            ocn.Close()
            ocm.Dispose()
            ocn.Dispose()
            Close()
            Form7.Close()
            Form14.man = False
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
        
    End Sub

    Private Sub Button26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button26.Click
        Form7.Show()
        Form7.BringToFront()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        Try
            Dim ocn As New System.Data.OleDb.OleDbConnection
            Dim ocm As New System.Data.OleDb.OleDbCommand
            Dim oda As New System.Data.OleDb.OleDbDataAdapter
            Dim ds As New DataSet()

            ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\Data.mdb"
            ocm.Connection = ocn
            ocm.CommandText = "SELECT * FROM Kala where name='" & ListBox1.SelectedItem & "'"
            oda.SelectCommand = ocm
            da = New OleDbDataAdapter(ocm.CommandText, ocn)
            da.Fill(ds, "Kala")
            TextBox20.Enabled = True
            TextBox20.DataBindings.Add(New Binding("Text", ds, "Kala.unit"))
            TextBox20.DataBindings.Clear()
            TextBox20.Enabled = False

            oda.Dispose()
            ocm.Dispose()
            ocn.Dispose()
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
       
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            ListBox1.Items.Clear()
            Dim da As New OleDbDataAdapter
            Dim ds As New DataSet
            Dim strSql As String
            Dim strCon As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\Data.mdb"
            Dim con As OleDb.OleDbConnection
            strSql = "SELECT * FROM Darkhast where ID='" & TextBox4.Text & "'"
            con = New OleDb.OleDbConnection(strCon)
            con.Open()
            da = New OleDb.OleDbDataAdapter(strSql, con)
            da.Fill(ds, "Darkhast")
            TextBox24.DataBindings.Add(New Binding("Text", ds, "Darkhast.name"))
            For i = 1 To TextBox32.Text
                ListBox1.Items.Add(TextBox24.Text)
                Me.BindingContext(ds, "Darkhast").Position += 1
            Next i
            TextBox24.DataBindings.Clear()
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
        
    End Sub

    Private Sub Button23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button23.Click
        Try
            If TextBox13.Text = "" Then
                MsgBox("شماره درخواست را وارد کنید", , "پیغام")
            Else
                address = Form1.TextBox3.Text
                Dim ocn As New System.Data.OleDb.OleDbConnection
                Dim ocm As New System.Data.OleDb.OleDbCommand
                Dim oda As New System.Data.OleDb.OleDbDataAdapter
                Dim dt As New DataTable

                ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + ""
                ocm.Connection = ocn
                ocm.CommandText = "SELECT * FROM Kharid where Num ='" & TextBox13.Text & "'"
                oda.SelectCommand = ocm
                If oda.Fill(dt) Then
                    Button23.Visible = False
                    Button24.Visible = True
                    Button25.Visible = True
                    Button25.Enabled = True
                    dt.Dispose()
                    oda.Dispose()
                    ocm.Dispose()
                    ocn.Dispose()
                Else
                    Label19.Visible = True
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

    Private Sub Button24_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button24.Click
        Button23.Visible = True
        Button24.Visible = False
        Button25.Visible = False
        Button25.Enabled = False
    End Sub

    Private Sub Button25_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button25.Click
        Try
            If TextBox13.Text = "" Or ComboBox1.SelectedItem = "" Then
                MsgBox("مقادیر فیلدها را وارد کنید", , "پیغام")
            Else
                address = Form1.TextBox3.Text
                Dim ocn As New System.Data.OleDb.OleDbConnection
                Dim ocm As New System.Data.OleDb.OleDbCommand
                Dim oda As New System.Data.OleDb.OleDbDataAdapter
                Dim dt As New DataTable

                ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + ""
                ocm.Connection = ocn
                ocm.CommandText = "DELETE FROM Kharid where ID =@p10 and name =@p6"
                ocm.Parameters.Clear()
                ocm.Parameters.AddWithValue("@p6", ComboBox1.Text)
                ocm.Parameters.AddWithValue("@p10", TextBox1.Text)
                ocn.Open()
                ocm.ExecuteNonQuery()
                ocn.Close()
                ocm.Dispose()
                ocn.Dispose()

                Dim list As Integer = ListBox2.Items.IndexOf(ComboBox1.SelectedItem)
                ListBox2.SelectedIndex = list
                ListBox3.SelectedIndex = list
                ListBox4.SelectedIndex = list
                ListBox5.SelectedIndex = list
                ListBox6.SelectedIndex = list
                ListBox7.SelectedIndex = list
                mony -= Convert.ToInt64(ListBox6.SelectedItem)
                ListBox2.Items.Remove(ListBox2.SelectedItem)
                ListBox3.Items.Remove(ListBox3.SelectedItem)
                ListBox4.Items.Remove(ListBox4.SelectedItem)
                ListBox5.Items.Remove(ListBox5.SelectedItem)
                ListBox6.Items.Remove(ListBox6.SelectedItem)
                ListBox7.Items.Remove(ListBox7.SelectedItem)

                TextBox5.Text = Convert.ToString(mony)

                ComboBox1.Text = ""
                TextBox13.Text = ""
                ComboBox1.Enabled = True
                Button25.Visible = False
                Button24.Visible = False
                Button25.Enabled = False
                Button23.Visible = True
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
        
    End Sub

    Private Sub Button19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button19.Click
        Try
            If count = 0 Then
                MsgBox("گزارشی ثبت نشده است", , "پیغام")
            Else

                For i = 0 To count - 1
                    TextBox31.Text += ListBox2.Items.Item(i) & vbCrLf
                    TextBox33.Text += ListBox3.Items.Item(i) & vbCrLf
                    TextBox34.Text += ListBox4.Items.Item(i) & vbCrLf
                    TextBox35.Text += ListBox5.Items.Item(i) & vbCrLf
                    TextBox36.Text += ListBox6.Items.Item(i) & vbCrLf
                    TextBox37.Text += ListBox7.Items.Item(i) & vbCrLf
                Next i
                rpt.SetParameterValue("D1", TextBox3.Text)
                rpt.SetParameterValue("D2", TextBox4.Text)
                rpt.SetParameterValue("D3", TextBox31.Text)
                rpt.SetParameterValue("D4", TextBox33.Text)
                rpt.SetParameterValue("D5", TextBox34.Text)
                rpt.SetParameterValue("D6", TextBox5.Text)
                rpt.SetParameterValue("D7", TextBox35.Text)
                rpt.SetParameterValue("D8", TextBox36.Text)
                rpt.SetParameterValue("D9", TextBox37.Text)

                CrystalReportViewer1.ReportSource = rpt
                CrystalReportViewer1.PrintReport()

                TextBox4.Text = ""
                TextBox5.Text = ""
                TextBox17.Text = ""
                TextBox31.Text = ""
                TextBox33.Text = ""
                TextBox34.Text = ""
                TextBox35.Text = ""
                TextBox36.Text = ""
                TextBox37.Text = ""

                ListBox2.Items.Clear()
                ListBox3.Items.Clear()
                ListBox4.Items.Clear()
                ListBox5.Items.Clear()
                ListBox6.Items.Clear()
                ListBox7.Items.Clear()
                count = 0
                test = True
                Button27.Enabled = True
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
       
    End Sub

    Private Sub TextBox22_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox22.KeyPress
        If Not IsNumeric(e.KeyChar) And e.KeyChar <> Convert.ToChar(Keys.Back) And e.KeyChar <> Convert.ToChar(Keys.Delete) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox19_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox19.KeyPress
        If Not IsNumeric(e.KeyChar) And e.KeyChar <> Convert.ToChar(Keys.Back) And e.KeyChar <> Convert.ToChar(Keys.Delete) Then
            e.Handled = True
        End If
    End Sub

    Private Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton3.CheckedChanged
        ComboBox2.Visible = True
        TextBox12.Visible = False
    End Sub

    Private Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton4.CheckedChanged
        ComboBox2.Visible = False
        TextBox12.Visible = True
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PrintDocument1.Print()
        End If
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        DataGridView1.Width = 875
        DataGridView1.Height = 1500
        Dim b As New Bitmap(DataGridView1.Width, DataGridView1.Height)
        DataGridView1.DrawToBitmap(b, New Rectangle(0, 0, 875, 1300))
        e.Graphics.DrawImage(b, New Point(0, 0))
        DataGridView1.Width = 615
        DataGridView1.Height = 244
    End Sub
End Class