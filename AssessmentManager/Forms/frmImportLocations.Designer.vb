<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmImportLocations
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
        Me.cmdFinish = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboLegalOwner = New System.Windows.Forms.ComboBox()
        Me.cboLegalDescription = New System.Windows.Forms.ComboBox()
        Me.cboZip = New System.Windows.Forms.ComboBox()
        Me.cboStateCd = New System.Windows.Forms.ComboBox()
        Me.cboCity = New System.Windows.Forms.ComboBox()
        Me.cboAddress = New System.Windows.Forms.ComboBox()
        Me.cboName = New System.Windows.Forms.ComboBox()
        Me.dgImport = New System.Windows.Forms.DataGridView()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboClientLocationID = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cboAcctNum = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboAssessor = New System.Windows.Forms.ComboBox()
        Me.fraFile = New System.Windows.Forms.GroupBox()
        Me.cmdBrowse = New System.Windows.Forms.Button()
        Me.txtFile = New System.Windows.Forms.TextBox()
        Me.fraColumns = New System.Windows.Forms.GroupBox()
        Me.cmdBack = New System.Windows.Forms.Button()
        CType(Me.dgImport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraFile.SuspendLayout()
        Me.fraColumns.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdFinish
        '
        Me.cmdFinish.Enabled = False
        Me.cmdFinish.Location = New System.Drawing.Point(384, 656)
        Me.cmdFinish.Name = "cmdFinish"
        Me.cmdFinish.Size = New System.Drawing.Size(75, 23)
        Me.cmdFinish.TabIndex = 41
        Me.cmdFinish.Text = "Finish"
        Me.cmdFinish.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(184, 84)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 13)
        Me.Label7.TabIndex = 39
        Me.Label7.Text = "Legal Owner"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(160, 56)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 13)
        Me.Label6.TabIndex = 38
        Me.Label6.Text = "Legal Description"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(228, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(22, 13)
        Me.Label5.TabIndex = 37
        Me.Label5.Text = "Zip"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(40, 112)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 13)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "State"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(48, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 13)
        Me.Label3.TabIndex = 35
        Me.Label3.Text = "City"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(24, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Address"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(36, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Name"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cboLegalOwner
        '
        Me.cboLegalOwner.FormattingEnabled = True
        Me.cboLegalOwner.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboLegalOwner.Location = New System.Drawing.Point(256, 80)
        Me.cboLegalOwner.Name = "cboLegalOwner"
        Me.cboLegalOwner.Size = New System.Drawing.Size(60, 21)
        Me.cboLegalOwner.TabIndex = 31
        '
        'cboLegalDescription
        '
        Me.cboLegalDescription.FormattingEnabled = True
        Me.cboLegalDescription.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboLegalDescription.Location = New System.Drawing.Point(256, 52)
        Me.cboLegalDescription.Name = "cboLegalDescription"
        Me.cboLegalDescription.Size = New System.Drawing.Size(60, 21)
        Me.cboLegalDescription.TabIndex = 30
        '
        'cboZip
        '
        Me.cboZip.FormattingEnabled = True
        Me.cboZip.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboZip.Location = New System.Drawing.Point(256, 24)
        Me.cboZip.Name = "cboZip"
        Me.cboZip.Size = New System.Drawing.Size(60, 21)
        Me.cboZip.TabIndex = 29
        '
        'cboStateCd
        '
        Me.cboStateCd.FormattingEnabled = True
        Me.cboStateCd.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboStateCd.Location = New System.Drawing.Point(76, 108)
        Me.cboStateCd.Name = "cboStateCd"
        Me.cboStateCd.Size = New System.Drawing.Size(60, 21)
        Me.cboStateCd.TabIndex = 28
        '
        'cboCity
        '
        Me.cboCity.FormattingEnabled = True
        Me.cboCity.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboCity.Location = New System.Drawing.Point(76, 80)
        Me.cboCity.Name = "cboCity"
        Me.cboCity.Size = New System.Drawing.Size(60, 21)
        Me.cboCity.TabIndex = 27
        '
        'cboAddress
        '
        Me.cboAddress.FormattingEnabled = True
        Me.cboAddress.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboAddress.Location = New System.Drawing.Point(76, 52)
        Me.cboAddress.Name = "cboAddress"
        Me.cboAddress.Size = New System.Drawing.Size(60, 21)
        Me.cboAddress.TabIndex = 26
        '
        'cboName
        '
        Me.cboName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboName.FormattingEnabled = True
        Me.cboName.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboName.Location = New System.Drawing.Point(76, 24)
        Me.cboName.Name = "cboName"
        Me.cboName.Size = New System.Drawing.Size(60, 21)
        Me.cboName.TabIndex = 25
        '
        'dgImport
        '
        Me.dgImport.AllowUserToAddRows = False
        Me.dgImport.AllowUserToDeleteRows = False
        Me.dgImport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgImport.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgImport.Location = New System.Drawing.Point(3, 144)
        Me.dgImport.Name = "dgImport"
        Me.dgImport.ReadOnly = True
        Me.dgImport.Size = New System.Drawing.Size(1014, 477)
        Me.dgImport.TabIndex = 24
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(464, 656)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 23
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(160, 112)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(91, 13)
        Me.Label9.TabIndex = 44
        Me.Label9.Text = "Client Location ID"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cboClientLocationID
        '
        Me.cboClientLocationID.FormattingEnabled = True
        Me.cboClientLocationID.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboClientLocationID.Location = New System.Drawing.Point(256, 108)
        Me.cboClientLocationID.Name = "cboClientLocationID"
        Me.cboClientLocationID.Size = New System.Drawing.Size(60, 21)
        Me.cboClientLocationID.TabIndex = 43
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(344, 28)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(87, 13)
        Me.Label11.TabIndex = 65
        Me.Label11.Text = "Account Number"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cboAcctNum
        '
        Me.cboAcctNum.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAcctNum.FormattingEnabled = True
        Me.cboAcctNum.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboAcctNum.Location = New System.Drawing.Point(436, 24)
        Me.cboAcctNum.Name = "cboAcctNum"
        Me.cboAcctNum.Size = New System.Drawing.Size(60, 21)
        Me.cboAcctNum.TabIndex = 63
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(380, 56)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 13)
        Me.Label10.TabIndex = 66
        Me.Label10.Text = "Assessor"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cboAssessor
        '
        Me.cboAssessor.FormattingEnabled = True
        Me.cboAssessor.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboAssessor.Location = New System.Drawing.Point(436, 52)
        Me.cboAssessor.Name = "cboAssessor"
        Me.cboAssessor.Size = New System.Drawing.Size(60, 21)
        Me.cboAssessor.TabIndex = 64
        '
        'fraFile
        '
        Me.fraFile.AutoSize = True
        Me.fraFile.Controls.Add(Me.cmdBrowse)
        Me.fraFile.Controls.Add(Me.txtFile)
        Me.fraFile.Location = New System.Drawing.Point(16, 16)
        Me.fraFile.Name = "fraFile"
        Me.fraFile.Size = New System.Drawing.Size(1020, 62)
        Me.fraFile.TabIndex = 67
        Me.fraFile.TabStop = False
        '
        'cmdBrowse
        '
        Me.cmdBrowse.Location = New System.Drawing.Point(7, 20)
        Me.cmdBrowse.Name = "cmdBrowse"
        Me.cmdBrowse.Size = New System.Drawing.Size(75, 23)
        Me.cmdBrowse.TabIndex = 9
        Me.cmdBrowse.Text = "Browse"
        Me.cmdBrowse.UseVisualStyleBackColor = True
        '
        'txtFile
        '
        Me.txtFile.Location = New System.Drawing.Point(88, 20)
        Me.txtFile.Name = "txtFile"
        Me.txtFile.Size = New System.Drawing.Size(636, 20)
        Me.txtFile.TabIndex = 8
        '
        'fraColumns
        '
        Me.fraColumns.Controls.Add(Me.cboName)
        Me.fraColumns.Controls.Add(Me.dgImport)
        Me.fraColumns.Controls.Add(Me.Label10)
        Me.fraColumns.Controls.Add(Me.cboAddress)
        Me.fraColumns.Controls.Add(Me.Label11)
        Me.fraColumns.Controls.Add(Me.cboCity)
        Me.fraColumns.Controls.Add(Me.cboAssessor)
        Me.fraColumns.Controls.Add(Me.cboStateCd)
        Me.fraColumns.Controls.Add(Me.cboAcctNum)
        Me.fraColumns.Controls.Add(Me.cboZip)
        Me.fraColumns.Controls.Add(Me.Label9)
        Me.fraColumns.Controls.Add(Me.cboLegalDescription)
        Me.fraColumns.Controls.Add(Me.cboClientLocationID)
        Me.fraColumns.Controls.Add(Me.cboLegalOwner)
        Me.fraColumns.Controls.Add(Me.Label1)
        Me.fraColumns.Controls.Add(Me.Label2)
        Me.fraColumns.Controls.Add(Me.Label7)
        Me.fraColumns.Controls.Add(Me.Label3)
        Me.fraColumns.Controls.Add(Me.Label6)
        Me.fraColumns.Controls.Add(Me.Label4)
        Me.fraColumns.Controls.Add(Me.Label5)
        Me.fraColumns.Location = New System.Drawing.Point(16, 16)
        Me.fraColumns.Name = "fraColumns"
        Me.fraColumns.Size = New System.Drawing.Size(1020, 624)
        Me.fraColumns.TabIndex = 10
        Me.fraColumns.TabStop = False
        Me.fraColumns.Visible = False
        '
        'cmdBack
        '
        Me.cmdBack.Enabled = False
        Me.cmdBack.Location = New System.Drawing.Point(304, 656)
        Me.cmdBack.Name = "cmdBack"
        Me.cmdBack.Size = New System.Drawing.Size(75, 23)
        Me.cmdBack.TabIndex = 68
        Me.cmdBack.Text = "Back"
        Me.cmdBack.UseVisualStyleBackColor = True
        '
        'frmImportLocations
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1052, 694)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdBack)
        Me.Controls.Add(Me.cmdFinish)
        Me.Controls.Add(Me.fraColumns)
        Me.Controls.Add(Me.fraFile)
        Me.Name = "frmImportLocations"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmImportLocations"
        CType(Me.dgImport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraFile.ResumeLayout(False)
        Me.fraFile.PerformLayout()
        Me.fraColumns.ResumeLayout(False)
        Me.fraColumns.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdFinish As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboLegalOwner As System.Windows.Forms.ComboBox
    Friend WithEvents cboLegalDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cboZip As System.Windows.Forms.ComboBox
    Friend WithEvents cboStateCd As System.Windows.Forms.ComboBox
    Friend WithEvents cboCity As System.Windows.Forms.ComboBox
    Friend WithEvents cboAddress As System.Windows.Forms.ComboBox
    Friend WithEvents cboName As System.Windows.Forms.ComboBox
    Friend WithEvents dgImport As System.Windows.Forms.DataGridView
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboClientLocationID As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents cboAcctNum As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents cboAssessor As ComboBox
    Friend WithEvents fraFile As GroupBox
    Friend WithEvents cmdBrowse As Button
    Friend WithEvents txtFile As TextBox
    Friend WithEvents fraColumns As GroupBox
    Friend WithEvents cmdBack As Button
End Class
