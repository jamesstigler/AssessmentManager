<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmEvent
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
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtEventValue = New System.Windows.Forms.TextBox()
        Me.txtEventDate = New System.Windows.Forms.TextBox()
        Me.txtEventNote = New System.Windows.Forms.TextBox()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboEvents = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Label29
        '
        Me.Label29.Location = New System.Drawing.Point(8, 52)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(64, 20)
        Me.Label29.TabIndex = 252
        Me.Label29.Text = "Date/Time"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label28
        '
        Me.Label28.Location = New System.Drawing.Point(24, 140)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(45, 17)
        Me.Label28.TabIndex = 251
        Me.Label28.Text = "Note"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(28, 76)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(42, 20)
        Me.Label27.TabIndex = 250
        Me.Label27.Text = "Value"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtEventValue
        '
        Me.txtEventValue.AllowDrop = True
        Me.txtEventValue.BackColor = System.Drawing.SystemColors.Window
        Me.txtEventValue.Location = New System.Drawing.Point(76, 76)
        Me.txtEventValue.Name = "txtEventValue"
        Me.txtEventValue.Size = New System.Drawing.Size(98, 20)
        Me.txtEventValue.TabIndex = 2
        Me.txtEventValue.Tag = ""
        Me.txtEventValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtEventValue.WordWrap = False
        '
        'txtEventDate
        '
        Me.txtEventDate.AllowDrop = True
        Me.txtEventDate.BackColor = System.Drawing.SystemColors.Window
        Me.txtEventDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEventDate.Location = New System.Drawing.Point(76, 52)
        Me.txtEventDate.Name = "txtEventDate"
        Me.txtEventDate.Size = New System.Drawing.Size(118, 20)
        Me.txtEventDate.TabIndex = 1
        Me.txtEventDate.Tag = ""
        '
        'txtEventNote
        '
        Me.txtEventNote.AllowDrop = True
        Me.txtEventNote.Location = New System.Drawing.Point(76, 100)
        Me.txtEventNote.Multiline = True
        Me.txtEventNote.Name = "txtEventNote"
        Me.txtEventNote.Size = New System.Drawing.Size(432, 56)
        Me.txtEventNote.TabIndex = 3
        Me.txtEventNote.Tag = ""
        '
        'cmdClose
        '
        Me.cmdClose.Location = New System.Drawing.Point(220, 168)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(75, 23)
        Me.cmdClose.TabIndex = 4
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 20)
        Me.Label1.TabIndex = 261
        Me.Label1.Text = "Event"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboEvents
        '
        Me.cboEvents.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboEvents.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboEvents.FormattingEnabled = True
        Me.cboEvents.Location = New System.Drawing.Point(76, 28)
        Me.cboEvents.Name = "cboEvents"
        Me.cboEvents.Size = New System.Drawing.Size(145, 21)
        Me.cboEvents.TabIndex = 0
        Me.cboEvents.Tag = ""
        '
        'frmEvent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(519, 199)
        Me.Controls.Add(Me.cboEvents)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.txtEventNote)
        Me.Controls.Add(Me.txtEventDate)
        Me.Controls.Add(Me.txtEventValue)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label27)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEvent"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Event"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label29 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents txtEventValue As TextBox
    Friend WithEvents txtEventDate As TextBox
    Friend WithEvents txtEventNote As TextBox
    Friend WithEvents cmdClose As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents cboEvents As ComboBox
End Class
