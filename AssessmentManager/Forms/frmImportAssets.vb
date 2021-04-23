Public Class frmImportAssets
    Private m_ClientId As Long
    Private m_LocationId As Long
    Private m_AssessmentId As Long
    Private m_TaxYear As Integer

    Private m_ClientName As String
    Private m_Address As String
    Private m_City As String
    Private m_StateCd As String
    Private m_Zip As String
    Private m_ClientLocationId As String
    Private m_AcctNum As String
    Private m_FactorEntityId1 As Long
    Private m_FactorEntityId2 As Long

    Private sStateCd As String
    Private bActivated As Boolean
    Private dtExistingAssets As DataTable
    Private iNumberOfColumns As Integer
    Private lImportAssetCount As Long
    Private lImportAssetAmount As Long
    Private Enum ErrorType
        NoError = 0
        DuplicateAsset = 1
        BadData = 2
    End Enum


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
    Private Function RefreshData() As Boolean
        Dim sSQL As String = "", dr As DataRow

        Try
            sSQL = "SELECT c.Name, l.Address, l.City, l.StateCd, l.Zip, ISNULL(assess.AcctNum,'') AS AcctNum," &
                " ISNULL(a.OriginalCost,0) AS OriginalCost, l.ClientLocationId," &
                " a.PurchaseDate, ISNULL(a.Description,'') AS Description, ISNULL(a.GLCode,'') AS GLCode," &
                " ISNULL(a.VIN,'') AS VIN, ISNULL(a.LocationAddress,'') AS LocationAddress," &
                " a.AssetId, ISNULL(assess.FactorEntityId1,0) AS FactorEntityId1, ISNULL(assess.FactorEntityId2,0) AS FactorEntityId2" &
                " FROM Clients AS c INNER JOIN" &
                " LocationsBPP AS l ON c.ClientId = l.ClientId INNER JOIN" &
                " AssessmentsBPP AS assess ON l.ClientId = assess.ClientId AND l.LocationId = assess.LocationId AND" &
                " l.TaxYear = assess.TaxYear LEFT OUTER JOIN" &
                " Assets AS a ON assess.ClientId = a.ClientId AND assess.LocationId = a.LocationId" &
                " AND assess.AssessmentId = a.AssessmentId" &
                " AND assess.TaxYear = a.TaxYear" &
                " WHERE l.ClientId = " & m_ClientId &
                " AND l.LocationId = " & m_LocationId &
                " AND assess.AssessmentId = " & m_AssessmentId &
                " AND l.TaxYear = " & m_TaxYear
            GetData(sSQL, dtExistingAssets)
            dr = dtExistingAssets.Rows(0)
            sStateCd = UnNullToString(dr("StateCd"))
            Me.Text = "Importing assets for " & UnNullToString(dr("Name")) & "   " & UnNullToString(dr("Address")) & _
                "   " & UnNullToString(dr("City")) & ", " & sStateCd & ", account " & UnNullToString(dr("AcctNum"))
            m_ClientName = UnNullToString(dr("Name"))
            m_Address = UnNullToString(dr("Address"))
            m_City = UnNullToString(dr("City"))
            m_StateCd = UnNullToString(dr("StateCd"))
            m_Zip = UnNullToString(dr("Zip"))
            m_ClientLocationId = UnNullToString(dr("ClientLocationId"))
            m_AcctNum = UnNullToString(dr("AcctNum"))
            m_FactorEntityId1 = dr("FactorEntityId1")
            m_FactorEntityId2 = dr("FactorEntityId2")

            Return True
        Catch ex As Exception
            MsgBox("Error in RefreshData:  " & ex.Message)
            Return False
        End Try
    End Function

    Private Sub frmImportAssets_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If bActivated Then Exit Sub

        lblTotals.Text = ""
        If Not RefreshData() Then Me.Close()

        bActivated = True


    End Sub
    Private Function ImportFile() As Boolean
        Dim vFileContents As New Object, lColumn As Long, lRow As Long, sRowContents() As String
        Dim sFile As String = ""


        dgFileContents.Columns.Clear()
        cboAssetId.Items.Clear()
        cboAssetId.Items.Add("")
        cboGLCode.Items.Clear()
        cboGLCode.Items.Add("")
        cboPurchaseDate.Items.Clear()
        cboPurchaseDate.Items.Add("")
        cboDescription.Items.Clear()
        cboDescription.Items.Add("")
        cboCost.Items.Clear()
        cboCost.Items.Add("")
        cboMonth.Items.Clear()
        cboMonth.Items.Add("")
        cboDay.Items.Clear()
        cboDay.Items.Add("")
        cboYear.Items.Clear()
        cboYear.Items.Add("")
        cboDisposed.Items.Clear()
        cboDisposed.Items.Add("")
        cboAddress.Items.Clear()
        cboAddress.Items.Add("")
        cboVIN.Items.Clear()
        cboVIN.Items.Add("")
        cboAllocationPct.Items.Clear()
        cboAllocationPct.Items.Add("")

        txtFile.Text = ""

        If Not modMain.ImportFile(vFileContents, sFile) Then Return False

        txtFile.Text = sFile
        ReDim sRowContents(UBound(vFileContents, 1))
        iNumberOfColumns = UBound(vFileContents, 1) + 1

        For lColumn = 0 To UBound(vFileContents, 1)
            dgFileContents.Columns.Add(lColumn + 1, lColumn + 1)
        Next

        For lRow = 0 To UBound(vFileContents, 2)
            For lColumn = 0 To UBound(vFileContents, 1)
                sRowContents(lColumn) = vFileContents(lColumn, lRow)
            Next

            dgFileContents.Rows.Add(sRowContents)
        Next

        For lColumn = 1 To iNumberOfColumns
            cboAssetId.Items.Add(lColumn)
            cboGLCode.Items.Add(lColumn)
            cboPurchaseDate.Items.Add(lColumn)
            cboDescription.Items.Add(lColumn)
            cboCost.Items.Add(lColumn)
            cboMonth.Items.Add(lColumn)
            cboDay.Items.Add(lColumn)
            cboYear.Items.Add(lColumn)
            cboDisposed.Items.Add(lColumn)
            cboVIN.Items.Add(lColumn)
            cboAddress.Items.Add(lColumn)
            cboAllocationPct.Items.Add(lColumn)
        Next
        Return True
    End Function

    Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdFinish_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdFinish.Click
        Dim sError As String = ""

        Me.Cursor = Cursors.WaitCursor
        MDIParent1.ShowStatus("Saving data")
        ExecuteSQL("begin transaction")
        If UpdateAssets(sError) Then
            ExecuteSQL("commit transaction")
        Else
            ExecuteSQL("rollback transaction")
        End If
        MDIParent1.ShowStatus()
        Me.Cursor = Cursors.Default
        If sError = "" Then
            MsgBox("Import complete")
            Me.Close()
        Else
            MsgBox("Error importing:  " & sError)
        End If
    End Sub
    Private Function UpdateAssets(ByRef sError As String) As Boolean
        Dim sSQL As String = "", lRow As Long = 0, sStatus As String = ""
        Dim sAssetId As String = "", lOriginalCost As Long = 0, sPurchaseDate As String = "", sDescription As String = "", sGLCode As String = ""
        Dim sVIN As String = "", sLocationAddress As String = "", sTemp As String = ""
        Dim dInterstateAllocationPct As Double = 0
        Dim assetidarray(0) As String

        Try

            For lRow = 0 To dgResults.Rows.Count - 1
                sAssetId = dgResults.Rows(lRow).Cells("AssetId").Value
                sStatus = dgResults.Rows(lRow).Cells("Status").Value
                lOriginalCost = dgResults.Rows(lRow).Cells("OriginalCost").Value
                sPurchaseDate = dgResults.Rows(lRow).Cells("PurchaseDate").Value
                sDescription = dgResults.Rows(lRow).Cells("Description").Value
                sGLCode = Trim(UCase(dgResults.Rows(lRow).Cells("GLCode").Value))
                sVIN = dgResults.Rows(lRow).Cells("VIN").Value
                sLocationAddress = dgResults.Rows(lRow).Cells("LocationAddress").Value
                dInterstateAllocationPct = UnNullToDouble(dgResults.Rows(lRow).Cells("InterstateAllocationPct").Value)
                If dInterstateAllocationPct = 0 Then dInterstateAllocationPct = 1

                If sStatus = "Exists" Then
                    sSQL = "UPDATE Assets SET GLCode = " & QuoStr(sGLCode) & "," &
                        " Description = " & QuoStr(sDescription) & "," &
                        " VIN = " & QuoStr(sVIN) & "," &
                        " LocationAddress = " & QuoStr(sLocationAddress) & ","
                    sSQL = sSQL &
                        " ChangeDate = GETDATE(), ChangeUser = " & QuoStr(AppData.UserId) &
                        " WHERE ClientId = " & m_ClientId &
                        " AND LocationId = " & m_LocationId &
                        " AND AssetId = " & QuoStr(sAssetId) &
                        " AND TaxYear = " & m_TaxYear &
                        " AND AssessmentId = " & m_AssessmentId
                    ExecuteSQL(sSQL)
                    sSQL = "insert ClientGLCodes (ClientId,StateCd,GLCode,TaxYear,AddUser)" &
                        " SELECT l.ClientId, l.StateCd," & QuoStr(sGLCode) & "," &
                        m_TaxYear & "," & QuoStr(AppData.UserId) &
                        " FROM LocationsBPP l WHERE" &
                        " l.ClientId = " & m_ClientId & " AND l.LocationId = " & m_LocationId &
                        " AND l.TaxYear = " & m_TaxYear &
                        " AND NOT EXISTS" &
                        " (select ClientId from ClientGLCodes where ClientId = l.ClientId AND StateCd = " &
                        " l.StateCd AND GLCode = " & QuoStr(sGLCode) & " AND TaxYear = l.TaxYear)"
                    ExecuteSQL(sSQL)
                ElseIf sStatus = "Delete" Then
                    sSQL = "delete FactorCodeOverrides where ClientId = " & m_ClientId & " AND LocationId = " & m_LocationId &
                        " AND AssessmentId = " & m_AssessmentId &
                        " AND AssetId = " & QuoStr(sAssetId) &
                        " AND TaxYear = " & m_TaxYear
                    ExecuteSQL(sSQL)
                    sSQL = "DELETE ClientFactorCodeOverrides WHERE ClientId = " & m_ClientId &
                        " AND LocationId = " & m_LocationId &
                        " AND AssessmentId = " & m_AssessmentId &
                        " AND AssetId = " & QuoStr(sAssetId) &
                        " AND TaxYear = " & m_TaxYear
                    ExecuteSQL(sSQL)
                    sSQL = "DELETE AssetAllocationPct WHERE ClientId = " & m_ClientId &
                        " AND LocationId = " & m_LocationId &
                        " AND AssessmentId = " & m_AssessmentId &
                        " AND AssetId = " & QuoStr(sAssetId) &
                        " AND TaxYear = " & m_TaxYear
                    ExecuteSQL(sSQL)
                    sSQL = "DELETE Assets WHERE ClientId = " & m_ClientId &
                        " AND LocationId = " & m_LocationId &
                        " AND AssetId = " & QuoStr(sAssetId) &
                        " AND TaxYear = " & m_TaxYear &
                        " AND AssessmentId = " & m_AssessmentId
                    ExecuteSQL(sSQL)
                ElseIf dgResults.Rows(lRow).Cells("Status").Value = "Add" Then


                    'If Not CreateAsset(m_ClientId, m_LocationId, m_AssessmentId, m_TaxYear, sAssetId, lOriginalCost,
                    '        sPurchaseDate, sGLCode, sDescription, sVIN, sLocationAddress, True, sError) Then
                    '    Return False
                    'End If
                End If
                If (dgResults.Rows(lRow).Cells("Status").Value = "Add" Or dgResults.Rows(lRow).Cells("Status").Value = "Exists") And cboAllocationPct.Text <> "" Then
                    assetidarray(0) = sAssetId
                    If m_FactorEntityId1 <> 0 Then
                        If Not SaveAssetAllocationPct(m_ClientId, m_LocationId, m_AssessmentId, m_TaxYear, assetidarray, m_FactorEntityId1, enumAllocationPctType.eInterstate, dInterstateAllocationPct) Then
                            Return False
                        End If
                    End If
                    If m_FactorEntityId2 <> 0 Then
                        If Not SaveAssetAllocationPct(m_ClientId, m_LocationId, m_AssessmentId, m_TaxYear, assetidarray, m_FactorEntityId2, enumAllocationPctType.eInterstate, dInterstateAllocationPct) Then
                            Return False
                        End If
                    End If
                End If
            Next
            Return True
        Catch ex As Exception
            sError = ex.Message
        End Try

    End Function
    Private Sub cmdBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdBack.Click
        If fraResults.Visible Then
            fraResults.Visible = False
            fraColumns.Visible = True
            fraFile.Visible = False
            cmdNext.Enabled = True
        ElseIf fraColumns.Visible Then
            fraFile.Visible = True
            fraColumns.Visible = False
            fraResults.Visible = False
            cmdBack.Enabled = False
            cmdNext.Enabled = True
        ElseIf fraFile.Visible Then
            'fraFile.Visible = False
            'fraColumns.Visible = False
        End If

    End Sub

    Private Sub cmdNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdNext.Click
        If fraFile.Visible Then
            fraFile.Visible = False
            fraColumns.Visible = True
            cmdBack.Enabled = True
            cmdPrint.Enabled = False
        ElseIf fraColumns.Visible Then
            Dim bError As Boolean = False
            fraFile.Visible = False
            fraColumns.Visible = False

            Me.Cursor = Cursors.WaitCursor
            MDIParent1.ShowStatus("Comparing assets")
            CompareAssets(bError)
            MDIParent1.ShowStatus()
            Me.Cursor = Cursors.Default
            cmdPrint.Enabled = True
            If bError Then
                cmdFinish.Enabled = False
                cmdNext.Enabled = False
                fraResults.Visible = True
            Else
                cmdFinish.Enabled = True
                cmdNext.Enabled = False
                fraResults.Visible = True
                If MsgBox("Print import summary report?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then PrintAssets()
            End If
        ElseIf fraResults.Visible Then
            fraResults.Visible = False
            cmdPrint.Enabled = False
        End If

    End Sub

    Private Sub cboAssetId_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles cboAssetId.TextChanged, cboGLCode.TextChanged, cboPurchaseDate.TextChanged, _
            cboDescription.TextChanged, cboCost.TextChanged, cboMonth.TextChanged, cboDay.TextChanged, _
            cboYear.TextChanged, cboDisposed.TextChanged, cboAddress.TextChanged, cboVIN.TextChanged, _
            cboAllocationPct.TextChanged
        If Trim(sender.text) = "" Or (Val(sender.text) >= 1 And Val(sender.text) <= iNumberOfColumns) Then
            RenameColumns()
        End If
    End Sub
    Private Sub RenameColumns()
        Dim iColumn As Integer, i As Integer


        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = "Asset ID" Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboAssetId.Text) <> "" Then
            iColumn = Val(cboAssetId.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = "Asset ID"
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = "Original Cost" Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboCost.Text) <> "" Then
            iColumn = Val(cboCost.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = "Original Cost"
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = "G/L Code" Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboGLCode.Text) <> "" Then
            iColumn = Val(cboGLCode.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = "G/L Code"
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = "Day" Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboDay.Text) <> "" Then
            iColumn = Val(cboDay.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = "Day"
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = "Year" Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboYear.Text) <> "" Then
            iColumn = Val(cboYear.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = "Year"
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = "Month" Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboMonth.Text) <> "" Then
            iColumn = Val(cboMonth.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = "Month"
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = "Description" Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboDescription.Text) <> "" Then
            iColumn = Val(cboDescription.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = "Description"
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = "Purchase Date" Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboPurchaseDate.Text) <> "" Then
            iColumn = Val(cboPurchaseDate.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = "Purchase Date"
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = "Disposed" Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboDisposed.Text) <> "" Then
            iColumn = Val(cboDisposed.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = "Disposed"
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = "VIN" Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboVIN.Text) <> "" Then
            iColumn = Val(cboVIN.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = "VIN"
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = "Location Address" Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboAddress.Text) <> "" Then
            iColumn = Val(cboAddress.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = "Location Address"
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = "Interstate Allocation Pct" Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboAllocationPct.Text) <> "" Then
            iColumn = Val(cboAllocationPct.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = "Interstate Allocation Pct"
        End If

    End Sub
    Private Sub optMultiple_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optMultiple.Click, optSingle.Click
        If optMultiple.Checked Then
            cboMonth.Enabled = True
            cboDay.Enabled = True
            cboYear.Enabled = True
        Else
            cboMonth.Enabled = False
            cboDay.Enabled = False
            cboYear.Enabled = False
        End If
    End Sub


    Private Sub cmdBrowse_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdBrowse.Click
        Me.Cursor = Cursors.WaitCursor
        MDIParent1.ShowStatus("Loading file")
        If ImportFile() Then cmdNext.Enabled = True
        MDIParent1.ShowStatus()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub frmImportAssets_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fraColumns.Left = fraFile.Left
        fraColumns.Top = fraFile.Top
        fraResults.Left = fraFile.Left
        fraResults.Top = fraFile.Top
    End Sub

    Private Function CompareAssets(ByRef bError As Boolean) As Boolean
        'load results grid with imported data first
        'compare import with existing assets (status depends on options)
        'add extra existing assets with status (status depends on options, could be "will be deleted" or "will be kept", etc)

        Dim lRow As Long = 0, iCol As Integer = 0
        Dim sAssetId As String = "", sGLCode As String = "", sDate As String = "", sDescription As String = "", sCost As String = "", sMonth As String = ""
        Dim sDay As String = "", sYear As String = "", sError As String = "", sDisposed As String = ""
        Dim sInterstateAllocationPct As String = ""
        Dim sSQL As String = ""
        Dim sVIN As String = "", sAddress As String = ""
        Dim dr As DataRow, sStatus As String = "", bAnyExistingAssets As Boolean = False
        Dim listDuplicateAssets As New List(Of String), bExists As Boolean = False
        Dim enumErrorType As ErrorType

        Try
            bError = False
            lImportAssetAmount = 0 : lImportAssetCount = 0
            lblTotals.Text = ""
            dr = dtExistingAssets.Rows(0)
            If IsDBNull(dr("AssetId")) Then bAnyExistingAssets = False Else bAnyExistingAssets = True

            dgResults.Columns.Clear()
            dgResults.Columns.Add("AssetID", "Asset ID")
            dgResults.Columns.Add("GLCode", "G/L Code")
            dgResults.Columns.Add("PurchaseDate", "Purchase Date")
            dgResults.Columns.Add("OriginalCost", "Original Cost")
            dgResults.Columns.Add("Description", "Description")
            dgResults.Columns.Add("VIN", "VIN")
            dgResults.Columns.Add("LocationAddress", "Location Address")
            dgResults.Columns.Add("Disposed", "Disposed")
            dgResults.Columns.Add("InterstateAllocationPct", "Interstate Allocation Pct")
            dgResults.Columns.Add("Status", "Status")
            dgResults.Columns.Add("ErrorType", "ErrorType")
            If cboAddress.Text = "" Then dgResults.Columns("LocationAddress").Visible = False
            If cboDisposed.Text = "" Then dgResults.Columns("Disposed").Visible = False
            If cboVIN.Text = "" Then dgResults.Columns("VIN").Visible = False
            If cboDescription.Text = "" Then dgResults.Columns("Description").Visible = False
            If cboAllocationPct.Text = "" Then dgResults.Columns("InterstateAllocationPct").Visible = False
            dgResults.Columns("ErrorType").Visible = False

            lImportAssetCount = dgFileContents.Rows.Count
            For lRow = 0 To dgFileContents.Rows.Count - 1
                sAssetId = "" : sGLCode = "" : sDate = "" : sDescription = "" : sCost = "" : sMonth = "" : sInterstateAllocationPct = ""
                sDay = "" : sYear = "" : sDisposed = "" : sStatus = "" : enumErrorType = ErrorType.NoError
                For iCol = 0 To dgFileContents.Columns.Count - 1
                    If dgFileContents.Columns(iCol).HeaderText = "Asset ID" Then sAssetId = Trim(UCase(dgFileContents.Rows(lRow).Cells(iCol).Value))
                    If dgFileContents.Columns(iCol).HeaderText = "G/L Code" Then sGLCode = Trim(UCase(dgFileContents.Rows(lRow).Cells(iCol).Value))
                    If dgFileContents.Columns(iCol).HeaderText = "Purchase Date" Then sDate = Trim(dgFileContents.Rows(lRow).Cells(iCol).Value)
                    If dgFileContents.Columns(iCol).HeaderText = "Original Cost" Then sCost = Replace(Replace(Trim(dgFileContents.Rows(lRow).Cells(iCol).Value), "$", ""), ",", "")
                    If dgFileContents.Columns(iCol).HeaderText = "Month" Then sMonth = Trim(dgFileContents.Rows(lRow).Cells(iCol).Value)
                    If dgFileContents.Columns(iCol).HeaderText = "Day" Then sDay = Trim(dgFileContents.Rows(lRow).Cells(iCol).Value)
                    If dgFileContents.Columns(iCol).HeaderText = "Year" Then sYear = Trim(dgFileContents.Rows(lRow).Cells(iCol).Value)
                    If dgFileContents.Columns(iCol).HeaderText = "Description" Then sDescription = Trim(dgFileContents.Rows(lRow).Cells(iCol).Value)
                    If dgFileContents.Columns(iCol).HeaderText = "Disposed" Then sDisposed = Trim(dgFileContents.Rows(lRow).Cells(iCol).Value)
                    If dgFileContents.Columns(iCol).HeaderText = "VIN" Then sVIN = Trim(dgFileContents.Rows(lRow).Cells(iCol).Value)
                    If dgFileContents.Columns(iCol).HeaderText = "Location Address" Then sAddress = Trim(dgFileContents.Rows(lRow).Cells(iCol).Value)
                    If dgFileContents.Columns(iCol).HeaderText = "Interstate Allocation Pct" Then sInterstateAllocationPct = Replace(Replace(Trim(dgFileContents.Rows(lRow).Cells(iCol).Value), "%", ""), ",", "")
                Next
                If optMultiple.Checked Then
                    sDate = sMonth & "/" & sDay & "/" & sYear
                    If Not IsDate(sDate) Then
                        sDate = "1/1/" & sYear
                    End If
                Else
                    If Not IsDate(sDate) Then
                        sDate = "1/1/" & sDate
                    End If
                End If
                dgResults.Rows.Add()
                dgResults.Rows(lRow).Cells("AssetID").Value = sAssetId
                dgResults.Rows(lRow).Cells("GLCode").Value = sGLCode
                dgResults.Rows(lRow).Cells("PurchaseDate").Value = sDate
                dgResults.Rows(lRow).Cells("Description").Value = sDescription
                dgResults.Rows(lRow).Cells("OriginalCost").Value = sCost
                lImportAssetAmount = lImportAssetAmount + Val(sCost)
                If sDisposed <> "" Then
                    If sDisposed = Trim(txtDisposedValue.Text) Then sDisposed = "Yes" Else sDisposed = "No"
                End If
                dgResults.Rows(lRow).Cells("Disposed").Value = sDisposed
                If sDisposed = "Yes" Then
                    sStatus = "Disposed"
                End If
                dgResults.Rows(lRow).Cells("VIN").Value = sVIN
                dgResults.Rows(lRow).Cells("LocationAddress").Value = sAddress
                dgResults.Rows(lRow).Cells("InterstateAllocationPct").Value = sInterstateAllocationPct

                If sAssetId = "" Or IsDate(sDate) = False Or sGLCode = "" Or IsNumeric(sCost) = False Then
                    sStatus = "Error:  Missing data"
                    bError = True
                    enumErrorType = ErrorType.BadData
                End If
                'If bAnyExistingAssets = False Then
                If radioImportAdditions.Checked Or radioImportComplete.Checked Then
                    If sStatus = "" Then sStatus = "Add"
                ElseIf radioImportDeletions.Checked Then
                    If sStatus = "" Then sStatus = "Delete"
                End If
                'End If

                dgResults.Rows(lRow).Cells("Status").Value = sStatus
                dgResults.Rows(lRow).Cells("ErrorType").Value = enumErrorType
            Next
            dgResults.Sort(dgResults.Columns("AssetId"), System.ComponentModel.ListSortDirection.Ascending)
            sAssetId = ""
            For lRow = 0 To dgResults.Rows.Count - 1
                If sAssetId = dgResults.Rows(lRow).Cells("AssetId").Value Then
                    listDuplicateAssets.Add(sAssetId)
                End If
                sAssetId = dgResults.Rows(lRow).Cells("AssetId").Value
            Next
            If listDuplicateAssets.Count > 0 Then bError = True
            For lRow = 0 To dgResults.Rows.Count - 1
                For Each sAssetId In listDuplicateAssets
                    If dgResults.Rows(lRow).Cells("AssetId").Value = sAssetId Then
                        dgResults.Rows(lRow).Cells("Status").Value = "Error:  Duplicate asset"
                        dgResults.Rows(lRow).Cells("ErrorType").Value = ErrorType.DuplicateAsset
                    End If
                Next
            Next


            If bAnyExistingAssets = False Then
                Return True
            End If

            For Each dr In dtExistingAssets.Rows
                sStatus = "" : enumErrorType = ErrorType.NoError
                For lRow = 0 To dgResults.Rows.Count - 1
                    If dr("AssetId") = dgResults.Rows(lRow).Cells("AssetId").Value Then
                        If Math.Abs(Math.Abs(CLng(dr("OriginalCost"))) - Math.Abs(CLng(dgResults.Rows(lRow).Cells("OriginalCost").Value))) > 1 Then
                            sStatus = "Mismatch"
                            enumErrorType = ErrorType.BadData
                            bError = True
                        End If
                        If Year(CDate(dr("PurchaseDate"))) <> Year(CDate(dgResults.Rows(lRow).Cells("PurchaseDate").Value)) Then
                            sStatus = "Mismatch"
                            enumErrorType = ErrorType.BadData
                            bError = True
                        End If
                        If radioImportAdditions.Checked Then
                            If sStatus = "" Then sStatus = "Exists"
                        ElseIf radioImportComplete.Checked Then
                            If sStatus = "" Then sStatus = "Exists"
                        ElseIf radioImportDeletions.Checked Then
                            If sStatus = "" Then sStatus = "Delete"
                        End If
                        dgResults.Rows(lRow).Cells("Status").Value = sStatus
                        dgResults.Rows(lRow).Cells("ErrorType").Value = enumErrorType
                        Exit For
                    End If
                Next

                If sStatus = "" Then
                    If radioImportAdditions.Checked Then
                        sStatus = "Exists"
                    ElseIf radioImportComplete.Checked Then
                        sStatus = "Delete"
                    ElseIf radioImportDeletions.Checked Then
                        sStatus = "Exists"
                    End If

                    dgResults.Rows.Add()
                    lRow = dgResults.Rows.Count - 1
                    dgResults.Rows(lRow).Cells("AssetId").Value = dr("AssetId")
                    dgResults.Rows(lRow).Cells("GLCode").Value = dr("GLCode")
                    dgResults.Rows(lRow).Cells("PurchaseDate").Value = dr("PurchaseDate")
                    dgResults.Rows(lRow).Cells("Description").Value = dr("Description")
                    dgResults.Rows(lRow).Cells("OriginalCost").Value = dr("OriginalCost")
                    dgResults.Rows(lRow).Cells("VIN").Value = dr("VIN")
                    dgResults.Rows(lRow).Cells("LocationAddress").Value = dr("LocationAddress")
                    'If cboAllocationPct.Text <> "" Then
                    '    dgResults.Rows(lRow).Cells("InterstateAllocationPct").Value = dr("InterstateAllocationPct")
                    'End If
                    dgResults.Rows(lRow).Cells("Status").Value = sStatus
                End If
            Next

            lblTotals.Text = "Number of assets in file:  " & Format(lImportAssetCount, "#,##0") &
                ", total original cost:  " & Format(lImportAssetAmount, csInt)

        Catch ex As Exception
            MsgBox("Error comparing assets:  " & ex.Message)
        End Try

    End Function

    Private Sub frmImportAssets_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Dim Buttons(4) As Control

        Buttons(0) = cmdBack
        Buttons(1) = cmdNext
        Buttons(2) = cmdPrint
        Buttons(3) = cmdFinish
        Buttons(4) = cmdCancel
        PlaceButtons(Me, Buttons)

        If Me.WindowState = FormWindowState.Minimized Then Exit Sub
        fraFile.Width = Me.Width - 30
        fraFile.Height = Me.Height - 80
        fraColumns.Width = fraFile.Width
        fraColumns.Height = fraFile.Height
        fraResults.Width = fraFile.Width
        fraResults.Height = fraFile.Height
        dgResults.Width = fraResults.Width - 10
        dgResults.Height = fraResults.Height - 32
        dgFileContents.Width = fraColumns.Width - 10
        dgFileContents.Height = fraColumns.Height - dgFileContents.Top - 5

    End Sub

    Private Sub cmdPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        Me.Cursor = Cursors.WaitCursor
        PrintAssets()
        Me.Cursor = Cursors.Default
    End Sub
    Private Function PrintAssets() As Boolean
        Dim sSQL As String = "", lRow As Long = 0, enumErrorType As ErrorType
        Dim dr As DataGridViewRow
        Dim sAssetId As String = "", sGLCode As String = "", sDate As String = "", sDescription As String = ""
        Dim dCost As Double = 0, sVIN As String = "", sAddress As String = ""
        Dim sTitle As String = "", bNeedDetailReport As Boolean = False
        Dim INSERTSQL As String = "INSERT INTO ReportData (UserName,ReportId,Title01,Text01,Text02,Text03,Text04,Text05,Text06,Text07,Text08,Text09," & _
                    "Number01,Number02,Number03,Date01) SELECT " & QuoStr(AppData.UserId) & "," & AppData.ReportId & ","


        Try


            For Each dr In dgResults.Rows
                If dr.Cells("ErrorType").Value <> ErrorType.NoError Or dr.Cells("Status").Value = "Delete" Then
                    bNeedDetailReport = True
                    Exit For
                End If
            Next

            If bNeedDetailReport = False Then
                sSQL = INSERTSQL & QuoStr("") & "," & QuoStr(m_ClientName) & "," & QuoStr(m_Address) & "," & _
                    QuoStr(m_City & ", " & m_StateCd & "  " & m_Zip) & "," & QuoStr(m_ClientLocationId) & "," & _
                    QuoStr(m_AcctNum) & "," & QuoStr("") & "," & QuoStr("") & "," & QuoStr("") & "," & _
                    QuoStr("") & "," & lImportAssetCount & "," & lImportAssetAmount & "," & _
                    "0,NULL"
                ExecuteSQL(sSQL)
            Else
                For Each dr In dgResults.Rows
                    enumErrorType = dr.Cells("ErrorType").Value
                    sTitle = ""
                    If enumErrorType = ErrorType.BadData Then
                        sTitle = "Bad Data"
                    ElseIf enumErrorType = ErrorType.DuplicateAsset Then
                        sTitle = "Duplicate Asset"
                    ElseIf dr.Cells("Status").Value = "Delete" Then
                        sTitle = "Deleted Assets"
                    End If
                    If sTitle <> "" Then
                        sSQL = INSERTSQL & QuoStr(sTitle) & "," & QuoStr(m_ClientName) & "," & QuoStr(m_Address) & ","
                        sSQL = sSQL & QuoStr(m_City & ", " & m_StateCd & "  " & m_Zip) & ","
                        sSQL = sSQL & QuoStr(m_ClientLocationId) & ","
                        sSQL = sSQL & QuoStr(m_AcctNum) & ","
                        sSQL = sSQL & QuoStr(dr.Cells("AssetId").Value) & ","
                        sSQL = sSQL & QuoStr(dr.Cells("Description").Value) & ","
                        sSQL = sSQL & QuoStr(dr.Cells("GLCode").Value) & ","
                        sSQL = sSQL & QuoStr(dr.Cells("LocationAddress").Value) & ","
                        sSQL = sSQL & lImportAssetCount & "," & lImportAssetAmount & ","
                        sSQL = sSQL & Val(dr.Cells("OriginalCost").Value) & ","
                        sSQL = sSQL & QuoStr(dr.Cells("PurchaseDate").Value)
                        ExecuteSQL(sSQL)
                    End If
                Next
            End If

            Dim sPDFFileName As String = CleanFileName("AssetImportSummary_" & m_ClientName & " " & m_Address & " " & m_AcctNum & ".pdf")
            OpenReport(enumReport.enumAssetImport, _
                       "Asset Import Summary:  " & m_ClientName & " " & m_Address & " " & m_AcctNum, False, spdffilename, "")
            AppData.ReportId = AppData.ReportId + 1
            Return True
        Catch ex As Exception
            MsgBox("Error printing:  " & ex.Message)
            Return False
        End Try
    End Function


End Class
