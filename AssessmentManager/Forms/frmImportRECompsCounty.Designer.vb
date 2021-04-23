<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportRECompsCounty
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
        Me.cmdBack = New System.Windows.Forms.Button()
        Me.cmdNext = New System.Windows.Forms.Button()
        Me.cmdFinish = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.fraFile = New System.Windows.Forms.GroupBox()
        Me.txtThreshhold = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cmdBrowse = New System.Windows.Forms.Button()
        Me.txtFolder = New System.Windows.Forms.TextBox()
        Me.fraResults = New System.Windows.Forms.GroupBox()
        Me.lblTotals = New System.Windows.Forms.Label()
        Me.fraFile.SuspendLayout()
        Me.fraResults.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdBack
        '
        Me.cmdBack.Enabled = False
        Me.cmdBack.Location = New System.Drawing.Point(223, 413)
        Me.cmdBack.Name = "cmdBack"
        Me.cmdBack.Size = New System.Drawing.Size(75, 23)
        Me.cmdBack.TabIndex = 6
        Me.cmdBack.Text = "Back"
        Me.cmdBack.UseVisualStyleBackColor = True
        '
        'cmdNext
        '
        Me.cmdNext.Enabled = False
        Me.cmdNext.Location = New System.Drawing.Point(303, 413)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(75, 23)
        Me.cmdNext.TabIndex = 7
        Me.cmdNext.Text = "Next"
        Me.cmdNext.UseVisualStyleBackColor = True
        '
        'cmdFinish
        '
        Me.cmdFinish.Enabled = False
        Me.cmdFinish.Location = New System.Drawing.Point(384, 412)
        Me.cmdFinish.Name = "cmdFinish"
        Me.cmdFinish.Size = New System.Drawing.Size(75, 23)
        Me.cmdFinish.TabIndex = 8
        Me.cmdFinish.Text = "Finish"
        Me.cmdFinish.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(465, 412)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 9
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'fraFile
        '
        Me.fraFile.AutoSize = True
        Me.fraFile.Controls.Add(Me.txtThreshhold)
        Me.fraFile.Controls.Add(Me.Label15)
        Me.fraFile.Controls.Add(Me.cmdBrowse)
        Me.fraFile.Controls.Add(Me.txtFolder)
        Me.fraFile.Location = New System.Drawing.Point(12, 4)
        Me.fraFile.Name = "fraFile"
        Me.fraFile.Size = New System.Drawing.Size(600, 108)
        Me.fraFile.TabIndex = 10
        Me.fraFile.TabStop = False
        '
        'txtThreshhold
        '
        Me.txtThreshhold.Location = New System.Drawing.Point(140, 64)
        Me.txtThreshhold.Name = "txtThreshhold"
        Me.txtThreshhold.Size = New System.Drawing.Size(68, 20)
        Me.txtThreshhold.TabIndex = 13
        Me.txtThreshhold.Text = "250,000"
        Me.txtThreshhold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(12, 68)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(120, 16)
        Me.Label15.TabIndex = 12
        Me.Label15.Text = "Total Value Threshhold"
        '
        'cmdBrowse
        '
        Me.cmdBrowse.Location = New System.Drawing.Point(11, 38)
        Me.cmdBrowse.Name = "cmdBrowse"
        Me.cmdBrowse.Size = New System.Drawing.Size(75, 23)
        Me.cmdBrowse.TabIndex = 0
        Me.cmdBrowse.Text = "Browse"
        Me.cmdBrowse.UseVisualStyleBackColor = True
        '
        'txtFolder
        '
        Me.txtFolder.Location = New System.Drawing.Point(92, 40)
        Me.txtFolder.Name = "txtFolder"
        Me.txtFolder.Size = New System.Drawing.Size(488, 20)
        Me.txtFolder.TabIndex = 1
        Me.txtFolder.Text = "Files must exist in a folder on the network"
        '
        'fraResults
        '
        Me.fraResults.Controls.Add(Me.lblTotals)
        Me.fraResults.Location = New System.Drawing.Point(111, 180)
        Me.fraResults.Name = "fraResults"
        Me.fraResults.Size = New System.Drawing.Size(579, 91)
        Me.fraResults.TabIndex = 11
        Me.fraResults.TabStop = False
        Me.fraResults.Visible = False
        '
        'lblTotals
        '
        Me.lblTotals.Location = New System.Drawing.Point(5, 11)
        Me.lblTotals.Name = "lblTotals"
        Me.lblTotals.Size = New System.Drawing.Size(459, 13)
        Me.lblTotals.TabIndex = 73
        Me.lblTotals.Text = "Number of rows in file:"
        Me.lblTotals.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmImportRECompsCounty
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.fraResults)
        Me.Controls.Add(Me.fraFile)
        Me.Controls.Add(Me.cmdBack)
        Me.Controls.Add(Me.cmdNext)
        Me.Controls.Add(Me.cmdFinish)
        Me.Controls.Add(Me.cmdCancel)
        Me.Name = "frmImportRECompsCounty"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Import RE Comps Using County Files"
        Me.fraFile.ResumeLayout(False)
        Me.fraFile.PerformLayout()
        Me.fraResults.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmdBack As Button
    Friend WithEvents cmdNext As Button
    Friend WithEvents cmdFinish As Button
    Friend WithEvents cmdCancel As Button
    Friend WithEvents fraFile As GroupBox
    Friend WithEvents cmdBrowse As Button
    Friend WithEvents txtFolder As TextBox
    Friend WithEvents txtThreshhold As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents fraResults As GroupBox
    Friend WithEvents lblTotals As Label
End Class
