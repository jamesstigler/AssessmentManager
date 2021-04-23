<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReport
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
        Me.reportviewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'reportviewer
        '
        Me.reportviewer.ActiveViewIndex = -1
        Me.reportviewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.reportviewer.Cursor = System.Windows.Forms.Cursors.Default
        Me.reportviewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.reportviewer.Location = New System.Drawing.Point(0, 0)
        Me.reportviewer.Name = "reportviewer"
        Me.reportviewer.SelectionFormula = ""
        Me.reportviewer.Size = New System.Drawing.Size(813, 532)
        Me.reportviewer.TabIndex = 0
        Me.reportviewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.reportviewer.ViewTimeSelectionFormula = ""
        '
        'frmReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(813, 532)
        Me.Controls.Add(Me.reportviewer)
        Me.Name = "frmReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Report"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents reportviewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
