USE [AssessmentManagerData]
GO

CREATE TABLE [dbo].[AssessmentsBPPComments](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ClientId] [bigint] NOT NULL,
	[LocationId] [bigint] NOT NULL,
	[AssessmentId] [bigint] NOT NULL,
	[CommentType] [smallint] NOT NULL,
	[TaxYear] [smallint] NOT NULL,
	[Comment] [varchar](1000) NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUser] [varchar](30) NULL,
	[ChangeDate] [datetime] NULL,
	[ChangeUser] [varchar](30) NULL,
	[ChangeType] [tinyint] NULL,
 CONSTRAINT [PK_AssessmentsBPPComments] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Index [IX_AssessmentsBPPComments]    Script Date: 4/5/2016 4:24:09 PM ******/
CREATE NONCLUSTERED INDEX [IX_AssessmentsBPPComments] ON [dbo].[AssessmentsBPPComments]
(
	[ClientId] ASC,
	[LocationId] ASC,
	[AssessmentId] ASC,
	[CommentType] ASC,
	[TaxYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

ALTER TABLE [dbo].[AssessmentsBPPComments] ADD  CONSTRAINT [DF__Assessmen__AddDa__4EA8A765]  DEFAULT (getdate()) FOR [AddDate]
GO

ALTER TABLE [dbo].[AssessmentsBPPComments]  WITH CHECK ADD  CONSTRAINT [FK_AssessmentsBPPComments_AssessmentsBPP] FOREIGN KEY([ClientId], [LocationId], [AssessmentId], [TaxYear])
REFERENCES [dbo].[AssessmentsBPP] ([ClientId], [LocationId], [AssessmentId], [TaxYear])
GO

ALTER TABLE [dbo].[AssessmentsBPPComments] CHECK CONSTRAINT [FK_AssessmentsBPPComments_AssessmentsBPP]
GO



alter TABLE AssessmentsBPP add 
RenditionCompleteFl bit null,
RenditionCompleteDate datetime null

exec UpdateDataDefinition


update FieldDefinition set QueryVisibleFl=1, QueryType=360 where TableName IN ('AssessmentsBPP') 
	and FieldName IN ('RenditionCompleteFl','RenditionCompleteDate')
