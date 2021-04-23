<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmBusinessUnits
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
        Me.cmdNewBusinessUnit = New System.Windows.Forms.Button()
        Me.dgBusinessUnits = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.dgBusinessUnits, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'cmdNewBusinessUnit
        '
        Me.cmdNewBusinessUnit.Location = New System.Drawing.Point(264, 167)
        Me.cmdNewBusinessUnit.Name = "cmdNewBusinessUnit"
        Me.cmdNewBusinessUnit.Size = New System.Drawing.Size(119, 23)
        Me.cmdNewBusinessUnit.TabIndex = 23
        Me.cmdNewBusinessUnit.Text = "New Business Unit"
        Me.cmdNewBusinessUnit.UseVisualStyleBackColor = True
        '
        'dgBusinessUnits
        '
        Me.dgBusinessUnits.AllowUserToAddRows = False
        Me.dgBusinessUnits.AllowUserToDeleteRows = False
        Me.dgBusinessUnits.AllowUserToOrderColumns = True
        Me.dgBusinessUnits.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgBusinessUnits.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgBusinessUnits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgBusinessUnits.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dgBusinessUnits.Location = New System.Drawing.Point(9, 9)
        Me.dgBusinessUnits.Margin = New System.Windows.Forms.Padding(0)
        Me.dgBusinessUnits.Name = "dgBusinessUnits"
        Me.dgBusinessUnits.RowHeadersVisible = False
        Me.dgBusinessUnits.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgBusinessUnits.ShowCellErrors = False
        Me.dgBusinessUnits.ShowCellToolTips = False
        Me.dgBusinessUnits.ShowEditingIcon = False
        Me.dgBusinessUnits.ShowRowErrors = False
        Me.dgBusinessUnits.Size = New System.Drawing.Size(623, 147)
        Me.dgBusinessUnits.TabIndex = 27
        '
        'frmBusinessUnits
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(641, 202)
        Me.Controls.Add(Me.dgBusinessUnits)
        Me.Controls.Add(Me.cmdNewBusinessUnit)
        Me.Name = "frmBusinessUnits"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Business Units"
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.dgBusinessUnits, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuContextDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdNewBusinessUnit As System.Windows.Forms.Button
    Friend WithEvents dgBusinessUnits As System.Windows.Forms.DataGridView
End Class
