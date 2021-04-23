USE [AssessmentManagerData]
GO

CREATE TABLE [dbo].[DatabaseHistory](
	[TypeOfUpdate] [varchar](50) NOT NULL,
	[TextOfUpdate] [varchar](5000) NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUser] [varchar](30) NULL
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[DatabaseHistory] ADD  CONSTRAINT [DF_DatabaseHistory_AddDate]  DEFAULT (getdate()) FOR [AddDate]
GO


exec updatedatadefinition