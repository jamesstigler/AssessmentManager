Public Class frmQueryProperties
    Private m_QueryId As Long
    Private m_QueryType As UserQueryType
    Private bActivated As Boolean
    Private DBUpdate() As typeDBUpdateInfo
    Private bChanged As Boolean


    Public Property QueryId() As Long
        Get
            Return m_QueryId
        End Get
        Set(ByVal value As Long)
            m_QueryId = value
        End Set
    End Property
    Public Property QueryType() As Integer
        Get
            Return m_QueryType
        End Get
        Set(ByVal value As Integer)
            m_QueryType = value
        End Set
    End Property

    Private Sub frmQueryProperties_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If bActivated Then Exit Sub

        InitInfo()
        RefreshData()

        bActivated = True
    End Sub
    Private Sub InitInfo()
        Dim DBPrimaryKeys(0) As typeDBUpdateInfo, l As Long
        Dim sFields As New List(Of String)

        DBPrimaryKeys(0).sTable = "UserQuery"
        DBPrimaryKeys(0).bAllowInsert = False
        ReDim DBPrimaryKeys(0).PrimaryKeys(0)
        DBPrimaryKeys(0).PrimaryKeys(0).sField = "QueryId"


        InitControls(Me, DBUpdate, DBPrimaryKeys)
        For l = 0 To UBound(DBUpdate)
            DBUpdate(l).PrimaryKeys(0).vValue = m_QueryId
        Next
        treeFields.Nodes.Clear()
        Dim sTable As String = ""
        For l = 0 To UBound(udtFieldInfo)
            If udtFieldInfo(l).bQueryVisibleFl = True Then
                If ContainsQueryType(m_QueryType, udtFieldInfo(l).lQueryType) Then
                    'ddField.AddItem(udtFieldInfo(l).sField)
                    If sTable <> udtFieldInfo(l).sTable Then
                        'ddTable.AddItem(udtFieldInfo(l).sTable)
                        sTable = udtFieldInfo(l).sTable
                        treeFields.Nodes.Add(sTable, sTable)
                    End If
                    treeFields.Nodes(sTable).Nodes.Add(sTable & "." & udtFieldInfo(l).sField, _
                        udtFieldInfo(l).sField & IIf(udtFieldInfo(l).sFieldDescription = "", "", " (" & udtFieldInfo(l).sFieldDescription & ")"))
                    sFields.Add(udtFieldInfo(l).sTable & "." & udtFieldInfo(l).sField)
                End If
            End If
        Next

        dgFilter.Columns.Clear()
        Dim colCondition As New DataGridViewComboBoxColumn
        colCondition.HeaderText = "Condition"
        colCondition.Resizable = DataGridViewTriState.True
        colCondition.Items.AddRange(New Object() {"", "AND", "OR"})
        colCondition.Name = "colCondition"
        colCondition.Width = 60

        Dim colOpenParen As New DataGridViewTextBoxColumn
        colOpenParen.HeaderText = "("
        colOpenParen.Name = "colOpenParen"
        colOpenParen.Resizable = DataGridViewTriState.True
        colOpenParen.Width = 30

        Dim colField As New DataGridViewComboBoxColumn
        colField.HeaderText = "Field"
        colField.Resizable = DataGridViewTriState.True
        colField.Name = "colField"
        colField.Width = 300
        For Each s As String In sFields
            colField.Items.Add(s)
        Next

        Dim colOperator As New DataGridViewComboBoxColumn
        colOperator.HeaderText = "Operator"
        colOperator.Items.AddRange(New Object() {"", "=", "<>", ">", "<", ">=", "<="})
        colOperator.Name = "colOperator"
        colOperator.Resizable = DataGridViewTriState.True
        colOperator.Width = 60

        Dim colValue As New DataGridViewTextBoxColumn
        colValue.HeaderText = "Value"
        colValue.Name = "colValue"
        colValue.Resizable = DataGridViewTriState.True
        colValue.Width = 220

        Dim colClosedParen As New DataGridViewTextBoxColumn
        colClosedParen.HeaderText = ")"
        colClosedParen.Name = "colClosedParen"
        colClosedParen.Resizable = DataGridViewTriState.True
        colClosedParen.Width = 30

        Dim colValueType As New DataGridViewComboBoxColumn
        colValueType.HeaderText = "Value Type"
        colValueType.Items.AddRange(New Object() {"Ask", "User Value"})
        colValueType.Name = "colValueType"
        colValueType.Resizable = DataGridViewTriState.True
        colValueType.Width = 100

        dgFilter.Columns.AddRange(New DataGridViewColumn() {colCondition, colOpenParen, colField, colOperator, colValue, colClosedParen, colValueType})

        dgSort.Columns.Clear()
        Dim colSortField As New DataGridViewComboBoxColumn
        colSortField.HeaderText = "Field"
        colSortField.Resizable = DataGridViewTriState.True
        colSortField.Name = "colField"
        colSortField.Width = dgSort.Width - 70 - 60
        For Each s As String In sFields
            colSortField.Items.Add(s)
        Next
        Dim colSortDirection As New DataGridViewComboBoxColumn
        colSortDirection.HeaderText = "Direction"
        colSortDirection.Resizable = DataGridViewTriState.True
        colSortDirection.Name = "colDirection"
        colSortDirection.Width = 70
        colSortDirection.Items.Add("ASC")
        colSortDirection.Items.Add("DESC")

        dgSort.Columns.AddRange(New DataGridViewColumn() {colSortField, colSortDirection})

        If m_QueryType = UserQueryType.Client Or m_QueryType = UserQueryType.ProspectLocations Or m_QueryType = UserQueryType.Prospects Or m_QueryType = UserQueryType.ProspectValues Then
            chkAllYears.Visible = False
        End If


    End Sub
    Private Function RefreshData() As Boolean
        Dim sError As String = "", dt As New DataTable, sSQL As String = "", dr As DataRow, i As Integer = 0
        Dim gridRow() As String, sOrderBy() As String

        Try
            txtQueryName.Text = "" : txtDescription.Text = "" : dgFields.Rows.Clear() : dgFilter.Rows.Clear() : dgSort.Rows.Clear()
            sSQL = "SELECT QueryType, QueryName, Description, ISNULL(OrderBy,'') AS OrderBy, QuerySQL, ISNULL(CurrentConsultantFl,0) AS CurrentConsultantFl," &
                " ISNULL(AllTaxYearsFl,0) AS AllTaxYearsFl FROM UserQuery WHERE QueryId = " & m_QueryId
            GetData(sSQL, dt)
            dr = dt.Rows(0)
            Me.Text = "UserQuery:  " & Trim(dr("QueryName"))
            RefreshControls(Me, dt, "UserQuery")
            If dr("OrderBy") <> "" Then
                ReDim gridRow(1)
                sOrderBy = Split(dr("OrderBy"), ",")
                For i = 0 To UBound(sOrderBy)
                    gridRow = Split(sOrderBy(i), " ")
                    dgSort.Rows.Add(gridRow)
                Next
            End If

            ReDim gridRow(0)
            sSQL = "SELECT QueryTable + '.' + QueryField AS Fields FROM UserQuerySelect WHERE QueryId = " & m_QueryId & " ORDER BY QuerySeqNo"
            GetData(sSQL, dt)
            For Each dr In dt.Rows
                gridRow(0) = dr(0).ToString
                dgFields.Rows.Add(gridRow)
            Next

            ReDim gridRow(6)
            sSQL = "SELECT ISNULL(QueryCondition,'') AS QueryCondition, ISNULL(QueryOpenParen,'') AS QueryOpenParen, ISNULL(QueryField,'') AS QueryField," & _
                " ISNULL(QueryOperator,'') AS QueryOperator, ISNULL(QueryFieldValue,'') AS QueryFieldValue," & _
                " ISNULL(QueryClosedParen,'') AS QueryClosedParen, ISNULL(QueryValueType,'') AS QueryValueType" & _
                " FROM UserQueryDetail WHERE QueryId = " & m_QueryId & " ORDER BY QuerySeqNo"
            GetData(sSQL, dt)
            For Each dr In dt.Rows
                For i = 0 To 6
                    If i = 6 Then
                        If dr(i).ToString = 0 Then
                            gridRow(i) = "User Value"
                        ElseIf dr(i).ToString = 1 Then
                            gridRow(i) = "Ask"
                        End If
                    Else
                        gridRow(i) = dr(i).ToString
                    End If
                Next
                dgFilter.Rows.Add(gridRow)
            Next
            dt.Dispose()

            Return True

        Catch ex As Exception
            MsgBox("Error in RefreshData:  " & ex.Message)
            Return False
        End Try
    End Function

    Private Sub txtQueryName_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQueryName.GotFocus, txtDescription.GotFocus
        sender.selectall()
    End Sub

    Private Sub txtDescription_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDescription.LostFocus,
            txtQueryName.LostFocus, chkCurrentConsultantFl.LostFocus, chkAllYears.LostFocus
        If bChanged Then
            If TypeOf sender Is ComboBox Then
                If sender.SelectedIndex >= 0 Then
                    If InStr(sender.tag, "EntityId") > 0 Then
                        'UpdateDB(sender, DBUpdate, colFactoringEntities)
                    Else
                        'UpdateDB(sender, DBUpdate, colAssessors)
                    End If
                End If
            Else
                UpdateDB(sender, DBUpdate)
            End If
            bChanged = False
        End If
    End Sub

    Private Sub txtDescription_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
            txtDescription.TextChanged, txtQueryName.TextChanged, chkCurrentConsultantFl.CheckedChanged, chkAllYears.CheckedChanged
        If bActivated Then bChanged = True
    End Sub


    Private Sub treeFields_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles treeFields.DoubleClick

        Try
            If treeFields.SelectedNode.Parent.Name <> Nothing Then
                Dim gridRow(0) As String, row As DataGridViewRow, bExists As Boolean = False
                gridRow(0) = treeFields.SelectedNode.Name
                For Each row In dgFields.Rows
                    If row.Cells(0).Value = gridRow(0) Then bExists = True
                Next
                If bExists = False Then
                    dgFields.Rows.Add(gridRow)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Dim msgReturn As MsgBoxResult = MsgBoxResult.No
        If bChanged Then
            msgReturn = MsgBox("Save changes?", MsgBoxStyle.YesNoCancel)
            If msgReturn = MsgBoxResult.Yes Then
                SaveChanges()
            End If
        End If
        If msgReturn <> MsgBoxResult.Cancel Then
            bChanged = False
            Me.Close()
        End If
    End Sub
    Private Sub frmQueryProperties_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If bChanged Then
            If MsgBox("Save changes?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then SaveChanges()
        End If
    End Sub
    Private Sub SaveChanges()
        Dim sSQL As String = ""

        Try
            Dim row As DataGridViewRow, iSeqNo As Integer = 0, sTable As String = "", sField As String = ""
            Dim sOrderBy As String = "", listFields As New List(Of String)

            sSQL = "DELETE UserQuerySelect WHERE QueryId = " & m_QueryId
            ExecuteSQL(sSQL)
            sSQL = "DELETE UserQueryDetail WHERE QueryId = " & m_QueryId
            ExecuteSQL(sSQL)
            For Each row In dgFields.Rows
                listFields.Add(row.Cells(0).Value)
                sTable = Trim(Microsoft.VisualBasic.Left(row.Cells(0).Value, InStr(row.Cells(0).Value, ".", CompareMethod.Text) - 1))
                sField = Trim(Microsoft.VisualBasic.Right(row.Cells(0).Value, Len(row.Cells(0).Value) - Len(sTable) - 1))
                If sTable <> "" And sField <> "" Then
                    sSQL = "INSERT UserQuerySelect (QueryId, QuerySeqNo, QueryTable, QueryField, AddUser)" & _
                        " SELECT " & m_QueryId & "," & iSeqNo & "," & QuoStr(sTable) & "," & QuoStr(sField) & "," & QuoStr(AppData.UserId)
                    ExecuteSQL(sSQL)
                    iSeqNo = iSeqNo + 1
                End If
            Next

            sOrderBy = ""
            For Each row In dgSort.Rows
                If row.Cells(0).Value <> Nothing Then
                    If listFields.Contains(row.Cells(0).Value.ToString()) Then
                        If sOrderBy <> "" Then sOrderBy = sOrderBy & ","
                        sOrderBy = sOrderBy & row.Cells(0).Value & " " & row.Cells(1).Value
                    End If
                End If
            Next
            sSQL = "UPDATE UserQuery SET OrderBy = " & QuoStr(sOrderBy) & " WHERE QueryId = " & m_QueryId
            ExecuteSQL(sSQL)

            iSeqNo = 0
            For Each row In dgFilter.Rows
                If Trim(row.Cells("colField").Value) <> "" And Trim(row.Cells("colValueType").Value) <> "" Then
                    sSQL = "INSERT UserQueryDetail (QueryId,QuerySeqNo,QueryOpenParen,QueryCondition,QueryField," & _
                        " QueryOperator,QueryFieldValue,QueryValueType,QueryClosedParen,AddUser)"
                    sSQL = sSQL & " SELECT " & m_QueryId & "," & iSeqNo & "," & QuoStr(row.Cells("colOpenParen").Value) & "," & _
                        QuoStr(row.Cells("colCondition").Value) & "," & _
                        QuoStr(row.Cells("colField").Value) & "," & _
                        QuoStr(row.Cells("colOperator").Value) & "," & _
                        QuoStr(row.Cells("colValue").Value) & ","
                    If row.Cells("colValueType").Value = "Ask" Then
                        sSQL = sSQL & "1,"
                    ElseIf row.Cells("colValueType").Value = "User Value" Then
                        sSQL = sSQL & "0,"
                    End If
                    sSQL = sSQL & QuoStr(row.Cells("colClosedParen").Value) & "," & QuoStr(AppData.UserId)

                    ExecuteSQL(sSQL)
                    iSeqNo = iSeqNo + 1
                End If
            Next

            bChanged = False

        Catch ex As Exception
            MsgBox("Error saving changes:  " & ex.Message)
        End Try
    End Sub

    Private Sub dgFields_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgFields.CellValueChanged, dgFilter.CellValueChanged, dgSort.CellValueChanged
        If bActivated Then bChanged = True
    End Sub

    Private Sub dgFields_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgFields.RowsAdded, dgFilter.RowsAdded, dgSort.RowsAdded
        If bActivated Then
            If sender.name = "dgFilter" Then
                Try
                    dgFilter.Rows(e.RowIndex - 1).Cells("colValueType").Value = "User Value"
                Catch
                End Try
            End If
            bChanged = True
        End If
    End Sub

    Private Sub dgFields_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgFields.RowsRemoved, dgFilter.RowsRemoved, dgSort.RowsRemoved
        If bActivated Then bChanged = True
    End Sub

    Private Sub cmdOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        If bChanged Then SaveChanges()
        Me.Close()
    End Sub

    Private Sub dgFilter_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgFilter.CellValueChanged
        If bActivated Then bChanged = True
    End Sub

    Private Sub frmQueryProperties_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'Try
        '    If Me.WindowState = FormWindowState.Minimized Then Exit Sub
        '    Dim mesize As Size = Me.Size
        '    cmdOK.Left = mesize.Width / 2 - cmdOK.Width - 5
        '    cmdClose.Left = cmdOK.Left + cmdOK.Width + 5
        '    cmdOK.Top = mesize.Height - cmdOK.Height - 40
        '    cmdClose.Top = cmdOK.Top
        '    TabControl1.Width = mesize.Width - 10
        '    TabControl1.Height = mesize.Height - 125
        '    cmdUp.Left = dgFields.Left - cmdUp.Width - 5
        '    cmdDown.Left = cmdUp.Left
        'Catch ex As Exception
        'End Try
    End Sub



    Private Sub cmdDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDown.Click
        Try
            If dgFields.Rows.Count > 0 Then
                If dgFields.SelectedRows.Count > 0 Then
                    If dgFields.SelectedRows(0).Index < (dgFields.Rows.Count - 1) Then
                        Dim row As DataGridViewRow, iIdxFrom As Integer = 0, sFieldFrom As String = "", sFieldTo As String = ""
                        Dim iIdxTo As Integer = 0
                        row = dgFields.SelectedRows(0)
                        sFieldFrom = row.Cells(0).Value
                        iIdxFrom = row.Index
                        iIdxTo = row.Index + 1
                        row = dgFields.Rows(iIdxTo)
                        sFieldTo = row.Cells(0).Value
                        row = dgFields.Rows(iIdxFrom)
                        row.Cells(0).Value = sFieldTo
                        row = dgFields.Rows(iIdxTo)
                        row.Cells(0).Value = sFieldFrom
                        dgFields.ClearSelection()
                        row.Selected = True
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUp.Click
        Try
            If dgFields.Rows.Count > 0 Then
                If dgFields.SelectedRows.Count > 0 Then
                    If dgFields.SelectedRows(0).Index > 0 Then
                        Dim row As DataGridViewRow, iIdxFrom As Integer = 0, sFieldFrom As String = "", sFieldTo As String = ""
                        Dim iIdxTo As Integer = 0
                        row = dgFields.SelectedRows(0)
                        sFieldFrom = row.Cells(0).Value
                        iIdxFrom = row.Index
                        iIdxTo = row.Index - 1
                        row = dgFields.Rows(iIdxTo)
                        sFieldTo = row.Cells(0).Value
                        row = dgFields.Rows(iIdxFrom)
                        row.Cells(0).Value = sFieldTo
                        row = dgFields.Rows(iIdxTo)
                        row.Cells(0).Value = sFieldFrom
                        dgFields.ClearSelection()
                        row.Selected = True
                    End If
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    
    Private Sub dgFields_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgFields.SizeChanged
        Try
            cmdUp.Left = dgFields.Left - cmdUp.Width - 5
            cmdDown.Left = cmdUp.Left
        Catch ex As Exception
        End Try
    End Sub
End Class