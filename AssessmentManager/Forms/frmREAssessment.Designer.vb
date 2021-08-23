<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmREAssessment
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.dgCollectors = New System.Windows.Forms.DataGridView()
        Me.CollectorId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Collector = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FormData = New System.Windows.Forms.DataGridViewButtonColumn()
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.txtSICCode = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cboAccountInvoicedStatus = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtConsultantName = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmdECU = New System.Windows.Forms.Button()
        Me.fraECU = New System.Windows.Forms.GroupBox()
        Me.dgECU = New System.Windows.Forms.DataGridView()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboOccupiedStatus = New System.Windows.Forms.ComboBox()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgCollectors, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip2.SuspendLayout()
        CType(Me.dgJurisdictions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraHistory.SuspendLayout()
        CType(Me.dgHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.fraECU.SuspendLayout()
        CType(Me.dgECU, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cboAssessor
        '
        Me.cboAssessor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAssessor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAssessor.FormattingEnabled = True
        Me.cboAssessor.Location = New System.Drawing.Point(120, 28)
        Me.cboAssessor.Name = "cboAssessor"
        Me.cboAssessor.Size = New System.Drawing.Size(221, 21)
        Me.cboAssessor.TabIndex = 1
        Me.cboAssessor.Tag = "@DB=AssessmentsRE.AssessorId"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(40, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 17)
        Me.Label2.TabIndex = 132
        Me.Label2.Text = "Assessor"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(20, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 18)
        Me.Label1.TabIndex = 130
        Me.Label1.Text = "Account Number"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtAcctNum
        '
        Me.txtAcctNum.Location = New System.Drawing.Point(120, 6)
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
        Me.GroupBox1.Location = New System.Drawing.Point(378, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(340, 136)
        Me.GroupBox1.TabIndex = 194
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Value Protest"
        '
        'chkValueProtestFl
        '
        Me.chkValueProtestFl.AutoSize = True
        Me.chkValueProtestFl.Location = New System.Drawing.Point(111, 20)
        Me.chkValueProtestFl.Name = "chkValueProtestFl"
        Me.chkValueProtestFl.Size = New System.Drawing.Size(15, 14)
        Me.chkValueProtestFl.TabIndex = 4
        Me.chkValueProtestFl.Tag = "@DB=AssessmentsRE.ValueProtestFl"
        Me.chkValueProtestFl.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(14, 17)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(91, 19)
        Me.Label17.TabIndex = 205
        Me.Label17.Text = "Protested"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(15, 39)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(91, 19)
        Me.Label8.TabIndex = 202
        Me.Label8.Text = "Mailed Date"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(15, 62)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(91, 19)
        Me.Label7.TabIndex = 201
        Me.Label7.Text = "CMRRR"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 110)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(102, 19)
        Me.Label6.TabIndex = 200
        Me.Label6.Text = "Hearing Date/Time"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(15, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 19)
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
        Me.txtValueProtestHearingDate.Location = New System.Drawing.Point(111, 110)
        Me.txtValueProtestHearingDate.Name = "txtValueProtestHearingDate"
        Me.txtValueProtestHearingDate.Size = New System.Drawing.Size(118, 20)
        Me.txtValueProtestHearingDate.TabIndex = 11
        Me.txtValueProtestHearingDate.Tag = "@DB=AssessmentsRE.ValueProtestHearingDate;@fmt=datetime"
        '
        'txtValueProtestCMRRR
        '
        Me.txtValueProtestCMRRR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValueProtestCMRRR.Location = New System.Drawing.Point(111, 62)
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
        Me.cboValueProtestStatus.Location = New System.Drawing.Point(111, 84)
        Me.cboValueProtestStatus.Name = "cboValueProtestStatus"
        Me.cboValueProtestStatus.Size = New System.Drawing.Size(221, 21)
        Me.cboValueProtestStatus.TabIndex = 8
        Me.cboValueProtestStatus.Tag = "@DB=AssessmentsRE.ValueProtestStatus"
        '
        'txtValueProtestMailedDate
        '
        Me.txtValueProtestMailedDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValueProtestMailedDate.Location = New System.Drawing.Point(111, 39)
        Me.txtValueProtestMailedDate.Name = "txtValueProtestMailedDate"
        Me.txtValueProtestMailedDate.Size = New System.Drawing.Size(72, 20)
        Me.txtValueProtestMailedDate.TabIndex = 6
        Me.txtValueProtestMailedDate.Tag = "@DB=AssessmentsRE.ValueProtestMailedDate;@fmt=date"
        '
        'dgCollectors
        '
        Me.dgCollectors.AllowUserToAddRows = False
        Me.dgCollectors.AllowUserToDeleteRows = False
        Me.dgCollectors.AllowUserToOrderColumns = True
        Me.dgCollectors.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dgCollectors.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgCollectors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCollectors.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CollectorId, Me.Collector, Me.Total, Me.FormData})
        Me.dgCollectors.ContextMenuStrip = Me.ContextMenuStrip2
        Me.dgCollectors.Location = New System.Drawing.Point(525, 143)
        Me.dgCollectors.Name = "dgCollectors"
        Me.dgCollectors.RowHeadersVisible = False
        Me.dgCollectors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgCollectors.ShowCellErrors = False
        Me.dgCollectors.ShowCellToolTips = False
        Me.dgCollectors.ShowEditingIcon = False
        Me.dgCollectors.ShowRowErrors = False
        Me.dgCollectors.Size = New System.Drawing.Size(355, 121)
        Me.dgCollectors.TabIndex = 216
        Me.dgCollectors.Visible = False
        '
        'CollectorId
        '
        Me.CollectorId.HeaderText = "Collector ID"
        Me.CollectorId.Name = "CollectorId"
        Me.CollectorId.ReadOnly = True
        Me.CollectorId.Visible = False
        Me.CollectorId.Width = 68
        '
        'Collector
        '
        Me.Collector.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Collector.HeaderText = "Collector"
        Me.Collector.Name = "Collector"
        Me.Collector.ReadOnly = True
        Me.Collector.Width = 175
        '
        'Total
        '
        Me.Total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Total.DefaultCellStyle = DataGridViewCellStyle1
        Me.Total.HeaderText = "Total"
        Me.Total.Name = "Total"
        Me.Total.ReadOnly = True
        '
        'FormData
        '
        Me.FormData.HeaderText = "Tax Bill"
        Me.FormData.Name = "FormData"
        Me.FormData.ReadOnly = True
        Me.FormData.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.FormData.Width = 47
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
        Me.dgJurisdictions.Size = New System.Drawing.Size(1213, 344)
        Me.dgJurisdictions.TabIndex = 133
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(8, 122)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(98, 19)
        Me.Label11.TabIndex = 209
        Me.Label11.Text = "Comments"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtComment
        '
        Me.txtComment.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComment.Location = New System.Drawing.Point(8, 144)
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
        Me.Label21.Location = New System.Drawing.Point(48, 54)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(64, 16)
        Me.Label21.TabIndex = 223
        Me.Label21.Text = "Client ID"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtClientLocationId
        '
        Me.txtClientLocationId.Location = New System.Drawing.Point(120, 52)
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
        Me.fraHistory.Location = New System.Drawing.Point(998, 6)
        Me.fraHistory.Name = "fraHistory"
        Me.fraHistory.Size = New System.Drawing.Size(210, 130)
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
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = Nothing
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgHistory.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgHistory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgHistory.Location = New System.Drawing.Point(3, 16)
        Me.dgHistory.Name = "dgHistory"
        Me.dgHistory.ReadOnly = True
        Me.dgHistory.RowHeadersVisible = False
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgHistory.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgHistory.ShowCellErrors = False
        Me.dgHistory.ShowCellToolTips = False
        Me.dgHistory.ShowEditingIcon = False
        Me.dgHistory.ShowRowErrors = False
        Me.dgHistory.Size = New System.Drawing.Size(204, 111)
        Me.dgHistory.TabIndex = 247
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtSICCode)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label12)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cboAccountInvoicedStatus)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label10)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtConsultantName)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label9)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdECU)
        Me.SplitContainer1.Panel1.Controls.Add(Me.fraECU)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cboOccupiedStatus)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdNewJurisdiction)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtAcctNum)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label21)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtClientLocationId)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.fraHistory)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdRefresh)
        Me.SplitContainer1.Panel1.Controls.Add(Me.dgCollectors)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cboAssessor)
        Me.SplitContainer1.Panel1.Controls.Add(Me.chkInactiveFl)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtComment)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblTaxBillTotal)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label11)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtTaxBillTotal)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdTaxBillDetail)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgJurisdictions)
        Me.SplitContainer1.Size = New System.Drawing.Size(1213, 618)
        Me.SplitContainer1.SplitterDistance = 271
        Me.SplitContainer1.SplitterWidth = 3
        Me.SplitContainer1.TabIndex = 250
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
        Me.cboAccountInvoicedStatus.Location = New System.Drawing.Point(120, 96)
        Me.cboAccountInvoicedStatus.Name = "cboAccountInvoicedStatus"
        Me.cboAccountInvoicedStatus.Size = New System.Drawing.Size(108, 21)
        Me.cboAccountInvoicedStatus.TabIndex = 4
        Me.cboAccountInvoicedStatus.Tag = "@DB=AssessmentsRE.AccountInvoicedStatus"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(8, 96)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(104, 20)
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
        Me.cmdECU.Location = New System.Drawing.Point(734, 6)
        Me.cmdECU.Name = "cmdECU"
        Me.cmdECU.Size = New System.Drawing.Size(68, 20)
        Me.cmdECU.TabIndex = 253
        Me.cmdECU.Text = "ECU"
        Me.cmdECU.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdECU.UseVisualStyleBackColor = True
        '
        'fraECU
        '
        Me.fraECU.Controls.Add(Me.dgECU)
        Me.fraECU.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraECU.Location = New System.Drawing.Point(804, 8)
        Me.fraECU.Name = "fraECU"
        Me.fraECU.Size = New System.Drawing.Size(388, 256)
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
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.Format = "N0"
        DataGridViewCellStyle4.NullValue = Nothing
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgECU.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgECU.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgECU.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgECU.Location = New System.Drawing.Point(3, 16)
        Me.dgECU.Name = "dgECU"
        Me.dgECU.ReadOnly = True
        Me.dgECU.RowHeadersVisible = False
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgECU.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgECU.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgECU.ShowCellErrors = False
        Me.dgECU.ShowCellToolTips = False
        Me.dgECU.ShowEditingIcon = False
        Me.dgECU.ShowRowErrors = False
        Me.dgECU.Size = New System.Drawing.Size(382, 237)
        Me.dgECU.TabIndex = 247
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(4, 74)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(107, 15)
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
        Me.cboOccupiedStatus.Location = New System.Drawing.Point(120, 72)
        Me.cboOccupiedStatus.Name = "cboOccupiedStatus"
        Me.cboOccupiedStatus.Size = New System.Drawing.Size(136, 21)
        Me.cboOccupiedStatus.TabIndex = 3
        Me.cboOccupiedStatus.Tag = "@DB=AssessmentsRE.OccupiedStatus"
        '
        'frmREAssessment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1213, 618)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmREAssessment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Real Estate Assessment"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgCollectors, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip2.ResumeLayout(False)
        CType(Me.dgJurisdictions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraHistory.ResumeLayout(False)
        CType(Me.dgHistory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
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
    Friend WithEvents dgCollectors As System.Windows.Forms.DataGridView
    Friend WithEvents cmdTaxBillDetail As System.Windows.Forms.Button
    Friend WithEvents chkInactiveFl As System.Windows.Forms.CheckBox
    Friend WithEvents CollectorId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Collector As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Total As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FormData As System.Windows.Forms.DataGridViewButtonColumn
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
End Class
