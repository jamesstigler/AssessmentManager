Public Class frmTask
    Private bActivated As Boolean
    Private m_TaskId As Long
    Private DBUpdate() As typeDBUpdateInfo
    Private bChanged As Boolean

    Public Property TaskId() As Long
        Get
            Return m_TaskId
        End Get
        Set(ByVal value As Long)
            m_TaskId = value
        End Set
    End Property

    Private Sub InitInfo()
        Dim DBPrimaryKeys(0) As typeDBUpdateInfo, l As Long

        DBPrimaryKeys(0).sTable = "TaskMasterList"
        ReDim DBPrimaryKeys(0).PrimaryKeys(0)
        DBPrimaryKeys(0).PrimaryKeys(0).sField = "TaskId"

        InitControls(Me, DBUpdate, DBPrimaryKeys)
        For l = 0 To UBound(DBUpdate)
            DBUpdate(l).PrimaryKeys(0).vValue = m_TaskId
        Next


    End Sub


    Private Sub frmTask_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If bActivated Then Exit Sub

        InitInfo()
        RefreshData()

        bActivated = True
    End Sub

    Private Function RefreshData() As Boolean
        Dim sError As String = "", dt As DataTable, sSQL As String, dr As DataRow

        Try


            sSQL = "SELECT * FROM TaskMasterList" & _
                " WHERE TaskId = " & m_TaskId
            GetData(sSQL, dt)
            RefreshControls(Me, dt, "TaskMasterList")

            Return True

        Catch ex As Exception
            MsgBox("Error in RefreshData:  " & ex.Message)
            Return False
        End Try
    End Function



    Private Sub txtName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles txtName.LostFocus,
            txtDescription.LostFocus
        If bChanged Then

            If TypeOf sender Is ComboBox Then
                'If sender.name = cboStateCd.Name Then
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
            Handles txtDescription.GotFocus,
            txtName.GotFocus
        sender.selectall()
    End Sub

    Private Sub txtName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles txtName.TextChanged, txtDescription.TextChanged
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


End Class