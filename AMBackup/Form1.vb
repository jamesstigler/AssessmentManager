Imports System.ServiceProcess
Imports System.Threading
Imports System.Windows.Forms
Imports System.Xml

Public Class Form1
    Private bActivated As Boolean = False

    Private Function StartSQLService(ByVal sService As String) As Boolean
        Try
            Dim svcctlSQL As New ServiceController(sService)
            svcctlSQL.Start()
            svcctlSQL.WaitForStatus(ServiceControllerStatus.Running)
            svcctlSQL.Close()
            svcctlSQL = Nothing
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function StopSQLService(ByVal sService As String) As Boolean
        Try
            Dim svcctlSQL As New ServiceController(sService)
            If svcctlSQL.Status = ServiceControllerStatus.Running Then svcctlSQL.Stop()
            svcctlSQL.WaitForStatus(ServiceControllerStatus.Stopped)
            svcctlSQL.Close()
            svcctlSQL = Nothing
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function


    Private Function GetParms(ByRef sService As String, ByRef sPath As String) As Boolean
        Try
            Dim sAppPath As String = System.IO.Path.GetDirectoryName(Application.ExecutablePath)
            Dim sXMLFile As String = sAppPath & "\AMBackupConfig.XML"
            Dim xXML As New XmlDocument
            xXML.LoadXml(LCase(IO.File.ReadAllText(sXMLFile)))
            Dim xNode As Xml.XmlNode = xXML.SelectSingleNode("//path")
            sPath = xNode.InnerText.ToUpper
            xNode = xXML.SelectSingleNode("//sqlservice")
            sService = xNode.InnerText.ToUpper
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function RunBackup(ByVal sPath As String, ByRef sError As String) As Boolean
        Try
            IO.Directory.CreateDirectory(sPath & "\Backup")
            FileCopy(sPath & "\AssessmentManagerData.MDF", sPath & "\Backup\AssessmentManagerData.MDF")
            'Thread.Sleep(10000)
            FileCopy(sPath & "\AssessmentManagerData_log.LDF", sPath & "\Backup\AssessmentManagerData_log.LDF")
            'Thread.Sleep(10000)
            Return True
        Catch ex As Exception
            sError = ex.Message
            Return False
        End Try
    End Function

    Private Sub Form1_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Dim sSQLService As String = ""
        Try
            If bActivated Then Exit Sub
            Dim sError As String = ""
            Dim sPath As String = ""
            Dim sLogFile As String = System.IO.Path.GetDirectoryName(Application.ExecutablePath) & "\AMBackup.LOG"
            txtStatus.Text = "Running backup, started at " & Now
            Me.Refresh()
            If GetParms(sSQLService, sPath) Then
                If StopSQLService(sSQLService) Then
                    If RunBackup(sPath, sError) Then
                        IO.File.AppendAllText(sLogFile, Now & " Database successfully backed up" & vbCrLf)
                    Else
                        IO.File.AppendAllText(sLogFile, Now & " Error backing up database:  " & sError & vbCrLf)
                    End If
                End If
            End If

            bActivated = True
        Catch ex As Exception


        End Try
        StartSQLService(sSQLService)
        Me.Close()
        Application.Exit()
    End Sub
End Class