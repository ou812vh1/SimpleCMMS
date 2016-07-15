Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Public Class setup
    Dim SQLstr As String
    Dim SQLConn As New SqlConnection
    Dim SQLcmd As New SqlCommand
    Dim cmdBuilder As New SqlCommandBuilder
    Dim RecordCount As Integer = 0
    Dim Company As Integer = 0
    Dim Employee As Integer = 0
    Dim tmpstr As String


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TabControl1.SelectedIndex.ToString = 0 Then
            UpdateCompany()
        ElseIf TabControl1.SelectedIndex.ToString = 1 Then
            SaveEmpInfo()
        End If
        Main.ToolStrip1.Enabled = True
        'Me.Close()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs)
        UpdateCompany()
        Main.Show()
        Main.Label2.Text = Me.Label1.Text
        Main.ToolStrip1.Enabled = True
        Me.Close()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If TabControl1.SelectedIndex.ToString = 0 Then
            LoadCompany()
        ElseIf TabControl1.SelectedIndex.ToString = 1 Then
            LoadEmpInfo()
        End If

        'Main.ToolStrip1.Enabled = True
    End Sub
    Private Sub LoadTypes()
        Try
            SQLConn.Open()
            SQLcmd = New SqlCommand("Select * From Types ORDER BY Types ASC", SQLConn)
            Dim SQLDS As New DataSet
            Dim SQLDA As New SqlDataAdapter(SQLcmd)
            RecordCount = SQLDA.Fill(SQLDS)

            If RecordCount = 0 Then
                If SQLConn.State = ConnectionState.Open Then SQLConn.Close()
                Exit Sub
            Else
                For Each r As DataRow In SQLDS.Tables(0).Rows
                    ListBox2.Items.Add(r("Types"))
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If SQLConn.State = ConnectionState.Open Then SQLConn.Close()
        End Try
    End Sub
    Private Sub LoadPriority()
        Try
            SQLConn.Open()
            SQLcmd = New SqlCommand("Select * From Priority ORDER BY Priority ASC", SQLConn)
            Dim SQLDS As New DataSet
            Dim SQLDA As New SqlDataAdapter(SQLcmd)
            RecordCount = SQLDA.Fill(SQLDS)

            If RecordCount = 0 Then
                If SQLConn.State = ConnectionState.Open Then SQLConn.Close()
                Exit Sub
            Else
                For Each r As DataRow In SQLDS.Tables(0).Rows
                    ListBox3.Items.Add(r("Priority"))
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If SQLConn.State = ConnectionState.Open Then SQLConn.Close()
        End Try
    End Sub
    Private Sub setup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Main.ToolStrip1.Enabled = False
        SQLstr = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CMMS.mdf;Integrated Security=True;Connect Timeout=30"
        SQLConn.ConnectionString = SQLstr
        LoadCompany()
        LoadEmp()
        LoadTypes()
        LoadPriority()
    End Sub
    Private Sub LoadCompany()
        Try
            SQLConn.Open()
            SQLcmd = New SqlCommand("Select * From tblMain", SQLConn)
            Dim SQLDS As New DataSet
            Dim SQLDA As New SqlDataAdapter(SQLcmd)
            RecordCount = SQLDA.Fill(SQLDS)

            If RecordCount = 0 Then
                If SQLConn.State = ConnectionState.Open Then SQLConn.Close()
                Exit Sub
            Else
                Company = SQLDS.Tables(0).Rows(0).Item(0)
                Label12.Text = Company
                TextBox1.Text = SQLDS.Tables(0).Rows(0).Item(1)
                If IsDBNull(SQLDS.Tables(0).Rows(0).Item(2)) = False Then
                    TextBox2.Text = SQLDS.Tables(0).Rows(0).Item(2)
                Else
                    TextBox2.Text = ""
                End If
                If IsDBNull(SQLDS.Tables(0).Rows(0).Item(3)) = False Then
                    TextBox3.Text = SQLDS.Tables(0).Rows(0).Item(3)
                Else
                    TextBox3.Text = ""
                End If
                If IsDBNull(SQLDS.Tables(0).Rows(0).Item(4)) = False Then
                    TextBox4.Text = SQLDS.Tables(0).Rows(0).Item(4)
                Else
                    TextBox4.Text = ""
                End If
                If IsDBNull(SQLDS.Tables(0).Rows(0).Item(5)) = False Then
                    TextBox5.Text = SQLDS.Tables(0).Rows(0).Item(5)
                Else
                    TextBox5.Text = ""
                End If
                If IsDBNull(SQLDS.Tables(0).Rows(0).Item(6)) = False Then
                    TextBox6.Text = SQLDS.Tables(0).Rows(0).Item(6)
                Else
                    TextBox6.Text = ""
                End If
                If IsDBNull(SQLDS.Tables(0).Rows(0).Item(7)) = False Then
                    TextBox7.Text = SQLDS.Tables(0).Rows(0).Item(7)
                Else
                    TextBox7.Text = ""
                End If
                If IsDBNull(SQLDS.Tables(0).Rows(0).Item(8)) = False Then
                    TextBox8.Text = SQLDS.Tables(0).Rows(0).Item(8)
                Else
                    TextBox8.Text = ""
                End If
                If IsDBNull(SQLDS.Tables(0).Rows(0).Item(9)) = False Then
                    TextBox9.Text = SQLDS.Tables(0).Rows(0).Item(9)
                Else
                    TextBox9.Text = ""
                End If
            End If
            SQLConn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If SQLConn.State = ConnectionState.Open Then SQLConn.Close()
        End Try
    End Sub
    Private Sub UpdateCompany()
        Try
            SQLstr = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CMMS.mdf;Integrated Security=True;Connect Timeout=30"
            SQLConn.ConnectionString = SQLstr
            SQLConn.Open()
            SQLcmd = New SqlCommand("Select * From tblMain where ID = '" & Label12.Text & "'", SQLConn)
            Dim SQLDS As New DataSet
            Dim SQLDA As New SqlDataAdapter(SQLcmd)

            cmdBuilder = New SqlCommandBuilder(SQLDA)
            SQLDA.Fill(SQLDS, "tblMain")
            SQLDS.Tables(0).Rows(0).Item(1) = TextBox1.Text
            SQLDS.Tables(0).Rows(0).Item(2) = TextBox2.Text
            SQLDS.Tables(0).Rows(0).Item(3) = TextBox3.Text
            SQLDS.Tables(0).Rows(0).Item(4) = TextBox4.Text
            SQLDS.Tables(0).Rows(0).Item(5) = TextBox5.Text
            SQLDS.Tables(0).Rows(0).Item(6) = TextBox6.Text
            SQLDS.Tables(0).Rows(0).Item(7) = TextBox7.Text
            SQLDS.Tables(0).Rows(0).Item(8) = TextBox8.Text
            SQLDS.Tables(0).Rows(0).Item(9) = TextBox9.Text
            SQLDA.Update(SQLDS, "tblMain")


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If SQLConn.State = ConnectionState.Open Then SQLConn.Close()
        End Try
    End Sub
    Private Sub LoadEmp()
        Try
            SQLConn.Open()
            SQLcmd = New SqlCommand("Select * From tblEmp ORDER BY EmpLName ASC", SQLConn)
            Dim SQLDS As New DataSet
            Dim SQLDA As New SqlDataAdapter(SQLcmd)
            RecordCount = SQLDA.Fill(SQLDS)

            If RecordCount = 0 Then
                If SQLConn.State = ConnectionState.Open Then SQLConn.Close()
                Exit Sub
            Else
                For Each r As DataRow In SQLDS.Tables(0).Rows
                    ListBox1.Items.Add(r("EmpFName") & " " & (r("EmpLName")))
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If SQLConn.State = ConnectionState.Open Then SQLConn.Close()
        End Try
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        LoadEmpInfo()
    End Sub
    Private Sub LoadEmpInfo()
        Dim Name() As String
        Name = Split(ListBox1.Text, " ")
        Label14.Text = Name(0)
        Label15.Text = Name(1)

        Try
            SQLConn.Open()
            SQLcmd = New SqlCommand("Select * From tblEmp WHERE EmpFName = '" & Name(0) & "' AND EmpLName = '" & Name(1) & "'", SQLConn)
            Dim SQLDS As New DataSet
            Dim SQLDA As New SqlDataAdapter(SQLcmd)
            If SQLConn.State = 1 Then
                'MsgBox("Connection Made")

            End If
            RecordCount = SQLDA.Fill(SQLDS)
            If RecordCount = 0 Then
                If SQLConn.State = ConnectionState.Open Then SQLConn.Close()
                Exit Sub
            Else
                Employee = SQLDS.Tables(0).Rows(0).Item(0)
                TextBox18.Text = SQLDS.Tables(0).Rows(0).Item(1)
                If IsDBNull(SQLDS.Tables(0).Rows(0).Item(2)) = False Then
                    TextBox10.Text = SQLDS.Tables(0).Rows(0).Item(2)
                End If
                If IsDBNull(SQLDS.Tables(0).Rows(0).Item(3)) = False Then
                    TextBox11.Text = SQLDS.Tables(0).Rows(0).Item(3)
                Else
                    TextBox11.Text = ""
                End If
                If IsDBNull(SQLDS.Tables(0).Rows(0).Item(4)) = False Then
                    TextBox12.Text = SQLDS.Tables(0).Rows(0).Item(4)
                Else
                    TextBox12.Text = ""
                End If
                If IsDBNull(SQLDS.Tables(0).Rows(0).Item(5)) = False Then
                    TextBox13.Text = SQLDS.Tables(0).Rows(0).Item(5)
                Else
                    TextBox13.Text = ""
                End If
                If IsDBNull(SQLDS.Tables(0).Rows(0).Item(6)) = False Then
                    TextBox14.Text = SQLDS.Tables(0).Rows(0).Item(6)
                Else
                    TextBox14.Text = ""
                End If
                If IsDBNull(SQLDS.Tables(0).Rows(0).Item(7)) = False Then
                    TextBox15.Text = SQLDS.Tables(0).Rows(0).Item(7)
                Else
                    TextBox15.Text = ""
                End If
                If IsDBNull(SQLDS.Tables(0).Rows(0).Item(8)) = False Then
                    TextBox16.Text = SQLDS.Tables(0).Rows(0).Item(8)
                Else
                    TextBox16.Text = ""
                End If
                If IsDBNull(SQLDS.Tables(0).Rows(0).Item(9)) = False Then
                    TextBox17.Text = SQLDS.Tables(0).Rows(0).Item(9)
                Else
                    TextBox17.Text = ""
                End If
                If IsDBNull(SQLDS.Tables(0).Rows(0).Item(14)) = False Then
                    TextBox21.Text = SQLDS.Tables(0).Rows(0).Item(14)
                Else
                    TextBox21.Text = ""
                End If
                If IsDBNull(SQLDS.Tables(0).Rows(0).Item(22)) = False Then
                    TextBox28.Text = SQLDS.Tables(0).Rows(0).Item(22)
                Else
                    TextBox28.Text = ""
                End If
                If IsDBNull(SQLDS.Tables(0).Rows(0).Item(15)) = False Then
                    If SQLDS.Tables(0).Rows(0).Item(15) = False Then
                        CheckBox2.CheckState = CheckState.Unchecked
                    Else
                        CheckBox2.CheckState = CheckState.Checked
                    End If
                Else
                    CheckBox2.CheckState = CheckState.Unchecked
                End If
                If CheckBox2.Checked = True Then
                    If IsDBNull(SQLDS.Tables(0).Rows(0).Item(4)) = False Then
                        TextBox22.Text = SQLDS.Tables(0).Rows(0).Item(4)
                    Else
                        TextBox22.Text = ""
                    End If
                    If IsDBNull(SQLDS.Tables(0).Rows(0).Item(5)) = False Then
                        TextBox23.Text = SQLDS.Tables(0).Rows(0).Item(5)
                    Else
                        TextBox23.Text = ""
                    End If
                    If IsDBNull(SQLDS.Tables(0).Rows(0).Item(6)) = False Then
                        TextBox24.Text = SQLDS.Tables(0).Rows(0).Item(6)
                    Else
                        TextBox24.Text = ""
                    End If
                    If IsDBNull(SQLDS.Tables(0).Rows(0).Item(7)) = False Then
                        TextBox25.Text = SQLDS.Tables(0).Rows(0).Item(7)
                    Else
                        TextBox25.Text = ""
                    End If
                    If IsDBNull(SQLDS.Tables(0).Rows(0).Item(8)) = False Then
                        TextBox26.Text = SQLDS.Tables(0).Rows(0).Item(8)
                    Else
                        TextBox26.Text = ""
                    End If
                    If IsDBNull(SQLDS.Tables(0).Rows(0).Item(9)) = False Then
                        TextBox27.Text = SQLDS.Tables(0).Rows(0).Item(9)
                    Else
                        TextBox27.Text = ""
                    End If
                Else
                    If IsDBNull(SQLDS.Tables(0).Rows(0).Item(16)) = False Then
                        TextBox22.Text = SQLDS.Tables(0).Rows(0).Item(16)
                    Else
                        TextBox22.Text = ""
                    End If
                    If IsDBNull(SQLDS.Tables(0).Rows(0).Item(17)) = False Then
                        TextBox23.Text = SQLDS.Tables(0).Rows(0).Item(17)
                    Else
                        TextBox23.Text = ""
                    End If
                    If IsDBNull(SQLDS.Tables(0).Rows(0).Item(18)) = False Then
                        TextBox24.Text = SQLDS.Tables(0).Rows(0).Item(18)
                    Else
                        TextBox24.Text = ""
                    End If
                    If IsDBNull(SQLDS.Tables(0).Rows(0).Item(19)) = False Then
                        TextBox25.Text = SQLDS.Tables(0).Rows(0).Item(19)
                    Else
                        TextBox25.Text = ""
                    End If
                    If IsDBNull(SQLDS.Tables(0).Rows(0).Item(20)) = False Then
                        TextBox26.Text = SQLDS.Tables(0).Rows(0).Item(20)
                    Else
                        TextBox26.Text = ""
                    End If
                    If IsDBNull(SQLDS.Tables(0).Rows(0).Item(21)) = False Then
                        TextBox27.Text = SQLDS.Tables(0).Rows(0).Item(21)
                    Else
                        TextBox27.Text = ""
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If SQLConn.State = ConnectionState.Open Then SQLConn.Close()
        End Try
    End Sub
    Private Sub SaveEmpInfo()
        Try
            'SQLstr = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CMMS.mdf;Integrated Security=True;Connect Timeout=30"
            'SQLConn.ConnectionString = SQLstr
            SQLConn.Open()
            SQLcmd = New SqlCommand("Select * From tblEmp WHERE Id = '" & Employee & "'", SQLConn)
            Dim SQLDS As New DataSet
            Dim SQLDA As New SqlDataAdapter(SQLcmd)

            cmdBuilder = New SqlCommandBuilder(SQLDA)
            SQLDA.Fill(SQLDS, "tblMain")
            SQLDS.Tables(0).Rows(0).Item(1) = TextBox18.Text
            SQLDS.Tables(0).Rows(0).Item(2) = TextBox10.Text
            SQLDS.Tables(0).Rows(0).Item(3) = TextBox11.Text
            SQLDS.Tables(0).Rows(0).Item(4) = TextBox12.Text
            SQLDS.Tables(0).Rows(0).Item(5) = TextBox13.Text
            SQLDS.Tables(0).Rows(0).Item(6) = TextBox14.Text
            SQLDS.Tables(0).Rows(0).Item(7) = TextBox15.Text
            SQLDS.Tables(0).Rows(0).Item(8) = TextBox16.Text
            SQLDS.Tables(0).Rows(0).Item(9) = TextBox17.Text
            SQLDS.Tables(0).Rows(0).Item(10) = TextBox29.Text
            SQLDS.Tables(0).Rows(0).Item(11) = TextBox19.Text
            SQLDS.Tables(0).Rows(0).Item(12) = TextBox20.Text
            SQLDS.Tables(0).Rows(0).Item(13) = TextBox30.Text
            SQLDS.Tables(0).Rows(0).Item(14) = TextBox21.Text
            SQLDS.Tables(0).Rows(0).Item(15) = CheckBox2.Checked
            If CheckBox2.Checked = False Then
                SQLDS.Tables(0).Rows(0).Item(16) = TextBox22.Text
                SQLDS.Tables(0).Rows(0).Item(17) = TextBox23.Text
                SQLDS.Tables(0).Rows(0).Item(18) = TextBox24.Text
                SQLDS.Tables(0).Rows(0).Item(19) = TextBox25.Text
                SQLDS.Tables(0).Rows(0).Item(20) = TextBox26.Text
                SQLDS.Tables(0).Rows(0).Item(21) = TextBox27.Text
                SQLDS.Tables(0).Rows(0).Item(22) = TextBox28.Text
            Else
                SQLDS.Tables(0).Rows(0).Item(16) = TextBox12.Text
                SQLDS.Tables(0).Rows(0).Item(17) = TextBox13.Text
                SQLDS.Tables(0).Rows(0).Item(18) = TextBox14.Text
                SQLDS.Tables(0).Rows(0).Item(19) = TextBox15.Text
                SQLDS.Tables(0).Rows(0).Item(20) = TextBox16.Text
                SQLDS.Tables(0).Rows(0).Item(21) = TextBox17.Text
                SQLDS.Tables(0).Rows(0).Item(22) = TextBox28.Text
            End If
            SQLDA.Update(SQLDS, "tblMain")


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If SQLConn.State = ConnectionState.Open Then SQLConn.Close()
        End Try
    End Sub
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)
        LoadEmpInfo()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        tmpstr = InputBox("Please Enter A New Type Code", "New Type Code")
        If tmpstr <> "" Then
            Try

                SQLConn.Open()
                SQLcmd.Connection = SQLConn
                SQLcmd.CommandText = "INSERT into Types(Types) VALUES(@tmpstr)"
                SQLcmd.Parameters.AddWithValue("@tmpstr", tmpstr)
                SQLcmd.ExecuteNonQuery()
                SQLConn.Close()


                SQLConn.Open()
                SQLcmd = New SqlCommand("SELECT Types FROM Types ORDER BY Types ASC", SQLConn)
                Dim SQLDS As New DataSet
                Dim SQLDA As New SqlDataAdapter(SQLcmd)
                If SQLDA.Fill(SQLDS) > 0 Then
                    ListBox2.Items.Clear()
                    For Each r As DataRow In SQLDS.Tables(0).Rows

                        ListBox2.Items.Add(r("Types"))
                    Next
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                If SQLConn.State = ConnectionState.Open Then SQLConn.Close()
            End Try
        Else
            MsgBox("Please Enter A Type Code")
            Exit Sub

        End If

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        tmpstr = InputBox("Please Enter A New Priority Code", "New Priority Code")
        If tmpstr <> "" Then
            Try

                SQLConn.Open()
                SQLcmd.Connection = SQLConn
                SQLcmd.CommandText = "INSERT into Priority(Priority) VALUES(@tmpstr)"
                SQLcmd.Parameters.AddWithValue("@tmpstr", tmpstr)
                SQLcmd.ExecuteNonQuery()
                SQLConn.Close()


                SQLConn.Open()
                SQLcmd = New SqlCommand("SELECT Priority FROM Priority ORDER BY Priority ASC", SQLConn)
                Dim SQLDS As New DataSet
                Dim SQLDA As New SqlDataAdapter(SQLcmd)
                If SQLDA.Fill(SQLDS) > 0 Then
                    ListBox3.Items.Clear()
                    For Each r As DataRow In SQLDS.Tables(0).Rows

                        ListBox3.Items.Add(r("Priority"))
                    Next
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                If SQLConn.State = ConnectionState.Open Then SQLConn.Close()
            End Try
        Else
            MsgBox("Please Enter A Priority Code")
            Exit Sub

        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If ListBox2.Text = "" Then
            MsgBox("Please Select The Line To Delete First")
            Exit Sub
        Else
            Dim X As Integer
            X = MsgBox("Confirm Deletion of " + ListBox2.Text, MsgBoxStyle.YesNo)
            If X = 7 Then
                Exit Sub
            End If
            Try
                SQLConn.Open()
                SQLcmd.Connection = SQLConn
                SQLcmd.CommandText = "DELETE FROM Types WHERE Types = '" & ListBox2.Text & "'"
                SQLcmd.ExecuteNonQuery()
                SQLConn.Close()

                SQLConn.ConnectionString = SQLstr
                SQLConn.Open()
                SQLcmd = New SqlCommand("SELECT Types FROM Types ORDER BY Types ASC", SQLConn)
                Dim SQLDS As New DataSet
                Dim SQLDA As New SqlDataAdapter(SQLcmd)
                If SQLDA.Fill(SQLDS) > 0 Then
                    ListBox2.Items.Clear()
                    For Each r As DataRow In SQLDS.Tables(0).Rows

                        ListBox2.Items.Add(r("Types"))
                    Next
                End If
                SQLConn.Close()
            Catch ex As Exception
            Finally
                If SQLConn.State = ConnectionState.Open Then SQLConn.Close()
            End Try
        End If

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If ListBox3.Text = "" Then
            MsgBox("Please Select The Line To Delete First")
            Exit Sub
        Else
            Dim X As Integer
            X = MsgBox("Confirm Deletion of " + ListBox3.Text, MsgBoxStyle.YesNo)
            If X = 7 Then
                Exit Sub
            End If
            Try
                SQLConn.Open()
                SQLcmd.Connection = SQLConn
                SQLcmd.CommandText = "DELETE FROM Priority WHERE Priority = '" & ListBox3.Text & "'"
                SQLcmd.ExecuteNonQuery()
                SQLConn.Close()

                SQLConn.ConnectionString = SQLstr
                SQLConn.Open()
                SQLcmd = New SqlCommand("SELECT Priority FROM Priority ORDER BY Priority ASC", SQLConn)
                Dim SQLDS As New DataSet
                Dim SQLDA As New SqlDataAdapter(SQLcmd)
                If SQLDA.Fill(SQLDS) > 0 Then
                    ListBox3.Items.Clear()
                    For Each r As DataRow In SQLDS.Tables(0).Rows

                        ListBox3.Items.Add(r("Priority"))
                    Next
                End If
                SQLConn.Close()
            Catch ex As Exception
            Finally
                If SQLConn.State = ConnectionState.Open Then SQLConn.Close()
            End Try
        End If

    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If TabControl1.SelectedIndex.ToString = 0 Then
            Button7.Visible = False
        ElseIf TabControl1.SelectedIndex.ToString = 1 Then
            Button7.Visible = True
        ElseIf TabControl1.SelectedIndex.ToString = 2 Then
            Button7.Visible = False
        End If
        Main.ToolStrip1.Enabled = True
    End Sub
End Class





