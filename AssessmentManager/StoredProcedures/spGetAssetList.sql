DROP PROCEDURE [dbo].[spGetAssetList] 
GO
  

CREATE PROCEDURE spGetAssetList
	@ClientId bigint,
	@LocationId bigint,
	@AssessmentId bigint,
	@TaxYear smallint,
	@NeedFactoredAmounts tinyint = 0,
	@Accrual tinyint = 0,
	@NeedFactoringEntityNames tinyint = 0,
	@NeedTotalValues tinyint = 0,
	@NeedTotalOriginalCost tinyint = 0,
	@NeedDetail tinyint = 0,
	@FactorEntityId bigint = 0,
	@NeedFixedAndInv tinyint = 0
	 
AS
	BEGIN
		DECLARE 
			@FactorEntityExists1 tinyint = 0, 
			@FactorEntityExists2 tinyint = 0, 
			@FactorEntityExists3 tinyint = 0, 
			@FactorEntityExists4 tinyint = 0, 
			@FactorEntityExists5 tinyint = 0

		CREATE TABLE #temptbl
			(ClientId bigint, 
			LocationId bigint,
			AssessmentId bigint,
			AssetId varchar(30), 
			TaxYear smallint,
			OriginalCost bigint null,
			PurchaseDate datetime,
			[Description] varchar(255) null,
			GLCode varchar(50) null,
			Clients_Name varchar(255),
			LegalOwner varchar(255) null,
			Locations_Address varchar(50) null,
			Locations_City varchar(50) null,
			Locations_StateCd char(2) not null,
			Locations_ClientLocationId varchar(255) null,
			Assessors_Name varchar(255) null,
			Assessments_AcctNum varchar(50) null,
			Clients_ExcludeNotified bit null,
			Clients_ExcludeAbatements bit null,
			Clients_ExcludeFreeport bit null,
			Clients_ExcludeClient bit null,
			Assessments_SavingsExclusionCd int null,
			VIN varchar(255) null,
			Assets_LocationAddress varchar(255) null,
			ClientRenditionValue float null,
			BPPRatio float null,
			BusinessUnitId bigint null,
			LeaseType varchar(50) null,
			LessorName varchar(50) null,
			LessorAddress varchar(255) null,
			LeaseTerm smallint null,
			EquipmentMake varchar(50) null,
			EquipmentModel varchar(50) null,
			InterstateAllocationFl bit null,			
			AuditFl bit null,
			AssetsLoadedFl bit null,
			AssetsVerifiedFl bit null,
			AssetsLoadedDate datetime null,
			AssetsVerifiedDate datetime null,

			FactorEntityId1 bigint null,
			FactoringEntityName1 varchar(255) null,
			ClientMappingFactorCode1 varchar(50) null,
			ClientMappingFactorDesc1 varchar(255),
            ClientMappingFactorCodeOverride1 varchar(50) null,
			ClientMappingFactorDescOverride1 varchar(255),
            ClientFactorCode1 varchar(50) null,
			ClientFactorDesc1 varchar(255),
            EntityFactorCodeOverride1 varchar(50) null,
			EntityFactorDescOverride1 varchar(255),
			EntityFactorCode1 varchar(50) null,
			EntityFactorDesc1 varchar(255) null,
			ClientFactor1 float null,
			EntityFactor1 float null,
			AllocationPct1 float null,
			InterstateAllocationPct1 float null,
			ClientValue1 bigint null,
			EntityValue1 bigint null,

			FactorEntityId2 bigint null,
			FactoringEntityName2 varchar(255) null,
			ClientMappingFactorCode2 varchar(50) null,
			ClientMappingFactorDesc2 varchar(255),
            ClientMappingFactorCodeOverride2 varchar(50) null,
			ClientMappingFactorDescOverride2 varchar(255),
            ClientFactorCode2 varchar(50) null,
			ClientFactorDesc2 varchar(255),
            EntityFactorCodeOverride2 varchar(50) null,
			EntityFactorDescOverride2 varchar(255),
			EntityFactorCode2 varchar(50) null,
			EntityFactorDesc2 varchar(255) null,
			ClientFactor2 float null,
			EntityFactor2 float null,
			AllocationPct2 float null,
			InterstateAllocationPct2 float null,
			ClientValue2 bigint null,
			EntityValue2 bigint null,

			FactorEntityId3 bigint null,
			FactoringEntityName3 varchar(255) null,
			ClientMappingFactorCode3 varchar(50) null,
			ClientMappingFactorDesc3 varchar(255),
            ClientMappingFactorCodeOverride3 varchar(50) null,
			ClientMappingFactorDescOverride3 varchar(255),
            ClientFactorCode3 varchar(50) null,
			ClientFactorDesc3 varchar(255),
            EntityFactorCodeOverride3 varchar(50) null,
			EntityFactorDescOverride3 varchar(255),
			EntityFactorCode3 varchar(50) null,
			EntityFactorDesc3 varchar(255) null,
			ClientFactor3 float null,
			EntityFactor3 float null,
			AllocationPct3 float null,
			InterstateAllocationPct3 float null,
			ClientValue3 bigint null,
			EntityValue3 bigint null,

			FactorEntityId4 bigint null,
			FactoringEntityName4 varchar(255) null,
			ClientMappingFactorCode4 varchar(50) null,
			ClientMappingFactorDesc4 varchar(255),
            ClientMappingFactorCodeOverride4 varchar(50) null,
			ClientMappingFactorDescOverride4 varchar(255),
            ClientFactorCode4 varchar(50) null,
			ClientFactorDesc4 varchar(255),
            EntityFactorCodeOverride4 varchar(50) null,
			EntityFactorDescOverride4 varchar(255),
			EntityFactorCode4 varchar(50) null,
			EntityFactorDesc4 varchar(255) null,
			ClientFactor4 float null,
			EntityFactor4 float null,
			AllocationPct4 float null,
			InterstateAllocationPct4 float null,
			ClientValue4 bigint null,
			EntityValue4 bigint null,

			FactorEntityId5 bigint null,
			FactoringEntityName5 varchar(255) null,
			ClientMappingFactorCode5 varchar(50) null,
			ClientMappingFactorDesc5 varchar(255),
            ClientMappingFactorCodeOverride5 varchar(50) null,
			ClientMappingFactorDescOverride5 varchar(255),
            ClientFactorCode5 varchar(50) null,
			ClientFactorDesc5 varchar(255),
            EntityFactorCodeOverride5 varchar(50) null,
			EntityFactorDescOverride5 varchar(255),
			EntityFactorCode5 varchar(50) null,
			EntityFactorDesc5 varchar(255) null,
			ClientFactor5 float null,
			EntityFactor5 float null,
			AllocationPct5 float null,
			InterstateAllocationPct5 float null,
			ClientValue5 bigint null,
			EntityValue5 bigint null,
			)
			
		INSERT #temptbl (ClientId, LocationId, AssessmentId, AssetId, TaxYear, OriginalCost,
			PurchaseDate, [Description], GLCode, FactorEntityId1, 
			FactorEntityId2, FactorEntityId3,
			FactorEntityId4, FactorEntityId5, Clients_Name, LegalOwner, Locations_Address, Locations_City,
			Locations_StateCd, Locations_ClientLocationId, Assessors_Name, Assessments_AcctNum, Clients_ExcludeNotified, Clients_ExcludeAbatements,
			Clients_ExcludeFreeport, Clients_ExcludeClient, Assessments_SavingsExclusionCd, VIN, Assets_LocationAddress,
			ClientRenditionValue, BPPRatio, BusinessUnitId,
			LeaseType, LessorName, LessorAddress, LeaseTerm, EquipmentMake, EquipmentModel, InterstateAllocationFl, AuditFl,
			AssetsLoadedFl, AssetsVerifiedFl, AssetsLoadedDate, AssetsVerifiedDate
		)				
		SELECT c.ClientId, l.LocationId, assess.AssessmentId, a.AssetId, a.TaxYear, ISNULL(a.OriginalCost,0),
			a.PurchaseDate, a.Description,a.GLCode, CASE WHEN @FactorEntityId = 0 THEN assess.FactorEntityId1 ELSE @FactorEntityId END, 
			assess.FactorEntityId2, assess.FactorEntityId3, 
			assess.FactorEntityId4, assess.FactorEntityId5, c.Name,ISNULL(l.LegalOwner,c.Name), l.Address,l.City,
			l.StateCd, ISNULL(l.ClientLocationId,''), assessor.Name, assess.AcctNum, ISNULL(c.ExcludeNotified,0), ISNULL(c.ExcludeAbatements,0),
			ISNULL(c.ExcludeFreeport,0), ISNULL(c.ExcludeClient,0), ISNULL(assess.SavingsExclusionCd,0), a.VIN, a.LocationAddress,
			assess.ClientRenditionValue, ISNULL(assessor.BPPRatio,0),ISNULL(assess.BusinessUnitId,0),
			LeaseType, LessorName, LessorAddress, LeaseTerm, EquipmentMake, EquipmentModel, 
			ISNULL(assess.InterstateAllocationFl,ISNULL(c.InterstateAllocationFl,0)), a.AuditFl,
			assess.AssetsLoadedFl, assess.AssetsVerifiedFl, assess.AssetsLoadedDate, assess.AssetsVerifiedDate

		FROM AssessmentsBPP AS assess
        INNER JOIN Clients AS c ON assess.ClientId = c.ClientId
        INNER JOIN LocationsBPP AS l ON assess.ClientId = l.ClientId
			AND assess.LocationId = l.LocationId AND assess.TaxYear = l.TaxYear
        LEFT OUTER JOIN Assessors AS assessor on assess.AssessorId = assessor.AssessorId
			AND assess.TaxYear = assessor.TaxYear
        LEFT OUTER JOIN Assets AS a ON assess.ClientId = a.ClientId AND assess.LocationId = a.LocationId AND assess.AssessmentId = a.AssessmentId
			AND assess.TaxYear = a.TaxYear
        WHERE assess.TaxYear = @TaxYear AND assess.ClientId = @ClientId AND assess.LocationId = @LocationId AND assess.AssessmentId = @AssessmentId
		
		--If FactorEntityId is passed, it is the only entity calculated and is put into the #1 bucket
		UPDATE #temptbl SET FactoringEntityName1 = (SELECT Name + ', ' + StateCd FROM FactorEntities WHERE FactorEntityId = #temptbl.FactorEntityId1) 
			WHERE FactorEntityId1 IS NOT NULL
		IF @@ROWCOUNT > 0 BEGIN SET @FactorEntityExists1 = 1 END

		IF @Accrual = 0 AND @FactorEntityId = 0
		BEGIN
			UPDATE #temptbl SET FactoringEntityName2 = (SELECT Name + ', ' + StateCd FROM FactorEntities WHERE FactorEntityId = #temptbl.FactorEntityId2) 
				WHERE FactorEntityId2 IS NOT NULL
			IF @@ROWCOUNT > 0 BEGIN SET @FactorEntityExists2 = 1 END
			UPDATE #temptbl SET FactoringEntityName3 = (SELECT Name + ', ' + StateCd FROM FactorEntities WHERE FactorEntityId = #temptbl.FactorEntityId3) 
				WHERE FactorEntityId3 IS NOT NULL
			IF @@ROWCOUNT > 0 BEGIN SET @FactorEntityExists3 = 1 END
			UPDATE #temptbl SET FactoringEntityName4 = (SELECT Name + ', ' + StateCd FROM FactorEntities WHERE FactorEntityId = #temptbl.FactorEntityId4) 
				WHERE FactorEntityId4 IS NOT NULL
			IF @@ROWCOUNT > 0 BEGIN SET @FactorEntityExists4 = 1 END
			UPDATE #temptbl SET FactoringEntityName5 = (SELECT Name + ', ' + StateCd FROM FactorEntities WHERE FactorEntityId = #temptbl.FactorEntityId5) 
				WHERE FactorEntityId5 IS NOT NULL
			IF @@ROWCOUNT > 0 BEGIN SET @FactorEntityExists5 = 1 END		
		END

		IF @NeedFactoringEntityNames = 1
			SELECT DISTINCT NULL AS ReturnTypeFactoringEntityNames, 
				FactoringEntityName1,FactoringEntityName2,FactoringEntityName3,FactoringEntityName4,FactoringEntityName5 FROM #temptbl

		IF @FactorEntityExists1 = 1
		BEGIN
			--client gl mapping
			UPDATE #temptbl SET ClientMappingFactorCode1 = cx.FactorCode, ClientMappingFactorDesc1 = fec.Description
				FROM ClientGLCodeXRef AS cx
				INNER JOIN FactorEntityCodes AS fec ON cx.FactorEntityId = fec.FactorEntityId
					AND cx.FactorCode = fec.FactorCode AND cx.TaxYear = fec.TaxYear
				INNER JOIN #temptbl ON #temptbl.ClientId = cx.ClientId AND #temptbl.Locations_StateCd = cx.StateCd
					AND #temptbl.GLCode = cx.GLCode AND #temptbl.TaxYear = cx.TaxYear AND #temptbl.FactorEntityId1 = cx.FactorEntityId
			--client reclass (overrides client gl mapping)
			UPDATE #temptbl SET ClientMappingFactorCodeOverride1 = fec.FactorCode, ClientMappingFactorDescOverride1 = fec.Description				
				FROM FactorEntityCodes AS fec 
				INNER JOIN ClientFactorCodeOverrides AS cfc ON fec.FactorEntityId = cfc.FactorEntityId AND fec.FactorCode = cfc.FactorCode
					AND fec.TaxYear = cfc.TaxYear 
				WHERE cfc.ClientId = @ClientId AND cfc.LocationId = @LocationId AND cfc.AssessmentId = @AssessmentId AND cfc.TaxYear = @TaxYear
					AND cfc.FactorEntityId = #temptbl.FactorEntityId1 AND cfc.AssetId = #temptbl.AssetId
			--final client factor
			UPDATE #temptbl SET ClientFactorCode1 = ISNULL(ClientMappingFactorCodeOverride1,ClientMappingFactorCode1), 
				ClientFactorDesc1 = ISNULL(ClientMappingFactorDescOverride1,ClientMappingFactorDesc1)
			--entity factor override
			UPDATE #temptbl SET EntityFactorCodeOverride1 = fec.FactorCode, EntityFactorDescOverride1 = fec.Description				
				FROM FactorEntityCodes AS fec 
				INNER JOIN FactorCodeOverrides AS fc ON fec.FactorEntityId = fc.FactorEntityId AND fec.FactorCode = fc.FactorCode
					AND fec.TaxYear = fc.TaxYear 
				WHERE fc.ClientId = @ClientId AND fc.LocationId = @LocationId AND fc.AssessmentId = @AssessmentId AND fc.TaxYear = @TaxYear
					AND fc.FactorEntityId = #temptbl.FactorEntityId1 AND fc.AssetId = #temptbl.AssetId
			--final factor for county
			UPDATE #temptbl SET EntityFactorCode1 = ISNULL(EntityFactorCodeOverride1,ClientFactorCode1), 
				EntityFactorDesc1 = ISNULL(EntityFactorDescOverride1,ClientFactorDesc1)			
			--set service level and interstate allocation pct
			UPDATE #temptbl SET AllocationPct1 = ISNULL(aap.AllocationPct,1), InterstateAllocationPct1 = ISNULL(aap.InterstateAllocationPct,1)
				FROM AssetAllocationPct AS aap
				RIGHT OUTER JOIN #temptbl ON aap.ClientId = #temptbl.ClientId AND aap.LocationId = #temptbl.LocationId
					AND aap.AssessmentId = #temptbl.AssessmentId AND aap.AssetId = #temptbl.AssetId
					AND aap.FactorEntityId = #temptbl.FactorEntityId1 AND aap.TaxYear = #temptbl.TaxYear
			


		END

		IF @FactorEntityExists2 = 1
		BEGIN
					--client gl mapping
			UPDATE #temptbl SET ClientMappingFactorCode2 = cx.FactorCode, ClientMappingFactorDesc2 = fec.Description
				FROM ClientGLCodeXRef AS cx
				INNER JOIN FactorEntityCodes AS fec ON cx.FactorEntityId = fec.FactorEntityId
					AND cx.FactorCode = fec.FactorCode AND cx.TaxYear = fec.TaxYear
				INNER JOIN #temptbl ON #temptbl.ClientId = cx.ClientId AND #temptbl.Locations_StateCd = cx.StateCd
					AND #temptbl.GLCode = cx.GLCode AND #temptbl.TaxYear = cx.TaxYear AND #temptbl.FactorEntityId2 = cx.FactorEntityId
			--client reclass (overrides client gl mapping)
			UPDATE #temptbl SET ClientMappingFactorCodeOverride2 = fec.FactorCode, ClientMappingFactorDescOverride2 = fec.Description				
				FROM FactorEntityCodes AS fec 
				INNER JOIN ClientFactorCodeOverrides AS cfc ON fec.FactorEntityId = cfc.FactorEntityId AND fec.FactorCode = cfc.FactorCode
					AND fec.TaxYear = cfc.TaxYear 
				WHERE cfc.ClientId = @ClientId AND cfc.LocationId = @LocationId AND cfc.AssessmentId = @AssessmentId AND cfc.TaxYear = @TaxYear
					AND cfc.FactorEntityId = #temptbl.FactorEntityId2 AND cfc.AssetId = #temptbl.AssetId
			--final client factor
			UPDATE #temptbl SET ClientFactorCode2 = ISNULL(ClientMappingFactorCodeOverride2,ClientMappingFactorCode2), 
				ClientFactorDesc2 = ISNULL(ClientMappingFactorDescOverride2,ClientMappingFactorDesc2)
			--entity factor override
			UPDATE #temptbl SET EntityFactorCodeOverride2 = fec.FactorCode, EntityFactorDescOverride2 = fec.Description				
				FROM FactorEntityCodes AS fec 
				INNER JOIN FactorCodeOverrides AS fc ON fec.FactorEntityId = fc.FactorEntityId AND fec.FactorCode = fc.FactorCode
					AND fec.TaxYear = fc.TaxYear 
				WHERE fc.ClientId = @ClientId AND fc.LocationId = @LocationId AND fc.AssessmentId = @AssessmentId AND fc.TaxYear = @TaxYear
					AND fc.FactorEntityId = #temptbl.FactorEntityId2 AND fc.AssetId = #temptbl.AssetId
			--final factor for county
			UPDATE #temptbl SET EntityFactorCode2 = ISNULL(EntityFactorCodeOverride2,ClientFactorCode2), 
				EntityFactorDesc2 = ISNULL(EntityFactorDescOverride2,ClientFactorDesc2)			
			--set service level and interstate allocation pct
			UPDATE #temptbl SET AllocationPct2 = ISNULL(aap.AllocationPct,1), InterstateAllocationPct2 = ISNULL(aap.InterstateAllocationPct,1)
				FROM AssetAllocationPct AS aap
				RIGHT OUTER JOIN #temptbl ON aap.ClientId = #temptbl.ClientId AND aap.LocationId = #temptbl.LocationId
					AND aap.AssessmentId = #temptbl.AssessmentId AND aap.AssetId = #temptbl.AssetId
					AND aap.FactorEntityId = #temptbl.FactorEntityId2 AND aap.TaxYear = #temptbl.TaxYear

		END

		IF @FactorEntityExists3 = 1
		BEGIN
					--client gl mapping
			UPDATE #temptbl SET ClientMappingFactorCode3 = cx.FactorCode, ClientMappingFactorDesc3 = fec.Description
				FROM ClientGLCodeXRef AS cx
				INNER JOIN FactorEntityCodes AS fec ON cx.FactorEntityId = fec.FactorEntityId
					AND cx.FactorCode = fec.FactorCode AND cx.TaxYear = fec.TaxYear
				INNER JOIN #temptbl ON #temptbl.ClientId = cx.ClientId AND #temptbl.Locations_StateCd = cx.StateCd
					AND #temptbl.GLCode = cx.GLCode AND #temptbl.TaxYear = cx.TaxYear AND #temptbl.FactorEntityId3 = cx.FactorEntityId
			--client reclass (overrides client gl mapping)
			UPDATE #temptbl SET ClientMappingFactorCodeOverride3 = fec.FactorCode, ClientMappingFactorDescOverride3 = fec.Description				
				FROM FactorEntityCodes AS fec 
				INNER JOIN ClientFactorCodeOverrides AS cfc ON fec.FactorEntityId = cfc.FactorEntityId AND fec.FactorCode = cfc.FactorCode
					AND fec.TaxYear = cfc.TaxYear 
				WHERE cfc.ClientId = @ClientId AND cfc.LocationId = @LocationId AND cfc.AssessmentId = @AssessmentId AND cfc.TaxYear = @TaxYear
					AND cfc.FactorEntityId = #temptbl.FactorEntityId3 AND cfc.AssetId = #temptbl.AssetId
			--final client factor
			UPDATE #temptbl SET ClientFactorCode3 = ISNULL(ClientMappingFactorCodeOverride3,ClientMappingFactorCode3), 
				ClientFactorDesc3 = ISNULL(ClientMappingFactorDescOverride3,ClientMappingFactorDesc3)
			--entity factor override
			UPDATE #temptbl SET EntityFactorCodeOverride3 = fec.FactorCode, EntityFactorDescOverride3 = fec.Description				
				FROM FactorEntityCodes AS fec 
				INNER JOIN FactorCodeOverrides AS fc ON fec.FactorEntityId = fc.FactorEntityId AND fec.FactorCode = fc.FactorCode
					AND fec.TaxYear = fc.TaxYear 
				WHERE fc.ClientId = @ClientId AND fc.LocationId = @LocationId AND fc.AssessmentId = @AssessmentId AND fc.TaxYear = @TaxYear
					AND fc.FactorEntityId = #temptbl.FactorEntityId3 AND fc.AssetId = #temptbl.AssetId
			--final factor for county
			UPDATE #temptbl SET EntityFactorCode3 = ISNULL(EntityFactorCodeOverride3,ClientFactorCode3), 
				EntityFactorDesc3 = ISNULL(EntityFactorDescOverride3,ClientFactorDesc3)			
			--set service level and interstate allocation pct
			UPDATE #temptbl SET AllocationPct3 = ISNULL(aap.AllocationPct,1), InterstateAllocationPct3 = ISNULL(aap.InterstateAllocationPct,1)
				FROM AssetAllocationPct AS aap
				RIGHT OUTER JOIN #temptbl ON aap.ClientId = #temptbl.ClientId AND aap.LocationId = #temptbl.LocationId
					AND aap.AssessmentId = #temptbl.AssessmentId AND aap.AssetId = #temptbl.AssetId
					AND aap.FactorEntityId = #temptbl.FactorEntityId3 AND aap.TaxYear = #temptbl.TaxYear


		END

		IF @FactorEntityExists4 = 1
		BEGIN
					--client gl mapping
			UPDATE #temptbl SET ClientMappingFactorCode4 = cx.FactorCode, ClientMappingFactorDesc4 = fec.Description
				FROM ClientGLCodeXRef AS cx
				INNER JOIN FactorEntityCodes AS fec ON cx.FactorEntityId = fec.FactorEntityId
					AND cx.FactorCode = fec.FactorCode AND cx.TaxYear = fec.TaxYear
				INNER JOIN #temptbl ON #temptbl.ClientId = cx.ClientId AND #temptbl.Locations_StateCd = cx.StateCd
					AND #temptbl.GLCode = cx.GLCode AND #temptbl.TaxYear = cx.TaxYear AND #temptbl.FactorEntityId4 = cx.FactorEntityId
			--client reclass (overrides client gl mapping)
			UPDATE #temptbl SET ClientMappingFactorCodeOverride4 = fec.FactorCode, ClientMappingFactorDescOverride4 = fec.Description				
				FROM FactorEntityCodes AS fec 
				INNER JOIN ClientFactorCodeOverrides AS cfc ON fec.FactorEntityId = cfc.FactorEntityId AND fec.FactorCode = cfc.FactorCode
					AND fec.TaxYear = cfc.TaxYear 
				WHERE cfc.ClientId = @ClientId AND cfc.LocationId = @LocationId AND cfc.AssessmentId = @AssessmentId AND cfc.TaxYear = @TaxYear
					AND cfc.FactorEntityId = #temptbl.FactorEntityId4 AND cfc.AssetId = #temptbl.AssetId
			--final client factor
			UPDATE #temptbl SET ClientFactorCode4 = ISNULL(ClientMappingFactorCodeOverride4,ClientMappingFactorCode4), 
				ClientFactorDesc4 = ISNULL(ClientMappingFactorDescOverride4,ClientMappingFactorDesc4)
			--entity factor override
			UPDATE #temptbl SET EntityFactorCodeOverride4 = fec.FactorCode, EntityFactorDescOverride4 = fec.Description				
				FROM FactorEntityCodes AS fec 
				INNER JOIN FactorCodeOverrides AS fc ON fec.FactorEntityId = fc.FactorEntityId AND fec.FactorCode = fc.FactorCode
					AND fec.TaxYear = fc.TaxYear 
				WHERE fc.ClientId = @ClientId AND fc.LocationId = @LocationId AND fc.AssessmentId = @AssessmentId AND fc.TaxYear = @TaxYear
					AND fc.FactorEntityId = #temptbl.FactorEntityId4 AND fc.AssetId = #temptbl.AssetId
			--final factor for county
			UPDATE #temptbl SET EntityFactorCode4 = ISNULL(EntityFactorCodeOverride4,ClientFactorCode4), 
				EntityFactorDesc4 = ISNULL(EntityFactorDescOverride4,ClientFactorDesc4)			
			--set service level and interstate allocation pct
			UPDATE #temptbl SET AllocationPct4 = ISNULL(aap.AllocationPct,1), InterstateAllocationPct4 = ISNULL(aap.InterstateAllocationPct,1)
				FROM AssetAllocationPct AS aap
				RIGHT OUTER JOIN #temptbl ON aap.ClientId = #temptbl.ClientId AND aap.LocationId = #temptbl.LocationId
					AND aap.AssessmentId = #temptbl.AssessmentId AND aap.AssetId = #temptbl.AssetId
					AND aap.FactorEntityId = #temptbl.FactorEntityId4 AND aap.TaxYear = #temptbl.TaxYear

		END

		IF @FactorEntityExists5 = 1
		BEGIN
					--client gl mapping
			UPDATE #temptbl SET ClientMappingFactorCode5 = cx.FactorCode, ClientMappingFactorDesc5 = fec.Description
				FROM ClientGLCodeXRef AS cx
				INNER JOIN FactorEntityCodes AS fec ON cx.FactorEntityId = fec.FactorEntityId
					AND cx.FactorCode = fec.FactorCode AND cx.TaxYear = fec.TaxYear
				INNER JOIN #temptbl ON #temptbl.ClientId = cx.ClientId AND #temptbl.Locations_StateCd = cx.StateCd
					AND #temptbl.GLCode = cx.GLCode AND #temptbl.TaxYear = cx.TaxYear AND #temptbl.FactorEntityId5 = cx.FactorEntityId
			--client reclass (overrides client gl mapping)
			UPDATE #temptbl SET ClientMappingFactorCodeOverride5 = fec.FactorCode, ClientMappingFactorDescOverride5 = fec.Description				
				FROM FactorEntityCodes AS fec 
				INNER JOIN ClientFactorCodeOverrides AS cfc ON fec.FactorEntityId = cfc.FactorEntityId AND fec.FactorCode = cfc.FactorCode
					AND fec.TaxYear = cfc.TaxYear 
				WHERE cfc.ClientId = @ClientId AND cfc.LocationId = @LocationId AND cfc.AssessmentId = @AssessmentId AND cfc.TaxYear = @TaxYear
					AND cfc.FactorEntityId = #temptbl.FactorEntityId5 AND cfc.AssetId = #temptbl.AssetId
			--final client factor
			UPDATE #temptbl SET ClientFactorCode5 = ISNULL(ClientMappingFactorCodeOverride5,ClientMappingFactorCode5), 
				ClientFactorDesc5 = ISNULL(ClientMappingFactorDescOverride5,ClientMappingFactorDesc5)
			--entity factor override
			UPDATE #temptbl SET EntityFactorCodeOverride5 = fec.FactorCode, EntityFactorDescOverride5 = fec.Description				
				FROM FactorEntityCodes AS fec 
				INNER JOIN FactorCodeOverrides AS fc ON fec.FactorEntityId = fc.FactorEntityId AND fec.FactorCode = fc.FactorCode
					AND fec.TaxYear = fc.TaxYear 
				WHERE fc.ClientId = @ClientId AND fc.LocationId = @LocationId AND fc.AssessmentId = @AssessmentId AND fc.TaxYear = @TaxYear
					AND fc.FactorEntityId = #temptbl.FactorEntityId5 AND fc.AssetId = #temptbl.AssetId
			--final factor for county
			UPDATE #temptbl SET EntityFactorCode5 = ISNULL(EntityFactorCodeOverride5,ClientFactorCode5), 
				EntityFactorDesc5 = ISNULL(EntityFactorDescOverride5,ClientFactorDesc5)			
			--set service level and interstate allocation pct
			UPDATE #temptbl SET AllocationPct5 = ISNULL(aap.AllocationPct,1), InterstateAllocationPct5 = ISNULL(aap.InterstateAllocationPct,1)
				FROM AssetAllocationPct AS aap
				RIGHT OUTER JOIN #temptbl ON aap.ClientId = #temptbl.ClientId AND aap.LocationId = #temptbl.LocationId
					AND aap.AssessmentId = #temptbl.AssessmentId AND aap.AssetId = #temptbl.AssetId
					AND aap.FactorEntityId = #temptbl.FactorEntityId5 AND aap.TaxYear = #temptbl.TaxYear

		END
		
		--set values
		IF @NeedFactoredAmounts = 1
		BEGIN
			IF @FactorEntityExists1 = 1
			BEGIN				
				UPDATE #temptbl SET ClientValue1 = ROUND(ISNULL(OriginalCost,0) * f.Percentage,0),
					ClientFactor1 = f.Percentage
				FROM #temptbl 				
				INNER JOIN Factors f
				ON f.FactorEntityId = #temptbl.FactorEntityId1 AND f.FactorCode = #temptbl.ClientFactorCode1
					AND f.TaxYear = #temptbl.TaxYear AND f.Age = @TaxYear - YEAR(#temptbl.PurchaseDate)		
				UPDATE #temptbl SET ClientValue1 = ROUND(ISNULL(OriginalCost,0) * ISNULL(f99.Percentage,0),0),
					ClientFactor1 = f99.Percentage
				FROM #temptbl 
				RIGHT OUTER JOIN Factors f99
				ON f99.FactorEntityId = #temptbl.FactorEntityId1 AND f99.FactorCode = #temptbl.ClientFactorCode1
					AND f99.TaxYear = #temptbl.TaxYear AND f99.Age = 99
				WHERE ClientFactor1 IS NULL
				UPDATE #temptbl SET EntityValue1 = ROUND(ISNULL(OriginalCost,0) * f.Percentage,0),
					EntityFactor1 = f.Percentage
				FROM #temptbl 				
				INNER JOIN Factors f
				ON f.FactorEntityId = #temptbl.FactorEntityId1 AND f.FactorCode = #temptbl.EntityFactorCode1
					AND f.TaxYear = #temptbl.TaxYear AND f.Age = @TaxYear - YEAR(#temptbl.PurchaseDate)		
				UPDATE #temptbl SET EntityValue1 = ROUND(ISNULL(OriginalCost,0) * ISNULL(f99.Percentage,0),0),
					EntityFactor1 = f99.Percentage
				FROM #temptbl 
				RIGHT OUTER JOIN Factors f99
				ON f99.FactorEntityId = #temptbl.FactorEntityId1 AND f99.FactorCode = #temptbl.EntityFactorCode1
					AND f99.TaxYear = #temptbl.TaxYear AND f99.Age = 99
				WHERE EntityFactor1 IS NULL
				UPDATE #temptbl SET ClientValue1 = 0 WHERE ClientValue1 IS NULL			
				UPDATE #temptbl SET ClientValue1 = ROUND(ClientValue1 * InterstateAllocationPct1,0) WHERE InterstateAllocationPct1 IS NOT NULL
					AND InterstateAllocationFl = 1
				UPDATE #temptbl SET EntityValue1 = 0 WHERE EntityValue1 IS NULL
				UPDATE #temptbl SET EntityValue1 = ROUND(EntityValue1 * AllocationPct1,0) WHERE AllocationPct1 IS NOT NULL
				UPDATE #temptbl SET EntityValue1 = ROUND(EntityValue1 * InterstateAllocationPct1,0) WHERE InterstateAllocationPct1 IS NOT NULL
			END

			IF @FactorEntityExists2 = 1
			BEGIN				
				UPDATE #temptbl SET ClientValue2 = ROUND(ISNULL(OriginalCost,0) * f.Percentage,0),
					ClientFactor2 = f.Percentage
				FROM #temptbl 				
				INNER JOIN Factors f
				ON f.FactorEntityId = #temptbl.FactorEntityId2 AND f.FactorCode = #temptbl.ClientFactorCode2
					AND f.TaxYear = #temptbl.TaxYear AND f.Age = @TaxYear - YEAR(#temptbl.PurchaseDate)		
				UPDATE #temptbl SET ClientValue2 = ROUND(ISNULL(OriginalCost,0) * ISNULL(f99.Percentage,0),0),
					ClientFactor2 = f99.Percentage
				FROM #temptbl 
				RIGHT OUTER JOIN Factors f99
				ON f99.FactorEntityId = #temptbl.FactorEntityId2 AND f99.FactorCode = #temptbl.ClientFactorCode2
					AND f99.TaxYear = #temptbl.TaxYear AND f99.Age = 99
				WHERE ClientFactor2 IS NULL
				UPDATE #temptbl SET EntityValue2 = ROUND(ISNULL(OriginalCost,0) * f.Percentage,0),
					EntityFactor2 = f.Percentage
				FROM #temptbl 				
				INNER JOIN Factors f
				ON f.FactorEntityId = #temptbl.FactorEntityId2 AND f.FactorCode = #temptbl.EntityFactorCode2
					AND f.TaxYear = #temptbl.TaxYear AND f.Age = @TaxYear - YEAR(#temptbl.PurchaseDate)		
				UPDATE #temptbl SET EntityValue2 = ROUND(ISNULL(OriginalCost,0) * ISNULL(f99.Percentage,0),0),
					EntityFactor2 = f99.Percentage
				FROM #temptbl 
				RIGHT OUTER JOIN Factors f99
				ON f99.FactorEntityId = #temptbl.FactorEntityId2 AND f99.FactorCode = #temptbl.EntityFactorCode2
					AND f99.TaxYear = #temptbl.TaxYear AND f99.Age = 99
				WHERE EntityFactor2 IS NULL
				UPDATE #temptbl SET ClientValue2 = 0 WHERE ClientValue2 IS NULL				
				UPDATE #temptbl SET ClientValue2 = ROUND(ClientValue2 * InterstateAllocationPct2,0) WHERE InterstateAllocationPct2 IS NOT NULL
					AND InterstateAllocationFl = 1
				UPDATE #temptbl SET EntityValue2 = 0 WHERE EntityValue2 IS NULL
				UPDATE #temptbl SET EntityValue2 = ROUND(EntityValue2 * AllocationPct2,0) WHERE AllocationPct2 IS NOT NULL
				UPDATE #temptbl SET EntityValue2 = ROUND(EntityValue2 * InterstateAllocationPct2,0) WHERE InterstateAllocationPct2 IS NOT NULL
			END

			IF @FactorEntityExists3 = 1
			BEGIN				
				UPDATE #temptbl SET ClientValue3 = ROUND(ISNULL(OriginalCost,0) * f.Percentage,0),
					ClientFactor3 = f.Percentage
				FROM #temptbl 				
				INNER JOIN Factors f
				ON f.FactorEntityId = #temptbl.FactorEntityId3 AND f.FactorCode = #temptbl.ClientFactorCode3
					AND f.TaxYear = #temptbl.TaxYear AND f.Age = @TaxYear - YEAR(#temptbl.PurchaseDate)		
				UPDATE #temptbl SET ClientValue3 = ROUND(ISNULL(OriginalCost,0) * ISNULL(f99.Percentage,0),0),
					ClientFactor3 = f99.Percentage
				FROM #temptbl 
				RIGHT OUTER JOIN Factors f99
				ON f99.FactorEntityId = #temptbl.FactorEntityId3 AND f99.FactorCode = #temptbl.ClientFactorCode3
					AND f99.TaxYear = #temptbl.TaxYear AND f99.Age = 99
				WHERE ClientFactor3 IS NULL
				UPDATE #temptbl SET EntityValue3 = ROUND(ISNULL(OriginalCost,0) * f.Percentage,0),
					EntityFactor3 = f.Percentage
				FROM #temptbl 				
				INNER JOIN Factors f
				ON f.FactorEntityId = #temptbl.FactorEntityId3 AND f.FactorCode = #temptbl.EntityFactorCode3
					AND f.TaxYear = #temptbl.TaxYear AND f.Age = @TaxYear - YEAR(#temptbl.PurchaseDate)		
				UPDATE #temptbl SET EntityValue3 = ROUND(ISNULL(OriginalCost,0) * ISNULL(f99.Percentage,0),0),
					EntityFactor3 = f99.Percentage
				FROM #temptbl 
				RIGHT OUTER JOIN Factors f99
				ON f99.FactorEntityId = #temptbl.FactorEntityId3 AND f99.FactorCode = #temptbl.EntityFactorCode3
					AND f99.TaxYear = #temptbl.TaxYear AND f99.Age = 99
				WHERE EntityFactor3 IS NULL
				UPDATE #temptbl SET ClientValue3 = 0 WHERE ClientValue3 IS NULL				
				UPDATE #temptbl SET ClientValue3 = ROUND(ClientValue3 * InterstateAllocationPct3,0) WHERE InterstateAllocationPct3 IS NOT NULL
					AND InterstateAllocationFl = 1
				UPDATE #temptbl SET EntityValue3 = 0 WHERE EntityValue3 IS NULL
				UPDATE #temptbl SET EntityValue3 = ROUND(EntityValue3 * AllocationPct3,0) WHERE AllocationPct3 IS NOT NULL
				UPDATE #temptbl SET EntityValue3 = ROUND(EntityValue3 * InterstateAllocationPct3,0) WHERE InterstateAllocationPct3 IS NOT NULL
			END

			IF @FactorEntityExists4 = 1
			BEGIN				
				UPDATE #temptbl SET ClientValue4 = ROUND(ISNULL(OriginalCost,0) * f.Percentage,0),
					ClientFactor4 = f.Percentage
				FROM #temptbl 				
				INNER JOIN Factors f
				ON f.FactorEntityId = #temptbl.FactorEntityId4 AND f.FactorCode = #temptbl.ClientFactorCode4
					AND f.TaxYear = #temptbl.TaxYear AND f.Age = @TaxYear - YEAR(#temptbl.PurchaseDate)		
				UPDATE #temptbl SET ClientValue4 = ROUND(ISNULL(OriginalCost,0) * ISNULL(f99.Percentage,0),0),
					ClientFactor4 = f99.Percentage
				FROM #temptbl 
				RIGHT OUTER JOIN Factors f99
				ON f99.FactorEntityId = #temptbl.FactorEntityId4 AND f99.FactorCode = #temptbl.ClientFactorCode4
					AND f99.TaxYear = #temptbl.TaxYear AND f99.Age = 99
				WHERE ClientFactor4 IS NULL
				UPDATE #temptbl SET EntityValue4 = ROUND(ISNULL(OriginalCost,0) * f.Percentage,0),
					EntityFactor4 = f.Percentage
				FROM #temptbl 				
				INNER JOIN Factors f
				ON f.FactorEntityId = #temptbl.FactorEntityId4 AND f.FactorCode = #temptbl.EntityFactorCode4
					AND f.TaxYear = #temptbl.TaxYear AND f.Age = @TaxYear - YEAR(#temptbl.PurchaseDate)		
				UPDATE #temptbl SET EntityValue4 = ROUND(ISNULL(OriginalCost,0) * ISNULL(f99.Percentage,0),0),
					EntityFactor4 = f99.Percentage
				FROM #temptbl 
				RIGHT OUTER JOIN Factors f99
				ON f99.FactorEntityId = #temptbl.FactorEntityId4 AND f99.FactorCode = #temptbl.EntityFactorCode4
					AND f99.TaxYear = #temptbl.TaxYear AND f99.Age = 99
				WHERE EntityFactor4 IS NULL
				UPDATE #temptbl SET ClientValue4 = 0 WHERE ClientValue4 IS NULL				
				UPDATE #temptbl SET ClientValue4 = ROUND(ClientValue4 * InterstateAllocationPct4,0) WHERE InterstateAllocationPct4 IS NOT NULL
					AND InterstateAllocationFl = 1
				UPDATE #temptbl SET EntityValue4 = 0 WHERE EntityValue4 IS NULL
				UPDATE #temptbl SET EntityValue4 = ROUND(EntityValue4 * AllocationPct4,0) WHERE AllocationPct4 IS NOT NULL
				UPDATE #temptbl SET EntityValue4 = ROUND(EntityValue4 * InterstateAllocationPct4,0) WHERE InterstateAllocationPct4 IS NOT NULL
			END

			IF @FactorEntityExists5 = 1
			BEGIN				
				UPDATE #temptbl SET ClientValue5 = ROUND(ISNULL(OriginalCost,0) * f.Percentage,0),
					ClientFactor5 = f.Percentage
				FROM #temptbl 				
				INNER JOIN Factors f
				ON f.FactorEntityId = #temptbl.FactorEntityId5 AND f.FactorCode = #temptbl.ClientFactorCode5
					AND f.TaxYear = #temptbl.TaxYear AND f.Age = @TaxYear - YEAR(#temptbl.PurchaseDate)		
				UPDATE #temptbl SET ClientValue5 = ROUND(ISNULL(OriginalCost,0) * ISNULL(f99.Percentage,0),0),
					ClientFactor5 = f99.Percentage
				FROM #temptbl 
				RIGHT OUTER JOIN Factors f99
				ON f99.FactorEntityId = #temptbl.FactorEntityId5 AND f99.FactorCode = #temptbl.ClientFactorCode5
					AND f99.TaxYear = #temptbl.TaxYear AND f99.Age = 99
				WHERE ClientFactor5 IS NULL
				UPDATE #temptbl SET EntityValue5 = ROUND(ISNULL(OriginalCost,0) * f.Percentage,0),
					EntityFactor5 = f.Percentage
				FROM #temptbl 				
				INNER JOIN Factors f
				ON f.FactorEntityId = #temptbl.FactorEntityId5 AND f.FactorCode = #temptbl.EntityFactorCode5
					AND f.TaxYear = #temptbl.TaxYear AND f.Age = @TaxYear - YEAR(#temptbl.PurchaseDate)		
				UPDATE #temptbl SET EntityValue5 = ROUND(ISNULL(OriginalCost,0) * ISNULL(f99.Percentage,0),0),
					EntityFactor5 = f99.Percentage
				FROM #temptbl 
				RIGHT OUTER JOIN Factors f99
				ON f99.FactorEntityId = #temptbl.FactorEntityId5 AND f99.FactorCode = #temptbl.EntityFactorCode5
					AND f99.TaxYear = #temptbl.TaxYear AND f99.Age = 99
				WHERE EntityFactor5 IS NULL
				UPDATE #temptbl SET ClientValue5 = 0 WHERE ClientValue5 IS NULL				
				UPDATE #temptbl SET ClientValue5 = ROUND(ClientValue5 * InterstateAllocationPct5,0) WHERE InterstateAllocationPct5 IS NOT NULL
					AND InterstateAllocationFl = 1
				UPDATE #temptbl SET EntityValue5 = 0 WHERE EntityValue5 IS NULL
				UPDATE #temptbl SET EntityValue5 = ROUND(EntityValue5 * AllocationPct5,0) WHERE AllocationPct5 IS NOT NULL
				UPDATE #temptbl SET EntityValue5 = ROUND(EntityValue5 * InterstateAllocationPct5,0) WHERE InterstateAllocationPct5 IS NOT NULL
			END

			IF @Accrual = 1
			BEGIN
				UPDATE #temptbl SET ClientValue1 = OriginalCost, EntityValue1 = OriginalCost
					WHERE GLCode IN('INV','Inventory') OR AssetId IN('INV','Inventory') OR [Description] IN('INV','Inventory')
			END 

			IF @NeedTotalValues = 1
				SELECT NULL AS ReturnTypeSumOfValues,
					ISNULL(SUM(ClientValue1),0) AS SumOfClientValue1, 
					ISNULL(SUM(ClientValue2),0) AS SumOfClientValue2, 
					ISNULL(SUM(ClientValue3),0) AS SumOfClientValue3, 
					ISNULL(SUM(ClientValue4),0) AS SumOfClientValue4, 
					ISNULL(SUM(ClientValue5),0) AS SumOfClientValue5, 
					ISNULL(SUM(EntityValue1),0) AS SumOfEntityValue1, 
					ISNULL(SUM(EntityValue2),0) AS SumOfEntityValue2, 
					ISNULL(SUM(EntityValue3),0) AS SumOfEntityValue3, 
					ISNULL(SUM(EntityValue4),0) AS SumOfEntityValue4, 
					ISNULL(SUM(EntityValue5),0) AS SumOfEntityValue5,
					ISNULL(SUM(OriginalCost),0) AS SumOfOriginalCost
				FROM #temptbl
		END

		--Remove unused columns
		IF @FactorEntityExists1 = 0
		BEGIN
			ALTER TABLE #temptbl DROP COLUMN 
				FactorEntityId1,
				FactoringEntityName1,
				ClientMappingFactorCode1,
				ClientMappingFactorDesc1,
				ClientMappingFactorCodeOverride1,
				ClientMappingFactorDescOverride1,
				ClientFactorCode1,
				ClientFactorDesc1,
				EntityFactorCodeOverride1,
				EntityFactorDescOverride1,
				EntityFactorCode1,
				EntityFactorDesc1,
				ClientFactor1,
				EntityFactor1,
				ClientValue1,
				EntityValue1,
				AllocationPct1,
				InterstateAllocationPct1
		END
		IF @FactorEntityExists2 = 0
		BEGIN
			ALTER TABLE #temptbl DROP COLUMN 
				FactorEntityId2,
				FactoringEntityName2,
				ClientMappingFactorCode2,
				ClientMappingFactorDesc2,
				ClientMappingFactorCodeOverride2,
				ClientMappingFactorDescOverride2,
				ClientFactorCode2,
				ClientFactorDesc2,
				EntityFactorCodeOverride2,
				EntityFactorDescOverride2,
				EntityFactorCode2,
				EntityFactorDesc2,
				ClientFactor2,
				EntityFactor2,
				ClientValue2,
				EntityValue2,
				AllocationPct2,
				InterstateAllocationPct2
		END
		IF @FactorEntityExists3 = 0
		BEGIN
			ALTER TABLE #temptbl DROP COLUMN 
				FactorEntityId3,
				FactoringEntityName3,
				ClientMappingFactorCode3,
				ClientMappingFactorDesc3,
				ClientMappingFactorCodeOverride3,
				ClientMappingFactorDescOverride3,
				ClientFactorCode3,
				ClientFactorDesc3,
				EntityFactorCodeOverride3,
				EntityFactorDescOverride3,
				EntityFactorCode3,
				EntityFactorDesc3,
				ClientFactor3,
				EntityFactor3,
				ClientValue3,
				EntityValue3,
				AllocationPct3,
				InterstateAllocationPct3
		END
		IF @FactorEntityExists4 = 0
		BEGIN
			ALTER TABLE #temptbl DROP COLUMN 
				FactorEntityId4,
				FactoringEntityName4,
				ClientMappingFactorCode4,
				ClientMappingFactorDesc4,
				ClientMappingFactorCodeOverride4,
				ClientMappingFactorDescOverride4,
				ClientFactorCode4,
				ClientFactorDesc4,
				EntityFactorCodeOverride4,
				EntityFactorDescOverride4,
				EntityFactorCode4,
				EntityFactorDesc4,
				ClientFactor4,
				EntityFactor4,
				ClientValue4,
				EntityValue4,
				AllocationPct4,
				InterstateAllocationPct4
		END
		IF @FactorEntityExists5 = 0
		BEGIN
			ALTER TABLE #temptbl DROP COLUMN 
				FactorEntityId5,
				FactoringEntityName5,
				ClientMappingFactorCode5,
				ClientMappingFactorDesc5,
				ClientMappingFactorCodeOverride5,
				ClientMappingFactorDescOverride5,
				ClientFactorCode5,
				ClientFactorDesc5,
				EntityFactorCodeOverride5,
				EntityFactorDescOverride5,
				EntityFactorCode5,
				EntityFactorDesc5,
				ClientFactor5,
				EntityFactor5,
				ClientValue5,
				EntityValue5,
				AllocationPct5,
				InterstateAllocationPct5
		END

		IF @FactorEntityExists1 = 1
		BEGIN
			IF ISNULL((SELECT COUNT(*) FROM #temptbl WHERE ISNULL(AllocationPct1,0) <> 1),0) = 0
				BEGIN
					ALTER TABLE #temptbl DROP COLUMN AllocationPct1
				END
			IF ISNULL((SELECT COUNT(*) FROM #temptbl WHERE ISNULL(InterstateAllocationPct1,0) <> 1),0) = 0
				BEGIN
					ALTER TABLE #temptbl DROP COLUMN InterstateAllocationPct1
				END
		END
		IF @FactorEntityExists2 = 1
		BEGIN
			IF ISNULL((SELECT COUNT(*) FROM #temptbl WHERE ISNULL(AllocationPct2,0) <> 1),0) = 0
				BEGIN
					ALTER TABLE #temptbl DROP COLUMN AllocationPct2
				END
			IF ISNULL((SELECT COUNT(*) FROM #temptbl WHERE ISNULL(InterstateAllocationPct2,0) <> 1),0) = 0
				BEGIN
					ALTER TABLE #temptbl DROP COLUMN InterstateAllocationPct2
				END
		END		
		IF @FactorEntityExists3 = 1
		BEGIN
			IF ISNULL((SELECT COUNT(*) FROM #temptbl WHERE ISNULL(AllocationPct3,0) <> 1),0) = 0
				BEGIN
					ALTER TABLE #temptbl DROP COLUMN AllocationPct3
				END
			IF ISNULL((SELECT COUNT(*) FROM #temptbl WHERE ISNULL(InterstateAllocationPct3,0) <> 1),0) = 0
				BEGIN
					ALTER TABLE #temptbl DROP COLUMN InterstateAllocationPct3
				END
		END
		IF @FactorEntityExists4 = 1
		BEGIN
			IF ISNULL((SELECT COUNT(*) FROM #temptbl WHERE ISNULL(AllocationPct4,0) <> 1),0) = 0
				BEGIN
					ALTER TABLE #temptbl DROP COLUMN AllocationPct4
				END
			IF ISNULL((SELECT COUNT(*) FROM #temptbl WHERE ISNULL(InterstateAllocationPct4,0) <> 1),0) = 0
				BEGIN
					ALTER TABLE #temptbl DROP COLUMN InterstateAllocationPct4
				END
		END
		IF @FactorEntityExists5 = 1
		BEGIN
			IF ISNULL((SELECT COUNT(*) FROM #temptbl WHERE ISNULL(AllocationPct5,0) <> 1),0) = 0
				BEGIN
					ALTER TABLE #temptbl DROP COLUMN AllocationPct5
				END
			IF ISNULL((SELECT COUNT(*) FROM #temptbl WHERE ISNULL(InterstateAllocationPct5,0) <> 1),0) = 0
				BEGIN
					ALTER TABLE #temptbl DROP COLUMN InterstateAllocationPct5
				END
		END

		IF ISNULL((SELECT COUNT(*) FROM #temptbl WHERE ISNULL(Assets_LocationAddress,'') <> ''),0) = 0
			BEGIN
				ALTER TABLE #temptbl DROP COLUMN Assets_LocationAddress
			END
		IF ISNULL((SELECT COUNT(*) FROM #temptbl WHERE ISNULL(VIN,'') <> ''),0) = 0
			BEGIN
				ALTER TABLE #temptbl DROP COLUMN VIN
			END
		IF ISNULL((SELECT COUNT(*) FROM #temptbl WHERE ISNULL(LeaseType,'') <> ''),0) = 0
			BEGIN
				ALTER TABLE #temptbl DROP COLUMN LeaseType, COLUMN LessorName, COLUMN LessorAddress, COLUMN LeaseTerm,
					COLUMN EquipmentMake, COLUMN EquipmentModel
			END
		IF ISNULL((SELECT COUNT(*) FROM #temptbl WHERE ISNULL(AuditFl,0) <> 0),0) = 0
			BEGIN
				ALTER TABLE #temptbl DROP COLUMN AuditFl
			END
		
		IF @NeedTotalOriginalCost = 1
			BEGIN
				SELECT NULL AS ReturnTypeSumOfOriginalCost, SUM(OriginalCost) AS SumOfOriginalCost FROM #temptbl
			END
		IF @NeedDetail = 1
			BEGIN
				SELECT NULL AS ReturnTypeDetail,* FROM #temptbl ORDER BY AssetId
			END
		IF @NeedFixedAndInv = 1
			BEGIN
				SELECT NULL AS ReturnTypeFixedAndInv, 
				(SELECT SUM(OriginalCost) FROM #temptbl WHERE GLCode IN('INV','Inventory') OR AssetId IN('INV','Inventory') OR [Description] IN('INV','Inventory'))
					AS SumOfInv,
				(SELECT SUM(OriginalCost) FROM #temptbl WHERE NOT (GLCode IN('INV','Inventory') OR AssetId IN('INV','Inventory') OR [Description] IN('INV','Inventory')))
					AS SumOfFixed
			END
	END
GO


