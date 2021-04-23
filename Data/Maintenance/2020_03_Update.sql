use AssessmentManagerData
alter table jurisdictions add TaxDistrictCd varchar(50) null
alter table userquery add CurrentConsultantFl bit null
alter table bppcomps add UsageRate float null

exec UpdateDataDefinition

update FieldDefinition set QueryVisibleFl=1, QueryType=448 where TableName='Jurisdictions' and FieldName='TaxDistrictCd'

