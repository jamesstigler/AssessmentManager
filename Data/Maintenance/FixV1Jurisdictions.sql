select j.JurisdictionId,j.TaxYear,j.Name,j.StateCd,j.CollectorId,
jur2.JurisdictionId, jur2.TaxYear, jur2.Name,jur2.StateCd,jur2.lastyearscollectorid

--update Jurisdictions set CollectorId=jur2.lastyearscollectorid

from Jurisdictions j
inner join 
(select j2.JurisdictionId, j2.TaxYear,j2.Name, j2.StateCd, j2.CollectorId as lastyearscollectorid from 
Jurisdictions j2 
where j2.TaxYear=2013 and j2.CollectorId is not null) as jur2
on j.JurisdictionId=jur2.JurisdictionId

where j.CollectorId is null
and j.TaxYear=2014



