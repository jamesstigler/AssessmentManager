--------------------------------------------- businessunits table
CREATE TABLE [dbo].[BusinessUnits](
	[ClientId] [bigint] NOT NULL,
	[BusinessUnitId] [bigint] NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUser] [varchar](30) NULL,
	[ChangeDate] [datetime] NULL,
	[ChangeUser] [varchar](30) NULL,
	[ChangeType] [tinyint] NULL,
 CONSTRAINT [PK_BusinessUnits] PRIMARY KEY CLUSTERED 
(
	[BusinessUnitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_BusinessUnits] ON [dbo].[BusinessUnits]
(
	[ClientId] ASC,
	[BusinessUnitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_BusinessUnits_1] ON [dbo].[BusinessUnits]
(
	[ClientId] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

ALTER TABLE [dbo].[BusinessUnits] ADD  CONSTRAINT [DF__BusinessU__AddDa__74CE504D]  DEFAULT (getdate()) FOR [AddDate]
GO

ALTER TABLE [dbo].[BusinessUnits]  WITH CHECK ADD  CONSTRAINT [FK_BusinessUnits_Clients] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Clients] ([ClientId])
GO

ALTER TABLE [dbo].[BusinessUnits] CHECK CONSTRAINT [FK_BusinessUnits_Clients]
GO

-------------------------------------------assessments bpp/re fields
alter TABLE AssessmentsBPP add 
BusinessUnitId bigint null

alter TABLE AssessmentsRE add 
BusinessUnitId bigint null

-------------------------------------------- assessments bpp/re relationships
ALTER TABLE [dbo].[AssessmentsBPP]  WITH CHECK ADD  CONSTRAINT [FK_AssessmentsBPP_BusinessUnits] FOREIGN KEY([ClientId], [BusinessUnitId])
REFERENCES [dbo].[BusinessUnits] ([ClientId], [BusinessUnitId])
GO

ALTER TABLE [dbo].[AssessmentsBPP] CHECK CONSTRAINT [FK_AssessmentsBPP_BusinessUnits]
GO

ALTER TABLE [dbo].[AssessmentsRE]  WITH CHECK ADD  CONSTRAINT [FK_AssessmentsRE_BusinessUnits] FOREIGN KEY([ClientId], [BusinessUnitId])
REFERENCES [dbo].[BusinessUnits] ([ClientId], [BusinessUnitId])
GO

ALTER TABLE [dbo].[AssessmentsRE] CHECK CONSTRAINT [FK_AssessmentsRE_BusinessUnits]
GO



exec UpdateDataDefinition

update FieldDefinition set QueryType=504, QueryVisibleFl=1 where TableName='BusinessUnits' and FieldName='Name'