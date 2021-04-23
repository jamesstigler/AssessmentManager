select a.AcctNum,a.ChangeUser, a.ChangeDate, 
ad.ClientId,ad.LocationId,ad.AssessmentId,ad.JurisdictionId,ad.TaxYear
from AssessmentDetailBPP ad, AssessmentsBPP a
where ad.ClientId=a.ClientId
and ad.LocationId=a.LocationId
and ad.AssessmentId=a.AssessmentId
and ad.TaxYear=a.TaxYear
and ad.TaxYear=2013
and not exists (
select ad2.ClientId from AssessmentDetailBPP ad2
where ad2.ClientId=ad.ClientId and ad2.LocationId=ad.LocationId
and ad2.AssessmentId=ad.AssessmentId 
and ad2.JurisdictionId=ad.JurisdictionId
and ad2.TaxYear=2014)
order by a.AcctNum

