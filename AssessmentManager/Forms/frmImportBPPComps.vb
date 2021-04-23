Public Class frmImportBPPComps
    Private bActivated As Boolean
    Private iNumberOfColumns As Integer
    Private lImportRowCount As Long
    Private sImportedTableName As String
    Private sImportFile As String
    Private Const SALEYEAR As String = "Year of Sale"
    Private Const SALEPRICE As String = "Sale Price"
    Private Const DESCRIPTION As String = "Description"
    Private Const INDUSTRY As String = "Industry"
    Private Const ASSETCATEGORY As String = "Asset Category"
    Private Const ASSETTYPE As String = "Asset Type"
    Private Const MANUFACTUREYEAR As String = "Year of Manufacture"
    Private Const MANUFACTURER As String = "Manufacturer"
    Private Const MODEL As String = "Model"
    Private Const SERIALNUMBER As String = "Serial Number/VIN"
    Private Const MACHINEHOURS As String = "Machine Hours"
    Private Const USEDFL As String = "New/Used"
    Private Const SOLDFL As String = "For Sale/Sold"
    Private Const COMPSOURCE As String = "Source"
    Private Const COMPSOURCEWEBSITE As String = "Source Website"
    Private Const COMPSOURCEPHONE As String = "Source Phone"
    Private Const COMPSOURCECONTACT As String = "Source Contact"
    Private Const DISCONTINUEDFL As String = "Discontinued"
    Private Const DETAILS As String = "Details"
    Private Const AUCTIONDATE As String = "Auction Date"
    Private Const LOTNUMBER As String = "Lot Number"

    Private Enum ErrorType
        NoError = 0
        BadData = 2
    End Enum

    Private Function RefreshData() As Boolean
        Dim sSQL As String = "", lRows As Long = 0
        Dim dt As New DataTable

        Try
            Randomize()
            Do
                Dim sRandom As String = CStr(Format(Rnd() * 1000000, "0"))
                sImportedTableName = "#tmpIBPPCOMPBI_" & sRandom
                sSQL = "SELECT 1 WHERE EXISTS (SELECT Name FROM sys.objects where name LIKE '%" & sRandom & "%')"
                lRows = GetData(sSQL, dt)
                If lRows = 0 Then Exit Do
            Loop
            Me.Text = "Importing BPP comps"

            Return True
        Catch ex As Exception
            MsgBox("Error in RefreshData:  " & ex.Message)
            Return False
        End Try
    End Function

    Private Sub frmImportBPPComps_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
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
        cboSaleYear.Items.Clear()
        cboSaleYear.Items.Add("")
        cboSalePrice.Items.Clear()
        cboSalePrice.Items.Add("")
        cboDescription.Items.Clear()
        cboDescription.Items.Add("")
        cboIndustry.Items.Clear()
        cboIndustry.Items.Add("")
        cboSerialNumber.Items.Clear()
        cboSerialNumber.Items.Add("")
        cboAssetCategory.Items.Clear()
        cboAssetCategory.Items.Add("")
        cboAssetType.Items.Clear()
        cboAssetType.Items.Add("")
        cboManufactureYear.Items.Clear()
        cboManufactureYear.Items.Add("")
        cboSoldFl.Items.Clear()
        cboSoldFl.Items.Add("")
        cboModel.Items.Clear()
        cboModel.Items.Add("")
        cboCompSource.Items.Clear()
        cboCompSource.Items.Add("")
        cboCompSourceWebsite.Items.Clear()
        cboCompSourceWebsite.Items.Add("")
        cboCompSourceContact.Items.Clear()
        cboCompSourceContact.Items.Add("")
        cboCompSourcePhone.Items.Clear()
        cboCompSourcePhone.Items.Add("")
        cboDiscontinuedFl.Items.Clear()
        cboDiscontinuedFl.Items.Add("")
        cboMachineHours.Items.Clear()
        cboMachineHours.Items.Add("")
        cboManufacturer.Items.Clear()
        cboManufacturer.Items.Add("")
        cboUsedFl.Items.Clear()
        cboUsedFl.Items.Add("")
        cboDetails.Items.Clear()
        cboDetails.Items.Add("")
        cboAuctionDate.Items.Clear()
        cboAuctionDate.Items.Add("")
        cboLotNumber.Items.Clear()
        cboLotNumber.Items.Add("")

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
            cboSaleYear.Items.Add(lColumn)
            cboSoldFl.Items.Add(lColumn)
            cboModel.Items.Add(lColumn)
            cboCompSource.Items.Add(lColumn)
            cboCompSourceWebsite.Items.Add(lColumn)
            cboCompSourceContact.Items.Add(lColumn)
            cboSalePrice.Items.Add(lColumn)
            cboDescription.Items.Add(lColumn)
            cboCompSourcePhone.Items.Add(lColumn)
            cboSerialNumber.Items.Add(lColumn)
            cboIndustry.Items.Add(lColumn)
            cboAssetCategory.Items.Add(lColumn)
            cboDiscontinuedFl.Items.Add(lColumn)
            cboMachineHours.Items.Add(lColumn)
            cboAssetType.Items.Add(lColumn)
            cboManufactureYear.Items.Add(lColumn)
            cboManufacturer.Items.Add(lColumn)
            cboUsedFl.Items.Add(lColumn)
            cboDetails.Items.Add(lColumn)
            cboAuctionDate.Items.Add(lColumn)
            cboLotNumber.Items.Add(lColumn)
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
    Private Function InsertComps(ByRef sError As String) As Boolean
        Try
            Dim sSQL As New StringBuilder, dt As New DataTable, col As DataColumn, sIN As String = "", row As DataRow
            Dim sInsert As New StringBuilder, sSelect As New StringBuilder

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
            sSQL.Append(" WHERE o.type = 'U' AND o.name = 'BPPComps' AND c.name IN(").Append(sIN).Append(")")
            GetData(sSQL.ToString, dt)
            'build up insert statement
            sInsert.Length = 0 : sSelect.Length = 0
            sInsert.Append("INSERT BPPComps (AddUser")
            sSelect.Append(" SELECT ").Append(QuoStr(AppData.UserId))
            For Each row In dt.Rows
                sInsert.Append(",").Append(row(0).ToString)
                Select Case row(0).ToString
                    Case "Description", "Industry", "AssetCategory", "AssetType", "Manufacturer", "Model", "SerialNumber", _
                                "CompSource", "CompSourceWebsite", "CompSourcePhone", "CompSourceContact", "Details", "LotNumber"
                        sSelect.Append(",").Append("LTRIM(RTRIM(ISNULL(").Append(row(0).ToString).Append(",'')))")
                    Case "SalePrice", "SaleYear", "ManufactureYear", "MachineHours"
                        'replace dollar signs and commas to an empty space, hyphens to 0
                        sSelect.Append(",").Append("ROUND(CONVERT(float,REPLACE(REPLACE(REPLACE(ISNULL(").Append(row(0).ToString).Append(",'0'),'$',''),',',''),'-','0')),0)")
                    Case "UsedFl"
                        sSelect.Append(",").Append("CASE WHEN ").Append(row(0).ToString).Append(" = 'Used' THEN 1 ELSE 0 END")
                    Case "SoldFl"
                        sSelect.Append(",").Append("CASE WHEN ").Append(row(0).ToString).Append(" = 'Sold' THEN 1 ELSE 0 END")
                    Case "DiscontinuedFl"
                        sSelect.Append(",").Append("CASE WHEN ").Append(row(0).ToString).Append(" = 'Y' THEN 1 ELSE 0 END")
                    Case "AuctionDate"
                        sSelect.Append(",").Append("CASE WHEN LTRIM(RTRIM(ISNULL(").Append(row(0).ToString)
                        sSelect.Append(",''))) = '' THEN NULL ELSE CONVERT(datetime,").Append(row(0).ToString).Append(") END")
                End Select
            Next

            sInsert.Append(")")
            sSelect.Append(" FROM ").Append(sImportedTableName)

            ExecuteSQL("begin transaction")
            If RunCompsInsert(sInsert.ToString, sSelect.ToString, sError) Then
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
    Private Function RunCompsInsert(sInsert As String, sSelect As String, _
            ByRef sError As String) As Boolean
        Try
            Dim sSQL As New StringBuilder
            sSQL.Length = 0
            sSQL.Append(sInsert).Append(" ").Append(sSelect)
            ExecuteSQL(sSQL.ToString)
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
            Handles cboSalePrice.TextChanged, cboDescription.TextChanged, cboIndustry.TextChanged, _
            cboAssetCategory.TextChanged, cboAssetType.TextChanged, cboSaleYear.TextChanged, _
            cboManufactureYear.TextChanged, cboManufacturer.TextChanged, cboModel.TextChanged, cboSerialNumber.TextChanged, _
            cboMachineHours.TextChanged, cboUsedFl.TextChanged, cboSoldFl.TextChanged, cboCompSource.TextChanged, _
            cboCompSourceWebsite.TextChanged, cboCompSourcePhone.TextChanged, cboCompSourceContact.TextChanged, _
            cboDiscontinuedFl.TextChanged, cboDetails.TextChanged, cboAuctionDate.TextChanged, cboLotNumber.TextChanged
        If Trim(sender.text) = "" Or (Val(sender.text) >= 1 And Val(sender.text) <= iNumberOfColumns) Then
            RenameColumns()
        End If
    End Sub
    Private Sub RenameColumns()
        Dim iColumn As Integer, i As Integer

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = SALEYEAR Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboSaleYear.Text) <> "" Then
            iColumn = Val(cboSaleYear.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = SALEYEAR
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = SALEPRICE Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboSalePrice.Text) <> "" Then
            iColumn = Val(cboSalePrice.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = SALEPRICE
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = DESCRIPTION Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboDescription.Text) <> "" Then
            iColumn = Val(cboDescription.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = DESCRIPTION
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = INDUSTRY Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboIndustry.Text) <> "" Then
            iColumn = Val(cboIndustry.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = INDUSTRY
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = ASSETCATEGORY Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboAssetCategory.Text) <> "" Then
            iColumn = Val(cboAssetCategory.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = ASSETCATEGORY
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = ASSETTYPE Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboAssetType.Text) <> "" Then
            iColumn = Val(cboAssetType.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = ASSETTYPE
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = MANUFACTUREYEAR Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboManufactureYear.Text) <> "" Then
            iColumn = Val(cboManufactureYear.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = MANUFACTUREYEAR
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = MANUFACTURER Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboManufacturer.Text) <> "" Then
            iColumn = Val(cboManufacturer.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = MANUFACTURER
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = MODEL Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboModel.Text) <> "" Then
            iColumn = Val(cboModel.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = MODEL
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = SERIALNUMBER Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboSerialNumber.Text) <> "" Then
            iColumn = Val(cboSerialNumber.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = SERIALNUMBER
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = MACHINEHOURS Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboMachineHours.Text) <> "" Then
            iColumn = Val(cboMachineHours.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = MACHINEHOURS
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = USEDFL Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboUsedFl.Text) <> "" Then
            iColumn = Val(cboUsedFl.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = USEDFL
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = SOLDFL Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboSoldFl.Text) <> "" Then
            iColumn = Val(cboSoldFl.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = SOLDFL
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = COMPSOURCE Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboCompSource.Text) <> "" Then
            iColumn = Val(cboCompSource.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = COMPSOURCE
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = COMPSOURCEWEBSITE Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboCompSourceWebsite.Text) <> "" Then
            iColumn = Val(cboCompSourceWebsite.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = COMPSOURCEWEBSITE
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = COMPSOURCEPHONE Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboCompSourcePhone.Text) <> "" Then
            iColumn = Val(cboCompSourcePhone.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = COMPSOURCEPHONE
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = COMPSOURCECONTACT Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboCompSourceContact.Text) <> "" Then
            iColumn = Val(cboCompSourceContact.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = COMPSOURCECONTACT
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = DISCONTINUEDFL Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboDiscontinuedFl.Text) <> "" Then
            iColumn = Val(cboDiscontinuedFl.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = DISCONTINUEDFL
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = DETAILS Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboDetails.Text) <> "" Then
            iColumn = Val(cboDetails.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = DETAILS
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = AUCTIONDATE Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboAuctionDate.Text) <> "" Then
            iColumn = Val(cboAuctionDate.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = AUCTIONDATE
        End If

        For i = 0 To dgFileContents.Columns.Count - 1
            If dgFileContents.Columns(i).HeaderText = LOTNUMBER Then dgFileContents.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboLotNumber.Text) <> "" Then
            iColumn = Val(cboLotNumber.Text) - 1
            dgFileContents.Columns.Item(iColumn).HeaderText = LOTNUMBER
        End If

    End Sub

    Private Sub cmdBrowse_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdBrowse.Click
        MDIParent1.ShowStatus("Loading file")
        Me.Cursor = Cursors.WaitCursor
        If ImportFile() Then cmdNext.Enabled = True
        MDIParent1.ShowStatus()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub frmImportBPPComps_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            ExecuteSQL("drop table " & sImportedTableName)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frmImportBPPComps_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fraColumns.Left = fraFile.Left
        fraColumns.Top = fraFile.Top
        fraResults.Left = fraFile.Left
        fraResults.Top = fraFile.Top
    End Sub

    Private Sub frmImportBPPComps_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
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
                    Case SALEYEAR
                        sField = "SaleYear"
                    Case SALEPRICE
                        sField = "SalePrice"
                    Case DESCRIPTION
                        sField = "Description"
                    Case INDUSTRY
                        sField = "Industry"
                    Case ASSETCATEGORY
                        sField = "AssetCategory"
                    Case ASSETTYPE
                        sField = "AssetType"
                    Case MANUFACTUREYEAR
                        sField = "ManufactureYear"
                    Case MANUFACTURER
                        sField = "Manufacturer"
                    Case MODEL
                        sField = "Model"
                    Case SERIALNUMBER
                        sField = "SerialNumber"
                    Case MACHINEHOURS
                        sField = "MachineHours"
                    Case USEDFL
                        sField = "UsedFl"
                    Case SOLDFL
                        sField = "SoldFl"
                    Case COMPSOURCE
                        sField = "CompSource"
                    Case COMPSOURCEWEBSITE
                        sField = "CompSourceWebsite"
                    Case COMPSOURCEPHONE
                        sField = "CompSourcePhone"
                    Case COMPSOURCECONTACT
                        sField = "CompSourceContact"
                    Case DISCONTINUEDFL
                        sField = "DiscontinuedFl"
                    Case DETAILS
                        sField = "Details"
                    Case AUCTIONDATE
                        sField = "AuctionDate"
                    Case LOTNUMBER
                        sField = "LotNumber"
                    Case Else
                        sField = "Column" & iCol
                End Select
                sSQL = sSQL & sField & " varchar(5000)"
            Next
            'sSQL = sSQL & ", IDField [bigint] IDENTITY(1,1) "
            sSQL = "CREATE TABLE " & sImportedTableName & " (" & sSQL & ")"
            ExecuteSQL(sSQL)

            sSQL = "BULK INSERT " & sImportedTableName & " FROM " & QuoStr(sImportFile) & _
                " WITH (ROWTERMINATOR = '\n', FIELDTERMINATOR ='\t', FIRSTROW=" & IIf(chkFirstRow.Checked, "2", "1") & ")"
            lRows = ExecuteSQL(sSQL)

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
