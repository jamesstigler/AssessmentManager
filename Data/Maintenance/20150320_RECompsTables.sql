USE [AssessmentManagerData]
GO

/****** Object:  Table [dbo].[REComps]    Script Date: 3/20/2015 2:34:08 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[REComps](
	[AssessorId] [bigint] NOT NULL,
	[AcctNum] [varchar](255) NOT NULL,
	[TaxYear] [int] NOT NULL,
	[ImprovementValue] [bigint] NOT NULL,
	[LandValue] [bigint] NOT NULL,
	[BuildingSqFt] [bigint] NOT NULL,
	[LandSqFt] [bigint] NOT NULL,
	[NumberOfUnits] [bigint] NOT NULL,
	[YearBuilt] [int] NOT NULL,
	[BuildingClass] [varchar](255) NOT NULL,
	[ComparabilityCode] [varchar](255) NOT NULL,
	[EconomicArea] [varchar](255) NOT NULL,
	[LandMarketArea] [varchar](255) NOT NULL,
	[ImprovementMarketArea] [varchar](255) NOT NULL,
	[Mapsco] [varchar](255) NOT NULL,
	[NeighborhoodGroup] [varchar](255) NOT NULL,
	[StreetName] [varchar](255) NOT NULL,
	[BusinessName] [varchar](255) NOT NULL,
	[TotalValue] [bigint] NOT NULL,
	[LandValuePerSqFt] [float] NOT NULL,
	[ImprovementValuePerSqFt] [float] NOT NULL,
	[TotalValuePerSqFt] [float] NOT NULL,
	[TotalValuePerUnit] [float] NOT NULL,
	[LandBuildingRatio] [float] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUser] [varchar](30) NULL,
 CONSTRAINT [PK_REComps] PRIMARY KEY CLUSTERED 
(
	[AssessorId] ASC,
	[AcctNum] ASC,
	[TaxYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Index [IX_REComps]    Script Date: 3/20/2015 2:34:08 PM ******/
CREATE NONCLUSTERED INDEX [IX_REComps] ON [dbo].[REComps]
(
	[AssessorId] ASC,
	[TaxYear] ASC,
	[LandValue] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

SET ANSI_PADDING ON

GO

/****** Object:  Index [IX_REComps_1]    Script Date: 3/20/2015 2:34:08 PM ******/
CREATE NONCLUSTERED INDEX [IX_REComps_1] ON [dbo].[REComps]
(
	[AssessorId] ASC,
	[TaxYear] ASC,
	[EconomicArea] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

SET ANSI_PADDING ON

GO

/****** Object:  Index [IX_REComps_10]    Script Date: 3/20/2015 2:34:08 PM ******/
CREATE NONCLUSTERED INDEX [IX_REComps_10] ON [dbo].[REComps]
(
	[AssessorId] ASC,
	[TaxYear] ASC,
	[ImprovementMarketArea] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

SET ANSI_PADDING ON

GO

/****** Object:  Index [IX_REComps_11]    Script Date: 3/20/2015 2:34:08 PM ******/
CREATE NONCLUSTERED INDEX [IX_REComps_11] ON [dbo].[REComps]
(
	[AssessorId] ASC,
	[TaxYear] ASC,
	[Mapsco] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

SET ANSI_PADDING ON

GO

/****** Object:  Index [IX_REComps_12]    Script Date: 3/20/2015 2:34:08 PM ******/
CREATE NONCLUSTERED INDEX [IX_REComps_12] ON [dbo].[REComps]
(
	[AssessorId] ASC,
	[TaxYear] ASC,
	[NeighborhoodGroup] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

SET ANSI_PADDING ON

GO

/****** Object:  Index [IX_REComps_13]    Script Date: 3/20/2015 2:34:08 PM ******/
CREATE NONCLUSTERED INDEX [IX_REComps_13] ON [dbo].[REComps]
(
	[AssessorId] ASC,
	[TaxYear] ASC,
	[StreetName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

SET ANSI_PADDING ON

GO

/****** Object:  Index [IX_REComps_14]    Script Date: 3/20/2015 2:34:08 PM ******/
CREATE NONCLUSTERED INDEX [IX_REComps_14] ON [dbo].[REComps]
(
	[AssessorId] ASC,
	[TaxYear] ASC,
	[BusinessName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

SET ANSI_PADDING ON

GO

/****** Object:  Index [IX_REComps_15]    Script Date: 3/20/2015 2:34:08 PM ******/
CREATE NONCLUSTERED INDEX [IX_REComps_15] ON [dbo].[REComps]
(
	[AssessorId] ASC,
	[TaxYear] ASC,
	[LandMarketArea] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

/****** Object:  Index [IX_REComps_16]    Script Date: 3/20/2015 2:34:08 PM ******/
CREATE NONCLUSTERED INDEX [IX_REComps_16] ON [dbo].[REComps]
(
	[AssessorId] ASC,
	[TaxYear] ASC,
	[ImprovementValuePerSqFt] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

/****** Object:  Index [IX_REComps_17]    Script Date: 3/20/2015 2:34:08 PM ******/
CREATE NONCLUSTERED INDEX [IX_REComps_17] ON [dbo].[REComps]
(
	[AssessorId] ASC,
	[TaxYear] ASC,
	[LandValuePerSqFt] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

/****** Object:  Index [IX_REComps_18]    Script Date: 3/20/2015 2:34:08 PM ******/
CREATE NONCLUSTERED INDEX [IX_REComps_18] ON [dbo].[REComps]
(
	[AssessorId] ASC,
	[TaxYear] ASC,
	[LandBuildingRatio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

/****** Object:  Index [IX_REComps_2]    Script Date: 3/20/2015 2:34:08 PM ******/
CREATE NONCLUSTERED INDEX [IX_REComps_2] ON [dbo].[REComps]
(
	[AssessorId] ASC,
	[TaxYear] ASC,
	[ImprovementValue] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

/****** Object:  Index [IX_REComps_20]    Script Date: 3/20/2015 2:34:08 PM ******/
CREATE NONCLUSTERED INDEX [IX_REComps_20] ON [dbo].[REComps]
(
	[AssessorId] ASC,
	[TaxYear] ASC,
	[TotalValuePerSqFt] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

/****** Object:  Index [IX_REComps_21]    Script Date: 3/20/2015 2:34:08 PM ******/
CREATE NONCLUSTERED INDEX [IX_REComps_21] ON [dbo].[REComps]
(
	[AssessorId] ASC,
	[TaxYear] ASC,
	[TotalValuePerUnit] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

/****** Object:  Index [IX_REComps_4]    Script Date: 3/20/2015 2:34:08 PM ******/
CREATE NONCLUSTERED INDEX [IX_REComps_4] ON [dbo].[REComps]
(
	[AssessorId] ASC,
	[TaxYear] ASC,
	[BuildingSqFt] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

/****** Object:  Index [IX_REComps_5]    Script Date: 3/20/2015 2:34:08 PM ******/
CREATE NONCLUSTERED INDEX [IX_REComps_5] ON [dbo].[REComps]
(
	[AssessorId] ASC,
	[TaxYear] ASC,
	[LandSqFt] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

/****** Object:  Index [IX_REComps_6]    Script Date: 3/20/2015 2:34:08 PM ******/
CREATE NONCLUSTERED INDEX [IX_REComps_6] ON [dbo].[REComps]
(
	[AssessorId] ASC,
	[TaxYear] ASC,
	[NumberOfUnits] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

/****** Object:  Index [IX_REComps_7]    Script Date: 3/20/2015 2:34:08 PM ******/
CREATE NONCLUSTERED INDEX [IX_REComps_7] ON [dbo].[REComps]
(
	[AssessorId] ASC,
	[TaxYear] ASC,
	[YearBuilt] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

SET ANSI_PADDING ON

GO

/****** Object:  Index [IX_REComps_8]    Script Date: 3/20/2015 2:34:08 PM ******/
CREATE NONCLUSTERED INDEX [IX_REComps_8] ON [dbo].[REComps]
(
	[AssessorId] ASC,
	[TaxYear] ASC,
	[BuildingClass] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

SET ANSI_PADDING ON

GO

/****** Object:  Index [IX_REComps_9]    Script Date: 3/20/2015 2:34:08 PM ******/
CREATE NONCLUSTERED INDEX [IX_REComps_9] ON [dbo].[REComps]
(
	[AssessorId] ASC,
	[TaxYear] ASC,
	[ComparabilityCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

ALTER TABLE [dbo].[REComps] ADD  CONSTRAINT [DF_REComps_ImprovementValue]  DEFAULT ((0)) FOR [ImprovementValue]
GO

ALTER TABLE [dbo].[REComps] ADD  CONSTRAINT [DF_REComps_LandValue]  DEFAULT ((0)) FOR [LandValue]
GO

ALTER TABLE [dbo].[REComps] ADD  CONSTRAINT [DF_REComps_BuildingSqFt]  DEFAULT ((0)) FOR [BuildingSqFt]
GO

ALTER TABLE [dbo].[REComps] ADD  CONSTRAINT [DF_REComps_LandSqFt]  DEFAULT ((0)) FOR [LandSqFt]
GO

ALTER TABLE [dbo].[REComps] ADD  CONSTRAINT [DF_REComps_NumberOfUnits]  DEFAULT ((0)) FOR [NumberOfUnits]
GO

ALTER TABLE [dbo].[REComps] ADD  CONSTRAINT [DF_REComps_YearBuilt]  DEFAULT ((0)) FOR [YearBuilt]
GO

ALTER TABLE [dbo].[REComps] ADD  CONSTRAINT [DF_REComps_BuildingClass]  DEFAULT ('') FOR [BuildingClass]
GO

ALTER TABLE [dbo].[REComps] ADD  CONSTRAINT [DF_REComps_ComparabilityCode]  DEFAULT ('') FOR [ComparabilityCode]
GO

ALTER TABLE [dbo].[REComps] ADD  CONSTRAINT [DF_REComps_EconomicArea]  DEFAULT ('') FOR [EconomicArea]
GO

ALTER TABLE [dbo].[REComps] ADD  CONSTRAINT [DF_REComps_LandMarketArea]  DEFAULT ('') FOR [LandMarketArea]
GO

ALTER TABLE [dbo].[REComps] ADD  CONSTRAINT [DF_REComps_ImprovementMarketArea]  DEFAULT ('') FOR [ImprovementMarketArea]
GO

ALTER TABLE [dbo].[REComps] ADD  CONSTRAINT [DF_REComps_Mapsco]  DEFAULT ('') FOR [Mapsco]
GO

ALTER TABLE [dbo].[REComps] ADD  CONSTRAINT [DF_REComps_NeighborhoodGroup]  DEFAULT ('') FOR [NeighborhoodGroup]
GO

ALTER TABLE [dbo].[REComps] ADD  CONSTRAINT [DF_REComps_StreetName]  DEFAULT ('') FOR [StreetName]
GO

ALTER TABLE [dbo].[REComps] ADD  CONSTRAINT [DF_REComps_BusinessName]  DEFAULT ('') FOR [BusinessName]
GO

ALTER TABLE [dbo].[REComps] ADD  CONSTRAINT [DF_REComps_TotalValue]  DEFAULT ((0)) FOR [TotalValue]
GO

ALTER TABLE [dbo].[REComps] ADD  CONSTRAINT [DF_REComps_LandValuePerSqFt]  DEFAULT ((0)) FOR [LandValuePerSqFt]
GO

ALTER TABLE [dbo].[REComps] ADD  CONSTRAINT [DF_REComps_ImprovementValuePerSqFt]  DEFAULT ((0)) FOR [ImprovementValuePerSqFt]
GO

ALTER TABLE [dbo].[REComps] ADD  CONSTRAINT [DF_REComps_TotalValuePerSqFt]  DEFAULT ((0)) FOR [TotalValuePerSqFt]
GO

ALTER TABLE [dbo].[REComps] ADD  CONSTRAINT [DF_REComps_TotalValuePerUnit]  DEFAULT ((0)) FOR [TotalValuePerUnit]
GO

ALTER TABLE [dbo].[REComps] ADD  CONSTRAINT [DF_REComps_LandBuildingRatio]  DEFAULT ((0)) FOR [LandBuildingRatio]
GO

ALTER TABLE [dbo].[REComps] ADD  CONSTRAINT [DF_REComps_AddDate]  DEFAULT (getdate()) FOR [AddDate]
GO

CREATE TABLE [dbo].[RECompCodes](
	[AssessorId] [bigint] NOT NULL,
	[TaxYear] [int] NOT NULL,
	[FieldName] [varchar](50) NOT NULL,
	[CodeValue] [varchar](255) NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUser] [varchar](30) NULL,
	[ChangeDate] [datetime] NULL,
	[ChangeUser] [varchar](30) NULL,
	[ChangeType] [tinyint] NULL,
 CONSTRAINT [PK_RECompCodes] PRIMARY KEY CLUSTERED 
(
	[AssessorId] ASC,
	[TaxYear] ASC,
	[FieldName] ASC,
	[CodeValue] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[RECompCodes] ADD  CONSTRAINT [DF_RECompCodes_AddDate]  DEFAULT (getdate()) FOR [AddDate]
GO

exec UpdateDataDefinition

