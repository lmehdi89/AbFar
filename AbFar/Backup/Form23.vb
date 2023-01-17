Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine

Public Class Form23

    Public test As Boolean = True
    Private da As OleDbDataAdapter

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
        Select Case ComboBox1.Text
            Case "کل روستاها"

            Case "بخش"
            Case "روستا"
        End Select
    End Sub

End Class