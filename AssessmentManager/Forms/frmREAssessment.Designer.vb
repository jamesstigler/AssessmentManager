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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.dgHistory = New System.Windows.Forms.DataGridView()
        Me.txtValueMethodMarket = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtValueMethodCost = New System.Windows.Forms.TextBox()
        Me.txtValueMethodIncome = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.cboValueMethod = New System.Windows.Forms.ComboBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmdOpenAssessor = New System.Windows.Forms.Button()
        Me.fraECU = New System.Windows.Forms.GroupBox()
        Me.dgECU = New System.Windows.Forms.DataGridView()
        Me.txtSICCode = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cboAccountInvoicedStatus = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboOccupiedStatus = New System.Windows.Forms.ComboBox()
        Me.txtConsultantName = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.grpComments = New System.Windows.Forms.GroupBox()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.cmdNewComment = New System.Windows.Forms.Button()
        Me.dgComments = New System.Windows.Forms.DataGridView()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ChangeDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Comment = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContextMenuStrip3 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuContextDeleteComment = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txtLeaseupCommissionPct = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.txtLeaseupTotIncCostPerSqFt = New System.Windows.Forms.TextBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.txtLeaseupVacantSqFt = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtMarketNonReimbPct = New System.Windows.Forms.TextBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.txtMarketReimbRevenue = New System.Windows.Forms.TextBox()
        Me.txtMarketCapRate = New System.Windows.Forms.TextBox()
        Me.txtMarketRentPerSqFt = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.txtMarketCommonAreaMaintPct = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.txtMarketMgmtFeesPct = New System.Windows.Forms.TextBox()
        Me.txtMarketTaxRate = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.txtMarketAddlRevenue = New System.Windows.Forms.TextBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtMarketVacCollLossPct = New System.Windows.Forms.TextBox()
        Me.txtMarketPropInsPct = New System.Windows.Forms.TextBox()
        Me.txtValueMethodTarget = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtValueMethodEquity = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtCeilingHeight = New System.Windows.Forms.TextBox()
        Me.Label43 = New System.Windows.Forms.Label()
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
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.fraECU.SuspendLayout()
        CType(Me.dgECU, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.grpComments.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.dgComments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.fraCollectors.SuspendLayout()
        CType(Me.dgCollectors, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cboAssessor
        '
        Me.cboAssessor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAssessor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAssessor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAssessor.FormattingEnabled = True
        Me.cboAssessor.Location = New System.Drawing.Point(105, 31)
        Me.cboAssessor.Name = "cboAssessor"
        Me.cboAssessor.Size = New System.Drawing.Size(200, 21)
        Me.cboAssessor.TabIndex = 1
        Me.cboAssessor.Tag = "@DB=AssessmentsRE.AssessorId"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(33, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 18)
        Me.Label2.TabIndex = 132
        Me.Label2.Text = "Assessor"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 18)
        Me.Label1.TabIndex = 130
        Me.Label1.Text = "Account Number"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtAcctNum
        '
        Me.txtAcctNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAcctNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAcctNum.Location = New System.Drawing.Point(105, 7)
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
        Me.cmdNewJurisdiction.Location = New System.Drawing.Point(4, 4)
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
        Me.GroupBox1.Location = New System.Drawing.Point(329, 7)
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
        Me.txtValueProtestDeadlineDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtValueProtestDeadlineDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValueProtestDeadlineDate.Location = New System.Drawing.Point(260, 17)
        Me.txtValueProtestDeadlineDate.Name = "txtValueProtestDeadlineDate"
        Me.txtValueProtestDeadlineDate.Size = New System.Drawing.Size(72, 20)
        Me.txtValueProtestDeadlineDate.TabIndex = 5
        Me.txtValueProtestDeadlineDate.Tag = "@DB=AssessmentsRE.ValueProtestDeadlineDate;@fmt=date"
        '
        'txtValueProtestHearingDate
        '
        Me.txtValueProtestHearingDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtValueProtestHearingDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValueProtestHearingDate.Location = New System.Drawing.Point(112, 108)
        Me.txtValueProtestHearingDate.Name = "txtValueProtestHearingDate"
        Me.txtValueProtestHearingDate.Size = New System.Drawing.Size(118, 20)
        Me.txtValueProtestHearingDate.TabIndex = 11
        Me.txtValueProtestHearingDate.Tag = "@DB=AssessmentsRE.ValueProtestHearingDate;@fmt=datetime"
        '
        'txtValueProtestCMRRR
        '
        Me.txtValueProtestCMRRR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
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
        Me.txtValueProtestMailedDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
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
        Me.cmdRefresh.Location = New System.Drawing.Point(115, 5)
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
        Me.dgJurisdictions.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgJurisdictions.Location = New System.Drawing.Point(0, 32)
        Me.dgJurisdictions.Margin = New System.Windows.Forms.Padding(0)
        Me.dgJurisdictions.Name = "dgJurisdictions"
        Me.dgJurisdictions.RowHeadersVisible = False
        Me.dgJurisdictions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgJurisdictions.ShowCellErrors = False
        Me.dgJurisdictions.ShowCellToolTips = False
        Me.dgJurisdictions.ShowEditingIcon = False
        Me.dgJurisdictions.ShowRowErrors = False
        Me.dgJurisdictions.Size = New System.Drawing.Size(1302, 398)
        Me.dgJurisdictions.TabIndex = 133
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(5, 127)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(98, 19)
        Me.Label11.TabIndex = 209
        Me.Label11.Text = "Comments"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtComment
        '
        Me.txtComment.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComment.Location = New System.Drawing.Point(5, 147)
        Me.txtComment.Multiline = True
        Me.txtComment.Name = "txtComment"
        Me.txtComment.Size = New System.Drawing.Size(366, 62)
        Me.txtComment.TabIndex = 4
        Me.txtComment.Tag = "@DB=AssessmentsRE.Comment"
        '
        'lblTaxBillTotal
        '
        Me.lblTaxBillTotal.Location = New System.Drawing.Point(220, 5)
        Me.lblTaxBillTotal.Name = "lblTaxBillTotal"
        Me.lblTaxBillTotal.Size = New System.Drawing.Size(125, 20)
        Me.lblTaxBillTotal.TabIndex = 217
        Me.lblTaxBillTotal.Text = "Tax Bill Total"
        Me.lblTaxBillTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTaxBillTotal
        '
        Me.txtTaxBillTotal.BackColor = System.Drawing.SystemColors.Window
        Me.txtTaxBillTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTaxBillTotal.Location = New System.Drawing.Point(351, 5)
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
        Me.cmdTaxBillDetail.Location = New System.Drawing.Point(467, 5)
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
        Me.chkInactiveFl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkInactiveFl.Location = New System.Drawing.Point(7, 217)
        Me.chkInactiveFl.Name = "chkInactiveFl"
        Me.chkInactiveFl.Size = New System.Drawing.Size(64, 17)
        Me.chkInactiveFl.TabIndex = 218
        Me.chkInactiveFl.Tag = "@DB=AssessmentsRE.InactiveFl"
        Me.chkInactiveFl.Text = "Inactive"
        Me.chkInactiveFl.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(41, 55)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(64, 16)
        Me.Label21.TabIndex = 223
        Me.Label21.Text = "Client ID"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtClientLocationId
        '
        Me.txtClientLocationId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtClientLocationId.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClientLocationId.Location = New System.Drawing.Point(105, 55)
        Me.txtClientLocationId.Name = "txtClientLocationId"
        Me.txtClientLocationId.Size = New System.Drawing.Size(154, 20)
        Me.txtClientLocationId.TabIndex = 2
        Me.txtClientLocationId.Tag = "@DB=LocationsRE.ClientLocationId"
        '
        'fraHistory
        '
        Me.fraHistory.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fraHistory.Controls.Add(Me.dgHistory)
        Me.fraHistory.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraHistory.Location = New System.Drawing.Point(1060, 4)
        Me.fraHistory.Name = "fraHistory"
        Me.fraHistory.Size = New System.Drawing.Size(228, 236)
        Me.fraHistory.TabIndex = 249
        Me.fraHistory.TabStop = False
        Me.fraHistory.Text = "History"
        '
        'dgHistory
        '
        Me.dgHistory.AllowDrop = True
        Me.dgHistory.AllowUserToAddRows = False
        Me.dgHistory.AllowUserToDeleteRows = False
        Me.dgHistory.AllowUserToOrderColumns = True
        Me.dgHistory.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.Format = "N0"
        DataGridViewCellStyle1.NullValue = Nothing
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgHistory.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgHistory.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgHistory.Location = New System.Drawing.Point(3, 16)
        Me.dgHistory.Name = "dgHistory"
        Me.dgHistory.ReadOnly = True
        Me.dgHistory.RowHeadersVisible = False
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgHistory.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgHistory.ShowCellErrors = False
        Me.dgHistory.ShowCellToolTips = False
        Me.dgHistory.ShowEditingIcon = False
        Me.dgHistory.ShowRowErrors = False
        Me.dgHistory.Size = New System.Drawing.Size(222, 112)
        Me.dgHistory.TabIndex = 247
        '
        'txtValueMethodMarket
        '
        Me.txtValueMethodMarket.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtValueMethodMarket.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValueMethodMarket.Location = New System.Drawing.Point(708, 184)
        Me.txtValueMethodMarket.Name = "txtValueMethodMarket"
        Me.txtValueMethodMarket.Size = New System.Drawing.Size(92, 20)
        Me.txtValueMethodMarket.TabIndex = 275
        Me.txtValueMethodMarket.Tag = "@DB=AssessmentsRE.ValueMethodMarket;@fmt=int"
        Me.txtValueMethodMarket.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtValueMethodMarket.WordWrap = False
        '
        'Label28
        '
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(660, 188)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(44, 12)
        Me.Label28.TabIndex = 275
        Me.Label28.Text = "Market"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtValueMethodCost
        '
        Me.txtValueMethodCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtValueMethodCost.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValueMethodCost.Location = New System.Drawing.Point(708, 136)
        Me.txtValueMethodCost.Name = "txtValueMethodCost"
        Me.txtValueMethodCost.Size = New System.Drawing.Size(92, 20)
        Me.txtValueMethodCost.TabIndex = 273
        Me.txtValueMethodCost.Tag = "@DB=AssessmentsRE.ValueMethodCost;@fmt=int"
        Me.txtValueMethodCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtValueMethodCost.WordWrap = False
        '
        'txtValueMethodIncome
        '
        Me.txtValueMethodIncome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtValueMethodIncome.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValueMethodIncome.Location = New System.Drawing.Point(708, 160)
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
        Me.Label25.Location = New System.Drawing.Point(660, 140)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(44, 12)
        Me.Label25.TabIndex = 269
        Me.Label25.Text = "Cost"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label27
        '
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(656, 164)
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
        Me.cboValueMethod.Location = New System.Drawing.Point(708, 112)
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.TabControl1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgJurisdictions)
        Me.SplitContainer1.Panel2.Controls.Add(Me.cmdNewJurisdiction)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtTaxBillTotal)
        Me.SplitContainer1.Panel2.Controls.Add(Me.cmdTaxBillDetail)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblTaxBillTotal)
        Me.SplitContainer1.Panel2.Controls.Add(Me.cmdRefresh)
        Me.SplitContainer1.Panel2.Controls.Add(Me.fraCollectors)
        Me.SplitContainer1.Size = New System.Drawing.Size(1302, 735)
        Me.SplitContainer1.SplitterDistance = 302
        Me.SplitContainer1.SplitterWidth = 3
        Me.SplitContainer1.TabIndex = 250
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1302, 302)
        Me.TabControl1.TabIndex = 270
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1294, 273)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Account"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.fraHistory)
        Me.Panel1.Controls.Add(Me.cmdOpenAssessor)
        Me.Panel1.Controls.Add(Me.fraECU)
        Me.Panel1.Controls.Add(Me.txtAcctNum)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.txtComment)
        Me.Panel1.Controls.Add(Me.chkInactiveFl)
        Me.Panel1.Controls.Add(Me.txtSICCode)
        Me.Panel1.Controls.Add(Me.cboAssessor)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.txtClientLocationId)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.cboAccountInvoicedStatus)
        Me.Panel1.Controls.Add(Me.Label21)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.cboOccupiedStatus)
        Me.Panel1.Controls.Add(Me.txtConsultantName)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1288, 267)
        Me.Panel1.TabIndex = 0
        '
        'cmdOpenAssessor
        '
        Me.cmdOpenAssessor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOpenAssessor.Location = New System.Drawing.Point(305, 31)
        Me.cmdOpenAssessor.Name = "cmdOpenAssessor"
        Me.cmdOpenAssessor.Size = New System.Drawing.Size(24, 19)
        Me.cmdOpenAssessor.TabIndex = 269
        Me.cmdOpenAssessor.Text = "..."
        Me.cmdOpenAssessor.UseVisualStyleBackColor = True
        '
        'fraECU
        '
        Me.fraECU.Controls.Add(Me.dgECU)
        Me.fraECU.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraECU.Location = New System.Drawing.Point(672, 4)
        Me.fraECU.Name = "fraECU"
        Me.fraECU.Size = New System.Drawing.Size(388, 232)
        Me.fraECU.TabIndex = 252
        Me.fraECU.TabStop = False
        Me.fraECU.Text = "ECU"
        '
        'dgECU
        '
        Me.dgECU.AllowDrop = True
        Me.dgECU.AllowUserToAddRows = False
        Me.dgECU.AllowUserToDeleteRows = False
        Me.dgECU.AllowUserToOrderColumns = True
        Me.dgECU.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.NullValue = Nothing
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgECU.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgECU.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgECU.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgECU.Location = New System.Drawing.Point(3, 16)
        Me.dgECU.Name = "dgECU"
        Me.dgECU.ReadOnly = True
        Me.dgECU.RowHeadersVisible = False
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgECU.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgECU.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgECU.ShowCellErrors = False
        Me.dgECU.ShowCellToolTips = False
        Me.dgECU.ShowEditingIcon = False
        Me.dgECU.ShowRowErrors = False
        Me.dgECU.Size = New System.Drawing.Size(382, 213)
        Me.dgECU.TabIndex = 247
        '
        'txtSICCode
        '
        Me.txtSICCode.AllowDrop = True
        Me.txtSICCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSICCode.Enabled = False
        Me.txtSICCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSICCode.Location = New System.Drawing.Point(357, 215)
        Me.txtSICCode.Name = "txtSICCode"
        Me.txtSICCode.Size = New System.Drawing.Size(160, 20)
        Me.txtSICCode.TabIndex = 265
        Me.txtSICCode.Tag = ""
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(301, 215)
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
        Me.cboAccountInvoicedStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAccountInvoicedStatus.FormattingEnabled = True
        Me.cboAccountInvoicedStatus.Location = New System.Drawing.Point(105, 103)
        Me.cboAccountInvoicedStatus.Name = "cboAccountInvoicedStatus"
        Me.cboAccountInvoicedStatus.Size = New System.Drawing.Size(108, 21)
        Me.cboAccountInvoicedStatus.TabIndex = 4
        Me.cboAccountInvoicedStatus.Tag = "@DB=AssessmentsRE.AccountInvoicedStatus"
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(13, 103)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(92, 20)
        Me.Label10.TabIndex = 264
        Me.Label10.Text = "Account Invoiced"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboOccupiedStatus
        '
        Me.cboOccupiedStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboOccupiedStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboOccupiedStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboOccupiedStatus.FormattingEnabled = True
        Me.cboOccupiedStatus.Location = New System.Drawing.Point(105, 79)
        Me.cboOccupiedStatus.Name = "cboOccupiedStatus"
        Me.cboOccupiedStatus.Size = New System.Drawing.Size(136, 21)
        Me.cboOccupiedStatus.TabIndex = 3
        Me.cboOccupiedStatus.Tag = "@DB=AssessmentsRE.OccupiedStatus"
        '
        'txtConsultantName
        '
        Me.txtConsultantName.AllowDrop = True
        Me.txtConsultantName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtConsultantName.Enabled = False
        Me.txtConsultantName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConsultantName.Location = New System.Drawing.Point(145, 215)
        Me.txtConsultantName.Name = "txtConsultantName"
        Me.txtConsultantName.Size = New System.Drawing.Size(154, 20)
        Me.txtConsultantName.TabIndex = 261
        Me.txtConsultantName.Tag = ""
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(9, 79)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 18)
        Me.Label5.TabIndex = 251
        Me.Label5.Text = "Occupied/Leased"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(81, 215)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(62, 20)
        Me.Label9.TabIndex = 262
        Me.Label9.Text = "Consultant"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Panel2)
        Me.TabPage2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1294, 273)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Property"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.grpComments)
        Me.Panel2.Controls.Add(Me.GroupBox4)
        Me.Panel2.Controls.Add(Me.GroupBox3)
        Me.Panel2.Controls.Add(Me.txtValueMethodTarget)
        Me.Panel2.Controls.Add(Me.Label29)
        Me.Panel2.Controls.Add(Me.txtValueMethodEquity)
        Me.Panel2.Controls.Add(Me.Label26)
        Me.Panel2.Controls.Add(Me.txtValueMethodMarket)
        Me.Panel2.Controls.Add(Me.GroupBox2)
        Me.Panel2.Controls.Add(Me.cboValueMethod)
        Me.Panel2.Controls.Add(Me.Label28)
        Me.Panel2.Controls.Add(Me.Label27)
        Me.Panel2.Controls.Add(Me.Label25)
        Me.Panel2.Controls.Add(Me.txtValueMethodCost)
        Me.Panel2.Controls.Add(Me.txtValueMethodIncome)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1288, 267)
        Me.Panel2.TabIndex = 1
        '
        'grpComments
        '
        Me.grpComments.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.grpComments.Controls.Add(Me.SplitContainer2)
        Me.grpComments.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpComments.Location = New System.Drawing.Point(812, 8)
        Me.grpComments.Name = "grpComments"
        Me.grpComments.Size = New System.Drawing.Size(468, 252)
        Me.grpComments.TabIndex = 302
        Me.grpComments.TabStop = False
        Me.grpComments.Text = "Proforma Notes"
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer2.Location = New System.Drawing.Point(3, 16)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.cmdNewComment)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.dgComments)
        Me.SplitContainer2.Size = New System.Drawing.Size(462, 233)
        Me.SplitContainer2.SplitterDistance = 25
        Me.SplitContainer2.TabIndex = 233
        '
        'cmdNewComment
        '
        Me.cmdNewComment.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNewComment.Location = New System.Drawing.Point(0, 0)
        Me.cmdNewComment.Name = "cmdNewComment"
        Me.cmdNewComment.Size = New System.Drawing.Size(72, 20)
        Me.cmdNewComment.TabIndex = 231
        Me.cmdNewComment.Text = "Comment"
        Me.cmdNewComment.UseVisualStyleBackColor = True
        '
        'dgComments
        '
        Me.dgComments.AllowDrop = True
        Me.dgComments.AllowUserToAddRows = False
        Me.dgComments.AllowUserToDeleteRows = False
        Me.dgComments.AllowUserToOrderColumns = True
        Me.dgComments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgComments.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgComments.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.ChangeDate, Me.Comment})
        Me.dgComments.ContextMenuStrip = Me.ContextMenuStrip3
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgComments.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgComments.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgComments.Location = New System.Drawing.Point(0, 0)
        Me.dgComments.Margin = New System.Windows.Forms.Padding(0)
        Me.dgComments.Name = "dgComments"
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgComments.RowsDefaultCellStyle = DataGridViewCellStyle9
        Me.dgComments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgComments.ShowCellErrors = False
        Me.dgComments.ShowCellToolTips = False
        Me.dgComments.ShowEditingIcon = False
        Me.dgComments.ShowRowErrors = False
        Me.dgComments.Size = New System.Drawing.Size(462, 204)
        Me.dgComments.TabIndex = 230
        '
        'ID
        '
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ID.DefaultCellStyle = DataGridViewCellStyle5
        Me.ID.HeaderText = "Column1"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Visible = False
        '
        'ChangeDate
        '
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChangeDate.DefaultCellStyle = DataGridViewCellStyle6
        Me.ChangeDate.FillWeight = 142.132!
        Me.ChangeDate.HeaderText = "Date/Time"
        Me.ChangeDate.MinimumWidth = 100
        Me.ChangeDate.Name = "ChangeDate"
        Me.ChangeDate.ReadOnly = True
        '
        'Comment
        '
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Comment.DefaultCellStyle = DataGridViewCellStyle7
        Me.Comment.FillWeight = 57.86803!
        Me.Comment.HeaderText = "Comment"
        Me.Comment.MinimumWidth = 250
        Me.Comment.Name = "Comment"
        '
        'ContextMenuStrip3
        '
        Me.ContextMenuStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuContextDeleteComment})
        Me.ContextMenuStrip3.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip3.Size = New System.Drawing.Size(108, 26)
        '
        'mnuContextDeleteComment
        '
        Me.mnuContextDeleteComment.Name = "mnuContextDeleteComment"
        Me.mnuContextDeleteComment.Size = New System.Drawing.Size(107, 22)
        Me.mnuContextDeleteComment.Text = "Delete"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtLeaseupCommissionPct)
        Me.GroupBox4.Controls.Add(Me.Label41)
        Me.GroupBox4.Controls.Add(Me.txtLeaseupTotIncCostPerSqFt)
        Me.GroupBox4.Controls.Add(Me.Label40)
        Me.GroupBox4.Controls.Add(Me.txtLeaseupVacantSqFt)
        Me.GroupBox4.Controls.Add(Me.Label35)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(624, 8)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(184, 92)
        Me.GroupBox4.TabIndex = 301
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "W/Leaseup"
        '
        'txtLeaseupCommissionPct
        '
        Me.txtLeaseupCommissionPct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLeaseupCommissionPct.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLeaseupCommissionPct.Location = New System.Drawing.Point(84, 64)
        Me.txtLeaseupCommissionPct.Name = "txtLeaseupCommissionPct"
        Me.txtLeaseupCommissionPct.Size = New System.Drawing.Size(92, 20)
        Me.txtLeaseupCommissionPct.TabIndex = 302
        Me.txtLeaseupCommissionPct.Tag = "@DB=AssessmentsRE.LeaseupCommissionPct;@fmt=pct"
        Me.txtLeaseupCommissionPct.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtLeaseupCommissionPct.WordWrap = False
        '
        'Label41
        '
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(4, 64)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(80, 16)
        Me.Label41.TabIndex = 303
        Me.Label41.Text = "Commission %"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtLeaseupTotIncCostPerSqFt
        '
        Me.txtLeaseupTotIncCostPerSqFt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLeaseupTotIncCostPerSqFt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLeaseupTotIncCostPerSqFt.Location = New System.Drawing.Point(84, 40)
        Me.txtLeaseupTotIncCostPerSqFt.Name = "txtLeaseupTotIncCostPerSqFt"
        Me.txtLeaseupTotIncCostPerSqFt.Size = New System.Drawing.Size(92, 20)
        Me.txtLeaseupTotIncCostPerSqFt.TabIndex = 300
        Me.txtLeaseupTotIncCostPerSqFt.Tag = "@DB=AssessmentsRE.LeaseupTotIncCostPerSqFt;@fmt=int"
        Me.txtLeaseupTotIncCostPerSqFt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtLeaseupTotIncCostPerSqFt.WordWrap = False
        '
        'Label40
        '
        Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(4, 40)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(80, 16)
        Me.Label40.TabIndex = 301
        Me.Label40.Text = "TI Cost PSF"
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtLeaseupVacantSqFt
        '
        Me.txtLeaseupVacantSqFt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLeaseupVacantSqFt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLeaseupVacantSqFt.Location = New System.Drawing.Point(84, 16)
        Me.txtLeaseupVacantSqFt.Name = "txtLeaseupVacantSqFt"
        Me.txtLeaseupVacantSqFt.Size = New System.Drawing.Size(92, 20)
        Me.txtLeaseupVacantSqFt.TabIndex = 298
        Me.txtLeaseupVacantSqFt.Tag = "@DB=AssessmentsRE.LeaseupVacantSqFt;@fmt=int"
        Me.txtLeaseupVacantSqFt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtLeaseupVacantSqFt.WordWrap = False
        '
        'Label35
        '
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(4, 16)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(80, 16)
        Me.Label35.TabIndex = 299
        Me.Label35.Text = "Vacant Sq Ft"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtMarketNonReimbPct)
        Me.GroupBox3.Controls.Add(Me.Label42)
        Me.GroupBox3.Controls.Add(Me.txtMarketReimbRevenue)
        Me.GroupBox3.Controls.Add(Me.txtMarketCapRate)
        Me.GroupBox3.Controls.Add(Me.txtMarketRentPerSqFt)
        Me.GroupBox3.Controls.Add(Me.Label34)
        Me.GroupBox3.Controls.Add(Me.txtMarketCommonAreaMaintPct)
        Me.GroupBox3.Controls.Add(Me.Label33)
        Me.GroupBox3.Controls.Add(Me.Label36)
        Me.GroupBox3.Controls.Add(Me.Label32)
        Me.GroupBox3.Controls.Add(Me.txtMarketMgmtFeesPct)
        Me.GroupBox3.Controls.Add(Me.txtMarketTaxRate)
        Me.GroupBox3.Controls.Add(Me.Label37)
        Me.GroupBox3.Controls.Add(Me.Label31)
        Me.GroupBox3.Controls.Add(Me.Label38)
        Me.GroupBox3.Controls.Add(Me.txtMarketAddlRevenue)
        Me.GroupBox3.Controls.Add(Me.Label39)
        Me.GroupBox3.Controls.Add(Me.Label30)
        Me.GroupBox3.Controls.Add(Me.txtMarketVacCollLossPct)
        Me.GroupBox3.Controls.Add(Me.txtMarketPropInsPct)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(404, 8)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(212, 256)
        Me.GroupBox3.TabIndex = 300
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Market Proforma"
        '
        'txtMarketNonReimbPct
        '
        Me.txtMarketNonReimbPct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMarketNonReimbPct.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMarketNonReimbPct.Location = New System.Drawing.Point(112, 136)
        Me.txtMarketNonReimbPct.Name = "txtMarketNonReimbPct"
        Me.txtMarketNonReimbPct.Size = New System.Drawing.Size(92, 20)
        Me.txtMarketNonReimbPct.TabIndex = 298
        Me.txtMarketNonReimbPct.Tag = "@DB=AssessmentsRE.MarketNonReimbPct;@fmt=pct"
        Me.txtMarketNonReimbPct.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtMarketNonReimbPct.WordWrap = False
        '
        'Label42
        '
        Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.Location = New System.Drawing.Point(16, 140)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(96, 12)
        Me.Label42.TabIndex = 299
        Me.Label42.Text = "Non-Reimb %"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtMarketReimbRevenue
        '
        Me.txtMarketReimbRevenue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMarketReimbRevenue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMarketReimbRevenue.Location = New System.Drawing.Point(112, 112)
        Me.txtMarketReimbRevenue.Name = "txtMarketReimbRevenue"
        Me.txtMarketReimbRevenue.Size = New System.Drawing.Size(92, 20)
        Me.txtMarketReimbRevenue.TabIndex = 288
        Me.txtMarketReimbRevenue.Tag = "@DB=AssessmentsRE.MarketReimbRevenuePerSqFt;@fmt=int"
        Me.txtMarketReimbRevenue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtMarketReimbRevenue.WordWrap = False
        '
        'txtMarketCapRate
        '
        Me.txtMarketCapRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMarketCapRate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMarketCapRate.Location = New System.Drawing.Point(112, 40)
        Me.txtMarketCapRate.Name = "txtMarketCapRate"
        Me.txtMarketCapRate.Size = New System.Drawing.Size(92, 20)
        Me.txtMarketCapRate.TabIndex = 283
        Me.txtMarketCapRate.Tag = "@DB=AssessmentsRE.MarketCapRate;@fmt=int"
        Me.txtMarketCapRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtMarketCapRate.WordWrap = False
        '
        'txtMarketRentPerSqFt
        '
        Me.txtMarketRentPerSqFt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMarketRentPerSqFt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMarketRentPerSqFt.Location = New System.Drawing.Point(112, 16)
        Me.txtMarketRentPerSqFt.Name = "txtMarketRentPerSqFt"
        Me.txtMarketRentPerSqFt.Size = New System.Drawing.Size(92, 20)
        Me.txtMarketRentPerSqFt.TabIndex = 282
        Me.txtMarketRentPerSqFt.Tag = "@DB=AssessmentsRE.MarketRentPerSqFt;@fmt=int"
        Me.txtMarketRentPerSqFt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtMarketRentPerSqFt.WordWrap = False
        '
        'Label34
        '
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(16, 20)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(96, 16)
        Me.Label34.TabIndex = 280
        Me.Label34.Text = "Market Rent PSF"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtMarketCommonAreaMaintPct
        '
        Me.txtMarketCommonAreaMaintPct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMarketCommonAreaMaintPct.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMarketCommonAreaMaintPct.Location = New System.Drawing.Point(112, 232)
        Me.txtMarketCommonAreaMaintPct.Name = "txtMarketCommonAreaMaintPct"
        Me.txtMarketCommonAreaMaintPct.Size = New System.Drawing.Size(92, 20)
        Me.txtMarketCommonAreaMaintPct.TabIndex = 296
        Me.txtMarketCommonAreaMaintPct.Tag = "@DB=AssessmentsRE.MarketCommonAreaMaintPct;@fmt=pct"
        Me.txtMarketCommonAreaMaintPct.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtMarketCommonAreaMaintPct.WordWrap = False
        '
        'Label33
        '
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(16, 44)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(96, 12)
        Me.Label33.TabIndex = 281
        Me.Label33.Text = "Cap Rate"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label36
        '
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(16, 236)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(96, 12)
        Me.Label36.TabIndex = 297
        Me.Label36.Text = "CAM %"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label32
        '
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(16, 68)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(96, 16)
        Me.Label32.TabIndex = 285
        Me.Label32.Text = "Tax Rate"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtMarketMgmtFeesPct
        '
        Me.txtMarketMgmtFeesPct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMarketMgmtFeesPct.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMarketMgmtFeesPct.Location = New System.Drawing.Point(112, 208)
        Me.txtMarketMgmtFeesPct.Name = "txtMarketMgmtFeesPct"
        Me.txtMarketMgmtFeesPct.Size = New System.Drawing.Size(92, 20)
        Me.txtMarketMgmtFeesPct.TabIndex = 294
        Me.txtMarketMgmtFeesPct.Tag = "@DB=AssessmentsRE.MarketMgmtFeesPct;@fmt=pct"
        Me.txtMarketMgmtFeesPct.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtMarketMgmtFeesPct.WordWrap = False
        '
        'txtMarketTaxRate
        '
        Me.txtMarketTaxRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMarketTaxRate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMarketTaxRate.Location = New System.Drawing.Point(112, 64)
        Me.txtMarketTaxRate.Name = "txtMarketTaxRate"
        Me.txtMarketTaxRate.Size = New System.Drawing.Size(92, 20)
        Me.txtMarketTaxRate.TabIndex = 284
        Me.txtMarketTaxRate.Tag = "@DB=AssessmentsRE.MarketTaxRate;@fmt=int"
        Me.txtMarketTaxRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtMarketTaxRate.WordWrap = False
        '
        'Label37
        '
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(16, 212)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(96, 12)
        Me.Label37.TabIndex = 295
        Me.Label37.Text = "Mgmt Fees %"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label31
        '
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(4, 92)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(108, 16)
        Me.Label31.TabIndex = 287
        Me.Label31.Text = "Addl Revenue PSF"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label38
        '
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(16, 188)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(96, 12)
        Me.Label38.TabIndex = 291
        Me.Label38.Text = "Property Ins %"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtMarketAddlRevenue
        '
        Me.txtMarketAddlRevenue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMarketAddlRevenue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMarketAddlRevenue.Location = New System.Drawing.Point(112, 88)
        Me.txtMarketAddlRevenue.Name = "txtMarketAddlRevenue"
        Me.txtMarketAddlRevenue.Size = New System.Drawing.Size(92, 20)
        Me.txtMarketAddlRevenue.TabIndex = 286
        Me.txtMarketAddlRevenue.Tag = "@DB=AssessmentsRE.MarketAddlRevenuePerSqFt;@fmt=int"
        Me.txtMarketAddlRevenue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtMarketAddlRevenue.WordWrap = False
        '
        'Label39
        '
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(16, 164)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(96, 12)
        Me.Label39.TabIndex = 290
        Me.Label39.Text = "Vac & Coll Loss %"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label30
        '
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(0, 116)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(112, 16)
        Me.Label30.TabIndex = 289
        Me.Label30.Text = "Reimb Revenue PSF"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtMarketVacCollLossPct
        '
        Me.txtMarketVacCollLossPct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMarketVacCollLossPct.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMarketVacCollLossPct.Location = New System.Drawing.Point(112, 160)
        Me.txtMarketVacCollLossPct.Name = "txtMarketVacCollLossPct"
        Me.txtMarketVacCollLossPct.Size = New System.Drawing.Size(92, 20)
        Me.txtMarketVacCollLossPct.TabIndex = 292
        Me.txtMarketVacCollLossPct.Tag = "@DB=AssessmentsRE.MarketVacCollLossPct;@fmt=pct"
        Me.txtMarketVacCollLossPct.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtMarketVacCollLossPct.WordWrap = False
        '
        'txtMarketPropInsPct
        '
        Me.txtMarketPropInsPct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMarketPropInsPct.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMarketPropInsPct.Location = New System.Drawing.Point(112, 184)
        Me.txtMarketPropInsPct.Name = "txtMarketPropInsPct"
        Me.txtMarketPropInsPct.Size = New System.Drawing.Size(92, 20)
        Me.txtMarketPropInsPct.TabIndex = 293
        Me.txtMarketPropInsPct.Tag = "@DB=AssessmentsRE.MarketPropInsPct;@fmt=pct"
        Me.txtMarketPropInsPct.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtMarketPropInsPct.WordWrap = False
        '
        'txtValueMethodTarget
        '
        Me.txtValueMethodTarget.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtValueMethodTarget.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValueMethodTarget.Location = New System.Drawing.Point(708, 232)
        Me.txtValueMethodTarget.Name = "txtValueMethodTarget"
        Me.txtValueMethodTarget.Size = New System.Drawing.Size(92, 20)
        Me.txtValueMethodTarget.TabIndex = 278
        Me.txtValueMethodTarget.Tag = "@DB=AssessmentsRE.ValueMethodTarget;@fmt=int"
        Me.txtValueMethodTarget.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtValueMethodTarget.WordWrap = False
        '
        'Label29
        '
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(660, 236)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(44, 12)
        Me.Label29.TabIndex = 279
        Me.Label29.Text = "Target"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtValueMethodEquity
        '
        Me.txtValueMethodEquity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtValueMethodEquity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValueMethodEquity.Location = New System.Drawing.Point(708, 208)
        Me.txtValueMethodEquity.Name = "txtValueMethodEquity"
        Me.txtValueMethodEquity.Size = New System.Drawing.Size(92, 20)
        Me.txtValueMethodEquity.TabIndex = 276
        Me.txtValueMethodEquity.Tag = "@DB=AssessmentsRE.ValueMethodEquity;@fmt=int"
        Me.txtValueMethodEquity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtValueMethodEquity.WordWrap = False
        '
        'Label26
        '
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(660, 212)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(44, 12)
        Me.Label26.TabIndex = 277
        Me.Label26.Text = "Equity"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtCeilingHeight)
        Me.GroupBox2.Controls.Add(Me.Label43)
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
        Me.GroupBox2.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(392, 164)
        Me.GroupBox2.TabIndex = 206
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Property Details"
        '
        'txtCeilingHeight
        '
        Me.txtCeilingHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCeilingHeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCeilingHeight.Location = New System.Drawing.Point(88, 136)
        Me.txtCeilingHeight.Name = "txtCeilingHeight"
        Me.txtCeilingHeight.Size = New System.Drawing.Size(60, 20)
        Me.txtCeilingHeight.TabIndex = 152
        Me.txtCeilingHeight.Tag = "@DB=AssessmentsRE.CeilingHeight;@fmt=int"
        Me.txtCeilingHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtCeilingHeight.WordWrap = False
        '
        'Label43
        '
        Me.Label43.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.Location = New System.Drawing.Point(6, 140)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(80, 16)
        Me.Label43.TabIndex = 151
        Me.Label43.Text = "Ceiling Height"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.txtExcessLandSqFt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
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
        Me.txtLandSqFt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
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
        Me.txtGrossLeasableSqFt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
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
        Me.txtYearBuilt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
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
        Me.txtEffYearBuilt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
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
        Me.txtBuildingSqFt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
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
        Me.txtNetLeasableSqFt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
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
        Me.fraCollectors.Location = New System.Drawing.Point(496, 4)
        Me.fraCollectors.Name = "fraCollectors"
        Me.fraCollectors.Size = New System.Drawing.Size(760, 136)
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
        Me.dgCollectors.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgCollectors.Location = New System.Drawing.Point(3, 16)
        Me.dgCollectors.Name = "dgCollectors"
        Me.dgCollectors.RowHeadersVisible = False
        Me.dgCollectors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgCollectors.ShowCellErrors = False
        Me.dgCollectors.ShowCellToolTips = False
        Me.dgCollectors.ShowEditingIcon = False
        Me.dgCollectors.ShowRowErrors = False
        Me.dgCollectors.Size = New System.Drawing.Size(754, 117)
        Me.dgCollectors.TabIndex = 212
        '
        'frmREAssessment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1302, 735)
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
        CType(Me.dgHistory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.fraECU.ResumeLayout(False)
        CType(Me.dgECU, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.grpComments.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.dgComments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.fraCollectors.ResumeLayout(False)
        CType(Me.dgCollectors, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents cmdOpenAssessor As Button
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents txtValueMethodTarget As TextBox
    Friend WithEvents Label29 As Label
    Friend WithEvents txtValueMethodEquity As TextBox
    Friend WithEvents Label26 As Label
    Friend WithEvents txtLeaseupVacantSqFt As TextBox
    Friend WithEvents Label35 As Label
    Friend WithEvents txtMarketCommonAreaMaintPct As TextBox
    Friend WithEvents Label36 As Label
    Friend WithEvents txtMarketMgmtFeesPct As TextBox
    Friend WithEvents Label37 As Label
    Friend WithEvents Label38 As Label
    Friend WithEvents Label39 As Label
    Friend WithEvents txtMarketVacCollLossPct As TextBox
    Friend WithEvents txtMarketPropInsPct As TextBox
    Friend WithEvents txtMarketReimbRevenue As TextBox
    Friend WithEvents Label30 As Label
    Friend WithEvents txtMarketAddlRevenue As TextBox
    Friend WithEvents Label31 As Label
    Friend WithEvents txtMarketTaxRate As TextBox
    Friend WithEvents Label32 As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents Label34 As Label
    Friend WithEvents txtMarketRentPerSqFt As TextBox
    Friend WithEvents txtMarketCapRate As TextBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents txtLeaseupCommissionPct As TextBox
    Friend WithEvents Label41 As Label
    Friend WithEvents txtLeaseupTotIncCostPerSqFt As TextBox
    Friend WithEvents Label40 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents grpComments As GroupBox
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents cmdNewComment As Button
    Friend WithEvents dgComments As DataGridView
    Friend WithEvents ContextMenuStrip3 As ContextMenuStrip
    Friend WithEvents mnuContextDeleteComment As ToolStripMenuItem
    Friend WithEvents ID As DataGridViewTextBoxColumn
    Friend WithEvents ChangeDate As DataGridViewTextBoxColumn
    Friend WithEvents Comment As DataGridViewTextBoxColumn
    Friend WithEvents txtMarketNonReimbPct As TextBox
    Friend WithEvents Label42 As Label
    Friend WithEvents txtCeilingHeight As TextBox
    Friend WithEvents Label43 As Label
End Class
