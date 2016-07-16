Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Public Class PM1
    Dim SQLstr As String
    Dim SQLConn As New SqlConnection
    Dim SQLcmd As New SqlCommand
    Dim cmdBuilder As New SqlCommandBuilder
    Dim RecordCount As Integer = 0

    Private Sub PM1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SQLstr = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CMMS.mdf;Integrated Security=True;Connect Timeout=30"
        SQLConn.ConnectionString = SQLstr

        Try
            SQLConn.Open()
            SQLcmd = New SqlCommand("Select Name From Equip ORDER BY Name ASC", SQLConn)
            Dim SQLDS As New DataSet
            Dim SQLDA As New SqlDataAdapter(SQLcmd)
            RecordCount = SQLDA.Fill(SQLDS)

            If RecordCount = 0 Then
                If SQLConn.State = ConnectionState.Open Then SQLConn.Close()
                Exit Sub
            Else
                For Each r As DataRow In SQLDS.Tables(0).Rows
                    ComboBox1.Items.Add(r("Name"))
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If SQLConn.State = ConnectionState.Open Then SQLConn.Close()
        End Try

    End Sub
    Private Sub LoadPM()
        Dim MyPM As Integer = Label12.Text
        Dim MyCount As Integer
        Dim MyInterval(2) As String

        Try

            SQLConn.Open()
            SQLcmd = New SqlCommand("Select * From tblPM WHERE [Id] = '" & MyPM & "'", SQLConn)
            Dim SQLDS As New DataSet
            Dim SQLDA As New SqlDataAdapter(SQLcmd)
            If SQLConn.State = 1 Then
                MyCount = SQLDA.Fill(SQLDS)
                'MsgBox("Connection Made")
                TextBox1.Text = SQLDS.Tables(0).Rows(0).Item(1).ToString ' PMName
                ComboBox1.Text = SQLDS.Tables(0).Rows(0).Item(2).ToString ' WOScheduled
                MyInterval = Split(SQLDS.Tables(0).Rows(0).Item(3).ToString, " ")
                ComboBox2.Text = MyInterval(0)
                ComboBox3.Text = MyInterval(1)

                TextBox2.Text = SQLDS.Tables(0).Rows(0).Item(3).ToString ' WOInterval
                'If IsDBNull(SQLDS.Tables(0).Rows(0).Item(4).ToString) Or SQLDS.Tables(0).Rows(0).Item(4).ToString = "" Then
                'Else
                '    DateTimePicker1.Value = SQLDS.Tables(0).Rows(0).Item(4).ToString ' WOCompleted
                'End If
                'If IsDBNull(SQLDS.Tables(0).Rows(0).Item(5).ToString) Or SQLDS.Tables(0).Rows(0).Item(5).ToString = "" Then
                'Else
                '    MaskedTextBox1.Text = SQLDS.Tables(0).Rows(0).Item(5).ToString ' WOTime
                'End If
                'If IsDBNull(SQLDS.Tables(0).Rows(0).Item(6).ToString) Or SQLDS.Tables(0).Rows(0).Item(6).ToString = "" Then
                'Else
                '    ComboBox1.Text = SQLDS.Tables(0).Rows(0).Item(6) ' WOType
                'End If


            End If
            SQLConn.Close()
            Exit Sub
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If SQLConn.State = ConnectionState.Open Then SQLConn.Close()
        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Label12.Text = 0 Then
            Timer1.Enabled = False
            Exit Sub
        Else
            Timer1.Enabled = False
            LoadPM()
        End If
    End Sub
End Class