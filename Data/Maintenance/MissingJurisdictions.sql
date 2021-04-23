use AssessmentManagerData
go


select tbl2012.PropType, tbl2012.Name,tbl2012.Address,
tbl2012.AcctNum,tbl2012.JurisdictionName, tbl2013.ChangeDate,tbl2013.ChangeUser,
tbl2013.PropType,tbl2012.ClientId, tbl2012.LocationId, 
tbl2012.AssessmentId ,tbl2012.JurisdictionId
from
(
SELECT 'BPP' as PropType,       a.ClientId, a.LocationId, ad.AssessmentId, ad.JurisdictionId, a.TaxYear, c.Name, l.Address, l.City, l.StateCd, a.AcctNum,
	j.Name as JurisdictionName, a.ChangeDate,a.ChangeUser
FROM            dbo.Clients AS c INNER JOIN
                         dbo.LocationsBPP AS l ON c.ClientId = l.ClientId INNER JOIN
                         dbo.AssessmentsBPP AS a ON l.ClientId = a.ClientId AND l.LocationId = a.LocationId AND l.TaxYear = a.TaxYear INNER JOIN
                         dbo.AssessmentDetailBPP AS ad ON a.ClientId = ad.ClientId AND a.LocationId = ad.LocationId AND a.AssessmentId = ad.AssessmentId AND 
                         a.TaxYear = ad.TaxYear
						 inner join dbo.Jurisdictions j 
						 on j.JurisdictionId=ad.JurisdictionId and j.TaxYear=ad.TaxYear
WHERE        (a.TaxYear = 2013)

union

SELECT 'Real' as PropType,       a.ClientId, a.LocationId, ad.AssessmentId, ad.JurisdictionId, a.TaxYear, c.Name, l.Address, l.City, l.StateCd, a.AcctNum,
	j.Name as JurisdictionName, a.ChangeDate,a.ChangeUser
FROM            dbo.Clients AS c INNER JOIN
                         dbo.LocationsRE AS l ON c.ClientId = l.ClientId INNER JOIN
                         dbo.AssessmentsRE AS a ON l.ClientId = a.ClientId AND l.LocationId = a.LocationId AND l.TaxYear = a.TaxYear INNER JOIN
                         dbo.AssessmentDetailRE AS ad ON a.ClientId = ad.ClientId AND a.LocationId = ad.LocationId AND a.AssessmentId = ad.AssessmentId AND 
                         a.TaxYear = ad.TaxYear
						 						 inner join dbo.Jurisdictions j 
						 on j.JurisdictionId=ad.JurisdictionId and j.TaxYear=ad.TaxYear

WHERE        (a.TaxYear = 2013)
) AS tbl2013

right outer join


(
SELECT 'BPP' as PropType,       a.ClientId, a.LocationId, ad.AssessmentId, ad.JurisdictionId, a.TaxYear, c.Name, l.Address, l.City, l.StateCd, a.AcctNum,
j.Name as JurisdictionName, a.ChangeDate,a.ChangeUser
FROM            dbo.Clients AS c INNER JOIN
                         dbo.LocationsBPP AS l ON c.ClientId = l.ClientId INNER JOIN
                         dbo.AssessmentsBPP AS a ON l.ClientId = a.ClientId AND l.LocationId = a.LocationId AND l.TaxYear = a.TaxYear INNER JOIN
                         dbo.AssessmentDetailBPP AS ad ON a.ClientId = ad.ClientId AND a.LocationId = ad.LocationId AND a.AssessmentId = ad.AssessmentId AND 
                         a.TaxYear = ad.TaxYear
						 						 inner join dbo.Jurisdictions j 
						 on j.JurisdictionId=ad.JurisdictionId and j.TaxYear=ad.TaxYear

WHERE        (a.TaxYear = 2012)

union

SELECT 'Real' as PropType,       a.ClientId, a.LocationId, ad.AssessmentId, ad.JurisdictionId, a.TaxYear, c.Name, l.Address, l.City, l.StateCd, a.AcctNum,
j.Name as JurisdictionName, a.ChangeDate,a.ChangeUser
FROM            dbo.Clients AS c INNER JOIN
                         dbo.LocationsRE AS l ON c.ClientId = l.ClientId INNER JOIN
                         dbo.AssessmentsRE AS a ON l.ClientId = a.ClientId AND l.LocationId = a.LocationId AND l.TaxYear = a.TaxYear INNER JOIN
                         dbo.AssessmentDetailRE AS ad ON a.ClientId = ad.ClientId AND a.LocationId = ad.LocationId AND a.AssessmentId = ad.AssessmentId AND 
                         a.TaxYear = ad.TaxYear
						 						 inner join dbo.Jurisdictions j 
						 on j.JurisdictionId=ad.JurisdictionId and j.TaxYear=ad.TaxYear

WHERE        (a.TaxYear = 2012)

) as tbl2012
on tbl2012.PropType=tbl2013.PropType
and tbl2012.ClientId=tbl2013.ClientId
and tbl2012.LocationId=tbl2013.LocationId
and tbl2012.AssessmentId=tbl2013.AssessmentId
and tbl2012.JurisdictionId=tbl2013.JurisdictionId
where tbl2013.PropType is null

order by 1,2,3,4,5

