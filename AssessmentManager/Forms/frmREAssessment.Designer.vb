<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmREAssessment
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.cboAssessor = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtAcctNum = New System.Windows.Forms.TextBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuContextPrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuContextDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmdNewJurisdiction = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkValueProtestFl = New System.Windows.Forms.CheckBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtValueProtestDeadlineDate = New System.Windows.Forms.TextBox()
        Me.txtValueProtestHearingDate = New System.Windows.Forms.TextBox()
        Me.txtValueProtestCMRRR = New System.Windows.Forms.TextBox()
        Me.cboValueProtestStatus = New System.Windows.Forms.ComboBox()
        Me.txtValueProtestMailedDate = New System.Windows.Forms.TextBox()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuContextImportTaxBill = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmdRefresh = New System.Windows.Forms.Button()
        Me.dgJurisdictions = New System.Windows.Forms.DataGridView()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtComment = New System.Windows.Forms.TextBox()
        Me.lblTaxBillTotal = New System.Windows.Forms.Label()
        Me.txtTaxBillTotal = New System.Windows.Forms.TextBox()
        Me.cmdTaxBillDetail = New System.Windows.Forms.Button()
        Me.chkInactiveFl = New System.Windows.Forms.CheckBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtClientLocationId = New System.Windows.Forms.TextBox()
        Me.fraHistory = New System.Windows.Forms.GroupBox()
        Me.txtValueMethodMarket = New System.Windows.Forms.TextBox()
        Me.dgHistory = New System.Windows.Forms.DataGridView()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtValueMethodCost = New System.Windows.Forms.TextBox()
        Me.txtValueMethodIncome = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.cboValueMethod = New System.Windows.Forms.ComboBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cboConstructionType = New System.Windows.Forms.ComboBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtExcessLandSqFt = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtLandSqFt = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtGrossLeasableSqFt = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtYearBuilt = New System.Windows.Forms.TextBox()
        Me.txtEffYearBuilt = New System.Windows.Forms.TextBox()
        Me.txtBuildingSqFt = New System.Windows.Forms.TextBox()
        Me.txtNetLeasableSqFt = New System.Windows.Forms.TextBox()
        Me.cboBuildingClass = New System.Windows.Forms.ComboBox()
        Me.cboBuildingType = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.fraCollectors = New System.Windows.Forms.GroupBox()
        Me.dgCollectors = New System.Windows.Forms.DataGridView()
        Me.txtSICCode = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cboAccountInvoicedStatus = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtConsultantName = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmdECU = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboOccupiedStatus = New System.Windows.Forms.ComboBox()
        Me.fraECU = New System.Windows.Forms.GroupBox()
        Me.dgECU = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.ContextMenuStrip2.SuspendLayout()
        CType(Me.dgJurisdictions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraHistory.SuspendLayout()
        CType(Me.dgHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.fraCollectors.SuspendLayout()
        CType(Me.dgCollectors, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraECU.SuspendLayout()
        CType(Me.dgECU, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cboAssessor
        '
        Me.cboAssessor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAssessor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAssessor.FormattingEnabled = True
        Me.cboAssessor.Location = New System.Drawing.Point(104, 32)
        Me.cboAssessor.Name = "cboAssessor"
        Me.cboAssessor.Size = New System.Drawing.Size(221, 21)
        Me.cboAssessor.TabIndex = 1
        Me.cboAssessor.Tag = "@DB=AssessmentsRE.AssessorId"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(32, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 18)
        Me.Label2.TabIndex = 132
        Me.Label2.Text = "Assessor"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 18)
        Me.Label1.TabIndex = 130
        Me.Label1.Text = "Account Number"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtAcctNum
        '
        Me.txtAcctNum.Location = New System.Drawing.Point(104, 8)
        Me.txtAcctNum.Name = "txtAcctNum"
        Me.txtAcctNum.Size = New System.Drawing.Size(221, 20)
        Me.txtAcctNum.TabIndex = 0
        Me.txtAcctNum.Tag = "@DB=AssessmentsRE.AcctNum"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuContextPrint, Me.mnuContextDelete})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(108, 48)
        '
        'mnuContextPrint
        '
        Me.mnuContextPrint.Name = "mnuContextPrint"
        Me.mnuContextPrint.Size = New System.Drawing.Size(107, 22)
        Me.mnuContextPrint.Text = "Print"
        '
        'mnuContextDelete
        '
        Me.mnuContextDelete.Name = "mnuContextDelete"
        Me.mnuContextDelete.Size = New System.Drawing.Size(107, 22)
        Me.mnuContextDelete.Text = "Delete"
        '
        'cmdNewJurisdiction
        '
        Me.cmdNewJurisdiction.Location = New System.Drawing.Point(8, 244)
        Me.cmdNewJurisdiction.Name = "cmdNewJurisdiction"
        Me.cmdNewJurisdiction.Size = New System.Drawing.Size(99, 23)
        Me.cmdNewJurisdiction.TabIndex = 134
        Me.cmdNewJurisdiction.Text = "New Jurisdiction"
        Me.cmdNewJurisdiction.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkValueProtestFl)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtValueProtestDeadlineDate)
        Me.GroupBox1.Controls.Add(Me.txtValueProtestHearingDate)
        Me.GroupBox1.Controls.Add(Me.txtValueProtestCMRRR)
        Me.GroupBox1.Controls.Add(Me.cboValueProtestStatus)
        Me.GroupBox1.Controls.Add(Me.txtValueProtestMailedDate)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(328, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(340, 136)
        Me.GroupBox1.TabIndex = 194
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Value Protest"
        '
        'chkValueProtestFl
        '
        Me.chkValueProtestFl.AutoSize = True
        Me.chkValueProtestFl.Location = New System.Drawing.Point(112, 20)
        Me.chkValueProtestFl.Name = "chkValueProtestFl"
        Me.chkValueProtestFl.Size = New System.Drawing.Size(15, 14)
        Me.chkValueProtestFl.TabIndex = 4
        Me.chkValueProtestFl.Tag = "@DB=AssessmentsRE.ValueProtestFl"
        Me.chkValueProtestFl.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(16, 20)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(91, 16)
        Me.Label17.TabIndex = 205
        Me.Label17.Text = "Protested"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(20, 36)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(91, 20)
        Me.Label8.TabIndex = 202
        Me.Label8.Text = "Mailed Date"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(16, 60)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(91, 20)
        Me.Label7.TabIndex = 201
        Me.Label7.Text = "CMRRR"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(4, 108)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 18)
        Me.Label6.TabIndex = 200
        Me.Label6.Text = "Hearing Date/Time"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(16, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 20)
        Me.Label4.TabIndex = 199
        Me.Label4.Text = "Status"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(163, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 19)
        Me.Label3.TabIndex = 198
        Me.Label3.Text = "Deadline Date"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtValueProtestDeadlineDate
        '
        Me.txtValueProtestDeadlineDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValueProtestDeadlineDate.Location = New System.Drawing.Point(260, 17)
        Me.txtValueProtestDeadlineDate.Name = "txtValueProtestDeadlineDate"
        Me.txtValueProtestDeadlineDate.Size = New System.Drawing.Size(72, 20)
        Me.txtValueProtestDeadlineDate.TabIndex = 5
        Me.txtValueProtestDeadlineDate.Tag = "@DB=AssessmentsRE.ValueProtestDeadlineDate;@fmt=date"
        '
        'txtValueProtestHearingDate
        '
        Me.txtValueProtestHearingDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValueProtestHearingDate.Location = New System.Drawing.Point(112, 108)
        Me.txtValueProtestHearingDate.Name = "txtValueProtestHearingDate"
        Me.txtValueProtestHearingDate.Size = New System.Drawing.Size(118, 20)
        Me.txtValueProtestHearingDate.TabIndex = 11
        Me.txtValueProtestHearingDate.Tag = "@DB=AssessmentsRE.ValueProtestHearingDate;@fmt=datetime"
        '
        'txtValueProtestCMRRR
        '
        Me.txtValueProtestCMRRR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValueProtestCMRRR.Location = New System.Drawing.Point(112, 60)
        Me.txtValueProtestCMRRR.Name = "txtValueProtestCMRRR"
        Me.txtValueProtestCMRRR.Size = New System.Drawing.Size(221, 20)
        Me.txtValueProtestCMRRR.TabIndex = 7
        Me.txtValueProtestCMRRR.Tag = "@DB=AssessmentsRE.ValueProtestCMRRR"
        '
        'cboValueProtestStatus
        '
        Me.cboValueProtestStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboValueProtestStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboValueProtestStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboValueProtestStatus.FormattingEnabled = True
        Me.cboValueProtestStatus.Location = New System.Drawing.Point(112, 84)
        Me.cboValueProtestStatus.Name = "cboValueProtestStatus"
        Me.cboValueProtestStatus.Size = New System.Drawing.Size(221, 21)
        Me.cboValueProtestStatus.TabIndex = 8
        Me.cboValueProtestStatus.Tag = "@DB=AssessmentsRE.ValueProtestStatus"
        '
        'txtValueProtestMailedDate
        '
        Me.txtValueProtestMailedDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValueProtestMailedDate.Location = New System.Drawing.Point(112, 36)
        Me.txtValueProtestMailedDate.Name = "txtValueProtestMailedDate"
        Me.txtValueProtestMailedDate.Size = New System.Drawing.Size(72, 20)
        Me.txtValueProtestMailedDate.TabIndex = 6
        Me.txtValueProtestMailedDate.Tag = "@DB=AssessmentsRE.ValueProtestMailedDate;@fmt=date"
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuContextImportTaxBill})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(150, 26)
        '
        'mnuContextImportTaxBill
        '
        Me.mnuContextImportTaxBill.Name = "mnuContextImportTaxBill"
        Me.mnuContextImportTaxBill.Size = New System.Drawing.Size(149, 22)
        Me.mnuContextImportTaxBill.Text = "Import Tax Bill"
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Location = New System.Drawing.Point(110, 244)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(99, 23)
        Me.cmdRefresh.TabIndex = 195
        Me.cmdRefresh.Text = "Refresh"
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'dgJurisdictions
        '
        Me.dgJurisdictions.AllowDrop = True
        Me.dgJurisdictions.AllowUserToAddRows = False
        Me.dgJurisdictions.AllowUserToDeleteRows = False
        Me.dgJurisdictions.AllowUserToOrderColumns = True
        Me.dgJurisdictions.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgJurisdictions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgJurisdictions.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dgJurisdictions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgJurisdictions.Location = New System.Drawing.Point(0, 0)
        Me.dgJurisdictions.Margin = New System.Windows.Forms.Padding(0)
        Me.dgJurisdictions.Name = "dgJurisdictions"
        Me.dgJurisdictions.RowHeadersVisible = False
        Me.dgJurisdictions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgJurisdictions.ShowCellErrors = False
        Me.dgJurisdictions.ShowCellToolTips = False
        Me.dgJurisdictions.ShowEditingIcon = False
        Me.dgJurisdictions.ShowRowErrors = False
        Me.dgJurisdictions.Size = New System.Drawing.Size(1327, 344)
        Me.dgJurisdictions.TabIndex = 133
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(4, 128)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(98, 19)
        Me.Label11.TabIndex = 209
        Me.Label11.Text = "Comments"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtComment
        '
        Me.txtComment.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComment.Location = New System.Drawing.Point(4, 148)
        Me.txtComment.Multiline = True
        Me.txtComment.Name = "txtComment"
        Me.txtComment.Size = New System.Drawing.Size(366, 62)
        Me.txtComment.TabIndex = 4
        Me.txtComment.Tag = "@DB=AssessmentsRE.Comment"
        '
        'lblTaxBillTotal
        '
        Me.lblTaxBillTotal.Location = New System.Drawing.Point(245, 244)
        Me.lblTaxBillTotal.Name = "lblTaxBillTotal"
        Me.lblTaxBillTotal.Size = New System.Drawing.Size(125, 20)
        Me.lblTaxBillTotal.TabIndex = 217
        Me.lblTaxBillTotal.Text = "Tax Bill Total"
        Me.lblTaxBillTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTaxBillTotal
        '
        Me.txtTaxBillTotal.BackColor = System.Drawing.SystemColors.Window
        Me.txtTaxBillTotal.Location = New System.Drawing.Point(376, 244)
        Me.txtTaxBillTotal.Name = "txtTaxBillTotal"
        Me.txtTaxBillTotal.ReadOnly = True
        Me.txtTaxBillTotal.Size = New System.Drawing.Size(115, 20)
        Me.txtTaxBillTotal.TabIndex = 215
        Me.txtTaxBillTotal.TabStop = False
        Me.txtTaxBillTotal.Tag = ""
        Me.txtTaxBillTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTaxBillTotal.WordWrap = False
        '
        'cmdTaxBillDetail
        '
        Me.cmdTaxBillDetail.Location = New System.Drawing.Point(492, 244)
        Me.cmdTaxBillDetail.Name = "cmdTaxBillDetail"
        Me.cmdTaxBillDetail.Size = New System.Drawing.Size(26, 20)
        Me.cmdTaxBillDetail.TabIndex = 214
        Me.cmdTaxBillDetail.Text = "..."
        Me.cmdTaxBillDetail.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdTaxBillDetail.UseVisualStyleBackColor = True
        '
        'chkInactiveFl
        '
        Me.chkInactiveFl.AutoSize = True
        Me.chkInactiveFl.Location = New System.Drawing.Point(6, 218)
        Me.chkInactiveFl.Name = "chkInactiveFl"
        Me.chkInactiveFl.Size = New System.Drawing.Size(64, 17)
        Me.chkInactiveFl.TabIndex = 218
        Me.chkInactiveFl.Tag = "@DB=AssessmentsRE.InactiveFl"
        Me.chkInactiveFl.Text = "Inactive"
        Me.chkInactiveFl.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(40, 56)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(64, 16)
        Me.Label21.TabIndex = 223
        Me.Label21.Text = "Client ID"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtClientLocationId
        '
        Me.txtClientLocationId.Location = New System.Drawing.Point(104, 56)
        Me.txtClientLocationId.Name = "txtClientLocationId"
        Me.txtClientLocationId.Size = New System.Drawing.Size(154, 20)
        Me.txtClientLocationId.TabIndex = 2
        Me.txtClientLocationId.Tag = "@DB=LocationsRE.ClientLocationId"
        '
        'fraHistory
        '
        Me.fraHistory.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fraHistory.Controls.Add(Me.txtValueMethodMarket)
        Me.fraHistory.Controls.Add(Me.dgHistory)
        Me.fraHistory.Controls.Add(Me.Label28)
        Me.fraHistory.Controls.Add(Me.txtValueMethodCost)
        Me.fraHistory.Controls.Add(Me.txtValueMethodIncome)
        Me.fraHistory.Controls.Add(Me.Label25)
        Me.fraHistory.Controls.Add(Me.Label27)
        Me.fraHistory.Controls.Add(Me.cboValueMethod)
        Me.fraHistory.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraHistory.Location = New System.Drawing.Point(1112, 8)
        Me.fraHistory.Name = "fraHistory"
        Me.fraHistory.Size = New System.Drawing.Size(209, 236)
        Me.fraHistory.TabIndex = 249
        Me.fraHistory.TabStop = False
        Me.fraHistory.Text = "History"
        '
        'txtValueMethodMarket
        '
        Me.txtValueMethodMarket.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValueMethodMarket.Location = New System.Drawing.Point(60, 208)
        Me.txtValueMethodMarket.Name = "txtValueMethodMarket"
        Me.txtValueMethodMarket.Size = New System.Drawing.Size(92, 20)
        Me.txtValueMethodMarket.TabIndex = 275
        Me.txtValueMethodMarket.Tag = "@DB=AssessmentsRE.ValueMethodMarket;@fmt=int"
        Me.txtValueMethodMarket.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtValueMethodMarket.WordWrap = False
        '
        'dgHistory
        '
        Me.dgHistory.AllowDrop = True
        Me.dgHistory.AllowUserToAddRows = False
        Me.dgHistory.AllowUserToDeleteRows = False
        Me.dgHistory.AllowUserToOrderColumns = True
        Me.dgHistory.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.Format = "N0"
        DataGridViewCellStyle5.NullValue = Nothing
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgHistory.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgHistory.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgHistory.Location = New System.Drawing.Point(3, 16)
        Me.dgHistory.Name = "dgHistory"
        Me.dgHistory.ReadOnly = True
        Me.dgHistory.RowHeadersVisible = False
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgHistory.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dgHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgHistory.ShowCellErrors = False
        Me.dgHistory.ShowCellToolTips = False
        Me.dgHistory.ShowEditingIcon = False
        Me.dgHistory.ShowRowErrors = False
        Me.dgHistory.Size = New System.Drawing.Size(203, 112)
        Me.dgHistory.TabIndex = 247
        '
        'Label28
        '
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(12, 212)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(44, 12)
        Me.Label28.TabIndex = 275
        Me.Label28.Text = "Market"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtValueMethodCost
        '
        Me.txtValueMethodCost.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValueMethodCost.Location = New System.Drawing.Point(60, 160)
        Me.txtValueMethodCost.Name = "txtValueMethodCost"
        Me.txtValueMethodCost.Size = New System.Drawing.Size(92, 20)
        Me.txtValueMethodCost.TabIndex = 273
        Me.txtValueMethodCost.Tag = "@DB=AssessmentsRE.ValueMethodCost;@fmt=int"
        Me.txtValueMethodCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtValueMethodCost.WordWrap = False
        '
        'txtValueMethodIncome
        '
        Me.txtValueMethodIncome.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValueMethodIncome.Location = New System.Drawing.Point(60, 184)
        Me.txtValueMethodIncome.Name = "txtValueMethodIncome"
        Me.txtValueMethodIncome.Size = New System.Drawing.Size(92, 20)
        Me.txtValueMethodIncome.TabIndex = 274
        Me.txtValueMethodIncome.Tag = "@DB=AssessmentsRE.ValueMethodIncome;@fmt=int"
        Me.txtValueMethodIncome.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtValueMethodIncome.WordWrap = False
        '
        'Label25
        '
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(12, 164)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(44, 12)
        Me.Label25.TabIndex = 269
        Me.Label25.Text = "Cost"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label27
        '
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(8, 188)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(48, 12)
        Me.Label27.TabIndex = 273
        Me.Label27.Text = "Income"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboValueMethod
        '
        Me.cboValueMethod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboValueMethod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboValueMethod.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboValueMethod.FormattingEnabled = True
        Me.cboValueMethod.Location = New System.Drawing.Point(60, 136)
        Me.cboValueMethod.Name = "cboValueMethod"
        Me.cboValueMethod.Size = New System.Drawing.Size(92, 21)
        Me.cboValueMethod.TabIndex = 272
        Me.cboValueMethod.Tag = "@DB=AssessmentsRE.ValueMethod"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(2)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.fraHistory)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.fraCollectors)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtSICCode)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label12)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cboAccountInvoicedStatus)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label10)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtConsultantName)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label9)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdECU)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cboOccupiedStatus)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdNewJurisdiction)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtAcctNum)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label21)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtClientLocationId)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdRefresh)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cboAssessor)
        Me.SplitContainer1.Panel1.Controls.Add(Me.chkInactiveFl)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtComment)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblTaxBillTotal)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label11)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtTaxBillTotal)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdTaxBillDetail)
        Me.SplitContainer1.Panel1.Controls.Add(Me.fraECU)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgJurisdictions)
        Me.SplitContainer1.Size = New System.Drawing.Size(1327, 618)
        Me.SplitContainer1.SplitterDistance = 271
        Me.SplitContainer1.SplitterWidth = 3
        Me.SplitContainer1.TabIndex = 250
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboConstructionType)
        Me.GroupBox2.Controls.Add(Me.Label24)
        Me.GroupBox2.Controls.Add(Me.txtExcessLandSqFt)
        Me.GroupBox2.Controls.Add(Me.Label23)
        Me.GroupBox2.Controls.Add(Me.txtLandSqFt)
        Me.GroupBox2.Controls.Add(Me.Label22)
        Me.GroupBox2.Controls.Add(Me.txtGrossLeasableSqFt)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.txtYearBuilt)
        Me.GroupBox2.Controls.Add(Me.txtEffYearBuilt)
        Me.GroupBox2.Controls.Add(Me.txtBuildingSqFt)
        Me.GroupBox2.Controls.Add(Me.txtNetLeasableSqFt)
        Me.GroupBox2.Controls.Add(Me.cboBuildingClass)
        Me.GroupBox2.Controls.Add(Me.cboBuildingType)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(716, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(392, 140)
        Me.GroupBox2.TabIndex = 206
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Property Details"
        '
        'cboConstructionType
        '
        Me.cboConstructionType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboConstructionType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboConstructionType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboConstructionType.FormattingEnabled = True
        Me.cboConstructionType.Location = New System.Drawing.Point(88, 64)
        Me.cboConstructionType.Name = "cboConstructionType"
        Me.cboConstructionType.Size = New System.Drawing.Size(160, 21)
        Me.cboConstructionType.TabIndex = 150
        Me.cboConstructionType.Tag = "@DB=AssessmentsRE.ConstructionType"
        '
        'Label24
        '
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(16, 68)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(70, 16)
        Me.Label24.TabIndex = 149
        Me.Label24.Text = "Const Type"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtExcessLandSqFt
        '
        Me.txtExcessLandSqFt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExcessLandSqFt.Location = New System.Drawing.Point(324, 112)
        Me.txtExcessLandSqFt.Name = "txtExcessLandSqFt"
        Me.txtExcessLandSqFt.Size = New System.Drawing.Size(64, 20)
        Me.txtExcessLandSqFt.TabIndex = 148
        Me.txtExcessLandSqFt.Tag = "@DB=AssessmentsRE.ExcessLandSqFt;@fmt=int"
        Me.txtExcessLandSqFt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtExcessLandSqFt.WordWrap = False
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(224, 116)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(100, 16)
        Me.Label23.TabIndex = 147
        Me.Label23.Text = "Excess Land Sq Ft"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtLandSqFt
        '
        Me.txtLandSqFt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLandSqFt.Location = New System.Drawing.Point(324, 88)
        Me.txtLandSqFt.Name = "txtLandSqFt"
        Me.txtLandSqFt.Size = New System.Drawing.Size(64, 20)
        Me.txtLandSqFt.TabIndex = 146
        Me.txtLandSqFt.Tag = "@DB=AssessmentsRE.LandSqFt;@fmt=int"
        Me.txtLandSqFt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtLandSqFt.WordWrap = False
        '
        'Label22
        '
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(244, 92)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(80, 16)
        Me.Label22.TabIndex = 145
        Me.Label22.Text = "Land Sq Ft"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtGrossLeasableSqFt
        '
        Me.txtGrossLeasableSqFt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGrossLeasableSqFt.Location = New System.Drawing.Point(88, 112)
        Me.txtGrossLeasableSqFt.Name = "txtGrossLeasableSqFt"
        Me.txtGrossLeasableSqFt.Size = New System.Drawing.Size(60, 20)
        Me.txtGrossLeasableSqFt.TabIndex = 144
        Me.txtGrossLeasableSqFt.Tag = "@DB=AssessmentsRE.GrossLeasableSqFt;@fmt=int"
        Me.txtGrossLeasableSqFt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtGrossLeasableSqFt.WordWrap = False
        '
        'Label20
        '
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(6, 116)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(80, 16)
        Me.Label20.TabIndex = 143
        Me.Label20.Text = "Gross Leasable"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtYearBuilt
        '
        Me.txtYearBuilt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtYearBuilt.Location = New System.Drawing.Point(324, 16)
        Me.txtYearBuilt.Name = "txtYearBuilt"
        Me.txtYearBuilt.Size = New System.Drawing.Size(32, 20)
        Me.txtYearBuilt.TabIndex = 142
        Me.txtYearBuilt.Tag = "@DB=AssessmentsRE.YearBuilt;@fmt=year"
        Me.txtYearBuilt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtYearBuilt.WordWrap = False
        '
        'txtEffYearBuilt
        '
        Me.txtEffYearBuilt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEffYearBuilt.Location = New System.Drawing.Point(324, 40)
        Me.txtEffYearBuilt.Name = "txtEffYearBuilt"
        Me.txtEffYearBuilt.Size = New System.Drawing.Size(32, 20)
        Me.txtEffYearBuilt.TabIndex = 141
        Me.txtEffYearBuilt.Tag = "@DB=AssessmentsRE.EffYearBuilt;@fmt=year"
        Me.txtEffYearBuilt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtEffYearBuilt.WordWrap = False
        '
        'txtBuildingSqFt
        '
        Me.txtBuildingSqFt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBuildingSqFt.Location = New System.Drawing.Point(324, 64)
        Me.txtBuildingSqFt.Name = "txtBuildingSqFt"
        Me.txtBuildingSqFt.Size = New System.Drawing.Size(60, 20)
        Me.txtBuildingSqFt.TabIndex = 140
        Me.txtBuildingSqFt.Tag = "@DB=AssessmentsRE.BuildingSqFt;@fmt=int"
        Me.txtBuildingSqFt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtBuildingSqFt.WordWrap = False
        '
        'txtNetLeasableSqFt
        '
        Me.txtNetLeasableSqFt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNetLeasableSqFt.Location = New System.Drawing.Point(88, 88)
        Me.txtNetLeasableSqFt.Name = "txtNetLeasableSqFt"
        Me.txtNetLeasableSqFt.Size = New System.Drawing.Size(60, 20)
        Me.txtNetLeasableSqFt.TabIndex = 139
        Me.txtNetLeasableSqFt.Tag = "@DB=AssessmentsRE.NetLeasableSqFt;@fmt=int"
        Me.txtNetLeasableSqFt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtNetLeasableSqFt.WordWrap = False
        '
        'cboBuildingClass
        '
        Me.cboBuildingClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBuildingClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBuildingClass.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBuildingClass.FormattingEnabled = True
        Me.cboBuildingClass.Location = New System.Drawing.Point(88, 40)
        Me.cboBuildingClass.Name = "cboBuildingClass"
        Me.cboBuildingClass.Size = New System.Drawing.Size(56, 21)
        Me.cboBuildingClass.TabIndex = 138
        Me.cboBuildingClass.Tag = "@DB=AssessmentsRE.BuildingClass"
        '
        'cboBuildingType
        '
        Me.cboBuildingType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBuildingType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBuildingType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBuildingType.FormattingEnabled = True
        Me.cboBuildingType.Location = New System.Drawing.Point(88, 16)
        Me.cboBuildingType.Name = "cboBuildingType"
        Me.cboBuildingType.Size = New System.Drawing.Size(160, 21)
        Me.cboBuildingType.TabIndex = 137
        Me.cboBuildingType.Tag = "@DB=AssessmentsRE.BuildingType"
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(16, 20)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(70, 16)
        Me.Label19.TabIndex = 136
        Me.Label19.Text = "Bldg Type"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(260, 68)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(62, 16)
        Me.Label18.TabIndex = 135
        Me.Label18.Text = "Bldg Sq Ft"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(4, 92)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(82, 16)
        Me.Label16.TabIndex = 134
        Me.Label16.Text = "Net Leasable"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(28, 44)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(58, 16)
        Me.Label15.TabIndex = 133
        Me.Label15.Text = "Bldg Class"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(268, 20)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(54, 16)
        Me.Label14.TabIndex = 132
        Me.Label14.Text = "Year Built"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(264, 44)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(58, 16)
        Me.Label13.TabIndex = 131
        Me.Label13.Text = "Eff Yr Built"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'fraCollectors
        '
        Me.fraCollectors.Controls.Add(Me.dgCollectors)
        Me.fraCollectors.Location = New System.Drawing.Point(520, 144)
        Me.fraCollectors.Name = "fraCollectors"
        Me.fraCollectors.Size = New System.Drawing.Size(672, 123)
        Me.fraCollectors.TabIndex = 268
        Me.fraCollectors.TabStop = False
        Me.fraCollectors.Visible = False
        '
        'dgCollectors
        '
        Me.dgCollectors.AllowDrop = True
        Me.dgCollectors.AllowUserToAddRows = False
        Me.dgCollectors.AllowUserToDeleteRows = False
        Me.dgCollectors.AllowUserToOrderColumns = True
        Me.dgCollectors.ColumnHeadersHeight = 45
        Me.dgCollectors.ContextMenuStrip = Me.ContextMenuStrip2
        Me.dgCollectors.Location = New System.Drawing.Point(0, 4)
        Me.dgCollectors.Name = "dgCollectors"
        Me.dgCollectors.RowHeadersVisible = False
        Me.dgCollectors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgCollectors.ShowCellErrors = False
        Me.dgCollectors.ShowCellToolTips = False
        Me.dgCollectors.ShowEditingIcon = False
        Me.dgCollectors.ShowRowErrors = False
        Me.dgCollectors.Size = New System.Drawing.Size(672, 116)
        Me.dgCollectors.TabIndex = 212
        '
        'txtSICCode
        '
        Me.txtSICCode.AllowDrop = True
        Me.txtSICCode.Enabled = False
        Me.txtSICCode.Location = New System.Drawing.Point(356, 216)
        Me.txtSICCode.Name = "txtSICCode"
        Me.txtSICCode.Size = New System.Drawing.Size(160, 20)
        Me.txtSICCode.TabIndex = 265
        Me.txtSICCode.Tag = ""
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(300, 216)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(54, 20)
        Me.Label12.TabIndex = 266
        Me.Label12.Text = "SIC Code"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboAccountInvoicedStatus
        '
        Me.cboAccountInvoicedStatus.AllowDrop = True
        Me.cboAccountInvoicedStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAccountInvoicedStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAccountInvoicedStatus.FormattingEnabled = True
        Me.cboAccountInvoicedStatus.Location = New System.Drawing.Point(104, 104)
        Me.cboAccountInvoicedStatus.Name = "cboAccountInvoicedStatus"
        Me.cboAccountInvoicedStatus.Size = New System.Drawing.Size(108, 21)
        Me.cboAccountInvoicedStatus.TabIndex = 4
        Me.cboAccountInvoicedStatus.Tag = "@DB=AssessmentsRE.AccountInvoicedStatus"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(12, 104)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(92, 20)
        Me.Label10.TabIndex = 264
        Me.Label10.Text = "Account Invoiced"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtConsultantName
        '
        Me.txtConsultantName.AllowDrop = True
        Me.txtConsultantName.Enabled = False
        Me.txtConsultantName.Location = New System.Drawing.Point(144, 216)
        Me.txtConsultantName.Name = "txtConsultantName"
        Me.txtConsultantName.Size = New System.Drawing.Size(154, 20)
        Me.txtConsultantName.TabIndex = 261
        Me.txtConsultantName.Tag = ""
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(80, 216)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(62, 20)
        Me.Label9.TabIndex = 262
        Me.Label9.Text = "Consultant"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdECU
        '
        Me.cmdECU.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdECU.Location = New System.Drawing.Point(672, 8)
        Me.cmdECU.Name = "cmdECU"
        Me.cmdECU.Size = New System.Drawing.Size(42, 20)
        Me.cmdECU.TabIndex = 253
        Me.cmdECU.Text = "ECU"
        Me.cmdECU.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdECU.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(8, 80)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 18)
        Me.Label5.TabIndex = 251
        Me.Label5.Text = "Occupied/Leased"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboOccupiedStatus
        '
        Me.cboOccupiedStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboOccupiedStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboOccupiedStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboOccupiedStatus.FormattingEnabled = True
        Me.cboOccupiedStatus.Location = New System.Drawing.Point(104, 80)
        Me.cboOccupiedStatus.Name = "cboOccupiedStatus"
        Me.cboOccupiedStatus.Size = New System.Drawing.Size(136, 21)
        Me.cboOccupiedStatus.TabIndex = 3
        Me.cboOccupiedStatus.Tag = "@DB=AssessmentsRE.OccupiedStatus"
        '
        'fraECU
        '
        Me.fraECU.Controls.Add(Me.dgECU)
        Me.fraECU.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraECU.Location = New System.Drawing.Point(672, 32)
        Me.fraECU.Name = "fraECU"
        Me.fraECU.Size = New System.Drawing.Size(388, 232)
        Me.fraECU.TabIndex = 252
        Me.fraECU.TabStop = False
        Me.fraECU.Text = "ECU"
        Me.fraECU.Visible = False
        '
        'dgECU
        '
        Me.dgECU.AllowDrop = True
        Me.dgECU.AllowUserToAddRows = False
        Me.dgECU.AllowUserToDeleteRows = False
        Me.dgECU.AllowUserToOrderColumns = True
        Me.dgECU.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.Format = "N0"
        DataGridViewCellStyle7.NullValue = Nothing
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgECU.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgECU.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgECU.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgECU.Location = New System.Drawing.Point(3, 16)
        Me.dgECU.Name = "dgECU"
        Me.dgECU.ReadOnly = True
        Me.dgECU.RowHeadersVisible = False
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgECU.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.dgECU.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgECU.ShowCellErrors = False
        Me.dgECU.ShowCellToolTips = False
        Me.dgECU.ShowEditingIcon = False
        Me.dgECU.ShowRowErrors = False
        Me.dgECU.Size = New System.Drawing.Size(382, 213)
        Me.dgECU.TabIndex = 247
        '
        'frmREAssessment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1327, 618)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmREAssessment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Real Estate Assessment"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ContextMenuStrip2.ResumeLayout(False)
        CType(Me.dgJurisdictions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraHistory.ResumeLayout(False)
        Me.fraHistory.PerformLayout()
        CType(Me.dgHistory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.fraCollectors.ResumeLayout(False)
        CType(Me.dgCollectors, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraECU.ResumeLayout(False)
        CType(Me.dgECU, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cboAssessor As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtAcctNum As System.Windows.Forms.TextBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuContextDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdNewJurisdiction As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtValueProtestDeadlineDate As System.Windows.Forms.TextBox
    Friend WithEvents txtValueProtestHearingDate As System.Windows.Forms.TextBox
    Friend WithEvents txtValueProtestCMRRR As System.Windows.Forms.TextBox
    Friend WithEvents cboValueProtestStatus As System.Windows.Forms.ComboBox
    Friend WithEvents txtValueProtestMailedDate As System.Windows.Forms.TextBox
    Friend WithEvents chkValueProtestFl As System.Windows.Forms.CheckBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents dgJurisdictions As System.Windows.Forms.DataGridView
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtComment As System.Windows.Forms.TextBox
    Friend WithEvents mnuContextPrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblTaxBillTotal As System.Windows.Forms.Label
    Friend WithEvents txtTaxBillTotal As System.Windows.Forms.TextBox
    Friend WithEvents cmdTaxBillDetail As System.Windows.Forms.Button
    Friend WithEvents chkInactiveFl As System.Windows.Forms.CheckBox
    Friend WithEvents ContextMenuStrip2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuContextImportTaxBill As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtClientLocationId As System.Windows.Forms.TextBox
    Friend WithEvents fraHistory As System.Windows.Forms.GroupBox
    Friend WithEvents dgHistory As System.Windows.Forms.DataGridView
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboOccupiedStatus As System.Windows.Forms.ComboBox
    Friend WithEvents fraECU As System.Windows.Forms.GroupBox
    Friend WithEvents dgECU As System.Windows.Forms.DataGridView
    Friend WithEvents cmdECU As System.Windows.Forms.Button
    Friend WithEvents txtConsultantName As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents cboAccountInvoicedStatus As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtSICCode As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents fraCollectors As GroupBox
    Friend WithEvents dgCollectors As DataGridView
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label13 As Label
    Friend WithEvents cboBuildingClass As ComboBox
    Friend WithEvents cboBuildingType As ComboBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents txtYearBuilt As TextBox
    Friend WithEvents txtEffYearBuilt As TextBox
    Friend WithEvents txtBuildingSqFt As TextBox
    Friend WithEvents txtNetLeasableSqFt As TextBox
    Friend WithEvents txtGrossLeasableSqFt As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents txtExcessLandSqFt As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents txtLandSqFt As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents cboConstructionType As ComboBox
    Friend WithEvents Label24 As Label
    Friend WithEvents txtValueMethodMarket As TextBox
    Friend WithEvents Label28 As Label
    Friend WithEvents txtValueMethodIncome As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents cboValueMethod As ComboBox
    Friend WithEvents txtValueMethodCost As TextBox
    Friend WithEvents Label25 As Label
End Class
