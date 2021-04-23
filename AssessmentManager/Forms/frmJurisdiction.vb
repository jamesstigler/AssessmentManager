Public Class frmJurisdiction
    Private bActivated As Boolean
    Private m_JurisdictionId As Long
    Private m_TaxYear As Integer
    Private DBUpdate() As typeDBUpdateInfo
    Private bChanged As Boolean
    Private colCollectors As Collection
    Private sStateCd As String

    Public Property JurisdictionId() As Long
        Get
            Return m_JurisdictionId
        End Get
        Set(ByVal value As Long)
            m_JurisdictionId = value
        End Set
    End Property
    Public Property TaxYear() As Integer
        Get
            Return m_TaxYear
        End Get
        Set(ByVal value As Integer)
            m_TaxYear = value
        End Set
    End Property


    Private Sub InitInfo()
        Dim DBPrimaryKeys(0) As typeDBUpdateInfo, l As Long

        DBPrimaryKeys(0).sTable = "Jurisdictions"
        ReDim DBPrimaryKeys(0).PrimaryKeys(1)
        DBPrimaryKeys(0).PrimaryKeys(0).sField = "JurisdictionId"
        DBPrimaryKeys(0).PrimaryKeys(1).sField = "TaxYear"

        InitControls(Me, DBUpdate, DBPrimaryKeys)
        For l = 0 To UBound(DBUpdate)
            DBUpdate(l).PrimaryKeys(0).vValue = m_JurisdictionId
            DBUpdate(l).PrimaryKeys(1).vValue = m_TaxYear
        Next


    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub frmJurisdiction_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If bActivated Then Exit Sub

        InitInfo()
        RefreshData()

        bActivated = True
    End Sub

    Private Function RefreshData() As Boolean
        Dim sError As String = "", dt As DataTable, sSQL As String, dr As DataRow

        Try


            sSQL = "SELECT j.*, (SELECT RTRIM(c.Name) + ', ' + c.StateCd FROM Collectors c" & _
                " WHERE c.CollectorId = j.CollectorId AND c.TaxYear = j.TaxYear) AS CollectorName" & _
                " FROM Jurisdictions j" & _
                " WHERE j.JurisdictionId = " & m_JurisdictionId & _
                " AND j.TaxYear = " & m_TaxYear
            GetData(sSQL, dt)
            If dt.Rows.Count > 0 Then
                sStateCd = dt.Rows(0)("StateCd")
                Me.Text = "Jurisdiction:  " & dt.Rows(0)("Name") & ", " & dt.Rows(0)("StateCd")
            End If

            RefreshControls(Me, dt, "Jurisdictions")

            LoadDropDowns(UnNullToString(dt.Rows(0)("CollectorName")), True)

            Return True

        Catch ex As Exception
            MsgBox("Error in RefreshData:  " & ex.Message)
            Return False
        End Try
    End Function
    Private Sub TextBox3_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox3.DoubleClick
        Try
            If Trim(sender.text) = "" Then Exit Sub
            Process.Start("iexplore.exe", sender.text)
        Catch ex As Exception
        End Try
    End Sub



    Private Sub txtName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles txtName.LostFocus, txtAddress.LostFocus, txtCity.LostFocus, txtZip.LostFocus,
            txtComment.LostFocus, cboStateCd.LostFocus, TextBox1.LostFocus, TextBox3.LostFocus, txtPhone.LostFocus,
            txtFax.LostFocus, txtPercentage.LostFocus, chkFreeport.LostFocus, cboCollector.LostFocus, txtTaxDistrictCd.LostFocus
        If bChanged Then
            If TypeOf sender Is ComboBox Then
                If sender.SelectedIndex >= 0 Then
                    If InStr(sender.tag, "CollectorId") > 0 Then
                        UpdateDB(sender, DBUpdate, colCollectors)
                        Dim sValue As String = ""
                        If cboCollector.Text = "" Then
                            sValue = "NULL"
                        Else
                            sValue = colCollectors(cboCollector.Text).ToString
                        End If
                        UpdateJurisdictionCollectorId(m_JurisdictionId, sValue, m_TaxYear)
                    Else
                        UpdateDB(sender, DBUpdate)
                    End If
                End If
            Else
                UpdateDB(sender, DBUpdate)
            End If
            bChanged = False
        End If
    End Sub

    Private Sub txtAddress_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles txtAddress.GotFocus, txtCity.GotFocus, txtZip.GotFocus, txtComment.GotFocus,
            txtName.GotFocus, txtZip.GotFocus, TextBox1.GotFocus, TextBox3.GotFocus,
            txtFax.GotFocus, txtPercentage.GotFocus, txtPhone.GotFocus, cboCollector.GotFocus, txtTaxDistrictCd.GotFocus
        sender.selectall()
    End Sub

    Private Sub txtName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles txtName.TextChanged, txtAddress.TextChanged, txtCity.TextChanged, txtComment.TextChanged,
            txtZip.TextChanged, cboStateCd.TextChanged, TextBox1.TextChanged, TextBox3.TextChanged,
            txtFax.TextChanged, txtPercentage.TextChanged, txtPhone.TextChanged, chkFreeport.Click, cboCollector.TextChanged, txtTaxDistrictCd.TextChanged
        If bActivated Then bChanged = True
    End Sub


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub frm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        bActivated = False
        bChanged = False
    End Sub
    Private Function LoadDropDowns(ByVal sCollectorName As String, ByVal bLimitToState As Boolean) As Boolean
        Dim sSQL As String, dt As DataTable, dr As DataRow

        colCollectors = New Collection
        'cboCollector.Text = ""
        cboCollector.Items.Clear() : cboCollector.Items.Add("")

        sSQL = "select CollectorId, (rtrim(Name) + ', ' + StateCd) AS Name, StateCd from Collectors" & _
            " WHERE TaxYear = " & m_TaxYear

        sSQL = sSQL & " ORDER BY Name"
        GetData(sSQL, dt)
        For Each dr In dt.Rows
            If bLimitToState = True Then
                If dr("StateCd") = sStateCd Then
                    cboCollector.Items.Add(dr("Name"))
                End If
            Else
                cboCollector.Items.Add(dr("Name"))
            End If
            colCollectors.Add(dr("CollectorId"), dr("Name"))      'use this to save?
        Next
        If Trim(sCollectorName) <> "" Then cboCollector.Text = sCollectorName
    End Function



    Private Sub cmdCollector_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCollector.Click
        Try
            If Trim(cboCollector.Text) <> "" Then
                Dim lId As Long = colCollectors(cboCollector.Text)
                OpenCollector(lId, m_TaxYear)
            End If
        Catch ex As Exception
            MsgBox("Error opening collector:  " & ex.Message)
        End Try

    End Sub

    Private Sub chkLimitStates_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLimitStates.CheckedChanged
        If Not bActivated Then Exit Sub
        Try
            Me.Cursor = Cursors.WaitCursor
            LoadDropDowns("", chkLimitStates.Checked)
        Catch ex As Exception
            MsgBox("Error loading collectors:  " & ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
End Class