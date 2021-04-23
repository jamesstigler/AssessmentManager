USE [AssessmentManagerData]
GO

/****** Object:  Index [IX_ReportData]    Script Date: 12/8/2015 9:40:08 AM ******/
DROP INDEX [IX_ReportData] ON [dbo].[ReportData]
GO

/****** Object:  Table [dbo].[ReportData]    Script Date: 12/8/2015 9:40:08 AM ******/
DROP TABLE [dbo].[ReportData]
GO

/****** Object:  Table [dbo].[ReportData]    Script Date: 12/8/2015 9:40:08 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ReportData](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](30) NOT NULL,
	[ReportId] [bigint] NOT NULL,
	[NoRows] [varchar](50) NULL,
	[Title01] [varchar](255) NULL,
	[Title02] [varchar](255) NULL,
	[Title03] [varchar](255) NULL,
	[Text01] [varchar](255) NULL,
	[Text02] [varchar](255) NULL,
	[Text03] [varchar](255) NULL,
	[Text04] [varchar](255) NULL,
	[Text05] [varchar](255) NULL,
	[Text06] [varchar](255) NULL,
	[Text07] [varchar](255) NULL,
	[Text08] [varchar](255) NULL,
	[Text09] [varchar](255) NULL,
	[Text10] [varchar](255) NULL,
	[Text11] [varchar](255) NULL,
	[Text12] [varchar](255) NULL,
	[Text13] [varchar](255) NULL,
	[Text14] [varchar](255) NULL,
	[Text15] [varchar](255) NULL,
	[Text16] [varchar](255) NULL,
	[Text17] [varchar](255) NULL,
	[Text18] [varchar](255) NULL,
	[Text19] [varchar](255) NULL,
	[Text20] [varchar](255) NULL,
	[Number01] [float] NULL,
	[Number02] [float] NULL,
	[Number03] [float] NULL,
	[Number04] [float] NULL,
	[Number05] [float] NULL,
	[Number06] [float] NULL,
	[Number07] [float] NULL,
	[Number08] [float] NULL,
	[Number09] [float] NULL,
	[Number10] [float] NULL,
	[Number11] [float] NULL,
	[Number12] [float] NULL,
	[Number13] [float] NULL,
	[Number14] [float] NULL,
	[Number15] [float] NULL,
	[Number16] [float] NULL,
	[Number17] [float] NULL,
	[Number18] [float] NULL,
	[Number19] [float] NULL,
	[Number20] [float] NULL,
	[RowCounter] [bigint] NULL,
	[Date01] [datetime] NULL,
	[Date02] [datetime] NULL,
	[Date03] [datetime] NULL,
	[Date04] [datetime] NULL,
	[Date05] [datetime] NULL,
	[Date06] [datetime] NULL,
	[Date07] [datetime] NULL,
	[Date08] [datetime] NULL,
	[Date09] [datetime] NULL,
	[Date10] [datetime] NULL,
	[Date11] [datetime] NULL,
	[Date12] [datetime] NULL,
	[Date13] [datetime] NULL,
	[Date14] [datetime] NULL,
	[Date15] [datetime] NULL,
	[Date16] [datetime] NULL,
	[Date17] [datetime] NULL,
	[Date18] [datetime] NULL,
	[Date19] [datetime] NULL,
	[Date20] [datetime] NULL,
	[BarCode1] [varchar](1000) NULL,
	[BarCode2] [varchar](1000) NULL,
	[BarCodeDesc] [varchar](8000) NULL,
	[BarCodeImage] [image] NULL,
 CONSTRAINT [PK_ReportData] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

SET ANSI_PADDING ON

GO

/****** Object:  Index [IX_ReportData]    Script Date: 12/8/2015 9:40:08 AM ******/
CREATE NONCLUSTERED INDEX [IX_ReportData] ON [dbo].[ReportData]
(
	[UserName] ASC,
	[ReportId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


exec updatedatadefinition