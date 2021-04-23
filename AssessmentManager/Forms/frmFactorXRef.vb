Public Class frmFactorXRef


    Private bActivated As Boolean
    Private m_FactorEntityId As Long
    Private m_EntityFactorCode As String
    Private m_TaxYear As Integer
    Private m_StateCd As String
    Private m_OldStateFactorCode As String
    Private bChanged As Boolean

    Public Property StateCd() As String
        Get
            Return m_StateCd
        End Get
        Set(ByVal value As String)
            m_StateCd = value
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
    Public Property EntityFactorCode() As String
        Get
            Return m_EntityFactorCode
        End Get
        Set(ByVal value As String)
            m_EntityFactorCode = value
        End Set
    End Property

    Public Property OldStateFactorCode() As String
        Get
            Return M_oldstatefactorcode
        End Get
        Set(ByVal value As String)
            m_oldstatefactorcode = value
        End Set
    End Property


    Private Sub frmGLCodeXref_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If bActivated Then Exit Sub



        RefreshData()

        bActivated = True

    End Sub


    Private Function RefreshData() As Boolean
        Dim sError As String = "", dt As New DataTable, sSQL As String = "", dr As DataRow

        Try
            txtEntityName.Text = "" : txtFactorCode.Text = m_EntityFactorCode : txtStateCd.Text = m_StateCd : cboStateFactorCode.Text = ""
            cboStateFactorCode.Items.Clear() : cboStateFactorCode.Items.Add("")

            sSQL = "SELECT fe.Name, x.StateFactorCode" & _
                " FROM FactorEntities AS fe INNER JOIN" & _
                " FactorEntityCodes AS fec ON fe.FactorEntityId = fec.FactorEntityId LEFT OUTER JOIN" & _
                " FactorCodeXRef AS x ON fec.FactorEntityId = x.FactorEntityId" & _
                " AND fec.FactorCode = x.EntityFactorCode AND fec.TaxYear = x.TaxYear" & _
                " WHERE fec.TaxYear = " & m_TaxYear & " AND fe.FactorEntityId = " & m_FactorEntityId & _
                " AND fec.FactorCode = " & QuoStr(m_EntityFactorCode)
            If GetData(sSQL, dt) > 0 Then
                cboStateFactorCode.Text = UnNullToString(dt.Rows(0).Item("StateFactorCode"))
                Me.Text = "Factoring Entity:  " & dt.Rows(0).Item("Name") & ", Factor Code:  " & m_EntityFactorCode
                txtEntityName.Text = dt.Rows(0).Item("Name")
            End If

            sSQL = "SELECT StateFactorCode FROM StateFactorCodes WHERE StateCd = " & QuoStr(m_StateCd) & _
                " AND TaxYear = " & AppData.TaxYear & " ORDER BY StateFactorCode"
            GetData(sSQL, dt)
            For Each dr In dt.Rows
                cboStateFactorCode.Items.Add(dr("StateFactorCode"))
            Next

            Return True


        Catch ex As Exception
            MsgBox("Error in RefreshData:  " & ex.Message)
            Return False
        End Try
    End Function



    Private Sub cboStateCode_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboStateFactorCode.GotFocus
        sender.selectall()
    End Sub

    Private Sub cboStateCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboStateFactorCode.TextChanged
        If bActivated Then bChanged = True
    End Sub




    Private Sub cboStateCode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboStateFactorCode.LostFocus
        If bChanged Then

            If TypeOf sender Is ComboBox Then

                If sender.SelectedIndex >= 0 Then
                    'DBUpdate(ctlIndex(sender)).PrimaryKeys(1).vValue = QuoStr(sender.text)
                    SaveData(sender.text)
                End If
            Else
                SaveData(sender.text)
            End If
            bChanged = False
        End If

    End Sub


    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub
    Private Function SaveData(ByVal sText As String) As Boolean
        Return AddFactorCodeXRef(m_StateCd, sText, m_FactorEntityId, m_TaxYear, m_EntityFactorCode, m_OldStateFactorCode)
    End Function

  
End Class