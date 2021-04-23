Public Class frmPDF
    Private m_PDFSource As String
    Private m_SendToPrinter As Boolean

    Public Property PDFSource() As String
        Get
            Return m_PDFSource
        End Get
        Set(ByVal value As String)
            m_PDFSource = value
        End Set
    End Property
    Public Property SendToPrinter() As Boolean
        Get
            Return m_SendToPrinter
        End Get
        Set(ByVal value As Boolean)
            m_SendToPrinter = value
        End Set
    End Property

    Private Sub frmPDF_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            WebBrowser1.Navigate(m_PDFSource)  ' & "#toolbar=0")
            Me.Text = FileIO.FileSystem.GetFileInfo(m_PDFSource).Name
            'If m_SendToPrinter Then
            '    Dim doc As System.Windows.Forms.HtmlDocument
            '    doc = WebBrowser1.Document

            'End If
        Catch ex As Exception
            MsgBox("Error opening PDF:  " & ex.Message)
        End Try
    End Sub
End Class

