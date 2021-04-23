Public Class clsQuerySelect
    Private m_QueryTable As String
    Private m_QueryField As String
    Private m_QueryAlias As String
    Public Property QueryTable() As String
        Get
            Return m_QueryTable
        End Get
        Set(ByVal value As String)
            m_QueryTable = value
        End Set
    End Property
    Public Property QueryField() As String
        Get
            Return m_QueryField
        End Get
        Set(ByVal value As String)
            m_QueryField = value
        End Set
    End Property
    Public Property QueryAlias() As String
        Get
            Return m_QueryAlias
        End Get
        Set(ByVal value As String)
            m_QueryAlias = value
        End Set
    End Property
End Class
