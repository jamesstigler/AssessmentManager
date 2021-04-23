--new spgetassetlist stored proc

ALTER TABLE AssessmentsBPP ADD 
AccountInvoicedStatus varchar(50) null

ALTER TABLE AssessmentsRE ADD 
AccountInvoicedStatus varchar(50) null

ALTER TABLE Assets ADD 
LessorName varchar(50) null,
LessorAddress varchar(255) null,
LeaseTerm smallint null,
EquipmentMake varchar(50) null,
EquipmentModel varchar(50) null,
LeaseType varchar(50) null

exec UpdateDataDefinition

update FieldDefinition set QueryType=360, QueryVisibleFl=1 where TableName in ('AssessmentsBPP') and FieldName IN ('AccountInvoicedStatus')
update FieldDefinition set QueryType=432, QueryVisibleFl=1 where TableName in ('AssessmentsRE') and FieldName IN ('AccountInvoicedStatus')

DELETE FieldDataDefinition WHERE TableName IN('AssessmentsBPP','AssessmentsRE') AND FieldName IN ('AccountInvoicedStatus')
INSERT FieldDataDefinition (TableName,FieldName,FieldValue) VALUES 
('AssessmentsBPP','AccountInvoicedStatus','Pending'),
('AssessmentsBPP','AccountInvoicedStatus','Invoiced'),
('AssessmentsRE','AccountInvoicedStatus','Pending'),
('AssessmentsRE','AccountInvoicedStatus','Invoiced')

DELETE FieldDataDefinition WHERE TableName IN('Assets') AND FieldName IN ('LeaseType')
INSERT FieldDataDefinition (TableName,FieldName,FieldValue) VALUES 
('Assets','LeaseType','Leased Equipment'),
('Assets','LeaseType','Leased Vehicles'),
('Assets','LeaseType','Leasehold Improvements')

