Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Public Class Main
    Dim SQLstr As String
    Dim SQLConn As New SqlConnection
    Dim SQLcmd As New SqlCommand
    Dim cmdBuilder As New SqlCommandBuilder

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'ToolStrip1.ImageScalingSize = New Size(200, 200)
        Count.MdiParent = Me
        Count.Show()
    End Sub
    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        setup.Close()
        Vendors.Close()
        PM.Close()
        Count.Close()
        Requests.Close()
        'Parts.Close()
        Work1.Close()
        Reports.Close()
        Parts.MdiParent = Me
        Parts.Show()
    End Sub
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        setup.Close()
        Vendors.Close()
        PM.Close()
        'Count.Close()
        Requests.Close()
        Parts.Close()
        Work1.Close()
        Reports.Close()
        Count.MdiParent = Me
        Count.Show()
    End Sub
    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        setup.Close()
        Vendors.Close()
        PM.Close()
        Count.Close()
        Requests.Close()
        Parts.Close()
        'Work1.Close()
        Reports.Close()
        Work1.MdiParent = Me
        Work1.Show()
    End Sub
    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        setup.Close()
        Vendors.Close()
        PM.Close()
        Count.Close()
        'Requests.Close()
        Parts.Close()
        Work1.Close()
        Reports.Close()
        Requests.MdiParent = Me
        Requests.Show()
    End Sub
    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        setup.Close()
        Vendors.Close()
        'PM.Close()
        Count.Close()
        Requests.Close()
        Parts.Close()
        Work1.Close()
        Reports.Close()
        PM.MdiParent = Me
        PM.Show()

    End Sub
    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        'setup.Close()
        Vendors.Close()
        PM.Close()
        Count.Close()
        Requests.Close()
        Parts.Close()
        Work1.Close()
        Reports.Close()
        setup.MdiParent = Me
        setup.Show()
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        setup.Close()
        'Vendors.Close()
        PM.Close()
        Count.Close()
        Requests.Close()
        Parts.Close()
        Work1.Close()
        Reports.Close()
        Vendors.MdiParent = Me
        Vendors.Show()

    End Sub
    Private Sub ToolStripButton11_Click(sender As Object, e As EventArgs) Handles ToolStripButton11.Click
        setup.Close()
        Vendors.Close()
        PM.Close()
        Count.Close()
        Requests.Close()
        Parts.Close()
        Work1.Close()
        'Reports.Close()
        Reports.MdiParent = Me
        Reports.Show()
    End Sub
    Private Sub ToolStripButton10_Click(sender As Object, e As EventArgs) Handles ToolStripButton10.Click
        End
    End Sub

    Private Sub ToolStripButton9_Click(sender As Object, e As EventArgs) Handles ToolStripButton9.Click
        About.Show()
    End Sub

    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs) Handles ToolStripButton8.Click
        Help.Show()
    End Sub

    Private Sub ToolStripButton12_Click(sender As Object, e As EventArgs) Handles ToolStripButton12.Click
        If Label2.Text = 0 Then
            LoginForm1.Show()
        Else
            Me.Text = "Simple CMMS"
            Label1.Text = ""
            Label2.Text = 0
            MsgBox("You Have Logged Out, Press The Login/Out Button To Login")
        End If
    End Sub
End Class
