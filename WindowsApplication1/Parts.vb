Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Public Class Parts
    Dim SQLstr As String
    Dim SQLConn As New SqlConnection
    Dim SQLcmd As New SqlCommand
    Dim cmdBuilder As New SqlCommandBuilder
    Private Sub Parts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Company As Integer = 0
        Dim recordcount As Integer = 0

        Try

            SQLstr = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CMMS.mdf;Integrated Security=True;Connect Timeout=30"
            SQLConn.ConnectionString = SQLstr
            SQLConn.Open()
            SQLcmd = New SqlCommand("Select PNumber as 'Part Number',Name as 'Part Name', Type as 'Part Type', Location as 'Location', Vendor as 'Vendor', Count as 'Qty', Units as 'Units', Id FROM tblParts", SQLConn)
            Dim SQLDS As New DataSet
            Dim SQLDA As New SqlDataAdapter(SQLcmd)
            If SQLConn.State = 1 Then
                'MsgBox("Connection Made")

            End If
            recordcount = SQLDA.Fill(SQLDS)
            If recordcount <> 0 Then
                DataGridView1.DataSource = SQLDS.Tables(0)
                DataGridView1.Refresh()
                DataGridView1.Columns(0).Width = 90
                DataGridView1.Columns(1).Width = 200
                DataGridView1.Columns(2).Width = 130
                DataGridView1.Columns(3).Width = 60
                DataGridView1.Columns(4).Width = 100
                DataGridView1.Columns(5).Width = 60
                DataGridView1.Columns(6).Width = 100
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        SQLConn.Close()
    End Sub

    Private Sub DataGridView1_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentDoubleClick
        If e.RowIndex >= 0 Then
            Dim selectedRow = DataGridView1.Rows(e.RowIndex)
            Dim MyRow As Integer = DataGridView1.CurrentRow.Cells(7).Value
            Parts1.Show()
            Parts1.Label11.Text = MyRow
        End If
    End Sub


End Class