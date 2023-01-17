Imports System.Data
Imports System.Data.SqlClient
Public Class Form5

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Close()
        Form2.PictureBox1.Image = Global.WindowsApplication1.My.Resources.te4
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try
            If TextBox6.Text = TextBox8.Text Then


                Dim ocn As New SqlConnection
                Dim ocm As New SqlCommand
                Dim oda As New SqlDataAdapter
                Dim da As New DataTable
                Dim ds As New DataSet
                ocn.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=" + Application.StartupPath + "\BN.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"
                ocm.Connection = ocn
                ocm.CommandText = "select * from EN where US = N'" & TextBox7.Text & "' AND PS = N'" & TextBox10.Text.GetHashCode & "'"
                oda.SelectCommand = ocm
                If oda.Fill(da) Then
                    ocm.CommandText = "DELETE FROM EN WHERE US = N'" & TextBox7.Text & "' and PS ='" & TextBox10.Text.GetHashCode & "'"
                    ocn.Open()
                    ocm.ExecuteNonQuery()
                    ocn.Close()
                    ocm.Dispose()
                    ocn.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=" + Application.StartupPath + "\BN.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"
                    ocm.Connection = ocn
                    ocm.CommandText = "INSERT INTO EN (US,PS) VALUES (@p1,@p2)"
                    ocm.Parameters.Clear()
                    ocm.Parameters.AddWithValue("@p1", TextBox9.Text)
                    ocm.Parameters.AddWithValue("@p2", TextBox8.Text.GetHashCode)
                    ocn.Open()
                    ocm.ExecuteNonQuery()
                    ocn.Close()
                    ocm.Dispose()
                    MsgBox("عملیات با موفقیت انجام شد", , "پیغام")
                    TextBox10.Text = ""
                    TextBox6.Text = ""
                    TextBox7.Text = ""
                    TextBox8.Text = ""
                    TextBox9.Text = ""
                    Me.Close()
                    Form2.PictureBox1.Image = Global.WindowsApplication1.My.Resources.te4
                Else
                    MsgBox("نام کاربری یا رمز عبور اشتباه می باشد", , "پیغام")
                End If

            Else
                MsgBox("در وارد کردن رمز عبور دقت کنید", , "اخطار")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Form5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GroupBox2.Visible = True
        GroupBox2.Enabled = True
        Form2.PictureBox1.Image = Global.WindowsApplication1.My.Resources.te4
    End Sub

    Private Sub Form5_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Form2.f1 = True
        Form2.f2 = True
    End Sub
End Class