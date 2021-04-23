<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmJurisdiction
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
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
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
        Me.cboStateCd = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCity = New System.Windows.Forms.TextBox()
        Me.txtZip = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.cboCollector = New System.Windows.Forms.ComboBox()
        Me.chkFreeport = New System.Windows.Forms.CheckBox()
        Me.cmdCollector = New System.Windows.Forms.Button()
        Me.chkLimitStates = New System.Windows.Forms.CheckBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtTaxDistrictCd = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(8, 282)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(109, 19)
        Me.Label9.TabIndex = 174
        Me.Label9.Text = "Collector"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 256)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(109, 19)
        Me.Label2.TabIndex = 173
        Me.Label2.Text = "Freeport"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(8, 229)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 19)
        Me.Label10.TabIndex = 171
        Me.Label10.Text = "Tax Rate"
        '
        'txtPercentage
        '
        Me.txtPercentage.Location = New System.Drawing.Point(100, 228)
        Me.txtPercentage.Name = "txtPercentage"
        Me.txtPercentage.Size = New System.Drawing.Size(98, 20)
        Me.txtPercentage.TabIndex = 10
        Me.txtPercentage.Tag = "@DB=Jurisdictions.TaxRate;@FMT=taxrate"
        Me.txtPercentage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtPercentage.WordWrap = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(8, 115)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(38, 13)
        Me.Label8.TabIndex = 170
        Me.Label8.Text = "Phone"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(242, 115)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(24, 13)
        Me.Label7.TabIndex = 169
        Me.Label7.Text = "Fax"
        '
        'txtPhone
        '
        Me.txtPhone.Location = New System.Drawing.Point(101, 112)
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Size = New System.Drawing.Size(123, 20)
        Me.txtPhone.TabIndex = 6
        Me.txtPhone.Tag = "@DB=Jurisdictions.Phone"
        '
        'txtFax
        '
        Me.txtFax.Location = New System.Drawing.Point(272, 112)
        Me.txtFax.Name = "txtFax"
        Me.txtFax.Size = New System.Drawing.Size(123, 20)
        Me.txtFax.TabIndex = 7
        Me.txtFax.Tag = "@DB=Jurisdictions.Fax"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 167)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 13)
        Me.Label6.TabIndex = 168
        Me.Label6.Text = "Comments"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(101, 138)
        Me.TextBox3.Multiline = True
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(469, 20)
        Me.TextBox3.TabIndex = 8
        Me.TextBox3.Tag = "@DB=Jurisdictions.WebSite"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 141)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 167
        Me.Label3.Text = "Web Site"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(101, 61)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(469, 20)
        Me.TextBox1.TabIndex = 2
        Me.TextBox1.Tag = "@DB=Jurisdictions.Address2"
        '
        'txtComment
        '
        Me.txtComment.Location = New System.Drawing.Point(101, 164)
        Me.txtComment.Multiline = True
        Me.txtComment.Name = "txtComment"
        Me.txtComment.Size = New System.Drawing.Size(469, 56)
        Me.txtComment.TabIndex = 9
        Me.txtComment.Tag = "@DB=Jurisdictions.Comment"
        '
        'cboStateCd
        '
        Me.cboStateCd.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboStateCd.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboStateCd.FormattingEnabled = True
        Me.cboStateCd.Location = New System.Drawing.Point(348, 85)
        Me.cboStateCd.Name = "cboStateCd"
        Me.cboStateCd.Size = New System.Drawing.Size(145, 21)
        Me.cboStateCd.TabIndex = 4
        Me.cboStateCd.Tag = "@DB=Jurisdictions.StateCd"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 165
        Me.Label5.Text = "Address"
        '
        'txtAddress
        '
        Me.txtAddress.Location = New System.Drawing.Point(101, 35)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(469, 20)
        Me.txtAddress.TabIndex = 1
        Me.txtAddress.Tag = "@DB=Jurisdictions.Address1"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 13)
        Me.Label4.TabIndex = 164
        Me.Label4.Text = "City, State  Zip"
        '
        'txtCity
        '
        Me.txtCity.Location = New System.Drawing.Point(101, 86)
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(241, 20)
        Me.txtCity.TabIndex = 3
        Me.txtCity.Tag = "@DB=Jurisdictions.City"
        '
        'txtZip
        '
        Me.txtZip.Location = New System.Drawing.Point(499, 85)
        Me.txtZip.Name = "txtZip"
        Me.txtZip.Size = New System.Drawing.Size(71, 20)
        Me.txtZip.TabIndex = 5
        Me.txtZip.Tag = "@DB=Jurisdictions.Zip"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 166
        Me.Label1.Text = "Name"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(101, 9)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(469, 20)
        Me.txtName.TabIndex = 0
        Me.txtName.Tag = "@DB=Jurisdictions.Name"
        '
        'cboCollector
        '
        Me.cboCollector.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCollector.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCollector.FormattingEnabled = True
        Me.cboCollector.Location = New System.Drawing.Point(101, 279)
        Me.cboCollector.Name = "cboCollector"
        Me.cboCollector.Size = New System.Drawing.Size(303, 21)
        Me.cboCollector.TabIndex = 13
        Me.cboCollector.Tag = "@DB=Jurisdictions.CollectorId"
        '
        'chkFreeport
        '
        Me.chkFreeport.AutoSize = True
        Me.chkFreeport.Location = New System.Drawing.Point(101, 256)
        Me.chkFreeport.Name = "chkFreeport"
        Me.chkFreeport.Size = New System.Drawing.Size(15, 14)
        Me.chkFreeport.TabIndex = 12
        Me.chkFreeport.Tag = "@DB=Jurisdictions.FreeportFl"
        Me.chkFreeport.UseVisualStyleBackColor = True
        '
        'cmdCollector
        '
        Me.cmdCollector.Location = New System.Drawing.Point(410, 279)
        Me.cmdCollector.Name = "cmdCollector"
        Me.cmdCollector.Size = New System.Drawing.Size(26, 20)
        Me.cmdCollector.TabIndex = 14
        Me.cmdCollector.Text = "..."
        Me.cmdCollector.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdCollector.UseVisualStyleBackColor = True
        '
        'chkLimitStates
        '
        Me.chkLimitStates.AutoSize = True
        Me.chkLimitStates.Checked = True
        Me.chkLimitStates.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkLimitStates.Location = New System.Drawing.Point(442, 281)
        Me.chkLimitStates.Name = "chkLimitStates"
        Me.chkLimitStates.Size = New System.Drawing.Size(128, 17)
        Me.chkLimitStates.TabIndex = 15
        Me.chkLimitStates.Tag = ""
        Me.chkLimitStates.Text = "Limit list to same state"
        Me.chkLimitStates.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(208, 232)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(67, 13)
        Me.Label11.TabIndex = 178
        Me.Label11.Text = "District Code"
        '
        'txtTaxDistrictCd
        '
        Me.txtTaxDistrictCd.Location = New System.Drawing.Point(280, 228)
        Me.txtTaxDistrictCd.Name = "txtTaxDistrictCd"
        Me.txtTaxDistrictCd.Size = New System.Drawing.Size(120, 20)
        Me.txtTaxDistrictCd.TabIndex = 11
        Me.txtTaxDistrictCd.Tag = "@DB=Jurisdictions.TaxDistrictCd"
        '
        'frmJurisdiction
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(576, 305)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtTaxDistrictCd)
        Me.Controls.Add(Me.chkLimitStates)
        Me.Controls.Add(Me.cmdCollector)
        Me.Controls.Add(Me.chkFreeport)
        Me.Controls.Add(Me.cboCollector)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label2)
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
        Me.Name = "frmJurisdiction"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Jurisdiction"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
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
    Friend WithEvents cboStateCd As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCity As System.Windows.Forms.TextBox
    Friend WithEvents txtZip As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents cboCollector As System.Windows.Forms.ComboBox
    Friend WithEvents chkFreeport As System.Windows.Forms.CheckBox
    Friend WithEvents cmdCollector As System.Windows.Forms.Button
    Friend WithEvents chkLimitStates As System.Windows.Forms.CheckBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtTaxDistrictCd As TextBox
End Class
