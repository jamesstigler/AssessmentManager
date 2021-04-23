<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQueryProperties
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
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Field1")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Table1", New System.Windows.Forms.TreeNode() {TreeNode1})
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmQueryProperties))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabpageFields = New System.Windows.Forms.TabPage()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.treeFields = New System.Windows.Forms.TreeView()
        Me.cmdDown = New System.Windows.Forms.Button()
        Me.cmdUp = New System.Windows.Forms.Button()
        Me.dgFields = New System.Windows.Forms.DataGridView()
        Me.Fields = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tabpageFilter = New System.Windows.Forms.TabPage()
        Me.SplitContainer4 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer5 = New System.Windows.Forms.SplitContainer()
        Me.dgFilter = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgSort = New System.Windows.Forms.DataGridView()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtQueryName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.chkCurrentConsultantFl = New System.Windows.Forms.CheckBox()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.TabControl1.SuspendLayout()
        Me.tabpageFields.SuspendLayout()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        CType(Me.dgFields, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabpageFilter.SuspendLayout()
        CType(Me.SplitContainer4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer4.Panel1.SuspendLayout()
        Me.SplitContainer4.Panel2.SuspendLayout()
        Me.SplitContainer4.SuspendLayout()
        CType(Me.SplitContainer5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer5.Panel1.SuspendLayout()
        Me.SplitContainer5.Panel2.SuspendLayout()
        Me.SplitContainer5.SuspendLayout()
        CType(Me.dgFilter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.dgSort, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabpageFields)
        Me.TabControl1.Controls.Add(Me.tabpageFilter)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1028, 659)
        Me.TabControl1.TabIndex = 1
        '
        'tabpageFields
        '
        Me.tabpageFields.Controls.Add(Me.SplitContainer3)
        Me.tabpageFields.Location = New System.Drawing.Point(4, 22)
        Me.tabpageFields.Name = "tabpageFields"
        Me.tabpageFields.Padding = New System.Windows.Forms.Padding(3)
        Me.tabpageFields.Size = New System.Drawing.Size(1020, 633)
        Me.tabpageFields.TabIndex = 0
        Me.tabpageFields.Text = "Fields"
        Me.tabpageFields.UseVisualStyleBackColor = True
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer3.Name = "SplitContainer3"
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.treeFields)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.cmdDown)
        Me.SplitContainer3.Panel2.Controls.Add(Me.cmdUp)
        Me.SplitContainer3.Panel2.Controls.Add(Me.dgFields)
        Me.SplitContainer3.Size = New System.Drawing.Size(1014, 627)
        Me.SplitContainer3.SplitterDistance = 338
        Me.SplitContainer3.TabIndex = 4
        '
        'treeFields
        '
        Me.treeFields.Dock = System.Windows.Forms.DockStyle.Fill
        Me.treeFields.Location = New System.Drawing.Point(0, 0)
        Me.treeFields.Name = "treeFields"
        TreeNode1.Name = "Node1"
        TreeNode1.Text = "Field1"
        TreeNode2.Name = "Node0"
        TreeNode2.Text = "Table1"
        Me.treeFields.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode2})
        Me.treeFields.Size = New System.Drawing.Size(338, 627)
        Me.treeFields.TabIndex = 0
        '
        'cmdDown
        '
        Me.cmdDown.Image = Global.AssessmentManager.My.Resources.Resources.ARW08DN
        Me.cmdDown.Location = New System.Drawing.Point(8, 56)
        Me.cmdDown.Name = "cmdDown"
        Me.cmdDown.Size = New System.Drawing.Size(24, 28)
        Me.cmdDown.TabIndex = 3
        Me.cmdDown.UseVisualStyleBackColor = True
        '
        'cmdUp
        '
        Me.cmdUp.Image = CType(resources.GetObject("cmdUp.Image"), System.Drawing.Image)
        Me.cmdUp.Location = New System.Drawing.Point(8, 24)
        Me.cmdUp.Name = "cmdUp"
        Me.cmdUp.Size = New System.Drawing.Size(24, 28)
        Me.cmdUp.TabIndex = 2
        Me.cmdUp.UseVisualStyleBackColor = True
        '
        'dgFields
        '
        Me.dgFields.AllowUserToAddRows = False
        Me.dgFields.AllowUserToResizeColumns = False
        Me.dgFields.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgFields.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Fields})
        Me.dgFields.Dock = System.Windows.Forms.DockStyle.Right
        Me.dgFields.Location = New System.Drawing.Point(36, 0)
        Me.dgFields.Name = "dgFields"
        Me.dgFields.ReadOnly = True
        Me.dgFields.Size = New System.Drawing.Size(636, 627)
        Me.dgFields.TabIndex = 1
        '
        'Fields
        '
        Me.Fields.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Fields.HeaderText = "Fields"
        Me.Fields.Name = "Fields"
        Me.Fields.ReadOnly = True
        '
        'tabpageFilter
        '
        Me.tabpageFilter.Controls.Add(Me.SplitContainer4)
        Me.tabpageFilter.Location = New System.Drawing.Point(4, 22)
        Me.tabpageFilter.Name = "tabpageFilter"
        Me.tabpageFilter.Padding = New System.Windows.Forms.Padding(3)
        Me.tabpageFilter.Size = New System.Drawing.Size(1020, 633)
        Me.tabpageFilter.TabIndex = 1
        Me.tabpageFilter.Text = "Filter"
        Me.tabpageFilter.UseVisualStyleBackColor = True
        '
        'SplitContainer4
        '
        Me.SplitContainer4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer4.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer4.Name = "SplitContainer4"
        Me.SplitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer4.Panel1
        '
        Me.SplitContainer4.Panel1.Controls.Add(Me.SplitContainer5)
        '
        'SplitContainer4.Panel2
        '
        Me.SplitContainer4.Panel2.Controls.Add(Me.dgSort)
        Me.SplitContainer4.Panel2.Controls.Add(Me.Label4)
        Me.SplitContainer4.Size = New System.Drawing.Size(1014, 627)
        Me.SplitContainer4.SplitterDistance = 499
        Me.SplitContainer4.TabIndex = 127
        '
        'SplitContainer5
        '
        Me.SplitContainer5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer5.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer5.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer5.Name = "SplitContainer5"
        Me.SplitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer5.Panel1
        '
        Me.SplitContainer5.Panel1.Controls.Add(Me.dgFilter)
        '
        'SplitContainer5.Panel2
        '
        Me.SplitContainer5.Panel2.Controls.Add(Me.Panel1)
        Me.SplitContainer5.Size = New System.Drawing.Size(1014, 499)
        Me.SplitContainer5.SplitterDistance = 437
        Me.SplitContainer5.TabIndex = 128
        '
        'dgFilter
        '
        Me.dgFilter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgFilter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgFilter.Location = New System.Drawing.Point(0, 0)
        Me.dgFilter.Name = "dgFilter"
        Me.dgFilter.Size = New System.Drawing.Size(1014, 437)
        Me.dgFilter.TabIndex = 2
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1014, 58)
        Me.Panel1.TabIndex = 127
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(0, 24)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(808, 32)
        Me.TextBox1.TabIndex = 123
        Me.TextBox1.Tag = "@DB=UserQuery.QuerySQL"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(0, 4)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 22)
        Me.Label3.TabIndex = 125
        Me.Label3.Text = "AND"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgSort
        '
        Me.dgSort.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgSort.ColumnHeadersVisible = False
        Me.dgSort.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgSort.Location = New System.Drawing.Point(0, 21)
        Me.dgSort.Name = "dgSort"
        Me.dgSort.Size = New System.Drawing.Size(1014, 103)
        Me.dgSort.TabIndex = 124
        '
        'Label4
        '
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(0, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(1014, 18)
        Me.Label4.TabIndex = 126
        Me.Label4.Text = "Sorting"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(4, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 16)
        Me.Label1.TabIndex = 121
        Me.Label1.Text = "Name"
        '
        'txtQueryName
        '
        Me.txtQueryName.Location = New System.Drawing.Point(48, 8)
        Me.txtQueryName.Name = "txtQueryName"
        Me.txtQueryName.Size = New System.Drawing.Size(281, 20)
        Me.txtQueryName.TabIndex = 120
        Me.txtQueryName.Tag = "@DB=UserQuery.QueryName"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(348, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 18)
        Me.Label2.TabIndex = 123
        Me.Label2.Text = "Description"
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(416, 8)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(368, 50)
        Me.txtDescription.TabIndex = 122
        Me.txtDescription.Tag = "@DB=UserQuery.Description"
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(435, 8)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(75, 23)
        Me.cmdOK.TabIndex = 125
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        Me.cmdClose.Location = New System.Drawing.Point(519, 8)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(75, 23)
        Me.cmdClose.TabIndex = 124
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.chkCurrentConsultantFl)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtDescription)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtQueryName)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(1028, 779)
        Me.SplitContainer1.SplitterDistance = 65
        Me.SplitContainer1.TabIndex = 126
        '
        'chkCurrentConsultantFl
        '
        Me.chkCurrentConsultantFl.AutoSize = True
        Me.chkCurrentConsultantFl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCurrentConsultantFl.Location = New System.Drawing.Point(792, 8)
        Me.chkCurrentConsultantFl.Name = "chkCurrentConsultantFl"
        Me.chkCurrentConsultantFl.Size = New System.Drawing.Size(215, 17)
        Me.chkCurrentConsultantFl.TabIndex = 124
        Me.chkCurrentConsultantFl.Tag = "@DB=UserQuery.CurrentConsultantFl"
        Me.chkCurrentConsultantFl.Text = "Limit results to current consultant"
        Me.chkCurrentConsultantFl.UseVisualStyleBackColor = True
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.TabControl1)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.cmdClose)
        Me.SplitContainer2.Panel2.Controls.Add(Me.cmdOK)
        Me.SplitContainer2.Size = New System.Drawing.Size(1028, 710)
        Me.SplitContainer2.SplitterDistance = 659
        Me.SplitContainer2.TabIndex = 0
        '
        'frmQueryProperties
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1028, 779)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmQueryProperties"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Query Properties"
        Me.TabControl1.ResumeLayout(False)
        Me.tabpageFields.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        CType(Me.dgFields, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabpageFilter.ResumeLayout(False)
        Me.SplitContainer4.Panel1.ResumeLayout(False)
        Me.SplitContainer4.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer4.ResumeLayout(False)
        Me.SplitContainer5.Panel1.ResumeLayout(False)
        Me.SplitContainer5.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer5.ResumeLayout(False)
        CType(Me.dgFilter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgSort, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabpageFields As System.Windows.Forms.TabPage
    Friend WithEvents treeFields As System.Windows.Forms.TreeView
    Friend WithEvents tabpageFilter As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtQueryName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents dgFields As System.Windows.Forms.DataGridView
    Friend WithEvents Fields As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents dgFilter As System.Windows.Forms.DataGridView
    Friend WithEvents dgSort As System.Windows.Forms.DataGridView
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdUp As System.Windows.Forms.Button
    Friend WithEvents cmdDown As System.Windows.Forms.Button
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents SplitContainer3 As SplitContainer
    Friend WithEvents SplitContainer4 As SplitContainer
    Friend WithEvents SplitContainer5 As SplitContainer
    Friend WithEvents Panel1 As Panel
    Friend WithEvents chkCurrentConsultantFl As CheckBox
End Class
