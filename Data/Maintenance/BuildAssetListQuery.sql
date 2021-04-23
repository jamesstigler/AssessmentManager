SELECT tblA.ClientId,tblA.LocationId,tblA.AssessmentId,tblA.TaxYear,tblA.AssetId,tblA.OriginalCost, tblA.PurchaseDate, 
RTRIM(tblA.Description) AS Description, 
RTRIM(tblA.GLCode) AS GLCode,RTRIM(tblA.Clients_Name) AS Clients_Name, LTRIM(RTRIM(tblA.LegalOwner)) AS LegalOwner, 
RTRIM(tblA.Locations_Address) AS Locations_Address,
RTRIM(tblA.Locations_City) AS Locations_City, tblA.ClientRenditionValue, tblA.BPPRatio, tblA.Locations_StateCd, tblA.Locations_ClientLocationId, 
RTRIM(tblA.Assessments_AcctNum) AS Assessments_AcctNum, ISNULL(tblA.Clients_ExcludeNotified,0) AS Clients_ExcludeNotified, 
ISNULL(tblA.Clients_ExcludeAbatements,0) AS Clients_ExcludeAbatements, 
ISNULL(tblA.Clients_ExcludeFreeport,0) AS Clients_ExcludeFreeport, ISNULL(tblA.Clients_ExcludeClient,0) AS Clients_ExcludeClient, 
ISNULL(tblA.Assessments_SavingsExclusionCd,0) AS Assessments_SavingsExclusionCd, RTRIM(tblA.Assessors_Name) AS Assessors_Name, 
tblA.AllocationPct,

'ELLIS COUNTY, TX' AS FactoringEntityName1,tblA.FactorEntityId1 ,
ISNULL(tbl1.FactorCode,'') AS MappedFactorCode1 ,ISNULL(tbl1CO.FactorCode,'') AS ClientFactorCodeOverride1 ,
ISNULL(tbl1CO.Description,'') AS ClientFactorCodeOverrides_Description1 ,ISNULL(tbl1CO.FactorCode,
ISNULL(tbl1.FactorCode,'')) AS FactorCode1 ,
ISNULL(tbl1CO.Description,ISNULL(tbl1.FactorEntityCodes_Description,'')) AS FactorEntityCodes_Description1 ,
ISNULL(tbl1O.FactorCode,'') AS FactorCodeOverride1 ,
ISNULL(tbl1O.Description,'') AS FactorEntityCodesOverride_Description1,
ISNULL(tbl1aap.AllocationPct,1) AS AllocationPct1,

FactoredAmount1 =  CONVERT(bigint, ISNULL(ISNULL((SELECT Percentage FROM Factors AS f WHERE f.FactorEntityId = 92 AND f.FactorCode = ISNULL(tbl1CO.FactorCode,tbl1.FactorCode) 
AND f.TaxYear = 2015 AND f.Age = 2015 - YEAR(tblA.PurchaseDate)), (SELECT Percentage FROM Factors AS f WHERE f.FactorEntityId = 92 AND f.FactorCode = ISNULL(tbl1CO.FactorCode,tbl1.FactorCode) 
AND f.TaxYear = 2015 AND f.Age = 99)), 0) * ISNULL(tblA.OriginalCost, 0) * 
--ISNULL(tblA.AllocationPct,1) + .5),
ISNULL(tbl1aap.AllocationPct,1) + .5),

CONVERT(bigint, ISNULL(ISNULL((SELECT Percentage FROM Factors AS f WHERE f.FactorEntityId = 92 AND f.FactorCode = tbl1O.FactorCode 
AND f.TaxYear = 2015 AND f.Age = 2015 - YEAR(tblA.PurchaseDate)), (SELECT Percentage FROM Factors AS f WHERE f.FactorEntityId = 92 AND f.FactorCode = tbl1O.FactorCode 
AND f.TaxYear = 2015 AND f.Age = 99)), 0) * ISNULL(tblA.OriginalCost, 0) * 
--ISNULL(tblA.AllocationPct,1) + .5) 
ISNULL(tbl1aap.AllocationPct,1) + .5) 
AS FactoredAmountOverride1,

CONVERT(float, ISNULL(ISNULL((SELECT Percentage FROM Factors AS f WHERE f.FactorEntityId = 92 AND f.FactorCode = ISNULL(tbl1CO.FactorCode,tbl1.FactorCode) 
AND f.TaxYear = 2015 AND f.Age = 2015 - YEAR(tblA.PurchaseDate)), (SELECT Percentage FROM Factors AS f WHERE f.FactorEntityId = 92 
AND f.FactorCode = ISNULL(tbl1CO.FactorCode,tbl1.FactorCode) AND f.TaxYear = 2015 AND f.Age = 99)), 0)) AS Factor1,

CONVERT(float, ISNULL(ISNULL((SELECT Percentage FROM Factors AS f WHERE f.FactorEntityId = 92 AND f.FactorCode = tbl1O.FactorCode AND f.TaxYear = 2015 
AND f.Age = 2015 - YEAR(tblA.PurchaseDate)), (SELECT Percentage FROM Factors AS f 
WHERE f.FactorEntityId = 92 AND f.FactorCode = tbl1O.FactorCode AND f.TaxYear = 2015 AND f.Age = 99)), 0)) AS FactorOverride1,

'Vantage One-MVF, TX' AS FactoringEntityName2,tblA.FactorEntityId2 ,
ISNULL(tbl2.FactorCode,'') AS MappedFactorCode2 ,ISNULL(tbl2CO.FactorCode,'') AS ClientFactorCodeOverride2 ,ISNULL(tbl2CO.Description,'') AS ClientFactorCodeOverrides_Description2 ,
ISNULL(tbl2CO.FactorCode,ISNULL(tbl2.FactorCode,'')) AS FactorCode2 ,ISNULL(tbl2CO.Description,ISNULL(tbl2.FactorEntityCodes_Description,'')) AS FactorEntityCodes_Description2 ,
ISNULL(tbl2O.FactorCode,'') AS FactorCodeOverride2 ,ISNULL(tbl2O.Description,'') AS FactorEntityCodesOverride_Description2,

FactoredAmount2 =  
CONVERT(bigint, ISNULL(ISNULL((SELECT Percentage FROM Factors AS f WHERE f.FactorEntityId = 917901878 AND f.FactorCode = ISNULL(tbl2CO.FactorCode,tbl2.FactorCode) AND f.TaxYear = 2015 
AND f.Age = 2015 - YEAR(tblA.PurchaseDate)), (SELECT Percentage FROM Factors AS f WHERE f.FactorEntityId = 917901878 AND f.FactorCode = ISNULL(tbl2CO.FactorCode,tbl2.FactorCode) 
AND f.TaxYear = 2015 AND f.Age = 99)), 0) * ISNULL(tblA.OriginalCost, 0) * 
--ISNULL(tblA.AllocationPct,1) + .5),
ISNULL(tbl2aap.AllocationPct,1) + .5),

ISNULL(tbl2aap.AllocationPct,1) AS AllocationPct2,

CONVERT(bigint, ISNULL(ISNULL((SELECT Percentage FROM Factors AS f 
WHERE f.FactorEntityId = 917901878 AND f.FactorCode = tbl2O.FactorCode AND f.TaxYear = 2015 AND f.Age = 2015 - YEAR(tblA.PurchaseDate)), (SELECT Percentage FROM Factors AS f 
WHERE f.FactorEntityId = 917901878 AND f.FactorCode = tbl2O.FactorCode AND f.TaxYear = 2015 AND f.Age = 99)), 0) * ISNULL(tblA.OriginalCost, 0) * 
--ISNULL(tblA.AllocationPct,1) + .5) 
ISNULL(tbl2aap.AllocationPct,1) + .5) AS FactoredAmountOverride2,

CONVERT(float, ISNULL(ISNULL((SELECT Percentage FROM Factors AS f WHERE f.FactorEntityId = 917901878 
AND f.FactorCode = ISNULL(tbl2CO.FactorCode,tbl2.FactorCode) AND f.TaxYear = 2015 AND f.Age = 2015 - YEAR(tblA.PurchaseDate)), (SELECT Percentage FROM Factors AS f 
WHERE f.FactorEntityId = 917901878 AND f.FactorCode = ISNULL(tbl2CO.FactorCode,tbl2.FactorCode) AND f.TaxYear = 2015 AND f.Age = 99)), 0)) AS Factor2,
CONVERT(float, ISNULL(ISNULL((SELECT Percentage FROM Factors AS f WHERE f.FactorEntityId = 917901878 AND f.FactorCode = tbl2O.FactorCode AND f.TaxYear = 2015 
AND f.Age = 2015 - YEAR(tblA.PurchaseDate)), (SELECT Percentage FROM Factors AS f WHERE f.FactorEntityId = 917901878 AND f.FactorCode = tbl2O.FactorCode 
AND f.TaxYear = 2015 AND f.Age = 99)), 0)) AS FactorOverride2 

--main asset/account 
FROM  (SELECT c.ClientId, l.LocationId, assess.AssessmentId, a.AssetId, a.TaxYear, ISNULL(a.OriginalCost,0) AS OriginalCost, a.PurchaseDate, 
a.Description,a.GLCode, l.StateCd, assess.FactorEntityId1, assess.FactorEntityId2, 
assess.FactorEntityId3, assess.FactorEntityId4, assess.FactorEntityId5, c.Name AS Clients_Name,ISNULL(l.LegalOwner,c.Name) AS LegalOwner, l.Address AS Locations_Address,
l.City as Locations_City,l.StateCd as Locations_StateCd, ISNULL(l.ClientLocationId,'') AS Locations_ClientLocationId, assessor.Name as Assessors_Name, assess.AcctNum AS Assessments_AcctNum,
 ISNULL(c.ExcludeNotified,0) AS Clients_ExcludeNotified, ISNULL(c.ExcludeAbatements,0) AS Clients_ExcludeAbatements, ISNULL(c.ExcludeFreeport,0) AS Clients_ExcludeFreeport, 
 ISNULL(c.ExcludeClient,0) AS Clients_ExcludeClient, ISNULL(assess.SavingsExclusionCd,0) AS Assessments_SavingsExclusionCd, a.VIN, a.LocationAddress,
 a.AllocationPct,
 assess.ClientRenditionValue,
 ISNULL(assessor.BPPRatio,0) AS BPPRatio 
 FROM AssessmentsBPP AS assess INNER JOIN Clients AS c ON assess.ClientId = c.ClientId INNER JOIN LocationsBPP AS l ON assess.ClientId = l.ClientId 
 AND assess.LocationId = l.LocationId AND assess.TaxYear = l.TaxYear LEFT OUTER JOIN Assessors AS assessor on assess.AssessorId = assessor.AssessorId and assess.TaxYear = assessor.TaxYear 
 LEFT OUTER JOIN Assets AS a ON assess.ClientId = a.ClientId AND assess.LocationId = a.LocationId AND assess.AssessmentId = a.AssessmentId AND assess.TaxYear = a.TaxYear 
 where assess.TaxYear = 2015 AND assess.ClientId = 572357574 AND assess.LocationId = 566623272 AND assess.AssessmentId = 513890377)  tblA 

 --client mapping 1
 LEFT OUTER JOIN (SELECT cx.ClientId, cx.StateCd, cx.GLCode, cx.TaxYear, cx.FactorEntityId, cx.FactorCode,ISNULL(fec.Description,cx.FactorCode) AS FactorEntityCodes_Description 
 FROM ClientGLCodeXRef AS cx INNER JOIN FactorEntityCodes AS fec ON cx.FactorEntityId = fec.FactorEntityId AND cx.FactorCode = fec.FactorCode AND cx.TaxYear = fec.TaxYear 
 WHERE cx.TaxYear = 2015 AND cx.ClientId = 572357574 AND cx.FactorEntityId = 92 ) tbl1 
 ON tblA.ClientId = tbl1.ClientId AND tblA.StateCd = tbl1.StateCd 
 AND tblA.GLCode = tbl1.GLCode AND tblA.TaxYear = tbl1.TaxYear AND tblA.FactorEntityId1 = tbl1.FactorEntityId 
 
 --factor overrides 1
 LEFT OUTER JOIN (SELECT fec.FactorCode,
 isnull(fec.Description,fec.FactorCode) AS Description, fco.ClientId, fco.LocationId, fco.AssessmentId, fco.AssetId, fco.FactorEntityId,fec.TaxYear 
 FROM FactorCodeOverrides AS fco INNER JOIN FactorEntityCodes AS fec ON fco.FactorEntityId = fec.FactorEntityId AND fco.FactorCode = fec.FactorCode 
 AND fco.TaxYear = fec.TaxYear 
 WHERE fco.TaxYear = 2015 AND fco.ClientId = 572357574 AND fco.FactorEntityId = 92 
 AND fco.LocationId =  566623272 AND fco.AssessmentId =  513890377 ) tbl1O 
 ON tblA.ClientId = tbl1O.ClientId AND tblA.LocationId = tbl1O.LocationId AND tblA.AssessmentId = tbl1O.AssessmentId 
 AND tblA.AssetId = tbl1O.AssetId AND tblA.TaxYear = tbl1O.TaxYear 
 AND tblA.FactorEntityId1 = tbl1O.FactorEntityId 
 
 --client factor override 1
 LEFT OUTER JOIN (SELECT cfc.AssetId, cfc.FactorCode, ISNULL(fec.Description,fec.FactorCode) AS Description FROM FactorEntityCodes AS fec 
 INNER JOIN ClientFactorCodeOverrides AS cfc ON fec.FactorEntityId = cfc.FactorEntityId AND fec.FactorCode = cfc.FactorCode 
 AND fec.TaxYear = cfc.TaxYear 
 WHERE cfc.ClientId = 572357574 AND cfc.FactorEntityId = 92 AND cfc.LocationId =  566623272 
 AND cfc.AssessmentId =  513890377 AND cfc.TaxYear = 2015 ) AS  tbl1CO 
 ON tblA.AssetId = tbl1CO.AssetId 

 --asset allocation pct 1
 LEFT OUTER JOIN (SELECT aap.AllocationPct, aap.AssetId, aap.FactorEntityId, aap.ClientId, aap.LocationId, aap.AssessmentId, aap.TaxYear FROM AssetAllocationPct aap
	WHERE aap.TaxYear = 2015 AND aap.ClientId = 572357574 AND aap.FactorEntityId = 92 
	AND aap.LocationId =  566623272 AND aap.AssessmentId =  513890377 ) tbl1aap
 ON tblA.ClientId = tbl1aap.ClientId AND tblA.LocationId = tbl1aap.LocationId AND tblA.AssessmentId = tbl1aap.AssessmentId 
 AND tblA.AssetId = tbl1aap.AssetId AND tblA.TaxYear = tbl1aap.TaxYear 
 AND tblA.FactorEntityId1 = tbl1aap.FactorEntityId 
  
 --client mapping 2
 LEFT OUTER JOIN (SELECT cx.ClientId, cx.StateCd, cx.GLCode, cx.TaxYear, cx.FactorEntityId, cx.FactorCode,
 ISNULL(fec.Description,cx.FactorCode) AS FactorEntityCodes_Description FROM ClientGLCodeXRef AS cx INNER JOIN FactorEntityCodes AS fec 
 ON cx.FactorEntityId = fec.FactorEntityId AND cx.FactorCode = fec.FactorCode AND cx.TaxYear = fec.TaxYear WHERE cx.TaxYear = 2015 AND cx.ClientId = 572357574 
 AND cx.FactorEntityId = 917901878 ) tbl2 
 ON tblA.ClientId = tbl2.ClientId AND tblA.StateCd = tbl2.StateCd AND tblA.GLCode = tbl2.GLCode AND tblA.TaxYear = tbl2.TaxYear 
 AND tblA.FactorEntityId2 = tbl2.FactorEntityId 
 
 --entity factor override 2
 LEFT OUTER JOIN (SELECT fec.FactorCode,isnull(fec.Description,fec.FactorCode) AS Description, 
	fco.ClientId, fco.LocationId, fco.AssessmentId, fco.AssetId, fco.FactorEntityId,fec.TaxYear 
	FROM FactorCodeOverrides AS fco 
	INNER JOIN FactorEntityCodes AS fec ON fco.FactorEntityId = fec.FactorEntityId AND fco.FactorCode = fec.FactorCode AND fco.TaxYear = fec.TaxYear 
	WHERE fco.TaxYear = 2015 AND fco.ClientId = 572357574 
	AND fco.FactorEntityId = 917901878 AND fco.LocationId =  566623272 AND fco.AssessmentId =  513890377 ) tbl2O 	
 ON tblA.ClientId = tbl2O.ClientId  AND tblA.LocationId = tbl2O.LocationId AND tblA.AssessmentId = tbl2O.AssessmentId AND tblA.AssetId = tbl2O.AssetId AND tblA.TaxYear = tbl2O.TaxYear 
 AND tblA.FactorEntityId2 = tbl2O.FactorEntityId 

 --client override of client mapping 2
 LEFT OUTER JOIN (SELECT cfc.AssetId, cfc.FactorCode, ISNULL(fec.Description,fec.FactorCode) AS Description 
	FROM FactorEntityCodes AS fec 
	INNER JOIN ClientFactorCodeOverrides AS cfc ON fec.FactorEntityId = cfc.FactorEntityId AND fec.FactorCode = cfc.FactorCode 
	AND fec.TaxYear = cfc.TaxYear 
	WHERE cfc.ClientId = 572357574 AND cfc.FactorEntityId = 917901878 AND cfc.LocationId =  566623272 AND cfc.AssessmentId =  513890377 
	AND cfc.TaxYear = 2015 ) AS tbl2CO 
 ON tblA.AssetId = tbl2CO.AssetId

 --asset allocation pct 2
 LEFT OUTER JOIN (SELECT aap.AllocationPct, aap.AssetId, aap.FactorEntityId, aap.ClientId, aap.LocationId, aap.AssessmentId, aap.TaxYear FROM AssetAllocationPct aap
	WHERE aap.TaxYear = 2015 AND aap.ClientId = 572357574 AND aap.FactorEntityId = 92 
	AND aap.LocationId =  566623272 AND aap.AssessmentId =  513890377 ) tbl2aap
 ON tblA.ClientId = tbl2aap.ClientId AND tblA.LocationId = tbl2aap.LocationId AND tblA.AssessmentId = tbl2aap.AssessmentId 
 AND tblA.AssetId = tbl2aap.AssetId AND tblA.TaxYear = tbl2aap.TaxYear 
 AND tblA.FactorEntityId1 = tbl2aap.FactorEntityId 
 

