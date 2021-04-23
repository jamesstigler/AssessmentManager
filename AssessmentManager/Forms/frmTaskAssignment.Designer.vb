<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTaskAssignment
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
        Me.cmdOK = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cboRELocations = New System.Windows.Forms.ComboBox
        Me.cboClients = New System.Windows.Forms.ComboBox
        Me.cboBPPLocations = New System.Windows.Forms.ComboBox
        Me.cboCollectors = New System.Windows.Forms.ComboBox
        Me.cboJurisdictions = New System.Windows.Forms.ComboBox
        Me.cboAssessments = New System.Windows.Forms.ComboBox
        Me.cboAssessors = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboStateCd = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.radioRELocations = New System.Windows.Forms.RadioButton
        Me.radioBPPLocations = New System.Windows.Forms.RadioButton
        Me.chkAssessors = New System.Windows.Forms.CheckBox
        Me.chkAllJurisdictions = New System.Windows.Forms.CheckBox
        Me.chkCollectors = New System.Windows.Forms.CheckBox
        Me.chkClients = New System.Windows.Forms.CheckBox
        Me.chkStates = New System.Windows.Forms.CheckBox
        Me.radioAllLocations = New System.Windows.Forms.RadioButton
        Me.chkAssessments = New System.Windows.Forms.CheckBox
        Me.cboTask = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.cmdClose = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(271, 342)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(82, 23)
        Me.cmdOK.TabIndex = 19
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.cboRELocations)
        Me.GroupBox1.Controls.Add(Me.cboClients)
        Me.GroupBox1.Controls.Add(Me.cboBPPLocations)
        Me.GroupBox1.Controls.Add(Me.cboCollectors)
        Me.GroupBox1.Controls.Add(Me.cboJurisdictions)
        Me.GroupBox1.Controls.Add(Me.cboAssessments)
        Me.GroupBox1.Controls.Add(Me.cboAssessors)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cboStateCd)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(445, 259)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Assignment Entity"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(7, 71)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 13)
        Me.Label8.TabIndex = 129
        Me.Label8.Text = "RE Locations"
        '
        'cboRELocations
        '
        Me.cboRELocations.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboRELocations.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboRELocations.FormattingEnabled = True
        Me.cboRELocations.Location = New System.Drawing.Point(88, 68)
        Me.cboRELocations.Name = "cboRELocations"
        Me.cboRELocations.Size = New System.Drawing.Size(351, 21)
        Me.cboRELocations.TabIndex = 3
        Me.cboRELocations.Tag = ""
        '
        'cboClients
        '
        Me.cboClients.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboClients.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboClients.FormattingEnabled = True
        Me.cboClients.Location = New System.Drawing.Point(88, 19)
        Me.cboClients.Name = "cboClients"
        Me.cboClients.Size = New System.Drawing.Size(351, 21)
        Me.cboClients.TabIndex = 1
        Me.cboClients.Tag = ""
        '
        'cboBPPLocations
        '
        Me.cboBPPLocations.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBPPLocations.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBPPLocations.FormattingEnabled = True
        Me.cboBPPLocations.Location = New System.Drawing.Point(88, 43)
        Me.cboBPPLocations.Name = "cboBPPLocations"
        Me.cboBPPLocations.Size = New System.Drawing.Size(351, 21)
        Me.cboBPPLocations.TabIndex = 2
        Me.cboBPPLocations.Tag = ""
        '
        'cboCollectors
        '
        Me.cboCollectors.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCollectors.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCollectors.FormattingEnabled = True
        Me.cboCollectors.Location = New System.Drawing.Point(88, 206)
        Me.cboCollectors.Name = "cboCollectors"
        Me.cboCollectors.Size = New System.Drawing.Size(351, 21)
        Me.cboCollectors.TabIndex = 7
        Me.cboCollectors.Tag = ""
        '
        'cboJurisdictions
        '
        Me.cboJurisdictions.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboJurisdictions.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboJurisdictions.FormattingEnabled = True
        Me.cboJurisdictions.Location = New System.Drawing.Point(88, 183)
        Me.cboJurisdictions.Name = "cboJurisdictions"
        Me.cboJurisdictions.Size = New System.Drawing.Size(351, 21)
        Me.cboJurisdictions.TabIndex = 6
        Me.cboJurisdictions.Tag = ""
        '
        'cboAssessments
        '
        Me.cboAssessments.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAssessments.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAssessments.FormattingEnabled = True
        Me.cboAssessments.Location = New System.Drawing.Point(88, 111)
        Me.cboAssessments.Name = "cboAssessments"
        Me.cboAssessments.Size = New System.Drawing.Size(351, 21)
        Me.cboAssessments.TabIndex = 4
        Me.cboAssessments.Tag = ""
        '
        'cboAssessors
        '
        Me.cboAssessors.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAssessors.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAssessors.FormattingEnabled = True
        Me.cboAssessors.Location = New System.Drawing.Point(88, 160)
        Me.cboAssessors.Name = "cboAssessors"
        Me.cboAssessors.Size = New System.Drawing.Size(351, 21)
        Me.cboAssessors.TabIndex = 5
        Me.cboAssessors.Tag = ""
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 46)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 13)
        Me.Label7.TabIndex = 126
        Me.Label7.Text = "BPP Locations"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 114)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 13)
        Me.Label6.TabIndex = 125
        Me.Label6.Text = "Assessments"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 163)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 13)
        Me.Label5.TabIndex = 127
        Me.Label5.Text = "Assessors"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 186)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 124
        Me.Label3.Text = "Jurisdictions"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 209)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 122
        Me.Label2.Text = "Collectors"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 232)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 128
        Me.Label1.Text = "States"
        '
        'cboStateCd
        '
        Me.cboStateCd.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboStateCd.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboStateCd.FormattingEnabled = True
        Me.cboStateCd.Location = New System.Drawing.Point(88, 229)
        Me.cboStateCd.Name = "cboStateCd"
        Me.cboStateCd.Size = New System.Drawing.Size(59, 21)
        Me.cboStateCd.TabIndex = 8
        Me.cboStateCd.Tag = ""
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 123
        Me.Label4.Text = "Clients"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.radioRELocations)
        Me.GroupBox2.Controls.Add(Me.radioBPPLocations)
        Me.GroupBox2.Controls.Add(Me.chkAssessors)
        Me.GroupBox2.Controls.Add(Me.chkAllJurisdictions)
        Me.GroupBox2.Controls.Add(Me.chkCollectors)
        Me.GroupBox2.Controls.Add(Me.chkClients)
        Me.GroupBox2.Controls.Add(Me.chkStates)
        Me.GroupBox2.Controls.Add(Me.radioAllLocations)
        Me.GroupBox2.Controls.Add(Me.chkAssessments)
        Me.GroupBox2.Location = New System.Drawing.Point(478, 41)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(137, 259)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Assignment Level"
        '
        'radioRELocations
        '
        Me.radioRELocations.AutoSize = True
        Me.radioRELocations.Location = New System.Drawing.Point(6, 69)
        Me.radioRELocations.Name = "radioRELocations"
        Me.radioRELocations.Size = New System.Drawing.Size(85, 17)
        Me.radioRELocations.TabIndex = 12
        Me.radioRELocations.TabStop = True
        Me.radioRELocations.Text = "RE locations"
        Me.radioRELocations.UseVisualStyleBackColor = True
        '
        'radioBPPLocations
        '
        Me.radioBPPLocations.AutoSize = True
        Me.radioBPPLocations.Location = New System.Drawing.Point(6, 44)
        Me.radioBPPLocations.Name = "radioBPPLocations"
        Me.radioBPPLocations.Size = New System.Drawing.Size(91, 17)
        Me.radioBPPLocations.TabIndex = 11
        Me.radioBPPLocations.TabStop = True
        Me.radioBPPLocations.Text = "BPP locations"
        Me.radioBPPLocations.UseVisualStyleBackColor = True
        '
        'chkAssessors
        '
        Me.chkAssessors.AutoSize = True
        Me.chkAssessors.Location = New System.Drawing.Point(6, 162)
        Me.chkAssessors.Name = "chkAssessors"
        Me.chkAssessors.Size = New System.Drawing.Size(86, 17)
        Me.chkAssessors.TabIndex = 15
        Me.chkAssessors.Tag = ""
        Me.chkAssessors.Text = "All assessors"
        Me.chkAssessors.UseVisualStyleBackColor = True
        '
        'chkAllJurisdictions
        '
        Me.chkAllJurisdictions.AutoSize = True
        Me.chkAllJurisdictions.Location = New System.Drawing.Point(6, 185)
        Me.chkAllJurisdictions.Name = "chkAllJurisdictions"
        Me.chkAllJurisdictions.Size = New System.Drawing.Size(94, 17)
        Me.chkAllJurisdictions.TabIndex = 16
        Me.chkAllJurisdictions.Tag = ""
        Me.chkAllJurisdictions.Text = "All jurisdictions"
        Me.chkAllJurisdictions.UseVisualStyleBackColor = True
        '
        'chkCollectors
        '
        Me.chkCollectors.AutoSize = True
        Me.chkCollectors.Location = New System.Drawing.Point(6, 208)
        Me.chkCollectors.Name = "chkCollectors"
        Me.chkCollectors.Size = New System.Drawing.Size(85, 17)
        Me.chkCollectors.TabIndex = 17
        Me.chkCollectors.Tag = ""
        Me.chkCollectors.Text = "All collectors"
        Me.chkCollectors.UseVisualStyleBackColor = True
        '
        'chkClients
        '
        Me.chkClients.AutoSize = True
        Me.chkClients.Location = New System.Drawing.Point(6, 23)
        Me.chkClients.Name = "chkClients"
        Me.chkClients.Size = New System.Drawing.Size(70, 17)
        Me.chkClients.TabIndex = 10
        Me.chkClients.Tag = ""
        Me.chkClients.Text = "All clients"
        Me.chkClients.UseVisualStyleBackColor = True
        '
        'chkStates
        '
        Me.chkStates.AutoSize = True
        Me.chkStates.Location = New System.Drawing.Point(6, 231)
        Me.chkStates.Name = "chkStates"
        Me.chkStates.Size = New System.Drawing.Size(68, 17)
        Me.chkStates.TabIndex = 18
        Me.chkStates.Tag = ""
        Me.chkStates.Text = "All states"
        Me.chkStates.UseVisualStyleBackColor = True
        '
        'radioAllLocations
        '
        Me.radioAllLocations.AutoSize = True
        Me.radioAllLocations.Location = New System.Drawing.Point(6, 90)
        Me.radioAllLocations.Name = "radioAllLocations"
        Me.radioAllLocations.Size = New System.Drawing.Size(81, 17)
        Me.radioAllLocations.TabIndex = 13
        Me.radioAllLocations.TabStop = True
        Me.radioAllLocations.Text = "All locations"
        Me.radioAllLocations.UseVisualStyleBackColor = True
        '
        'chkAssessments
        '
        Me.chkAssessments.AutoSize = True
        Me.chkAssessments.Location = New System.Drawing.Point(6, 113)
        Me.chkAssessments.Name = "chkAssessments"
        Me.chkAssessments.Size = New System.Drawing.Size(100, 17)
        Me.chkAssessments.TabIndex = 14
        Me.chkAssessments.Tag = ""
        Me.chkAssessments.Text = "All assessments"
        Me.chkAssessments.UseVisualStyleBackColor = True
        '
        'cboTask
        '
        Me.cboTask.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboTask.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboTask.FormattingEnabled = True
        Me.cboTask.Location = New System.Drawing.Point(100, 12)
        Me.cboTask.Name = "cboTask"
        Me.cboTask.Size = New System.Drawing.Size(351, 21)
        Me.cboTask.TabIndex = 0
        Me.cboTask.Tag = ""
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 15)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(31, 13)
        Me.Label9.TabIndex = 124
        Me.Label9.Text = "Task"
        '
        'cmdClose
        '
        Me.cmdClose.Location = New System.Drawing.Point(359, 342)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(75, 23)
        Me.cmdClose.TabIndex = 125
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'frmTaskAssignment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(627, 380)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cboTask)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdOK)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTaskAssignment"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Task Assignment"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents radioRELocations As System.Windows.Forms.RadioButton
    Friend WithEvents radioBPPLocations As System.Windows.Forms.RadioButton
    Friend WithEvents chkAssessors As System.Windows.Forms.CheckBox
    Friend WithEvents chkAllJurisdictions As System.Windows.Forms.CheckBox
    Friend WithEvents chkCollectors As System.Windows.Forms.CheckBox
    Friend WithEvents chkClients As System.Windows.Forms.CheckBox
    Friend WithEvents chkStates As System.Windows.Forms.CheckBox
    Friend WithEvents radioAllLocations As System.Windows.Forms.RadioButton
    Friend WithEvents chkAssessments As System.Windows.Forms.CheckBox
    Friend WithEvents cboClients As System.Windows.Forms.ComboBox
    Friend WithEvents cboBPPLocations As System.Windows.Forms.ComboBox
    Friend WithEvents cboCollectors As System.Windows.Forms.ComboBox
    Friend WithEvents cboJurisdictions As System.Windows.Forms.ComboBox
    Friend WithEvents cboAssessments As System.Windows.Forms.ComboBox
    Friend WithEvents cboAssessors As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboStateCd As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboRELocations As System.Windows.Forms.ComboBox
    Friend WithEvents cboTask As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmdClose As System.Windows.Forms.Button
End Class
