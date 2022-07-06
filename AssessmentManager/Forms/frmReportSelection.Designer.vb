<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmReportSelection
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
        Me.radioDepreciationDetail = New System.Windows.Forms.RadioButton()
        Me.cmdRun = New System.Windows.Forms.Button()
        Me.radioRenditionForm = New System.Windows.Forms.RadioButton()
        Me.radioFreeportForm = New System.Windows.Forms.RadioButton()
        Me.radioDepreciationSummary = New System.Windows.Forms.RadioButton()
        Me.chkShowCost = New System.Windows.Forms.CheckBox()
        Me.chkPrint = New System.Windows.Forms.CheckBox()
        Me.radioValueProtestForm = New System.Windows.Forms.RadioButton()
        Me.radioDepreciationDetailCost = New System.Windows.Forms.RadioButton()
        Me.radioDepreciationDetailExempt = New System.Windows.Forms.RadioButton()
        Me.radioDepreciationDetailNon = New System.Windows.Forms.RadioButton()
        Me.radioTaxBill = New System.Windows.Forms.RadioButton()
        Me.radioTaxBillCheckOff = New System.Windows.Forms.RadioButton()
        Me.radioAppointmentOfAgentForm = New System.Windows.Forms.RadioButton()
        Me.chkExport = New System.Windows.Forms.CheckBox()
        Me.txtFolder = New System.Windows.Forms.TextBox()
        Me.cmdBrowse = New System.Windows.Forms.Button()
        Me.radioRenditionExtensionForm = New System.Windows.Forms.RadioButton()
        Me.radioRenditionDueDate = New System.Windows.Forms.RadioButton()
        Me.radioMissingTaxBills = New System.Windows.Forms.RadioButton()
        Me.radioMissingNotice = New System.Windows.Forms.RadioButton()
        Me.radioCertificateOfMailing = New System.Windows.Forms.RadioButton()
        Me.radioClientLocationListing = New System.Windows.Forms.RadioButton()
        Me.radioFixedAssetRecon = New System.Windows.Forms.RadioButton()
        Me.radioTaxAccrual = New System.Windows.Forms.RadioButton()
        Me.radioTaxSavings = New System.Windows.Forms.RadioButton()
        Me.cboFactoringEntity = New System.Windows.Forms.ComboBox()
        Me.radioAssessorCover = New System.Windows.Forms.RadioButton()
        Me.radioClientEnvelope = New System.Windows.Forms.RadioButton()
        Me.cboContactType = New System.Windows.Forms.ComboBox()
        Me.radioBarCode = New System.Windows.Forms.RadioButton()
        Me.cboBarCode = New System.Windows.Forms.ComboBox()
        Me.chkCover = New System.Windows.Forms.CheckBox()
        Me.grpBatchRendition = New System.Windows.Forms.GroupBox()
        Me.chkIncludeZeroBatch = New System.Windows.Forms.CheckBox()
        Me.chkShowCostBatch = New System.Windows.Forms.CheckBox()
        Me.chkBatchRenditionCert = New System.Windows.Forms.CheckBox()
        Me.chkBatchRenditionAssessor = New System.Windows.Forms.CheckBox()
        Me.chkBatchRenditionRendition = New System.Windows.Forms.CheckBox()
        Me.chkBatchRenditionAssetSummary = New System.Windows.Forms.CheckBox()
        Me.chkBatchRenditionAssetDetail = New System.Windows.Forms.CheckBox()
        Me.chkBatchRenditionBarCode = New System.Windows.Forms.CheckBox()
        Me.grpBatchValue = New System.Windows.Forms.GroupBox()
        Me.chkBatchValueProtestCert = New System.Windows.Forms.CheckBox()
        Me.chkBatchValueProtestAssessor = New System.Windows.Forms.CheckBox()
        Me.chkBatchValueProtestProtest = New System.Windows.Forms.CheckBox()
        Me.chkBatchValueProtestBarCode = New System.Windows.Forms.CheckBox()
        Me.grpBatchTaxBill = New System.Windows.Forms.GroupBox()
        Me.CheckBox14 = New System.Windows.Forms.CheckBox()
        Me.CheckBox6 = New System.Windows.Forms.CheckBox()
        Me.CheckBox10 = New System.Windows.Forms.CheckBox()
        Me.CheckBox11 = New System.Windows.Forms.CheckBox()
        Me.radioBatchRendition = New System.Windows.Forms.RadioButton()
        Me.radioBatchValueProtest = New System.Windows.Forms.RadioButton()
        Me.radioBatchTaxBill = New System.Windows.Forms.RadioButton()
        Me.radioCompletedRenditions = New System.Windows.Forms.RadioButton()
        Me.radioCorrectionForm = New System.Windows.Forms.RadioButton()
        Me.radioAffidavitOfEvidenceForm = New System.Windows.Forms.RadioButton()
        Me.pnlFixedAssetRecon = New System.Windows.Forms.Panel()
        Me.radioFixedAssetReconDepr = New System.Windows.Forms.RadioButton()
        Me.radioFixedAssetReconGL = New System.Windows.Forms.RadioButton()
        Me.numMissingDays = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.radioRenditionValueComparison = New System.Windows.Forms.RadioButton()
        Me.chkIncludeZero = New System.Windows.Forms.CheckBox()
        Me.radioDepreciationDetailLeases = New System.Windows.Forms.RadioButton()
        Me.pnlLeasedAssets = New System.Windows.Forms.Panel()
        Me.radioLeasesAll = New System.Windows.Forms.RadioButton()
        Me.radioLeaseImprove = New System.Windows.Forms.RadioButton()
        Me.radioLeasedProperty = New System.Windows.Forms.RadioButton()
        Me.chkShowCostAndFactors = New System.Windows.Forms.CheckBox()
        Me.chkIdentifyFields = New System.Windows.Forms.CheckBox()
        Me.radioTaxAccrualSummary = New System.Windows.Forms.RadioButton()
        Me.grpBatchRendition.SuspendLayout()
        Me.grpBatchValue.SuspendLayout()
        Me.grpBatchTaxBill.SuspendLayout()
        Me.pnlFixedAssetRecon.SuspendLayout()
        CType(Me.numMissingDays, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlLeasedAssets.SuspendLayout()
        Me.SuspendLayout()
        '
        'radioDepreciationDetail
        '
        Me.radioDepreciationDetail.AutoSize = True
        Me.radioDepreciationDetail.Location = New System.Drawing.Point(16, 12)
        Me.radioDepreciationDetail.Name = "radioDepreciationDetail"
        Me.radioDepreciationDetail.Size = New System.Drawing.Size(81, 17)
        Me.radioDepreciationDetail.TabIndex = 0
        Me.radioDepreciationDetail.TabStop = True
        Me.radioDepreciationDetail.Text = "Asset Detail"
        Me.radioDepreciationDetail.UseVisualStyleBackColor = True
        '
        'cmdRun
        '
        Me.cmdRun.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.cmdRun.Location = New System.Drawing.Point(473, 541)
        Me.cmdRun.Name = "cmdRun"
        Me.cmdRun.Size = New System.Drawing.Size(75, 23)
        Me.cmdRun.TabIndex = 37
        Me.cmdRun.Text = "Run"
        Me.cmdRun.UseVisualStyleBackColor = True
        '
        'radioRenditionForm
        '
        Me.radioRenditionForm.AutoSize = True
        Me.radioRenditionForm.Location = New System.Drawing.Point(16, 188)
        Me.radioRenditionForm.Name = "radioRenditionForm"
        Me.radioRenditionForm.Size = New System.Drawing.Size(96, 17)
        Me.radioRenditionForm.TabIndex = 9
        Me.radioRenditionForm.TabStop = True
        Me.radioRenditionForm.Text = "Rendition Form"
        Me.radioRenditionForm.UseVisualStyleBackColor = True
        '
        'radioFreeportForm
        '
        Me.radioFreeportForm.AutoSize = True
        Me.radioFreeportForm.Location = New System.Drawing.Point(200, 208)
        Me.radioFreeportForm.Name = "radioFreeportForm"
        Me.radioFreeportForm.Size = New System.Drawing.Size(90, 17)
        Me.radioFreeportForm.TabIndex = 13
        Me.radioFreeportForm.TabStop = True
        Me.radioFreeportForm.Text = "Freeport Form"
        Me.radioFreeportForm.UseVisualStyleBackColor = True
        '
        'radioDepreciationSummary
        '
        Me.radioDepreciationSummary.AutoSize = True
        Me.radioDepreciationSummary.Location = New System.Drawing.Point(16, 64)
        Me.radioDepreciationSummary.Name = "radioDepreciationSummary"
        Me.radioDepreciationSummary.Size = New System.Drawing.Size(97, 17)
        Me.radioDepreciationSummary.TabIndex = 4
        Me.radioDepreciationSummary.TabStop = True
        Me.radioDepreciationSummary.Text = "Asset Summary"
        Me.radioDepreciationSummary.UseVisualStyleBackColor = True
        '
        'chkShowCost
        '
        Me.chkShowCost.AutoSize = True
        Me.chkShowCost.Location = New System.Drawing.Point(116, 64)
        Me.chkShowCost.Name = "chkShowCost"
        Me.chkShowCost.Size = New System.Drawing.Size(115, 17)
        Me.chkShowCost.TabIndex = 5
        Me.chkShowCost.Text = "Show Original Cost"
        Me.chkShowCost.UseVisualStyleBackColor = True
        '
        'chkPrint
        '
        Me.chkPrint.AutoSize = True
        Me.chkPrint.Location = New System.Drawing.Point(15, 441)
        Me.chkPrint.Name = "chkPrint"
        Me.chkPrint.Size = New System.Drawing.Size(95, 17)
        Me.chkPrint.TabIndex = 33
        Me.chkPrint.Text = "Send to printer"
        Me.chkPrint.UseVisualStyleBackColor = True
        '
        'radioValueProtestForm
        '
        Me.radioValueProtestForm.AutoSize = True
        Me.radioValueProtestForm.Location = New System.Drawing.Point(200, 228)
        Me.radioValueProtestForm.Name = "radioValueProtestForm"
        Me.radioValueProtestForm.Size = New System.Drawing.Size(114, 17)
        Me.radioValueProtestForm.TabIndex = 14
        Me.radioValueProtestForm.TabStop = True
        Me.radioValueProtestForm.Text = "Value Protest Form"
        Me.radioValueProtestForm.UseVisualStyleBackColor = True
        '
        'radioDepreciationDetailCost
        '
        Me.radioDepreciationDetailCost.AutoSize = True
        Me.radioDepreciationDetailCost.Location = New System.Drawing.Point(16, 32)
        Me.radioDepreciationDetailCost.Name = "radioDepreciationDetailCost"
        Me.radioDepreciationDetailCost.Size = New System.Drawing.Size(130, 17)
        Me.radioDepreciationDetailCost.TabIndex = 2
        Me.radioDepreciationDetailCost.TabStop = True
        Me.radioDepreciationDetailCost.Text = "Asset Detail With Cost"
        Me.radioDepreciationDetailCost.UseVisualStyleBackColor = True
        '
        'radioDepreciationDetailExempt
        '
        Me.radioDepreciationDetailExempt.AutoSize = True
        Me.radioDepreciationDetailExempt.Location = New System.Drawing.Point(16, 84)
        Me.radioDepreciationDetailExempt.Name = "radioDepreciationDetailExempt"
        Me.radioDepreciationDetailExempt.Size = New System.Drawing.Size(94, 17)
        Me.radioDepreciationDetailExempt.TabIndex = 6
        Me.radioDepreciationDetailExempt.TabStop = True
        Me.radioDepreciationDetailExempt.Text = "Exempt Assets"
        Me.radioDepreciationDetailExempt.UseVisualStyleBackColor = True
        '
        'radioDepreciationDetailNon
        '
        Me.radioDepreciationDetailNon.AutoSize = True
        Me.radioDepreciationDetailNon.Location = New System.Drawing.Point(16, 104)
        Me.radioDepreciationDetailNon.Name = "radioDepreciationDetailNon"
        Me.radioDepreciationDetailNon.Size = New System.Drawing.Size(116, 17)
        Me.radioDepreciationDetailNon.TabIndex = 7
        Me.radioDepreciationDetailNon.TabStop = True
        Me.radioDepreciationDetailNon.Text = "Non-taxable Assets"
        Me.radioDepreciationDetailNon.UseVisualStyleBackColor = True
        '
        'radioTaxBill
        '
        Me.radioTaxBill.AutoSize = True
        Me.radioTaxBill.Location = New System.Drawing.Point(16, 260)
        Me.radioTaxBill.Name = "radioTaxBill"
        Me.radioTaxBill.Size = New System.Drawing.Size(59, 17)
        Me.radioTaxBill.TabIndex = 17
        Me.radioTaxBill.TabStop = True
        Me.radioTaxBill.Text = "Tax Bill"
        Me.radioTaxBill.UseVisualStyleBackColor = True
        '
        'radioTaxBillCheckOff
        '
        Me.radioTaxBillCheckOff.AutoSize = True
        Me.radioTaxBillCheckOff.Location = New System.Drawing.Point(16, 280)
        Me.radioTaxBillCheckOff.Name = "radioTaxBillCheckOff"
        Me.radioTaxBillCheckOff.Size = New System.Drawing.Size(110, 17)
        Me.radioTaxBillCheckOff.TabIndex = 18
        Me.radioTaxBillCheckOff.TabStop = True
        Me.radioTaxBillCheckOff.Text = "Tax Bill Check-Off"
        Me.radioTaxBillCheckOff.UseVisualStyleBackColor = True
        '
        'radioAppointmentOfAgentForm
        '
        Me.radioAppointmentOfAgentForm.AutoSize = True
        Me.radioAppointmentOfAgentForm.Location = New System.Drawing.Point(200, 188)
        Me.radioAppointmentOfAgentForm.Name = "radioAppointmentOfAgentForm"
        Me.radioAppointmentOfAgentForm.Size = New System.Drawing.Size(153, 17)
        Me.radioAppointmentOfAgentForm.TabIndex = 12
        Me.radioAppointmentOfAgentForm.TabStop = True
        Me.radioAppointmentOfAgentForm.Text = "Appointment of Agent Form"
        Me.radioAppointmentOfAgentForm.UseVisualStyleBackColor = True
        '
        'chkExport
        '
        Me.chkExport.AutoSize = True
        Me.chkExport.Location = New System.Drawing.Point(15, 464)
        Me.chkExport.Name = "chkExport"
        Me.chkExport.Size = New System.Drawing.Size(56, 17)
        Me.chkExport.TabIndex = 34
        Me.chkExport.Text = "Export"
        Me.chkExport.UseVisualStyleBackColor = True
        '
        'txtFolder
        '
        Me.txtFolder.Location = New System.Drawing.Point(96, 492)
        Me.txtFolder.Name = "txtFolder"
        Me.txtFolder.Size = New System.Drawing.Size(332, 20)
        Me.txtFolder.TabIndex = 36
        '
        'cmdBrowse
        '
        Me.cmdBrowse.Location = New System.Drawing.Point(15, 489)
        Me.cmdBrowse.Name = "cmdBrowse"
        Me.cmdBrowse.Size = New System.Drawing.Size(75, 23)
        Me.cmdBrowse.TabIndex = 35
        Me.cmdBrowse.Text = "Browse"
        Me.cmdBrowse.UseVisualStyleBackColor = True
        '
        'radioRenditionExtensionForm
        '
        Me.radioRenditionExtensionForm.AutoSize = True
        Me.radioRenditionExtensionForm.Location = New System.Drawing.Point(16, 208)
        Me.radioRenditionExtensionForm.Name = "radioRenditionExtensionForm"
        Me.radioRenditionExtensionForm.Size = New System.Drawing.Size(145, 17)
        Me.radioRenditionExtensionForm.TabIndex = 10
        Me.radioRenditionExtensionForm.TabStop = True
        Me.radioRenditionExtensionForm.Text = "Rendition Extension Form"
        Me.radioRenditionExtensionForm.UseVisualStyleBackColor = True
        '
        'radioRenditionDueDate
        '
        Me.radioRenditionDueDate.AutoSize = True
        Me.radioRenditionDueDate.Location = New System.Drawing.Point(200, 260)
        Me.radioRenditionDueDate.Name = "radioRenditionDueDate"
        Me.radioRenditionDueDate.Size = New System.Drawing.Size(124, 17)
        Me.radioRenditionDueDate.TabIndex = 21
        Me.radioRenditionDueDate.TabStop = True
        Me.radioRenditionDueDate.Text = "Rendition Due Dates"
        Me.radioRenditionDueDate.UseVisualStyleBackColor = True
        '
        'radioMissingTaxBills
        '
        Me.radioMissingTaxBills.AutoSize = True
        Me.radioMissingTaxBills.Location = New System.Drawing.Point(200, 300)
        Me.radioMissingTaxBills.Name = "radioMissingTaxBills"
        Me.radioMissingTaxBills.Size = New System.Drawing.Size(102, 17)
        Me.radioMissingTaxBills.TabIndex = 23
        Me.radioMissingTaxBills.TabStop = True
        Me.radioMissingTaxBills.Text = "Missing Tax Bills"
        Me.radioMissingTaxBills.UseVisualStyleBackColor = True
        '
        'radioMissingNotice
        '
        Me.radioMissingNotice.AutoSize = True
        Me.radioMissingNotice.Location = New System.Drawing.Point(200, 320)
        Me.radioMissingNotice.Name = "radioMissingNotice"
        Me.radioMissingNotice.Size = New System.Drawing.Size(94, 17)
        Me.radioMissingNotice.TabIndex = 25
        Me.radioMissingNotice.TabStop = True
        Me.radioMissingNotice.Text = "Missing Notice"
        Me.radioMissingNotice.UseVisualStyleBackColor = True
        '
        'radioCertificateOfMailing
        '
        Me.radioCertificateOfMailing.AutoSize = True
        Me.radioCertificateOfMailing.Location = New System.Drawing.Point(16, 228)
        Me.radioCertificateOfMailing.Name = "radioCertificateOfMailing"
        Me.radioCertificateOfMailing.Size = New System.Drawing.Size(120, 17)
        Me.radioCertificateOfMailing.TabIndex = 11
        Me.radioCertificateOfMailing.TabStop = True
        Me.radioCertificateOfMailing.Text = "Certificate of Mailing"
        Me.radioCertificateOfMailing.UseVisualStyleBackColor = True
        '
        'radioClientLocationListing
        '
        Me.radioClientLocationListing.AutoSize = True
        Me.radioClientLocationListing.Location = New System.Drawing.Point(200, 340)
        Me.radioClientLocationListing.Name = "radioClientLocationListing"
        Me.radioClientLocationListing.Size = New System.Drawing.Size(128, 17)
        Me.radioClientLocationListing.TabIndex = 26
        Me.radioClientLocationListing.TabStop = True
        Me.radioClientLocationListing.Text = "Client Location Listing"
        Me.radioClientLocationListing.UseVisualStyleBackColor = True
        '
        'radioFixedAssetRecon
        '
        Me.radioFixedAssetRecon.AutoSize = True
        Me.radioFixedAssetRecon.Location = New System.Drawing.Point(16, 156)
        Me.radioFixedAssetRecon.Name = "radioFixedAssetRecon"
        Me.radioFixedAssetRecon.Size = New System.Drawing.Size(149, 17)
        Me.radioFixedAssetRecon.TabIndex = 10
        Me.radioFixedAssetRecon.TabStop = True
        Me.radioFixedAssetRecon.Text = "Fixed Asset Reconciliation"
        Me.radioFixedAssetRecon.UseVisualStyleBackColor = True
        '
        'radioTaxAccrual
        '
        Me.radioTaxAccrual.AutoSize = True
        Me.radioTaxAccrual.Location = New System.Drawing.Point(16, 300)
        Me.radioTaxAccrual.Name = "radioTaxAccrual"
        Me.radioTaxAccrual.Size = New System.Drawing.Size(82, 17)
        Me.radioTaxAccrual.TabIndex = 19
        Me.radioTaxAccrual.TabStop = True
        Me.radioTaxAccrual.Text = "Tax Accrual"
        Me.radioTaxAccrual.UseVisualStyleBackColor = True
        '
        'radioTaxSavings
        '
        Me.radioTaxSavings.AutoSize = True
        Me.radioTaxSavings.Location = New System.Drawing.Point(16, 340)
        Me.radioTaxSavings.Name = "radioTaxSavings"
        Me.radioTaxSavings.Size = New System.Drawing.Size(84, 17)
        Me.radioTaxSavings.TabIndex = 20
        Me.radioTaxSavings.TabStop = True
        Me.radioTaxSavings.Text = "Tax Savings"
        Me.radioTaxSavings.UseVisualStyleBackColor = True
        '
        'cboFactoringEntity
        '
        Me.cboFactoringEntity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboFactoringEntity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboFactoringEntity.FormattingEnabled = True
        Me.cboFactoringEntity.Location = New System.Drawing.Point(332, 16)
        Me.cboFactoringEntity.Name = "cboFactoringEntity"
        Me.cboFactoringEntity.Size = New System.Drawing.Size(224, 21)
        Me.cboFactoringEntity.TabIndex = 7
        Me.cboFactoringEntity.Tag = ""
        '
        'radioAssessorCover
        '
        Me.radioAssessorCover.AutoSize = True
        Me.radioAssessorCover.Location = New System.Drawing.Point(15, 379)
        Me.radioAssessorCover.Name = "radioAssessorCover"
        Me.radioAssessorCover.Size = New System.Drawing.Size(124, 17)
        Me.radioAssessorCover.TabIndex = 28
        Me.radioAssessorCover.TabStop = True
        Me.radioAssessorCover.Text = "Assessor cover page"
        Me.radioAssessorCover.UseVisualStyleBackColor = True
        '
        'radioClientEnvelope
        '
        Me.radioClientEnvelope.AutoSize = True
        Me.radioClientEnvelope.Location = New System.Drawing.Point(200, 380)
        Me.radioClientEnvelope.Name = "radioClientEnvelope"
        Me.radioClientEnvelope.Size = New System.Drawing.Size(99, 17)
        Me.radioClientEnvelope.TabIndex = 31
        Me.radioClientEnvelope.TabStop = True
        Me.radioClientEnvelope.Text = "Client Envelope"
        Me.radioClientEnvelope.UseVisualStyleBackColor = True
        '
        'cboContactType
        '
        Me.cboContactType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboContactType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboContactType.FormattingEnabled = True
        Me.cboContactType.Items.AddRange(New Object() {"Tax", "Invoice", "Contract", "Information", "Miscellaneous"})
        Me.cboContactType.Location = New System.Drawing.Point(304, 378)
        Me.cboContactType.Name = "cboContactType"
        Me.cboContactType.Size = New System.Drawing.Size(114, 21)
        Me.cboContactType.TabIndex = 32
        Me.cboContactType.Tag = ""
        Me.cboContactType.Text = "Tax"
        '
        'radioBarCode
        '
        Me.radioBarCode.AutoSize = True
        Me.radioBarCode.Location = New System.Drawing.Point(15, 402)
        Me.radioBarCode.Name = "radioBarCode"
        Me.radioBarCode.Size = New System.Drawing.Size(95, 17)
        Me.radioBarCode.TabIndex = 29
        Me.radioBarCode.TabStop = True
        Me.radioBarCode.Text = "Bar code page"
        Me.radioBarCode.UseVisualStyleBackColor = True
        '
        'cboBarCode
        '
        Me.cboBarCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBarCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBarCode.FormattingEnabled = True
        Me.cboBarCode.Items.AddRange(New Object() {"AOA", "Audit", "Communication", "Data", "Evidence", "Exempt", "Extension", "Hearing Final Order", "Hearing Notice", "Notice", "Protest", "Rendition", "Report", "Tax Bill", "V1 AGR", "V1 Lawsuit", "VSR"})
        Me.cboBarCode.Location = New System.Drawing.Point(115, 401)
        Me.cboBarCode.Name = "cboBarCode"
        Me.cboBarCode.Size = New System.Drawing.Size(114, 21)
        Me.cboBarCode.Sorted = True
        Me.cboBarCode.TabIndex = 30
        Me.cboBarCode.Tag = ""
        Me.cboBarCode.Text = "AOA"
        '
        'chkCover
        '
        Me.chkCover.AutoSize = True
        Me.chkCover.Location = New System.Drawing.Point(332, 40)
        Me.chkCover.Name = "chkCover"
        Me.chkCover.Size = New System.Drawing.Size(165, 17)
        Me.chkCover.TabIndex = 8
        Me.chkCover.Text = "Include bar code cover sheet"
        Me.chkCover.UseVisualStyleBackColor = True
        '
        'grpBatchRendition
        '
        Me.grpBatchRendition.Controls.Add(Me.chkIncludeZeroBatch)
        Me.grpBatchRendition.Controls.Add(Me.chkShowCostBatch)
        Me.grpBatchRendition.Controls.Add(Me.chkBatchRenditionCert)
        Me.grpBatchRendition.Controls.Add(Me.chkBatchRenditionAssessor)
        Me.grpBatchRendition.Controls.Add(Me.chkBatchRenditionRendition)
        Me.grpBatchRendition.Controls.Add(Me.chkBatchRenditionAssetSummary)
        Me.grpBatchRendition.Controls.Add(Me.chkBatchRenditionBarCode)
        Me.grpBatchRendition.Controls.Add(Me.chkBatchRenditionAssetDetail)
        Me.grpBatchRendition.Location = New System.Drawing.Point(591, 15)
        Me.grpBatchRendition.Name = "grpBatchRendition"
        Me.grpBatchRendition.Size = New System.Drawing.Size(273, 148)
        Me.grpBatchRendition.TabIndex = 30
        Me.grpBatchRendition.TabStop = False
        Me.grpBatchRendition.Text = "Rendition Batch"
        '
        'chkIncludeZeroBatch
        '
        Me.chkIncludeZeroBatch.AutoSize = True
        Me.chkIncludeZeroBatch.Location = New System.Drawing.Point(108, 60)
        Me.chkIncludeZeroBatch.Name = "chkIncludeZeroBatch"
        Me.chkIncludeZeroBatch.Size = New System.Drawing.Size(154, 17)
        Me.chkIncludeZeroBatch.TabIndex = 7
        Me.chkIncludeZeroBatch.Text = "Include assets with no cost"
        Me.chkIncludeZeroBatch.UseVisualStyleBackColor = True
        '
        'chkShowCostBatch
        '
        Me.chkShowCostBatch.AutoSize = True
        Me.chkShowCostBatch.Location = New System.Drawing.Point(108, 40)
        Me.chkShowCostBatch.Name = "chkShowCostBatch"
        Me.chkShowCostBatch.Size = New System.Drawing.Size(115, 17)
        Me.chkShowCostBatch.TabIndex = 6
        Me.chkShowCostBatch.Text = "Show Original Cost"
        Me.chkShowCostBatch.UseVisualStyleBackColor = True
        '
        'chkBatchRenditionCert
        '
        Me.chkBatchRenditionCert.AutoSize = True
        Me.chkBatchRenditionCert.Checked = True
        Me.chkBatchRenditionCert.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBatchRenditionCert.Location = New System.Drawing.Point(8, 100)
        Me.chkBatchRenditionCert.Name = "chkBatchRenditionCert"
        Me.chkBatchRenditionCert.Size = New System.Drawing.Size(120, 17)
        Me.chkBatchRenditionCert.TabIndex = 2
        Me.chkBatchRenditionCert.Text = "Certificate of mailing"
        Me.chkBatchRenditionCert.UseVisualStyleBackColor = True
        '
        'chkBatchRenditionAssessor
        '
        Me.chkBatchRenditionAssessor.AutoSize = True
        Me.chkBatchRenditionAssessor.Checked = True
        Me.chkBatchRenditionAssessor.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBatchRenditionAssessor.Location = New System.Drawing.Point(8, 80)
        Me.chkBatchRenditionAssessor.Name = "chkBatchRenditionAssessor"
        Me.chkBatchRenditionAssessor.Size = New System.Drawing.Size(98, 17)
        Me.chkBatchRenditionAssessor.TabIndex = 1
        Me.chkBatchRenditionAssessor.Text = "Assessor cover"
        Me.chkBatchRenditionAssessor.UseVisualStyleBackColor = True
        '
        'chkBatchRenditionRendition
        '
        Me.chkBatchRenditionRendition.AutoSize = True
        Me.chkBatchRenditionRendition.Checked = True
        Me.chkBatchRenditionRendition.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBatchRenditionRendition.Location = New System.Drawing.Point(8, 20)
        Me.chkBatchRenditionRendition.Name = "chkBatchRenditionRendition"
        Me.chkBatchRenditionRendition.Size = New System.Drawing.Size(94, 17)
        Me.chkBatchRenditionRendition.TabIndex = 3
        Me.chkBatchRenditionRendition.Text = "Rendition form"
        Me.chkBatchRenditionRendition.UseVisualStyleBackColor = True
        '
        'chkBatchRenditionAssetSummary
        '
        Me.chkBatchRenditionAssetSummary.AutoSize = True
        Me.chkBatchRenditionAssetSummary.Checked = True
        Me.chkBatchRenditionAssetSummary.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBatchRenditionAssetSummary.Location = New System.Drawing.Point(8, 40)
        Me.chkBatchRenditionAssetSummary.Name = "chkBatchRenditionAssetSummary"
        Me.chkBatchRenditionAssetSummary.Size = New System.Drawing.Size(96, 17)
        Me.chkBatchRenditionAssetSummary.TabIndex = 5
        Me.chkBatchRenditionAssetSummary.Text = "Asset summary"
        Me.chkBatchRenditionAssetSummary.UseVisualStyleBackColor = True
        '
        'chkBatchRenditionAssetDetail
        '
        Me.chkBatchRenditionAssetDetail.AutoSize = True
        Me.chkBatchRenditionAssetDetail.Checked = True
        Me.chkBatchRenditionAssetDetail.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBatchRenditionAssetDetail.Location = New System.Drawing.Point(8, 60)
        Me.chkBatchRenditionAssetDetail.Name = "chkBatchRenditionAssetDetail"
        Me.chkBatchRenditionAssetDetail.Size = New System.Drawing.Size(80, 17)
        Me.chkBatchRenditionAssetDetail.TabIndex = 4
        Me.chkBatchRenditionAssetDetail.Text = "Asset detail"
        Me.chkBatchRenditionAssetDetail.UseVisualStyleBackColor = True
        '
        'chkBatchRenditionBarCode
        '
        Me.chkBatchRenditionBarCode.AutoSize = True
        Me.chkBatchRenditionBarCode.Checked = True
        Me.chkBatchRenditionBarCode.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBatchRenditionBarCode.Location = New System.Drawing.Point(8, 120)
        Me.chkBatchRenditionBarCode.Name = "chkBatchRenditionBarCode"
        Me.chkBatchRenditionBarCode.Size = New System.Drawing.Size(99, 17)
        Me.chkBatchRenditionBarCode.TabIndex = 0
        Me.chkBatchRenditionBarCode.Text = "Bar code cover"
        Me.chkBatchRenditionBarCode.UseVisualStyleBackColor = True
        '
        'grpBatchValue
        '
        Me.grpBatchValue.Controls.Add(Me.chkBatchValueProtestCert)
        Me.grpBatchValue.Controls.Add(Me.chkBatchValueProtestAssessor)
        Me.grpBatchValue.Controls.Add(Me.chkBatchValueProtestProtest)
        Me.grpBatchValue.Controls.Add(Me.chkBatchValueProtestBarCode)
        Me.grpBatchValue.Location = New System.Drawing.Point(591, 179)
        Me.grpBatchValue.Name = "grpBatchValue"
        Me.grpBatchValue.Size = New System.Drawing.Size(136, 116)
        Me.grpBatchValue.TabIndex = 32
        Me.grpBatchValue.TabStop = False
        Me.grpBatchValue.Text = "Value Protest Batch"
        '
        'chkBatchValueProtestCert
        '
        Me.chkBatchValueProtestCert.AutoSize = True
        Me.chkBatchValueProtestCert.Checked = True
        Me.chkBatchValueProtestCert.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBatchValueProtestCert.Location = New System.Drawing.Point(8, 60)
        Me.chkBatchValueProtestCert.Name = "chkBatchValueProtestCert"
        Me.chkBatchValueProtestCert.Size = New System.Drawing.Size(120, 17)
        Me.chkBatchValueProtestCert.TabIndex = 2
        Me.chkBatchValueProtestCert.Text = "Certificate of mailing"
        Me.chkBatchValueProtestCert.UseVisualStyleBackColor = True
        '
        'chkBatchValueProtestAssessor
        '
        Me.chkBatchValueProtestAssessor.AutoSize = True
        Me.chkBatchValueProtestAssessor.Checked = True
        Me.chkBatchValueProtestAssessor.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBatchValueProtestAssessor.Location = New System.Drawing.Point(8, 40)
        Me.chkBatchValueProtestAssessor.Name = "chkBatchValueProtestAssessor"
        Me.chkBatchValueProtestAssessor.Size = New System.Drawing.Size(98, 17)
        Me.chkBatchValueProtestAssessor.TabIndex = 1
        Me.chkBatchValueProtestAssessor.Text = "Assessor cover"
        Me.chkBatchValueProtestAssessor.UseVisualStyleBackColor = True
        '
        'chkBatchValueProtestProtest
        '
        Me.chkBatchValueProtestProtest.AutoSize = True
        Me.chkBatchValueProtestProtest.Checked = True
        Me.chkBatchValueProtestProtest.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBatchValueProtestProtest.Location = New System.Drawing.Point(8, 80)
        Me.chkBatchValueProtestProtest.Name = "chkBatchValueProtestProtest"
        Me.chkBatchValueProtestProtest.Size = New System.Drawing.Size(82, 17)
        Me.chkBatchValueProtestProtest.TabIndex = 3
        Me.chkBatchValueProtestProtest.Text = "Protest form"
        Me.chkBatchValueProtestProtest.UseVisualStyleBackColor = True
        '
        'chkBatchValueProtestBarCode
        '
        Me.chkBatchValueProtestBarCode.AutoSize = True
        Me.chkBatchValueProtestBarCode.Checked = True
        Me.chkBatchValueProtestBarCode.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBatchValueProtestBarCode.Location = New System.Drawing.Point(8, 20)
        Me.chkBatchValueProtestBarCode.Name = "chkBatchValueProtestBarCode"
        Me.chkBatchValueProtestBarCode.Size = New System.Drawing.Size(99, 17)
        Me.chkBatchValueProtestBarCode.TabIndex = 0
        Me.chkBatchValueProtestBarCode.Text = "Bar code cover"
        Me.chkBatchValueProtestBarCode.UseVisualStyleBackColor = True
        '
        'grpBatchTaxBill
        '
        Me.grpBatchTaxBill.Controls.Add(Me.CheckBox14)
        Me.grpBatchTaxBill.Controls.Add(Me.CheckBox6)
        Me.grpBatchTaxBill.Controls.Add(Me.CheckBox10)
        Me.grpBatchTaxBill.Controls.Add(Me.CheckBox11)
        Me.grpBatchTaxBill.Location = New System.Drawing.Point(591, 307)
        Me.grpBatchTaxBill.Name = "grpBatchTaxBill"
        Me.grpBatchTaxBill.Size = New System.Drawing.Size(136, 108)
        Me.grpBatchTaxBill.TabIndex = 34
        Me.grpBatchTaxBill.TabStop = False
        Me.grpBatchTaxBill.Text = "Tax Bill Batch"
        Me.grpBatchTaxBill.Visible = False
        '
        'CheckBox14
        '
        Me.CheckBox14.AutoSize = True
        Me.CheckBox14.Checked = True
        Me.CheckBox14.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox14.Location = New System.Drawing.Point(8, 60)
        Me.CheckBox14.Name = "CheckBox14"
        Me.CheckBox14.Size = New System.Drawing.Size(120, 17)
        Me.CheckBox14.TabIndex = 2
        Me.CheckBox14.Text = "Certificate of mailing"
        Me.CheckBox14.UseVisualStyleBackColor = True
        '
        'CheckBox6
        '
        Me.CheckBox6.AutoSize = True
        Me.CheckBox6.Checked = True
        Me.CheckBox6.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox6.Location = New System.Drawing.Point(8, 40)
        Me.CheckBox6.Name = "CheckBox6"
        Me.CheckBox6.Size = New System.Drawing.Size(98, 17)
        Me.CheckBox6.TabIndex = 1
        Me.CheckBox6.Text = "Assessor cover"
        Me.CheckBox6.UseVisualStyleBackColor = True
        '
        'CheckBox10
        '
        Me.CheckBox10.AutoSize = True
        Me.CheckBox10.Checked = True
        Me.CheckBox10.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox10.Location = New System.Drawing.Point(8, 80)
        Me.CheckBox10.Name = "CheckBox10"
        Me.CheckBox10.Size = New System.Drawing.Size(59, 17)
        Me.CheckBox10.TabIndex = 3
        Me.CheckBox10.Text = "Tax bill"
        Me.CheckBox10.UseVisualStyleBackColor = True
        '
        'CheckBox11
        '
        Me.CheckBox11.AutoSize = True
        Me.CheckBox11.Checked = True
        Me.CheckBox11.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox11.Location = New System.Drawing.Point(8, 20)
        Me.CheckBox11.Name = "CheckBox11"
        Me.CheckBox11.Size = New System.Drawing.Size(99, 17)
        Me.CheckBox11.TabIndex = 0
        Me.CheckBox11.Text = "Bar code cover"
        Me.CheckBox11.UseVisualStyleBackColor = True
        '
        'radioBatchRendition
        '
        Me.radioBatchRendition.AutoSize = True
        Me.radioBatchRendition.Location = New System.Drawing.Point(571, 15)
        Me.radioBatchRendition.Name = "radioBatchRendition"
        Me.radioBatchRendition.Size = New System.Drawing.Size(14, 13)
        Me.radioBatchRendition.TabIndex = 31
        Me.radioBatchRendition.TabStop = True
        Me.radioBatchRendition.UseVisualStyleBackColor = True
        '
        'radioBatchValueProtest
        '
        Me.radioBatchValueProtest.AutoSize = True
        Me.radioBatchValueProtest.Location = New System.Drawing.Point(571, 179)
        Me.radioBatchValueProtest.Name = "radioBatchValueProtest"
        Me.radioBatchValueProtest.Size = New System.Drawing.Size(14, 13)
        Me.radioBatchValueProtest.TabIndex = 32
        Me.radioBatchValueProtest.TabStop = True
        Me.radioBatchValueProtest.UseVisualStyleBackColor = True
        '
        'radioBatchTaxBill
        '
        Me.radioBatchTaxBill.AutoSize = True
        Me.radioBatchTaxBill.Location = New System.Drawing.Point(571, 307)
        Me.radioBatchTaxBill.Name = "radioBatchTaxBill"
        Me.radioBatchTaxBill.Size = New System.Drawing.Size(14, 13)
        Me.radioBatchTaxBill.TabIndex = 33
        Me.radioBatchTaxBill.TabStop = True
        Me.radioBatchTaxBill.UseVisualStyleBackColor = True
        Me.radioBatchTaxBill.Visible = False
        '
        'radioCompletedRenditions
        '
        Me.radioCompletedRenditions.AutoSize = True
        Me.radioCompletedRenditions.Location = New System.Drawing.Point(200, 280)
        Me.radioCompletedRenditions.Name = "radioCompletedRenditions"
        Me.radioCompletedRenditions.Size = New System.Drawing.Size(128, 17)
        Me.radioCompletedRenditions.TabIndex = 22
        Me.radioCompletedRenditions.TabStop = True
        Me.radioCompletedRenditions.Text = "Completed Renditions"
        Me.radioCompletedRenditions.UseVisualStyleBackColor = True
        '
        'radioCorrectionForm
        '
        Me.radioCorrectionForm.AutoSize = True
        Me.radioCorrectionForm.Location = New System.Drawing.Point(388, 208)
        Me.radioCorrectionForm.Name = "radioCorrectionForm"
        Me.radioCorrectionForm.Size = New System.Drawing.Size(99, 17)
        Me.radioCorrectionForm.TabIndex = 16
        Me.radioCorrectionForm.TabStop = True
        Me.radioCorrectionForm.Text = "Correction Form"
        Me.radioCorrectionForm.UseVisualStyleBackColor = True
        '
        'radioAffidavitOfEvidenceForm
        '
        Me.radioAffidavitOfEvidenceForm.AutoSize = True
        Me.radioAffidavitOfEvidenceForm.Location = New System.Drawing.Point(388, 188)
        Me.radioAffidavitOfEvidenceForm.Name = "radioAffidavitOfEvidenceForm"
        Me.radioAffidavitOfEvidenceForm.Size = New System.Drawing.Size(149, 17)
        Me.radioAffidavitOfEvidenceForm.TabIndex = 15
        Me.radioAffidavitOfEvidenceForm.TabStop = True
        Me.radioAffidavitOfEvidenceForm.Text = "Affidavit of Evidence Form"
        Me.radioAffidavitOfEvidenceForm.UseVisualStyleBackColor = True
        '
        'pnlFixedAssetRecon
        '
        Me.pnlFixedAssetRecon.Controls.Add(Me.radioFixedAssetReconDepr)
        Me.pnlFixedAssetRecon.Controls.Add(Me.radioFixedAssetReconGL)
        Me.pnlFixedAssetRecon.Location = New System.Drawing.Point(164, 152)
        Me.pnlFixedAssetRecon.Name = "pnlFixedAssetRecon"
        Me.pnlFixedAssetRecon.Size = New System.Drawing.Size(228, 28)
        Me.pnlFixedAssetRecon.TabIndex = 39
        '
        'radioFixedAssetReconDepr
        '
        Me.radioFixedAssetReconDepr.AutoSize = True
        Me.radioFixedAssetReconDepr.Location = New System.Drawing.Point(94, 5)
        Me.radioFixedAssetReconDepr.Name = "radioFixedAssetReconDepr"
        Me.radioFixedAssetReconDepr.Size = New System.Drawing.Size(122, 17)
        Me.radioFixedAssetReconDepr.TabIndex = 1
        Me.radioFixedAssetReconDepr.Text = "Depr Code Grouping"
        Me.radioFixedAssetReconDepr.UseVisualStyleBackColor = True
        '
        'radioFixedAssetReconGL
        '
        Me.radioFixedAssetReconGL.AutoSize = True
        Me.radioFixedAssetReconGL.Checked = True
        Me.radioFixedAssetReconGL.Location = New System.Drawing.Point(4, 4)
        Me.radioFixedAssetReconGL.Name = "radioFixedAssetReconGL"
        Me.radioFixedAssetReconGL.Size = New System.Drawing.Size(85, 17)
        Me.radioFixedAssetReconGL.TabIndex = 0
        Me.radioFixedAssetReconGL.TabStop = True
        Me.radioFixedAssetReconGL.Text = "GL Grouping"
        Me.radioFixedAssetReconGL.UseVisualStyleBackColor = True
        '
        'numMissingDays
        '
        Me.numMissingDays.Location = New System.Drawing.Point(304, 300)
        Me.numMissingDays.Maximum = New Decimal(New Integer() {365, 0, 0, 0})
        Me.numMissingDays.Name = "numMissingDays"
        Me.numMissingDays.Size = New System.Drawing.Size(48, 20)
        Me.numMissingDays.TabIndex = 24
        Me.numMissingDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numMissingDays.Value = New Decimal(New Integer() {60, 0, 0, 0})
        Me.numMissingDays.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(356, 304)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "days"
        Me.Label1.Visible = False
        '
        'radioRenditionValueComparison
        '
        Me.radioRenditionValueComparison.AutoSize = True
        Me.radioRenditionValueComparison.Location = New System.Drawing.Point(388, 260)
        Me.radioRenditionValueComparison.Name = "radioRenditionValueComparison"
        Me.radioRenditionValueComparison.Size = New System.Drawing.Size(110, 17)
        Me.radioRenditionValueComparison.TabIndex = 27
        Me.radioRenditionValueComparison.TabStop = True
        Me.radioRenditionValueComparison.Text = "Value Comparison"
        Me.radioRenditionValueComparison.UseVisualStyleBackColor = True
        '
        'chkIncludeZero
        '
        Me.chkIncludeZero.AutoSize = True
        Me.chkIncludeZero.Location = New System.Drawing.Point(148, 16)
        Me.chkIncludeZero.Name = "chkIncludeZero"
        Me.chkIncludeZero.Size = New System.Drawing.Size(161, 17)
        Me.chkIncludeZero.TabIndex = 1
        Me.chkIncludeZero.Text = "Include Assets With No Cost"
        Me.chkIncludeZero.UseVisualStyleBackColor = True
        '
        'radioDepreciationDetailLeases
        '
        Me.radioDepreciationDetailLeases.AutoSize = True
        Me.radioDepreciationDetailLeases.Location = New System.Drawing.Point(16, 124)
        Me.radioDepreciationDetailLeases.Name = "radioDepreciationDetailLeases"
        Me.radioDepreciationDetailLeases.Size = New System.Drawing.Size(94, 17)
        Me.radioDepreciationDetailLeases.TabIndex = 8
        Me.radioDepreciationDetailLeases.TabStop = True
        Me.radioDepreciationDetailLeases.Text = "Leased Assets"
        Me.radioDepreciationDetailLeases.UseVisualStyleBackColor = True
        '
        'pnlLeasedAssets
        '
        Me.pnlLeasedAssets.Controls.Add(Me.radioLeasesAll)
        Me.pnlLeasedAssets.Controls.Add(Me.radioLeaseImprove)
        Me.pnlLeasedAssets.Controls.Add(Me.radioLeasedProperty)
        Me.pnlLeasedAssets.Location = New System.Drawing.Point(124, 120)
        Me.pnlLeasedAssets.Name = "pnlLeasedAssets"
        Me.pnlLeasedAssets.Size = New System.Drawing.Size(304, 28)
        Me.pnlLeasedAssets.TabIndex = 43
        '
        'radioLeasesAll
        '
        Me.radioLeasesAll.AutoSize = True
        Me.radioLeasesAll.Location = New System.Drawing.Point(260, 4)
        Me.radioLeasesAll.Name = "radioLeasesAll"
        Me.radioLeasesAll.Size = New System.Drawing.Size(36, 17)
        Me.radioLeasesAll.TabIndex = 2
        Me.radioLeasesAll.Text = "All"
        Me.radioLeasesAll.UseVisualStyleBackColor = True
        '
        'radioLeaseImprove
        '
        Me.radioLeaseImprove.AutoSize = True
        Me.radioLeaseImprove.Location = New System.Drawing.Point(112, 4)
        Me.radioLeaseImprove.Name = "radioLeaseImprove"
        Me.radioLeaseImprove.Size = New System.Drawing.Size(143, 17)
        Me.radioLeaseImprove.TabIndex = 1
        Me.radioLeaseImprove.Text = "Leasehold Improvements"
        Me.radioLeaseImprove.UseVisualStyleBackColor = True
        '
        'radioLeasedProperty
        '
        Me.radioLeasedProperty.AutoSize = True
        Me.radioLeasedProperty.Checked = True
        Me.radioLeasedProperty.Location = New System.Drawing.Point(4, 4)
        Me.radioLeasedProperty.Name = "radioLeasedProperty"
        Me.radioLeasedProperty.Size = New System.Drawing.Size(102, 17)
        Me.radioLeasedProperty.TabIndex = 0
        Me.radioLeasedProperty.TabStop = True
        Me.radioLeasedProperty.Text = "Leased Property"
        Me.radioLeasedProperty.UseVisualStyleBackColor = True
        '
        'chkShowCostAndFactors
        '
        Me.chkShowCostAndFactors.AutoSize = True
        Me.chkShowCostAndFactors.Location = New System.Drawing.Point(148, 32)
        Me.chkShowCostAndFactors.Name = "chkShowCostAndFactors"
        Me.chkShowCostAndFactors.Size = New System.Drawing.Size(174, 17)
        Me.chkShowCostAndFactors.TabIndex = 44
        Me.chkShowCostAndFactors.Text = "Show Original Cost and Factors"
        Me.chkShowCostAndFactors.UseVisualStyleBackColor = True
        '
        'chkIdentifyFields
        '
        Me.chkIdentifyFields.AutoSize = True
        Me.chkIdentifyFields.Location = New System.Drawing.Point(736, 544)
        Me.chkIdentifyFields.Name = "chkIdentifyFields"
        Me.chkIdentifyFields.Size = New System.Drawing.Size(84, 17)
        Me.chkIdentifyFields.TabIndex = 45
        Me.chkIdentifyFields.Text = "Identify PDF"
        Me.chkIdentifyFields.UseVisualStyleBackColor = True
        Me.chkIdentifyFields.Visible = False
        '
        'radioTaxAccrualSummary
        '
        Me.radioTaxAccrualSummary.AutoSize = True
        Me.radioTaxAccrualSummary.Location = New System.Drawing.Point(16, 320)
        Me.radioTaxAccrualSummary.Name = "radioTaxAccrualSummary"
        Me.radioTaxAccrualSummary.Size = New System.Drawing.Size(128, 17)
        Me.radioTaxAccrualSummary.TabIndex = 20
        Me.radioTaxAccrualSummary.TabStop = True
        Me.radioTaxAccrualSummary.Text = "Tax Accrual Summary"
        Me.radioTaxAccrualSummary.UseVisualStyleBackColor = True
        '
        'frmReportSelection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1022, 572)
        Me.Controls.Add(Me.radioTaxAccrualSummary)
        Me.Controls.Add(Me.chkIdentifyFields)
        Me.Controls.Add(Me.chkShowCostAndFactors)
        Me.Controls.Add(Me.pnlLeasedAssets)
        Me.Controls.Add(Me.radioDepreciationDetailLeases)
        Me.Controls.Add(Me.chkIncludeZero)
        Me.Controls.Add(Me.radioRenditionValueComparison)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.numMissingDays)
        Me.Controls.Add(Me.pnlFixedAssetRecon)
        Me.Controls.Add(Me.radioAffidavitOfEvidenceForm)
        Me.Controls.Add(Me.radioCorrectionForm)
        Me.Controls.Add(Me.radioCompletedRenditions)
        Me.Controls.Add(Me.radioBatchTaxBill)
        Me.Controls.Add(Me.radioBatchValueProtest)
        Me.Controls.Add(Me.radioBatchRendition)
        Me.Controls.Add(Me.grpBatchTaxBill)
        Me.Controls.Add(Me.grpBatchValue)
        Me.Controls.Add(Me.grpBatchRendition)
        Me.Controls.Add(Me.chkCover)
        Me.Controls.Add(Me.cboBarCode)
        Me.Controls.Add(Me.radioBarCode)
        Me.Controls.Add(Me.cboContactType)
        Me.Controls.Add(Me.radioClientEnvelope)
        Me.Controls.Add(Me.radioAssessorCover)
        Me.Controls.Add(Me.radioTaxBill)
        Me.Controls.Add(Me.radioTaxBillCheckOff)
        Me.Controls.Add(Me.radioAppointmentOfAgentForm)
        Me.Controls.Add(Me.radioRenditionDueDate)
        Me.Controls.Add(Me.cboFactoringEntity)
        Me.Controls.Add(Me.radioTaxSavings)
        Me.Controls.Add(Me.radioRenditionForm)
        Me.Controls.Add(Me.radioMissingTaxBills)
        Me.Controls.Add(Me.radioFreeportForm)
        Me.Controls.Add(Me.radioTaxAccrual)
        Me.Controls.Add(Me.radioDepreciationDetail)
        Me.Controls.Add(Me.radioMissingNotice)
        Me.Controls.Add(Me.radioValueProtestForm)
        Me.Controls.Add(Me.radioClientLocationListing)
        Me.Controls.Add(Me.radioRenditionExtensionForm)
        Me.Controls.Add(Me.radioDepreciationSummary)
        Me.Controls.Add(Me.radioCertificateOfMailing)
        Me.Controls.Add(Me.chkShowCost)
        Me.Controls.Add(Me.radioFixedAssetRecon)
        Me.Controls.Add(Me.cmdBrowse)
        Me.Controls.Add(Me.radioDepreciationDetailCost)
        Me.Controls.Add(Me.txtFolder)
        Me.Controls.Add(Me.radioDepreciationDetailExempt)
        Me.Controls.Add(Me.chkExport)
        Me.Controls.Add(Me.radioDepreciationDetailNon)
        Me.Controls.Add(Me.chkPrint)
        Me.Controls.Add(Me.cmdRun)
        Me.Name = "frmReportSelection"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reports"
        Me.grpBatchRendition.ResumeLayout(False)
        Me.grpBatchRendition.PerformLayout()
        Me.grpBatchValue.ResumeLayout(False)
        Me.grpBatchValue.PerformLayout()
        Me.grpBatchTaxBill.ResumeLayout(False)
        Me.grpBatchTaxBill.PerformLayout()
        Me.pnlFixedAssetRecon.ResumeLayout(False)
        Me.pnlFixedAssetRecon.PerformLayout()
        CType(Me.numMissingDays, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlLeasedAssets.ResumeLayout(False)
        Me.pnlLeasedAssets.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents radioDepreciationDetail As System.Windows.Forms.RadioButton
    Friend WithEvents cmdRun As System.Windows.Forms.Button
    Friend WithEvents radioRenditionForm As System.Windows.Forms.RadioButton
    Friend WithEvents radioFreeportForm As System.Windows.Forms.RadioButton
    Friend WithEvents radioDepreciationSummary As System.Windows.Forms.RadioButton
    Friend WithEvents chkShowCost As System.Windows.Forms.CheckBox
    Friend WithEvents chkPrint As System.Windows.Forms.CheckBox
    Friend WithEvents radioValueProtestForm As System.Windows.Forms.RadioButton
    Friend WithEvents radioDepreciationDetailCost As System.Windows.Forms.RadioButton
    Friend WithEvents radioDepreciationDetailExempt As System.Windows.Forms.RadioButton
    Friend WithEvents radioDepreciationDetailNon As System.Windows.Forms.RadioButton
    Friend WithEvents radioTaxBill As System.Windows.Forms.RadioButton
    Friend WithEvents radioTaxBillCheckOff As System.Windows.Forms.RadioButton
    Friend WithEvents radioAppointmentOfAgentForm As System.Windows.Forms.RadioButton
    Friend WithEvents chkExport As System.Windows.Forms.CheckBox
    Friend WithEvents txtFolder As System.Windows.Forms.TextBox
    Friend WithEvents cmdBrowse As System.Windows.Forms.Button
    Friend WithEvents radioRenditionExtensionForm As System.Windows.Forms.RadioButton
    Friend WithEvents radioRenditionDueDate As System.Windows.Forms.RadioButton
    Friend WithEvents radioMissingTaxBills As System.Windows.Forms.RadioButton
    Friend WithEvents radioMissingNotice As System.Windows.Forms.RadioButton
    Friend WithEvents radioCertificateOfMailing As System.Windows.Forms.RadioButton
    Friend WithEvents radioClientLocationListing As System.Windows.Forms.RadioButton
    Friend WithEvents radioFixedAssetRecon As System.Windows.Forms.RadioButton
    Friend WithEvents radioTaxAccrual As System.Windows.Forms.RadioButton
    Friend WithEvents radioTaxSavings As System.Windows.Forms.RadioButton
    Friend WithEvents cboFactoringEntity As System.Windows.Forms.ComboBox
    Friend WithEvents radioAssessorCover As System.Windows.Forms.RadioButton
    Friend WithEvents radioClientEnvelope As System.Windows.Forms.RadioButton
    Friend WithEvents cboContactType As System.Windows.Forms.ComboBox
    Friend WithEvents radioBarCode As System.Windows.Forms.RadioButton
    Friend WithEvents cboBarCode As System.Windows.Forms.ComboBox
    Friend WithEvents chkCover As System.Windows.Forms.CheckBox
    Friend WithEvents grpBatchRendition As System.Windows.Forms.GroupBox
    Friend WithEvents chkBatchRenditionAssessor As System.Windows.Forms.CheckBox
    Friend WithEvents chkBatchRenditionRendition As System.Windows.Forms.CheckBox
    Friend WithEvents chkBatchRenditionAssetSummary As System.Windows.Forms.CheckBox
    Friend WithEvents chkBatchRenditionAssetDetail As System.Windows.Forms.CheckBox
    Friend WithEvents chkBatchRenditionBarCode As System.Windows.Forms.CheckBox
    Friend WithEvents grpBatchValue As System.Windows.Forms.GroupBox
    Friend WithEvents chkBatchValueProtestAssessor As System.Windows.Forms.CheckBox
    Friend WithEvents chkBatchValueProtestProtest As System.Windows.Forms.CheckBox
    Friend WithEvents chkBatchValueProtestBarCode As System.Windows.Forms.CheckBox
    Friend WithEvents grpBatchTaxBill As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBox6 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox10 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox11 As System.Windows.Forms.CheckBox
    Friend WithEvents radioBatchRendition As System.Windows.Forms.RadioButton
    Friend WithEvents radioBatchValueProtest As System.Windows.Forms.RadioButton
    Friend WithEvents radioBatchTaxBill As System.Windows.Forms.RadioButton
    Friend WithEvents chkBatchRenditionCert As System.Windows.Forms.CheckBox
    Friend WithEvents chkBatchValueProtestCert As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox14 As System.Windows.Forms.CheckBox
    Friend WithEvents chkShowCostBatch As System.Windows.Forms.CheckBox
    Friend WithEvents radioCompletedRenditions As System.Windows.Forms.RadioButton
    Friend WithEvents radioCorrectionForm As RadioButton
    Friend WithEvents radioAffidavitOfEvidenceForm As RadioButton
    Friend WithEvents pnlFixedAssetRecon As Panel
    Friend WithEvents radioFixedAssetReconDepr As RadioButton
    Friend WithEvents radioFixedAssetReconGL As RadioButton
    Friend WithEvents numMissingDays As NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents radioRenditionValueComparison As RadioButton
    Friend WithEvents chkIncludeZero As CheckBox
    Friend WithEvents chkIncludeZeroBatch As CheckBox
    Friend WithEvents radioDepreciationDetailLeases As RadioButton
    Friend WithEvents pnlLeasedAssets As Panel
    Friend WithEvents radioLeaseImprove As RadioButton
    Friend WithEvents radioLeasedProperty As RadioButton
    Friend WithEvents radioLeasesAll As RadioButton
    Friend WithEvents chkShowCostAndFactors As CheckBox
    Friend WithEvents chkIdentifyFields As CheckBox
    Friend WithEvents radioTaxAccrualSummary As RadioButton
End Class
