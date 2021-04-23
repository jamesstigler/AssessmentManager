<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportClients
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
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.dgImport = New System.Windows.Forms.DataGridView
        Me.cboName = New System.Windows.Forms.ComboBox
        Me.cboAddress = New System.Windows.Forms.ComboBox
        Me.cboCity = New System.Windows.Forms.ComboBox
        Me.cboStateCd = New System.Windows.Forms.ComboBox
        Me.cboPhone = New System.Windows.Forms.ComboBox
        Me.cboFax = New System.Windows.Forms.ComboBox
        Me.cboComment = New System.Windows.Forms.ComboBox
        Me.cboZip = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.cmdFinish = New System.Windows.Forms.Button
        Me.cmdNext = New System.Windows.Forms.Button
        CType(Me.dgImport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(262, 452)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 3
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'dgImport
        '
        Me.dgImport.AllowUserToAddRows = False
        Me.dgImport.AllowUserToDeleteRows = False
        Me.dgImport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgImport.Location = New System.Drawing.Point(3, 134)
        Me.dgImport.Name = "dgImport"
        Me.dgImport.ReadOnly = True
        Me.dgImport.Size = New System.Drawing.Size(431, 292)
        Me.dgImport.TabIndex = 4
        '
        'cboName
        '
        Me.cboName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboName.FormattingEnabled = True
        Me.cboName.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboName.Location = New System.Drawing.Point(61, 12)
        Me.cboName.Name = "cboName"
        Me.cboName.Size = New System.Drawing.Size(60, 21)
        Me.cboName.TabIndex = 5
        '
        'cboAddress
        '
        Me.cboAddress.FormattingEnabled = True
        Me.cboAddress.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboAddress.Location = New System.Drawing.Point(61, 39)
        Me.cboAddress.Name = "cboAddress"
        Me.cboAddress.Size = New System.Drawing.Size(60, 21)
        Me.cboAddress.TabIndex = 6
        '
        'cboCity
        '
        Me.cboCity.FormattingEnabled = True
        Me.cboCity.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboCity.Location = New System.Drawing.Point(61, 66)
        Me.cboCity.Name = "cboCity"
        Me.cboCity.Size = New System.Drawing.Size(60, 21)
        Me.cboCity.TabIndex = 7
        '
        'cboStateCd
        '
        Me.cboStateCd.FormattingEnabled = True
        Me.cboStateCd.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboStateCd.Location = New System.Drawing.Point(61, 93)
        Me.cboStateCd.Name = "cboStateCd"
        Me.cboStateCd.Size = New System.Drawing.Size(60, 21)
        Me.cboStateCd.TabIndex = 8
        '
        'cboPhone
        '
        Me.cboPhone.FormattingEnabled = True
        Me.cboPhone.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboPhone.Location = New System.Drawing.Point(199, 39)
        Me.cboPhone.Name = "cboPhone"
        Me.cboPhone.Size = New System.Drawing.Size(60, 21)
        Me.cboPhone.TabIndex = 10
        '
        'cboFax
        '
        Me.cboFax.FormattingEnabled = True
        Me.cboFax.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboFax.Location = New System.Drawing.Point(199, 66)
        Me.cboFax.Name = "cboFax"
        Me.cboFax.Size = New System.Drawing.Size(60, 21)
        Me.cboFax.TabIndex = 11
        '
        'cboComment
        '
        Me.cboComment.FormattingEnabled = True
        Me.cboComment.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboComment.Location = New System.Drawing.Point(199, 93)
        Me.cboComment.Name = "cboComment"
        Me.cboComment.Size = New System.Drawing.Size(60, 21)
        Me.cboComment.TabIndex = 12
        '
        'cboZip
        '
        Me.cboZip.FormattingEnabled = True
        Me.cboZip.Items.AddRange(New Object() {" ", "1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cboZip.Location = New System.Drawing.Point(199, 12)
        Me.cboZip.Name = "cboZip"
        Me.cboZip.Size = New System.Drawing.Size(60, 21)
        Me.cboZip.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Name"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Address"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(31, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "City"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(23, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "State"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(171, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(22, 13)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Zip"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(155, 42)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Phone"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(168, 69)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(24, 13)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "Fax"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(142, 96)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 13)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Comment"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cmdFinish
        '
        Me.cmdFinish.Enabled = False
        Me.cmdFinish.Location = New System.Drawing.Point(181, 452)
        Me.cmdFinish.Name = "cmdFinish"
        Me.cmdFinish.Size = New System.Drawing.Size(75, 23)
        Me.cmdFinish.TabIndex = 21
        Me.cmdFinish.Text = "Finish"
        Me.cmdFinish.UseVisualStyleBackColor = True
        '
        'cmdNext
        '
        Me.cmdNext.Enabled = False
        Me.cmdNext.Location = New System.Drawing.Point(100, 452)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(75, 23)
        Me.cmdNext.TabIndex = 22
        Me.cmdNext.Text = "Next"
        Me.cmdNext.UseVisualStyleBackColor = True
        '
        'frmImportClients
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(437, 477)
        Me.Controls.Add(Me.cmdNext)
        Me.Controls.Add(Me.cmdFinish)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboComment)
        Me.Controls.Add(Me.cboFax)
        Me.Controls.Add(Me.cboPhone)
        Me.Controls.Add(Me.cboZip)
        Me.Controls.Add(Me.cboStateCd)
        Me.Controls.Add(Me.cboCity)
        Me.Controls.Add(Me.cboAddress)
        Me.Controls.Add(Me.cboName)
        Me.Controls.Add(Me.dgImport)
        Me.Controls.Add(Me.cmdCancel)
        Me.Name = "frmImportClients"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Import Clients"
        Me.TopMost = True
        CType(Me.dgImport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents dgImport As System.Windows.Forms.DataGridView
    Friend WithEvents cboName As System.Windows.Forms.ComboBox
    Friend WithEvents cboAddress As System.Windows.Forms.ComboBox
    Friend WithEvents cboCity As System.Windows.Forms.ComboBox
    Friend WithEvents cboStateCd As System.Windows.Forms.ComboBox
    Friend WithEvents cboPhone As System.Windows.Forms.ComboBox
    Friend WithEvents cboFax As System.Windows.Forms.ComboBox
    Friend WithEvents cboComment As System.Windows.Forms.ComboBox
    Friend WithEvents cboZip As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmdFinish As System.Windows.Forms.Button
    Friend WithEvents cmdNext As System.Windows.Forms.Button
End Class
