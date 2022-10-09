Public Class frmAgencyContacts
    Private bActivated As Boolean
    Private m_AgencyId As String
    Private m_agencyname As String
    Private bChanged As Boolean

    Public Property AgencyId() As String
        Get
            Return m_AgencyId
        End Get
        Set(ByVal value As String)
            m_AgencyId = value
        End Set
    End Property
    Public Property AgencyName() As String
        Get
            Return m_agencyname
        End Get
        Set(ByVal value As String)
            m_agencyname = value
        End Set
    End Property
    Private Sub InitInfo()
        Try
            Dim colContactType As New Collection
            cboContactType.Items.Clear()
            LoadComboBox("select FieldValue, FieldValue AS ContactType from FieldDataDefinition WHERE TableName='AgencyContacts' AND FieldName='ContactType' ORDER BY 2", cboContactType, colContactType)
            cboContactType.Text = colContactType(1).ToString
            cboStateCd.Items.Clear()
            For Each s As String In colStateCodes
                cboStateCd.Items.Add(s)
            Next
        Catch ex As Exception
            MsgBox("Error in InitInfo:  " & ex.Message)
        End Try
    End Sub
    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub
    Private Sub Form_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        If bActivated Then Exit Sub
        InitInfo()
        RefreshData(cboContactType.Text)
        Me.Text = "Agency contacts for " & m_agencyname
        bActivated = True
    End Sub
    Private Function RefreshData(sContactType As String) As Boolean
        Dim sError As String = "", dt As New DataTable, sSQL As String = ""

        Try
            txtAddress.Text = ""
            txtCity.Text = ""
            txtEMail.Text = ""
            txtName.Text = ""
            txtPhone.Text = ""
            txtZip.Text = ""
            cboStateCd.Text = ""
            sSQL = "SELECT ac.ContactType, ac.ContactName, ac.ContactAddress, ac.ContactCity, ac.ContactStateCd, ac.ContactZip, ac.ContactPhone, ac.ContactEMail" &
                " FROM AgencyContacts ac WHERE ac.AgencyId = " & m_AgencyId & " AND ac.ContactType = " & QuoStr(sContactType)
            GetData(sSQL, dt)
            If dt.Rows.Count > 0 Then
                Dim dr As DataRow = dt.Rows(0)
                txtAddress.Text = dr("ContactAddress").ToString.Trim
                txtCity.Text = dr("ContactCity").ToString.Trim
                txtEMail.Text = dr("ContactEMail").ToString.Trim
                txtName.Text = dr("ContactName").ToString.Trim
                txtPhone.Text = dr("ContactPhone").ToString.Trim
                txtZip.Text = dr("ContactZip").ToString.Trim
                If dr("ContactStateCd").ToString.Trim <> "" Then cboStateCd.Text = colStateCodes(dr("ContactStateCd").ToString.Trim)
            End If
            If sContactType = "AofA Authorization" Then
                cmdDupe.Visible = True
            Else
                cmdDupe.Visible = False
            End If
            Return True

        Catch ex As Exception
            MsgBox("Error in RefreshData:  " & ex.Message)
            Return False
        End Try
    End Function
    Private Sub txtName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles txtName.LostFocus, txtAddress.LostFocus, txtCity.LostFocus, txtZip.LostFocus,
            txtPhone.LostFocus, txtEMail.LostFocus, cboStateCd.LostFocus
        If bChanged Then
            If TypeOf sender Is ComboBox Then
                'If sender.SelectedIndex >= 0 Then
                UpdateDB(sender, cboContactType.Text)
                'End If
            Else
                UpdateDB(sender, cboContactType.Text)
            End If
            bChanged = False
        End If
    End Sub
    Private Sub UpdateDB(ctl As Control, contacttype As String)
        Try
            Dim value As String = ctl.Text.Trim
            Dim fieldname As String = ""
            Select Case ctl.Name
                Case "txtName"
                    fieldname = "ContactName"
                Case "txtAddress"
                    fieldname = "ContactAddress"
                Case "txtCity"
                    fieldname = "ContactCity"
                Case "cboStateCd"
                    fieldname = "ContactStateCd"
                    If colStateNames.Contains(value) Then
                        value = colStateNames(value)
                    End If
                Case "txtZip"
                    fieldname = "ContactZip"
                Case "txtPhone"
                    fieldname = "ContactPhone"
                Case "txtEMail"
                    fieldname = "ContactEMail"
            End Select
            If fieldname = "ContactName" Then
                value = QuoStr(value)
            Else
                If value <> "" Then value = QuoStr(value) Else value = "NULL"
            End If

            Dim sql As New StringBuilder
            sql.Append(" UPDATE AgencyContacts SET ChangeDate=GETDATE(), ChangeUser=").Append(QuoStr(AppData.UserId)).Append(", ChangeType=2")
            sql.Append(",").Append(fieldname).Append("=").Append(value)
            sql.Append(" WHERE AgencyId=").Append(m_AgencyId).Append(" AND ContactType=").Append(QuoStr(contacttype))
            sql.Append(" IF @@ROWCOUNT=0 BEGIN")
            sql.Append(" INSERT AgencyContacts (AgencyId, ContactType,AddUser,").Append(fieldname).Append(")")
            sql.Append(" SELECT ").Append(m_AgencyId).Append(",").Append(QuoStr(contacttype)).Append(",").Append(QuoStr(AppData.UserId)).Append(",").Append(value)
            sql.Append(" END")
            ExecuteSQL(sql.ToString)
        Catch ex As Exception
            If InStr(ex.Message, "column does not allow nulls", CompareMethod.Text) > 0 Then
                MsgBox("Must enter a name")
            Else
                MsgBox("Error saving data:  " & ex.Message)
            End If
        End Try
    End Sub
    Private Sub txtAddress_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles txtAddress.GotFocus, txtCity.GotFocus, txtZip.GotFocus, txtEMail.GotFocus,
            txtName.GotFocus, txtZip.GotFocus, txtPhone.GotFocus
        sender.selectall()
    End Sub
    Private Sub txtName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles txtName.TextChanged, txtAddress.TextChanged, txtCity.TextChanged,
            txtZip.TextChanged, txtEMail.TextChanged, txtPhone.TextChanged,
            cboStateCd.TextChanged
        If bActivated Then bChanged = True
    End Sub
    Private Sub FrmAgencyContacts_Load(sender As Object, e As EventArgs) Handles Me.Load
        bActivated = False
        bChanged = False
    End Sub
    Private Sub cboContactType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboContactType.SelectedIndexChanged
        If bActivated = False Then Exit Sub
        bActivated = False
        RefreshData(cboContactType.Text)
        bActivated = True
    End Sub
    Private Sub cmdDupe_Click(sender As Object, e As EventArgs) Handles cmdDupe.Click
        If MsgBox("Do you wish to duplicate all contact information?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            DuplicateContactInfo()
        End If
    End Sub
    Private Sub DuplicateContactInfo()
        Try
            Dim sql As New StringBuilder
            sql.Append("DELETE AgencyContacts WHERE AgencyId = ").Append(m_AgencyId).Append(" AND ContactType <> 'AofA Authorization'")
            ExecuteSQL(sql.ToString)
            Dim dt As New DataTable
            sql.Clear()
            sql.Append("SELECT FieldValue FROM FieldDataDefinition WHERE TableName='AgencyContacts' AND FieldName = 'ContactType'")
            GetData(sql.ToString, dt)
            For Each dr As DataRow In dt.Rows
                If dr("FieldValue").ToString <> "AofA Authorization" Then
                    sql.Clear()
                    sql.Append(" INSERT AgencyContacts (AgencyId,ContactType,ContactName,")
                    sql.Append(" ContactAddress, ContactCity, ContactStateCd, ContactZip, ContactPhone, ContactEMail, AddUser, ChangeType)")
                    sql.Append(" SELECT ").Append(m_AgencyId).Append(",").Append(QuoStr(dr("FieldValue").ToString)).Append(",ContactName,")
                    sql.Append(" ContactAddress,ContactCity,ContactStateCd,ContactZip,ContactPhone,ContactEMail,").Append(QuoStr(AppData.UserId)).Append(", 1")
                    sql.Append(" FROM AgencyContacts WHERE AgencyId = ").Append(m_AgencyId).Append(" And ContactType = 'AofA Authorization'")
                    ExecuteSQL(sql.ToString)
                End If

            Next

        Catch ex As Exception
            MsgBox("Error duplicating contacts:  " & ex.Message)
        End Try

    End Sub
End Class