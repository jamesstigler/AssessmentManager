Public Class frmInstallments
    Private bActivated As Boolean
    Private m_ClientId As Long
    Private m_LocationId As Long
    Private m_AssessmentId As Long
    Private m_TaxYear As Integer
    Private m_CollectorId As Long
    Private m_PropType As enumTable
    Private m_JurisdictionId As Long
    Private sPropType As String

    Private DBUpdate() As typeDBUpdateInfo
    Private bChanged As Boolean
    Private iMouseClickColIndex As Integer = 0

    Public Property TaxYear() As Integer
        Get
            Return m_TaxYear
        End Get
        Set(ByVal value As Integer)
            m_TaxYear = value
        End Set
    End Property
    Public Property CollectorId() As Long
        Get
            Return m_CollectorId
        End Get
        Set(ByVal value As Long)
            m_CollectorId = value
        End Set
    End Property
    Public Property JurisdictionId() As Long
        Get
            Return m_JurisdictionId
        End Get
        Set(ByVal value As Long)
            m_JurisdictionId = value
        End Set
    End Property
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
    Public Property PropType() As Integer
        Get
            Return m_PropType
        End Get
        Set(ByVal value As Integer)
            m_PropType = value
        End Set
    End Property


    Private Sub frmBPPAssessment_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If bActivated Then Exit Sub

        If m_PropType = enumTable.enumLocationBPP Then sPropType = "BPP" Else sPropType = "RE"
        RefreshData()

        bActivated = True

    End Sub


    Private Function RefreshData() As Boolean
        Dim sError As String = "", dt As New DataTable, sSQL As String = "", dr As DataRow, i As Integer = 0

        Try
            sSQL = "SELECT c.Name AS Clients_Name, a.AcctNum, j.Name AS Jurisdictions_Name, a.AssessmentId," & _
                " j.JurisdictionId, l.Address, co.Name AS Collectors_Name, l.City, l.StateCd," & _
                " co.Payee, a.ClientId, a.LocationId, a.TaxYear, co.CollectorId" & _
                " FROM AssessmentDetail" & sPropType & " AS ad INNER JOIN" & _
                " Assessments" & sPropType & " AS a ON ad.ClientId = a.ClientId AND ad.LocationId = a.LocationId AND" & _
                " ad.AssessmentId = a.AssessmentId AND" & _
                " ad.TaxYear = a.TaxYear INNER JOIN" & _
                " Jurisdictions AS j ON ad.JurisdictionId = j.JurisdictionId AND ad.TaxYear = j.TaxYear INNER JOIN" & _
                " Locations" & sPropType & " AS l INNER JOIN" & _
                " Clients AS c ON l.ClientId = c.ClientId ON a.ClientId = l.ClientId AND a.LocationId = l.LocationId AND" & _
                " a.TaxYear = l.TaxYear INNER JOIN" & _
                " Collectors AS co ON j.CollectorId = co.CollectorId AND j.TaxYear = co.TaxYear" & _
                " WHERE a.AssessmentId = " & m_AssessmentId & _
                " AND a.ClientId = " & m_ClientId & _
                " AND a.LocationId = " & m_LocationId & _
                " AND co.CollectorId = " & m_CollectorId & _
                " AND a.TaxYear = " & m_TaxYear

            GetData(sSQL, dt)
            dr = dt.Rows(0)

            Me.Text = IIf(m_PropType = enumTable.enumLocationBPP, "BPP", "Real Estate") & " Payments:  " & _
                Trim(dr("Clients_Name")) & "   " & Trim(dr("Address")) & "   " & _
                Trim(dr("City")) & " " & Trim(dr("StateCd")) & _
                "   " & Trim(dr("Collectors_Name")) & _
                "   " & Trim(dr("AcctNum"))

            LoadInstallments()

            Return True
        Catch ex As Exception
            MsgBox("Error in RefreshData:  " & ex.Message)
            Return False
        End Try
    End Function

    Private Sub frmInstallments_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Dim Buttons(0) As Control

        Buttons(0) = cmdNewInstallment
        PlaceButtons(Me, Buttons)

        If Me.WindowState = FormWindowState.Minimized Then Exit Sub
        dgInstallments.Height = Me.Height - 80
    End Sub

    Private Function LoadInstallments() As Boolean
        Dim bind As New BindingSource, sSQL As String, dtList As New DataTable

        Try

            sSQL = "SELECT PayFromDt, PayToDt, DueDate, PayAmt, PaidFl, PaidDt, InstallId" & _
                " FROM Installments" & sPropType & _
                " WHERE AssessmentId = " & m_AssessmentId & _
                " AND ClientId = " & m_ClientId & _
                " AND LocationId = " & m_LocationId & _
                " AND TaxYear = " & m_TaxYear & _
                " AND CollectorId = " & m_CollectorId
            GetData(sSQL, dtList)
            dgInstallments.Columns.Clear()
            bind.DataSource = dtList
            dgInstallments.DataSource = bind

            For Each column As DataGridViewColumn In dgInstallments.Columns
                If column.Name = "PayFromDt" Or column.Name = "PayToDt" Or _
                        column.Name = "PayAmt" Or column.Name = "PaidFl" Or _
                        column.Name = "PaidDt" Or column.Name = "DueDate" Or column.Name = "DueDateDropDown" Then
                    column.Visible = True
                Else
                    column.Visible = False
                End If

                If column.Name = "PayFromDt" Then column.HeaderText = "Pay From Date"
                If column.Name = "PayToDt" Then column.HeaderText = "Pay To Date"
                If column.Name = "PayAmt" Then column.HeaderText = "Amount"
                If column.Name = "PaidFl" Then column.HeaderText = "Paid"
                If column.Name = "PaidDt" Then column.HeaderText = "Paid Date"
                If column.Name = "DueDate" Then column.HeaderText = "Due Date"
                If column.Name = "DueDateDropDown" Then column.HeaderText = "Due Date"

                Select Case column.Name
                    Case "PayFromDt", "PayToDt", "PayAmt", "PaidFl", "PaidDt", "DueDate", "DueDateDropDown"
                        column.ReadOnly = False
                    Case Else
                        column.ReadOnly = True
                End Select

                Select Case column.Name
                    Case "PayFromDt", "PayToDt", "PaidDt", "DueDate", "DueDateDropDown"
                        If column.Name = "PaidDt" Then
                            column.DefaultCellStyle.Format = csDateTime
                        Else
                            column.DefaultCellStyle.Format = csDate
                        End If
                        If column.Name = "PaidDt" Then column.Width = 125 Else column.Width = 105
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Case "PayAmt"
                        column.DefaultCellStyle.Format = csDol
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        column.Width = 100
                    Case "PaidFl"
                        column.Width = 50
                End Select
            Next

            'Dim dtCollector As DataTable
            'Dim sDate1 As String = "", sDate2 As String = "", sDate3 As String = "", sDate4 As String = ""
            'sSQL = "SELECT DueDate,DueDate2,DueDate3,DueDate4 FROM Collectors WHERE CollectorId = " & m_CollectorId & _
            '    " AND TaxYear = " & m_TaxYear
            'GetData(sSQL, dtCollector)
            'Dim row As DataRow = dtCollector.Rows(0)
            'If Not IsDBNull(row("DueDate")) Then
            '    sDate1 = Format(row("DueDate"), csDate)
            'End If
            'If Not IsDBNull(row("DueDate2")) Then
            '    sDate2 = Format(row("DueDate2"), csDate)
            'End If
            'If Not IsDBNull(row("DueDate3")) Then
            '    sDate3 = Format(row("DueDate3"), csDate)
            'End If
            'If Not IsDBNull(row("DueDate4")) Then
            '    sDate4 = Format(row("DueDate4"), csDate)
            'End If

            'If sDate1 <> "" Or sDate2 <> "" Or sDate3 <> "" Or sDate4 <> "" Then
            '    Dim ddcolumn As New DataGridViewComboBoxColumn
            '    With ddcolumn
            '        .Name = "DueDateDropDown"
            '        .HeaderText = "Due Date"
            '        .DropDownWidth = 100
            '        .Width = 100
            '        .MaxDropDownItems = 8
            '        .FlatStyle = FlatStyle.Flat
            '        .Items.AddRange(sDate1, sDate2, sDate3, sDate4)
            '    End With
            '    dgInstallments.Columns.Add(ddcolumn)
            '    dgInstallments.Columns("DueDate").Visible = False
            '    dgInstallments.Columns("DueDateDropDown").DisplayIndex = 3
            '    For Each gridrow As DataGridViewRow In dgInstallments.Rows
            '        gridrow.Cells("DueDateDropDown").t = gridrow.Cells("DueDate").Value
            '
            '    Next
            'End If



            Return True
        Catch ex As Exception
            MsgBox("Error loading payments:  " & ex.Message)
            Return False
        End Try

    End Function

    Private Sub mnuContextDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuContextDelete.Click
        Try
            If iMouseClickColIndex >= 0 Then
                If dgInstallments.SelectedRows.Count > 0 Then
                    If MsgBox("Are you sure you want to delete?", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then Exit Sub
                    Dim sSQL As String = ""
                    Dim row As DataGridViewRow
                    For Each row In dgInstallments.SelectedRows
                        sSQL = "DELETE Installments" & sPropType & " WHERE InstallId = " & row.Cells("InstallId").Value
                        ExecuteSQL(sSQL)
                    Next
                    RefreshData()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error deleting:  " & ex.Message)
        End Try

    End Sub

    Private Sub dgInstallments_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgInstallments.CellEndEdit
        Try
            Dim sError As String = "", sField As String = ""
            sField = dgInstallments.Columns(e.ColumnIndex).Name
            If sField = "DueDateDropDown" Then sField = "DueDate"

            If Not UpdateInstallments(m_PropType, dgInstallments.Rows(e.RowIndex).Cells("InstallId").Value, sField, _
                    Trim(UnNullToString(dgInstallments.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)), sError) Then
                MsgBox(sError)
            End If
            dgInstallments.Rows(e.RowIndex).ErrorText = String.Empty
            If sError = "" Then
                If dgInstallments.Columns(e.ColumnIndex).Name = "PaidFl" Then
                    If dgInstallments.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = True Then
                        dgInstallments.Rows(e.RowIndex).Cells("PaidDt").Value = Format(Now, csDateTime)
                    Else
                        dgInstallments.Rows(e.RowIndex).Cells("PaidDt").Value = DBNull.Value
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub dgInstallments_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgInstallments.CellMouseDown
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

    Private Sub cmdNewInstallment_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdNewInstallment.Click
        Dim sFromDate As String = Trim(InputBox("Pay from date"))
        If IsDate(sFromDate) = False Then Exit Sub
        Dim sToDate As String = Trim(InputBox("Pay to date", , sFromDate))
        If IsDate(sToDate) = False Then Exit Sub
        Dim dPayAmt = Val(Trim(InputBox("Payment amount")))
        Dim sError As String = ""

        If AddInstallment(m_PropType, m_ClientId, m_LocationId, m_AssessmentId, m_CollectorId, m_TaxYear, sFromDate, sToDate, dPayAmt, sError) Then
            RefreshData()
        Else
            MsgBox(sError)
        End If
    End Sub

End Class