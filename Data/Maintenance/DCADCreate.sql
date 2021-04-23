remember to add dcad to vantageapp user in server security (not dcad database)

USE [DCAD]
GO
/****** Object:  Table [dbo].[abatement_exempt]    Script Date: 10/28/2020 5:11:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[abatement_exempt](
	[ACCOUNT_NUM] [nvarchar](50) NULL,
	[APPRAISAL_YR] [int] NULL,
	[TOT_VAL] [float] NULL,
	[CITY_EFF_YR] [nvarchar](50) NULL,
	[CITY_EXP_YR] [nvarchar](50) NULL,
	[CITY_EXEMPTION_PCT] [float] NULL,
	[CITY_BASE_VAL] [float] NULL,
	[CITY_VAL_DIF] [float] NULL,
	[CITY_EXEMPTION_AMT] [float] NULL,
	[CNTY_EFF_YR] [nvarchar](50) NULL,
	[CNTY_EXP_YR] [nvarchar](50) NULL,
	[CNTY_EXEMPTION_PCT] [float] NULL,
	[CNTY_BASE_VAL] [float] NULL,
	[CNTY_VAL_DIF] [float] NULL,
	[CNTY_EXEMPTION_AMT] [float] NULL,
	[ISD_EFF_YR] [nvarchar](50) NULL,
	[ISD_EXP_YR] [nvarchar](50) NULL,
	[ISD_EXEMPTION_PCT] [float] NULL,
	[ISD_BASE_VAL] [float] NULL,
	[ISD_VAL_DIF] [float] NULL,
	[ISD_EXEMPTION_AMT] [float] NULL,
	[COLL_EFF_YR] [nvarchar](50) NULL,
	[COLL_EXP_YR] [nvarchar](50) NULL,
	[COLL_EXEMPTION_PCT] [float] NULL,
	[COLL_BASE_VAL] [float] NULL,
	[COLL_VAL_DIF] [float] NULL,
	[COLL_EXEMPTION_AMT] [float] NULL,
	[SPEC_EFF_YR] [nvarchar](50) NULL,
	[SPEC_EXP_YR] [nvarchar](50) NULL,
	[SPEC_EXEMPTION_PCT] [float] NULL,
	[SPEC_BASE_VAL] [float] NULL,
	[SPEC_VAL_DIF] [float] NULL,
	[SPEC_EXEMPTION_AMT] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[account_apprl_year]    Script Date: 10/28/2020 5:11:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[account_apprl_year](
	[ACCOUNT_NUM] [nvarchar](50) NULL,
	[APPRAISAL_YR] [int] NULL,
	[IMPR_VAL] [float] NULL,
	[LAND_VAL] [float] NULL,
	[LAND_AG_EXEMPT] [nvarchar](50) NULL,
	[AG_USE_VAL] [nvarchar](50) NULL,
	[TOT_VAL] [float] NULL,
	[HMSTD_CAP_VAL] [float] NULL,
	[REVAL_YR] [int] NULL,
	[PREV_REVAL_YR] [int] NULL,
	[PREV_MKT_VAL] [float] NULL,
	[TOT_CONTRIB_AMT] [float] NULL,
	[TAXPAYER_REP] [nvarchar](50) NULL,
	[CITY_JURIS_DESC] [nvarchar](50) NULL,
	[COUNTY_JURIS_DESC] [nvarchar](50) NULL,
	[ISD_JURIS_DESC] [nvarchar](50) NULL,
	[HOSPITAL_JURIS_DESC] [nvarchar](50) NULL,
	[COLLEGE_JURIS_DESC] [nvarchar](50) NULL,
	[SPECIAL_DIST_JURIS_DESC] [nvarchar](50) NULL,
	[CITY_SPLIT_PCT] [float] NULL,
	[COUNTY_SPLIT_PCT] [float] NULL,
	[ISD_SPLIT_PCT] [float] NULL,
	[HOSPITAL_SPLIT_PCT] [float] NULL,
	[COLLEGE_SPLIT_PCT] [float] NULL,
	[SPECIAL_DIST_SPLIT_PCT] [float] NULL,
	[CITY_TAXABLE_VAL] [nvarchar](50) NULL,
	[COUNTY_TAXABLE_VAL] [nvarchar](50) NULL,
	[ISD_TAXABLE_VAL] [nvarchar](50) NULL,
	[HOSPITAL_TAXABLE_VAL] [nvarchar](50) NULL,
	[COLLEGE_TAXABLE_VAL] [nvarchar](50) NULL,
	[SPECIAL_DIST_TAXABLE_VAL] [nvarchar](50) NULL,
	[CITY_CEILING_VALUE] [nvarchar](50) NULL,
	[COUNTY_CEILING_VALUE] [nvarchar](50) NULL,
	[ISD_CEILING_VALUE] [nvarchar](50) NULL,
	[HOSPITAL_CEILING_VALUE] [nvarchar](1) NULL,
	[COLLEGE_CEILING_VALUE] [nvarchar](50) NULL,
	[SPECIAL_DIST_CEILING_VALUE] [nvarchar](1) NULL,
	[VID_IND] [nvarchar](50) NULL,
	[GIS_PARCEL_ID] [nvarchar](50) NULL,
	[APPRAISAL_METH_CD] [nvarchar](50) NULL,
	[RENDITION_PENALTY] [nvarchar](50) NULL,
	[DIVISION_CD] [nvarchar](50) NULL,
	[EXTRNL_CNTY_ACCT] [nvarchar](50) NULL,
	[EXTRNL_CITY_ACCT] [nvarchar](50) NULL,
	[P_BUS_TYP_CD] [nvarchar](50) NULL,
	[BLDG_CLASS_CD] [nvarchar](50) NULL,
	[SPTD_CODE] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[account_info]    Script Date: 10/28/2020 5:11:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[account_info](
	[ACCOUNT_NUM] [nvarchar](50) NULL,
	[APPRAISAL_YR] [int] NULL,
	[DIVISION_CD] [nvarchar](50) NULL,
	[BIZ_NAME] [nvarchar](250) NULL,
	[OWNER_NAME1] [nvarchar](250) NULL,
	[OWNER_NAME2] [nvarchar](250) NULL,
	[EXCLUDE_OWNER] [nvarchar](50) NULL,
	[OWNER_ADDRESS_LINE1] [nvarchar](250) NULL,
	[OWNER_ADDRESS_LINE2] [nvarchar](250) NULL,
	[OWNER_ADDRESS_LINE3] [nvarchar](250) NULL,
	[OWNER_ADDRESS_LINE4] [nvarchar](250) NULL,
	[OWNER_CITY] [nvarchar](250) NULL,
	[OWNER_STATE] [nvarchar](50) NULL,
	[OWNER_ZIPCODE] [nvarchar](50) NULL,
	[OWNER_COUNTRY] [nvarchar](250) NULL,
	[STREET_NUM] [nvarchar](50) NULL,
	[STREET_HALF_NUM] [nvarchar](50) NULL,
	[FULL_STREET_NAME] [nvarchar](250) NULL,
	[BLDG_ID] [nvarchar](50) NULL,
	[UNIT_ID] [nvarchar](50) NULL,
	[PROPERTY_CITY] [nvarchar](250) NULL,
	[PROPERTY_ZIPCODE] [nvarchar](50) NULL,
	[MAPSCO] [nvarchar](50) NULL,
	[NBHD_CD] [nvarchar](50) NULL,
	[LEGAL1] [nvarchar](250) NULL,
	[LEGAL2] [nvarchar](250) NULL,
	[LEGAL3] [nvarchar](250) NULL,
	[LEGAL4] [nvarchar](250) NULL,
	[LEGAL5] [nvarchar](250) NULL,
	[DEED_TXFR_DATE] [datetime2](7) NULL,
	[GIS_PARCEL_ID] [nvarchar](50) NULL,
	[PHONE_NUM] [nvarchar](50) NULL,
	[LMA] [nvarchar](50) NULL,
	[IMA] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[acct_exempt_value]    Script Date: 10/28/2020 5:11:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[acct_exempt_value](
	[ACCOUNT_NUM] [nvarchar](50) NULL,
	[APPRAISAL_YR] [int] NULL,
	[SORTORDER] [nvarchar](50) NULL,
	[EXEMPTION_CD] [nvarchar](50) NULL,
	[EXEMPTION] [nvarchar](50) NULL,
	[CITY_APPLD_VAL] [float] NULL,
	[CNTY_APPLD_VAL] [float] NULL,
	[ISD_APPLD_VAL] [float] NULL,
	[HOSPITAL_APPLD_VAL] [float] NULL,
	[COLLEGE_APPLD_VAL] [float] NULL,
	[SPCL_APPLIED_VAL] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[com_detail]    Script Date: 10/28/2020 5:11:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[com_detail](
	[TAX_OBJ_ID] [nvarchar](50) NULL,
	[ACCOUNT_NUM] [nvarchar](50) NULL,
	[APPRAISAL_YR] [int] NULL,
	[BLDG_CLASS_DESC] [nvarchar](50) NULL,
	[YEAR_BUILT] [int] NULL,
	[REMODEL_YR] [nvarchar](50) NULL,
	[GROSS_BLDG_AREA] [int] NULL,
	[FOUNDATION_TYP_DESC] [nvarchar](50) NULL,
	[FOUNDATION_AREA] [nvarchar](50) NULL,
	[BASEMENT_DESC] [nvarchar](50) NULL,
	[BASEMENT_AREA] [nvarchar](50) NULL,
	[NUM_STORIES] [nvarchar](50) NULL,
	[CONSTR_TYP_DESC] [nvarchar](50) NULL,
	[HEATING_TYP_DESC] [nvarchar](50) NULL,
	[AC_TYP_DESC] [nvarchar](50) NULL,
	[NUM_UNITS] [nvarchar](50) NULL,
	[NET_LEASE_AREA] [nvarchar](50) NULL,
	[PROPERTY_NAME] [nvarchar](100) NULL,
	[PROPERTY_QUAL_DESC] [nvarchar](50) NULL,
	[PROPERTY_COND_DESC] [nvarchar](50) NULL,
	[PHYS_DEPR_PCT] [float] NULL,
	[FUNCT_DEPR_PCT] [float] NULL,
	[EXTRNL_DEPR_PCT] [float] NULL,
	[TOT_DEPR_PCT] [float] NULL,
	[IMP_VAL] [nvarchar](1) NULL,
	[LAND_VAL] [nvarchar](1) NULL,
	[MKT_VAL] [nvarchar](1) NULL,
	[APPR_METHOD_DESC] [nvarchar](50) NULL,
	[COMPARABILITY_CD] [nvarchar](50) NULL,
	[PCT_COMPLETE] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[land]    Script Date: 10/28/2020 5:11:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[land](
	[ACCOUNT_NUM] [nvarchar](50) NULL,
	[APPRAISAL_YR] [int] NULL,
	[SECTION_NUM] [nvarchar](50) NULL,
	[SPTD_CD] [nvarchar](50) NULL,
	[SPTD_DESC] [nvarchar](50) NULL,
	[ZONING] [nvarchar](50) NULL,
	[FRONT_DIM] [nvarchar](50) NULL,
	[DEPTH_DIM] [nvarchar](50) NULL,
	[AREA_SIZE] [float] NULL,
	[AREA_UOM_DESC] [nvarchar](50) NULL,
	[PRICING_METH_DESC] [nvarchar](50) NULL,
	[COST_PER_UOM] [float] NULL,
	[MARKET_ADJ_PCT] [float] NULL,
	[VAL_AMT] [float] NULL,
	[AG_USE_IND] [nvarchar](50) NULL,
	[ACCT_AG_VAL_AMT] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[spUpdateREComps]    Script Date: 10/28/2020 5:11:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateREComps]
	@AssessorId bigint,
	@TaxYear smallint,
	@Threshhold bigint,
	@AddUser varchar(30)
	 
AS
	BEGIN
		DELETE AssessmentManagerData..REComps WHERE AssessorId = @AssessorId AND TaxYear = @TaxYear

		INSERT INTO AssessmentManagerData..REComps
           ([AssessorId]
           ,[AcctNum]
           ,[TaxYear]
           ,[ImprovementValue]
           ,[LandValue]
           ,[BuildingSqFt]
           ,[LandSqFt]
           ,[NumberOfUnits]
           ,[YearBuilt]
           ,[BuildingClass]
           ,[ComparabilityCode]
           ,[EconomicArea]
           ,[LandMarketArea]
           ,[ImprovementMarketArea]
           ,[Mapsco]
           ,[NeighborhoodGroup]
           ,[StreetName]
           ,[BusinessName]
           ,[TotalValue]
           ,[LandValuePerSqFt]
           ,[ImprovementValuePerSqFt]
           ,[TotalValuePerSqFt]
           ,[TotalValuePerUnit]
           ,[LandBuildingRatio]           
           ,[ConstructionType]
           ,[EffectiveYear]
           ,[AppraisalMethod]
           ,[PricingMethod]
		   ,[AddUser])		   
		
		--UPDATE MERGEQUERY AS WELL FOR CHANGES TO THIS SELECT
		SELECT @AssessorId AS AssessorId, tmp1.Account_Num, @TaxYear AS TaxYear, ISNULL(tmp1.IMPR_VAL,0), ISNULL(tmp1.LAND_VAL,0), 
		--ISNULL(tmp1.GROSS_BLDG_AREA,0), 
		ISNULL(tmp1.NET_LEASE_AREA,0), 
		ISNULL(tmp1.AREA_SIZE,0),
		ISNULL(tmp1.NUM_UNITS,0), ISNULL(tmp1.YEAR_BUILT,0), ISNULL(tmp1.BLDG_CLASS_DESC,''), 
		ISNULL(tmp1.COMPARABILITY_CD,''), '' AS EconomicArea, ISNULL(tmp1.LMA,''), ISNULL(tmp1.IMA,''), ISNULL(tmp1.MAPSCO,''),
		ISNULL(tmp1.NBHD_CD,''), ISNULL(tmp1.STREET_NUM,'') + ISNULL(tmp1.STREET_HALF_NUM,'') + ' ' + ISNULL(tmp1.FULL_STREET_NAME,'') AS StreetName, 
		--ISNULL(tmp1.BIZ_NAME,'') BIZ_NAME,
		ISNULL(tmp1.OWNER_NAME1,''),
		ISNULL(tmp1.TOT_VAL,0), 
		CASE WHEN ISNULL(tmp1.AREA_SIZE,0) > 0 THEN ROUND(ISNULL(tmp1.LAND_VAL,0) / ISNULL(tmp1.AREA_SIZE,0),2) ELSE 0 END AS LandValuePerSqFt,
		--CASE WHEN ISNULL(tmp1.GROSS_BLDG_AREA,0) > 0 THEN ROUND(ISNULL(tmp1.IMPR_VAL,0) / ISNULL(tmp1.GROSS_BLDG_AREA,0),2) ELSE 0 END AS ImprovementValuePerSqFt,
		CASE WHEN ISNULL(tmp1.NET_LEASE_AREA,0) > 0 THEN ROUND(ISNULL(tmp1.IMPR_VAL,0) / ISNULL(tmp1.NET_LEASE_AREA,0),2) ELSE 0 END AS ImprovementValuePerSqFt,
		--CASE WHEN ISNULL(tmp1.GROSS_BLDG_AREA,0) > 0 THEN ROUND(ISNULL(tmp1.TOT_VAL,0) / ISNULL(tmp1.GROSS_BLDG_AREA,0),2) ELSE 0 END AS TotalValuePerSqFt,
		CASE WHEN ISNULL(tmp1.NET_LEASE_AREA,0) > 0 THEN ROUND(ISNULL(tmp1.TOT_VAL,0) / ISNULL(tmp1.NET_LEASE_AREA,0),2) ELSE 0 END AS TotalValuePerSqFt,
		CASE WHEN ISNULL(tmp1.NUM_UNITS,0) > 0 THEN ISNULL(tmp1.TOT_VAL,0) / ISNULL(tmp1.NUM_UNITS,0) ELSE 0 END AS TotalValuePerUnit,
		--CASE WHEN ISNULL(tmp1.AREA_SIZE,0) > 0 THEN ISNULL(tmp1.GROSS_BLDG_AREA,0) / ISNULL(tmp1.AREA_SIZE,0) ELSE 0 END AS LandBuildingRatio,
		CASE WHEN ISNULL(tmp1.AREA_SIZE,0) > 0 THEN ISNULL(tmp1.NET_LEASE_AREA,0) / ISNULL(tmp1.AREA_SIZE,0) ELSE 0 END AS LandBuildingRatio,
		ISNULL(tmp1.CONSTR_TYP_DESC,''), ISNULL(tmp1.CITY_EFF_YR,0), ISNULL(tmp1.APPR_METHOD_DESC,''), ISNULL(tmp1.PRICING_METH_DESC,''), @AddUser AS AddUser

		FROM (
		SELECT account_apprl_year.ACCOUNT_NUM, MAX(account_apprl_year.IMPR_VAL) AS IMPR_VAL, MAX(account_apprl_year.LAND_VAL) AS LAND_VAL, 
		MAX(account_apprl_year.LAND_AG_EXEMPT) AS LAND_AG_EXEMPT, 
		MAX(account_apprl_year.AG_USE_VAL) AS AG_USE_VAL, MAX(CONVERT(bigint,account_apprl_year.TOT_VAL)) AS TOT_VAL, 
		MAX(account_apprl_year.PREV_MKT_VAL) AS PREV_MKT_VAL, 
		MAX(account_apprl_year.TOT_CONTRIB_AMT) AS TOT_CONTRIB_AMT, 
		MAX(account_apprl_year.TAXPAYER_REP) AS TAXPAYER_REP, MAX(account_apprl_year.CITY_TAXABLE_VAL) AS CITY_TAXABLE_VAL, 
		MAX(account_apprl_year.COUNTY_TAXABLE_VAL) AS COUNTY_TAXABLE_VAL, 
		MAX(account_apprl_year.ISD_TAXABLE_VAL) AS ISD_TAXABLE_VAL, MAX(account_apprl_year.VID_IND) AS VID_IND, MAX(account_info.DIVISION_CD) AS DIVISION_CD, 
		MAX(account_info.BIZ_NAME) AS BIZ_NAME, 
		MAX(account_info.OWNER_NAME1) AS OWNER_NAME1, MAX(account_info.OWNER_NAME2) AS OWNER_NAME2, MAX(account_info.EXCLUDE_OWNER) AS EXCLUDE_OWNER, 
		MAX(account_info.OWNER_ADDRESS_LINE1) AS OWNER_ADDRESS_LINE1, 
		MAX(account_info.OWNER_ADDRESS_LINE2) AS OWNER_ADDRESS_LINE2, MAX(account_info.OWNER_ADDRESS_LINE3) AS OWNER_ADDRESS_LINE3, MAX(account_info.OWNER_ADDRESS_LINE4) AS OWNER_ADDRESS_LINE4, 
		MAX(account_info.OWNER_CITY) AS OWNER_CITY, 
		MAX(account_info.OWNER_STATE) AS OWNER_STATE, MAX(account_info.OWNER_ZIPCODE) AS OWNER_ZIPCODE, MAX(account_info.OWNER_COUNTRY) AS OWNER_COUNTRY, 
		MAX(account_info.STREET_NUM) AS STREET_NUM, 
		MAX(account_info.STREET_HALF_NUM) AS STREET_HALF_NUM, MAX(account_info.FULL_STREET_NAME) AS FULL_STREET_NAME, MAX(account_info.BLDG_ID) AS BLDG_ID, 
		MAX(account_info.UNIT_ID) AS UNIT_ID, 
		MAX(account_info.MAPSCO) AS MAPSCO, MAX(account_info.NBHD_CD) AS NBHD_CD, MAX(account_info.LEGAL1) AS LEGAL1, MAX(account_info.LEGAL2) AS LEGAL2, 
		MAX(account_info.LEGAL3) AS LEGAL3, 
		MAX(account_info.LEGAL4) AS LEGAL4, MAX(account_info.LEGAL5) AS LEGAL5, MAX(account_info.DEED_TXFR_DATE) AS DEED_TXFR_DATE, 
		MAX(account_info.GIS_PARCEL_ID) AS GIS_PARCEL_ID, 
		MAX(account_info.PHONE_NUM) AS PHONE_NUM, MAX(account_info.LMA) AS LMA, MAX(account_info.IMA) AS IMA, 
		MAX(com_detail.TAX_OBJ_ID) AS TAX_OBJ_ID,
		MAX(com_detail.BLDG_CLASS_DESC) AS BLDG_CLASS_DESC, MAX(com_detail.YEAR_BUILT) AS YEAR_BUILT, MAX(com_detail.GROSS_BLDG_AREA) AS GROSS_BLDG_AREA, 
		MAX(com_detail.FOUNDATION_TYP_DESC) AS FOUNDATION_TYP_DESC, 
		MAX(com_detail.FOUNDATION_AREA) AS FOUNDATION_AREA, MAX(com_detail.BASEMENT_DESC) AS BASEMENT_DESC, MAX(com_detail.BASEMENT_AREA) AS BASEMENT_AREA, 
		MAX(com_detail.NUM_STORIES) AS NUM_STORIES, 
		MAX(com_detail.CONSTR_TYP_DESC) AS CONSTR_TYP_DESC, MAX(com_detail.HEATING_TYP_DESC) AS HEATING_TYP_DESC, MAX(com_detail.AC_TYP_DESC) AS AC_TYP_DESC, 
		MAX(com_detail.NUM_UNITS) AS NUM_UNITS, 
		MAX(CONVERT(bigint,com_detail.NET_LEASE_AREA)) AS NET_LEASE_AREA, MAX(com_detail.PROPERTY_NAME) AS PROPERTY_NAME, MAX(com_detail.PROPERTY_QUAL_DESC) AS PROPERTY_QUAL_DESC,
		MAX(com_detail.PROPERTY_COND_DESC) AS PROPERTY_COND_DESC, 
		MAX(com_detail.PHYS_DEPR_PCT) AS PHYS_DEPR_PCT, MAX(com_detail.FUNCT_DEPR_PCT) AS FUNCT_DEPR_PCT, MAX(com_detail.EXTRNL_DEPR_PCT) AS EXTRNL_DEPR_PCT, 
		MAX(com_detail.TOT_DEPR_PCT) AS TOT_DEPR_PCT, 
		MAX(com_detail.IMP_VAL) AS IMP_VAL, MAX(com_detail.MKT_VAL) AS MKT_VAL, MAX(com_detail.APPR_METHOD_DESC) AS APPR_METHOD_DESC, 
		MAX(com_detail.COMPARABILITY_CD) AS COMPARABILITY_CD, MAX(com_detail.REMODEL_YR) AS REMODEL_YR, MAX(land.APPRAISAL_YR) AS APPRAISAL_YR, 
		MAX(land.SECTION_NUM) AS SECTION_NUM, MAX(land.SPTD_CD) AS SPTD_CD, 
		MAX(land.SPTD_DESC) AS SPTD_DESC, MAX(land.ZONING) AS ZONING, MAX(land.FRONT_DIM) AS FRONT_DIM, MAX(land.DEPTH_DIM) AS DEPTH_DIM, 
		MAX(land.AREA_SIZE) AS AREA_SIZE, MAX(land.AREA_UOM_DESC) AS AREA_UOM_DESC, MAX(land.PRICING_METH_DESC) AS PRICING_METH_DESC, 
		MAX(land.COST_PER_UOM) AS COST_PER_UOM, MAX(land.MARKET_ADJ_PCT) AS MARKET_ADJ_PCT, 
		MAX(land.VAL_AMT) AS VAL_AMT, MAX(land.AG_USE_IND) AS AG_USE_IND, MAX(land.ACCT_AG_VAL_AMT) AS ACCT_AG_VAL_AMT, 
		MAX(acct_exempt_value.EXEMPTION_CD) AS EXEMPTION_CD, MAX(acct_exempt_value.EXEMPTION) AS EXEMPTION,
		MAX(acct_exempt_value.CITY_APPLD_VAL) AS CITY_APPLD_VAL, MAX(abatement_exempt.CITY_EFF_YR) AS CITY_EFF_YR, MAX(abatement_exempt.CITY_EXP_YR) AS CITY_EXP_YR,
		MAX(abatement_exempt.CITY_BASE_VAL) AS CITY_BASE_VAL, MAX(abatement_exempt.CITY_VAL_DIF) AS CITY_VAL_DIF, MAX(abatement_exempt.CITY_EXEMPTION_AMT) AS CITY_EXEMPTION_AMT
		FROM DCAD..account_apprl_year INNER JOIN
		DCAD..account_info ON account_apprl_year.ACCOUNT_NUM = account_info.ACCOUNT_NUM INNER JOIN
		DCAD..com_detail ON account_apprl_year.ACCOUNT_NUM = com_detail.ACCOUNT_NUM INNER JOIN
		DCAD..land ON account_apprl_year.ACCOUNT_NUM = land.ACCOUNT_NUM LEFT OUTER JOIN
		DCAD..abatement_exempt ON account_apprl_year.ACCOUNT_NUM = abatement_exempt.ACCOUNT_NUM LEFT OUTER JOIN
		DCAD..acct_exempt_value ON account_apprl_year.ACCOUNT_NUM = acct_exempt_value.ACCOUNT_NUM
		GROUP BY account_apprl_year.ACCOUNT_NUM
		HAVING MAX(CONVERT(bigint,account_apprl_year.TOT_VAL)) >= @Threshhold
		) as tmp1

	END

GO
