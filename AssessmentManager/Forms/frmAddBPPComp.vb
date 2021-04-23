Public Class frmAddBPPComp
    Dim m_AddNew As Boolean = False
    Dim m_CompID As String = ""

    Public Property CompID As String
        Get
            Return m_CompID
        End Get
        Set(value As String)
            m_CompID = value
        End Set
    End Property

    Public Property AddNew() As Boolean
        Get
            Return m_AddNew
        End Get
        Set(ByVal value As Boolean)
            m_AddNew = value
        End Set
    End Property

    Private Sub cmdAdd_Click(sender As System.Object, e As System.EventArgs) Handles cmdAdd.Click
        If m_AddNew Then
            AddComp()
        Else
            UpdateComp()
            Me.Close()
        End If
    End Sub

    Private Sub TextBoxGotFocus(sender As Object, e As System.EventArgs) Handles txtSaleYear.GotFocus, txtSalePrice.GotFocus, _
            txtDescription.GotFocus, txtIndustry.GotFocus, txtAssetCategory.GotFocus, txtAssetType.GotFocus, txtManufactureYear.GotFocus, _
            txtManufacturer.GotFocus, txtModel.GotFocus, txtSerialNumber.GotFocus, txtMachineHours.GotFocus, txtCompSource.GotFocus, _
            txtCompSourceWebsite.GotFocus, txtCompSourcePhone.GotFocus, txtCompSourceContact.GotFocus, txtDetails.GotFocus, _
            txtAuctionDate.GotFocus, txtLotNumber.GotFocus

        Try
            If sender.name.ToString.StartsWith("txt") Then sender.selectall()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frmAddBPPComp_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If m_AddNew Then

        Else
            cmdAdd.Text = "OK"
            RefreshData()
        End If
    End Sub
    Private Sub RefreshData()
        Try
            Dim sSQL As New StringBuilder, dt As DataTable, dr As DataRow

            sSQL.Append("SELECT * FROM BPPComps WHERE CompID = ").Append(m_CompID)

            If (GetData(sSQL.ToString, dt)) = 0 Then
                MsgBox("Comps not found, SQL = " & sSQL.ToString)
                Exit Sub
            End If
            dr = dt.Rows(0)

            txtSaleYear.Text = dr("SaleYear").ToString
            txtSalePrice.Text = dr("SalePrice").ToString
            txtDescription.Text = dr("Description").ToString
            txtIndustry.Text = dr("Industry").ToString
            txtAssetCategory.Text = dr("AssetCategory").ToString
            txtAssetType.Text = dr("AssetType").ToString
            txtManufactureYear.Text = dr("ManufactureYear").ToString
            txtManufacturer.Text = dr("Manufacturer").ToString
            txtModel.Text = dr("Model").ToString
            txtSerialNumber.Text = dr("SerialNumber").ToString
            txtMachineHours.Text = dr("MachineHours").ToString
            chkUsedFl.Checked = dr("UsedFl")
            chkSoldFl.Checked = dr("SoldFl")
            txtCompSource.Text = dr("CompSource").ToString
            txtCompSourceWebsite.Text = dr("CompSourceWebsite").ToString
            txtCompSourcePhone.Text = dr("CompSourcePhone").ToString
            txtCompSourceContact.Text = dr("CompSourceContact").ToString
            chkDiscontinuedFl.Checked = dr("DiscontinuedFl")
            txtDetails.Text = dr("Details").ToString
            If IsDBNull(dr("AuctionDate")) Then
                txtAuctionDate.Text = ""
            Else
                txtAuctionDate.Text = Format(dr("AuctionDate"), "MM/dd/yyyy")
            End If
            txtLotNumber.Text = dr("LotNumber").ToString

        Catch ex As Exception
            MsgBox("Error loading:  " & ex.Message)
        End Try
    End Sub
    Private Sub AddComp()
        Try
            Dim sSQL As StringBuilder = New StringBuilder

            sSQL.Length = 0
            sSQL.Append("INSERT BPPComps([SaleYear],[SalePrice],[Description],[Industry],[AssetCategory],[AssetType],")
            sSQL.Append("[ManufactureYear],[Manufacturer],[Model],[SerialNumber],[MachineHours],[UsedFl],[SoldFl],")
            sSQL.Append("[CompSource],[CompSourceWebsite],[CompSourcePhone],[CompSourceContact],[DiscontinuedFl],[Details],[AuctionDate],[LotNumber],[AddUser])")
            sSQL.Append(" SELECT ").Append(Val(txtSaleYear.Text)).Append(",")
            sSQL.Append(Val(txtSalePrice.Text)).Append(",")
            sSQL.Append(QuoStr(txtDescription.Text)).Append(",")
            sSQL.Append(QuoStr(txtIndustry.Text)).Append(",")
            sSQL.Append(QuoStr(txtAssetCategory.Text)).Append(",")
            sSQL.Append(QuoStr(txtAssetType.Text)).Append(",")
            sSQL.Append(Val(txtManufactureYear.Text)).Append(",")
            sSQL.Append(QuoStr(txtManufacturer.Text)).Append(",")
            sSQL.Append(QuoStr(txtModel.Text)).Append(",")
            sSQL.Append(QuoStr(txtSerialNumber.Text)).Append(",")
            sSQL.Append(Val(txtMachineHours.Text)).Append(",")
            sSQL.Append(IIf(chkUsedFl.Checked, "1", "0")).Append(",")
            sSQL.Append(IIf(chkSoldFl.Checked, "1", "0")).Append(",")
            sSQL.Append(QuoStr(txtCompSource.Text)).Append(",")
            sSQL.Append(QuoStr(txtCompSourceWebsite.Text)).Append(",")
            sSQL.Append(QuoStr(txtCompSourcePhone.Text)).Append(",")
            sSQL.Append(QuoStr(txtCompSourceContact.Text)).Append(",")
            sSQL.Append(IIf(chkDiscontinuedFl.Checked, "1", "0")).Append(",")
            sSQL.Append(QuoStr(txtDetails.Text)).Append(",")
            sSQL.Append(IIf(IsDate(txtAuctionDate.Text.Trim), QuoStr(txtAuctionDate.Text.Trim), "NULL")).Append(",")
            sSQL.Append(QuoStr(txtLotNumber.Text)).Append(",")
            sSQL.Append(QuoStr(AppData.UserId))
            If ExecuteSQL(sSQL.ToString) = 1 Then
                MsgBox("Saved")
            Else
                MsgBox("Error saving")
            End If
            txtSaleYear.Focus()
        Catch ex As Exception
            MsgBox("Error saving:  " & ex.Message)
        End Try
    End Sub
    Private Sub UpdateComp()
        Try
            Dim sSQL As StringBuilder = New StringBuilder
            Dim s1 As StringBuilder = New StringBuilder
            Dim s2 As String = ""

            s1.Append("UPDATE BPPComps SET [SaleYear] = {0},[SalePrice] = {1}, [Description] = {2}, Industry = {3}, [AssetCategory] = {4},[AssetType] = {5},")
            s1.Append("[ManufactureYear] = {6},[Manufacturer] = {7},[Model] = {8},[SerialNumber] = {9},[MachineHours] = {10},[UsedFl] = {11},[SoldFl] = {12},")
            s1.Append("[CompSource] = {13},[CompSourceWebsite] = {14},[CompSourcePhone] = {15},[CompSourceContact] = {16},[DiscontinuedFl] = {17},")
            s1.Append("[Details] = {18},[AuctionDate] = {19},[LotNumber] = {20},[ChangeUser] = {21},[ChangeDate] = GETDATE(), ChangeType = 2")
            s2 = String.Format(s1.ToString, Val(txtSaleYear.Text), Val(txtSalePrice.Text), QuoStr(txtDescription.Text), QuoStr(txtIndustry.Text), QuoStr(txtAssetCategory.Text), _
                QuoStr(txtAssetType.Text), Val(txtManufactureYear.Text), QuoStr(txtManufacturer.Text), QuoStr(txtModel.Text), QuoStr(txtSerialNumber.Text), _
                Val(txtMachineHours.Text), IIf(chkUsedFl.Checked, "1", "0"), IIf(chkSoldFl.Checked, "1", "0"), QuoStr(txtCompSource.Text), _
                QuoStr(txtCompSourceWebsite.Text), QuoStr(txtCompSourcePhone.Text), QuoStr(txtCompSourceContact.Text), IIf(chkDiscontinuedFl.Checked, "1", "0"), _
                QuoStr(txtDetails.Text), IIf(IsDate(txtAuctionDate.Text.Trim), QuoStr(txtAuctionDate.Text.Trim), "NULL"), QuoStr(txtLotNumber.Text), _
                QuoStr(AppData.UserId))
            sSQL.Append(s2).Append(" WHERE CompID = ").Append(m_CompID)
            If ExecuteSQL(sSQL.ToString) = 1 Then
                MsgBox("Saved")
            Else
                MsgBox("Error saving")
            End If
            txtSaleYear.Focus()
        Catch ex As Exception
            MsgBox("Error saving:  " & ex.Message)
        End Try
    End Sub
End Class