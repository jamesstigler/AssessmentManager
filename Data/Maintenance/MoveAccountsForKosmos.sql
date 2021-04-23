This set of scripts re-assigns locations and assessments to a new client.  It
actually just creates new records but does not delete anything.

It creates temp tables with existing locationid/assessmentid values
from the "From" client and their new locationid/assessmentid 
values (NewLocationId,OldLocationId)

It then inserts new records for all the location/assessment tables with 
the new locationid/assessmentid values and the "To" clientid


Would you please make that correction?  Anywhere the Client is listed as Kosmos Energy Gulf of Mexico
(should be 16 records where KEGOM is the Client), please correct to Kosmos Energy as the Client 
and the Legal Owner will be Kosmos Energy Gulf of Mexico.


select ProspectFl, * from clients where name like 'kosmos%'
  

1.  Verify table structures have not changed
2.  check to see what smallest locationid and assessmentid numbers are
    hopefully they are pretty high (new locationid/assessmentid values
	should start at lowest + 1)  Remember to change the seed in the 
	Identity tables

	select distinct top 500 LocationId from LocationsBPP order by LocationId
--	select distinct top 500 LocationId from LocationsRE order by LocationId
	select distinct top 500 AssessmentId from AssessmentsBPP order by AssessmentId
--	select distinct top 500 AssessmentId from AssessmentsRE order by AssessmentId

3.  run the first part (up through loading the temp tables) to get an idea
    of the maximum number of locationid (may use that number to delete if
    things do not work the first time

Do this if account inserts fail at any point.  Still have the original
data, but need to delete these new records that have the "To" clientid
/**
declare @beginlocationid bigint,@endlocationid bigint
select @beginlocationid = 436, @endlocationid = 451
delete  FactorCodeOverrides where LocationId BETWEEN  @beginlocationid and @endlocationid
delete  ClientFactorCodeOverrides where LocationId BETWEEN  @beginlocationid and @endlocationid
delete  AssetAllocationPct where LocationId BETWEEN @beginlocationid and @endlocationid
delete  Assets where LocationId BETWEEN  @beginlocationid and @endlocationid
delete  InstallmentsBPP where LocationId BETWEEN  @beginlocationid and @endlocationid
delete  InstallmentsRE where LocationId BETWEEN  @beginlocationid and @endlocationid
delete  AssessmentsBPPComments where LocationId BETWEEN @beginlocationid and @endlocationid
delete  TaxBillsBPP where LocationId BETWEEN  @beginlocationid and @endlocationid
delete  TaxBillsRE where LocationId BETWEEN  @beginlocationid and @endlocationid
delete  AssessmentDetailBPP where LocationId BETWEEN @beginlocationid and @endlocationid
delete  AssessmentDetailRE where LocationId BETWEEN @beginlocationid and @endlocationid
delete  AssessmentsBPP where LocationId BETWEEN @beginlocationid and @endlocationid
delete  AssessmentsRE where LocationId BETWEEN @beginlocationid and @endlocationid
delete  LocationsBPP where LocationId BETWEEN  @beginlocationid and @endlocationid
delete  LocationsRE where LocationId BETWEEN  @beginlocationid and @endlocationid
**/
4.  run the last update statement on the client table if all works




IF  EXISTS
(SELECT * FROM tempdb.sys.objects 
WHERE object_id = OBJECT_ID(N'[tempdb].[dbo].[tempbpplocations]') 
AND type in (N'U'))
DROP TABLE [tempdb].[dbo].[tempbpplocations]
create table tempdb.dbo.tempbpplocations
--IDENTITY seed comes from gap between previous data moves and a valid client
--Previous moves began with ClientId=1 up to ClientId=83
(	[NewLocationId] [bigint] IDENTITY(436,1) NOT NULL,				
	[OldLocationId] [bigint] NOT NULL
)
IF  EXISTS
(SELECT * FROM tempdb.sys.objects 
WHERE object_id = OBJECT_ID(N'[tempdb].[dbo].[temprelocations]') 
AND type in (N'U'))
DROP TABLE [tempdb].[dbo].[temprelocations]
create table tempdb.dbo.temprelocations
--IDENTITY seed comes from gap between previous data moves and a valid client
--Previous moves began with ClientId=1 up to ClientId=83
(	[NewLocationId] [bigint] IDENTITY(436,1) NOT NULL,				
	[OldLocationId] [bigint] NOT NULL
)
IF  EXISTS
(SELECT * FROM tempdb.sys.objects 
WHERE object_id = OBJECT_ID(N'[tempdb].[dbo].[tempbppassessments]') 
AND type in (N'U'))
DROP TABLE [tempdb].[dbo].[tempbppassessments]
create table tempdb.dbo.tempbppassessments
(	[NewAssessmentId] [bigint] IDENTITY(436,1) NOT NULL,
	[OldAssessmentId] [bigint] NOT NULL
)
IF  EXISTS
(SELECT * FROM tempdb.sys.objects 
WHERE object_id = OBJECT_ID(N'[tempdb].[dbo].[tempreassessments]') 
AND type in (N'U'))
DROP TABLE [tempdb].[dbo].[tempreassessments]
create table tempdb.dbo.tempreassessments
(	[NewAssessmentId] [bigint] IDENTITY(436,1) NOT NULL,
	[OldAssessmentId] [bigint] NOT NULL
)



declare @ToClientId bigint,@FromClientId bigint
declare @numrows bigint


select @ToClientId=1576971057, @FromClientId=1625233594


insert into tempdb.dbo.tempbpplocations (OldLocationId)
select distinct l.LocationId
from LocationsBPP AS l, AssessmentsBPP AS a where l.ClientId = @FromClientId
AND a.LocationId = l.LocationId
insert into tempdb.dbo.temprelocations (OldLocationId)
select distinct l.LocationId
from LocationsRE AS l, AssessmentsRE AS a where l.ClientId = @FromClientId
AND a.LocationId = l.LocationId



select @numrows=0
select @numrows = (select COUNT(*) from tempdb.dbo.tempbpplocations
where NewLocationId in 
(select LocationId from LocationsBPP))
if @numrows>0
	begin
		select 'Found duplicate locationid'
		return
	end
select @numrows=0
select @numrows = (select COUNT(*) from tempdb.dbo.temprelocations
where NewLocationId in 
(select LocationId from LocationsRE))
if @numrows>0
	begin
		select 'Found duplicate locationid'
		return
	end



insert into tempdb.dbo.tempbppassessments (OldAssessmentId)
select distinct AssessmentId
from AssessmentsBPP where ClientId = @FromClientId
insert into tempdb.dbo.tempreassessments (OldAssessmentId)
select distinct AssessmentId
from AssessmentsRE where ClientId = @FromClientId


select @numrows=0
select @numrows = (select COUNT(*) from tempdb.dbo.tempbppassessments
where NewAssessmentId in 
(select AssessmentId from AssessmentsBPP))
if @numrows>0
	begin
		select 'Found duplicate assessmentid'
		return
	end
select @numrows=0
select @numrows = (select COUNT(*) from tempdb.dbo.tempreassessments
where NewAssessmentId in 
(select AssessmentId from AssessmentsRE))
if @numrows>0
	begin
		select 'Found duplicate assessmentid'
		return
	end



--run this to get range of new locationid
/**
select * from tempdb..tempbpplocations

**/


-------------VERIFY data in temp tables BEFORE RUNNING INSERTS----------------
-------------  MUST RUN SCRIPT BEGINNING WITH TEMP TABLE DROP/CREATE
-------------  BUT RUN UP TO THIS POINT TO VERIFY DATA IN TEMP TABLES



INSERT INTO LocationsBPP
      ([ClientId]
      ,[LocationId]
      ,[TaxYear]
      ,[Address]
      ,[Name]
      ,[City]
      ,[StateCd]
      ,[Zip]
      ,[LegalDescription]
      ,[LegalOwner]
      ,[ClientLocationId]
      ,[Comment]
      ,[AddDate]
      ,[AddUser]
      ,[ChangeDate]
      ,[ChangeUser]
      ,[ChangeType]
      ,[CustomFl1]
      ,[CustomFl2]
      ,[CustomFl3]
      ,[CustomDate1]
      ,[CustomDate2]
      ,[CustomDate3]
      ,[CustomText1]
      ,[CustomText2]
      ,[CustomText3]
      ,[InactiveFl]
      ,[ConsultantName])
SELECT @ToClientId,t.NewLocationId
      ,[TaxYear]
      ,[Address]
      ,[Name]
      ,[City]
      ,[StateCd]
      ,[Zip]
      ,[LegalDescription]
      ,'Kosmos Energy Gulf of Mexico'
      ,[ClientLocationId]
      ,[Comment]
      ,[AddDate]
      ,[AddUser]
      ,[ChangeDate]
      ,[ChangeUser]
      ,[ChangeType]
      ,[CustomFl1]
      ,[CustomFl2]
      ,[CustomFl3]
      ,[CustomDate1]
      ,[CustomDate2]
      ,[CustomDate3]
      ,[CustomText1]
      ,[CustomText2]
      ,[CustomText3]
      ,[InactiveFl]
      ,[ConsultantName]
FROM [dbo].[LocationsBPP] l,
tempdb..tempbpplocations t where l.ClientId = @FromClientId and l.LocationId = t.OldLocationId and l.TaxYear=2020








INSERT INTO LocationsRE
      ([ClientId]
      ,[LocationId]
      ,[TaxYear]
      ,[Address]
      ,[Name]
      ,[City]
      ,[StateCd]
      ,[Zip]
      ,[LegalDescription]
      ,[LegalOwner]
      ,[ClientLocationId]
      ,[Comment]
      ,[AddDate]
      ,[AddUser]
      ,[ChangeDate]
      ,[ChangeUser]
      ,[ChangeType]
      ,[CustomFl1]
      ,[CustomFl2]
      ,[CustomFl3]
      ,[CustomDate1]
      ,[CustomDate2]
      ,[CustomDate3]
      ,[CustomText1]
      ,[CustomText2]
      ,[CustomText3]
      ,[InactiveFl]
      ,[ConsultantName])
SELECT @ToClientId,t.NewLocationId
      ,[TaxYear]
      ,[Address]
      ,[Name]
      ,[City]
      ,[StateCd]
      ,[Zip]
      ,[LegalDescription]
      ,[LegalOwner]
      ,[ClientLocationId]
      ,[Comment]
      ,[AddDate]
      ,[AddUser]
      ,[ChangeDate]
      ,[ChangeUser]
      ,[ChangeType]
      ,[CustomFl1]
      ,[CustomFl2]
      ,[CustomFl3]
      ,[CustomDate1]
      ,[CustomDate2]
      ,[CustomDate3]
      ,[CustomText1]
      ,[CustomText2]
      ,[CustomText3]
      ,[InactiveFl]
      ,[ConsultantName]
  FROM [dbo].[LocationsRE] l,
tempdb..temprelocations t where l.ClientId = @FromClientId and l.LocationId = t.OldLocationId and l.TaxYear=2020






INSERT INTO AssessmentsBPP
      ([ClientId]
      ,[LocationId]
      ,[AssessmentId]
      ,[TaxYear]
      ,[AssessorId]
      ,[AcctNum]
      ,[Comment]
      ,[CustomFl1]
      ,[CustomFl2]
      ,[CustomFl3]
      ,[CustomText1]
      ,[CustomText2]
      ,[CustomText3]
      ,[CustomNumber1]
      ,[CustomNumber2]
      ,[CustomNumber3]
      ,[CustomDate1]
      ,[CustomDate2]
      ,[CustomDate3]
      ,[FactorEntityId1]
      ,[FactorEntityId2]
      ,[FactorEntityId3]
      ,[FactorEntityId4]
      ,[FactorEntityId5]
      ,[AddDate]
      ,[AddUser]
      ,[ChangeDate]
      ,[ChangeUser]
      ,[ChangeType]
      ,[JurDiffValFl]
      ,[ProspectFl]
      ,[ValueProtestMailedDate]
      ,[ValueProtestHearingDate]
      ,[ValueProtestStatus]
      ,[ValueProtestDeadlineDate]
      ,[ValueProtestCMRRR]
      ,[FreeportProtestFl]
      ,[ValueProtestFl]
      ,[FreeportProtestMailedDate]
      ,[FreeportProtestHearingDate]
      ,[FreeportProtestStatus]
      ,[FreeportProtestDeadlineDate]
      ,[FreeportProtestCMRRR]
      ,[InactiveFl]
      ,[RenditionMailedDate]
      ,[RenditionCMRRR]
      ,[RenditionExtCMRRR]
      ,[RenditionExtMailedDate]
      ,[OtherProtest1]
      ,[OtherProtest1DeadlineDate]
      ,[OtherProtest1MailedDate]
      ,[OtherProtest1CMRRR]
      ,[OtherProtest1Status]
      ,[OtherProtest1HearingDate]
      ,[RenditionDeadlineDate]
      ,[RenditionExtDeadlineDate]
      ,[ClientRenditionValue]
      ,[SavingsExclusionCd]
      ,[ParentAssessmentId]
      ,[RenditionCompleteFl]
      ,[RenditionCompleteDate]
      ,[BusinessUnitId]
	  ,AccountInvoicedStatus
	  ,InterstateAllocationFl)
SELECT @ToClientId,tl.NewLocationId,ta.NewAssessmentId
      ,[TaxYear]
      ,[AssessorId]
      ,[AcctNum]
      ,[Comment]
      ,[CustomFl1]
      ,[CustomFl2]
      ,[CustomFl3]
      ,[CustomText1]
      ,[CustomText2]
      ,[CustomText3]
      ,[CustomNumber1]
      ,[CustomNumber2]
      ,[CustomNumber3]
      ,[CustomDate1]
      ,[CustomDate2]
      ,[CustomDate3]
      ,[FactorEntityId1]
      ,[FactorEntityId2]
      ,[FactorEntityId3]
      ,[FactorEntityId4]
      ,[FactorEntityId5]
      ,[AddDate]
      ,[AddUser]
      ,[ChangeDate]
      ,[ChangeUser]
      ,[ChangeType]
      ,[JurDiffValFl]
      ,[ProspectFl]
      ,[ValueProtestMailedDate]
      ,[ValueProtestHearingDate]
      ,[ValueProtestStatus]
      ,[ValueProtestDeadlineDate]
      ,[ValueProtestCMRRR]
      ,[FreeportProtestFl]
      ,[ValueProtestFl]
      ,[FreeportProtestMailedDate]
      ,[FreeportProtestHearingDate]
      ,[FreeportProtestStatus]
      ,[FreeportProtestDeadlineDate]
      ,[FreeportProtestCMRRR]
      ,[InactiveFl]
      ,[RenditionMailedDate]
      ,[RenditionCMRRR]
      ,[RenditionExtCMRRR]
      ,[RenditionExtMailedDate]
      ,[OtherProtest1]
      ,[OtherProtest1DeadlineDate]
      ,[OtherProtest1MailedDate]
      ,[OtherProtest1CMRRR]
      ,[OtherProtest1Status]
      ,[OtherProtest1HearingDate]
      ,[RenditionDeadlineDate]
      ,[RenditionExtDeadlineDate]
      ,[ClientRenditionValue]
      ,[SavingsExclusionCd]
      ,[ParentAssessmentId]
      ,[RenditionCompleteFl]
      ,[RenditionCompleteDate]
      ,[BusinessUnitId]
	  ,AccountInvoicedStatus
	  ,InterstateAllocationFl
FROM [dbo].[AssessmentsBPP] a, 
tempdb.dbo.tempbpplocations tl, tempdb.dbo.tempbppassessments ta
WHERE a.ClientId=@FromClientId 
AND a.LocationId=tl.OldLocationId
AND a.AssessmentId = ta.OldAssessmentId  and a.TaxYear=2020












INSERT INTO AssessmentsRE
      ([ClientId]
      ,[LocationId]
      ,[AssessmentId]
      ,[TaxYear]
      ,[AssessorId]
      ,[AcctNum]
      ,[Comment]
      ,[CustomFl1]
      ,[CustomFl2]
      ,[CustomFl3]
      ,[CustomText1]
      ,[CustomText2]
      ,[CustomText3]
      ,[CustomNumber1]
      ,[CustomNumber2]
      ,[CustomNumber3]
      ,[CustomDate1]
      ,[CustomDate2]
      ,[CustomDate3]
      ,[AddDate]
      ,[AddUser]
      ,[ChangeDate]
      ,[ChangeUser]
      ,[ChangeType]
      ,[JurDiffValFl]
      ,[ProspectFl]
      ,[ValueProtestMailedDate]
      ,[ValueProtestHearingDate]
      ,[ValueProtestStatus]
      ,[ValueProtestDeadlineDate]
      ,[ValueProtestCMRRR]
      ,[ValueProtestFl]
      ,[InactiveFl]
      ,[LastYearsFinalValue]
      ,[SavingsExclusionCd]
      ,[ParentAssessmentId]
      ,[OccupiedStatus]
      ,[BusinessUnitId]
	  ,AccountInvoicedStatus)
SELECT @ToClientId,tl.NewLocationId,ta.NewAssessmentId
      ,[TaxYear]
      ,[AssessorId]
      ,[AcctNum]
      ,[Comment]
      ,[CustomFl1]
      ,[CustomFl2]
      ,[CustomFl3]
      ,[CustomText1]
      ,[CustomText2]
      ,[CustomText3]
      ,[CustomNumber1]
      ,[CustomNumber2]
      ,[CustomNumber3]
      ,[CustomDate1]
      ,[CustomDate2]
      ,[CustomDate3]
      ,[AddDate]
      ,[AddUser]
      ,[ChangeDate]
      ,[ChangeUser]
      ,[ChangeType]
      ,[JurDiffValFl]
      ,[ProspectFl]
      ,[ValueProtestMailedDate]
      ,[ValueProtestHearingDate]
      ,[ValueProtestStatus]
      ,[ValueProtestDeadlineDate]
      ,[ValueProtestCMRRR]
      ,[ValueProtestFl]
      ,[InactiveFl]
      ,[LastYearsFinalValue]
      ,[SavingsExclusionCd]
      ,[ParentAssessmentId]
      ,[OccupiedStatus]
      ,[BusinessUnitId]
	  ,AccountInvoicedStatus
  FROM [dbo].[AssessmentsRE] a, 
tempdb.dbo.temprelocations tl, tempdb.dbo.tempreassessments ta
WHERE a.ClientId=@FromClientId 
AND a.LocationId=tl.OldLocationId
AND a.AssessmentId = ta.OldAssessmentId and a.TaxYear=2020









INSERT INTO AssessmentsBPPComments
      ([ClientId]
      ,[LocationId]
      ,[AssessmentId]
      ,[CommentType]
      ,[TaxYear]
      ,[Comment]
      ,[AddDate]
      ,[AddUser]
      ,[ChangeDate]
      ,[ChangeUser]
      ,[ChangeType])
SELECT @ToClientId,tl.NewLocationId,ta.NewAssessmentId
      ,[CommentType]
      ,[TaxYear]
      ,[Comment]
      ,[AddDate]
      ,[AddUser]
      ,[ChangeDate]
      ,[ChangeUser]
      ,[ChangeType]
FROM [dbo].[AssessmentsBPPComments] a, 
tempdb.dbo.tempbpplocations tl, tempdb.dbo.tempbppassessments ta
WHERE a.ClientId=@FromClientId 
AND a.LocationId=tl.OldLocationId
AND a.AssessmentId = ta.OldAssessmentId and a.TaxYear=2020







INSERT INTO AssessmentDetailBPP
      ([ClientId]
      ,[LocationId]
      ,[AssessmentId]
      ,[JurisdictionId]
      ,[TaxYear]
      ,[NotifiedValue]
      ,[ConsultantValue]
      ,[FinalValue]
      ,[AddDate]
      ,[AddUser]
      ,[ChangeDate]
      ,[ChangeUser]
      ,[ChangeType]
      ,[AdjAmt1]
      ,[AdjDesc1]
      ,[AdjAmt2]
      ,[AdjDesc2]
      ,[AdjAmt3]
      ,[AdjDesc3]
      ,[FreeportReductionAmt]
      ,[AbatementReductionAmt]
      ,[TaxBillAdjAmt1]
      ,[TaxBillAdjDesc1]
      ,[TaxBillAdjAmt2]
      ,[TaxBillAdjDesc2]
      ,[TaxBillPrintedDate]
      ,[TaxBillPrintedUser]
      ,[PenaltyAmt1]
      ,[ClientFreeportAmt]
      ,[ClientAbatementAmt])
SELECT @ToClientId,tl.NewLocationId,ta.NewAssessmentId
      ,[JurisdictionId]
      ,[TaxYear]
      ,[NotifiedValue]
      ,[ConsultantValue]
      ,[FinalValue]
      ,[AddDate]
      ,[AddUser]
      ,[ChangeDate]
      ,[ChangeUser]
      ,[ChangeType]
      ,[AdjAmt1]
      ,[AdjDesc1]
      ,[AdjAmt2]
      ,[AdjDesc2]
      ,[AdjAmt3]
      ,[AdjDesc3]
      ,[FreeportReductionAmt]
      ,[AbatementReductionAmt]
      ,[TaxBillAdjAmt1]
      ,[TaxBillAdjDesc1]
      ,[TaxBillAdjAmt2]
      ,[TaxBillAdjDesc2]
      ,[TaxBillPrintedDate]
      ,[TaxBillPrintedUser]
      ,[PenaltyAmt1]
      ,[ClientFreeportAmt]
      ,[ClientAbatementAmt]
  FROM [dbo].[AssessmentDetailBPP] a, 
tempdb.dbo.tempbpplocations tl, tempdb.dbo.tempbppassessments ta
WHERE a.ClientId=@FromClientId 
AND a.LocationId=tl.OldLocationId
AND a.AssessmentId = ta.OldAssessmentId and a.TaxYear=2020










INSERT INTO AssessmentDetailRE
      ([ClientId]
      ,[LocationId]
      ,[AssessmentId]
      ,[JurisdictionId]
      ,[TaxYear]
      ,[ConsultantValue]
      ,[FinalValue]
      ,[RELandValue]
      ,[REImprovementValue]
      ,[AddDate]
      ,[AddUser]
      ,[ChangeDate]
      ,[ChangeUser]
      ,[ChangeType]
      ,[AdjAmt1]
      ,[AdjDesc1]
      ,[AdjAmt2]
      ,[AdjDesc2]
      ,[AdjAmt3]
      ,[AdjDesc3]
      ,[AbatementReductionAmt]
      ,[TaxBillAdjAmt1]
      ,[TaxBillAdjDesc1]
      ,[TaxBillAdjAmt2]
      ,[TaxBillAdjDesc2]
      ,[TotalAssessedValue]
      ,[TaxBillPrintedDate]
      ,[TaxBillPrintedUser]
      ,[PenaltyAmt1]
      ,[ClientAbatementAmt])
SELECT @ToClientId,tl.NewLocationId,ta.NewAssessmentId
      ,[JurisdictionId]
      ,[TaxYear]
      ,[ConsultantValue]
      ,[FinalValue]
      ,[RELandValue]
      ,[REImprovementValue]
      ,[AddDate]
      ,[AddUser]
      ,[ChangeDate]
      ,[ChangeUser]
      ,[ChangeType]
      ,[AdjAmt1]
      ,[AdjDesc1]
      ,[AdjAmt2]
      ,[AdjDesc2]
      ,[AdjAmt3]
      ,[AdjDesc3]
      ,[AbatementReductionAmt]
      ,[TaxBillAdjAmt1]
      ,[TaxBillAdjDesc1]
      ,[TaxBillAdjAmt2]
      ,[TaxBillAdjDesc2]
      ,[TotalAssessedValue]
      ,[TaxBillPrintedDate]
      ,[TaxBillPrintedUser]
      ,[PenaltyAmt1]
      ,[ClientAbatementAmt]
FROM [dbo].[AssessmentDetailRE] a, 
tempdb.dbo.temprelocations tl, tempdb.dbo.tempreassessments ta
WHERE a.ClientId=@FromClientId 
AND a.LocationId=tl.OldLocationId
AND a.AssessmentId = ta.OldAssessmentId and a.TaxYear=2020








INSERT INTO Assets
      ([ClientId]
      ,[LocationId]
      ,[AssessmentId]
      ,[AssetId]
      ,[TaxYear]
      ,[OriginalCost]
      ,[PurchaseDate]
      ,[Description]
      ,[GLCode]
      ,[Future1]
      ,[AddDate]
      ,[AddUser]
      ,[ChangeDate]
      ,[ChangeUser]
      ,[ChangeType]
      ,[VIN]
      ,[LocationAddress]
      ,[AllocationPct]
	  ,LessorName
	  ,LessorAddress
	  ,LeaseTerm
	  ,EquipmentMake
	  ,EquipmentModel
	  ,LeaseType)
SELECT @ToClientId,tl.NewLocationId,ta.NewAssessmentId
      ,[AssetId]
      ,[TaxYear]
      ,[OriginalCost]
      ,[PurchaseDate]
      ,[Description]
      ,[GLCode]
      ,[Future1]
      ,[AddDate]
      ,[AddUser]
      ,[ChangeDate]
      ,[ChangeUser]
      ,[ChangeType]
      ,[VIN]
      ,[LocationAddress]
      ,[AllocationPct]
	  ,LessorName
	  ,LessorAddress
	  ,LeaseTerm
	  ,EquipmentMake
	  ,EquipmentModel
	  ,LeaseType
  FROM [dbo].[Assets] a, 
tempdb.dbo.tempbpplocations tl, tempdb.dbo.tempbppassessments ta
WHERE a.ClientId=@FromClientId 
AND a.LocationId=tl.OldLocationId
AND a.AssessmentId = ta.OldAssessmentId and a.TaxYear=2020









INSERT INTO ClientFactorCodeOverrides
      ([ClientId]
      ,[LocationId]
      ,[AssessmentId]
      ,[AssetId]
      ,[FactorEntityId]
      ,[TaxYear]
      ,[FactorCode]
      ,[AddDate]
      ,[AddUser]
      ,[ChangeDate]
      ,[ChangeUser]
      ,[ChangeType])
SELECT @ToClientId,tl.NewLocationId,ta.NewAssessmentId
      ,[AssetId]
      ,[FactorEntityId]
      ,[TaxYear]
      ,[FactorCode]
      ,[AddDate]
      ,[AddUser]
      ,[ChangeDate]
      ,[ChangeUser]
      ,[ChangeType]
  FROM [dbo].[ClientFactorCodeOverrides] a, 
tempdb.dbo.tempbpplocations tl, tempdb.dbo.tempbppassessments ta
WHERE a.ClientId=@FromClientId 
AND a.LocationId=tl.OldLocationId
AND a.AssessmentId = ta.OldAssessmentId and a.TaxYear=2020







INSERT INTO FactorCodeOverrides
      ([ClientId]
      ,[LocationId]
      ,[AssessmentId]
      ,[AssetId]
      ,[FactorEntityId]
      ,[TaxYear]
      ,[FactorCode]
      ,[AddDate]
      ,[AddUser]
      ,[ChangeDate]
      ,[ChangeUser]
      ,[ChangeType])
SELECT @ToClientId,tl.NewLocationId,ta.NewAssessmentId
      ,[AssetId]
      ,[FactorEntityId]
      ,[TaxYear]
      ,[FactorCode]
      ,[AddDate]
      ,[AddUser]
      ,[ChangeDate]
      ,[ChangeUser]
      ,[ChangeType]
  FROM [dbo].[FactorCodeOverrides] a, 
tempdb.dbo.tempbpplocations tl, tempdb.dbo.tempbppassessments ta
WHERE a.ClientId=@FromClientId 
AND a.LocationId=tl.OldLocationId
AND a.AssessmentId = ta.OldAssessmentId and a.TaxYear=2020







INSERT INTO AssetAllocationPct
      ([ClientId]
      ,[LocationId]
      ,[AssessmentId]
      ,[AssetId]
      ,[FactorEntityId]
      ,[TaxYear]
      ,[AllocationPct]
      ,[AddDate]
      ,[AddUser]
      ,[ChangeDate]
      ,[ChangeUser]
      ,[ChangeType]
      ,[InterstateAllocationPct])
SELECT @ToClientId,tl.NewLocationId,ta.NewAssessmentId
      ,[AssetId]
      ,[FactorEntityId]
      ,[TaxYear]
      ,[AllocationPct]
      ,[AddDate]
      ,[AddUser]
      ,[ChangeDate]
      ,[ChangeUser]
      ,[ChangeType]
      ,[InterstateAllocationPct]
  FROM [dbo].[AssetAllocationPct] a, 
tempdb.dbo.tempbpplocations tl, tempdb.dbo.tempbppassessments ta
WHERE a.ClientId=@FromClientId 
AND a.LocationId=tl.OldLocationId
AND a.AssessmentId = ta.OldAssessmentId and a.TaxYear=2020







INSERT INTO InstallmentsBPP
      ([ClientId]
      ,[LocationId]
      ,[AssessmentId]
      ,[CollectorId]
      ,[TaxYear]
      ,[PayFromDt]
      ,[PayToDt]
      ,[PayAmt]
      ,[PaidFl]
      ,[PaidDt]
      ,[AddDate]
      ,[AddUser]
      ,[ChangeDate]
      ,[ChangeUser]
      ,[ChangeType]
      ,[DueDate]
      ,[TaxBillPrintedDate]
      ,[TaxBillPrintedUser])
SELECT @ToClientId,tl.NewLocationId,ta.NewAssessmentId
      ,[CollectorId]
      ,[TaxYear]
      ,[PayFromDt]
      ,[PayToDt]
      ,[PayAmt]
      ,[PaidFl]
      ,[PaidDt]
      ,[AddDate]
      ,[AddUser]
      ,[ChangeDate]
      ,[ChangeUser]
      ,[ChangeType]
      ,[DueDate]
      ,[TaxBillPrintedDate]
      ,[TaxBillPrintedUser]
FROM [dbo].[InstallmentsBPP] a, 
tempdb.dbo.tempbpplocations tl, tempdb.dbo.tempbppassessments ta
WHERE a.ClientId=@FromClientId 
AND a.LocationId=tl.OldLocationId
AND a.AssessmentId = ta.OldAssessmentId and a.TaxYear=2020






INSERT INTO InstallmentsRE
      ([ClientId]
      ,[LocationId]
      ,[AssessmentId]
      ,[CollectorId]
      ,[TaxYear]
      ,[PayFromDt]
      ,[PayToDt]
      ,[PayAmt]
      ,[PaidFl]
      ,[PaidDt]
      ,[AddDate]
      ,[AddUser]
      ,[ChangeDate]
      ,[ChangeUser]
      ,[ChangeType]
      ,[DueDate]
      ,[TaxBillPrintedDate]
      ,[TaxBillPrintedUser])
SELECT @ToClientId,tl.NewLocationId,ta.NewAssessmentId
      ,[CollectorId]
      ,[TaxYear]
      ,[PayFromDt]
      ,[PayToDt]
      ,[PayAmt]
      ,[PaidFl]
      ,[PaidDt]
      ,[AddDate]
      ,[AddUser]
      ,[ChangeDate]
      ,[ChangeUser]
      ,[ChangeType]
      ,[DueDate]
      ,[TaxBillPrintedDate]
      ,[TaxBillPrintedUser]
FROM [dbo].[InstallmentsRE] a, 
tempdb.dbo.temprelocations tl, tempdb.dbo.tempreassessments ta
WHERE a.ClientId=@FromClientId 
AND a.LocationId=tl.OldLocationId
AND a.AssessmentId = ta.OldAssessmentId and a.TaxYear=2020








INSERT INTO TaxBillsBPP
      ([ClientId]
      ,[LocationId]
      ,[AssessmentId]
      ,[CollectorId]
      ,[TaxYear]
      ,[FormData]
      ,[AddDate]
      ,[AddUser]
      ,[ChangeDate]
      ,[ChangeUser]
      ,[ChangeType])
SELECT @ToClientId,tl.NewLocationId,ta.NewAssessmentId
      ,[CollectorId]
      ,[TaxYear]
      ,[FormData]
      ,[AddDate]
      ,[AddUser]
      ,[ChangeDate]
      ,[ChangeUser]
      ,[ChangeType]
FROM [dbo].[TaxBillsBPP] a, 
tempdb.dbo.tempbpplocations tl, tempdb.dbo.tempbppassessments ta
WHERE a.ClientId=@FromClientId 
AND a.LocationId=tl.OldLocationId
AND a.AssessmentId = ta.OldAssessmentId and a.TaxYear=2020






INSERT INTO TaxBillsRE
      ([ClientId]
      ,[LocationId]
      ,[AssessmentId]
      ,[CollectorId]
      ,[TaxYear]
      ,[FormData]
      ,[AddDate]
      ,[AddUser]
      ,[ChangeDate]
      ,[ChangeUser]
      ,[ChangeType])
SELECT @ToClientId,tl.NewLocationId,ta.NewAssessmentId
      ,[CollectorId]
      ,[TaxYear]
      ,[FormData]
      ,[AddDate]
      ,[AddUser]
      ,[ChangeDate]
      ,[ChangeUser]
      ,[ChangeType]
FROM [dbo].[TaxBillsRE] a, 
tempdb.dbo.temprelocations tl, tempdb.dbo.tempreassessments ta
WHERE a.ClientId=@FromClientId 
AND a.LocationId=tl.OldLocationId
AND a.AssessmentId = ta.OldAssessmentId and a.TaxYear=2020


















update LocationsBPP set InactiveFl=1
--select * 
from LocationsBPP l, AssessmentsBPP a, tempdb..tempbppassessments tmp
where a.LocationId = l.LocationId
and tmp.OldAssessmentId = a.AssessmentId and l.TaxYear=2020 and a.TaxYear=2020

update LocationsRE set  InactiveFl=1
--select * 
from LocationsRE l, AssessmentsRE a, tempdb..tempreassessments tmp
where a.LocationId = l.LocationId
and tmp.OldAssessmentId = a.AssessmentId and l.TaxYear=2020


update AssessmentsBPP set  InactiveFl=1
--select *	
from LocationsBPP l, AssessmentsBPP a, tempdb..tempbppassessments tmp
where a.LocationId = l.LocationId
and tmp.OldAssessmentId = a.AssessmentId and a.TaxYear=2020 and l.TaxYear=2020

update AssessmentsRE set  InactiveFl=1
--select *	
from LocationsRE l, AssessmentsRE a, tempdb..tempreassessments tmp
where a.LocationId = l.LocationId
and tmp.OldAssessmentId = a.AssessmentId and a.TaxYear=2020

--change legal owner name 
update LocationsBPP set LegalOwner = 'Kosmos Energy, LLC'
--select * 
from LocationsBPP l
where ClientId = 1576971057 and TaxYear=2020 and LegalOwner<>'Kosmos Energy Gulf of Mexico'






