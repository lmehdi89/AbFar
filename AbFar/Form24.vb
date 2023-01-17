Imports system.IO
Imports System.Data.OleDb
Imports System.Data
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Text
Imports System.Windows.Forms
Imports CrystalDecisions.CrystalReports.Engine
Public Class Form24
    Friend class2 As New class1
    Public address As String
    Public test As Boolean = True
    Public key As Boolean = False
    Private da As OleDbDataAdapter
    Public x As Integer
    Public y As Integer
    Dim rpt As New CrystalReport20
    Dim PrintPreviewDialog1 As New PrintPreviewDialog
    Private Function SetupThePrinting() As Boolean
        Try

       
            Dim MyPrintDialog As PrintDialog = New PrintDialog()
            MyPrintDialog.AllowCurrentPage = False
            MyPrintDialog.AllowPrintToFile = False
            MyPrintDialog.AllowSelection = False
            MyPrintDialog.AllowSomePages = False
            MyPrintDialog.PrintToFile = False
            MyPrintDialog.ShowHelp = False
            MyPrintDialog.ShowNetwork = False

            If Not (MyPrintDialog.ShowDialog() = DialogResult.OK) Then
                Return False
            End If
            myPrintDocument.DocumentName = "درخواست لوله برای روستای " + ComboBox4.Text
            myPrintDocument.PrinterSettings = MyPrintDialog.PrinterSettings
            myPrintDocument.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings
            myPrintDocument.DefaultPageSettings.Margins = New Margins(40, 40, 40, 40)


            class2.DataGridViewPrinter(DataGridView1, myPrintDocument, True, True, "درخواست لوله برای روستای " + ComboBox4.Text, New Font("Tahoma", 10, FontStyle.Bold, GraphicsUnit.Point), Color.Black, True)
            Return True
        Catch ex As Exception
            MsgBox(ex.ToString, , )
        End Try
    End Function
    Private Sub ComboBox1_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.DropDown
        test = True
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
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
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
        
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        Try
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
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
       
    End Sub

    Private Sub Button42_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button42.Click
        Try
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
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
       
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
            Me.Enabled = False
            Form28.Show()
            Button9.BringToFront()
            Button9.Enabled = True
            Button9.Visible = True
        Else
            MsgBox("درخواستی ثبت نشده است", , "پیغام")
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
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
                If ComboBox3.Text = "بله" Then
                    MsgBox("اطلاعات با موفقیت ثبت شد وارد صفحه رسّام شوید", , "پیغام")
                Else
                    MsgBox("اطلاعات با موفقیت ثبت شد", , "پیغام")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
        
    End Sub

    Private Sub Form24_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            y = Me.Size.Height
            x = Me.Size.Width
            GroupBox1.Location = New System.Drawing.Point(x / 2, 15)
            address = Form1.TextBox3.Text
            Dim ds As New DataSet()
            Dim strSql As String
            Dim strCon As String = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
            "atabase Password=" + Form14.TextBox10.Text + "")
            Dim da As OleDb.OleDbDataAdapter
            Dim con As OleDb.OleDbConnection
            strSql = "select * from Form"
            con = New OleDb.OleDbConnection(strCon)
            con.Open()
            da = New OleDb.OleDbDataAdapter(strSql, con)
            da.Fill(ds, "Form")
            TextBox13.DataBindings.Add(New Binding("Text", ds, "Form.Ostan"))
            TextBox14.DataBindings.Add(New Binding("Text", ds, "Form.Shahr"))
            PictureBox1.Image = Image.FromFile(Application.StartupPath + "\ck.jpg")
            Dim ocn As New System.Data.OleDb.OleDbConnection
            Dim ocm As New System.Data.OleDb.OleDbCommand
            Dim oda As New System.Data.OleDb.OleDbDataAdapter
            ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
        "atabase Password=" + Form14.TextBox10.Text + ""
            ocm.Connection = ocn
            ocm.CommandText = "update DarkhastLO SET NUM=0"
            ocn.Open()
            ocm.ExecuteNonQuery()
            ocn.Close()
            ocm.Dispose()
            ocn.Dispose()

        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
        
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try
         
            rpt.SetParameterValue("D1", TextBox13.Text)
            rpt.SetParameterValue("D2", TextBox14.Text)
            rpt.SetParameterValue("D3", TextBox3.Text)
            rpt.SetParameterValue("D4", TextBox2.Text)
            rpt.SetParameterValue("D5", ComboBox2.Text)
            rpt.SetParameterValue("D6", ComboBox1.Text)
            rpt.SetParameterValue("D7", TextBox1.Text)
            rpt.SetParameterValue("D8", TextBox5.Text)
            rpt.SetParameterValue("D9", TextBox6.Text)
            rpt.SetParameterValue("D10", TextBox7.Text)
            CrystalReportViewer1.ReportSource = rpt
            CrystalReportViewer1.PrintReport()

            PrintPreviewDialog1.Document = PrintDocument1
            PrintPreviewDialog1.Show()

            Button1.Enabled = True
            Button3.Enabled = True
            Button5.Enabled = False
            TextBox7.Text = ""
            TextBox6.Text = ""
            TextBox5.Text = ""
            TextBox1.Text = ""
            TextBox4.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            ComboBox2.Text = ""
            ComboBox1.Text = ""
            ComboBox3.Text = ""
            PictureBox1.Dispose()
            PictureBox1.Update()
            PictureBox1.Visible = False
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try


    End Sub
    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        e.Graphics.DrawImage(Image.FromFile(TextBox8.Text), New Point(0, 0))
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
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
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
        
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Try
            If ComboBox4.Text = "" Then
                MsgBox("نام روستا", , "پیغام")
            Else
                address = Form1.TextBox3.Text
                Dim ocn As New System.Data.OleDb.OleDbConnection
                Dim ocm As New System.Data.OleDb.OleDbCommand
                Dim oda As New System.Data.OleDb.OleDbDataAdapter
                Dim ds As New DataSet()
                Dim dt As New DataTable
                Dim dta As New OleDbDataAdapter("SELECT * FROM darkhastLO where roosta='" & ComboBox4.Text & "'", "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
             "atabase Password=" + Form14.TextBox10.Text + "")

                Dim bs As New BindingSource
                ds.Clear()
                dta.Fill(ds, "darkhastLO")
                bs.DataSource = ds
                bs.DataMember = "darkhastLO"
                Me.DataGridView1.DataSource = bs

                DataGridView1.Columns(0).HeaderText = "توضیحات"
                DataGridView1.Columns(1).HeaderText = "آدرس"
                DataGridView1.Columns(2).HeaderText = "موارد قابل گسترش"
                DataGridView1.Columns(3).HeaderText = "وسایل مورد نیاز"
                DataGridView1.Columns(4).HeaderText = "تعداد خانوار"
                DataGridView1.Columns(5).HeaderText = "متراژ"
                DataGridView1.Columns(6).HeaderText = "سایز"
                DataGridView1.Columns(7).HeaderText = "روستا"
                DataGridView1.Columns(8).HeaderText = "بخش"
                DataGridView1.Columns(9).HeaderText = "کروکی"
                DataGridView1.Columns(10).Visible = False
                DataGridView1.Columns(11).Visible = False


                TextBox63.DataBindings.Clear()
                TextBox63.DataBindings.Add("text", bs, "bishtar", True, DataSourceUpdateMode.OnValidation)

                TextBox64.DataBindings.Clear()
                TextBox64.DataBindings.Add("text", bs, "Address", True, DataSourceUpdateMode.OnValidation)

                TextBox65.DataBindings.Clear()
                TextBox65.DataBindings.Add("text", bs, "MGHG", True, DataSourceUpdateMode.OnValidation)

                TextBox66.DataBindings.Clear()
                TextBox66.DataBindings.Add("text", bs, "VMN", True, DataSourceUpdateMode.OnValidation)

                TextBox67.DataBindings.Clear()
                TextBox67.DataBindings.Add("text", bs, "TKH", True, DataSourceUpdateMode.OnValidation)

                TextBox68.DataBindings.Clear()
                TextBox68.DataBindings.Add("text", bs, "ML", True, DataSourceUpdateMode.OnValidation)

                TextBox69.DataBindings.Clear()
                TextBox69.DataBindings.Add("text", bs, "SL", True, DataSourceUpdateMode.OnValidation)

                TextBox70.DataBindings.Clear()
                TextBox70.DataBindings.Add("text", bs, "roosta", True, DataSourceUpdateMode.OnValidation)

                TextBox71.DataBindings.Clear()
                TextBox71.DataBindings.Add("text", bs, "bakhsh", True, DataSourceUpdateMode.OnValidation)

                TextBox9.DataBindings.Clear()
                TextBox9.DataBindings.Add("text", bs, "koruki", True, DataSourceUpdateMode.OnValidation)

                TextBox10.DataBindings.Clear()
                TextBox10.DataBindings.Add("text", bs, "num", True, DataSourceUpdateMode.OnValidation)

                TextBox11.DataBindings.Clear()
                TextBox11.DataBindings.Add("text", bs, "IMGADR", True, DataSourceUpdateMode.OnValidation)



                GroupBox3.Visible = True
                GroupBox3.Size = New System.Drawing.Size(535, 325)
                GroupBox3.Location = New System.Drawing.Point(5, y / 2)

                dt.Dispose()
                oda.Dispose()
                ocm.Dispose()
                ocn.Dispose()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
       
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        GroupBox3.Visible = False
    End Sub

    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        TextBox7.Text = TextBox63.Text
        TextBox6.Text = TextBox64.Text
        TextBox5.Text = TextBox65.Text
        TextBox1.Text = TextBox66.Text
        TextBox4.Text = TextBox67.Text
        TextBox2.Text = TextBox68.Text
        TextBox3.Text = TextBox69.Text
        ComboBox2.Text = TextBox70.Text
        ComboBox1.Text = TextBox71.Text
        ComboBox3.Text = TextBox9.Text
        If TextBox9.Text = "بله" Then
            PictureBox1.Image = Image.FromFile(TextBox11.Text)
        Else
            PictureBox1.Visible = False
        End If
        DataGridView1.Visible = False
        Button1.Enabled = False
        Button3.Enabled = False
        Button5.Enabled = True
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        If (SetupThePrinting()) Then
            Dim MyPrintPreviewDialog As PrintPreviewDialog = New PrintPreviewDialog()
            MyPrintPreviewDialog.Document = myPrintDocument
            MyPrintPreviewDialog.ShowDialog()
        End If
    End Sub

    Private Sub myPrintDocument_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles myPrintDocument.PrintPage
        Dim more As Boolean = class2.DrawDataGridView(e.Graphics)
        If (more = True) Then
            e.HasMorePages = True
        End If
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Try
            Button9.Enabled = False
            Button9.Visible = False
            Button3.BringToFront()
            TextBox8.Text = ""
            PictureBox1.Image = Image.FromFile(Application.StartupPath + "\ck.jpg")
            Dim ocm As New System.Data.OleDb.OleDbCommand
            Dim oda As New System.Data.OleDb.OleDbDataAdapter
            Dim ocn As New System.Data.OleDb.OleDbConnection

            address = Form1.TextBox3.Text
            ocn.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
        "atabase Password=" + Form14.TextBox10.Text + "")
            ocm.Connection = ocn
            ocm.CommandText = "update DarkhastLO SET IMGADR='" & TextBox8.Text & "' where (num='" & 1 & "')"
            ocn.Open()
            ocm.ExecuteNonQuery()
            ocn.Close()
            Button5.Enabled = False
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
        
    End Sub
End Class