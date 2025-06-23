Imports System.IO
Imports System.Security.Cryptography
Imports System.Threading

Module modMain
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
        Friend ClientReportingServer As Boolean
        Friend ConsultantName As String
        Friend FullName As String
        Friend IsAdministrator As Boolean
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

    Sub Main()
        Try
            AppData.UserId = Microsoft.VisualBasic.Left(Trim(UCase(Environ("username"))), 30)
            If AppData.UserId = "JAMESSTIGLER" Then
                AppData.Server = "MSI"
            Else
                AppData.Server = "10.10.1.4\SQLEXPRESS"
            End If
            Console.Title = "Client Reporting Application"
            LogMsg("Starting")
            ConnectToDB()
            RunClientReporting()

        Catch ex As Exception
            LogMsg("Error:  " & ex.Message)
        End Try

        End

    End Sub
    Public Sub LogMsg(msg As String)
        Try
            Console.WriteLine(Now.ToString("G") & "  " & msg)
            Dim logfile
            If AppData.UserId = "JAMESSTIGLER" Then
                logfile = "C:\MyTempFolder\vantageone\temp\ClientReportingStatus.LOG"
            Else
                logfile = "\\vot-file\Vantage\Assessment Manager\AssessmentManagerLogs\ClientReportingStatus.LOG"
            End If
            If Directory.Exists(Path.GetDirectoryName(logfile)) = False Then Directory.CreateDirectory(Path.GetDirectoryName(logfile))
            My.Computer.FileSystem.WriteAllText(logfile, Now.ToString("G") & "  " & msg & vbCrLf, True)
        Catch ex As Exception
        End Try
    End Sub

End Module
