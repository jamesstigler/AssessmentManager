Public Class frmTaskAssignment
    Private bActivated As Boolean
    Private bRefreshing As Boolean
    Private colClients As Collection
    Private colBPPLocations As Collection
    Private colRELocations As Collection
    Private colAssessments As Collection
    Private colAssessors As Collection
    Private colJurisdictions As Collection
    Private colCollectors As Collection
    Private colStates As Collection
    Private colTasks As Collection

    Private Sub frmTaskAssignment_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If bActivated Then Exit Sub

        Try
            colTasks = New Collection
            LoadComboBox("select TaskId, RTRIM(Name) + ' - ' + CONVERT(varchar,TaskDate,1) + ' ' + convert(varchar,TaskDate,8) FROM TaskMasterList order by Name", cboTask, colTasks)
            colClients = New Collection
            LoadComboBox("select ClientId, Name from Clients WHERE ISNULL(ProspectFl,0) = 0 " & IIf(AppData.IncludeInactive = False, " AND ISNULL(InactiveFl,0) = 0", "") & " order by Name", cboClients, colClients)
            colStates = New Collection
            LoadComboBox("select StateCd, StateCd from States order by 1", cboStateCd, colStates)
            colAssessors = New Collection
            LoadComboBox("select AssessorId, RTRIM(Name) + ', ' + RTRIM(StateCd) from Assessors" & _
                " WHERE TaxYear = " & AppData.TaxYear & " order by Name, StateCd", cboAssessors, colAssessors)
            colJurisdictions = New Collection
            LoadComboBox("SELECT JurisdictionId, RTRIM(Name) + ', ' + RTRIM(StateCd) FROM Jurisdictions" & _
                " WHERE TaxYear = " & AppData.TaxYear & " order by Name, StateCd", cboJurisdictions, colJurisdictions)

            colCollectors = New Collection
            LoadComboBox("SELECT CollectorId, RTRIM(Name) + ', ' + RTRIM(StateCd) FROM Collectors" & _
                " WHERE TaxYear = " & AppData.TaxYear & " order by Name, StateCd", cboCollectors, colCollectors)


        Catch ex As Exception
            MsgBox("Error opening screen:  " & ex.Message)
        End Try

        bActivated = True

    End Sub

    Private Sub cboClients_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboClients.SelectedIndexChanged
        If bActivated And Not bRefreshing Then
            LoadLocations(colClients(cboClients.SelectedItem.ToString))

        End If

    End Sub
    Private Function LoadLocations(ByVal lClientId As Long) As Boolean
        Dim sSQL As String

        Try

            bRefreshing = True
            colBPPLocations = New Collection
            colRELocations = New Collection
            colAssessments = New Collection
            cboBPPLocations.Items.Clear()
            cboRELocations.Items.Clear()
            cboAssessments.Items.Clear()
            cboBPPLocations.Text = ""
            cboRELocations.Text = ""
            cboAssessments.Text = ""

            sSQL = "SELECT LocationId, RTRIM(ISNULL(Address,'')) + ' ' + RTRIM(ISNULL(City,'')) + ' ' + RTRIM(ISNULL(StateCd,''))" & _
                " FROM LocationsRE WHERE ClientId = " & lClientId & " AND TaxYear = " & AppData.TaxYear & _
                " ORDER BY Address, City, StateCd"
            LoadComboBox(sSQL, cboRELocations, colRELocations)

            sSQL = "SELECT LocationId,RTRIM(ISNULL(Address,'')) + ' ' + RTRIM(ISNULL(City,'')) + ' ' + RTRIM(ISNULL(StateCd,''))" & _
                " FROM LocationsBPP WHERE ClientId = " & lClientId & " AND TaxYear = " & AppData.TaxYear & _
                " ORDER BY Address, City, StateCd"
            LoadComboBox(sSQL, cboBPPLocations, colBPPLocations)

            bRefreshing = False
            Return True
        Catch ex As Exception
            bRefreshing = False
            MsgBox("Error loading locations:  " & ex.Message)
            Return False
        End Try
    End Function

    Private Sub cboBPPLocations_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboBPPLocations.SelectedIndexChanged
        If bActivated And Not bRefreshing Then
            LoadAssessments(colClients(cboClients.SelectedItem.ToString), colBPPLocations(cboBPPLocations.SelectedItem.ToString), enumTable.enumLocationBPP)
        End If

    End Sub

    Private Sub cboRELocations_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRELocations.SelectedIndexChanged
        If bActivated And Not bRefreshing Then
            LoadAssessments(colClients(cboClients.SelectedItem.ToString), colRELocations(cboRELocations.SelectedItem.ToString), enumTable.enumLocationRE)
        End If

    End Sub

    Private Function LoadAssessments(ByVal lClientId As Long, ByVal lLocationId As Long, ByVal ePropType As enumTable) As Boolean
        Dim sSQL As String, sType As String

        Try

            bRefreshing = True
            colAssessments = New Collection
            cboAssessments.Items.Clear()
            cboAssessments.Text = ""

            If ePropType = enumTable.enumLocationBPP Then
                sType = "BPP"
            Else
                sType = "RE"
            End If

            sSQL = "SELECT assess.AssessmentId, RTRIM((isnull(assess.AcctNum,'')) + ' ' + RTRIM(isnull(a.Name,'')) + ', ' + isnull(a.StateCd,'')) AS Assessor" & _
                " FROM Assessments" & sType & " assess LEFT OUTER JOIN Assessors a" & _
                " ON assess.AssessorId = a.AssessorId AND assess.TaxYear = a.TaxYear" & _
                " WHERE assess.ClientId = " & lClientId & " AND assess.LocationId = " & lLocationId & _
                " AND assess.TaxYear = " & AppData.TaxYear & _
                " ORDER BY assess.AcctNum,a.Name,a.StateCd"
            LoadComboBox(sSQL, cboAssessments, colAssessments)

            bRefreshing = False
            Return True
        Catch ex As Exception
            bRefreshing = False
            MsgBox("Error loading assessments:  " & ex.Message)
            Return False
        End Try



    End Function

    Private Sub cmdOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Dim lTaskId As Long = 0, lClientId As Long = 0, lBPPLocationId As Long = 0, lRELocationId As Long = 0
        Dim lAssessmentId As Long = 0, lAssessorId As Long = 0
        Dim lJurisdictionId As Long = 0, lCollectorId As Long = 0, sStateCd As String = "", bAllClients As Boolean = False
        Dim bBPPLocations As Boolean = False, bRELocations As Boolean = False, bAllLocations As Boolean = False
        Dim bAllAssessments As Boolean = False, bAllAssessors As Boolean = False, bAllJurisdictions As Boolean = False
        Dim bAllCollectors As Boolean = False, bAllStates As Boolean = False
        Dim sMsg As String = ""

        If cboTask.Text = "" Then Exit Sub
        lTaskId = colTasks(cboTask.Text)
        If cboClients.Text <> "" Then lClientId = colClients(cboClients.Text)
        If cboBPPLocations.Text <> "" Then lBPPLocationId = colBPPLocations(cboBPPLocations.Text)
        If cboRELocations.Text <> "" Then lRELocationId = colRELocations(cboRELocations.Text)
        If cboAssessments.Text <> "" Then lAssessmentId = colAssessments(cboAssessments.Text)
        If cboAssessors.Text <> "" Then lAssessorId = colAssessors(cboAssessors.Text)
        If cboJurisdictions.Text <> "" Then lJurisdictionId = colJurisdictions(cboJurisdictions.Text)
        If cboCollectors.Text <> "" Then lCollectorId = colCollectors(cboCollectors.Text)
        If cboStateCd.Text <> "" Then sStateCd = colStates(cboStateCd.Text)
        bAllClients = chkClients.Checked
        bBPPLocations = radioBPPLocations.Checked
        bRELocations = radioRELocations.Checked
        bAllLocations = radioAllLocations.Checked
        bAllAssessments = chkAssessments.Checked
        bAllAssessors = chkAssessors.Checked
        bAllJurisdictions = chkAllJurisdictions.Checked
        bAllCollectors = chkCollectors.Checked
        bAllStates = chkStates.Checked


        If SaveTaskAssignment(lTaskId, lClientId, lBPPLocationId, lRELocationId, lAssessmentId, lAssessorId, lJurisdictionId, _
                lCollectorId, sStateCd, bAllClients, _
                bBPPLocations, bRELocations, bAllLocations, bAllAssessments, bAllAssessors, _
                bAllJurisdictions, bAllCollectors, bAllStates, sMsg) Then
            MsgBox("Task assignment saved")
            ClearAssignments()
        Else
            MsgBox(sMsg)
        End If


    End Sub
    Private Sub ClearAssignments()
        cboAssessments.Text = ""
        cboAssessors.Text = ""
        cboBPPLocations.Text = ""
        cboClients.Text = ""
        cboCollectors.Text = ""
        cboJurisdictions.Text = ""
        cboRELocations.Text = ""
        cboStateCd.Text = ""
        chkAllJurisdictions.Checked = False
        chkAssessments.Checked = False
        chkAssessors.Checked = False
        chkClients.Checked = False
        chkCollectors.Checked = False
        chkStates.Checked = False
        radioAllLocations.Checked = False
        radioBPPLocations.Checked = False
        radioRELocations.Checked = False

    End Sub

    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub
End Class