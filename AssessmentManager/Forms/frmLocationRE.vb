Public Class frmLocationRE
    Private bActivated As Boolean
    Private clsLocation As New clsLocationRE
    Private m_ClientId As Long
    Private m_LocationId As Long
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
    Public Property LocationId() As Long
        Get
            Return m_LocationId
        End Get
        Set(ByVal value As Long)
            m_LocationId = value
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

        DBPrimaryKeys(0).sTable = "LocationsRE"
        ReDim DBPrimaryKeys(0).PrimaryKeys(2)
        DBPrimaryKeys(0).PrimaryKeys(0).sField = "ClientId"
        DBPrimaryKeys(0).PrimaryKeys(1).sField = "LocationId"
        DBPrimaryKeys(0).PrimaryKeys(2).sField = "TaxYear"

        InitControls(Me, DBUpdate, DBPrimaryKeys)
        For l = 0 To UBound(DBUpdate)
            DBUpdate(l).PrimaryKeys(0).vValue = m_ClientId
            DBUpdate(l).PrimaryKeys(1).vValue = m_LocationId
            DBUpdate(l).PrimaryKeys(2).vValue = m_TaxYear
        Next


    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub frmLocationRE_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If bActivated Then Exit Sub

        InitInfo()
        OpenLocation()

        bActivated = True
    End Sub



    Private Function OpenLocation() As Boolean
        Dim sError As String = ""

        Try
            clsLocation.ClientId = m_ClientId
            clsLocation.LocationId = m_LocationId
            clsLocation.TaxYear = m_TaxYear
            clsLocation.OpenLocation(sError)

            Me.Text = "Real Estate Location:  " & clsLocation.Address & "   " & clsLocation.City & ", " & clsLocation.StateCd
            RefreshControls(Me, clsLocation.ResultSet, "LocationsRE")
            Return True


        Catch ex As Exception
            MsgBox("Error in OpenLocation:  " & ex.Message)
            Return False
        End Try
    End Function

    Private Sub txtName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles txtName.LostFocus, txtAddress.LostFocus, txtCity.LostFocus, txtZip.LostFocus, _
            txtComment.LostFocus, cboStateCd.LostFocus, TextBox1.LostFocus, TextBox2.LostFocus, TextBox3.LostFocus, chkInactiveFl.LostFocus, _
            cboConsultant.LostFocus
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
            txtName.GotFocus, txtZip.GotFocus, TextBox1.GotFocus, TextBox2.GotFocus, TextBox3.GotFocus
        sender.selectall()
    End Sub

    Private Sub txtName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles txtName.TextChanged, txtAddress.TextChanged, txtCity.TextChanged, txtComment.TextChanged, _
            txtZip.TextChanged, cboStateCd.TextChanged, TextBox1.TextChanged, TextBox2.TextChanged, TextBox3.TextChanged, chkInactiveFl.CheckedChanged, _
            cboConsultant.TextChanged
        If bActivated Then
            If sender.name = chkInactiveFl.Name Then
                If sender.checkstate = CheckState.Checked Then
                    If MsgBox("Ok to deactivate location?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        bChanged = True
                    End If
                Else
                    bChanged = True
                End If
            Else
                bChanged = True
            End If
        End If
    End Sub


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub



    Private Sub frmLocationRE_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        bActivated = False
        bChanged = False
    End Sub
End Class