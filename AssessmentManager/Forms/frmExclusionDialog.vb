Public Class frmExclusionDialog
    Private m_ClientId As Long
    Private m_TaxYear As Integer
    Private bActivated As Boolean
    Private AssessmentList() As structAssessment
    Public Property ClientId() As Long
        Get
            Return m_ClientId
        End Get
        Set(ByVal value As Long)
            m_ClientId = value
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

    Private Sub frmExclusionDialog_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        If bActivated Then Exit Sub
        If Not RefreshData() Then Me.Close()
        bActivated = True
    End Sub
    Private Function RefreshData() As Boolean
        Dim sSQL As String = "", dt As New DataTable, sAdd As String = ""
        ReDim AssessmentList(0)
        Try
            sSQL = "SELECT 'P' AS PropType, c.Name as Name, ISNULL(l.Address,'') AS Address," & _
                " ISNULL(a.AcctNum,'') AS AcctNum, a.ClientId, a.LOcationId, a.AssessmentId" & _
                " FROM AssessmentsBPP a" & _
                " INNER JOIN LocationsBPP l ON l.ClientId = a.ClientId AND l.LocationId = a.LocationId" & _
                " AND l.TaxYear = a.TaxYear" & _
                " INNER JOIN Clients c ON c.ClientId = l.ClientId" & _
                " WHERE l.ClientId = " & m_ClientId & _
                " AND l.TaxYear = " & m_TaxYear
            sSQL = sSQL & " UNION SELECT 'R' AS PropType, c.Name as Name, ISNULL(l.Address,'') AS Address," & _
                " ISNULL(a.AcctNum,'') AS AcctNum, a.ClientId, a.LOcationId, a.AssessmentId" & _
                " FROM AssessmentsRE a" & _
                " INNER JOIN LocationsRE l ON l.ClientId = a.ClientId AND l.LocationId = a.LocationId" & _
                " AND l.TaxYear = a.TaxYear" & _
                " INNER JOIN Clients c ON c.ClientId = l.ClientId" & _
                " WHERE l.ClientId = " & m_ClientId & _
                " AND l.TaxYear = " & m_TaxYear
            sSQL = sSQL & " ORDER BY 1, 3, 4"
            Dim lRows As Long = GetData(sSQL, dt)
            If lRows > 0 Then ReDim AssessmentList(lRows - 1)
            If lRows > 0 Then
                lblClient.Text = dt.Rows(0)("Name")
                Me.Text = "Savings Exclusions:  " & dt.Rows(0)("Name")
            End If
            lRows = 0
            For Each dr As DataRow In dt.Rows
                sAdd = dr("PropType") & "  " & dr("Address") & "  " & dr("AcctNum")
                cboAccount.Items.Add(sAdd)
                With AssessmentList(lRows)
                    .ClientId = dr("ClientId")
                    .LocationId = dr("LocationId")
                    .AssessmentId = dr("AssessmentId")
                    .Description = sAdd
                    .PropType = dr("PropType")
                End With
                lRows = lRows + 1
            Next

            Return True
        Catch ex As Exception
            MsgBox("Error in RefreshData:  " & ex.Message)
            Return False
        End Try
    End Function

    Private Sub cmdCancel_Click(sender As Object, e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As System.EventArgs) Handles cmdSave.Click
        Dim l As Long = 0
        Try
            For l = 0 To UBound(AssessmentList)
                With AssessmentList(l)
                    If .Description = cboAccount.Text Then
                        Dim eExclCd As enumSavingsExclusionCd = enumSavingsExclusionCd.enumNone
                        If chkEntire.Checked Then
                            eExclCd = enumSavingsExclusionCd.enumEntire
                        Else
                            If chkNotified.Checked Then
                                If chkAbatements.Checked And chkFreeport.Checked Then
                                    eExclCd = enumSavingsExclusionCd.enumNotifiedAbatementsFreeport
                                ElseIf chkAbatements.Checked = False And chkFreeport.Checked = False Then
                                    eExclCd = enumSavingsExclusionCd.enumNotified
                                ElseIf chkAbatements.Checked And chkFreeport.Checked = False Then
                                    eExclCd = enumSavingsExclusionCd.enumNotifiedAbatements
                                ElseIf chkAbatements.Checked = False And chkFreeport.Checked Then
                                    eExclCd = enumSavingsExclusionCd.enumNotifiedFreeport
                                End If
                            ElseIf chkClient.Checked Then
                                If chkAbatements.Checked And chkFreeport.Checked Then
                                    eExclCd = enumSavingsExclusionCd.enumClientAbatementsFreeport
                                ElseIf chkAbatements.Checked = False And chkFreeport.Checked = False Then
                                    eExclCd = enumSavingsExclusionCd.enumClient
                                ElseIf chkAbatements.Checked And chkFreeport.Checked = False Then
                                    eExclCd = enumSavingsExclusionCd.enumClientAbatements
                                ElseIf chkAbatements.Checked = False And chkFreeport.Checked Then
                                    eExclCd = enumSavingsExclusionCd.enumClientFreeport
                                End If
                            Else
                                If chkAbatements.Checked = False And chkFreeport.Checked = False Then
                                    eExclCd = enumSavingsExclusionCd.enumNone
                                ElseIf chkAbatements.Checked = True And chkFreeport.Checked = False Then
                                    eExclCd = enumSavingsExclusionCd.enumAbatements
                                ElseIf chkAbatements.Checked = False And chkFreeport.Checked Then
                                    eExclCd = enumSavingsExclusionCd.enumFreeport
                                ElseIf chkAbatements.Checked And chkFreeport.Checked Then
                                    eExclCd = enumSavingsExclusionCd.enumAbatementsFreeport
                                End If
                            End If
                        End If
                        Dim sSQL As String = "UPDATE " & IIf(.PropType = "R", "AssessmentsRE", "AssessmentsBPP") & _
                            " SET SavingsExclusionCd = " & eExclCd & _
                            ", ChangeDate = GETDATE(), ChangeUser = " & QuoStr(AppData.UserId) & _
                            " WHERE ClientId = " & .ClientId & _
                            " AND AssessmentId = " & .AssessmentId & _
                            " AND LocationId = " & .LocationId & _
                            " AND TaxYear = " & m_TaxYear
                        ExecuteSQL(sSQL)
                        Exit For
                    End If
                End With
            Next
        Catch ex As Exception
            MsgBox("Error saving:  " & ex.Message)
        End Try
    End Sub

    Private Sub chkClient_Click(sender As Object, e As System.EventArgs) Handles chkClient.Click, chkNotified.Click
        If sender.checked Then
            If sender.name = "chkNotified" And chkClient.Checked Then chkClient.Checked = False
            If sender.name = "chkClient" And chkNotified.Checked Then chkNotified.Checked = False
        End If

    End Sub
End Class