Module modAssessments
    Public Function SaveECUParent(lClientId As Long, lLocationId As Long, lAssessmentId As Long, iTaxYear As Integer, ePropType As enumTable, lParentId As Long, ByRef sError As String) As Boolean
        Try
            Dim sSQL As New StringBuilder
            sSQL.Append("UPDATE Assessments").Append(IIf(ePropType = enumTable.enumLocationBPP, "BPP", "RE")).Append(" SET ParentAssessmentId = ").Append(IIf(lParentId = 0, "NULL", lParentId))
            sSQL.Append(" WHERE ClientId = ").Append(lClientId).Append(" AND LocationId = ").Append(lLocationId).Append(" AND AssessmentId = ").Append(lAssessmentId)
            sSQL.Append(" AND TaxYear = ").Append(iTaxYear)
            If ExecuteSQL(sSQL.ToString) <> 1 Then
                sError = "Error saving ECU parent:  SQL = " & sSQL.ToString
                Return False
            End If
            Return True
        Catch ex As Exception
            sError = "Error saving ECU parent:  " & ex.Message
            Return False
        End Try
    End Function
    Public Function BuildTaxBillQuery(ByVal lClientId As Long, ByVal lLocationId As Long,
            ByVal lAssessmentId As Long, ByVal JurisdictionList As List(Of Long), ByVal iTaxYear As Integer,
            ByVal ePropType As enumTable, ByVal bReport As Boolean, ByVal bJurisdictionList As Boolean,
            ByVal bTotalByCollectorList As Boolean, ByVal bIncludeInstallmentFlag As Boolean, ByVal bSavings As Boolean,
            ByVal lClientRenditionValue As Long) As String
        Return BuildTaxBillQuery(lClientId, lLocationId, lAssessmentId, JurisdictionList, iTaxYear, ePropType, bReport, bJurisdictionList,
                bTotalByCollectorList, bIncludeInstallmentFlag, bSavings, lClientRenditionValue, 0)
    End Function
    Public Function BuildTaxBillQuery(ByVal lClientId As Long, ByVal lLocationId As Long,
            ByVal lAssessmentId As Long, ByVal JurisdictionList As List(Of Long), ByVal iTaxYear As Integer,
            ByVal ePropType As enumTable, ByVal bReport As Boolean, ByVal bJurisdictionList As Boolean,
            ByVal bTotalByCollectorList As Boolean, ByVal bIncludeInstallmentFlag As Boolean, ByVal bSavings As Boolean,
            ByVal lClientRenditionValue As Long, ByVal lBusinessUnitId As Long) As String
        Return BuildTaxBillQuery(lClientId, lLocationId, lAssessmentId, JurisdictionList, iTaxYear, ePropType, bReport, bJurisdictionList,
                bTotalByCollectorList, bIncludeInstallmentFlag, bSavings, lClientRenditionValue, 0, "")
    End Function

    Public Function BuildTaxBillQuery(ByVal lClientId As Long, ByVal lLocationId As Long,
            ByVal lAssessmentId As Long, ByVal JurisdictionList As List(Of Long), ByVal iTaxYear As Integer,
            ByVal ePropType As enumTable, ByVal bReport As Boolean, ByVal bJurisdictionList As Boolean,
            ByVal bTotalByCollectorList As Boolean, ByVal bIncludeInstallmentFlag As Boolean, ByVal bSavings As Boolean,
            ByVal lClientRenditionValue As Long, ByVal lBusinessUnitId As Long, ByVal sStateCd As String) As String
        Dim sSQL As String = "", sWHERE As String = ""
        Dim sIn As String = ""
        Dim sInNotified = "(" & enumSavingsExclusionCd.enumNotified & "," & enumSavingsExclusionCd.enumNotifiedAbatements & "," &
            enumSavingsExclusionCd.enumNotifiedAbatementsFreeport & "," & enumSavingsExclusionCd.enumNotifiedFreeport & ")"
        Dim sInAbatement = "(" & enumSavingsExclusionCd.enumAbatements & "," & enumSavingsExclusionCd.enumNotifiedAbatements & "," &
            enumSavingsExclusionCd.enumNotifiedAbatementsFreeport & "," & enumSavingsExclusionCd.enumAbatementsFreeport & "," &
            enumSavingsExclusionCd.enumClientAbatements & "," & enumSavingsExclusionCd.enumClientAbatementsFreeport & ")"
        Dim sInFreeport = "(" & enumSavingsExclusionCd.enumFreeport & "," & enumSavingsExclusionCd.enumNotifiedFreeport & "," &
            enumSavingsExclusionCd.enumNotifiedAbatementsFreeport & "," & enumSavingsExclusionCd.enumAbatementsFreeport & "," &
            enumSavingsExclusionCd.enumClientAbatementsFreeport & "," & enumSavingsExclusionCd.enumClientFreeport & ")"
        Dim sInClient = "(" & enumSavingsExclusionCd.enumClient & "," & enumSavingsExclusionCd.enumClientAbatements & "," &
           enumSavingsExclusionCd.enumClientAbatementsFreeport & "," & enumSavingsExclusionCd.enumClientFreeport & ")"

        If JurisdictionList Is Nothing Then JurisdictionList = New List(Of Long)
        For Each lJurisdictionId As Long In JurisdictionList
            If sIn <> "" Then sIn = sIn & ","
            sIn = sIn & lJurisdictionId
        Next

        sSQL = ""
        ' Beginning of SELECT
        If bTotalByCollectorList Then
            sSQL = "SELECT TaxYear, Clients_Name, ClientId, LocationId, Locations_Address, Locations_ClientLocationId, Locations_Name," &
                "Locations_City, Locations_StateCd," &
                "Locations_Zip, AcctNum, BusinessUnits_Name, AssessmentId, Assessors_Name, Collectors_Name, Payee, AssessorId, CollectorId," &
                "Collectors_DueDate, Collectors_DiscountFl," &
                "Collectors_DiscountDate, Collectors_DiscountDate2, Collectors_DiscountDate3, Collectors_DiscountDate4," &
                "Collectors_StateCd, Collectors_Address1, Collectors_Address2, Collectors_City, Collectors_PayeeStateCd," &
                "Collectors_Zip,Collectors_Phone,Consultants_ConsultantName,Consultants_EMail,Consultants_Phone,Consultants_FullName," &
                "TaxBillNotes,TaxBillAcctNum," &
                "TaxBillLoaded,ROUND(SUM(TaxDue), 2) AS TotalTaxDue FROM ("
        End If

        sSQL = sSQL & "SELECT l.TaxYear, c.Name AS Clients_Name, c.ClientId, l.LocationId, l.Address AS Locations_Address," &
                " l.ClientLocationId AS Locations_ClientLocationId," &
                " l.Name AS Locations_Name, ISNULL(c.ExcludeNotified,0) AS ExcludeNotified," &
                " ISNULL(c.ExcludeClient,0) AS ExcludeClient," &
                " ISNULL(c.ExcludeAbatements,0) AS ExcludeAbatements, ISNULL(c.ExcludeFreeport,0) AS ExcludeFreeport," &
                " l.City AS Locations_City, l.StateCd AS Locations_StateCd, l.Zip AS Locations_Zip, ISNULL(asmt.AcctNum,'') AS AcctNum,"
        sSQL = sSQL & "ISNULL(bu.Name,'') AS BusinessUnits_Name,"
        sSQL = sSQL &
                " asmt.AssessmentId, ISNULL(asmt.SavingsExclusionCd,0) AS SavingsExclusionCd," &
                " ISNULL(asr.Name,'') AS Assessors_Name, j.FreeportFl AS Jurisdictions_FreeportFl,"
        sSQL = sSQL & "ISNULL(c.InactiveFl,0) AS Clients_InactiveFl,ISNULL(l.InactiveFl,0) AS Locations_InactiveFl,ISNULL(asmt.InactiveFl,0) AS Assessments_InactiveFl,"
        sSQL = sSQL & "ISNULL(collect.Name,'NONE') AS Collectors_Name,ISNULL(j.Name,'') AS Jurisdictions_Name,"
        If ePropType = enumTable.enumLocationBPP Then
            If bSavings Then
                sSQL = sSQL & "ROUND(ISNULL(ad.NotifiedValue,0) * ISNULL(asr.BPPRatio,0),0) AS NotifiedValue,"
            Else
                sSQL = sSQL & "ad.NotifiedValue,"
            End If
            sSQL = sSQL & "0 AS RELandValue, 0 AS REImprovementValue,"
            If bSavings Then
                sSQL = sSQL & " CASE WHEN ISNULL(c.ExcludeNotified,0) <> 0 OR ISNULL(asmt.SavingsExclusionCd,0) IN " & sInNotified & " THEN 'Client Value'" &
                    " WHEN ISNULL(c.ExcludeClient,0) <> 0 OR ISNULL(asmt.SavingsExclusionCd,0) IN " & sInClient & " THEN 'Notified Value'" &
                    " ELSE CASE WHEN ISNULL(ad.NotifiedValue,0) > " & lClientRenditionValue & " THEN 'Notified Value' ELSE 'Client Value' END END AS ValueSource,"

                sSQL = sSQL & " CASE WHEN ISNULL(c.ExcludeNotified,0) <> 0 THEN ROUND(" & lClientRenditionValue & " * ISNULL(asr.BPPRatio,0),0)" &
                    " ELSE CASE WHEN ISNULL(c.ExcludeClient,0) <> 0 THEN ROUND(ISNULL(ad.NotifiedValue,0) * ISNULL(asr.BPPRatio,0),0)" &
                    " ELSE CASE WHEN ISNULL(asmt.SavingsExclusionCd,0) IN " & sInNotified & " THEN ROUND(" & lClientRenditionValue & " * ISNULL(asr.BPPRatio,0),0)" &
                    " WHEN ISNULL(asmt.SavingsExclusionCd,0) IN " & sInClient & " THEN ROUND(ISNULL(ad.NotifiedValue,0) * ISNULL(asr.BPPRatio,0),0)" &
                    " ELSE CASE WHEN ISNULL(ad.NotifiedValue,0) > " & lClientRenditionValue & " THEN ROUND(ISNULL(ad.NotifiedValue,0) * ISNULL(asr.BPPRatio,0),0)" &
                    " ELSE ROUND(" & lClientRenditionValue & " * ISNULL(asr.BPPRatio,0),0)" & " END END END END"

            Else
                sSQL = sSQL & "'Notified Value' AS ValueSource, ad.NotifiedValue"
            End If
            sSQL = sSQL & " AS TotalAssessedValue,"
        Else
            If bSavings Then
                sSQL = sSQL & " ROUND(ISNULL(asr.RERatio,0) * ROUND(ISNULL(ad.TotalAssessedValue,(ISNULL(ad.RELandValue,0) + ISNULL(ad.REImprovementValue,0))),0),0) AS NotifiedValue,"
                sSQL = sSQL & "ROUND(ISNULL(asr.RERatio,0) * ISNULL(ad.RELandValue,0),0) AS RELandValue, ROUND(ISNULL(asr.RERatio,0) * ISNULL(ad.REImprovementValue,0),0) AS REImprovementValue,"
                'for now show Notified Value in the report header even if notified is excluded.  Calculations still take the exclude flag into consideration
                sSQL = sSQL & " CASE WHEN ISNULL(c.ExcludeNotified,0) <> 0 OR ISNULL(asmt.SavingsExclusionCd,0) IN " & sInNotified &
                    " THEN 'Notified Value' ELSE 'Notified Value' END AS ValueSource,"
                sSQL = sSQL & " CASE WHEN ISNULL(c.ExcludeNotified,0) <> 0 OR ISNULL(asmt.SavingsExclusionCd,0) IN " & sInNotified
                sSQL = sSQL & " THEN ROUND(ISNULL(asr.RERatio,0) * ISNULL(ad.FinalValue,0),0)" &
                    " ELSE ROUND(ISNULL(asr.RERatio, 0) * ROUND(ISNULL(ad.TotalAssessedValue, (ISNULL(ad.RELandValue, 0) + ISNULL(ad.REImprovementValue, 0))), 0), 0)" &
                    " END AS TotalAssessedValue,"
            Else
                sSQL = sSQL & " ROUND(ISNULL(ad.TotalAssessedValue,(ISNULL(ad.RELandValue,0) + ISNULL(ad.REImprovementValue,0))),0) AS NotifiedValue,"
                sSQL = sSQL & "ad.RELandValue, ad.REImprovementValue," &
                    " 'Notified Value' AS ValueSource," &
                    " ROUND(ISNULL(ad.TotalAssessedValue,(ISNULL(ad.RELandValue,0) + ISNULL(ad.REImprovementValue,0))),0) AS TotalAssessedValue, "
            End If
        End If

        If Not bSavings Then
            sSQL = sSQL & " ISNULL((SELECT 'Yes' WHERE EXISTS(SELECT tb.ClientId FROM TaxBills" & IIf(ePropType = enumTable.enumLocationBPP, "BPP", "RE") & " AS tb" &
                " WHERE tb.ClientId = asmt.ClientId AND tb.LocationId = asmt.LocationId AND tb.AssessmentId = asmt.AssessmentId" &
                " AND tb.CollectorId = j.CollectorId AND tb.TaxYear = j.TaxYear AND tb.FormData IS NOT NULL)),'No') AS TaxBillLoaded,"
        End If

        If bIncludeInstallmentFlag = False Then
            sSQL = sSQL & " 0 AS HasInstallments,"
        Else
            sSQL = sSQL & " ISNULL((SELECT 1 WHERE EXISTS(SELECT InstallId FROM Installments" & IIf(ePropType = enumTable.enumLocationBPP, "BPP", "RE") &
                " WHERE ClientId = ad.ClientId AND LocationId = ad.LocationId AND AssessmentId = ad.AssessmentId" &
                " AND CollectorId = collect.CollectorId AND TaxYear = ad.TaxYear AND TaxYear = collect.TaxYear)),0) AS HasInstallments,"

        End If

        If bSavings Then
            sSQL = sSQL & "ROUND(ISNULL(ad.FinalValue,0) * ISNULL(asr." & IIf(ePropType = enumTable.enumLocationBPP, "BPPRatio", "RERatio") & ",0),0) AS FinalValue,"
        Else
            sSQL = sSQL & "ad.FinalValue,"
        End If
        If bSavings Then
            sSQL = sSQL & " ROUND(ISNULL(ad.ClientAbatementAmt,0) * ISNULL(asr." & IIf(ePropType = enumTable.enumLocationBPP, "BPPRatio", "RERatio") & ",0),0) AS ClientAbatementAmt,"
            sSQL = sSQL & " ROUND(ISNULL(ad.AbatementReductionAmt,0) * ISNULL(asr." & IIf(ePropType = enumTable.enumLocationBPP, "BPPRatio", "RERatio") & ",0),0) AS AbatementReductionAmt,"
        Else
            sSQL = sSQL & " ISNULL(ad.ClientAbatementAmt,0) AS ClientAbatementAmt,"
            sSQL = sSQL & " ISNULL(ad.AbatementReductionAmt,0) AS AbatementReductionAmt,"
        End If

        If ePropType = enumTable.enumLocationBPP Then
            If bSavings Then
                sSQL = sSQL & " ROUND(ISNULL(ad.ClientFreeportAmt,0) * ISNULL(asr.BPPRatio,0),0) AS ClientFreeportAmt,"
                sSQL = sSQL & " ROUND(ISNULL(ad.FreeportReductionAmt,0) * ISNULL(asr.BPPRatio,0),0) AS FreeportReductionAmt,"
            Else
                sSQL = sSQL & " ISNULL(ad.ClientFreeportAmt, 0) AS ClientFreeportAmt,"
                sSQL = sSQL & " ISNULL(ad.FreeportReductionAmt, 0) AS FreeportReductionAmt,"
            End If
        Else
            sSQL = sSQL & " 0 AS ClientFreeportAmt,"
            sSQL = sSQL & " 0 AS FreeportReductionAmt,"
        End If

        sSQL = sSQL & " ad.AdjDesc1,ad.AdjAmt1,"
        If ePropType = enumTable.enumLocationBPP Then
            sSQL = sSQL & "asr.BPPRatio, .00000000001 AS RERatio,"
        Else
            sSQL = sSQL & ".00000000001 AS BPPRatio, asr.RERatio,"
        End If

        If ePropType = enumTable.enumLocationBPP Then
            sSQL = sSQL & "round(round(ISNULL(ad.FinalValue,0) - ISNULL(ad.AbatementReductionAmt, 0) - " &
                " ISNULL(ad.FreeportReductionAmt, 0) + ISNULL(ad.AdjAmt1, 0),0) * ISNULL(asr.BPPRatio,0),0) AS TaxableValue,"
            If bSavings Then
                sSQL = sSQL & "(ROUND((("

                sSQL = sSQL & " CASE WHEN ISNULL(c.ExcludeNotified,0) <> 0 THEN " & lClientRenditionValue &
                    " ELSE CASE WHEN ISNULL(c.ExcludeClient,0) <> 0 THEN ISNULL(ad.NotifiedValue,0)" &
                    " ELSE CASE WHEN ISNULL(asmt.SavingsExclusionCd,0) IN " & sInNotified & " THEN " & lClientRenditionValue &
                    " WHEN ISNULL(asmt.SavingsExclusionCd,0) IN " & sInClient & " THEN ISNULL(ad.NotifiedValue,0)" &
                    " ELSE CASE WHEN ISNULL(ad.NotifiedValue,0) > " & lClientRenditionValue & " THEN ISNULL(ad.NotifiedValue,0)" &
                    " ELSE " & lClientRenditionValue & " END END END END"

                sSQL = sSQL & " - ISNULL(ad.ClientFreeportAmt,0) - ISNULL(ad.ClientAbatementAmt,0))"
                sSQL = sSQL & " * ISNULL(asr.BPPRatio,0)),0) - "
                sSQL = sSQL & " (ROUND((ISNULL(ad.FinalValue,0) - "
                sSQL = sSQL & " ISNULL(ad.AbatementReductionAmt, 0)"

                sSQL = sSQL & " - "

                sSQL = sSQL & " ISNULL(ad.FreeportReductionAmt, 0)"

                sSQL = sSQL & " + ISNULL(ad.AdjAmt1,0)"

                sSQL = sSQL & ") * ISNULL(asr.BPPRatio,0),0))) AS ValueDifference," &
                    " ISNULL((SELECT jLast.TaxRate FROM Jurisdictions jLast" &
                    " WHERE(jLast.JurisdictionId = ad.JurisdictionId)" &
                    " AND jLast.TaxYear = " & iTaxYear & "),ISNULL(j.TaxRate,0)) AS PreviousYearTaxRate,"
            End If
        Else
            sSQL = sSQL & "round(round(ISNULL(ad.FinalValue,0) - ISNULL(ad.AbatementReductionAmt,0) + " &
                " ISNULL(ad.AdjAmt1,0),0) * ISNULL(asr.RERatio,0),0)" &
                " AS TaxableValue,"
            If bSavings Then
                sSQL = sSQL & " CASE WHEN ISNULL(c.ExcludeNotified,0) <> 0 OR ISNULL(asmt.SavingsExclusionCd,0) IN " & sInNotified &
                    " THEN 0 ELSE"
                sSQL = sSQL & " (ROUND((ISNULL(ad.TotalAssessedValue, ISNULL(ad.RELandValue,0) + ISNULL(REImprovementValue,0)) - ISNULL(ad.ClientAbatementAmt,0)) * " &
                    " ISNULL(asr.RERatio,0),0)) - (ROUND((ISNULL(ad.FinalValue,0) - "
                sSQL = sSQL & " ISNULL(ad.AbatementReductionAmt, 0)"
                sSQL = sSQL & " + ISNULL(ad.AdjAmt1,0)"
                sSQL = sSQL & ") * " &
                    " ISNULL(asr.RERatio,0),0)) END as ValueDifference,"

                sSQL = sSQL &
                    " ISNULL((SELECT jLast.TaxRate FROM Jurisdictions jLast" &
                    " WHERE(jLast.JurisdictionId = ad.JurisdictionId)" &
                    " AND jLast.TaxYear = " & iTaxYear & "),ISNULL(j.TaxRate,0)) AS PreviousYearTaxRate,"
            End If
        End If


        sSQL = sSQL & "ISNULL(j.TaxRate,0) AS TaxRate, ad.TaxBillAdjDesc1, ad.TaxBillAdjAmt1,"

        If ePropType = enumTable.enumLocationBPP Then
            sSQL = sSQL & " round(round(round(round(isnull(ad.FinalValue,0)-isnull(ad.AbatementReductionAmt,0)" &
                " - isnull(ad.FreeportReductionAmt,0)+isnull(ad.AdjAmt1,0),0) * isnull(asr.BPPRatio,0),0)" &
                " * (isnull(j.TaxRate,0)/100),2) + isnull(ad.TaxBillAdjAmt1,0),2) as TaxDue,"
            If bSavings Then
                sSQL = sSQL & " round(round(round(isnull(ad.FinalValue,0) - "
                sSQL = sSQL & " ISNULL(ad.AbatementReductionAmt,0)"
                sSQL = sSQL & " - "
                sSQL = sSQL & " ISNULL(ad.FreeportReductionAmt, 0)"
                sSQL = sSQL & " + ISNULL(ad.AdjAmt1,0)"
                sSQL = sSQL & ",0) * isnull(asr.BPPRatio,0),0)" &
                    " * ISNULL((SELECT jLast.TaxRate FROM Jurisdictions jLast" &
                    " WHERE jLast.JurisdictionId = ad.JurisdictionId" &
                    " AND jLast.TaxYear = " & iTaxYear & "),ISNULL(j.TaxRate,0))/100 + ISNULL(ad.TaxBillAdjAmt1,0),2) AS TaxDueUsingPreviousYearRate,"
            End If
        Else
            sSQL = sSQL & " round(round(round(round(isnull(ad.FinalValue,0)-isnull(ad.AbatementReductionAmt,0)" &
                " + isnull(ad.AdjAmt1,0),0) * isnull(asr.RERatio,0),0)" &
                " * (isnull(j.TaxRate,0)/100),2) + isnull(ad.TaxBillAdjAmt1,0),2) as TaxDue,"
            If bSavings Then
                sSQL = sSQL & " round(round(round(isnull(ad.FinalValue,0) - "
                sSQL = sSQL & " ISNULL(ad.AbatementReductionAmt, 0)"
                sSQL = sSQL & " + ISNULL(ad.AdjAmt1,0)"
                sSQL = sSQL & " ,0)" &
                    " * isnull(asr.RERatio,0),0)" &
                    " * ISNULL((SELECT jLast.TaxRate FROM Jurisdictions jLast" &
                    " WHERE jLast.JurisdictionId = ad.JurisdictionId" &
                    " AND jLast.TaxYear = " & iTaxYear & "), ISNULL(j.TaxRate,0)) / 100 + ISNULL(ad.TaxBillAdjAmt1,0),2) AS TaxDueUsingPreviousYearRate,"
            End If
        End If

        If bSavings Then
            If ePropType = enumTable.enumLocationBPP Then
                sSQL = sSQL & " (ROUND(ROUND(("
                sSQL = sSQL & " CASE WHEN ISNULL(c.ExcludeNotified,0) <> 0 THEN " & lClientRenditionValue &
                    " ELSE CASE WHEN ISNULL(c.ExcludeClient,0) <> 0 THEN ISNULL(ad.NotifiedValue,0)" &
                    " ELSE CASE WHEN ISNULL(asmt.SavingsExclusionCd,0) IN " & sInNotified & " THEN " & lClientRenditionValue &
                    " WHEN ISNULL(asmt.SavingsExclusionCd,0) IN " & sInClient & " THEN ISNULL(ad.NotifiedValue,0)" &
                    " ELSE CASE WHEN ISNULL(ad.NotifiedValue,0) > " & lClientRenditionValue & " THEN ISNULL(ad.NotifiedValue,0)" &
                    " ELSE " & lClientRenditionValue & " END END END END"
                sSQL = sSQL & " - ISNULL(ad.ClientFreeportAmt,0) - ISNULL(ad.ClientAbatementAmt,0))"
                sSQL = sSQL & " * ISNULL(asr.BPPRatio,0),0) * ISNULL((SELECT jLast.TaxRate" &
                    " FROM Jurisdictions jLast WHERE jLast.JurisdictionId = ad.JurisdictionId" &
                    " AND jLast.TaxYear = " & iTaxYear & "),ISNULL(j.TaxRate,0)) / 100 + ISNULL(ad.TaxBillAdjAmt1,0), 2))" &
                    " AS TaxDueBeforeSavings,"
                sSQL = sSQL & " ROUND(ROUND(ROUND(("
                sSQL = sSQL & " CASE WHEN ISNULL(c.ExcludeNotified,0) <> 0 THEN " & lClientRenditionValue &
                    " ELSE CASE WHEN ISNULL(c.ExcludeClient,0) <> 0 THEN ISNULL(ad.NotifiedValue,0)" &
                    " ELSE CASE WHEN ISNULL(asmt.SavingsExclusionCd,0) IN " & sInNotified & " THEN " & lClientRenditionValue &
                    " WHEN ISNULL(asmt.SavingsExclusionCd,0) IN " & sInClient & " THEN ISNULL(ad.NotifiedValue,0)" &
                    " ELSE CASE WHEN ISNULL(ad.NotifiedValue,0) > " & lClientRenditionValue & " THEN ISNULL(ad.NotifiedValue,0)" &
                    " ELSE " & lClientRenditionValue & " END END END END"
                sSQL = sSQL & " - ISNULL(ad.ClientFreeportAmt,0) - ISNULL(ad.ClientAbatementAmt,0))"
                sSQL = sSQL & " * ISNULL(asr.BPPRatio,0),0) * " &
                    " ISNULL((SELECT jLast.TaxRate FROM Jurisdictions jLast" &
                    " WHERE jLast.JurisdictionId = ad.JurisdictionId" &
                    " AND jLast.TaxYear = " & iTaxYear & "),ISNULL(j.TaxRate,0)) / 100 + ISNULL(ad.TaxBillAdjAmt1,0), 2) - " &
                    " round(round(round((round(isnull(ad.FinalValue,0) - "
                sSQL = sSQL & " ISNULL(ad.AbatementReductionAmt,0)"
                sSQL = sSQL & " - "
                sSQL = sSQL & " ISNULL(ad.FreeportReductionAmt, 0)"
                sSQL = sSQL & " + isnull(ad.AdjAmt1,0),0)) * isnull(asr.BPPRatio,0),0) * " &
                    " ISNULL((SELECT jLast.TaxRate FROM Jurisdictions jLast" &
                    " WHERE jLast.JurisdictionId = ad.JurisdictionId" &
                    " AND jLast.TaxYear = " & iTaxYear & "),ISNULL(j.TaxRate,0)) / 100 + ISNULL(ad.TaxBillAdjAmt1,0), 2)" &
                    " ,2),2)" &
                    " AS SavingsAmt,"
            Else
                sSQL = sSQL & " CASE WHEN ISNULL(c.ExcludeNotified,0) <> 0 OR ISNULL(asmt.SavingsExclusionCd,0) IN " & sInNotified
                sSQL = sSQL & " THEN round(round(round(round(isnull(ad.FinalValue,0)-isnull(ad.AbatementReductionAmt,0)" &
                    " + isnull(ad.AdjAmt1,0),0) * isnull(asr.RERatio,0),0)" &
                    " * (isnull(j.TaxRate,0)/100),2) + isnull(ad.TaxBillAdjAmt1,0),2)"
                sSQL = sSQL & " ELSE ROUND(ROUND((ISNULL(ad.TotalAssessedValue, ISNULL(ad.RELandValue,0) + ISNULL(ad.REImprovementValue,0)) - ISNULL(ad.ClientAbatementAmt,0)) * " &
                    " ISNULL(asr.RERatio,0),0) * ISNULL((SELECT jLast.TaxRate FROM Jurisdictions jLast" &
                    " WHERE jLast.JurisdictionId = ad.JurisdictionId AND jLast.TaxYear = " & iTaxYear & "),ISNULL(j.TaxRate,0)) / 100 + ISNULL(ad.TaxBillAdjAmt1,0), 2)" &
                    " END AS TaxDueBeforeSavings,"
                sSQL = sSQL & " CASE WHEN ISNULL(c.ExcludeNotified,0) <> 0 OR ISNULL(asmt.SavingsExclusionCd,0) IN " & sInNotified
                sSQL = sSQL & " THEN 0 ELSE ROUND(ROUND(ROUND((ISNULL(ad.TotalAssessedValue, ISNULL(ad.RELandValue,0) + ISNULL(ad.REImprovementValue,0)) - ISNULL(ad.ClientAbatementAmt,0)) * " &
                    " ISNULL(asr.RERatio,0),0) * ISNULL((SELECT jLast.TaxRate FROM Jurisdictions jLast" &
                    " WHERE jLast.JurisdictionId = ad.JurisdictionId AND jLast.TaxYear = " & iTaxYear & "),ISNULL(j.TaxRate,0)) / 100 + ISNULL(ad.TaxBillAdjAmt1,0), 2) -" &
                    " round(round(round(round(isnull(ad.FinalValue,0) - "
                sSQL = sSQL & " ISNULL(ad.AbatementReductionAmt,0)"
                sSQL = sSQL & " + " &
                    " isnull(ad.AdjAmt1,0),0) * isnull(asr.RERatio,0),0) * " &
                    " ISNULL((SELECT jLast.TaxRate FROM Jurisdictions jLast" &
                    " WHERE jLast.JurisdictionId = ad.JurisdictionId AND jLast.TaxYear = " & iTaxYear & "),ISNULL(j.TaxRate,0)) / 100 + ISNULL(ad.TaxBillAdjAmt1,0), 2)" &
                    " ,2),2) END AS SavingsAmt,"
            End If
        End If

        sSQL = sSQL & "ad.PenaltyAmt1, ad.TaxBillPrintedDate,"

        sSQL = sSQL & "j.JurisdictionId,asr.AssessorId,ISNULL(collect.CollectorId,0) AS CollectorId,"
        If ePropType = enumTable.enumLocationBPP Then
            sSQL = sSQL & " collect.BPPDueDate1 AS Collectors_DueDate,"
        Else
            sSQL = sSQL & " collect.REDueDate1 AS Collectors_DueDate,"
        End If
        sSQL = sSQL & " collect.DiscountDate AS Collectors_DiscountDate,collect.DiscountDate2 AS Collectors_DiscountDate2,collect.DiscountDate3 AS Collectors_DiscountDate3,collect.DiscountDate4 AS Collectors_DiscountDate4," &
            " collect.DiscountFl as Collectors_DiscountFl,ISNULL(collect.Phone,'') as Collectors_Phone"

        sSQL = sSQL & ",consult.ConsultantName AS Consultants_ConsultantName, consult.EMail AS Consultants_EMail, consult.Phone AS Consultants_Phone,consult.FullName AS Consultants_FullName"
        sSQL = sSQL & ",taxbills.TaxBillNotes,ISNULL(taxbills.TaxBillAcctNum,ISNULL(asmt.AcctNum,'')) AS TaxBillAcctNum"

        If Not bJurisdictionList Then
            sSQL = sSQL & "," & IIf(ePropType = enumTable.enumLocationBPP, "'P'", "'R'") & " AS PropertyType," &
                " collect.StateCd AS Collectors_StateCd,collect.PayeeStateCd AS Collectors_PayeeStateCd," &
                " collect.Payee, collect.Address1 AS Collectors_Address1, collect.Address2 AS Collectors_Address2, collect.City AS Collectors_City," &
                " collect.Zip AS Collectors_Zip," &
                " asr.LienDate," &
                " ISNULL(c.ContactTaxName,'') AS ContactTaxName, ISNULL(c.ContactTaxAddress,'') AS ContactTaxAddress," &
                " ISNULL(c.ContactTaxCity,'') AS ContactTaxCity, ISNULL(c.ContactTaxStateCd,'') AS ContactTaxStateCd," &
                " ISNULL(c.ContactTaxZip,'') AS ContactTaxZip," &
                " RTRIM(LTRIM(ISNULL(l.ClientLocationId,''))) AS ClientLocationId, l.LegalOwner"
        End If

        If bSavings Then
            sSQL = sSQL & ", c.ContractFee, c.ContractFeeContingencyCapAmt ,c.ContractFeeContingencyCapFl ,c.ContractFeeContingencyCapPct," &
                " c.ContractFeeContingencyFl ,c.ContractFeeContingencyPct ,c.ContractFeeFlatAmt ,c.ContractFeeFlatFl," &
                " c.ContractFeeFlatPerLocAmt ,c.ContractFeeFlatPerLocFl ,c.ContractFeeOther ,c.ContractFeeOtherFl," &
                " c.ContractLocationFee,"
            If ePropType = enumTable.enumLocationBPP Then
                sSQL = sSQL & "0 AS PriorYearTotalFinalValue"
            Else
                sSQL = sSQL & "ROUND(ISNULL(ISNULL(asr.RERatio,0) * (SELECT MAX(FinalValue)" &
                " FROM AssessmentDetailRE" &
                " WHERE ClientId = asmt.ClientId" &
                " AND LocationId = asmt.LocationId" &
                " AND AssessmentId = asmt.AssessmentId" &
                " AND TaxYear = " & iTaxYear - 1 & "),0),0) AS PriorYearTotalFinalValue"
            End If
        End If
        'End of select

        ' JOINS
        sSQL = sSQL & " FROM Assessors AS asr RIGHT OUTER JOIN" &
                IIf(ePropType = enumTable.enumLocationBPP, " LocationsBPP ", " LocationsRE ") & " AS l RIGHT OUTER JOIN" &
                IIf(ePropType = enumTable.enumLocationBPP, " AssessmentsBPP ", " AssessmentsRE ") & " AS asmt INNER JOIN" &
                " Clients AS c ON asmt.ClientId = c.ClientId ON l.ClientId = asmt.ClientId AND" &
                " l.LocationId = asmt.LocationId AND" &
                " l.TaxYear = asmt.TaxYear LEFT OUTER JOIN" &
                IIf(ePropType = enumTable.enumLocationBPP, " AssessmentDetailBPP ", " AssessmentDetailRE ") & " AS ad INNER JOIN" &
                " Jurisdictions AS j ON ad.JurisdictionId = j.JurisdictionId AND ad.TaxYear = j.TaxYear" &
                " ON asmt.ClientId = ad.ClientId AND" &
                " asmt.LocationId = ad.LocationId AND asmt.AssessmentId = ad.AssessmentId" &
                " AND asmt.TaxYear = ad.TaxYear" &
                " ON asr.AssessorId = asmt.AssessorId AND asr.TaxYear = asmt.TaxYear LEFT OUTER JOIN" &
                " Collectors AS collect ON j.CollectorId = collect.CollectorId AND j.TaxYear = collect.TaxYear"
        sSQL = sSQL & " LEFT OUTER JOIN BusinessUnits bu ON asmt.ClientId = bu.ClientId AND asmt.BusinessUnitId = bu.BusinessUnitId"
        sSQL = sSQL & " LEFT OUTER JOIN Consultants consult" &
            " ON ISNULL(l.ConsultantName,c." & IIf(ePropType = enumTable.enumLocationBPP, "BPP", "RE") & "ConsultantName) = consult.ConsultantName"
        sSQL = sSQL & " LEFT OUTER JOIN TaxBills" & IIf(ePropType = enumTable.enumLocationBPP, "BPP", "RE") & " taxbills" &
            " ON taxbills.ClientId = ad.ClientId AND taxbills.LocationId = ad.LocationId AND taxbills.AssessmentId = ad.AssessmentId AND taxbills.CollectorId = j.CollectorId AND taxbills.TaxYear = ad.TaxYear"

        If lClientId > 0 Then
            If sWHERE = "" Then sWHERE = " WHERE " Else sWHERE = sWHERE & " AND "
            sWHERE = sWHERE & " ad.ClientId = " & lClientId
        Else
            If sWHERE = "" Then sWHERE = " WHERE " Else sWHERE = sWHERE & " AND "
            sWHERE = sWHERE & " ISNULL(c.ProspectFl,0) = 0 "
            If AppData.IncludeInactive = False Then
                If sWHERE = "" Then sWHERE = " WHERE " Else sWHERE = sWHERE & " AND "
                sWHERE = sWHERE & " ISNULL(c.InactiveFl,0) = 0 "
            End If
        End If
        If lLocationId > 0 Then
            If sWHERE = "" Then sWHERE = " WHERE " Else sWHERE = sWHERE & " AND "
            sWHERE = sWHERE & " ad.LocationId = " & lLocationId
        Else
            If AppData.IncludeInactive = False Then
                If sWHERE = "" Then sWHERE = " WHERE " Else sWHERE = sWHERE & " AND "
                sWHERE = sWHERE & " ISNULL(l.InactiveFl,0) = 0 "
            End If
        End If
        If lAssessmentId > 0 Then
            If sWHERE = "" Then sWHERE = " WHERE " Else sWHERE = sWHERE & " AND "
            sWHERE = sWHERE & " ad.AssessmentId = " & lAssessmentId
        Else
            If AppData.IncludeInactive = False Then
                If sWHERE = "" Then sWHERE = " WHERE " Else sWHERE = sWHERE & " AND "
                sWHERE = sWHERE & " ISNULL(asmt.InactiveFl,0) = 0 "
            End If
        End If
        If iTaxYear > 0 Then
            If sWHERE = "" Then sWHERE = " WHERE " Else sWHERE = sWHERE & " AND "
            sWHERE = sWHERE & " l.TaxYear = " & iTaxYear
        End If
        If lBusinessUnitId > 0 Then
            If sWHERE = "" Then sWHERE = " WHERE " Else sWHERE = sWHERE & " AND "
            sWHERE = sWHERE & " asmt.BusinessUnitId = " & lBusinessUnitId
        End If
        If sStateCd.Trim <> "" Then
            If sWHERE = "" Then sWHERE = " WHERE " Else sWHERE = sWHERE & " AND "
            sWHERE = sWHERE & " l.StateCd = " & QuoStr(sStateCd)
        End If

        If bSavings Then
            sWHERE = sWHERE & " AND ISNULL(asmt.SavingsExclusionCd,0) <> " & enumSavingsExclusionCd.enumEntire
        End If

        sSQL = sSQL & sWHERE

        If sIn <> "" Then
            sSQL = sSQL & " AND ad.JurisdictionId IN (" & sIn & ")"
        End If

        If bSavings Then
        ElseIf bReport Then
            sSQL = sSQL & " ORDER BY l.TaxYear desc, c.Name, l.StateCd, asr.Name, collect.Name, l.City, l.Address, l.ClientLocationId, asmt.AcctNum, j.Name"
        ElseIf bJurisdictionList Then
            sSQL = sSQL & " ORDER BY l.TaxYear desc, c.Name, l.Address, l.ClientLocationId, l.City, l.StateCd, asmt.AcctNum, j.Name"
        ElseIf bTotalByCollectorList Then
            sSQL = sSQL & " ) AS t"
            sSQL = sSQL & " GROUP BY TaxYear, Clients_Name, ClientId, LocationId, Locations_Address, Locations_ClientLocationId, Locations_Name," &
                " Locations_City, Locations_StateCd, Locations_Zip, AcctNum, BusinessUnits_Name," &
                " AssessmentId, Assessors_Name, Collectors_Name, Payee, AssessorId, CollectorId, Collectors_DueDate, Collectors_DiscountFl," &
                " Collectors_DiscountDate," &
                " Collectors_DiscountDate2, Collectors_DiscountDate3, Collectors_DiscountDate4," &
                " Collectors_StateCd, Collectors_PayeeStateCd, Collectors_Address1, Collectors_Address2, Collectors_City, Collectors_Zip, Collectors_Phone," &
                " Consultants_ConsultantName, Consultants_EMail, Consultants_Phone, Consultants_FullName, TaxBillNotes,TaxBillAcctNum," &
                " TaxBillLoaded"
            sSQL = sSQL & " ORDER BY TaxYear desc, Clients_Name, Locations_Address, Locations_ClientLocationId, Locations_City, Locations_StateCd, AcctNum, Collectors_Name"
        Else
            sSQL = sSQL & " ORDER BY l.TaxYear desc, collect.Name,j.Name"
        End If

        Return sSQL


    End Function

    Public Function SetTaxBillPrintedDate(ByVal lClientId As Long, ByVal lLocationId As Long, _
            ByVal lAssessmentId As Long, ByVal JurisdictionList As List(Of Long), ByVal iTaxYear As Integer, ByVal eType As enumTable) As Boolean

        Try
            Dim sIn As String = ""
            If JurisdictionList Is Nothing Then JurisdictionList = New List(Of Long)
            For Each lJurisdictionId As Long In JurisdictionList
                If sIn <> "" Then sIn = sIn & ","
                sIn = sIn & lJurisdictionId
            Next

            Dim sSQL As String = "UPDATE AssessmentDetail" & IIf(eType = enumTable.enumLocationBPP, "BPP", "RE") &
                " SET TaxBillPrintedDate = GETDATE(), TaxBillPrintedUser = " & QuoStr(AppData.UserId) &
                " WHERE ClientId = " & lClientId & " AND LocationId = " & lLocationId &
                " AND AssessmentId = " & lAssessmentId & " AND TaxYear = " & iTaxYear
            If sIn <> "" Then
                sSQL = sSQL & " AND JurisdictionId IN (" & sIn & ")"
            End If
            ExecuteSQL(sSQL)

            Return True
        Catch ex As Exception
            MsgBox("Error setting Tax Bill Printed Date:  " & ex.Message)
            Return False
        End Try

    End Function
    Public Function AddInstallment(ByVal ePropType As enumTable, ByVal lClientId As Long, ByVal lLocationId As Long, ByVal lAssessmentId As Long, _
            ByVal lCollectorId As Long, ByVal iTaxYear As Integer, _
            ByVal sPayFromDate As String, ByVal sPayToDate As String, ByVal dPayAmt As Double, ByRef sError As String) As Boolean

        Try
            sError = ""
            Dim sSQL As String = "INSERT Installments" & IIf(ePropType = enumTable.enumLocationBPP, "BPP", "RE") & _
                " (ClientId, LocationId, AssessmentId, CollectorId, TaxYear, PayFromDt, PayToDt, PayAmt, AddUser)" & _
                " SELECT " & lClientId & "," & lLocationId & "," & lAssessmentId & "," & lCollectorId & "," & _
                iTaxYear & "," & QuoStr(sPayFromDate) & "," & QuoStr(sPayToDate) & "," & dPayAmt & "," & QuoStr(AppData.UserId)
            ExecuteSQL(sSQL)
            Return True
        Catch ex As Exception
            sError = ex.Message
            Return False
        End Try

    End Function

End Module
