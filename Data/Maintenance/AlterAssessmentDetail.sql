alter TABLE AssessmentManagerData..assessmentdetailbpp add 
ClientFreeportAmt float null,
ClientAbatementAmt float null

alter TABLE assessmentdetailre add 
ClientAbatementAmt float null

exec UpdateDataDefinition

update FieldDefinition set QueryVisibleFl=1, QueryType=320 
where TableName='AssessmentDetailBPP' 
and FieldName in ('ClientAbatementAmt','ClientFreeportAmt')

update FieldDefinition set QueryVisibleFl=1, QueryType=384 
where TableName='AssessmentDetailRE' 
and FieldName in ('ClientAbatementAmt')

