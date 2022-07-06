Module modTasks
    Public Function SaveTaskAssignment(ByVal lTaskId As Long, ByVal lClientId As Long, _
            ByVal lBPPLocationId As Long, ByVal lRELocationId As Long, _
            ByVal lAssessmentId As Long, ByVal lAssessorId As Long, ByVal lJurisdictionId As Long, _
            ByVal lCollectorId As Long, ByVal sStateCd As String, ByVal bAllClients As Boolean, _
            ByVal bBPPLocations As Boolean, ByVal bRELocations As Boolean, ByVal bAllLocations As Boolean, _
            ByVal bAllAssessments As Boolean, ByVal bAllAssessors As Boolean, _
            ByVal bAllJurisdictions As Boolean, ByVal bAllCollectors As Boolean, ByVal bAllStates As Boolean, _
            ByRef sMsg As String) As Boolean

        Dim sSQL As String = "", lId As Long = 0
        Dim sAuditField As String = ", AddUser)"
        Dim sAuditValue As String = "," & QuoStr(AppData.UserId)

        Try
            If lTaskId = 0 Then
                sMsg = "No task to assign"
                Return False
            End If
            lId = CreateID(enumTable.enumTaskAssignment)
            If bAllClients Then                             'all clients
                sSQL = "INSERT TaskAssignments (TaskAssignmentId,TaskId,AllClients" & sAuditField & _
                    " SELECT " & lId & "," & lTaskId & ", 1" & sAuditValue
            ElseIf lClientId > 0 And lBPPLocationId = 0 And lRELocationId = 0 Then
                If bBPPLocations Then                       'single client, all bpp locations

                ElseIf bRELocations Then                    'single client, all re locations

                ElseIf bAllLocations Then                   'single client, all locations

                ElseIf bAllAssessments Then                 'single client

                Else                                        'single client
                    sSQL = "INSERT TaskAssignments (TaskAssignmentId,TaskId, ClientId" & sAuditField & _
                        " SELECT " & lId & "," & lTaskId & "," & lClientId & sAuditValue
                End If

            ElseIf lBPPLocationId > 0 And lAssessmentId = 0 Then
                If lClientId = 0 Then
                    sMsg = "No client specified"
                    Return False
                End If

            ElseIf lRELocationId > 0 And lAssessmentId = 0 Then
                If lClientId = 0 Then
                    sMsg = "No client specified"
                    Return False
                End If

            ElseIf lAssessmentId > 0 Then
                If lClientId = 0 Or (lBPPLocationId = 0 And lRELocationId = 0) Then
                    sMsg = "No client or location specified"
                    Return False
                End If
                sSQL = "INSERT TaskAssignments" & IIf(lBPPLocationId > 0, "BPP", "RE") & _
                    " (TaskAssignmentId,TaskId,ClientId,LocationId,AssessmentId,AddUser)" & _
                    " SELECT " & lId & "," & lTaskId & "," & lClientId & "," & _
                    IIf(lBPPLocationId > 0, lBPPLocationId, lRELocationId) & "," & _
                    lAssessmentId & "," & QuoStr(AppData.UserId)
            ElseIf lAssessorId > 0 Then
                sSQL = "INSERT TaskAssignments (TaskAssignmentId,TaskId, AssessorId" & sAuditField & _
                    " SELECT " & lId & "," & lTaskId & "," & lAssessorId & sAuditValue
            ElseIf lJurisdictionId > 0 Then
                sSQL = "INSERT TaskAssignments (TaskAssignmentId,TaskId, JurisdictionId" & sAuditField & _
                    " SELECT " & lId & "," & lTaskId & "," & lJurisdictionId & sAuditValue
            ElseIf lCollectorId > 0 Then
                sSQL = "INSERT TaskAssignments (TaskAssignmentId,TaskId, CollectorId" & sAuditField & _
                    " SELECT " & lId & "," & lTaskId & "," & lCollectorId & sAuditValue
            ElseIf sStateCd <> "" Then
                sSQL = "INSERT TaskAssignments (TaskAssignmentId,TaskId, StateCd" & sAuditField & _
                    " SELECT " & lId & "," & lTaskId & "," & QuoStr(sStateCd) & sAuditValue
            End If

            If sSQL = "" Then
                sMsg = "Task could not be saved"
                Return False
            Else
                ExecuteSQL(sSQL)
                Return True
            End If

        Catch ex As Exception
            MsgBox("Error assigning task:  " & ex.Message)
            Return False
        End Try

    End Function

    Public Function BuildTaskAssignmentQuery(proptype As enumPropType, clientid As Long, locationid As Long, assessmentid As Long, taxyear As Integer) As String
        'Dim sql As New StringBuilder

        'sql.Append("SELECT ta.TaskId, tm.Name, tm.Description, ta.TaskDate, ta.Notes, ta.Email, ta.Website, ta.CompletedFl, ta.CompletedDate, ta.Priority, ta.ContactInfo")
        'sql.Append(",ISNULL(ta.ClientId,0) AS ClientId, ISNULL(ta.LocationId,0) AS LocationId, ISNULL(ta.AssessmentId,0) AS AssessmentId,ta.TaxYear, ta.PropType")
        'sql.Append(" FROM TaskAssignments ta, TaskMasterList tm WHERE ta.TaskId = tm.TaskId")
        'If proptype = enumPropType.BPP Then sql.Append(" AND ta.PropType='P' AND ta.ClientId= )

        ''If GetData(sSQL, dt) = 0 Then Return ""
        Dim sReturnSQL as string = ""

        ''''''''For Each dr As DataRow In dt.Rows
        ''''''''    sSQL = ""
        ''''''''    If dr("AllClients") Then
        ''''''''        sSQL = "'Client Task' AS TaskType, c.ClientId, c.Name AS Clients_Name, te2.TaskDate AS TaskEvents_TaskDate," &
        ''''''''            " te2.Comment AS TaskEvents_Comment" &
        ''''''''            " FROM Clients AS c LEFT OUTER JOIN (SELECT TaskId, TaskDate, Comment, ClientId" &
        ''''''''            " FROM TaskEvents AS te WHERE TaskId = " & dr("TaskId") & ") AS te2 ON c.ClientId = te2.ClientId"
        ''''''''        sSQL = sSQL & " WHERE ISNULL(c.ProspectFl,0) = 0"

        ''''''''ElseIf dr("ClientId") > 0 And dr("LocationId") = 0 Then

        ''''''''End If


        ''''''''If sSQL <> "" Then
        ''''''''    sSQL = " SELECT " & dr("TaskAssignmentId") & " AS TaskAssignmentId " & "," & dr("TaskId") & " AS TaskId," &
        ''''''''        QuoStr(dr("TaskMasterList_Name")) & " AS TaskName, " & QuoStr(dr("TaskDate")) & " AS TaskDate," &
        ''''''''        QuoStr(dr("TaskMasterList_Description")) & " AS TaskDescription," & sSQL
        ''''''''    If sReturnSQL <> "" Then sReturnSQL = sReturnSQL & " UNION "
        ''''''''    sReturnSQL = sReturnSQL & sSQL
        ''''''''End If
        ''''''''Next

        Return sReturnSQL
    End Function
End Module
