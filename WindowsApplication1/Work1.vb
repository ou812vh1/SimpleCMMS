Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Public Class Work1
    Dim SQLstr As String
    Dim SQLConn As New SqlConnection
    Dim SQLcmd As New SqlCommand
    Dim cmdBuilder As New SqlCommandBuilder
    Private Sub Work1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim Company As Integer = 0
        Dim recordcount As Integer = 0

        Try

            SQLstr = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CMMS.mdf;Integrated Security=True;Connect Timeout=30"
            SQLConn.ConnectionString = SQLstr
            SQLConn.Open()
            SQLcmd = New SqlCommand("Select ID, BName From tblMain", SQLConn)
            Dim SQLDS As New DataSet
            Dim SQLDA As New SqlDataAdapter(SQLcmd)
            If SQLConn.State = 1 Then
                'MsgBox("Connection Made")

            End If
            recordcount = SQLDA.Fill(SQLDS)
            If recordcount <> 0 Then
                Label1.Text = SQLDS.Tables(0).Rows(0).Item(1)

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        SQLConn.Close()
        'Timer1.Enabled = True
        LoadWO()
    End Sub
    Private Sub LoadWO()
        Dim recordcount As Integer = 0
        Try

            'SQLstr = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CMMS.mdf;Integrated Security=True;Connect Timeout=30"
            'SQLConn.ConnectionString = SQLstr
            SQLConn.Open()
            SQLcmd = New SqlCommand("SELECT ID, WOName as 'Work Order Name', WOEquip as 'Work Order Equipment', WOScheduled as 'Work Order Scheduled', WOType as 'Work Order Type', WOPriority as 'Work Order Priority', WOAssigned as 'Work Order Assigned To', WOStatus as 'Work Order Status' FROM tblWO", SQLConn)
            Dim SQLDS As New DataSet
            Dim SQLDA As New SqlDataAdapter(SQLcmd)
            If SQLConn.State = 1 Then
                'MsgBox("Connection Made")

            End If
            recordcount = SQLDA.Fill(SQLDS)
            If recordcount <> 0 Then
                DataGridView1.DataSource = SQLDS.Tables(0)
                DataGridView1.Refresh()
                'DataGridView1.Column(1)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        SQLConn.Close()
    End Sub

    Private Sub DataGridView1_CellMouseDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentDoubleClick
        If e.RowIndex >= 0 Then
            Dim selectedRow = DataGridView1.Rows(e.RowIndex)
            Dim MyRow As Integer = DataGridView1.CurrentRow.Cells(0).Value
            Work.Show()
            Work.Label1.Text = "yes"
            Work.Label2.Text = MyRow
            'Me.Close()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim select_ID As String = String.Empty
        select_ID = Convert.ToInt32(DataGridView1.CurrentRow.Index) 'get selected row index
        select_ID = Convert.ToInt32(DataGridView1.Rows(select_ID).Cells(0).Value) 'get selected value

        Dim DelWO As Integer
        If select_ID = "" Then
            '     If DataGridView1.Text = "" Then
            MsgBox("Please Select The Work Order To Delete First")
            Exit Sub
        End If
        DelWO = MsgBox("Are You Sure You Want To Delete Selected WO's", vbYesNo, "Confirm WO Deletion")
        If DelWO = 7 Then
            'Dim X As Integer
            'X = MsgBox("Confirm Deletion of Work Order ( This cannot be undone )", MsgBoxStyle.YesNo)
            'If X = 7 Then
            Exit Sub
            'End If
        Else
            Try
                SQLConn.Open()
                SQLcmd.Connection = SQLConn
                SQLcmd.CommandText = "DELETE FROM tblWO WHERE ID = '" & select_ID & "'"
                SQLcmd.ExecuteNonQuery()
                SQLConn.Close()

                SQLConn.ConnectionString = SQLstr
                SQLConn.Open()
                SQLcmd = New SqlCommand("SELECT ID, WOName as 'Work Order Name', WOEquip as 'Work Order Equipment', WOScheduled as 'Work Order Scheduled', WOType as 'Work Order Type', WOPriority as 'Work Order Priority', WOAssigned as 'Work Order Assigned To', WOStatus as 'Work Order Status' FROM tblWO", SQLConn)
                Dim SQLDS As New DataSet
                Dim SQLDA As New SqlDataAdapter(SQLcmd)
                If SQLDA.Fill(SQLDS) > 0 Then
                    DataGridView1.DataSource = SQLDS.Tables(0)
                    DataGridView1.Refresh()
                End If
                SQLConn.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                    If SQLConn.State = ConnectionState.Open Then SQLConn.Close()
                End Try

            MsgBox("WO(s) Have Been Deleted", vbOKOnly, "Deleted")


        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        LoadWO()
        Timer1.Enabled = False
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Work.Show()

    End Sub
End Class