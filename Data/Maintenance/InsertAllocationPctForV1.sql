--need to lookup when table was added to V1's system

insert AssetAllocationPct (ClientId,LocationId,AssessmentId,AssetId,FactorEntityId,TaxYear,AllocationPct,AddUser) 

select a.ClientId,a.LocationId,a.AssessmentId,a.AssetId,(select ab.FactorEntityId1 FROM AssessmentsBPP ab where ab.ClientId=a.ClientId and ab.LocationId=a.LocationId
and ab.AssessmentId = a.AssessmentId and ab.TaxYear = a.TaxYear  ),a.TaxYear, a.AllocationPct,'stigler'
from Assets a where a.AllocationPct >0 and a.AllocationPct <1
and a.TaxYear=2016
and not exists (select aap.* from AssetAllocationPct aap where aap.ClientId=a.ClientId and aap.LocationId=a.LocationId
and aap.AssessmentId=a.AssessmentId and aap.TaxYear=a.TaxYear and aap.AssetId=a.AssetId
and aap.FactorEntityId=
(select ab.FactorEntityId1 FROM AssessmentsBPP ab where ab.ClientId=a.ClientId and ab.LocationId=a.LocationId
and ab.AssessmentId = a.AssessmentId and ab.TaxYear = a.TaxYear  )
)
and (select ab.FactorEntityId1 FROM AssessmentsBPP ab where ab.ClientId=a.ClientId and ab.LocationId=a.LocationId
and ab.AssessmentId = a.AssessmentId and ab.TaxYear = a.TaxYear  ) is not null



insert AssetAllocationPct (ClientId,LocationId,AssessmentId,AssetId,FactorEntityId,TaxYear,AllocationPct,AddUser) 

select a.ClientId,a.LocationId,a.AssessmentId,a.AssetId,(select ab.FactorEntityId2 FROM AssessmentsBPP ab where ab.ClientId=a.ClientId and ab.LocationId=a.LocationId
and ab.AssessmentId = a.AssessmentId and ab.TaxYear = a.TaxYear  ),a.TaxYear, a.AllocationPct,'stigler'
from Assets a where a.AllocationPct >0 and a.AllocationPct <1
and a.TaxYear=2016
and not exists (select aap.* from AssetAllocationPct aap where aap.ClientId=a.ClientId and aap.LocationId=a.LocationId
and aap.AssessmentId=a.AssessmentId and aap.TaxYear=a.TaxYear and aap.AssetId=a.AssetId
and aap.FactorEntityId=
(select ab.FactorEntityId2 FROM AssessmentsBPP ab where ab.ClientId=a.ClientId and ab.LocationId=a.LocationId
and ab.AssessmentId = a.AssessmentId and ab.TaxYear = a.TaxYear  )
)
and (select ab.FactorEntityId2 FROM AssessmentsBPP ab where ab.ClientId=a.ClientId and ab.LocationId=a.LocationId
and ab.AssessmentId = a.AssessmentId and ab.TaxYear = a.TaxYear  ) is not null


insert AssetAllocationPct (ClientId,LocationId,AssessmentId,AssetId,FactorEntityId,TaxYear,AllocationPct,AddUser) 

select a.ClientId,a.LocationId,a.AssessmentId,a.AssetId,(select ab.FactorEntityId3 FROM AssessmentsBPP ab where ab.ClientId=a.ClientId and ab.LocationId=a.LocationId
and ab.AssessmentId = a.AssessmentId and ab.TaxYear = a.TaxYear  ),a.TaxYear, a.AllocationPct,'stigler'
from Assets a where a.AllocationPct >0 and a.AllocationPct <1
and a.TaxYear=2016
and not exists (select aap.* from AssetAllocationPct aap where aap.ClientId=a.ClientId and aap.LocationId=a.LocationId
and aap.AssessmentId=a.AssessmentId and aap.TaxYear=a.TaxYear and aap.AssetId=a.AssetId
and aap.FactorEntityId=
(select ab.FactorEntityId3 FROM AssessmentsBPP ab where ab.ClientId=a.ClientId and ab.LocationId=a.LocationId
and ab.AssessmentId = a.AssessmentId and ab.TaxYear = a.TaxYear  )
)
and (select ab.FactorEntityId3 FROM AssessmentsBPP ab where ab.ClientId=a.ClientId and ab.LocationId=a.LocationId
and ab.AssessmentId = a.AssessmentId and ab.TaxYear = a.TaxYear  ) is not null


insert AssetAllocationPct (ClientId,LocationId,AssessmentId,AssetId,FactorEntityId,TaxYear,AllocationPct,AddUser) 

select a.ClientId,a.LocationId,a.AssessmentId,a.AssetId,(select ab.FactorEntityId4 FROM AssessmentsBPP ab where ab.ClientId=a.ClientId and ab.LocationId=a.LocationId
and ab.AssessmentId = a.AssessmentId and ab.TaxYear = a.TaxYear  ),a.TaxYear, a.AllocationPct,'stigler'
from Assets a where a.AllocationPct >0 and a.AllocationPct <1
and a.TaxYear=2016
and not exists (select aap.* from AssetAllocationPct aap where aap.ClientId=a.ClientId and aap.LocationId=a.LocationId
and aap.AssessmentId=a.AssessmentId and aap.TaxYear=a.TaxYear and aap.AssetId=a.AssetId
and aap.FactorEntityId=
(select ab.FactorEntityId4 FROM AssessmentsBPP ab where ab.ClientId=a.ClientId and ab.LocationId=a.LocationId
and ab.AssessmentId = a.AssessmentId and ab.TaxYear = a.TaxYear  )
)
and (select ab.FactorEntityId4 FROM AssessmentsBPP ab where ab.ClientId=a.ClientId and ab.LocationId=a.LocationId
and ab.AssessmentId = a.AssessmentId and ab.TaxYear = a.TaxYear  ) is not null



insert AssetAllocationPct (ClientId,LocationId,AssessmentId,AssetId,FactorEntityId,TaxYear,AllocationPct,AddUser) 

select a.ClientId,a.LocationId,a.AssessmentId,a.AssetId,(select ab.FactorEntityId5 FROM AssessmentsBPP ab where ab.ClientId=a.ClientId and ab.LocationId=a.LocationId
and ab.AssessmentId = a.AssessmentId and ab.TaxYear = a.TaxYear  ),a.TaxYear, a.AllocationPct,'stigler'
from Assets a where a.AllocationPct >0 and a.AllocationPct <1
and a.TaxYear=2016
and not exists (select aap.* from AssetAllocationPct aap where aap.ClientId=a.ClientId and aap.LocationId=a.LocationId
and aap.AssessmentId=a.AssessmentId and aap.TaxYear=a.TaxYear and aap.AssetId=a.AssetId
and aap.FactorEntityId=
(select ab.FactorEntityId5 FROM AssessmentsBPP ab where ab.ClientId=a.ClientId and ab.LocationId=a.LocationId
and ab.AssessmentId = a.AssessmentId and ab.TaxYear = a.TaxYear  )
)
and (select ab.FactorEntityId5 FROM AssessmentsBPP ab where ab.ClientId=a.ClientId and ab.LocationId=a.LocationId
and ab.AssessmentId = a.AssessmentId and ab.TaxYear = a.TaxYear  ) is not null



select *  from AssessmentsBPP where AssessmentId=1097458937


select *  from Assets where AssessmentId=1097458937 and TaxYear=2016


SELECT   ClientId, LocationId, AssessmentId, TaxYear, AcctNum, FactorEntityId1 AS FactorEntityId
FROM      dbo.AssessmentsBPP AS ass
WHERE   (NOT (FactorEntityId1 IS NULL)) AND (TaxYear = 2016)
UNION SELECT   ClientId, LocationId, AssessmentId, TaxYear, AcctNum, FactorEntityId2 AS FactorEntityId
FROM      dbo.AssessmentsBPP AS ass
WHERE   (NOT (FactorEntityId2 IS NULL)) AND (TaxYear = 2016)
UNION SELECT   ClientId, LocationId, AssessmentId, TaxYear, AcctNum, FactorEntityId3 AS FactorEntityId
FROM      dbo.AssessmentsBPP AS ass
WHERE   (NOT (FactorEntityId3 IS NULL)) AND (TaxYear = 2016)
UNION SELECT   ClientId, LocationId, AssessmentId, TaxYear, AcctNum, FactorEntityId4 AS FactorEntityId
FROM      dbo.AssessmentsBPP AS ass
WHERE   (NOT (FactorEntityId4 IS NULL)) AND (TaxYear = 2016)
UNION SELECT   ClientId, LocationId, AssessmentId, TaxYear, AcctNum, FactorEntityId5  AS FactorEntityId
FROM      dbo.AssessmentsBPP AS ass
WHERE   (NOT (FactorEntityId5 IS NULL)) AND (TaxYear = 2016)
