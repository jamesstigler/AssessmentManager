select * from Clients where ClientId in (572357574,519329130)

select * from LocationsBPP  where ClientId in (572357574,519329130)
select * from LocationsRE  where ClientId in (572357574,519329130)

select * from FieldDefinition where FieldName in ('ClientId','LocationId','AssessmentId') order by TableName, FieldName

select * from AssessmentDetailBPP where clientid=519329130
select * from AssessmentsBPP where clientid=519329130
--select * from AssessmentsBPPComments where clientid=519329130
select * from AssetAllocationPct where clientid=519329130
select * from Assets where clientid=519329130
select * from ClientFactorCodeOverrides where clientid=519329130
select * from FactorCodeOverrides where clientid=519329130
--select * from InstallmentsBPP where clientid=519329130
--select * from Inventory where clientid=519329130
--select * from LocationIssues where clientid=519329130
select * from LocationsBPP where clientid=519329130
--select * from TaxBillsBPP where clientid=519329130






