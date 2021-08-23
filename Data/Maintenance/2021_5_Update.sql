use AssessmentManagerData

alter table UserQuery add AllTaxYearsFl bit null
alter table LocationsBPP add SICCode varchar(255)
alter table LocationsRE add SICCode varchar(255)

CREATE TABLE [dbo].[SICCodes](
	[SICCode] [varchar](255) NOT NULL,
	[SICCodeDescription] [varchar](255) NOT NULL,
 CONSTRAINT [PK_SICCodes] PRIMARY KEY CLUSTERED 
(
	[SICCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


exec UpdateDataDefinition


update FieldDefinition set QueryVisibleFl=1, QueryType=362 where TableName='LocationsBPP' and FieldName in ('TaxYear','SICCode')
update FieldDefinition set QueryVisibleFl=1, QueryType=436 where TableName='LocationsRE' and FieldName IN ('TaxYear','SICCode')
update FieldDefinition set QueryVisibleFl=1, QueryType=4095 where TableName='Clients' and FieldName IN ('SICCode')


--Import SIC Codes (siccodes.txt file is in data/maintenance folder)
truncate table SICCodes
create table #siccodes (SICCode varchar(255),SICCodeDescription varchar(255) )
bulk insert #siccodes from 'c:\mytempfolder\siccodes.txt' with ( ROWTERMINATOR = '\n', FIELDTERMINATOR ='\t')

insert SICCodes (SICCode,SICCodeDescription)
select distinct  s.SICCode,(select top 1 s1.SICCodeDescription from #siccodes s1 where s1.SICCode=s.SICCode)  from #siccodes s

drop table #siccodes
select * from SICCodes
