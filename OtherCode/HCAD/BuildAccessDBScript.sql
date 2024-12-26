﻿-- DBWScript v4.1
-- Database: C:\MyFiles\VantageOne\HCAD\Hcad.accdb
-- Builds access database

CREATE TABLE [arb_hearings_pp] (
	[ACCOUNT] NVARCHAR(7) NOT NULL,
	[TAX_YEAR] NVARCHAR(4),
	[PERSONAL] NVARCHAR(1),
	[HEARING_TYPE] NCHAR(1),
	[STATE_CLASS] NCHAR(2),
	[OWNER_NAME] NVARCHAR(100),
	[SCHEDULED_FOR_DATE] NVARCHAR(10),
	[ACTUAL_HEARING_DATE] NVARCHAR(10),
	[ARB_RELEASE_DATE] NVARCHAR(10),
	[CONCLUSION_CODE] NVARCHAR(2),
	[AGENT_CODE] NCHAR(6),
	[INITIAL_APPRAISED_VALUE] NVARCHAR(12),
	[FINAL_APPRAISED_VALUE] NVARCHAR(12)
);
GO

CREATE TABLE [arb_hearings_real] (
	[ACCOUNT] NVARCHAR(13) NOT NULL,
	[TAX_YEAR] NVARCHAR(4),
	[REAL] NVARCHAR(1),
	[HEARING_TYPE] NCHAR(1),
	[STATE_CLASS] NVARCHAR(4),
	[OWNER_NAME] NVARCHAR(100),
	[SCHEDULED_FOR_DATE] NVARCHAR(10),
	[ACTUAL_HEARING_DATE] NVARCHAR(10),
	[ARB_RELEASE_DATE] NVARCHAR(10),
	[CONCLUSION_CODE] NVARCHAR(2),
	[AGENT_CODE] NCHAR(6),
	[INITIAL_APPRAISED_VALUE] NVARCHAR(12),
	[INITIAL_MARKET_VALUE] NVARCHAR(12),
	[FINAL_APPRAISED_VALUE] NVARCHAR(12),
	[FINAL_MARKET_VALUE] NVARCHAR(12)
);
GO

CREATE TABLE [arb_protest_pp] (
	[ACCOUNT] NVARCHAR(7) NOT NULL,
	[PROTESTED_BY] NVARCHAR(6),
	[PROTESTED_DT] NVARCHAR(10)
);
GO

CREATE TABLE [arb_protest_real] (
	[ACCOUNT] NVARCHAR(13) NOT NULL,
	[PROTESTED_BY] NVARCHAR(6),
	[PROTESTED_DT] NVARCHAR(10)
);
GO

CREATE TABLE [building_other] (
	[ACCOUNT] NVARCHAR(13),
	[USE_CODE] NVARCHAR(16),
	[BLD_NUM] INTEGER NOT NULL,
	[IMPROV_TYPE] NCHAR(4),
	[BUILDING_STYLE_CODE] NCHAR(4),
	[CLASS_STRUCTURE] NCHAR(3),
	[CLASS_STRUC_DESCRIPTION] NVARCHAR(50),
	[NOTICED_DEPR_VALUE] NVARCHAR(12),
	[DEPRECIATION_VALUE] NVARCHAR(12),
	[MS_REPLACEMENT_COST] NVARCHAR(12),
	[CAMA_REPLACEMENT_COST] NVARCHAR(12),
	[ACCRUED_DEPR_PCT] NVARCHAR(8),
	[QUALITY] NCHAR(2),
	[QUALITY_DESCRIPTION] NVARCHAR(50),
	[DATE_ERECTED] NVARCHAR(4),
	[EFFECTIVE_DATE] NVARCHAR(4),
	[YR_REMODEL] NCHAR(4),
	[YR_ROLL] NCHAR(4),
	[APPRAISED_BY] NCHAR(5),
	[APPRAISED_DATE] NVARCHAR(10),
	[NOTE] NVARCHAR(150),
	[IMPR_SQ_FT] NVARCHAR(12),
	[ACTUAL_AREA] NVARCHAR(12),
	[HEAT_AREA] NVARCHAR(12),
	[GROSS_AREA] NVARCHAR(12),
	[EFFECTIVE_AREA] NVARCHAR(12),
	[BASE_AREA] NVARCHAR(12),
	[PERIMETER] NVARCHAR(12),
	[PERCENT_COMPLETE] NVARCHAR(4),
	[CATEGORY] NCHAR(2),
	[CATEGORY_DSCR] NVARCHAR(50),
	[PROPERTY_NAME] NVARCHAR(50),
	[UNITS] NVARCHAR(15),
	[NET_RENT_AREA] NVARCHAR(10),
	[LEASE_RATE] NVARCHAR(10),
	[OCCUPANCY_RATE] NVARCHAR(10),
	[TOTAL_INCOME] NVARCHAR(10)
);
GO

CREATE TABLE [building_res] (
	[ACCOUNT] NVARCHAR(13) NOT NULL,
	[USE_CODE] NVARCHAR(16),
	[BUILDING_NUMBER] INTEGER NOT NULL,
	[IMPRV_TYPE] NCHAR(4),
	[BUILDING_STYLE_CODE] NCHAR(4),
	[CLASS_STRUCTURE] NCHAR(3),
	[CLASS_STRUC_DESCRIPTION] NVARCHAR(50),
	[DEPRECIATION_VALUE] NVARCHAR(12),
	[CAMA_REPLACEMENT_COST] NVARCHAR(12),
	[ACCRUED_DEPR_PCT] NVARCHAR(9),
	[QUALITY] NCHAR(2),
	[QUALITY_DESCRIPTION] NVARCHAR(50),
	[DATE_ERECTED] NVARCHAR(4),
	[EFFECTIVE_DATE] NVARCHAR(4),
	[YR_REMODEL] NVARCHAR(4),
	[YR_ROLL] NCHAR(4),
	[APPRAISED_BY] NCHAR(5),
	[APPRAISED_DATE] NVARCHAR(10),
	[NOTE] NVARCHAR(150),
	[IMPR_SQ_FT] NVARCHAR(12),
	[ACTUAL_AREA] NVARCHAR(12),
	[HEAT_AREA] NVARCHAR(12),
	[GROSS_AREA] NVARCHAR(12),
	[EFFECTIVE_AREA] NVARCHAR(12),
	[BASE_AREA] NVARCHAR(12),
	[PERIMETER] NVARCHAR(12),
	[PERCENT_COMPLETE] NVARCHAR(4),
	[NBHD_FACTOR] NVARCHAR(6),
	[RCNLD] NVARCHAR(13),
	[SIZE_INDEX] NVARCHAR(9),
	[LUMP_SUM_ADJ] NVARCHAR(12)
);
GO

CREATE TABLE [deeds] (
	[acct] NVARCHAR(13),
	[dateOfSale] NVARCHAR(10),
	[clerk_yr] INTEGER,
	[clerk_id] NVARCHAR(20),
	[deed_id] INTEGER NOT NULL,
	CONSTRAINT [deeds$acct] PRIMARY KEY ([acct], [deed_id])
);
GO

CREATE TABLE [exterior] (
	[ACCOUNT] NVARCHAR(13) NOT NULL,
	[BUILDING_NUMBER] INTEGER NOT NULL,
	[EXTERIOR_TYPE] NCHAR(3),
	[EXTERIOR_DESCRIPTION] NVARCHAR(50),
	[AREA] NVARCHAR(12)
);
GO

CREATE TABLE [extra_features] (
	[ACCOUNT] NVARCHAR(13) NOT NULL,
	[BLD_NUM] INTEGER,
	[COUNT] INTEGER,
	[GRADE] NCHAR(4),
	[CODE] NCHAR(6),
	[S_DSCR] NVARCHAR(10),
	[L_DESCR] NVARCHAR(50),
	[CATEGORY] NCHAR(2),
	[DSCR] NVARCHAR(50),
	[NOTE] NVARCHAR(50),
	[UTS] NVARCHAR(12)
);
GO

CREATE TABLE [extra_features_detail1] (
	[ACCOUNT] NVARCHAR(13),
	[CD] NCHAR(6),
	[DSCR] NVARCHAR(50),
	[GRADE] NCHAR(4),
	[COND_CD] NCHAR(2),
	[BLD_NUM] INTEGER,
	[LENGTH] INTEGER,
	[WIDTH] INTEGER,
	[UNITS] NVARCHAR(12),
	[UNIT_PRICE] NVARCHAR(13),
	[ADJ_UNIT_PRICE] NVARCHAR(15),
	[PCT_COMP] NVARCHAR(4),
	[ACT_YR] NVARCHAR(4),
	[EFF_YR] NVARCHAR(4),
	[ROLL_YR] NVARCHAR(4),
	[DT] NVARCHAR(6),
	[PCT_COND] NVARCHAR(4),
	[DPR_VAL] NVARCHAR(12),
	[NOTE] NVARCHAR(50),
	[ASD_VAL] NVARCHAR(12)
);
GO

CREATE TABLE [extra_features_detail2] (
	[ACCOUNT] NVARCHAR(13),
	[CD] NCHAR(6),
	[DSCR] NVARCHAR(50),
	[GRADE] NCHAR(4),
	[COND_CD] NCHAR(2),
	[BLD_NUM] INTEGER,
	[LENGTH] INTEGER,
	[WIDTH] INTEGER,
	[UNITS] NVARCHAR(12),
	[UNIT_PRICE] NVARCHAR(13),
	[ADJ_UNIT_PRICE] NVARCHAR(15),
	[PCT_COMP] NVARCHAR(4),
	[ACT_YR] INTEGER,
	[EFF_YR] INTEGER,
	[ROLL_YR] INTEGER,
	[DT] NVARCHAR(6),
	[PCT_COND] NVARCHAR(4),
	[DPR_VAL] NVARCHAR(12),
	[NOTE] NVARCHAR(50),
	[ASD_VAL] NVARCHAR(12)
);
GO

CREATE TABLE [fixtures] (
	[ACCOUNT] NVARCHAR(13) NOT NULL,
	[BUILDING_NUMBER] INTEGER NOT NULL,
	[FIXTURE_TYPE] NCHAR(4),
	[FIXTURE_DESCRIPTION] NVARCHAR(50),
	[UNITS] NVARCHAR(11)
);
GO

CREATE TABLE [jur_exempt] (
	[ACCOUNT] NVARCHAR(13) NOT NULL,
	[TAX_DISTRICT] NVARCHAR(6),
	[EXEMPT_CAT] NVARCHAR(4),
	[EXEMPT_VAL] NVARCHAR(12)
);
GO

CREATE TABLE [jur_exempt_cd] (
	[ACCOUNT] NVARCHAR(13),
	[EXEMPT_CAT] NVARCHAR(92)
);
GO

CREATE TABLE [jur_exemption_dscr] (
	[EXEMPT_CAT] NVARCHAR(6),
	[EXEMPTION_DSCR] NVARCHAR(50),
	CONSTRAINT [jur_exemption_dscr$EXEMPT_CAT] PRIMARY KEY ([EXEMPT_CAT])
);
GO

CREATE TABLE [jur_tax_dist_exempt_value] (
	[RP_TYPE] NVARCHAR(4) NOT NULL,
	[TAX_DIST] NVARCHAR(6),
	[TAX_DISTRICT_NAME] NVARCHAR(100),
	[PRIOR_YR_RATE] NVARCHAR(10),
	[CURRENT_YR_RATE] NVARCHAR(10),
	[ABT] INTEGER,
	[APD] INTEGER,
	[APO] INTEGER,
	[APR] INTEGER,
	[APS] INTEGER DEFAULT 0,
	[DIS] INTEGER,
	[HIS] INTEGER,
	[LIH] INTEGER DEFAULT 0,
	[MCL] INTEGER,
	[OVR] INTEGER,
	[PAR] INTEGER,
	[PDS] INTEGER,
	[PEX] INTEGER,
	[POL] INTEGER,
	[POV] INTEGER,
	[PRO] INTEGER,
	[RES] INTEGER,
	[SFT] INTEGER DEFAULT 0,
	[SOL] INTEGER,
	[SSA] INTEGER,
	[SSD] INTEGER,
	[SSF] INTEGER DEFAULT 0,
	[STT] INTEGER,
	[STX] INTEGER,
	[SUR] INTEGER,
	[TOT] INTEGER,
	[V11] INTEGER,
	[V12] INTEGER,
	[V13] INTEGER,
	[V14] INTEGER,
	[V21] INTEGER,
	[V22] INTEGER,
	[V23] INTEGER,
	[V24] INTEGER,
	[VCH] INTEGER,
	[VS1] INTEGER,
	[VS2] INTEGER,
	[VS3] INTEGER,
	[VS4] INTEGER,
	[VTX] INTEGER
);
GO

CREATE TABLE [jur_tax_dist_percent_rate] (
	[RP_TYPE] NVARCHAR(4) NOT NULL,
	[TAX_DIST] NVARCHAR(6),
	[TAX_DISTRICT_NAME] NVARCHAR(100),
	[PRIOR_YR_RATE] NVARCHAR(10),
	[CURRENT_YR_RATE] NVARCHAR(10),
	[ABT] NVARCHAR(10),
	[APD] NVARCHAR(10),
	[APO] NVARCHAR(10),
	[APR] NVARCHAR(10),
	[APS] NVARCHAR(10),
	[DIS] NVARCHAR(10),
	[HIS] NVARCHAR(10),
	[LIH] NVARCHAR(10),
	[MCL] NVARCHAR(10),
	[OVR] NVARCHAR(10),
	[PAR] NVARCHAR(10),
	[PDS] NVARCHAR(10),
	[PEX] NVARCHAR(10),
	[POL] NVARCHAR(10),
	[POV] NVARCHAR(10),
	[PRO] NVARCHAR(10),
	[RES] NVARCHAR(10),
	[SFT] NVARCHAR(10),
	[SOL] NVARCHAR(10),
	[SSA] NVARCHAR(10),
	[SSD] NVARCHAR(10),
	[SSF] NVARCHAR(10),
	[STT] NVARCHAR(10),
	[STX] NVARCHAR(10),
	[SUR] NVARCHAR(10),
	[TOT] NVARCHAR(10),
	[V11] NVARCHAR(10),
	[V12] NVARCHAR(10),
	[V13] NVARCHAR(10),
	[V14] NVARCHAR(10),
	[V21] NVARCHAR(10),
	[V22] NVARCHAR(10),
	[V23] NVARCHAR(10),
	[V24] NVARCHAR(10),
	[VCH] NVARCHAR(10),
	[VS1] NVARCHAR(10),
	[VS2] NVARCHAR(10),
	[VS3] NVARCHAR(10),
	[VS4] NVARCHAR(10),
	[VTX] NVARCHAR(10)
);
GO

CREATE TABLE [jur_value] (
	[ACCOUNT] NVARCHAR(13) NOT NULL,
	[TAX_DISTRICT] NVARCHAR(6) NOT NULL,
	[TYPE] NCHAR(1),
	[PCT_DISTRICT] NVARCHAR(6),
	[APPRAISED_VALUE] NVARCHAR(13),
	[TAXABLE_VALUE] NVARCHAR(13),
	CONSTRAINT [jur_value$ACCOUNT] PRIMARY KEY ([ACCOUNT], [TAX_DISTRICT])
);
GO

CREATE TABLE [land] (
	[ACCOUNT] NVARCHAR(13) NOT NULL,
	[LINE_NUMBER] INTEGER NOT NULL,
	[LAND_USE_CODE] NCHAR(4),
	[LAND_USE_DSCR] NVARCHAR(50),
	[SITE_CD] NVARCHAR(4),
	[SITE_CD_DSCR] NVARCHAR(50),
	[SITE_ADJ] NVARCHAR(6),
	[UNIT_TYPE] NCHAR(2),
	[UNITS] NVARCHAR(13),
	[SIZE_FACTOR] NVARCHAR(6),
	[SITE_FACT] NVARCHAR(6),
	[APPR_OVERRIDE_FACTOR] NVARCHAR(6),
	[APPR_OVERRIDE_REASON] NVARCHAR(50),
	[TOT_ADJ] NVARCHAR(12),
	[UNIT_PRICE] NVARCHAR(12),
	[ADJ_UNIT_PRICE] NVARCHAR(14),
	[VALUE] NVARCHAR(11),
	[OVERRIDE_VALUE] NVARCHAR(11),
	CONSTRAINT [land$ACCOUNT] PRIMARY KEY ([ACCOUNT], [LINE_NUMBER])
);
GO

CREATE TABLE [land_ag] (
	[ACCOUNT] NVARCHAR(13) NOT NULL,
	[LINE_NUMBER] INTEGER NOT NULL,
	[LAND_USE_CODE] NCHAR(4),
	[LAND_USE_DSCR] NVARCHAR(50),
	[SITE_CD] NVARCHAR(4),
	[SITE_CD_DSCR] NVARCHAR(50),
	[SITE_ADJ] NVARCHAR(6),
	[UNIT_TYPE] NCHAR(2),
	[UNITS] NVARCHAR(13),
	[SIZE_FACTOR] NVARCHAR(6),
	[SITE_FACTOR] NVARCHAR(6),
	[APPR_OVERRIDE_FACTOR] NVARCHAR(6),
	[APPR_OVERRIDE_REASON] NVARCHAR(50),
	[TOT_ADJ] NVARCHAR(12),
	[UNIT_PRICE] NVARCHAR(12),
	[ADJ_UNIT_PRICE] NVARCHAR(14),
	[VALUE] NVARCHAR(11),
	[OVERRIDE_VALUE] NVARCHAR(11)
);
GO

CREATE TABLE [owners] (
	[ACCOUNT] NVARCHAR(13) NOT NULL,
	[LINE_NUMBER] INTEGER NOT NULL,
	[NAME] NVARCHAR(100),
	[AKA] NVARCHAR(50),
	[PCT_OWN] NVARCHAR(5),
	CONSTRAINT [owners$ACCOUNT] PRIMARY KEY ([ACCOUNT], [LINE_NUMBER])
);
GO

CREATE TABLE [ownership_history] (
	[ACCOUNT] NVARCHAR(13) NOT NULL,
	[PURCHASE_DATE] NVARCHAR(25),
	[NAME] NVARCHAR(100),
	[SITE_ADDRESS] NVARCHAR(75)
);
GO

CREATE TABLE [parcel_tieback] (
	[ACCOUNT] NVARCHAR(13),
	[RELATIONSHIP_TYPE] NCHAR(2),
	[RELATIONSHIP_DESCRIPTION] NVARCHAR(100),
	[RELATED_ACCOUNT_NUMBER] NVARCHAR(13),
	[PERCENT] NVARCHAR(8)
);
GO

CREATE TABLE [permits] (
	[ACCOUNT] NVARCHAR(13) NOT NULL,
	[PERMIT_ID] INTEGER NOT NULL,
	[AGENCY_ID] NCHAR(4),
	[PERMIT_STATUS] NVARCHAR(1),
	[DESCRIPTION] NVARCHAR(50),
	[STATE_CLASS] NVARCHAR(4),
	[PERMIT_TYPE] NVARCHAR(10),
	[PERMIT_TYPE_DSCR] NVARCHAR(50),
	[PROPERTY_TYPE] NVARCHAR(3),
	[ISSUE_DATE] NVARCHAR(10),
	[YEAR] NVARCHAR(4),
	[SITE_NUMBER] NVARCHAR(9),
	[SITE_PFX] NVARCHAR(2),
	[SITE_STREET_NAME] NVARCHAR(50),
	[SITE_TP] NVARCHAR(4),
	[SITE_SFX] NVARCHAR(25),
	[SITE_APT] NVARCHAR(6),
	CONSTRAINT [permits$ACCOUNT] PRIMARY KEY ([ACCOUNT], [PERMIT_ID])
);
GO

CREATE TABLE [real_acct] (
	[ACCOUNT] NVARCHAR(13) NOT NULL,
	[TAX_YEAR] NVARCHAR(4),
	[MAILTO] NVARCHAR(100),
	[MAIL_ADDR_1] NVARCHAR(50),
	[MAIL_ADDR_2] NVARCHAR(50),
	[MAIL_CITY] NVARCHAR(50),
	[MAIL_STATE] NCHAR(2),
	[MAIL_ZIP] NVARCHAR(10),
	[MAIL_COUNTRY] NVARCHAR(50),
	[UNDELIVERABLE] NVARCHAR(1),
	[STR_PFX] NCHAR(2),
	[STR_NUM] INTEGER,
	[STR_NUM_SFX] NCHAR(3),
	[STR_NAME] NVARCHAR(50),
	[STR_SFX] NVARCHAR(25),
	[STR_SFX_DIR] NCHAR(2),
	[STR_UNIT] NVARCHAR(15),
	[SITE_ADDR_1] NVARCHAR(50),
	[SITE_ADDR_2] NVARCHAR(50),
	[SITE_ADDR_3] NVARCHAR(10),
	[STATE_CLASS] NVARCHAR(16),
	[SCHOOL_DIST] NVARCHAR(5),
	[MAP_FACET] NVARCHAR(6),
	[KEY_MAP] NVARCHAR(6),
	[NEIGHBORHOOD_CODE] NVARCHAR(11),
	[NEIGHBORHOOD_GROUP] NVARCHAR(8),
	[MARKET_AREA_1] NVARCHAR(8),
	[MARKET_AREA_1_DSCR] NVARCHAR(50),
	[MARKET_AREA_2] NVARCHAR(8),
	[MARKET_AREA_2_DSCR] NVARCHAR(50),
	[ECON_AREA] NVARCHAR(5),
	[ECON_BLD_CLASS] NVARCHAR(5),
	[CENTER_CODE] NVARCHAR(5),
	[YR_IMPR] NVARCHAR(4),
	[YR_ANNEXED] NVARCHAR(4),
	[SPLT_DT] NCHAR(20),
	[DSC_CD] NCHAR(2),
	[NXT_BUILDING] NVARCHAR(10),
	[TOTAL_BUILDING_AREA] NVARCHAR(12),
	[TOTAL_LAND_AREA] NVARCHAR(12),
	[ACREAGE] NVARCHAR(13),
	[CAP_ACCOUNT] NVARCHAR(7),
	[SHARED_CAD_CODE] NCHAR(3),
	[LAND_VALUE] NVARCHAR(12),
	[IMPROVEMENT_VALUE] NVARCHAR(12),
	[EXTRA_FEATURES_VALUE] NVARCHAR(12),
	[AG_VALUE] NVARCHAR(12),
	[ASSESSED_VALUE] NVARCHAR(12),
	[TOTAL_APPRAISED_VALUE] NVARCHAR(12),
	[TOTAL_MARKET_VALUE] NVARCHAR(12),
	[PRIOR_LND_VALUE] NVARCHAR(12),
	[PRIOR_IMPR_VALUE] NVARCHAR(12),
	[PRIOR_X_FEATURES_VALUE] NVARCHAR(12),
	[PRIOR_AG_VALUE] NVARCHAR(12),
	[PRIOR_TOTAL_APPRAISED_VALUE] NVARCHAR(12),
	[PRIOR_TOTAL_MARKET_VALUE] NVARCHAR(12),
	[NEW_CONSTRUCTION_VALUE] NVARCHAR(12),
	[TOTAL_RCN_VALUE] NVARCHAR(12),
	[VALUE_STATUS] NVARCHAR(36),
	[NOTICED] NVARCHAR(1),
	[NOTICE_DATE] NVARCHAR(25),
	[PROTESTED] NVARCHAR(1),
	[CERTIFIED_DATE] NVARCHAR(25),
	[LAST_INSPECTED_DATE] NVARCHAR(25),
	[LAST_INSPECTED_BY] NCHAR(5),
	[NEW_OWNER_DATE] NVARCHAR(25),
	[LEGAL_DSCR_1] NVARCHAR(50),
	[LEGAL_DSCR_2] NVARCHAR(50),
	[LEGAL_DSCR_3] NVARCHAR(50),
	[LEGAL_DSCR_4] NVARCHAR(50),
	[JURS] NVARCHAR(100),
	CONSTRAINT [real_acct$ACCOUNT] PRIMARY KEY ([ACCOUNT])
);
GO

CREATE TABLE [real_neighborhood_code] (
	[NEIGHBORHOOD_CD] NVARCHAR(11) NOT NULL,
	[GROUP_CD] NVARCHAR(12),
	[DESCRIPTION] NVARCHAR(50)
);
GO

CREATE TABLE [structural_elem1] (
	[ACCOUNT] NVARCHAR(13) NOT NULL,
	[BUILDING_NUMBER] INTEGER NOT NULL,
	[CODE] NVARCHAR(10),
	[ADJ_CD] NVARCHAR(10),
	[STRUCTURE_TYPE] NCHAR(4),
	[TYPE_DESCRIPTION] NVARCHAR(50),
	[CATEGORY_DESCRIPTION] NVARCHAR(50),
	[STATE_CLASS_CODE] NCHAR(4)
);
GO

CREATE TABLE [structural_elem2] (
	[ACCOUNT] NVARCHAR(13) NOT NULL,
	[BUILDING_NUMBER] INTEGER NOT NULL,
	[CODE] NVARCHAR(10),
	[ADJ_CD] NVARCHAR(10),
	[STRUCTURE_TYPE] NCHAR(4),
	[TYPE_DESCRIPTION] NVARCHAR(50),
	[CATEGORY_DESCRIPTION] NVARCHAR(50),
	[STATE_CLASS_CODE] NCHAR(4)
);
GO

CREATE TABLE [t_business_acct] (
	[ACCOUNT] NVARCHAR(12) NOT NULL,
	[TAX_YEAR] NVARCHAR(4),
	[O_NAME] NVARCHAR(100),
	[OWNER] NVARCHAR(100),
	[SITE_ADDRESS] NVARCHAR(80),
	[SITE_CITY] NVARCHAR(50),
	[SITE_STATE] NVARCHAR(5),
	[SITE_ZIP] NVARCHAR(10),
	[MAILTO] NVARCHAR(50),
	[MAIL_ADDRESS1] NVARCHAR(50),
	[MAIL_ADDRESS2] NVARCHAR(50),
	[MAIL_CITY] NVARCHAR(50),
	[MAIL_STATE] NCHAR(2),
	[MAIL_ZIP] NVARCHAR(10),
	[PHONE] NVARCHAR(14),
	[DSCR] NVARCHAR(80),
	[DESCRIPTION1] NVARCHAR(50),
	[DESCRIPTION2] NVARCHAR(50),
	[DESCRIPTION3] NVARCHAR(50),
	[PROPERTY_TYPE] NCHAR(1),
	[PROPERTY_TYPE_DESCR] NVARCHAR(50),
	[STATE_CLASS] NCHAR(2),
	[SIC_DESCR] NVARCHAR(50),
	[SIC_CODE] NVARCHAR(8),
	[SIC_DSCR] NVARCHAR(100),
	[SQUARE_FEET] NVARCHAR(100),
	[CENTER_CODE] NVARCHAR(10),
	[SHARED_CAD] NVARCHAR(1),
	[KEY_MAP] NVARCHAR(6),
	[APPRAISED_VALUE] NVARCHAR(10),
	[PRIOR_APPRAISED_VALUE] NVARCHAR(12),
	[RETURN_CODE] NVARCHAR(52),
	[VALUE_STATUS] NVARCHAR(36),
	[NOTICED] NVARCHAR(1),
	[NOTICE_DATE] NVARCHAR(25),
	[PROTESTED] NVARCHAR(1),
	[CERTIFIED_DATE] NVARCHAR(25),
	[AGENT_ID] NCHAR(6),
	[JURS] NVARCHAR(100),
	CONSTRAINT [t_business_acct$ACCOUNT] PRIMARY KEY ([ACCOUNT])
);
GO

CREATE TABLE [t_business_detail] (
	[ACCOUNT] NVARCHAR(7) NOT NULL,
	[LINE_NUMBER] INTEGER NOT NULL,
	[DEPT_CODE] NCHAR(4) NOT NULL,
	[DEPT_CODE_DESCR] NVARCHAR(50),
	[APPRAISED_VAL] NVARCHAR(12),
	CONSTRAINT [t_business_detail$ACCOUNT] PRIMARY KEY ([ACCOUNT], [LINE_NUMBER], [DEPT_CODE])
);
GO

CREATE TABLE [t_jur_exempt] (
	[ACCOUNT] NVARCHAR(7) NOT NULL,
	[TAX_DIST] NVARCHAR(6),
	[TAX_DIST_NAME] NVARCHAR(100),
	[EXEMPT_CAT] NVARCHAR(4),
	[EXEMPT_DSCR] NVARCHAR(50),
	[PCT_EXEMPT] NVARCHAR(10),
	[EXEMPT_VALUE] NVARCHAR(12)
);
GO

CREATE TABLE [t_jur_tax_dist_exempt_value] (
	[RP_TYPE] NVARCHAR(8) NOT NULL,
	[TAX_DISTRICT] NVARCHAR(6),
	[TAX_DISTRICT_NAME] NVARCHAR(100),
	[PRIOR_YR_RATE] NVARCHAR(10),
	[CURRENT_YR_RATE] NVARCHAR(10),
	[ABT] INTEGER,
	[DIS] INTEGER,
	[ERE] INTEGER DEFAULT 0,
	[ESP] INTEGER DEFAULT 0,
	[GCC] INTEGER DEFAULT 0,
	[HIS] INTEGER,
	[MCL] INTEGER,
	[OVR] INTEGER,
	[PAR] INTEGER,
	[PDS] INTEGER,
	[POL] INTEGER DEFAULT 0,
	[POV] INTEGER,
	[PRO] INTEGER,
	[RES] INTEGER,
	[SOL] INTEGER,
	[SPV] INTEGER,
	[SUR] INTEGER,
	[TOT] INTEGER,
	[UND] INTEGER DEFAULT 0,
	[V11] INTEGER,
	[V12] INTEGER,
	[V13] INTEGER,
	[V14] INTEGER,
	[V21] INTEGER,
	[V22] INTEGER,
	[V23] INTEGER,
	[V24] INTEGER,
	[VS1] INTEGER,
	[VS2] INTEGER,
	[VS3] INTEGER,
	[VS4] INTEGER
);
GO

CREATE TABLE [t_jur_tax_dist_percent_rate] (
	[RP_TYPE] NVARCHAR(8) NOT NULL,
	[TAX_DISTRICT] NVARCHAR(6),
	[TAX_DISTRICT_NAME] NVARCHAR(100),
	[PRIOR_YR_RATE] NVARCHAR(10),
	[CURRENT_YR_RATE] NVARCHAR(10),
	[ABT] NVARCHAR(10),
	[DIS] NVARCHAR(10),
	[ERE] NVARCHAR(10),
	[ESP] NVARCHAR(10),
	[GCC] NVARCHAR(10),
	[HIS] NVARCHAR(10),
	[MCL] NVARCHAR(10),
	[OVR] NVARCHAR(10),
	[PAR] NVARCHAR(10),
	[PDS] NVARCHAR(10),
	[POL] NVARCHAR(10),
	[POV] NVARCHAR(10),
	[PRO] NVARCHAR(10),
	[RES] NVARCHAR(10),
	[SOL] NVARCHAR(10),
	[SPV] NVARCHAR(10),
	[SUR] NVARCHAR(10),
	[TOT] NVARCHAR(10),
	[UND] NVARCHAR(10),
	[V11] NVARCHAR(10),
	[V12] NVARCHAR(10),
	[V13] NVARCHAR(10),
	[V14] NVARCHAR(10),
	[V21] NVARCHAR(10),
	[V22] NVARCHAR(10),
	[V23] NVARCHAR(10),
	[V24] NVARCHAR(10),
	[VS1] NVARCHAR(10),
	[VS2] NVARCHAR(10),
	[VS3] NVARCHAR(10),
	[VS4] NVARCHAR(10)
);
GO

CREATE TABLE [t_jur_value] (
	[ACCOUNT] NVARCHAR(7) NOT NULL,
	[TAX_DISTRICT] NVARCHAR(6) NOT NULL,
	[TAX_DISTRICT_TYPE] NCHAR(1),
	[PCT_EXEMPT] NVARCHAR(12),
	[APPRAISED_VALUE] NVARCHAR(13),
	[TAXABLE_VALUE] NVARCHAR(13),
	CONSTRAINT [t_jur_value$ACCOUNT] PRIMARY KEY ([ACCOUNT], [TAX_DISTRICT])
);
GO

CREATE TABLE [t_pp_c] (
	[ACCOUNT] NVARCHAR(7) NOT NULL,
	[PPT_CODE] NCHAR(1),
	[PIPE_USAGE] NVARCHAR(100),
	[PIPE_SIZE] NVARCHAR(100),
	[PIPE_MILEAGE] NVARCHAR(100),
	[YEAR_INSTALLED] NVARCHAR(100),
	[PIPE_TYPE] NVARCHAR(100),
	[REGULATION] NVARCHAR(100),
	[USAGE_FACTOR] NVARCHAR(100),
	[STATUS] NVARCHAR(100),
	[PIPE_ID] NVARCHAR(100),
	[HCAD_ID] NVARCHAR(100),
	CONSTRAINT [t_pp_c$ACCOUNT] PRIMARY KEY ([ACCOUNT])
);
GO

CREATE TABLE [t_pp_e] (
	[ACCOUNT] NVARCHAR(7) NOT NULL,
	[PPT_CODE] NCHAR(1),
	[RAIL_LEASENUM] NVARCHAR(100),
	[TYPE_INTEREST] NVARCHAR(100),
	[INTEREST_PERCENT] NVARCHAR(100),
	CONSTRAINT [t_pp_e$ACCOUNT] PRIMARY KEY ([ACCOUNT])
);
GO

CREATE TABLE [t_pp_l] (
	[ACCOUNT] NVARCHAR(7) NOT NULL,
	[PPT_CODE] NCHAR(1),
	[TYPE_STRUCTURE] NVARCHAR(100),
	[VOLT_AMP] NVARCHAR(100),
	[EL_MILEAGE] NVARCHAR(100),
	[NUM_OF_CIRCUITS] NVARCHAR(100),
	[CONTRACT_ACCOUNT] NVARCHAR(100),
	CONSTRAINT [t_pp_l$ACCOUNT] PRIMARY KEY ([ACCOUNT])
);
GO

CREATE INDEX [arb_hearings_pp$ACCOUNT]
	ON [arb_hearings_pp] ([ACCOUNT]);
GO

CREATE INDEX [arb_hearings_real$ACCOUNT]
	ON [arb_hearings_real] ([ACCOUNT]);
GO

CREATE INDEX [arb_protest_pp$ACCOUNT]
	ON [arb_protest_pp] ([ACCOUNT]);
GO

CREATE INDEX [arb_protest_real$ACCOUNT]
	ON [arb_protest_real] ([ACCOUNT]);
GO

CREATE INDEX [building_other$ACCOUNT]
	ON [building_other] ([ACCOUNT]);
GO

CREATE INDEX [building_res$ACCOUNT]
	ON [building_res] ([ACCOUNT]);
GO

CREATE INDEX [deeds$clerk_id]
	ON [deeds] ([clerk_id]);
GO

CREATE INDEX [deeds$deed_id]
	ON [deeds] ([deed_id]);
GO

CREATE INDEX [exterior$ACCOUNT]
	ON [exterior] ([ACCOUNT]);
GO

CREATE INDEX [extra_features$ACCOUNT]
	ON [extra_features] ([ACCOUNT]);
GO

CREATE INDEX [fixtures$ACCOUNT]
	ON [fixtures] ([ACCOUNT]);
GO

CREATE INDEX [jur_exempt$ACCOUNT]
	ON [jur_exempt] ([ACCOUNT]);
GO

CREATE INDEX [jur_value$ACCOUNT2]
	ON [jur_value] ([ACCOUNT]);
GO

CREATE INDEX [jur_value$TAX_DISTRICT]
	ON [jur_value] ([TAX_DISTRICT]);
GO

CREATE INDEX [land$ACCOUNT2]
	ON [land] ([ACCOUNT]);
GO

CREATE INDEX [land_ag$ACCOUNT]
	ON [land_ag] ([ACCOUNT]);
GO

CREATE INDEX [owners$ACCOUNT2]
	ON [owners] ([ACCOUNT]);
GO

CREATE INDEX [owners$LINE_NUMBER]
	ON [owners] ([LINE_NUMBER]);
GO

CREATE INDEX [ownership_history$ACCOUNT]
	ON [ownership_history] ([ACCOUNT]);
GO

CREATE INDEX [permits$ACCOUNT2]
	ON [permits] ([ACCOUNT]);
GO

CREATE INDEX [permits$PERMIT_ID]
	ON [permits] ([PERMIT_ID]);
GO

CREATE INDEX [structural_elem1$ACCOUNT]
	ON [structural_elem1] ([ACCOUNT]);
GO

CREATE INDEX [structural_elem2$ACCOUNT]
	ON [structural_elem2] ([ACCOUNT]);
GO

CREATE INDEX [t_business_detail$ACCOUNT2]
	ON [t_business_detail] ([ACCOUNT]);
GO

CREATE INDEX [t_business_detail$DEPT_CODE]
	ON [t_business_detail] ([DEPT_CODE]);
GO

CREATE INDEX [t_business_detail$LINE_NUMBER]
	ON [t_business_detail] ([LINE_NUMBER]);
GO

CREATE INDEX [t_jur_exempt$ACCOUNT]
	ON [t_jur_exempt] ([ACCOUNT]);
GO

CREATE INDEX [t_jur_value$ACCOUNT2]
	ON [t_jur_value] ([ACCOUNT]);
GO

CREATE INDEX [t_jur_value$TAX_DISTRICT]
	ON [t_jur_value] ([TAX_DISTRICT]);
GO


/* CREATE VIEW [all neighborhood(subdivisions) numbers and names by zipcode] AS SELECT DISTINCT Left([Real_acct].[Site_addr_3],5) AS site_zip, Real_acct.Neighborhood_Code, Real_Neighborhood_code.DESCRIPTION
FROM Real_acct INNER JOIN Real_Neighborhood_code ON Real_acct.Neighborhood_Code = Real_Neighborhood_code.NEIGHBORHOOD_CD
WHERE (((Left(Real_acct.Site_addr_3,5)) In ('77000','77001','77002')) And ((Real_acct.State_Class) In ('a1','a2','a3','a4','b2','b3','b4','e1','O2','m3')))
ORDER BY Left([Real_acct].[Site_addr_3],5);

*/
GO


/* CREATE VIEW [all property site address sort by Jurs(where=001)] AS SELECT DISTINCT [Real_acct].[ACCOUNT], [Real_acct].[Site_addr_1] AS site_address, [Real_acct].[Site_addr_2] AS site_city, Left([Real_acct].[Site_addr_3],5) AS site_zip, [Real_acct].[Jurs] AS jurs
FROM Real_acct
WHERE [Real_acct].[Jurs] Like '%001%'
ORDER BY Left([Real_acct].[Site_addr_3],5);

*/
GO


/* CREATE VIEW [all property site address sort by state class] AS SELECT DISTINCT [Real_acct].[ACCOUNT], [Real_acct].[Str_pfx], [Real_acct].[Str_num], [Real_acct].[str_num_sfx], [Real_acct].[Str_name], [Real_acct].[Str_sfx], [Real_acct].[Str_sfx_dir], [Real_acct].[str_unit], [Real_acct].[Site_addr_2] AS site_city, [Real_acct].[Site_addr_3] AS site_zip, [Real_acct].[State_Class]
FROM Real_acct
ORDER BY [Real_acct].[State_Class];

*/
GO


/* CREATE VIEW [all res property had remodeled] AS SELECT DISTINCT Real_acct.ACCOUNT, Real_acct.Mailto, Real_acct.Mail_Addr_1, Real_acct.Mail_Addr_2, Real_acct.Mail_City, Real_acct.Mail_State, Real_acct.Mail_Zip, Real_acct.Mail_Country, Real_acct.Site_addr_1, Real_acct.Site_addr_2, Real_acct.Site_addr_3, Real_acct.Key_Map, Building_res.YR_REMODEL, Structural_elem1.CATEGORY_DESCRIPTION, Structural_elem1.TYPE_DESCRIPTION
FROM (Real_acct INNER JOIN Building_res ON (Real_acct.[ACCOUNT] = Building_res.[ACCOUNT]) AND (Real_acct.[ACCOUNT] = Building_res.[ACCOUNT])) INNER JOIN Structural_elem1 ON Real_acct.[ACCOUNT] = Structural_elem1.[ACCOUNT]
WHERE (((Building_res.YR_REMODEL)<>'') AND ((Structural_elem1.TYPE_DESCRIPTION)='Cost and Design') AND ((Real_acct.State_Class) In ('a1','a2','a3','a4','b2','b3','b4','e1','O2','m3')));

*/
GO


/* CREATE VIEW [all res property owners mail address] AS SELECT DISTINCT Real_acct.ACCOUNT, Real_acct.Mailto, Real_acct.Mail_Addr_1, Real_acct.Mail_Addr_2, Real_acct.Mail_City, Real_acct.Mail_State, Real_acct.Mail_Zip, Real_acct.Mail_Country
FROM Real_acct
WHERE (((Real_acct.State_Class) In ('a1','a2','a3','a4','b2','b3','b4','e1','O2','m3')));

*/
GO


/* CREATE VIEW [all res property owners mail address by Building (where clause)] AS SELECT DISTINCT [Real_acct].[ACCOUNT], [Real_acct].[Mailto], [Real_acct].[Mail_Addr_1], [Real_acct].[Mail_Addr_2], [Real_acct].[Mail_City], [Real_acct].[Mail_State], [Real_acct].[Mail_Zip], [Real_acct].[Mail_Country]
FROM Real_acct INNER JOIN Building_res ON [Real_acct].[ACCOUNT]=[Building_res].[ACCOUNT]
WHERE ((([Real_acct].[State_Class]) In ('a1','a2','a3','a4','b2','b3','b4','e1','O2','m3'))) And use_code In ('101','102','103');

*/
GO


/* CREATE VIEW [all res property owners mail address by Land (where clause)] AS SELECT DISTINCT Real_acct.ACCOUNT, Real_acct.Mailto, Real_acct.Mail_Addr_1, Real_acct.Mail_Addr_2, Real_acct.Mail_City, Real_acct.Mail_State, Real_acct.Mail_Zip, Real_acct.Mail_Country
FROM Real_acct INNER JOIN Land ON Real_acct.ACCOUNT = Land.ACCOUNT
WHERE (((Real_acct.State_Class) In ('a1','a2','a3','a4','b2','b3','b4','e1','O2','m3')))
and land_use_code in ('4200' ,'4201','4209' );

*/
GO


/* CREATE VIEW [all res property owners with pool] AS SELECT DISTINCT [Real_acct].[ACCOUNT], [Real_acct].[Mailto], [Real_acct].[Mail_Addr_1], [Real_acct].[Mail_Addr_2], [Real_acct].[Mail_City], [Real_acct].[Mail_State], [Real_acct].[Mail_Zip], [Real_acct].[Mail_Country], [Real_acct].[Site_addr_1], [Real_acct].[Site_addr_2], [Real_acct].[Site_addr_3], [Real_acct].[Key_Map], [Extra_features].[L_DESCR]
FROM Real_acct INNER JOIN Extra_features ON [Extra_features].[ACCOUNT]=[Real_acct].[ACCOUNT]
WHERE [Real_acct].[state_class] In ('a1', 'a2','a3', 'a4','b2','b3','b4','e1','O2','m3') And [Extra_features].[category]='pl';

*/
GO


/* CREATE VIEW [all res property owners with undeliverable mailing address] AS SELECT DISTINCT Real_acct.ACCOUNT, Real_acct.Mailto, Real_acct.Mail_Addr_1, Real_acct.Mail_Addr_2, Real_acct.Mail_City, Real_acct.Mail_State, Real_acct.Mail_Zip, Real_acct.Mail_Country, Real_acct.undeliverable
FROM Real_acct
WHERE (((Real_acct.undeliverable)='y') AND ((Real_acct.State_Class) In ('a1','a2','a3','a4','b2','b3','b4','e1','O2','m3')));

*/
GO


/* CREATE VIEW [all res property site address separated] AS SELECT DISTINCT [Real_acct].[ACCOUNT], [Real_acct].[Str_pfx], [Real_acct].[Str_num], [Real_acct].[str_num_sfx], [Real_acct].[Str_name], [Real_acct].[Str_sfx], [Real_acct].[Str_sfx_dir], [Real_acct].[str_unit], [Real_acct].[Site_addr_2] AS site_city, [Real_acct].[Site_addr_3] AS site_zip
FROM Real_acct
WHERE ((([Real_acct].[State_Class]) In ('a1', 'a2','a3', 'a4','b2','b3','b4','e1','O2','m3')));

*/
GO


/* CREATE VIEW [all res property site address sort by keymap] AS SELECT DISTINCT Real_acct.ACCOUNT, Real_acct.Site_addr_1 AS site_address, Real_acct.Site_addr_2 AS site_city, Left([Real_acct].[Site_addr_3],5) AS site_zip, Real_acct.Key_Map
FROM Real_acct
WHERE (((Real_acct.State_Class) In ('a1','a2','a3','a4','b2','b3','b4','e1','O2','m3')))
ORDER BY Real_acct.Key_Map;

*/
GO


/* CREATE VIEW [all res property site address sort by school] AS SELECT Real_acct.ACCOUNT, Real_acct.Site_addr_1 AS site_address, Real_acct.Site_addr_2 AS site_city, Left([Real_acct].[Site_addr_3],5) AS site_zip, Real_acct.School_Dist
FROM Real_acct
WHERE (((Real_acct.State_Class) In ('a1','a2','a3','a4','O2')))
ORDER BY Real_acct.School_Dist;

*/
GO


/* CREATE VIEW [all res property site address sort by zipcode] AS SELECT DISTINCT Real_acct.ACCOUNT, Real_acct.Site_addr_1 AS site_address, Real_acct.Site_addr_2 AS site_city, Left([Real_acct].[Site_addr_3],5) AS site_zip
FROM Real_acct
WHERE (((Real_acct.State_Class) In ('a1','a2','a3','a4','b2','b3','b4','e1','O2','m3')))
ORDER BY Left([Real_acct].[Site_addr_3],5);

*/
GO


/* CREATE VIEW [all res property site and neighborhood(subdivisions) by zipcode] AS SELECT DISTINCT Real_acct.ACCOUNT, Real_acct.Site_addr_1 AS site_address, Real_acct.Site_addr_2 AS site_city, Left([Real_acct].[Site_addr_3],5) AS site_zip, Real_acct.Neighborhood_Code, Real_Neighborhood_code.DESCRIPTION
FROM Real_acct INNER JOIN Real_Neighborhood_code ON Real_acct.[Neighborhood_Code] = Real_Neighborhood_code.[NEIGHBORHOOD_CD]
WHERE (((Left([Real_acct].[Site_addr_3],5)) In ('77000','77001','77002')) AND ((Real_acct.State_Class) In ('a1','a2','a3','a4','b2','b3','b4','e1','O2','m3')))
ORDER BY Left([Real_acct].[Site_addr_3],5);

*/
GO


/* CREATE VIEW [all res property with cost and design] AS SELECT DISTINCT Structural_elem1.*
FROM Structural_elem1
WHERE (((Structural_elem1.TYPE_DESCRIPTION)='Cost and Design'));

*/
GO


/* CREATE VIEW [Parcel tieback Undivided Interest Master] AS SELECT Parcel_tieback.*
FROM Parcel_tieback
WHERE Relationship_Type='UM';

*/
GO


/* CREATE VIEW [Parcel tieback Undivided Interest Split (100% total)] AS SELECT Parcel_tieback.*
FROM Parcel_tieback
WHERE ([Parcel_tieback].[Relationship_Type]='us')
ORDER BY [account];

*/
GO


/* CREATE VIEW [Tax_district_rate_percentage] AS SELECT Jur_tax_dist_percent_rate.*
FROM Jur_tax_dist_percent_rate;

*/
GO


/* CREATE VIEW [all real accounts with Agent] AS SELECT Real_acct_agents.*
FROM Real_acct_agents;

*/
GO


/* CREATE VIEW [all real accounts with Agent in 02(where clause)] AS SELECT Real_acct_agents.*
FROM Real_acct_agents
WHERE roles in ('02');

*/
GO


/* CREATE VIEW [Exemption RES - all accounts with Residental exemption] AS SELECT DISTINCT [Jur_exempt].[ACCOUNT], [Jur_exempt].[EXEMPT_CD]
FROM Jur_exempt
WHERE ((([Jur_exempt].[EXEMPT_CD])='res') And (([Jur_exempt].[TAX_DISTRICT])='040'))
ORDER BY 1;

*/
GO


/* CREATE VIEW [Real tax_dist sum value by county] AS SELECT Jur_value.ACCOUNT, Jur_value.TAX_DISTRICT, Jur_value.TYPE, Jur_value.PCT_DISTRICT, Sum(Jur_value.APPRAISED_VALUE) AS SumOfAPPRAISED_VALUE, Sum(Jur_value.TAXABLE_VALUE) AS SumOfTAXABLE_VALUE
FROM Jur_value
WHERE (((Jur_value.TAX_DISTRICT)='040') AND ((Jur_value.TYPE)='t') AND ((Jur_value.ACCOUNT)=[acct]))
GROUP BY Jur_value.ACCOUNT, Jur_value.TAX_DISTRICT, Jur_value.TYPE, Jur_value.PCT_DISTRICT;

*/
GO


/* CREATE VIEW [Real tax_dist sum value by isd] AS SELECT Jur_value.ACCOUNT, Jur_value.TAX_DISTRICT, Jur_value.TYPE, Jur_value.PCT_DISTRICT, Sum(Jur_value.APPRAISED_VALUE) AS Sum_Of_APPRAISED_VALUE, Sum(Jur_value.TAXABLE_VALUE) AS Sum_Of_TAXABLE_VALUE
FROM Jur_value
WHERE (((Jur_value.TYPE)='i') AND ((Jur_value.ACCOUNT)=[acct]))
GROUP BY Jur_value.ACCOUNT, Jur_value.TAX_DISTRICT, Jur_value.TYPE, Jur_value.PCT_DISTRICT;

*/
GO


/* CREATE VIEW [Tangible tax_dist sum value by county] AS SELECT T_jur_value.ACCT, T_jur_value.TAX_DISTRICT, T_jur_value.PCT_EXEMPT, T_jur_value.APPRAISED_VALUE, T_jur_value.TAXABLE_VALUE
FROM T_jur_value
WHERE (((T_jur_value.TAX_DISTRICT)='040') AND ((T_jur_value.TAX_DISTRICT_TYPE)='t'))
GROUP BY T_jur_value.ACCT, T_jur_value.TAX_DISTRICT, T_jur_value.PCT_EXEMPT, T_jur_value.APPRAISED_VALUE, T_jur_value.TAXABLE_VALUE;

*/
GO


/* CREATE VIEW [Tangible tax_dist sum value by isd] AS SELECT T_jur_value.ACCT, T_jur_value.TAX_DISTRICT, T_jur_value.TAX_DISTRICT_TYPE, T_jur_value.PCT_EXEMPT, Sum(T_jur_value.APPRAISED_VALUE) AS SumOfAPPRAISED_VALUE, Sum(T_jur_value.TAXABLE_VALUE) AS SumOfTAXABLE_VALUE
FROM T_jur_value
WHERE (((T_jur_value.TAX_DISTRICT_TYPE)='i') AND ((T_jur_value.ACCT)=[acct]))
GROUP BY T_jur_value.ACCT, T_jur_value.TAX_DISTRICT, T_jur_value.TAX_DISTRICT_TYPE, T_jur_value.PCT_EXEMPT;

*/
GO
