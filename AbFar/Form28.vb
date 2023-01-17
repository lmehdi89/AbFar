Public Class Form28

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
        Form24.Enabled = True
        Form15.Show()
        Form15.Button6.Visible = True
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
        Form24.Enabled = True
        frmScanApplication.Show()
        frmScanApplication.Button3.Visible = True
        frmScanApplication.Button3.Enabled = True
    End Sub
End Class