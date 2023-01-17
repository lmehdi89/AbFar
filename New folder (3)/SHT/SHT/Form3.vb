Imports System.Data.SqlClient
Imports System.Data
Imports System.IO
Public Class Form3

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Form2.f2 = False
        'Me.Location = New Drawing.Point(10, 70)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        TextBox1.Visible = True
        Label2.Text = ComboBox1.Text
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Form2.PictureBox1.Visible = False
            Dim st As String
            Dim st2 As String
            Select Case ComboBox1.Text
                Case "شماره شناسایی"
                    st = "ID = '"
                    st2 = "'"
                Case "نام"
                    st = "FN Like N'%"
                    st2 = "%'"
                Case "نام خانوادگی"
                    st = "LN Like N'% "
                    st2 = "%'"
                Case "نام پدر"
                    st = "PN Like N'%"
                    st2 = "%'"
                Case "شماره شناسنامه"
                    st = "SN Like N'%"
                    st2 = "%'"
                Case "شماره ملی"
                    st = "CN Like N'% "
                    st2 = "%'"
            End Select
            Dim ocn As New SqlConnection
            Dim ocm As New SqlCommand
            Dim oda As New SqlDataAdapter
            Dim ds As New DataSet
            Dim da As New DataTable
            Dim bs As New BindingSource
            ocn.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=" + Application.StartupPath + "\BN.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"
            ocm.Connection = ocn
            ocm.CommandText = "select * from INF where " + st + "" + TextBox1.Text + "" + st2
            oda.SelectCommand = ocm
            If oda.Fill(ds, "INF") Then
                GroupBox1.Visible = False
                Button2.Visible = True
                bs.DataSource = ds
                bs.DataMember = "INF"
                DataGridView1.Visible = True
                Me.DataGridView1.DataSource = bs

                DataGridView1.Size = New Size(683, 245)
                Me.Size = New Size(705, 305)
                Me.BringToFront()
                Form2.Label1.Size = New Size(114, 55)
                Form2.Label1.Location = New Point(713, 88)
                Form2.Label1.TextAlign = ContentAlignment.MiddleLeft
                Form2.Label2.Text = " جستجو "
                Form2.Label2.Size = New Size(114, 55)
                Form2.Label2.Location = New Point(713, 143)
                Form2.Label2.TextAlign = ContentAlignment.MiddleLeft
                DataGridView1.Columns(0).HeaderText = "شماره شناسایی"
                DataGridView1.Columns(0).Width = 80
                DataGridView1.Columns(1).HeaderText = "نام"
                DataGridView1.Columns(2).HeaderText = "نام خانوادگی"
                DataGridView1.Columns(3).HeaderText = "نام پدر"
                DataGridView1.Columns(4).HeaderText = "شماره شناسنامه "
                DataGridView1.Columns(5).HeaderText = "شماره ملی"
                DataGridView1.Columns(6).HeaderText = "تاریخ تولد"
                DataGridView1.Columns(7).Visible = False
                DataGridView1.Sort(DataGridView1.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
            Else
                MsgBox("موردی یافت نشد")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            GroupBox1.Visible = True
            Button2.Visible = False
            'DataGridView1.Dispose()
            DataGridView1.Visible = False
            Me.Size = New Size(555, 305)
            Form2.Label1.Size = New Size(182, 55)
            Form2.Label1.Location = New Point(645, 88)
            Form2.Label1.TextAlign = ContentAlignment.MiddleCenter
            Form2.Label2.Text = "جستجو"
            Form2.Label2.Size = New Size(182, 55)
            Form2.Label2.Location = New Point(645, 143)
            Form2.Label2.TextAlign = ContentAlignment.MiddleCenter
            Form1.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub DataGridView1_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        Try
            Form1.Label7.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString
            Dim ocn As New SqlConnection
            Dim ocm As New SqlCommand
            Dim oda As New SqlDataAdapter
            Dim ds As New DataSet
            Dim da As New DataTable
            ocn.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=" + Application.StartupPath + "\BN.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"
            ocm.Connection = ocn
            ocm.CommandText = "select * from INF where ID='" & Form1.Label7.Text & "'"
            oda.SelectCommand = ocm
            Form1.TextBox1.DataBindings.Clear()
            Form1.TextBox2.DataBindings.Clear()
            Form1.TextBox3.DataBindings.Clear()
            Form1.TextBox4.DataBindings.Clear()
            Form1.TextBox5.DataBindings.Clear()
            Form1.TextBox6.DataBindings.Clear()
            Form1.Label21.DataBindings.Clear()
            If oda.Fill(ds, "INF") Then
                Form1.MdiParent = Form2
                Form1.Parent = Form2.Panel1
                Form1.Visible = True
                Form1.BringToFront()
                Form1.Show()
                Me.BringToFront()
                Form1.TextBox1.DataBindings.Add(New Binding("Text", ds, "INF.FN"))
                Form1.TextBox2.DataBindings.Add(New Binding("Text", ds, "INF.LN"))
                Form1.TextBox3.DataBindings.Add(New Binding("Text", ds, "INF.PN"))
                Form1.TextBox4.DataBindings.Add(New Binding("Text", ds, "INF.SN"))
                Form1.TextBox5.DataBindings.Add(New Binding("Text", ds, "INF.CN"))
                Form1.TextBox6.DataBindings.Add(New Binding("Text", ds, "INF.DT"))
                Form1.Label21.DataBindings.Add(New Binding("Text", ds, "INF.IM"))
                If File.Exists(Form1.Label21.Text) Then
                    Form1.PictureBox1.Image = Image.FromFile(Form1.Label21.Text)
                Else
                    Form1.PictureBox1.Image = Image.FromFile(Application.StartupPath + "\Images\NoPhoto.jpg")
                End If
              
            End If
            oda.Dispose()
            ocm.Dispose()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub DataGridView1_RowHeaderMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseDoubleClick
        Try
            Form1.Label8.Visible = False
            Form1.Label10.Visible = True
            GroupBox1.Visible = True
            Button2.Visible = False
            'DataGridView1.Dispose()
            DataGridView1.Visible = False
            Me.Location = New Drawing.Point(10, 70)
            Me.Size = New Size(555, 305)
            Form2.Label1.Size = New Size(182, 55)
            Form2.Label1.Location = New Point(645, 88)
            Form2.Label1.TextAlign = ContentAlignment.MiddleCenter
            Form2.Label2.Text = "جستجو"
            Form2.Label2.Size = New Size(182, 55)
            Form2.Label2.Location = New Point(645, 143)
            Form2.Label2.TextAlign = ContentAlignment.MiddleCenter
            Form1.Label11.Visible = True
            Form1.Label22.Visible = True
            Me.Close()
            Form2.f1 = False
            Form2.f2 = True
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub TextBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.Enter
        InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(New System.Globalization.CultureInfo("Fa"))
    End Sub

    Private Sub Form3_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Form2.PictureBox1.Visible = True
        Form2.f1 = True
        Form2.f2 = True
    End Sub
End Class