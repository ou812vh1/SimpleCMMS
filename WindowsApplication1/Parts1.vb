Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Public Class Parts1
    Dim SQLstr As String
    Dim SQLConn As New SqlConnection
    Dim SQLcmd As New SqlCommand
    Dim cmdBuilder As New SqlCommandBuilder

    Private Sub Parts1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SQLstr = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CMMS.mdf;Integrated Security=True;Connect Timeout=30"
        SQLConn.ConnectionString = SQLstr
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Me.Close()

    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        If Label11.Text = 0 Then 'Inserting a new part
            Try
                'SQLstr = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CMMS.mdf;Integrated Security=True;Connect Timeout=30"
                'SQLConn.ConnectionString = SQLstr
                SQLConn.Open()
                SQLcmd.Connection = SQLConn
                'SQLcmd = New SqlCommand("Select * From tblMain where ID = '" & Label11.Text & "'", SQLConn)
                SQLcmd.CommandText = "INSERT into tblParts(PNumber, Name, Type, Location, Cost, Vendor, ManPartNum, Min, Count, Units) VALUES('" & TextBox2.Text & "','" & TextBox1.Text & "''" & ComboBox1.Text & "''" & TextBox4.Text & "''" & TextBox5.Text & "''" & ComboBox2.Text & "''" & TextBox7.Text & "''" & TextBox8.Text & "''" & TextBox9.Text & "''" & ComboBox3.Text & "')"
                'SQLcmd.Parameters.AddWithValue("@tmpArea", tmpArea)
                SQLcmd.ExecuteNonQuery()

                'Dim SQLDS As New DataSet
                'Dim SQLDA As New SqlDataAdapter(SQLcmd)
                'cmdBuilder = New SqlCommandBuilder(SQLDA)
                'SQLDA.Fill(SQLDS, "Parts")

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                If SQLConn.State = ConnectionState.Open Then SQLConn.Close()
            End Try

        Else ' Saving edits from a part number
            Try
                'SQLstr = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CMMS.mdf;Integrated Security=True;Connect Timeout=30"
                'SQLConn.ConnectionString = SQLstr
                SQLConn.Open()
                SQLcmd = New SqlCommand("Select * From tblParts where ID = '" & Label11.Text & "'", SQLConn)
                Dim SQLDS As New DataSet
                Dim SQLDA As New SqlDataAdapter(SQLcmd)

                cmdBuilder = New SqlCommandBuilder(SQLDA)
                SQLDA.Fill(SQLDS, "Parts")
                SQLDS.Tables(0).Rows(0).Item(1) = TextBox2.Text
                SQLDS.Tables(0).Rows(0).Item(2) = TextBox1.Text
                SQLDS.Tables(0).Rows(0).Item(3) = ComboBox1.Text
                SQLDS.Tables(0).Rows(0).Item(4) = TextBox4.Text
                SQLDS.Tables(0).Rows(0).Item(5) = TextBox5.Text
                SQLDS.Tables(0).Rows(0).Item(6) = ComboBox2.Text
                'SQLDS.Tables(0).Rows(0).Item(7) = TextBox8.Text
                SQLDS.Tables(0).Rows(0).Item(8) = TextBox7.Text
                SQLDS.Tables(0).Rows(0).Item(9) = TextBox8.Text
                SQLDS.Tables(0).Rows(0).Item(10) = TextBox9.Text
                SQLDS.Tables(0).Rows(0).Item(11) = ComboBox3.Text
                SQLDA.Update(SQLDS, "Parts")

                SQLConn.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                If SQLConn.State = ConnectionState.Open Then SQLConn.Close()
            End Try

        End If

        Me.Close()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Label11.Text <> 0 Then
            Dim Company As Integer = 0
            Dim recordcount As Integer = 0
            Dim MyPart As Integer = Label11.Text

            Try

                SQLstr = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CMMS.mdf;Integrated Security=True;Connect Timeout=30"
                SQLConn.ConnectionString = SQLstr
                SQLConn.Open()
                SQLcmd = New SqlCommand("Select PNumber as 'Part Number',Name as 'Part Name', Type as 'Part Type', Location , Cost, Vendor, ManPartNum, Min, Count as 'Qty', Units , Id FROM tblParts WHERE Id = '" & MyPart & "' ", SQLConn)
                Dim SQLDS As New DataSet
                Dim SQLDA As New SqlDataAdapter(SQLcmd)
                recordcount = SQLDA.Fill(SQLDS)

                If recordcount <> 0 Then
                    TextBox2.Text = SQLDS.Tables(0).Rows(0).Item(0).ToString
                    TextBox1.Text = SQLDS.Tables(0).Rows(0).Item(1).ToString
                    ComboBox1.Text = SQLDS.Tables(0).Rows(0).Item(2).ToString
                    TextBox4.Text = SQLDS.Tables(0).Rows(0).Item(3).ToString
                    TextBox5.Text = SQLDS.Tables(0).Rows(0).Item(4).ToString
                    ComboBox2.Text = SQLDS.Tables(0).Rows(0).Item(5).ToString
                    TextBox7.Text = SQLDS.Tables(0).Rows(0).Item(6).ToString
                    TextBox8.Text = SQLDS.Tables(0).Rows(0).Item(7).ToString
                    TextBox9.Text = SQLDS.Tables(0).Rows(0).Item(8).ToString
                    ComboBox3.Text = SQLDS.Tables(0).Rows(0).Item(9).ToString
                    'TextBox1.Text = SQLDS.Tables(0).Rows(0).Item(1).ToString
                    'TextBox1.Text = SQLDS.Tables(0).Rows(0).Item(1).ToString
                    'TextBox1.Text = SQLDS.Tables(0).Rows(0).Item(1).ToString

                End If
                Timer1.Enabled = False
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Timer1.Enabled = False
                If SQLConn.State = ConnectionState.Open Then SQLConn.Close()
            End Try

        End If
    End Sub
End Class