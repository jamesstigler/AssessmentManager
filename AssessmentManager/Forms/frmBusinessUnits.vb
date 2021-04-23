Public Class frmBusinessUnits
    Private bActivated As Boolean
    Private m_ClientId As Long
    Private m_ClientName As String

    Private DBUpdate() As typeDBUpdateInfo
    Private bChanged As Boolean
    Private iMouseClickColIndex As Integer = 0

    Public Property ClientId() As Long
        Get
            Return m_ClientId
        End Get
        Set(ByVal value As Long)
            m_ClientId = value
        End Set
    End Property
    Public Property ClientName As String
        Get
            Return m_ClientName
        End Get
        Set(value As String)
            m_ClientName = value
        End Set
    End Property

    Private Sub frmBusinessUnits_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If bActivated Then Exit Sub
        RefreshData()
        bActivated = True
    End Sub

    Private Function RefreshData() As Boolean
        Try
            Me.Text = m_ClientName & " Business Units"
            LoadBusinessUnits()

            Return True
        Catch ex As Exception
            MsgBox("Error in RefreshData:  " & ex.Message)
            Return False
        End Try
    End Function

    Private Sub frmBusinessUnits_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Dim Buttons(0) As Control

        Buttons(0) = cmdNewBusinessUnit
        PlaceButtons(Me, Buttons)

        If Me.WindowState = FormWindowState.Minimized Then Exit Sub
        dgBusinessUnits.Height = Me.Height - 80
    End Sub

    Private Function LoadBusinessUnits() As Boolean
        Dim bind As New BindingSource, sSQL As New StringBuilder, dtList As New DataTable

        Try
            sSQL.Append("SELECT BusinessUnitId, Name FROM BusinessUnits WHERE ClientId = ").Append(m_ClientId.ToString).Append(" ORDER BY Name")
            GetData(sSQL.ToString, dtList)
            dgBusinessUnits.Columns.Clear()
            bind.DataSource = dtList
            dgBusinessUnits.DataSource = bind
            dgBusinessUnits.Columns(0).Visible = False

            Return True
        Catch ex As Exception
            MsgBox("Error loading payments:  " & ex.Message)
            Return False
        End Try

    End Function

    Private Sub mnuContextDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuContextDelete.Click
        Try
            If iMouseClickColIndex >= 0 Then
                If dgBusinessUnits.SelectedRows.Count > 0 Then
                    If MsgBox("Are you sure you want to delete?", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then Exit Sub
                    Dim sSQL As String = ""
                    Dim row As DataGridViewRow
                    For Each row In dgBusinessUnits.SelectedRows
                        sSQL = "DELETE BusinessUnits WHERE BusinessUnitId = " & row.Cells("BusinessUnitId").Value
                        ExecuteSQL(sSQL)
                    Next
                    RefreshData()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error deleting:  " & ex.Message)
        End Try

    End Sub

    Private Sub dgBusinessUnits_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgBusinessUnits.CellEndEdit
        Try
            Dim sError As String = "", sId As String, sSQL As New StringBuilder, sName As String
            sId = dgBusinessUnits.Rows(e.RowIndex).Cells("BusinessUnitId").Value.ToString
            sName = dgBusinessUnits.Rows(e.RowIndex).Cells("Name").Value.ToString.Trim
            If sName = "" Then Exit Sub
            If sName.Length > 255 Then sName = sName.Substring(0, 255)
            sSQL.Append("UPDATE BusinessUnits SET Name = ").Append(QuoStr(sName)).Append(", ChangeType = 2, ChangeDate = GETDATE(), ChangeUser = ").Append(QuoStr(AppData.UserId))
            sSQL.Append(" WHERE BusinessUnitId = ").Append(sId)
            If ExecuteSQL(sSQL.ToString) < 1 Then
                MsgBox("Error saving:  Unable to save data, SQL = " & sSQL.ToString)
                Exit Sub
            End If
            dgBusinessUnits.Rows(e.RowIndex).ErrorText = String.Empty
        Catch ex As Exception
            MsgBox("Error saving:  " & ex.Message)
        End Try
    End Sub
    Private Sub dgBusinessUnits_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgBusinessUnits.CellMouseDown
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

    Private Sub cmdNewBusinessUnit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdNewBusinessUnit.Click
        Try
            Dim sName As String = Trim(InputBox("Enter name of business unit"))
            If sName = "" Then Exit Sub
            If sName.Length > 255 Then sName = sName.Substring(0, 255)
            Dim sId As String = CreateID(enumTable.enumBusinessUnits)
            Dim sSQL As New StringBuilder
            sSQL.Append("INSERT BusinessUnits (ClientId,BusinessUnitId,Name,AddUser)")
            sSQL.Append(" SELECT ").Append(m_ClientId).Append(",").Append(sId).Append(",").Append(QuoStr(sName)).Append(",").Append(QuoStr(AppData.UserId))
            If ExecuteSQL(sSQL.ToString) < 1 Then
                MsgBox("Error saving:  SQL = " & sSQL.ToString)
                Exit Sub
            End If
            RefreshData()
        Catch ex As Exception
            MsgBox("Error saving:  " & ex.Message)
        End Try
    End Sub
End Class