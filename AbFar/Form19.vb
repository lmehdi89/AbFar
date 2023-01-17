Public Class Form19

    Private Sub Form19_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Location = New Point((((Form3.Size.Width) / 2) + Form3.GroupBox4.Size.Width) - 2, Form3.GroupBox2.Size.Height)
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ocn As New System.Data.OleDb.OleDbConnection
        Dim ocm As New System.Data.OleDb.OleDbCommand
        Dim stp As Integer = 1
        If TextBox11.Text = "" Or TextBox12.Text = "" Then
            MsgBox("هر دو فیلد باید تکمیل شود")
        Else
            ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\Data.mdb"
            ocm.Connection = ocn
            ocm.CommandText = "DELETE FROM Shekastegi WHERE ID=@p9 AND roosta=@p7 "
            ocm.Parameters.Clear()
            ocm.Parameters.AddWithValue("@p9", Form3.TextBox2.Text)
            ocm.Parameters.AddWithValue("@p7", TextBox12.Text)
            ocn.Open()
            ocm.ExecuteNonQuery()
            ocn.Close()
            ocm.Dispose()
            ocn.Dispose()
            stp = Convert.ToInt32(TextBox11.Text)
            Select Case stp
                Case 1
                    Form3.TextBox17.Text = "1 _ "
                Case 2
                    Form3.TextBox18.Text = "2 _ "
                Case 3
                    Form3.TextBox19.Text = "3 _ "
                Case 4
                    Form3.TextBox20.Text = "4 _ "
                Case 5
                    Form3.TextBox21.Text = "5 _ "
                Case 6
                    Form3.TextBox22.Text = "6 _ "
                Case 7
                    Form3.TextBox23.Text = "7 _ "
                Case 8
                    Form3.TextBox24.Text = "8 _ "
                Case 9
                    Form3.TextBox25.Text = "9 _ "
                Case 10
                    Form3.TextBox26.Text = "10 _ "
                Case 11
                    Form3.TextBox27.Text = "11 _ "
            End Select

        End If
    End Sub
    Dim del As Boolean = False
    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TextBox11.Text = ""
        TextBox12.Text = ""
        del = True
    End Sub

    Private Sub TextBox11_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not IsNumeric(e.KeyChar) And e.KeyChar <> Convert.ToChar(Keys.Back) And e.KeyChar <> Convert.ToChar(Keys.Delete) Then
            e.Handled = True
        End If
    End Sub

End Class