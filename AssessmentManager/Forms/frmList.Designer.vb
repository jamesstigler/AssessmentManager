<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmList
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
        Me.dgList = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuContextCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuContextDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuContextDeleteAssets = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuContextFactor = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuContextPrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuContextSetAgency = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuContextSetECUParent = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuContextSetBusinessUnit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuContextSetConsultantName = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuContextAssignTask = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuContextImportTaxBill = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuContextViewTaxBill = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuContextModifyQuery = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuContextAddJurisdiction = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuContextOpenListOfAssets = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuContextOpenAssessmentValues = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuContextImportAssets = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuContextLabelEdit = New System.Windows.Forms.ToolStripTextBox()
        Me.mnuContextTextBox = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuContextOpenProspect = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuContextAssignToClient = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuContextSetSolicitType = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuContextSetSolicitSentDate = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuContextSetLeadMailDate = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuContextSetLeadFollowUpDate = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuContextSetLeadInfoSentFl = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuContextSetLeadStatus = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuContextSetClientCoordinatorName = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuContextSetRenditionServiceLevel = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuContextSetRenditionInterstateAllocation = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuContextSetLeaseInfo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuContextSetRenditionAuditFl = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboSortType3 = New System.Windows.Forms.ComboBox()
        Me.cboSortType2 = New System.Windows.Forms.ComboBox()
        Me.cboSortType1 = New System.Windows.Forms.ComboBox()
        Me.cboSortField3 = New System.Windows.Forms.ComboBox()
        Me.cboSortField2 = New System.Windows.Forms.ComboBox()
        Me.cboSortField1 = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtFilterValue3 = New System.Windows.Forms.TextBox()
        Me.txtFilterValue2 = New System.Windows.Forms.TextBox()
        Me.txtFilterValue1 = New System.Windows.Forms.TextBox()
        Me.cboFilterField3 = New System.Windows.Forms.ComboBox()
        Me.cboFilterField2 = New System.Windows.Forms.ComboBox()
        Me.cboFilterField1 = New System.Windows.Forms.ComboBox()
        Me.cmdApply = New System.Windows.Forms.Button()
        Me.cmdRefresh = New System.Windows.Forms.Button()
        Me.txtRowCount = New System.Windows.Forms.TextBox()
        Me.pnlFactor = New System.Windows.Forms.Panel()
        Me.cmdFactorCancel = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblFactorEntityName = New System.Windows.Forms.Label()
        Me.cmdFactorOK = New System.Windows.Forms.Button()
        Me.cboFactorFactorCode = New System.Windows.Forms.ComboBox()
        Me.cmdExport = New System.Windows.Forms.Button()
        Me.chkShowFactor = New System.Windows.Forms.CheckBox()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.pnlClient = New System.Windows.Forms.Panel()
        Me.cmdClientCancel = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdClientOK = New System.Windows.Forms.Button()
        Me.cboClient = New System.Windows.Forms.ComboBox()
        Me.pnlLeadMailDate = New System.Windows.Forms.Panel()
        Me.cmdLeadMailDateCancel = New System.Windows.Forms.Button()
        Me.txtLeadMailDate = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmdLeadMailDateOK = New System.Windows.Forms.Button()
        Me.pnlClientCoordinatorName = New System.Windows.Forms.Panel()
        Me.cmdClientCoordinatorNameCancel = New System.Windows.Forms.Button()
        Me.cboClientCoordinatorName = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmdClientCoordinatorNameOK = New System.Windows.Forms.Button()
        Me.pnlSolicitType = New System.Windows.Forms.Panel()
        Me.cmdSolicitTypeCancel = New System.Windows.Forms.Button()
        Me.cboSolicitType = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmdSolicitTypeOK = New System.Windows.Forms.Button()
        Me.pnlLeadFollowUpDate = New System.Windows.Forms.Panel()
        Me.cmdLeadFollowUpDateCancel = New System.Windows.Forms.Button()
        Me.txtLeadFollowUpDate = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmdLeadFollowUpDateOK = New System.Windows.Forms.Button()
        Me.pnlLeadStatus = New System.Windows.Forms.Panel()
        Me.cmdLeadStatusCancel = New System.Windows.Forms.Button()
        Me.cboLeadStatus = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmdLeadStatusOK = New System.Windows.Forms.Button()
        Me.pnlLeadInfoSentFl = New System.Windows.Forms.Panel()
        Me.cmdLeadInfoSentFlCancel = New System.Windows.Forms.Button()
        Me.chkLeadInfoSentFl = New System.Windows.Forms.CheckBox()
        Me.cmdLeadInfoSentFlOK = New System.Windows.Forms.Button()
        Me.pnlSolicitSentDate = New System.Windows.Forms.Panel()
        Me.cmdSolicitSentDateCancel = New System.Windows.Forms.Button()
        Me.txtSolicitSentDate = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmdSolicitSentDateOK = New System.Windows.Forms.Button()
        Me.pnlRenditionAllocationPct = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmdAllocationPctCancel = New System.Windows.Forms.Button()
        Me.txtAllocationPct = New System.Windows.Forms.TextBox()
        Me.lblAllocation = New System.Windows.Forms.Label()
        Me.cmdAllocationPctOK = New System.Windows.Forms.Button()
        Me.cmdNew = New System.Windows.Forms.Button()
        Me.cmdImport = New System.Windows.Forms.Button()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblFixed = New System.Windows.Forms.Label()
        Me.lblInv = New System.Windows.Forms.Label()
        Me.txtInv = New System.Windows.Forms.TextBox()
        Me.txtFixed = New System.Windows.Forms.TextBox()
        Me.pnlAgency = New System.Windows.Forms.Panel()
        Me.cmdAgencyCancel = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cmdAgencyOK = New System.Windows.Forms.Button()
        Me.cboAgency = New System.Windows.Forms.ComboBox()
        Me.pnlTask = New System.Windows.Forms.Panel()
        Me.cmdTaskCancel = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cmdTaskOK = New System.Windows.Forms.Button()
        Me.cboTask = New System.Windows.Forms.ComboBox()
        Me.pnlAuditFl = New System.Windows.Forms.Panel()
        Me.cmdAuditFlCancel = New System.Windows.Forms.Button()
        Me.chkAuditFl = New System.Windows.Forms.CheckBox()
        Me.cmdAuditFlOK = New System.Windows.Forms.Button()
        Me.pnlLeaseInfo = New System.Windows.Forms.Panel()
        Me.cboLesseeStateCd = New System.Windows.Forms.ComboBox()
        Me.txtLesseeZip = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtLesseeCity = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtLesseeName = New System.Windows.Forms.TextBox()
        Me.txtLesseeAddress = New System.Windows.Forms.TextBox()
        Me.txtEquipmentMake = New System.Windows.Forms.TextBox()
        Me.txtLeaseTerm = New System.Windows.Forms.TextBox()
        Me.txtEquipmentModel = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cmdLeaseInfoCancel = New System.Windows.Forms.Button()
        Me.cboLeaseType = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cmdLeaseInfoOK = New System.Windows.Forms.Button()
        Me.pnlConsultantName = New System.Windows.Forms.Panel()
        Me.cmdConsultantNameCancel = New System.Windows.Forms.Button()
        Me.cboConsultantName = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cmdConsultantNameOK = New System.Windows.Forms.Button()
        Me.pnlBusinessUnit = New System.Windows.Forms.Panel()
        Me.cmdBusinessUnitCancel = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmdBusinessUnitOK = New System.Windows.Forms.Button()
        Me.cboBusinessUnit = New System.Windows.Forms.ComboBox()
        Me.pnlECUParent = New System.Windows.Forms.Panel()
        Me.cmdECUParentCancel = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmdECUParentOK = New System.Windows.Forms.Button()
        Me.cboECUParent = New System.Windows.Forms.ComboBox()
        CType(Me.dgList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.pnlFactor.SuspendLayout()
        Me.pnlClient.SuspendLayout()
        Me.pnlLeadMailDate.SuspendLayout()
        Me.pnlClientCoordinatorName.SuspendLayout()
        Me.pnlSolicitType.SuspendLayout()
        Me.pnlLeadFollowUpDate.SuspendLayout()
        Me.pnlLeadStatus.SuspendLayout()
        Me.pnlLeadInfoSentFl.SuspendLayout()
        Me.pnlSolicitSentDate.SuspendLayout()
        Me.pnlRenditionAllocationPct.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlAgency.SuspendLayout()
        Me.pnlTask.SuspendLayout()
        Me.pnlAuditFl.SuspendLayout()
        Me.pnlLeaseInfo.SuspendLayout()
        Me.pnlConsultantName.SuspendLayout()
        Me.pnlBusinessUnit.SuspendLayout()
        Me.pnlECUParent.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgList
        '
        Me.dgList.AllowUserToAddRows = False
        Me.dgList.AllowUserToDeleteRows = False
        Me.dgList.AllowUserToOrderColumns = True
        Me.dgList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgList.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dgList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgList.Location = New System.Drawing.Point(0, 0)
        Me.dgList.Margin = New System.Windows.Forms.Padding(0)
        Me.dgList.Name = "dgList"
        Me.dgList.ReadOnly = True
        Me.dgList.RowHeadersVisible = False
        Me.dgList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgList.ShowCellErrors = False
        Me.dgList.ShowCellToolTips = False
        Me.dgList.ShowEditingIcon = False
        Me.dgList.ShowRowErrors = False
        Me.dgList.Size = New System.Drawing.Size(1453, 609)
        Me.dgList.TabIndex = 0
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuContextCopy, Me.mnuContextDelete, Me.mnuContextDeleteAssets, Me.mnuContextFactor, Me.mnuContextPrint, Me.mnuContextSetAgency, Me.mnuContextSetECUParent, Me.mnuContextSetBusinessUnit, Me.mnuContextSetConsultantName, Me.mnuContextAssignTask, Me.mnuContextImportTaxBill, Me.mnuContextViewTaxBill, Me.mnuContextModifyQuery, Me.mnuContextAddJurisdiction, Me.mnuContextOpenListOfAssets, Me.mnuContextOpenAssessmentValues, Me.mnuContextImportAssets, Me.ToolStripSeparator1, Me.mnuContextLabelEdit, Me.mnuContextTextBox, Me.ToolStripSeparator2, Me.mnuContextOpenProspect, Me.mnuContextAssignToClient, Me.mnuContextSetSolicitType, Me.mnuContextSetSolicitSentDate, Me.mnuContextSetLeadMailDate, Me.mnuContextSetLeadFollowUpDate, Me.mnuContextSetLeadInfoSentFl, Me.mnuContextSetLeadStatus, Me.mnuContextSetClientCoordinatorName, Me.mnuContextSetRenditionServiceLevel, Me.mnuContextSetRenditionInterstateAllocation, Me.mnuContextSetLeaseInfo, Me.mnuContextSetRenditionAuditFl})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(205, 719)
        '
        'mnuContextCopy
        '
        Me.mnuContextCopy.Name = "mnuContextCopy"
        Me.mnuContextCopy.Size = New System.Drawing.Size(204, 22)
        Me.mnuContextCopy.Text = "Copy"
        '
        'mnuContextDelete
        '
        Me.mnuContextDelete.Name = "mnuContextDelete"
        Me.mnuContextDelete.Size = New System.Drawing.Size(204, 22)
        Me.mnuContextDelete.Text = "Delete"
        '
        'mnuContextDeleteAssets
        '
        Me.mnuContextDeleteAssets.Name = "mnuContextDeleteAssets"
        Me.mnuContextDeleteAssets.Size = New System.Drawing.Size(204, 22)
        Me.mnuContextDeleteAssets.Text = "Delete Assets"
        Me.mnuContextDeleteAssets.Visible = False
        '
        'mnuContextFactor
        '
        Me.mnuContextFactor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.mnuContextFactor.Name = "mnuContextFactor"
        Me.mnuContextFactor.Size = New System.Drawing.Size(204, 22)
        Me.mnuContextFactor.Text = "Factor"
        '
        'mnuContextPrint
        '
        Me.mnuContextPrint.Name = "mnuContextPrint"
        Me.mnuContextPrint.Size = New System.Drawing.Size(204, 22)
        Me.mnuContextPrint.Text = "Print"
        '
        'mnuContextSetAgency
        '
        Me.mnuContextSetAgency.Name = "mnuContextSetAgency"
        Me.mnuContextSetAgency.Size = New System.Drawing.Size(204, 22)
        Me.mnuContextSetAgency.Text = "Set Agency"
        '
        'mnuContextSetECUParent
        '
        Me.mnuContextSetECUParent.Name = "mnuContextSetECUParent"
        Me.mnuContextSetECUParent.Size = New System.Drawing.Size(204, 22)
        Me.mnuContextSetECUParent.Text = "Set ECU Parent"
        '
        'mnuContextSetBusinessUnit
        '
        Me.mnuContextSetBusinessUnit.Name = "mnuContextSetBusinessUnit"
        Me.mnuContextSetBusinessUnit.Size = New System.Drawing.Size(204, 22)
        Me.mnuContextSetBusinessUnit.Text = "Set Business Unit"
        Me.mnuContextSetBusinessUnit.Visible = False
        '
        'mnuContextSetConsultantName
        '
        Me.mnuContextSetConsultantName.Name = "mnuContextSetConsultantName"
        Me.mnuContextSetConsultantName.Size = New System.Drawing.Size(204, 22)
        Me.mnuContextSetConsultantName.Text = "Set Consultant Name"
        '
        'mnuContextAssignTask
        '
        Me.mnuContextAssignTask.Name = "mnuContextAssignTask"
        Me.mnuContextAssignTask.Size = New System.Drawing.Size(204, 22)
        Me.mnuContextAssignTask.Text = "Assign Task"
        Me.mnuContextAssignTask.Visible = False
        '
        'mnuContextImportTaxBill
        '
        Me.mnuContextImportTaxBill.Name = "mnuContextImportTaxBill"
        Me.mnuContextImportTaxBill.Size = New System.Drawing.Size(204, 22)
        Me.mnuContextImportTaxBill.Text = "Import Tax Bill"
        Me.mnuContextImportTaxBill.Visible = False
        '
        'mnuContextViewTaxBill
        '
        Me.mnuContextViewTaxBill.Name = "mnuContextViewTaxBill"
        Me.mnuContextViewTaxBill.Size = New System.Drawing.Size(204, 22)
        Me.mnuContextViewTaxBill.Text = "View Tax Bill"
        Me.mnuContextViewTaxBill.Visible = False
        '
        'mnuContextModifyQuery
        '
        Me.mnuContextModifyQuery.Name = "mnuContextModifyQuery"
        Me.mnuContextModifyQuery.Size = New System.Drawing.Size(204, 22)
        Me.mnuContextModifyQuery.Text = "Modify Query"
        '
        'mnuContextAddJurisdiction
        '
        Me.mnuContextAddJurisdiction.Name = "mnuContextAddJurisdiction"
        Me.mnuContextAddJurisdiction.Size = New System.Drawing.Size(204, 22)
        Me.mnuContextAddJurisdiction.Text = "Add Jurisdiction"
        '
        'mnuContextOpenListOfAssets
        '
        Me.mnuContextOpenListOfAssets.Name = "mnuContextOpenListOfAssets"
        Me.mnuContextOpenListOfAssets.Size = New System.Drawing.Size(204, 22)
        Me.mnuContextOpenListOfAssets.Text = "Open List of Assets"
        '
        'mnuContextOpenAssessmentValues
        '
        Me.mnuContextOpenAssessmentValues.Name = "mnuContextOpenAssessmentValues"
        Me.mnuContextOpenAssessmentValues.Size = New System.Drawing.Size(204, 22)
        Me.mnuContextOpenAssessmentValues.Text = "Open Assessment Values"
        '
        'mnuContextImportAssets
        '
        Me.mnuContextImportAssets.Name = "mnuContextImportAssets"
        Me.mnuContextImportAssets.Size = New System.Drawing.Size(204, 22)
        Me.mnuContextImportAssets.Text = "Import Assets"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(201, 6)
        Me.ToolStripSeparator1.Visible = False
        '
        'mnuContextLabelEdit
        '
        Me.mnuContextLabelEdit.BackColor = System.Drawing.SystemColors.Window
        Me.mnuContextLabelEdit.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.mnuContextLabelEdit.Enabled = False
        Me.mnuContextLabelEdit.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.mnuContextLabelEdit.Name = "mnuContextLabelEdit"
        Me.mnuContextLabelEdit.ReadOnly = True
        Me.mnuContextLabelEdit.Size = New System.Drawing.Size(100, 16)
        Me.mnuContextLabelEdit.Text = "Edit"
        Me.mnuContextLabelEdit.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.mnuContextLabelEdit.Visible = False
        '
        'mnuContextTextBox
        '
        Me.mnuContextTextBox.AutoToolTip = True
        Me.mnuContextTextBox.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.mnuContextTextBox.Name = "mnuContextTextBox"
        Me.mnuContextTextBox.Size = New System.Drawing.Size(100, 23)
        Me.mnuContextTextBox.ToolTipText = "Edit value"
        Me.mnuContextTextBox.Visible = False
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(201, 6)
        Me.ToolStripSeparator2.Visible = False
        '
        'mnuContextOpenProspect
        '
        Me.mnuContextOpenProspect.Name = "mnuContextOpenProspect"
        Me.mnuContextOpenProspect.Size = New System.Drawing.Size(204, 22)
        Me.mnuContextOpenProspect.Text = "Open Prospect"
        Me.mnuContextOpenProspect.Visible = False
        '
        'mnuContextAssignToClient
        '
        Me.mnuContextAssignToClient.Name = "mnuContextAssignToClient"
        Me.mnuContextAssignToClient.Size = New System.Drawing.Size(204, 22)
        Me.mnuContextAssignToClient.Text = "Assign to Client"
        Me.mnuContextAssignToClient.Visible = False
        '
        'mnuContextSetSolicitType
        '
        Me.mnuContextSetSolicitType.Name = "mnuContextSetSolicitType"
        Me.mnuContextSetSolicitType.Size = New System.Drawing.Size(204, 22)
        Me.mnuContextSetSolicitType.Text = "Set Solicitation Type"
        '
        'mnuContextSetSolicitSentDate
        '
        Me.mnuContextSetSolicitSentDate.Name = "mnuContextSetSolicitSentDate"
        Me.mnuContextSetSolicitSentDate.Size = New System.Drawing.Size(204, 22)
        Me.mnuContextSetSolicitSentDate.Text = "Set Solicitation Date"
        '
        'mnuContextSetLeadMailDate
        '
        Me.mnuContextSetLeadMailDate.Name = "mnuContextSetLeadMailDate"
        Me.mnuContextSetLeadMailDate.Size = New System.Drawing.Size(204, 22)
        Me.mnuContextSetLeadMailDate.Text = "Set Mail/Email Date"
        '
        'mnuContextSetLeadFollowUpDate
        '
        Me.mnuContextSetLeadFollowUpDate.Name = "mnuContextSetLeadFollowUpDate"
        Me.mnuContextSetLeadFollowUpDate.Size = New System.Drawing.Size(204, 22)
        Me.mnuContextSetLeadFollowUpDate.Text = "Set Follow-up Date"
        '
        'mnuContextSetLeadInfoSentFl
        '
        Me.mnuContextSetLeadInfoSentFl.Name = "mnuContextSetLeadInfoSentFl"
        Me.mnuContextSetLeadInfoSentFl.Size = New System.Drawing.Size(204, 22)
        Me.mnuContextSetLeadInfoSentFl.Text = "Set Lead Info Sent Flag"
        '
        'mnuContextSetLeadStatus
        '
        Me.mnuContextSetLeadStatus.Name = "mnuContextSetLeadStatus"
        Me.mnuContextSetLeadStatus.Size = New System.Drawing.Size(204, 22)
        Me.mnuContextSetLeadStatus.Text = "Set Lead Status"
        '
        'mnuContextSetClientCoordinatorName
        '
        Me.mnuContextSetClientCoordinatorName.Name = "mnuContextSetClientCoordinatorName"
        Me.mnuContextSetClientCoordinatorName.Size = New System.Drawing.Size(204, 22)
        Me.mnuContextSetClientCoordinatorName.Text = "Set Client Coordinator"
        '
        'mnuContextSetRenditionServiceLevel
        '
        Me.mnuContextSetRenditionServiceLevel.Name = "mnuContextSetRenditionServiceLevel"
        Me.mnuContextSetRenditionServiceLevel.Size = New System.Drawing.Size(204, 22)
        Me.mnuContextSetRenditionServiceLevel.Text = "Set Service Level"
        '
        'mnuContextSetRenditionInterstateAllocation
        '
        Me.mnuContextSetRenditionInterstateAllocation.Name = "mnuContextSetRenditionInterstateAllocation"
        Me.mnuContextSetRenditionInterstateAllocation.Size = New System.Drawing.Size(204, 22)
        Me.mnuContextSetRenditionInterstateAllocation.Text = "Set Interstate Allocation"
        '
        'mnuContextSetLeaseInfo
        '
        Me.mnuContextSetLeaseInfo.Name = "mnuContextSetLeaseInfo"
        Me.mnuContextSetLeaseInfo.Size = New System.Drawing.Size(204, 22)
        Me.mnuContextSetLeaseInfo.Text = "Set Lease Information"
        '
        'mnuContextSetRenditionAuditFl
        '
        Me.mnuContextSetRenditionAuditFl.Name = "mnuContextSetRenditionAuditFl"
        Me.mnuContextSetRenditionAuditFl.Size = New System.Drawing.Size(204, 22)
        Me.mnuContextSetRenditionAuditFl.Text = "Set Audit Flag"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboSortType3)
        Me.GroupBox1.Controls.Add(Me.cboSortType2)
        Me.GroupBox1.Controls.Add(Me.cboSortType1)
        Me.GroupBox1.Controls.Add(Me.cboSortField3)
        Me.GroupBox1.Controls.Add(Me.cboSortField2)
        Me.GroupBox1.Controls.Add(Me.cboSortField1)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 4)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(726, 61)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Sort"
        '
        'cboSortType3
        '
        Me.cboSortType3.FormattingEnabled = True
        Me.cboSortType3.Items.AddRange(New Object() {"ASC", "DESC"})
        Me.cboSortType3.Location = New System.Drawing.Point(650, 24)
        Me.cboSortType3.Margin = New System.Windows.Forms.Padding(4)
        Me.cboSortType3.Name = "cboSortType3"
        Me.cboSortType3.Size = New System.Drawing.Size(70, 21)
        Me.cboSortType3.TabIndex = 12
        Me.cboSortType3.Text = "ASC"
        '
        'cboSortType2
        '
        Me.cboSortType2.FormattingEnabled = True
        Me.cboSortType2.Items.AddRange(New Object() {"ASC", "DESC"})
        Me.cboSortType2.Location = New System.Drawing.Point(408, 24)
        Me.cboSortType2.Margin = New System.Windows.Forms.Padding(4)
        Me.cboSortType2.Name = "cboSortType2"
        Me.cboSortType2.Size = New System.Drawing.Size(70, 21)
        Me.cboSortType2.TabIndex = 11
        Me.cboSortType2.Text = "ASC"
        '
        'cboSortType1
        '
        Me.cboSortType1.FormattingEnabled = True
        Me.cboSortType1.Items.AddRange(New Object() {"ASC", "DESC"})
        Me.cboSortType1.Location = New System.Drawing.Point(171, 24)
        Me.cboSortType1.Margin = New System.Windows.Forms.Padding(4)
        Me.cboSortType1.Name = "cboSortType1"
        Me.cboSortType1.Size = New System.Drawing.Size(70, 21)
        Me.cboSortType1.TabIndex = 10
        Me.cboSortType1.Text = "ASC"
        '
        'cboSortField3
        '
        Me.cboSortField3.FormattingEnabled = True
        Me.cboSortField3.Location = New System.Drawing.Point(486, 24)
        Me.cboSortField3.Margin = New System.Windows.Forms.Padding(4)
        Me.cboSortField3.Name = "cboSortField3"
        Me.cboSortField3.Size = New System.Drawing.Size(155, 21)
        Me.cboSortField3.TabIndex = 9
        '
        'cboSortField2
        '
        Me.cboSortField2.FormattingEnabled = True
        Me.cboSortField2.Location = New System.Drawing.Point(250, 24)
        Me.cboSortField2.Margin = New System.Windows.Forms.Padding(4)
        Me.cboSortField2.Name = "cboSortField2"
        Me.cboSortField2.Size = New System.Drawing.Size(155, 21)
        Me.cboSortField2.TabIndex = 8
        '
        'cboSortField1
        '
        Me.cboSortField1.FormattingEnabled = True
        Me.cboSortField1.Location = New System.Drawing.Point(8, 24)
        Me.cboSortField1.Margin = New System.Windows.Forms.Padding(4)
        Me.cboSortField1.Name = "cboSortField1"
        Me.cboSortField1.Size = New System.Drawing.Size(155, 21)
        Me.cboSortField1.TabIndex = 3
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtFilterValue3)
        Me.GroupBox2.Controls.Add(Me.txtFilterValue2)
        Me.GroupBox2.Controls.Add(Me.txtFilterValue1)
        Me.GroupBox2.Controls.Add(Me.cboFilterField3)
        Me.GroupBox2.Controls.Add(Me.cboFilterField2)
        Me.GroupBox2.Controls.Add(Me.cboFilterField1)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 69)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(1025, 56)
        Me.GroupBox2.TabIndex = 17
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Filter"
        '
        'txtFilterValue3
        '
        Me.txtFilterValue3.Location = New System.Drawing.Point(870, 25)
        Me.txtFilterValue3.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFilterValue3.Name = "txtFilterValue3"
        Me.txtFilterValue3.Size = New System.Drawing.Size(149, 20)
        Me.txtFilterValue3.TabIndex = 12
        '
        'txtFilterValue2
        '
        Me.txtFilterValue2.Location = New System.Drawing.Point(530, 25)
        Me.txtFilterValue2.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFilterValue2.Name = "txtFilterValue2"
        Me.txtFilterValue2.Size = New System.Drawing.Size(149, 20)
        Me.txtFilterValue2.TabIndex = 11
        '
        'txtFilterValue1
        '
        Me.txtFilterValue1.Location = New System.Drawing.Point(190, 25)
        Me.txtFilterValue1.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFilterValue1.Name = "txtFilterValue1"
        Me.txtFilterValue1.Size = New System.Drawing.Size(149, 20)
        Me.txtFilterValue1.TabIndex = 10
        '
        'cboFilterField3
        '
        Me.cboFilterField3.FormattingEnabled = True
        Me.cboFilterField3.Location = New System.Drawing.Point(688, 25)
        Me.cboFilterField3.Margin = New System.Windows.Forms.Padding(4)
        Me.cboFilterField3.Name = "cboFilterField3"
        Me.cboFilterField3.Size = New System.Drawing.Size(174, 21)
        Me.cboFilterField3.TabIndex = 9
        '
        'cboFilterField2
        '
        Me.cboFilterField2.FormattingEnabled = True
        Me.cboFilterField2.Location = New System.Drawing.Point(348, 25)
        Me.cboFilterField2.Margin = New System.Windows.Forms.Padding(4)
        Me.cboFilterField2.Name = "cboFilterField2"
        Me.cboFilterField2.Size = New System.Drawing.Size(174, 21)
        Me.cboFilterField2.TabIndex = 8
        '
        'cboFilterField1
        '
        Me.cboFilterField1.FormattingEnabled = True
        Me.cboFilterField1.Location = New System.Drawing.Point(8, 25)
        Me.cboFilterField1.Margin = New System.Windows.Forms.Padding(4)
        Me.cboFilterField1.Name = "cboFilterField1"
        Me.cboFilterField1.Size = New System.Drawing.Size(174, 21)
        Me.cboFilterField1.TabIndex = 3
        '
        'cmdApply
        '
        Me.cmdApply.Enabled = False
        Me.cmdApply.Location = New System.Drawing.Point(742, 4)
        Me.cmdApply.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdApply.Name = "cmdApply"
        Me.cmdApply.Size = New System.Drawing.Size(91, 28)
        Me.cmdApply.TabIndex = 18
        Me.cmdApply.Text = "Apply Filter"
        Me.cmdApply.UseVisualStyleBackColor = True
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Location = New System.Drawing.Point(742, 36)
        Me.cmdRefresh.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(91, 28)
        Me.cmdRefresh.TabIndex = 19
        Me.cmdRefresh.Text = "Refresh"
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'txtRowCount
        '
        Me.txtRowCount.BackColor = System.Drawing.SystemColors.Control
        Me.txtRowCount.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtRowCount.Location = New System.Drawing.Point(48, 84)
        Me.txtRowCount.Margin = New System.Windows.Forms.Padding(4)
        Me.txtRowCount.Name = "txtRowCount"
        Me.txtRowCount.ReadOnly = True
        Me.txtRowCount.Size = New System.Drawing.Size(184, 13)
        Me.txtRowCount.TabIndex = 20
        Me.txtRowCount.TabStop = False
        Me.txtRowCount.Text = "txtRowCount"
        Me.txtRowCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'pnlFactor
        '
        Me.pnlFactor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlFactor.Controls.Add(Me.cmdFactorCancel)
        Me.pnlFactor.Controls.Add(Me.Label1)
        Me.pnlFactor.Controls.Add(Me.lblFactorEntityName)
        Me.pnlFactor.Controls.Add(Me.cmdFactorOK)
        Me.pnlFactor.Controls.Add(Me.cboFactorFactorCode)
        Me.pnlFactor.Location = New System.Drawing.Point(24, 284)
        Me.pnlFactor.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlFactor.Name = "pnlFactor"
        Me.pnlFactor.Size = New System.Drawing.Size(313, 120)
        Me.pnlFactor.TabIndex = 21
        Me.pnlFactor.Visible = False
        '
        'cmdFactorCancel
        '
        Me.cmdFactorCancel.Location = New System.Drawing.Point(162, 78)
        Me.cmdFactorCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdFactorCancel.Name = "cmdFactorCancel"
        Me.cmdFactorCancel.Size = New System.Drawing.Size(99, 28)
        Me.cmdFactorCancel.TabIndex = 23
        Me.cmdFactorCancel.Text = "Cancel"
        Me.cmdFactorCancel.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(29, 45)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 21)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Factor code"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFactorEntityName
        '
        Me.lblFactorEntityName.Location = New System.Drawing.Point(4, 0)
        Me.lblFactorEntityName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFactorEntityName.Name = "lblFactorEntityName"
        Me.lblFactorEntityName.Size = New System.Drawing.Size(292, 21)
        Me.lblFactorEntityName.TabIndex = 21
        Me.lblFactorEntityName.Text = "Factor Entity"
        Me.lblFactorEntityName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdFactorOK
        '
        Me.cmdFactorOK.Location = New System.Drawing.Point(56, 78)
        Me.cmdFactorOK.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdFactorOK.Name = "cmdFactorOK"
        Me.cmdFactorOK.Size = New System.Drawing.Size(99, 28)
        Me.cmdFactorOK.TabIndex = 19
        Me.cmdFactorOK.Text = "OK"
        Me.cmdFactorOK.UseVisualStyleBackColor = True
        '
        'cboFactorFactorCode
        '
        Me.cboFactorFactorCode.FormattingEnabled = True
        Me.cboFactorFactorCode.Location = New System.Drawing.Point(124, 44)
        Me.cboFactorFactorCode.Margin = New System.Windows.Forms.Padding(4)
        Me.cboFactorFactorCode.Name = "cboFactorFactorCode"
        Me.cboFactorFactorCode.Size = New System.Drawing.Size(150, 21)
        Me.cboFactorFactorCode.TabIndex = 4
        '
        'cmdExport
        '
        Me.cmdExport.Enabled = False
        Me.cmdExport.Location = New System.Drawing.Point(836, 4)
        Me.cmdExport.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdExport.Name = "cmdExport"
        Me.cmdExport.Size = New System.Drawing.Size(91, 28)
        Me.cmdExport.TabIndex = 22
        Me.cmdExport.Text = "Export"
        Me.cmdExport.UseVisualStyleBackColor = True
        '
        'chkShowFactor
        '
        Me.chkShowFactor.Location = New System.Drawing.Point(64, 4)
        Me.chkShowFactor.Margin = New System.Windows.Forms.Padding(4)
        Me.chkShowFactor.Name = "chkShowFactor"
        Me.chkShowFactor.Size = New System.Drawing.Size(144, 20)
        Me.chkShowFactor.TabIndex = 23
        Me.chkShowFactor.Text = "Show factored amounts"
        Me.chkShowFactor.UseVisualStyleBackColor = True
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.SystemColors.Control
        Me.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotal.Location = New System.Drawing.Point(132, 24)
        Me.txtTotal.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTotal.Multiline = True
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(100, 16)
        Me.txtTotal.TabIndex = 24
        Me.txtTotal.TabStop = False
        Me.txtTotal.Text = "txtTotal"
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'pnlClient
        '
        Me.pnlClient.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlClient.Controls.Add(Me.cmdClientCancel)
        Me.pnlClient.Controls.Add(Me.Label2)
        Me.pnlClient.Controls.Add(Me.cmdClientOK)
        Me.pnlClient.Controls.Add(Me.cboClient)
        Me.pnlClient.Location = New System.Drawing.Point(24, 184)
        Me.pnlClient.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlClient.Name = "pnlClient"
        Me.pnlClient.Size = New System.Drawing.Size(458, 88)
        Me.pnlClient.TabIndex = 25
        Me.pnlClient.Visible = False
        '
        'cmdClientCancel
        '
        Me.cmdClientCancel.Location = New System.Drawing.Point(242, 45)
        Me.cmdClientCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdClientCancel.Name = "cmdClientCancel"
        Me.cmdClientCancel.Size = New System.Drawing.Size(99, 28)
        Me.cmdClientCancel.TabIndex = 23
        Me.cmdClientCancel.Text = "Cancel"
        Me.cmdClientCancel.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(4, 11)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 22)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Client"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdClientOK
        '
        Me.cmdClientOK.Location = New System.Drawing.Point(136, 45)
        Me.cmdClientOK.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdClientOK.Name = "cmdClientOK"
        Me.cmdClientOK.Size = New System.Drawing.Size(99, 28)
        Me.cmdClientOK.TabIndex = 19
        Me.cmdClientOK.Text = "OK"
        Me.cmdClientOK.UseVisualStyleBackColor = True
        '
        'cboClient
        '
        Me.cboClient.FormattingEnabled = True
        Me.cboClient.Location = New System.Drawing.Point(64, 11)
        Me.cboClient.Margin = New System.Windows.Forms.Padding(4)
        Me.cboClient.Name = "cboClient"
        Me.cboClient.Size = New System.Drawing.Size(370, 21)
        Me.cboClient.TabIndex = 4
        '
        'pnlLeadMailDate
        '
        Me.pnlLeadMailDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlLeadMailDate.Controls.Add(Me.cmdLeadMailDateCancel)
        Me.pnlLeadMailDate.Controls.Add(Me.txtLeadMailDate)
        Me.pnlLeadMailDate.Controls.Add(Me.Label3)
        Me.pnlLeadMailDate.Controls.Add(Me.cmdLeadMailDateOK)
        Me.pnlLeadMailDate.Location = New System.Drawing.Point(688, 312)
        Me.pnlLeadMailDate.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlLeadMailDate.Name = "pnlLeadMailDate"
        Me.pnlLeadMailDate.Size = New System.Drawing.Size(227, 88)
        Me.pnlLeadMailDate.TabIndex = 26
        Me.pnlLeadMailDate.Visible = False
        '
        'cmdLeadMailDateCancel
        '
        Me.cmdLeadMailDateCancel.Location = New System.Drawing.Point(115, 44)
        Me.cmdLeadMailDateCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdLeadMailDateCancel.Name = "cmdLeadMailDateCancel"
        Me.cmdLeadMailDateCancel.Size = New System.Drawing.Size(99, 28)
        Me.cmdLeadMailDateCancel.TabIndex = 24
        Me.cmdLeadMailDateCancel.Text = "Cancel"
        Me.cmdLeadMailDateCancel.UseVisualStyleBackColor = True
        '
        'txtLeadMailDate
        '
        Me.txtLeadMailDate.Location = New System.Drawing.Point(122, 12)
        Me.txtLeadMailDate.Margin = New System.Windows.Forms.Padding(4)
        Me.txtLeadMailDate.Name = "txtLeadMailDate"
        Me.txtLeadMailDate.Size = New System.Drawing.Size(85, 20)
        Me.txtLeadMailDate.TabIndex = 23
        Me.txtLeadMailDate.Tag = ""
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(4, 11)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(111, 22)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Mail/Email date"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdLeadMailDateOK
        '
        Me.cmdLeadMailDateOK.Location = New System.Drawing.Point(8, 44)
        Me.cmdLeadMailDateOK.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdLeadMailDateOK.Name = "cmdLeadMailDateOK"
        Me.cmdLeadMailDateOK.Size = New System.Drawing.Size(99, 28)
        Me.cmdLeadMailDateOK.TabIndex = 19
        Me.cmdLeadMailDateOK.Text = "OK"
        Me.cmdLeadMailDateOK.UseVisualStyleBackColor = True
        '
        'pnlClientCoordinatorName
        '
        Me.pnlClientCoordinatorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlClientCoordinatorName.Controls.Add(Me.cmdClientCoordinatorNameCancel)
        Me.pnlClientCoordinatorName.Controls.Add(Me.cboClientCoordinatorName)
        Me.pnlClientCoordinatorName.Controls.Add(Me.Label4)
        Me.pnlClientCoordinatorName.Controls.Add(Me.cmdClientCoordinatorNameOK)
        Me.pnlClientCoordinatorName.Location = New System.Drawing.Point(700, 408)
        Me.pnlClientCoordinatorName.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlClientCoordinatorName.Name = "pnlClientCoordinatorName"
        Me.pnlClientCoordinatorName.Size = New System.Drawing.Size(300, 88)
        Me.pnlClientCoordinatorName.TabIndex = 27
        Me.pnlClientCoordinatorName.Visible = False
        '
        'cmdClientCoordinatorNameCancel
        '
        Me.cmdClientCoordinatorNameCancel.Location = New System.Drawing.Point(152, 44)
        Me.cmdClientCoordinatorNameCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdClientCoordinatorNameCancel.Name = "cmdClientCoordinatorNameCancel"
        Me.cmdClientCoordinatorNameCancel.Size = New System.Drawing.Size(99, 28)
        Me.cmdClientCoordinatorNameCancel.TabIndex = 24
        Me.cmdClientCoordinatorNameCancel.Text = "Cancel"
        Me.cmdClientCoordinatorNameCancel.UseVisualStyleBackColor = True
        '
        'cboClientCoordinatorName
        '
        Me.cboClientCoordinatorName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboClientCoordinatorName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboClientCoordinatorName.FormattingEnabled = True
        Me.cboClientCoordinatorName.Location = New System.Drawing.Point(112, 12)
        Me.cboClientCoordinatorName.Margin = New System.Windows.Forms.Padding(4)
        Me.cboClientCoordinatorName.Name = "cboClientCoordinatorName"
        Me.cboClientCoordinatorName.Size = New System.Drawing.Size(180, 21)
        Me.cboClientCoordinatorName.TabIndex = 23
        Me.cboClientCoordinatorName.Tag = ""
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(4, 11)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 22)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Client Coordinator"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdClientCoordinatorNameOK
        '
        Me.cmdClientCoordinatorNameOK.Location = New System.Drawing.Point(46, 44)
        Me.cmdClientCoordinatorNameOK.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdClientCoordinatorNameOK.Name = "cmdClientCoordinatorNameOK"
        Me.cmdClientCoordinatorNameOK.Size = New System.Drawing.Size(99, 28)
        Me.cmdClientCoordinatorNameOK.TabIndex = 19
        Me.cmdClientCoordinatorNameOK.Text = "OK"
        Me.cmdClientCoordinatorNameOK.UseVisualStyleBackColor = True
        '
        'pnlSolicitType
        '
        Me.pnlSolicitType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlSolicitType.Controls.Add(Me.cmdSolicitTypeCancel)
        Me.pnlSolicitType.Controls.Add(Me.cboSolicitType)
        Me.pnlSolicitType.Controls.Add(Me.Label5)
        Me.pnlSolicitType.Controls.Add(Me.cmdSolicitTypeOK)
        Me.pnlSolicitType.Location = New System.Drawing.Point(285, 73)
        Me.pnlSolicitType.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlSolicitType.Name = "pnlSolicitType"
        Me.pnlSolicitType.Size = New System.Drawing.Size(314, 88)
        Me.pnlSolicitType.TabIndex = 28
        Me.pnlSolicitType.Visible = False
        '
        'cmdSolicitTypeCancel
        '
        Me.cmdSolicitTypeCancel.Location = New System.Drawing.Point(158, 45)
        Me.cmdSolicitTypeCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdSolicitTypeCancel.Name = "cmdSolicitTypeCancel"
        Me.cmdSolicitTypeCancel.Size = New System.Drawing.Size(99, 28)
        Me.cmdSolicitTypeCancel.TabIndex = 24
        Me.cmdSolicitTypeCancel.Text = "Cancel"
        Me.cmdSolicitTypeCancel.UseVisualStyleBackColor = True
        '
        'cboSolicitType
        '
        Me.cboSolicitType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSolicitType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSolicitType.FormattingEnabled = True
        Me.cboSolicitType.Location = New System.Drawing.Point(124, 11)
        Me.cboSolicitType.Margin = New System.Windows.Forms.Padding(4)
        Me.cboSolicitType.Name = "cboSolicitType"
        Me.cboSolicitType.Size = New System.Drawing.Size(180, 21)
        Me.cboSolicitType.TabIndex = 23
        Me.cboSolicitType.Tag = ""
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(4, 12)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 22)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "Solicitation type"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdSolicitTypeOK
        '
        Me.cmdSolicitTypeOK.Location = New System.Drawing.Point(51, 45)
        Me.cmdSolicitTypeOK.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdSolicitTypeOK.Name = "cmdSolicitTypeOK"
        Me.cmdSolicitTypeOK.Size = New System.Drawing.Size(99, 28)
        Me.cmdSolicitTypeOK.TabIndex = 19
        Me.cmdSolicitTypeOK.Text = "OK"
        Me.cmdSolicitTypeOK.UseVisualStyleBackColor = True
        '
        'pnlLeadFollowUpDate
        '
        Me.pnlLeadFollowUpDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlLeadFollowUpDate.Controls.Add(Me.cmdLeadFollowUpDateCancel)
        Me.pnlLeadFollowUpDate.Controls.Add(Me.txtLeadFollowUpDate)
        Me.pnlLeadFollowUpDate.Controls.Add(Me.Label6)
        Me.pnlLeadFollowUpDate.Controls.Add(Me.cmdLeadFollowUpDateOK)
        Me.pnlLeadFollowUpDate.Location = New System.Drawing.Point(496, 200)
        Me.pnlLeadFollowUpDate.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlLeadFollowUpDate.Name = "pnlLeadFollowUpDate"
        Me.pnlLeadFollowUpDate.Size = New System.Drawing.Size(228, 88)
        Me.pnlLeadFollowUpDate.TabIndex = 29
        Me.pnlLeadFollowUpDate.Visible = False
        '
        'cmdLeadFollowUpDateCancel
        '
        Me.cmdLeadFollowUpDateCancel.Location = New System.Drawing.Point(116, 44)
        Me.cmdLeadFollowUpDateCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdLeadFollowUpDateCancel.Name = "cmdLeadFollowUpDateCancel"
        Me.cmdLeadFollowUpDateCancel.Size = New System.Drawing.Size(99, 28)
        Me.cmdLeadFollowUpDateCancel.TabIndex = 24
        Me.cmdLeadFollowUpDateCancel.Text = "Cancel"
        Me.cmdLeadFollowUpDateCancel.UseVisualStyleBackColor = True
        '
        'txtLeadFollowUpDate
        '
        Me.txtLeadFollowUpDate.Location = New System.Drawing.Point(110, 9)
        Me.txtLeadFollowUpDate.Margin = New System.Windows.Forms.Padding(4)
        Me.txtLeadFollowUpDate.Name = "txtLeadFollowUpDate"
        Me.txtLeadFollowUpDate.Size = New System.Drawing.Size(85, 20)
        Me.txtLeadFollowUpDate.TabIndex = 23
        Me.txtLeadFollowUpDate.Tag = ""
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(4, 11)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 22)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "Follow-up date"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdLeadFollowUpDateOK
        '
        Me.cmdLeadFollowUpDateOK.Location = New System.Drawing.Point(10, 44)
        Me.cmdLeadFollowUpDateOK.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdLeadFollowUpDateOK.Name = "cmdLeadFollowUpDateOK"
        Me.cmdLeadFollowUpDateOK.Size = New System.Drawing.Size(99, 28)
        Me.cmdLeadFollowUpDateOK.TabIndex = 19
        Me.cmdLeadFollowUpDateOK.Text = "OK"
        Me.cmdLeadFollowUpDateOK.UseVisualStyleBackColor = True
        '
        'pnlLeadStatus
        '
        Me.pnlLeadStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlLeadStatus.Controls.Add(Me.cmdLeadStatusCancel)
        Me.pnlLeadStatus.Controls.Add(Me.cboLeadStatus)
        Me.pnlLeadStatus.Controls.Add(Me.Label7)
        Me.pnlLeadStatus.Controls.Add(Me.cmdLeadStatusOK)
        Me.pnlLeadStatus.Location = New System.Drawing.Point(380, 412)
        Me.pnlLeadStatus.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlLeadStatus.Name = "pnlLeadStatus"
        Me.pnlLeadStatus.Size = New System.Drawing.Size(282, 88)
        Me.pnlLeadStatus.TabIndex = 30
        Me.pnlLeadStatus.Visible = False
        '
        'cmdLeadStatusCancel
        '
        Me.cmdLeadStatusCancel.Location = New System.Drawing.Point(152, 44)
        Me.cmdLeadStatusCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdLeadStatusCancel.Name = "cmdLeadStatusCancel"
        Me.cmdLeadStatusCancel.Size = New System.Drawing.Size(99, 28)
        Me.cmdLeadStatusCancel.TabIndex = 24
        Me.cmdLeadStatusCancel.Text = "Cancel"
        Me.cmdLeadStatusCancel.UseVisualStyleBackColor = True
        '
        'cboLeadStatus
        '
        Me.cboLeadStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLeadStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLeadStatus.FormattingEnabled = True
        Me.cboLeadStatus.Location = New System.Drawing.Point(91, 12)
        Me.cboLeadStatus.Margin = New System.Windows.Forms.Padding(4)
        Me.cboLeadStatus.Name = "cboLeadStatus"
        Me.cboLeadStatus.Size = New System.Drawing.Size(180, 21)
        Me.cboLeadStatus.TabIndex = 23
        Me.cboLeadStatus.Tag = ""
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(6, 11)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 22)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "Lead status"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdLeadStatusOK
        '
        Me.cmdLeadStatusOK.Location = New System.Drawing.Point(46, 44)
        Me.cmdLeadStatusOK.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdLeadStatusOK.Name = "cmdLeadStatusOK"
        Me.cmdLeadStatusOK.Size = New System.Drawing.Size(99, 28)
        Me.cmdLeadStatusOK.TabIndex = 19
        Me.cmdLeadStatusOK.Text = "OK"
        Me.cmdLeadStatusOK.UseVisualStyleBackColor = True
        '
        'pnlLeadInfoSentFl
        '
        Me.pnlLeadInfoSentFl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlLeadInfoSentFl.Controls.Add(Me.cmdLeadInfoSentFlCancel)
        Me.pnlLeadInfoSentFl.Controls.Add(Me.chkLeadInfoSentFl)
        Me.pnlLeadInfoSentFl.Controls.Add(Me.cmdLeadInfoSentFlOK)
        Me.pnlLeadInfoSentFl.Location = New System.Drawing.Point(1196, 4)
        Me.pnlLeadInfoSentFl.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlLeadInfoSentFl.Name = "pnlLeadInfoSentFl"
        Me.pnlLeadInfoSentFl.Size = New System.Drawing.Size(247, 88)
        Me.pnlLeadInfoSentFl.TabIndex = 31
        Me.pnlLeadInfoSentFl.Visible = False
        '
        'cmdLeadInfoSentFlCancel
        '
        Me.cmdLeadInfoSentFlCancel.Location = New System.Drawing.Point(126, 42)
        Me.cmdLeadInfoSentFlCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdLeadInfoSentFlCancel.Name = "cmdLeadInfoSentFlCancel"
        Me.cmdLeadInfoSentFlCancel.Size = New System.Drawing.Size(99, 28)
        Me.cmdLeadInfoSentFlCancel.TabIndex = 21
        Me.cmdLeadInfoSentFlCancel.Text = "Cancel"
        Me.cmdLeadInfoSentFlCancel.UseVisualStyleBackColor = True
        '
        'chkLeadInfoSentFl
        '
        Me.chkLeadInfoSentFl.AutoSize = True
        Me.chkLeadInfoSentFl.Location = New System.Drawing.Point(65, 14)
        Me.chkLeadInfoSentFl.Margin = New System.Windows.Forms.Padding(4)
        Me.chkLeadInfoSentFl.Name = "chkLeadInfoSentFl"
        Me.chkLeadInfoSentFl.Size = New System.Drawing.Size(93, 17)
        Me.chkLeadInfoSentFl.TabIndex = 20
        Me.chkLeadInfoSentFl.Tag = ""
        Me.chkLeadInfoSentFl.Text = "Lead info sent"
        Me.chkLeadInfoSentFl.UseVisualStyleBackColor = True
        '
        'cmdLeadInfoSentFlOK
        '
        Me.cmdLeadInfoSentFlOK.Location = New System.Drawing.Point(20, 42)
        Me.cmdLeadInfoSentFlOK.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdLeadInfoSentFlOK.Name = "cmdLeadInfoSentFlOK"
        Me.cmdLeadInfoSentFlOK.Size = New System.Drawing.Size(99, 28)
        Me.cmdLeadInfoSentFlOK.TabIndex = 19
        Me.cmdLeadInfoSentFlOK.Text = "OK"
        Me.cmdLeadInfoSentFlOK.UseVisualStyleBackColor = True
        '
        'pnlSolicitSentDate
        '
        Me.pnlSolicitSentDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlSolicitSentDate.Controls.Add(Me.cmdSolicitSentDateCancel)
        Me.pnlSolicitSentDate.Controls.Add(Me.txtSolicitSentDate)
        Me.pnlSolicitSentDate.Controls.Add(Me.Label8)
        Me.pnlSolicitSentDate.Controls.Add(Me.cmdSolicitSentDateOK)
        Me.pnlSolicitSentDate.Location = New System.Drawing.Point(24, 72)
        Me.pnlSolicitSentDate.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlSolicitSentDate.Name = "pnlSolicitSentDate"
        Me.pnlSolicitSentDate.Size = New System.Drawing.Size(224, 88)
        Me.pnlSolicitSentDate.TabIndex = 32
        Me.pnlSolicitSentDate.Visible = False
        '
        'cmdSolicitSentDateCancel
        '
        Me.cmdSolicitSentDateCancel.Location = New System.Drawing.Point(114, 45)
        Me.cmdSolicitSentDateCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdSolicitSentDateCancel.Name = "cmdSolicitSentDateCancel"
        Me.cmdSolicitSentDateCancel.Size = New System.Drawing.Size(99, 28)
        Me.cmdSolicitSentDateCancel.TabIndex = 24
        Me.cmdSolicitSentDateCancel.Text = "Cancel"
        Me.cmdSolicitSentDateCancel.UseVisualStyleBackColor = True
        '
        'txtSolicitSentDate
        '
        Me.txtSolicitSentDate.Location = New System.Drawing.Point(122, 10)
        Me.txtSolicitSentDate.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSolicitSentDate.Name = "txtSolicitSentDate"
        Me.txtSolicitSentDate.Size = New System.Drawing.Size(85, 20)
        Me.txtSolicitSentDate.TabIndex = 23
        Me.txtSolicitSentDate.Tag = ""
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(4, 11)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(111, 22)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "Solicitation date"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdSolicitSentDateOK
        '
        Me.cmdSolicitSentDateOK.Location = New System.Drawing.Point(8, 45)
        Me.cmdSolicitSentDateOK.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdSolicitSentDateOK.Name = "cmdSolicitSentDateOK"
        Me.cmdSolicitSentDateOK.Size = New System.Drawing.Size(99, 28)
        Me.cmdSolicitSentDateOK.TabIndex = 19
        Me.cmdSolicitSentDateOK.Text = "OK"
        Me.cmdSolicitSentDateOK.UseVisualStyleBackColor = True
        '
        'pnlRenditionAllocationPct
        '
        Me.pnlRenditionAllocationPct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlRenditionAllocationPct.Controls.Add(Me.Label10)
        Me.pnlRenditionAllocationPct.Controls.Add(Me.cmdAllocationPctCancel)
        Me.pnlRenditionAllocationPct.Controls.Add(Me.txtAllocationPct)
        Me.pnlRenditionAllocationPct.Controls.Add(Me.lblAllocation)
        Me.pnlRenditionAllocationPct.Controls.Add(Me.cmdAllocationPctOK)
        Me.pnlRenditionAllocationPct.Location = New System.Drawing.Point(24, 504)
        Me.pnlRenditionAllocationPct.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlRenditionAllocationPct.Name = "pnlRenditionAllocationPct"
        Me.pnlRenditionAllocationPct.Size = New System.Drawing.Size(250, 88)
        Me.pnlRenditionAllocationPct.TabIndex = 33
        Me.pnlRenditionAllocationPct.Visible = False
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(230, 11)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(14, 22)
        Me.Label10.TabIndex = 25
        Me.Label10.Text = "%"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdAllocationPctCancel
        '
        Me.cmdAllocationPctCancel.Location = New System.Drawing.Point(128, 44)
        Me.cmdAllocationPctCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdAllocationPctCancel.Name = "cmdAllocationPctCancel"
        Me.cmdAllocationPctCancel.Size = New System.Drawing.Size(99, 28)
        Me.cmdAllocationPctCancel.TabIndex = 21
        Me.cmdAllocationPctCancel.Text = "Cancel"
        Me.cmdAllocationPctCancel.UseVisualStyleBackColor = True
        '
        'txtAllocationPct
        '
        Me.txtAllocationPct.Location = New System.Drawing.Point(155, 11)
        Me.txtAllocationPct.Margin = New System.Windows.Forms.Padding(4)
        Me.txtAllocationPct.Name = "txtAllocationPct"
        Me.txtAllocationPct.Size = New System.Drawing.Size(70, 20)
        Me.txtAllocationPct.TabIndex = 19
        Me.txtAllocationPct.Tag = ""
        Me.txtAllocationPct.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblAllocation
        '
        Me.lblAllocation.Location = New System.Drawing.Point(4, 11)
        Me.lblAllocation.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAllocation.Name = "lblAllocation"
        Me.lblAllocation.Size = New System.Drawing.Size(144, 22)
        Me.lblAllocation.TabIndex = 22
        Me.lblAllocation.Text = "Allocation Percentage"
        Me.lblAllocation.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdAllocationPctOK
        '
        Me.cmdAllocationPctOK.Location = New System.Drawing.Point(21, 44)
        Me.cmdAllocationPctOK.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdAllocationPctOK.Name = "cmdAllocationPctOK"
        Me.cmdAllocationPctOK.Size = New System.Drawing.Size(99, 28)
        Me.cmdAllocationPctOK.TabIndex = 20
        Me.cmdAllocationPctOK.Text = "OK"
        Me.cmdAllocationPctOK.UseVisualStyleBackColor = True
        '
        'cmdNew
        '
        Me.cmdNew.Enabled = False
        Me.cmdNew.Location = New System.Drawing.Point(836, 36)
        Me.cmdNew.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdNew.Name = "cmdNew"
        Me.cmdNew.Size = New System.Drawing.Size(91, 28)
        Me.cmdNew.TabIndex = 34
        Me.cmdNew.Text = "New"
        Me.cmdNew.UseVisualStyleBackColor = True
        '
        'cmdImport
        '
        Me.cmdImport.Location = New System.Drawing.Point(930, 4)
        Me.cmdImport.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdImport.Name = "cmdImport"
        Me.cmdImport.Size = New System.Drawing.Size(91, 28)
        Me.cmdImport.TabIndex = 35
        Me.cmdImport.Text = "Import"
        Me.cmdImport.UseVisualStyleBackColor = True
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdApply)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdImport)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdExport)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdNew)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdRefresh)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.pnlAgency)
        Me.SplitContainer1.Panel2.Controls.Add(Me.pnlTask)
        Me.SplitContainer1.Panel2.Controls.Add(Me.pnlAuditFl)
        Me.SplitContainer1.Panel2.Controls.Add(Me.pnlLeaseInfo)
        Me.SplitContainer1.Panel2.Controls.Add(Me.pnlSolicitType)
        Me.SplitContainer1.Panel2.Controls.Add(Me.pnlSolicitSentDate)
        Me.SplitContainer1.Panel2.Controls.Add(Me.pnlLeadInfoSentFl)
        Me.SplitContainer1.Panel2.Controls.Add(Me.pnlLeadFollowUpDate)
        Me.SplitContainer1.Panel2.Controls.Add(Me.pnlClient)
        Me.SplitContainer1.Panel2.Controls.Add(Me.pnlConsultantName)
        Me.SplitContainer1.Panel2.Controls.Add(Me.pnlClientCoordinatorName)
        Me.SplitContainer1.Panel2.Controls.Add(Me.pnlBusinessUnit)
        Me.SplitContainer1.Panel2.Controls.Add(Me.pnlRenditionAllocationPct)
        Me.SplitContainer1.Panel2.Controls.Add(Me.pnlLeadStatus)
        Me.SplitContainer1.Panel2.Controls.Add(Me.pnlLeadMailDate)
        Me.SplitContainer1.Panel2.Controls.Add(Me.pnlECUParent)
        Me.SplitContainer1.Panel2.Controls.Add(Me.pnlFactor)
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgList)
        Me.SplitContainer1.Size = New System.Drawing.Size(1453, 740)
        Me.SplitContainer1.SplitterDistance = 127
        Me.SplitContainer1.TabIndex = 36
        '
        'Panel1
        '
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Panel1.Controls.Add(Me.lblTotal)
        Me.Panel1.Controls.Add(Me.lblFixed)
        Me.Panel1.Controls.Add(Me.lblInv)
        Me.Panel1.Controls.Add(Me.txtInv)
        Me.Panel1.Controls.Add(Me.txtFixed)
        Me.Panel1.Controls.Add(Me.chkShowFactor)
        Me.Panel1.Controls.Add(Me.txtTotal)
        Me.Panel1.Controls.Add(Me.txtRowCount)
        Me.Panel1.Location = New System.Drawing.Point(1208, 4)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(237, 108)
        Me.Panel1.TabIndex = 37
        '
        'lblTotal
        '
        Me.lblTotal.Location = New System.Drawing.Point(20, 24)
        Me.lblTotal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(96, 12)
        Me.lblTotal.TabIndex = 29
        Me.lblTotal.Text = "Total original cost"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblTotal.Visible = False
        '
        'lblFixed
        '
        Me.lblFixed.Location = New System.Drawing.Point(4, 40)
        Me.lblFixed.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFixed.Name = "lblFixed"
        Me.lblFixed.Size = New System.Drawing.Size(112, 12)
        Me.lblFixed.TabIndex = 28
        Me.lblFixed.Text = "Total fixed asset cost"
        Me.lblFixed.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblFixed.Visible = False
        '
        'lblInv
        '
        Me.lblInv.Location = New System.Drawing.Point(4, 56)
        Me.lblInv.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblInv.Name = "lblInv"
        Me.lblInv.Size = New System.Drawing.Size(112, 12)
        Me.lblInv.TabIndex = 27
        Me.lblInv.Text = "Total inventory cost"
        Me.lblInv.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblInv.Visible = False
        '
        'txtInv
        '
        Me.txtInv.BackColor = System.Drawing.SystemColors.Control
        Me.txtInv.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtInv.Location = New System.Drawing.Point(132, 56)
        Me.txtInv.Margin = New System.Windows.Forms.Padding(4)
        Me.txtInv.Multiline = True
        Me.txtInv.Name = "txtInv"
        Me.txtInv.ReadOnly = True
        Me.txtInv.Size = New System.Drawing.Size(100, 16)
        Me.txtInv.TabIndex = 26
        Me.txtInv.TabStop = False
        Me.txtInv.Text = "txtInv"
        Me.txtInv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFixed
        '
        Me.txtFixed.BackColor = System.Drawing.SystemColors.Control
        Me.txtFixed.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtFixed.Location = New System.Drawing.Point(132, 40)
        Me.txtFixed.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFixed.Multiline = True
        Me.txtFixed.Name = "txtFixed"
        Me.txtFixed.ReadOnly = True
        Me.txtFixed.Size = New System.Drawing.Size(100, 16)
        Me.txtFixed.TabIndex = 25
        Me.txtFixed.TabStop = False
        Me.txtFixed.Text = "txtFixed"
        Me.txtFixed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'pnlAgency
        '
        Me.pnlAgency.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlAgency.Controls.Add(Me.cmdAgencyCancel)
        Me.pnlAgency.Controls.Add(Me.Label20)
        Me.pnlAgency.Controls.Add(Me.cmdAgencyOK)
        Me.pnlAgency.Controls.Add(Me.cboAgency)
        Me.pnlAgency.Location = New System.Drawing.Point(1001, 409)
        Me.pnlAgency.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlAgency.Name = "pnlAgency"
        Me.pnlAgency.Size = New System.Drawing.Size(340, 84)
        Me.pnlAgency.TabIndex = 37
        Me.pnlAgency.Visible = False
        '
        'cmdAgencyCancel
        '
        Me.cmdAgencyCancel.Location = New System.Drawing.Point(175, 40)
        Me.cmdAgencyCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdAgencyCancel.Name = "cmdAgencyCancel"
        Me.cmdAgencyCancel.Size = New System.Drawing.Size(99, 28)
        Me.cmdAgencyCancel.TabIndex = 23
        Me.cmdAgencyCancel.Text = "Cancel"
        Me.cmdAgencyCancel.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(4, 10)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(71, 22)
        Me.Label20.TabIndex = 22
        Me.Label20.Text = "Agency"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdAgencyOK
        '
        Me.cmdAgencyOK.Location = New System.Drawing.Point(68, 40)
        Me.cmdAgencyOK.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdAgencyOK.Name = "cmdAgencyOK"
        Me.cmdAgencyOK.Size = New System.Drawing.Size(99, 28)
        Me.cmdAgencyOK.TabIndex = 19
        Me.cmdAgencyOK.Text = "OK"
        Me.cmdAgencyOK.UseVisualStyleBackColor = True
        '
        'cboAgency
        '
        Me.cboAgency.FormattingEnabled = True
        Me.cboAgency.Location = New System.Drawing.Point(83, 11)
        Me.cboAgency.Margin = New System.Windows.Forms.Padding(4)
        Me.cboAgency.Name = "cboAgency"
        Me.cboAgency.Size = New System.Drawing.Size(246, 21)
        Me.cboAgency.TabIndex = 4
        '
        'pnlTask
        '
        Me.pnlTask.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlTask.Controls.Add(Me.cmdTaskCancel)
        Me.pnlTask.Controls.Add(Me.Label19)
        Me.pnlTask.Controls.Add(Me.cmdTaskOK)
        Me.pnlTask.Controls.Add(Me.cboTask)
        Me.pnlTask.Location = New System.Drawing.Point(945, 309)
        Me.pnlTask.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlTask.Name = "pnlTask"
        Me.pnlTask.Size = New System.Drawing.Size(340, 84)
        Me.pnlTask.TabIndex = 36
        Me.pnlTask.Visible = False
        '
        'cmdTaskCancel
        '
        Me.cmdTaskCancel.Location = New System.Drawing.Point(175, 40)
        Me.cmdTaskCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdTaskCancel.Name = "cmdTaskCancel"
        Me.cmdTaskCancel.Size = New System.Drawing.Size(99, 28)
        Me.cmdTaskCancel.TabIndex = 23
        Me.cmdTaskCancel.Text = "Cancel"
        Me.cmdTaskCancel.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(20, 10)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(55, 22)
        Me.Label19.TabIndex = 22
        Me.Label19.Text = "Task"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdTaskOK
        '
        Me.cmdTaskOK.Location = New System.Drawing.Point(68, 40)
        Me.cmdTaskOK.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdTaskOK.Name = "cmdTaskOK"
        Me.cmdTaskOK.Size = New System.Drawing.Size(99, 28)
        Me.cmdTaskOK.TabIndex = 19
        Me.cmdTaskOK.Text = "OK"
        Me.cmdTaskOK.UseVisualStyleBackColor = True
        '
        'cboTask
        '
        Me.cboTask.FormattingEnabled = True
        Me.cboTask.Location = New System.Drawing.Point(83, 11)
        Me.cboTask.Margin = New System.Windows.Forms.Padding(4)
        Me.cboTask.Name = "cboTask"
        Me.cboTask.Size = New System.Drawing.Size(246, 21)
        Me.cboTask.TabIndex = 4
        '
        'pnlAuditFl
        '
        Me.pnlAuditFl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlAuditFl.Controls.Add(Me.cmdAuditFlCancel)
        Me.pnlAuditFl.Controls.Add(Me.chkAuditFl)
        Me.pnlAuditFl.Controls.Add(Me.cmdAuditFlOK)
        Me.pnlAuditFl.Location = New System.Drawing.Point(1196, 96)
        Me.pnlAuditFl.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlAuditFl.Name = "pnlAuditFl"
        Me.pnlAuditFl.Size = New System.Drawing.Size(247, 88)
        Me.pnlAuditFl.TabIndex = 35
        Me.pnlAuditFl.Visible = False
        '
        'cmdAuditFlCancel
        '
        Me.cmdAuditFlCancel.Location = New System.Drawing.Point(126, 42)
        Me.cmdAuditFlCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdAuditFlCancel.Name = "cmdAuditFlCancel"
        Me.cmdAuditFlCancel.Size = New System.Drawing.Size(99, 28)
        Me.cmdAuditFlCancel.TabIndex = 21
        Me.cmdAuditFlCancel.Text = "Cancel"
        Me.cmdAuditFlCancel.UseVisualStyleBackColor = True
        '
        'chkAuditFl
        '
        Me.chkAuditFl.AutoSize = True
        Me.chkAuditFl.Location = New System.Drawing.Point(88, 12)
        Me.chkAuditFl.Margin = New System.Windows.Forms.Padding(4)
        Me.chkAuditFl.Name = "chkAuditFl"
        Me.chkAuditFl.Size = New System.Drawing.Size(62, 17)
        Me.chkAuditFl.TabIndex = 20
        Me.chkAuditFl.Tag = ""
        Me.chkAuditFl.Text = "Audited"
        Me.chkAuditFl.UseVisualStyleBackColor = True
        '
        'cmdAuditFlOK
        '
        Me.cmdAuditFlOK.Location = New System.Drawing.Point(20, 42)
        Me.cmdAuditFlOK.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdAuditFlOK.Name = "cmdAuditFlOK"
        Me.cmdAuditFlOK.Size = New System.Drawing.Size(99, 28)
        Me.cmdAuditFlOK.TabIndex = 19
        Me.cmdAuditFlOK.Text = "OK"
        Me.cmdAuditFlOK.UseVisualStyleBackColor = True
        '
        'pnlLeaseInfo
        '
        Me.pnlLeaseInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlLeaseInfo.Controls.Add(Me.cboLesseeStateCd)
        Me.pnlLeaseInfo.Controls.Add(Me.txtLesseeZip)
        Me.pnlLeaseInfo.Controls.Add(Me.Label22)
        Me.pnlLeaseInfo.Controls.Add(Me.txtLesseeCity)
        Me.pnlLeaseInfo.Controls.Add(Me.Label21)
        Me.pnlLeaseInfo.Controls.Add(Me.txtLesseeName)
        Me.pnlLeaseInfo.Controls.Add(Me.txtLesseeAddress)
        Me.pnlLeaseInfo.Controls.Add(Me.txtEquipmentMake)
        Me.pnlLeaseInfo.Controls.Add(Me.txtLeaseTerm)
        Me.pnlLeaseInfo.Controls.Add(Me.txtEquipmentModel)
        Me.pnlLeaseInfo.Controls.Add(Me.Label14)
        Me.pnlLeaseInfo.Controls.Add(Me.Label15)
        Me.pnlLeaseInfo.Controls.Add(Me.Label16)
        Me.pnlLeaseInfo.Controls.Add(Me.Label17)
        Me.pnlLeaseInfo.Controls.Add(Me.Label18)
        Me.pnlLeaseInfo.Controls.Add(Me.cmdLeaseInfoCancel)
        Me.pnlLeaseInfo.Controls.Add(Me.cboLeaseType)
        Me.pnlLeaseInfo.Controls.Add(Me.Label13)
        Me.pnlLeaseInfo.Controls.Add(Me.cmdLeaseInfoOK)
        Me.pnlLeaseInfo.Location = New System.Drawing.Point(732, 4)
        Me.pnlLeaseInfo.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlLeaseInfo.Name = "pnlLeaseInfo"
        Me.pnlLeaseInfo.Size = New System.Drawing.Size(452, 244)
        Me.pnlLeaseInfo.TabIndex = 34
        Me.pnlLeaseInfo.Visible = False
        '
        'cboLesseeStateCd
        '
        Me.cboLesseeStateCd.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLesseeStateCd.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLesseeStateCd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboLesseeStateCd.FormattingEnabled = True
        Me.cboLesseeStateCd.Location = New System.Drawing.Point(136, 104)
        Me.cboLesseeStateCd.Margin = New System.Windows.Forms.Padding(4)
        Me.cboLesseeStateCd.Name = "cboLesseeStateCd"
        Me.cboLesseeStateCd.Size = New System.Drawing.Size(200, 21)
        Me.cboLesseeStateCd.TabIndex = 4
        Me.cboLesseeStateCd.Tag = ""
        Me.cboLesseeStateCd.Text = "Lessee state"
        '
        'txtLesseeZip
        '
        Me.txtLesseeZip.AllowDrop = True
        Me.txtLesseeZip.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLesseeZip.Location = New System.Drawing.Point(340, 104)
        Me.txtLesseeZip.Name = "txtLesseeZip"
        Me.txtLesseeZip.Size = New System.Drawing.Size(92, 20)
        Me.txtLesseeZip.TabIndex = 5
        Me.txtLesseeZip.Tag = ""
        Me.txtLesseeZip.Text = "Lessee zip"
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(8, 108)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(96, 13)
        Me.Label22.TabIndex = 225
        Me.Label22.Text = "Lessee state/zip"
        '
        'txtLesseeCity
        '
        Me.txtLesseeCity.AllowDrop = True
        Me.txtLesseeCity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLesseeCity.Location = New System.Drawing.Point(136, 80)
        Me.txtLesseeCity.Name = "txtLesseeCity"
        Me.txtLesseeCity.Size = New System.Drawing.Size(296, 20)
        Me.txtLesseeCity.TabIndex = 3
        Me.txtLesseeCity.Tag = ""
        Me.txtLesseeCity.Text = "Lessee city"
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(8, 84)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(96, 13)
        Me.Label21.TabIndex = 223
        Me.Label21.Text = "Lessee city"
        '
        'txtLesseeName
        '
        Me.txtLesseeName.AllowDrop = True
        Me.txtLesseeName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLesseeName.Location = New System.Drawing.Point(136, 32)
        Me.txtLesseeName.Name = "txtLesseeName"
        Me.txtLesseeName.Size = New System.Drawing.Size(180, 20)
        Me.txtLesseeName.TabIndex = 1
        Me.txtLesseeName.Tag = ""
        Me.txtLesseeName.Text = "Lessee name"
        Me.txtLesseeName.WordWrap = False
        '
        'txtLesseeAddress
        '
        Me.txtLesseeAddress.AllowDrop = True
        Me.txtLesseeAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLesseeAddress.Location = New System.Drawing.Point(136, 56)
        Me.txtLesseeAddress.Name = "txtLesseeAddress"
        Me.txtLesseeAddress.Size = New System.Drawing.Size(296, 20)
        Me.txtLesseeAddress.TabIndex = 2
        Me.txtLesseeAddress.Tag = ""
        Me.txtLesseeAddress.Text = "Lessee address"
        '
        'txtEquipmentMake
        '
        Me.txtEquipmentMake.AllowDrop = True
        Me.txtEquipmentMake.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEquipmentMake.Location = New System.Drawing.Point(136, 156)
        Me.txtEquipmentMake.Name = "txtEquipmentMake"
        Me.txtEquipmentMake.Size = New System.Drawing.Size(180, 20)
        Me.txtEquipmentMake.TabIndex = 7
        Me.txtEquipmentMake.Tag = ""
        Me.txtEquipmentMake.Text = "Equipment make"
        '
        'txtLeaseTerm
        '
        Me.txtLeaseTerm.AllowDrop = True
        Me.txtLeaseTerm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLeaseTerm.Location = New System.Drawing.Point(136, 132)
        Me.txtLeaseTerm.Name = "txtLeaseTerm"
        Me.txtLeaseTerm.Size = New System.Drawing.Size(72, 20)
        Me.txtLeaseTerm.TabIndex = 6
        Me.txtLeaseTerm.Tag = ""
        Me.txtLeaseTerm.Text = "Lease Term"
        Me.txtLeaseTerm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtEquipmentModel
        '
        Me.txtEquipmentModel.AllowDrop = True
        Me.txtEquipmentModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEquipmentModel.Location = New System.Drawing.Point(136, 180)
        Me.txtEquipmentModel.Name = "txtEquipmentModel"
        Me.txtEquipmentModel.Size = New System.Drawing.Size(180, 20)
        Me.txtEquipmentModel.TabIndex = 8
        Me.txtEquipmentModel.Tag = ""
        Me.txtEquipmentModel.Text = "Equipment model"
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(8, 36)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(76, 20)
        Me.Label14.TabIndex = 221
        Me.Label14.Text = "Lessee name"
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(8, 136)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(102, 13)
        Me.Label15.TabIndex = 220
        Me.Label15.Text = "Lease term (months)"
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(8, 60)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(96, 13)
        Me.Label16.TabIndex = 219
        Me.Label16.Text = "Lessee address"
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(8, 184)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(88, 13)
        Me.Label17.TabIndex = 218
        Me.Label17.Text = "Equipment model"
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(8, 160)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(86, 13)
        Me.Label18.TabIndex = 217
        Me.Label18.Text = "Equipment make"
        '
        'cmdLeaseInfoCancel
        '
        Me.cmdLeaseInfoCancel.Location = New System.Drawing.Point(228, 208)
        Me.cmdLeaseInfoCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdLeaseInfoCancel.Name = "cmdLeaseInfoCancel"
        Me.cmdLeaseInfoCancel.Size = New System.Drawing.Size(99, 28)
        Me.cmdLeaseInfoCancel.TabIndex = 10
        Me.cmdLeaseInfoCancel.Text = "Cancel"
        Me.cmdLeaseInfoCancel.UseVisualStyleBackColor = True
        '
        'cboLeaseType
        '
        Me.cboLeaseType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLeaseType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLeaseType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboLeaseType.FormattingEnabled = True
        Me.cboLeaseType.Location = New System.Drawing.Point(136, 8)
        Me.cboLeaseType.Margin = New System.Windows.Forms.Padding(4)
        Me.cboLeaseType.Name = "cboLeaseType"
        Me.cboLeaseType.Size = New System.Drawing.Size(180, 21)
        Me.cboLeaseType.TabIndex = 0
        Me.cboLeaseType.Tag = ""
        Me.cboLeaseType.Text = "Lease type"
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(8, 12)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(104, 21)
        Me.Label13.TabIndex = 22
        Me.Label13.Text = "Lease type"
        '
        'cmdLeaseInfoOK
        '
        Me.cmdLeaseInfoOK.Location = New System.Drawing.Point(120, 208)
        Me.cmdLeaseInfoOK.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdLeaseInfoOK.Name = "cmdLeaseInfoOK"
        Me.cmdLeaseInfoOK.Size = New System.Drawing.Size(99, 28)
        Me.cmdLeaseInfoOK.TabIndex = 9
        Me.cmdLeaseInfoOK.Text = "OK"
        Me.cmdLeaseInfoOK.UseVisualStyleBackColor = True
        '
        'pnlConsultantName
        '
        Me.pnlConsultantName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlConsultantName.Controls.Add(Me.cmdConsultantNameCancel)
        Me.pnlConsultantName.Controls.Add(Me.cboConsultantName)
        Me.pnlConsultantName.Controls.Add(Me.Label12)
        Me.pnlConsultantName.Controls.Add(Me.cmdConsultantNameOK)
        Me.pnlConsultantName.Location = New System.Drawing.Point(376, 308)
        Me.pnlConsultantName.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlConsultantName.Name = "pnlConsultantName"
        Me.pnlConsultantName.Size = New System.Drawing.Size(300, 88)
        Me.pnlConsultantName.TabIndex = 32
        Me.pnlConsultantName.Visible = False
        '
        'cmdConsultantNameCancel
        '
        Me.cmdConsultantNameCancel.Location = New System.Drawing.Point(152, 44)
        Me.cmdConsultantNameCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdConsultantNameCancel.Name = "cmdConsultantNameCancel"
        Me.cmdConsultantNameCancel.Size = New System.Drawing.Size(99, 28)
        Me.cmdConsultantNameCancel.TabIndex = 24
        Me.cmdConsultantNameCancel.Text = "Cancel"
        Me.cmdConsultantNameCancel.UseVisualStyleBackColor = True
        '
        'cboConsultantName
        '
        Me.cboConsultantName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboConsultantName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboConsultantName.FormattingEnabled = True
        Me.cboConsultantName.Location = New System.Drawing.Point(112, 12)
        Me.cboConsultantName.Margin = New System.Windows.Forms.Padding(4)
        Me.cboConsultantName.Name = "cboConsultantName"
        Me.cboConsultantName.Size = New System.Drawing.Size(180, 21)
        Me.cboConsultantName.TabIndex = 23
        Me.cboConsultantName.Tag = ""
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(4, 11)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(96, 22)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "Consultant"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdConsultantNameOK
        '
        Me.cmdConsultantNameOK.Location = New System.Drawing.Point(46, 44)
        Me.cmdConsultantNameOK.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdConsultantNameOK.Name = "cmdConsultantNameOK"
        Me.cmdConsultantNameOK.Size = New System.Drawing.Size(99, 28)
        Me.cmdConsultantNameOK.TabIndex = 19
        Me.cmdConsultantNameOK.Text = "OK"
        Me.cmdConsultantNameOK.UseVisualStyleBackColor = True
        '
        'pnlBusinessUnit
        '
        Me.pnlBusinessUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlBusinessUnit.Controls.Add(Me.cmdBusinessUnitCancel)
        Me.pnlBusinessUnit.Controls.Add(Me.Label9)
        Me.pnlBusinessUnit.Controls.Add(Me.cmdBusinessUnitOK)
        Me.pnlBusinessUnit.Controls.Add(Me.cboBusinessUnit)
        Me.pnlBusinessUnit.Location = New System.Drawing.Point(24, 412)
        Me.pnlBusinessUnit.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlBusinessUnit.Name = "pnlBusinessUnit"
        Me.pnlBusinessUnit.Size = New System.Drawing.Size(340, 84)
        Me.pnlBusinessUnit.TabIndex = 31
        Me.pnlBusinessUnit.Visible = False
        '
        'cmdBusinessUnitCancel
        '
        Me.cmdBusinessUnitCancel.Location = New System.Drawing.Point(175, 40)
        Me.cmdBusinessUnitCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdBusinessUnitCancel.Name = "cmdBusinessUnitCancel"
        Me.cmdBusinessUnitCancel.Size = New System.Drawing.Size(99, 28)
        Me.cmdBusinessUnitCancel.TabIndex = 23
        Me.cmdBusinessUnitCancel.Text = "Cancel"
        Me.cmdBusinessUnitCancel.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(4, 10)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(71, 22)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "Business Unit"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdBusinessUnitOK
        '
        Me.cmdBusinessUnitOK.Location = New System.Drawing.Point(68, 40)
        Me.cmdBusinessUnitOK.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdBusinessUnitOK.Name = "cmdBusinessUnitOK"
        Me.cmdBusinessUnitOK.Size = New System.Drawing.Size(99, 28)
        Me.cmdBusinessUnitOK.TabIndex = 19
        Me.cmdBusinessUnitOK.Text = "OK"
        Me.cmdBusinessUnitOK.UseVisualStyleBackColor = True
        '
        'cboBusinessUnit
        '
        Me.cboBusinessUnit.FormattingEnabled = True
        Me.cboBusinessUnit.Location = New System.Drawing.Point(83, 11)
        Me.cboBusinessUnit.Margin = New System.Windows.Forms.Padding(4)
        Me.cboBusinessUnit.Name = "cboBusinessUnit"
        Me.cboBusinessUnit.Size = New System.Drawing.Size(246, 21)
        Me.cboBusinessUnit.TabIndex = 4
        '
        'pnlECUParent
        '
        Me.pnlECUParent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlECUParent.Controls.Add(Me.cmdECUParentCancel)
        Me.pnlECUParent.Controls.Add(Me.Label11)
        Me.pnlECUParent.Controls.Add(Me.cmdECUParentOK)
        Me.pnlECUParent.Controls.Add(Me.cboECUParent)
        Me.pnlECUParent.Location = New System.Drawing.Point(296, 508)
        Me.pnlECUParent.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlECUParent.Name = "pnlECUParent"
        Me.pnlECUParent.Size = New System.Drawing.Size(800, 84)
        Me.pnlECUParent.TabIndex = 22
        Me.pnlECUParent.Visible = False
        '
        'cmdECUParentCancel
        '
        Me.cmdECUParentCancel.Location = New System.Drawing.Point(401, 45)
        Me.cmdECUParentCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdECUParentCancel.Name = "cmdECUParentCancel"
        Me.cmdECUParentCancel.Size = New System.Drawing.Size(99, 28)
        Me.cmdECUParentCancel.TabIndex = 23
        Me.cmdECUParentCancel.Text = "Cancel"
        Me.cmdECUParentCancel.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(10, 10)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(84, 22)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "ECU Parent"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdECUParentOK
        '
        Me.cmdECUParentOK.Location = New System.Drawing.Point(295, 45)
        Me.cmdECUParentOK.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdECUParentOK.Name = "cmdECUParentOK"
        Me.cmdECUParentOK.Size = New System.Drawing.Size(99, 28)
        Me.cmdECUParentOK.TabIndex = 19
        Me.cmdECUParentOK.Text = "OK"
        Me.cmdECUParentOK.UseVisualStyleBackColor = True
        '
        'cboECUParent
        '
        Me.cboECUParent.FormattingEnabled = True
        Me.cboECUParent.Location = New System.Drawing.Point(100, 11)
        Me.cboECUParent.Margin = New System.Windows.Forms.Padding(4)
        Me.cboECUParent.Name = "cboECUParent"
        Me.cboECUParent.Size = New System.Drawing.Size(689, 21)
        Me.cboECUParent.TabIndex = 4
        '
        'frmList
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1453, 740)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmList"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.dgList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ContextMenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.pnlFactor.ResumeLayout(False)
        Me.pnlClient.ResumeLayout(False)
        Me.pnlLeadMailDate.ResumeLayout(False)
        Me.pnlLeadMailDate.PerformLayout()
        Me.pnlClientCoordinatorName.ResumeLayout(False)
        Me.pnlSolicitType.ResumeLayout(False)
        Me.pnlLeadFollowUpDate.ResumeLayout(False)
        Me.pnlLeadFollowUpDate.PerformLayout()
        Me.pnlLeadStatus.ResumeLayout(False)
        Me.pnlLeadInfoSentFl.ResumeLayout(False)
        Me.pnlLeadInfoSentFl.PerformLayout()
        Me.pnlSolicitSentDate.ResumeLayout(False)
        Me.pnlSolicitSentDate.PerformLayout()
        Me.pnlRenditionAllocationPct.ResumeLayout(False)
        Me.pnlRenditionAllocationPct.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlAgency.ResumeLayout(False)
        Me.pnlTask.ResumeLayout(False)
        Me.pnlAuditFl.ResumeLayout(False)
        Me.pnlAuditFl.PerformLayout()
        Me.pnlLeaseInfo.ResumeLayout(False)
        Me.pnlLeaseInfo.PerformLayout()
        Me.pnlConsultantName.ResumeLayout(False)
        Me.pnlBusinessUnit.ResumeLayout(False)
        Me.pnlECUParent.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgList As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboSortType3 As System.Windows.Forms.ComboBox
    Friend WithEvents cboSortType2 As System.Windows.Forms.ComboBox
    Friend WithEvents cboSortType1 As System.Windows.Forms.ComboBox
    Friend WithEvents cboSortField3 As System.Windows.Forms.ComboBox
    Friend WithEvents cboSortField2 As System.Windows.Forms.ComboBox
    Friend WithEvents cboSortField1 As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtFilterValue3 As System.Windows.Forms.TextBox
    Friend WithEvents txtFilterValue2 As System.Windows.Forms.TextBox
    Friend WithEvents txtFilterValue1 As System.Windows.Forms.TextBox
    Friend WithEvents cboFilterField3 As System.Windows.Forms.ComboBox
    Friend WithEvents cboFilterField2 As System.Windows.Forms.ComboBox
    Friend WithEvents cboFilterField1 As System.Windows.Forms.ComboBox
    Friend WithEvents cmdApply As System.Windows.Forms.Button
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents txtRowCount As System.Windows.Forms.TextBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuContextFactor As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlFactor As System.Windows.Forms.Panel
    Friend WithEvents lblFactorEntityName As System.Windows.Forms.Label
    Friend WithEvents cmdFactorOK As System.Windows.Forms.Button
    Friend WithEvents cboFactorFactorCode As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents mnuContextDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuContextPrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdExport As System.Windows.Forms.Button
    Friend WithEvents chkShowFactor As System.Windows.Forms.CheckBox
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents mnuContextTextBox As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuContextLabelEdit As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents pnlClient As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdClientOK As System.Windows.Forms.Button
    Friend WithEvents cboClient As System.Windows.Forms.ComboBox
    Friend WithEvents mnuContextAssignToClient As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuContextOpenProspect As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuContextImportTaxBill As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuContextViewTaxBill As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlSolicitType As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents pnlLeadFollowUpDate As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmdLeadFollowUpDateOK As System.Windows.Forms.Button
    Friend WithEvents cmdSolicitTypeOK As System.Windows.Forms.Button
    Friend WithEvents pnlLeadMailDate As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdLeadMailDateOK As System.Windows.Forms.Button
    Friend WithEvents pnlClientCoordinatorName As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdClientCoordinatorNameOK As System.Windows.Forms.Button
    Friend WithEvents pnlLeadStatus As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmdLeadStatusOK As System.Windows.Forms.Button
    Friend WithEvents txtLeadFollowUpDate As System.Windows.Forms.TextBox
    Friend WithEvents cboSolicitType As System.Windows.Forms.ComboBox
    Friend WithEvents cboClientCoordinatorName As System.Windows.Forms.ComboBox
    Friend WithEvents txtLeadMailDate As System.Windows.Forms.TextBox
    Friend WithEvents cboLeadStatus As System.Windows.Forms.ComboBox
    Friend WithEvents pnlLeadInfoSentFl As System.Windows.Forms.Panel
    Friend WithEvents cmdLeadInfoSentFlOK As System.Windows.Forms.Button
    Friend WithEvents chkLeadInfoSentFl As System.Windows.Forms.CheckBox
    Friend WithEvents mnuContextSetSolicitType As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuContextSetSolicitSentDate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlSolicitSentDate As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmdSolicitSentDateOK As System.Windows.Forms.Button
    Friend WithEvents txtSolicitSentDate As System.Windows.Forms.TextBox
    Friend WithEvents mnuContextSetLeadMailDate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuContextSetLeadFollowUpDate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuContextSetLeadStatus As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuContextSetClientCoordinatorName As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuContextSetLeadInfoSentFl As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdClientCoordinatorNameCancel As System.Windows.Forms.Button
    Friend WithEvents cmdFactorCancel As System.Windows.Forms.Button
    Friend WithEvents cmdClientCancel As System.Windows.Forms.Button
    Friend WithEvents cmdLeadMailDateCancel As System.Windows.Forms.Button
    Friend WithEvents cmdSolicitTypeCancel As System.Windows.Forms.Button
    Friend WithEvents cmdLeadFollowUpDateCancel As System.Windows.Forms.Button
    Friend WithEvents cmdLeadStatusCancel As System.Windows.Forms.Button
    Friend WithEvents cmdLeadInfoSentFlCancel As System.Windows.Forms.Button
    Friend WithEvents cmdSolicitSentDateCancel As System.Windows.Forms.Button
    Friend WithEvents pnlRenditionAllocationPct As System.Windows.Forms.Panel
    Friend WithEvents cmdAllocationPctCancel As System.Windows.Forms.Button
    Friend WithEvents txtAllocationPct As System.Windows.Forms.TextBox
    Friend WithEvents lblAllocation As System.Windows.Forms.Label
    Friend WithEvents cmdAllocationPctOK As System.Windows.Forms.Button
    Friend WithEvents mnuContextSetRenditionServiceLevel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmdNew As System.Windows.Forms.Button
    Friend WithEvents mnuContextAddJurisdiction As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdImport As System.Windows.Forms.Button
    Friend WithEvents mnuContextModifyQuery As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuContextCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents mnuContextSetECUParent As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlECUParent As System.Windows.Forms.Panel
    Friend WithEvents cmdECUParentCancel As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmdECUParentOK As System.Windows.Forms.Button
    Friend WithEvents cboECUParent As System.Windows.Forms.ComboBox
    Friend WithEvents mnuContextSetRenditionInterstateAllocation As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuContextSetBusinessUnit As ToolStripMenuItem
    Friend WithEvents pnlBusinessUnit As Panel
    Friend WithEvents cmdBusinessUnitCancel As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents cmdBusinessUnitOK As Button
    Friend WithEvents cboBusinessUnit As ComboBox
    Friend WithEvents mnuContextOpenListOfAssets As ToolStripMenuItem
    Friend WithEvents mnuContextOpenAssessmentValues As ToolStripMenuItem
    Friend WithEvents pnlConsultantName As Panel
    Friend WithEvents cmdConsultantNameCancel As Button
    Friend WithEvents cboConsultantName As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents cmdConsultantNameOK As Button
    Friend WithEvents mnuContextSetConsultantName As ToolStripMenuItem
    Friend WithEvents mnuContextSetLeaseInfo As ToolStripMenuItem
    Friend WithEvents pnlLeaseInfo As Panel
    Friend WithEvents cmdLeaseInfoCancel As Button
    Friend WithEvents cboLeaseType As ComboBox
    Friend WithEvents Label13 As Label
    Friend WithEvents cmdLeaseInfoOK As Button
    Friend WithEvents txtLesseeName As TextBox
    Friend WithEvents txtLesseeAddress As TextBox
    Friend WithEvents txtEquipmentMake As TextBox
    Friend WithEvents txtLeaseTerm As TextBox
    Friend WithEvents txtEquipmentModel As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents pnlAuditFl As Panel
    Friend WithEvents cmdAuditFlCancel As Button
    Friend WithEvents chkAuditFl As CheckBox
    Friend WithEvents cmdAuditFlOK As Button
    Friend WithEvents mnuContextSetRenditionAuditFl As ToolStripMenuItem
    Friend WithEvents txtInv As TextBox
    Friend WithEvents txtFixed As TextBox
    Friend WithEvents lblTotal As Label
    Friend WithEvents lblFixed As Label
    Friend WithEvents lblInv As Label
    Friend WithEvents mnuContextImportAssets As ToolStripMenuItem
    Friend WithEvents mnuContextDeleteAssets As ToolStripMenuItem
    Friend WithEvents pnlTask As Panel
    Friend WithEvents cmdTaskCancel As Button
    Friend WithEvents Label19 As Label
    Friend WithEvents cmdTaskOK As Button
    Friend WithEvents cboTask As ComboBox
    Friend WithEvents mnuContextAssignTask As ToolStripMenuItem
    Friend WithEvents pnlAgency As Panel
    Friend WithEvents cmdAgencyCancel As Button
    Friend WithEvents Label20 As Label
    Friend WithEvents cmdAgencyOK As Button
    Friend WithEvents cboAgency As ComboBox
    Friend WithEvents mnuContextSetAgency As ToolStripMenuItem
    Friend WithEvents cboLesseeStateCd As ComboBox
    Friend WithEvents txtLesseeZip As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents txtLesseeCity As TextBox
    Friend WithEvents Label21 As Label
End Class
