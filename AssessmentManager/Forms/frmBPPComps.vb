Public Class frmBPPComps
    Private sSearchSQL As String
    Private dtResults As DataTable

    Private Sub cmdClose_Click(sender As Object, e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub frmBPPComps_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Try
            Dim dt As New DataTable, dr As DataRow
            Dim sSQL As New StringBuilder
            sSQL.Length = 0
            sSQL.Append("SELECT RTRIM(LTRIM(Model)) AS Model FROM BPPComps GROUP BY RTRIM(LTRIM(Model)) ORDER BY Model")
            GetData(sSQL.ToString, dt)
            For Each dr In dt.Rows
                listModel.Items.Add(dr("Model"))
            Next
            cboIndustry.Items.Add("")
            sSQL.Length = 0
            sSQL.Append("SELECT RTRIM(LTRIM(Industry)) AS Industry FROM BPPComps GROUP BY RTRIM(LTRIM(Industry)) HAVING RTRIM(LTRIM(Industry)) <> '' ORDER BY Industry")
            GetData(sSQL.ToString, dt)
            For Each dr In dt.Rows
                cboIndustry.Items.Add(dr("Industry"))
            Next
            cboAssetCategory.Items.Add("")
            sSQL.Length = 0
            sSQL.Append("SELECT RTRIM(LTRIM(AssetCategory)) AS AssetCategory FROM BPPComps GROUP BY RTRIM(LTRIM(AssetCategory)) HAVING RTRIM(LTRIM(AssetCategory)) <> '' ORDER BY AssetCategory")
            GetData(sSQL.ToString, dt)
            For Each dr In dt.Rows
                cboAssetCategory.Items.Add(dr("AssetCategory"))
            Next

        Catch ex As Exception
            MsgBox("Error loading screen:  " & ex.Message)
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
            Dim lRows As Long = 0, sSQL As New StringBuilder, sWHERE As New StringBuilder
            Dim bind As New BindingSource
            Dim i As Integer
            Dim sModel As String
            Dim sIN As String
            Static bGridFormatted As Boolean = False

            dtResults = New DataTable
            cmdPrint.Enabled = False
            txtCount.Text = "" : sSQL.Length = 0 : sWHERE.Length = 0
            sWHERE.Append(" WHERE CompID > 0")

            If cboIndustry.Text <> "" Then
                sWHERE.Append(" AND Industry LIKE " & QuoStr(cboIndustry.Text & "%"))
            End If
            If cboAssetCategory.Text <> "" Then
                sWHERE.Append(" AND AssetCategory LIKE " & QuoStr(cboAssetCategory.Text & "%"))
            End If
            If txtSaleYearFrom.Text <> "" And txtSaleYearTo.Text <> "" Then
                sWHERE.Append(" AND SaleYear BETWEEN " & txtSaleYearFrom.Text & " AND " & txtSaleYearTo.Text)
            End If
            If txtSalePriceFrom.Text <> "" And txtSalePriceTo.Text <> "" Then
                sWHERE.Append(" AND SalePrice BETWEEN " & txtSalePriceFrom.Text & " AND " & txtSalePriceTo.Text)
            End If
            If txtSerialNumber.Text <> "" Then
                sWHERE.Append(" AND SerialNumber LIKE " & QuoStr(txtSerialNumber.Text & "%"))
            End If
            If txtMachineHoursFrom.Text <> "" And txtMachineHoursTo.Text <> "" Then
                sWHERE.Append(" AND MachineHours BETWEEN " & txtMachineHoursFrom.Text & " AND " & txtMachineHoursTo.Text)
            End If
            If listModel.SelectedItems.Count > 0 Then
                sIN = ""
                For Each sModel In listModel.SelectedItems
                    If sIN <> "" Then sIN = sIN & ","
                    sIN = sIN & QuoStr(sModel)
                Next
                sWHERE.Append(" AND Model IN(" & sIN & ")")
            End If
            If txtAssetType.Text <> "" Then
                sWHERE.Append(" AND AssetType LIKE " & QuoStr(txtAssetType.Text & "%"))
            End If
            If txtManufacturer.Text <> "" Then
                sWHERE.Append(" AND Manufacturer LIKE " & QuoStr(txtManufacturer.Text & "%"))
            End If
            If txtManufactureYear.Text <> "" Then
                sWHERE.Append(" AND ManufactureYear = " & txtManufactureYear.Text)
            End If
            If cboUsedFl.Text <> "" Then
                If cboUsedFl.Text.ToString.ToLower = "used" Then
                    sWHERE.Append(" AND UsedFl = 1")
                Else
                    sWHERE.Append(" AND UsedFl = 0")
                End If
            End If
            If cboSoldFl.Text <> "" Then
                If cboSoldFl.Text.ToString.ToLower = "sold" Then
                    sWHERE.Append(" AND SoldFl = 1")
                Else
                    sWHERE.Append(" AND SoldFl = 0")
                End If
            End If
            If cboDiscontinuedFl.Text <> "" Then
                If cboDiscontinuedFl.Text.ToString.ToLower = "yes" Then
                    sWHERE.Append(" AND DiscontinuedFl = 1")
                Else
                    sWHERE.Append(" AND DiscontinuedFl = 0")
                End If
            End If
            If txtCompSource.Text <> "" Then
                sWHERE.Append(" AND CompSource LIKE " & QuoStr(txtCompSource.Text & "%"))
            End If
            If txtDescription.Text <> "" Then
                sWHERE.Append(" AND Description LIKE " & QuoStr("%" & txtDescription.Text & "%"))
            End If
            
            lRows = GetData("SELECT COUNT(CompID) FROM BPPComps " & sWHERE.ToString, dtResults)
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

            sSQL.Length = 0
            sSQL.Append("SELECT CompID, SaleYear, CASE WHEN SoldFl = 1 THEN 'Sold' ELSE 'For sale' END AS SoldFl,")
            sSQL.Append(" SalePrice, Description, AssetType, ManufactureYear, Manufacturer, Model, SerialNumber, MachineHours,")
            sSQL.Append(" CASE WHEN UsedFl = 1 THEN 'Used' ELSE 'New' END AS UsedFl, CompSource FROM BPPComps")
            sSQL.Append(sWHERE.ToString).Append(" ORDER BY SalePrice")

            lRows = GetData(sSQL.ToString, dtResults)
            bind.DataSource = dtResults
            gridResults.DataSource = bind
            txtCount.Text = "Record count:  " & (lRows).ToString("#,##0")
            cmdPrint.Enabled = True
            If bGridFormatted Then Exit Sub
            With gridResults
                With .Columns("CompID")
                    .Width = 50
                    .HeaderText = "ID"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .DefaultCellStyle.Format = "###0"
                    .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With
                With .Columns("SaleYear")
                    .Width = 40
                    .HeaderText = "Sale Year"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .DefaultCellStyle.Format = "###0"
                    .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                With .Columns("SoldFl")
                    .Width = 60
                    .HeaderText = "For Sale/" & vbCrLf & "Sold"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                With .Columns("SalePrice")
                    .Width = 80
                    .HeaderText = "Price"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .DefaultCellStyle.Format = "#,##0"
                    .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                End With
                With .Columns("Description")
                    .Width = 220
                    .HeaderText = "Description"
                End With
                With .Columns("AssetType")
                    .Width = 120
                    .HeaderText = "Asset Type"
                End With
                With .Columns("ManufactureYear")
                    .Width = 40
                    .HeaderText = "Mfg Year"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .DefaultCellStyle.Format = "###0"
                    .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                With .Columns("Manufacturer")
                    .Width = 110
                    .HeaderText = "Manufacturer"
                End With
                With .Columns("Model")
                    .Width = 80
                    .HeaderText = "Model"
                End With
                With .Columns("SerialNumber")
                    .Width = 100
                    .HeaderText = "VIN/SN"
                End With
                With .Columns("MachineHours")
                    .Width = 70
                    .HeaderText = "Engine/" & vbCrLf & "Machine" & vbCrLf & "Hours"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .DefaultCellStyle.Format = "#,##0"
                    .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                End With
                With .Columns("UsedFl")
                    .Width = 40
                    .HeaderText = "New/" & vbCrLf & "Used"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                With .Columns("CompSource")
                    .Width = 120
                    .HeaderText = "Source"
                End With
            End With

            bGridFormatted = True

        Catch ex As Exception
            MsgBox("Error loading results:  " & ex.Message)
        End Try
    End Sub

    Private Sub menuClearSelected_Click(sender As Object, e As System.EventArgs) Handles menuClearSelected.Click
        Try
            listModel.ClearSelected()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TexBoxGotFocus(sender As Object, e As System.EventArgs) Handles _
             txtManufacturer.GotFocus, txtSaleYearFrom.GotFocus, txtSalePriceFrom.GotFocus, _
            txtSalePriceTo.GotFocus, txtSaleYearTo.GotFocus, txtManufactureYear.GotFocus, _
            txtSerialNumber.GotFocus, txtMachineHoursFrom.GotFocus, txtMachineHoursTo.GotFocus, _
            txtCompSource.GotFocus, txtDescription.GotFocus, txtAssetType.GotFocus, txtAssetType.GotFocus
        sender.SelectAll()
    End Sub

    Private Sub frmBPPComps_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Try
            SplitContainer1.SplitterDistance = cmdClose.Top + 25
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmdPrint_Click(sender As Object, e As System.EventArgs) Handles cmdPrint.Click
        RunReport(enumReport.enumBPPCompBarCode, AppData.TaxYear, dtResults)
    End Sub

    Private Sub menuRemoveRow_Click(sender As Object, e As System.EventArgs) Handles menuRemoveRow.Click
        Try
            Dim selectedrow As DataGridViewRow, bDidDelete As Boolean = False
            For Each selectedrow In gridResults.SelectedRows
                bDidDelete = True
                gridResults.Rows.Remove(selectedrow)
            Next
            If bDidDelete Then dtResults.AcceptChanges()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmdExport_Click(sender As System.Object, e As System.EventArgs) Handles cmdExport.Click
        Dim sOutput As String = "", sOutputHeader As String = "", lRow As Long = 0, iCol As Integer = 0
        Dim iEvent As Integer = 0, lRowsCount As Long = 0, sFileName As String = ""

        Try
            Me.Cursor = Cursors.WaitCursor
            MDIParent1.ShowStatus("Exporting")
            For iCol = 0 To gridResults.Columns.Count - 1
                If sOutputHeader <> "" Then sOutputHeader = sOutputHeader & vbTab
                sOutputHeader = sOutputHeader & Replace(Trim(gridResults.Columns(iCol).HeaderText), vbCrLf, "")
            Next
            sOutputHeader = sOutputHeader & vbNewLine
            ExportFile(sOutputHeader, False, sFileName)
            sOutputHeader = ""
            lRowsCount = gridResults.Rows.Count
            For lRow = 0 To lRowsCount - 1
                sOutput = ""
                For iCol = 0 To gridResults.Columns.Count - 1
                    If Not IsIndexField(gridResults.Columns(iCol).Name) Then
                        If sOutput <> "" Then sOutput = sOutput & vbTab
                        sOutput = sOutput & Trim(UnNullToString(gridResults.Rows(lRow).Cells(iCol).Value))
                    End If
                Next
                sOutputHeader = sOutputHeader & sOutput & vbNewLine
                iEvent = iEvent + 1
                If iEvent > 1000 Then
                    ExportFile(sOutputHeader, True, sFileName)
                    sOutputHeader = ""
                    MDIParent1.ShowStatus("Exporting, " & Format(lRow / lRowsCount * 100, "0") & "% complete")
                    iEvent = 0
                End If
            Next
            MDIParent1.ShowStatus()
            Me.Cursor = Cursors.Default

            If sOutputHeader <> "" Then ExportFile(sOutputHeader, True, sFileName)
            MsgBox("Export completed")

        Catch ex As Exception
            MsgBox("Error exporting:  " & ex.Message)
        End Try

    End Sub

    Private Sub cmdDelete_Click(sender As Object, e As System.EventArgs) Handles cmdDelete.Click
        Try
            If MsgBox("Are you sure you want to permanently delete the selected rows from the database?", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then Exit Sub

            Me.Cursor = Cursors.WaitCursor
            MDIParent1.ShowStatus("Deleting")

            Dim selectedrow As DataGridViewRow, bDidDelete As Boolean = False
            For Each selectedrow In gridResults.SelectedRows
                bDidDelete = True
                Dim sCompID As String = selectedrow.Cells("CompID").Value
                Dim sSQL As New StringBuilder
                sSQL.Append("DELETE BPPComps WHERE CompID = ").Append(sCompID)
                ExecuteSQL(sSQL.ToString)
                gridResults.Rows.Remove(selectedrow)

            Next
            If bDidDelete Then dtResults.AcceptChanges()

            MDIParent1.ShowStatus()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MsgBox("Error deleting:  " & ex.Message)
        End Try
    End Sub

    Private Sub gridResults_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridResults.CellDoubleClick
        Try
            If e.RowIndex < 0 Then Exit Sub
            Dim sCompID As String = ""
            sCompID = gridResults.Rows(e.RowIndex).Cells("CompID").Value.ToString
            If sCompID <> "" Then
                frmAddBPPComp.AddNew = False
                frmAddBPPComp.CompID = sCompID
                frmAddBPPComp.ShowDialog()
                frmAddBPPComp = Nothing
            End If
        Catch
        End Try
    End Sub
End Class
