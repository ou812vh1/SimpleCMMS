﻿Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Public Class Requests
    Dim SQLstr As String
    Dim SQLConn As New SqlConnection
    Dim SQLcmd As New SqlCommand
    Dim cmdBuilder As New SqlCommandBuilder
    Private Sub Requests_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Company As Integer = 0
        Dim recordcount As Integer = 0

        Try

            SQLstr = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CMMS.mdf;Integrated Security=True;Connect Timeout=30"
            SQLConn.ConnectionString = SQLstr
            SQLConn.Open()
            SQLcmd = New SqlCommand("Select ReqID, ReqDate as 'Date',ReqType as 'Request Type', ReqTitle as 'Request', ReqEquip as 'Equipment Requests For', ReqBy as 'Requested By' FROM Requests", SQLConn)
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
    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Work1.Show()
        Work1.Label1.Text = "yes"
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        PM.Show()
        PM.Label1.Text = "yes"
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

    Private Sub DataGridView1_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentDoubleClick

        Requests1.Show()

    End Sub
End Class