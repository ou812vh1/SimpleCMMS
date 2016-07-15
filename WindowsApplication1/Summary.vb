Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Public Class Summary
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Main.Show()
        Me.Close()
    End Sub

    Private Sub Summary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ProgressBar1.Value = 25
        ProgressBar2.Value = 55
        ProgressBar3.Value = 45

        Dim SQLstr As String
        Dim SQLConn As New SqlConnection
        Dim SQLcmd As New SqlCommand
        Dim cmdBuilder As New SqlCommandBuilder

        Dim Company As Integer = 0
        Dim TotalCount As Integer = 0
        Dim TotalCount2 As Integer = 0
        Dim TotalCount3 As Integer = 0
        Dim MyDate As Date = Today
        Try

            SQLstr = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CMMS.mdf;Integrated Security=True;Connect Timeout=30"
            SQLConn.ConnectionString = SQLstr
            SQLConn.Open()
            SQLcmd = New SqlCommand("Select WOScheduled, WOCompleted From tblWO WHERE WOScheduled <= '" & MyDate & "'", SQLConn)
            Dim SQLDS As New DataSet
            Dim SQLDA As New SqlDataAdapter(SQLcmd)
            If SQLConn.State = 1 Then
                'MsgBox("Connection Made")
                TotalCount = SQLDA.Fill(SQLDS)
                'For X 
            End If
            SQLConn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Try
            SQLConn.Open()
            SQLcmd = New SqlCommand("Select WOScheduled, WOCompleted From tblWO WHERE WOScheduled <= '" & MyDate & "' AND WOCompleted = '' OR WOCompleted = null", SQLConn)
            Dim SQLDS As New DataSet
            Dim SQLDA As New SqlDataAdapter(SQLcmd)
            If SQLConn.State = 1 Then
                'MsgBox("Connection Made")
                TotalCount2 = SQLDA.Fill(SQLDS)
            End If
            SQLConn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        TotalCount3 = (TotalCount2 / TotalCount) * 100
        ProgressBar1.Value = TotalCount3
        SQLConn.Close()
    End Sub
End Class