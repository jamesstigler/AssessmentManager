Module modRendition
    Public Structure structAsset
        Friend lClientId As Long
        Friend lLocationId As Long
        Friend lAssessmentId As Long
        Friend iTaxYear As Integer
        Friend sAssetId As String
        Friend sGLCode As String
        Friend sPurchaseDate As String
        Friend sDescription As String
        Friend lOriginalCost As Long
        Friend sVIN As String
        Friend sLocationAddress As String
        Friend dAllocationPct As Double
        Friend sLeaseType As String
        Friend sLessorName As String
        Friend sLessorAddress As String
        Friend iLeaseTerm As Integer
        Friend sEquipmentMake As String
        Friend sEquipmentModel As String
        Friend sStatus As String
        Friend iErrorType As Integer
    End Structure
    Public Enum enumAllocationPctType
        eServiceLevel
        eInterstate
    End Enum


    ''' <summary>
    ''' Function uses stored procedure, spGetAssetList, which is basis for anything related to renditions
    ''' </summary>
    ''' <param name="lClientId"></param>
    ''' <param name="lLocationId"></param>
    ''' <param name="lAssessmentId"></param>
    ''' <param name="iTaxYear"></param>
    ''' <param name="lFactoringEntityId"></param>
    ''' <param name="bNeedFactoredAmounts"></param>
    ''' <param name="bNeedFactoringEntityNames"></param>
    ''' <param name="bNeedTotalValues"></param>
    ''' <param name="bNeedTotalOriginalCost"></param>
    ''' <param name="bNeedDetail"></param>
    ''' <param name="bAccrual"></param>
    ''' <returns>Dataset with multiple tables</returns>
    Public Function GetAssetList(ByVal lClientId As Long, ByVal lLocationId As Long, ByVal lAssessmentId As Long, ByVal iTaxYear As Integer, ByVal lFactoringEntityId As Long,
            ByVal bNeedFactoredAmounts As Boolean, ByVal bNeedFactoringEntityNames As Boolean, ByVal bNeedTotalValues As Boolean, ByVal bNeedTotalOriginalCost As Boolean, ByVal bNeedDetail As Boolean, ByVal bAccrual As Boolean) As DataSet
        Return cData.GetAssetList(lClientId, lLocationId, lAssessmentId, iTaxYear, lFactoringEntityId, bNeedFactoredAmounts, bNeedFactoringEntityNames, bNeedTotalValues, bNeedTotalOriginalCost, bNeedDetail, bAccrual)
    End Function

    ''' <summary>
    ''' Function returns SQL to query assets.  Use only for the reconciliation reports.  All other asset listings/renditions must use GetAssetList
    ''' </summary>
    ''' <param name="lClientId"></param>
    ''' <param name="lLocationId"></param>
    ''' <param name="lAssessmentId"></param>
    ''' <param name="bNeedFactoredAmounts"></param>
    ''' <param name="bAccrual"></param>
    ''' <param name="lFactorEntityId"></param>
    ''' <param name="iTaxYear"></param>
    ''' <param name="sFactoringEntityNames"></param>
    ''' <returns>SQL string</returns>
    Public Function BuildAssetListQuery(ByVal lClientId As Long, ByVal lLocationId As Long,
            ByVal lAssessmentId As Long, ByVal bNeedFactoredAmounts As Boolean, ByVal bAccrual As Boolean,
            ByVal lFactorEntityId As Long, ByVal iTaxYear As Integer, ByRef sFactoringEntityNames() As String) As String
        Dim i As Integer, sSQL As String = "", dtList As New DataTable
        Dim bShowVIN As Boolean = False, bShowAddress As Boolean = False, bShowAllocationPct As Boolean = False
        Dim row As DataRow, lFactoringEntityId(4) As Long, iNumberOfFactoringEntities As Integer = 0
        Dim bPreInterstate As Boolean = False

        If bAccrual Then
            iNumberOfFactoringEntities = 1          'accrual always uses 1st entity (FactorEntityId1)
        Else
            iNumberOfFactoringEntities = 5
        End If

        If Not bAccrual Then
            sSQL = "SELECT (SELECT 1 WHERE EXISTS(SELECT ClientId FROM Assets WHERE ClientId = " & lClientId &
                " AND LocationId = " & lLocationId &
                " AND AssessmentId = " & lAssessmentId &
                " AND TaxYear = " & iTaxYear &
                " AND ISNULL(VIN,'') <> '')) AS VINExists," &
                " (SELECT 1 WHERE EXISTS(SELECT ClientId FROM Assets WHERE ClientId = " & lClientId &
                " AND LocationId = " & lLocationId &
                " AND AssessmentId = " & lAssessmentId &
                " AND TaxYear = " & iTaxYear &
                " AND ISNULL(LocationAddress,'') <> '')) AS AddressExists," &
                " (SELECT 1 WHERE EXISTS(SELECT ClientId FROM AssetAllocationPct WHERE ClientId = " & lClientId &
                " AND LocationId = " & lLocationId &
                " AND AssessmentId = " & lAssessmentId &
                " AND TaxYear = " & iTaxYear &
                " AND (ISNULL(AllocationPct,0) <> 0 OR ISNULL(InterstateAllocationPct,0) <> 0)" &
                " )) AS AllocationPctExists"

            If GetData(sSQL, dtList) > 0 Then
                row = dtList.Rows(0)
                If Not IsDBNull(row("VINExists")) Then
                    If row("VINExists") = 1 Then bShowVIN = True Else bShowVIN = False
                End If
                If Not IsDBNull(row("AddressExists")) Then
                    If row("AddressExists") = 1 Then bShowAddress = True Else bShowAddress = False
                End If
                If Not IsDBNull(row("AllocationPctExists")) Then
                    If row("AllocationPctExists") = 1 Then bShowAllocationPct = True Else bShowAllocationPct = False
                End If
            End If
        End If

        sSQL = ""
        ReDim sFactoringEntityNames(4)
        For i = 1 To iNumberOfFactoringEntities
            If sSQL <> "" Then sSQL = sSQL & " UNION "
            sSQL = sSQL & "SELECT " & i & " AS Counter, (fe.Name + ', ' + fe.StateCd) as Name," &
                " ISNULL(a.FactorEntityId" & i & ",0) AS FactorEntityId FROM AssessmentsBPP a" &
                " LEFT OUTER JOIN FactorEntities fe" &
                " ON a.FactorEntityId" & i & " = fe.FactorEntityId WHERE TaxYear = " & iTaxYear
            If lClientId > 0 And lLocationId > 0 And lAssessmentId > 0 Then
                sSQL = sSQL & " AND a.ClientId = " & lClientId & " AND a.LocationId = " & lLocationId &
                    " AND a.AssessmentId = " & lAssessmentId
            End If
        Next
        sSQL = sSQL & " ORDER BY Counter"
        GetData(sSQL, dtList)
        Dim EntityIds As DataRow()
        If lFactorEntityId > 0 Then
            EntityIds = dtList.Select("FactorEntityId = " & lFactorEntityId)
        Else
            EntityIds = dtList.Select
        End If
        For Each row In EntityIds
            sFactoringEntityNames(row("Counter") - 1) = UnNullToString(row("Name"))
            lFactoringEntityId(row("Counter") - 1) = row("FactorEntityId")
        Next

        sSQL = "SELECT tblA.ClientId,tblA.LocationId,tblA.AssessmentId,tblA.TaxYear,tblA.AssetId,tblA.OriginalCost," &
            " tblA.PurchaseDate, RTRIM(tblA.Description) AS Description," &
            " RTRIM(tblA.GLCode) AS GLCode,RTRIM(tblA.Clients_Name) AS Clients_Name, LTRIM(RTRIM(tblA.LegalOwner)) AS LegalOwner," &
            " RTRIM(tblA.Locations_Address) AS Locations_Address,RTRIM(tblA.Locations_City) AS Locations_City," &
            " tblA.ClientRenditionValue, tblA.BPPRatio," &
            " tblA.Locations_StateCd, tblA.Locations_ClientLocationId, RTRIM(tblA.Assessments_AcctNum) AS Assessments_AcctNum," &
            " ISNULL(tblA.Clients_ExcludeNotified,0) AS Clients_ExcludeNotified," &
            " ISNULL(tblA.Clients_ExcludeAbatements,0) AS Clients_ExcludeAbatements," &
            " ISNULL(tblA.Clients_ExcludeFreeport,0) AS Clients_ExcludeFreeport," &
            " ISNULL(tblA.Clients_ExcludeClient,0) AS Clients_ExcludeClient," &
            " ISNULL(tblA.Assessments_SavingsExclusionCd,0) AS Assessments_SavingsExclusionCd," &
            " RTRIM(tblA.Assessors_Name) AS Assessors_Name, tblA.BusinessUnitId"
        If bShowAddress Then
            sSQL = sSQL & ", tblA.LocationAddress"
        End If
        If bShowVIN Then
            sSQL = sSQL & ", tblA.VIN"
        End If
        For i = 1 To iNumberOfFactoringEntities
            If sFactoringEntityNames(i - 1) <> "" Then
                sSQL = sSQL & "," & QuoStr(sFactoringEntityNames(i - 1)) & " AS FactoringEntityName" & i &
                    ",tblA.FactorEntityId" & i &
                    " ,ISNULL(tbl" & i & ".FactorCode,'') AS MappedFactorCode" & i &
                    " ,ISNULL(tbl" & i & "CO.FactorCode,'') AS ClientFactorCodeOverride" & i &
                    " ,ISNULL(tbl" & i & "CO.Description,'') AS ClientFactorCodeOverrides_Description" & i &
                    " ,ISNULL(tbl" & i & "CO.FactorCode,ISNULL(tbl" & i & ".FactorCode,'')) AS FactorCode" & i &
                    " ,ISNULL(tbl" & i & "CO.Description,ISNULL(tbl" & i & ".FactorEntityCodes_Description,'')) AS FactorEntityCodes_Description" & i
                If bShowAllocationPct Then
                    sSQL = sSQL & " ,ISNULL(tbl" & i & "aap.AllocationPct,1) AS AllocationPct" & i
                    sSQL = sSQL & " ,ISNULL(tbl" & i & "aap.InterstateAllocationPct,1) AS InterstateAllocationPct" & i
                End If
            End If

            'override factors
            If sFactoringEntityNames(i - 1) <> "" Then
                sSQL = sSQL & " ,ISNULL(tbl" & i & "O.FactorCode,'') AS FactorCodeOverride" & i &
                    " ,ISNULL(tbl" & i & "O.Description,'') AS FactorEntityCodesOverride_Description" & i
            End If

            '2 subqueries, 1st to find matching age, 2nd if no match
            If bNeedFactoredAmounts Then
                If sFactoringEntityNames(i - 1) <> "" Then
                    'if have interstate allocation then get Pre-Interstate amounts
                    'first time through gets pre interstate amounts, 2nd time normal factored amounts
                    bPreInterstate = True
                    Do                        'Entity factored amount 
                        If bPreInterstate And bShowAllocationPct Then
                            sSQL = sSQL & ",PreInterstateFactoredAmount" & i & " = "
                        Else
                            sSQL = sSQL & ",FactoredAmount" & i & " = "
                        End If
                        'accruals assume inventory at 100% of cost
                        If bAccrual Then
                            sSQL = sSQL & " CASE " &
                                " WHEN tblA.GLCode IN('INV','Inventory') OR tblA.AssetId IN('INV','Inventory')" &
                                " OR tblA.Description IN('INV','Inventory')" &
                                " THEN tbla.OriginalCost ELSE"
                        End If
                        sSQL = sSQL & " ROUND(ISNULL(ISNULL((SELECT Percentage FROM Factors AS f" &
                            " WHERE f.FactorEntityId = " & lFactoringEntityId(i - 1) &
                            " AND f.FactorCode = ISNULL(tbl" & i & "CO.FactorCode,tbl" & i & ".FactorCode)" &
                            " AND f.TaxYear = " & iTaxYear & " AND f.Age = " & iTaxYear & " - YEAR(tblA.PurchaseDate))," &
                            " (SELECT Percentage FROM Factors AS f" &
                            " WHERE f.FactorEntityId = " & lFactoringEntityId(i - 1) &
                            " AND f.FactorCode = ISNULL(tbl" & i & "CO.FactorCode,tbl" & i & ".FactorCode)" &
                            " AND f.TaxYear = " & iTaxYear &
                            " AND f.Age = 99)), 0) * ISNULL(tblA.OriginalCost, 0)"
                        If bShowAllocationPct Then
                            If bPreInterstate = False Then
                                sSQL = sSQL & " * ISNULL(tbl" & i & "aap.InterstateAllocationPct,1)"
                            End If
                            sSQL = sSQL & " * ISNULL(tbl" & i & "aap.AllocationPct,1)"
                        Else
                            sSQL = sSQL & "*1*1"
                        End If
                        sSQL = sSQL & ",0)"

                        If bAccrual Then sSQL = sSQL & " END "

                        'override entity factored amount
                        sSQL = sSQL & ",ROUND(ISNULL(ISNULL((SELECT Percentage FROM Factors AS f" &
                            " WHERE f.FactorEntityId = " & lFactoringEntityId(i - 1) & " AND f.FactorCode = tbl" & i & "O.FactorCode" &
                            " AND f.TaxYear = " & iTaxYear & " AND f.Age = " & iTaxYear & " - YEAR(tblA.PurchaseDate))," &
                            " (SELECT Percentage FROM Factors AS f" &
                            " WHERE f.FactorEntityId = " & lFactoringEntityId(i - 1) & " AND f.FactorCode = tbl" & i & "O.FactorCode" &
                            " AND f.TaxYear = " & iTaxYear &
                            " AND f.Age = 99)), 0) * ISNULL(tblA.OriginalCost, 0) * "
                        If bShowAllocationPct Then
                            If bPreInterstate = False Then sSQL = sSQL & "ISNULL(tbl" & i & "aap.InterstateAllocationPct,1) * "
                            sSQL = sSQL & "ISNULL(tbl" & i & "aap.AllocationPct,1)"
                        Else
                            sSQL = sSQL & "1*1"
                        End If
                        sSQL = sSQL & " , 0 ) AS "
                        If bPreInterstate And bShowAllocationPct Then
                            sSQL = sSQL & " PreInterstateFactoredAmountOverride" & i
                        Else
                            sSQL = sSQL & " FactoredAmountOverride" & i
                        End If
                        If bShowAllocationPct Then
                            If bPreInterstate = False Then Exit Do
                            If bPreInterstate = True Then bPreInterstate = False
                        Else
                            Exit Do
                        End If
                    Loop

                    'Entity factor percentage
                    sSQL = sSQL & ",CONVERT(float, ISNULL(ISNULL((SELECT Percentage FROM Factors AS f" &
                        " WHERE f.FactorEntityId = " & lFactoringEntityId(i - 1) &
                        " AND f.FactorCode = ISNULL(tbl" & i & "CO.FactorCode,tbl" & i & ".FactorCode)" &
                        " AND f.TaxYear = " & iTaxYear & " AND f.Age = " & iTaxYear & " - YEAR(tblA.PurchaseDate))," &
                        " (SELECT Percentage FROM Factors AS f" &
                        " WHERE f.FactorEntityId = " & lFactoringEntityId(i - 1) &
                        " AND f.FactorCode = ISNULL(tbl" & i & "CO.FactorCode,tbl" & i & ".FactorCode)" &
                        " AND f.TaxYear = " & iTaxYear & " AND f.Age = 99)), 0)) AS Factor" & i

                    'Override entity factor percentage
                    sSQL = sSQL & ",CONVERT(float, ISNULL(ISNULL((SELECT Percentage FROM Factors AS f" &
                        " WHERE f.FactorEntityId = " & lFactoringEntityId(i - 1) & " AND f.FactorCode = tbl" & i & "O.FactorCode" &
                        " AND f.TaxYear = " & iTaxYear & " AND f.Age = " & iTaxYear & " - YEAR(tblA.PurchaseDate))," &
                        " (SELECT Percentage FROM Factors AS f" &
                        " WHERE f.FactorEntityId = " & lFactoringEntityId(i - 1) & " AND f.FactorCode = tbl" & i & "O.FactorCode" &
                        " AND f.TaxYear = " & iTaxYear & " AND f.Age = 99)), 0)) AS FactorOverride" & i
                End If
            End If
        Next

        sSQL = sSQL & " FROM " &
            " (SELECT c.ClientId, l.LocationId, assess.AssessmentId, a.AssetId, a.TaxYear, ISNULL(a.OriginalCost,0) AS OriginalCost," &
            " a.PurchaseDate, a.Description,a.GLCode," &
            " l.StateCd, assess.FactorEntityId1, assess.FactorEntityId2," &
            " assess.FactorEntityId3, assess.FactorEntityId4, assess.FactorEntityId5," &
            " c.Name AS Clients_Name,ISNULL(l.LegalOwner,c.Name) AS LegalOwner, l.Address AS Locations_Address,l.City as Locations_City,l.StateCd as Locations_StateCd," &
            " ISNULL(l.ClientLocationId,'') AS Locations_ClientLocationId, assessor.Name as Assessors_Name," &
            " assess.AcctNum AS Assessments_AcctNum," &
            " ISNULL(c.ExcludeNotified,0) AS Clients_ExcludeNotified," &
            " ISNULL(c.ExcludeAbatements,0) AS Clients_ExcludeAbatements," &
            " ISNULL(c.ExcludeFreeport,0) AS Clients_ExcludeFreeport," &
            " ISNULL(c.ExcludeClient,0) AS Clients_ExcludeClient," &
            " ISNULL(assess.SavingsExclusionCd,0) AS Assessments_SavingsExclusionCd," &
            " a.VIN, a.LocationAddress,assess.ClientRenditionValue,ISNULL(assessor.BPPRatio,0) AS BPPRatio,ISNULL(assess.BusinessUnitId,0) AS BusinessUnitId" &
            " FROM AssessmentsBPP AS assess" &
            " INNER JOIN Clients AS c ON assess.ClientId = c.ClientId" &
            " INNER JOIN LocationsBPP AS l ON assess.ClientId = l.ClientId" &
            " AND assess.LocationId = l.LocationId AND assess.TaxYear = l.TaxYear" &
            " LEFT OUTER JOIN Assessors AS assessor on assess.AssessorId = assessor.AssessorId" &
            " and assess.TaxYear = assessor.TaxYear" &
            " LEFT OUTER JOIN Assets AS a ON assess.ClientId = a.ClientId" &
            " AND assess.LocationId = a.LocationId" &
            " AND assess.AssessmentId = a.AssessmentId" &
            " AND assess.TaxYear = a.TaxYear" &
            " where assess.TaxYear = " & iTaxYear
        If lAssessmentId > 0 Then
            sSQL = sSQL & " AND assess.ClientId = " & lClientId & " AND assess.LocationId = " & lLocationId &
                " AND assess.AssessmentId = " & lAssessmentId
        End If
        sSQL = sSQL & ") tblA"

        For i = 1 To iNumberOfFactoringEntities
            'cross ref between client gl code and factoring entity factor code
            If sFactoringEntityNames(i - 1) <> "" Then

                'client factor/factoring entity cross reference
                sSQL = sSQL & " LEFT OUTER JOIN (SELECT cx.ClientId, cx.StateCd, cx.GLCode, cx.TaxYear," &
                    " cx.FactorEntityId, cx.FactorCode,ISNULL(fec.Description,cx.FactorCode) AS FactorEntityCodes_Description" &
                    " FROM ClientGLCodeXRef AS cx INNER JOIN FactorEntityCodes AS fec ON cx.FactorEntityId = fec.FactorEntityId" &
                    " AND cx.FactorCode = fec.FactorCode AND cx.TaxYear = fec.TaxYear" &
                    " WHERE cx.TaxYear = " & iTaxYear &
                    " AND cx.ClientId = " & lClientId & " AND cx.FactorEntityId = " & lFactoringEntityId(i - 1) &
                    " ) tbl" & i
                sSQL = sSQL & " ON tblA.ClientId = tbl" & i & ".ClientId" &
                    " AND tblA.StateCd = tbl" & i & ".StateCd" &
                    " AND tblA.GLCode = tbl" & i & ".GLCode" &
                    " AND tblA.TaxYear = tbl" & i & ".TaxYear" &
                    " AND tblA.FactorEntityId" & i & " = tbl" & i & ".FactorEntityId"

                'override tables for factoring entity
                sSQL = sSQL & " LEFT OUTER JOIN (SELECT fec.FactorCode,isnull(fec.Description,fec.FactorCode) AS Description," &
                    " fco.ClientId, fco.LocationId, fco.AssessmentId, fco.AssetId, fco.FactorEntityId,fec.TaxYear" &
                    " FROM FactorCodeOverrides AS fco INNER JOIN" &
                    " FactorEntityCodes AS fec ON fco.FactorEntityId = fec.FactorEntityId" &
                    " AND fco.FactorCode = fec.FactorCode AND fco.TaxYear = fec.TaxYear" &
                    " WHERE fco.TaxYear = " & iTaxYear &
                    " AND fco.ClientId = " & lClientId & " AND fco.FactorEntityId = " & lFactoringEntityId(i - 1) &
                    " AND fco.LocationId =  " & lLocationId & " AND fco.AssessmentId =  " & lAssessmentId &
                    " ) tbl" & i & "O"
                sSQL = sSQL & " ON tblA.ClientId = tbl" & i & "O.ClientId" &
                    " AND tblA.LocationId = tbl" & i & "O.LocationId" &
                    " AND tblA.AssessmentId = tbl" & i & "O.AssessmentId" &
                    " AND tblA.AssetId = tbl" & i & "O.AssetId" &
                    " AND tblA.TaxYear = tbl" & i & "O.TaxYear" &
                    " AND tblA.FactorEntityId" & i & " = " & "tbl" & i & "O.FactorEntityId"

                'client factor override
                sSQL = sSQL & " LEFT OUTER JOIN (SELECT cfc.AssetId, cfc.FactorCode," &
                    " ISNULL(fec.Description,fec.FactorCode) AS Description" &
                    " FROM FactorEntityCodes AS fec INNER JOIN" &
                    " ClientFactorCodeOverrides AS cfc" &
                    " ON fec.FactorEntityId = cfc.FactorEntityId AND fec.FactorCode = cfc.FactorCode" &
                    " AND fec.TaxYear = cfc.TaxYear" &
                    " WHERE cfc.ClientId = " & lClientId & " AND cfc.FactorEntityId = " & lFactoringEntityId(i - 1) &
                    " AND cfc.LocationId =  " & lLocationId & " AND cfc.AssessmentId =  " & lAssessmentId &
                    " AND cfc.TaxYear = " & iTaxYear &
                    " ) AS tbl" & i & "CO" &
                    " ON tblA.AssetId = tbl" & i & "CO.AssetId"

                If bShowAllocationPct Then
                    'asset allocation
                    sSQL = sSQL & " LEFT OUTER JOIN (SELECT aap.AllocationPct, ISNULL(aap.InterstateAllocationPct,1) AS InterstateAllocationPct," &
                        " aap.AssetId, aap.FactorEntityId, aap.ClientId, aap.LocationId, aap.AssessmentId, aap.TaxYear" &
                        " FROM AssetAllocationPct aap" &
                        " WHERE aap.TaxYear = " & iTaxYear & " And aap.ClientId = " & lClientId & " And aap.FactorEntityId = " & lFactoringEntityId(i - 1) &
                        " AND aap.LocationId =  " & lLocationId & " AND aap.AssessmentId = " & lAssessmentId & ") tbl" & i & "aap" &
                        " ON tblA.ClientId = tbl" & i & "aap.ClientId AND tblA.LocationId = tbl" & i & "aap.LocationId AND tblA.AssessmentId = tbl" & i & "aap.AssessmentId" &
                        " AND tblA.AssetId = tbl" & i & "aap.AssetId AND tblA.TaxYear = tbl" & i & "aap.TaxYear" &
                        " AND tblA.FactorEntityId" & i & " = tbl" & i & "aap.FactorEntityId"
                End If

            End If

        Next

        Return sSQL

    End Function

    Public Function CreateAsset(ByVal Asset As structAsset, ByVal bHitDB As Boolean, ByRef sError As String) As Boolean
        Dim sSQL As String, dt As New DataTable

        Try
            Dim sAssetId As String = UCase(Trim(Asset.sAssetId))
            Dim sGLCode As String = UCase(Trim(Asset.sGLCode))
            Dim sDate As String = Trim(Asset.sPurchaseDate)
            Dim sDescription As String = Left(Trim(Asset.sDescription), 255)
            Dim sVIN As String = UCase(Trim(Asset.sVIN))
            Dim sAddress As String = Trim(Asset.sLocationAddress)
            Dim sLeaseType = Trim(Asset.sLeaseType)
            Dim sLessorName = Trim(Asset.sLessorName)
            Dim sLessorAddress = Trim(Asset.sLessorAddress)
            Dim iLeaseTerm = Asset.iLeaseTerm
            Dim sEquipmentMake = Trim(Asset.sEquipmentMake)
            Dim sEquipmentModel = Trim(Asset.sEquipmentModel)

            If Asset.lClientId = 0 Or Asset.lLocationId = 0 Or Asset.lAssessmentId = 0 Or Asset.iTaxYear = 0 Or sAssetId = "" Or sGLCode = "" Or Not IsDate(sDate) Then
                sError = "Asset info missing"
                Return False
            End If
            sError = ""
            sSQL = "select AddDate, AddUser from Assets where ClientId = " & Asset.lClientId &
                " AND LocationId = " & Asset.lLocationId &
                " AND AssessmentId = " & Asset.lAssessmentId &
                " AND TaxYear = " & Asset.iTaxYear &
                " AND AssetId = " & QuoStr(sAssetId)
            If GetData(sSQL, dt) > 0 Then
                sError = "Asset exists, created on " & Format(dt.Rows(0).Item("AddDate"), csDateTime) & " by " & UnNullToString(dt.Rows(0).Item("AddUser"))
                Return False
            End If
            If bHitDB Then
                Dim sql As StringBuilder = New StringBuilder()
                sql.Append("INSERT Assets (ClientId,LocationId,AssessmentId,TaxYear,AssetId,OriginalCost,PurchaseDate,GLCode")
                If sDescription <> "" Then sql.Append(",Description")
                If sVIN <> "" Then sql.Append(",VIN")
                If sAddress <> "" Then sql.Append(",LocationAddress")
                If sLeaseType <> "" Then sql.Append(",LeaseType")
                If sLessorName <> "" Then sql.Append(",LessorName")
                If sLessorAddress <> "" Then sql.Append(",LessorAddress")
                If iLeaseTerm <> 0 Then sql.Append(",LeaseTerm")
                If sEquipmentMake <> "" Then sql.Append(",EquipmentMake")
                If sEquipmentModel <> "" Then sql.Append(",EquipmentModel")
                sql.Append(",AddUser)")
                sql.Append(" SELECT ").Append(Asset.lClientId).Append(",").Append(Asset.lLocationId).Append(",").Append(Asset.lAssessmentId).Append(",")
                sql.Append(Asset.iTaxYear).Append(",").Append(QuoStr(sAssetId)).Append(",").Append(Asset.lOriginalCost).Append(",")
                sql.Append(QuoStr(sDate)).Append(",").Append(QuoStr(sGLCode))
                If sDescription <> "" Then sql.Append(",").Append(QuoStr(sDescription))
                If sVIN <> "" Then sql.Append(",").Append(QuoStr(sVIN))
                If sAddress <> "" Then sql.Append(",").Append(QuoStr(sAddress))
                If sLeaseType <> "" Then sql.Append(",").Append(QuoStr(sLeaseType))
                If sLessorName <> "" Then sql.Append(", ").Append(QuoStr(sLessorName))
                If sLessorAddress <> "" Then sql.Append(",").Append(QuoStr(sLessorAddress))
                If iLeaseTerm <> 0 Then sql.Append(",").Append(iLeaseTerm)
                If sEquipmentMake <> "" Then sql.Append(",").Append(QuoStr(sEquipmentMake))
                If sEquipmentModel <> "" Then sql.Append(", ").Append(QuoStr(sEquipmentModel))
                sql.Append(",").Append(QuoStr(AppData.UserId))

                If ExecuteSQL(sql.ToString) = 1 Then
                    sSQL = "insert ClientGLCodes (ClientId,StateCd,GLCode,TaxYear,AddUser)" &
                        " SELECT l.ClientId, l.StateCd," & QuoStr(sGLCode) & "," &
                        Asset.iTaxYear & "," & QuoStr(AppData.UserId) &
                        " FROM LocationsBPP l WHERE" &
                        " l.ClientId = " & Asset.lClientId & " And l.LocationId = " & Asset.lLocationId &
                        " And l.TaxYear = " & Asset.iTaxYear &
                        " And Not EXISTS" &
                        " (Select ClientId from ClientGLCodes where ClientId = l.ClientId And StateCd = " &
                        " l.StateCd And GLCode = " & QuoStr(sGLCode) & " And TaxYear = l.TaxYear)"
                    ExecuteSQL(sSQL)
                    Return True
                End If
            Else
                Return True
            End If
        Catch ex As Exception
            sError = ex.Message
            Return False
        End Try

    End Function
    Public Function BuildRenditionValueComparisonQuery(lClientId As Long, iTaxYear As Integer, ePropType As enumTable, lBusinessUnitId As Long, sStateCd As String, lAssessorId As Long) As String
        Dim sql As New StringBuilder(), stemptable As String, lrows As Long, sinsert As New StringBuilder
        Dim dtaccounts As New DataTable, dtvalues As New DataTable, countyval As Long = 0, marketval As Long = 0
        Dim progresscounter As Long = 0, rowsinresults As Long = 0, resetcounter As Integer = 0

        Do
            stemptable = "#tmpRenditionValueComparison" & AppData.UserId & Date.Now.Ticks.ToString
            'stemptable = "tempdb..tmpRenditionValueComparison" & AppData.UserId & Date.Now.Ticks.ToString
            sql.Clear()
            sql.Append("Select 1 WHERE EXISTS (Select Name FROM sys.objects where name Like '%" & stemptable & "%')")
            lrows = GetData(sql.ToString, New DataTable)
            If lrows = 0 Then Exit Do
        Loop
        sql.Clear()
        sql.Append("CREATE TABLE ").Append(stemptable).Append(" ( ")
        sql.Append("[Clients_Name] [varchar](255) NULL,")
        sql.Append("[Locations_Address] [varchar](50) NULL,")
        sql.Append("[Locations_City] [varchar](50) NULL,")
        sql.Append("[Locations_StateCd] [Char](2) NULL,")
        sql.Append("[Locations_ClientLocationId] [varchar](255) NULL,")
        sql.Append("[Assessments_AcctNum] [varchar](50) NULL,")
        sql.Append("[Assessors_Name] [varchar](255) NULL,")
        sql.Append("[BusinessUnits_Name] [varchar](255) NULL,")
        sql.Append("[ClientId] [bigint] NULL,")
        sql.Append("[LocationId] [bigint] NULL,")
        sql.Append("[AssessmentId] [bigint] NULL,")
        sql.Append("[TaxYear] [smallint] NULL,")
        sql.Append("[CountyReclassValue] [float] NULL,")
        sql.Append("[MarketReclassValue] [float] NULL,")
        sql.Append("[PriorYearFinalValue] [float] NULL,")
        sql.Append("[CurrentYearAssessedValue] [float] NULL,")
        sql.Append("[PropType] varchar(1) NULL,")
        sql.Append("[BusinessUnitId] [bigint] NULL,")
        sql.Append("[AssessorId] [bigint] NULL")
        sql.Append(")")
        ExecuteSQL(sql.ToString)

        sinsert.Clear()
        sinsert.Append(" INSERT ").Append(stemptable).Append(" (Clients_Name, Locations_Address, Locations_City, Locations_StateCd, Locations_ClientLocationId,")
        sinsert.Append(" Assessments_AcctNum, Assessors_Name, BusinessUnits_Name, ClientId, LocationId, AssessmentId, TaxYear,")
        sinsert.Append(" CountyReclassValue, MarketReclassValue, PriorYearFinalValue, CurrentYearAssessedValue, PropType, BusinessUnitId, AssessorId)")

        sql.Clear()
        If ePropType = enumTable.enumLocationBPP Or ePropType = enumTable.enumUnknown Then
            sql.Append(" SELECT c.Name AS Clients_Name, ISNULL(l.Address, '') AS Locations_Address, ISNULL(l.City, '') AS Locations_City, l.StateCd AS Locations_StateCd,")
            sql.Append(" LTRIM(RTRIM(ISNULL(l.ClientLocationId,''))) AS Locations_ClientLocationId, ISNULL(a.AcctNum, '') AS Assessments_AcctNum, ISNULL(assessor.Name, '') AS Assessors_Name,")
            sql.Append(" ISNULL(bu.Name, '') AS BusinessUnits_Name, a.ClientId, a.LocationId, a.AssessmentId, l.TaxYear, 0, 0,")
            sql.Append(" MAX(ISNULL(ad.FinalValue, 0)) AS PriorYearFinalValue, 0 AS CurrentYearAssessedValue, 'P'")
            sql.Append(" , a.BusinessUnitId, a.AssessorId")
            sql.Append(" FROM Clients AS c")
            sql.Append(" INNER JOIN LocationsBPP AS l ON c.ClientId = l.ClientId")
            sql.Append(" INNER JOIN AssessmentsBPP AS a ON l.ClientId = a.ClientId And l.LocationId = a.LocationId And l.TaxYear = a.TaxYear")
            sql.Append(" RIGHT OUTER JOIN AssessmentDetailBPP AS ad ON ad.ClientId = a.ClientId AND ad.LocationId = a.LocationId AND ad.AssessmentId = a.AssessmentId")
            sql.Append(" AND ad.TaxYear = a.TaxYear - 1")
            sql.Append(" LEFT OUTER JOIN BusinessUnits AS bu ON a.ClientId = bu.ClientId AND a.BusinessUnitId = bu.BusinessUnitId")
            sql.Append(" LEFT OUTER JOIN Assessors AS assessor ON a.AssessorId = assessor.AssessorId AND a.TaxYear = assessor.TaxYear")
            If AppData.IncludeInactive = False Then
                sql.Append(" WHERE ISNULL(c.InactiveFl, 0) = 0 AND ISNULL(l.InactiveFl,0) = 0 AND ISNULL(a.InactiveFl,0) = 0")
            End If
            sql.Append(" GROUP BY c.Name, ISNULL(l.Address, ''), ISNULL(l.City, ''), l.StateCd, LTRIM(RTRIM(ISNULL(l.ClientLocationId, ''))), ISNULL(a.AcctNum, ''), ISNULL(assessor.Name, ''), ISNULL(bu.Name, ''),")
            sql.Append(" a.ClientId, a.LocationId, a.AssessmentId, l.TaxYear, a.BusinessUnitId, a.AssessorId")
            sql.Append(" HAVING l.TaxYear = ").Append(iTaxYear).Append(" AND a.ClientId = ").Append(lClientId)
            If lBusinessUnitId > 0 Then sql.Append(" AND a.BusinessUnitId = ").Append(lBusinessUnitId)
            If lAssessorId > 0 Then sql.Append(" AND a.AssessorId = ").Append(lAssessorId)
            If sStateCd <> "" Then sql.Append(" AND l.StateCd = '").Append(sStateCd).Append("'")
        End If
        If ePropType = enumTable.enumLocationRE Or ePropType = enumTable.enumUnknown Then
            If sql.Length > 0 Then sql.Append(" UNION ")
            sql.Append(" SELECT c.Name AS Clients_Name, ISNULL(l.Address, '') AS Locations_Address, ISNULL(l.City, '') AS Locations_City, l.StateCd AS Locations_StateCd,")
            sql.Append(" LTRIM(RTRIM(ISNULL(l.ClientLocationId,''))) AS Locations_ClientLocationId, ISNULL(a.AcctNum, '') AS Assessments_AcctNum, ISNULL(assessor.Name, '') AS Assessors_Name,")
            sql.Append(" ISNULL(bu.Name, '') AS BusinessUnits_Name, a.ClientId, a.LocationId, a.AssessmentId, l.TaxYear, 0, 0, MAX(ISNULL(adprior.FinalValue, 0)) AS PriorYearFinalValue,")
            sql.Append(" MAX(ISNULL(ad.TotalAssessedValue, ISNULL(ad.RELandValue, 0) + ISNULL(ad.REImprovementValue, 0))) AS CurrentYearAssessedValue, 'R'")
            sql.Append(" , a.BusinessUnitId, a.AssessorId")
            sql.Append(" FROM Clients AS c")
            sql.Append(" INNER JOIN LocationsRE AS l ON c.ClientId = l.ClientId")
            sql.Append(" INNER JOIN AssessmentsRE AS a ON l.ClientId = a.ClientId And l.LocationId = a.LocationId And l.TaxYear = a.TaxYear")
            sql.Append(" LEFT OUTER JOIN BusinessUnits AS bu ON a.ClientId = bu.ClientId And a.BusinessUnitId = bu.BusinessUnitId")
            sql.Append(" LEFT OUTER JOIN Assessors AS assessor ON a.AssessorId = assessor.AssessorId And a.TaxYear = assessor.TaxYear")
            sql.Append(" LEFT OUTER JOIN AssessmentDetailRE AS adprior ON adprior.ClientId = a.ClientId AND adprior.LocationId = a.LocationId AND adprior.AssessmentId = a.AssessmentId")
            sql.Append(" AND adprior.TaxYear = a.TaxYear - 1")
            sql.Append(" LEFT OUTER JOIN AssessmentDetailRE AS ad ON ad.ClientId = a.ClientId AND ad.LocationId = a.LocationId AND ad.AssessmentId = a.AssessmentId AND ad.TaxYear = a.TaxYear")
            If AppData.IncludeInactive = False Then
                sql.Append(" WHERE ISNULL(c.InactiveFl, 0) = 0 AND ISNULL(l.InactiveFl,0) = 0 AND ISNULL(a.InactiveFl,0) = 0")
            End If
            sql.Append(" GROUP BY c.Name, ISNULL(l.Address, ''), ISNULL(l.City, ''), l.StateCd, LTRIM(RTRIM(ISNULL(l.ClientLocationId, ''))), ISNULL(a.AcctNum, ''), ISNULL(assessor.Name, ''), ISNULL(bu.Name, ''),")
            sql.Append(" a.ClientId, a.LocationId, a.AssessmentId, l.TaxYear, a.BusinessUnitId, a.AssessorId")
            sql.Append(" HAVING l.TaxYear = ").Append(iTaxYear).Append(" AND a.ClientId = ").Append(lClientId)
            If lBusinessUnitId > 0 Then sql.Append(" AND a.BusinessUnitId = ").Append(lBusinessUnitId)
            If lAssessorId > 0 Then sql.Append(" AND a.AssessorId = ").Append(lAssessorId)
            If sStateCd <> "" Then sql.Append(" AND l.StateCd = '").Append(sStateCd).Append("'")
        End If

        'sql.Clear()
        'For i As Integer = 0 To 1
        '    If sql.Length > 0 Then sql.Append(" UNION ")
        '    If i = 0 And (ePropType = enumTable.enumLocationBPP Or ePropType = enumTable.enumUnknown) Or (i = 1 And (ePropType = enumTable.enumLocationRE Or ePropType = enumTable.enumUnknown)) Then
        '        sql.Append(" Select c.Name As Clients_Name, ISNULL(l.Address,'') As Locations_Address, ISNULL(l.City,'') As Locations_City, l.StateCd As Locations_StateCd,")
        '        sql.Append(" LTRIM(RTRIM(ISNULL(l.ClientLocationId,''))) As Locations_ClientLocationId, ISNULL(a.AcctNum,'') As Assessments_AcctNum, ISNULL(assessor.Name,'') As Assessors_Name, ISNULL(bu.Name,'') As BusinessUnits_Name,")
        '        sql.Append(" a.ClientId, a.LocationId, a.AssessmentId, l.TaxYear,0,0,")
        '        sql.Append(" ISNULL((Select MAX(ISNULL(FinalValue,0)) FROM AssessmentDetail").Append(IIf(i = 0, "BPP", "RE")).Append(" AS ad WHERE ad.ClientId = a.ClientId And ad.LocationId = a.LocationId And ad.AssessmentId = a.AssessmentId And ad.TaxYear = a.TaxYear - 1),0),")
        '        sql.Append(IIf(i = 0, "'P'", "'R'"))
        '        sql.Append(" FROM Clients As c INNER JOIN Locations").Append(IIf(i = 0, "BPP", "RE")).Append(" AS l ON c.ClientId = l.ClientId")
        '        sql.Append(" INNER JOIN Assessments").Append(IIf(i = 0, "BPP", "RE")).Append(" AS a ON l.ClientId = a.ClientId And l.LocationId = a.LocationId And l.TaxYear = a.TaxYear")
        '        sql.Append(" LEFT OUTER JOIN BusinessUnits bu On a.ClientId = bu.ClientId And a.BusinessUnitId = bu.BusinessUnitId")
        '        sql.Append(" LEFT OUTER JOIN Assessors As assessor On a.AssessorId = assessor.AssessorId And a.TaxYear = assessor.TaxYear")
        '        sql.Append(" WHERE l.TaxYear = ").Append(iTaxYear)
        '        If lClientId > 0 Then sql.Append(" AND a.ClientId = ").Append(lClientId)
        '        If lBusinessUnitId > 0 Then sql.Append(" AND a.BusinessUnitId = ").Append(lBusinessUnitId)
        '        If lAssessorId > 0 Then sql.Append(" AND a.AssessorId = ").Append(lAssessorId)
        '        If sStateCd <> "" Then sql.Append(" AND l.StateCd = '").Append(sStateCd).Append("'")
        '        If AppData.IncludeInactive = False Then
        '            sql.Append(" AND ISNULL(c.InactiveFl, 0) = 0 AND ISNULL(l.InactiveFl,0) = 0 AND ISNULL(a.InactiveFl,0) = 0")
        '        End If
        '    End If
        'Next

        ExecuteSQL(sinsert.ToString & sql.ToString)

        sql.Clear()
        sql.Append("SELECT ClientId,LocationId,AssessmentId,PropType FROM ").Append(stemptable).Append(" WHERE PropType = 'P'")
        rowsinresults = GetData(sql.ToString, dtaccounts)
        progresscounter = 0
        For Each draccount As DataRow In dtaccounts.Rows
            countyval = 0 : marketval = 0
            dtvalues = GetAssetList(draccount("ClientId"), draccount("LocationId"), draccount("AssessmentId"), iTaxYear, 0, True, False, True, False, False, False).Tables("ReturnTypeSumOfValues")
            If dtvalues.Columns.Contains("SumOfEntityValue1") Then
                countyval = dtvalues.Rows(0)("SumOfEntityValue1")
            End If
            If dtvalues.Columns.Contains("SumOfEntityValue2") Then
                marketval = dtvalues.Rows(0)("SumOfEntityValue2")
            End If
            If countyval > 0 Or marketval > 0 Then
                sql.Clear()
                sql.Append("UPDATE ").Append(stemptable).Append(" SET CountyReclassValue = ").Append(countyval.ToString).Append(",MarketReclassValue = ").Append(marketval.ToString)
                sql.Append(" WHERE ClientId = ").Append(draccount("ClientId")).Append(" AND LocationId = ").Append(draccount("LocationId")).Append(" AND AssessmentId = ").Append(draccount("AssessmentId").ToString).Append(" AND PropType = '").Append(draccount("PropType")).Append("'")
                ExecuteSQL(sql.ToString)
            End If
            progresscounter = progresscounter + 1
            resetcounter = resetcounter + 1
            If resetcounter > 10 Then
                MDIParent1.ShowStatus("Running report, " & Format(progresscounter / rowsinresults, csPct) & " complete")
                resetcounter = 0
            End If
        Next
        dtaccounts.Dispose()
        dtvalues.Dispose()
        Return "SELECT * FROM " & stemptable
    End Function
    Public Function BuildAssetReconciliationQueryByDeprCode(ByVal lClientId As Long, ByVal lLocationId As Long, lAssessmentId As Long,
            ByVal iTaxYear As Integer) As String
        Dim sSQL As New StringBuilder, sTempTable As String = "", lRows As Long, dtAccounts As New DataTable
        Dim sFactoringEntityNames(4) As String
        Dim sReturn As String = "", sINSERT As New StringBuilder, sSELECT As New StringBuilder
        Dim progresscounter As Long = 0, rowsinresults As Long = 0, resetcounter As Integer = 0

        'BuildAssetListQuery(lClientId, lLocationId, lAssessmentId, True, False, lFactorEntityId, AppData.TaxYear, sFactoringEntityNames)

        'build temptable as source for the recon report and/or list
        Do
            sTempTable = "#tmpAssetReconDeprCode" & AppData.UserId & Date.Now.Ticks.ToString
            'sTempTable = "tempdb..tmpAssetReconDeprCode" & AppData.UserId & Date.Now.Ticks.ToString
            sSQL.Clear()
            sSQL.Append("Select 1 WHERE EXISTS (Select Name FROM sys.objects where name Like '%" & sTempTable & "%')")
            lrows = GetData(sSQL.ToString, New DataTable)
            If lRows = 0 Then Exit Do
        Loop
        sSQL.Clear()
        sSQL.Append("CREATE TABLE ").Append(sTempTable).Append(" ( ")
        sSQL.Append("[ClientId] [bigint] Not NULL, ")
        sSQL.Append("[LocationId] [bigint] Not NULL, ")
        sSQL.Append("[AssessmentId] [bigint] Not NULL, ")
        sSQL.Append("[TaxYear] [smallint] NULL, ")
        sSQL.Append("[AssetId] [varchar](30) NULL,")
        sSQL.Append("[OriginalCost] [bigint] Not NULL,")
        sSQL.Append("[PurchaseDate] [DateTime] NULL,")
        'sSQL.Append("[Description] [varchar](255) NULL,")
        sSQL.Append("[GLCode] [varchar](50) NULL,")
        sSQL.Append("[Clients_Name] [varchar](255) NULL,")
        sSQL.Append("[LegalOwner] [varchar](255) NULL,")
        sSQL.Append("[Locations_Address] [varchar](50) NULL,")
        sSQL.Append("[Locations_City] [varchar](50) NULL,")
        'sSQL.Append("[ClientRenditionValue] [float] NULL,")
        'sSQL.Append("[BPPRatio] [float] Not NULL,")
        sSQL.Append("[Locations_StateCd] [Char](2) Not NULL,")
        sSQL.Append("[Locations_ClientLocationId] [varchar](255) Not NULL,")
        sSQL.Append("[Assessments_AcctNum] [varchar](50) NULL,")
        'sSQL.Append("[Clients_ExcludeNotified] [bit] Not NULL,")
        'sSQL.Append("[Clients_ExcludeAbatements] [bit] Not NULL,")
        'sSQL.Append("[Clients_ExcludeFreeport] [bit] Not NULL,")
        'sSQL.Append("[Clients_ExcludeClient] [bit] Not NULL,")
        'sSQL.Append("[Assessments_SavingsExclusionCd] [Int] Not NULL,")
        sSQL.Append("[Assessors_Name] [varchar](255) NULL,")
        sSQL.Append("[BusinessUnitId] [bigint] Not NULL,")
        sSQL.Append("[FactoringEntityName1] [varchar](255) Not NULL,")
        sSQL.Append("[FactorEntityId1] [bigint] NULL,")
        'sSQL.Append("[MappedFactorCode1] [varchar](50) Not NULL,")
        'sSQL.Append("[ClientFactorCodeOverride1] [varchar](50) Not NULL,")
        'sSQL.Append("[ClientFactorCodeOverrides_Description1] [varchar](255) Not NULL,")
        sSQL.Append("[FactorCode1] [varchar](50) Not NULL,")
        sSQL.Append("[FactorEntityCodes_Description1] [varchar](255) Not NULL,")
        'sSQL.Append("[FactorCodeOverride1] [varchar](50) Not NULL,")
        'sSQL.Append("[FactorEntityCodesOverride_Description1] [varchar](255) Not NULL,")
        sSQL.Append("[FactoredAmount1] [float] NULL")
        'sSQL.Append("[FactoredAmountOverride1] [float] NULL,")
        'sSQL.Append("[Factor1] [float] NULL,")
        'sSQL.Append("[FactorOverride1] [float] NULL")
        sSQL.Append(")")
        ExecuteSQL(sSQL.ToString)

        sINSERT.Clear()
        sINSERT.Append(" INSERT ").Append(sTempTable).Append(" (ClientId, LocationId, AssessmentId, TaxYear, AssetId, OriginalCost, PurchaseDate, GLCode, Clients_Name,")
        sINSERT.Append(" LegalOwner, Locations_Address, Locations_City,")
        sINSERT.Append(" Locations_StateCd, Locations_ClientLocationId, Assessments_AcctNum, Assessors_Name, BusinessUnitId, FactoringEntityName1, FactorEntityId1,")
        sINSERT.Append(" FactorCode1, FactorEntityCodes_Description1, FactoredAmount1)")
        sSELECT.Clear()
        sSELECT.Append(" Select ClientId, LocationId, AssessmentId, TaxYear, AssetId, OriginalCost, PurchaseDate, GLCode, Clients_Name, LegalOwner, Locations_Address, Locations_City,")
        sSELECT.Append(" Locations_StateCd, Locations_ClientLocationId, Assessments_AcctNum, Assessors_Name, BusinessUnitId, FactoringEntityName1, FactorEntityId1,")
        sSELECT.Append(" FactorCode1, FactorEntityCodes_Description1, FactoredAmount1 FROM ( ")

        'query bpp accounts
        sSQL.Clear()
        sSQL.Append(" Declare @TaxYear smallint, @ClientId bigint, @LocationId bigint, @AssessmentId bigint")
        sSQL.Append(" Select @TaxYear = ").Append(iTaxYear.ToString)
        If lClientId > 0 Then sSQL.Append(", @ClientId = " & lClientId)
        If lLocationId > 0 Then sSQL.Append(", @LocationId = " & lLocationId)
        If lAssessmentId > 0 Then sSQL.Append(", @AssessmentId = " & lAssessmentId)
        sSQL.Append(" Select asmt.ClientId, asmt.LocationId, asmt.AssessmentId, ISNULL(asmt.FactorEntityId1, 0) As FactorEntityId1")
        sSQL.Append(" FROM Clients As c INNER JOIN LocationsBPP As l On c.ClientId = l.ClientId")
        sSQL.Append(" INNER JOIN AssessmentsBPP As asmt On l.ClientId = asmt.ClientId And l.LocationId = asmt.LocationId And l.TaxYear = asmt.TaxYear")
        sSQL.Append(" WHERE (asmt.ClientId = @ClientId Or @ClientId Is NULL) And (asmt.LocationId = @LocationId Or @LocationId Is NULL)")
        sSQL.Append(" And (asmt.AssessmentId = @AssessmentId Or @AssessmentId Is NULL) And asmt.TaxYear = @TaxYear")
        sSQL.Append(" And ISNULL(asmt.FactorEntityId1,0) <> 0")
        sSQL.Append(" AND asmt.FactorEntityId1 = (SELECT FactorEntityId1 FROM AssessmentsBPP WHERE AssessmentId = asmt.AssessmentId AND TaxYear = ").Append(iTaxYear - 1).Append(")")
        If AppData.IncludeInactive = False Then
            sSQL.Append(" And ISNULL(c.InactiveFl,0) = 0 And ISNULL(l.InactiveFl,0) = 0 And ISNULL(asmt.InactiveFl,0) = 0")
        End If
        rowsinresults = GetData(sSQL.ToString, dtAccounts)
        progresscounter = 0
        sSQL.Clear()
        For Each dr As DataRow In dtAccounts.Rows
            If sSQL.Length = 0 Then
                sSQL.Append(sINSERT.ToString)
            Else
                sSQL.Append(" UNION ")
            End If
            sSQL.Append(sSELECT)
            sSQL.Append(BuildAssetListQuery(dr("ClientId"), dr("LocationId"), dr("AssessmentId"), True, True, dr("FactorEntityId1"), iTaxYear, sFactoringEntityNames))
            sSQL.Append(" ) As tmptable")
            sSQL.Append(" UNION ")
            sSQL.Append(sSELECT.ToString)
            sSQL.Append(BuildAssetListQuery(dr("ClientId"), dr("LocationId"), dr("AssessmentId"), True, True, dr("FactorEntityId1"), iTaxYear - 1, sFactoringEntityNames))
            sSQL.Append(" ) As tmptable")
            If sSQL.Length > 100000 Then
                ExecuteSQL(sSQL.ToString)
                sSQL.Clear()
            End If

            progresscounter = progresscounter + 1
            resetcounter = resetcounter + 1
            If resetcounter > 20 Then
                MDIParent1.ShowStatus("Running report, " & Format(progresscounter / rowsinresults, csPct) & " complete")
                resetcounter = 0
            End If

        Next
        If sSQL.Length > 0 Then
            ExecuteSQL(sSQL.ToString)
        End If
        sReturn = BuildAssetReconciliationQuery(lClientId, lLocationId, lAssessmentId, iTaxYear, False, sTempTable)
        Return sReturn
    End Function
    Public Function BuildAssetReconciliationQuery(ByVal lClientId As Long, ByVal lLocationId As Long, lAssessmentId As Long,
            ByVal iTaxYear As Integer, ByVal bByGLCode As Boolean, ByVal sTempTable As String) As String
        Dim sSQL As New StringBuilder

        sSQL.Length = 0

        sSQL.Append(" Declare @TaxYear smallint, @ClientId bigint, @LocationId bigint, @AssessmentId bigint")
        sSQL.Append(" Select @TaxYear = ").Append(iTaxYear.ToString)
        If lClientId > 0 Then sSQL.Append(", @ClientId = " & lClientId)
        If lLocationId > 0 Then sSQL.Append(", @LocationId = " & lLocationId)
        If lAssessmentId > 0 Then sSQL.Append(", @AssessmentId = " & lAssessmentId)

        sSQL.Append(" Select LTRIM(RTRIM(l1.Clients_Name)) As Clients_Name,")
        sSQL.Append(" LTRIM(RTRIM(l1.Address)) As Address, LTRIM(RTRIM(l1.City)) As City,")
        sSQL.Append(" l1.StateCd, l1.AcctNum, ISNULL(l1.ClientLocationId,'') AS ClientLocationId, ISNULL(l1.LegalOwner,'') AS LegalOwner,")
        sSQL.Append(" ISNULL(l1.AccountRep,'') AS AccountRep, ISNULL(l1.ConsultantName,'') AS ConsultantName, l1.ClientId,")
        sSQL.Append(" l1.LocationId, l1.AssessmentId, l1.TaxYear, ISNULL(l1.AssessorId,0) AS AssessorId,")
        If bByGLCode Then
            sSQL.Append(" GLCode = CASE a2.GLCode WHEN 'INV' THEN 'INVENTORY' ELSE a2.GLCode END,")
        Else
            sSQL.Append(" FactorCode1 = CASE a2.FactorCode1 WHEN 'INV' THEN 'INVENTORY' ELSE a2.FactorCode1 END,")
        End If
        sSQL.Append(" a2.YearPurchased, a2.PreviousYearCost, a2.CurrentYearCost, a2.CurrentYearCost - a2.PreviousYearCost AS Difference,")
        sSQL.Append(" @TaxYear AS TaxYear")

        'client/location/assessment info for current tax year
        sSQL.Append(" FROM (SELECT c.Name AS Clients_Name, l.Address, l.City, l.StateCd, asmt.AcctNum, l.ClientLocationId, l.LegalOwner, c.AccountRep,")
        sSQL.Append(" c.BPPConsultantName AS ConsultantName, asmt.ClientId, asmt.LocationId, asmt.AssessmentId, asmt.TaxYear, asmt.AssessorId")
        sSQL.Append(" FROM Clients AS c INNER JOIN LocationsBPP AS l ON c.ClientId = l.ClientId")
        sSQL.Append(" INNER JOIN AssessmentsBPP AS asmt ON l.ClientId = asmt.ClientId AND l.LocationId = asmt.LocationId And l.TaxYear = asmt.TaxYear")
        sSQL.Append(" WHERE (asmt.ClientId = @ClientId OR @ClientId IS NULL) AND (asmt.LocationId = @LocationId OR @LocationId IS NULL)")
        sSQL.Append(" AND (asmt.AssessmentId = @AssessmentId OR @AssessmentId IS NULL) AND asmt.TaxYear = @TaxYear")
        If AppData.IncludeInactive = False Then
            sSQL.Append(" AND ISNULL(c.InactiveFl,0) = 0 AND ISNULL(l.InactiveFl,0) = 0 AND ISNULL(asmt.InactiveFl,0) = 0")
        End If
        sSQL.Append(" ) AS l1")

        'asset info grouped by purchase year/glcode
        sSQL.Append(" INNER JOIN (SELECT a1.ClientId, a1.LocationId, a1.AssessmentId, a1.YearPurchased,")
        If bByGLCode Then
            sSQL.Append("a1.GLCode,")
        Else
            sSQL.Append("a1.FactorCode1,")
        End If
        If bByGLCode Then
            sSQL.Append(" ISNULL((SELECT SUM(OriginalCost) FROM Assets a")
        Else
            sSQL.Append(" ISNULL((SELECT SUM(FactoredAmount1) FROM ").Append(sTempTable).Append(" a")
        End If
        sSQL.Append(" WHERE a.ClientId = a1.ClientId And a.LocationId = a1.LocationId AND a.AssessmentId = a1.AssessmentId AND a.TaxYear = (@TaxYear - 1)")
        If bByGLCode Then
            sSQL.Append(" AND a.GLCode=a1.GLCode")
        Else
            sSQL.Append(" AND a.FactorCode1 = a1.FactorCode1")
        End If
        sSQL.Append(" And ((YEAR(a.PurchaseDate) = a1.YearPurchased")
        If bByGLCode Then
            sSQL.Append(" AND a.GLCode Not in ('INV','INVENTORY')) OR (a.GLCode in ('INV','INVENTORY')))),0) AS PreviousYearCost,")
            sSQL.Append(" ISNULL((SELECT SUM(OriginalCost) FROM Assets a")
        Else
            sSQL.Append(" AND a.FactorCode1 Not in ('INV','INVENTORY')) OR (a.FactorCode1 in ('INV','INVENTORY')))),0) AS PreviousYearCost,")
            sSQL.Append(" ISNULL((SELECT SUM(FactoredAmount1) FROM ").Append(sTempTable).Append(" a")
        End If
        sSQL.Append(" WHERE a.ClientId = a1.ClientId And a.LocationId = a1.LocationId AND a.AssessmentId = a1.AssessmentId AND a.TaxYear = @TaxYear")
        If bByGLCode Then
            sSQL.Append(" AND a.GLCode=a1.GLCode")
        Else
            sSQL.Append(" AND a.FactorCode1 = a1.FactorCode1")
        End If
        sSQL.Append(" AND ((YEAR(a.PurchaseDate) = a1.YearPurchased")
        If bByGLCode Then
            sSQL.Append(" And a.GLCode Not in ('INV','INVENTORY')) OR (a.GLCode in ('INV','INVENTORY')))),0) AS CurrentYearCost")
        Else
            sSQL.Append(" And a.FactorCode1 Not in ('INV','INVENTORY')) OR (a.FactorCode1 in ('INV','INVENTORY')))),0) AS CurrentYearCost")
        End If
        'get fixed assets (not inv) grouped by purchase year/glcode
        sSQL.Append(" FROM (SELECT ClientId, LocationId, AssessmentId, YEAR(PurchaseDate) AS YearPurchased,")
        If bByGLCode Then
            sSQL.Append("GLCode From Assets")
        Else
            sSQL.Append("FactorCode1 From ").Append(sTempTable)
        End If
        sSQL.Append(" Group By ClientId, LocationId, AssessmentId, Year(PurchaseDate),")
        If bByGLCode Then
            sSQL.Append("GLCode")
        Else
            sSQL.Append("FactorCode1")
        End If
        sSQL.Append(" HAVING (ClientId = @ClientId Or @ClientId Is NULL)")
        sSQL.Append(" And (LocationId = @LocationId Or @LocationId Is NULL)")
        sSQL.Append(" And (AssessmentId = @AssessmentId Or @AssessmentId Is NULL)")
        If bByGLCode Then
            sSQL.Append(" And Not GLCode IN ('INV', 'INVENTORY')")
        Else
            sSQL.Append(" And Not FactorCode1 IN ('INV', 'INVENTORY')")
        End If
        'inventory (inv)
        sSQL.Append(" UNION SELECT asmt.ClientId, asmt.LocationId, asmt.AssessmentId, @TaxYear AS YearPurchased,")
        If bByGLCode Then
            sSQL.Append(" 'INV' AS GLCode")
        Else
            sSQL.Append(" 'INV' AS FactorCode1")
        End If
        sSQL.Append(" FROM Clients AS c INNER JOIN LocationsBPP AS l ON c.ClientId = l.ClientId")
        sSQL.Append(" INNER JOIN AssessmentsBPP AS asmt ON l.ClientId = asmt.ClientId AND l.LocationId = asmt.LocationId And l.TaxYear = asmt.TaxYear")
        sSQL.Append(" WHERE (asmt.ClientId = @ClientId OR @ClientId IS NULL) AND (asmt.LocationId = @LocationId OR @LocationId IS NULL)")
        sSQL.Append(" AND (asmt.AssessmentId = @AssessmentId OR @AssessmentId IS NULL) AND asmt.TaxYear = @TaxYear")
        'inventory (inventory)
        sSQL.Append(" UNION SELECT asmt.ClientId, asmt.LocationId, asmt.AssessmentId, @TaxYear AS YearPurchased,")
        If bByGLCode Then
            sSQL.Append(" 'INVENTORY' AS GLCode")
        Else
            sSQL.Append(" 'INVENTORY' AS FactorCode1")
        End If
        sSQL.Append(" FROM Clients AS c INNER JOIN LocationsBPP AS l ON c.ClientId = l.ClientId")
        sSQL.Append(" INNER JOIN AssessmentsBPP AS asmt ON l.ClientId = asmt.ClientId AND l.LocationId = asmt.LocationId And l.TaxYear = asmt.TaxYear")
        sSQL.Append(" WHERE (asmt.ClientId = @ClientId OR @ClientId IS NULL) AND (asmt.LocationId = @LocationId OR @LocationId IS NULL)")
        sSQL.Append(" AND (asmt.AssessmentId = @AssessmentId OR @AssessmentId IS NULL) AND asmt.TaxYear = @TaxYear ) as a1) AS a2")
        sSQL.Append(" ON a2.ClientId=l1.ClientId and a2.LocationId=l1.LocationId AND a2.AssessmentId = l1.AssessmentId")
        sSQL.Append(" WHERE (a2.PreviousYearCost > 0 Or a2.CurrentYearCost > 0)")
        sSQL.Append(" ORDER BY l1.Clients_Name,l1.Address,l1.City,l1.StateCd,")
        If bByGLCode Then
            sSQL.Append(" a2.GLCode,")
        Else
            sSQL.Append(" a2.FactorCode1,")
        End If
        sSQL.Append(" a2.YearPurchased")

        Return sSQL.ToString

    End Function


    Public Function SaveAssetOverride(ByVal lClientId As Long, ByVal lLocationId As Long,
            ByVal lAssessmentId As Long, ByVal iTaxYear As Integer, ByVal sAssetId() As String,
            ByVal lFactorEntityId As Long, ByVal sFactorCode As String) As Boolean
        Dim sSQL As String, i As Integer, sINString As String

        Try
            sINString = ""
            For i = LBound(sAssetId) To UBound(sAssetId)
                If sINString <> "" Then sINString = sINString & ","
                sINString = sINString & QuoStr(sAssetId(i))
            Next
            sINString = "(" & sINString & ")"
            sFactorCode = Trim(sFactorCode)
            If sFactorCode = "" Then
                sSQL = "DELETE FactorCodeOverrides" &
                    " WHERE ClientId = " & lClientId & " AND LocationId = " & lLocationId &
                    " AND AssessmentId = " & lAssessmentId &
                    " AND AssetId IN " & sINString & " AND FactorEntityId = " & lFactorEntityId &
                    " AND TaxYear = " & iTaxYear
                ExecuteSQL(sSQL)
            Else
                For i = LBound(sAssetId) To UBound(sAssetId)
                    sSQL = "UPDATE FactorCodeOverrides SET FactorCode = " & QuoStr(sFactorCode) & "," &
                        " ChangeDate = GETDATE(), ChangeUser = " & QuoStr(AppData.UserId) & ", ChangeType = " & DB_Change &
                        " WHERE ClientId = " & lClientId & " AND LocationId = " & lLocationId &
                        " AND AssessmentId = " & lAssessmentId &
                        " AND AssetId = " & QuoStr(sAssetId(i)) & " AND FactorEntityId = " & lFactorEntityId &
                        " AND TaxYear = " & iTaxYear
                    If ExecuteSQL(sSQL) = 0 Then
                        sSQL = "INSERT FactorCodeOverrides (ClientId,LocationId,AssessmentId,AssetId," &
                            " FactorEntityId,TaxYear,FactorCode,AddUser)" &
                            " SELECT " & lClientId & "," & lLocationId & "," & lAssessmentId & "," &
                            QuoStr(sAssetId(i)) & "," &
                            lFactorEntityId & "," & iTaxYear & "," & QuoStr(sFactorCode) & "," & QuoStr(AppData.UserId)
                        ExecuteSQL(sSQL)
                    End If
                Next
            End If
            Return True
        Catch ex As Exception
            MsgBox("Error saving data:  " & ex.Message)
            Return False
        End Try

    End Function
    Public Function SaveAssetClientOverride(ByVal lClientId As Long, ByVal lLocationId As Long,
            ByVal lAssessmentId As Long, ByVal iTaxYear As Integer, ByVal sAssetId() As String,
            ByVal lFactorEntityId As Long, ByVal sFactorCode As String) As Boolean
        Dim sSQL As String, i As Integer, sINString As String

        Try
            sINString = ""
            For i = LBound(sAssetId) To UBound(sAssetId)
                If sINString <> "" Then sINString = sINString & ","
                sINString = sINString & QuoStr(sAssetId(i))
            Next
            sINString = "(" & sINString & ")"
            sFactorCode = Trim(sFactorCode)
            If sFactorCode = "" Then
                sSQL = "DELETE ClientFactorCodeOverrides" &
                    " WHERE ClientId = " & lClientId & " AND LocationId = " & lLocationId &
                    " AND AssessmentId = " & lAssessmentId &
                    " AND AssetId IN " & sINString & " AND FactorEntityId = " & lFactorEntityId &
                    " AND TaxYear = " & iTaxYear
                ExecuteSQL(sSQL)
            Else
                For i = LBound(sAssetId) To UBound(sAssetId)
                    sSQL = "UPDATE ClientFactorCodeOverrides SET FactorCode = " & QuoStr(sFactorCode) & "," &
                        " ChangeDate = GETDATE(), ChangeUser = " & QuoStr(AppData.UserId) & ", ChangeType = " & DB_Change &
                        " WHERE ClientId = " & lClientId & " AND LocationId = " & lLocationId &
                        " AND AssessmentId = " & lAssessmentId &
                        " AND AssetId = " & QuoStr(sAssetId(i)) & " AND FactorEntityId = " & lFactorEntityId &
                        " AND TaxYear = " & iTaxYear
                    If ExecuteSQL(sSQL) = 0 Then
                        sSQL = "INSERT ClientFactorCodeOverrides (ClientId,LocationId,AssessmentId,AssetId," &
                            " FactorEntityId,TaxYear,FactorCode,AddUser)" &
                            " SELECT " & lClientId & "," & lLocationId & "," & lAssessmentId & "," &
                            QuoStr(sAssetId(i)) & "," &
                            lFactorEntityId & "," & iTaxYear & "," & QuoStr(sFactorCode) & "," & QuoStr(AppData.UserId)
                        ExecuteSQL(sSQL)
                    End If
                Next
            End If
            Return True
        Catch ex As Exception
            MsgBox("Error saving data:  " & ex.Message)
            Return False
        End Try

    End Function
    Public Function SaveAssetAllocationPct(ByVal lClientId As Long, ByVal lLocationId As Long,
            ByVal lAssessmentId As Long, ByVal iTaxYear As Integer, ByVal sAssetId() As String,
            ByVal lFactorEntityId As Long, ByVal eType As enumAllocationPctType, ByVal dPct As Double) As Boolean
        Dim sSQL As String, i As Integer, sINString As String

        Try
            sINString = ""
            For i = LBound(sAssetId) To UBound(sAssetId)
                If sINString <> "" Then sINString = sINString & ","
                sINString = sINString & QuoStr(sAssetId(i))
            Next
            sINString = "(" & sINString & ")"
            'If dPct = 1 Then
            '    sSQL = "DELETE AssetAllocationPct" & _
            '        " WHERE ClientId = " & lClientId & " AND LocationId = " & lLocationId & _
            '        " AND AssessmentId = " & lAssessmentId & _
            '        " AND AssetId IN " & sINString & " AND FactorEntityId = " & lFactorEntityId & _
            '        " AND TaxYear = " & iTaxYear
            '    ExecuteSQL(sSQL)
            'Else
            For i = LBound(sAssetId) To UBound(sAssetId)
                sSQL = "UPDATE AssetAllocationPct SET " & IIf(eType = enumAllocationPctType.eInterstate, "InterstateAllocationPct", "AllocationPct") & " = " & dPct & "," &
                    " ChangeDate = GETDATE(), ChangeUser = " & QuoStr(AppData.UserId) & ", ChangeType = " & DB_Change &
                    " WHERE ClientId = " & lClientId & " AND LocationId = " & lLocationId &
                    " AND AssessmentId = " & lAssessmentId &
                    " AND AssetId = " & QuoStr(sAssetId(i)) & " AND FactorEntityId = " & lFactorEntityId &
                    " AND TaxYear = " & iTaxYear
                If ExecuteSQL(sSQL) = 0 Then
                    sSQL = "INSERT AssetAllocationPct (ClientId,LocationId,AssessmentId,AssetId," &
                        " FactorEntityId,TaxYear," & IIf(eType = enumAllocationPctType.eInterstate, "InterstateAllocationPct", "AllocationPct") & ",AddUser)" &
                        " SELECT " & lClientId & "," & lLocationId & "," & lAssessmentId & "," &
                        QuoStr(sAssetId(i)) & "," &
                        lFactorEntityId & "," & iTaxYear & "," & dPct & "," & QuoStr(AppData.UserId)
                    ExecuteSQL(sSQL)
                End If
                sSQL = "DELETE AssetAllocationPct" &
                    " WHERE ClientId = " & lClientId & " AND LocationId = " & lLocationId &
                    " AND AssessmentId = " & lAssessmentId &
                    " AND AssetId IN " & sINString & " AND FactorEntityId = " & lFactorEntityId &
                    " AND TaxYear = " & iTaxYear &
                    " AND ISNULL(AllocationPct,0) = 1 AND ISNULL(InterstateAllocationPct,0) = 1"
                ExecuteSQL(sSQL)
            Next
            'End If
            Return True
        Catch ex As Exception
            MsgBox("Error saving data:  " & ex.Message)
            Return False
        End Try

    End Function

End Module
