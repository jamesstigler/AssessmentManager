Public Class frmREAssessment
    Private bActivated As Boolean
    Private m_ClientId As Long
    Private m_LocationId As Long
    Private m_AssessmentId As Long
    Private m_TaxYear As Integer
    Private m_AssessorId As Long

    Private iMouseClickColIndex As Integer = 0
    Private DBUpdate() As typeDBUpdateInfo
    Private bChanged As Boolean
    Private sStateCd As String
    Private colAssessors As Collection

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

        DBPrimaryKeys(0).sTable = "AssessmentsRE"
        DBPrimaryKeys(0).bAllowInsert = False
        ReDim DBPrimaryKeys(0).PrimaryKeys(3)
        DBPrimaryKeys(0).PrimaryKeys(0).sField = "ClientId"
        DBPrimaryKeys(0).PrimaryKeys(1).sField = "LocationId"
        DBPrimaryKeys(0).PrimaryKeys(2).sField = "AssessmentId"
        DBPrimaryKeys(0).PrimaryKeys(3).sField = "TaxYear"

        DBPrimaryKeys(1).sTable = "LocationsRE"
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

    Private Sub frmREAssessment_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If bActivated Then Exit Sub



        InitInfo()
        RefreshData()

        bActivated = True

    End Sub


    Private Function RefreshData() As Boolean
        Dim sError As String = "", dt As DataTable, sSQL As String, dr As DataRow, i As Integer
        Dim lParentAssessmentId As Long = 0

        Try
            MDIParent1.ShowStatus("Loading, please wait...")
            txtAcctNum.Text = "" : txtConsultantName.Text = ""

            sSQL = "SELECT c.ClientId, l.LocationId, a.AssessmentId,isnull(l.StateCd,'') as StateCd," &
                " isnull(c.Name,'') as Name, isnull(l.Address,'') as Address, isnull(l.City,'') as City," &
                " isnull(a.AcctNum,'') as AcctNum, ISNULL(a.AssessorId,0) AS AssessorId," &
                " a.ValueProtestFl, a.Comment, a.InactiveFl, ISNULL(l.ClientLocationId,'') AS ClientLocationId," &
                " a.ValueProtestMailedDate,a.ValueProtestHearingDate,a.ValueProtestStatus," &
                " ISNULL(a.ValueProtestDeadlineDate,assrs.REProtestDeadlineDate) AS ValueProtestDeadlineDate," &
                " a.ValueProtestCMRRR," &
                " assrs.REProtestDeadlineDate, ISNULL(assrs.Name,'') AS AssessorName,a.OccupiedStatus, ISNULL(a.ParentAssessmentId,0) AS ParentAssessmentId," &
                " ISNULL(l.ConsultantName,ISNULL(c.REConsultantName,'')) AS ConsultantName, a.AccountInvoicedStatus"
            sSQL = sSQL &
                " FROM Clients AS c INNER JOIN" &
                " AssessmentsRE AS a ON c.ClientId = a.ClientId INNER JOIN" &
                " LocationsRE AS l ON a.ClientId = l.ClientId AND a.LocationId = l.LocationId AND a.TaxYear = l.TaxYear LEFT OUTER JOIN" &
                " Assessors AS assrs ON a.AssessorId = assrs.AssessorId AND a.TaxYear = assrs.TaxYear" &
                " WHERE a.ClientId = " & m_ClientId & " AND a.LocationId = " & m_LocationId &
                " AND a.AssessmentId = " & m_AssessmentId & " AND a.TaxYear = " & m_TaxYear
            GetData(sSQL, dt)
            dr = dt.Rows(0)
            sStateCd = UnNullToString(dr("StateCd"))
            txtAcctNum.Text = UnNullToString(dr("AcctNum"))
            txtConsultantName.Text = dr("ConsultantName").ToString.Trim
            txtClientLocationId.Text = dr("ClientLocationId").ToString
            m_AssessorId = dr("AssessorId")
            lParentAssessmentId = dr("ParentAssessmentId")
            Me.Text = "Real Estate Assessment:  " & Trim(dr("Name")) & "   " & Trim(dr("Address")) & "   " &
                Trim(dr("City")) & " " & Trim(dr("StateCd")) & "   " & Trim(dr("AcctNum"))

            RefreshControls(Me, dt, "AssessmentsRE")
            LoadDropDowns(UnNullToString(dr("AssessorName")))

            LoadJurisdictions()
            LoadECU(lParentAssessmentId)

            Return True


        Catch ex As Exception
            MsgBox("Error in RefreshData:  " & ex.Message)
            Return False
        Finally
            MDIParent1.ShowStatus()
        End Try
    End Function

    Private Sub ComboBox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles txtAcctNum.GotFocus, cboAssessor.GotFocus, txtValueProtestCMRRR.GotFocus,
            txtValueProtestDeadlineDate.GotFocus, txtValueProtestHearingDate.GotFocus,
            txtValueProtestMailedDate.GotFocus, cboValueProtestStatus.GotFocus, txtComment.GotFocus, txtClientLocationId.GotFocus, cboOccupiedStatus.GotFocus,
            cboAccountInvoicedStatus.GotFocus
        sender.selectall()
    End Sub

    Private Sub ComboBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles txtAcctNum.TextChanged, cboAssessor.TextChanged, txtValueProtestCMRRR.TextChanged,
            txtValueProtestDeadlineDate.TextChanged, txtValueProtestHearingDate.TextChanged,
            txtValueProtestMailedDate.TextChanged, cboValueProtestStatus.TextChanged,
            chkValueProtestFl.CheckedChanged, txtComment.TextChanged, chkInactiveFl.CheckedChanged, txtClientLocationId.TextChanged, cboOccupiedStatus.TextChanged,
            cboAccountInvoicedStatus.TextChanged
        If bActivated Then
            If sender.name = chkInactiveFl.Name Then
                If sender.checkstate = CheckState.Checked Then
                    If MsgBox("Ok to deactivate assessment?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        bChanged = True
                    End If
                Else
                    bChanged = True
                End If
            Else
                bChanged = True
            End If
        End If
    End Sub

    Private Sub ComboBox_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles txtAcctNum.LostFocus, cboAssessor.LostFocus, txtValueProtestCMRRR.LostFocus,
            txtValueProtestDeadlineDate.LostFocus, txtValueProtestHearingDate.LostFocus,
            txtValueProtestMailedDate.LostFocus, cboValueProtestStatus.LostFocus, chkValueProtestFl.LostFocus,
            txtComment.LostFocus, chkInactiveFl.LostFocus, txtClientLocationId.LostFocus, cboOccupiedStatus.LostFocus,
            cboAccountInvoicedStatus.LostFocus
        If bChanged Then

            If TypeOf sender Is ComboBox Then
                If sender.SelectedIndex >= 0 Then
                    UpdateDB(sender, DBUpdate, colAssessors)
                End If
            Else
                UpdateDB(sender, DBUpdate)
            End If
            bChanged = False
        End If

    End Sub


    Private Function LoadDropDowns(ByVal sAssessorName As String) As Boolean
        Dim sSQL As String, dt As New DataTable, dr As DataRow

        colAssessors = New Collection
        cboAssessor.Text = ""
        cboAssessor.Items.Clear() : cboAssessor.Items.Add("")

        sSQL = "select AssessorId, (Name + ', ' + StateCd) AS Name from Assessors" & _
            " WHERE StateCd = " & QuoStr(sStateCd) & _
            " AND TaxYear = " & m_TaxYear & _
            " ORDER BY Name"
        GetData(sSQL, dt)
        For Each dr In dt.Rows
            cboAssessor.Items.Add(dr("Name"))
            colAssessors.Add(dr("AssessorId"), dr("Name"))      'use this to save?
        Next
        cboAssessor.Text = sAssessorName
    End Function

    Private Function LoadECU(ByVal lParentAssessmentId As Long) As Boolean
        Try
            dgECU.Columns.Clear()

            Dim sqlselect = New StringBuilder
            sqlselect.Append("SELECT CASE WHEN ISNULL(a.ParentAssessmentId,0) = 0 THEN 1 WHEN ISNULL(a.ParentAssessmentId,0) = a.AssessmentId THEN 1 ELSE 0 END AS IsParent,")
            sqlselect.Append("a.AcctNum, a.AssessmentId, a.TaxYear, ISNULL(d.REImprovementValue,0) AS REImprovementValue, ISNULL(d.RELandValue,0) AS RELandValue,")
            sqlselect.Append(" ISNULL(d.TotalAssessedValue,ISNULL(d.REImprovementValue,0) + ISNULL(d.RELandValue,0)) AS TotalAssessedValue")
            sqlselect.Append(" FROM AssessmentsRE a INNER JOIN AssessmentDetailRE d")
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
            ''get this account info
            'sql.Append(sqlselect.ToString).Append(" WHERE a.AssessmentId = ").Append(m_AssessmentId).Append(" AND a.TaxYear = ").Append(m_TaxYear)
            ''get parent's acount info
            'sql.Append(" UNION ").Append(sqlselect.ToString).Append(" WHERE a.AssessmentId = ").Append(lParentAssessmentId).Append(" AND a.TaxYear = ").Append(m_TaxYear)
            ''get child accounts if parent has parent as itself
            'sql.Append(" UNION ").Append(sqlselect.ToString).Append(" WHERE a.ParentAssessmentId = ").Append(lParentAssessmentId).Append(" AND a.TaxYear = ").Append(m_TaxYear)
            ''get child accounts if parent does not have itself as parent
            'sql.Append(" UNION ").Append(sqlselect.ToString).Append(" WHERE a.ParentAssessmentId = ").Append(m_AssessmentId).Append(" AND a.TaxYear = ").Append(m_TaxYear)

            Dim sqlgroup = New StringBuilder
            sqlgroup.Append("SELECT tbl1.IsParent, tbl1.AcctNum, tbl1.AssessmentId, tbl1.TaxYear, MAX(tbl1.REImprovementValue) AS REImprovementValue,")
            sqlgroup.Append("MAX(tbl1.RELandValue) AS RELandValue, MAX(tbl1.TotalAssessedValue) AS TotalAssessedValue")
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
                    Case "REImprovementValue"
                        column.HeaderText = "Improve"
                        column.DefaultCellStyle.Format = csInt
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        column.Width = 70
                    Case "RELandValue"
                        column.HeaderText = "Land"
                        column.DefaultCellStyle.Format = csInt
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        column.Width = 70
                    Case "TotalAssessedValue"
                        column.HeaderText = "Total"
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

    Private Function LoadJurisdictions() As Boolean
        Dim bind As New BindingSource
        Dim sSQL As String
        Dim lRows As Long = 0, dtList As New DataTable, JurisdictionList As New List(Of Long)
        Dim CollectorTotal() As structTotals, bFound As Boolean = False
        Dim dgRow(3) As String, l As Long = 0, d As Double = 0
        Dim dtsource As New DataTable

        Try
            sSQL = BuildTaxBillQuery(m_ClientId, m_LocationId, m_AssessmentId, JurisdictionList,
                0, enumTable.enumLocationRE, False, False, False, True, False, 0)
            lRows = GetData(sSQL, dtList)

            'MUST ADD FIELDS TO THIS SELECT IF NEW COLUMNS ADDED
            For Each col As DataColumn In dtList.Columns
                Select Case col.ColumnName
                    Case "JurisdictionId", "HasInstallments", "RELandValue", "REImprovementValue", "TotalAssessedValue", "RERatio", "ClientAbatementAmt",
                            "ClientAbatement", "AbatementReductionAmt", "Collectors_Name",
                            "FinalValue", "Jurisdictions_Name", "TaxBillAdjAmt1",
                            "TaxBillAdjDesc1", "TaxBillPrintedDate", "TaxDue", "TaxRate", "TaxYear", "TaxableValue"
                        dtsource.Columns.Add(col.ColumnName, col.DataType)
                End Select
            Next
            dtsource.Merge(dtList, True, MissingSchemaAction.Ignore)

            dgJurisdictions.Columns.Clear()
            bind.DataSource = dtsource
            dgJurisdictions.DataSource = bind
            dgCollectors.Rows.Clear()

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
                With .Columns("Collectors_Name")
                    .Visible = True
                    .HeaderText = "Collector"
                    .Width = 115
                    .ReadOnly = True
                End With
                With .Columns("Jurisdictions_Name")
                    .Visible = True
                    .HeaderText = "Jurisdiction"
                    .Width = 115
                    .DividerWidth = 2
                    .Frozen = True
                    .ReadOnly = True
                End With
                With .Columns("RELandValue")
                    .Visible = True
                    .HeaderText = "Land"
                    .Width = 70
                    .DefaultCellStyle.Format = csInt
                    .ReadOnly = False
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                With .Columns("REImprovementValue")
                    .Visible = True
                    .HeaderText = "Improvement"
                    .Width = 70
                    .ReadOnly = False
                    .DefaultCellStyle.Format = csInt
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                With .Columns("TotalAssessedValue")
                    .Visible = True
                    .HeaderText = "Total Assessed Value"
                    .Width = 70
                    .ReadOnly = False
                    .DefaultCellStyle.Format = csInt
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
                With .Columns("RERatio")
                    .Visible = True
                    .HeaderText = "Assessor Ratio"
                    .Width = 55
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
                    .Width = 50
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
                With .Columns("TaxBillPrintedDate")
                    .Visible = True
                    .HeaderText = "Tax Bill Printed Date"
                    .Width = 115
                    .ReadOnly = False
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
            End With

            'For Each column As DataGridViewColumn In dgJurisdictions.Columns
            '    If IsIndexField(column.Name) Then
            '        column.Visible = False
            '    ElseIf column.Name = "TaxYear" Or column.Name = "Jurisdictions_Name" Or column.Name = "RELandValue" Or
            '            column.Name = "REImprovementValue" Or column.Name = "TotalAssessedValue" Or
            '            column.Name = "FinalValue" Or column.Name = "AbatementReductionAmt" Or
            '            column.Name = "ClientAbatement" Or
            '            column.Name = "TaxableValue" Or
            '            column.Name = "TaxRate" Or column.Name = "TaxBillAdjDesc1" Or
            '            column.Name = "TaxBillAdjAmt1" Or column.Name = "TaxDue" Or
            '            column.Name = "TaxBillPrintedDate" Or column.Name = "Collectors_Name" Or
            '            column.Name = "RERatio" Or column.Name = "Collectors_Name" Or column.Name = "ClientAbatementAmt" Then
            '        column.Visible = True
            '    Else
            '        column.Visible = False
            '    End If

            '    If column.Name = "RELandValue" Then column.HeaderText = "Land"
            '    If column.Name = "REImprovementValue" Then column.HeaderText = "Improvements"
            '    If column.Name = "RERatio" Then column.HeaderText = "Assessor Ratio"
            '    If column.Name = "AbatementReductionAmt" Then column.HeaderText = "V1 Abatement"
            '    If column.Name = "ClientAbatementAmt" Then column.HeaderText = "Client Abatement"
            '    If column.Name = "TaxBillAdjDesc1" Then column.HeaderText = "Tax Bill Adj Desc"
            '    If column.Name = "TaxBillAdjAmt1" Then column.HeaderText = "Tax Bill Adj Amt"
            '    If column.Name = "TaxDue" Then column.HeaderText = "Tax Due"
            '    If column.Name = "TaxBillPrintedDate" Then column.HeaderText = "Tax Bill Printed Date"
            '    If column.Name = "PenaltyAmt1" Then column.HeaderText = "Penalty Amt"
            '    If column.Name = "Collectors_Name" Then column.HeaderText = "Collector"
            '    If column.Name = "Jurisdictions_Name" Then column.HeaderText = "Jurisdiction"
            '    If column.Name = "FinalValue" Then column.HeaderText = "Final Value"
            '    If column.Name = "TaxableValue" Then column.HeaderText = "Taxable Value"
            '    If column.Name = "TotalAssessedValue" Then column.HeaderText = "Total Assessed Value"
            '    If column.Name = "TaxYear" Then column.HeaderText = "Tax Year"

            '    If column.Name = "Jurisdictions_Name" Then
            '        column.DividerWidth = 2
            '        column.Frozen = True
            '    End If
            '    Select Case column.Name
            '        Case "RELandValue", "REImprovementValue", "TotalAssessedValue", "FinalValue", "AbatementReductionAmt", "AdjDesc1", "AdjAmt1",
            '                "TaxBillAdjDesc1", "TaxBillAdjAmt1", "TaxBillPrintedDate", "ClientAbatementAmt"
            '            column.ReadOnly = False
            '        Case Else
            '            column.ReadOnly = True
            '    End Select

            '    Select Case column.Name
            '        Case "RELandValue", "REImprovementValue", "TotalAssessedValue", "FinalValue", "AbatementReductionAmt",
            '                "AdjAmt1", "TaxBillAdjAmt1", "TaxDue", "TaxRate", "TaxableValue", "RERatio", "ClientAbatementAmt"
            '            If column.Name = "TaxDue" Or column.Name = "TaxBillAdjAmt1" Then
            '                column.DefaultCellStyle.Format = csDol
            '            ElseIf column.Name = "TaxRate" Then
            '                column.DefaultCellStyle.Format = csTaxRate
            '            ElseIf column.Name = "RERatio" Then
            '                column.DefaultCellStyle.Format = csPct
            '            Else
            '                column.DefaultCellStyle.Format = csInt
            '            End If
            '            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            '            If column.Name = "TaxDue" Then
            '                Dim font As New Font(dgJurisdictions.DefaultCellStyle.Font.FontFamily, 8.25, FontStyle.Bold)
            '                Try
            '                    column.DefaultCellStyle.Font = font
            '                Finally
            '                    font.Dispose()
            '                End Try
            '            End If
            '    End Select
            '    Select Case column.Name
            '        Case "RELandValue", "REImprovementValue", "TotalAssessedValue", "FinalValue", "TaxableValue"
            '            column.Width = 70
            '        Case "AbatementReductionAmt", "ClientAbatementAmt"
            '            column.Width = 70
            '        Case "TaxBillAdjAmt1"
            '            column.Width = 50
            '        Case "TaxRate"
            '            column.Width = 75
            '        Case "TaxDue"
            '            column.Width = 75
            '        Case "RERatio"
            '            column.Width = 55
            '        Case "Jurisdictions_Name", "Collectors_Name"
            '            column.Width = 115
            '        Case "TaxBillAdjDesc1"
            '            column.Width = 50
            '        Case "TaxBillPrintedDate"
            '            column.Width = 115
            '        Case "TaxYear"
            '            column.Width = 35
            '    End Select
            'Next


            If lRows = 0 Then
                dgJurisdictions.Enabled = False
            Else
                dgJurisdictions.Enabled = True
            End If

            If lRows > 0 Then
                Dim bFirst As Boolean = True
                ReDim CollectorTotal(0)
                CollectorTotal(0).lId = dtList.Rows(0)("CollectorId")
                CollectorTotal(0).sDescription = dtList.Rows(0)("Collectors_Name")
                If dtList.Rows(0)("TaxBillLoaded") = "Yes" Then CollectorTotal(UBound(CollectorTotal)).bLoaded = True
                For Each dr As DataRow In dtList.Rows
                    If dr("TaxYear") = m_TaxYear Then
                        bFound = False
                        For l = 0 To UBound(CollectorTotal)
                            If CollectorTotal(l).lId = dr("CollectorId") Then
                                bFound = True
                                Exit For
                            End If
                        Next
                        If bFound Then
                            CollectorTotal(l).dAmount = CollectorTotal(l).dAmount + dr("TaxDue")
                        Else
                            ReDim Preserve CollectorTotal(UBound(CollectorTotal) + 1)
                            CollectorTotal(UBound(CollectorTotal)).lId = dr("CollectorId")
                            CollectorTotal(UBound(CollectorTotal)).sDescription = dr("Collectors_Name")
                            CollectorTotal(UBound(CollectorTotal)).dAmount = dr("TaxDue")
                            If dr("TaxBillLoaded") = "Yes" Then CollectorTotal(UBound(CollectorTotal)).bLoaded = True
                        End If
                        d = d + dr("TaxDue")
                    End If
                Next
                For Each CollectorItem As structTotals In CollectorTotal
                    dgRow(0) = CollectorItem.lId
                    dgRow(1) = CollectorItem.sDescription
                    dgRow(2) = Format(CollectorItem.dAmount, csDol)
                    dgRow(3) = IIf(CollectorItem.bLoaded = True, "View", "")
                    dgCollectors.Rows.Add(dgRow)
                Next
                dgCollectors.Sort(dgCollectors.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
                txtTaxBillTotal.Text = Format(d, csDol)
            End If

            Dim bindHist As New BindingSource
            Dim dtListHist As New DataTable
            dgHistory.Columns.Clear()
            sSQL = "SELECT TaxYear as [Year], MAX(FinalValue) AS [Value]" &
                " FROM AssessmentDetailRE" &
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
                        sSQL = "DELETE AssessmentDetailRE WHERE ClientId = " & m_ClientId & _
                            " AND LocationId = " & m_LocationId & _
                            " AND AssessmentId = " & m_AssessmentId & _
                            " AND JurisdictionId = " & row.Cells("JurisdictionId").Value & _
                            " AND TaxYear = " & m_TaxYear
                        If sSQL <> "" Then
                            ExecuteSQL(sSQL)
                            WriteSQLToHistory("DeleteAssessmentDetailRE", sSQL)
                        End If
                    Next
                    sSQL = "UPDATE AssessmentsRE SET ChangeDate = GETDATE(), ChangeUser = " & QuoStr(AppData.UserId) & ", ChangeType = 2" & _
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
        If Not UpdateAssessmentDetailRE(m_ClientId, m_LocationId, m_AssessmentId, dgJurisdictions.Rows(e.RowIndex).Cells("JurisdictionId").Value, m_TaxYear, dgJurisdictions.Columns(e.ColumnIndex).Name, Trim(UnNullToString(dgJurisdictions.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)), bApplyToAll, sError) Then
            MsgBox(sError)
        End If
        dgJurisdictions.Rows(e.RowIndex).ErrorText = String.Empty

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
                            frmJ.StateCd = sStateCd And frmJ.TaxYear = m_TaxYear And frmJ.PropType = enumTable.enumLocationRE Then
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
        frmJ.PropType = enumTable.enumLocationRE
        frmJ.TaxYear = m_TaxYear
        frmJ.MdiParent = MDIParent1
        frmJ.Show()
    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
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
                            enumTable.enumLocationRE, 0, 0, False, sPDFFileName, "")
                End If
            End If
        Catch ex As Exception
            MsgBox("Error printing:  " & ex.Message)
        End Try

    End Sub
    Private Sub cmdTaxBillDetail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdTaxBillDetail.Click
        If dgCollectors.Visible = True Then
            dgCollectors.Visible = False
        Else
            dgCollectors.Visible = True
            dgCollectors.BringToFront()
        End If
    End Sub

    Private Sub dgCollectors_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgCollectors.CellClick
        Try
            Dim sError As String = ""
            If e.RowIndex < 0 OrElse Not e.ColumnIndex = dgCollectors.Columns("FormData").Index Then Return
            If dgCollectors(3, e.RowIndex).Value = "" Then Return
            Dim lCollectorId As Long = CLng(dgCollectors(0, e.RowIndex).Value)
            If ViewTaxBill("TaxBillsRE", m_ClientId, m_LocationId, m_AssessmentId, lCollectorId, m_TaxYear, dgCollectors(1, e.RowIndex).Value & "_" & txtAcctNum.Text, False, sError) Then

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
            If e.RowIndex < 0 Or e.ColumnIndex = dgCollectors.Columns("FormData").Index Then Return
            Dim lCollectorId As Long = CLng(dgCollectors(0, e.RowIndex).Value)
            Dim frmI As frmInstallments
            For Each frm As Form In MDIParent1.MdiChildren
                If frm.Name = "frmInstallments" Then
                    frmI = frm
                    If frmI.ClientId = m_ClientId And frmI.LocationId = m_LocationId And frmI.AssessmentId = m_AssessmentId And _
                                frmI.TaxYear = m_TaxYear And frmI.PropType = enumTable.enumLocationRE And frmI.CollectorId = lCollectorId Then
                        frm.Focus()
                        Exit Sub
                    End If
                End If
            Next
            frmI = New frmInstallments
            frmI.ClientId = m_ClientId
            frmI.LocationId = m_LocationId
            frmI.AssessmentId = m_AssessmentId
            frmI.PropType = enumTable.enumLocationRE
            frmI.CollectorId = lCollectorId
            frmI.TaxYear = m_TaxYear
            frmI.MdiParent = MDIParent1
            frmI.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Private Sub mnuContextImportTaxBill_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuContextImportTaxBill.Click
        Try
            Dim sError As String = ""
            If dgCollectors.SelectedRows.Count = 0 Then Return
            Dim iRowIndex As Integer = dgCollectors.SelectedRows(0).Index
            Dim lCollectorId As Long = CLng(dgCollectors(0, iRowIndex).Value)
            If lCollectorId = 0 Then Return
            If ImportTaxBill(m_ClientId, m_LocationId, m_AssessmentId, lCollectorId, enumTable.enumLocationRE, m_TaxYear, AppData.UserId, sError) = True Then
                MsgBox("Tax bill imported")
            Else
                If sError <> "" Then MsgBox("Error importing:  " & sError)
            End If

        Catch ex As Exception
            MsgBox("Error importing tax bill:  " & ex.Message)
        End Try

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

    Private Sub frmREAssessment_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class