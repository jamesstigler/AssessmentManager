alter TABLE Consultants add 
FullName varchar(255) null

alter table locationsbpp add
ConsultantName varchar(50) null

alter table locationsre add
ConsultantName varchar(50) null

alter table assessmentsbpp add
ParentAssessmentId bigint null

alter table assessmentsre add
ParentAssessmentId bigint null

exec UpdateDataDefinition


update FieldDefinition set QueryVisibleFl=1, QueryType=362 where TableName IN ('LocationsBPP') and FieldName='ConsultantName'
update FieldDefinition set QueryVisibleFl=1, QueryType=436 where TableName IN ('LocationsRE') and FieldName='ConsultantName'

--new spgetdocumentinfo stored proc also
