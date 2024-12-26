Public Class frmBatchImportAssets

    Private bActivated As Boolean
    Private iNumberOfColumns As Integer
    Private lImportAssetCount As Long
    Private lImportAssetAmount As Long
    Private sExistingAssetsTableName As String
    Private sImportedAssetsTableName As String
    Private sResultsTableName As String
    Private sImportFile As String
    Private dtExistingAssets As New DataTable
    Private Enum ErrorType
        NoError = 0
        DuplicateAsset = 1
        BadData = 2
        Mismatch = 3
    End Enum
    Private Const LOCATIONIDHEADER As String = "Location ID"
    Private _IsSpecificAccount As Boolean = False
    Private _ClientName As String = ""
    Private _AcctNum As String = ""

    Public Property ClientId() As Long
    Public Property LocationId() As Long
    Public Property AssessmentId() As Long
    Public Property TaxYear() As Integer

    Private Function RefreshData() As Boolean
        Dim sSQL As String = "", dr As DataRow, lRows As Long = 0
        Dim dt As New DataTable

        Try
            If lRows = 0 Then
                Randomize()
                Do
                    Dim sRandom As String = Format(Rnd() * 1000000, "0")
                    sExistingAssetsTableName = "#tmpEABI_" & sRandom
                    sImportedAssetsTableName = "#tmpIABI_" & sRandom
                    sResultsTableName = "#tmpRABI_" & sRandom
                    sSQL = "SELECT 1 WHERE EXISTS (SELECT Name FROM sys.objects where name LIKE '%" & sRandom & "%')"
                    lRows = GetData(sSQL, dt)
                    If lRows = 0 Then Exit Do
                Loop
            Else
                sExistingAssetsTableName = "tempdb..existingassetstable"
                sImportedAssetsTableName = "tempdb..importedassetstable"
                sResultsTableName = "tempdb..resultstable"
                DropTempTables()
            End If
            sSQL = "CREATE TABLE " & sExistingAssetsTableName & " (Name varchar(255), Address varchar(50), City varchar(50)," &
                " StateCd varchar(2), Zip varchar(50), AcctNum varchar(50), OriginalCost bigint, ClientLocationId varchar(255)," &
                " PurchaseDate datetime, Description varchar(255), GLCode varchar(50), VIN varchar(255), LocationAddress varchar(255)," &
                " AssetId varchar(30)," &
                " [LesseeName] [varchar](50) NULL,[LesseeAddress] [varchar](255) NULL," &
                " [LesseeCity] [varchar](255) NULL,[LesseeStateCd] [varchar](2) NULL," & " [LesseeZip] [varchar](10) NULL," &
                " [LeaseTerm] [smallint] NULL,[EquipmentMake] [varchar](50) NULL," &
                " [EquipmentModel] [varchar](50) NULL,[LeaseType] [varchar](50) NULL, AuditFl bit null, ActivityQty bigint null)"
            lRows = ExecuteSQL(sSQL)
            sSQL = "INSERT INTO " & sExistingAssetsTableName &
                " SELECT c.Name, l.Address, l.City, l.StateCd, l.Zip, ISNULL(assess.AcctNum,'') AS AcctNum," &
                " ISNULL(a.OriginalCost,0) AS OriginalCost, ISNULL(l.ClientLocationId,'') AS ClientLocationId," &
                " a.PurchaseDate, ISNULL(a.Description,'') AS Description, ISNULL(a.GLCode,'') AS GLCode," &
                " ISNULL(a.VIN,'') AS VIN, ISNULL(a.LocationAddress,'') AS LocationAddress," &
                " a.AssetId," &
                " ISNULL(a.[LesseeName],''),ISNULL(a.[LesseeAddress],'')," &
                " ISNULL(a.[LesseeCity],''),ISNULL(a.[LesseeStateCd],''),ISNULL(a.[LesseeZip],'')," &
                " ISNULL(a.[LeaseTerm],0),ISNULL(a.[EquipmentMake],''),ISNULL(a.[EquipmentModel],''),ISNULL(a.[LeaseType],'')" &
                " ,ISNULL(a.AuditFl,0), ISNULL(a.ActivityQty,0)" &
                " FROM Clients AS c INNER JOIN" &
                " LocationsBPP AS l ON c.ClientId = l.ClientId INNER JOIN" &
                " AssessmentsBPP AS assess ON l.ClientId = assess.ClientId AND l.LocationId = assess.LocationId AND" &
                " l.TaxYear = assess.TaxYear LEFT OUTER JOIN" &
                " Assets AS a ON assess.ClientId = a.ClientId AND assess.LocationId = a.LocationId" &
                " AND assess.AssessmentId = a.AssessmentId" &
                " AND assess.TaxYear = a.TaxYear" &
                " WHERE assess.ClientId = " & ClientId &
                " AND l.TaxYear = " & TaxYear
            If _IsSpecificAccount Then
                sSQL = sSQL & " AND assess.LocationId = " & LocationId & " AND assess.AssessmentId = " & AssessmentId
            Else
                sSQL = sSQL & " AND ISNULL(l.ClientLocationId,'') <> ''"
            End If
            sSQL = sSQL & " ORDER BY l.ClientLocationId, a.AssetId"
            lRows = ExecuteSQL(sSQL)
            If lRows = 0 Then
                MsgBox("Client has no assessments")
                Return False
            End If
            sSQL = "CREATE TABLE " & sResultsTableName & "("
            sSQL = sSQL & "[OriginalCost] [bigint] NULL,"
            sSQL = sSQL & "[ClientLocationId] [varchar](50) NULL,"
            sSQL = sSQL & "[PurchaseDate] [datetime] NULL,"
            sSQL = sSQL & "[Description] [varchar](255) NULL,"
            sSQL = sSQL & "[GLCode] [varchar](50) NULL,"
            sSQL = sSQL & "[VIN] [varchar](255) NULL,"
            sSQL = sSQL & "[LocationAddress] [varchar](255) NULL,"
            sSQL = sSQL & "[AssetId] [varchar](30) NULL,"
            sSQL = sSQL & "[InterstateAllocationPct] [float] NULL,"
            sSQL = sSQL & "[LesseeName] [varchar](50) NULL, [LesseeAddress] [varchar](255) NULL,"
            sSQL = sSQL & "[LesseeCity] [varchar](255) NULL, [LesseeStateCd] [varchar](2) NULL,[LesseeZip] [varchar](10) NULL,"
            sSQL = sSQL & "[LeaseTerm] [smallint] NULL,"
            sSQL = sSQL & "[EquipmentMake] [varchar](50) NULL, [EquipmentModel] [varchar](50) NULL, [LeaseType] [varchar](50) NULL,"
            sSQL = sSQL & "AuditFl bit null, ActivityQty bigint null,"
            sSQL = sSQL & "[Status] [varchar](50) NULL,"
            sSQL = sSQL & "[ErrorType] [int] NULL)"
            ExecuteSQL(sSQL)

            sSQL = "SELECT Name, Address, City, AcctNum FROM " & sExistingAssetsTableName
            lRows = GetData(sSQL, dt)
            dr = dt.Rows(0)
            Dim sHeading As String = ""
            If _IsSpecificAccount Then
                sHeading = "Importing assets for " & dr("Name") & "  " & dr("Address") & "  " & dr("City") & "  " & dr("AcctNum")
                _AcctNum = dr("AcctNum")
            Else
                sHeading = "Importing asset batch for " & dr("Name")
            End If
            _ClientName = dr("Name")

            Me.Text = TaxYear & " " & sHeading

            Return True
        Catch ex As Exception
            MsgBox("Error in RefreshData:  " & ex.Message)
            Return False
        End Try
    End Function

    Private Sub frmBatchImportAssets_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If bActivated Then Exit Sub

        lblTotals.Text = ""
        If AssessmentId > 0 Then
            _IsSpecificAccount = True
            cboClientLocationId.Visible = False
            Label15.Visible = False
        Else
            _IsSpecificAccount = False
        End If
        If Not RefreshData() Then
            cmdNext.Enabled = False
            cmdBrowse.Enabled = False
        End If

        bActivated = True


    End Sub
    Private Function ImportFile() As Boolean
        Dim vFileContents As New Object, lColumn As Long, lRow As Long, sRowContents() As String

        sImportFile = ""
        dgFileContents.Columns.Clear()
        cboClientLocationId.Items.Clear()
        cboClientLocationId.Items.Add("")
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

        cboLeaseType.Items.Clear()
        cboLeaseType.Items.Add("")
        cboLesseeName.Items.Clear()
        cboLesseeName.Items.Add("")
        cboLesseeAddress.Items.Clear()
        cboLesseeAddress.Items.Add("")
        cboLesseeCity.Items.Clear()
        cboLesseeCity.Items.Add("")
        cboLesseeStateCd.Items.Clear()
        cboLesseeStateCd.Items.Add("")
        cboLesseeZip.Items.Clear()
        cboLesseeZip.Items.Add("")
        cboLeaseTerm.Items.Clear()
        cboLeaseTerm.Items.Add("")
        cboEquipmentMake.Items.Clear()
        cboEquipmentMake.Items.Add("")
        cboEquipmentModel.Items.Clear()
        cboEquipmentModel.Items.Add("")
        cboActivityQty.Items.Clear()
        cboActivityQty.Items.Add("")

        txtFile.Text = ""
        If Not modMain.ImportFile(vFileContents, sImportFile) Then Exit Function
        txtFile.Text = sImportFile

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
            cboClientLocationId.Items.Add(lColumn)
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
            cboLeaseType.Items.Add(lColumn)
            cboLesseeName.Items.Add(lColumn)
            cboLesseeAddress.Items.Add(lColumn)
            cboLesseeCity.Items.Add(lColumn)
            cboLesseeStateCd.Items.Add(lColumn)
            cboLesseeZip.Items.Add(lColumn)
            cboLeaseTerm.Items.Add(lColumn)
            cboEquipmentMake.Items.Add(lColumn)
            cboEquipmentModel.Items.Add(lColumn)
            cboActivityQty.Items.Add(lColumn)
        Next
        Return True
    End Function

    Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdFinish_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdFinish.Click
        Dim sError As String = "", bLoadAnyway As Boolean = True
        Dim ListOfLocationsWithError As List(Of String) = New List(Of String)

        ListOfLocationsWithError = GetLocationsWithErrors()
        If ListOfLocationsWithError.Count = 0 Then
            bLoadAnyway = True
        Else
            If MsgBox("Errors exist for some locations.  Load those locations?  Existing assets will be overwritten Or deleted.", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                bLoadAnyway = True
            Else
                bLoadAnyway = False
            End If
        End If

        MDIParent1.ShowStatus("Saving data")
        Me.Cursor = Cursors.WaitCursor
        ExecuteSQL("begin transaction")
        If UpdateAssets(bLoadAnyway, ListOfLocationsWithError, sError) Then
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
    Private Function GetLocationsWithErrors() As List(Of String)
        GetLocationsWithErrors = New List(Of String)
        Dim sSQL As String = ""
        Dim ListOfLocationsWithError As New List(Of String)
        Try
            sSQL = "SELECT DISTINCT ISNULL(ClientLocationId,'') AS ClientLocationId FROM " & sResultsTableName & " WHERE ErrorType <> " & ErrorType.NoError
            Dim dt As New DataTable
            GetData(sSQL, dt)
            ListOfLocationsWithError = New List(Of String)
            For Each dr As DataRow In dt.Rows
                ListOfLocationsWithError.Add(dr(0))
            Next
            GetLocationsWithErrors = ListOfLocationsWithError
        Catch ex As Exception
            MsgBox("Error loading locations with errors:  " & ex.Message)
        End Try
    End Function

    Private Function UpdateAssets(bLoadAnyway As Boolean, ListOfLocationsWithError As List(Of String), ByRef sError As String) As Boolean
        Dim sSQL As String = "", lRow As Long = 0, sStatus As String = ""
        Dim sAssetId As String = "", lOriginalCost As Long = 0, sPurchaseDate As String = "", sDescription As String = "", sGLCode As String = ""
        Dim sVIN As String = "", sLocationAddress As String = "", dInterstateAllocationPct As Double = 0, sTemp As String = ""
        Dim sClientLocationId As String = ""
        Dim sLesseeName As String = "", sLesseeAddress As String = "", sLeaseTerm As String = "", sEquipmentMake As String = "", sEquipmentModel As String = "", sLeaseType As String = ""
        Dim sLesseeCity As String = "", sLesseeStateCd As String = "", sLesseeZip As String = ""
        Dim sActivityQty As String = ""
        Dim Asset As structAsset
        Dim iProgress As Integer = 0, lTotalRows As Long = 0, assetidaray(0) As String
        Dim bUpdateAsset As Boolean = False

        Try

            iProgress = 0 : lTotalRows = dgResults.Rows.Count
            For lRow = 0 To dgResults.Rows.Count - 1
                If _IsSpecificAccount Then
                    bUpdateAsset = True
                Else
                    bUpdateAsset = ListOfLocationsWithError.Contains(UnNullToString(dgResults.Rows(lRow).Cells("ClientLocationId").Value)) = False Or bLoadAnyway = True
                End If
                If bUpdateAsset Then
                    sAssetId = UnNullToString(dgResults.Rows(lRow).Cells("AssetId").Value)
                    If _IsSpecificAccount = False Then sClientLocationId = UnNullToString(dgResults.Rows(lRow).Cells("ClientLocationId").Value)
                    sStatus = UnNullToString(dgResults.Rows(lRow).Cells("Status").Value)
                    lOriginalCost = UnNullToDouble(dgResults.Rows(lRow).Cells("OriginalCost").Value)
                    sPurchaseDate = UnNullToString(dgResults.Rows(lRow).Cells("PurchaseDate").Value)
                    sDescription = UnNullToString(dgResults.Rows(lRow).Cells("Description").Value)
                    sGLCode = Trim(UCase(UnNullToString(dgResults.Rows(lRow).Cells("GLCode").Value)))
                    sVIN = UnNullToString(dgResults.Rows(lRow).Cells("VIN").Value)
                    sLocationAddress = UnNullToString(dgResults.Rows(lRow).Cells("LocationAddress").Value)
                    ''if interstate allocation is 0 in the file, save 0.  only set to 1 if the file has 1 or the pct is not defined in the file
                    If dgResults.Rows(lRow).Cells("InterstateAllocationPct").Value.ToString.Trim = "" Then
                        dInterstateAllocationPct = 1
                    Else
                        dInterstateAllocationPct = UnNullToDouble(dgResults.Rows(lRow).Cells("InterstateAllocationPct").Value)
                    End If
                    sLeaseTerm = UnNullToString(dgResults.Rows(lRow).Cells("LeaseTerm").Value)
                    sLeaseType = UnNullToString(dgResults.Rows(lRow).Cells("LeaseType").Value)
                    sLesseeAddress = UnNullToString(dgResults.Rows(lRow).Cells("LesseeAddress").Value)
                    sLesseeName = UnNullToString(dgResults.Rows(lRow).Cells("LesseeName").Value)
                    sLesseeCity = UnNullToString(dgResults.Rows(lRow).Cells("LesseeCity").Value)
                    sLesseeStateCd = UnNullToString(dgResults.Rows(lRow).Cells("LesseeStateCd").Value)
                    sLesseeZip = UnNullToString(dgResults.Rows(lRow).Cells("LesseeZip").Value)
                    sEquipmentMake = UnNullToString(dgResults.Rows(lRow).Cells("EquipmentMake").Value)
                    sEquipmentModel = UnNullToString(dgResults.Rows(lRow).Cells("EquipmentModel").Value)
                    sActivityQty = UnNullToString(dgResults.Rows(lRow).Cells("ActivityQty").Value)

                    Asset.dAllocationPct = dInterstateAllocationPct
                    Asset.iLeaseTerm = IIf(sLeaseTerm = "", 0, Val(sLeaseTerm))
                    Asset.iTaxYear = TaxYear
                    Asset.lClientId = ClientId
                    Asset.lOriginalCost = lOriginalCost
                    Asset.sAssetId = sAssetId
                    Asset.sDescription = sDescription
                    Asset.sEquipmentMake = sEquipmentMake
                    Asset.sEquipmentModel = sEquipmentModel
                    Asset.sGLCode = sGLCode
                    Asset.sLeaseType = sLeaseType
                    Asset.sLesseeAddress = sLesseeAddress
                    Asset.sLesseeName = sLesseeName
                    Asset.sLesseeCity = sLesseeCity
                    Asset.sLesseeStateCd = sLesseeStateCd
                    Asset.sLesseeZip = sLesseeZip
                    Asset.sLocationAddress = sLocationAddress
                    Asset.sPurchaseDate = sPurchaseDate
                    Asset.sVIN = sVIN
                    Asset.ActivityQty = IIf(sActivityQty = "", 0, Val(sActivityQty))

                    If (sStatus = "Exists" Or sStatus = "Error:  Mismatch") And radioImportComplete.Checked Then
                        sSQL = "UPDATE Assets SET GLCode = " & QuoStr(sGLCode) & "," &
                            " OriginalCost = " & lOriginalCost & "," &
                            " PurchaseDate = " & QuoStr(sPurchaseDate) & "," &
                            " Description = " & QuoStr(sDescription) & "," &
                            " VIN = " & IIf(sVIN = "", "NULL", QuoStr(sVIN)) & "," &
                            " LocationAddress = " & IIf(sLocationAddress = "", "NULL", QuoStr(sLocationAddress)) & "," &
                            " LesseeName = " & IIf(sLesseeName = "", "NULL", QuoStr(sLesseeName)) & "," &
                            " LesseeAddress = " & IIf(sLesseeAddress = "", "NULL", QuoStr(sLesseeAddress)) & "," &
                            " LesseeCity = " & IIf(sLesseeCity = "", "NULL", QuoStr(sLesseeCity)) & "," &
                            " LesseeStateCd = " & IIf(sLesseeStateCd = "", "NULL", QuoStr(sLesseeStateCd)) & "," &
                            " LesseeZip = " & IIf(sLesseeZip = "", "NULL", QuoStr(sLesseeZip)) & "," &
                            " LeaseTerm = " & IIf(sLeaseTerm = "", "NULL", sLeaseTerm) & "," &
                            " EquipmentMake = " & IIf(sEquipmentMake = "", "NULL", QuoStr(sEquipmentMake)) & "," &
                            " EquipmentModel = " & IIf(sEquipmentModel = "", "NULL", QuoStr(sEquipmentModel)) & "," &
                            " LeaseType = " & IIf(sLeaseType = "", "NULL", QuoStr(sLeaseType)) & "," &
                            " ActivityQty = " & IIf(sActivityQty = "", "NULL", sActivityQty) & ","
                        sSQL = sSQL &
                            " ChangeDate = GETDATE(), ChangeUser = " & QuoStr(AppData.UserId)
                        sSQL = sSQL & " FROM AssessmentsBPP AS ass INNER JOIN" &
                            " LocationsBPP AS l ON ass.ClientId = l.ClientId AND ass.LocationId = l.LocationId AND ass.TaxYear = l.TaxYear INNER JOIN" &
                            " Assets AS a ON ass.ClientId = a.ClientId AND ass.LocationId = a.LocationId AND ass.AssessmentId = a.AssessmentId" &
                            " AND ass.TaxYear = a.TaxYear" &
                            " WHERE a.ClientId = " & ClientId &
                            " AND a.AssetId = " & QuoStr(sAssetId) &
                            " AND a.TaxYear = " & TaxYear
                        If _IsSpecificAccount Then
                            sSQL = sSQL & " AND a.LocationId = " & LocationId & " AND a.AssessmentId = " & AssessmentId
                        Else
                            sSQL = sSQL & " AND l.ClientLocationId = " & QuoStr(sClientLocationId)
                        End If
                        ExecuteSQL(sSQL)
                        sSQL = "insert ClientGLCodes (ClientId,StateCd,GLCode,TaxYear,AddUser)"
                        sSQL = sSQL & " SELECT l.ClientId, l.StateCd," & QuoStr(sGLCode) & "," &
                            TaxYear & "," & QuoStr(AppData.UserId) &
                            " FROM LocationsBPP l" &
                            " WHERE l.ClientId = " & ClientId
                        If _IsSpecificAccount Then
                            sSQL = sSQL & " AND l.LocationId = " & LocationId
                        Else
                            sSQL = sSQL & " AND l.ClientLocationId = " & QuoStr(sClientLocationId)
                        End If
                        sSQL = sSQL & " AND l.TaxYear = " & TaxYear
                        sSQL = sSQL &
                                " AND NOT EXISTS" &
                                " (select ClientId from ClientGLCodes where ClientId = l.ClientId AND StateCd = " &
                                " l.StateCd AND GLCode = " & QuoStr(sGLCode) & " AND TaxYear = l.TaxYear)"
                        ExecuteSQL(sSQL)
                    ElseIf sStatus = "Delete" Or sStatus.Contains("Error:") Then
                        sSQL = "DELETE FactorCodeOverrides" &
                            " FROM Assets AS a INNER JOIN" &
                            " LocationsBPP AS l INNER JOIN" &
                            " AssessmentsBPP AS ass ON l.ClientId = ass.ClientId AND l.LocationId = ass.LocationId AND l.TaxYear = ass.TaxYear ON " &
                            " a.ClientId = ass.ClientId AND a.LocationId = ass.LocationId" &
                            " AND a.AssessmentId = ass.AssessmentId AND a.TaxYear = ass.TaxYear INNER JOIN" &
                            " FactorCodeOverrides AS fo ON a.ClientId = fo.ClientId AND a.LocationId = fo.LocationId" &
                            " AND a.AssessmentId = fo.AssessmentId" &
                            " AND a.AssetId = fo.AssetId And a.TaxYear = fo.TaxYear" &
                            " WHERE fo.ClientId = " & ClientId & " AND fo.AssetId = " & QuoStr(sAssetId) &
                            " AND fo.TaxYear = " & TaxYear
                        If _IsSpecificAccount Then
                            sSQL = sSQL & " AND fo.LocationId = " & LocationId & " AND fo.AssessmentId = " & AssessmentId
                        Else
                            sSQL = sSQL & " AND l.ClientLocationId = " & QuoStr(sClientLocationId)
                        End If
                        ExecuteSQL(sSQL)
                        sSQL = "DELETE ClientFactorCodeOverrides" &
                                " FROM Assets AS a INNER JOIN" &
                                " LocationsBPP AS l INNER JOIN" &
                                " AssessmentsBPP AS ass ON l.ClientId = ass.ClientId AND l.LocationId = ass.LocationId AND l.TaxYear = ass.TaxYear ON " &
                                " a.ClientId = ass.ClientId AND a.LocationId = ass.LocationId" &
                                " AND a.AssessmentId = ass.AssessmentId AND a.TaxYear = ass.TaxYear INNER JOIN" &
                                " ClientFactorCodeOverrides AS fo ON a.ClientId = fo.ClientId AND a.LocationId = fo.LocationId" &
                                " AND a.AssessmentId = fo.AssessmentId" &
                                " AND a.AssetId = fo.AssetId And a.TaxYear = fo.TaxYear" &
                                " WHERE fo.ClientId = " & ClientId & " AND fo.AssetId = " & QuoStr(sAssetId) &
                                " AND fo.TaxYear = " & TaxYear
                        If _IsSpecificAccount Then
                            sSQL = sSQL & " AND fo.LocationId = " & LocationId & " AND fo.AssessmentId = " & AssessmentId
                        Else
                            sSQL = sSQL & " AND l.ClientLocationId = " & QuoStr(sClientLocationId)
                        End If
                        ExecuteSQL(sSQL)
                        sSQL = "DELETE AssetAllocationPct" &
                            " FROM Assets AS a INNER JOIN" &
                            " LocationsBPP AS l INNER JOIN" &
                            " AssessmentsBPP AS ass ON l.ClientId = ass.ClientId AND l.LocationId = ass.LocationId AND l.TaxYear = ass.TaxYear ON " &
                            " a.ClientId = ass.ClientId AND a.LocationId = ass.LocationId" &
                            " AND a.AssessmentId = ass.AssessmentId AND a.TaxYear = ass.TaxYear INNER JOIN" &
                            " AssetAllocationPct AS fo ON a.ClientId = fo.ClientId AND a.LocationId = fo.LocationId" &
                            " AND a.AssessmentId = fo.AssessmentId" &
                            " AND a.AssetId = fo.AssetId And a.TaxYear = fo.TaxYear" &
                            " WHERE fo.ClientId = " & ClientId & " AND fo.AssetId = " & QuoStr(sAssetId) &
                            " AND fo.TaxYear = " & TaxYear
                        If _IsSpecificAccount Then
                            sSQL = sSQL & " AND fo.LocationId = " & LocationId & " AND fo.AssessmentId = " & AssessmentId
                        Else
                            sSQL = sSQL & " AND l.ClientLocationId = " & QuoStr(sClientLocationId)
                        End If
                        ExecuteSQL(sSQL)
                        sSQL = "DELETE Assets" &
                            " FROM Assets AS a INNER JOIN" &
                            " LocationsBPP AS l INNER JOIN" &
                            " AssessmentsBPP AS ass ON l.ClientId = ass.ClientId AND l.LocationId = ass.LocationId AND l.TaxYear = ass.TaxYear" &
                            " ON a.ClientId = ass.ClientId And a.LocationId = ass.LocationId" &
                            " And a.AssessmentId = ass.AssessmentId And a.TaxYear = ass.TaxYear" &
                            " WHERE a.ClientId = " & ClientId & " AND a.AssetId = " & QuoStr(sAssetId) & " AND a.TaxYear = " & TaxYear
                        If _IsSpecificAccount Then
                            sSQL = sSQL & " AND a.LocationId = " & LocationId & " AND a.AssessmentId = " & AssessmentId
                        Else
                            sSQL = sSQL & " AND l.ClientLocationId = " & QuoStr(sClientLocationId)
                        End If
                        ExecuteSQL(sSQL)
                    ElseIf sStatus = "Add" Then
                        If _IsSpecificAccount Then
                            Asset.lLocationId = LocationId
                            Asset.lAssessmentId = AssessmentId
                            If Not CreateAsset(Asset, True, sError) Then
                                Return False
                            End If
                        Else
                            sSQL = "SELECT l.LocationId, a.AssessmentId" &
                                " FROM LocationsBPP AS l INNER JOIN" &
                                " AssessmentsBPP AS a ON l.ClientId = a.ClientId AND l.LocationId = a.LocationId AND l.TaxYear = a.TaxYear" &
                                " WHERE l.TaxYear = " & TaxYear & " AND l.ClientId = " & ClientId & " AND l.ClientLocationId = " & QuoStr(sClientLocationId)
                            Dim dtAss As New DataTable
                            GetData(sSQL, dtAss)
                            For Each dr As DataRow In dtAss.Rows
                                Asset.lAssessmentId = dr("AssessmentId")
                                Asset.lLocationId = dr("LocationId")
                                If Not CreateAsset(Asset, True, sError) Then
                                    Return False
                                End If
                            Next
                        End If
                    End If
                    If (sStatus = "Add" Or (sStatus = "Exists" And radioImportComplete.Checked)) And cboAllocationPct.Text <> "" Then
                        sSQL = "SELECT l.LocationId, a.AssessmentId, ISNULL(a.FactorEntityId1,0) AS FactorEntityId1, ISNULL(a.FactorEntityId2,0) AS FactorEntityId2" &
                            " FROM LocationsBPP AS l INNER JOIN" &
                            " AssessmentsBPP AS a ON l.ClientId = a.ClientId AND l.LocationId = a.LocationId AND l.TaxYear = a.TaxYear" &
                            " WHERE l.TaxYear = " & TaxYear & " AND l.ClientId = " & ClientId
                        If _IsSpecificAccount Then
                            sSQL = sSQL & " AND a.LocationId = " & LocationId & " AND a.AssessmentId = " & AssessmentId
                        Else
                            sSQL = sSQL & " AND l.ClientLocationId = " & QuoStr(sClientLocationId)
                        End If
                        Dim dtAss As New DataTable
                        GetData(sSQL, dtAss)
                        For Each dr As DataRow In dtAss.Rows
                            assetidaray(0) = sAssetId
                            If dr("FactorEntityId1") > 0 Then
                                If Not SaveAssetAllocationPct(ClientId, dr("LocationId"), dr("AssessmentId"), TaxYear, assetidaray, dr("FactorEntityId1"), enumAllocationPctType.eInterstate, dInterstateAllocationPct) Then
                                    Return False
                                End If
                            End If
                            If dr("FactorEntityId2") > 0 Then
                                If Not SaveAssetAllocationPct(ClientId, dr("LocationId"), dr("AssessmentId"), TaxYear, assetidaray, dr("FactorEntityId2"), enumAllocationPctType.eInterstate, dInterstateAllocationPct) Then
                                    Return False
                                End If
                            End If
                        Next
                    End If
                End If
                iProgress = iProgress + 1
                If iProgress > 50 Then
                    MDIParent1.ShowStatus("Updating database, " & Format((lRow + 1) / lTotalRows * 100, "0") & "% complete...")
                    Application.DoEvents()
                    iProgress = 0
                End If
            Next
            Return True
        Catch ex As Exception
            sError = ex.Message
            Return False
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
            fraFile.Visible = False
            fraColumns.Visible = False
            MDIParent1.ShowStatus("Comparing assets")
            Me.Cursor = Cursors.WaitCursor
            Dim bLocationsWithErrors As Boolean = False, bLocationsWithMismatches As Boolean = False
            CompareAssets(bLocationsWithErrors, bLocationsWithMismatches)
            MDIParent1.ShowStatus()
            Me.Cursor = Cursors.Default
            cmdPrint.Enabled = True
            Dim bContinue As Boolean = True
            If _IsSpecificAccount Then
                'If bLocationsWithErrors Then bContinue = False
            Else
                If bLocationsWithErrors Then
                    If MsgBox("Errors exist.  Do you want To load those locations that Do Not have errors?", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then
                        bContinue = False
                    End If
                End If
            End If
            If bLocationsWithMismatches Then
                MsgBox("Mismatches exist.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
            End If
            If bContinue Then
                cmdFinish.Enabled = True
                cmdNext.Enabled = False
                fraResults.Visible = True
                If MsgBox("Print import summary report?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then PrintAssets()
            Else
                fraColumns.Visible = True
                cmdBack.Enabled = True
                cmdPrint.Enabled = False
            End If
        ElseIf fraResults.Visible Then
            fraResults.Visible = False
            cmdPrint.Enabled = False
        End If

    End Sub

    Private Sub cboAssetId_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles cboAssetId.TextChanged, cboGLCode.TextChanged, cboPurchaseDate.TextChanged,
            cboDescription.TextChanged, cboCost.TextChanged, cboMonth.TextChanged, cboDay.TextChanged,
            cboYear.TextChanged, cboDisposed.TextChanged, cboAddress.TextChanged, cboVIN.TextChanged,
            cboAllocationPct.TextChanged, cboClientLocationId.TextChanged, cboEquipmentMake.TextChanged, cboEquipmentModel.TextChanged,
            cboLeaseTerm.TextChanged, cboLeaseType.TextChanged, cboLesseeAddress.TextChanged, cboLesseeName.TextChanged, cboActivityQty.TextChanged,
            cboLesseeCity.TextChanged, cboLesseeStateCd.TextChanged, cboLesseeZip.TextChanged
        If Trim(sender.text) = "" Or (Val(sender.text) >= 1 And Val(sender.text) <= iNumberOfColumns) Then
            RenameColumns()
        End If
    End Sub
    Private Sub RenameColumns()
        Dim iColumn As Integer, i As Integer

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = LOCATIONIDHEADER Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboClientLocationId.Text) <> "" Then
            iColumn = Val(cboClientLocationId.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = LOCATIONIDHEADER
        End If

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

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = "Lease Type" Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboLeaseType.Text) <> "" Then
            iColumn = Val(cboLeaseType.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = "Lease Type"
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = "Lessee Name" Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboLesseeName.Text) <> "" Then
            iColumn = Val(cboLesseeName.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = "Lessee Name"
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = "Lessee Address" Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboLesseeAddress.Text) <> "" Then
            iColumn = Val(cboLesseeAddress.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = "Lessee Address"
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = "Lessee City" Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboLesseeCity.Text) <> "" Then
            iColumn = Val(cboLesseeCity.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = "Lessee City"
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = "Lessee State" Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboLesseeStateCd.Text) <> "" Then
            iColumn = Val(cboLesseeStateCd.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = "Lessee State"
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = "Lessee Zip" Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboLesseeZip.Text) <> "" Then
            iColumn = Val(cboLesseeZip.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = "Lessee Zip"
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = "Lease Term" Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboLeaseTerm.Text) <> "" Then
            iColumn = Val(cboLeaseTerm.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = "Lease Term"
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = "Equipment Make" Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboEquipmentMake.Text) <> "" Then
            iColumn = Val(cboEquipmentMake.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = "Equipment Make"
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = "Equipment Model" Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboEquipmentModel.Text) <> "" Then
            iColumn = Val(cboEquipmentModel.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = "Equipment Model"
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = "ActivityQty" Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboActivityQty.Text) <> "" Then
            iColumn = Val(cboActivityQty.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = "Activity Qty"
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
        MDIParent1.ShowStatus("Loading file")
        Me.Cursor = Cursors.WaitCursor
        If ImportFile() Then cmdNext.Enabled = True
        MDIParent1.ShowStatus()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub frmBatchImportAssets_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        DropTempTables()
    End Sub
    Private Sub DropTempTables()
        Try
            ExecuteSQL("drop table " & sImportedAssetsTableName)
        Catch ex As Exception
        End Try
        Try
            ExecuteSQL("drop table " & sExistingAssetsTableName)
        Catch ex As Exception
        End Try
        Try
            ExecuteSQL("drop table " & sResultsTableName)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub frmBatchImportAssets_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fraColumns.Left = fraFile.Left
        fraColumns.Top = fraFile.Top
        fraResults.Left = fraFile.Left
        fraResults.Top = fraFile.Top
    End Sub
    Private Function CompareAssets(ByRef bSomeLocationsHaveErrors As Boolean, ByRef bSomeLocationsHaveMismatches As Boolean) As Boolean
        Try
            Dim sSQL As String = "", lRows As Long = 0
            Dim sInsertSQL As String = ""
            lblTotals.Text = ""
            bSomeLocationsHaveErrors = False
            bSomeLocationsHaveMismatches = False

            sInsertSQL = " INSERT " & sResultsTableName & " (ClientLocationId, AssetId, GLCode, OriginalCost, PurchaseDate, " &
                "Status, ErrorType"
            If cboAddress.Text <> "" Then sInsertSQL = sInsertSQL & ", LocationAddress"
            If cboVIN.Text <> "" Then sInsertSQL = sInsertSQL & ", VIN"
            If cboDescription.Text <> "" Then sInsertSQL = sInsertSQL & ", Description"
            If cboAllocationPct.Text <> "" Then sInsertSQL = sInsertSQL & ", InterstateAllocationPct"
            If cboLeaseType.Text <> "" Then sInsertSQL = sInsertSQL & ", LeaseType"
            If cboLesseeName.Text <> "" Then sInsertSQL = sInsertSQL & ", LesseeName"
            If cboLesseeAddress.Text <> "" Then sInsertSQL = sInsertSQL & ", LesseeAddress"
            If cboLesseeCity.Text <> "" Then sInsertSQL = sInsertSQL & ", LesseeCity"
            If cboLesseeStateCd.Text <> "" Then sInsertSQL = sInsertSQL & ", LesseeStateCd"
            If cboLesseeZip.Text <> "" Then sInsertSQL = sInsertSQL & ", LesseeZip"
            If cboLeaseTerm.Text <> "" Then sInsertSQL = sInsertSQL & ", LeaseTerm"
            If cboEquipmentMake.Text <> "" Then sInsertSQL = sInsertSQL & ", EquipmentMake"
            If cboEquipmentModel.Text <> "" Then sInsertSQL = sInsertSQL & ", EquipmentModel"
            If cboActivityQty.Text <> "" Then sInsertSQL = sInsertSQL & ", ActivityQty"
            sInsertSQL = sInsertSQL & ")"

            If Not LoadFileIntoDB() Then Return False
            ExecuteSQL("DELETE " & sResultsTableName)

            'Load all rows from imported file
            'for account specific import, put in acctnum for location id so queries downstream will work
            sSQL = sInsertSQL & " SELECT " & IIf(_IsSpecificAccount, QuoStr(_AcctNum), "LTRIM(RTRIM(i.ClientLocationId))") & ",LTRIM(RTRIM(i.AssetId)),LTRIM(RTRIM(i.GLCode))," &
                " Case When RTRIM(LTRIM(ISNULL(i.OriginalCost,''))) = '' THEN NULL ELSE ROUND(CONVERT(float,REPLACE(REPLACE(i.OriginalCost,'$',''),',','')),0) END,"
            If optMultiple.Checked Then
                'if month/day/year in separate fields, put together to make date
                sSQL = sSQL & " CASE WHEN ISDATE(i.PurchaseMonth + '/' + i.PurchaseDay + '/' + i.PurchaseYear) = 1" &
                    " THEN CONVERT(datetime, i.PurchaseMonth + '/' + i.PurchaseDay + '/' + i.PurchaseYear)" &
                    " ELSE CASE WHEN ISDATE('1/1/' + i.PurchaseYear) = 1 THEN CONVERT(datetime,'1/1/' + i.PurchaseYear)" &
                    " ELSE NULL END END"
            Else
                'date in one field
                sSQL = sSQL & " CASE WHEN ISDATE(i.PurchaseDate) = 1" &
                    " THEN CONVERT(datetime, i.PurchaseDate)" &
                    " ELSE CASE WHEN ISDATE('1/1/' + i.PurchaseDate) = 1 THEN CONVERT(datetime,'1/1/' + i.PurchaseDate)" &
                    " ELSE NULL END END"
            End If
            If radioImportAdditions.Checked Then
                sSQL = sSQL & ",'Add'"
            ElseIf radioImportComplete.Checked Then
                sSQL = sSQL & ",'Exists'"
            ElseIf radioImportDeletions.Checked Then
                sSQL = sSQL & ",'Delete'"
            End If
            sSQL = sSQL & ",0"

            If cboAddress.Text <> "" Then sSQL = sSQL & ",LTRIM(RTRIM(i.LocationAddress))"
            If cboVIN.Text <> "" Then sSQL = sSQL & ",LTRIM(RTRIM(i.VIN))"
            If cboDescription.Text <> "" Then sSQL = sSQL & ",LTRIM(RTRIM(i.Description))"
            If cboAllocationPct.Text <> "" Then
                sSQL = sSQL & ",CASE WHEN RTRIM(LTRIM(ISNULL(i.InterstateAllocationPct,''))) = '' THEN NULL ELSE ROUND(CONVERT(float,REPLACE(REPLACE(i.InterstateAllocationPct,'%',''),',','')),8) END"
            End If

            If cboLeaseType.Text <> "" Then sSQL = sSQL & ",LTRIM(RTRIM(i.LeaseType))"
            If cboLesseeName.Text <> "" Then sSQL = sSQL & ",LTRIM(RTRIM(i.LesseeName))"
            If cboLesseeAddress.Text <> "" Then sSQL = sSQL & ",LTRIM(RTRIM(i.LesseeAddress))"
            If cboLesseeCity.Text <> "" Then sSQL = sSQL & ",LTRIM(RTRIM(i.LesseeCity))"
            ''If cboLesseeStateCd.Text <> "" Then sSQL = sSQL & ",LTRIM(RTRIM(i.LesseeStateCd))"
            If cboLesseeStateCd.Text <> "" Then sSQL = sSQL & ",CASE WHEN RTRIM(LTRIM(ISNULL(i.LesseeStateCd,''))) = '' THEN NULL ELSE CASE WHEN (SELECT s.StateCd FROM States s WHERE s.StateCd = RTRIM(LTRIM(i.LesseeStateCd))) IS NULL THEN CASE WHEN (SELECT s.StateCd FROM States s WHERE s.StateName = RTRIM(LTRIM(i.LesseeStateCd))) IS NULL THEN NULL ELSE (SELECT s.StateCd FROM States s WHERE s.StateName = RTRIM(LTRIM(i.LesseeStateCd))) END ELSE RTRIM(LTRIM(i.LesseeStateCd)) END END"
            If cboLesseeZip.Text <> "" Then sSQL = sSQL & ",LTRIM(RTRIM(i.LesseeZip))"
            If cboLeaseTerm.Text <> "" Then
                sSQL = sSQL & ",CASE WHEN RTRIM(LTRIM(ISNULL(i.LeaseTerm,''))) = '' THEN NULL ELSE ROUND(CONVERT(smallint,REPLACE(REPLACE(i.LeaseTerm,'%',''),',','')),0) END"
            End If
            If cboEquipmentMake.Text <> "" Then sSQL = sSQL & ",LTRIM(RTRIM(i.EquipmentMake))"
            If cboEquipmentModel.Text <> "" Then sSQL = sSQL & ",LTRIM(RTRIM(i.EquipmentModel))"
            If cboActivityQty.Text <> "" Then
                sSQL = sSQL & ",CASE WHEN RTRIM(LTRIM(ISNULL(i.ActivityQty,''))) = '' THEN NULL ELSE ROUND(CONVERT(bigint,REPLACE(REPLACE(i.ActivityQty,'%',''),',','')),0) END"
            End If

            sSQL = sSQL & " FROM " & sImportedAssetsTableName & " i"
            ExecuteSQL(sSQL)

            sSQL = "SELECT SUM(OriginalCost) AS TotalCost, COUNT(*) AS TotalCount FROM " & sResultsTableName
            Dim dt As New DataTable
            If GetData(sSQL, dt) > 0 Then
                lblTotals.Text = "Number of assets in file:  " & Format(UnNullToDouble(dt.Rows(0)("TotalCount")), "#,##0") &
                    ", total original cost:  " & Format(UnNullToDouble(dt.Rows(0)("TotalCost")), csInt)

            End If

            'if locationid or assetid or purchase date is empty in imported file
            sSQL = "UPDATE " & sResultsTableName & " SET Status = 'Error:  Missing data', ErrorType = " & ErrorType.BadData &
                " WHERE RTRIM(LTRIM(ISNULL(AssetId,''))) = ''" &
                " OR PurchaseDate IS NULL OR RTRIM(LTRIM(ISNULL(GLCode,''))) = '' OR OriginalCost IS NULL"
            If _IsSpecificAccount = False Then
                sSQL = sSQL & " OR RTRIM(LTRIM(ISNULL(ClientLocationId,''))) = ''"
            End If
            If ExecuteSQL(sSQL) > 0 Then bSomeLocationsHaveErrors = True

            If _IsSpecificAccount = False Then
                'if locationid in import file does not exist for client
                sSQL = "UPDATE " & sResultsTableName & " SET Status = 'Error:  Location ID does not exist', ErrorType = " & ErrorType.BadData &
                " WHERE ClientLocationId NOT IN (SELECT DISTINCT ClientLocationId FROM " & sExistingAssetsTableName & ")"
                If ExecuteSQL(sSQL) > 0 Then bSomeLocationsHaveErrors = True
            End If

            'if any duplicate assets for locationid in import file
            sSQL = "UPDATE " & sResultsTableName & " SET Status = 'Error:  Duplicate asset', ErrorType = " & ErrorType.DuplicateAsset
            If _IsSpecificAccount Then
                sSQL = sSQL & " FROM (SELECT AssetId, COUNT(OriginalCost) AS AssetCount" &
                    " FROM " & sResultsTableName & " GROUP BY AssetId" &
                    " HAVING (COUNT(OriginalCost) > 1)) as dupes" &
                    " INNER JOIN " & sResultsTableName & " r on r.AssetId = dupes.AssetId"
            Else
                sSQL = sSQL & " FROM (SELECT ClientLocationId, AssetId, COUNT(OriginalCost) AS AssetCount" &
                    " FROM " & sResultsTableName & " GROUP BY ClientLocationId, AssetId" &
                    " HAVING (COUNT(OriginalCost) > 1)) as dupes" &
                    " INNER JOIN " & sResultsTableName & " r on r.ClientLocationId = dupes.ClientLocationId" &
                    " and r.AssetId = dupes.AssetId"
            End If
            If ExecuteSQL(sSQL) > 0 Then bSomeLocationsHaveErrors = True

            'for locationid/assets that match up between import file and existing assets, if cost or date doesn't match
            sSQL = "UPDATE " & sResultsTableName & " SET Status = 'Error:  Mismatch', ErrorType = " & ErrorType.Mismatch
            If _IsSpecificAccount Then
                sSQL = sSQL & " FROM " & sResultsTableName & " AS r" &
                    " INNER JOIN " & sExistingAssetsTableName & " AS e ON r.AssetId = e.AssetId WHERE" &
                    " (ABS(ABS(e.OriginalCost) - ABS(r.OriginalCost)) > 1) OR" &
                    " (YEAR(e.PurchaseDate) <> YEAR(r.PurchaseDate))"
            Else
                sSQL = sSQL & " FROM " & sResultsTableName & " AS r" &
                    " INNER JOIN " & sExistingAssetsTableName & " AS e ON r.ClientLocationId = e.ClientLocationId" &
                    " AND r.AssetId = e.AssetId WHERE" &
                    " (ABS(ABS(e.OriginalCost) - ABS(r.OriginalCost)) > 1) OR" &
                    " (YEAR(e.PurchaseDate) <> YEAR(r.PurchaseDate))"
            End If
            If ExecuteSQL(sSQL) > 0 Then bSomeLocationsHaveMismatches = True

            'where assets match and not in error, set status to exists or delete
            sSQL = "UPDATE " & sResultsTableName & " SET Status = "
            If radioImportAdditions.Checked Then
                sSQL = sSQL & "'Exists'"
            ElseIf radioImportComplete.Checked Then
                sSQL = sSQL & "'Exists'"
            ElseIf radioImportDeletions.Checked Then
                sSQL = sSQL & "'Delete'"
            End If
            sSQL = sSQL & " FROM " & sResultsTableName & " AS r" &
                " INNER JOIN " & sExistingAssetsTableName & " AS e ON r.AssetId = e.AssetId"
            If _IsSpecificAccount = False Then
                sSQL = sSQL & " AND r.ClientLocationId = e.ClientLocationId"
            End If
            sSQL = sSQL & " WHERE r.ErrorType = " & ErrorType.NoError
            ExecuteSQL(sSQL)

            'for complete import, set to Add for those assets in the import file, but do not exist
            If radioImportComplete.Checked Then
                sSQL = "UPDATE " & sResultsTableName & " Set Status = 'Add'" &
                    " FROM " & sResultsTableName & " AS r" &
                    " LEFT OUTER JOIN " & sExistingAssetsTableName & " AS e" &
                    " ON r.AssetId = e.AssetId"
                If _IsSpecificAccount = False Then
                    sSQL = sSQL & " AND r.ClientLocationId = e.ClientLocationId"
                End If
                sSQL = sSQL & " WHERE r.ErrorType = " & ErrorType.NoError & " AND e.AssetId IS NULL"
                ExecuteSQL(sSQL)
            End If

            'add any existing assets not in the import file.  set to delete if complete list
            'if deletions then set to exists.  if additions then exists
            sSQL = "INSERT " & sResultsTableName & " (" & IIf(_IsSpecificAccount, "", "ClientLocationId,") & "AssetId,OriginalCost,PurchaseDate," &
                " Description, GLCode, VIN,LocationAddress,AuditFl,Status,ErrorType)" &
                " SELECT " & IIf(_IsSpecificAccount, "", "e.ClientLocationId,") & "e.AssetId, e.OriginalCost, e.PurchaseDate," &
                " e.Description, e.GLCode, e.VIN, e.LocationAddress, e.AuditFl,"
            If radioImportComplete.Checked = True Then
                sSQL = sSQL & "CASE WHEN e.AuditFl=1 THEN 'Audit' ELSE 'Delete' END"
            Else
                sSQL = sSQL & "CASE WHEN e.AuditFl=1 THEN 'Audit' ELSE 'Exists' END"
            End If
            sSQL = sSQL & ",0 FROM " & sExistingAssetsTableName & " AS e" &
                " LEFT OUTER JOIN " & sResultsTableName & " AS r" &
                " ON e.AssetId = r.AssetId"
            If _IsSpecificAccount = False Then
                sSQL = sSQL & " AND e.ClientLocationId = r.ClientLocationId"
            End If
            sSQL = sSQL & " WHERE r.AssetId IS NULL AND e.AssetId IS NOT NULL"
            If _IsSpecificAccount = False Then
                sSQL = sSQL & " AND e.ClientLocationId IN (SELECT DISTINCT ClientLocationId" &
                    " FROM " & sResultsTableName & ")"
            End If
            ExecuteSQL(sSQL)

            dgResults.Columns.Clear()
            sSQL = "SELECT " & IIf(_IsSpecificAccount = False, "ClientLocationId,", "") & "AssetId,GLCode,PurchaseDate,OriginalCost,Description,VIN,LocationAddress,InterstateAllocationPct," &
                " LeaseType, LesseeName, LesseeAddress,LesseeCity,LesseeStateCd,LesseeZip," &
                " LeaseTerm, EquipmentMake, EquipmentModel,ActivityQty," &
                " Status,ErrorType" &
                " FROM " & sResultsTableName & " ORDER BY " & IIf(_IsSpecificAccount, "", "ClientLocationId,") & "AssetId"
            Dim bind As New BindingSource
            lRows = GetData(sSQL, dt)
            bind.DataSource = dt
            dgResults.DataSource = bind
            dgResults.Columns("ErrorType").Visible = False
            dgResults.Columns("VIN").Visible = Not (cboVIN.Text = "")
            dgResults.Columns("LocationAddress").Visible = Not (cboAddress.Text = "")
            dgResults.Columns("Description").Visible = Not (cboDescription.Text = "")
            dgResults.Columns("InterstateAllocationPct").Visible = Not (cboAllocationPct.Text = "")
            dgResults.Columns("LeaseType").Visible = Not (cboLeaseType.Text = "")
            dgResults.Columns("LesseeName").Visible = Not (cboLesseeName.Text = "")
            dgResults.Columns("LesseeAddress").Visible = Not (cboLesseeAddress.Text = "")
            dgResults.Columns("LesseeCity").Visible = Not (cboLesseeCity.Text = "")
            dgResults.Columns("LesseeStateCd").Visible = Not (cboLesseeStateCd.Text = "")
            dgResults.Columns("LesseeZip").Visible = Not (cboLesseeZip.Text = "")
            dgResults.Columns("LeaseTerm").Visible = Not (cboLeaseTerm.Text = "")
            dgResults.Columns("EquipmentMake").Visible = Not (cboEquipmentMake.Text = "")
            dgResults.Columns("EquipmentModel").Visible = Not (cboEquipmentModel.Text = "")
            dgResults.Columns("ActivityQty").Visible = Not (cboActivityQty.Text = "")

            Return True
        Catch ex As Exception
            MsgBox("Error comparing assets  " & ex.Message)
            Return False
        End Try
    End Function

    Private Sub frmBatchImportAssets_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
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
        Dim sSQL As String = "", enumErrorType As ErrorType
        Dim dr As DataRow
        Dim sDate As String = ""
        Dim sTitle As String = ""
        Dim INSERTSQL As String = "INSERT INTO ReportData (UserName,ReportId,Title01,Text01,Text02,Text03,Text04,Text05,Text06,Text07,Text08,Text09," &
                    "Number01,Number02,Number03,Date01)"
        Dim dt As New DataTable, sPDFFileName As String = ""

        Try
            'locations with no errors get a summary report
            sSQL = "SELECT t2.ClientLocationId,COUNT(*) AS TotalCount,SUM(t2.OriginalCost) AS TotalCost" &
                " FROM (SELECT t.ClientLocationId, t.OriginalCost" &
                " FROM " & sResultsTableName & " AS t" &
                " INNER JOIN (SELECT DISTINCT t3.ClientLocationId" &
                " FROM " & sResultsTableName & " t3 WHERE Not EXISTS (SELECT t4.ClientLocationId FROM " & sResultsTableName & " t4" &
                " WHERE t4.ClientLocationId = t3.ClientLocationId And t4.ErrorType Not IN(" & ErrorType.NoError & "," & ErrorType.Mismatch & "))) AS ul" &
                " ON t.ClientLocationId = ul.ClientLocationId WHERE t.Status <> 'Delete') t2" &
                " GROUP BY t2.ClientLocationId"
            GetData(sSQL, dt)
            For Each dr In dt.Rows
                sSQL = INSERTSQL & " SELECT " & QuoStr(AppData.UserId) & "," & AppData.ReportId & "," &
                    QuoStr("") & "," & QuoStr("Successfully imported assets for " &
                    _ClientName & IIf(_IsSpecificAccount, ":  " & _AcctNum, ":  " & dr("ClientLocationId"))) & "," &
                    QuoStr("") & "," &
                    QuoStr("") & "," & QuoStr("") & "," &
                    QuoStr("") & "," & QuoStr("") & "," & QuoStr("") & "," & QuoStr("") & "," &
                    QuoStr("") & "," & dr("TotalCount") & "," & dr("TotalCost") & "," &
                    "0,NULL"
                ExecuteSQL(sSQL)
                sSQL = INSERTSQL & " SELECT " & QuoStr(AppData.UserId) & "," & AppData.ReportId & "," &
                    QuoStr("Deleted Assets for " & _ClientName & IIf(_IsSpecificAccount, ":  " & _AcctNum, ":  " & dr("ClientLocationId"))) & "," &
                    QuoStr(_ClientName) & "," & QuoStr("") & ","
                sSQL = sSQL & QuoStr("") & ","
                sSQL = sSQL & " ClientLocationId, '',AssetId,ISNULL(Description,''),ISNULL(GLCode,'')," &
                    " ISNULL(LocationAddress,''),0,0,OriginalCost,PurchaseDate" &
                    " FROM " & sResultsTableName & " WHERE Status = 'Delete' " & IIf(_IsSpecificAccount, "", " AND ClientLocationId = " & QuoStr(dr("ClientLocationId").ToString)) &
                    " "
                ExecuteSQL(sSQL)

                sPDFFileName = CleanFileName("BatchAssetImportSummary_" & _ClientName &
                    ":  " & IIf(_IsSpecificAccount, _AcctNum, dr("ClientLocationId")) &
                    ".pdf")
                OpenReport(enumReport.enumAssetImport,
                    "Batch Asset Import Summary:  " & _ClientName & ", " & IIf(_IsSpecificAccount, _AcctNum, dr("ClientLocationId")),
                    False, sPDFFileName, "")
                AppData.ReportId = AppData.ReportId + 1
            Next

            'print detail for assets that had errors
            sSQL = "SELECT * FROM " & sResultsTableName & " WHERE ErrorType <> " & ErrorType.NoError & " ORDER BY ClientLocationId, AssetId"
            Dim lRows As Long = 0
            lRows = GetData(sSQL, dt)
            For Each dr In dt.Rows
                enumErrorType = dr("ErrorType")
                sTitle = ""
                If enumErrorType = ErrorType.BadData Then
                    sTitle = "Bad Data"
                ElseIf enumErrorType = ErrorType.DuplicateAsset Then
                    sTitle = "Duplicate Assets"
                ElseIf enumErrorType = ErrorType.Mismatch Then
                    sTitle = "Mismatch"
                ElseIf dr("Status").Value = "Delete" Then
                    sTitle = "Deleted Assets"
                End If
                If sTitle <> "" Then
                    sTitle = sTitle & " for " & _ClientName & ":  " & IIf(_IsSpecificAccount, _AcctNum, dr("ClientLocationId").ToString)
                    sSQL = INSERTSQL & " SELECT " & QuoStr(AppData.UserId) & "," & AppData.ReportId & "," &
                        QuoStr(sTitle) & "," & QuoStr(_ClientName) & "," & QuoStr("") & ","
                    sSQL = sSQL & QuoStr("") & ","
                    sSQL = sSQL & QuoStr(IIf(_IsSpecificAccount, _AcctNum, dr("ClientLocationId").ToString)) & ","
                    sSQL = sSQL & QuoStr("") & ","
                    sSQL = sSQL & QuoStr(dr("AssetId").ToString) & ","
                    sSQL = sSQL & QuoStr(dr("Description").ToString) & ","
                    sSQL = sSQL & QuoStr(dr("GLCode").ToString) & ","
                    sSQL = sSQL & QuoStr(dr("LocationAddress").ToString) & ","
                    sSQL = sSQL & "0" & "," & "0" & ","
                    sSQL = sSQL & Val(dr("OriginalCost").ToString) & ","
                    If IsDBNull(dr("PurchaseDate")) Then
                        sDate = "NULL"
                    Else
                        sDate = QuoStr(dr("PurchaseDate"))
                    End If
                    sSQL = sSQL & sDate
                    ExecuteSQL(sSQL)
                End If
            Next

            If lRows > 0 Then
                sPDFFileName = CleanFileName("BatchAssetImportSummary_" & _ClientName & IIf(_IsSpecificAccount, _AcctNum, "") & ".pdf")
                OpenReport(enumReport.enumAssetImport,
                            "Batch Asset Import Summary:  " & _ClientName & IIf(_IsSpecificAccount, _AcctNum, ""), False, sPDFFileName, "")
                AppData.ReportId = AppData.ReportId + 1
            End If

            Return True
        Catch ex As Exception
            MsgBox("Error printing:  " & ex.Message)
            Return False
        End Try
    End Function
    Private Function LoadFileIntoDB() As Boolean
        Try
            ExecuteSQL("DROP TABLE " & sImportedAssetsTableName)
        Catch ex As Exception
        End Try

        Try
            Dim lRows As Long, sSQL As String = "", sField As String = ""
            Dim iCol As Integer = 0
            sSQL = ""
            For iCol = 0 To dgFileContents.ColumnCount - 1
                If sSQL <> "" Then sSQL = sSQL & ","
                Select Case dgFileContents.Columns(iCol).HeaderText
                    Case LOCATIONIDHEADER
                        sField = "ClientLocationId"
                    Case "Asset ID"
                        sField = "AssetId"
                    Case "G/L Code"
                        sField = "GLCode"
                    Case "Purchase Date"
                        sField = "PurchaseDate"
                    Case "Original Cost"
                        sField = "OriginalCost"
                    Case "Month"
                        sField = "PurchaseMonth"
                    Case "Day"
                        sField = "PurchaseDay"
                    Case "Year"
                        sField = "PurchaseYear"
                    Case "Description"
                        sField = "Description"
                    Case "Disposed"
                        sField = "Disposed"
                    Case "VIN"
                        sField = "VIN"
                    Case "Location Address"
                        sField = "LocationAddress"
                    Case "Interstate Allocation Pct"
                        sField = "InterstateAllocationPct"
                    Case "Lease Type"
                        sField = "LeaseType"
                    Case "Lessee Name"
                        sField = "LesseeName"
                    Case "Lessee Address"
                        sField = "LesseeAddress"
                    Case "Lessee City"
                        sField = "LesseeCity"
                    Case "Lessee State"
                        sField = "LesseeStateCd"
                    Case "Lessee Zip"
                        sField = "LesseeZip"
                    Case "Lease Term"
                        sField = "LeaseTerm"
                    Case "Equipment Make"
                        sField = "EquipmentMake"
                    Case "Equipment Model"
                        sField = "EquipmentModel"
                    Case "Activity Qty"
                        sField = "ActivityQty"
                    Case Else
                        sField = "Column" & iCol
                End Select
                sSQL = sSQL & sField & " varchar(255)"
            Next
            sSQL = "CREATE TABLE " & sImportedAssetsTableName & " (" & sSQL & ")"
            ExecuteSQL(sSQL)

            sSQL = "BULK INSERT " & sImportedAssetsTableName & " FROM " & QuoStr(sImportFile) &
                " WITH (ROWTERMINATOR = '\n', FIELDTERMINATOR ='\t')"
            lRows = ExecuteSQL(sSQL)

            Return True
        Catch ex As Exception
            MsgBox("Error loading file into database:  " & ex.Message)
            Return False
        End Try


    End Function

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

End Class


