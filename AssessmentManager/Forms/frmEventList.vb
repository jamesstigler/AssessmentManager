Public Class frmEventList
    Private bActivated As Boolean
    Private m_PropType As enumTable

    Private DBUpdate() As typeDBUpdateInfo
    Private bChanged As Boolean
    Private iMouseClickColIndex As Integer = 0
    Private sTable As String = ""

    Public Property PropType() As Integer
        Get
            Return m_PropType
        End Get
        Set(ByVal value As Integer)
            m_PropType = value
        End Set
    End Property

    Private Sub frmEventList_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If bActivated Then Exit Sub
        RefreshData()
        bActivated = True
    End Sub

    Private Function RefreshData() As Boolean
        Try
            sTable = IIf(m_PropType = enumTable.enumLocationBPP, "EventListBPP", "EventListRE")
            Me.Text = IIf(m_PropType = enumTable.enumLocationBPP, "BPP", "Real Estate") & " Event List"
            If AppData.IsAdministrator = False Then
                cmdNewEvent.Enabled = False
                mnuContextDelete.Enabled = False
                mnuContextRename.Enabled = False
            End If
            LoadEvents()

            Return True
        Catch ex As Exception
            MsgBox("Error in RefreshData:  " & ex.Message)
            Return False
        End Try
    End Function

    Private Sub frmEventList_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Dim Buttons(0) As Control

        Buttons(0) = cmdNewEvent
        PlaceButtons(Me, Buttons)

        If Me.WindowState = FormWindowState.Minimized Then Exit Sub
        dgEvents.Height = Me.Height - 80
    End Sub

    Private Function LoadEvents() As Boolean
        Dim bind As New BindingSource, sSQL As New StringBuilder, dtList As New DataTable

        Try
            sSQL.Append("SELECT EventId, EventName FROM " & sTable & " ORDER BY EventName")
            GetData(sSQL.ToString, dtList)
            dgEvents.Columns.Clear()
            bind.DataSource = dtList
            dgEvents.DataSource = bind
            dgEvents.Columns("EventId").Visible = False
            dgEvents.Columns("EventName").HeaderText = "Event Name"
            dgEvents.Columns("EventName").ReadOnly = False
            If AppData.IsAdministrator Then
                dgEvents.ReadOnly = False
            Else
                dgEvents.ReadOnly = True
            End If

            Return True
        Catch ex As Exception
            MsgBox("Error loading events:  " & ex.Message)
            Return False
        End Try

    End Function

    Private Sub mnuContextDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuContextDelete.Click
        Try
            If AppData.IsAdministrator = False Then Exit Sub
            If iMouseClickColIndex >= 0 Then
                If dgEvents.SelectedRows.Count > 0 Then
                    If MsgBox("Are you sure you want to delete?", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then Exit Sub
                    Dim sSQL As String = ""
                    Dim row As DataGridViewRow
                    For Each row In dgEvents.SelectedRows
                        sSQL = "DELETE " & sTable & " WHERE EventId = " & row.Cells("EventId").Value
                        ExecuteSQL(sSQL)
                    Next
                    RefreshData()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error deleting:  " & ex.Message)
        End Try

    End Sub

    Private Sub dgEvents_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgEvents.CellEndEdit
        Try
            If AppData.IsAdministrator = False Then Exit Sub
            Dim sError As String = "", sId As String, sSQL As New StringBuilder, sName As String
            sId = dgEvents.Rows(e.RowIndex).Cells("EventId").Value.ToString
            sName = dgEvents.Rows(e.RowIndex).Cells("EventName").Value.ToString.Trim
            If sName = "" Then Exit Sub
            If sName.Length > 255 Then sName = sName.Substring(0, 255)
            sSQL.Append("UPDATE " & sTable & " SET EventName = ").Append(QuoStr(sName)).Append(", ChangeType = 2, ChangeDate = GETDATE(), ChangeUser = ").Append(QuoStr(AppData.UserId))
            sSQL.Append(" WHERE EventId = ").Append(sId)
            If ExecuteSQL(sSQL.ToString) < 1 Then
                MsgBox("Error saving:  Unable to save data, SQL = " & sSQL.ToString)
                Exit Sub
            End If
            dgEvents.Rows(e.RowIndex).ErrorText = String.Empty
        Catch ex As Exception
            MsgBox("Error saving:  " & ex.Message)
        End Try
    End Sub
    Private Sub dgEvents_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgEvents.CellMouseDown
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

    Private Sub cmdNewEvent_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdNewEvent.Click
        Try
            If AppData.IsAdministrator = False Then Exit Sub
            Dim sName As String = Trim(InputBox("Enter name of event"))
            If sName = "" Then Exit Sub
            If sName.Length > 255 Then sName = sName.Substring(0, 255)
            Dim sSQL As New StringBuilder
            sSQL.Append("INSERT " & sTable & " (EventName,AddUser)")
            sSQL.Append(" SELECT ").Append(QuoStr(sName)).Append(",").Append(QuoStr(AppData.UserId))
            If ExecuteSQL(sSQL.ToString) < 1 Then
                MsgBox("Error saving:  SQL = " & sSQL.ToString)
                Exit Sub
            End If
            RefreshData()
        Catch ex As Exception
            MsgBox("Error saving:  " & ex.Message)
        End Try
    End Sub

    Private Sub dgEvents_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgEvents.CellDoubleClick
        Try
            If e.RowIndex >= 0 Then
                OpenEvent(dgEvents.Rows(e.RowIndex).Cells("EventId").Value.ToString.Trim, dgEvents.Rows(e.RowIndex).Cells("EventName").Value.ToString.Trim)
            End If
        Catch ex As Exception
            MsgBox("Error:  " & ex.Message)
        End Try
    End Sub

    Public Sub OpenEvent(ByVal eventid As String, ByVal eventname As String)
        'If eventid.Trim = "" Then Exit Sub
        'Dim frm As Form, frmc As frmEvent

        'For Each frm In MDIParent1.MdiChildren
        '    If frm.Name = "frmEvent" Then
        '        frmc = frm
        '        If frmc.eventid = eventid And frmc.proptype = m_PropType Then
        '            frmc.Focus()
        '            Exit Sub
        '        End If
        '    End If
        'Next
        'frmc = New frmevent
        'frmc.eventId = eventid
        'frmc.eventName = eventname
        'frmc.proptype = m_PropType
        'frmc.MdiParent = MDIParent1
        'frmc.Show()
    End Sub

End Class