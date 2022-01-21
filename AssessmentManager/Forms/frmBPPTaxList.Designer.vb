<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmBPPTaxList
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtAcctNum = New System.Windows.Forms.TextBox()
        Me.cboAssessor = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgJurisdictions = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuContextPrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuContextDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmdNewJurisdiction = New System.Windows.Forms.Button()
        Me.fraCollectors = New System.Windows.Forms.GroupBox()
        Me.dgCollectors = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuContextImportTaxBill = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmdRefresh = New System.Windows.Forms.Button()
        Me.cmdTaxBillDetail = New System.Windows.Forms.Button()
        Me.txtTaxBillTotal = New System.Windows.Forms.TextBox()
        Me.lblTaxBillTotal = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtClientLocationId = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtClientRendition2 = New System.Windows.Forms.TextBox()
        Me.txtClientRendition3 = New System.Windows.Forms.TextBox()
        Me.txtClientRendition4 = New System.Windows.Forms.TextBox()
        Me.txtClientRendition5 = New System.Windows.Forms.TextBox()
        Me.txtReclassRendition1 = New System.Windows.Forms.TextBox()
        Me.txtReclassRendition2 = New System.Windows.Forms.TextBox()
        Me.txtReclassRendition3 = New System.Windows.Forms.TextBox()
        Me.txtReclassRendition4 = New System.Windows.Forms.TextBox()
        Me.txtReclassRendition5 = New System.Windows.Forms.TextBox()
        Me.txtClientRendition1 = New System.Windows.Forms.TextBox()
        Me.cboFactorEntity1 = New System.Windows.Forms.ComboBox()
        Me.cboFactorEntity2 = New System.Windows.Forms.ComboBox()
        Me.cboFactorEntity3 = New System.Windows.Forms.ComboBox()
        Me.cboFactorEntity4 = New System.Windows.Forms.ComboBox()
        Me.cboFactorEntity5 = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dgHistory = New System.Windows.Forms.DataGridView()
        Me.fraHistory = New System.Windows.Forms.GroupBox()
        Me.cmdViewAssessment = New System.Windows.Forms.Button()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.txtSICCode = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.chkInterstateAllocationFl = New System.Windows.Forms.CheckBox()
        Me.cboAccountInvoicedStatus = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtConsultantName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.grpComments = New System.Windows.Forms.GroupBox()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.cmdNewComment = New System.Windows.Forms.Button()
        Me.cmdExpandComments = New System.Windows.Forms.Button()
        Me.dgComments = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip3 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuContextDeleteComment = New System.Windows.Forms.ToolStripMenuItem()
        Me.fraECU = New System.Windows.Forms.GroupBox()
        Me.dgECU = New System.Windows.Forms.DataGridView()
        Me.txtRenditionCompleteDate = New System.Windows.Forms.TextBox()
        Me.chkRenditionCompleteFl = New System.Windows.Forms.CheckBox()
        Me.cmdECU = New System.Windows.Forms.Button()
        CType(Me.dgJurisdictions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.fraCollectors.SuspendLayout()
        CType(Me.dgCollectors, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip2.SuspendLayout()
        CType(Me.dgHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraHistory.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.grpComments.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.dgComments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip3.SuspendLayout()
        Me.fraECU.SuspendLayout()
        CType(Me.dgECU, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(4, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 20)
        Me.Label1.TabIndex = 119
        Me.Label1.Text = "Account Number"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtAcctNum
        '
        Me.txtAcctNum.AllowDrop = True
        Me.txtAcctNum.Location = New System.Drawing.Point(100, 16)
        Me.txtAcctNum.Name = "txtAcctNum"
        Me.txtAcctNum.Size = New System.Drawing.Size(221, 20)
        Me.txtAcctNum.TabIndex = 0
        Me.txtAcctNum.Tag = "@DB=AssessmentsBPP.AcctNum"
        '
        'cboAssessor
        '
        Me.cboAssessor.AllowDrop = True
        Me.cboAssessor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAssessor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAssessor.FormattingEnabled = True
        Me.cboAssessor.Location = New System.Drawing.Point(100, 40)
        Me.cboAssessor.Name = "cboAssessor"
        Me.cboAssessor.Size = New System.Drawing.Size(221, 21)
        Me.cboAssessor.TabIndex = 2
        Me.cboAssessor.Tag = "@DB=AssessmentsBPP.AssessorId"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(20, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 20)
        Me.Label2.TabIndex = 128
        Me.Label2.Text = "Assessor"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgJurisdictions
        '
        Me.dgJurisdictions.AllowDrop = True
        Me.dgJurisdictions.AllowUserToAddRows = False
        Me.dgJurisdictions.AllowUserToDeleteRows = False
        Me.dgJurisdictions.AllowUserToOrderColumns = True
        Me.dgJurisdictions.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgJurisdictions.ColumnHeadersHeight = 45
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
        Me.dgJurisdictions.Size = New System.Drawing.Size(1325, 330)
        Me.dgJurisdictions.TabIndex = 25
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
        Me.cmdNewJurisdiction.Location = New System.Drawing.Point(9, 226)
        Me.cmdNewJurisdiction.Name = "cmdNewJurisdiction"
        Me.cmdNewJurisdiction.Size = New System.Drawing.Size(99, 23)
        Me.cmdNewJurisdiction.TabIndex = 23
        Me.cmdNewJurisdiction.Text = "New Jurisdiction"
        Me.cmdNewJurisdiction.UseVisualStyleBackColor = True
        '
        'fraCollectors
        '
        Me.fraCollectors.Controls.Add(Me.dgCollectors)
        Me.fraCollectors.Location = New System.Drawing.Point(567, 108)
        Me.fraCollectors.Name = "fraCollectors"
        Me.fraCollectors.Size = New System.Drawing.Size(749, 141)
        Me.fraCollectors.TabIndex = 219
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
        Me.dgCollectors.Location = New System.Drawing.Point(4, 12)
        Me.dgCollectors.Name = "dgCollectors"
        Me.dgCollectors.RowHeadersVisible = False
        Me.dgCollectors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgCollectors.ShowCellErrors = False
        Me.dgCollectors.ShowCellToolTips = False
        Me.dgCollectors.ShowEditingIcon = False
        Me.dgCollectors.ShowRowErrors = False
        Me.dgCollectors.Size = New System.Drawing.Size(740, 124)
        Me.dgCollectors.TabIndex = 212
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
        Me.cmdRefresh.Location = New System.Drawing.Point(114, 226)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(99, 23)
        Me.cmdRefresh.TabIndex = 24
        Me.cmdRefresh.Text = "Refresh"
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'cmdTaxBillDetail
        '
        Me.cmdTaxBillDetail.Location = New System.Drawing.Point(537, 228)
        Me.cmdTaxBillDetail.Name = "cmdTaxBillDetail"
        Me.cmdTaxBillDetail.Size = New System.Drawing.Size(26, 20)
        Me.cmdTaxBillDetail.TabIndex = 210
        Me.cmdTaxBillDetail.Text = "..."
        Me.cmdTaxBillDetail.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdTaxBillDetail.UseVisualStyleBackColor = True
        '
        'txtTaxBillTotal
        '
        Me.txtTaxBillTotal.AllowDrop = True
        Me.txtTaxBillTotal.BackColor = System.Drawing.SystemColors.Window
        Me.txtTaxBillTotal.Location = New System.Drawing.Point(417, 228)
        Me.txtTaxBillTotal.Name = "txtTaxBillTotal"
        Me.txtTaxBillTotal.ReadOnly = True
        Me.txtTaxBillTotal.Size = New System.Drawing.Size(115, 20)
        Me.txtTaxBillTotal.TabIndex = 211
        Me.txtTaxBillTotal.TabStop = False
        Me.txtTaxBillTotal.Tag = ""
        Me.txtTaxBillTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTaxBillTotal.WordWrap = False
        '
        'lblTaxBillTotal
        '
        Me.lblTaxBillTotal.Location = New System.Drawing.Point(325, 227)
        Me.lblTaxBillTotal.Name = "lblTaxBillTotal"
        Me.lblTaxBillTotal.Size = New System.Drawing.Size(86, 20)
        Me.lblTaxBillTotal.TabIndex = 213
        Me.lblTaxBillTotal.Text = "Tax Bill Total"
        Me.lblTaxBillTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(328, 16)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(50, 20)
        Me.Label21.TabIndex = 221
        Me.Label21.Text = "Client ID"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtClientLocationId
        '
        Me.txtClientLocationId.AllowDrop = True
        Me.txtClientLocationId.Location = New System.Drawing.Point(380, 16)
        Me.txtClientLocationId.Name = "txtClientLocationId"
        Me.txtClientLocationId.Size = New System.Drawing.Size(120, 20)
        Me.txtClientLocationId.TabIndex = 1
        Me.txtClientLocationId.Tag = "@DB=LocationsBPP.ClientLocationId"
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(456, 91)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(98, 19)
        Me.Label24.TabIndex = 246
        Me.Label24.Text = "* County Schedule"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(248, 68)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(98, 19)
        Me.Label10.TabIndex = 245
        Me.Label10.Text = "Client Value"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(352, 68)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(98, 19)
        Me.Label9.TabIndex = 244
        Me.Label9.Text = "Reclassed Value"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtClientRendition2
        '
        Me.txtClientRendition2.AllowDrop = True
        Me.txtClientRendition2.BackColor = System.Drawing.SystemColors.Window
        Me.txtClientRendition2.Location = New System.Drawing.Point(248, 118)
        Me.txtClientRendition2.Name = "txtClientRendition2"
        Me.txtClientRendition2.ReadOnly = True
        Me.txtClientRendition2.Size = New System.Drawing.Size(98, 20)
        Me.txtClientRendition2.TabIndex = 243
        Me.txtClientRendition2.TabStop = False
        Me.txtClientRendition2.Tag = ""
        Me.txtClientRendition2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtClientRendition2.WordWrap = False
        '
        'txtClientRendition3
        '
        Me.txtClientRendition3.AllowDrop = True
        Me.txtClientRendition3.BackColor = System.Drawing.SystemColors.Window
        Me.txtClientRendition3.Location = New System.Drawing.Point(248, 145)
        Me.txtClientRendition3.Name = "txtClientRendition3"
        Me.txtClientRendition3.ReadOnly = True
        Me.txtClientRendition3.Size = New System.Drawing.Size(98, 20)
        Me.txtClientRendition3.TabIndex = 242
        Me.txtClientRendition3.TabStop = False
        Me.txtClientRendition3.Tag = ""
        Me.txtClientRendition3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtClientRendition3.WordWrap = False
        '
        'txtClientRendition4
        '
        Me.txtClientRendition4.AllowDrop = True
        Me.txtClientRendition4.BackColor = System.Drawing.SystemColors.Window
        Me.txtClientRendition4.Location = New System.Drawing.Point(248, 172)
        Me.txtClientRendition4.Name = "txtClientRendition4"
        Me.txtClientRendition4.ReadOnly = True
        Me.txtClientRendition4.Size = New System.Drawing.Size(98, 20)
        Me.txtClientRendition4.TabIndex = 241
        Me.txtClientRendition4.TabStop = False
        Me.txtClientRendition4.Tag = ""
        Me.txtClientRendition4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtClientRendition4.WordWrap = False
        '
        'txtClientRendition5
        '
        Me.txtClientRendition5.AllowDrop = True
        Me.txtClientRendition5.BackColor = System.Drawing.SystemColors.Window
        Me.txtClientRendition5.Location = New System.Drawing.Point(248, 199)
        Me.txtClientRendition5.Name = "txtClientRendition5"
        Me.txtClientRendition5.ReadOnly = True
        Me.txtClientRendition5.Size = New System.Drawing.Size(98, 20)
        Me.txtClientRendition5.TabIndex = 240
        Me.txtClientRendition5.TabStop = False
        Me.txtClientRendition5.Tag = ""
        Me.txtClientRendition5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtClientRendition5.WordWrap = False
        '
        'txtReclassRendition1
        '
        Me.txtReclassRendition1.AllowDrop = True
        Me.txtReclassRendition1.BackColor = System.Drawing.SystemColors.Window
        Me.txtReclassRendition1.Location = New System.Drawing.Point(352, 90)
        Me.txtReclassRendition1.Name = "txtReclassRendition1"
        Me.txtReclassRendition1.ReadOnly = True
        Me.txtReclassRendition1.Size = New System.Drawing.Size(98, 20)
        Me.txtReclassRendition1.TabIndex = 239
        Me.txtReclassRendition1.TabStop = False
        Me.txtReclassRendition1.Tag = ""
        Me.txtReclassRendition1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtReclassRendition1.WordWrap = False
        '
        'txtReclassRendition2
        '
        Me.txtReclassRendition2.AllowDrop = True
        Me.txtReclassRendition2.BackColor = System.Drawing.SystemColors.Window
        Me.txtReclassRendition2.Location = New System.Drawing.Point(352, 116)
        Me.txtReclassRendition2.Name = "txtReclassRendition2"
        Me.txtReclassRendition2.ReadOnly = True
        Me.txtReclassRendition2.Size = New System.Drawing.Size(98, 20)
        Me.txtReclassRendition2.TabIndex = 238
        Me.txtReclassRendition2.TabStop = False
        Me.txtReclassRendition2.Tag = ""
        Me.txtReclassRendition2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtReclassRendition2.WordWrap = False
        '
        'txtReclassRendition3
        '
        Me.txtReclassRendition3.AllowDrop = True
        Me.txtReclassRendition3.BackColor = System.Drawing.SystemColors.Window
        Me.txtReclassRendition3.Location = New System.Drawing.Point(352, 145)
        Me.txtReclassRendition3.Name = "txtReclassRendition3"
        Me.txtReclassRendition3.ReadOnly = True
        Me.txtReclassRendition3.Size = New System.Drawing.Size(98, 20)
        Me.txtReclassRendition3.TabIndex = 237
        Me.txtReclassRendition3.TabStop = False
        Me.txtReclassRendition3.Tag = ""
        Me.txtReclassRendition3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtReclassRendition3.WordWrap = False
        '
        'txtReclassRendition4
        '
        Me.txtReclassRendition4.AllowDrop = True
        Me.txtReclassRendition4.BackColor = System.Drawing.SystemColors.Window
        Me.txtReclassRendition4.Location = New System.Drawing.Point(352, 172)
        Me.txtReclassRendition4.Name = "txtReclassRendition4"
        Me.txtReclassRendition4.ReadOnly = True
        Me.txtReclassRendition4.Size = New System.Drawing.Size(98, 20)
        Me.txtReclassRendition4.TabIndex = 236
        Me.txtReclassRendition4.TabStop = False
        Me.txtReclassRendition4.Tag = ""
        Me.txtReclassRendition4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtReclassRendition4.WordWrap = False
        '
        'txtReclassRendition5
        '
        Me.txtReclassRendition5.AllowDrop = True
        Me.txtReclassRendition5.BackColor = System.Drawing.SystemColors.Window
        Me.txtReclassRendition5.Location = New System.Drawing.Point(352, 199)
        Me.txtReclassRendition5.Name = "txtReclassRendition5"
        Me.txtReclassRendition5.ReadOnly = True
        Me.txtReclassRendition5.Size = New System.Drawing.Size(98, 20)
        Me.txtReclassRendition5.TabIndex = 235
        Me.txtReclassRendition5.TabStop = False
        Me.txtReclassRendition5.Tag = ""
        Me.txtReclassRendition5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtReclassRendition5.WordWrap = False
        '
        'txtClientRendition1
        '
        Me.txtClientRendition1.AllowDrop = True
        Me.txtClientRendition1.BackColor = System.Drawing.SystemColors.Window
        Me.txtClientRendition1.Location = New System.Drawing.Point(248, 91)
        Me.txtClientRendition1.Name = "txtClientRendition1"
        Me.txtClientRendition1.Size = New System.Drawing.Size(98, 20)
        Me.txtClientRendition1.TabIndex = 234
        Me.txtClientRendition1.Tag = "@DB=AssessmentsBPP.ClientRenditionValue;@FMT=int"
        Me.txtClientRendition1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtClientRendition1.WordWrap = False
        '
        'cboFactorEntity1
        '
        Me.cboFactorEntity1.AllowDrop = True
        Me.cboFactorEntity1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboFactorEntity1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboFactorEntity1.FormattingEnabled = True
        Me.cboFactorEntity1.Location = New System.Drawing.Point(21, 91)
        Me.cboFactorEntity1.Name = "cboFactorEntity1"
        Me.cboFactorEntity1.Size = New System.Drawing.Size(221, 21)
        Me.cboFactorEntity1.TabIndex = 228
        Me.cboFactorEntity1.Tag = "@DB=AssessmentsBPP.FactorEntityId1"
        '
        'cboFactorEntity2
        '
        Me.cboFactorEntity2.AllowDrop = True
        Me.cboFactorEntity2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboFactorEntity2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboFactorEntity2.FormattingEnabled = True
        Me.cboFactorEntity2.Location = New System.Drawing.Point(21, 118)
        Me.cboFactorEntity2.Name = "cboFactorEntity2"
        Me.cboFactorEntity2.Size = New System.Drawing.Size(221, 21)
        Me.cboFactorEntity2.TabIndex = 229
        Me.cboFactorEntity2.Tag = "@DB=AssessmentsBPP.FactorEntityId2"
        '
        'cboFactorEntity3
        '
        Me.cboFactorEntity3.AllowDrop = True
        Me.cboFactorEntity3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboFactorEntity3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboFactorEntity3.FormattingEnabled = True
        Me.cboFactorEntity3.Location = New System.Drawing.Point(21, 145)
        Me.cboFactorEntity3.Name = "cboFactorEntity3"
        Me.cboFactorEntity3.Size = New System.Drawing.Size(221, 21)
        Me.cboFactorEntity3.TabIndex = 230
        Me.cboFactorEntity3.Tag = "@DB=AssessmentsBPP.FactorEntityId3"
        '
        'cboFactorEntity4
        '
        Me.cboFactorEntity4.AllowDrop = True
        Me.cboFactorEntity4.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboFactorEntity4.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboFactorEntity4.FormattingEnabled = True
        Me.cboFactorEntity4.Location = New System.Drawing.Point(21, 172)
        Me.cboFactorEntity4.Name = "cboFactorEntity4"
        Me.cboFactorEntity4.Size = New System.Drawing.Size(221, 21)
        Me.cboFactorEntity4.TabIndex = 231
        Me.cboFactorEntity4.Tag = "@DB=AssessmentsBPP.FactorEntityId4"
        '
        'cboFactorEntity5
        '
        Me.cboFactorEntity5.AllowDrop = True
        Me.cboFactorEntity5.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboFactorEntity5.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboFactorEntity5.FormattingEnabled = True
        Me.cboFactorEntity5.Location = New System.Drawing.Point(21, 199)
        Me.cboFactorEntity5.Name = "cboFactorEntity5"
        Me.cboFactorEntity5.Size = New System.Drawing.Size(221, 21)
        Me.cboFactorEntity5.TabIndex = 232
        Me.cboFactorEntity5.Tag = "@DB=AssessmentsBPP.FactorEntityId5"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(16, 68)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(224, 19)
        Me.Label5.TabIndex = 233
        Me.Label5.Text = "Factoring Entities"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.dgHistory.Location = New System.Drawing.Point(6, 17)
        Me.dgHistory.Name = "dgHistory"
        Me.dgHistory.ReadOnly = True
        Me.dgHistory.RowHeadersVisible = False
        Me.dgHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgHistory.ShowCellErrors = False
        Me.dgHistory.ShowCellToolTips = False
        Me.dgHistory.ShowEditingIcon = False
        Me.dgHistory.ShowRowErrors = False
        Me.dgHistory.Size = New System.Drawing.Size(199, 127)
        Me.dgHistory.TabIndex = 247
        '
        'fraHistory
        '
        Me.fraHistory.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fraHistory.Controls.Add(Me.dgHistory)
        Me.fraHistory.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraHistory.Location = New System.Drawing.Point(1109, 6)
        Me.fraHistory.Name = "fraHistory"
        Me.fraHistory.Size = New System.Drawing.Size(211, 152)
        Me.fraHistory.TabIndex = 248
        Me.fraHistory.TabStop = False
        Me.fraHistory.Text = "History"
        '
        'cmdViewAssessment
        '
        Me.cmdViewAssessment.Location = New System.Drawing.Point(219, 226)
        Me.cmdViewAssessment.Name = "cmdViewAssessment"
        Me.cmdViewAssessment.Size = New System.Drawing.Size(93, 23)
        Me.cmdViewAssessment.TabIndex = 249
        Me.cmdViewAssessment.Text = "Assessment"
        Me.cmdViewAssessment.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.fraCollectors)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtSICCode)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label6)
        Me.SplitContainer1.Panel1.Controls.Add(Me.chkInterstateAllocationFl)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cboAccountInvoicedStatus)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtConsultantName)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.grpComments)
        Me.SplitContainer1.Panel1.Controls.Add(Me.fraHistory)
        Me.SplitContainer1.Panel1.Controls.Add(Me.fraECU)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtRenditionCompleteDate)
        Me.SplitContainer1.Panel1.Controls.Add(Me.chkRenditionCompleteFl)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdECU)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdRefresh)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblTaxBillTotal)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdViewAssessment)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdTaxBillDetail)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label24)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdNewJurisdiction)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label10)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtTaxBillTotal)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtAcctNum)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label9)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtClientRendition2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtClientRendition3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cboAssessor)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtClientRendition4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtClientLocationId)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtClientRendition5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label21)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtReclassRendition1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtReclassRendition2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cboFactorEntity5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtReclassRendition3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cboFactorEntity4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtReclassRendition4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cboFactorEntity3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtReclassRendition5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cboFactorEntity2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtClientRendition1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cboFactorEntity1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgJurisdictions)
        Me.SplitContainer1.Size = New System.Drawing.Size(1325, 585)
        Me.SplitContainer1.SplitterDistance = 251
        Me.SplitContainer1.TabIndex = 250
        '
        'txtSICCode
        '
        Me.txtSICCode.AllowDrop = True
        Me.txtSICCode.Enabled = False
        Me.txtSICCode.Location = New System.Drawing.Point(716, 16)
        Me.txtSICCode.Name = "txtSICCode"
        Me.txtSICCode.Size = New System.Drawing.Size(140, 20)
        Me.txtSICCode.TabIndex = 264
        Me.txtSICCode.Tag = ""
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(660, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 20)
        Me.Label6.TabIndex = 265
        Me.Label6.Text = "SIC Code"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkInterstateAllocationFl
        '
        Me.chkInterstateAllocationFl.AutoSize = True
        Me.chkInterstateAllocationFl.Enabled = False
        Me.chkInterstateAllocationFl.Location = New System.Drawing.Point(328, 44)
        Me.chkInterstateAllocationFl.Name = "chkInterstateAllocationFl"
        Me.chkInterstateAllocationFl.Size = New System.Drawing.Size(148, 17)
        Me.chkInterstateAllocationFl.TabIndex = 263
        Me.chkInterstateAllocationFl.Tag = ""
        Me.chkInterstateAllocationFl.Text = "Apply Interstate Allocation"
        Me.chkInterstateAllocationFl.UseVisualStyleBackColor = True
        '
        'cboAccountInvoicedStatus
        '
        Me.cboAccountInvoicedStatus.AllowDrop = True
        Me.cboAccountInvoicedStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAccountInvoicedStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAccountInvoicedStatus.FormattingEnabled = True
        Me.cboAccountInvoicedStatus.Location = New System.Drawing.Point(576, 40)
        Me.cboAccountInvoicedStatus.Name = "cboAccountInvoicedStatus"
        Me.cboAccountInvoicedStatus.Size = New System.Drawing.Size(108, 21)
        Me.cboAccountInvoicedStatus.TabIndex = 3
        Me.cboAccountInvoicedStatus.Tag = "@DB=AssessmentsBPP.AccountInvoicedStatus"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(480, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 20)
        Me.Label4.TabIndex = 262
        Me.Label4.Text = "Account Invoiced"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtConsultantName
        '
        Me.txtConsultantName.AllowDrop = True
        Me.txtConsultantName.Enabled = False
        Me.txtConsultantName.Location = New System.Drawing.Point(564, 16)
        Me.txtConsultantName.Name = "txtConsultantName"
        Me.txtConsultantName.Size = New System.Drawing.Size(92, 20)
        Me.txtConsultantName.TabIndex = 259
        Me.txtConsultantName.Tag = ""
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(500, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 20)
        Me.Label3.TabIndex = 260
        Me.Label3.Text = "Consultant"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grpComments
        '
        Me.grpComments.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.grpComments.Controls.Add(Me.SplitContainer2)
        Me.grpComments.Location = New System.Drawing.Point(692, 48)
        Me.grpComments.Name = "grpComments"
        Me.grpComments.Size = New System.Drawing.Size(416, 200)
        Me.grpComments.TabIndex = 258
        Me.grpComments.TabStop = False
        Me.grpComments.Text = "Rendition Comments"
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
        Me.SplitContainer2.Panel1.Controls.Add(Me.cmdExpandComments)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.dgComments)
        Me.SplitContainer2.Size = New System.Drawing.Size(410, 181)
        Me.SplitContainer2.SplitterDistance = 25
        Me.SplitContainer2.TabIndex = 233
        '
        'cmdNewComment
        '
        Me.cmdNewComment.Location = New System.Drawing.Point(0, 0)
        Me.cmdNewComment.Name = "cmdNewComment"
        Me.cmdNewComment.Size = New System.Drawing.Size(75, 23)
        Me.cmdNewComment.TabIndex = 231
        Me.cmdNewComment.Text = "Comment"
        Me.cmdNewComment.UseVisualStyleBackColor = True
        '
        'cmdExpandComments
        '
        Me.cmdExpandComments.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExpandComments.Location = New System.Drawing.Point(352, 0)
        Me.cmdExpandComments.Name = "cmdExpandComments"
        Me.cmdExpandComments.Size = New System.Drawing.Size(59, 23)
        Me.cmdExpandComments.TabIndex = 232
        Me.cmdExpandComments.Text = "Expand"
        Me.cmdExpandComments.UseVisualStyleBackColor = True
        '
        'dgComments
        '
        Me.dgComments.AllowDrop = True
        Me.dgComments.AllowUserToAddRows = False
        Me.dgComments.AllowUserToDeleteRows = False
        Me.dgComments.AllowUserToOrderColumns = True
        Me.dgComments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgComments.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgComments.ContextMenuStrip = Me.ContextMenuStrip3
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgComments.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgComments.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgComments.Location = New System.Drawing.Point(0, 0)
        Me.dgComments.Margin = New System.Windows.Forms.Padding(0)
        Me.dgComments.Name = "dgComments"
        Me.dgComments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgComments.ShowCellErrors = False
        Me.dgComments.ShowCellToolTips = False
        Me.dgComments.ShowEditingIcon = False
        Me.dgComments.ShowRowErrors = False
        Me.dgComments.Size = New System.Drawing.Size(410, 152)
        Me.dgComments.TabIndex = 230
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
        'fraECU
        '
        Me.fraECU.Controls.Add(Me.dgECU)
        Me.fraECU.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraECU.Location = New System.Drawing.Point(930, 6)
        Me.fraECU.Name = "fraECU"
        Me.fraECU.Size = New System.Drawing.Size(258, 228)
        Me.fraECU.TabIndex = 254
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
        Me.dgECU.Size = New System.Drawing.Size(252, 209)
        Me.dgECU.TabIndex = 247
        '
        'txtRenditionCompleteDate
        '
        Me.txtRenditionCompleteDate.AllowDrop = True
        Me.txtRenditionCompleteDate.BackColor = System.Drawing.SystemColors.Window
        Me.txtRenditionCompleteDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRenditionCompleteDate.Location = New System.Drawing.Point(568, 84)
        Me.txtRenditionCompleteDate.Name = "txtRenditionCompleteDate"
        Me.txtRenditionCompleteDate.ReadOnly = True
        Me.txtRenditionCompleteDate.Size = New System.Drawing.Size(118, 20)
        Me.txtRenditionCompleteDate.TabIndex = 257
        Me.txtRenditionCompleteDate.TabStop = False
        Me.txtRenditionCompleteDate.Tag = "@DB=AssessmentsBPP.RenditionCompleteDate;@fmt=datetime"
        '
        'chkRenditionCompleteFl
        '
        Me.chkRenditionCompleteFl.AutoSize = True
        Me.chkRenditionCompleteFl.Location = New System.Drawing.Point(568, 68)
        Me.chkRenditionCompleteFl.Name = "chkRenditionCompleteFl"
        Me.chkRenditionCompleteFl.Size = New System.Drawing.Size(118, 17)
        Me.chkRenditionCompleteFl.TabIndex = 256
        Me.chkRenditionCompleteFl.Tag = "@DB=AssessmentsBPP.RenditionCompleteFl"
        Me.chkRenditionCompleteFl.Text = "Rendition Complete"
        Me.chkRenditionCompleteFl.UseVisualStyleBackColor = True
        '
        'cmdECU
        '
        Me.cmdECU.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdECU.Location = New System.Drawing.Point(860, 4)
        Me.cmdECU.Name = "cmdECU"
        Me.cmdECU.Size = New System.Drawing.Size(68, 20)
        Me.cmdECU.TabIndex = 255
        Me.cmdECU.Text = "ECU"
        Me.cmdECU.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdECU.UseVisualStyleBackColor = True
        '
        'frmBPPTaxList
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1325, 585)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmBPPTaxList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BPP Tax List"
        CType(Me.dgJurisdictions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.fraCollectors.ResumeLayout(False)
        CType(Me.dgCollectors, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip2.ResumeLayout(False)
        CType(Me.dgHistory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraHistory.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.grpComments.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.dgComments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip3.ResumeLayout(False)
        Me.fraECU.ResumeLayout(False)
        CType(Me.dgECU, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtAcctNum As System.Windows.Forms.TextBox
    Friend WithEvents cboAssessor As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgJurisdictions As System.Windows.Forms.DataGridView
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuContextDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdNewJurisdiction As System.Windows.Forms.Button
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents mnuContextPrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdTaxBillDetail As System.Windows.Forms.Button
    Friend WithEvents txtTaxBillTotal As System.Windows.Forms.TextBox
    Friend WithEvents dgCollectors As System.Windows.Forms.DataGridView
    Friend WithEvents lblTaxBillTotal As System.Windows.Forms.Label
    Friend WithEvents fraCollectors As System.Windows.Forms.GroupBox
    Friend WithEvents ContextMenuStrip2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuContextImportTaxBill As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtClientLocationId As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtClientRendition2 As System.Windows.Forms.TextBox
    Friend WithEvents txtClientRendition3 As System.Windows.Forms.TextBox
    Friend WithEvents txtClientRendition4 As System.Windows.Forms.TextBox
    Friend WithEvents txtClientRendition5 As System.Windows.Forms.TextBox
    Friend WithEvents txtReclassRendition1 As System.Windows.Forms.TextBox
    Friend WithEvents txtReclassRendition2 As System.Windows.Forms.TextBox
    Friend WithEvents txtReclassRendition3 As System.Windows.Forms.TextBox
    Friend WithEvents txtReclassRendition4 As System.Windows.Forms.TextBox
    Friend WithEvents txtReclassRendition5 As System.Windows.Forms.TextBox
    Friend WithEvents txtClientRendition1 As System.Windows.Forms.TextBox
    Friend WithEvents cboFactorEntity1 As System.Windows.Forms.ComboBox
    Friend WithEvents cboFactorEntity2 As System.Windows.Forms.ComboBox
    Friend WithEvents cboFactorEntity3 As System.Windows.Forms.ComboBox
    Friend WithEvents cboFactorEntity4 As System.Windows.Forms.ComboBox
    Friend WithEvents cboFactorEntity5 As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dgHistory As System.Windows.Forms.DataGridView
    Friend WithEvents fraHistory As System.Windows.Forms.GroupBox
    Friend WithEvents cmdViewAssessment As System.Windows.Forms.Button
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents cmdECU As System.Windows.Forms.Button
    Friend WithEvents fraECU As System.Windows.Forms.GroupBox
    Friend WithEvents dgECU As System.Windows.Forms.DataGridView
    Friend WithEvents chkRenditionCompleteFl As System.Windows.Forms.CheckBox
    Friend WithEvents txtRenditionCompleteDate As System.Windows.Forms.TextBox
    Friend WithEvents grpComments As System.Windows.Forms.GroupBox
    Friend WithEvents cmdExpandComments As System.Windows.Forms.Button
    Friend WithEvents cmdNewComment As System.Windows.Forms.Button
    Friend WithEvents dgComments As System.Windows.Forms.DataGridView
    Friend WithEvents ContextMenuStrip3 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuContextDeleteComment As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents txtConsultantName As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cboAccountInvoicedStatus As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents chkInterstateAllocationFl As CheckBox
    Friend WithEvents txtSICCode As TextBox
    Friend WithEvents Label6 As Label
End Class
