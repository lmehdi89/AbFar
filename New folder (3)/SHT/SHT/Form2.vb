Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.Win32.Registry
Public Class Form2
    Public Shared f1 As Boolean = True
    Public Shared f2 As Boolean = True
    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        '  Form1.MdiParent = Me
        Try
            If f1 Then
                PictureBox1.Image = Global.WindowsApplication1.My.Resources.te2
                PictureBox1.Location = New Point(549, -32)
                CrystalReportViewer1.Visible = False
                Button1.Visible = False
                Form1.Show()
                ' Label2.Enabled = False
                Form1.BringToFront()
                Form1.MdiParent = Me
                Form1.Parent = Me.Panel1
                Form1.Visible = True
                Form1.BringToFront()
                Form5.Close()
                Form3.Close()
                f1 = False
                f2 = True
                Dim ocn As New SqlConnection
                Dim ocm As New SqlCommand
                Dim ocm1 As New SqlCommand
                Dim ocm2 As New SqlCommand
                Dim oda As New SqlDataAdapter
                Dim oda1 As New SqlDataAdapter
                Dim da As New DataTable
                Dim da1 As New DataTable
                Dim ds As New DataSet
                ocn.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=" + Application.StartupPath + "\BN.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"
                ocm2.Connection = ocn
                ocm2.CommandText = "select max(id) from INF"
                oda1.SelectCommand = ocm2
                oda1.SelectCommand.Connection.Open()
                Form1.Label7.Text = oda1.SelectCommand.ExecuteScalar.ToString
                oda1.SelectCommand.Connection.Close()
                If Form1.Label7.Text = "" Then
                    Form1.Label7.Text = "1000"
                Else
                    Form1.Label7.Text += 1
                End If
                ocn.Close()
                ocm.Dispose()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click
        Try
            If f2 Then
                '  CrystalReportViewer1.Dispose()
                CrystalReportViewer1.Visible = False
                Button1.Visible = False
                PictureBox1.Image = Global.WindowsApplication1.My.Resources.te3
                PictureBox1.Location = New Point(549, -55)
                ' Form3.MdiParent = Me
                Form3.Show()
                Form3.MdiParent = Me
                Form3.Parent = Me.Panel1
                Form3.Visible = True
                Form3.BringToFront()
                Form5.Close()
                ' Form1.Close()
                f2 = False
                f1 = True
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'CrystalReportViewer1.Dispose()
        CrystalReportViewer1.Visible = False
        Button1.Visible = False
    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        bn()
        Me.Opacity = 0
        Me.Enabled = False
        fir()
        If Label4.Text = "" Then
            SE()
        End If
        Label4.Text = ""
        Form4.Show()

    End Sub
    Public Function fir()
        Try
            Dim ocn As New SqlConnection
            Dim ocm As New SqlCommand
            Dim oda As New SqlDataAdapter
            Dim da As New DataTable
            Dim ds As New DataSet
            ocn.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=" + Application.StartupPath + "\BN.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"
            ocm.Connection = ocn
            ocm.CommandText = "select PS from EN"
            oda.SelectCommand = ocm
            If oda.Fill(ds, "EN") Then
                Label4.DataBindings.Clear()
                Label4.DataBindings.Add(New Binding("Text", ds, "EN.PS"))
                oda.Dispose()
                ocm.Dispose()
                ocn.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return 0
    End Function
    Public Function SE()
        Try
             Dim ocn As New SqlConnection
            Dim ocm As New SqlCommand
            Dim oda As New SqlDataAdapter
            Dim da As New DataTable
            Dim ds As New DataSet
            ocn.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=" + Application.StartupPath + "\BN.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"
            ocm.Connection = ocn
            ocm.CommandText = "INSERT INTO EN (US,PS) VALUES (@p1,@p2)"
            ocm.Parameters.Clear()
            ocm.Parameters.Add("@p1", "user")
            ocm.Parameters.Add("@p2", "123".GetHashCode)
            ocn.Open()
            ocm.ExecuteNonQuery()
            ocn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return 0
    End Function
    Public Function bn()
        Try
            Dim registry As Microsoft.Win32.RegistryKey
            registry = CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion", True)
            Label3.Text = registry.GetValue("UN", "شرکت تعاونی مصرف کارکنان جهاد کشاورزی گیلان")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return 0
    End Function
    Private Sub امنیتToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles امنیتToolStripMenuItem.Click
        CrystalReportViewer1.Visible = False
        Button1.Visible = False
        ' Form5.MdiParent = Me
        Form5.Show()
        Form5.MdiParent = Me
        Form5.Parent = Me.Panel1
        Form5.Visible = True
        Form5.BringToFront()
        Form1.Close()
        Form3.Close()
    End Sub

    Private Sub Label2_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.MouseEnter
        If f2 Then
            Label2.BackColor = Color.FromArgb(39, 43, 87)
        End If
    End Sub

    Private Sub Label2_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.MouseLeave
        Label2.BackColor = Color.FromArgb(39, 43, 57)
    End Sub

    Private Sub Label1_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.MouseEnter
        If f1 Then
            Label1.BackColor = Color.FromArgb(39, 43, 87)
        End If

    End Sub

    Private Sub Label1_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.MouseLeave
        Label1.BackColor = Color.FromArgb(39, 43, 57)
    End Sub

    Private Sub تغییرعنوانToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles تغییرعنوانToolStripMenuItem.Click
        Form6.Show()
        Me.Enabled = False
    End Sub
End Class