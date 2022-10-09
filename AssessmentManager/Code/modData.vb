Module modData
    Public Const csDol = "#,##0.00"
    Public Const csPct = "#0.00%"
    Public Const csPctNoDec = "#0%"
    Public Const csInt = "#,##0"
    Public Const csDate = "M/d/yyyy"
    Public Const csDateTime = "M/d/yyyy h:mm tt"
    Public Const csFactor = "0.00000000%" 'factor codes
    Public Const csShortDate = "M/d"
    Public Const csTaxRate = "0.00000000"
    Public Const csYear = "####"

    Private Const CheckBox = 13
    Private Const TextBox = 14
    Private Const RadioButton = 20
    Private Const Label = 21
    Private Const DataGridView As Integer = 1
    Private Const ComboBox As Integer = 2
    Private Const DateTimePicker As Integer = 3

    Private dtDataDefinitions As New DataTable
    Private dtFieldDataDefinition As New DataTable
    Public colStateCodes As Collection
    Public colStateNames As Collection
    Public colSICCodes As Collection
    Public dicColumnWidths As Dictionary(Of String, Long)

    Private colConsultants As Collection

    Public Structure typeDBUpdateInfo
        Public Structure typeDBPrimaryKeys
            Friend sField As String
            Friend vValue As Object
        End Structure
        Friend sTable As String
        Friend sUpdateField As String
        Friend vUpdateValue As Object
        Friend bAllowInsert As Boolean
        Friend PrimaryKeys() As typeDBPrimaryKeys
        Friend sFormat As String
        Friend sTriggerField As String
        Friend sTriggerValue As String
    End Structure
    Public Const DB_Add As Integer = 1
    Public Const DB_Change As Integer = 2
    Public Const DB_Delete As Integer = 3
    Public Enum enumDataTypes
        eDataUnknown
        eDataNumber
        eDataText
        eDataDate
        eDataBit
        eDataDateTime
    End Enum

    Public Structure typeFieldDefinition
        Friend sTable As String
        Friend sField As String
        Friend lType As Long
        Friend vValue As Object
        Friend bQueryVisibleFl As Boolean
        Friend lQueryType As Long
        Friend sFieldDescription As String
        'Friend bIsAPrimaryKey As Boolean
    End Structure
    Public udtFieldInfo() As typeFieldDefinition

    Public Function GetData(ByVal sSQL As String, ByRef dt As DataTable) As Long
        Return cData.GetData(sSQL, dt)
    End Function
    Public Function GetDataset(ByVal sSQL As String) As DataSet
        Return cData.GetDataset(sSQL)
    End Function
    'Public Function ExecuteSQLLocal(ByVal sSQL As String) As Long
    '    Try
    '        If AppData.UserId = "U0829716" Then My.Computer.FileSystem.WriteAllText("d:\sqldebuglocal.txt", Now & ":  " & sSQL & vbCrLf & vbCrLf, True)
    '    Catch ex As Exception
    '    End Try

    '    Dim command As OleDbCommand = New OleDbCommand(sSQL, cnLocal)
    '    Return command.ExecuteNonQuery()



    'End Function
    Public Function StoreStateFormBLOB(ByVal lFormId As Long, ByVal sFile As String, ByVal iTaxYear As Integer, ByVal sStateCd As String, _
            ByVal sFormName As String, ByVal sFormDescription As String, ByVal sUserId As String) As Boolean
        Return cData.StoreStateFormBLOB(sFile, lFormId, iTaxYear, sStateCd, sFormName, sFormDescription, sUserId)
    End Function
    Public Function StoreClientFormBLOB(ByVal lFormId As Long, ByVal sFile As String, ByVal lClientId As Long, _
            ByVal iTaxYear As Integer, ByVal sStateCd As String, _
            ByVal sFormName As String, ByVal sFormDescription As String, ByVal sUserId As String) As Boolean
        Return cData.StoreClientFormBLOB(sFile, lFormId, lClientId, iTaxYear, sStateCd, sFormName, sFormDescription, sUserId)
    End Function
    Public Function StoreClientContractBLOB(ByVal lClientId As Long, ByVal sFile As String, ByVal sUserId As String) As Boolean
        Return cData.StoreClientContractBLOB(lClientId, sFile, sUserId)
    End Function
    Public Function StoreClientProposalBLOB(ByVal lClientId As Long, ByVal sFile As String, ByVal sUserId As String) As Boolean
        Return cData.StoreClientProposalBLOB(lClientId, sFile, sUserId)
    End Function

    Public Function StoreTaxBillBLOB(ByVal sTable As String, ByVal lClientId As Long, ByVal lLocationId As Long, _
            ByVal lAssessmentId As Long, ByVal lCollectorId As Long, ByVal iTaxYear As Integer, _
            ByVal sUserName As String, ByVal sFile As String) As Boolean
        Return cData.StoreTaxBillBLOB(sTable, lClientId, lLocationId, lAssessmentId, lCollectorId, iTaxYear, sUserName, sFile)
    End Function
    Public Function RetrieveBLOB(ByVal eType As enumReport, ByVal lFormId As Long, ByVal iTaxYear As Integer, ByRef sStreamData As System.IO.MemoryStream) As Boolean
        Return cData.RetrieveBLOB(lFormId, iTaxYear, sStreamData)
    End Function
    Public Function RetrieveClientContractBLOB(ByVal lClientId As Long, ByRef sFile As String) As Boolean
        Return cData.RetrieveClientContractBLOB(lClientId, sFile)
    End Function
    Public Function RetrieveClientProposalBLOB(ByVal lClientId As Long, ByRef sFile As String) As Boolean
        Return cData.RetrieveClientProposalBLOB(lClientId, sFile)
    End Function
    Public Function RetrieveClientFormBLOB(ByVal lFormId As Long, ByVal iTaxYear As Integer, ByRef sStreamData As System.IO.MemoryStream) As Boolean
        Return cData.RetrieveClientFormBLOB(lFormId, iTaxYear, sStreamData)
    End Function

    Public Function RetrieveTaxBillBLOB(ByVal sTable As String, ByVal lClientId As Long, ByVal lLocationId As Long, ByVal lAssessmentId As Long, _
            ByVal lCollectorId As Long, ByVal iTaxYear As Integer, ByVal sFileName As String) As Boolean
        Return cData.RetrieveTaxBillBLOB(sTable, lClientId, lLocationId, lAssessmentId, lCollectorId, iTaxYear, sFileName)
    End Function
    Public Function WriteSQLToHistory(ByVal sTypeOfUpdate As String, sHistory As String)
        'need to add table to database (may not need this function, but just in case)
        'Try
        '    Dim sSQL As String = ""
        '    sSQL = "INSERT DatabaseHistory (TypeOfUpdate,TextOfUpdate,AddUser)" & _
        '        " SELECT " & QuoStr(sTypeOfUpdate) & "," & QuoStr(sHistory, 5000) & "," & QuoStr(AppData.UserId)
        '    ExecuteSQL(sSQL)
        'Catch ex As Exception
        'End Try
    End Function
    Public Function ExecuteSQL(ByVal sSQL As String) As Long
        'MsgBox(sSQL)

        Try
            If UCase(AppData.UserId) = "UX016445" Or UCase(AppData.UserId).Contains("STIGLER") Then
                If IO.Directory.Exists("c:\mytempfolder\vantageone") = False Then IO.Directory.CreateDirectory("c:\mytempfolder\vantageone")
                My.Computer.FileSystem.WriteAllText("c:\mytempfolder\vantageone\assmansql.txt", Now & ":  " & sSQL & vbCrLf & vbCrLf, True)
            End If

        Catch ex As Exception
        End Try


        Return cData.ExecuteSQL(sSQL)
    End Function
    Public Function CreateID(ByVal eTable As enumTable) As Long
        Dim sSQL As String = "", lID As Long, dt As New DataTable


        Do
            lID = AppData.myRandom.Next
            'want to keep number high for account moves between clients 
            If lID > 100000 Then
                If eTable = enumTable.enumClient Then
                    sSQL = "SELECT ClientId FROM Clients WHERE ClientId = " & lID
                ElseIf eTable = enumTable.enumLocationBPP Or eTable = enumTable.enumLocationRE Then
                    sSQL = "SELECT LocationId FROM LocationsBPP WHERE LocationId = " & lID &
                        " UNION SELECT LocationId FROM LocationsRE WHERE LocationId = " & lID
                ElseIf eTable = enumTable.enumAssessmentBPP Or eTable = enumTable.enumAssessmentRE Then
                    sSQL = "SELECT AssessmentId FROM AssessmentsBPP WHERE AssessmentId = " & lID &
                        " UNION SELECT AssessmentId FROM AssessmentsRE WHERE AssessmentId = " & lID
                ElseIf eTable = enumTable.enumAssessor Then
                    sSQL = "SELECT AssessorId FROM Assessors WHERE AssessorId = " & lID
                ElseIf eTable = enumTable.enumFactorEntity Then
                    sSQL = "select FactorEntityId from FactorEntities where FactorEntityId = " & lID
                ElseIf eTable = enumTable.enumCollector Then
                    sSQL = "select CollectorId from Collectors where CollectorId = " & lID
                ElseIf eTable = enumTable.enumJurisdiction Then
                    sSQL = "select JurisdictionId from Jurisdictions where JurisdictionId = " & lID
                ElseIf eTable = enumTable.enumStateForms Then
                    sSQL = "select FormId from StateForms where FormId = " & lID
                ElseIf eTable = enumTable.enumClientForms Then
                    sSQL = "select FormId from ClientForms where FormId = " & lID
                ElseIf eTable = enumTable.enumTaskMasterList Then
                    sSQL = "select TaskId from TaskMasterList where TaskId = " & lID
                ElseIf eTable = enumTable.enumTaskAssignment Then
                    sSQL = "SELECT TaskAssignmentId FROM TaskAssignments WHERE TaskAssignmentId = " & lID
                ElseIf eTable = enumTable.enumProspectLocation Then
                    sSQL = "SELECT LocationId FROM ProspectLocations WHERE LocationId = " & lID
                ElseIf eTable = enumTable.enumQuery Then
                    sSQL = "SELECT QueryId FROM UserQuery WHERE QueryId = " & lID
                ElseIf eTable = enumTable.enumBusinessUnits Then
                    sSQL = "SELECT BusinessUnitId FROM BusinessUnits WHERE BusinessUnitId = " & lID
                ElseIf eTable = enumTable.enumAgency Then
                    sSQL = "SELECT AgencyId FROM Agencies WHERE AgencyId = " & lID
                End If
                If GetData(sSQL, dt) = 0 Then Exit Do
            End If
        Loop

        Return lID
    End Function

    Public Sub UpdateJurisdictionCollectorId(lJurisdictionId As Long, sCollectorId As String, iTaxYear As Integer)
        Try
            Dim sSQL As String
            sSQL = "UPDATE Jurisdictions SET CollectorId = " & sCollectorId & " , ChangeDate = GETDATE(), ChangeUser = " &
                QuoStr(AppData.UserId) & ",ChangeType = 2  WHERE JurisdictionId = " & lJurisdictionId & " AND TaxYear > " & iTaxYear
            ExecuteSQL(sSQL)
        Catch ex As Exception
            MsgBox("Error in UpdateJurisdictionCollectorId:  " & ex.Message)
        End Try
    End Sub

    Public Sub UpdateDB(ByVal ctl As Control, ByVal DBInfo() As typeDBUpdateInfo, _
            Optional ByVal colDropDownCollection As Collection = Nothing)
        Dim sTag As String, sFormat As String, sTable As String, sField As String, iStart As Integer, iEnd As Integer
        Dim vWrkVar As Object, iLen As Integer, eDataType As enumDataTypes, bAllowNull As Boolean
        Dim sKeyword As String, lFieldLength As Long, lIndex As Long
        Dim NullObject As Object

        Try

            sTag = Trim(ctl.Tag)
            If sTag = "" Then Exit Sub
            With ctl
                sFormat = ""
                If Left(sTag, 4) = "@DB=" Then
                    iStart = 1
                    iLen = Len(sTag)
                    While iStart < iLen
                        iStart = InStr(iStart, sTag, "@") + 1
                        If iStart > 1 Then
                            iEnd = InStr(iStart, sTag, "=")
                            sKeyword = UCase(Mid$(sTag, iStart, iEnd - iStart))
                            iStart = iEnd + 1
                            If iStart <= iLen Then
                                Select Case sKeyword
                                    Case "DB"  'database tablename.fieldname
                                        sTable = Mid$(sTag, iStart, IIf(InStr(iStart, sTag, ".") = 0, 0, InStr(iStart, sTag, ".") - iStart))
                                        iStart = iStart + Len(sTable) + 1
                                        sField = CStr(GetTagItem(sTag, iStart, iEnd))
                                    Case "FMT"
                                        vWrkVar = GetTagItem(sTag, iStart, iEnd)
                                        Select Case UCase$(vWrkVar)
                                            Case "DOL"
                                                sFormat = csDol
                                            Case "PCT"
                                                sFormat = csPct
                                            Case "INT"
                                                sFormat = csInt
                                            Case "FACTOR"
                                                sFormat = csFactor
                                            Case "DATE"
                                                sFormat = csDate
                                            Case "SHORTDATE"
                                                sFormat = csShortDate
                                            Case "TAXRATE"
                                                sFormat = csTaxRate
                                            Case "DATETIME"
                                                sFormat = csDateTime
                                            Case "YEAR"
                                                sFormat = csYear
                                        End Select
                                    Case "IDX"
                                        lIndex = CLng(GetTagItem(sTag, iStart, iEnd))
                                End Select
                            End If
                        End If
                    End While
                    GetDataDefinition(sTable, sField, eDataType, bAllowNull, lFieldLength, "")
                    SaveOneControl(DBInfo(lIndex), ctl, eDataType, sFormat, bAllowNull, NullObject, lFieldLength, colDropDownCollection, "")
                End If
            End With
        Catch ex As Exception
            MsgBox("Error in UpdateDB:  " & ex.Message)

        End Try

    End Sub

    Public Sub SaveOneControl(ByVal DBInfo As typeDBUpdateInfo, ByRef ctl As Object, _
            ByVal eDataType As enumDataTypes, ByVal sFormat As String, _
            ByVal bAllowNull As Object, ByRef vNewValue As Object, ByVal lFieldLength As Long, _
            ByVal colDropDownCollection As Collection, ByRef sMsg As String)
        Dim iCtlType As Integer, sValue As String
        Dim i As Integer, d As Double

        Try
            iCtlType = ControlType(ctl)
            Select Case iCtlType
                Case CheckBox
                    If DBInfo.sUpdateField = "ChangeType" Then
                        If ctl.checkstate = 0 Then
                            sValue = DB_Change
                        Else
                            sValue = DB_Delete
                        End If
                    ElseIf ctl.checkstate = 0 Then
                        If bAllowNull Then
                            sValue = "NULL"
                        Else
                            sValue = "0"
                        End If
                    Else
                        sValue = "1"
                    End If
                Case ComboBox
                    If InStr(DBInfo.sUpdateField, "StateCd", CompareMethod.Text) > 0 Then
                        If Trim(ctl.text) = "" Then
                            sValue = "NULL"
                        Else
                            sValue = QuoStr(colStateNames(ctl.text))
                        End If
                    Else
                        If eDataType = enumDataTypes.eDataText Then
                            If Trim(ctl.Text) = "" And bAllowNull = True Then
                                sValue = "NULL"
                            Else
                                sValue = QuoStr(Left(Trim(ctl.Text), lFieldLength))
                            End If
                        ElseIf eDataType = enumDataTypes.eDataNumber Then
                            If Trim(ctl.text) = "" Then
                                If bAllowNull Then
                                    sValue = "NULL"
                                Else
                                    sValue = "0"
                                End If
                            Else
                                sValue = colDropDownCollection(ctl.Text)
                            End If
                        End If
                        '        Case SSDateCombo
                        '            If IsNull(ctl) Then
                        '                sValue = "NULL"
                        '            ElseIf ctl.Text = "" Then
                        '                sValue = "NULL"
                        '            Else
                        '                sValue = QuoStr(Format(ctl.Text, csDate))
                        '            End If
                    End If
                Case TextBox
                    If Trim(ctl.Text) = "" And bAllowNull Then
                        sValue = "NULL"
                    ElseIf eDataType = enumDataTypes.eDataNumber Then
                        If Trim(ctl.text) = "" Then
                            d = 0
                        ElseIf sFormat = csFactor Or sFormat = csPct Then
                            If InStr(ctl.text, "%") > 1 Then
                                d = CDbl(Left(ctl.text, Len(ctl.text) - 1)) / 100
                            Else
                                d = CDbl(ctl.text) / 100
                            End If
                        ElseIf IsNumeric(Trim(ctl.text)) Then
                            d = CDbl(ctl.Text)
                        Else
                            d = 0
                        End If
                        sValue = d
                        ctl.text = Format(d, sFormat)
                    ElseIf eDataType = enumDataTypes.eDataText Then
                        ctl.Text = Left(Trim(ctl.Text), lFieldLength)
                        sValue = QuoStr(Left(Trim(ctl.Text), lFieldLength))
                    ElseIf eDataType = enumDataTypes.eDataDate Then
                        If IsDate(ctl.Text) Then
                            ctl.Text = Format(CDate(ctl.Text), sFormat)
                            If sFormat = csShortDate Then
                                sValue = QuoStr(Format(CDate(ctl.Text & "/" & AppData.TaxYear), csDate))
                            Else
                                sValue = QuoStr(Format(CDate(ctl.Text), sFormat))
                            End If
                        Else
                            MsgBox("Entry must be a date")
                            ctl.Text = ""
                            Exit Sub
                        End If
                    ElseIf eDataType = enumDataTypes.eDataDateTime Then
                        If IsDate(ctl.Text) Then
                            ctl.Text = Format(ctl.Text, sFormat)
                            sValue = QuoStr(Format(ctl.Text, csDateTime))
                        Else
                            MsgBox("Entry must be date/time")
                            ctl.Text = ""
                            Exit Sub
                        End If
                    ElseIf eDataType = enumDataTypes.eDataBit Then
                        If ctl.text = "False" Then sValue = 0 Else sValue = 1
                        ctl.text = sValue
                    End If
                    'Case OptionButton
                    '    If ctl.Value = True Then
                    '        sValue = ctl.Index
                    '    End If
                    'Case SSDataGrid
                    '    If eDataType = eDataNumber Then
                    '        If Trim(DBInfo.vUpdateValue) = "" Then
                    '            If bAllowNull Then
                    '                sValue = "NULL"
                    '            Else
                    '                sValue = "0"
                    '            End If
                    '        ElseIf IsNumeric(DBInfo.vUpdateValue) Then
                    '            If CDbl(DBInfo.vUpdateValue) = 0 Then
                    '                If bAllowNull Then
                    '                    sValue = "NULL"
                    '                    vNewValue = ""
                    '                Else
                    '                    sValue = "0"
                    '                End If
                    '            Else
                    '                sValue = Format(CDbl(DBInfo.vUpdateValue))
                    '                vNewValue = Format(CDbl(DBInfo.vUpdateValue), sFormat)
                    '            End If
                    '        Else
                    '            sMsg = "Entry must be numeric"
                    '            Exit Sub
                    '        End If
                    '    ElseIf eDataType = eDataText Then
                    '        If Trim(DBInfo.vUpdateValue) = "" Then
                    '            If bAllowNull Then
                    '                sValue = "NULL"
                    '            Else
                    '                sValue = "''"
                    '            End If
                    '        Else
                    '            vNewValue = Left(Trim(DBInfo.vUpdateValue), lFieldLength)
                    '            sValue = QuoStr(Left(Trim(DBInfo.vUpdateValue), lFieldLength))
                    '        End If
                    '    ElseIf eDataType = eDataDate Then
                    '        If Trim(DBInfo.vUpdateValue) = "" Then
                    '            If bAllowNull Then
                    '                sValue = "NULL"
                    '            Else
                    '                sValue = QuoStr(Format(Now, csDate))
                    '            End If
                    '        Else
                    '            If Not IsDate(DBInfo.vUpdateValue) Then
                    '                sMsg = "Entry must be a date"
                    '                Exit Sub
                    '            Else
                    '                vNewValue = Format(DBInfo.vUpdateValue, sFormat)
                    '                sValue = QuoStr(Format(DBInfo.vUpdateValue, csDate))
                    '            End If
                    '        End If
                    '    ElseIf eDataType = eDataDateTime Then
                    '        If Trim(DBInfo.vUpdateValue) = "" Then
                    '            If bAllowNull Then
                    '                sValue = "NULL"
                    '            Else
                    '                sValue = QuoStr(Format(Now, csDateTime))
                    '            End If
                    '        Else
                    '            If Not IsDate(DBInfo.vUpdateValue) Then
                    '                sMsg = "Entry must be date/time"
                    '                Exit Sub
                    '            Else
                    '                vNewValue = Format(DBInfo.vUpdateValue, sFormat)
                    '                sValue = QuoStr(Format(DBInfo.vUpdateValue, csDateTime))
                    '            End If
                    '        End If
                    '    ElseIf eDataType = eDataBit Then
                    '        sValue = Format(Abs(Val(DBInfo.vUpdateValue)), "0")
                    '        If sValue = "0" And bAllowNull Then sValue = "NULL"
                    '        vNewValue = DBInfo.vUpdateValue
                    '    End If
            End Select

            If Not SaveData(sValue, DBInfo, vNewValue, sMsg) Then
                MsgBox(sMsg)
            End If

        Catch ex As Exception
            MsgBox("Error in SaveOneControl:  " & ex.Message)
        End Try
    End Sub

    Public Function SaveData(ByVal sValue As String, ByVal DBInfo As typeDBUpdateInfo, _
            ByRef vNewValue As Object, ByRef sMsg As String) As Boolean

        Dim sWhere As String = "", sAudit As String = "", sSQL As String = ""
        Dim lDeprCodeId As Long = 0

        Try

            If InStr(DBInfo.sUpdateField, "StateCd", CompareMethod.Text) > 0 Then
                sValue = UCase(sValue)
                vNewValue = UCase(vNewValue)
            End If
            sWhere = " WHERE "
            For i = 0 To UBound(DBInfo.PrimaryKeys)
                If i > 0 Then sWhere = sWhere & " AND "
                sWhere = sWhere & DBInfo.PrimaryKeys(i).sField & " = " & DBInfo.PrimaryKeys(i).vValue   'value already formatted with quotes if needed
            Next

            sAudit = ", ChangeDate = GETDATE(), ChangeUser = " & QuoStr(AppData.UserId)
            If DBInfo.sUpdateField <> "ChangeType" Then sAudit = sAudit & ",ChangeType = " & DB_Change
            sSQL = "UPDATE " & DBInfo.sTable & " SET " & DBInfo.sUpdateField & " = " & sValue
            ''''    If DBInfo.sTable = "LocationByYear" Then
            ''''        If Right(DBInfo.sUpdateField, 3) = "_Fl" Then
            ''''            DBInfo.sTriggerField = Left(DBInfo.sUpdateField, Len(DBInfo.sUpdateField) - 3) & "_Dt"
            ''''            If sValue = "1" Then
            ''''                DBInfo.sTriggerValue = "GETDATE()"
            ''''            Else
            ''''                DBInfo.sTriggerValue = "NULL"
            ''''            End If
            ''''        End If
            ''''    End If
            If DBInfo.sTable = "AssessmentsBPP" And
                    (DBInfo.sUpdateField = "RenditionCompleteFl" Or DBInfo.sUpdateField = "AssetsLoadedFl" Or DBInfo.sUpdateField = "AssetsVerifiedFl") Then
                Select Case DBInfo.sUpdateField
                    Case "RenditionCompleteFl"
                        DBInfo.sTriggerField = "RenditionCompleteDate"
                    Case "AssetsLoadedFl"
                        DBInfo.sTriggerField = "AssetsLoadedDate"
                    Case "AssetsVerifiedFl"
                        DBInfo.sTriggerField = "AssetsVerifiedDate"
                End Select
                DBInfo.sTriggerValue = IIf(sValue = "1", "GETDATE()", "NULL")
            End If
            If DBInfo.sTriggerField <> "" Then
                sSQL = sSQL & "," & DBInfo.sTriggerField & " = " & DBInfo.sTriggerValue
            End If
            sSQL = sSQL & sAudit & " " & sWhere
            If ExecuteSQL(sSQL) < 1 Then
                If DBInfo.bAllowInsert Then
                    sSQL = DBInfo.sUpdateField
                    If DBInfo.sTriggerField <> "" Then
                        sSQL = sSQL & "," & DBInfo.sTriggerField
                    End If
                    For i = 0 To UBound(DBInfo.PrimaryKeys)
                        If DBInfo.PrimaryKeys(i).sField <> DBInfo.sUpdateField Then
                            sSQL = sSQL & " , "
                            sSQL = sSQL & DBInfo.PrimaryKeys(i).sField
                        End If
                    Next
                    sSQL = sSQL & ",ChangeDate,ChangeUser,ChangeType,AddDate,AddUser"
                    sSQL = "INSERT " & DBInfo.sTable & " (" & sSQL & ") SELECT "
                    sSQL = sSQL & sValue
                    If DBInfo.sTriggerField <> "" Then
                        sSQL = sSQL & "," & DBInfo.sTriggerValue
                    End If
                    For i = 0 To UBound(DBInfo.PrimaryKeys)
                        If DBInfo.PrimaryKeys(i).sField <> DBInfo.sUpdateField Then
                            sSQL = sSQL & " , "
                            sSQL = sSQL & DBInfo.PrimaryKeys(i).vValue
                        End If
                    Next
                    sSQL = sSQL & ",GETDATE()," & QuoStr(AppData.UserId) & "," & DB_Add & ",GETDATE()," & QuoStr(AppData.UserId)
                    If ExecuteSQL(sSQL) < 1 Then
                        sMsg = "Error in SaveOneControl:  Unable to save data, SQL = " & sSQL
                        Return False
                    End If
                Else
                    sMsg = "Error in SaveOneControl:  Unable to save data, SQL = " & sSQL
                    Return False
                End If
            End If

            If DBInfo.sTable = "Jurisdictions" And DBInfo.sUpdateField = "CollectorId" And sValue = "NULL" Then
                WriteSQLToHistory("RemoveCollectorFromJurisdiction", sSQL)
            End If

            'enforce data integrity between Depreciation codes and tax return groups by using Junction Table TaxReturnGroupJunction
            If DBInfo.sTable = "DeprCode" And DBInfo.sUpdateField = "TaxReturnGroupId" Then
                For i = 0 To UBound(DBInfo.PrimaryKeys)
                    If DBInfo.PrimaryKeys(i).sField = "DeprCodeId" Then
                        lDeprCodeId = DBInfo.PrimaryKeys(i).vValue
                    End If
                Next
                If DBInfo.vUpdateValue = "0" Then
                    sSQL = "DELETE TaxReturnGroupJunction WHERE DeprCodeId = " & lDeprCodeId & " AND Year = " & AppData.TaxYear
                    ExecuteSQL(sSQL)
                Else
                    sSQL = "UPDATE TaxReturnGroupJunction SET GroupId = " & DBInfo.vUpdateValue & _
                        " WHERE DeprCodeId = " & lDeprCodeId & " AND Year = " & AppData.TaxYear
                    If ExecuteSQL(sSQL) = 0 Then
                        sSQL = "INSERT TaxReturnGroupJunction (DeprCodeId,GroupId,Year)" & _
                            " SELECT " & lDeprCodeId & "," & DBInfo.vUpdateValue & "," & AppData.TaxYear
                        ExecuteSQL(sSQL)
                    End If
                End If
            End If

            Return True
        Catch ex As Exception
            sMsg = "Error in SaveData:  " & ex.Message
            Return False
        End Try

    End Function

    'Public Function ConnectToLocalDB(ByVal sError As String) As Boolean
    '    Try
    '        cnLocal = New OleDbConnection
    '        cnLocal.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & AppData.ReportFile
    '        cnLocal.Open()
    '        Return True
    '    Catch ex As Exception
    '        sError = "Error connecting to " & AppData.ReportFile & ":  " & ex.Message
    '        Return False
    '    End Try

    'End Function

    Public Function ConnectToDB() As Boolean
        Dim sError As String = ""

        cData = New clsData With {
            .Server = AppData.Server
        }
        If cData.MakeConnection(sError) Then
            LoadStates()
            ExecuteSQL("delete ReportData WHERE UserName = " & QuoStr(AppData.UserId))
            Return True
        Else
            MsgBox("Error connecting to database:  " & sError, MsgBoxStyle.Critical, AppData.AppName)
            Return False
        End If

    End Function
    Private Function ControlType(ByVal ctl As Control) As Integer
        'Returns the class of control. The returned integer will be equated
        'to the type of control.
        ' OCX controls
        If TypeOf ctl Is CheckBox Then
            ControlType = CheckBox
        ElseIf TypeOf ctl Is ComboBox Then
            ControlType = ComboBox
        ElseIf TypeOf ctl Is TextBox Then
            ControlType = TextBox
        ElseIf TypeOf ctl Is DateTimePicker Then
            ControlType = DateTimePicker
        ElseIf TypeOf ctl Is RichTextBox Then
            ControlType = TextBox
            '    ElseIf TypeOf ctl Is ctlPushButton Then
            '        ControlType = ctlPushButton
        ElseIf TypeOf ctl Is RadioButton Then
            ControlType = RadioButton
        ElseIf TypeOf ctl Is DataGridView Then
            ControlType = DataGridView
        ElseIf TypeOf ctl Is Label Then
            ControlType = Label
        End If

    End Function


    Public Sub InitControls(ByRef frm As Form, ByRef DBInfo() As typeDBUpdateInfo, ByVal DBPrimary() As typeDBUpdateInfo)
        Dim l As Long, sTag As String, iLen As Integer, iStart As Integer, sKeyword As String, sTable As String
        Dim sField As String, eDataType As enumDataTypes, lTranslateCode As Long, iCtlType As Integer
        Dim lTransCounter As Long, iEnd As Integer, bAllowNull As Boolean, sAddStr As String
        Dim vTranslateList() As Object, lFieldLength As Long, i1 As Integer, i2 As Integer
        Dim sTriggerField As String, sFieldDescription As String, ctl As Object
        Dim ctlFormControl As Object
        Dim colControls As New Collection, page As Object

        ReDim DBInfo(0)
        ReDim DBInfo(0).PrimaryKeys(UBound(DBPrimary(i1).PrimaryKeys))

        For Each ctlFormControl In frm.Controls             '1st level of collection of controls
            colControls = New Collection
            If TypeOf ctlFormControl Is TabControl Then     'tab control contains it's own collection of pages
                For Each page In ctlFormControl.controls    'page contains controls
                    For Each ctl In page.Controls
                        colControls.Add(ctl)
                    Next
                Next
            ElseIf TypeOf ctlFormControl Is GroupBox Or TypeOf ctlFormControl Is SplitContainer Or TypeOf ctlFormControl Is SplitterPanel Then       'group box may contain other group boxes
                For Each ctl1 In ctlFormControl.controls         'this goes down 3 levels
                    If TypeOf ctl1 Is GroupBox Or TypeOf ctl1 Is SplitContainer Or TypeOf ctl1 Is SplitterPanel Then
                        For Each ctl2 In ctl1.controls
                            If TypeOf ctl2 Is GroupBox Or TypeOf ctl2 Is SplitContainer Or TypeOf ctl2 Is SplitterPanel Then
                                For Each ctl3 In ctl2.controls
                                    If TypeOf ctl3 Is GroupBox Or TypeOf ctl3 Is SplitContainer Or TypeOf ctl3 Is SplitterPanel Then
                                        For Each ctl4 In ctl3.controls
                                            If TypeOf ctl4 Is GroupBox Or TypeOf ctl4 Is SplitContainer Or TypeOf ctl4 Is SplitterPanel Then
                                            Else
                                                colControls.Add(ctl4)
                                            End If
                                        Next
                                    Else
                                        colControls.Add(ctl3)
                                    End If
                                Next
                            Else
                                colControls.Add(ctl2)
                            End If
                        Next
                    Else
                        colControls.Add(ctl1)
                    End If
                Next
            Else
                colControls.Add(ctlFormControl)             'first level control
            End If

            For Each ctl In colControls
                With ctl
                    sTag = Trim(.Tag)
                    If Left(sTag, 4) = "@DB=" Then
                        iLen = Len(sTag)
                        iStart = 1
                        While iStart < iLen
                            iStart = InStr(iStart, sTag, "@") + 1
                            If iStart > 1 Then
                                iEnd = InStr(iStart, sTag, "=")
                                sKeyword = UCase(Mid$(sTag, iStart, iEnd - iStart))
                                iStart = iEnd + 1
                                If iStart <= iLen Then
                                    Select Case sKeyword
                                        Case "DB"  'database tablename.fieldname
                                            sTable = Mid$(sTag, iStart, IIf(InStr(iStart, sTag, ".") = 0, 0, InStr(iStart, sTag, ".") - iStart))
                                            iStart = iStart + Len(sTable) + 1
                                            sField = CStr(GetTagItem(sTag, iStart, iEnd))
                                        Case Else
                                            GetTagItem(sTag, iStart, iEnd)
                                    End Select
                                End If
                            End If
                        End While
                        GetDataDefinition(sTable, sField, eDataType, bAllowNull, lFieldLength, sFieldDescription)
                        iCtlType = ControlType(ctl)
                        If iCtlType = Label Then .Text = sFieldDescription
                        If iCtlType = ComboBox Then
                            ctl.Items.Clear()
                            If InStr(sField, "StateCd", CompareMethod.Text) > 0 Then
                                ctl.items.add("")
                                For Each sTemp As String In colStateCodes
                                    ctl.Items.Add(sTemp)
                                Next
                            ElseIf (sTable = "Clients" Or sTable = "LocationsBPP" Or sTable = "LocationsRE") And (sField = "ClientCoordinatorName" Or sField = "AccountRep" Or sField = "BPPConsultantName" Or sField = "REConsultantName" Or sField = "ConsultantName") Then
                                ctl.items.add("")
                                For Each sTemp As String In colConsultants
                                    ctl.Items.Add(sTemp)
                                Next
                            ElseIf sTable = "Clients" And (sField = "LeadStatus" Or sField = "SolicitType") Then
                            ElseIf sField = "SICCode" Then
                                ctl.items.add("")
                                For Each stemp As String In colSICCodes
                                    ctl.items.add(stemp)
                                Next
                            Else
                                Dim drFiltered() As DataRow, row As DataRow
                                drFiltered = dtFieldDataDefinition.Select("TableName = " & QuoStr(sTable) & " AND FieldName = " & QuoStr(sField))
                                If drFiltered.Count > 0 Then
                                    ctl.items.add("")
                                    For Each row In drFiltered
                                        ctl.items.add(row("FieldValue"))
                                    Next
                                End If
                            End If
                        End If
                        ReDim Preserve DBInfo(UBound(DBInfo) + 1)
                        With DBInfo(UBound(DBInfo))
                            .sTable = sTable
                            .sUpdateField = sField
                        End With
                        For i1 = 0 To UBound(DBPrimary)
                            If DBPrimary(i1).sTable = sTable Then
                                ReDim DBInfo(UBound(DBInfo)).PrimaryKeys(UBound(DBPrimary(i1).PrimaryKeys))
                                For i2 = 0 To UBound(DBPrimary(i1).PrimaryKeys)
                                    DBInfo(UBound(DBInfo)).PrimaryKeys(i2).sField = DBPrimary(i1).PrimaryKeys(i2).sField
                                    DBInfo(UBound(DBInfo)).PrimaryKeys(i2).vValue = DBPrimary(i1).PrimaryKeys(i2).vValue
                                Next
                            End If
                        Next
                        .Tag = .Tag & ";@IDX=" & UBound(DBInfo)
                    End If
                End With
            Next
        Next
    End Sub

    Public Sub RefreshControls(ByRef frm As Form, ByVal dt As DataTable, ByVal sParmTable As String)
        Dim sTagTable As String = "", sField As String = "", sFormat As String = ""
        Dim iStart As Integer = 0, iLen As Integer = 0, iEnd As Integer = 0, sTag As String = ""
        Dim eDataType As enumDataTypes, lTranslateCode As Long = 0, bAllowNull As Boolean = False
        Dim sKeyword As String = "", vWrkVar As Object, lFieldLength As Long = 0
        Dim lRows As Long = 0, dr As DataRow, ctlFormControl As Object, ctl As Object
        Dim colControls As New Collection, page As Object

        Try
            lRows = dt.Rows.Count
            If lRows > 0 Then dr = dt.Rows(0)
            For Each ctlFormControl In frm.Controls             '1st level of collection of controls
                colControls = New Collection
                If TypeOf ctlFormControl Is TabControl Then     'tab control contains it's own collection of pages
                    For Each page In ctlFormControl.controls    'page contains controls
                        For Each ctl In page.Controls
                            colControls.Add(ctl)
                        Next
                    Next
                ElseIf TypeOf ctlFormControl Is GroupBox Or TypeOf ctlFormControl Is SplitContainer Or TypeOf ctlFormControl Is SplitterPanel Then       'group box may contain other group boxes
                    For Each ctl1 In ctlFormControl.controls         'this goes down 3 levels
                        If TypeOf ctl1 Is GroupBox Or TypeOf ctl1 Is SplitContainer Or TypeOf ctl1 Is SplitterPanel Then
                            For Each ctl2 In ctl1.controls
                                If TypeOf ctl2 Is GroupBox Or TypeOf ctl2 Is SplitContainer Or TypeOf ctl2 Is SplitterPanel Then
                                    For Each ctl3 In ctl2.controls
                                        If TypeOf ctl3 Is GroupBox Or TypeOf ctl3 Is SplitContainer Or TypeOf ctl3 Is SplitterPanel Then
                                            For Each ctl4 In ctl3.controls
                                                If TypeOf ctl4 Is GroupBox Or TypeOf ctl4 Is SplitContainer Or TypeOf ctl4 Is SplitterPanel Then
                                                Else
                                                    colControls.Add(ctl4)
                                                End If
                                            Next
                                        Else
                                            colControls.Add(ctl3)
                                        End If
                                    Next
                                Else
                                    colControls.Add(ctl2)
                                End If
                            Next
                        Else
                            colControls.Add(ctl1)
                        End If
                    Next
                Else
                    colControls.Add(ctlFormControl)             'first level control
                End If

                For Each ctl In colControls
                    With ctl
                        sTag = Trim(.Tag)
                        sFormat = ""
                        If Left(sTag, 4) = "@DB=" Then
                            iStart = 1
                            iLen = Len(sTag)
                            While iStart < iLen
                                iStart = InStr(iStart, sTag, "@") + 1
                                If iStart > 1 Then
                                    iEnd = InStr(iStart, sTag, "=")
                                    sKeyword = UCase(Mid$(sTag, iStart, iEnd - iStart))
                                    iStart = iEnd + 1
                                    If iStart <= iLen Then
                                        Select Case sKeyword
                                            Case "DB"  'database tablename.fieldname
                                                sTagTable = Mid$(sTag, iStart, IIf(InStr(iStart, sTag, ".") = 0, 0, InStr(iStart, sTag, ".") - iStart))
                                                iStart = iStart + Len(sTagTable) + 1
                                                sField = CStr(GetTagItem(sTag, iStart, iEnd))
                                            Case "FMT"
                                                vWrkVar = GetTagItem(sTag, iStart, iEnd)
                                                Select Case UCase$(vWrkVar)
                                                    Case "DOL"
                                                        sFormat = csDol
                                                    Case "PCT"
                                                        sFormat = csPct
                                                    Case "INT"
                                                        sFormat = csInt
                                                    Case "FACTOR"
                                                        sFormat = csFactor
                                                    Case "TAXRATE"
                                                        sFormat = csTaxRate
                                                    Case "DATE"
                                                        sFormat = csDate
                                                    Case "SHORTDATE"
                                                        sFormat = csShortDate
                                                    Case "DATETIME"
                                                        sFormat = csDateTime
                                                    Case "YEAR"
                                                        sFormat = csYear
                                                End Select
                                            Case Else
                                                GetTagItem(sTag, iStart, iEnd)
                                        End Select
                                    End If
                                End If
                            End While
                            If sTagTable = sParmTable Then
                                GetDataDefinition(sTagTable, sField, eDataType, bAllowNull, lFieldLength, "")
                                LoadOneControl(ctl, sField, dr(sField), eDataType, sFormat, lTranslateCode, lRows)
                            End If
                        End If
                    End With
                Next
            Next

        Catch ex As Exception
            MsgBox("Error refreshing form data in RefreshControls:  " & ex.Message & ", TAG=" & sTag)
        End Try
    End Sub

    Private Function GetTagItem(ByVal sTag As String, ByRef iStart As Integer, ByRef iEnd As Integer) As Object
        'given a beginning, looks for known alternate delimiters before returning the string.
        'Resets iStart to the new starting position,
        'Resets iend to the ending position.

        Dim i As Integer

        iEnd = InStr(iStart + 1, sTag, "@")
        If iEnd = 0 Then iEnd = Len(sTag)
        i = InStr(iStart, sTag, ":")
        If i <> 0 Then iEnd = IIf(i <= iEnd, i - 1, iEnd)
        i = InStr(iStart, sTag, ";")
        If i <> 0 Then iEnd = IIf(i <= iEnd, i - 1, iEnd)
        GetTagItem = Mid(sTag, iStart, (iEnd + 1) - iStart)
        iStart = iEnd + 1

    End Function
    Private Sub LoadOneControl(ByRef ctlControl As Object, ByVal sField As String, ByVal fld As Object, ByVal eDataType As enumDataTypes,
            ByVal sFormat As String, ByVal lTranslateCode As Long, ByVal lRows As Long)

        Dim sWrkVar As String
        Dim iSeq As Integer
        Dim i As Integer
        Dim iCtlType As Integer, List() As String, row As DataRow
        Dim d As Double


        'Perform data edits based on control type
        iCtlType = ControlType(ctlControl)
        Select Case iCtlType
            Case CheckBox
                If lRows = 0 Then
                    ctlControl.value = 0
                Else
                    If sField = "ChangeType" Then
                        If UnNullToDouble(fld.ToString) = DB_Delete Then
                            ctlControl.Value = 1
                        Else
                            ctlControl.Value = 0
                        End If
                    Else
                        If fld.ToString = "True" Then
                            ctlControl.checkstate = 1
                        Else
                            ctlControl.checkstate = 0
                        End If
                    End If
                End If
            Case ComboBox
                ctlControl.Text = ""
                If lRows = 0 Then
                    ctlControl.text = ""
                Else
                    If InStr(sField, "StateCd", CompareMethod.Text) > 0 And Trim(fld.ToString) <> "" Then
                        ctlControl.text = colStateCodes(fld.ToString)
                    Else
                        ctlControl.text = fld.ToString
                    End If
                End If
            Case DateTimePicker
                ctlControl.value = ""
                If lRows > 0 Then
                    If Not IsDBNull(fld) Then
                        If fld <> "" Then
                            ctlControl.value = Format(fld, csDate)
                        End If
                    End If
                End If
            Case TextBox
                ctlControl.Text = ""
                If lRows > 0 Then
                    If eDataType = enumDataTypes.eDataNumber Then
                        sWrkVar = Trim("" & fld.ToString)
                        If sWrkVar <> "" Then
                            d = CDbl("" & fld.ToString)
                            sWrkVar = Format(d, sFormat)
                        End If
                        ctlControl.Text = sWrkVar
                    ElseIf eDataType = enumDataTypes.eDataDate Then
                        sWrkVar = "" & fld.ToString
                        If sWrkVar <> "" Then
                            sWrkVar = Format(CDate(sWrkVar), sFormat)
                        End If
                        ctlControl.Text = sWrkVar
                    ElseIf eDataType = enumDataTypes.eDataDateTime Then
                        sWrkVar = "" & fld.ToString
                        If sWrkVar <> "" Then
                            sWrkVar = Format(sWrkVar, sFormat)
                        End If
                        ctlControl.Text = sWrkVar
                    Else
                        ctlControl.Text = "" & fld.ToString
                    End If
                Else
                    ctlControl.text = ""
                End If
        End Select
    End Sub
    Public Function LoadFirmInfo()
        Dim dt As New DataTable, row As DataRow, sSQL As String = ""

        Try
            With AppData
                .FirmAddress = ""
                .FirmCity = ""
                .FirmName = ""
                .FirmPhone = ""
                .FirmStateCd = ""
                .FirmZip = ""
                .FirmFax = ""
            End With
            sSQL = "SELECT RTRIM(ISNULL(Name,'')) AS Name, RTRIM(ISNULL(Address,'')) AS Address," &
                "RTRIM(ISNULL(City,'')) AS City, RTRIM(ISNULL(StateCd,'')) AS StateCd," &
                "RTRIM(ISNULL(Zip,'')) AS Zip, RTRIM(ISNULL(Phone,'')) AS Phone, RTRIM(ISNULL(Fax,'')) AS Fax FROM FirmInfo"
            If GetData(sSQL, dt) > 0 Then
                row = dt.Rows(0)
                With AppData
                    .FirmAddress = row("Address")
                    .FirmCity = row("City")
                    .FirmName = row("Name")
                    .FirmPhone = row("Phone")
                    .FirmStateCd = row("StateCd")
                    .FirmZip = row("Zip")
                    .FirmFax = row("Fax")
                End With
            End If
            sSQL = "SELECT ConsultantName, ISNULL(ConsultantId,'') AS ConsultantId, ISNULL(FullName,'') AS FullName FROM Consultants WHERE ConsultantId = " &
                QuoStr(AppData.UserId)
            If GetData(sSQL, dt) > 0 Then
                row = dt.Rows(0)
                AppData.ConsultantName = row("ConsultantName").ToString.Trim
                AppData.FullName = row("FullName").ToString.Trim
            End If
            dt.Dispose()

            Return True
        Catch ex As Exception
            MsgBox("Error loading firm info:  " & ex.Message)
            Return False
        End Try
    End Function
    Public Function LoadDropDowns() As Boolean
        Dim dt As New DataTable, row As DataRow, sSQL As String = "", lRows As Long = 0
        Try
            colConsultants = New Collection
            GetData("SELECT ConsultantName FROM Consultants ORDER BY ConsultantName", dt)
            For Each row In dt.Rows
                colConsultants.Add(row("ConsultantName").ToString, row("ConsultantName"))
            Next

            colSICCodes = New Collection
            GetData("SELECT SICCode, SICCodeDescription FROM SICCodes ORDER BY SICCode", dt)
            For Each row In dt.Rows
                colSICCodes.Add(row("SICCode").ToString & "-" & row("SICCodeDescription").ToString, row("SICCode").ToString)
            Next

            dtFieldDataDefinition = New DataTable
            sSQL = "SELECT TableName, FieldName, FieldValue FROM FieldDataDefinition"
            lRows = GetData(sSQL, dtFieldDataDefinition)

            Return True
        Catch ex As Exception
            MsgBox("Error in LoadDropDowns:  " & ex.Message)
            Return False
        End Try
    End Function

    Public Function LoadStates() As Boolean
        Dim dtStateCodes As New DataTable, row As DataRow
        Try
            colStateCodes = New Collection
            colStateNames = New Collection
            GetData("SELECT StateCd, StateName FROM States ORDER BY StateName", dtStateCodes)
            For Each row In dtStateCodes.Rows
                colStateCodes.Add(row("StateName").ToString, row("StateCd"))
                colStateNames.Add(row("StateCd").ToString, row("StateName"))
            Next
            Return True
        Catch ex As Exception
            MsgBox("Error in LoadState:  " & ex.Message)
            Return False
        End Try
    End Function

    Private Function LoadDataDefinitions() As Boolean
        Dim sSQL As String, lRows As Long, row As DataRow
        Dim dt As DataTable

        Try

            sSQL = "SELECT t.name AS TableName, c.name AS FieldName, c.isnullable AS AllowNull," &
                " c.type AS FieldType, c.Length as FieldLength, fd.QueryVisibleFl, fd.QueryType, fd.Description AS FieldDescription" &
                " FROM sysobjects t, syscolumns c, FieldDefinition fd" &
                " WHERE t.id = c.id" &
                " AND fd.TableName = t.name AND fd.FieldName = c.name" &
                " AND t.type = 'U' AND t.name <> 'dtproperties'" &
                " ORDER BY t.name, c.name"
            lRows = GetData(sSQL, dtDataDefinitions)
            ReDim udtFieldInfo(lRows - 1)
            lRows = 0
            For Each row In dtDataDefinitions.Rows
                With udtFieldInfo(lRows)
                    .sField = row("FieldName")
                    .sTable = row("TableName")
                    .lType = row("FieldType")
                    .sFieldDescription = UnNullToString(row("FieldDescription"))
                    If IsDBNull(row("QueryVisibleFl")) Then
                        .bQueryVisibleFl = False
                    Else
                        .bQueryVisibleFl = row("QueryVisibleFl")
                    End If
                    .lQueryType = UnNullToDouble(row("QueryType"))
                End With
                lRows = lRows + 1
            Next
            Return True
        Catch ex As Exception
            MsgBox("Error in LoadDataDefintions:  " & ex.Message)
            Return False
        End Try
    End Function


    Public Sub GetDataDefinition(ByVal sTable As String, ByVal sField As String, _
            ByRef eDataType As enumDataTypes, ByRef bAllowNull As Boolean, _
            ByRef lLength As Long, ByRef sFieldDescription As String)
        Dim row As DataRow, drFiltered() As DataRow

        eDataType = enumDataTypes.eDataUnknown
        bAllowNull = False
        lLength = 0
        sFieldDescription = sField
        If dtDataDefinitions.Rows.Count = 0 Then
            If Not LoadDataDefinitions() Then Exit Sub
        End If
        drFiltered = dtDataDefinitions.Select("TableName = " & QuoStr(sTable) & " AND FieldName = " & QuoStr(sField))

        If drFiltered.Count > 0 Then
            row = drFiltered(0)
            Select Case row("FieldType")
                Case 38, 48, 52, 62, 63, 108, 109
                    eDataType = enumDataTypes.eDataNumber
                Case 39, 47
                    eDataType = enumDataTypes.eDataText
                Case 50
                    eDataType = enumDataTypes.eDataBit
                Case 61, 111
                    eDataType = enumDataTypes.eDataDate
            End Select
            If row("AllowNull") = 1 Then bAllowNull = True
            lLength = row("FieldLength")
            sFieldDescription = Trim(UnNullToString(row("FieldDescription")))
        End If
    End Sub

    Public Function QuoStr(ByVal sIn As String, Optional ByVal lLength As Long = 0) As String
        Return cData.QuoStr(sIn, lLength)
    End Function
    Public Function UnNullToString(ByVal vData As Object) As String
        If IsDBNull(vData) Then
            Return ""
        Else
            Return Trim(vData)
        End If
    End Function
    Public Function UnNullToDouble(ByVal vData As Object) As Double
        If IsDBNull(vData) Then
            Return 0
        ElseIf IsNumeric(vData) = False Then
            Return 0
        Else
            Return vData
        End If
    End Function

    Public Function IsIndexField(ByVal sFieldName As String) As Boolean
        Select Case sFieldName
            Case "ClientId", "LocationId", "AssessmentId", "AssessorId", "JurisdictionId", "CollectorId",
                    "FactorEntityId", "FactorEntityId1", "FactorId1", "FactorEntityId2", "FactorId2",
                    "FactorEntityId3", "FactorId3", "FactorEntityId4", "FactorId4", "FactorEntityId5",
                    "FactorId5", "TaskId", "TaskAssignmentId",
                    "Clients_ClientId", "Locations_LocationId", "AssessmentsBPP_AssessmentId",
                    "AssessmentsRE_AssessmentId", "ID", "ProspectValues_LocationId", "ProspectLocations_LocationId",
                    "InstallId", "QueryId", "BusinessUnitId"


                Return True
            Case Else
                Return False
        End Select
    End Function
    Public Sub LoadComboBox(ByVal sSQL As String, ByRef cbo As ComboBox, ByRef col As Collection)
        Dim dt As New DataTable, dr As DataRow

        'assumes dr(1) is name,address, etc
        'dr(0) is ClientId, LocationId, etc
        'loads dropdown with text and collection with text and id number so app can refer to collection
        'using dropdown selection
        GetData(sSQL, dt)
        For Each dr In dt.Rows
            cbo.Items.Add(dr(1))
            col.Add(dr(0), dr(1))
        Next






    End Sub


    Public Function ctlIndex(ByVal ctl As Control) As Integer
        'looks in tag property of control to find the index of the
        'fieldinfo structure in memory
        'should be at the end of the tag


        Dim i As Integer

        i = InStr(ctl.Tag, "@IDX=")
        If i = 0 Then
            Return -1
        Else
            Return Val(Right(ctl.Tag, Len(ctl.Tag) - (i + 4)))

        End If




    End Function

End Module