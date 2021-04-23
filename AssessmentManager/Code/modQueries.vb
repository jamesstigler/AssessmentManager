Module modQueries
    Public Enum UserQueryType
        Client = 1
        BPPLocation = 2
        RELocation = 4
        BPPAssessment = 8
        REAssessment = 16
        AllAssessment = 32
        BPPTaxes = 64
        RETaxes = 128
        AllTaxes = 256
        Prospects = 512
        ProspectLocations = 1024
        ProspectValues = 2048
    End Enum
    Public colUserQueries As Collection

    Public Class AskFilters
        Public Property QuerySeqNo() As Integer
        Public Property AskValue() As String
    End Class

    Public Function CopyQuery(ByVal lFromId As Long, ByVal sToName As String, ByRef sError As String) As Boolean
        Dim sSQL As StringBuilder = New StringBuilder, lId As Long = 0

        Try
            sError = "" : sSQL.Length = 0
            lId = CreateID(enumTable.enumQuery)
            sSQL.Append("INSERT UserQuery (QueryId, QueryType, QueryName, Description, OrderBy, QuerySQL, AddUser) SELECT ")
            sSQL.Append(lId).Append(", QueryType,").Append(QuoStr(sToName)).Append(",Description,OrderBy,QuerySQL,").Append(QuoStr(AppData.UserId))
            sSQL.Append(" FROM UserQuery WHERE QueryId = ").Append(lFromId)
            sSQL.Append(" INSERT UserQueryDetail (QueryId, QuerySeqNo, QueryOpenParen, QueryCondition, QueryField, QueryOperator,")
            sSQL.Append("QueryFieldValue, QueryValueType, QueryClosedParen, AddUser) SELECT ")
            sSQL.Append(lId).Append(",QuerySeqNo, QueryOpenParen, QueryCondition, QueryField, QueryOperator,")
            sSQL.Append("QueryFieldValue, QueryValueType, QueryClosedParen, ").Append(QuoStr(AppData.UserId))
            sSQL.Append(" FROM UserQueryDetail WHERE QueryId = ").Append(lFromId)
            sSQL.Append(" INSERT UserQuerySelect (QueryId, QuerySeqNo, QueryTable, QueryField, AddUser) SELECT ")
            sSQL.Append(lId).Append(",QuerySeqNo, QueryTable, QueryField,").Append(QuoStr(AppData.UserId))
            sSQL.Append(" FROM UserQuerySelect WHERE QueryId = ").Append(lFromId)
            ExecuteSQL(sSQL.ToString)

            Return True
        Catch ex As Exception
            sError = ex.Message
            Return False
        End Try
    End Function
    Public Function AddQuery(ByVal sName As String, ByVal enumQueryType As UserQueryType, ByRef sError As String) As Boolean
        Dim sSQL As String = "", lId As Long = 0

        Try
            sName = Trim(sName)
            If sName = "" Then
                Throw New ApplicationException("Query name not valid")
            End If
            lId = CreateID(enumTable.enumQuery)
            sSQL = "INSERT UserQuery (QueryId, QueryType, QueryName, AddUser)" &
                " SELECT " & lId & "," & enumQueryType & "," & QuoStr(sName) & "," & QuoStr(AppData.UserId)
            ExecuteSQL(sSQL)
            Select Case enumQueryType
                Case UserQueryType.AllAssessment
                    sSQL = "INSERT UserQueryDetail (QueryId, QuerySeqNo, QueryCondition, QueryField, QueryOperator, QueryFieldValue, QueryValueType)" &
                        " SELECT " & lId & ",0,''," & QuoStr("Clients.ProspectFl") & "," & QuoStr("=") & "," & QuoStr("0") & ",0"
                    sSQL = sSQL & " INSERT UserQueryDetail (QueryId, QuerySeqNo, QueryCondition, QueryField, QueryOperator, QueryFieldValue, QueryValueType)" &
                        " SELECT " & lId & ",1,'AND'," & QuoStr("Clients.InactiveFl") & "," & QuoStr("=") & "," & QuoStr("0") & ",0"
                    sSQL = sSQL & " INSERT UserQueryDetail (QueryId, QuerySeqNo, QueryCondition, QueryField, QueryOperator, QueryFieldValue, QueryValueType)" &
                        " SELECT " & lId & ",2,'AND'," & QuoStr("LocationsBPP.InactiveFl") & "," & QuoStr("=") & "," & QuoStr("0") & ",0"
                    sSQL = sSQL & " INSERT UserQueryDetail (QueryId, QuerySeqNo, QueryCondition, QueryField, QueryOperator, QueryFieldValue, QueryValueType)" &
                        " SELECT " & lId & ",3,'AND'," & QuoStr("LocationsRE.InactiveFl") & "," & QuoStr("=") & "," & QuoStr("0") & ",0"
                    sSQL = sSQL & " INSERT UserQueryDetail (QueryId, QuerySeqNo, QueryCondition, QueryField, QueryOperator, QueryFieldValue, QueryValueType)" &
                        " SELECT " & lId & ",4,'AND'," & QuoStr("AssessmentsBPP.InactiveFl") & "," & QuoStr("=") & "," & QuoStr("0") & ",0"
                    sSQL = sSQL & " INSERT UserQueryDetail (QueryId, QuerySeqNo, QueryCondition, QueryField, QueryOperator, QueryFieldValue, QueryValueType)" &
                        " SELECT " & lId & ",5,'AND'," & QuoStr("AssessmentsRE.InactiveFl") & "," & QuoStr("=") & "," & QuoStr("0") & ",0"
                    ExecuteSQL(sSQL)
                Case UserQueryType.AllTaxes
                    sSQL = " INSERT UserQueryDetail (QueryId, QuerySeqNo, QueryCondition, QueryField, QueryOperator, QueryFieldValue, QueryValueType)" &
                        " SELECT " & lId & ",0,''," & QuoStr("Clients.ProspectFl") & "," & QuoStr("=") & "," & QuoStr("0") & ",0"
                    sSQL = sSQL & " INSERT UserQueryDetail (QueryId, QuerySeqNo, QueryCondition, QueryField, QueryOperator, QueryFieldValue, QueryValueType)" &
                        " SELECT " & lId & ",1,'AND'," & QuoStr("Clients.InactiveFl") & "," & QuoStr("=") & "," & QuoStr("0") & ",0"
                    sSQL = sSQL & " INSERT UserQueryDetail (QueryId, QuerySeqNo, QueryCondition, QueryField, QueryOperator, QueryFieldValue, QueryValueType)" &
                        " SELECT " & lId & ",2,'AND'," & QuoStr("LocationsBPP.InactiveFl") & "," & QuoStr("=") & "," & QuoStr("0") & ",0"
                    sSQL = sSQL & " INSERT UserQueryDetail (QueryId, QuerySeqNo, QueryCondition, QueryField, QueryOperator, QueryFieldValue, QueryValueType)" &
                        " SELECT " & lId & ",3,'AND'," & QuoStr("LocationsRE.InactiveFl") & "," & QuoStr("=") & "," & QuoStr("0") & ",0"
                    sSQL = sSQL & " INSERT UserQueryDetail (QueryId, QuerySeqNo, QueryCondition, QueryField, QueryOperator, QueryFieldValue, QueryValueType)" &
                        " SELECT " & lId & ",4,'AND'," & QuoStr("AssessmentsBPP.InactiveFl") & "," & QuoStr("=") & "," & QuoStr("0") & ",0"
                    sSQL = sSQL & " INSERT UserQueryDetail (QueryId, QuerySeqNo, QueryCondition, QueryField, QueryOperator, QueryFieldValue, QueryValueType)" &
                        " SELECT " & lId & ",5,'AND'," & QuoStr("AssessmentsRE.InactiveFl") & "," & QuoStr("=") & "," & QuoStr("0") & ",0"
                    ExecuteSQL(sSQL)
                Case UserQueryType.BPPAssessment
                    sSQL = " INSERT UserQueryDetail (QueryId, QuerySeqNo, QueryCondition, QueryField, QueryOperator, QueryFieldValue, QueryValueType)" &
                        " SELECT " & lId & ",0,''," & QuoStr("Clients.ProspectFl") & "," & QuoStr("=") & "," & QuoStr("0") & ",0"
                    sSQL = sSQL & " INSERT UserQueryDetail (QueryId, QuerySeqNo, QueryCondition, QueryField, QueryOperator, QueryFieldValue, QueryValueType)" &
                        " SELECT " & lId & ",1,'AND'," & QuoStr("Clients.InactiveFl") & "," & QuoStr("=") & "," & QuoStr("0") & ",0"
                    sSQL = sSQL & " INSERT UserQueryDetail (QueryId, QuerySeqNo, QueryCondition, QueryField, QueryOperator, QueryFieldValue, QueryValueType)" &
                        " SELECT " & lId & ",2,'AND'," & QuoStr("LocationsBPP.InactiveFl") & "," & QuoStr("=") & "," & QuoStr("0") & ",0"
                    sSQL = sSQL & " INSERT UserQueryDetail (QueryId, QuerySeqNo, QueryCondition, QueryField, QueryOperator, QueryFieldValue, QueryValueType)" &
                        " SELECT " & lId & ",3,'AND'," & QuoStr("AssessmentsBPP.InactiveFl") & "," & QuoStr("=") & "," & QuoStr("0") & ",0"
                    ExecuteSQL(sSQL)
                Case UserQueryType.BPPLocation
                    sSQL = " INSERT UserQueryDetail (QueryId, QuerySeqNo, QueryCondition, QueryField, QueryOperator, QueryFieldValue, QueryValueType)" &
                        " SELECT " & lId & ",0,''," & QuoStr("Clients.ProspectFl") & "," & QuoStr("=") & "," & QuoStr("0") & ",0"
                    sSQL = sSQL & " INSERT UserQueryDetail (QueryId, QuerySeqNo, QueryCondition, QueryField, QueryOperator, QueryFieldValue, QueryValueType)" &
                        " SELECT " & lId & ",1,'AND'," & QuoStr("Clients.InactiveFl") & "," & QuoStr("=") & "," & QuoStr("0") & ",0"
                    sSQL = sSQL & " INSERT UserQueryDetail (QueryId, QuerySeqNo, QueryCondition, QueryField, QueryOperator, QueryFieldValue, QueryValueType)" &
                        " SELECT " & lId & ",2,'AND'," & QuoStr("LocationsBPP.InactiveFl") & "," & QuoStr("=") & "," & QuoStr("0") & ",0"
                    ExecuteSQL(sSQL)
                Case UserQueryType.BPPTaxes
                    sSQL = " INSERT UserQueryDetail (QueryId, QuerySeqNo, QueryCondition, QueryField, QueryOperator, QueryFieldValue, QueryValueType)" &
                        " SELECT " & lId & ",0,''," & QuoStr("Clients.ProspectFl") & "," & QuoStr("=") & "," & QuoStr("0") & ",0"
                    sSQL = sSQL & " INSERT UserQueryDetail (QueryId, QuerySeqNo, QueryCondition, QueryField, QueryOperator, QueryFieldValue, QueryValueType)" &
                        " SELECT " & lId & ",1,'AND'," & QuoStr("Clients.InactiveFl") & "," & QuoStr("=") & "," & QuoStr("0") & ",0"
                    sSQL = sSQL & " INSERT UserQueryDetail (QueryId, QuerySeqNo, QueryCondition, QueryField, QueryOperator, QueryFieldValue, QueryValueType)" &
                        " SELECT " & lId & ",2,'AND'," & QuoStr("LocationsBPP.InactiveFl") & "," & QuoStr("=") & "," & QuoStr("0") & ",0"
                    sSQL = sSQL & " INSERT UserQueryDetail (QueryId, QuerySeqNo, QueryCondition, QueryField, QueryOperator, QueryFieldValue, QueryValueType)" &
                        " SELECT " & lId & ",3,'AND'," & QuoStr("AssessmentsBPP.InactiveFl") & "," & QuoStr("=") & "," & QuoStr("0") & ",0"
                    ExecuteSQL(sSQL)
                Case UserQueryType.Client
                    sSQL = " INSERT UserQueryDetail (QueryId, QuerySeqNo, QueryCondition, QueryField, QueryOperator, QueryFieldValue, QueryValueType)" &
                        " SELECT " & lId & ",0,''," & QuoStr("Clients.ProspectFl") & "," & QuoStr("=") & "," & QuoStr("0") & ",0"
                    sSQL = sSQL & " INSERT UserQueryDetail (QueryId, QuerySeqNo, QueryCondition, QueryField, QueryOperator, QueryFieldValue, QueryValueType)" &
                        " SELECT " & lId & ",1,'AND'," & QuoStr("Clients.InactiveFl") & "," & QuoStr("=") & "," & QuoStr("0") & ",0"
                    ExecuteSQL(sSQL)
                Case UserQueryType.ProspectLocations, UserQueryType.ProspectValues
                    sSQL = " INSERT UserQueryDetail (QueryId, QuerySeqNo, QueryCondition, QueryField, QueryOperator, QueryFieldValue, QueryValueType)" &
                        " SELECT " & lId & ",0,''," & QuoStr("Clients.ProspectFl") & "," & QuoStr("=") & "," & QuoStr("1") & ",0"
                    sSQL = sSQL & " INSERT UserQueryDetail (QueryId, QuerySeqNo, QueryCondition, QueryField, QueryOperator, QueryFieldValue, QueryValueType)" &
                        " SELECT " & lId & ",1,'AND'," & QuoStr("Clients.InactiveFl") & "," & QuoStr("=") & "," & QuoStr("0") & ",0"
                    ExecuteSQL(sSQL)
                Case UserQueryType.Prospects
                    sSQL = " INSERT UserQueryDetail (QueryId, QuerySeqNo, QueryCondition, QueryField, QueryOperator, QueryFieldValue, QueryValueType)" &
                        " SELECT " & lId & ",0,''," & QuoStr("Clients.ProspectFl") & "," & QuoStr("=") & "," & QuoStr("1") & ",0"
                    sSQL = sSQL & " INSERT UserQueryDetail (QueryId, QuerySeqNo, QueryCondition, QueryField, QueryOperator, QueryFieldValue, QueryValueType)" &
                        " SELECT " & lId & ",1,'AND'," & QuoStr("Clients.InactiveFl") & "," & QuoStr("=") & "," & QuoStr("0") & ",0"
                    ExecuteSQL(sSQL)
                Case UserQueryType.REAssessment
                    sSQL = " INSERT UserQueryDetail (QueryId, QuerySeqNo, QueryCondition, QueryField, QueryOperator, QueryFieldValue, QueryValueType)" &
                        " SELECT " & lId & ",0,''," & QuoStr("Clients.ProspectFl") & "," & QuoStr("=") & "," & QuoStr("0") & ",0"
                    sSQL = sSQL & " INSERT UserQueryDetail (QueryId, QuerySeqNo, QueryCondition, QueryField, QueryOperator, QueryFieldValue, QueryValueType)" &
                        " SELECT " & lId & ",1,'AND'," & QuoStr("Clients.InactiveFl") & "," & QuoStr("=") & "," & QuoStr("0") & ",0"
                    sSQL = sSQL & " INSERT UserQueryDetail (QueryId, QuerySeqNo, QueryCondition, QueryField, QueryOperator, QueryFieldValue, QueryValueType)" &
                        " SELECT " & lId & ",2,'AND'," & QuoStr("LocationsRE.InactiveFl") & "," & QuoStr("=") & "," & QuoStr("0") & ",0"
                    sSQL = sSQL & " INSERT UserQueryDetail (QueryId, QuerySeqNo, QueryCondition, QueryField, QueryOperator, QueryFieldValue, QueryValueType)" &
                        " SELECT " & lId & ",3,'AND'," & QuoStr("AssessmentsRE.InactiveFl") & "," & QuoStr("=") & "," & QuoStr("0") & ",0"
                    ExecuteSQL(sSQL)
                Case UserQueryType.RELocation
                    sSQL = " INSERT UserQueryDetail (QueryId, QuerySeqNo, QueryCondition, QueryField, QueryOperator, QueryFieldValue, QueryValueType)" &
                        " SELECT " & lId & ",0,''," & QuoStr("Clients.ProspectFl") & "," & QuoStr("=") & "," & QuoStr("0") & ",0"
                    sSQL = sSQL & " INSERT UserQueryDetail (QueryId, QuerySeqNo, QueryCondition, QueryField, QueryOperator, QueryFieldValue, QueryValueType)" &
                        " SELECT " & lId & ",1,'AND'," & QuoStr("Clients.InactiveFl") & "," & QuoStr("=") & "," & QuoStr("0") & ",0"
                    sSQL = sSQL & " INSERT UserQueryDetail (QueryId, QuerySeqNo, QueryCondition, QueryField, QueryOperator, QueryFieldValue, QueryValueType)" &
                        " SELECT " & lId & ",3,'AND'," & QuoStr("LocationsRE.InactiveFl") & "," & QuoStr("=") & "," & QuoStr("0") & ",0"
                    ExecuteSQL(sSQL)
                Case UserQueryType.RETaxes
                    sSQL = " INSERT UserQueryDetail (QueryId, QuerySeqNo, QueryCondition, QueryField, QueryOperator, QueryFieldValue, QueryValueType)" &
                        " SELECT " & lId & ",0,''," & QuoStr("Clients.ProspectFl") & "," & QuoStr("=") & "," & QuoStr("0") & ",0"
                    sSQL = sSQL & " INSERT UserQueryDetail (QueryId, QuerySeqNo, QueryCondition, QueryField, QueryOperator, QueryFieldValue, QueryValueType)" &
                        " SELECT " & lId & ",1,'AND'," & QuoStr("Clients.InactiveFl") & "," & QuoStr("=") & "," & QuoStr("0") & ",0"
                    sSQL = sSQL & " INSERT UserQueryDetail (QueryId, QuerySeqNo, QueryCondition, QueryField, QueryOperator, QueryFieldValue, QueryValueType)" &
                        " SELECT " & lId & ",2,'AND'," & QuoStr("LocationsRE.InactiveFl") & "," & QuoStr("=") & "," & QuoStr("0") & ",0"
                    sSQL = sSQL & " INSERT UserQueryDetail (QueryId, QuerySeqNo, QueryCondition, QueryField, QueryOperator, QueryFieldValue, QueryValueType)" &
                        " SELECT " & lId & ",3,'AND'," & QuoStr("AssessmentsRE.InactiveFl") & "," & QuoStr("=") & "," & QuoStr("0") & ",0"
                    ExecuteSQL(sSQL)
            End Select


            Return True
        Catch ex As Exception
            sError = ex.Message
            Return False
        End Try
    End Function
    Public Function BuildAskList(ByVal lQueryId As Long) As List(Of AskFilters)
        Dim AskList As New List(Of AskFilters), sql As New StringBuilder
        Dim sAsk As String, askfilter As New AskFilters, sDefault As String = ""

        sql.Clear()
        sql.Append("SELECT QuerySeqNo, ISNULL(QueryField,'') AS QueryField FROM UserQueryDetail WHERE QueryId = ").Append(lQueryId.ToString)
        sql.Append(" AND QueryValueType = '1' ORDER BY QuerySeqNo")
        Dim dt As New DataTable
        GetData(sql.ToString, dt)
        For Each dr As DataRow In dt.Rows
            sAsk = InputBox("Enter value for " & dr("QueryField").ToString, "Ask", sDefault).Trim
            askfilter = New AskFilters With {.AskValue = sAsk, .QuerySeqNo = dr("QuerySeqNo")}
            AskList.Add(askfilter)
        Next
        dt.Dispose()

        Return AskList
    End Function
    Public Sub BuildQuerySQL(ByVal lQueryId As Long, ByVal ListOfAskFilters As List(Of AskFilters), ByRef sIndexFields As List(Of String),
            ByRef sQueryName As String, ByRef enumQueryType As UserQueryType, ByRef sQuerySQL As String)
        Dim sSQL As String = "", dtUserQuery As New DataTable, lRows As Long = 0, dr As DataRow
        Dim dtUserQuerySelect As New DataTable, dtUserQueryDetail As New DataTable
        Dim cQuery As clsQuery, cSelect As clsQuerySelect, cUserQuery As clsUserQuery
        Dim sSELECT As String = "", sUserSELECT As String = "", sWHERE As String = "", sORDERBY As String
        Dim sPropType As String = "", sTable As String = "", sField As String = ""
        Dim eDataType As enumDataTypes, bAllowNull As Boolean, lLength As Long = 0, sDesc As String = ""
        Dim sQueryFieldValue As String = ""
        Dim bOnlyCurrentConsultant As Boolean = False

        sIndexFields = New List(Of String) : sQueryName = "" : sQuerySQL = ""

        sSQL = "SELECT QueryType, QueryName, ISNULL(OrderBy,'') AS OrderBy, ISNULL(CurrentConsultantFl,0) AS CurrentConsultantFl FROM UserQuery WHERE QueryId = " & lQueryId
        lRows = GetData(sSQL, dtUserQuery)
        If lRows = 0 Then Exit Sub
        dr = dtUserQuery.Rows(0)
        sQueryName = dr("QueryName")
        cUserQuery = colUserQueries.Item(CStr(dr("QueryType")))
        enumQueryType = dr("QueryType")
        sORDERBY = Trim(dr("OrderBy"))
        bOnlyCurrentConsultant = IIf(dr("CurrentConsultantFl") = 0, False, True)

        If sORDERBY <> "" Then
            'If enumQueryType = UserQueryType.AllAssessment Or enumQueryType = UserQueryType.AllTaxes Then
            '    sORDERBY = Replace(sORDERBY, "LocationsBPP", "Locations", 1, , CompareMethod.Binary)
            '    sORDERBY = Replace(sORDERBY, "LocationsRE", "Locations", 1, , CompareMethod.Binary)
            '    sORDERBY = Replace(sORDERBY, "AssessmentsBPP", "Assessments", 1, , CompareMethod.Binary)
            '    sORDERBY = Replace(sORDERBY, "AssessmentsRE", "Assessments", 1, , CompareMethod.Binary)
            '    sORDERBY = Replace(sORDERBY, "AssessmentDetailBPP", "AssessmentDetail", 1, , CompareMethod.Binary)
            '    sORDERBY = Replace(sORDERBY, "AssessmentDetailRE", "AssessmentDetail", 1, , CompareMethod.Binary)
            sORDERBY = Replace(sORDERBY, ".", "_", 1, , CompareMethod.Binary)
            '    arrayOrderBy = Split(sORDERBY, ",")
            '    sORDERBY = ""
            '    Dim i As Integer = 0
            '    sORDERBY = arrayOrderBy(0)
            '    For i = 0 To UBound(arrayOrderBy)
            '        If InStr(sORDERBY, arrayOrderBy(i), CompareMethod.Binary) = 0 Then
            '            sORDERBY = sORDERBY & "," & arrayOrderBy(i)
            '        End If
            '    Next
            'End If
            sORDERBY = " ORDER BY " & sORDERBY
        End If
        sSQL = "SELECT QueryTable, QueryField FROM UserQuerySelect WHERE QueryId = " & lQueryId & " ORDER BY QuerySeqNo"
        GetData(sSQL, dtUserQuerySelect)
        sSQL = "SELECT ISNULL(QueryCondition,'') AS QueryCondition, ISNULL(QueryOpenParen,'') AS QueryOpenParen, ISNULL(QueryField,'') AS QueryField," &
            " ISNULL(QueryOperator,'') AS QueryOperator, ISNULL(QueryFieldValue,'') AS QueryFieldValue," &
            " ISNULL(QueryClosedParen,'') AS QueryClosedParen, ISNULL(QueryValueType,'') AS QueryValueType, QuerySeqNo" &
            " FROM UserQueryDetail WHERE QueryId = " & lQueryId & " ORDER BY QuerySeqNo"
        GetData(sSQL, dtUserQueryDetail)

        sPropType = ""
        For Each cQuery In cUserQuery.Queries
            If sQuerySQL <> "" Then sQuerySQL = sQuerySQL & " UNION "
            If enumQueryType = UserQueryType.AllTaxes Or enumQueryType = UserQueryType.AllAssessment Then
                If sPropType = "" Then
                    sPropType = "BPP"
                Else
                    sPropType = "RE"
                End If
            End If
            'sPropType = ""
            'For Each cSelect In cQuery.SelectList
            '    If cSelect.QueryTable = "LocationsBPP" Then
            '        sPropType = "BPP"
            '    ElseIf cSelect.QueryTable = "LocationsRE" Then
            '        sPropType = "RE"
            '    End If
            'Next

            sUserSELECT = ""
            For Each dr In dtUserQuerySelect.Rows
                If sUserSELECT <> "" Then sUserSELECT = sUserSELECT & ","
                If sPropType = "BPP" And
                        (dr("QueryTable") = "LocationsRE" Or
                        dr("QueryTable") = "AssessmentsRE" Or
                        dr("QueryTable") = "AssessmentDetailRE") Then
                    sUserSELECT = sUserSELECT & " NULL AS " & dr("QueryTable") & "_" & dr("QueryField")

                ElseIf sPropType = "RE" And
                        (dr("QueryTable") = "LocationsBPP" Or
                        dr("QueryTable") = "AssessmentsBPP" Or
                        dr("QueryTable") = "AssessmentDetailBPP") Then
                    sUserSELECT = sUserSELECT & " NULL AS " & dr("QueryTable") & "_" & dr("QueryField")

                Else

                    'If enumQueryType = UserQueryType.AllAssessment Or enumQueryType = UserQueryType.AllTaxes Then
                    '    If dr("QueryTable") = "LocationsBPP" Or dr("QueryTable") = "LocationsRE" Then
                    '        sUserSELECT = sUserSELECT & dr("QueryTable") & "." & dr("QueryField") & " AS Locations_" & dr("QueryField")
                    '    ElseIf dr("QueryTable") = "AssessmentsBPP" Or dr("QueryTable") = "AssessmentsRE" Then
                    '        sUserSELECT = sUserSELECT & dr("QueryTable") & "." & dr("QueryField") & " AS Assessments_" & dr("QueryField")
                    '    ElseIf dr("QueryTable") = "AssessmentDetailBPP" Or dr("QueryTable") = "AssessmentDetailRE" Then
                    '        sUserSELECT = sUserSELECT & dr("QueryTable") & "." & dr("QueryField") & " AS AssessmentDetail_" & dr("QueryField")
                    '    Else
                    '        sUserSELECT = sUserSELECT & dr("QueryTable") & "." & dr("QueryField") & " AS " & dr("QueryTable") & "_" & dr("QueryField")
                    '    End If
                    'Else

                    sTable = dr("QueryTable")
                    sField = dr("QueryField")
                    GetDataDefinition(sTable, sField, eDataType, bAllowNull, lLength, sDesc)
                    If eDataType = enumDataTypes.eDataText Then
                        sUserSELECT = sUserSELECT & "REPLACE(REPLACE(" & sTable & "." & sField & ",CHAR(9),' '),CHAR(13)+CHAR(10),' ')"
                        sUserSELECT = sUserSELECT & " AS " & sTable & "_" & sField
                    Else
                        'sUserSELECT = sUserSELECT & dr("QueryTable") & "." & dr("QueryField") & " AS " & dr("QueryTable") & "_" & dr("QueryField")
                        sUserSELECT = sUserSELECT & sTable & "." & sField & " AS " & sTable & "_" & sField
                    End If
                End If
            Next
            sUserSELECT = sUserSELECT & " "

            sWHERE = ""
            For Each dr In dtUserQueryDetail.Rows
                sQueryFieldValue = ""
                '1 is ASK
                If dr("QueryValueType") = "1" Then
                    For Each askfilter As AskFilters In ListOfAskFilters
                        If askfilter.QuerySeqNo = dr("QuerySeqNo") Then sQueryFieldValue = askfilter.AskValue
                    Next
                Else
                    sQueryFieldValue = dr("QueryFieldValue").ToString.Trim
                End If

                If sPropType = "BPP" And
                    (InStr(dr("QueryField"), "LocationsRE") > 0 Or
                     InStr(dr("QueryField"), "AssessmentsRE") > 0 Or
                     InStr(dr("QueryField"), "AssessmentDetailRE") > 0) Then
                ElseIf sPropType = "RE" And
                    (InStr(dr("QueryField"), "LocationsBPP") > 0 Or
                     InStr(dr("QueryField"), "AssessmentsBPP") > 0 Or
                     InStr(dr("QueryField"), "AssessmentDetailBPP") > 0) Then
                Else
                    sTable = Trim(Microsoft.VisualBasic.Left(dr("QueryField"), InStr(dr("QueryField"), ".", CompareMethod.Text) - 1))
                    sField = Trim(Microsoft.VisualBasic.Right(dr("QueryField"), Len(dr("QueryField")) - Len(sTable) - 1))
                    GetDataDefinition(sTable, sField, eDataType, bAllowNull, lLength, sDesc)
                    'AND (
                    If sWHERE <> "" Then
                        sWHERE = sWHERE & " " & dr("QueryCondition") & " " & dr("QueryOpenParen") & " "
                    End If

                    If bAllowNull And eDataType <> enumDataTypes.eDataDate And eDataType <> enumDataTypes.eDataDateTime Then
                        'isnull(
                        sWHERE = sWHERE & " ISNULL( "
                    End If

                    'where table.field
                    If eDataType = enumDataTypes.eDataDate Or eDataType = enumDataTypes.eDataDateTime Then
                        If sQueryFieldValue = "" Then
                            'if datetime field and filtering for empty date, use table.field
                            sWHERE = sWHERE & " " & dr("QueryField") & " "
                        Else
                            'if datetime field and filter has date, use convert (convert(datetime,table.field)) = convert(datetime,'12/31/2000')
                            sWHERE = sWHERE & " CONVERT(DATETIME," & dr("QueryField") & ") "
                        End If
                    Else
                        'table.field       
                        sWHERE = sWHERE & " " & dr("QueryField") & " "
                    End If

                    'isnull(table.field,'') for non date fields
                    If bAllowNull And eDataType <> enumDataTypes.eDataDate And eDataType <> enumDataTypes.eDataDateTime Then
                        sWHERE = sWHERE & " , "
                        If eDataType = enumDataTypes.eDataText Then
                            sWHERE = sWHERE & " '' "
                        ElseIf eDataType = enumDataTypes.eDataBit Or eDataType = enumDataTypes.eDataNumber Then
                            sWHERE = sWHERE & " 0 "
                        End If
                        sWHERE = sWHERE & " ) "
                    End If

                    'OPERATOR
                    If eDataType = enumDataTypes.eDataDate Or eDataType = enumDataTypes.eDataDateTime Then
                        If sQueryFieldValue = "" Then
                            If dr("QueryOperator") = "=" Then
                                sWHERE = sWHERE & " IS "
                            Else
                                sWHERE = sWHERE & " IS NOT "
                            End If
                        Else
                            If dr("QueryOperator") = "=" Then
                                sWHERE = sWHERE & " >= "
                            Else
                                sWHERE = sWHERE & " " & dr("QueryOperator") & " "
                            End If
                        End If
                    Else
                        sWHERE = sWHERE & " " & dr("QueryOperator") & " "
                    End If

                    'value for table.field to compare against 
                    Select Case eDataType
                        Case enumDataTypes.eDataText
                            sWHERE = sWHERE & " " & QuoStr(sQueryFieldValue) & " "
                        Case enumDataTypes.eDataDate, enumDataTypes.eDataDateTime
                            If sQueryFieldValue = "" Then
                                'if empty use NULL, result may be is null or is not null
                                sWHERE = sWHERE & " NULL "
                            Else
                                sWHERE = sWHERE & " CONVERT(DATETIME," & QuoStr(sQueryFieldValue) & ") "
                                If dr("QueryOperator") = "=" Then
                                    sWHERE = sWHERE & " AND CONVERT(DATETIME," & dr("QueryField") & ") < "
                                    sWHERE = sWHERE & " CONVERT(DATETIME," & QuoStr(DateAdd(DateInterval.Day, 1, CDate(CDate(sQueryFieldValue).ToString("MM/dd/yyyy")))) & ") "
                                End If
                            End If
                        Case Else
                            If IsNumeric(sQueryFieldValue) Then
                                sWHERE = sWHERE & " " & sQueryFieldValue & " "
                            Else
                                sWHERE = sWHERE & " 0 "
                            End If
                    End Select

                    sWHERE = sWHERE & " " & dr("QueryClosedParen") & " "
                End If
            Next

            sSELECT = sUserSELECT.Trim
            For Each cSelect In cQuery.SelectList
                sIndexFields.Add(cSelect.QueryAlias)
                If sSELECT <> "" Then sSELECT = sSELECT & ","
                If cSelect.QueryField = "" Then
                    sSELECT = sSELECT & cSelect.QueryAlias
                Else
                    sSELECT = sSELECT & cSelect.QueryTable & "." & cSelect.QueryField & " AS " & cSelect.QueryAlias
                End If
            Next
            sQuerySQL = sQuerySQL & " SELECT " & sSELECT & " " & cQuery.JoinStatement
            'If enumQueryType = UserQueryType.AllAssessment Or enumQueryType = UserQueryType.AllTaxes Or enumQueryType = UserQueryType.BPPAssessment Or _
            '        enumQueryType = UserQueryType.BPPLocation Or enumQueryType = UserQueryType.BPPTaxes Or enumQueryType = UserQueryType.REAssessment Or _
            '        enumQueryType = UserQueryType.RELocation Or enumQueryType = UserQueryType.RETaxes Then
            '    If sWHERE = "" Then
            '        sWHERE = " WHERE "
            '    Else
            '        sWHERE = sWHERE & " AND "
            '    End If
            '    sWHERE = sWHERE & " Locations" & sPropType & ".TaxYear = " & AppData.TaxYear
            'End If

            If bOnlyCurrentConsultant Then
                If cQuery.JoinStatement.Contains("LocationsBPP.") And cQuery.JoinStatement.Contains("Clients.") Then
                    sWHERE = sWHERE & " AND ISNULL(LocationsBPP.ConsultantName,Clients.BPPConsultantName) = " & QuoStr(AppData.ConsultantName)
                End If
            End If


            If cQuery.WhereClause = "" Then
                sWHERE = " WHERE " & sWHERE
            Else
                sWHERE = cQuery.WhereClause & " AND " & sWHERE
            End If
            sQuerySQL = sQuerySQL & sWHERE
        Next
        sQuerySQL = Replace(sQuerySQL, "[TaxYear]", AppData.TaxYear)
        sQuerySQL = sQuerySQL & sORDERBY





    End Sub




    Public Sub InitializeQueries()
        Dim sSQL As String = "", cQuery As clsQuery, cSelect As clsQuerySelect, cUserQuery As clsUserQuery
        Dim sSELECT As String = ""
        'colUserQueries (collection of clsUserQuery)
        '   clsUserQuery
        '       collection of clsQuery
        '           select list (collection of clsQuerySelect)
        '               QueryTable
        '               QueryField
        '               QueryAlias
        '           Join Statement string

        'include every keyfield from every table in join.  Will use these keys to update from the list directly

        colUserQueries = New Collection

        'Clients table only
        cUserQuery = New clsUserQuery With {
            .QueryType = UserQueryType.Client,
            .Queries = New Collection
        }
        cQuery = New clsQuery With {
            .SelectList = New Collection
        }
        cSelect = New clsQuerySelect
        cQuery.JoinStatement = "FROM Clients"
        cQuery.WhereClause = ""
        cSelect.QueryTable = "Clients"
        cSelect.QueryField = "ClientId"
        cSelect.QueryAlias = "Clients_ClientId"
        cQuery.SelectList.Add(cSelect)
        cUserQuery.Queries.Add(cQuery)
        colUserQueries.Add(cUserQuery, UserQueryType.Client)

        'BPPLocations:  Clients/LocationsBPP
        cUserQuery = New clsUserQuery With {
            .QueryType = UserQueryType.BPPLocation,
            .Queries = New Collection
        }
        cQuery = New clsQuery With {
            .SelectList = New Collection
        }
        cSelect = New clsQuerySelect
        cQuery.JoinStatement = "FROM Clients INNER JOIN LocationsBPP ON Clients.ClientId = LocationsBPP.ClientId"
        cQuery.WhereClause = " WHERE LocationsBPP.TaxYear = [TaxYear]"
        cSelect.QueryTable = "Clients"
        cSelect.QueryField = "ClientId"
        cSelect.QueryAlias = "Clients_ClientId"
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "LocationsBPP",
            .QueryField = "ClientId",
            .QueryAlias = "LocationsBPP_ClientId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "LocationsBPP",
            .QueryField = "LocationId",
            .QueryAlias = "LocationsBPP_LocationId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "LocationsBPP",
            .QueryField = "TaxYear",
            .QueryAlias = "LocationsBPP_TaxYear"
        }
        cQuery.SelectList.Add(cSelect)
        cUserQuery.Queries.Add(cQuery)
        colUserQueries.Add(cUserQuery, UserQueryType.BPPLocation)

        'RE Locations:  Clients/LocationsRE
        cUserQuery = New clsUserQuery With {
            .QueryType = UserQueryType.RELocation,
            .Queries = New Collection
        }
        cQuery = New clsQuery With {
            .SelectList = New Collection
        }
        cSelect = New clsQuerySelect
        cQuery.JoinStatement = "FROM Clients INNER JOIN LocationsRE ON Clients.ClientId = LocationsRE.ClientId"
        cQuery.WhereClause = " WHERE LocationsRE.TaxYear = [TaxYear]"
        cSelect.QueryTable = "Clients"
        cSelect.QueryField = "ClientId"
        cSelect.QueryAlias = "Clients_ClientId"
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "LocationsRE",
            .QueryField = "ClientId",
            .QueryAlias = "LocationsRE_ClientId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "LocationsRE",
            .QueryField = "LocationId",
            .QueryAlias = "LocationsRE_LocationId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "LocationsRE",
            .QueryField = "TaxYear",
            .QueryAlias = "LocationsRE_TaxYear"
        }
        cQuery.SelectList.Add(cSelect)
        cUserQuery.Queries.Add(cQuery)
        colUserQueries.Add(cUserQuery, UserQueryType.RELocation)

        'BPPAssessments:  Clients/LocationsBPP/AssessmentsBPP
        cUserQuery = New clsUserQuery With {
            .QueryType = UserQueryType.BPPAssessment,
            .Queries = New Collection
        }
        cQuery = New clsQuery With {
            .SelectList = New Collection
        }
        cSelect = New clsQuerySelect
        cQuery.JoinStatement = "FROM Clients INNER JOIN LocationsBPP ON Clients.ClientId = LocationsBPP.ClientId" &
            " INNER JOIN AssessmentsBPP ON LocationsBPP.ClientId = AssessmentsBPP.ClientId" &
            " AND LocationsBPP.LocationId = AssessmentsBPP.LocationId And LocationsBPP.TaxYear = AssessmentsBPP.TaxYear" &
            " LEFT OUTER JOIN Assessors ON AssessmentsBPP.AssessorId = Assessors.AssessorId" &
            " AND AssessmentsBPP.TaxYear = Assessors.TaxYear" &
            " LEFT OUTER JOIN BusinessUnits ON AssessmentsBPP.ClientId = BusinessUnits.ClientId AND AssessmentsBPP.BusinessUnitId = BusinessUnits.BusinessUnitId"
        cQuery.WhereClause = " WHERE LocationsBPP.TaxYear = [TaxYear]"
        cSelect.QueryTable = "Clients"
        cSelect.QueryField = "ClientId"
        cSelect.QueryAlias = "Clients_ClientId"
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "LocationsBPP",
            .QueryField = "ClientId",
            .QueryAlias = "LocationsBPP_ClientId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "LocationsBPP",
            .QueryField = "LocationId",
            .QueryAlias = "LocationsBPP_LocationId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "LocationsBPP",
            .QueryField = "TaxYear",
            .QueryAlias = "LocationsBPP_TaxYear"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "AssessmentsBPP",
            .QueryField = "ClientId",
            .QueryAlias = "AssessmentsBPP_ClientId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "AssessmentsBPP",
            .QueryField = "LocationId",
            .QueryAlias = "AssessmentsBPP_LocationId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "AssessmentsBPP",
            .QueryField = "AssessmentId",
            .QueryAlias = "AssessmentsBPP_AssessmentId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "AssessmentsBPP",
            .QueryField = "TaxYear",
            .QueryAlias = "AssessmentsBPP_TaxYear"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "Assessors",
            .QueryField = "AssessorId",
            .QueryAlias = "Assessors_AssessorId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "Assessors",
            .QueryField = "TaxYear",
            .QueryAlias = "Assessors_TaxYear"
        }
        cQuery.SelectList.Add(cSelect)
        'cSelect = New clsQuerySelect
        'cSelect.QueryTable = "BusinessUnits"
        'cSelect.QueryField = "Name"
        'cSelect.QueryAlias = "BusinessUnits_Name"
        'cQuery.SelectList.Add(cSelect)
        cUserQuery.Queries.Add(cQuery)
        colUserQueries.Add(cUserQuery, UserQueryType.BPPAssessment)

        'RE Assessments:  Clients/LocationsRE/AssessmentsRE
        cUserQuery = New clsUserQuery With {
            .Queries = New Collection,
            .QueryType = UserQueryType.REAssessment
        }
        cQuery = New clsQuery With {
            .SelectList = New Collection
        }
        cSelect = New clsQuerySelect
        cQuery.JoinStatement = "FROM Clients INNER JOIN LocationsRE ON Clients.ClientId = LocationsRE.ClientId" &
            " INNER JOIN AssessmentsRE ON LocationsRE.ClientId = AssessmentsRE.ClientId" &
            " AND LocationsRE.LocationId = AssessmentsRE.LocationId And LocationsRE.TaxYear = AssessmentsRE.TaxYear" &
            " LEFT OUTER JOIN Assessors ON AssessmentsRE.AssessorId = Assessors.AssessorId" &
            " AND AssessmentsRE.TaxYear = Assessors.TaxYear" &
            " LEFT OUTER JOIN BusinessUnits ON AssessmentsRE.ClientId = BusinessUnits.ClientId AND AssessmentsRE.BusinessUnitId = BusinessUnits.BusinessUnitId"
        cQuery.WhereClause = " WHERE LocationsRE.TaxYear = [TaxYear]"
        cSelect.QueryTable = "Clients"
        cSelect.QueryField = "ClientId"
        cSelect.QueryAlias = "Clients_ClientId"
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "LocationsRE",
            .QueryField = "ClientId",
            .QueryAlias = "LocationsRE_ClientId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "LocationsRE",
            .QueryField = "LocationId",
            .QueryAlias = "LocationsRE_LocationId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "LocationsRE",
            .QueryField = "TaxYear",
            .QueryAlias = "LocationsRE_TaxYear"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "AssessmentsRE",
            .QueryField = "ClientId",
            .QueryAlias = "AssessmentsRE_ClientId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "AssessmentsRE",
            .QueryField = "LocationId",
            .QueryAlias = "AssessmentsRE_LocationId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "AssessmentsRE",
            .QueryField = "AssessmentId",
            .QueryAlias = "AssessmentsRE_AssessmentId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "AssessmentsRE",
            .QueryField = "TaxYear",
            .QueryAlias = "AssessmentsRE_TaxYear"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "Assessors",
            .QueryField = "AssessorId",
            .QueryAlias = "Assessors_AssessorId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "Assessors",
            .QueryField = "TaxYear",
            .QueryAlias = "Assessors_TaxYear"
        }
        cQuery.SelectList.Add(cSelect)
        'cSelect = New clsQuerySelect
        'cSelect.QueryTable = "BusinessUnits"
        'cSelect.QueryField = "Name"
        'cSelect.QueryAlias = "BusinessUnits_Name"
        'cQuery.SelectList.Add(cSelect)
        cUserQuery.Queries.Add(cQuery)
        colUserQueries.Add(cUserQuery, UserQueryType.REAssessment)

        'All Assessments:  Clients/LocationsBPP/AssessmentsBPP UNION Clients/LocationsRE/AssessmentsRE
        cUserQuery = New clsUserQuery With {
            .QueryType = UserQueryType.AllAssessment,
            .Queries = New Collection
        }
        'BPP part
        cQuery = New clsQuery With {
            .SelectList = New Collection
        }
        cSelect = New clsQuerySelect
        cQuery.JoinStatement = "FROM Clients INNER JOIN LocationsBPP ON Clients.ClientId = LocationsBPP.ClientId" &
            " INNER JOIN AssessmentsBPP ON LocationsBPP.ClientId = AssessmentsBPP.ClientId" &
            " AND LocationsBPP.LocationId = AssessmentsBPP.LocationId And LocationsBPP.TaxYear = AssessmentsBPP.TaxYear" &
            " LEFT OUTER JOIN Assessors ON AssessmentsBPP.AssessorId = Assessors.AssessorId" &
            " AND AssessmentsBPP.TaxYear = Assessors.TaxYear" &
            " LEFT OUTER JOIN BusinessUnits ON AssessmentsBPP.ClientId = BusinessUnits.ClientId AND AssessmentsBPP.BusinessUnitId = BusinessUnits.BusinessUnitId"
        cQuery.WhereClause = " WHERE LocationsBPP.TaxYear = [TaxYear]"
        cSelect.QueryTable = "Clients"
        cSelect.QueryField = "ClientId"
        cSelect.QueryAlias = "Clients_ClientId"
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "LocationsBPP",
            .QueryField = "ClientId",
            .QueryAlias = "LocationsBPP_ClientId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "LocationsBPP",
            .QueryField = "LocationId",
            .QueryAlias = "LocationsBPP_LocationId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "LocationsBPP",
            .QueryField = "TaxYear",
            .QueryAlias = "LocationsBPP_TaxYear"
        }
        cQuery.SelectList.Add(cSelect)

        cSelect = New clsQuerySelect With {
            .QueryTable = "",
            .QueryField = "",
            .QueryAlias = "NULL AS LocationsRE_ClientId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "",
            .QueryField = "",
            .QueryAlias = "NULL AS LocationsRE_LocationId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "",
            .QueryField = "",
            .QueryAlias = "NULL AS LocationsRE_TaxYear"
        }
        cQuery.SelectList.Add(cSelect)


        cSelect = New clsQuerySelect With {
            .QueryTable = "AssessmentsBPP",
            .QueryField = "ClientId",
            .QueryAlias = "AssessmentsBPP_ClientId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "AssessmentsBPP",
            .QueryField = "LocationId",
            .QueryAlias = "AssessmentsBPP_LocationId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "AssessmentsBPP",
            .QueryField = "AssessmentId",
            .QueryAlias = "AssessmentsBPP_AssessmentId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "AssessmentsBPP",
            .QueryField = "TaxYear",
            .QueryAlias = "AssessmentsBPP_TaxYear"
        }
        cQuery.SelectList.Add(cSelect)

        cSelect = New clsQuerySelect With {
            .QueryTable = "",
            .QueryField = "",
            .QueryAlias = "NULL AS AssessmentsRE_ClientId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "",
            .QueryField = "",
            .QueryAlias = "NULL AS AssessmentsRE_LocationId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "",
            .QueryField = "",
            .QueryAlias = "NULL AS AssessmentsRE_AssessmentId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "",
            .QueryField = "",
            .QueryAlias = "NULL AS AssessmentsRE_TaxYear"
        }
        cQuery.SelectList.Add(cSelect)

        cSelect = New clsQuerySelect With {
            .QueryTable = "Assessors",
            .QueryField = "AssessorId",
            .QueryAlias = "Assessors_AssessorId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "Assessors",
            .QueryField = "TaxYear",
            .QueryAlias = "Assessors_TaxYear"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "",
            .QueryField = "",
            .QueryAlias = "'BPP' AS PropType"
        }
        cQuery.SelectList.Add(cSelect)
        'cSelect = New clsQuerySelect
        'cSelect.QueryTable = "BusinessUnits"
        'cSelect.QueryField = "Name"
        'cSelect.QueryAlias = "BusinessUnits_Name"
        'cQuery.SelectList.Add(cSelect)
        cUserQuery.Queries.Add(cQuery)
        'RE part
        cQuery = New clsQuery With {
            .SelectList = New Collection
        }
        cSelect = New clsQuerySelect
        cQuery.JoinStatement = "FROM Clients INNER JOIN LocationsRE ON Clients.ClientId = LocationsRE.ClientId" &
            " INNER JOIN AssessmentsRE ON LocationsRE.ClientId = AssessmentsRE.ClientId" &
            " AND LocationsRE.LocationId = AssessmentsRE.LocationId And LocationsRE.TaxYear = AssessmentsRE.TaxYear" &
            " LEFT OUTER JOIN Assessors ON AssessmentsRE.AssessorId = Assessors.AssessorId" &
            " AND AssessmentsRE.TaxYear = Assessors.TaxYear" &
            " LEFT OUTER JOIN BusinessUnits ON AssessmentsRE.ClientId = BusinessUnits.ClientId AND AssessmentsRE.BusinessUnitId = BusinessUnits.BusinessUnitId"
        cQuery.WhereClause = " WHERE LocationsRE.TaxYear = [TaxYear]"
        cSelect.QueryTable = "Clients"
        cSelect.QueryField = "ClientId"
        cSelect.QueryAlias = "Clients_ClientId"
        cQuery.SelectList.Add(cSelect)

        cSelect = New clsQuerySelect With {
            .QueryTable = "",
            .QueryField = "",
            .QueryAlias = "NULL AS LocationsBPP_ClientId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "",
            .QueryField = "",
            .QueryAlias = "NULL AS LocationsBPP_LocationId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "",
            .QueryField = "",
            .QueryAlias = "NULL AS LocationsBPP_TaxYear"
        }
        cQuery.SelectList.Add(cSelect)

        cSelect = New clsQuerySelect With {
            .QueryTable = "LocationsRE",
            .QueryField = "ClientId",
            .QueryAlias = "LocationsRE_ClientId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "LocationsRE",
            .QueryField = "LocationId",
            .QueryAlias = "LocationsRE_LocationId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "LocationsRE",
            .QueryField = "TaxYear",
            .QueryAlias = "LocationsRE_TaxYear"
        }
        cQuery.SelectList.Add(cSelect)

        cSelect = New clsQuerySelect With {
            .QueryTable = "",
            .QueryField = "",
            .QueryAlias = "NULL AS AssessmentsBPP_ClientId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "",
            .QueryField = "",
            .QueryAlias = "NULL AS AssessmentsBPP_LocationId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "",
            .QueryField = "",
            .QueryAlias = "NULL AS AssessmentsBPP_AssessmentId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "",
            .QueryField = "",
            .QueryAlias = "NULL AS AssessmentsBPP_TaxYear"
        }
        cQuery.SelectList.Add(cSelect)


        cSelect = New clsQuerySelect With {
            .QueryTable = "AssessmentsRE",
            .QueryField = "ClientId",
            .QueryAlias = "AssessmentsRE_ClientId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "AssessmentsRE",
            .QueryField = "LocationId",
            .QueryAlias = "AssessmentsRE_LocationId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "AssessmentsRE",
            .QueryField = "AssessmentId",
            .QueryAlias = "AssessmentsRE_AssessmentId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "AssessmentsRE",
            .QueryField = "TaxYear",
            .QueryAlias = "AssessmentsRE_TaxYear"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "Assessors",
            .QueryField = "AssessorId",
            .QueryAlias = "Assessors_AssessorId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "Assessors",
            .QueryField = "TaxYear",
            .QueryAlias = "Assessors_TaxYear"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "",
            .QueryField = "",
            .QueryAlias = "'RE' AS PropType"
        }
        cQuery.SelectList.Add(cSelect)
        'cSelect = New clsQuerySelect
        'cSelect.QueryTable = "BusinessUnits"
        'cSelect.QueryField = "Name"
        'cSelect.QueryAlias = "BusinessUnits_Name"
        'cQuery.SelectList.Add(cSelect)

        cUserQuery.Queries.Add(cQuery)
        colUserQueries.Add(cUserQuery, UserQueryType.AllAssessment)

        'BPP Taxes:  Clients/LocationsBPP/AssessmentsBPP/AssessmentDetailBPP
        cUserQuery = New clsUserQuery With {
            .QueryType = UserQueryType.BPPTaxes,
            .Queries = New Collection
        }
        cQuery = New clsQuery With {
            .SelectList = New Collection
        }
        cSelect = New clsQuerySelect
        cQuery.JoinStatement = "FROM Clients INNER JOIN LocationsBPP ON Clients.ClientId = LocationsBPP.ClientId" &
            " INNER JOIN AssessmentsBPP ON LocationsBPP.ClientId = AssessmentsBPP.ClientId" &
            " AND LocationsBPP.LocationId = AssessmentsBPP.LocationId And LocationsBPP.TaxYear = AssessmentsBPP.TaxYear" &
            " INNER JOIN AssessmentDetailBPP ON AssessmentsBPP.ClientId = AssessmentDetailBPP.ClientId" &
            " AND AssessmentsBPP.LocationId = AssessmentDetailBPP.LocationId AND AssessmentsBPP.AssessmentId = AssessmentDetailBPP.AssessmentId" &
            " AND AssessmentsBPP.TaxYear = AssessmentDetailBPP.TaxYear" &
            " LEFT OUTER JOIN Assessors ON AssessmentsBPP.AssessorId = Assessors.AssessorId" &
            " AND AssessmentsBPP.TaxYear = Assessors.TaxYear" &
            " INNER JOIN Jurisdictions ON AssessmentDetailBPP.JurisdictionId = Jurisdictions.JurisdictionId" &
            " AND AssessmentDetailBPP.TaxYear = Jurisdictions.TaxYear" &
            " LEFT OUTER JOIN Collectors ON Jurisdictions.CollectorId = Collectors.CollectorId" &
            " AND Jurisdictions.TaxYear = Collectors.TaxYear" &
            " LEFT OUTER JOIN BusinessUnits ON AssessmentsBPP.ClientId = BusinessUnits.ClientId AND AssessmentsBPP.BusinessUnitId = BusinessUnits.BusinessUnitId"
        cQuery.WhereClause = " WHERE LocationsBPP.TaxYear = [TaxYear]"
        cSelect.QueryTable = "Clients"
        cSelect.QueryField = "ClientId"
        cSelect.QueryAlias = "Clients_ClientId"
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "LocationsBPP",
            .QueryField = "ClientId",
            .QueryAlias = "LocationsBPP_ClientId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "LocationsBPP",
            .QueryField = "LocationId",
            .QueryAlias = "LocationsBPP_LocationId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "LocationsBPP",
            .QueryField = "TaxYear",
            .QueryAlias = "LocationsBPP_TaxYear"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "AssessmentsBPP",
            .QueryField = "ClientId",
            .QueryAlias = "AssessmentsBPP_ClientId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "AssessmentsBPP",
            .QueryField = "LocationId",
            .QueryAlias = "AssessmentsBPP_LocationId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "AssessmentsBPP",
            .QueryField = "AssessmentId",
            .QueryAlias = "AssessmentsBPP_AssessmentId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "AssessmentsBPP",
            .QueryField = "TaxYear",
            .QueryAlias = "AssessmentsBPP_TaxYear"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "AssessmentDetailBPP",
            .QueryField = "ClientId",
            .QueryAlias = "AssessmentDetailBPP_ClientId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "AssessmentDetailBPP",
            .QueryField = "LocationId",
            .QueryAlias = "AssessmentDetailBPP_LocationId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "AssessmentDetailBPP",
            .QueryField = "AssessmentId",
            .QueryAlias = "AssessmentDetailBPP_AssessmentId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "AssessmentDetailBPP",
            .QueryField = "JurisdictionId",
            .QueryAlias = "AssessmentDetailBPP_JurisdictionId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "AssessmentDetailBPP",
            .QueryField = "TaxYear",
            .QueryAlias = "AssessmentDetailBPP_TaxYear"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "Assessors",
            .QueryField = "AssessorId",
            .QueryAlias = "Assessors_AssessorId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "Assessors",
            .QueryField = "TaxYear",
            .QueryAlias = "Assessors_TaxYear"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "Jurisdictions",
            .QueryField = "JurisdictionId",
            .QueryAlias = "Jurisdictions_JurisdictionId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "Jurisdictions",
            .QueryField = "TaxYear",
            .QueryAlias = "Jurisdictions_TaxYear"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "Collectors",
            .QueryField = "CollectorId",
            .QueryAlias = "Collectors_CollectorsId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "Collectors",
            .QueryField = "TaxYear",
            .QueryAlias = "Collectors_TaxYear"
        }
        cQuery.SelectList.Add(cSelect)
        'cSelect = New clsQuerySelect
        'cSelect.QueryTable = "BusinessUnits"
        'cSelect.QueryField = "Name"
        'cSelect.QueryAlias = "BusinessUnits_Name"
        'cQuery.SelectList.Add(cSelect)
        cUserQuery.Queries.Add(cQuery)
        colUserQueries.Add(cUserQuery, UserQueryType.BPPTaxes)

        'RE Taxes:  Clients/LocationsRE/AssessmentsRE/AssessmentDetailRE
        cUserQuery = New clsUserQuery With {
            .Queries = New Collection,
            .QueryType = UserQueryType.RETaxes
        }
        cQuery = New clsQuery With {
            .SelectList = New Collection
        }
        cSelect = New clsQuerySelect
        cQuery.JoinStatement = "FROM Clients INNER JOIN LocationsRE ON Clients.ClientId = LocationsRE.ClientId" &
            " INNER JOIN AssessmentsRE ON LocationsRE.ClientId = AssessmentsRE.ClientId" &
            " AND LocationsRE.LocationId = AssessmentsRE.LocationId And LocationsRE.TaxYear = AssessmentsRE.TaxYear" &
            " INNER JOIN AssessmentDetailRE ON AssessmentsRE.ClientId = AssessmentDetailRE.ClientId" &
            " AND AssessmentsRE.LocationId = AssessmentDetailRE.LocationId AND AssessmentsRE.AssessmentId = AssessmentDetailRE.AssessmentId" &
            " AND AssessmentsRE.TaxYear = AssessmentDetailRE.TaxYear" &
            " LEFT OUTER JOIN Assessors ON AssessmentsRE.AssessorId = Assessors.AssessorId" &
            " AND AssessmentsRE.TaxYear = Assessors.TaxYear" &
            " INNER JOIN Jurisdictions ON AssessmentDetailRE.JurisdictionId = Jurisdictions.JurisdictionId" &
            " AND AssessmentDetailRE.TaxYear = Jurisdictions.TaxYear" &
            " LEFT OUTER JOIN Collectors ON Jurisdictions.CollectorId = Collectors.CollectorId" &
            " AND Jurisdictions.TaxYear = Collectors.TaxYear" &
            " LEFT OUTER JOIN BusinessUnits ON AssessmentsRE.ClientId = BusinessUnits.ClientId AND AssessmentsRE.BusinessUnitId = BusinessUnits.BusinessUnitId"
        cQuery.WhereClause = " WHERE LocationsRE.TaxYear = [TaxYear]"
        cSelect.QueryTable = "Clients"
        cSelect.QueryField = "ClientId"
        cSelect.QueryAlias = "Clients_ClientId"
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "LocationsRE",
            .QueryField = "ClientId",
            .QueryAlias = "LocationsRE_ClientId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "LocationsRE",
            .QueryField = "LocationId",
            .QueryAlias = "LocationsRE_LocationId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "LocationsRE",
            .QueryField = "TaxYear",
            .QueryAlias = "LocationsRE_TaxYear"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "AssessmentsRE",
            .QueryField = "ClientId",
            .QueryAlias = "AssessmentsRE_ClientId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "AssessmentsRE",
            .QueryField = "LocationId",
            .QueryAlias = "AssessmentsRE_LocationId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "AssessmentsRE",
            .QueryField = "AssessmentId",
            .QueryAlias = "AssessmentsRE_AssessmentId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "AssessmentsRE",
            .QueryField = "TaxYear",
            .QueryAlias = "AssessmentsRE_TaxYear"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "AssessmentDetailRE",
            .QueryField = "ClientId",
            .QueryAlias = "AssessmentDetailRE_ClientId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "AssessmentDetailRE",
            .QueryField = "LocationId",
            .QueryAlias = "AssessmentDetailRE_LocationId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "AssessmentDetailRE",
            .QueryField = "AssessmentId",
            .QueryAlias = "AssessmentDetailRE_AssessmentId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "AssessmentDetailRE",
            .QueryField = "JurisdictionId",
            .QueryAlias = "AssessmentDetailRE_JurisdictionId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "AssessmentDetailRE",
            .QueryField = "TaxYear",
            .QueryAlias = "AssessmentDetailRE_TaxYear"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "Assessors",
            .QueryField = "AssessorId",
            .QueryAlias = "Assessors_AssessorId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "Assessors",
            .QueryField = "TaxYear",
            .QueryAlias = "Assessors_TaxYear"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "Jurisdictions",
            .QueryField = "JurisdictionId",
            .QueryAlias = "Jurisdictions_JurisdictionId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "Jurisdictions",
            .QueryField = "TaxYear",
            .QueryAlias = "Jurisdictions_TaxYear"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "Collectors",
            .QueryField = "CollectorId",
            .QueryAlias = "Collectors_CollectorsId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "Collectors",
            .QueryField = "TaxYear",
            .QueryAlias = "Collectors_TaxYear"
        }
        cQuery.SelectList.Add(cSelect)
        'cSelect = New clsQuerySelect
        'cSelect.QueryTable = "BusinessUnits"
        'cSelect.QueryField = "Name"
        'cSelect.QueryAlias = "BusinessUnits_Name"
        'cQuery.SelectList.Add(cSelect)
        cUserQuery.Queries.Add(cQuery)
        colUserQueries.Add(cUserQuery, UserQueryType.RETaxes)

        'All taxes:  Clients/LocationsBPP/AssessmentsBPP/AssessmentDetailBPP UNION Clients/LocationsRE/AssessmentsRE/AssessmentDetailRE
        'BPP part
        cUserQuery = New clsUserQuery With {
            .QueryType = UserQueryType.AllTaxes,
            .Queries = New Collection
        }
        cQuery = New clsQuery With {
            .SelectList = New Collection
        }
        cSelect = New clsQuerySelect
        cQuery.JoinStatement = "FROM Clients INNER JOIN LocationsBPP ON Clients.ClientId = LocationsBPP.ClientId" &
            " INNER JOIN AssessmentsBPP ON LocationsBPP.ClientId = AssessmentsBPP.ClientId" &
            " AND LocationsBPP.LocationId = AssessmentsBPP.LocationId And LocationsBPP.TaxYear = AssessmentsBPP.TaxYear" &
            " INNER JOIN AssessmentDetailBPP ON AssessmentsBPP.ClientId = AssessmentDetailBPP.ClientId" &
            " AND AssessmentsBPP.LocationId = AssessmentDetailBPP.LocationId AND AssessmentsBPP.AssessmentId = AssessmentDetailBPP.AssessmentId" &
            " AND AssessmentsBPP.TaxYear = AssessmentDetailBPP.TaxYear" &
            " LEFT OUTER JOIN Assessors ON AssessmentsBPP.AssessorId = Assessors.AssessorId" &
            " AND AssessmentsBPP.TaxYear = Assessors.TaxYear" &
            " INNER JOIN Jurisdictions ON AssessmentDetailBPP.JurisdictionId = Jurisdictions.JurisdictionId" &
            " AND AssessmentDetailBPP.TaxYear = Jurisdictions.TaxYear" &
            " LEFT OUTER JOIN Collectors ON Jurisdictions.CollectorId = Collectors.CollectorId" &
            " AND Jurisdictions.TaxYear = Collectors.TaxYear" &
            " LEFT OUTER JOIN BusinessUnits ON AssessmentsBPP.ClientId = BusinessUnits.ClientId AND AssessmentsBPP.BusinessUnitId = BusinessUnits.BusinessUnitId"
        cQuery.WhereClause = " WHERE LocationsBPP.TaxYear = [TaxYear]"
        cSelect.QueryTable = "Clients"
        cSelect.QueryField = "ClientId"
        cSelect.QueryAlias = "Clients_ClientId"
        cQuery.SelectList.Add(cSelect)

        cSelect = New clsQuerySelect With {
            .QueryTable = "LocationsBPP",
            .QueryField = "ClientId",
            .QueryAlias = "LocationsBPP_ClientId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "LocationsBPP",
            .QueryField = "LocationId",
            .QueryAlias = "LocationsBPP_LocationId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "LocationsBPP",
            .QueryField = "TaxYear",
            .QueryAlias = "LocationsBPP_TaxYear"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "AssessmentsBPP",
            .QueryField = "ClientId",
            .QueryAlias = "AssessmentsBPP_ClientId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "AssessmentsBPP",
            .QueryField = "LocationId",
            .QueryAlias = "AssessmentsBPP_LocationId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "AssessmentsBPP",
            .QueryField = "AssessmentId",
            .QueryAlias = "AssessmentsBPP_AssessmentId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "AssessmentsBPP",
            .QueryField = "TaxYear",
            .QueryAlias = "AssessmentsBPP_TaxYear"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "AssessmentDetailBPP",
            .QueryField = "ClientId",
            .QueryAlias = "AssessmentDetailBPP_ClientId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "AssessmentDetailBPP",
            .QueryField = "LocationId",
            .QueryAlias = "AssessmentDetailBPP_LocationId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "AssessmentDetailBPP",
            .QueryField = "AssessmentId",
            .QueryAlias = "AssessmentDetailBPP_AssessmentId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "AssessmentDetailBPP",
            .QueryField = "JurisdictionId",
            .QueryAlias = "AssessmentDetailBPP_JurisdictionId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "AssessmentDetailBPP",
            .QueryField = "TaxYear",
            .QueryAlias = "AssessmentDetailBPP_TaxYear"
        }
        cQuery.SelectList.Add(cSelect)

        cSelect = New clsQuerySelect With {
            .QueryTable = "",
            .QueryField = "",
            .QueryAlias = "NULL AS LocationsRE_ClientId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "",
            .QueryField = "",
            .QueryAlias = "NULL AS LocationsRE_LocationId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "",
            .QueryField = "",
            .QueryAlias = "NULL AS LocationsRE_TaxYear"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "",
            .QueryField = "",
            .QueryAlias = "NULL AS AssessmentsRE_ClientId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "",
            .QueryField = "",
            .QueryAlias = "NULL AS AssessmentsRE_LocationId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "",
            .QueryField = "",
            .QueryAlias = "NULL AS AssessmentsRE_AssessmentId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "",
            .QueryField = "",
            .QueryAlias = "NULL AS AssessmentsRE_TaxYear"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "",
            .QueryField = "",
            .QueryAlias = "NULL AS AssessmentDetailRE_ClientId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "",
            .QueryField = "",
            .QueryAlias = "NULL AS AssessmentDetailRE_LocationId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "",
            .QueryField = "",
            .QueryAlias = "NULL AS AssessmentDetailRE_AssessmentId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "",
            .QueryField = "",
            .QueryAlias = "NULL AssessmentDetailRE_JurisdictionId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "",
            .QueryField = "",
            .QueryAlias = "NULL AS AssessmentDetailRE_TaxYear"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "Assessors",
            .QueryField = "AssessorId",
            .QueryAlias = "Assessors_AssessorId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "Assessors",
            .QueryField = "TaxYear",
            .QueryAlias = "Assessors_TaxYear"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "Jurisdictions",
            .QueryField = "JurisdictionId",
            .QueryAlias = "Jurisdictions_JurisdictionId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "Jurisdictions",
            .QueryField = "TaxYear",
            .QueryAlias = "Jurisdictions_TaxYear"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "Collectors",
            .QueryField = "CollectorId",
            .QueryAlias = "Collectors_CollectorsId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "Collectors",
            .QueryField = "TaxYear",
            .QueryAlias = "Collectors_TaxYear"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "",
            .QueryField = "",
            .QueryAlias = "'BPP' AS PropType"
        }
        cQuery.SelectList.Add(cSelect)
        'cSelect = New clsQuerySelect
        'cSelect.QueryTable = "BusinessUnits"
        'cSelect.QueryField = "Name"
        'cSelect.QueryAlias = "BusinessUnits_Name"
        'cQuery.SelectList.Add(cSelect)
        cUserQuery.Queries.Add(cQuery)
        'RE Taxes part
        cQuery = New clsQuery With {
            .SelectList = New Collection
        }
        cSelect = New clsQuerySelect
        cQuery.JoinStatement = "FROM Clients INNER JOIN LocationsRE ON Clients.ClientId = LocationsRE.ClientId" &
            " INNER JOIN AssessmentsRE ON LocationsRE.ClientId = AssessmentsRE.ClientId" &
            " AND LocationsRE.LocationId = AssessmentsRE.LocationId And LocationsRE.TaxYear = AssessmentsRE.TaxYear" &
            " INNER JOIN AssessmentDetailRE ON AssessmentsRE.ClientId = AssessmentDetailRE.ClientId" &
            " AND AssessmentsRE.LocationId = AssessmentDetailRE.LocationId AND AssessmentsRE.AssessmentId = AssessmentDetailRE.AssessmentId" &
            " AND AssessmentsRE.TaxYear = AssessmentDetailRE.TaxYear" &
            " LEFT OUTER JOIN Assessors ON AssessmentsRE.AssessorId = Assessors.AssessorId" &
            " AND AssessmentsRE.TaxYear = Assessors.TaxYear" &
            " INNER JOIN Jurisdictions ON AssessmentDetailRE.JurisdictionId = Jurisdictions.JurisdictionId" &
            " AND AssessmentDetailRE.TaxYear = Jurisdictions.TaxYear" &
            " LEFT OUTER JOIN Collectors ON Jurisdictions.CollectorId = Collectors.CollectorId" &
            " AND Jurisdictions.TaxYear = Collectors.TaxYear" &
            " LEFT OUTER JOIN BusinessUnits ON AssessmentsRE.ClientId = BusinessUnits.ClientId AND AssessmentsRE.BusinessUnitId = BusinessUnits.BusinessUnitId"
        cQuery.WhereClause = " WHERE LocationsRE.TaxYear = [TaxYear]"
        cSelect.QueryTable = "Clients"
        cSelect.QueryField = "ClientId"
        cSelect.QueryAlias = "Clients_ClientId"
        cQuery.SelectList.Add(cSelect)

        cSelect = New clsQuerySelect With {
            .QueryTable = "",
            .QueryField = "",
            .QueryAlias = "NULL AS LocationsBPP_ClientId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "",
            .QueryField = "",
            .QueryAlias = "NULL AS LocationsBPP_LocationId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "",
            .QueryField = "",
            .QueryAlias = "NULL AS LocationsBPP_TaxYear"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "",
            .QueryField = "",
            .QueryAlias = "NULL AS AssessmentsBPP_ClientId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "",
            .QueryField = "",
            .QueryAlias = "NULL AS AssessmentsBPP_LocationId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "",
            .QueryField = "",
            .QueryAlias = "NULL AS AssessmentsBPP_AssessmentId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "",
            .QueryField = "",
            .QueryAlias = "NULL AS AssessmentsBPP_TaxYear"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "",
            .QueryField = "",
            .QueryAlias = "NULL AS AssessmentDetailBPP_ClientId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "",
            .QueryField = "",
            .QueryAlias = "NULL AS AssessmentDetailBPP_LocationId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "",
            .QueryField = "",
            .QueryAlias = "NULL AS AssessmentDetailBPP_AssessmentId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "",
            .QueryField = "",
            .QueryAlias = "NULL AS AssessmentDetailBPP_JurisdictionId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "",
            .QueryField = "",
            .QueryAlias = "NULL AS AssessmentDetailBPP_TaxYear"
        }
        cQuery.SelectList.Add(cSelect)

        cSelect = New clsQuerySelect With {
            .QueryTable = "LocationsRE",
            .QueryField = "ClientId",
            .QueryAlias = "LocationsRE_ClientId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "LocationsRE",
            .QueryField = "LocationId",
            .QueryAlias = "LocationsRE_LocationId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "LocationsRE",
            .QueryField = "TaxYear",
            .QueryAlias = "LocationsRE_TaxYear"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "AssessmentsRE",
            .QueryField = "ClientId",
            .QueryAlias = "AssessmentsRE_ClientId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "AssessmentsRE",
            .QueryField = "LocationId",
            .QueryAlias = "AssessmentsRE_LocationId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "AssessmentsRE",
            .QueryField = "AssessmentId",
            .QueryAlias = "AssessmentsRE_AssessmentId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "AssessmentsRE",
            .QueryField = "TaxYear",
            .QueryAlias = "AssessmentsRE_TaxYear"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "AssessmentDetailRE",
            .QueryField = "ClientId",
            .QueryAlias = "AssessmentDetailRE_ClientId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "AssessmentDetailRE",
            .QueryField = "LocationId",
            .QueryAlias = "AssessmentDetailRE_LocationId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "AssessmentDetailRE",
            .QueryField = "AssessmentId",
            .QueryAlias = "AssessmentDetailRE_AssessmentId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "AssessmentDetailRE",
            .QueryField = "JurisdictionId",
            .QueryAlias = "AssessmentDetailRE_JurisdictionId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "AssessmentDetailRE",
            .QueryField = "TaxYear",
            .QueryAlias = "AssessmentDetailRE_TaxYear"
        }
        cQuery.SelectList.Add(cSelect)

        cSelect = New clsQuerySelect With {
            .QueryTable = "Assessors",
            .QueryField = "AssessorId",
            .QueryAlias = "Assessors_AssessorId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "Assessors",
            .QueryField = "TaxYear",
            .QueryAlias = "Assessors_TaxYear"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "Jurisdictions",
            .QueryField = "JurisdictionId",
            .QueryAlias = "Jurisdictions_JurisdictionId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "Jurisdictions",
            .QueryField = "TaxYear",
            .QueryAlias = "Jurisdictions_TaxYear"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "Collectors",
            .QueryField = "CollectorId",
            .QueryAlias = "Collectors_CollectorsId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "Collectors",
            .QueryField = "TaxYear",
            .QueryAlias = "Collectors_TaxYear"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "",
            .QueryField = "",
            .QueryAlias = "'RE' AS PropType"
        }
        cQuery.SelectList.Add(cSelect)
        'cSelect = New clsQuerySelect
        'cSelect.QueryTable = "BusinessUnits"
        'cSelect.QueryField = "Name"
        'cSelect.QueryAlias = "BusinessUnits_Name"
        'cQuery.SelectList.Add(cSelect)
        cUserQuery.Queries.Add(cQuery)
        colUserQueries.Add(cUserQuery, UserQueryType.AllTaxes)

        'Prospects
        cUserQuery = New clsUserQuery With {
            .QueryType = UserQueryType.Prospects,
            .Queries = New Collection
        }
        cQuery = New clsQuery With {
            .SelectList = New Collection
        }
        cSelect = New clsQuerySelect
        cQuery.JoinStatement = "FROM Clients"
        cSelect.QueryTable = "Clients"
        cSelect.QueryField = "ClientId"
        cSelect.QueryAlias = "Clients_ClientId"
        cQuery.SelectList.Add(cSelect)
        cUserQuery.Queries.Add(cQuery)
        colUserQueries.Add(cUserQuery, UserQueryType.Prospects)

        'Prospect locations
        cUserQuery = New clsUserQuery With {
            .QueryType = UserQueryType.ProspectLocations,
            .Queries = New Collection
        }
        cQuery = New clsQuery With {
            .SelectList = New Collection
        }
        cSelect = New clsQuerySelect
        cQuery.JoinStatement = "FROM Clients INNER JOIN ProspectLocations ON Clients.ClientId = ProspectLocations.ClientId" &
            " LEFT OUTER JOIN Assessors ON ProspectLocations.AssessorId = Assessors.AssessorId AND Assessors.TaxYear = [TaxYear]"
        cSelect.QueryTable = "Clients"
        cSelect.QueryField = "ClientId"
        cSelect.QueryAlias = "Clients_ClientId"
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "ProspectLocations",
            .QueryField = "ClientId",
            .QueryAlias = "ProspectLocations_ClientId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "ProspectLocations",
            .QueryField = "LocationId",
            .QueryAlias = "ProspectLocations_LocationId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "Assessors",
            .QueryField = "AssessorId",
            .QueryAlias = "Assessors_AssessorId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "Assessors",
            .QueryField = "TaxYear",
            .QueryAlias = "Assessors_TaxYear"
        }
        cQuery.SelectList.Add(cSelect)
        cUserQuery.Queries.Add(cQuery)
        colUserQueries.Add(cUserQuery, UserQueryType.ProspectLocations)


        'prospect values
        cUserQuery = New clsUserQuery With {
            .QueryType = UserQueryType.ProspectValues,
            .Queries = New Collection
        }
        cQuery = New clsQuery With {
            .SelectList = New Collection
        }
        cSelect = New clsQuerySelect
        cQuery.JoinStatement = "FROM Clients INNER JOIN ProspectLocations ON Clients.ClientId = ProspectLocations.ClientId" &
            " LEFT OUTER JOIN Assessors ON ProspectLocations.AssessorId = Assessors.AssessorId AND Assessors.TaxYear = [TaxYear]" &
            " LEFT OUTER JOIN ProspectValues ON ProspectValues.ClientId = ProspectLocations.ClientId" &
            " AND ProspectValues.LocationId = ProspectLocations.LocationId AND ProspectValues.TaxYear = [TaxYear]"
        cSelect.QueryTable = "Clients"
        cSelect.QueryField = "ClientId"
        cSelect.QueryAlias = "Clients_ClientId"
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "ProspectLocations",
            .QueryField = "ClientId",
            .QueryAlias = "ProspectLocations_ClientId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "ProspectLocations",
            .QueryField = "LocationId",
            .QueryAlias = "ProspectLocations_LocationId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "Assessors",
            .QueryField = "AssessorId",
            .QueryAlias = "Assessors_AssessorId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "Assessors",
            .QueryField = "TaxYear",
            .QueryAlias = "Assessors_TaxYear"
        }
        cQuery.SelectList.Add(cSelect)
        cUserQuery.Queries.Add(cQuery)
        cSelect = New clsQuerySelect With {
            .QueryTable = "ProspectValues",
            .QueryField = "ClientId",
            .QueryAlias = "ProspectValues_ClientId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "ProspectValues",
            .QueryField = "LocationId",
            .QueryAlias = "ProspectValues_LocationId"
        }
        cQuery.SelectList.Add(cSelect)
        cSelect = New clsQuerySelect With {
            .QueryTable = "ProspectValues",
            .QueryField = "TaxYear",
            .QueryAlias = "ProspectValues_TaxYear"
        }
        cQuery.SelectList.Add(cSelect)
        colUserQueries.Add(cUserQuery, UserQueryType.ProspectValues)



        'For Each cUserQuery In colUserQueries
        '    sSQL = ""
        '    For Each cQuery In cUserQuery.Queries
        '        If sSQL <> "" Then sSQL = sSQL & " UNION "
        '        sSELECT = ""
        '        For Each cSelect In cQuery.SelectList
        '            If sSELECT <> "" Then sSELECT = sSELECT & ","
        '            If cSelect.QueryField = "" Then
        '                sSELECT = sSELECT & cSelect.QueryAlias
        '            Else
        '                sSELECT = sSELECT & cSelect.QueryTable & "." & cSelect.QueryField & " AS " & cSelect.QueryAlias
        '            End If
        '        Next
        '        sSQL = sSQL & "SELECT " & sSELECT & " " & cQuery.JoinStatement
        '    Next
        '    My.Computer.FileSystem.WriteAllText("d:\queriesdebug.txt", sSQL & vbCrLf, True)
        'Next








    End Sub
    Public Function ContainsQueryType(ByVal lSearch As Long, ByVal lAggregate As Long) As Boolean
        Dim dFraction As Double, lIncrement As Long, bResult As Boolean
        Dim lPieces() As Long

        If lSearch < 1 Or lAggregate < 1 Then
            ContainsQueryType = False
            Exit Function
        End If
        If lSearch = lAggregate Then
            ContainsQueryType = True
            Exit Function
        End If
        If lSearch > lAggregate Then
            ContainsQueryType = False
            Exit Function
        End If

        ReDim lPieces(0)
        lIncrement = 1
        Do
            dFraction = lAggregate / lIncrement
            If dFraction = 1 Then
                ReDim Preserve lPieces(UBound(lPieces) + 1)
                lPieces(UBound(lPieces)) = lIncrement
                Exit Do
            End If
            If dFraction < 1 Then
                Exit Do
            End If
            If dFraction < 2 Then
                ReDim Preserve lPieces(UBound(lPieces) + 1)
                lPieces(UBound(lPieces)) = lIncrement
                lAggregate = lAggregate - lIncrement
                lIncrement = 1
            Else
                lIncrement = lIncrement * 2
            End If
        Loop

        bResult = False
        For lIncrement = 1 To UBound(lPieces)
            If lSearch = lPieces(lIncrement) Then
                bResult = True
                Exit For
            End If
        Next

        ContainsQueryType = bResult
    End Function

End Module
