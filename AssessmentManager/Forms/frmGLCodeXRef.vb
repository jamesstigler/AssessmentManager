Public Class frmGLCodeXRef

    Private bActivated As Boolean
    Private m_ClientId As Long
    Private m_GLCode As String
    Private m_FactorEntityId As Long
    Private m_StateCd As String
    Private m_TaxYear As Integer

    Private DBUpdate() As typeDBUpdateInfo
    Private bChanged As Boolean

    Public Property ClientId() As Long
        Get
            Return m_ClientId
        End Get
        Set(ByVal value As Long)
            m_ClientId = value
        End Set
    End Property
    Public Property StateCd() As String
        Get
            Return m_StateCd
        End Get
        Set(ByVal value As String)
            m_StateCd = value
        End Set
    End Property
    Public Property GLCode() As String
        Get
            Return m_GLCode
        End Get
        Set(ByVal value As String)
            m_GLCode = value
        End Set
    End Property
    Public Property FactoringEntityId() As Long
        Get
            Return m_FactorEntityId
        End Get
        Set(ByVal value As Long)
            m_FactorEntityId = value
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

        DBPrimaryKeys(0).sTable = "ClientGLCodeXRef"
        DBPrimaryKeys(0).bAllowInsert = True
        ReDim DBPrimaryKeys(0).PrimaryKeys(4)
        DBPrimaryKeys(0).PrimaryKeys(0).sField = "ClientId"
        DBPrimaryKeys(0).PrimaryKeys(1).sField = "StateCd"
        DBPrimaryKeys(0).PrimaryKeys(2).sField = "GLCode"
        DBPrimaryKeys(0).PrimaryKeys(3).sField = "TaxYear"
        DBPrimaryKeys(0).PrimaryKeys(4).sField = "FactorEntityId"


        InitControls(Me, DBUpdate, DBPrimaryKeys)
        For l = 0 To UBound(DBUpdate)
            DBUpdate(l).PrimaryKeys(0).vValue = m_ClientId
            DBUpdate(l).PrimaryKeys(1).vValue = QuoStr(m_StateCd)
            DBUpdate(l).PrimaryKeys(2).vValue = QuoStr(m_GLCode)
            DBUpdate(l).PrimaryKeys(3).vValue = AppData.TaxYear
            DBUpdate(l).PrimaryKeys(4).vValue = m_FactorEntityId
            DBUpdate(l).bAllowInsert = True
        Next




    End Sub

    Private Sub frmGLCodeXref_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If bActivated Then Exit Sub



        InitInfo()
        RefreshData()

        bActivated = True

    End Sub


    Private Function RefreshData() As Boolean
        Dim sError As String = "", dt As New DataTable, sSQL As String = "", dr As DataRow

        Try
            txtClientName.Text = "" : txtGLCode.Text = m_GLCode : txtStateCd.Text = m_StateCd : cboFactorCode.Text = ""
            txtEntity.Text = ""
            cboFactorCode.Items.Clear() : cboFactorCode.Items.Add("")

            sSQL = "SELECT c.Name AS ClientName," & _
                " ISNULL((SELECT cx.FactorCode FROM ClientGLCodeXRef cx WHERE cx.ClientId = " & m_ClientId & _
                " AND cx.StateCd = " & QuoStr(m_StateCd) & " AND cx.GLCode = " & QuoStr(m_GLCode) & _
                " AND cx.TaxYear = " & m_TaxYear & " AND cx.FactorEntityId = " & m_FactorEntityId & "),'') AS FactorCode," & _
                " ISNULL((SELECT fe.Name FROM FactorEntities fe WHERE fe.FactorEntityId = " & m_FactorEntityId & "),'') AS EntityName" & _
                " FROM Clients AS c WHERE c.ClientId = " & m_ClientId
            GetData(sSQL, dt)
            cboFactorCode.Text = UnNullToString(dt.Rows(0).Item("FactorCode"))
            Me.Text = "Client:  " & dt.Rows(0).Item("ClientName") & ", " & dt.Rows(0).Item("EntityName") & ", G/L Code:  " & m_GLCode
            txtClientName.Text = dt.Rows(0).Item("ClientName")
            txtEntity.Text = dt.Rows(0).Item("EntityName")

            sSQL = "SELECT FactorCode FROM FactorEntityCodes WHERE FactorEntityId = " & m_FactorEntityId &
                " AND TaxYear = " & m_TaxYear & " AND ISNULL(InactiveFl,0) = 0 ORDER BY FactorCode"
            GetData(sSQL, dt)
            For Each dr In dt.Rows
                cboFactorCode.Items.Add(dr("FactorCode"))
            Next

            Return True


        Catch ex As Exception
            MsgBox("Error in RefreshData:  " & ex.Message)
            Return False
        End Try
    End Function



    Private Sub cboFactorCode_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFactorCode.GotFocus
        sender.selectall()
    End Sub

    Private Sub cboFactorCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFactorCode.TextChanged
        If bActivated Then bChanged = True
    End Sub




    Private Sub cboFactorCode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFactorCode.LostFocus
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


    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

End Class