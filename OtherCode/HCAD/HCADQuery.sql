 use HCAD
 
 truncate table real_acct
 truncate table real_neighborhood_code
 truncate table building_other
 truncate table owners
 truncate table jur_tax_dist_exempt_value
 truncate table jur_value

 BULK INSERT real_acct FROM
'C:\OurFolders\VantageOne\HCAD\FlatFiles\real_acct.txt'
WITH(FIRSTROW=2, ROWTERMINATOR = '\n', FIELDTERMINATOR = '\t')

BULK INSERT real_neighborhood_code FROM
'C:\OurFolders\VantageOne\HCAD\FlatFiles\real_neighborhood_code.txt'
WITH(FIRSTROW=2, ROWTERMINATOR = '\n', FIELDTERMINATOR = '\t')

-- BULK INSERT owners FROM
--'C:\OurFolders\VantageOne\HCAD\FlatFiles\owners.txt'
--WITH(FIRSTROW=2, ROWTERMINATOR = '\n', FIELDTERMINATOR = '\t')

BULK INSERT building_other  FROM
'C:\OurFolders\VantageOne\HCAD\FlatFiles\building_other.txt'
WITH(FIRSTROW=2, ROWTERMINATOR = '\n', FIELDTERMINATOR = '\t')

--BULK INSERT jur_tax_dist_exempt_value  FROM
--'C:\OurFolders\VantageOne\HCAD\FlatFiles\jur_tax_dist_exempt_value.txt'
--WITH(FIRSTROW=2, ROWTERMINATOR = '\n', FIELDTERMINATOR = '\t')

--BULK INSERT jur_value  FROM
--'C:\OurFolders\VantageOne\HCAD\FlatFiles\jur_value.txt'
--WITH(FIRSTROW=2, ROWTERMINATOR = '\n', FIELDTERMINATOR = '\t')




--*******************       RE Sales/Comps    *********************
--RE sales query
SELECT 
r.ACCOUNT, r.TAX_YEAR, r.MAILTO, r.MAIL_ADDR_1, r.MAIL_CITY, r.MAIL_STATE, r.MAIL_ZIP, r.MAIL_COUNTRY, r.SITE_ADDR_1, r.SITE_ADDR_2, 
r.NEIGHBORHOOD_CODE, r.MARKET_AREA_1_DSCR, 
r.MARKET_AREA_2_DSCR, r.ECON_AREA, r.ECON_BLD_CLASS, r.YR_IMPR, r.TOTAL_BUILDING_AREA, r.TOTAL_LAND_AREA, r.ACREAGE, r.LAND_VALUE, 
r.EXTRA_FEATURES_VALUE, r.IMPROVEMENT_VALUE, convert(bigint, isnull(r.EXTRA_FEATURES_VALUE,0)) + convert(bigint, isnull(r.IMPROVEMENT_VALUE,0)) AS TOTAL_IMPROVED_VALUE, 
r.ASSESSED_VALUE, 
r.TOTAL_APPRAISED_VALUE, r.TOTAL_MARKET_VALUE, r.LEGAL_DSCR_1, r.LEGAL_DSCR_2, r.LEGAL_DSCR_3, r.LEGAL_DSCR_4, n.DESCRIPTION, 
ISNULL(r.NEIGHBORHOOD_CODE, N'') + ' ' + ISNULL(n.DESCRIPTION, N'')                           AS NeighborhoodCode,
LTRIM(RTRIM(ISNULL(
(
ISNULL((select 'Fireproofed Steel' where exists (select * from building_other bo where bo.account=r.account and bo.CLASS_STRUC_DESCRIPTION = 'Fireproofed Steel')),'')
 + ' ' +
 ISNULL((select 'Masonry Bearing' where exists (select * from building_other bo where bo.account=r.account and bo.CLASS_STRUC_DESCRIPTION = 'Masonry Bearing')),'')
+ ' ' +
 ISNULL((select 'Mobile Home' where exists (select * from building_other bo where bo.account=r.account and bo.CLASS_STRUC_DESCRIPTION = 'Mobile Home')),'')
+ ' ' +
 ISNULL((select 'Open Steel Skeleton' where exists (select * from building_other bo where bo.account=r.account and bo.CLASS_STRUC_DESCRIPTION = 'Open Steel Skeleton')),'')
+ ' ' +
 ISNULL((select 'Reinforced Concrete' where exists (select * from building_other bo where bo.account=r.account and bo.CLASS_STRUC_DESCRIPTION = 'Reinforced Concrete')),'')
+ ' ' +
 ISNULL((select 'Residential' where exists (select * from building_other bo where bo.account=r.account and bo.CLASS_STRUC_DESCRIPTION = 'Residential')),'')
+ ' ' +
 ISNULL((select 'Storage Tank' where exists (select * from building_other bo where bo.account=r.account and bo.CLASS_STRUC_DESCRIPTION = 'Storage Tank')),'')
+ ' ' +
 ISNULL((select 'Wood or Light Steel' where exists (select * from building_other bo where bo.account=r.account and bo.CLASS_STRUC_DESCRIPTION = 'Wood or Light Steel')),'')
)
,'')))
as ConstructionType,
(select max(use_code) from building_other bo where bo.account=r.account group by account) as USE_CODE,
(select MIN(bo.IMPROV_TYPE) from building_other bo where bo.ACCOUNT=r.ACCOUNT and bo.BLD_NUM=1 GROUP BY bo.ACCOUNT) as IMPROV_TYPE

FROM            dbo.real_acct AS r 
LEFT OUTER JOIN real_neighborhood_code AS n ON r.NEIGHBORHOOD_CODE = n.NEIGHBORHOOD_CD

WHERE CONVERT(bigint, r.TOTAL_APPRAISED_VALUE) >= 500000






select distinct CLASS_STRUC_DESCRIPTION from building_other order by CLASS_STRUC_DESCRIPTION

Fireproofed Steel
Masonry Bearing
Mobile Home
Open Steel Skeleton
Reinforced Concrete
Residential
Storage Tank
Wood or Light Steel





--************************     RE notified value import    *********************

SELECT        acct.ACCOUNT, acct.TAX_YEAR, acct.LAND_VALUE, acct.TOTAL_APPRAISED_VALUE, 
	ISNULL(CONVERT(bigint, acct.TOTAL_APPRAISED_VALUE), 0) - ISNULL(CONVERT(bigint, acct.LAND_VALUE), 0) AS TOTAL_IMPROVEMENT_VALUE, 
	acct.NOTICE_DATE, acct.NOTICED,
	ad.RELandValue,ad.REImprovementValue,ad.ChangeDate, ad.ChangeUser,a.ValueProtestDeadlineDate,a.ValueProtestHearingDate,
	a.ClientId, a.LocationId, a.AssessmentId, a.TaxYear,ad.JurisdictionId

--update AssessmentManagerData..AssessmentDetailRE set REImprovementValue=ISNULL(CONVERT(bigint, acct.TOTAL_APPRAISED_VALUE), 0) - ISNULL(CONVERT(bigint, acct.LAND_VALUE), 0), RELandValue=acct.LAND_VALUE, ChangeDate=GETDATE(), ChangeUser='stiglerfamily'
--update AssessmentManagerData..AssessmentDetailRE set REImprovementValue=null, RELandValue=null, ChangeDate=GETDATE(), ChangeUser='stiglerfamily'

FROM  HCAD..real_acct AS acct  
INNER JOIN AssessmentManagerData..AssessmentsRE AS a ON a.AcctNum = acct.ACCOUNT AND acct.TAX_YEAR = a.TaxYear 
INNER JOIN AssessmentManagerData..AssessmentDetailRE AS ad ON ad.ClientId = a.ClientId AND ad.LocationId = a.LocationId AND ad.AssessmentId = a.AssessmentId AND ad.TaxYear = a.TaxYear
WHERE a.AssessorId=2252 and a.TaxYear=2020



--don't need codes to update notified since all values are the same in TX
--populate tax district codes for each jurisdiction
SELECT JurisdictionId, TaxYear, Name, TaxDistrictCd
FROM 
AssessmentManagerData..Jurisdictions
--update AssessmentManagerData..Jurisdictions set taxdistrictcd='061'

WHERE  jurisdictionid in 
(5352,
5639,
6098,
7391,
7398,
7633,
7634,
7682)
and JurisdictionId=7682
