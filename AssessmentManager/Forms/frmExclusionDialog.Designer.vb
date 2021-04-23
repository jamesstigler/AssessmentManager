<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExclusionDialog
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
        Me.lblClient = New System.Windows.Forms.Label()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkClient = New System.Windows.Forms.CheckBox()
        Me.chkFreeport = New System.Windows.Forms.CheckBox()
        Me.chkEntire = New System.Windows.Forms.CheckBox()
        Me.chkAbatements = New System.Windows.Forms.CheckBox()
        Me.chkNotified = New System.Windows.Forms.CheckBox()
        Me.cboAccount = New System.Windows.Forms.ComboBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblClient
        '
        Me.lblClient.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClient.Location = New System.Drawing.Point(12, 9)
        Me.lblClient.Name = "lblClient"
        Me.lblClient.Size = New System.Drawing.Size(344, 25)
        Me.lblClient.TabIndex = 12
        Me.lblClient.UseMnemonic = False
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(203, 173)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(69, 26)
        Me.cmdCancel.TabIndex = 11
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(109, 173)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(69, 26)
        Me.cmdSave.TabIndex = 10
        Me.cmdSave.Text = "&Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkClient)
        Me.GroupBox1.Controls.Add(Me.chkFreeport)
        Me.GroupBox1.Controls.Add(Me.chkEntire)
        Me.GroupBox1.Controls.Add(Me.chkAbatements)
        Me.GroupBox1.Controls.Add(Me.chkNotified)
        Me.GroupBox1.Location = New System.Drawing.Point(90, 64)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(203, 103)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Exclusion Type:"
        '
        'chkClient
        '
        Me.chkClient.AutoSize = True
        Me.chkClient.Location = New System.Drawing.Point(117, 43)
        Me.chkClient.Name = "chkClient"
        Me.chkClient.Size = New System.Drawing.Size(52, 17)
        Me.chkClient.TabIndex = 4
        Me.chkClient.Text = "Client"
        Me.chkClient.UseVisualStyleBackColor = True
        '
        'chkFreeport
        '
        Me.chkFreeport.AutoSize = True
        Me.chkFreeport.Location = New System.Drawing.Point(117, 66)
        Me.chkFreeport.Name = "chkFreeport"
        Me.chkFreeport.Size = New System.Drawing.Size(65, 17)
        Me.chkFreeport.TabIndex = 3
        Me.chkFreeport.Text = "Freeport"
        Me.chkFreeport.UseVisualStyleBackColor = True
        Me.chkFreeport.Visible = False
        '
        'chkEntire
        '
        Me.chkEntire.AutoSize = True
        Me.chkEntire.Location = New System.Drawing.Point(14, 20)
        Me.chkEntire.Name = "chkEntire"
        Me.chkEntire.Size = New System.Drawing.Size(96, 17)
        Me.chkEntire.TabIndex = 2
        Me.chkEntire.Text = "Entire Account"
        Me.chkEntire.UseVisualStyleBackColor = True
        '
        'chkAbatements
        '
        Me.chkAbatements.AutoSize = True
        Me.chkAbatements.Location = New System.Drawing.Point(14, 66)
        Me.chkAbatements.Name = "chkAbatements"
        Me.chkAbatements.Size = New System.Drawing.Size(82, 17)
        Me.chkAbatements.TabIndex = 1
        Me.chkAbatements.Text = "Abatements"
        Me.chkAbatements.UseVisualStyleBackColor = True
        Me.chkAbatements.Visible = False
        '
        'chkNotified
        '
        Me.chkNotified.AutoSize = True
        Me.chkNotified.Location = New System.Drawing.Point(14, 43)
        Me.chkNotified.Name = "chkNotified"
        Me.chkNotified.Size = New System.Drawing.Size(62, 17)
        Me.chkNotified.TabIndex = 0
        Me.chkNotified.Text = "Notified"
        Me.chkNotified.UseVisualStyleBackColor = True
        '
        'cboAccount
        '
        Me.cboAccount.FormattingEnabled = True
        Me.cboAccount.Location = New System.Drawing.Point(15, 37)
        Me.cboAccount.Name = "cboAccount"
        Me.cboAccount.Size = New System.Drawing.Size(341, 21)
        Me.cboAccount.TabIndex = 13
        '
        'frmExclusionDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(374, 206)
        Me.Controls.Add(Me.cboAccount)
        Me.Controls.Add(Me.lblClient)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmExclusionDialog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Savings Exclusions"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblClient As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboAccount As System.Windows.Forms.ComboBox
    Friend WithEvents chkFreeport As System.Windows.Forms.CheckBox
    Friend WithEvents chkEntire As System.Windows.Forms.CheckBox
    Friend WithEvents chkAbatements As System.Windows.Forms.CheckBox
    Friend WithEvents chkNotified As System.Windows.Forms.CheckBox
    Friend WithEvents chkClient As System.Windows.Forms.CheckBox
End Class
