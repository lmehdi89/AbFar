Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Public Class Form7

#Region "var"
    Public address As String
    Public y As Integer
    Public x As Integer
    Public n As Integer = 0
    Public R As Boolean = True
    Public k As Boolean = True
    Public f As Boolean = True
    Public s As Boolean = True
    Public d As Boolean = True
    Public test As Boolean = True
    Public key As Boolean = True
    Public BL As Boolean = False
    Private da As OleDbDataAdapter
    Private ds As New DataSet
    Dim LP As Integer = 0
    Dim c As Integer = 0
    Dim copyc As Integer = 0
    Dim i As Integer
    Public allow As Boolean = False
    Dim rpt As New CrystalReport1
    Dim rpt1 As New CrystalReport7
    Dim rpt2 As New CrystalReport10
#End Region
    Public Function Stext()
        TextBox27.Text = ""
        TextBox30.Text = ""
        TextBox32.Text = ""
        TextBox33.Text = ""
        TextBox34.Text = ""
        TextBox35.Text = ""
        TextBox36.Text = ""
        TextBox37.Text = ""
        TextBox38.Text = ""
        TextBox39.Text = ""
        TextBox40.Text = ""
        Return 0
    End Function
    Public Function SMnone()
        ListBox1.SelectionMode = SelectionMode.None
        ListBox2.SelectionMode = SelectionMode.None
        ListBox3.SelectionMode = SelectionMode.None
        ListBox4.SelectionMode = SelectionMode.None
        ListBox5.SelectionMode = SelectionMode.None
        ListBox6.SelectionMode = SelectionMode.None
        Return 0
    End Function
    Public Function SMone()
        ListBox1.SelectionMode = SelectionMode.One
        ListBox2.SelectionMode = SelectionMode.One
        ListBox3.SelectionMode = SelectionMode.One
        ListBox4.SelectionMode = SelectionMode.One
        ListBox5.SelectionMode = SelectionMode.One
        ListBox6.SelectionMode = SelectionMode.One
        Return 0
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
        TextBox6.Text = d
        TextBox28.Text = m
        TextBox29.Text = y
        Return 0
    End Function

    Private Sub Form7_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        y = Me.Size.Height
        x = Me.Size.Width

        GroupBox4.Location = New System.Drawing.Point((x / 2), y / 28)
        Button11.Location = New System.Drawing.Point(25, (y / 12) + 620)
        Button6.Location = New System.Drawing.Point(25, (y / 12) + 665)
        GroupBox5.Location = New System.Drawing.Point(45, y / 20)
        Button48.Location = New System.Drawing.Point(10, (y / 20))

        Call Toshamsi()
        TextBox11.Text = TextBox29.Text + "/" + TextBox28.Text + "/" + TextBox6.Text
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If TextBox1.Text = "" Or TextBox3.Text = "" Or ComboBox1.Text = "" Then
                MsgBox("اطلاعات ورودی ناقص است", , "پیغام")
            Else
                address = Form1.TextBox3.Text
                Dim ocn As New System.Data.OleDb.OleDbConnection
                Dim ocm As New System.Data.OleDb.OleDbCommand
                Dim oda As New System.Data.OleDb.OleDbDataAdapter
                Dim dt As New DataTable
                ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + ""
                ocm.Connection = ocn
                ocm.CommandText = "SELECT * FROM Darkhast where ID='" & TextBox1.Text & "'"
                oda.SelectCommand = ocm
                If oda.Fill(dt) And R Then
                    MsgBox("خطای شماره درخواست تکراری", , "پیغام")
                    ocn.Close()
                    ocm.Dispose()
                    ocn.Dispose()
                Else
                    TextBox1.Enabled = False
                    test = False
                    R = False
                    allow = False
                    c += 1
                    Label18.Text = TextBox1.Text
                    ListBox1.Items.Add(ComboBox1.Text)
                    ListBox2.Items.Add(TextBox3.Text)
                    ListBox3.Items.Add(TextBox4.Text)
                    ListBox4.Items.Add(TextBox5.Text)
                    ListBox5.Items.Add(TextBox7.Text)
                    ListBox6.Items.Add(TextBox8.Text)
                    address = Form1.TextBox3.Text
                    ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + ""
                    ocm.Connection = ocn
                    ocm.CommandText = "INSERT INTO Darkhast (bishtar,mony,unit,MDBH,MDBA,name,Y,M,D,ID,NUM) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)"
                    ocm.Parameters.Clear()
                    ocm.Parameters.AddWithValue("@p1", TextBox8.Text)
                    ocm.Parameters.AddWithValue("@p2", TextBox7.Text)
                    ocm.Parameters.AddWithValue("@p3", TextBox5.Text)
                    ocm.Parameters.AddWithValue("@p4", TextBox4.Text)
                    ocm.Parameters.AddWithValue("@p5", TextBox3.Text)
                    ocm.Parameters.AddWithValue("@p6", ComboBox1.Text)
                    ocm.Parameters.AddWithValue("@p7", TextBox29.Text)
                    ocm.Parameters.AddWithValue("@p8", TextBox28.Text)
                    ocm.Parameters.AddWithValue("@p9", TextBox6.Text)
                    ocm.Parameters.AddWithValue("@p10", TextBox1.Text)
                    ocm.Parameters.AddWithValue("@p11", c)
                    ocn.Open()
                    ocm.ExecuteNonQuery()
                    ocn.Close()
                    ocm.Dispose()
                    ocn.Dispose()

                    ComboBox1.Text = ""
                    TextBox3.Text = ""
                    TextBox4.Text = ""
                    TextBox5.Text = ""
                    TextBox7.Text = ""
                    TextBox8.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
        
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
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
                ocm.CommandText = "update Darkhast SET NUM=0"
                ocn.Open()
                ocm.ExecuteNonQuery()
                ocn.Close()
                ocm.Dispose()
                ocn.Dispose()
                TextBox1.Text = ""
                ComboBox1.Text = ""
                TextBox3.Text = ""
                TextBox4.Text = ""
                TextBox5.Text = ""
                TextBox7.Text = ""
                TextBox8.Text = ""
                Label18.Text = ""
                TextBox1.Enabled = True
                ListBox1.Items.Clear()
                ListBox2.Items.Clear()
                ListBox3.Items.Clear()
                ListBox4.Items.Clear()
                ListBox5.Items.Clear()
                ListBox6.Items.Clear()
                c = 0
                R = True
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
                ocm.CommandText = "DELETE FROM Darkhast WHERE NUM >'" & 0 & "'"
                ocn.Open()
                ocm.ExecuteNonQuery()
                ocn.Close()
                ocm.Dispose()
                ocn.Dispose()
                TextBox1.Text = ""
                ComboBox1.Text = ""
                TextBox3.Text = ""
                TextBox4.Text = ""
                TextBox5.Text = ""
                TextBox7.Text = ""
                TextBox8.Text = ""
                Label18.Text = ""
                TextBox1.Enabled = True
                ListBox1.Items.Clear()
                ListBox2.Items.Clear()
                ListBox3.Items.Clear()
                ListBox4.Items.Clear()
                ListBox5.Items.Clear()
                ListBox6.Items.Clear()
                c = 0
                R = True
                test = True
                allow = False
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
       
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        TextBox1.Text = ""
        ComboBox1.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
    End Sub

    Private Sub Button45_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button45.Click
        Try
            If Not GroupBox1.Visible And k Then
                Dim ocn As New System.Data.OleDb.OleDbConnection
                Dim ocm As New System.Data.OleDb.OleDbCommand
                Dim oda As New System.Data.OleDb.OleDbDataAdapter
                Dim ds As New DataSet()
                address = Form1.TextBox3.Text
                ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + ""
                ocm.Connection = ocn
                ocm.CommandText = "SELECT name FROM Kala"
                oda.SelectCommand = ocm
                da = New OleDbDataAdapter(ocm.CommandText, ocn)
                da.Fill(ds, "Kala")

                Do
                    TextBox18.Text = TextBox17.Text
                    TextBox17.DataBindings.Add(New Binding("Text", ds, "Kala.name"))
                    ComboBox1.Items.Add(TextBox17.Text)
                    Me.BindingContext(ds, "Kala").Position += 1
                    TextBox17.DataBindings.Clear()
                    If TextBox17.Text = TextBox18.Text Then
                        Exit Do
                    End If
                Loop

                oda.Dispose()
                ocm.Dispose()
                ocn.Dispose()
                GroupBox1.Visible = True
                k = False
            ElseIf Not GroupBox1.Visible Then
                GroupBox1.Visible = True
            Else
                GroupBox1.Visible = False
                TextBox1.Text = ""
                ComboBox1.Text = ""
                TextBox3.Text = ""
                TextBox4.Text = ""
                TextBox5.Text = ""
                TextBox7.Text = ""
                TextBox8.Text = ""
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
        
    End Sub

    Private Sub Button47_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button47.Click
        Try
            TextBox17.Text = ""
            TextBox18.Text = ""
            If Not GroupBox2.Visible And d Then
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
                    TextBox18.Text = TextBox17.Text
                    TextBox17.DataBindings.Add(New Binding("Text", ds, "Kala.name"))
                    ComboBox3.Items.Add(TextBox17.Text)
                    Me.BindingContext(ds, "Kala").Position += 1
                    TextBox17.DataBindings.Clear()
                    If TextBox17.Text = TextBox18.Text Then
                        Exit Do
                    End If
                Loop

                oda.Dispose()
                ocm.Dispose()
                ocn.Dispose()
                GroupBox2.Visible = True
                d = False
            ElseIf Not GroupBox2.Visible Then
                GroupBox2.Visible = True
            Else
                GroupBox2.Visible = False
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
        
    End Sub

    Private Sub Button46_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button46.Click
        Try
            TextBox17.Text = ""
            TextBox18.Text = ""
            If Not GroupBox3.Visible And s Then
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
                    TextBox18.Text = TextBox17.Text
                    TextBox17.DataBindings.Add(New Binding("Text", ds, "Kala.name"))
                    ComboBox2.Items.Add(TextBox17.Text)
                    Me.BindingContext(ds, "Kala").Position += 1
                    TextBox17.DataBindings.Clear()
                    If TextBox17.Text = TextBox18.Text Then
                        Exit Do
                    End If
                Loop

                oda.Dispose()
                ocm.Dispose()
                ocn.Dispose()
                GroupBox3.Visible = True
                s = False
            ElseIf Not GroupBox3.Visible Then
                GroupBox3.Visible = True
            Else
                GroupBox3.Visible = False
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
        
    End Sub

    Private Sub Button48_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button48.Click
        Try
            If Not GroupBox5.Visible And f Then
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

                TextBox12.DataBindings.Add(New Binding("Text", ds, "Form.Ostan"))
                TextBox13.DataBindings.Add(New Binding("Text", ds, "Form.Shahr"))
                GroupBox5.Visible = True
                f = False
            ElseIf Not GroupBox5.Visible Then
                GroupBox5.Visible = True
            Else
                GroupBox5.Visible = False
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
       
    End Sub

    Private Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton4.CheckedChanged
        TextBox10.Visible = True
        ComboBox2.Text = ""
        ComboBox2.Visible = False
    End Sub

    Private Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton3.CheckedChanged
        TextBox10.Text = ""
        TextBox10.Visible = False
        ComboBox2.Visible = True
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try
            Dim pc As Integer = 0
            If TextBox10.Visible And TextBox10.Text = "" Then
                MsgBox("شماره درخواست را وارد کنید", , "پیغام")
            Else

                CrystalReportViewer1.Size = New System.Drawing.Size(x, y)
                CrystalReportViewer1.Location = New System.Drawing.Point(1, 1)
                Button13.Location = New System.Drawing.Point(x - 115, 5)
                address = Form1.TextBox3.Text
                Dim ocm As New System.Data.OleDb.OleDbCommand
                Dim oda As New System.Data.OleDb.OleDbDataAdapter
                Dim con As New System.Data.OleDb.OleDbConnection
                Dim strSql As String
                Dim strCon As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + ""

                If RadioButton3.Checked Then
                    strSql = "SELECT * FROM Darkhast where name ='" & ComboBox2.Text & "'"
                    con = New OleDb.OleDbConnection(strCon)
                    con.Open()
                    da = New OleDb.OleDbDataAdapter(strSql, con)
                    If da.Fill(ds, "Darkhast") Then
                        TextBox57.DataBindings.Add(New Binding("Text", ds, "Darkhast.bishtar"))
                        TextBox58.DataBindings.Add(New Binding("Text", ds, "Darkhast.mony"))
                        TextBox59.DataBindings.Add(New Binding("Text", ds, "Darkhast.unit"))
                        TextBox60.DataBindings.Add(New Binding("Text", ds, "Darkhast.MDBA"))
                        TextBox61.DataBindings.Add(New Binding("Text", ds, "Darkhast.ID"))
                        TextBox62.DataBindings.Add(New Binding("Text", ds, "Darkhast.Y"))
                        TextBox63.DataBindings.Add(New Binding("Text", ds, "Darkhast.M"))
                        TextBox64.DataBindings.Add(New Binding("Text", ds, "Darkhast.D"))

                        Do
                            TextBox56.Text = TextBox61.Text
                            TextBox47.Text += TextBox57.Text & vbCrLf
                            TextBox48.Text += TextBox58.Text & vbCrLf
                            TextBox49.Text += TextBox60.Text & vbCrLf
                            TextBox50.Text += TextBox61.Text & vbCrLf
                            TextBox55.Text += TextBox62.Text + "/" + TextBox63.Text + "/" + TextBox64.Text & vbCrLf
                            pc += Convert.ToInt32(TextBox60.Text)
                            Me.BindingContext(ds, "Darkhast").Position += 1
                            If TextBox56.Text = TextBox61.Text Then
                                Exit Do
                            End If
                        Loop
                        rpt1.SetParameterValue("A1", ComboBox2.SelectedItem)
                        rpt1.SetParameterValue("A2", TextBox59.Text)
                        rpt1.SetParameterValue("A3", TextBox50.Text)
                        rpt1.SetParameterValue("A4", TextBox49.Text)
                        rpt1.SetParameterValue("A5", TextBox48.Text)
                        rpt1.SetParameterValue("A6", TextBox47.Text)
                        rpt1.SetParameterValue("A7", (Convert.ToString(pc)))
                        rpt1.SetParameterValue("A8", TextBox55.Text)
                        CrystalReportViewer1.ReportSource = rpt1
                        CrystalReportViewer1.Visible = True
                        CrystalReportViewer1.BringToFront()
                        Button13.Visible = True
                        Button13.BringToFront()
                    Else
                        MsgBox("موردی یافت نشد", , "پیغام")
                    End If
                ElseIf RadioButton4.Checked Then
                    strSql = "SELECT * FROM Darkhast where ID ='" & TextBox10.Text & "'"
                    con = New OleDb.OleDbConnection(strCon)
                    con.Open()
                    da = New OleDb.OleDbDataAdapter(strSql, con)
                    If da.Fill(ds, "Darkhast") Then
                        TextBox57.DataBindings.Add(New Binding("Text", ds, "Darkhast.bishtar"))
                        TextBox58.DataBindings.Add(New Binding("Text", ds, "Darkhast.mony"))
                        TextBox59.DataBindings.Add(New Binding("Text", ds, "Darkhast.unit"))
                        TextBox60.DataBindings.Add(New Binding("Text", ds, "Darkhast.MDBA"))
                        TextBox61.DataBindings.Add(New Binding("Text", ds, "Darkhast.name"))
                        TextBox62.DataBindings.Add(New Binding("Text", ds, "Darkhast.Y"))
                        TextBox63.DataBindings.Add(New Binding("Text", ds, "Darkhast.M"))
                        TextBox64.DataBindings.Add(New Binding("Text", ds, "Darkhast.D"))
                        TextBox55.Text = TextBox62.Text + "/" + TextBox63.Text + "/" + TextBox64.Text
                        Do
                            TextBox56.Text = TextBox61.Text
                            TextBox47.Text += TextBox57.Text & vbCrLf
                            TextBox48.Text += TextBox58.Text & vbCrLf
                            TextBox49.Text += TextBox60.Text & vbCrLf
                            TextBox50.Text += TextBox61.Text & vbCrLf
                            TextBox51.Text += TextBox59.Text & vbCrLf
                            pc += Convert.ToInt32(TextBox60.Text)
                            Me.BindingContext(ds, "Darkhast").Position += 1
                            If TextBox56.Text = TextBox61.Text Then
                                Exit Do
                            End If
                        Loop
                        rpt2.SetParameterValue("C1", TextBox10.Text)
                        rpt2.SetParameterValue("C2", TextBox55.Text)
                        rpt2.SetParameterValue("C3", TextBox50.Text)
                        rpt2.SetParameterValue("C4", TextBox49.Text)
                        rpt2.SetParameterValue("C5", TextBox51.Text)
                        rpt2.SetParameterValue("C6", TextBox48.Text)
                        rpt2.SetParameterValue("C7", TextBox47.Text)
                        CrystalReportViewer1.ReportSource = rpt2
                        CrystalReportViewer1.Visible = True
                        CrystalReportViewer1.BringToFront()
                        Button13.Visible = True
                        Button13.BringToFront()
                    Else
                        MsgBox("موردی یافت نشد", , "پیغام")
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
       
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
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
                ocm.CommandText = "update Darkhast SET NUM=0"
                ocn.Open()
                ocm.ExecuteNonQuery()
                ocn.Close()
                ocm.Dispose()
                ocn.Dispose()
                Close()
                Form8.Close()
            Else
                address = Form1.TextBox3.Text
                Dim ocn As New System.Data.OleDb.OleDbConnection
                Dim ocm As New System.Data.OleDb.OleDbCommand
                Dim oda As New System.Data.OleDb.OleDbDataAdapter
                Dim ds As New DataSet()

                ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + ""
                ocm.Connection = ocn
                ocm.CommandText = "DELETE FROM Darkhast WHERE NUM >'" & 0 & "'"
                ocn.Open()
                ocm.ExecuteNonQuery()
                ocn.Close()
                ocm.Dispose()
                ocn.Dispose()
                Close()
                Form8.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
       
        
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        If allow Then
            Form8.TextBox32.Text = c
            Form8.Show()
            Form8.BringToFront()
        Else
            MsgBox("از برگ درخواست کالا پرینت بگیرید", , "پیغام")
        End If
    End Sub

    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Click
        If GroupBox8.Visible Then
            TextBox15.Text = ""
            TextBox16.Text = ""
            GroupBox8.Visible = False
        Else
            GroupBox8.Visible = True
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
            Dim ocn As New System.Data.OleDb.OleDbConnection
            Dim ocm As New System.Data.OleDb.OleDbCommand
            Dim oda As New System.Data.OleDb.OleDbDataAdapter
            Dim ds As New DataSet()

            ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\Data.mdb"
            ocm.Connection = ocn
            ocm.CommandText = "SELECT unit FROM Kala where name='" & ComboBox1.SelectedItem & "'"
            oda.SelectCommand = ocm
            da = New OleDbDataAdapter(ocm.CommandText, ocn)
            da.Fill(ds, "kala")

            TextBox5.DataBindings.Add(New Binding("Text", ds, "Kala.unit"))
            TextBox5.DataBindings.Clear()

            oda.Dispose()
            ocm.Dispose()
            ocn.Dispose()
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
      
    End Sub

    Private Sub Button19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button19.Click
        Try
            If TextBox15.Text = "" Or TextBox16.Text = "" Then
                MsgBox("اطلاعات ورودی ناقص است", , "پیغام")
            Else
                Dim ocm As New System.Data.OleDb.OleDbCommand
                Dim oda As New System.Data.OleDb.OleDbDataAdapter
                Dim ocn As New System.Data.OleDb.OleDbConnection
                address = Form1.TextBox3.Text
                ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + ""
                ocm.Connection = ocn
                ocm.CommandText = "INSERT INTO Kala (unit,name) VALUES (@p1,@p2)"
                ocm.Parameters.Clear()
                ocm.Parameters.AddWithValue("@p1", TextBox16.Text)
                ocm.Parameters.AddWithValue("@p2", TextBox15.Text)
                ocn.Open()
                ocm.ExecuteNonQuery()
                ocn.Close()
                ocm.Dispose()
                ocn.Dispose()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
        
    End Sub

    Private Sub TextBox10_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox10.KeyPress
        If Not IsNumeric(e.KeyChar) And e.KeyChar <> Convert.ToChar(Keys.Back) And e.KeyChar <> Convert.ToChar(Keys.Delete) Then
            e.Handled = True
        End If
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

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            If ComboBox3.SelectedItem = "" Then
                MsgBox("نام کالا را وارد کنید", , "پیغام")
            Else
                address = Form1.TextBox3.Text
                Dim ocn As New System.Data.OleDb.OleDbConnection
                Dim ocm As New System.Data.OleDb.OleDbCommand
                Dim oda As New System.Data.OleDb.OleDbDataAdapter
                Dim dt As New DataTable

                ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + ""
                ocm.Connection = ocn
                ocm.CommandText = "SELECT * FROM Darkhast where name ='" & ComboBox3.Text & "' and ID ='" & TextBox1.Text & "'"
                oda.SelectCommand = ocm
                If oda.Fill(dt) Then
                    Button2.Visible = False
                    Button3.Visible = True
                    Button3.Enabled = True
                    Button4.Visible = True
                    ComboBox3.Enabled = False
                    dt.Dispose()
                    oda.Dispose()
                    ocm.Dispose()
                    ocn.Dispose()
                Else
                    Label12.Visible = True
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

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        If c = 0 Then
            MsgBox("گزارشی ثبت نشده است", , "پیغام")
        Else

            For i = 0 To c - 1
                TextBox35.Text += ListBox1.Items.Item(i) & vbCrLf
                TextBox36.Text += ListBox2.Items.Item(i) & vbCrLf
                TextBox37.Text += ListBox3.Items.Item(i) & vbCrLf
                TextBox38.Text += ListBox4.Items.Item(i) & vbCrLf
                TextBox39.Text += ListBox5.Items.Item(i) & vbCrLf
                TextBox40.Text += ListBox6.Items.Item(i) & vbCrLf
            Next i
            rpt.SetParameterValue("D", TextBox11.Text)
            rpt.SetParameterValue("C1", TextBox35.Text)
            rpt.SetParameterValue("C2", TextBox36.Text)
            rpt.SetParameterValue("C3", TextBox37.Text)
            rpt.SetParameterValue("C4", TextBox38.Text)
            rpt.SetParameterValue("C5", TextBox39.Text)
            rpt.SetParameterValue("C6", TextBox40.Text)
            CrystalReportViewer1.ReportSource = rpt
            CrystalReportViewer1.PrintReport()

            TextBox35.Text = ""
            TextBox36.Text = ""
            TextBox37.Text = ""
            TextBox38.Text = ""
            TextBox39.Text = ""
            TextBox40.Text = ""

            R = True
            allow = True
        End If
    End Sub


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Button4.Visible = False
        Button3.Visible = False
        Button2.Visible = True
        Label12.Visible = False
        ComboBox3.Text = ""
        ComboBox3.Enabled = True
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Dim ocn As New System.Data.OleDb.OleDbConnection
            Dim ocm As New System.Data.OleDb.OleDbCommand
            Dim oda As New System.Data.OleDb.OleDbDataAdapter
            Dim dt As New DataTable
            address = Form1.TextBox3.Text
            ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                "atabase Password=" + Form14.TextBox10.Text + ""
            ocm.Connection = ocn
            ocm.CommandText = "DELETE FROM Darkhast where ID =@p10 and name =@p6"
            ocm.Parameters.Clear()
            ocm.Parameters.AddWithValue("@p6", ComboBox3.Text)
            ocm.Parameters.AddWithValue("@p10", TextBox1.Text)
            ocn.Open()
            ocm.ExecuteNonQuery()
            ocn.Close()
            ocm.Dispose()
            ocn.Dispose()

            SMone()

            Dim list As Integer = ListBox1.Items.IndexOf(ComboBox3.SelectedItem)
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

            SMnone()

            ComboBox3.Text = ""
            ComboBox3.Enabled = True
            Button4.Visible = False
            Button3.Visible = False
            Button3.Enabled = False
            Button2.Visible = True

        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
        
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        CrystalReportViewer1.Visible = False
        Button13.Visible = False
        TextBox57.DataBindings.Clear()
        TextBox58.DataBindings.Clear()
        TextBox59.DataBindings.Clear()
        TextBox60.DataBindings.Clear()
        TextBox61.DataBindings.Clear()
        TextBox62.DataBindings.Clear()
        TextBox63.DataBindings.Clear()
        TextBox64.DataBindings.Clear()
        TextBox56.Text = ""
        TextBox51.Text = ""
        TextBox47.Text = ""
        TextBox48.Text = ""
        TextBox49.Text = ""
        TextBox50.Text = ""
        TextBox55.Text = ""
    End Sub

    Private Sub TextBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox3.KeyPress
        If Not IsNumeric(e.KeyChar) And e.KeyChar <> Convert.ToChar(Keys.Back) And e.KeyChar <> Convert.ToChar(Keys.Delete) Then
            e.Handled = True
        End If
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        If (Not GroupBox6.Visible) Then

            If Form1.Label1.Text = "مدیریت" Then
                GroupBox6.Visible = True
            Else
                MsgBox("عدم امکان دسترسی به این بخش توسط کارمندان", , "پیغام")
            End If

        Else
            GroupBox6.Visible = False
        End If

    End Sub
End Class