<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProspectLocation
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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.txtAcctNum = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtZip = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtCity = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtAddress = New System.Windows.Forms.TextBox
        Me.cboStateCd = New System.Windows.Forms.ComboBox
        Me.dgValues = New System.Windows.Forms.DataGridView
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuContextDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.Label38 = New System.Windows.Forms.Label
        Me.cboPropType = New System.Windows.Forms.ComboBox
        Me.cmdNewValue = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TextBox4 = New System.Windows.Forms.TextBox
        CType(Me.dgValues, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtAcctNum
        '
        Me.txtAcctNum.AllowDrop = True
        Me.txtAcctNum.Location = New System.Drawing.Point(132, 4)
        Me.txtAcctNum.Name = "txtAcctNum"
        Me.txtAcctNum.Size = New System.Drawing.Size(193, 20)
        Me.txtAcctNum.TabIndex = 0
        Me.txtAcctNum.Tag = "@DB=ProspectLocations.AcctNum"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 111
        Me.Label1.Text = "Account number"
        '
        'txtZip
        '
        Me.txtZip.Location = New System.Drawing.Point(476, 64)
        Me.txtZip.Name = "txtZip"
        Me.txtZip.Size = New System.Drawing.Size(76, 20)
        Me.txtZip.TabIndex = 4
        Me.txtZip.Tag = "@DB=ProspectLocations.Zip"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 68)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "City, State  Zip"
        '
        'txtCity
        '
        Me.txtCity.Location = New System.Drawing.Point(132, 64)
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(193, 20)
        Me.txtCity.TabIndex = 2
        Me.txtCity.Tag = "@DB=ProspectLocations.City"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Address"
        '
        'txtAddress
        '
        Me.txtAddress.Location = New System.Drawing.Point(132, 44)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(420, 20)
        Me.txtAddress.TabIndex = 1
        Me.txtAddress.Tag = "@DB=ProspectLocations.Address"
        '
        'cboStateCd
        '
        Me.cboStateCd.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboStateCd.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboStateCd.FormattingEnabled = True
        Me.cboStateCd.Location = New System.Drawing.Point(328, 64)
        Me.cboStateCd.Name = "cboStateCd"
        Me.cboStateCd.Size = New System.Drawing.Size(145, 21)
        Me.cboStateCd.TabIndex = 3
        Me.cboStateCd.Tag = "@DB=ProspectLocations.StateCd"
        '
        'dgValues
        '
        Me.dgValues.AllowDrop = True
        Me.dgValues.AllowUserToAddRows = False
        Me.dgValues.AllowUserToDeleteRows = False
        Me.dgValues.AllowUserToOrderColumns = True
        Me.dgValues.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgValues.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgValues.ContextMenuStrip = Me.ContextMenuStrip1
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgValues.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgValues.Location = New System.Drawing.Point(16, 240)
        Me.dgValues.Margin = New System.Windows.Forms.Padding(0)
        Me.dgValues.Name = "dgValues"
        Me.dgValues.RowHeadersVisible = False
        Me.dgValues.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgValues.ShowCellErrors = False
        Me.dgValues.ShowCellToolTips = False
        Me.dgValues.ShowEditingIcon = False
        Me.dgValues.ShowRowErrors = False
        Me.dgValues.Size = New System.Drawing.Size(383, 174)
        Me.dgValues.TabIndex = 10
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuContextDelete})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(117, 26)
        '
        'mnuContextDelete
        '
        Me.mnuContextDelete.Name = "mnuContextDelete"
        Me.mnuContextDelete.Size = New System.Drawing.Size(116, 22)
        Me.mnuContextDelete.Text = "Delete"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(12, 28)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(73, 13)
        Me.Label38.TabIndex = 211
        Me.Label38.Text = "Property Type"
        '
        'cboPropType
        '
        Me.cboPropType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPropType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPropType.FormattingEnabled = True
        Me.cboPropType.Location = New System.Drawing.Point(132, 24)
        Me.cboPropType.Name = "cboPropType"
        Me.cboPropType.Size = New System.Drawing.Size(80, 21)
        Me.cboPropType.TabIndex = 12
        Me.cboPropType.Tag = "@DB=ProspectLocations.PropType"
        '
        'cmdNewValue
        '
        Me.cmdNewValue.Location = New System.Drawing.Point(16, 216)
        Me.cmdNewValue.Name = "cmdNewValue"
        Me.cmdNewValue.Size = New System.Drawing.Size(75, 23)
        Me.cmdNewValue.TabIndex = 9
        Me.cmdNewValue.Text = "Add Value"
        Me.cmdNewValue.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 188)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 13)
        Me.Label2.TabIndex = 231
        Me.Label2.Text = "Rendition Filing Status"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(132, 184)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(420, 20)
        Me.TextBox1.TabIndex = 8
        Me.TextBox1.Tag = "@DB=ProspectLocations.RenditionFilingStatus"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 168)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(105, 13)
        Me.Label3.TabIndex = 233
        Me.Label3.Text = "Business Description"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(132, 164)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(420, 20)
        Me.TextBox2.TabIndex = 7
        Me.TextBox2.Tag = "@DB=ProspectLocations.BusDesc"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 148)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 13)
        Me.Label6.TabIndex = 235
        Me.Label6.Text = "SIC Code"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(132, 144)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(420, 20)
        Me.TextBox3.TabIndex = 6
        Me.TextBox3.Tag = "@DB=ProspectLocations.SICCode"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 88)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(35, 13)
        Me.Label7.TabIndex = 237
        Me.Label7.Text = "Notes"
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(132, 84)
        Me.TextBox4.Multiline = True
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox4.Size = New System.Drawing.Size(420, 60)
        Me.TextBox4.TabIndex = 5
        Me.TextBox4.Tag = "@DB=ProspectLocations.Notes"
        '
        'frmProspectLocation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(643, 421)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.cmdNewValue)
        Me.Controls.Add(Me.cboPropType)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.dgValues)
        Me.Controls.Add(Me.cboStateCd)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtAcctNum)
        Me.Controls.Add(Me.txtAddress)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtCity)
        Me.Controls.Add(Me.txtZip)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmProspectLocation"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Prospect Location"
        CType(Me.dgValues, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtAcctNum As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtZip As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCity As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents cboStateCd As System.Windows.Forms.ComboBox
    Friend WithEvents dgValues As System.Windows.Forms.DataGridView
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents cboPropType As System.Windows.Forms.ComboBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuContextDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdNewValue As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
End Class
