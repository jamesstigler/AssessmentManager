Imports System.IO

Public Class frmImportClients
    Private bActivated As Boolean
    Private iNumberOfColumns As Integer

    Private Function ImportFile()
        Dim vFileContents As Object, lColumn As Long, lRow As Long, sRowContents() As String


        dgImport.Columns.Clear()

        If Not modMain.ImportFile(vFileContents) Then Exit Function

        ReDim sRowContents(UBound(vFileContents, 1))
        iNumberOfColumns = UBound(vFileContents, 1) + 1

        cboAddress.Items.Clear()
        cboAddress.Items.Add("")
        cboCity.Items.Clear()
        cboCity.Items.Add("")
        cboComment.Items.Clear()
        cboComment.Items.Add("")
        cboFax.Items.Clear()
        cboFax.Items.Add("")
        cboName.Items.Clear()
        cboName.Items.Add("")
        cboPhone.Items.Clear()
        cboPhone.Items.Add("")
        cboStateCd.Items.Clear()
        cboStateCd.Items.Add("")
        cboZip.Items.Clear()
        cboZip.Items.Add("")

        For lRow = 1 To iNumberOfColumns
            cboAddress.Items.Add(lRow)
            cboCity.Items.Add(lRow)
            cboComment.Items.Add(lRow)
            cboFax.Items.Add(lRow)
            cboName.Items.Add(lRow)
            cboPhone.Items.Add(lRow)
            cboStateCd.Items.Add(lRow)
            cboZip.Items.Add(lRow)
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
            If dgImport.Columns(i).HeaderText = "Address" Then dgImport.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboAddress.Text) <> "" Then
            iColumn = Val(cboAddress.Text) - 1
            dgImport.Columns.Item(iColumn).HeaderText = "Address"
        End If

        For i = 0 To dgImport.Columns.Count - 1
            If dgImport.Columns(i).HeaderText = "Name" Then dgImport.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboName.Text) <> "" Then
            iColumn = Val(cboName.Text) - 1
            dgImport.Columns.Item(iColumn).HeaderText = "Name"
        End If

        For i = 0 To dgImport.Columns.Count - 1
            If dgImport.Columns(i).HeaderText = "City" Then dgImport.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboCity.Text) <> "" Then
            iColumn = Val(cboCity.Text) - 1
            dgImport.Columns.Item(iColumn).HeaderText = "City"
        End If

        For i = 0 To dgImport.Columns.Count - 1
            If dgImport.Columns(i).HeaderText = "State" Then dgImport.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboStateCd.Text) <> "" Then
            iColumn = Val(cboStateCd.Text) - 1
            dgImport.Columns.Item(iColumn).HeaderText = "State"
        End If

        For i = 0 To dgImport.Columns.Count - 1
            If dgImport.Columns(i).HeaderText = "Zip" Then dgImport.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboZip.Text) <> "" Then
            iColumn = Val(cboZip.Text) - 1
            dgImport.Columns.Item(iColumn).HeaderText = "Zip"
        End If

        For i = 0 To dgImport.Columns.Count - 1
            If dgImport.Columns(i).HeaderText = "Phone" Then dgImport.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboPhone.Text) <> "" Then
            iColumn = Val(cboPhone.Text) - 1
            dgImport.Columns.Item(iColumn).HeaderText = "Phone"
        End If

        For i = 0 To dgImport.Columns.Count - 1
            If dgImport.Columns(i).HeaderText = "Fax" Then dgImport.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboFax.Text) <> "" Then
            iColumn = Val(cboFax.Text) - 1
            dgImport.Columns.Item(iColumn).HeaderText = "Fax"
        End If

        For i = 0 To dgImport.Columns.Count - 1
            If dgImport.Columns(i).HeaderText = "Comment" Then dgImport.Columns(i).HeaderText = i + 1
        Next
        If Trim(cboComment.Text) <> "" Then
            iColumn = Val(cboComment.Text) - 1
            dgImport.Columns.Item(iColumn).HeaderText = "Comment"
        End If




    End Sub


    Private Sub cboAddress_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAddress.TextChanged, cboCity.TextChanged, cboComment.TextChanged, cboFax.TextChanged, cboName.TextChanged, cboPhone.TextChanged, cboStateCd.TextChanged, cboZip.TextChanged
        If Trim(sender.text) = "" Or (Val(sender.text) >= 1 And Val(sender.text) <= iNumberOfColumns) Then
            RenameColumns()
        End If
    End Sub



    Private Sub cmdNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNext.Click
        CreateClients(False)
        cmdNext.Enabled = False
        cmdFinish.Enabled = True
    End Sub
    Private Sub CreateClients(ByVal bHitDB As Boolean)
        Dim lRow As Long, iCol As Integer, colClients As New Collection, cClient As clsClient
        Dim sName As String, sAddress As String, sCity As String, sStateCd As String, sZip As String, sPhone As String
        Dim sFax As String, sComment As String, sError As String

        Try
            dgImport.Columns("Status").Visible = True
            For lRow = 0 To dgImport.Rows.Count - 1
                sName = "" : sAddress = "" : sCity = "" : sStateCd = "" : sZip = "" : sPhone = "" : sFax = "" : sComment = ""
                For iCol = 0 To dgImport.Columns.Count - 1
                    If dgImport.Columns(iCol).HeaderText = "Name" Then sName = Trim(dgImport.Rows(lRow).Cells(iCol).Value)
                    If dgImport.Columns(iCol).HeaderText = "Address" Then sAddress = Trim(dgImport.Rows(lRow).Cells(iCol).Value)
                    If dgImport.Columns(iCol).HeaderText = "City" Then sCity = Trim(dgImport.Rows(lRow).Cells(iCol).Value)
                    If dgImport.Columns(iCol).HeaderText = "State" Then sStateCd = Trim(dgImport.Rows(lRow).Cells(iCol).Value)
                    If dgImport.Columns(iCol).HeaderText = "Zip" Then sZip = Trim(dgImport.Rows(lRow).Cells(iCol).Value)
                    If dgImport.Columns(iCol).HeaderText = "Phone" Then sPhone = Trim(dgImport.Rows(lRow).Cells(iCol).Value)
                    If dgImport.Columns(iCol).HeaderText = "Fax" Then sFax = Trim(dgImport.Rows(lRow).Cells(iCol).Value)
                    If dgImport.Columns(iCol).HeaderText = "Comment" Then sComment = Trim(dgImport.Rows(lRow).Cells(iCol).Value)
                Next
                If sName = "" Then
                    dgImport.Rows(lRow).Cells("Status").Value = "Error:  name missing"
                Else
                    cClient = New clsClient
                    If cClient.CreateClient(sName, sAddress, sCity, sStateCd, sZip, sPhone, sFax, sComment, bHitDB, False, sError) = True Then
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
        CreateClients(True)
        cmdFinish.Enabled = False
    End Sub

End Class