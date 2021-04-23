
Public Class clsClient
    Private m_ClientId As Long
    Private m_Name As String
    Private m_Address As String
    Private m_City As String
    Private m_StateCd As String
    Private m_Zip As String
    Private m_Phone As String
    Private m_Fax As String
    Private m_Locations As Collection
    Private m_ProspectFl As Boolean
    Private m_ResultSet As DataTable

    Public Property ClientId() As Long
        Get
            Return m_ClientId
        End Get
        Set(ByVal value As Long)
            m_ClientId = value
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

    Public Property Phone() As String
        Get
            Return m_Phone
        End Get
        Set(ByVal value As String)
            m_Phone = value
        End Set
    End Property

    Public Property Fax() As String
        Get
            Return m_Fax
        End Get
        Set(ByVal value As String)
            m_Fax = value
        End Set
    End Property
    Public Property ProspectFl() As Boolean
        Get
            Return m_ProspectFl
        End Get
        Set(ByVal value As Boolean)
            m_ProspectFl = value
        End Set
    End Property



    Public Property Locations() As Collection
        Get
            Return m_Locations
        End Get
        Set(ByVal value As Collection)
            m_Locations = value
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

    Public Function OpenClient(ByRef sError As String) As Boolean
        Dim sSQL As String

        Try
            m_Address = "" : m_City = "" : m_Fax = "" : m_Name = "" : m_Phone = "" : m_StateCd = "" : m_Zip = ""
            sError = ""
            sSQL = "SELECT * FROM Clients WHERE ClientId = " & m_ClientId
            If GetData(sSQL, m_ResultSet) > 0 Then
                Dim dr As DataRow = m_ResultSet.Rows(0)
                m_Address = UnNullToString(dr("Address"))
                m_City = UnNullToString(dr("City"))
                m_Fax = UnNullToString(dr("Fax"))
                m_Name = UnNullToString(dr("Name"))
                m_Phone = UnNullToString(dr("Phone"))
                m_StateCd = UnNullToString(dr("StateCd"))
                m_Zip = UnNullToString(dr("Zip"))
                If IsDBNull(dr("ProspectFl")) Then
                    m_ProspectFl = False
                Else
                    If dr("ProspectFl") = True Then m_ProspectFl = True Else m_ProspectFl = False
                End If

                Return True
            Else
                sError = "Client does not exist"
                Return False
            End If
        Catch ex As Exception
            sError = ex.Message
            Return False
        End Try

    End Function
    Public Function CreateClient(ByVal sName As String, Optional ByVal sAddress As String = "", Optional ByVal sCity As String = "", _
            Optional ByVal sStateCd As String = "", Optional ByVal sZIP As String = "", _
            Optional ByVal sPhone As String = "", Optional ByVal sFax As String = "", Optional ByVal sComment As String = "", Optional ByVal bHitDB As Boolean = False, _
            Optional ByVal bProspect As Boolean = False, Optional ByRef sError As String = "") As Boolean
        Dim sSQL As String, dt As New DataTable

        Try
            sName = Trim(sName)
            If sName = "" Then
                sError = "Client name missing"
                Return False
            End If
            If Trim(sStateCd) = "" Then
                sStateCd = "NULL"
            Else
                sStateCd = QuoStr(sStateCd)
            End If

            sError = ""
            sSQL = "SELECT AddDate, AddUser FROM Clients WHERE Name = " & QuoStr(sName)
            If GetData(sSQL, dt) > 0 Then
                Dim dr As DataRow = dt.Rows(0)
                sError = "Client already exists, it was added " & Format(dr("AddDate"), FORMATDATETIME) & " by " & UnNullToString(dr("AddUser"))
                Return False
            ElseIf bHitDB Then
                Dim lID As Long = CreateID(enumTable.enumClient)
                sSQL = "INSERT Clients (ClientId,Name,Address,City,StateCd,Zip,Phone,Fax,Comment,ProspectFl)" & _
                    " SELECT " & lID & "," & QuoStr(sName) & "," & QuoStr(sAddress) & "," & QuoStr(sCity) & "," & _
                    sStateCd & "," & _
                     QuoStr(sZIP) & "," & QuoStr(sPhone) & "," & QuoStr(sFax) & "," & QuoStr(sComment) & "," & IIf(bProspect, 1, 0)
                If ExecuteSQL(sSQL) = 1 Then
                    m_ClientId = lID
                    m_Name = sName
                    Return True
                End If
            Else
                Return True
            End If
        Catch ex As Exception
            sError = ex.Message
            Return False
        End Try

    End Function

End Class
