Public Class frmImportFactoringEntities
    Private bActivated As Boolean
    Private iNumberOfColumns As Integer

    Private Function ImportFile()
        Dim vFileContents As Object, lColumn As Long, lRow As Long, sRowContents() As String


        dgImport.Columns.Clear()

        If Not modMain.ImportFile(vFileContents) Then Exit Function

        ReDim sRowContents(UBound(vFileContents, 1))
        iNumberOfColumns = UBound(vFileContents, 1) + 1

        cboStateCd.Items.Clear()
        cboStateCd.Items.Add("")
        cboName.Items.Clear()
        cboName.Items.Add("")


        For lRow = 1 To iNumberOfColumns
            cboStateCd.Items.Add(lRow)
            cboName.Items.Add(lRow)
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
            If dgImport.Columns(i).HeaderText = "State Code" Then dgImport.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboStateCd.Text) <> "" Then
            iColumn = Val(cboStateCd.Text) - 1
            dgImport.Columns.Item(iColumn).HeaderText = "State Code"
        End If

        For i = 0 To dgImport.Columns.Count - 1
            If dgImport.Columns(i).HeaderText = "Name" Then dgImport.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboName.Text) <> "" Then
            iColumn = Val(cboName.Text) - 1
            dgImport.Columns.Item(iColumn).HeaderText = "Name"
        End If


    End Sub


    Private Sub cbo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles cboStateCd.TextChanged, cboName.TextChanged
        If Trim(sender.text) = "" Or (Val(sender.text) >= 1 And Val(sender.text) <= iNumberOfColumns) Then
            RenameColumns()
        End If
    End Sub



    Private Sub cmdNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNext.Click
        CreateEntities(False)
        cmdNext.Enabled = False
        cmdFinish.Enabled = True
    End Sub
    Private Sub CreateEntities(ByVal bHitDB As Boolean)
        Dim lRow As Long, iCol As Integer
        Dim sStateCd As String, sName As String, sError As String

        Try
            dgImport.Columns("Status").Visible = True
            For lRow = 0 To dgImport.Rows.Count - 1
                sStateCd = "" : sName = ""
                For iCol = 0 To dgImport.Columns.Count - 1
                    If dgImport.Columns(iCol).HeaderText = "State Code" Then sStateCd = UCase(Trim(dgImport.Rows(lRow).Cells(iCol).Value))
                    If dgImport.Columns(iCol).HeaderText = "Name" Then sName = Trim(dgImport.Rows(lRow).Cells(iCol).Value)
                Next
                If sStateCd = "" Or sName = "" Then
                    dgImport.Rows(lRow).Cells("Status").Value = "Error:  Missing data"
                Else
                    If AddFactoringEntity(sName, sStateCd, bHitDB, sError) Then
                        dgImport.Rows(lRow).Cells("Status").Value = "OK"
                    Else
                        dgImport.Rows(lRow).Cells("Status").Value = "Error:  " & sError
                    End If
                End If
            Next

        Catch ex As Exception
            MsgBox("Error importing:  " & ex.Message)
        End Try


    End Sub

    Private Sub cmdFinish_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdFinish.Click
        CreateEntities(True)
        cmdFinish.Enabled = False
    End Sub

End Class