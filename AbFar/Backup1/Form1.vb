Imports System.IO
Public Class Form1
    Public test As Boolean = True
    Public rgs As String

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
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim y As Integer = Me.Size.Height
        Dim x As Integer = Me.Size.Width
        Dim rgd As String
        Toshamsi()
        If (File.Exists("c:\windows\system32\pas.txt")) And (File.Exists("c:\windows\system32\adr.txt")) Then
            Dim MyReader As StreamReader = File.OpenText("c:\windows\system32\pas.txt")
            Form14.TextBox10.Text = MyReader.ReadToEnd()
            MyReader.Close()

            Dim MyReader2 As StreamReader = File.OpenText("c:\windows\system32\adr.txt")
            TextBox3.Text = MyReader2.ReadToEnd()
            MyReader2.Close()
            Form2.Show()
        Else
h:          If (File.Exists("c:\windows\System32\rg.txt")) And (File.Exists("c:\windows\System32\rg2.txt")) Then
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
l:                  Label1.Text = "مدیریت"
                    Me.PictureBox1.Size = Me.Size
                    Me.PictureBox1.Visible = True
                    Me.TreeView1.Size = New System.Drawing.Size(175, y)
                    Me.Button9.Size = New System.Drawing.Size(10, y)
                    Me.Button9.Visible = True
                    'Me.TreeView1.Visible = True
                    Me.AnalogueClock1.Location = New System.Drawing.Point(x - 165, 20)
                    Me.AnalogueClock1.Visible = True
                    Me.GroupBox2.Visible = True
                    Me.GroupBox1.Location = New System.Drawing.Point((x / 2) - 270, 270)
                    Me.GroupBox1.Visible = True
                    'Me.Button1.Visible = True
                    'Me.Button2.Visible = True
                    'Me.Button3.Visible = True
                    'Me.Button4.Visible = True
                    'Me.Button6.Visible = True
                    'Me.Button7.Visible = True
                    'Me.Button8.Visible = True
                    Me.SpecialButton2.Visible = True
                    Me.SpecialButton3.Visible = True
                    Me.Label2.Location = New System.Drawing.Point((x / 2) - 442, 45)
                    Me.SpecialButton2.Location = New System.Drawing.Point((x / 2) - 32, 5)
                    Me.SpecialButton3.Location = New System.Drawing.Point((x / 2) + 32, 5)
                    Me.Label2.Visible = True
                    Me.Label2.BringToFront()
                    Me.MenuStrip1.Visible = True
                    Me.MenuStrip1.BringToFront()
                    Me.کارتابلمدیریتToolStripMenuItem.Visible = True
                    Me.SpecialButton2.BringToFront()
                    Me.SpecialButton3.BringToFront()
                    Me.Button2.BringToFront()
                    Me.GroupBox1.BringToFront()
                    Me.Opacity = 100
                    Me.Enabled = True


                ElseIf ((rgs - rgd) <= 2 And (rgs - rgd) >= 0) Then
                    If MsgBox("شما تا دو روز دیگر حق استفاده از نرم افزار را دارید آیا مایل به ثبت آن هستید؟", MsgBoxStyle.YesNo, "پیام") = MsgBoxResult.Yes Then
                        Form11.Show()
                    Else
                        GoTo l
                    End If
                ElseIf ((rgs - rgd) > 2) Then
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
        End If
    End Sub


    Public Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Form3.Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Form7.Show()
    End Sub


    Private Sub کارتابلمدیریتToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles کارتابلمدیریتToolStripMenuItem.Click
        Form14.Show()
    End Sub

    Private Sub TreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect
        Select Case TreeView1.SelectedNode.Text
            Case "گزارش شکستگی"
                Form3.Show()
                Me.Hide()
                Me.Show()
                Me.SendToBack()
            Case "درخواست کالا"
                Form7.Show()
                Me.Hide()
                Me.Show()
                Me.SendToBack()
            Case "لوله گذاری"
                Form5.Show()
                Me.Hide()
                Me.Show()
                Me.SendToBack()
            Case "تعمیر و تعویض پمپ"
                Form9.Show()
                Me.Hide()
                Me.Show()
                Me.SendToBack()
            Case "تعمیرات تأسیسات برق"
                Form10.Show()
                Me.Hide()
                Me.Show()
                Me.SendToBack()
            Case "گزارش به مرکز"
                Form6.Show()
                Me.Hide()
                Me.Show()
                Me.SendToBack()
            Case "گزارش به استان"
                Form22.Show()
                Me.Hide()
                Me.Show()
                Me.SendToBack()
            Case "رسّام"
                Form15.Show()
                Me.Hide()
                Me.Show()
                Me.SendToBack()
            Case "قبوض برق"
                Form20.Show()
                Me.Hide()
                Me.Show()
                Me.SendToBack()
            Case "اسکن"
                frmScanApplication.Show()
                Me.Hide()
                Me.Show()
                Me.SendToBack()
            Case "پروژه ها"
                Form18.Show()
                Me.Hide()
                Me.Show()
                Me.SendToBack()
            Case "گزارش عملکرد"
                Form23.Show()
                Me.Hide()
                Me.Show()
                Me.SendToBack()
        End Select
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If test Then
            test = False
            Form4.Show()
        Else
            test = True
            Form4.Close()
        End If
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        If Not test Then
            Form4.Close()
            test = True
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Form6.Show()
    End Sub

    Private Sub خروجToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles خروجToolStripMenuItem.Click
        End
    End Sub

    Private Sub LogOFFToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogOFFToolStripMenuItem.Click
        Form2.Show()
        AnalogueClock1.Visible = False
        PictureBox1.Visible = False
        'Button1.Visible = False
        'Button2.Visible = False
        'Button3.Visible = False
        'Button4.Visible = False
        'Button6.Visible = False
        'Button7.Visible = False
        GroupBox2.Visible = False
        GroupBox1.Visible = False
        AnalogueClock1.Visible = False
        MenuStrip1.Visible = False
        TreeView1.Visible = False
        Opacity = 0
        Me.Enabled = False
    End Sub

    Private Sub شکستگیهاToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles شکستگیهاToolStripMenuItem.Click
        Form3.Show()
    End Sub

    Private Sub درخواستکالاToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles درخواستکالاToolStripMenuItem.Click
        Form7.Show()
    End Sub

    Private Sub لولهگذاریToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles لولهگذاریToolStripMenuItem.Click
        Form5.Show()
    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click
        Form5.Show()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Form15.Show()
    End Sub

    Private Sub Label3_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label3.MouseLeave
        Label3.ForeColor = Color.White
    End Sub

    Private Sub Label3_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label3.MouseMove
        Label3.ForeColor = Color.Yellow
    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click
        Form9.Show()
    End Sub

    Private Sub Label4_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label4.MouseLeave
        Label4.ForeColor = Color.White
    End Sub

    Private Sub Label4_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label4.MouseMove
        Label4.ForeColor = Color.Yellow
    End Sub

    Private Sub PictureBox1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseLeave
        TextBox2.Visible = False
    End Sub

    Private Sub PictureBox1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove
        TextBox2.Visible = True
        If e.Y <= 20 And e.X <= 25 Then
            TextBox2.Location = New Point((PictureBox1.Location.X) + e.X, (PictureBox1.Location.Y) + e.Y)
        End If
    End Sub

    Private Sub تعمیروتعویزپمپToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles تعمیروتعویزپمپToolStripMenuItem.Click
        Form9.Show()
    End Sub

    Private Sub تعمیراتتأسیساتبرقToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles تعمیراتتأسیساتبرقToolStripMenuItem.Click
        Form10.Show()
    End Sub

    Private Sub گزارشبهمرکزToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles گزارشبهمرکزToolStripMenuItem.Click
        Form9.Show()
    End Sub

    Private Sub رسToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles رسToolStripMenuItem.Click
        Form15.Show()
    End Sub

    Private Sub تغییررمزعبورToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles تغییررمزعبورToolStripMenuItem.Click
        Form16.Show()
    End Sub

    Private Sub Label5_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label5.MouseLeave
        Label5.ForeColor = Color.White
    End Sub

    Private Sub Label5_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label5.MouseMove
        Label5.ForeColor = Color.Yellow
    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click
        Form10.Show()
    End Sub

    Public Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Form18.Show()
    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click
        Form20.Show()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        frmScanApplication.Show()
    End Sub

    Private Sub Label6_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label6.MouseLeave
        Label6.ForeColor = Color.White
    End Sub

    Private Sub Label6_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label6.MouseMove
        Label6.ForeColor = Color.Yellow
    End Sub

    Private Sub SpecialButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SpecialButton2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub SpecialButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SpecialButton3.Click
        End
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        If Not TreeView1.Visible Then
            Button9.Location = New System.Drawing.Point(175, 0)
            TreeView1.Visible = True
            Button9.Cursor = Cursors.PanWest
        Else
            Button9.Location = New System.Drawing.Point(0, 0)
            TreeView1.Visible = False
            Button9.Cursor = Cursors.PanEast
        End If
    End Sub

    Private Sub Button1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.MouseLeave
        Button1.Size = New System.Drawing.Size(145, 55)
        Button1.Location = New System.Drawing.Point(20, 33)
    End Sub

    Private Sub Button1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button1.MouseMove
        Button1.Size = New System.Drawing.Size(165, 75)
        Button1.Location = New System.Drawing.Point(15, 28)
    End Sub

    Private Sub Button3_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.MouseLeave
        Button3.Size = New System.Drawing.Size(150, 55)
        Button3.Location = New System.Drawing.Point(432, 33)
    End Sub

    Private Sub Button3_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button3.MouseMove
        Button3.Size = New System.Drawing.Size(165, 75)
        Button3.Location = New System.Drawing.Point(427, 28)
    End Sub

    Private Sub Button4_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.MouseLeave
        Button4.Size = New System.Drawing.Size(150, 55)
        Button4.Location = New System.Drawing.Point(20, 141)
    End Sub

    Private Sub Button4_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button4.MouseMove
        Button4.Size = New System.Drawing.Size(165, 75)
        Button4.Location = New System.Drawing.Point(15, 136)
    End Sub

    Private Sub Button8_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button8.MouseLeave
        Button8.Size = New System.Drawing.Size(150, 55)
        Button8.Location = New System.Drawing.Point(432, 141)
    End Sub

    Private Sub Button8_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button8.MouseMove
        Button8.Size = New System.Drawing.Size(165, 75)
        Button8.Location = New System.Drawing.Point(427, 136)
    End Sub

    Private Sub Button6_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button6.MouseLeave
        Button6.Size = New System.Drawing.Size(150, 55)
        Button6.Location = New System.Drawing.Point(226, 252)
    End Sub

    Private Sub Button6_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button6.MouseMove
        Button6.Size = New System.Drawing.Size(165, 75)
        Button6.Location = New System.Drawing.Point(221, 248)
    End Sub

    Private Sub Button7_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button7.MouseLeave
        Button7.Size = New System.Drawing.Size(150, 55)
        Button7.Location = New System.Drawing.Point(432, 252)
    End Sub

    Private Sub Button7_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button7.MouseMove
        Button7.Size = New System.Drawing.Size(165, 75)
        Button7.Location = New System.Drawing.Point(422, 248)
    End Sub

    Private Sub دربارهسامانهToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles دربارهسامانهToolStripMenuItem.Click
        Form21.Show()
    End Sub

    Private Sub پروژههاToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles پروژههاToolStripMenuItem.Click
        Form18.Show()
    End Sub

    Private Sub قبوضبرقToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles قبوضبرقToolStripMenuItem.Click
        Form20.Show()
    End Sub

    Private Sub اسکنToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles اسکنToolStripMenuItem.Click
        frmScanApplication.Show()
    End Sub

    Private Sub Button5_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.MouseLeave
        Button5.Size = New System.Drawing.Size(150, 55)
        Button5.Location = New System.Drawing.Point(20, 248)
    End Sub

    Private Sub Button5_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button5.MouseMove
        Button5.Size = New System.Drawing.Size(165, 75)
        Button5.Location = New System.Drawing.Point(15, 248)
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Form22.Show()
    End Sub

    Private Sub Button10_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button10.MouseLeave
        Button10.Size = New System.Drawing.Size(150, 55)
        Button10.Location = New System.Drawing.Point(226, 332)
        Button10.Text = "گزارش عملکرد"
    End Sub

    Private Sub Button10_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button10.MouseMove
        Button10.Size = New System.Drawing.Size(575, 65)
        Button10.Location = New System.Drawing.Point(15, 328)
        Button10.Text = "گزارش عملکرد بخش بهره برداری"
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        form23.show()
    End Sub
End Class
