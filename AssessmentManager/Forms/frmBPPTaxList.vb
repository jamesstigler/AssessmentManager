Public Class frmBPPTaxList
    Private bActivated As Boolean
    Private m_ClientId As Long
    Private m_LocationId As Long
    Private m_AssessmentId As Long
    Private m_TaxYear As Integer
    Private m_AssessorId As Long

    Private DBUpdate() As typeDBUpdateInfo
    Private bChanged As Boolean
    Private sStateCd As String
    Private colFactoringEntities As Collection
    Private colAssessors As Collection
    Private iMouseClickColIndex As Integer = 0
    Private lClientRenditionValueDefault As Long = 0


    Private Structure structHistory
        Friend iTaxYear As Integer
        Friend dAmount As Double
    End Structure


    Public Property TaxYear() As Integer
        Get
            Return m_TaxYear
        End Get
        Set(ByVal value As Integer)
            m_TaxYear = value
        End Set
    End Property
    Public Property AssessorId() As Long
        Get
            Return m_AssessorId
        End Get
        Set(ByVal value As Long)
            m_AssessorId = value
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

    Private Sub InitInfo()
        Dim DBPrimaryKeys(1) As typeDBUpdateInfo, l As Long

        DBPrimaryKeys(0).sTable = "AssessmentsBPP"
        DBPrimaryKeys(0).bAllowInsert = False
        ReDim DBPrimaryKeys(0).PrimaryKeys(3)
        DBPrimaryKeys(0).PrimaryKeys(0).sField = "ClientId"
        DBPrimaryKeys(0).PrimaryKeys(1).sField = "LocationId"
        DBPrimaryKeys(0).PrimaryKeys(2).sField = "AssessmentId"
        DBPrimaryKeys(0).PrimaryKeys(3).sField = "TaxYear"

        DBPrimaryKeys(1).sTable = "LocationsBPP"
        DBPrimaryKeys(1).bAllowInsert = False
        ReDim DBPrimaryKeys(1).PrimaryKeys(2)
        DBPrimaryKeys(1).PrimaryKeys(0).sField = "ClientId"
        DBPrimaryKeys(1).PrimaryKeys(1).sField = "LocationId"
        DBPrimaryKeys(1).PrimaryKeys(2).sField = "TaxYear"

        InitControls(Me, DBUpdate, DBPrimaryKeys)
        For l = 0 To UBound(DBUpdate)
            If UBound(DBUpdate(l).PrimaryKeys) = 3 Then
                DBUpdate(l).PrimaryKeys(0).vValue = m_ClientId
                DBUpdate(l).PrimaryKeys(1).vValue = m_LocationId
                DBUpdate(l).PrimaryKeys(2).vValue = m_AssessmentId
                DBUpdate(l).PrimaryKeys(3).vValue = m_TaxYear
                DBUpdate(l).bAllowInsert = True
            Else
                DBUpdate(l).PrimaryKeys(0).vValue = m_ClientId
                DBUpdate(l).PrimaryKeys(1).vValue = m_LocationId
                DBUpdate(l).PrimaryKeys(2).vValue = m_TaxYear
                DBUpdate(l).bAllowInsert = True

            End If
        Next

    End Sub

    Private Sub frmBPPAssessment_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If bActivated Then Exit Sub



        InitInfo()
        RefreshData()

        bActivated = True

    End Sub


    Private Function RefreshData() As Boolean
        Dim sError As String = "", dt As New DataTable, sSQL As String = "", dr As DataRow, i As Integer = 0
        Dim lParentAssessmentId = 0

        Try
            MDIParent1.ShowStatus("Loading, please wait...")
            txtAcctNum.Text = "" : txtConsultantName.Text = "" : chkInterstateAllocationFl.Checked = False

            sSQL = "SELECT c.ClientId, l.LocationId, a.AssessmentId,isnull(l.StateCd,'') as StateCd,a.InactiveFl," &
                " isnull(c.Name,'') as Name, isnull(l.Address,'') as Address, isnull(l.City,'') as City," &
                " isnull(a.AcctNum,'') as AcctNum, ISNULL(a.AssessorId,0) AS AssessorId,a.Comment,a.ValueProtestFl,a.FreeportProtestFl," &
                " a.ValueProtestMailedDate,a.ValueProtestHearingDate,a.ValueProtestStatus,a.ValueProtestDeadlineDate,a.ValueProtestCMRRR," &
                " a.FreeportProtestMailedDate,a.FreeportProtestHearingDate,a.FreeportProtestStatus,a.FreeportProtestDeadlineDate,a.FreeportProtestCMRRR," &
                " a.RenditionCompleteFl, a.RenditionCompleteDate," &
                " a.AssetsLoadedFl, a.AssetsLoadedDate," &
                " a.AssetsVerifiedFl, a.AssetsVerifiedDate, a.RenditionExtFl," &
                " a.RenditionCMRRR, a.RenditionMailedDate,ISNULL(l.ClientLocationId,'') AS ClientLocationId," &
                " a.RenditionExtCMRRR, a.RenditionExtMailedDate,a.ClientRenditionValue,ISNULL(a.ParentAssessmentId,0) AS ParentAssessmentId," &
                " (select (rtrim(Name) + ', ' + StateCd) from Assessors where AssessorId = a.AssessorId and TaxYear = " & m_TaxYear & ") as AssessorName," &
                " ISNULL(l.ConsultantName,ISNULL(c.BPPConsultantName,'')) AS ConsultantName, a.AccountInvoicedStatus," &
                " ISNULL(a.InterstateAllocationFl,ISNULL(c.InterstateAllocationFl,0)) AS InterstateAllocationFl," &
                " ISNULL(l.SICCode,ISNULL(c.SICCode,'')) AS SICCode"
            For i = 1 To 5
                sSQL = sSQL & ", a.FactorEntityId" & i &
                ",isnull ((select Name from FactorEntities where FactorEntityId = a.FactorEntityId" & i &
                " AND StateCd = l.StateCd),'') AS FactorEntityName" & i
            Next
            sSQL = sSQL & " FROM Clients c, LocationsBPP l, AssessmentsBPP a" &
                " WHERE c.ClientId = a.ClientId AND l.ClientId = a.ClientId and l.LocationId = a.LocationId" &
                " AND l.TaxYear = a.TaxYear AND a.ClientId = " & m_ClientId & " AND a.LocationId = " & m_LocationId &
                " AND a.AssessmentId = " & m_AssessmentId & " AND a.TaxYear = " & m_TaxYear

            GetData(sSQL, dt)
            dr = dt.Rows(0)
            sStateCd = UnNullToString(dr("StateCd"))
            txtAcctNum.Text = UnNullToString(dr("AcctNum"))
            txtConsultantName.Text = dr("ConsultantName").ToString.Trim
            txtSICCode.Text = dr("SICCode").ToString.Trim
            If dr("InterstateAllocationFl").ToString = "True" Then chkInterstateAllocationFl.Checked = True
            m_AssessorId = dr("AssessorId")
            lParentAssessmentId = dr("ParentAssessmentId")
            Me.Text = m_TaxYear & " BPP Tax List:  " & Trim(dr("Name")) & "   " & Trim(dr("Address")) & "   " &
                Trim(dr("City")) & " " & Trim(dr("StateCd")) & "   " & Trim(dr("AcctNum"))

            RefreshControls(Me, dt, "AssessmentsBPP")
            RefreshControls(Me, dt, "LocationsBPP")
            LoadDropDowns(dr("FactorEntityName1"), dr("FactorEntityName2"), dr("FactorEntityName3"),
                dr("FactorEntityName4"), dr("FactorEntityName5"), UnNullToString(dr("AssessorName")))

            LoadJurisdictions()
            LoadRenditionTotals(dr("ClientRenditionValue"))
            LoadECU(lParentAssessmentId)
            LoadComments()

            Return True
        Catch ex As Exception
            MsgBox("Error in RefreshData:  " & ex.Message)
            Return False
        Finally
            MDIParent1.ShowStatus()
        End Try
    End Function
    Private Function LoadECU(ByVal lParentAssessmentId As Long) As Boolean
        Try
            dgECU.Columns.Clear()

            Dim sqlselect = New StringBuilder
            sqlselect.Append("SELECT CASE WHEN ISNULL(a.ParentAssessmentId,0) = 0 THEN 1 WHEN ISNULL(a.ParentAssessmentId,0) = a.AssessmentId THEN 1 ELSE 0 END AS IsParent,")
            sqlselect.Append(" a.AcctNum, a.AssessmentId, a.TaxYear, ISNULL(d.NotifiedValue,0) AS NotifiedValue")
            sqlselect.Append(" FROM AssessmentsBPP a INNER JOIN AssessmentDetailBPP d")
            sqlselect.Append(" ON a.AssessmentId = d.AssessmentId AND a.TaxYear = d.TaxYear")
            'this account is parent, get children
            sqlselect.Append(" WHERE ( (a.ParentAssessmentId = ").Append(m_AssessmentId).Append(" AND a.TaxYear = ").Append(m_TaxYear).Append(")")
            'this account is a child, get parent
            sqlselect.Append(" OR (a.AssessmentId = ").Append(lParentAssessmentId).Append(" AND a.TaxYear = ").Append(m_TaxYear).Append(")")
            'this account is a child, get other children
            sqlselect.Append(" OR (a.ParentAssessmentId = ").Append(lParentAssessmentId).Append(" AND a.TaxYear = ").Append(m_TaxYear).Append(")")
            'get self
            sqlselect.Append(" OR (a.AssessmentId = ").Append(m_AssessmentId).Append(" AND a.TaxYear = ").Append(m_TaxYear).Append(") )")

            'Dim sql = New StringBuilder
            ''this account is parent, get children
            'sql.Append(" UNION ").Append(sqlselect.ToString).Append(" WHERE a.AssessmentId = ").Append(lParentAssessmentId).Append(" AND a.TaxYear = ").Append(m_TaxYear)
            ''get child accounts if parent has parent as itself
            'sql.Append(" UNION ").Append(sqlselect.ToString).Append(" WHERE a.ParentAssessmentId = ").Append(lParentAssessmentId).Append(" AND a.TaxYear = ").Append(m_TaxYear)
            ''get child accounts if parent does not have itself as parent
            'sql.Append(" UNION ").Append(sqlselect.ToString).Append(" WHERE a.ParentAssessmentId = ").Append(m_AssessmentId).Append(" AND a.TaxYear = ").Append(m_TaxYear)
            ''get this account info
            'sql.Append(sqlselect.ToString).Append(" WHERE a.AssessmentId = ").Append(m_AssessmentId).Append(" AND a.TaxYear = ").Append(m_TaxYear)


            Dim sqlgroup = New StringBuilder
            sqlgroup.Append("SELECT tbl1.IsParent, tbl1.AcctNum, tbl1.AssessmentId, tbl1.TaxYear, MAX(tbl1.NotifiedValue) AS NotifiedValue")
            sqlgroup.Append(" FROM (").Append(sqlselect.ToString).Append(") tbl1 GROUP BY tbl1.IsParent, tbl1.AcctNum, tbl1.AssessmentId, tbl1.TaxYear")
            sqlgroup.Append(" ORDER BY tbl1.IsParent DESC, tbl1.AcctNum")

            Dim dt As DataTable = New DataTable
            Dim lRows As Long = GetData(sqlgroup.ToString, dt)
            Dim bind As BindingSource = New BindingSource
            bind.DataSource = dt
            dgECU.DataSource = bind
            For Each column As DataGridViewColumn In dgECU.Columns
                Dim font As New Font(dgECU.DefaultCellStyle.Font.FontFamily, 8.25, FontStyle.Regular)
                column.HeaderCell.Style.Font = font
                column.DefaultCellStyle.Font = font
                Select Case column.Name
                    Case "AcctNum"
                        column.HeaderText = "Account"
                        column.Width = 150
                    Case "NotifiedValue"
                        column.HeaderText = "Notified"
                        column.DefaultCellStyle.Format = csInt
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        column.Width = 70
                    Case Else
                        column.Visible = False
                End Select
            Next

            Return True
        Catch ex As Exception
            MsgBox("Error loading jurisdictions:  " & ex.Message)
            Return False
        End Try
    End Function

    Private Function LoadRenditionTotals(ByVal oClientRenditionValue As Object) As Boolean
        Dim dt As New DataTable, ds As DataSet
        Dim dtValues As New DataTable

        ds = GetAssetList(m_ClientId, m_LocationId, m_AssessmentId, m_TaxYear, 0, True, False, True, False, False, False)
        dtValues = ds.Tables("ReturnTypeSumOfValues").Copy
        lClientRenditionValueDefault = 0
        If dtValues.Columns.Contains("SumOfClientValue1") Then
            lClientRenditionValueDefault = dtValues.Rows(0)("SumOfClientValue1")
        End If
        If IsDBNull(oClientRenditionValue) Then
            txtClientRendition1.Text = Format(lClientRenditionValueDefault, csInt)
            txtClientRendition1.BackColor = Color.White
        Else
            txtClientRendition1.Text = Format(Val(oClientRenditionValue), csInt)
            txtClientRendition1.BackColor = Color.Yellow
        End If
        If dtValues.Columns.Contains("SumOfClientValue2") Then
            txtClientRendition2.Text = Format(dtValues.Rows(0)("SumOfClientValue2"), csInt)
        End If
        If dtValues.Columns.Contains("SumOfClientValue3") Then
            txtClientRendition3.Text = Format(dtValues.Rows(0)("SumOfClientValue3"), csInt)
        End If
        If dtValues.Columns.Contains("SumOfClientValue4") Then
            txtClientRendition4.Text = Format(dtValues.Rows(0)("SumOfClientValue4"), csInt)
        End If
        If dtValues.Columns.Contains("SumOfClientValue5") Then
            txtClientRendition5.Text = Format(dtValues.Rows(0)("SumOfClientValue5"), csInt)
        End If
        If dtValues.Columns.Contains("SumOfEntityValue1") Then
            txtReclassRendition1.Text = Format(dtValues.Rows(0)("SumOfEntityValue1"), csInt)
        End If
        If dtValues.Columns.Contains("SumOfEntityValue2") Then
            txtReclassRendition2.Text = Format(dtValues.Rows(0)("SumOfEntityValue2"), csInt)
        End If
        If dtValues.Columns.Contains("SumOfEntityValue3") Then
            txtReclassRendition3.Text = Format(dtValues.Rows(0)("SumOfEntityValue3"), csInt)
        End If
        If dtValues.Columns.Contains("SumOfEntityValue4") Then
            txtReclassRendition4.Text = Format(dtValues.Rows(0)("SumOfEntityValue4"), csInt)
        End If
        If dtValues.Columns.Contains("SumOfEntityValue5") Then
            txtReclassRendition5.Text = Format(dtValues.Rows(0)("SumOfEntityValue5"), csInt)
        End If
    End Function

    Private Sub ComboBox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles txtAcctNum.GotFocus, cboAssessor.GotFocus, txtClientLocationId.GotFocus,
            cboFactorEntity1.GotFocus, cboFactorEntity2.GotFocus, cboFactorEntity3.GotFocus,
            cboFactorEntity4.GotFocus, cboFactorEntity5.GotFocus, txtClientRendition1.GotFocus, cboAccountInvoicedStatus.GotFocus
        sender.selectall()
    End Sub

    Private Sub ComboBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles txtAcctNum.TextChanged, cboAssessor.TextChanged, txtClientLocationId.TextChanged,
            cboFactorEntity1.TextChanged, cboFactorEntity2.TextChanged, cboFactorEntity3.TextChanged,
            cboFactorEntity4.TextChanged, cboFactorEntity5.TextChanged, txtClientRendition1.TextChanged, chkRenditionCompleteFl.CheckedChanged,
            cboAccountInvoicedStatus.TextChanged, chkAssetsLoadedFl.CheckedChanged, chkAssetsVerifiedFl.CheckedChanged, chkRenditionExtFl.CheckedChanged
        If bActivated Then bChanged = True
        If bActivated Then
            If sender.name = chkRenditionCompleteFl.Name Then
                If chkRenditionCompleteFl.CheckState = CheckState.Checked Then
                    txtRenditionCompleteDate.Text = Format(Now, csDateTime)
                Else
                    txtRenditionCompleteDate.Text = ""
                End If
            End If
            If sender.name = chkAssetsLoadedFl.Name Then
                If chkAssetsLoadedFl.CheckState = CheckState.Checked Then
                    txtAssetsLoadedDate.Text = Format(Now, csDateTime)
                Else
                    txtAssetsLoadedDate.Text = ""
                End If
            End If
            If sender.name = chkAssetsVerifiedFl.Name Then
                If chkAssetsVerifiedFl.CheckState = CheckState.Checked Then
                    txtAssetsVerifiedDate.Text = Format(Now, csDateTime)
                Else
                    txtAssetsVerifiedDate.Text = ""
                End If
            End If
        End If
    End Sub

    Private Sub ComboBox_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles txtAcctNum.LostFocus, cboAssessor.LostFocus, txtClientLocationId.LostFocus,
            cboFactorEntity1.LostFocus, cboFactorEntity2.LostFocus, cboFactorEntity3.LostFocus,
            cboFactorEntity4.LostFocus, cboFactorEntity5.LostFocus, txtClientRendition1.LostFocus, chkRenditionCompleteFl.LostFocus,
            cboAccountInvoicedStatus.LostFocus, chkAssetsLoadedFl.LostFocus, chkAssetsVerifiedFl.LostFocus, chkRenditionExtFl.LostFocus
        If bChanged Then
            If TypeOf sender Is ComboBox Then
                If sender.SelectedIndex >= 0 Then
                    If InStr(sender.tag, "EntityId") > 0 Then
                        UpdateDB(sender, DBUpdate, colFactoringEntities)
                    Else
                        UpdateDB(sender, DBUpdate, colAssessors)
                    End If
                End If
            Else
                UpdateDB(sender, DBUpdate)
                If sender.name = "txtClientRendition1" Then
                    If Trim(sender.text) = "" Then
                        sender.backcolor = Color.White
                        sender.text = Format(lClientRenditionValueDefault, csInt)
                    Else
                        sender.backcolor = Color.Yellow
                    End If
                End If
            End If
            bChanged = False
        End If
    End Sub

    Private Function LoadDropDowns(ByVal sName1 As String, ByVal sName2 As String, ByVal sName3 As String, _
            ByVal sName4 As String, ByVal sName5 As String, ByVal sAssessorName As String) As Boolean
        Dim sSQL As String = "", dt As New DataTable, dr As DataRow

        colFactoringEntities = New Collection : colAssessors = New Collection
        cboFactorEntity1.Text = "" : cboFactorEntity2.Text = "" : cboFactorEntity3.Text = ""
        cboFactorEntity4.Text = "" : cboFactorEntity5.Text = ""
        cboAssessor.Text = ""
        cboFactorEntity1.Items.Clear() : cboFactorEntity1.Items.Add("")
        cboFactorEntity2.Items.Clear() : cboFactorEntity2.Items.Add("")
        cboFactorEntity3.Items.Clear() : cboFactorEntity3.Items.Add("")
        cboFactorEntity4.Items.Clear() : cboFactorEntity4.Items.Add("")
        cboFactorEntity5.Items.Clear() : cboFactorEntity5.Items.Add("")
        cboAssessor.Items.Clear() : cboAssessor.Items.Add("")

        sSQL = "Select FactorEntityId, Name from FactorEntities" & _
            " WHERE StateCd = " & QuoStr(sStateCd) & _
            " ORDER BY Name"
        GetData(sSQL, dt)
        For Each dr In dt.Rows
            cboFactorEntity1.Items.Add(dr("Name"))
            cboFactorEntity2.Items.Add(dr("Name"))
            cboFactorEntity3.Items.Add(dr("Name"))
            cboFactorEntity4.Items.Add(dr("Name"))
            cboFactorEntity5.Items.Add(dr("Name"))
            colFactoringEntities.Add(dr("FactorEntityId"), dr("Name"))      'use this to save?
        Next
        cboFactorEntity1.Text = sName1
        cboFactorEntity2.Text = sName2
        cboFactorEntity3.Text = sName3
        cboFactorEntity4.Text = sName4
        cboFactorEntity5.Text = sName5

        sSQL = "Select AssessorId, (Name + ', ' + StateCd) AS Name from Assessors" & _
            " WHERE StateCd = " & QuoStr(sStateCd) &
            " AND TaxYear = " & m_TaxYear &
            " ORDER BY Name"
        GetData(sSQL, dt)
        For Each dr In dt.Rows
            cboAssessor.Items.Add(dr("Name"))
            colAssessors.Add(dr("AssessorId"), dr("Name"))      'use this to save?
        Next
        cboAssessor.Text = sAssessorName
    End Function

    Private Function LoadJurisdictions() As Boolean
        Dim bind As New BindingSource
        Dim sSQL As String = "", i As Integer = 0
        Dim lRows As Long = 0, dtList As New DataTable, JurisdictionList As New List(Of Long)
        Dim CollectorTotal() As structTotals, bFound As Boolean = False
        Dim dgRow() As String, l As Long = 0, d As Double = 0
        Dim dtsource As New DataTable

        Try
            sSQL = BuildTaxBillQuery(m_ClientId, m_LocationId, m_AssessmentId, JurisdictionList,
                0, enumTable.enumLocationBPP, False, False, False, True, False, 0)
            lRows = GetData(sSQL, dtList)

            'MUST ADD FIELDS TO THIS SELECT IF NEW COLUMNS ADDED
            For Each col As DataColumn In dtList.Columns
                Select Case col.ColumnName
                    Case "JurisdictionId", "HasInstallments", "AbatementReductionAmt", "BPPRatio", "ClientAbatementAmt", "ClientFreeportAmt", "Collectors_Name",
                            "FinalValue", "FreeportReductionAmt", "Jurisdictions_FreeportFl", "Jurisdictions_Name", "NotifiedValue", "PenaltyAmt1", "TaxBillAdjAmt1",
                            "TaxBillAdjDesc1", "TaxBillPrintedDate", "TaxDue", "TaxRate", "TaxYear", "TaxableValue"
                        dtsource.Columns.Add(col.ColumnName, col.DataType)
                End Select
            Next
            dtsource.Merge(dtList, True, MissingSchemaAction.Ignore)

            dgJurisdictions.Columns.Clear()
            bind.DataSource = dtsource
            dgJurisdictions.DataSource = bind
            dgCollectors.Columns.Clear()

            'MUST ADD FIELDS TO THIS WITH IF NEW COLUMNS ADDED
            With dgJurisdictions
                .Columns("JurisdictionId").Visible = False
                .Columns("HasInstallments").Visible = False
                With .Columns("TaxYear")
                    .Visible = True
                    .HeaderText = "Tax Year"
                    .Width = 35
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .ReadOnly = True
                End With
                With .Columns("Jurisdictions_FreeportFl")
                    .Visible = True
                    .HeaderText = "Free port"
                    .Width = 30
                    .ReadOnly = True
                End With
                With .Columns("Collectors_Name")
                    .Visible = True
                    .HeaderText = "Collector"
                    .Width = 125
                    .ReadOnly = True
                End With
                With .Columns("Jurisdictions_Name")
                    .Visible = True
                    .HeaderText = "Jurisdiction"
                    .Width = 125
                    .DividerWidth = 2
                    .Frozen = True
                    .ReadOnly = True
                End With
                With .Columns("NotifiedValue")
                    .Visible = True
                    .HeaderText = "Notified"
                    .Width = 70
                    .DefaultCellStyle.Format = csInt
                    .ReadOnly = False
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                With .Columns("FinalValue")
                    .Visible = True
                    .HeaderText = "Final Value"
                    .Width = 70
                    .ReadOnly = False
                    .DefaultCellStyle.Format = csInt
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                With .Columns("ClientAbatementAmt")
                    .Visible = True
                    .HeaderText = "Client Abatement"
                    .Width = 70
                    .ReadOnly = False
                    .DefaultCellStyle.Format = csInt
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                With .Columns("AbatementReductionAmt")
                    .Visible = True
                    .HeaderText = "V1 Abatement"
                    .Width = 70
                    .ReadOnly = False
                    .DefaultCellStyle.Format = csInt
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                With .Columns("ClientFreeportAmt")
                    .Visible = True
                    .HeaderText = "Client Freeport"
                    .Width = 70
                    .ReadOnly = False
                    .DefaultCellStyle.Format = csInt
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                With .Columns("FreeportReductionAmt")
                    .Visible = True
                    .HeaderText = "V1 Freeport"
                    .Width = 70
                    .ReadOnly = False
                    .DefaultCellStyle.Format = csInt
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                With .Columns("BPPRatio")
                    .Visible = True
                    .HeaderText = "Assessor Ratio"
                    .Width = 60
                    .DefaultCellStyle.Format = csPct
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .ReadOnly = True
                End With
                With .Columns("TaxableValue")
                    .Visible = True
                    .HeaderText = "Taxable Value"
                    .Width = 70
                    .ReadOnly = True
                    .DefaultCellStyle.Format = csInt
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                With .Columns("TaxRate")
                    .Visible = True
                    .HeaderText = "Tax Rate"
                    .Width = 75
                    .ReadOnly = True
                    .DefaultCellStyle.Format = csTaxRate
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                With .Columns("TaxBillAdjDesc1")
                    .Visible = True
                    .HeaderText = "Tax Bill Adj Desc"
                    .Width = 60
                    .ReadOnly = False
                End With
                With .Columns("TaxBillAdjAmt1")
                    .Visible = True
                    .HeaderText = "Tax Bill Adj Amt"
                    .Width = 50
                    .ReadOnly = False
                    .DefaultCellStyle.Format = csDol
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                With .Columns("TaxDue")
                    .Visible = True
                    .HeaderText = "Tax Due"
                    .Width = 85
                    .ReadOnly = True
                    .DefaultCellStyle.Format = csDol
                    Dim font As New Font(dgJurisdictions.DefaultCellStyle.Font.FontFamily, 8.25, FontStyle.Bold)
                    Try
                        .DefaultCellStyle.Font = font
                    Finally
                        font.Dispose()
                    End Try
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                With .Columns("PenaltyAmt1")
                    .Visible = True
                    .HeaderText = "Penalty Amt"
                    .Width = 50
                    .ReadOnly = False
                    .DefaultCellStyle.Format = csDol
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                With .Columns("TaxBillPrintedDate")
                    .Visible = True
                    .HeaderText = "Tax Bill Printed Date"
                    .Width = 115
                    .ReadOnly = False
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
            End With

            If lRows = 0 Then
                dgJurisdictions.Enabled = False
            Else
                dgJurisdictions.Enabled = True
            End If

            'collector, tax bill totals and tax bill notes
            With dgCollectors
                .Columns.Add("CollectorId", "CollectorId")
                .Columns.Add("Collectors_Name", "Collector")
                .Columns.Add("TotalTaxDue", "Total Tax Due")
                .Columns.Add("TaxBillLoaded", "Tax Bill Loaded")
                .Columns.Add("TaxBillAcctNum", "Tax Bill Account Number")
                .Columns.Add("TaxBillNotes", "Notes")
                .Columns("CollectorId").Visible = False
                With .Columns("Collectors_Name")
                    .Visible = True
                    .HeaderText = "Collector"
                    .Width = 100
                    .ReadOnly = True
                End With
                With .Columns("TotalTaxDue")
                    .Visible = True
                    .HeaderText = "Total Tax Due"
                    .Width = 85
                    .ReadOnly = True
                    .DefaultCellStyle.Format = csDol
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                With .Columns("TaxBillLoaded")
                    .Visible = True
                    .HeaderText = "Tax Bill Loaded"
                    .Width = 50
                    .ReadOnly = True
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .DefaultCellStyle.BackColor = Color.Gray
                End With
                With .Columns("TaxBillAcctNum")
                    .Visible = True
                    .HeaderText = "Tax Bill Account Number"
                    .Width = 150
                    .ReadOnly = False
                End With
                With .Columns("TaxBillNotes")
                    .Visible = True
                    .HeaderText = "Tax Bill Notes"
                    .Width = 330
                    .ReadOnly = False
                    .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                End With
            End With

            sSQL = BuildTaxBillQuery(m_ClientId, m_LocationId, m_AssessmentId, New List(Of Long), m_TaxYear, enumTable.enumLocationBPP, False, False, True, False, False, 0)
            lRows = GetData(sSQL, dtList)
            d = 0
            For Each dr As DataRow In dtList.Rows
                dgCollectors.Rows.Add(dr("CollectorId").ToString, dr("Collectors_Name").ToString, Format(dr("TotalTaxDue"), csDol), dr("TaxBillLoaded").ToString,
                    dr("TaxBillAcctNum").ToString, dr("TaxBillNotes").ToString)
                d = d + dr("TotalTaxDue")
            Next
            txtTaxBillTotal.Text = Format(d, csDol)


            'Dim drs() As DataRow = dtList.Select("TaxYear = " & m_TaxYear)
            'If drs.Count > 0 Then
            '    'populate dgcollector
            '    Dim bFirst As Boolean = True
            '    ReDim CollectorTotal(0)
            '    ReDim dgRow(3)
            '    CollectorTotal(0).lId = drs(0)("CollectorId")
            '    CollectorTotal(0).sDescription = drs(0)("Collectors_Name")
            '    If drs(0)("TaxBillLoaded") = "Yes" Then CollectorTotal(UBound(CollectorTotal)).bLoaded = True
            '    For Each dr As DataRow In drs
            '        bFound = False
            '        For l = 0 To UBound(CollectorTotal)
            '            If CollectorTotal(l).lId = dr("CollectorId") Then
            '                bFound = True
            '                Exit For
            '            End If
            '        Next
            '        If bFound Then
            '            CollectorTotal(l).dAmount = CollectorTotal(l).dAmount + dr("TaxDue")
            '        Else
            '            ReDim Preserve CollectorTotal(UBound(CollectorTotal) + 1)
            '            CollectorTotal(UBound(CollectorTotal)).lId = dr("CollectorId")
            '            CollectorTotal(UBound(CollectorTotal)).sDescription = dr("Collectors_Name")
            '            CollectorTotal(UBound(CollectorTotal)).dAmount = dr("TaxDue")
            '            If dr("TaxBillLoaded") = "Yes" Then CollectorTotal(UBound(CollectorTotal)).bLoaded = True
            '        End If
            '        d = d + dr("TaxDue")
            '    Next
            '    For Each CollectorItem As structTotals In CollectorTotal
            '        dgRow(0) = CollectorItem.lId
            '        dgRow(1) = CollectorItem.sDescription
            '        dgRow(2) = Format(CollectorItem.dAmount, csDol)
            '        dgRow(3) = IIf(CollectorItem.bLoaded = True, "View", "")
            '        dgCollectors.Rows.Add(dgRow)
            '    Next
            '    dgCollectors.Sort(dgCollectors.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
            '    txtTaxBillTotal.Text = Format(d, csDol)
            'End If

            'value history
            Dim bindHist As New BindingSource
            Dim dtListHist As New DataTable
            dgHistory.Columns.Clear()
            sSQL = "SELECT TaxYear as [Year], MAX(FinalValue) AS [Value]" &
                " FROM AssessmentDetailBPP" &
                " WHERE ClientId = " & m_ClientId &
                " AND LocationId = " & m_LocationId &
                " AND AssessmentId = " & m_AssessmentId &
                " GROUP BY TaxYear ORDER BY TaxYear DESC"
            lRows = GetData(sSQL, dtListHist)
            bindHist.DataSource = dtListHist
            dgHistory.DataSource = bindHist
            For Each column As DataGridViewColumn In dgHistory.Columns
                Dim font As New Font(dgHistory.DefaultCellStyle.Font.FontFamily, 8.25, FontStyle.Regular)
                column.HeaderCell.Style.Font = font
                column.DefaultCellStyle.Font = font
                If column.Name = "Year" Then
                    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    column.Width = 55
                ElseIf column.Name = "Value" Then
                    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = csInt
                    column.Width = 120
                End If
            Next

            Return True
        Catch ex As Exception
            MsgBox("Error loading jurisdictions:  " & ex.Message)
            Return False
        End Try

    End Function

    Private Sub mnuContextDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuContextDelete.Click
        Try
            If iMouseClickColIndex >= 0 Then
                If dgJurisdictions.SelectedRows.Count > 0 Then
                    If MsgBox("Are you sure you want to delete?", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then Exit Sub
                    Dim sSQL As String = ""
                    Dim row As DataGridViewRow
                    For Each row In dgJurisdictions.SelectedRows
                        sSQL = "DELETE AssessmentDetailBPP WHERE ClientId = " & m_ClientId & _
                            " AND LocationId = " & m_LocationId & _
                            " AND AssessmentId = " & m_AssessmentId & _
                            " AND JurisdictionId = " & row.Cells("JurisdictionId").Value & _
                            " AND TaxYear = " & m_TaxYear
                        If sSQL <> "" Then
                            ExecuteSQL(sSQL)
                            WriteSQLToHistory("DeleteAssessmentDetailBPP", sSQL)
                        End If
                    Next
                    sSQL = "UPDATE AssessmentsBPP SET ChangeDate = GETDATE(), ChangeUser = " & QuoStr(AppData.UserId) & ", ChangeType = 2" & _
                        " WHERE ClientId = " & m_ClientId & " AND LocationId = " & m_LocationId & _
                        " AND AssessmentId = " & m_AssessmentId & " AND TaxYear = " & m_TaxYear
                    ExecuteSQL(sSQL)
                    RefreshData()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error deleting:  " & ex.Message)
        End Try

    End Sub

    Private Sub dgJurisdictions_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgJurisdictions.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub

        Try
            If dgJurisdictions.Rows(e.RowIndex).Cells("TaxYear").Value = m_TaxYear Then
                Dim lId As Long = dgJurisdictions.Rows(e.RowIndex).Cells("JurisdictionId").Value
                OpenJurisdiction(lId, m_TaxYear)
            End If
        Catch ex As Exception
            MsgBox("Error opening jurisdiction:  " & ex.Message)
        End Try

    End Sub
    Private Sub dgJurisdictions_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgJurisdictions.CellEndEdit
        Dim sError As String = "", bApplyToAll As Boolean

        bApplyToAll = IIf(MsgBox("Apply to all jurisdictions?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes, True, False)
        If Not UpdateAssessmentDetailBPP(m_ClientId, m_LocationId, m_AssessmentId, dgJurisdictions.Rows(e.RowIndex).Cells("JurisdictionId").Value, m_TaxYear, dgJurisdictions.Columns(e.ColumnIndex).Name, Trim(UnNullToString(dgJurisdictions.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)), bApplyToAll, sError) Then
            MsgBox(sError)
        End If
        dgJurisdictions.Rows(e.RowIndex).ErrorText = String.Empty
        'If bApplyToAll Then RefreshData()

    End Sub

    Private Sub dg_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgJurisdictions.CellMouseDown
        Try
            iMouseClickColIndex = -1
            If dgJurisdictions.Rows(e.RowIndex).Cells("TaxYear").Value = m_TaxYear Then
                Select Case e.Button
                    Case MouseButtons.Left
                    Case MouseButtons.Right
                        iMouseClickColIndex = e.ColumnIndex
                        ContextMenuStrip1.Enabled = True
                        mnuContextPrint.Enabled = True
                        'If dgJurisdictions.Rows(e.RowIndex).Cells("HasInstallments").Value = 1 Then
                        '    mnuContextPrint.Enabled = False
                        'End If
                    Case MouseButtons.Middle
                    Case MouseButtons.XButton1
                    Case MouseButtons.XButton2
                    Case MouseButtons.None
                End Select
            Else
                ContextMenuStrip1.Enabled = False
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmdNewJurisdiction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNewJurisdiction.Click
        Dim frmJ As frmAddJurisdictions, bFound As Boolean = False
        Dim structAssess As New structAssessment
        For Each frm As Form In MDIParent1.MdiChildren
            If frm.Name = "frmAddJurisdictions" Then
                frmJ = frm
                structAssess = frmJ.Assessments(1)
                If structAssess.ClientId = m_ClientId And structAssess.LocationId = m_LocationId And structAssess.AssessmentId = m_AssessmentId And _
                            frmJ.StateCd = sStateCd And frmJ.TaxYear = m_TaxYear And frmJ.PropType = enumTable.enumLocationBPP Then
                    frm.Focus()
                    Exit Sub
                End If
            End If
        Next
        frmJ = New frmAddJurisdictions

        structAssess.ClientId = m_ClientId
        structAssess.LocationId = m_LocationId
        structAssess.AssessmentId = m_AssessmentId
        Dim colAssess As New Collection
        colAssess.Add(structAssess)
        frmJ.Assessments = colAssess
        frmJ.StateCd = sStateCd
        frmJ.PropType = enumTable.enumLocationBPP
        frmJ.TaxYear = m_TaxYear
        frmJ.MdiParent = MDIParent1
        frmJ.Show()
    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        RefreshData()
    End Sub

    Private Sub mnuContextPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuContextPrint.Click
        Try
            If iMouseClickColIndex >= 0 Then
                If dgJurisdictions.SelectedRows.Count > 0 Then
                    Dim JurisdictionList As New List(Of Long)
                    Dim row As DataGridViewRow
                    For Each row In dgJurisdictions.SelectedRows
                        JurisdictionList.Add(row.Cells("JurisdictionId").Value)
                    Next
                    Dim sPDFFileName As String = CleanFileName("TaxBill_" & Me.Text & ".pdf")
                    RunReport(enumReport.enumTaxBill, m_ClientId, m_LocationId, m_AssessmentId, JurisdictionList, m_TaxYear, _
                            enumTable.enumLocationBPP, 0, 0, False, sPDFFileName, "")

                End If
            End If
        Catch ex As Exception
            MsgBox("Error deleting:  " & ex.Message)
        End Try

    End Sub


    Private Sub cmdTaxBillDetail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdTaxBillDetail.Click
        If fraCollectors.Visible Then
            fraCollectors.Visible = False
        Else
            fraCollectors.BringToFront()
            fraCollectors.Visible = True
        End If
    End Sub


    Private Sub dgCollectors_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgCollectors.CellClick
        Try
            Dim sError As String = ""
            If e.RowIndex < 0 OrElse Not e.ColumnIndex = dgCollectors.Columns("TaxBillLoaded").Index Then Return
            If dgCollectors("TaxBillLoaded", e.RowIndex).Value.ToString.ToUpper.StartsWith("Y") = False Then Return
            Dim lCollectorId As Long = CLng(dgCollectors("CollectorId", e.RowIndex).Value)
            If ViewTaxBill("TaxBillsBPP", m_ClientId, m_LocationId, m_AssessmentId, lCollectorId, m_TaxYear,
                    dgCollectors("Collectors_Name", e.RowIndex).Value & "_" & dgCollectors("TaxBillAcctNum", e.RowIndex).Value, False, sError) Then
            Else
                MsgBox("Error opening tax bill:  " & sError)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub dgCollectors_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgCollectors.CellDoubleClick
        Try
            Dim sError As String = ""
            If e.RowIndex < 0 Or e.ColumnIndex = dgCollectors.Columns("TaxBillLoaded").Index Then Return
            Dim lCollectorId As Long = CLng(dgCollectors("CollectorId", e.RowIndex).Value)
            Dim frmI As frmInstallments
            For Each frm As Form In MDIParent1.MdiChildren
                If frm.Name = "frmInstallments" Then
                    frmI = frm
                    If frmI.ClientId = m_ClientId And frmI.LocationId = m_LocationId And frmI.AssessmentId = m_AssessmentId And
                                frmI.TaxYear = m_TaxYear And frmI.PropType = enumTable.enumLocationBPP And frmI.CollectorId = lCollectorId Then
                        frm.Focus()
                        Exit Sub
                    End If
                End If
            Next
            frmI = New frmInstallments
            frmI.ClientId = m_ClientId
            frmI.LocationId = m_LocationId
            frmI.AssessmentId = m_AssessmentId
            frmI.PropType = enumTable.enumLocationBPP
            frmI.CollectorId = lCollectorId
            frmI.TaxYear = m_TaxYear
            frmI.MdiParent = MDIParent1
            frmI.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgCollectors_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgCollectors.CellEndEdit
        Dim sError As String = ""

        If Not UpdateTaxBills(enumTable.enumLocationBPP, m_ClientId, m_LocationId, m_AssessmentId, dgCollectors.Rows(e.RowIndex).Cells("CollectorId").Value, m_TaxYear,
                dgCollectors.Columns(e.ColumnIndex).Name, Trim(UnNullToString(dgCollectors.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)), sError) Then
            MsgBox(sError)
        End If
        dgCollectors.Rows(e.RowIndex).ErrorText = String.Empty
    End Sub

    Private Sub dgCollectors_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgCollectors.CellMouseDown

    End Sub

    Private Sub mnuContextImportTaxBill_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuContextImportTaxBill.Click
        Try
            Dim sError As String = ""
            If dgCollectors.SelectedRows.Count = 0 Then Return
            Dim iRowIndex As Integer = dgCollectors.SelectedRows(0).Index
            Dim lCollectorId As Long = CLng(dgCollectors(0, iRowIndex).Value)
            If lCollectorId = 0 Then Return
            If ImportTaxBill(m_ClientId, m_LocationId, m_AssessmentId, lCollectorId, enumTable.enumLocationBPP, m_TaxYear, AppData.UserId, sError) = True Then
                MsgBox("Tax bill imported")
            Else
                If sError <> "" Then MsgBox("Error importing:  " & sError)
            End If

        Catch ex As Exception
            MsgBox("Error importing tax bill:  " & ex.Message)
        End Try

    End Sub

    Private Sub cmdViewAssessment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewAssessment.Click
        Dim sMsg As String = ""
        If Not OpenBPPAssessment(m_ClientId, m_LocationId, m_AssessmentId, m_TaxYear, sMsg) Then
            MsgBox(sMsg)
        End If
    End Sub

    Private Sub dgJurisdictions_CellPainting(sender As Object, e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgJurisdictions.CellPainting
        Try
            If e.RowIndex >= 0 Then
                If dgJurisdictions.Rows(e.RowIndex).Cells("TaxYear").Value <> m_TaxYear Then
                    e.CellStyle.BackColor = Color.LightGray
                    dgJurisdictions.Rows(e.RowIndex).ReadOnly = True

                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmdECU_Click(sender As Object, e As System.EventArgs) Handles cmdECU.Click
        If fraECU.Visible = False Then
            fraECU.BringToFront()
            fraECU.Visible = True
        Else
            fraECU.Visible = False
        End If
    End Sub

    Private Sub cmdNewComment_Click(sender As System.Object, e As System.EventArgs) Handles cmdNewComment.Click
        Dim sComment As String = Trim(InputBox("Enter comment"))
        If sComment = "" Then Exit Sub
        Dim sError As String = ""
        If UpdateComment("", sComment, sError) Then
            LoadComments()
        Else
            MsgBox(sError)
        End If
    End Sub

    Private Function UpdateComment(ByVal sID As String, ByVal sComment As String, ByRef sError As String) As Boolean
        Try
            sError = "" : sID = Trim(sID) : sComment = Trim(sComment)
            Dim sSQL As String = ""
            If sID = "" Then
                sSQL = "INSERT AssessmentsBPPComments (ClientId,LocationId,AssessmentId,CommentType,TaxYear,Comment,AddUser)" & _
                    " SELECT " & m_ClientId & "," & _
                    m_LocationId & "," & m_AssessmentId & ",1," & m_TaxYear & "," & _
                    QuoStr(sComment) & "," & QuoStr(AppData.UserId)
            Else
                sSQL = "UPDATE AssessmentsBPPComments SET Comment = " & QuoStr(sComment) & "," & _
                    " ChangeType = 2, ChangeUser = " & QuoStr(AppData.UserId) & ", ChangeDate = GETDATE()" & _
                    " WHERE ID = " & sID
            End If
            If ExecuteSQL(sSQL) <> 1 Then
                sError = "Error saving comment"
                Return False
            End If

            Return True
        Catch ex As Exception
            sError = "Error saving comment:  " & ex.Message
            Return False
        End Try
    End Function

    Private Function LoadComments() As Boolean
        Dim sError As String = "", lRows As Long = 0, sSQL As String = ""
        Dim dtList As New DataTable, bind As New BindingSource

        Try
            sSQL = "SELECT ID, ISNULL(ChangeDate,AddDate) AS ChangeDate, Comment FROM AssessmentsBPPComments" & _
                " WHERE ClientId = " & m_ClientId &
                " AND LocationId = " & m_LocationId & _
                " AND AssessmentId = " & m_AssessmentId & _
                " AND TaxYear = " & m_TaxYear & _
                " AND CommentType = 1" & _
                " ORDER BY ID DESC"
            lRows = GetData(sSQL, dtList)

            dgComments.Columns.Clear()
            bind.DataSource = dtList
            dgComments.DataSource = bind

            For Each column As DataGridViewTextBoxColumn In dgComments.Columns
                If IsIndexField(column.Name) Then column.Visible = False
                If column.Name = "ChangeDate" Then
                    column.HeaderText = "Date/Time"
                    column.ReadOnly = True
                    column.Width = 140
                    column.DefaultCellStyle.Format = csDateTime
                End If
                If column.Name = "Comment" Then
                    column.Width = dgComments.Width - 140 - 20
                    column.DefaultCellStyle.WrapMode = DataGridViewTriState.True
                    column.MaxInputLength = 1000
                End If
            Next

            Return True
        Catch ex As Exception
            MsgBox("Error in LoadComments:  " & ex.Message)
            Return False
        End Try
    End Function

    Private Sub cmdExpandComments_Click(sender As System.Object, e As System.EventArgs) Handles cmdExpandComments.Click
        Try
            If Me.WindowState = FormWindowState.Minimized Then Exit Sub
            If cmdExpandComments.Text = "Expand" Then
                cmdExpandComments.Text = "Shrink"
                grpComments.Left = 5
                grpComments.Top = 5
                grpComments.BringToFront()
                grpComments.Width = SplitContainer1.Panel1.Width - 5
                grpComments.Height = SplitContainer1.Panel1.Height
            Else
                cmdExpandComments.Text = "Expand"
                grpComments.Left = 695
                grpComments.Top = 56
                grpComments.Width = 410
                grpComments.Height = 192
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dgComments_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgComments.CellEndEdit
        Dim sError As String = ""

        If Not UpdateComment(dgComments.Rows(e.RowIndex).Cells("ID").Value, UnNullToString(dgComments.Rows(e.RowIndex).Cells("Comment").Value), sError) Then
            MsgBox(sError)
        End If
        dgComments.Rows(e.RowIndex).ErrorText = String.Empty

    End Sub

    Private Sub dgComments_CellMouseDown(sender As System.Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgComments.CellMouseDown
        Select Case e.Button
            Case MouseButtons.Left
            Case MouseButtons.Right
                iMouseClickColIndex = e.ColumnIndex
            Case MouseButtons.Middle
            Case MouseButtons.XButton1
            Case MouseButtons.XButton2
            Case MouseButtons.None
        End Select

    End Sub

    Private Sub mnuContextDeleteComment_Click(sender As System.Object, e As System.EventArgs) Handles mnuContextDeleteComment.Click
        Try
            If iMouseClickColIndex >= 0 Then
                If dgComments.SelectedRows.Count > 0 Then
                    If MsgBox("Are you sure you want to delete?", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then Exit Sub
                    Dim sSQL As String = ""
                    Dim row As DataGridViewRow
                    For Each row In dgComments.SelectedRows
                        sSQL = "DELETE AssessmentsBPPComments WHERE ID = " & row.Cells("ID").Value
                        If sSQL <> "" Then ExecuteSQL(sSQL)
                        LoadComments()
                    Next
                End If
            End If
        Catch ex As Exception
            MsgBox("Error deleting:  " & ex.Message)
        End Try
    End Sub

    Private Sub SplitContainer1_Panel1_Paint(sender As Object, e As PaintEventArgs) Handles SplitContainer1.Panel1.Paint

    End Sub

    Private Sub cmdOpenAssessor_Click(sender As Object, e As EventArgs) Handles cmdOpenAssessor.Click
        Try
            OpenAssessor(colAssessors(cboAssessor.Text), m_TaxYear)
        Catch ex As Exception
        End Try
    End Sub
End Class