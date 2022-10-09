Module modTasks
    Public Function SaveTaskAssignment(ByVal taxyear As Integer, ByVal taskid As String, proptype As String, taskdate As String, ByVal clientid As String,
            ByVal locationid As String, ByVal assessmentid As String, ByRef msg As String) As Boolean
        Dim sql As New StringBuilder
        Try
            sql.Append(" INSERT TaskAssignments (TaskId,PropType,ClientId,LocationId,AssessmentId,TaxYear,TaskDate,AddUser)")
            sql.Append(" SELECT ").Append(taskid).Append(",").Append(QuoStr(proptype)).Append(",").Append(clientid)
            sql.Append(",").Append(locationid).Append(",").Append(assessmentid).Append(",").Append(taxyear)
            sql.Append(",").Append(QuoStr(taskdate))
            sql.Append(",").Append(QuoStr(AppData.UserId))
            sql.Append(" WHERE NOT EXISTS (SELECT ta2.TaskId FROM TaskAssignments ta2 WHERE ta2.TaskId = ").Append(taskid)
            sql.Append(" AND ta2.PropType = ").Append(QuoStr(proptype))
            sql.Append(" AND ta2.TaxYear = ").Append(taxyear)
            sql.Append(" AND ta2.ClientId = ").Append(clientid)
            sql.Append(" AND ta2.LocationId = ").Append(locationid)
            sql.Append(" AND ta2.AssessmentId = ").Append(assessmentid).Append(")")
            ExecuteSQL(sql.ToString)
            Return True
        Catch ex As Exception
            MsgBox("Error assigning task:  " & ex.Message)
            Return False
        End Try
    End Function

    Public Function BuildTaskAssignmentQuery()
        Return BuildTaskAssignmentQuery(enumPropType.Both, 0, 0, 0, 0)
    End Function
    Public Function BuildTaskAssignmentQuery(proptype As enumPropType, clientid As Long, locationid As Long, assessmentid As Long, taxyear As Integer) As String
        Dim sql As New StringBuilder

        sql.Append("SELECT tm.TaskId, tm.Name AS TaskName, tm.Description AS TaskDescription, ta.PropType, ta.ClientId, ta.LocationId, ta.AssessmentId, ta.TaxYear,")
        sql.Append(" ta.TaskDate, ta.Notes AS TaskNotes, ta.Email AS TaskEmail, ta.Website AS TaskWebsite, ta.CompletedFl AS TaskCompletedFl, ta.CompletedDate AS TaskCompletedDate,")
        sql.Append(" ta.Priority AS TaskPriority, ta.ContactInfo AS TaskContactInfo, c.Name As ClientName, l.Address, l.City, l.StateCd, l.ClientLocationId, l.ConsultantName,")
        sql.Append(" c.ClientCoordinatorName, c.BPPConsultantName AS ConsultantName, a.AcctNum, 'BPP' AS PropertyType")
        sql.Append(" FROM LocationsBPP AS l")
        sql.Append(" INNER JOIN Clients AS c ON l.ClientId = c.ClientId")
        sql.Append(" INNER JOIN AssessmentsBPP AS a ON l.ClientId = a.ClientId And l.LocationId = a.LocationId And l.TaxYear = a.TaxYear")
        sql.Append(" INNER JOIN TaskMasterList AS tm")
        sql.Append(" INNER JOIN TaskAssignments AS ta ON tm.TaskId = ta.TaskId ON a.ClientId = ta.ClientId And a.LocationId = ta.LocationId")
        sql.Append(" And a.AssessmentId = ta.AssessmentId And a.TaxYear = ta.TaxYear")
        sql.Append(" WHERE ta.PropType = 'P'")
        If proptype = enumPropType.BPP Then
            If clientid <> 0 Then sql.Append(" AND a.ClientId = ").Append(clientid.ToString)
            If locationid <> 0 Then sql.Append(" AND a.LocationId = ").Append(locationid.ToString)
            If assessmentid <> 0 Then sql.Append(" AND a.AssessmentId = ").Append(assessmentid.ToString)
        End If

        sql.Append(" UNION SELECT tm.TaskId, tm.Name AS TaskName, tm.Description AS TaskDescription, ta.PropType, ta.ClientId, ta.LocationId, ta.AssessmentId, ta.TaxYear,")
        sql.Append(" ta.TaskDate, ta.Notes AS TaskNotes, ta.Email AS TaskEmail, ta.Website AS TaskWebsite, ta.CompletedFl AS TaskCompletedFl, ta.CompletedDate AS TaskCompletedDate,")
        sql.Append(" ta.Priority AS TaskPriority, ta.ContactInfo AS TaskContactInfo, c.Name As ClientName, l.Address, l.City, l.StateCd, l.ClientLocationId, l.ConsultantName,")
        sql.Append(" c.ClientCoordinatorName, c.REConsultantName AS ConsultantName, a.AcctNum, 'Real' AS PropertyType")
        sql.Append(" FROM LocationsRE AS l")
        sql.Append(" INNER JOIN Clients AS c ON l.ClientId = c.ClientId")
        sql.Append(" INNER JOIN AssessmentsRE AS a ON l.ClientId = a.ClientId And l.LocationId = a.LocationId And l.TaxYear = a.TaxYear")
        sql.Append(" INNER JOIN TaskMasterList AS tm")
        sql.Append(" INNER JOIN TaskAssignments AS ta ON tm.TaskId = ta.TaskId ON a.ClientId = ta.ClientId And a.LocationId = ta.LocationId")
        sql.Append(" And a.AssessmentId = ta.AssessmentId And a.TaxYear = ta.TaxYear")
        sql.Append(" WHERE ta.PropType = 'R'")
        If proptype = enumPropType.Real Then
            If clientid <> 0 Then sql.Append(" AND a.ClientId = ").Append(clientid.ToString)
            If locationid <> 0 Then sql.Append(" AND a.LocationId = ").Append(locationid.ToString)
            If assessmentid <> 0 Then sql.Append(" AND a.AssessmentId = ").Append(assessmentid.ToString)
        End If

        Return sql.ToString

    End Function
End Module
