Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports system.IO
Public Class Form24
    Public address As String
    Public test As Boolean = True
    public key as Boolean=False
    Private da As OleDbDataAdapter
    Public x As Integer
    Public y As Integer
    Dim rpt As New CrystalReport20
    Private Sub ComboBox1_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.DropDown
        test = True
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If Not test Then
            Exit Sub
        Else
            Dim ocn As New System.Data.OleDb.OleDbConnection
            Dim ocm As New System.Data.OleDb.OleDbCommand
            Dim oda As New System.Data.OleDb.OleDbDataAdapter
            Dim ds As New DataSet()

            ComboBox2.Items.Clear()
            ComboBox2.Text = ""

            ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\Data.mdb"
            ocm.Connection = ocn
            ocm.CommandText = "SELECT roosta FROM Roostaha where bakhsh='" & ComboBox1.SelectedItem & "'"
            oda.SelectCommand = ocm
            da = New OleDbDataAdapter(ocm.CommandText, ocn)
            da.Fill(ds, "Roostaha")

            Do
                TextBox36.Text = TextBox35.Text
                TextBox35.DataBindings.Add(New Binding("Text", ds, "Roostaha.roosta"))
                ComboBox2.Items.Add(TextBox35.Text)
                Me.BindingContext(ds, "Roostaha").Position += 1
                TextBox35.DataBindings.Clear()
                If TextBox35.Text = TextBox36.Text Then
                    Exit Do
                End If
            Loop

            oda.Dispose()
            ocm.Dispose()
            ocn.Dispose()

            Button42.Visible = True
        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        test = False
        Dim ocn As New System.Data.OleDb.OleDbConnection
        Dim ocm As New System.Data.OleDb.OleDbCommand
        Dim oda As New System.Data.OleDb.OleDbDataAdapter
        Dim ds As New DataSet()
        ComboBox2.Text = ComboBox2.SelectedText
        ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\Data.mdb"
        ocm.Connection = ocn
        ocm.CommandText = "SELECT bakhsh FROM Roostaha where roosta='" & ComboBox2.SelectedItem & "'"
        oda.SelectCommand = ocm
        da = New OleDbDataAdapter(ocm.CommandText, ocn)
        da.Fill(ds, "Roostaha")
        ComboBox1.DataBindings.Add(New Binding("text", ds, "Roostaha.bakhsh"))
        ComboBox1.DataBindings.Clear()
        oda.Dispose()
        ocm.Dispose()
        ocn.Dispose()
        Button42.Visible = True
    End Sub

    Private Sub Button42_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button42.Click
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox2.Items.Clear()
        Dim ocn As New System.Data.OleDb.OleDbConnection
        Dim ocm As New System.Data.OleDb.OleDbCommand
        Dim oda As New System.Data.OleDb.OleDbDataAdapter
        Dim ds As New DataSet()

        ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\Data.mdb"
        ocm.Connection = ocn
        ocm.CommandText = "SELECT roosta FROM Roostaha"
        oda.SelectCommand = ocm
        da = New OleDbDataAdapter(ocm.CommandText, ocn)
        da.Fill(ds, "Roostaha")

        Do
            TextBox36.Text = TextBox35.Text
            TextBox35.DataBindings.Add(New Binding("Text", ds, "Roostaha.roosta"))
            ComboBox2.Items.Add(TextBox35.Text)
            Me.BindingContext(ds, "Roostaha").Position += 1
            TextBox35.DataBindings.Clear()
            If TextBox35.Text = TextBox36.Text Then
                Exit Do
            End If
        Loop
        oda.Dispose()
        ocm.Dispose()
        ocn.Dispose()
        ComboBox1.Enabled = True
        ComboBox2.Enabled = True
        Button42.Visible = False
        test = True
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged
        Select Case ComboBox3.Text
            Case "بله"
                Button5.Enabled = False
                Button3.Enabled = True
                PictureBox1.Visible = True
            Case "خیر"
                Button5.Enabled = True
                Button3.Enabled = False
                PictureBox1.Visible = False
        End Select
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If key Then
            Form25.Show()
            Form15.Button6.Visible = True
        Else
            MsgBox("درخواستی قبت نشده است", , "پیغام")
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim ocm As New System.Data.OleDb.OleDbCommand
        Dim oda As New System.Data.OleDb.OleDbDataAdapter
        Dim ocn As New System.Data.OleDb.OleDbConnection


        If ComboBox3.Text = "" Or ComboBox1.Text = "" Or ComboBox2.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Then
            MsgBox("عدم دریافت اطلاعات اساسی", , "پیغام")
        Else
            address = Form1.TextBox3.Text
            ocn.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
        "atabase Password=" + Form14.TextBox10.Text + "")
            ocm.Connection = ocn
            ocm.CommandText = "INSERT INTO DarkhastLO (bishtar,address,MGHG,VMN,TKH,ML,SL,roosta,bakhsh,koruki,num,IMGADR) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12)"
            ocm.Parameters.Clear()
            ocm.Parameters.AddWithValue("@p1", TextBox7.Text)
            ocm.Parameters.AddWithValue("@p2", TextBox6.Text)
            ocm.Parameters.AddWithValue("@p3", TextBox5.Text)
            ocm.Parameters.AddWithValue("@p4", TextBox1.Text)
            ocm.Parameters.AddWithValue("@p5", TextBox4.Text)
            ocm.Parameters.AddWithValue("@p6", TextBox2.Text)
            ocm.Parameters.AddWithValue("@p7", TextBox3.Text)
            ocm.Parameters.AddWithValue("@p8", ComboBox2.Text)
            ocm.Parameters.AddWithValue("@p9", ComboBox1.Text)
            ocm.Parameters.AddWithValue("@p10", ComboBox3.Text)
            ocm.Parameters.AddWithValue("@p11", "1")
            ocm.Parameters.AddWithValue("@p12", "")

            ocn.Open()
            ocm.ExecuteNonQuery()
            ocn.Close()
            ocm.Dispose()
            ocn.Dispose()
            key = True
        End If
    End Sub

    Private Sub Form24_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        y = Me.Size.Height
        x = Me.Size.Width
        GroupBox1.Location = New System.Drawing.Point(x / 2, 15)
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try
            ' here i have define a simple datatable inwhich image will recide
            Dim dt As New DataTable
            ' object of data row
            Dim drow As DataRow
            ' add the column in table to store the image of Byte array type
            dt.Columns.Add("Image", System.Type.GetType("System.Byte[]"))
            drow = dt.NewRow
            ' define the filestream object to read the image
            Dim fs As FileStream
            ' define te binary reader to read the bytes of image
            Dim br As BinaryReader
            ' check the existance of image
            If File.Exists(AppDomain.CurrentDomain.BaseDirectory & "10157.Jpg") Then
                ' open image in file stream
                fs = New FileStream(AppDomain.CurrentDomain.BaseDirectory & "10157.Jpg", FileMode.Open)
            Else ' if phot does not exist show the nophoto.jpg file
                fs = New FileStream(AppDomain.CurrentDomain.BaseDirectory & "NoPhoto.jpg", FileMode.Open)
            End If
            ' initialise the binary reader from file streamobject
            br = New BinaryReader(fs)
            ' define the byte array of filelength
            Dim imgbyte(fs.Length) As Byte
            ' read the bytes from the binary reader
            imgbyte = br.ReadBytes(Convert.ToInt32((fs.Length)))
            drow(0) = imgbyte       ' add the image in bytearray
            dt.Rows.Add(drow)       ' add row into the datatable
            br.Close()              ' close the binary reader
            fs.Close()              ' close the file stream
            Dim rptobj As New CrystalReport1    ' object of crystal report
            rptobj.SetDataSource(dt)            ' set the datasource of crystalreport object
            CrystalReportViewer1.ReportSource = rptobj  'set the report source
        Catch ex As Exception
            ' error handling
            MsgBox("Missing 10157.jpg or nophoto.jpg in application folder")
        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If TextBox4.BorderStyle = BorderStyle.None Then
            Dim result As Integer = MsgBox("آيا درخواست جاری را ذخیره می کنید؟", MsgBoxStyle.YesNoCancel)
            If result = MsgBoxResult.Yes Then
                address = Form1.TextBox3.Text
                Dim ocn As New System.Data.OleDb.OleDbConnection
                Dim ocm As New System.Data.OleDb.OleDbCommand
                Dim oda As New System.Data.OleDb.OleDbDataAdapter
                Dim ds As New DataSet()

                ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
            "atabase Password=" + Form14.TextBox10.Text + ""
                ocm.Connection = ocn
                ocm.CommandText = "update DarkhastLO SET NUM=0"
                ocn.Open()
                ocm.ExecuteNonQuery()
                ocn.Close()
                ocm.Dispose()
                ocn.Dispose()
                Close()
            ElseIf result = MsgBoxResult.No Then
                address = Form1.TextBox3.Text
                Dim ocn As New System.Data.OleDb.OleDbConnection
                Dim ocm As New System.Data.OleDb.OleDbCommand
                Dim oda As New System.Data.OleDb.OleDbDataAdapter
                Dim ds As New DataSet()

                ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
            "atabase Password=" + Form14.TextBox10.Text + ""
                ocm.Connection = ocn
                ocm.CommandText = "DELETE FROM DarkhastLO WHERE NUM >'" & 0 & "'"
                ocn.Open()
                ocm.ExecuteNonQuery()
                ocn.Close()
                ocm.Dispose()
                ocn.Dispose()
                Close()
            End If
        Else
            Close()
        End If
    End Sub
End Class