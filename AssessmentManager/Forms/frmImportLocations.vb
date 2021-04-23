Public Class frmImportLocations
    Private m_ClientId As Long
    Private m_TaxYear As Integer
    Private m_ClientName As String
    Private sImportedLocationsTableName As String = ""
    Private sResultsTableName As String = ""
    Private sImportFile As String = ""

    Public Property TaxYear() As Integer
        Get
            Return m_TaxYear
        End Get
        Set(ByVal value As Integer)
            m_TaxYear = value
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
    Public Property ClientName() As String
        Get
            Return m_ClientName
        End Get
        Set(ByVal value As String)
            m_ClientName = value
        End Set
    End Property
    Public Property TypeOfImport() As Integer
        Get
            Return m_TypeOfImport
        End Get
        Set(ByVal value As Integer)
            m_TypeOfImport = value
        End Set
    End Property

    Private m_TypeOfImport As enumTable
    Private bActivated As Boolean
    Private iNumberOfColumns As Integer

    Private Function ImportFile() As Boolean
        Dim vFileContents As Object, lColumn As Long, lRow As Long, sRowContents() As String

        Try
            sImportFile = ""
            dgImport.Columns.Clear()
            If Not modMain.ImportFile(vFileContents, sImportFile) Then Exit Function
            txtFile.Text = sImportFile
            ReDim sRowContents(UBound(vFileContents, 1))
            iNumberOfColumns = UBound(vFileContents, 1) + 1

            cboAddress.Items.Clear()
            cboAddress.Items.Add("")
            cboCity.Items.Clear()
            cboCity.Items.Add("")
            cboClientLocationID.Items.Clear()
            cboClientLocationID.Items.Add("")
            cboName.Items.Clear()
            cboName.Items.Add("")
            cboLegalDescription.Items.Clear()
            cboLegalDescription.Items.Add("")
            cboStateCd.Items.Clear()
            cboStateCd.Items.Add("")
            cboZip.Items.Clear()
            cboZip.Items.Add("")
            cboLegalOwner.Items.Clear()
            cboLegalOwner.Items.Add("")
            cboAcctNum.Items.Clear()
            cboAcctNum.Items.Add("")
            cboAssessor.Items.Clear()
            cboAssessor.Items.Add("")

            For lRow = 1 To iNumberOfColumns
                cboAddress.Items.Add(lRow)
                cboCity.Items.Add(lRow)
                cboClientLocationID.Items.Add(lRow)
                cboName.Items.Add(lRow)
                cboLegalDescription.Items.Add(lRow)
                cboStateCd.Items.Add(lRow)
                cboZip.Items.Add(lRow)
                cboLegalOwner.Items.Add(lRow)
                cboAcctNum.Items.Add(lRow)
                cboAssessor.Items.Add(lRow)
            Next

            For lColumn = 0 To UBound(vFileContents, 1)
                dgImport.Columns.Add(lColumn + 1, lColumn + 1)
            Next
            For lRow = 0 To UBound(vFileContents, 2)
                For lColumn = 0 To UBound(vFileContents, 1)
                    sRowContents(lColumn) = vFileContents(lColumn, lRow)
                Next
                dgImport.Rows.Add(sRowContents)
            Next

            Return True
        Catch ex As Exception
            MsgBox("Error in ImportFile:  " & ex.Message)
            Return False
        End Try

    End Function

    Private Sub frmImport_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If bActivated Then Exit Sub
        If Not RefreshData() Then
            cmdBrowse.Enabled = False
        End If
        bActivated = True
    End Sub

    Private Function RefreshData() As Boolean
        Dim sSQL As String = "", lRows As Long = 0, dt As New DataTable

        Try
            If lRows = 0 Then
                Randomize()
                Do
                    Dim sRandom As String = Format(Rnd() * 1000000, "0")
                    sImportedLocationsTableName = "#tmpILI_" & sRandom
                    sResultsTableName = "#tmpILR_" & sRandom
                    sSQL = "SELECT 1 WHERE EXISTS (SELECT Name FROM sys.objects where name LIKE '%" & sRandom & "%')"
                    lRows = GetData(sSQL, dt)
                    If lRows = 0 Then Exit Do
                Loop
            Else
                sImportedLocationsTableName = "tempdb..importedlocationstable"
                sResultsTableName = "tempdb..resultslocationstable"
                Try
                    ExecuteSQL("drop table " & sImportedLocationsTableName)
                Catch
                End Try
                Try
                    ExecuteSQL("drop table " & sResultsTableName)
                Catch
                End Try
            End If
            Me.Text = "Importing locations for " & m_ClientName

            Return True
        Catch ex As Exception
            MsgBox("Error in RefreshData:  " & ex.Message)
            Return False
        End Try
    End Function

    Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub frmImport_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Dim Buttons(2) As Control
        Buttons(0) = cmdBack
        Buttons(1) = cmdFinish
        Buttons(2) = cmdCancel
        PlaceButtons(Me, Buttons)
        If Me.WindowState = FormWindowState.Minimized Then Exit Sub
    End Sub

    Private Sub RenameColumns()
        Dim iColumn As Integer, i As Integer

        Try


            For i = 0 To dgImport.Columns.Count - 1
                If dgImport.Columns(i).HeaderText = "Address" Then dgImport.Columns(i).HeaderText = i + 1
            Next
            If Trim(cboAddress.Text) <> "" Then
                iColumn = Val(cboAddress.Text) - 1
                dgImport.Columns.Item(iColumn).HeaderText = "Address"
            End If

            For i = 0 To dgImport.Columns.Count - 1
                If dgImport.Columns(i).HeaderText = "Name" Then dgImport.Columns(i).HeaderText = i + 1
            Next
            If Trim(cboName.Text) <> "" Then
                iColumn = Val(cboName.Text) - 1
                dgImport.Columns.Item(iColumn).HeaderText = "Name"
            End If

            For i = 0 To dgImport.Columns.Count - 1
                If dgImport.Columns(i).HeaderText = "City" Then dgImport.Columns(i).HeaderText = i + 1
            Next
            If Trim(cboCity.Text) <> "" Then
                iColumn = Val(cboCity.Text) - 1
                dgImport.Columns.Item(iColumn).HeaderText = "City"
            End If

            For i = 0 To dgImport.Columns.Count - 1
                If dgImport.Columns(i).HeaderText = "State" Then dgImport.Columns(i).HeaderText = i + 1
            Next
            If Trim(cboStateCd.Text) <> "" Then
                iColumn = Val(cboStateCd.Text) - 1
                dgImport.Columns.Item(iColumn).HeaderText = "State"
            End If

            For i = 0 To dgImport.Columns.Count - 1
                If dgImport.Columns(i).HeaderText = "Zip" Then dgImport.Columns(i).HeaderText = i + 1
            Next
            If Trim(cboZip.Text) <> "" Then
                iColumn = Val(cboZip.Text) - 1
                dgImport.Columns.Item(iColumn).HeaderText = "Zip"
            End If

            For i = 0 To dgImport.Columns.Count - 1
                If dgImport.Columns(i).HeaderText = "Client Location ID" Then dgImport.Columns(i).HeaderText = i + 1
            Next
            If Trim(cboClientLocationID.Text) <> "" Then
                iColumn = Val(cboClientLocationID.Text) - 1
                dgImport.Columns.Item(iColumn).HeaderText = "Client Location ID"
            End If

            For i = 0 To dgImport.Columns.Count - 1
                If dgImport.Columns(i).HeaderText = "Legal Description" Then dgImport.Columns(i).HeaderText = i + 1
            Next
            If Trim(cboLegalDescription.Text) <> "" Then
                iColumn = Val(cboLegalDescription.Text) - 1
                dgImport.Columns.Item(iColumn).HeaderText = "Legal Description"
            End If

            For i = 0 To dgImport.Columns.Count - 1
                If dgImport.Columns(i).HeaderText = "Legal Owner" Then dgImport.Columns(i).HeaderText = i + 1
            Next
            If Trim(cboLegalOwner.Text) <> "" Then
                iColumn = Val(cboLegalOwner.Text) - 1
                dgImport.Columns.Item(iColumn).HeaderText = "Legal Owner"
            End If

            For i = 0 To dgImport.Columns.Count - 1
                If dgImport.Columns(i).HeaderText = "Account Number" Then dgImport.Columns(i).HeaderText = i + 1
            Next
            If Trim(cboAcctNum.Text) <> "" Then
                iColumn = Val(cboAcctNum.Text) - 1
                dgImport.Columns.Item(iColumn).HeaderText = "Account Number"
            End If

            For i = 0 To dgImport.Columns.Count - 1
                If dgImport.Columns(i).HeaderText = "Assessor" Then dgImport.Columns(i).HeaderText = i + 1
            Next
            If Trim(cboAssessor.Text) <> "" Then
                iColumn = Val(cboAssessor.Text) - 1
                dgImport.Columns.Item(iColumn).HeaderText = "Assessor"
            End If
        Catch ex As Exception

        End Try

    End Sub


    Private Sub cboAddress_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles cboAddress.TextChanged, cboCity.TextChanged,
            cboClientLocationID.TextChanged, cboName.TextChanged, cboLegalDescription.TextChanged,
            cboStateCd.TextChanged, cboZip.TextChanged, cboLegalOwner.TextChanged,
            cboAcctNum.TextChanged, cboAssessor.TextChanged
        If Trim(sender.text) = "" Or (Val(sender.text) >= 1 And Val(sender.text) <= iNumberOfColumns) Then
            RenameColumns()
        End If
    End Sub

    Private Function LoadFileIntoDB(ByRef hasassessor As Boolean) As Boolean
        Dim lRows As Long, sSQL As String = "", sField As String = ""
        Dim iCol As Integer = 0
        Dim fields As New StringBuilder
        Dim hasstate As Boolean = False, hascity = False, hasaddress = False, hasacctnum = False

        Try
            ExecuteSQL("DROP TABLE " & sImportedLocationsTableName)
        Catch ex As Exception
        End Try
        Try
            ExecuteSQL("DROP TABLE " & sResultsTableName)
        Catch ex As Exception
        End Try

        Try
            hasassessor = False
            For iCol = 0 To dgImport.ColumnCount - 1
                If sSQL <> "" Then sSQL = sSQL & ","
                Select Case dgImport.Columns(iCol).HeaderText
                    Case "Address"
                        sField = "Address"
                        hasaddress = True
                    Case "Name"
                        sField = "Name"
                    Case "City"
                        sField = "City"
                        hascity = True
                    Case "State"
                        sField = "StateCd"
                        hasstate = True
                    Case "Zip"
                        sField = "Zip"
                    Case "Legal Description"
                        sField = "LegalDescription"
                    Case "Legal Owner"
                        sField = "LegalOwner"
                    Case "Client Location ID"
                        sField = "ClientLocationId"
                    Case "Account Number"
                        sField = "AcctNum"
                        hasacctnum = True
                    Case "Assessor"
                        sField = "AssessorName"
                        hasassessor = True
                    Case Else
                        sField = "Column" & iCol
                End Select
                sSQL = sSQL & sField & " varchar(255)"
                If fields.Length > 0 Then fields.Append(",")
                fields.Append(sField)
            Next
            If hasstate = False Or hascity = False Or hasaddress = False Or hasacctnum = False Then
                MsgBox("Address, city, state, and account number are required")
                Return False
            End If
            ExecuteSQL("CREATE TABLE " & sImportedLocationsTableName & " (" & sSQL & ")")
            sSQL = sSQL & ", [UniqueId] [bigint] IDENTITY(1,1) NOT NULL"
            sSQL = sSQL & ", LocationId bigint NULL, AssessmentId bigint null, AssessorId bigint null"
            ExecuteSQL("CREATE TABLE " & sResultsTableName & " (" & sSQL & ")")

            sSQL = "BULK INSERT " & sImportedLocationsTableName & " FROM " & QuoStr(sImportFile) &
                " WITH (ROWTERMINATOR = '\n', FIELDTERMINATOR ='\t')"
            lRows = ExecuteSQL(sSQL)
            'Can't bulk insert into a table with a uniqueid field, so just copy
            sSQL = "INSERT " & sResultsTableName & " ( " & fields.ToString() & ") SELECT " & fields.ToString & " FROM " & sImportedLocationsTableName
            lRows = ExecuteSQL(sSQL)

            Return True
        Catch ex As Exception
            MsgBox("Error loading file into database:  " & ex.Message)
            Return False
        End Try
    End Function

    Private Function CreateLocations() As Boolean
        Dim locationid As Long, assessmentid As Long, sql As New StringBuilder
        Dim dt As New DataTable
        Dim hasassessor As Boolean = False
        Dim clsbpploc As clsLocationBPP, clsreloc As clsLocationRE
        Dim clsbppass As clsAssessmentBPP, clsreass As clsAssessmentRE

        Try
            If Not LoadFileIntoDB(hasassessor) Then Return False

            'First, load up results temp table with correct locationid, assessmentid, assessorid values
            sql.Clear()
            sql.Append("SELECT UniqueId, StateCd").Append(IIf(hasassessor, ",AssessorName", "")).Append(" FROM ").Append(sResultsTableName)
            If GetData(sql.ToString, dt) < 1 Then
                Throw New Exception("No records to import")
            End If
            sql.Clear()
            For Each dr In dt.Rows
                locationid = CreateID(m_TypeOfImport)
                assessmentid = CreateID(IIf(m_TypeOfImport = enumTable.enumLocationBPP, enumTable.enumAssessmentBPP, enumTable.enumAssessmentRE))
                sql.Append(" UPDATE ").Append(sResultsTableName).Append(" SET LocationId = ").Append(locationid).Append(",AssessmentId = ").Append(assessmentid)
                sql.Append(" WHERE UniqueId = ").Append(dr("UniqueId"))
                If hasassessor Then
                    sql.Append(" UPDATE ").Append(sResultsTableName).Append(" SET AssessorId = (SELECT AssessorId FROM Assessors WHERE Name = ")
                    sql.Append(QuoStr(dr("AssessorName"))).Append(" AND StateCd = ").Append(QuoStr(dr("StateCd"))).Append(" AND TaxYear = ").Append(AppData.TaxYear).Append(")")
                    sql.Append(" WHERE UniqueId = ").Append(dr("UniqueId"))
                End If
            Next
            ExecuteSQL(sql.ToString)

            sql.Clear()
            sql.Append("SELECT * FROM ").Append(sResultsTableName)
            GetData(sql.ToString, dt)
            For Each dr In dt.Rows
                If m_TypeOfImport = enumTable.enumLocationBPP Then
                    clsbpploc = New clsLocationBPP
                    clsbppass = New clsAssessmentBPP
                    clsbpploc.ClientId = m_ClientId
                    clsbpploc.Address = dr("Address")
                    clsbpploc.City = dr("City")
                    clsbpploc.StateCd = dr("StateCd")
                    If dt.Columns.IndexOf("Zip") >= 0 Then
                        clsbpploc.Zip = dr("Zip").ToString
                    End If
                    If dt.Columns.IndexOf("Name") >= 0 Then
                        clsbpploc.Name = dr("Name").ToString
                    End If
                    If dt.Columns.IndexOf("ClientLocationId") >= 0 Then
                        clsbpploc.ClientLocationID = dr("ClientLocationID").ToString
                    End If
                    If dt.Columns.IndexOf("LegalOwner") >= 0 Then
                        clsbpploc.LegalOwner = dr("LegalOwner").ToString
                    End If
                    If dt.Columns.IndexOf("LegalDescription") >= 0 Then
                        clsbpploc.LegalDescription = dr("LegalDescription").ToString
                    End If
                    If clsbpploc.CreateLocation(True, dr("LocationId"), "") Then
                        If UnNullToDouble(dr("AssessorId")) > 0 Then
                            AddAssessor(dr("AssessorName"), dr("StateCd"), "")
                        End If
                        clsbppass.ClientId = m_ClientId
                        clsbppass.LocationId = dr("LocationId")
                        If dt.Columns.IndexOf("AcctNum") >= 0 Then
                            clsbppass.AcctNum = dr("AcctNum").ToString
                        End If
                        clsbppass.CreateAssessment(True, dr("AssessmentId"), UnNullToDouble(dr("AssessorId")), "")
                    End If
                Else
                    clsreloc = New clsLocationRE
                    clsreass = New clsAssessmentRE
                    clsreloc.ClientId = m_ClientId
                    clsreloc.Address = dr("Address")
                    clsreloc.City = dr("City")
                    clsreloc.StateCd = dr("StateCd")
                    If dt.Columns.IndexOf("Zip") >= 0 Then
                        clsreloc.Zip = dr("Zip").ToString
                    End If
                    If dt.Columns.IndexOf("Name") >= 0 Then
                        clsreloc.Name = dr("Name").ToString
                    End If
                    If dt.Columns.IndexOf("ClientLocationId") >= 0 Then
                        clsreloc.ClientLocationID = dr("ClientLocationID").ToString
                    End If
                    If dt.Columns.IndexOf("LegalOwner") >= 0 Then
                        clsreloc.LegalOwner = dr("LegalOwner").ToString
                    End If
                    If dt.Columns.IndexOf("LegalDescription") >= 0 Then
                        clsreloc.LegalDescription = dr("LegalDescription").ToString
                    End If
                    If clsreloc.CreateLocation(True, dr("LocationId"), "") Then
                        If UnNullToDouble(dr("AssessorId")) > 0 Then
                            AddAssessor(dr("AssessorName"), dr("StateCd"), "")
                        End If
                        clsreass.ClientId = m_ClientId
                        clsreass.LocationId = dr("LocationId")
                        If dt.Columns.IndexOf("AcctNum") >= 0 Then
                            clsreass.AcctNum = dr("AcctNum").ToString
                        End If
                        clsreass.CreateAssessment(True, dr("AssessmentId"), UnNullToDouble(dr("AssessorId")), "")
                    End If
                End If
            Next
            Return True
        Catch ex As Exception
            MsgBox("Error importing:  " & ex.Message)
            Return False
        End Try
    End Function

    Private Sub cmdFinish_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdFinish.Click
        Dim breturn As Boolean = False
        If MsgBox("Are you sure you want to import?", vbYesNo) = vbYes Then
            MDIParent1.ShowStatus("Importing locations")
            Me.Cursor = Cursors.WaitCursor
            breturn = CreateLocations()
            MDIParent1.ShowStatus()
            Me.Cursor = Cursors.Default
            cmdFinish.Enabled = False
        End If
        If breturn Then
            MsgBox("Import successful")
            Me.Close()
        End If
    End Sub

    Private Sub cmdBrowse_Click(sender As Object, e As EventArgs) Handles cmdBrowse.Click
        MDIParent1.ShowStatus("Loading file")
        Me.Cursor = Cursors.WaitCursor
        If ImportFile() Then
            fraFile.Visible = False
            fraColumns.Visible = True
            cmdFinish.Enabled = True
            cmdBack.Enabled = True
        End If
        MDIParent1.ShowStatus()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmdBack_Click(sender As Object, e As EventArgs) Handles cmdBack.Click
        If fraColumns.Visible Then
            fraColumns.Visible = False
            fraFile.Visible = True
            cmdFinish.Enabled = False
            cmdBack.Enabled = False
        End If
    End Sub
End Class
