Public Class Form13
    Dim count As Integer = 1
    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Dim ocm As New System.Data.OleDb.OleDbCommand
        Dim ocn As New System.Data.OleDb.OleDbConnection

        If TextBox1.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or TextBox3.Text = "" Then
            MsgBox("مشخصات فرم کامل نیست", , "پیغام")
        ElseIf count > 26 Then
            MsgBox("فرم جدید ایجاد کنید", , "پیغام")
        Else
            ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\data.mdb"
            ocm.Connection = ocn
            ocm.CommandText = "INSERT INTO Ghabz (bishtar,D6A,D5A,D4A,D3A,D2A,D1A,D12,D11,D10,D9,D8,D7,D6,D5,D4,D3,D2,D1,T,mandeA,mandeD,roosta,bakhsh,IDA,IDD) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17,@p18,@p19,@p20,@p21,@p22,@p23,@p24,@p25,@p26)"
            ocm.Parameters.Clear()
            ocm.Parameters.AddWithValue("@p1", TextBox7.Text)
            ocm.Parameters.AddWithValue("@p19", "")
            ocm.Parameters.AddWithValue("@p18", "")
            ocm.Parameters.AddWithValue("@P17", "")
            ocm.Parameters.AddWithValue("@p16", "")
            ocm.Parameters.AddWithValue("@p15", "")
            ocm.Parameters.AddWithValue("@p14", "")
            ocm.Parameters.AddWithValue("@p13", "")
            ocm.Parameters.AddWithValue("@p12", "")
            ocm.Parameters.AddWithValue("@p11", "")
            ocm.Parameters.AddWithValue("@p10", "")
            ocm.Parameters.AddWithValue("@p9", "")
            ocm.Parameters.AddWithValue("@p8", "")
            ocm.Parameters.AddWithValue("@p20", "")
            ocm.Parameters.AddWithValue("@p21", "")
            ocm.Parameters.AddWithValue("@p25", "")
            Select Case ComboBox1.SelectedItem
                Case "دوره 1"
                    ocm.Parameters.AddWithValue("@p2", "")
                    ocm.Parameters.AddWithValue("@p3", "")
                    ocm.Parameters.AddWithValue("@p4", "")
                    ocm.Parameters.AddWithValue("@p5", "")
                    ocm.Parameters.AddWithValue("@p6", "")
                    ocm.Parameters.AddWithValue("@p7", TextBox3.Text)
                Case "دوره 2"
                    ocm.Parameters.AddWithValue("@p2", "")
                    ocm.Parameters.AddWithValue("@p3", "")
                    ocm.Parameters.AddWithValue("@p4", "")
                    ocm.Parameters.AddWithValue("@p5", "")
                    ocm.Parameters.AddWithValue("@p6", TextBox3.Text)
                    ocm.Parameters.AddWithValue("@p7", "")
                Case "دوره 3"
                    ocm.Parameters.AddWithValue("@p2", "")
                    ocm.Parameters.AddWithValue("@p3", "")
                    ocm.Parameters.AddWithValue("@p4", "")
                    ocm.Parameters.AddWithValue("@p5", TextBox3.Text)
                    ocm.Parameters.AddWithValue("@p6", "")
                    ocm.Parameters.AddWithValue("@p7", "")
                Case "دوره 4"
                    ocm.Parameters.AddWithValue("@p2", "")
                    ocm.Parameters.AddWithValue("@p3", "")
                    ocm.Parameters.AddWithValue("@p4", TextBox3.Text)
                    ocm.Parameters.AddWithValue("@p5", "")
                    ocm.Parameters.AddWithValue("@p6", "")
                    ocm.Parameters.AddWithValue("@p7", "")
                Case "دوره 5"
                    ocm.Parameters.AddWithValue("@p2", "")
                    ocm.Parameters.AddWithValue("@p3", TextBox3.Text)
                    ocm.Parameters.AddWithValue("@p4", "")
                    ocm.Parameters.AddWithValue("@p5", "")
                    ocm.Parameters.AddWithValue("@p6", "")
                    ocm.Parameters.AddWithValue("@p7", "")
                Case "دوره 6"
                    ocm.Parameters.AddWithValue("@p2", TextBox3.Text)
                    ocm.Parameters.AddWithValue("@p3", "")
                    ocm.Parameters.AddWithValue("@p4", "")
                    ocm.Parameters.AddWithValue("@p5", "")
                    ocm.Parameters.AddWithValue("@p6", "")
                    ocm.Parameters.AddWithValue("@p7", "")
            End Select

            ocm.Parameters.AddWithValue("@p26", "")
            ocm.Parameters.AddWithValue("@p24", "")
            ocm.Parameters.AddWithValue("@p23", "")
            ocm.Parameters.AddWithValue("@p22", "")

            ocn.Open()
            ocm.ExecuteNonQuery()
            ocn.Close()
            ocm.Dispose()
            ocn.Dispose()
            count += 1
        End If

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Button8.Text = ComboBox1.Text
    End Sub
End Class