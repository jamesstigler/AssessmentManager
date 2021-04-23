use AssessmentManagerData
go

alter TABLE AssessmentManagerData..FirmInfo add 
DocumentFileshare varchar(255) null

alter TABLE AssessmentManagerData..ReportData add 
BarCode varchar(1000) null, BarCodeDesc varchar(8000) null

update AssessmentManagerData..FirmInfo set DocumentFileshare='C:\My Files\VantageOne\Assessment Manager\Documents'

exec UpdateDataDefinition

--include spGetDocumentInfo.sql and spCleanFileName.sql



