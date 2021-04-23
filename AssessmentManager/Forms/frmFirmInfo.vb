Public Class frmFirmInfo
    Private bActivated As Boolean
    Private DBUpdate() As typeDBUpdateInfo
    Private bChanged As Boolean
    Private bAnythingChanged As Boolean = False

    Private Sub InitInfo()
        Dim DBPrimaryKeys(0) As typeDBUpdateInfo, l As Long

        DBPrimaryKeys(0).sTable = "FirmInfo"
        ReDim DBPrimaryKeys(0).PrimaryKeys(0)
        DBPrimaryKeys(0).PrimaryKeys(0).sField = "Name"

        InitControls(Me, DBUpdate, DBPrimaryKeys)
        For l = 0 To UBound(DBUpdate)
            DBUpdate(l).PrimaryKeys(0).vValue = QuoStr(AppData.FirmName)
        Next

    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub frmFirmInfo_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If bActivated Then Exit Sub

        InitInfo()
        RefreshData()

        bActivated = True
    End Sub

    Private Function RefreshData() As Boolean
        Dim sError As String = "", dt As New DataTable, sSQL As String, dr As DataRow

        Try
            sSQL = "SELECT * FROM FirmInfo"
            GetData(sSQL, dt)
            RefreshControls(Me, dt, "FirmInfo")
            Return True
        Catch ex As Exception
            MsgBox("Error in RefreshData:  " & ex.Message)
            Return False
        End Try
    End Function
    Private Sub txtName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles txtAddress.LostFocus, txtCity.LostFocus, txtZip.LostFocus, _
                cboStateCd.LostFocus, TextBox3.LostFocus, txtPhone.LostFocus, _
                txtFax.LostFocus
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
            Handles txtAddress.GotFocus, txtCity.GotFocus, txtZip.GotFocus, _
             txtZip.GotFocus, TextBox3.GotFocus, _
            txtFax.GotFocus, txtPhone.GotFocus
        sender.selectall()
    End Sub

    Private Sub txtName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles txtAddress.TextChanged, txtCity.TextChanged, _
            txtZip.TextChanged, cboStateCd.TextChanged, TextBox3.TextChanged, _
            txtFax.TextChanged, txtPhone.TextChanged
        If bActivated Then
            bChanged = True
            bAnythingChanged = True
        End If
    End Sub


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub frmFirmInfo_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If bAnythingChanged Then
            MsgBox("Must restart application for changes to take effect")
        End If
    End Sub

    Private Sub frm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        bActivated = False
        bChanged = False
        bAnythingChanged = False
    End Sub
End Class