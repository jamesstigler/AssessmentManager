Public Class frmAssessor
    Private bActivated As Boolean
    Private m_AssessorId As Long
    Private m_TaxYear As Integer
    Private DBUpdate() As typeDBUpdateInfo
    Private bChanged As Boolean

    Public Property AssessorId() As Long
        Get
            Return m_AssessorId
        End Get
        Set(ByVal value As Long)
            m_AssessorId = value
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

        DBPrimaryKeys(0).sTable = "Assessors"
        ReDim DBPrimaryKeys(0).PrimaryKeys(1)
        DBPrimaryKeys(0).PrimaryKeys(0).sField = "AssessorId"
        DBPrimaryKeys(0).PrimaryKeys(1).sField = "TaxYear"

        InitControls(Me, DBUpdate, DBPrimaryKeys)
        For l = 0 To UBound(DBUpdate)
            DBUpdate(l).PrimaryKeys(0).vValue = m_AssessorId
            DBUpdate(l).PrimaryKeys(1).vValue = m_TaxYear
        Next


    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub frmBPPLocation_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If bActivated Then Exit Sub

        InitInfo()
        RefreshData()

        bActivated = True
    End Sub

    Private Function RefreshData() As Boolean
        Dim sError As String = "", dt As New DataTable, sSQL As String

        Try

            sSQL = "SELECT * FROM Assessors" & _
                " WHERE AssessorId = " & m_AssessorId & _
                " AND TaxYear = " & m_TaxYear
            If GetData(sSQL, dt) > 0 Then
                Me.Text = m_TaxYear & " " & "Assessor:  " & dt.Rows(0)("Name") & ", " & dt.Rows(0)("StateCd")
            End If
            RefreshControls(Me, dt, "Assessors")

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
            txtComment.LostFocus, cboStateCd.LostFocus, TextBox1.LostFocus, TextBox3.LostFocus, txtPhone.LostFocus, _
            txtFax.LostFocus, TextBox4.LostFocus, txtPercentage.LostFocus, TextBox2.LostFocus, TextBox5.LostFocus, _
            TextBox6.LostFocus, TextBox7.LostFocus, TextBox8.LostFocus, TextBox9.LostFocus
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
            Handles txtAddress.GotFocus, txtCity.GotFocus, txtZip.GotFocus, txtComment.GotFocus, _
            txtName.GotFocus, txtZip.GotFocus, TextBox1.GotFocus, TextBox4.GotFocus, TextBox3.GotFocus, _
            txtFax.GotFocus, txtPercentage.GotFocus, txtPhone.GotFocus, TextBox2.GotFocus, TextBox5.GotFocus, _
            TextBox6.GotFocus, TextBox7.GotFocus, TextBox8.GotFocus, TextBox9.GotFocus
        sender.selectall()
    End Sub

    Private Sub txtName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles txtName.TextChanged, txtAddress.TextChanged, txtCity.TextChanged, txtComment.TextChanged, _
            txtZip.TextChanged, cboStateCd.TextChanged, TextBox1.TextChanged, TextBox4.TextChanged, TextBox3.TextChanged, _
            txtFax.TextChanged, txtPercentage.TextChanged, txtPhone.TextChanged, TextBox2.TextChanged, TextBox5.TextChanged, _
            TextBox6.TextChanged, TextBox7.TextChanged, TextBox8.TextChanged, TextBox9.TextChanged
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


    Private Sub cmdEnvelope_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnvelope.Click
        Dim lList As New List(Of Long)
        RunReport(enumReport.enumAssessorEnvelope, 0, 0, 0, lList, AppData.TaxYear, enumTable.enumLocationBPP, m_AssessorId, 0, True, m_AssessorId, "")
    End Sub

End Class