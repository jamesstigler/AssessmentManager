Module modTableUpdate
    Public Function UpdateFactorEntities(ByVal lFactorEntityId As Long, ByVal sField As String, _
            ByVal sValue As String, ByRef sError As String) As Boolean
        Dim sSQL As String = "", eDataType As enumDataTypes, bAllowNull As Boolean = False
        Dim lLength As Long = 0, sFieldDescription As String = ""
        Dim DBInfo As typeDBUpdateInfo, sFormat As String, vNewValue As Object, colDropDown As New Collection
        Dim ctlTextBox As New TextBox

        Try
            sError = ""
            ctlTextBox.Text = sValue
            With DBInfo
                .bAllowInsert = False
                .sTable = "FactorEntities"
                .sUpdateField = sField
                .vUpdateValue = sValue
                ReDim .PrimaryKeys(0)
                .PrimaryKeys(0).sField = "FactorEntityId"
                .PrimaryKeys(0).vValue = lFactorEntityId
            End With
            GetDataDefinition("FactorEntities", sField, eDataType, bAllowNull, lLength, sFieldDescription)
            SaveOneControl(DBInfo, ctlTextBox, eDataType, sFormat, bAllowNull, vNewValue, lLength, colDropDown, sError)



            Return True
        Catch ex As Exception
            sError = "Error in UpdateFactorEntities:  " & ex.Message
            Return False
        End Try
    End Function
    Public Function UpdateFactorEntityCodes(ByVal lFactorEntityId As Long, ByVal sFactorCode As String, _
            ByVal iTaxYear As Integer, ByVal sField As String, _
            ByVal sValue As String, ByRef sError As String) As Boolean
        Dim sSQL As String = "", eDataType As enumDataTypes, bAllowNull As Boolean = False
        Dim lLength As Long = 0, sFieldDescription As String = ""
        Dim DBInfo As typeDBUpdateInfo, sFormat As String, vNewValue As Object, colDropDown As New Collection
        Dim ctlTextBox As New TextBox

        Try
            sError = ""
            ctlTextBox.Text = sValue
            With DBInfo
                .bAllowInsert = False
                .sTable = "FactorEntityCodes"
                .sUpdateField = sField
                .vUpdateValue = sValue
                ReDim .PrimaryKeys(2)
                .PrimaryKeys(0).sField = "FactorEntityId"
                .PrimaryKeys(1).sField = "FactorCode"
                .PrimaryKeys(2).sField = "TaxYear"
                .PrimaryKeys(0).vValue = lFactorEntityId
                .PrimaryKeys(1).vValue = QuoStr(sFactorCode)
                .PrimaryKeys(2).vValue = iTaxYear
            End With
            GetDataDefinition("FactorEntityCodes", sField, eDataType, bAllowNull, lLength, sFieldDescription)
            SaveOneControl(DBInfo, ctlTextBox, eDataType, sFormat, bAllowNull, vNewValue, lLength, colDropDown, sError)



            Return True
        Catch ex As Exception
            sError = "Error in UpdateFactorCodes:  " & ex.Message
            Return False
        End Try
    End Function
    Public Function UpdateAssessmentDetailRE(ByVal lClientId As Long, ByVal lLocationId As Long, _
            ByVal lAssessmentId As Long, ByVal lJurisdictionId As Long, _
            ByVal iTaxYear As Integer, ByVal sField As String, _
            ByVal sValue As String, ByVal bApplyToAllJurisdictions As Boolean, ByRef sError As String) As Boolean
        Dim sSQL As String = "", eDataType As enumDataTypes, bAllowNull As Boolean = False
        Dim lLength As Long = 0, sFieldDescription As String = ""
        Dim DBInfo As typeDBUpdateInfo, sFormat As String, vNewValue As Object, colDropDown As New Collection
        Dim ctlTextBox As New TextBox

        Try
            sError = ""
            ctlTextBox.Text = sValue
            With DBInfo
                .bAllowInsert = False
                .sTable = "AssessmentDetailRE"
                .sUpdateField = sField
                .vUpdateValue = sValue
                If bApplyToAllJurisdictions Then
                    ReDim .PrimaryKeys(3)
                Else
                    ReDim .PrimaryKeys(4)
                End If
                .PrimaryKeys(0).sField = "ClientId"
                .PrimaryKeys(1).sField = "LocationId"
                .PrimaryKeys(2).sField = "AssessmentId"
                If bApplyToAllJurisdictions Then
                    .PrimaryKeys(3).sField = "TaxYear"
                Else
                    .PrimaryKeys(3).sField = "JurisdictionId"
                    .PrimaryKeys(4).sField = "TaxYear"
                End If
                .PrimaryKeys(0).vValue = lClientId
                .PrimaryKeys(1).vValue = lLocationId
                .PrimaryKeys(2).vValue = lAssessmentId
                If bApplyToAllJurisdictions Then
                    .PrimaryKeys(3).vValue = iTaxYear
                Else
                    .PrimaryKeys(3).vValue = lJurisdictionId
                    .PrimaryKeys(4).vValue = iTaxYear
                End If
            End With
            GetDataDefinition("AssessmentDetailRE", sField, eDataType, bAllowNull, lLength, sFieldDescription)
            SaveOneControl(DBInfo, ctlTextBox, eDataType, sFormat, bAllowNull, vNewValue, lLength, colDropDown, sError)



            Return True
        Catch ex As Exception
            sError = "Error in UpdateAssessmentDetailRE:  " & ex.Message
            Return False
        End Try
    End Function
    Public Function UpdateAssessmentDetailBPP(ByVal lClientId As Long, ByVal lLocationId As Long,
            ByVal lAssessmentId As Long, ByVal lJurisdictionId As Long,
            ByVal iTaxYear As Integer, ByVal sField As String,
            ByVal sValue As String, ByVal bApplyToAllJurisdictions As Boolean, ByRef sError As String) As Boolean
        Dim sSQL As String = "", eDataType As enumDataTypes, bAllowNull As Boolean = False
        Dim lLength As Long = 0, sFieldDescription As String = ""
        Dim DBInfo As typeDBUpdateInfo, sFormat As String, vNewValue As Object, colDropDown As New Collection
        Dim ctlTextBox As New TextBox

        Try
            sError = ""
            ctlTextBox.Text = sValue
            With DBInfo
                .bAllowInsert = False
                .sTable = "AssessmentDetailBPP"
                .sUpdateField = sField
                .vUpdateValue = sValue
                If bApplyToAllJurisdictions Then
                    ReDim .PrimaryKeys(3)
                Else
                    ReDim .PrimaryKeys(4)
                End If
                .PrimaryKeys(0).sField = "ClientId"
                .PrimaryKeys(1).sField = "LocationId"
                .PrimaryKeys(2).sField = "AssessmentId"
                If bApplyToAllJurisdictions Then
                    .PrimaryKeys(3).sField = "TaxYear"
                Else
                    .PrimaryKeys(3).sField = "JurisdictionId"
                    .PrimaryKeys(4).sField = "TaxYear"
                End If
                .PrimaryKeys(0).vValue = lClientId
                .PrimaryKeys(1).vValue = lLocationId
                .PrimaryKeys(2).vValue = lAssessmentId
                If bApplyToAllJurisdictions Then
                    .PrimaryKeys(3).vValue = iTaxYear
                Else
                    .PrimaryKeys(3).vValue = lJurisdictionId
                    .PrimaryKeys(4).vValue = iTaxYear
                End If
            End With
            GetDataDefinition("AssessmentDetailBPP", sField, eDataType, bAllowNull, lLength, sFieldDescription)
            SaveOneControl(DBInfo, ctlTextBox, eDataType, sFormat, bAllowNull, vNewValue, lLength, colDropDown, sError)

            Return True
        Catch ex As Exception
            sError = "Error in UpdateAssessmentDetailRE:  " & ex.Message
            Return False
        End Try
    End Function

    Public Function UpdateTaxBills(ByVal ePropType As enumTable, ByVal lClientId As Long, ByVal lLocationId As Long,
            ByVal lAssessmentId As Long, ByVal lCollectorId As Long, ByVal iTaxYear As Integer, ByVal sField As String,
            ByVal sValue As String, ByRef sError As String) As Boolean
        Dim eDataType As enumDataTypes, bAllowNull As Boolean = False
        Dim lLength As Long = 0, sFieldDescription As String = ""
        Dim DBInfo As typeDBUpdateInfo, sFormat As String, vNewValue As Object, colDropDown As New Collection
        Dim ctlTextBox As New TextBox

        Try
            sError = ""
            ctlTextBox.Text = sValue
            With DBInfo
                .bAllowInsert = True
                .sTable = "TaxBills" & IIf(ePropType = enumTable.enumLocationBPP, "BPP", "RE")
                .sUpdateField = sField
                .vUpdateValue = sValue
                ReDim .PrimaryKeys(4)
                .PrimaryKeys(0).sField = "ClientId"
                .PrimaryKeys(1).sField = "LocationId"
                .PrimaryKeys(2).sField = "AssessmentId"
                .PrimaryKeys(3).sField = "CollectorId"
                .PrimaryKeys(4).sField = "TaxYear"
                .PrimaryKeys(0).vValue = lClientId
                .PrimaryKeys(1).vValue = lLocationId
                .PrimaryKeys(2).vValue = lAssessmentId
                .PrimaryKeys(3).vValue = lCollectorId
                .PrimaryKeys(4).vValue = iTaxYear
            End With
            GetDataDefinition(DBInfo.sTable, sField, eDataType, bAllowNull, lLength, sFieldDescription)
            SaveOneControl(DBInfo, ctlTextBox, eDataType, sFormat, bAllowNull, vNewValue, lLength, colDropDown, sError)

            Return True
        Catch ex As Exception
            sError = "Error in UpdateAssessmentDetailRE:  " & ex.Message
            Return False
        End Try
    End Function


    Public Function UpdateInstallments(ByVal ePropType As enumTable, ByVal lInstallId As Long, _
            ByVal sField As String, ByVal sValue As String, ByRef sError As String) As Boolean
        Dim eDataType As enumDataTypes, bAllowNull As Boolean = False
        Dim lLength As Long = 0, sFieldDescription As String = ""
        Dim DBInfo As typeDBUpdateInfo, sFormat As String, vNewValue As Object, colDropDown As New Collection
        Dim sTable As String = "", ctlTextBox As New TextBox

        Try
            sError = ""
            ctlTextBox.Text = sValue
            sTable = "Installments" & IIf(ePropType = enumTable.enumLocationBPP, "BPP", "RE")
            With DBInfo
                .bAllowInsert = False
                .sTable = sTable
                .sUpdateField = sField
                'If sField = "PaidFl" Then
                ' If sValue = "False" Then sValue = 0 Else sValue = 1
                'Else
                .vUpdateValue = sValue
                'End If
                ReDim .PrimaryKeys(0)
                .PrimaryKeys(0).sField = "InstallId"
                .PrimaryKeys(0).vValue = lInstallId
            End With
            GetDataDefinition(sTable, sField, eDataType, bAllowNull, lLength, sFieldDescription)
            SaveOneControl(DBInfo, ctlTextBox, eDataType, sFormat, bAllowNull, vNewValue, lLength, colDropDown, sError)
            If sField = "PaidFl" Then
                sField = "PaidDt"
                DBInfo.sUpdateField = "PaidDt"
                If sValue = "True" Then
                    DBInfo.vUpdateValue = Format(Now, csDateTime)
                Else
                    DBInfo.vUpdateValue = Nothing
                End If
                ctlTextBox.Text = DBInfo.vUpdateValue
                GetDataDefinition(sTable, sField, eDataType, bAllowNull, lLength, sFieldDescription)
                SaveOneControl(DBInfo, ctlTextBox, eDataType, sFormat, bAllowNull, vNewValue, lLength, colDropDown, sError)
            End If

                Return True
        Catch ex As Exception
            sError = "Error in UpdateAssessmentDetailRE:  " & ex.Message
            Return False
        End Try
    End Function

End Module
