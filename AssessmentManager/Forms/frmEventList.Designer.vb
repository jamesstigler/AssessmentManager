<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmEventList
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
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuContextDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmdNewEvent = New System.Windows.Forms.Button()
        Me.dgEvents = New System.Windows.Forms.DataGridView()
        Me.mnuContextRename = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.dgEvents, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuContextDelete, Me.mnuContextRename})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(181, 70)
        '
        'mnuContextDelete
        '
        Me.mnuContextDelete.Name = "mnuContextDelete"
        Me.mnuContextDelete.Size = New System.Drawing.Size(180, 22)
        Me.mnuContextDelete.Text = "Delete"
        '
        'cmdNewEvent
        '
        Me.cmdNewEvent.Location = New System.Drawing.Point(264, 324)
        Me.cmdNewEvent.Name = "cmdNewEvent"
        Me.cmdNewEvent.Size = New System.Drawing.Size(108, 23)
        Me.cmdNewEvent.TabIndex = 23
        Me.cmdNewEvent.Text = "New Event"
        Me.cmdNewEvent.UseVisualStyleBackColor = True
        '
        'dgEvents
        '
        Me.dgEvents.AllowUserToAddRows = False
        Me.dgEvents.AllowUserToDeleteRows = False
        Me.dgEvents.AllowUserToOrderColumns = True
        Me.dgEvents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgEvents.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgEvents.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dgEvents.Location = New System.Drawing.Point(9, 9)
        Me.dgEvents.Margin = New System.Windows.Forms.Padding(0)
        Me.dgEvents.Name = "dgEvents"
        Me.dgEvents.RowHeadersVisible = False
        Me.dgEvents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgEvents.ShowCellErrors = False
        Me.dgEvents.ShowCellToolTips = False
        Me.dgEvents.ShowEditingIcon = False
        Me.dgEvents.ShowRowErrors = False
        Me.dgEvents.Size = New System.Drawing.Size(623, 307)
        Me.dgEvents.TabIndex = 27
        '
        'mnuContextRename
        '
        Me.mnuContextRename.Name = "mnuContextRename"
        Me.mnuContextRename.Size = New System.Drawing.Size(180, 22)
        Me.mnuContextRename.Text = "Rename"
        '
        'frmEventList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(641, 356)
        Me.Controls.Add(Me.dgEvents)
        Me.Controls.Add(Me.cmdNewEvent)
        Me.Name = "frmEventList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Event List"
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.dgEvents, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuContextDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdNewEvent As System.Windows.Forms.Button
    Friend WithEvents dgEvents As System.Windows.Forms.DataGridView
    Friend WithEvents mnuContextRename As ToolStripMenuItem
End Class
