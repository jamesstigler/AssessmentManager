--record retention fields
alter TABLE Clients add 
RecordRetentionYears smallint null

update Clients set RecordRetentionYears = 3

--manually modify clients to not null, default to 3

exec UpdateDataDefinition

update FieldDefinition set QueryType=1, QueryVisibleFl=1 where TableName='Clients' and FieldName='RecordRetentionYears'