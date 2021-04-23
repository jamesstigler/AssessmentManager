Public Class frmProspectLocation
    Private bActivated As Boolean
    Private m_ClientId As Long
    Private m_LocationId As Long
    Private DBUpdate() As typeDBUpdateInfo
    Private bChanged As Boolean
    Dim iMouseClickColIndex As Integer

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

    Private Sub InitInfo()
        Dim DBPrimaryKeys(0) As typeDBUpdateInfo, l As Long

        DBPrimaryKeys(0).sTable = "ProspectLocations"
        ReDim DBPrimaryKeys(0).PrimaryKeys(1)
        DBPrimaryKeys(0).PrimaryKeys(0).sField = "ClientId"
        DBPrimaryKeys(0).PrimaryKeys(1).sField = "LocationId"

        InitControls(Me, DBUpdate, DBPrimaryKeys)
        For l = 0 To UBound(DBUpdate)
            DBUpdate(l).PrimaryKeys(0).vValue = m_ClientId
            DBUpdate(l).PrimaryKeys(1).vValue = m_LocationId
        Next

        cboPropType.Items.Add("R")
        cboPropType.Items.Add("P")
    End Sub


    Private Sub frmClient_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If bActivated Then Exit Sub

        InitInfo()
        OpenLocation()



        bActivated = True
    End Sub



    Private Function OpenLocation() As Boolean
        Dim sError As String = "", dt As New DataTable, sSQL As String = "", dr As DataRow, i As Integer = 0


        Try
            sSQL = "SELECT c.Name AS Clients_Name, (SELECT a.Name FROM Assessors a" & _
                " WHERE a.AssessorId = l.AssessorId AND a.TaxYear = " & AppData.TaxYear & ") AS Assessors_Name," & _
                " l.* FROM Clients c, ProspectLocations l" & _
                " WHERE c.ClientId = l.ClientId" & _
                " AND l.ClientId = " & m_ClientId & " AND l.LocationId = " & m_LocationId
            GetData(sSQL, dt)
            dr = dt.Rows(0)
            Me.Text = "Prospect Location:  " & Trim(dr("Clients_Name")) & "   " & Trim(UnNullToString(dr("Address"))) & "   " & _
                Trim(UnNullToString(dr("City"))) & " " & Trim(UnNullToString(dr("StateCd"))) & " " & Trim(UnNullToString(dr("AcctNum")))


            RefreshControls(Me, dt, "ProspectLocations")
            Loadvalues()
            Return True

        Catch ex As Exception
            MsgBox("Error in OpenLocation:  " & ex.Message)
            Return False
        End Try
    End Function

    Private Sub txtAcctNum_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAcctNum.KeyDown
        'trying to figure out Ctrl-V to paste
        'If e.KeyData = Keys.ControlKey AndAlso Keys.V Then
        '    sender.paste()
        'Else
        '    Debug.Print(e.KeyData)
        '    '            sender.paste()
        'End If
    End Sub

    Private Sub txtName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAcctNum.LostFocus, txtAddress.LostFocus, _
            txtCity.LostFocus, txtZip.LostFocus, cboStateCd.LostFocus, cboPropType.LostFocus, _
            TextBox1.LostFocus, TextBox2.LostFocus, TextBox3.LostFocus, TextBox4.LostFocus
        If bChanged Then

            If TypeOf sender Is ComboBox Then
                'If sender.name = cboLeadStatus.Name Then
                '    If sender.SelectedIndex >= 0 Then
                '        UpdateDB(sender, DBUpdate, colLeadStatus)
                '    End If
                'Else
                If sender.SelectedIndex >= 0 Then
                    UpdateDB(sender, DBUpdate)
                End If
                'End If
            Else
                UpdateDB(sender, DBUpdate)
            End If
            bChanged = False
        End If
    End Sub


    Private Sub txtAddress_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAddress.GotFocus, txtCity.GotFocus, _
            txtZip.GotFocus, cboPropType.GotFocus, txtAcctNum.GotFocus, cboStateCd.GotFocus, _
            TextBox1.GotFocus, TextBox2.GotFocus, TextBox3.GotFocus, TextBox4.GotFocus
        sender.selectall()

    End Sub


    Private Sub txtName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
            txtAddress.TextChanged, txtCity.TextChanged, _
            txtZip.TextChanged, cboStateCd.TextChanged, _
            txtAcctNum.TextChanged, cboPropType.TextChanged, _
            TextBox1.TextChanged, TextBox2.TextChanged, TextBox3.TextChanged, TextBox4.TextChanged
        If bActivated Then bChanged = True
    End Sub

    Private Function LoadValues() As Boolean
        Dim sError As String = "", lRows As Long = 0, sSQL As String = ""
        Dim dtList As New DataTable, bind As New BindingSource

        Try
            sSQL = "SELECT TaxYear, MarketValue FROM ProspectValues" & _
                " WHERE ClientId = " & m_ClientId & " AND LocationId = " & m_LocationId & " ORDER BY TaxYear DESC"
            lRows = GetData(sSQL, dtList)

            dgValues.Columns.Clear()
            bind.DataSource = dtList
            dgValues.DataSource = bind

            For Each column As DataGridViewColumn In dgValues.Columns
                If IsIndexField(column.Name) Then column.Visible = False
                If column.Name = "TaxYear" Then
                    column.HeaderText = "Tax Year"
                    column.DefaultCellStyle.Format = "0000"
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End If
                If column.Name = "MarketValue" Then
                    column.HeaderText = "Market Value"
                    column.DefaultCellStyle.Format = csDol
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End If
            Next

            Return True
        Catch ex As Exception
            MsgBox("Error in LoadValues:  " & ex.Message)
            Return False
        End Try
    End Function

    Private Sub dg_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgValues.CellEndEdit
        Dim sError As String = ""

        If Not UpdateValue(dgValues.Rows(e.RowIndex).Cells("TaxYear").Value, UnNullToDouble(dgValues.Rows(e.RowIndex).Cells("MarketValue").Value), sError) Then
            MsgBox(sError)
        End If
        dgValues.Rows(e.RowIndex).ErrorText = String.Empty

    End Sub
    Private Function UpdateValue(ByVal iYear As Integer, ByVal dValue As Double, ByRef sError As String) As Boolean
        Try
            sError = ""
            Dim sSQL As String = ""
            sSQL = "UPDATE ProspectValues SET MarketValue = " & dValue & "," & _
                " ChangeType = 2, ChangeUser = " & QuoStr(AppData.UserId) & ", ChangeDate = GETDATE()" & _
                " WHERE ClientId = " & m_ClientId & " AND LocationId = " & m_LocationId & _
                " AND TaxYear = " & iYear & " IF @@rowcount = 0 BEGIN" & _
                " INSERT ProspectValues (ClientId, LocationId, TaxYear, MarketValue, AddUser)" & _
                " SELECT " & m_ClientId & "," & m_LocationId & "," & _
                iYear & "," & dValue & "," & QuoStr(AppData.UserId) & " END"
            If ExecuteSQL(sSQL) <> 1 Then
                sError = "Error saving value"
                Return False
            End If

            Return True
        Catch ex As Exception
            sError = "Error saving value:  " & ex.Message
            Return False
        End Try
    End Function

    Private Sub dg_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgValues.CellMouseDown
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


    Private Sub mnuContextDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuContextDelete.Click
        Try
            If iMouseClickColIndex >= 0 Then
                If dgValues.SelectedRows.Count > 0 Then
                    If MsgBox("Are you sure you want to delete?", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then Exit Sub
                    Dim sSQL As String = ""
                    Dim row As DataGridViewRow
                    For Each row In dgValues.SelectedRows
                        sSQL = "DELETE ProspectValues WHERE TaxYear = " & row.Cells("TaxYear").Value & _
                            " AND ClientId = " & m_ClientId & " AND LocationId = " & m_LocationId
                        If sSQL <> "" Then ExecuteSQL(sSQL)
                        LoadValues()
                    Next
                End If
            End If
        Catch ex As Exception
            MsgBox("Error deleting:  " & ex.Message)
        End Try

    End Sub


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub cmdNewComment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNewValue.Click
        Dim iYear As Integer = Val(InputBox("Enter year"))
        If iYear = 0 Then Exit Sub
        Dim dValue As Double = Val(InputBox("Enter value"))

        Dim sError As String = ""
        If UpdateValue(iYear, dValue, sError) Then
            LoadValues()
        Else
            MsgBox(sError)
        End If
    End Sub

End Class