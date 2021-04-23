<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportFactorCodes
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
        Me.cmdNext = New System.Windows.Forms.Button
        Me.cmdFinish = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboDescription = New System.Windows.Forms.ComboBox
        Me.cboFactorCode = New System.Windows.Forms.ComboBox
        Me.dgImport = New System.Windows.Forms.DataGridView
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboAge = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboPercentage = New System.Windows.Forms.ComboBox
        CType(Me.dgImport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdNext
        '
        Me.cmdNext.Enabled = False
        Me.cmdNext.Location = New System.Drawing.Point(99, 452)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(75, 23)
        Me.cmdNext.TabIndex = 80
        Me.cmdNext.Text = "Next"
        Me.cmdNext.UseVisualStyleBackColor = True
        '
        'cmdFinish
        '
        Me.cmdFinish.Enabled = False
        Me.cmdFinish.Location = New System.Drawing.Point(180, 452)
        Me.cmdFinish.Name = "cmdFinish"
        Me.cmdFinish.Size = New System.Drawing.Size(75, 23)
        Me.cmdFinish.TabIndex = 79
        Me.cmdFinish.Text = "Finish"
        Me.cmdFinish.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(22, 42)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(82, 18)
        Me.Label8.TabIndex = 78
        Me.Label8.Text = "Description"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(19, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 18)
        Me.Label1.TabIndex = 77
        Me.Label1.Text = "Factor Code"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cboDescription
        '
        Me.cboDescription.FormattingEnabled = True
        Me.cboDescription.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboDescription.Location = New System.Drawing.Point(110, 39)
        Me.cboDescription.Name = "cboDescription"
        Me.cboDescription.Size = New System.Drawing.Size(60, 21)
        Me.cboDescription.TabIndex = 76
        '
        'cboFactorCode
        '
        Me.cboFactorCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboFactorCode.FormattingEnabled = True
        Me.cboFactorCode.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboFactorCode.Location = New System.Drawing.Point(110, 12)
        Me.cboFactorCode.Name = "cboFactorCode"
        Me.cboFactorCode.Size = New System.Drawing.Size(60, 21)
        Me.cboFactorCode.TabIndex = 75
        '
        'dgImport
        '
        Me.dgImport.AllowUserToAddRows = False
        Me.dgImport.AllowUserToDeleteRows = False
        Me.dgImport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgImport.Location = New System.Drawing.Point(2, 75)
        Me.dgImport.Name = "dgImport"
        Me.dgImport.ReadOnly = True
        Me.dgImport.Size = New System.Drawing.Size(431, 351)
        Me.dgImport.TabIndex = 74
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(261, 452)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 73
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(188, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 18)
        Me.Label2.TabIndex = 82
        Me.Label2.Text = "Age"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cboAge
        '
        Me.cboAge.FormattingEnabled = True
        Me.cboAge.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboAge.Location = New System.Drawing.Point(276, 12)
        Me.cboAge.Name = "cboAge"
        Me.cboAge.Size = New System.Drawing.Size(60, 21)
        Me.cboAge.TabIndex = 81
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(188, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 18)
        Me.Label3.TabIndex = 84
        Me.Label3.Text = "Percentage"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cboPercentage
        '
        Me.cboPercentage.FormattingEnabled = True
        Me.cboPercentage.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboPercentage.Location = New System.Drawing.Point(276, 39)
        Me.cboPercentage.Name = "cboPercentage"
        Me.cboPercentage.Size = New System.Drawing.Size(60, 21)
        Me.cboPercentage.TabIndex = 83
        '
        'frmImportFactorCodes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(437, 478)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboPercentage)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboAge)
        Me.Controls.Add(Me.cmdNext)
        Me.Controls.Add(Me.cmdFinish)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboDescription)
        Me.Controls.Add(Me.cboFactorCode)
        Me.Controls.Add(Me.dgImport)
        Me.Controls.Add(Me.cmdCancel)
        Me.Name = "frmImportFactorCodes"
        Me.Text = "frmImportFactorCodes"
        CType(Me.dgImport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdNext As System.Windows.Forms.Button
    Friend WithEvents cmdFinish As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cboFactorCode As System.Windows.Forms.ComboBox
    Friend WithEvents dgImport As System.Windows.Forms.DataGridView
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboAge As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboPercentage As System.Windows.Forms.ComboBox
End Class
