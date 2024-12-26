Public Class frmReportSelection
    Private m_Assessments As New Collection
    Private m_ReportType As enumReport
    Private m_PropType As enumTable
    Private m_FactorEntityIdList As New List(Of Long)
    Private bActivated As Boolean = False
    Private dicFactorEntitiesName As New Dictionary(Of String, Long)

    Public Property Assessments() As Collection
        Get
            Return m_Assessments
        End Get
        Set(ByVal value As Collection)
            m_Assessments = value
        End Set
    End Property
    Public Property ReportType() As Integer
        Get
            Return m_ReportType
        End Get
        Set(ByVal value As Integer)
            m_ReportType = value
        End Set
    End Property
    Public Property PropType() As Integer
        Get
            Return m_PropType
        End Get
        Set(ByVal value As Integer)
            m_PropType = value
        End Set
    End Property
    Public Property FactorEntityIdList() As List(Of Long)
        Get
            Return m_FactorEntityIdList
        End Get
        Set(value As List(Of Long))
            m_FactorEntityIdList = value
        End Set
    End Property

    Private Sub cmdRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRun.Click
        Dim frm As Form, frml As frmSelect
        Dim iSuppress As Integer = 0, sExportFolder As String = ""
        Dim eContactType As enumContactTypes
        Dim eBarCodeType As enumBarCodeTypes
        Dim bIncludeZeroAmounts As Boolean = chkIncludeZero.Checked
        Dim identifyfields As Boolean

        Try

            identifyfields = chkIdentifyFields.Checked

            If m_ReportType = enumReport.enumFixedAssetReconByDeprCode Or m_ReportType = enumReport.enumFixedAssetReconByGLCode Then
                If radioFixedAssetReconDepr.Checked Then
                    m_ReportType = enumReport.enumFixedAssetReconByDeprCode
                Else
                    m_ReportType = enumReport.enumFixedAssetReconByGLCode
                End If
            End If
            If m_ReportType = enumReport.enumAssetSummary Then
                If chkShowCost.Checked Then
                    iSuppress = 0
                Else
                    iSuppress = 1
                End If
            ElseIf m_ReportType = enumReport.enumAssetDetailExempt Or m_ReportType = enumReport.enumAssetDetailNon Then
                iSuppress = 1
            ElseIf m_ReportType = enumReport.enumBatchRendition Then
                If chkShowCostBatch.Checked Then
                    iSuppress = 0
                Else
                    iSuppress = 1
                End If
            End If
            If chkExport.Checked = True And Trim(txtFolder.Text) = "" Then
                MsgBox("Please select folder to export to")
                Exit Sub
            End If
            If chkExport.Checked = True Then sExportFolder = txtFolder.Text
            Select Case cboContactType.Text
                Case "Tax"
                    eContactType = enumContactTypes.enumTax
                Case "Invoice"
                    eContactType = enumContactTypes.enumInvoice
                Case "Contract"
                    eContactType = enumContactTypes.enumContract
                Case "Information"
                    eContactType = enumContactTypes.enumInformation
                Case "Miscellaneous"
                    eContactType = enumContactTypes.enumMisc
                Case Else
                    eContactType = enumContactTypes.enumTax
            End Select
            Select Case cboBarCode.Text
                Case "Audit"
                    eBarCodeType = enumBarCodeTypes.Audit
                Case "Communication"
                    eBarCodeType = enumBarCodeTypes.Communication
                Case "Data"
                    eBarCodeType = enumBarCodeTypes.Data
                Case "Exempt"
                    eBarCodeType = enumBarCodeTypes.Exempt
                Case "Notice"
                    eBarCodeType = enumBarCodeTypes.Notice
                Case "Rendition"
                    eBarCodeType = enumBarCodeTypes.Rendition
                Case "Report"
                    eBarCodeType = enumBarCodeTypes.Report
                Case "Tax Bill"
                    eBarCodeType = enumBarCodeTypes.TaxBill
                Case "Protest"
                    eBarCodeType = enumBarCodeTypes.Protest
                Case "Evidence"
                    eBarCodeType = enumBarCodeTypes.Evidence
                Case "VSR"
                    eBarCodeType = enumBarCodeTypes.VSR
                Case "Hearing Notice"
                    eBarCodeType = enumBarCodeTypes.HearingNotice
                Case "Hearing Final Order"
                    eBarCodeType = enumBarCodeTypes.HearingFinalOrder
                Case "AOA"
                    eBarCodeType = enumBarCodeTypes.AOA
                Case "Extension"
                    eBarCodeType = enumBarCodeTypes.Extension
                Case "V1 AGR"
                    eBarCodeType = enumBarCodeTypes.V1AGR
                Case "V1 Lawsuit"
                    eBarCodeType = enumBarCodeTypes.V1Lawsuit
                Case Else
                    eBarCodeType = enumBarCodeTypes.Audit
            End Select

            If m_ReportType = enumReport.enumRenditionDueDate Or
                    m_ReportType = enumReport.enumMissingTaxBills Or m_ReportType = enumReport.enumMissingNotice Or m_ReportType = enumReport.enumCompletedRenditions Then
                Dim sFileName As String = ""
                Dim JurisdictionList As List(Of Long)
                JurisdictionList = New List(Of Long)
                If m_ReportType = enumReport.enumMissingNotice Then
                    sFileName = "MissingNotice"
                ElseIf m_ReportType = enumReport.enumMissingTaxBills Then
                    sFileName = "MissingTaxBills"
                ElseIf m_ReportType = enumReport.enumRenditionDueDate Then
                    sFileName = "RenditionDueDates"
                ElseIf m_ReportType = enumReport.enumCompletedRenditions Then
                    sFileName = "CompletedRenditions"
                End If

                MDIParent1.ShowStatus("Running report")
                RunReport(m_ReportType, 0, 0, 0, JurisdictionList, AppData.TaxYear, m_PropType, 0, iSuppress, chkPrint.Checked,
                    CleanFileName(sFileName & ".pdf"), sExportFolder)
                MDIParent1.ShowStatus()
            Else
                Dim lFactorEntityId As Long = 0
                Dim bPrintClientScheduleOnly As Boolean = False

                If cboFactoringEntity.Text = "Client schedule only" Then
                    bPrintClientScheduleOnly = True
                Else
                    bPrintClientScheduleOnly = False
                End If
                If m_Assessments.Count = 0 Then
                    For Each frm In MDIParent1.MdiChildren
                        If frm.Name = "frmSelect" Then
                            frml = frm
                            If frml.TypeOfReport = m_ReportType Then
                                frml.Parm1 = iSuppress
                                frml.Focus()
                                Exit Sub
                            End If
                        End If
                    Next
                    frml = New frmSelect
                    frml.Parm1 = iSuppress
                    frml.CallingFormHandle = Me.Handle
                    frml.TypeOfReport = m_ReportType
                    frml.Text = "Report Selection"
                    frml.MdiParent = MDIParent1
                    frml.SendToPrinter = chkPrint.Checked
                    frml.ExportFolder = sExportFolder
                    If bPrintClientScheduleOnly = False Then
                        If dicFactorEntitiesName.Count > 0 And dicFactorEntitiesName.ContainsKey(cboFactoringEntity.Text) Then
                            lFactorEntityId = dicFactorEntitiesName(cboFactoringEntity.Text)
                        End If
                    End If
                    frml.FactorEntityId = lFactorEntityId
                    frml.PrintClientScheduleOnly = bPrintClientScheduleOnly
                    frml.ContactType = eContactType
                    frml.BarCodeType = eBarCodeType
                    frml.PrintCoverPage = chkCover.Checked
                    frml.IncludeZeroAmounts = bIncludeZeroAmounts
                    frml.Show()
                Else
                    MDIParent1.ShowStatus("Running report")
                    Dim structAssess As structAssessment
                    For Each structAssess In m_Assessments
                        lFactorEntityId = 0
                        If dicFactorEntitiesName.Count > 0 And dicFactorEntitiesName.ContainsKey(cboFactoringEntity.Text) Then
                            lFactorEntityId = dicFactorEntitiesName(cboFactoringEntity.Text)
                        End If
                        Dim proptype As enumTable
                        If structAssess.PropType Is Nothing Then structAssess.PropType = ""
                        If structAssess.PropType.StartsWith("R") Then
                            proptype = enumTable.enumLocationRE
                        ElseIf structAssess.PropType.StartsWith("B") Then
                            proptype = enumTable.enumLocationBPP
                        Else
                            proptype = m_PropType
                        End If
                        Dim sTempFolder = ""
                        Select Case m_ReportType
                            Case enumReport.enumBatchRendition
                                sTempFolder = AppData.TempPath & "\batchprintrendition_" & structAssess.AssessmentId & "_" & DateTime.Now.Ticks
                                If IO.Directory.Exists(sTempFolder) Then IO.Directory.Delete(sTempFolder, True)
                                IO.Directory.CreateDirectory(sTempFolder)
                                If chkBatchRenditionRendition.Checked Then _
                                        OpenForm(enumReport.enumRenditionForm, structAssess.ClientId, structAssess.LocationId,
                                            structAssess.AssessmentId, structAssess.TaxYear, structAssess.AssessorId, structAssess.StateCd, "", False,
                                            enumTable.enumLocationBPP, sTempFolder, "1", True, identifyfields, "")
                                If chkBatchRenditionAssetSummary.Checked Then _
                                        PrintAccount(enumReport.enumAssetSummary, structAssess, lFactorEntityId, bPrintClientScheduleOnly,
                                        iSuppress, sTempFolder, eContactType, eBarCodeType, False, False, True, "2", False, chkShowCostBatch.Checked, identifyfields)
                                If chkBatchRenditionAssetDetail.Checked Then _
                                        PrintAccount(enumReport.enumAssetDetail, structAssess, lFactorEntityId, bPrintClientScheduleOnly,
                                        iSuppress, sTempFolder, eContactType, eBarCodeType, False, False, True, "3", chkIncludeZeroBatch.Checked, False, identifyfields)
                                If chkBatchRenditionAssessor.Checked Then _
                                        PrintAccount(enumReport.enumAssessorCover, structAssess, lFactorEntityId, bPrintClientScheduleOnly,
                                        iSuppress, sTempFolder, eContactType, eBarCodeType, False, False, True, "4", False, False, identifyfields)
                                If chkBatchRenditionCert.Checked Then _
                                        OpenForm(enumReport.enumCertificateOfMailing, structAssess.ClientId, structAssess.LocationId,
                                            structAssess.AssessmentId, structAssess.TaxYear, structAssess.AssessorId, structAssess.StateCd, "", False,
                                            enumTable.enumLocationBPP, sTempFolder, "5", True, identifyfields, "")
                                If chkBatchRenditionBarCode.Checked Then _
                                        PrintAccount(enumReport.enumBarCode, structAssess, lFactorEntityId, bPrintClientScheduleOnly,
                                        iSuppress, sTempFolder, eContactType, enumBarCodeTypes.Rendition, False, False, True, "6", identifyfields)
                                Dim sCombinedFile As String = sTempFolder & "\" & CleanFileName(structAssess.Description & "_RenditionBatch.pdf")
                                Dim listFiles As List(Of String) = IO.Directory.GetFiles(sTempFolder, "*.pdf", IO.SearchOption.TopDirectoryOnly).ToList
                                If ConcatPages(listFiles, sCombinedFile) Then
                                    RunAdobe(sCombinedFile, chkPrint.Checked, sExportFolder)
                                End If
                            Case enumReport.enumBatchValueProtest
                                sTempFolder = AppData.TempPath & "\batchprintvalueprotest_" & structAssess.AssessmentId & "_" & DateTime.Now.Ticks
                                If IO.Directory.Exists(sTempFolder) Then IO.Directory.Delete(sTempFolder, True)
                                IO.Directory.CreateDirectory(sTempFolder)

                                If chkBatchValueProtestBarCode.Checked Then _
                                        PrintAccount(enumReport.enumBarCode, structAssess, lFactorEntityId, bPrintClientScheduleOnly,
                                        iSuppress, sTempFolder, eContactType, enumBarCodeTypes.Protest, False, False, True, "1", False, False, identifyfields)
                                If chkBatchValueProtestAssessor.Checked Then _
                                        PrintAccount(enumReport.enumAssessorCover, structAssess, lFactorEntityId, bPrintClientScheduleOnly,
                                        iSuppress, sTempFolder, eContactType, eBarCodeType, False, False, True, "2", False, False, identifyfields)
                                If chkBatchValueProtestCert.Checked Then _
                                        OpenForm(enumReport.enumCertificateOfMailing, structAssess.ClientId, structAssess.LocationId,
                                            structAssess.AssessmentId, structAssess.TaxYear, structAssess.AssessorId, structAssess.StateCd, "", False,
                                            proptype, sTempFolder, "3", True, identifyfields, "")
                                If chkBatchValueProtestProtest.Checked Then _
                                        OpenForm(enumReport.enumValueProtestForm, structAssess.ClientId, structAssess.LocationId,
                                            structAssess.AssessmentId, structAssess.TaxYear, structAssess.AssessorId, structAssess.StateCd, "", False,
                                            proptype, sTempFolder, "4", True, identifyfields, "")
                                Dim sCombinedFile As String = sTempFolder & "\" & CleanFileName(structAssess.Description & "_ValueProtestBatch.pdf")
                                Dim listFiles As List(Of String) = IO.Directory.GetFiles(sTempFolder, "*.pdf", IO.SearchOption.TopDirectoryOnly).ToList
                                If ConcatPages(listFiles, sCombinedFile) Then
                                    RunAdobe(sCombinedFile, chkPrint.Checked, sExportFolder)
                                End If
                            Case Else
                                PrintAccount(m_ReportType, structAssess, lFactorEntityId, bPrintClientScheduleOnly, iSuppress, sExportFolder, eContactType,
                                    eBarCodeType, chkCover.Checked, chkPrint.Checked, False, chkIncludeZero.Checked, chkShowCostAndFactors.Checked, identifyfields)
                        End Select
                    Next
                    MDIParent1.ShowStatus()
                    Me.Close()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error running report:  " & ex.Message)
        End Try

    End Sub
    Private Sub PrintAccount(eReportType As enumReport, structAssess As structAssessment, lFactorEntityId As Long,
            bPrintClientScheduleOnly As Boolean, iSuppress As Integer, sExportFolder As String,
            eContactType As enumContactTypes, eBarCodeType As enumBarCodeTypes, bPrintCoverPage As Boolean, bSendToPrinter As Boolean,
            bJustCreatePDF As Boolean, bIncludeZeroAmounts As Boolean, bShowCostAndFactors As Boolean, identifyfields As Boolean)
        PrintAccount(eReportType, structAssess, lFactorEntityId, bPrintClientScheduleOnly, iSuppress, sExportFolder,
            eContactType, eBarCodeType, bPrintCoverPage, bSendToPrinter, bJustCreatePDF, "", bIncludeZeroAmounts, bShowCostAndFactors, identifyfields)
    End Sub
    Private Sub PrintAccount(eReportType As enumReport, structAssess As structAssessment, lFactorEntityId As Long,
            bPrintClientScheduleOnly As Boolean, iSuppress As Integer, sExportFolder As String,
            eContactType As enumContactTypes, eBarCodeType As enumBarCodeTypes, bPrintCoverPage As Boolean, bSendToPrinter As Boolean,
            bJustCreatePDF As Boolean, sFileNamePrefix As String, identifyfields As Boolean)
        PrintAccount(eReportType, structAssess, lFactorEntityId, bPrintClientScheduleOnly, iSuppress, sExportFolder,
            eContactType, eBarCodeType, bPrintCoverPage, bSendToPrinter, bJustCreatePDF, sFileNamePrefix, False, False, identifyfields)
    End Sub
    Private Sub PrintAccount(eReportType As enumReport, structAssess As structAssessment, lFactorEntityId As Long,
            bPrintClientScheduleOnly As Boolean, iSuppress As Integer, sExportFolder As String,
            eContactType As enumContactTypes, eBarCodeType As enumBarCodeTypes, bPrintCoverPage As Boolean, bSendToPrinter As Boolean,
            bJustCreatePDF As Boolean, sFileNamePrefix As String, ByVal bIncludeZeroAmounts As Boolean, ByVal bShowCostAndFactors As Boolean,byval identifyfields As Boolean)
        Dim ePropType As enumTable = enumTable.enumUnknown
        Dim sError As String = ""

        If structAssess.PropType Is Nothing Then structAssess.PropType = ""
        If structAssess.PropType.StartsWith("R") Then
            ePropType = enumTable.enumLocationRE
        ElseIf structAssess.PropType.StartsWith("B") Then
            ePropType = enumTable.enumLocationBPP
        End If
        If ePropType = enumTable.enumUnknown Then ePropType = m_PropType
        If eReportType = enumReport.enumAssetDetail Or eReportType = enumReport.enumAssetSummary Or
                eReportType = enumReport.enumAssetDetailCost Or eReportType = enumReport.enumAssetDetailExempt Or
                eReportType = enumReport.enumAssetDetailNon Or eReportType = enumReport.enumTaxBill Or
                eReportType = enumReport.enumTaxBillCheckOff Or eReportType = enumReport.enumClientLocationListing Or
                eReportType = enumReport.enumFixedAssetReconByGLCode Or eReportType = enumReport.enumFixedAssetReconByDeprCode Or
                eReportType = enumReport.enumTaxAccrual Or
                eReportType = enumReport.enumTaxAccrualSummary Or
                eReportType = enumReport.enumValueComparison Or
                eReportType = enumReport.enumTaxSavings Or eReportType = enumReport.enumAssessorCover Or
                eReportType = enumReport.enumClientEnvelope Or eReportType = enumReport.enumBarCode Or
                eReportType = enumReport.enumAssetDetailLeasedProperty Or
                eReportType = enumReport.enumAssetDetailLeaseholdImprovements Or
                eReportType = enumReport.enumAssetDetailLeasesAll Or
                eReportType = enumReport.enumLeaseSummary Then
            If bPrintClientScheduleOnly Then lFactorEntityId = structAssess.FactorEntityId1
            RunReport(eReportType, structAssess.ClientId, structAssess.LocationId,
                structAssess.AssessmentId, structAssess.JurisdictionList,
                structAssess.TaxYear, ePropType, structAssess.AssessorId, iSuppress, bSendToPrinter,
                IIf(sFileNamePrefix = "", "", sFileNamePrefix & "_") & CleanFileName(eReportType & "_" & structAssess.Description & ".pdf"), sExportFolder,
                lFactorEntityId, bPrintClientScheduleOnly, eContactType, eBarCodeType, bPrintCoverPage, New DataTable, bJustCreatePDF, AppData.IncludeInactive,
                0, "", bIncludeZeroAmounts, bShowCostAndFactors)
        Else
            sError = ""
            If Not OpenForm(eReportType, structAssess.ClientId, structAssess.LocationId,
                    structAssess.AssessmentId, structAssess.TaxYear, structAssess.AssessorId, structAssess.StateCd,
                    "", bSendToPrinter, ePropType, sExportFolder, sFileNamePrefix, False, identifyfields, sError) Then
                MsgBox(sError)
            End If
        End If

    End Sub

    Private Sub radioDepreciation_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
            radioDepreciationDetail.Click, radioFreeportForm.Click, radioRenditionForm.Click,
            radioDepreciationSummary.Click, radioValueProtestForm.Click, radioDepreciationDetailCost.Click,
            radioDepreciationDetailExempt.Click, radioDepreciationDetailNon.Click, radioTaxBill.Click, radioTaxBillCheckOff.Click,
            radioAppointmentOfAgentForm.Click, radioRenditionExtensionForm.Click, radioMissingNotice.Click,
            radioMissingTaxBills.Click, radioRenditionDueDate.Click, radioCertificateOfMailing.Click,
            radioClientLocationListing.Click, radioFixedAssetRecon.Click, radioFixedAssetReconDepr.Click, radioFixedAssetReconGL.Click,
            radioTaxAccrual.Click, radioTaxSavings.Click,
            radioAssessorCover.Click, radioClientEnvelope.Click, radioBarCode.Click, radioBatchRendition.Click, radioBatchValueProtest.Click,
            radioCompletedRenditions.Click, radioAffidavitOfEvidenceForm.Click, radioCorrectionForm.Click, radioRenditionValueComparison.Click,
            radioDepreciationDetailLeases.Click, radioLeasedProperty.Click, radioLeaseImprove.Click, radioLeasesAll.Click, radioTaxAccrualSummary.Click,
            radioLeaseSummary.Click
        If sender.name = "radioDepreciationDetail" Then
            m_ReportType = enumReport.enumAssetDetail
        ElseIf sender.name = "radioDepreciationSummary" Then
            m_ReportType = enumReport.enumAssetSummary
        ElseIf sender.name = "radioDepreciationDetailCost" Then
            m_ReportType = enumReport.enumAssetDetailCost
        ElseIf sender.name = "radioFreeportForm" Then
            m_ReportType = enumReport.enumFreeportForm
        ElseIf sender.name = "radioRenditionForm" Then
            m_ReportType = enumReport.enumRenditionForm
        ElseIf sender.name = "radioBarCode" Then
            m_ReportType = enumReport.enumBarCode
        ElseIf sender.name = "radioRenditionExtensionForm" Then
            m_ReportType = enumReport.enumRenditionExtensionForm
        ElseIf sender.name = "radioValueProtestForm" Then
            m_ReportType = enumReport.enumValueProtestForm
        ElseIf sender.name = "radioAffidavitOfEvidenceForm" Then
            m_ReportType = enumReport.enumAffidavitOfEvidence
        ElseIf sender.name = "radioCorrectionForm" Then
            m_ReportType = enumReport.enumCorrection
        ElseIf sender.name = "radioCertificateOfMailing" Then
            m_ReportType = enumReport.enumCertificateOfMailing
        ElseIf sender.name = "radioDepreciationDetailNon" Then
            m_ReportType = enumReport.enumAssetDetailNon
        ElseIf sender.name = "radioDepreciationDetailExempt" Then
            m_ReportType = enumReport.enumAssetDetailExempt
        ElseIf sender.name = "radioTaxBill" Then
            m_ReportType = enumReport.enumTaxBill
        ElseIf sender.name = "radioTaxBillCheckOff" Then
            m_ReportType = enumReport.enumTaxBillCheckOff
        ElseIf sender.name = "radioAppointmentOfAgentForm" Then
            m_ReportType = enumReport.enumAppointmentOfAgentForm
        ElseIf sender.name = "radioRenditionDueDate" Then
            m_ReportType = enumReport.enumRenditionDueDate
        ElseIf sender.name = radioCompletedRenditions.Name Then
            m_ReportType = enumReport.enumCompletedRenditions
        ElseIf sender.name = "radioMissingTaxBills" Then
            m_ReportType = enumReport.enumMissingTaxBills
        ElseIf sender.name = "radioAssessorCover" Then
            m_ReportType = enumReport.enumAssessorCover
        ElseIf sender.name = "radioMissingNotice" Then
            m_ReportType = enumReport.enumMissingNotice
        ElseIf sender.name = "radioClientLocationListing" Then
            m_ReportType = enumReport.enumClientLocationListing
        ElseIf sender.name = radioFixedAssetRecon.Name Or sender.name = radioFixedAssetReconDepr.Name Or sender.name = radioFixedAssetReconGL.Name Then
            If radioFixedAssetRecon.Checked Then
                If radioFixedAssetReconGL.Checked Then
                    m_ReportType = enumReport.enumFixedAssetReconByGLCode
                Else
                    m_ReportType = enumReport.enumFixedAssetReconByDeprCode
                End If
            End If
        ElseIf sender.name = "radioTaxAccrual" Then
            m_ReportType = enumReport.enumTaxAccrual
        ElseIf sender.name = "radioTaxAccrualSummary" Then
            m_ReportType = enumReport.enumTaxAccrualSummary
        ElseIf sender.name = "radioTaxSavings" Then
            m_ReportType = enumReport.enumTaxSavings
        ElseIf sender.name = "radioClientEnvelope" Then
            m_ReportType = enumReport.enumClientEnvelope
        ElseIf sender.name = "radioBatchRendition" Then
            m_ReportType = enumReport.enumBatchRendition
        ElseIf sender.name = "radioBatchValueProtest" Then
            m_ReportType = enumReport.enumBatchValueProtest
        ElseIf sender.name = "radioRenditionValueComparison" Then
            m_ReportType = enumReport.enumValueComparison
        ElseIf sender.name = radioDepreciationDetailLeases.Name _
                Or sender.name = radioLeasedProperty.Name _
                Or sender.name = radioLeaseImprove.Name _
                Or sender.name = radioLeasesAll.Name Then
            If radioDepreciationDetailLeases.Checked Then
                If radioLeasedProperty.Checked Then
                    m_ReportType = enumReport.enumAssetDetailLeasedProperty
                ElseIf radioLeaseImprove.Checked Then
                    m_ReportType = enumReport.enumAssetDetailLeaseholdImprovements
                Else
                    m_ReportType = enumReport.enumAssetDetailLeasesAll
                End If
            End If
        ElseIf sender.name = radioLeaseSummary.Name Then
            m_ReportType = enumReport.enumLeaseSummary
        End If
    End Sub

    Private Sub cmdBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBrowse.Click
        txtFolder.Text = SelectFolder("ReportExportFolder")
    End Sub

    
    Private Sub frmReportSelection_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        If bActivated Then Exit Sub
        LoadFactoringEntities()
        bActivated = True
    End Sub
    Private Sub LoadFactoringEntities()
        Try
            If m_Assessments.Count = 0 Then
                cboFactoringEntity.Visible = False
            Else
                cboFactoringEntity.Items.Clear()
                dicFactorEntitiesName = New Dictionary(Of String, Long)
                If Not m_FactorEntityIdList Is Nothing Then
                    If m_FactorEntityIdList.Count > 0 Then
                        cboFactoringEntity.Items.Add("Select depreciation schedule")
                        cboFactoringEntity.Items.Add("Client schedule only")
                        cboFactoringEntity.Text = "Select depreciation schedule"
                        Dim sSQL As String = "SELECT FactorEntityId, RTRIM(LTRIM(Name)) + ', ' + StateCd AS Name FROM FactorEntities"
                        sSQL = sSQL & " WHERE FactorEntityId IN ("
                        Dim sIN As String = ""
                        For Each lId As Long In m_FactorEntityIdList
                            If sIN <> "" Then sIN = sIN & ","
                            sIN = sIN & CStr(lId)
                        Next
                        sSQL = sSQL & sIN & ") ORDER BY Name, StateCd"
                        Dim dt As New DataTable
                        GetData(sSQL, dt)
                        For Each dr As DataRow In dt.Rows
                            dicFactorEntitiesName.Add(dr("Name").ToString.Trim, CLng(dr("FactorEntityId").ToString()))
                            cboFactoringEntity.Items.Add(dr("Name").ToString.Trim)
                        Next
                    End If
                End If
                If cboFactoringEntity.Items.Count = 0 Then cboFactoringEntity.Visible = False
            End If
        Catch ex As Exception
            MsgBox("Error loading factoring entities:  " & ex.Message)
        End Try
    End Sub

    Private Sub frmReportSelection_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If m_Assessments.Count = 0 Then
            radioBatchRendition.Visible = False
            radioBatchValueProtest.Visible = False
            radioBatchTaxBill.Visible = False
            grpBatchRendition.Visible = False
            grpBatchTaxBill.Visible = False
            grpBatchValue.Visible = False
            Me.Width = 600
        Else
            radioRenditionValueComparison.Visible = False
        End If
        If AppData.UserId.ToLower.Contains("016445") Or AppData.UserId.ToLower.Contains("stigler") Then
            chkIdentifyFields.Visible = True
        Else
            chkIdentifyFields.Visible = False
        End If
    End Sub


End Class