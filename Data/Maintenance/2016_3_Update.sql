alter TABLE assessmentsre add 
OccupiedStatus varchar(255) null

exec UpdateDataDefinition


update FieldDefinition set QueryVisibleFl=1, QueryType=432 where TableName IN ('AssessmentsRE') and FieldName='OccupiedStatus'

insert FieldDataDefinition (TableName,FieldName,FieldValue) select 'AssessmentsRE','OccupiedStatus','Leased'
insert FieldDataDefinition (TableName,FieldName,FieldValue) select 'AssessmentsRE','OccupiedStatus','Owner Occupied'