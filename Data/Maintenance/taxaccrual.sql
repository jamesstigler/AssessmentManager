--original version

SELECT 'RE' as PropertyType, a.ClientId, a.LocationId, a.AssessmentId, 
a.TaxYear,  c.Name as Clients_Name, l.Address as Locations_Address, l.City as Locations_City, l.StateCd as Locations_StateCd, ISNULL(l.ClientLocationId,'') AS Locations_ClientLocationId, a.AcctNum as Assessments_AcctNum, ass.Name as Assessors_Name, '' as FactoringEntityName1, ISNULL(ass.RERatio,0) AS Assessors_Ratio, 0 as ClientRenditionValue, j.Name as Jurisdictions_Name, 
j.TaxRate, 

--ISNULL(ad.FinalValue,(SELECT MAX(ad2.FinalValue) 
ISNULL(
CASE 
	WHEN (ISNULL(ad.REImprovementValue,0) + ISNULL(ad.RELandValue,0)) = 0  
	THEN NULL
	ELSE (ISNULL(ad.REImprovementValue,0) + ISNULL(ad.RELandValue,0))
END
,
(SELECT MAX(ad2.FinalValue) 
FROM AssessmentDetailRE ad2 
WHERE ad2.ClientId = a.ClientId AND ad2.LocationId = a.LocationId 
AND ad2.AssessmentId = a.AssessmentId  AND ad2.TaxYear = 2014)) AS FinalValue, 

ISNULL(ISNULL(ad.AbatementReductionAmt,
(SELECT ad2.AbatementReductionAmt FROM AssessmentDetailRE ad2 WHERE ad2.ClientId = ad.ClientId AND ad2.LocationId = ad.LocationId AND ad2.AssessmentId = ad.AssessmentId AND ad2.JurisdictionId = ad.JurisdictionId AND ad2.TaxYear = 2014)),0) AS AbatementReductionAmt, 
0 AS FreeportReductionAmt ,
CASE WHEN (ISNULL(ad.REImprovementValue,0) + ISNULL(ad.RELandValue,0)) = 0 THEN NULL
ELSE (ISNULL(ad.REImprovementValue,0) + ISNULL(ad.RELandValue,0)) END AS NotifiedValue,
0 AS SumOfFactoredAmount

FROM Clients AS c 
INNER JOIN LocationsRE AS l ON c.ClientId = l.ClientId 
INNER JOIN AssessmentsRE AS a ON l.ClientId = a.ClientId 
AND l.LocationId = a.LocationId AND l.TaxYear = a.TaxYear 
INNER JOIN AssessmentDetailRE AS ad ON a.ClientId = ad.ClientId 
AND a.LocationId = ad.LocationId AND a.AssessmentId = ad.AssessmentId 
AND a.TaxYear = ad.TaxYear 
LEFT OUTER JOIN Jurisdictions AS j ON ad.JurisdictionId = j.JurisdictionId 
AND ad.TaxYear = j.TaxYear 
LEFT OUTER JOIN Assessors AS ass ON a.AssessorId = ass.AssessorId 
AND a.TaxYear = ass.TaxYear 

WHERE a.TaxYear = 2015 
AND a.ClientId = 1503209683 
AND ISNULL(c.ProspectFl,0) = 0  
AND ISNULL(c.InactiveFl,0) = 0 
AND ISNULL(l.InactiveFl,0) = 0 
AND ISNULL(a.InactiveFl,0) = 0  

UNION 


SELECT 'BPP' as PropertyType, tblValues.ClientId, tblValues.LocationId, tblValues.AssessmentId,tblValues.TaxYear, tblValues.Clients_Name, tblValues.Locations_Address, tblValues.Locations_City,tblValues.Locations_StateCd, tblValues.Locations_ClientLocationId, tblValues.Assessments_AcctNum, tblValues.Assessors_Name, tblValues.FactoringEntityName1, ISNULL(tblValues.BPPRatio,0) AS Assessors_Ratio, tblValues.ClientRenditionValue, j.Name as Jurisdictions_Name, j.TaxRate, 


CASE WHEN tblValues.SumOfFactoredAmount > 
--ISNULL(ISNULL(ad.FinalValue,
ISNULL(ISNULL(ad.NotifiedValue,

--(SELECT MAX(ad2.FinalValue) FROM AssessmentDetailBPP ad2 
--WHERE ad2.ClientId = tblValues.ClientId 
--AND ad2.LocationId = tblValues.LocationId 
--AND ad2.AssessmentId = tblValues.AssessmentId AND ad2.TaxYear = 2014)
tblValues.SumOfFactoredAmount
)
,0) 
THEN tblValues.SumOfFactoredAmount 
--ELSE ISNULL(ISNULL(ad.FinalValue,(SELECT MAX(ad2.FinalValue) 
ELSE ISNULL(ISNULL(ad.NotifiedValue,

--(SELECT MAX(ad2.FinalValue) 
--FROM AssessmentDetailBPP ad2 WHERE ad2.ClientId = tblValues.ClientId 
--AND ad2.LocationId = tblValues.LocationId 
--AND ad2.AssessmentId = tblValues.AssessmentId
--AND ad2.TaxYear = 2014)
tblValues.SumOfFactoredAmount 
 )
 ,0) END AS FinalValue, 
 
 ISNULL(ISNULL(ad.AbatementReductionAmt,(SELECT ad2.AbatementReductionAmt FROM AssessmentDetailBPP ad2 WHERE ad2.ClientId = ad.ClientId AND ad2.LocationId = ad.LocationId AND ad2.AssessmentId = ad.AssessmentId AND ad2.JurisdictionId = ad.JurisdictionId AND ad2.TaxYear = 2014)),0) AS AbatementReductionAmt, 
 ISNULL(ISNULL(ad.FreeportReductionAmt,
	(SELECT ad2.FreeportReductionAmt 
	FROM AssessmentDetailBPP ad2 
	WHERE ad2.ClientId = ad.ClientId AND ad2.LocationId = ad.LocationId 
	AND ad2.AssessmentId = ad.AssessmentId AND ad2.JurisdictionId = ad.JurisdictionId 
	AND ad2.TaxYear = 2014)),0) AS FreeportReductionAmt, 
 ISNULL(ad.NotifiedValue,0) AS NotifiedValue,
 tblValues.SumOfFactoredAmount
 FROM (SELECT ClientId, LocationId, AssessmentId,TaxYear, Clients_Name, Locations_Address, Locations_City, Locations_StateCd, Locations_ClientLocationId, Assessments_AcctNum, Assessors_Name, FactoringEntityName1,BPPRatio, ISNULL(ClientRenditionValue,0) AS ClientRenditionValue, SUM(FactoredAmount1) AS SumOfFactoredAmount FROM (SELECT tblA.ClientId,tblA.LocationId,tblA.AssessmentId,tblA.TaxYear,tblA.AssetId,tblA.OriginalCost, tblA.PurchaseDate, RTRIM(tblA.Description) AS Description, RTRIM(tblA.GLCode) AS GLCode,RTRIM(tblA.Clients_Name) AS Clients_Name, RTRIM(tblA.Locations_Address) AS Locations_Address,RTRIM(tblA.Locations_City) AS Locations_City, tblA.ClientRenditionValue, tblA.BPPRatio, tblA.Locations_StateCd, tblA.Locations_ClientLocationId, RTRIM(tblA.Assessments_AcctNum) AS Assessments_AcctNum, RTRIM(tblA.Assessors_Name) AS Assessors_Name,'DENTON, TX' AS FactoringEntityName1,tblA.FactorEntityId1 ,ISNULL(tbl1.FactorCode,'') AS MappedFactorCode1 ,ISNULL(tbl1CO.FactorCode,'') AS ClientFactorCodeOverride1 ,ISNULL(tbl1CO.Description,'') AS ClientFactorCodeOverrides_Description1 ,ISNULL(tbl1CO.FactorCode,ISNULL(tbl1.FactorCode,'')) AS FactorCode1 ,ISNULL(tbl1CO.Description,ISNULL(tbl1.FactorEntityCodes_Description,'')) AS FactorEntityCodes_Description1 ,ISNULL(tbl1O.FactorCode,'') AS FactorCodeOverride1 ,ISNULL(tbl1O.Description,'') AS FactorEntityCodesOverride_Description1,FactoredAmount1 =  CASE  WHEN tblA.GLCode IN('INV','Inventory') OR tblA.AssetId IN('INV','Inventory') OR tblA.Description IN('INV','Inventory') THEN tbla.OriginalCost ELSE CONVERT(bigint, ISNULL(ISNULL((SELECT Percentage FROM Factors AS f WHERE f.FactorEntityId = 89 AND f.FactorCode = ISNULL(tbl1CO.FactorCode,tbl1.FactorCode) AND f.TaxYear = 2015 AND f.Age = 2015 - YEAR(tblA.PurchaseDate)), (SELECT Percentage FROM Factors AS f WHERE f.FactorEntityId = 89 AND f.FactorCode = ISNULL(tbl1CO.FactorCode,tbl1.FactorCode) AND f.TaxYear = 2015 AND f.Age = 99)), 0) * ISNULL(tblA.OriginalCost, 0) * ISNULL(tblA.AllocationPct,1) + .5) END ,CONVERT(bigint, ISNULL(ISNULL((SELECT Percentage FROM Factors AS f WHERE f.FactorEntityId = 89 AND f.FactorCode = tbl1O.FactorCode AND f.TaxYear = 2015 AND f.Age = 2015 - YEAR(tblA.PurchaseDate)), (SELECT Percentage FROM Factors AS f WHERE f.FactorEntityId = 89 AND f.FactorCode = tbl1O.FactorCode AND f.TaxYear = 2015 AND f.Age = 99)), 0) * ISNULL(tblA.OriginalCost, 0) * ISNULL(tblA.AllocationPct,1) + .5) AS FactoredAmountOverride1,CONVERT(float, ISNULL(ISNULL((SELECT Percentage FROM Factors AS f WHERE f.FactorEntityId = 89 AND f.FactorCode = ISNULL(tbl1CO.FactorCode,tbl1.FactorCode) AND f.TaxYear = 2015 AND f.Age = 2015 - YEAR(tblA.PurchaseDate)), (SELECT Percentage FROM Factors AS f WHERE f.FactorEntityId = 89 AND f.FactorCode = ISNULL(tbl1CO.FactorCode,tbl1.FactorCode) AND f.TaxYear = 2015 AND f.Age = 99)), 0)) AS Factor1,CONVERT(float, ISNULL(ISNULL((SELECT Percentage FROM Factors AS f WHERE f.FactorEntityId = 89 AND f.FactorCode = tbl1O.FactorCode AND f.TaxYear = 2015 AND f.Age = 2015 - YEAR(tblA.PurchaseDate)), (SELECT Percentage FROM Factors AS f WHERE f.FactorEntityId = 89 AND f.FactorCode = tbl1O.FactorCode AND f.TaxYear = 2015 AND f.Age = 99)), 0)) AS FactorOverride1 FROM  (SELECT c.ClientId, l.LocationId, assess.AssessmentId, a.AssetId, a.TaxYear, ISNULL(a.OriginalCost,0) AS OriginalCost, a.PurchaseDate, a.Description,a.GLCode, l.StateCd, assess.FactorEntityId1, assess.FactorEntityId2, assess.FactorEntityId3, assess.FactorEntityId4, assess.FactorEntityId5, c.Name AS Clients_Name,l.Address AS Locations_Address,l.City as Locations_City,l.StateCd as Locations_StateCd, ISNULL(l.ClientLocationId,'') AS Locations_ClientLocationId, assessor.Name as Assessors_Name, assess.AcctNum AS Assessments_AcctNum, a.VIN, a.LocationAddress,a.AllocationPct,assess.ClientRenditionValue,ISNULL(assessor.BPPRatio,0) AS BPPRatio FROM AssessmentsBPP AS assess INNER JOIN Clients AS c ON assess.ClientId = c.ClientId INNER JOIN LocationsBPP AS l ON assess.ClientId = l.ClientId AND assess.LocationId = l.LocationId AND assess.TaxYear = l.TaxYear LEFT OUTER JOIN Assessors AS assessor on assess.AssessorId = assessor.AssessorId and assess.TaxYear = assessor.TaxYear LEFT OUTER JOIN Assets AS a ON assess.ClientId = a.ClientId AND assess.LocationId = a.LocationId AND assess.AssessmentId = a.AssessmentId AND assess.TaxYear = a.TaxYear where assess.TaxYear = 2015 AND assess.ClientId = 1503209683 AND assess.LocationId = 1820429750 AND assess.AssessmentId = 414734931) tblA LEFT OUTER JOIN (SELECT cx.ClientId, cx.StateCd, cx.GLCode, cx.TaxYear, cx.FactorEntityId, cx.FactorCode,ISNULL(fec.Description,cx.FactorCode) AS FactorEntityCodes_Description FROM ClientGLCodeXRef AS cx INNER JOIN FactorEntityCodes AS fec ON cx.FactorEntityId = fec.FactorEntityId AND cx.FactorCode = fec.FactorCode AND cx.TaxYear = fec.TaxYear WHERE cx.TaxYear = 2015 AND cx.ClientId = 1503209683 AND cx.FactorEntityId = 89 ) tbl1 ON tblA.ClientId = tbl1.ClientId AND tblA.StateCd = tbl1.StateCd AND tblA.GLCode = tbl1.GLCode AND tblA.TaxYear = tbl1.TaxYear AND tblA.FactorEntityId1 = tbl1.FactorEntityId LEFT OUTER JOIN (SELECT fec.FactorCode,isnull(fec.Description,fec.FactorCode) AS Description, fco.ClientId, fco.LocationId, fco.AssessmentId, fco.AssetId, fco.FactorEntityId,fec.TaxYear FROM FactorCodeOverrides AS fco INNER JOIN FactorEntityCodes AS fec ON fco.FactorEntityId = fec.FactorEntityId AND fco.FactorCode = fec.FactorCode AND fco.TaxYear = fec.TaxYear WHERE fco.TaxYear = 2015 AND fco.ClientId = 1503209683 AND fco.FactorEntityId = 89 AND fco.LocationId =  1820429750 AND fco.AssessmentId =  414734931 ) tbl1O ON tblA.ClientId = tbl1O.ClientId AND tblA.LocationId = tbl1O.LocationId AND tblA.AssessmentId = tbl1O.AssessmentId AND tblA.AssetId = tbl1O.AssetId AND tblA.TaxYear = tbl1O.TaxYear AND tblA.FactorEntityId1 = tbl1O.FactorEntityId LEFT OUTER JOIN (SELECT cfc.AssetId, cfc.FactorCode, ISNULL(fec.Description,fec.FactorCode) AS Description FROM FactorEntityCodes AS fec INNER JOIN ClientFactorCodeOverrides AS cfc ON fec.FactorEntityId = cfc.FactorEntityId AND fec.FactorCode = cfc.FactorCode AND fec.TaxYear = cfc.TaxYear WHERE cfc.ClientId = 1503209683 AND cfc.FactorEntityId = 89 AND cfc.LocationId =  1820429750 AND cfc.AssessmentId =  414734931 AND cfc.TaxYear = 2015 ) AS tbl1CO ON tblA.AssetId = tbl1CO.AssetId ) tblAssets GROUP BY ClientId, LocationId, AssessmentId,TaxYear, Clients_Name, Locations_Address, Locations_City,Locations_StateCd,Locations_ClientLocationId,Assessments_AcctNum, Assessors_Name, FactoringEntityName1, BPPRatio, ClientRenditionValue ) tblValues INNER JOIN AssessmentDetailBPP ad on ad.ClientId=tblValues.ClientId and ad.LocationId=tblValues.LocationId AND ad.AssessmentId=tblValues.AssessmentId and ad.TaxYear=tblValues.TaxYear LEFT JOIN Jurisdictions j ON ad.JurisdictionId = j.JurisdictionId AND ad.TaxYear = j.TaxYear 
 ORDER BY 6,1



 --revised version
