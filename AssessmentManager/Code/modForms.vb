Imports System.IO
Imports iTextSharp.text.pdf

Module modForms

    Public Const SW_SHOW = 5       ' Displays Window in its current size and position
    Public Const SW_SHOWNORMAL = 1 ' Restores Window if Minimized or Maximized

    Public Declare Function ShellExecute Lib "shell32.dll" Alias _
             "ShellExecuteA" (ByVal hwnd As Long, ByVal lpOperation As _
             String, ByVal lpFile As String, ByVal lpParameters As String,
             ByVal lpDirectory As String, ByVal nShowCmd As Long) As Long
    Private Const ERROR_SUCCESS = 32&
    Private Const ERROR_NO_ASSOC = 31&
    Private Const ERROR_OUT_OF_MEM = 0&
    Private Const ERROR_FILE_NOT_FOUND = 2&
    Private Const ERROR_PATH_NOT_FOUND = 3&
    Private Const ERROR_BAD_FORMAT = 11&
    Private Const sRun As String = "RUNDLL32.EXE"
    Private Const sParameters As String = "shell32.dll,OpenAs_RunDLL "

    Private Declare Function FindExecutable Lib "shell32" _
        Alias "FindExecutableA" _
        (ByVal lpFile As String,
        ByVal lpDirectory As String,
        ByVal sResult As String) As Long


    Private Structure structPDFFields
        Friend sTable As String
        Friend sField As String
        Friend sPDFField As String
        Friend sValue As String
    End Structure

    Public Function OpenForm(ByVal eType As enumReport, ByVal lClientId As Long, ByVal lAssessorId As Long, ByVal sStateCd As String,
            ByVal iTaxYear As Integer, ByVal sEffectiveDate As String, ByVal bPrint As Boolean,
            ByVal sFolder As String, ByRef sError As String) As Boolean

        Return OpenForm(eType, lClientId, 0, 0, iTaxYear, lAssessorId, sStateCd, sEffectiveDate, bPrint, enumTable.enumLocationBPP, sFolder, "", False, False, sError)
    End Function

    Public Function OpenForm(ByVal eType As enumReport, ByVal lClientId As Long, ByVal lLocationId As Long,
            ByVal lAssessmentId As Long, ByVal iTaxYear As Integer, ByVal lAssessorId As Long, ByVal sStateCd As String,
            ByVal sExtraParm As String,
            ByVal bPrint As Boolean, ByVal ePropType As enumTable, ByVal sFolder As String, ByVal sFileNamePrefix As String,
            ByVal bJustCreatePDF As Boolean, ByVal identifyfields As Boolean, ByRef sError As String) As Boolean
        Dim sSQL As String = "", dtFormData As New DataTable, structFields() As structPDFFields
        Dim dr As DataRow, sFormName As String = "", lFormId As Long = 0, l As Long = 0
        Dim sJurNameList As New StringBuilder()
        Dim dtJurNameList As New DataTable, drJurNameList As DataRow

        Try
            ReDim structFields(0)
            Select Case eType
                Case enumReport.enumFreeportForm
                    sFormName = "50-113"
                Case enumReport.enumRenditionForm
                    sFormName = "50-144"
                Case enumReport.enumValueProtestForm
                    sFormName = "50-132"
                Case enumReport.enumCertificateOfMailing
                    sFormName = "PS3817"
                Case enumReport.enumAppointmentOfAgentForm
                    sFormName = "50-162"
                Case enumReport.enumRenditionExtensionForm
                    sFormName = "50-144-EXT"
                Case enumReport.enumAffidavitOfEvidence
                    sFormName = "50-283"
                Case enumReport.enumCorrection
                    sFormName = "50-771"
            End Select

            If eType <> enumReport.enumClientContract Then
                Dim dt As New DataTable
                If eType = enumReport.enumAppointmentOfAgentForm Then
                    sSQL = "SELECT FormId FROM StateForms WHERE FormName = " & QuoStr(sFormName) & " AND TaxYear = " & iTaxYear &
                        " AND StateCd = '" & sStateCd & "'"
                Else
                    sSQL = "SELECT FormId FROM StateForms WHERE FormName = " & QuoStr(sFormName) & " AND TaxYear = " & iTaxYear &
                        " AND StateCd = (SELECT StateCd FROM Locations" &
                        IIf(ePropType = enumTable.enumLocationBPP, "BPP", "RE") &
                        " WHERE ClientId = " & lClientId & " AND LocationId = " & lLocationId &
                        " AND TaxYear = " & iTaxYear & ")"
                End If
                If GetData(sSQL, dt) > 0 Then
                    lFormId = dt.Rows(0)(0)
                Else
                    sError = "Form " & sFormName & " not found"
                    Return False
                End If
            End If

            'replace with query
            If eType = enumReport.enumRenditionExtensionForm Then
                ReDim structFields(16)
                structFields(0).sPDFField = "TAX AGENT IF APPLICABLE" : structFields(0).sTable = "FirmInfo" : structFields(0).sField = "Name"
                structFields(1).sPDFField = "MAILING ADDRESS" : structFields(1).sTable = "FirmInfo" : structFields(1).sField = "Address"
                structFields(2).sPDFField = "ASSESSOR ADDRESS" : structFields(2).sTable = "Assessors" : structFields(2).sField = "Address"
                structFields(3).sPDFField = "PHONE NUMBER" : structFields(3).sTable = "FirmInfo" : structFields(3).sField = "Phone"
                structFields(4).sPDFField = "OWNER NAME" : structFields(4).sTable = "Locations" : structFields(4).sField = "OwnerName"
                structFields(5).sPDFField = "ACCOUNT NUMBER" : structFields(5).sTable = "Assessments" : structFields(5).sField = "AcctNum"
                structFields(6).sPDFField = "CMRRR" : structFields(6).sTable = "Assessments" : structFields(6).sField = "RenditionExtCMRRR"
                structFields(7).sPDFField = "BUSINESS NAME" : structFields(7).sTable = "Clients" : structFields(7).sField = "Name"
                structFields(8).sPDFField = "PROPERTY ADDRESS" : structFields(8).sTable = "LocationsBPP" : structFields(8).sField = "Address"
                structFields(9).sPDFField = "FAX NUMBER" : structFields(9).sTable = "FirmInfo" : structFields(9).sField = "Fax"
                structFields(10).sPDFField = "DATE" : structFields(10).sTable = "FirmInfo" : structFields(10).sField = "Date"
                structFields(11).sPDFField = "TAX YEAR" : structFields(11).sTable = "Assessments" : structFields(11).sField = "TaxYear"
                structFields(12).sPDFField = "TITLE" : structFields(12).sTable = "FirmInfo" : structFields(12).sField = "Title"
                structFields(13).sPDFField = "ASSESSOR" : structFields(13).sTable = "Assessors" : structFields(13).sField = "Name"
                structFields(14).sPDFField = "ASSESSOR CITY STATE ZIP" : structFields(14).sTable = "Assessors" : structFields(14).sField = "City"
                structFields(15).sPDFField = "PROPERTY CITY STATE ZIP" : structFields(15).sTable = "LocationsBPP" : structFields(15).sField = "City"
                structFields(16).sPDFField = "MAILING CITY STATE ZIP" : structFields(16).sTable = "FirmInfo" : structFields(16).sField = "City"

                sSQL = "SELECT ISNULL(a.Name,'') AS Assessors_Name, ISNULL(c.Name,'') AS Clients_Name," &
                    " ISNULL(abpp.AcctNum,'') AS Assessments_AcctNum," &
                    " abpp.TaxYear AS Assessments_TaxYear," &
                    " RTRIM(ISNULL(a.Address1,'')) AS Assessors_Address," &
                    " RTRIM(ISNULL(a.City,'')) + ', ' + RTRIM(ISNULL(a.StateCd,'')) + '  ' + RTRIM(ISNULL(a.Zip,'')) AS Assessors_City," &
                    QuoStr(AppData.FirmCity & ", " & AppData.FirmStateCd & "  " & AppData.FirmZip) & " AS FirmInfo_City," &
                    QuoStr(AppData.FirmName) & " AS FirmInfo_Name," &
                    QuoStr(AppData.FirmAddress) & " AS FirmInfo_Address," &
                    QuoStr(AppData.FirmPhone) & " AS FirmInfo_Phone," &
                    QuoStr(AppData.FirmFax) & " AS FirmInfo_Fax," &
                    " 'Agent' AS FirmInfo_Title," &
                    " CONVERT(varchar,GETDATE(),101) AS FirmInfo_Date," &
                    " RTRIM(ISNULL(l.Address,'')) AS LocationsBPP_Address," &
                    " RTRIM(ISNULL(l.City,'')) + ', ' + RTRIM(ISNULL(l.StateCd,'')) + '  ' + RTRIM(ISNULL(l.Zip,'')) AS LocationsBPP_City," &
                    " RTRIM(ISNULL(c.Address,'')) AS Clients_Address," &
                    " 'CMRRR:  ' + RTRIM(ISNULL(abpp.RenditionExtCMRRR,'')) AS Assessments_RenditionExtCMRRR," &
                    " RTRIM(ISNULL(c.City,'')) + ', ' + RTRIM(ISNULL(c.StateCd,'')) + '  ' + RTRIM(ISNULL(c.Zip,'')) AS Clients_City," &
                    " ISNULL(c.Phone,'') AS Clients_Phone, ISNULL(l.LegalOwner,c.Name) AS Locations_OwnerName" &
                    " FROM AssessmentsBPP AS abpp INNER JOIN" &
                    " Assessors AS a ON abpp.AssessorId = a.AssessorId AND abpp.TaxYear = a.TaxYear INNER JOIN" &
                    " LocationsBPP AS l ON abpp.ClientId = l.ClientId AND abpp.LocationId = l.LocationId" &
                    " AND abpp.TaxYear = l.TaxYear INNER JOIN" &
                    " Clients AS c ON l.ClientId = c.ClientId" &
                    " WHERE abpp.ClientId = " & lClientId & " AND abpp.LocationId = " & lLocationId &
                    " AND abpp.AssessmentId = " & lAssessmentId & " AND l.TaxYear = " & iTaxYear
            ElseIf eType = enumReport.enumRenditionForm Then
                ReDim structFields(12)
                structFields(0).sPDFField = "3" : structFields(0).sTable = "Assessments" : structFields(0).sField = "AcctNum"
                structFields(1).sPDFField = "2" : structFields(1).sTable = "Assessors" : structFields(1).sField = "Name"
                structFields(2).sPDFField = "" : structFields(2).sTable = "Assessors" : structFields(2).sField = "Phone"
                structFields(3).sPDFField = "" : structFields(3).sTable = "Assessors" : structFields(3).sField = "Address"
                structFields(4).sPDFField = "1" : structFields(4).sTable = "Assessments" : structFields(4).sField = "TaxYear"
                structFields(5).sPDFField = "11" : structFields(5).sTable = "Locations" : structFields(5).sField = "Name"
                structFields(6).sPDFField = "12" : structFields(6).sTable = "Locations" : structFields(6).sField = "OwnerName"
                structFields(7).sPDFField = "" : structFields(7).sTable = "Clients" : structFields(7).sField = "Address"
                structFields(8).sPDFField = "15" : structFields(8).sTable = "Clients" : structFields(8).sField = "Phone"
                structFields(9).sPDFField = "13" : structFields(9).sTable = "Locations" : structFields(9).sField = "Address"
                structFields(10).sPDFField = "22" : structFields(10).sTable = "FirmInfo" : structFields(10).sField = "Name"
                structFields(11).sPDFField = "23" : structFields(11).sTable = "FirmInfo" : structFields(11).sField = "Address"
                structFields(12).sPDFField = "24" : structFields(12).sTable = "FirmInfo" : structFields(12).sField = "Phone"

                sSQL = "SELECT ISNULL(a.Name,'') AS Assessors_Name, ISNULL(c.Name,'') AS Clients_Name, ISNULL(abpp.AcctNum,'') AS Assessments_AcctNum," &
                    " abpp.TaxYear AS Assessments_TaxYear," &
                    " ISNULL(a.Phone,'') AS Assessors_Phone," &
                    QuoStr(AppData.FirmCity & ", " & AppData.FirmStateCd & "  " & AppData.FirmZip) & " AS FirmInfo_City," &
                    " RTRIM(ISNULL(a.Address1,'')) + '  ' + RTRIM(ISNULL(a.City,'')) + ', ' + RTRIM(ISNULL(a.StateCd,'')) + '  ' + RTRIM(ISNULL(a.Zip,'')) AS Assessors_Address," &
                    " RTRIM(ISNULL(l.Address,'')) + '  ' + RTRIM(ISNULL(l.City,'')) + ', ' + RTRIM(ISNULL(l.StateCd,'')) + '  ' + RTRIM(ISNULL(l.Zip,'')) + '  ' + RTRIM(ISNULL(l.ClientLocationId,'')) AS Locations_Address," &
                    QuoStr(AppData.FirmName) & " AS FirmInfo_Name," &
                    QuoStr(AppData.FirmAddress & "  " & AppData.FirmCity & ", " & AppData.FirmStateCd & "  " & AppData.FirmZip) & " AS FirmInfo_Address," &
                    QuoStr(AppData.FirmPhone) & " AS FirmInfo_Phone," &
                    QuoStr(AppData.FirmFax) & " AS FirmInfo_Fax," &
                    " RTRIM(LTRIM(ISNULL(l.Name,c.Name))) AS Locations_Name," &
                    " RTRIM(ISNULL(c.Address,'')) + '  ' + RTRIM(ISNULL(c.City,'')) + ', ' + RTRIM(ISNULL(c.StateCd,'')) + '  ' + RTRIM(ISNULL(c.Zip,'')) AS Clients_Address," &
                    " 'CMRRR:  ' + RTRIM(ISNULL(abpp.RenditionCMRRR,'')) AS Assessments_RenditionCMRRR," &
                    " RTRIM(ISNULL(c.City,'')) + ', ' + RTRIM(ISNULL(c.StateCd,'')) + '  ' + RTRIM(ISNULL(c.Zip,'')) AS Clients_City," &
                    " ISNULL(c.Phone,'') AS Clients_Phone, ISNULL(l.LegalOwner,c.Name) AS Locations_OwnerName," &
                    " ISNULL(l.LegalDescription,'') AS Locations_LegalDescription" &
                    " FROM AssessmentsBPP AS abpp INNER JOIN" &
                    " Assessors AS a ON abpp.AssessorId = a.AssessorId AND abpp.TaxYear = a.TaxYear INNER JOIN" &
                    " LocationsBPP AS l ON abpp.ClientId = l.ClientId AND abpp.LocationId = l.LocationId" &
                    " AND abpp.TaxYear = l.TaxYear INNER JOIN" &
                    " Clients AS c ON l.ClientId = c.ClientId" &
                    " WHERE abpp.ClientId = " & lClientId & " AND abpp.LocationId = " & lLocationId &
                    " AND abpp.AssessmentId = " & lAssessmentId & " AND l.TaxYear = " & iTaxYear

            ElseIf eType = enumReport.enumFreeportForm Then
                ReDim structFields(14)
                structFields(0).sPDFField = "?" : structFields(0).sTable = "Assessors" : structFields(0).sField = "Address"
                structFields(1).sPDFField = "2" : structFields(1).sTable = "Assessors" : structFields(1).sField = "Name"
                structFields(2).sPDFField = "?" : structFields(2).sTable = "Assessors" : structFields(2).sField = "Phone"
                structFields(3).sPDFField = "18" : structFields(3).sTable = "Clients" : structFields(3).sField = "FullAddress"
                structFields(4).sPDFField = "13" : structFields(4).sTable = "Locations" : structFields(4).sField = "OwnerName"
                structFields(5).sPDFField = "16" : structFields(5).sTable = "Clients" : structFields(5).sField = "Phone"
                structFields(6).sPDFField = "28" : structFields(6).sTable = "FirmInfo" : structFields(6).sField = "FullAddress"
                structFields(7).sPDFField = "23" : structFields(7).sTable = "FirmInfo" : structFields(7).sField = "Name"
                structFields(8).sPDFField = "26" : structFields(8).sTable = "FirmInfo" : structFields(8).sField = "Phone"
                structFields(9).sPDFField = "15" : structFields(9).sTable = "LocationsBPP" : structFields(9).sField = "Address"
                structFields(10).sPDFField = "3" : structFields(10).sTable = "Assessments" : structFields(10).sField = "AcctNum"
                structFields(11).sPDFField = "1" : structFields(11).sTable = "Assessments" : structFields(11).sField = "TaxYear"
                structFields(12).sPDFField = "53" : structFields(12).sTable = "Calculated" : structFields(12).sField = "Date" : structFields(12).sValue = Format(Now, "MM/dd/yyyy")
                structFields(13).sPDFField = "31" : structFields(13).sTable = "LocationsBPP" : structFields(13).sField = "Address"
                structFields(14).sPDFField = "32" : structFields(14).sTable = "LocationsBPP" : structFields(14).sField = "LegalDescription"

                sSQL = "SELECT ISNULL(a.Name,'') AS Assessors_Name, ISNULL(c.Name,'') AS Clients_Name, ISNULL(abpp.AcctNum,'') AS Assessments_AcctNum," &
                    " abpp.TaxYear AS Assessments_TaxYear," &
                    " RTRIM(ISNULL(a.Address1,'')) + '  ' + RTRIM(ISNULL(a.City,'')) + ', ' + RTRIM(ISNULL(a.StateCd,'')) + '  ' + RTRIM(ISNULL(a.Zip,'')) AS Assessors_Address," &
                    " ISNULL(a.Phone,'') AS Assessors_Phone," &
                    " RTRIM(ISNULL(l.Address,'')) + '  ' + RTRIM(ISNULL(l.City,'')) + ', ' + RTRIM(ISNULL(l.StateCd,'')) + '  ' + RTRIM(ISNULL(l.Zip,'')) AS LocationsBPP_Address," &
                    " ISNULL(l.LegalOwner,c.Name) AS Locations_OwnerName," &
                    QuoStr(AppData.FirmCity & ", " & AppData.FirmStateCd & "  " & AppData.FirmZip) & " AS FirmInfo_City," &
                    QuoStr(AppData.FirmName) & " AS FirmInfo_Name," &
                    QuoStr(AppData.FirmAddress) & " AS FirmInfo_Address," &
                    QuoStr(AppData.FirmPhone) & " AS FirmInfo_Phone," &
                    QuoStr(AppData.FirmFax) & " AS FirmInfo_Fax," &
                    QuoStr(AppData.FirmAddress & "  " & AppData.FirmCity & ", " & AppData.FirmStateCd & "  " & AppData.FirmZip) & " AS FirmInfo_FullAddress," &
                    " RTRIM(ISNULL(c.Address,'')) AS Clients_Address," &
                    " RTRIM(ISNULL(c.City,'')) + ', ' + RTRIM(ISNULL(c.StateCd,'')) + '  ' + RTRIM(ISNULL(c.Zip,'')) AS Clients_City," &
                    " ISNULL(c.Phone,'') AS Clients_Phone," &
                    " RTRIM(ISNULL(c.Address,'')) + '  ' + RTRIM(ISNULL(c.City,'')) + ', ' + RTRIM(ISNULL(c.StateCd,'')) + '  ' + RTRIM(ISNULL(c.Zip,'')) AS Clients_FullAddress," &
                    " ISNULL(l.LegalDescription,'') AS LocationsBPP_LegalDescription" &
                    " FROM AssessmentsBPP AS abpp INNER JOIN" &
                    " Assessors AS a ON abpp.AssessorId = a.AssessorId AND abpp.TaxYear = a.TaxYear INNER JOIN" &
                    " LocationsBPP AS l ON abpp.ClientId = l.ClientId AND abpp.LocationId = l.LocationId" &
                    " AND abpp.TaxYear = l.TaxYear INNER JOIN" &
                    " Clients AS c ON l.ClientId = c.ClientId" &
                    " WHERE abpp.ClientId = " & lClientId & " AND abpp.LocationId = " & lLocationId &
                    " AND abpp.AssessmentId = " & lAssessmentId & " AND l.TaxYear = " & iTaxYear
            ElseIf eType = enumReport.enumCertificateOfMailing Then
                ReDim structFields(8)
                structFields(0).sPDFField = "From1" : structFields(0).sTable = "FirmInfo" : structFields(0).sField = "Name"
                structFields(1).sPDFField = "From2" : structFields(1).sTable = "FirmInfo" : structFields(1).sField = "Address"
                structFields(2).sPDFField = "From3" : structFields(2).sTable = "FirmInfo" : structFields(2).sField = "City"
                structFields(4).sPDFField = "To1" : structFields(4).sTable = "Assessors" : structFields(4).sField = "Name"
                structFields(5).sPDFField = "To2" : structFields(5).sTable = "Assessors" : structFields(5).sField = "Address"
                structFields(6).sPDFField = "To3" : structFields(6).sTable = "Assessors" : structFields(6).sField = "City"
                structFields(7).sPDFField = "To4" : structFields(7).sTable = "Locations" : structFields(7).sField = "Address"
                structFields(8).sPDFField = "To5" : structFields(8).sTable = "Assessments" : structFields(8).sField = "AcctNum"
                sSQL = "SELECT RTRIM(ISNULL(assr.Name, '')) AS Assessors_Name," &
                    " RTRIM(ISNULL(l.LegalOwner,c.Name)) + ' ' + RTRIM(l.Address) AS Locations_Address," &
                    " RTRIM(l.City) + '   ' + RTRIM(assess.AcctNum) AS Assessments_AcctNum," &
                    " 'BPP' as PropType, c.ClientId AS Clients_ClientId," &
                    " RTRIM(c.Name) AS Clients_Name," &
                    " RTRIM(ISNULL(assr.Address1, '')) AS Assessors_Address," &
                    " RTRIM(ISNULL(assr.City, '')) + ', ' + RTRIM(ISNULL(assr.StateCd, '')) + '  ' + RTRIM(ISNULL(assr.Zip, '')) AS Assessors_City," &
                    " RTRIM(c.Address) AS Clients_Address," &
                    " RTRIM(c.StateCd) AS Clients_StateCd, RTRIM(c.Zip) AS Clients_Zip," &
                    QuoStr(AppData.FirmCity & ", " & AppData.FirmStateCd & "  " & AppData.FirmZip) & " AS FirmInfo_City," &
                    QuoStr(AppData.FirmName) & " AS FirmInfo_Name," &
                    QuoStr(AppData.FirmAddress) & " AS FirmInfo_Address," &
                    QuoStr(AppData.FirmPhone) & " AS FirmInfo_Phone," &
                    QuoStr(AppData.FirmFax) & " AS FirmInfo_Fax," &
                    " RTRIM(ISNULL(c.City, '')) + ', ' + RTRIM(ISNULL(c.StateCd, '')) + '  ' + RTRIM(ISNULL(c.Zip, '')) AS Clients_City," &
                    " ISNULL(c.Phone, '') AS Clients_Phone," &
                    " assess.TaxYear, assr.AssessorId, 'On' AS Calculated_Check," &
                    " ISNULL(assr.Phone, '') AS Assessors_Phone" &
                    " FROM Clients AS c INNER JOIN" &
                    " AssessmentsBPP AS assess ON c.ClientId = assess.ClientId INNER JOIN" &
                    " Assessors AS assr ON assess.AssessorId = assr.AssessorId AND assess.TaxYear = assr.TaxYear" &
                    " INNER JOIN LocationsBPP l ON assess.ClientId = l.ClientId AND assess.LocationId = l.LocationId" &
                    " AND assess.TaxYear = l.TaxYear" &
                    " WHERE assess.TaxYear = " & iTaxYear & " AND c.ClientId = " & lClientId &
                    " AND ISNULL(assess.AcctNum,'') <> ''"
                If lLocationId = 0 And lAssessmentId = 0 Then
                    sSQL = sSQL & " AND ISNULL(l.InactiveFl,0) = 0 AND ISNULL(assess.InactiveFl,0) = 0"
                Else
                    sSQL = sSQL & " AND assess.LocationId = " & lLocationId & " AND assess.AssessmentId = " & lAssessmentId
                End If
                sSQL = sSQL & " UNION ALL SELECT RTRIM(ISNULL(assr.Name, '')) AS Assessors_Name," &
                    " RTRIM(ISNULL(l.LegalOwner,c.Name)) + ' ' + RTRIM(l.Address) AS Locations_Address," &
                    " RTRIM(l.City) + '   ' + RTRIM(assess.AcctNum) AS Assessments_AcctNum," &
                    " 'RE' as PropType, c.ClientId AS Clients_ClientId," &
                    " RTRIM(c.Name) AS Clients_Name," &
                    " RTRIM(ISNULL(assr.Address1, '')) AS Assessors_Address," &
                    " RTRIM(ISNULL(assr.City, '')) + ', ' + RTRIM(ISNULL(assr.StateCd, '')) + '  ' + RTRIM(ISNULL(assr.Zip, '')) AS Assessors_City," &
                    " RTRIM(c.Address) AS Clients_Address," &
                    " RTRIM(c.StateCd) AS Clients_StateCd, RTRIM(c.Zip) AS Clients_Zip," &
                    QuoStr(AppData.FirmCity & ", " & AppData.FirmStateCd & "  " & AppData.FirmZip) & " AS FirmInfo_City," &
                    QuoStr(AppData.FirmName) & " AS FirmInfo_Name," &
                    QuoStr(AppData.FirmAddress) & " AS FirmInfo_Address," &
                    QuoStr(AppData.FirmPhone) & " AS FirmInfo_Phone," &
                    QuoStr(AppData.FirmFax) & " AS FirmInfo_Fax," &
                    " RTRIM(ISNULL(c.City, '')) + ', ' + RTRIM(ISNULL(c.StateCd, '')) + '  ' + RTRIM(ISNULL(c.Zip, '')) AS Clients_City," &
                    " ISNULL(c.Phone, '') AS Clients_Phone," &
                    " assess.TaxYear, assr.AssessorId, 'On' AS Calculated_Check," &
                    " ISNULL(assr.Phone, '') AS Assessors_Phone" &
                    " FROM Clients AS c INNER JOIN" &
                    " AssessmentsRE AS assess ON c.ClientId = assess.ClientId INNER JOIN" &
                    " Assessors AS assr ON assess.AssessorId = assr.AssessorId AND assess.TaxYear = assr.TaxYear" &
                    " INNER JOIN LocationsRE l ON assess.ClientId = l.ClientId AND assess.LocationId = l.LocationId" &
                    " AND assess.TaxYear = l.TaxYear" &
                    " WHERE assess.TaxYear = " & iTaxYear & " AND c.ClientId = " & lClientId &
                    " AND ISNULL(assess.AcctNum,'') <> ''"
                If lLocationId = 0 And lAssessmentId = 0 Then
                    sSQL = sSQL & " AND ISNULL(l.InactiveFl,0) = 0 AND ISNULL(assess.InactiveFl,0) = 0"
                Else
                    sSQL = sSQL & " AND assess.LocationId = " & lLocationId & " AND assess.AssessmentId = " & lAssessmentId
                End If
                sSQL = sSQL & " ORDER BY 1,2"
            ElseIf eType = enumReport.enumValueProtestForm Or eType = enumReport.enumAffidavitOfEvidence Or eType = enumReport.enumCorrection Then
                Select Case eType
                    Case enumReport.enumValueProtestForm
                        ReDim structFields(7)
                        structFields(0).sPDFField = "Intro_Name" : structFields(0).sTable = "Assessors" : structFields(0).sField = "Name"
                        structFields(1).sPDFField = "Intro_Year" : structFields(1).sTable = "Assessments" : structFields(1).sField = "TaxYear"
                        structFields(2).sPDFField = "Sec1_Name" : structFields(2).sTable = "Locations" : structFields(2).sField = "OwnerName"
                        structFields(3).sPDFField = "Sec1_Address" : structFields(3).sTable = "Clients" : structFields(3).sField = "FullAddress"
                        structFields(4).sPDFField = "Sec1_Phone" : structFields(4).sTable = "Clients" : structFields(4).sField = "Phone"
                        structFields(5).sPDFField = "Sec2_Address" : structFields(5).sTable = "LocationsBPP" : structFields(5).sField = "Address"
                        structFields(6).sPDFField = "Intro_Number" : structFields(6).sTable = "Assessments" : structFields(6).sField = "AcctNum"
                        structFields(7).sPDFField = "Sec7_Date" : structFields(7).sTable = "Calculated" : structFields(7).sField = "Date"
                        structFields(7).sValue = Format(Now, "MM/dd/yyyy")
                    Case enumReport.enumAffidavitOfEvidence
                        ReDim structFields(13)
                        structFields(0).sPDFField = "Name" : structFields(0).sTable = "Assessors" : structFields(0).sField = "Name"
                        structFields(1).sPDFField = "Sec1_Name" : structFields(1).sTable = "Locations" : structFields(1).sField = "OwnerName"
                        structFields(2).sPDFField = "Sec1_Address" : structFields(2).sTable = "Clients" : structFields(2).sField = "FullAddress"
                        structFields(3).sPDFField = "Sec1_Phone" : structFields(3).sTable = "Clients" : structFields(3).sField = "Phone"
                        structFields(4).sPDFField = "AccountNumber" : structFields(4).sTable = "Assessments" : structFields(4).sField = "AcctNum"
                        structFields(5).sPDFField = "Sec2_Address" : structFields(5).sTable = "LocationsBPP" : structFields(5).sField = "Address"
                        structFields(6).sPDFField = "Protest" : structFields(6).sTable = "Assessments" : structFields(6).sField = "TaxYear"
                        structFields(7).sPDFField = "Sec2_description" : structFields(7).sTable = "Locations" : structFields(7).sField = "LegalDescription"
                        structFields(8).sPDFField = "Day_1" : structFields(9).sTable = "Calculated" : structFields(8).sField = "Day" : structFields(8).sValue = CStr(Now.Day)
                        structFields(9).sPDFField = "Month_1" : structFields(9).sTable = "Calculated" : structFields(9).sField = "Month" : structFields(9).sValue = Format(Now, "MMMM")
                        structFields(10).sPDFField = "Year_1" : structFields(10).sTable = "Calculated" : structFields(10).sField = "Year" : structFields(10).sValue = Right(CStr(Now.Year), 2)
                        structFields(11).sPDFField = "Day_2" : structFields(11).sTable = "Calculated" : structFields(11).sField = "Day" : structFields(11).sValue = CStr(Now.Day)
                        structFields(12).sPDFField = "Month_2" : structFields(12).sTable = "Calculated" : structFields(12).sField = "Month" : structFields(12).sValue = Format(Now, "MMMM")
                        structFields(13).sPDFField = "Year_2" : structFields(13).sTable = "Calculated" : structFields(13).sField = "Year" : structFields(13).sValue = Right(CStr(Now.Year), 2)
                    Case enumReport.enumCorrection
                        ReDim structFields(13)
                        structFields(0).sPDFField = "3" : structFields(0).sTable = "Locations" : structFields(0).sField = "OwnerName"
                        structFields(1).sPDFField = "4" : structFields(1).sTable = "Locations" : structFields(1).sField = "LegalDescription"
                        structFields(2).sPDFField = "5" : structFields(2).sTable = "LocationsBPP" : structFields(2).sField = "Address"
                        structFields(3).sPDFField = "6" : structFields(3).sTable = "Assessments" : structFields(3).sField = "AcctNum"
                        structFields(4).sPDFField = "7" : structFields(9).sTable = "Calculated" : structFields(4).sField = "Day"
                        structFields(4).sValue = CStr(Now.Day)
                        structFields(5).sPDFField = "8" : structFields(10).sTable = "Calculated" : structFields(5).sField = "Month"
                        structFields(5).sValue = Format(Now, "MMMM")
                        structFields(6).sPDFField = "9" : structFields(11).sTable = "Calculated" : structFields(6).sField = "Year"
                        structFields(6).sValue = CStr(Now.Year)
                        structFields(7).sPDFField = "19" : structFields(10).sTable = "Calculated" : structFields(7).sField = "Date"
                        structFields(7).sValue = Format(Now, "MM/dd/yyyy")
                        structFields(8).sPDFField = "20" : structFields(8).sTable = "FirmInfo" : structFields(8).sField = "Name"
                        structFields(9).sPDFField = "22" : structFields(9).sTable = "FirmInfo" : structFields(9).sField = "Address"
                        structFields(10).sPDFField = "23" : structFields(10).sTable = "FirmInfo" : structFields(10).sField = "City"
                        structFields(11).sPDFField = "21" : structFields(11).sTable = "FirmInfo" : structFields(11).sField = "Phone"
                        structFields(12).sPDFField = "16" : structFields(12).sTable = "Jurisdictions" : structFields(12).sField = "NameList"
                End Select

                sJurNameList.Clear()
                If eType = enumReport.enumCorrection Then
                    sSQL = "SELECT j.Name FROM AssessmentDetail" & IIf(ePropType = enumTable.enumLocationBPP, "BPP", "RE") & " AS assess" &
                        " INNER JOIN Jurisdictions AS j ON assess.JurisdictionId = j.JurisdictionId AND assess.TaxYear = j.TaxYear" &
                        " WHERE assess.ClientId = " & lClientId & " AND assess.LocationId = " & lLocationId &
                        " AND assess.AssessmentId = " & lAssessmentId & " AND assess.TaxYear = " & iTaxYear
                    If GetData(sSQL, dtJurNameList) > 0 Then
                        For Each drJurNameList In dtJurNameList.Rows
                            If sJurNameList.Length > 0 Then sJurNameList.Append(", ")
                            sJurNameList.Append(drJurNameList("Name")).ToString.Trim()
                        Next
                    End If
                    dtJurNameList.Dispose()
                End If

                sSQL = "SELECT ISNULL(a.Name,'') AS Assessors_Name, ISNULL(c.Name,'') AS Clients_Name, ISNULL(abpp.AcctNum,'') AS Assessments_AcctNum," &
                        " abpp.TaxYear AS Assessments_TaxYear," &
                        " RTRIM(ISNULL(a.Address1,'')) + '  ' + RTRIM(ISNULL(a.City,'')) + ', ' + RTRIM(ISNULL(a.StateCd,'')) + '  ' + RTRIM(ISNULL(a.Zip,'')) AS Assessors_Address," &
                        " ISNULL(a.Phone,'') AS Assessors_Phone," &
                        " RTRIM(ISNULL(l.Address,'')) + '  ' + RTRIM(ISNULL(l.City,'')) + ', ' + RTRIM(ISNULL(l.StateCd,'')) + '  ' + RTRIM(ISNULL(l.Zip,'')) + '" & Space(20) & "' + RTRIM(ISNULL(l.ClientLocationId,'')) AS LocationsBPP_Address," &
                        " ISNULL(l.LegalOwner,c.Name) AS Locations_OwnerName," &
                        QuoStr(AppData.FirmCity & ", " & AppData.FirmStateCd & "  " & AppData.FirmZip) & " AS FirmInfo_City," &
                        QuoStr(AppData.FirmName) & " AS FirmInfo_Name," &
                        QuoStr(AppData.FirmAddress) & " AS FirmInfo_Address," &
                        QuoStr(AppData.FirmPhone) & " AS FirmInfo_Phone," &
                        QuoStr(AppData.FirmFax) & " AS FirmInfo_Fax," &
                        " RTRIM(ISNULL(c.Address,'')) AS Clients_Address," &
                        " RTRIM(ISNULL(c.City,'')) + ', ' + RTRIM(ISNULL(c.StateCd,'')) + '  ' + RTRIM(ISNULL(c.Zip,'')) AS Clients_City," &
                        " RTRIM(ISNULL(c.Address,'')) + '  ' + RTRIM(ISNULL(c.City,'')) + ', ' + RTRIM(ISNULL(c.StateCd,'')) + '  ' + RTRIM(ISNULL(c.Zip,'')) AS Clients_FullAddress," &
                        " ISNULL(c.Phone,'') AS Clients_Phone," &
                        " RTRIM(LTRIM(ISNULL(l.StateCd,''))) AS Locations_StateCd," &
                        " RTRIM(LTRIM(ISNULL(l.LegalDescription,''))) AS Locations_LegalDescription," &
                       QuoStr(sJurNameList.ToString()) & " AS Jurisdictions_NameList" &
                        " FROM Assessments" & IIf(ePropType = enumTable.enumLocationBPP, "BPP", "RE") & " AS abpp INNER JOIN" &
                        " Assessors AS a ON abpp.AssessorId = a.AssessorId And abpp.TaxYear = a.TaxYear INNER JOIN" &
                        " Locations" & IIf(ePropType = enumTable.enumLocationBPP, "BPP", "RE") & " AS l ON abpp.ClientId = l.ClientId And abpp.LocationId = l.LocationId" &
                        " And abpp.TaxYear = l.TaxYear INNER JOIN" &
                        " Clients AS c ON l.ClientId = c.ClientId" &
                        " WHERE abpp.ClientId = " & lClientId & " And abpp.LocationId = " & lLocationId &
                        " And abpp.AssessmentId = " & lAssessmentId & " And l.TaxYear = " & iTaxYear

            ElseIf eType = enumReport.enumAppointmentOfAgentForm Then
                If sStateCd = "TX" Then
                    ReDim structFields(30)
                    structFields(0).sPDFField = "Appraisal District Name" : structFields(0).sTable = "Assessors" : structFields(0).sField = "Name"
                    structFields(1).sPDFField = "" : structFields(1).sTable = "Assessors" : structFields(1).sField = "Phone"
                    structFields(2).sPDFField = "" : structFields(2).sTable = "Assessors" : structFields(2).sField = "Address"
                    structFields(3).sPDFField = "Name" : structFields(3).sTable = "Locations" : structFields(3).sField = "OwnerName"
                    structFields(4).sPDFField = "Address" : structFields(4).sTable = "Clients" : structFields(4).sField = "Address"
                    structFields(5).sPDFField = "City State Zip Code" : structFields(5).sTable = "Clients" : structFields(5).sField = "City"
                    structFields(6).sPDFField = "Telephone Number include area code" : structFields(6).sTable = "Clients" : structFields(6).sField = "Phone"
                    structFields(7).sPDFField = "" : structFields(7).sTable = "Calculated" : structFields(7).sField = "Check"
                    structFields(8).sPDFField = "Appraisal District Account Number_2" : structFields(8).sTable = "Calculated" : structFields(8).sField = "AcctNum1"
                    structFields(9).sPDFField = "Appraisal District Account Number_3" : structFields(9).sTable = "Calculated" : structFields(9).sField = "AcctNum2"
                    structFields(10).sPDFField = "Appraisal District Account Number_4" : structFields(10).sTable = "Calculated" : structFields(10).sField = "AcctNum3"
                    structFields(11).sPDFField = "Appraisal District Account Number_5" : structFields(11).sTable = "Calculated" : structFields(11).sField = "AcctNum4"
                    structFields(12).sPDFField = "Physical or Situs Address of Property_2" : structFields(12).sTable = "Calculated" : structFields(12).sField = "LocationAddress1"
                    structFields(13).sPDFField = "Physical or Situs Address of Property_3" : structFields(13).sTable = "Calculated" : structFields(13).sField = "LocationAddress2"
                    structFields(14).sPDFField = "Physical or Situs Address of Property_4" : structFields(14).sTable = "Calculated" : structFields(14).sField = "LocationAddress3"
                    structFields(15).sPDFField = "Physical or Situs Address of Property_5" : structFields(15).sTable = "Calculated" : structFields(15).sField = "LocationAddress4"
                    structFields(16).sPDFField = "Legal Description_2" : structFields(16).sTable = "Calculated" : structFields(16).sField = "LegalDescription1"
                    structFields(17).sPDFField = "Legal Description_3" : structFields(17).sTable = "Calculated" : structFields(17).sField = "LegalDescription2"
                    structFields(18).sPDFField = "Legal Description_4" : structFields(18).sTable = "Calculated" : structFields(18).sField = "LegalDescription3"
                    structFields(19).sPDFField = "Legal Description_5" : structFields(19).sTable = "Calculated" : structFields(19).sField = "LegalDescription4"
                    structFields(20).sPDFField = "" : structFields(20).sTable = "Calculated" : structFields(20).sField = "Check"
                    structFields(21).sPDFField = "Name_2" : structFields(21).sTable = "FirmInfo" : structFields(21).sField = "Name"
                    structFields(22).sPDFField = "Address_2" : structFields(22).sTable = "FirmInfo" : structFields(22).sField = "Address"
                    structFields(23).sPDFField = "City State Zip Code_2" : structFields(23).sTable = "FirmInfo" : structFields(23).sField = "City"
                    structFields(24).sPDFField = "Telephone Number include area code_2" : structFields(24).sTable = "FirmInfo" : structFields(24).sField = "Phone"
                    structFields(25).sPDFField = "Number of additional sheets attatched" : structFields(25).sTable = "Calculated" : structFields(25).sField = "AdditionalSheets"
                    structFields(26).sPDFField = "" : structFields(26).sTable = "Calculated" : structFields(26).sField = "Check"
                    structFields(27).sPDFField = "" : structFields(27).sTable = "Calculated" : structFields(27).sField = "Check"
                    structFields(28).sPDFField = "" : structFields(28).sTable = "Calculated" : structFields(28).sField = "Check"
                    structFields(29).sPDFField = "" : structFields(29).sTable = "FirmInfo" : structFields(29).sField = "Name"
                    structFields(30).sPDFField = "Date" : structFields(30).sTable = "Calculated" : structFields(30).sField = "AcctNum1"
                    structFields(30).sValue = Format(Now, "MM/dd/yyyy")
                Else
                    ReDim structFields(25)
                    structFields(0).sPDFField = "AssessorName" : structFields(0).sTable = "Assessors" : structFields(0).sField = "Name"
                    structFields(2).sPDFField = "AssessorAddress" : structFields(2).sTable = "Assessors" : structFields(2).sField = "Address1"
                    structFields(2).sPDFField = "AssessorCity" : structFields(2).sTable = "Assessors" : structFields(2).sField = "CityStZip"
                    structFields(22).sPDFField = "AcctNum" : structFields(22).sTable = "Calculated" : structFields(22).sField = "AcctNum"
                    structFields(3).sPDFField = "OwnerName" : structFields(3).sTable = "Locations" : structFields(3).sField = "OwnerName"


                    structFields(4).sPDFField = "Present mailing address number And street" : structFields(4).sTable = "Clients" : structFields(4).sField = "Address"
                    structFields(5).sPDFField = "City town Or post office state ZIP code" : structFields(5).sTable = "Clients" : structFields(5).sField = "City"
                    structFields(6).sPDFField = "Phone area code And number" : structFields(6).sTable = "Clients" : structFields(6).sField = "Phone"
                    structFields(7).sPDFField = "The following property give account number Or legal description" : structFields(7).sTable = "Calculated" : structFields(7).sField = "Check"
                    structFields(8).sPDFField = "1" : structFields(8).sTable = "Calculated" : structFields(8).sField = "AcctNum1"
                    structFields(9).sPDFField = "2" : structFields(8).sTable = "Calculated" : structFields(9).sField = "AcctNum2"
                    structFields(10).sPDFField = "3" : structFields(8).sTable = "Calculated" : structFields(10).sField = "AcctNum3"
                    structFields(11).sPDFField = "General power to represent me in property tax matters concerning this property" : structFields(11).sTable = "Calculated" : structFields(11).sField = "Check"
                    structFields(12).sPDFField = "Agents name" : structFields(12).sTable = "FirmInfo" : structFields(12).sField = "Name"
                    structFields(13).sPDFField = "Present mailing address number And street_2" : structFields(13).sTable = "FirmInfo" : structFields(13).sField = "Address"
                    structFields(14).sPDFField = "City town Or post office state ZIP code_2" : structFields(14).sTable = "FirmInfo" : structFields(14).sField = "City"
                    structFields(15).sPDFField = "Phone area code And number_2" : structFields(15).sTable = "FirmInfo" : structFields(15).sField = "Phone"
                    structFields(16).sPDFField = "I want my agent to receive all my property tax notices And other communication for this property including appraisal notices appraisal review board orders And hearing" : structFields(16).sTable = "Calculated" : structFields(16).sField = "Check"
                    structFields(17).sPDFField = "The following property give account number Or legal description_2" : structFields(17).sTable = "Calculated" : structFields(17).sField = "Check"
                    structFields(18).sPDFField = "Name of person Or firm" : structFields(18).sTable = "FirmInfo" : structFields(18).sField = "Name"
                    structFields(19).sPDFField = "Present mailing address number And street_3" : structFields(19).sTable = "FirmInfo" : structFields(19).sField = "Address"
                    structFields(20).sPDFField = "City town Or post office state ZIP code_3" : structFields(20).sTable = "FirmInfo" : structFields(20).sField = "City"
                    structFields(21).sPDFField = "Phone area code And number_3" : structFields(21).sTable = "FirmInfo" : structFields(21).sField = "Phone"
                    structFields(22).sPDFField = "Property 1" : structFields(22).sTable = "Calculated" : structFields(22).sField = "AcctNum1"
                    structFields(23).sPDFField = "Property 2" : structFields(23).sTable = "Calculated" : structFields(23).sField = "AcctNum1"
                    structFields(24).sPDFField = "Property 3" : structFields(24).sTable = "Calculated" : structFields(24).sField = "AcctNum1"
                    structFields(25).sPDFField = "Date the designation took effect" : structFields(25).sTable = "Calculated" : structFields(25).sField = "AcctNum1"
                    structFields(25).sValue = sExtraParm
                End If

                sSQL = "SELECT 'BPP' as PropType, c.ClientId AS Clients_ClientId," &
                        " RTRIM(c.Name) AS Clients_Name," &
                        " RTRIM(ISNULL(assr.Address1, '')) + '  ' + RTRIM(ISNULL(assr.City, '')) + ', ' + RTRIM(ISNULL(assr.StateCd, '')) + '  ' + RTRIM(ISNULL(assr.Zip, '')) AS Assessors_Address," &
                        " RTRIM(ISNULL(assr.Address1, '')) AS Assessors_Address1," &
                        " RTRIM(ISNULL(assr.City, '')) + ', ' + RTRIM(ISNULL(assr.StateCd, '')) + '  ' + RTRIM(ISNULL(assr.Zip, '')) AS Assessors_CityStZip," &
                        " RTRIM(c.Address) AS Clients_Address," &
                        " RTRIM(c.StateCd) AS Clients_StateCd, RTRIM(c.Zip) AS Clients_Zip, RTRIM(assess.AcctNum) AS AcctNum," &
                        " RTRIM(LTRIM(ISNULL(l.LegalDescription,''))) AS LegalDescription," &
                        " RTRIM(ISNULL(l.Address,'')) + '  ' + RTRIM(ISNULL(l.City,'')) + ', ' + RTRIM(ISNULL(l.StateCd,'')) + '  ' + RTRIM(ISNULL(l.Zip,'')) AS Locations_Address," &
                        QuoStr(AppData.FirmCity & ", " & AppData.FirmStateCd & "  " & AppData.FirmZip) & " AS FirmInfo_City," &
                        QuoStr(AppData.FirmName) & " AS FirmInfo_Name," &
                        QuoStr(AppData.FirmAddress) & " AS FirmInfo_Address," &
                        QuoStr(AppData.FirmPhone) & " AS FirmInfo_Phone," &
                        QuoStr(AppData.FirmFax) & " AS FirmInfo_Fax," &
                        " RTRIM(ISNULL(c.City, '')) + ', ' + RTRIM(ISNULL(c.StateCd, '')) + '  ' + RTRIM(ISNULL(c.Zip, '')) AS Clients_City," &
                        " ISNULL(c.Phone, '') AS Clients_Phone," &
                        " assess.TaxYear, assr.AssessorId, ISNULL(assr.Name, '') AS Assessors_Name, 'On' AS Calculated_Check," &
                        " ISNULL(assr.Phone, '') AS Assessors_Phone, RTRIM(LTRIM(ISNULL(l.LegalOwner,c.Name))) AS Locations_OwnerName" &
                        " FROM Clients AS c INNER JOIN" &
                        " AssessmentsBPP AS assess ON c.ClientId = assess.ClientId INNER JOIN" &
                        " Assessors AS assr ON assess.AssessorId = assr.AssessorId AND assess.TaxYear = assr.TaxYear" &
                        " INNER JOIN LocationsBPP l ON assess.ClientId = l.ClientId AND assess.LocationId = l.LocationId" &
                        " AND assess.TaxYear = l.TaxYear" &
                        " WHERE assess.TaxYear = " & iTaxYear & " AND c.ClientId = " & lClientId & " AND assr.AssessorId = " & lAssessorId &
                        " AND ISNULL(assess.AcctNum,'') <> ''"
                If lLocationId = 0 And lAssessmentId = 0 Then
                    sSQL = sSQL & " AND ISNULL(l.InactiveFl,0) = 0 AND ISNULL(assess.InactiveFl,0) = 0"
                Else
                    sSQL = sSQL & " AND assess.LocationId = " & lLocationId & " AND assess.AssessmentId = " & lAssessmentId
                End If
                sSQL = sSQL & " UNION ALL SELECT 'RE' as PropType, c.ClientId AS Clients_ClientId," &
                        " RTRIM(c.Name) AS Clients_Name," &
                        " RTRIM(ISNULL(assr.Address1, '')) + '  ' + RTRIM(ISNULL(assr.City, '')) + ', ' + RTRIM(ISNULL(assr.StateCd, '')) + '  ' + RTRIM(ISNULL(assr.Zip, '')) AS Assessors_Address," &
                        " RTRIM(ISNULL(assr.Address1, '')) AS Assessors_Address1," &
                        " RTRIM(ISNULL(assr.City, '')) + ', ' + RTRIM(ISNULL(assr.StateCd, '')) + '  ' + RTRIM(ISNULL(assr.Zip, '')) AS Assessors_CityStZip," &
                        " RTRIM(c.Address) AS Clients_Address," &
                        " RTRIM(c.StateCd) AS Clients_StateCd, RTRIM(c.Zip) AS Clients_Zip, RTRIM(assess.AcctNum) AS AcctNum," &
                        " RTRIM(LTRIM(ISNULL(l.LegalDescription,''))) AS LegalDescription," &
                        " RTRIM(ISNULL(l.Address,'')) + '  ' + RTRIM(ISNULL(l.City,'')) + ', ' + RTRIM(ISNULL(l.StateCd,'')) + '  ' + RTRIM(ISNULL(l.Zip,'')) AS Locations_Address," &
                        QuoStr(AppData.FirmCity & ", " & AppData.FirmStateCd & "  " & AppData.FirmZip) & " AS FirmInfo_City," &
                        QuoStr(AppData.FirmName) & " AS FirmInfo_Name," &
                        QuoStr(AppData.FirmAddress) & " AS FirmInfo_Address," &
                        QuoStr(AppData.FirmPhone) & " AS FirmInfo_Phone," &
                        QuoStr(AppData.FirmFax) & " AS FirmInfo_Fax," &
                        " RTRIM(ISNULL(c.City, '')) + ', ' + RTRIM(ISNULL(c.StateCd, '')) + '  ' + RTRIM(ISNULL(c.Zip, '')) AS Clients_City," &
                        " ISNULL(c.Phone, '') AS Clients_Phone," &
                        " assess.TaxYear, assr.AssessorId, ISNULL(assr.Name, '') AS Assessors_Name, 'On' AS Calculated_Check," &
                        " ISNULL(assr.Phone, '') AS Assessors_Phone, RTRIM(LTRIM(ISNULL(l.LegalOwner,c.Name))) AS Locations_OwnerName" &
                        " FROM Clients AS c INNER JOIN" &
                        " AssessmentsRE AS assess ON c.ClientId = assess.ClientId INNER JOIN" &
                        " Assessors AS assr ON assess.AssessorId = assr.AssessorId AND assess.TaxYear = assr.TaxYear" &
                        " INNER JOIN LocationsRE l ON assess.ClientId = l.ClientId AND assess.LocationId = l.LocationId" &
                        " AND assess.TaxYear = l.TaxYear" &
                        " WHERE assess.TaxYear = " & iTaxYear & " AND c.ClientId = " & lClientId & " AND assr.AssessorId = " & lAssessorId &
                        " AND ISNULL(assess.AcctNum,'') <> ''"
                If lLocationId = 0 And lAssessmentId = 0 Then
                    sSQL = sSQL & " AND ISNULL(l.InactiveFl,0) = 0 AND ISNULL(assess.InactiveFl,0) = 0"
                Else
                    sSQL = sSQL & " AND assess.LocationId = " & lLocationId & " AND assess.AssessmentId = " & lAssessmentId
                End If
                sSQL = sSQL & " ORDER BY Locations_OwnerName, AcctNum"
            ElseIf eType = enumReport.enumClientContract Then
                sSQL = "SELECT Name, ContractImage FROM Clients WHERE ClientId = " & lClientId
            End If

            If GetData(sSQL, dtFormData) < 1 Then
                sError = "Not enough data to generate form"
                Return False
            End If
            dr = dtFormData.Rows(0)
            Dim sFile As New StringBuilder
            sFile.Append(sFileNamePrefix)
            If eType = enumReport.enumAppointmentOfAgentForm Then
                sFile.Append(dr("Clients_Name") & "_" & dr("Assessors_Name"))
                If lLocationId <> 0 And lAssessmentId <> 0 Then
                    sFile.Append("_" & dr("AcctNum"))
                End If
            ElseIf eType = enumReport.enumClientContract Then
                If IsDBNull(dr(1)) Then
                    Throw New ApplicationException("No contract found")
                End If
                sFile.Append(dr("Name") & "_contract")
            Else
                sFile.Append(dr("Assessors_Name") & "_" & dr("Assessments_AcctNum"))
            End If
            Dim col As DataColumn
            For Each col In dtFormData.Columns
                For l = 0 To UBound(structFields)
                    If col.ColumnName = structFields(l).sTable & "_" & structFields(l).sField Then
                        structFields(l).sValue = Trim(dr(col.ColumnName).ToString)
                    End If
                Next
            Next

            If eType = enumReport.enumAppointmentOfAgentForm Then
                Dim iFourCounter As Integer = 0        'up to 4 accounts per form
                Dim iPageCounter As Integer = 0
                Dim sOwner As String = ""
                Dim listOwnersWithList As New List(Of String)

                For Each dr In dtFormData.Rows
                    'get 1st owner name
                    If sOwner = "" Then sOwner = dr("Locations_OwnerName")
                Next
                iFourCounter = 0
                For Each dr In dtFormData.Rows
                    'an owner has > 4 accounts, then print "see attached list" in aofa and print list report
                    iFourCounter = iFourCounter + 1
                    If iFourCounter > 4 And sOwner = dr("Locations_OwnerName") Then
                        If listOwnersWithList.Contains(sOwner) = False Then
                            listOwnersWithList.Add(sOwner)
                        End If
                    End If
                    If sOwner <> dr("Locations_OwnerName") Then
                        iFourCounter = 1
                        sOwner = dr("Locations_OwnerName")
                    End If
                Next

                sOwner = ""
                For Each dr In dtFormData.Rows
                    'get 1st owner name not in ownerwithdetaillist
                    If listOwnersWithList.Contains(dr("Locations_OwnerName").ToString) = False Then
                        If sOwner = "" Then sOwner = dr("Locations_OwnerName")
                    End If
                Next
                'account/address/legal desc of each account, 1 through 4 on page
                structFields(8).sValue = ""
                structFields(9).sValue = ""
                structFields(10).sValue = ""
                structFields(11).sValue = ""
                structFields(12).sValue = ""
                structFields(13).sValue = ""
                structFields(14).sValue = ""
                structFields(15).sValue = ""
                structFields(16).sValue = ""
                structFields(17).sValue = ""
                structFields(18).sValue = ""
                structFields(19).sValue = ""
                structFields(25).sValue = ""
                iFourCounter = 0
                For Each dr In dtFormData.Rows
                    If listOwnersWithList.Contains(dr("Locations_OwnerName").ToString) = False Then
                        '    iFourCounter = 1
                        '    sOwner = dr("Locations_OwnerName")
                        'Else
                        iFourCounter = iFourCounter + 1
                        If iFourCounter > 4 Or sOwner <> dr("Locations_OwnerName") Then
                            iPageCounter = iPageCounter + 1
                            structFields(3).sValue = sOwner
                            If Not OpenPDF(eType, lFormId, iTaxYear, structFields, sFolder, sFile.ToString & "_" & sFormName & "_" & iPageCounter, bPrint, False, identifyfields) Then Return False
                            structFields(8).sValue = ""
                            structFields(9).sValue = ""
                            structFields(10).sValue = ""
                            structFields(11).sValue = ""
                            structFields(12).sValue = ""
                            structFields(13).sValue = ""
                            structFields(14).sValue = ""
                            structFields(15).sValue = ""
                            structFields(16).sValue = ""
                            structFields(17).sValue = ""
                            structFields(18).sValue = ""
                            structFields(19).sValue = ""
                            iFourCounter = 1
                            sOwner = dr("Locations_OwnerName")
                        End If
                        Select Case iFourCounter
                            Case 1
                                structFields(8).sValue = dr("AcctNum").ToString
                                structFields(12).sValue = dr("Locations_Address").ToString
                                structFields(16).sValue = dr("LegalDescription").ToString
                            Case 2
                                structFields(9).sValue = dr("AcctNum").ToString
                                structFields(13).sValue = dr("Locations_Address").ToString
                                structFields(17).sValue = dr("LegalDescription").ToString
                            Case 3
                                structFields(10).sValue = dr("AcctNum").ToString
                                structFields(14).sValue = dr("Locations_Address").ToString
                                structFields(18).sValue = dr("LegalDescription").ToString
                            Case 4
                                structFields(11).sValue = dr("AcctNum").ToString
                                structFields(15).sValue = dr("Locations_Address").ToString
                                structFields(19).sValue = dr("LegalDescription").ToString
                        End Select
                    End If
                Next
                If structFields(8).sValue <> "" Then
                    iPageCounter = iPageCounter + 1
                    structFields(3).sValue = sOwner
                    If Not OpenPDF(eType, lFormId, iTaxYear, structFields, sFolder, sFile.ToString & "_" & sFormName & "_" & iPageCounter, bPrint, False, identifyfields) Then Return False
                End If

                'AofA form for those owners who have > 4 accounts.  Generate 1 pdf for owner and splice report showing list
                structFields(8).sValue = "See attached list"
                structFields(9).sValue = ""
                structFields(10).sValue = ""
                structFields(11).sValue = ""
                structFields(12).sValue = ""
                structFields(13).sValue = ""
                structFields(14).sValue = ""
                structFields(15).sValue = ""
                structFields(16).sValue = ""
                structFields(17).sValue = ""
                structFields(18).sValue = ""
                structFields(19).sValue = ""
                For Each sOwner In listOwnersWithList
                    Dim iLineCounter As Integer = 0
                    Dim iDetailPageCounter As Integer = 1
                    iPageCounter = iPageCounter + 1
                    For Each dr In dtFormData.Rows
                        If dr("Locations_OwnerName").ToString = sOwner Then
                            If iLineCounter > 25 Then
                                iDetailPageCounter = iDetailPageCounter + 1
                                iLineCounter = 0
                            End If
                            iLineCounter = iLineCounter + 1
                            sSQL = "INSERT INTO ReportData (UserName,ReportId,Title01,Text01,Text02,Number01)" &
                                " SELECT " & QuoStr(AppData.UserId) & "," & AppData.ReportId & "," &
                                QuoStr(Trim(dr("Locations_OwnerName")) & "  " & Trim(dr("Clients_Address")) & "  " &
                                Trim(dr("Clients_City"))) & "," & QuoStr(dr("AcctNum")) & "," & QuoStr(dr("Locations_Address")) &
                                "," & iDetailPageCounter
                            ExecuteSQL(sSQL)
                        End If
                    Next
                    structFields(3).sValue = sOwner
                    structFields(25).sValue = iDetailPageCounter
                    Dim sAofAFile As String = CleanFileName(sFile.ToString & "_" & sFormName & "_" & iPageCounter)
                    Dim sAofAListFile As String = CleanFileName(sFile.ToString & "_" & sFormName & "_List_" & iPageCounter) & ".pdf"
                    Dim sAofAFolder As String = AppData.TempPath & "\forms\"
                    Dim sAofAListFolder As String = AppData.TempPath & "\"
                    Dim sAofACombinedFile As String = sAofAFolder & CleanFileName(sFile.ToString & "_" & sFormName & "_Combined_" & iPageCounter) & ".pdf"
                    If Not OpenPDF(eType, lFormId, iTaxYear, structFields, sAofAFolder, sAofAFile, False, True, identifyfields) Then Return False

                    'temp\forms contains the AofA
                    'temp contains the list
                    OpenReport(eType, sFormName & "List_" & sFile.ToString & "_" & iPageCounter, False, sAofAListFile, sAofAListFolder, False, True)

                    Dim fTo As FileStream
                    Dim pdfTo As PdfCopyFields
                    Dim reader As PdfReader
                    If File.Exists(sAofACombinedFile) Then File.Delete(sAofACombinedFile)
                    fTo = New FileStream(sAofACombinedFile, FileMode.Append, FileAccess.Write)
                    pdfTo = New PdfCopyFields(fTo)
                    reader = New PdfReader(sAofAFolder & sAofAFile & ".pdf")
                    pdfTo.AddDocument(reader)
                    reader = New PdfReader(sAofAListFolder & sAofAListFile)
                    pdfTo.AddDocument(reader)
                    reader.Close()
                    pdfTo.Close()
                    fTo.Close()
                    If FileIO.FileSystem.FileExists(sAofACombinedFile) Then
                        If sFolder <> "" Then
                            FileIO.FileSystem.CopyFile(sAofACombinedFile, sFolder & IIf(Microsoft.VisualBasic.Right(sFolder, 1) = "\", "", "\") & sAofACombinedFile, True)
                        Else
                            RunAdobe(sAofACombinedFile, bPrint)
                        End If
                    End If
                Next
            Else
                'All forms except for AofA
                If Not OpenPDF(eType, lFormId, iTaxYear, structFields, sFolder, sFile.ToString & "_" & sFormName, bPrint, bJustCreatePDF, identifyfields) Then Return False
            End If


            Return True
        Catch ex As Exception
            sError = "Error in OpenForm:  " & ex.Message
            Return False
        End Try
    End Function

    Private Function OpenPDF(ByVal eType As enumReport, ByVal lFormId As Long, ByVal iTaxYear As Integer, ByVal structFields() As structPDFFields,
            ByVal sFolder As String, ByVal sFile As String, ByVal bPrint As Boolean, bJustCreatePDF As Boolean, identifyfields As Boolean) As Boolean
        'Try
        'Dim avdoc As Object, formapp As Object, acroform As Object, pdffield As Object
        'Dim pddoc As Object, structField As structPDFFields, l As Long

        'Dim formApp As AFORMAUTLib.AFormApp
        'Dim acroForm As AFORMAUTLib.Fields
        'Dim field As AFORMAUTLib.Field
        'Dim avDoc As Acrobat.CAcroAVDoc
        'Dim pdDoc As Acrobat.CAcroPDDoc

        'project references
        '<COMReference Include="Acrobat">
        '  <Guid>{E64169B3-3592-47D2-816E-602C5C13F328}</Guid>
        '  <VersionMajor>1</VersionMajor>
        '  <VersionMinor>1</VersionMinor>
        '  <Lcid>0</Lcid>
        '  <WrapperTool>tlbimp</WrapperTool>
        '</COMReference>
        '<COMReference Include="AFORMAUTLib">
        '  <Guid>{7CD06992-50AA-11D1-B8F0-00A0C9259304}</Guid>
        '  <VersionMajor>1</VersionMajor>
        '  <VersionMinor>0</VersionMinor>
        '  <Lcid>0</Lcid>
        '  <WrapperTool>tlbimp</WrapperTool>
        '</COMReference>



        'ConcatPages()











        Dim reader As PdfReader
        Dim stamper As PdfStamper
        Dim tofields As AcroFields
        Dim field As DictionaryEntry
        Dim sName As String = ""


        'reader = New PdfReader("d:\test.pdf")
        'stamper = New PdfStamper(reader, New FileStream("d:\test2.pdf", FileMode.Create))
        'tofields = stamper.AcroFields
        'For Each field In reader.AcroFields.Fields
        '    sName = field.Key.ToString
        '    If sName = "year" Then tofields.SetField(sName, "9999")
        'Next
        'stamper.FormFlattening = True
        'stamper.Close()







        'Dim formApp As Object
        'Dim acroForm As Object
        'Dim field As Object
        'Dim avDoc As Object
        'Dim pdDoc As Object

        Dim sStreamData As New MemoryStream

        If sFolder = "" Then sFolder = AppData.TempPath & "\forms\"
        Directory.CreateDirectory(sFolder)
        sFile = CleanFileName(sFile)
        If Right(sFolder, 1) <> "\" Then sFolder = sFolder & "\"
        'If Dir(sFolder & sFile) <> "" Then Kill(sFolder & sFile)
        If eType = enumReport.enumClientContract Then
            If Not RetrieveClientContractBLOB(lFormId, sFile) Then
            End If
        Else
            If Not RetrieveBLOB(eType, lFormId, iTaxYear, sStreamData) Then

            End If
        End If


        'avDoc = CreateObject("AcroExch.AVDoc")

        'reader = New PdfReader(sFolder & sFile)



        reader = New PdfReader(sStreamData.ToArray)
        stamper = New PdfStamper(reader, New FileStream(sFolder & sFile & ".pdf", FileMode.Create))
        tofields = stamper.AcroFields



        'If avDoc.Open(sPath & sFile, sFile) = True Then
        ' formApp = CreateObject("AFormAut.App")
        ' acroForm = formApp.Fields
        'Else
        'System.Runtime.InteropServices.Marshal.ReleaseComObject(avDoc)
        'avDoc = Nothing
        'Return False
        'End If
        'For Each pdffield In acroForm
        For Each field In reader.AcroFields.Fields

            'run this line to see what the adobe field names are called
            If identifyfields Then
                tofields.SetField(field.Key.ToString, Left(field.Key.ToString, 30))
            Else
                ''''Debug.Print(field.Key.ToString)
                'run these lines for app to run normally
                sName = field.Key.ToString

                For l = 0 To UBound(structFields)
                    If sName = structFields(l).sPDFField Then
                        tofields.SetField(sName, structFields(l).sValue)
                        Exit For
                    End If
                Next
            End If
        Next

        'pdDoc = avDoc.GetPDDoc
        'sFile = sFile & ".pdf"
        'If pdDoc.Save(1, sPath & sFile) <> True Then
        ' MsgBox("Unable to save the PDF file")
        ' Exit Function
        ' End If
        stamper.FormFlattening = True
        stamper.Close()
        reader.Close()
        'If Dir(sFolder & sFile) <> "" Then Kill(sFolder & sFile)
        If bJustCreatePDF Then
            Return True
        Else
            If Not RunAdobe(sFolder & sFile & ".pdf", bPrint) Then
                Return False
            Else
                Return True
            End If
        End If
        'If bPrint Then avDoc.PrintPages(0, 0, 0, 0, 1)

        'avDoc.Close(False)
        'Return True
        'pdffield = Nothing
        'acroform = Nothing
        'formapp = Nothing
        'pddoc = Nothing
        'avdoc = Nothing

        'Dim saveFileDialog1 As New SaveFileDialog()

        'With saveFileDialog1
        '    .Filter = "Adobe PDF files (*.pdf)|*.pdf"
        '    .FilterIndex = 1
        '    .RestoreDirectory = True
        '    .FileName = sFile & ".pdf"
        '    '.CheckFileExists = True
        '    '.CheckPathExists = True
        '    '.DefaultExt = ".txt"
        'End With

        'If saveFileDialog1.ShowDialog() = DialogResult.OK Then
        '    FileCopy(sPath & sFile & ".pdf", saveFileDialog1.FileName)
        'End If
        'Return True




        'Shell(sFile, AppWinStyle.NormalFocus, True)
        'RunAdobe(sFile, spath, lhwnd)


        'Catch ex As Exception

        'End Try

    End Function

    Private Function OpenClientForm(ByVal lFormId As Long, ByVal iTaxYear As Integer, ByVal structFields() As structPDFFields,
            ByVal sFolder As String, ByVal sFile As String, ByVal bPrint As Boolean) As Boolean
        Try
            Dim reader As PdfReader
            Dim stamper As PdfStamper
            Dim tofields As AcroFields
            Dim field As DictionaryEntry
            Dim sName As String = ""
            Dim sStreamData As New MemoryStream



            If sFolder = "" Then sFolder = AppData.TempPath & "\forms\"
            Directory.CreateDirectory(sFolder)
            If Right(sFolder, 1) <> "\" Then sFolder = sFolder & "\"
            sFile = CleanFileName(sFile)
            'If Dir(sFolder & sFile) <> "" Then Kill(sFolder & sFile)
            If Not RetrieveClientFormBLOB(lFormId, iTaxYear, sStreamData) Then

            End If

            reader = New PdfReader(sStreamData.ToArray)
            stamper = New PdfStamper(reader, New FileStream(sFolder & sFile & ".pdf", FileMode.Create))
            tofields = stamper.AcroFields
            For Each field In reader.AcroFields.Fields
                'tofields.SetField(field.Key.ToString, Left(field.Key.ToString, 20))
                sName = field.Key.ToString
                For l = 0 To UBound(structFields)
                    If sName = structFields(l).sPDFField Then
                        tofields.SetField(sName, structFields(l).sValue)
                        Exit For
                    End If
                Next
            Next

            stamper.FormFlattening = True
            stamper.Close()
            reader.Close()
            'If Dir(sFolder & sFile) <> "" Then Kill(sFolder & sFile)
            If Not RunAdobe(sFolder & sFile & ".pdf", bPrint) Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function OpenClientContract(ByVal lClientId As Long, ByVal sName As String, ByRef sError As String) As Boolean
        Dim sFolder As String, sFile As String
        Try
            sFolder = AppData.TempPath & "\forms\"
            Directory.CreateDirectory(sFolder)
            If Right(sFolder, 1) <> "\" Then sFolder = sFolder & "\"
            sFile = CleanFileName(sName & ".pdf")
            If Not RetrieveClientContractBLOB(lClientId, sFolder & sFile) Then

            End If
            'If Dir(sFolder & sFile) <> "" Then Kill(sFolder & sFile)
            If Not RunAdobe(sFolder & sFile, False) Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try

    End Function
    Public Function OpenClientProposal(ByVal lClientId As Long, ByVal sName As String, ByRef sError As String) As Boolean
        Try
            Dim sFolder As String, sFile As String

            sFolder = AppData.TempPath & "\forms\"
            Directory.CreateDirectory(sFolder)
            If Right(sFolder, 1) <> "\" Then sFolder = sFolder & "\"
            sFile = CleanFileName(sName & ".pdf")
            If Not RetrieveClientProposalBLOB(lClientId, sFolder & sFile) Then

            End If
            'If Dir(sFolder & sFile) <> "" Then Kill(sFolder & sFile)
            If Not RunAdobe(sFolder & sFile, False) Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try

    End Function


    Public Function ConcatPages(listFilesFrom As List(Of String), sFileTo As String) As Boolean
        If File.Exists(sFileTo) Then File.Delete(sFileTo)
        Dim fTo As New FileStream(sFileTo, FileMode.Create)
        Dim pdfTo As PdfCopyFields = New PdfCopyFields(fTo)
        Dim reader As PdfReader

        For Each sFile As String In listFilesFrom
            reader = New PdfReader(sFile)
            pdfTo.AddDocument(reader)
            reader.Close()
        Next

        pdfTo.Close()


        ' read bytes from the FileStream.
        'Dim sr As New BinaryReader(f)
        '' While not at the end of the file, read lines from the file.
        'While sr.PeekChar() > -1
        '    Dim input As Byte = sr.ReadByte()
        '    Console.WriteLine(input)
        'End While
        'sr.Close()

        'Dim doc As New Document
        'Dim doccopy As PdfCopy

        'doccopy = New PdfCopy(doc, f)
        'doc.Open()
        'Dim reader As PdfReader
        'reader = New PdfReader("d:\copyfrom.pdf")
        'Dim i As Integer = 0
        'For i = 1 To reader.NumberOfPages
        '    doccopy.AddPage(doccopy.GetImportedPage(reader, i))
        'Next
        'doc.Close()



        Return True
    End Function

    Public Function RunAdobe(ByVal sPDFfilename As String, ByVal sExportFolder As String) As Boolean
        Return RunAdobe(sPDFfilename, False, sExportFolder)
    End Function
    Public Function RunAdobe(ByVal sPDFfilename As String, ByVal bSendToPrinter As Boolean) As Boolean
        Return RunAdobe(sPDFfilename, bSendToPrinter, "")
    End Function
    Public Function RunAdobe(ByVal sPDFfilename As String, ByVal bSendToPrinter As Boolean, ByVal sExportFolder As String) As Boolean
        Dim frm As Form, frmP As frmPDF

        Try

            If bSendToPrinter Then
                Dim myprocess As New Process
                myprocess.StartInfo.FileName = sPDFfilename
                myprocess.StartInfo.Verb = "Print"
                myprocess.StartInfo.CreateNoWindow = False
                myprocess.Start()
                myprocess.Dispose()
            ElseIf sExportFolder <> "" Then
                File.Copy(sPDFfilename, Path.Combine(sExportFolder, Path.GetFileName(sPDFfilename)), True)
            Else
                For Each frm In MDIParent1.MdiChildren
                    If frm.Name = "frmPDF" Then
                        frmP = frm
                        If frmP.PDFSource = sPDFfilename Then
                            frm.Focus()
                            Return True
                        End If
                    End If
                Next

                Dim frmAdobe = New frmPDF
                frmAdobe.MdiParent = MDIParent1
                frmAdobe.PDFSource = sPDFfilename
                frmAdobe.SendToPrinter = bSendToPrinter
                frmAdobe.Show()
            End If

            Return True
        Catch ex As Exception
            MsgBox("Error opening form:  " & ex.Message)
            Return False
        End Try






        'Return True





        '  lpFile: name of the file of interest
        '  lpDirectory: location of lpFile
        '  sResult: path and name of executable associated with lpFile
        '  lSuccess = FindExecutable("winhlp32.hlp", "c:\winnt\system32\", sResult)
        'lRet = FindExecutable(sPDFfilename, sPath, sResult)

        'Select Case lRet
        '    Case ERROR_NO_ASSOC ' : msg = "no association"
        '    Case ERROR_FILE_NOT_FOUND ': msg = "file not found"
        '    Case ERROR_PATH_NOT_FOUND ': msg = "path not found"
        '    Case ERROR_BAD_FORMAT ': msg = "bad format"
        '    Case Is >= ERROR_SUCCESS
        '        lPos = InStr(sResult, Chr(0))
        '        If lPos > 0 Then
        '            sEXEName = Left$(sResult, lPos - 1)
        '        End If
        'End Select


        'System.Diagnostics.Process.Start(sEXEName, " /n /s /o " & sPDFfilename)

        ''       lRet = ShellExecute(lHWND, "Open", sEXEName, _
        ''                " /n /s /o " & sPDFfilename, sPath, SW_SHOWNORMAL)







        'First try ShellExecute
        '    lRet = apiShellExecute(hWndAccessApp, vbNullString, _
        '            PDFfilename, vbNullString, vbNullString, lShowHow)
        '    If m_bPreviewPDFs Then
        'lRet = ShellExecute(lHWND, "Open", PDFfilename, "", sPath, SW_SHOWNORMAL)
        '       If ret = SE_ERR_NOASSOC Then   'no association exists
        '           RetVal = ShellExecute(Me.hwnd, "Open", sRun, sParameters + PDFfilename, sPath, SW_SHOWNORMAL)
        '       End If
        '    elseIf m_bPrintPDFs Then
        '       lRet = ShellExecute(Me.hwnd, "Print", PDFfilename, "", sPath, 0)
        '       If RetVal = SE_ERR_NOASSOC Then   'no association exists
        '           RetVal = ShellExecute(Me.hwnd, "Open", sRun, sParameters + PDFfilename, sPath, SW_SHOWNORMAL)
        '       End If
        '    End If

        'If lRet > ERROR_SUCCESS Then
        '    stRet = vbNullString
        '    lRet = -1
        'Else
        '    Select Case lRet
        '        Case ERROR_NO_ASSOC
        '            'Try the OpenWith dialog
        '            varTaskID = ShellExecute(lHWND, "Open", sRun, sParameters + PDFfilename, sPath, SW_SHOWNORMAL)
        '            lRet = (varTaskID <> 0)
        '        Case ERROR_OUT_OF_MEM
        '            stRet = "Error: Out of Memory/Resources. Couldn't Execute!"
        '        Case ERROR_FILE_NOT_FOUND
        '            stRet = "Error: File not found.  Couldn't Execute!"
        '        Case ERROR_PATH_NOT_FOUND
        '            stRet = "Error: Path not found. Couldn't Execute!"
        '        Case ERROR_BAD_FORMAT
        '            stRet = "Error:  Bad File Format. Couldn't Execute!"
        '        Case Else
        '    End Select
        'End If
        'RunAdobe = lRet & _
        '            IIf(stRet = "", vbNullString, ", " & stRet)
    End Function

    Public Function AppendTaxBills(ByVal dt As DataTable, ByVal enumProp As enumTable, ByVal sReportFile As String) As String
        Dim row As DataRow, lClientId As Long = 0, lLocationId As Long = 0
        Dim lAssessmentId As Long = 0, lCollectorId As Long = 0, iTaxYear As Integer = 0
        Dim sTaxBillFile As String = ""
        Dim sReportPath As String = Directory.GetParent(sReportFile).FullName
        Dim sNewReportFile As String = Replace(sReportFile, ".pdf", "_Combined.pdf", , , CompareMethod.Text)
        Dim bFoundTaxBills As Boolean = False
        Dim fTo As FileStream
        Dim pdfTo As PdfCopyFields
        Dim reader As PdfReader


        If Microsoft.VisualBasic.Right(sReportPath, 1) <> "\" Then sReportPath = sReportPath & "\"
        'create new combined pdf
        File.Delete(sNewReportFile)
        fTo = New FileStream(sNewReportFile, FileMode.Append, FileAccess.Write)
        pdfTo = New PdfCopyFields(fTo)
        'read report
        reader = New PdfReader(sReportFile)
        'add report to combined pdf
        pdfTo.AddDocument(reader)
        'pdfTo.Close()
        'fTo.Close()

        For Each row In dt.Rows
            If row("ClientId") <> lClientId Or row("LocationId") <> lLocationId Or
                    row("AssessmentId") <> lAssessmentId Or row("CollectorId") <> lCollectorId Or
                    row("TaxYear") <> iTaxYear Then

                lClientId = row("ClientId")
                lLocationId = row("LocationId")
                lAssessmentId = row("AssessmentId")
                lCollectorId = row("CollectorId")
                iTaxYear = row("TaxYear")

                sTaxBillFile = lClientId & "_" & lLocationId & "_" & lAssessmentId & "_" & lCollectorId & "_" & iTaxYear & ".pdf"

                RetrieveTaxBillBLOB(IIf(enumProp = enumTable.enumLocationBPP, "TaxBillsBPP", "TaxBillsRE"),
                        lClientId, lLocationId, lAssessmentId, lCollectorId, iTaxYear,
                        sReportPath & sTaxBillFile)
                If File.Exists(sReportPath & sTaxBillFile) Then
                    bFoundTaxBills = True
                    'fTo = New FileStream(sNewReportFile, FileMode.Append, FileAccess.Write)
                    'pdfTo = New PdfCopyFields(fTo)
                    'read report
                    'reader = New PdfReader(sReportFile)
                    'add report to combined pdf
                    'pdfTo.AddDocument(reader)
                    'read tax bill
                    reader = New PdfReader(sReportPath & sTaxBillFile)
                    'add tax bill to combined pdf
                    pdfTo.AddDocument(reader)
                    'reader.Close()
                    'pdfTo.Close()
                    'fTo.Close()
                End If
            End If
        Next

        reader.Close()
        pdfTo.Close()
        fTo.Close()

        'If bFoundTaxBills Then
        Return sNewReportFile
        'Else
        'Return sReportFile
        'End If

    End Function


    Public Function ViewTaxBill(ByVal sTable As String, ByVal lClientId As Long, ByVal lLocationId As Long, ByVal lAssessmentId As Long,
            ByVal lCollectorId As Long, ByVal iTaxYear As Integer, ByVal sFile As String, ByVal bPrint As Boolean, ByRef sError As String) As Boolean
        Try
            sError = ""
            Dim reader As PdfReader
            'Dim stamper As PdfStamper
            'Dim tofields As AcroFields
            'Dim field As DictionaryEntry
            Dim sName As String = ""
            Dim sPath As String = AppData.TempPath & "\taxbills\"



            Directory.CreateDirectory(sPath)
            sFile = sFile & ".pdf"
            If Dir(sPath & sFile) <> "" Then Kill(sPath & sFile)
            If Not RetrieveTaxBillBLOB(sTable, lClientId, lLocationId, lAssessmentId, lCollectorId, iTaxYear, sPath & sFile) Then

            End If
            reader = New PdfReader(sPath & sFile)
            'stamper = New PdfStamper(reader, New FileStream(sPath & sFile & ".pdf", FileMode.Create))
            'stamper.FormFlattening = True
            'stamper.Close()
            reader.Close()
            If Not RunAdobe(sPath & sFile, bPrint) Then
                Return False
            Else
                Return True
            End If








            Return True
        Catch ex As Exception
            sError = "Error viewing tax bill:  " & ex.Message
            Return False
        End Try
    End Function

End Module

