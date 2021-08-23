<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLocationRE
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
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtZip = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCity = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.cboStateCd = New System.Windows.Forms.ComboBox()
        Me.txtComment = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.chkInactiveFl = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboConsultant = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboSICCode = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(93, 15)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(432, 20)
        Me.txtName.TabIndex = 0
        Me.txtName.Tag = "@DB=LocationsRE.Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 111
        Me.Label1.Text = "Name"
        '
        'txtZip
        '
        Me.txtZip.Location = New System.Drawing.Point(454, 66)
        Me.txtZip.Name = "txtZip"
        Me.txtZip.Size = New System.Drawing.Size(71, 20)
        Me.txtZip.TabIndex = 4
        Me.txtZip.Tag = "@DB=LocationsRE.Zip"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 70)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "City, State  Zip"
        '
        'txtCity
        '
        Me.txtCity.Location = New System.Drawing.Point(93, 67)
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(204, 20)
        Me.txtCity.TabIndex = 2
        Me.txtCity.Tag = "@DB=LocationsRE.City"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 44)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Address"
        '
        'txtAddress
        '
        Me.txtAddress.Location = New System.Drawing.Point(93, 41)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(432, 20)
        Me.txtAddress.TabIndex = 1
        Me.txtAddress.Tag = "@DB=LocationsRE.Address"
        '
        'cboStateCd
        '
        Me.cboStateCd.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboStateCd.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboStateCd.FormattingEnabled = True
        Me.cboStateCd.Location = New System.Drawing.Point(303, 66)
        Me.cboStateCd.Name = "cboStateCd"
        Me.cboStateCd.Size = New System.Drawing.Size(145, 21)
        Me.cboStateCd.TabIndex = 3
        Me.cboStateCd.Tag = "@DB=LocationsRE.StateCd"
        '
        'txtComment
        '
        Me.txtComment.Location = New System.Drawing.Point(93, 206)
        Me.txtComment.Multiline = True
        Me.txtComment.Name = "txtComment"
        Me.txtComment.Size = New System.Drawing.Size(432, 56)
        Me.txtComment.TabIndex = 8
        Me.txtComment.Tag = "@DB=LocationsRE.Comment"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 95)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Legal Owner"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(12, 121)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 33)
        Me.Label2.TabIndex = 113
        Me.Label2.Text = "Legal Description"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(93, 92)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(432, 20)
        Me.TextBox1.TabIndex = 5
        Me.TextBox1.Tag = "@DB=LocationsRE.LegalOwner"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 183)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 115
        Me.Label3.Text = "Client ID"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(93, 118)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(432, 56)
        Me.TextBox2.TabIndex = 6
        Me.TextBox2.Tag = "@DB=LocationsRE.LegalDescription"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 209)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 13)
        Me.Label6.TabIndex = 117
        Me.Label6.Text = "Comments"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(93, 180)
        Me.TextBox3.Multiline = True
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(432, 20)
        Me.TextBox3.TabIndex = 7
        Me.TextBox3.Tag = "@DB=LocationsRE.ClientLocationId"
        '
        'chkInactiveFl
        '
        Me.chkInactiveFl.AutoSize = True
        Me.chkInactiveFl.Location = New System.Drawing.Point(8, 324)
        Me.chkInactiveFl.Name = "chkInactiveFl"
        Me.chkInactiveFl.Size = New System.Drawing.Size(64, 17)
        Me.chkInactiveFl.TabIndex = 10
        Me.chkInactiveFl.Tag = "@DB=LocationsRE.InactiveFl"
        Me.chkInactiveFl.Text = "Inactive"
        Me.chkInactiveFl.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 276)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 13)
        Me.Label8.TabIndex = 210
        Me.Label8.Text = "Consultant"
        '
        'cboConsultant
        '
        Me.cboConsultant.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboConsultant.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboConsultant.FormattingEnabled = True
        Me.cboConsultant.Location = New System.Drawing.Point(92, 272)
        Me.cboConsultant.Name = "cboConsultant"
        Me.cboConsultant.Size = New System.Drawing.Size(145, 21)
        Me.cboConsultant.TabIndex = 9
        Me.cboConsultant.Tag = "@DB=LocationsRE.ConsultantName"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(244, 276)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(52, 13)
        Me.Label9.TabIndex = 212
        Me.Label9.Text = "SIC Code"
        '
        'cboSICCode
        '
        Me.cboSICCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSICCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSICCode.FormattingEnabled = True
        Me.cboSICCode.Location = New System.Drawing.Point(300, 272)
        Me.cboSICCode.Name = "cboSICCode"
        Me.cboSICCode.Size = New System.Drawing.Size(224, 21)
        Me.cboSICCode.TabIndex = 211
        Me.cboSICCode.Tag = "@DB=LocationsRE.SICCode"
        '
        'frmLocationRE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(546, 347)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cboSICCode)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cboConsultant)
        Me.Controls.Add(Me.chkInactiveFl)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label7)
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
        Me.Name = "frmLocationRE"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Real Estate Location"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtZip As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCity As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents cboStateCd As System.Windows.Forms.ComboBox
    Friend WithEvents txtComment As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents chkInactiveFl As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboConsultant As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents cboSICCode As ComboBox
End Class
