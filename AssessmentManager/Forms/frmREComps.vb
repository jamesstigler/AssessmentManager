Public Class frmREComps
    Private Enum enumRECompCodes
        enumBldgClass
        enumCompCode
        enumConstructionType
        enumAppraisalMethod
        enumPricingMethod
    End Enum

    Private colAssessors As Collection
    Private eListOfCodes As enumRECompCodes
    Private sSearchSQL As String
    Private dtResults As DataTable

    Private Sub cmdClose_Click(sender As Object, e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub frmREComps_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Try
            Dim dt As New DataTable, dr As DataRow
            Dim sSQL As New StringBuilder
            sSQL.Length = 0
            sSQL.Append("SELECT RTRIM(LTRIM(a.Name)) + ', ' + a.StateCd AS AssessorName, a.AssessorId")
            sSQL.Append(" FROM Assessors AS a INNER JOIN REComps AS r ON a.AssessorId = r.AssessorId AND a.TaxYear = r.TaxYear")
            sSQL.Append(" WHERE r.TaxYear = ").Append(AppData.TaxYear.ToString).Append(" GROUP BY RTRIM(LTRIM(a.Name)) + ', ' + a.StateCd, a.AssessorId, a.Name, a.StateCd")
            sSQL.Append(" ORDER BY a.Name, a.StateCd")

            colAssessors = New Collection
            GetData(sSQL.ToString, dt)
            For Each dr In dt.Rows
                cboAssessor.Items.Add(dr("AssessorName"))
                colAssessors.Add(dr("AssessorId").ToString, dr("AssessorName").ToString)
            Next
        Catch ex As Exception
            MsgBox("Error loading assessors:  " & ex.Message)
        End Try
    End Sub

    Private Sub cmdSearch_Click(sender As Object, e As System.EventArgs) Handles cmdSearch.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            LoadResults()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
        End Try
    End Sub
    Private Sub LoadResults()
        Try
            Dim lRows As Long = 0, lRowsCalc As Long = 0, sSELECT As New StringBuilder, sWHERE As New StringBuilder
            Dim bind As New BindingSource, sORDERBY As New StringBuilder, row As DataRow
            Dim i As Integer
            Dim lTotalLandValue As Long, lTotalImproveValue As Long, lTotalValue As Long, lTotalLandFt As Long, lTotalImproveFt As Long, lTotalLandBldgRatio As Double
            Dim lTotalUnits As Long
            Dim dAVGLandValueSqFt As Double = 0, dAVGImproveValSqFt As Double = 0, dAVGTotalValueSqFt As Double = 0, dAVGTotalValueUnit As Double = 0, dAVGLandBldgRatio As Double = 0
            Dim sCode As String
            Dim sIN As String
            Static bGridFormatted As Boolean = False

            dtResults = New DataTable
            cmdPrint.Enabled = False
            txtCount.Text = "" : sSELECT.Length = 0 : sWHERE.Length = 0
            sWHERE.Append(" WHERE AssessorId = ").Append(colAssessors(cboAssessor.Text)).Append(" AND TaxYear = ").Append(AppData.TaxYear)
            If txtImprovementValueFrom.Text <> "" And txtImprovementValueTo.Text <> "" Then
                sWHERE.Append(" AND ImprovementValue BETWEEN " & txtImprovementValueFrom.Text & " AND " & txtImprovementValueTo.Text)
            End If
            If txtImprovementValueSqFtFrom.Text <> "" And txtImprovementValueSqFtTo.Text <> "" Then
                sWHERE.Append(" AND ImprovementValuePerSqFt BETWEEN " & txtImprovementValueSqFtFrom.Text & " AND " & txtImprovementValueSqFtTo.Text)
            End If
            If txtLandSqFtFrom.Text <> "" And txtLandSqFtTo.Text <> "" Then
                sWHERE.Append(" AND LandSqFt BETWEEN " & txtLandSqFtFrom.Text & " AND " & txtLandSqFtTo.Text)
            End If
            If txtLandValueFrom.Text <> "" And txtLandValueTo.Text <> "" Then
                sWHERE.Append(" AND LandValue BETWEEN " & txtLandValueFrom.Text & " AND " & txtLandValueTo.Text)
            End If
            If txtLandValueSqFtFrom.Text <> "" And txtLandValueSqFtTo.Text <> "" Then
                sWHERE.Append(" AND LandValuePerSqFt BETWEEN " & txtLandValueSqFtFrom.Text & " AND " & txtLandValueSqFtTo.Text)
            End If
            If txtNumberUnitsFrom.Text <> "" And txtNumberUnitsTo.Text <> "" Then
                sWHERE.Append(" AND NumberOfUnits BETWEEN " & txtNumberUnitsFrom.Text & " AND " & txtNumberUnitsTo.Text)
            End If
            If txtTotalValueFrom.Text <> "" And txtTotalValueTo.Text <> "" Then
                sWHERE.Append(" AND TotalValue BETWEEN " & txtTotalValueFrom.Text & " AND " & txtTotalValueTo.Text)
            End If
            If txtTotalValueSqFtFrom.Text <> "" And txtTotalValueSqFtTo.Text <> "" Then
                sWHERE.Append(" AND TotalValuePerSqFt BETWEEN " & txtTotalValueSqFtFrom.Text & " AND " & txtTotalValueSqFtTo.Text)
            End If
            If txtTotalValueUnitFrom.Text <> "" And txtTotalValueUnitTo.Text <> "" Then
                sWHERE.Append(" AND TotalValuePerUnit BETWEEN " & txtTotalValueUnitFrom.Text & " AND " & txtTotalValueUnitTo.Text)
            End If
            If txtBldgSqFtFrom.Text <> "" And txtBldgSqFtTo.Text <> "" Then
                sWHERE.Append(" AND BuildingSqFt BETWEEN " & txtBldgSqFtFrom.Text & " AND " & txtBldgSqFtTo.Text)
            End If
            If txtYearBuiltFrom.Text <> "" And txtYearBuiltTo.Text <> "" Then
                sWHERE.Append(" AND YearBuilt BETWEEN " & txtYearBuiltFrom.Text & " AND " & txtYearBuiltTo.Text)
            End If
            If txtEffectiveYearFrom.Text <> "" And txtEffectiveYearTo.Text <> "" Then
                sWHERE.Append(" AND EffectiveYear BETWEEN " & txtEffectiveYearFrom.Text & " AND " & txtEffectiveYearTo.Text)
            End If

            If listBuildingClass.SelectedItems.Count > 0 Then
                sIN = ""
                For Each sCode In listBuildingClass.SelectedItems
                    If sIN <> "" Then sIN = sIN & ","
                    sIN = sIN & QuoStr(sCode)
                Next
                sWHERE.Append(" AND BuildingClass IN(" & sIN & ")")
            End If
            If listCompCode.SelectedItems.Count > 0 Then
                sIN = ""
                For Each sCode In listCompCode.SelectedItems
                    If sIN <> "" Then sIN = sIN & ","
                    sIN = sIN & QuoStr(sCode)
                Next
                sWHERE.Append(" AND ComparabilityCode IN(" & sIN & ")")
            End If
            If listConstructionType.SelectedItems.Count > 0 Then
                sIN = ""
                For Each sCode In listConstructionType.SelectedItems
                    If sIN <> "" Then sIN = sIN & ","
                    sIN = sIN & QuoStr(sCode)
                Next
                sWHERE.Append(" AND ConstructionType IN(" & sIN & ")")
            End If
            If listAppraisalMethod.SelectedItems.Count > 0 Then
                sIN = ""
                For Each sCode In listAppraisalMethod.SelectedItems
                    If sIN <> "" Then sIN = sIN & ","
                    sIN = sIN & QuoStr(sCode)
                Next
                sWHERE.Append(" AND AppraisalMethod IN(" & sIN & ")")
            End If
            If listPricingMethod.SelectedItems.Count > 0 Then
                sIN = ""
                For Each sCode In listPricingMethod.SelectedItems
                    If sIN <> "" Then sIN = sIN & ","
                    sIN = sIN & QuoStr(sCode)
                Next
                sWHERE.Append(" AND PricingMethod IN(" & sIN & ")")
            End If

            If txtEconomicArea.Text <> "" Then
                sWHERE.Append(" AND EconomicArea = " & QuoStr(txtEconomicArea.Text))
            End If
            If txtLandMarketArea.Text <> "" Then
                sWHERE.Append(" AND LandMarketArea = " & QuoStr(txtLandMarketArea.Text))
            End If
            If txtImprovementMarketArea.Text <> "" Then
                sWHERE.Append(" AND ImprovementMarketArea = " & QuoStr(txtImprovementMarketArea.Text))
            End If
            If txtMapsco.Text <> "" Then
                sWHERE.Append(" AND Mapsco = " & QuoStr(txtMapsco.Text))
            End If
            If txtNeighborhoodGroup.Text <> "" Then
                sWHERE.Append(" AND NeighborhoodGroup = " & QuoStr(txtNeighborhoodGroup.Text))
            End If
            If txtStreet.Text <> "" Then
                sWHERE.Append(" AND StreetName LIKE " & QuoStr(txtStreet.Text & "%"))
            End If
            If txtBusinessName.Text <> "" Then
                sWHERE.Append(" AND BusinessName LIKE " & QuoStr(txtBusinessName.Text & "%"))
            End If
            If txtLandBldgRatioFrom.Text <> "" And txtLandBldgRatioTo.Text <> "" Then
                sWHERE.Append(" AND LandBuildingRatio BETWEEN " & txtLandBldgRatioFrom.Text & " AND " & txtLandBldgRatioTo.Text)
            End If

            lRows = GetData("SELECT COUNT(AcctNum) FROM REComps " & sWHERE.ToString, dtResults)
            If lRows > 0 Then
                If Not IsDBNull(dtResults.Rows(0)(0)) Then
                    lRows = dtResults.Rows(0)(0)
                End If
            End If
            If lRows > 500 Then
                If MsgBox(lRows.ToString("#,##0") & " rows found.  Do you wish to continue?", MsgBoxStyle.YesNo) = vbNo Then
                    Exit Sub
                End If
            End If

            sSELECT.Length = 0
            For i = 0 To 1
                If sSELECT.Length > 0 Then sSELECT.Append(" UNION ")
                sSELECT.Append(" SELECT " & i & " AS SortField, AcctNum, StreetName, BusinessName, BuildingClass, ConstructionType, LandMarketArea,")
                sSELECT.Append(" ImprovementMarketArea, NeighborhoodGroup, EconomicArea, ComparabilityCode,")
                sSELECT.Append(" BuildingSqFt, LandSqFt, YearBuilt, EffectiveYear,")
                sSELECT.Append(" LandValue, ImprovementValue, TotalValue, LandValuePerSqFt, ImprovementValuePerSqFt, TotalValuePerSqFt, LandBuildingRatio,")
                sSELECT.Append(" NumberOfUnits, TotalValuePerUnit, Mapsco, AppraisalMethod, PricingMethod,").Append(QuoStr(cboAssessor.Text)).Append(" AS Assessors_Name,")
                sSELECT.Append(" 0.00000001 AS AVGLandValueSqFt, 0.00000001 AS AVGImproveValSqFt, 0.00000001 AS AVGTotalValueSqFt, 0.00000001 AS AVGTotalValueUnit, 0.00000001 AS AVGLandBldgRatio, 0 AS DateSwitch")
                sSELECT.Append(" FROM REComps ")
                If i = 0 Then
                    sSELECT.Append(" WHERE AssessorId = ").Append(colAssessors(cboAssessor.Text)).Append(" AND TaxYear = ").Append(AppData.TaxYear)
                End If
                If i = 1 Then sSELECT.Append(sWHERE.ToString)
                sSELECT.Append(" AND AcctNum " & IIf(i = 0, " = ", " <> ") & QuoStr(txtAcctNum.Text))
            Next

            sORDERBY.Length = 0
            sORDERBY.Append(" ORDER BY SortField")
            If cboSortImpValueSqFt.Text <> "" Then
                sORDERBY.Append(", ImprovementValuePerSqFt " & cboSortImpValueSqFt.Text)
            End If
            If cboSortLandValueSqFt.Text <> "" Then
                sORDERBY.Append(", LandValuePerSqFt " & cboSortLandValueSqFt.Text)
            End If
            If cboSortTotalValueSqFt.Text <> "" Then
                sORDERBY.Append(", TotalValuePerSqFt " & cboSortTotalValueSqFt.Text)
            End If
            If cboSortTotalValueUnit.Text <> "" Then
                sORDERBY.Append(", TotalValuePerUnit " & cboSortTotalValueUnit.Text)
            End If
            sSearchSQL = sSELECT.ToString & sORDERBY.ToString
            lRows = GetData(sSearchSQL, dtResults)
            If txtAcctNum.Text.ToString.Trim = "" Then lRowsCalc = lRows Else lRowsCalc = lRows - 1
            If lRowsCalc < 0 Then lRowsCalc = 0

            lTotalImproveFt = 0 : lTotalImproveValue = 0 : lTotalLandBldgRatio = 0 : lTotalLandFt = 0 : lTotalLandValue = 0 : lTotalValue = 0 : lTotalUnits = 0
            dAVGLandValueSqFt = 0 : dAVGImproveValSqFt = 0 : dAVGTotalValueSqFt = 0 : dAVGTotalValueUnit = 0
            For Each row In dtResults.Rows
                If row("AcctNum") <> txtAcctNum.Text Then
                    lTotalImproveFt = lTotalImproveFt + row("BuildingSqFt")
                    lTotalImproveValue = lTotalImproveValue + row("ImprovementValue")
                    lTotalLandBldgRatio = lTotalLandBldgRatio + row("LandBuildingRatio")
                    lTotalLandFt = lTotalLandFt + row("LandSqFt")
                    lTotalLandValue = lTotalLandValue + row("LandValue")
                    lTotalValue = lTotalValue + row("TotalValue")
                    lTotalUnits = lTotalUnits + row("NumberOfUnits")
                End If
            Next
            If lTotalLandFt > 0 Then dAVGLandValueSqFt = lTotalLandValue / lTotalLandFt
            If lTotalImproveFt > 0 Then dAVGImproveValSqFt = lTotalImproveValue / lTotalImproveFt
            If (lTotalImproveFt) > 0 Then dAVGTotalValueSqFt = lTotalValue / (lTotalImproveFt)
            If lTotalUnits > 0 Then dAVGTotalValueUnit = lTotalValue / lTotalUnits
            If lRowsCalc > 0 Then dAVGLandBldgRatio = lTotalLandBldgRatio / (lRowsCalc)
            For Each row In dtResults.Rows
                row("AVGLandValueSqFt") = dAVGLandValueSqFt
                row("AVGImproveValSqFt") = dAVGImproveValSqFt
                row("AVGTotalValueSqFt") = dAVGTotalValueSqFt
                row("AVGTotalValueUnit") = dAVGTotalValueUnit
                row("AVGLandBldgRatio") = dAVGLandBldgRatio
            Next

            bind.DataSource = dtResults
            gridResults.DataSource = bind

            txtCount.Text = "Record count:  " & (lRowsCalc).ToString("#,##0") &
                "    Average LV/ft:  " & dAVGLandValueSqFt.ToString("#,##0.0") &
                "    IV/ft:  " & dAVGImproveValSqFt.ToString("#,##0") &
                "    TV/ft:  " & dAVGTotalValueSqFt.ToString("#,##0")    ''& "    L/B:  " & dAVGLandBldgRatio.ToString("0")

            cmdPrint.Enabled = True
            gridResults.Columns("SortField").Visible = False

            If bGridFormatted Then Exit Sub

            With gridResults
                With .Columns("AcctNum")
                    .HeaderText = "Acct Num"
                End With
                With .Columns("StreetName")
                    .HeaderText = "Site"
                End With
                With .Columns("BusinessName")
                    .HeaderText = "Biz Name"
                End With
                With .Columns("BuildingClass")
                    .HeaderText = "Bldg Class"
                End With
                With .Columns("ConstructionType")
                    .HeaderText = "Construction Type"
                End With
                With .Columns("Mapsco")
                    .HeaderText = "Mapsco"
                End With
                With .Columns("LandMarketArea")
                    .HeaderText = "LMA"
                End With
                With .Columns("ImprovementMarketArea")
                    .HeaderText = "IMA"
                End With
                With .Columns("ComparabilityCode")
                    .HeaderText = "Comp Code"
                End With
                With .Columns("EconomicArea")
                    .HeaderText = "Eco Area"
                End With
                With .Columns("NeighborhoodGroup")
                    '.Width = 45
                    '.HeaderText = "Neigh Code"
                    .Visible = False
                End With
                With .Columns("BuildingSqFt")
                    .HeaderText = "Bldg" & vbCrLf & "SqFt"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .DefaultCellStyle.Format = "#,##0"
                    .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                End With
                With .Columns("LandSqFt")
                    .HeaderText = "Land" & vbCrLf & "SqFt"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .DefaultCellStyle.Format = "#,##0"
                    .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                End With
                With .Columns("YearBuilt")
                    .HeaderText = "Year Built"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .DefaultCellStyle.Format = "###0"
                    .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                With .Columns("EffectiveYear")
                    .HeaderText = "Effc Year"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .DefaultCellStyle.Format = "###0"
                    .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                With .Columns("LandValue")
                    .HeaderText = "Land Val"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .DefaultCellStyle.Format = "#,##0"
                    .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                End With
                With .Columns("ImprovementValue")
                    .HeaderText = "Imp Val"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .DefaultCellStyle.Format = "#,##0"
                    .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                End With
                With .Columns("TotalValue")
                    .HeaderText = "Tot Val"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .DefaultCellStyle.Format = "#,##0"
                    .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                End With
                With .Columns("LandValuePerSqFt")
                    .HeaderText = "LV/ft"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .DefaultCellStyle.Format = "#,##0.0"
                    .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                End With
                With .Columns("ImprovementValuePerSqFt")
                    .HeaderText = "IV/ft"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .DefaultCellStyle.Format = "#,##0"
                    .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                End With
                With .Columns("TotalValuePerSqFt")
                    .HeaderText = "TV/ft"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .DefaultCellStyle.Format = "#,##0"
                    .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                End With
                With .Columns("LandBuildingRatio")
                    '.Width = 30
                    '.HeaderText = "L/B"
                    '.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    '.DefaultCellStyle.Format = "#,##0"
                    '.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = False
                End With
                With .Columns("NumberOfUnits")
                    .HeaderText = "# of" & vbCrLf & "Units"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .DefaultCellStyle.Format = "#,##0"
                    .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                End With
                With .Columns("TotalValuePerUnit")
                    .HeaderText = "TV/Unit"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .DefaultCellStyle.Format = "#,##0"
                    .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                End With
                With .Columns("AppraisalMethod")
                    .HeaderText = "Appraisal Method"
                End With
                With .Columns("PricingMethod")
                    .HeaderText = "Pricing Method"
                End With
                With .Columns("ComparabilityCode")
                    .HeaderText = "Comp Code"
                End With

                .Columns("Assessors_Name").Visible = False
                .Columns("AVGLandValueSqFt").Visible = False
                .Columns("AVGImproveValSqFt").Visible = False
                .Columns("AVGTotalValueSqFt").Visible = False
                .Columns("AVGTotalValueUnit").Visible = False
                .Columns("AVGLandBldgRatio").Visible = False
                .Columns("DateSwitch").Visible = False
            End With

            For Each col As DataGridViewColumn In gridResults.Columns
                col.Width = GetColumnWidth(enumListType.enumRECompList, 0, col.Name)
            Next

            bGridFormatted = True

        Catch ex As Exception
            MsgBox("Error loading results:  " & ex.Message)
        End Try
    End Sub
    Private Sub SaveColumnWidths()
        Try
            For Each column As DataGridViewColumn In gridResults.Columns
                If column.Visible Then
                    SetColumnWidth(enumListType.enumRECompList, 0, column.Name, column.Width)
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub gridResults_CellPainting(sender As Object, e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles gridResults.CellPainting
        Try
            If e.RowIndex >= 0 Then
                If gridResults.Rows(e.RowIndex).Cells("SortField").Value.ToString = "0" Then
                    e.CellStyle.BackColor = Color.LightBlue
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LoadCodes(lAssessorId As Long)
        Try
            listBuildingClass.Items.Clear()
            listCompCode.Items.Clear()
            listAppraisalMethod.Items.Clear()
            listConstructionType.Items.Clear()
            listPricingMethod.Items.Clear()
            Dim dt As New DataTable, dr As DataRow
            GetData("SELECT FieldName, CodeValue FROM RECompCodes WHERE AssessorId = " & lAssessorId & " AND TaxYear = " & AppData.TaxYear & " ORDER BY CodeValue", dt)
            For Each dr In dt.Rows
                Select Case dr("FieldName").ToString
                    Case "BuildingClass"
                        listBuildingClass.Items.Add(dr("CodeValue").ToString)
                    Case "ComparabilityCode"
                        listCompCode.Items.Add(dr("CodeValue").ToString)
                    Case "ConstructionType"
                        listConstructionType.Items.Add(dr("CodeValue").ToString)
                    Case "AppraisalMethod"
                        listAppraisalMethod.Items.Add(dr("CodeValue").ToString)
                    Case "PricingMethod"
                        listPricingMethod.Items.Add(dr("CodeValue").ToString)
                End Select
            Next
        Catch ex As Exception
            MsgBox("Error loading codes:  " & ex.Message)
        End Try
    End Sub

    Private Sub cboAssessor_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboAssessor.SelectedIndexChanged
        Try
            If cboAssessor.Text = "" Then Exit Sub
            Me.Cursor = Cursors.WaitCursor
            LoadCodes(colAssessors(cboAssessor.Text))
            Me.Cursor = Cursors.Default
        Catch ex As Exception
        End Try
    End Sub

    Private Sub menuClearSelected_Click(sender As Object, e As System.EventArgs) Handles menuClearSelected.Click
        Try
            Select Case eListOfCodes
                Case enumRECompCodes.enumAppraisalMethod
                    listAppraisalMethod.ClearSelected()
                Case enumRECompCodes.enumBldgClass
                    listBuildingClass.ClearSelected()
                Case enumRECompCodes.enumCompCode
                    listCompCode.ClearSelected()
                Case enumRECompCodes.enumConstructionType
                    listConstructionType.ClearSelected()
                Case enumRECompCodes.enumPricingMethod
                    listPricingMethod.ClearSelected()
            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ListBox_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles listBuildingClass.MouseDown, listAppraisalMethod.MouseDown,
            listCompCode.MouseDown, listConstructionType.MouseDown, listPricingMethod.MouseDown

        If e.Button <> Windows.Forms.MouseButtons.Right Then Exit Sub

        Dim slistboxname As String = sender.name
        Select Case slistboxname
            Case listAppraisalMethod.Name
                eListOfCodes = enumRECompCodes.enumAppraisalMethod
            Case listBuildingClass.Name
                eListOfCodes = enumRECompCodes.enumBldgClass
            Case listCompCode.Name
                eListOfCodes = enumRECompCodes.enumCompCode
            Case listConstructionType.Name
                eListOfCodes = enumRECompCodes.enumConstructionType
            Case listPricingMethod.Name
                eListOfCodes = enumRECompCodes.enumPricingMethod
        End Select
    End Sub

    Private Sub TexBoxGotFocus(sender As Object, e As System.EventArgs) Handles txtAcctNum.GotFocus, txtBldgSqFtFrom.GotFocus, txtBldgSqFtTo.GotFocus,
            txtBusinessName.GotFocus, txtEconomicArea.GotFocus, txtImprovementMarketArea.GotFocus, txtImprovementValueFrom.GotFocus, txtImprovementValueSqFtFrom.GotFocus,
            txtImprovementValueSqFtTo.GotFocus, txtImprovementValueTo.GotFocus, txtLandMarketArea.GotFocus, txtLandSqFtFrom.GotFocus, txtLandSqFtTo.GotFocus,
            txtLandValueFrom.GotFocus, txtLandValueSqFtFrom.GotFocus, txtLandValueSqFtTo.GotFocus, txtLandValueTo.GotFocus, txtMapsco.GotFocus,
            txtNeighborhoodGroup.GotFocus, txtNumberUnitsFrom.GotFocus, txtNumberUnitsTo.GotFocus, txtStreet.GotFocus, txtTotalValueFrom.GotFocus,
            txtTotalValueSqFtFrom.GotFocus, txtTotalValueSqFtTo.GotFocus, txtTotalValueTo.GotFocus, txtTotalValueUnitFrom.GotFocus, txtTotalValueUnitTo.GotFocus,
            txtYearBuiltFrom.GotFocus, txtYearBuiltTo.GotFocus, txtLandBldgRatioFrom.GotFocus, txtLandBldgRatioTo.GotFocus, txtEffectiveYearFrom.GotFocus, txtEffectiveYearTo.GotFocus
        sender.SelectAll()
    End Sub

    Private Sub frmREComps_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Try
            SplitContainer1.SplitterDistance = cmdClose.Top + 25
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmdPrint_Click(sender As Object, e As System.EventArgs) Handles cmdPrint.Click
        Try
            Dim row As DataRow
            For Each row In dtResults.Rows
                row("DateSwitch") = IIf(chkPrintDate.Checked, 1, 0)
            Next
        Catch ex As Exception
        End Try

        RunReport(enumReport.enumREComp, AppData.TaxYear, dtResults)
    End Sub

    Private Sub frmREComps_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        SaveColumnWidths()
    End Sub
End Class
