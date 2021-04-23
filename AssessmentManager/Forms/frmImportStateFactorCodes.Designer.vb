<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportStateFactorCodes
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
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboDescription = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboName = New System.Windows.Forms.ComboBox
        Me.cmdNext = New System.Windows.Forms.Button
        Me.cmdFinish = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboCode = New System.Windows.Forms.ComboBox
        Me.cboStateCd = New System.Windows.Forms.ComboBox
        Me.dgImport = New System.Windows.Forms.DataGridView
        Me.cmdCancel = New System.Windows.Forms.Button
        CType(Me.dgImport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(191, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 18)
        Me.Label3.TabIndex = 96
        Me.Label3.Text = "Description"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboDescription
        '
        Me.cboDescription.FormattingEnabled = True
        Me.cboDescription.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboDescription.Location = New System.Drawing.Point(279, 42)
        Me.cboDescription.Name = "cboDescription"
        Me.cboDescription.Size = New System.Drawing.Size(60, 21)
        Me.cboDescription.TabIndex = 95
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(191, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 18)
        Me.Label2.TabIndex = 94
        Me.Label2.Text = "Name"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboName
        '
        Me.cboName.FormattingEnabled = True
        Me.cboName.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboName.Location = New System.Drawing.Point(279, 15)
        Me.cboName.Name = "cboName"
        Me.cboName.Size = New System.Drawing.Size(60, 21)
        Me.cboName.TabIndex = 93
        '
        'cmdNext
        '
        Me.cmdNext.Enabled = False
        Me.cmdNext.Location = New System.Drawing.Point(102, 455)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(75, 23)
        Me.cmdNext.TabIndex = 92
        Me.cmdNext.Text = "Next"
        Me.cmdNext.UseVisualStyleBackColor = True
        '
        'cmdFinish
        '
        Me.cmdFinish.Enabled = False
        Me.cmdFinish.Location = New System.Drawing.Point(183, 455)
        Me.cmdFinish.Name = "cmdFinish"
        Me.cmdFinish.Size = New System.Drawing.Size(75, 23)
        Me.cmdFinish.TabIndex = 91
        Me.cmdFinish.Text = "Finish"
        Me.cmdFinish.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(25, 45)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(82, 18)
        Me.Label8.TabIndex = 90
        Me.Label8.Text = "Code"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(22, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 18)
        Me.Label1.TabIndex = 89
        Me.Label1.Text = "State"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboCode
        '
        Me.cboCode.FormattingEnabled = True
        Me.cboCode.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboCode.Location = New System.Drawing.Point(113, 42)
        Me.cboCode.Name = "cboCode"
        Me.cboCode.Size = New System.Drawing.Size(60, 21)
        Me.cboCode.TabIndex = 88
        '
        'cboStateCd
        '
        Me.cboStateCd.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboStateCd.FormattingEnabled = True
        Me.cboStateCd.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboStateCd.Location = New System.Drawing.Point(113, 15)
        Me.cboStateCd.Name = "cboStateCd"
        Me.cboStateCd.Size = New System.Drawing.Size(60, 21)
        Me.cboStateCd.TabIndex = 87
        '
        'dgImport
        '
        Me.dgImport.AllowUserToAddRows = False
        Me.dgImport.AllowUserToDeleteRows = False
        Me.dgImport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgImport.Location = New System.Drawing.Point(5, 78)
        Me.dgImport.Name = "dgImport"
        Me.dgImport.ReadOnly = True
        Me.dgImport.Size = New System.Drawing.Size(431, 351)
        Me.dgImport.TabIndex = 86
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(264, 455)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 85
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'frmImportStateFactorCodes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(443, 485)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboDescription)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboName)
        Me.Controls.Add(Me.cmdNext)
        Me.Controls.Add(Me.cmdFinish)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboCode)
        Me.Controls.Add(Me.cboStateCd)
        Me.Controls.Add(Me.dgImport)
        Me.Controls.Add(Me.cmdCancel)
        Me.Name = "frmImportStateFactorCodes"
        Me.Text = "frmImportStateFactorCodes"
        CType(Me.dgImport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboDescription As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboName As System.Windows.Forms.ComboBox
    Friend WithEvents cmdNext As System.Windows.Forms.Button
    Friend WithEvents cmdFinish As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboCode As System.Windows.Forms.ComboBox
    Friend WithEvents cboStateCd As System.Windows.Forms.ComboBox
    Friend WithEvents dgImport As System.Windows.Forms.DataGridView
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
End Class
