Public Class frmFactorCodes

    Private bActivated As Boolean
    Private m_FactorEntityId As Long
    Private m_FactorCode As String
    Private m_Age As Integer
    Private m_TaxYear As Integer

    Private DBUpdate() As typeDBUpdateInfo
    Private bChanged As Boolean
    Public Property Age() As Integer
        Get
            Return m_Age
        End Get
        Set(ByVal value As Integer)
            m_Age = value
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





    Public Property FactorEntityId() As Long
        Get
            Return m_FactorEntityId
        End Get
        Set(ByVal value As Long)
            m_FactorEntityId = value
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

        DBPrimaryKeys(0).sTable = "Factors"
        ReDim DBPrimaryKeys(0).PrimaryKeys(3)
        DBPrimaryKeys(0).PrimaryKeys(0).sField = "FactorEntityId"
        DBPrimaryKeys(0).PrimaryKeys(1).sField = "FactorCode"
        DBPrimaryKeys(0).PrimaryKeys(2).sField = "Age"
        DBPrimaryKeys(0).PrimaryKeys(3).sField = "TaxYear"


        InitControls(Me, DBUpdate, DBPrimaryKeys)
        For l = 0 To UBound(DBUpdate)
            DBUpdate(l).PrimaryKeys(0).vValue = m_FactorEntityId
            DBUpdate(l).PrimaryKeys(1).vValue = QuoStr(m_FactorCode)
            DBUpdate(l).PrimaryKeys(2).vValue = m_Age
            DBUpdate(l).PrimaryKeys(3).vValue = AppData.TaxYear
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
        txtAge.Text = m_Age

        bActivated = True

    End Sub

    Private Function RefreshData() As Boolean
        Dim sError As String = "", dt As New DataTable, sSQL As String = ""

        Try
            txtPercentage.Text = ""

            sSQL = "SELECT Percentage FROM Factors" & _
                " WHERE FactorEntityId = " & m_FactorEntityId & _
                " AND FactorCode = " & QuoStr(m_FactorCode) & _
                " AND Age = " & m_Age & _
                " AND TaxYear = " & m_TaxYear
            GetData(sSQL, dt)
            RefreshControls(Me, dt, "Factors")

            Return True

        Catch ex As Exception
            MsgBox("Error in RefreshData:  " & ex.Message)
            Return False
        End Try
    End Function



    Private Sub txtPercentage_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPercentage.GotFocus
        sender.selectall()
    End Sub

    Private Sub txtPercentage_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPercentage.LostFocus
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

    Private Sub txtPercentage_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPercentage.TextChanged
        If bActivated Then bChanged = True
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        Try
            Dim sSQL As String = "delete Factors where FactorEntityId = " & m_FactorEntityId & _
                " AND FactorCode = " & QuoStr(m_FactorCode) & " AND TaxYear = " & AppData.TaxYear & _
                " AND Age = " & m_Age
            ExecuteSQL(sSQL)
            Me.Close()
        Catch ex As Exception
            MsgBox("Error deleting:  " & ex.Message)
        End Try
    End Sub

End Class