Public Class frmStateFactorCodes

    Private bActivated As Boolean
    Private m_StateCd As String
    Private m_FactorCode As String
    Private DBUpdate() As typeDBUpdateInfo
    Private bChanged As Boolean







    Public Property StateCd() As String
        Get
            Return m_StateCd
        End Get
        Set(ByVal value As String)
            m_StateCd = value
        End Set
    End Property
    Public Property FactorCode() As String
        Get
            Return m_FactorCode
        End Get
        Set(ByVal value As String)
            m_FactorCode = value
        End Set
    End Property

    Private Sub InitInfo()
        Dim DBPrimaryKeys(0) As typeDBUpdateInfo, l As Long

        DBPrimaryKeys(0).sTable = "StateFactorCodes"
        ReDim DBPrimaryKeys(0).PrimaryKeys(2)
        DBPrimaryKeys(0).PrimaryKeys(0).sField = "StateCd"
        DBPrimaryKeys(0).PrimaryKeys(1).sField = "StateFactorCode"
        DBPrimaryKeys(0).PrimaryKeys(2).sField = "TaxYear"


        InitControls(Me, DBUpdate, DBPrimaryKeys)
        For l = 0 To UBound(DBUpdate)
            DBUpdate(l).PrimaryKeys(0).vValue = QuoStr(m_StateCd)
            DBUpdate(l).PrimaryKeys(1).vValue = QuoStr(m_FactorCode)
            DBUpdate(l).PrimaryKeys(2).vValue = AppData.TaxYear
        Next




    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub frmStateFactorCodes_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If bActivated Then Exit Sub



        InitInfo()
        RefreshData()
        txtFactorCode.Text = m_FactorCode
        txtStateCd.Text = m_StateCd

        bActivated = True

    End Sub

    Private Function RefreshData() As Boolean
        Dim sError As String = "", dt As DataTable, sSQL As String, dr As DataRow

        Try
            txtDescription.Text = "" : txtName.Text = ""

            sSQL = "SELECT Name, Description FROM StateFactorCodes" & _
                " WHERE StateCd = " & QuoStr(m_StateCd) & _
                " AND StateFactorCode = " & QuoStr(m_FactorCode) & _
                " AND TaxYear = " & AppData.TaxYear
            GetData(sSQL, dt)
            txtName.Text = UnNullToString(dt.Rows(0).Item("Name"))
            txtDescription.Text = UnNullToString(dt.Rows(0).Item("Description"))

            Return True

        Catch ex As Exception
            MsgBox("Error in RefreshData:  " & ex.Message)
            Return False
        End Try
    End Function


    Private Sub frmStateFactorCodes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtDescription_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDescription.GotFocus, txtName.GotFocus
        sender.selectall()
    End Sub

    Private Sub txtDescription_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDescription.LostFocus, txtName.LostFocus
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

    Private Sub txtDescription_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDescription.TextChanged, txtName.TextChanged
        If bActivated Then bChanged = True
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        Try
            Dim sSQL As String = "delete StateFactorCodes where StateCd = " & QuoStr(m_StateCd) & " AND StateFactorCode = " & QuoStr(m_FactorCode) & " AND TaxYear = " & AppData.TaxYear
            ExecuteSQL(sSQL)
            Me.Close()
        Catch ex As Exception
            MsgBox("Error deleting:  " & ex.Message)
        End Try
    End Sub
End Class