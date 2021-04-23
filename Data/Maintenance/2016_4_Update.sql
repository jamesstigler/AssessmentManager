USE [AssessmentManagerData]
GO

/****** Object:  Table [dbo].[AssetAllocationPct]    Script Date: 3/30/2016 3:51:46 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[AssetAllocationPct](
	[ClientId] [bigint] NOT NULL,
	[LocationId] [bigint] NOT NULL,
	[AssessmentId] [bigint] NOT NULL,
	[AssetId] [varchar](30) NOT NULL,
	[FactorEntityId] [bigint] NOT NULL,
	[TaxYear] [smallint] NOT NULL,
	[AllocationPct] [float] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUser] [varchar](30) NULL,
	[ChangeDate] [datetime] NULL,
	[ChangeUser] [varchar](30) NULL,
	[ChangeType] [tinyint] NULL,
 CONSTRAINT [PK_AssetAllocationPct] PRIMARY KEY CLUSTERED 
(
	[ClientId] ASC,
	[LocationId] ASC,
	[AssessmentId] ASC,
	[AssetId] ASC,
	[FactorEntityId] ASC,
	[TaxYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[AssetAllocationPct] ADD  CONSTRAINT [DF_AssetAllocationPct_AddDate]  DEFAULT (getdate()) FOR [AddDate]
GO

ALTER TABLE [dbo].[AssetAllocationPct]  WITH CHECK ADD  CONSTRAINT [FK_AssetAllocationPct_Assets] FOREIGN KEY([ClientId], [LocationId], [AssessmentId], [AssetId], [TaxYear])
REFERENCES [dbo].[Assets] ([ClientId], [LocationId], [AssessmentId], [AssetId], [TaxYear])
GO

ALTER TABLE [dbo].[AssetAllocationPct] CHECK CONSTRAINT [FK_AssetAllocationPct_Assets]
GO

ALTER TABLE [dbo].[AssetAllocationPct]  WITH CHECK ADD  CONSTRAINT [FK_AssetAllocationPct_FactorEntities] FOREIGN KEY([FactorEntityId])
REFERENCES [dbo].[FactorEntities] ([FactorEntityId])
GO

ALTER TABLE [dbo].[AssetAllocationPct] CHECK CONSTRAINT [FK_AssetAllocationPct_FactorEntities]
GO


exec UpdateDataDefinition
