Imports System
Imports TwainLib
Imports System.IO
Imports GdiPlusLib
Imports System.Text
Imports System.Data
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Collections
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Runtime.InteropServices

Public Class frmScanApplication
    Inherits System.Windows.Forms.Form
    Implements IMessageFilter
    Dim SavedFileAddress As String = ""
    Public Shared xc As Integer
    Public Shared bc As Boolean = False
#Region "   [ Windows Form Designer generated code ]    "

    Public Sub New()
        MyBase.New()
        Try


            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            tw = New Twain
            tw.Init(Me.Handle)
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try


    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try

    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents btnSelect As System.Windows.Forms.Button
    Friend WithEvents btnAcquire As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents pnlMABox As System.Windows.Forms.Panel
    Friend WithEvents pbMA As System.Windows.Forms.PictureBox
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.btnSelect = New System.Windows.Forms.Button
        Me.btnAcquire = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.pnlMABox = New System.Windows.Forms.Panel
        Me.pbMA = New System.Windows.Forms.PictureBox
        Me.lblStatus = New System.Windows.Forms.Label
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.pnlMABox.SuspendLayout()
        CType(Me.pbMA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSelect
        '
        Me.btnSelect.BackColor = System.Drawing.SystemColors.Window
        Me.btnSelect.Font = New System.Drawing.Font("B Nazanin", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnSelect.ForeColor = System.Drawing.Color.Black
        Me.btnSelect.Location = New System.Drawing.Point(12, 21)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(0, 45)
        Me.btnSelect.TabIndex = 0
        Me.btnSelect.Text = "انتخاب اسکنر"
        Me.btnSelect.UseVisualStyleBackColor = False
        '
        'btnAcquire
        '
        Me.btnAcquire.BackColor = System.Drawing.SystemColors.Window
        Me.btnAcquire.Font = New System.Drawing.Font("B Nazanin", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnAcquire.ForeColor = System.Drawing.Color.Black
        Me.btnAcquire.Location = New System.Drawing.Point(12, 72)
        Me.btnAcquire.Name = "btnAcquire"
        Me.btnAcquire.Size = New System.Drawing.Size(0, 45)
        Me.btnAcquire.TabIndex = 1
        Me.btnAcquire.Text = "اسکن"
        Me.btnAcquire.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.SystemColors.Window
        Me.btnSave.Font = New System.Drawing.Font("B Nazanin", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.Black
        Me.btnSave.Location = New System.Drawing.Point(12, 54)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(112, 45)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "ذخیره"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.SystemColors.Window
        Me.btnExit.Font = New System.Drawing.Font("B Nazanin", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnExit.ForeColor = System.Drawing.Color.Black
        Me.btnExit.Location = New System.Drawing.Point(12, 174)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(0, 45)
        Me.btnExit.TabIndex = 4
        Me.btnExit.Text = "خروج"
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'pnlMABox
        '
        Me.pnlMABox.AutoScroll = True
        Me.pnlMABox.BackColor = System.Drawing.Color.Gray
        Me.pnlMABox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlMABox.Controls.Add(Me.pbMA)
        Me.pnlMABox.Location = New System.Drawing.Point(130, 0)
        Me.pnlMABox.Name = "pnlMABox"
        Me.pnlMABox.Size = New System.Drawing.Size(405, 305)
        Me.pnlMABox.TabIndex = 5
        '
        'pbMA
        '
        Me.pbMA.BackColor = System.Drawing.Color.Black
        Me.pbMA.Location = New System.Drawing.Point(3, 2)
        Me.pbMA.Name = "pbMA"
        Me.pbMA.Size = New System.Drawing.Size(395, 296)
        Me.pbMA.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbMA.TabIndex = 0
        Me.pbMA.TabStop = False
        '
        'lblStatus
        '
        Me.lblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(1, 608)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(131, 32)
        Me.lblStatus.TabIndex = 1
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'frmScanApplication
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(43, Byte), Integer), CType(CType(57, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(532, 305)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlMABox)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnAcquire)
        Me.Controls.Add(Me.btnSelect)
        Me.Controls.Add(Me.lblStatus)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.Name = "frmScanApplication"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "اسکن"
        Me.pnlMABox.ResumeLayout(False)
        CType(Me.pbMA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "   [ Member Variables Decleration Section  ]   "
    Private clData As IntPtr
    Private clTHIA As Image.GetThumbnailImageAbort
    Private boolChecked As Boolean
    Private imgPath As String = ""
    Const pbMaHeight As Int16 = 640
    Const pbMaWidth As Int16 = 465
    Private strImagePath As String = Application.StartupPath.ToString & "\Images\"
    Private strTempImagePath As String = Application.StartupPath.ToString & "\TEMP\"
    Private AppKey As String
#End Region

#Region "   [ frmScanMealApplication_Load Event  ]   "
    Private Sub frmScanMealApplication_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            ' pbMA.Size = New System.Drawing.Size(Me.Width / 2, Me.Height/2)
            ' pnlMABox.Location = New System.Drawing.Point(Me.Size.Width / 6, 5)
            '''' If Picturebox does not contain an image then disable stretch checkbox and btnSave

            ' btnSave.Enabled = Not (pbMA.Image Is Nothing)
            Dim dir As Directory
            ' If the Temp directory does not exists then create it.
            ' This Temp directory is created to store the Captured images before saving the image.
            If Not dir.Exists(strTempImagePath) Then
                dir.CreateDirectory(strTempImagePath)
            End If
            ' If folder Images does not exist then create which contains the Images captured by 
            ' the scanner and webcams.
            If Not dir.Exists(strImagePath) Then
                dir.CreateDirectory(strImagePath)
            End If
            If (Twain.ScreenBitDepth < 15) Then
                MessageBox.Show("Need high/true-color video mode!", "Screen Bit Depth", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try

    End Sub
#End Region

#Region "   [ chkStretchImage_CheckedChanged Event  ]   "
    Private Sub chkStretchImage_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            If pbMA.Image Is Nothing Then
                MsgBox("ابتدا تصویر را اسکن کنید", MsgBoxStyle.Information, "Meal Application")

                Exit Sub
            End If
            boolChecked = Not boolChecked
            'if checkbox is checked then increase the size of the image else decrease the size.
            If (Not pbMA.SizeMode = PictureBoxSizeMode.StretchImage) And (boolChecked = True) Then
                pbMA.SizeMode = PictureBoxSizeMode.StretchImage
                ' pbMA.Size = New Drawing.Size(890, 656)
            Else
                pbMA.SizeMode = PictureBoxSizeMode.Normal
                ' pbMA.Size = New System.Drawing.Size(pbMaWidth, pbMaHeight)
            End If
        Catch ex As Exception
            MsgBox("ابتدا تصویر را اسکن کنید", MsgBoxStyle.Information, "mawin")
        End Try
    End Sub
#End Region

#Region "   [ Scanner Related Code ]   "

#Region "   [ Weird Functions  ]"

#Region "   [ Weird Declerations اسکن شده به برنامه ]   "

    Private bmi As BITMAPINFOHEADER
    Private bmprect As Rectangle
    Private dibhand As IntPtr
    Private bmpptr As IntPtr
    Private pixptr As IntPtr
    <DllImport("kernel32.dll", ExactSpelling:=True)> _
Friend Shared Function GlobalLock(ByVal handle As IntPtr) As IntPtr
    End Function
    Protected Function GetPixelInfo(ByVal bmpptr As IntPtr) As IntPtr
        Try
            bmi = New BITMAPINFOHEADER
            Marshal.PtrToStructure(bmpptr, bmi)
            bmprect.X = bmprect.Y = 0
            bmprect.Width = bmi.biWidth
            bmprect.Height = bmi.biHeight
            If bmi.biSizeImage = 0 Then
                bmi.biSizeImage = ((((bmi.biWidth * bmi.biBitCount) + 31) And Not 31) >> 3) * bmi.biHeight
            End If
            Dim p As Integer = bmi.biClrUsed
            If (p = 0) AndAlso (bmi.biBitCount <= 8) Then
                p = 1 << bmi.biBitCount
            End If
            p = (p * 4) + bmi.biSize + CInt(bmpptr.ToInt32) 'CType(bmpptr, Integer) '.ToInt32
            Dim intP As New IntPtr(p)
            Return intP
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try

    End Function
#End Region

    Public Sub ShowMe(ByVal dibhandp As IntPtr)
        bmprect = New Rectangle(0, 0, 0, 0)
        dibhand = dibhandp
        bmpptr = GlobalLock(dibhand)
        pixptr = GetPixelInfo(bmpptr)
    End Sub

#Region "   [ BITMAPINFO Header Class ]   "
    <StructLayout(LayoutKind.Sequential)> _
            Friend Class BITMAPINFOHEADER
        Public biSize As Integer
        Public biWidth As Integer
        Public biHeight As Integer
        Public biPlanes As Short
        Public biBitCount As Short
        Public biCompression As Integer
        Public biSizeImage As Integer
        Public biXPelsPerMeter As Integer
        Public biYPelsPerMeter As Integer
        Public biClrUsed As Integer
        Public biClrImportant As Integer
    End Class
#End Region

#End Region

#Region "   [ Button Click Events  ]   "
    ''''''''''''''''''''''''''''''''''''''''''''''
    '' For Twain Classes
    Private msgfilter As Boolean
    Private tw As Twain
    Private picnumber As Integer = 0
    ''''''''''''''''''''''''''''''''''''''''''''''
    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        tw.[Select]()
    End Sub
    Private Sub btnAcquire_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAcquire.Click
        If Not msgfilter Then
            '--------------------------------------------,
            ' Remove the old image from the picturebox   '
            If Not pbMA.Image Is Nothing Then
                pbMA.Image = Nothing
                pbMA.Refresh()                               '
            End If
            lblStatus.Text = ""
            '--------------------------------------------'
            Me.Enabled = False
            msgfilter = True
            Application.AddMessageFilter(Me)
            tw.Acquire()
        End If
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        DeleteTempFiles(strTempImagePath)
        Me.Close()
    End Sub
#End Region

#Region "   [ User - Defined Functions  ]   "
    Public Function PreFilterMessage(ByRef m As System.Windows.Forms.Message) As Boolean _
                                     Implements System.Windows.Forms.IMessageFilter.PreFilterMessage

        Dim cmd As TwainCommand = tw.PassMessage(m)
        If cmd = TwainCommand.Not Then
            Return False
        End If
        Select Case cmd
            Case TwainCommand.CloseRequest
                EndingScan()
                tw.CloseSrc()
                Exit Function
            Case TwainCommand.CloseOk
                EndingScan()
                tw.CloseSrc()
                Exit Function
            Case TwainCommand.DeviceEvent
                Exit Function
            Case TwainCommand.TransferReady
                Dim pics As ArrayList = tw.TransferPictures()
                EndingScan()
                tw.CloseSrc()
                picnumber = picnumber + 1
                Dim i As Integer
                For i = 0 To pics.Count - 1 Step i + 1
                    Dim img As IntPtr = CType(pics(i), IntPtr)
                    Me.ShowMe(img)
                Next
                Dim l_imgPath
                ' Get new Guid and save it in MealAppKey variable.
                GetId(AppKey)
                l_imgPath = strTempImagePath & CStr(AppKey) & ".Jpg"
                Gdip.SaveDIBAs(l_imgPath, bmpptr, pixptr)
                '''' This function sets the image to the Picture box picking from the source.
                SetImageInPB()

                ' If Picturebox contains an image then enable stretch checkbox and btnSave
                Exit Select
        End Select
        Return True
    End Function
    Private Sub EndingScan()
        If msgfilter Then
            Application.RemoveMessageFilter(Me)
            msgfilter = False
            Me.Enabled = True
            Me.Activate()
            Form1.Label18.Visible = False
            Form1.Label10.Visible = True

        End If
    End Sub
    Private Sub SetImageInPB()
        Try
            Dim _imgPath As String = strTempImagePath & CStr(AppKey) & ".Jpg"
            Dim fs As New FileStream(_imgPath, FileMode.Open, FileAccess.ReadWrite)
            pbMA.Image = Image.FromStream(fs, True)
            fs.Close()
            fs = Nothing
            pbMA.Invalidate()
        Catch ex As Exception
            ' Do nothing
        End Try
    End Sub
    Private Function GetImageFromStream(ByVal ImagePath As String) As Image
        Try
            Dim _imgPath As String = ImagePath
            Dim fs As New FileStream(_imgPath, FileMode.Open, FileAccess.ReadWrite)
            Dim img As Image = Image.FromStream(fs, True)
            fs.Close()
            fs = Nothing
            GetImageFromStream = img
            'File.Copy(imgPath, Application.StartupPath + "\Images.jpg", True)

        Catch ex As Exception
            ' Do nothing
        End Try
    End Function
    Private Sub GetId(ByRef MealAppKey As String)
        MealAppKey = Guid.NewGuid.ToString.Substring(0, 5)
    End Sub
    Private Sub DeleteTempFiles(ByVal strTempPath As String)
        Try
            For Each fls As String In Directory.GetFiles(strTempPath)
                File.Delete(fls)
            Next
        Catch ex As Exception
            ' Do nothing
        End Try
    End Sub
#End Region

#End Region

#Region "   [ Form Closing Event  ]   "
    Private Sub frmScanMealApplication_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        DeleteTempFiles(strTempImagePath)
    End Sub
#End Region

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        tw.Finish()
        imgPath = strTempImagePath & CStr(AppKey) & ".Jpg"
        File.Copy(imgPath, Application.StartupPath + "\Images\" + Form1.Label7.Text + ".jpg", True)
        Form1.Label21.Text = Application.StartupPath + "\Images\" + Form1.Label7.Text + ".jpg"
        Form1.PictureBox1.Image = Image.FromFile(Form1.Label21.Text)
        If File.Exists(imgPath) Then
            File.Delete(imgPath)
        End If
        Form2.WindowState = FormWindowState.Normal
        Me.Close()
    End Sub
End Class