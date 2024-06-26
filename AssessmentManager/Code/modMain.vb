Imports System.IO
Imports iTextSharp.text.pdf

Module modMain

    'add delete prospect to all prospect lists (msg if any accounts linked to prospect)
    'add ability to push account info to live data
    'add form for sales correspondence (need names of fields, etc).  Import form



    Public Const FORMATDATETIME As String = "MM/dd/yyyy hh:mm:ss"
    Public Const LEASEDEQUIPMENT As String = "Leased Equipment"
    Public Const LEASEDVEHICLES As String = "Leased Vehicles"
    Public Const LEASEHOLDIMPROVEMENTS As String = "Leasehold Improvements"
    Public cData As New clsData
    Public cLocalData As New clsData
    Public AppData As structApp
    Public Structure structApp
        Friend AppName As String
        Friend AppPath As String
        Friend myRandom As Random
        Friend Server As String
        Friend TempPath As String
        Friend TaxYear As Integer
        Friend UserPath As String
        Friend UserId As String
        Friend Version As String
        Friend IncludeInactive As Boolean
        Friend ReportId As Long
        Friend FirmName As String
        Friend FirmAddress As String
        Friend FirmCity As String
        Friend FirmStateCd As String
        Friend FirmZip As String
        Friend FirmPhone As String
        Friend FirmFax As String
        Friend AppCompanyName As String
        Friend ColumnWidthChanged As Boolean
        Friend PrintServer As Boolean
        Friend ConsultantName As String
        Friend FullName As String
    End Structure
    Public Enum enumSavingsExclusionCd
        enumNone = 0
        enumNotified = 1
        enumAbatements = 2
        enumNotifiedAbatements = 3
        enumFreeport = 4
        enumNotifiedFreeport = 5
        enumAbatementsFreeport = 6
        enumNotifiedAbatementsFreeport = 7
        enumEntire = 8
        enumClient = 9
        enumClientAbatements = 10
        enumClientFreeport = 11
        enumClientAbatementsFreeport = 12
    End Enum
    Public Structure structAssessment
        Friend ClientId As Long
        Friend LocationId As Long
        Friend AssessmentId As Long
        Friend JurisdictionList As List(Of Long)
        Friend TaxYear As Integer
        Friend Description As String
        Friend AssessorId As Long
        Friend StateCd As String
        Friend PropType As String
        Friend FactorEntityId1 As Long
    End Structure
    Public Structure structTotals
        Friend sDescription As String
        Friend lId As Long
        Friend dAmount As Double
        Friend bLoaded As Boolean
    End Structure
    Public Enum enumReport
        enumUnknown
        enumAssetDetail
        enumAssetSummary
        enumRenditionForm
        enumFreeportForm
        enumValueProtestForm
        enumAssetDetailCost
        enumAssetDetailNon
        enumAssetDetailExempt
        enumTaxBill
        enumTaxBillCheckOff
        enumAppointmentOfAgentForm
        enumAssetImport
        enumClientEnvelope
        enumAssessorEnvelope
        enumRenditionExtensionForm
        enumRenditionDueDate
        enumMissingTaxBills
        enumMissingNotice
        enumClientContract
        enumCertificateOfMailing
        enumClientLocationListing
        enumFixedAssetReconByGLCode
        enumFixedAssetReconByDeprCode
        enumTaxAccrual
        enumTaxSavings
        enumAssessorCover
        enumBarCode
        enumREComp
        enumBPPCompBarCode
        enumBatchRendition
        enumBatchValueProtest
        enumCompletedRenditions
        enumAffidavitOfEvidence
        enumCorrection
        enumValueComparison
        enumAssetDetailLeasedProperty
        enumAssetDetailLeaseholdImprovements
        enumAssetDetailLeasesAll
        enumTaxAccrualSummary
        enumAssessorValueProtestEnvelope
        enumLeaseSummary
    End Enum
    Public Enum enumContactTypes
        enumTax
        enumInvoice
        enumContract
        enumInformation
        enumMisc
    End Enum
    Public Enum enumTable
        enumUnknown
        enumClient
        enumLocationBPP
        enumLocationRE
        enumAssessmentBPP
        enumAssessmentRE
        enumAssessor
        enumAsset
        enumFactorEntity
        enumFactorCode
        enumFactor
        enumStateFactorCode
        enumClientGLCode
        enumFactorCodeXRef
        enumJurisdiction
        enumCollector
        enumStateForms
        enumClientForms
        enumTaskMasterList
        enumTask
        enumTaskAssignment
        enumProspect
        enumProspectLocation
        enumTaxBillsBPP
        enumTaxBillsRE
        enumQuery
        enumREComps
        enumRECompsCounty
        enumBusinessUnits
        enumAgency
    End Enum
    Public Enum enumListType
        enumUnknown
        enumClient
        enumLocationRE
        enumAssessmentRE
        enumLocationBPP
        enumAssessmentBPP
        enumAssessor
        enumJurisdiction
        enumCollector
        enumAssets
        enumClientFactors
        enumClientGLCodeXRef
        enumStateFactorCodes
        enumFactoringEntities
        enumFactorCodes
        enumFactors
        enumRenditions
        enumFactorCodeXRef
        enumRenditionDueDates
        enumTaskMasterList
        enumTaskAssignments
        enumAssessmentRETaxBills
        enumAssessmentBPPTaxBills
        enumProspect
        enumProspectLocations
        enumProspectValues
        enumProspectTotalValues
        enumAssessmentRETotalTaxBills
        enumAssessmentBPPTotalTaxBills
        enumFixedAssetReconciliation
        enumQueryList
        enumQueryResults
        enumSavings
        enumRECompList
    End Enum
    Public Enum enumBarCodeTypes
        Audit = 1
        Data = 2
        Exempt = 3
        Communication = 4
        Notice = 5
        Rendition = 6
        Report = 7
        TaxBill = 8
        Protest = 9
        Evidence = 10
        VSR = 11
        HearingNotice = 12
        HearingFinalOrder = 13
        AOA = 14
        BPPComps = 15
        Extension = 16
        V1AGR = 17
        V1Lawsuit = 18
    End Enum
    Public Enum enumPropType
        Both
        BPP
        Real
    End Enum

    Public Function StartApp() As Boolean
        Dim sError As String = "", sPath As String

        AppData.myRandom = New Random
        AppData.AppName = Trim(Application.ProductName)
        AppData.ColumnWidthChanged = False
        AppData.Version = Application.ProductVersion
        AppData.UserPath = Application.LocalUserAppDataPath
        AppData.AppPath = Trim(Application.StartupPath)
        AppData.AppCompanyName = Trim(Application.CompanyName)
        AppData.PrintServer = False
        If Environment.GetCommandLineArgs.Length > 1 Then
            If Environment.GetCommandLineArgs(1).ToString = "P" Then
                AppData.PrintServer = True
            End If
        End If

        AppData.ReportId = 1

        AppData.TaxYear = GetSetting(AppData.AppName, "Configuration", "TaxYear", CStr(Year(Now)))
        AppData.UserId = Microsoft.VisualBasic.Left(Trim(UCase(Environ("username"))), 30)

        sPath = Trim(Environ("APPDATA"))
        If Right(sPath, 1) <> "\" Then sPath = sPath & "\"
        sPath = sPath & AppData.AppCompanyName & "\"
        Directory.CreateDirectory(sPath & "\" & AppData.AppName)
        AppData.Server = GetSetting(AppData.AppName, "Configuration", "Server")
        ''AppData.Server = "10.10.1.4\SQLEXPRESs"
        AppData.IncludeInactive = IIf(GetSetting(AppData.AppName, "Configuration", "IncludeInactive", "1") = "1", True, False)

        ConnectToDB()

        AppData.TempPath = Environ("temp") & "\" & AppData.AppCompanyName & "\" & AppData.AppName
        DeleteTempFolder()
        Directory.CreateDirectory(AppData.TempPath)
        LoadDropDowns()
        GetDataDefinition("", "", enumDataTypes.eDataUnknown, True, 0, "")
        LoadFirmInfo()
        InitializeQueries()
        LoadColumnWidths()

        Return True



    End Function
    Public Function CloseApp() As Boolean
        Try
            SaveColumnWidths()
            cData.CloseConnection()

        Catch ex As Exception

        End Try

    End Function
    Private Function SaveColumnWidths() As Boolean
        Try

            If AppData.ColumnWidthChanged = False Then Return True
            Dim sql As StringBuilder = New StringBuilder, sArray() As String
            Dim sqlvalues As StringBuilder = New StringBuilder
            sql.Clear()
            sqlvalues.Clear()
            sql.Append(" DELETE ColumnWidths WHERE UserName = " & QuoStr(AppData.UserId))
            sql.Append(" INSERT ColumnWidths (UserName, ListId, QueryId, ColumnName, ColumnWidth) VALUES ")
            For Each kvp As KeyValuePair(Of String, Long) In dicColumnWidths
                sArray = Split(kvp.Key, "|")
                If sqlvalues.Length > 0 Then sqlvalues.Append(" , ")
                sqlvalues.Append(" ( ").Append(QuoStr(AppData.UserId) & "," & sArray(0) & "," & sArray(1) & "," & QuoStr(sArray(2)) & "," & Val(kvp.Value)).Append(" ) ")
            Next
            ExecuteSQL(sql.ToString & sqlvalues.ToString)

        Catch ex As Exception

        End Try
    End Function
    Private Function LoadColumnWidths() As Boolean
        Try
            Dim sSQL As String = "SELECT ListId, QueryId, ColumnName, ColumnWidth FROM ColumnWidths WHERE UserName = " & QuoStr(AppData.UserId) & " ORDER BY ListId, QueryId, ColumnName"
            Dim dt As New DataTable

            dicColumnWidths = New Dictionary(Of String, Long)
            GetData(sSQL, dt)
            For Each row As DataRow In dt.Rows
                dicColumnWidths.Add(row("ListId") & "|" & row("QueryId") & "|" & row("ColumnName"), row("ColumnWidth"))
            Next
        Catch ex As Exception

        End Try
    End Function
    Public Function GetColumnWidth(ByVal listtype As enumListType, ByVal queryid As Long, ByVal sColumnName As String) As Long
        Try
            Dim sKey As String = ""
            sKey = listtype & "|" & queryid & "|" & sColumnName
            Return Val(dicColumnWidths(sKey))
        Catch ex As Exception
            Return sColumnName.Length * 10
        End Try
    End Function
    Public Function SetColumnWidth(ByVal listtype As enumListType, ByVal queryid As String, ByVal columnname As String, ByVal columnwidth As Long) As Boolean
        Try
            Dim sKey As String = ""
            sKey = listtype & "|" & queryid & "|" & columnname
            If dicColumnWidths.ContainsKey(sKey) Then
                dicColumnWidths(sKey) = CLng(columnwidth)
            Else
                dicColumnWidths.Add(sKey, CLng(columnwidth))
            End If
        Catch ex As Exception
        End Try
    End Function
    Private Function DeleteTempFolder() As Boolean
        Try
            Directory.Delete(AppData.TempPath, True)
        Catch ex As Exception

        End Try
    End Function
    Public Function OpenClient(ByVal lClientId As Long) As Boolean
        If lClientId = 0 Then Return False
        Dim frm As Form, frmc As frmClient

        For Each frm In MDIParent1.MdiChildren
            If frm.Name = "frmClient" Then
                frmc = frm
                If frmc.ClientId = lClientId Then
                    frmc.ClientId = lClientId
                    frmc.Focus()
                    Return True
                End If
            End If
        Next
        frmc = New frmClient
        frmc.ClientId = lClientId
        frmc.MdiParent = MDIParent1
        frmc.Show()
    End Function
    Public Function OpenAssessor(ByVal lAssessorId As Long, ByVal iTaxYear As Integer) As Boolean
        If lAssessorId = 0 Then Return False
        Dim frm As Form, frmc As frmAssessor

        For Each frm In MDIParent1.MdiChildren
            If frm.Name = "frmAssessor" Then
                frmc = frm
                If frmc.AssessorId = lAssessorId Then
                    frmc.Focus()
                    Return True
                End If
            End If
        Next
        frmc = New frmAssessor
        frmc.AssessorId = lAssessorId
        frmc.TaxYear = iTaxYear
        frmc.MdiParent = MDIParent1
        frmc.Show()
    End Function

    Public Function OpenTask(ByVal lTaskId As Long) As Boolean
        If lTaskId = 0 Then Return False
        Dim frm As Form, frmc As frmTask

        For Each frm In MDIParent1.MdiChildren
            If frm.Name = "frmTask" Then
                frmc = frm
                If frmc.TaskId = lTaskId Then
                    frmc.Focus()
                    Return True
                End If
            End If
        Next
        frmc = New frmTask
        frmc.TaskId = lTaskId
        frmc.MdiParent = MDIParent1
        frmc.Show()
    End Function

    Public Function OpenJurisdiction(ByVal lJurisdictionId As Long, ByVal iTaxYear As Integer) As Boolean
        If lJurisdictionId = 0 Then Return False
        Dim frm As Form, frmc As frmJurisdiction

        For Each frm In MDIParent1.MdiChildren
            If frm.Name = "frmJurisdiction" Then
                frmc = frm
                If frmc.JurisdictionId = lJurisdictionId Then
                    frmc.Focus()
                    Return True
                End If
            End If
        Next
        frmc = New frmJurisdiction
        frmc.JurisdictionId = lJurisdictionId
        frmc.TaxYear = iTaxYear
        frmc.MdiParent = MDIParent1
        frmc.Show()
    End Function

    Public Function OpenCollector(ByVal lCollectorId As Long, ByVal iTaxYear As Integer) As Boolean
        If lCollectorId = 0 Then Return False
        Dim frm As Form, frmc As frmCollector

        For Each frm In MDIParent1.MdiChildren
            If frm.Name = "frmCollector" Then
                frmc = frm
                If frmc.CollectorId = lCollectorId Then
                    frmc.Focus()
                    Return True
                End If
            End If
        Next
        frmc = New frmCollector
        frmc.CollectorId = lCollectorId
        frmc.TaxYear = iTaxYear
        frmc.MdiParent = MDIParent1
        frmc.Show()
    End Function

    Public Function OpenBPPLocation(ByVal lClientId As Long, ByVal lLocationId As Long, ByVal iTaxYear As Integer, ByRef sMsg As String) As Boolean
        If lClientId = 0 Or lLocationId = 0 Or iTaxYear = 0 Then Return False

        If iTaxYear <> AppData.TaxYear Then
            sMsg = "Must change the tax year to " & iTaxYear & " to open location"
            Return False
        End If

        Dim frm As Form, frml As frmLocationBPP

        For Each frm In MDIParent1.MdiChildren
            If frm.Name = "frmLocationBPP" Then
                frml = frm
                If frml.ClientId = lClientId And frml.LocationId = lLocationId And frml.TaxYear = iTaxYear Then
                    frml.ClientId = lClientId
                    frml.LocationId = lLocationId
                    frml.TaxYear = iTaxYear
                    frml.Focus()
                    Return True
                End If
            End If
        Next
        frml = New frmLocationBPP
        frml.ClientId = lClientId
        frml.LocationId = lLocationId
        frml.TaxYear = iTaxYear
        frml.MdiParent = MDIParent1
        frml.Show()
        Return True
    End Function

    Public Function OpenProspectLocation(ByVal lClientId As Long, ByVal lLocationId As Long) As Boolean
        If lClientId = 0 Or lLocationId = 0 Then Return False
        Dim frm As Form, frmp As frmProspectLocation

        For Each frm In MDIParent1.MdiChildren
            If frm.Name = "frmProspectLocation" Then
                frmp = frm
                If frmp.ClientId = lClientId And frmp.LocationId = lLocationId Then
                    frmp.ClientId = lClientId
                    frmp.LocationId = lLocationId
                    frmp.Focus()
                    Return True
                End If
            End If
        Next
        frmp = New frmProspectLocation
        frmp.ClientId = lClientId
        frmp.LocationId = lLocationId
        frmp.MdiParent = MDIParent1
        frmp.Show()
        Return True
    End Function

    Public Function OpenRELocation(ByVal lClientId As Long, ByVal lLocationId As Long, ByVal iTaxYear As Integer, ByRef sMsg As String) As Boolean
        If lClientId = 0 Or lLocationId = 0 Or iTaxYear = 0 Then Return False

        If iTaxYear <> AppData.TaxYear Then
            sMsg = "Must change the tax year to " & iTaxYear & " to open location"
            Return False
        End If

        Dim frm As Form, frml As frmLocationRE

        For Each frm In MDIParent1.MdiChildren
            If frm.Name = "frmLocationRE" Then
                frml = frm
                If frml.ClientId = lClientId And frml.LocationId = lLocationId And frml.TaxYear = iTaxYear Then
                    frml.ClientId = lClientId
                    frml.LocationId = lLocationId
                    frml.TaxYear = iTaxYear
                    frml.Focus()
                    Return True
                End If
            End If
        Next
        frml = New frmLocationRE
        frml.ClientId = lClientId
        frml.LocationId = lLocationId
        frml.TaxYear = iTaxYear
        frml.MdiParent = MDIParent1
        frml.Show()
        Return True
    End Function
    'Public Function OpenRendition(ByVal lClientId As Long, ByVal lLocationId As Long, ByVal lAssessmentId As Long, _
    '        ByVal iTaxYear As Integer) As Boolean
    '    If lClientId = 0 Or lLocationId = 0 Or lAssessmentId = 0 Or iTaxYear = 0 Then Return False
    '    Dim frm As Form, frmr As frmRendition

    '    For Each frm In MDIParent1.MdiChildren
    '        If frm.Name = "frmRendition" Then
    '            frmr = frm
    '            If frmr.ClientId = lClientId And frmr.LocationId = lLocationId And frmr.AssessmentId = lAssessmentId And frmr.TaxYear = iTaxYear Then
    '                frmr.ClientId = lClientId
    '                frmr.LocationId = lLocationId
    '                frmr.AssessmentId = lAssessmentId
    '                frmr.TaxYear = iTaxYear
    '                frmr.Focus()
    '                Return True
    '            End If
    '        End If
    '    Next
    '    frmr = New frmRendition
    '    frmr.ClientId = lClientId
    '    frmr.LocationId = lLocationId
    '    frmr.AssessmentId = lAssessmentId
    '    frmr.TaxYear = iTaxYear
    '    frmr.MdiParent = MDIParent1
    '    frmr.Show()
    'End Function

    Public Function OpenClientGLCode(ByVal lClientId As Long, _
            ByVal sClientGLCode As String, ByVal sStateCd As String, ByVal lFactoringEntityId As Long, ByVal iTaxYear As Integer) As Boolean

        If lClientId = 0 Or sClientGLCode = "" Or sStateCd = "" Then Return False
        Dim frm As Form, frmx As frmGLCodeXRef

        For Each frm In MDIParent1.MdiChildren
            If frm.Name = "frmGLCodeXRef" Then
                frmx = frm
                If frmx.ClientId = lClientId And frmx.GLCode = sClientGLCode And _
                        frmx.StateCd = sStateCd And frmx.FactoringEntityId = lFactoringEntityId And frmx.TaxYear = iTaxYear Then
                    'frmx.ClientId = lClientId
                    'frmr.LocationId = lLocationId
                    'frmr.AssessmentId = lAssessmentId
                    'frmr.TaxYear = iTaxYear
                    frmx.Focus()
                    Return True
                End If
            End If
        Next
        frmx = New frmGLCodeXRef
        frmx.ClientId = lClientId
        frmx.GLCode = sClientGLCode
        frmx.StateCd = sStateCd
        frmx.TaxYear = iTaxYear
        frmx.FactoringEntityId = lFactoringEntityId
        frmx.MdiParent = MDIParent1
        frmx.Show()



    End Function


    Public Function OpenFactorXRef(ByVal sStateCd As String, ByVal lFactorEntityId As Long, _
            ByVal sEntityFactorCode As String, ByVal sStateFactorCode As String, ByVal iTaxYear As Integer) As Boolean
        If sStateCd = "" Or lFactorEntityId = 0 Or sEntityFactorCode = "" Or sStateCd = "" Then Return False
        Dim frm As Form, frmx As frmFactorXRef

        For Each frm In MDIParent1.MdiChildren
            If frm.Name = "frmFactorXRef" Then
                frmx = frm
                If frmx.FactorEntityId = lFactorEntityId And frmx.EntityFactorCode = sEntityFactorCode Then
                    frmx.Focus()
                    Return True
                End If
            End If
        Next
        frmx = New frmFactorXRef
        frmx.FactorEntityId = lFactorEntityId
        frmx.EntityFactorCode = sEntityFactorCode
        frmx.StateCd = sStateCd
        frmx.TaxYear = iTaxYear
        frmx.OldStateFactorCode = sStateFactorCode
        frmx.MdiParent = MDIParent1
        frmx.Show()
        Return True
    End Function
    Public Function RunQuery(ByVal lQueryId As Long, iQueryType As Integer) As Boolean
        If lQueryId = 0 Then Return False
        Dim frm As Form, frmx As frmList

        For Each frm In MDIParent1.MdiChildren
            If frm.Name = "frmList" Then
                frmx = frm
                If frmx.ListType = enumListType.enumQueryResults And frmx.QueryId = lQueryId Then
                    frmx.Focus()
                    Return True
                End If
            End If
        Next
        frmx = New frmList
        frmx.ListType = enumListType.enumQueryResults
        frmx.QueryType = iQueryType
        frmx.QueryId = lQueryId
        frmx.MdiParent = MDIParent1
        frmx.Show()
        Return True

    End Function
    Public Function OpenQueryProperties(ByVal lQueryId As Long, ByVal iQueryType As Integer) As Boolean
        If lQueryId = 0 Then Return False
        Dim frm As Form, frmx As frmQueryProperties

        For Each frm In MDIParent1.MdiChildren
            If frm.Name = "frmQueryProperties" Then
                frmx = frm
                If frmx.QueryId = lQueryId Then
                    frmx.Focus()
                    Return True
                End If
            End If
        Next
        frmx = New frmQueryProperties
        frmx.QueryId = lQueryId
        frmx.QueryType = iQueryType
        frmx.MdiParent = MDIParent1
        frmx.Show()
        Return True
    End Function

    Public Function ExportFile(ByVal sText As String, ByVal bAppend As Boolean, ByRef sFileName As String) As Boolean
        Dim myStream As StreamWriter
        Dim saveFileDialog1 As New SaveFileDialog()

        Try
            If bAppend = False Then
                With saveFileDialog1
                    .Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
                    .FilterIndex = 2
                    .RestoreDirectory = True
                    '.CheckFileExists = True
                    '.CheckPathExists = True
                    '.DefaultExt = ".txt"
                End With
                If saveFileDialog1.ShowDialog() = DialogResult.OK Then
                    sFileName = saveFileDialog1.FileName
                End If
            End If

            myStream = New StreamWriter(sFileName, bAppend)
            myStream.Write(sText)
            myStream.Close()

            Return True
        Catch ex As Exception
            MsgBox("Error exporting:  " & ex.Message)
            Return False
        End Try


    End Function
    Public Function CleanFileName(ByVal sIn As String) As String
        Dim sTemp As String = ""

        'replace \/:*?"<>| with empty string
        sTemp = Replace(sIn, Chr(92), "")
        sTemp = Replace(sTemp, Chr(47), "")
        sTemp = Replace(sTemp, Chr(58), "")
        sTemp = Replace(sTemp, Chr(42), "")
        sTemp = Replace(sTemp, Chr(63), "")
        sTemp = Replace(sTemp, Chr(34), "")
        sTemp = Replace(sTemp, Chr(60), "")
        sTemp = Replace(sTemp, Chr(62), "")
        sTemp = Replace(sTemp, Chr(124), "")
        Return sTemp

    End Function

    ''' <summary>Call folder dialog to select folder then save folder name in app settings</summary>
    Public Function SelectFolder(ByVal sSaveSetting As String) As String
        Dim fbdFolder As New FolderBrowserDialog, sFolder As String = ""

        Try
            sFolder = Trim(GetSetting(AppData.AppName, "Configuration", sSaveSetting, ""))
            If sFolder <> "" Then fbdFolder.SelectedPath = sFolder
            sFolder = ""
            fbdFolder.ShowDialog()
            sFolder = Trim(fbdFolder.SelectedPath)
            SaveSetting(AppData.AppName, "Configuration", sSaveSetting, sFolder)

            Return sFolder
        Catch Ex As Exception
            MessageBox.Show(Ex.Message)
            Return ""
        End Try


    End Function
    Public Function ImportFile(ByRef vFileContents As Object, Optional ByRef sFile As String = "", Optional ByVal lNumberOfRows As Long = 0) As Boolean
        Dim myStream As Stream = Nothing, l As Long
        Dim openFileDialog1 As New OpenFileDialog(), bHaveSetColumns As Boolean = False, sLine As String = ""
        Dim lRowCounter As Long = 0

        ReDim vFileContents(0, 0) : sFile = ""

        'openFileDialog1.InitialDirectory = "d:\"
        openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
        openFileDialog1.FilterIndex = 2
        openFileDialog1.RestoreDirectory = True
        openFileDialog1.Multiselect = False

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                myStream = openFileDialog1.OpenFile()
                sFile = openFileDialog1.FileName

                If (myStream IsNot Nothing) Then
                    Using sr = New StreamReader(myStream)
                        lRowCounter = 0
                        Do Until sr.EndOfStream
                            lRowCounter = lRowCounter + 1
                            If lNumberOfRows > 0 And lRowCounter = lNumberOfRows Then
                                Exit Do
                            Else
                                'replace quote with space
                                sLine = Trim(sr.ReadLine)
                                If sLine <> "" Then
                                    Dim sLineContents() As String = Split(sLine, vbTab)
                                    If Not bHaveSetColumns Then
                                        ReDim vFileContents(UBound(sLineContents), 0)
                                        bHaveSetColumns = True
                                    End If
                                    If Trim(UnNullToString(vFileContents(0, 0))) <> "" Then
                                        ReDim Preserve vFileContents(UBound(vFileContents, 1), UBound(vFileContents, 2) + 1)
                                    End If
                                    For l = 0 To UBound(sLineContents)
                                        vFileContents(l, UBound(vFileContents, 2)) = sLineContents(l)
                                    Next
                                End If
                            End If
                        Loop
                    End Using
                    Return True
                Else
                    Return False
                End If
            Catch Ex As Exception
                MessageBox.Show("Cannot read file from disk. Original error: " & Ex.Message & ", line contents:  " & sLine)
            Finally
                ' Check this again, since we need to make sure we didn't throw an exception on open.
                If (myStream IsNot Nothing) Then
                    myStream.Close()
                End If
            End Try
        Else
            Return False
        End If
    End Function

    Public Sub PlaceButtons(ByVal frmCurrent As Form, ByVal ctlButton() As Control)
        Dim i As Integer, mesize As Size = frmCurrent.ClientSize

        ctlButton(0).Top = mesize.Height - ctlButton(0).Height - 5
        For i = 1 To UBound(ctlButton)
            ctlButton(i).Top = ctlButton(0).Top
        Next i
        ctlButton(0).Left = (mesize.Width - ((UBound(ctlButton) + 1) * (ctlButton(0).Width + 5))) / 2
        For i% = 1 To UBound(ctlButton)
            ctlButton(i%).Left = ctlButton(i% - 1).Left + ctlButton(i% - 1).Width + 5
        Next i%
    End Sub

    Public Function OpenStateFactorCodes(ByVal sStateCd As String, ByVal sFactorCode As String) As Boolean
        If sStateCd = "" Then Return False
        Dim frm As Form, frmx As frmStateFactorCodes

        For Each frm In MDIParent1.MdiChildren
            If frm.Name = "frmStateFactorCodes" Then
                frmx = frm
                If frmx.StateCd = sStateCd And frmx.FactorCode = sFactorCode Then
                    'frmx.ClientId = lClientId
                    'frmr.LocationId = lLocationId
                    'frmr.AssessmentId = lAssessmentId
                    'frmr.TaxYear = iTaxYear
                    frmx.Focus()
                    Return True
                End If
            End If
        Next
        frmx = New frmStateFactorCodes
        frmx.StateCd = sStateCd
        frmx.FactorCode = sFactorCode
        frmx.MdiParent = MDIParent1
        frmx.Show()


    End Function

    Public Function OpenList(ByVal eListType As enumListType, Optional ByVal lClientId As Long = 0, _
            Optional ByVal lLocationId As Long = 0, _
            Optional ByVal lAssessmentId As Long = 0, Optional ByVal lFactoringEntityId As Long = 0, _
            Optional ByVal sFactorCode As String = "", _
            Optional ByVal sAdditionalText As String = "", _
            Optional ByVal sStateCd As String = "") As Boolean
        Dim frm As Form, frml As frmList

        Try
            For Each frm In MDIParent1.MdiChildren
                If frm.Name = "frmList" Then
                    frml = frm
                    If eListType = enumListType.enumFactors Then
                        If frml.FactoringEntityId = lFactoringEntityId And frml.FactorCode = sFactorCode Then
                            frm.Focus()
                            Return True
                        End If
                    ElseIf eListType = enumListType.enumFactorCodes Then
                        If frml.FactoringEntityId = lFactoringEntityId And frml.ListType = eListType Then
                            frm.Focus()
                            Return True
                        End If
                    ElseIf eListType = enumListType.enumAssets Or eListType = enumListType.enumAssessmentBPP Then
                        If frml.ListType = eListType And frml.ClientId = lClientId And frml.LocationId = lLocationId And frml.AssessmentId = lAssessmentId Then
                            frm.Focus()
                            Return True
                        End If
                    ElseIf eListType = enumListType.enumProspectValues Then
                        If frml.ListType = eListType And frml.ClientId = lClientId Then
                            frm.Focus()
                            Return True
                        End If
                    ElseIf eListType = enumListType.enumClientGLCodeXRef Then
                        If frml.ListType = eListType And frml.ClientId = lClientId And frml.FactoringEntityId = lFactoringEntityId Then
                            frm.Focus()
                            Return True
                        End If
                    Else
                        If frml.ListType = eListType Then
                            frm.Focus()
                            Return True
                        End If
                    End If
                End If
            Next

            Dim frmChild As New frmList
            frmChild.MdiParent = MDIParent1
            frmChild.ListType = eListType
            frmChild.TaxYear = AppData.TaxYear
            If eListType = enumListType.enumFactors Then
                frmChild.FactoringEntityId = lFactoringEntityId
                frmChild.FactorCode = sFactorCode
            ElseIf eListType = enumListType.enumFactorCodes Then
                frmChild.FactoringEntityId = lFactoringEntityId
                frmChild.AdditionalText = sAdditionalText
            ElseIf eListType = enumListType.enumAssets Or eListType = enumListType.enumAssessmentBPP Then
                frmChild.ClientId = lClientId
                frmChild.LocationId = lLocationId
                frmChild.AssessmentId = lAssessmentId
            ElseIf eListType = enumListType.enumProspectValues Then
                frmChild.ClientId = lClientId
            ElseIf eListType = enumListType.enumClientGLCodeXRef Then
                frmChild.ClientId = lClientId
                frmChild.FactoringEntityId = lFactoringEntityId
                frmChild.StateCd = sStateCd
                frmChild.AdditionalText = sAdditionalText
            End If

            frmChild.Show()
        Catch ex As Exception

        End Try
    End Function



    Public Function OpenFactor(ByVal lFactorEntityId As Long, _
        ByVal sFactorCode As String, ByVal iAge As Integer, ByVal iTaxYear As Integer) As Boolean

        If lFactorEntityId = 0 Or sFactorCode = "" Or iTaxYear = 0 Then Return False
        Dim frm As Form, frmx As frmFactorCodes

        For Each frm In MDIParent1.MdiChildren
            If frm.Name = "frmFactorCodes" Then
                frmx = frm
                If frmx.FactorEntityId = lFactorEntityId And frmx.FactorCode = sFactorCode And frmx.Age = iAge And frmx.TaxYear = iTaxYear Then
                    frmx.Focus()
                    Return True
                End If
            End If
        Next
        frmx = New frmFactorCodes
        frmx.FactorEntityId = lFactorEntityId
        frmx.FactorCode = sFactorCode
        frmx.Age = iAge
        frmx.TaxYear = iTaxYear
        frmx.MdiParent = MDIParent1
        frmx.Show()



    End Function

    Public Function OpenAsset(ByVal lClientId As Long, _
        ByVal lLocationId As Long, ByVal lAssessmentId As Long, ByVal sAssetId As String, _
        ByVal sFactorCodes() As String, ByVal sClientFactorCodes() As String, ByVal iTaxYear As Integer) As Boolean

        If lClientId = 0 Or lLocationId = 0 Or lAssessmentId = 0 Or sAssetId = "" Or iTaxYear = 0 Then Return False
        Dim frm As Form, frmx As frmAsset

        For Each frm In MDIParent1.MdiChildren
            If frm.Name = "frmAsset" Then
                frmx = frm
                If frmx.ClientId = lClientId And frmx.LocationId = lLocationId And frmx.AssessmentId = lAssessmentId And frmx.AssetId = sAssetId And frmx.TaxYear = iTaxYear Then
                    frmx.Focus()
                    Return True
                End If
            End If
        Next
        frmx = New frmAsset
        frmx.ClientId = lClientId
        frmx.LocationId = lLocationId
        frmx.AssessmentId = lAssessmentId
        frmx.AssetId = sAssetId
        frmx.FactorCodes = sFactorCodes
        frmx.ClientFactorCodes = sClientFactorCodes
        frmx.TaxYear = iTaxYear
        frmx.MdiParent = MDIParent1
        frmx.Show()



    End Function

    Public Function ImportBatchAssets(ByVal lClientId As Long, ByVal sClientName As String, ByVal iTaxYear As Integer) As Boolean
        Dim frmI As frmBatchImportAssets
        For Each frm As Form In MDIParent1.MdiChildren
            If frm.Name = "frmBatchImportAssets" Then
                frmI = frm
                If frmI.ClientId = lClientId And _
                        frmI.TaxYear = iTaxYear Then
                    frm.Focus()
                    Exit Function
                End If
            End If
        Next
        frmI = New frmBatchImportAssets
        frmI.ClientId = lClientId
        frmI.TaxYear = iTaxYear
        frmI.MdiParent = MDIParent1
        frmI.Show()
        Return True
    End Function

    Public Function ImportAssets(ByVal lClientId As Long, ByVal lLocationId As Long, ByVal lAssessmentId As Long, ByVal iTaxYear As Integer) As Boolean
        Dim frmI As frmBatchImportAssets
        For Each frm As Form In MDIParent1.MdiChildren
            If frm.Name = "frmBatchImportAssets" Then
                frmI = frm
                If frmI.ClientId = lClientId And frmI.LocationId = lLocationId And frmI.AssessmentId = lAssessmentId And
                        frmI.TaxYear = iTaxYear Then
                    frm.Focus()
                    Exit Function
                End If
            End If
        Next
        frmI = New frmBatchImportAssets
        frmI.ClientId = lClientId
        frmI.LocationId = lLocationId
        frmI.AssessmentId = lAssessmentId
        frmI.TaxYear = iTaxYear
        frmI.MdiParent = MDIParent1
        frmI.Show()
        Return True

    End Function
    Public Function ImportLocations(ByVal lClientId As Long, ByVal sClientName As String, ByVal iTaxYear As Integer, ByVal eType As enumTable) As Boolean
        Dim frmChild As New frmImportLocations
        frmChild.ClientId = lClientId
        frmChild.ClientName = sClientName
        frmChild.TaxYear = iTaxYear
        frmChild.TypeOfImport = eType
        frmChild.ShowDialog(MDIParent1)
        frmChild.Dispose()
        Return True
    End Function
    Public Function ImportFactorCodes(ByVal lFactorEntityId As Long) As Boolean
        Dim frmChild = New frmImportFactorCodes
        frmChild.FactorEntityId = lFactorEntityId
        frmChild.ShowDialog(MDIParent1)
        frmChild.Dispose()
        Return True
    End Function

    Public Function ImportAssessments(ByVal lClientId As Long, ByVal lLocationId As Long, ByVal iTaxYear As Integer, ByVal eType As enumTable) As Boolean
        Dim frmChild As New frmImportAssessments
        frmChild.ClientId = lClientId
        frmChild.LocationId = lLocationId
        frmChild.TaxYear = iTaxYear
        frmChild.TypeOfImport = eType
        frmChild.ShowDialog(MDIParent1)
        frmChild.Dispose()
        Return True
    End Function

    Public Function ImportProspects(ByVal lAssessorId As Long, ByVal sAssessorName As String, ByVal sAssessorStateCd As String) As Boolean
        Dim frmI As frmImportProspects
        For Each frm As Form In MDIParent1.MdiChildren
            If frm.Name = "frmImportProspects" Then
                frmI = frm
                If frmI.AssessorId = lAssessorId Then
                    frm.Focus()
                    Exit Function
                End If
            End If
        Next
        frmI = New frmImportProspects
        frmI.AssessorId = lAssessorId
        frmI.AssessorName = sAssessorName
        frmI.AssessorStateCd = sAssessorStateCd
        frmI.MdiParent = MDIParent1
        frmI.Show()
        Return True
    End Function
    Public Function ImportREComps(ByVal lAssessorId As Long, ByVal sAssessorName As String) As Boolean
        Dim frmI As frmImportREComps
        For Each frm As Form In MDIParent1.MdiChildren
            If frm.Name = "frmImportREComps" Then
                frmI = frm
                If frmI.AssessorId = lAssessorId Then
                    frm.Focus()
                    Exit Function
                End If
            End If
        Next
        frmI = New frmImportREComps
        frmI.AssessorId = lAssessorId
        frmI.AssessorName = sAssessorName
        frmI.MdiParent = MDIParent1
        frmI.Show()
        Return True
    End Function
    Public Function ImportRECompsCounty(ByVal lAssessorId As Long, ByVal sAssessorName As String) As Boolean
        Dim frmI As frmImportRECompsCounty
        For Each frm As Form In MDIParent1.MdiChildren
            If frm.Name = "frmImportRECompsCounty" Then
                frmI = frm
                If frmI.AssessorId = lAssessorId Then
                    frm.Focus()
                    Exit Function
                End If
            End If
        Next
        frmI = New frmImportRECompsCounty
        frmI.AssessorId = lAssessorId
        frmI.AssessorName = sAssessorName
        frmI.MdiParent = MDIParent1
        frmI.Show()
        Return True
    End Function
    Public Function AddClient(Optional ByVal bProspect As Boolean = False) As Boolean
        Try
            Dim sName As String = Trim(InputBox("Enter client name"))
            If sName = "" Then Return False
            Dim cClient As New clsClient, sError As String = ""
            If Not cClient.CreateClient(sName, , , , , , , , True, bProspect, sError) Then
                MsgBox("Error creating client:  " & sError)
            Else
                MsgBox("Client created")
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function DeleteProspect(ByVal lClientId As Long, ByRef sError As String) As Boolean
        Dim sSQL As String
        Try
            'sSQL = "DELETE ProspectValues WHERE ClientId = " & lClientId & _
            '    " DELETE ProspectLocations WHERE ClientId = " & lClientId & _
            '    " DELETE ClientComments WHERE ClientId = " & lClientId 
            sSQL = "UPDATE Clients SET InactiveFl = 1 WHERE ClientId = " & lClientId
            ExecuteSQL(sSQL)
            Return True
        Catch ex As Exception
            sError = ex.Message
            Return False
        End Try
    End Function
    Public Function AddTask(ByVal sName As String, ByVal sDesc As String, ByRef sError As String) As Boolean
        Dim sSQL As String

        Try
            sSQL = "insert TaskMasterList (TaskId,Name,Description,AddUser)" &
                " select " & CreateID(enumTable.enumTaskMasterList) & "," & QuoStr(sName) & "," &
                QuoStr(sDesc) & "," & QuoStr(AppData.UserId)
            If ExecuteSQL(sSQL) = 1 Then Return True
        Catch ex As Exception
            sError = ex.Message
            Return False
        End Try

    End Function

    Public Function AddAsset(ByVal lClientId As Long, ByVal lLocationId As Long, ByVal lAssessmentId As Long, ByVal iTaxYear As Integer) As Boolean
        Dim sAssetId As String = Trim(InputBox("Enter asset ID"))
        If sAssetId = "" Then Exit Function
        Dim sDate As String = Trim(InputBox("Enter acquistion date"))
        If Not IsDate(sDate) Then Exit Function
        Dim sGLCode As String = Trim(InputBox("Enter G/L code"))
        If sGLCode = "" Then Exit Function
        Dim lCost As Long = Val(InputBox("Enter amount"))
        Dim sDescription As String = Trim(InputBox("Enter description"))
        Dim sVIN As String = Trim(InputBox("Enter VIN"))
        Dim sAddress As String = Trim(InputBox("Enter location address"))
        Dim sActivityQty As String = Trim(InputBox("Enter activity quantity (mileage/hours)"))
        Dim sError As String = ""
        Dim Asset As structAsset

        Asset.lClientId = lClientId
        Asset.lLocationId = lLocationId
        Asset.lAssessmentId = lAssessmentId
        Asset.iTaxYear = iTaxYear
        Asset.sAssetId = sAssetId
        Asset.lOriginalCost = lCost
        Asset.sPurchaseDate = sDate
        Asset.sGLCode = sGLCode
        Asset.sDescription = sDescription
        Asset.sVIN = sVIN
        Asset.sLocationAddress = sAddress
        Asset.ActivityQty = sActivityQty

        If Not CreateAsset(Asset, True, sError) Then
            MsgBox("Error creating asset:  " & sError)
        Else
            MsgBox("Asset created")
        End If
        Return True

    End Function
    Public Function AddAssessor(ByVal sName As String, ByVal sStateCd As String, ByRef sError As String) As Boolean
        Dim sSQL As String = "", dt As New DataTable, lAssessorId As Long = 0

        sStateCd = UCase(Trim(sStateCd))
        Try
            'not exists should handle duplicates.  otherwise the indexes will
            'sSQL = "SELECT AssessorId, TaxYear FROM Assessors WHERE Name = " & QuoStr(sName) & " AND StateCd = " & QuoStr(sStateCd)
            'If GetData(sSQL, dt) > 0 Then
            '    For Each dr As DataRow In dt.Rows
            '        lAssessorId = dr("AssessorId")
            '        If dr("TaxYear") = AppData.TaxYear Then
            '            sError = "Assessor already exists"
            '            Return False
            '        End If
            '    Next
            'End If

            sSQL = "select distinct t.TaxYear from (select " & AppData.TaxYear & " AS TaxYear union select distinct TaxYear AS TaxYear from Assessors) AS t"
            GetData(sSQL, dt)
            If lAssessorId = 0 Then lAssessorId = CreateID(enumTable.enumAssessor)
            For Each dr As DataRow In dt.Rows
                sSQL = "insert Assessors (AssessorId,StateCd,Name,TaxYear,AddUser)" &
                    " select " & lAssessorId & "," & QuoStr(sStateCd) & "," & QuoStr(sName) & "," &
                    dr("TaxYear") & "," & QuoStr(AppData.UserId) & " WHERE NOT EXISTS(SELECT * FROM Assessors" &
                    " WHERE AssessorId = " & lAssessorId & " AND TaxYear = " & dr("TaxYear") & ")"
                ExecuteSQL(sSQL)
            Next
            Return True
        Catch ex As Exception
            sError = ex.Message
            Return False
        End Try

    End Function

    Public Function AddJurisdiction(ByVal sName As String, ByVal sStateCd As String, ByRef sError As String) As Boolean
        Dim sSQL As String = "", dt As New DataTable, lId As Long = 0

        sStateCd = UCase(Trim(sStateCd))
        Try
            sSQL = "SELECT JurisdictionId, TaxYear FROM Jurisdictions WHERE Name = " & QuoStr(sName) & " AND StateCd = " & QuoStr(sStateCd)
            If GetData(sSQL, dt) > 0 Then
                For Each dr As DataRow In dt.Rows
                    lId = dr("JurisdictionId")
                    If dr("TaxYear") = AppData.TaxYear Then
                        sError = "Jurisdiction already exists"
                        Return False
                    End If
                Next
            End If

            sSQL = "select distinct t.TaxYear from (select " & AppData.TaxYear & " AS TaxYear union select distinct TaxYear AS TaxYear from Jurisdictions) AS t"
            GetData(sSQL, dt)
            If lId = 0 Then lId = CreateID(enumTable.enumJurisdiction)
            For Each dr As DataRow In dt.Rows
                sSQL = "insert Jurisdictions (JurisdictionId,StateCd,Name,TaxYear,AddUser)" & _
                    " select " & lId & "," & QuoStr(sStateCd) & "," & QuoStr(sName) & "," & _
                    dr("TaxYear") & "," & QuoStr(AppData.UserId) & " WHERE NOT EXISTS(SELECT * FROM Jurisdictions" & _
                    " WHERE JurisdictionId = " & lId & " AND TaxYear = " & dr("TaxYear") & ")"
                ExecuteSQL(sSQL)
            Next
            Return True
        Catch ex As Exception
            sError = ex.Message
            Return False
        End Try
    End Function
    Public Function AddProspectLocation(ByVal lClientId As Long, ByVal lAssessorId As Long, _
            ByVal sAcctNum As String, ByVal ePropType As enumTable, _
            ByVal sAddress As String, ByVal sCity As String, _
            ByVal sStateCd As String, ByRef sError As String) As Boolean
        Dim sSQL As String = ""
        Try
            sSQL = "INSERT ProspectLocations (ClientId, LocationId, AssessorId, AcctNum, PropType, Address, City, StateCd)" & _
                " SELECT " & lClientId & "," & CreateID(enumTable.enumProspectLocation) & "," & _
                lAssessorId & "," & QuoStr(sAcctNum) & "," & IIf(ePropType = enumTable.enumLocationBPP, "'P'", "'R'") & "," & _
                QuoStr(sAddress) & "," & _
                QuoStr(sCity) & "," & QuoStr(sStateCd)
            If ExecuteSQL(sSQL) = 1 Then Return True
        Catch ex As Exception
            sError = ex.Message
            Return False
        End Try
    End Function

    Public Function AddCollector(ByVal sName As String, ByVal sStateCd As String, ByRef sError As String) As Boolean
        Dim sSQL As String = "", dt As New DataTable, lCollectorId As Long = 0

        sStateCd = UCase(Trim(sStateCd))
        Try
            sSQL = "SELECT CollectorId, TaxYear FROM Collectors WHERE Name = " & QuoStr(sName) & " AND StateCd = " & QuoStr(sStateCd)
            If GetData(sSQL, dt) > 0 Then
                For Each dr As DataRow In dt.Rows
                    lCollectorId = dr("CollectorId")
                    If dr("TaxYear") = AppData.TaxYear Then
                        sError = "Collector already exists"
                        Return False
                    End If
                Next
            End If
            sSQL = "select distinct t.TaxYear from (select " & AppData.TaxYear & " AS TaxYear union select distinct TaxYear AS TaxYear from Collectors) AS t"
            GetData(sSQL, dt)
            If lCollectorId = 0 Then lCollectorId = CreateID(enumTable.enumCollector)
            For Each dr As DataRow In dt.Rows
                sSQL = "insert Collectors (CollectorId,StateCd,Name,TaxYear,AddUser)" & _
                    " select " & lCollectorId & "," & QuoStr(sStateCd) & "," & QuoStr(sName) & "," & _
                    dr("TaxYear") & "," & QuoStr(AppData.UserId) & " WHERE NOT EXISTS(SELECT * FROM Collectors" & _
                    " WHERE CollectorId = " & lCollectorId & " AND TaxYear = " & dr("TaxYear") & ")"
                ExecuteSQL(sSQL)
            Next
            Return True
        Catch ex As Exception
            sError = ex.Message
            Return False
        End Try

    End Function

    Public Function ImportTaxBill(ByVal lClientId As Long, ByVal lLocationId As Long, ByVal lAssessmentId As Long, _
            ByVal lCollectorId As Long, ByVal ePropType As enumTable, ByVal iTaxYear As Integer, ByVal sUserName As String, ByRef sError As String)
        Dim sSQL As String, dt As DataTable, lId As Long = 0
        Dim sPropType As String = ""

        Try
            sError = ""
            If ePropType = enumTable.enumLocationBPP Then
                sPropType = "BPP"
            Else
                sPropType = "RE"
            End If
            sSQL = "SELECT AddDate, AddUser FROM TaxBills" & sPropType & " WHERE ClientId = " & lClientId & _
                " AND LocationId = " & lLocationId & " AND AssessmentId = " & lAssessmentId & _
                " AND CollectorId = " & lCollectorId & " AND TaxYear = " & iTaxYear
            If GetData(sSQL, dt) > 0 Then
                Dim dr As DataRow = dt.Rows(0)
                If MsgBox("Tax bill already exists, added " & dr("AddDate") & " by " & dr("AddUser") & _
                          ".  Do you wish to overwrite?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    sError = ""
                    Return False
                End If
            End If

        Catch ex As Exception
            sError = ex.Message
            Return False
        End Try

        Dim openFileDialog1 As New OpenFileDialog()

        openFileDialog1.Filter = "Adobe PDF files (*.pdf)|*.pdf"
        openFileDialog1.RestoreDirectory = True
        openFileDialog1.Multiselect = False

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                Dim sFile As String = openFileDialog1.FileName

                ExecuteSQL("begin transaction")
                'sSQL = "DELETE TaxBills" & sPropType & " WHERE ClientId = " & lClientId & _
                '    " AND LocationId = " & lLocationId & " AND AssessmentId = " & lAssessmentId & _
                '    " AND CollectorId = " & lCollectorId & " AND TaxYear = " & iTaxYear
                'ExecuteSQL(sSQL)
                If StoreTaxBillBLOB("TaxBills" & sPropType, lClientId, lLocationId, lAssessmentId, lCollectorId, iTaxYear, sUserName, sFile) Then
                    ExecuteSQL("commit transaction")
                    Return True
                Else
                    ExecuteSQL("rollback transaction")
                    Return False
                End If
            Catch ex As Exception
                sError = ex.Message
                ExecuteSQL("rollback transaction")
                Return False
            End Try
        End If

    End Function

    Public Function ImportStateForm(ByVal iTaxYear As Integer, ByVal sStateCd As String, _
            ByVal sFormName As String, _
            ByVal sFormDescription As String, ByRef sError As String) As Boolean
        Dim sSQL As String, dt As DataTable, lId As Long = 0

        Try
            sStateCd = UCase(Trim(sStateCd))
            sFormName = UCase(Trim(sFormName))
            If sStateCd = "" Or sFormName = "" Then
                sError = "State and form name required"
                Return False
            End If
            sSQL = "SELECT FormId, AddDate, AddUser FROM StateForms WHERE FormName = " & QuoStr(sFormName) & _
                " AND StateCd = " & QuoStr(sStateCd) & " AND TaxYear = " & iTaxYear
            If GetData(sSQL, dt) > 0 Then
                Dim dr As DataRow = dt.Rows(0)
                lId = dr("FormId")
                If MsgBox("Form already exists, added " & dr("AddDate") & " by " & dr("AddUser") & _
                          ".  Do you wish to overwrite?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    sError = ""
                    Return False
                End If
            End If

        Catch ex As Exception
            sError = ex.Message
            Return False
        End Try

        Dim openFileDialog1 As New OpenFileDialog()

        'openFileDialog1.InitialDirectory = "d:\"
        openFileDialog1.Filter = "Adobe PDF files (*.pdf)|*.pdf"
        openFileDialog1.RestoreDirectory = True
        openFileDialog1.Multiselect = False

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                Dim sFile As String = openFileDialog1.FileName
                If lId = 0 Then lId = CreateID(enumTable.enumStateForms)
                ExecuteSQL("begin transaction")
                If StoreStateFormBLOB(lId, sFile, iTaxYear, sStateCd, sFormName, sFormDescription, AppData.UserId) Then
                    If CreateFormXRef(lId, sFile, 0, iTaxYear, sError) Then
                        ExecuteSQL("commit transaction")
                        Return True
                    Else
                        ExecuteSQL("rollback transaction")
                    End If
                End If
            Catch ex As Exception
                sError = ex.Message
                ExecuteSQL("rollback transaction")
                Return False
            End Try
        End If

    End Function

    Public Function ImportClientForm(ByVal lClientId As Long, ByVal iTaxYear As Integer, ByVal sStateCd As String, _
            ByVal sFormName As String, _
            ByVal sFormDescription As String, ByRef sError As String) As Boolean
        Dim sSQL As String, dt As DataTable, lId As Long = 0

        Try
            sStateCd = UCase(Trim(sStateCd))
            sFormName = UCase(Trim(sFormName))
            sFormDescription = Trim(sFormDescription)
            If lClientId = 0 Or sStateCd = "" Or sFormName = "" Then
                sError = "Client, state and form name required"
                Return False
            End If
            sSQL = "SELECT FormId, AddDate, AddUser FROM ClientForms WHERE FormName = " & QuoStr(sFormName) & _
                "AND ClientId = " & lClientId & " AND StateCd = " & QuoStr(sStateCd) & " AND TaxYear = " & iTaxYear
            If GetData(sSQL, dt) > 0 Then
                Dim dr As DataRow = dt.Rows(0)
                lId = dr("FormId")
                If MsgBox("Form already exists, added " & dr("AddDate") & " by " & dr("AddUser") & _
                          ".  Do you wish to overwrite?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    sError = ""
                    Return False
                End If
            End If

        Catch ex As Exception
            sError = ex.Message
            Return False
        End Try

        Dim openFileDialog1 As New OpenFileDialog()

        'openFileDialog1.InitialDirectory = "d:\"
        openFileDialog1.Filter = "Adobe PDF files (*.pdf)|*.pdf"
        openFileDialog1.RestoreDirectory = True
        openFileDialog1.Multiselect = False

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                Dim sFile As String = openFileDialog1.FileName
                If lId = 0 Then lId = CreateID(enumTable.enumClientForms)
                ExecuteSQL("begin transaction")
                If StoreClientFormBLOB(lId, sFile, lClientId, iTaxYear, sStateCd, sFormName, sFormDescription, AppData.UserId) Then
                    If CreateFormXRef(lId, sFile, lClientId, iTaxYear, sError) Then
                        ExecuteSQL("commit transaction")
                        Return True
                    Else
                        ExecuteSQL("rollback transaction")
                    End If
                End If
            Catch ex As Exception
                sError = ex.Message
                ExecuteSQL("rollback transaction")
                Return False
            End Try
        End If

    End Function

    Public Function ImportClientContract(ByVal lClientId As Long, ByRef sError As String) As Boolean
        Dim sSQL As String = "", dt As New DataTable, lId As Long = 0

        Try
            If lClientId = 0 Then
                sError = "Client required"
                Return False
            End If
            sSQL = "SELECT ContractImage FROM Clients WHERE ClientId = " & lClientId
            If GetData(sSQL, dt) > 0 Then
                Dim dr As DataRow = dt.Rows(0)
                If IsDBNull(dr("ContractImage")) Then
                Else
                    If MsgBox("Contract already exists.  Do you wish to overwrite?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        sError = ""
                        Return False
                    End If
                End If
            End If
        Catch ex As Exception
            sError = ex.Message
            Return False
        End Try

        Dim openFileDialog1 As New OpenFileDialog()

        'openFileDialog1.InitialDirectory = "d:\"
        openFileDialog1.Filter = "Adobe PDF files (*.pdf)|*.pdf"
        openFileDialog1.RestoreDirectory = True
        openFileDialog1.Multiselect = False

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                Dim sFile As String = openFileDialog1.FileName
                ExecuteSQL("begin transaction")
                If StoreClientContractBLOB(lClientId, sFile, AppData.UserId) Then
                    ExecuteSQL("commit transaction")
                    Return True
                Else
                    ExecuteSQL("rollback transaction")
                End If
            Catch ex As Exception
                sError = ex.Message
                ExecuteSQL("rollback transaction")
                Return False
            End Try
        End If

    End Function

    Public Function ImportClientProposal(ByVal lClientId As Long, ByRef sError As String) As Boolean
        Dim sSQL As String = "", dt As New DataTable, lId As Long = 0

        Try
            If lClientId = 0 Then
                sError = "Client required"
                Return False
            End If
            sSQL = "SELECT ProposalImage FROM Clients WHERE ClientId = " & lClientId
            If GetData(sSQL, dt) > 0 Then
                Dim dr As DataRow = dt.Rows(0)
                If IsDBNull(dr("ProposalImage")) Then
                Else
                    If MsgBox("Proposal already exists.  Do you wish to overwrite?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        sError = ""
                        Return False
                    End If
                End If
            End If
        Catch ex As Exception
            sError = ex.Message
            Return False
        End Try

        Dim openFileDialog1 As New OpenFileDialog()

        'openFileDialog1.InitialDirectory = "d:\"
        openFileDialog1.Filter = "Adobe PDF files (*.pdf)|*.pdf"
        openFileDialog1.RestoreDirectory = True
        openFileDialog1.Multiselect = False

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                Dim sFile As String = openFileDialog1.FileName
                ExecuteSQL("begin transaction")
                If StoreClientProposalBLOB(lClientId, sFile, AppData.UserId) Then
                    ExecuteSQL("commit transaction")
                    Return True
                Else
                    ExecuteSQL("rollback transaction")
                End If
            Catch ex As Exception
                sError = ex.Message
                ExecuteSQL("rollback transaction")
                Return False
            End Try
        End If

    End Function

    Private Function CreateFormXRef(ByVal lFormId As Long, ByVal sFile As String, ByVal lClientId As Long, _
            ByVal iTaxYear As Integer, ByRef sError As String) As Boolean
        Dim sSQL As String = ""
        Dim reader As PdfReader
        Dim tofields As AcroFields
        Dim field As DictionaryEntry
        Dim sName As String = ""
        Try
            reader = New PdfReader(sFile)
            tofields = reader.AcroFields
            For Each field In reader.AcroFields.Fields
                sName = field.Key.ToString
                If lClientId = 0 Then
                    sSQL = "INSERT StateFormsXRef (FormId,PDFFieldName,TaxYear,AddUser)" & _
                        " SELECT " & lFormId & "," & QuoStr(sName) & "," & iTaxYear & "," & QuoStr(AppData.UserId) & _
                        " WHERE NOT EXISTS (SELECT FormId FROM StateFormsXRef WHERE FormId = " & lFormId & " AND PDFFieldName = " & QuoStr(sName) & _
                        " AND TaxYear = " & iTaxYear & ")"
                Else
                    sSQL = "INSERT ClientFormsXRef (FormId,PDFFieldName,TaxYear,AddUser) VALUES" & _
                        " (" & lFormId & "," & QuoStr(sName) & "," & iTaxYear & "," & QuoStr(AppData.UserId) & ")"
                End If
                ExecuteSQL(sSQL)
            Next
            reader.Close()
            Return True
        Catch ex As Exception
            sError = "Error creating form cross reference:  " & ex.Message & ".  SQL = " & sSQL
            Return False
        End Try
    End Function

    Private Function CreateFormXRef(ByVal lFormId As Long, ByVal sFile As String, ByVal iTaxYear As Integer, ByRef sError As String) As Boolean
        Return CreateFormXRef(lFormId, sFile, 0, iTaxYear, sError)
    End Function

    Public Function AddClientGLCode(ByVal lClientId As Long, ByVal sStateCd As String, ByVal sGLCode As String, ByRef sError As String) As Boolean
        Dim sSQL As String

        Try
            sGLCode = UCase(Trim(sGLCode))
            sStateCd = UCase(Trim(sStateCd))
            If sGLCode = "" Or lClientId = 0 Or sStateCd = "" Then
                sError = "Missing data"
                Return False
            End If

            sSQL = "insert ClientGLCodes (ClientId,StateCd,GLCode,TaxYear,AddUser)" & _
                " select " & lClientId & "," & QuoStr(sStateCd) & "," & QuoStr(sGLCode) & "," & _
                AppData.TaxYear & "," & QuoStr(AppData.UserId)
            If ExecuteSQL(sSQL) = 1 Then Return True
        Catch ex As Exception
            sError = ex.Message
            Return False
        End Try
    End Function
    Public Function AddLocation(ByVal lClientId As Long, ByVal iTaxYear As Integer, ByVal lAssessorId As Long, _
            ByVal ePropType As enumTable, _
            ByVal eType As enumTable) As Boolean
        Dim sAcctNum As String = ""
        If eType = enumTable.enumProspectLocation Then
            sAcctNum = UCase(Trim(InputBox("Enter account number")))
            If sAcctNum = "" Then Return False
        End If

        Dim sAddress As String = Trim(InputBox("Enter address"))
        If sAddress = "" Then Return False
        Dim sCity As String = Trim(InputBox("Enter city"))
        If sCity = "" Then Return False
        Dim sStateCd As String = UCase(Trim(InputBox("Enter state code")))
        If sStateCd = "" Then Return False

        Dim sError As String = "", bReturn As Boolean
        If eType = enumTable.enumLocationBPP Then
            Dim cLocation As New clsLocationBPP
            cLocation.ClientId = lClientId
            cLocation.Address = sAddress
            cLocation.City = sCity
            cLocation.StateCd = sStateCd
            cLocation.TaxYear = iTaxYear
            bReturn = cLocation.CreateLocation(True, 0, sError)
        ElseIf eType = enumTable.enumLocationRE Then
            Dim cLocation As New clsLocationRE
            cLocation.ClientId = lClientId
            cLocation.Address = sAddress
            cLocation.City = sCity
            cLocation.TaxYear = iTaxYear
            cLocation.StateCd = sStateCd
            bReturn = cLocation.CreateLocation(True, 0, sError)
        ElseIf eType = enumTable.enumProspectLocation Then
            bReturn = AddProspectLocation(lClientId, lAssessorId, sAcctNum, ePropType, sAddress, sCity, sStateCd, sError)
        End If
        If Not bReturn Then
            MsgBox("Error creating location:  " & sError)
        Else
            MsgBox("Location created")
        End If
        Return bReturn
    End Function
    Public Function AddAssessment(ByVal lClientId As Long, ByVal lLocationId As Long, ByVal iTaxYear As Integer, ByVal eType As enumTable) As Boolean
        Dim sAcctNum As String = UCase(Trim(InputBox("Enter account number")))
        If sAcctNum = "" Then Return False
        Dim sError As String = "", bReturn As Boolean
        If eType = enumTable.enumAssessmentBPP Then
            Dim cAssessment As New clsAssessmentBPP
            cAssessment.ClientId = lClientId
            cAssessment.LocationId = lLocationId
            cAssessment.TaxYear = iTaxYear
            cAssessment.AcctNum = sAcctNum
            bReturn = cAssessment.CreateAssessment(True, 0, 0, sError)
        Else
            Dim cAssessment As New clsAssessmentRE
            cAssessment.ClientId = lClientId
            cAssessment.LocationId = lLocationId
            cAssessment.TaxYear = iTaxYear
            cAssessment.AcctNum = sAcctNum
            bReturn = cAssessment.CreateAssessment(True, 0, 0, sError)
        End If
        If Not bReturn Then
            MsgBox("Error creating assessment:  " & sError)
        Else
            MsgBox("Assessment created")
        End If
        Return bReturn
    End Function

    Public Function OpenBPPAssessment(ByVal lClientId As Long, ByVal lLocationId As Long, ByVal lAssessmentId As Long, ByVal iTaxYear As Integer, ByRef sMsg As String) As Boolean
        If lClientId = 0 Or lLocationId = 0 Or lAssessmentId = 0 Or iTaxYear = 0 Then
            If lAssessmentId = 0 Then
                sMsg = "Assessment does not exist"
            Else
                sMsg = "Missing information"
            End If
            Return False
        End If

        Dim frm As Form, frml As frmBPPAssessment

        For Each frm In MDIParent1.MdiChildren
            If frm.Name = "frmBPPAssessment" Then
                frml = frm
                If frml.ClientId = lClientId And frml.LocationId = lLocationId And frml.AssessmentId = lAssessmentId And frml.TaxYear = iTaxYear Then
                    frml.ClientId = lClientId
                    frml.LocationId = lLocationId
                    frml.AssessmentId = lAssessmentId
                    frml.TaxYear = iTaxYear
                    frml.Focus()
                    Return True
                End If
            End If
        Next
        frml = New frmBPPAssessment
        frml.ClientId = lClientId
        frml.LocationId = lLocationId
        frml.AssessmentId = lAssessmentId
        frml.TaxYear = iTaxYear
        frml.MdiParent = MDIParent1
        frml.Show()
        Return True
    End Function
    Public Function OpenBPPTaxList(ByVal lClientId As Long, ByVal lLocationId As Long, ByVal lAssessmentId As Long, _
            ByVal lAssessorId As Long, ByVal iTaxYear As Integer, ByRef sMsg As String) As Boolean
        Try
            If lClientId = 0 Or lLocationId = 0 Or lAssessmentId = 0 Or iTaxYear = 0 Or iTaxYear <> AppData.TaxYear Then
                If lAssessmentId = 0 Then
                    sMsg = "Assessment does not exist"
                ElseIf iTaxYear <> AppData.TaxYear Then
                    sMsg = "Must change the tax year to " & iTaxYear & " to open account"
                Else
                    sMsg = "Missing information"
                End If
                Return False
            End If
            Dim frmT As frmBPPTaxList, bFound As Boolean = False
            For Each frm As Form In MDIParent1.MdiChildren
                If frm.Name = "frmBPPTaxList" Then
                    frmT = frm
                    If frmT.ClientId = lClientId And frmT.LocationId = lLocationId And frmT.AssessmentId = lAssessmentId And _
                            frmT.TaxYear = iTaxYear Then
                        frm.Focus()
                        Return True
                    End If
                End If
            Next
            frmT = New frmBPPTaxList
            frmT.ClientId = lClientId
            frmT.LocationId = lLocationId
            frmT.AssessmentId = lAssessmentId
            frmT.AssessorId = lAssessorId
            frmT.TaxYear = iTaxYear
            frmT.MdiParent = MDIParent1
            frmT.Show()
            Return True
        Catch ex As Exception
            sMsg = ex.Message
            Return False
        End Try
    End Function

    Public Function OpenREAssessment(ByVal lClientId As Long, ByVal lLocationId As Long, ByVal lAssessmentId As Long, ByVal iTaxYear As Integer, ByRef sMsg As String) As Boolean
        If lClientId = 0 Or lLocationId = 0 Or lAssessmentId = 0 Or iTaxYear = 0 Or iTaxYear <> AppData.TaxYear Then
            If lAssessmentId = 0 Then
                sMsg = "Assessment does not exist"
            ElseIf iTaxYear <> AppData.TaxYear Then
                sMsg = "Must change the tax year to " & iTaxYear & " to open account"
            Else
                sMsg = "Missing information"
            End If
            Return False
        End If
        Dim frm As Form, frml As frmREAssessment

        For Each frm In MDIParent1.MdiChildren
            If frm.Name = "frmREAssessment" Then
                frml = frm
                If frml.ClientId = lClientId And frml.LocationId = lLocationId And frml.AssessmentId = lAssessmentId And frml.TaxYear = iTaxYear Then
                    frml.ClientId = lClientId
                    frml.LocationId = lLocationId
                    frml.AssessmentId = lAssessmentId
                    frml.TaxYear = iTaxYear
                    frml.Focus()
                    Return True
                End If
            End If
        Next
        frml = New frmREAssessment
        frml.ClientId = lClientId
        frml.LocationId = lLocationId
        frml.AssessmentId = lAssessmentId
        frml.TaxYear = iTaxYear
        frml.MdiParent = MDIParent1
        frml.Show()
        Return True
    End Function


    Public Function AddFactoringEntity(ByVal sName As String, ByVal sStateCd As String, ByVal bHitDB As Boolean, ByRef sError As String) As Boolean
        Dim sSQL As String, dt As DataTable, dr As DataRow

        Try
            sName = Trim(sName)
            sStateCd = UCase(Trim(sStateCd))

            If sName = "" Or sStateCd = "" Then
                sError = "Missing data"
                Return False
            End If



            If bHitDB = False Then
                sSQL = "select AddDate, AddUser from FactorEntities" & _
                    " where StateCd = " & QuoStr(sStateCd) & _
                    " and Name = " & QuoStr(sName)
                If GetData(sSQL, dt) > 0 Then
                    dr = dt.Rows(0)
                    sError = "Factoring entity already exists.  Created by " & UnNullToString(dr("AddUser")) & " on " & dr("AddDate")
                    Return False
                Else
                    Return True
                End If
            Else
                sSQL = "insert FactorEntities (FactorEntityId,StateCd,Name,AddUser)" & _
                    " select " & CreateID(enumTable.enumFactorEntity) & "," & QuoStr(sStateCd) & "," & QuoStr(sName) & "," & QuoStr(AppData.UserId)
                If ExecuteSQL(sSQL) = 1 Then Return True
            End If
        Catch ex As Exception
            sError = ex.Message
            Return False
        End Try


    End Function

    Public Function AddStateFactorCode(ByVal sStateCd As String, ByVal sStateFactorCode As String, _
            ByVal sName As String, ByVal sDescription As String, ByRef sError As String) As Boolean
        Dim sSQL As String

        Try
            sStateFactorCode = UCase(Trim(sStateFactorCode))
            sStateCd = UCase(Trim(sStateCd))
            sName = Trim(sName)
            sDescription = Trim(sDescription)
            If sStateCd = "" Or sStateFactorCode = "" Then
                sError = "Missing data"
                Return False
            End If
            If sName = "" Then sName = sStateFactorCode

            sSQL = "insert StateFactorCodes (StateCd,StateFactorCode,TaxYear,Name,Description,AddUser)" & _
                " select " & QuoStr(sStateCd) & "," & QuoStr(sStateFactorCode) & "," & AppData.TaxYear & _
                "," & QuoStr(sName) & "," & QuoStr(sDescription) & "," & QuoStr(AppData.UserId) & _
                " where not exists (select StateCd from StateFactorCodes" & _
                " where StateCd = " & QuoStr(sStateCd) & " and StateFactorCode = " & QuoStr(sStateFactorCode) & _
                " and TaxYear = " & AppData.TaxYear & ")"
            ExecuteSQL(sSQL)
            Return True
        Catch ex As Exception
            sError = ex.Message
            Return False
        End Try


    End Function

    Public Function AddFactorCode(ByVal lFactorEntityId As Long, ByVal sCode As String, _
            ByVal sDescription As String, ByRef sError As String) As Boolean
        Dim sSQL As String

        Try
            sCode = UCase(Trim(sCode))
            sDescription = Trim(sDescription)

            If lFactorEntityId = 0 Or sCode = "" Or sDescription = "" Then
                sError = "Missing data"
                Return False
            End If

            sSQL = "insert FactorEntityCodes (FactorEntityId,FactorCode,Description,TaxYear,AddUser)" & _
                " select " & lFactorEntityId & "," & QuoStr(sCode) & "," & QuoStr(sDescription) & "," & _
                AppData.TaxYear & "," & QuoStr(AppData.UserId) & _
                " where not exists(select FactorEntityId from FactorEntityCodes" & _
                " where FactorEntityId = " & lFactorEntityId & " and FactorCode = " & QuoStr(sCode) & " AND TaxYear = " & AppData.TaxYear & ")"

            ExecuteSQL(sSQL)
            Return True

        Catch ex As Exception
            sError = ex.Message
            Return False
        End Try


    End Function

    Public Function AddAssessmentJurisdiction(ByVal lClientId As Long, ByVal lLocationId As Long, _
        ByVal lAssessmentId As Long, ByVal lJurisdictionId As Long, _
        ByVal eType As enumTable, ByVal iTaxYear As Integer, ByRef sError As String) As Boolean

        Dim sSQL As String = "", dt As New DataTable
        Dim sInsertSQL As String = "INSERT AssessmentDetail" & IIf(eType = enumTable.enumLocationBPP, "BPP", "RE") & _
                " (ClientId,LocationId,AssessmentId,JurisdictionId,AddUser,TaxYear)" & _
                " SELECT " & lClientId & "," & lLocationId & "," & lAssessmentId & "," & lJurisdictionId & _
                "," & QuoStr(AppData.UserId)
        Try
            'get list of taxyears beginning with current year.
            'will add detail for this jurisdiction for this year an all subsequent years
            'in case user adds detail for year when roll occurred in subsequent year
            'will add detail for those years that have been rolled
            sSQL = "SELECT DISTINCT TaxYear FROM Assessments" & IIf(eType = enumTable.enumLocationBPP, "BPP", "RE") & _
                " WHERE ClientId = " & lClientId & " AND LocationId = " & lLocationId & _
                " AND AssessmentId = " & lAssessmentId & " AND TaxYear >= " & iTaxYear
            GetData(sSQL, dt)
            If dt.Rows.Count = 0 Then
                'no assessments at all for this year or subsequent years.  Just add detail for this year
                sSQL = sInsertSQL & "," & iTaxYear
                ExecuteSQL(sSQL)
            Else
                'add detail for this year and all subsequent years
                For Each dr As DataRow In dt.Rows
                    sSQL = sInsertSQL & "," & dr(0).ToString & _
                        " WHERE NOT EXISTS (SELECT * FROM AssessmentDetail" & IIf(eType = enumTable.enumLocationBPP, "BPP", "RE") & _
                        " WHERE ClientId = " & lClientId & " AND LocationId = " & lLocationId & _
                        " AND AssessmentId = " & lAssessmentId & " AND JurisdictionId = " & lJurisdictionId & " AND TaxYear = " & dr(0).ToString & ")"
                    ExecuteSQL(sSQL)
                Next
            End If

            Return True
        Catch ex As Exception
            sError = ex.Message
            Return False
        End Try
    End Function
    Public Function AddFactorAge(ByVal lFactorEntityId As Long, ByVal sFactorCode As String, ByVal iAge As Integer, _
            ByVal dPercentage As Double, ByRef sError As String) As Boolean
        Dim sSQL As String

        Try
            sFactorCode = Trim(sFactorCode)

            If lFactorEntityId = 0 Or sFactorCode = "" Then
                sError = "Missing data"
                Return False
            End If


            sSQL = "insert Factors (FactorEntityId,FactorCode,Age,TaxYear,Percentage,AddUser)" & _
                " select " & lFactorEntityId & "," & QuoStr(sFactorCode) & "," & iAge & "," & _
                AppData.TaxYear & "," & dPercentage & "," & QuoStr(AppData.UserId) & _
                " where not exists(select FactorEntityId from Factors where FactorEntityId = " & lFactorEntityId & _
                " and FactorCode = " & QuoStr(sFactorCode) & " and Age = " & iAge & " AND TaxYear = " & AppData.TaxYear & ")"
            If ExecuteSQL(sSQL) = 1 Then Return True

        Catch ex As Exception
            sError = ex.Message
            Return False
        End Try


    End Function

    Public Function RollData(ByVal iFromYear As Integer, ByVal iToYear As Integer, ByVal lClientId As Long, _
            ByVal lLocationId As Long, ByVal lAssessmentId As Long) As Boolean
        Dim sSQL As String, lRows As Long, dt As New DataTable

        Try
            sSQL = "SELECT 1 WHERE EXISTS (SELECT AssessorId FROM Assessors WHERE TaxYear = " & iToYear & ")"
            If GetData(sSQL, dt) > 0 Then
                If Not IsDBNull(dt.Rows(0)(0)) Then
                    If dt.Rows(0)(0).ToString = "1" Then
                        MsgBox("Data exists in " & iToYear)
                        Return False
                    End If
                End If
            End If

            sSQL = "INSERT Assessors (AssessorId,TaxYear,StateCd,Name,Address1,Address2,City,Zip,Phone,Fax,WebSite," &
                " Comment,BPPRatio,RERatio,AddUser,RenditionDueDate,LienDate," &
                " BPPNoticeDate, RENoticeDate, BPPProtestDeadlineDate, REProtestDeadlineDate, REImportTypeCd)" &
                " SELECT" &
                " t1.AssessorId," & iToYear & ",t1.StateCd,t1.Name,t1.Address1,t1.Address2,t1.City,t1.Zip,t1.Phone,t1.Fax,t1.WebSite," &
                " t1.Comment,t1.BPPRatio,t1.RERatio," & QuoStr(AppData.UserId) & "," &
                " DATEADD(year,1,t1.RenditionDueDate),DATEADD(year,1,t1.LienDate)," &
                " DATEADD(year,1,t1.BPPNoticeDate)" & ",DATEADD(year,1,t1.RENoticeDate)," &
                " DATEADD(year,1,t1.BPPProtestDeadlineDate)" & ",DATEADD(year,1,t1.REProtestDeadlineDate), t1.REImportTypeCd" &
                " FROM Assessors t1 WHERE t1.TaxYear = " & iFromYear &
                " AND NOT EXISTS(SELECT t2.AssessorId FROM Assessors t2" &
                " WHERE t2.AssessorId = t1.AssessorId AND t2.TaxYear = " & iToYear & ")"
            lRows = ExecuteSQL(sSQL)

            sSQL = "INSERT Collectors (CollectorId,TaxYear,Name,StateCd,PayeeStateCd,Payee,Address1,Address2,City,Zip,Phone,Fax,WebSite," &
                " BPPDueDate1,BPPDueDate2,REDueDate1,ReDueDate2,Comment,DiscountDate,NumDaysWarning,AddUser,DiscountFl," &
                " DiscountDate2,DiscountDate3,DiscountDate4," &
                " DiscountPct,DiscountPct2,DiscountPct3,DiscountPct4) SELECT" &
                " t1.CollectorId," & iToYear & ",t1.Name,t1.StateCd,t1.PayeeStateCd,t1.Payee,t1.Address1,t1.Address2,t1.City,t1.Zip,t1.Phone,t1.Fax,t1.WebSite," &
                " DATEADD(year,1,t1.BPPDueDate1),DATEADD(year,1,t1.BPPDueDate2),DATEADD(year,1,t1.REDueDate1),DATEADD(year,1,t1.REDueDate2)," &
                " t1.Comment,DATEADD(year,1,t1.DiscountDate),t1.NumDaysWarning," & QuoStr(AppData.UserId) & "," &
                " t1.DiscountFl," &
                " DATEADD(year,1,t1.DiscountDate2), DATEADD(year,1,t1.DiscountDate3),DATEADD(year,1,t1.DiscountDate4)," &
                " t1.DiscountPct,t1.DiscountPct2,t1.DiscountPct3,t1.DiscountPct4" &
                " FROM Collectors t1 WHERE t1.TaxYear = " & iFromYear &
                " AND NOT EXISTS(SELECT t2.CollectorId FROM Collectors t2" &
                " WHERE t2.CollectorId = t1.CollectorId AND t2.TaxYear = " & iToYear & ")"
            lRows = ExecuteSQL(sSQL)

            sSQL = "INSERT Jurisdictions (JurisdictionId,TaxYear,CollectorId,StateCd,Name,Address1,Address2,City,Zip,Phone,Fax,WebSite," &
                " Comment,TaxRate,FreeportFl,AddUser,TaxDistrictCd) SELECT" &
                " t1.JurisdictionId," & iToYear & ",t1.CollectorId,t1.StateCd,t1.Name,t1.Address1,t1.Address2,t1.City,t1.Zip,t1.Phone,t1.Fax,t1.WebSite," &
                " t1.Comment,t1.TaxRate,t1.FreeportFl," & QuoStr(AppData.UserId) & ",t1.TaxDistrictCd" &
                " FROM Jurisdictions t1 WHERE t1.TaxYear = " & iFromYear &
                " AND NOT EXISTS(SELECT t2.JurisdictionId FROM Jurisdictions t2" &
                " WHERE t2.JurisdictionId = t1.JurisdictionId AND t2.TaxYear = " & iToYear & ")"
            lRows = ExecuteSQL(sSQL)

            'sSQL = "INSERT StateFactorCodes (StateCd,StateFactorCode,TaxYear,Name,Description,AddUser)" & _
            '    " SELECT t1.StateCd,t1.StateFactorCode," & iToYear & "," & _
            '    " t1.Name, t1.Description," & _
            '    QuoStr(AppData.UserId) & _
            '    " FROM StateFactorCodes t1 WHERE t1.TaxYear = " & iFromYear & _
            '    " AND NOT EXISTS(SELECT t2.StateCd FROM StateFactorCodes t2" & _
            '    " WHERE t2.StateCd = t1.StateCd AND t2.StateFactorCode = t1.StateFactorCode" & _
            '    " AND t2.TaxYear = " & iToYear & ")"
            'lRows = ExecuteSQL(sSQL)

            sSQL = "INSERT LocationsBPP (ClientId,LocationId,TaxYear,Address,Name,City,StateCd,Zip," &
                " LegalDescription,LegalOwner,ClientLocationId,Comment,InactiveFl,ConsultantName,AddUser,SICCode)" &
                " SELECT t1.ClientId,t1.LocationId," & iToYear & "," &
                " t1.Address,t1.Name,t1.City,t1.StateCd,t1.Zip,t1.LegalDescription,t1.LegalOwner," &
                " t1.ClientLocationId,t1.Comment,t1.InactiveFl,t1.ConsultantName," &
                QuoStr(AppData.UserId) & ",t1.SICCode" &
                " FROM LocationsBPP t1 WHERE t1.TaxYear = " & iFromYear &
                " AND NOT EXISTS(SELECT t2.ClientId FROM LocationsBPP t2" &
                " WHERE t2.ClientId = t1.ClientId AND t2.LocationId = t1.LocationId" &
                " AND t2.TaxYear = " & iToYear & ")"
            If lClientId > 0 Then sSQL = sSQL & " AND t1.ClientId = " & lClientId
            If lLocationId > 0 Then sSQL = sSQL & " AND t1.LocationId = " & lLocationId
            lRows = ExecuteSQL(sSQL)

            sSQL = "INSERT LocationsRE (ClientId,LocationId,TaxYear,Address,Name,City,StateCd,Zip," &
                " LegalDescription,LegalOwner,ClientLocationId,Comment,InactiveFl,ConsultantName,AddUser,SICCode)" &
                " SELECT t1.ClientId,t1.LocationId," & iToYear & "," &
                " t1.Address,t1.Name,t1.City,t1.StateCd,t1.Zip,t1.LegalDescription,t1.LegalOwner," &
                " t1.ClientLocationId,t1.Comment,t1.InactiveFl,t1.ConsultantName," &
                QuoStr(AppData.UserId) & ",t1.SICCode" &
                " FROM LocationsRE t1 WHERE t1.TaxYear = " & iFromYear &
                " AND NOT EXISTS(SELECT t2.ClientId FROM LocationsRE t2" &
                " WHERE t2.ClientId = t1.ClientId AND t2.LocationId = t1.LocationId" &
                " AND t2.TaxYear = " & iToYear & ")"
            If lClientId > 0 Then sSQL = sSQL & " AND t1.ClientId = " & lClientId
            If lLocationId > 0 Then sSQL = sSQL & " AND t1.LocationId = " & lLocationId
            lRows = ExecuteSQL(sSQL)

            sSQL = "INSERT AssessmentsBPP (ClientId,LocationId,AssessmentId,TaxYear,AssessorId,AcctNum,Comment," &
                " FactorEntityId1,FactorEntityId2,FactorEntityId3,FactorEntityId4,FactorEntityId5,InactiveFl,AddUser,SavingsExclusionCd," &
                " ParentAssessmentId,BusinessUnitId,InterstateAllocationFl,AgencyId)" &
                " SELECT t1.ClientId,t1.LocationId,t1.AssessmentId," & iToYear & "," &
                " t1.AssessorId,t1.AcctNum,t1.Comment," &
                " t1.FactorEntityId1,t1.FactorEntityId2,t1.FactorEntityId3,t1.FactorEntityId4,t1.FactorEntityId5,t1.InactiveFl," &
                QuoStr(AppData.UserId) & ",t1.SavingsExclusionCd,t1.ParentAssessmentId,t1.BusinessUnitId,t1.InterstateAllocationFl,t1.AgencyId" &
                " FROM AssessmentsBPP t1 WHERE t1.TaxYear = " & iFromYear &
                " AND NOT EXISTS(SELECT t2.ClientId FROM AssessmentsBPP t2" &
                " WHERE t2.ClientId = t1.ClientId AND t2.LocationId = t1.LocationId" &
                " AND t2.AssessmentId = t1.AssessmentId AND t2.TaxYear = " & iToYear & ")"
            If lClientId > 0 Then sSQL = sSQL & " AND t1.ClientId = " & lClientId
            If lLocationId > 0 Then sSQL = sSQL & " AND t1.LocationId = " & lLocationId
            If lAssessmentId > 0 Then sSQL = sSQL & " AND t1.AssessmentId = " & lAssessmentId
            lRows = ExecuteSQL(sSQL)

            sSQL = "INSERT AssessmentsBPPComments (ClientId,LocationId,AssessmentId,TaxYear,CommentType,Comment,AddUser,AddDate,ChangeDate,ChangeUser,ChangeType)" &
                " SELECT t1.ClientId,t1.LocationId,t1.AssessmentId," & iToYear & "," &
                " t1.CommentType,t1.Comment,t1.AddUser,t1.AddDate,t1.ChangeDate,t1.ChangeUser,t1.ChangeType" &
                " FROM AssessmentsBPPComments t1 WHERE t1.TaxYear = " & iFromYear
            If lClientId > 0 Then sSQL = sSQL & " AND t1.ClientId = " & lClientId
            If lLocationId > 0 Then sSQL = sSQL & " AND t1.LocationId = " & lLocationId
            If lAssessmentId > 0 Then sSQL = sSQL & " AND t1.AssessmentId = " & lAssessmentId
            lRows = ExecuteSQL(sSQL)

            sSQL = "INSERT AssessmentDetailBPP (ClientId,LocationId,AssessmentId,JurisdictionId,TaxYear,AddUser)" & _
                " SELECT t1.ClientId,t1.LocationId,t1.AssessmentId,t1.JurisdictionId," & iToYear & "," & QuoStr(AppData.UserId) & _
                " FROM AssessmentDetailBPP t1 WHERE t1.TaxYear = " & iFromYear & _
                " AND NOT EXISTS(SELECT t2.ClientId FROM AssessmentDetailBPP t2" & _
                " WHERE t2.ClientId = t1.ClientId AND t2.LocationId = t1.LocationId" & _
                " AND t2.AssessmentId = t1.AssessmentId AND t2.JurisdictionId = t1.JurisdictionId" & _
                " AND t2.TaxYear = " & iToYear & ")"
            If lClientId > 0 Then sSQL = sSQL & " AND t1.ClientId = " & lClientId
            If lLocationId > 0 Then sSQL = sSQL & " AND t1.LocationId = " & lLocationId
            If lAssessmentId > 0 Then sSQL = sSQL & " AND t1.AssessmentId = " & lAssessmentId
            lRows = ExecuteSQL(sSQL)

            'sSQL = "INSERT Inventory (ClientId,LocationId,TaxYear,AddUser)" & _
            '    " SELECT t1.ClientId,t1.LocationId," & iToYear & "," & QuoStr(AppData.UserId) & _
            '    " FROM Inventory t1 WHERE t1.TaxYear = " & iFromYear & _
            '    " AND NOT EXISTS(SELECT t2.ClientId FROM Inventory t2" & _
            '    " WHERE t2.ClientId = t1.ClientId AND t2.LocationId = t1.LocationId" & _
            '    " AND t2.TaxYear = " & iToYear & ")"
            'If lClientId > 0 Then sSQL = sSQL & " AND t1.ClientId = " & lClientId
            'If lLocationId > 0 Then sSQL = sSQL & " AND t1.LocationId = " & lLocationId
            'lRows = ExecuteSQL(sSQL)

            sSQL = "INSERT AssessmentsRE (ClientId,LocationId,AssessmentId,TaxYear,AssessorId,AcctNum,Comment,InactiveFl," &
                " AddUser,SavingsExclusionCd,OccupiedStatus,ParentAssessmentId,BusinessUnitId," &
                " BuildingType,BuildingClass,BuildingSqFt,NetLeasableSqFt,GrossLeasableSqFt,YearBuilt,EffYearBuilt,LandSqFt,ExcessLandSqFt,ConstructionType,AgencyId" &
                ",MarketReimbRevenuePerSqFt,MarketAddlRevenuePerSqFt,CeilingHeight" &
                ",ValueMethodTarget,MarketCapRate,MarketCommonAreaMaintPct,MarketMgmtFeesPct,MarketNonReimbPct,MarketPropInsPct" &
                ",ValueMethodEquity,MarketRentPerSqFt,MarketTaxRate,MarketVacCollLossPct,LeaseupCommissionPct,LeaseupTotIncCostPerSqFt" &
                ",LeaseupVacantSqFt,ValueMethodIncome,ValueMethodMarket,ValueMethod,ValueMethodCost,LandType" &
                ")" &
                " SELECT t1.ClientId,t1.LocationId,t1.AssessmentId," & iToYear & "," &
                " t1.AssessorId,t1.AcctNum,t1.Comment,t1.InactiveFl," &
                QuoStr(AppData.UserId) & ",t1.SavingsExclusionCd,t1.OccupiedStatus,t1.ParentAssessmentId,t1.BusinessUnitId," &
                " t1.BuildingType,t1.BuildingClass,t1.BuildingSqFt,t1.NetLeasableSqFt,t1.GrossLeasableSqFt,t1.YearBuilt,t1.EffYearBuilt,t1.LandSqFt,t1.ExcessLandSqFt,t1.ConstructionType,t1.AgencyId" &
                ",t1.MarketReimbRevenuePerSqFt,t1.MarketAddlRevenuePerSqFt,t1.CeilingHeight" &
                ",t1.ValueMethodTarget,t1.MarketCapRate,t1.MarketCommonAreaMaintPct,t1.MarketMgmtFeesPct,t1.MarketNonReimbPct,t1.MarketPropInsPct" &
                ",t1.ValueMethodEquity,t1.MarketRentPerSqFt,t1.MarketTaxRate,t1.MarketVacCollLossPct,t1.LeaseupCommissionPct,t1.LeaseupTotIncCostPerSqFt" &
                ",t1.LeaseupVacantSqFt,t1.ValueMethodIncome,t1.ValueMethodMarket,t1.ValueMethod,t1.ValueMethodCost,t1.LandType" &
                " FROM AssessmentsRE t1 WHERE t1.TaxYear = " & iFromYear &
                " AND NOT EXISTS(SELECT t2.ClientId FROM AssessmentsRE t2" &
                " WHERE t2.ClientId = t1.ClientId AND t2.LocationId = t1.LocationId" &
                " AND t2.AssessmentId = t1.AssessmentId AND t2.TaxYear = " & iToYear & ")"
            If lClientId > 0 Then sSQL = sSQL & " AND t1.ClientId = " & lClientId
            If lLocationId > 0 Then sSQL = sSQL & " AND t1.LocationId = " & lLocationId
            If lAssessmentId > 0 Then sSQL = sSQL & " AND t1.AssessmentId = " & lAssessmentId
            lRows = ExecuteSQL(sSQL)

            sSQL = "INSERT AssessmentDetailRE (ClientId,LocationId,AssessmentId,JurisdictionId,TaxYear,AddUser)" & _
                " SELECT t1.ClientId,t1.LocationId,t1.AssessmentId,t1.JurisdictionId," & iToYear & "," & QuoStr(AppData.UserId) & _
                " FROM AssessmentDetailRE t1 WHERE t1.TaxYear = " & iFromYear & _
                " AND NOT EXISTS(SELECT t2.ClientId FROM AssessmentDetailRE t2" & _
                " WHERE t2.ClientId = t1.ClientId AND t2.LocationId = t1.LocationId" & _
                " AND t2.AssessmentId = t1.AssessmentId AND t2.JurisdictionId = t1.JurisdictionId" & _
                " AND t2.TaxYear = " & iToYear & ")"
            If lClientId > 0 Then sSQL = sSQL & " AND t1.ClientId = " & lClientId
            If lLocationId > 0 Then sSQL = sSQL & " AND t1.LocationId = " & lLocationId
            If lAssessmentId > 0 Then sSQL = sSQL & " AND t1.AssessmentId = " & lAssessmentId
            lRows = ExecuteSQL(sSQL)

            sSQL = "INSERT AssessmentsREComments (ClientId,LocationId,AssessmentId,TaxYear,CommentType,Comment,AddUser,AddDate,ChangeDate,ChangeUser,ChangeType)" &
                " SELECT t1.ClientId,t1.LocationId,t1.AssessmentId," & iToYear & "," &
                " t1.CommentType,t1.Comment,t1.AddUser,t1.AddDate,t1.ChangeDate,t1.ChangeUser,t1.ChangeType" &
                " FROM AssessmentsREComments t1 WHERE t1.TaxYear = " & iFromYear
            If lClientId > 0 Then sSQL = sSQL & " AND t1.ClientId = " & lClientId
            If lLocationId > 0 Then sSQL = sSQL & " AND t1.LocationId = " & lLocationId
            If lAssessmentId > 0 Then sSQL = sSQL & " AND t1.AssessmentId = " & lAssessmentId
            lRows = ExecuteSQL(sSQL)

            sSQL = "INSERT Assets (ClientId,LocationId,AssessmentId,AssetId,TaxYear,OriginalCost,PurchaseDate,Description," &
                " GLCode,AddUser,VIN,LocationAddress,AllocationPct,LesseeName,LesseeAddress,LeaseTerm,EquipmentMake,EquipmentModel,LeaseType,AuditFl,ActivityQty," &
                " LesseeCity, LesseeStateCd, LesseeZip)" &
                " SELECT t1.ClientId,t1.LocationId,t1.AssessmentId,t1.AssetId," & iToYear & "," &
                " t1.OriginalCost,t1.PurchaseDate,t1.Description,t1.GLCode," &
                QuoStr(AppData.UserId) & ",t1.VIN, t1.LocationAddress,t1.AllocationPct," &
                " t1.LesseeName,t1.LesseeAddress,t1.LeaseTerm,t1.EquipmentMake,t1.EquipmentModel,t1.LeaseType,t1.AuditFl,t1.ActivityQty," &
                " t1.LesseeCity, t1.LesseeStateCd, t1.LesseeZip" &
                " FROM Assets t1 WHERE t1.TaxYear = " & iFromYear &
                " AND NOT EXISTS(SELECT t2.ClientId FROM Assets t2" &
                " WHERE t2.ClientId = t1.ClientId AND t2.LocationId = t1.LocationId AND t2.AssessmentId = t1.AssessmentId" &
                " AND t2.AssetId = t1.AssetId" &
                " AND t2.TaxYear = " & iToYear & ")"
            If lClientId > 0 Then sSQL = sSQL & " AND t1.ClientId = " & lClientId
            If lLocationId > 0 Then sSQL = sSQL & " AND t1.LocationId = " & lLocationId
            If lAssessmentId > 0 Then sSQL = sSQL & " AND t1.AssessmentId = " & lAssessmentId
            lRows = ExecuteSQL(sSQL)

            sSQL = "INSERT ClientGLCodes (ClientId,StateCd,GLCode,TaxYear,AddUser)" & _
                " SELECT t1.ClientId,t1.StateCd,t1.GLCode," & iToYear & "," & QuoStr(AppData.UserId) & _
                " FROM ClientGLCodes t1 WHERE t1.TaxYear = " & iFromYear & _
                " AND NOT EXISTS(SELECT t2.ClientId FROM ClientGLCodes t2" & _
                " WHERE t2.ClientId = t1.ClientId AND t2.StateCd = t1.StateCd AND t2.GLCode = t1.GLCode" & _
                " AND t2.TaxYear = " & iToYear & ")"
            If lClientId > 0 Then sSQL = sSQL & " AND t1.ClientId = " & lClientId
            lRows = ExecuteSQL(sSQL)

            'sSQL = "INSERT StateClientGLCodeXRef (ClientId,StateCd,ClientGLCode,TaxYear,StateFactorCode,AddUser)" & _
            '    " SELECT t1.ClientId,t1.StateCd,t1.ClientGLCode," & iToYear & ",t1.StateFactorCode," & QuoStr(AppData.UserId) & _
            '    " FROM StateClientGLCodeXRef t1 WHERE t1.TaxYear = " & iFromYear & _
            '    " AND NOT EXISTS(SELECT t2.ClientId FROM StateClientGLCodeXRef t2" & _
            '    " WHERE t2.ClientId = t1.ClientId AND t2.StateCd = t1.StateCd AND t2.ClientGLCode = t1.ClientGLCode" & _
            '    " AND t2.TaxYear = " & iToYear & ")"
            'If lClientId > 0 Then sSQL = sSQL & " AND t1.ClientId = " & lClientId
            'lRows = ExecuteSQL(sSQL)

            sSQL = "INSERT FactorEntityCodes (FactorEntityId,FactorCode,TaxYear,Description,AddUser,InactiveFl)" &
                " SELECT t1.FactorEntityId,t1.FactorCode," & iToYear & ",t1.Description," & QuoStr(AppData.UserId) & ",t1.InactiveFl" &
                " FROM FactorEntityCodes t1 WHERE t1.TaxYear = " & iFromYear &
                " AND NOT EXISTS(SELECT t2.FactorEntityId FROM FactorEntityCodes t2" &
                " WHERE t2.FactorEntityId = t1.FactorEntityId AND t2.FactorCode = t1.FactorCode" &
                " AND t2.TaxYear = " & iToYear & ")"
            lRows = ExecuteSQL(sSQL)

            sSQL = "INSERT StateForms (FormId,TaxYear,StateCd,FormName,FormData,FormDescription,AddUser)" & _
                " SELECT t1.FormId," & iToYear & ",t1.StateCd," & _
                " t1.FormName,t1.FormData,t1.FormDescription," & _
                QuoStr(AppData.UserId) & _
                " FROM StateForms t1 WHERE t1.TaxYear = " & iFromYear & _
                " AND NOT EXISTS(SELECT t2.FormId FROM StateForms t2" & _
                " WHERE t2.FormId = t1.FormId" & _
                " AND t2.TaxYear = " & iToYear & ")"
            lRows = ExecuteSQL(sSQL)

            sSQL = "INSERT ClientForms (FormId,TaxYear,ClientId,StateCd,FormName,FormData,FormDescription,AddUser)" & _
                " SELECT t1.FormId," & iToYear & ",t1.ClientId,t1.StateCd," & _
                " t1.FormName,t1.FormData,t1.FormDescription," & _
                QuoStr(AppData.UserId) & _
                " FROM ClientForms t1 WHERE t1.TaxYear = " & iFromYear & _
                " AND NOT EXISTS(SELECT t2.FormId FROM ClientForms t2" & _
                " WHERE t2.FormId = t1.FormId" & _
                " AND t2.TaxYear = " & iToYear & ")"
            lRows = ExecuteSQL(sSQL)

            sSQL = "INSERT StateFormsXRef (FormId,PDFFieldName,TaxYear,TableName,FieldName,AddUser)" & _
                " SELECT t1.FormId,t1.PDFFieldName," & iToYear & ",t1.TableName," & _
                " t1.FieldName," & _
                QuoStr(AppData.UserId) & _
                " FROM StateFormsXRef t1 WHERE t1.TaxYear = " & iFromYear & _
                " AND NOT EXISTS(SELECT t2.FormId FROM StateFormsXRef t2" & _
                " WHERE t2.FormId = t1.FormId AND t2.PDFFieldName = t1.PDFFieldName" & _
                " AND t2.TaxYear = " & iToYear & ")"
            lRows = ExecuteSQL(sSQL)

            sSQL = "INSERT ClientFormsXRef (FormId,PDFFieldName,TaxYear,TableName,FieldName,AddUser)" & _
                " SELECT t1.FormId,t1.PDFFieldName," & iToYear & ",t1.TableName," & _
                " t1.FieldName," & _
                QuoStr(AppData.UserId) & _
                " FROM ClientFormsXRef t1 WHERE t1.TaxYear = " & iFromYear & _
                " AND NOT EXISTS(SELECT t2.FormId FROM ClientFormsXRef t2" & _
                " WHERE t2.FormId = t1.FormId AND t2.PDFFieldName = t1.PDFFieldName" & _
                " AND t2.TaxYear = " & iToYear & ")"
            lRows = ExecuteSQL(sSQL)

            sSQL = "INSERT Factors (FactorEntityId,FactorCode,Age,TaxYear,Percentage,AddUser)" & _
                " SELECT t1.FactorEntityId,t1.FactorCode,t1.Age," & iToYear & ",t1.Percentage," & QuoStr(AppData.UserId) & _
                " FROM Factors t1 WHERE t1.TaxYear = " & iFromYear & _
                " AND NOT EXISTS(SELECT t2.FactorEntityId FROM Factors t2" & _
                " WHERE t2.FactorEntityId = t1.FactorEntityId AND t2.FactorCode = t1.FactorCode" & _
                " AND t2.Age = t1.Age" & _
                " AND t2.TaxYear = " & iToYear & ")"
            lRows = ExecuteSQL(sSQL)

            'sSQL = "INSERT FactorCodeXRef (StateCd,StateFactorCode,FactorEntityId,TaxYear,EntityFactorCode,AddUser)" & _
            '    " SELECT t1.StateCd,t1.StateFactorCode,t1.FactorEntityId," & iToYear & "," & _
            '    " t1.EntityFactorCode," & _
            '    QuoStr(AppData.UserId) & _
            '    " FROM FactorCodeXRef t1 WHERE t1.TaxYear = " & iFromYear & _
            '    " AND NOT EXISTS(SELECT t2.StateCd FROM FactorCodeXRef t2" & _
            '    " WHERE t2.StateCd = t1.StateCd AND t2.StateFactorCode = t1.StateFactorCode" & _
            '    " AND t2.FactorEntityId = t1.FactorEntityId" & _
            '    " AND t2.TaxYear = " & iToYear & ")"
            'lRows = ExecuteSQL(sSQL)

            sSQL = "INSERT ClientGLCodeXRef (ClientId,StateCd,GLCode,TaxYear,FactorEntityId,FactorCode,AddUser)" & _
                " SELECT t1.ClientId, t1.StateCd, t1.GLCode," & iToYear & ",t1.FactorEntityId, t1.FactorCode," & _
                QuoStr(AppData.UserId) & _
                " FROM ClientGLCodeXRef t1 WHERE t1.TaxYear = " & iFromYear & _
                " AND NOT EXISTS(SELECT t2.StateCd FROM ClientGLCodeXRef t2" & _
                " WHERE t2.ClientId = t1.ClientId AND t2.StateCd = t1.StateCd" & _
                " AND t2.GLCode = t1.GLCode AND t2.FactorEntityId = t1.FactorEntityId" & _
                " AND t2.TaxYear = " & iToYear & ")"
            lRows = ExecuteSQL(sSQL)

            sSQL = "INSERT FactorCodeOverrides (ClientId,LocationId,AssessmentId,AssetId,FactorEntityId,TaxYear,FactorCode,AddUser)" & _
                " SELECT t1.ClientId,t1.LocationId,t1.AssessmentId,t1.AssetId,t1.FactorEntityId," & iToYear & "," & _
                " t1.FactorCode," & QuoStr(AppData.UserId) & _
                " FROM FactorCodeOverrides t1 WHERE t1.TaxYear = " & iFromYear & _
                " AND NOT EXISTS(SELECT t2.ClientId FROM FactorCodeOverrides t2" & _
                " WHERE t2.ClientId = t1.ClientId AND t2.LocationId = t1.LocationId AND t2.AssessmentId = t1.AssessmentId" & _
                " AND t2.AssetId = t1.AssetId AND t2.FactorEntityId = t1.FactorEntityId" & _
                " AND t2.TaxYear = " & iToYear & ")"
            If lClientId > 0 Then sSQL = sSQL & " AND t1.ClientId = " & lClientId
            If lLocationId > 0 Then sSQL = sSQL & " AND t1.LocationId = " & lLocationId
            If lAssessmentId > 0 Then sSQL = sSQL & " AND t1.AssessmentId = " & lAssessmentId
            lRows = ExecuteSQL(sSQL)

            sSQL = "INSERT ClientFactorCodeOverrides (ClientId,LocationId,AssessmentId,AssetId,FactorEntityId,TaxYear,FactorCode,AddUser)" & _
                " SELECT t1.ClientId,t1.LocationId,t1.AssessmentId,t1.AssetId,t1.FactorEntityId," & iToYear & "," & _
                " t1.FactorCode," & QuoStr(AppData.UserId) & _
                " FROM ClientFactorCodeOverrides t1 WHERE t1.TaxYear = " & iFromYear & _
                " AND NOT EXISTS(SELECT t2.ClientId FROM ClientFactorCodeOverrides t2" & _
                " WHERE t2.ClientId = t1.ClientId AND t2.LocationId = t1.LocationId AND t2.AssessmentId = t1.AssessmentId" & _
                " AND t2.AssetId = t1.AssetId AND t2.FactorEntityId = t1.FactorEntityId" & _
                " AND t2.TaxYear = " & iToYear & ")"
            If lClientId > 0 Then sSQL = sSQL & " AND t1.ClientId = " & lClientId
            If lLocationId > 0 Then sSQL = sSQL & " AND t1.LocationId = " & lLocationId
            If lAssessmentId > 0 Then sSQL = sSQL & " AND t1.AssessmentId = " & lAssessmentId
            lRows = ExecuteSQL(sSQL)

            sSQL = "INSERT AssetAllocationPct (ClientId,LocationId,AssessmentId,AssetId,FactorEntityId,TaxYear,AllocationPct,AddUser,InterstateAllocationPct)" & _
                " SELECT t1.ClientId,t1.LocationId,t1.AssessmentId,t1.AssetId,t1.FactorEntityId," & iToYear & "," & _
                " t1.AllocationPct," & QuoStr(AppData.UserId) & ",t1.InterstateAllocationPct" & _
                " FROM AssetAllocationPct t1 WHERE t1.TaxYear = " & iFromYear & _
                " AND NOT EXISTS(SELECT t2.ClientId FROM AssetAllocationPct t2" & _
                " WHERE t2.ClientId = t1.ClientId AND t2.LocationId = t1.LocationId AND t2.AssessmentId = t1.AssessmentId" & _
                " AND t2.AssetId = t1.AssetId AND t2.FactorEntityId = t1.FactorEntityId" & _
                " AND t2.TaxYear = " & iToYear & ")"
            If lClientId > 0 Then sSQL = sSQL & " AND t1.ClientId = " & lClientId
            If lLocationId > 0 Then sSQL = sSQL & " AND t1.LocationId = " & lLocationId
            If lAssessmentId > 0 Then sSQL = sSQL & " AND t1.AssessmentId = " & lAssessmentId
            lRows = ExecuteSQL(sSQL)

            sSQL = "INSERT TaxBillsBPP (ClientId,LocationId,AssessmentId,CollectorId,TaxYear,AddUser,TaxBillAcctNum)" &
                " SELECT t1.ClientId,t1.LocationId,t1.AssessmentId,t1.CollectorId," & iToYear & "," & QuoStr(AppData.UserId) & ",t1.TaxBillAcctNum" &
                " FROM TaxBillsBPP t1 WHERE t1.TaxYear = " & iFromYear &
                " AND NOT EXISTS(SELECT t2.ClientId FROM TaxBillsBPP t2" &
                " WHERE t2.ClientId = t1.ClientId AND t2.LocationId = t1.LocationId" &
                " AND t2.AssessmentId = t1.AssessmentId AND t2.CollectorId = t1.CollectorId" &
                " AND t2.TaxYear = " & iToYear & ")"
            If lClientId > 0 Then sSQL = sSQL & " AND t1.ClientId = " & lClientId
            If lLocationId > 0 Then sSQL = sSQL & " AND t1.LocationId = " & lLocationId
            If lAssessmentId > 0 Then sSQL = sSQL & " AND t1.AssessmentId = " & lAssessmentId
            lRows = ExecuteSQL(sSQL)

            sSQL = "INSERT TaxBillsRE (ClientId,LocationId,AssessmentId,CollectorId,TaxYear,AddUser,TaxBillAcctNum)" &
                " SELECT t1.ClientId,t1.LocationId,t1.AssessmentId,t1.CollectorId," & iToYear & "," & QuoStr(AppData.UserId) & ",t1.TaxBillAcctNum" &
                " FROM TaxBillsRE t1 WHERE t1.TaxYear = " & iFromYear &
                " AND NOT EXISTS(SELECT t2.ClientId FROM TaxBillsRE t2" &
                " WHERE t2.ClientId = t1.ClientId AND t2.LocationId = t1.LocationId" &
                " AND t2.AssessmentId = t1.AssessmentId AND t2.CollectorId = t1.CollectorId" &
                " AND t2.TaxYear = " & iToYear & ")"
            If lClientId > 0 Then sSQL = sSQL & " AND t1.ClientId = " & lClientId
            If lLocationId > 0 Then sSQL = sSQL & " AND t1.LocationId = " & lLocationId
            If lAssessmentId > 0 Then sSQL = sSQL & " AND t1.AssessmentId = " & lAssessmentId
            lRows = ExecuteSQL(sSQL)

            Return True
        Catch ex As Exception
            MsgBox("Error in RollData:  " & ex.Message)
            Return False
        End Try
    End Function

    Public Function CloseMDIChildren() As Boolean
        'Returns vbOK if successful, vbCancel if the user selects the cancel button at any time in the process
        Dim frm As Form

        For Each frm In MDIParent1.MdiChildren
            frm.Close()
        Next
        Return True

    End Function
    Public Function AddFactorCodeXRef(ByVal sStateCd As String, ByVal sStateFactorCode As String, ByVal lFactorEntityId As Long, _
                ByVal iTaxYear As Integer, ByVal sEntityFactorCode As String, ByVal sOldStateFactorCode As String) As Boolean
        Dim sSQL As String

        Try

            sStateFactorCode = UCase(Trim(sStateFactorCode))

            If sStateFactorCode = "" Then
                sSQL = "delete FactorCodeXRef where StateCd = " & QuoStr(sStateCd) & _
                    " and FactorEntityId = " & lFactorEntityId & _
                    " and TaxYear = " & iTaxYear & _
                    " and EntityFactorCode = " & QuoStr(sEntityFactorCode) & _
                    " and StateFactorCode = " & QuoStr(sOldStateFactorCode)
                ExecuteSQL(sSQL)
            Else
                sSQL = "update FactorCodeXRef set StateFactorCode = " & QuoStr(sStateFactorCode) & "," & _
                    " ChangeDate = getdate(), ChangeUser = " & QuoStr(AppData.UserId) & _
                    " where StateCd = " & QuoStr(sStateCd) & _
                    " and FactorEntityId = " & lFactorEntityId & _
                    " and TaxYear = " & iTaxYear & _
                    " and EntityFactorCode = " & QuoStr(sEntityFactorCode) & _
                    " and StateFactorCode = " & QuoStr(sOldStateFactorCode)
                If ExecuteSQL(sSQL) = 0 Then
                    sSQL = "insert FactorCodeXRef (StateCd,StateFactorCode,FactorEntityId,TaxYear,EntityFactorCode,AddUser)" & _
                        " select " & QuoStr(sStateCd) & "," & QuoStr(sStateFactorCode) & "," & lFactorEntityId & "," & iTaxYear & "," & _
                        QuoStr(sEntityFactorCode) & "," & QuoStr(AppData.UserId)
                    ExecuteSQL(sSQL)
                End If
            End If
            Return True
        Catch ex As Exception
            MsgBox("Error saving data:  " & ex.Message)
            Return False
        End Try
    End Function

End Module
