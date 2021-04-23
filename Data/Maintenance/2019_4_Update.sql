new spGetAssetList stored proc

ALTER TABLE Clients ADD 
InterstateAllocationFl bit null

ALTER TABLE AssessmentsBPP ADD 
InterstateAllocationFl bit null

exec UpdateDataDefinition

update FieldDefinition set QueryType=360, QueryVisibleFl=1 where TableName in ('AssessmentsBPP') and FieldName IN ('InterstateAllocationFl')
update FieldDefinition set QueryType=4095, QueryVisibleFl=1 where TableName in ('Clients') and FieldName IN ('InterstateAllocationFl')

