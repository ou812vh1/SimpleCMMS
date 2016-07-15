Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Public Class Vendors
    Dim SQLstr As String
    Dim SQLConn As New SqlConnection
    Dim SQLcmd As New SqlCommand
    Dim cmdBuilder As New SqlCommandBuilder
    Dim RecordCount As Integer = 0

    Private Sub Vendors_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click

    End Sub

End Class