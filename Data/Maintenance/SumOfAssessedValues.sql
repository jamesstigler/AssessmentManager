SELECT        'BPP' AS PropType, c.Name AS ClientName, l.Address, l.City, l.StateCd, l.ClientLocationId, a.AcctNum, ass.Name AS AssessorName, MAX(ISNULL(ad.FinalValue, 0)) 
                         AS SumOfFinalValue
FROM            dbo.Clients AS c INNER JOIN
                         dbo.LocationsBPP AS l ON c.ClientId = l.ClientId INNER JOIN
                         dbo.AssessmentsBPP AS a ON l.ClientId = a.ClientId AND l.LocationId = a.LocationId AND l.TaxYear = a.TaxYear INNER JOIN
                         dbo.AssessmentDetailBPP AS ad ON a.ClientId = ad.ClientId AND a.LocationId = ad.LocationId AND a.AssessmentId = ad.AssessmentId AND 
                         a.TaxYear = ad.TaxYear LEFT OUTER JOIN
                         dbo.Assessors AS ass ON a.AssessorId = ass.AssessorId AND a.TaxYear = ass.TaxYear
WHERE        (l.TaxYear = 2014) AND (ISNULL(c.InactiveFl, 0) = 0) AND (ISNULL(c.ProspectFl, 0) = 0) AND (ISNULL(l.InactiveFl, 0) = 0) AND (ISNULL(a.InactiveFl, 0) = 0)
GROUP BY c.Name, l.Address, l.City, l.StateCd, l.ClientLocationId, a.AcctNum, ass.Name
union 
SELECT        'RE' AS PropType, c.Name AS ClientName, l.Address, l.City, l.StateCd, l.ClientLocationId, a.AcctNum, 
ass.Name AS AssessorName, MAX(ISNULL(ad.FinalValue, 0)) 
                         AS SumOfFinalValue
FROM            dbo.Clients AS c INNER JOIN
                         dbo.LocationsRE AS l ON c.ClientId = l.ClientId INNER JOIN
                         dbo.AssessmentsRE AS a ON l.ClientId = a.ClientId AND l.LocationId = a.LocationId AND l.TaxYear = a.TaxYear INNER JOIN
                         dbo.AssessmentDetailRE AS ad ON a.ClientId = ad.ClientId AND a.LocationId = ad.LocationId AND a.AssessmentId = ad.AssessmentId AND 
                         a.TaxYear = ad.TaxYear LEFT OUTER JOIN
                         dbo.Assessors AS ass ON a.AssessorId = ass.AssessorId AND a.TaxYear = ass.TaxYear
WHERE        (l.TaxYear = 2014) AND (ISNULL(c.InactiveFl, 0) = 0) AND (ISNULL(c.ProspectFl, 0) = 0) AND (ISNULL(l.InactiveFl, 0) = 0) AND (ISNULL(a.InactiveFl, 0) = 0)
GROUP BY c.Name, l.Address, l.City, l.StateCd, l.ClientLocationId, a.AcctNum, ass.Name