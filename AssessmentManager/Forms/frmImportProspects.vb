Public Class frmImportProspects
    Private bActivated As Boolean
    Private m_AssessorId As Long
    Private m_AssessorName As String
    Private m_AssessorStateCd As String

    Private Const COL_COUNTER As Integer = 0
    Private Const COL_IMPORTFROM As Integer = 1
    Private Const COL_ASSIGNTO As Integer = 2
    Private Const COL_SORT As Integer = 3
    Private Const COL_ASSIGNSORTED As Integer = 4
    Private listImportColumns As New List(Of String)



    Public Property AssessorId() As Long
        Get
            Return m_AssessorId
        End Get
        Set(ByVal value As Long)
            m_AssessorId = value
        End Set
    End Property
    Public Property AssessorName() As String
        Get
            Return m_AssessorName
        End Get
        Set(ByVal value As String)
            m_AssessorName = value
        End Set
    End Property
    Public Property AssessorStateCd() As String
        Get
            Return m_AssessorStateCd
        End Get
        Set(ByVal value As String)
            m_AssessorStateCd = value
        End Set
    End Property





    Private Sub frmImportProspects_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If bActivated Then Exit Sub
        RefreshData()


        bActivated = True
        ImportFile()
    End Sub
    Private Function RefreshData() As Boolean


        Try
            Me.Text = "Importing prospects for " & m_AssessorName

            listImportColumns.Add("Account Number")
            listImportColumns.Add("Property Type")
            listImportColumns.Add("Location Address")
            listImportColumns.Add("Location City")
            listImportColumns.Add("Location State Code")
            listImportColumns.Add("Location Zip")
            listImportColumns.Add("Account Notes")
            listImportColumns.Add("Account SIC")
            listImportColumns.Add("Business Description")
            listImportColumns.Add("Rendition Filing Status")
            listImportColumns.Add("Owner DBA")
            listImportColumns.Add("Owner Name")
            listImportColumns.Add("Contact Name")
            listImportColumns.Add("Lead Status")
            listImportColumns.Add("Owner Phone")
            listImportColumns.Add("Owner Address")
            listImportColumns.Add("Owner City")
            listImportColumns.Add("Owner State Code")
            listImportColumns.Add("Owner Zip")
            listImportColumns.Add("Competing Tax Consultant")
            listImportColumns.Add("Current Year Value")
            listImportColumns.Add("Prior Year Value")
            listImportColumns.Add("Consultant Name")


            Return True
        Catch ex As Exception
            MsgBox("Error in RefreshData:  " & ex.Message)
            Return False
        End Try
    End Function

    Private Function ImportFile() As Boolean
        Dim vFileContents As New Object, lColumn As Long = 0, lRow As Long = 0, sRowContents() As String
        Dim iNumberOfColumns As Integer
        Dim sColumns() As String

        Try
            dgColumns.Columns.Clear()
            dgImport.Columns.Clear()

            If Not modMain.ImportFile(vFileContents) Then Return False

            ReDim sRowContents(UBound(vFileContents, 1))
            iNumberOfColumns = UBound(vFileContents, 1) + 1
            ReDim sColumns(4)       'column number/column header/assigned field/sorted assigned field
            dgColumns.Columns.Add(COL_COUNTER, COL_COUNTER)
            dgColumns.Columns.Add(COL_IMPORTFROM, "Import From")

            Dim assignedToColumn As New DataGridViewComboBoxColumn()
            ' Populate the combo box drop-down list with available database fields
            For Each sAddItem As String In listImportColumns
                assignedToColumn.Items.Add(sAddItem)
            Next
            assignedToColumn.Items.Add("")
            assignedToColumn.Name = COL_ASSIGNTO
            assignedToColumn.HeaderText = "Assigned To"
            assignedToColumn.DataPropertyName = "AssignedTo"
            assignedToColumn.AutoComplete = True
            assignedToColumn.DisplayMember = "Name"
            assignedToColumn.ValueMember = "Name"
            assignedToColumn.MaxDropDownItems = assignedToColumn.Items.Count
            dgColumns.Columns.Add(assignedToColumn)

            Dim orderbyColumn As New DataGridViewComboBoxColumn()
            With orderbyColumn
                .Items.Add("")
                For lRow = 1 To 9
                    .Items.Add(CStr(lRow))
                Next
                .Name = COL_SORT
                .HeaderText = "Order By"
                .DataPropertyName = "OrderBy"
                .AutoComplete = True
                .DisplayMember = "Name"
                .ValueMember = "Name"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            dgColumns.Columns.Add(orderbyColumn)
            dgColumns.Columns.Add(COL_ASSIGNSORTED, COL_ASSIGNSORTED)
            dgColumns.Columns(COL_ASSIGNSORTED).Visible = False
            dgColumns.Columns(COL_COUNTER).Visible = False



            'populate dgcolumns with list of columns in file, column name being the first row of imported data
            For lRow = 0 To UBound(sRowContents)
                vFileContents(lRow, 0) = UCase(Trim(vFileContents(lRow, 0)))
                sColumns(COL_COUNTER) = Format(lRow, "0000")                          'column number
                sColumns(COL_IMPORTFROM) = vFileContents(lRow, 0)       'column header is 1st row of data
                sColumns(COL_ASSIGNTO) = ""
                sColumns(COL_SORT) = ""
                sColumns(COL_ASSIGNSORTED) = ""
                dgColumns.Rows.Add(sColumns)
            Next


            'assume 1st row are headers
            For lColumn = 0 To UBound(vFileContents, 1)
                dgImport.Columns.Add(vFileContents(lColumn, 0), vFileContents(lColumn, 0))
            Next
            For lRow = 1 To UBound(vFileContents, 2)
                For lColumn = 0 To UBound(vFileContents, 1)
                    sRowContents(lColumn) = vFileContents(lColumn, lRow)
                Next
                dgImport.Rows.Add(sRowContents)
            Next

            For Each row As DataGridViewRow In dgColumns.Rows
                Select Case row.Cells(COL_IMPORTFROM).Value
                    Case "ACC_NUM"
                        row.Cells(COL_ASSIGNTO).Value = "Account Number"
                    Case "DBA"
                        row.Cells(COL_ASSIGNTO).Value = "Owner DBA"
                    Case "STREET_NUM"
                        row.Cells(COL_ASSIGNTO).Value = "Location Address"
                        row.Cells(COL_SORT).Value = "1"
                    Case "STREET_DIR"
                        row.Cells(COL_ASSIGNTO).Value = "Location Address"
                        row.Cells(COL_SORT).Value = "2"
                    Case "STREET_NAME"
                        row.Cells(COL_ASSIGNTO).Value = "Location Address"
                        row.Cells(COL_SORT).Value = "3"
                    Case "STREET_SUFFIX"
                        row.Cells(COL_ASSIGNTO).Value = "Location Address"
                        row.Cells(COL_SORT).Value = "4"
                    Case "SUITE_NUMBER"
                        row.Cells(COL_ASSIGNTO).Value = "Location Address"
                        row.Cells(COL_SORT).Value = "5"
                    Case "CITY"
                        row.Cells(COL_ASSIGNTO).Value = "Location City"
                    Case "OWNER_NAME"
                        row.Cells(COL_ASSIGNTO).Value = "Owner Name"
                    Case "PERSON_CONTACTED"
                        row.Cells(COL_ASSIGNTO).Value = "Contact Name"
                    Case "FILE STATUS"
                        row.Cells(COL_ASSIGNTO).Value = "Lead Status"
                    Case "OWNER_PHONE"
                        row.Cells(COL_ASSIGNTO).Value = "Owner Phone"
                    Case "MAIL_ADDRESS1"
                        row.Cells(COL_ASSIGNTO).Value = "Owner Address"
                        row.Cells(COL_SORT).Value = "1"
                    Case "MAIL_ADDRESS2"
                        row.Cells(COL_ASSIGNTO).Value = "Owner Address"
                        row.Cells(COL_SORT).Value = "2"
                    Case "MAIL_ADDRESS3"
                        row.Cells(COL_ASSIGNTO).Value = "Owner Address"
                        row.Cells(COL_SORT).Value = "3"
                    Case "MAIL_CITY"
                        row.Cells(COL_ASSIGNTO).Value = "Owner City"
                    Case "MAIL_STATE"
                        row.Cells(COL_ASSIGNTO).Value = "Owner State Code"
                    Case "MAIL_ZIP"
                        row.Cells(COL_ASSIGNTO).Value = "Owner Zip"
                    Case "TAX_CONSULTANT"
                        row.Cells(COL_ASSIGNTO).Value = "Competing Tax Consultant"
                    Case "TOT_VAL_CURRENT"
                        row.Cells(COL_ASSIGNTO).Value = "Current Year Value"
                    Case "TOT_VAL_PRIOR"
                        row.Cells(COL_ASSIGNTO).Value = "Prior Year Value"
                    Case "STATE"
                        row.Cells(COL_ASSIGNTO).Value = "Location State Code"
                End Select
            Next

            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Private Sub cmdNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdNext.Click
        cmdBack.Enabled = True
        grpAssign.Visible = False
        grpImport.Visible = True
        cmdNext.Enabled = False
        If ArrangeImport() Then cmdFinish.Enabled = True Else cmdFinish.Enabled = False
    End Sub

    Private Function ArrangeImport() As Boolean
        Dim sRowContents() As String, iCol As Integer = 0
        Dim bHaveAcctNum As Boolean = False, bHaveClientName As Boolean = False, bHavePropType As Boolean = False


        Try
            dgAssignedImport.Columns.Clear()
            'populate sort column
            For Each row As DataGridViewRow In dgColumns.Rows
                Select Case UnNullToString(row.Cells(COL_ASSIGNTO).Value)
                    Case "Account Number"
                        bHaveAcctNum = True
                    Case "Property Type"
                        bHavePropType = True
                    Case "Owner Name"
                        bHaveClientName = True
                End Select
                row.Cells(COL_ASSIGNSORTED).Value = _
                    UnNullToString(row.Cells(COL_ASSIGNTO).Value) & UnNullToString(row.Cells(COL_SORT).Value)
            Next
            If bHaveAcctNum = False Or bHaveClientName = False Or bHavePropType = False Then
                MsgBox("Must define owner name and account number and property type")
                Return False
            End If
            dgColumns.Sort(dgColumns.Columns(COL_ASSIGNSORTED), System.ComponentModel.ListSortDirection.Ascending)
            For Each sColumnName As String In listImportColumns
                dgAssignedImport.Columns.Add(sColumnName, sColumnName)
            Next


            For Each rowImport As DataGridViewRow In dgImport.Rows
                ReDim sRowContents(listImportColumns.Count - 1)
                iCol = 0
                For Each sColumnName As String In listImportColumns
                    sRowContents(iCol) = ""
                    For Each rowAssigned As DataGridViewRow In dgColumns.Rows
                        If sColumnName = UnNullToString(rowAssigned.Cells(COL_ASSIGNTO).Value) Then
                            sRowContents(iCol) = sRowContents(iCol) & " " & _
                                UnNullToString(rowImport.Cells(UnNullToString(rowAssigned.Cells(COL_IMPORTFROM).Value)).Value)
                        End If
                    Next
                    If sRowContents(iCol) = "" Then
                        If sColumnName = "Location State Code" Then
                            sRowContents(iCol) = m_AssessorStateCd
                        End If
                    End If
                    iCol = iCol + 1
                Next
                dgAssignedImport.Rows.Add(sRowContents)
            Next



            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Private Sub cmdBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdBack.Click
        dgColumns.Sort(dgColumns.Columns(COL_COUNTER), System.ComponentModel.ListSortDirection.Ascending)
        cmdBack.Enabled = False
        grpAssign.Visible = True
        grpImport.Visible = False
        cmdNext.Enabled = True
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdFinish_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdFinish.Click
        Me.Cursor = Cursors.WaitCursor
        If SaveImport() Then
            Me.Cursor = Cursors.Default
            MsgBox("Import Complete")
            Me.Close()
        Else
            Me.Cursor = Cursors.Default
        End If

    End Sub
    Private Function SaveImport() As Boolean
        Dim sSQL As String = "", dt As New DataTable, lClientId As Long = 0, lLocationId As Long = 0
        Dim sStateCd As String = ""
        Dim sPropType As String = ""
        Try
            For Each row As DataGridViewRow In dgAssignedImport.Rows
                sSQL = "SELECT ClientId, LocationId FROM ProspectLocations" & _
                    " WHERE AssessorId = " & m_AssessorId & _
                    " AND UPPER(AcctNum) = UPPER(" & QuoStr(UnNullToString(row.Cells("Account Number").Value)) & ")"
                If GetData(sSQL, dt) = 0 Then
                    lLocationId = CreateID(enumTable.enumProspectLocation)
                    sSQL = "SELECT ClientId FROM Clients WHERE UPPER(Name) = " & QuoStr(UnNullToString(row.Cells("Owner Name").Value))
                    If GetData(sSQL, dt) = 0 Then
                        lClientId = CreateID(enumTable.enumClient)
                        sSQL = "INSERT Clients (ClientId,Name,Address,City,StateCd,Zip,Phone,DBA,ProspectFl,LeadCompetitorName,ContactTaxName,LeadStatus,AddUser,ClientCoordinatorName)" &
                            " SELECT " & lClientId & "," & QuoStr(UnNullToString(row.Cells("Owner Name").Value), 255) & "," &
                            QuoStr(UnNullToString(row.Cells("Owner Address").Value), 255) & "," &
                            QuoStr(UnNullToString(row.Cells("Owner City").Value), 255) & ","
                        sStateCd = Trim(UnNullToString(row.Cells("Owner State Code").Value))
                        If colStateCodes.Contains(sStateCd) Then
                            sStateCd = QuoStr(sStateCd, 2)
                        Else
                            sStateCd = "NULL"
                        End If
                        sSQL = sSQL & sStateCd & ","
                        sSQL = sSQL & _
                            QuoStr(UnNullToString(row.Cells("Owner Zip").Value), 10) & "," & _
                            QuoStr(UnNullToString(row.Cells("Owner Phone").Value), 50) & "," & _
                            QuoStr(UnNullToString(row.Cells("Owner DBA").Value), 255) & ",1," & _
                            QuoStr(UnNullToString(row.Cells("Competing Tax Consultant").Value), 255) & "," & _
                            QuoStr(UnNullToString(row.Cells("Contact Name").Value), 255) & "," & _
                            QuoStr(UnNullToString(row.Cells("Lead Status").Value), 255) & "," & _
                            QuoStr(AppData.UserId) & "," & _
                            QuoStr(UnNullToString(row.Cells("Consultant Name").Value), 50)
                        ExecuteSQL(sSQL)
                    Else
                        lClientId = dt.Rows(0)("ClientId")
                    End If
                    sSQL = "INSERT ProspectLocations (ClientId,LocationId,AssessorId,AcctNum,PropType,Address,City,StateCd,Zip,AddUser,Notes,SICCode,BusDesc,RenditionFilingStatus)" & _
                        " SELECT " & lClientId & "," & lLocationId & "," & _
                        m_AssessorId & "," & _
                        QuoStr(UnNullToString(row.Cells("Account Number").Value), 50) & ","
                    If UnNullToString(row.Cells("Property Type").Value) = "P" Or UnNullToString(row.Cells("Property Type").Value) = "BPP" Then
                        sPropType = "P"
                    Else
                        sPropType = "R"
                    End If

                    sSQL = sSQL & QuoStr(sPropType) & "," & _
                        QuoStr(UnNullToString(row.Cells("Location Address").Value), 255) & "," & _
                        QuoStr(UnNullToString(row.Cells("Location City").Value), 255) & "," & _
                        QuoStr(UnNullToString(row.Cells("Location State Code").Value), 2) & "," & _
                        QuoStr(UnNullToString(row.Cells("Location Zip").Value), 10) & "," & _
                        QuoStr(AppData.UserId) & "," & _
                        QuoStr(UnNullToString(row.Cells("Account Notes").Value), 1000) & "," & _
                        QuoStr(UnNullToString(row.Cells("Account SIC").Value), 255) & "," & _
                        QuoStr(UnNullToString(row.Cells("Business Description").Value), 255) & "," & _
                        QuoStr(UnNullToString(row.Cells("Rendition Filing Status").Value), 255)
                    ExecuteSQL(sSQL)
                Else
                    lClientId = dt.Rows(0)("ClientId")
                    lLocationId = dt.Rows(0)("LocationId")
                End If
                For iYear As Integer = AppData.TaxYear - 1 To AppData.TaxYear
                    sSQL = "UPDATE ProspectValues SET MarketValue = "
                    If iYear = AppData.TaxYear Then
                        If IsNumeric(row.Cells("Current Year Value").Value) Then
                            sSQL = sSQL & UnNullToDouble(row.Cells("Current Year Value").Value)
                        Else
                            sSQL = sSQL & "0"
                        End If
                    Else
                        If IsNumeric(row.Cells("Prior Year Value").Value) Then
                            sSQL = sSQL & UnNullToDouble(row.Cells("Prior Year Value").Value)
                        Else
                            sSQL = sSQL & "0"
                        End If
                    End If
                    sSQL = sSQL & ", ChangeType = 2, ChangeDate = GETDATE(), ChangeUser = " & QuoStr(AppData.UserId) & _
                        " WHERE ClientId = " & lClientId & " AND LocationId = " & lLocationId & _
                        " AND TaxYear = " & iYear & _
                        "   IF @@rowcount = 0 BEGIN" & _
                        " INSERT ProspectValues (ClientId,LocationId,TaxYear,MarketValue,AddUser)" & _
                        " SELECT " & lClientId & "," & lLocationId & "," & iYear & ","
                    If iYear = AppData.TaxYear Then
                        If IsNumeric(row.Cells("Current Year Value").Value) Then
                            sSQL = sSQL & UnNullToDouble(row.Cells("Current Year Value").Value)
                        Else
                            sSQL = sSQL & "0"
                        End If
                    Else
                        If IsNumeric(row.Cells("Prior Year Value").Value) Then
                            sSQL = sSQL & UnNullToDouble(row.Cells("Prior Year Value").Value)
                        Else
                            sSQL = sSQL & "0"
                        End If
                    End If
                    sSQL = sSQL & "," & QuoStr(AppData.UserId) & " END"
                    ExecuteSQL(sSQL)

                Next
            Next

            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Private Sub frmImportProspects_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        grpAssign.Left = 3
        grpAssign.Top = 3
        grpImport.Left = grpAssign.Left
        grpImport.Top = grpAssign.Top
    End Sub

    
    Private Sub frmImportProspects_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Dim Buttons(3) As Control

        Buttons(0) = cmdBack
        Buttons(1) = cmdNext
        Buttons(2) = cmdFinish
        Buttons(3) = cmdCancel
        PlaceButtons(Me, Buttons)

        If Me.WindowState = FormWindowState.Minimized Then Exit Sub

        grpAssign.Width = Me.Width - 30
        grpAssign.Height = Me.Height - 80
        grpImport.Width = grpAssign.Width
        grpImport.Height = grpAssign.Height
        dgColumns.Height = grpAssign.Height - 30
        dgImport.Width = grpAssign.Width - dgColumns.Left - dgColumns.Width - 10
        dgImport.Height = dgColumns.Height


    End Sub
End Class