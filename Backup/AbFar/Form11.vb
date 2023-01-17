Imports System.IO
Public Class Form11
    Public Function reg(ByVal TX1 As String)
        Dim x As Integer
        Dim y As Integer = 0
        Dim k As Integer = 0
        y = Convert.ToInt32(TX1)
        While (y)
            x = TX1 Mod 10
            k += x
            TX1 = (TX1 / 10)
            If x >= 5 Then
                TX1 -= 1
            End If
            y = y / 10
        End While
        Return k
    End Function
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim g As Integer
        If Label2.Visible = True Then
            Me.Close()
        ElseIf TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Then
            MsgBox("خطا", , "پیغام")
        Else
            g = reg(TextBox1.Text) + reg(TextBox2.Text) + reg(TextBox3.Text)
            If ((g Mod 51) = 0) And Not (TextBox1.Text = "0000" And TextBox2.Text = "0000" And TextBox3.Text = "0000") Then
                FileClose()
                FileOpen(1, ("c:\windows\system32\rg.txt"), OpenMode.Output)
                PrintLine(1, "active")
                FileClose()
                Label1.Visible = False
                Label2.Visible = True
                TextBox1.Visible = False
                TextBox2.Visible = False
                TextBox3.Visible = False
                TextBox4.Visible = False
                MsgBox("نرم افزار شما تایید شد . ", , )
                Form1.MaximizeBox = True
                Me.Close()
            Else
                MsgBox("کد ورودی را با دقت وارد کنید .", , "پیام")
            End If
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Close()
    End Sub
    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If Not IsNumeric(e.KeyChar) And e.KeyChar <> Convert.ToChar(Keys.Back) And e.KeyChar <> Convert.ToChar(Keys.Delete) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If Not IsNumeric(e.KeyChar) And e.KeyChar <> Convert.ToChar(Keys.Back) And e.KeyChar <> Convert.ToChar(Keys.Delete) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox3.KeyPress
        If Not IsNumeric(e.KeyChar) And e.KeyChar <> Convert.ToChar(Keys.Back) And e.KeyChar <> Convert.ToChar(Keys.Delete) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress
        If Not IsNumeric(e.KeyChar) And e.KeyChar <> Convert.ToChar(Keys.Back) And e.KeyChar <> Convert.ToChar(Keys.Delete) Then
            e.Handled = True
        End If
    End Sub

    Private Sub Form11_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim rd As StreamReader = File.OpenText("c:\windows\system32\rg.txt")
        Dim rd2 As StreamReader = File.OpenText("c:\windows\system32\rg2.txt")
        If rd.ReadToEnd = rd2.ReadToEnd Then
            Label1.Visible = False
            Label2.Visible = True
            TextBox1.Visible = False
            TextBox2.Visible = False
            TextBox3.Visible = False
            TextBox4.Visible = False
            Button2.Visible = False
        End If
    End Sub
End Class