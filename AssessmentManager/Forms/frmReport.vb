Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmReport
    Private m_Type As enumReport
    Private m_SendToPrinter As Boolean
    Private m_PDFFileName As String
    Private m_ExportFolder As String
    Private m_ShowPDF As Boolean
    Private m_JustCreatePDF As Boolean
    Private m_ReportData As DataTable

    Public Property ReportType() As Integer
        Get
            Return m_Type
        End Get
        Set(ByVal value As Integer)
            m_Type = value
        End Set
    End Property
    Public Property ReportData() As DataTable
        Get
            Return m_ReportData
        End Get
        Set(value As DataTable)
            m_ReportData = value
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
    Public Property PDFFileName() As String
        Get
            Return m_PDFFileName
        End Get
        Set(ByVal value As String)
            m_PDFFileName = value
        End Set
    End Property
    Public Property ExportFolder() As String
        Get
            Return m_ExportFolder
        End Get
        Set(ByVal value As String)
            m_ExportFolder = value
        End Set
    End Property
    Public Property JustCreatePDF() As Boolean
        Get
            Return m_JustCreatePDF
        End Get
        Set(value As Boolean)
            m_JustCreatePDF = value
        End Set
    End Property
    Public Property ShowPDF() As Boolean
        Get
            Return m_ShowPDF
        End Get
        Set(ByVal value As Boolean)
            m_ShowPDF = value
        End Set
    End Property

    Private Function ConfigureReport() As Boolean
        Try
            Dim sReportFile As String = ""
            Dim dtReportData As New DataTable
            Dim rpt = New ReportDocument

            If Not modReports.ConfigureReport(m_Type, m_SendToPrinter, m_ShowPDF, m_PDFFileName, m_JustCreatePDF,
                    m_ExportFolder, m_ReportData, sReportFile, dtReportData) Then
                Return False
            End If
            rpt.Load(sReportFile)
            rpt.SetDataSource(dtReportData)

            'If m_ShowPDF Or m_ExportFolder <> "" Or m_JustCreatePDF Then
            '    IO.File.Delete(AppData.TempPath & "\" & m_PDFFileName)
            '    rpt.ExportToDisk(ExportFormatType.PortableDocFormat, AppData.TempPath & "\" & m_PDFFileName)
            'End If
            ''If FileIO.FileSystem.FileExists(m_PDFFileName) Then
            'If m_ShowPDF = True Then
            '    RunAdobe(AppData.TempPath & "\" & m_PDFFileName, m_SendToPrinter)
            'ElseIf m_ExportFolder <> "" Then
            '    FileIO.FileSystem.CopyFile(AppData.TempPath & "\" & m_PDFFileName, m_ExportFolder & IIf(Microsoft.VisualBasic.Right(m_ExportFolder, "1") = "\", "", "\") & m_PDFFileName, True)
            'End If

            'If m_SendToPrinter Then rpt.PrintToPrinter(1, False, 0, 0)



            reportviewer.ReportSource = rpt

            'If m_SendToPrinter Or m_ExportFolder <> "" Or m_JustCreatePDF Then
            '    Me.Close()
            'Else
            reportviewer.Zoom(1)
            'End If

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub frmReport_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        Try
            If m_JustCreatePDF Or m_ShowPDF Or m_ExportFolder <> "" Then Me.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frmReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            ConfigureReport()
        Catch ex As Exception
        End Try
    End Sub

End Class