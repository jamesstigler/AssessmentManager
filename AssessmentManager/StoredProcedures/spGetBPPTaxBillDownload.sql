DROP PROCEDURE [dbo].[spGetBPPTaxBillDownload] 
GO

CREATE PROCEDURE [dbo].[spGetBPPTaxBillDownload]
	@TaxYear int,
	@BillingCd int	-- 1=bill.com, 2=client download (rkhall, etc)

AS
BEGIN	
	SELECT 'BPP' AS PropertyType, BillingCd, 
	CASE WHEN BillingCd = 1 THEN 'Bill.com' WHEN BillingCd = 2 THEN 'Client Download' ELSE NULL END AS BillingCdDescription,
	TaxYear, Clients_Name, ClientId, LocationId, Locations_Address, Locations_ClientLocationId, 
	Locations_Name,Locations_City, Locations_StateCd,Locations_Zip, AcctNum, BusinessUnits_Name, AssessmentId, Assessors_Name, 
	Collectors_Name, Payee, AssessorId, CollectorId,Collectors_DueDate, Collectors_DiscountFl,Collectors_DiscountDate, 
	Collectors_DiscountDate2, Collectors_DiscountDate3, Collectors_DiscountDate4,Collectors_StateCd, Collectors_Address1, 
	Collectors_Address2, Collectors_City, 
	Collectors_PayeeStateCd,Collectors_Zip,Collectors_Phone,Consultants_ConsultantName,Consultants_EMail,Consultants_Phone,
	Consultants_FullName,TaxBillNotes,TaxBillAcctNum,TaxBillLoaded,ROUND(SUM(TaxDue), 2) AS TotalTaxDue 
	,t.BPPDueDate1,t.DelinquentDate,t.LegalOwner, t.TaxBillPrintedDate, t.TaxBillDownloadDate

	FROM (SELECT c.BillingCd, l.TaxYear, c.Name AS Clients_Name, c.ClientId, l.LocationId, l.Address AS Locations_Address, 
	l.ClientLocationId AS Locations_ClientLocationId, 
	l.Name AS Locations_Name, ISNULL(c.ExcludeNotified,0) AS ExcludeNotified, ISNULL(c.ExcludeClient,0) AS ExcludeClient, 
	ISNULL(c.ExcludeAbatements,0) AS ExcludeAbatements, ISNULL(c.ExcludeFreeport,0) AS ExcludeFreeport, l.City AS 
	Locations_City, l.StateCd AS Locations_StateCd, l.Zip AS Locations_Zip, ISNULL(asmt.AcctNum,'') AS 
	AcctNum,ISNULL(bu.Name,'') AS BusinessUnits_Name, asmt.AssessmentId, ISNULL(asmt.SavingsExclusionCd,0) AS 
	SavingsExclusionCd, ISNULL(asr.Name,'') AS Assessors_Name, j.FreeportFl AS Jurisdictions_FreeportFl,ISNULL(c.InactiveFl,0) 
	AS Clients_InactiveFl,ISNULL(l.InactiveFl,0) AS Locations_InactiveFl,ISNULL(asmt.InactiveFl,0) AS 
	Assessments_InactiveFl,ISNULL(collect.Name,'NONE') AS Collectors_Name,ISNULL(j.Name,'') AS 
	Jurisdictions_Name,ad.NotifiedValue,0 AS RELandValue, 0 AS REImprovementValue,'Notified Value' AS ValueSource, 
	ad.NotifiedValue AS TotalAssessedValue, ISNULL((SELECT 'Yes' WHERE EXISTS(SELECT tb.ClientId FROM TaxBillsBPP AS tb WHERE 
	tb.ClientId = asmt.ClientId AND tb.LocationId = asmt.LocationId AND tb.AssessmentId = asmt.AssessmentId AND tb.CollectorId = 
	j.CollectorId AND tb.TaxYear = j.TaxYear AND tb.FormData IS NOT NULL)),'No') AS TaxBillLoaded, 0 AS 
	HasInstallments,ad.FinalValue, ISNULL(ad.ClientAbatementAmt,0) AS ClientAbatementAmt, ISNULL(ad.AbatementReductionAmt,0) AS 
	AbatementReductionAmt, ISNULL(ad.ClientFreeportAmt, 0) AS ClientFreeportAmt, ISNULL(ad.FreeportReductionAmt, 0) AS 
	FreeportReductionAmt, ad.AdjDesc1,ad.AdjAmt1,asr.BPPRatio, .00000000001 AS RERatio,round(round(ISNULL(ad.FinalValue,0) - 
	ISNULL(ad.AbatementReductionAmt, 0) -  ISNULL(ad.FreeportReductionAmt, 0) + ISNULL(ad.AdjAmt1, 0),0) * 
	ISNULL(asr.BPPRatio,0),0) AS TaxableValue,ISNULL(j.TaxRate,0) AS TaxRate, ad.TaxBillAdjDesc1, ad.TaxBillAdjAmt1, 
	round(round(round(round(isnull(ad.FinalValue,0)-isnull(ad.AbatementReductionAmt,0) - 
	isnull(ad.FreeportReductionAmt,0)+isnull(ad.AdjAmt1,0),0) * isnull(asr.BPPRatio,0),0) * (isnull(j.TaxRate,0)/100),2) + 
	isnull(ad.TaxBillAdjAmt1,0),2) as TaxDue,ad.PenaltyAmt1, 
	ad.TaxBillPrintedDate,j.JurisdictionId,asr.AssessorId,ISNULL(collect.CollectorId,0) AS CollectorId, collect.BPPDueDate1 AS 
	Collectors_DueDate, collect.DiscountDate AS Collectors_DiscountDate,collect.DiscountDate2 AS 
	Collectors_DiscountDate2,collect.DiscountDate3 AS Collectors_DiscountDate3,collect.DiscountDate4 AS 
	Collectors_DiscountDate4, collect.DiscountFl as Collectors_DiscountFl,ISNULL(collect.Phone,'') as 
	Collectors_Phone,consult.ConsultantName AS Consultants_ConsultantName, consult.EMail AS Consultants_EMail, consult.Phone AS 
	Consultants_Phone,consult.FullName AS 
	Consultants_FullName,taxbills.TaxBillNotes,ISNULL(taxbills.TaxBillAcctNum,ISNULL(asmt.AcctNum,'')) AS TaxBillAcctNum,'P' AS 
	PropertyType, collect.StateCd AS Collectors_StateCd,collect.PayeeStateCd AS Collectors_PayeeStateCd, collect.Payee, 
	collect.Address1 AS Collectors_Address1, collect.Address2 AS Collectors_Address2, collect.City AS Collectors_City, 
	collect.Zip AS Collectors_Zip, asr.LienDate, ISNULL(c.ContactTaxName,'') AS ContactTaxName, ISNULL(c.ContactTaxAddress,'') 
	AS ContactTaxAddress, ISNULL(c.ContactTaxCity,'') AS ContactTaxCity, ISNULL(c.ContactTaxStateCd,'') AS ContactTaxStateCd, 
	ISNULL(c.ContactTaxZip,'') AS ContactTaxZip, RTRIM(LTRIM(ISNULL(l.ClientLocationId,''))) AS ClientLocationId, 
	l.LegalOwner ,collect.BPPDueDate1,DATEADD(day,1,collect.BPPDueDate1) AS DelinquentDate, ad.TaxBillDownloadDate

	FROM Assessors AS asr RIGHT OUTER JOIN LocationsBPP  AS l 
	RIGHT OUTER JOIN AssessmentsBPP  AS asmt 
	INNER JOIN Clients AS c ON asmt.ClientId = c.ClientId ON l.ClientId = asmt.ClientId AND l.LocationId = asmt.LocationId 
	AND l.TaxYear = asmt.TaxYear 
	LEFT OUTER JOIN AssessmentDetailBPP  AS ad 
	INNER JOIN Jurisdictions AS j ON ad.JurisdictionId = j.JurisdictionId AND ad.TaxYear = j.TaxYear 
	ON asmt.ClientId = ad.ClientId AND asmt.LocationId = ad.LocationId AND asmt.AssessmentId = ad.AssessmentId 
	AND asmt.TaxYear = ad.TaxYear ON asr.AssessorId = asmt.AssessorId AND asr.TaxYear = asmt.TaxYear 
	LEFT OUTER JOIN Collectors AS collect ON j.CollectorId = collect.CollectorId AND j.TaxYear = collect.TaxYear 
	LEFT OUTER JOIN BusinessUnits bu ON asmt.ClientId = bu.ClientId AND asmt.BusinessUnitId = bu.BusinessUnitId 
	LEFT OUTER JOIN Consultants consult ON ISNULL(l.ConsultantName,c.BPPConsultantName) = consult.ConsultantName 
	LEFT OUTER JOIN TaxBillsBPP taxbills ON taxbills.ClientId = ad.ClientId AND taxbills.LocationId = ad.LocationId 
	AND taxbills.AssessmentId = ad.AssessmentId AND taxbills.CollectorId = j.CollectorId AND taxbills.TaxYear = ad.TaxYear 

	WHERE  ISNULL(c.ProspectFl,0) = 0  AND  ISNULL(c.InactiveFl,0) = 0  
	AND  ISNULL(l.InactiveFl,0) = 0  AND  ISNULL(asmt.InactiveFl,0) = 0  
	AND  l.TaxYear >= @TaxYear
	AND c.BillingCd = @BillingCd

	and ad.TaxBillDownloadDate is null 
	and ad.TaxBillPrintedDate is not null 
	--12/25 is printed, but not yet sent (V1 sets)
	and NOT ( month(ad.TaxBillPrintedDate)=12 and day(ad.TaxBillPrintedDate)=25)

	) AS t 
	GROUP BY BillingCd, TaxYear, Clients_Name, ClientId, LocationId, Locations_Address, Locations_ClientLocationId, Locations_Name, 
	Locations_City, Locations_StateCd, Locations_Zip, AcctNum, BusinessUnits_Name, AssessmentId, Assessors_Name, 
	Collectors_Name, Payee, AssessorId, CollectorId, Collectors_DueDate, Collectors_DiscountFl, Collectors_DiscountDate, 
	Collectors_DiscountDate2, Collectors_DiscountDate3, Collectors_DiscountDate4, Collectors_StateCd, Collectors_PayeeStateCd, 
	Collectors_Address1, Collectors_Address2, Collectors_City, Collectors_Zip, Collectors_Phone, Consultants_ConsultantName, 
	Consultants_EMail, Consultants_Phone, Consultants_FullName, TaxBillNotes,TaxBillAcctNum, TaxBillLoaded 
	,t.BPPDueDate1,t.DelinquentDate,t.LegalOwner, t.TaxBillPrintedDate, t.TaxBillDownloadDate

	ORDER BY BillingCd, TaxYear desc, Clients_Name,Locations_StateCd, Locations_Address, Locations_ClientLocationId, Locations_City, AcctNum, Collectors_Name

END
GO
