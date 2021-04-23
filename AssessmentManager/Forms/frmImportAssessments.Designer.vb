<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportAssessments
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
        Me.cboComment = New System.Windows.Forms.ComboBox
        Me.cboAcctNum = New System.Windows.Forms.ComboBox
        Me.dgImport = New System.Windows.Forms.DataGridView
        Me.cmdCancel = New System.Windows.Forms.Button
        CType(Me.dgImport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdNext
        '
        Me.cmdNext.Enabled = False
        Me.cmdNext.Location = New System.Drawing.Point(98, 452)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(75, 23)
        Me.cmdNext.TabIndex = 64
        Me.cmdNext.Text = "Next"
        Me.cmdNext.UseVisualStyleBackColor = True
        '
        'cmdFinish
        '
        Me.cmdFinish.Enabled = False
        Me.cmdFinish.Location = New System.Drawing.Point(179, 452)
        Me.cmdFinish.Name = "cmdFinish"
        Me.cmdFinish.Size = New System.Drawing.Size(75, 23)
        Me.cmdFinish.TabIndex = 63
        Me.cmdFinish.Text = "Finish"
        Me.cmdFinish.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(52, 42)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 13)
        Me.Label8.TabIndex = 62
        Me.Label8.Text = "Comment"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 55
        Me.Label1.Text = "Account number"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cboComment
        '
        Me.cboComment.FormattingEnabled = True
        Me.cboComment.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboComment.Location = New System.Drawing.Point(109, 39)
        Me.cboComment.Name = "cboComment"
        Me.cboComment.Size = New System.Drawing.Size(60, 21)
        Me.cboComment.TabIndex = 54
        '
        'cboAcctNum
        '
        Me.cboAcctNum.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAcctNum.FormattingEnabled = True
        Me.cboAcctNum.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboAcctNum.Location = New System.Drawing.Point(109, 12)
        Me.cboAcctNum.Name = "cboAcctNum"
        Me.cboAcctNum.Size = New System.Drawing.Size(60, 21)
        Me.cboAcctNum.TabIndex = 47
        '
        'dgImport
        '
        Me.dgImport.AllowUserToAddRows = False
        Me.dgImport.AllowUserToDeleteRows = False
        Me.dgImport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgImport.Location = New System.Drawing.Point(1, 75)
        Me.dgImport.Name = "dgImport"
        Me.dgImport.ReadOnly = True
        Me.dgImport.Size = New System.Drawing.Size(431, 351)
        Me.dgImport.TabIndex = 46
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(260, 452)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 45
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'frmImportAssessments
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(435, 479)
        Me.Controls.Add(Me.cmdNext)
        Me.Controls.Add(Me.cmdFinish)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboComment)
        Me.Controls.Add(Me.cboAcctNum)
        Me.Controls.Add(Me.dgImport)
        Me.Controls.Add(Me.cmdCancel)
        Me.Name = "frmImportAssessments"
        Me.Text = "frmImportAssessments"
        CType(Me.dgImport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdNext As System.Windows.Forms.Button
    Friend WithEvents cmdFinish As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboComment As System.Windows.Forms.ComboBox
    Friend WithEvents cboAcctNum As System.Windows.Forms.ComboBox
    Friend WithEvents dgImport As System.Windows.Forms.DataGridView
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
End Class
