Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Public Class LoginForm1
    Dim SQLstr As String
    Dim SQLConn As New SqlConnection
    Dim SQLcmd As New SqlCommand

    Private Sub LoginForm1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Dim recordcount As Integer = 0
        Dim FullName As String
        Dim UName As String
        Dim PWord As String
        Try
            SQLstr = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CMMS.mdf;Integrated Security=True;Connect Timeout=30"
            SQLConn.ConnectionString = SQLstr
            SQLConn.Open()
            SQLcmd = New SqlCommand("Select EmpUserName, EmpPass, Admin, EmpFName, EmpLName From tblEmp", SQLConn)
            Dim SQLDS As New DataSet
            Dim SQLDA As New SqlDataAdapter(SQLcmd)
            recordcount = SQLDA.Fill(SQLDS)
            If recordcount <> 0 Then
                For Each r As DataRow In SQLDS.Tables(0).Rows
                    UName = r("EmpUserName")
                    PWord = r("EmpPass")
                    If UName = UsernameTextBox.Text Then
                        If PWord = PasswordTextBox.Text Then
                            FullName = r("EmpFName") & " " & r("EmpLName")
                            MsgBox("Welcome " & FullName)
                            Main.Label1.Text = FullName
                            If r("Admin") = True Then
                                Main.Label2.Text = 2
                                Main.Text = ("Simple CMMS - Admin(" & FullName & ")")
                                Me.Close()
                                Exit Sub
                            Else
                                Main.Label2.Text = 1
                                Main.Text = ("Simple CMMS - User(" & FullName & ")")
                                Me.Close()
                                Exit Sub
                            End If

                        Else
                            MsgBox("Incorrect Password")
                            Exit Sub
                        End If
                    End If

                Next
                MsgBox("Username does not exit")
                'Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If SQLConn.State = ConnectionState.Open Then SQLConn.Close()
        End Try
        Me.Close()
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub


End Class
