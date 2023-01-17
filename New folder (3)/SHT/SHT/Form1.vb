Imports Microsoft.Win32.Registry
Imports System.Data.SqlClient
Imports System.Data
Imports System.IO
Imports System
Imports TwainLib
Imports GdiPlusLib
Imports System.Text
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Collections
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Runtime.InteropServices

Public Class Form1

    Inherits System.Windows.Forms.Form
    Dim SavedFileAddress As String = ""

    Public Shared b As Boolean



    Private Sub Form1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form2.f1 = True
        Form2.f2 = True
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Panel1.Font = New System.Drawing.Font("B Zar", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
            giv()
            Form2.f1 = False
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
        'Me.Location = New Drawing.Point(10, 70)
       
    End Sub
    Public Function giv()
        Try
            Dim registry As Microsoft.Win32.RegistryKey
            registry = CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion", True)
            Label13.Text = registry.GetValue("UN", "شرکت تعاونی مصرف کارکنان جهاد کشاورزی گیلان")
            Label14.Text = registry.GetValue("F1", "نام                      :")
            Label15.Text = registry.GetValue("F2", "نام خانوادگی      :")
            Label16.Text = registry.GetValue("F3", "نام پدر               :")
            Label17.Text = registry.GetValue("F4", "شماره شناسنامه:")
            Label18.Text = registry.GetValue("F5", "شماره ملی         :")
            Label19.Text = registry.GetValue("F6", "تاریخ تولد          :")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return 0
    End Function
    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "    /  /" Then
            MsgBox("همه موارد باید تکمیل شوند", , "اخطار")
        Else
            If MsgBox("آیا شما مطمئن به ثبت این اطلاعات هستید؟", MsgBoxStyle.YesNo, "اخطار") = MsgBoxResult.Yes Then

                regi()
            End If
        End If
    End Sub

    '   Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    OpenFileDialog1.ShowDialog()
    '   PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
    '  End Sub
    Public Function regi()
        Try
            If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "    /  /" Then
                MsgBox("همه موارد باید تکمیل شوند", , "اخطار")
            Else
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
                ocm.Connection = ocn
                ocm1.Connection = ocn
                ocm2.Connection = ocn
                ocm1.CommandText = "select * from INF where CN ='" & TextBox5.Text & "'"
                oda.SelectCommand = ocm1
                If oda.Fill(da) Then
                    MsgBox("این شماره ملی قبلا ثبت شده است", , "خطا")
                Else
                    ocm.CommandText = "INSERT INTO INF (ID,FN,LN,PN,SN,CN,DT,IM) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)"
                    ocm.Parameters.Clear()
                    ocm.Parameters.Add("@p1", Label7.Text)
                    ocm.Parameters.Add("@p2", TextBox1.Text)
                    ocm.Parameters.Add("@p3", TextBox2.Text)
                    ocm.Parameters.Add("@p4", TextBox3.Text)
                    ocm.Parameters.Add("@p5", TextBox4.Text)
                    ocm.Parameters.Add("@p6", TextBox5.Text)
                    ocm.Parameters.Add("@p7", TextBox6.Text)
                    ocm.Parameters.Add("@p8", Label21.Text)
                    ocn.Open()
                    ocm.ExecuteNonQuery()
                    ocn.Close()
                    MsgBox("اطلاعات وارد شده شما ثبت شد", , "پیغام")
                    print(Label21.Text)
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return 0
    End Function
    Public Function upd(ByVal sta As String)
        Try

            Dim ocn As New SqlConnection
            Dim ocm As New SqlCommand
            Dim oda As New SqlDataAdapter
            ocn.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=" + Application.StartupPath + "\BN.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"
            ocm.Connection = ocn
            ocm.CommandText = "DELETE FROM INF WHERE ID  ='" & Label7.Text & "'"
            ocn.Open()
            ocm.ExecuteNonQuery()
            ocn.Close()
            ocm.Dispose()

            ocm.CommandText = "INSERT INTO INF (ID,FN,LN,PN,SN,CN,DT,IM) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)"
            ocm.Parameters.Clear()
            ocm.Parameters.Add("@p1", Label7.Text)
            ocm.Parameters.Add("@p2", TextBox1.Text)
            ocm.Parameters.Add("@p3", TextBox2.Text)
            ocm.Parameters.Add("@p4", TextBox3.Text)
            ocm.Parameters.Add("@p5", TextBox4.Text)
            ocm.Parameters.Add("@p6", TextBox5.Text)
            ocm.Parameters.Add("@p7", TextBox6.Text)
            ocm.Parameters.Add("@p8", sta)
            ocn.Open()
            ocm.ExecuteNonQuery()
            ocn.Close()
            print(Label21.Text)
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            TextBox5.Text = ""
            TextBox6.Text = ""
            Label7.Text = ""
            Label21.Text = ""
            Button1.Enabled = False
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return 0
    End Function
    Public Function print(ByVal sor As String)
        Try

            Dim registry As Microsoft.Win32.RegistryKey
            Dim st As String
            Dim st4 As String
            Dim st2 As String = Application.StartupPath + "\Images\Untitle.jpg"
            Dim st3 As String = Application.StartupPath + "\Images\Untitle2.jpg"
            registry = CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion", True)
            st = registry.GetValue("IM", st2)
            st4 = registry.GetValue("IM2", st3)
            If File.Exists(st) Then
                Form2.CrystalReportViewer1.Visible = True
                Dim rpt As New CrystalReport1

                Try
                    ' here i have define a simple datatable inwhich image will recide
                    Dim dt As New DataTable
                    ' object of data row
                    Dim drow As DataRow
                    ' add the column in table to store the image of Byte array type
                    dt.Columns.Add("IM2", System.Type.GetType("System.Byte[]"))
                    dt.Columns.Add("IM1", System.Type.GetType("System.Byte[]"))
                    dt.Columns.Add("IM3", System.Type.GetType("System.Byte[]"))
                    drow = dt.NewRow
                    ' define the filestream object to read the image
                    Dim fs As FileStream
                    Dim fs2 As FileStream
                    Dim fs3 As FileStream
                    ' define te binary reader to read the bytes of image
                    Dim br As BinaryReader
                    Dim br2 As BinaryReader
                    Dim br3 As BinaryReader
                    ' check the existance of image
                    fs2 = File.OpenRead(st)
                    fs3 = File.OpenRead(st4)
                    If File.Exists(sor) Then
                        ' open image in file stream
                        fs = File.OpenRead(sor)
                    Else ' if phot does not exist show the nophoto.jpg file
                        fs = File.OpenRead(Application.StartupPath + "\Images\NoPhoto.jpg")
                    End If

                    ' initialise the binary reader from file streamobject
                    br = New BinaryReader(fs)
                    br2 = New BinaryReader(fs2)
                    br3 = New BinaryReader(fs3)
                    ' define the byte array of filelength
                    Dim imgbyte(fs.Length) As Byte
                    Dim imgbyte2(fs2.Length) As Byte
                    Dim imgbyte3(fs3.Length) As Byte
                    ' read the bytes from the binary reader
                    imgbyte = br.ReadBytes(Convert.ToInt32((fs.Length)))
                    imgbyte2 = br2.ReadBytes(Convert.ToInt32((fs2.Length)))
                    imgbyte3 = br3.ReadBytes(Convert.ToInt32((fs3.Length)))
                    drow(0) = imgbyte
                    drow(1) = imgbyte2
                    drow(2) = imgbyte3 ' add the image in bytearray
                    dt.Rows.Add(drow)       ' add row into the datatable
                    br.Close()              ' close the binary reader
                    fs.Close()
                    fs2.Close()
                    fs3.Close() ' close the file stream
                    Dim rptobj As New CrystalReport1    ' object of crystal report
                    rpt.SetDataSource(dt)            ' set the datasource of crystalreport object
                    '    Form2.CrystalReportViewer1.ReportSource = rptobj  'set the report source
                Catch ex As Exception
                    ' error handling
                    MsgBox(ex.ToString)
                End Try
                rpt.SetParameterValue("p1", TextBox1.Text)
                rpt.SetParameterValue("p2", TextBox2.Text)
                rpt.SetParameterValue("p3", TextBox3.Text)
                rpt.SetParameterValue("p4", TextBox4.Text)
                rpt.SetParameterValue("p5", TextBox5.Text)
                rpt.SetParameterValue("p6", TextBox6.Text)
                rpt.SetParameterValue("SE", Label7.Text)
                rpt.SetParameterValue("p7", Label13.Text)
                rpt.SetParameterValue("p8", Label14.Text)
                rpt.SetParameterValue("p9", Label15.Text)
                rpt.SetParameterValue("p10", Label16.Text)
                rpt.SetParameterValue("p11", Label17.Text)
                rpt.SetParameterValue("p12", Label18.Text)
                rpt.SetParameterValue("p13", Label19.Text)
                rpt.SetParameterValue("p14", "مخصوص اعضا")
                rpt.SetParameterValue("p15", "(شماره ثبت 1699)")
                Form2.CrystalReportViewer1.ReportSource = rpt
                Me.Close()
                Form2.Label2.Enabled = True
                Form2.Button1.Visible = True
                Form2.CrystalReportViewer1.BringToFront()
                Form2.Button1.BringToFront()
            Else
                MsgBox("تمپلیت در مسیر برنامه وجود ندارد", , "اخطار")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return 0
    End Function

    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label9.Click
        Me.Close()
        Form2.Label2.Enabled = True
        Form2.PictureBox1.Image = Global.WindowsApplication1.My.Resources.te4
    End Sub

    Private Sub Label10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label10.Click
        print(Label21.Text)
    End Sub

    Private Sub Label11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label11.Click
        Try

            If MsgBox("آیا مطمئن به حذف این مورد هستید؟", MsgBoxStyle.YesNo, "اخطار") = MsgBoxResult.Yes Then
                Dim ocn As New SqlConnection
                Dim ocm As New SqlCommand
                Dim oda As New SqlDataAdapter
                ocn.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=" + Application.StartupPath + "\BN.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"
                ocm.Connection = ocn
                PictureBox1.Image.Dispose()
                File.Delete(Label21.Text)
                ocm.CommandText = "DELETE FROM INF WHERE ID  ='" & Label7.Text & "'"
                ocn.Open()
                ocm.ExecuteNonQuery()
                ocn.Close()
                ocm.Dispose()
                MsgBox("حذف شد")
                PictureBox1.Image = Image.FromFile(Application.StartupPath + "\Images\NoPhoto.jpg")
                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox4.Text = ""
                TextBox5.Text = ""
                TextBox6.Text = ""
                Label7.Text = ""
                Label8.Visible = True
                Label10.Visible = False
                Label11.Visible = False
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub TextBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.Enter
        InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(New System.Globalization.CultureInfo("Fa"))
    End Sub

    Private Sub TextBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.Enter
        InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(New System.Globalization.CultureInfo("Fa"))
    End Sub

    Private Sub TextBox3_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.Enter
        InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(New System.Globalization.CultureInfo("Fa"))
    End Sub

    Private Sub TextBox4_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.Enter
        InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(New System.Globalization.CultureInfo("Fa"))
    End Sub

    Private Sub TextBox5_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox5.Enter
        InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(New System.Globalization.CultureInfo("Fa"))
    End Sub

    Private Sub TextBox6_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(New System.Globalization.CultureInfo("Fa"))
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        b = False
        If Label21.Text = "" Then
            GroupBox1.Enabled = False
            GroupBox2.Visible = True
            GroupBox2.Enabled = True
            GroupBox2.BringToFront()
        Else
            If MsgBox("آیا مطمئن به تغییر تصویر می باشید؟", MsgBoxStyle.YesNo, "پیغام") = MsgBoxResult.Yes Then
                GroupBox1.Enabled = False
                GroupBox2.Visible = True
                GroupBox2.Enabled = True
                GroupBox2.BringToFront()
            End If
        End If


    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        GroupBox1.Enabled = True
        GroupBox2.Visible = False
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "JPEG File (*.jpg)|*.jpg|TIF File (*.tif)|*.tif "
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Form2.WindowState = FormWindowState.Minimized
        frmScanApplication.Show()
        frmScanApplication.BringToFront()
        frmScanApplication.btnSelect.PerformClick()
        frmScanApplication.btnAcquire.PerformClick()
        '  Form2.ShowInTaskbar = False
        '    frmScanApplication.ShowInTaskbar = True

        GroupBox1.Enabled = True
        GroupBox2.Visible = False
    End Sub

    Private Sub OpenFileDialog1_FileOk(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        Try
            PictureBox1.Image.Dispose()
            Label21.Text = OpenFileDialog1.FileName
            ' MsgBox(Application.StartupPath + "\Image")
            ' IO.File.Copy(OpenFileDialog1.FileName, Application.StartupPath)
            File.Copy(Label21.Text, Application.StartupPath + "\Images\" + Label7.Text + ".jpg", True)
            PictureBox1.Image = Image.FromFile(Label21.Text)
            Label21.Text = Application.StartupPath + "\Images\" + Label7.Text + ".jpg"

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Label22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label22.Click
        If MsgBox("آیا مطمئن به اصلاح این مورد هستید؟", MsgBoxStyle.YesNo, "اخطار") = MsgBoxResult.Yes Then
            If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "    /  /" Then
                MsgBox("همه موارد باید تکمیل شوند", , "اخطار")
            Else
                Dim ocn As New SqlConnection
                Dim ocm As New SqlCommand
                Dim oda As New SqlDataAdapter
                ocn.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=" + Application.StartupPath + "\BN.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"
                ocm.Connection = ocn
                ocm.CommandText = "DELETE FROM INF WHERE ID  ='" & Label7.Text & "'"
                ocn.Open()
                ocm.ExecuteNonQuery()
                ocn.Close()
                ocm.Dispose()
                regi()
                Label22.Visible = False
                Label8.Visible = True
                Label10.Visible = False
                Label11.Visible = False
            End If
        End If
    End Sub

    Private Sub TextBox5_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox5.KeyPress
        If Not IsNumeric(e.KeyChar) And e.KeyChar <> Convert.ToChar(Keys.Back) And e.KeyChar <> Convert.ToChar(Keys.Delete) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox4_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress
        If Not IsNumeric(e.KeyChar) And e.KeyChar <> Convert.ToChar(Keys.Back) And e.KeyChar <> Convert.ToChar(Keys.Delete) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If IsNumeric(e.KeyChar) And e.KeyChar <> Convert.ToChar(Keys.Back) And e.KeyChar <> Convert.ToChar(Keys.Delete) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If IsNumeric(e.KeyChar) And e.KeyChar <> Convert.ToChar(Keys.Back) And e.KeyChar <> Convert.ToChar(Keys.Delete) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox3_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox3.KeyPress
        If IsNumeric(e.KeyChar) And e.KeyChar <> Convert.ToChar(Keys.Back) And e.KeyChar <> Convert.ToChar(Keys.Delete) Then
            e.Handled = True
        End If
    End Sub
End Class

