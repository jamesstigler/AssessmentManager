<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportAssets
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.fraFile = New System.Windows.Forms.GroupBox()
        Me.cmdBrowse = New System.Windows.Forms.Button()
        Me.txtFile = New System.Windows.Forms.TextBox()
        Me.radioImportDeletions = New System.Windows.Forms.RadioButton()
        Me.radioImportAdditions = New System.Windows.Forms.RadioButton()
        Me.radioImportComplete = New System.Windows.Forms.RadioButton()
        Me.cmdNext = New System.Windows.Forms.Button()
        Me.cmdFinish = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdBack = New System.Windows.Forms.Button()
        Me.fraColumns = New System.Windows.Forms.GroupBox()
        Me.dgFileContents = New System.Windows.Forms.DataGridView()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cboAllocationPct = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cboVIN = New System.Windows.Forms.ComboBox()
        Me.cboAddress = New System.Windows.Forms.ComboBox()
        Me.txtDisposedValue = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboDisposed = New System.Windows.Forms.ComboBox()
        Me.optMultiple = New System.Windows.Forms.RadioButton()
        Me.optSingle = New System.Windows.Forms.RadioButton()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboPurchaseDate = New System.Windows.Forms.ComboBox()
        Me.cboDescription = New System.Windows.Forms.ComboBox()
        Me.cboMonth = New System.Windows.Forms.ComboBox()
        Me.cboYear = New System.Windows.Forms.ComboBox()
        Me.cboDay = New System.Windows.Forms.ComboBox()
        Me.cboGLCode = New System.Windows.Forms.ComboBox()
        Me.cboAssetId = New System.Windows.Forms.ComboBox()
        Me.cboCost = New System.Windows.Forms.ComboBox()
        Me.fraResults = New System.Windows.Forms.GroupBox()
        Me.lblTotals = New System.Windows.Forms.Label()
        Me.dgResults = New System.Windows.Forms.DataGridView()
        Me.cmdPrint = New System.Windows.Forms.Button()
        Me.fraFile.SuspendLayout()
        Me.fraColumns.SuspendLayout()
        CType(Me.dgFileContents, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraResults.SuspendLayout()
        CType(Me.dgResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fraFile
        '
        Me.fraFile.AutoSize = True
        Me.fraFile.Controls.Add(Me.cmdBrowse)
        Me.fraFile.Controls.Add(Me.txtFile)
        Me.fraFile.Controls.Add(Me.radioImportDeletions)
        Me.fraFile.Controls.Add(Me.radioImportAdditions)
        Me.fraFile.Controls.Add(Me.radioImportComplete)
        Me.fraFile.Location = New System.Drawing.Point(12, 12)
        Me.fraFile.Name = "fraFile"
        Me.fraFile.Size = New System.Drawing.Size(585, 127)
        Me.fraFile.TabIndex = 5
        Me.fraFile.TabStop = False
        '
        'cmdBrowse
        '
        Me.cmdBrowse.Location = New System.Drawing.Point(10, 85)
        Me.cmdBrowse.Name = "cmdBrowse"
        Me.cmdBrowse.Size = New System.Drawing.Size(75, 23)
        Me.cmdBrowse.TabIndex = 9
        Me.cmdBrowse.Text = "Browse"
        Me.cmdBrowse.UseVisualStyleBackColor = True
        '
        'txtFile
        '
        Me.txtFile.Location = New System.Drawing.Point(91, 87)
        Me.txtFile.Name = "txtFile"
        Me.txtFile.Size = New System.Drawing.Size(488, 20)
        Me.txtFile.TabIndex = 8
        '
        'radioImportDeletions
        '
        Me.radioImportDeletions.AutoSize = True
        Me.radioImportDeletions.Location = New System.Drawing.Point(10, 62)
        Me.radioImportDeletions.Name = "radioImportDeletions"
        Me.radioImportDeletions.Size = New System.Drawing.Size(99, 17)
        Me.radioImportDeletions.TabIndex = 7
        Me.radioImportDeletions.Text = "Import deletions"
        Me.radioImportDeletions.UseVisualStyleBackColor = True
        '
        'radioImportAdditions
        '
        Me.radioImportAdditions.AutoSize = True
        Me.radioImportAdditions.Location = New System.Drawing.Point(10, 39)
        Me.radioImportAdditions.Name = "radioImportAdditions"
        Me.radioImportAdditions.Size = New System.Drawing.Size(99, 17)
        Me.radioImportAdditions.TabIndex = 6
        Me.radioImportAdditions.Text = "Import additions"
        Me.radioImportAdditions.UseVisualStyleBackColor = True
        '
        'radioImportComplete
        '
        Me.radioImportComplete.AutoSize = True
        Me.radioImportComplete.Checked = True
        Me.radioImportComplete.Location = New System.Drawing.Point(10, 16)
        Me.radioImportComplete.Name = "radioImportComplete"
        Me.radioImportComplete.Size = New System.Drawing.Size(160, 17)
        Me.radioImportComplete.TabIndex = 5
        Me.radioImportComplete.TabStop = True
        Me.radioImportComplete.Text = "Import complete list of assets"
        Me.radioImportComplete.UseVisualStyleBackColor = True
        '
        'cmdNext
        '
        Me.cmdNext.Enabled = False
        Me.cmdNext.Location = New System.Drawing.Point(239, 471)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(75, 23)
        Me.cmdNext.TabIndex = 19
        Me.cmdNext.Text = "Next"
        Me.cmdNext.UseVisualStyleBackColor = True
        '
        'cmdFinish
        '
        Me.cmdFinish.Enabled = False
        Me.cmdFinish.Location = New System.Drawing.Point(401, 471)
        Me.cmdFinish.Name = "cmdFinish"
        Me.cmdFinish.Size = New System.Drawing.Size(75, 23)
        Me.cmdFinish.TabIndex = 20
        Me.cmdFinish.Text = "Finish"
        Me.cmdFinish.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(482, 471)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 21
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdBack
        '
        Me.cmdBack.Enabled = False
        Me.cmdBack.Location = New System.Drawing.Point(158, 471)
        Me.cmdBack.Name = "cmdBack"
        Me.cmdBack.Size = New System.Drawing.Size(75, 23)
        Me.cmdBack.TabIndex = 22
        Me.cmdBack.Text = "Back"
        Me.cmdBack.UseVisualStyleBackColor = True
        '
        'fraColumns
        '
        Me.fraColumns.Controls.Add(Me.dgFileContents)
        Me.fraColumns.Controls.Add(Me.Label14)
        Me.fraColumns.Controls.Add(Me.cboAllocationPct)
        Me.fraColumns.Controls.Add(Me.Label12)
        Me.fraColumns.Controls.Add(Me.Label13)
        Me.fraColumns.Controls.Add(Me.cboVIN)
        Me.fraColumns.Controls.Add(Me.cboAddress)
        Me.fraColumns.Controls.Add(Me.txtDisposedValue)
        Me.fraColumns.Controls.Add(Me.Label11)
        Me.fraColumns.Controls.Add(Me.Label10)
        Me.fraColumns.Controls.Add(Me.cboDisposed)
        Me.fraColumns.Controls.Add(Me.optMultiple)
        Me.fraColumns.Controls.Add(Me.optSingle)
        Me.fraColumns.Controls.Add(Me.Label9)
        Me.fraColumns.Controls.Add(Me.Label8)
        Me.fraColumns.Controls.Add(Me.Label7)
        Me.fraColumns.Controls.Add(Me.Label6)
        Me.fraColumns.Controls.Add(Me.Label5)
        Me.fraColumns.Controls.Add(Me.Label4)
        Me.fraColumns.Controls.Add(Me.Label3)
        Me.fraColumns.Controls.Add(Me.Label2)
        Me.fraColumns.Controls.Add(Me.Label1)
        Me.fraColumns.Controls.Add(Me.cboPurchaseDate)
        Me.fraColumns.Controls.Add(Me.cboDescription)
        Me.fraColumns.Controls.Add(Me.cboMonth)
        Me.fraColumns.Controls.Add(Me.cboYear)
        Me.fraColumns.Controls.Add(Me.cboDay)
        Me.fraColumns.Controls.Add(Me.cboGLCode)
        Me.fraColumns.Controls.Add(Me.cboAssetId)
        Me.fraColumns.Controls.Add(Me.cboCost)
        Me.fraColumns.Location = New System.Drawing.Point(12, 145)
        Me.fraColumns.Name = "fraColumns"
        Me.fraColumns.Size = New System.Drawing.Size(927, 140)
        Me.fraColumns.TabIndex = 23
        Me.fraColumns.TabStop = False
        Me.fraColumns.Visible = False
        '
        'dgFileContents
        '
        Me.dgFileContents.AllowUserToAddRows = False
        Me.dgFileContents.AllowUserToDeleteRows = False
        Me.dgFileContents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgFileContents.Location = New System.Drawing.Point(5, 128)
        Me.dgFileContents.Name = "dgFileContents"
        Me.dgFileContents.ReadOnly = True
        Me.dgFileContents.Size = New System.Drawing.Size(915, 39)
        Me.dgFileContents.TabIndex = 71
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(128, 84)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(128, 13)
        Me.Label14.TabIndex = 70
        Me.Label14.Text = "Interstate Allocation Pct"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboAllocationPct
        '
        Me.cboAllocationPct.FormattingEnabled = True
        Me.cboAllocationPct.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboAllocationPct.Location = New System.Drawing.Point(161, 101)
        Me.cboAllocationPct.Name = "cboAllocationPct"
        Me.cboAllocationPct.Size = New System.Drawing.Size(60, 21)
        Me.cboAllocationPct.TabIndex = 51
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(96, 85)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(28, 13)
        Me.Label12.TabIndex = 69
        Me.Label12.Text = "VIN"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(7, 85)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(60, 13)
        Me.Label13.TabIndex = 68
        Me.Label13.Text = "Address"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboVIN
        '
        Me.cboVIN.FormattingEnabled = True
        Me.cboVIN.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboVIN.Location = New System.Drawing.Point(83, 101)
        Me.cboVIN.Name = "cboVIN"
        Me.cboVIN.Size = New System.Drawing.Size(60, 21)
        Me.cboVIN.TabIndex = 50
        '
        'cboAddress
        '
        Me.cboAddress.FormattingEnabled = True
        Me.cboAddress.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboAddress.Location = New System.Drawing.Point(5, 101)
        Me.cboAddress.Name = "cboAddress"
        Me.cboAddress.Size = New System.Drawing.Size(60, 21)
        Me.cboAddress.TabIndex = 49
        '
        'txtDisposedValue
        '
        Me.txtDisposedValue.Location = New System.Drawing.Point(482, 56)
        Me.txtDisposedValue.Name = "txtDisposedValue"
        Me.txtDisposedValue.Size = New System.Drawing.Size(60, 20)
        Me.txtDisposedValue.TabIndex = 48
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(482, 40)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(60, 13)
        Me.Label11.TabIndex = 67
        Me.Label11.Text = "Value"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(416, 40)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(60, 13)
        Me.Label10.TabIndex = 66
        Me.Label10.Text = "Disposed"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboDisposed
        '
        Me.cboDisposed.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDisposed.FormattingEnabled = True
        Me.cboDisposed.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboDisposed.Location = New System.Drawing.Point(416, 56)
        Me.cboDisposed.Name = "cboDisposed"
        Me.cboDisposed.Size = New System.Drawing.Size(60, 21)
        Me.cboDisposed.TabIndex = 47
        '
        'optMultiple
        '
        Me.optMultiple.Location = New System.Drawing.Point(581, 49)
        Me.optMultiple.Name = "optMultiple"
        Me.optMultiple.Size = New System.Drawing.Size(111, 33)
        Me.optMultiple.TabIndex = 53
        Me.optMultiple.Text = "Purchase date in multiple columns"
        Me.optMultiple.UseVisualStyleBackColor = True
        '
        'optSingle
        '
        Me.optSingle.Checked = True
        Me.optSingle.Location = New System.Drawing.Point(581, 16)
        Me.optSingle.Name = "optSingle"
        Me.optSingle.Size = New System.Drawing.Size(111, 32)
        Me.optSingle.TabIndex = 52
        Me.optSingle.TabStop = True
        Me.optSingle.Text = "Purchase date in single column"
        Me.optSingle.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(695, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(213, 13)
        Me.Label9.TabIndex = 65
        Me.Label9.Text = "Purchase Date"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(141, 40)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(95, 13)
        Me.Label8.TabIndex = 64
        Me.Label8.Text = "Purchase Date"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(239, 40)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 13)
        Me.Label7.TabIndex = 63
        Me.Label7.Text = "Description"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(698, 35)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 13)
        Me.Label6.TabIndex = 62
        Me.Label6.Text = "Month"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(848, 35)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 13)
        Me.Label5.TabIndex = 61
        Me.Label5.Text = "Year"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(770, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 60
        Me.Label4.Text = "Day"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(84, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 58
        Me.Label3.Text = "G/L Code"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(7, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 56
        Me.Label2.Text = "Asset ID"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(317, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 54
        Me.Label1.Text = "Cost"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboPurchaseDate
        '
        Me.cboPurchaseDate.FormattingEnabled = True
        Me.cboPurchaseDate.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboPurchaseDate.Location = New System.Drawing.Point(161, 56)
        Me.cboPurchaseDate.Name = "cboPurchaseDate"
        Me.cboPurchaseDate.Size = New System.Drawing.Size(60, 21)
        Me.cboPurchaseDate.TabIndex = 44
        '
        'cboDescription
        '
        Me.cboDescription.FormattingEnabled = True
        Me.cboDescription.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboDescription.Location = New System.Drawing.Point(239, 56)
        Me.cboDescription.Name = "cboDescription"
        Me.cboDescription.Size = New System.Drawing.Size(60, 21)
        Me.cboDescription.TabIndex = 45
        '
        'cboMonth
        '
        Me.cboMonth.Enabled = False
        Me.cboMonth.FormattingEnabled = True
        Me.cboMonth.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboMonth.Location = New System.Drawing.Point(698, 51)
        Me.cboMonth.Name = "cboMonth"
        Me.cboMonth.Size = New System.Drawing.Size(60, 21)
        Me.cboMonth.TabIndex = 55
        '
        'cboYear
        '
        Me.cboYear.Enabled = False
        Me.cboYear.FormattingEnabled = True
        Me.cboYear.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboYear.Location = New System.Drawing.Point(848, 51)
        Me.cboYear.Name = "cboYear"
        Me.cboYear.Size = New System.Drawing.Size(60, 21)
        Me.cboYear.TabIndex = 59
        '
        'cboDay
        '
        Me.cboDay.Enabled = False
        Me.cboDay.FormattingEnabled = True
        Me.cboDay.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboDay.Location = New System.Drawing.Point(773, 51)
        Me.cboDay.Name = "cboDay"
        Me.cboDay.Size = New System.Drawing.Size(60, 21)
        Me.cboDay.TabIndex = 57
        '
        'cboGLCode
        '
        Me.cboGLCode.FormattingEnabled = True
        Me.cboGLCode.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboGLCode.Location = New System.Drawing.Point(83, 56)
        Me.cboGLCode.Name = "cboGLCode"
        Me.cboGLCode.Size = New System.Drawing.Size(60, 21)
        Me.cboGLCode.TabIndex = 43
        '
        'cboAssetId
        '
        Me.cboAssetId.FormattingEnabled = True
        Me.cboAssetId.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboAssetId.Location = New System.Drawing.Point(5, 56)
        Me.cboAssetId.Name = "cboAssetId"
        Me.cboAssetId.Size = New System.Drawing.Size(60, 21)
        Me.cboAssetId.TabIndex = 42
        '
        'cboCost
        '
        Me.cboCost.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCost.FormattingEnabled = True
        Me.cboCost.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboCost.Location = New System.Drawing.Point(317, 56)
        Me.cboCost.Name = "cboCost"
        Me.cboCost.Size = New System.Drawing.Size(60, 21)
        Me.cboCost.TabIndex = 46
        '
        'fraResults
        '
        Me.fraResults.Controls.Add(Me.lblTotals)
        Me.fraResults.Controls.Add(Me.dgResults)
        Me.fraResults.Location = New System.Drawing.Point(12, 291)
        Me.fraResults.Name = "fraResults"
        Me.fraResults.Size = New System.Drawing.Size(579, 91)
        Me.fraResults.TabIndex = 24
        Me.fraResults.TabStop = False
        Me.fraResults.Visible = False
        '
        'lblTotals
        '
        Me.lblTotals.Location = New System.Drawing.Point(5, 11)
        Me.lblTotals.Name = "lblTotals"
        Me.lblTotals.Size = New System.Drawing.Size(459, 13)
        Me.lblTotals.TabIndex = 73
        Me.lblTotals.Text = "Number of assets in file:       Total original cost:"
        Me.lblTotals.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgResults
        '
        Me.dgResults.AllowUserToAddRows = False
        Me.dgResults.AllowUserToDeleteRows = False
        Me.dgResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgResults.Location = New System.Drawing.Point(3, 27)
        Me.dgResults.Name = "dgResults"
        Me.dgResults.ReadOnly = True
        Me.dgResults.Size = New System.Drawing.Size(573, 26)
        Me.dgResults.TabIndex = 72
        '
        'cmdPrint
        '
        Me.cmdPrint.Enabled = False
        Me.cmdPrint.Location = New System.Drawing.Point(320, 471)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(75, 23)
        Me.cmdPrint.TabIndex = 26
        Me.cmdPrint.Text = "Print"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'frmImportAssets
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1003, 501)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.fraResults)
        Me.Controls.Add(Me.fraFile)
        Me.Controls.Add(Me.cmdBack)
        Me.Controls.Add(Me.cmdNext)
        Me.Controls.Add(Me.cmdFinish)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.fraColumns)
        Me.Name = "frmImportAssets"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Import Assets"
        Me.fraFile.ResumeLayout(False)
        Me.fraFile.PerformLayout()
        Me.fraColumns.ResumeLayout(False)
        Me.fraColumns.PerformLayout()
        CType(Me.dgFileContents, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraResults.ResumeLayout(False)
        CType(Me.dgResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents fraFile As System.Windows.Forms.GroupBox
    Friend WithEvents radioImportDeletions As System.Windows.Forms.RadioButton
    Friend WithEvents radioImportAdditions As System.Windows.Forms.RadioButton
    Friend WithEvents radioImportComplete As System.Windows.Forms.RadioButton
    Friend WithEvents cmdNext As System.Windows.Forms.Button
    Friend WithEvents cmdFinish As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdBack As System.Windows.Forms.Button
    Friend WithEvents fraColumns As System.Windows.Forms.GroupBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cboAllocationPct As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cboVIN As System.Windows.Forms.ComboBox
    Friend WithEvents cboAddress As System.Windows.Forms.ComboBox
    Friend WithEvents txtDisposedValue As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboDisposed As System.Windows.Forms.ComboBox
    Friend WithEvents optMultiple As System.Windows.Forms.RadioButton
    Friend WithEvents optSingle As System.Windows.Forms.RadioButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboPurchaseDate As System.Windows.Forms.ComboBox
    Friend WithEvents cboDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cboMonth As System.Windows.Forms.ComboBox
    Friend WithEvents cboYear As System.Windows.Forms.ComboBox
    Friend WithEvents cboDay As System.Windows.Forms.ComboBox
    Friend WithEvents cboGLCode As System.Windows.Forms.ComboBox
    Friend WithEvents cboAssetId As System.Windows.Forms.ComboBox
    Friend WithEvents cboCost As System.Windows.Forms.ComboBox
    Friend WithEvents dgFileContents As System.Windows.Forms.DataGridView
    Friend WithEvents txtFile As System.Windows.Forms.TextBox
    Friend WithEvents cmdBrowse As System.Windows.Forms.Button
    Friend WithEvents fraResults As System.Windows.Forms.GroupBox
    Friend WithEvents dgResults As System.Windows.Forms.DataGridView
    Friend WithEvents lblTotals As System.Windows.Forms.Label
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
End Class
