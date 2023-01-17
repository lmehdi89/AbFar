Imports System.Data.SqlClient
Imports System.Data
Imports Microsoft.Win32.Registry
Imports System.IO
Public Class Form4
    Public Shared b As Boolean = True
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim registry As Microsoft.Win32.RegistryKey
            Dim st As String
            Dim st2 As String = Application.StartupPath + "\Images\Untitle.jpg"
            registry = CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion", True)
            st = registry.GetValue("IM", st2)
            If st = "" Then
                st = st2
            End If
            If File.Exists(st) Then
                Dim ocn As New SqlConnection
                Dim ocm As New SqlCommand
                Dim oda As New SqlDataAdapter
                Dim ds As New DataSet
                Dim da As New DataTable
                Dim bs As New BindingSource
                ocn.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=" + Application.StartupPath + "\BN.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"
                ocm.Connection = ocn
                ocm.CommandText = "select * from EN where US = N'" & TextBox1.Text & "' and PS = N'" & TextBox2.Text.GetHashCode & "'"
                oda.SelectCommand = ocm
                If oda.Fill(ds, "EN") Then
                    Form2.Opacity = 100
                    Form2.Enabled = True
                    Me.Close()
                    Form2.WindowState = FormWindowState.Normal
                    Form2.Show()
                Else
                    MsgBox("کاربر گرامی در وارد کردن نام کاربری و رمز عبور دقت بیشتری کنید", , "اخطار")
                End If
            Else
                MsgBox("تمپلیت در مسیر برنامه وجود ندارد", , "اخطار")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        End
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Button1.PerformClick()
        End If
    End Sub

    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '  Me.TopMost = True
        TextBox1.Focus()
        Label3.Text = TimeString
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Label3.Text = TimeString
        If B Then
            TextBox1.Focus()
            b = False
        End If

    End Sub
End Class