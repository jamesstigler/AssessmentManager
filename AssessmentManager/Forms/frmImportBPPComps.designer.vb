<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportBPPComps
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
        Me.fraFile = New System.Windows.Forms.GroupBox()
        Me.chkFirstRow = New System.Windows.Forms.CheckBox()
        Me.cmdBrowse = New System.Windows.Forms.Button()
        Me.txtFile = New System.Windows.Forms.TextBox()
        Me.fraColumns = New System.Windows.Forms.GroupBox()
        Me.cboSoldFl = New System.Windows.Forms.ComboBox()
        Me.cboCompSourcePhone = New System.Windows.Forms.ComboBox()
        Me.cboCompSourceContact = New System.Windows.Forms.ComboBox()
        Me.cboCompSourceWebsite = New System.Windows.Forms.ComboBox()
        Me.cboCompSource = New System.Windows.Forms.ComboBox()
        Me.cboDiscontinuedFl = New System.Windows.Forms.ComboBox()
        Me.cboUsedFl = New System.Windows.Forms.ComboBox()
        Me.cboManufacturer = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cboSaleYear = New System.Windows.Forms.ComboBox()
        Me.dgFileContents = New System.Windows.Forms.DataGridView()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cboMachineHours = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cboSerialNumber = New System.Windows.Forms.ComboBox()
        Me.cboModel = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboManufactureYear = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboIndustry = New System.Windows.Forms.ComboBox()
        Me.cboAssetCategory = New System.Windows.Forms.ComboBox()
        Me.cboDescription = New System.Windows.Forms.ComboBox()
        Me.cboSalePrice = New System.Windows.Forms.ComboBox()
        Me.cboAssetType = New System.Windows.Forms.ComboBox()
        Me.cmdNext = New System.Windows.Forms.Button()
        Me.cmdFinish = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdBack = New System.Windows.Forms.Button()
        Me.fraResults = New System.Windows.Forms.GroupBox()
        Me.lblTotals = New System.Windows.Forms.Label()
        Me.cboDetails = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cboAuctionDate = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cboLotNumber = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.fraFile.SuspendLayout()
        Me.fraColumns.SuspendLayout()
        CType(Me.dgFileContents, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraResults.SuspendLayout()
        Me.SuspendLayout()
        '
        'fraFile
        '
        Me.fraFile.AutoSize = True
        Me.fraFile.Controls.Add(Me.chkFirstRow)
        Me.fraFile.Controls.Add(Me.cmdBrowse)
        Me.fraFile.Controls.Add(Me.txtFile)
        Me.fraFile.Location = New System.Drawing.Point(12, 8)
        Me.fraFile.Name = "fraFile"
        Me.fraFile.Size = New System.Drawing.Size(600, 104)
        Me.fraFile.TabIndex = 5
        Me.fraFile.TabStop = False
        '
        'chkFirstRow
        '
        Me.chkFirstRow.AutoSize = True
        Me.chkFirstRow.Location = New System.Drawing.Point(12, 68)
        Me.chkFirstRow.Name = "chkFirstRow"
        Me.chkFirstRow.Size = New System.Drawing.Size(149, 17)
        Me.chkFirstRow.TabIndex = 87
        Me.chkFirstRow.Text = "First row contains headers"
        Me.chkFirstRow.UseVisualStyleBackColor = True
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
        'txtFile
        '
        Me.txtFile.Location = New System.Drawing.Point(92, 40)
        Me.txtFile.Name = "txtFile"
        Me.txtFile.Size = New System.Drawing.Size(488, 20)
        Me.txtFile.TabIndex = 1
        '
        'fraColumns
        '
        Me.fraColumns.Controls.Add(Me.cboLotNumber)
        Me.fraColumns.Controls.Add(Me.Label19)
        Me.fraColumns.Controls.Add(Me.cboAuctionDate)
        Me.fraColumns.Controls.Add(Me.Label18)
        Me.fraColumns.Controls.Add(Me.cboDetails)
        Me.fraColumns.Controls.Add(Me.Label17)
        Me.fraColumns.Controls.Add(Me.cboSoldFl)
        Me.fraColumns.Controls.Add(Me.cboCompSourcePhone)
        Me.fraColumns.Controls.Add(Me.cboCompSourceContact)
        Me.fraColumns.Controls.Add(Me.cboCompSourceWebsite)
        Me.fraColumns.Controls.Add(Me.cboCompSource)
        Me.fraColumns.Controls.Add(Me.cboDiscontinuedFl)
        Me.fraColumns.Controls.Add(Me.cboUsedFl)
        Me.fraColumns.Controls.Add(Me.cboManufacturer)
        Me.fraColumns.Controls.Add(Me.Label20)
        Me.fraColumns.Controls.Add(Me.Label21)
        Me.fraColumns.Controls.Add(Me.Label4)
        Me.fraColumns.Controls.Add(Me.Label5)
        Me.fraColumns.Controls.Add(Me.Label6)
        Me.fraColumns.Controls.Add(Me.Label9)
        Me.fraColumns.Controls.Add(Me.Label16)
        Me.fraColumns.Controls.Add(Me.Label15)
        Me.fraColumns.Controls.Add(Me.cboSaleYear)
        Me.fraColumns.Controls.Add(Me.dgFileContents)
        Me.fraColumns.Controls.Add(Me.Label14)
        Me.fraColumns.Controls.Add(Me.cboMachineHours)
        Me.fraColumns.Controls.Add(Me.Label12)
        Me.fraColumns.Controls.Add(Me.Label13)
        Me.fraColumns.Controls.Add(Me.cboSerialNumber)
        Me.fraColumns.Controls.Add(Me.cboModel)
        Me.fraColumns.Controls.Add(Me.Label11)
        Me.fraColumns.Controls.Add(Me.Label10)
        Me.fraColumns.Controls.Add(Me.cboManufactureYear)
        Me.fraColumns.Controls.Add(Me.Label8)
        Me.fraColumns.Controls.Add(Me.Label7)
        Me.fraColumns.Controls.Add(Me.Label3)
        Me.fraColumns.Controls.Add(Me.Label2)
        Me.fraColumns.Controls.Add(Me.Label1)
        Me.fraColumns.Controls.Add(Me.cboIndustry)
        Me.fraColumns.Controls.Add(Me.cboAssetCategory)
        Me.fraColumns.Controls.Add(Me.cboDescription)
        Me.fraColumns.Controls.Add(Me.cboSalePrice)
        Me.fraColumns.Controls.Add(Me.cboAssetType)
        Me.fraColumns.Location = New System.Drawing.Point(12, 96)
        Me.fraColumns.Name = "fraColumns"
        Me.fraColumns.Size = New System.Drawing.Size(988, 264)
        Me.fraColumns.TabIndex = 23
        Me.fraColumns.TabStop = False
        Me.fraColumns.Visible = False
        '
        'cboSoldFl
        '
        Me.cboSoldFl.FormattingEnabled = True
        Me.cboSoldFl.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboSoldFl.Location = New System.Drawing.Point(8, 124)
        Me.cboSoldFl.Name = "cboSoldFl"
        Me.cboSoldFl.Size = New System.Drawing.Size(60, 21)
        Me.cboSoldFl.TabIndex = 14
        '
        'cboCompSourcePhone
        '
        Me.cboCompSourcePhone.FormattingEnabled = True
        Me.cboCompSourcePhone.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboCompSourcePhone.Location = New System.Drawing.Point(224, 124)
        Me.cboCompSourcePhone.Name = "cboCompSourcePhone"
        Me.cboCompSourcePhone.Size = New System.Drawing.Size(60, 21)
        Me.cboCompSourcePhone.TabIndex = 17
        '
        'cboCompSourceContact
        '
        Me.cboCompSourceContact.FormattingEnabled = True
        Me.cboCompSourceContact.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboCompSourceContact.Location = New System.Drawing.Point(296, 124)
        Me.cboCompSourceContact.Name = "cboCompSourceContact"
        Me.cboCompSourceContact.Size = New System.Drawing.Size(60, 21)
        Me.cboCompSourceContact.TabIndex = 18
        '
        'cboCompSourceWebsite
        '
        Me.cboCompSourceWebsite.FormattingEnabled = True
        Me.cboCompSourceWebsite.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboCompSourceWebsite.Location = New System.Drawing.Point(152, 124)
        Me.cboCompSourceWebsite.Name = "cboCompSourceWebsite"
        Me.cboCompSourceWebsite.Size = New System.Drawing.Size(60, 21)
        Me.cboCompSourceWebsite.TabIndex = 16
        '
        'cboCompSource
        '
        Me.cboCompSource.FormattingEnabled = True
        Me.cboCompSource.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboCompSource.Location = New System.Drawing.Point(80, 124)
        Me.cboCompSource.Name = "cboCompSource"
        Me.cboCompSource.Size = New System.Drawing.Size(60, 21)
        Me.cboCompSource.TabIndex = 15
        '
        'cboDiscontinuedFl
        '
        Me.cboDiscontinuedFl.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDiscontinuedFl.FormattingEnabled = True
        Me.cboDiscontinuedFl.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboDiscontinuedFl.Location = New System.Drawing.Point(368, 124)
        Me.cboDiscontinuedFl.Name = "cboDiscontinuedFl"
        Me.cboDiscontinuedFl.Size = New System.Drawing.Size(60, 21)
        Me.cboDiscontinuedFl.TabIndex = 19
        '
        'cboUsedFl
        '
        Me.cboUsedFl.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboUsedFl.FormattingEnabled = True
        Me.cboUsedFl.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboUsedFl.Location = New System.Drawing.Point(800, 56)
        Me.cboUsedFl.Name = "cboUsedFl"
        Me.cboUsedFl.Size = New System.Drawing.Size(60, 21)
        Me.cboUsedFl.TabIndex = 13
        '
        'cboManufacturer
        '
        Me.cboManufacturer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboManufacturer.FormattingEnabled = True
        Me.cboManufacturer.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboManufacturer.Location = New System.Drawing.Point(512, 56)
        Me.cboManufacturer.Name = "cboManufacturer"
        Me.cboManufacturer.Size = New System.Drawing.Size(60, 21)
        Me.cboManufacturer.TabIndex = 9
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(360, 88)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(76, 32)
        Me.Label20.TabIndex = 80
        Me.Label20.Text = "Discontinued"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(288, 88)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(77, 32)
        Me.Label21.TabIndex = 79
        Me.Label21.Text = "Source" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Contact"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(216, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 32)
        Me.Label4.TabIndex = 78
        Me.Label4.Text = "Source" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Phone"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(152, 88)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 32)
        Me.Label5.TabIndex = 77
        Me.Label5.Text = "Source" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Website"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(72, 88)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 32)
        Me.Label6.TabIndex = 76
        Me.Label6.Text = "Source"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(4, 88)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(68, 32)
        Me.Label9.TabIndex = 75
        Me.Label9.Text = "For Sale/" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Sold"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(796, 20)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(68, 32)
        Me.Label16.TabIndex = 74
        Me.Label16.Text = "New/Used"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(-8, 20)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(80, 32)
        Me.Label15.TabIndex = 73
        Me.Label15.Text = "Year Sold/" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "For Sale" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cboSaleYear
        '
        Me.cboSaleYear.FormattingEnabled = True
        Me.cboSaleYear.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboSaleYear.Location = New System.Drawing.Point(8, 56)
        Me.cboSaleYear.Name = "cboSaleYear"
        Me.cboSaleYear.Size = New System.Drawing.Size(60, 21)
        Me.cboSaleYear.TabIndex = 2
        '
        'dgFileContents
        '
        Me.dgFileContents.AllowDrop = True
        Me.dgFileContents.AllowUserToAddRows = False
        Me.dgFileContents.AllowUserToDeleteRows = False
        Me.dgFileContents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgFileContents.Location = New System.Drawing.Point(8, 212)
        Me.dgFileContents.Name = "dgFileContents"
        Me.dgFileContents.ReadOnly = True
        Me.dgFileContents.Size = New System.Drawing.Size(915, 39)
        Me.dgFileContents.TabIndex = 24
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(720, 20)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(80, 32)
        Me.Label14.TabIndex = 70
        Me.Label14.Text = "Engine/" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Machine Hours"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cboMachineHours
        '
        Me.cboMachineHours.FormattingEnabled = True
        Me.cboMachineHours.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboMachineHours.Location = New System.Drawing.Point(728, 56)
        Me.cboMachineHours.Name = "cboMachineHours"
        Me.cboMachineHours.Size = New System.Drawing.Size(60, 21)
        Me.cboMachineHours.TabIndex = 12
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(644, 20)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(80, 32)
        Me.Label12.TabIndex = 69
        Me.Label12.Text = "Serial Number/" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "VIN"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(584, 20)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(55, 32)
        Me.Label13.TabIndex = 68
        Me.Label13.Text = "Model"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cboSerialNumber
        '
        Me.cboSerialNumber.FormattingEnabled = True
        Me.cboSerialNumber.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboSerialNumber.Location = New System.Drawing.Point(656, 56)
        Me.cboSerialNumber.Name = "cboSerialNumber"
        Me.cboSerialNumber.Size = New System.Drawing.Size(60, 21)
        Me.cboSerialNumber.TabIndex = 11
        '
        'cboModel
        '
        Me.cboModel.FormattingEnabled = True
        Me.cboModel.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboModel.Location = New System.Drawing.Point(584, 56)
        Me.cboModel.Name = "cboModel"
        Me.cboModel.Size = New System.Drawing.Size(60, 21)
        Me.cboModel.TabIndex = 10
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(508, 20)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(70, 32)
        Me.Label11.TabIndex = 67
        Me.Label11.Text = "Manufacturer"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(436, 20)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(72, 32)
        Me.Label10.TabIndex = 66
        Me.Label10.Text = "Manufacture" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Year"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cboManufactureYear
        '
        Me.cboManufactureYear.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboManufactureYear.FormattingEnabled = True
        Me.cboManufactureYear.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboManufactureYear.Location = New System.Drawing.Point(440, 56)
        Me.cboManufactureYear.Name = "cboManufactureYear"
        Me.cboManufactureYear.Size = New System.Drawing.Size(60, 21)
        Me.cboManufactureYear.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(232, 20)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 32)
        Me.Label8.TabIndex = 64
        Me.Label8.Text = "Industry"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(288, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 32)
        Me.Label7.TabIndex = 63
        Me.Label7.Text = "Asset" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Category"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(144, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 32)
        Me.Label3.TabIndex = 58
        Me.Label3.Text = "Description"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(68, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 32)
        Me.Label2.TabIndex = 56
        Me.Label2.Text = "Price"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(376, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 32)
        Me.Label1.TabIndex = 54
        Me.Label1.Text = "Asset Type"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cboIndustry
        '
        Me.cboIndustry.FormattingEnabled = True
        Me.cboIndustry.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboIndustry.Location = New System.Drawing.Point(224, 56)
        Me.cboIndustry.Name = "cboIndustry"
        Me.cboIndustry.Size = New System.Drawing.Size(60, 21)
        Me.cboIndustry.TabIndex = 5
        '
        'cboAssetCategory
        '
        Me.cboAssetCategory.FormattingEnabled = True
        Me.cboAssetCategory.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboAssetCategory.Location = New System.Drawing.Point(296, 56)
        Me.cboAssetCategory.Name = "cboAssetCategory"
        Me.cboAssetCategory.Size = New System.Drawing.Size(60, 21)
        Me.cboAssetCategory.TabIndex = 6
        '
        'cboDescription
        '
        Me.cboDescription.FormattingEnabled = True
        Me.cboDescription.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboDescription.Location = New System.Drawing.Point(152, 56)
        Me.cboDescription.Name = "cboDescription"
        Me.cboDescription.Size = New System.Drawing.Size(60, 21)
        Me.cboDescription.TabIndex = 4
        '
        'cboSalePrice
        '
        Me.cboSalePrice.FormattingEnabled = True
        Me.cboSalePrice.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboSalePrice.Location = New System.Drawing.Point(80, 56)
        Me.cboSalePrice.Name = "cboSalePrice"
        Me.cboSalePrice.Size = New System.Drawing.Size(60, 21)
        Me.cboSalePrice.TabIndex = 3
        '
        'cboAssetType
        '
        Me.cboAssetType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAssetType.FormattingEnabled = True
        Me.cboAssetType.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboAssetType.Location = New System.Drawing.Point(368, 56)
        Me.cboAssetType.Name = "cboAssetType"
        Me.cboAssetType.Size = New System.Drawing.Size(60, 21)
        Me.cboAssetType.TabIndex = 7
        '
        'cmdNext
        '
        Me.cmdNext.Enabled = False
        Me.cmdNext.Location = New System.Drawing.Point(320, 472)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(75, 23)
        Me.cmdNext.TabIndex = 26
        Me.cmdNext.Text = "Next"
        Me.cmdNext.UseVisualStyleBackColor = True
        '
        'cmdFinish
        '
        Me.cmdFinish.Enabled = False
        Me.cmdFinish.Location = New System.Drawing.Point(401, 471)
        Me.cmdFinish.Name = "cmdFinish"
        Me.cmdFinish.Size = New System.Drawing.Size(75, 23)
        Me.cmdFinish.TabIndex = 27
        Me.cmdFinish.Text = "Finish"
        Me.cmdFinish.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(482, 471)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 28
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdBack
        '
        Me.cmdBack.Enabled = False
        Me.cmdBack.Location = New System.Drawing.Point(240, 472)
        Me.cmdBack.Name = "cmdBack"
        Me.cmdBack.Size = New System.Drawing.Size(75, 23)
        Me.cmdBack.TabIndex = 25
        Me.cmdBack.Text = "Back"
        Me.cmdBack.UseVisualStyleBackColor = True
        '
        'fraResults
        '
        Me.fraResults.Controls.Add(Me.lblTotals)
        Me.fraResults.Location = New System.Drawing.Point(12, 376)
        Me.fraResults.Name = "fraResults"
        Me.fraResults.Size = New System.Drawing.Size(579, 91)
        Me.fraResults.TabIndex = 24
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
        'cboDetails
        '
        Me.cboDetails.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDetails.FormattingEnabled = True
        Me.cboDetails.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboDetails.Location = New System.Drawing.Point(440, 124)
        Me.cboDetails.Name = "cboDetails"
        Me.cboDetails.Size = New System.Drawing.Size(60, 21)
        Me.cboDetails.TabIndex = 20
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(432, 88)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(76, 32)
        Me.Label17.TabIndex = 82
        Me.Label17.Text = "Details"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cboAuctionDate
        '
        Me.cboAuctionDate.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAuctionDate.FormattingEnabled = True
        Me.cboAuctionDate.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboAuctionDate.Location = New System.Drawing.Point(512, 124)
        Me.cboAuctionDate.Name = "cboAuctionDate"
        Me.cboAuctionDate.Size = New System.Drawing.Size(60, 21)
        Me.cboAuctionDate.TabIndex = 21
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(504, 88)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(76, 32)
        Me.Label18.TabIndex = 84
        Me.Label18.Text = "Auction Date"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cboLotNumber
        '
        Me.cboLotNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLotNumber.FormattingEnabled = True
        Me.cboLotNumber.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboLotNumber.Location = New System.Drawing.Point(584, 124)
        Me.cboLotNumber.Name = "cboLotNumber"
        Me.cboLotNumber.Size = New System.Drawing.Size(60, 21)
        Me.cboLotNumber.TabIndex = 22
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(576, 88)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(76, 32)
        Me.Label19.TabIndex = 86
        Me.Label19.Text = "Lot Number"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'frmImportBPPComps
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1058, 526)
        Me.Controls.Add(Me.fraColumns)
        Me.Controls.Add(Me.fraResults)
        Me.Controls.Add(Me.fraFile)
        Me.Controls.Add(Me.cmdBack)
        Me.Controls.Add(Me.cmdNext)
        Me.Controls.Add(Me.cmdFinish)
        Me.Controls.Add(Me.cmdCancel)
        Me.Name = "frmImportBPPComps"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Import BPP Comps"
        Me.fraFile.ResumeLayout(False)
        Me.fraFile.PerformLayout()
        Me.fraColumns.ResumeLayout(False)
        CType(Me.dgFileContents, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraResults.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents fraFile As System.Windows.Forms.GroupBox
    Friend WithEvents cmdNext As System.Windows.Forms.Button
    Friend WithEvents cmdFinish As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdBack As System.Windows.Forms.Button
    Friend WithEvents fraColumns As System.Windows.Forms.GroupBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cboMachineHours As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cboSerialNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cboModel As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboManufactureYear As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboIndustry As System.Windows.Forms.ComboBox
    Friend WithEvents cboAssetCategory As System.Windows.Forms.ComboBox
    Friend WithEvents cboDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cboSalePrice As System.Windows.Forms.ComboBox
    Friend WithEvents cboAssetType As System.Windows.Forms.ComboBox
    Friend WithEvents dgFileContents As System.Windows.Forms.DataGridView
    Friend WithEvents txtFile As System.Windows.Forms.TextBox
    Friend WithEvents cmdBrowse As System.Windows.Forms.Button
    Friend WithEvents fraResults As System.Windows.Forms.GroupBox
    Friend WithEvents lblTotals As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cboSaleYear As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cboSoldFl As System.Windows.Forms.ComboBox
    Friend WithEvents cboCompSourcePhone As System.Windows.Forms.ComboBox
    Friend WithEvents cboCompSourceContact As System.Windows.Forms.ComboBox
    Friend WithEvents cboCompSourceWebsite As System.Windows.Forms.ComboBox
    Friend WithEvents cboCompSource As System.Windows.Forms.ComboBox
    Friend WithEvents cboDiscontinuedFl As System.Windows.Forms.ComboBox
    Friend WithEvents cboUsedFl As System.Windows.Forms.ComboBox
    Friend WithEvents cboManufacturer As System.Windows.Forms.ComboBox
    Friend WithEvents chkFirstRow As System.Windows.Forms.CheckBox
    Friend WithEvents cboLotNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cboAuctionDate As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cboDetails As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
End Class
