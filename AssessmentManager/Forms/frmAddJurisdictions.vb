Public Class frmAddJurisdictions
    Private bActivated As Boolean
    Private m_TaxYear As Integer
    Private m_StateCd As String
    Private m_PropType As enumTable
    Private m_Assessments As Collection

    Public Property TaxYear() As Integer
        Get
            Return m_TaxYear
        End Get
        Set(ByVal value As Integer)
            m_TaxYear = value
        End Set
    End Property
    Public Property StateCd() As String
        Get
            Return m_StateCd
        End Get
        Set(ByVal value As String)
            m_StateCd = value
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
    Public Property Assessments() As Collection
        Get
            Return m_Assessments
        End Get
        Set(ByVal value As Collection)
            m_Assessments = value
        End Set
    End Property



    Private Sub frmAddJurisdictions_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If bActivated Then Exit Sub
        If Not RefreshData() Then Me.Close()
        bActivated = True
    End Sub
    Private Sub frmAddJurisdictions_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Dim Buttons(1) As Control

        Buttons(0) = cmdOK
        Buttons(1) = cmdCancel
        PlaceButtons(Me, Buttons)

        If Me.WindowState = FormWindowState.Minimized Then Exit Sub
        dgJurisdictions.Height = Me.Height - 80
    End Sub
    Public Function RefreshData() As Boolean
        Dim sSQL As String = "", dt As New DataTable
        Dim bind As New BindingSource

        Try
            sSQL = "SELECT j.JurisdictionId, j.Name, j.StateCd FROM Jurisdictions AS j" & _
                " WHERE j.TaxYear = " & m_TaxYear & " AND j.StateCd = " & QuoStr(m_StateCd) & " ORDER BY j.Name"
            Dim lRows As Long = GetData(sSQL, dt)
            bind.DataSource = dt
            dgJurisdictions.DataSource = bind
            For Each column As DataGridViewColumn In dgJurisdictions.Columns
                If IsIndexField(column.Name) Or column.Name = "TaxYear" Then
                    column.Visible = False
                End If
                If column.Name = "Name" Then column.Width = 155
                If column.Name = "StateCd" Then column.Width = 50
            Next
            Return True
        Catch ex As Exception
            MsgBox("Error in RefreshData:  " & ex.Message)
            Return False
        End Try
    End Function

    Private Sub cmdOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Try
            If dgJurisdictions.SelectedRows.Count > 0 Then
                Dim sSQL As String = ""
                Dim row As DataGridViewRow
                Dim structAssess As New structAssessment
                For Each row In dgJurisdictions.SelectedRows
                    For Each structAssess In m_Assessments
                        Dim sErrorMsg As String = ""
                        If Not AddAssessmentJurisdiction(structAssess.ClientId, structAssess.LocationId, structAssess.AssessmentId, _
                                row.Cells("JurisdictionId").Value, m_PropType, m_TaxYear, sErrorMsg) Then
                            MsgBox(sErrorMsg)
                        End If
                    Next
                Next
            End If
            Me.Close()
        Catch ex As Exception
            MsgBox("Error adding jurisdictions:  " & ex.Message)
        End Try
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub
End Class