Public Class frmUsers
    Private bActivated As Boolean

    Private DBUpdate() As typeDBUpdateInfo
    Private bChanged As Boolean
    Private iMouseClickColIndex As Integer = 0

    Private Function RefreshData() As Boolean
        Try
            LoadUsers()
            Return True
        Catch ex As Exception
            MsgBox("Error in RefreshData:  " & ex.Message)
            Return False
        End Try
    End Function

    Private Sub frmUsers_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        If bActivated Then Exit Sub
        RefreshData()
        bActivated = True
    End Sub

    Private Sub frmUsers_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Dim Buttons(0) As Control
        Buttons(0) = cmdNewUser
        PlaceButtons(Me, Buttons)
        If Me.WindowState = FormWindowState.Minimized Then Exit Sub
    End Sub

    Private Function LoadUsers() As Boolean
        Dim bind As New BindingSource, sSQL As String, dtList As New DataTable

        Try
            sSQL = "SELECT ConsultantName, FullName, ConsultantId, Phone, EMail FROM Consultants ORDER BY ConsultantName"
            GetData(sSQL, dtList)
            dgUsers.Columns.Clear()
            bind.DataSource = dtList
            dgUsers.DataSource = bind

            For Each column As DataGridViewTextBoxColumn In dgUsers.Columns
                Select Case column.Name
                    Case "ConsultantName"
                        column.HeaderText = "Name"
                        column.Width = 150
                        column.ReadOnly = True
                        column.DefaultCellStyle.BackColor = Color.LightGray
                    Case ("FullName")
                        column.HeaderText = "Full Name"
                        column.Width = 200
                        column.MaxInputLength = 255
                    Case "ConsultantId"
                        column.HeaderText = "User ID"
                        column.Width = 150
                        column.MaxInputLength = 50
                    Case "Phone"
                        column.HeaderText = "Phone"
                        column.Width = 150
                        column.MaxInputLength = 50
                    Case "EMail"
                        column.HeaderText = "E-Mail"
                        column.Width = 275
                        column.MaxInputLength = 255
                    Case Else
                        column.Visible = False
                End Select
            Next

            Return True
        Catch ex As Exception
            MsgBox("Error loading users:  " & ex.Message)
            Return False
        End Try
    End Function

    Private Sub mnuContextDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuContextDelete.Click
        Try
            If iMouseClickColIndex >= 0 Then
                If dgUsers.SelectedRows.Count > 0 Then
                    If MsgBox("Are you sure you want to delete?", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then Exit Sub
                    Dim sSQL As String = ""
                    Dim row As DataGridViewRow
                    For Each row In dgUsers.SelectedRows
                        sSQL = "DELETE Consultants WHERE ConsultantName = " & QuoStr(row.Cells("ConsultantName").Value)
                        ExecuteSQL(sSQL)
                    Next
                    RefreshData()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error deleting:  " & ex.Message)
        End Try
    End Sub

    Private Sub dgUsers_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgUsers.CellEndEdit
        Try
            Dim sError As String = "", sField As String = ""
            sField = dgUsers.Columns(e.ColumnIndex).Name

            If Not UpdateUser(dgUsers.Rows(e.RowIndex).Cells("ConsultantName").Value, sField, _
                    Trim(UnNullToString(dgUsers.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)), sError) Then
                MsgBox(sError)
            End If
            dgUsers.Rows(e.RowIndex).ErrorText = String.Empty
        Catch ex As Exception

        End Try
    End Sub
    Private Function UpdateUser(ByVal sConsultantName As String, ByVal sField As String, ByVal sValue As String, ByRef sError As String) As Boolean
        Dim sSQL As String = ""
        sError = ""
        Try
            sSQL = "UPDATE Consultants SET " & sField & " = " & QuoStr(sValue) & ", ChangeUser = " & QuoStr(AppData.UserId) & ", ChangeType = 2, ChangeDate = GETDATE() WHERE ConsultantName = " & QuoStr(sConsultantName)
            If ExecuteSQL(sSQL) <> 1 Then
                sError = "Error updating user"
                Return False
            End If

            Return True
        Catch ex As Exception
            sError = "Error updating user:  " & ex.Message
            Return False
        End Try
    End Function
    Private Sub dgUsers_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgUsers.CellMouseDown
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

    Private Sub cmdNewUser_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdNewUser.Click
        Dim sShort As String = Trim(InputBox("Consultant short name"))
        If sShort = "" Then Exit Sub
        Dim sFull As String = Trim(InputBox("Full name"))
        Dim sUserId = Trim(InputBox("User ID"))
        Dim sError As String = ""

        If AddUser(sShort, sFull, sUserId, sError) Then
            RefreshData()
        Else
            MsgBox(sError)
        End If
    End Sub
    Private Function AddUser(sShort As String, sFull As String, sId As String, ByRef sError As String) As Boolean
        Dim sSQL As New StringBuilder
        sError = ""
        Try
            sSQL.Append("INSERT Consultants (ConsultantName,ConsultantId,FullName,AddUser)")
            sSQL.Append(" SELECT ").Append(QuoStr(sShort)).Append(",").Append(QuoStr(sId)).Append(",").Append(QuoStr(sFull)).Append(",").Append(QuoStr(AppData.UserId))
            If ExecuteSQL(sSQL.ToString) <> 1 Then
                sError = "Error creating user"
                Return False
            End If

            Return True
        Catch ex As Exception
            sError = "Error creating user:  " & ex.Message
            Return False
        End Try

    End Function

End Class