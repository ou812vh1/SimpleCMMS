Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Public Class Count
    Dim SQLstr As String
    Dim SQLConn As New SqlConnection
    Dim SQLcmd As New SqlCommand

    Private Sub Count_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        NullWO()
        CheckRequests()
    End Sub
    Private Sub LoadWO()
        Dim recordcount As Integer = 0
        Dim MyMonth2 As String
        Dim Myyear As String
        Dim MyToday As Integer
        Dim MyWeek As Integer
        Dim MyMonth As Integer
        Dim WeekDay As Integer = (Today.DayOfWeek)
        TextBox10.Text = WeekDay
        MyMonth2 = DatePart(DateInterval.Month, Today)
        Myyear = DatePart(DateInterval.Year, Today)
        Dim MyMonth3 As Date = DateTime.Parse(MyMonth2 & "/1/" & Myyear)

        Try
            SQLConn.Open()
            SQLcmd = New SqlCommand("SELECT ID,WOCompleted FROM tblWO WHERE WOCompleted >=  '" & MyMonth3 & "'", SQLConn)
            Dim SQLDS As New DataSet
            Dim SQLDA As New SqlDataAdapter(SQLcmd)
            If SQLConn.State = 1 Then
                'MsgBox("Connection Made")
            End If
            recordcount = SQLDA.Fill(SQLDS)
            If recordcount <> 0 Then
                TextBox9.Text = recordcount
                For Each r As DataRow In SQLDS.Tables(0).Rows
                    If r("WOCompleted") = Today Then
                        MyToday = MyToday + 1
                        MyWeek = MyWeek + 1
                        MyMonth = MyMonth + 1
                    ElseIf r("WOCompleted") >= DateAdd(DateInterval.Day, -WeekDay, Today) Then
                        MyWeek = MyWeek + 1
                        MyMonth = MyMonth + 1
                    Else
                        MyMonth = MyMonth + 1
                    End If
                Next
                Label2.Text = MyToday
                Label5.Text = MyWeek
                Label6.Text = MyMonth
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        SQLConn.Close()
    End Sub
    Private Sub NullWO()
        'Uncompleted Work Orders
        Dim recordcount As Integer
        Try
            Dim nulltext = DBNull.Value
            SQLConn.Open()
            'SQLcmd = New SqlCommand("SELECT ID, WOCompleted FROM tblWO", SQLConn)
            SQLcmd = New SqlCommand("SELECT ID, WOCompleted FROM tblWO WHERE WOCompleted IS NULL OR WOCompleted =' '", SQLConn)
            Dim SQLDS As New DataSet
            Dim SQLDA As New SqlDataAdapter(SQLcmd)
            If SQLConn.State = 1 Then
                'recordcount = SQLDA.Fill(SQLDS)
                'MsgBox("Connection Made")

                Label7.Text = recordcount
            End If
            recordcount = SQLDA.Fill(SQLDS)
            Label7.Text = recordcount

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        SQLConn.Close()
    End Sub
    Private Sub CheckRequests()
        Dim Company As Integer = 0
        Dim recordcount As Integer = 0

        Try
            SQLConn.Open()
            SQLcmd = New SqlCommand("Select * From Requests", SQLConn)
            Dim SQLDS As New DataSet
            Dim SQLDA As New SqlDataAdapter(SQLcmd)
            If SQLConn.State = 1 Then
                'MsgBox("Connection Made")

            End If
            recordcount = SQLDA.Fill(SQLDS)
            If recordcount <> 0 Then
                Label8.Text = recordcount
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        SQLConn.Close()

    End Sub

End Class