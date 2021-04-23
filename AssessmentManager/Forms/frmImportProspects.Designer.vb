<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportProspects
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
        Me.grpAssign = New System.Windows.Forms.GroupBox
        Me.dgImport = New System.Windows.Forms.DataGridView
        Me.dgColumns = New System.Windows.Forms.DataGridView
        Me.grpImport = New System.Windows.Forms.GroupBox
        Me.dgAssignedImport = New System.Windows.Forms.DataGridView
        Me.cmdBack = New System.Windows.Forms.Button
        Me.cmdNext = New System.Windows.Forms.Button
        Me.cmdFinish = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.grpAssign.SuspendLayout()
        CType(Me.dgImport, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgColumns, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpImport.SuspendLayout()
        CType(Me.dgAssignedImport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpAssign
        '
        Me.grpAssign.Controls.Add(Me.dgImport)
        Me.grpAssign.Controls.Add(Me.dgColumns)
        Me.grpAssign.Location = New System.Drawing.Point(19, 32)
        Me.grpAssign.Name = "grpAssign"
        Me.grpAssign.Size = New System.Drawing.Size(778, 165)
        Me.grpAssign.TabIndex = 2
        Me.grpAssign.TabStop = False
        '
        'dgImport
        '
        Me.dgImport.AllowUserToAddRows = False
        Me.dgImport.AllowUserToDeleteRows = False
        Me.dgImport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgImport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgImport.Location = New System.Drawing.Point(349, 16)
        Me.dgImport.Name = "dgImport"
        Me.dgImport.ReadOnly = True
        Me.dgImport.RowHeadersVisible = False
        Me.dgImport.Size = New System.Drawing.Size(334, 117)
        Me.dgImport.TabIndex = 3
        '
        'dgColumns
        '
        Me.dgColumns.AllowUserToAddRows = False
        Me.dgColumns.AllowUserToDeleteRows = False
        Me.dgColumns.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgColumns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgColumns.Location = New System.Drawing.Point(3, 16)
        Me.dgColumns.Name = "dgColumns"
        Me.dgColumns.RowHeadersVisible = False
        Me.dgColumns.ShowEditingIcon = False
        Me.dgColumns.Size = New System.Drawing.Size(340, 117)
        Me.dgColumns.TabIndex = 2
        '
        'grpImport
        '
        Me.grpImport.Controls.Add(Me.dgAssignedImport)
        Me.grpImport.Location = New System.Drawing.Point(19, 216)
        Me.grpImport.Name = "grpImport"
        Me.grpImport.Size = New System.Drawing.Size(781, 174)
        Me.grpImport.TabIndex = 3
        Me.grpImport.TabStop = False
        Me.grpImport.Visible = False
        '
        'dgAssignedImport
        '
        Me.dgAssignedImport.AllowUserToAddRows = False
        Me.dgAssignedImport.AllowUserToDeleteRows = False
        Me.dgAssignedImport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgAssignedImport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgAssignedImport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgAssignedImport.Location = New System.Drawing.Point(3, 16)
        Me.dgAssignedImport.Name = "dgAssignedImport"
        Me.dgAssignedImport.ReadOnly = True
        Me.dgAssignedImport.RowHeadersVisible = False
        Me.dgAssignedImport.Size = New System.Drawing.Size(775, 155)
        Me.dgAssignedImport.TabIndex = 3
        '
        'cmdBack
        '
        Me.cmdBack.Enabled = False
        Me.cmdBack.Location = New System.Drawing.Point(250, 431)
        Me.cmdBack.Name = "cmdBack"
        Me.cmdBack.Size = New System.Drawing.Size(75, 23)
        Me.cmdBack.TabIndex = 38
        Me.cmdBack.Text = "Back"
        Me.cmdBack.UseVisualStyleBackColor = True
        '
        'cmdNext
        '
        Me.cmdNext.Location = New System.Drawing.Point(331, 431)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(75, 23)
        Me.cmdNext.TabIndex = 35
        Me.cmdNext.Text = "Next"
        Me.cmdNext.UseVisualStyleBackColor = True
        '
        'cmdFinish
        '
        Me.cmdFinish.Enabled = False
        Me.cmdFinish.Location = New System.Drawing.Point(412, 431)
        Me.cmdFinish.Name = "cmdFinish"
        Me.cmdFinish.Size = New System.Drawing.Size(75, 23)
        Me.cmdFinish.TabIndex = 36
        Me.cmdFinish.Text = "Finish"
        Me.cmdFinish.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(493, 431)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 37
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'frmImportProspects
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(809, 457)
        Me.Controls.Add(Me.cmdBack)
        Me.Controls.Add(Me.grpAssign)
        Me.Controls.Add(Me.cmdNext)
        Me.Controls.Add(Me.cmdFinish)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.grpImport)
        Me.Name = "frmImportProspects"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Import Prospects"
        Me.grpAssign.ResumeLayout(False)
        CType(Me.dgImport, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgColumns, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpImport.ResumeLayout(False)
        CType(Me.dgAssignedImport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpAssign As System.Windows.Forms.GroupBox
    Friend WithEvents dgImport As System.Windows.Forms.DataGridView
    Friend WithEvents dgColumns As System.Windows.Forms.DataGridView
    Friend WithEvents grpImport As System.Windows.Forms.GroupBox
    Friend WithEvents dgAssignedImport As System.Windows.Forms.DataGridView
    Friend WithEvents cmdBack As System.Windows.Forms.Button
    Friend WithEvents cmdNext As System.Windows.Forms.Button
    Friend WithEvents cmdFinish As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
End Class
