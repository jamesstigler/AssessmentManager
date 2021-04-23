USE [AssessmentManagerData]
GO
/****** Object:  StoredProcedure [dbo].[spCleanFileName]    Script Date: 9/19/2014 10:52:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[spCleanFileName]
	@Incoming varchar(1000),
	@Outgoing varchar(1000) OUT
AS
	BEGIN
		SET @Outgoing = LTRIM(RTRIM(@Incoming))
		SET @Outgoing = REPLACE(@Outgoing,'\','')
		SET @Outgoing = REPLACE(@Outgoing,'/','')
		SET @Outgoing = REPLACE(@Outgoing,':','')
		SET @Outgoing = REPLACE(@Outgoing,'*','')
		SET @Outgoing = REPLACE(@Outgoing,'?','')
		SET @Outgoing = REPLACE(@Outgoing,'"','')
		SET @Outgoing = REPLACE(@Outgoing,'<','')
		SET @Outgoing = REPLACE(@Outgoing,'>','')
		SET @Outgoing = REPLACE(@Outgoing,'|','')
	END

GO
/****** Object:  StoredProcedure [dbo].[spGetDocumentInfo]    Script Date: 9/19/2014 10:52:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[spGetDocumentInfo]
	@DocType int,					-- 1=audit, 2=data, etc	
	@ClientId bigint,
	@TaxYear bigint = NULL,
	@PropType bigint = NULL,		-- 1=BPP, 2=RE
	@LocationId bigint = NULL,
	@AssessmentId bigint = NULL,
	@JurisdictionId bigint = NULL,
	@CollectorId bigint = NULL
AS
	BEGIN	
		DECLARE @DocPath varchar(1000) = ''
		DECLARE @DocFileshare varchar(1000)	= ''
		DECLARE @Name varchar(300) = ''
		DECLARE @ClientName varchar(300) = ''
		DECLARE @TaxYearPath varchar(5) = ''
		DECLARE @DocFolder varchar(50) = ''
		DECLARE @FileName varchar(1000) = ''

		SET @DocFileshare = (SELECT LTRIM(RTRIM(DocumentFileshare)) + '\' 
			FROM FirmInfo)
		
		IF @TaxYear IS NOT NULL
			BEGIN
				SET @TaxYearPath = CONVERT(varchar(4),@TaxYear) + '\'
			END

	    SET @Name = ISNULL((SELECT LTRIM(RTRIM(Name)) AS Name 
			FROM Clients WHERE ClientId = @ClientId),'Unknown Client')
		EXEC spCleanFileName @Name, @ClientName OUT
		SET @ClientName = @ClientName + '\'
		
		SET @DocFolder = 
			CASE 
				WHEN @DocType = 1 THEN 'Audit'
				WHEN @DocType = 2 THEN 'Data'
				WHEN @DocType = 3 THEN 'Exempt'
				WHEN @DocType = 4 THEN 'Com'
				WHEN @DocType = 5 THEN 'Notice'
				WHEN @DocType = 6 THEN 'Rendition'
				WHEN @DocType = 7 THEN 'Reports'
				WHEN @DocType = 8 THEN 'Tax Bills'
				ELSE 'Unknown Document Type'
			END
		SET @DocFolder = @DocFolder + '\'

		SET @DocPath = @DocFileshare + @ClientName + @TaxYearPath + 
			@DocFolder

		-- Begin setting the file name
		DECLARE @ClientLocationId varchar(1000) = ''
		DECLARE @StateCd varchar(2) = ''
		DECLARE @PropTypeDesc varchar(3) = ''
		DECLARE @Address varchar(50) = ''
		DECLARE @City varchar(50) = ''
		DECLARE @AcctNum varchar(50) = ''
		DECLARE @CollectorName varchar(50) = ''
		
		--BPP
		IF @PropType = 1
			BEGIN
				SET @PropTypeDesc = 'BPP'
				IF @DocType = 8
					BEGIN
						SELECT @ClientLocationId = l.ClientLocationId,
							@StateCd = l.StateCd, @Address = l.Address, 
							@City = l.City, @AcctNum = a.AcctNum,
							@CollectorName = c.Name
						FROM LocationsBPP AS l 
						INNER JOIN AssessmentsBPP AS a 
							ON l.ClientId = a.ClientId AND l.LocationId = a.LocationId 
							AND l.TaxYear = a.TaxYear 
						INNER JOIN AssessmentDetailBPP AS ad 
							ON a.ClientId = ad.ClientId AND a.LocationId = ad.LocationId 
							AND a.AssessmentId = ad.AssessmentId AND a.TaxYear = ad.TaxYear 
						INNER JOIN Jurisdictions AS j 
							ON ad.JurisdictionId = j.JurisdictionId AND ad.TaxYear = j.TaxYear
						INNER JOIN Collectors AS c
							ON j.CollectorId = c.CollectorId AND j.TaxYear = c.TaxYear
						WHERE a.ClientId = @ClientId AND a.LocationId = @LocationId 
							AND a.AssessmentId = @AssessmentId AND a.TaxYear = @TaxYear
							AND c.CollectorId = @CollectorId
					END
				ELSE
					BEGIN
						SELECT @ClientLocationId = l.ClientLocationId,
							@StateCd = l.StateCd, @Address = l.Address, 
							@City = l.City,  
							@AcctNum = a.AcctNum
						FROM LocationsBPP AS l 
						INNER JOIN AssessmentsBPP AS a 
							ON l.ClientId = a.ClientId AND l.LocationId = a.LocationId 
							AND l.TaxYear = a.TaxYear
						WHERE a.ClientId = @ClientId AND a.LocationId = @LocationId 
							AND a.AssessmentId = @AssessmentId AND a.TaxYear = @TaxYear
					END
			END
		
		--RE
		IF @PropType = 2
			BEGIN
				SET @PropTypeDesc = 'RE'
				IF @DocType = 8
					BEGIN
						SELECT @ClientLocationId = l.ClientLocationId,
							@StateCd = l.StateCd, @Address = l.Address, 
							@City = l.City, @AcctNum = a.AcctNum,
							@CollectorName = c.Name
						FROM LocationsRE AS l 
						INNER JOIN AssessmentsRE AS a 
							ON l.ClientId = a.ClientId AND l.LocationId = a.LocationId 
							AND l.TaxYear = a.TaxYear 
						INNER JOIN AssessmentDetailRE AS ad 
							ON a.ClientId = ad.ClientId AND a.LocationId = ad.LocationId 
							AND a.AssessmentId = ad.AssessmentId AND a.TaxYear = ad.TaxYear 
						INNER JOIN Jurisdictions AS j 
							ON ad.JurisdictionId = j.JurisdictionId AND ad.TaxYear = j.TaxYear
						INNER JOIN Collectors AS c
							ON j.CollectorId = c.CollectorId AND j.TaxYear = c.TaxYear
						WHERE a.ClientId = @ClientId AND a.LocationId = @LocationId 
							AND a.AssessmentId = @AssessmentId AND a.TaxYear = @TaxYear
							AND c.CollectorId = @CollectorId
					END
				ELSE
					BEGIN
						SELECT @ClientLocationId = l.ClientLocationId,
							@StateCd = l.StateCd, @Address = l.Address, 
							@City = l.City,  
							@AcctNum = a.AcctNum
						FROM LocationsRE AS l INNER JOIN
							AssessmentsRE AS a 
						ON l.ClientId = a.ClientId AND l.LocationId = a.LocationId 
							AND l.TaxYear = a.TaxYear
						WHERE a.ClientId = @ClientId AND a.LocationId = @LocationId 
							AND a.AssessmentId = @AssessmentId AND a.TaxYear = @TaxYear
					END

			END

		SET @StateCd = LTRIM(RTRIM(ISNULL(@StateCd,'')))
		SET @ClientLocationId = LTRIM(RTRIM(ISNULL(@ClientLocationId,'')))
		SET @Address = LTRIM(RTRIM(ISNULL(@Address,'')))
		SET @City = LTRIM(RTRIM(ISNULL(@City,'')))
		SET @AcctNum = LTRIM(RTRIM(ISNULL(@AcctNum,'')))
		SET @CollectorName = LTRIM(RTRIM(ISNULL(@CollectorName,'')))
		
		--should not happen, but need to create some kind of trail
		IF @StateCd = '' OR (@DocType = 8 AND @CollectorName = '')
			BEGIN
				SET @ClientLocationId = 'Unknown location or account:  Parms = ' + 
					CONVERT(varchar,@DocType) + ',' +
					CONVERT(varchar,@ClientId) + ',' +
					CONVERT(varchar,ISNULL(@TaxYear,0)) + ',' +
					CONVERT(varchar,ISNULL(@PropType,0)) + ',' +
					CONVERT(varchar,ISNULL(@LocationId,0)) + ',' +
					CONVERT(varchar,ISNULL(@AssessmentId,0)) + ',' +
					CONVERT(varchar,ISNULL(@CollectorName,0)) + ','
			END

		IF @ClientLocationId <> ''
			BEGIN
				SET @FileName = @ClientLocationId + '_'
			END
		SET @FileName = @FileName + @StateCd + '_' + 
			@PropTypeDesc + '_' + @Address + '_' + @City + '_' +
			@AcctNum
		IF @DocType = 8	
			BEGIN
				SET @FileName = @FileName + '_' + @CollectorName
			END

		EXEC spCleanFileName @FileName, @FileName OUT

		SELECT @DocPath AS Path, @FileName AS FileName
			
	END

GO
/****** Object:  StoredProcedure [dbo].[UpdateDataDefinition]    Script Date: 9/19/2014 10:52:45 AM ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.UpdateDataDefinition    Script Date: 7/2/2008 4:19:29 PM ******/

CREATE proc [dbo].[UpdateDataDefinition]
	as

	set nocount on

	begin transaction

	DELETE FieldDefinition
	FROM FieldDefinition fd
	WHERE fd.FieldName NOT IN(SELECT c.name FROM sysobjects t, syscolumns c
				WHERE c.id = t.id
				AND t.type = 'U'
				AND t.name = fd.TableName)

	DELETE TableDefinition
	WHERE TableName NOT IN(SELECT name FROM sysobjects 
				WHERE type = 'U')
	
	commit transaction
	
	begin transaction

	INSERT TableDefinition (TableName) 
	SELECT t.name 
	FROM sysobjects t 
	WHERE t.type = 'U'
	AND t.name NOT IN('dtproperties')
	AND NOT EXISTS (SELECT tf.* FROM TableDefinition tf
					WHERE tf.TableName = t.name)
	
	INSERT FieldDefinition (TableName,FieldName) 
	SELECT t.name , c.name
	FROM sysobjects t, syscolumns c
	WHERE t.type = 'U'
	AND c.id = t.id
	AND t.name NOT IN('dtproperties')
	AND NOT EXISTS (SELECT fd.* FROM FieldDefinition fd
					WHERE fd.TableName = t.name
					AND fd.FieldName = c.name)
	
	commit transaction

GO
/****** Object:  Table [dbo].[AssessmentDetailBPP]    Script Date: 9/19/2014 10:52:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AssessmentDetailBPP](
	[ClientId] [bigint] NOT NULL,
	[LocationId] [bigint] NOT NULL,
	[AssessmentId] [bigint] NOT NULL,
	[JurisdictionId] [bigint] NOT NULL,
	[TaxYear] [smallint] NOT NULL,
	[NotifiedValue] [float] NULL,
	[ConsultantValue] [float] NULL,
	[FinalValue] [float] NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUser] [varchar](30) NULL,
	[ChangeDate] [datetime] NULL,
	[ChangeUser] [varchar](30) NULL,
	[ChangeType] [tinyint] NULL,
	[AdjAmt1] [float] NULL,
	[AdjDesc1] [varchar](255) NULL,
	[AdjAmt2] [float] NULL,
	[AdjDesc2] [varchar](255) NULL,
	[AdjAmt3] [float] NULL,
	[AdjDesc3] [varchar](255) NULL,
	[FreeportReductionAmt] [float] NULL,
	[AbatementReductionAmt] [float] NULL,
	[TaxBillAdjAmt1] [float] NULL,
	[TaxBillAdjDesc1] [varchar](255) NULL,
	[TaxBillAdjAmt2] [float] NULL,
	[TaxBillAdjDesc2] [varchar](255) NULL,
	[TaxBillPrintedDate] [datetime] NULL,
	[TaxBillPrintedUser] [varchar](30) NULL,
	[PenaltyAmt1] [float] NULL,
 CONSTRAINT [PK_AssessmentDetailBPP] PRIMARY KEY CLUSTERED 
(
	[ClientId] ASC,
	[LocationId] ASC,
	[AssessmentId] ASC,
	[JurisdictionId] ASC,
	[TaxYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AssessmentDetailRE]    Script Date: 9/19/2014 10:52:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AssessmentDetailRE](
	[ClientId] [bigint] NOT NULL,
	[LocationId] [bigint] NOT NULL,
	[AssessmentId] [bigint] NOT NULL,
	[JurisdictionId] [bigint] NOT NULL,
	[TaxYear] [smallint] NOT NULL,
	[ConsultantValue] [float] NULL,
	[FinalValue] [float] NULL,
	[RELandValue] [float] NULL,
	[REImprovementValue] [float] NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUser] [varchar](30) NULL,
	[ChangeDate] [datetime] NULL,
	[ChangeUser] [varchar](30) NULL,
	[ChangeType] [tinyint] NULL,
	[AdjAmt1] [float] NULL,
	[AdjDesc1] [varchar](255) NULL,
	[AdjAmt2] [float] NULL,
	[AdjDesc2] [varchar](255) NULL,
	[AdjAmt3] [float] NULL,
	[AdjDesc3] [varchar](255) NULL,
	[AbatementReductionAmt] [float] NULL,
	[TaxBillAdjAmt1] [float] NULL,
	[TaxBillAdjDesc1] [varchar](255) NULL,
	[TaxBillAdjAmt2] [float] NULL,
	[TaxBillAdjDesc2] [varchar](255) NULL,
	[TotalAssessedValue] [float] NULL,
	[TaxBillPrintedDate] [datetime] NULL,
	[TaxBillPrintedUser] [varchar](30) NULL,
	[PenaltyAmt1] [float] NULL,
 CONSTRAINT [PK_AssessmentDetailReal] PRIMARY KEY CLUSTERED 
(
	[ClientId] ASC,
	[LocationId] ASC,
	[AssessmentId] ASC,
	[JurisdictionId] ASC,
	[TaxYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AssessmentsBPP]    Script Date: 9/19/2014 10:52:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AssessmentsBPP](
	[ClientId] [bigint] NOT NULL,
	[LocationId] [bigint] NOT NULL,
	[AssessmentId] [bigint] NOT NULL,
	[TaxYear] [smallint] NOT NULL,
	[AssessorId] [bigint] NULL,
	[AcctNum] [varchar](50) NULL,
	[Comment] [varchar](1000) NULL,
	[CustomFl1] [bit] NULL,
	[CustomFl2] [bit] NULL,
	[CustomFl3] [bit] NULL,
	[CustomText1] [varchar](255) NULL,
	[CustomText2] [varchar](255) NULL,
	[CustomText3] [varchar](255) NULL,
	[CustomNumber1] [float] NULL,
	[CustomNumber2] [float] NULL,
	[CustomNumber3] [float] NULL,
	[CustomDate1] [datetime] NULL,
	[CustomDate2] [datetime] NULL,
	[CustomDate3] [datetime] NULL,
	[FactorEntityId1] [bigint] NULL,
	[FactorEntityId2] [bigint] NULL,
	[FactorEntityId3] [bigint] NULL,
	[FactorEntityId4] [bigint] NULL,
	[FactorEntityId5] [bigint] NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUser] [varchar](30) NULL,
	[ChangeDate] [datetime] NULL,
	[ChangeUser] [nvarchar](30) NULL,
	[ChangeType] [tinyint] NULL,
	[JurDiffValFl] [bit] NULL,
	[ProspectFl] [bit] NULL,
	[ValueProtestMailedDate] [datetime] NULL,
	[ValueProtestHearingDate] [datetime] NULL,
	[ValueProtestStatus] [varchar](255) NULL,
	[ValueProtestDeadlineDate] [datetime] NULL,
	[ValueProtestCMRRR] [varchar](255) NULL,
	[FreeportProtestFl] [bit] NULL,
	[ValueProtestFl] [bit] NULL,
	[FreeportProtestMailedDate] [datetime] NULL,
	[FreeportProtestHearingDate] [datetime] NULL,
	[FreeportProtestStatus] [varchar](255) NULL,
	[FreeportProtestDeadlineDate] [datetime] NULL,
	[FreeportProtestCMRRR] [varchar](255) NULL,
	[InactiveFl] [bit] NULL,
	[RenditionMailedDate] [datetime] NULL,
	[RenditionCMRRR] [varchar](255) NULL,
	[RenditionExtCMRRR] [varchar](255) NULL,
	[RenditionExtMailedDate] [datetime] NULL,
	[OtherProtest1] [varchar](255) NULL,
	[OtherProtest1DeadlineDate] [datetime] NULL,
	[OtherProtest1MailedDate] [datetime] NULL,
	[OtherProtest1CMRRR] [varchar](255) NULL,
	[OtherProtest1Status] [varchar](255) NULL,
	[OtherProtest1HearingDate] [datetime] NULL,
	[RenditionDeadlineDate] [datetime] NULL,
	[RenditionExtDeadlineDate] [datetime] NULL,
	[ClientRenditionValue] [float] NULL,
	[SavingsExclusionCd] [int] NULL,
 CONSTRAINT [PK_AssessmentsBPP] PRIMARY KEY CLUSTERED 
(
	[ClientId] ASC,
	[LocationId] ASC,
	[AssessmentId] ASC,
	[TaxYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_AssessmentsBPP] UNIQUE NONCLUSTERED 
(
	[AssessmentId] ASC,
	[TaxYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AssessmentsRE]    Script Date: 9/19/2014 10:52:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AssessmentsRE](
	[ClientId] [bigint] NOT NULL,
	[LocationId] [bigint] NOT NULL,
	[AssessmentId] [bigint] NOT NULL,
	[TaxYear] [smallint] NOT NULL,
	[AssessorId] [bigint] NULL,
	[AcctNum] [varchar](50) NULL,
	[Comment] [varchar](1000) NULL,
	[CustomFl1] [bit] NULL,
	[CustomFl2] [bit] NULL,
	[CustomFl3] [bit] NULL,
	[CustomText1] [varchar](255) NULL,
	[CustomText2] [varchar](255) NULL,
	[CustomText3] [varchar](255) NULL,
	[CustomNumber1] [float] NULL,
	[CustomNumber2] [float] NULL,
	[CustomNumber3] [float] NULL,
	[CustomDate1] [datetime] NULL,
	[CustomDate2] [datetime] NULL,
	[CustomDate3] [datetime] NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUser] [varchar](30) NULL,
	[ChangeDate] [datetime] NULL,
	[ChangeUser] [nvarchar](30) NULL,
	[ChangeType] [tinyint] NULL,
	[JurDiffValFl] [bit] NULL,
	[ProspectFl] [bit] NULL,
	[ValueProtestMailedDate] [datetime] NULL,
	[ValueProtestHearingDate] [datetime] NULL,
	[ValueProtestStatus] [varchar](255) NULL,
	[ValueProtestDeadlineDate] [datetime] NULL,
	[ValueProtestCMRRR] [varchar](255) NULL,
	[ValueProtestFl] [bit] NULL,
	[InactiveFl] [bit] NULL,
	[LastYearsFinalValue] [decimal](16, 2) NULL,
	[SavingsExclusionCd] [int] NULL,
 CONSTRAINT [PK_AssessmentsReal] PRIMARY KEY CLUSTERED 
(
	[ClientId] ASC,
	[LocationId] ASC,
	[AssessmentId] ASC,
	[TaxYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Assessors]    Script Date: 9/19/2014 10:52:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Assessors](
	[AssessorId] [bigint] NOT NULL,
	[TaxYear] [smallint] NOT NULL,
	[StateCd] [char](2) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[Address1] [varchar](255) NULL,
	[Address2] [varchar](255) NULL,
	[City] [varchar](255) NULL,
	[Zip] [varchar](10) NULL,
	[Phone] [varchar](20) NULL,
	[Fax] [varchar](20) NULL,
	[WebSite] [varchar](50) NULL,
	[Comment] [varchar](255) NULL,
	[BPPRatio] [float] NULL,
	[RERatio] [float] NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUser] [varchar](30) NULL,
	[ChangeDate] [datetime] NULL,
	[ChangeUser] [varchar](30) NULL,
	[ChangeType] [tinyint] NULL,
	[RenditionDueDate] [datetime] NULL,
	[LienDate] [datetime] NULL,
	[BPPNoticeDate] [datetime] NULL,
	[RENoticeDate] [datetime] NULL,
	[BPPProtestDeadlineDate] [datetime] NULL,
	[REProtestDeadlineDate] [datetime] NULL,
 CONSTRAINT [PK_Assessor] PRIMARY KEY CLUSTERED 
(
	[AssessorId] ASC,
	[TaxYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY],
 CONSTRAINT [IX_Assessor] UNIQUE NONCLUSTERED 
(
	[StateCd] ASC,
	[Name] ASC,
	[TaxYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Assets]    Script Date: 9/19/2014 10:52:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Assets](
	[ClientId] [bigint] NOT NULL,
	[LocationId] [bigint] NOT NULL,
	[AssetId] [varchar](30) NOT NULL,
	[TaxYear] [smallint] NOT NULL,
	[OriginalCost] [bigint] NULL,
	[PurchaseDate] [datetime] NOT NULL,
	[Description] [varchar](255) NULL,
	[GLCode] [varchar](50) NULL,
	[Future1] [varchar](50) NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUser] [varchar](30) NULL,
	[ChangeDate] [datetime] NULL,
	[ChangeUser] [varchar](30) NULL,
	[ChangeType] [tinyint] NULL,
	[VIN] [varchar](255) NULL,
	[LocationAddress] [varchar](255) NULL,
	[AllocationPct] [float] NOT NULL,
	[AssessmentId] [bigint] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ClientComments]    Script Date: 9/19/2014 10:52:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ClientComments](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ClientId] [bigint] NOT NULL,
	[Comment] [varchar](1000) NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUser] [varchar](30) NULL,
	[ChangeDate] [datetime] NULL,
	[ChangeUser] [varchar](30) NULL,
	[ChangeType] [tinyint] NULL,
 CONSTRAINT [PK_ClientComments] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ClientFactorCodeOverrides]    Script Date: 9/19/2014 10:52:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ClientFactorCodeOverrides](
	[ClientId] [bigint] NOT NULL,
	[LocationId] [bigint] NOT NULL,
	[AssessmentId] [bigint] NOT NULL,
	[AssetId] [varchar](30) NOT NULL,
	[FactorEntityId] [bigint] NOT NULL,
	[TaxYear] [smallint] NOT NULL,
	[FactorCode] [varchar](50) NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUser] [varchar](30) NULL,
	[ChangeDate] [datetime] NULL,
	[ChangeUser] [varchar](30) NULL,
	[ChangeType] [tinyint] NULL,
 CONSTRAINT [PK_ClientFactorCodeOverrides] PRIMARY KEY CLUSTERED 
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
/****** Object:  Table [dbo].[ClientForms]    Script Date: 9/19/2014 10:52:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ClientForms](
	[FormId] [bigint] NOT NULL,
	[TaxYear] [smallint] NOT NULL,
	[ClientId] [bigint] NOT NULL,
	[StateCd] [char](2) NOT NULL,
	[FormName] [varchar](255) NOT NULL,
	[FormData] [image] NULL,
	[FormDescription] [varchar](255) NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUser] [varchar](30) NULL,
	[ChangeDate] [datetime] NULL,
	[ChangeUser] [varchar](30) NULL,
	[ChangeType] [tinyint] NULL,
 CONSTRAINT [PK_ClientForms] PRIMARY KEY CLUSTERED 
(
	[FormId] ASC,
	[TaxYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY],
 CONSTRAINT [IX_ClientsForm] UNIQUE NONCLUSTERED 
(
	[ClientId] ASC,
	[StateCd] ASC,
	[FormName] ASC,
	[TaxYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ClientFormsXRef]    Script Date: 9/19/2014 10:52:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ClientFormsXRef](
	[FormId] [bigint] NOT NULL,
	[PDFFieldName] [varchar](500) NOT NULL,
	[TaxYear] [smallint] NOT NULL,
	[TableName] [varchar](50) NULL,
	[FieldName] [varchar](50) NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUser] [varchar](30) NULL,
	[ChangeDate] [datetime] NULL,
	[ChangeUser] [varchar](30) NULL,
	[ChangeType] [tinyint] NULL,
 CONSTRAINT [PK_ClientFormXRef] PRIMARY KEY CLUSTERED 
(
	[FormId] ASC,
	[PDFFieldName] ASC,
	[TaxYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ClientGLCodes]    Script Date: 9/19/2014 10:52:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ClientGLCodes](
	[ClientId] [bigint] NOT NULL,
	[StateCd] [char](2) NOT NULL,
	[GLCode] [varchar](50) NOT NULL,
	[TaxYear] [smallint] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUser] [varchar](30) NULL,
	[ChangeDate] [datetime] NULL,
	[ChangeUser] [varchar](30) NULL,
	[ChangeType] [tinyint] NULL,
 CONSTRAINT [PK_ClientGLCodes] PRIMARY KEY CLUSTERED 
(
	[ClientId] ASC,
	[StateCd] ASC,
	[GLCode] ASC,
	[TaxYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ClientGLCodeXRef]    Script Date: 9/19/2014 10:52:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ClientGLCodeXRef](
	[ClientId] [bigint] NOT NULL,
	[StateCd] [char](2) NOT NULL,
	[GLCode] [varchar](50) NOT NULL,
	[TaxYear] [smallint] NOT NULL,
	[FactorEntityId] [bigint] NOT NULL,
	[FactorCode] [varchar](50) NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUser] [varchar](30) NULL,
	[ChangeDate] [datetime] NULL,
	[ChangeUser] [varchar](30) NULL,
	[ChangeType] [tinyint] NULL,
 CONSTRAINT [PK_ClientGLCodeXRef] PRIMARY KEY CLUSTERED 
(
	[ClientId] ASC,
	[StateCd] ASC,
	[GLCode] ASC,
	[TaxYear] ASC,
	[FactorEntityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 9/19/2014 10:52:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Clients](
	[ClientId] [bigint] NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[Address] [varchar](255) NULL,
	[City] [varchar](255) NULL,
	[StateCd] [char](2) NULL,
	[Zip] [varchar](10) NULL,
	[Phone] [varchar](50) NULL,
	[Fax] [varchar](50) NULL,
	[Comment] [varchar](255) NULL,
	[LeadInfoSentFl] [bit] NULL,
	[CustomFlag2] [bit] NULL,
	[CustomFlag3] [bit] NULL,
	[CustomFlag4] [bit] NULL,
	[CustomFlag5] [bit] NULL,
	[WebSite] [varchar](255) NULL,
	[DBA] [varchar](255) NULL,
	[LeadCompetitorName] [varchar](255) NULL,
	[LeadStatus] [varchar](255) NULL,
	[CustomText5] [varchar](255) NULL,
	[ContractTermYears] [float] NULL,
	[ContractFee] [float] NULL,
	[ContractLocationFee] [float] NULL,
	[CustomNumber4] [float] NULL,
	[CustomNumber5] [float] NULL,
	[LeadFollowUpDate] [datetime] NULL,
	[LeadMailDate] [datetime] NULL,
	[CustomDate3] [datetime] NULL,
	[CustomDate4] [datetime] NULL,
	[CustomDate5] [datetime] NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUser] [varchar](30) NULL,
	[ChangeDate] [datetime] NULL,
	[ChangeUser] [varchar](30) NULL,
	[ChangeType] [tinyint] NULL,
	[ProspectFl] [bit] NULL,
	[ConsultantName] [varchar](50) NULL,
	[ContactTaxName] [varchar](255) NULL,
	[ContactTaxAddress] [varchar](255) NULL,
	[ContactTaxCity] [varchar](255) NULL,
	[ContactTaxStateCd] [char](2) NULL,
	[ContactTaxZip] [varchar](10) NULL,
	[ContactTaxPhone] [varchar](50) NULL,
	[ContactTaxFax] [varchar](50) NULL,
	[ContactTaxEMail] [varchar](255) NULL,
	[ContactInvoiceName] [varchar](255) NULL,
	[ContactInvoiceAddress] [varchar](255) NULL,
	[ContactInvoiceCity] [varchar](255) NULL,
	[ContactInvoiceStateCd] [char](2) NULL,
	[ContactInvoiceZip] [varchar](10) NULL,
	[ContactInvoicePhone] [varchar](50) NULL,
	[ContactInvoiceFax] [varchar](50) NULL,
	[ContactInvoiceEMail] [varchar](255) NULL,
	[ContactContractName] [varchar](255) NULL,
	[ContactContractAddress] [varchar](255) NULL,
	[ContactContractCity] [varchar](255) NULL,
	[ContactContractStateCd] [char](2) NULL,
	[ContactContractZip] [varchar](10) NULL,
	[ContactContractPhone] [varchar](50) NULL,
	[ContactContractFax] [varchar](50) NULL,
	[ContactContractEMail] [varchar](255) NULL,
	[ContactInformationName] [varchar](255) NULL,
	[ContactInformationAddress] [varchar](255) NULL,
	[ContactInformationCity] [varchar](255) NULL,
	[ContactInformationStateCd] [char](2) NULL,
	[ContactInformationZip] [varchar](10) NULL,
	[ContactInformationPhone] [varchar](50) NULL,
	[ContactInformationFax] [varchar](50) NULL,
	[ContactInformationEMail] [varchar](255) NULL,
	[ContactMiscName] [varchar](255) NULL,
	[ContactMiscAddress] [varchar](255) NULL,
	[ContactMiscCity] [varchar](255) NULL,
	[ContactMiscStateCd] [char](2) NULL,
	[ContactMiscZip] [varchar](10) NULL,
	[ContactMiscPhone] [varchar](50) NULL,
	[ContactMiscFax] [varchar](50) NULL,
	[ContactMiscEMail] [varchar](255) NULL,
	[InactiveFl] [bit] NULL,
	[SolicitType] [varchar](255) NULL,
	[SolicitSentDate] [datetime] NULL,
	[AofAExpireDate] [datetime] NULL,
	[ContractStartDate] [datetime] NULL,
	[ContractEndDate] [datetime] NULL,
	[SICCode] [varchar](255) NULL,
	[ContractRenewalFl] [bit] NULL,
	[AccountRep] [varchar](255) NULL,
	[ContractFeeFlatFl] [bit] NULL,
	[ContractFeeFlatAmt] [float] NULL,
	[ContractFeeFlatPerLocFl] [bit] NULL,
	[ContractFeeFlatPerLocAmt] [float] NULL,
	[ContractFeeContingencyFl] [bit] NULL,
	[ContractFeeContingencyPct] [float] NULL,
	[ContractFeeContingencyCapFl] [bit] NULL,
	[ContractFeeContingencyCapPct] [float] NULL,
	[ContractFeeContingencyCapAmt] [float] NULL,
	[ContractFeeOtherFl] [bit] NULL,
	[ContractFeeOther] [varchar](1000) NULL,
	[AofAEffectiveDate] [datetime] NULL,
	[ContractImage] [image] NULL,
	[ProposalImage] [image] NULL,
	[ExcludeNotified] [bit] NULL,
	[ExcludeAbatements] [bit] NULL,
	[ExcludeFreeport] [bit] NULL,
	[ExcludeClient] [bit] NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[ClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_Client] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Collectors]    Script Date: 9/19/2014 10:52:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Collectors](
	[CollectorId] [bigint] NOT NULL,
	[TaxYear] [smallint] NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[StateCd] [char](2) NOT NULL,
	[Payee] [varchar](255) NULL,
	[Address1] [varchar](255) NULL,
	[Address2] [varchar](255) NULL,
	[City] [varchar](255) NULL,
	[Zip] [varchar](10) NULL,
	[Phone] [varchar](50) NULL,
	[Fax] [varchar](50) NULL,
	[WebSite] [varchar](255) NULL,
	[DueDate] [datetime] NULL,
	[Comment] [varchar](255) NULL,
	[DiscountDate] [datetime] NULL,
	[NumDaysWarning] [bigint] NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUser] [varchar](30) NULL,
	[ChangeDate] [datetime] NULL,
	[ChangeUser] [varchar](30) NULL,
	[ChangeType] [tinyint] NULL,
	[AddressCorrectFl] [bit] NULL,
	[DiscountFl] [bit] NULL,
	[DiscountDate2] [datetime] NULL,
	[DiscountDate3] [datetime] NULL,
	[DiscountDate4] [datetime] NULL,
	[DiscountPct] [float] NULL,
	[DiscountPct2] [float] NULL,
	[DiscountPct3] [float] NULL,
	[DiscountPct4] [float] NULL,
	[DueDate2] [datetime] NULL,
	[DueDate3] [datetime] NULL,
	[DueDate4] [datetime] NULL,
	[PayeeStateCd] [char](2) NULL,
 CONSTRAINT [PK_Collector] PRIMARY KEY CLUSTERED 
(
	[CollectorId] ASC,
	[TaxYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_Collector] UNIQUE NONCLUSTERED 
(
	[Name] ASC,
	[StateCd] ASC,
	[TaxYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ColumnWidths]    Script Date: 9/19/2014 10:52:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ColumnWidths](
	[UserName] [varchar](30) NOT NULL,
	[ListId] [bigint] NOT NULL,
	[QueryId] [bigint] NOT NULL,
	[ColumnName] [varchar](255) NOT NULL,
	[ColumnWidth] [bigint] NOT NULL,
 CONSTRAINT [PK_ColumnWidths] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC,
	[ListId] ASC,
	[QueryId] ASC,
	[ColumnName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Consultants]    Script Date: 9/19/2014 10:52:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Consultants](
	[ConsultantName] [varchar](50) NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUser] [varchar](30) NULL,
	[ChangeDate] [datetime] NULL,
	[ChangeUser] [varchar](30) NULL,
	[ChangeType] [tinyint] NULL,
	[ConsultantId] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ConsultantName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FactorCodeOverrides]    Script Date: 9/19/2014 10:52:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FactorCodeOverrides](
	[ClientId] [bigint] NOT NULL,
	[LocationId] [bigint] NOT NULL,
	[AssessmentId] [bigint] NOT NULL,
	[AssetId] [varchar](30) NOT NULL,
	[FactorEntityId] [bigint] NOT NULL,
	[TaxYear] [smallint] NOT NULL,
	[FactorCode] [varchar](50) NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUser] [varchar](30) NULL,
	[ChangeDate] [datetime] NULL,
	[ChangeUser] [varchar](30) NULL,
	[ChangeType] [tinyint] NULL,
 CONSTRAINT [PK_FactorCodeOverridesNew] PRIMARY KEY CLUSTERED 
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
/****** Object:  Table [dbo].[FactorCodeXRef]    Script Date: 9/19/2014 10:52:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FactorCodeXRef](
	[StateCd] [char](2) NOT NULL,
	[StateFactorCode] [varchar](50) NOT NULL,
	[FactorEntityId] [bigint] NOT NULL,
	[TaxYear] [smallint] NOT NULL,
	[EntityFactorCode] [varchar](50) NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUser] [varchar](30) NULL,
	[ChangeDate] [datetime] NULL,
	[ChangeUser] [varchar](30) NULL,
	[ChangeType] [tinyint] NULL,
 CONSTRAINT [PK_FactorCodeXRef] PRIMARY KEY CLUSTERED 
(
	[StateCd] ASC,
	[StateFactorCode] ASC,
	[FactorEntityId] ASC,
	[TaxYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FactorEntities]    Script Date: 9/19/2014 10:52:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FactorEntities](
	[FactorEntityId] [bigint] NOT NULL,
	[StateCd] [char](2) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUser] [varchar](30) NULL,
	[ChangeDate] [datetime] NULL,
	[ChangeUser] [varchar](30) NULL,
	[ChangeType] [tinyint] NULL,
 CONSTRAINT [PK_FactorEntities] PRIMARY KEY CLUSTERED 
(
	[FactorEntityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FactorEntityCodes]    Script Date: 9/19/2014 10:52:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FactorEntityCodes](
	[FactorEntityId] [bigint] NOT NULL,
	[FactorCode] [varchar](50) NOT NULL,
	[TaxYear] [smallint] NOT NULL,
	[Description] [varchar](255) NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUser] [varchar](30) NULL,
	[ChangeDate] [datetime] NULL,
	[ChangeUser] [varchar](30) NULL,
	[ChangeType] [tinyint] NULL,
 CONSTRAINT [PK_FactorEntityCodes] PRIMARY KEY CLUSTERED 
(
	[FactorEntityId] ASC,
	[FactorCode] ASC,
	[TaxYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Factors]    Script Date: 9/19/2014 10:52:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Factors](
	[FactorEntityId] [bigint] NOT NULL,
	[FactorCode] [varchar](50) NOT NULL,
	[Age] [smallint] NOT NULL,
	[TaxYear] [smallint] NOT NULL,
	[Percentage] [float] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUser] [varchar](30) NULL,
	[ChangeDate] [datetime] NULL,
	[ChangeUser] [varchar](30) NULL,
	[ChangeType] [tinyint] NULL,
 CONSTRAINT [PK_Factors] PRIMARY KEY CLUSTERED 
(
	[FactorEntityId] ASC,
	[FactorCode] ASC,
	[Age] ASC,
	[TaxYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FieldDataDefinition]    Script Date: 9/19/2014 10:52:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FieldDataDefinition](
	[TableName] [varchar](50) NOT NULL,
	[FieldName] [varchar](50) NOT NULL,
	[FieldValue] [varchar](255) NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUser] [varchar](30) NULL,
	[ChangeDate] [datetime] NULL,
	[ChangeUser] [varchar](30) NULL,
	[ChangeType] [tinyint] NULL,
 CONSTRAINT [PK_FieldDataDefinition] PRIMARY KEY CLUSTERED 
(
	[TableName] ASC,
	[FieldName] ASC,
	[FieldValue] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FieldDefinition]    Script Date: 9/19/2014 10:52:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FieldDefinition](
	[TableName] [varchar](50) NOT NULL,
	[FieldName] [varchar](50) NOT NULL,
	[Description] [varchar](50) NULL,
	[QueryVisibleFl] [bit] NULL,
	[QueryType] [bigint] NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUser] [varchar](30) NULL,
	[ChangeDate] [datetime] NULL,
	[ChangeUser] [varchar](30) NULL,
	[ChangeType] [tinyint] NULL,
 CONSTRAINT [PK_FieldDefinition] PRIMARY KEY CLUSTERED 
(
	[TableName] ASC,
	[FieldName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FirmInfo]    Script Date: 9/19/2014 10:52:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FirmInfo](
	[Name] [varchar](50) NULL,
	[Address] [varchar](50) NULL,
	[City] [varchar](50) NULL,
	[StateCd] [char](2) NULL,
	[Zip] [varchar](10) NULL,
	[Phone] [varchar](50) NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUser] [varchar](30) NULL,
	[ChangeDate] [datetime] NULL,
	[ChangeUser] [varchar](30) NULL,
	[ChangeType] [tinyint] NULL,
	[AppVersionNumber] [varchar](50) NULL,
	[Fax] [varchar](50) NULL,
	[DocumentFileshare] [varchar](255) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[InstallmentsBPP]    Script Date: 9/19/2014 10:52:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[InstallmentsBPP](
	[InstallId] [bigint] IDENTITY(1,1) NOT NULL,
	[ClientId] [bigint] NOT NULL,
	[LocationId] [bigint] NOT NULL,
	[AssessmentId] [bigint] NOT NULL,
	[CollectorId] [bigint] NOT NULL,
	[TaxYear] [smallint] NOT NULL,
	[PayFromDt] [datetime] NOT NULL,
	[PayToDt] [datetime] NOT NULL,
	[PayAmt] [float] NULL,
	[PaidFl] [bit] NULL,
	[PaidDt] [datetime] NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUser] [varchar](30) NULL,
	[ChangeDate] [datetime] NULL,
	[ChangeUser] [varchar](30) NULL,
	[ChangeType] [tinyint] NULL,
	[DueDate] [datetime] NULL,
	[TaxBillPrintedDate] [datetime] NULL,
	[TaxBillPrintedUser] [varchar](30) NULL,
 CONSTRAINT [PK_InstallmentsBPP] PRIMARY KEY CLUSTERED 
(
	[InstallId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[InstallmentsRE]    Script Date: 9/19/2014 10:52:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[InstallmentsRE](
	[InstallId] [bigint] IDENTITY(1,1) NOT NULL,
	[ClientId] [bigint] NOT NULL,
	[LocationId] [bigint] NOT NULL,
	[AssessmentId] [bigint] NOT NULL,
	[CollectorId] [bigint] NOT NULL,
	[TaxYear] [smallint] NOT NULL,
	[PayFromDt] [datetime] NOT NULL,
	[PayToDt] [datetime] NOT NULL,
	[PayAmt] [float] NULL,
	[PaidFl] [bit] NULL,
	[PaidDt] [datetime] NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUser] [varchar](30) NULL,
	[ChangeDate] [datetime] NULL,
	[ChangeUser] [varchar](30) NULL,
	[ChangeType] [tinyint] NULL,
	[DueDate] [datetime] NULL,
	[TaxBillPrintedDate] [datetime] NULL,
	[TaxBillPrintedUser] [varchar](30) NULL,
 CONSTRAINT [PK_InstallmentsRE] PRIMARY KEY CLUSTERED 
(
	[InstallId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Inventory]    Script Date: 9/19/2014 10:52:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Inventory](
	[ClientId] [bigint] NOT NULL,
	[LocationId] [bigint] NOT NULL,
	[TaxYear] [smallint] NOT NULL,
	[RawMaterialClient] [bigint] NULL,
	[WorkInProgressClient] [bigint] NULL,
	[FinishedGoodsClient] [bigint] NULL,
	[SuppliesClient] [bigint] NULL,
	[ConstructionInProgressClient] [bigint] NULL,
	[MarketInventory] [bigint] NULL,
	[RawMaterialConsultant] [bigint] NULL,
	[WorkInProgressConsultant] [bigint] NULL,
	[FinishedGoodsConsultant] [bigint] NULL,
	[SuppliesConsultant] [bigint] NULL,
	[ConstructionInProgressConsultant] [bigint] NULL,
	[MarketInventoryQty] [bigint] NULL,
	[MarketInventoryDescription] [varchar](255) NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUser] [varchar](30) NULL,
	[ChangeDate] [datetime] NULL,
	[ChangeUser] [varchar](30) NULL,
	[ChangeType] [tinyint] NULL,
 CONSTRAINT [PK_Inventory] PRIMARY KEY CLUSTERED 
(
	[ClientId] ASC,
	[LocationId] ASC,
	[TaxYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Jurisdictions]    Script Date: 9/19/2014 10:52:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Jurisdictions](
	[JurisdictionId] [bigint] NOT NULL,
	[TaxYear] [smallint] NOT NULL,
	[CollectorId] [bigint] NULL,
	[StateCd] [char](2) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[Address1] [varchar](255) NULL,
	[Address2] [varchar](255) NULL,
	[City] [varchar](255) NULL,
	[Zip] [varchar](10) NULL,
	[Phone] [varchar](20) NULL,
	[Fax] [varchar](20) NULL,
	[WebSite] [varchar](50) NULL,
	[Comment] [varchar](255) NULL,
	[TaxRate] [float] NULL,
	[FreeportFl] [bit] NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUser] [varchar](30) NULL,
	[ChangeDate] [datetime] NULL,
	[ChangeUser] [varchar](30) NULL,
	[ChangeType] [tinyint] NULL,
 CONSTRAINT [PK_Jurisdictions] PRIMARY KEY CLUSTERED 
(
	[JurisdictionId] ASC,
	[TaxYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_Jurisdiction] UNIQUE NONCLUSTERED 
(
	[StateCd] ASC,
	[Name] ASC,
	[TaxYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LocationIssues]    Script Date: 9/19/2014 10:52:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LocationIssues](
	[ClientId] [bigint] NOT NULL,
	[LocationId] [bigint] NOT NULL,
	[SeqNo] [int] NOT NULL,
	[Description] [varchar](8000) NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUser] [varchar](30) NULL,
	[ChangeDate] [datetime] NULL,
	[ChangeUser] [varchar](30) NULL,
	[ChangeType] [tinyint] NULL,
 CONSTRAINT [PK_LocationIssues] PRIMARY KEY CLUSTERED 
(
	[ClientId] ASC,
	[LocationId] ASC,
	[SeqNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LocationsBPP]    Script Date: 9/19/2014 10:52:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LocationsBPP](
	[ClientId] [bigint] NOT NULL,
	[LocationId] [bigint] NOT NULL,
	[TaxYear] [smallint] NOT NULL,
	[Address] [varchar](50) NULL,
	[Name] [varchar](50) NULL,
	[City] [varchar](50) NULL,
	[StateCd] [char](2) NOT NULL,
	[Zip] [varchar](50) NULL,
	[LegalDescription] [varchar](255) NULL,
	[LegalOwner] [varchar](255) NULL,
	[ClientLocationId] [varchar](255) NULL,
	[Comment] [varchar](255) NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUser] [varchar](30) NULL,
	[ChangeDate] [datetime] NULL,
	[ChangeUser] [varchar](30) NULL,
	[ChangeType] [tinyint] NULL,
	[CustomFl1] [bit] NULL,
	[CustomFl2] [bit] NULL,
	[CustomFl3] [bit] NULL,
	[CustomDate1] [datetime] NULL,
	[CustomDate2] [datetime] NULL,
	[CustomDate3] [datetime] NULL,
	[CustomText1] [varchar](255) NULL,
	[CustomText2] [varchar](255) NULL,
	[CustomText3] [varchar](255) NULL,
	[InactiveFl] [bit] NULL,
 CONSTRAINT [PK_LocationsBPP] PRIMARY KEY CLUSTERED 
(
	[ClientId] ASC,
	[LocationId] ASC,
	[TaxYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_LocationsBPP] UNIQUE NONCLUSTERED 
(
	[LocationId] ASC,
	[TaxYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LocationsRE]    Script Date: 9/19/2014 10:52:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LocationsRE](
	[ClientId] [bigint] NOT NULL,
	[LocationId] [bigint] NOT NULL,
	[TaxYear] [smallint] NOT NULL,
	[Address] [varchar](50) NULL,
	[Name] [varchar](50) NULL,
	[City] [varchar](50) NULL,
	[StateCd] [char](2) NOT NULL,
	[Zip] [varchar](50) NULL,
	[LegalDescription] [varchar](255) NULL,
	[LegalOwner] [varchar](255) NULL,
	[ClientLocationId] [varchar](255) NULL,
	[Comment] [varchar](255) NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUser] [varchar](30) NULL,
	[ChangeDate] [datetime] NULL,
	[ChangeUser] [varchar](30) NULL,
	[ChangeType] [tinyint] NULL,
	[CustomFl1] [bit] NULL,
	[CustomFl2] [bit] NULL,
	[CustomFl3] [bit] NULL,
	[CustomDate1] [datetime] NULL,
	[CustomDate2] [datetime] NULL,
	[CustomDate3] [datetime] NULL,
	[CustomText1] [varchar](255) NULL,
	[CustomText2] [varchar](255) NULL,
	[CustomText3] [varchar](255) NULL,
	[InactiveFl] [bit] NULL,
 CONSTRAINT [PK_LocationsReal] PRIMARY KEY CLUSTERED 
(
	[ClientId] ASC,
	[LocationId] ASC,
	[TaxYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProspectLocations]    Script Date: 9/19/2014 10:52:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProspectLocations](
	[ClientId] [bigint] NOT NULL,
	[LocationId] [bigint] NOT NULL,
	[AssessorId] [bigint] NOT NULL,
	[AcctNum] [varchar](50) NOT NULL,
	[PropType] [char](1) NOT NULL,
	[Address] [varchar](255) NULL,
	[City] [varchar](255) NULL,
	[StateCd] [char](2) NOT NULL,
	[Zip] [varchar](10) NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUser] [varchar](30) NULL,
	[ChangeDate] [datetime] NULL,
	[ChangeUser] [varchar](30) NULL,
	[ChangeType] [tinyint] NULL,
	[Notes] [varchar](1000) NULL,
	[SICCode] [varchar](255) NULL,
	[BusDesc] [varchar](255) NULL,
	[RenditionFilingStatus] [varchar](255) NULL,
 CONSTRAINT [PK_ProspectLocations] PRIMARY KEY CLUSTERED 
(
	[ClientId] ASC,
	[LocationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProspectValues]    Script Date: 9/19/2014 10:52:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProspectValues](
	[ClientId] [bigint] NOT NULL,
	[LocationId] [bigint] NOT NULL,
	[TaxYear] [smallint] NOT NULL,
	[MarketValue] [float] NULL,
	[FreeportValue] [float] NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUser] [varchar](30) NULL,
	[ChangeDate] [datetime] NULL,
	[ChangeUser] [varchar](30) NULL,
	[ChangeType] [tinyint] NULL,
 CONSTRAINT [PK_ProspectValues] PRIMARY KEY CLUSTERED 
(
	[ClientId] ASC,
	[LocationId] ASC,
	[TaxYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ReportData]    Script Date: 9/19/2014 10:52:46 AM ******/
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
 CONSTRAINT [PK_ReportData] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SavingsExemptions]    Script Date: 9/19/2014 10:52:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SavingsExemptions](
	[ClientId] [bigint] NOT NULL,
	[AcctNum] [nchar](50) NOT NULL,
	[ExemptionType] [char](1) NULL,
	[TaxYear] [smallint] NULL,
	[RealOrPersonal] [nchar](1) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StateClientGLCodeXRef]    Script Date: 9/19/2014 10:52:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StateClientGLCodeXRef](
	[ClientId] [bigint] NOT NULL,
	[StateCd] [char](2) NOT NULL,
	[ClientGLCode] [varchar](50) NOT NULL,
	[TaxYear] [smallint] NOT NULL,
	[StateFactorCode] [varchar](50) NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUser] [varchar](30) NULL,
	[ChangeDate] [datetime] NULL,
	[ChangeUser] [varchar](30) NULL,
	[ChangeType] [tinyint] NULL,
 CONSTRAINT [PK_StateClientGLCodeXRef] PRIMARY KEY CLUSTERED 
(
	[ClientId] ASC,
	[StateCd] ASC,
	[ClientGLCode] ASC,
	[TaxYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StateFactorCodes]    Script Date: 9/19/2014 10:52:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StateFactorCodes](
	[StateCd] [char](2) NOT NULL,
	[StateFactorCode] [varchar](50) NOT NULL,
	[TaxYear] [smallint] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](255) NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUser] [varchar](30) NULL,
	[ChangeDate] [datetime] NULL,
	[ChangeUser] [varchar](30) NULL,
	[ChangeType] [tinyint] NULL,
 CONSTRAINT [PK_StateDeprCodes] PRIMARY KEY CLUSTERED 
(
	[StateCd] ASC,
	[StateFactorCode] ASC,
	[TaxYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_StateDeprCodes] UNIQUE NONCLUSTERED 
(
	[StateCd] ASC,
	[TaxYear] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StateForms]    Script Date: 9/19/2014 10:52:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StateForms](
	[FormId] [bigint] NOT NULL,
	[TaxYear] [smallint] NOT NULL,
	[StateCd] [char](2) NOT NULL,
	[FormName] [varchar](255) NOT NULL,
	[FormData] [image] NULL,
	[FormDescription] [varchar](255) NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUser] [varchar](30) NULL,
	[ChangeDate] [datetime] NULL,
	[ChangeUser] [varchar](30) NULL,
	[ChangeType] [tinyint] NULL,
 CONSTRAINT [PK_StateForm] PRIMARY KEY CLUSTERED 
(
	[FormId] ASC,
	[TaxYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY],
 CONSTRAINT [IX_StateForm] UNIQUE NONCLUSTERED 
(
	[StateCd] ASC,
	[FormName] ASC,
	[TaxYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StateFormsXRef]    Script Date: 9/19/2014 10:52:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StateFormsXRef](
	[FormId] [bigint] NOT NULL,
	[PDFFieldName] [varchar](500) NOT NULL,
	[TaxYear] [smallint] NOT NULL,
	[TableName] [varchar](50) NULL,
	[FieldName] [varchar](50) NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUser] [varchar](30) NULL,
	[ChangeDate] [datetime] NULL,
	[ChangeUser] [varchar](30) NULL,
	[ChangeType] [tinyint] NULL,
 CONSTRAINT [PK_StateFormXRef] PRIMARY KEY CLUSTERED 
(
	[FormId] ASC,
	[PDFFieldName] ASC,
	[TaxYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[States]    Script Date: 9/19/2014 10:52:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[States](
	[StateCd] [char](2) NOT NULL,
	[StateName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_State] PRIMARY KEY CLUSTERED 
(
	[StateCd] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY],
 CONSTRAINT [IX_State] UNIQUE NONCLUSTERED 
(
	[StateName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TableDefinition]    Script Date: 9/19/2014 10:52:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TableDefinition](
	[TableName] [varchar](50) NOT NULL,
	[Description] [varchar](50) NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUser] [varchar](30) NULL,
	[ChangeDate] [datetime] NULL,
	[ChangeUser] [varchar](30) NULL,
	[ChangeType] [tinyint] NULL,
 CONSTRAINT [PK_TableDefinition] PRIMARY KEY CLUSTERED 
(
	[TableName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TaskAssignment]    Script Date: 9/19/2014 10:52:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TaskAssignment](
	[TaskId] [bigint] NOT NULL,
	[Entity] [varchar](50) NOT NULL,
	[EntityId] [varchar](50) NOT NULL,
	[EntityLevel] [varchar](50) NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUser] [varchar](30) NULL,
	[ChangeDate] [datetime] NULL,
	[ChangeUser] [varchar](30) NULL,
	[ChangeType] [tinyint] NULL,
 CONSTRAINT [PK_Task_Assignment] PRIMARY KEY CLUSTERED 
(
	[TaskId] ASC,
	[Entity] ASC,
	[EntityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TaskEvents]    Script Date: 9/19/2014 10:52:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TaskEvents](
	[TaskId] [bigint] NOT NULL,
	[Entity] [varchar](50) NOT NULL,
	[EntityId] [varchar](50) NOT NULL,
	[TaskDate] [datetime] NULL,
	[Comment] [varchar](255) NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUser] [varchar](30) NULL,
	[ChangeDate] [datetime] NULL,
	[ChangeUser] [varchar](30) NULL,
	[ChangeType] [tinyint] NULL,
 CONSTRAINT [PK_Task_Events] PRIMARY KEY CLUSTERED 
(
	[TaskId] ASC,
	[Entity] ASC,
	[EntityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TaskGroup]    Script Date: 9/19/2014 10:52:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TaskGroup](
	[GroupId] [bigint] NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[Description] [varchar](255) NULL,
	[Entity] [varchar](50) NOT NULL,
	[EntityId] [varchar](50) NOT NULL,
	[EntityLevel] [varchar](50) NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUser] [varchar](30) NULL,
	[ChangeDate] [datetime] NULL,
	[ChangeUser] [varchar](30) NULL,
	[ChangeType] [tinyint] NULL,
 CONSTRAINT [PK__Task_Group__37FA4C37] PRIMARY KEY CLUSTERED 
(
	[GroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY],
 CONSTRAINT [IX_Task_Group] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TaskGroupDetail]    Script Date: 9/19/2014 10:52:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TaskGroupDetail](
	[GroupId] [bigint] NOT NULL,
	[TaskId] [bigint] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUser] [varchar](30) NULL,
	[ChangeDate] [datetime] NULL,
	[ChangeUser] [varchar](30) NULL,
	[ChangeType] [tinyint] NULL,
 CONSTRAINT [PK__Task_GroupList__3AD6B8E2] PRIMARY KEY CLUSTERED 
(
	[GroupId] ASC,
	[TaskId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TaskMasterList]    Script Date: 9/19/2014 10:52:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TaskMasterList](
	[TaskId] [bigint] NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[Description] [varchar](255) NULL,
	[TaskDate] [datetime] NULL,
	[Recurrence] [smallint] NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUser] [varchar](30) NULL,
	[ChangeDate] [datetime] NULL,
	[ChangeUser] [varchar](30) NULL,
	[ChangeType] [tinyint] NULL,
 CONSTRAINT [PK__Task_MasterList__351DDF8C] PRIMARY KEY CLUSTERED 
(
	[TaskId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY],
 CONSTRAINT [IX_Task_MasterList] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TaxBillsBPP]    Script Date: 9/19/2014 10:52:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TaxBillsBPP](
	[ClientId] [bigint] NOT NULL,
	[LocationId] [bigint] NOT NULL,
	[AssessmentId] [bigint] NOT NULL,
	[CollectorId] [bigint] NOT NULL,
	[TaxYear] [smallint] NOT NULL,
	[FormData] [image] NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUser] [varchar](30) NULL,
	[ChangeDate] [datetime] NULL,
	[ChangeUser] [varchar](30) NULL,
	[ChangeType] [tinyint] NULL,
 CONSTRAINT [PK_TaxBillsBPP] PRIMARY KEY CLUSTERED 
(
	[ClientId] ASC,
	[LocationId] ASC,
	[AssessmentId] ASC,
	[CollectorId] ASC,
	[TaxYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TaxBillsRE]    Script Date: 9/19/2014 10:52:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TaxBillsRE](
	[ClientId] [bigint] NOT NULL,
	[LocationId] [bigint] NOT NULL,
	[AssessmentId] [bigint] NOT NULL,
	[CollectorId] [bigint] NOT NULL,
	[TaxYear] [smallint] NOT NULL,
	[FormData] [image] NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUser] [varchar](30) NULL,
	[ChangeDate] [datetime] NULL,
	[ChangeUser] [varchar](30) NULL,
	[ChangeType] [tinyint] NULL,
 CONSTRAINT [PK_TaxBillsRE] PRIMARY KEY CLUSTERED 
(
	[ClientId] ASC,
	[LocationId] ASC,
	[AssessmentId] ASC,
	[CollectorId] ASC,
	[TaxYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TaxReturnGroupJunction]    Script Date: 9/19/2014 10:52:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaxReturnGroupJunction](
	[DeprCodeId] [bigint] NOT NULL,
	[GroupId] [bigint] NOT NULL,
	[TaxYear] [smallint] NOT NULL,
 CONSTRAINT [PK_TaxReturnGroupJunction] PRIMARY KEY CLUSTERED 
(
	[DeprCodeId] ASC,
	[GroupId] ASC,
	[TaxYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TaxReturnGroups]    Script Date: 9/19/2014 10:52:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TaxReturnGroups](
	[GroupId] [bigint] NOT NULL,
	[FormId] [bigint] NOT NULL,
	[GroupName] [varchar](255) NOT NULL,
	[TaxYear] [smallint] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUser] [varchar](30) NULL,
	[ChangeDate] [datetime] NULL,
	[ChangeUser] [varchar](30) NULL,
	[ChangeType] [tinyint] NULL,
 CONSTRAINT [PK__TaxReturnGroup__2057CCD0] PRIMARY KEY CLUSTERED 
(
	[GroupId] ASC,
	[TaxYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY],
 CONSTRAINT [IX_TaxReturnGroup_1] UNIQUE NONCLUSTERED 
(
	[FormId] ASC,
	[GroupName] ASC,
	[TaxYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserQuery]    Script Date: 9/19/2014 10:52:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserQuery](
	[QueryId] [bigint] NOT NULL,
	[QueryType] [bigint] NOT NULL,
	[QueryName] [varchar](50) NOT NULL,
	[Description] [varchar](255) NULL,
	[OrderBy] [varchar](1000) NULL,
	[QuerySQL] [varchar](8000) NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUser] [varchar](30) NULL,
	[ChangeDate] [datetime] NULL,
	[ChangeUser] [varchar](30) NULL,
	[ChangeType] [tinyint] NULL,
 CONSTRAINT [PK__UserQuery__114A936A] PRIMARY KEY CLUSTERED 
(
	[QueryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY],
 CONSTRAINT [IX_UserQuery] UNIQUE NONCLUSTERED 
(
	[QueryName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserQueryDetail]    Script Date: 9/19/2014 10:52:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserQueryDetail](
	[QueryId] [bigint] NOT NULL,
	[QuerySeqNo] [int] NOT NULL,
	[QueryOpenParen] [varchar](50) NULL,
	[QueryCondition] [varchar](3) NULL,
	[QueryField] [varchar](50) NOT NULL,
	[QueryOperator] [varchar](2) NOT NULL,
	[QueryFieldValue] [varchar](255) NULL,
	[QueryValueType] [varchar](1) NOT NULL,
	[QueryClosedParen] [varchar](50) NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUser] [varchar](30) NULL,
	[ChangeDate] [datetime] NULL,
	[ChangeUser] [varchar](30) NULL,
	[ChangeType] [tinyint] NULL,
 CONSTRAINT [PK__UserQueryDetail__14270015] PRIMARY KEY CLUSTERED 
(
	[QueryId] ASC,
	[QuerySeqNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserQuerySelect]    Script Date: 9/19/2014 10:52:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserQuerySelect](
	[QueryId] [bigint] NOT NULL,
	[QuerySeqNo] [int] NOT NULL,
	[QueryTable] [varchar](50) NOT NULL,
	[QueryField] [varchar](50) NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUser] [varchar](30) NULL,
	[ChangeDate] [datetime] NULL,
	[ChangeUser] [varchar](30) NULL,
	[ChangeType] [tinyint] NULL,
 CONSTRAINT [PK_UserQuerySelect] PRIMARY KEY CLUSTERED 
(
	[QueryId] ASC,
	[QuerySeqNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY],
 CONSTRAINT [IX_UserQuerySelect] UNIQUE NONCLUSTERED 
(
	[QueryId] ASC,
	[QueryTable] ASC,
	[QueryField] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_AssessmentsBPP_1]    Script Date: 9/19/2014 10:52:46 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_AssessmentsBPP_1] ON [dbo].[AssessmentsBPP]
(
	[ClientId] ASC,
	[LocationId] ASC,
	[AssessorId] ASC,
	[AcctNum] ASC,
	[TaxYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FactorEntity1]    Script Date: 9/19/2014 10:52:46 AM ******/
CREATE NONCLUSTERED INDEX [IX_FactorEntity1] ON [dbo].[AssessmentsBPP]
(
	[ClientId] ASC,
	[FactorEntityId1] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FactorEntity2]    Script Date: 9/19/2014 10:52:46 AM ******/
CREATE NONCLUSTERED INDEX [IX_FactorEntity2] ON [dbo].[AssessmentsBPP]
(
	[ClientId] ASC,
	[FactorEntityId2] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FactorEntity3]    Script Date: 9/19/2014 10:52:46 AM ******/
CREATE NONCLUSTERED INDEX [IX_FactorEntity3] ON [dbo].[AssessmentsBPP]
(
	[ClientId] ASC,
	[FactorEntityId3] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FactorEntity4]    Script Date: 9/19/2014 10:52:46 AM ******/
CREATE NONCLUSTERED INDEX [IX_FactorEntity4] ON [dbo].[AssessmentsBPP]
(
	[ClientId] ASC,
	[FactorEntityId4] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FactorEntity5]    Script Date: 9/19/2014 10:52:46 AM ******/
CREATE NONCLUSTERED INDEX [IX_FactorEntity5] ON [dbo].[AssessmentsBPP]
(
	[ClientId] ASC,
	[FactorEntityId5] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_AssessmentsRE]    Script Date: 9/19/2014 10:52:46 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_AssessmentsRE] ON [dbo].[AssessmentsRE]
(
	[ClientId] ASC,
	[LocationId] ASC,
	[AssessorId] ASC,
	[AcctNum] ASC,
	[TaxYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_AssessmentsRE_1]    Script Date: 9/19/2014 10:52:46 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_AssessmentsRE_1] ON [dbo].[AssessmentsRE]
(
	[AssessmentId] ASC,
	[TaxYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Assets]    Script Date: 9/19/2014 10:52:46 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Assets] ON [dbo].[Assets]
(
	[ClientId] ASC,
	[LocationId] ASC,
	[AssessmentId] ASC,
	[AssetId] ASC,
	[TaxYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ClientComments]    Script Date: 9/19/2014 10:52:46 AM ******/
CREATE NONCLUSTERED INDEX [IX_ClientComments] ON [dbo].[ClientComments]
(
	[ClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_ClientFactorCodeOverrides]    Script Date: 9/19/2014 10:52:46 AM ******/
CREATE NONCLUSTERED INDEX [IX_ClientFactorCodeOverrides] ON [dbo].[ClientFactorCodeOverrides]
(
	[FactorEntityId] ASC,
	[FactorCode] ASC,
	[TaxYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_ClientGLCodeXRef]    Script Date: 9/19/2014 10:52:46 AM ******/
CREATE NONCLUSTERED INDEX [IX_ClientGLCodeXRef] ON [dbo].[ClientGLCodeXRef]
(
	[FactorEntityId] ASC,
	[FactorCode] ASC,
	[TaxYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [idx_ChangeType]    Script Date: 9/19/2014 10:52:46 AM ******/
CREATE NONCLUSTERED INDEX [idx_ChangeType] ON [dbo].[Clients]
(
	[ChangeType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
/****** Object:  Index [idx_ProspectFl]    Script Date: 9/19/2014 10:52:46 AM ******/
CREATE NONCLUSTERED INDEX [idx_ProspectFl] ON [dbo].[Clients]
(
	[ProspectFl] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_ClientFactorXRef]    Script Date: 9/19/2014 10:52:46 AM ******/
CREATE NONCLUSTERED INDEX [IX_ClientFactorXRef] ON [dbo].[FactorCodeXRef]
(
	[FactorEntityId] ASC,
	[EntityFactorCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_FactorEntities]    Script Date: 9/19/2014 10:52:46 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_FactorEntities] ON [dbo].[FactorEntities]
(
	[Name] ASC,
	[StateCd] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_FactorEntityCodes]    Script Date: 9/19/2014 10:52:46 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_FactorEntityCodes] ON [dbo].[FactorEntityCodes]
(
	[FactorEntityId] ASC,
	[TaxYear] ASC,
	[Description] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_InstallmentsBPP]    Script Date: 9/19/2014 10:52:46 AM ******/
CREATE NONCLUSTERED INDEX [IX_InstallmentsBPP] ON [dbo].[InstallmentsBPP]
(
	[ClientId] ASC,
	[LocationId] ASC,
	[AssessmentId] ASC,
	[CollectorId] ASC,
	[TaxYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_InstallmentsRE]    Script Date: 9/19/2014 10:52:46 AM ******/
CREATE NONCLUSTERED INDEX [IX_InstallmentsRE] ON [dbo].[InstallmentsRE]
(
	[ClientId] ASC,
	[LocationId] ASC,
	[AssessmentId] ASC,
	[CollectorId] ASC,
	[TaxYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_LocationsBPP_1]    Script Date: 9/19/2014 10:52:46 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_LocationsBPP_1] ON [dbo].[LocationsBPP]
(
	[ClientId] ASC,
	[Address] ASC,
	[City] ASC,
	[StateCd] ASC,
	[TaxYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [idx_ChangeType]    Script Date: 9/19/2014 10:52:46 AM ******/
CREATE NONCLUSTERED INDEX [idx_ChangeType] ON [dbo].[LocationsRE]
(
	[ChangeType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
/****** Object:  Index [IX_LocationsRE]    Script Date: 9/19/2014 10:52:46 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_LocationsRE] ON [dbo].[LocationsRE]
(
	[LocationId] ASC,
	[TaxYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_LocationsRE_1]    Script Date: 9/19/2014 10:52:46 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_LocationsRE_1] ON [dbo].[LocationsRE]
(
	[ClientId] ASC,
	[Address] ASC,
	[City] ASC,
	[StateCd] ASC,
	[TaxYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_ProspectLocations]    Script Date: 9/19/2014 10:52:46 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_ProspectLocations] ON [dbo].[ProspectLocations]
(
	[AssessorId] ASC,
	[AcctNum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProspectLocations_1]    Script Date: 9/19/2014 10:52:46 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_ProspectLocations_1] ON [dbo].[ProspectLocations]
(
	[LocationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_ReportData]    Script Date: 9/19/2014 10:52:46 AM ******/
CREATE NONCLUSTERED INDEX [IX_ReportData] ON [dbo].[ReportData]
(
	[UserName] ASC,
	[ReportId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TaxBillsBPP]    Script Date: 9/19/2014 10:52:46 AM ******/
CREATE NONCLUSTERED INDEX [IX_TaxBillsBPP] ON [dbo].[TaxBillsBPP]
(
	[ClientId] ASC,
	[LocationId] ASC,
	[AssessmentId] ASC,
	[TaxYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TaxBillsRE]    Script Date: 9/19/2014 10:52:46 AM ******/
CREATE NONCLUSTERED INDEX [IX_TaxBillsRE] ON [dbo].[TaxBillsRE]
(
	[ClientId] ASC,
	[LocationId] ASC,
	[AssessmentId] ASC,
	[TaxYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AssessmentDetailBPP] ADD  CONSTRAINT [DF_AssessmentDetailBPP_AddDate]  DEFAULT (getdate()) FOR [AddDate]
GO
ALTER TABLE [dbo].[AssessmentDetailRE] ADD  CONSTRAINT [DF_AssessmentDetailReal_AddDate]  DEFAULT (getdate()) FOR [AddDate]
GO
ALTER TABLE [dbo].[AssessmentsBPP] ADD  CONSTRAINT [DF_AssessmentsBPP_AddDate]  DEFAULT (getdate()) FOR [AddDate]
GO
ALTER TABLE [dbo].[AssessmentsRE] ADD  CONSTRAINT [DF_AssessmentsReal_AddDate]  DEFAULT (getdate()) FOR [AddDate]
GO
ALTER TABLE [dbo].[Assessors] ADD  CONSTRAINT [DF_Assessor_AddDate]  DEFAULT (getdate()) FOR [AddDate]
GO
ALTER TABLE [dbo].[Assets] ADD  CONSTRAINT [DF_Asset_PurchaseDate]  DEFAULT (getdate()) FOR [PurchaseDate]
GO
ALTER TABLE [dbo].[Assets] ADD  CONSTRAINT [DF_Asset_AddDate]  DEFAULT (getdate()) FOR [AddDate]
GO
ALTER TABLE [dbo].[Assets] ADD  CONSTRAINT [DF_Assets_AllocationPct]  DEFAULT ((1)) FOR [AllocationPct]
GO
ALTER TABLE [dbo].[ClientComments] ADD  DEFAULT (getdate()) FOR [AddDate]
GO
ALTER TABLE [dbo].[ClientFactorCodeOverrides] ADD  CONSTRAINT [DF_ClientFactorCodeOverrides_AddDate]  DEFAULT (getdate()) FOR [AddDate]
GO
ALTER TABLE [dbo].[ClientForms] ADD  CONSTRAINT [DF_ClientForms_AddDate]  DEFAULT (getdate()) FOR [AddDate]
GO
ALTER TABLE [dbo].[ClientFormsXRef] ADD  CONSTRAINT [DF__ClientForm__AddDa__0D44F85C]  DEFAULT (getdate()) FOR [AddDate]
GO
ALTER TABLE [dbo].[ClientGLCodes] ADD  CONSTRAINT [DF__ClientGLC__AddDa__4F9CCB9E]  DEFAULT (getdate()) FOR [AddDate]
GO
ALTER TABLE [dbo].[ClientGLCodeXRef] ADD  CONSTRAINT [DF_ClientGLCodeXRef_AddDate]  DEFAULT (getdate()) FOR [AddDate]
GO
ALTER TABLE [dbo].[Clients] ADD  CONSTRAINT [DF_Client_AddDate]  DEFAULT (getdate()) FOR [AddDate]
GO
ALTER TABLE [dbo].[Collectors] ADD  CONSTRAINT [DF__Collector__AddDa__0F624AF8]  DEFAULT (getdate()) FOR [AddDate]
GO
ALTER TABLE [dbo].[Consultants] ADD  CONSTRAINT [DF__Consultan__AddDa__690797E6]  DEFAULT (getdate()) FOR [AddDate]
GO
ALTER TABLE [dbo].[FactorCodeOverrides] ADD  CONSTRAINT [DF_FactorCodeOverridesNew_AddDate]  DEFAULT (getdate()) FOR [AddDate]
GO
ALTER TABLE [dbo].[FactorCodeXRef] ADD  CONSTRAINT [DF__ClientFac__AddDa__50C5FA01]  DEFAULT (getdate()) FOR [AddDate]
GO
ALTER TABLE [dbo].[FactorEntities] ADD  CONSTRAINT [DF__FactorEnt__AddDa__53A266AC]  DEFAULT (getdate()) FOR [AddDate]
GO
ALTER TABLE [dbo].[FactorEntityCodes] ADD  CONSTRAINT [DF__FactorEnt__AddDa__567ED357]  DEFAULT (getdate()) FOR [AddDate]
GO
ALTER TABLE [dbo].[Factors] ADD  CONSTRAINT [DF__Factors__AddDate__595B4002]  DEFAULT (getdate()) FOR [AddDate]
GO
ALTER TABLE [dbo].[FieldDataDefinition] ADD  DEFAULT (getdate()) FOR [AddDate]
GO
ALTER TABLE [dbo].[FieldDefinition] ADD  CONSTRAINT [DF_FieldDefinition_AddDate]  DEFAULT (getdate()) FOR [AddDate]
GO
ALTER TABLE [dbo].[FirmInfo] ADD  CONSTRAINT [DF__AgentInfo__AddDa__6166761E]  DEFAULT (getdate()) FOR [AddDate]
GO
ALTER TABLE [dbo].[InstallmentsBPP] ADD  CONSTRAINT [DF_InstallmentsBPP_AddDate]  DEFAULT (getdate()) FOR [AddDate]
GO
ALTER TABLE [dbo].[InstallmentsRE] ADD  CONSTRAINT [DF_InstallmentsRE_AddDate]  DEFAULT (getdate()) FOR [AddDate]
GO
ALTER TABLE [dbo].[Inventory] ADD  CONSTRAINT [DF__Inventory__AddDa__245D67DE]  DEFAULT (getdate()) FOR [AddDate]
GO
ALTER TABLE [dbo].[Jurisdictions] ADD  CONSTRAINT [DF_Jurisdiction_AddDate]  DEFAULT (getdate()) FOR [AddDate]
GO
ALTER TABLE [dbo].[LocationsBPP] ADD  CONSTRAINT [DF_LocationsBPP_AddDate]  DEFAULT (getdate()) FOR [AddDate]
GO
ALTER TABLE [dbo].[LocationsRE] ADD  CONSTRAINT [DF_Location_AddDate]  DEFAULT (getdate()) FOR [AddDate]
GO
ALTER TABLE [dbo].[ProspectLocations] ADD  DEFAULT (getdate()) FOR [AddDate]
GO
ALTER TABLE [dbo].[ProspectValues] ADD  DEFAULT (getdate()) FOR [AddDate]
GO
ALTER TABLE [dbo].[StateClientGLCodeXRef] ADD  CONSTRAINT [DF__StateDepr__AddDa__15A53433]  DEFAULT (getdate()) FOR [AddDate]
GO
ALTER TABLE [dbo].[StateFactorCodes] ADD  CONSTRAINT [DF__StateDepr__AddDa__1881A0DE]  DEFAULT (getdate()) FOR [AddDate]
GO
ALTER TABLE [dbo].[StateForms] ADD  CONSTRAINT [DF_StateForms_AddDate]  DEFAULT (getdate()) FOR [AddDate]
GO
ALTER TABLE [dbo].[StateFormsXRef] ADD  CONSTRAINT [DF__StateForm__AddDa__0D44F85C]  DEFAULT (getdate()) FOR [AddDate]
GO
ALTER TABLE [dbo].[TableDefinition] ADD  CONSTRAINT [DF_TableDefinition_AddDate]  DEFAULT (getdate()) FOR [AddDate]
GO
ALTER TABLE [dbo].[TaskAssignment] ADD  CONSTRAINT [DF__Task_Assi__AddDa__3EA749C6]  DEFAULT (getdate()) FOR [AddDate]
GO
ALTER TABLE [dbo].[TaskEvents] ADD  CONSTRAINT [DF__Task_Even__AddDa__0539C240]  DEFAULT (getdate()) FOR [AddDate]
GO
ALTER TABLE [dbo].[TaskGroup] ADD  CONSTRAINT [DF__Task_Grou__AddDa__38EE7070]  DEFAULT (getdate()) FOR [AddDate]
GO
ALTER TABLE [dbo].[TaskGroupDetail] ADD  CONSTRAINT [DF__Task_Grou__AddDa__3BCADD1B]  DEFAULT (getdate()) FOR [AddDate]
GO
ALTER TABLE [dbo].[TaskMasterList] ADD  CONSTRAINT [DF__Task_Mast__AddDa__361203C5]  DEFAULT (getdate()) FOR [AddDate]
GO
ALTER TABLE [dbo].[TaxBillsBPP] ADD  CONSTRAINT [DF_TaxBillsBPP_AddDate]  DEFAULT (getdate()) FOR [AddDate]
GO
ALTER TABLE [dbo].[TaxBillsRE] ADD  CONSTRAINT [DF_TaxBillsRE_AddDate]  DEFAULT (getdate()) FOR [AddDate]
GO
ALTER TABLE [dbo].[TaxReturnGroups] ADD  CONSTRAINT [DF__TaxReturn__AddDa__214BF109]  DEFAULT (getdate()) FOR [AddDate]
GO
ALTER TABLE [dbo].[UserQuery] ADD  CONSTRAINT [DF__UserQuery__AddDa__123EB7A3]  DEFAULT (getdate()) FOR [AddDate]
GO
ALTER TABLE [dbo].[UserQueryDetail] ADD  CONSTRAINT [DF__UserQuery__AddDa__151B244E]  DEFAULT (getdate()) FOR [AddDate]
GO
ALTER TABLE [dbo].[UserQuerySelect] ADD  CONSTRAINT [DF_UserQuerySelect_AddDate]  DEFAULT (getdate()) FOR [AddDate]
GO
ALTER TABLE [dbo].[AssessmentDetailBPP]  WITH CHECK ADD  CONSTRAINT [FK_AssessmentDetailBPP_AssessmentsBPP] FOREIGN KEY([ClientId], [LocationId], [AssessmentId], [TaxYear])
REFERENCES [dbo].[AssessmentsBPP] ([ClientId], [LocationId], [AssessmentId], [TaxYear])
GO
ALTER TABLE [dbo].[AssessmentDetailBPP] CHECK CONSTRAINT [FK_AssessmentDetailBPP_AssessmentsBPP]
GO
ALTER TABLE [dbo].[AssessmentDetailBPP]  WITH CHECK ADD  CONSTRAINT [FK_AssessmentDetailBPP_Jurisdictions] FOREIGN KEY([JurisdictionId], [TaxYear])
REFERENCES [dbo].[Jurisdictions] ([JurisdictionId], [TaxYear])
GO
ALTER TABLE [dbo].[AssessmentDetailBPP] CHECK CONSTRAINT [FK_AssessmentDetailBPP_Jurisdictions]
GO
ALTER TABLE [dbo].[AssessmentDetailRE]  WITH CHECK ADD  CONSTRAINT [FK_AssessmentDetailRE_AssessmentsRE] FOREIGN KEY([ClientId], [LocationId], [AssessmentId], [TaxYear])
REFERENCES [dbo].[AssessmentsRE] ([ClientId], [LocationId], [AssessmentId], [TaxYear])
GO
ALTER TABLE [dbo].[AssessmentDetailRE] CHECK CONSTRAINT [FK_AssessmentDetailRE_AssessmentsRE]
GO
ALTER TABLE [dbo].[AssessmentDetailRE]  WITH CHECK ADD  CONSTRAINT [FK_AssessmentDetailRE_Jurisdictions] FOREIGN KEY([JurisdictionId], [TaxYear])
REFERENCES [dbo].[Jurisdictions] ([JurisdictionId], [TaxYear])
GO
ALTER TABLE [dbo].[AssessmentDetailRE] CHECK CONSTRAINT [FK_AssessmentDetailRE_Jurisdictions]
GO
ALTER TABLE [dbo].[AssessmentsBPP]  WITH NOCHECK ADD  CONSTRAINT [FK_AssessmentsBPP_Assessors] FOREIGN KEY([AssessorId], [TaxYear])
REFERENCES [dbo].[Assessors] ([AssessorId], [TaxYear])
GO
ALTER TABLE [dbo].[AssessmentsBPP] CHECK CONSTRAINT [FK_AssessmentsBPP_Assessors]
GO
ALTER TABLE [dbo].[AssessmentsBPP]  WITH CHECK ADD  CONSTRAINT [FK_AssessmentsBPP_LocationsBPP] FOREIGN KEY([ClientId], [LocationId], [TaxYear])
REFERENCES [dbo].[LocationsBPP] ([ClientId], [LocationId], [TaxYear])
GO
ALTER TABLE [dbo].[AssessmentsBPP] CHECK CONSTRAINT [FK_AssessmentsBPP_LocationsBPP]
GO
ALTER TABLE [dbo].[AssessmentsRE]  WITH CHECK ADD  CONSTRAINT [FK_AssessmentsRE_LocationsRE] FOREIGN KEY([ClientId], [LocationId], [TaxYear])
REFERENCES [dbo].[LocationsRE] ([ClientId], [LocationId], [TaxYear])
GO
ALTER TABLE [dbo].[AssessmentsRE] CHECK CONSTRAINT [FK_AssessmentsRE_LocationsRE]
GO
ALTER TABLE [dbo].[AssessmentsRE]  WITH CHECK ADD  CONSTRAINT [FK_AssessmentsReal_Assessors] FOREIGN KEY([AssessorId], [TaxYear])
REFERENCES [dbo].[Assessors] ([AssessorId], [TaxYear])
GO
ALTER TABLE [dbo].[AssessmentsRE] CHECK CONSTRAINT [FK_AssessmentsReal_Assessors]
GO
ALTER TABLE [dbo].[Assessors]  WITH NOCHECK ADD  CONSTRAINT [FK_Assessor_State] FOREIGN KEY([StateCd])
REFERENCES [dbo].[States] ([StateCd])
GO
ALTER TABLE [dbo].[Assessors] CHECK CONSTRAINT [FK_Assessor_State]
GO
ALTER TABLE [dbo].[Assets]  WITH CHECK ADD  CONSTRAINT [FK_Assets_AssessmentsBPP] FOREIGN KEY([ClientId], [LocationId], [AssessmentId], [TaxYear])
REFERENCES [dbo].[AssessmentsBPP] ([ClientId], [LocationId], [AssessmentId], [TaxYear])
GO
ALTER TABLE [dbo].[Assets] CHECK CONSTRAINT [FK_Assets_AssessmentsBPP]
GO
ALTER TABLE [dbo].[ClientComments]  WITH CHECK ADD  CONSTRAINT [FK_ClientComments_Clients] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Clients] ([ClientId])
GO
ALTER TABLE [dbo].[ClientComments] CHECK CONSTRAINT [FK_ClientComments_Clients]
GO
ALTER TABLE [dbo].[ClientFactorCodeOverrides]  WITH CHECK ADD  CONSTRAINT [FK_ClientFactorCodeOverrides_Assets] FOREIGN KEY([ClientId], [LocationId], [AssessmentId], [AssetId], [TaxYear])
REFERENCES [dbo].[Assets] ([ClientId], [LocationId], [AssessmentId], [AssetId], [TaxYear])
GO
ALTER TABLE [dbo].[ClientFactorCodeOverrides] CHECK CONSTRAINT [FK_ClientFactorCodeOverrides_Assets]
GO
ALTER TABLE [dbo].[ClientFactorCodeOverrides]  WITH CHECK ADD  CONSTRAINT [FK_ClientFactorCodeOverrides_FactorEntityCodes] FOREIGN KEY([FactorEntityId], [FactorCode], [TaxYear])
REFERENCES [dbo].[FactorEntityCodes] ([FactorEntityId], [FactorCode], [TaxYear])
GO
ALTER TABLE [dbo].[ClientFactorCodeOverrides] CHECK CONSTRAINT [FK_ClientFactorCodeOverrides_FactorEntityCodes]
GO
ALTER TABLE [dbo].[ClientForms]  WITH CHECK ADD  CONSTRAINT [FK_ClientForms_Clients] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Clients] ([ClientId])
GO
ALTER TABLE [dbo].[ClientForms] CHECK CONSTRAINT [FK_ClientForms_Clients]
GO
ALTER TABLE [dbo].[ClientForms]  WITH NOCHECK ADD  CONSTRAINT [FK_ClientForms_State] FOREIGN KEY([StateCd])
REFERENCES [dbo].[States] ([StateCd])
GO
ALTER TABLE [dbo].[ClientForms] CHECK CONSTRAINT [FK_ClientForms_State]
GO
ALTER TABLE [dbo].[ClientFormsXRef]  WITH CHECK ADD  CONSTRAINT [FK_ClientFormsXRef_ClientForms] FOREIGN KEY([FormId], [TaxYear])
REFERENCES [dbo].[ClientForms] ([FormId], [TaxYear])
GO
ALTER TABLE [dbo].[ClientFormsXRef] CHECK CONSTRAINT [FK_ClientFormsXRef_ClientForms]
GO
ALTER TABLE [dbo].[ClientFormsXRef]  WITH CHECK ADD  CONSTRAINT [FK_ClientFormsXRef_FieldDefinition] FOREIGN KEY([TableName], [FieldName])
REFERENCES [dbo].[FieldDefinition] ([TableName], [FieldName])
GO
ALTER TABLE [dbo].[ClientFormsXRef] CHECK CONSTRAINT [FK_ClientFormsXRef_FieldDefinition]
GO
ALTER TABLE [dbo].[ClientGLCodes]  WITH NOCHECK ADD  CONSTRAINT [FK_ClientGLCodes_Clients] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Clients] ([ClientId])
GO
ALTER TABLE [dbo].[ClientGLCodes] CHECK CONSTRAINT [FK_ClientGLCodes_Clients]
GO
ALTER TABLE [dbo].[ClientGLCodes]  WITH NOCHECK ADD  CONSTRAINT [FK_ClientGLCodes_States] FOREIGN KEY([StateCd])
REFERENCES [dbo].[States] ([StateCd])
GO
ALTER TABLE [dbo].[ClientGLCodes] CHECK CONSTRAINT [FK_ClientGLCodes_States]
GO
ALTER TABLE [dbo].[ClientGLCodeXRef]  WITH CHECK ADD  CONSTRAINT [FK_ClientGLCodeXRef_ClientGLCodes] FOREIGN KEY([ClientId], [StateCd], [GLCode], [TaxYear])
REFERENCES [dbo].[ClientGLCodes] ([ClientId], [StateCd], [GLCode], [TaxYear])
GO
ALTER TABLE [dbo].[ClientGLCodeXRef] CHECK CONSTRAINT [FK_ClientGLCodeXRef_ClientGLCodes]
GO
ALTER TABLE [dbo].[ClientGLCodeXRef]  WITH CHECK ADD  CONSTRAINT [FK_ClientGLCodeXRef_FactorEntityCodes] FOREIGN KEY([FactorEntityId], [FactorCode], [TaxYear])
REFERENCES [dbo].[FactorEntityCodes] ([FactorEntityId], [FactorCode], [TaxYear])
GO
ALTER TABLE [dbo].[ClientGLCodeXRef] CHECK CONSTRAINT [FK_ClientGLCodeXRef_FactorEntityCodes]
GO
ALTER TABLE [dbo].[Clients]  WITH NOCHECK ADD  CONSTRAINT [FK_Client_State] FOREIGN KEY([StateCd])
REFERENCES [dbo].[States] ([StateCd])
GO
ALTER TABLE [dbo].[Clients] CHECK CONSTRAINT [FK_Client_State]
GO
ALTER TABLE [dbo].[Collectors]  WITH NOCHECK ADD  CONSTRAINT [FK_Collector_State] FOREIGN KEY([StateCd])
REFERENCES [dbo].[States] ([StateCd])
GO
ALTER TABLE [dbo].[Collectors] CHECK CONSTRAINT [FK_Collector_State]
GO
ALTER TABLE [dbo].[Collectors]  WITH CHECK ADD  CONSTRAINT [FK_Collectors_States] FOREIGN KEY([PayeeStateCd])
REFERENCES [dbo].[States] ([StateCd])
GO
ALTER TABLE [dbo].[Collectors] CHECK CONSTRAINT [FK_Collectors_States]
GO
ALTER TABLE [dbo].[FactorCodeOverrides]  WITH CHECK ADD  CONSTRAINT [FK_FactorCodeOverrides_Assets] FOREIGN KEY([ClientId], [LocationId], [AssessmentId], [AssetId], [TaxYear])
REFERENCES [dbo].[Assets] ([ClientId], [LocationId], [AssessmentId], [AssetId], [TaxYear])
GO
ALTER TABLE [dbo].[FactorCodeOverrides] CHECK CONSTRAINT [FK_FactorCodeOverrides_Assets]
GO
ALTER TABLE [dbo].[FactorCodeOverrides]  WITH CHECK ADD  CONSTRAINT [FK_FactorCodeOverridesNew_AssessmentsBPP] FOREIGN KEY([ClientId], [LocationId], [AssessmentId], [TaxYear])
REFERENCES [dbo].[AssessmentsBPP] ([ClientId], [LocationId], [AssessmentId], [TaxYear])
GO
ALTER TABLE [dbo].[FactorCodeOverrides] CHECK CONSTRAINT [FK_FactorCodeOverridesNew_AssessmentsBPP]
GO
ALTER TABLE [dbo].[FactorCodeOverrides]  WITH CHECK ADD  CONSTRAINT [FK_FactorCodeOverridesNew_FactorCodeOverrides] FOREIGN KEY([FactorEntityId], [FactorCode], [TaxYear])
REFERENCES [dbo].[FactorEntityCodes] ([FactorEntityId], [FactorCode], [TaxYear])
GO
ALTER TABLE [dbo].[FactorCodeOverrides] CHECK CONSTRAINT [FK_FactorCodeOverridesNew_FactorCodeOverrides]
GO
ALTER TABLE [dbo].[FactorEntities]  WITH CHECK ADD  CONSTRAINT [FK_FactorEntities_States] FOREIGN KEY([StateCd])
REFERENCES [dbo].[States] ([StateCd])
GO
ALTER TABLE [dbo].[FactorEntities] CHECK CONSTRAINT [FK_FactorEntities_States]
GO
ALTER TABLE [dbo].[FactorEntityCodes]  WITH CHECK ADD  CONSTRAINT [FK_FactorEntityCodes_FactorEntities] FOREIGN KEY([FactorEntityId])
REFERENCES [dbo].[FactorEntities] ([FactorEntityId])
GO
ALTER TABLE [dbo].[FactorEntityCodes] CHECK CONSTRAINT [FK_FactorEntityCodes_FactorEntities]
GO
ALTER TABLE [dbo].[Factors]  WITH CHECK ADD  CONSTRAINT [FK_Factors_FactorEntityCodes] FOREIGN KEY([FactorEntityId], [FactorCode], [TaxYear])
REFERENCES [dbo].[FactorEntityCodes] ([FactorEntityId], [FactorCode], [TaxYear])
GO
ALTER TABLE [dbo].[Factors] CHECK CONSTRAINT [FK_Factors_FactorEntityCodes]
GO
ALTER TABLE [dbo].[FieldDataDefinition]  WITH CHECK ADD  CONSTRAINT [FK_FieldDataDefinition_FieldDefinition] FOREIGN KEY([TableName], [FieldName])
REFERENCES [dbo].[FieldDefinition] ([TableName], [FieldName])
GO
ALTER TABLE [dbo].[FieldDataDefinition] CHECK CONSTRAINT [FK_FieldDataDefinition_FieldDefinition]
GO
ALTER TABLE [dbo].[FieldDefinition]  WITH CHECK ADD  CONSTRAINT [FK_FieldDefinition_TableDefinition] FOREIGN KEY([TableName])
REFERENCES [dbo].[TableDefinition] ([TableName])
GO
ALTER TABLE [dbo].[FieldDefinition] CHECK CONSTRAINT [FK_FieldDefinition_TableDefinition]
GO
ALTER TABLE [dbo].[InstallmentsBPP]  WITH CHECK ADD  CONSTRAINT [FK_InstallmentsBPP_AssessmentsBPP] FOREIGN KEY([ClientId], [LocationId], [AssessmentId], [TaxYear])
REFERENCES [dbo].[AssessmentsBPP] ([ClientId], [LocationId], [AssessmentId], [TaxYear])
GO
ALTER TABLE [dbo].[InstallmentsBPP] CHECK CONSTRAINT [FK_InstallmentsBPP_AssessmentsBPP]
GO
ALTER TABLE [dbo].[InstallmentsRE]  WITH CHECK ADD  CONSTRAINT [FK_InstallmentsRE_AssessmentsRE] FOREIGN KEY([ClientId], [LocationId], [AssessmentId], [TaxYear])
REFERENCES [dbo].[AssessmentsRE] ([ClientId], [LocationId], [AssessmentId], [TaxYear])
GO
ALTER TABLE [dbo].[InstallmentsRE] CHECK CONSTRAINT [FK_InstallmentsRE_AssessmentsRE]
GO
ALTER TABLE [dbo].[Jurisdictions]  WITH NOCHECK ADD  CONSTRAINT [FK_Jurisdiction_State] FOREIGN KEY([StateCd])
REFERENCES [dbo].[States] ([StateCd])
GO
ALTER TABLE [dbo].[Jurisdictions] CHECK CONSTRAINT [FK_Jurisdiction_State]
GO
ALTER TABLE [dbo].[Jurisdictions]  WITH CHECK ADD  CONSTRAINT [FK_Jurisdictions_Collectors] FOREIGN KEY([CollectorId], [TaxYear])
REFERENCES [dbo].[Collectors] ([CollectorId], [TaxYear])
GO
ALTER TABLE [dbo].[Jurisdictions] CHECK CONSTRAINT [FK_Jurisdictions_Collectors]
GO
ALTER TABLE [dbo].[LocationsBPP]  WITH CHECK ADD  CONSTRAINT [FK_LocationsBPP_Clients] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Clients] ([ClientId])
GO
ALTER TABLE [dbo].[LocationsBPP] CHECK CONSTRAINT [FK_LocationsBPP_Clients]
GO
ALTER TABLE [dbo].[LocationsBPP]  WITH CHECK ADD  CONSTRAINT [FK_LocationsBPP_States] FOREIGN KEY([StateCd])
REFERENCES [dbo].[States] ([StateCd])
GO
ALTER TABLE [dbo].[LocationsBPP] CHECK CONSTRAINT [FK_LocationsBPP_States]
GO
ALTER TABLE [dbo].[LocationsRE]  WITH NOCHECK ADD  CONSTRAINT [FK_Location_State] FOREIGN KEY([StateCd])
REFERENCES [dbo].[States] ([StateCd])
GO
ALTER TABLE [dbo].[LocationsRE] CHECK CONSTRAINT [FK_Location_State]
GO
ALTER TABLE [dbo].[LocationsRE]  WITH CHECK ADD  CONSTRAINT [FK_LocationsRE_Clients] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Clients] ([ClientId])
GO
ALTER TABLE [dbo].[LocationsRE] CHECK CONSTRAINT [FK_LocationsRE_Clients]
GO
ALTER TABLE [dbo].[ProspectLocations]  WITH CHECK ADD  CONSTRAINT [FK_ProspectLocations_Clients] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Clients] ([ClientId])
GO
ALTER TABLE [dbo].[ProspectLocations] CHECK CONSTRAINT [FK_ProspectLocations_Clients]
GO
ALTER TABLE [dbo].[ProspectValues]  WITH CHECK ADD  CONSTRAINT [FK_ProspectValues_ProspectLocations] FOREIGN KEY([ClientId], [LocationId])
REFERENCES [dbo].[ProspectLocations] ([ClientId], [LocationId])
GO
ALTER TABLE [dbo].[ProspectValues] CHECK CONSTRAINT [FK_ProspectValues_ProspectLocations]
GO
ALTER TABLE [dbo].[StateForms]  WITH NOCHECK ADD  CONSTRAINT [FK_StateForm_State] FOREIGN KEY([StateCd])
REFERENCES [dbo].[States] ([StateCd])
GO
ALTER TABLE [dbo].[StateForms] CHECK CONSTRAINT [FK_StateForm_State]
GO
ALTER TABLE [dbo].[StateFormsXRef]  WITH CHECK ADD  CONSTRAINT [FK_StateFormsXRef_FieldDefinition] FOREIGN KEY([TableName], [FieldName])
REFERENCES [dbo].[FieldDefinition] ([TableName], [FieldName])
GO
ALTER TABLE [dbo].[StateFormsXRef] CHECK CONSTRAINT [FK_StateFormsXRef_FieldDefinition]
GO
ALTER TABLE [dbo].[StateFormsXRef]  WITH CHECK ADD  CONSTRAINT [FK_StateFormsXRef_StateForms] FOREIGN KEY([FormId], [TaxYear])
REFERENCES [dbo].[StateForms] ([FormId], [TaxYear])
GO
ALTER TABLE [dbo].[StateFormsXRef] CHECK CONSTRAINT [FK_StateFormsXRef_StateForms]
GO
ALTER TABLE [dbo].[TaskEvents]  WITH CHECK ADD  CONSTRAINT [FK_Task_Events_Task_MasterList] FOREIGN KEY([TaskId])
REFERENCES [dbo].[TaskMasterList] ([TaskId])
GO
ALTER TABLE [dbo].[TaskEvents] CHECK CONSTRAINT [FK_Task_Events_Task_MasterList]
GO
ALTER TABLE [dbo].[TaskGroupDetail]  WITH CHECK ADD  CONSTRAINT [FK_Task_GroupList_Task_Group] FOREIGN KEY([GroupId])
REFERENCES [dbo].[TaskGroup] ([GroupId])
GO
ALTER TABLE [dbo].[TaskGroupDetail] CHECK CONSTRAINT [FK_Task_GroupList_Task_Group]
GO
ALTER TABLE [dbo].[TaskGroupDetail]  WITH CHECK ADD  CONSTRAINT [FK_Task_GroupList_Task_MasterList] FOREIGN KEY([TaskId])
REFERENCES [dbo].[TaskMasterList] ([TaskId])
GO
ALTER TABLE [dbo].[TaskGroupDetail] CHECK CONSTRAINT [FK_Task_GroupList_Task_MasterList]
GO
ALTER TABLE [dbo].[TaxBillsBPP]  WITH CHECK ADD  CONSTRAINT [FK_TaxBillsBPP_AssessmentsBPP] FOREIGN KEY([ClientId], [LocationId], [AssessmentId], [TaxYear])
REFERENCES [dbo].[AssessmentsBPP] ([ClientId], [LocationId], [AssessmentId], [TaxYear])
GO
ALTER TABLE [dbo].[TaxBillsBPP] CHECK CONSTRAINT [FK_TaxBillsBPP_AssessmentsBPP]
GO
ALTER TABLE [dbo].[TaxBillsRE]  WITH CHECK ADD  CONSTRAINT [FK_TaxBillsRE_AssessmentsRE] FOREIGN KEY([ClientId], [LocationId], [AssessmentId], [TaxYear])
REFERENCES [dbo].[AssessmentsRE] ([ClientId], [LocationId], [AssessmentId], [TaxYear])
GO
ALTER TABLE [dbo].[TaxBillsRE] CHECK CONSTRAINT [FK_TaxBillsRE_AssessmentsRE]
GO
ALTER TABLE [dbo].[UserQueryDetail]  WITH CHECK ADD  CONSTRAINT [FK_UserQueryDetail_UserQuery] FOREIGN KEY([QueryId])
REFERENCES [dbo].[UserQuery] ([QueryId])
GO
ALTER TABLE [dbo].[UserQueryDetail] CHECK CONSTRAINT [FK_UserQueryDetail_UserQuery]
GO
ALTER TABLE [dbo].[UserQuerySelect]  WITH CHECK ADD  CONSTRAINT [FK_UserQuerySelect_UserQuery] FOREIGN KEY([QueryId])
REFERENCES [dbo].[UserQuery] ([QueryId])
GO
ALTER TABLE [dbo].[UserQuerySelect] CHECK CONSTRAINT [FK_UserQuerySelect_UserQuery]
GO
ALTER TABLE [dbo].[Assessors]  WITH NOCHECK ADD  CONSTRAINT [CK_Assessor] CHECK  (([AssessorId] > 0))
GO
ALTER TABLE [dbo].[Assessors] CHECK CONSTRAINT [CK_Assessor]
GO
ALTER TABLE [dbo].[Assessors]  WITH CHECK ADD  CONSTRAINT [CK_Assessors] CHECK  (([TaxYear] > 0))
GO
ALTER TABLE [dbo].[Assessors] CHECK CONSTRAINT [CK_Assessors]
GO
ALTER TABLE [dbo].[Assets]  WITH NOCHECK ADD  CONSTRAINT [CK_Asset] CHECK  (([TaxYear]>(0)))
GO
ALTER TABLE [dbo].[Assets] CHECK CONSTRAINT [CK_Asset]
GO
ALTER TABLE [dbo].[Assets]  WITH NOCHECK ADD  CONSTRAINT [CK_Asset_1] CHECK  (([AssetId]<>''))
GO
ALTER TABLE [dbo].[Assets] CHECK CONSTRAINT [CK_Asset_1]
GO
ALTER TABLE [dbo].[Assets]  WITH CHECK ADD  CONSTRAINT [CK_Assets] CHECK  (([AllocationPct]>(0) AND [AllocationPct]<=(1)))
GO
ALTER TABLE [dbo].[Assets] CHECK CONSTRAINT [CK_Assets]
GO
ALTER TABLE [dbo].[ClientForms]  WITH NOCHECK ADD  CONSTRAINT [CK_ClientForms] CHECK  (([FormId]>(0)))
GO
ALTER TABLE [dbo].[ClientForms] CHECK CONSTRAINT [CK_ClientForms]
GO
ALTER TABLE [dbo].[Clients]  WITH NOCHECK ADD  CONSTRAINT [CK_Client] CHECK  (([ClientId] > 0))
GO
ALTER TABLE [dbo].[Clients] CHECK CONSTRAINT [CK_Client]
GO
ALTER TABLE [dbo].[Collectors]  WITH NOCHECK ADD  CONSTRAINT [CK_Collector] CHECK  (([CollectorId] > 0))
GO
ALTER TABLE [dbo].[Collectors] CHECK CONSTRAINT [CK_Collector]
GO
ALTER TABLE [dbo].[Jurisdictions]  WITH NOCHECK ADD  CONSTRAINT [CK_Jurisdiction] CHECK  (([JurisdictionId] > 0))
GO
ALTER TABLE [dbo].[Jurisdictions] CHECK CONSTRAINT [CK_Jurisdiction]
GO
ALTER TABLE [dbo].[LocationsRE]  WITH NOCHECK ADD  CONSTRAINT [CK_Location] CHECK  (([LocationId]>(0)))
GO
ALTER TABLE [dbo].[LocationsRE] CHECK CONSTRAINT [CK_Location]
GO
ALTER TABLE [dbo].[ProspectLocations]  WITH CHECK ADD  CONSTRAINT [CK_ProspectLocations] CHECK  (([PropType]='P' OR [PropType]='R'))
GO
ALTER TABLE [dbo].[ProspectLocations] CHECK CONSTRAINT [CK_ProspectLocations]
GO
ALTER TABLE [dbo].[StateForms]  WITH NOCHECK ADD  CONSTRAINT [CK_StateForm] CHECK  (([FormId] > 0))
GO
ALTER TABLE [dbo].[StateForms] CHECK CONSTRAINT [CK_StateForm]
GO
ALTER TABLE [dbo].[TaskGroup]  WITH CHECK ADD  CONSTRAINT [CK_Task_Group] CHECK  (([Entity] <> '' and [EntityId] <> ''))
GO
ALTER TABLE [dbo].[TaskGroup] CHECK CONSTRAINT [CK_Task_Group]
GO
ALTER TABLE [dbo].[TaxReturnGroupJunction]  WITH CHECK ADD  CONSTRAINT [CK_TaxReturnGroupJunction] CHECK  (([DeprCodeId] > 0))
GO
ALTER TABLE [dbo].[TaxReturnGroupJunction] CHECK CONSTRAINT [CK_TaxReturnGroupJunction]
GO
ALTER TABLE [dbo].[TaxReturnGroupJunction]  WITH CHECK ADD  CONSTRAINT [CK_TaxReturnGroupJunction_1] CHECK  (([GroupId] > 0))
GO
ALTER TABLE [dbo].[TaxReturnGroupJunction] CHECK CONSTRAINT [CK_TaxReturnGroupJunction_1]
GO
ALTER TABLE [dbo].[TaxReturnGroups]  WITH CHECK ADD  CONSTRAINT [CK_TaxReturnGroup] CHECK  (([GroupId] > 0))
GO
ALTER TABLE [dbo].[TaxReturnGroups] CHECK CONSTRAINT [CK_TaxReturnGroup]
GO
ALTER TABLE [dbo].[UserQuery]  WITH CHECK ADD  CONSTRAINT [CK_UserQuery] CHECK  (([QueryId]>(0)))
GO
ALTER TABLE [dbo].[UserQuery] CHECK CONSTRAINT [CK_UserQuery]
GO
