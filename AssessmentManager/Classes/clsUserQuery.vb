Public Class clsUserQuery
    Private m_QueryType As UserQueryType
    Private m_Queries As Collection
    Public Property Queries() As Collection
        Get
            Return m_Queries
        End Get
        Set(ByVal value As Collection)
            m_Queries = value
        End Set
    End Property
    Public Property QueryType() As Integer
        Get
            Return m_QueryType
        End Get
        Set(ByVal value As Integer)
            m_QueryType = value
        End Set
    End Property
End Class
