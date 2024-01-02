Imports System.Windows.Forms

Public Class MDIParent1
    Private _Printing As Boolean = False

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs) Handles OpenToolStripMenuItem.Click
        'Dim OpenFileDialog As New OpenFileDialog
        'OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        'OpenFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        'If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
        '    Dim FileName As String = OpenFileDialog.FileName
        '    ' TODO: Add code here to open the file.
        'End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: Add code here to save the current contents of the form to a file.
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuFileExit.Click

        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CutToolStripMenuItem.Click
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CopyToolStripMenuItem.Click
        ''Use My.Computer.Clipboard to insert the selected text or images into the clipboard
        My.Computer.Clipboard.GetText()

    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PasteToolStripMenuItem.Click
        'Use My.Computer.Clipboard.GetText() or My.Computer.Clipboard.GetData to retrieve information from the clipboard.
    End Sub

    Private Sub ToolBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolBarToolStripMenuItem.Click
        Me.ToolStrip.Visible = Me.ToolBarToolStripMenuItem.Checked
    End Sub

    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles StatusBarToolStripMenuItem.Click
        Me.StatusStrip.Visible = Me.StatusBarToolStripMenuItem.Checked
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ArrangeIconsToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseAllToolStripMenuItem.Click
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer

    Private Sub buttonClients_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonClients.Click
        OpenList(enumListType.enumClient)
    End Sub





    Private Sub buttonBPPLocations_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonBPPLocations.Click
        OpenList(enumListType.enumLocationBPP)
    End Sub

    Private Sub buttonRELocations_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonRELocations.Click
        OpenList(enumListType.enumLocationRE)
    End Sub




    Private Sub mnuFileImportClients_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileImportClients.Click
        Try
            For Each frm As Form In Me.MdiChildren
                If frm.Name = "frmImportClients" Then
                    frm.Focus()
                    Exit Sub
                End If
            Next
            Dim frmChild As New frmImportClients
            frmChild.MdiParent = Me
            frmChild.Show()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub mnuFileNewClient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewClient.Click
        AddClient()
    End Sub

    Private Sub mnuFileImportAssets_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileImportAssets.Click, buttonImportAssets.Click
        Try
            Dim frmS As frmSelect
            For Each frm As Form In Me.MdiChildren
                If frm.Name = "frmSelect" Then
                    frmS = frm
                    If frmS.TypeOfImport = enumTable.enumAsset And frmS.ImportAssetsForClient = False Then
                        frm.Focus()
                        Exit Sub
                    End If
                End If
            Next
            frmS = New frmSelect
            frmS.TypeOfImport = enumTable.enumAsset
            frmS.ImportAssetsForClient = False
            frmS.Text = "Import Assets"
            frmS.MdiParent = Me
            frmS.Show()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub mnuFileOpenClients_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileOpenClients.Click
        OpenList(enumListType.enumClient)
    End Sub

    Private Sub mnuFileOpenAssessors_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileOpenAssessors.Click
        OpenList(enumListType.enumAssessor)
    End Sub

    Private Sub mnuFileOpenBPPLocations_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileOpenBPPLocations.Click
        OpenList(enumListType.enumLocationBPP)
    End Sub

    Private Sub mnuFileOpenClientGLCodes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileOpenClientGLCodes.Click
        OpenList(enumListType.enumClientFactors)
    End Sub

    Private Sub mnuFileOpenCollectors_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileOpenCollectors.Click
        OpenList(enumListType.enumCollector)
    End Sub

    Private Sub mnuFileOpenFactoringEntities_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileOpenFactoringEntities.Click
        OpenList(enumListType.enumFactoringEntities)
    End Sub

    Private Sub mnuFileOpenREAssessments_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileOpenREAssessments.Click
        OpenList(enumListType.enumAssessmentRE)
    End Sub

    Private Sub mnuFileOpenRELocations_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileOpenRELocations.Click
        OpenList(enumListType.enumLocationRE)
    End Sub

    Private Sub mnuFileOpenRenditions_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileOpenRenditions.Click
        OpenList(enumListType.enumRenditions)
    End Sub

    Private Sub mnuFileOpenStateFactorCodes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileOpenStateFactorCodes.Click
        OpenList(enumListType.enumStateFactorCodes)
    End Sub

    Private Sub mnuFileImportRELocations_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileImportRELocations.Click
        Try
            Dim frmS As frmSelect
            For Each frm As Form In Me.MdiChildren
                If frm.Name = "frmSelect" Then
                    frmS = frm
                    If frmS.TypeOfImport = enumTable.enumLocationRE Then
                        frm.Focus()
                        Exit Sub
                    End If
                End If
            Next
            frmS = New frmSelect
            frmS.TypeOfImport = enumTable.enumLocationRE
            frmS.Text = "Import RE Locations"
            frmS.MdiParent = Me
            frmS.Show()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub mnuFileImportBPPLocations_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileImportBPPLocations.Click
        Try
            Dim frmS As frmSelect
            For Each frm As Form In Me.MdiChildren
                If frm.Name = "frmSelect" Then
                    frmS = frm
                    If frmS.TypeOfImport = enumTable.enumLocationBPP Then
                        frm.Focus()
                        Exit Sub
                    End If
                End If
            Next
            frmS = New frmSelect
            frmS.TypeOfImport = enumTable.enumLocationBPP
            frmS.Text = "Import BPP Locations"
            frmS.MdiParent = Me
            frmS.Show()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub mnuFileNewBPPLocation_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileNewBPPLocation.Click
        Try
            Dim frmS As frmSelect
            For Each frm As Form In Me.MdiChildren
                If frm.Name = "frmSelect" Then
                    frmS = frm
                    If frmS.TypeOfAdd = enumTable.enumLocationBPP Then
                        frm.Focus()
                        Exit Sub
                    End If
                End If
            Next
            frmS = New frmSelect
            frmS.TypeOfAdd = enumTable.enumLocationBPP
            frmS.Text = "New BPP Location"
            frmS.MdiParent = Me
            frmS.Show()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub mnuFileNewRELocation_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileNewRELocation.Click
        Try
            Dim frmS As frmSelect
            For Each frm As Form In Me.MdiChildren
                If frm.Name = "frmSelect" Then
                    frmS = frm
                    If frmS.TypeOfAdd = enumTable.enumLocationRE Then
                        frm.Focus()
                        Exit Sub
                    End If
                End If
            Next
            frmS = New frmSelect
            frmS.TypeOfAdd = enumTable.enumLocationRE
            frmS.Text = "New RE Location"
            frmS.MdiParent = Me
            frmS.Show()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub mnuFileNewBPPAssessment_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileNewBPPAssessment.Click
        Try
            Dim frmS As frmSelect
            For Each frm As Form In Me.MdiChildren
                If frm.Name = "frmSelect" Then
                    frmS = frm
                    If frmS.TypeOfAdd = enumTable.enumAssessmentBPP Then
                        frm.Focus()
                        Exit Sub
                    End If
                End If
            Next
            frmS = New frmSelect
            frmS.TypeOfAdd = enumTable.enumAssessmentBPP
            frmS.Text = "New BPP Assessment"
            frmS.MdiParent = Me
            frmS.Show()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub mnuFileNewREAssessment_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileNewREAssessment.Click
        Try
            Dim frmS As frmSelect
            For Each frm As Form In Me.MdiChildren
                If frm.Name = "frmSelect" Then
                    frmS = frm
                    If frmS.TypeOfAdd = enumTable.enumAssessmentRE Then
                        frm.Focus()
                        Exit Sub
                    End If
                End If
            Next
            frmS = New frmSelect
            frmS.TypeOfAdd = enumTable.enumAssessmentRE
            frmS.Text = "New RE Assessment"
            frmS.MdiParent = Me
            frmS.Show()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub mnuFileOpenBPPAssessments_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileOpenBPPAssessments.Click
        OpenList(enumListType.enumAssessmentBPP)
    End Sub

    Private Sub mnuFileOpenFactorCodeXRef_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileOpenFactorCodeXRef.Click
        OpenList(enumListType.enumFactorCodeXRef)
    End Sub

    Private Sub MDIParent1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        CloseApp()
    End Sub

    Private Sub MDIParent1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not StartApp() Then End
        Me.Text = AppData.AppName & " version:  " & AppData.Version & IIf(AppData.PrintServer, " (Print Server)", "") & ", datebase:  " & AppData.Server & "          " & AppData.TaxYear

        mnuOptionsTaxYear2008.Checked = False
        mnuOptionsTaxYear2009.Checked = False
        mnuOptionsTaxYear2010.Checked = False
        mnuOptionsTaxYear2011.Checked = False
        mnuOptionsTaxYear2012.Checked = False
        mnuOptionsTaxYear2013.Checked = False
        mnuOptionsTaxYear2014.Checked = False
        mnuOptionsTaxYear2015.Checked = False
        mnuOptionsTaxYear2016.Checked = False
        mnuOptionsTaxYear2017.Checked = False
        mnuOptionsTaxYear2018.Checked = False
        mnuOptionsTaxYear2019.Checked = False
        mnuOptionsTaxYear2020.Checked = False
        mnuOptionsTaxYear2021.Checked = False
        mnuOptionsTaxYear2022.Checked = False
        mnuOptionsTaxYear2023.Checked = False
        mnuOptionsTaxYear2024.Checked = False

        If AppData.TaxYear = 2008 Then
            mnuOptionsTaxYear2008.Checked = True
        ElseIf AppData.TaxYear = 2009 Then
            mnuOptionsTaxYear2009.Checked = True
        ElseIf AppData.TaxYear = 2010 Then
            mnuOptionsTaxYear2010.Checked = True
        ElseIf AppData.TaxYear = 2011 Then
            mnuOptionsTaxYear2011.Checked = True
        ElseIf AppData.TaxYear = 2012 Then
            mnuOptionsTaxYear2012.Checked = True
        ElseIf AppData.TaxYear = 2013 Then
            mnuOptionsTaxYear2013.Checked = True
        ElseIf AppData.TaxYear = 2014 Then
            mnuOptionsTaxYear2014.Checked = True
        ElseIf AppData.TaxYear = 2015 Then
            mnuOptionsTaxYear2015.Checked = True
        ElseIf AppData.TaxYear = 2016 Then
            mnuOptionsTaxYear2016.Checked = True
        ElseIf AppData.TaxYear = 2017 Then
            mnuOptionsTaxYear2017.Checked = True
        ElseIf AppData.TaxYear = 2018 Then
            mnuOptionsTaxYear2018.Checked = True
        ElseIf AppData.TaxYear = 2019 Then
            mnuOptionsTaxYear2019.Checked = True
        ElseIf AppData.TaxYear = 2020 Then
            mnuOptionsTaxYear2020.Checked = True
        ElseIf AppData.TaxYear = 2021 Then
            mnuOptionsTaxYear2021.Checked = True
        ElseIf AppData.TaxYear = 2022 Then
            mnuOptionsTaxYear2022.Checked = True
        ElseIf AppData.TaxYear = 2023 Then
            mnuOptionsTaxYear2023.Checked = True
        ElseIf AppData.TaxYear = 2024 Then
            mnuOptionsTaxYear2024.Checked = True
        End If
        If AppData.IncludeInactive Then mnuOptionsIncludeInactive.Checked = True Else mnuOptionsIncludeInactive.Checked = False
        If AppData.PrintServer = True Then Timer1.Enabled = True
        ShowStatus()
        StatusLabel.Text = "Tax year:  " & AppData.TaxYear
        Me.Icon = My.Resources.AppIcon
    End Sub


    Private Sub mnuFileNewStateFactorCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewStateFactorCode.Click
        Try
            Dim frmS As frmSelect
            For Each frm As Form In Me.MdiChildren
                If frm.Name = "frmSelect" Then
                    frmS = frm
                    If frmS.TypeOfAdd = enumTable.enumStateFactorCode Then
                        frm.Focus()
                        Exit Sub
                    End If
                End If
            Next
            frmS = New frmSelect
            frmS.TypeOfAdd = enumTable.enumStateFactorCode
            frmS.Text = "New State Factor Code"
            frmS.MdiParent = Me
            frmS.Show()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub mnuFileNewClientGLCode_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileNewClientGLCode.Click
        Try
            Dim frmS As frmSelect
            For Each frm As Form In Me.MdiChildren
                If frm.Name = "frmSelect" Then
                    frmS = frm
                    If frmS.TypeOfAdd = enumTable.enumClientGLCode Then
                        frm.Focus()
                        Exit Sub
                    End If
                End If
            Next
            frmS = New frmSelect
            frmS.TypeOfAdd = enumTable.enumClientGLCode
            frmS.MdiParent = Me
            frmS.Text = "New Client G/L Code"
            frmS.Show()
        Catch ex As Exception

        End Try

    End Sub


    Private Sub mnuFileNewFactorAge_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileNewFactorAge.Click
        Try
            Dim frmS As frmSelect
            For Each frm As Form In Me.MdiChildren
                If frm.Name = "frmSelect" Then
                    frmS = frm
                    If frmS.TypeOfAdd = enumTable.enumFactor Then
                        frm.Focus()
                        Exit Sub
                    End If
                End If
            Next
            frmS = New frmSelect
            frmS.TypeOfAdd = enumTable.enumFactor
            frmS.MdiParent = Me
            frmS.Text = "New Factor Age"
            frmS.Show()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub mnuFileNewFactorFactorCode_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileNewFactorFactorCode.Click
        Try
            Dim frmS As frmSelect
            For Each frm As Form In Me.MdiChildren
                If frm.Name = "frmSelect" Then
                    frmS = frm
                    If frmS.TypeOfAdd = enumTable.enumFactorCode Then
                        frm.Focus()
                        Exit Sub
                    End If
                End If
            Next
            frmS = New frmSelect
            frmS.TypeOfAdd = enumTable.enumFactorCode
            frmS.MdiParent = Me
            frmS.Text = "New Factor Code"
            frmS.Show()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub mnuFileNewFactorFactoringEntity_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileNewFactorFactoringEntity.Click
        Try
            Dim sName As String = Trim(InputBox("Enter factoring entity name"))
            If sName = "" Then Exit Sub
            Dim sStateCd As String = Trim(InputBox("Enter state code"))
            If sStateCd = "" Then Exit Sub
            Dim sError As String = ""
            If Not AddFactoringEntity(sName, sStateCd, True, sError) Then MsgBox("Error creating entity:  " & sError)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub mnuFilePrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFilePrint.Click, buttonPrint.Click
        Try
            Dim frm As Form, frml As frmReportSelection, frmActive As Form = Me.ActiveMdiChild
            Dim fBPPAss As frmBPPAssessment = Nothing, colAssessments As Collection
            Dim fREAss As frmREAssessment = Nothing
            Dim structAssess As New structAssessment

            If Not frmActive Is Nothing Then
                If frmActive.Name = "frmBPPAssessment" Then fBPPAss = Me.ActiveMdiChild
                If frmActive.Name = "frmREAssessment" Then fREAss = Me.ActiveMdiChild
            End If

            For Each frm In Me.MdiChildren
                If frm.Name = "frmReportSelection" Then
                    frml = frm
                    frml.Focus()
                    Exit Sub
                End If
            Next
            frml = New frmReportSelection
            If Not fBPPAss Is Nothing Then
                colAssessments = New Collection
                structAssess.ClientId = fBPPAss.ClientId
                structAssess.LocationId = fBPPAss.LocationId
                structAssess.AssessmentId = fBPPAss.AssessmentId
                structAssess.AssessorId = fBPPAss.AssessorId
                structAssess.TaxYear = fBPPAss.TaxYear
                colAssessments.Add(structAssess)
                frml.Assessments = colAssessments
                frml.PropType = enumTable.enumLocationBPP
            End If
            If Not fREAss Is Nothing Then
                colAssessments = New Collection
                structAssess.ClientId = fREAss.ClientId
                structAssess.LocationId = fREAss.LocationId
                structAssess.AssessmentId = fREAss.AssessmentId
                structAssess.AssessorId = fREAss.AssessorId
                structAssess.TaxYear = fREAss.TaxYear
                colAssessments.Add(structAssess)
                frml.Assessments = colAssessments
                frml.PropType = enumTable.enumLocationRE
            End If

            frml.MdiParent = Me
            frml.Show()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub mnuFileImportBPPAssessments_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileImportBPPAssessments.Click
        Try
            Dim frmS As frmSelect
            For Each frm As Form In Me.MdiChildren
                If frm.Name = "frmSelect" Then
                    frmS = frm
                    If frmS.TypeOfImport = enumTable.enumAssessmentBPP Then
                        frm.Focus()
                        Exit Sub
                    End If
                End If
            Next
            frmS = New frmSelect
            frmS.TypeOfImport = enumTable.enumAssessmentBPP
            frmS.Text = "Import BPP Assessments"
            frmS.MdiParent = Me
            frmS.Show()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub mnuFileImportREAssessments_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileImportREAssessments.Click
        Try
            Dim frmS As frmSelect
            For Each frm As Form In Me.MdiChildren
                If frm.Name = "frmSelect" Then
                    frmS = frm
                    If frmS.TypeOfImport = enumTable.enumAssessmentRE Then
                        frm.Focus()
                        Exit Sub
                    End If
                End If
            Next
            frmS = New frmSelect
            frmS.TypeOfImport = enumTable.enumAssessmentRE
            frmS.Text = "Import RE Assessments"
            frmS.MdiParent = Me
            frmS.Show()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub mnuFileImportFactorsEntities_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileImportFactorsEntities.Click
        Try
            Dim frmChild As New frmImportFactoringEntities
            frmChild.ShowDialog(Me)
            frmChild.Dispose()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub mnuFileImportFactorsFactorCodes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileImportFactorsFactorCodes.Click
        Try
            Dim frmS As frmSelect
            For Each frm As Form In Me.MdiChildren
                If frm.Name = "frmSelect" Then
                    frmS = frm
                    If frmS.TypeOfImport = enumTable.enumFactorCode Then
                        frm.Focus()
                        Exit Sub
                    End If
                End If
            Next
            frmS = New frmSelect
            frmS.TypeOfImport = enumTable.enumFactorCode
            frmS.Text = "Import Factor Codes"
            frmS.MdiParent = Me
            frmS.Show()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub mnuFileImportFactorsStateCodes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileImportFactorsStateCodes.Click
        Try
            Dim frmChild As New frmImportStateFactorCodes
            frmChild.ShowDialog(Me)
            frmChild.Dispose()
        Catch ex As Exception

        End Try

    End Sub



    Private Sub mnuToolsRoll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuToolsRoll.Click
        Try
            If MsgBox("Are you sure you want to roll data from " & AppData.TaxYear - 1 & " to " & AppData.TaxYear & "?" &
                    vbCrLf & "Assets existing in " & AppData.TaxYear - 1 & " will be created in " & AppData.TaxYear & ".",
                    MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                If RollData(AppData.TaxYear - 1, AppData.TaxYear, 0, 0, 0) = True Then
                    Me.Cursor = Cursors.Default
                    MsgBox("Roll successful")
                Else
                    Me.Cursor = Cursors.Default
                    MsgBox("Roll failed")
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub mnuOptionsTaxYear2008_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuOptionsTaxYear2008.Click,
            mnuOptionsTaxYear2009.Click, mnuOptionsTaxYear2010.Click, mnuOptionsTaxYear2011.Click, mnuOptionsTaxYear2012.Click,
            mnuOptionsTaxYear2013.Click, mnuOptionsTaxYear2014.Click, mnuOptionsTaxYear2015.Click, mnuOptionsTaxYear2016.Click,
            mnuOptionsTaxYear2017.Click, mnuOptionsTaxYear2018.Click, mnuOptionsTaxYear2019.Click, mnuOptionsTaxYear2020.Click,
            mnuOptionsTaxYear2021.Click, mnuOptionsTaxYear2022.Click, mnuOptionsTaxYear2023.Click, mnuOptionsTaxYear2024.Click

        ''   *********     WHEN ADDING TAX YEAR, SEARCH FOR mnuOptionsTaxYear2016 AND ADD YEAR.  NO VALIDTAXYEARS ARRAY.     ************

        Try
            If MsgBox("All screens will be closed if tax year is changed.", MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then Exit Sub
            mnuOptionsTaxYear2008.Checked = False
            mnuOptionsTaxYear2009.Checked = False
            mnuOptionsTaxYear2010.Checked = False
            mnuOptionsTaxYear2011.Checked = False
            mnuOptionsTaxYear2012.Checked = False
            mnuOptionsTaxYear2013.Checked = False
            mnuOptionsTaxYear2014.Checked = False
            mnuOptionsTaxYear2015.Checked = False
            mnuOptionsTaxYear2016.Checked = False
            mnuOptionsTaxYear2017.Checked = False
            mnuOptionsTaxYear2018.Checked = False
            mnuOptionsTaxYear2019.Checked = False
            mnuOptionsTaxYear2020.Checked = False
            mnuOptionsTaxYear2021.Checked = False
            mnuOptionsTaxYear2022.Checked = False
            mnuOptionsTaxYear2023.Checked = False
            mnuOptionsTaxYear2024.Checked = False

            sender.checked = True
            AppData.TaxYear = Val(Microsoft.VisualBasic.Right(sender.name, 4))
            SaveSetting(AppData.AppName, "Configuration", "TaxYear", AppData.TaxYear)
            CloseMDIChildren()
            ShowStatus()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub mnuOptionsDB_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuOptionsDB.Click
        Try
            Dim sServer As String

            'get instances of sql on network
            'Dim instance As Sql.SqlDataSourceEnumerator
            'instance = Sql.SqlDataSourceEnumerator.Instance
            'Dim dt As DataTable = instance.GetDataSources




            sServer = Trim(GetSetting(AppData.AppName, "Configuration", "Server", ""))
            If sServer = "" Then



                sServer = Trim(InputBox("Please enter name of server.", "Server Name"))
            Else
                sServer = Trim(InputBox("Please enter name of server.  It is currently set to " & sServer, "Server Name"))
            End If
            If sServer <> "" Then
                SaveSetting(AppData.AppName, "Configuration", "Server", sServer)
                ConnectToDB()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub mnuFileNewFactorCodeXRef_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileNewFactorCodeXRef.Click
        Try
            Dim frmS As frmSelect
            For Each frm As Form In Me.MdiChildren
                If frm.Name = "frmSelect" Then
                    frmS = frm
                    If frmS.TypeOfAdd = enumTable.enumFactorCodeXRef Then
                        frm.Focus()
                        Exit Sub
                    End If
                End If
            Next
            frmS = New frmSelect
            frmS.TypeOfAdd = enumTable.enumFactorCodeXRef
            frmS.Text = "New Factor Code Cross Reference"
            frmS.MdiParent = Me
            frmS.Show()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub mnuFileNewAssessor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileNewAssessor.Click
        Try
            Dim sName As String = Trim(InputBox("Enter assessor name"))
            If sName = "" Then Exit Sub
            Dim sStateCd As String = Trim(InputBox("Enter state code"))
            If sStateCd = "" Then Exit Sub
            Dim sError As String = ""
            If Not AddAssessor(sName, sStateCd, sError) Then MsgBox("Error creating assessor:  " & sError)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub mnuFileOpenJurisdictions_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileOpenJurisdictions.Click
        OpenList(enumListType.enumJurisdiction)
    End Sub

    Private Sub mnuFileNewJurisdiction_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileNewJurisdiction.Click
        Try
            Dim sName As String = Trim(InputBox("Enter jurisdiction name"))
            If sName = "" Then Exit Sub
            Dim sStateCd As String = Trim(InputBox("Enter state code"))
            If sStateCd = "" Then Exit Sub
            Dim sError As String = ""
            If Not AddJurisdiction(sName, sStateCd, sError) Then MsgBox("Error creating jurisdiction:  " & sError)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub mnuFileNewCollector_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileNewCollector.Click
        Try
            Dim sName As String = Trim(InputBox("Enter collector name"))
            If sName = "" Then Exit Sub
            Dim sStateCd As String = Trim(InputBox("Enter state code"))
            If sStateCd = "" Then Exit Sub
            Dim sError As String = ""
            If Not AddCollector(sName, sStateCd, sError) Then MsgBox("Error creating collector:  " & sError)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub mnuFileImportStateForms_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileImportStateForms.Click
        Try
            Dim sStateCd As String = Trim(InputBox("Enter state code"))
            If sStateCd = "" Then Exit Sub
            Dim sFormName As String = Trim(UCase(InputBox("Enter form name (i.e. 50-127)")))
            If sFormName = "" Then Exit Sub
            Dim sDescription As String = Trim(InputBox("Description"))
            Dim sError As String = ""
            If ImportStateForm(AppData.TaxYear, sStateCd, sFormName, sDescription, sError) Then
                MsgBox("Form loaded")
            Else
                If sError <> "" Then MsgBox("Error importing form:  " & sError)
            End If
        Catch ex As Exception

        End Try
    End Sub



    Private Sub mnuFileOpenRenditionDueDates_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileOpenRenditionDueDates.Click
        OpenList(enumListType.enumRenditionDueDates)
    End Sub


    Private Sub mnuFileOpenTaskMasterList_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuTasksTaskMasterList.Click
        OpenList(enumListType.enumTaskMasterList)
    End Sub

    Private Sub mnuFileNewTask_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuTasksNewTask.Click
        Try
            Dim sName As String = Trim(InputBox("Enter task name"))
            If sName = "" Then Exit Sub
            Dim sDesc As String = Trim(InputBox("Description"))
            Dim sError As String = ""
            If Not AddTask(sName, sDesc, sError) Then MsgBox("Error creating task:  " & sError)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub mnuTasksAssignTask_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuTasksAssignTask.Click
        Try
            Dim frm As Form, frml As frmTaskAssignment

            For Each frm In Me.MdiChildren
                If frm.Name = "frmTaskAssignment" Then
                    frml = frm
                    frml.Focus()
                    Exit Sub
                End If
            Next
            frml = New frmTaskAssignment
            frml.MdiParent = Me
            frml.Show()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub mnuTasksOpenAssignments_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuTasksOpenAssignments.Click
        OpenList(enumListType.enumTaskAssignments)
    End Sub

    Private Sub mnuFileOpenBPPTaxBills_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileOpenBPPTaxBills.Click
        OpenList(enumListType.enumAssessmentBPPTaxBills)
    End Sub
    Private Sub mnuFileOpenBPPTaxBillTotals_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileOpenBPPTaxBillTotals.Click
        OpenList(enumListType.enumAssessmentBPPTotalTaxBills)
    End Sub

    Private Sub mnuFileOpenRETaxBills_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileOpenRETaxBills.Click
        OpenList(enumListType.enumAssessmentRETaxBills)
    End Sub

    Private Sub mnuFileOpenRETaxBillTotals_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileOpenRETaxBillTotals.Click
        OpenList(enumListType.enumAssessmentRETotalTaxBills)
    End Sub

    Private Sub mnuOptionsIncludeInactive_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuOptionsIncludeInactive.Click
        Try
            If sender.checked = True Then
                sender.checked = False
                AppData.IncludeInactive = False
            Else
                sender.checked = True
                AppData.IncludeInactive = True
            End If
            SaveSetting(AppData.AppName, "Configuration", "IncludeInactive", IIf(AppData.IncludeInactive, "1", "0"))
        Catch ex As Exception

        End Try

    End Sub

    Private Sub mnuFileNewAsset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileNewAsset.Click
        Try
            Dim frmS As frmSelect
            For Each frm As Form In Me.MdiChildren
                If frm.Name = "frmSelect" Then
                    frmS = frm
                    If frmS.TypeOfAdd = enumTable.enumAsset Then
                        frm.Focus()
                        Exit Sub
                    End If
                End If
            Next
            frmS = New frmSelect
            frmS.TypeOfAdd = enumTable.enumAsset
            frmS.Text = "New Asset"
            frmS.MdiParent = Me
            frmS.Show()
        Catch ex As Exception

        End Try

    End Sub


    Private Sub mnuProspectsNewProspect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuProspectsNewProspect.Click
        AddClient(True)
    End Sub

    Private Sub mnuProspectsOpenProspects_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuProspectsOpenProspects.Click
        OpenList(enumListType.enumProspect)
    End Sub

    Private Sub mnuProspectsOpenLocations_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuProspectsOpenLocations.Click
        OpenList(enumListType.enumProspectLocations)
    End Sub

    Private Sub mnuProspectsOpenValues_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuProspectsOpenValues.Click
        OpenList(enumListType.enumProspectValues)
    End Sub

    Private Sub mnuProspectsNewLocation_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuProspectsNewLocation.Click
        Try
            Dim frmS As frmSelect
            For Each frm As Form In Me.MdiChildren
                If frm.Name = "frmSelect" Then
                    frmS = frm
                    If frmS.TypeOfAdd = enumTable.enumProspectLocation Then
                        frm.Focus()
                        Exit Sub
                    End If
                End If
            Next
            frmS = New frmSelect
            frmS.TypeOfAdd = enumTable.enumProspectLocation
            frmS.Text = "New Prospect Location"
            frmS.MdiParent = Me
            frmS.Show()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub mnuProspectsImport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuProspectsImport.Click
        Try
            Dim frmS As frmSelect
            For Each frm As Form In Me.MdiChildren
                If frm.Name = "frmSelect" Then
                    frmS = frm
                    If frmS.TypeOfImport = enumTable.enumProspect Then
                        frm.Focus()
                        Exit Sub
                    End If
                End If
            Next
            frmS = New frmSelect
            frmS.TypeOfImport = enumTable.enumProspect
            frmS.Text = "Import Prospects"
            frmS.MdiParent = Me
            frmS.Show()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub mnuProspectsOpenTotalValues_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuProspectsOpenTotalValues.Click
        OpenList(enumListType.enumProspectTotalValues)
    End Sub


    Private Sub mnuFileImportTaxBill_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileImportTaxBill.Click
        Try
            Dim frmS As frmSelect
            For Each frm As Form In Me.MdiChildren
                If frm.Name = "frmSelect" Then
                    frmS = frm
                    If frmS.TypeOfImport = enumTable.enumTaxBillsBPP Then
                        frm.Focus()
                        Exit Sub
                    End If
                End If
            Next
            frmS = New frmSelect
            frmS.TypeOfImport = enumTable.enumTaxBillsBPP
            frmS.Text = "Import Tax Bill"
            frmS.MdiParent = Me
            frmS.Show()
        Catch ex As Exception

        End Try

    End Sub


    Private Sub buttonBPPAssessments_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonBPPAssessments.Click
        OpenList(enumListType.enumAssessmentBPP)
    End Sub

    Private Sub buttonBPPTaxBills_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonBPPTaxBills.Click
        OpenList(enumListType.enumAssessmentBPPTaxBills)
    End Sub

    Private Sub buttonREAssessments_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonREAssessments.Click
        OpenList(enumListType.enumAssessmentRE)
    End Sub

    Private Sub buttonRenditions_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonRenditions.Click
        OpenList(enumListType.enumRenditions)
    End Sub

    Private Sub buttonRETaxBills_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonRETaxBills.Click
        OpenList(enumListType.enumAssessmentRETaxBills)
    End Sub
    Public Function ShowStatus(ByVal sMsg As String) As Boolean
        Try
            Me.Cursor = Cursors.WaitCursor
            StatusLabel.Text = sMsg
            Me.Refresh()
            Return True
        Catch ex As Exception

        End Try

    End Function

    Public Function ShowStatus() As Boolean
        Try
            StatusLabel.Text = "Tax year:  " & AppData.TaxYear
            If Year(Now) <> AppData.TaxYear Then
                StatusLabel.ForeColor = Color.Red
                StatusLabel.BackColor = Color.Black
            Else
                StatusLabel.ForeColor = Color.Black
                StatusLabel.BackColor = Color.Transparent
            End If
            Me.Cursor = Cursors.Default
            Me.Refresh()
            Return True
        Catch ex As Exception

        End Try

    End Function
    Public Function ShowStatus(ByVal eListType As Integer) As Boolean
        Try
            Dim sType As String = ""
            Select Case eListType
                Case enumListType.enumAssessmentBPP
                    sType = "BPP assessment"
                Case enumListType.enumAssessmentBPPTaxBills
                    sType = "BPP tax Bill"
                Case enumListType.enumAssessmentBPPTotalTaxBills
                    sType = "BPP tax bill total"
                Case enumListType.enumAssessmentRE
                    sType = "RE assessment"
                Case enumListType.enumAssessmentRETaxBills
                    sType = "RE tax bill"
                Case enumListType.enumAssessmentRETotalTaxBills
                    sType = "RE tax bill total"
                Case enumListType.enumAssessor
                    sType = "assessor"
                Case enumListType.enumAssets
                    sType = "asset"
                Case enumListType.enumClient
                    sType = "client"
                Case enumListType.enumClientFactors
                    sType = "client factor code"
                Case enumListType.enumClientGLCodeXRef
                    sType = "client factor code/GL code cross reference"
                Case enumListType.enumCollector
                    sType = "collector"
                Case enumListType.enumFactorCodes
                    sType = "factor codes"
                Case enumListType.enumFactorCodeXRef
                    sType = "factor code cross reference"
                Case enumListType.enumFactoringEntities
                    sType = "factoring entity"
                Case enumListType.enumFactors
                    sType = "factor"
                Case enumListType.enumJurisdiction
                    sType = "jurisdiction"
                Case enumListType.enumLocationBPP
                    sType = "BPP location"
                Case enumListType.enumLocationRE
                    sType = "RE location"
                Case enumListType.enumProspect
                    sType = "prospect"
                Case enumListType.enumProspectLocations
                    sType = "prospect location"
                Case enumListType.enumProspectTotalValues
                    sType = "prospect total value"
                Case enumListType.enumProspectValues
                    sType = "prospect value"
                Case enumListType.enumRenditionDueDates
                    sType = "rendition due date"
                Case enumListType.enumRenditions
                    sType = "renditions"
                Case enumListType.enumStateFactorCodes
                    sType = "state factor code"
                Case enumListType.enumSavings
                    sType = "tax savings"
                Case enumListType.enumQueryResults
                    sType = "custom query"
            End Select
            StatusLabel.Text = "Reading " & sType & " data, please wait..."
            Me.Refresh()
            Return True
        Catch ex As Exception

        End Try

    End Function

    Private Sub mnuFileImportAssetsForClient_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileImportAssetsForClient.Click
        Try
            Dim frmS As frmSelect
            For Each frm As Form In Me.MdiChildren
                If frm.Name = "frmSelect" Then
                    frmS = frm
                    If frmS.TypeOfImport = enumTable.enumAsset And frmS.ImportAssetsForClient = True Then
                        frm.Focus()
                        Exit Sub
                    End If
                End If
            Next
            frmS = New frmSelect
            frmS.TypeOfImport = enumTable.enumAsset
            frmS.ImportAssetsForClient = True
            frmS.Text = "Import Assets"
            frmS.MdiParent = Me
            frmS.Show()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub mnuFileImportClientForms_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileImportClientForms.Click
        Try
            Dim frmS As frmSelect
            For Each frm As Form In Me.MdiChildren
                If frm.Name = "frmSelect" Then
                    frmS = frm
                    If frmS.TypeOfImport = enumTable.enumClientForms Then
                        frm.Focus()
                        Exit Sub
                    End If
                End If
            Next
            frmS = New frmSelect
            frmS.TypeOfImport = enumTable.enumClientForms
            frmS.Text = "Import Client Form"
            frmS.MdiParent = Me
            frmS.Show()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub mnuFileOpenFixedAssetRecon_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileOpenFixedAssetRecon.Click
        OpenList(enumListType.enumFixedAssetReconciliation)
    End Sub

    Private Sub mnuFileOpenQueries_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonQueries.Click, mnuFileOpenQueries.Click
        OpenList(enumListType.enumQueryList)
    End Sub

    Private Sub mnuFileNewQuery_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileNewQuery.Click
        Try
            Dim sName As String = Trim(InputBox("Enter name of query"))
            If sName = "" Then Exit Sub
            Dim iResponse As Integer = Val(InputBox("Enter type of query:" & vbCrLf & vbCrLf _
                & "1.  Client only data" & vbCrLf _
                & "2.  BPP location data" & vbCrLf _
                & "3.  RE location data" & vbCrLf _
                & "4.  BPP assessment data" & vbCrLf _
                & "5.  RE assessment data" & vbCrLf _
                & "6.  All assessment data" & vbCrLf _
                & "7.  BPP tax data" & vbCrLf _
                & "8.  RE tax data" & vbCrLf _
                & "9.  All tax data" & vbCrLf _
                & "10.  Prospect data" & vbCrLf _
                & "11.  Prospect location data" & vbCrLf _
                & "12.  Prospect value data" & vbCrLf & vbCrLf _
                , , 0))
            If iResponse = 0 Then Exit Sub
            Dim enumQueryType As UserQueryType
            enumQueryType = CInt(2 ^ (iResponse - 1))

            Dim sError As String = ""
            If AddQuery(sName, enumQueryType, sError) Then
                MsgBox("Query added")
            Else
                MsgBox("Error creating query:  " & sError)
            End If
        Catch ex As Exception
            MsgBox("Error adding query:  " & ex.Message)
        End Try
    End Sub

    Private Sub mnuFileOpenTaxSavings_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileOpenTaxSavings.Click
        OpenList(enumListType.enumSavings)
    End Sub
    Private Sub mnuRECompsSearch_Click(sender As Object, e As System.EventArgs) Handles mnuRECompsSearch.Click
        Try
            Dim frm As Form, frml As frmREComps

            For Each frm In Me.MdiChildren
                If frm.Name = "frmREComps" Then
                    frml = frm
                    frml.Focus()
                    Exit Sub
                End If
            Next
            frml = New frmREComps
            frml.MdiParent = Me
            frml.Show()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub mnuRECompsImport_Click(sender As Object, e As System.EventArgs) Handles mnuRECompsImport.Click
        Try
            Dim frmS As frmSelect
            For Each frm As Form In Me.MdiChildren
                If frm.Name = "frmSelect" Then
                    frmS = frm
                    If frmS.TypeOfImport = enumTable.enumREComps Then
                        frm.Focus()
                        Exit Sub
                    End If
                End If
            Next
            frmS = New frmSelect
            frmS.TypeOfImport = enumTable.enumREComps
            frmS.Text = "Import RE Comps"
            frmS.MdiParent = Me
            frmS.Show()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub mnuBPPCompsSearch_Click(sender As Object, e As System.EventArgs) Handles mnuBPPCompsSearch.Click
        Try
            Dim frm As Form, frml As frmBPPComps

            For Each frm In Me.MdiChildren
                If frm.Name = "frmBPPComps" Then
                    frml = frm
                    frml.Focus()
                    Exit Sub
                End If
            Next
            frml = New frmBPPComps
            frml.MdiParent = Me
            frml.Show()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub mnuBPPCompsImport_Click(sender As Object, e As System.EventArgs) Handles mnuBPPCompsImport.Click
        Try
            Dim frm As Form, frml As frmImportBPPComps

            For Each frm In Me.MdiChildren
                If frm.Name = "frmImportBPPComps" Then
                    frml = frm
                    frml.Focus()
                    Exit Sub
                End If
            Next
            frml = New frmImportBPPComps
            frml.MdiParent = Me
            frml.Show()
        Catch ex As Exception

        End Try
    End Sub


    Private Sub mnuOptionsAgency_Click(sender As Object, e As System.EventArgs) Handles mnuOptionsAgency.Click
        Try
            Dim frmS As frmFirmInfo
            For Each frm As Form In Me.MdiChildren
                If frm.Name = "frmFirmInfo" Then
                    frmS = frm
                    frm.Focus()
                    Exit Sub
                End If
            Next
            frmS = New frmFirmInfo
            frmS.MdiParent = Me
            frmS.Show()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub mnuBPPCompsInput_Click(sender As Object, e As System.EventArgs) Handles mnuBPPCompsInput.Click
        frmAddBPPComp.AddNew = True
        frmAddBPPComp.ShowDialog()
        frmAddBPPComp = Nothing
    End Sub

    Private Sub mnuOptionsConsultants_Click(sender As Object, e As System.EventArgs) Handles mnuOptionsConsultants.Click
        Try
            Dim frmS As frmUsers
            For Each frm As Form In Me.MdiChildren
                If frm.Name = "frmUsers" Then
                    frmS = frm
                    frm.Focus()
                    Exit Sub
                End If
            Next
            frmS = New frmUsers
            frmS.MdiParent = Me
            frmS.Show()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If _Printing = False Then
            _Printing = True
            RunPrintJobs()
            _Printing = False
        End If
    End Sub

    Private Sub mnuRECompsImportCounty_Click(sender As Object, e As EventArgs) Handles mnuRECompsImportCounty.Click
        Try
            Dim frmS As frmSelect
            For Each frm As Form In Me.MdiChildren
                If frm.Name = "frmSelect" Then
                    frmS = frm
                    If frmS.TypeOfImport = enumTable.enumRECompsCounty Then
                        frm.Focus()
                        Exit Sub
                    End If
                End If
            Next
            frmS = New frmSelect
            frmS.TypeOfImport = enumTable.enumRECompsCounty
            frmS.Text = "Import RE Comps Using County Files"
            frmS.MdiParent = Me
            frmS.Show()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub mnuOptionsAgencies_Click(sender As Object, e As EventArgs) Handles mnuOptionsAgencies.Click
        Try
            Dim frmS As frmAgencies
            For Each frm As Form In Me.MdiChildren
                If frm.Name = "frmAgencies" Then
                    frmS = frm
                    frm.Focus()
                    Exit Sub
                End If
            Next
            frmS = New frmAgencies
            frmS.MdiParent = Me
            frmS.Show()
        Catch ex As Exception

        End Try
    End Sub
End Class



