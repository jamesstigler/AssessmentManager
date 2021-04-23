Public Class clsLocationBPP
    Private m_ClientId As Long
    Private m_LocationId As Long
    Private m_Address As String
    Private m_Assessments As Collection
    Private m_City As String
    Private m_StateCd As String
    Private m_Zip As String
    Private m_TaxYear As Integer
    Private m_Client As clsClient
    Private m_Name As String
    Private m_LegalDescription As String
    Private m_LegalOwner As String
    Private m_ClientLocationId As String
    Private m_Comment As String

    Private m_ResultSet As DataTable

    Public Property ClientId() As Long
        Get
            Return m_ClientId
        End Get
        Set(ByVal value As Long)
            m_ClientId = value
        End Set
    End Property
    Public Property Client() As clsClient
        Get
            Return m_Client
        End Get
        Set(ByVal value As clsClient)
            m_Client = value
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

    Public Property LocationId() As Long
        Get
            Return m_LocationId
        End Get
        Set(ByVal value As Long)
            m_LocationId = value
        End Set
    End Property

    Public Property Address() As String
        Get
            Return m_Address
        End Get
        Set(ByVal value As String)
            m_Address = value
        End Set
    End Property

    Public Property City() As String
        Get
            Return m_City
        End Get
        Set(ByVal value As String)
            m_City = value
        End Set
    End Property

    Public Property StateCd() As String
        Get
            Return m_StateCd
        End Get
        Set(ByVal value As String)
            m_StateCd = value
        End Set
    End Property

    Public Property Zip() As String
        Get
            Return m_Zip
        End Get
        Set(ByVal value As String)
            m_Zip = value
        End Set
    End Property
    Public Property Name() As String
        Get
            Return m_Name
        End Get
        Set(ByVal value As String)
            m_Name = value
        End Set
    End Property

    Public Property LegalDescription() As String
        Get
            Return m_LegalDescription
        End Get
        Set(ByVal value As String)
            m_LegalDescription = value
        End Set
    End Property
    Public Property LegalOwner() As String
        Get
            Return m_LegalOwner
        End Get
        Set(ByVal value As String)
            m_LegalOwner = value
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
    Public Property ClientLocationID() As String
        Get
            Return m_ClientLocationId
        End Get
        Set(ByVal value As String)
            m_ClientLocationId = value
        End Set
    End Property

    Public Property Assessments() As Collection
        Get
            Return m_Assessments
        End Get
        Set(ByVal value As Collection)
            m_Assessments = value
        End Set
    End Property
    Public Property ResultSet() As DataTable
        Get
            Return m_ResultSet
        End Get
        Set(ByVal value As DataTable)
            m_ResultSet = value
        End Set
    End Property


    Public Function OpenLocation(ByRef sError As String) As Boolean
        Dim sSQL As New StringBuilder

        Try
            m_Client = New clsClient
            m_Client.ClientId = m_ClientId
            If Not m_Client.OpenClient(sError) Then Return False

            m_Address = "" : m_City = "" : m_StateCd = "" : m_Zip = ""
            sError = ""
            sSQL.Length = 0
            sSQL.Append("SELECT ClientId,LocationId,TaxYear,Address,Name,City,StateCd,Zip,LegalDescription,LegalOwner,ClientLocationId,Comment,AddDate,AddUser,ChangeDate,ChangeUser,")
            sSQL.Append(" ChangeType,InactiveFl,")
            sSQL.Append(" ISNULL(ConsultantName,(SELECT BPPConsultantName FROM Clients WHERE ClientId = ").Append(m_ClientId).Append(")) AS ConsultantName")
            sSQL.Append(" FROM LocationsBPP WHERE ClientId = ").Append(m_ClientId).Append(" AND LocationId = ").Append(m_LocationId)
            sSQL.Append(" AND TaxYear = ").Append(m_TaxYear)
            If GetData(sSQL.ToString, m_ResultSet) > 0 Then
                Dim dr As DataRow = m_ResultSet.Rows(0)
                m_Address = UnNullToString(dr("Address"))
                m_City = UnNullToString(dr("City"))
                m_StateCd = UnNullToString(dr("StateCd"))
                m_Zip = UnNullToString(dr("Zip"))

                Return True
            Else
                sError = "Location does not exist"
                Return False
            End If
        Catch ex As Exception
            sError = ex.Message
            Return False
        End Try

    End Function
    Public Function CreateLocation(ByVal bHitDB As Boolean, ByVal lLocationId As Long, ByRef sError As String) As Boolean
        Dim sSQL As String, dt As New DataTable

        Try
            m_Address = Trim(m_Address)
            m_StateCd = UCase(Trim(m_StateCd))
            m_City = Trim(m_City)
            If m_Address = "" Or m_StateCd = "" Or m_City = "" Then
                sError = "Location info missing"
                Return False
            End If
            sError = ""
            sSQL = "SELECT AddDate, AddUser FROM LocationsBPP WHERE ClientId = " & m_ClientId & " AND Address = " & QuoStr(m_Address) & " AND City = " & QuoStr(m_City) & " AND StateCd = " & QuoStr(m_StateCd) & " AND TaxYear = " & m_TaxYear
            If GetData(sSQL, dt) > 0 Then
                Dim dr As DataRow = dt.Rows(0)
                sError = "Location already exists, it was added " & Format(dr("AddDate"), FORMATDATETIME) & " by " & UnNullToString(dr("AddUser"))
                Return False
            Else
                If bHitDB Then
                    If lLocationId = 0 Then lLocationId = CreateID(enumTable.enumLocationBPP)
                    sSQL = "create table #tmpyears (TaxYear smallint)" &
                        " INSERT INTO #tmpyears SELECT DISTINCT TaxYear FROM LocationsBPP" &
                        " INSERT LocationsBPP (ClientId,LocationId,TaxYear,Address,City,StateCd,Name,Zip,LegalDescription," &
                        "LegalOwner,ClientLocationId,Comment,InactiveFl,AddUser) SELECT " &
                        m_ClientId & "," & lLocationId & ", tmp.TaxYear," & QuoStr(m_Address) & "," & QuoStr(m_City) & "," &
                        QuoStr(m_StateCd) & "," & IIf(Trim(m_Name) = "", "NULL", QuoStr(m_Name)) & "," &
                        IIf(Trim(m_Zip) = "", "NULL", QuoStr(m_Zip)) & "," &
                        IIf(Trim(m_LegalDescription) = "", "NULL", QuoStr(m_LegalDescription)) & "," &
                        IIf(Trim(m_LegalOwner) = "", "NULL", QuoStr(m_LegalOwner)) & "," &
                        IIf(Trim(m_ClientLocationId) = "", "NULL", QuoStr(m_ClientLocationId)) & "," &
                        IIf(Trim(m_Comment) = "", "NULL", QuoStr(m_Comment)) & ", CASE WHEN tmp.TaxYear < " & AppData.TaxYear & " THEN 1 ELSE 0 END, " &
                        QuoStr(AppData.UserId) &
                          " FROM #tmpyears tmp    drop table #tmpyears"
                    If ExecuteSQL(sSQL) > 0 Then
                        m_LocationId = lLocationId
                        Return True
                    End If
                Else
                    Return True
                End If
            End If
        Catch ex As Exception
            sError = ex.Message
            Return False
        End Try

    End Function

End Class
