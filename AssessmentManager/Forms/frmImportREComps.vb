Public Class frmImportREComps
    Private bActivated As Boolean
    Private iNumberOfColumns As Integer
    Private lImportRowCount As Long
    Private sImportedTableName As String
    Private sImportFile As String
    Private Const ACCTNUM As String = "Account"
    Private Const IMPROVEVAL As String = "Improvment Value"
    Private Const IMPROVEVALSQFT As String = "Improvement Value/Sq Ft"
    Private Const LANDVALUE As String = "Land Value"
    Private Const LANDVALUESQFT As String = "Land Value/Sq Ft"
    Private Const TOTALVALUE As String = "Total Value"
    Private Const TOTALVALUESQFT As String = "Total Value/Sq Ft"
    Private Const TOTALVALUEUNIT As String = "Total Value/Unit"
    Private Const BUILDINGSQFT As String = "Building Sq Ft"
    Private Const LANDSQFT As String = "Land Sq Ft"
    Private Const NUMBEROFUNITS As String = "Number of Units"
    Private Const YEARBUILT As String = "Year Built"
    Private Const BUILDINGCLASS As String = "Building Class"
    Private Const COMPCODE As String = "Comparability Code"
    Private Const ECONOMICAREA As String = "Economic Area"
    Private Const LANDMARKETAREA As String = "Land Market Area"
    Private Const IMPROVEMARKETAREA As String = "Improvement Market Area"
    Private Const MAPSCO As String = "Mapsco"
    Private Const NEIGHBORGROUP As String = "Neighborhood Group"
    Private Const STREETNUMBER As String = "Street Number"
    Private Const STREETNAME As String = "Street Name"
    Private Const BUSINESSNAME As String = "Business Name"
    Private Const LANDBLDGRATIO As String = "Land/Bldg Ratio"
    Private Const CONSTRUCTIONTYPE As String = "Construction Type"
    Private Const EFFECTIVEYEAR As String = "Effective Year"
    Private Const APPRAISALMETHOD As String = "Appraisal Method"
    Private Const PRICINGMETHOD As String = "Pricing Method"
    Private Enum ErrorType
        NoError = 0
        BadData = 2
    End Enum

    Public Property AssessorId() As Long
    Public Property AssessorName() As String

    Private Function RefreshData() As Boolean
        Dim sSQL As String = "", lRows As Long = 0
        Dim dt As New DataTable

        Try
            Randomize()
            Do
                Dim sRandom As String = CStr(Format(Rnd() * 1000000, "0"))
                sImportedTableName = "#tmpIRECOMPBI_" & sRandom
                sSQL = "SELECT 1 WHERE EXISTS (SELECT Name FROM sys.objects where name LIKE '%" & sRandom & "%')"
                lRows = GetData(sSQL, dt)
                If lRows = 0 Then Exit Do
            Loop
            Me.Text = "Importing comps for " & AssessorName

            Return True
        Catch ex As Exception
            MsgBox("Error in RefreshData:  " & ex.Message)
            Return False
        End Try
    End Function

    Private Sub frmImportREComps_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If bActivated Then Exit Sub
        lblTotals.Text = ""
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
        cboAccount.Items.Clear()
        cboAccount.Items.Add("")
        cboImprovementValue.Items.Clear()
        cboImprovementValue.Items.Add("")
        cboImprovementValueSqFt.Items.Clear()
        cboImprovementValueSqFt.Items.Add("")
        cboLandValue.Items.Clear()
        cboLandValue.Items.Add("")
        cboLandSqFt.Items.Clear()
        cboLandSqFt.Items.Add("")
        cboLandValueSqFt.Items.Clear()
        cboLandValueSqFt.Items.Add("")
        cboTotalValue.Items.Clear()
        cboTotalValue.Items.Add("")
        cboTotalValueSqFt.Items.Clear()
        cboTotalValueSqFt.Items.Add("")
        cboBuildingClass.Items.Clear()
        cboBuildingClass.Items.Add("")
        cboBuildingSqFt.Items.Clear()
        cboBuildingSqFt.Items.Add("")
        cboBusinessName.Items.Clear()
        cboBusinessName.Items.Add("")
        cboCompCode.Items.Clear()
        cboCompCode.Items.Add("")
        cboEconomicArea.Items.Clear()
        cboEconomicArea.Items.Add("")
        cboImprovementMarketArea.Items.Clear()
        cboImprovementMarketArea.Items.Add("")
        cboImprovementValue.Items.Clear()
        cboImprovementValue.Items.Add("")
        cboImprovementValueSqFt.Items.Clear()
        cboImprovementValueSqFt.Items.Add("")
        cboLandBldgRatio.Items.Clear()
        cboLandBldgRatio.Items.Add("")
        cboLandMarketArea.Items.Clear()
        cboLandMarketArea.Items.Add("")
        cboMapsco.Items.Clear()
        cboMapsco.Items.Add("")
        cboNeighborhoodGroup.Items.Clear()
        cboNeighborhoodGroup.Items.Add("")
        cboNumberOfUnits.Items.Clear()
        cboNumberOfUnits.Items.Add("")
        cboStreetNumber.Items.Clear()
        cboStreetNumber.Items.Add("")
        cboStreet.Items.Clear()
        cboStreet.Items.Add("")
        cboTotalValueUnit.Items.Clear()
        cboTotalValueUnit.Items.Add("")
        cboYearBuilt.Items.Clear()
        cboYearBuilt.Items.Add("")
        cboConstructionType.Items.Clear()
        cboConstructionType.Items.Add("")
        cboEffectiveYear.Items.Clear()
        cboEffectiveYear.Items.Add("")
        cboAppraisalMethod.Items.Clear()
        cboAppraisalMethod.Items.Add("")
        cboPricingMethod.Items.Clear()
        cboPricingMethod.Items.Add("")

        txtFile.Text = ""
        If Not modMain.ImportFile(vFileContents, sImportFile, 500) Then Exit Function
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
            cboAccount.Items.Add(lColumn)
            cboBuildingClass.Items.Add(lColumn)
            cboBuildingSqFt.Items.Add(lColumn)
            cboBusinessName.Items.Add(lColumn)
            cboCompCode.Items.Add(lColumn)
            cboEconomicArea.Items.Add(lColumn)
            cboImprovementMarketArea.Items.Add(lColumn)
            cboImprovementValue.Items.Add(lColumn)
            cboImprovementValueSqFt.Items.Add(lColumn)
            cboLandBldgRatio.Items.Add(lColumn)
            cboLandMarketArea.Items.Add(lColumn)
            cboLandSqFt.Items.Add(lColumn)
            cboLandValue.Items.Add(lColumn)
            cboLandValueSqFt.Items.Add(lColumn)
            cboMapsco.Items.Add(lColumn)
            cboNeighborhoodGroup.Items.Add(lColumn)
            cboNumberOfUnits.Items.Add(lColumn)
            cboStreetNumber.Items.Add(lColumn)
            cboStreet.Items.Add(lColumn)
            cboTotalValue.Items.Add(lColumn)
            cboTotalValueSqFt.Items.Add(lColumn)
            cboTotalValueUnit.Items.Add(lColumn)
            cboYearBuilt.Items.Add(lColumn)
            cboConstructionType.Items.Add(lColumn)
            cboEffectiveYear.Items.Add(lColumn)
            cboAppraisalMethod.Items.Add(lColumn)
            cboPricingMethod.Items.Add(lColumn)
        Next
        Return True
    End Function

    Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdFinish_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdFinish.Click
        Dim sError As String = ""

        MDIParent1.ShowStatus("Saving data")
        Me.Cursor = Cursors.WaitCursor
        InsertComps(sError)
        MDIParent1.ShowStatus()
        Me.Cursor = Cursors.Default
        If sError = "" Then
            MsgBox("Import complete")
            Me.Close()
        Else
            MsgBox("Error importing:  " & sError)
        End If
    End Sub
    Private Function ValidateInput() As Boolean
        Try
            If cboStreet.Text = "" And cboStreetNumber.Text <> "" Then
                MsgBox("Street must be defined")
                Return False
            End If
            Return True
        Catch ex As Exception
            MsgBox("Error validating:  " & ex.Message)
            Return False
        End Try
    End Function
    Private Function InsertComps(ByRef sError As String) As Boolean
        Try
            Dim sSQL As New StringBuilder, dt As New DataTable, col As DataColumn, sIN As String = "", row As DataRow
            Dim sInsert As New StringBuilder, sSelect As New StringBuilder
            Dim bHaveBuildingClass As Boolean = False, bHaveCompCode As Boolean = False
            Dim bHaveConstructionType As Boolean = False, bHaveAppraisalMethod As Boolean = False, bHavePricingMethod As Boolean = False
            Dim bHaveBldgSqFt As Boolean = False, bHaveLandSqFt As Boolean = False
            Dim bHaveImproveValue As Boolean = False, bHaveLandValue As Boolean = False
            Dim bHaveImproveValueSqFt As Boolean = False, bHaveLandValueSqFt As Boolean = False
            Dim bHaveNumberOfUnits As Boolean = False, bHaveTotalValuePerUnit As Boolean = False
            Dim bHaveTotalValue As Boolean = False, bHaveTotalValueSqFt As Boolean = False

            'get list of fields that will be imported
            sSQL.Length = 0
            sSQL.Append("SELECT * FROM " & sImportedTableName & " WHERE 0 = 1")         'just want the fields  (can't do a sys query on temp table)
            GetData(sSQL.ToString, dt)
            sIN = ""
            For Each col In dt.Columns
                If sIN <> "" Then sIN = sIN & ","
                sIN = sIN & QuoStr(col.ColumnName)
            Next
            sSQL.Length = 0
            sSQL.Append("SELECT c.name AS FieldName FROM sys.sysobjects AS o INNER JOIN sys.syscolumns AS c ON o.id = c.id")
            sSQL.Append(" WHERE o.type = 'U' AND o.name = 'REComps' AND c.name IN(").Append(sIN).Append(")")
            GetData(sSQL.ToString, dt)
            'build up insert statement
            sInsert.Length = 0 : sSelect.Length = 0
            sInsert.Append("INSERT REComps (AssessorId,TaxYear,AddUser")
            sSelect.Append(" SELECT ").Append(AssessorId.ToString).Append(",").Append(AppData.TaxYear.ToString).Append(",").Append(QuoStr(AppData.UserId))
            For Each row In dt.Rows
                sInsert.Append(",").Append(row(0).ToString)
                Select Case row(0).ToString
                    Case "AcctNum", "BuildingClass", "ComparabilityCode", "EconomicArea", "LandMarketArea", "ImprovementMarketArea", "Mapsco",
                                "NeighborhoodGroup", "StreetName", "ConstructionType", "AppraisalMethod", "PricingMethod"
                        sSelect.Append(",").Append(" LTRIM(RTRIM(ISNULL(").Append(row(0).ToString).Append(",'')))")
                    Case "BusinessName"
                        sSelect.Append(",").Append("SUBSTRING(LTRIM(RTRIM(ISNULL(").Append(row(0).ToString).Append(",''))),1,255)")
                    Case "LandValuePerSqFt", "ImprovementValuePerSqFt", "TotalValuePerSqFt", "TotalValuePerUnit", "LandBuildingRatio"
                        sSelect.Append(",").Append("ROUND(CONVERT(float,ISNULL(").Append(row(0).ToString).Append(",'0')),2)")
                    Case Else
                        sSelect.Append(",").Append("ROUND(CONVERT(float,ISNULL(").Append(row(0).ToString).Append(",'0')),0)")
                End Select
                If row(0).ToString = "BuildingClass" Then bHaveBuildingClass = True
                If row(0).ToString = "ComparabilityCode" Then bHaveCompCode = True
                If row(0).ToString = "ConstructionType" Then bHaveConstructionType = True
                If row(0).ToString = "AppraisalMethod" Then bHaveAppraisalMethod = True
                If row(0).ToString = "PricingMethod" Then bHavePricingMethod = True
                If row(0).ToString = "BuildingSqFt" Then bHaveBldgSqFt = True
                If row(0).ToString = "LandSqFt" Then bHaveLandSqFt = True
                If row(0).ToString = "ImprovementValue" Then bHaveImproveValue = True
                If row(0).ToString = "LandValue" Then bHaveLandValue = True
                If row(0).ToString = "ImprovementValuePerSqFt" Then bHaveImproveValueSqFt = True
                If row(0).ToString = "NumberOfUnits" Then bHaveNumberOfUnits = True
                If row(0).ToString = "TotalValuePerUnit" Then bHaveTotalValuePerUnit = True
                If row(0).ToString = "TotalValue" Then bHaveTotalValue = True
                If row(0).ToString = "TotalValuePerSqFt" Then bHaveTotalValueSqFt = True
                If row(0).ToString = "LandValuePerSqFt" Then bHaveLandValueSqFt = True
            Next

            If bHaveImproveValueSqFt = False And bHaveBldgSqFt And bHaveImproveValue Then
                sInsert.Append(",ImprovementValuePerSqFt")
                sSelect.Append(",CASE WHEN ROUND(CONVERT(float,ISNULL(BuildingSqFt,'0')),0) > 0 THEN ROUND(ROUND(CONVERT(float,ISNULL(ImprovementValue,'0')),0) / ROUND(CONVERT(float,ISNULL(BuildingSqFt,'0')),0),2) ELSE 0 END")
            End If
            If bHaveLandValueSqFt = False And bHaveLandSqFt And bHaveLandValue Then
                sInsert.Append(",LandValuePerSqFt")
                sSelect.Append(",CASE WHEN ROUND(CONVERT(float,ISNULL(LandSqFt,'0')),0) > 0 THEN ROUND(ROUND(CONVERT(float,ISNULL(LandValue,'0')),0) / ROUND(CONVERT(float,ISNULL(LandSqFt,'0')),0),2) ELSE 0 END")
            End If
            If bHaveTotalValuePerUnit = False And bHaveNumberOfUnits And bHaveTotalValue Then
                sInsert.Append(",TotalValuePerUnit")
                sSelect.Append(",CASE WHEN ROUND(CONVERT(float,ISNULL(NumberOfUnits,'0')),0) > 0 THEN ROUND(ROUND(CONVERT(float,ISNULL(TotalValue,'0')),0) / ROUND(CONVERT(float,ISNULL(NumberOfUnits,'0')),0),2) ELSE 0 END")
            End If
            If bHaveTotalValueSqFt = False Then
                If bHaveBldgSqFt And bHaveLandSqFt Then
                    If bHaveTotalValue Then
                        sInsert.Append(",TotalValuePerSqFt")
                        sSelect.Append(",CASE WHEN ROUND(CONVERT(float,ISNULL(BuildingSqFt,'0')),0) > 0 THEN ROUND(ROUND(CONVERT(float,ISNULL(TotalValue,'0')),0) / (ROUND(CONVERT(float,ISNULL(BuildingSqFt,'0')),0)),2) ELSE 0 END")
                    Else
                        If bHaveLandValue And bHaveImproveValue Then
                            sInsert.Append(",TotalValuePerSqFt")
                            sSelect.Append(",CASE WHEN ROUND(CONVERT(float,ISNULL(BuildingSqFt,'0')),0) > 0 THEN ROUND(ROUND(CONVERT(float,ISNULL(LandValue,'0')) + CONVERT(float,ISNULL(ImprovementValue,'0')),0) / (ROUND(CONVERT(float,ISNULL(BuildingSqFt,'0')),0)),2) ELSE 0 END")
                        End If
                    End If
                End If
            End If

            sInsert.Append(")")
            sSelect.Append(" FROM ").Append(sImportedTableName)

            ExecuteSQL("begin transaction")
            If RunCompsInsert(sInsert.ToString, sSelect.ToString, bHaveBuildingClass, bHaveCompCode, bHaveConstructionType, bHaveAppraisalMethod, bHavePricingMethod, sError) Then
                ExecuteSQL("commit transaction")
            Else
                Try
                    ExecuteSQL("rollback transaction")
                Catch ex As Exception
                End Try
                MsgBox("Error importing:  " & sError)
                Return False
            End If
            Return True
        Catch ex As Exception
            sError = ex.Message
            Return False
        End Try
    End Function
    Private Function RunCompsInsert(sInsert As String, sSelect As String, bHaveBuildingClass As Boolean, bHaveCompCode As Boolean,
            bHaveConstructionType As Boolean, bHaveAppraisalMethod As Boolean, bHavePricingMethod As Boolean, ByRef sError As String) As Boolean
        Try
            Dim sSQL As New StringBuilder

            ''ExecuteSQL("DELETE RECompCodes WHERE AssessorId = " & AssessorId & " AND TaxYear = " & AppData.TaxYear)
            ExecuteSQL("DELETE REComps WHERE AssessorId = " & AssessorId & " AND TaxYear = " & AppData.TaxYear)
            sSQL.Length = 0
            sSQL.Append(sInsert).Append(" ").Append(sSelect)
            ExecuteSQL(sSQL.ToString)

            sSQL.Clear()
            sSQL.Append("EXEC spUpdateRECompCodes")
            sSQL.Append(" @AssessorId=").Append(AssessorId).Append(",@TaxYear=").Append(AppData.TaxYear).Append(",@AddUser=").Append(QuoStr(AppData.UserId))
            ExecuteSQL(sSQL.ToString)


            'If bHaveBuildingClass Then
            '    sSQL.Length = 0
            '    sSQL.Append("INSERT RECompCodes (AssessorId,TaxYear,CodeValue,FieldName,AddUser)")
            '    sSQL.Append(" SELECT AssessorId, TaxYear, BuildingClass, 'BuildingClass',").Append(QuoStr(AppData.UserId)).Append(" FROM REComps")
            '    sSQL.Append(" GROUP BY AssessorId, TaxYear, BuildingClass")
            '    sSQL.Append(" HAVING AssessorId = ").Append(AssessorId).Append(" AND TaxYear = ").Append(AppData.TaxYear)
            '    ExecuteSQL(sSQL.ToString)
            'End If
            'If bHaveCompCode Then
            '    sSQL.Length = 0
            '    sSQL.Append("INSERT RECompCodes (AssessorId,TaxYear,CodeValue,FieldName,AddUser)")
            '    sSQL.Append(" SELECT AssessorId, TaxYear, ComparabilityCode, 'ComparabilityCode',").Append(QuoStr(AppData.UserId)).Append(" FROM REComps")
            '    sSQL.Append(" GROUP BY AssessorId, TaxYear, ComparabilityCode")
            '    sSQL.Append(" HAVING AssessorId = ").Append(AssessorId).Append(" AND TaxYear = ").Append(AppData.TaxYear)
            '    ExecuteSQL(sSQL.ToString)
            'End If
            'If bHaveConstructionType Then
            '    sSQL.Length = 0
            '    sSQL.Append("INSERT RECompCodes (AssessorId,TaxYear,CodeValue,FieldName,AddUser)")
            '    sSQL.Append(" SELECT AssessorId, TaxYear, ConstructionType, 'ConstructionType',").Append(QuoStr(AppData.UserId)).Append(" FROM REComps")
            '    sSQL.Append(" GROUP BY AssessorId, TaxYear, ConstructionType")
            '    sSQL.Append(" HAVING AssessorId = ").Append(AssessorId).Append(" AND TaxYear = ").Append(AppData.TaxYear)
            '    ExecuteSQL(sSQL.ToString)
            'End If
            'If bHaveAppraisalMethod Then
            '    sSQL.Length = 0
            '    sSQL.Append("INSERT RECompCodes (AssessorId,TaxYear,CodeValue,FieldName,AddUser)")
            '    sSQL.Append(" SELECT AssessorId, TaxYear, AppraisalMethod, 'AppraisalMethod',").Append(QuoStr(AppData.UserId)).Append(" FROM REComps")
            '    sSQL.Append(" GROUP BY AssessorId, TaxYear, AppraisalMethod")
            '    sSQL.Append(" HAVING AssessorId = ").Append(AssessorId).Append(" AND TaxYear = ").Append(AppData.TaxYear)
            '    ExecuteSQL(sSQL.ToString)
            'End If
            'If bHavePricingMethod Then
            '    sSQL.Length = 0
            '    sSQL.Append("INSERT RECompCodes (AssessorId,TaxYear,CodeValue,FieldName,AddUser)")
            '    sSQL.Append(" SELECT AssessorId, TaxYear, PricingMethod, 'PricingMethod',").Append(QuoStr(AppData.UserId)).Append(" FROM REComps")
            '    sSQL.Append(" GROUP BY AssessorId, TaxYear, PricingMethod")
            '    sSQL.Append(" HAVING AssessorId = ").Append(AssessorId).Append(" AND TaxYear = ").Append(AppData.TaxYear)
            '    ExecuteSQL(sSQL.ToString)
            'End If

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
            cmdFinish.Enabled = False
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
        ElseIf fraColumns.Visible Then
            If ValidateInput() = False Then Exit Sub
            fraColumns.Visible = False
            MDIParent1.ShowStatus("Loading comps")
            Me.Cursor = Cursors.WaitCursor
            LoadFileIntoDB()
            MDIParent1.ShowStatus()
            Me.Cursor = Cursors.Default
            fraResults.Visible = True
            cmdNext.Enabled = False
            cmdFinish.Enabled = True
        End If

    End Sub

    Private Sub cboAccount_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles cboImprovementValue.TextChanged, cboImprovementValueSqFt.TextChanged, cboLandValue.TextChanged,
            cboLandValueSqFt.TextChanged, cboTotalValue.TextChanged, cboAccount.TextChanged,
            cboTotalValueSqFt.TextChanged, cboTotalValueUnit.TextChanged, cboBuildingSqFt.TextChanged, cboLandSqFt.TextChanged,
            cboNumberOfUnits.TextChanged, cboYearBuilt.TextChanged, cboBuildingClass.TextChanged, cboCompCode.TextChanged,
            cboEconomicArea.TextChanged, cboLandMarketArea.TextChanged, cboImprovementMarketArea.TextChanged,
            cboMapsco.TextChanged, cboNeighborhoodGroup.TextChanged, cboStreetNumber.TextChanged, cboStreet.TextChanged, cboBusinessName.TextChanged,
            cboLandBldgRatio.TextChanged, cboConstructionType.TextChanged, cboEffectiveYear.TextChanged, cboAppraisalMethod.TextChanged, cboPricingMethod.TextChanged
        If Trim(sender.text) = "" Or (Val(sender.text) >= 1 And Val(sender.text) <= iNumberOfColumns) Then
            RenameColumns()
        End If
    End Sub
    Private Sub RenameColumns()
        Dim iColumn As Integer, i As Integer

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = ACCTNUM Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboAccount.Text) <> "" Then
            iColumn = Val(cboAccount.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = ACCTNUM
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = IMPROVEVAL Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboImprovementValue.Text) <> "" Then
            iColumn = Val(cboImprovementValue.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = IMPROVEVAL
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = IMPROVEVALSQFT Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboImprovementValueSqFt.Text) <> "" Then
            iColumn = Val(cboImprovementValueSqFt.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = IMPROVEVALSQFT
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = LANDVALUE Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboLandValue.Text) <> "" Then
            iColumn = Val(cboLandValue.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = LANDVALUE
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = LANDVALUESQFT Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboLandValueSqFt.Text) <> "" Then
            iColumn = Val(cboLandValueSqFt.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = LANDVALUESQFT
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = TOTALVALUE Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboTotalValue.Text) <> "" Then
            iColumn = Val(cboTotalValue.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = TOTALVALUE
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = TOTALVALUESQFT Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboTotalValueSqFt.Text) <> "" Then
            iColumn = Val(cboTotalValueSqFt.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = TOTALVALUESQFT
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = TOTALVALUEUNIT Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboTotalValueUnit.Text) <> "" Then
            iColumn = Val(cboTotalValueUnit.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = TOTALVALUEUNIT
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = BUILDINGSQFT Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboBuildingSqFt.Text) <> "" Then
            iColumn = Val(cboBuildingSqFt.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = BUILDINGSQFT
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = LANDSQFT Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboLandSqFt.Text) <> "" Then
            iColumn = Val(cboLandSqFt.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = LANDSQFT
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = NUMBEROFUNITS Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboNumberOfUnits.Text) <> "" Then
            iColumn = Val(cboNumberOfUnits.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = NUMBEROFUNITS
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = YEARBUILT Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboYearBuilt.Text) <> "" Then
            iColumn = Val(cboYearBuilt.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = YEARBUILT
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = BUILDINGCLASS Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboBuildingClass.Text) <> "" Then
            iColumn = Val(cboBuildingClass.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = BUILDINGCLASS
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = COMPCODE Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboCompCode.Text) <> "" Then
            iColumn = Val(cboCompCode.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = COMPCODE
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = ECONOMICAREA Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboEconomicArea.Text) <> "" Then
            iColumn = Val(cboEconomicArea.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = ECONOMICAREA
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = LANDMARKETAREA Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboLandMarketArea.Text) <> "" Then
            iColumn = Val(cboLandMarketArea.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = LANDMARKETAREA
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = IMPROVEMARKETAREA Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboImprovementMarketArea.Text) <> "" Then
            iColumn = Val(cboImprovementMarketArea.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = IMPROVEMARKETAREA
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = MAPSCO Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboMapsco.Text) <> "" Then
            iColumn = Val(cboMapsco.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = MAPSCO
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = NEIGHBORGROUP Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboNeighborhoodGroup.Text) <> "" Then
            iColumn = Val(cboNeighborhoodGroup.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = NEIGHBORGROUP
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = STREETNUMBER Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboStreetNumber.Text) <> "" Then
            iColumn = Val(cboStreetNumber.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = STREETNUMBER
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = STREETNAME Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboStreet.Text) <> "" Then
            iColumn = Val(cboStreet.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = STREETNAME
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = BUSINESSNAME Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboBusinessName.Text) <> "" Then
            iColumn = Val(cboBusinessName.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = BUSINESSNAME
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = LANDBLDGRATIO Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboLandBldgRatio.Text) <> "" Then
            iColumn = Val(cboLandBldgRatio.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = LANDBLDGRATIO
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = CONSTRUCTIONTYPE Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboConstructionType.Text) <> "" Then
            iColumn = Val(cboConstructionType.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = CONSTRUCTIONTYPE
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = EFFECTIVEYEAR Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboEffectiveYear.Text) <> "" Then
            iColumn = Val(cboEffectiveYear.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = EFFECTIVEYEAR
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = APPRAISALMETHOD Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboAPPRAISALMETHOD.Text) <> "" Then
            iColumn = Val(cboAPPRAISALMETHOD.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = APPRAISALMETHOD
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = PRICINGMETHOD Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboPricingMethod.Text) <> "" Then
            iColumn = Val(cboPricingMethod.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = PRICINGMETHOD
        End If

    End Sub

    Private Sub cmdBrowse_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdBrowse.Click
        MDIParent1.ShowStatus("Loading file")
        Me.Cursor = Cursors.WaitCursor
        If ImportFile() Then cmdNext.Enabled = True
        MDIParent1.ShowStatus()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub frmImportREComps_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            ExecuteSQL("drop table " & sImportedTableName)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frmImportREComps_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fraColumns.Left = fraFile.Left
        fraColumns.Top = fraFile.Top
        fraResults.Left = fraFile.Left
        fraResults.Top = fraFile.Top
    End Sub

    Private Sub frmImportREComps_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Dim Buttons(3) As Control

        Buttons(0) = cmdBack
        Buttons(1) = cmdNext
        Buttons(2) = cmdFinish
        Buttons(3) = cmdCancel
        PlaceButtons(Me, Buttons)

        If Me.WindowState = FormWindowState.Minimized Then Exit Sub
        fraFile.Width = Me.Width - 30
        fraFile.Height = Me.Height - 80
        fraColumns.Width = fraFile.Width
        fraColumns.Height = fraFile.Height
        fraResults.Width = fraFile.Width
        fraResults.Height = fraFile.Height
        dgFileContents.Width = fraColumns.Width - 10
        dgFileContents.Height = fraColumns.Height - dgFileContents.Top - 5

    End Sub
    Private Function LoadFileIntoDB() As Boolean
        Dim hasstreetnumber As Boolean = False
        lblTotals.Text = ""
        Try
            ExecuteSQL("DROP TABLE " & sImportedTableName)
        Catch ex As Exception
        End Try

        Try
            Dim lRows As Long, sSQL As String = "", sField As String = ""
            Dim iCol As Integer = 0
            sSQL = ""
            For iCol = 0 To dgFileContents.ColumnCount - 1
                If sSQL <> "" Then sSQL = sSQL & ","
                Select Case dgFileContents.Columns(iCol).HeaderText
                    Case ACCTNUM
                        sField = "AcctNum"
                    Case IMPROVEVAL
                        sField = "ImprovementValue"
                    Case LANDVALUE
                        sField = "LandValue"
                    Case BUILDINGSQFT
                        sField = "BuildingSqFt"
                    Case LANDSQFT
                        sField = "LandSqFt"
                    Case NUMBEROFUNITS
                        sField = "NumberOfUnits"
                    Case YEARBUILT
                        sField = "YearBuilt"
                    Case BUILDINGCLASS
                        sField = "BuildingClass"
                    Case COMPCODE
                        sField = "ComparabilityCode"
                    Case ECONOMICAREA
                        sField = "EconomicArea"
                    Case LANDMARKETAREA
                        sField = "LandMarketArea"
                    Case IMPROVEMARKETAREA
                        sField = "ImprovementMarketArea"
                    Case MAPSCO
                        sField = "Mapsco"
                    Case NEIGHBORGROUP
                        sField = "NeighborhoodGroup"
                    Case STREETNUMBER
                        sField = "StreetNumber"
                        hasstreetnumber = True
                    Case STREETNAME
                        sField = "StreetName"
                    Case BUSINESSNAME
                        sField = "BusinessName"
                    Case LANDBLDGRATIO
                        sField = "LandBuildingRatio"
                    Case TOTALVALUE
                        sField = "TotalValue"
                    Case LANDVALUESQFT
                        sField = "LandValuePerSqFt"
                    Case IMPROVEVALSQFT
                        sField = "ImprovementValuePerSqFt"
                    Case TOTALVALUESQFT
                        sField = "TotalValuePerSqFt"
                    Case TOTALVALUEUNIT
                        sField = "TotalValuePerUnit"
                    Case CONSTRUCTIONTYPE
                        sField = "ConstructionType"
                    Case EFFECTIVEYEAR
                        sField = "EffectiveYear"
                    Case APPRAISALMETHOD
                        sField = "AppraisalMethod"
                    Case PRICINGMETHOD
                        sField = "PricingMethod"
                    Case Else
                        sField = "Column" & iCol
                End Select
                sSQL = sSQL & sField & " varchar(255)"
            Next
            'sSQL = sSQL & ", IDField [bigint] IDENTITY(1,1) "
            sSQL = "CREATE TABLE " & sImportedTableName & " (" & sSQL & ")"
            ExecuteSQL(sSQL)

            sSQL = "BULK INSERT " & sImportedTableName & " FROM " & QuoStr(sImportFile) &
                " WITH (ROWTERMINATOR = '\n', FIELDTERMINATOR ='\t', FIRSTROW=" & IIf(chkFirstRow.Checked, "2", "1") & ")"
            lRows = ExecuteSQL(sSQL)

            If hasstreetnumber Then
                sSQL = "UPDATE " & sImportedTableName & " SET StreetName = LTRIM(RTRIM(StreetNumber)) + ' ' + LTRIM(RTRIM(StreetName)) WHERE LTRIM(RTRIM(StreetNumber)) <> ''"
                ExecuteSQL(sSQL)
            End If

            lblTotals.Text = lRows.ToString("#,##0") & " rows loaded"

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
