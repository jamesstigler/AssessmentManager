<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBPPComps
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.cmdDelete = New System.Windows.Forms.Button()
        Me.cboAssetCategory = New System.Windows.Forms.ComboBox()
        Me.cboIndustry = New System.Windows.Forms.ComboBox()
        Me.cmdExport = New System.Windows.Forms.Button()
        Me.cboDiscontinuedFl = New System.Windows.Forms.ComboBox()
        Me.cboSoldFl = New System.Windows.Forms.ComboBox()
        Me.cmdPrint = New System.Windows.Forms.Button()
        Me.txtCount = New System.Windows.Forms.TextBox()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdSearch = New System.Windows.Forms.Button()
        Me.cboUsedFl = New System.Windows.Forms.ComboBox()
        Me.txtCompSource = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.listModel = New System.Windows.Forms.ListBox()
        Me.contextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.menuClearSelected = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.txtManufactureYear = New System.Windows.Forms.TextBox()
        Me.txtSalePriceTo = New System.Windows.Forms.TextBox()
        Me.txtManufacturer = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtSaleYearFrom = New System.Windows.Forms.TextBox()
        Me.txtSaleYearTo = New System.Windows.Forms.TextBox()
        Me.txtSalePriceFrom = New System.Windows.Forms.TextBox()
        Me.txtSerialNumber = New System.Windows.Forms.TextBox()
        Me.txtMachineHoursTo = New System.Windows.Forms.TextBox()
        Me.txtMachineHoursFrom = New System.Windows.Forms.TextBox()
        Me.txtAssetType = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gridResults = New System.Windows.Forms.DataGridView()
        Me.contextMenuGrid = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.menuRemoveRow = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.contextMenu.SuspendLayout()
        CType(Me.gridResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.contextMenuGrid.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdDelete)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cboAssetCategory)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cboIndustry)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdExport)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cboDiscontinuedFl)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cboSoldFl)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdPrint)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtCount)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdClose)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdSearch)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cboUsedFl)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtCompSource)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label34)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label33)
        Me.SplitContainer1.Panel1.Controls.Add(Me.listModel)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label31)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label30)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label29)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label27)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label26)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label24)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtDescription)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtManufactureYear)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtSalePriceTo)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtManufacturer)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label21)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label19)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label14)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtSaleYearFrom)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtSaleYearTo)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtSalePriceFrom)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtSerialNumber)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtMachineHoursTo)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtMachineHoursFrom)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtAssetType)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label12)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label11)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label10)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label9)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label8)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.gridResults)
        Me.SplitContainer1.Panel2.Margin = New System.Windows.Forms.Padding(3)
        Me.SplitContainer1.Panel2.Padding = New System.Windows.Forms.Padding(3)
        Me.SplitContainer1.Size = New System.Drawing.Size(1157, 547)
        Me.SplitContainer1.SplitterDistance = 299
        Me.SplitContainer1.TabIndex = 73
        '
        'cmdDelete
        '
        Me.cmdDelete.Location = New System.Drawing.Point(656, 268)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(75, 23)
        Me.cmdDelete.TabIndex = 21
        Me.cmdDelete.Text = "Delete"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cboAssetCategory
        '
        Me.cboAssetCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAssetCategory.FormattingEnabled = True
        Me.cboAssetCategory.Location = New System.Drawing.Point(160, 32)
        Me.cboAssetCategory.Name = "cboAssetCategory"
        Me.cboAssetCategory.Size = New System.Drawing.Size(240, 21)
        Me.cboAssetCategory.TabIndex = 1
        '
        'cboIndustry
        '
        Me.cboIndustry.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboIndustry.FormattingEnabled = True
        Me.cboIndustry.Location = New System.Drawing.Point(160, 8)
        Me.cboIndustry.Name = "cboIndustry"
        Me.cboIndustry.Size = New System.Drawing.Size(240, 21)
        Me.cboIndustry.TabIndex = 0
        '
        'cmdExport
        '
        Me.cmdExport.Location = New System.Drawing.Point(576, 268)
        Me.cmdExport.Name = "cmdExport"
        Me.cmdExport.Size = New System.Drawing.Size(75, 23)
        Me.cmdExport.TabIndex = 20
        Me.cmdExport.Text = "Export"
        Me.cmdExport.UseVisualStyleBackColor = True
        '
        'cboDiscontinuedFl
        '
        Me.cboDiscontinuedFl.FormattingEnabled = True
        Me.cboDiscontinuedFl.Items.AddRange(New Object() {"", "Yes", "No"})
        Me.cboDiscontinuedFl.Location = New System.Drawing.Point(548, 212)
        Me.cboDiscontinuedFl.Name = "cboDiscontinuedFl"
        Me.cboDiscontinuedFl.Size = New System.Drawing.Size(64, 21)
        Me.cboDiscontinuedFl.TabIndex = 16
        '
        'cboSoldFl
        '
        Me.cboSoldFl.FormattingEnabled = True
        Me.cboSoldFl.Items.AddRange(New Object() {"", "For sale", "Sold"})
        Me.cboSoldFl.Location = New System.Drawing.Point(548, 184)
        Me.cboSoldFl.Name = "cboSoldFl"
        Me.cboSoldFl.Size = New System.Drawing.Size(64, 21)
        Me.cboSoldFl.TabIndex = 15
        '
        'cmdPrint
        '
        Me.cmdPrint.Enabled = False
        Me.cmdPrint.Location = New System.Drawing.Point(496, 268)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(75, 23)
        Me.cmdPrint.TabIndex = 19
        Me.cmdPrint.Text = "Print"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'txtCount
        '
        Me.txtCount.BackColor = System.Drawing.SystemColors.Menu
        Me.txtCount.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCount.Location = New System.Drawing.Point(7, 272)
        Me.txtCount.Name = "txtCount"
        Me.txtCount.ReadOnly = True
        Me.txtCount.Size = New System.Drawing.Size(396, 13)
        Me.txtCount.TabIndex = 144
        Me.txtCount.TabStop = False
        '
        'cmdClose
        '
        Me.cmdClose.Location = New System.Drawing.Point(736, 268)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(75, 23)
        Me.cmdClose.TabIndex = 22
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'cmdSearch
        '
        Me.cmdSearch.Location = New System.Drawing.Point(416, 268)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(75, 23)
        Me.cmdSearch.TabIndex = 18
        Me.cmdSearch.Text = "Search"
        Me.cmdSearch.UseVisualStyleBackColor = True
        '
        'cboUsedFl
        '
        Me.cboUsedFl.FormattingEnabled = True
        Me.cboUsedFl.Items.AddRange(New Object() {"", "New", "Used"})
        Me.cboUsedFl.Location = New System.Drawing.Point(548, 156)
        Me.cboUsedFl.Name = "cboUsedFl"
        Me.cboUsedFl.Size = New System.Drawing.Size(64, 21)
        Me.cboUsedFl.TabIndex = 14
        '
        'txtCompSource
        '
        Me.txtCompSource.Location = New System.Drawing.Point(548, 240)
        Me.txtCompSource.Name = "txtCompSource"
        Me.txtCompSource.Size = New System.Drawing.Size(240, 20)
        Me.txtCompSource.TabIndex = 17
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(416, 112)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(70, 13)
        Me.Label34.TabIndex = 136
        Me.Label34.Text = "Manufacturer"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(416, 216)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(69, 13)
        Me.Label33.TabIndex = 135
        Me.Label33.Text = "Discontinued"
        '
        'listModel
        '
        Me.listModel.ContextMenuStrip = Me.contextMenu
        Me.listModel.FormattingEnabled = True
        Me.listModel.Location = New System.Drawing.Point(548, 8)
        Me.listModel.Name = "listModel"
        Me.listModel.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.listModel.Size = New System.Drawing.Size(240, 69)
        Me.listModel.TabIndex = 10
        '
        'contextMenu
        '
        Me.contextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuClearSelected})
        Me.contextMenu.Name = "menuClearAll"
        Me.contextMenu.Size = New System.Drawing.Size(148, 26)
        Me.contextMenu.Text = "Clear selected"
        '
        'menuClearSelected
        '
        Me.menuClearSelected.Name = "menuClearSelected"
        Me.menuClearSelected.Size = New System.Drawing.Size(147, 22)
        Me.menuClearSelected.Text = "Clear selected"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(416, 188)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(68, 13)
        Me.Label31.TabIndex = 132
        Me.Label31.Text = "For sale/sold"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(416, 244)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(41, 13)
        Me.Label30.TabIndex = 131
        Me.Label30.Text = "Source"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(8, 156)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(60, 13)
        Me.Label29.TabIndex = 130
        Me.Label29.Text = "Description"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(416, 12)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(36, 13)
        Me.Label27.TabIndex = 128
        Me.Label27.Text = "Model"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(416, 160)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(57, 13)
        Me.Label26.TabIndex = 126
        Me.Label26.Text = "New/used"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(272, 60)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(16, 13)
        Me.Label24.TabIndex = 124
        Me.Label24.Text = "to"
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(160, 152)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(240, 20)
        Me.txtDescription.TabIndex = 9
        '
        'txtManufactureYear
        '
        Me.txtManufactureYear.Location = New System.Drawing.Point(548, 132)
        Me.txtManufactureYear.Name = "txtManufactureYear"
        Me.txtManufactureYear.Size = New System.Drawing.Size(44, 20)
        Me.txtManufactureYear.TabIndex = 13
        '
        'txtSalePriceTo
        '
        Me.txtSalePriceTo.Location = New System.Drawing.Point(300, 80)
        Me.txtSalePriceTo.Name = "txtSalePriceTo"
        Me.txtSalePriceTo.Size = New System.Drawing.Size(100, 20)
        Me.txtSalePriceTo.TabIndex = 5
        Me.txtSalePriceTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtManufacturer
        '
        Me.txtManufacturer.Location = New System.Drawing.Point(548, 108)
        Me.txtManufacturer.Name = "txtManufacturer"
        Me.txtManufacturer.Size = New System.Drawing.Size(240, 20)
        Me.txtManufacturer.TabIndex = 12
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(272, 84)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(16, 13)
        Me.Label21.TabIndex = 112
        Me.Label21.Text = "to"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(272, 132)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(16, 13)
        Me.Label19.TabIndex = 110
        Me.Label19.Text = "to"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(416, 136)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(103, 13)
        Me.Label14.TabIndex = 105
        Me.Label14.Text = "Year of manufacture"
        '
        'txtSaleYearFrom
        '
        Me.txtSaleYearFrom.Location = New System.Drawing.Point(160, 56)
        Me.txtSaleYearFrom.Name = "txtSaleYearFrom"
        Me.txtSaleYearFrom.Size = New System.Drawing.Size(100, 20)
        Me.txtSaleYearFrom.TabIndex = 2
        Me.txtSaleYearFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSaleYearTo
        '
        Me.txtSaleYearTo.Location = New System.Drawing.Point(300, 56)
        Me.txtSaleYearTo.Name = "txtSaleYearTo"
        Me.txtSaleYearTo.Size = New System.Drawing.Size(100, 20)
        Me.txtSaleYearTo.TabIndex = 3
        Me.txtSaleYearTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSalePriceFrom
        '
        Me.txtSalePriceFrom.Location = New System.Drawing.Point(160, 80)
        Me.txtSalePriceFrom.Name = "txtSalePriceFrom"
        Me.txtSalePriceFrom.Size = New System.Drawing.Size(100, 20)
        Me.txtSalePriceFrom.TabIndex = 4
        Me.txtSalePriceFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSerialNumber
        '
        Me.txtSerialNumber.Location = New System.Drawing.Point(160, 104)
        Me.txtSerialNumber.Name = "txtSerialNumber"
        Me.txtSerialNumber.Size = New System.Drawing.Size(240, 20)
        Me.txtSerialNumber.TabIndex = 6
        '
        'txtMachineHoursTo
        '
        Me.txtMachineHoursTo.Location = New System.Drawing.Point(300, 128)
        Me.txtMachineHoursTo.Name = "txtMachineHoursTo"
        Me.txtMachineHoursTo.Size = New System.Drawing.Size(100, 20)
        Me.txtMachineHoursTo.TabIndex = 8
        Me.txtMachineHoursTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMachineHoursFrom
        '
        Me.txtMachineHoursFrom.Location = New System.Drawing.Point(160, 128)
        Me.txtMachineHoursFrom.Name = "txtMachineHoursFrom"
        Me.txtMachineHoursFrom.Size = New System.Drawing.Size(100, 20)
        Me.txtMachineHoursFrom.TabIndex = 7
        Me.txtMachineHoursFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAssetType
        '
        Me.txtAssetType.Location = New System.Drawing.Point(548, 84)
        Me.txtAssetType.Name = "txtAssetType"
        Me.txtAssetType.Size = New System.Drawing.Size(240, 20)
        Me.txtAssetType.TabIndex = 11
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(8, 60)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(51, 13)
        Me.Label12.TabIndex = 85
        Me.Label12.Text = "Sale year"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(8, 84)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(54, 13)
        Me.Label11.TabIndex = 84
        Me.Label11.Text = "Sale price"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(8, 108)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(94, 13)
        Me.Label10.TabIndex = 83
        Me.Label10.Text = "Serial number/VIN"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(8, 132)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(114, 13)
        Me.Label9.TabIndex = 82
        Me.Label9.Text = "Engine/machine hours"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(416, 88)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 13)
        Me.Label8.TabIndex = 81
        Me.Label8.Text = "Asset type"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 13)
        Me.Label2.TabIndex = 75
        Me.Label2.Text = "Asset Category"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 74
        Me.Label1.Text = "Industry"
        '
        'gridResults
        '
        Me.gridResults.AllowUserToAddRows = False
        Me.gridResults.AllowUserToDeleteRows = False
        Me.gridResults.AllowUserToOrderColumns = True
        Me.gridResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridResults.ContextMenuStrip = Me.contextMenuGrid
        Me.gridResults.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridResults.Location = New System.Drawing.Point(3, 3)
        Me.gridResults.Margin = New System.Windows.Forms.Padding(0)
        Me.gridResults.Name = "gridResults"
        Me.gridResults.ReadOnly = True
        Me.gridResults.RowHeadersVisible = False
        Me.gridResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridResults.ShowCellErrors = False
        Me.gridResults.ShowCellToolTips = False
        Me.gridResults.ShowEditingIcon = False
        Me.gridResults.ShowRowErrors = False
        Me.gridResults.Size = New System.Drawing.Size(1151, 238)
        Me.gridResults.TabIndex = 23
        '
        'contextMenuGrid
        '
        Me.contextMenuGrid.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuRemoveRow})
        Me.contextMenuGrid.Name = "menuClearAll"
        Me.contextMenuGrid.Size = New System.Drawing.Size(192, 26)
        Me.contextMenuGrid.Text = "Clear selected"
        '
        'menuRemoveRow
        '
        Me.menuRemoveRow.Name = "menuRemoveRow"
        Me.menuRemoveRow.Size = New System.Drawing.Size(191, 22)
        Me.menuRemoveRow.Text = "Remove selected rows"
        '
        'frmBPPComps
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1157, 547)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmBPPComps"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BPP Comparisons"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.contextMenu.ResumeLayout(False)
        CType(Me.gridResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.contextMenuGrid.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents gridResults As System.Windows.Forms.DataGridView
    Friend WithEvents cboUsedFl As System.Windows.Forms.ComboBox
    Friend WithEvents txtCompSource As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents listModel As System.Windows.Forms.ListBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtManufactureYear As System.Windows.Forms.TextBox
    Friend WithEvents txtSalePriceTo As System.Windows.Forms.TextBox
    Friend WithEvents txtManufacturer As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtSaleYearFrom As System.Windows.Forms.TextBox
    Friend WithEvents txtSaleYearTo As System.Windows.Forms.TextBox
    Friend WithEvents txtSalePriceFrom As System.Windows.Forms.TextBox
    Friend WithEvents txtSerialNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtMachineHoursTo As System.Windows.Forms.TextBox
    Friend WithEvents txtMachineHoursFrom As System.Windows.Forms.TextBox
    Friend WithEvents txtAssetType As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdSearch As System.Windows.Forms.Button
    Friend WithEvents txtCount As System.Windows.Forms.TextBox
    Friend WithEvents contextMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents menuClearSelected As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cboSoldFl As System.Windows.Forms.ComboBox
    Friend WithEvents cboDiscontinuedFl As System.Windows.Forms.ComboBox
    Friend WithEvents contextMenuGrid As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents menuRemoveRow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdExport As System.Windows.Forms.Button
    Friend WithEvents cboAssetCategory As System.Windows.Forms.ComboBox
    Friend WithEvents cboIndustry As System.Windows.Forms.ComboBox
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
End Class
