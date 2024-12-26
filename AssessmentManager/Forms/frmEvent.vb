Public Class frmEvent
    Private m_activated As Boolean = False
    Private m_ClientId As Long
    Private m_LocationId As Long
    Private m_AssessmentId As Long
    Private m_TaxYear As Integer
    Private m_EventId As Long
    Private m_PropType As enumTable
    Private m_EventList As New Collection
    Private m_tablename As String = ""
    Private m_changed As Boolean = False

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
    Public Property TaxYear() As Integer
        Get
            Return m_TaxYear
        End Get
        Set(ByVal value As Integer)
            m_TaxYear = value
        End Set
    End Property
    Public Property EventId() As Long
        Get
            Return m_EventId
        End Get
        Set(ByVal value As Long)
            m_EventId = value
        End Set
    End Property
    Public Property PropType() As Integer
        Get
            Return m_PropType
        End Get
        Set(ByVal value As Integer)
            m_PropType = value
        End Set
    End Property

    Private Sub InitInfo()
        If m_PropType = enumTable.enumLocationBPP Then
            m_tablename = "AssessmentsBPPEvents"
        Else
            m_tablename = "AssessmentsREEvents"
        End If
        m_EventList = New Collection
        Dim sql As New StringBuilder()
        sql.Append("SELECT EventId, EventName FROM EventList" & IIf(m_PropType = enumTable.enumLocationBPP, "BPP", "RE")).Append(" AS el")
        sql.Append(" ORDER BY EventName")
        Dim dt As New DataTable
        GetData(sql.ToString, dt)
        For Each dr As DataRow In dt.Rows
            cboEvents.Items.Add(dr("EventName"))
            m_EventList.Add(dr("EventId"), dr("EventName"))
        Next
        If m_EventId = 0 Then
            cboEvents.Enabled = True
        Else
            cboEvents.Enabled = False
        End If

    End Sub

    Private Sub frmEvent_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If m_activated Then Exit Sub
        InitInfo()
        RefreshData()
        m_activated = True
    End Sub

    Private Function RefreshData() As Boolean
        Try
            txtEventDate.Text = "" : txtEventNote.Text = "" : txtEventValue.Text = ""
            If m_EventId > 0 Then
                Dim dt As New DataTable
                Dim sql As String = "SELECT EventDate, EventValue, EventNote, (SELECT el.EventName FROM EventList" & IIf(m_PropType = enumTable.enumLocationBPP, "BPP", "RE") & " el WHERE el.EventId = " & m_EventId & ") AS EventName FROM " & m_tablename &
                    " WHERE ClientId = " & m_ClientId & " AND LocationId = " & m_LocationId & " AND AssessmentId = " & m_AssessmentId &
                    " AND TaxYear = " & m_TaxYear & " AND EventId = " & m_EventId
                GetData(sql, dt)
                If dt.Rows.Count > 0 Then
                    Dim dr As DataRow = dt.Rows(0)
                    If dr("EventDate").ToString <> "" Then txtEventDate.Text = Format(dr("EventDate"), csDateTime)
                    If dr("EventValue").ToString <> "" Then txtEventValue.Text = Format(dr("EventValue"), csDol)
                    txtEventNote.Text = dr("EventNote").ToString.Trim
                    cboEvents.Text = dr("EventName").ToString
                End If
            End If

            Return True
        Catch ex As Exception
            MsgBox("Error in RefreshData:  " & ex.Message)
            Return False
        End Try
    End Function

    Private Sub _GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEventDate.GotFocus,
            txtEventNote.GotFocus, txtEventValue.GotFocus, cboEvents.GotFocus
        sender.selectall()
    End Sub

    Private Sub SaveData()
        Try
            If m_changed = False Then Exit Sub
            If cboEvents.Text.Trim = "" Then Exit Sub
            Dim eventid As Long = 0
            If m_EventId > 0 Then
                eventid = m_EventId
            Else
                eventid = m_EventList(cboEvents.Text)
            End If
            SaveEvent(m_tablename, eventid, txtEventDate.Text, txtEventValue.Text, txtEventNote.Text, m_ClientId, m_LocationId, m_AssessmentId, m_TaxYear)
        Catch ex As Exception
            MsgBox("Error saving data:  " & ex.Message)
        End Try
    End Sub
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        SaveData()
        Me.Close()
    End Sub

    Private Sub _TextChanged(sender As Object, e As EventArgs) Handles txtEventDate.TextChanged, txtEventNote.TextChanged, txtEventValue.TextChanged, cboEvents.TextChanged
        If m_activated Then m_changed = True
    End Sub
End Class