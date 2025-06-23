Imports System.IO
Imports iTextSharp.text

'**************************************************************************************************
'**************** MUST COPY ASSESSMENTMANAGERDATA.MODREPORTS TO THIS PROJECT **********************
'**************************************************************************************************

Module modReports

    '***********  THIS MDIPARENT1 ONLY EXISTS IN THE CLIENTREPORTINGBACKEND APPLICATION  *******************
    Public MDIParent1 As New MDIParent1()

    Public Function BuildBarCode1(DocType As enumBarCodeTypes, ClientId As Long, TaxYear As Integer, PropType As enumTable,
            LocationId As Long, AssessmentId As Long, JurisdictionId As Long, CollectorId As Long, lCompID As Long) As String
        '*1;123456789;2015;123456789*
        Dim sReturn As New StringBuilder
        sReturn.Append("*").Append(CInt(DocType).ToString)
        sReturn.Append(";").Append(ClientId.ToString)
        sReturn.Append(";").Append(TaxYear.ToString)
        sReturn.Append(";").Append(IIf(PropType = enumTable.enumLocationBPP, "1", "2"))
        sReturn.Append(";").Append(LocationId.ToString)
        sReturn.Append("*")
        Return sReturn.ToString
    End Function
    Public Function BuildBarCode1(DocType As enumBarCodeTypes, ClientId As Long, TaxYear As Integer, PropType As enumTable,
        LocationId As Long, AssessmentId As Long, JurisdictionId As Long, CollectorId As Long) As String
        Return BuildBarCode1(DocType, ClientId, TaxYear, PropType, LocationId, AssessmentId, JurisdictionId, CollectorId, 0)
    End Function
    Public Function BuildBarCode1(DocType As enumBarCodeTypes, lCompID As Long) As String
        Return BuildBarCode1(DocType, 0, 0, enumTable.enumLocationBPP, 0, 0, 0, 0, lCompID)
    End Function
    Public Function BuildBarCode2(DocType As enumBarCodeTypes, ClientId As Long, TaxYear As Integer, PropType As enumTable,
            LocationId As Long, AssessmentId As Long, JurisdictionId As Long, CollectorId As Long, lCompID As Long) As String
        Dim sReturn As New StringBuilder
        'typically   *;123456789;123456789;123456789;0*
        'bpp *;0;0;0;123456789*
        sReturn.Length = 0
        sReturn.Append("*;").Append(AssessmentId.ToString)
        sReturn.Append(";").Append(JurisdictionId.ToString)
        sReturn.Append(";").Append(CollectorId.ToString)
        sReturn.Append(";").Append(lCompID.ToString)
        sReturn.Append("*")
        Return sReturn.ToString
    End Function
    Public Function BuildBarCode2(DocType As enumBarCodeTypes, ClientId As Long, TaxYear As Integer, PropType As enumTable,
        LocationId As Long, AssessmentId As Long, JurisdictionId As Long, CollectorId As Long) As String
        Return BuildBarCode2(DocType, ClientId, TaxYear, PropType, LocationId, AssessmentId, JurisdictionId, CollectorId, 0)
    End Function
    Public Function BuildBarCode2(DocType As enumBarCodeTypes, lCompID As Long) As String
        Return BuildBarCode2(DocType, 0, 0, enumTable.enumLocationBPP, 0, 0, 0, 0, lCompID)
    End Function
    Public Function BuildBarCodeDesc(DocType As enumBarCodeTypes, sDocTypeExtra As String, sClientName As String,
            iTaxYear As Integer,
            sLocationAddress As String, sCity As String, sStateCd As String, sAcctNum As String,
            sClientLocationId As String, sAssessorName As String, sCollectorName As String)
        Return BuildBarCodeDesc(DocType, sDocTypeExtra, sClientName, iTaxYear, sLocationAddress, sCity, sStateCd, sAcctNum,
            sClientLocationId, sAssessorName, sCollectorName, 0)
    End Function
    Public Function BuildBarCodeDesc(DocType As enumBarCodeTypes, lCompID As Long, sAssetType As String, iManufactureYear As Integer,
            sManufacturer As String, sModel As String, sSerialNumber As String)
        Dim sReturn As New StringBuilder
        sReturn.Length = 0
        sReturn.Append("Document type:  ").Append(DocType.ToString).Append(vbCrLf)
        sReturn.Append("ID:  ").Append(lCompID.ToString).Append(vbCrLf)
        sReturn.Append("Asset Type:  ").Append(sAssetType).Append(vbCrLf)
        sReturn.Append("Year Manufactured:  ").Append(iManufactureYear).Append(vbCrLf)
        sReturn.Append("Manufacturer:  ").Append(sManufacturer).Append(vbCrLf)
        sReturn.Append("Model:  ").Append(sModel).Append(vbCrLf)
        sReturn.Append("Serial Number:  ").Append(sSerialNumber)
        Return sReturn.ToString
    End Function
    Public Function BuildBarCodeDesc(DocType As enumBarCodeTypes, sDocTypeExtra As String, sClientName As String,
        iTaxYear As Integer,
        sLocationAddress As String, sCity As String, sStateCd As String, sAcctNum As String,
        sClientLocationId As String, sAssessorName As String, sCollectorName As String, lCompID As Long)

        Dim sReturn As New StringBuilder
        sReturn.Length = 0
        sReturn.Append("Document type:  ").Append(DocType.ToString).Append(sDocTypeExtra).Append(vbCrLf)
        sReturn.Append("Client name:  ").Append(sClientName).Append(vbCrLf)
        sReturn.Append("Tax year:  ").Append(iTaxYear.ToString).Append(vbCrLf)
        sReturn.Append("Location address:  ").Append(sLocationAddress).Append(vbCrLf)
        sReturn.Append("City:  ").Append(sCity).Append(vbCrLf)
        sReturn.Append("State:  ").Append(sStateCd).Append(vbCrLf)
        sReturn.Append("Account number:  ").Append(sAcctNum).Append(vbCrLf)
        sReturn.Append("Client location id:  ").Append(sClientLocationId)
        If sAssessorName <> "" Then sReturn.Append(vbCrLf).Append("Assessor:  ").Append(sAssessorName)
        If sCollectorName <> "" Then sReturn.Append(vbCrLf).Append("Collector:  ").Append(sCollectorName)
        Return sReturn.ToString
    End Function
    Public Function BuildBarCodeImage(DocType As enumBarCodeTypes, ClientId As Long, TaxYear As Integer, PropType As enumTable,
            LocationId As Long, AssessmentId As Long, JurisdictionId As Long, CollectorId As Long) As Byte()
        Return BuildBarCodeImage(DocType, ClientId, TaxYear, PropType, LocationId, AssessmentId, JurisdictionId, CollectorId, 0)
    End Function

    Public Function BuildBarCodeImage(DocType As enumBarCodeTypes, ClientId As Long, TaxYear As Integer, PropType As enumTable,
        LocationId As Long, AssessmentId As Long, JurisdictionId As Long, CollectorId As Long, lCompID As Long) As Byte()

        Dim sCodeContents As New StringBuilder
        sCodeContents.Length = 0
        sCodeContents.Append("*").Append(CInt(DocType).ToString).Append(";").Append(ClientId.ToString).Append(";")
        sCodeContents.Append(TaxYear.ToString).Append(";")
        sCodeContents.Append(IIf(PropType = enumTable.enumLocationBPP, "1", "2")).Append(";")
        sCodeContents.Append(LocationId.ToString).Append(";").Append(AssessmentId.ToString).Append(";")
        sCodeContents.Append(JurisdictionId.ToString).Append(";")
        sCodeContents.Append(CollectorId.ToString).Append(";")
        sCodeContents.Append(lCompID.ToString)
        sCodeContents.Append("*")

        Dim qrCode As OnBarcode.Barcode.QRCode
        ' Create QRCode object
        qrCode = New OnBarcode.Barcode.QRCode()
        ' Set QR Code data to encode
        qrCode.Data = sCodeContents.ToString
        ' Set QRCode data mode (QR-Code Barcode Settings)
        qrCode.DataMode = OnBarcode.Barcode.QRCodeDataMode.Auto
        ' Draw & print generated QR Code to jpeg image file
        qrCode.ImageFormat = System.Drawing.Imaging.ImageFormat.Jpeg
        'qrCode.drawBarcode("C:\DocumentsFolder\qrtest.jpg")


        'qrCode.DataMode = QRCodeDataMode.Byte
        Dim bytes() As Byte
        bytes = qrCode.drawBarcodeAsBytes()

        Return bytes

    End Function
    Public Function RunReport(eType As enumReport, iTaxYear As Integer, dt As DataTable) As Boolean
        Return RunReport(eType, 0, 0, 0, New List(Of Long), iTaxYear, enumTable.enumLocationRE, 0, 0, False, "", "", 0, False, enumContactTypes.enumTax,
            enumBarCodeTypes.Audit, False, dt, False, AppData.IncludeInactive, 0, "")
    End Function
    Public Function RunReport(ByVal eType As enumReport, ByVal lClientId As Long, ByVal lLocationId As Long,
            ByVal lAssessmentId As Long, ByVal JurisdictionList As List(Of Long), ByVal iTaxYear As Integer, ByVal ePropType As enumTable,
            ByVal lAssessorId As Long,
            ByVal iSuppressOriginalCost As Integer,
            ByVal bSendToPrinter As Boolean, ByVal sPDFFileName As String, ByVal sExportFolder As String) As Boolean

        Return RunReport(eType, lClientId, lLocationId, lAssessmentId, JurisdictionList, iTaxYear, ePropType, lAssessorId, iSuppressOriginalCost,
            bSendToPrinter, sPDFFileName, sExportFolder, 0, False, enumContactTypes.enumTax, enumBarCodeTypes.Audit, False, New DataTable, False, AppData.IncludeInactive, 0, "")
    End Function
    Public Function RunReport(ByVal eType As enumReport, ByVal lClientId As Long, ByVal iTaxYear As Integer, ByVal ePropType As enumTable, ByVal lBusinessUnitId As Long,
            ByVal bSendToPrinter As Boolean, ByVal sPDFFileName As String, ByVal sExportFolder As String) As Boolean

        Return RunReport(eType, lClientId, 0, 0, New List(Of Long), iTaxYear, ePropType, 0, 0,
            bSendToPrinter, sPDFFileName, sExportFolder, 0, False, enumContactTypes.enumTax, enumBarCodeTypes.Audit, False, New DataTable, False,
            AppData.IncludeInactive, lBusinessUnitId, "")
    End Function
    Public Function RunReport(ByVal eType As enumReport, ByVal lClientId As Long, ByVal lLocationId As Long,
            ByVal lAssessmentId As Long, ByVal JurisdictionList As List(Of Long), ByVal iTaxYear As Integer,
            ByVal ePropType As enumTable,
            ByVal lAssessorId As Long,
            ByVal iSuppressOriginalCost As Integer,
            ByVal bSendToPrinter As Boolean, ByVal sPDFFileName As String, ByVal sExportFolder As String,
            ByVal lFactorEntityId As Long, ByVal bPrintClientScheduleOnly As Boolean,
            ByVal eContactType As enumContactTypes, eBarCodeType As enumBarCodeTypes, ByVal bPrintCoverPage As Boolean, dtParm As DataTable) As Boolean

        Return RunReport(eType, lClientId, lLocationId, lAssessmentId, JurisdictionList, iTaxYear, ePropType, lAssessorId, iSuppressOriginalCost,
            bSendToPrinter, sPDFFileName, sExportFolder, lFactorEntityId, bPrintClientScheduleOnly, eContactType, eBarCodeType, bPrintCoverPage, dtParm, False, AppData.IncludeInactive, 0, "")
    End Function
    Public Function RunReport(ByVal eType As enumReport, ByVal lClientId As Long, ByVal lLocationId As Long,
            ByVal lAssessmentId As Long, ByVal JurisdictionList As List(Of Long), ByVal iTaxYear As Integer,
            ByVal ePropType As enumTable,
            ByVal lAssessorId As Long,
            ByVal iSuppressOriginalCost As Integer,
            ByVal bSendToPrinter As Boolean, ByVal sPDFFileName As String, ByVal sExportFolder As String,
            ByVal lFactorEntityId As Long, ByVal bPrintClientScheduleOnly As Boolean,
            ByVal eContactType As enumContactTypes, eBarCodeType As enumBarCodeTypes, ByVal bPrintCoverPage As Boolean, dtParm As DataTable,
            ByVal bIncludeZeroAmounts As Boolean, ByVal bShowCostAndFactors As Boolean) As Boolean

        Return RunReport(eType, lClientId, lLocationId, lAssessmentId, JurisdictionList, iTaxYear, ePropType, lAssessorId, iSuppressOriginalCost,
            bSendToPrinter, sPDFFileName, sExportFolder, lFactorEntityId, bPrintClientScheduleOnly, eContactType, eBarCodeType, bPrintCoverPage, dtParm, False,
            AppData.IncludeInactive, 0, "", bIncludeZeroAmounts, bShowCostAndFactors, False)
    End Function
    Public Function RunReport(ByVal eType As enumReport, ByVal lClientId As Long, ByVal iTaxYear As Integer,
            ByVal ePropType As enumTable, ByVal lAssessorId As Long, ByVal lBusinessUnitId As Long, ByVal sStateCd As String,
            ByVal bSendToPrinter As Boolean, ByVal sPDFFileName As String, ByVal sExportFolder As String) As Boolean

        Return RunReport(eType, lClientId, 0, 0, New List(Of Long), iTaxYear, ePropType, lAssessorId, 0,
            bSendToPrinter, sPDFFileName, sExportFolder, 0, False, enumContactTypes.enumContract,
            enumBarCodeTypes.AOA, False, New DataTable, False, AppData.IncludeInactive, lBusinessUnitId, sStateCd)
    End Function
    Public Function RunReport(ByVal eType As enumReport, ByVal lClientId As Long, ByVal lLocationId As Long,
            ByVal lAssessmentId As Long, ByVal JurisdictionList As List(Of Long), ByVal iTaxYear As Integer,
            ByVal ePropType As enumTable,
            ByVal lAssessorId As Long,
            ByVal iSuppressOriginalCost As Integer,
            ByVal bSendToPrinter As Boolean, ByVal sPDFFileName As String, ByVal sExportFolder As String,
            ByVal lFactorEntityId As Long, ByVal bPrintClientScheduleOnly As Boolean,
            ByVal eContactType As enumContactTypes, eBarCodeType As enumBarCodeTypes, ByVal bPrintCoverPage As Boolean, dtParm As DataTable,
            ByVal bJustCreatePDF As Boolean, ByVal bIncludeInactive As Boolean,
            ByVal lBusinessUnitId As Long, sStateCd As String) As Boolean

        Return RunReport(eType, lClientId, lLocationId, lAssessmentId, JurisdictionList, iTaxYear, ePropType, lAssessorId, iSuppressOriginalCost,
            bSendToPrinter, sPDFFileName, sExportFolder, lFactorEntityId, bPrintClientScheduleOnly, eContactType, eBarCodeType, bPrintCoverPage, dtParm, False,
            AppData.IncludeInactive, lBusinessUnitId, sStateCd, False, False, False)
    End Function
    Public Function RunReport(ByVal eType As enumReport, ByVal lClientId As Long, ByVal lLocationId As Long,
            ByVal lAssessmentId As Long, ByVal JurisdictionList As List(Of Long), ByVal iTaxYear As Integer,
            ByVal ePropType As enumTable,
            ByVal lAssessorId As Long,
            ByVal iSuppressOriginalCost As Integer,
            ByVal bSendToPrinter As Boolean, ByVal sPDFFileName As String, ByVal sExportFolder As String,
            ByVal lFactorEntityId As Long, ByVal bPrintClientScheduleOnly As Boolean,
            ByVal eContactType As enumContactTypes, eBarCodeType As enumBarCodeTypes, ByVal bPrintCoverPage As Boolean, dtParm As DataTable,
            ByVal bJustCreatePDF As Boolean, ByVal bIncludeInactive As Boolean,
            ByVal lBusinessUnitId As Long, sStateCd As String, ByVal bIncludeZeroAmounts As Boolean, ByVal bShowCostAndFactors As Boolean,
            ByVal bUpdateClientReporting As Boolean) As Boolean

        If AppData.ClientReportingServer = False Then MDIParent1.ShowStatus("Running report")

        Dim sSQL As String = "", sFactoringEntityNames(4) As String
        Dim dt As New DataTable, row As DataRow
        Dim sName As String = "", dFactoredAmt As Double, dOriginalAmt As Double, dFactor As Double
        Dim lFactoredAmtBeforeInterstateAllocationPct As Long, bHasInterstateAllocationPct As Boolean
        Dim iScheduleCounter As Integer, lRows As Long, sTitle As String
        Dim lRowCounter As Long, sFactorDescription As String
        Dim sReportText As String = "", sVIN As String, sFactorCode As String
        Dim sAssetExportFile As String = "", sAcctNum As String = ""
        Dim bPrintingClientValue As Boolean = False, dTaxDue As Double = 0
        Dim dtSavings As New DataTable
        Dim clsReport As clsReportData
        Dim sTempTable As String = ""
        Dim progresscounter As Long = 0, rowsinresults As Long = 0, resetcounter As Integer = 0
        Dim sql As New StringBuilder
        Dim bIncludeRow As Boolean = False, sDesc As String = ""
        Dim sProperty As New StringBuilder
        Dim LesseeInfo As New StringBuilder
        Dim citystate As New StringBuilder

        Try
            'need to incorporate batch printing into the print server
            'that means the stuff in frmreportselection.cmdRun_Click needs to be moved to runreport or similar so printserver can see it.
            'If bSendToPrinter And AppData.PrintServer = False Then
            '    Dim sqlinsertclause = New StringBuilder, sqlvaluesclause = New StringBuilder
            '    sqlinsertclause.Append("INSERT PrintQueue (ReportType,AddUser")
            '    sqlvaluesclause.Append(" VALUES (").Append(eType).Append(",").Append(QuoStr(AppData.UserId))
            '    If lClientId > 0 Then
            '        sqlinsertclause.Append(",ClientId")
            '        sqlvaluesclause.Append(",").Append(lClientId.ToString)
            '    End If
            '    If lLocationId > 0 Then
            '        sqlinsertclause.Append(",LocationId")
            '        sqlvaluesclause.Append(",").Append(lLocationId.ToString)
            '    End If
            '    If lAssessmentId > 0 Then
            '        sqlinsertclause.Append(",AssessmentId")
            '        sqlvaluesclause.Append(",").Append(lAssessmentId.ToString)
            '    End If
            '    If Not JurisdictionList Is Nothing Then
            '        If JurisdictionList.Count > 0 Then
            '            sqlinsertclause.Append(",JurisdictionList")
            '            Dim strlist As New StringBuilder
            '            For Each lId As Long In JurisdictionList
            '                If strlist.Length > 0 Then strlist.Append(",")
            '                strlist.Append(lId.ToString)
            '            Next
            '            sqlvaluesclause.Append(",").Append(QuoStr(strlist.ToString))
            '        End If
            '    End If
            '    If iTaxYear > 0 Then
            '        sqlinsertclause.Append(",TaxYear")
            '        sqlvaluesclause.Append(",").Append(iTaxYear.ToString)
            '    End If
            '    If ePropType = enumTable.enumLocationBPP Or ePropType = enumTable.enumLocationRE Then
            '        sqlinsertclause.Append(",PropType")
            '        sqlvaluesclause.Append(",").Append(IIf(ePropType = enumTable.enumLocationBPP, "'P'", "'R'"))
            '    End If
            '    If lAssessorId > 0 Then
            '        sqlinsertclause.Append(",AssessorId")
            '        sqlvaluesclause.Append(",").Append(lAssessorId.ToString)
            '    End If
            '    If iSuppressOriginalCost > 0 Then
            '        sqlinsertclause.Append(",SuppressOriginalCost")
            '        sqlvaluesclause.Append(",").Append("1")
            '    End If
            '    If lFactorEntityId > 0 Then
            '        sqlinsertclause.Append(",FactorEntityId")
            '        sqlvaluesclause.Append(",").Append(lFactorEntityId.ToString)
            '    End If
            '    If bPrintClientScheduleOnly Then
            '        sqlinsertclause.Append(",PrintClientScheduleOnly")
            '        sqlvaluesclause.Append(",").Append("1")
            '    End If
            '    sqlinsertclause.Append(",ContactType")
            '    sqlvaluesclause.Append(",").Append(eContactType)
            '    sqlinsertclause.Append(",BarCodeType")
            '    sqlvaluesclause.Append(",").Append(eBarCodeType)
            '    If bPrintCoverPage Then
            '        sqlinsertclause.Append(",PrintCoverPage")
            '        sqlvaluesclause.Append(",").Append("1")
            '    End If
            '    If bIncludeInactive Then
            '        sqlinsertclause.Append(",IncludeInactive")
            '        sqlvaluesclause.Append(",").Append("1")
            '    End If
            '    sqlinsertclause.Append(")")
            '    sqlvaluesclause.Append(")")
            '    ExecuteSQL(sqlinsertclause.ToString & sqlvaluesclause.ToString)
            '    MsgBox("Report sent to print server")
            '    Return True
            'End If

            If eType = enumReport.enumAssetDetail Then
                sReportText = "Asset Detail - Tax Year " & iTaxYear
            ElseIf eType = enumReport.enumAssetSummary Then
                sReportText = "Asset Summary - Tax Year " & iTaxYear
            ElseIf eType = enumReport.enumAssetDetailCost Then
                sReportText = "Asset Detail Cost - Tax Year " & iTaxYear
            ElseIf eType = enumReport.enumAssetDetailExempt Then
                sReportText = "Exempt Assets - Tax Year " & iTaxYear
            ElseIf eType = enumReport.enumAssetDetailNon Then
                sReportText = "Non-taxable Assets - Tax Year " & iTaxYear
            ElseIf eType = enumReport.enumAssetDetailLeasedProperty Or
                    eType = enumReport.enumAssetDetailLeaseholdImprovements Or
                    eType = enumReport.enumAssetDetailLeasesAll Then
                sReportText = "Leased Property - Tax Year " & iTaxYear
            ElseIf eType = enumReport.enumLeaseSummary Then
                sReportText = "Asset Summary - Leases - Tax Year " & iTaxYear
            ElseIf eType = enumReport.enumTaxBill Then
                sReportText = "Statement of Taxes Due"
            ElseIf eType = enumReport.enumBarCode Then
                sReportText = "Bar Code Page"
            ElseIf eType = enumReport.enumRenditionDueDate Then
                sReportText = "Rendition Due Dates"
            ElseIf eType = enumReport.enumCompletedRenditions Then
                sReportText = "Completed Renditions"
            ElseIf eType = enumReport.enumMissingNotice Then
                sReportText = "Missing Notices"
            ElseIf eType = enumReport.enumAssessorCover Then
                sReportText = "Assessor Cover"
            ElseIf eType = enumReport.enumMissingTaxBills Then
                sReportText = "Missing Tax Bills"
            ElseIf eType = enumReport.enumClientLocationListing Then
                sReportText = "Client Location Listing"
            ElseIf eType = enumReport.enumTaxBillCheckOff Then
                sReportText = "Tax Bill Check Off:  " & IIf(ePropType = enumTable.enumLocationBPP, "BPP", "Real")
            ElseIf eType = enumReport.enumClientEnvelope Or eType = enumReport.enumAssessorEnvelope Or eType = enumReport.enumAssessorValueProtestEnvelope Then
                sReportText = "Envelope"
            ElseIf eType = enumReport.enumFixedAssetReconByGLCode Or eType = enumReport.enumFixedAssetReconByDeprCode Then
                sReportText = "Fixed Asset Reconciliation"
            ElseIf eType = enumReport.enumTaxSavings Or eType = enumReport.enumTaxAccrual Or eType = enumReport.enumTaxAccrualSummary Then
                Select Case eType
                    Case enumReport.enumTaxSavings
                        sReportText = "Tax Savings"
                    Case enumReport.enumTaxAccrual
                        sReportText = "Tax Accrual"
                    Case enumReport.enumTaxAccrualSummary
                        sReportText = "Tax Accrual Summary"
                End Select
                If ePropType = enumTable.enumLocationBPP Then
                    sReportText = sReportText & " for BPP"
                ElseIf ePropType = enumTable.enumLocationRE Then
                    sReportText = sReportText & " for Real Estate"
                Else
                    sReportText = sReportText & " for all locations"
                End If
            ElseIf eType = enumReport.enumAppointmentOfAgentForm Then
                sReportText = "Appointment of Agent Detail"
            ElseIf eType = enumReport.enumREComp Then
                sReportText = "RE Comps"
            ElseIf eType = enumReport.enumBPPCompBarCode Then
                sReportText = "BPP Comps"
            ElseIf eType = enumReport.enumValueComparison Then
                sReportText = "Value Comparison - " & IIf(ePropType = enumTable.enumLocationBPP, "BPP", "Real Estate")
            End If
            sTitle = sReportText

            If eType = enumReport.enumTaxBill Or eType = enumReport.enumTaxBillCheckOff Then
                sSQL = BuildTaxBillQuery(lClientId, lLocationId, lAssessmentId, JurisdictionList, iTaxYear, ePropType, True, False, False, False, False, 0)
            ElseIf eType = enumReport.enumClientEnvelope Then
                Dim sContact As String = ""
                Select Case eContactType
                    Case enumContactTypes.enumContract
                        sContact = "Contract"
                    Case enumContactTypes.enumInformation
                        sContact = "Information"
                    Case enumContactTypes.enumInvoice
                        sContact = "Invoice"
                    Case enumContactTypes.enumMisc
                        sContact = "Misc"
                    Case enumContactTypes.enumTax
                        sContact = "Tax"
                End Select
                sSQL = "SELECT Name, ISNULL(Contact" & sContact & "Name,'') AS ContactName," &
                    " ISNULL(Contact" & sContact & "Address,'') AS ContactAddress," &
                    " RTRIM(ISNULL(Contact" & sContact & "City,'')) + ', ' + " &
                    " RTRIM(ISNULL(Contact" & sContact & "StateCd,'')) + '  ' + " &
                    " RTRIM(ISNULL(Contact" & sContact & "Zip,'')) AS ContactCityStZip," &
                    " ISNULL(Contact" & sContact & "Phone,'') AS ContactPhone,"
                sSQL = sSQL &
                    QuoStr(AppData.FirmAddress) & " AS FirmAddress, " & QuoStr(AppData.FirmName) & " AS FirmName," &
                    QuoStr(AppData.FirmCity & ", " & AppData.FirmStateCd & "  " & AppData.FirmZip) & " AS FirmCityStZip," &
                    QuoStr(AppData.FirmPhone) & " AS FirmPhone " &
                    " FROM Clients WHERE ClientId = " & lClientId
            ElseIf eType = enumReport.enumAssessorEnvelope Or eType = enumReport.enumAssessorValueProtestEnvelope Then
                sSQL = "SELECT Name, ISNULL(Address1,'') AS Address," &
                    " RTRIM(ISNULL(City,'')) + ', ' + RTRIM(ISNULL(StateCd,'')) + '  ' + RTRIM(ISNULL(Zip,'')) AS CityStZip," &
                    QuoStr(AppData.FirmAddress) & " AS FirmAddress, " & QuoStr(AppData.FirmName) & " AS FirmName," &
                    QuoStr(AppData.FirmCity & ", " & AppData.FirmStateCd & "  " & AppData.FirmZip) & " AS FirmCityStZip," &
                    QuoStr(AppData.FirmPhone) & " AS FirmPhone,"
                sSQL = sSQL & "LTRIM(RTRIM(ISNULL(ValueProtestAddress,ISNULL(Address1,'')))) AS ValueProtestAddress," &
                    " LTRIM(RTRIM(ISNULL(ValueProtestCity,ISNULL(City,'')))) + ', ' + LTRIM(RTRIM(ISNULL(ValueProtestStateCd,ISNULL(StateCd,'')))) + '  ' + " &
                    "LTRIM(RTRIM(ISNULL(ValueProtestZip,ISNULL(Zip,'')))) AS ValueProtestCityStZip" &
                    " FROM Assessors WHERE AssessorId = " & lAssessorId & " AND TaxYear = " & iTaxYear
            ElseIf eType = enumReport.enumRenditionDueDate Or eType = enumReport.enumCompletedRenditions Then
                sSQL = "SELECT  asr.RenditionDueDate, ISNULL(l.LegalOwner, c.Name) AS Clients_Name," &
                    " ISNULL(l.Address,'') AS Address, ISNULL(l.City,'') AS City, l.StateCd, ISNULL(l.Zip,'') AS Zip," &
                    " ISNULL(a.AcctNum,'') AS AcctNum," &
                    " ISNULL(asr.Name,'') + ', ' + ISNULL(asr.StateCd,'') + '  ' + ISNULL(asr.Phone,'') AS Assessors_Name," &
                    " ISNULL(l.ConsultantName,ISNULL(c.BPPConsultantName,'NONE')) AS Clients_ConsultantName, a.RenditionCompleteDate"
                If eType = enumReport.enumCompletedRenditions Then
                    sSQL = sSQL & ", ISNULL(abc.Comment,'') AS Comment, ISNULL(abc.ChangeDate,abc.AddDate) AS ChangeDate"
                End If
                sSQL = sSQL &
                    " FROM Assessors AS asr RIGHT OUTER JOIN" &
                    " AssessmentsBPP AS a INNER JOIN" &
                    " Clients AS c INNER JOIN" &
                    " LocationsBPP AS l" &
                    " ON c.ClientId = l.ClientId ON a.ClientId = l.ClientId AND a.LocationId = l.LocationId AND a.TaxYear = l.TaxYear" &
                    " ON asr.AssessorId = a.AssessorId And asr.TaxYear = a.TaxYear"
                If eType = enumReport.enumCompletedRenditions Then
                    sSQL = sSQL & " LEFT OUTER JOIN AssessmentsBPPComments abc" &
                        " ON a.ClientId = abc.ClientId AND a.LocationId = abc.LocationId AND a.AssessmentId = abc.AssessmentId AND a.TaxYear = abc.TaxYear" &
                        " AND abc.CommentType = 1"
                End If
                sSQL = sSQL &
                    " WHERE l.TaxYear = " & iTaxYear
                If eType = enumReport.enumCompletedRenditions Then
                    sSQL = sSQL & " AND a.RenditionCompleteDate IS NOT NULL"
                End If
                sSQL = sSQL & " AND ISNULL(c.ProspectFl,0) = 0 "
                If bIncludeInactive = False Then
                    sSQL = sSQL & " AND ISNULL(c.InactiveFl,0) = 0 AND ISNULL(l.InactiveFl,0) = 0 AND ISNULL(a.InactiveFl,0) = 0 "
                End If
            ElseIf eType = enumReport.enumClientLocationListing Then
                sSQL = "SELECT c.Name AS Clients_Name, ISNULL(l.Address,'') AS Locations_Address," &
                    " ISNULL(l.City,'') AS Locations_City," &
                    " ISNULL(l.StateCd,'') AS Locations_StateCd," &
                    " ISNULL(l.Zip,'') AS Locations_Zip," &
                    " ISNULL(l.ClientLocationId,'') AS Locations_ClientLocationId," &
                    " ISNULL(l.LegalOwner,'') AS Locations_LegalOwner, 'BPP' AS Type," &
                    " ISNULL(a.AcctNum,'') AS Assessments_AcctNum" &
                    " FROM AssessmentsBPP AS a" &
                    " RIGHT OUTER JOIN LocationsBPP AS l ON a.ClientId = l.ClientId AND a.LocationId = l.LocationId AND a.TaxYear = l.TaxYear" &
                    " INNER JOIN Clients AS c ON l.ClientId = c.ClientId"
                sSQL = sSQL & " WHERE ISNULL(c.ProspectFl,0) = 0 AND l.TaxYear = " & iTaxYear
                If bIncludeInactive = False Then
                    sSQL = sSQL & " AND ISNULL(c.InactiveFl,0) = 0 AND ISNULL(l.InactiveFl,0) = 0 AND ISNULL(a.InactiveFl,0) = 0"
                End If
                If lClientId > 0 Then sSQL = sSQL & " AND c.ClientId = " & lClientId
                sSQL = sSQL & " UNION SELECT c.Name AS Clients_Name, ISNULL(l.Address,'') AS Locations_Address," &
                    " ISNULL(l.City,'') AS Locations_City," &
                    " ISNULL(l.StateCd,'') AS Locations_StateCd," &
                    " ISNULL(l.Zip,'') AS Locations_Zip," &
                    " ISNULL(l.ClientLocationId,'') AS Locations_ClientLocationId," &
                    " ISNULL(l.LegalOwner,'') AS Locations_LegalOwner, 'Real' AS Type," &
                    " ISNULL(a.AcctNum,'') AS Assessments_AcctNum" &
                    " FROM AssessmentsRE AS a" &
                    " RIGHT OUTER JOIN LocationsRE AS l ON a.ClientId = l.ClientId AND a.LocationId = l.LocationId AND a.TaxYear = l.TaxYear" &
                    " INNER JOIN Clients AS c ON l.ClientId = c.ClientId"
                sSQL = sSQL & " WHERE ISNULL(c.ProspectFl,0) = 0 AND l.TaxYear = " & iTaxYear
                If bIncludeInactive = False Then
                    sSQL = sSQL & " AND ISNULL(c.InactiveFl,0) = 0 AND ISNULL(l.InactiveFl,0) = 0 AND ISNULL(a.InactiveFl,0) = 0"
                End If
                If lClientId > 0 Then sSQL = sSQL & " AND c.ClientId = " & lClientId
            ElseIf eType = enumReport.enumMissingTaxBills Then
                sSQL = "SELECT 'BPP' AS PropType, ISNULL(l.LegalOwner, c.Name) AS Clients_Name, ISNULL(l.Address,'') AS Address," &
                    " ISNULL(l.City,'') AS City, l.StateCd, ISNULL(l.Zip,'') AS Zip, ISNULL(a.AcctNum,'') AS AcctNum, col.BPPDueDate1 AS DueDate," &
                    " j.Name AS Jurisdictions_Name, ISNULL(col.Name,'') + ', ' + ISNULL(col.StateCd,'') + '  ' + ISNULL(col.Phone, '') AS Collectors_Name," &
                    " ISNULL(l.ConsultantName, ISNULL(c.BPPConsultantName,'NONE')) AS Clients_ConsultantName" &
                    " FROM AssessmentDetailBPP AS ad INNER JOIN" &
                    " Jurisdictions AS j ON ad.JurisdictionId = j.JurisdictionId AND ad.TaxYear = j.TaxYear INNER JOIN" &
                    " AssessmentsBPP AS a INNER JOIN" &
                    " Clients AS c INNER JOIN" &
                    " LocationsBPP AS l ON c.ClientId = l.ClientId ON a.ClientId = l.ClientId AND a.LocationId = l.LocationId" &
                    " AND a.TaxYear = l.TaxYear ON ad.ClientId = a.ClientId" &
                    " AND ad.LocationId = a.LocationId AND ad.AssessmentId = a.AssessmentId AND ad.TaxYear = a.TaxYear LEFT OUTER JOIN" &
                    " Collectors AS col ON j.CollectorId = col.CollectorId AND j.TaxYear = col.TaxYear" &
                    " WHERE ad.TaxBillPrintedDate IS NULL AND l.TaxYear = " & iTaxYear
                sSQL = sSQL & " AND ISNULL(c.ProspectFl,0) = 0 "
                If bIncludeInactive = False Then
                    sSQL = sSQL & " AND ISNULL(c.InactiveFl,0) = 0 AND ISNULL(l.InactiveFl,0) = 0 AND ISNULL(a.InactiveFl,0) = 0 "
                End If
                sSQL = sSQL & " UNION SELECT 'Real' AS PropType, ISNULL(l.LegalOwner, c.Name) AS Clients_Name, ISNULL(l.Address,'') AS Address," &
                    " ISNULL(l.City,'') AS City, l.StateCd," &
                    " ISNULL(l.Zip,'') AS Zip, ISNULL(a.AcctNum,'') AS AcctNum, col.REDueDate1 AS DueDate," &
                    " j.Name AS Jurisdictions_Name, ISNULL(col.Name,'') + ', ' + ISNULL(col.StateCd,'') + '  ' + ISNULL(col.Phone, '') AS Collectors_Name," &
                    " ISNULL(l.ConsultantName,ISNULL(c.REConsultantName,'NONE')) AS Clients_ConsultantName" &
                    " FROM AssessmentDetailRE AS ad INNER JOIN" &
                    " Jurisdictions AS j ON ad.JurisdictionId = j.JurisdictionId AND ad.TaxYear = j.TaxYear INNER JOIN" &
                    " AssessmentsRE AS a INNER JOIN" &
                    " Clients AS c INNER JOIN" &
                    " LocationsRE AS l ON c.ClientId = l.ClientId ON a.ClientId = l.ClientId AND a.LocationId = l.LocationId" &
                    " AND a.TaxYear = l.TaxYear ON ad.ClientId = a.ClientId" &
                    " AND ad.LocationId = a.LocationId AND ad.AssessmentId = a.AssessmentId AND ad.TaxYear = a.TaxYear LEFT OUTER JOIN" &
                    " Collectors AS col ON j.CollectorId = col.CollectorId AND j.TaxYear = col.TaxYear" &
                    " WHERE ad.TaxBillPrintedDate IS NULL AND l.TaxYear = " & iTaxYear
                sSQL = sSQL & " AND ISNULL(c.ProspectFl,0) = 0 "
                If bIncludeInactive = False Then
                    sSQL = sSQL & " AND ISNULL(c.InactiveFl,0) = 0 AND ISNULL(l.InactiveFl,0) = 0 AND ISNULL(a.InactiveFl,0) = 0 "
                End If
                sSQL = sSQL & " UNION SELECT 'BPP' AS PropType, ISNULL(l.LegalOwner, c.Name) AS Clients_Name, ISNULL(l.Address, '') AS Address," &
                    " ISNULL(l.City, '') AS City, l.StateCd," &
                    " ISNULL(l.Zip, '') AS Zip, ISNULL(a.AcctNum, '') AS AcctNum, i.PayToDt AS DueDate," &
                    " j.Name AS Jurisdictions_Name, ISNULL(col.Name, '') + ', ' + ISNULL(col.StateCd, '') + '  ' + ISNULL(col.Phone, '') AS Collectors_Name," &
                    " ISNULL(l.ConsultantName,ISNULL(c.BPPConsultantName,'NONE')) AS Clients_ConsultantName" &
                    " FROM AssessmentDetailBPP AS ad INNER JOIN" &
                    " Jurisdictions AS j ON ad.JurisdictionId = j.JurisdictionId AND ad.TaxYear = j.TaxYear INNER JOIN" &
                    " AssessmentsBPP AS a INNER JOIN" &
                    " Clients AS c INNER JOIN" &
                    " LocationsBPP AS l ON c.ClientId = l.ClientId ON a.ClientId = l.ClientId AND a.LocationId = l.LocationId" &
                    " AND a.TaxYear = l.TaxYear ON ad.ClientId = a.ClientId" &
                    " AND ad.LocationId = a.LocationId And ad.AssessmentId = a.AssessmentId And ad.TaxYear = a.TaxYear INNER JOIN" &
                    " InstallmentsBPP AS i ON a.ClientId = i.ClientId AND a.LocationId = i.LocationId AND a.AssessmentId = i.AssessmentId AND a.TaxYear = i.TaxYear" &
                    " INNER JOIN Collectors AS col ON i.CollectorId = col.CollectorId And i.TaxYear = col.TaxYear" &
                    " WHERE ISNULL(c.ProspectFl, 0) = 0 AND  i.PaidDt Is NULL"
                If bIncludeInactive = False Then
                    sSQL = sSQL & " AND ISNULL(c.InactiveFl,0) = 0 AND ISNULL(l.InactiveFl,0) = 0 AND ISNULL(a.InactiveFl,0) = 0 "
                End If

                sSQL = sSQL & " UNION SELECT 'Real' AS PropType, ISNULL(l.LegalOwner, c.Name) AS Clients_Name, ISNULL(l.Address, '') AS Address," &
                    " ISNULL(l.City, '') AS City, l.StateCd," &
                    " ISNULL(l.Zip, '') AS Zip, ISNULL(a.AcctNum, '') AS AcctNum, i.PayToDt AS DueDate," &
                    " j.Name AS Jurisdictions_Name, ISNULL(col.Name, '') + ', ' + ISNULL(col.StateCd, '') + '  ' + ISNULL(col.Phone, '') AS Collectors_Name," &
                    " ISNULL(l.ConsultantName,ISNULL(c.REConsultantName,'NONE')) AS Clients_ConsultantName" &
                    " FROM AssessmentDetailRE AS ad INNER JOIN" &
                    " Jurisdictions AS j ON ad.JurisdictionId = j.JurisdictionId AND ad.TaxYear = j.TaxYear INNER JOIN" &
                    " AssessmentsRE AS a INNER JOIN" &
                    " Clients AS c INNER JOIN" &
                    " LocationsRE AS l ON c.ClientId = l.ClientId ON a.ClientId = l.ClientId AND a.LocationId = l.LocationId" &
                    " AND a.TaxYear = l.TaxYear ON ad.ClientId = a.ClientId" &
                    " AND ad.LocationId = a.LocationId And ad.AssessmentId = a.AssessmentId And ad.TaxYear = a.TaxYear INNER JOIN" &
                    " InstallmentsRE AS i ON a.ClientId = i.ClientId AND a.LocationId = i.LocationId AND a.AssessmentId = i.AssessmentId AND a.TaxYear = i.TaxYear" &
                    " INNER JOIN Collectors AS col ON i.CollectorId = col.CollectorId And i.TaxYear = col.TaxYear" &
                    " WHERE ISNULL(c.ProspectFl, 0) = 0 AND  i.PaidDt Is NULL"
                If bIncludeInactive = False Then
                    sSQL = sSQL & " AND ISNULL(c.InactiveFl,0) = 0 AND ISNULL(l.InactiveFl,0) = 0 AND ISNULL(a.InactiveFl,0) = 0 "
                End If

            ElseIf eType = enumReport.enumAssessorCover Then
                sSQL = "Select RTRIM(LTRIM(Name)) As Name, RTRIM(LTRIM(ISNULL(Address1,''))) AS Address," &
                    " (RTRIM(LTRIM(ISNULL(City,''))) + ', ' + RTRIM(LTRIM(StateCd)) + '  ' + RTRIM(LTRIM(ISNULL(Zip,'')))) AS City," &
                    " RTRIM(LTRIM(ISNULL(Phone,''))) AS Phone, AssessorId," &
                    QuoStr(AppData.FirmAddress) & " AS FirmAddress, " & QuoStr(AppData.FirmName) & " AS FirmName," &
                    QuoStr(AppData.FirmCity & ", " & AppData.FirmStateCd & "  " & AppData.FirmZip) & " AS FirmCityStZip" & "," &
                    QuoStr(AppData.FirmPhone) & " AS FirmPhone " &
                    " FROM Assessors WHERE AssessorId = " & lAssessorId & " AND TaxYear = " & iTaxYear
            ElseIf eType = enumReport.enumMissingNotice Then
                sSQL = "SELECT 'BPP' AS PropType, ISNULL(l.LegalOwner, c.Name) AS Clients_Name, ISNULL(l.Address,'') AS Address," &
                    " ISNULL(l.City,'') AS City, l.StateCd, ISNULL(l.Zip,'') AS Zip," &
                    " ISNULL(a.AcctNum,'') AS AcctNum, asr.BPPNoticeDate AS NoticeDate," &
                    " ISNULL(l.ConsultantName,ISNULL(c.BPPConsultantName,'NONE')) AS Clients_ConsultantName," &
                    " ISNULL(asr.Name,'') + ', ' + ISNULL(asr.StateCd,'') + '  ' + ISNULL(asr.Phone,'') AS Assessors_Name" &
                    " FROM AssessmentDetailBPP AS ad INNER JOIN" &
                    " AssessmentsBPP AS a INNER JOIN" &
                    " Clients AS c INNER JOIN" &
                    " LocationsBPP AS l ON c.ClientId = l.ClientId ON a.ClientId = l.ClientId AND a.LocationId = l.LocationId" &
                    " AND a.TaxYear = l.TaxYear ON ad.ClientId = a.ClientId" &
                    " AND ad.LocationId = a.LocationId AND ad.AssessmentId = a.AssessmentId AND ad.TaxYear = a.TaxYear LEFT OUTER JOIN" &
                    " Assessors AS asr ON a.AssessorId = asr.AssessorId AND a.TaxYear = asr.TaxYear" &
                    " WHERE l.TaxYear = " & iTaxYear & " And ISNULL(ad.NotifiedValue, 0) = 0"
                sSQL = sSQL & " AND ISNULL(c.ProspectFl,0) = 0 "
                If bIncludeInactive = False Then
                    sSQL = sSQL & " AND ISNULL(c.InactiveFl,0) = 0 AND ISNULL(l.InactiveFl,0) = 0 AND ISNULL(a.InactiveFl,0) = 0 "
                End If
                sSQL = sSQL & " GROUP BY ISNULL(l.LegalOwner, c.Name), ISNULL(l.Address,''), ISNULL(l.City,''), l.StateCd, ISNULL(l.Zip,''), ISNULL(a.AcctNum,''), asr.BPPNoticeDate," &
                    " ISNULL(asr.Name,'') + ', ' + ISNULL(asr.StateCd,'') + '  ' + ISNULL(asr.Phone,'')," &
                     " ISNULL(l.ConsultantName,ISNULL(c.BPPConsultantName,'NONE'))"
                sSQL = sSQL & " UNION SELECT 'Real' AS PropType, ISNULL(l.LegalOwner, c.Name) AS Clients_Name, ISNULL(l.Address,'') AS Address, ISNULL(l.City,'') AS City, l.StateCd, ISNULL(l.Zip,'') AS Zip," &
                    " ISNULL(a.AcctNum,'') AS AcctNum, asr.RENoticeDate AS NoticeDate," &
                    " ISNULL(l.ConsultantName,ISNULL(c.REConsultantName,'NONE')) AS Clients_ConsultantName," &
                    " ISNULL(asr.Name,'') + ', ' + ISNULL(asr.StateCd,'') + '  ' + ISNULL(asr.Phone, '') AS Assessors_Name" &
                    " FROM AssessmentDetailRE AS ad INNER JOIN" &
                    " AssessmentsRE AS a INNER JOIN" &
                    " Clients AS c INNER JOIN" &
                    " LocationsRE AS l ON c.ClientId = l.ClientId ON a.ClientId = l.ClientId AND a.LocationId = l.LocationId" &
                    " AND a.TaxYear = l.TaxYear ON ad.ClientId = a.ClientId" &
                    " AND ad.LocationId = a.LocationId AND ad.AssessmentId = a.AssessmentId AND ad.TaxYear = a.TaxYear LEFT OUTER JOIN" &
                    " Assessors AS asr ON a.AssessorId = asr.AssessorId AND a.TaxYear = asr.TaxYear" &
                    " WHERE l.TaxYear = " & iTaxYear & " AND ISNULL(ad.RELandValue, 0) + ISNULL(ad.REImprovementValue, 0) = 0"
                sSQL = sSQL & " AND ISNULL(c.ProspectFl,0) = 0 "
                If bIncludeInactive = False Then
                    sSQL = sSQL & " AND ISNULL(c.InactiveFl,0) = 0 AND ISNULL(l.InactiveFl,0) = 0 AND ISNULL(a.InactiveFl,0) = 0 "
                End If
                sSQL = sSQL & " GROUP BY ISNULL(l.LegalOwner, c.Name), ISNULL(l.Address,''), ISNULL(l.City,''), l.StateCd, ISNULL(l.Zip,''), ISNULL(a.AcctNum,''), asr.RENoticeDate," &
                    " ISNULL(asr.Name,'') + ', ' + ISNULL(asr.StateCd,'') + '  ' + ISNULL(asr.Phone,'')," &
                    " ISNULL(l.ConsultantName,ISNULL(c.REConsultantName,'NONE'))"
            ElseIf eType = enumReport.enumFixedAssetReconByGLCode Then
                sSQL = BuildAssetReconciliationQuery(lClientId, lLocationId, lAssessmentId, iTaxYear, True, "")
            ElseIf eType = enumReport.enumFixedAssetReconByDeprCode Then
                sSQL = BuildAssetReconciliationQueryByDeprCode(lClientId, lLocationId, lAssessmentId, iTaxYear)
            ElseIf eType = enumReport.enumValueComparison Then
                sSQL = BuildRenditionValueComparisonQuery(lClientId, iTaxYear, ePropType, lBusinessUnitId, sStateCd, lAssessorId)
            ElseIf eType = enumReport.enumTaxSavings Then
                Dim dtAssessments As New DataTable, rowAssessments As DataRow, lClientRenditionTotal As Long
                Dim dtAssets As New DataTable
                Dim rowTaxBills As DataRow
                Dim dtTaxBills = New DataTable

                If ePropType = enumTable.enumLocationBPP Or ePropType = enumTable.enumUnknown Then
                    'Get BPP assessments
                    sSQL = "SELECT a.ClientId, a.LocationId, a.AssessmentId, a.FactorEntityId1" &
                        " FROM Clients AS c" &
                        " INNER JOIN LocationsBPP AS l ON c.ClientId = l.ClientId" &
                        " INNER JOIN AssessmentsBPP AS a ON l.ClientId = a.ClientId AND l.LocationId = a.LocationId AND l.TaxYear = a.TaxYear" &
                        " WHERE a.TaxYear = " & iTaxYear
                    If lClientId <> 0 Then sSQL = sSQL & " AND a.ClientId = " & lClientId
                    If lLocationId <> 0 Then sSQL = sSQL & " AND a.LocationId = " & lLocationId
                    If lAssessmentId <> 0 Then sSQL = sSQL & " AND a.AssessmentId = " & lAssessmentId
                    If lBusinessUnitId <> 0 Then sSQL = sSQL & " AND a.BusinessUnitId = " & lBusinessUnitId
                    sSQL = sSQL & " AND ISNULL(c.ProspectFl,0) = 0 "
                    If bIncludeInactive = False Then
                        sSQL = sSQL & " AND ISNULL(c.InactiveFl,0) = 0 AND ISNULL(l.InactiveFl,0) = 0 AND ISNULL(a.InactiveFl,0) = 0 "
                    End If
                    If sStateCd.Trim <> "" Then sSQL = sSQL & " AND l.StateCd = " & QuoStr(sStateCd)
                    rowsinresults = GetData(sSQL, dtAssessments)
                    progresscounter = 0 : resetcounter = 0
                    'For each BPP assessment, sum up Client Factored Amount
                    For Each rowAssessments In dtAssessments.Rows
                        lClientRenditionTotal = 0
                        If IsDBNull(rowAssessments("FactorEntityId1")) Then
                            lClientRenditionTotal = 0
                        Else
                            Dim dsassets As DataSet = GetAssetList(rowAssessments("ClientId"), rowAssessments("LocationId"), rowAssessments("AssessmentId"), AppData.TaxYear, 0, True, False, True, False, False, False)
                            lClientRenditionTotal = dsassets.Tables("ReturnTypeSumOfValues").Rows(0)("SumOfClientValue1")
                        End If
                        'for each BPP assessment, get tax bill amounts with savings
                        'and add to results table dtSavings
                        sSQL = BuildTaxBillQuery(rowAssessments("ClientId"), rowAssessments("LocationId"),
                            rowAssessments("AssessmentId"), JurisdictionList, iTaxYear, enumTable.enumLocationBPP,
                            False, False, False, False, True, lClientRenditionTotal)
                        GetData(sSQL, dtTaxBills)
                        If dtSavings.Columns.Count = 0 Then dtSavings = dtTaxBills.Clone
                        For Each rowTaxBills In dtTaxBills.Rows
                            dtSavings.ImportRow(rowTaxBills)
                        Next

                        progresscounter = progresscounter + 1
                        resetcounter = resetcounter + 1
                        If resetcounter > 10 Then
                            MDIParent1.ShowStatus("Running report, " & Format(progresscounter / rowsinresults, csPct) & " complete")
                            resetcounter = 0
                        End If

                    Next
                End If

                If ePropType = enumTable.enumLocationRE Or ePropType = enumTable.enumUnknown Then
                    'Run RE tax savings once since don't have rendition for RE
                    'and add to dtSavingsTemp results table
                    sSQL = BuildTaxBillQuery(lClientId, lLocationId, lAssessmentId, JurisdictionList, iTaxYear, enumTable.enumLocationRE, False, False, False, False, True, 0,
                        lBusinessUnitId, sStateCd)
                    GetData(sSQL, dtTaxBills)
                    If dtSavings.Columns.Count = 0 Then dtSavings = dtTaxBills.Clone
                    For Each rowTaxBills In dtTaxBills.Rows
                        dtSavings.ImportRow(rowTaxBills)
                    Next
                End If
            ElseIf eType = enumReport.enumTaxAccrual Or eType = enumReport.enumTaxAccrualSummary Then
                sTempTable = ""
                Do
                    sTempTable = "#tmpAccrual" & AppData.UserId & Date.Now.Ticks.ToString
                    'sTempTable = "tempdb..accrualtmp"
                    sSQL = "SELECT 1 WHERE EXISTS (SELECT Name FROM sys.objects where name LIKE '%" & sTempTable & "%')"
                    lRows = GetData(sSQL, dt)
                    If lRows = 0 Then Exit Do
                Loop

                Dim stmp = New StringBuilder
                'SAME TEMP TABLE IN RUNTAXACCRUALSUMMARY FUNCTION CHECK THERE FOR CHANGES
                stmp.Append("CREATE TABLE ").Append(sTempTable).Append(" (PropertyType varchar(3), ClientId bigint, LocationId bigint, AssessmentId bigint,")
                stmp.Append("JurisdictionId bigint, TaxYear smallint,")
                stmp.Append("Clients_Name varchar(255) null, Locations_Address varchar(50) null, Locations_City varchar(50) null, Locations_StateCd varchar(2),")
                stmp.Append("Locations_ClientLocationId varchar(255) null, Assessments_AcctNum varchar(50) null, Clients_ExcludeNotified bit null,")
                stmp.Append("Clients_ExcludeClient bit null, Assessments_SavingsExclusionCd bit null,")
                stmp.Append("Assessors_Name varchar(255) null, Assessors_Ratio float null, ClientRenditionValue float null,")
                stmp.Append("Jurisdictions_Name varchar(255) null, TaxRate float null, FinalValue float null, CYFinalValue float null, AbatementReductionAmt float null,")
                stmp.Append("ClientAbatementAmt float null,")
                stmp.Append("FreeportReductionAmt float null, ClientFreeportAmt float null, NotifiedValue float null, SumOfFactoredAmount float null,")
                stmp.Append("BusinessUnits_Name varchar(255) null, TaxDueDate datetime null")
                stmp.Append(")")
                ExecuteSQL(stmp.ToString)
                stmp.Length = 0

                Dim dtAccrualBPPAccounts As New DataTable, rowAccrual As DataRow, iAccrualCounter As Integer = 0
                sSQL = ""
                If ePropType = enumTable.enumLocationBPP Or ePropType = enumTable.enumUnknown Then
                    'get all bpp assessment records to build bpp part of accrual query
                    sSQL = "SELECT a.ClientId, a.LocationId, a.AssessmentId, a.FactorEntityId1, c.Name AS Clients_Name," &
                        " ISNULL(l.Address,'') AS Locations_Address," &
                        " ISNULL(l.City,'') AS Locations_City, l.StateCd AS Locations_StateCd, ISNULL(l.ClientLocationId,'') AS Locations_ClientLocationId," &
                        " ISNULL(a.AcctNum,'') AS Assessments_AcctNum," &
                        " ISNULL(c.ExcludeNotified,0) AS Clients_ExcludeNotified," &
                        " ISNULL(c.ExcludeClient,0) AS Clients_ExcludeClient," &
                        " ISNULL(a.SavingsExclusionCd,0) AS Assessments_SavingsExclusionCd," &
                        " ISNULL(ass.Name,'') AS Assessors_Name, CONVERT(float,ISNULL(ass.BPPRatio,0)) AS Assessors_BPPRatio," &
                        " CONVERT(float,ISNULL(a.ClientRenditionValue,0)) AS ClientRenditionValue, ISNULL(a.BusinessUnitId,0) AS BusinessUnitId" &
                        " FROM Clients AS c" &
                        " INNER JOIN LocationsBPP AS l ON c.ClientId = l.ClientId" &
                        " INNER JOIN AssessmentsBPP AS a ON l.ClientId = a.ClientId AND l.LocationId = a.LocationId AND l.TaxYear = a.TaxYear" &
                        " LEFT OUTER JOIN Assessors AS ass ON a.AssessorId = ass.AssessorId AND a.TaxYear = ass.TaxYear" &
                        " WHERE a.TaxYear = " & iTaxYear
                    If lClientId <> 0 Then sSQL = sSQL & " AND a.ClientId = " & lClientId
                    If lLocationId <> 0 Then sSQL = sSQL & " AND a.LocationId = " & lLocationId
                    If lAssessmentId <> 0 Then sSQL = sSQL & " AND a.AssessmentId = " & lAssessmentId
                    If lBusinessUnitId <> 0 Then sSQL = sSQL & " AND a.BusinessUnitId = " & lBusinessUnitId
                    If sStateCd.Trim <> "" Then sSQL = sSQL & " AND l.StateCd = " & QuoStr(sStateCd)
                    sSQL = sSQL & " AND ISNULL(c.ProspectFl,0) = 0 "
                    If bIncludeInactive = False Then
                        sSQL = sSQL & " AND ISNULL(c.InactiveFl,0) = 0 AND ISNULL(l.InactiveFl,0) = 0 AND ISNULL(a.InactiveFl,0) = 0 "
                    End If
                    GetData(sSQL, dtAccrualBPPAccounts)
                End If
                sSQL = ""
                If ePropType = enumTable.enumLocationRE Or ePropType = enumTable.enumUnknown Then
                    sSQL = "INSERT INTO " & sTempTable & " "
                    'get Real property part of accrual (may or may not be all clients) last years value
                    sSQL = sSQL & " SELECT 'RE' as PropertyType," &
                        " a.ClientId, a.LocationId, a.AssessmentId, j.JurisdictionId, CONVERT(smallint,a.TaxYear) AS TaxYear,  c.Name as Clients_Name," &
                        " l.Address as Locations_Address, l.City as Locations_City, l.StateCd as Locations_StateCd," &
                        " ISNULL(l.ClientLocationId,'') AS Locations_ClientLocationId, a.AcctNum as Assessments_AcctNum," &
                        " ISNULL(c.ExcludeNotified,0) AS Clients_ExcludeNotified," &
                        " ISNULL(c.ExcludeClient,0) AS Clients_ExcludeClient," &
                        " ISNULL(a.SavingsExclusionCd,0) AS Assessments_SavingsExclusionCd," &
                        " ass.Name as Assessors_Name," &
                        " CONVERT(float,ISNULL(ass.RERatio,0)) AS Assessors_Ratio," &
                        " CONVERT(float,0) as ClientRenditionValue, j.Name as Jurisdictions_Name, j.TaxRate,"

                    sSQL = sSQL & "CONVERT(float,ISNULL( ISNULL(ad.FinalValue, ISNULL( CASE WHEN (ISNULL(ad.REImprovementValue,0) + ISNULL(ad.RELandValue,0)) = 0 THEN NULL" &
                        " ELSE (ISNULL(ad.REImprovementValue,0) + ISNULL(ad.RELandValue,0)) END, (SELECT MAX(ad2.FinalValue)"

                    sSQL = sSQL &
                        " FROM AssessmentDetailRE ad2" &
                        " WHERE ad2.ClientId = a.ClientId" &
                        " AND ad2.LocationId = a.LocationId AND ad2.AssessmentId = a.AssessmentId " &
                        " AND ad2.TaxYear = " & iTaxYear - 1 & "))),0)) AS FinalValue,"
                    sSQL = sSQL & "ISNULL(ad.FinalValue,0) AS CYFinalValue,"
                    sSQL = sSQL & " CONVERT(float,ISNULL(ISNULL(ad.AbatementReductionAmt,(SELECT ad2.AbatementReductionAmt" &
                        " FROM AssessmentDetailRE ad2 WHERE ad2.ClientId = ad.ClientId" &
                        " AND ad2.LocationId = ad.LocationId AND ad2.AssessmentId = ad.AssessmentId" &
                        " AND ad2.JurisdictionId = ad.JurisdictionId AND ad2.TaxYear = " & iTaxYear - 1 & ")),0)) AS AbatementReductionAmt,"
                    sSQL = sSQL & " CONVERT(float,ISNULL(ISNULL(ad.ClientAbatementAmt,(SELECT ad2.ClientAbatementAmt" &
                        " FROM AssessmentDetailRE ad2 WHERE ad2.ClientId = ad.ClientId" &
                        " AND ad2.LocationId = ad.LocationId AND ad2.AssessmentId = ad.AssessmentId" &
                        " AND ad2.JurisdictionId = ad.JurisdictionId AND ad2.TaxYear = " & iTaxYear - 1 & ")),0)) AS ClientAbatementAmt,"
                    sSQL = sSQL & " CONVERT(float,0) AS FreeportReductionAmt, CONVERT(float,0) AS ClientFreeportAmt," &
                        " CONVERT(float,ISNULL(CASE WHEN (ISNULL(ad.REImprovementValue,0) + ISNULL(ad.RELandValue,0)) = 0 THEN NULL" &
                        " ELSE (ISNULL(ad.REImprovementValue,0) + ISNULL(ad.RELandValue,0)) END,0)) AS NotifiedValue, CONVERT(float,0) AS SumOfFactoredAmount,"
                    sSQL = sSQL & " ISNULL(bu.Name,'') AS BusinessUnits_Name, ISNULL(collect.REDueDate1,'1/1/1900') AS TaxDueDate"

                    sSQL = sSQL &
                        " FROM Clients AS c" &
                        " INNER JOIN LocationsRE AS l ON c.ClientId = l.ClientId" &
                        " INNER JOIN AssessmentsRE AS a ON l.ClientId = a.ClientId AND l.LocationId = a.LocationId AND l.TaxYear = a.TaxYear" &
                        " INNER JOIN AssessmentDetailRE AS ad ON a.ClientId = ad.ClientId AND a.LocationId = ad.LocationId" &
                        " AND a.AssessmentId = ad.AssessmentId AND a.TaxYear = ad.TaxYear" &
                        " LEFT OUTER JOIN Jurisdictions AS j ON ad.JurisdictionId = j.JurisdictionId AND ad.TaxYear = j.TaxYear" &
                        " LEFT OUTER JOIN Assessors AS ass ON a.AssessorId = ass.AssessorId AND a.TaxYear = ass.TaxYear" &
                        " LEFT OUTER JOIN BusinessUnits bu ON a.ClientId = bu.ClientId AND a.BusinessUnitId = bu.BusinessUnitId" &
                        " LEFT OUTER JOIN Collectors collect On j.CollectorId = collect.CollectorId And j.TaxYear = collect.TaxYear" &
                        " WHERE a.TaxYear = " & iTaxYear
                    If lClientId <> 0 Then sSQL = sSQL & " AND a.ClientId = " & lClientId
                    If lLocationId <> 0 Then sSQL = sSQL & " AND a.LocationId = " & lLocationId
                    If lAssessmentId <> 0 Then sSQL = sSQL & " AND a.AssessmentId = " & lAssessmentId
                    If lBusinessUnitId <> 0 Then sSQL = sSQL & " AND a.BusinessUnitId = " & lBusinessUnitId
                    If sStateCd.Trim <> "" Then sSQL = sSQL & " AND l.StateCd = " & QuoStr(sStateCd)
                    sSQL = sSQL & " AND ISNULL(c.ProspectFl,0) = 0 "
                    If bIncludeInactive = False Then
                        sSQL = sSQL & " AND ISNULL(c.InactiveFl,0) = 0 AND ISNULL(l.InactiveFl,0) = 0 AND ISNULL(a.InactiveFl,0) = 0 "
                    End If
                    ExecuteSQL(sSQL)
                End If

                sSQL = ""
                rowsinresults = dtAccrualBPPAccounts.Rows.Count
                progresscounter = 0 : resetcounter = 0
                For Each rowAccrual In dtAccrualBPPAccounts.Rows
                    If sSQL = "" Then
                        sSQL = "INSERT INTO " & sTempTable & " "
                    Else
                        sSQL = sSQL & " UNION "
                    End If
                    sSQL = sSQL &
                        " SELECT 'BPP' as PropertyType," &
                        " tblValues.ClientId, tblValues.LocationId, tblValues.AssessmentId,j.JurisdictionId,CONVERT(smallint,tblValues.TaxYear) AS TaxYear, tblValues.Clients_Name," &
                        " tblValues.Locations_Address, tblValues.Locations_City,tblValues.Locations_StateCd, tblValues.Locations_ClientLocationId," &
                        " tblValues.Assessments_AcctNum," &
                        " tblValues.Clients_ExcludeNotified," &
                        " tblValues.Clients_ExcludeClient," &
                        " tblValues.Assessments_SavingsExclusionCd," &
                        " tblValues.Assessors_Name, " &
                        " CONVERT(float,ISNULL(tblValues.BPPRatio,0)) AS Assessors_Ratio," &
                        " CONVERT(float,tblValues.ClientRenditionValue) AS ClientRenditionValue, j.Name as Jurisdictions_Name, CONVERT(float,j.TaxRate) AS TaxRate,"
                    sSQL = sSQL & " CASE WHEN ISNULL(ad.FinalValue,0)>0 THEN ad.FinalValue" &
                        " WHEN tblValues.SumOfFactoredAmount > ISNULL(ISNULL(ad.NotifiedValue,tblValues.SumOfFactoredAmount),0)" &
                        " THEN tblValues.SumOfFactoredAmount ELSE ISNULL(ISNULL(ad.NotifiedValue,tblValues.SumOfFactoredAmount),0) END AS FinalValue,"
                    sSQL = sSQL & "ISNULL(ad.FinalValue,0) AS CYFinalValue,"
                    sSQL = sSQL & " CONVERT(float,ISNULL(ISNULL(ad.AbatementReductionAmt,(SELECT ad2.AbatementReductionAmt" &
                        " FROM AssessmentDetailBPP ad2 WHERE ad2.ClientId = ad.ClientId" &
                        " AND ad2.LocationId = ad.LocationId AND ad2.AssessmentId = ad.AssessmentId" &
                        " AND ad2.JurisdictionId = ad.JurisdictionId AND ad2.TaxYear = " & iTaxYear - 1 & ")),0)) AS AbatementReductionAmt,"
                    sSQL = sSQL & " CONVERT(float,ISNULL(ISNULL(ad.ClientAbatementAmt,(SELECT ad2.ClientAbatementAmt" &
                        " FROM AssessmentDetailBPP ad2 WHERE ad2.ClientId = ad.ClientId" &
                        " AND ad2.LocationId = ad.LocationId AND ad2.AssessmentId = ad.AssessmentId" &
                        " AND ad2.JurisdictionId = ad.JurisdictionId AND ad2.TaxYear = " & iTaxYear - 1 & ")),0)) AS ClientAbatementAmt,"
                    sSQL = sSQL & " CONVERT(float,ISNULL(ISNULL(ad.FreeportReductionAmt,(SELECT ad2.FreeportReductionAmt" &
                        " FROM AssessmentDetailBPP ad2 WHERE ad2.ClientId = ad.ClientId" &
                        " AND ad2.LocationId = ad.LocationId AND ad2.AssessmentId = ad.AssessmentId" &
                        " AND ad2.JurisdictionId = ad.JurisdictionId AND ad2.TaxYear = " & iTaxYear - 1 & ")),0)) AS FreeportReductionAmt,"
                    sSQL = sSQL & " CONVERT(float,ISNULL(ISNULL(ad.ClientFreeportAmt,(SELECT ad2.ClientFreeportAmt" &
                        " FROM AssessmentDetailBPP ad2 WHERE ad2.ClientId = ad.ClientId" &
                        " AND ad2.LocationId = ad.LocationId AND ad2.AssessmentId = ad.AssessmentId" &
                        " AND ad2.JurisdictionId = ad.JurisdictionId AND ad2.TaxYear = " & iTaxYear - 1 & ")),0)) AS ClientFreeportAmt,"
                    sSQL = sSQL & " CONVERT(float,ISNULL(ad.NotifiedValue,0)) AS NotifiedValue, CONVERT(float,tblValues.SumOfFactoredAmount) AS SumOfFactoredAmount,"
                    sSQL = sSQL & " ISNULL(bu.Name,'') AS BusinessUnits_Name, ISNULL(c.BPPDueDate1,'1/1/1900') AS TaxDueDate"

                    sSQL = sSQL & " FROM (SELECT ClientId, LocationId, AssessmentId,TaxYear, Clients_Name, Locations_Address," &
                        " Locations_City, Locations_StateCd, Locations_ClientLocationId, Assessments_AcctNum," &
                        " Clients_ExcludeNotified," &
                        " Clients_ExcludeClient," &
                        " Assessments_SavingsExclusionCd," &
                        " Assessors_Name, BPPRatio," &
                        " ISNULL(ClientRenditionValue,0) AS ClientRenditionValue, FactoredAmount1 AS SumOfFactoredAmount," &
                        " BusinessUnitId" &
                        " FROM ("
                    Dim lFactoredAmount As Long = 0
                    If Not IsDBNull(rowAccrual("FactorEntityId1")) Then
                        Dim dsassets As DataSet = GetAssetList(rowAccrual("ClientId"), rowAccrual("LocationId"), rowAccrual("AssessmentId"), iTaxYear, 0, True, False, True, False, False, True)
                        lFactoredAmount = dsassets.Tables("ReturnTypeSumOfValues").Rows(0)("SumOfClientValue1")
                        dsassets.Dispose()
                    End If
                    sSQL = sSQL & " SELECT " & rowAccrual("ClientId") & " AS ClientId," & rowAccrual("LocationId") & " AS LocationId," &
                            rowAccrual("AssessmentId") & " AS AssessmentId," &
                            " CONVERT(smallint," & iTaxYear & ") AS TaxYear," & QuoStr(rowAccrual("Clients_Name")) & " AS Clients_Name," &
                            QuoStr(rowAccrual("Locations_Address")) & " AS Locations_Address," &
                            QuoStr(rowAccrual("Locations_City")) & "AS Locations_City," &
                            QuoStr(rowAccrual("Locations_StateCd")) & " AS Locations_StateCd," &
                            QuoStr(rowAccrual("Locations_ClientLocationId")) & " AS Locations_ClientLocationId," &
                            QuoStr(rowAccrual("Assessments_AcctNum")) & " AS Assessments_AcctNum," &
                            " CONVERT(bit," & IIf(rowAccrual("Clients_ExcludeNotified"), "1", "0") & ") AS Clients_ExcludeNotified," &
                            " CONVERT(bit," & IIf(rowAccrual("Clients_ExcludeClient"), "1", "0") & ") AS Clients_ExcludeClient," &
                            " CONVERT(int," & rowAccrual("Assessments_SavingsExclusionCd") & ") AS Assessments_SavingsExclusionCd," &
                            QuoStr(rowAccrual("Assessors_Name")) & " AS Assessors_Name," &
                            " CONVERT(float," & rowAccrual("Assessors_BPPRatio") & ") AS BPPRatio," &
                            " CONVERT(float," & rowAccrual("ClientRenditionValue") & ") AS ClientRenditionValue, CONVERT(float," & lFactoredAmount & ") AS FactoredAmount1," &
                            rowAccrual("BusinessUnitId") & " AS BusinessUnitId"
                    sSQL = sSQL & " ) tblAssets"
                    sSQL = sSQL & " ) tblValues"
                    sSQL = sSQL &
                        " INNER JOIN AssessmentDetailBPP ad On ad.ClientId=tblValues.ClientId And ad.LocationId=tblValues.LocationId" &
                        " And ad.AssessmentId=tblValues.AssessmentId And ad.TaxYear=tblValues.TaxYear" &
                        " LEFT JOIN Jurisdictions j On ad.JurisdictionId = j.JurisdictionId And ad.TaxYear = j.TaxYear"
                    sSQL = sSQL & " LEFT OUTER JOIN BusinessUnits bu On tblValues.ClientId = bu.ClientId And tblValues.BusinessUnitId = bu.BusinessUnitId"
                    sSQL = sSQL & " LEFT OUTER JOIN Collectors c On j.CollectorId = c.CollectorId And j.TaxYear = c.TaxYear"

                    If iAccrualCounter > 5 Then
                        ExecuteSQL(sSQL)
                        sSQL = ""
                        iAccrualCounter = 0
                    End If
                    iAccrualCounter = iAccrualCounter + 1

                    progresscounter = progresscounter + 1
                    resetcounter = resetcounter + 1
                    If resetcounter > 20 Then
                        MDIParent1.ShowStatus("Running report, " & Format(progresscounter / rowsinresults, csPct) & " complete")
                        resetcounter = 0
                    End If
                Next

                If sSQL <> "" Then ExecuteSQL(sSQL)
                sSQL = "Select * FROM " & sTempTable
            ElseIf eType = enumReport.enumBarCode Then
                If eBarCodeType = enumBarCodeTypes.TaxBill Then
                    sSQL = "Select LTRIM(RTRIM(ISNULL(c.Name, ''))) AS ClientName, LTRIM(RTRIM(ISNULL(l.Address, ''))) AS Address," &
                        " LTRIM(RTRIM(ISNULL(l.City, ''))) AS City, l.StateCd," &
                        " LTRIM(RTRIM(ISNULL(l.ClientLocationId, ''))) AS ClientLocationId," &
                        " LTRIM(RTRIM(ISNULL(a.AcctNum, ''))) AS AcctNum, LTRIM(RTRIM(ISNULL(coll.Name, ''))) AS CollectorName," &
                        " LTRIM(RTRIM(ISNULL(asr.Name, ''))) AS AssessorName, a.AssessmentId, coll.CollectorId, a.ClientId," &
                        " LTRIM(RTRIM(ISNULL(asr.Address1, ''))) AS AssessorAddress," &
                        " (LTRIM(RTRIM(ISNULL(asr.City, ''))) + ', ' + LTRIM(RTRIM(ISNULL(asr.StateCd, ''))) + '  ' + LTRIM(RTRIM(ISNULL(asr.Zip, '')))) AS AssessorCityStZip," &
                        " a.LocationId, a.TaxYear, a.AssessorId" &
                        " FROM Clients AS c" &
                        " INNER JOIN Locations" & IIf(ePropType = enumTable.enumLocationBPP, "BPP", "RE") & " AS l" &
                        " ON c.ClientId = l.ClientId" &
                        " INNER JOIN Assessments" & IIf(ePropType = enumTable.enumLocationBPP, "BPP", "RE") & " AS a" &
                        " ON l.ClientId = a.ClientId AND l.LocationId = a.LocationId AND l.TaxYear = a.TaxYear" &
                        " INNER JOIN AssessmentDetail" & IIf(ePropType = enumTable.enumLocationBPP, "BPP", "RE") & " AS ad" &
                        " ON a.ClientId = ad.ClientId AND a.LocationId = ad.LocationId" &
                        " AND a.AssessmentId = ad.AssessmentId AND a.TaxYear = ad.TaxYear" &
                        " INNER JOIN Jurisdictions AS j ON ad.JurisdictionId = j.JurisdictionId AND ad.TaxYear = j.TaxYear" &
                        " INNER JOIN Collectors AS coll ON j.CollectorId = coll.CollectorId AND j.TaxYear = coll.TaxYear" &
                        " LEFT OUTER JOIN Assessors AS asr ON a.AssessorId = asr.AssessorId AND a.TaxYear = asr.TaxYear" &
                        " WHERE l.TaxYear = " & iTaxYear
                    If lClientId <> 0 Then sSQL = sSQL & " AND a.ClientId = " & lClientId
                    If lLocationId <> 0 Then sSQL = sSQL & " AND a.LocationId = " & lLocationId
                    If lAssessmentId <> 0 Then sSQL = sSQL & " AND a.AssessmentId = " & lAssessmentId
                    sSQL = sSQL & " AND ISNULL(c.ProspectFl,0) = 0 "
                    If bIncludeInactive = False Then
                        sSQL = sSQL & " AND ISNULL(c.InactiveFl,0) = 0 AND ISNULL(l.InactiveFl,0) = 0 AND ISNULL(a.InactiveFl,0) = 0 "
                    End If
                    sSQL = sSQL &
                        " GROUP BY c.Name, l.Address, l.City, l.StateCd, l.ClientLocationId, a.AcctNum, coll.Name," &
                        " asr.Name, a.AssessmentId, coll.CollectorId, a.ClientId, asr.Address1, asr.City, asr.StateCd, asr.Zip, a.LocationId, a.TaxYear, a.AssessorId"
                Else
                    sSQL = "SELECT LTRIM(RTRIM(c.Name)) AS ClientName, LTRIM(RTRIM(ISNULL(l.Address,''))) AS Address," &
                        " LTRIM(RTRIM(ISNULL(l.City,''))) AS City, l.StateCd," &
                        " LTRIM(RTRIM(ISNULL(l.ClientLocationId,''))) AS ClientLocationId," &
                        " LTRIM(RTRIM(ISNULL(a.AcctNum,''))) AS AcctNum," &
                        " LTRIM(RTRIM(ISNULL(asr.Name,''))) AS AssessorName," &
                        " LTRIM(RTRIM(ISNULL(asr.Address1, ''))) AS AssessorAddress," &
                        " (LTRIM(RTRIM(ISNULL(asr.City, ''))) + ', ' + LTRIM(RTRIM(ISNULL(asr.StateCd, ''))) + '  ' + LTRIM(RTRIM(ISNULL(asr.Zip, '')))) AS AssessorCityStZip," &
                        " a.AssessmentId, a.ClientId," &
                        " a.LocationId, a.TaxYear, a.AssessorId" &
                        " FROM Clients AS c" &
                        " INNER JOIN Locations" & IIf(ePropType = enumTable.enumLocationBPP, "BPP", "RE") & " AS l" &
                        " ON c.ClientId = l.ClientId" &
                        " INNER JOIN Assessments" & IIf(ePropType = enumTable.enumLocationBPP, "BPP", "RE") & " AS a" &
                        " ON l.ClientId = a.ClientId AND l.LocationId = a.LocationId AND l.TaxYear = a.TaxYear" &
                        " LEFT OUTER JOIN Assessors AS asr" &
                        " ON a.AssessorId = asr.AssessorId AND a.TaxYear = asr.TaxYear" &
                        " WHERE l.TaxYear = " & iTaxYear
                    If lClientId <> 0 Then sSQL = sSQL & " AND a.ClientId = " & lClientId
                    If lLocationId <> 0 Then sSQL = sSQL & " AND a.LocationId = " & lLocationId
                    If lAssessmentId <> 0 Then sSQL = sSQL & " AND a.AssessmentId = " & lAssessmentId
                    sSQL = sSQL & " AND ISNULL(c.ProspectFl,0) = 0 "
                    If bIncludeInactive = False Then
                        sSQL = sSQL & " AND ISNULL(c.InactiveFl,0) = 0 AND ISNULL(l.InactiveFl,0) = 0 AND ISNULL(a.InactiveFl,0) = 0 "
                    End If
                End If
            ElseIf eType = enumReport.enumREComp Or eType = enumReport.enumBPPCompBarCode Then
                'passes datatable in as parm
            Else
                'sSQL = BuildAssetListQuery(lClientId, lLocationId, lAssessmentId, True, False, lFactorEntityId, AppData.TaxYear, sFactoringEntityNames)
                'sSQL = sSQL & " ORDER BY tblA.AssetId"
            End If              'if etype=  ends builds up of sql

            If eType = enumReport.enumTaxSavings Then
                dt = dtSavings
                lRows = dtSavings.Rows.Count
            ElseIf eType = enumReport.enumREComp Or eType = enumReport.enumBPPCompBarCode Then
                dt = dtParm
                lRows = dtParm.Rows.Count
            ElseIf eType = enumReport.enumAssetDetail Or eType = enumReport.enumAssetDetailCost Or
                    eType = enumReport.enumAssetDetailExempt Or eType = enumReport.enumAssetDetailNon Or
                    eType = enumReport.enumAssetDetailLeasedProperty Or
                    eType = enumReport.enumAssetDetailLeaseholdImprovements Or
                    eType = enumReport.enumAssetDetailLeasesAll Or
                    eType = enumReport.enumAssetSummary Or
                    eType = enumReport.enumLeaseSummary Then
                dt = GetAssetList(lClientId, lLocationId, lAssessmentId, iTaxYear, lFactorEntityId, True, False, False, False, True, False).Tables("ReturnTypeDetail")
                lRows = dt.Rows.Count
            Else
                lRows = GetData(sSQL, dt)
                If eType = enumReport.enumTaxAccrual Or eType = enumReport.enumTaxAccrualSummary Then ExecuteSQL("drop table " & sTempTable)
            End If

            If lRows > 0 Then
                row = dt.Rows(0)
                If eType = enumReport.enumTaxBill Then
                    sName = Trim(row("ContactTaxName")) & vbCrLf & Trim(row("Clients_Name")) & vbCrLf &
                        Trim(row("ContactTaxAddress")) & vbCrLf &
                        Trim(row("ContactTaxCity")) & ", " & Trim(row("ContactTaxStateCd")) &
                        "  " & Trim(row("ContactTaxZip"))
                ElseIf eType = enumReport.enumTaxBillCheckOff Then
                ElseIf eType = enumReport.enumAssessorEnvelope Or eType = enumReport.enumAssessorValueProtestEnvelope Then
                ElseIf eType = enumReport.enumMissingNotice Or eType = enumReport.enumMissingTaxBills Or
                    eType = enumReport.enumRenditionDueDate Or eType = enumReport.enumCompletedRenditions Then
                ElseIf eType = enumReport.enumClientLocationListing Then
                    sTitle = iTaxYear & " Client Location Listing"
                ElseIf eType = enumReport.enumFixedAssetReconByGLCode Or eType = enumReport.enumFixedAssetReconByDeprCode Then
                    sTitle = "Fixed Asset Reconciliation"
                ElseIf eType = enumReport.enumTaxSavings Or eType = enumReport.enumTaxAccrual Or eType = enumReport.enumTaxAccrualSummary Then
                    Select Case eType
                        Case enumReport.enumTaxSavings
                            sTitle = "Tax Savings"
                        Case enumReport.enumTaxAccrual
                            sTitle = "Tax Accrual"
                        Case enumReport.enumTaxAccrualSummary
                            sTitle = "Tax Accrual Summary"
                    End Select
                    sTitle = sTitle & ":  " & row("Clients_Name").ToString.Trim

                    'sTitle = IIf(eType = enumReport.enumTaxSavings, "Tax Savings", "Tax Accrual") & ":  " & row("Clients_Name").ToString.Trim
                    If ePropType = enumTable.enumLocationBPP Then
                        sTitle = sTitle & " for business personal property locations"
                    ElseIf ePropType = enumTable.enumLocationRE Then
                        sTitle = sTitle & " for real estate locations"
                    Else
                        sTitle = sTitle & " for all locations"
                    End If
                    sReportText = sTitle
                ElseIf eType = enumReport.enumAssessorCover Then
                    sTitle = "Assessor Cover:  " & row("Name").ToString.Trim
                    sReportText = sTitle
                ElseIf eType = enumReport.enumClientEnvelope Then
                    sTitle = "Envelope:  " & row("Name").ToString.Trim
                    sReportText = sTitle
                ElseIf eType = enumReport.enumBarCode Then
                    sReportText = "Bar code page:  " & row("ClientName") & "  " & row("AssessorName") & "  " & row("AcctNum")
                ElseIf eType = enumReport.enumREComp Then
                    sReportText = "RE Tax Comps:  " & row("Assessors_Name")
                ElseIf eType = enumReport.enumBPPCompBarCode Then
                    sReportText = "BPP Comps"
                ElseIf eType = enumReport.enumValueComparison Then
                    sReportText = "Value Comparison - " & IIf(ePropType = enumTable.enumLocationBPP, "BPP", "Real Estate")
                Else
                    sTitle = sTitle & vbCrLf & row("LegalOwner") &
                        IIf(row("Locations_ClientLocationId").ToString().Trim().Length > 0, vbCrLf & row("Locations_ClientLocationId").ToString().Trim(), "") &
                        vbCrLf & row("Locations_Address") &
                        vbCrLf & row("Locations_City") & ", " & row("Locations_StateCd") & vbCrLf &
                        row("Assessors_Name") & "  " & row("Assessments_AcctNum")
                    If IsDBNull(row("AssetId")) Then lRows = 0
                End If
            End If
            If lRows = 0 Then
                If bUpdateClientReporting = False Then
                    If eType = enumReport.enumTaxAccrual Or
                        eType = enumReport.enumBPPCompBarCode Or
                        eType = enumReport.enumTaxSavings Or
                        eType = enumReport.enumBarCode Or
                        eType = enumReport.enumMissingTaxBills Or eType = enumReport.enumTaxBill Or
                        eType = enumReport.enumCompletedRenditions Or
                        eType = enumReport.enumValueComparison Or
                        eType = enumReport.enumREComp Or eType = enumReport.enumFixedAssetReconByDeprCode Or eType = enumReport.enumFixedAssetReconByGLCode Then
                        clsReport = New clsReportData
                        clsReport.NoRows = "No records found"
                        clsReport.WriteReportData()
                        OpenReport(eType, sReportText, bSendToPrinter, sPDFFileName, sExportFolder, clsReport.ReportDataTable)
                    Else
                        sSQL = "insert into ReportData (UserName,ReportId,Title01,NoRows,RowCounter)" &
                        " values (" & QuoStr(AppData.UserId) & "," & AppData.ReportId & "," &
                        QuoStr(sTitle) & ",'No records found',1)"
                        ExecuteSQL(sSQL)
                        OpenReport(eType, sReportText, bSendToPrinter, sPDFFileName, sExportFolder)
                    End If
                End If
                MDIParent1.ShowStatus()
                Return True
            End If

            If eType = enumReport.enumTaxBill Then
                Dim dtinstallments As DataTable
                dtinstallments = GetInstallments(lClientId, lLocationId, lAssessmentId, iTaxYear, ePropType)
                clsReport = New clsReportData
                clsReport.Title01 = AppData.FirmName & vbCrLf & sTitle
                clsReport.Title02 = sName
                If dt.Rows.Count > 0 Then
                    row = dt.Rows(0)
                    If row("Clients_InactiveFl").ToString.ToUpper.Trim = "TRUE" Or
                            row("Locations_InactiveFl").ToString.ToUpper.Trim = "TRUE" Or
                            row("Assessments_InactiveFl").ToString.ToUpper.Trim = "TRUE" Then
                        sProperty.Clear()
                        sProperty.Append("INACTIVE").AppendLine()
                        sProperty.Append(IIf(row("LegalOwner").ToString.Trim.ToUpper = "", row("Clients_Name").ToString.Trim, row("LegalOwner").ToString.Trim)).AppendLine()
                        sProperty.Append(UnNullToString(row("Locations_Address"))).AppendLine()
                        sProperty.Append(UnNullToString(row("Locations_City"))).Append(", ").Append(row("Locations_StateCd").ToString).AppendLine()
                        sProperty.Append(UnNullToString(row("Locations_Name"))).Append(IIf(row("Locations_Name").ToString().Trim() <> "", " ", ""))
                        sProperty.Append(UnNullToString(row("ClientLocationId")))
                        clsReport.Text01 = sProperty.ToString
                        clsReport.WriteReportData()
                    Else
                        For Each row In dt.Rows
                            clsReport.Date02 = IIf(IsDBNull(row("Collectors_DueDate")), "NULL", UnNullToString(row("Collectors_DueDate")))
                            clsReport.Date03 = IIf(IsDBNull(row("Collectors_DueDate")), "NULL", UnNullToString(Convert.ToDateTime(row("Collectors_DueDate")).AddDays(1)))
                            sProperty.Clear()
                            sProperty.Append(IIf(row("LegalOwner").ToString.Trim.ToUpper = "", row("Clients_Name").ToString.Trim, row("LegalOwner").ToString.Trim)).AppendLine()
                            sProperty.Append(UnNullToString(row("Locations_Address"))).AppendLine()
                            sProperty.Append(UnNullToString(row("Locations_City"))).Append(", ").Append(row("Locations_StateCd").ToString).AppendLine()
                            If row("ClientLocationId").ToString.Trim = "" Then
                                sProperty.Append(UnNullToString(row("Locations_Name"))).Append(IIf(row("Locations_Name").ToString().Trim() <> "", " ", ""))
                            End If
                            sProperty.Append(row("ClientLocationId").ToString.Trim)
                            clsReport.Text01 = sProperty.ToString
                            clsReport.Text02 = IIf(row("PropertyType") = "P", "BPP", "Real Estate")
                            clsReport.Text03 = IIf(row("PropertyType") = "P", Format(row("BPPRatio"), csPctNoDec), Format(row("RERatio"), csPctNoDec))
                            'installments
                            clsReport.Text04 = ""
                            clsReport.Text05 = ""
                            clsReport.Text06 = ""
                            clsReport.Text07 = ""
                            Dim dv As New DataView(dtinstallments, "CollectorId=" & row("CollectorId"), "PayToDt", DataViewRowState.OriginalRows)
                            If dv.Count > 0 Then
                                Dim dtthisinstall = dv.ToTable()
                                If dtthisinstall.Rows.Count > 0 Then
                                    clsReport.Text04 = ""
                                    clsReport.Text05 = ""
                                    clsReport.Text06 = ""
                                    clsReport.Text07 = "Installments"
                                    For Each dr As DataRow In dtthisinstall.Rows
                                        If clsReport.Text04 <> "" Then clsReport.Text04 = clsReport.Text04 & vbCrLf
                                        If clsReport.Text05 <> "" Then clsReport.Text05 = clsReport.Text05 & vbCrLf
                                        If clsReport.Text06 <> "" Then clsReport.Text06 = clsReport.Text06 & vbCrLf
                                        clsReport.Text04 = clsReport.Text04 & "Due"
                                        clsReport.Text05 = clsReport.Text05 & Format(dr("PayToDt"), csDate)
                                        clsReport.Text06 = clsReport.Text06 & Format(dr("PayAmt"), csDol)
                                    Next
                                End If
                            End If
                            clsReport.Text09 = row("Assessors_Name").ToString
                            clsReport.Text10 = row("Jurisdictions_Name").ToString
                            clsReport.Text11 = row("TaxBillAcctNum").ToString()
                            clsReport.Text12 = row("Payee").ToString() & vbCrLf &
                            row("Collectors_Address1").ToString & vbCrLf &
                            row("Collectors_City").ToString & ", " & row("Collectors_PayeeStateCd").ToString & "  " & row("Collectors_Zip")
                            clsReport.Text14 = sName
                            clsReport.Text15 = "Tax Consultant:" & vbCrLf &
                            row("Consultants_FullName").ToString & vbCrLf &
                            row("Consultants_EMail").ToString & vbCrLf &
                            row("Consultants_Phone").ToString & vbCrLf
                            If row("TaxBillNotes").ToString.Length > 0 Then
                                clsReport.Text16 = "Important Tax Notes:" & vbCrLf & vbCrLf & row("TaxBillNotes").ToString
                            Else
                                clsReport.Text16 = ""
                            End If
                            clsReport.Number01 = iTaxYear
                            clsReport.Number02 = UnNullToDouble(row("TaxDue"))
                            clsReport.Number03 = UnNullToDouble(row("CollectorId"))
                            clsReport.Number04 = UnNullToDouble(row("TaxRate"))
                            clsReport.Number05 = UnNullToDouble(row("FinalValue"))
                            clsReport.Number06 = UnNullToDouble(row("TaxableValue"))
                            'clsReport.Number07 = UnNullToDouble(row("TaxBillAdjAmt1"))
                            clsReport.BarCode1 = BuildBarCode1(enumBarCodeTypes.TaxBill,
                                row("ClientId"), row("TaxYear"),
                                IIf(row("PropertyType").ToString.StartsWith("R"), enumTable.enumLocationRE, enumTable.enumLocationBPP),
                                row("LocationId"),
                                row("AssessmentId"), 0, row("CollectorId"))
                            clsReport.BarCode2 = BuildBarCode2(enumBarCodeTypes.TaxBill, row("ClientId"), row("TaxYear"),
                                IIf(row("PropertyType").ToString.StartsWith("R"), enumTable.enumLocationRE, enumTable.enumLocationBPP),
                                row("LocationId"), row("AssessmentId"), 0, row("CollectorId"))

                            clsReport.WriteReportData()
                        Next
                    End If
                End If                ''''If dt.rows>0
            ElseIf eType = enumReport.enumBarCode Then
                clsReport = New clsReportData
                For Each row In dt.Rows
                    Dim sBarCode1 As String = "", sBarCode2 As String = "", sBarCodeDesc As String = ""
                    Dim byteBarCodeImage As Byte()
                    If eBarCodeType = enumBarCodeTypes.TaxBill Then
                        sBarCode1 = BuildBarCode1(eBarCodeType, row("ClientId"), iTaxYear, ePropType,
                                row("LocationId"), row("AssessmentId"), 0, row("CollectorId"))
                        sBarCode2 = BuildBarCode2(eBarCodeType, row("ClientId"), iTaxYear, ePropType,
                                row("LocationId"), row("AssessmentId"), 0, row("CollectorId"))
                        sBarCodeDesc = BuildBarCodeDesc(eBarCodeType, "", row("ClientName"),
                                row("TaxYear"), row("Address"), row("City"), row("StateCd"), row("AcctNum"),
                                row("ClientLocationId"), row("AssessorName"), row("CollectorName"))
                        byteBarCodeImage = BuildBarCodeImage(eBarCodeType, row("ClientId"), iTaxYear, ePropType,
                                row("LocationId"), row("AssessmentId"), 0, row("CollectorId"))
                    Else
                        sBarCode1 = BuildBarCode1(eBarCodeType, row("ClientId"), iTaxYear, ePropType,
                                row("LocationId"), row("AssessmentId"), 0, 0)
                        sBarCode2 = BuildBarCode2(eBarCodeType, row("ClientId"), iTaxYear, ePropType,
                                row("LocationId"), row("AssessmentId"), 0, 0)
                        sBarCodeDesc = BuildBarCodeDesc(eBarCodeType, "", row("ClientName"),
                                row("TaxYear"), row("Address"), row("City"), row("StateCd"), row("AcctNum"),
                                row("ClientLocationId"), row("AssessorName"), "")
                        byteBarCodeImage = BuildBarCodeImage(eBarCodeType, row("ClientId"), iTaxYear, ePropType,
                                row("LocationId"), row("AssessmentId"), 0, 0)
                    End If
                    clsReport.BarCode1 = sBarCode1
                    clsReport.BarCode2 = sBarCode2
                    clsReport.BarCodeDesc = sBarCodeDesc
                    clsReport.BarCodeImage = byteBarCodeImage
                    clsReport.Text01 = AppData.FirmName
                    clsReport.Text02 = AppData.FirmAddress
                    clsReport.Text03 = AppData.FirmCity + ", " + AppData.FirmStateCd + "  " + AppData.FirmZip
                    clsReport.Text04 = AppData.FirmPhone
                    clsReport.Text05 = row("AssessorName").ToString.Trim
                    clsReport.Text06 = row("AssessorAddress").ToString.Trim
                    clsReport.Text07 = row("AssessorCityStZip").ToString.Trim

                    clsReport.WriteReportData()
                Next
            ElseIf eType = enumReport.enumTaxBillCheckOff Then
                For Each row In dt.Rows
                    sSQL = "INSERT INTO ReportData (UserName,ReportId,Title01,Text01,Text02,Text03,Text04,Text05,Text06,Text07,Text08,Text09," &
                            "Number01,Number02,Date01,Text10,Text11,Text12) SELECT " &
                            QuoStr(AppData.UserId) & "," & AppData.ReportId & "," &
                            QuoStr(Trim(row("Clients_Name")) & " - " & iTaxYear & " Tax Report" & vbCrLf &
                            IIf(ePropType = enumTable.enumLocationBPP, "Business Personal Property", "Real Estate")) & "," &
                            QuoStr(row("Clients_Name")) & "," &
                            QuoStr(row("Locations_ClientLocationId").ToString.Trim &
                            IIf(row("Locations_ClientLocationId").ToString.Trim = "", "", Space(10)) &
                            row("Locations_Address").ToString.Trim) & "," &
                            QuoStr(row("Locations_City")) & "," &
                            QuoStr(row("Locations_StateCd")) & "," &
                            QuoStr(row("AcctNum")) & "," &
                            QuoStr(row("Assessors_Name")) & "," &
                            QuoStr(row("Collectors_Name")) & "," &
                            QuoStr(row("Jurisdictions_Name")) & "," &
                            QuoStr(Trim(row("Locations_City")) & ", " & Trim(row("Locations_StateCd"))) & "," &
                            row("TaxRate") & "," & row("TaxDue") & ","
                    If IsDBNull(row("Collectors_DueDate")) Then
                        sSQL = sSQL & "NULL,"
                    Else
                        sSQL = sSQL & QuoStr(Format(row("Collectors_DueDate"), csDate)) & ","
                    End If
                    sSQL = sSQL & QuoStr(Trim(row("Payee").ToString)) & "," &
                            QuoStr(Trim(row("Collectors_Address1").ToString)) & "," &
                            QuoStr(Trim(row("Collectors_City").ToString) & ", " &
                            Trim(row("Collectors_PayeeStateCd").ToString) & "  " & Trim(row("Collectors_Zip").ToString))
                    ExecuteSQL(sSQL)
                Next
            ElseIf eType = enumReport.enumCompletedRenditions Then
                clsReport = New clsReportData
                For Each row In dt.Rows
                    If IsDBNull(row("RenditionDueDate")) Then
                        clsReport.Date01 = Convert.ToDateTime("12/30/1899")
                    Else
                        clsReport.Date01 = Convert.ToDateTime(row("RenditionDueDate"))
                    End If
                    clsReport.Text01 = row("Clients_Name").ToString.Trim
                    clsReport.Text02 = row("Address").ToString.Trim
                    clsReport.Text03 = row("City").ToString.Trim
                    clsReport.Text04 = row("StateCd").ToString.Trim
                    clsReport.Text05 = row("Zip").ToString.Trim
                    clsReport.Text06 = row("AcctNum").ToString.Trim
                    clsReport.Text07 = row("Assessors_Name").ToString.Trim
                    clsReport.Text08 = row("Clients_ConsultantName").ToString.Trim
                    If IsDBNull(row("RenditionCompleteDate")) Then
                        clsReport.Date02 = Convert.ToDateTime("12/30/1899")
                    Else
                        clsReport.Date02 = Convert.ToDateTime(row("RenditionCompleteDate"))
                    End If
                    If IsDBNull(row("ChangeDate")) Then
                        clsReport.Date03 = Convert.ToDateTime("12/30/1899")
                    Else
                        clsReport.Date03 = Convert.ToDateTime(row("ChangeDate"))
                    End If
                    clsReport.BarCode1 = row("Comment").ToString.Trim
                    clsReport.WriteReportData()
                Next
            ElseIf eType = enumReport.enumRenditionDueDate Then
                For Each row In dt.Rows
                    sSQL = "INSERT INTO ReportData (UserName, ReportId, Date01, Text01, Text02, Text03, Text04, Text05, Text06, Text07, Text08)" &
                            " SELECT " & QuoStr(AppData.UserId) & "," & AppData.ReportId & ","
                    If IsDBNull(row("RenditionDueDate")) Then
                        sSQL = sSQL & "NULL,"
                    Else
                        sSQL = sSQL & QuoStr(Format(row("RenditionDueDate"), csDate)) & ","
                    End If
                    sSQL = sSQL & QuoStr(Trim(row("Clients_Name"))) & "," &
                            QuoStr(row("Address")) & "," &
                            QuoStr(row("City")) & "," &
                            QuoStr(row("StateCd")) & "," &
                            QuoStr(row("Zip")) & "," &
                            QuoStr(row("AcctNum")) & "," &
                            QuoStr(row("Assessors_Name")) & "," & QuoStr(row("Clients_ConsultantName"))
                    ExecuteSQL(sSQL)
                Next
            ElseIf eType = enumReport.enumMissingTaxBills Then
                clsReport = New clsReportData
                For Each row In dt.Rows
                    If IsDBNull(row("DueDate")) Then
                        clsReport.Date01 = Convert.ToDateTime("12/30/1899")
                    Else
                        clsReport.Date01 = Convert.ToDateTime(row("DueDate"))
                    End If
                    clsReport.Text01 = row("Clients_Name")
                    clsReport.Text02 = row("Address")
                    clsReport.Text03 = row("City")
                    clsReport.Text04 = row("StateCd")
                    clsReport.Text05 = row("Zip")
                    clsReport.Text06 = row("AcctNum")
                    clsReport.Text07 = row("Jurisdictions_Name")
                    clsReport.Text08 = row("Collectors_Name")
                    clsReport.Text09 = row("PropType")
                    clsReport.Text10 = row("Clients_ConsultantName")
                    clsReport.WriteReportData()
                Next
            ElseIf eType = enumReport.enumClientLocationListing Then
                For Each row In dt.Rows
                    sSQL = "INSERT INTO ReportData (UserName, ReportId, Title01, Text01, Text02, Text03, Text04, Text05, Text06, Text07, Text08, Text09)" &
                            " SELECT " & QuoStr(AppData.UserId) & "," & AppData.ReportId & ","
                    sSQL = sSQL & QuoStr(sTitle) & "," & QuoStr(row("Clients_Name")) & "," &
                            QuoStr(row("Locations_ClientLocationId")) & "," &
                            QuoStr(row("Locations_Address")) & "," &
                            QuoStr(row("Locations_City")) & "," &
                            QuoStr(row("Locations_StateCd")) & "," &
                            QuoStr(row("Locations_Zip")) & "," &
                            QuoStr(row("Assessments_AcctNum")) & "," &
                            QuoStr(row("Type")) & "," &
                            QuoStr(row("Locations_LegalOwner"))
                    ExecuteSQL(sSQL)
                Next
            ElseIf eType = enumReport.enumMissingNotice Then
                For Each row In dt.Rows
                    sSQL = "INSERT INTO ReportData (UserName, ReportId, Date01, Text01, Text02, Text03, Text04, Text05, Text06, Text07, Text08, Text09)" &
                            " SELECT " & QuoStr(AppData.UserId) & "," & AppData.ReportId & ","
                    If IsDBNull(row("NoticeDate")) Then
                        sSQL = sSQL & "NULL,"
                    Else
                        sSQL = sSQL & QuoStr(Format(row("NoticeDate"), csDate)) & ","
                    End If
                    sSQL = sSQL & QuoStr(row("Clients_Name")) & "," &
                            QuoStr(row("Address")) & "," &
                            QuoStr(row("City")) & "," &
                            QuoStr(row("StateCd")) & "," &
                            QuoStr(row("Zip")) & "," &
                            QuoStr(row("AcctNum")) & "," &
                            QuoStr(row("Assessors_Name")) & "," & QuoStr(row("PropType")) & "," & QuoStr(row("Clients_ConsultantName"))
                    ExecuteSQL(sSQL)
                Next
            ElseIf eType = enumReport.enumClientEnvelope Or eType = enumReport.enumAssessorEnvelope Or eType = enumReport.enumAssessorValueProtestEnvelope Then
                For Each row In dt.Rows
                    sSQL = "INSERT INTO ReportData" &
                        " (UserName,ReportId,Text01,Text02,Text03,Text04,Text05,Text06,Text07,Text08)" &
                        " SELECT " & QuoStr(AppData.UserId) & "," &
                        AppData.ReportId & "," &
                        QuoStr(row("FirmName")) & "," &
                        QuoStr(row("FirmAddress")) & "," &
                        QuoStr(row("FirmCityStZip")) & "," &
                        QuoStr(row("FirmPhone")) & ","
                    If eType = enumReport.enumClientEnvelope Then
                        sSQL = sSQL &
                                QuoStr(row("Name")) & "," &
                                QuoStr("Attn:  " & row("ContactName")) & "," &
                                QuoStr(row("ContactAddress")) & "," &
                                QuoStr(row("ContactCityStZip"))
                    ElseIf eType = enumReport.enumAssessorEnvelope Then
                        sSQL = sSQL &
                                QuoStr(row("Name")) & "," &
                                QuoStr(row("Address")) & "," &
                                QuoStr(row("CityStZip")) & ",''"
                    ElseIf eType = enumReport.enumAssessorValueProtestEnvelope Then
                        sSQL = sSQL &
                                QuoStr(row("Name")) & "," &
                                QuoStr(row("ValueProtestAddress")) & "," &
                                QuoStr(row("ValueProtestCityStZip")) & ",''"
                    End If

                    ExecuteSQL(sSQL)
                Next
            ElseIf eType = enumReport.enumFixedAssetReconByGLCode Or eType = enumReport.enumFixedAssetReconByDeprCode Then
                clsReport = New clsReportData
                For Each row In dt.Rows
                    clsReport.Title01 = sTitle
                    clsReport.Text01 = row("Address").ToString.Trim & "  " & row("City").ToString.Trim & ", " & row("StateCd").ToString.Trim & "  " & row("ClientLocationId").ToString.Trim
                    If eType = enumReport.enumFixedAssetReconByGLCode Then
                        If row("GLCode") = "INVENTORY" Then
                            clsReport.Text02 = "INVENTORY"
                        Else
                            clsReport.Text02 = "FIXED ASSETS TOTAL"
                        End If
                    Else
                        If row("FactorCode1") = "INVENTORY" Then
                            clsReport.Text02 = "INVENTORY"
                        Else
                            clsReport.Text02 = "FIXED ASSETS TOTAL"
                        End If
                    End If
                    clsReport.Text03 = "Cost " & iTaxYear - 1
                    clsReport.Text04 = "Cost " & iTaxYear
                    If eType = enumReport.enumFixedAssetReconByGLCode Then
                        clsReport.Text05 = row("GLCode").ToString().Trim()
                    Else
                        clsReport.Text05 = row("FactorCode1").ToString().Trim()
                    End If
                    clsReport.Text06 = row("Clients_Name").ToString.Trim

                    If eType = enumReport.enumFixedAssetReconByGLCode Then
                        If row("GLCode").ToString.Trim.ToUpper = "INVENTORY" Then
                            clsReport.Number01 = 1
                        Else
                            clsReport.Number01 = 0
                        End If
                        clsReport.Text07 = "G/L Code"
                    Else
                        If row("FactorCode1").ToString.Trim.ToUpper = "INVENTORY" Then
                            clsReport.Number01 = 1
                        Else
                            clsReport.Number01 = 0
                        End If
                        clsReport.Text07 = "Depreciation Code"
                    End If

                    clsReport.Number02 = row("YearPurchased")
                    clsReport.Number03 = row("PreviousYearCost")
                    clsReport.Number04 = row("Difference")
                    clsReport.Number05 = row("CurrentYearCost")
                    clsReport.WriteReportData()
                Next
            ElseIf eType = enumReport.enumTaxSavings Then
                Dim bHasBusinessUnits As Boolean = True
                If lClientId > 0 Then
                    If GetData("SELECT 1 WHERE EXISTS (SELECT ClientId FROM BusinessUnits WHERE ClientId = " & lClientId & ")", New DataTable) > 0 Then
                        bHasBusinessUnits = True
                    Else
                        bHasBusinessUnits = False
                    End If
                End If
                clsReport = New clsReportData
                For Each row In dt.Rows
                    clsReport.Text01 = row("Clients_Name").ToString.Trim
                    clsReport.Text02 = row("TaxYear") & " Tax Accrual Savings Report"
                    clsReport.Text03 = "Tax Rate"
                    clsReport.Text04 = row("Clients_Name").ToString.Trim
                    clsReport.Text05 = row("AcctNum").ToString.Trim
                    clsReport.Text06 = row("Locations_StateCd").ToString
                    clsReport.Text07 = row("Locations_Address").ToString.Trim
                    clsReport.Text08 = row("Locations_City").ToString.Trim
                    clsReport.Text09 = row("ValueSource").ToString
                    clsReport.Text12 = row("AcctNum").ToString.Trim & "  " & row("Locations_StateCd").ToString & "  " & row("Locations_Address").ToString.Trim &
                        "  " & row("Locations_City").ToString.Trim
                    clsReport.Text10 = IIf(row("PropertyType") = "R", "Real Estate", "Business Personal Property")
                    clsReport.Text11 = row("Jurisdictions_Name").ToString.Trim
                    clsReport.Text13 = row("Assessors_Name").ToString.Trim
                    clsReport.Text14 = row("BusinessUnits_Name").ToString & "  " & row("Locations_StateCd") & "  " &
                        row("Assessors_Name").ToString.Trim & "  " & row("Locations_Address").ToString.Trim &
                        "  " & row("AcctNum").ToString.Trim
                    clsReport.Text15 = IIf(row("ClientLocationId").ToString.Length > 0, "Loc " & row("ClientLocationId").ToString.Trim, "")
                    If row("PropertyType") = "P" Then
                        clsReport.Text16 = "State ratio:  " & Format(UnNullToDouble(row("BPPRatio")), csPct)
                        clsReport.Number14 = UnNullToDouble(row("BPPRatio"))
                    Else
                        clsReport.Text16 = "State ratio:  " & Format(UnNullToDouble(row("RERatio")), csPct)
                        clsReport.Number14 = UnNullToDouble(row("RERatio"))
                    End If
                    If row("PropertyType") = "R" Then
                        clsReport.Text17 = "Last year value:  " & Format(row("PriorYearTotalFinalValue"), csInt)
                        ''new RE cap that may go away after 2026
                        If row("ValueLimitation") > 0 Then
                            clsReport.Text17 = clsReport.Text17 & "    Value Limitation:  " & Format(row("ValueLimitation"), csInt)
                        End If
                    Else
                        clsReport.Text17 = ""
                    End If

                    clsReport.Text18 = "Business Unit:  " & IIf(row("BusinessUnits_Name").ToString.Length = 0, "N/A", row("BusinessUnits_Name").ToString)
                    clsReport.Text19 = "Total For " & clsReport.Text18
                    clsReport.Text20 = IIf(row("BusinessUnits_Name").ToString.Length = 0, "N/A", row("BusinessUnits_Name").ToString)
                    clsReport.Number01 = UnNullToDouble(row("TaxRate"))
                    clsReport.Number02 = UnNullToDouble(row("TotalAssessedValue"))
                    clsReport.Number03 = UnNullToDouble(row("FinalValue"))
                    clsReport.Number04 = UnNullToDouble(row("AbatementReductionAmt")) + UnNullToDouble(row("FreeportReductionAmt")) - UnNullToDouble(row("AdjAmt1"))
                    clsReport.Number05 = UnNullToDouble(row("ValueDifference"))
                    clsReport.Number06 = UnNullToDouble(row("TaxDueBeforeSavings"))
                    clsReport.Number07 = UnNullToDouble(row("TaxDueUsingPreviousYearRate"))
                    clsReport.Number08 = UnNullToDouble(row("SavingsAmt"))
                    'suppress business units if not business units, suppress=1
                    clsReport.Number11 = IIf(bHasBusinessUnits, 0, 1)
                    clsReport.Number12 = UnNullToDouble(row("PriorYearTotalFinalValue"))
                    clsReport.Number13 = UnNullToDouble(row("ValueLimitation"))
                    clsReport.WriteReportData()
                Next
            ElseIf eType = enumReport.enumAssessorCover Then
                For Each row In dt.Rows
                    sSQL = "INSERT INTO ReportData" &
                        " (UserName,ReportId,Text01,Text02,Text03,Text04,Text05,Text06,Text07,Text08,Text09,Text10,Text11,Text12,Text13)" &
                        " SELECT " & QuoStr(AppData.UserId) & "," & AppData.ReportId & "," &
                        QuoStr(row("FirmName")) & "," &
                        QuoStr(row("FirmAddress")) & "," &
                        QuoStr(row("FirmCityStZip")) & "," &
                        QuoStr(row("FirmPhone")) & "," &
                        QuoStr(row("Name")) & "," & QuoStr(row("Address")) & "," & QuoStr(row("City")) & "," &
                        QuoStr(row("Phone")) & "," & QuoStr("") & "," &
                        QuoStr("") & "," & QuoStr("") & "," & QuoStr("") & "," &
                        QuoStr("")
                    ExecuteSQL(sSQL)
                Next
            ElseIf eType = enumReport.enumTaxAccrual Or eType = enumReport.enumTaxAccrualSummary Then
                Dim bHasBusinessUnits As Boolean = True
                Dim excludecode As enumSavingsExclusionCd
                Dim dValue As Double = 0
                Dim dAbatement As Double = 0
                Dim dFreeport As Double = 0
                Dim lNetTaxableValue As Long = 0

                If lClientId > 0 Then
                    If GetData("SELECT 1 WHERE EXISTS (SELECT ClientId FROM BusinessUnits WHERE ClientId = " & lClientId & ")", New DataTable) > 0 Then
                        bHasBusinessUnits = True
                    Else
                        bHasBusinessUnits = False
                    End If
                End If
                ''need to add abatement and freeport and taxable values to report
                clsReport = New clsReportData
                For Each row In dt.Rows
                    excludecode = row("Assessments_SavingsExclusionCd")
                    dValue = 0
                    dAbatement = 0
                    dFreeport = 0
                    lNetTaxableValue = 0

                    If row("PropertyType") = "BPP" Then
                        If row("Clients_ExcludeNotified") And row("Clients_ExcludeClient") Then
                            dValue = 0
                        Else
                            If row("Clients_ExcludeNotified") Then
                                dValue = UnNullToDouble(row("SumOfFactoredAmount"))
                            ElseIf row("Clients_ExcludeClient") Then
                                dValue = UnNullToDouble(row("NotifiedValue"))
                            Else
                                Select Case excludecode
                                    Case enumSavingsExclusionCd.enumNotified,
                                            enumSavingsExclusionCd.enumNotifiedAbatements,
                                            enumSavingsExclusionCd.enumNotifiedAbatementsFreeport,
                                            enumSavingsExclusionCd.enumNotifiedFreeport
                                        dValue = UnNullToDouble(row("SumOfFactoredAmount"))
                                    Case enumSavingsExclusionCd.enumClient,
                                            enumSavingsExclusionCd.enumClientAbatements,
                                            enumSavingsExclusionCd.enumClientAbatementsFreeport,
                                            enumSavingsExclusionCd.enumClientFreeport
                                        dValue = UnNullToDouble(row("NotifiedValue"))
                                    Case Else
                                        dValue = UnNullToDouble(row("FinalValue"))
                                End Select
                            End If
                        End If
                        dAbatement = UnNullToDouble(row("AbatementReductionAmt"))
                        dFreeport = UnNullToDouble(row("FreeportReductionAmt"))
                    Else
                        dValue = UnNullToDouble(row("FinalValue"))
                        dAbatement = UnNullToDouble(row("AbatementReductionAmt"))
                    End If
                    clsReport.Text18 = Trim(row("Clients_Name"))
                    clsReport.Text01 = Trim(row("Clients_Name")) & vbCrLf & iTaxYear & " Estimated Tax Accrual"
                    clsReport.Text02 = "Business Unit:  " & IIf(row("BusinessUnits_Name").ToString.Length = 0, "N/A", row("BusinessUnits_Name").ToString)
                    clsReport.Text03 = iTaxYear - 1 & " Tax Rate"
                    clsReport.Text04 = UnNullToString(row("Assessments_AcctNum"))
                    clsReport.Text05 = row("Locations_StateCd")
                    clsReport.Text06 = Trim(UnNullToString(row("Locations_ClientLocationId"))) & "  " & Trim(UnNullToString(row("Locations_Address"))) & "  " &
                        Trim(UnNullToString(row("Locations_City")))
                    clsReport.Text07 = "Total For " & clsReport.Text02
                    clsReport.Text08 = UnNullToString(row("Assessors_Name"))
                    clsReport.Text09 = IIf(row("PropertyType") = "BPP", "BPP", "Real")
                    clsReport.Text10 = UnNullToString(row("Jurisdictions_Name"))
                    clsReport.Text15 = row("BusinessUnits_Name").ToString & "  " & row("Locations_StateCd") & "  " & row("Assessors_Name").ToString.Trim & "  " & row("Locations_Address").ToString.Trim &
                        "  " & row("Assessments_AcctNum").ToString.Trim
                    clsReport.Number01 = iTaxYear
                    clsReport.Number09 = UnNullToDouble(row("TaxRate"))
                    If row("ClientRenditionValue") = 0 Then
                        clsReport.Number10 = dValue
                        lNetTaxableValue = dValue - dAbatement - dFreeport
                        dTaxDue = (row("Assessors_Ratio") *
                            (dValue -
                            dAbatement -
                            dFreeport)) / 100 *
                            UnNullToDouble(row("TaxRate"))
                    Else
                        clsReport.Number10 = dValue
                        lNetTaxableValue = dValue - dAbatement - dFreeport
                        dTaxDue = (row("Assessors_Ratio") *
                            (dValue -
                            dAbatement -
                            dFreeport)) / 100 *
                            UnNullToDouble(row("TaxRate"))
                    End If
                    If lNetTaxableValue < 0 Then lNetTaxableValue = 0
                    If dTaxDue < 0 And UnNullToDouble(row("TaxRate")) > 0 Then dTaxDue = 0
                    clsReport.Number14 = Val(Format(dTaxDue, "0.00"))
                    clsReport.Number15 = row("Assessors_Ratio") * 100
                    clsReport.Number02 = Val(Format(dAbatement, "0.00"))
                    clsReport.Number03 = Val(Format(dFreeport, "0.00"))
                    clsReport.Number04 = lNetTaxableValue
                    'suppress business units if not business units, suppress=1
                    clsReport.Number11 = IIf(bHasBusinessUnits, 0, 1)
                    clsReport.Number16 = row("ClientId")
                    clsReport.Number17 = row("LocationId")
                    clsReport.Number18 = row("AssessmentId")
                    clsReport.Number19 = row("JurisdictionId")
                    clsReport.Number20 = row("NotifiedValue")
                    clsReport.Date01 = row("TaxDueDate")
                    clsReport.Number12 = UnNullToDouble(row("CYFinalValue"))
                    'Number01 is tax year

                    clsReport.WriteReportData()
                Next

                'hack to sum up the accrual detail stored in clsReport (need stored proc to do accrual calculations)
                'write data back to sql and use sql to sum/group by and store in ReportData table
                If eType = enumReport.enumTaxAccrualSummary Then
                    If Not RunTaxAccrualSummaryReport(clsReport) Then Return False
                End If

            ElseIf eType = enumReport.enumREComp Then
                clsReport = New clsReportData
                For Each row In dt.Rows
                    clsReport.Title01 = AppData.FirmName & vbCrLf & "Tax Comps - " & iTaxYear & " Commercial Values" & vbCrLf & row("Assessors_Name")
                    clsReport.Text01 = row("AcctNum")
                    clsReport.Text02 = row("StreetName")
                    clsReport.Text03 = row("BusinessName")
                    clsReport.Text04 = row("BuildingClass")
                    clsReport.Text05 = row("Mapsco")
                    clsReport.Text06 = row("NeighborhoodGroup")
                    clsReport.Text07 = row("EconomicArea")
                    clsReport.Text08 = row("ComparabilityCode")
                    clsReport.Text09 = IIf(row("DateSwitch") = 1, "Date:  " & Now.ToString("M/d/yyyy"), "")
                    clsReport.Text10 = IIf(row("SortField") = 1, "", "Comparison Account")
                    clsReport.Text11 = row("AppraisalMethod")
                    clsReport.Text12 = row("PricingMethod")
                    clsReport.Text13 = row("EffectiveYear")
                    clsReport.Text14 = row("ConstructionType")
                    clsReport.Number01 = row("BuildingSqFt")
                    clsReport.Number02 = row("LandSqFt")
                    clsReport.Number03 = row("YearBuilt")
                    clsReport.Number04 = row("LandValue")
                    clsReport.Number05 = row("ImprovementValue")
                    clsReport.Number06 = row("TotalValue")
                    clsReport.Number07 = row("LandValuePerSqFt")
                    clsReport.Number08 = row("ImprovementValuePerSqFt")
                    clsReport.Number09 = row("TotalValuePerSqFt")
                    clsReport.Number10 = row("LandBuildingRatio")
                    clsReport.Number11 = row("NumberOfUnits")
                    clsReport.Number12 = row("TotalValuePerUnit")
                    clsReport.Number13 = row("AVGLandValueSqFt")
                    clsReport.Number14 = row("AVGImproveValSqFt")
                    clsReport.Number15 = row("AVGTotalValueSqFt")
                    clsReport.Number16 = row("AVGTotalValueUnit")
                    clsReport.Number17 = IIf(row("SortField") = 0, 1, 0)
                    clsReport.Number18 = dt.Rows.Count - 1
                    clsReport.Number19 = row("AVGLandBldgRatio")

                    clsReport.WriteReportData()
                Next
            ElseIf eType = enumReport.enumBPPCompBarCode Then
                clsReport = New clsReportData
                For Each row In dt.Rows
                    clsReport.BarCode1 = BuildBarCode1(enumBarCodeTypes.BPPComps, row("CompID"))
                    clsReport.BarCode2 = BuildBarCode2(enumBarCodeTypes.BPPComps, row("CompID"))
                    clsReport.BarCodeDesc = BuildBarCodeDesc(enumBarCodeTypes.BPPComps, row("CompID"), row("AssetType"), row("ManufactureYear"),
                        row("Manufacturer"), row("Model"), row("SerialNumber"))
                    clsReport.BarCodeImage = BuildBarCodeImage(enumBarCodeTypes.BPPComps, 0, 0, enumTable.enumLocationBPP, 0, 0, 0, 0, row("CompID"))
                    clsReport.WriteReportData()
                Next
            ElseIf eType = enumReport.enumValueComparison Then
                Dim bHasBusinessUnits As Boolean = True
                If lClientId > 0 Then
                    If GetData("SELECT 1 WHERE EXISTS (SELECT ClientId FROM BusinessUnits WHERE ClientId = " & lClientId & ")", New DataTable) > 0 Then
                        bHasBusinessUnits = True
                    Else
                        bHasBusinessUnits = False
                    End If
                End If
                clsReport = New clsReportData
                For Each row In dt.Rows
                    clsReport.Title01 = Trim(row("Clients_Name")) & vbCrLf & iTaxYear & " Value Comparison - " & IIf(ePropType = enumTable.enumLocationBPP, "BPP", "Real Estate")
                    clsReport.Text01 = "Business Unit:  " & IIf(row("BusinessUnits_Name").ToString.Length = 0, "N/A", row("BusinessUnits_Name").ToString)
                    clsReport.Text02 = row("Assessors_Name")
                    clsReport.Text03 = row("Assessments_AcctNum")
                    clsReport.Text04 = IIf(row("Locations_ClientLocationId") = "", "", row("Locations_ClientLocationId") & "  ") & row("Locations_Address") & "  " &
                        row("Locations_City") & ", " & row("Locations_StateCd")
                    clsReport.Text05 = IIf(row("PropType") = "P", "BPP", "Real")
                    ''sorting
                    clsReport.Text15 = row("BusinessUnits_Name").ToString & "  " & row("Locations_StateCd") & "  " & row("Assessors_Name").ToString.Trim & "  " & row("Locations_Address").ToString.Trim &
                        "  " & row("Assessments_AcctNum").ToString.Trim
                    clsReport.Number01 = row("PriorYearFinalValue")
                    If row("PropType").ToString() = "P" Then
                        clsReport.Number02 = row("CountyReclassValue")
                        clsReport.Number03 = row("MarketReclassValue")
                    Else
                        clsReport.Number02 = row("CurrentYearAssessedValue")
                    End If
                    'suppress business units if not business units, suppress=1
                    clsReport.Number11 = IIf(bHasBusinessUnits, 0, 1)
                    clsReport.WriteReportData()
                Next
            Else
                '1 thru 5 are the 5 potential depreciation schedules
                '1 is printed twice, 1a is client value, 1b is normal reclassed
                If lFactorEntityId = 0 Or bPrintClientScheduleOnly Then
                    bPrintingClientValue = True
                Else
                    bPrintingClientValue = False
                End If
                For iScheduleCounter = 1 To IIf(eType = enumReport.enumAssetDetailLeasedProperty _
                        Or eType = enumReport.enumAssetDetailLeaseholdImprovements _
                        Or eType = enumReport.enumAssetDetailLeasesAll, 1, 5)
                    If dt.Columns.Contains("FactoringEntityName" & iScheduleCounter) Then
                        If dt.Columns.Contains("ClientFactorCode" & iScheduleCounter) Then
                            Dim INVRows() As DataRow = dt.Select("ClientFactorCode" & iScheduleCounter & " IN('INV','INVENTORY')" &
                                " OR EntityFactorCode" & iScheduleCounter & " IN('INV','INVENTORY')")
                            Dim dINV As Double = 0, dClientINV As Double = 0, iINVYear As Integer = 0
                            Dim bHasFixed As Boolean = False
                            Dim bHasINV As Boolean = False
                            Dim sTotalAssessorRatio As String = ""
                            For Each dr As DataRow In INVRows
                                dINV = dINV + dr("EntityValue" & iScheduleCounter)
                                dClientINV = dClientINV + dr("ClientValue" & iScheduleCounter)

                                'If dr("FactorCodeOverride" & iScheduleCounter).ToString = "" Then
                                '    dINV = dINV + dr("FactoredAmount" & iScheduleCounter)
                                'Else
                                '    dINV = dINV + dr("FactoredAmountOverride" & iScheduleCounter)
                                'End If
                                'If dr("MappedFactorCode" & iScheduleCounter).ToString <> "" Or dr("ClientFactorCodeOverride" & iScheduleCounter).ToString <> "" Then
                                '    If dr("ClientFactorCodeOverride" & iScheduleCounter).ToString = "" Then
                                '        dClientINV = dClientINV + dr("FactoredAmount" & iScheduleCounter)
                                '    Else
                                '        dClientINV = dClientINV + dr("FactoredAmount" & iScheduleCounter)
                                '    End If
                                'End If


                                If Year(dr("PurchaseDate")) > iINVYear Then iINVYear = Year(dr("PurchaseDate"))
                            Next
                            lRowCounter = 0
                            Do                                   'do twice for 1st schedule, once for others
                                If dt.Columns.Contains("InterstateAllocationPct" & iScheduleCounter) Then
                                    bHasInterstateAllocationPct = True
                                Else
                                    bHasInterstateAllocationPct = False
                                End If
                                For Each row In dt.Rows
                                    sName = "" : dFactoredAmt = 0 : dFactor = 0 : sFactorDescription = "" : lFactoredAmtBeforeInterstateAllocationPct = 0
                                    dOriginalAmt = row("OriginalCost")
                                    If iScheduleCounter = 1 And bPrintingClientValue = True Then
                                        sName = "Client Value"
                                    Else
                                        sName = row("FactoringEntityName" & iScheduleCounter)
                                    End If
                                    sAcctNum = row("Assessments_AcctNum")

                                    If bPrintingClientValue Then
                                        sFactorDescription = UnNullToString(row("ClientFactorDesc" & iScheduleCounter))
                                        dFactoredAmt = UnNullToDouble(row("ClientValue" & iScheduleCounter))
                                        lFactoredAmtBeforeInterstateAllocationPct = dFactoredAmt
                                        If dt.Columns.Contains("InterstateAllocationPct" & iScheduleCounter) Then
                                            If UnNullToDouble(row("InterstateAllocationPct" & iScheduleCounter)) > 0 Then
                                                lFactoredAmtBeforeInterstateAllocationPct = dOriginalAmt * UnNullToDouble(row("ClientFactor" & iScheduleCounter))
                                                If dt.Columns.Contains("AllocationPct" & iScheduleCounter) Then
                                                    If UnNullToDouble(row("AllocationPct" & iScheduleCounter)) > 0 Then
                                                        lFactoredAmtBeforeInterstateAllocationPct = lFactoredAmtBeforeInterstateAllocationPct * UnNullToDouble(row("AllocationPct" & iScheduleCounter))
                                                    End If
                                                End If
                                            End If
                                        End If
                                        dFactor = UnNullToDouble(row("ClientFactor" & iScheduleCounter))
                                        sFactorCode = UnNullToString(row("ClientFactorCode" & iScheduleCounter))
                                    Else
                                        sFactorDescription = UnNullToString(row("EntityFactorDesc" & iScheduleCounter))
                                        dFactoredAmt = UnNullToDouble(row("EntityValue" & iScheduleCounter))
                                        ''''need to move this to the stored proc
                                        lFactoredAmtBeforeInterstateAllocationPct = dFactoredAmt
                                        If dt.Columns.Contains("InterstateAllocationPct" & iScheduleCounter) Then
                                            If UnNullToDouble(row("InterstateAllocationPct" & iScheduleCounter)) > 0 Then
                                                lFactoredAmtBeforeInterstateAllocationPct = dOriginalAmt * UnNullToDouble(row("EntityFactor" & iScheduleCounter))
                                                If dt.Columns.Contains("AllocationPct" & iScheduleCounter) Then
                                                    If UnNullToDouble(row("AllocationPct" & iScheduleCounter)) > 0 Then
                                                        lFactoredAmtBeforeInterstateAllocationPct = lFactoredAmtBeforeInterstateAllocationPct * UnNullToDouble(row("AllocationPct" & iScheduleCounter))
                                                    End If
                                                End If
                                            End If
                                        End If
                                        dFactor = UnNullToDouble(row("EntityFactor" & iScheduleCounter))
                                        sFactorCode = UnNullToString(row("EntityFactorCode" & iScheduleCounter))
                                    End If

                                    bIncludeRow = False
                                    If eType = enumReport.enumAssetDetailLeasedProperty _
                                            Or eType = enumReport.enumAssetDetailLeaseholdImprovements _
                                            Or eType = enumReport.enumAssetDetailLeasesAll Then
                                        If dt.Columns.Contains("LeaseType") Then
                                            Select Case eType
                                                Case enumReport.enumAssetDetailLeasedProperty
                                                    If UCase(row("LeaseType").ToString.Trim) = UCase(LEASEDEQUIPMENT) _
                                                            Or UCase(row("LeaseType").ToString.Trim) = UCase(LEASEDVEHICLES) Then
                                                        bIncludeRow = True
                                                    End If
                                                Case enumReport.enumAssetDetailLeaseholdImprovements
                                                    If UCase(row("LeaseType").ToString.Trim) = UCase(LEASEHOLDIMPROVEMENTS) Then
                                                        bIncludeRow = True
                                                    End If
                                                Case enumReport.enumAssetDetailLeasesAll
                                                    If row("LeaseType").ToString.Trim <> "" Then bIncludeRow = True
                                            End Select
                                        End If
                                    Else
                                        If dFactoredAmt <> 0 And eType <> enumReport.enumAssetDetailNon And eType <> enumReport.enumAssetDetailExempt Then
                                            bIncludeRow = True
                                        End If
                                        If sFactorCode = "NON" And eType = enumReport.enumAssetDetailNon Then
                                            bIncludeRow = True
                                        End If
                                        If sFactorCode = "EXEMPT" And eType = enumReport.enumAssetDetailExempt Then
                                            bIncludeRow = True
                                        End If
                                        If bIncludeZeroAmounts And sFactorCode <> "NON" And sFactorCode <> "EXEMPT" And row("OriginalCost") = 0 _
                                            And (eType = enumReport.enumAssetDetail Or eType = enumReport.enumAssetDetailCost) Then
                                            bIncludeRow = True
                                        End If
                                    End If

                                    If bIncludeRow = True Then
                                        If dt.Columns.Contains("VIN") Then
                                            sVIN = UnNullToString(row("VIN"))
                                        Else
                                            sVIN = ""
                                        End If
                                        lRowCounter = lRowCounter + 1
                                        If eType = enumReport.enumAssetDetail Then
                                            sSQL = "insert into ReportData (UserName,ReportId,RowCounter,Title01,Text01,Date01," &
                                                "Text03,Text04,Text10,BarCode1,BarCode2,BarCodeDesc) SELECT " &
                                                QuoStr(AppData.UserId) & "," & AppData.ReportId & "," &
                                                lRowCounter & "," & QuoStr(sTitle) & "," &
                                                QuoStr(row("AssetId")) & "," & QuoStr(Format(row("PurchaseDate"), csDate)) & "," &
                                                QuoStr(row("Description") &
                                                IIf(sVIN = "", "", vbCrLf & "VIN: " & sVIN)) & "," &
                                                QuoStr(sFactorDescription) & "," & QuoStr(sFactorCode) & ","
                                            If bPrintCoverPage Then
                                                sSQL = sSQL & QuoStr(BuildBarCode1(enumBarCodeTypes.Rendition, row("ClientId"), iTaxYear,
                                                    enumTable.enumLocationBPP, row("LocationId"), row("AssessmentId"), 0, 0)) & "," &
                                                QuoStr(BuildBarCode2(enumBarCodeTypes.Rendition, row("ClientId"), iTaxYear,
                                                    enumTable.enumLocationBPP, row("LocationId"), row("AssessmentId"), 0, 0)) & "," &
                                                QuoStr(BuildBarCodeDesc(enumBarCodeTypes.Rendition, " for " & sName,
                                                row("Clients_Name"), iTaxYear, row("Locations_Address"),
                                                row("Locations_City"), row("Locations_StateCd"), row("Assessments_AcctNum"),
                                                row("Locations_ClientLocationId"), row("Assessors_Name"), ""))
                                            Else
                                                sSQL = sSQL & "'','',''"
                                            End If
                                            ExecuteSQL(sSQL)
                                        ElseIf eType = enumReport.enumAssetSummary Then
                                            sTotalAssessorRatio = "Total at " & Format(row("BPPRatio"), csPct) & " ratio"
                                            LesseeInfo.Clear()
                                            If dt.Columns.Contains("LesseeName") Then
                                                If row("LesseeName").ToString.Trim <> "" Then
                                                    LesseeInfo.Append(row("LesseeName").ToString.Trim)
                                                    If row("LesseeAddress").ToString.Trim <> "" Then LesseeInfo.Append(" ").Append(row("LesseeAddress").ToString.Trim)
                                                    If row("LesseeCity").ToString.Trim <> "" Then LesseeInfo.Append(" ").Append(row("LesseeCity").ToString.Trim)
                                                    If row("LesseeStateCd").ToString.Trim <> "" Then LesseeInfo.Append(", ").Append(row("LesseeStateCd").ToString.Trim)
                                                    If row("LesseeZip").ToString.Trim <> "" Then LesseeInfo.Append("  ").Append(row("LesseeZip").ToString.Trim)
                                                End If
                                            End If
                                            sSQL = "insert into ReportData (UserName,ReportId,RowCounter,Title01,Text01,Text02,Text03,Number01," &
                                                    "Number02,Number03,Number04,Number05,Number06,Number07,Text10,Text04,Number08,Text09," &
                                                    "Number09, Number10, Text05, Number11," &
                                                    "BarCode1,BarCode2,BarCodeDesc)" &
                                                    " SELECT " & QuoStr(AppData.UserId) & "," & AppData.ReportId & "," &    'username,reportid
                                                    lRowCounter & "," & QuoStr(sTitle) & "," &              'rowcounter,title01              
                                                    QuoStr(row("AssetId")) & "," &                          'text01
                                                    QuoStr(LesseeInfo.ToString) & "," &                     'text02
                                                    QuoStr(sFactorDescription) & "," &                      'text03
                                                    dFactoredAmt & "," & dOriginalAmt & "," & iSuppressOriginalCost & "," &     'number01,number02,number03
                                                    Year(row("PurchaseDate")) & "," & dFactor & "," &       'number04,number05
                                                    IIf(iScheduleCounter = 1 And bPrintingClientValue = True, dClientINV, dINV) & "," &     'number06
                                                    row("BPPRatio") & "," &                                 'number07
                                                    QuoStr(sFactorCode) & "," &                             'text10
                                                    QuoStr(sTotalAssessorRatio) & "," &                     'text04
                                                    iINVYear & "," &                                        'number08
                                                    QuoStr(Format(row("BPPRatio"), csPct)) & ","            'text09
                                            'Number09
                                            sSQL = sSQL & IIf(bHasInterstateAllocationPct, 0, 1) & ","      ''if has allocation, show columns (1=suppress)
                                            'Number10
                                            sSQL = sSQL & lFactoredAmtBeforeInterstateAllocationPct & ","
                                            'Text05, Number11
                                            If sFactorCode = "INV" Or sFactorCode = "INVENTORY" Then
                                                sSQL = sSQL & "'" & iTaxYear & " Inventory',1,"
                                            Else
                                                sSQL = sSQL & "'Fixed Assets',0,"
                                            End If
                                            'BarCode1,BarCode2,BarCodeDesc
                                            If bPrintCoverPage Then
                                                sSQL = sSQL & QuoStr(BuildBarCode1(enumBarCodeTypes.Rendition, row("ClientId"), iTaxYear,
                                                        enumTable.enumLocationBPP, row("LocationId"), row("AssessmentId"), 0, 0)) & "," &
                                                    QuoStr(BuildBarCode2(enumBarCodeTypes.Rendition, row("ClientId"), iTaxYear,
                                                        enumTable.enumLocationBPP, row("LocationId"), row("AssessmentId"), 0, 0)) & "," &
                                                    QuoStr(BuildBarCodeDesc(enumBarCodeTypes.Rendition, " for " & sName,
                                                    row("Clients_Name"), iTaxYear, row("Locations_Address"),
                                                    row("Locations_City"), row("Locations_StateCd"), row("Assessments_AcctNum"),
                                                    row("Locations_ClientLocationId"), row("Assessors_Name"), ""))
                                            Else
                                                sSQL = sSQL & "'','',''"
                                            End If
                                            ExecuteSQL(sSQL)
                                        ElseIf eType = enumReport.enumAssetDetailCost Or eType = enumReport.enumAssetDetailExempt Or eType = enumReport.enumAssetDetailNon Then
                                            If eType = enumReport.enumAssetDetailExempt Or eType = enumReport.enumAssetDetailNon Then iSuppressOriginalCost = 1
                                            sSQL = "insert into ReportData (UserName,ReportId,RowCounter,Title01,Text01,Date01," &
                                                "Text03,Text04,Number01," &
                                                "Number02,Number03,Number04,Number05,Text10,Number06,Text02,Text06,Number07,Text05," &
                                                " Number09,BarCode1,BarCode2,BarCodeDesc,Number10,Number11,Number12,Number13)" &
                                                " SELECT " &
                                                QuoStr(AppData.UserId) & "," & AppData.ReportId & "," &         'username, reportid
                                                lRowCounter & "," & QuoStr(sTitle) & "," &                      'rowcounter, title01
                                                QuoStr(row("AssetId")) & "," & QuoStr(Format(row("PurchaseDate"), csDate)) & "," &      'text01, date01
                                                QuoStr(row("Description") &                                     'text03
                                                IIf(sVIN = "", "", vbCrLf & "VIN: " & sVIN)) & "," &
                                                QuoStr(sFactorDescription) & "," & dFactoredAmt & "," &         'text04, number01
                                                dOriginalAmt & "," & iSuppressOriginalCost & "," &              'number02, number03
                                                Year(row("PurchaseDate")) & "," & dFactor & "," & QuoStr(sFactorCode) & ","     'number04, number05, text10
                                            'Number06,Text02
                                            If sFactorCode = "INV" Or sFactorCode = "INVENTORY" Then
                                                sSQL = sSQL & "1, 'Inventory',"
                                            Else
                                                sSQL = sSQL & "0,'Fixed Assets',"
                                            End If
                                            'Text06
                                            LesseeInfo.Clear()
                                            If dt.Columns.Contains("LesseeName") Then
                                                If row("LesseeName").ToString.Trim <> "" Then
                                                    LesseeInfo.Append(row("LesseeName").ToString.Trim)
                                                    If row("LesseeAddress").ToString.Trim <> "" Then LesseeInfo.Append(" ").Append(row("LesseeAddress").ToString.Trim)
                                                    If row("LesseeCity").ToString.Trim <> "" Then LesseeInfo.Append(" ").Append(row("LesseeCity").ToString.Trim)
                                                    If row("LesseeStateCd").ToString.Trim <> "" Then LesseeInfo.Append(", ").Append(row("LesseeStateCd").ToString.Trim)
                                                    If row("LesseeZip").ToString.Trim <> "" Then LesseeInfo.Append("  ").Append(row("LesseeZip").ToString.Trim)
                                                End If
                                            End If
                                            sSQL = sSQL & QuoStr(LesseeInfo.ToString) & ","                         'Text06
                                            sSQL = sSQL & row("BPPRatio") & "," & QuoStr(Format(row("BPPRatio"), csPct)) & ",0,"        'number07, text05, number09
                                            'BarCode1,BarCode2,BarCodeDesc
                                            If bPrintCoverPage Then
                                                sSQL = sSQL & QuoStr(BuildBarCode1(enumBarCodeTypes.Rendition, row("ClientId"), iTaxYear,
                                                    enumTable.enumLocationBPP, row("LocationId"), row("AssessmentId"), 0, 0)) & "," &
                                                    QuoStr(BuildBarCode2(enumBarCodeTypes.Rendition, row("ClientId"), iTaxYear,
                                                        enumTable.enumLocationBPP, row("LocationId"), row("AssessmentId"), 0, 0)) & "," &
                                                    QuoStr(BuildBarCodeDesc(enumBarCodeTypes.Rendition, " for " & sName,
                                                        row("Clients_Name"), iTaxYear, row("Locations_Address"),
                                                        row("Locations_City"), row("Locations_StateCd"), row("Assessments_AcctNum"),
                                                        row("Locations_ClientLocationId"), row("Assessors_Name"), ""))
                                            Else
                                                sSQL = sSQL & "'','',''"
                                            End If
                                            'Number10
                                            If bHasInterstateAllocationPct Then
                                                sSQL = sSQL & "," & row("InterstateAllocationPct" & iScheduleCounter)
                                            Else
                                                sSQL = sSQL & ",1"
                                            End If
                                            'Number11
                                            sSQL = sSQL & "," & lFactoredAmtBeforeInterstateAllocationPct
                                            'Number12
                                            sSQL = sSQL & "," & IIf(bHasInterstateAllocationPct, 0, 1)        ''if has allocation, show columns (1=suppress)
                                            'flag is to suppress, so set to 0 if want to see columns
                                            'Number13
                                            If bShowCostAndFactors Or eType = enumReport.enumAssetDetailExempt Or eType = enumReport.enumAssetDetailNon Then
                                                sSQL = sSQL & ",0"
                                            Else
                                                sSQL = sSQL & ",1"
                                            End If
                                            ExecuteSQL(sSQL)
                                        ElseIf eType = enumReport.enumAssetDetailLeasedProperty Or
                                                eType = enumReport.enumAssetDetailLeaseholdImprovements Or
                                                eType = enumReport.enumAssetDetailLeasesAll Then
                                            sql.Clear()
                                            If row("LeaseType").ToString = LEASEHOLDIMPROVEMENTS Then
                                                sTitle = "Leasehold Improvements - Tax Year " & iTaxYear
                                            Else
                                                sTitle = "Leased Property Belonging to Others - Tax Year " & iTaxYear
                                            End If
                                            sTitle = sTitle & vbCrLf & row("LegalOwner") &
                                                IIf(row("Locations_ClientLocationId").ToString().Trim().Length > 0, vbCrLf & row("Locations_ClientLocationId").ToString().Trim(), "") &
                                                vbCrLf & row("Locations_Address") &
                                                vbCrLf & row("Locations_City") & ", " & row("Locations_StateCd") & vbCrLf &
                                                row("Assessors_Name") & "  " & row("Assessments_AcctNum")
                                            sql.Append("INSERT INTO ReportData (UserName,ReportId,RowCounter,Title01,Text01,Text02,Text03,Text04,Text05,Text06,")
                                            sql.Append("Date01,Number01,Number02,Number03) SELECT ")
                                            sql.Append(QuoStr(AppData.UserId)).Append(",").Append(AppData.ReportId).Append(",")
                                            sql.Append(lRowCounter.ToString).Append(",").Append(QuoStr(sTitle)).Append(",")
                                            sql.Append(QuoStr(row("AssetId"))).Append(",").Append(QuoStr(row("GLCode").ToString)).Append(",")
                                            sql.Append(QuoStr(row("Description").ToString)).Append(",").Append(QuoStr(row("LesseeName").ToString)).Append(",")
                                            sql.Append(QuoStr(row("LesseeAddress").ToString)).Append(",")
                                            sDesc = row("EquipmentMake").ToString & " " & row("EquipmentModel").ToString
                                            If dt.Columns.Contains("VIN") Then sDesc = sDesc & " " & row("VIN").ToString
                                            sql.Append(QuoStr(sDesc)).Append(",")
                                            sql.Append(QuoStr(Convert.ToDateTime(row("PurchaseDate")).ToString(csDate))).Append(",")
                                            sql.Append(IIf(row("LeaseType").ToString = LEASEHOLDIMPROVEMENTS, 0, 1)).Append(",")
                                            sql.Append(dOriginalAmt.ToString).Append(",")
                                            sql.Append(UnNullToDouble(row("LeaseTerm")))
                                            ExecuteSQL(sql.ToString)
                                        ElseIf eType = enumReport.enumLeaseSummary Then
                                            sql.Clear() : citystate.Clear()
                                            'sTitle = sTitle & vbCrLf & row("LegalOwner") &
                                            '    IIf(row("Locations_ClientLocationId").ToString().Trim().Length > 0, vbCrLf & row("Locations_ClientLocationId").ToString().Trim(), "") &
                                            '    vbCrLf & row("Locations_Address") &
                                            '    vbCrLf & row("Locations_City") & ", " & row("Locations_StateCd") & vbCrLf &
                                            '    row("Assessors_Name") & "  " & row("Assessments_AcctNum")
                                            sql.Append("INSERT INTO ReportData (UserName,ReportId,RowCounter,Title01,Text01,Number01,Number02) SELECT ")
                                            sql.Append(QuoStr(AppData.UserId)).Append(",").Append(AppData.ReportId).Append(",")
                                            sql.Append(lRowCounter.ToString).Append(",").Append(QuoStr(sTitle)).Append(",")
                                            'Text01
                                            If dt.Columns.Contains("LesseeCity") Then
                                                If row("LesseeCity").ToString <> "" Then citystate.Append(row("LesseeCity").ToString)
                                            End If
                                            If dt.Columns.Contains("LesseeStateCd") Then
                                                If row("LesseeStateCd").ToString() <> "" Then citystate.Append(", ").Append(row("LesseeStateCd").ToString)
                                            End If
                                            sql.Append(QuoStr(citystate.ToString())).Append(",")
                                            'Number01 and Number02
                                            If sFactorCode = "INV" Or sFactorCode = "INVENTORY" Then
                                                sql.Append("0,").Append(dFactoredAmt)
                                            Else
                                                sql.Append(dFactoredAmt).Append(",0")
                                            End If
                                            ExecuteSQL(sql.ToString)
                                        End If
                                    End If
                                Next
                                '''''set total assessed value (total * bppratio) and whether has inv
                                ''''If eType = enumReport.enumAssetDetailCost Then
                                ''''    sSQL = "DECLARE @Sum float SELECT @Sum = (SELECT SUM(ISNULL(Number01,0))" &
                                ''''        " FROM ReportData WHERE UserName = " & QuoStr(AppData.UserId) &
                                ''''        " AND ReportId = " & AppData.ReportId & ")" &
                                ''''        " UPDATE ReportData SET Number08 = ROUND(@Sum * ISNULL(Number07,0),0)," &
                                ''''        " Number09 = " & IIf(bHasINV, "1", "0") &
                                ''''        " WHERE UserName = " & QuoStr(AppData.UserId) & " AND ReportId = " & AppData.ReportId
                                ''''    ExecuteSQL(sSQL)
                                ''''End If

                                ''''If eType = enumReport.enumAssetSummary Then
                                ''''    If bHasFixed = False Then
                                ''''        Dim invrow As DataRow
                                ''''        If dt.Rows.Count > 0 Then
                                ''''            invrow = dt.Rows(0)
                                ''''            sTotalAssessorRatio = "Total at " & Format(invrow("BPPRatio"), csPct) & " ratio"
                                ''''            sSQL = "insert into ReportData (UserName,ReportId,RowCounter,Title01,Text01,Text03,Number01," &
                                ''''                "Number02,Number03,Number04,Number05,Number06,Number07,Text10,Text04,Number15,Number08,Text09," &
                                ''''                "Number09, Number10," &
                                ''''                "BarCode1,BarCode2,BarCodeDesc) SELECT " &
                                ''''                QuoStr(AppData.UserId) & "," & AppData.ReportId & "," &
                                ''''                1 & "," & QuoStr(sTitle) & "," &
                                ''''                QuoStr("") & "," &
                                ''''                QuoStr("No fixed assets") & "," &
                                ''''                0 & "," & 0 & "," & iSuppressOriginalCost & "," &
                                ''''                0 & "," & 0 & "," &
                                ''''                IIf(iScheduleCounter = 1 And bPrintingClientValue = True, dClientINV, dINV) & "," &
                                ''''                invrow("BPPRatio") & "," &
                                ''''                QuoStr("") & "," &
                                ''''                QuoStr(sTotalAssessorRatio) & "," &
                                ''''                IIf(iScheduleCounter = 1 And bPrintingClientValue = True, dClientINV, dINV) & "," &
                                ''''                iINVYear & "," &
                                ''''                QuoStr(Format(invrow("BPPRatio"), csPct)) & ","
                                ''''            'Number09    allocation suppress switch
                                ''''            sSQL = sSQL & IIf(bHasInterstateAllocationPct, 0, 1) & ","        ''if has allocation, show columns (1=suppress)
                                ''''            'Number10    cost after allocation, same as number01
                                ''''            sSQL = sSQL & "0,"

                                ''''            If bPrintCoverPage Then
                                ''''                sSQL = sSQL & QuoStr(BuildBarCode1(enumBarCodeTypes.Rendition, invrow("ClientId"), iTaxYear,
                                ''''                    enumTable.enumLocationBPP, invrow("LocationId"), invrow("AssessmentId"), 0, 0)) & "," &
                                ''''                QuoStr(BuildBarCode2(enumBarCodeTypes.Rendition, invrow("ClientId"), iTaxYear,
                                ''''                    enumTable.enumLocationBPP, invrow("LocationId"), invrow("AssessmentId"), 0, 0)) & "," &
                                ''''                QuoStr(BuildBarCodeDesc(enumBarCodeTypes.Rendition, " for " & sName,
                                ''''                invrow("Clients_Name"), iTaxYear, invrow("Locations_Address"),
                                ''''                invrow("Locations_City"), invrow("Locations_StateCd"), invrow("Assessments_AcctNum"),
                                ''''                invrow("Locations_ClientLocationId"), invrow("Assessors_Name"), ""))
                                ''''            Else
                                ''''                sSQL = sSQL & "'','',''"
                                ''''            End If
                                ''''            ExecuteSQL(sSQL)
                                ''''        End If
                                ''''    Else
                                ''''        'Set field for total of inventory and fixed assets
                                ''''        sSQL = "UPDATE ReportData SET Number15 = (SELECT SUM(Number01) FROM ReportData" &
                                ''''            " WHERE UserName = " & QuoStr(AppData.UserId) & " AND ReportId = " & AppData.ReportId & ")" &
                                ''''            " + " & IIf(iScheduleCounter = 1 And bPrintingClientValue = True, dClientINV, dINV) & " WHERE " &
                                ''''            " UserName = " & QuoStr(AppData.UserId) & " AND ReportId = " & AppData.ReportId & " "
                                ''''        ExecuteSQL(sSQL)
                                ''''    End If
                                ''''    'set total asset value (fixed plus inventory) times the assessor ratio
                                ''''    sSQL = "UPDATE ReportData SET Number16 = ROUND(ISNULL(Number15,0) * ISNULL(Number07,0),0)" &
                                ''''        " WHERE UserName = " & QuoStr(AppData.UserId) & " AND ReportId = " & AppData.ReportId
                                ''''    ExecuteSQL(sSQL)
                                ''''End If

                                If eType = enumReport.enumAssetDetail Or eType = enumReport.enumAssetSummary Or eType = enumReport.enumAssetDetailCost Or
                                            eType = enumReport.enumAssetDetailExempt Or eType = enumReport.enumAssetDetailNon Or
                                            eType = enumReport.enumAssetDetailLeasedProperty Or
                                            eType = enumReport.enumAssetDetailLeaseholdImprovements Or
                                            eType = enumReport.enumAssetDetailLeasesAll Or
                                            eType = enumReport.enumLeaseSummary Then
                                    sAssetExportFile =
                                        Replace(sPDFFileName, ".pdf", "_" & sName & ".pdf", , , CompareMethod.Text)
                                    OpenReport(eType, sReportText & " " & sName & "  " & sAcctNum, bSendToPrinter,
                                        sAssetExportFile, sExportFolder)
                                End If
                                If iScheduleCounter > 1 _
                                        Or (iScheduleCounter = 1 And bPrintingClientValue = False) _
                                        Or bPrintClientScheduleOnly _
                                        Or eType = enumReport.enumAssetDetailLeasedProperty _
                                        Or eType = enumReport.enumAssetDetailLeaseholdImprovements _
                                        Or eType = enumReport.enumAssetDetailLeasesAll Then
                                    Exit Do
                                End If
                                bPrintingClientValue = False
                            Loop
                        End If
                    End If
                Next
            End If

            If bUpdateClientReporting Then
                UpdateClientReporting(eType, lClientId, lLocationId, lAssessmentId, iTaxYear, ePropType, clsReport.ReportDataTable)



            Else
                'new clsreport reports
                If eType = enumReport.enumTaxAccrual Or eType = enumReport.enumBPPCompBarCode Or eType = enumReport.enumTaxSavings Or eType = enumReport.enumBarCode Or
                    eType = enumReport.enumCompletedRenditions Or eType = enumReport.enumFixedAssetReconByGLCode Or eType = enumReport.enumFixedAssetReconByDeprCode Or
                    eType = enumReport.enumValueComparison Or
                    eType = enumReport.enumMissingTaxBills Or eType = enumReport.enumREComp Then
                    OpenReport(eType, sReportText, bSendToPrinter, sPDFFileName, sExportFolder, clsReport.ReportDataTable)
                ElseIf eType = enumReport.enumTaxBill Then
                    If OpenReport(eType, sReportText, bSendToPrinter, sPDFFileName, sExportFolder, clsReport.ReportDataTable) Then
                        SetTaxBillPrintedDate(lClientId, lLocationId, lAssessmentId, JurisdictionList, iTaxYear, ePropType)
                    End If
                ElseIf eType = enumReport.enumTaxBillCheckOff Then
                    OpenReport(eType, sReportText, bSendToPrinter, sPDFFileName, sExportFolder)
                    'V1 doesn't seem to be importing tax bills in the app
                    'Dim sCombinedForm As String = AppendTaxBills(dt, ePropType, AppData.TempPath & "\" & sPDFFileName)
                    'If FileIO.FileSystem.FileExists(sCombinedForm) Then
                    '    If sExportFolder <> "" Then FileIO.FileSystem.CopyFile(sCombinedForm, sExportFolder & IIf(Microsoft.VisualBasic.Right(sExportFolder, 1) = "\", "", "\") & sPDFFileName, True)
                    '    If Not RunAdobe(sCombinedForm, bSendToPrinter) Then
                    '        Return False
                    '    Else
                    '        Return True
                    '    End If
                    'End If
                ElseIf eType = enumReport.enumAssessorEnvelope Or eType = enumReport.enumAssessorValueProtestEnvelope Or eType = enumReport.enumClientEnvelope Or
                        eType = enumReport.enumMissingNotice Or
                        eType = enumReport.enumAssessorCover Or
                        eType = enumReport.enumRenditionDueDate Or eType = enumReport.enumClientLocationListing Or eType = enumReport.enumTaxAccrualSummary Then
                    OpenReport(eType, sReportText, bSendToPrinter, sPDFFileName, sExportFolder, False, bJustCreatePDF)
                End If
            End If

        Catch ex As Exception
            If AppData.ClientReportingServer Then
                Dim msg As New StringBuilder
                msg.Append("Error running client reporting in RunReport:").Append(" reporttype=").Append(eType)
                msg.Append(" clientid=").Append(lClientId).Append("locationid=").Append(lLocationId).Append("assessmentid=").Append(lAssessmentId)
                msg.Append(":  ").Append(ex.Message)
                LogMsg(msg.ToString)
            Else
                MsgBox("Error running report:  " & ex.Message)
            End If
        End Try

        If AppData.ClientReportingServer = False Then MDIParent1.ShowStatus()
        Return True


    End Function
    Public Function OpenReport(ByVal eType As enumReport, ByVal sText As String,
            ByVal bSendToPrinter As Boolean, ByVal sPDFFileName As String, ByVal sExportFolder As String,
            ByVal bShowPDF As Boolean, bJustCreatePDF As Boolean) As Boolean
        Return OpenReport(eType, sText, bSendToPrinter, sPDFFileName, sExportFolder, False, bJustCreatePDF, New DataTable)
    End Function
    Public Function OpenReport(ByVal eType As enumReport, ByVal sText As String,
            ByVal bSendToPrinter As Boolean, ByVal sPDFFileName As String, ByVal sExportFolder As String) As Boolean
        Return OpenReport(eType, sText, bSendToPrinter, sPDFFileName, sExportFolder, False, False, New DataTable)
    End Function

    Public Function OpenReport(ByVal eType As enumReport, ByVal sText As String,
            ByVal bSendToPrinter As Boolean, ByVal sPDFFileName As String, ByVal sExportFolder As String, ByVal dtReportData As DataTable) As Boolean
        Return OpenReport(eType, sText, bSendToPrinter, sPDFFileName, sExportFolder, False, False, dtReportData)
    End Function


    Public Function OpenReport(ByVal eType As enumReport, ByVal sText As String,
            ByVal bSendToPrinter As Boolean, ByVal sPDFFileName As String, ByVal sExportFolder As String,
            ByVal bShowPDF As Boolean, bJustCreatePDF As Boolean, ByVal dtReportData As DataTable) As Boolean
        'Try
        '    If bSendToPrinter Or sExportFolder <> "" Or bJustCreatePDF Then
        '        Dim sReportFile As String = ""
        '        'Dim frmtest As New Form
        '        'frmtest.Text = "Report:  " & sText
        '        'frmtest.Height = 600
        '        'frmtest.Width = 900
        '        'frmtest.StartPosition = FormStartPosition.CenterScreen

        '        If Not ConfigureReport(eType, bSendToPrinter, bShowPDF, sPDFFileName, bJustCreatePDF, sExportFolder, dtReportData, sReportFile, dtReportData) Then
        '            Return False
        '        End If

        '        Dim crDoc As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        '        crDoc.FileName = sReportFile
        '        crDoc.SetDataSource(dtReportData)
        '        If sExportFolder <> "" Or bJustCreatePDF Then
        '            crDoc.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, sExportFolder & "\" & sPDFFileName)
        '        Else
        '            crDoc.PrintToPrinter(1, False, 1, 0)
        '        End If

        '        'Dim crViewer As New CrystalDecisions.Windows.Forms.CrystalReportViewer
        '        'crViewer.ReportSource = crDoc

        '        'If bSendToPrinter Then crViewer.PrintReport()

        '        'crViewer.Dispose()
        '        crDoc.Dispose()


        '        'frmtest.Controls.Add(crViewer)
        '        'frmtest.Visible = False
        '        'frmtest.MdiParent = MDIParent1
        '        'frmtest.Show()
        '        'AppData.ReportId = AppData.ReportId + 1
        '        'frmtest.Close()
        '        'frmtest.Dispose()


        '        'Return True

        '    Else

        '        Dim frm As frmReport
        '        frm = New frmReport
        '        frm.ReportType = eType
        '        frm.ReportData = dtReportData
        '        frm.Text = "Report:  " & sText
        '        frm.SendToPrinter = bSendToPrinter
        '        frm.ExportFolder = sExportFolder
        '        frm.PDFFileName = sPDFFileName
        '        frm.ShowPDF = bShowPDF
        '        frm.JustCreatePDF = bJustCreatePDF
        '        frm.MdiParent = MDIParent1
        '        frm.Show()
        '    End If

        '    AppData.ReportId = AppData.ReportId + 1
        '    Return True
        'Catch ex As Exception
        '    MsgBox("Error opening report:  " & ex.Message)
        '    Return False
        'End Try
        Return True
    End Function

    Public Function ConfigureReport(eType As enumReport, bSendToPrinter As Boolean, bShowPDF As Boolean, sPDFFileName As String,
            bJustCreatePDF As Boolean, sExportFolder As String, dt As DataTable, ByRef sReportPathFile As String, ByRef dtReportData As DataTable) As Boolean

        Dim sWHERE As String = " WHERE UserName = " & QuoStr(AppData.UserId) & " AND ReportId = " & AppData.ReportId & " "
        Dim sReportPath As String = "", sReportFile As String = ""
        Dim sSQL As String = ""

        'reports exist in app path for exe, in reports folder during debug
        Select Case eType
            Case enumReport.enumAssetDetail
                sSQL = "select * from ReportData" & sWHERE & " ORDER BY ID"
                sReportFile = "rptAssetDetail.rpt"
            Case enumReport.enumAssetImport
                sSQL = "select * from ReportData" & sWHERE & " ORDER BY Title01,Text06"
                sReportFile = "rptAssetImportSummary.rpt"
            Case enumReport.enumAssetSummary
                sSQL = "SELECT Title01, Text02, Text05, Text03, Text10, Number04, Number03, Number05, Number06, Number07, Text04, Number15, Number16, Number08, Text09, Number09, Number11," &
                    " BarCode1,BarCode2,BarCodeDesc," &
                    " Sum(Number01) AS Number01, Sum(Number02) AS Number02, SUM(Number10) AS Number10" &
                    " FROM ReportData" & sWHERE & "  GROUP BY Title01, Text02, Text05, Text03, Text10, Number04, Number03, Number05," &
                    " Number06, Number07, Text04, Number15, Number16, Number08, Text09, Number09, Number11, BarCode1, BarCode2, BarCodeDesc ORDER BY Text02, Text05 DESC, Text03, Number04 DESC"
                ''sSQL = "select * from ReportData" & sWHERE
                sReportFile = "rptAssetSummary.rpt"
            Case enumReport.enumAssetDetailExempt, enumReport.enumAssetDetailNon
                sSQL = "SELECT * FROM ReportData" & sWHERE & "  ORDER BY Text04, Number04 desc, Text01"
                sReportFile = "rptAssetDetailCost.rpt"
            Case enumReport.enumAssetDetailLeasedProperty, enumReport.enumAssetDetailLeaseholdImprovements, enumReport.enumAssetDetailLeasesAll
                sSQL = "SELECT Title01, Text01,Text02,Text03,Text04,Text05,Text06,Date01,Number01,Number02,Number03,NoRows" &
                    " FROM ReportData" & sWHERE & "  ORDER BY Title01, Text01"
                sReportFile = "rptAssetLeases.rpt"
            Case enumReport.enumAssetDetailCost
                sSQL = "SELECT * FROM ReportData" & sWHERE
                sReportFile = "rptAssetDetailCost.rpt"
            Case enumReport.enumLeaseSummary
                sSQL = "SELECT Title01, Text01, Sum(Number01) AS Number01, Sum(Number02) AS Number02 FROM ReportData" & sWHERE & " GROUP BY Title01, Text01 ORDER BY Text01"
                sReportFile = "rptAssetLeasesSummary.rpt"
            Case enumReport.enumTaxBill
                'sSQL = "Select * from ReportData" & sWHERE & " ORDER BY ID"
                sReportFile = "rptTaxBillTransmittal.rpt"
            Case enumReport.enumBarCode
                sSQL = "Select * from ReportData" & sWHERE & " ORDER BY ID"
                sReportFile = "rptBarCode.rpt"
            Case enumReport.enumTaxBillCheckOff
                sSQL = "Select * from ReportData" & sWHERE & " ORDER BY ID"
                sReportFile = "rptTaxBillCheckOff.rpt"
            Case enumReport.enumRenditionDueDate
                sSQL = "Select Date01, Text01, Text02, Text03, Text04, Text05, Text06, Text07, Text08, Title01, NoRows FROM ReportData " &
                    sWHERE & " ORDER BY Text08, Date01, Text04, Text07, Text02"
                sReportFile = "rptRenditionDueDate.rpt"
            Case enumReport.enumMissingTaxBills
                sReportFile = "rptMissingTaxBills.rpt"
            Case enumReport.enumClientLocationListing
                sSQL = "Select Title01, Text01, Text02, Text03, Text04, Text05, Text06, Text07, Text08, Text09, NoRows FROM ReportData " &
                    sWHERE & " ORDER BY Text01, Text05, Text03, Text04, Text08, Text07"
                sReportFile = "rptClientLocationListing.rpt"
            Case enumReport.enumMissingNotice
                sSQL = "Select Date01, Text01, Text02, Text03, Text04, Text05, Text06, Text07, Text08, Text09, Title01, NoRows FROM ReportData " &
                    sWHERE & " ORDER BY Text09, Date01, Text07, Text02"
                sReportFile = "rptMissingNotice.rpt"
            Case enumReport.enumAssessorEnvelope, enumReport.enumAssessorValueProtestEnvelope, enumReport.enumClientEnvelope
                sSQL = "Select Text01, Text02, Text03, Text04, Text05, Text06, Text07, Text08 FROM ReportData " & sWHERE & " ORDER BY ID"
                sReportFile = "rptAssessorEnvelope.rpt"
            Case enumReport.enumAssessorCover
                sSQL = "Select Text01,Text02,Text03,Text04,Text05,Text06,Text07,Text08,Text09,Text10,Text11,Text12,Text13" &
                    " FROM ReportData " & sWHERE
                sReportFile = "rptAssessorEnvelope.rpt"
            Case enumReport.enumFixedAssetReconByGLCode, enumReport.enumFixedAssetReconByDeprCode
                sReportFile = "rptFixedAssetRecon.rpt"
            Case enumReport.enumTaxAccrual
                sReportFile = "rptTaxAccrual.rpt"
            Case enumReport.enumTaxAccrualSummary
                sReportFile = "rptTaxAccrualSummary.rpt"
                sSQL = "Select * from ReportData" & sWHERE
            Case enumReport.enumTaxSavings
                sReportFile = "rptTaxSavings.rpt"
            Case enumReport.enumAppointmentOfAgentForm
                sSQL = "Select Title01,Text01,Text02,Number01 FROM ReportData " & sWHERE
                sReportFile = "rptAofADetail.rpt"
            Case enumReport.enumREComp
                sReportFile = "rptREComps.rpt"
            Case enumReport.enumBPPCompBarCode
                sReportFile = "rptBarCode.rpt"
            Case enumReport.enumCompletedRenditions
                sReportFile = "rptCompletedRenditionDueDate.rpt"
            Case enumReport.enumValueComparison
                sReportFile = "rptRenditionValueComparison.rpt"
        End Select

        'new clsreport reports
        If eType = enumReport.enumTaxAccrual Or eType = enumReport.enumBPPCompBarCode Or eType = enumReport.enumTaxSavings Or eType = enumReport.enumBarCode _
                Or eType = enumReport.enumCompletedRenditions Or eType = enumReport.enumFixedAssetReconByGLCode Or eType = enumReport.enumFixedAssetReconByDeprCode _
                Or eType = enumReport.enumValueComparison _
                Or eType = enumReport.enumMissingTaxBills Or eType = enumReport.enumTaxBill Or eType = enumReport.enumREComp Then
            dtReportData = dt
        Else
            Dim clsReport As New clsReportDataSet
            clsReport.SQL = sSQL
            Dim ds As DataSet = clsReport.GetReportDataSet
            dtReportData = ds.Tables(0)
        End If

        sReportPath = AppData.AppPath & "\"
        If Not IO.File.Exists(sReportPath & sReportFile) Then
            sReportPath = "C:\OurFolders\VantageOne\AssessmentManager\AssessmentManager\Reports\"
            If Not IO.File.Exists(sReportPath & sReportFile) Then
                sReportPath = "C:\OurFolders\VantageOne\Assessment Manager\Assessment Manager\Reports\"
                If Not IO.File.Exists(sReportPath & sReportFile) Then
                    sReportPath = "C:\MyFiles\VantageOne\Assessment Manager\Assessment Manager\Reports\"
                End If
            End If
        End If
        sReportPathFile = sReportPath & sReportFile
        If Not IO.File.Exists(sReportPathFile) Then
            MsgBox("Report not found:  " & sReportPathFile)
            Return False
        End If
        Return True
    End Function

    Public Sub RunClientReporting()
        Dim msg As String
        Try
            If Hour(Now) <> 2 Then Return

            Dim starttime As String = Now.ToString("f")
            msg = "Starting client reporting process, " + starttime
            MDIParent1.ShowStatus(msg)
            LogMsg(msg)
            Dim sql As New StringBuilder()
            Dim dt As New DataTable
            sql.Append("SELECT 1 AS DoRun WHERE")
            sql.Append(" (DATEDIFF(HOUR,(SELECT MAX(AddDate) FROM ClientReporting..TaxAccrualDetail),GETDATE()) > 18)")
            sql.Append(" OR ((SELECT COUNT(*) FROM ClientReporting..TaxAccrualDetail) = 0)")
            sql.Append(" OR (DATEDIFF(HOUR,(SELECT MAX(AddDate) FROM ClientReporting..TaxSavingsDetail),GETDATE()) > 18)")
            sql.Append(" OR ((SELECT COUNT(*) FROM ClientReporting..TaxSavingsDetail) = 0)")
            GetData(sql.ToString, dt)
            If dt.Rows.Count = 0 Then
                LogMsg("Has not been long enough since reporting last run")
                dt.Dispose()
                Return
            End If
            If dt.Rows(0)(0) <> 1 Then
                dt.Dispose()
                Return
            End If

            Dim msgcounter As Integer = 0, counterpct = 0, rowcount = 0, rowcounter = 0

            Dim colAssessments As New Collection, structAssess As New structAssessment
            LogMsg("Deleting previous reporting data")
            sql.Clear()
            sql.Append("TRUNCATE TABLE ClientReporting..TaxAccrualDetail")
            sql.Append(" TRUNCATE TABLE ClientReporting..TaxSavingsDetail")
            ExecuteSQL(sql.ToString)
            ''get bpp accounts
            LogMsg("Starting BPP reporting")
            sql.Clear()
            sql.Append("SELECT Clients.ClientId, LocationsBPP.LocationId, LocationsBPP.TaxYear, AssessmentsBPP.AssessmentId, ISNULL(Assessors.AssessorId,0) AS AssessorId, LocationsBPP.StateCd")
            sql.Append(" FROM Clients INNER JOIN LocationsBPP ON Clients.ClientId = LocationsBPP.ClientId")
            sql.Append(" INNER JOIN AssessmentsBPP ON LocationsBPP.ClientId = AssessmentsBPP.ClientId And LocationsBPP.LocationId = AssessmentsBPP.LocationId AND")
            sql.Append(" LocationsBPP.TaxYear = AssessmentsBPP.TaxYear")
            sql.Append(" LEFT OUTER JOIN Assessors ON AssessmentsBPP.AssessorId = Assessors.AssessorId And AssessmentsBPP.TaxYear = Assessors.TaxYear")
            sql.Append(" WHERE LocationsBPP.TaxYear >= ").Append(Year(Now) - 1)
            sql.Append(" AND ISNULL(Clients.ProspectFl,0)=0 AND ISNULL(Clients.InactiveFl,0)=0")
            sql.Append(" AND ISNULL(LocationsBPP.InactiveFl,0)= 0 And ISNULL(AssessmentsBPP.InactiveFl, 0) = 0")
            GetData(sql.ToString, dt)

            rowcount = dt.Rows.Count
            LogMsg("Found " & rowcount & " BPP accounts")
            msgcounter = 0 : rowcounter = 0
            For Each dr As DataRow In dt.Rows
                With structAssess
                    .ClientId = dr("ClientId")
                    .TaxYear = dr("TaxYear")
                    .LocationId = dr("LocationId")
                    .AssessmentId = dr("AssessmentId")
                    .Description = ""
                    .AssessorId = dr("AssessorId")
                    .StateCd = dr("StateCd")
                    .PropType = ""
                End With
                RunReport(enumReport.enumTaxAccrual, structAssess.ClientId, structAssess.LocationId, structAssess.AssessmentId,
                        structAssess.JurisdictionList, structAssess.TaxYear, enumTable.enumLocationBPP, structAssess.AssessorId, False, False,
                        "", "", 0, False, enumContactTypes.enumTax, enumBarCodeTypes.AOA, False, New DataTable, False, AppData.IncludeInactive,
                        0, "", False, False, True)
                RunReport(enumReport.enumTaxSavings, structAssess.ClientId, structAssess.LocationId, structAssess.AssessmentId,
                        structAssess.JurisdictionList, structAssess.TaxYear, enumTable.enumLocationBPP, structAssess.AssessorId, False, False,
                        "", "", 0, False, enumContactTypes.enumTax, enumBarCodeTypes.AOA, False, New DataTable, False, AppData.IncludeInactive,
                        0, "", False, False, True)
                rowcounter = rowcounter + 1
                msgcounter = msgcounter + 1
                If msgcounter > 50 Then
                    counterpct = rowcounter / rowcount * 100
                    msg = "Running BPP client reporting process, " & counterpct & "% complete, started at " & starttime
                    MDIParent1.ShowStatus(msg)
                    LogMsg(msg)
                    msgcounter = 0
                End If
            Next
            LogMsg("Finished client reporting for BPP")

            ''get re accounts
            starttime = Now.ToString("f")
            msg = "Starting client reporting process for RE, " + starttime
            MDIParent1.ShowStatus(msg)
            LogMsg(msg)
            sql.Clear()
            sql.Append("SELECT Clients.ClientId, LocationsRE.LocationId, LocationsRE.TaxYear, AssessmentsRE.AssessmentId, ISNULL(Assessors.AssessorId,0) AS AssessorId, LocationsRE.StateCd")
            sql.Append(" FROM Clients INNER JOIN LocationsRE ON Clients.ClientId = LocationsRE.ClientId")
            sql.Append(" INNER JOIN AssessmentsRE ON LocationsRE.ClientId = AssessmentsRE.ClientId And LocationsRE.LocationId = AssessmentsRE.LocationId And")
            sql.Append(" LocationsRE.TaxYear = AssessmentsRE.TaxYear")
            sql.Append(" LEFT OUTER JOIN Assessors ON AssessmentsRE.AssessorId = Assessors.AssessorId And AssessmentsRE.TaxYear = Assessors.TaxYear")
            sql.Append(" WHERE LocationsRE.TaxYear >= ").Append(Year(Now) - 1)
            sql.Append(" And ISNULL(Clients.ProspectFl,0)=0 And ISNULL(Clients.InactiveFl,0)=0")
            sql.Append(" And ISNULL(LocationsRE.InactiveFl,0)= 0 And ISNULL(AssessmentsRE.InactiveFl, 0) = 0")
            GetData(sql.ToString, dt)

            rowcount = dt.Rows.Count
            LogMsg("Found " & rowcount & " RE accounts")
            msgcounter = 0 : rowcounter = 0
            For Each dr As DataRow In dt.Rows
                With structAssess
                    .ClientId = dr("ClientId")
                    .TaxYear = dr("TaxYear")
                    .LocationId = dr("LocationId")
                    .AssessmentId = dr("AssessmentId")
                    .Description = ""
                    .AssessorId = dr("AssessorId")
                    .StateCd = dr("StateCd")
                    .PropType = ""
                End With
                RunReport(enumReport.enumTaxAccrual, structAssess.ClientId, structAssess.LocationId, structAssess.AssessmentId,
                        structAssess.JurisdictionList, structAssess.TaxYear, enumTable.enumLocationRE, structAssess.AssessorId, False, False,
                        "", "", 0, False, enumContactTypes.enumTax, enumBarCodeTypes.AOA, False, New DataTable, False, AppData.IncludeInactive,
                        0, "", False, False, True)
                RunReport(enumReport.enumTaxSavings, structAssess.ClientId, structAssess.LocationId, structAssess.AssessmentId,
                        structAssess.JurisdictionList, structAssess.TaxYear, enumTable.enumLocationRE, structAssess.AssessorId, False, False,
                        "", "", 0, False, enumContactTypes.enumTax, enumBarCodeTypes.AOA, False, New DataTable, False, AppData.IncludeInactive,
                        0, "", False, False, True)
                rowcounter = rowcounter + 1
                msgcounter = msgcounter + 1
                If msgcounter > 50 Then
                    counterpct = rowcounter / rowcount * 100
                    msg = "Running RE client reporting process, " & counterpct & "% complete, started at " & starttime
                    MDIParent1.ShowStatus(msg)
                    LogMsg(msg)
                    msgcounter = 0
                End If
            Next
            dt.Dispose()
            LogMsg("Finished client reporting for RE")
            MDIParent1.ShowStatus()
        Catch ex As Exception
            LogMsg("Error running client reporting:  " & ex.Message)
        End Try
    End Sub

    Private Function RunTaxAccrualSummaryReport(clsReport As clsReportData) As Boolean
        Dim sTempTable As String = ""
        Dim sql As New StringBuilder, sqlins As New StringBuilder
        Dim lRows As Long
        Dim dt As New DataTable

        Try
            sTempTable = ""
            Do
                sTempTable = "#tmpAccrualSummary" & AppData.UserId & Date.Now.Ticks.ToString
                ''sTempTable = "tempdb..accrualSummarytmp"
                sql.Clear()
                sql.Append("SELECT 1 WHERE EXISTS (SELECT Name FROM sys.objects where name Like '%").Append(sTempTable).Append("%')")
                lRows = GetData(sql.ToString, dt)
                If lRows = 0 Then Exit Do
            Loop
            sql.Clear()
            'SAME TEMP TABLE IN TAX ACCRUAL REPORT CHECK THERE FOR CHANGES
            sql.Append("CREATE TABLE ").Append(sTempTable).Append(" ([Text01] [varchar](255) NULL,[Text02] [varchar](255) NULL,[Text03] [varchar](255) NULL,")
            sql.Append("[Text04] [varchar](255) NULL,[Text05] [varchar](255) NULL,[Text06] [varchar](255) NULL,[Text07] [varchar](255) NULL,[Text08] [varchar](255) NULL,")
            sql.Append("[Text09] [varchar](255) NULL,[Text10] [varchar](255) NULL,[Text15] [varchar](255) NULL,[Number01] [float] NULL,[Number02] [float] NULL,")
            sql.Append("[Number03] [float] NULL,[Number04] [float] NULL,[Number09] [float] NULL,[Number10] [float] NULL,[Number11] [float] NULL,[Number14] [float] NULL,")
            sql.Append("[Number15] [float] NULL,[Number16] [float] NULL,[Number17] [float] NULL,[Number18] [float] NULL,[Number19] [float] NULL,Number20 float null")
            sql.Append(",[Date01] [datetime] NULL, Number12 float null")
            sql.Append(")")
            ExecuteSQL(sql.ToString)

            'Copy contents of report class into temp table
            lRows = 0
            sqlins.Clear()
            sqlins.Append("INSERT INTO ").Append(sTempTable).Append(" ([Text01],[Text02],[Text03],[Text04],[Text05],[Text06],[Text07],[Text08],[Text09],[Text10],")
            sqlins.Append("[Text15],[Number01],[Number02],[Number03],[Number04],[Number09],[Number10],[Number11],[Number14],[Number15],[Number16],[Number17],")
            sqlins.Append("[Number18],[Number19],Number20,Date01,Number12) VALUES ")
            sql.Clear()
            For Each row In clsReport.ReportDataTable.Rows
                If sql.Length > 0 Then
                    sql.Append(",")
                End If

                sql.Append("(")
                sql.Append(QuoStr(row("Text01") & " Summary")).Append(",")               'Clients Name title
                sql.Append(QuoStr(row("Text02"))).Append(",")               'business unit title
                sql.Append(QuoStr(row("Text03"))).Append(",")               'taxrate title
                sql.Append(QuoStr(row("Text04"))).Append(",")               'acctnum
                sql.Append(QuoStr(row("Text05"))).Append(",")               'state
                sql.Append(QuoStr(row("Text06"))).Append(",")               'location address
                sql.Append(QuoStr(row("Text07"))).Append(",")               'total for bu title
                sql.Append(QuoStr(row("Text08"))).Append(",")               'assessor
                sql.Append(QuoStr(row("Text09"))).Append(",")               'prop type
                sql.Append(QuoStr(row("Text10"))).Append(",")               'jurisdiction
                sql.Append(QuoStr(row("Text15"))).Append(",")               'bu name, location group by value
                sql.Append(row("Number01")).Append(",")                     'tax year
                sql.Append(row("Number02")).Append(",")                     'abatement
                sql.Append(row("Number03")).Append(",")                     'freeport
                sql.Append(row("Number04")).Append(",")                     'tax value
                sql.Append(row("Number09")).Append(",")                     'tax rate
                sql.Append(row("Number10")).Append(",")                     'client value or final value        
                sql.Append(row("Number11")).Append(",")                     'has bu?
                sql.Append(row("Number14")).Append(",")                     'tax accrual estimate amount
                sql.Append(row("Number15")).Append(",")                     'assessor ratio
                sql.Append(row("Number16")).Append(",")                     'clientid
                sql.Append(row("Number17")).Append(",")                     'locationid
                sql.Append(row("Number18")).Append(",")                     'assessmentid
                sql.Append(row("Number19")).Append(",")                     'jurisdictionid
                sql.Append(row("Number20"))                                 'notified value
                sql.Append(",").Append(QuoStr(row("Date01")))               'tax due date     
                sql.Append(",").Append(row("Number12")).Append("")          'Current year final value
                sql.Append(")")

                If lRows > 100 Then
                    ExecuteSQL(sqlins.ToString & sql.ToString)
                    sql.Clear()
                    lRows = 0
                End If
                lRows = lRows + 1
            Next
            If sql.Length > 0 Then ExecuteSQL(sqlins.ToString & sql.ToString)

            'query temp table to include prior year value and sum of values, etc., and dump into ReportData table
            sql.Clear()
            sql.Append(" INSERT INTO ReportData (UserName,ReportId,RowCounter,Text01,Text02,Text03, Text04, Text05, Text06, Text07, Text08, Text09, Text15, Number01,")
            sql.Append(" Number04, Number09, Number10, Number12, Number11, Number14, Number15, Number16, Number17, Number18, Date01, Number20, Number05, Number06)")
            sql.Append(" SELECT ").Append(QuoStr(AppData.UserId)).Append(",").Append(AppData.ReportId).Append(",1,").Append("Text01, Text02, Text03, Text04,")
            sql.Append(" Text05, Text06, Text07, Text08, Text09, Text15, Number01, MAX_Number04, SUM_Number09,")
            sql.Append(" MAX_Number10, MAX_Number12, Number11, SUM_Number14, Number15, Number16, Number17, Number18, MIN_Date01, MAX_Number20, ")
            sql.Append(" MAX_Number02Number03,")
            sql.Append(" CASE WHEN tmp1.Text09 = 'BPP'")
            sql.Append(" THEN (SELECT MAX(ISNULL(d.FinalValue,0)) FROM AssessmentDetailBPP d")
            sql.Append(" WHERE d.ClientId = tmp1.Number16 AND d.LocationId = tmp1.Number17 AND d.AssessmentId = tmp1.Number18 AND d.TaxYear = tmp1.Number01 - 1)")
            sql.Append(" ELSE (SELECT MAX(ISNULL(d.FinalValue,0)) FROM AssessmentDetailRE d")
            sql.Append(" WHERE d.ClientId = tmp1.Number16 AND d.LocationId = tmp1.Number17 AND d.AssessmentId = tmp1.Number18 AND d.TaxYear = tmp1.Number01 - 1)")
            sql.Append(" END AS PriorFinalValue")
            sql.Append(" FROM (SELECT Text01, Text02, Text03, Text04, Text05, Text06, Text07, Text08, Text09, Text15, Number01, MAX(Number04) AS MAX_Number04, SUM(Number09) AS SUM_Number09,")
            sql.Append(" MAX(Number10) AS MAX_Number10, MAX(Number12) AS MAX_Number12, Number11, SUM(Number14) AS SUM_Number14, Number15, Number16, Number17, Number18, MIN(Date01) AS MIN_Date01, MAX(Number20) AS MAX_Number20,")
            sql.Append(" MAX(Number02 + Number03) AS MAX_Number02Number03")
            sql.Append(" FROM ").Append(sTempTable)
            sql.Append(" GROUP BY Text01, Text02, Text03, Text04, Text05, Text06, Text07, Text08, Text09, Text15, Number01, Number11, Number15, Number16, Number17, Number18)")
            sql.Append(" AS tmp1")

            ExecuteSQL(sql.ToString)

            ExecuteSQL("drop table " & sTempTable)

            Return True
        Catch ex As Exception
            LogMsg("Error printing Tax Accrual Summary:  " & ex.Message)
            Return False
        End Try
    End Function
    Private Function GetInstallments(clientid As Long, locationid As Long, assessmentid As Long, taxyear As Integer, proptype As enumTable) As DataTable
        Dim dt As New DataTable
        Try
            Dim sql As New StringBuilder("SELECT CollectorId, PayFromDt, PayToDt, ISNULL(PayAmt,0) AS PayAmt FROM Installments")
            sql.Append(IIf(proptype = enumTable.enumLocationBPP, "BPP", "RE"))
            sql.Append(" WHERE ClientId=").Append(clientid).Append(" AND LocationId=").Append(locationid).Append(" AND AssessmentId=").Append(assessmentid)
            sql.Append(" AND TaxYear=").Append(taxyear).Append(" ORDER BY CollectorId, PayToDt")
            GetData(sql.ToString, dt)
            Return dt
        Catch ex As Exception
            LogMsg("Error getting installments:  " & ex.Message)
            Return dt
        End Try
    End Function
    Public Sub UpdateClientReporting(etype As enumReport, clientid As Long, locationid As Long, assessmentid As Long, taxyear As Integer, proptype As enumTable,
            dt As DataTable)
        Try
            Dim sql As New StringBuilder
            Dim sqlvalues As New StringBuilder
            Select Case etype
                Case enumReport.enumTaxAccrual
                    sql.Clear()
                    sql.Append("DELETE ClientReporting..TaxAccrualDetail")
                    sql.Append(" WHERE ClientId = ").Append(clientid.ToString)
                    If locationid > 0 Then sql.Append(" AND LocationId = ").Append(locationid.ToString)
                    If assessmentid > 0 Then sql.Append(" AND AssessmentId = ").Append(assessmentid.ToString)
                    sql.Append(" AND TaxYear = ").Append(taxyear.ToString)
                    ExecuteSQL(sql.ToString)
                    sql.Clear()
                    sql.Append("INSERT ClientReporting..TaxAccrualDetail")
                    sql.Append(" (ClientId, LocationId, AssessmentId, TaxYear, PropType, ClientName, BusinessUnit, StateCd, AccountLocation, AssessorName, AcctNum,")
                    sql.Append(" JurisdictionName, TaxRateHeading, TaxRate, AccrualBasis, AbatementAmt, FreeportAmt, NetTaxableValue, AssessorRatio,")
                    sql.Append(" TaxAccrualAmt)")
                    sql.Append(" VALUES")
                    sqlvalues.Clear()
                    For Each dr As DataRow In dt.Rows
                        If sqlvalues.Length > 0 Then sqlvalues.Append(",")
                        sqlvalues.Append(" (").Append(clientid.ToString).Append(",").Append(locationid.ToString).Append(",").Append(assessmentid.ToString).Append(",")
                        sqlvalues.Append(taxyear.ToString).Append(",").Append(IIf(proptype = enumTable.enumLocationBPP, "'BPP'", "'Real'")).Append(",").Append(QuoStr(dr("Text18"))).Append(",").Append(QuoStr(dr("Text02"))).Append(",").Append(QuoStr(dr("Text05"))).Append(",")
                        sqlvalues.Append(QuoStr(dr("Text06"))).Append(",").Append(QuoStr(dr("Text08"))).Append(",").Append(QuoStr(dr("Text04"))).Append(",").Append(QuoStr(dr("Text10"))).Append(",")
                        sqlvalues.Append(QuoStr(dr("Text03"))).Append(",").Append(dr("Number09")).Append(",").Append(dr("Number10")).Append(",").Append(dr("Number02")).Append(",")
                        sqlvalues.Append(dr("Number03")).Append(",").Append(dr("Number04")).Append(",").Append(dr("Number15")).Append(",").Append(dr("Number14")).Append(")")
                    Next
                    If dt.Rows.Count > 0 Then
                        sql.Append(sqlvalues.ToString)
                        ExecuteSQL(sql.ToString)
                    End If
                Case enumReport.enumTaxSavings
                    sql.Clear()
                    sql.Append("DELETE ClientReporting..TaxSavingsDetail")
                    sql.Append(" WHERE ClientId = ").Append(clientid.ToString)
                    If locationid > 0 Then sql.Append(" AND LocationId = ").Append(locationid.ToString)
                    If assessmentid > 0 Then sql.Append(" AND AssessmentId = ").Append(assessmentid.ToString)
                    sql.Append(" AND TaxYear = ").Append(taxyear.ToString)
                    ExecuteSQL(sql.ToString)
                    sql.Clear()
                    sql.Append("INSERT ClientReporting..TaxSavingsDetail")
                    sql.Append(" (ClientId, LocationId, AssessmentId, TaxYear, PropType, ClientName, BusinessUnit, StateCd, AccountLocation, AssessorName, AcctNum,")
                    sql.Append(" JurisdictionName, TaxRateHeading, TaxRate, SavingsBasis, SavingsBasisHeading, FinalValue, ExemptAmt, ValueDifference,")
                    sql.Append(" TaxBeforeSavings, TaxAccrual, TaxSavings, PreviousYearValue, ValueLimitation, AssessorRatio)")
                    sql.Append(" VALUES")
                    sqlvalues.Clear()
                    For Each dr As DataRow In dt.Rows
                        If sqlvalues.Length > 0 Then sqlvalues.Append(",")
                        sqlvalues.Append(" (").Append(clientid.ToString).Append(",").Append(locationid.ToString).Append(",").Append(assessmentid.ToString).Append(",")
                        sqlvalues.Append(taxyear.ToString).Append(",").Append(IIf(proptype = enumTable.enumLocationBPP, "'BPP'", "'Real'")).Append(",")
                        sqlvalues.Append(QuoStr(dr("Text01"))).Append(",").Append(QuoStr(dr("Text20"))).Append(",").Append(QuoStr(dr("Text06"))).Append(",")
                        sqlvalues.Append(QuoStr(dr("Text12"))).Append(",").Append(QuoStr(dr("Text13"))).Append(",").Append(QuoStr(dr("Text05"))).Append(",")
                        sqlvalues.Append(QuoStr(dr("Text11"))).Append(",").Append(QuoStr(dr("Text03"))).Append(",").Append(dr("Number01")).Append(",")
                        sqlvalues.Append(dr("Number02")).Append(",").Append(QuoStr(dr("Text09"))).Append(",").Append(dr("Number03")).Append(",")
                        sqlvalues.Append(dr("Number04")).Append(",").Append(dr("Number05")).Append(",").Append(dr("Number06")).Append(",")
                        sqlvalues.Append(dr("Number07")).Append(",").Append(dr("Number08")).Append(",").Append(dr("Number12")).Append(",")
                        sqlvalues.Append(dr("Number13")).Append(",").Append(dr("Number14"))
                        sqlvalues.Append(")")
                    Next
                    If dt.Rows.Count > 0 Then
                        sql.Append(sqlvalues.ToString)
                        ExecuteSQL(sql.ToString)
                    End If
            End Select
        Catch ex As Exception
            WriteLog("Error in UpdateClientReporting for " & etype.ToString & "," & clientid & "," & locationid & "," & assessmentid & "," & taxyear & ":  " & ex.Message)
        End Try
    End Sub
    Public Sub WriteLog(msg As String)
        Try
            FileIO.FileSystem.WriteAllText(Path.Combine(AppData.AppPath, "AssessmentManagerErrorLog.Log"), DateTime.Now.ToString("g") & "  " & msg & vbCrLf, True)
        Catch ex As Exception

        End Try
    End Sub
End Module

