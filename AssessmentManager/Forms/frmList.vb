Public Class frmList
    Private m_ListType As enumListType
    Private m_QueryType As UserQueryType
    Private m_TaxYear As Integer
    Private m_ClientId As Long
    Private m_LocationId As Long
    Private m_AssessmentId As Long
    Private m_FactoringEntityId As Long
    Private m_FactorCode As String
    Private m_AdditionalText As String
    Private m_StateCd As String
    Private m_QueryId As Long

    Private dtList As DataTable
    Private iMouseClickColIndex As Integer = 0
    Private iMouseClickRowIndex As Integer = 0
    Private lFactorEntityId As Long = 0
    Private bClientOverride As Boolean = False
    Private bLoading As Boolean
    Private bContextTextBoxChanged As Boolean = False
    Private bContextTextBoxLoading As Boolean = False
    Private colClientID As Collection
    Private colECUParentAccounts As Collection
    Private colBusinessUnits As Collection
    Private colAgencies As Collection
    Private colTasks As Collection
    Private colEvents As Collection
    Private lLastGridRow As Long = 0
    Private bHasLoadedAlready As Boolean
    Private eAllocationPctType As enumAllocationPctType
    Private _FreezeLeaseInfoSettings As Boolean = True
    Private _LeaseTypeChanged As Boolean = False
    Private _LesseeNameChanged As Boolean = False
    Private _LesseeAddressChanged As Boolean = False
    Private _LesseeCityChanged As Boolean = False
    Private _LesseeStateCdChanged As Boolean = False
    Private _LesseeZipChanged As Boolean = False
    Private _LeaseTermChanged As Boolean = False
    Private _EquipmentMakeChanged As Boolean = False
    Private _EquipmentModelChanged As Boolean = False

    Private Enum enumProspectSetType
        SolicitType
        LeadFollowUpDate
        ClientCoordinatorName
        LeadMailDate
        LeadStatus
        SolicitSentDate
        LeadInfoSentFl
    End Enum

    Public Property ListType() As Integer
        Get
            Return m_ListType
        End Get
        Set(ByVal value As Integer)
            m_ListType = value
        End Set
    End Property
    Public Property QueryType() As Integer
        Get
            Return m_QueryType
        End Get
        Set(value As Integer)
            m_QueryType = value
        End Set
    End Property
    Public Property AdditionalText() As String
        Get
            Return m_AdditionalText
        End Get
        Set(ByVal value As String)
            m_AdditionalText = value
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
    Public Property TaxYear() As Integer
        Get
            Return m_TaxYear
        End Get
        Set(ByVal value As Integer)
            m_TaxYear = value
        End Set
    End Property
    Public Property ClientId() As Long
        Get
            Return m_ClientId
        End Get
        Set(ByVal value As Long)
            m_ClientId = value
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

    Public Property FactoringEntityId() As Long
        Get
            Return m_FactoringEntityId
        End Get
        Set(ByVal value As Long)
            m_FactoringEntityId = value
        End Set
    End Property

    Public Property FactorCode() As String
        Get
            Return m_FactorCode
        End Get
        Set(ByVal value As String)
            m_FactorCode = value
        End Set
    End Property
    Public Property QueryId() As Long
        Get
            Return m_QueryId
        End Get
        Set(ByVal value As Long)
            m_QueryId = value
        End Set
    End Property


    Private Function LoadList() As Boolean
        Dim bind As New BindingSource
        Dim sSQL As String = "", sText As String = ""
        Dim lRows As Long = 0
        Dim iWidths() As Integer, iCol As Integer = 0
        Dim bDividerSet As Boolean = False
        Dim sIndexFields As New List(Of String)
        Dim bReturn As Boolean = False
        Dim lWidth As Long = 0

        Try
            bLoading = True

            If m_ListType = enumListType.enumAssets Then
                LoadAssets()
                bLoading = False
                Return True
            ElseIf m_ListType = enumListType.enumQueryResults Then
                Dim sQueryName As String = ""
                Dim ASK As New List(Of AskFilters)
                ASK = BuildAskList(m_QueryId)
                BuildQuerySQL(m_QueryId, ASK, sIndexFields, sQueryName, 0, sSQL)
                sText = "User Query:  " & sQueryName
            ElseIf m_ListType = enumListType.enumQueryList Then
                sSQL = "SELECT QueryId, QueryName, ISNULL(Description,'') AS Description,QueryType," &
                    " 'Query Type' = " &
                    "    CASE QueryType WHEN 1 THEN 'Clients'" &
                    "        WHEN 2 THEN 'BPP Locations'" &
                    "        WHEN 4 THEN 'RE Locations'" &
                    "        WHEN 8 THEN 'BPP Assessments'" &
                    "        WHEN 16 THEN 'RE Assessments'" &
                    "        WHEN 32 THEN 'All Assessments'" &
                    "        WHEN 64 THEN 'BPP Taxes'" &
                    "        WHEN 128 THEN 'RE Taxes'" &
                    "        WHEN 256 THEN 'All Taxes'" &
                    "        WHEN 512 THEN 'Prospects'" &
                    "        WHEN 1024 THEN 'Prospect Locations'" &
                    "        WHEN 2048 THEN 'Prospect Values'" &
                    " END" &
                    " FROM UserQuery ORDER BY QueryName"
                sText = "User Queries"
            ElseIf m_ListType = enumListType.enumTaskAssignments Then
                sSQL = BuildTaskAssignmentQuery()
                sText = "Task Assignments"
            ElseIf m_ListType = enumListType.enumClient Then
                sSQL = "SELECT ClientId AS Clients_ClientId, Name AS Clients_Name, Address AS Clients_Address, City AS Clients_City," &
                    "StateCd AS Clients_StateCd, Zip AS Clients_Zip, Phone AS Clients_Phone,ISNULL(ClientCoordinatorName,'') AS Clients_ClientCoordinatorName," &
                    "ISNULL(BPPConsultantName,'') AS Clients_BPPConsultantName, ISNULL(REConsultantName,'') AS Clients_REConsultantName," &
                    "AofAExpireDate,RecordRetentionYears," &
                    "ContactTaxName,ContactTaxAddress,ContactTaxCity,ContactTaxStateCd,ContactTaxZip,ContactTaxPhone,ContactTaxFax," &
                    "ContactTaxEMail,ContactInvoiceName,ContactInvoiceAddress,ContactInvoiceCity,ContactInvoiceStateCd," &
                    "ContactInvoiceZip,ContactInvoicePhone,ContactInvoiceFax,ContactInvoiceEMail,ContactContractName," &
                    "ContactContractAddress,ContactContractCity,ContactContractStateCd,ContactContractZip,ContactContractPhone," &
                    "ContactContractFax,ContactContractEMail," &
                    "ContactMiscName,ContactMiscAddress,ContactMiscCity,ContactMiscStateCd,ContactMiscZip,ContactMiscPhone,ContactMiscFax," &
                    "ContactMiscEMail" &
                    " FROM Clients WHERE ISNULL(ProspectFl,0) = 0"
                If AppData.IncludeInactive = False Then sSQL = sSQL & " AND ISNULL(InactiveFl,0) = 0"

                sSQL = sSQL & " ORDER BY Name"
                sText = "Clients"
            ElseIf m_ListType = enumListType.enumProspect Then
                sSQL = "SELECT c1.ClientId AS Clients_ClientId, c1.Name, c1.DBA, c1.Address," &
                    "c1.City," &
                    "c1.StateCd, c1.Zip, c1.Phone," &
                    "c1.WebSite,c1.SolicitType, c1.SolicitSentDate, c1.LeadStatus, c1.LeadInfoSentFl, c1.LeadFollowUpDate, c1.LeadMailDate," &
                    "c1.ClientCoordinatorName," &
                    "c1.ContactTaxName,c1.ContactTaxAddress,c1.ContactTaxCity,c1.ContactTaxStateCd,c1.ContactTaxZip,c1.ContactTaxPhone,c1.ContactTaxFax," &
                    "c1.ContactTaxEMail," &
                    "c1.LeadCompetitorName,	CommentList = ISNULL(c1.Comment,'') + '  ' + substring((SELECT ( '  ' + convert(varchar,c2.AddDate,100) + '  ' + c2.Comment )" &
                    " FROM ClientComments c2 WHERE c1.clientid = c2.clientid ORDER BY c2.clientID, c2.AddDate DESC" &
                    " FOR XML PATH(''),type).value('.','varchar(max)'),3,1000)" &
                    " FROM Clients c1 WHERE ISNULL(c1.ProspectFl,0) = 1"
                If AppData.IncludeInactive = False Then sSQL = sSQL & " AND ISNULL(c1.InactiveFl,0) = 0"
                sSQL = sSQL & " GROUP BY c1.ClientId, c1.Name, c1.DBA, c1.Address," &
                    "c1.City," &
                    "c1.StateCd, c1.Zip, c1.Phone," &
                    "c1.WebSite,c1.SolicitType, c1.SolicitSentDate, c1.LeadStatus, c1.LeadInfoSentFl, c1.LeadFollowUpDate, c1.LeadMailDate," &
                    "c1.ClientCoordinatorName," &
                    "c1.ContactTaxName,c1.ContactTaxAddress,c1.ContactTaxCity,c1.ContactTaxStateCd,c1.ContactTaxZip,c1.ContactTaxPhone,c1.ContactTaxFax," &
                    "c1.ContactTaxEMail," &
                    "c1.LeadCompetitorName, c1.Comment"
                sSQL = sSQL & " ORDER BY c1.Name"
                sText = "Prospects"
            ElseIf m_ListType = enumListType.enumProspectLocations Then
                sSQL = "SELECT c.ClientId AS Clients_ClientId, l.LocationId AS ProspectLocations_LocationId," &
                    " c.Name, l.AssessorId, l.AcctNum," &
                    " l.Notes, l.SICCode, l.BusDesc, l.RenditionFilingStatus," &
                    " c.SolicitType, c.SolicitSentDate," &
                    " c.LeadStatus, c.LeadInfoSentFl, c.LeadFollowUpDate, c.LeadMailDate," &
                    " c.ClientCoordinatorName," &
                    " l.PropType, l.Address, l.City, l.StateCd, l.Zip, c.LeadCompetitorName, c.Phone," &
                    " a.Assessors_Name, a.Assessors_StateCd" &
                    " FROM ProspectLocations AS l LEFT OUTER JOIN" &
                    " (SELECT AssessorId, Name AS Assessors_Name, StateCd AS Assessors_StateCd" &
                    " FROM Assessors WHERE TaxYear = " & AppData.TaxYear & ") AS a" &
                    " ON l.AssessorId = a.AssessorId INNER JOIN" &
                    " Clients AS c ON l.ClientId = c.ClientId WHERE ISNULL(c.ProspectFl,0) = 1"
                If AppData.IncludeInactive = False Then sSQL = sSQL & " AND ISNULL(c.InactiveFl,0) = 0"
                sSQL = sSQL & " ORDER BY Name"
                sText = "Prospect Locations"
            ElseIf m_ListType = enumListType.enumProspectValues Then
                sSQL = BuildProspectValuesQuery(False)
                sText = "Prospect Values"
            ElseIf m_ListType = enumListType.enumProspectTotalValues Then
                sSQL = BuildProspectValuesQuery(True)
                sText = "Prospect Total Values"
            ElseIf m_ListType = enumListType.enumLocationBPP Then
                sSQL = "SELECT c.Name AS Clients_Name, l.ClientId, l.LocationId, l.TaxYear, l.Address, l.Name," &
                    "l.City, l.StateCd, l.Zip, l.ClientLocationId, l.LegalOwner, ISNULL(l.ConsultantName,c.BPPConsultantName) AS ConsultantName," &
                    " ISNULL(c.ClientCoordinatorName,'') AS ClientCoordinatorName" &
                    " FROM LocationsBPP l, Clients c WHERE l.ClientId = c.ClientId AND" &
                    " l.TaxYear = " & m_TaxYear & " AND ISNULL(c.ProspectFl,0) = 0"
                If AppData.IncludeInactive = False Then sSQL = sSQL & " AND ISNULL(c.InactiveFl,0) = 0 AND ISNULL(l.InactiveFl,0) = 0 "
                sSQL = sSQL & " ORDER BY c.Name, l.Address, l.City, l.StateCd"
                sText = "BPP Locations"
            ElseIf m_ListType = enumListType.enumLocationRE Then
                sSQL = "SELECT c.Name AS Clients_Name, l.ClientId, l.LocationId, l.TaxYear, l.Address, l.Name," &
                    "l.City, l.StateCd, l.Zip, l.ClientLocationId, l.LegalOwner, ISNULL(l.ConsultantName,c.REConsultantName) AS ConsultantName," &
                    " ISNULL(c.ClientCoordinatorName,'') AS ClientCoordinatorName" &
                    " FROM LocationsRE l, Clients c WHERE l.ClientId = c.ClientId AND" &
                    " l.TaxYear = " & m_TaxYear & " AND ISNULL(c.ProspectFl,0) = 0"
                If AppData.IncludeInactive = False Then sSQL = sSQL & " AND ISNULL(c.InactiveFl,0) = 0 AND ISNULL(l.InactiveFl,0) = 0 "
                sSQL = sSQL & " ORDER BY c.Name, l.Address, l.City, l.StateCd"
                sText = "Real Estate Locations"
            ElseIf m_ListType = enumListType.enumAssessmentBPP Then
                sSQL = "SELECT Clients_Name, ClientId, LocationId, TaxYear, Address, Name, City, StateCd, AcctNum,"
                sSQL = sSQL & " (SELECT ap.AcctNum FROM AssessmentsBPP ap WHERE ap.AssessmentId = tbl1.ParentAssessmentId AND ap.TaxYear = tbl1.TaxYear) AS ECUParentAcctNum,"
                sSQL = sSQL & " BusinessUnits_Name, BusinessUnitId,"
                sSQL = sSQL & " (SELECT agcy.AgencyName FROM Agencies agcy WHERE agcy.AgencyId = tbl1.AgencyId) AS AgencyName,"
                sSQL = sSQL &
                    " ClientLocationId, LegalOwner, AssessmentId, Assessors_Name, FactorEntities_Name," &
                    " BPPConsultantName AS ConsultantName, ClientCoordinatorName," &
                    " RenditionExtDeadlineDate, RenditionExtMailedDate, RenditionExtCMRRR," &
                    " RenditionDeadlineDate, RenditionMailedDate, RenditionCMRRR, FreeportProtestDeadlineDate, FreeportProtestMailedDate, FreeportProtestCMRRR," &
                    " FreeportProtestStatus, FreeportProtestHearingDate, ValueProtestDeadlineDate, ValueProtestMailedDate, ValueProtestCMRRR, ValueProtestStatus, ValueProtestHearingDate," &
                    " OtherProtest1, OtherProtest1DeadlineDate, OtherProtest1MailedDate, OtherProtest1CMRRR," &
                    " OtherProtest1Status, OtherProtest1HearingDate, AssessorId, FactorEntityId1, FactorEntityId2," &
                    " FactorEntityId3, FactorEntityId4, FactorEntityId5, CurrentFinalValue, PreviousFinalValue FROM ("
                sSQL = sSQL & "SELECT c.Name AS Clients_Name, l.ClientId, l.LocationId, l.TaxYear, l.Address, l.Name, l.City," &
                    " l.StateCd, a.AcctNum, a.ParentAssessmentId, bu.Name AS BusinessUnits_Name, a.BusinessUnitId, ISNULL(a.AgencyId,c.AgencyId) AS AgencyId,"
                sSQL = sSQL &
                    " l.ClientLocationId, l.LegalOwner, a.AssessmentId, asr.Name AS Assessors_Name, fe.Name AS FactorEntities_Name," &
                    " a.RenditionExtDeadlineDate, a.RenditionExtMailedDate, a.RenditionExtCMRRR," &
                    " ISNULL(a.RenditionDeadlineDate, asr.RenditionDueDate) AS RenditionDeadlineDate, a.RenditionMailedDate," &
                    " a.RenditionCMRRR, a.FreeportProtestDeadlineDate, a.FreeportProtestMailedDate, a.FreeportProtestCMRRR," &
                    " a.FreeportProtestStatus, a.FreeportProtestHearingDate," &
                    " ISNULL(a.ValueProtestDeadlineDate,asr.BPPProtestDeadlineDate) AS ValueProtestDeadlineDate," &
                    " a.ValueProtestMailedDate, a.ValueProtestCMRRR, a.ValueProtestStatus, a.ValueProtestHearingDate," &
                    " a.OtherProtest1, a.OtherProtest1DeadlineDate, a.OtherProtest1MailedDate, a.OtherProtest1CMRRR," &
                    " a.OtherProtest1Status, a.OtherProtest1HearingDate, ISNULL(a.AssessorId, 0) AS AssessorId," &
                    " ISNULL(a.FactorEntityId1, 0) AS FactorEntityId1, ISNULL(a.FactorEntityId2, 0) AS FactorEntityId2," &
                    " ISNULL(a.FactorEntityId3, 0) AS FactorEntityId3, ISNULL(a.FactorEntityId4, 0) AS FactorEntityId4," &
                    " ISNULL(a.FactorEntityId5, 0) AS FactorEntityId5," &
                    " ISNULL(c.ClientCoordinatorName,'') AS ClientCoordinatorName," &
                    " ISNULL(l.ConsultantName,ISNULL(c.BPPConsultantName,'')) AS BPPConsultantName," &
                    " MAX(ad.FinalValue) AS CurrentFinalValue," &
                    " MAX(adprev.FinalValue) AS PreviousFinalValue" &
                    " FROM AssessmentDetailBPP AS adprev" &
                    " RIGHT OUTER JOIN AssessmentsBPP AS a" &
                    " ON adprev.ClientId = a.ClientId And adprev.LocationId = a.LocationId" &
                    " And adprev.AssessmentId = a.AssessmentId And adprev.TaxYear = " & m_TaxYear - 1 &
                    " LEFT OUTER JOIN AssessmentDetailBPP AS ad" &
                    " ON a.ClientId = ad.ClientId And a.LocationId = ad.LocationId And a.AssessmentId = ad.AssessmentId" &
                    " And a.TaxYear = ad.TaxYear" &
                    " RIGHT OUTER JOIN LocationsBPP AS l" &
                    " INNER JOIN Clients AS c ON l.ClientId = c.ClientId ON a.ClientId = l.ClientId" &
                    " And a.LocationId = l.LocationId And a.TaxYear = l.TaxYear" &
                    " LEFT OUTER JOIN Assessors AS asr" &
                    " ON a.AssessorId = asr.AssessorId And a.TaxYear = asr.TaxYear" &
                    " LEFT OUTER JOIN BusinessUnits bu ON a.ClientId = bu.ClientId And a.BusinessUnitId = bu.BusinessUnitId" &
                    " LEFT OUTER JOIN FactorEntities fe ON a.FactorEntityId1 = fe.FactorEntityId" &
                    " WHERE (ISNULL(c.ProspectFl, 0) = 0)"
                If AppData.IncludeInactive = False Then
                    sSQL = sSQL & " And ISNULL(c.InactiveFl,0) = 0 And ISNULL(l.InactiveFl,0) = 0 And ISNULL(a.InactiveFl,0) = 0"
                End If
                sSQL = sSQL &
                    " GROUP BY c.Name, l.ClientId, l.LocationId, l.TaxYear, l.Address, l.Name, l.City, l.StateCd," &
                    " a.AcctNum, a.ParentAssessmentId, bu.Name, a.BusinessUnitId, ISNULL(a.AgencyId,c.AgencyId), l.ClientLocationId," &
                    " l.LegalOwner, a.AssessmentId, asr.Name, fe.Name," &
                    " a.RenditionExtDeadlineDate, a.RenditionExtMailedDate, a.RenditionExtCMRRR," &
                    " ISNULL(a.RenditionDeadlineDate,asr.RenditionDueDate), a.RenditionMailedDate, a.RenditionCMRRR," &
                    " a.FreeportProtestDeadlineDate," &
                    " a.FreeportProtestMailedDate, a.FreeportProtestCMRRR, a.FreeportProtestStatus, a.FreeportProtestHearingDate," &
                    " ISNULL(a.ValueProtestDeadlineDate, asr.BPPProtestDeadlineDate), a.ValueProtestMailedDate," &
                    " a.ValueProtestCMRRR, a.ValueProtestStatus, a.ValueProtestHearingDate, a.OtherProtest1," &
                    " a.OtherProtest1DeadlineDate, a.OtherProtest1MailedDate, a.OtherProtest1CMRRR, a.OtherProtest1Status," &
                    " a.OtherProtest1HearingDate, ISNULL(a.AssessorId, 0), ISNULL(a.FactorEntityId1, 0)," &
                    " ISNULL(a.FactorEntityId2, 0), ISNULL(a.FactorEntityId3, 0)," &
                    " ISNULL(a.FactorEntityId4, 0), ISNULL(a.FactorEntityId5, 0)," &
                    " ISNULL(c.ClientCoordinatorName,''), ISNULL(l.ConsultantName,ISNULL(c.BPPConsultantName,''))" &
                    " HAVING(l.TaxYear = " & m_TaxYear & ")" &
                    " ) AS tbl1" &
                    " ORDER BY Clients_Name, Address, City, StateCd, AcctNum"
                sText = "BPP Assessments"
            ElseIf m_ListType = enumListType.enumRenditions Then
                sSQL = "SELECT c.Name AS Clients_Name, l.ClientId, l.LocationId, l.TaxYear, l.Address, l.Name," &
                    " l.City, l.StateCd, a.AcctNum,"
                sSQL = sSQL & " (SELECT ap.AcctNum FROM AssessmentsBPP ap WHERE ap.AssessmentId = a.ParentAssessmentId And ap.TaxYear = a.TaxYear) AS ECUParentAcctNum,"
                sSQL = sSQL & " bu.Name AS BusinessUnits_Name, a.BusinessUnitId,"
                sSQL = sSQL & " l.ClientLocationId, l.LegalOwner, a.AssessmentId, Assessors.Name AS Assessors_Name, fe.Name AS FactorEntities_Name," &
                    " ISNULL(l.ConsultantName,ISNULL(c.BPPConsultantName,'')) AS ConsultantName, c.ClientCoordinatorName," &
                    " a.RenditionExtDeadlineDate,a.RenditionExtMailedDate,a.RenditionExtCMRRR," &
                    " ISNULL(a.RenditionDeadlineDate,Assessors.RenditionDueDate) AS RenditionDeadlineDate," &
                    " RenditionMailedDate,a.RenditionCMRRR," &
                    " a.FreeportProtestDeadlineDate,a.FreeportProtestMailedDate,a.FreeportProtestCMRRR," &
                    " a.FreeportProtestStatus,a.FreeportProtestHearingDate," &
                    " ISNULL(a.ValueProtestDeadlineDate,Assessors.BPPProtestDeadlineDate) AS ValueProtestDeadlineDate," &
                    " a.ValueProtestMailedDate,a.ValueProtestCMRRR," &
                    " a.ValueProtestStatus,a.ValueProtestHearingDate," &
                    " a.OtherProtest1,a.OtherProtest1DeadlineDate,a.OtherProtest1MailedDate,a.OtherProtest1CMRRR," &
                    " a.OtherProtest1Status,a.OtherProtest1HearingDate," &
                    " ISNULL(a.AssessorId,0) AS AssessorId," &
                    " ISNULL(a.FactorEntityId1,0) AS FactorEntityId1, ISNULL(a.FactorEntityId2,0) AS FactorEntityId2," &
                    " ISNULL(a.FactorEntityId3,0) AS FactorEntityId3, ISNULL(a.FactorEntityId4,0) AS FactorEntityId4," &
                    " ISNULL(a.FactorEntityId5,0) AS FactorEntityId5"
                sSQL = sSQL & " FROM LocationsBPP AS l INNER JOIN" &
                    " Clients AS c ON l.ClientId = c.ClientId " &
                    " INNER JOIN AssessmentsBPP AS a ON l.ClientId = a.ClientId And l.LocationId = a.LocationId And" &
                    " l.TaxYear = a.TaxYear LEFT OUTER JOIN" &
                    " Assessors ON a.AssessorId = Assessors.AssessorId And a.TaxYear = Assessors.TaxYear" &
                    " LEFT OUTER JOIN BusinessUnits bu ON a.ClientId = bu.ClientId And a.BusinessUnitId = bu.BusinessUnitId" &
                    " LEFT OUTER JOIN FactorEntities fe ON a.FactorEntityId1 = fe.FactorEntityId" &
                    " WHERE l.TaxYear = " & m_TaxYear & " And ISNULL(c.ProspectFl,0) = 0"
                If AppData.IncludeInactive = False Then
                    sSQL = sSQL & " And ISNULL(c.InactiveFl,0) = 0 And ISNULL(l.InactiveFl,0) = 0 And ISNULL(a.InactiveFl,0) = 0"
                End If
                sSQL = sSQL & " ORDER BY Clients_Name, l.Address, l.City, l.StateCd, a.AcctNum"
                sText = "Renditions"
            ElseIf m_ListType = enumListType.enumAssessmentRE Then
                sSQL = "SELECT Clients_Name, ClientId, LocationId, TaxYear, Address, Name," &
                    " City, StateCd, AcctNum,"
                sSQL = sSQL & " (SELECT ap.AcctNum FROM AssessmentsRE ap WHERE ap.AssessmentId = tbl1.ParentAssessmentId And ap.TaxYear = tbl1.TaxYear) AS ECUParentAcctNum,"
                sSQL = sSQL & " BusinessUnits_Name, BusinessUnitId,"
                sSQL = sSQL & " (SELECT agcy.AgencyName FROM Agencies agcy WHERE agcy.AgencyId = tbl1.AgencyId) AS AgencyName,"
                sSQL = sSQL & " OccupiedStatus, ClientLocationId," &
                    " LegalOwner, AssessmentId, Assessors_Name, AssessorId," &
                    " REConsultantName AS ConsultantName, ClientCoordinatorName," &
                    " ValueProtestFl, ValueProtestDeadlineDate," &
                    " ValueProtestMailedDate, ValueProtestCMRRR," &
                    " ValueProtestHearingDate, ValueProtestStatus," &
                    " CurrentFinalValue, PreviousFinalValue FROM ("
                sSQL = sSQL & "SELECT c.Name AS Clients_Name, l.ClientId, l.LocationId, l.TaxYear, l.Address, l.Name," &
                    " l.City, l.StateCd, a.AcctNum, a.ParentAssessmentId, bu.Name AS BusinessUnits_Name, a.BusinessUnitId, ISNULL(a.AgencyId,c.AgencyId) AS AgencyId," &
                    " ISNULL(a.OccupiedStatus,'') AS OccupiedStatus,l.ClientLocationId," &
                    " l.LegalOwner, a.AssessmentId, asr.Name AS Assessors_Name, ISNULL(a.AssessorId, 0) AS AssessorId," &
                    " a.ValueProtestFl, ISNULL(a.ValueProtestDeadlineDate, asr.REProtestDeadlineDate) AS ValueProtestDeadlineDate," &
                    " a.ValueProtestMailedDate, ISNULL(a.ValueProtestCMRRR, '') AS ValueProtestCMRRR," &
                    " a.ValueProtestHearingDate, ISNULL(a.ValueProtestStatus, '') AS ValueProtestStatus," &
                    " ISNULL(c.ClientCoordinatorName,'') AS ClientCoordinatorName," &
                    " ISNULL(l.ConsultantName,ISNULL(c.REConsultantName,'')) AS REConsultantName," &
                    " MAX(ad.FinalValue) AS CurrentFinalValue, MAX(adprev.FinalValue) AS PreviousFinalValue" &
                    " FROM AssessmentDetailRE AS adprev" &
                    " RIGHT OUTER JOIN AssessmentsRE AS a" &
                    " ON adprev.ClientId = a.ClientId AND adprev.LocationId = a.LocationId" &
                    " AND adprev.AssessmentId = a.AssessmentId AND adprev.TaxYear = " & m_TaxYear - 1 &
                    " LEFT OUTER JOIN AssessmentDetailRE AS ad" &
                    " ON a.ClientId = ad.ClientId AND a.LocationId = ad.LocationId AND a.AssessmentId = ad.AssessmentId" &
                    " AND a.TaxYear = ad.TaxYear" &
                    " RIGHT OUTER JOIN LocationsRE AS l" &
                    " INNER JOIN Clients AS c" &
                    " ON l.ClientId = c.ClientId ON a.ClientId = l.ClientId AND a.LocationId = l.LocationId" &
                    " AND a.TaxYear = l.TaxYear" &
                    " LEFT OUTER JOIN Assessors AS asr ON a.AssessorId = asr.AssessorId AND a.TaxYear = asr.TaxYear" &
                    " LEFT OUTER JOIN BusinessUnits bu ON a.ClientId = bu.ClientId AND a.BusinessUnitId = bu.BusinessUnitId" &
                    " WHERE (ISNULL(c.ProspectFl, 0) = 0)"
                If AppData.IncludeInactive = False Then
                    sSQL = sSQL & " AND ISNULL(c.InactiveFl,0) = 0 AND ISNULL(l.InactiveFl,0) = 0 AND ISNULL(a.InactiveFl,0) = 0"
                End If
                sSQL = sSQL & " GROUP BY c.Name, l.ClientId, l.LocationId, l.TaxYear, l.Address, l.Name, l.City," &
                    " l.StateCd, a.AcctNum, a.ParentAssessmentId, bu.Name, a.BusinessUnitId, ISNULL(a.AgencyId,c.AgencyId)," &
                    " a.OccupiedStatus, l.ClientLocationId, l.LegalOwner, a.AssessmentId, asr.Name," &
                    " ISNULL(a.AssessorId, 0), ISNULL(a.ValueProtestDeadlineDate, asr.REProtestDeadlineDate)," &
                    " a.ValueProtestMailedDate, ISNULL(a.ValueProtestCMRRR, '')," &
                    " a.ValueProtestHearingDate, ISNULL(a.ValueProtestStatus, ''), a.ValueProtestFl," &
                    " ISNULL(c.ClientCoordinatorName,''), ISNULL(l.ConsultantName,ISNULL(c.REConsultantName,''))" &
                    " HAVING l.TaxYear = " & m_TaxYear &
                    " ) AS tbl1" &
                    " ORDER BY Clients_Name, Address, City, StateCd, AcctNum"
                sText = "Real Estate Valuations"
            ElseIf m_ListType = enumListType.enumAssessor Then
                sSQL = "select AssessorId, Name, Address1, Address2, City, StateCd, Zip,TaxYear, RenditionDueDate," &
                    " BPPNoticeDate, RENoticeDate, BPPProtestDeadlineDate, REProtestDeadlineDate, LienDate FROM Assessors" &
                    " WHERE TaxYear = " & m_TaxYear &
                    " ORDER BY Name"
                sText = "Assessors"
            ElseIf m_ListType = enumListType.enumClientFactors Then
                sSQL = "SELECT ClientId, Clients_Name, TaxYear," &
                " StateCd, FactoringEntityName, FactorEntityId" &
                " FROM ("
                Dim i As Integer = 0
                For i = 1 To 5
                    If i > 1 Then sSQL = sSQL & " UNION "
                    sSQL = sSQL &
                        " SELECT c.ClientId, c.Name AS Clients_Name, l.TaxYear," &
                        " l.StateCd, f.Name AS FactoringEntityName, f.FactorEntityId" &
                        " FROM  Clients AS c INNER JOIN" &
                        " LocationsBPP AS l ON c.ClientId = l.ClientId INNER JOIN" &
                        " AssessmentsBPP ON l.ClientId = AssessmentsBPP.ClientId" &
                        " AND l.LocationId = AssessmentsBPP.LocationId" &
                        " AND l.TaxYear = AssessmentsBPP.TaxYear INNER JOIN" &
                        " FactorEntities AS f" &
                        " ON AssessmentsBPP.FactorEntityId" & i & " = f.FactorEntityId" &
                        " WHERE l.TaxYear = " & m_TaxYear
                Next
                sSQL = sSQL & ") as dt" &
                    " GROUP BY dt.ClientId, dt.Clients_Name, dt.TaxYear, dt.StateCd," &
                    " dt.FactoringEntityName, dt.FactorEntityId" &
                    " ORDER BY dt.Clients_Name,dt.StateCd,dt.FactoringEntityName"
                sText = "Client Factoring Entities"
            ElseIf m_ListType = enumListType.enumClientGLCodeXRef Then
                sSQL = "SELECT cc.ClientId, cc.GLCode, cc.TaxYear," &
                    " cx.FactorEntityId, cx.FactorCode, fe.Description" &
                    " FROM ClientGLCodes AS cc left outer join" &
                    " (select ClientId,StateCd, FactorEntityId, FactorCode," &
                    " GLCode, TaxYear from" &
                    " ClientGLCodeXRef where ClientId = " & m_ClientId &
                    " and TaxYear = " & m_TaxYear & " and StateCd = " & QuoStr(m_StateCd) &
                    " and FactorEntityId = " & m_FactoringEntityId & ") as cx on" &
                    " cc.ClientId=cx.ClientId and cc.StateCd=cx.StateCd" &
                    " AND cc.GLCode = cx.GLCode And cc.TaxYear = cx.TaxYear" &
                    " left outer join (select FactorEntityId, FactorCode, TaxYear,Description" &
                    " from FactorEntityCodes where FactorEntityId = " & m_FactoringEntityId &
                    " and TaxYear = " & m_TaxYear & ") as fe" &
                    " on cx.FactorEntityId=fe.FactorEntityId and cx.FactorCode=fe.FactorCode" &
                    " and cx.TaxYear=fe.TaxYear" &
                    " where cc.ClientId = " & m_ClientId & " and cc.StateCd = " & QuoStr(m_StateCd) & " and cc.TaxYear = " & m_TaxYear &
                    " order by cc.GLCode"
                sText = "Client G/L Code Cross Reference:  " & m_AdditionalText
            ElseIf m_ListType = enumListType.enumCollector Then
                sSQL = "select CollectorId, Name, Payee, Address1, Address2, City, StateCd, PayeeStateCd, Zip," &
                    " DiscountDate, DiscountDate2, DiscountDate3, DiscountDate4," &
                    " BPPDueDate1, BPPDueDate2, REDueDate1, REDueDate2, DiscountFl, AddressCorrectFl, TaxYear FROM Collectors" &
                    " WHERE TaxYear = " & m_TaxYear &
                    " ORDER BY Name"
                sText = "Collectors"
            ElseIf m_ListType = enumListType.enumFactoringEntities Then
                sSQL = "select FactorEntityId, Name, StateCd from FactorEntities order by Name, StateCd"
                sText = "Factoring Entities"
                dgList.ReadOnly = False
            ElseIf m_ListType = enumListType.enumFactorCodes Then
                sSQL = "SELECT FactorEntityId, FactorCode, Description, InactiveFl, TaxYear FROM FactorEntityCodes WHERE FactorEntityId = " &
                    m_FactoringEntityId & " AND TaxYear = " & m_TaxYear & " ORDER BY FactorCode"
                sText = "Factoring Codes:  " & m_AdditionalText
                dgList.ReadOnly = False
            ElseIf m_ListType = enumListType.enumFactors Then
                sSQL = "select FactorEntityId,FactorCode,Age,Percentage from Factors where FactorEntityId = " & m_FactoringEntityId & " AND FactorCode = " & QuoStr(m_FactorCode) & " and TaxYear  = " & m_TaxYear
                sText = "Factors"
            ElseIf m_ListType = enumListType.enumJurisdiction Then
                sSQL = "SELECT j.JurisdictionId, j.Name, j.StateCd, j.Address1, j.Address2, j.City, j.Zip," &
                    " c.DiscountDate AS Collectors_DiscountDate, c.DiscountDate2 AS Collectors_DiscountDate2," &
                    " c.DiscountDate3 AS Collectors_DiscountDate3, c.DiscountDate4 AS Collectors_DiscountDate4," &
                    " j.TaxRate, j.TaxYear, c.CollectorId, c.Name AS Collectors_Name, c.Payee as Collectors_Payee," &
                    " c.BPPDueDate1, c.BPPDueDate2,c.REDueDate1,c.REDueDate2," &
                    " c.DiscountFl as Collectors_DiscountFl,c.AddressCorrectFl as Collectors_AddressCorrectFl" &
                    " FROM Collectors AS c RIGHT OUTER JOIN" &
                    " Jurisdictions AS j ON c.CollectorId = j.CollectorId AND c.TaxYear = j.TaxYear" &
                    " WHERE j.TaxYear = " & m_TaxYear & " ORDER BY j.Name"
                sText = "Jurisdictions"
            ElseIf m_ListType = enumListType.enumStateFactorCodes Then
                sSQL = "select StateCd, StateFactorCode, TaxYear, Name, Description from StateFactorCodes" &
                    " WHERE TaxYear = " & m_TaxYear & " order by StateCd, StateFactorCode"
                sText = "State Factor Codes"
            ElseIf m_ListType = enumListType.enumFactorCodeXRef Then
                sSQL = "SELECT fe.FactorEntityId, fe.Name AS FactoringEntityName,fe.StateCd," &
                    " fec.FactorCode AS EntityFactorCode, fec.TaxYear, " &
                    " fcx.StateFactorCode, sfc.Name AS StateFactorName" &
                    " FROM StateFactorCodes AS sfc RIGHT OUTER JOIN" &
                    " FactorCodeXRef AS fcx ON sfc.StateCd = fcx.StateCd" &
                    " AND sfc.StateFactorCode = fcx.StateFactorCode" &
                    " AND sfc.TaxYear = fcx.TaxYear RIGHT OUTER JOIN" &
                    " FactorEntities AS fe INNER JOIN" &
                    " FactorEntityCodes AS fec ON fe.FactorEntityId = fec.FactorEntityId" &
                    " ON fcx.FactorEntityId = fec.FactorEntityId" &
                    " AND fcx.EntityFactorCode = fec.FactorCode And fcx.TaxYear = fec.TaxYear" &
                    " WHERE fec.TaxYear = " & m_TaxYear &
                    " ORDER BY fe.Name, fe.StateCd, fec.FactorCode"
                sText = "Factor cross reference"
            ElseIf m_ListType = enumListType.enumRenditionDueDates Then
                sSQL = "SELECT c.ClientId, lbpp.LocationId, ISNULL(abpp.AssessmentId,0) AS AssessmentId," &
                    " ISNULL(abpp.AssessorId,0) AS AssessorId, c.Name AS Clients_Name," &
                    " lbpp.Address, lbpp.City, lbpp.StateCd, abpp.AcctNum,"
                sSQL = sSQL & " bu.Name AS BusinessUnits_Name, abpp.BusinessUnitId,"
                sSQL = sSQL &
                    " lbpp.ClientLocationId, lbpp.LegalOwner, a.Name As Assessor_Name, " &
                    " lbpp.TaxYear, a.RenditionDueDate, a.RenditionExtDate, " &
                    " abpp.RenditionMailedDate, abpp.RenditionCMRRR, ISNULL(lbpp.ConsultantName, ISNULL(c.BPPConsultantName,'')) As ConsultantName, " &
                    " c.ClientCoordinatorName," &
                    " c.AddDate As Client_AddDate, lbpp.AddDate As Location_AddDate, abpp.AddDate As Assessment_AddDate" &
                    " FROM Clients As c INNER JOIN" &
                    " LocationsBPP As lbpp On c.ClientId = lbpp.ClientId LEFT OUTER JOIN" &
                    " AssessmentsBPP As abpp On lbpp.ClientId = abpp.ClientId And lbpp.LocationId = abpp.LocationId" &
                    " And lbpp.TaxYear = abpp.TaxYear LEFT OUTER JOIN" &
                    " Assessors As a On abpp.AssessorId = a.AssessorId And abpp.TaxYear = a.TaxYear" &
                    " LEFT OUTER JOIN BusinessUnits bu ON abpp.ClientId = bu.ClientId AND abpp.BusinessUnitId = bu.BusinessUnitId" &
                    " WHERE lbpp.TaxYear = " & m_TaxYear & " And ISNULL(c.ProspectFl, 0) = 0"
                If AppData.IncludeInactive = False Then
                    sSQL = sSQL & " And ISNULL(c.InactiveFl,0) = 0 And ISNULL(lbpp.InactiveFl,0) = 0  And ISNULL(abpp.InactiveFl,0) = 0"
                End If
                sSQL = sSQL & " ORDER BY ISNULL(lbpp.ConsultantName,ISNULL(c.BPPConsultantName,'')), ISNULL(a.RenditionExtDate,a.RenditionDueDate), lbpp.StateCd, a.Name, lbpp.Address"
                sText = "Rendition Due Dates"
            ElseIf m_ListType = enumListType.enumAssessmentBPPTaxBills Then
                sSQL = BuildTaxBillQuery(0, 0, 0, New List(Of Long), m_TaxYear, enumTable.enumLocationBPP, False, True, False, False, False, 0)
                sText = "BPP Tax Bills"
            ElseIf m_ListType = enumListType.enumAssessmentRETaxBills Then
                sSQL = BuildTaxBillQuery(0, 0, 0, New List(Of Long), m_TaxYear, enumTable.enumLocationRE, False, True, False, False, False, 0)
                sText = "Real Estate Tax Bills"
            ElseIf m_ListType = enumListType.enumAssessmentRETotalTaxBills Then
                sSQL = BuildTaxBillQuery(0, 0, 0, New List(Of Long), m_TaxYear, enumTable.enumLocationRE, False, False, True, False, False, 0)
                sText = "Real Estate Tax Bill Totals"
            ElseIf m_ListType = enumListType.enumAssessmentBPPTotalTaxBills Then
                sSQL = BuildTaxBillQuery(0, 0, 0, New List(Of Long), m_TaxYear, enumTable.enumLocationBPP, False, False, True, False, False, 0)
                sText = "BPP Tax Bill Totals"
            ElseIf m_ListType = enumListType.enumSavings Then
                sSQL = BuildTaxBillQuery(0, 0, 0, New List(Of Long), m_TaxYear, enumTable.enumLocationBPP, False, False, False, False, True, 0)
                sSQL = sSQL & " UNION "
                sSQL = sSQL & BuildTaxBillQuery(0, 0, 0, New List(Of Long), m_TaxYear, enumTable.enumLocationRE, False, False, False, False, True, 0)
                sSQL = sSQL & " ORDER BY Clients_Name, Locations_Address, Locations_City, Locations_StateCd, AcctNum, Jurisdictions_Name"
                sText = "Tax Savings"
            ElseIf m_ListType = enumListType.enumTaskMasterList Then
                sSQL = "SELECT TaskId, Name, Description FROM TaskMasterList ORDER BY Name"
                sText = "Task Master List"
            ElseIf m_ListType = enumListType.enumFixedAssetReconciliation Then
                sSQL = BuildAssetReconciliationQuery(m_ClientId, 0, 0, m_TaxYear, False, "")
                sText = "Fixed Asset Reconciliation"
            End If

            If m_ListType = enumListType.enumQueryResults Then
                If AppData.UserId.Contains("STIGLER") Then
                    Clipboard.SetText(sSQL)
                End If
            End If
            lRows = GetData(sSQL, dtList)

            If m_ListType = enumListType.enumProspectValues And m_ClientId > 0 Then
                If dtList.Rows.Count > 0 Then
                    sText = "Prospect Values  " & dtList.Rows(0)("Name")
                End If
            End If

            bind.DataSource = dtList
            dgList.DataSource = bind

            ReDim iWidths(dtList.Columns.Count - 1)
            'set default column widths to size of column name
            For iCol = 0 To UBound(iWidths)
                'If m_ListType <> enumListType.enumQueryResults Then
                iWidths(iCol) = Len(dtList.Columns.Item(iCol).ColumnName) * 2
                'End If
            Next

            'find maximum size for each column
            'For Each row In dtList.Rows
            '    For iCol = 0 To UBound(iWidths)
            '        If Not IsDBNull(row(iCol)) Then
            '            If Len(row(iCol)) > iWidths(iCol) Then iWidths(iCol) = Len(row(iCol))
            '        End If
            '    Next
            'Next

            If dgList.Rows.Count > 0 Then
                If dgList.Rows.Count > lLastGridRow Then
                    bind.Position = lLastGridRow
                Else
                    bind.Position = dgList.Rows.Count - 1
                End If
            End If


            For Each column As DataGridViewColumn In dgList.Columns
                column.Visible = Not IsHiddenColumn(column.Name)
                If m_ListType = enumListType.enumQueryResults Then
                    For Each s As String In sIndexFields
                        If column.Name = s Then column.Visible = False
                    Next
                End If
                If IsIndexField(column.Name) Or column.Name = "TaxYear" Or column.Name = "QueryType" Then
                    column.Visible = False
                End If
                If m_ListType = enumListType.enumFactorCodes Then
                    Select Case column.Name
                        Case "Description", "InactiveFl"
                            column.ReadOnly = False
                        Case Else
                            column.ReadOnly = True
                    End Select
                ElseIf m_ListType = enumListType.enumFactoringEntities Then
                    If column.Name = "StateCd" Or column.Name = "Name" Then
                        column.ReadOnly = False
                    Else
                        column.ReadOnly = True
                    End If
                End If
                If column.Visible Then
                    If Not bHasLoadedAlready Then
                        column.Width = GetColumnWidth(m_ListType, m_QueryId, column.Name)
                    End If
                End If
            Next

            LoadDropDowns(dtList, sIndexFields)
            cmdApply.Enabled = True
            cmdExport.Enabled = True

            Me.Text = m_TaxYear & " " & "List  " & sText

            If lRows = 0 Then
                txtRowCount.Text = "No records found"
                dgList.Enabled = False
            ElseIf lRows = 1 Then
                dgList.Enabled = True
                txtRowCount.Text = "1 record found"
            Else
                dgList.Enabled = True
                txtRowCount.Text = Format(lRows, csInt) & " records found"
            End If

            bHasLoadedAlready = True
            bLoading = False
            Return True
        Catch ex As Exception
            bLoading = False
            MsgBox("Error loading list  " & ex.Message)
            Return False
        End Try

    End Function

    Private Function ApplyQuery() As Boolean
        Dim rows As DataRow(), sFilter As String = "", sSort As String = ""
        Dim dt As New DataTable, bind As New BindingSource
        Dim row As DataRow, lRows As Long
        Dim dTotal As Double = 0
        Dim typeCode1 As TypeCode
        Dim typeCode2 As TypeCode
        Dim typeCode3 As TypeCode
        Dim sField1 As String = "", sField2 As String = "", sField3 As String = ""




        Try
            sField1 = Trim(cboFilterField1.Text)
            sField2 = Trim(cboFilterField2.Text)
            sField3 = Trim(cboFilterField3.Text)

            If sField1 <> "" Then
                typeCode1 = Type.GetTypeCode(dgList.Columns(sField1).ValueType)
                If sFilter <> "" Then sFilter = sFilter & " And "
                sFilter = sFilter & sField1
                If typeCode1 = TypeCode.String Then
                    If txtFilterValue1.Text = "" Then
                        sFilter = sFilter & " Is NULL"
                    Else
                        sFilter = sFilter & " Like " & QuoStr("*" & txtFilterValue1.Text & "*")
                    End If
                ElseIf typeCode1 = TypeCode.DateTime Then
                    If txtFilterValue1.Text = "" Then
                        sFilter = sFilter & " Is NULL"
                    Else
                        sFilter = sFilter & " = " & QuoStr(txtFilterValue1.Text)
                    End If
                Else
                    If txtFilterValue1.Text = "" Then
                        sFilter = sFilter & " Is NULL"
                    Else
                        sFilter = sFilter & " = " & txtFilterValue1.Text
                    End If
                End If
            End If

            If sField2 <> "" Then
                typeCode2 = Type.GetTypeCode(dgList.Columns(sField2).ValueType)
                If sFilter <> "" Then sFilter = sFilter & " And "
                sFilter = sFilter & sField2
                If typeCode2 = TypeCode.String Then
                    If txtFilterValue2.Text = "" Then
                        sFilter = sFilter & " Is NULL"
                    Else
                        sFilter = sFilter & " Like " & QuoStr("*" & txtFilterValue2.Text & "*")
                    End If
                ElseIf typeCode2 = TypeCode.DateTime Then
                    If txtFilterValue2.Text = "" Then
                        sFilter = sFilter & " Is NULL"
                    Else
                        sFilter = sFilter & " = " & QuoStr(txtFilterValue2.Text)
                    End If
                Else
                    If txtFilterValue2.Text = "" Then
                        sFilter = sFilter & " Is NULL"
                    Else
                        sFilter = sFilter & " = " & txtFilterValue2.Text
                    End If
                End If
            End If

            If sField3 <> "" Then
                typeCode3 = Type.GetTypeCode(dgList.Columns(sField3).ValueType)
                If sFilter <> "" Then sFilter = sFilter & " And "
                sFilter = sFilter & sField3
                If typeCode3 = TypeCode.String Then
                    If txtFilterValue3.Text = "" Then
                        sFilter = sFilter & " Is NULL"
                    Else
                        sFilter = sFilter & " Like " & QuoStr("*" & txtFilterValue3.Text & "*")
                    End If
                ElseIf typeCode3 = TypeCode.DateTime Then
                    If txtFilterValue3.Text = "" Then
                        sFilter = sFilter & " Is NULL"
                    Else
                        sFilter = sFilter & " = " & QuoStr(txtFilterValue3.Text)
                    End If
                Else
                    If txtFilterValue3.Text = "" Then
                        sFilter = sFilter & " Is NULL"
                    Else
                        sFilter = sFilter & " = " & txtFilterValue3.Text
                    End If
                End If
            End If







            If Trim(cboSortField1.Text) <> "" Then
                If sSort <> "" Then sSort = sSort & ", "
                sSort = sSort & cboSortField1.Text & IIf(cboSortType1.Text = "ASC", " ASC ", " DESC ")
            End If
            If Trim(cboSortField2.Text) <> "" Then
                If sSort <> "" Then sSort = sSort & ", "
                sSort = sSort & cboSortField2.Text & IIf(cboSortType2.Text = "ASC", " ASC ", " DESC ")
            End If
            If Trim(cboSortField3.Text) <> "" Then
                If sSort <> "" Then sSort = sSort & ", "
                sSort = sSort & cboSortField3.Text & IIf(cboSortType3.Text = "ASC", " ASC ", " DESC ")
            End If

            dt = dtList.Clone
            dt.Clear()
            rows = dtList.Select(sFilter, sSort)
            For Each row In rows
                dt.ImportRow(row)
                If m_ListType = enumListType.enumAssets Then dTotal = dTotal + UnNullToDouble(row("OriginalCost"))
            Next
            bind.DataSource = dt
            dgList.DataSource = bind

            lRows = dt.Rows.Count
            If lRows = 0 Then
                txtRowCount.Text = "No records found"
                dgList.Enabled = False
            ElseIf lRows = 1 Then
                dgList.Enabled = True
                txtRowCount.Text = "1 record found"
            Else
                dgList.Enabled = True
                txtRowCount.Text = Format(lRows, csInt) & " records found"
            End If
            If m_ListType = enumListType.enumAssets Then txtTotal.Text = "Total original cost:  " & Format(dTotal, csInt)

            Return True

        Catch ex As Exception
            MsgBox("Error in ApplyQuery:  " & ex.Message)
            Return False
        End Try

    End Function
    Private Function LoadDropDowns(ByVal dt As DataTable, ByVal sIndexFields As List(Of String)) As Boolean
        Dim col As DataColumn, bIsIndexField As Boolean = False, s As String = ""

        cboFilterField1.Items.Clear()
        cboFilterField2.Items.Clear()
        cboFilterField3.Items.Clear()
        cboSortField1.Items.Clear()
        cboSortField2.Items.Clear()
        cboSortField3.Items.Clear()
        txtFilterValue1.Text = ""
        txtFilterValue2.Text = ""
        txtFilterValue3.Text = ""

        cboFilterField1.Items.Add("")
        cboFilterField2.Items.Add("")
        cboFilterField3.Items.Add("")
        cboSortField1.Items.Add("")
        cboSortField2.Items.Add("")
        cboSortField3.Items.Add("")
        For Each col In dt.Columns
            If Not IsIndexField(col.ColumnName) And col.ColumnName <> "TaxYear" And IsHiddenColumn(col.ColumnName) = False Then
                bIsIndexField = False
                For Each s In sIndexFields
                    If s = col.ColumnName Then
                        bIsIndexField = True
                        Exit For
                    End If
                Next
                If bIsIndexField = False Then
                    cboFilterField1.Items.Add(col.ColumnName)
                    cboFilterField2.Items.Add(col.ColumnName)
                    cboFilterField3.Items.Add(col.ColumnName)
                    cboSortField1.Items.Add(col.ColumnName)
                    cboSortField2.Items.Add(col.ColumnName)
                    cboSortField3.Items.Add(col.ColumnName)
                End If
            End If
        Next




    End Function

    Private Sub frmList_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        SaveColumnWidths()
    End Sub
    Private Sub SaveColumnWidths()
        Try
            For Each column As DataGridViewColumn In dgList.Columns
                If column.Visible Then
                    SetColumnWidth(m_ListType, m_QueryId, column.Name, column.Width)
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub
    Private Function IsHiddenColumn(ByVal sColumnName As String) As Boolean
        Select Case m_ListType
            Case enumListType.enumAssessmentBPPTaxBills
                Select Case sColumnName
                    Case "RELandValue", "REImprovementValue", "TotalAssessedValue", "RERatio"
                        Return True
                End Select
            Case enumListType.enumAssessmentBPPTotalTaxBills
            Case enumListType.enumAssessmentRETaxBills
                Select Case sColumnName
                    Case "NotifiedValue", "BPPRatio", "FreeportReductionAmt"
                        Return True
                End Select
            Case enumListType.enumAssessmentRETotalTaxBills
            Case enumListType.enumSavings
                Select Case sColumnName
                    Case "Assessors_Name", "HasInstallments", "AdjDesc1", "AdjAmt1", "TaxBillAdjAmt1", "TaxBillAdjDesc1", "PenaltyAmt1", "TaxBillPrintedDate", "Payee", "LienDate"
                        Return True
                    Case Else
                        If InStr(sColumnName, "Collectors_", CompareMethod.Text) > 0 Or InStr(sColumnName, "Contact", CompareMethod.Text) > 0 Then
                            Return True
                        End If
                End Select

        End Select
        Return False
    End Function

    Private Sub frmList_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Me.Width = Me.ParentForm.Width - 50
        'Me.Height = Me.ParentForm.Height - 100
        'Me.Left = 0
        'Me.Top = 0
        txtRowCount.Text = ""
        txtTotal.Text = ""
        txtFixed.Text = ""
        txtInv.Text = ""

        Dim tt As New ToolTip
        tt.AutoPopDelay = 5000
        tt.InitialDelay = 1000
        tt.ReshowDelay = 500
        tt.ShowAlways = True

        If m_ListType = enumListType.enumAssessmentBPP Or m_ListType = enumListType.enumRenditions Or m_ListType = enumListType.enumAssessmentRE Then
            mnuContextAddJurisdiction.Visible = True
            mnuContextCreateEvent.Visible = True
        Else
            mnuContextAddJurisdiction.Visible = False
            mnuContextCreateEvent.Visible = False
        End If

        If m_ListType = enumListType.enumAssessmentBPP Or m_ListType = enumListType.enumRenditions Then
            mnuContextOpenListOfAssets.Visible = True
            mnuContextOpenAssessmentValues.Visible = True
            mnuContextImportAssets.Visible = True
            mnuContextDeleteAssets.Visible = True
        Else
            mnuContextOpenListOfAssets.Visible = False
            mnuContextOpenAssessmentValues.Visible = False
            mnuContextImportAssets.Visible = False
            mnuContextDeleteAssets.Visible = False
        End If

        If m_ListType = enumListType.enumAssessmentBPP Or m_ListType = enumListType.enumAssessmentRE Or m_ListType = enumListType.enumRenditions Then
            mnuContextSetECUParent.Visible = True
            mnuContextSetBusinessUnit.Visible = True
            ''mnuContextAssignTask.Visible = True
            mnuContextSetAgency.Visible = True
        Else
            mnuContextSetECUParent.Visible = False
            mnuContextSetBusinessUnit.Visible = False
            mnuContextAssignTask.Visible = False
            mnuContextSetAgency.Visible = False
        End If

        If m_ListType = enumListType.enumQueryList Then
            mnuContextModifyQuery.Visible = True
            mnuContextCopy.Visible = True
        Else
            mnuContextModifyQuery.Visible = False
            mnuContextCopy.Visible = False
        End If
        If m_ListType = enumListType.enumAssets Then
            chkShowFactor.Visible = True
            mnuContextFactor.Visible = True
            mnuContextSetRenditionServiceLevel.Visible = True
            mnuContextSetRenditionInterstateAllocation.Visible = True
            mnuContextSetLeaseInfo.Visible = True
            mnuContextSetRenditionAuditFl.Visible = True
            cmdNew.Visible = True
            cmdNew.Enabled = True
            cmdNew.Text = "New Asset"
            cmdImport.Visible = False
            'chkAssetsLoadedFl.Visible = True
            'chkAssetsVerifiedFl.Visible = True
            'txtAssetsLoadedDt.Visible = True
            'txtAssetsVerifiedDt.Visible = True
        Else
            chkShowFactor.Visible = False
            mnuContextFactor.Visible = False
            mnuContextSetRenditionServiceLevel.Visible = False
            mnuContextSetRenditionInterstateAllocation.Visible = False
            mnuContextSetRenditionAuditFl.Visible = False
            mnuContextSetLeaseInfo.Visible = False
            cmdNew.Visible = False
            cmdImport.Visible = False
            'chkAssetsLoadedFl.Visible = False
            'chkAssetsVerifiedFl.Visible = False
            'txtAssetsLoadedDt.Visible = False
            'txtAssetsVerifiedDt.Visible = False
        End If

        If m_ListType = enumListType.enumAssessmentBPP Or m_ListType = enumListType.enumRenditions Or
                m_ListType = enumListType.enumRenditionDueDates Or m_ListType = enumListType.enumAssessmentRE Then
            mnuContextSetConsultantName.Visible = True
        Else
            mnuContextSetConsultantName.Visible = False
        End If

        If m_ListType = enumListType.enumProspectLocations Or m_ListType = enumListType.enumProspectValues Or
                m_ListType = enumListType.enumProspectTotalValues Then
            mnuContextOpenProspect.Visible = True

        End If
        If m_ListType = enumListType.enumProspectLocations Or m_ListType = enumListType.enumProspectValues Then
            mnuContextAssignToClient.Visible = True

        End If

        If m_ListType = enumListType.enumAssessmentBPP Or m_ListType = enumListType.enumRenditions Or
                m_ListType = enumListType.enumAssessmentRE Or m_ListType = enumListType.enumClient Or
                m_ListType = enumListType.enumAssessor Or
                m_ListType = enumListType.enumSavings Then
            mnuContextPrint.Visible = True
        ElseIf m_ListType = enumListType.enumQueryResults Then
            If m_QueryType = UserQueryType.AllAssessment Or m_QueryType = UserQueryType.BPPAssessment Or m_QueryType = UserQueryType.REAssessment Then
                mnuContextPrint.Visible = True
            Else
                mnuContextPrint.Visible = False
            End If
        Else
            mnuContextPrint.Visible = False

        End If
        If m_ListType = enumListType.enumProspectTotalValues Or m_ListType = enumListType.enumRenditionDueDates Or
                m_ListType = enumListType.enumAssessmentBPPTaxBills Or m_ListType = enumListType.enumAssessmentRETaxBills Or
                m_ListType = enumListType.enumAssessmentBPPTotalTaxBills Or m_ListType = enumListType.enumAssessmentRETotalTaxBills Or
                m_ListType = enumListType.enumSavings Then
            mnuContextDelete.Visible = False
        End If
        If m_ListType = enumListType.enumAssessmentBPPTaxBills Or m_ListType = enumListType.enumAssessmentBPPTotalTaxBills Or
                m_ListType = enumListType.enumAssessmentRETaxBills Or m_ListType = enumListType.enumAssessmentRETotalTaxBills Or
                m_ListType = enumListType.enumSavings Then
            mnuContextImportTaxBill.Visible = True
            mnuContextViewTaxBill.Visible = True
        End If

        If m_ListType = enumListType.enumProspect Then
            mnuContextSetClientCoordinatorName.Visible = True
            mnuContextSetLeadFollowUpDate.Visible = True
            mnuContextSetLeadInfoSentFl.Visible = True
            mnuContextSetLeadMailDate.Visible = True
            mnuContextSetLeadStatus.Visible = True
            mnuContextSetSolicitSentDate.Visible = True
            mnuContextSetSolicitType.Visible = True
        Else
            mnuContextSetClientCoordinatorName.Visible = False
            mnuContextSetLeadFollowUpDate.Visible = False
            mnuContextSetLeadInfoSentFl.Visible = False
            mnuContextSetLeadMailDate.Visible = False
            mnuContextSetLeadStatus.Visible = False
            mnuContextSetSolicitSentDate.Visible = False
            mnuContextSetSolicitType.Visible = False
        End If

        Select Case m_ListType
            Case enumListType.enumAssessmentBPP
                tt.SetToolTip(dgList, "Right-click to see more options")
            Case enumListType.enumAssessmentBPPTaxBills
            Case enumListType.enumAssessmentRE
            Case enumListType.enumAssessmentRETaxBills
            Case enumListType.enumAssessor

        End Select

        Try
            Dim iX As Integer = SplitContainer1.Panel2.Width / 2
            Dim iY As Integer = SplitContainer1.Panel2.Height / 2
            pnlClient.Location = New Point(iX - (pnlClient.Width / 2), iY - (pnlClient.Height / 2))
            pnlClientCoordinatorName.Location = New Point(iX - (pnlClientCoordinatorName.Width / 2), iY - (pnlClientCoordinatorName.Height / 2))
            pnlFactor.Location = New Point(iX - (pnlFactor.Width / 2), iY - (pnlFactor.Height / 2))
            pnlLeadFollowUpDate.Location = New Point(iX - (pnlLeadFollowUpDate.Width / 2), iY - (pnlLeadFollowUpDate.Height / 2))
            pnlLeadInfoSentFl.Location = New Point(iX - (pnlLeadInfoSentFl.Width / 2), iY - (pnlLeadInfoSentFl.Height / 2))
            pnlLeadMailDate.Location = New Point(iX - (pnlLeadMailDate.Width / 2), iY - (pnlLeadMailDate.Height / 2))
            pnlLeadStatus.Location = New Point(iX - (pnlLeadStatus.Width / 2), iY - (pnlLeadStatus.Height / 2))
            pnlSolicitSentDate.Location = New Point(iX - (pnlSolicitSentDate.Width / 2), iY - (pnlSolicitSentDate.Height / 2))
            pnlSolicitType.Location = New Point(iX - (pnlSolicitType.Width / 2), iY - (pnlSolicitType.Height / 2))
            pnlRenditionAllocationPct.Location = New Point(iX - (pnlRenditionAllocationPct.Width / 2), iY - (pnlRenditionAllocationPct.Height / 2))
            pnlECUParent.Location = New Point(iX - (pnlECUParent.Width / 2), iY - (pnlECUParent.Height / 2))
            pnlBusinessUnit.Location = New Point(iX - (pnlBusinessUnit.Width / 2), iY - (pnlBusinessUnit.Height / 2))
            pnlConsultantName.Location = New Point(iX - (pnlConsultantName.Width / 2), iY - (pnlConsultantName.Height / 2))
            pnlLeaseInfo.Location = New Point(iX - (pnlLeaseInfo.Width / 2), iY - (pnlLeaseInfo.Height / 2))
            pnlAuditFl.Location = New Point(iX - (pnlAuditFl.Width / 2), iY - (pnlAuditFl.Height / 2))
            pnlAgency.Location = New Point(iX - (pnlAgency.Width / 2), iY - (pnlAgency.Height / 2))
        Catch ex As Exception

        End Try

        Me.Cursor = Cursors.WaitCursor
        MDIParent1.ShowStatus(m_ListType)
        LoadList()
        MDIParent1.ShowStatus()
        Me.Cursor = Cursors.Default
        _FreezeLeaseInfoSettings = False
    End Sub


    Private Sub dgList_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgList.CellDoubleClick
        Try
            If e.RowIndex >= 0 Then
                GridCellDoubleClick(dgList.Rows(e.RowIndex))
            End If
        Catch ex As Exception
            MsgBox("Error:  " & ex.Message)
        End Try
    End Sub

    Private Sub GridCellDoubleClick(row As DataGridViewRow)
        'perform typical action
        GridCellDoubleClick(row, enumListType.enumUnknown)
    End Sub

    Private Sub GridCellDoubleClick(row As DataGridViewRow, WhichListToOpen As enumListType)

        Dim lClientId As Long, lLocationId As Long, iTaxYear As Integer, lAssessmentId As Long
        Dim sStateCd As String, lId As Long


        If m_ListType = enumListType.enumClient Or m_ListType = enumListType.enumProspect Or
                m_QueryType = UserQueryType.Client Or m_QueryType = UserQueryType.Prospects Then
            lClientId = row.Cells("Clients_ClientId").Value
            OpenClient(lClientId)
        ElseIf m_ListType = enumListType.enumProspectLocations Or m_ListType = enumListType.enumProspectValues Or
                m_QueryType = UserQueryType.ProspectLocations Or m_QueryType = UserQueryType.ProspectValues Then
            lClientId = row.Cells("Clients_ClientId").Value
            lLocationId = UnNullToDouble(row.Cells("ProspectLocations_LocationId").Value)
            OpenProspectLocation(lClientId, lLocationId)
        ElseIf m_ListType = enumListType.enumAssessor Then
            Dim lAssessorId As Long = row.Cells("AssessorId").Value
            iTaxYear = row.Cells("TaxYear").Value
            OpenAssessor(lAssessorId, iTaxYear)
        ElseIf m_ListType = enumListType.enumJurisdiction Then
            Dim lJurisdictionId As Long = row.Cells("JurisdictionId").Value
            iTaxYear = row.Cells("TaxYear").Value
            OpenJurisdiction(lJurisdictionId, iTaxYear)
        ElseIf m_ListType = enumListType.enumCollector Then
            Dim lCollectorId As Long = row.Cells("CollectorId").Value
            iTaxYear = row.Cells("TaxYear").Value
            OpenCollector(lCollectorId, iTaxYear)
        ElseIf m_ListType = enumListType.enumLocationBPP Or m_QueryType = UserQueryType.BPPLocation Then
            Dim sField As String = ""
            If m_ListType = enumListType.enumLocationBPP Then sField = "ClientId" Else sField = "Clients_ClientId"
            lClientId = row.Cells(sField).Value
            If m_ListType = enumListType.enumLocationBPP Then sField = "LocationId" Else sField = "LocationsBPP_LocationId"
            lLocationId = row.Cells(sField).Value
            If m_ListType = enumListType.enumLocationBPP Then sField = "TaxYear" Else sField = "LocationsBPP_TaxYear"
            iTaxYear = row.Cells(sField).Value
            Dim sMsg As String = ""
            If Not OpenBPPLocation(lClientId, lLocationId, iTaxYear, sMsg) Then MsgBox(sMsg)
        ElseIf m_ListType = enumListType.enumLocationRE Or m_QueryType = UserQueryType.RELocation Then
            Dim sField As String = ""
            If m_ListType = enumListType.enumLocationRE Then sField = "ClientId" Else sField = "Clients_ClientId"
            lClientId = row.Cells(sField).Value
            If m_ListType = enumListType.enumLocationRE Then sField = "LocationId" Else sField = "LocationsRE_LocationId"
            lLocationId = row.Cells(sField).Value
            If m_ListType = enumListType.enumLocationRE Then sField = "TaxYear" Else sField = "LocationsRE_TaxYear"
            iTaxYear = row.Cells(sField).Value
            Dim sMsg As String = ""
            If Not OpenRELocation(lClientId, lLocationId, iTaxYear, sMsg) Then MsgBox(sMsg)
        ElseIf m_QueryType = UserQueryType.BPPAssessment Or m_QueryType = UserQueryType.BPPTaxes Then
            lClientId = row.Cells("Clients_ClientId").Value
            lLocationId = row.Cells("LocationsBPP_LocationId").Value
            lAssessmentId = UnNullToDouble(row.Cells("AssessmentsBPP_AssessmentId").Value)
            iTaxYear = row.Cells("LocationsBPP_TaxYear").Value
            Dim lAssessorId As Long = 0
            If row.Cells("Assessors_AssessorId").Value.ToString.Trim <> "" Then
                lAssessorId = row.Cells("Assessors_AssessorId").Value
            End If
            Dim sMsg As String = ""
            If Not OpenBPPTaxList(lClientId, lLocationId, lAssessmentId, lAssessorId, iTaxYear, sMsg) Then MsgBox(sMsg)
        ElseIf m_QueryType = UserQueryType.REAssessment Or m_QueryType = UserQueryType.RETaxes Then
            lClientId = row.Cells("Clients_ClientId").Value
            lLocationId = row.Cells("LocationsRE_LocationId").Value
            lAssessmentId = UnNullToDouble(row.Cells("AssessmentsRE_AssessmentId").Value)
            iTaxYear = row.Cells("LocationsRE_TaxYear").Value
            Dim sMsg As String = ""
            If Not OpenREAssessment(lClientId, lLocationId, lAssessmentId, iTaxYear, sMsg) Then MsgBox(sMsg)
        ElseIf m_QueryType = UserQueryType.AllAssessment Or m_QueryType = UserQueryType.AllTaxes Then
            Dim sPropType As String = "", lAssessorId As Long = 0
            sPropType = row.Cells("PropType").Value
            lClientId = row.Cells("Clients_ClientId").Value
            lLocationId = row.Cells("Locations" & sPropType & "_LocationId").Value
            lAssessmentId = UnNullToDouble(row.Cells("Assessments" & sPropType & "_AssessmentId").Value)
            iTaxYear = row.Cells("Locations" & sPropType & "_TaxYear").Value
            lAssessorId = UnNullToDouble(row.Cells("Assessors_AssessorId").Value)
            Dim sMsg As String = ""
            If sPropType = "RE" Then
                If Not OpenREAssessment(lClientId, lLocationId, lAssessmentId, iTaxYear, sMsg) Then MsgBox(sMsg)
            Else
                If Not OpenBPPTaxList(lClientId, lLocationId, lAssessmentId, lAssessorId, iTaxYear, sMsg) Then MsgBox(sMsg)
            End If
        ElseIf m_ListType = enumListType.enumRenditions Or m_ListType = enumListType.enumAssessmentBPP _
                Or m_ListType = enumListType.enumAssessmentRE Or m_ListType = enumListType.enumFixedAssetReconciliation Then
            lClientId = row.Cells("ClientId").Value
            lLocationId = row.Cells("LocationId").Value
            lAssessmentId = UnNullToDouble(row.Cells("AssessmentId").Value)
            iTaxYear = row.Cells("TaxYear").Value
            Dim lAssessorId As Long = row.Cells("AssessorId").Value

            If ((WhichListToOpen = enumListType.enumUnknown Or WhichListToOpen = enumListType.enumAssets) And (m_ListType = enumListType.enumRenditions Or m_ListType = enumListType.enumFixedAssetReconciliation)) _
                    Or (m_ListType = enumListType.enumAssessmentBPP And WhichListToOpen = enumListType.enumAssets) Then
                OpenList(enumListType.enumAssets, lClientId, lLocationId, lAssessmentId)
            ElseIf ((WhichListToOpen = enumListType.enumUnknown Or WhichListToOpen = enumListType.enumAssessmentBPP) And (m_ListType = enumListType.enumAssessmentBPP Or m_ListType = enumListType.enumAssessmentBPPTaxBills Or
                    m_ListType = enumListType.enumAssessmentBPPTotalTaxBills)) Or (m_ListType = enumListType.enumRenditions And WhichListToOpen = enumListType.enumAssessmentBPP) Then
                Dim sMsg As String = ""
                If Not OpenBPPTaxList(lClientId, lLocationId, lAssessmentId, lAssessorId, iTaxYear, sMsg) Then MsgBox(sMsg)
            ElseIf m_ListType = enumListType.enumAssessmentRE Or m_ListType = enumListType.enumAssessmentRETaxBills Or
                    m_ListType = enumListType.enumAssessmentRETotalTaxBills Then
                Dim sMsg As String = ""
                If Not OpenREAssessment(lClientId, lLocationId, lAssessmentId, iTaxYear, sMsg) Then MsgBox(sMsg)
            End If

        ElseIf m_ListType = enumListType.enumAssessmentBPPTaxBills Or m_ListType = enumListType.enumAssessmentRETaxBills Or
                m_ListType = enumListType.enumAssessmentBPPTotalTaxBills Or m_ListType = enumListType.enumAssessmentRETotalTaxBills Or
                m_ListType = enumListType.enumSavings Then
            Dim sMsg As String = ""
            lClientId = row.Cells("ClientId").Value
            lLocationId = row.Cells("LocationId").Value
            lAssessmentId = UnNullToDouble(row.Cells("AssessmentId").Value)
            iTaxYear = row.Cells("TaxYear").Value
            Dim lAssessorId As Long = UnNullToDouble(row.Cells("AssessorId").Value)
            If m_ListType = enumListType.enumAssessmentBPPTaxBills Or
                    m_ListType = enumListType.enumAssessmentBPPTotalTaxBills Then
                If Not OpenBPPTaxList(lClientId, lLocationId, lAssessmentId, lAssessorId, iTaxYear, sMsg) Then MsgBox(sMsg)
            ElseIf m_ListType = enumListType.enumSavings Then
                If row.Cells("PropertyType").Value = "P" Then
                    If Not OpenBPPTaxList(lClientId, lLocationId, lAssessmentId, lAssessorId, iTaxYear, sMsg) Then MsgBox(sMsg)
                End If
                If row.Cells("PropertyType").Value = "R" Then
                    If Not OpenREAssessment(lClientId, lLocationId, lAssessmentId, iTaxYear, sMsg) Then MsgBox(sMsg)
                End If
            ElseIf m_ListType = enumListType.enumAssessmentRE Or m_ListType = enumListType.enumAssessmentRETaxBills Or
                    m_ListType = enumListType.enumAssessmentRETotalTaxBills Then
                If Not OpenREAssessment(lClientId, lLocationId, lAssessmentId, iTaxYear, sMsg) Then MsgBox(sMsg)
            ElseIf m_ListType = enumListType.enumProspectTotalValues Then
                lClientId = row.Cells("Clients_ClientId").Value
                OpenList(enumListType.enumProspectValues, lClientId)
            End If
        ElseIf m_ListType = enumListType.enumRenditionDueDates Then
            lClientId = row.Cells("ClientId").Value
            lLocationId = row.Cells("LocationId").Value
            lAssessmentId = row.Cells("AssessmentId").Value
            iTaxYear = row.Cells("TaxYear").Value
            Dim lAssessorId As Long = row.Cells("AssessorId").Value
            Dim sMsg As String = ""
            If Not OpenBPPTaxList(lClientId, lLocationId, lAssessmentId, lAssessorId, iTaxYear, sMsg) Then MsgBox(sMsg)
        ElseIf m_ListType = enumListType.enumClientFactors Then
            lClientId = row.Cells("ClientId").Value
            'sClientGLCode = row.Cells("GLCode").Value
            'sStateCd = row.Cells("StateCd").Value
            lFactorEntityId = row.Cells("FactorEntityId").Value
            iTaxYear = row.Cells("TaxYear").Value
            Dim sAdditionalText As String = ""
            sAdditionalText = Trim(row.Cells("Clients_Name").Value) & ", " &
                Trim(row.Cells("FactoringEntityName").Value)
            OpenList(enumListType.enumClientGLCodeXRef, lClientId, , , lFactorEntityId, , sAdditionalText,
                Trim(row.Cells("StateCd").Value))
        ElseIf m_ListType = enumListType.enumClientGLCodeXRef Then
            Dim sGLCode As String = ""
            sGLCode = UnNullToString(row.Cells("GLCode").Value)
            OpenClientGLCode(m_ClientId, sGLCode, m_StateCd, m_FactoringEntityId, m_TaxYear)
        ElseIf m_ListType = enumListType.enumStateFactorCodes Then
            sStateCd = row.Cells("StateCd").Value
            Dim sFactorCode = row.Cells("StateFactorCode").Value
            OpenStateFactorCodes(sStateCd, sFactorCode)
        ElseIf m_ListType = enumListType.enumFactoringEntities Then
            lId = row.Cells("FactorEntityId").Value
            OpenList(enumListType.enumFactorCodes, , , , lId, , row.Cells("Name").Value & ", " & row.Cells("StateCd").Value)
        ElseIf m_ListType = enumListType.enumFactorCodes Then
            Dim sFactorCode As String = row.Cells("FactorCode").Value
            OpenList(enumListType.enumFactors, , , , m_FactoringEntityId, sFactorCode)
        ElseIf m_ListType = enumListType.enumFactors Then
            Dim iAge As Integer = row.Cells("Age").Value
            OpenFactor(m_FactoringEntityId, m_FactorCode, iAge, AppData.TaxYear)
        ElseIf m_ListType = enumListType.enumAssets Then
            Dim sAssetId As String = row.Cells("AssetId").Value
            Dim sFactorCodes(5) As String, i As Integer
            Dim sClientFactorCodes(5) As String

            For i = 1 To 5
                If dgList.Columns.Contains("EntityFactorCode" & i) And dgList.Columns.Contains("ClientFactorCode" & i) Then
                    sFactorCodes(i) = UnNullToString(row.Cells("EntityFactorCode" & i).Value)
                    sClientFactorCodes(i) = UnNullToString(row.Cells("ClientFactorCode" & i).Value)
                End If
            Next
            'For i = 1 To 5
            '    If dgList.Columns.Contains("EntityFactorCodeOverride" & i) Then
            '        If UnNullToString(row.Cells("EntityFactorCodeOverride" & i).Value) <> "" Then
            '            sFactorCodes(i) = UnNullToString(row.Cells("EntityFactorCodeOverride" & i).Value)
            '        End If
            '    End If
            'Next

            OpenAsset(m_ClientId, m_LocationId, m_AssessmentId, sAssetId, sFactorCodes, sClientFactorCodes, m_TaxYear)
        ElseIf m_ListType = enumListType.enumFactorCodeXRef Then
            sStateCd = row.Cells("StateCd").Value
            Dim lFactorEntityId As Long = row.Cells("FactorEntityId").Value
            Dim sFactorCode As String = row.Cells("EntityFactorCode").Value
            Dim sStateFactorCode As String = UnNullToString(row.Cells("StateFactorCode").Value)
            iTaxYear = AppData.TaxYear
            OpenFactorXRef(sStateCd, lFactorEntityId, sFactorCode, sStateFactorCode, iTaxYear)
        ElseIf m_ListType = enumListType.enumTaskMasterList Then
            Dim lTaskId As Long = row.Cells("TaskId").Value
            OpenTask(lTaskId)
        ElseIf m_ListType = enumListType.enumQueryList Then
            RunQuery(row.Cells("QueryId").Value, row.Cells("QueryType").Value)
        End If



    End Sub

    Private Sub cmdApply_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdApply.Click
        ApplyQuery()
        'dgList.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        'dgList.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click, chkShowFactor.CheckedChanged
        Me.Cursor = Cursors.WaitCursor
        bHasLoadedAlready = False
        LoadList()
        Me.Cursor = Cursors.Default
    End Sub

    Private Function LoadAssets() As Boolean
        Dim bind As New BindingSource
        Dim sFactoringEntityNames(4) As String
        Dim lRows As Long
        Dim dTotal As Long = 0, dFixed As Long = 0, dInv As Long = 0
        Dim iCol As Integer = 0
        Dim bReturn As Boolean = False, lWidth As Long = 0
        Dim bShowLeaseType As Boolean = False
        Dim bShowAuditFl As Boolean = False
        Dim bShowActivityQty As Boolean = False
        Dim dtsource As New DataTable

        'txtAssetsLoadedDt.Text = "" : txtAssetsVerifiedDt.Text = "" : chkAssetsLoadedFl.CheckState = CheckState.Unchecked : chkAssetsVerifiedFl.CheckState = CheckState.Unchecked
        If Not IsNothing(dtList) Then dtList.Rows.Clear()
        Dim ds As DataSet
        ds = GetAssetList(m_ClientId, m_LocationId, m_AssessmentId, AppData.TaxYear, 0, IIf(chkShowFactor.CheckState = CheckState.Checked, True, False), True, False, True, True, False, True)

        dtList = ds.Tables("ReturnTypeDetail").Copy
        dTotal = UnNullToDouble(ds.Tables("ReturnTypeSumOfOriginalCost").Rows(0)("SumOfOriginalCost"))
        dFixed = UnNullToDouble(ds.Tables("ReturnTypeFixedAndInv").Rows(0)("SumOfFixed"))
        dInv = UnNullToDouble(ds.Tables("ReturnTypeFixedAndInv").Rows(0)("SumOfInv"))
        Dim dtFactorEntities As DataTable = ds.Tables("ReturnTypeFactoringEntityNames").Copy

        lRows = dtList.Rows.Count
        If lRows > 0 Then
            If IsDBNull(dtList.Rows(0)("AssetId")) Then
                lRows = 0
                dtList.Rows.Clear()
            End If
            'chkAssetsLoadedFl.CheckState = IIf(dtList.Rows(0)("AssetsLoadedFl").ToString.ToUpper = "TRUE", CheckState.Checked, CheckState.Unchecked)
            'chkAssetsVerifiedFl.CheckState = IIf(dtList.Rows(0)("AssetsVerifiedFl").ToString.ToUpper = "TRUE", CheckState.Checked, CheckState.Unchecked)
            'If dtList.Rows(0)("AssetsLoadedDt").ToString <> "" Then
            '    txtAssetsLoadedDt.Text = Convert.ToDateTime(dtList.Rows(0)("AssetsLoadedDt")).ToString(csDateTime)
            'End If
            'If dtList.Rows(0)("AssetsVerifiedDt").ToString <> "" Then
            '    txtAssetsVerifiedDt.Text = Convert.ToDateTime(dtList.Rows(0)("AssetsVerifiedDt")).ToString(csDateTime)
            'End If
        End If

        If dtList.Columns.Contains("LeaseType") = True Then
            bShowLeaseType = dtList.Select("ISNULL(LeaseType,'')<>''").Count > 0
        End If
        If dtList.Columns.Contains("AuditFl") = True Then
            bShowAuditFl = dtList.Select("ISNULL(AuditFl,0)<>0").Count > 0
        End If
        If dtList.Columns.Contains("ActivityQty") = True Then
            bShowActivityQty = dtList.Select("ISNULL(ActivityQty,0)<>0").Count > 0
        End If

        'MUST ADD FIELDS TO THIS SELECT IF NEW COLUMNS ADDED
        dtsource = New DataTable
        Dim baddcolumn As Boolean = False
        For Each col As DataColumn In dtList.Columns
            baddcolumn = False
            Select Case col.ColumnName
                Case "AssetId", "OriginalCost", "PurchaseDate", "Description", "GLCode", "ClientMappingFactorCode1", "ClientMappingFactorCodeOverride1",
                        "ClientFactorCode1" To "ClientFactorCode5",
                        "EntityFactorCodeOverride1" To "EntityFactorCodeOverride5",
                        "AllocationPct1" To "AllocationPct5", "InterstateAllocationPct1" To "InterstateAllocationPct5",
                        "EntityFactorCode1" To "EntityFactorCode5", "ClientFactorCode1" To "ClientFactorCode5",
                        "ClientId", "LocationId", "AssessmentId",
                        "FactorEntityId1" To "FactorEntityId5",
                        "FactoringEntityName1" To "FactoringEntityName5"
                    baddcolumn = True
                Case "ClientFactor1", "ClientValue1", "EntityFactor1" To "EntityFactor5", "EntityValue1" To "EntityValue5"
                    If chkShowFactor.CheckState = CheckState.Checked Then
                        baddcolumn = True
                    End If
                Case "LeaseType"
                    If bShowLeaseType Then baddcolumn = True
                Case "AuditFl"
                    If bShowAuditFl Then baddcolumn = True
                Case "ActivityQty"
                    If bShowActivityQty Then baddcolumn = True
            End Select
            If baddcolumn Then dtsource.Columns.Add(col.ColumnName, col.DataType)
        Next
        dtsource.Merge(dtList, True, MissingSchemaAction.Ignore)

        dgList.Columns.Clear()
        bind.DataSource = dtsource
        dgList.DataSource = bind

        For Each column As DataGridViewColumn In dgList.Columns
            Select Case column.Name
                Case "AssetId"
                    column.HeaderText = "Asset ID"
                Case "OriginalCost"
                    column.HeaderText = "Original Cost"
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = csInt
                Case "PurchaseDate"
                    column.HeaderText = "Purchase Date"
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "GLCode"
                    column.HeaderText = "GL Code"
                Case "ClientMappingFactorCode1"
                    column.HeaderText = "Client Mapping"
                Case "ClientMappingFactorCodeOverride1"
                    column.HeaderText = "Client Reclass"
                Case "ClientFactorCode1" To "ClientFactorCode5"
                    column.HeaderText = dtFactorEntities.Rows(0)("FactoringEntityName" + column.Name.Substring(column.Name.Length - 1, 1)).ToString
                Case "EntityFactorCodeOverride1"
                    column.HeaderText = "Reclassed"
                Case "EntityFactorCodeOverride2" To "EntityFactorCodeOverride5"
                    column.HeaderText = dtFactorEntities.Rows(0)("FactoringEntityName" + column.Name.Substring(column.Name.Length - 1, 1)).ToString + ":  Reclassed"
                Case "ClientValue1"
                    column.HeaderText = "Client Value"
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = csInt
                Case "EntityValue1" To "EntityValue5"
                    column.HeaderText = dtFactorEntities.Rows(0)("FactoringEntityName" + column.Name.Substring(column.Name.Length - 1, 1)).ToString + ":  Factored Amount"
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = csInt
                Case "ClientFactor1"
                    column.HeaderText = "Client Factor"
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = csTaxRate
                Case "EntityFactor1" To "EntityFactor5"
                    column.HeaderText = dtFactorEntities.Rows(0)("FactoringEntityName" + column.Name.Substring(column.Name.Length - 1, 1)).ToString + ":  Factor"
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = csTaxRate
                Case "AllocationPct1" To "AllocationPct5"
                    column.HeaderText = dtFactorEntities.Rows(0)("FactoringEntityName" + column.Name.Substring(column.Name.Length - 1, 1)).ToString + ":  Service Life Factor"
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = csTaxRate
                Case "InterstateAllocationPct1" To "InterstateAllocationPct5"
                    column.HeaderText = dtFactorEntities.Rows(0)("FactoringEntityName" + column.Name.Substring(column.Name.Length - 1, 1)).ToString + ":  Interstate Allocation"
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = csTaxRate
                Case "LeaseType"
                    column.HeaderText = "Lease Type"
                Case "LesseeName"
                    column.HeaderText = "Lessee Name"
                Case "LesseeAddress"
                    column.HeaderText = "Lessee Address"
                Case "LesseeCity"
                    column.HeaderText = "Lessee City"
                Case "LesseeStateCd"
                    column.HeaderText = "Lessee State"
                Case "LesseeZip"
                    column.HeaderText = "Lessee ZIP"
                Case "LeaseTerm"
                    column.HeaderText = "Lease Term"
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    column.DefaultCellStyle.Format = csInt
                Case "EquipmentMake"
                    column.HeaderText = "Equipment Make"
                Case "EquipmentModel"
                    column.HeaderText = "Equipment Model"
                Case "ActivityQty"
                    column.HeaderText = "Engine Hours/Mileage"
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    column.DefaultCellStyle.Format = csInt
                Case "AuditFl"
                    column.HeaderText = "Audited"
                Case "EntityFactorCode1" To "EntityFactorCode5", "ClientFactorCode1" To "ClientFactorCode5",
                        "ClientId", "LocationId", "AssessmentId",
                        "FactorEntityId1" To "FactorEntityId5",
                        "FactoringEntityName1" To "FactoringEntityName5"
                    'used when user double clicks row to open asset detail or factors or deletes
                    column.Visible = False
            End Select
            If Not bHasLoadedAlready Then column.Width = GetColumnWidth(m_ListType, m_QueryId, column.Name)
        Next

        Dim sIndexFields As New List(Of String)
        LoadDropDowns(dtList, sIndexFields)
        cmdApply.Enabled = True
        cmdExport.Enabled = True

        Dim dt As New DataTable
        Dim sSQL As String = "select c.Name, isnull(l.ClientLocationId,'') AS ClientLocationId, l.Address, a.AcctNum," &
            " ISNULL((SELECT Name FROM Assessors WHERE AssessorId = a.AssessorId AND TaxYear = " & m_TaxYear & "),'') AS Assessors_Name" &
            " from Clients c, LocationsBPP l, AssessmentsBPP a" &
            " WHERE c.ClientId = l.ClientId AND a.ClientId = l.ClientId and a.LocationId = l.LocationId" &
            " AND a.TaxYear = l.TaxYear AND a.AssessmentId = " & m_AssessmentId & " AND l.TaxYear = " & m_TaxYear
        GetData(sSQL, dt)
        Me.Text = m_TaxYear & " " & "List of Assets:  " & Trim(UnNullToString(dt.Rows(0).Item("Name"))) & "   " &
            Trim(UnNullToString(dt.Rows(0).Item("Address"))) & "   " & Trim(UnNullToString(dt.Rows(0).Item("AcctNum"))) &
            "   " & Trim(dt.Rows(0).Item("Assessors_Name")) & IIf(dt.Rows(0)("ClientLocationId").ToString.Trim <> "", "    " & dt.Rows(0)("ClientLocationId").ToString, "")

        txtTotal.Text = Format(dTotal, csInt)
        txtFixed.Text = Format(dFixed, csInt)
        txtInv.Text = Format(dInv, csInt)
        lblTotal.Visible = True
        lblFixed.Visible = True
        lblInv.Visible = True

        bHasLoadedAlready = True

        If lRows = 0 Then
            txtRowCount.Text = "No records found"
            dgList.Enabled = False
        ElseIf lRows = 1 Then
            dgList.Enabled = True
            txtRowCount.Text = "1 record found"
        Else
            dgList.Enabled = True
            txtRowCount.Text = Format(lRows, csInt) & " records found"
        End If


    End Function


    Private Sub dgList_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgList.CellMouseDown
        Select Case e.Button
            Case MouseButtons.Left
            Case MouseButtons.Right
                iMouseClickColIndex = e.ColumnIndex
                iMouseClickRowIndex = e.RowIndex
                'bContextTextBoxLoading = True
                'bContextTextBoxChanged = False
                'mnuContextTextBox.Text = dgList.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
                'bContextTextBoxLoading = False
            Case MouseButtons.Middle
            Case MouseButtons.XButton1
            Case MouseButtons.XButton2
            Case MouseButtons.None
        End Select
        lLastGridRow = e.RowIndex
    End Sub

    Private Sub mnuContextSetECUParent_Click(sender As Object, e As System.EventArgs) Handles mnuContextSetECUParent.Click
        Try
            If dgList.SelectedRows.Count = 0 Then Exit Sub
            Dim bFoundBadOne As Boolean = False
            Dim lClientId As Long = dgList.SelectedRows(0).Cells("ClientId").Value
            Dim sStateCd As String = dgList.SelectedRows(0).Cells("StateCd").Value.ToString
            Dim sProp As String = IIf(m_ListType = enumListType.enumAssessmentBPP Or m_ListType = enumListType.enumRenditions, "BPP", "RE")
            Dim row As DataGridViewRow
            For Each row In dgList.SelectedRows
                If lClientId <> row.Cells("ClientId").Value Or sStateCd <> row.Cells("StateCd").Value.ToString Then
                    bFoundBadOne = True
                    Exit For
                End If
            Next
            If bFoundBadOne Then
                MsgBox("All selected accounts must belong to the same client within the same state")
                Exit Sub
            End If
            cboECUParent.Items.Clear()
            cboECUParent.Text = ""
            Dim sSQL As New StringBuilder
            sSQL.Append(" SELECT 0 AS AssessmentId, '' AS Account")
            sSQL.Append(" UNION SELECT a.AssessmentId, RTRIM(LTRIM(ISNULL(a.AcctNum,''))) + ', ' + RTRIM(LTRIM(ISNULL(l.Address,''))) + ', ' + RTRIM(LTRIM(ISNULL(l.City,''))) AS Account")
            sSQL.Append(" FROM Locations").Append(sProp).Append(" AS l INNER JOIN Assessments").Append(sProp).Append(" AS a ON l.ClientId = a.ClientId AND l.LocationId = a.LocationId AND l.TaxYear = a.TaxYear")
            sSQL.Append(" WHERE l.ClientId = ").Append(lClientId).Append(" AND l.StateCd = ").Append(QuoStr(sStateCd))
            sSQL.Append(" AND l.TaxYear = ").Append(AppData.TaxYear).Append(" AND ISNULL(l.InactiveFl,0) = 0 AND ISNULL(a.InactiveFl,0) = 0 AND ISNULL(a.ProspectFl,0) = 0")
            sSQL.Append(" ORDER BY Account")
            colECUParentAccounts = New Collection
            LoadComboBox(sSQL.ToString, cboECUParent, colECUParentAccounts)
            dgList.Enabled = False
            pnlECUParent.Visible = True
            pnlECUParent.BringToFront()
        Catch ex As Exception
            MsgBox("Error setting ECU Parent:  " & ex.Message)
        End Try
    End Sub

    Private Sub mnuContextFactor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuContextFactor.Click
        Try
            If iMouseClickColIndex >= 0 Then
                If InStr(dgList.Columns(iMouseClickColIndex).Name, "EntityFactorCodeOverride") = 1 Or
                        InStr(dgList.Columns(iMouseClickColIndex).Name, "EntityFactorCode") = 1 Or
                        InStr(dgList.Columns(iMouseClickColIndex).Name, "ClientMappingFactorCode") = 1 Or
                        InStr(dgList.Columns(iMouseClickColIndex).Name, "ClientMappingFactorCodeOverride") = 1 Then
                    If dgList.SelectedRows.Count > 0 Then
                        Dim i As Integer
                        Dim row As DataGridViewRow
                        Dim sSQL As String, colTemp As New Collection

                        i = Val(Microsoft.VisualBasic.Right(dgList.Columns(iMouseClickColIndex).Name, 1))
                        row = dgList.SelectedRows(0)
                        lFactorEntityId = row.Cells("FactorEntityId" & i).Value
                        If InStr(dgList.Columns(iMouseClickColIndex).Name, "ClientMappingFactorCode") = 1 Or
                                InStr(dgList.Columns(iMouseClickColIndex).Name, "ClientMappingFactorCodeOverride") = 1 Then
                            bClientOverride = True
                        Else
                            bClientOverride = False
                        End If
                        sSQL = "SELECT FactorCode,FactorCode FROM FactorEntityCodes" &
                            " WHERE FactorEntityId = " & lFactorEntityId & " AND TaxYear = " & m_TaxYear &
                            "  AND ISNULL(InactiveFl,0) = 0 ORDER BY 1"
                        cboFactorFactorCode.Items.Clear()
                        cboFactorFactorCode.Items.Add("")
                        LoadComboBox(sSQL, cboFactorFactorCode, colTemp)
                        cboFactorFactorCode.Text = ""
                        If bClientOverride Then
                            lblFactorEntityName.Text = "Client Reclass"
                        Else
                            lblFactorEntityName.Text = row.Cells("FactoringEntityName" & i).Value
                        End If

                        dgList.Enabled = False
                        pnlFactor.Visible = True
                        pnlFactor.BringToFront()

                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Error factoring:  " & ex.Message)
        End Try
    End Sub

    Private Sub cmdECUParentOK_Click(sender As Object, e As System.EventArgs) Handles cmdECUParentOK.Click
        Try

            Dim lAssessmentId As Long = 0
            Dim sError As String = ""

            If colECUParentAccounts.Contains(cboECUParent.Text) Then
                lAssessmentId = colECUParentAccounts(cboECUParent.Text)
            End If

            Dim cAssessment As clsAssessmentBPP
            Dim listAssessment As New List(Of clsAssessmentBPP)
            Dim row As DataGridViewRow
            For Each row In dgList.SelectedRows
                If row.Cells("AssessmentId").Value.ToString.Trim <> "" Then
                    cAssessment = New clsAssessmentBPP
                    cAssessment.ClientId = row.Cells("ClientId").Value
                    cAssessment.LocationId = row.Cells("LocationId").Value
                    cAssessment.AssessmentId = row.Cells("AssessmentId").Value
                    cAssessment.TaxYear = m_TaxYear
                    listAssessment.Add(cAssessment)
                End If
            Next
            For Each cAssessment In listAssessment
                If Not SaveECUParent(cAssessment.ClientId, cAssessment.LocationId, cAssessment.AssessmentId, cAssessment.TaxYear,
                        IIf(m_ListType = enumListType.enumAssessmentBPP Or m_ListType = enumListType.enumRenditions, enumTable.enumLocationBPP, enumTable.enumLocationRE),
                        lAssessmentId, sError) Then
                    MsgBox(sError)
                    Exit For
                End If
            Next

        Catch ex As Exception
            MsgBox("Error setting ECU parent:  " & ex.Message)
        Finally
            pnlECUParent.Visible = False
            dgList.Enabled = True
        End Try
    End Sub

    Private Sub cmdFactorOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdFactorOK.Click
        Dim sAssets() As String, i As Integer = 0, row As DataGridViewRow
        Try

            ReDim sAssets(dgList.SelectedRows.Count - 1)
            For Each row In dgList.SelectedRows
                sAssets(i) = row.Cells("AssetId").Value
                i = i + 1
            Next
            If bClientOverride Then
                SaveAssetClientOverride(m_ClientId, m_LocationId, m_AssessmentId, m_TaxYear, sAssets, lFactorEntityId, cboFactorFactorCode.Text)
            Else
                If SaveAssetOverride(m_ClientId, m_LocationId, m_AssessmentId, m_TaxYear, sAssets, lFactorEntityId, cboFactorFactorCode.Text) Then
                    'For Each row In dgList.SelectedRows
                    ' row.Cells("").Value = cboFactorFactorCode.Text
                    ' i = i + 1
                    ' Next

                End If
            End If

        Catch ex As Exception
            MsgBox("Error factoring:  " & ex.Message)
        Finally
            pnlFactor.Visible = False
            dgList.Enabled = True
        End Try

    End Sub

    Private Sub mnuContextDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuContextDelete.Click
        Try
            Dim sql As New StringBuilder
            Me.Cursor = Cursors.WaitCursor
            If iMouseClickColIndex >= 0 Then
                If dgList.SelectedRows.Count > 0 Then
                    If MsgBox("Are you sure you want to delete?", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then Exit Sub
                    Dim sSQL As String = ""
                    Dim row As DataGridViewRow
                    For Each row In dgList.SelectedRows
                        Select Case m_ListType
                            Case enumListType.enumClient, enumListType.enumProspect
                                sSQL = ""
                                'If m_ListType = enumListType.enumProspect Then
                                '    sSQL = "DELETE ProspectValues WHERE ClientId = " & row.Cells("Clients_ClientId").Value & _
                                '        " DELETE ProspectLocations WHERE ClientId = " & row.Cells("Clients_ClientId").Value
                                'End If
                                'sSQL = sSQL & " DELETE ClientComments WHERE ClientId = " & row.Cells("Clients_ClientId").Value 
                                sSQL = "UPDATE Clients SET InactiveFl = 1 WHERE ClientId = " & row.Cells("Clients_ClientId").Value
                            Case enumListType.enumProspectLocations, enumListType.enumProspectValues
                                sSQL = "DELETE ProspectValues WHERE ClientId = " & row.Cells("Clients_ClientId").Value &
                                    " AND LocationId = " & UnNullToDouble(row.Cells("ProspectLocations_LocationId").Value) &
                                    " DELETE ProspectLocations WHERE ClientId = " & row.Cells("Clients_ClientId").Value &
                                    " AND LocationId = " & UnNullToDouble(row.Cells("ProspectLocations_LocationId").Value)
                            Case enumListType.enumAssessor
                                sSQL = "DELETE Assessors WHERE AssessorId = " & row.Cells("AssessorId").Value &
                                    " AND TaxYear = " & m_TaxYear
                            Case enumListType.enumJurisdiction
                                sSQL = "DELETE Jurisdictions WHERE JurisdictionId = " & row.Cells("JurisdictionId").Value &
                                    " AND TaxYear = " & m_TaxYear
                            Case enumListType.enumLocationBPP
                                sSQL = "DELETE LocationsBPP WHERE LocationId = " & row.Cells("LocationId").Value &
                                    " AND TaxYear = " & m_TaxYear
                            Case enumListType.enumLocationRE
                                sSQL = "DELETE LocationsRE WHERE LocationId = " & row.Cells("LocationId").Value &
                                    " AND TaxYear = " & m_TaxYear
                            Case enumListType.enumRenditions, enumListType.enumAssessmentBPP
                                sSQL = "DELETE AssessmentsBPP WHERE AssessmentId = " & row.Cells("AssessmentId").Value &
                                    " AND TaxYear = " & m_TaxYear
                            Case enumListType.enumAssessmentRE
                                sSQL = "DELETE AssessmentsRE WHERE AssessmentId = " & row.Cells("AssessmentId").Value &
                                    " AND TaxYear = " & m_TaxYear
                            Case enumListType.enumClientFactors
                            Case enumListType.enumStateFactorCodes
                                sSQL = "DELETE StateFactorCodes WHERE StateCd = " & QuoStr(row.Cells("StateCd").Value) &
                                    " AND StateFactorCode = " & QuoStr(row.Cells("StateFactorCode").Value) &
                                    " AND TaxYear = " & m_TaxYear
                            Case enumListType.enumFactoringEntities
                                sSQL = "DELETE FactorEntities WHERE FactorEntityId = " & row.Cells("FactorEntityId").Value
                            Case enumListType.enumFactorCodes
                                sSQL = "DELETE FactorEntityCodes WHERE FactorEntityId = " & row.Cells("FactorEntityId").Value &
                                    " AND FactorCode = " & QuoStr(row.Cells("FactorCode").Value) &
                                    " AND TaxYear = " & m_TaxYear
                            Case enumListType.enumFactors
                                sSQL = "DELETE Factors WHERE FactorEntityId = " & row.Cells("FactorEntityId").Value &
                                    " AND FactorCode = " & QuoStr(row.Cells("FactorCode").Value) &
                                    " AND Age = " & row.Cells("Age").Value &
                                    " AND TaxYear = " & m_TaxYear
                            Case enumListType.enumAssets
                                DeleteAssets(row.Cells("ClientId").Value.ToString, row.Cells("LocationId").Value.ToString, row.Cells("AssessmentId").Value.ToString, row.Cells("AssetId").Value.ToString, m_TaxYear)
                            Case enumListType.enumFactorCodeXRef
                            Case enumListType.enumCollector
                                sSQL = "DELETE Collectors WHERE CollectorId = " & row.Cells("CollectorId").Value &
                                    " AND TaxYear = " & m_TaxYear
                            Case enumListType.enumTaskMasterList
                                Dim lId As Long = row.Cells("TaskId").Value
                                sSQL = "DELETE TaskAssignments WHERE TaskId = " & lId & " DELETE TaskMasterList WHERE TaskId = " & lId
                            Case enumListType.enumTaskAssignments
                                Dim taskid As String, proptype As String, clientid As String, locationid As String, assessmentid As String, taxyear As String
                                taskid = row.Cells("TaskId").Value.ToString
                                proptype = row.Cells("PropType").Value.ToString
                                clientid = row.Cells("ClientId").Value.ToString
                                locationid = row.Cells("LocationId").Value.ToString
                                assessmentid = row.Cells("AssessmentId").Value.ToString
                                taxyear = row.Cells("TaxYear").Value.ToString
                                sql.Clear()
                                sql.Append("DELETE TaskAssignments WHERE TaskId = ").Append(taskid)
                                sql.Append(" AND PropType = ").Append(QuoStr(proptype))
                                sql.Append(" AND TaxYear = ").Append(taxyear)
                                sql.Append(" AND ClientId = ").Append(clientid)
                                sql.Append(" AND LocationId = ").Append(locationid)
                                sql.Append(" AND AssessmentId = ").Append(assessmentid)
                                sSQL = sql.ToString
                            Case enumListType.enumQueryList
                                Dim lId As Long = row.Cells("QueryId").Value
                                sSQL = "DELETE UserQuerySelect WHERE QueryId = " & lId &
                                    " DELETE UserQueryDetail WHERE QueryId = " & lId &
                                    " DELETE UserQuery WHERE QueryId = " & lId
                        End Select
                        If sSQL <> "" Then
                            ExecuteSQL(sSQL)
                        End If
                    Next
                    If sSQL <> "" Or m_ListType = enumListType.enumAssets Then
                        LoadList()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Error deleting:  " & ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub
    Private Sub DeleteAssets(clientid As String, locationid As String, assessmentid As String, assetid As String, taxyear As String)
        Dim sql As New StringBuilder

        If clientid = "" Or locationid = "" Or assessmentid = "" Or taxyear = "" Then Exit Sub

        sql.Append("DELETE FactorCodeOverrides WHERE ClientId = ").Append(clientid).Append(" AND LocationId = ").Append(locationid)
        sql.Append(" AND AssessmentId = ").Append(assessmentid).Append(" AND TaxYear = ").Append(taxyear)
        If assetid <> "" Then sql.Append(" AND AssetId = ").Append(QuoStr(assetid))
        sql.Append(" DELETE ClientFactorCodeOverrides WHERE ClientId = ").Append(clientid).Append(" AND LocationId = ").Append(locationid)
        sql.Append(" AND AssessmentId = ").Append(assessmentid).Append(" AND TaxYear = ").Append(taxyear)
        If assetid <> "" Then sql.Append(" AND AssetId = ").Append(QuoStr(assetid))
        sql.Append(" DELETE AssetAllocationPct WHERE ClientId = ").Append(clientid).Append(" AND LocationId = ").Append(locationid)
        sql.Append(" AND AssessmentId = ").Append(assessmentid).Append(" AND TaxYear = ").Append(taxyear)
        If assetid <> "" Then sql.Append(" AND AssetId = ").Append(QuoStr(assetid))
        sql.Append(" DELETE Assets WHERE ClientId = ").Append(clientid).Append(" AND LocationId = ").Append(locationid)
        sql.Append(" AND AssessmentId = ").Append(assessmentid).Append(" AND TaxYear = ").Append(taxyear)
        If assetid <> "" Then sql.Append(" AND AssetId = ").Append(QuoStr(assetid))
        ExecuteSQL(sql.ToString)
    End Sub
    Private Sub mnuContextPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuContextPrint.Click
        Try
            If m_ListType <> enumListType.enumAssessmentBPP And m_ListType <> enumListType.enumRenditions And
                m_ListType <> enumListType.enumAssessmentRE And m_ListType <> enumListType.enumClient And
                m_ListType <> enumListType.enumAssessor And
                m_ListType <> enumListType.enumSavings And m_ListType <> enumListType.enumQueryResults Then Exit Sub

            If m_ListType = enumListType.enumQueryResults Then
                If m_QueryType <> UserQueryType.AllAssessment And m_QueryType <> UserQueryType.BPPAssessment And m_QueryType <> UserQueryType.REAssessment Then
                    Exit Sub
                End If
            End If

            If iMouseClickColIndex >= 0 Then
                If dgList.SelectedRows.Count > 0 Then
                    Dim FactorEntityIdList As New List(Of Long), i As Integer
                    Dim row As DataGridViewRow
                    Dim colAssessments As New Collection, structAssess As New structAssessment

                    For Each row In dgList.SelectedRows
                        'for bpp assess and rendtion lists, get list of all factorentityids to pass to print screen
                        'print screen will then show dropdown list of entities so user can select which entity to print
                        For i = 1 To 5
                            If dgList.Columns.Contains("FactorEntityId" & i) Then
                                If row.Cells("FactorEntityId" & i).Value > 0 Then
                                    If FactorEntityIdList.Contains(row.Cells("FactorEntityId" & i).Value) = False Then
                                        FactorEntityIdList.Add(row.Cells("FactorEntityId" & i).Value)
                                    End If
                                End If
                            End If
                        Next
                        If m_ListType = enumListType.enumClient Then
                            If UnNullToDouble(row.Cells("Clients_ClientId").Value) > 0 Then
                                With structAssess
                                    .ClientId = row.Cells("Clients_ClientId").Value
                                    .TaxYear = m_TaxYear
                                    .Description = Trim(UnNullToString(row.Cells("Clients_Name").Value))
                                End With
                                colAssessments.Add(structAssess)
                            End If
                        ElseIf m_ListType = enumListType.enumAssessor Then
                            If UnNullToDouble(row.Cells("AssessorId").Value) > 0 Then
                                With structAssess
                                    .AssessorId = row.Cells("AssessorId").Value
                                    .TaxYear = m_TaxYear
                                End With
                                colAssessments.Add(structAssess)
                            End If
                        ElseIf m_ListType = enumListType.enumQueryResults Then
                            Dim lAssessmentId As Long = 0, lAssessorId As Long = 0, sStateCd As String = ""
                            Dim sAssessorName As String = "", sAcctNum As String = ""
                            Dim sPropType As String = ""
                            Dim sMsg As String = ""

                            If dgList.Columns.Contains("AssessmentsBPP_AssessmentId") Then
                                If UnNullToDouble(row.Cells("AssessmentsBPP_AssessmentId").Value) > 0 Then
                                    lAssessmentId = row.Cells("AssessmentsBPP_AssessmentId").Value
                                    sPropType = "BPP"
                                End If
                            End If
                            If dgList.Columns.Contains("AssessmentsRE_AssessmentId") Then
                                If UnNullToDouble(row.Cells("AssessmentsRE_AssessmentId").Value) > 0 Then
                                    lAssessmentId = row.Cells("AssessmentsRE_AssessmentId").Value
                                    sPropType = "RE"
                                End If
                            End If
                            If lAssessmentId = 0 Then
                                MsgBox("AssessmentId missing")
                                Exit Sub
                            End If

                            If dgList.Columns.Contains("Assessors_AssessorId") Then
                                lAssessorId = row.Cells("Assessors_AssessorId").Value
                            Else
                                MsgBox("AssessorId missing")
                                Exit Sub
                            End If

                            If dgList.Columns.Contains("Assessors_Name") Then
                                sAssessorName = row.Cells("Assessors_Name").Value
                            Else
                                sMsg = sMsg & "Assessor name needed" & vbCrLf
                            End If
                            If dgList.Columns.Contains("Assessments" & sPropType & "_AcctNum") Then
                                sAcctNum = UnNullToString(row.Cells("Assessments" & sPropType & "_AcctNum").Value)
                            Else
                                sMsg = sMsg & "AcctNum needed" & vbCrLf
                            End If
                            If dgList.Columns.Contains("Locations" & sPropType & "_StateCd") Then
                                sStateCd = UnNullToString(row.Cells("Locations" & sPropType & "_StateCd").Value)
                            Else
                                sMsg = sMsg & "State code needed" & vbCrLf
                            End If
                            If sMsg <> "" Then
                                MsgBox("For printing, the following information needs to be in the query results:" & vbCrLf & sMsg)
                                Exit Sub
                            End If
                            With structAssess
                                .ClientId = row.Cells("Clients_ClientId").Value
                                .TaxYear = row.Cells("Locations" & sPropType & "_TaxYear").Value
                                .LocationId = row.Cells("Locations" & sPropType & "_LocationId").Value
                                .AssessmentId = lAssessmentId
                                .Description = sAssessorName & "_" & sAcctNum
                                .AssessorId = lAssessorId
                                .StateCd = sStateCd
                                .PropType = sPropType
                            End With
                            colAssessments.Add(structAssess)
                        Else
                            If UnNullToDouble(row.Cells("AssessmentId").Value) > 0 Then
                                With structAssess
                                    .ClientId = row.Cells("ClientId").Value
                                    .TaxYear = m_TaxYear
                                    .LocationId = row.Cells("LocationId").Value
                                    .AssessmentId = row.Cells("AssessmentId").Value
                                    .Description = Trim(UnNullToString(row.Cells("Assessors_Name").Value)) & "_" & Trim(UnNullToString(row.Cells("AcctNum").Value))
                                    .AssessorId = row.Cells("AssessorId").Value
                                    If m_ListType = enumListType.enumSavings Then
                                        .StateCd = row.Cells("Locations_StateCd").Value
                                    Else
                                        .StateCd = row.Cells("StateCd").Value
                                    End If
                                    If dgList.Columns.Contains("FactorEntityId1") Then
                                        structAssess.FactorEntityId1 = row.Cells("FactorEntityId1").Value
                                    End If
                                    .PropType = ""
                                End With
                                colAssessments.Add(structAssess)
                            End If
                        End If
                    Next
                    Dim frml = New frmReportSelection
                    frml.Assessments = colAssessments
                    If m_ListType = enumListType.enumAssessmentBPP Or m_ListType = enumListType.enumRenditions Then
                        frml.PropType = enumTable.enumLocationBPP
                    ElseIf m_ListType = enumListType.enumAssessmentRE Then
                        frml.PropType = enumTable.enumLocationRE
                    Else
                        frml.PropType = 0
                    End If
                    frml.FactorEntityIdList = FactorEntityIdList
                    frml.MdiParent = MDIParent1
                    frml.Show()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error printing:  " & ex.Message)
        End Try
    End Sub

    Private Sub cmdExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdExport.Click
        Dim sOutput As String = "", sOutputHeader As String = "", lRow As Long = 0, iCol As Integer = 0
        Dim iEvent As Integer = 0, lRowsCount As Long = 0, sFileName As String = ""
        Dim bAddTab As Boolean = False
        Try
            Me.Cursor = Cursors.WaitCursor
            MDIParent1.ShowStatus("Exporting")
            bAddTab = False
            For iCol = 0 To dgList.Columns.Count - 1
                'If Not IsIndexField(dgList.Columns(iCol).Name) Then
                If bAddTab Then sOutputHeader = sOutputHeader & vbTab
                sOutputHeader = sOutputHeader & Trim(dgList.Columns(iCol).HeaderText)
                bAddTab = True
                'End If
            Next
            sOutputHeader = sOutputHeader & vbNewLine
            ExportFile(sOutputHeader, False, sFileName)
            sOutputHeader = ""
            lRowsCount = dgList.Rows.Count
            For lRow = 0 To lRowsCount - 1
                sOutput = ""
                bAddTab = False
                For iCol = 0 To dgList.Columns.Count - 1
                    'If Not IsIndexField(dgList.Columns(iCol).Name) Then
                    If bAddTab Then sOutput = sOutput & vbTab
                    sOutput = sOutput & Trim(UnNullToString(dgList.Rows(lRow).Cells(iCol).Value))
                    bAddTab = True
                    'End If
                Next
                sOutputHeader = sOutputHeader & sOutput & vbNewLine
                iEvent = iEvent + 1
                If iEvent > 1000 Then
                    ExportFile(sOutputHeader, True, sFileName)
                    sOutputHeader = ""
                    MDIParent1.ShowStatus("Exporting, " & Format(lRow / lRowsCount * 100, "0") & "% complete")
                    iEvent = 0
                End If
            Next
            MDIParent1.ShowStatus()
            Me.Cursor = Cursors.Default

            If sOutputHeader <> "" Then ExportFile(sOutputHeader, True, sFileName)
            MsgBox("Export completed")

        Catch ex As Exception
            MsgBox("Error exporting:  " & ex.Message)
        End Try

    End Sub

    Private Sub dgList_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgList.CellValidating
        If bLoading = False Then
            If m_ListType = enumListType.enumFactoringEntities Then
                If dgList.Columns(e.ColumnIndex).HeaderText = "Name" Then
                ElseIf dgList.Columns(e.ColumnIndex).HeaderText = "StateCd" Then
                Else
                    'e.Cancel = True
                End If
            ElseIf m_ListType = enumListType.enumFactorCodes Then
                If dgList.Columns(e.ColumnIndex).HeaderText = "Description" Then
                Else
                    'e.Cancel = True
                End If
            Else
                'e.Cancel = True
            End If
        End If
    End Sub
    Private Sub dgList_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgList.CellEndEdit
        Dim sError As String = ""
        If m_ListType = enumListType.enumFactoringEntities Then
            If Not UpdateFactorEntities(dgList.Rows(e.RowIndex).Cells("FactorEntityId").Value, dgList.Columns(e.ColumnIndex).Name,
                    Trim(UnNullToString(dgList.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)), sError) Then
                MsgBox(sError)
            End If
        ElseIf m_ListType = enumListType.enumFactorCodes Then
            If Not UpdateFactorEntityCodes(dgList.Rows(e.RowIndex).Cells("FactorEntityId").Value, dgList.Rows(e.RowIndex).Cells("FactorCode").Value,
                    dgList.Rows(e.RowIndex).Cells("TaxYear").Value, dgList.Columns(e.ColumnIndex).Name,
                    Trim(UnNullToString(dgList.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)), sError) Then
                MsgBox(sError)
            End If
        End If
        dgList.Rows(e.RowIndex).ErrorText = String.Empty
    End Sub

    Private Sub mnuContextTextBox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuContextTextBox.GotFocus
        sender.selectall()
    End Sub


    Private Sub mnuContextTextBox_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuContextTextBox.LostFocus
        If bContextTextBoxChanged Then
            If TypeOf sender Is ComboBox Then
                If sender.SelectedIndex >= 0 Then
                    'UpdateDB(sender, DBUpdate)
                End If
            Else
                'UpdateDB(sender, DBUpdate)
                dgList.Rows(iMouseClickRowIndex).Cells(iMouseClickColIndex).Value = mnuContextTextBox.Text

            End If
            bContextTextBoxChanged = False
        End If

    End Sub

    Private Sub mnuContextTextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuContextTextBox.TextChanged
        If bContextTextBoxLoading = False Then bContextTextBoxChanged = True
    End Sub


    Private Sub mnuContextAssignToClient_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuContextAssignToClient.Click
        Try
            If iMouseClickColIndex >= 0 Then
                If dgList.SelectedRows.Count > 0 Then
                    If colClientID Is Nothing Then
                        Dim sSQL As String
                        colClientID = New Collection
                        sSQL = "SELECT ClientId, Name FROM Clients" &
                            " WHERE ISNULL(ProspectFl,0) = 1"
                        If AppData.IncludeInactive = False Then sSQL = sSQL & " AND ISNULL(InactiveFl,0) = 0"
                        sSQL = sSQL & " ORDER BY Name"
                        cboClient.Items.Clear()
                        LoadComboBox(sSQL, cboClient, colClientID)
                    End If
                    cboClient.Text = ""
                    dgList.Enabled = False
                    pnlClient.Visible = True
                    pnlClient.BringToFront()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error assigning locations:  " & ex.Message)
        End Try
    End Sub

    Private Sub cmdClientOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdClientOK.Click
        Dim sSQL As String = "", dtLocations As New DataTable, dtValues As New DataTable
        Dim dr As DataRow, dc As DataColumn
        Dim row As DataGridViewRow, sFields As String = "", eDataType As enumDataTypes
        Dim lLocationId As Long = 0
        Dim lClientIdList As New List(Of Long), lClientId As Long = 0
        Dim bInTransaction As Boolean = False
        Dim b As Boolean = False

        Try
            If dgList.SelectedRows.Count = 0 Then Exit Sub
            Me.Cursor = Cursors.WaitCursor
            For Each row In dgList.SelectedRows
                b = False
                For Each lClientId In lClientIdList
                    If lClientId = row.Cells("Clients_ClientId").Value Then
                        b = True
                        Exit For
                    End If
                Next
                If b = False And colClientID(cboClient.Text) <> row.Cells("Clients_ClientId").Value Then
                    lClientIdList.Add(row.Cells("Clients_ClientId").Value)
                End If
                If UnNullToDouble(row.Cells("ProspectLocations_LocationId").Value) > 0 Then
                    ExecuteSQL("begin transaction")
                    bInTransaction = True
                    sSQL = "SELECT * FROM ProspectLocations" &
                        " WHERE ClientId = " & row.Cells("Clients_ClientId").Value &
                        " AND LocationId = " & row.Cells("ProspectLocations_LocationId").Value
                    GetData(sSQL, dtLocations)
                    sSQL = "SELECT * FROM ProspectValues" &
                        " WHERE ClientId = " & row.Cells("Clients_ClientId").Value &
                        " AND LocationId = " & row.Cells("ProspectLocations_LocationId").Value
                    GetData(sSQL, dtValues)
                    sSQL = "DELETE ProspectValues WHERE ClientId = " & row.Cells("Clients_ClientId").Value &
                        " AND LocationId = " & row.Cells("ProspectLocations_LocationId").Value &
                        " DELETE ProspectLocations WHERE ClientId = " & row.Cells("Clients_ClientId").Value &
                        " AND LocationId = " & row.Cells("ProspectLocations_LocationId").Value
                    ExecuteSQL(sSQL)

                    lLocationId = CreateID(enumTable.enumProspectLocation)

                    For Each dr In dtLocations.Rows
                        sFields = ""
                        For Each dc In dtLocations.Columns
                            If sFields <> "" Then sFields = sFields & ","
                            sFields = sFields & dc.ColumnName
                        Next

                        sSQL = "INSERT ProspectLocations (" & sFields & ")"
                        sSQL = sSQL & " SELECT "
                        sFields = ""
                        For Each dc In dtLocations.Columns
                            If sFields <> "" Then sFields = sFields & ","
                            If dc.ColumnName = "ClientId" Then
                                sFields = sFields & colClientID(cboClient.Text)
                            ElseIf dc.ColumnName = "LocationId" Then
                                sFields = sFields & CStr(lLocationId)
                            Else
                                GetDataDefinition("ProspectLocations", dc.ColumnName, eDataType, False, 0, "")
                                If eDataType = enumDataTypes.eDataText Or eDataType = enumDataTypes.eDataDate Or
                                        eDataType = enumDataTypes.eDataDateTime Then
                                    If IsDBNull(dr(dc.ColumnName)) Then
                                        sFields = sFields & "NULL"
                                    Else
                                        sFields = sFields & QuoStr(dr(dc.ColumnName))
                                    End If
                                Else
                                    sFields = sFields & UnNullToDouble(dr(dc.ColumnName))
                                End If
                            End If
                        Next
                        sSQL = sSQL & sFields
                        ExecuteSQL(sSQL)
                    Next

                    For Each dr In dtValues.Rows
                        sFields = ""
                        For Each dc In dtValues.Columns
                            If sFields <> "" Then sFields = sFields & ","
                            sFields = sFields & dc.ColumnName
                        Next

                        sSQL = "INSERT ProspectValues (" & sFields & ")"
                        sSQL = sSQL & " SELECT "
                        sFields = ""
                        For Each dc In dtValues.Columns
                            If sFields <> "" Then sFields = sFields & ","
                            If dc.ColumnName = "ClientId" Then
                                sFields = sFields & colClientID(cboClient.Text)
                            ElseIf dc.ColumnName = "LocationId" Then
                                sFields = sFields & CStr(lLocationId)
                            Else
                                GetDataDefinition("ProspectValues", dc.ColumnName, eDataType, False, 0, "")
                                If eDataType = enumDataTypes.eDataText Or eDataType = enumDataTypes.eDataDate Or
                                        eDataType = enumDataTypes.eDataDateTime Then
                                    If IsDBNull(dr(dc.ColumnName)) Then
                                        sFields = sFields & "NULL"
                                    Else
                                        sFields = sFields & QuoStr(dr(dc.ColumnName))
                                    End If
                                Else
                                    sFields = sFields & UnNullToDouble(dr(dc.ColumnName))
                                End If
                            End If
                        Next
                        sSQL = sSQL & sFields
                        ExecuteSQL(sSQL)
                    Next
                    ExecuteSQL("commit transaction")
                    bInTransaction = False
                End If
            Next

            If MsgBox("Delete clients that have no linked accounts?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                For Each lClientId In lClientIdList
                    DeleteProspect(lClientId, "")
                Next
            End If


            LoadList()
        Catch ex As Exception
            If bInTransaction Then ExecuteSQL("rollback transaction")
            MsgBox("Error reassigning locations:  " & ex.Message)
        Finally
            pnlClient.Visible = False
            dgList.Enabled = True
            Me.Cursor = Cursors.Default
        End Try


    End Sub
    Private Function BuildProspectValuesQuery(ByVal bTotal As Boolean) As String
        Dim sSQL As String = ""
        If bTotal Then
            sSQL = "SELECT Clients_ClientId, Name, LeadCompetitorName, Phone, COUNT(Clients_ClientId) AS NumberOfLocations," &
                " SUM(MarketValue" & AppData.TaxYear & ") AS Value" & AppData.TaxYear & "," &
                " ISNULL(SUM(MarketValue" & AppData.TaxYear & "), 0) - ISNULL(SUM(MarketValue" & AppData.TaxYear - 1 & "), 0) AS ValueDiff" & AppData.TaxYear & "," &
                " SUM(MarketValue" & AppData.TaxYear - 1 & ") AS Value" & AppData.TaxYear - 1 & "," &
                " ISNULL(SUM(MarketValue" & AppData.TaxYear - 1 & "), 0) - ISNULL(SUM(MarketValue" & AppData.TaxYear - 2 & "), 0) AS ValueDiff" & AppData.TaxYear - 1 & "," &
                " SUM(MarketValue" & AppData.TaxYear - 2 & ") AS Value" & AppData.TaxYear - 2 & " FROM ("
        End If
        sSQL = sSQL & " SELECT c.ClientId AS Clients_ClientId, l.LocationId AS ProspectLocations_LocationId, c.Name, l.AssessorId, l.AcctNum," &
            " l.PropType, l.Notes, l.SICCode, l.BusDesc, l.RenditionFilingStatus," &
            " c.SolicitSentDate, c.LeadStatus, c.LeadFollowUpDate, " &
            " c.ClientCoordinatorName, c.LeadCompetitorName, c.Phone," &
            " a.Assessors_Name, a.Assessors_StateCd" &
            " ,v1.MarketValue AS MarketValue" & AppData.TaxYear &
            " ,ISNULL(v1.MarketValue,0) - ISNULL(v2.MarketValue,0) AS MarketValueDiff" & AppData.TaxYear &
            " ,v2.MarketValue AS MarketValue" & AppData.TaxYear - 1 &
            " ,ISNULL(v2.MarketValue,0) - ISNULL(v3.MarketValue,0) AS MarketValueDiff" & AppData.TaxYear - 1 &
            " ,v3.MarketValue AS MarketValue" & AppData.TaxYear - 2 &
            " FROM ProspectLocations AS l" &
            " LEFT OUTER JOIN (SELECT ClientId, LocationId, TaxYear, MarketValue" &
            " FROM ProspectValues WHERE TaxYear = " & AppData.TaxYear & ") AS v1" &
            " ON l.ClientId = v1.ClientId AND l.LocationId = v1.LocationId" &
            " LEFT OUTER JOIN (SELECT ClientId, LocationId, TaxYear, MarketValue" &
            " FROM ProspectValues WHERE TaxYear = " & AppData.TaxYear - 1 & ") AS v2" &
            " ON l.ClientId = v2.ClientId AND l.LocationId = v2.LocationId" &
            " LEFT OUTER JOIN (SELECT ClientId, LocationId, TaxYear, MarketValue" &
            " FROM ProspectValues WHERE TaxYear = " & AppData.TaxYear - 2 & ") AS v3" &
            " ON l.ClientId = v3.ClientId AND l.LocationId = v3.LocationId" &
            " LEFT OUTER JOIN (SELECT AssessorId, Name AS Assessors_Name, StateCd AS Assessors_StateCd" &
            " FROM Assessors WHERE TaxYear = " & AppData.TaxYear & ") AS a" &
            " ON l.AssessorId = a.AssessorId INNER JOIN" &
            " Clients AS c ON l.ClientId = c.ClientId" &
            " WHERE ISNULL(c.ProspectFl,0) = 1"
        If m_ClientId > 0 Then sSQL = sSQL & " AND c.ClientId = " & m_ClientId
        If AppData.IncludeInactive = False Then sSQL = sSQL & " AND ISNULL(c.InactiveFl,0) = 0"
        If bTotal Then
            sSQL = sSQL & " ) AS v GROUP BY Name, Clients_ClientId, LeadCompetitorName, Phone ORDER BY Name"
        Else
            sSQL = sSQL & " ORDER BY c.Name,a.Assessors_Name,l.AcctNum"
        End If
        Return sSQL
    End Function

    Private Sub mnuContextOpenProspect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuContextOpenProspect.Click

        Try
            If iMouseClickColIndex >= 0 Then
                If dgList.SelectedRows.Count > 0 Then
                    Dim row As DataGridViewRow = dgList.SelectedRows(0)
                    Dim lClientId As Long = row.Cells("Clients_ClientId").Value
                    OpenClient(lClientId)
                End If
            End If
        Catch ex As Exception
            MsgBox("Error opening prospect:  " & ex.Message)
        End Try


    End Sub

    Private Sub mnuContextImportTaxBill_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuContextImportTaxBill.Click
        Try
            Dim sError As String = ""
            If dgList.SelectedRows.Count = 0 Then Return
            Dim row As DataGridViewRow = dgList.SelectedRows(0)
            Dim lClientId As Long = CLng(row.Cells("ClientId").Value)
            Dim lLocationId As Long = CLng(row.Cells("LocationId").Value)
            Dim lAssessmentId As Long = CLng(row.Cells("AssessmentId").Value)
            Dim lCollectorId As Long = CLng(row.Cells("CollectorId").Value)
            If lCollectorId = 0 Then Return
            Dim ePropType As enumTable
            If m_ListType = enumListType.enumAssessmentBPPTaxBills Or m_ListType = enumListType.enumAssessmentBPPTotalTaxBills Then
                ePropType = enumTable.enumLocationBPP
            Else
                ePropType = enumTable.enumLocationRE
            End If

            If ImportTaxBill(lClientId, lLocationId, lAssessmentId, lCollectorId, ePropType, m_TaxYear, AppData.UserId, sError) = True Then
                MsgBox("Tax bill imported")
            Else
                If sError <> "" Then MsgBox("Error importing:  " & sError)
            End If
        Catch ex As Exception
            MsgBox("Error importing tax bill:  " & ex.Message)
        End Try

    End Sub

    Private Sub mnuContextViewTaxBill_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuContextViewTaxBill.Click
        Try
            Dim lClientId As Long = 0, lLocationId As Long = 0, lAssessmentId As Long = 0, lCollectorId As Long = 0, iTaxYear As Integer = 0
            Dim sTable As String = ""
            Dim sFile As String = "", sError As String = "", bHaveViewed As Boolean = False
            Dim sPropType As String = ""

            If iMouseClickColIndex >= 0 Then
                If dgList.SelectedRows.Count > 0 Then
                    Dim row As DataGridViewRow
                    For Each row In dgList.SelectedRows
                        If dgList.Columns.Contains("PropertyType") = True Then
                            sPropType = row.Cells("PropertyType").ToString.Trim
                        Else
                            sPropType = ""
                        End If
                        sTable = IIf(m_ListType = enumListType.enumAssessmentBPPTaxBills Or
                            m_ListType = enumListType.enumAssessmentBPPTotalTaxBills Or
                            (m_ListType = enumListType.enumSavings And sPropType = "P"), "TaxBillsBPP", "TaxBillsRE")
                        If lAssessmentId = row.Cells("AssessmentId").Value And lCollectorId = row.Cells("CollectorId").Value Then
                            bHaveViewed = True
                        Else
                            bHaveViewed = False
                        End If
                        If UnNullToDouble(row.Cells("CollectorId").Value) > 0 And bHaveViewed = False Then
                            lClientId = row.Cells("ClientId").Value
                            lLocationId = row.Cells("LocationId").Value
                            lAssessmentId = row.Cells("AssessmentId").Value
                            lCollectorId = row.Cells("CollectorId").Value
                            iTaxYear = m_TaxYear
                            sFile = row.Cells("Collectors_Name").Value & "_" & row.Cells("AcctNum").Value
                            ViewTaxBill(sTable, lClientId, lLocationId, lAssessmentId, lCollectorId, iTaxYear, sFile, False, sError)
                        End If
                    Next
                End If
            End If
        Catch ex As Exception
            MsgBox("Error printing:  " & ex.Message)
        End Try
    End Sub

    Private Sub mnuContextImportAssets_Click(sender As Object, e As EventArgs) Handles mnuContextImportAssets.Click
        Try
            Dim sError As String = ""
            If dgList.SelectedRows.Count = 0 Then Return
            Dim row As DataGridViewRow = dgList.SelectedRows(0)
            Dim lClientId As Long = CLng(row.Cells("ClientId").Value)
            Dim lLocationId As Long = CLng(row.Cells("LocationId").Value)
            Dim lAssessmentId As Long = 0
            If row.Cells("AssessmentId").Value.ToString.Trim = "" Then
                MsgBox("Assessment does not exist")
                Exit Sub
            End If
            lAssessmentId = CLng(row.Cells("AssessmentId").Value)

            ImportAssets(lClientId, lLocationId, lAssessmentId, AppData.TaxYear)

        Catch ex As Exception
            MsgBox("Error importing assets:  " & ex.Message)
        End Try
    End Sub

    Private Function OpenProspectInfo(ByVal eType As enumProspectSetType) As Boolean
        Try
            If iMouseClickColIndex < 0 Then
                Return False
            End If
            If dgList.SelectedRows.Count <= 0 Then
                Return False
            End If

            If eType = enumProspectSetType.ClientCoordinatorName Then
                If cboClientCoordinatorName.Items.Count = 0 Then
                    cboClientCoordinatorName.Items.Clear()
                    Dim dt As New DataTable
                    GetData("SELECT ConsultantName FROM Consultants ORDER BY ConsultantName", dt)
                    For Each row As DataRow In dt.Rows
                        cboClientCoordinatorName.Items.Add(row("ConsultantName").ToString)
                    Next
                End If
                cboClientCoordinatorName.Text = ""
                pnlClientCoordinatorName.Visible = True
                pnlClientCoordinatorName.BringToFront()
            ElseIf eType = enumProspectSetType.LeadFollowUpDate Then
                txtLeadFollowUpDate.Text = ""
                pnlLeadFollowUpDate.Visible = True
                pnlLeadFollowUpDate.BringToFront()
            ElseIf eType = enumProspectSetType.LeadMailDate Then
                txtLeadMailDate.Text = ""
                pnlLeadMailDate.Visible = True
                pnlLeadMailDate.BringToFront()
            ElseIf eType = enumProspectSetType.LeadStatus Then
                If cboLeadStatus.Items.Count = 0 Then
                    cboLeadStatus.Items.Clear()
                    Dim sSQL As String = "SELECT FieldValue FROM FieldDataDefinition" &
                        " WHERE TableName = 'Clients'" &
                        " AND FieldName = 'LeadStatus'" &
                        " ORDER BY FieldValue"
                    Dim dt As New DataTable
                    GetData(sSQL, dt)
                    For Each dr As DataRow In dt.Rows
                        cboLeadStatus.Items.Add(dr("FieldValue"))
                    Next
                End If
                cboLeadStatus.Text = ""
                pnlLeadStatus.Visible = True
                pnlLeadStatus.BringToFront()
            ElseIf eType = enumProspectSetType.SolicitSentDate Then
                txtSolicitSentDate.Text = ""
                pnlSolicitSentDate.Visible = True
                pnlSolicitSentDate.BringToFront()
            ElseIf eType = enumProspectSetType.SolicitType Then
                If cboSolicitType.Items.Count = 0 Then
                    cboSolicitType.Items.Clear()
                    Dim sSQL As String = "SELECT FieldValue FROM FieldDataDefinition" &
                        " WHERE TableName = 'Clients'" &
                        " AND FieldName = 'SolicitType'" &
                        " ORDER BY FieldValue"
                    Dim dt As New DataTable
                    GetData(sSQL, dt)
                    For Each dr In dt.Rows
                        cboSolicitType.Items.Add(dr("FieldValue"))
                    Next
                End If
                cboSolicitType.Text = ""
                pnlSolicitType.Visible = True
                pnlSolicitType.BringToFront()
            ElseIf eType = enumProspectSetType.LeadInfoSentFl Then
                chkLeadInfoSentFl.CheckState = CheckState.Unchecked
                pnlLeadInfoSentFl.Visible = True
                pnlLeadInfoSentFl.BringToFront()
            End If
            dgList.Enabled = False
            Return True

        Catch ex As Exception
            MsgBox("Error opening prospect information:  " & ex.Message)
        End Try

    End Function

    Private Sub mnuContextSetClientCoordinatorName_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuContextSetClientCoordinatorName.Click
        OpenProspectInfo(enumProspectSetType.ClientCoordinatorName)
    End Sub

    Private Sub mnuContextSetLeadFollowUpDate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuContextSetLeadFollowUpDate.Click
        OpenProspectInfo(enumProspectSetType.LeadFollowUpDate)
    End Sub

    Private Sub mnuContextSetLeadInfoSentFl_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuContextSetLeadInfoSentFl.Click
        OpenProspectInfo(enumProspectSetType.LeadInfoSentFl)
    End Sub

    Private Sub mnuContextSetLeadMailDate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuContextSetLeadMailDate.Click
        OpenProspectInfo(enumProspectSetType.LeadMailDate)
    End Sub

    Private Sub mnuContextSetLeadStatus_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuContextSetLeadStatus.Click
        OpenProspectInfo(enumProspectSetType.LeadStatus)
    End Sub

    Private Sub mnuContextSetSolicitSentDate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuContextSetSolicitSentDate.Click
        OpenProspectInfo(enumProspectSetType.SolicitSentDate)
    End Sub

    Private Sub mnuContextSetSolicitType_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuContextSetSolicitType.Click
        OpenProspectInfo(enumProspectSetType.SolicitType)
    End Sub

    Private Sub cmdLeadFollowUpDateOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLeadFollowUpDateOK.Click

        Try
            If dgList.SelectedRows.Count = 0 Then Exit Sub
            If Not IsDate(txtLeadFollowUpDate.Text) Or Trim(txtLeadFollowUpDate.Text) = "" Then
                MsgBox("Not a valid date")
                Exit Sub
            End If
            Me.Cursor = Cursors.WaitCursor
            For Each row As DataGridViewRow In dgList.SelectedRows
                Dim sSQL As String = "", lClientId As Long = row.Cells("Clients_ClientId").Value
                sSQL = "UPDATE Clients SET LeadFollowUpDate = " & QuoStr(txtLeadFollowUpDate.Text) & "," &
                    " ChangeType = 2, ChangeUser = " & QuoStr(AppData.UserId) & ",ChangeDate=GETDATE()" &
                    " WHERE ClientId = " & lClientId
                ExecuteSQL(sSQL)
            Next

            LoadList()
        Catch ex As Exception
            MsgBox("Error setting lead follow-up date:  " & ex.Message)
        Finally
            pnlLeadFollowUpDate.Visible = False
            dgList.Enabled = True
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub cmdClientCoordinatorNameOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdClientCoordinatorNameOK.Click
        Try
            If dgList.SelectedRows.Count = 0 Then Exit Sub
            If Trim(cboClientCoordinatorName.Text) = "" Then
                MsgBox("Must enter a value")
                Exit Sub
            End If
            Me.Cursor = Cursors.WaitCursor
            For Each row As DataGridViewRow In dgList.SelectedRows
                Dim sSQL As String = "", lClientId As Long = row.Cells("Clients_ClientId").Value
                sSQL = "UPDATE Clients SET ClientCoordinatorName = " & QuoStr(cboClientCoordinatorName.Text) & "," &
                    " ChangeType = 2, ChangeUser = " & QuoStr(AppData.UserId) & ",ChangeDate=GETDATE()" &
                    " WHERE ClientId = " & lClientId
                ExecuteSQL(sSQL)
            Next

            LoadList()
        Catch ex As Exception
            MsgBox("Error setting client coordinator name:  " & ex.Message)
        Finally
            pnlClientCoordinatorName.Visible = False
            dgList.Enabled = True
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub cmdLeadInfoSentFlOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLeadInfoSentFlOK.Click
        Try
            If dgList.SelectedRows.Count = 0 Then Exit Sub
            If chkLeadInfoSentFl.CheckState <> CheckState.Checked Then
                MsgBox("Must check to update database")
                Exit Sub
            End If
            Me.Cursor = Cursors.WaitCursor
            For Each row As DataGridViewRow In dgList.SelectedRows
                Dim sSQL As String = "", lClientId As Long = row.Cells("Clients_ClientId").Value
                sSQL = "UPDATE Clients SET LeadInfoSentFl = 1," &
                    " ChangeType = 2, ChangeUser = " & QuoStr(AppData.UserId) & ",ChangeDate=GETDATE()" &
                    " WHERE ClientId = " & lClientId
                ExecuteSQL(sSQL)
            Next

            LoadList()
        Catch ex As Exception
            MsgBox("Error setting lead information sent flag:  " & ex.Message)
        Finally
            pnlLeadInfoSentFl.Visible = False
            dgList.Enabled = True
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub cmdLeadMailDateOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLeadMailDateOK.Click
        Try
            If dgList.SelectedRows.Count = 0 Then Exit Sub
            If Not IsDate(txtLeadMailDate.Text) Or Trim(txtLeadMailDate.Text) = "" Then
                MsgBox("Not a valid date")
                Exit Sub
            End If
            Me.Cursor = Cursors.WaitCursor
            For Each row As DataGridViewRow In dgList.SelectedRows
                Dim sSQL As String = "", lClientId As Long = row.Cells("Clients_ClientId").Value
                sSQL = "UPDATE Clients SET LeadMailDate = " & QuoStr(txtLeadMailDate.Text) & "," &
                    " ChangeType = 2, ChangeUser = " & QuoStr(AppData.UserId) & ",ChangeDate=GETDATE()" &
                    " WHERE ClientId = " & lClientId
                ExecuteSQL(sSQL)
            Next

            LoadList()
        Catch ex As Exception
            MsgBox("Error setting lead mailed date:  " & ex.Message)
        Finally
            pnlLeadMailDate.Visible = False
            dgList.Enabled = True
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub cmdLeadStatusOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLeadStatusOK.Click
        Try
            If dgList.SelectedRows.Count = 0 Then Exit Sub
            If Trim(cboLeadStatus.Text) = "" Then
                MsgBox("Must enter a value")
                Exit Sub
            End If
            Me.Cursor = Cursors.WaitCursor
            For Each row As DataGridViewRow In dgList.SelectedRows
                Dim sSQL As String = "", lClientId As Long = row.Cells("Clients_ClientId").Value
                sSQL = "UPDATE Clients SET LeadStatus = " & QuoStr(cboLeadStatus.Text) & "," &
                    " ChangeType = 2, ChangeUser = " & QuoStr(AppData.UserId) & ",ChangeDate=GETDATE()" &
                    " WHERE ClientId = " & lClientId
                ExecuteSQL(sSQL)
            Next

            LoadList()
        Catch ex As Exception
            MsgBox("Error setting lead status:  " & ex.Message)
        Finally
            pnlLeadStatus.Visible = False
            dgList.Enabled = True
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub cmdSolicitSentDateOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSolicitSentDateOK.Click
        Try
            If dgList.SelectedRows.Count = 0 Then Exit Sub
            If Not IsDate(txtSolicitSentDate.Text) Or Trim(txtSolicitSentDate.Text) = "" Then
                MsgBox("Not a valid date")
                Exit Sub
            End If
            Me.Cursor = Cursors.WaitCursor
            For Each row As DataGridViewRow In dgList.SelectedRows
                Dim sSQL As String = "", lClientId As Long = row.Cells("Clients_ClientId").Value
                sSQL = "UPDATE Clients SET SolicitSentDate = " & QuoStr(txtSolicitSentDate.Text) & "," &
                    " ChangeType = 2, ChangeUser = " & QuoStr(AppData.UserId) & ",ChangeDate=GETDATE()" &
                    " WHERE ClientId = " & lClientId
                ExecuteSQL(sSQL)
            Next

            LoadList()
        Catch ex As Exception
            MsgBox("Error setting solicitation sent date:  " & ex.Message)
        Finally
            pnlSolicitSentDate.Visible = False
            dgList.Enabled = True
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub cmdSolicitTypeOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSolicitTypeOK.Click
        Try
            If dgList.SelectedRows.Count = 0 Then Exit Sub
            If Trim(cboSolicitType.Text) = "" Then
                MsgBox("Must enter a value")
                Exit Sub
            End If
            Me.Cursor = Cursors.WaitCursor
            For Each row As DataGridViewRow In dgList.SelectedRows
                Dim sSQL As String = "", lClientId As Long = row.Cells("Clients_ClientId").Value
                sSQL = "UPDATE Clients SET SolicitType = " & QuoStr(cboSolicitType.Text) & "," &
                    " ChangeType = 2, ChangeUser = " & QuoStr(AppData.UserId) & ",ChangeDate=GETDATE()" &
                    " WHERE ClientId = " & lClientId
                ExecuteSQL(sSQL)
            Next

            LoadList()
        Catch ex As Exception
            MsgBox("Error setting solicitation type:  " & ex.Message)
        Finally
            pnlSolicitType.Visible = False
            dgList.Enabled = True
            Me.Cursor = Cursors.Default
        End Try
    End Sub


    Private Sub cmdClientCoordinatorNameCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdClientCoordinatorNameCancel.Click
        pnlClientCoordinatorName.Visible = False
        dgList.Enabled = True
    End Sub

    Private Sub cmdClientCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdClientCancel.Click
        pnlClient.Visible = False
        dgList.Enabled = True
    End Sub

    Private Sub cmdFactorCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdFactorCancel.Click
        pnlFactor.Visible = False
        dgList.Enabled = True
    End Sub

    Private Sub cmdECUParentCancel_Click(sender As Object, e As System.EventArgs) Handles cmdECUParentCancel.Click
        pnlECUParent.Visible = False
        dgList.Enabled = True
    End Sub

    Private Sub cmdLeadFollowUpDateCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLeadFollowUpDateCancel.Click
        pnlLeadFollowUpDate.Visible = False
        dgList.Enabled = True
    End Sub

    Private Sub cmdLeadInfoSentFlCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLeadInfoSentFlCancel.Click
        pnlLeadInfoSentFl.Visible = False
        dgList.Enabled = True
    End Sub

    Private Sub cmdLeadMailDateCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLeadMailDateCancel.Click
        pnlLeadMailDate.Visible = False
        dgList.Enabled = True
    End Sub

    Private Sub cmdLeadStatusCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLeadStatusCancel.Click
        pnlLeadStatus.Visible = False
        dgList.Enabled = True
    End Sub

    Private Sub cmdSolicitSentDateCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSolicitSentDateCancel.Click
        pnlSolicitSentDate.Visible = False
        dgList.Enabled = True
    End Sub

    Private Sub cmdSolicitTypeCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSolicitTypeCancel.Click
        pnlSolicitType.Visible = False
        dgList.Enabled = True
    End Sub

    Private Sub cmdAuditFlOK_Click(sender As Object, e As EventArgs) Handles cmdAuditFlOK.Click
        Dim row As DataGridViewRow, assetids As New StringBuilder, sql As New StringBuilder
        Try
            If dgList.SelectedRows.Count = 0 Then Exit Sub
            Me.Cursor = Cursors.WaitCursor
            assetids.Clear()
            For Each row In dgList.SelectedRows
                If assetids.Length > 0 Then
                    assetids.Append(",")
                End If
                assetids.Append(QuoStr(row.Cells("AssetId").Value))
            Next
            sql.Clear()
            sql.Append("UPDATE Assets SET AuditFl = ").Append(IIf(chkAuditFl.CheckState = CheckState.Checked, "1", "NULL"))
            sql.Append(" WHERE ClientId = ").Append(m_ClientId).Append(" AND LocationId = ").Append(m_LocationId).Append(" AND AssessmentId = ").Append(m_AssessmentId)
            sql.Append(" AND AssetId IN (").Append(assetids.ToString).Append(")").Append(" AND TaxYear = ").Append(m_TaxYear)
            ExecuteSQL(sql.ToString)
        Catch ex As Exception
            MsgBox("Error setting audit flag:  " & ex.Message)
        Finally
            pnlAuditFl.Visible = False
            dgList.Enabled = True
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub cmdAuditFlCancel_Click(sender As Object, e As EventArgs) Handles cmdAuditFlCancel.Click
        pnlAuditFl.Visible = False
        dgList.Enabled = True
    End Sub

    Private Sub mnuContextSetRenditionAuditFl_Click(sender As Object, e As EventArgs) Handles mnuContextSetRenditionAuditFl.Click
        Dim row As DataGridViewRow, i As Integer
        Try
            If iMouseClickColIndex < 0 Then
                Exit Sub
            End If
            If dgList.SelectedRows.Count <= 0 Then
                Exit Sub
            End If

            i = Val(Microsoft.VisualBasic.Right(dgList.Columns(iMouseClickColIndex).Name, 1))
            row = dgList.SelectedRows(0)
            pnlAuditFl.Visible = True
            pnlAuditFl.BringToFront()
            dgList.Enabled = False
            Exit Sub

        Catch ex As Exception
            MsgBox("Error setting audit flag:  " & ex.Message)
        End Try
    End Sub

    Private Sub mnuContextSetRenditionAllocationPct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuContextSetRenditionServiceLevel.Click,
            mnuContextSetRenditionInterstateAllocation.Click
        Dim row As DataGridViewRow, i As Integer
        Try
            If iMouseClickColIndex < 0 Then
                Exit Sub
            End If
            If dgList.SelectedRows.Count <= 0 Then
                Exit Sub
            End If

            If Not (InStr(dgList.Columns(iMouseClickColIndex).Name, "EntityFactorCodeOverride") = 1 Or
                    InStr(dgList.Columns(iMouseClickColIndex).Name, "EntityFactorCode") = 1 Or
                    InStr(dgList.Columns(iMouseClickColIndex).Name, "ClientFactorCode") = 1 Or
                    InStr(dgList.Columns(iMouseClickColIndex).Name, "ClientMappingFactorCode") = 1 Or
                    InStr(dgList.Columns(iMouseClickColIndex).Name, "ClientMappingFactorCodeOverride") = 1 Or
                    InStr(dgList.Columns(iMouseClickColIndex).Name, "AllocationPct") = 1 Or
                    InStr(dgList.Columns(iMouseClickColIndex).Name, "InterstateAllocationPct") = 1) Then
                Exit Sub
            End If

            If sender.name = mnuContextSetRenditionServiceLevel.Name Then
                eAllocationPctType = enumAllocationPctType.eServiceLevel
            Else
                eAllocationPctType = enumAllocationPctType.eInterstate
            End If

            i = Val(Microsoft.VisualBasic.Right(dgList.Columns(iMouseClickColIndex).Name, 1))
            row = dgList.SelectedRows(0)
            lFactorEntityId = row.Cells("FactorEntityId" & i).Value
            If eAllocationPctType = enumAllocationPctType.eServiceLevel Then
                lblAllocation.Text = "Service Level"
            Else
                lblAllocation.Text = "Interstate Allocation"
            End If
            txtAllocationPct.Text = ""
            pnlRenditionAllocationPct.Visible = True
            pnlRenditionAllocationPct.BringToFront()
            dgList.Enabled = False
            Exit Sub

        Catch ex As Exception
            MsgBox("Error setting allocation percentage:  " & ex.Message)
        End Try

    End Sub


    Private Sub cmdAllocationPctOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAllocationPctOK.Click
        Dim sAssets() As String, i As Integer = 0, row As DataGridViewRow, sPct As String = ""
        Try
            sPct = txtAllocationPct.Text.Trim

            If Not IsNumeric(sPct) Or Trim(sPct) = "" Then
                MsgBox("Not a valid amount")
                Exit Sub
            End If

            Me.Cursor = Cursors.WaitCursor
            ReDim sAssets(dgList.SelectedRows.Count - 1)
            For Each row In dgList.SelectedRows
                sAssets(i) = row.Cells("AssetId").Value
                i = i + 1
            Next
            SaveAssetAllocationPct(m_ClientId, m_LocationId, m_AssessmentId, m_TaxYear, sAssets, lFactorEntityId, eAllocationPctType, CDbl(sPct) / 100)
        Catch ex As Exception
            MsgBox("Error setting allocation percentage:  " & ex.Message)
        Finally
            pnlRenditionAllocationPct.Visible = False
            dgList.Enabled = True
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub cmdAllocationPctCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAllocationPctCancel.Click
        pnlRenditionAllocationPct.Visible = False
        dgList.Enabled = True
    End Sub

    Private Sub cmdNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNew.Click
        If m_ListType = enumListType.enumAssets Then
            AddAsset(m_ClientId, m_LocationId, m_AssessmentId, m_TaxYear)
        End If
    End Sub
    Private Sub mnuContextAddJurisdiction_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuContextAddJurisdiction.Click
        Try
            If m_ListType <> enumListType.enumAssessmentBPP And
                    m_ListType <> enumListType.enumRenditions And
                    m_ListType <> enumListType.enumAssessmentRE Then Exit Sub

            If iMouseClickColIndex >= 0 Then
                If dgList.SelectedRows.Count > 0 Then
                    Dim row As DataGridViewRow
                    Dim colAssessments As New Collection, structAssess As New structAssessment
                    Dim sStateCd As String = ""
                    For Each row In dgList.SelectedRows
                        If sStateCd = "" Then
                            sStateCd = row.Cells("StateCd").Value
                        Else
                            If row.Cells("StateCd").Value <> sStateCd Then
                                Throw New ApplicationException("All locations must reside in same state")
                            End If
                        End If
                        If UnNullToDouble(row.Cells("AssessmentId").Value) > 0 Then
                            With structAssess
                                .ClientId = row.Cells("ClientId").Value
                                .LocationId = row.Cells("LocationId").Value
                                .AssessmentId = row.Cells("AssessmentId").Value
                                .Description = Trim(UnNullToString(row.Cells("Assessors_Name").Value)) & "_" & Trim(UnNullToString(row.Cells("AcctNum").Value))
                                .TaxYear = m_TaxYear
                                .AssessorId = row.Cells("AssessorId").Value
                            End With
                            colAssessments.Add(structAssess)
                        End If
                    Next

                    Dim frml = New frmAddJurisdictions
                    frml.Assessments = colAssessments
                    If m_ListType = enumListType.enumAssessmentBPP Or m_ListType = enumListType.enumRenditions Then
                        frml.PropType = enumTable.enumLocationBPP
                    ElseIf m_ListType = enumListType.enumAssessmentRE Then
                        frml.PropType = enumTable.enumLocationRE
                    Else
                        frml.PropType = 0
                    End If
                    frml.StateCd = sStateCd
                    frml.TaxYear = m_TaxYear
                    frml.MdiParent = MDIParent1
                    frml.Show()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error adding jurisdictions:  " & ex.Message)
        End Try
    End Sub



    Private Sub mnuContextModifyQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuContextModifyQuery.Click
        Try
            OpenQueryProperties(dgList.Rows(iMouseClickRowIndex).Cells("QueryId").Value, dgList.Rows(iMouseClickRowIndex).Cells("QueryType").Value)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub mnuContextCopy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuContextCopy.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            If iMouseClickColIndex >= 0 Then
                If dgList.SelectedRows.Count > 0 Then
                    Dim row As DataGridViewRow
                    For Each row In dgList.SelectedRows
                        Select Case m_ListType
                            Case enumListType.enumQueryList
                                Dim sName As String = Trim(InputBox("Name of new query"))
                                If sName <> "" Then
                                    Dim sError As String = ""
                                    Dim lId As Long = row.Cells("QueryId").Value
                                    If Not CopyQuery(lId, sName, sError) Then
                                        Throw New ApplicationException(sError)
                                    End If
                                End If
                        End Select
                    Next
                End If
            End If
        Catch ex As Exception
            MsgBox("Error copying:  " & ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub dgList_ColumnWidthChanged(sender As Object, e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles dgList.ColumnWidthChanged
        If bLoading = False Then AppData.ColumnWidthChanged = True
    End Sub

    Private Sub mnuContextSetBusinessUnit_Click(sender As Object, e As System.EventArgs) Handles mnuContextSetBusinessUnit.Click
        Try
            If dgList.SelectedRows.Count = 0 Then Exit Sub
            Dim bFoundBadOne As Boolean = False
            Dim lClientId As Long = dgList.SelectedRows(0).Cells("ClientId").Value
            Dim sProp As String = IIf(m_ListType = enumListType.enumAssessmentBPP Or m_ListType = enumListType.enumRenditions, "BPP", "RE")
            Dim row As DataGridViewRow
            For Each row In dgList.SelectedRows
                If lClientId <> row.Cells("ClientId").Value Then
                    bFoundBadOne = True
                    Exit For
                End If
            Next
            If bFoundBadOne Then
                MsgBox("All selected accounts must belong to the same client")
                Exit Sub
            End If
            cboBusinessUnit.Items.Clear()
            cboBusinessUnit.Text = ""
            Dim sSQL As New StringBuilder
            sSQL.Append(" SELECT 0 AS BusinessUnitId, '' AS Name")
            sSQL.Append(" UNION SELECT BusinessUnitId, RTRIM(LTRIM(Name)) AS Name")
            sSQL.Append(" FROM BusinessUnits ").Append(" WHERE ClientId = ").Append(lClientId)
            sSQL.Append(" ORDER BY Name")
            colBusinessUnits = New Collection
            LoadComboBox(sSQL.ToString, cboBusinessUnit, colBusinessUnits)
            dgList.Enabled = False
            pnlBusinessUnit.Visible = True
            pnlBusinessUnit.BringToFront()
        Catch ex As Exception
            MsgBox("Error setting business unit:  " & ex.Message)
        End Try
    End Sub

    Private Sub cmdBusinessUnitCancel_Click(sender As Object, e As EventArgs) Handles cmdBusinessUnitCancel.Click
        pnlBusinessUnit.Visible = False
        dgList.Enabled = True
    End Sub

    Private Sub cmdBusinessUnitOK_Click(sender As Object, e As EventArgs) Handles cmdBusinessUnitOK.Click
        Try
            Dim lId As Long = 0, sSQL As New StringBuilder, i As Integer, row As DataGridViewRow

            If colBusinessUnits.Contains(cboBusinessUnit.Text) Then
                lId = colBusinessUnits(cboBusinessUnit.Text)
            End If
            sSQL.Clear()
            i = 0
            For Each row In dgList.SelectedRows
                If row.Cells("AssessmentId").Value.ToString.Trim <> "" Then
                    sSQL.Append(" UPDATE Assessments").Append(IIf(m_ListType = enumListType.enumAssessmentBPP Or m_ListType = enumListType.enumRenditions, "BPP", "RE"))
                    sSQL.Append(" SET BusinessUnitId = ").Append(IIf(lId = 0, "NULL", lId.ToString)).Append(", ChangeDate = GETDATE(), ChangeUser = ").Append(QuoStr(AppData.UserId))
                    sSQL.Append(", ChangeType = 2")
                    sSQL.Append(" WHERE AssessmentId = ").Append(row.Cells("AssessmentId").Value).Append(" AND TaxYear = ").Append(m_TaxYear)
                End If
                i = i + 1
                If i > 10 And sSQL.Length > 0 Then
                    ExecuteSQL(sSQL.ToString)
                    sSQL.Clear()
                    i = 0
                End If
            Next
            If sSQL.Length > 0 Then
                ExecuteSQL(sSQL.ToString)
            End If
        Catch ex As Exception
            MsgBox("Error setting business unit:  " & ex.Message)
        Finally
            pnlBusinessUnit.Visible = False
            dgList.Enabled = True
        End Try
    End Sub

    Private Sub mnuContextOpenListOfAssets_Click(sender As Object, e As EventArgs) Handles mnuContextOpenListOfAssets.Click
        Try
            If iMouseClickColIndex >= 0 Then
                If dgList.SelectedRows.Count > 0 Then
                    Dim row As DataGridViewRow = dgList.SelectedRows(0)
                    GridCellDoubleClick(row, enumListType.enumAssets)
                End If
            End If
        Catch ex As Exception
            MsgBox("Error opening prospect:  " & ex.Message)
        End Try

    End Sub

    Private Sub mnuContextOpenAssessmentValues_Click(sender As Object, e As EventArgs) Handles mnuContextOpenAssessmentValues.Click
        Try
            If iMouseClickColIndex >= 0 Then
                If dgList.SelectedRows.Count > 0 Then
                    Dim row As DataGridViewRow = dgList.SelectedRows(0)
                    GridCellDoubleClick(row, enumListType.enumAssessmentBPP)
                End If
            End If
        Catch ex As Exception
            MsgBox("Error opening prospect:  " & ex.Message)
        End Try
    End Sub

    Private Sub cmdConsultantNameOK_Click(sender As Object, e As EventArgs) Handles cmdConsultantNameOK.Click
        Try
            If dgList.SelectedRows.Count = 0 Then Exit Sub
            If Trim(cboConsultantName.Text) = "" Then
                If MsgBox("Are you sure you want to clear the consultant name?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If
            Me.Cursor = Cursors.WaitCursor
            Dim locationids As New Collection, tablename As String = ""
            If m_ListType = enumListType.enumAssessmentRE Then
                tablename = "LocationsRE"
            Else
                tablename = "LocationsBPP"
            End If

            For Each row As DataGridViewRow In dgList.SelectedRows
                If Not locationids.Contains(row.Cells("LocationId").Value.ToString) Then
                    locationids.Add(row.Cells("LocationId").Value.ToString)
                End If
            Next
            Dim sql As New StringBuilder
            For Each locationid As String In locationids
                sql.Append(" UPDATE ").Append(tablename).Append(" SET ConsultantName = " & IIf(cboConsultantName.Text.Trim.Length = 0, "NULL", QuoStr(cboConsultantName.Text)))
                sql.Append(" , ChangeType = 2, ChangeUser = ").Append(QuoStr(AppData.UserId)).Append(" ,ChangeDate=GETDATE()")
                sql.Append(" WHERE LocationId = ").Append(locationid).Append(" AND TaxYear = ").Append(m_TaxYear.ToString)
                If sql.Length > 5000 Then
                    ExecuteSQL(sql.ToString)
                    sql.Clear()
                End If
            Next
            If sql.Length > 0 Then ExecuteSQL(sql.ToString)

            LoadList()
        Catch ex As Exception
            MsgBox("Error setting consultant name:  " & ex.Message)
        Finally
            pnlConsultantName.Visible = False
            dgList.Enabled = True
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub cmdConsultantNameCancel_Click(sender As Object, e As EventArgs) Handles cmdConsultantNameCancel.Click
        pnlConsultantName.Visible = False
        dgList.Enabled = True
    End Sub

    Private Sub mnuContextSetConsultantName_Click(sender As Object, e As EventArgs) Handles mnuContextSetConsultantName.Click
        Try
            If dgList.SelectedRows.Count = 0 Then Exit Sub
            If cboConsultantName.Items.Count = 0 Then
                cboConsultantName.Items.Add("")
                Dim dt As New DataTable
                GetData("SELECT ConsultantName FROM Consultants ORDER BY ConsultantName", dt)
                For Each row As DataRow In dt.Rows
                    cboConsultantName.Items.Add(row("ConsultantName").ToString)
                Next
            End If
            cboConsultantName.Text = ""
            pnlConsultantName.Visible = True
            pnlConsultantName.BringToFront()
            dgList.Enabled = False
        Catch ex As Exception
            MsgBox("Error setting consultant name:  " & ex.Message)
        End Try
    End Sub

    Private Sub LeaseInfo_TextChanged(sender As Object, e As EventArgs) Handles cboLeaseType.TextChanged, txtEquipmentMake.TextChanged,
            txtEquipmentModel.TextChanged, txtLeaseTerm.TextChanged, txtLesseeAddress.TextChanged, txtLesseeName.TextChanged,
            txtLesseeCity.TextChanged, cboLesseeStateCd.TextChanged, txtLesseeZip.TextChanged
        If _FreezeLeaseInfoSettings = False And sender.Font.Italic = True Then
            sender.Font = New Font(Me.Font, FontStyle.Regular)
            Select Case sender.name
                Case txtEquipmentMake.Name
                    _EquipmentMakeChanged = True
                Case txtEquipmentModel.Name
                    _EquipmentModelChanged = True
                Case txtLeaseTerm.Name
                    _LeaseTermChanged = True
                Case txtLesseeAddress.Name
                    _LesseeAddressChanged = True
                Case txtLesseeName.Name
                    _LesseeNameChanged = True
                Case cboLeaseType.Name
                    _LeaseTypeChanged = True
                Case txtLesseeCity.Name
                    _LesseeCityChanged = True
                Case cboLesseeStateCd.Name
                    _LesseeStateCdChanged = True
                Case txtLesseeZip.Name
                    _LesseeZipChanged = True
            End Select
        End If
    End Sub

    Private Sub mnuContextSetLeaseInfo_Click(sender As Object, e As EventArgs) Handles mnuContextSetLeaseInfo.Click
        Try
            If dgList.SelectedRows.Count = 0 Then Exit Sub

            _FreezeLeaseInfoSettings = True
            If cboLeaseType.Items.Count = 0 Then
                cboLeaseType.Items.Add("")
                Dim dt As New DataTable
                GetData("SELECT FieldValue FROM FieldDataDefinition WHERE TableName = 'Assets' AND FieldName = 'LeaseType' ORDER BY FieldValue", dt)
                For Each row As DataRow In dt.Rows
                    cboLeaseType.Items.Add(row("FieldValue").ToString)
                Next
            End If
            If cboLesseeStateCd.Items.Count = 0 Then
                cboLesseeStateCd.Items.Add("")
                For Each sTemp As String In colStateCodes
                    cboLesseeStateCd.Items.Add(sTemp)
                Next
            End If
            cboLeaseType.Text = "Lease type"
            txtLeaseTerm.Text = "Lease term"
            txtLesseeAddress.Text = "Lessee address"
            txtLesseeName.Text = "Lessee name"
            txtLesseeCity.Text = "Lessee city"
            cboLesseeStateCd.Text = "Lessee state"
            txtLesseeZip.Text = "Lessee zip"
            txtEquipmentMake.Text = "Equipment make"
            txtEquipmentModel.Text = "Equipment model"
            cboLeaseType.Font = New Font(cboLeaseType.Font, FontStyle.Italic)
            txtLeaseTerm.Font = New Font(txtLeaseTerm.Font, FontStyle.Italic)
            txtLesseeAddress.Font = New Font(txtLesseeAddress.Font, FontStyle.Italic)
            txtLesseeName.Font = New Font(txtLesseeName.Font, FontStyle.Italic)
            txtLesseeCity.Font = New Font(txtLesseeCity.Font, FontStyle.Italic)
            cboLesseeStateCd.Font = New Font(cboLesseeStateCd.Font, FontStyle.Italic)
            txtLesseeZip.Font = New Font(txtLesseeZip.Font, FontStyle.Italic)
            txtEquipmentMake.Font = New Font(txtEquipmentMake.Font, FontStyle.Italic)
            txtEquipmentModel.Font = New Font(txtEquipmentModel.Font, FontStyle.Italic)
            _EquipmentMakeChanged = False
            _EquipmentModelChanged = False
            _LeaseTermChanged = False
            _LeaseTypeChanged = False
            _LesseeAddressChanged = False
            _LesseeNameChanged = False
            _LesseeCityChanged = False
            _LesseeStateCdChanged = False
            _LesseeZipChanged = False
            _FreezeLeaseInfoSettings = False

            pnlLeaseInfo.Visible = True
            pnlLeaseInfo.BringToFront()
            dgList.Enabled = False
        Catch ex As Exception
            MsgBox("Error setting lease info:  " & ex.Message)
        End Try
    End Sub

    Private Sub cmdLeaseInfoCancel_Click(sender As Object, e As EventArgs) Handles cmdLeaseInfoCancel.Click
        pnlLeaseInfo.Visible = False
        dgList.Enabled = True
    End Sub

    Private Sub cmdLeaseInfoOK_Click(sender As Object, e As EventArgs) Handles cmdLeaseInfoOK.Click
        Dim sAssets() As String, i As Integer = 0, row As DataGridViewRow
        Dim fields As New StringBuilder
        Try
            If _EquipmentMakeChanged Then fields.Append(IIf(fields.Length > 0, ",", "")).Append(" EquipmentMake = ").Append(IIf(txtEquipmentMake.Text.Trim = "", "NULL", QuoStr(txtEquipmentMake.Text)))
            If _EquipmentModelChanged Then fields.Append(IIf(fields.Length > 0, ",", "")).Append(" EquipmentModel = ").Append(IIf(txtEquipmentModel.Text.Trim = "", "NULL", QuoStr(txtEquipmentModel.Text)))
            If _LeaseTermChanged Then fields.Append(IIf(fields.Length > 0, ",", "")).Append(" LeaseTerm = ").Append(IIf(txtLeaseTerm.Text.Trim = "", "NULL", txtLeaseTerm.Text))
            If _LesseeNameChanged Then fields.Append(IIf(fields.Length > 0, ",", "")).Append(" LesseeName = ").Append(IIf(txtLesseeName.Text.Trim = "", "NULL", QuoStr(txtLesseeName.Text)))
            If _LesseeAddressChanged Then fields.Append(IIf(fields.Length > 0, ",", "")).Append(" LesseeAddress = ").Append(IIf(txtLesseeAddress.Text.Trim = "", "NULL", QuoStr(txtLesseeAddress.Text)))
            If _LesseeCityChanged Then fields.Append(IIf(fields.Length > 0, ",", "")).Append(" LesseeCity = ").Append(IIf(txtLesseeCity.Text.Trim = "", "NULL", QuoStr(txtLesseeCity.Text)))
            If _LesseeStateCdChanged Then
                Dim statecd As String = ""
                If cboLesseeStateCd.Text.Trim = "" Then
                    statecd = ""
                Else
                    If colStateNames.Contains(cboLesseeStateCd.Text.Trim) Then
                        statecd = colStateNames(cboLesseeStateCd.Text.Trim)
                    End If
                End If
                fields.Append(IIf(fields.Length > 0, ",", "")).Append(" LesseeStateCd = ").Append(IIf(statecd = "", "NULL", QuoStr(statecd)))
            End If
            If _LesseeZipChanged Then fields.Append(IIf(fields.Length > 0, ",", "")).Append(" LesseeZip = ").Append(IIf(txtLesseeZip.Text.Trim = "", "NULL", QuoStr(txtLesseeZip.Text)))
            If _LeaseTypeChanged Then fields.Append(IIf(fields.Length > 0, ",", "")).Append(" LeaseType = ").Append(IIf(cboLeaseType.Text.Trim = "", "NULL", QuoStr(cboLeaseType.Text)))
            If fields.Length = 0 Then
                MsgBox("No changes to be saved")
                Exit Sub
            End If
            ReDim sAssets(dgList.SelectedRows.Count - 1)
            For Each row In dgList.SelectedRows
                sAssets(i) = row.Cells("AssetId").Value
                i = i + 1
            Next
            Dim sql As New StringBuilder
            For Each assetid As String In sAssets
                sql.Append(" UPDATE Assets SET ").Append(fields.ToString)
                sql.Append(" , ChangeType = 2, ChangeUser = ").Append(QuoStr(AppData.UserId)).Append(" ,ChangeDate=GETDATE()")
                sql.Append(" WHERE ClientId = ").Append(m_ClientId)
                sql.Append(" AND LocationId = ").Append(m_LocationId)
                sql.Append(" AND AssessmentId = ").Append(m_AssessmentId)
                sql.Append(" AND AssetId = ").Append(QuoStr(assetid))
                sql.Append(" AND TaxYear = ").Append(m_TaxYear)
                If sql.Length > 5000 Then
                    ExecuteSQL(sql.ToString)
                    sql.Clear()
                End If
            Next
            If sql.Length > 0 Then ExecuteSQL(sql.ToString)
            LoadList()
        Catch ex As Exception
            MsgBox("Error setting lease info:  " & ex.Message)
        Finally
            pnlLeaseInfo.Visible = False
            dgList.Enabled = True
        End Try
    End Sub

    Private Sub mnuContextDeleteAssets_Click(sender As Object, e As EventArgs) Handles mnuContextDeleteAssets.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            If iMouseClickColIndex >= 0 Then
                If dgList.SelectedRows.Count > 0 Then
                    If MsgBox("Are you sure you want to delete ALL ASSETS for these accounts?", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then Exit Sub
                    Dim row As DataGridViewRow
                    For Each row In dgList.SelectedRows
                        DeleteAssets(row.Cells("ClientId").Value.ToString, row.Cells("LocationId").Value.ToString, row.Cells("AssessmentId").Value.ToString, "", m_TaxYear)
                    Next
                    MsgBox("ALL assets deleted for selected accounts")
                End If
            End If
        Catch ex As Exception
            MsgBox("Error deleting:  " & ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub mnuContextAssignTask_Click(sender As Object, e As EventArgs) Handles mnuContextAssignTask.Click
        Try
            If dgList.SelectedRows.Count = 0 Then Exit Sub

            Dim proptype As String = IIf(m_ListType = enumListType.enumAssessmentBPP Or m_ListType = enumListType.enumRenditions, "P", "R")
            cboTask.Items.Clear()
            cboTask.Text = ""
            Dim sql As New StringBuilder
            sql.Append(" SELECT 0 AS TaskId, '' AS Name")
            sql.Append(" UNION SELECT TaskId, RTRIM(LTRIM(Name)) AS Name")
            sql.Append(" FROM TaskMasterList ORDER BY Name")
            colTasks = New Collection
            LoadComboBox(sql.ToString, cboTask, colTasks)
            dgList.Enabled = False
            pnlTask.Visible = True
            pnlTask.BringToFront()
        Catch ex As Exception
            MsgBox("Error assigning task:  " & ex.Message)
        End Try

    End Sub

    Private Sub cmdTaskOK_Click(sender As Object, e As EventArgs) Handles cmdTaskOK.Click
        Try
            Dim lId As Long = 0, row As DataGridViewRow
            Dim proptype As String
            Select Case m_ListType
                Case enumListType.enumAssessmentBPP, enumListType.enumRenditions
                    proptype = "P"
                Case enumListType.enumAssessmentRE
                    proptype = "R"
                Case Else
                    proptype = ""
            End Select
            If proptype = "" Then
                MsgBox("Must assign tasks from and assessment list")
                Exit Sub
            End If
            Dim taskdate As String = InputBox("Enter Task Date/Time (i.e. 12/31/2022 14:30)")
            If IsDate(taskdate) = False Then
                MsgBox("Enter valid date/time")
                Exit Sub
            End If
            If colTasks.Contains(cboTask.Text) Then
                lId = colTasks(cboTask.Text)
            Else
                MsgBox("Not a valid task")
                Exit Sub
            End If

            Dim clientid As String, locationid As String, assessmentid As String, msg As String
            For Each row In dgList.SelectedRows
                If row.Cells("AssessmentId").Value.ToString.Trim <> "" Then
                    clientid = row.Cells("ClientId").Value.ToString.Trim
                    locationid = row.Cells("LocationId").Value.ToString.Trim
                    assessmentid = row.Cells("AssessmentId").Value.ToString.Trim
                    msg = ""
                    If Not SaveTaskAssignment(m_TaxYear, lId.ToString, proptype, taskdate, clientid, locationid, assessmentid, msg) Then Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("Error assigning tasks:  " & ex.Message)
        Finally
            pnlTask.Visible = False
            dgList.Enabled = True
        End Try
    End Sub

    Private Sub cmdTaskCancel_Click(sender As Object, e As EventArgs) Handles cmdTaskCancel.Click
        pnlTask.Visible = False
        dgList.Enabled = True
    End Sub

    Private Sub mnuContextSetAgency_Click(sender As Object, e As EventArgs) Handles mnuContextSetAgency.Click
        Try
            If dgList.SelectedRows.Count = 0 Then Exit Sub
            Dim sProp As String = IIf(m_ListType = enumListType.enumAssessmentBPP Or m_ListType = enumListType.enumRenditions, "BPP", "RE")
            cboAgency.Items.Clear()
            cboAgency.Text = ""
            Dim sSQL As New StringBuilder
            sSQL.Append(" SELECT 0 AS AgencyId, '' AS AgencyName")
            sSQL.Append(" UNION SELECT AgencyId, RTRIM(LTRIM(AgencyName)) AS AgencyName")
            sSQL.Append(" FROM Agencies ORDER BY AgencyName")
            colagencies = New Collection
            LoadComboBox(sSQL.ToString, cboAgency, colagencies)
            dgList.Enabled = False
            pnlAgency.Visible = True
            pnlAgency.BringToFront()
        Catch ex As Exception
            MsgBox("Error setting agency:  " & ex.Message)
        End Try
    End Sub

    Private Sub cmdAgencyOK_Click(sender As Object, e As EventArgs) Handles cmdAgencyOK.Click
        Try
            Dim lId As Long = 0, sSQL As New StringBuilder, i As Integer, row As DataGridViewRow

            If colAgencies.Contains(cboAgency.Text) Then
                lId = colAgencies(cboAgency.Text)
            End If
            sSQL.Clear()
            i = 0
            For Each row In dgList.SelectedRows
                If row.Cells("AssessmentId").Value.ToString.Trim <> "" Then
                    sSQL.Append(" UPDATE Assessments").Append(IIf(m_ListType = enumListType.enumAssessmentBPP Or m_ListType = enumListType.enumRenditions, "BPP", "RE"))
                    sSQL.Append(" SET AgencyId = ").Append(IIf(lId = 0, "NULL", lId.ToString)).Append(", ChangeDate = GETDATE(), ChangeUser = ").Append(QuoStr(AppData.UserId))
                    sSQL.Append(", ChangeType = 2")
                    sSQL.Append(" WHERE AssessmentId = ").Append(row.Cells("AssessmentId").Value).Append(" AND TaxYear = ").Append(m_TaxYear)
                End If
                i = i + 1
                If i > 10 And sSQL.Length > 0 Then
                    ExecuteSQL(sSQL.ToString)
                    sSQL.Clear()
                    i = 0
                End If
            Next
            If sSQL.Length > 0 Then
                ExecuteSQL(sSQL.ToString)
            End If
        Catch ex As Exception
            MsgBox("Error setting agency:  " & ex.Message)
        Finally
            pnlAgency.Visible = False
            dgList.Enabled = True
        End Try
    End Sub

    Private Sub cmdAgencyCancel_Click(sender As Object, e As EventArgs) Handles cmdAgencyCancel.Click
        pnlAgency.Visible = False
        dgList.Enabled = True
    End Sub

    Private Sub mnuContextCreateEvent_Click(sender As Object, e As EventArgs) Handles mnuContextCreateEvent.Click
        Try
            If m_ListType <> enumListType.enumAssessmentBPP And
                    m_ListType <> enumListType.enumRenditions And
                    m_ListType <> enumListType.enumAssessmentRE Then Exit Sub
            If dgList.SelectedRows.Count = 0 Then Exit Sub

            Dim proptype As String = IIf(m_ListType = enumListType.enumAssessmentBPP Or m_ListType = enumListType.enumRenditions, "BPP", "RE")
            cboEvents.Items.Clear()
            cboEvents.Text = ""
            txtEventDate.Text = ""
            txtEventNote.Text = ""
            txtEventValue.Text = ""

            Dim sql As New StringBuilder
            sql.Append("SELECT EventId, RTRIM(LTRIM(EventName)) AS EventName")
            sql.Append(" FROM EventList").Append(proptype).Append(" ORDER BY EventName")
            colEvents = New Collection
            LoadComboBox(sql.ToString, cboEvents, colEvents)
            dgList.Enabled = False
            pnlEvent.Visible = True
            pnlEvent.BringToFront()
        Catch ex As Exception
            MsgBox("Error creating event:  " & ex.Message)
        End Try
    End Sub

    Private Sub cmdEventOK_Click(sender As Object, e As EventArgs) Handles cmdEventOK.Click
        Try
            Dim lId As Long = 0, sSQL As New StringBuilder, i As Integer, row As DataGridViewRow
            If cboEvents.Text.Trim = "" Then Exit Sub

            If colEvents.Contains(cboEvents.Text) Then
                lId = colEvents(cboEvents.Text)
            End If
            sSQL.Clear()
            i = 0
            For Each row In dgList.SelectedRows
                If row.Cells("AssessmentId").Value.ToString.Trim <> "" Then
                    SaveEvent(IIf(m_ListType = enumListType.enumAssessmentBPP Or m_ListType = enumListType.enumRenditions, "AssessmentsBPPEvents", "AssessmentsREEvents"),
                        lId.ToString, txtEventDate.Text, txtEventValue.Text, txtEventNote.Text,
                        row.Cells("ClientId").Value, row.Cells("LocationId").Value, row.Cells("AssessmentId").Value, m_TaxYear)
                End If
            Next
        Catch ex As Exception
            MsgBox("Error creating event:  " & ex.Message)
        Finally
            pnlEvent.Visible = False
            dgList.Enabled = True
        End Try
    End Sub

    Private Sub cmdEventCancel_Click(sender As Object, e As EventArgs) Handles cmdEventCancel.Click
        pnlEvent.Visible = False
        dgList.Enabled = True
    End Sub


    'Private Sub chkAssetsLoadedFl_CheckedChanged(sender As Object, e As EventArgs) Handles chkAssetsLoadedFl.CheckedChanged
    '    If bLoading Then Exit Sub
    '    UpdateAssetStatus("AssetsLoadedFl", IIf(chkAssetsLoadedFl.CheckState = CheckState.Checked, "1", "0"))
    'End Sub
    'Private Sub chkAssetsVerifiedFl_CheckedChanged(sender As Object, e As EventArgs) Handles chkAssetsVerifiedFl.CheckedChanged
    '    If bLoading Then Exit Sub
    '    UpdateAssetStatus("AssetsVerifiedFl", IIf(chkAssetsVerifiedFl.CheckState = CheckState.Checked, "1", "0"))
    'End Sub
    'Private Sub UpdateAssetStatus(field As String, value As String)
    '    Dim serror As String = ""

    '    Dim clsassess As New clsAssessmentBPP
    '    clsassess.ClientId = m_ClientId
    '    clsassess.LocationId = m_LocationId
    '    clsassess.AssessmentId = m_AssessmentId
    '    clsassess.TaxYear = m_TaxYear
    '    If Not clsassess.UpdateAssetStatus(field, value, serror) Then
    '        MsgBox("Unable to save the rendition status:  Error=" & serror)
    '    End If
    '    clsassess = Nothing
    'End Sub
End Class
