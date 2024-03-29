﻿Public Class clsAssessmentBPP
    Private m_AcctNum As String
    Private m_ClientId As Long
    Private m_LocationId As Long
    Private m_AssessmentId As Long
    Private m_AssessorId As Long
    Private m_DefaultDeprId As Long
    Private m_TaxYear As Integer
    Private m_Location As clsLocationBPP
    Private m_Assets As Collection
    Private m_Comment As String

    Public Property Location() As clsLocationBPP
        Get
            Return m_Location
        End Get
        Set(ByVal value As clsLocationBPP)
            m_Location = value
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
    Public Property AcctNum() As String
        Get
            Return m_AcctNum
        End Get
        Set(ByVal value As String)
            m_AcctNum = value
        End Set
    End Property

    Public Property DefaultDeprId() As Long
        Get
            Return m_DefaultDeprId
        End Get
        Set(ByVal value As Long)
            m_DefaultDeprId = value
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

    Public Property AssessorId() As Long
        Get
            Return m_AssessorId
        End Get
        Set(ByVal value As Long)
            m_AssessorId = value
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

    Public Property LocationId() As Long
        Get
            Return m_LocationId
        End Get
        Set(ByVal value As Long)
            m_LocationId = value
        End Set
    End Property
    Public Property Comment() As String
        Get
            Return m_Comment
        End Get
        Set(ByVal value As String)
            m_Comment = value
        End Set
    End Property

    Public Function OpenAssessment(ByRef sError As String) As Boolean
        Dim sSQL As String, dt As New DataTable




        Try

            m_Location = New clsLocationBPP
            m_Location.ClientId = m_ClientId
            m_Location.LocationId = m_LocationId
            m_Location.TaxYear = m_TaxYear
            If Not m_Location.OpenLocation(sError) Then Return False

            m_AssessorId = 0 : m_DefaultDeprId = 0
            sError = ""
            sSQL = "SELECT * FROM AssessmentsBPP WHERE ClientId = " & m_ClientId &
                " AND LocationId = " & m_LocationId & " AND AssessmentId = " & m_AssessmentId &
                " AND TaxYear = " & m_TaxYear
            If GetData(sSQL, dt) > 0 Then
                Dim dr As DataRow = dt.Rows(0)
                m_AssessorId = UnNullToDouble(dr("AssessorId"))
                'm_DefaultDeprId = UnNullToDouble(dt(""))
                m_AcctNum = UnNullToString(dr("AcctNum"))
                m_Comment = UnNullToString(dr("Comment"))
                Return True
            Else
                sError = "Assessment does not exist"
                Return False
            End If

        Catch ex As Exception
            sError = ex.Message
            Return False
        End Try

    End Function
    Public Function CreateAssessment(ByVal bHitDB As Boolean, ByVal lAssessmentId As Long, lAssessorId As Long, ByRef sError As String) As Boolean
        Dim sSQL As String, dt As New DataTable

        Try
            m_AcctNum = UCase(Trim(m_AcctNum))
            m_Comment = Trim(m_Comment)
            If m_AcctNum = "" Then
                sError = "Assessment info missing"
                Return False
            End If
            sError = ""
            If bHitDB Then
                If lAssessmentId = 0 Then lAssessmentId = CreateID(enumTable.enumAssessmentBPP)
                'get distinct tax year from location because location must exist before account
                sSQL = "create table #tmpyears (TaxYear smallint)" &
                    " INSERT #tmpyears (TaxYear) SELECT DISTINCT TaxYear FROM LocationsBPP" &
                    " WHERE ClientId = " & m_ClientId & " AND LocationId = " & m_LocationId &
                    " INSERT AssessmentsBPP (ClientId,LocationId,AssessmentId,TaxYear,AcctNum,Comment,InactiveFl,AssessorId,AddUser) SELECT " &
                    m_ClientId & "," & m_LocationId & "," & lAssessmentId & ", tmp.TaxYear," & QuoStr(m_AcctNum) & "," & QuoStr(m_Comment) &
                    ", CASE WHEN tmp.TaxYear < " & AppData.TaxYear & " THEN 1 ELSE 0 END, " &
                    IIf(lAssessorId > 0, lAssessorId, "NULL") & "," & QuoStr(AppData.UserId) & " FROM #tmpyears tmp drop table #tmpyears"
                If ExecuteSQL(sSQL) > 0 Then
                    m_AssessmentId = lAssessmentId
                    Return True
                End If
            End If
            Return True
        Catch ex As Exception
            sError = ex.Message
            Return False
        End Try
    End Function
    '    Public Function UpdateAssetStatus(field As String, value As String, ByRef serror As String)
    '        Try
    '            serror = ""
    '            Dim sql As New StringBuilder()
    '            Dim dateupdate As String = ""

    '            Select Case field
    '                Case "AssetsLoadedFl"
    '                    dateupdate = ",AssetsLoadedDt=" & IIf(value = "0", "NULL", "GETDATE()")
    '                Case "AssetsVerifiedFl"
    '                    dateupdate = ",AssetsVerifiedDt=" & IIf(value = "0", "NULL", "GETDATE()")
    '            End Select

    '            sql.Append("UPDATE AssessmentsBPP SET ").Append(field).Append("=").Append(value).Append(dateupdate).Append(",ChangeDate=GETDATE(),ChangeUser=").Append(QuoStr(AppData.UserId))
    '            sql.Append(",ChangeType=2")
    '            sql.Append(" WHERE ClientId=").Append(m_ClientId.ToString).Append(" AND LocationId=").Append(m_LocationId.ToString).Append(" AND AssessmentId=").Append(m_AssessmentId)
    '            sql.Append(" AND TaxYear=").Append(m_TaxYear)
    '            ExecuteSQL(sql.ToString)
    '            Return True
    '        Catch ex As Exception
    '            serror = ex.Message
    '            Return False
    '        End Try
    '    End Function
End Class
