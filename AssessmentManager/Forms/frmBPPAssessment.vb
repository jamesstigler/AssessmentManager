Public Class frmBPPAssessment

    '' child/parent notified values in group box for bpp (notified) and re (land/improve/total)

    Private bActivated As Boolean
    Private m_ClientId As Long
    Private m_LocationId As Long
    Private m_AssessmentId As Long
    Private m_TaxYear As Integer
    Private m_AssessorId As Long

    Private DBUpdate() As typeDBUpdateInfo
    Private bChanged As Boolean
    Private sStateCd As String
    Private colAssessors As Collection
    Private iMouseClickColIndex As Integer = 0

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

        Try
            txtAcctNum.Text = "" : txtConsultantName.Text = ""
            sSQL = "SELECT c.ClientId, l.LocationId, a.AssessmentId, ISNULL(l.StateCd, '') AS StateCd, a.InactiveFl," &
                " ISNULL(c.Name, '') AS Name, ISNULL(l.Address, '') AS Address," &
                " ISNULL(l.City, '') AS City, ISNULL(a.AcctNum, '') AS AcctNum, ISNULL(a.AssessorId, 0) AS AssessorId," &
                " a.Comment, a.ValueProtestFl, a.FreeportProtestFl, a.ValueProtestMailedDate, a.ValueProtestHearingDate," &
                " a.ValueProtestStatus, ISNULL(a.ValueProtestDeadlineDate,assrs.BPPProtestDeadlineDate) AS ValueProtestDeadlineDate," &
                " a.ValueProtestCMRRR, a.FreeportProtestMailedDate," &
                " a.FreeportProtestHearingDate, a.FreeportProtestStatus, a.FreeportProtestDeadlineDate, a.FreeportProtestCMRRR," &
                " ISNULL(a.OtherProtest1, 'Other Protest') AS OtherProtest1, a.OtherProtest1DeadlineDate, a.OtherProtest1MailedDate," &
                " a.OtherProtest1CMRRR, a.OtherProtest1Status, a.OtherProtest1HearingDate," &
                " ISNULL(a.RenditionDeadlineDate,assrs.RenditionDueDate) AS RenditionDeadlineDate," &
                " a.RenditionExtDeadlineDate, a.RenditionCMRRR, a.RenditionMailedDate, ISNULL(l.ClientLocationId, '') AS ClientLocationId," &
                " a.RenditionExtCMRRR, a.RenditionExtMailedDate, ltrim(rtrim(assrs.Name)) + ', ' + assrs.StateCd AS AssessorName, assrs.RenditionDueDate," &
                " assrs.BPPProtestDeadlineDate," &
                " ISNULL(l.SICCode,ISNULL(c.SICCode,'')) AS SICCode," &
                " ISNULL(l.ConsultantName,ISNULL(c.BPPConsultantName,'')) AS ConsultantName, a.AccountInvoicedStatus" &
                " FROM Clients AS c INNER JOIN" &
                " AssessmentsBPP AS a ON c.ClientId = a.ClientId INNER JOIN" &
                " LocationsBPP AS l ON a.ClientId = l.ClientId AND a.LocationId = l.LocationId AND a.TaxYear = l.TaxYear LEFT OUTER JOIN" &
                " Assessors AS assrs ON a.AssessorId = assrs.AssessorId AND a.TaxYear = assrs.TaxYear" &
                " WHERE a.ClientId = " & m_ClientId & " AND a.LocationId = " & m_LocationId &
                " AND a.AssessmentId = " & m_AssessmentId & " AND a.TaxYear = " & m_TaxYear

            GetData(sSQL, dt)
            dr = dt.Rows(0)
            sStateCd = UnNullToString(dr("StateCd"))
            txtAcctNum.Text = UnNullToString(dr("AcctNum"))
            txtConsultantName.Text = dr("ConsultantName").ToString.Trim
            txtSICCode.Text = dr("SICCode").ToString.Trim
            m_AssessorId = dr("AssessorId")
            Me.Text = m_TaxYear & " BPP Assessment:  " & Trim(dr("Name")) & "   " & Trim(dr("Address")) & "   " &
                Trim(dr("City")) & " " & Trim(dr("StateCd")) & "   " & Trim(dr("AcctNum"))

            RefreshControls(Me, dt, "AssessmentsBPP")
            RefreshControls(Me, dt, "LocationsBPP")
            LoadDropDowns(UnNullToString(dr("AssessorName")))

            Return True

        Catch ex As Exception
            MsgBox("Error in RefreshData:  " & ex.Message)
            Return False
        End Try
    End Function

    Private Sub ComboBox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles _
             txtAcctNum.GotFocus, cboAssessor.GotFocus,
            txtValueProtestCMRRR.GotFocus, txtValueProtestDeadlineDate.GotFocus,
            txtValueProtestHearingDate.GotFocus, txtValueProtestMailedDate.GotFocus, cboValueProtestStatus.GotFocus,
            txtFreeportProtestCMRRR.GotFocus, txtFreeportProtestDeadlineDate.GotFocus,
            txtFreeportProtestHearingDate.GotFocus, txtFreeportProtestMailedDate.GotFocus, cboFreeportProtestStatus.GotFocus, txtComment.GotFocus,
            txtClientLocationId.GotFocus, txtRenditionExtCMRRR.GotFocus, txtRenditionExtMailedDate.GotFocus,
            txtRenditionCMRRR.GotFocus, txtRenditionMailedDate.GotFocus, TextBox1.GotFocus, TextBox2.GotFocus,
            TextBox3.GotFocus, TextBox4.GotFocus, TextBox5.GotFocus, TextBox6.GotFocus, TextBox7.GotFocus,
            ComboBox1.GotFocus, cboAccountInvoicedStatus.GotFocus

        sender.selectall()
    End Sub

    Private Sub ComboBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles _
            txtAcctNum.TextChanged, cboAssessor.TextChanged,
            cboValueProtestStatus.TextChanged, txtValueProtestCMRRR.TextChanged, txtValueProtestDeadlineDate.TextChanged,
            txtValueProtestHearingDate.TextChanged, txtValueProtestMailedDate.TextChanged,
            cboFreeportProtestStatus.TextChanged, txtFreeportProtestCMRRR.TextChanged, txtFreeportProtestDeadlineDate.TextChanged,
            txtFreeportProtestHearingDate.TextChanged, txtFreeportProtestMailedDate.TextChanged, txtComment.TextChanged,
            chkInactiveFl.CheckedChanged,
            txtClientLocationId.TextChanged, txtRenditionExtCMRRR.TextChanged, txtRenditionExtMailedDate.TextChanged,
            txtRenditionCMRRR.TextChanged, txtRenditionMailedDate.TextChanged, TextBox1.TextChanged, TextBox2.TextChanged,
            TextBox3.TextChanged, TextBox4.TextChanged, TextBox5.TextChanged, TextBox6.TextChanged, TextBox7.TextChanged,
            ComboBox1.TextChanged, cboAccountInvoicedStatus.TextChanged
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
            Handles _
             txtAcctNum.LostFocus, cboAssessor.LostFocus,
            cboValueProtestStatus.LostFocus, txtValueProtestCMRRR.LostFocus, txtValueProtestDeadlineDate.LostFocus,
            txtValueProtestHearingDate.LostFocus, txtValueProtestMailedDate.LostFocus,
            cboFreeportProtestStatus.LostFocus, txtFreeportProtestCMRRR.LostFocus, txtFreeportProtestDeadlineDate.LostFocus,
            txtFreeportProtestHearingDate.LostFocus, txtFreeportProtestMailedDate.LostFocus, txtComment.LostFocus,
            chkInactiveFl.LostFocus,
            txtClientLocationId.LostFocus, txtRenditionExtCMRRR.LostFocus, txtRenditionExtMailedDate.LostFocus,
            txtRenditionCMRRR.LostFocus, txtRenditionMailedDate.LostFocus, TextBox1.LostFocus, TextBox2.LostFocus,
            TextBox3.LostFocus, TextBox4.LostFocus, TextBox5.LostFocus, TextBox6.LostFocus, TextBox7.LostFocus,
            ComboBox1.LostFocus, cboAccountInvoicedStatus.LostFocus

        If bChanged Then
            If TypeOf sender Is ComboBox Then
                If sender.SelectedIndex >= 0 Then
                    If InStr(sender.tag, "EntityId") > 0 Then
                        'UpdateDB(sender, DBUpdate, colFactoringEntities)
                    Else
                        UpdateDB(sender, DBUpdate, colAssessors)
                    End If
                End If
            Else
                UpdateDB(sender, DBUpdate)
            End If
            bChanged = False
        End If

    End Sub


    Private Function LoadDropDowns(ByVal sAssessorName As String) As Boolean
        Dim sSQL As String = "", dt As New DataTable, dr As DataRow

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

    Private Sub frmBPPAssessment_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Minimized Then Exit Sub
        Dim mesize As Size = Me.Size

    End Sub

    Private Sub cmdValues_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdValues.Click
        Dim sMsg As String = ""
        If Not OpenBPPTaxList(m_ClientId, m_LocationId, m_AssessmentId, m_AssessorId, m_TaxYear, sMsg) Then
            MsgBox(sMsg)
        End If
    End Sub

    Private Sub cmdOpenAssessor_Click(sender As Object, e As EventArgs) Handles cmdOpenAssessor.Click
        Try
            OpenAssessor(colAssessors(cboAssessor.Text), m_TaxYear)
        Catch ex As Exception
        End Try
    End Sub
End Class