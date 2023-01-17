Imports System.IO
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Public Class Form2
    Public address As String
    Public rgs As String
    Public rgd As String
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
        rgs = y + m + d
        Return 0
    End Function
    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1_Click(sender, e)
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim y As Integer = Form1.Size.Height
        Dim x As Integer = Form1.Size.Width
        Dim ocm As New System.Data.OleDb.OleDbCommand
        Dim oda As New System.Data.OleDb.OleDbDataAdapter
        Dim con As New System.Data.OleDb.OleDbConnection
        Dim ds As New DataSet
        Dim strSql As String
        Toshamsi()
        If ComboBox1.Text = "مدیریت" Then
            address = Form1.TextBox3.Text
            Dim strCon As String = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
            "atabase Password=" + Form14.TextBox10.Text + "")
            strSql = "SELECT * FROM code WHERE (user='" & ComboBox1.SelectedItem & "' AND ID='" & TextBox1.Text & "')"
            If TextBox1.Text = "" Then
                MsgBox("رمز عبور را وارد کنید", , "پیغام")
            Else
                con = New OleDb.OleDbConnection(strCon)
                con.Open()
                oda = New OleDb.OleDbDataAdapter(strSql, con)

                If oda.Fill(ds, "code") Then

h:                  If (File.Exists("c:\windows\System32\rg.txt")) And (File.Exists("c:\windows\System32\rg2.txt")) Then
                        Dim rd As StreamReader = File.OpenText("c:\windows\system32\rg.txt")
                        Dim rd2 As StreamReader = File.OpenText("c:\windows\system32\rg2.txt")
                        rgd = rd.ReadToEnd
                        If (rgd = rd2.ReadToEnd) Then
                            If (rgd = rd2.ReadToEnd) Then
                                Form11.Label2.Visible = True
                                Form11.Label2.Visible = False
                                Form11.TextBox1.Visible = False
                                Form11.TextBox2.Visible = False
                                Form11.TextBox3.Visible = False
                                Form11.TextBox4.Visible = False
                            End If
l:                          Form1.Label1.Text = "مدیریت"
                            Form1.PictureBox1.Size = Form1.Size
                            Form1.PictureBox1.Visible = True
                            Form1.TreeView1.Size = New System.Drawing.Size(175, y)
                            Form1.Button9.Size = New System.Drawing.Size(10, y)
                            Form1.Button9.Visible = True
                            'Form1.TreeView1.Visible = True
                            Form1.AnalogueClock1.Location = New System.Drawing.Point(x - 165, 20)
                            Form1.AnalogueClock1.Visible = True
                            Form1.GroupBox2.Visible = True
                            Form1.GroupBox1.Location = New System.Drawing.Point((x / 2) - 270, 270)
                            Form1.GroupBox1.Visible = True
                            'Form1.Button1.Visible = True
                            'Form1.Button2.Visible = True
                            'Form1.Button3.Visible = True
                            'Form1.Button4.Visible = True
                            'Form1.Button6.Visible = True
                            'Form1.Button7.Visible = True
                            'Form1.Button8.Visible = True
                            Form1.SpecialButton2.Visible = True
                            Form1.SpecialButton3.Visible = True
                            Form1.Label2.Location = New System.Drawing.Point((x / 2) - 442, 45)
                            Form1.SpecialButton2.Location = New System.Drawing.Point((x / 2) - 32, 5)
                            Form1.SpecialButton3.Location = New System.Drawing.Point((x / 2) + 32, 5)
                            Form1.Label2.Visible = True
                            Form1.Label2.BringToFront()
                            Form1.MenuStrip1.Visible = True
                            Form1.MenuStrip1.BringToFront()
                            Form1.کارتابلمدیریتToolStripMenuItem.Visible = True
                            Form1.SpecialButton2.BringToFront()
                            Form1.SpecialButton3.BringToFront()
                            Form1.Button2.BringToFront()
                            Form1.Opacity = 100
                            Form1.Enabled = True
                            Close()
                        ElseIf (rgs - rgd) > 100 Then
                            If ((rgs - rgd) - 30 <= 30 And (rgs - rgd) - 30 >= 0) Then
                                Form1.GroupBox3.Location = New System.Drawing.Point(x - 175, y - 125)
                                Form1.GroupBox3.Visible = True
                                Form1.GroupBox3.BringToFront()
                                GoTo l
                            Else
                                Form11.Show()
                            End If

                        ElseIf ((rgs - rgd) <= 30 And (rgs - rgd) >= 0) Then

                            Form1.GroupBox3.Location = New System.Drawing.Point(x - 175, y - 125)
                            Form1.GroupBox3.Visible = True
                            Form1.GroupBox3.BringToFront()
                            GoTo l

                        ElseIf ((rgs - rgd) > 30) Then
                            Form11.Show()
                        ElseIf ((rgs - rgd) < 0) Then
                            MsgBox("تاریخ سیستم خود را به حالت قبل برگردانید", , "اخطار")
                            End
                        End If
                    Else
                        FileOpen(1, ("c:\windows\system32\rg.txt"), OpenMode.Output)
                        PrintLine(1, rgs)
                        FileClose()
                        FileOpen(1, ("c:\windows\system32\rg2.txt"), OpenMode.Output)
                        PrintLine(1, "active")
                        FileClose()

                        GoTo h

                    End If
                Else
                    MsgBox("رمز عبور معتبر نیست", , "پیغام")
                    TextBox1.Text = ""
                End If
            End If
        ElseIf ComboBox1.Text = "کارمندان" Then
            Dim strCon As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\Data.mdb"
            strSql = "SELECT * FROM code WHERE (user='" & ComboBox1.SelectedItem & "' AND ID='" & TextBox1.Text & "')"
            If TextBox1.Text = "" Then
                MsgBox("رمز عبور را وارد کنید", , "پیغام")

            Else
                con = New OleDb.OleDbConnection(strCon)
                con.Open()
                oda = New OleDb.OleDbDataAdapter(strSql, con)

                If oda.Fill(ds, "code") Then
h2:                 If (File.Exists("c:\windows\System32\rg.txt")) And (File.Exists("c:\windows\System32\rg2.txt")) Then
                        Dim rd As StreamReader = File.OpenText("c:\windows\system32\rg.txt")
                        Dim rd2 As StreamReader = File.OpenText("c:\windows\system32\rg2.txt")
                        rgd = rd.ReadToEnd
                        If (rgd = rd2.ReadToEnd) Then
                            If (rgd = rd2.ReadToEnd) Then
                                Form11.Label2.Visible = True
                                Form11.Label2.Visible = False
                                Form11.TextBox1.Visible = False
                                Form11.TextBox2.Visible = False
                                Form11.TextBox3.Visible = False
                                Form11.TextBox4.Visible = False
                            End If
l2:                         Form1.Label1.Text = "کارمند"
                            Form1.PictureBox1.Size = Form1.Size
                            Form1.PictureBox1.Visible = True
                            Form1.TreeView1.Size = New System.Drawing.Size(175, y)
                            Form1.Button9.Size = New System.Drawing.Size(10, y)
                            Form1.Button9.Visible = True
                            'Form1.TreeView1.Visible = True
                            Form1.AnalogueClock1.Location = New System.Drawing.Point(x - 165, 20)
                            Form1.AnalogueClock1.Visible = True
                            Form1.GroupBox2.Visible = True
                            Form1.GroupBox1.Location = New System.Drawing.Point((x / 2) - 270, 270)
                            Form1.GroupBox1.Visible = True
                            'Form1.Button1.Visible = True
                            'Form1.Button2.Visible = True
                            'Form1.Button3.Visible = True
                            'Form1.Button4.Visible = True
                            'Form1.Button6.Visible = True
                            'Form1.Button7.Visible = True
                            'Form1.Button8.Visible = True
                            Form1.SpecialButton2.Visible = True
                            Form1.SpecialButton3.Visible = True
                            Form1.Label2.Location = New System.Drawing.Point((x / 2) - 442, 45)
                            Form1.SpecialButton2.Location = New System.Drawing.Point((x / 2) - 32, 5)
                            Form1.SpecialButton3.Location = New System.Drawing.Point((x / 2) + 32, 5)
                            Form1.Label2.Visible = True
                            Form1.Label2.BringToFront()
                            Form1.MenuStrip1.Visible = True
                            Form1.MenuStrip1.BringToFront()
                            Form1.تغییررمزعبورToolStripMenuItem.Visible = True
                            Form1.ارسالپیامبهمدیریتToolStripMenuItem.Visible = True
                            Form1.SpecialButton2.BringToFront()
                            Form1.SpecialButton3.BringToFront()
                            Form1.Button2.BringToFront()
                            Form1.GroupBox1.BringToFront()
                            Form1.Opacity = 100
                            Form1.Enabled = True
                            Close()
                        ElseIf (rgs - rgd) > 100 Then
                            If ((rgs - rgd) - 30 <= 30 And (rgs - rgd) - 30 >= 0) Then
                                Form1.GroupBox3.Location = New System.Drawing.Point(x - 175, y - 125)
                                Form1.GroupBox3.Visible = True
                                Form1.GroupBox3.BringToFront()
                                GoTo l2
                            Else
                                Form11.Show()
                            End If

                        ElseIf ((rgs - rgd) <= 30 And (rgs - rgd) >= 0) Then

                            Form1.GroupBox3.Location = New System.Drawing.Point(x - 175, y - 125)
                            Form1.GroupBox3.Visible = True
                            Form1.GroupBox3.BringToFront()
                            GoTo l2

                        ElseIf ((rgs - rgd) > 30) Then
                            Form11.Show()
                        ElseIf ((rgs - rgd) < 0) Then
                            MsgBox("تاریخ سیستم خود را به حالت قبل برگردانید", , "اخطار")
                            End
                        End If
                    Else
                        FileOpen(1, ("c:\windows\system32\rg.txt"), OpenMode.Output)
                        PrintLine(1, rgs)
                        FileClose()
                        FileOpen(1, ("c:\windows\system32\rg2.txt"), OpenMode.Output)
                        PrintLine(1, "active")
                        FileClose()

                        GoTo h2
                    End If
                Else
                    MsgBox("رمز عبور معتبر نیست", , "پیغام")
                    TextBox1.Text = ""
                End If
            End If
            oda.Dispose()
            ocm.Dispose()
            con.Dispose()
            con.Close()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        End
    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub
End Class