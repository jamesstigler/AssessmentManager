Public Class frmAsset

    Private bActivated As Boolean
    Private m_ClientId As Long
    Private m_LocationId As Long
    Private m_AssessmentId As Long
    Private m_AssetId As String
    Private m_TaxYear As Integer
    Private m_FactorCodes As String()
    Private m_ClientFactorCodes As String()
    Private sStateCd As String
    Private lFactorEntityId(5) As Long

    Private DBUpdate() As typeDBUpdateInfo
    Private bChanged As Boolean

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
    Public Property AssessmentId() As Long
        Get
            Return m_AssessmentId
        End Get
        Set(ByVal value As Long)
            m_AssessmentId = value
        End Set
    End Property
    Public Property AssetId() As String
        Get
            Return m_AssetId
        End Get
        Set(ByVal value As String)
            m_assetid = value
        End Set
    End Property
    Public Property FactorCodes() As String()
        Get
            Return m_FactorCodes
        End Get
        Set(ByVal value As String())
            m_FactorCodes = value
        End Set
    End Property
    Public Property ClientFactorCodes() As String()
        Get
            Return m_ClientFactorCodes
        End Get
        Set(ByVal value As String())
            m_ClientFactorCodes = value
        End Set
    End Property
    Private Sub InitInfo()
        Dim DBPrimaryKeys(0) As typeDBUpdateInfo, l As Long

        DBPrimaryKeys(0).sTable = "Assets"
        ReDim DBPrimaryKeys(0).PrimaryKeys(4)
        DBPrimaryKeys(0).PrimaryKeys(0).sField = "ClientId"
        DBPrimaryKeys(0).PrimaryKeys(1).sField = "LocationId"
        DBPrimaryKeys(0).PrimaryKeys(2).sField = "AssessmentId"
        DBPrimaryKeys(0).PrimaryKeys(3).sField = "AssetId"
        DBPrimaryKeys(0).PrimaryKeys(4).sField = "TaxYear"

        InitControls(Me, DBUpdate, DBPrimaryKeys)
        For l = 0 To UBound(DBUpdate)
            DBUpdate(l).PrimaryKeys(0).vValue = m_ClientId
            DBUpdate(l).PrimaryKeys(1).vValue = m_LocationId
            DBUpdate(l).PrimaryKeys(2).vValue = m_AssessmentId
            DBUpdate(l).PrimaryKeys(3).vValue = QuoStr(m_AssetId)
            DBUpdate(l).PrimaryKeys(4).vValue = AppData.TaxYear
        Next
    End Sub


    Private Sub frmAsset_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If bActivated Then Exit Sub
        InitInfo()
        RefreshData()
        bActivated = True
    End Sub


    Private Function RefreshData() As Boolean
        Dim sError As String = "", dt As New DataTable, sSQL As String, dr As DataRow
        Dim i As Integer
        Try
            txtAssetId.Text = ""
            sSQL = "SELECT c.Name, l.Address, l.City, ISNULL(assess.AcctNum,'') AS AcctNum, l.StateCd, a.ClientId, a.LocationId," &
                " a.AssessmentId, a.AssetId, a.TaxYear, assess.FactorEntityId1, assess.FactorEntityId2," &
                " assess.FactorEntityId3, assess.FactorEntityId4, assess.FactorEntityId5," &
                " a.VIN, a.LocationAddress,a.OriginalCost,a.PurchaseDate,a.Description,a.GLCode," &
                " a.LessorName, a.LessorAddress, a.LeaseTerm, a.EquipmentMake, a.EquipmentModel, a.LeaseType, a.AuditFl" &
                " FROM Clients AS c INNER JOIN" &
                " LocationsBPP AS l ON c.ClientId = l.ClientId INNER JOIN" &
                " AssessmentsBPP AS assess ON l.ClientId = assess.ClientId" &
                " AND l.LocationId = assess.LocationId AND l.TaxYear = assess.TaxYear INNER JOIN" &
                " Assets AS a ON assess.ClientId = a.ClientId AND assess.LocationId = a.LocationId AND assess.AssessmentId = a.AssessmentId" &
                " AND assess.TaxYear = a.TaxYear" &
                " WHERE a.ClientId = " & m_ClientId &
                " AND a.LocationId = " & m_LocationId &
                " AND a.AssessmentId = " & m_AssessmentId &
                " AND a.TaxYear = " & m_TaxYear &
                " AND a.AssetId = " & QuoStr(m_AssetId)

            GetData(sSQL, dt)
            RefreshControls(Me, dt, "Assets")
            dr = dt.Rows(0)
            For i = 1 To 5
                lFactorEntityId(i) = UnNullToDouble(dr("FactorEntityId" & i))
            Next
            LoadAllocationPct()

            LoadDropDowns()

            txtAssetId.Text = m_AssetId
            sStateCd = Trim(CStr(dr("StateCd")))
            Me.Text = "Asset:  " & m_AssetId & " for client " & UnNullToString((dr("Name"))) & "   " & UnNullToString(dr("Address")) & "   " & _
                UnNullToString(dr("City")) & " " & UnNullToString(dr("StateCd")) & " account " & dr("AcctNum")

            dt.Dispose()
            Return True
        Catch ex As Exception
            MsgBox("Error in RefreshData:  " & ex.Message)
            Return False
        End Try
    End Function

    Private Function LoadAllocationPct()
        Dim sSQL As New StringBuilder, dt As New DataTable, dr As DataRow, i As Integer

        txtPct1.Text = Format(1, csFactor)
        txtPct2.Text = Format(1, csFactor)
        txtPct3.Text = Format(1, csFactor)
        txtPct4.Text = Format(1, csFactor)
        txtPct5.Text = Format(1, csFactor)
        txtPct1Interstate.Text = Format(1, csFactor)
        txtPct2Interstate.Text = Format(1, csFactor)
        txtPct3Interstate.Text = Format(1, csFactor)
        txtPct4Interstate.Text = Format(1, csFactor)
        txtPct5Interstate.Text = Format(1, csFactor)

        sSQL.Append("SELECT FactorEntityId, AllocationPct, ISNULL(InterstateAllocationPct,1) AS InterstateAllocationPct")
        sSQL.Append(" FROM AssetAllocationPct WHERE ClientId = ").Append(m_ClientId).Append(" AND LocationId = ").Append(m_LocationId)
        sSQL.Append(" AND AssessmentId = ").Append(m_AssessmentId).Append(" AND AssetId = ").Append(QuoStr(m_AssetId)).Append(" AND TaxYear = ").Append(m_TaxYear)
        If GetData(sSQL.ToString, dt) > 0 Then
            For Each dr In dt.Rows
                For i = LBound(lFactorEntityId) To UBound(lFactorEntityId)
                    Select Case i
                        Case 1
                            If lFactorEntityId(i) = dr("FactorEntityId") Then
                                txtPct1.Text = Format(dr("AllocationPct"), csFactor)
                                txtPct1Interstate.Text = Format(dr("InterstateAllocationPct"), csFactor)
                            End If
                        Case 2
                            If lFactorEntityId(i) = dr("FactorEntityId") Then
                                txtPct2.Text = Format(dr("AllocationPct"), csFactor)
                                txtPct2Interstate.Text = Format(dr("InterstateAllocationPct"), csFactor)
                            End If
                        Case 3
                            If lFactorEntityId(i) = dr("FactorEntityId") Then
                                txtPct3.Text = Format(dr("AllocationPct"), csFactor)
                                txtPct3Interstate.Text = Format(dr("InterstateAllocationPct"), csFactor)
                            End If
                        Case 4
                            If lFactorEntityId(i) = dr("FactorEntityId") Then
                                txtPct4.Text = Format(dr("AllocationPct"), csFactor)
                                txtPct4Interstate.Text = Format(dr("InterstateAllocationPct"), csFactor)
                            End If
                        Case 5
                            If lFactorEntityId(i) = dr("FactorEntityId") Then
                                txtPct5.Text = Format(dr("AllocationPct"), csFactor)
                                txtPct5Interstate.Text = Format(dr("InterstateAllocationPct"), csFactor)
                            End If
                    End Select
                Next
            Next
        End If
        dt.Dispose()

    End Function

    Private Sub ComboBox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles cboFactorOvr1.GotFocus, cboFactorOvr2.GotFocus, cboFactorOvr3.GotFocus,
            cboFactorOvr4.GotFocus, cboFactorOvr5.GotFocus, txtAddress.GotFocus,
             txtVIN.GotFocus, txtOriginalCost.GotFocus, txtPurchaseDate.GotFocus,
            txtDescription.GotFocus, txtGLCode.GotFocus,
            cboClientFactorOvr1.GotFocus, cboClientFactorOvr2.GotFocus, cboClientFactorOvr3.GotFocus,
            cboClientFactorOvr4.GotFocus, cboClientFactorOvr5.GotFocus,
            txtPct1.GotFocus, txtPct2.GotFocus, txtPct3.GotFocus, txtPct4.GotFocus, txtPct5.GotFocus,
            txtPct1Interstate.GotFocus, txtPct2Interstate.GotFocus, txtPct3Interstate.GotFocus, txtPct4Interstate.GotFocus, txtPct5Interstate.GotFocus,
            txtEquipmentMake.GotFocus, txtEquipmentModel.GotFocus, txtLeaseTerm.GotFocus, txtLessorAddress.GotFocus, txtLessorName.GotFocus, cboLeaseType.GotFocus

        sender.selectall()
    End Sub

    Private Sub ComboBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles cboFactorOvr1.TextChanged, cboFactorOvr2.TextChanged, cboFactorOvr3.TextChanged,
            cboFactorOvr4.TextChanged, cboFactorOvr5.TextChanged, txtAddress.TextChanged,
             txtVIN.TextChanged, txtOriginalCost.TextChanged,
            txtPurchaseDate.TextChanged, txtDescription.TextChanged, txtGLCode.TextChanged,
            cboClientFactorOvr1.TextChanged, cboClientFactorOvr2.TextChanged, cboClientFactorOvr3.TextChanged,
            cboClientFactorOvr4.TextChanged, cboClientFactorOvr5.TextChanged,
            txtPct1.TextChanged, txtPct2.TextChanged, txtPct3.TextChanged, txtPct4.TextChanged, txtPct5.TextChanged,
            txtPct1Interstate.TextChanged, txtPct2Interstate.TextChanged, txtPct3Interstate.TextChanged, txtPct4Interstate.TextChanged, txtPct5Interstate.TextChanged,
            txtEquipmentMake.TextChanged, txtEquipmentModel.TextChanged, txtLeaseTerm.TextChanged, txtLessorAddress.TextChanged, txtLessorName.TextChanged,
            cboLeaseType.TextChanged, chkAuditFl.CheckedChanged
        If bActivated Then bChanged = True
    End Sub
    Private Sub ComboBox_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles cboFactorOvr1.LostFocus, cboFactorOvr2.LostFocus, cboFactorOvr3.LostFocus,
            cboFactorOvr4.LostFocus, cboFactorOvr5.LostFocus, txtAddress.LostFocus,
            txtVIN.LostFocus, txtOriginalCost.LostFocus,
            txtPurchaseDate.LostFocus, txtDescription.LostFocus, txtGLCode.LostFocus,
            cboClientFactorOvr1.LostFocus, cboClientFactorOvr2.LostFocus, cboClientFactorOvr3.LostFocus,
            cboClientFactorOvr4.LostFocus, cboClientFactorOvr5.LostFocus,
            txtPct1.LostFocus, txtPct2.LostFocus, txtPct3.LostFocus, txtPct4.LostFocus, txtPct5.LostFocus,
            txtPct1Interstate.LostFocus, txtPct2Interstate.LostFocus, txtPct3Interstate.LostFocus, txtPct4Interstate.LostFocus, txtPct5Interstate.LostFocus,
            txtEquipmentMake.LostFocus, txtEquipmentModel.LostFocus, txtLeaseTerm.LostFocus, txtLessorAddress.LostFocus, txtLessorName.LostFocus,
            cboLeaseType.LostFocus, chkAuditFl.LostFocus

        If bChanged Then

            If TypeOf sender Is ComboBox And (InStr(sender.name, "cboClientFactorOvr", CompareMethod.Text) > 0 Or InStr(sender.name, "cboFactorOvr", CompareMethod.Text) > 0) Then
                If sender.SelectedIndex >= 0 Then
                    SaveData(sender.name, sender.text)
                End If
            Else
                If sender.name.ToString.StartsWith("txtPct") Then
                    Dim sAssetId(0) As String
                    sAssetId(0) = m_AssetId
                    Dim sPct As String = sender.text.ToString.Trim
                    If sPct = "" Then sPct = 0
                    sPct = Replace(sPct, ",", "")
                    Dim eType As enumAllocationPctType
                    If sender.name.ToString.Contains("Interstate") Then
                        eType = enumAllocationPctType.eInterstate
                    Else
                        eType = enumAllocationPctType.eServiceLevel
                    End If
                    If IsNumeric(sPct) Then
                        SaveAssetAllocationPct(m_ClientId, m_LocationId, m_AssessmentId, m_TaxYear, sAssetId, lFactorEntityId(CInt(sender.name.ToString.Substring(6, 1))), eType, CDbl(sPct) / 100)
                    Else
                        MsgBox("Must enter number")
                    End If
                    sender.text = Format(CDbl(sPct) / 100, csFactor)
                Else
                    UpdateDB(sender, DBUpdate)
                End If
            End If
            bChanged = False
        End If

    End Sub
    Private Function SaveData(ByVal cboName As String, ByVal sFactorCode As String) As Boolean
        Dim lId As Long = 0, sAssetId(0) As String

        Try
            sFactorCode = Trim(sFactorCode)
            sAssetId(0) = m_AssetId
            lId = lFactorEntityId(Val(Microsoft.VisualBasic.Right(cboName, 1)))
            If InStr(cboName, "cboClientFactorOvr", CompareMethod.Text) > 0 Then
                SaveAssetClientOverride(m_ClientId, m_LocationId, m_AssessmentId, m_TaxYear, sAssetId, lId, sFactorCode)
            Else
                SaveAssetOverride(m_ClientId, m_LocationId, m_AssessmentId, m_TaxYear, sAssetId, lId, sFactorCode)
            End If

            Return True
        Catch ex As Exception
            MsgBox("Error saving data:  " & ex.Message)
            Return False
        End Try
    End Function

    Private Function LoadDropDowns() As Boolean
        Dim sSQL As String = "", dt As New DataTable, dr As DataRow, i As Integer = 0

        cboFactorOvr1.Text = m_FactorCodes(1) : cboFactorOvr1.Items.Clear() : cboFactorOvr1.Items.Add("")
        cboFactorOvr2.Text = m_FactorCodes(2) : cboFactorOvr2.Items.Clear() : cboFactorOvr2.Items.Add("")
        cboFactorOvr3.Text = m_FactorCodes(3) : cboFactorOvr3.Items.Clear() : cboFactorOvr3.Items.Add("")
        cboFactorOvr4.Text = m_FactorCodes(4) : cboFactorOvr4.Items.Clear() : cboFactorOvr4.Items.Add("")
        cboFactorOvr5.Text = m_FactorCodes(5) : cboFactorOvr5.Items.Clear() : cboFactorOvr5.Items.Add("")

        cboClientFactorOvr1.Text = m_ClientFactorCodes(1) : cboClientFactorOvr1.Items.Clear() : cboClientFactorOvr1.Items.Add("")
        cboClientFactorOvr2.Text = m_ClientFactorCodes(2) : cboClientFactorOvr2.Items.Clear() : cboClientFactorOvr2.Items.Add("")
        cboClientFactorOvr3.Text = m_ClientFactorCodes(3) : cboClientFactorOvr3.Items.Clear() : cboClientFactorOvr3.Items.Add("")
        cboClientFactorOvr4.Text = m_ClientFactorCodes(4) : cboClientFactorOvr4.Items.Clear() : cboClientFactorOvr4.Items.Add("")
        cboClientFactorOvr5.Text = m_ClientFactorCodes(5) : cboClientFactorOvr5.Items.Clear() : cboClientFactorOvr5.Items.Add("")

        If lFactorEntityId(1) = 0 Then cboFactorOvr1.Visible = False : cboClientFactorOvr1.Visible = False : txtPct1.Visible = False : txtPct1Interstate.Visible = False
        If lFactorEntityId(2) = 0 Then cboFactorOvr2.Visible = False : cboClientFactorOvr2.Visible = False : txtPct2.Visible = False : txtPct2Interstate.Visible = False
        If lFactorEntityId(3) = 0 Then cboFactorOvr3.Visible = False : cboClientFactorOvr3.Visible = False : txtPct3.Visible = False : txtPct3Interstate.Visible = False
        If lFactorEntityId(4) = 0 Then cboFactorOvr4.Visible = False : cboClientFactorOvr4.Visible = False : txtPct4.Visible = False : txtPct4Interstate.Visible = False
        If lFactorEntityId(5) = 0 Then cboFactorOvr5.Visible = False : cboClientFactorOvr5.Visible = False : txtPct5.Visible = False : txtPct5Interstate.Visible = False

        sSQL = ""
        For i = 1 To 5
            If lFactorEntityId(i) > 0 Then
                If sSQL <> "" Then sSQL = sSQL & " UNION "
                sSQL = sSQL & "SELECT " & i & " AS Counter, fe.Name, fec.FactorCode FROM FactorEntities fe, FactorEntityCodes fec" & _
                    " WHERE fe.FactorEntityId = " & lFactorEntityId(i) & " AND fec.TaxYear = " & m_TaxYear & _
                    " AND fe.FactorEntityId = fec.FactorEntityId"
            End If
        Next
        If sSQL = "" Then Return True

        sSQL = sSQL & " ORDER BY Counter, FactorCode"
        GetData(sSQL, dt)
        For Each dr In dt.Rows
            If dr("Counter") = 1 Then
                If lbl1.Text = "" Then lbl1.Text = dr("Name")
                cboFactorOvr1.Items.Add(dr("FactorCode"))
                cboClientFactorOvr1.Items.Add(dr("FactorCode"))
            ElseIf dr("Counter") = 2 Then
                If lbl2.Text = "" Then lbl2.Text = dr("Name")
                cboFactorOvr2.Items.Add(dr("FactorCode"))
                cboClientFactorOvr2.Items.Add(dr("FactorCode"))
            ElseIf dr("Counter") = 3 Then
                If lbl3.Text = "" Then lbl3.Text = dr("Name")
                cboFactorOvr3.Items.Add(dr("FactorCode"))
                cboClientFactorOvr3.Items.Add(dr("FactorCode"))
            ElseIf dr("Counter") = 4 Then
                If lbl4.Text = "" Then lbl4.Text = dr("Name")
                cboFactorOvr4.Items.Add(dr("FactorCode"))
                cboClientFactorOvr4.Items.Add(dr("FactorCode"))
            ElseIf dr("Counter") = 5 Then
                If lbl5.Text = "" Then lbl5.Text = dr("Name")
                cboFactorOvr5.Items.Add(dr("FactorCode"))
                cboClientFactorOvr5.Items.Add(dr("FactorCode"))
            End If
        Next
        dt.Dispose()

    End Function

    Private Sub cboLeaseType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLeaseType.SelectedIndexChanged

    End Sub
End Class