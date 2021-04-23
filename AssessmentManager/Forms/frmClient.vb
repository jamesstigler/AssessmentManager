Public Class frmClient
    Private bActivated As Boolean
    Private clsClient As New clsClient
    Private m_ClientId As Long
    Private DBUpdate() As typeDBUpdateInfo
    Private bChanged As Boolean
    Private colLeadStatus As New Collection
    Private colSolicitType As New Collection
    Private iMouseClickColIndex As Integer
    Private bContractExists As Boolean
    Private bProposalExists As Boolean

    Public Property ClientId() As Long
        Get
            Return m_ClientId
        End Get
        Set(ByVal value As Long)
            m_ClientId = value
        End Set
    End Property

    Private Sub InitInfo()
        Dim DBPrimaryKeys(0) As typeDBUpdateInfo, l As Long
        Dim sSQL As String, dt As New DataTable, dr As DataRow

        DBPrimaryKeys(0).sTable = "Clients"
        ReDim DBPrimaryKeys(0).PrimaryKeys(0)
        DBPrimaryKeys(0).PrimaryKeys(0).sField = "ClientId"

        InitControls(Me, DBUpdate, DBPrimaryKeys)
        For l = 0 To UBound(DBUpdate)
            DBUpdate(l).PrimaryKeys(0).vValue = m_ClientId
        Next

        colLeadStatus = New Collection
        colLeadStatus.Add("", "")
        cboLeadStatus.Items.Add("")
        sSQL = "SELECT FieldValue FROM FieldDataDefinition" & _
            " WHERE TableName = 'Clients'" & _
            " AND FieldName = 'LeadStatus'" & _
            " ORDER BY FieldValue"
        GetData(sSQL, dt)
        For Each dr In dt.Rows
            cboLeadStatus.Items.Add(dr("FieldValue"))
            colLeadStatus.Add(dr("FieldValue"), dr("FieldValue"))
        Next

        colSolicitType = New Collection
        colSolicitType.Add("", "")
        cboSolicitType.Items.Add("")
        sSQL = "SELECT FieldValue FROM FieldDataDefinition" & _
            " WHERE TableName = 'Clients'" & _
            " AND FieldName = 'SolicitType'" & _
            " ORDER BY FieldValue"
        GetData(sSQL, dt)
        For Each dr In dt.Rows
            cboSolicitType.Items.Add(dr("FieldValue"))
            colsolicittype.Add(dr("FieldValue"), dr("FieldValue"))
        Next

    End Sub


    Private Sub frmClient_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If bActivated Then Exit Sub

        InitInfo()
        OpenClient()



        bActivated = True
    End Sub



    Private Function OpenClient() As Boolean
        Dim sError As String = "", dr As DataRow

        Try
            clsClient.ClientId = m_ClientId

            clsClient.OpenClient(sError)

            RefreshControls(Me, clsClient.ResultSet, "Clients")
            dr = clsClient.ResultSet.Rows(0)
            If IsDBNull(dr("ContractImage")) Then
                bContractExists = False
            Else
                bContractExists = True
            End If
            If IsDBNull(dr("ProposalImage")) Then
                bProposalExists = False
            Else
                bProposalExists = True
            End If

            If clsClient.ProspectFl Then
                grpProspectInfo.Left = 536
                grpProspectInfo.Top = 4
                grpContractInfo.Visible = False
                grpProspectInfo.Visible = True
                Me.Text = "Prospect:  " & clsClient.Name
                cmdViewProposal.Enabled = bProposalExists
            Else
                grpProspectInfo.Visible = False
                grpContractInfo.Visible = True
                Me.Text = "Client:  " & clsClient.Name
                cmdViewContract.Enabled = bContractExists
            End If
            LoadComments()
            LoadExclusions()
            Return True

        Catch ex As Exception
            MsgBox("Error in OpenClient:  " & ex.Message)
            Return False
        End Try
    End Function

    Private Sub txtWebSite_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtWebSite.DoubleClick
        Try
            If Trim(sender.text) = "" Then Exit Sub
            Process.Start("iexplore.exe", sender.text)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub chkBxExcludeNotified_Click(sender As Object, e As System.EventArgs) Handles chkBxExcludeNotified.Click, chkBxExcludeClient.Click
        Try
            If sender.checked Then
                If sender.name = "chkBxExcludeNotified" And chkBxExcludeClient.Checked Then chkBxExcludeClient.Checked = False
                If sender.name = "chkBxExcludeClient" And chkBxExcludeNotified.Checked Then chkBxExcludeNotified.Checked = False
            End If
            Dim sSQL As String = "UPDATE Clients Set ExcludeNotified = " & IIf(chkBxExcludeNotified.Checked, "1", "NULL") & _
                ", ExcludeClient = " & IIf(chkBxExcludeClient.Checked, "1", "NULL") & _
                ", ChangeDate = GETDATE(), ChangeUser = " & QuoStr(AppData.UserId) & " WHERE ClientId = " & m_ClientId
            ExecuteSQL(sSQL)
        Catch ex As Exception
            MsgBox("Error in " & System.Reflection.MethodInfo.GetCurrentMethod.Name & ":  " & ex.Message)
        End Try
    End Sub

    Private Sub txtName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.LostFocus, txtAddress.LostFocus,
            txtCity.LostFocus, txtZip.LostFocus, txtComment.LostFocus, txtFax.LostFocus, txtPhone.LostFocus, cboStateCd.LostFocus,
            TextBox1.LostFocus, TextBox10.LostFocus, TextBox11.LostFocus, TextBox12.LostFocus, TextBox13.LostFocus,
            TextBox14.LostFocus, TextBox15.LostFocus, TextBox16.LostFocus, TextBox17.LostFocus, TextBox18.LostFocus,
            TextBox19.LostFocus, TextBox2.LostFocus, TextBox20.LostFocus, TextBox21.LostFocus, TextBox22.LostFocus,
            TextBox23.LostFocus, TextBox24.LostFocus, TextBox25.LostFocus, TextBox26.LostFocus, TextBox27.LostFocus,
            TextBox28.LostFocus, TextBox29.LostFocus, TextBox3.LostFocus, TextBox30.LostFocus, TextBox31.LostFocus,
            TextBox32.LostFocus, TextBox33.LostFocus, TextBox34.LostFocus, TextBox35.LostFocus, ComboBox1.LostFocus,
            ComboBox2.LostFocus, ComboBox3.LostFocus, ComboBox4.LostFocus, ComboBox5.LostFocus, TextBox4.LostFocus,
            TextBox5.LostFocus, TextBox6.LostFocus, TextBox7.LostFocus, TextBox8.LostFocus, TextBox9.LostFocus,
            chkInactiveFl.LostFocus, cboClientCoordinatorName.LostFocus, cboLeadStatus.LostFocus, chkLeadInfoSentFl.LostFocus,
            txtContractFee.LostFocus, txtContractLocationFee.LostFocus, txtContractTermYears1.LostFocus,
            txtDBA.LostFocus, txtFollowUpDate.LostFocus, txtLeadCompetitorName.LostFocus, txtMailDate.LostFocus,
            txtWebSite.LostFocus, chkProspectFl.LostFocus, txtSolicitSentDate.LostFocus, cboSolicitType.LostFocus,
            txtContractStartDate.LostFocus, txtContractEndDate.LostFocus, txtSICCode.LostFocus, txtContractTermYears2.LostFocus,
            txtContractFeeFlatAmt.LostFocus, txtContractFeeFlatPerLocAmt.LostFocus, txtContractFeeContingencyPct.LostFocus,
            txtContractFeeContingencyCapPct.LostFocus, txtContractFeeContingencyCapAmt.LostFocus, txtContractFeeOther.LostFocus,
            chkContractRenewalFl.LostFocus, chkContractFeeFlatFl.LostFocus, chkContractFeeFlatPerLocFl.LostFocus, chkContractFeeContingencyFl.LostFocus,
            chkContractFeeContingencyCapFl.LostFocus, chkContractFeeOtherFl.LostFocus,
            txtAofAEffectiveDate.LostFocus, txtAofAExpireDate.LostFocus, cboAccountRep.LostFocus,
            chkBxExcludeAbatements.LostFocus, chkBxExcludeFreeport.LostFocus, txtRecordRetentionYears.LostFocus,
            cboBPPConsultant.LostFocus, cboREConsultant.LostFocus, chkInterstateAllocationFl.LostFocus

        If bChanged Then

            If TypeOf sender Is ComboBox Then
                If sender.name = cboLeadStatus.Name Or sender.name = cboSolicitType.Name Then
                    If sender.SelectedIndex >= 0 Then
                        If sender.name = cboLeadStatus.Name Then
                            UpdateDB(sender, DBUpdate, colLeadStatus)
                        Else
                            UpdateDB(sender, DBUpdate, colSolicitType)
                        End If
                    End If
                Else
                    If sender.SelectedIndex >= 0 Then
                        UpdateDB(sender, DBUpdate)
                    End If
                End If
            Else
                UpdateDB(sender, DBUpdate)
            End If
            bChanged = False
        End If
    End Sub

    Private Sub txtAddress_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAddress.GotFocus, txtCity.GotFocus,
            txtZip.GotFocus, txtComment.GotFocus, txtFax.GotFocus, txtName.GotFocus, txtPhone.GotFocus, txtZip.GotFocus,
            TextBox1.GotFocus, TextBox10.GotFocus, TextBox11.GotFocus, TextBox12.GotFocus, TextBox13.GotFocus, TextBox14.GotFocus,
            TextBox15.GotFocus, TextBox16.GotFocus, TextBox17.GotFocus, TextBox18.GotFocus, TextBox19.GotFocus, TextBox2.GotFocus,
            TextBox20.GotFocus, TextBox21.GotFocus, TextBox22.GotFocus, TextBox23.GotFocus, TextBox24.GotFocus, TextBox25.GotFocus,
            TextBox26.GotFocus, TextBox27.GotFocus, TextBox28.GotFocus, TextBox29.GotFocus, TextBox3.GotFocus, TextBox30.GotFocus,
            TextBox31.GotFocus, TextBox32.GotFocus, TextBox33.GotFocus, TextBox34.GotFocus, TextBox35.GotFocus, TextBox4.GotFocus,
            TextBox5.GotFocus, TextBox6.GotFocus, TextBox7.GotFocus, TextBox8.GotFocus, TextBox9.GotFocus,
            txtContractFee.GotFocus, txtContractLocationFee.GotFocus, txtContractTermYears1.GotFocus,
            txtDBA.GotFocus, txtFollowUpDate.GotFocus, txtLeadCompetitorName.GotFocus, txtMailDate.GotFocus,
            txtWebSite.GotFocus, txtSolicitSentDate.GotFocus, cboSolicitType.GotFocus,
            txtContractStartDate.GotFocus, txtContractEndDate.GotFocus, txtSICCode.GotFocus, txtContractTermYears2.GotFocus,
            txtContractFeeFlatAmt.GotFocus, txtContractFeeFlatPerLocAmt.GotFocus, txtContractFeeContingencyPct.GotFocus,
            txtContractFeeContingencyCapPct.GotFocus, txtContractFeeContingencyCapAmt.GotFocus, txtContractFeeOther.GotFocus,
            txtAofAEffectiveDate.GotFocus, txtAofAExpireDate.GotFocus, txtRecordRetentionYears.GotFocus,
            cboBPPConsultant.GotFocus, cboREConsultant.GotFocus, cboClientCoordinatorName.GotFocus
        sender.selectall()
    End Sub


    Private Sub txtName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtName.TextChanged,
            txtAddress.TextChanged, txtCity.TextChanged, txtComment.TextChanged, txtFax.TextChanged, txtPhone.TextChanged,
            txtZip.TextChanged, cboStateCd.TextChanged, TextBox1.TextChanged, TextBox10.TextChanged, TextBox11.TextChanged,
            TextBox12.TextChanged, TextBox13.TextChanged, TextBox14.TextChanged, TextBox15.TextChanged, TextBox16.TextChanged,
            TextBox17.TextChanged, TextBox18.TextChanged, TextBox19.TextChanged, TextBox2.TextChanged, TextBox20.TextChanged,
            TextBox21.TextChanged, TextBox22.TextChanged, TextBox23.TextChanged, TextBox24.TextChanged, TextBox25.TextChanged,
            TextBox26.TextChanged, TextBox27.TextChanged, TextBox28.TextChanged, TextBox29.TextChanged, TextBox3.TextChanged,
            TextBox30.TextChanged, TextBox31.TextChanged, TextBox32.TextChanged, TextBox33.TextChanged, TextBox34.TextChanged,
            TextBox35.TextChanged, ComboBox1.TextChanged, ComboBox2.TextChanged, ComboBox3.TextChanged, ComboBox4.TextChanged,
            ComboBox5.TextChanged, TextBox4.TextChanged, TextBox5.TextChanged, TextBox6.TextChanged, TextBox7.TextChanged,
            TextBox8.TextChanged, TextBox9.TextChanged, chkInactiveFl.CheckedChanged, cboClientCoordinatorName.TextChanged,
            txtContractFee.TextChanged, txtContractLocationFee.TextChanged, txtContractTermYears1.TextChanged,
            txtDBA.TextChanged, txtFollowUpDate.TextChanged, txtLeadCompetitorName.TextChanged, txtMailDate.TextChanged,
            txtWebSite.TextChanged, cboLeadStatus.TextChanged, chkLeadInfoSentFl.CheckedChanged, chkProspectFl.CheckedChanged,
            txtSolicitSentDate.TextChanged, cboSolicitType.TextChanged,
            txtContractStartDate.TextChanged, txtContractEndDate.TextChanged, txtSICCode.TextChanged, txtContractTermYears2.TextChanged,
            txtContractFeeFlatAmt.TextChanged, txtContractFeeFlatPerLocAmt.TextChanged, txtContractFeeContingencyPct.TextChanged,
            txtContractFeeContingencyCapPct.TextChanged, txtContractFeeContingencyCapAmt.TextChanged, txtContractFeeOther.TextChanged,
            chkContractRenewalFl.CheckedChanged, chkContractFeeFlatFl.CheckedChanged, chkContractFeeFlatPerLocFl.CheckedChanged, chkContractFeeContingencyFl.CheckedChanged,
            chkContractFeeContingencyCapFl.CheckedChanged, chkContractFeeOtherFl.CheckedChanged,
            txtAofAEffectiveDate.TextChanged, txtAofAExpireDate.TextChanged, cboAccountRep.TextChanged,
            chkBxExcludeAbatements.CheckedChanged, chkBxExcludeFreeport.CheckedChanged, txtRecordRetentionYears.TextChanged,
            cboBPPConsultant.TextChanged, cboREConsultant.TextChanged, chkInterstateAllocationFl.CheckedChanged
        If bActivated Then
            If sender.name = chkInactiveFl.Name Then
                If sender.checkstate = CheckState.Checked Then
                    If MsgBox("Ok to deactivate client?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        bChanged = True
                    End If
                Else
                    bChanged = True
                End If
            Else
                bChanged = True
            End If
        End If
    End Sub
    Private Function LoadExclusions() As Boolean
        Try
            lvSpecialExclusions.Items.Clear()
            Dim sSQL As String = "SELECT 'P' AS PropType, c.Name as Name, ISNULL(l.Address,'') AS Address," & _
                " ISNULL(a.AcctNum,'') AS AcctNum, a.ClientId, a.LocationId, a.AssessmentId, ISNULL(a.SavingsExclusionCd,0) AS SavingsExclusionCd" & _
                " FROM AssessmentsBPP a" & _
                " INNER JOIN LocationsBPP l ON l.ClientId = a.ClientId AND l.LocationId = a.LocationId" & _
                " AND l.TaxYear = a.TaxYear" & _
                " INNER JOIN Clients c ON c.ClientId = l.ClientId" & _
                " WHERE l.ClientId = " & m_ClientId & _
                " AND l.TaxYear = " & AppData.TaxYear & _
                " AND ISNULL(a.SavingsExclusionCd,0) <> 0"
            sSQL = sSQL & " UNION SELECT 'R' AS PropType, c.Name as Name, ISNULL(l.Address,'') AS Address," & _
                " ISNULL(a.AcctNum,'') AS AcctNum, a.ClientId, a.LOcationId, a.AssessmentId, ISNULL(a.SavingsExclusionCd,0) AS SavingsExclusionCd" & _
                " FROM AssessmentsRE a" & _
                " INNER JOIN LocationsRE l ON l.ClientId = a.ClientId AND l.LocationId = a.LocationId" & _
                " AND l.TaxYear = a.TaxYear" & _
                " INNER JOIN Clients c ON c.ClientId = l.ClientId" & _
                " WHERE l.ClientId = " & m_ClientId & _
                " AND l.TaxYear = " & AppData.TaxYear & _
                " AND ISNULL(a.SavingsExclusionCd,0) <> 0"
            sSQL = sSQL & " ORDER BY 1, 3, 4"
            Dim dt As New DataTable
            Dim lRows As Long = GetData(sSQL, dt)
            For Each dr As DataRow In dt.Rows
                Dim eExclCd As enumSavingsExclusionCd = enumSavingsExclusionCd.enumNone
                Dim sAdd As String = dr("PropType") & "  " & dr("Address") & "  " & dr("AcctNum") & "  "
                Select Case dr("SavingsExclusionCd")
                    Case enumSavingsExclusionCd.enumAbatements
                        sAdd = sAdd & "Abatements"
                    Case enumSavingsExclusionCd.enumEntire
                        sAdd = sAdd & "Entire Account"
                    Case enumSavingsExclusionCd.enumFreeport
                        sAdd = sAdd & "Freeport"
                    Case enumSavingsExclusionCd.enumNotified
                        sAdd = sAdd & "Notified"
                    Case enumSavingsExclusionCd.enumAbatementsFreeport
                        sAdd = sAdd & "Abatements and Freeport"
                    Case enumSavingsExclusionCd.enumNotifiedAbatements
                        sAdd = sAdd & "Notified and Abatements"
                    Case enumSavingsExclusionCd.enumNotifiedAbatementsFreeport
                        sAdd = sAdd & "Notified, Abatements and Freeport"
                    Case enumSavingsExclusionCd.enumNotifiedFreeport
                        sAdd = sAdd & "Notified and Freeport"
                    Case enumSavingsExclusionCd.enumClient
                        sAdd = sAdd & "Client"
                    Case enumSavingsExclusionCd.enumClientAbatements
                        sAdd = sAdd & "Client and Abatements"
                    Case enumSavingsExclusionCd.enumClientAbatementsFreeport
                        sAdd = sAdd & "Client, Abatements and Freeport"
                    Case enumSavingsExclusionCd.enumClientFreeport
                        sAdd = sAdd & "Client and Freeport"
                End Select

                lvSpecialExclusions.Items.Add(sAdd)
            Next
            Return True
        Catch ex As Exception
            MsgBox("Error loading exclusions:  " & ex.Message)
            Return False
        End Try
    End Function

    Private Function LoadComments() As Boolean
        Dim sError As String = "", lRows As Long = 0, sSQL As String = ""
        Dim dtList As New DataTable, bind As New BindingSource

        Try
            sSQL = "SELECT ID, ISNULL(ChangeDate,AddDate) AS ChangeDate, Comment FROM ClientComments" & _
                " WHERE ClientId = " & m_ClientId & " ORDER BY ID DESC"
            lRows = GetData(sSQL, dtList)

            dgComments.Columns.Clear()
            bind.DataSource = dtList
            dgComments.DataSource = bind

            For Each column As DataGridViewColumn In dgComments.Columns
                If IsIndexField(column.Name) Then column.Visible = False
                If column.Name = "ChangeDate" Then
                    column.HeaderText = "Date/Time"
                    column.ReadOnly = True
                    column.Width = 120
                    column.DefaultCellStyle.Format = csDateTime
                End If
                If column.Name = "Comment" Then
                    column.Width = dgComments.Width - 120 - 20
                    column.DefaultCellStyle.WrapMode = DataGridViewTriState.True

                End If
            Next

            Return True
        Catch ex As Exception
            MsgBox("Error in LoadComments:  " & ex.Message)
            Return False
        End Try
    End Function

    Private Sub dg_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgComments.CellEndEdit
        Dim sError As String = ""

        If Not UpdateComment(dgComments.Rows(e.RowIndex).Cells("ID").Value, UnNullToString(dgComments.Rows(e.RowIndex).Cells("Comment").Value), sError) Then
            MsgBox(sError)
        End If
        dgComments.Rows(e.RowIndex).ErrorText = String.Empty

    End Sub
    Private Function UpdateComment(ByVal sID As String, ByVal sComment As String, ByRef sError As String) As Boolean
        Try
            sError = "" : sID = Trim(sID) : sComment = Trim(sComment)
            Dim sSQL As String = ""
            If sID = "" Then
                sSQL = "INSERT ClientComments (ClientId, Comment, AddUser)" & _
                    " SELECT " & m_ClientId & "," & _
                    QuoStr(sComment) & "," & QuoStr(AppData.UserId)
            Else
                sSQL = "UPDATE ClientComments SET Comment = " & QuoStr(sComment) & "," & _
                    " ChangeType = 2, ChangeUser = " & QuoStr(AppData.UserId) & ", ChangeDate = GETDATE()" & _
                    " WHERE ID = " & sID
            End If
            If ExecuteSQL(sSQL) <> 1 Then
                sError = "Error saving comment"
                Return False
            End If

            Return True
        Catch ex As Exception
            sError = "Error saving comment:  " & ex.Message
            Return False
        End Try
    End Function

    Private Sub dg_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgComments.CellMouseDown
        Select Case e.Button
            Case MouseButtons.Left
            Case MouseButtons.Right
                iMouseClickColIndex = e.ColumnIndex
            Case MouseButtons.Middle
            Case MouseButtons.XButton1
            Case MouseButtons.XButton2
            Case MouseButtons.None
        End Select

    End Sub


    Private Sub mnuContextDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuContextDelete.Click
        Try
            If iMouseClickColIndex >= 0 Then
                If dgComments.SelectedRows.Count > 0 Then
                    If MsgBox("Are you sure you want to delete?", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then Exit Sub
                    Dim sSQL As String = ""
                    Dim row As DataGridViewRow
                    For Each row In dgComments.SelectedRows
                        sSQL = "DELETE ClientComments WHERE ID = " & row.Cells("ID").Value
                        If sSQL <> "" Then ExecuteSQL(sSQL)
                        LoadComments()
                    Next
                End If
            End If
        Catch ex As Exception
            MsgBox("Error deleting:  " & ex.Message)
        End Try

    End Sub


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub cmdNewComment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNewComment.Click
        Dim sComment As String = Trim(InputBox("Enter comment"))
        If sComment = "" Then Exit Sub
        Dim sError As String = ""
        If UpdateComment("", sComment, sError) Then
            LoadComments()
        Else
            MsgBox(sError)
        End If
    End Sub

    Private Sub cmdEnvelope_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnvelope.Click
        Dim lList As New List(Of Long)
        RunReport(enumReport.enumClientEnvelope, m_ClientId, 0, 0, lList, AppData.TaxYear, enumTable.enumLocationBPP, 0, 0, False, m_ClientId, "", 0, False, tabContacts.SelectedIndex, enumBarCodeTypes.Audit, False, New DataTable)
    End Sub

    Private Sub cmdViewContract_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewContract.Click
        Dim sError As String = ""
        If Not OpenClientContract(m_ClientId, "Contract for " & Me.Text, sError) Then MsgBox(sError)
    End Sub
    Private Sub cmdViewProposal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewProposal.Click
        Dim sError As String = ""
        If Not OpenClientProposal(m_ClientId, "Proposal for " & Me.Text, sError) Then MsgBox(sError)
    End Sub


    Private Sub cmdImportContract_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdImportContract.Click
        Dim sError As String = ""
        If ImportClientContract(m_ClientId, sError) Then
            MsgBox("Contract imported")
        Else
            If Trim(sError) <> "" Then MsgBox(sError)
        End If
    End Sub
    Private Sub cmdImportProposal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdImportProposal.Click
        Dim sError As String = ""
        If ImportClientProposal(m_ClientId, sError) Then
            MsgBox("Proposal imported")
        Else
            If Trim(sError) <> "" Then MsgBox(sError)
        End If
    End Sub

    Private Sub cmdExpandComments_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdExpandComments.Click
        Try
            If Me.WindowState = FormWindowState.Minimized Then Exit Sub
            Dim mesize As Size = Me.Size
            If cmdExpandComments.Text = "Expand" Then
                cmdExpandComments.Text = "Shrink"
                grpComments.Left = 5
                grpComments.Top = 5
                grpComments.Width = mesize.Width - 20
                grpComments.Height = mesize.Height - 40
                cmdExpandComments.Left = 895
                dgComments.Width = grpComments.Width - 5
                dgComments.Height = grpComments.Height - 40
            Else
                cmdExpandComments.Text = "Expand"
                grpComments.Left = 15
                grpComments.Top = 430
                grpComments.Width = 949
                grpComments.Height = 141
                cmdExpandComments.Left = 882
                dgComments.Width = grpComments.Width - 5
                dgComments.Height = grpComments.Height - 40
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub cmdAddExclusion_Click(sender As System.Object, e As System.EventArgs) Handles cmdAddExclusion.Click
        Dim frmExcl = New frmExclusionDialog
        frmExcl.ClientId = m_ClientId
        frmExcl.TaxYear = AppData.TaxYear
        frmExcl.ShowDialog()
        LoadExclusions()

    End Sub

    Private Sub cmdBusinessUnits_Click(sender As Object, e As EventArgs) Handles cmdBusinessUnits.Click
        Dim frmbus = New frmBusinessUnits
        frmbus.ClientId = m_ClientId
        frmbus.ShowDialog()
    End Sub


End Class