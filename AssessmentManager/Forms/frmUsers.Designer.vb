<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUsers
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuContextDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmdNewUser = New System.Windows.Forms.Button()
        Me.dgUsers = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.dgUsers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuContextDelete})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(108, 26)
        '
        'mnuContextDelete
        '
        Me.mnuContextDelete.Name = "mnuContextDelete"
        Me.mnuContextDelete.Size = New System.Drawing.Size(107, 22)
        Me.mnuContextDelete.Text = "Delete"
        '
        'cmdNewUser
        '
        Me.cmdNewUser.Location = New System.Drawing.Point(424, 408)
        Me.cmdNewUser.Name = "cmdNewUser"
        Me.cmdNewUser.Size = New System.Drawing.Size(99, 23)
        Me.cmdNewUser.TabIndex = 23
        Me.cmdNewUser.Text = "New User"
        Me.cmdNewUser.UseVisualStyleBackColor = True
        '
        'dgUsers
        '
        Me.dgUsers.AllowUserToAddRows = False
        Me.dgUsers.AllowUserToDeleteRows = False
        Me.dgUsers.AllowUserToOrderColumns = True
        Me.dgUsers.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgUsers.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dgUsers.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgUsers.Location = New System.Drawing.Point(0, 0)
        Me.dgUsers.Margin = New System.Windows.Forms.Padding(0)
        Me.dgUsers.Name = "dgUsers"
        Me.dgUsers.RowHeadersVisible = False
        Me.dgUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgUsers.ShowCellErrors = False
        Me.dgUsers.ShowCellToolTips = False
        Me.dgUsers.ShowEditingIcon = False
        Me.dgUsers.ShowRowErrors = False
        Me.dgUsers.Size = New System.Drawing.Size(949, 396)
        Me.dgUsers.TabIndex = 27
        '
        'frmUsers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(949, 440)
        Me.Controls.Add(Me.dgUsers)
        Me.Controls.Add(Me.cmdNewUser)
        Me.Name = "frmUsers"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Users"
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.dgUsers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuContextDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdNewUser As System.Windows.Forms.Button
    Friend WithEvents dgUsers As System.Windows.Forms.DataGridView
End Class
