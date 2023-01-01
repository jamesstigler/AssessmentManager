<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAssessor
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
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.txtComment = New System.Windows.Forms.TextBox()
        Me.cboStateCd = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCity = New System.Windows.Forms.TextBox()
        Me.txtZip = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtPhone = New System.Windows.Forms.TextBox()
        Me.txtFax = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtPercentage = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.cmdEnvelope = New System.Windows.Forms.Button()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TextBox9 = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cboValueProtestStateCd = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtValueProtestAddress = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtValueProtestCity = New System.Windows.Forms.TextBox()
        Me.txtValueProtestZip = New System.Windows.Forms.TextBox()
        Me.txtRenditionExtDate = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 256)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 13)
        Me.Label6.TabIndex = 133
        Me.Label6.Text = "Comments"
        '
        'TextBox3
        '
        Me.TextBox3.AllowDrop = True
        Me.TextBox3.Location = New System.Drawing.Point(200, 226)
        Me.TextBox3.Multiline = True
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(432, 20)
        Me.TextBox3.TabIndex = 8
        Me.TextBox3.Tag = "@DB=Assessors.WebSite"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 230)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 131
        Me.Label3.Text = "Web Site"
        '
        'TextBox1
        '
        Me.TextBox1.AllowDrop = True
        Me.TextBox1.Location = New System.Drawing.Point(200, 60)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(428, 20)
        Me.TextBox1.TabIndex = 2
        Me.TextBox1.Tag = "@DB=Assessors.Address2"
        '
        'txtComment
        '
        Me.txtComment.AllowDrop = True
        Me.txtComment.Location = New System.Drawing.Point(200, 252)
        Me.txtComment.Multiline = True
        Me.txtComment.Name = "txtComment"
        Me.txtComment.Size = New System.Drawing.Size(432, 56)
        Me.txtComment.TabIndex = 9
        Me.txtComment.Tag = "@DB=Assessors.Comment"
        '
        'cboStateCd
        '
        Me.cboStateCd.AllowDrop = True
        Me.cboStateCd.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboStateCd.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboStateCd.FormattingEnabled = True
        Me.cboStateCd.Location = New System.Drawing.Point(408, 84)
        Me.cboStateCd.Name = "cboStateCd"
        Me.cboStateCd.Size = New System.Drawing.Size(145, 21)
        Me.cboStateCd.TabIndex = 4
        Me.cboStateCd.Tag = "@DB=Assessors.StateCd"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 41)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 125
        Me.Label5.Text = "Address"
        '
        'txtAddress
        '
        Me.txtAddress.AllowDrop = True
        Me.txtAddress.Location = New System.Drawing.Point(200, 36)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(428, 20)
        Me.txtAddress.TabIndex = 1
        Me.txtAddress.Tag = "@DB=Assessors.Address1"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 91)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 13)
        Me.Label4.TabIndex = 124
        Me.Label4.Text = "City, State  Zip"
        '
        'txtCity
        '
        Me.txtCity.AllowDrop = True
        Me.txtCity.Location = New System.Drawing.Point(200, 84)
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(204, 20)
        Me.txtCity.TabIndex = 3
        Me.txtCity.Tag = "@DB=Assessors.City"
        '
        'txtZip
        '
        Me.txtZip.AllowDrop = True
        Me.txtZip.Location = New System.Drawing.Point(556, 84)
        Me.txtZip.Name = "txtZip"
        Me.txtZip.Size = New System.Drawing.Size(71, 20)
        Me.txtZip.TabIndex = 5
        Me.txtZip.Tag = "@DB=Assessors.Zip"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 127
        Me.Label1.Text = "Name"
        '
        'txtName
        '
        Me.txtName.AllowDrop = True
        Me.txtName.Location = New System.Drawing.Point(200, 12)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(428, 20)
        Me.txtName.TabIndex = 0
        Me.txtName.Tag = "@DB=Assessors.Name"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(16, 204)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(38, 13)
        Me.Label8.TabIndex = 137
        Me.Label8.Text = "Phone"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(349, 203)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(24, 13)
        Me.Label7.TabIndex = 136
        Me.Label7.Text = "Fax"
        '
        'txtPhone
        '
        Me.txtPhone.AllowDrop = True
        Me.txtPhone.Location = New System.Drawing.Point(200, 200)
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Size = New System.Drawing.Size(123, 20)
        Me.txtPhone.TabIndex = 6
        Me.txtPhone.Tag = "@DB=Assessors.Phone"
        '
        'txtFax
        '
        Me.txtFax.AllowDrop = True
        Me.txtFax.Location = New System.Drawing.Point(379, 200)
        Me.txtFax.Name = "txtFax"
        Me.txtFax.Size = New System.Drawing.Size(123, 20)
        Me.txtFax.TabIndex = 7
        Me.txtFax.Tag = "@DB=Assessors.Fax"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(16, 318)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 19)
        Me.Label10.TabIndex = 142
        Me.Label10.Text = "BPP Ratio"
        '
        'txtPercentage
        '
        Me.txtPercentage.AllowDrop = True
        Me.txtPercentage.Location = New System.Drawing.Point(200, 314)
        Me.txtPercentage.Name = "txtPercentage"
        Me.txtPercentage.Size = New System.Drawing.Size(98, 20)
        Me.txtPercentage.TabIndex = 10
        Me.txtPercentage.Tag = "@DB=Assessors.BPPRatio;@fmt=factor"
        Me.txtPercentage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtPercentage.WordWrap = False
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(16, 344)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(96, 19)
        Me.Label12.TabIndex = 145
        Me.Label12.Text = "Real Estate Ratio"
        '
        'TextBox4
        '
        Me.TextBox4.AllowDrop = True
        Me.TextBox4.Location = New System.Drawing.Point(200, 340)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(98, 20)
        Me.TextBox4.TabIndex = 11
        Me.TextBox4.Tag = "@DB=Assessors.RERatio;@fmt=factor"
        Me.TextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TextBox4.WordWrap = False
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 370)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(109, 19)
        Me.Label2.TabIndex = 147
        Me.Label2.Text = "Rendition Due Date"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(16, 531)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(109, 19)
        Me.Label9.TabIndex = 149
        Me.Label9.Text = "Lien Date"
        '
        'TextBox2
        '
        Me.TextBox2.AllowDrop = True
        Me.TextBox2.Location = New System.Drawing.Point(200, 527)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(69, 20)
        Me.TextBox2.TabIndex = 17
        Me.TextBox2.Tag = "@DB=Assessors.LienDate;@fmt=DATE"
        '
        'TextBox5
        '
        Me.TextBox5.AllowDrop = True
        Me.TextBox5.Location = New System.Drawing.Point(200, 366)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(69, 20)
        Me.TextBox5.TabIndex = 12
        Me.TextBox5.Tag = "@DB=Assessors.RenditionDueDate;@fmt=DATE"
        '
        'cmdEnvelope
        '
        Me.cmdEnvelope.Location = New System.Drawing.Point(552, 168)
        Me.cmdEnvelope.Name = "cmdEnvelope"
        Me.cmdEnvelope.Size = New System.Drawing.Size(75, 23)
        Me.cmdEnvelope.TabIndex = 237
        Me.cmdEnvelope.Text = "Envelope"
        Me.cmdEnvelope.UseVisualStyleBackColor = True
        '
        'TextBox6
        '
        Me.TextBox6.AllowDrop = True
        Me.TextBox6.Location = New System.Drawing.Point(200, 423)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(69, 20)
        Me.TextBox6.TabIndex = 13
        Me.TextBox6.Tag = "@DB=Assessors.BPPNoticeDate;@fmt=DATE"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(16, 428)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(124, 19)
        Me.Label11.TabIndex = 239
        Me.Label11.Text = "BPP Notice Date"
        '
        'TextBox7
        '
        Me.TextBox7.AllowDrop = True
        Me.TextBox7.Location = New System.Drawing.Point(200, 475)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(69, 20)
        Me.TextBox7.TabIndex = 15
        Me.TextBox7.Tag = "@DB=Assessors.BPPProtestDeadlineDate;@fmt=DATE"
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(16, 480)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(150, 19)
        Me.Label13.TabIndex = 241
        Me.Label13.Text = "BPP Protest Deadline Date"
        '
        'TextBox8
        '
        Me.TextBox8.AllowDrop = True
        Me.TextBox8.Location = New System.Drawing.Point(200, 449)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(69, 20)
        Me.TextBox8.TabIndex = 14
        Me.TextBox8.Tag = "@DB=Assessors.RENoticeDate;@fmt=DATE"
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(16, 454)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(124, 19)
        Me.Label14.TabIndex = 244
        Me.Label14.Text = "Real Estate Notice Date"
        '
        'TextBox9
        '
        Me.TextBox9.AllowDrop = True
        Me.TextBox9.Location = New System.Drawing.Point(200, 501)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New System.Drawing.Size(69, 20)
        Me.TextBox9.TabIndex = 16
        Me.TextBox9.Tag = "@DB=Assessors.REProtestDeadlineDate;@fmt=DATE"
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(16, 506)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(180, 19)
        Me.Label15.TabIndex = 246
        Me.Label15.Text = "Real Estate Protest Deadline Date"
        '
        'cboValueProtestStateCd
        '
        Me.cboValueProtestStateCd.AllowDrop = True
        Me.cboValueProtestStateCd.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboValueProtestStateCd.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboValueProtestStateCd.FormattingEnabled = True
        Me.cboValueProtestStateCd.Location = New System.Drawing.Point(408, 140)
        Me.cboValueProtestStateCd.Name = "cboValueProtestStateCd"
        Me.cboValueProtestStateCd.Size = New System.Drawing.Size(145, 21)
        Me.cboValueProtestStateCd.TabIndex = 251
        Me.cboValueProtestStateCd.Tag = "@DB=Assessors.ValueProtestStateCd"
        Me.cboValueProtestStateCd.Visible = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(12, 120)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(138, 13)
        Me.Label16.TabIndex = 254
        Me.Label16.Text = "Value Protest Filing Address"
        Me.Label16.Visible = False
        '
        'txtValueProtestAddress
        '
        Me.txtValueProtestAddress.AllowDrop = True
        Me.txtValueProtestAddress.Location = New System.Drawing.Point(200, 116)
        Me.txtValueProtestAddress.Name = "txtValueProtestAddress"
        Me.txtValueProtestAddress.Size = New System.Drawing.Size(428, 20)
        Me.txtValueProtestAddress.TabIndex = 248
        Me.txtValueProtestAddress.Tag = "@DB=Assessors.ValueProtestAddress"
        Me.txtValueProtestAddress.Visible = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(12, 144)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(76, 13)
        Me.Label17.TabIndex = 253
        Me.Label17.Text = "City, State  Zip"
        Me.Label17.Visible = False
        '
        'txtValueProtestCity
        '
        Me.txtValueProtestCity.AllowDrop = True
        Me.txtValueProtestCity.Location = New System.Drawing.Point(200, 140)
        Me.txtValueProtestCity.Name = "txtValueProtestCity"
        Me.txtValueProtestCity.Size = New System.Drawing.Size(204, 20)
        Me.txtValueProtestCity.TabIndex = 250
        Me.txtValueProtestCity.Tag = "@DB=Assessors.ValueProtestCity"
        Me.txtValueProtestCity.Visible = False
        '
        'txtValueProtestZip
        '
        Me.txtValueProtestZip.AllowDrop = True
        Me.txtValueProtestZip.Location = New System.Drawing.Point(556, 140)
        Me.txtValueProtestZip.Name = "txtValueProtestZip"
        Me.txtValueProtestZip.Size = New System.Drawing.Size(71, 20)
        Me.txtValueProtestZip.TabIndex = 252
        Me.txtValueProtestZip.Tag = "@DB=Assessors.ValueProtestZip"
        Me.txtValueProtestZip.Visible = False
        '
        'txtRenditionExtDate
        '
        Me.txtRenditionExtDate.AllowDrop = True
        Me.txtRenditionExtDate.Location = New System.Drawing.Point(200, 396)
        Me.txtRenditionExtDate.Name = "txtRenditionExtDate"
        Me.txtRenditionExtDate.Size = New System.Drawing.Size(69, 20)
        Me.txtRenditionExtDate.TabIndex = 255
        Me.txtRenditionExtDate.Tag = "@DB=Assessors.RenditionExtDate;@fmt=DATE"
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(16, 400)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(164, 19)
        Me.Label18.TabIndex = 256
        Me.Label18.Text = "Rendition Extension Due Date"
        '
        'frmAssessor
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(642, 556)
        Me.Controls.Add(Me.txtRenditionExtDate)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.cboValueProtestStateCd)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtValueProtestAddress)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txtValueProtestCity)
        Me.Controls.Add(Me.txtValueProtestZip)
        Me.Controls.Add(Me.TextBox9)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.TextBox8)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.TextBox7)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.TextBox6)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.cmdEnvelope)
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtPercentage)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtPhone)
        Me.Controls.Add(Me.txtFax)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.txtComment)
        Me.Controls.Add(Me.cboStateCd)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtAddress)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtCity)
        Me.Controls.Add(Me.txtZip)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtName)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAssessor"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Assessor"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents txtComment As System.Windows.Forms.TextBox
    Friend WithEvents cboStateCd As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCity As System.Windows.Forms.TextBox
    Friend WithEvents txtZip As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtPhone As System.Windows.Forms.TextBox
    Friend WithEvents txtFax As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtPercentage As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents cmdEnvelope As System.Windows.Forms.Button
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TextBox9 As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cboValueProtestStateCd As ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txtValueProtestAddress As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents txtValueProtestCity As TextBox
    Friend WithEvents txtValueProtestZip As TextBox
    Friend WithEvents txtRenditionExtDate As TextBox
    Friend WithEvents Label18 As Label
End Class
