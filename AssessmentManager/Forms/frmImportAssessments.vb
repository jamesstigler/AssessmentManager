Public Class frmImportAssessments
    Private m_ClientId As Long
    Private m_LocationId As Long
    Private m_TaxYear As Integer
    Private m_TypeOfImport As enumTable
    Private bActivated As Boolean
    Private iNumberOfColumns As Integer


    Public Property TaxYear() As Integer
        Get
            Return m_TaxYear
        End Get
        Set(ByVal value As Integer)
            m_TaxYear = value
        End Set
    End Property
    Public Property ClientId() As Long
        Get
            Return m_ClientId
        End Get
        Set(ByVal value As Long)
            m_ClientId = value
        End Set
    End Property
    Public Property LocationId() As Long
        Get
            Return m_LocationId
        End Get
        Set(ByVal value As Long)
            m_LocationId = value
        End Set
    End Property
    Public Property TypeOfImport() As Integer
        Get
            Return m_TypeOfImport
        End Get
        Set(ByVal value As Integer)
            m_TypeOfImport = value
        End Set
    End Property


    Private Function ImportFile() As Boolean
        Dim vFileContents As New Object, lColumn As Long = 0, lRow As Long = 0, sRowContents() As String


        dgImport.Columns.Clear()

        If Not modMain.ImportFile(vFileContents) Then Return False

        ReDim sRowContents(UBound(vFileContents, 1))
        iNumberOfColumns = UBound(vFileContents, 1) + 1

        cboAcctNum.Items.Clear()
        cboAcctNum.Items.Add("")
        cboComment.Items.Clear()
        cboComment.Items.Add("")


        For lRow = 1 To iNumberOfColumns
            cboAcctNum.Items.Add(lRow)
            cboComment.Items.Add(lRow)
        Next


        For lColumn = 0 To UBound(vFileContents, 1)
            dgImport.Columns.Add(lColumn + 1, lColumn + 1)
        Next

        For lRow = 0 To UBound(vFileContents, 2)
            For lColumn = 0 To UBound(vFileContents, 1)
                sRowContents(lColumn) = vFileContents(lColumn, lRow)
            Next

            dgImport.Rows.Add(sRowContents)
        Next
        dgImport.Columns.Add("Status", "Status")
        dgImport.Columns("Status").Visible = False
        cmdNext.Enabled = True
        Return True

    End Function

    Private Sub frmImport_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If bActivated Then Exit Sub
        bActivated = True
        ImportFile()
    End Sub


    Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub frmImport_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Dim Buttons(2) As Control

        Buttons(0) = cmdNext
        Buttons(1) = cmdFinish
        Buttons(2) = cmdCancel
        PlaceButtons(Me, Buttons)

        If Me.WindowState = FormWindowState.Minimized Then Exit Sub
        Dim mesize As Size = Me.ClientSize
        dgImport.Width = mesize.Width - 10
        dgImport.Height = mesize.Height - 120

    End Sub




    Private Sub RenameColumns()
        Dim iColumn As Integer, i As Integer


        For i = 0 To dgImport.Columns.Count - 1
            If dgImport.Columns(i).HeaderText = "Account Number" Then dgImport.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboAcctNum.Text) <> "" Then
            iColumn = Val(cboAcctNum.Text) - 1
            dgImport.Columns.Item(iColumn).HeaderText = "Account Number"
        End If

        For i = 0 To dgImport.Columns.Count - 1
            If dgImport.Columns(i).HeaderText = "Comment" Then dgImport.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboComment.Text) <> "" Then
            iColumn = Val(cboComment.Text) - 1
            dgImport.Columns.Item(iColumn).HeaderText = "Comment"
        End If


    End Sub


    Private Sub cbo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles cboAcctNum.TextChanged, cboComment.TextChanged
        If Trim(sender.text) = "" Or (Val(sender.text) >= 1 And Val(sender.text) <= iNumberOfColumns) Then
            RenameColumns()
        End If
    End Sub



    Private Sub cmdNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNext.Click
        CreateAssessments(False)
        cmdNext.Enabled = False
        cmdFinish.Enabled = True
    End Sub
    Private Sub CreateAssessments(ByVal bHitDB As Boolean)
        Dim lRow As Long = 0, iCol As Integer = 0, cBPP As clsAssessmentBPP, cRE As clsAssessmentRE
        Dim sAcctNum As String = "", sComment As String = "", sError As String = ""

        Try
            dgImport.Columns("Status").Visible = True
            For lRow = 0 To dgImport.Rows.Count - 1
                sAcctNum = "" : sComment = ""
                For iCol = 0 To dgImport.Columns.Count - 1
                    If dgImport.Columns(iCol).HeaderText = "Account Number" Then sAcctNum = Trim(dgImport.Rows(lRow).Cells(iCol).Value)
                    If dgImport.Columns(iCol).HeaderText = "Comment" Then sComment = Trim(dgImport.Rows(lRow).Cells(iCol).Value)
                Next
                If sAcctNum = "" Then
                    dgImport.Rows(lRow).Cells("Status").Value = "Error:  Missing data"
                Else
                    If m_TypeOfImport = enumTable.enumAssessmentBPP Then
                        cBPP = New clsAssessmentBPP
                        With cBPP
                            .AcctNum = sAcctNum
                            .ClientId = m_ClientId
                            .LocationId = m_LocationId
                            .Comment = sComment
                            .TaxYear = AppData.TaxYear
                        End With
                        If cBPP.CreateAssessment(bHitDB, 0, 0, sError) = True Then
                            dgImport.Rows(lRow).Cells("Status").Value = "OK"
                        Else
                            dgImport.Rows(lRow).Cells("Status").Value = "Error:  " & sError
                        End If
                    ElseIf m_TypeOfImport = enumTable.enumAssessmentRE Then
                        cRE = New clsAssessmentRE
                        With cRE
                            .AcctNum = sAcctNum
                            .ClientId = m_ClientId
                            .LocationId = m_LocationId
                            .Comment = sComment
                            .TaxYear = AppData.TaxYear
                        End With
                        If cRE.CreateAssessment(bHitDB, 0, 0, sError) = True Then
                            dgImport.Rows(lRow).Cells("Status").Value = "OK"
                        Else
                            dgImport.Rows(lRow).Cells("Status").Value = "Error:  " & sError
                        End If

                    End If
                End If
            Next

        Catch ex As Exception
            MsgBox("Error importing:  " & ex.Message)
        End Try


    End Sub

    Private Sub cmdFinish_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdFinish.Click
        CreateAssessments(True)
        cmdFinish.Enabled = False
    End Sub

    Private Sub frmImportAssessments_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class