<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportREComps
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
        Me.cmdNext = New System.Windows.Forms.Button()
        Me.cmdFinish = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdBack = New System.Windows.Forms.Button()
        Me.fraColumns = New System.Windows.Forms.GroupBox()
        Me.cboStreetNumber = New System.Windows.Forms.ComboBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.cboPricingMethod = New System.Windows.Forms.ComboBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.cboAppraisalMethod = New System.Windows.Forms.ComboBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.cboEffectiveYear = New System.Windows.Forms.ComboBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.cboConstructionType = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.cboLandBldgRatio = New System.Windows.Forms.ComboBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.cboStreet = New System.Windows.Forms.ComboBox()
        Me.cboBuildingClass = New System.Windows.Forms.ComboBox()
        Me.cboBusinessName = New System.Windows.Forms.ComboBox()
        Me.cboNeighborhoodGroup = New System.Windows.Forms.ComboBox()
        Me.cboLandMarketArea = New System.Windows.Forms.ComboBox()
        Me.cboImprovementMarketArea = New System.Windows.Forms.ComboBox()
        Me.cboEconomicArea = New System.Windows.Forms.ComboBox()
        Me.cboCompCode = New System.Windows.Forms.ComboBox()
        Me.cboMapsco = New System.Windows.Forms.ComboBox()
        Me.cboYearBuilt = New System.Windows.Forms.ComboBox()
        Me.cboTotalValueUnit = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cboAccount = New System.Windows.Forms.ComboBox()
        Me.dgFileContents = New System.Windows.Forms.DataGridView()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cboNumberOfUnits = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cboLandSqFt = New System.Windows.Forms.ComboBox()
        Me.cboBuildingSqFt = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboTotalValueSqFt = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboLandValue = New System.Windows.Forms.ComboBox()
        Me.cboLandValueSqFt = New System.Windows.Forms.ComboBox()
        Me.cboImprovementValueSqFt = New System.Windows.Forms.ComboBox()
        Me.cboImprovementValue = New System.Windows.Forms.ComboBox()
        Me.cboTotalValue = New System.Windows.Forms.ComboBox()
        Me.fraResults = New System.Windows.Forms.GroupBox()
        Me.lblTotals = New System.Windows.Forms.Label()
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
        Me.fraFile.Size = New System.Drawing.Size(600, 108)
        Me.fraFile.TabIndex = 0
        Me.fraFile.TabStop = False
        '
        'chkFirstRow
        '
        Me.chkFirstRow.AutoSize = True
        Me.chkFirstRow.Location = New System.Drawing.Point(12, 72)
        Me.chkFirstRow.Name = "chkFirstRow"
        Me.chkFirstRow.Size = New System.Drawing.Size(149, 17)
        Me.chkFirstRow.TabIndex = 2
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
        'cmdNext
        '
        Me.cmdNext.Enabled = False
        Me.cmdNext.Location = New System.Drawing.Point(320, 472)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(75, 23)
        Me.cmdNext.TabIndex = 3
        Me.cmdNext.Text = "Next"
        Me.cmdNext.UseVisualStyleBackColor = True
        '
        'cmdFinish
        '
        Me.cmdFinish.Enabled = False
        Me.cmdFinish.Location = New System.Drawing.Point(401, 471)
        Me.cmdFinish.Name = "cmdFinish"
        Me.cmdFinish.Size = New System.Drawing.Size(75, 23)
        Me.cmdFinish.TabIndex = 4
        Me.cmdFinish.Text = "Finish"
        Me.cmdFinish.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(482, 471)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 5
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdBack
        '
        Me.cmdBack.Enabled = False
        Me.cmdBack.Location = New System.Drawing.Point(240, 472)
        Me.cmdBack.Name = "cmdBack"
        Me.cmdBack.Size = New System.Drawing.Size(75, 23)
        Me.cmdBack.TabIndex = 2
        Me.cmdBack.Text = "Back"
        Me.cmdBack.UseVisualStyleBackColor = True
        '
        'fraColumns
        '
        Me.fraColumns.Controls.Add(Me.cboStreetNumber)
        Me.fraColumns.Controls.Add(Me.Label27)
        Me.fraColumns.Controls.Add(Me.cboPricingMethod)
        Me.fraColumns.Controls.Add(Me.Label26)
        Me.fraColumns.Controls.Add(Me.cboAppraisalMethod)
        Me.fraColumns.Controls.Add(Me.Label25)
        Me.fraColumns.Controls.Add(Me.cboEffectiveYear)
        Me.fraColumns.Controls.Add(Me.Label24)
        Me.fraColumns.Controls.Add(Me.cboConstructionType)
        Me.fraColumns.Controls.Add(Me.Label23)
        Me.fraColumns.Controls.Add(Me.cboLandBldgRatio)
        Me.fraColumns.Controls.Add(Me.Label22)
        Me.fraColumns.Controls.Add(Me.cboStreet)
        Me.fraColumns.Controls.Add(Me.cboBuildingClass)
        Me.fraColumns.Controls.Add(Me.cboBusinessName)
        Me.fraColumns.Controls.Add(Me.cboNeighborhoodGroup)
        Me.fraColumns.Controls.Add(Me.cboLandMarketArea)
        Me.fraColumns.Controls.Add(Me.cboImprovementMarketArea)
        Me.fraColumns.Controls.Add(Me.cboEconomicArea)
        Me.fraColumns.Controls.Add(Me.cboCompCode)
        Me.fraColumns.Controls.Add(Me.cboMapsco)
        Me.fraColumns.Controls.Add(Me.cboYearBuilt)
        Me.fraColumns.Controls.Add(Me.cboTotalValueUnit)
        Me.fraColumns.Controls.Add(Me.Label17)
        Me.fraColumns.Controls.Add(Me.Label18)
        Me.fraColumns.Controls.Add(Me.Label19)
        Me.fraColumns.Controls.Add(Me.Label20)
        Me.fraColumns.Controls.Add(Me.Label21)
        Me.fraColumns.Controls.Add(Me.Label4)
        Me.fraColumns.Controls.Add(Me.Label5)
        Me.fraColumns.Controls.Add(Me.Label6)
        Me.fraColumns.Controls.Add(Me.Label9)
        Me.fraColumns.Controls.Add(Me.Label16)
        Me.fraColumns.Controls.Add(Me.Label15)
        Me.fraColumns.Controls.Add(Me.cboAccount)
        Me.fraColumns.Controls.Add(Me.dgFileContents)
        Me.fraColumns.Controls.Add(Me.Label14)
        Me.fraColumns.Controls.Add(Me.cboNumberOfUnits)
        Me.fraColumns.Controls.Add(Me.Label12)
        Me.fraColumns.Controls.Add(Me.Label13)
        Me.fraColumns.Controls.Add(Me.cboLandSqFt)
        Me.fraColumns.Controls.Add(Me.cboBuildingSqFt)
        Me.fraColumns.Controls.Add(Me.Label11)
        Me.fraColumns.Controls.Add(Me.Label10)
        Me.fraColumns.Controls.Add(Me.cboTotalValueSqFt)
        Me.fraColumns.Controls.Add(Me.Label8)
        Me.fraColumns.Controls.Add(Me.Label7)
        Me.fraColumns.Controls.Add(Me.Label3)
        Me.fraColumns.Controls.Add(Me.Label2)
        Me.fraColumns.Controls.Add(Me.Label1)
        Me.fraColumns.Controls.Add(Me.cboLandValue)
        Me.fraColumns.Controls.Add(Me.cboLandValueSqFt)
        Me.fraColumns.Controls.Add(Me.cboImprovementValueSqFt)
        Me.fraColumns.Controls.Add(Me.cboImprovementValue)
        Me.fraColumns.Controls.Add(Me.cboTotalValue)
        Me.fraColumns.Location = New System.Drawing.Point(12, 96)
        Me.fraColumns.Name = "fraColumns"
        Me.fraColumns.Size = New System.Drawing.Size(988, 264)
        Me.fraColumns.TabIndex = 1
        Me.fraColumns.TabStop = False
        Me.fraColumns.Visible = False
        '
        'cboStreetNumber
        '
        Me.cboStreetNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboStreetNumber.FormattingEnabled = True
        Me.cboStreetNumber.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboStreetNumber.Location = New System.Drawing.Point(440, 124)
        Me.cboStreetNumber.Name = "cboStreetNumber"
        Me.cboStreetNumber.Size = New System.Drawing.Size(60, 21)
        Me.cboStreetNumber.TabIndex = 22
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(440, 88)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(60, 32)
        Me.Label27.TabIndex = 95
        Me.Label27.Text = "Steet Number"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cboPricingMethod
        '
        Me.cboPricingMethod.FormattingEnabled = True
        Me.cboPricingMethod.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboPricingMethod.Location = New System.Drawing.Point(872, 124)
        Me.cboPricingMethod.Name = "cboPricingMethod"
        Me.cboPricingMethod.Size = New System.Drawing.Size(60, 21)
        Me.cboPricingMethod.TabIndex = 28
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(868, 88)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(68, 32)
        Me.Label26.TabIndex = 93
        Me.Label26.Text = "Pricing Method"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cboAppraisalMethod
        '
        Me.cboAppraisalMethod.FormattingEnabled = True
        Me.cboAppraisalMethod.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboAppraisalMethod.Location = New System.Drawing.Point(800, 124)
        Me.cboAppraisalMethod.Name = "cboAppraisalMethod"
        Me.cboAppraisalMethod.Size = New System.Drawing.Size(60, 21)
        Me.cboAppraisalMethod.TabIndex = 27
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(796, 88)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(68, 32)
        Me.Label25.TabIndex = 91
        Me.Label25.Text = "Appraisal Method"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cboEffectiveYear
        '
        Me.cboEffectiveYear.FormattingEnabled = True
        Me.cboEffectiveYear.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboEffectiveYear.Location = New System.Drawing.Point(728, 124)
        Me.cboEffectiveYear.Name = "cboEffectiveYear"
        Me.cboEffectiveYear.Size = New System.Drawing.Size(60, 21)
        Me.cboEffectiveYear.TabIndex = 26
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(724, 88)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(68, 32)
        Me.Label24.TabIndex = 89
        Me.Label24.Text = "Effective Year"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cboConstructionType
        '
        Me.cboConstructionType.FormattingEnabled = True
        Me.cboConstructionType.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboConstructionType.Location = New System.Drawing.Point(656, 124)
        Me.cboConstructionType.Name = "cboConstructionType"
        Me.cboConstructionType.Size = New System.Drawing.Size(60, 21)
        Me.cboConstructionType.TabIndex = 25
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(652, 88)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(68, 32)
        Me.Label23.TabIndex = 87
        Me.Label23.Text = "Construction Type"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cboLandBldgRatio
        '
        Me.cboLandBldgRatio.FormattingEnabled = True
        Me.cboLandBldgRatio.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboLandBldgRatio.Location = New System.Drawing.Point(824, 176)
        Me.cboLandBldgRatio.Name = "cboLandBldgRatio"
        Me.cboLandBldgRatio.Size = New System.Drawing.Size(60, 21)
        Me.cboLandBldgRatio.TabIndex = 119
        Me.cboLandBldgRatio.TabStop = False
        Me.cboLandBldgRatio.Visible = False
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(820, 140)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(68, 32)
        Me.Label22.TabIndex = 85
        Me.Label22.Text = "Land/Bldg Ratio"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Label22.Visible = False
        '
        'cboStreet
        '
        Me.cboStreet.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboStreet.FormattingEnabled = True
        Me.cboStreet.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboStreet.Location = New System.Drawing.Point(512, 124)
        Me.cboStreet.Name = "cboStreet"
        Me.cboStreet.Size = New System.Drawing.Size(60, 21)
        Me.cboStreet.TabIndex = 23
        '
        'cboBuildingClass
        '
        Me.cboBuildingClass.FormattingEnabled = True
        Me.cboBuildingClass.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboBuildingClass.Location = New System.Drawing.Point(8, 124)
        Me.cboBuildingClass.Name = "cboBuildingClass"
        Me.cboBuildingClass.Size = New System.Drawing.Size(60, 21)
        Me.cboBuildingClass.TabIndex = 16
        '
        'cboBusinessName
        '
        Me.cboBusinessName.FormattingEnabled = True
        Me.cboBusinessName.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboBusinessName.Location = New System.Drawing.Point(584, 124)
        Me.cboBusinessName.Name = "cboBusinessName"
        Me.cboBusinessName.Size = New System.Drawing.Size(60, 21)
        Me.cboBusinessName.TabIndex = 24
        '
        'cboNeighborhoodGroup
        '
        Me.cboNeighborhoodGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboNeighborhoodGroup.FormattingEnabled = True
        Me.cboNeighborhoodGroup.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboNeighborhoodGroup.Location = New System.Drawing.Point(908, 176)
        Me.cboNeighborhoodGroup.Name = "cboNeighborhoodGroup"
        Me.cboNeighborhoodGroup.Size = New System.Drawing.Size(60, 21)
        Me.cboNeighborhoodGroup.TabIndex = 120
        Me.cboNeighborhoodGroup.TabStop = False
        Me.cboNeighborhoodGroup.Visible = False
        '
        'cboLandMarketArea
        '
        Me.cboLandMarketArea.FormattingEnabled = True
        Me.cboLandMarketArea.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboLandMarketArea.Location = New System.Drawing.Point(224, 124)
        Me.cboLandMarketArea.Name = "cboLandMarketArea"
        Me.cboLandMarketArea.Size = New System.Drawing.Size(60, 21)
        Me.cboLandMarketArea.TabIndex = 19
        '
        'cboImprovementMarketArea
        '
        Me.cboImprovementMarketArea.FormattingEnabled = True
        Me.cboImprovementMarketArea.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboImprovementMarketArea.Location = New System.Drawing.Point(296, 124)
        Me.cboImprovementMarketArea.Name = "cboImprovementMarketArea"
        Me.cboImprovementMarketArea.Size = New System.Drawing.Size(60, 21)
        Me.cboImprovementMarketArea.TabIndex = 20
        '
        'cboEconomicArea
        '
        Me.cboEconomicArea.FormattingEnabled = True
        Me.cboEconomicArea.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboEconomicArea.Location = New System.Drawing.Point(152, 124)
        Me.cboEconomicArea.Name = "cboEconomicArea"
        Me.cboEconomicArea.Size = New System.Drawing.Size(60, 21)
        Me.cboEconomicArea.TabIndex = 18
        '
        'cboCompCode
        '
        Me.cboCompCode.FormattingEnabled = True
        Me.cboCompCode.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboCompCode.Location = New System.Drawing.Point(80, 124)
        Me.cboCompCode.Name = "cboCompCode"
        Me.cboCompCode.Size = New System.Drawing.Size(60, 21)
        Me.cboCompCode.TabIndex = 17
        '
        'cboMapsco
        '
        Me.cboMapsco.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboMapsco.FormattingEnabled = True
        Me.cboMapsco.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboMapsco.Location = New System.Drawing.Point(368, 124)
        Me.cboMapsco.Name = "cboMapsco"
        Me.cboMapsco.Size = New System.Drawing.Size(60, 21)
        Me.cboMapsco.TabIndex = 21
        '
        'cboYearBuilt
        '
        Me.cboYearBuilt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboYearBuilt.FormattingEnabled = True
        Me.cboYearBuilt.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboYearBuilt.Location = New System.Drawing.Point(800, 56)
        Me.cboYearBuilt.Name = "cboYearBuilt"
        Me.cboYearBuilt.Size = New System.Drawing.Size(60, 21)
        Me.cboYearBuilt.TabIndex = 15
        '
        'cboTotalValueUnit
        '
        Me.cboTotalValueUnit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboTotalValueUnit.FormattingEnabled = True
        Me.cboTotalValueUnit.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboTotalValueUnit.Location = New System.Drawing.Point(512, 56)
        Me.cboTotalValueUnit.Name = "cboTotalValueUnit"
        Me.cboTotalValueUnit.Size = New System.Drawing.Size(60, 21)
        Me.cboTotalValueUnit.TabIndex = 11
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(580, 88)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(68, 32)
        Me.Label17.TabIndex = 83
        Me.Label17.Text = "Business Name"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(520, 88)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(39, 32)
        Me.Label18.TabIndex = 82
        Me.Label18.Text = "Steet Name"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(896, 140)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(84, 32)
        Me.Label19.TabIndex = 81
        Me.Label19.Text = "Neighborhood Group"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Label19.Visible = False
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(368, 88)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(55, 32)
        Me.Label20.TabIndex = 80
        Me.Label20.Text = "Mapsco"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(288, 88)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(77, 32)
        Me.Label21.TabIndex = 79
        Me.Label21.Text = "Improvement Market Area"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(216, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 32)
        Me.Label4.TabIndex = 78
        Me.Label4.Text = "Land Market Area"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(152, 88)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 32)
        Me.Label5.TabIndex = 77
        Me.Label5.Text = "Economic Area"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(72, 88)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 32)
        Me.Label6.TabIndex = 76
        Me.Label6.Text = "Comparability Code"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(12, 88)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(52, 32)
        Me.Label9.TabIndex = 75
        Me.Label9.Text = "Building Class"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(808, 20)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(40, 32)
        Me.Label16.TabIndex = 74
        Me.Label16.Text = "Year Built"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(12, 20)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(52, 32)
        Me.Label15.TabIndex = 11
        Me.Label15.Text = "Account"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cboAccount
        '
        Me.cboAccount.FormattingEnabled = True
        Me.cboAccount.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboAccount.Location = New System.Drawing.Point(8, 56)
        Me.cboAccount.Name = "cboAccount"
        Me.cboAccount.Size = New System.Drawing.Size(60, 21)
        Me.cboAccount.TabIndex = 4
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
        Me.dgFileContents.TabIndex = 30
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(732, 20)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(50, 32)
        Me.Label14.TabIndex = 70
        Me.Label14.Text = "Number of Units"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cboNumberOfUnits
        '
        Me.cboNumberOfUnits.FormattingEnabled = True
        Me.cboNumberOfUnits.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboNumberOfUnits.Location = New System.Drawing.Point(728, 56)
        Me.cboNumberOfUnits.Name = "cboNumberOfUnits"
        Me.cboNumberOfUnits.Size = New System.Drawing.Size(60, 21)
        Me.cboNumberOfUnits.TabIndex = 14
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(664, 20)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(44, 32)
        Me.Label12.TabIndex = 69
        Me.Label12.Text = "Land Sq Ft"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(584, 20)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(55, 32)
        Me.Label13.TabIndex = 68
        Me.Label13.Text = "Building Sq Ft"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cboLandSqFt
        '
        Me.cboLandSqFt.FormattingEnabled = True
        Me.cboLandSqFt.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboLandSqFt.Location = New System.Drawing.Point(656, 56)
        Me.cboLandSqFt.Name = "cboLandSqFt"
        Me.cboLandSqFt.Size = New System.Drawing.Size(60, 21)
        Me.cboLandSqFt.TabIndex = 13
        '
        'cboBuildingSqFt
        '
        Me.cboBuildingSqFt.FormattingEnabled = True
        Me.cboBuildingSqFt.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboBuildingSqFt.Location = New System.Drawing.Point(584, 56)
        Me.cboBuildingSqFt.Name = "cboBuildingSqFt"
        Me.cboBuildingSqFt.Size = New System.Drawing.Size(60, 21)
        Me.cboBuildingSqFt.TabIndex = 12
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(508, 20)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(70, 32)
        Me.Label11.TabIndex = 67
        Me.Label11.Text = "Total Value/Unit"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(436, 20)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(72, 32)
        Me.Label10.TabIndex = 66
        Me.Label10.Text = "Total Value/Sq Ft"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cboTotalValueSqFt
        '
        Me.cboTotalValueSqFt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboTotalValueSqFt.FormattingEnabled = True
        Me.cboTotalValueSqFt.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboTotalValueSqFt.Location = New System.Drawing.Point(440, 56)
        Me.cboTotalValueSqFt.Name = "cboTotalValueSqFt"
        Me.cboTotalValueSqFt.Size = New System.Drawing.Size(60, 21)
        Me.cboTotalValueSqFt.TabIndex = 10
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(232, 20)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 32)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Land Value"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(288, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 32)
        Me.Label7.TabIndex = 63
        Me.Label7.Text = "Land Value/Sq Ft"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(144, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 32)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Improvement Value/Sq Ft"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(68, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 32)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Improvement Value"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(376, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 32)
        Me.Label1.TabIndex = 54
        Me.Label1.Text = "Total Value"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cboLandValue
        '
        Me.cboLandValue.FormattingEnabled = True
        Me.cboLandValue.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboLandValue.Location = New System.Drawing.Point(224, 56)
        Me.cboLandValue.Name = "cboLandValue"
        Me.cboLandValue.Size = New System.Drawing.Size(60, 21)
        Me.cboLandValue.TabIndex = 7
        '
        'cboLandValueSqFt
        '
        Me.cboLandValueSqFt.FormattingEnabled = True
        Me.cboLandValueSqFt.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboLandValueSqFt.Location = New System.Drawing.Point(296, 56)
        Me.cboLandValueSqFt.Name = "cboLandValueSqFt"
        Me.cboLandValueSqFt.Size = New System.Drawing.Size(60, 21)
        Me.cboLandValueSqFt.TabIndex = 8
        '
        'cboImprovementValueSqFt
        '
        Me.cboImprovementValueSqFt.FormattingEnabled = True
        Me.cboImprovementValueSqFt.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboImprovementValueSqFt.Location = New System.Drawing.Point(152, 56)
        Me.cboImprovementValueSqFt.Name = "cboImprovementValueSqFt"
        Me.cboImprovementValueSqFt.Size = New System.Drawing.Size(60, 21)
        Me.cboImprovementValueSqFt.TabIndex = 6
        '
        'cboImprovementValue
        '
        Me.cboImprovementValue.FormattingEnabled = True
        Me.cboImprovementValue.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboImprovementValue.Location = New System.Drawing.Point(80, 56)
        Me.cboImprovementValue.Name = "cboImprovementValue"
        Me.cboImprovementValue.Size = New System.Drawing.Size(60, 21)
        Me.cboImprovementValue.TabIndex = 5
        '
        'cboTotalValue
        '
        Me.cboTotalValue.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboTotalValue.FormattingEnabled = True
        Me.cboTotalValue.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboTotalValue.Location = New System.Drawing.Point(368, 56)
        Me.cboTotalValue.Name = "cboTotalValue"
        Me.cboTotalValue.Size = New System.Drawing.Size(60, 21)
        Me.cboTotalValue.TabIndex = 9
        '
        'fraResults
        '
        Me.fraResults.Controls.Add(Me.lblTotals)
        Me.fraResults.Location = New System.Drawing.Point(12, 376)
        Me.fraResults.Name = "fraResults"
        Me.fraResults.Size = New System.Drawing.Size(579, 91)
        Me.fraResults.TabIndex = 5
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
        'frmImportREComps
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1058, 526)
        Me.Controls.Add(Me.fraResults)
        Me.Controls.Add(Me.fraFile)
        Me.Controls.Add(Me.cmdBack)
        Me.Controls.Add(Me.cmdNext)
        Me.Controls.Add(Me.cmdFinish)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.fraColumns)
        Me.Name = "frmImportREComps"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Import RE Comps"
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
    Friend WithEvents cboNumberOfUnits As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cboLandSqFt As System.Windows.Forms.ComboBox
    Friend WithEvents cboBuildingSqFt As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboTotalValueSqFt As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboLandValue As System.Windows.Forms.ComboBox
    Friend WithEvents cboLandValueSqFt As System.Windows.Forms.ComboBox
    Friend WithEvents cboImprovementValueSqFt As System.Windows.Forms.ComboBox
    Friend WithEvents cboImprovementValue As System.Windows.Forms.ComboBox
    Friend WithEvents cboTotalValue As System.Windows.Forms.ComboBox
    Friend WithEvents dgFileContents As System.Windows.Forms.DataGridView
    Friend WithEvents txtFile As System.Windows.Forms.TextBox
    Friend WithEvents cmdBrowse As System.Windows.Forms.Button
    Friend WithEvents fraResults As System.Windows.Forms.GroupBox
    Friend WithEvents lblTotals As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cboAccount As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cboStreet As System.Windows.Forms.ComboBox
    Friend WithEvents cboBuildingClass As System.Windows.Forms.ComboBox
    Friend WithEvents cboBusinessName As System.Windows.Forms.ComboBox
    Friend WithEvents cboNeighborhoodGroup As System.Windows.Forms.ComboBox
    Friend WithEvents cboLandMarketArea As System.Windows.Forms.ComboBox
    Friend WithEvents cboImprovementMarketArea As System.Windows.Forms.ComboBox
    Friend WithEvents cboEconomicArea As System.Windows.Forms.ComboBox
    Friend WithEvents cboCompCode As System.Windows.Forms.ComboBox
    Friend WithEvents cboMapsco As System.Windows.Forms.ComboBox
    Friend WithEvents cboYearBuilt As System.Windows.Forms.ComboBox
    Friend WithEvents cboTotalValueUnit As System.Windows.Forms.ComboBox
    Friend WithEvents cboLandBldgRatio As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents chkFirstRow As System.Windows.Forms.CheckBox
    Friend WithEvents cboPricingMethod As ComboBox
    Friend WithEvents Label26 As Label
    Friend WithEvents cboAppraisalMethod As ComboBox
    Friend WithEvents Label25 As Label
    Friend WithEvents cboEffectiveYear As ComboBox
    Friend WithEvents Label24 As Label
    Friend WithEvents cboConstructionType As ComboBox
    Friend WithEvents Label23 As Label
    Friend WithEvents cboStreetNumber As ComboBox
    Friend WithEvents Label27 As Label
End Class
