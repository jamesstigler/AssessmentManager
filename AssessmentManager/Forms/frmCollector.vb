Public Class frmCollector
    Private bActivated As Boolean
    Private m_CollectorId As Long
    Private m_TaxYear As Integer
    Private DBUpdate() As typeDBUpdateInfo
    Private bChanged As Boolean

    Public Property CollectorId() As Long
        Get
            Return m_CollectorId
        End Get
        Set(ByVal value As Long)
            m_CollectorId = value
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

        DBPrimaryKeys(0).sTable = "Collectors"
        ReDim DBPrimaryKeys(0).PrimaryKeys(1)
        DBPrimaryKeys(0).PrimaryKeys(0).sField = "CollectorId"
        DBPrimaryKeys(0).PrimaryKeys(1).sField = "TaxYear"

        InitControls(Me, DBUpdate, DBPrimaryKeys)
        For l = 0 To UBound(DBUpdate)
            DBUpdate(l).PrimaryKeys(0).vValue = m_CollectorId
            DBUpdate(l).PrimaryKeys(1).vValue = m_TaxYear
        Next


    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub frmCollector_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        If bActivated Then Exit Sub

        InitInfo()
        RefreshData()

        bActivated = True
    End Sub

    Private Function RefreshData() As Boolean
        Dim sError As String = "", dt As New DataTable, sSQL As String = ""

        Try
            sSQL = "SELECT * FROM Collectors" & _
                " WHERE CollectorId = " & m_CollectorId & _
                " AND TaxYear = " & m_TaxYear
            GetData(sSQL, dt)
            RefreshControls(Me, dt, "Collectors")
            If dt.Rows.Count > 0 Then
                Me.Text = "Collector:  " & dt.Rows(0)("Name") & ", " & dt.Rows(0)("StateCd")
            End If

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
            Handles txtName.LostFocus, txtAddress.LostFocus, txtCity.LostFocus, txtZip.LostFocus, _
            txtComment.LostFocus, cboPayeeStateCd.LostFocus, TextBox1.LostFocus, TextBox3.LostFocus, txtPhone.LostFocus, _
            txtFax.LostFocus, txtPercentage.LostFocus, TextBox2.LostFocus, TextBox4.LostFocus, TextBox5.LostFocus, _
            chkAddressCorrectFl.LostFocus, chkDiscountFl.LostFocus, TextBox6.LostFocus, TextBox7.LostFocus, _
            TextBox8.LostFocus, TextBox9.LostFocus, TextBox10.LostFocus, TextBox11.LostFocus, TextBox12.LostFocus, _
            TextBox13.LostFocus, TextBox14.LostFocus, TextBox15.LostFocus, cboStateCd.LostFocus
        If bChanged Then
            If TypeOf sender Is ComboBox Then
                If sender.SelectedIndex >= 0 Then
                    UpdateDB(sender, DBUpdate)
                End If
            Else
                UpdateDB(sender, DBUpdate)
            End If
            bChanged = False
        End If
    End Sub

    Private Sub txtAddress_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles txtAddress.GotFocus, txtCity.GotFocus, txtZip.GotFocus, txtComment.GotFocus, _
            txtName.GotFocus, txtZip.GotFocus, TextBox1.GotFocus, TextBox3.GotFocus, _
            txtFax.GotFocus, txtPercentage.GotFocus, txtPhone.GotFocus, _
            TextBox2.GotFocus, TextBox4.GotFocus, TextBox5.GotFocus, TextBox6.GotFocus, TextBox7.GotFocus, _
            TextBox8.GotFocus, TextBox9.GotFocus, TextBox10.GotFocus, TextBox11.GotFocus, TextBox12.GotFocus, _
            TextBox13.GotFocus, TextBox14.GotFocus, TextBox15.GotFocus
        sender.selectall()
    End Sub

    Private Sub txtName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles txtName.TextChanged, txtAddress.TextChanged, txtCity.TextChanged, txtComment.TextChanged, _
            txtZip.TextChanged, cboPayeeStateCd.TextChanged, TextBox1.TextChanged, TextBox3.TextChanged, _
            txtFax.TextChanged, txtPercentage.TextChanged, txtPhone.TextChanged, _
            TextBox2.TextChanged, TextBox4.TextChanged, TextBox5.TextChanged, _
            chkAddressCorrectFl.CheckedChanged, chkDiscountFl.CheckedChanged, _
            TextBox6.TextChanged, TextBox7.TextChanged, _
            TextBox8.TextChanged, TextBox9.TextChanged, TextBox10.TextChanged, TextBox11.TextChanged, TextBox12.TextChanged, _
            TextBox13.TextChanged, TextBox14.TextChanged, TextBox15.TextChanged, cboStateCd.TextChanged
        If bActivated Then bChanged = True
    End Sub


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub frm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        bActivated = False
        bChanged = False
    End Sub

End Class