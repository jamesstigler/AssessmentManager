--USE ASSESSMENTMANAGER TO IMPORT FLAT FILES-------


select * from
--delete 
AssessmentManagerData..REComps where AssessorId=1697 and TaxYear=2025 and AcctNum='00000100129000000'

--This comes from the spUpdateREComps stored proc
		SELECT 1697 AS AssessorId, tmp1.Account_Num, ISNULL(tmp1.IMPR_VAL,0) AS IMPR_VAL, ISNULL(tmp1.LAND_VAL,0) AS LAND_VAL, 
		ISNULL(tmp1.GROSS_BLDG_AREA,0) AS GROSS_BLDG_AREA, ISNULL(tmp1.AREA_SIZE,0) AS AREA_SIZE,
		ISNULL(tmp1.NUM_UNITS,0) AS NUM_UNITS, ISNULL(tmp1.YEAR_BUILT,0) AS YEAR_BUILT, ISNULL(tmp1.BLDG_CLASS_DESC,'') AS BLDG_CLASS_DESC, 
		ISNULL(tmp1.COMPARABILITY_CD,'') AS COMPARABILITY_CD, '' AS EconomicArea, ISNULL(tmp1.LMA,'') AS LMA, ISNULL(tmp1.IMA,'') AS IMA, 
		ISNULL(tmp1.MAPSCO,'') AS MAPSCO,
		ISNULL(tmp1.NBHD_CD,'') AS NBHD_CD , 
		ISNULL(tmp1.STREET_NUM,'') + ISNULL(tmp1.STREET_HALF_NUM,'') + ' ' + ISNULL(tmp1.FULL_STREET_NAME,'') AS StreetName, 
		CASE 
			WHEN ISNULL(tmp1.BIZ_NAME,'') = '' THEN ISNULL(tmp1.OWNER_NAME1,'')
			WHEN ISNULL(tmp1.OWNER_NAME1,'') = '' THEN ISNULL(tmp1.BIZ_NAME,'')
			WHEN ISNULL(tmp1.OWNER_NAME1,'') <> ISNULL(tmp1.BIZ_NAME,'') THEN SUBSTRING(ISNULL(tmp1.OWNER_NAME1,'') + ' dba ' + ISNULL(tmp1.BIZ_NAME,''),1,255)
			ELSE ISNULL(tmp1.BIZ_NAME,'')
		END AS BIZOWNER_NAME,
		ISNULL(tmp1.TOT_VAL,0) AS TOT_VAL, 
		CASE WHEN ISNULL(tmp1.AREA_SIZE,0) > 0 THEN ROUND(ISNULL(tmp1.LAND_VAL,0) / ISNULL(tmp1.AREA_SIZE,0),2) ELSE 0 END AS LandValuePerSqFt,
		CASE WHEN ISNULL(tmp1.GROSS_BLDG_AREA,0) > 0 THEN ROUND(ISNULL(tmp1.IMPR_VAL,0) / ISNULL(tmp1.GROSS_BLDG_AREA,0),2) ELSE 0 END AS ImprovementValuePerSqFt,
		CASE WHEN ISNULL(tmp1.GROSS_BLDG_AREA,0) > 0 THEN ROUND(ISNULL(tmp1.TOT_VAL,0) / ISNULL(tmp1.GROSS_BLDG_AREA,0),2) ELSE 0 END AS TotalValuePerSqFt,
		CASE WHEN ISNULL(tmp1.NUM_UNITS,0) > 0 THEN ISNULL(tmp1.TOT_VAL,0) / ISNULL(tmp1.NUM_UNITS,0) ELSE 0 END AS TotalValuePerUnit,
		CASE WHEN ISNULL(tmp1.AREA_SIZE,0) > 0 THEN ISNULL(tmp1.GROSS_BLDG_AREA,0) / ISNULL(tmp1.AREA_SIZE,0) ELSE 0 END AS LandBuildingRatio,
		ISNULL(tmp1.CONSTR_TYP_DESC,'') AS CONSTR_TYP_DESC, ISNULL(tmp1.CITY_EFF_YR,0) AS CITY_EFF_YR, 
		ISNULL(tmp1.APPR_METHOD_DESC,'') AS APPR_METHOD_DESC, ISNULL(tmp1.PRICING_METH_DESC,'') AS PRICING_METH_DESC

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
		MAX(account_info.OWNER_NAME1) AS OWNER_NAME1, 
		MAX(account_info.OWNER_NAME2) AS OWNER_NAME2, MAX(account_info.EXCLUDE_OWNER) AS EXCLUDE_OWNER, 
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
		--select detail record with the greatest sq footage and use that bldgdesc
		(SELECT TOP 1 d2.BLDG_CLASS_DESC FROM com_detail d2 WHERE d2.ACCOUNT_NUM = account_apprl_year.ACCOUNT_NUM 
			AND d2.GROSS_BLDG_AREA = (SELECT MAX(d3.GROSS_BLDG_AREA) FROM com_detail d3 WHERE d3.ACCOUNT_NUM = d2.ACCOUNT_NUM)) AS BLDG_CLASS_DESC,
		MIN(com_detail.YEAR_BUILT) AS YEAR_BUILT, SUM(com_detail.GROSS_BLDG_AREA) AS GROSS_BLDG_AREA, 
		MAX(com_detail.FOUNDATION_TYP_DESC) AS FOUNDATION_TYP_DESC, 
		MAX(com_detail.FOUNDATION_AREA) AS FOUNDATION_AREA, MAX(com_detail.BASEMENT_DESC) AS BASEMENT_DESC, MAX(com_detail.BASEMENT_AREA) AS BASEMENT_AREA, 
		MAX(com_detail.NUM_STORIES) AS NUM_STORIES, 
		--select detail record with the greatest sq footage and use that construction type
		(SELECT TOP 1 d2.CONSTR_TYP_DESC FROM com_detail d2 WHERE d2.ACCOUNT_NUM = account_apprl_year.ACCOUNT_NUM 
			AND d2.GROSS_BLDG_AREA = (SELECT MAX(d3.GROSS_BLDG_AREA) FROM com_detail d3 WHERE d3.ACCOUNT_NUM = d2.ACCOUNT_NUM)) AS CONSTR_TYP_DESC,	
		MAX(com_detail.HEATING_TYP_DESC) AS HEATING_TYP_DESC, MAX(com_detail.AC_TYP_DESC) AS AC_TYP_DESC, 
		MAX(com_detail.NUM_UNITS) AS NUM_UNITS, 
		MAX(com_detail.NET_LEASE_AREA) AS NET_LEASE_AREA, MAX(com_detail.PROPERTY_NAME) AS PROPERTY_NAME, MAX(com_detail.PROPERTY_QUAL_DESC) AS PROPERTY_QUAL_DESC,
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
		HAVING MAX(CONVERT(bigint,account_apprl_year.TOT_VAL)) >= 250000
		) as tmp1
		order by 1,2


select distinct r.AssessorId, r.TaxYear, r.BuildingClass,'BuildingClass','user' from REComps r where r.AssessorId=1697 and r.TaxYear=2019
and not exists (select rcc.AssessorId, rcc.TaxYear, rcc.CodeValue, rcc.FieldName from RECompCodes rcc where rcc.AssessorId=r.AssessorId 
and rcc.TaxYear=r.TaxYear and rcc.CodeValue = r.BuildingClass AND rcc.FieldName = 'BuildingClass')

select * from RECompCodes where AssessorId=1697 and taxyear=2021

exec spUpdaterecompcodes @Assessorid=1697, @taxyear=2020, @adduser='me'


-- ***************           UPDATE REAL ESTATE NOTIFIED VALUES    ***************

select * from AssessmentManagerData..Assessors where AssessorId=1697


SELECT d.ACCOUNT_NUM, isnull(d.IMPR_VAL,0) AS IMPR_VAL, isnull(d.LAND_VAL,0) AS LAND_VAL, ad.REImprovementValue, ad.RELandValue, ad.*
--update AssessmentManagerData..AssessmentDetailRE set REImprovementValue=d.IMPR_VAL, RELandValue=d.LAND_VAL, ChangeDate=GETDATE(), ChangeUser='stiglerfamily'
--update AssessmentManagerData..AssessmentDetailRE set REImprovementValue=null, RELandValue=null, ChangeDate=GETDATE(), ChangeUser='stiglerfamily'
FROM DCAD..account_apprl_year d, AssessmentManagerData..AssessmentDetailRE ad, AssessmentManagerData..AssessmentsRE a,
AssessmentManagerData..Clients c, AssessmentManagerData..LocationsRE l
where d.ACCOUNT_NUM=a.AcctNum and ad.ClientId=a.ClientId and ad.LocationId=a.LocationId and ad.AssessmentId=a.AssessmentId and ad.TaxYear=a.TaxYear
and isnull(a.inactivefl,0)=0
and c.ClientId=l.ClientId and isnull(c.inactivefl,0)=0
and l.ClientId=a.ClientId and l.LocationId=a.LocationId and l.TaxYear=a.TaxYear and isnull(l.inactivefl,0)=0
and a.AssessorId=1697 and a.TaxYear=2020


-- ***************           UPDATE BPP NOTIFIED VALUES    ***************

SELECT d.ACCOUNT_NUM, isnull(d.TOT_VAL,0) AS TOT_VAL, ad.NotifiedValue, ad.*,d.*
--update AssessmentManagerData..AssessmentDetailbpp set notifiedValue=d.tot_val, ChangeDate=GETDATE(), ChangeUser='stiglerfamily'
--update AssessmentManagerData..AssessmentDetailbpp set notifiedvalue=null, ChangeDate=GETDATE(), ChangeUser='stiglerfamily'
FROM DCAD..account_apprl_year d, AssessmentManagerData..AssessmentDetailBPP ad, AssessmentManagerData..AssessmentsBPP a,
AssessmentManagerData..Clients c, AssessmentManagerData..LocationsBPP l
where d.ACCOUNT_NUM=a.AcctNum and ad.ClientId=a.ClientId and ad.LocationId=a.LocationId and ad.AssessmentId=a.AssessmentId and ad.TaxYear=a.TaxYear
and isnull(a.inactivefl,0)=0
and c.ClientId=l.ClientId and isnull(c.inactivefl,0)=0
and l.ClientId=a.ClientId and l.LocationId=a.LocationId and l.TaxYear=a.TaxYear and isnull(l.inactivefl,0)=0
and a.AssessorId=1697 and a.TaxYear=2020


