<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCollector
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
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtPercentage = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtPhone = New System.Windows.Forms.TextBox()
        Me.txtFax = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.txtComment = New System.Windows.Forms.TextBox()
        Me.cboPayeeStateCd = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCity = New System.Windows.Forms.TextBox()
        Me.txtZip = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.chkAddressCorrectFl = New System.Windows.Forms.CheckBox()
        Me.chkDiscountFl = New System.Windows.Forms.CheckBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.TextBox9 = New System.Windows.Forms.TextBox()
        Me.TextBox10 = New System.Windows.Forms.TextBox()
        Me.TextBox11 = New System.Windows.Forms.TextBox()
        Me.TextBox12 = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TextBox15 = New System.Windows.Forms.TextBox()
        Me.TextBox14 = New System.Windows.Forms.TextBox()
        Me.TextBox13 = New System.Windows.Forms.TextBox()
        Me.cboStateCd = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(8, 279)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(124, 19)
        Me.Label10.TabIndex = 195
        Me.Label10.Text = "Warning Days"
        '
        'txtPercentage
        '
        Me.txtPercentage.Location = New System.Drawing.Point(138, 276)
        Me.txtPercentage.Name = "txtPercentage"
        Me.txtPercentage.Size = New System.Drawing.Size(45, 20)
        Me.txtPercentage.TabIndex = 12
        Me.txtPercentage.Tag = "@DB=Collectors.NumDaysWarning;@FMT=int"
        Me.txtPercentage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtPercentage.WordWrap = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(8, 165)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(38, 13)
        Me.Label8.TabIndex = 194
        Me.Label8.Text = "Phone"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(287, 165)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(24, 13)
        Me.Label7.TabIndex = 193
        Me.Label7.Text = "Fax"
        '
        'txtPhone
        '
        Me.txtPhone.Location = New System.Drawing.Point(138, 162)
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Size = New System.Drawing.Size(123, 20)
        Me.txtPhone.TabIndex = 8
        Me.txtPhone.Tag = "@DB=Collectors.Phone"
        '
        'txtFax
        '
        Me.txtFax.Location = New System.Drawing.Point(317, 162)
        Me.txtFax.Name = "txtFax"
        Me.txtFax.Size = New System.Drawing.Size(123, 20)
        Me.txtFax.TabIndex = 9
        Me.txtFax.Tag = "@DB=Collectors.Fax"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 217)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 13)
        Me.Label6.TabIndex = 192
        Me.Label6.Text = "Comments"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(138, 188)
        Me.TextBox3.Multiline = True
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(432, 20)
        Me.TextBox3.TabIndex = 10
        Me.TextBox3.Tag = "@DB=Collectors.WebSite"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 191)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 191
        Me.Label3.Text = "Web Site"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(138, 88)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(432, 20)
        Me.TextBox1.TabIndex = 3
        Me.TextBox1.Tag = "@DB=Collectors.Address2"
        '
        'txtComment
        '
        Me.txtComment.Location = New System.Drawing.Point(138, 214)
        Me.txtComment.Multiline = True
        Me.txtComment.Name = "txtComment"
        Me.txtComment.Size = New System.Drawing.Size(432, 56)
        Me.txtComment.TabIndex = 11
        Me.txtComment.Tag = "@DB=Collectors.Comment"
        '
        'cboPayeeStateCd
        '
        Me.cboPayeeStateCd.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPayeeStateCd.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPayeeStateCd.FormattingEnabled = True
        Me.cboPayeeStateCd.Location = New System.Drawing.Point(348, 114)
        Me.cboPayeeStateCd.Name = "cboPayeeStateCd"
        Me.cboPayeeStateCd.Size = New System.Drawing.Size(145, 21)
        Me.cboPayeeStateCd.TabIndex = 5
        Me.cboPayeeStateCd.Tag = "@DB=Collectors.PayeeStateCd"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 67)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 189
        Me.Label5.Text = "Address"
        '
        'txtAddress
        '
        Me.txtAddress.Location = New System.Drawing.Point(138, 64)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(432, 20)
        Me.txtAddress.TabIndex = 2
        Me.txtAddress.Tag = "@DB=Collectors.Address1"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 118)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 13)
        Me.Label4.TabIndex = 188
        Me.Label4.Text = "City, State  Zip"
        '
        'txtCity
        '
        Me.txtCity.Location = New System.Drawing.Point(138, 115)
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(204, 20)
        Me.txtCity.TabIndex = 4
        Me.txtCity.Tag = "@DB=Collectors.City"
        '
        'txtZip
        '
        Me.txtZip.Location = New System.Drawing.Point(499, 115)
        Me.txtZip.Name = "txtZip"
        Me.txtZip.Size = New System.Drawing.Size(71, 20)
        Me.txtZip.TabIndex = 6
        Me.txtZip.Tag = "@DB=Collectors.Zip"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 190
        Me.Label1.Text = "Name"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(138, 12)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(432, 20)
        Me.txtName.TabIndex = 0
        Me.txtName.Tag = "@DB=Collectors.Name"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(8, 41)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(37, 13)
        Me.Label11.TabIndex = 199
        Me.Label11.Text = "Payee"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(138, 38)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(432, 20)
        Me.TextBox2.TabIndex = 1
        Me.TextBox2.Tag = "@DB=Collectors.Payee"
        '
        'TextBox5
        '
        Me.TextBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox5.Location = New System.Drawing.Point(6, 61)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(69, 20)
        Me.TextBox5.TabIndex = 18
        Me.TextBox5.Tag = "@DB=Collectors.DiscountDate;@fmt=DATE"
        '
        'TextBox4
        '
        Me.TextBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox4.Location = New System.Drawing.Point(24, 20)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(69, 20)
        Me.TextBox4.TabIndex = 13
        Me.TextBox4.Tag = "@DB=Collectors.BPPDueDate1;@fmt=DATE"
        '
        'chkAddressCorrectFl
        '
        Me.chkAddressCorrectFl.AutoSize = True
        Me.chkAddressCorrectFl.Location = New System.Drawing.Point(138, 141)
        Me.chkAddressCorrectFl.Name = "chkAddressCorrectFl"
        Me.chkAddressCorrectFl.Size = New System.Drawing.Size(101, 17)
        Me.chkAddressCorrectFl.TabIndex = 7
        Me.chkAddressCorrectFl.Tag = "@DB=Collectors.AddressCorrectFl"
        Me.chkAddressCorrectFl.Text = "Address verified"
        Me.chkAddressCorrectFl.UseVisualStyleBackColor = True
        '
        'chkDiscountFl
        '
        Me.chkDiscountFl.AutoSize = True
        Me.chkDiscountFl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDiscountFl.Location = New System.Drawing.Point(6, 19)
        Me.chkDiscountFl.Name = "chkDiscountFl"
        Me.chkDiscountFl.Size = New System.Drawing.Size(113, 17)
        Me.chkDiscountFl.TabIndex = 17
        Me.chkDiscountFl.Tag = "@DB=Collectors.DiscountFl"
        Me.chkDiscountFl.Text = "Discount available"
        Me.chkDiscountFl.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(97, 39)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(77, 19)
        Me.Label12.TabIndex = 200
        Me.Label12.Text = "Percentage"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(6, 39)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(69, 19)
        Me.Label13.TabIndex = 201
        Me.Label13.Text = "Date"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBox6
        '
        Me.TextBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox6.Location = New System.Drawing.Point(99, 61)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(74, 20)
        Me.TextBox6.TabIndex = 19
        Me.TextBox6.Tag = "@DB=Collectors.DiscountPct;@FMT=pct"
        Me.TextBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TextBox6.WordWrap = False
        '
        'TextBox7
        '
        Me.TextBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox7.Location = New System.Drawing.Point(99, 87)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(74, 20)
        Me.TextBox7.TabIndex = 21
        Me.TextBox7.Tag = "@DB=Collectors.DiscountPct2;@FMT=pct"
        Me.TextBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TextBox7.WordWrap = False
        '
        'TextBox8
        '
        Me.TextBox8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox8.Location = New System.Drawing.Point(6, 87)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(69, 20)
        Me.TextBox8.TabIndex = 20
        Me.TextBox8.Tag = "@DB=Collectors.DiscountDate2;@fmt=DATE"
        '
        'TextBox9
        '
        Me.TextBox9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox9.Location = New System.Drawing.Point(99, 113)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New System.Drawing.Size(74, 20)
        Me.TextBox9.TabIndex = 23
        Me.TextBox9.Tag = "@DB=Collectors.DiscountPct3;@FMT=pct"
        Me.TextBox9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TextBox9.WordWrap = False
        '
        'TextBox10
        '
        Me.TextBox10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox10.Location = New System.Drawing.Point(6, 113)
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Size = New System.Drawing.Size(69, 20)
        Me.TextBox10.TabIndex = 22
        Me.TextBox10.Tag = "@DB=Collectors.DiscountDate3;@fmt=DATE"
        '
        'TextBox11
        '
        Me.TextBox11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox11.Location = New System.Drawing.Point(99, 139)
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.Size = New System.Drawing.Size(74, 20)
        Me.TextBox11.TabIndex = 25
        Me.TextBox11.Tag = "@DB=Collectors.DiscountPct4;@FMT=pct"
        Me.TextBox11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TextBox11.WordWrap = False
        '
        'TextBox12
        '
        Me.TextBox12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox12.Location = New System.Drawing.Point(6, 139)
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.Size = New System.Drawing.Size(69, 20)
        Me.TextBox12.TabIndex = 24
        Me.TextBox12.Tag = "@DB=Collectors.DiscountDate4;@fmt=DATE"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkDiscountFl)
        Me.GroupBox1.Controls.Add(Me.TextBox11)
        Me.GroupBox1.Controls.Add(Me.TextBox12)
        Me.GroupBox1.Controls.Add(Me.TextBox5)
        Me.GroupBox1.Controls.Add(Me.TextBox9)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.TextBox10)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.TextBox7)
        Me.GroupBox1.Controls.Add(Me.TextBox6)
        Me.GroupBox1.Controls.Add(Me.TextBox8)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(168, 300)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(184, 165)
        Me.GroupBox1.TabIndex = 202
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Discounts"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.TextBox15)
        Me.GroupBox2.Controls.Add(Me.TextBox14)
        Me.GroupBox2.Controls.Add(Me.TextBox13)
        Me.GroupBox2.Controls.Add(Me.TextBox4)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(11, 302)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(117, 142)
        Me.GroupBox2.TabIndex = 203
        Me.GroupBox2.TabStop = False
        '
        'TextBox15
        '
        Me.TextBox15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox15.Location = New System.Drawing.Point(24, 112)
        Me.TextBox15.Name = "TextBox15"
        Me.TextBox15.Size = New System.Drawing.Size(69, 20)
        Me.TextBox15.TabIndex = 16
        Me.TextBox15.Tag = "@DB=Collectors.REDueDate2;@fmt=DATE"
        '
        'TextBox14
        '
        Me.TextBox14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox14.Location = New System.Drawing.Point(24, 88)
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.Size = New System.Drawing.Size(69, 20)
        Me.TextBox14.TabIndex = 15
        Me.TextBox14.Tag = "@DB=Collectors.REDueDate1;@fmt=DATE"
        '
        'TextBox13
        '
        Me.TextBox13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox13.Location = New System.Drawing.Point(24, 44)
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.Size = New System.Drawing.Size(69, 20)
        Me.TextBox13.TabIndex = 14
        Me.TextBox13.Tag = "@DB=Collectors.BPPDueDate2;@fmt=DATE"
        '
        'cboStateCd
        '
        Me.cboStateCd.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboStateCd.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboStateCd.FormattingEnabled = True
        Me.cboStateCd.Location = New System.Drawing.Point(576, 11)
        Me.cboStateCd.Name = "cboStateCd"
        Me.cboStateCd.Size = New System.Drawing.Size(145, 21)
        Me.cboStateCd.TabIndex = 1
        Me.cboStateCd.Tag = "@DB=Collectors.StateCd"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 13)
        Me.Label2.TabIndex = 193
        Me.Label2.Text = "BPP Due Dates"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(16, 72)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 13)
        Me.Label9.TabIndex = 194
        Me.Label9.Text = "RE Due Dates"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmCollector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(805, 508)
        Me.Controls.Add(Me.cboStateCd)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.chkAddressCorrectFl)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TextBox2)
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
        Me.Controls.Add(Me.cboPayeeStateCd)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtAddress)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtCity)
        Me.Controls.Add(Me.txtZip)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtName)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCollector"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Collector"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtPercentage As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtPhone As System.Windows.Forms.TextBox
    Friend WithEvents txtFax As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents txtComment As System.Windows.Forms.TextBox
    Friend WithEvents cboPayeeStateCd As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCity As System.Windows.Forms.TextBox
    Friend WithEvents txtZip As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents chkAddressCorrectFl As System.Windows.Forms.CheckBox
    Friend WithEvents chkDiscountFl As System.Windows.Forms.CheckBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox9 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox10 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox11 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox12 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox15 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox14 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox13 As System.Windows.Forms.TextBox
    Friend WithEvents cboStateCd As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label2 As Label
End Class
