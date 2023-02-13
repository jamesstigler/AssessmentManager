Public Class frmImportFactorCodes
    Private m_FactorEntityId As Long
    Private bActivated As Boolean
    Private iNumberOfColumns As Integer

    Public Property FactorEntityId() As Long
        Get
            Return m_FactorEntityId
        End Get
        Set(ByVal value As Long)
            m_FactorEntityId = value
        End Set
    End Property

    Private Function ImportFile()
        Dim vFileContents As Object, lColumn As Long, lRow As Long, sRowContents() As String

        dgImport.Columns.Clear()

        If Not modMain.ImportFile(vFileContents) Then Exit Function

        ReDim sRowContents(UBound(vFileContents, 1))
        iNumberOfColumns = UBound(vFileContents, 1) + 1

        cboAge.Items.Clear()
        cboDescription.Items.Add("")
        cboFactorCode.Items.Clear()
        cboPercentage.Items.Add("")

        For lRow = 1 To iNumberOfColumns
            cboAge.Items.Add(lRow)
            cboDescription.Items.Add(lRow)
            cboFactorCode.Items.Add(lRow)
            cboPercentage.Items.Add(lRow)
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
        dgImport.Width = Me.Width - 20
        dgImport.Height = Me.Height - 200

    End Sub




    Private Sub RenameColumns()
        Dim iColumn As Integer, i As Integer


        For i = 0 To dgImport.Columns.Count - 1
            If dgImport.Columns(i).HeaderText = "Factor Code" Then dgImport.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboFactorCode.Text) <> "" Then
            iColumn = Val(cboFactorCode.Text) - 1
            dgImport.Columns.Item(iColumn).HeaderText = "Factor Code"
        End If

        For i = 0 To dgImport.Columns.Count - 1
            If dgImport.Columns(i).HeaderText = "Description" Then dgImport.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboDescription.Text) <> "" Then
            iColumn = Val(cboDescription.Text) - 1
            dgImport.Columns.Item(iColumn).HeaderText = "Description"
        End If

        For i = 0 To dgImport.Columns.Count - 1
            If dgImport.Columns(i).HeaderText = "Age" Then dgImport.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboAge.Text) <> "" Then
            iColumn = Val(cboAge.Text) - 1
            dgImport.Columns.Item(iColumn).HeaderText = "Age"
        End If

        For i = 0 To dgImport.Columns.Count - 1
            If dgImport.Columns(i).HeaderText = "Percentage" Then dgImport.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboPercentage.Text) <> "" Then
            iColumn = Val(cboPercentage.Text) - 1
            dgImport.Columns.Item(iColumn).HeaderText = "Percentage"
        End If

    End Sub


    Private Sub cbo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles cboAge.TextChanged, cboDescription.TextChanged, cboFactorCode.TextChanged, cboPercentage.TextChanged
        If Trim(sender.text) = "" Or (Val(sender.text) >= 1 And Val(sender.text) <= iNumberOfColumns) Then
            RenameColumns()
        End If
    End Sub



    Private Sub cmdNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNext.Click
        CreateFactors(False)
        cmdNext.Enabled = False
        cmdFinish.Enabled = True
    End Sub
    Private Sub CreateFactors(ByVal bHitDB As Boolean)
        Dim lRow As Long, iCol As Integer
        Dim sFactorCode As String, sDescription As String, iAge As Integer, dPercentage As Double, sError As String
        Dim bUserHasSelectedRows As Boolean = False, myrow As DataGridViewRow
        'Gather unique list of factor codes then delete existing Factor records before creating new ones
        'First, loop through rows to build a list of factor codes, then delete those codes, then loop through grid to insert new ones
        Dim FactorsToDelete As List(Of String), bAccumFactors As Boolean
        Dim bBreak As Boolean

        Try
            If bHitDB = False Then bBreak = True Else bBreak = False

            If dgImport.SelectedRows.Count > 0 Then
                bUserHasSelectedRows = True
            End If

            dgImport.Columns("Status").Visible = True
            bAccumFactors = True
            FactorsToDelete = New List(Of String)
            Do
                If bAccumFactors = False And bHitDB = True And FactorsToDelete.Count > 0 Then
                    For Each s As String In FactorsToDelete
                        Dim sql As New StringBuilder("DELETE Factors WHERE TaxYear = ")
                        sql.Append(AppData.TaxYear).Append(" AND FactorEntityId = ").Append(m_FactorEntityId)
                        sql.Append(" AND FactorCode = ").Append(QuoStr(s))
                        ExecuteSQL(sql.ToString)
                    Next
                End If
                For lRow = 0 To dgImport.Rows.Count - 1
                    myrow = dgImport.Rows(lRow)
                    If (bUserHasSelectedRows And myrow.Selected) Or bUserHasSelectedRows = False Then
                        sFactorCode = "" : sDescription = "" : iAge = 0 : dPercentage = 0
                        For iCol = 0 To dgImport.Columns.Count - 1
                            If dgImport.Columns(iCol).HeaderText = "Factor Code" Then sFactorCode = UCase(Trim(dgImport.Rows(lRow).Cells(iCol).Value))
                            If dgImport.Columns(iCol).HeaderText = "Description" Then sDescription = Trim(dgImport.Rows(lRow).Cells(iCol).Value)
                            If dgImport.Columns(iCol).HeaderText = "Age" Then iAge = Val(Trim(dgImport.Rows(lRow).Cells(iCol).Value))
                            If dgImport.Columns(iCol).HeaderText = "Percentage" Then dPercentage = Val(Trim(dgImport.Rows(lRow).Cells(iCol).Value))
                        Next
                        If sFactorCode = "" Then
                            dgImport.Rows(lRow).Cells("Status").Value = "Error:  Missing data"
                        Else
                            If bHitDB Then
                                If bAccumFactors Then
                                    If FactorsToDelete.Contains(sFactorCode) = False Then
                                        FactorsToDelete.Add(sFactorCode)
                                    End If
                                Else
                                    AddFactorCode(m_FactorEntityId, sFactorCode, sDescription, sError)
                                    sError = ""
                                    If AddFactorAge(m_FactorEntityId, sFactorCode, iAge, dPercentage, sError) Then
                                        dgImport.Rows(lRow).Cells("Status").Value = "OK"
                                    Else
                                        dgImport.Rows(lRow).Cells("Status").Value = "Error:  " & sError
                                    End If
                                End If
                            Else
                                dgImport.Rows(lRow).Cells("Status").Value = "OK"
                            End If
                        End If
                    End If
                Next
                If bBreak = True Then Exit Do
                bAccumFactors = False
                bBreak = True
            Loop


        Catch ex As Exception
            MsgBox("Error importing:  " & ex.Message)
        End Try


    End Sub

    Private Sub cmdFinish_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdFinish.Click
        CreateFactors(True)
        cmdFinish.Enabled = False
    End Sub
End Class