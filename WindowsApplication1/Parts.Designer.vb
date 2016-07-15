<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Parts
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.PartsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PartsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(797, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Label1"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 18)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.DataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(757, 470)
        Me.DataGridView1.TabIndex = 27
        '
        'Button11
        '
        Me.Button11.Location = New System.Drawing.Point(800, 36)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(172, 40)
        Me.Button11.TabIndex = 28
        Me.Button11.Text = "Add Part"
        Me.Button11.UseVisualStyleBackColor = True
        '
        'Button12
        '
        Me.Button12.Location = New System.Drawing.Point(800, 82)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(172, 40)
        Me.Button12.TabIndex = 29
        Me.Button12.Text = "Del Part"
        Me.Button12.UseVisualStyleBackColor = True
        '
        'PartsBindingSource
        '
        Me.PartsBindingSource.DataMember = "Parts"
        '
        'Parts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(990, 500)
        Me.Controls.Add(Me.Button12)
        Me.Controls.Add(Me.Button11)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Parts"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Parts"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PartsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents IDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PNumberDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PTypeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PLocationDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PCostsDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PVendorDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PKeywordsDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PManufPartNumberDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PMinDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PCountDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PReorderCountDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PartsBindingSource As BindingSource
    Friend WithEvents Label1 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button11 As Button
    Friend WithEvents Button12 As Button
End Class
