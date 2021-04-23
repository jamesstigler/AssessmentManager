<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFirmInfo
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
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtPhone = New System.Windows.Forms.TextBox()
        Me.txtFax = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboStateCd = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCity = New System.Windows.Forms.TextBox()
        Me.txtZip = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(8, 63)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(38, 13)
        Me.Label8.TabIndex = 170
        Me.Label8.Text = "Phone"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(242, 63)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(24, 13)
        Me.Label7.TabIndex = 169
        Me.Label7.Text = "Fax"
        '
        'txtPhone
        '
        Me.txtPhone.Location = New System.Drawing.Point(108, 60)
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Size = New System.Drawing.Size(123, 20)
        Me.txtPhone.TabIndex = 156
        Me.txtPhone.Tag = "@DB=FirmInfo.Phone"
        '
        'txtFax
        '
        Me.txtFax.Location = New System.Drawing.Point(272, 60)
        Me.txtFax.Name = "txtFax"
        Me.txtFax.Size = New System.Drawing.Size(123, 20)
        Me.txtFax.TabIndex = 157
        Me.txtFax.Tag = "@DB=FirmInfo.Fax"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(108, 86)
        Me.TextBox3.Multiline = True
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(462, 20)
        Me.TextBox3.TabIndex = 158
        Me.TextBox3.Tag = "@DB=FirmInfo.DocumentFileshare"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 89)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 13)
        Me.Label3.TabIndex = 167
        Me.Label3.Text = "Document fileshare"
        '
        'cboStateCd
        '
        Me.cboStateCd.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboStateCd.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboStateCd.FormattingEnabled = True
        Me.cboStateCd.Location = New System.Drawing.Point(348, 33)
        Me.cboStateCd.Name = "cboStateCd"
        Me.cboStateCd.Size = New System.Drawing.Size(145, 21)
        Me.cboStateCd.TabIndex = 154
        Me.cboStateCd.Tag = "@DB=FirmInfo.StateCd"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 165
        Me.Label5.Text = "Address"
        '
        'txtAddress
        '
        Me.txtAddress.Location = New System.Drawing.Point(108, 8)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(462, 20)
        Me.txtAddress.TabIndex = 151
        Me.txtAddress.Tag = "@DB=FirmInfo.Address"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 36)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 13)
        Me.Label4.TabIndex = 164
        Me.Label4.Text = "City, State  Zip"
        '
        'txtCity
        '
        Me.txtCity.Location = New System.Drawing.Point(108, 34)
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(234, 20)
        Me.txtCity.TabIndex = 153
        Me.txtCity.Tag = "@DB=FirmInfo.City"
        '
        'txtZip
        '
        Me.txtZip.Location = New System.Drawing.Point(499, 33)
        Me.txtZip.Name = "txtZip"
        Me.txtZip.Size = New System.Drawing.Size(71, 20)
        Me.txtZip.TabIndex = 155
        Me.txtZip.Tag = "@DB=FirmInfo.Zip"
        '
        'frmFirmInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(576, 115)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtPhone)
        Me.Controls.Add(Me.txtFax)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboStateCd)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtAddress)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtCity)
        Me.Controls.Add(Me.txtZip)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFirmInfo"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Agent Information"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtPhone As System.Windows.Forms.TextBox
    Friend WithEvents txtFax As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboStateCd As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCity As System.Windows.Forms.TextBox
    Friend WithEvents txtZip As System.Windows.Forms.TextBox
End Class
