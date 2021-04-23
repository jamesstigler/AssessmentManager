<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInstallments
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
        Me.components = New System.ComponentModel.Container
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuContextDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdNewInstallment = New System.Windows.Forms.Button
        Me.dgInstallments = New System.Windows.Forms.DataGridView
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.dgInstallments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuContextDelete})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(117, 26)
        '
        'mnuContextDelete
        '
        Me.mnuContextDelete.Name = "mnuContextDelete"
        Me.mnuContextDelete.Size = New System.Drawing.Size(116, 22)
        Me.mnuContextDelete.Text = "Delete"
        '
        'cmdNewInstallment
        '
        Me.cmdNewInstallment.Location = New System.Drawing.Point(268, 164)
        Me.cmdNewInstallment.Name = "cmdNewInstallment"
        Me.cmdNewInstallment.Size = New System.Drawing.Size(99, 23)
        Me.cmdNewInstallment.TabIndex = 23
        Me.cmdNewInstallment.Text = "New Payment"
        Me.cmdNewInstallment.UseVisualStyleBackColor = True
        '
        'dgInstallments
        '
        Me.dgInstallments.AllowUserToAddRows = False
        Me.dgInstallments.AllowUserToDeleteRows = False
        Me.dgInstallments.AllowUserToOrderColumns = True
        Me.dgInstallments.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgInstallments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgInstallments.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dgInstallments.Location = New System.Drawing.Point(9, 9)
        Me.dgInstallments.Margin = New System.Windows.Forms.Padding(0)
        Me.dgInstallments.Name = "dgInstallments"
        Me.dgInstallments.RowHeadersVisible = False
        Me.dgInstallments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgInstallments.ShowCellErrors = False
        Me.dgInstallments.ShowCellToolTips = False
        Me.dgInstallments.ShowEditingIcon = False
        Me.dgInstallments.ShowRowErrors = False
        Me.dgInstallments.Size = New System.Drawing.Size(623, 147)
        Me.dgInstallments.TabIndex = 27
        '
        'frmInstallments
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(641, 192)
        Me.Controls.Add(Me.dgInstallments)
        Me.Controls.Add(Me.cmdNewInstallment)
        Me.Name = "frmInstallments"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Installments"
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.dgInstallments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuContextDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdNewInstallment As System.Windows.Forms.Button
    Friend WithEvents dgInstallments As System.Windows.Forms.DataGridView
End Class
