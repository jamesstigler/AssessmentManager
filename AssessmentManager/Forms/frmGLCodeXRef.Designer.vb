<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGLCodeXRef
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
        Me.cboFactorCode = New System.Windows.Forms.ComboBox
        Me.txtStateCd = New System.Windows.Forms.TextBox
        Me.txtClientName = New System.Windows.Forms.TextBox
        Me.txtGLCode = New System.Windows.Forms.TextBox
        Me.cmdClose = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtEntity = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'cboFactorCode
        '
        Me.cboFactorCode.FormattingEnabled = True
        Me.cboFactorCode.Location = New System.Drawing.Point(130, 128)
        Me.cboFactorCode.Name = "cboFactorCode"
        Me.cboFactorCode.Size = New System.Drawing.Size(121, 21)
        Me.cboFactorCode.TabIndex = 0
        Me.cboFactorCode.Tag = "@DB=ClientGLCodeXRef.FactorCode"
        '
        'txtStateCd
        '
        Me.txtStateCd.Enabled = False
        Me.txtStateCd.Location = New System.Drawing.Point(130, 38)
        Me.txtStateCd.Name = "txtStateCd"
        Me.txtStateCd.Size = New System.Drawing.Size(34, 20)
        Me.txtStateCd.TabIndex = 1
        '
        'txtClientName
        '
        Me.txtClientName.Enabled = False
        Me.txtClientName.Location = New System.Drawing.Point(130, 12)
        Me.txtClientName.Name = "txtClientName"
        Me.txtClientName.Size = New System.Drawing.Size(268, 20)
        Me.txtClientName.TabIndex = 2
        '
        'txtGLCode
        '
        Me.txtGLCode.Enabled = False
        Me.txtGLCode.Location = New System.Drawing.Point(130, 64)
        Me.txtGLCode.Name = "txtGLCode"
        Me.txtGLCode.Size = New System.Drawing.Size(160, 20)
        Me.txtGLCode.TabIndex = 3
        '
        'cmdClose
        '
        Me.cmdClose.Location = New System.Drawing.Point(176, 179)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(75, 23)
        Me.cmdClose.TabIndex = 5
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 17)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Client Name"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(12, 129)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 17)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Factor Code"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(12, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 17)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Client G/L Code"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(12, 39)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 17)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "State"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(12, 91)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 17)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Factoring Entity"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtEntity
        '
        Me.txtEntity.Enabled = False
        Me.txtEntity.Location = New System.Drawing.Point(130, 90)
        Me.txtEntity.Name = "txtEntity"
        Me.txtEntity.Size = New System.Drawing.Size(232, 20)
        Me.txtEntity.TabIndex = 10
        '
        'frmGLCodeXRef
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(424, 212)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtEntity)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.txtGLCode)
        Me.Controls.Add(Me.txtClientName)
        Me.Controls.Add(Me.txtStateCd)
        Me.Controls.Add(Me.cboFactorCode)
        Me.Name = "frmGLCodeXRef"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Client G/L Code"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboFactorCode As System.Windows.Forms.ComboBox
    Friend WithEvents txtStateCd As System.Windows.Forms.TextBox
    Friend WithEvents txtClientName As System.Windows.Forms.TextBox
    Friend WithEvents txtGLCode As System.Windows.Forms.TextBox
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtEntity As System.Windows.Forms.TextBox
End Class
