Public Class clsReportDataSet
    Private m_SQL As String
    Private m_ReportDataTable As DataTable
    Private ReportSchema As New ReportsDataSet

    Public Property SQL() As String
        Get
            Return m_SQL
        End Get
        Set(ByVal value As String)
            m_SQL = value
        End Set
    End Property
    Public Property ReportDataTable As DataTable
        Get
            Return m_ReportDataTable
        End Get
        Set(value As DataTable)
            m_ReportDataTable = value
        End Set
    End Property

    Public Function GetReportDataSet() As DataSet
        Dim ds As New DataSet

        'perhaps implement this instead of writing to ReportData table
        'but need to fix the reports so the sorting is done in the report, not the datasource
        'see the sql that uses order by or group by in frmreport.configurereport
        'Dim dt As New DataTable
        'Dim dr As DataRow

        'dt.Columns.Add("NoRows", GetType(String))
        'dt.Columns.Add("Title01", GetType(String))
        'dt.Columns.Add("Text01", GetType(String))
        'dt.Columns.Add("Text03", GetType(String))
        'dt.Columns.Add("Text04", GetType(String))
        'dt.Columns.Add("Date01", GetType(Date))

        'dr = dt.NewRow()
        'dr("NoRows") = "norows1"
        'dr("Title01") = "title011"
        'dr("Text03") = "text031"
        'dt.Rows.Add(dr)
        'dr = dt.NewRow()
        'dr("NoRows") = "norows2"
        'dr("Title01") = "title012"
        'dr("Text03") = "text032"
        'dr("Date01") = Now
        'dt.Rows.Add(dr)
        'ds.Tables.Add(dt)
        ds = GetDataset(m_SQL)
        Return ds
    End Function
End Class
