USE [AssessmentManagerData]
GO

IF OBJECT_ID('spGetDocumentInfo') IS NOT NULL
BEGIN
    DROP PROCEDURE spGetDocumentInfo
    IF OBJECT_ID('spGetDocumentInfo') IS NOT NULL
        PRINT '<<< FAILED DROPPING PROCEDURE spGetDocumentInfo >>>'
END
go

CREATE proc [dbo].[spGetDocumentInfo]
	@DocType int,					-- 1=audit, 2=data, etc	
	@ClientId bigint,
	@TaxYear bigint = NULL,
	@PropType bigint = NULL,		-- 1=BPP, 2=RE
	@LocationId bigint = NULL,
	@AssessmentId bigint = NULL,
	@JurisdictionId bigint = NULL,
	@CollectorId bigint = NULL,
	@BPPCompID bigint = NULL
AS
	BEGIN	
		DECLARE @DocPath varchar(1000) = ''
		DECLARE @DocFileshare varchar(1000)	= ''
		DECLARE @Name varchar(300) = ''
		DECLARE @ClientName varchar(300) = ''
		DECLARE @TaxYearPath varchar(5) = ''
		DECLARE @DocFolder varchar(50) = ''
		DECLARE @FileName varchar(1000) = ''
		DECLARE @ManufactureYear int = 0
		DECLARE @Manufacturer varchar(255) = ''
		DECLARE @Model varchar(255) = ''
		DECLARE @SerialNumber varchar(255) = ''

		SET @DocFileshare = (SELECT LTRIM(RTRIM(DocumentFileshare)) + '\' 		
			FROM FirmInfo)

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
				WHEN @DocType = 9 THEN 'Protest'
				WHEN @DocType = 10 THEN 'Evidence'
				WHEN @DocType = 11 THEN 'VSR'
				WHEN @DocType = 12 THEN 'Hearing Notice'
				WHEN @DocType = 13 THEN 'Hearing Final Order'
				WHEN @DocType = 14 THEN 'AOA'
				WHEN @DocType = 15 THEN 'BPP Comps'
				WHEN @DocType = 16 THEN 'Extension'
				WHEN @DocType = 17 THEN 'V1 AGR'
				WHEN @DocType = 18 THEN 'V1 Lawsuit'
				ELSE 'Unknown Document Type'
			END
		SET @DocFolder = @DocFolder + '\'

		IF @DocType = 15
			BEGIN
				SET @DocPath = @DocFileshare + @DocFolder		--\\fileshare\BPP Comps\
				SELECT @ManufactureYear = ManufactureYear, 
						@Manufacturer = LTRIM(RTRIM(Manufacturer)),
						@Model = LTRIM(RTRIM(Model)),
						@SerialNumber = LTRIM(RTRIM(SerialNumber))
				FROM BPPComps
				WHERE CompID = @BPPCompID
				SET @FileName = CONVERT(varchar,@BPPCompID) 
				IF @ManufactureYear > 0
					SET @FileName = @FileName + '_' + CONVERT(varchar,@ManufactureYear)
				IF @Manufacturer <> ''
					SET @FileName = @FileName + '_' + @Manufacturer
				IF @Model <> ''
					SET @FileName = @FileName + '_' + @Model
				IF @SerialNumber <> ''
					SET @FileName = @FileName + '_' + @SerialNumber
			END 
		ELSE
			BEGIN  
				IF @TaxYear IS NOT NULL
					BEGIN
						SET @TaxYearPath = CONVERT(varchar(4),@TaxYear) + '\'
					END

				SET @Name = ISNULL((SELECT LTRIM(RTRIM(Name)) AS Name 
					FROM Clients WHERE ClientId = @ClientId),'Unknown Client')
				EXEC spCleanFileName @Name, @ClientName OUT
				SET @ClientName = @ClientName + '\'		

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
			END			--DocType <> 15 (bppcomp)

		EXEC spCleanFileName @FileName, @FileName OUT

		SELECT @DocPath AS Path, @FileName AS FileName
			
	END
GO

IF OBJECT_ID('spGetDocumentInfo') IS NULL
    PRINT '<<< FAILED CREATING PROCEDURE spGetDocumentInfo >>>'
go


