<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFactorXRef
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
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdClose = New System.Windows.Forms.Button
        Me.txtFactorCode = New System.Windows.Forms.TextBox
        Me.txtEntityName = New System.Windows.Forms.TextBox
        Me.txtStateCd = New System.Windows.Forms.TextBox
        Me.cboStateFactorCode = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(12, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 17)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "State"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(12, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 17)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Factor Code"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(12, 109)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 17)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "State Factor Code"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 17)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Factoring Entity"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdClose
        '
        Me.cmdClose.Location = New System.Drawing.Point(176, 170)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(75, 23)
        Me.cmdClose.TabIndex = 14
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'txtFactorCode
        '
        Me.txtFactorCode.Enabled = False
        Me.txtFactorCode.Location = New System.Drawing.Point(130, 60)
        Me.txtFactorCode.Name = "txtFactorCode"
        Me.txtFactorCode.Size = New System.Drawing.Size(160, 20)
        Me.txtFactorCode.TabIndex = 13
        '
        'txtEntityName
        '
        Me.txtEntityName.Enabled = False
        Me.txtEntityName.Location = New System.Drawing.Point(130, 8)
        Me.txtEntityName.Name = "txtEntityName"
        Me.txtEntityName.Size = New System.Drawing.Size(268, 20)
        Me.txtEntityName.TabIndex = 12
        '
        'txtStateCd
        '
        Me.txtStateCd.Enabled = False
        Me.txtStateCd.Location = New System.Drawing.Point(130, 34)
        Me.txtStateCd.Name = "txtStateCd"
        Me.txtStateCd.Size = New System.Drawing.Size(34, 20)
        Me.txtStateCd.TabIndex = 11
        '
        'cboStateFactorCode
        '
        Me.cboStateFactorCode.FormattingEnabled = True
        Me.cboStateFactorCode.Location = New System.Drawing.Point(130, 108)
        Me.cboStateFactorCode.Name = "cboStateFactorCode"
        Me.cboStateFactorCode.Size = New System.Drawing.Size(121, 21)
        Me.cboStateFactorCode.TabIndex = 10
        Me.cboStateFactorCode.Tag = "@DB=FactorCodeXRef.StateFactorCode"
        '
        'frmFactorXRef
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(444, 208)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.txtFactorCode)
        Me.Controls.Add(Me.txtEntityName)
        Me.Controls.Add(Me.txtStateCd)
        Me.Controls.Add(Me.cboStateFactorCode)
        Me.Name = "frmFactorXRef"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmFactorXRef"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents txtFactorCode As System.Windows.Forms.TextBox
    Friend WithEvents txtEntityName As System.Windows.Forms.TextBox
    Friend WithEvents txtStateCd As System.Windows.Forms.TextBox
    Friend WithEvents cboStateFactorCode As System.Windows.Forms.ComboBox
End Class
