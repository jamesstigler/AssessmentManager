declare @TaxYear smallint, @ClientId bigint, @LocationId bigint, @AssessmentId bigint

SELECT @TaxYear = 2014, @ClientId = 30 --, @LocationId = 457620419, @AssessmentId = 1147274633

SELECT LTRIM(RTRIM(l1.Clients_Name)) AS Clients_Name, 
LTRIM(RTRIM(l1.Address)) AS Address, LTRIM(RTRIM(l1.City)) AS City, 
l1.StateCd, l1.AcctNum, l1.ClientLocationId, 
l1.LegalOwner, l1.AccountRep, 
l1.ConsultantName, l1.ClientId, l1.LocationId, l1.AssessmentId, l1.TaxYear, l1.AssessorId,
GLCode = CASE a2.GLCode WHEN 'INV' THEN 'INVENTORY' ELSE a2.GLCode END, a2.YearPurchased,
a2.PreviousYearCost, a2.CurrentYearCost, a2.CurrentYearCost - a2.PreviousYearCost AS Difference,
@TaxYear AS TaxYear, l1.Clients_InactiveFl, l1.Locations_InactiveFl, l1.Assessments_InactiveFl

FROM
(
SELECT c.Name AS Clients_Name, l.Address, l.City, l.StateCd, 
asmt.AcctNum, l.ClientLocationId, l.LegalOwner, c.AccountRep, 
c.ConsultantName, asmt.ClientId, asmt.LocationId, asmt.AssessmentId, 
asmt.TaxYear, asmt.AssessorId, 
c.InactiveFl AS Clients_InactiveFl, 
l.InactiveFl AS Locations_InactiveFl,
asmt.InactiveFl AS Assessments_InactiveFl
FROM Clients AS c 
INNER JOIN LocationsBPP AS l ON c.ClientId = l.ClientId 
INNER JOIN AssessmentsBPP AS asmt ON l.ClientId = asmt.ClientId AND 
l.LocationId = asmt.LocationId AND l.TaxYear = asmt.TaxYear
WHERE (asmt.ClientId = @ClientId OR @ClientId IS NULL) AND
(asmt.LocationId = @LocationId OR @LocationId IS NULL) AND
(asmt.AssessmentId = @AssessmentId OR @AssessmentId IS NULL) AND 
asmt.TaxYear = @TaxYear

--AND ISNULL(c.InactiveFl,0) = 0 AND ISNULL(l.InactiveFl,0) = 0 AND ISNULL(asmt.InactiveFl,0) = 0

) AS l1 

inner join

(
SELECT a1.ClientId, a1.LocationId, a1.AssessmentId, --a1.TaxYear, 
a1.YearPurchased, a1.GLCode,

ISNULL((SELECT SUM(OriginalCost) FROM Assets a WHERE a.ClientId = a1.ClientId And 
a.LocationId = a1.LocationId and 
a.AssessmentId=a1.AssessmentId and a.GLCode=a1.GLCode AND a.TaxYear = (@TaxYear - 1) AND     
((YEAR(a.PurchaseDate)=a1.YearPurchased and a.GLCode not in ('INV','INVENTORY')) 
   OR (a.GLCode in ('INV','INVENTORY')))),0) AS PreviousYearCost,

ISNULL((SELECT SUM(OriginalCost) FROM Assets a WHERE a.ClientId = a1.ClientId And 
a.LocationId = a1.LocationId and 
a.AssessmentId=a1.AssessmentId and a.GLCode=a1.GLCode AND a.TaxYear = @TaxYear AND     
((YEAR(a.PurchaseDate)=a1.YearPurchased and a.GLCode not in ('INV','INVENTORY')) 
   OR (a.GLCode in ('INV','INVENTORY')))),0) AS CurrentYearCost


FROM

(



--get fixed assets (not inv) grouped by purchase year/glcode
SELECT ClientId, LocationId, AssessmentId, --TaxYear, 
YEAR(PurchaseDate) AS YearPurchased, GLCode
FROM Assets
GROUP BY ClientId, LocationId, AssessmentId, --TaxYear, 
YEAR(PurchaseDate), GLCode
HAVING (ClientId = @ClientId OR @ClientId IS NULL) AND 
(LocationId = @LocationId OR @LocationId IS NULL) AND 
(AssessmentId = @AssessmentId OR @AssessmentId IS NULL) AND 
--TaxYear IN(@TaxYear - 1,@TaxYear) AND
NOT GLCode IN ('INV', 'INVENTORY')

union 

SELECT asmt.ClientId, asmt.LocationId, asmt.AssessmentId, --asmt.TaxYear,
@TaxYear AS YearPurchased,'INV' AS GLCode
FROM Clients AS c 
INNER JOIN LocationsBPP AS l ON c.ClientId = l.ClientId 
INNER JOIN AssessmentsBPP AS asmt ON l.ClientId = asmt.ClientId AND 
l.LocationId = asmt.LocationId AND l.TaxYear = asmt.TaxYear
WHERE (asmt.ClientId = @ClientId OR @ClientId IS NULL) AND
(asmt.LocationId = @LocationId OR @LocationId IS NULL) AND
(asmt.AssessmentId = @AssessmentId OR @AssessmentId IS NULL) AND 
asmt.TaxYear = @TaxYear

union 

SELECT asmt.ClientId, asmt.LocationId, asmt.AssessmentId, --asmt.TaxYear,
@TaxYear AS YearPurchased,'INVENTORY' AS GLCode
FROM Clients AS c 
INNER JOIN LocationsBPP AS l ON c.ClientId = l.ClientId 
INNER JOIN AssessmentsBPP AS asmt ON l.ClientId = asmt.ClientId AND 
l.LocationId = asmt.LocationId AND l.TaxYear = asmt.TaxYear
WHERE (asmt.ClientId = @ClientId OR @ClientId IS NULL) AND
(asmt.LocationId = @LocationId OR @LocationId IS NULL) AND
(asmt.AssessmentId = @AssessmentId OR @AssessmentId IS NULL) AND 
asmt.TaxYear = @TaxYear
) as a1
) AS a2

on a2.ClientId=l1.ClientId and a2.LocationId=l1.LocationId and 
a2.AssessmentId = l1.AssessmentId 

where a2.PreviousYearCost > 0 or a2.CurrentYearCost > 0

order by l1.Clients_Name,l1.Address,l1.City,l1.StateCd, a2.GLCode,a2.YearPurchased


