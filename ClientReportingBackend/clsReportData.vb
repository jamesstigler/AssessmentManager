Public Class clsReportData
    Private m_ReportDataTable As DataTable = Nothing
    Private m_NoRows As String
    Private m_Title01 As String
    Private m_Title02 As String
    Private m_Title03 As String
    Private m_Text01 As String
    Private m_Text02 As String
    Private m_Text03 As String
    Private m_Text04 As String
    Private m_Text05 As String
    Private m_Text06 As String
    Private m_Text07 As String
    Private m_Text08 As String
    Private m_Text09 As String
    Private m_Text10 As String
    Private m_Text11 As String
    Private m_Text12 As String
    Private m_Text13 As String
    Private m_Text14 As String
    Private m_Text15 As String
    Private m_Text16 As String
    Private m_Text17 As String
    Private m_Text18 As String
    Private m_Text19 As String
    Private m_Text20 As String
    Private m_Number01 As Double
    Private m_Number02 As Double
    Private m_Number03 As Double
    Private m_Number04 As Double
    Private m_Number05 As Double
    Private m_Number06 As Double
    Private m_Number07 As Double
    Private m_Number08 As Double
    Private m_Number09 As Double
    Private m_Number10 As Double
    Private m_Number11 As Double
    Private m_Number12 As Double
    Private m_Number13 As Double
    Private m_Number14 As Double
    Private m_Number15 As Double
    Private m_Number16 As Double
    Private m_Number17 As Double
    Private m_Number18 As Double
    Private m_Number19 As Double
    Private m_Number20 As Double
    Private m_Date01 As DateTime
    Private m_Date02 As DateTime
    Private m_Date03 As DateTime
    Private m_Date04 As DateTime
    Private m_Date05 As DateTime
    Private m_Date06 As DateTime
    Private m_Date07 As DateTime
    Private m_Date08 As DateTime
    Private m_Date09 As DateTime
    Private m_Date10 As DateTime
    Private m_Date11 As DateTime
    Private m_Date12 As DateTime
    Private m_Date13 As DateTime
    Private m_Date14 As DateTime
    Private m_Date15 As DateTime
    Private m_Date16 As DateTime
    Private m_Date17 As DateTime
    Private m_Date18 As DateTime
    Private m_Date19 As DateTime
    Private m_Date20 As DateTime
    Private m_BarCode1 As String
    Private m_BarCode2 As String
    Private m_BarCodeDesc As String
    Private m_BarCodeImage As Byte()

    Public Property ReportDataTable As DataTable
        Get
            Return m_ReportDataTable
        End Get
        Set(value As DataTable)
            m_ReportDataTable = value
        End Set
    End Property

    Public Property NoRows As String
        Get
            Return m_NoRows
        End Get
        Set(value As String)
            m_NoRows = value
        End Set
    End Property

    Public Property Title01 As String
        Get
            Return m_Title01
        End Get
        Set(value As String)
            m_Title01 = value
        End Set
    End Property
    Public Property Title02 As String
        Get
            Return m_Title02
        End Get
        Set(value As String)
            m_Title02 = value
        End Set
    End Property
    Public Property Title03 As String
        Get
            Return m_Title03
        End Get
        Set(value As String)
            m_Title03 = value
        End Set
    End Property
    Public Property Text01 As String
        Get
            Return m_Text01
        End Get
        Set(value As String)
            m_Text01 = value
        End Set
    End Property
    Public Property Text02 As String
        Get
            Return m_Text02
        End Get
        Set(value As String)
            m_Text02 = value
        End Set
    End Property
    Public Property Text03 As String
        Get
            Return m_Text03
        End Get
        Set(value As String)
            m_Text03 = value
        End Set
    End Property
    Public Property Text04 As String
        Get
            Return m_Text04
        End Get
        Set(value As String)
            m_Text04 = value
        End Set
    End Property
    Public Property Text05 As String
        Get
            Return m_Text05
        End Get
        Set(value As String)
            m_Text05 = value
        End Set
    End Property
    Public Property Text06 As String
        Get
            Return m_Text06
        End Get
        Set(value As String)
            m_Text06 = value
        End Set
    End Property
    Public Property Text07 As String
        Get
            Return m_Text07
        End Get
        Set(value As String)
            m_Text07 = value
        End Set
    End Property
    Public Property Text08 As String
        Get
            Return m_Text08
        End Get
        Set(value As String)
            m_Text08 = value
        End Set
    End Property
    Public Property Text09 As String
        Get
            Return m_Text09
        End Get
        Set(value As String)
            m_Text09 = value
        End Set
    End Property
    Public Property Text10 As String
        Get
            Return m_Text10
        End Get
        Set(value As String)
            m_Text10 = value
        End Set
    End Property
    Public Property Text11 As String
        Get
            Return m_Text11
        End Get
        Set(value As String)
            m_Text11 = value
        End Set
    End Property
    Public Property Text12 As String
        Get
            Return m_Text12
        End Get
        Set(value As String)
            m_Text12 = value
        End Set
    End Property
    Public Property Text13 As String
        Get
            Return m_Text13
        End Get
        Set(value As String)
            m_Text13 = value
        End Set
    End Property
    Public Property Text14 As String
        Get
            Return m_Text14
        End Get
        Set(value As String)
            m_Text14 = value
        End Set
    End Property
    Public Property Text15 As String
        Get
            Return m_Text15
        End Get
        Set(value As String)
            m_Text15 = value
        End Set
    End Property
    Public Property Text16 As String
        Get
            Return m_Text16
        End Get
        Set(value As String)
            m_Text16 = value
        End Set
    End Property
    Public Property Text17 As String
        Get
            Return m_Text17
        End Get
        Set(value As String)
            m_Text17 = value
        End Set
    End Property
    Public Property Text18 As String
        Get
            Return m_Text18
        End Get
        Set(value As String)
            m_Text18 = value
        End Set
    End Property
    Public Property Text19 As String
        Get
            Return m_Text19
        End Get
        Set(value As String)
            m_Text19 = value
        End Set
    End Property
    Public Property Text20 As String
        Get
            Return m_Text20
        End Get
        Set(value As String)
            m_Text20 = value
        End Set
    End Property

    Public Property Number01 As Double
        Get
            Return m_Number01
        End Get
        Set(value As Double)
            m_Number01 = value
        End Set
    End Property
    Public Property Number02 As Double
        Get
            Return m_Number02
        End Get
        Set(value As Double)
            m_Number02 = value
        End Set
    End Property
    Public Property Number03 As Double
        Get
            Return m_Number03
        End Get
        Set(value As Double)
            m_Number03 = value
        End Set
    End Property
    Public Property Number04 As Double
        Get
            Return m_Number04
        End Get
        Set(value As Double)
            m_Number04 = value
        End Set
    End Property
    Public Property Number05 As Double
        Get
            Return m_Number05
        End Get
        Set(value As Double)
            m_Number05 = value
        End Set
    End Property
    Public Property Number06 As Double
        Get
            Return m_Number06
        End Get
        Set(value As Double)
            m_Number06 = value
        End Set
    End Property
    Public Property Number07 As Double
        Get
            Return m_Number07
        End Get
        Set(value As Double)
            m_Number07 = value
        End Set
    End Property
    Public Property Number08 As Double
        Get
            Return m_Number08
        End Get
        Set(value As Double)
            m_Number08 = value
        End Set
    End Property
    Public Property Number09 As Double
        Get
            Return m_Number09
        End Get
        Set(value As Double)
            m_Number09 = value
        End Set
    End Property
    Public Property Number10 As Double
        Get
            Return m_Number10
        End Get
        Set(value As Double)
            m_Number10 = value
        End Set
    End Property
    Public Property Number11 As Double
        Get
            Return m_Number11
        End Get
        Set(value As Double)
            m_Number11 = value
        End Set
    End Property
    Public Property Number12 As Double
        Get
            Return m_Number12
        End Get
        Set(value As Double)
            m_Number12 = value
        End Set
    End Property
    Public Property Number13 As Double
        Get
            Return m_Number13
        End Get
        Set(value As Double)
            m_Number13 = value
        End Set
    End Property
    Public Property Number14 As Double
        Get
            Return m_Number14
        End Get
        Set(value As Double)
            m_Number14 = value
        End Set
    End Property
    Public Property Number15 As Double
        Get
            Return m_Number15
        End Get
        Set(value As Double)
            m_Number15 = value
        End Set
    End Property
    Public Property Number16 As Double
        Get
            Return m_Number16
        End Get
        Set(value As Double)
            m_Number16 = value
        End Set
    End Property
    Public Property Number17 As Double
        Get
            Return m_Number17
        End Get
        Set(value As Double)
            m_Number17 = value
        End Set
    End Property
    Public Property Number18 As Double
        Get
            Return m_Number18
        End Get
        Set(value As Double)
            m_Number18 = value
        End Set
    End Property
    Public Property Number19 As Double
        Get
            Return m_Number19
        End Get
        Set(value As Double)
            m_Number19 = value
        End Set
    End Property
    Public Property Number20 As Double
        Get
            Return m_Number20
        End Get
        Set(value As Double)
            m_Number20 = value
        End Set
    End Property
    Public Property Date01 As DateTime
        Get
            Return m_Date01
        End Get
        Set(value As DateTime)
            m_Date01 = value
        End Set
    End Property
    Public Property Date02 As DateTime
        Get
            Return m_Date02
        End Get
        Set(value As DateTime)
            m_Date02 = value
        End Set
    End Property
    Public Property Date03 As DateTime
        Get
            Return m_Date03
        End Get
        Set(value As DateTime)
            m_Date03 = value
        End Set
    End Property
    Public Property Date04 As DateTime
        Get
            Return m_Date04
        End Get
        Set(value As DateTime)
            m_Date04 = value
        End Set
    End Property
    Public Property Date05 As DateTime
        Get
            Return m_Date05
        End Get
        Set(value As DateTime)
            m_Date05 = value
        End Set
    End Property
    Public Property Date06 As DateTime
        Get
            Return m_Date06
        End Get
        Set(value As DateTime)
            m_Date06 = value
        End Set
    End Property
    Public Property Date07 As DateTime
        Get
            Return m_Date07
        End Get
        Set(value As DateTime)
            m_Date07 = value
        End Set
    End Property
    Public Property Date08 As DateTime
        Get
            Return m_Date08
        End Get
        Set(value As DateTime)
            m_Date08 = value
        End Set
    End Property
    Public Property Date09 As DateTime
        Get
            Return m_Date09
        End Get
        Set(value As DateTime)
            m_Date09 = value
        End Set
    End Property
    Public Property Date10 As DateTime
        Get
            Return m_Date10
        End Get
        Set(value As DateTime)
            m_Date10 = value
        End Set
    End Property
    Public Property Date11 As DateTime
        Get
            Return m_Date11
        End Get
        Set(value As DateTime)
            m_Date11 = value
        End Set
    End Property
    Public Property Date12 As DateTime
        Get
            Return m_Date12
        End Get
        Set(value As DateTime)
            m_Date12 = value
        End Set
    End Property
    Public Property Date13 As DateTime
        Get
            Return m_Date13
        End Get
        Set(value As DateTime)
            m_Date13 = value
        End Set
    End Property
    Public Property Date14 As DateTime
        Get
            Return m_Date14
        End Get
        Set(value As DateTime)
            m_Date14 = value
        End Set
    End Property
    Public Property Date15 As DateTime
        Get
            Return m_Date15
        End Get
        Set(value As DateTime)
            m_Date15 = value
        End Set
    End Property
    Public Property Date16 As DateTime
        Get
            Return m_Date16
        End Get
        Set(value As DateTime)
            m_Date16 = value
        End Set
    End Property
    Public Property Date17 As DateTime
        Get
            Return m_Date17
        End Get
        Set(value As DateTime)
            m_Date17 = value
        End Set
    End Property
    Public Property Date18 As DateTime
        Get
            Return m_Date18
        End Get
        Set(value As DateTime)
            m_Date18 = value
        End Set
    End Property
    Public Property Date19 As DateTime
        Get
            Return m_Date19
        End Get
        Set(value As DateTime)
            m_Date19 = value
        End Set
    End Property
    Public Property Date20 As DateTime
        Get
            Return m_Date20
        End Get
        Set(value As DateTime)
            m_Date20 = value
        End Set
    End Property
    Public Property BarCode1 As String
        Get
            Return m_BarCode1
        End Get
        Set(value As String)
            m_BarCode1 = value
        End Set
    End Property
    Public Property BarCode2 As String
        Get
            Return m_BarCode2
        End Get
        Set(value As String)
            m_BarCode2 = value
        End Set
    End Property
    Public Property BarCodeDesc As String
        Get
            Return m_BarCodeDesc
        End Get
        Set(value As String)
            m_BarCodeDesc = value
        End Set
    End Property
    Public Property BarCodeImage As Byte()
        Get
            Return m_BarCodeImage
        End Get
        Set(value As Byte())
            m_BarCodeImage = value
        End Set
    End Property

    Public Sub WriteReportData()
        Dim dr As DataRow
        If m_ReportDataTable Is Nothing Then BuildReportDataTable()
        dr = m_ReportDataTable.NewRow
        dr("NoRows") = m_NoRows
        dr("Title01") = m_Title01
        dr("Title02") = m_Title02
        dr("Title03") = m_Title03

        dr("Text01") = m_Text01
        dr("Text02") = m_Text02
        dr("Text03") = m_Text03
        dr("Text04") = m_Text04
        dr("Text05") = m_Text05
        dr("Text06") = m_Text06
        dr("Text07") = m_Text07
        dr("Text08") = m_Text08
        dr("Text09") = m_Text09
        dr("Text10") = m_Text10
        dr("Text11") = m_Text11
        dr("Text12") = m_Text12
        dr("Text13") = m_Text13
        dr("Text14") = m_Text14
        dr("Text15") = m_Text15
        dr("Text16") = m_Text16
        dr("Text17") = m_Text17
        dr("Text18") = m_Text18
        dr("Text19") = m_Text19
        dr("Text20") = m_Text20

        dr("Number01") = m_Number01
        dr("Number02") = m_Number02
        dr("Number03") = m_Number03
        dr("Number04") = m_Number04
        dr("Number05") = m_Number05
        dr("Number06") = m_Number06
        dr("Number07") = m_Number07
        dr("Number08") = m_Number08
        dr("Number09") = m_Number09
        dr("Number10") = m_Number10
        dr("Number11") = m_Number11
        dr("Number12") = m_Number12
        dr("Number13") = m_Number13
        dr("Number14") = m_Number14
        dr("Number15") = m_Number15
        dr("Number16") = m_Number16
        dr("Number17") = m_Number17
        dr("Number18") = m_Number18
        dr("Number19") = m_Number19
        dr("Number20") = m_Number20

        dr("Date01") = m_Date01
        dr("Date02") = m_Date02
        dr("Date03") = m_Date03
        dr("Date04") = m_Date04
        dr("Date05") = m_Date05
        dr("Date06") = m_Date06
        dr("Date07") = m_Date07
        dr("Date08") = m_Date08
        dr("Date09") = m_Date09
        dr("Date10") = m_Date10
        dr("Date11") = m_Date11
        dr("Date12") = m_Date12
        dr("Date13") = m_Date13
        dr("Date14") = m_Date14
        dr("Date15") = m_Date15
        dr("Date16") = m_Date16
        dr("Date17") = m_Date17
        dr("Date18") = m_Date18
        dr("Date19") = m_Date19
        dr("Date20") = m_Date20

        dr("BarCode1") = m_BarCode1
        dr("BarCode2") = m_BarCode2
        dr("BarCodeDesc") = m_BarCodeDesc
        dr("BarCodeImage") = m_BarCodeImage

        m_ReportDataTable.Rows.Add(dr)
    End Sub
    Private Sub BuildReportDataTable()
        m_ReportDataTable = New DataTable
        m_ReportDataTable.Columns.Add("NoRows", GetType(String))
        m_ReportDataTable.Columns.Add("Title01", GetType(String))
        m_ReportDataTable.Columns.Add("Title02", GetType(String))
        m_ReportDataTable.Columns.Add("Title03", GetType(String))

        m_ReportDataTable.Columns.Add("Text01", GetType(String))
        m_ReportDataTable.Columns.Add("Text02", GetType(String))
        m_ReportDataTable.Columns.Add("Text03", GetType(String))
        m_ReportDataTable.Columns.Add("Text04", GetType(String))
        m_ReportDataTable.Columns.Add("Text05", GetType(String))
        m_ReportDataTable.Columns.Add("Text06", GetType(String))
        m_ReportDataTable.Columns.Add("Text07", GetType(String))
        m_ReportDataTable.Columns.Add("Text08", GetType(String))
        m_ReportDataTable.Columns.Add("Text09", GetType(String))
        m_ReportDataTable.Columns.Add("Text10", GetType(String))
        m_ReportDataTable.Columns.Add("Text11", GetType(String))
        m_ReportDataTable.Columns.Add("Text12", GetType(String))
        m_ReportDataTable.Columns.Add("Text13", GetType(String))
        m_ReportDataTable.Columns.Add("Text14", GetType(String))
        m_ReportDataTable.Columns.Add("Text15", GetType(String))
        m_ReportDataTable.Columns.Add("Text16", GetType(String))
        m_ReportDataTable.Columns.Add("Text17", GetType(String))
        m_ReportDataTable.Columns.Add("Text18", GetType(String))
        m_ReportDataTable.Columns.Add("Text19", GetType(String))
        m_ReportDataTable.Columns.Add("Text20", GetType(String))

        m_ReportDataTable.Columns.Add("Number01", GetType(Double))
        m_ReportDataTable.Columns.Add("Number02", GetType(Double))
        m_ReportDataTable.Columns.Add("Number03", GetType(Double))
        m_ReportDataTable.Columns.Add("Number04", GetType(Double))
        m_ReportDataTable.Columns.Add("Number05", GetType(Double))
        m_ReportDataTable.Columns.Add("Number06", GetType(Double))
        m_ReportDataTable.Columns.Add("Number07", GetType(Double))
        m_ReportDataTable.Columns.Add("Number08", GetType(Double))
        m_ReportDataTable.Columns.Add("Number09", GetType(Double))
        m_ReportDataTable.Columns.Add("Number10", GetType(Double))
        m_ReportDataTable.Columns.Add("Number11", GetType(Double))
        m_ReportDataTable.Columns.Add("Number12", GetType(Double))
        m_ReportDataTable.Columns.Add("Number13", GetType(Double))
        m_ReportDataTable.Columns.Add("Number14", GetType(Double))
        m_ReportDataTable.Columns.Add("Number15", GetType(Double))
        m_ReportDataTable.Columns.Add("Number16", GetType(Double))
        m_ReportDataTable.Columns.Add("Number17", GetType(Double))
        m_ReportDataTable.Columns.Add("Number18", GetType(Double))
        m_ReportDataTable.Columns.Add("Number19", GetType(Double))
        m_ReportDataTable.Columns.Add("Number20", GetType(Double))

        m_ReportDataTable.Columns.Add("Date01", GetType(DateTime))
        m_ReportDataTable.Columns.Add("Date02", GetType(DateTime))
        m_ReportDataTable.Columns.Add("Date03", GetType(DateTime))
        m_ReportDataTable.Columns.Add("Date04", GetType(DateTime))
        m_ReportDataTable.Columns.Add("Date05", GetType(DateTime))
        m_ReportDataTable.Columns.Add("Date06", GetType(DateTime))
        m_ReportDataTable.Columns.Add("Date07", GetType(DateTime))
        m_ReportDataTable.Columns.Add("Date08", GetType(DateTime))
        m_ReportDataTable.Columns.Add("Date09", GetType(DateTime))
        m_ReportDataTable.Columns.Add("Date10", GetType(DateTime))
        m_ReportDataTable.Columns.Add("Date11", GetType(DateTime))
        m_ReportDataTable.Columns.Add("Date12", GetType(DateTime))
        m_ReportDataTable.Columns.Add("Date13", GetType(DateTime))
        m_ReportDataTable.Columns.Add("Date14", GetType(DateTime))
        m_ReportDataTable.Columns.Add("Date15", GetType(DateTime))
        m_ReportDataTable.Columns.Add("Date16", GetType(DateTime))
        m_ReportDataTable.Columns.Add("Date17", GetType(DateTime))
        m_ReportDataTable.Columns.Add("Date18", GetType(DateTime))
        m_ReportDataTable.Columns.Add("Date19", GetType(DateTime))
        m_ReportDataTable.Columns.Add("Date20", GetType(DateTime))

        m_ReportDataTable.Columns.Add("BarCode1", GetType(String))
        m_ReportDataTable.Columns.Add("BarCode2", GetType(String))
        m_ReportDataTable.Columns.Add("BarCodeDesc", GetType(String))
        m_ReportDataTable.Columns.Add("BarCodeImage", GetType(Byte()))

    End Sub
End Class
