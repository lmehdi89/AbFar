Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine

Public Class Form23
    Public y As Integer
    Public x As Integer
    Public address As String
    Public test As Boolean = True
    Public allow As Boolean = False
    Private da As OleDbDataAdapter
    Public arrey(16, 12) As Integer
    Public Shared u(16) As Integer
    Dim rpt As New CrystalReport21
    Public Function clear()
        For z As Integer = 0 To 15
            For k As Integer = 0 To 11
                arrey(z, k) = 0
            Next k
        Next z
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        ListBox3.Items.Clear()
        ListBox4.Items.Clear()
        ListBox5.Items.Clear()
        ListBox6.Items.Clear()
        ListBox7.Items.Clear()
        ListBox8.Items.Clear()
        ListBox9.Items.Clear()
        ListBox10.Items.Clear()
        ListBox11.Items.Clear()
        ListBox12.Items.Clear()
        ListBox13.Items.Clear()

        TextBox16.Text = ""
        TextBox17.Text = ""
        TextBox18.Text = ""
        TextBox19.Text = ""
        TextBox47.Text = ""
        TextBox48.Text = ""
        TextBox49.Text = ""
        TextBox50.Text = ""
        TextBox51.Text = ""
        TextBox52.Text = ""
        TextBox53.Text = ""
        TextBox54.Text = ""
        TextBox55.Text = ""
        Return 0
    End Function
    Public Function L_box()
        For z As Integer = 15 To 0 Step -1
            u(z) = 0
        Next z
        For z As Integer = 15 To 0 Step -1
            ListBox1.Items.Add("")
            ListBox2.Items.Add("")
            ListBox3.Items.Add("")
            ListBox4.Items.Add("")
            ListBox5.Items.Add("")
            ListBox6.Items.Add("")
            ListBox7.Items.Add("")
            ListBox8.Items.Add("")
            ListBox9.Items.Add("")
            ListBox10.Items.Add("")
            ListBox11.Items.Add("")
            ListBox12.Items.Add("")
            ListBox13.Items.Add("")
        Next z
        For z As Integer = 15 To 0 Step -1
            For k As Integer = ComboBox4.SelectedIndex To ComboBox5.SelectedIndex
                If k = 0 Then
                    ListBox1.Items(z) = arrey(z, k)
                    u(z) += ListBox1.Items(z)
                    ListBox13.Items(z) = u(z)
                ElseIf k = 1 Then
                    ListBox2.Items(z) = arrey(z, k)
                    u(z) += ListBox2.Items(z)
                    ListBox13.Items(z) = u(z)
                ElseIf k = 2 Then
                    ListBox3.Items(z) = arrey(z, k)
                    u(z) += ListBox3.Items(z)
                    ListBox13.Items(z) = u(z)
                ElseIf k = 3 Then
                    ListBox4.Items(z) = arrey(z, k)
                    u(z) += ListBox4.Items(z)
                    ListBox13.Items(z) = u(z)
                ElseIf k = 4 Then
                    ListBox5.Items(z) = arrey(z, k)
                    u(z) += ListBox5.Items(z)
                    ListBox13.Items(z) = u(z)
                ElseIf k = 5 Then
                    ListBox6.Items(z) = arrey(z, k)
                    u(z) += ListBox6.Items(z)
                    ListBox13.Items(z) = u(z)
                ElseIf k = 6 Then
                    ListBox7.Items(z) = arrey(z, k)
                    u(z) += ListBox7.Items(z)
                    ListBox13.Items(z) = u(z)
                ElseIf k = 7 Then
                    ListBox8.Items(z) = arrey(z, k)
                    u(z) += ListBox8.Items(z)
                    ListBox13.Items(z) = u(z)
                ElseIf k = 8 Then
                    ListBox9.Items(z) = arrey(z, k)
                    u(z) += ListBox9.Items(z)
                    ListBox13.Items(z) = u(z)
                ElseIf k = 9 Then
                    ListBox10.Items(z) = arrey(z, k)
                    u(z) += ListBox10.Items(z)
                    ListBox13.Items(z) = u(z)
                ElseIf k = 10 Then
                    ListBox11.Items(z) = arrey(z, k)
                    u(z) += ListBox11.Items(z)
                    ListBox13.Items(z) = u(z)
                ElseIf k = 11 Then
                    ListBox12.Items(z) = arrey(z, k)
                    u(z) += ListBox12.Items(z)
                    ListBox13.Items(z) = u(z)

                End If
            Next k
        Next z

        For m As Integer = 0 To 3
            ListBox1.Items(m) = ""
            ListBox2.Items(m) = ""
            ListBox3.Items(m) = ""
            ListBox4.Items(m) = ""
            ListBox5.Items(m) = ""
            ListBox6.Items(m) = ""
            ListBox7.Items(m) = ""
            ListBox8.Items(m) = ""
            ListBox9.Items(m) = ""
            ListBox10.Items(m) = ""
            ListBox11.Items(m) = ""
            ListBox12.Items(m) = ""
            ListBox13.Items(m) = ""
        Next m
        For m As Integer = 6 To 8
            ListBox1.Items(m) = ""
            ListBox2.Items(m) = ""
            ListBox3.Items(m) = ""
            ListBox4.Items(m) = ""
            ListBox5.Items(m) = ""
            ListBox6.Items(m) = ""
            ListBox7.Items(m) = ""
            ListBox8.Items(m) = ""
            ListBox9.Items(m) = ""
            ListBox10.Items(m) = ""
            ListBox11.Items(m) = ""
            ListBox12.Items(m) = ""
            ListBox13.Items(m) = ""
        Next m

        For m As Integer = 11 To 16 Step 2
            ListBox1.Items(m) = ""
            ListBox2.Items(m) = ""
            ListBox3.Items(m) = ""
            ListBox4.Items(m) = ""
            ListBox5.Items(m) = ""
            ListBox6.Items(m) = ""
            ListBox7.Items(m) = ""
            ListBox8.Items(m) = ""
            ListBox9.Items(m) = ""
            ListBox10.Items(m) = ""
            ListBox11.Items(m) = ""
            ListBox12.Items(m) = ""
            ListBox13.Items(m) = ""
        Next m
    End Function

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Select Case ComboBox1.Text
            Case "کل روستاها"
                ComboBox2.Visible = False
                ComboBox3.Visible = False
                ComboBox2.Text = ""
                ComboBox3.Text = ""
                Label2.Visible = False
                Label3.Visible = False
                Button2.Visible = False
            Case "بخش"
                ComboBox3.Visible = False
                ComboBox2.Visible = True
                ComboBox2.Text = ""
                ComboBox3.Text = ""
                Label2.Visible = True
                Label3.Visible = False
                Button2.Visible = False
            Case "روستا"
                ComboBox3.Visible = True
                ComboBox2.Visible = True
                ComboBox2.Text = ""
                ComboBox3.Text = ""
                Label2.Visible = True
                Label3.Visible = True
                Button2.Visible = False
        End Select
    End Sub

    Private Sub ComboBox2_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox2.DropDown
        test = True
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        If Not test Then
            Exit Sub
        Else
            Dim ocn As New System.Data.OleDb.OleDbConnection
            Dim ocm As New System.Data.OleDb.OleDbCommand
            Dim oda As New System.Data.OleDb.OleDbDataAdapter
            Dim ds As New DataSet()

            ComboBox3.Items.Clear()
            ComboBox3.Text = ""


            ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\Data.mdb"
            ocm.Connection = ocn
            ocm.CommandText = "SELECT roosta FROM Roostaha where bakhsh='" & ComboBox2.SelectedItem & "'"
            oda.SelectCommand = ocm
            da = New OleDbDataAdapter(ocm.CommandText, ocn)
            da.Fill(ds, "Roostaha")

            Do
                TextBox36.Text = TextBox35.Text
                TextBox35.DataBindings.Add(New Binding("Text", ds, "Roostaha.roosta"))
                ComboBox3.Items.Add(TextBox35.Text)
                Me.BindingContext(ds, "Roostaha").Position += 1
                TextBox35.DataBindings.Clear()
                If TextBox35.Text = TextBox36.Text Then
                    Exit Do
                End If
            Loop

            oda.Dispose()
            ocm.Dispose()
            ocn.Dispose()

            Button2.Visible = True
        End If
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged
        test = False
        Dim ocn As New System.Data.OleDb.OleDbConnection
        Dim ocm As New System.Data.OleDb.OleDbCommand
        Dim oda As New System.Data.OleDb.OleDbDataAdapter
        Dim ds As New DataSet()
        ComboBox3.Text = ComboBox3.SelectedText
        ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\Data.mdb"
        ocm.Connection = ocn
        ocm.CommandText = "SELECT bakhsh FROM Roostaha where roosta='" & ComboBox3.SelectedItem & "'"
        oda.SelectCommand = ocm
        da = New OleDbDataAdapter(ocm.CommandText, ocn)
        da.Fill(ds, "Roostaha")
        ComboBox2.DataBindings.Add(New Binding("text", ds, "Roostaha.bakhsh"))
        ComboBox2.DataBindings.Clear()
        oda.Dispose()
        ocm.Dispose()
        ocn.Dispose()
        Button2.Visible = True
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        ComboBox2.Text = ""
        ComboBox3.Text = ""
        ComboBox3.Items.Clear()
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
            ComboBox3.Items.Add(TextBox35.Text)
            Me.BindingContext(ds, "Roostaha").Position += 1
            TextBox35.DataBindings.Clear()
            If TextBox35.Text = TextBox36.Text Then
                Exit Do
            End If
        Loop
        oda.Dispose()
        ocm.Dispose()
        ocn.Dispose()
        ComboBox2.Enabled = True
        ComboBox3.Enabled = True
        Button2.Visible = False
        test = True
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If ComboBox1.Text = "" Or ComboBox4.Text = "" Or ComboBox5.Text = "" Then
            MsgBox("خطای فیلد های خالی", , "پیغام")
        Else

            Select Case ComboBox1.Text
                Case "کل روستاها"
                    clear()
                    Dim ocn As New System.Data.OleDb.OleDbConnection
                    Dim ocm As New System.Data.OleDb.OleDbCommand
                    Dim oda As New System.Data.OleDb.OleDbDataAdapter
                    Dim ds As New DataSet()
                    Dim i As Integer = 0

                    address = Form1.TextBox3.Text

                    ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                    "atabase Password=" + Form14.TextBox10.Text + ""
                    ocm.Connection = ocn
                    ocm.CommandText = "SELECT * FROM LooleGozari where( eslah ='اصلاح' )"
                    oda.SelectCommand = ocm
                    da = New OleDbDataAdapter(ocm.CommandText, ocn)
                    da.Fill(ds, "Loolegozari")
                    i = Me.BindingContext(ds, "Loolegozari").Count
                    Do
                        TextBox14.DataBindings.Add(New Binding("Text", ds, "loolegozari.m"))
                        arrey(4, Convert.ToInt32(TextBox14.Text) - 1) += 1
                        TextBox14.DataBindings.Clear()
                        Me.BindingContext(ds, "Loolegozari").Position += 1
                        i -= 1
                        If i = 0 Or i < 0 Then
                            Exit Do
                        End If

                    Loop

                    ds.Clear()
                    '*****************************************end 1**********************************************************************************************************'
                    address = Form1.TextBox3.Text


                    ocm.CommandText = "SELECT * FROM LooleGozari where( eslah ='' )"
                    oda.SelectCommand = ocm
                    da = New OleDbDataAdapter(ocm.CommandText, ocn)
                    da.Fill(ds, "Loolegozari")
                    i = Me.BindingContext(ds, "Loolegozari").Count
                    Do
                        TextBox14.DataBindings.Add(New Binding("Text", ds, "loolegozari.m"))
                        arrey(5, Convert.ToInt32(TextBox14.Text) - 1) += 1
                        TextBox14.DataBindings.Clear()
                        Me.BindingContext(ds, "Loolegozari").Position += 1
                        i -= 1
                        If i = 0 Or i < 0 Then
                            Exit Do
                        End If

                    Loop


                    ds.Clear()
                    '*****************************************end 2**********************************************************************************************************'
                    address = Form1.TextBox3.Text


                    ocm.CommandText = "SELECT * FROM tamirat1 where( pomp ='شناور' )"
                    oda.SelectCommand = ocm
                    da = New OleDbDataAdapter(ocm.CommandText, ocn)
                    da.Fill(ds, "tamirat1")
                    i = Me.BindingContext(ds, "tamirat1").Count
                    Do
                        TextBox14.DataBindings.Add(New Binding("Text", ds, "tamirat1.m"))
                        arrey(9, Convert.ToInt32(TextBox14.Text) - 1) += 1
                        TextBox14.DataBindings.Clear()
                        Me.BindingContext(ds, "tamirat1").Position += 1
                        i -= 1
                        If i = 0 Or i < 0 Then
                            Exit Do
                        End If

                    Loop

                    ds.Clear()
                    '*****************************************end 3**********************************************************************************************************'

                    address = Form1.TextBox3.Text


                    ocm.CommandText = "SELECT * FROM tamirat1 where( pomp ='سانتیرفیوژ' )"
                    oda.SelectCommand = ocm
                    da = New OleDbDataAdapter(ocm.CommandText, ocn)
                    da.Fill(ds, "tamirat1")
                    i = Me.BindingContext(ds, "tamirat1").Count
                    Do
                        TextBox14.DataBindings.Add(New Binding("Text", ds, "tamirat1.m"))
                        arrey(10, Convert.ToInt32(TextBox14.Text) - 1) += 1
                        TextBox14.DataBindings.Clear()
                        Me.BindingContext(ds, "tamirat1").Position += 1
                        i -= 1
                        If i = 0 Or i < 0 Then
                            Exit Do
                        End If

                    Loop


                    ds.Clear()
                    '*****************************************end 4**********************************************************************************************************'



                    address = Form1.TextBox3.Text


                    ocm.CommandText = "SELECT * FROM tamirat2"
                    oda.SelectCommand = ocm
                    da = New OleDbDataAdapter(ocm.CommandText, ocn)
                    da.Fill(ds, "tamirat2")
                    i = Me.BindingContext(ds, "tamirat2").Count
                    Do
                        TextBox14.DataBindings.Add(New Binding("Text", ds, "tamirat2.m"))
                        arrey(12, Convert.ToInt32(TextBox14.Text) - 1) += 1
                        TextBox14.DataBindings.Clear()
                        Me.BindingContext(ds, "tamirat2").Position += 1
                        i -= 1
                        If i = 0 Or i < 0 Then
                            Exit Do
                        End If

                    Loop


                    ds.Clear()
                    '*****************************************end 5**********************************************************************************************************'

                    address = Form1.TextBox3.Text


                    ocm.CommandText = "SELECT * FROM Shekastegi where(Vazeiat=true)"
                    oda.SelectCommand = ocm
                    da = New OleDbDataAdapter(ocm.CommandText, ocn)
                    da.Fill(ds, "Shekastegi")
                    i = Me.BindingContext(ds, "Shekastegi").Count

                    Do
                        TextBox14.DataBindings.Add(New Binding("Text", ds, "Shekastegi.m"))
                        TextBox15.DataBindings.Add(New Binding("Text", ds, "Shekastegi.tedad"))
                        arrey(14, Convert.ToInt32(TextBox14.Text) - 1) += TextBox15.Text
                        TextBox14.DataBindings.Clear()
                        TextBox15.DataBindings.Clear()
                        Me.BindingContext(ds, "Shekastegi").Position += 1
                        i -= 1
                        If i = 0 Or i < 0 Then
                            Exit Do
                        End If

                    Loop

                    L_box()
                    ds.Clear()
                    '*****************************************end 6**********************************************************************************************************'


                    oda.Dispose()
                    ocm.Dispose()
                    ocn.Dispose()
                    ocn.Close()
                    ds.Clear()
                    allow = True
                Case "بخش"
                    If ComboBox2.Text = "" Or ComboBox4.Text = "" Or ComboBox5.Text = "" Then
                        MsgBox("خطای فیلد های خالی", , "پیغام")
                    Else
                        clear()
                        Dim ocn As New System.Data.OleDb.OleDbConnection
                        Dim ocm As New System.Data.OleDb.OleDbCommand
                        Dim oda As New System.Data.OleDb.OleDbDataAdapter
                        Dim ds As New DataSet()
                        Dim i As Integer = 0

                        address = Form1.TextBox3.Text

                        ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                        "atabase Password=" + Form14.TextBox10.Text + ""
                        ocm.Connection = ocn
                        ocm.CommandText = "SELECT * FROM LooleGozari where( eslah ='اصلاح' and Bakhsh='" & ComboBox2.Text & "' )"
                        oda.SelectCommand = ocm
                        da = New OleDbDataAdapter(ocm.CommandText, ocn)
                        If da.Fill(ds, "Loolegozari") Then
                            i = Me.BindingContext(ds, "Loolegozari").Count
                            Do
                                TextBox14.DataBindings.Add(New Binding("Text", ds, "loolegozari.m"))
                                arrey(4, Convert.ToInt32(TextBox14.Text) - 1) += 1
                                TextBox14.DataBindings.Clear()
                                Me.BindingContext(ds, "Loolegozari").Position += 1
                                i -= 1
                                If i = 0 Or i < 0 Then
                                    Exit Do
                                End If

                            Loop
                        End If

                        ds.Clear()
                        '*****************************************end 1**********************************************************************************************************'
                        address = Form1.TextBox3.Text


                        ocm.CommandText = "SELECT * FROM LooleGozari where( eslah ='' and Bakhsh='" & ComboBox2.Text & "'  )"
                        oda.SelectCommand = ocm
                        da = New OleDbDataAdapter(ocm.CommandText, ocn)
                        If da.Fill(ds, "Loolegozari") Then
                            i = Me.BindingContext(ds, "Loolegozari").Count
                            Do
                                TextBox14.DataBindings.Add(New Binding("Text", ds, "loolegozari.m"))
                                arrey(5, Convert.ToInt32(TextBox14.Text) - 1) += 1
                                TextBox14.DataBindings.Clear()
                                Me.BindingContext(ds, "Loolegozari").Position += 1
                                i -= 1
                                If i = 0 Or i < 0 Then
                                    Exit Do
                                End If

                            Loop
                        End If

                        ds.Clear()
                        '*****************************************end 2**********************************************************************************************************'
                        address = Form1.TextBox3.Text


                        ocm.CommandText = "SELECT * FROM tamirat1 where( pomp ='شناور' and Bakhsh='" & ComboBox2.Text & "'  )"
                        oda.SelectCommand = ocm
                        da = New OleDbDataAdapter(ocm.CommandText, ocn)
                        If da.Fill(ds, "tamirat1") Then
                            i = Me.BindingContext(ds, "tamirat1").Count
                            Do
                                TextBox14.DataBindings.Add(New Binding("Text", ds, "tamirat1.m"))
                                arrey(9, Convert.ToInt32(TextBox14.Text) - 1) += 1
                                TextBox14.DataBindings.Clear()
                                Me.BindingContext(ds, "tamirat1").Position += 1
                                i -= 1
                                If i = 0 Or i < 0 Then
                                    Exit Do
                                End If

                            Loop
                        End If
                        ds.Clear()
                        '*****************************************end 3**********************************************************************************************************'

                        address = Form1.TextBox3.Text


                        ocm.CommandText = "SELECT * FROM tamirat1 where( pomp ='سانتیرفیوژ' and Bakhsh='" & ComboBox2.Text & "'  )"
                        oda.SelectCommand = ocm
                        da = New OleDbDataAdapter(ocm.CommandText, ocn)
                        If da.Fill(ds, "tamirat1") Then
                            i = Me.BindingContext(ds, "tamirat1").Count
                            Do
                                TextBox14.DataBindings.Add(New Binding("Text", ds, "tamirat1.m"))
                                arrey(10, Convert.ToInt32(TextBox14.Text) - 1) += 1
                                TextBox14.DataBindings.Clear()
                                Me.BindingContext(ds, "tamirat1").Position += 1
                                i -= 1
                                If i = 0 Or i < 0 Then
                                    Exit Do
                                End If

                            Loop
                        End If

                        ds.Clear()
                        '*****************************************end 4**********************************************************************************************************'



                        address = Form1.TextBox3.Text


                        ocm.CommandText = "SELECT * FROM tamirat2 where (bakhsh='" & ComboBox2.Text & "' )"
                        oda.SelectCommand = ocm
                        da = New OleDbDataAdapter(ocm.CommandText, ocn)
                        If da.Fill(ds, "tamirat2") Then
                            i = Me.BindingContext(ds, "tamirat2").Count
                            Do
                                TextBox14.DataBindings.Add(New Binding("Text", ds, "tamirat2.m"))
                                arrey(12, Convert.ToInt32(TextBox14.Text) - 1) += 1
                                TextBox14.DataBindings.Clear()
                                Me.BindingContext(ds, "tamirat2").Position += 1
                                i -= 1
                                If i = 0 Or i < 0 Then
                                    Exit Do
                                End If

                            Loop
                        End If

                        ds.Clear()
                        '*****************************************end 5**********************************************************************************************************'

                        address = Form1.TextBox3.Text


                        ocm.CommandText = "SELECT * FROM Shekastegi where(Vazeiat=true and Bakhsh='" & ComboBox2.Text & "' )"
                        oda.SelectCommand = ocm
                        da = New OleDbDataAdapter(ocm.CommandText, ocn)
                        If da.Fill(ds, "Shekastegi") Then
                            i = Me.BindingContext(ds, "Shekastegi").Count

                            Do
                                TextBox14.DataBindings.Add(New Binding("Text", ds, "Shekastegi.m"))
                                TextBox15.DataBindings.Add(New Binding("Text", ds, "Shekastegi.tedad"))
                                arrey(14, Convert.ToInt32(TextBox14.Text) - 1) += TextBox15.Text
                                TextBox14.DataBindings.Clear()
                                TextBox15.DataBindings.Clear()
                                Me.BindingContext(ds, "Shekastegi").Position += 1
                                i -= 1
                                If i = 0 Or i < 0 Then
                                    Exit Do
                                End If

                            Loop
                        End If
                        L_box()

                        ds.Clear()
                        '*****************************************end 6**********************************************************************************************************'


                        oda.Dispose()
                        ocm.Dispose()
                        ocn.Dispose()
                        ds.Clear()
                        allow = True
                    End If

                Case "روستا"
                    If ComboBox2.Text = "" Or ComboBox3.Text = "" Or ComboBox4.Text = "" Or ComboBox5.Text = "" Then
                        MsgBox("خطای فیلد های خالی", , "پیغام")
                    Else
                        clear()
                        Dim ocn As New System.Data.OleDb.OleDbConnection
                        Dim ocm As New System.Data.OleDb.OleDbCommand
                        Dim oda As New System.Data.OleDb.OleDbDataAdapter
                        Dim ds As New DataSet()
                        Dim i As Integer = 0

                        address = Form1.TextBox3.Text

                        ocn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + address + "\\Data.mdb;Jet OLEDB:D" & _
                        "atabase Password=" + Form14.TextBox10.Text + ""
                        ocm.Connection = ocn
                        ocm.CommandText = "SELECT * FROM LooleGozari where( eslah ='اصلاح' and roosta='" & ComboBox3.Text & "' )"
                        oda.SelectCommand = ocm
                        da = New OleDbDataAdapter(ocm.CommandText, ocn)
                        If da.Fill(ds, "Loolegozari") Then
                            i = Me.BindingContext(ds, "Loolegozari").Count
                            Do
                                TextBox14.DataBindings.Add(New Binding("Text", ds, "loolegozari.m"))
                                arrey(4, Convert.ToInt32(TextBox14.Text) - 1) += 1
                                TextBox14.DataBindings.Clear()
                                Me.BindingContext(ds, "Loolegozari").Position += 1
                                i -= 1
                                If i = 0 Or i < 0 Then
                                    Exit Do
                                End If

                            Loop
                        End If

                        ds.Clear()
                        '*****************************************end 1**********************************************************************************************************'
                        address = Form1.TextBox3.Text


                        ocm.CommandText = "SELECT * FROM LooleGozari where( eslah ='' and roosta='" & ComboBox3.Text & "' )"
                        oda.SelectCommand = ocm
                        da = New OleDbDataAdapter(ocm.CommandText, ocn)
                        If da.Fill(ds, "Loolegozari") Then
                            i = Me.BindingContext(ds, "Loolegozari").Count
                            Do
                                TextBox14.DataBindings.Add(New Binding("Text", ds, "loolegozari.m"))
                                arrey(5, Convert.ToInt32(TextBox14.Text) - 1) += 1
                                TextBox14.DataBindings.Clear()
                                Me.BindingContext(ds, "Loolegozari").Position += 1
                                i -= 1
                                If i = 0 Or i < 0 Then
                                    Exit Do
                                End If

                            Loop
                        End If

                        ds.Clear()
                        '*****************************************end 2**********************************************************************************************************'
                        address = Form1.TextBox3.Text


                        ocm.CommandText = "SELECT * FROM tamirat1 where( pomp ='شناور' and roosta='" & ComboBox3.Text & "' )"
                        oda.SelectCommand = ocm
                        da = New OleDbDataAdapter(ocm.CommandText, ocn)
                        If da.Fill(ds, "tamirat1") Then
                            i = Me.BindingContext(ds, "tamirat1").Count
                            Do
                                TextBox14.DataBindings.Add(New Binding("Text", ds, "tamirat1.m"))
                                arrey(9, Convert.ToInt32(TextBox14.Text) - 1) += 1
                                TextBox14.DataBindings.Clear()
                                Me.BindingContext(ds, "tamirat1").Position += 1
                                i -= 1
                                If i = 0 Or i < 0 Then
                                    Exit Do
                                End If

                            Loop
                        End If
                        ds.Clear()
                        '*****************************************end 3**********************************************************************************************************'

                        address = Form1.TextBox3.Text


                        ocm.CommandText = "SELECT * FROM tamirat1 where( pomp ='سانتیرفیوژ' and roosta='" & ComboBox3.Text & "' )"
                        oda.SelectCommand = ocm
                        da = New OleDbDataAdapter(ocm.CommandText, ocn)
                        If da.Fill(ds, "tamirat1") Then
                            i = Me.BindingContext(ds, "tamirat1").Count
                            Do
                                TextBox14.DataBindings.Add(New Binding("Text", ds, "tamirat1.m"))
                                arrey(10, Convert.ToInt32(TextBox14.Text) - 1) += 1
                                TextBox14.DataBindings.Clear()
                                Me.BindingContext(ds, "tamirat1").Position += 1
                                i -= 1
                                If i = 0 Or i < 0 Then
                                    Exit Do
                                End If

                            Loop
                        End If

                        ds.Clear()
                        '*****************************************end 4**********************************************************************************************************'



                        address = Form1.TextBox3.Text


                        ocm.CommandText = "SELECT * FROM tamirat2 where (roosta='" & ComboBox3.Text & "' )"
                        oda.SelectCommand = ocm
                        da = New OleDbDataAdapter(ocm.CommandText, ocn)
                        If da.Fill(ds, "tamirat2") Then
                            i = Me.BindingContext(ds, "tamirat2").Count
                            Do
                                TextBox14.DataBindings.Add(New Binding("Text", ds, "tamirat2.m"))
                                arrey(12, Convert.ToInt32(TextBox14.Text) - 1) += 1
                                TextBox14.DataBindings.Clear()
                                Me.BindingContext(ds, "tamirat2").Position += 1
                                i -= 1
                                If i = 0 Or i < 0 Then
                                    Exit Do
                                End If

                            Loop
                        End If

                        ds.Clear()
                        '*****************************************end 5**********************************************************************************************************'

                        address = Form1.TextBox3.Text


                        ocm.CommandText = "SELECT * FROM Shekastegi where(Vazeiat=true and roosta='" & ComboBox3.Text & "'  )"
                        oda.SelectCommand = ocm
                        da = New OleDbDataAdapter(ocm.CommandText, ocn)
                        If da.Fill(ds, "Shekastegi") Then
                            i = Me.BindingContext(ds, "Shekastegi").Count

                            Do
                                TextBox14.DataBindings.Add(New Binding("Text", ds, "Shekastegi.m"))
                                TextBox15.DataBindings.Add(New Binding("Text", ds, "Shekastegi.tedad"))
                                arrey(14, Convert.ToInt32(TextBox14.Text) - 1) += TextBox15.Text
                                TextBox14.DataBindings.Clear()
                                TextBox15.DataBindings.Clear()
                                Me.BindingContext(ds, "Shekastegi").Position += 1
                                i -= 1
                                If i = 0 Or i < 0 Then
                                    Exit Do
                                End If

                            Loop
                        End If
                        L_box()

                        ds.Clear()
                        '*****************************************end 6**********************************************************************************************************'


                        oda.Dispose()
                        ocm.Dispose()
                        ocn.Dispose()
                        ds.Clear()
                        allow = True
                    End If
            End Select
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Close()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If Not allow Then
            MsgBox("عدم امکان چاپ", , "پیغام")
        Else
            Dim count As Integer = 0
            CrystalReportViewer1.Size = New System.Drawing.Size(x, y)
            CrystalReportViewer1.Location = New System.Drawing.Point(1, 1)
            Button13.Location = New System.Drawing.Point(x - 115, 5)

            For i As Integer = 0 To 15
                For j As Integer = ComboBox4.SelectedIndex To ComboBox5.SelectedIndex
                    If j = 0 Then
                        If arrey(i, j) = 0 Then
                            TextBox16.Text += "" & vbCrLf
                            count += arrey(i, j)
                        Else
                            TextBox16.Text += arrey(i, j) & vbCrLf
                            count += arrey(i, j)
                        End If
                    ElseIf j = 1 Then
                        If arrey(i, j) = 0 Then
                            TextBox17.Text += "" & vbCrLf
                            count += arrey(i, j)
                        Else
                            TextBox17.Text += arrey(i, j) & vbCrLf
                            count += arrey(i, j)
                        End If
                    ElseIf j = 2 Then
                        If arrey(i, j) = 0 Then
                            TextBox18.Text += "" & vbCrLf
                            count += arrey(i, j)
                        Else
                            TextBox18.Text += arrey(i, j) & vbCrLf
                            count += arrey(i, j)
                        End If
                    ElseIf j = 3 Then
                        If arrey(i, j) = 0 Then
                            TextBox19.Text += "" & vbCrLf
                            count += arrey(i, j)
                        Else
                            TextBox19.Text += arrey(i, j) & vbCrLf
                            count += arrey(i, j)
                        End If
                    ElseIf j = 4 Then
                        If arrey(i, j) = 0 Then
                            TextBox47.Text += "" & vbCrLf
                            count += arrey(i, j)
                        Else
                            TextBox47.Text += arrey(i, j) & vbCrLf
                            count += arrey(i, j)
                        End If
                    ElseIf j = 5 Then
                        If arrey(i, j) = 0 Then
                            TextBox48.Text += "" & vbCrLf
                            count += arrey(i, j)
                        Else
                            TextBox48.Text += arrey(i, j) & vbCrLf
                            count += arrey(i, j)
                        End If
                    ElseIf j = 6 Then
                        If arrey(i, j) = 0 Then
                            TextBox49.Text += "" & vbCrLf
                            count += arrey(i, j)
                        Else
                            TextBox49.Text += arrey(i, j) & vbCrLf
                            count += arrey(i, j)
                        End If
                    ElseIf j = 7 Then
                        If arrey(i, j) = 0 Then
                            TextBox50.Text += "" & vbCrLf
                            count += arrey(i, j)
                        Else
                            TextBox50.Text += arrey(i, j) & vbCrLf
                            count += arrey(i, j)
                        End If
                    ElseIf j = 8 Then
                        If arrey(i, j) = 0 Then
                            TextBox51.Text += "" & vbCrLf
                            count += arrey(i, j)
                        Else
                            TextBox51.Text += arrey(i, j) & vbCrLf
                            count += arrey(i, j)
                        End If
                    ElseIf j = 9 Then
                        If arrey(i, j) = 0 Then
                            TextBox52.Text += "" & vbCrLf
                            count += arrey(i, j)
                        Else
                            TextBox52.Text += arrey(i, j) & vbCrLf
                            count += arrey(i, j)
                        End If
                    ElseIf j = 10 Then
                        If arrey(i, j) = 0 Then
                            TextBox53.Text += "" & vbCrLf
                            count += arrey(i, j)
                        Else
                            TextBox53.Text += arrey(i, j) & vbCrLf
                            count += arrey(i, j)
                        End If
                    ElseIf j = 11 Then
                        If arrey(i, j) = 0 Then
                            TextBox54.Text += "" & vbCrLf
                            count += arrey(i, j)
                        Else
                            TextBox54.Text += arrey(i, j) & vbCrLf
                            count += arrey(i, j)
                        End If
                    End If
                Next j
                If count = 0 Then
                    TextBox55.Text += "" & vbCrLf
                    count = 0
                Else

                    TextBox55.Text += count & vbCrLf
                    count = 0
                End If
            Next i


            rpt.SetParameterValue("C1", TextBox16.Text)
            rpt.SetParameterValue("C2", TextBox17.Text)
            rpt.SetParameterValue("C3", TextBox18.Text)
            rpt.SetParameterValue("C4", TextBox19.Text)
            rpt.SetParameterValue("C5", TextBox47.Text)
            rpt.SetParameterValue("C6", TextBox48.Text)
            rpt.SetParameterValue("C7", TextBox49.Text)
            rpt.SetParameterValue("C8", TextBox50.Text)
            rpt.SetParameterValue("C9", TextBox51.Text)
            rpt.SetParameterValue("C10", TextBox52.Text)
            rpt.SetParameterValue("C11", TextBox53.Text)
            rpt.SetParameterValue("C12", TextBox54.Text)
            rpt.SetParameterValue("C13", TextBox55.Text)
            CrystalReportViewer1.ReportSource = rpt
            CrystalReportViewer1.Visible = True
            Button13.Visible = True
            Button13.BringToFront()

        End If
    End Sub

    Private Sub Form23_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        y = Me.Size.Height
        x = Me.Size.Width
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        clear()
        CrystalReportViewer1.Visible = False
        Button13.Visible = False
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        ComboBox4.Text = ""
        ComboBox5.Text = ""
        allow = False
    End Sub
End Class