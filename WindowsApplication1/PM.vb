Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Public Class PM
    Dim SQLstr As String
    Dim SQLConn As New SqlConnection
    Dim SQLcmd As New SqlCommand
    Dim cmdBuilder As New SqlCommandBuilder
    Private Sub PM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Company As Integer = 0
        Dim recordcount As Integer = 0

        Try
            SQLstr = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CMMS.mdf;Integrated Security=True;Connect Timeout=30"
            SQLConn.ConnectionString = SQLstr
            SQLConn.Open()
            SQLcmd = New SqlCommand("Select * From tblPM", SQLConn)
            Dim SQLDS As New DataSet
            Dim SQLDA As New SqlDataAdapter(SQLcmd)
            If SQLConn.State = 1 Then
                'MsgBox("Connection Made")

            End If
            recordcount = SQLDA.Fill(SQLDS)
            If recordcount <> 0 Then
                DataGridView1.DataSource = SQLDS.Tables(0)
                DataGridView1.Refresh()
                DataGridView1.Columns(0).Width = 0
                DataGridView1.Columns(1).Width = 100
                DataGridView1.Columns(2).Width = 100
                DataGridView1.Columns(3).Width = 100
                DataGridView1.Columns(4).Width = 40
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If SQLConn.State = ConnectionState.Open Then SQLConn.Close()
        End Try

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Work1.Show()
        Work1.Label1.Text = "yes"
        Me.Close()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Requests.Show()
        Requests.Label1.Text = "yes"
        Me.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        Vendors.Show()
        Vendors.Label1.Text = "yes"
        Me.Close()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)
        Parts.Show()
        Parts.Label1.Text = "yes"
        Me.Close()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs)
        setup.Show()
        setup.Label1.Text = "yes"
        Me.Close()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs)
        About.Show()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs)
        Help.Show()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs)
        End
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs)
        Reports.Show()
    End Sub

    Private Sub DataGridView1_CellMouseDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentDoubleClick
        If e.RowIndex >= 0 Then
            Dim selectedRow = DataGridView1.Rows(e.RowIndex)
            Dim MyRow As Integer = DataGridView1.CurrentRow.Cells(0).Value
            PM1.Show()
            'PM1.Label1.Text = "yes"
            PM1.Label12.Text = MyRow
            'Me.Close()
        End If


        PM1.Show()

    End Sub


End Class