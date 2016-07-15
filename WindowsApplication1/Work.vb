Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Public Class Work
    Dim SQLstr As String
    Dim SQLConn As New SqlConnection
    Dim SQLcmd As New SqlCommand
    Dim cmdBuilder As New SqlCommandBuilder

    Private Sub Work_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim recordcount As Integer = 0

        SQLstr = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CMMS.mdf;Integrated Security=True;Connect Timeout=30"
        SQLConn.ConnectionString = SQLstr
        LoadCombos()
        Timer1.Enabled = True

    End Sub
    Private Sub LoadCombos()
        Dim recordcount As Integer = 0
        Try 'Loading users and admins in comboboxes
            SQLConn.Open()
            SQLcmd = New SqlCommand("Select EmpFName, EmpLName From tblEmp ORDER BY EmpFName ASC", SQLConn)
            Dim SQLDS As New DataSet
            Dim SQLDA As New SqlDataAdapter(SQLcmd)
            RecordCount = SQLDA.Fill(SQLDS)

            If RecordCount = 0 Then
                If SQLConn.State = ConnectionState.Open Then SQLConn.Close()
                Exit Sub
            Else
                For Each r As DataRow In SQLDS.Tables(0).Rows
                    ComboBox3.Items.Add(r("EmpFName") & " " & (r("EmpLName")))
                    ComboBox5.Items.Add(r("EmpFName") & " " & (r("EmpLName")))
                    ComboBox6.Items.Add(r("EmpFName") & " " & (r("EmpLName")))
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If SQLConn.State = ConnectionState.Open Then SQLConn.Close()
        End Try
    End Sub

    Private Sub LoadWO()
        Dim MyWO As Integer = Label2.Text
        Dim MyCount As Integer

        Try

            SQLConn.Open()
            SQLcmd = New SqlCommand("Select * From tblWO WHERE [Id] = '" & MyWO & "'", SQLConn)
            Dim SQLDS As New DataSet
            Dim SQLDA As New SqlDataAdapter(SQLcmd)
            If SQLConn.State = 1 Then
                MyCount = SQLDA.Fill(SQLDS)
                'MsgBox("Connection Made")
                TextBox3.Text = SQLDS.Tables(0).Rows(0).Item(1).ToString ' WOEquip
                TextBox1.Text = SQLDS.Tables(0).Rows(0).Item(2).ToString ' WOScheduled
                TextBox2.Text = SQLDS.Tables(0).Rows(0).Item(3).ToString ' WOName
                If IsDBNull(SQLDS.Tables(0).Rows(0).Item(4).ToString) Or SQLDS.Tables(0).Rows(0).Item(4).ToString = "" Then
                Else
                    DateTimePicker1.Value = SQLDS.Tables(0).Rows(0).Item(4).ToString ' WOCompleted
                End If
                If IsDBNull(SQLDS.Tables(0).Rows(0).Item(5).ToString) Or SQLDS.Tables(0).Rows(0).Item(5).ToString = "" Then
                Else
                    MaskedTextBox1.Text = SQLDS.Tables(0).Rows(0).Item(5).ToString ' WOTime
                End If
                If IsDBNull(SQLDS.Tables(0).Rows(0).Item(6).ToString) Or SQLDS.Tables(0).Rows(0).Item(6).ToString = "" Then
                Else
                    ComboBox1.Text = SQLDS.Tables(0).Rows(0).Item(6) ' WOType
                End If
                If IsDBNull(SQLDS.Tables(0).Rows(0).Item(7).ToString) Or SQLDS.Tables(0).Rows(0).Item(7).ToString = "" Then
                Else
                    ComboBox2.Text = SQLDS.Tables(0).Rows(0).Item(7) ' WOPriority
                End If
                If IsDBNull(SQLDS.Tables(0).Rows(0).Item(8).ToString) Or SQLDS.Tables(0).Rows(0).Item(8).ToString = "" Then
                Else
                    ComboBox6.Text = SQLDS.Tables(0).Rows(0).Item(8) ' WORequest
                End If
                If IsDBNull(SQLDS.Tables(0).Rows(0).Item(9).ToString) Or SQLDS.Tables(0).Rows(0).Item(9).ToString = "" Then
                Else
                    ComboBox3.Text = SQLDS.Tables(0).Rows(0).Item(9) ' WOAssigned
                End If
                If IsDBNull(SQLDS.Tables(0).Rows(0).Item(10).ToString) Or SQLDS.Tables(0).Rows(0).Item(10).ToString = "" Then
                Else
                    ComboBox4.Text = SQLDS.Tables(0).Rows(0).Item(10) ' WOStatus
                End If
                If IsDBNull(SQLDS.Tables(0).Rows(0).Item(11).ToString) Or SQLDS.Tables(0).Rows(0).Item(11).ToString = "" Then
                Else
                    ComboBox5.Text = SQLDS.Tables(0).Rows(0).Item(11) ' WOCompletedBy
                End If
                If IsDBNull(SQLDS.Tables(0).Rows(0).Item(12).ToString) Or SQLDS.Tables(0).Rows(0).Item(12).ToString = "" Then
                Else
                    MaskedTextBox2.Text = SQLDS.Tables(0).Rows(0).Item(12).ToString ' WOEndTime
                End If

            End If
            SQLConn.Close()
            Exit Sub
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If SQLConn.State = ConnectionState.Open Then SQLConn.Close()
        End Try

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Label2.Text = "0" Then
            Exit Sub
            Timer1.Enabled = False
        Else
            LoadWO()
        End If
        Timer1.Enabled = False
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If Label2.Text = 0 Then
            SaveNew()
        Else
            SaveCurrent()
        End If
    End Sub
    Private Sub SaveNew()

        Dim timecheck As Boolean

        If MaskedTextBox1.Text <> "  :" Then
            timecheck = IsDate(MaskedTextBox1.Text)
            If timecheck = False Then
                MsgBox("Please Enter A Valid Time", vbOKOnly)
                MaskedTextBox1.Focus()
                Exit Sub
            End If
        End If
        If MaskedTextBox2.Text <> "  :" Then
            timecheck = IsDate(MaskedTextBox2.Text)
            If timecheck = False Then
                MsgBox("Please Enter A Valid Time", vbOKOnly)
                MaskedTextBox2.Focus()
                Exit Sub
            End If
        End If
        Dim isvalidtime As Boolean = IsDate(MaskedTextBox1.Text)
        Try
            SQLConn.Open()
            SQLcmd.CommandText = "INSERT into tblWO ([WOName], [WOEquip], [WOScheduled], [WOCompleted], [WOTime], [WOType], [WOPriority], [WORequest], [WOAssigned], [WOStatus], [WOCompleteBy], [WOEndTime]) VALUES('" & TextBox3.Text & "','" & TextBox1.Text & "','" & TextBox2.Text & "','" & DateTimePicker1.Text & "','" & MaskedTextBox1.Text & "','" & ComboBox1.Text & "','" & ComboBox2.Text & "','" & ComboBox6.Text & "','" & ComboBox3.Text & "','" & ComboBox4.Text & "','" & ComboBox5.Text & "','" & MaskedTextBox2.Text & "')"
            SQLcmd.ExecuteNonQuery()

            MsgBox("Data Has Been Saved")

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If SQLConn.State = ConnectionState.Open Then SQLConn.Close()
        End Try
        Work1.Timer1.Enabled = True
        Me.Close()
    End Sub
    Private Sub SaveCurrent()
        Dim MyWO As Integer = Label2.Text
        Dim MyDate As Date
        Dim timecheck As Boolean

        If MaskedTextBox1.Text <> "  :" Then
            timecheck = IsDate(MaskedTextBox1.Text)
            If timecheck = False Then
                MsgBox("Please Enter A Valid Time", vbOKOnly)
                MaskedTextBox1.Focus()
                Exit Sub
            End If
        End If
        If MaskedTextBox2.Text <> "  :" Then
            timecheck = IsDate(MaskedTextBox2.Text)
            If timecheck = False Then
                MsgBox("Please Enter A Valid Time", vbOKOnly)
                MaskedTextBox2.Focus()
                Exit Sub
            End If
        End If
        Dim isvalidtime As Boolean = IsDate(MaskedTextBox1.Text)
        Try

            SQLConn.Open()
            SQLcmd = New SqlCommand("Select * From tblWO WHERE [Id] = '" & MyWO & "'", SQLConn)
            Dim SQLDS As New DataSet
            Dim SQLDA As New SqlDataAdapter(SQLcmd)

            cmdBuilder = New SqlCommandBuilder(SQLDA)
            SQLDA.Fill(SQLDS, "tblWO")
            SQLDS.Tables(0).Rows(0).Item(1) = TextBox3.Text ' WOName
            SQLDS.Tables(0).Rows(0).Item(2) = TextBox1.Text ' WOEquip
            SQLDS.Tables(0).Rows(0).Item(3) = TextBox2.Text ' WOScheduled
            MyDate = Format("M/d/YYYY", DateTimePicker1.Text)
            SQLDS.Tables(0).Rows(0).Item(4) = MyDate ' WOCompleted
            If MaskedTextBox1.Text <> "  :" Then
                SQLDS.Tables(0).Rows(0).Item(5) = MaskedTextBox1.Text ' WOTime
            End If
            SQLDS.Tables(0).Rows(0).Item(6) = ComboBox1.Text ' WOType
            SQLDS.Tables(0).Rows(0).Item(7) = ComboBox2.Text ' WOPriority
            SQLDS.Tables(0).Rows(0).Item(8) = ComboBox6.Text ' WORequest
            SQLDS.Tables(0).Rows(0).Item(9) = ComboBox3.Text ' WOAssigned
            SQLDS.Tables(0).Rows(0).Item(10) = ComboBox4.Text ' WOStatus
            SQLDS.Tables(0).Rows(0).Item(11) = ComboBox5.Text ' WOCompletedBy
            If MaskedTextBox2.Text <> "  :" Then
                SQLDS.Tables(0).Rows(0).Item(12) = MaskedTextBox2.Text ' WOEndTime
            End If

            SQLDA.Update(SQLDS, "tblWO")

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If SQLConn.State = ConnectionState.Open Then SQLConn.Close()
        End Try
        Work1.Timer1.Enabled = True
        Me.Close()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class