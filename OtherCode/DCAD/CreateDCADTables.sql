

-- *******************            To load DCAD for V1, go through re import county in app.  Then query assessmentmanagerdata.recomps where
--        AssessorId=1697 and TaxYear=xxxx
--		



 select * from AssessmentManagerData..recomps where  AssessorId=1697 and TaxYear=2024





drop table DCAD..abatement_exempt
drop table DCAD..account_info
drop table DCAD..account_apprl_year
drop table DCAD..acct_exempt_value
drop table DCAD..com_detail
drop table DCAD..land

USE [DCAD]
GO
/****** Object:  Table [dbo].[abatement_exempt]    Script Date: 3/5/2020 1:40:42 PM ******/
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
/****** Object:  Table [dbo].[account_apprl_year]    Script Date: 3/5/2020 1:40:42 PM ******/
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
/****** Object:  Table [dbo].[account_info]    Script Date: 3/5/2020 1:40:42 PM ******/
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
/****** Object:  Table [dbo].[acct_exempt_value]    Script Date: 3/5/2020 1:40:42 PM ******/
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
/****** Object:  Table [dbo].[com_detail]    Script Date: 3/5/2020 1:40:42 PM ******/
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
/****** Object:  Table [dbo].[land]    Script Date: 3/5/2020 1:40:42 PM ******/
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

