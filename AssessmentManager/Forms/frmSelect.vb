Public Class frmSelect
    Private m_ClientId As Long
    Private m_LocationId As Long
    Private m_AssessmentId As Long
    Private bRefreshing As Boolean
    Private bActivated As Boolean
    Private colClients As Collection
    Private colAssessors As Collection
    Private colLocations As Collection
    Private colAssessments As Collection
    Private colFactorEntities As Collection
    Private colJurisdictions As Collection
    Private colBusinessUnits As Collection
    Private colCollectors As Collection
    Private colTasks As Collection
    Private colStateCodes As Collection
    Private m_TypeOfImport As enumTable
    Private m_TypeOfAdd As enumTable
    Private m_TypeOfReport As enumReport
    Private m_Parm1 As Double
    Private m_SendToPrinter As Boolean
    Private m_ExportFolder As String
    Private m_PropType As enumTable
    Private m_StateCd As String
    Private m_CallingFormHandle As Long
    Private m_ImportAssetsForClient As Boolean
    Private m_FactorEntityId As Long
    Private m_PrintClientScheduleOnly As Boolean
    Private m_AssessorId As Long
    Private m_ContactType As enumContactTypes
    Private m_BarCodeType As enumBarCodeTypes
    Private m_PrintCoverPage As Boolean
    Private m_IncludeZeroAmounts As Boolean
    Private m_ShowCostAndFactors As Boolean

    Private lblClient As Label
    Private lblTask As Label
    Private lblLocation As Label
    Private lblAssessment As Label
    Private lblState As Label
    Private lblFactorEntityName As Label
    Private lblFactorCode As Label
    Private lblStateFactorCode As Label
    Private lblJurisdiction As Label
    Private lblPropType As Label
    Private lblAssessor As Label
    Private lblCollector As Label
    Private lblBusinessUnit As Label

    Friend WithEvents cboClient As ComboBox
    Friend WithEvents cboLocation As ComboBox
    Friend WithEvents cboAssessment As ComboBox
    Friend WithEvents cboStateCd As ComboBox
    Friend WithEvents cboFactorEntity As ComboBox
    Friend WithEvents cboFactorCode As ComboBox
    Friend WithEvents cboStateFactorCode As ComboBox
    Friend WithEvents cboJurisdiction As ComboBox
    Friend WithEvents cboTask As ComboBox
    Friend WithEvents cboPropType As ComboBox
    Friend WithEvents cboAssessor As ComboBox
    Friend WithEvents cboCollector As ComboBox
    Friend WithEvents cboBusinessUnit As ComboBox

    Public Property ClientId() As Long
        Get
            Return m_ClientId
        End Get
        Set(ByVal value As Long)
            m_ClientId = value
        End Set
    End Property
    Public Property ImportAssetsForClient() As Boolean
        Get
            Return m_ImportAssetsForClient
        End Get
        Set(ByVal value As Boolean)
            m_ImportAssetsForClient = value
        End Set
    End Property
    Public Property LocationId() As Long
        Get
            Return m_LocationId
        End Get
        Set(ByVal value As Long)
            m_LocationId = value
        End Set
    End Property
    Public Property AssessmentId() As Long
        Get
            Return m_AssessmentId
        End Get
        Set(ByVal value As Long)
            m_AssessmentId = value
        End Set
    End Property
    Public Property StateCd() As String
        Get
            Return m_StateCd
        End Get
        Set(ByVal value As String)
            m_StateCd = value
        End Set
    End Property
    Public Property TypeOfImport() As Integer
        Get
            Return m_TypeOfImport
        End Get
        Set(ByVal value As Integer)
            m_TypeOfImport = value
        End Set
    End Property
    Public Property TypeOfAdd() As Integer
        Get
            Return m_TypeOfAdd
        End Get
        Set(ByVal value As Integer)
            m_TypeOfAdd = value
        End Set
    End Property
    Public Property TypeOfReport() As Integer
        Get
            Return m_TypeOfReport
        End Get
        Set(ByVal value As Integer)
            m_TypeOfReport = value
        End Set
    End Property
    Public Property SendToPrinter() As Boolean
        Get
            Return m_SendToPrinter
        End Get
        Set(ByVal value As Boolean)
            m_SendToPrinter = value
        End Set
    End Property
    Public Property ExportFolder() As String
        Get
            Return m_Exportfolder
        End Get
        Set(ByVal value As String)
            m_Exportfolder = value
        End Set
    End Property

    Public Property Parm1() As Double
        Get
            Return m_Parm1
        End Get
        Set(ByVal value As Double)
            m_Parm1 = value
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
    Public Property FactorEntityId As Long
        Get
            Return m_FactorEntityId
        End Get
        Set(value As Long)
            m_FactorEntityId = value
        End Set
    End Property
    Public Property PrintClientScheduleOnly As Boolean
        Get
            Return m_PrintClientScheduleOnly
        End Get
        Set(value As Boolean)
            m_PrintClientScheduleOnly = value
        End Set
    End Property
    Public Property CallingFormHandle() As Long
        Get
            Return m_CallingFormHandle
        End Get
        Set(ByVal value As Long)
            m_CallingFormHandle = value
        End Set
    End Property
    Public Property AssessorId() As Long
        Get
            Return m_AssessorId
        End Get
        Set(value As Long)
            m_AssessorId = value
        End Set
    End Property
    Public Property ContactType() As Integer
        Get
            Return m_ContactType
        End Get
        Set(value As Integer)
            m_ContactType = value
        End Set
    End Property
    Public Property BarCodeType() As Integer
        Get
            Return m_BarCodeType
        End Get
        Set(value As Integer)
            m_BarCodeType = value
        End Set
    End Property
    Public Property PrintCoverPage() As Boolean
        Get
            Return m_PrintCoverPage
        End Get
        Set(value As Boolean)
            m_PrintCoverPage = value
        End Set
    End Property
    Public Property IncludeZeroAmounts() As Boolean
        Get
            Return m_IncludeZeroAmounts
        End Get
        Set(value As Boolean)
            m_IncludeZeroAmounts = value
        End Set
    End Property
    Public Property ShowCostAndFactors() As Boolean
        Get
            Return m_ShowCostAndFactors
        End Get
        Set(value As Boolean)
            m_ShowCostAndFactors = value
        End Set
    End Property
    Private Sub frmSelect_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If bActivated Then Exit Sub

        Try

            If m_TypeOfReport = enumReport.enumAssessorCover Then
                lblAssessor = New Label
                lblAssessor.Text = "Assessor"
                lblAssessor.Width = 75
                lblAssessor.TextAlign = ContentAlignment.MiddleRight
                lblAssessor.Location = New Point(10, 50)
                Me.Controls.Add(lblAssessor)

                cboAssessor = New ComboBox
                colAssessors = New Collection
                'select AssessorId, RTRIM(Name) + ', ' + RTRIM(StateCd) AS Name from Assessors
                LoadComboBox("select AssessorId, RTRIM(Name) + ', ' + RTRIM(StateCd) AS Name from Assessors WHERE TaxYear = " & AppData.TaxYear & _
                    " ORDER BY Name, StateCd", cboAssessor, colAssessors)
                cboAssessor.Location = New Point(100, 50)
                cboAssessor.Width = 400
                Me.Controls.Add(cboAssessor)
            End If

            If m_TypeOfImport = enumTable.enumAsset Or m_TypeOfImport = enumTable.enumAssessmentBPP Or
                        m_TypeOfImport = enumTable.enumAssessmentRE Or m_TypeOfAdd = enumTable.enumAssessmentBPP Or
                        m_TypeOfAdd = enumTable.enumAssessmentRE Or m_TypeOfImport = enumTable.enumLocationBPP Or
                        m_TypeOfAdd = enumTable.enumLocationBPP Or m_TypeOfAdd = enumTable.enumLocationRE Or
                        m_TypeOfAdd = enumTable.enumProspectLocation Or
                        m_TypeOfImport = enumTable.enumLocationRE Or m_TypeOfAdd = enumTable.enumClientGLCode Or
                        m_TypeOfReport = enumReport.enumAssetDetail Or m_TypeOfReport = enumReport.enumAssetSummary Or
                        m_TypeOfReport = enumReport.enumAssetDetailCost Or m_TypeOfReport = enumReport.enumAssetDetailExempt Or
                        m_TypeOfReport = enumReport.enumAssetDetailNon Or
                        m_TypeOfReport = enumReport.enumAssetDetailLeasedProperty Or
                        m_TypeOfReport = enumReport.enumAssetDetailLeaseholdImprovements Or
                        m_TypeOfReport = enumReport.enumAssetDetailLeasesAll Or m_TypeOfReport = enumReport.enumLeaseSummary Or
                        m_TypeOfReport = enumReport.enumFreeportForm Or m_TypeOfReport = enumReport.enumRenditionForm Or
                        m_TypeOfReport = enumReport.enumRenditionExtensionForm Or
                        m_TypeOfReport = enumReport.enumCertificateOfMailing Or m_TypeOfReport = enumReport.enumClientLocationListing Or
                        m_TypeOfReport = enumReport.enumValueProtestForm Or m_TypeOfAdd = enumTable.enumAsset Or
                        m_TypeOfReport = enumReport.enumAffidavitOfEvidence Or m_TypeOfReport = enumReport.enumCorrection Or
                        m_TypeOfReport = enumReport.enumTaxBillCheckOff Or
                        m_TypeOfReport = enumReport.enumTaxBill Or m_TypeOfImport = enumTable.enumTaxBillsBPP Or
                        m_TypeOfReport = enumReport.enumAppointmentOfAgentForm Or m_TypeOfImport = enumTable.enumClientForms Or
                        m_TypeOfReport = enumReport.enumFixedAssetReconByGLCode Or m_TypeOfReport = enumReport.enumFixedAssetReconByDeprCode Or
                        m_TypeOfReport = enumReport.enumTaxAccrual Or m_TypeOfReport = enumReport.enumTaxAccrualSummary Or
                        m_TypeOfReport = enumReport.enumValueComparison Or
                        m_TypeOfReport = enumReport.enumTaxSavings Or m_TypeOfReport = enumReport.enumClientEnvelope Or
                        m_TypeOfReport = enumReport.enumBarCode Then

                lblClient = New Label
                lblClient.Text = "Client"
                lblClient.Width = 75
                lblClient.TextAlign = ContentAlignment.MiddleRight
                lblClient.Location = New Point(10, 25)
                Me.Controls.Add(lblClient)

                cboClient = New ComboBox
                colClients = New Collection
                LoadComboBox("select ClientId, Name from Clients WHERE ISNULL(ProspectFl,0) = " &
                    IIf(m_TypeOfAdd = enumTable.enumProspectLocation, "1", "0") &
                    IIf(AppData.IncludeInactive = False, " AND ISNULL(InactiveFl,0) = 0", "") &
                    " ORDER BY Name", cboClient, colClients)
                cboClient.Location = New Point(100, 25)
                cboClient.Width = 400
                Me.Controls.Add(cboClient)

                If m_ImportAssetsForClient Or m_TypeOfReport = enumReport.enumClientLocationListing Or
                        m_TypeOfReport = enumReport.enumFixedAssetReconByGLCode Or m_TypeOfReport = enumReport.enumFixedAssetReconByDeprCode Or
                        m_TypeOfReport = enumReport.enumValueComparison Or
                        m_TypeOfReport = enumReport.enumClientEnvelope Then
                ElseIf m_TypeOfReport = enumReport.enumTaxSavings Or m_TypeOfReport = enumReport.enumTaxAccrual Or m_TypeOfReport = enumReport.enumTaxAccrualSummary Then
                    CreateBusinessUnitControls()
                Else
                    lblAssessor = New Label
                    lblAssessor.Text = "Assessor"
                    lblAssessor.Width = 75
                    lblAssessor.TextAlign = ContentAlignment.MiddleRight
                    lblAssessor.Location = New Point(10, 50)
                    If m_TypeOfAdd = enumTable.enumProspectLocation Or m_TypeOfReport = enumReport.enumAppointmentOfAgentForm Then
                        Me.Controls.Add(lblAssessor)
                    End If

                    cboAssessor = New ComboBox
                    colAssessors = New Collection
                    'select AssessorId, RTRIM(Name) + ', ' + RTRIM(StateCd) AS Name from Assessors
                    LoadComboBox("select AssessorId, RTRIM(Name) + ', ' + RTRIM(StateCd) AS Name from Assessors WHERE TaxYear = " & AppData.TaxYear &
                        " ORDER BY Name, StateCd", cboAssessor, colAssessors)
                    cboAssessor.Location = New Point(100, 50)
                    cboAssessor.Width = 400
                    If m_TypeOfAdd = enumTable.enumProspectLocation Or m_TypeOfReport = enumReport.enumAppointmentOfAgentForm Then
                        Me.Controls.Add(cboAssessor)
                    End If
                    'If m_TypeOfAdd = enumTable.enumProspectLocation Then
                    '    cboAssessor.Visible = True
                    'Else
                    '    cboAssessor.Visible = False
                    'End If


                    lblPropType = New Label
                    lblPropType.Text = "Property Type"
                    lblPropType.Width = 75
                    lblPropType.TextAlign = ContentAlignment.MiddleRight
                    lblPropType.Location = New Point(10, 75)
                    If m_TypeOfAdd = enumTable.enumProspectLocation Then Me.Controls.Add(lblPropType)

                    cboPropType = New ComboBox
                    cboPropType.Location = New Point(100, 75)
                    cboPropType.Width = 100
                    cboPropType.Items.Add("BPP")
                    cboPropType.Items.Add("Real")
                    If m_TypeOfAdd = enumTable.enumProspectLocation Then Me.Controls.Add(cboPropType)
                End If
            End If

            If m_TypeOfImport = (enumTable.enumAsset And m_ImportAssetsForClient = False) Or m_TypeOfImport = enumTable.enumAssessmentBPP Or
                    m_TypeOfImport = enumTable.enumAssessmentRE Or m_TypeOfAdd = enumTable.enumAssessmentBPP Or
                    m_TypeOfAdd = enumTable.enumAssessmentRE Or m_TypeOfReport = enumReport.enumAssetDetail Or
                    m_TypeOfReport = enumReport.enumAssetSummary Or
                    m_TypeOfReport = enumReport.enumAssetDetailCost Or m_TypeOfReport = enumReport.enumAssetDetailExempt Or
                    m_TypeOfReport = enumReport.enumAssetDetailLeasedProperty Or
                    m_TypeOfReport = enumReport.enumAssetDetailLeaseholdImprovements Or
                    m_TypeOfReport = enumReport.enumAssetDetailLeasesAll Or m_TypeOfReport = enumReport.enumLeaseSummary Or
                    m_TypeOfReport = enumReport.enumAssetDetailNon Or
                    m_TypeOfReport = enumReport.enumFixedAssetReconByGLCode Or m_TypeOfReport = enumReport.enumFixedAssetReconByDeprCode Or
                    m_TypeOfReport = enumReport.enumFreeportForm Or m_TypeOfReport = enumReport.enumRenditionForm Or
                    m_TypeOfReport = enumReport.enumRenditionExtensionForm Or
                    m_TypeOfAdd = enumTable.enumAsset Then

                lblLocation = New Label
                lblLocation.Text = "Location"
                lblLocation.Width = 75
                lblLocation.TextAlign = ContentAlignment.MiddleRight
                lblLocation.Location = New Point(10, 50)
                Me.Controls.Add(lblLocation)

                cboLocation = New ComboBox
                cboLocation.Location = New Point(100, 50)
                cboLocation.Width = 400
                Me.Controls.Add(cboLocation)
            End If

            If m_TypeOfImport = enumTable.enumProspect Or m_TypeOfImport = enumTable.enumREComps Or m_TypeOfImport = enumTable.enumRECompsCounty Then
                lblAssessor = New Label
                lblAssessor.Text = "Assessor"
                lblAssessor.Width = 75
                lblAssessor.TextAlign = ContentAlignment.MiddleRight
                lblAssessor.Location = New Point(10, 25)
                Me.Controls.Add(lblAssessor)

                cboAssessor = New ComboBox
                colAssessors = New Collection
                LoadComboBox("select AssessorId, RTRIM(Name) + ', ' + RTRIM(StateCd) AS Name from Assessors WHERE TaxYear = " & AppData.TaxYear &
                    IIf(m_TypeOfImport = enumTable.enumRECompsCounty, " AND ISNULL(REImportTypeCd,0) <> 0", "") &
                    " ORDER BY Name, StateCd", cboAssessor, colAssessors)
                cboAssessor.Location = New Point(100, 25)
                cboAssessor.Width = 400
                Me.Controls.Add(cboAssessor)
            End If

            If m_TypeOfReport = enumReport.enumTaxBillCheckOff Or m_TypeOfReport = enumReport.enumTaxSavings Or
                    m_TypeOfReport = enumReport.enumTaxAccrual Or m_TypeOfReport = enumReport.enumTaxAccrualSummary Then
                lblPropType = New Label
                lblPropType.Text = "Property Type"
                lblPropType.Width = 75
                lblPropType.TextAlign = ContentAlignment.MiddleRight
                lblPropType.Location = New Point(10, 50)
                Me.Controls.Add(lblPropType)

                cboPropType = New ComboBox
                cboPropType.Location = New Point(100, 50)
                cboPropType.Width = 100
                cboPropType.Items.Add("BPP")
                cboPropType.Items.Add("Real")
                If m_TypeOfReport = enumReport.enumTaxSavings Or m_TypeOfReport = enumReport.enumTaxAccrual Or m_TypeOfReport = enumReport.enumTaxAccrualSummary Then cboPropType.Items.Add("")
                Me.Controls.Add(cboPropType)
            End If

            If m_TypeOfReport = enumReport.enumTaxSavings Or m_TypeOfReport = enumReport.enumTaxAccrual Or m_TypeOfReport = enumReport.enumTaxAccrualSummary Then
                CreateStateCdDropDown("State", 100)
            End If

            If m_TypeOfReport = enumReport.enumValueProtestForm Or
                    m_TypeOfReport = enumReport.enumCertificateOfMailing Or
                    m_TypeOfReport = enumReport.enumTaxBill Or
                    m_TypeOfReport = enumReport.enumBarCode Or
                    m_TypeOfReport = enumReport.enumAffidavitOfEvidence Or
                    m_TypeOfReport = enumReport.enumCorrection Or
                    m_TypeOfImport = enumTable.enumTaxBillsBPP Then
                lblPropType = New Label
                lblPropType.Text = "Property Type"
                lblPropType.Width = 75
                lblPropType.TextAlign = ContentAlignment.MiddleRight
                lblPropType.Location = New Point(10, 50)
                Me.Controls.Add(lblPropType)

                cboPropType = New ComboBox
                cboPropType.Location = New Point(100, 50)
                cboPropType.Width = 100
                cboPropType.Items.Add("BPP")
                cboPropType.Items.Add("Real")
                Me.Controls.Add(cboPropType)

                lblLocation = New Label
                lblLocation.Text = "Location"
                lblLocation.Width = 75
                lblLocation.TextAlign = ContentAlignment.MiddleRight
                lblLocation.Location = New Point(10, 75)
                Me.Controls.Add(lblLocation)

                cboLocation = New ComboBox
                cboLocation.Location = New Point(100, 75)
                cboLocation.Width = 400
                Me.Controls.Add(cboLocation)

                lblAssessment = New Label
                lblAssessment.Text = "Assessment"
                lblAssessment.Width = 75
                lblAssessment.TextAlign = ContentAlignment.MiddleRight
                lblAssessment.Location = New Point(10, 100)
                Me.Controls.Add(lblAssessment)

                cboAssessment = New ComboBox
                cboAssessment.Location = New Point(100, 100)
                cboAssessment.Width = 400
                Me.Controls.Add(cboAssessment)

            End If


            If m_TypeOfReport = enumReport.enumAssetDetail Or m_TypeOfReport = enumReport.enumAssetSummary Or
                    m_TypeOfReport = enumReport.enumAssetDetailCost Or m_TypeOfReport = enumReport.enumAssetDetailExempt Or
                    m_TypeOfReport = enumReport.enumAssetDetailNon Or
                    m_TypeOfReport = enumReport.enumAssetDetailLeasedProperty Or
                    m_TypeOfReport = enumReport.enumAssetDetailLeaseholdImprovements Or
                    m_TypeOfReport = enumReport.enumAssetDetailLeasesAll Or m_TypeOfReport = enumReport.enumLeaseSummary Or
                    m_TypeOfReport = enumReport.enumFreeportForm Or m_TypeOfReport = enumReport.enumRenditionForm Or
                    m_TypeOfReport = enumReport.enumRenditionExtensionForm Or
                    m_TypeOfReport = enumReport.enumFixedAssetReconByGLCode Or m_TypeOfReport = enumReport.enumFixedAssetReconByDeprCode Or
                    m_TypeOfAdd = enumTable.enumAsset Or (m_TypeOfImport = enumTable.enumAsset And m_ImportAssetsForClient = False) Then
                lblAssessment = New Label
                lblAssessment.Text = "Assessment"
                lblAssessment.Width = 75
                lblAssessment.TextAlign = ContentAlignment.MiddleRight
                lblAssessment.Location = New Point(10, 75)
                Me.Controls.Add(lblAssessment)

                cboAssessment = New ComboBox
                cboAssessment.Location = New Point(100, 75)
                cboAssessment.Width = 400
                Me.Controls.Add(cboAssessment)


            End If

            If m_TypeOfAdd = enumTable.enumClientGLCode Or m_TypeOfAdd = enumTable.enumStateFactorCode Or
                    m_TypeOfAdd = enumTable.enumFactorCodeXRef Or m_TypeOfImport = enumTable.enumClientForms Then

                lblState = New Label
                lblState.Text = "State"
                If m_TypeOfAdd = enumTable.enumFactorCodeXRef Then
                    lblState.Width = 125
                Else
                    lblState.Width = 75
                End If
                lblState.TextAlign = ContentAlignment.MiddleRight
                If m_TypeOfAdd = enumTable.enumFactorCodeXRef Then
                    lblState.Location = New Point(10, 25)
                Else
                    lblState.Location = New Point(10, 50)
                End If
                Me.Controls.Add(lblState)

                cboStateCd = New ComboBox
                If m_TypeOfAdd = enumTable.enumFactorCodeXRef Then
                    cboStateCd.Location = New Point(150, 25)
                Else
                    cboStateCd.Location = New Point(100, 50)
                End If
                cboStateCd.Width = 300
                Me.Controls.Add(cboStateCd)
                If m_TypeOfAdd = enumTable.enumStateFactorCode Or m_TypeOfAdd = enumTable.enumFactorCodeXRef Then
                    colClients = New Collection
                    LoadComboBox("select StateCd,StateCd from States", cboStateCd, colClients)  'colclients is dummy
                ElseIf m_TypeOfImport = enumTable.enumClientForms Then
                    colStateNames = New Collection
                    LoadComboBox("select StateCd, StateName from States", cboStateCd, colStateNames)
                End If
            End If


            If m_TypeOfAdd = enumTable.enumFactorCode Or m_TypeOfAdd = enumTable.enumFactor Or
                    m_TypeOfImport = enumTable.enumFactorCode Or m_TypeOfImport = enumTable.enumFactor Or
                    m_TypeOfAdd = enumTable.enumFactorCodeXRef Then

                lblFactorEntityName = New Label
                lblFactorEntityName.Text = "Factoring Entity"
                lblFactorEntityName.Width = 125
                lblFactorEntityName.TextAlign = ContentAlignment.MiddleRight
                If m_TypeOfAdd = enumTable.enumFactorCodeXRef Then
                    lblFactorEntityName.Location = New Point(10, 50)
                Else
                    lblFactorEntityName.Location = New Point(10, 25)
                End If
                Me.Controls.Add(lblFactorEntityName)


                cboFactorEntity = New ComboBox
                colFactorEntities = New Collection
                If m_TypeOfAdd = enumTable.enumFactorCodeXRef Then
                Else
                    LoadComboBox("select FactorEntityId, RTRIM(Name) + ', ' + RTRIM(StateCd) from FactorEntities order by Name,StateCd",
                            cboFactorEntity, colFactorEntities)
                End If
                If m_TypeOfAdd = enumTable.enumFactorCodeXRef Then
                    cboFactorEntity.Location = New Point(150, 50)
                Else
                    cboFactorEntity.Location = New Point(150, 25)
                End If
                cboFactorEntity.Width = 400
                Me.Controls.Add(cboFactorEntity)


            End If

            If m_TypeOfAdd = enumTable.enumFactor Or m_TypeOfAdd = enumTable.enumFactorCodeXRef Then
                lblFactorCode = New Label
                lblFactorCode.Text = "Factor Code"
                lblFactorCode.Width = 125
                lblFactorCode.TextAlign = ContentAlignment.MiddleRight
                If m_TypeOfAdd = enumTable.enumFactorCodeXRef Then
                    lblFactorCode.Location = New Point(10, 75)
                Else
                    lblFactorCode.Location = New Point(10, 50)
                End If
                Me.Controls.Add(lblFactorCode)

                cboFactorCode = New ComboBox
                If m_TypeOfAdd = enumTable.enumFactorCodeXRef Then
                    cboFactorCode.Location = New Point(150, 75)
                Else
                    cboFactorCode.Location = New Point(150, 50)
                End If
                cboFactorCode.Width = 300
                Me.Controls.Add(cboFactorCode)
            End If

            If m_TypeOfAdd = enumTable.enumFactorCodeXRef Then
                lblStateFactorCode = New Label
                lblStateFactorCode.Text = "State Factor Code"
                lblStateFactorCode.Width = 125
                lblStateFactorCode.TextAlign = ContentAlignment.MiddleRight
                lblStateFactorCode.Location = New Point(10, 100)
                Me.Controls.Add(lblStateFactorCode)

                cboStateFactorCode = New ComboBox
                cboStateFactorCode.Location = New Point(150, 100)
                cboStateFactorCode.Width = 300
                Me.Controls.Add(cboStateFactorCode)

            End If

            If m_TypeOfAdd = enumTable.enumJurisdiction Then
                lblJurisdiction = New Label
                With lblJurisdiction
                    .Text = "Jurisdiction"
                    .Width = 75
                    .TextAlign = ContentAlignment.MiddleRight
                    .Location = New Point(10, 25)
                End With
                Me.Controls.Add(lblJurisdiction)

                cboJurisdiction = New ComboBox
                With cboJurisdiction
                    colJurisdictions = New Collection
                    LoadComboBox("SELECT JurisdictionId, Name FROM Jurisdictions" &
                        " WHERE TaxYear = " & AppData.TaxYear & " AND StateCd = " & QuoStr(m_StateCd) & " order by Name",
                        cboJurisdiction, colJurisdictions)
                    .Location = New Point(100, 25)
                    .Width = 400
                End With
                Me.Controls.Add(cboJurisdiction)
            End If

            If m_TypeOfAdd = enumTable.enumTask Then
                lblTask = New Label
                lblTask.Text = "Task"
                lblTask.Width = 75
                lblTask.TextAlign = ContentAlignment.MiddleRight
                lblTask.Location = New Point(10, 25)
                Me.Controls.Add(lblTask)

                cboTask = New ComboBox
                colTasks = New Collection
                LoadComboBox("select TaskId, Name from TaskMasterList order by Name", cboTask, colTasks)
                cboTask.Location = New Point(100, 25)
                cboTask.Width = 400
                Me.Controls.Add(cboTask)



            End If

            If m_TypeOfImport = enumTable.enumTaxBillsBPP Then
                lblCollector = New Label
                lblCollector.Text = "Collector"
                lblCollector.Width = 75
                lblCollector.TextAlign = ContentAlignment.MiddleRight
                lblCollector.Location = New Point(10, 125)
                Me.Controls.Add(lblCollector)

                cboCollector = New ComboBox
                cboCollector.Location = New Point(100, 125)
                cboCollector.Width = 400
                Me.Controls.Add(cboCollector)

            End If

            If m_TypeOfReport = enumReport.enumValueComparison Then
                lblPropType = New Label
                lblPropType.Text = "Property Type"
                lblPropType.Width = 75
                lblPropType.TextAlign = ContentAlignment.MiddleRight
                lblPropType.Location = New Point(10, 50)
                Me.Controls.Add(lblPropType)

                cboPropType = New ComboBox
                cboPropType.Location = New Point(100, 50)
                cboPropType.Width = 100
                cboPropType.Items.Add("BPP")
                cboPropType.Items.Add("Real")
                Me.Controls.Add(cboPropType)
                cboPropType.Text = "BPP"

                CreateBusinessUnitControls()

                lblState = New Label
                With lblState
                    .Text = "State"
                    .Width = 75
                    .TextAlign = ContentAlignment.MiddleRight
                    .Location = New Point(10, 100)
                End With
                Me.Controls.Add(lblState)

                cboStateCd = New ComboBox
                With cboStateCd
                    colStateCodes = New Collection
                    LoadComboBox("select StateCd, StateName from States", cboStateCd, colStateCodes)
                    .Location = New Point(100, 100)
                    .Width = 400
                End With
                Me.Controls.Add(cboStateCd)

                lblAssessor = New Label
                With lblAssessor
                    .Text = "Assessor"
                    .Width = 75
                    .TextAlign = ContentAlignment.MiddleRight
                    .Location = New Point(10, 125)
                End With
                Me.Controls.Add(lblAssessor)

                cboAssessor = New ComboBox
                With cboAssessor
                    .Location = New Point(100, 125)
                    .Width = 400
                End With
                Me.Controls.Add(cboAssessor)

            End If


            Select Case m_TypeOfAdd
                Case enumTable.enumAssessmentBPP
                    Me.Text = "Adding BPP Assessment"
                Case enumTable.enumAssessmentRE
                    Me.Text = "Adding Real Estate Assessment"
                Case enumTable.enumAssessor
                    Me.Text = "Adding Assessor"
                Case enumTable.enumAsset
                    Me.Text = "Adding Asset"
                Case enumTable.enumClient
                    Me.Text = "Adding Client"
                Case enumTable.enumClientGLCode
                    Me.Text = "Adding Client G/L Code"
                Case enumTable.enumFactor
                    Me.Text = "Adding Factor"
                Case enumTable.enumFactorCode
                    Me.Text = "Adding Factor Code"
                Case enumTable.enumFactorEntity
                    Me.Text = "Adding Factoring Entity"
                Case enumTable.enumLocationBPP
                    Me.Text = "Adding BPP Location"
                Case enumTable.enumLocationRE
                    Me.Text = "Adding Real Estate Location"
                Case enumTable.enumStateFactorCode
                    Me.Text = "Adding State Factor Code"
                Case enumTable.enumFactorCodeXRef
                    Me.Text = "Adding Factor Code XRef"
                Case enumTable.enumAsset
                    Me.Text = "Adding Asset"
                Case enumTable.enumJurisdiction
                    Me.Text = "Adding Jurisdiction"
                Case enumTable.enumTask
                    Me.Text = "Assigning a task"
                Case enumTable.enumProspectLocation
                    Me.Text = "Adding Prospect Location"
            End Select

            If m_TypeOfImport = enumTable.enumTaxBillsBPP Then Me.Text = "Importing Tax Bill"

        Catch ex As Exception
            MsgBox("Error opening screen:  " & ex.Message)
            Me.Close()
        End Try





        bActivated = True
    End Sub

    Private Function LoadValueComparisonDropdowns(lClientId As Long) As Boolean
        Try

            cboBusinessUnit.Items.Clear()
            cboAssessor.Items.Clear()
            cboBusinessUnit.Text = ""
            cboAssessor.Text = ""

            LoadBusinessUnits(lClientId)

            colAssessors = New Collection
            LoadComboBox(" select tbl1.AssessorId, tbl1.Name from (" &
                            "select a.AssessorId, a.Name + ', ' + a.StateCd AS Name from Assessors a, AssessmentsBPP assess where assess.taxyear = " & AppData.TaxYear & " AND assess.assessorid=a.assessorid and assess.taxyear=a.taxyear and assess.clientid = " & lClientId &
                            " union select a.AssessorId, a.Name + ', ' + a.StateCd AS Name from Assessors a, AssessmentsRE assess where assess.taxyear=" & AppData.TaxYear & " AND assess.taxyear=a.taxyear and assess.assessorid=a.assessorid and assess.clientid = " & lClientId &
                            " ) tbl1 group by tbl1.AssessorId, tbl1.Name order by tbl1.Name", cboAssessor, colAssessors)
        Catch ex As Exception
            bRefreshing = False
            MsgBox("Error loading value comparison dropdowns:  " & ex.Message)
            Return False
        End Try

    End Function

    Private Function LoadFactorCodes(ByVal lEntityId As Long) As Boolean
        Dim sSQL As String, colCodes As New Collection
        Try
            bRefreshing = True
            cboFactorCode.Items.Clear()
            cboFactorCode.Text = ""
            sSQL = "select RTRIM(FactorCode),RTRIM(FactorCode) from FactorEntityCodes where FactorEntityId = " & lEntityId &
                " and TaxYear = " & AppData.TaxYear & " AND ISNULL(InactiveFl,0) = 0"
            LoadComboBox(sSQL, cboFactorCode, colCodes)
            bRefreshing = False
            Return True
        Catch ex As Exception
            bRefreshing = False
            MsgBox("Error loading codes:  " & ex.Message)
            Return False
        End Try
    End Function

    Private Function LoadStateFactorCodes(ByVal lEntityId As Long) As Boolean
        Dim sSQL As String, colCodes As New Collection
        Try
            bRefreshing = True
            cboStateFactorCode.Items.Clear()
            cboStateFactorCode.Text = ""
            sSQL = "SELECT sfc.StateFactorCode,sfc.StateFactorCode" &
                " FROM FactorEntities AS fe INNER JOIN" &
                " StateFactorCodes AS sfc ON fe.StateCd = sfc.StateCd" &
                " GROUP BY sfc.StateCd, sfc.StateFactorCode, sfc.TaxYear, fe.FactorEntityId" &
                " HAVING sfc.TaxYear = " & AppData.TaxYear & " AND fe.FactorEntityId = " & lEntityId
            LoadComboBox(sSQL, cboStateFactorCode, colCodes)
            bRefreshing = False
            Return True
        Catch ex As Exception
            bRefreshing = False
            MsgBox("Error loading codes:  " & ex.Message)
            Return False
        End Try

    End Function
    Private Function LoadClientStateCodes(ByVal lClientId As Long) As Boolean
        Dim sSQL As String, colStates As New Collection

        Try
            bRefreshing = True
            cboStateCd.Items.Clear()
            cboStateCd.Text = ""

            sSQL = "SELECT distinct StateCd, StateCd from LocationsBPP" &
                " WHERE ClientId = " & lClientId & " AND TaxYear = " & AppData.TaxYear
            LoadComboBox(sSQL, cboStateCd, colStates)

            bRefreshing = False
            Return True
        Catch ex As Exception
            bRefreshing = False
            MsgBox("Error loading states:  " & ex.Message)
            Return False

        End Try
    End Function

    Private Function LoadAssessments(ByVal lClientId As Long, ByVal lLocationId As Long) As Boolean
        Dim sSQL As String, sType As String

        Try

            bRefreshing = True
            colAssessments = New Collection
            cboAssessment.Items.Clear()
            cboAssessment.Text = ""

            If m_TypeOfAdd = enumTable.enumAssessmentBPP Or (m_TypeOfImport = enumTable.enumAsset And m_ImportAssetsForClient = False) Or
                    m_TypeOfReport = enumTable.enumAsset Or
                    m_TypeOfImport = enumTable.enumAssessmentBPP Or m_TypeOfAdd = enumTable.enumAsset Then
                sType = "BPP"
            ElseIf m_TypeOfAdd = enumTable.enumAssessmentRE Or m_TypeOfImport = enumTable.enumAssessmentRE Then
                sType = "RE"
            ElseIf m_TypeOfReport = enumReport.enumTaxBill Or m_TypeOfReport = enumReport.enumBarCode Or
                    m_TypeOfReport = enumReport.enumValueProtestForm Or
                    m_TypeOfReport = enumReport.enumAffidavitOfEvidence Or
                    m_TypeOfReport = enumReport.enumCorrection Or
                    m_TypeOfReport = enumReport.enumCertificateOfMailing Or
                    m_TypeOfImport = enumTable.enumTaxBillsBPP Then
                If cboPropType.Text = "Real" Then
                    sType = "RE"
                Else
                    sType = "BPP"
                End If
            ElseIf m_TypeOfReport = enumReport.enumAssetDetail Or m_TypeOfReport = enumReport.enumAssetSummary Or
                    m_TypeOfReport = enumReport.enumAssetDetailCost Or m_TypeOfReport = enumReport.enumAssetDetailExempt Or
                    m_TypeOfReport = enumReport.enumAssetDetailNon Or m_TypeOfReport = enumReport.enumRenditionForm Or
                    m_TypeOfReport = enumReport.enumAssetDetailLeasedProperty Or
                    m_TypeOfReport = enumReport.enumAssetDetailLeaseholdImprovements Or
                    m_TypeOfReport = enumReport.enumAssetDetailLeasesAll Or m_TypeOfReport = enumReport.enumLeaseSummary Or
                    m_TypeOfReport = enumReport.enumRenditionExtensionForm Or m_TypeOfReport = enumReport.enumFixedAssetReconByGLCode Or
                    m_TypeOfReport = enumReport.enumFixedAssetReconByDeprCode Or
                    m_TypeOfReport = enumReport.enumFreeportForm Then
                sType = "BPP"
            End If

            sSQL = "SELECT assess.AssessmentId, RTRIM((isnull(assess.AcctNum,'')) + ' '" &
                " + RTRIM(isnull(a.Name,'')) + ', ' + isnull(a.StateCd,'')) AS Assessor" &
                " FROM Assessments" & sType & " assess LEFT OUTER JOIN Assessors a" &
                " ON assess.AssessorId = a.AssessorId AND assess.TaxYear = a.TaxYear" &
                " WHERE assess.ClientId = " & lClientId & " AND assess.LocationId = " & lLocationId &
                " AND assess.TaxYear = " & AppData.TaxYear &
                IIf(AppData.IncludeInactive = False, " AND ISNULL(assess.InactiveFl,0) = 0", "") &
                " ORDER BY assess.AcctNum,a.Name,a.StateCd"
            LoadComboBox(sSQL, cboAssessment, colAssessments)

            bRefreshing = False
            Return True
        Catch ex As Exception
            bRefreshing = False
            MsgBox("Error loading assessments:  " & ex.Message)
            Return False
        End Try



    End Function

    Private Function LoadAssessors(ByVal lClientId As Long) As Boolean
        Dim sSQL As String = ""

        Try
            bRefreshing = True
            colAssessors = New Collection
            cboAssessor.Items.Clear()
            cboAssessor.Text = ""
            sSQL = "SELECT a.AssessorId, RTRIM(a.Name) + ', ' + RTRIM(a.StateCd) AS Name from Assessors a WHERE a.TaxYear = " & AppData.TaxYear &
                " AND EXISTS (SELECT assess.AssessorId FROM AssessmentsBPP assess WHERE assess.ClientId = " & lClientId &
                " AND assess.TaxYear = " & AppData.TaxYear & " AND assess.AssessorId = a.AssessorId" &
                " AND a.TaxYear = " & AppData.TaxYear &
                " UNION SELECT assess.AssessorId FROM AssessmentsRE assess WHERE assess.ClientId = " & lClientId &
                " AND assess.TaxYear = " & AppData.TaxYear & " AND assess.AssessorId = a.AssessorId" &
                " AND a.TaxYear = " & AppData.TaxYear & ")" &
                " ORDER BY a.Name, a.StateCd"
            LoadComboBox(sSQL, cboAssessor, colAssessors)

            bRefreshing = False
            Return True
        Catch ex As Exception
            bRefreshing = False
            MsgBox("Error loading assessors:  " & ex.Message)
            Return False
        End Try
    End Function

    Private Function LoadLocations(ByVal lClientId As Long) As Boolean
        Dim sSQL As String = "", sType As String = ""

        Try
            If m_TypeOfAdd = enumTable.enumLocationBPP Or m_TypeOfAdd = enumTable.enumLocationRE Or
                    m_TypeOfImport = enumTable.enumLocationBPP Or m_TypeOfImport = enumTable.enumLocationRE Or
                    (m_TypeOfImport = enumTable.enumAsset And m_ImportAssetsForClient = True) Then
                Return True
            End If

            bRefreshing = True
            colLocations = New Collection
            cboLocation.Items.Clear()
            cboLocation.Text = ""

            If m_TypeOfAdd = enumTable.enumAssessmentBPP Or (m_TypeOfImport = enumTable.enumAsset And m_ImportAssetsForClient = False) Or
                    m_TypeOfReport = enumReport.enumAssetDetail Or m_TypeOfReport = enumReport.enumAssetSummary Or
                    m_TypeOfReport = enumReport.enumAssetDetailCost Or m_TypeOfReport = enumReport.enumAssetDetailExempt Or
                    m_TypeOfReport = enumReport.enumAssetDetailLeasedProperty Or
                    m_TypeOfReport = enumReport.enumAssetDetailLeaseholdImprovements Or
                    m_TypeOfReport = enumReport.enumAssetDetailLeasesAll Or m_TypeOfReport = enumReport.enumLeaseSummary Or
                    m_TypeOfReport = enumReport.enumAssetDetailNon Or
                    m_TypeOfImport = enumTable.enumAssessmentBPP Or m_TypeOfReport = enumReport.enumFixedAssetReconByGLCode Or m_TypeOfReport = enumReport.enumFixedAssetReconByDeprCode Or
                    m_TypeOfReport = enumReport.enumFreeportForm Or m_TypeOfReport = enumReport.enumRenditionForm Or
                    m_TypeOfReport = enumReport.enumRenditionExtensionForm Or
                    m_TypeOfAdd = enumTable.enumAsset Then
                sType = "BPP"
            ElseIf m_TypeOfAdd = enumTable.enumAssessmentRE Or m_TypeOfImport = enumTable.enumAssessmentRE Then
                sType = "RE"
            ElseIf m_TypeOfReport = enumReport.enumValueProtestForm Or
                    m_TypeOfReport = enumReport.enumTaxBill Or m_TypeOfReport = enumReport.enumBarCode Or
                    m_TypeOfReport = enumReport.enumAffidavitOfEvidence Or
                    m_TypeOfReport = enumReport.enumCorrection Or
                    m_TypeOfReport = enumReport.enumCertificateOfMailing Or
                    m_TypeOfImport = enumTable.enumTaxBillsBPP Then
                If cboPropType.Text = "Real" Then
                    sType = "RE"
                Else
                    sType = "BPP"
                End If
            End If

            sSQL = "SELECT LocationId, RTRIM(ISNULL(Address,'')) + ' ' + RTRIM(ISNULL(City,'')) + ' '" &
                    " + RTRIM(ISNULL(StateCd,''))" &
                    " FROM Locations" & sType & " WHERE ClientId = " & lClientId & " AND TaxYear = " & AppData.TaxYear &
                    IIf(AppData.IncludeInactive = False, " AND ISNULL(InactiveFl,0) = 0", "") &
                    " ORDER BY Address, City, StateCd"
            LoadComboBox(sSQL, cboLocation, colLocations)

            bRefreshing = False
            Return True
        Catch ex As Exception
            bRefreshing = False
            MsgBox("Error loading locations:  " & ex.Message)
            Return False
        End Try
    End Function

    Private Sub cboClient_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                cboClient.SelectedIndexChanged
        If bActivated And Not bRefreshing Then
            If Not cboLocation Is Nothing Then
                cboLocation.Items.Clear()
                cboLocation.Text = ""
            End If
            If Not cboAssessment Is Nothing Then
                cboAssessment.Items.Clear()
                cboAssessment.Text = ""
            End If
            If Not cboPropType Is Nothing And m_TypeOfReport <> enumReport.enumValueComparison Then
                cboPropType.Text = ""
            End If
            If Not cboCollector Is Nothing Then
                cboCollector.Text = ""
                cboCollector.Items.Clear()
            End If


            If m_TypeOfAdd = enumTable.enumClientGLCode Then
                LoadClientStateCodes(colClients(cboClient.SelectedItem.ToString))
            ElseIf m_TypeOfReport = enumReport.enumTaxBillCheckOff Or m_TypeOfAdd = enumTable.enumProspectLocation Or
                    m_TypeOfImport = enumTable.enumClientForms Or
                    m_TypeOfReport = enumReport.enumClientEnvelope Then
                'nothing
            ElseIf m_TypeOfReport = enumReport.enumTaxBill Or
                    m_TypeOfReport = enumReport.enumValueProtestForm Or
                    m_TypeOfReport = enumReport.enumCertificateOfMailing Or
                    m_TypeOfReport = enumReport.enumAffidavitOfEvidence Or
                    m_TypeOfReport = enumReport.enumCorrection Or
                    m_TypeOfImport = enumTable.enumTaxBillsBPP Or m_TypeOfReport = enumReport.enumClientLocationListing Or
                    m_TypeOfReport = enumReport.enumBarCode Then
                'nothing
            ElseIf m_TypeOfReport = enumReport.enumAppointmentOfAgentForm Then
                LoadAssessors(colClients(cboClient.SelectedItem.ToString))
            ElseIf m_TypeOfReport = enumReport.enumValueComparison Then
                LoadValueComparisonDropdowns(colClients(cboClient.SelectedItem.ToString))
            ElseIf m_TypeOfReport = enumReport.enumTaxAccrual Or m_TypeOfReport = enumReport.enumTaxAccrualSummary Or m_TypeOfReport = enumReport.enumTaxSavings Then
                LoadBusinessUnits(colClients(cboClient.SelectedItem.ToString))
            Else
                LoadLocations(colClients(cboClient.SelectedItem.ToString))
            End If

        End If

    End Sub

    Private Sub cboFactorEntity_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
            cboFactorEntity.SelectedIndexChanged
        If bActivated And Not bRefreshing Then
            If m_TypeOfAdd = enumTable.enumFactor Then
                LoadFactorCodes(colFactorEntities(cboFactorEntity.SelectedItem.ToString))
            ElseIf m_TypeOfAdd = enumTable.enumFactorCodeXRef Then
                LoadFactorCodes(colFactorEntities(cboFactorEntity.SelectedItem.ToString))
                LoadStateFactorCodes(colFactorEntities(cboFactorEntity.SelectedItem.ToString))
            End If

        End If

    End Sub


    Private Sub cmdOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Dim JurisdictionList As New List(Of Long), sPDFFileName As String = ""
        Try



            If m_TypeOfImport = enumTable.enumAsset And m_ImportAssetsForClient = False Then
                ImportAssets(colClients(cboClient.Text), colLocations(cboLocation.Text),
                    colAssessments(cboAssessment.Text), AppData.TaxYear)
            ElseIf m_TypeOfImport = enumTable.enumAsset And m_ImportAssetsForClient = True Then
                ImportBatchAssets(colClients(cboClient.Text), cboClient.Text, AppData.TaxYear)
            ElseIf m_TypeOfImport = enumTable.enumProspect Then
                ImportProspects(colAssessors(cboAssessor.Text), cboAssessor.Text, Microsoft.VisualBasic.Right(cboAssessor.Text, 2))
            ElseIf m_TypeOfImport = enumTable.enumREComps Then
                ImportREComps(colAssessors(cboAssessor.Text), cboAssessor.Text)
            ElseIf m_TypeOfImport = enumTable.enumRECompsCounty Then
                ImportRECompsCounty(colAssessors(cboAssessor.Text), cboAssessor.Text)
            ElseIf m_TypeOfImport = enumTable.enumLocationBPP Or m_TypeOfImport = enumTable.enumLocationRE Then
                ImportLocations(colClients(cboClient.Text), cboClient.Text, AppData.TaxYear, m_TypeOfImport)
            ElseIf m_TypeOfImport = enumTable.enumAssessmentBPP Or m_TypeOfImport = enumTable.enumAssessmentRE Then
                ImportAssessments(colClients(cboClient.Text), colLocations(cboLocation.Text), AppData.TaxYear, m_TypeOfImport)
            ElseIf m_TypeOfImport = enumTable.enumFactorCode Then
                ImportFactorCodes(colFactorEntities(cboFactorEntity.Text))
            ElseIf m_TypeOfAdd = enumTable.enumAssessmentBPP Or m_TypeOfAdd = enumTable.enumAssessmentRE Then
                AddAssessment(colClients(cboClient.Text), colLocations(cboLocation.Text), AppData.TaxYear, m_TypeOfAdd)
            ElseIf m_TypeOfAdd = enumTable.enumLocationBPP Or m_TypeOfAdd = enumTable.enumLocationRE Or
                    m_TypeOfAdd = enumTable.enumProspectLocation Then
                Dim lAssessorId As Long = 0
                If m_TypeOfAdd = enumTable.enumProspectLocation Then
                    lAssessorId = colAssessors(cboAssessor.Text)
                End If
                AddLocation(colClients(cboClient.Text), AppData.TaxYear, lAssessorId,
                    IIf(cboPropType.Text = "BPP", enumTable.enumLocationBPP, enumTable.enumLocationRE),
                    m_TypeOfAdd)
            ElseIf m_TypeOfAdd = enumTable.enumClientGLCode Then
                Dim sError As String = "", sGLCode As String = UCase(Trim(InputBox("Enter G/L Code")))
                If Not AddClientGLCode(colClients(cboClient.Text), cboStateCd.Text, sGLCode, sError) Then _
                    MsgBox("Error creating G/L Code:  " & sError)
            ElseIf m_TypeOfAdd = enumTable.enumFactorCode Then
                Dim sError As String = "", sCode As String = UCase(Trim(InputBox("Enter factor code")))
                If sCode = "" Then Exit Sub
                Dim sDescription As String = Trim(InputBox("Enter description"))
                If Not AddFactorCode(colFactorEntities(cboFactorEntity.Text), sCode, sDescription, sError) Then _
                    MsgBox("Error adding factor code:  " & sError)
            ElseIf m_TypeOfAdd = enumTable.enumFactor Then
                Dim iAge As Integer = Val(InputBox("Enter age"))
                Dim dPercentage As Double = Val(InputBox("Enter percentage"))
                Dim sError As String = ""
                If Not AddFactorAge(colFactorEntities(cboFactorEntity.Text), cboFactorCode.Text, iAge, dPercentage, sError) Then
                    MsgBox("Error adding factor:  " & sError)
                End If
            ElseIf m_TypeOfReport = enumReport.enumAssetDetail Or m_TypeOfReport = enumReport.enumAssetSummary Or
                    m_TypeOfReport = enumReport.enumAssetDetailCost Or m_TypeOfReport = enumReport.enumAssetDetailExempt Or
                    m_TypeOfReport = enumReport.enumAssetDetailLeasedProperty Or
                    m_TypeOfReport = enumReport.enumAssetDetailLeaseholdImprovements Or
                    m_TypeOfReport = enumReport.enumAssetDetailLeasesAll Or m_TypeOfReport = enumReport.enumLeaseSummary Or
                    m_TypeOfReport = enumReport.enumAssetDetailNon Then
                sPDFFileName = CleanFileName("AssetReport_" & m_TypeOfReport & "_" & cboAssessment.Text & ".pdf")
                RunReport(m_TypeOfReport, colClients(cboClient.Text), colLocations(cboLocation.Text),
                    colAssessments(cboAssessment.Text), JurisdictionList, AppData.TaxYear, m_PropType, 0, m_Parm1,
                    m_SendToPrinter, sPDFFileName, m_ExportFolder, m_FactorEntityId, m_PrintClientScheduleOnly, enumContactTypes.enumTax,
                    enumBarCodeTypes.Audit, m_PrintCoverPage, New DataTable, m_IncludeZeroAmounts, m_ShowCostAndFactors)
            ElseIf m_TypeOfReport = enumReport.enumTaxBillCheckOff Then
                Dim lClientId As Long = 0
                If cboClient.Text <> "" Then lClientId = colClients(cboClient.Text)
                sPDFFileName = CleanFileName("TaxBillCheckoffReport_" & cboClient.Text & cboPropType.Text & ".pdf")
                RunReport(m_TypeOfReport, lClientId, 0, 0, JurisdictionList, AppData.TaxYear,
                    IIf(cboPropType.Text = "BPP", enumTable.enumLocationBPP, enumTable.enumLocationRE),
                    0, m_Parm1, m_SendToPrinter, sPDFFileName, m_ExportFolder)
            ElseIf m_TypeOfReport = enumReport.enumClientLocationListing Then
                Dim lClientId As Long = 0
                If cboClient.Text <> "" Then lClientId = colClients(cboClient.Text)
                sPDFFileName = CleanFileName("ClientLocationListing_" & cboClient.Text & ".pdf")
                RunReport(m_TypeOfReport, lClientId, 0, 0, JurisdictionList, AppData.TaxYear,
                    enumTable.enumLocationBPP, 0, False, m_SendToPrinter, sPDFFileName, m_ExportFolder)
            ElseIf m_TypeOfReport = enumReport.enumBarCode Then
                sPDFFileName = CleanFileName("BarCode_" & cboAssessment.Text & cboPropType.Text & ".pdf")
                RunReport(m_TypeOfReport, colClients(cboClient.Text), colLocations(cboLocation.Text), colAssessments(cboAssessment.Text),
                    JurisdictionList, AppData.TaxYear, IIf(cboPropType.Text = "BPP", enumTable.enumLocationBPP, enumTable.enumLocationRE),
                    0, m_Parm1, m_SendToPrinter, sPDFFileName, m_ExportFolder, 0, False, enumContactTypes.enumTax, m_BarCodeType, False, New DataTable)
            ElseIf m_TypeOfReport = enumReport.enumTaxBill Then
                sPDFFileName = CleanFileName("TaxBillReport_" & cboAssessment.Text & cboPropType.Text & ".pdf")
                RunReport(m_TypeOfReport, colClients(cboClient.Text), colLocations(cboLocation.Text), colAssessments(cboAssessment.Text),
                    JurisdictionList, AppData.TaxYear, IIf(cboPropType.Text = "BPP", enumTable.enumLocationBPP, enumTable.enumLocationRE),
                    0, m_Parm1, m_SendToPrinter, sPDFFileName, m_ExportFolder)
            ElseIf m_TypeOfImport = enumTable.enumTaxBillsBPP Then
                Dim sError As String = ""
                If ImportTaxBill(colClients(cboClient.Text), colLocations(cboLocation.Text), colAssessments(cboAssessment.Text),
                        colCollectors(cboCollector.Text),
                        IIf(cboPropType.Text = "BPP", enumTable.enumLocationBPP, enumTable.enumLocationRE), AppData.TaxYear, AppData.UserId, sError) Then
                    MsgBox("Tax bill imported")
                Else
                    If sError <> "" Then MsgBox("Error importing tax bill:  " & sError)
                End If
            ElseIf m_TypeOfReport = enumReport.enumFreeportForm Or m_TypeOfReport = enumReport.enumRenditionForm Or
                    m_TypeOfReport = enumReport.enumRenditionExtensionForm Or
                    m_TypeOfReport = enumReport.enumAppointmentOfAgentForm Or
                    m_TypeOfReport = enumReport.enumCertificateOfMailing Or
                    m_TypeOfReport = enumReport.enumAffidavitOfEvidence Or
                    m_TypeOfReport = enumReport.enumCorrection Or
                    m_TypeOfReport = enumReport.enumValueProtestForm Then
                Dim sError As String = "", enumPropType As enumTable
                If m_TypeOfReport = enumReport.enumFreeportForm Or m_TypeOfReport = enumReport.enumRenditionForm Or
                        m_TypeOfReport = enumReport.enumRenditionExtensionForm Then
                    enumPropType = enumTable.enumLocationBPP
                Else
                    enumPropType = IIf(cboPropType.Text = "BPP", enumTable.enumLocationBPP, enumTable.enumLocationRE)
                End If
                If m_TypeOfReport = enumReport.enumAppointmentOfAgentForm Then
                    Dim sEffectiveDate As String = ""   ' Trim(InputBox("Enter effective date"))
                    'If IsDate(sEffectiveDate) Then
                    '    sEffectiveDate = Format(CDate(sEffectiveDate), csDate)
                    'Else
                    '    sEffectiveDate = ""
                    'End If
                    If Not OpenForm(enumReport.enumAppointmentOfAgentForm, colClients(cboClient.Text),
                                    colAssessors(cboAssessor.Text), Microsoft.VisualBasic.Right(cboAssessor.Text, 2), AppData.TaxYear, sEffectiveDate,
                                    m_SendToPrinter, m_ExportFolder, sError) Then
                        MsgBox(sError)
                    End If
                Else
                    OpenForm(m_TypeOfReport, colClients(cboClient.Text), colLocations(cboLocation.Text), colAssessments(cboAssessment.Text),
                        AppData.TaxYear, 0, "", "",
                        m_SendToPrinter, enumPropType, m_ExportFolder,
                        "", False, False, sError)
                End If


            ElseIf m_TypeOfAdd = enumTable.enumStateFactorCode Then
                Dim sError As String = ""
                Dim sCode As String = Trim(InputBox("Enter state factor code"))
                If sCode = "" Then Exit Sub
                If Not AddStateFactorCode(cboStateCd.Text, sCode, "", "", sError) Then MsgBox("Error adding code:  " & sError)
            ElseIf m_TypeOfAdd = enumTable.enumFactorCodeXRef Then
                If Not AddFactorCodeXRef(cboStateCd.Text, cboStateFactorCode.Text, colFactorEntities(cboFactorEntity.Text),
                    AppData.TaxYear, cboFactorCode.Text, cboStateFactorCode.Text) Then
                End If
            ElseIf m_TypeOfAdd = enumTable.enumAsset Then
                AddAsset(colClients(cboClient.Text), colLocations(cboLocation.Text), colAssessments(cboAssessment.Text), AppData.TaxYear)
            ElseIf m_TypeOfAdd = enumTable.enumJurisdiction Then
                Dim sError As String = ""
                If Not AddAssessmentJurisdiction(m_ClientId, m_LocationId, m_AssessmentId,
                    colJurisdictions(cboJurisdiction.Text), m_PropType, AppData.TaxYear, sError) Then _
                    MsgBox("Error adding jurisdiction:  " & sError)
                Me.Close()
            ElseIf m_TypeOfImport = enumTable.enumClientForms Then
                Dim sError As String = ""
                Dim sFormName As String = Trim(InputBox("Enter form name (i.e. 50-132)"))
                If sFormName = "" Then Exit Sub
                Dim sFormDescription As String = Trim(InputBox("Enter description"))
                If ImportClientForm(colClients(cboClient.Text), AppData.TaxYear,
                        colStateNames(cboStateCd.Text), sFormName, sFormDescription, sError) Then
                    MsgBox("Form imported successfully")
                Else
                    MsgBox("Error importing form:  " & sError)
                End If
            ElseIf m_TypeOfAdd = enumTable.enumTask Then
                'assigntask(colTasks(cboTask.Text))
            ElseIf m_TypeOfReport = enumReport.enumFixedAssetReconByGLCode Or m_TypeOfReport = enumReport.enumFixedAssetReconByDeprCode Or
                    m_TypeOfReport = enumReport.enumValueComparison Then
                sPDFFileName = CleanFileName(IIf(m_TypeOfReport = enumReport.enumValueComparison, "RenditionValueCompare_", "FixedAssetReconciliation_") & Trim(cboClient.Text) & ".pdf")
                Dim lLocationId As Long = 0, lAssessmentId As Long = 0, lBusinessUnitId As Long = 0, lAssessorId As Long = 0, eproptype As enumTable = enumTable.enumUnknown, statecd As String = ""
                If Not colLocations Is Nothing Then
                    If colLocations.Contains(cboLocation.Text) Then lLocationId = colLocations(cboLocation.Text)
                End If
                If Not colAssessments Is Nothing Then
                    If colAssessments.Contains(cboAssessment.Text) Then lAssessmentId = colAssessments(cboAssessment.Text)
                End If
                If Not colBusinessUnits Is Nothing Then
                    If colBusinessUnits.Contains(cboBusinessUnit.Text) Then lBusinessUnitId = colBusinessUnits(cboBusinessUnit.Text)
                End If
                If Not colAssessors Is Nothing Then
                    If colAssessors.Contains(cboAssessor.Text) Then lAssessorId = colAssessors(cboAssessor.Text)
                End If
                If Not colStateCodes Is Nothing Then
                    If Not cboStateCd Is Nothing Then
                        If colStateCodes.Contains(cboStateCd.Text) Then statecd = colStateCodes(cboStateCd.Text)
                    End If
                End If
                If m_TypeOfReport = enumReport.enumValueComparison Then
                    If Not cboPropType Is Nothing Then
                        If cboPropType.Text.ToUpper = "BPP" Then
                            eproptype = enumTable.enumLocationBPP
                        ElseIf cboPropType.Text.ToUpper = "REAL" Then
                            eproptype = enumTable.enumLocationRE
                        Else
                            eproptype = enumTable.enumUnknown
                        End If
                    End If
                    If eproptype = enumTable.enumUnknown Then Throw New Exception("Must select a property type")
                End If

                If m_TypeOfReport = enumReport.enumValueComparison Then
                    Dim clientid As Long = 0
                    'need to rewrite report to show clients in a column, not in title.  grouping also affected
                    'If cboClient.Text <> "" Then clientid = colClients(cboClient.Text)
                    clientid = colClients(cboClient.Text)
                    RunReport(m_TypeOfReport, clientid, AppData.TaxYear, eproptype,
                        lAssessorId, lBusinessUnitId, statecd, m_SendToPrinter, sPDFFileName, m_ExportFolder)
                Else
                    RunReport(m_TypeOfReport, colClients(cboClient.Text), lLocationId, lAssessmentId, New List(Of Long), AppData.TaxYear, enumTable.enumLocationBPP, 0, 0, m_SendToPrinter, sPDFFileName, m_ExportFolder)
                End If
            ElseIf m_TypeOfReport = enumReport.enumAssessorCover Then
                sPDFFileName = CleanFileName("AssessorCover" & Trim(cboAssessor.Text) & ".pdf")
                RunReport(m_TypeOfReport, 0, 0, 0, JurisdictionList, AppData.TaxYear, enumTable.enumAssessmentBPP,
                colAssessors(cboAssessor.Text),
                0, m_SendToPrinter, sPDFFileName, m_ExportFolder)
            ElseIf m_TypeOfReport = enumReport.enumTaxSavings Or m_TypeOfReport = enumReport.enumTaxAccrual Or m_TypeOfReport = enumReport.enumTaxAccrualSummary Then
                sPDFFileName = CleanFileName(IIf(m_TypeOfReport = enumReport.enumTaxSavings, "TaxSavings", "TaxAccrual") & "_" & Trim(cboClient.Text) & ".pdf")
                Dim ePropType As enumTable
                If cboPropType.Text = "BPP" Then
                    ePropType = enumTable.enumLocationBPP
                ElseIf cboPropType.Text = "Real" Then
                    ePropType = enumTable.enumLocationRE
                Else
                    ePropType = enumTable.enumUnknown
                End If
                'If m_TypeOfReport = enumReport.enumTaxAccrual Or m_TypeOfReport = enumReport.enumTaxAccrualSummary Then
                'RunReport(m_TypeOfReport, colClients(cboClient.Text), AppData.TaxYear, ePropType, colBusinessUnits(cboBusinessUnit.Text),
                '    m_SendToPrinter, sPDFFileName, m_ExportFolder)
                RunReport(m_TypeOfReport, colClients(cboClient.Text), 0, 0, New List(Of Long), AppData.TaxYear, ePropType, 0,
                        0, m_SendToPrinter, sPDFFileName, m_ExportFolder, 0, False,
                        enumContactTypes.enumTax, enumBarCodeTypes.Audit, False, New DataTable, False, AppData.IncludeInactive, colBusinessUnits(cboBusinessUnit.Text),
                        colStateCodes(cboStateCd.Text))
                'ElseIf m_TypeOfReport = enumReport.enumTaxSavings Then
                '    RunReport(m_TypeOfReport, colClients(cboClient.Text), 0, 0, New List(Of Long), AppData.TaxYear, ePropType, 0,
                '        0, m_SendToPrinter, sPDFFileName, m_ExportFolder, 0, False,
                '        enumContactTypes.enumTax, enumBarCodeTypes.Audit, False, New DataTable, False, AppData.IncludeInactive, colBusinessUnits(cboBusinessUnit.Text),
                '        colStateCodes(cboStateCd.Text))
                'End If
            ElseIf m_TypeOfReport = enumReport.enumClientEnvelope Then
                sPDFFileName = CleanFileName("ClientEnvelope" & Trim(cboClient.Text) & ".pdf")
                RunReport(m_TypeOfReport, colClients(cboClient.Text), 0, 0,
                    JurisdictionList, AppData.TaxYear, enumTable.enumLocationBPP, 0, 0, m_SendToPrinter, sPDFFileName,
                    m_ExportFolder, 0, False, m_ContactType, enumBarCodeTypes.Audit, False, New DataTable)
            End If

        Catch ex As Exception
            If ex.Message = "Argument 'Index' is not a valid value." Then
                MsgBox("Need more information")
            Else
                MsgBox("Error in selection:  " & ex.Message)
            End If
        End Try

    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub cboLocation_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
            cboLocation.SelectedIndexChanged
        If bActivated And Not bRefreshing Then
            If Not cboCollector Is Nothing Then
                cboCollector.Text = ""
                cboCollector.Items.Clear()
            End If

            If m_TypeOfReport = enumReport.enumAssetDetail Or m_TypeOfReport = enumReport.enumAssetSummary Or
                    m_TypeOfReport = enumReport.enumAssetDetailCost Or m_TypeOfReport = enumReport.enumAssetDetailExempt Or
                    m_TypeOfReport = enumReport.enumAssetDetailNon Or
                    m_TypeOfReport = enumReport.enumAssetDetailLeasedProperty Or
                    m_TypeOfReport = enumReport.enumAssetDetailLeaseholdImprovements Or
                    m_TypeOfReport = enumReport.enumAssetDetailLeasesAll Or m_TypeOfReport = enumReport.enumLeaseSummary Or
                    m_TypeOfReport = enumReport.enumFreeportForm Or m_TypeOfReport = enumReport.enumRenditionForm Or
                    m_TypeOfReport = enumReport.enumRenditionExtensionForm Or
                    m_TypeOfReport = enumReport.enumCertificateOfMailing Or
                    m_TypeOfReport = enumReport.enumAffidavitOfEvidence Or
                    m_TypeOfReport = enumReport.enumCorrection Or
                    m_TypeOfReport = enumReport.enumValueProtestForm Or (m_TypeOfImport = enumTable.enumAsset And m_ImportAssetsForClient = False) Or
                    m_TypeOfAdd = enumTable.enumAsset Or m_TypeOfReport = enumReport.enumTaxBill Or m_TypeOfImport = enumTable.enumTaxBillsBPP Or
                    m_TypeOfReport = enumReport.enumFixedAssetReconByGLCode Or m_TypeOfReport = enumReport.enumFixedAssetReconByDeprCode Or
                    m_TypeOfReport = enumReport.enumBarCode Then
                LoadAssessments(colClients(cboClient.SelectedItem.ToString), colLocations(cboLocation.SelectedItem.ToString))
            End If
        End If
    End Sub

    Private Sub cboStateCd_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
            cboStateCd.SelectedIndexChanged
        If bActivated And Not bRefreshing Then
            If m_TypeOfAdd = enumTable.enumFactorCodeXRef Then
                LoadFactorEntities(cboStateCd.Text)
            End If
        End If

    End Sub
    Private Function LoadFactorEntities(ByVal sStateCd As String) As Boolean
        Dim sSQL As String
        Try
            bRefreshing = True
            cboFactorEntity.Items.Clear()
            cboFactorEntity.Text = ""
            sSQL = "SELECT FactorEntityId,RTRIM(Name)" & _
                " FROM FactorEntities WHERE StateCd = " & QuoStr(sStateCd) & _
                " ORDER BY Name"
            LoadComboBox(sSQL, cboFactorEntity, colFactorEntities)
            bRefreshing = False
            Return True
        Catch ex As Exception
            bRefreshing = False
            MsgBox("Error loading entities:  " & ex.Message)
            Return False
        End Try

    End Function

    Private Sub cboPropType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
            cboPropType.SelectedIndexChanged
        If bActivated And Not bRefreshing Then
            If Not cboLocation Is Nothing Then
                cboLocation.Text = ""
                cboLocation.Items.Clear()
            End If
            If Not cboAssessment Is Nothing Then
                cboAssessment.Text = ""
                cboAssessment.Items.Clear()
            End If
            If Not cboCollector Is Nothing Then
                cboCollector.Text = ""
                cboCollector.Items.Clear()
            End If

            If m_TypeOfReport = enumReport.enumTaxBill Or
                    m_TypeOfReport = enumReport.enumValueProtestForm Or
                    m_TypeOfReport = enumReport.enumCertificateOfMailing Or
                    m_TypeOfReport = enumReport.enumAffidavitOfEvidence Or
                    m_TypeOfReport = enumReport.enumCorrection Or
                    m_TypeOfReport = enumReport.enumFixedAssetReconByGLCode Or m_TypeOfReport = enumReport.enumFixedAssetReconByDeprCode Or
                    m_TypeOfImport = enumTable.enumTaxBillsBPP Or m_TypeOfReport = enumReport.enumBarCode Then
                LoadLocations(colClients(cboClient.SelectedItem.ToString))
            End If
        End If
    End Sub

    Private Sub cboAssessment_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAssessment.SelectedIndexChanged
        If bActivated And Not bRefreshing Then
            If Not cboCollector Is Nothing Then
                cboCollector.Text = ""
                cboCollector.Items.Clear()
            End If

            If m_TypeOfImport = enumTable.enumTaxBillsBPP Then
                LoadCollectors(colClients(cboClient.SelectedItem.ToString), colLocations(cboLocation.SelectedItem.ToString), _
                    colAssessments(cboAssessment.SelectedItem.ToString))
            End If
        End If

    End Sub


    Private Function LoadCollectors(ByVal lClientId As Long, ByVal lLocationId As Long, ByVal lAssessmentId As Long) As Boolean
        Dim sSQL As String, sType As String

        Try

            bRefreshing = True
            colCollectors = New Collection
            cboCollector.Items.Clear()
            cboCollector.Text = ""

            If m_TypeOfImport = enumTable.enumTaxBillsBPP Then
                If cboPropType.Text = "Real" Then
                    sType = "RE"
                Else
                    sType = "BPP"
                End If
            End If

            sSQL = "SELECT c.CollectorId, RTRIM(ISNULL(c.Name,'')) + ', ' + RTRIM(ISNULL(c.StateCd,''))" &
                " FROM AssessmentDetail" & sType & " AS a INNER JOIN" &
                " Jurisdictions AS j ON a.JurisdictionId = j.JurisdictionId AND a.TaxYear = j.TaxYear INNER JOIN" &
                " Collectors AS c ON j.CollectorId = c.CollectorId AND j.TaxYear = c.TaxYear" &
                " WHERE a.ClientId = " & lClientId & " AND a.LocationId = " & lLocationId &
                " AND a.AssessmentId = " & lAssessmentId & " AND a.TaxYear = " & AppData.TaxYear &
                " GROUP BY c.CollectorId, c.Name, c.StateCd"
            LoadComboBox(sSQL, cboCollector, colCollectors)

            bRefreshing = False
            Return True
        Catch ex As Exception
            bRefreshing = False
            MsgBox("Error loading assessments:  " & ex.Message)
            Return False
        End Try
    End Function

    Private Sub CreateBusinessUnitControls()
        lblBusinessUnit = New Label
        With lblBusinessUnit
            .Text = "Business Unit"
            .Width = 75
            .TextAlign = ContentAlignment.MiddleRight
            .Location = New Point(10, 75)
        End With
        Me.Controls.Add(lblBusinessUnit)

        cboBusinessUnit = New ComboBox
        With cboBusinessUnit
            .Location = New Point(100, 75)
            .Width = 400
        End With
        Me.Controls.Add(cboBusinessUnit)
    End Sub
    Private Sub CreateStateCdDropDown(sText As String, iHeight As Integer)
        lblState = New Label
        With lblState
            .Text = sText
            .Width = 75
            .TextAlign = ContentAlignment.MiddleRight
            .Location = New Point(10, iHeight)
        End With
        Me.Controls.Add(lblState)

        cboStateCd = New ComboBox
        With cboStateCd
            colStateCodes = New Collection
            LoadComboBox("select '' AS StateCd, '' AS StateName UNION SELECT StateCd, StateName from States", cboStateCd, colStateCodes)
            .Location = New Point(100, iHeight)
            .Width = 400
        End With
        Me.Controls.Add(cboStateCd)
    End Sub
    Private Sub LoadBusinessUnits(clientid As Long)
        Try
            colBusinessUnits = New Collection
            cboBusinessUnit.Items.Clear()
            cboBusinessUnit.Items.Add("")
            colBusinessUnits.Add(0, "")
            LoadComboBox("SELECT BusinessUnitId, Name FROM BusinessUnits" &
                        " WHERE ClientId = " & clientid & " ORDER BY Name",
                        cboBusinessUnit, colBusinessUnits)
        Catch ex As Exception
            bRefreshing = False
            MsgBox("Error loading business unit dropdowns:  " & ex.Message)
        End Try
    End Sub

End Class