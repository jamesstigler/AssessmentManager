use AssessmentManagerData

alter table AssessmentsBPP add AssetsLoadedFl bit null,AssetsVerifiedFl bit null, AssetsLoadedDate datetime null, AssetsVerifiedDate datetime null

exec UpdateDataDefinition

update FieldDefinition set QueryVisibleFl=1, QueryType=360 
where TableName='AssessmentsBPP' and FieldName in ('AssetsLoadedFl','AssetsVerifiedFl','AssetsLoadedDate','AssetsVerifiedDate')


