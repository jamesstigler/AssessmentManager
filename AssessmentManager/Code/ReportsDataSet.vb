Partial Class ReportsDataSet
    Partial Public Class tblReportsDataTable
        Private Sub tblReportsDataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.UserNameColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class
End Class

Namespace ReportsDataSetTableAdapters
    
    Partial Public Class tblReportsTableAdapter
    End Class
End Namespace
