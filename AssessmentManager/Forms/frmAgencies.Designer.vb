<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAgencies
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
        Me.dgAgencies = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuContextDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmdNewAgency = New System.Windows.Forms.Button()
        CType(Me.dgAgencies, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgAgencies
        '
        Me.dgAgencies.AllowUserToAddRows = False
        Me.dgAgencies.AllowUserToDeleteRows = False
        Me.dgAgencies.AllowUserToOrderColumns = True
        Me.dgAgencies.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgAgencies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgAgencies.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dgAgencies.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgAgencies.Location = New System.Drawing.Point(0, 0)
        Me.dgAgencies.Margin = New System.Windows.Forms.Padding(0)
        Me.dgAgencies.Name = "dgAgencies"
        Me.dgAgencies.RowHeadersVisible = False
        Me.dgAgencies.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgAgencies.ShowCellErrors = False
        Me.dgAgencies.ShowCellToolTips = False
        Me.dgAgencies.ShowEditingIcon = False
        Me.dgAgencies.ShowRowErrors = False
        Me.dgAgencies.Size = New System.Drawing.Size(800, 396)
        Me.dgAgencies.TabIndex = 28
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
        'cmdNewAgency
        '
        Me.cmdNewAgency.Location = New System.Drawing.Point(348, 412)
        Me.cmdNewAgency.Name = "cmdNewAgency"
        Me.cmdNewAgency.Size = New System.Drawing.Size(99, 23)
        Me.cmdNewAgency.TabIndex = 29
        Me.cmdNewAgency.Text = "New Agency"
        Me.cmdNewAgency.UseVisualStyleBackColor = True
        '
        'frmAgencies
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.cmdNewAgency)
        Me.Controls.Add(Me.dgAgencies)
        Me.Name = "frmAgencies"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Agencies"
        CType(Me.dgAgencies, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgAgencies As DataGridView
    Friend WithEvents cmdNewAgency As Button
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents mnuContextDelete As ToolStripMenuItem
End Class
