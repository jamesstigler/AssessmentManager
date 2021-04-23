Public Class clsQuery
    Private m_SelectList As Collection
    Private m_JoinStatement As String
    Private m_WhereClause As String
    Public Property SelectList() As Collection
        Get
            Return m_SelectList
        End Get
        Set(ByVal value As Collection)
            m_SelectList = value
        End Set
    End Property
    Public Property JoinStatement() As String
        Get
            Return m_JoinStatement
        End Get
        Set(ByVal value As String)
            m_JoinStatement = value
        End Set
    End Property
    Public Property WhereClause() As String
        Get
            Return m_WhereClause
        End Get
        Set(ByVal value As String)
            m_WhereClause = value
        End Set
    End Property
End Class
