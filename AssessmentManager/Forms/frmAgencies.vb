Public Class frmAgencies
    Private bActivated As Boolean
    Private DBUpdate() As typeDBUpdateInfo
    Private bChanged As Boolean
    Private iMouseClickColIndex As Integer = 0

    Private Sub frmAgencies_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If bActivated Then Exit Sub
        RefreshData()
        bActivated = True
    End Sub
    Private Sub frmAgencies_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Dim Buttons(0) As Control
        Buttons(0) = cmdNewAgency
        PlaceButtons(Me, Buttons)
        If Me.WindowState = FormWindowState.Minimized Then Exit Sub
    End Sub
    Private Function RefreshData() As Boolean
        Try
            LoadAgencies()
            Return True
        Catch ex As Exception
            MsgBox("Error in RefreshData:  " & ex.Message)
            Return False
        End Try
    End Function
    Private Function LoadAgencies() As Boolean
        Dim bind As New BindingSource, sSQL As String, dtList As New DataTable

        Try
            sSQL = "SELECT AgencyName, AgencyId FROM Agencies ORDER BY AgencyName"
            GetData(sSQL, dtList)
            dgAgencies.Columns.Clear()
            bind.DataSource = dtList
            dgAgencies.DataSource = bind

            For Each column As DataGridViewTextBoxColumn In dgAgencies.Columns
                Select Case column.Name
                    Case "AgencyName"
                        column.HeaderText = "Name"
                        column.Width = 750
                        column.ReadOnly = False
                        column.DefaultCellStyle.BackColor = Color.LightGray
                        column.MaxInputLength = 255
                    Case "AgencyId"
                        column.Visible = False
                    Case Else
                        column.Visible = False
                End Select
            Next

            Return True
        Catch ex As Exception
            MsgBox("Error loading agencies:  " & ex.Message)
            Return False
        End Try
    End Function
    Private Sub mnuContextDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuContextDelete.Click
        Try
            If iMouseClickColIndex >= 0 Then
                If dgAgencies.SelectedRows.Count > 0 Then
                    If MsgBox("Are you sure you want to delete?", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then Exit Sub
                    Dim sSQL As String = ""
                    Dim row As DataGridViewRow
                    For Each row In dgAgencies.SelectedRows
                        sSQL = "DELETE AgencyContacts WHERE AgencyId = " & row.Cells("AgencyId").Value.ToString & " DELETE Agencies WHERE AgencyId = " & row.Cells("AgencyId").Value.ToString
                        ExecuteSQL(sSQL)
                    Next
                    RefreshData()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error deleting:  " & ex.Message)
        End Try
    End Sub
    Private Sub dgAgencies_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgAgencies.CellEndEdit
        Try
            Dim sError As String = "", sField As String = ""
            sField = dgAgencies.Columns(e.ColumnIndex).Name

            If Not UpdateAgency(dgAgencies.Rows(e.RowIndex).Cells("AgencyId").Value, sField,
                    Trim(UnNullToString(dgAgencies.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)), sError) Then
                MsgBox(sError)
            End If
            dgAgencies.Rows(e.RowIndex).ErrorText = String.Empty
        Catch ex As Exception

        End Try
    End Sub

    Private Function UpdateAgency(ByVal sId As String, ByVal sField As String, ByVal sValue As String, ByRef sError As String) As Boolean
        Dim sSQL As String = ""
        sError = ""
        Try
            sSQL = "UPDATE Agencies SET " & sField & " = " & QuoStr(sValue) & ", ChangeUser = " & QuoStr(AppData.UserId) & ", ChangeType = 2, ChangeDate = GETDATE() WHERE AgencyId = " & sId
            If ExecuteSQL(sSQL) <> 1 Then
                sError = "Error updating agency"
                Return False
            End If

            Return True
        Catch ex As Exception
            sError = "Error updating agency:  " & ex.Message
            Return False
        End Try
    End Function
    Private Sub dgAgencies_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgAgencies.CellMouseDown
        iMouseClickColIndex = -1
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
    Private Sub dgAgencies_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgAgencies.CellDoubleClick
        Try
            If e.RowIndex >= 0 Then
                OpenAgency(dgAgencies.Rows(e.RowIndex).Cells("AgencyId").Value.ToString.Trim, dgAgencies.Rows(e.RowIndex).Cells("AgencyName").Value.ToString.Trim)
            End If
        Catch ex As Exception
            MsgBox("Error:  " & ex.Message)
        End Try
    End Sub
    Private Sub cmdNewAgency_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdNewAgency.Click
        Dim sName As String = Microsoft.VisualBasic.Left(Trim(InputBox("Agency Name")), 255)
        If sName = "" Then Exit Sub
        Dim sError As String = ""

        If AddAgency(sName, sError) Then
            RefreshData()
        Else
            MsgBox(sError)
        End If
    End Sub
    Private Function AddAgency(sName As String, ByRef sError As String) As Boolean
        Dim sSQL As New StringBuilder
        sError = ""
        Try
            Dim id As String = ""
            id = CreateID(enumTable.enumAgency)
            sSQL.Append("INSERT Agencies (AgencyId,AgencyName,AddUser)")
            sSQL.Append(" SELECT ").Append(id).Append(",").Append(QuoStr(sName)).Append(",").Append(QuoStr(AppData.UserId))
            If ExecuteSQL(sSQL.ToString) <> 1 Then
                sError = "Error creating agency"
                Return False
            End If
            Return True
        Catch ex As Exception
            sError = "Error creating agency:  " & ex.Message
            Return False
        End Try
    End Function
    Public Sub OpenAgency(ByVal agencyid As String, ByVal agencyname As String)
        If agencyid = "" Then Exit Sub
        Dim frm As Form, frmc As frmAgencyContacts

        For Each frm In MDIParent1.MdiChildren
            If frm.Name = "frmAgencyContacts" Then
                frmc = frm
                If frmc.AgencyId = agencyid Then
                    frmc.AgencyId = agencyid
                    frmc.AgencyName = agencyname
                    frmc.Focus()
                    Exit Sub
                End If
            End If
        Next
        frmc = New frmAgencyContacts
        frmc.AgencyId = agencyid
        frmc.AgencyName = agencyname
        frmc.MdiParent = MDIParent1
        frmc.Show()
    End Sub

End Class