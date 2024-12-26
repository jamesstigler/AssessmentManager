<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmBPPAssessment
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtAcctNum = New System.Windows.Forms.TextBox()
        Me.cboAssessor = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuContextDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtValueProtestDeadlineDate = New System.Windows.Forms.TextBox()
        Me.txtValueProtestHearingDate = New System.Windows.Forms.TextBox()
        Me.txtValueProtestCMRRR = New System.Windows.Forms.TextBox()
        Me.cboValueProtestStatus = New System.Windows.Forms.ComboBox()
        Me.txtValueProtestMailedDate = New System.Windows.Forms.TextBox()
        Me.txtComment = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtFreeportProtestDeadlineDate = New System.Windows.Forms.TextBox()
        Me.txtFreeportProtestHearingDate = New System.Windows.Forms.TextBox()
        Me.txtFreeportProtestCMRRR = New System.Windows.Forms.TextBox()
        Me.cboFreeportProtestStatus = New System.Windows.Forms.ComboBox()
        Me.txtFreeportProtestMailedDate = New System.Windows.Forms.TextBox()
        Me.chkInactiveFl = New System.Windows.Forms.CheckBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtClientLocationId = New System.Windows.Forms.TextBox()
        Me.txtRenditionExtCMRRR = New System.Windows.Forms.TextBox()
        Me.txtRenditionExtMailedDate = New System.Windows.Forms.TextBox()
        Me.txtRenditionCMRRR = New System.Windows.Forms.TextBox()
        Me.txtRenditionMailedDate = New System.Windows.Forms.TextBox()
        Me.cmdValues = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtConsultantName = New System.Windows.Forms.TextBox()
        Me.cboAccountInvoicedStatus = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtSICCode = New System.Windows.Forms.TextBox()
        Me.cmdOpenAssessor = New System.Windows.Forms.Button()
        Me.grpEvents = New System.Windows.Forms.GroupBox()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.cmdNewEvent = New System.Windows.Forms.Button()
        Me.dgEvents = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.grpEvents.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.dgEvents, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 20)
        Me.Label1.TabIndex = 119
        Me.Label1.Text = "Account Number"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtAcctNum
        '
        Me.txtAcctNum.AllowDrop = True
        Me.txtAcctNum.Location = New System.Drawing.Point(110, 9)
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
        Me.cboAssessor.Location = New System.Drawing.Point(110, 35)
        Me.cboAssessor.Name = "cboAssessor"
        Me.cboAssessor.Size = New System.Drawing.Size(221, 21)
        Me.cboAssessor.TabIndex = 2
        Me.cboAssessor.Tag = "@DB=AssessmentsBPP.AssessorId"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(30, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 21)
        Me.Label2.TabIndex = 128
        Me.Label2.Text = "Assessor"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuContextDelete})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(108, 26)
        '
        'mnuContextDelete
        '
        Me.mnuContextDelete.Name = "mnuContextDelete"
        Me.mnuContextDelete.Size = New System.Drawing.Size(107, 22)
        Me.mnuContextDelete.Text = "Delete"
        '
        'txtValueProtestDeadlineDate
        '
        Me.txtValueProtestDeadlineDate.AllowDrop = True
        Me.txtValueProtestDeadlineDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValueProtestDeadlineDate.Location = New System.Drawing.Point(121, 185)
        Me.txtValueProtestDeadlineDate.Name = "txtValueProtestDeadlineDate"
        Me.txtValueProtestDeadlineDate.Size = New System.Drawing.Size(72, 20)
        Me.txtValueProtestDeadlineDate.TabIndex = 14
        Me.txtValueProtestDeadlineDate.Tag = "@DB=AssessmentsBPP.ValueProtestDeadlineDate;@fmt=date"
        '
        'txtValueProtestHearingDate
        '
        Me.txtValueProtestHearingDate.AllowDrop = True
        Me.txtValueProtestHearingDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValueProtestHearingDate.Location = New System.Drawing.Point(702, 185)
        Me.txtValueProtestHearingDate.Name = "txtValueProtestHearingDate"
        Me.txtValueProtestHearingDate.Size = New System.Drawing.Size(118, 20)
        Me.txtValueProtestHearingDate.TabIndex = 18
        Me.txtValueProtestHearingDate.Tag = "@DB=AssessmentsBPP.ValueProtestHearingDate;@fmt=datetime"
        '
        'txtValueProtestCMRRR
        '
        Me.txtValueProtestCMRRR.AllowDrop = True
        Me.txtValueProtestCMRRR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValueProtestCMRRR.Location = New System.Drawing.Point(277, 185)
        Me.txtValueProtestCMRRR.Name = "txtValueProtestCMRRR"
        Me.txtValueProtestCMRRR.Size = New System.Drawing.Size(192, 20)
        Me.txtValueProtestCMRRR.TabIndex = 16
        Me.txtValueProtestCMRRR.Tag = "@DB=AssessmentsBPP.ValueProtestCMRRR"
        '
        'cboValueProtestStatus
        '
        Me.cboValueProtestStatus.AllowDrop = True
        Me.cboValueProtestStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboValueProtestStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboValueProtestStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboValueProtestStatus.FormattingEnabled = True
        Me.cboValueProtestStatus.Location = New System.Drawing.Point(475, 185)
        Me.cboValueProtestStatus.Name = "cboValueProtestStatus"
        Me.cboValueProtestStatus.Size = New System.Drawing.Size(221, 21)
        Me.cboValueProtestStatus.TabIndex = 17
        Me.cboValueProtestStatus.Tag = "@DB=AssessmentsBPP.ValueProtestStatus"
        '
        'txtValueProtestMailedDate
        '
        Me.txtValueProtestMailedDate.AllowDrop = True
        Me.txtValueProtestMailedDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValueProtestMailedDate.Location = New System.Drawing.Point(199, 185)
        Me.txtValueProtestMailedDate.Name = "txtValueProtestMailedDate"
        Me.txtValueProtestMailedDate.Size = New System.Drawing.Size(72, 20)
        Me.txtValueProtestMailedDate.TabIndex = 15
        Me.txtValueProtestMailedDate.Tag = "@DB=AssessmentsBPP.ValueProtestMailedDate;@fmt=date"
        '
        'txtComment
        '
        Me.txtComment.AllowDrop = True
        Me.txtComment.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComment.Location = New System.Drawing.Point(8, 516)
        Me.txtComment.Multiline = True
        Me.txtComment.Name = "txtComment"
        Me.txtComment.Size = New System.Drawing.Size(429, 70)
        Me.txtComment.TabIndex = 26
        Me.txtComment.Tag = "@DB=AssessmentsBPP.Comment"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(8, 496)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(98, 19)
        Me.Label11.TabIndex = 207
        Me.Label11.Text = "Comments"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFreeportProtestDeadlineDate
        '
        Me.txtFreeportProtestDeadlineDate.AllowDrop = True
        Me.txtFreeportProtestDeadlineDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFreeportProtestDeadlineDate.Location = New System.Drawing.Point(121, 159)
        Me.txtFreeportProtestDeadlineDate.Name = "txtFreeportProtestDeadlineDate"
        Me.txtFreeportProtestDeadlineDate.Size = New System.Drawing.Size(72, 20)
        Me.txtFreeportProtestDeadlineDate.TabIndex = 9
        Me.txtFreeportProtestDeadlineDate.Tag = "@DB=AssessmentsBPP.FreeportProtestDeadlineDate;@fmt=date"
        '
        'txtFreeportProtestHearingDate
        '
        Me.txtFreeportProtestHearingDate.AllowDrop = True
        Me.txtFreeportProtestHearingDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFreeportProtestHearingDate.Location = New System.Drawing.Point(702, 158)
        Me.txtFreeportProtestHearingDate.Name = "txtFreeportProtestHearingDate"
        Me.txtFreeportProtestHearingDate.Size = New System.Drawing.Size(118, 20)
        Me.txtFreeportProtestHearingDate.TabIndex = 13
        Me.txtFreeportProtestHearingDate.Tag = "@DB=AssessmentsBPP.FreeportProtestHearingDate;@fmt=datetime"
        '
        'txtFreeportProtestCMRRR
        '
        Me.txtFreeportProtestCMRRR.AllowDrop = True
        Me.txtFreeportProtestCMRRR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFreeportProtestCMRRR.Location = New System.Drawing.Point(277, 158)
        Me.txtFreeportProtestCMRRR.Name = "txtFreeportProtestCMRRR"
        Me.txtFreeportProtestCMRRR.Size = New System.Drawing.Size(192, 20)
        Me.txtFreeportProtestCMRRR.TabIndex = 11
        Me.txtFreeportProtestCMRRR.Tag = "@DB=AssessmentsBPP.FreeportProtestCMRRR"
        '
        'cboFreeportProtestStatus
        '
        Me.cboFreeportProtestStatus.AllowDrop = True
        Me.cboFreeportProtestStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboFreeportProtestStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboFreeportProtestStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFreeportProtestStatus.FormattingEnabled = True
        Me.cboFreeportProtestStatus.Location = New System.Drawing.Point(475, 158)
        Me.cboFreeportProtestStatus.Name = "cboFreeportProtestStatus"
        Me.cboFreeportProtestStatus.Size = New System.Drawing.Size(221, 21)
        Me.cboFreeportProtestStatus.TabIndex = 12
        Me.cboFreeportProtestStatus.Tag = "@DB=AssessmentsBPP.FreeportProtestStatus"
        '
        'txtFreeportProtestMailedDate
        '
        Me.txtFreeportProtestMailedDate.AllowDrop = True
        Me.txtFreeportProtestMailedDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFreeportProtestMailedDate.Location = New System.Drawing.Point(199, 159)
        Me.txtFreeportProtestMailedDate.Name = "txtFreeportProtestMailedDate"
        Me.txtFreeportProtestMailedDate.Size = New System.Drawing.Size(72, 20)
        Me.txtFreeportProtestMailedDate.TabIndex = 10
        Me.txtFreeportProtestMailedDate.Tag = "@DB=AssessmentsBPP.FreeportProtestMailedDate;@fmt=date"
        '
        'chkInactiveFl
        '
        Me.chkInactiveFl.AutoSize = True
        Me.chkInactiveFl.Location = New System.Drawing.Point(10, 593)
        Me.chkInactiveFl.Name = "chkInactiveFl"
        Me.chkInactiveFl.Size = New System.Drawing.Size(64, 17)
        Me.chkInactiveFl.TabIndex = 27
        Me.chkInactiveFl.Tag = "@DB=AssessmentsBPP.InactiveFl"
        Me.chkInactiveFl.Text = "Inactive"
        Me.chkInactiveFl.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(436, 8)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(62, 20)
        Me.Label21.TabIndex = 221
        Me.Label21.Text = "Client ID"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtClientLocationId
        '
        Me.txtClientLocationId.AllowDrop = True
        Me.txtClientLocationId.Location = New System.Drawing.Point(508, 12)
        Me.txtClientLocationId.Name = "txtClientLocationId"
        Me.txtClientLocationId.Size = New System.Drawing.Size(154, 20)
        Me.txtClientLocationId.TabIndex = 1
        Me.txtClientLocationId.Tag = "@DB=LocationsBPP.ClientLocationId"
        '
        'txtRenditionExtCMRRR
        '
        Me.txtRenditionExtCMRRR.AllowDrop = True
        Me.txtRenditionExtCMRRR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRenditionExtCMRRR.Location = New System.Drawing.Point(277, 106)
        Me.txtRenditionExtCMRRR.Name = "txtRenditionExtCMRRR"
        Me.txtRenditionExtCMRRR.Size = New System.Drawing.Size(192, 20)
        Me.txtRenditionExtCMRRR.TabIndex = 5
        Me.txtRenditionExtCMRRR.Tag = "@DB=AssessmentsBPP.RenditionExtCMRRR"
        '
        'txtRenditionExtMailedDate
        '
        Me.txtRenditionExtMailedDate.AllowDrop = True
        Me.txtRenditionExtMailedDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRenditionExtMailedDate.Location = New System.Drawing.Point(199, 106)
        Me.txtRenditionExtMailedDate.Name = "txtRenditionExtMailedDate"
        Me.txtRenditionExtMailedDate.Size = New System.Drawing.Size(72, 20)
        Me.txtRenditionExtMailedDate.TabIndex = 4
        Me.txtRenditionExtMailedDate.Tag = "@DB=AssessmentsBPP.RenditionExtMailedDate;@fmt=date"
        '
        'txtRenditionCMRRR
        '
        Me.txtRenditionCMRRR.AllowDrop = True
        Me.txtRenditionCMRRR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRenditionCMRRR.Location = New System.Drawing.Point(277, 132)
        Me.txtRenditionCMRRR.Name = "txtRenditionCMRRR"
        Me.txtRenditionCMRRR.Size = New System.Drawing.Size(192, 20)
        Me.txtRenditionCMRRR.TabIndex = 8
        Me.txtRenditionCMRRR.Tag = "@DB=AssessmentsBPP.RenditionCMRRR"
        '
        'txtRenditionMailedDate
        '
        Me.txtRenditionMailedDate.AllowDrop = True
        Me.txtRenditionMailedDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRenditionMailedDate.Location = New System.Drawing.Point(199, 132)
        Me.txtRenditionMailedDate.Name = "txtRenditionMailedDate"
        Me.txtRenditionMailedDate.Size = New System.Drawing.Size(72, 20)
        Me.txtRenditionMailedDate.TabIndex = 7
        Me.txtRenditionMailedDate.Tag = "@DB=AssessmentsBPP.RenditionMailedDate;@fmt=date"
        '
        'cmdValues
        '
        Me.cmdValues.Location = New System.Drawing.Point(376, 608)
        Me.cmdValues.Name = "cmdValues"
        Me.cmdValues.Size = New System.Drawing.Size(99, 23)
        Me.cmdValues.TabIndex = 29
        Me.cmdValues.Text = "Values"
        Me.cmdValues.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(121, 70)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 29)
        Me.Label5.TabIndex = 229
        Me.Label5.Text = "Deadline Date"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(702, 71)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(118, 29)
        Me.Label10.TabIndex = 231
        Me.Label10.Text = "Hearing Date/Time"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(475, 70)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(84, 29)
        Me.Label24.TabIndex = 232
        Me.Label24.Text = "Status"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(274, 70)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(87, 29)
        Me.Label25.TabIndex = 233
        Me.Label25.Text = "CMRRR"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(199, 70)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(72, 30)
        Me.Label26.TabIndex = 234
        Me.Label26.Text = "Mailed Date"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(24, 186)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(86, 17)
        Me.Label27.TabIndex = 236
        Me.Label27.Text = "Value Protest"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label28
        '
        Me.Label28.Location = New System.Drawing.Point(21, 160)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(89, 17)
        Me.Label28.TabIndex = 237
        Me.Label28.Text = "Freeport Protest"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label29
        '
        Me.Label29.Location = New System.Drawing.Point(6, 107)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(104, 17)
        Me.Label29.TabIndex = 238
        Me.Label29.Text = "Rendition Extension"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label30
        '
        Me.Label30.Location = New System.Drawing.Point(3, 133)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(107, 17)
        Me.Label30.TabIndex = 239
        Me.Label30.Text = "Rendition"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBox1
        '
        Me.TextBox1.AllowDrop = True
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(121, 106)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(72, 20)
        Me.TextBox1.TabIndex = 3
        Me.TextBox1.Tag = "@DB=AssessmentsBPP.RenditionExtDeadlineDate;@fmt=date"
        '
        'TextBox2
        '
        Me.TextBox2.AllowDrop = True
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(121, 132)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(72, 20)
        Me.TextBox2.TabIndex = 6
        Me.TextBox2.Tag = "@DB=AssessmentsBPP.RenditionDeadlineDate;@fmt=date"
        '
        'TextBox3
        '
        Me.TextBox3.AllowDrop = True
        Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(702, 211)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(118, 20)
        Me.TextBox3.TabIndex = 24
        Me.TextBox3.Tag = "@DB=AssessmentsBPP.OtherProtest1HearingDate;@fmt=datetime"
        '
        'ComboBox1
        '
        Me.ComboBox1.AllowDrop = True
        Me.ComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(475, 211)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(221, 21)
        Me.ComboBox1.TabIndex = 23
        Me.ComboBox1.Tag = "@DB=AssessmentsBPP.OtherProtest1Status"
        '
        'TextBox4
        '
        Me.TextBox4.AllowDrop = True
        Me.TextBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox4.Location = New System.Drawing.Point(121, 211)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(72, 20)
        Me.TextBox4.TabIndex = 20
        Me.TextBox4.Tag = "@DB=AssessmentsBPP.OtherProtest1DeadlineDate;@fmt=date"
        '
        'TextBox5
        '
        Me.TextBox5.AllowDrop = True
        Me.TextBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox5.Location = New System.Drawing.Point(277, 211)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(192, 20)
        Me.TextBox5.TabIndex = 22
        Me.TextBox5.Tag = "@DB=AssessmentsBPP.OtherProtest1CMRRR"
        '
        'TextBox6
        '
        Me.TextBox6.AllowDrop = True
        Me.TextBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox6.Location = New System.Drawing.Point(199, 211)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(72, 20)
        Me.TextBox6.TabIndex = 21
        Me.TextBox6.Tag = "@DB=AssessmentsBPP.OtherProtest1MailedDate;@fmt=date"
        '
        'TextBox7
        '
        Me.TextBox7.AllowDrop = True
        Me.TextBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox7.Location = New System.Drawing.Point(6, 211)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(109, 20)
        Me.TextBox7.TabIndex = 19
        Me.TextBox7.Tag = "@DB=AssessmentsBPP.OtherProtest1"
        Me.TextBox7.Text = "Other Protest"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(464, 516)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 20)
        Me.Label3.TabIndex = 241
        Me.Label3.Text = "Consultant"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtConsultantName
        '
        Me.txtConsultantName.AllowDrop = True
        Me.txtConsultantName.Enabled = False
        Me.txtConsultantName.Location = New System.Drawing.Point(532, 516)
        Me.txtConsultantName.Name = "txtConsultantName"
        Me.txtConsultantName.Size = New System.Drawing.Size(152, 20)
        Me.txtConsultantName.TabIndex = 28
        Me.txtConsultantName.Tag = ""
        '
        'cboAccountInvoicedStatus
        '
        Me.cboAccountInvoicedStatus.AllowDrop = True
        Me.cboAccountInvoicedStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAccountInvoicedStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAccountInvoicedStatus.FormattingEnabled = True
        Me.cboAccountInvoicedStatus.Location = New System.Drawing.Point(508, 36)
        Me.cboAccountInvoicedStatus.Name = "cboAccountInvoicedStatus"
        Me.cboAccountInvoicedStatus.Size = New System.Drawing.Size(108, 21)
        Me.cboAccountInvoicedStatus.TabIndex = 3
        Me.cboAccountInvoicedStatus.Tag = "@DB=AssessmentsBPP.AccountInvoicedStatus"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(396, 36)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 20)
        Me.Label4.TabIndex = 243
        Me.Label4.Text = "Account Invoiced"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(464, 544)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 20)
        Me.Label6.TabIndex = 245
        Me.Label6.Text = "SIC Code"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSICCode
        '
        Me.txtSICCode.AllowDrop = True
        Me.txtSICCode.Enabled = False
        Me.txtSICCode.Location = New System.Drawing.Point(532, 544)
        Me.txtSICCode.Name = "txtSICCode"
        Me.txtSICCode.Size = New System.Drawing.Size(152, 20)
        Me.txtSICCode.TabIndex = 244
        Me.txtSICCode.Tag = ""
        '
        'cmdOpenAssessor
        '
        Me.cmdOpenAssessor.Location = New System.Drawing.Point(332, 36)
        Me.cmdOpenAssessor.Name = "cmdOpenAssessor"
        Me.cmdOpenAssessor.Size = New System.Drawing.Size(24, 19)
        Me.cmdOpenAssessor.TabIndex = 246
        Me.cmdOpenAssessor.Text = "..."
        Me.cmdOpenAssessor.UseVisualStyleBackColor = True
        '
        'grpEvents
        '
        Me.grpEvents.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.grpEvents.Controls.Add(Me.SplitContainer2)
        Me.grpEvents.Location = New System.Drawing.Point(8, 244)
        Me.grpEvents.Name = "grpEvents"
        Me.grpEvents.Size = New System.Drawing.Size(812, 244)
        Me.grpEvents.TabIndex = 259
        Me.grpEvents.TabStop = False
        Me.grpEvents.Text = "Events"
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
        Me.SplitContainer2.Panel1.Controls.Add(Me.cmdNewEvent)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.dgEvents)
        Me.SplitContainer2.Size = New System.Drawing.Size(806, 225)
        Me.SplitContainer2.SplitterDistance = 25
        Me.SplitContainer2.TabIndex = 233
        '
        'cmdNewEvent
        '
        Me.cmdNewEvent.Location = New System.Drawing.Point(0, 0)
        Me.cmdNewEvent.Name = "cmdNewEvent"
        Me.cmdNewEvent.Size = New System.Drawing.Size(80, 24)
        Me.cmdNewEvent.TabIndex = 231
        Me.cmdNewEvent.Text = "New Event"
        Me.cmdNewEvent.UseVisualStyleBackColor = True
        '
        'dgEvents
        '
        Me.dgEvents.AllowDrop = True
        Me.dgEvents.AllowUserToAddRows = False
        Me.dgEvents.AllowUserToDeleteRows = False
        Me.dgEvents.AllowUserToOrderColumns = True
        Me.dgEvents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgEvents.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgEvents.ContextMenuStrip = Me.ContextMenuStrip1
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgEvents.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgEvents.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgEvents.Location = New System.Drawing.Point(0, 0)
        Me.dgEvents.Margin = New System.Windows.Forms.Padding(0)
        Me.dgEvents.Name = "dgEvents"
        Me.dgEvents.RowHeadersVisible = False
        Me.dgEvents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgEvents.ShowCellErrors = False
        Me.dgEvents.ShowCellToolTips = False
        Me.dgEvents.ShowEditingIcon = False
        Me.dgEvents.ShowRowErrors = False
        Me.dgEvents.Size = New System.Drawing.Size(806, 196)
        Me.dgEvents.TabIndex = 230
        '
        'frmBPPAssessment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(828, 639)
        Me.Controls.Add(Me.grpEvents)
        Me.Controls.Add(Me.cmdOpenAssessor)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtSICCode)
        Me.Controls.Add(Me.cboAccountInvoicedStatus)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtConsultantName)
        Me.Controls.Add(Me.TextBox7)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.TextBox6)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.txtRenditionExtCMRRR)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.txtRenditionCMRRR)
        Me.Controls.Add(Me.txtRenditionExtMailedDate)
        Me.Controls.Add(Me.txtFreeportProtestHearingDate)
        Me.Controls.Add(Me.txtFreeportProtestDeadlineDate)
        Me.Controls.Add(Me.cboFreeportProtestStatus)
        Me.Controls.Add(Me.txtFreeportProtestCMRRR)
        Me.Controls.Add(Me.txtValueProtestHearingDate)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.txtFreeportProtestMailedDate)
        Me.Controls.Add(Me.cboValueProtestStatus)
        Me.Controls.Add(Me.txtValueProtestDeadlineDate)
        Me.Controls.Add(Me.txtValueProtestCMRRR)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.txtRenditionMailedDate)
        Me.Controls.Add(Me.txtValueProtestMailedDate)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.txtClientLocationId)
        Me.Controls.Add(Me.cboAssessor)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.chkInactiveFl)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtComment)
        Me.Controls.Add(Me.cmdValues)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtAcctNum)
        Me.Name = "frmBPPAssessment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BPP Assessment"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.grpEvents.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.dgEvents, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtAcctNum As System.Windows.Forms.TextBox
    Friend WithEvents cboAssessor As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuContextDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtValueProtestDeadlineDate As System.Windows.Forms.TextBox
    Friend WithEvents txtValueProtestHearingDate As System.Windows.Forms.TextBox
    Friend WithEvents txtValueProtestCMRRR As System.Windows.Forms.TextBox
    Friend WithEvents cboValueProtestStatus As System.Windows.Forms.ComboBox
    Friend WithEvents txtValueProtestMailedDate As System.Windows.Forms.TextBox
    Friend WithEvents txtComment As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtFreeportProtestDeadlineDate As System.Windows.Forms.TextBox
    Friend WithEvents txtFreeportProtestHearingDate As System.Windows.Forms.TextBox
    Friend WithEvents txtFreeportProtestCMRRR As System.Windows.Forms.TextBox
    Friend WithEvents cboFreeportProtestStatus As System.Windows.Forms.ComboBox
    Friend WithEvents txtFreeportProtestMailedDate As System.Windows.Forms.TextBox
    Friend WithEvents chkInactiveFl As System.Windows.Forms.CheckBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtClientLocationId As System.Windows.Forms.TextBox
    Friend WithEvents txtRenditionExtCMRRR As System.Windows.Forms.TextBox
    Friend WithEvents txtRenditionExtMailedDate As System.Windows.Forms.TextBox
    Friend WithEvents txtRenditionCMRRR As System.Windows.Forms.TextBox
    Friend WithEvents txtRenditionMailedDate As System.Windows.Forms.TextBox
    Friend WithEvents cmdValues As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtConsultantName As TextBox
    Friend WithEvents cboAccountInvoicedStatus As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtSICCode As TextBox
    Friend WithEvents cmdOpenAssessor As Button
    Friend WithEvents grpEvents As GroupBox
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents cmdNewEvent As Button
    Friend WithEvents dgEvents As DataGridView
End Class
