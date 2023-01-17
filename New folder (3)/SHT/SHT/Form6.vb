Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.Win32.Registry
Public Class Form6

    Private Sub Form6_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form2.Enabled = True
    End Sub

    Private Sub Form6_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        giv()
    End Sub
    Public Function giv()
        Try
            Dim registry As Microsoft.Win32.RegistryKey
            registry = CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion", True)
            TextBox1.Text = registry.GetValue("UN", "شرکت تعاونی مصرف کارکنان جهاد کشاورزی گیلان")
            TextBox2.Text = registry.GetValue("F1", "نام                      :")
            TextBox3.Text = registry.GetValue("F2", "نام خانوادگی      :")
            TextBox4.Text = registry.GetValue("F3", "نام پدر               :")
            TextBox5.Text = registry.GetValue("F4", "شماره شناسنامه:")
            TextBox6.Text = registry.GetValue("F5", "شماره ملی         :")
            TextBox7.Text = registry.GetValue("F6", "تاریخ تولد          :")
            TextBox8.Text = registry.GetValue("IM", Application.StartupPath + "\Images\Untitle.jpg")
            TextBox9.Text = registry.GetValue("IM2", Application.StartupPath + "\Images\Untitle2.jpg")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return 0
    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TextBox1.Text = "شرکت تعاونی مصرف کارکنان جهاد کشاورزی گیلان"
        TextBox2.Text = "نام                      :"
        TextBox3.Text = "نام خانوادگی      :"
        TextBox4.Text = "نام پدر               :"
        TextBox5.Text = "شماره شناسنامه:"
        TextBox6.Text = "شماره ملی         :"
        TextBox7.Text = "تاریخ تولد          :"

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If MsgBox("آیا شما مطمئن به ثبت این اطلاعات هستید؟", MsgBoxStyle.YesNo, "اخطار") = MsgBoxResult.Yes Then

                Dim registry As Microsoft.Win32.RegistryKey
                registry = CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion", True)
                registry.SetValue("UN", TextBox1.Text)
                registry.SetValue("F1", TextBox2.Text)
                registry.SetValue("F2", TextBox3.Text)
                registry.SetValue("F3", TextBox4.Text)
                registry.SetValue("F4", TextBox5.Text)
                registry.SetValue("F5", TextBox6.Text)
                registry.SetValue("F6", TextBox7.Text)
       
                MsgBox("اطلاعات وارد شده شما ثبت شد", , "پیغام")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        OpenFileDialog1.FileName = TextBox8.Text
        OpenFileDialog1.Filter = "JPEG File (*.jpg)|*.jpg"
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            TextBox8.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            If MsgBox("آیا شما مطمئن به ثبت این اطلاعات هستید؟", MsgBoxStyle.YesNo, "اخطار") = MsgBoxResult.Yes Then
                Dim registry As Microsoft.Win32.RegistryKey
                registry = CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion", True)
                registry.SetValue("IM", TextBox8.Text)
                registry.SetValue("IM2", TextBox9.Text)
                MsgBox("اطلاعات وارد شده شما ثبت شد", , "پیغام")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        OpenFileDialog1.FileName = TextBox8.Text
        OpenFileDialog1.Filter = "JPEG File (*.jpg)|*.jpg"
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            TextBox9.Text = OpenFileDialog1.FileName
        End If
    End Sub
End Class