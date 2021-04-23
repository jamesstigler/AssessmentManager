Public Class frmImportRECompsCounty
    Public Property AssessorId() As Long
    Public Property AssessorName() As String

    Private Sub cmdBrowse_Click(sender As Object, e As EventArgs) Handles cmdBrowse.Click
        txtFolder.Text = SelectFolder("RECompsCounty")
        If txtFolder.Text.Trim <> "" Then cmdNext.Enabled = True Else cmdNext.Enabled = False
    End Sub
    Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdFinish_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdFinish.Click
        Dim sError As String = ""

        MDIParent1.ShowStatus("Saving data")
        Me.Cursor = Cursors.WaitCursor
        InsertComps(sError)
        MDIParent1.ShowStatus()
        Me.Cursor = Cursors.Default
        If sError = "" Then
            MsgBox("Import complete")
            Me.Close()
        Else
            MsgBox("Error importing:  " & sError)
        End If
    End Sub
    Private Sub cmdNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdNext.Click
        If fraFile.Visible Then
            If ValidateFolder Then
                fraFile.Visible = False
                cmdBack.Enabled = True
                cmdFinish.Enabled=True
            End If
        End If
    End Sub
    Private Function ValidateFolder() As Boolean
        Try
            If txtFolder.Text.Trim = "" Then
                MsgBox("Please select folder")
                Return False
            End If
            Dim sFolder As String = txtFolder.Text.Trim.ToLower
            Dim files() As String = System.IO.Directory.GetFiles(sFolder)

            For Each s As String In files
                s = s.Trim.ToLower
            Next
            If files.Contains(IO.Path.Combine(sFolder, "abatement_exempt.csv")) And files.Contains(IO.Path.Combine(sFolder, "account_apprl_year.csv")) And
                    files.Contains(IO.Path.Combine(sFolder, "account_info.csv")) And files.Contains(IO.Path.Combine(sFolder, "acct_exempt_value.csv")) And
                    files.Contains(IO.Path.Combine(sFolder, "com_detail.csv")) And
                    files.Contains(IO.Path.Combine(sFolder, "land.csv")) Then
                Return True
            Else
                MsgBox("Appropriate files do not exist")
                Return False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function
    Private Sub cmdBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdBack.Click
        If fraResults.Visible Then
            fraResults.Visible = False
            fraFile.Visible = False
            cmdFinish.Enabled = False
            cmdNext.Enabled = True
        Else
            fraFile.Visible = True
            'fraColumns.Visible = False
        End If

    End Sub

    Private Sub frmImportRECompsCounty_Load(sender As Object, e As EventArgs) Handles Me.Load
        fraResults.Left = fraFile.Left
        fraResults.Top = fraFile.Top
    End Sub

    Private Sub frmImportRECompsCounty_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Dim Buttons(3) As Control

        Buttons(0) = cmdBack
        Buttons(1) = cmdNext
        Buttons(2) = cmdFinish
        Buttons(3) = cmdCancel
        PlaceButtons(Me, Buttons)

        If Me.WindowState = FormWindowState.Minimized Then Exit Sub
        fraFile.Width = Me.Width - 30
        fraFile.Height = Me.Height - 80
        fraResults.Width = fraFile.Width
        fraResults.Height = fraFile.Height
    End Sub
    Private Function InsertComps(ByRef sError As String) As Boolean
        Try
            Dim sql As String, sFolder As String = txtFolder.Text
            Dim lRows As Long
            Dim sWITH As String = " WITH(FIRSTROW=2, ROWTERMINATOR = '\n', FIELDTERMINATOR = ',', FORMAT = 'csv')"

            MDIParent1.ShowStatus("Deleting old data:  table 1 of 6")
            sql = "TRUNCATE TABLE DCAD..abatement_exempt"
            ExecuteSQL(sql.ToString)
            System.Threading.Thread.Sleep(2000)

            MDIParent1.ShowStatus("Deleting old data:  table 2 of 6")
            sql = "TRUNCATE TABLE DCAD..account_apprl_year"
            ExecuteSQL(sql.ToString)
            System.Threading.Thread.Sleep(2000)

            MDIParent1.ShowStatus("Deleting old data:  table 3 of 6")
            sql = "TRUNCATE TABLE DCAD..account_info"
            ExecuteSQL(sql.ToString)
            System.Threading.Thread.Sleep(2000)

            MDIParent1.ShowStatus("Deleting old data:  table 4 of 6")
            sql = "TRUNCATE TABLE DCAD..acct_exempt_value"
            ExecuteSQL(sql.ToString)
            System.Threading.Thread.Sleep(2000)

            MDIParent1.ShowStatus("Deleting old data:  table 5 of 6")
            sql = "TRUNCATE TABLE DCAD..com_detail"
            ExecuteSQL(sql.ToString)
            System.Threading.Thread.Sleep(2000)

            MDIParent1.ShowStatus("Deleting old data:  table 6 of 6")
            sql = "TRUNCATE TABLE DCAD..land"
            ExecuteSQL(sql.ToString)

            MDIParent1.ShowStatus("Loading new data from .CSV files, file 1 of 6")
            sql = "BULK INSERT DCAD..abatement_exempt FROM " & QuoStr(IO.Path.Combine(sFolder, "abatement_exempt.csv")) & sWITH
            ExecuteSQL(sql.ToString)
            System.Threading.Thread.Sleep(2000)

            MDIParent1.ShowStatus("Loading new data from .CSV files, file 2 of 6")
            sql = "BULK INSERT DCAD..account_apprl_year FROM " & QuoStr(IO.Path.Combine(sFolder, "account_apprl_year.csv")) & sWITH
            ExecuteSQL(sql.ToString)
            System.Threading.Thread.Sleep(2000)

            MDIParent1.ShowStatus("Loading new data from .CSV files, file 3 of 6")
            sql = "BULK INSERT DCAD..account_info FROM " & QuoStr(IO.Path.Combine(sFolder, "account_info.csv")) & sWITH
            ExecuteSQL(sql.ToString)
            System.Threading.Thread.Sleep(2000)

            MDIParent1.ShowStatus("Loading new data from .CSV files, file 4 of 6")
            sql = "BULK INSERT DCAD..acct_exempt_value FROM " & QuoStr(IO.Path.Combine(sFolder, "acct_exempt_value.csv")) & sWITH
            ExecuteSQL(sql.ToString)
            System.Threading.Thread.Sleep(2000)

            MDIParent1.ShowStatus("Loading new data from .CSV files, file 5 of 6")
            sql = "BULK INSERT DCAD..com_detail FROM " & QuoStr(IO.Path.Combine(sFolder, "com_detail.csv")) & sWITH
            ExecuteSQL(sql.ToString)
            System.Threading.Thread.Sleep(2000)

            MDIParent1.ShowStatus("Loading new data from .CSV files, file 6 of 6")
            sql = "BULK INSERT DCAD..land FROM " & QuoStr(IO.Path.Combine(sFolder, "land.csv")) & sWITH
            ExecuteSQL(sql)

            MDIParent1.ShowStatus("County .CSV files loaded.  Now loading into RE Comp database")
            sql = "EXEC DCAD..spUpdateREComps @AssessorId=" & AssessorId & ",@Threshhold=" & Convert.ToDouble(txtThreshhold.Text) & ",@TaxYear=" & AppData.TaxYear & ",@AddUser=" & QuoStr(AppData.UserId)
            lRows = ExecuteSQL(sql)
            MDIParent1.ShowStatus("Loaded " & lRows.ToString(csInt) & " accounts.  Now loading RE Comp Codes")
            sql = "EXEC spUpdateRECompCodes @AssessorId=" & AssessorId & ", @TaxYear=" & AppData.TaxYear & ",@AddUser=" & QuoStr(AppData.UserId)
            ExecuteSQL(sql)

            MDIParent1.ShowStatus()

            'BULK INSERT land FROM 'C:\MyFiles\VantageOne\HCAD\DCAD\land.csv'
            'WITH(FIRSTROW=2 ROWTERMINATOR = '\n', FIELDTERMINATOR = ',', format = 'csv')
            '")


            Return True
        Catch ex As Exception
            sError = ex.Message
            Return False
        End Try
    End Function
End Class