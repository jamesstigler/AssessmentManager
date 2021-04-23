
Public Class clsAssessor

    Private m_AssessorId As Long
    Private m_TaxYear As Integer
    Private m_StateCd As String
    Private m_Name As String
    Private m_Address1 As String
    Private m_Address2 As String
    Private m_City As String
    Private m_Zip As String
    Private m_Phone As String
    Private m_Fax As String
    Private m_Website As String
    Private m_Comment As String
    Private m_BPPRatio As Collection
    Private m_RERatio As Collection
    Public Property AssessorId() As Long
        Get
            Return m_AssessorId
        End Get
        Set(ByVal value As Long)
            m_AssessorId = value
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

    Public Property TaxYear() As Integer
        Get
            Return m_TaxYear
        End Get
        Set(ByVal value As Integer)
            m_TaxYear = value
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

    Public Property Address1() As String
        Get
            Return m_Address1
        End Get
        Set(ByVal value As String)
            m_Address1 = value
        End Set
    End Property

    Public Property Address2() As String
        Get
            Return m_Address2
        End Get
        Set(ByVal value As String)
            m_Address2 = value
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

    Public Property WebSite() As String
        Get
            Return m_Website
        End Get
        Set(ByVal value As String)
            m_Website = value
        End Set
    End Property

    Public Property BPPRatio() As Collection
        Get
            Return m_BPPRatio
        End Get
        Set(ByVal value As Collection)
            m_BPPRatio = value
        End Set
    End Property

    Public Property RERatio() As Collection
        Get
            Return m_RERatio
        End Get
        Set(ByVal value As Collection)
            m_RERatio = value
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
    Public Function OpenAssessor(ByRef sError As String) As Boolean
        Dim dt As New DataTable, sSQL As String

        Try
            m_Address1 = "" : m_City = "" : m_Fax = "" : m_Name = "" : m_Phone = "" : m_StateCd = "" : m_Zip = ""
            m_Address2 = "" : m_BPPRatio = New Collection : m_Comment = "" : m_RERatio = New Collection : m_Website = ""
            sError = ""
            sSQL = "SELECT * FROM Assessors WHERE AssessorId = " & m_AssessorId
            If GetData(sSQL, dt) > 0 Then
                For Each dr In dt.Rows
                    If dr("TaxYear") = m_TaxYear Then
                        m_Address1 = UnNullToString(dr("Address1"))
                        m_Address2 = UnNullToString(dr("Address2"))
                        m_City = UnNullToString(dr("City"))
                        m_Fax = UnNullToString(dr("Fax"))
                        m_Name = UnNullToString(dr("Name"))
                        m_Phone = UnNullToString(dr("Phone"))
                        m_StateCd = UnNullToString(dr("StateCd"))
                        m_Zip = UnNullToString(dr("Zip"))
                        m_Website = UnNullToString(dr("Website"))
                        m_Comment = UnNullToString(dr("Comment"))
                    End If
                    m_BPPRatio.Add(UnNullToDouble(dr("BPPRatio")), dr("TaxYear"))
                    m_RERatio.Add(UnNullToDouble(dr("RERatio")), dr("TaxYear"))
                Next
                Return True
            Else
                sError = "Assessor does not exist"
                Return False
            End If
        Catch ex As Exception
            sError = ex.Message
            Return False
        End Try

    End Function
End Class
