Public Class frmClient
    Private bActivated As Boolean
    Private clsClient As New clsClient
    Private m_ClientId As Long
    Private DBUpdate() As typeDBUpdateInfo
    Private bChanged As Boolean
    Private colLeadStatus As New Collection
    Private colSolicitType As New Collection
    Private colAgencies As New Collection
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
        sSQL = "SELECT FieldValue FROM FieldDataDefinition" &
            " WHERE TableName = 'Clients'" &
            " AND FieldName = 'LeadStatus'" &
            " ORDER BY FieldValue"
        GetData(sSQL, dt)
        For Each dr In dt.Rows
            cboLeadStatus.Items.Add(dr("FieldValue"))
            colLeadStatus.Add(dr("FieldValue"), dr("FieldValue"))
        Next

        colSolicitType = New Collection
        colSolicitType.Add("", "")
        cboSolicitType.Items.Add("")
        sSQL = "SELECT FieldValue FROM FieldDataDefinition" &
            " WHERE TableName = 'Clients'" &
            " AND FieldName = 'SolicitType'" &
            " ORDER BY FieldValue"
        GetData(sSQL, dt)
        For Each dr In dt.Rows
            cboSolicitType.Items.Add(dr("FieldValue"))
            colsolicittype.Add(dr("FieldValue"), dr("FieldValue"))
        Next

        colAgencies = New Collection
        colAgencies.Add("", "")
        cboAgency.Items.Add("")
        sSQL = "SELECT AgencyId, AgencyName FROM Agencies" &
            " ORDER BY AgencyName"
        GetData(sSQL, dt)
        For Each dr In dt.Rows
            cboAgency.Items.Add(dr("AgencyName"))
            colAgencies.Add(dr("AgencyId").ToString, dr("AgencyName").ToString)
        Next

    End Sub


    Private Sub frmClient_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If bActivated Then Exit Sub
        InitInfo()
        RefreshData()
        bActivated = True
    End Sub



    Private Function RefreshData() As Boolean
        Dim sError As String = "", dr As DataRow

        Try
            clsClient.ClientId = m_ClientId

            clsClient.OpenClient(sError)

            RefreshControls(Me, clsClient.ResultSet, "Clients")
            dr = clsClient.ResultSet.Rows(0)
            cboAgency.Text = dr("AgencyName").ToString

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
            Dim sSQL As String = "UPDATE Clients Set ExcludeNotified = " & IIf(chkBxExcludeNotified.Checked, "1", "NULL") &
                ", ExcludeClient = " & IIf(chkBxExcludeClient.Checked, "1", "NULL") &
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
            txtContractStartDate.LostFocus, txtContractEndDate.LostFocus, txtContractTermYears2.LostFocus,
            txtContractFeeFlatAmt.LostFocus, txtContractFeeFlatPerLocAmt.LostFocus, txtContractFeeContingencyPct.LostFocus,
            txtContractFeeContingencyCapPct.LostFocus, txtContractFeeContingencyCapAmt.LostFocus, txtContractFeeOther.LostFocus,
            chkContractRenewalFl.LostFocus, chkContractFeeFlatFl.LostFocus, chkContractFeeFlatPerLocFl.LostFocus, chkContractFeeContingencyFl.LostFocus,
            chkContractFeeContingencyCapFl.LostFocus, chkContractFeeOtherFl.LostFocus,
            txtAofAEffectiveDate.LostFocus, txtAofAExpireDate.LostFocus, cboAccountRep.LostFocus,
            chkBxExcludeAbatements.LostFocus, chkBxExcludeFreeport.LostFocus, txtRecordRetentionYears.LostFocus,
            cboBPPConsultant.LostFocus, cboREConsultant.LostFocus, chkInterstateAllocationFl.LostFocus, cboSICCode.LostFocus, cboAgency.LostFocus,
            TextBox42.LostFocus, TextBox37.LostFocus, TextBox36.LostFocus, ComboBox6.LostFocus, TextBox41.LostFocus, TextBox40.LostFocus,
            TextBox39.LostFocus, TextBox38.LostFocus, TextBox49.LostFocus, TextBox46.LostFocus, TextBox45.LostFocus, TextBox44.LostFocus,
            TextBox43.LostFocus, ComboBox7.LostFocus, TextBox56.LostFocus, TextBox55.LostFocus, TextBox54.LostFocus, TextBox53.LostFocus,
            TextBox52.LostFocus, TextBox51.LostFocus, TextBox50.LostFocus, TextBox48.LostFocus, TextBox47.LostFocus, ComboBox8.LostFocus,
            TextBox84.LostFocus, TextBox83.LostFocus, TextBox82.LostFocus, TextBox81.LostFocus, TextBox80.LostFocus, TextBox79.LostFocus,
            TextBox78.LostFocus, TextBox77.LostFocus, TextBox76.LostFocus, TextBox75.LostFocus, TextBox74.LostFocus, TextBox73.LostFocus,
            TextBox72.LostFocus, TextBox71.LostFocus, TextBox70.LostFocus, TextBox69.LostFocus, TextBox68.LostFocus, TextBox67.LostFocus,
            TextBox66.LostFocus, TextBox65.LostFocus, TextBox64.LostFocus, TextBox63.LostFocus, TextBox62.LostFocus, TextBox61.LostFocus,
            TextBox60.LostFocus, TextBox59.LostFocus, TextBox58.LostFocus, TextBox57.LostFocus, ComboBox9.LostFocus, ComboBox12.LostFocus,
            ComboBox11.LostFocus, ComboBox10.LostFocus

        If bChanged Then

            If TypeOf sender Is ComboBox Then
                If sender.name = cboLeadStatus.Name Or sender.name = cboSolicitType.Name Or sender.name = cboAgency.Name Then
                    If sender.SelectedIndex >= 0 Then
                        If sender.name = cboLeadStatus.Name Then
                            UpdateDB(sender, DBUpdate, colLeadStatus)
                        ElseIf sender.name = cboSolicitType.Name Then
                            UpdateDB(sender, DBUpdate, colSolicitType)
                        ElseIf sender.name = cboAgency.Name Then
                            UpdateDB(sender, DBUpdate, colAgencies)
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
            txtContractStartDate.GotFocus, txtContractEndDate.GotFocus, txtContractTermYears2.GotFocus,
            txtContractFeeFlatAmt.GotFocus, txtContractFeeFlatPerLocAmt.GotFocus, txtContractFeeContingencyPct.GotFocus,
            txtContractFeeContingencyCapPct.GotFocus, txtContractFeeContingencyCapAmt.GotFocus, txtContractFeeOther.GotFocus,
            txtAofAEffectiveDate.GotFocus, txtAofAExpireDate.GotFocus, txtRecordRetentionYears.GotFocus,
            cboBPPConsultant.GotFocus, cboREConsultant.GotFocus, cboClientCoordinatorName.GotFocus, cboSICCode.GotFocus, cboAgency.GotFocus,
            TextBox42.GotFocus, TextBox37.GotFocus, TextBox36.GotFocus, ComboBox6.GotFocus, TextBox41.GotFocus, TextBox40.GotFocus,
            TextBox39.GotFocus, TextBox38.GotFocus, TextBox49.GotFocus, TextBox46.GotFocus, TextBox45.GotFocus, TextBox44.GotFocus,
            TextBox43.GotFocus, ComboBox7.GotFocus, TextBox56.GotFocus, TextBox55.GotFocus, TextBox54.GotFocus, TextBox53.GotFocus,
            TextBox52.GotFocus, TextBox51.GotFocus, TextBox50.GotFocus, TextBox48.GotFocus, TextBox47.GotFocus, ComboBox8.GotFocus,
            TextBox84.GotFocus, TextBox83.GotFocus, TextBox82.GotFocus, TextBox81.GotFocus, TextBox80.GotFocus, TextBox79.GotFocus,
            TextBox78.GotFocus, TextBox77.GotFocus, TextBox76.GotFocus, TextBox75.GotFocus, TextBox74.GotFocus, TextBox73.GotFocus,
            TextBox72.GotFocus, TextBox71.GotFocus, TextBox70.GotFocus, TextBox69.GotFocus, TextBox68.GotFocus, TextBox67.GotFocus,
            TextBox66.GotFocus, TextBox65.GotFocus, TextBox64.GotFocus, TextBox63.GotFocus, TextBox62.GotFocus, TextBox61.GotFocus,
            TextBox60.GotFocus, TextBox59.GotFocus, TextBox58.GotFocus, TextBox57.GotFocus, ComboBox9.GotFocus, ComboBox12.GotFocus,
            ComboBox11.GotFocus, ComboBox10.GotFocus

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
            txtContractStartDate.TextChanged, txtContractEndDate.TextChanged, txtContractTermYears2.TextChanged,
            txtContractFeeFlatAmt.TextChanged, txtContractFeeFlatPerLocAmt.TextChanged, txtContractFeeContingencyPct.TextChanged,
            txtContractFeeContingencyCapPct.TextChanged, txtContractFeeContingencyCapAmt.TextChanged, txtContractFeeOther.TextChanged,
            chkContractRenewalFl.CheckedChanged, chkContractFeeFlatFl.CheckedChanged, chkContractFeeFlatPerLocFl.CheckedChanged, chkContractFeeContingencyFl.CheckedChanged,
            chkContractFeeContingencyCapFl.CheckedChanged, chkContractFeeOtherFl.CheckedChanged,
            txtAofAEffectiveDate.TextChanged, txtAofAExpireDate.TextChanged, cboAccountRep.TextChanged,
            chkBxExcludeAbatements.CheckedChanged, chkBxExcludeFreeport.CheckedChanged, txtRecordRetentionYears.TextChanged,
            cboBPPConsultant.TextChanged, cboREConsultant.TextChanged, chkInterstateAllocationFl.CheckedChanged, cboSICCode.TextChanged, cboAgency.TextChanged,
            TextBox42.TextChanged, TextBox37.TextChanged, TextBox36.TextChanged, ComboBox6.TextChanged, TextBox41.TextChanged, TextBox40.TextChanged,
            TextBox39.TextChanged, TextBox38.TextChanged, TextBox49.TextChanged, TextBox46.TextChanged, TextBox45.TextChanged, TextBox44.TextChanged,
            TextBox43.TextChanged, ComboBox7.TextChanged, TextBox56.TextChanged, TextBox55.TextChanged, TextBox54.TextChanged, TextBox53.TextChanged,
            TextBox52.TextChanged, TextBox51.TextChanged, TextBox50.TextChanged, TextBox48.TextChanged, TextBox47.TextChanged, ComboBox8.TextChanged,
            TextBox84.TextChanged, TextBox83.TextChanged, TextBox82.TextChanged, TextBox81.TextChanged, TextBox80.TextChanged, TextBox79.TextChanged,
            TextBox78.TextChanged, TextBox77.TextChanged, TextBox76.TextChanged, TextBox75.TextChanged, TextBox74.TextChanged, TextBox73.TextChanged,
            TextBox72.TextChanged, TextBox71.TextChanged, TextBox70.TextChanged, TextBox69.TextChanged, TextBox68.TextChanged, TextBox67.TextChanged,
            TextBox66.TextChanged, TextBox65.TextChanged, TextBox64.TextChanged, TextBox63.TextChanged, TextBox62.TextChanged, TextBox61.TextChanged,
            TextBox60.TextChanged, TextBox59.TextChanged, TextBox58.TextChanged, TextBox57.TextChanged, ComboBox9.TextChanged, ComboBox12.TextChanged,
            ComboBox11.TextChanged, ComboBox10.TextChanged
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
            Dim sSQL As String = "SELECT 'P' AS PropType, c.Name as Name, ISNULL(l.Address,'') AS Address," &
                " ISNULL(a.AcctNum,'') AS AcctNum, a.ClientId, a.LocationId, a.AssessmentId, ISNULL(a.SavingsExclusionCd,0) AS SavingsExclusionCd" &
                " FROM AssessmentsBPP a" &
                " INNER JOIN LocationsBPP l ON l.ClientId = a.ClientId AND l.LocationId = a.LocationId" &
                " AND l.TaxYear = a.TaxYear" &
                " INNER JOIN Clients c ON c.ClientId = l.ClientId" &
                " WHERE l.ClientId = " & m_ClientId &
                " AND l.TaxYear = " & AppData.TaxYear &
                " AND ISNULL(a.SavingsExclusionCd,0) <> 0"
            sSQL = sSQL & " UNION SELECT 'R' AS PropType, c.Name as Name, ISNULL(l.Address,'') AS Address," &
                " ISNULL(a.AcctNum,'') AS AcctNum, a.ClientId, a.LOcationId, a.AssessmentId, ISNULL(a.SavingsExclusionCd,0) AS SavingsExclusionCd" &
                " FROM AssessmentsRE a" &
                " INNER JOIN LocationsRE l ON l.ClientId = a.ClientId AND l.LocationId = a.LocationId" &
                " AND l.TaxYear = a.TaxYear" &
                " INNER JOIN Clients c ON c.ClientId = l.ClientId" &
                " WHERE l.ClientId = " & m_ClientId &
                " AND l.TaxYear = " & AppData.TaxYear &
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
            sSQL = "SELECT ID, ISNULL(ChangeDate,AddDate) AS ChangeDate, Comment FROM ClientComments" &
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
                sSQL = "INSERT ClientComments (ClientId, Comment, AddUser)" &
                    " SELECT " & m_ClientId & "," &
                    QuoStr(sComment) & "," & QuoStr(AppData.UserId)
            Else
                sSQL = "UPDATE ClientComments SET Comment = " & QuoStr(sComment) & "," &
                    " ChangeType = 2, ChangeUser = " & QuoStr(AppData.UserId) & ", ChangeDate = GETDATE()" &
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
    Private Sub DuplicateTaxContactInfo()
        Try
            Dim sql As New StringBuilder
            sql.Append("UPDATE Clients SET ChangeDate = GETDATE(), ChangeType = 2, ChangeUser = ").Append(QuoStr(AppData.UserId)).Append(",")
            sql.Append("ContactAofAAuthorizationAddress = ContactTaxAddress,")
            sql.Append("ContactAofAAuthorizationCity = ContactTaxCity,")
            sql.Append("ContactAofAAuthorizationEMail = ContactTaxEMail,")
            sql.Append("ContactAofAAuthorizationFax = ContactTaxFax,")
            sql.Append("ContactAofAAuthorizationName = ContactTaxName,")
            sql.Append("ContactAofAAuthorizationPhone = ContactTaxPhone,")
            sql.Append("ContactAofAAuthorizationStateCd = ContactTaxStateCd,")
            sql.Append("ContactAofAAuthorizationZip = ContactTaxZip,")
            sql.Append("ContactAppealApprovalAddress = ContactTaxAddress,")
            sql.Append("ContactAppealApprovalCity = ContactTaxCity,")
            sql.Append("ContactAppealApprovalEMail = ContactTaxEMail,")
            sql.Append("ContactAppealApprovalFax = ContactTaxFax,")
            sql.Append("ContactAppealApprovalName = ContactTaxName,")
            sql.Append("ContactAppealApprovalPhone = ContactTaxPhone,")
            sql.Append("ContactAppealApprovalStateCd = ContactTaxStateCd,")
            sql.Append("ContactAppealApprovalZip = ContactTaxZip,")
            sql.Append("ContactBPPInfoAddress = ContactTaxAddress,")
            sql.Append("ContactBPPInfoCity = ContactTaxCity,")
            sql.Append("ContactBPPInfoEMail = ContactTaxEMail,")
            sql.Append("ContactBPPInfoFax = ContactTaxFax,")
            sql.Append("ContactBPPInfoName = ContactTaxName,")
            sql.Append("ContactBPPInfoPhone = ContactTaxPhone,")
            sql.Append("ContactBPPInfoStateCd = ContactTaxStateCd,")
            sql.Append("ContactBPPInfoZip = ContactTaxZip,")
            sql.Append("ContactContractAddress = ContactTaxAddress,")
            sql.Append("ContactContractCity = ContactTaxCity,")
            sql.Append("ContactContractEMail = ContactTaxEMail,")
            sql.Append("ContactContractFax = ContactTaxFax,")
            sql.Append("ContactContractName = ContactTaxName,")
            sql.Append("ContactContractPhone = ContactTaxPhone,")
            sql.Append("ContactContractStateCd = ContactTaxStateCd,")
            sql.Append("ContactContractZip = ContactTaxZip,")
            sql.Append("ContactInvoiceAddress = ContactTaxAddress,")
            sql.Append("ContactInvoiceCity = ContactTaxCity,")
            sql.Append("ContactInvoiceEMail = ContactTaxEMail,")
            sql.Append("ContactInvoiceFax = ContactTaxFax,")
            sql.Append("ContactInvoiceName = ContactTaxName,")
            sql.Append("ContactInvoicePhone = ContactTaxPhone,")
            sql.Append("ContactInvoiceStateCd = ContactTaxStateCd,")
            sql.Append("ContactInvoiceZip = ContactTaxZip,")
            sql.Append("ContactMiscAddress = ContactTaxAddress,")
            sql.Append("ContactMiscCity = ContactTaxCity,")
            sql.Append("ContactMiscEMail = ContactTaxEMail,")
            sql.Append("ContactMiscFax = ContactTaxFax,")
            sql.Append("ContactMiscName = ContactTaxName,")
            sql.Append("ContactMiscPhone = ContactTaxPhone,")
            sql.Append("ContactMiscStateCd = ContactTaxStateCd,")
            sql.Append("ContactMiscZip = ContactTaxZip,")
            sql.Append("ContactREInfoAddress = ContactTaxAddress,")
            sql.Append("ContactREInfoCity = ContactTaxCity,")
            sql.Append("ContactREInfoEMail = ContactTaxEMail,")
            sql.Append("ContactREInfoFax = ContactTaxFax,")
            sql.Append("ContactREInfoName = ContactTaxName,")
            sql.Append("ContactREInfoPhone = ContactTaxPhone,")
            sql.Append("ContactREInfoStateCd = ContactTaxStateCd,")
            sql.Append("ContactREInfoZip = ContactTaxZip,")
            sql.Append("ContactRenditionSignatureAddress = ContactTaxAddress,")
            sql.Append("ContactRenditionSignatureCity = ContactTaxCity,")
            sql.Append("ContactRenditionSignatureEMail = ContactTaxEMail,")
            sql.Append("ContactRenditionSignatureFax = ContactTaxFax,")
            sql.Append("ContactRenditionSignatureName = ContactTaxName,")
            sql.Append("ContactRenditionSignaturePhone = ContactTaxPhone,")
            sql.Append("ContactRenditionSignatureStateCd = ContactTaxStateCd,")
            sql.Append("ContactRenditionSignatureZip = ContactTaxZip,")
            sql.Append("ContactReportsAddress = ContactTaxAddress,")
            sql.Append("ContactReportsCity = ContactTaxCity,")
            sql.Append("ContactReportsEMail = ContactTaxEMail,")
            sql.Append("ContactReportsFax = ContactTaxFax,")
            sql.Append("ContactReportsName = ContactTaxName,")
            sql.Append("ContactReportsPhone = ContactTaxPhone,")
            sql.Append("ContactReportsStateCd = ContactTaxStateCd,")
            sql.Append("ContactReportsZip = ContactTaxZip,")
            sql.Append("ContactTaxBillPaymentAddress = ContactTaxAddress,")
            sql.Append("ContactTaxBillPaymentCity = ContactTaxCity,")
            sql.Append("ContactTaxBillPaymentEMail = ContactTaxEMail,")
            sql.Append("ContactTaxBillPaymentFax = ContactTaxFax,")
            sql.Append("ContactTaxBillPaymentName = ContactTaxName,")
            sql.Append("ContactTaxBillPaymentPhone = ContactTaxPhone,")
            sql.Append("ContactTaxBillPaymentStateCd = ContactTaxStateCd,")
            sql.Append("ContactTaxBillPaymentZip = ContactTaxZip,")
            sql.Append("ContactTaxBillTransmittalAddress = ContactTaxAddress,")
            sql.Append("ContactTaxBillTransmittalCity = ContactTaxCity,")
            sql.Append("ContactTaxBillTransmittalEMail = ContactTaxEMail,")
            sql.Append("ContactTaxBillTransmittalFax = ContactTaxFax,")
            sql.Append("ContactTaxBillTransmittalName = ContactTaxName,")
            sql.Append("ContactTaxBillTransmittalPhone = ContactTaxPhone,")
            sql.Append("ContactTaxBillTransmittalStateCd = ContactTaxStateCd,")
            sql.Append("ContactTaxBillTransmittalZip = ContactTaxZip")
            sql.Append(" WHERE ClientId=").Append(m_ClientId.ToString)
            ExecuteSQL(sql.ToString)
            RefreshData()

        Catch ex As Exception
            MsgBox("Error duplicating contacts:  " & ex.Message)
        End Try
    End Sub

    Private Sub cmdDupe_Click(sender As Object, e As EventArgs) Handles cmdDupe.Click
        If MsgBox("Do you wish to duplicate all tax contact information?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            DuplicateTaxContactInfo()
        End If
    End Sub
End Class