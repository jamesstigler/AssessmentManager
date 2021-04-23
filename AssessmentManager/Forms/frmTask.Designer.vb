<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTask
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
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtName = New System.Windows.Forms.TextBox
        Me.txtTaskDate = New System.Windows.Forms.TextBox
        Me.txtReminderDate = New System.Windows.Forms.TextBox
        Me.chkEntitySpecific = New System.Windows.Forms.CheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 129)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(106, 13)
        Me.Label6.TabIndex = 133
        Me.Label6.Text = "Reminder Date/Time"
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(142, 38)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(432, 56)
        Me.txtDescription.TabIndex = 1
        Me.txtDescription.Tag = "@DB=TaskMasterList.Description"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 41)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 13)
        Me.Label5.TabIndex = 125
        Me.Label5.Text = "Description"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 103)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 13)
        Me.Label4.TabIndex = 124
        Me.Label4.Text = "Date/Time"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 127
        Me.Label1.Text = "Name"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(142, 12)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(432, 20)
        Me.txtName.TabIndex = 0
        Me.txtName.Tag = "@DB=TaskMasterList.Name"
        '
        'txtTaskDate
        '
        Me.txtTaskDate.Location = New System.Drawing.Point(142, 100)
        Me.txtTaskDate.Name = "txtTaskDate"
        Me.txtTaskDate.Size = New System.Drawing.Size(114, 20)
        Me.txtTaskDate.TabIndex = 2
        Me.txtTaskDate.Tag = "@DB=TaskMasterList.TaskDate;@fmt=DATETIME"
        '
        'txtReminderDate
        '
        Me.txtReminderDate.Location = New System.Drawing.Point(142, 126)
        Me.txtReminderDate.Name = "txtReminderDate"
        Me.txtReminderDate.Size = New System.Drawing.Size(114, 20)
        Me.txtReminderDate.TabIndex = 3
        Me.txtReminderDate.Tag = "@DB=TaskMasterList.ReminderDate;@fmt=DATETIME"
        '
        'chkEntitySpecific
        '
        Me.chkEntitySpecific.AutoSize = True
        Me.chkEntitySpecific.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkEntitySpecific.Location = New System.Drawing.Point(142, 152)
        Me.chkEntitySpecific.Name = "chkEntitySpecific"
        Me.chkEntitySpecific.Size = New System.Drawing.Size(15, 14)
        Me.chkEntitySpecific.TabIndex = 134
        Me.chkEntitySpecific.Tag = "@DB=TaskMasterList.EntitySpecific"
        Me.chkEntitySpecific.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 152)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 13)
        Me.Label2.TabIndex = 135
        Me.Label2.Text = "Assign to entity"
        '
        'frmTask
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(581, 172)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.chkEntitySpecific)
        Me.Controls.Add(Me.txtReminderDate)
        Me.Controls.Add(Me.txtTaskDate)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtName)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTask"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Task"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents txtTaskDate As System.Windows.Forms.TextBox
    Friend WithEvents txtReminderDate As System.Windows.Forms.TextBox
    Friend WithEvents chkEntitySpecific As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
