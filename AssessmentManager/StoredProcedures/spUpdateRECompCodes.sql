DROP PROCEDURE [dbo].[spUpdateRECompCodes] 
GO

CREATE PROCEDURE spUpdateRECompCodes
	@AssessorId bigint,
	@TaxYear smallint,
	@AddUser varchar(30)
	 
AS
	BEGIN
		DELETE RECompCodes WHERE AssessorId = @AssessorId AND TaxYear = @TaxYear
		
		INSERT RECompCodes (AssessorId, TaxYear, CodeValue, FieldName, AddUser)
		SELECT DISTINCT r.AssessorId, r.TaxYear, r.BuildingClass, 'BuildingClass', @AddUser
		FROM REComps r 
		WHERE r.AssessorId = @AssessorId AND r.TaxYear = @TaxYear
			AND ISNULL(r.BuildingClass,'') <> ''
			AND NOT EXISTS (SELECT rcc.AssessorId FROM RECompCodes rcc 
				WHERE rcc.AssessorId = r.AssessorId AND rcc.TaxYear = r.TaxYear 
				AND rcc.CodeValue = r.BuildingClass AND rcc.FieldName = 'BuildingClass')

		INSERT RECompCodes (AssessorId, TaxYear, CodeValue, FieldName, AddUser)
		SELECT DISTINCT r.AssessorId, r.TaxYear, r.ComparabilityCode, 'ComparabilityCode', @AddUser
		FROM REComps r 
		WHERE r.AssessorId = @AssessorId AND r.TaxYear = @TaxYear
			AND ISNULL(r.ComparabilityCode,'') <> ''
			AND NOT EXISTS (SELECT rcc.AssessorId FROM RECompCodes rcc 
				WHERE rcc.AssessorId = r.AssessorId AND rcc.TaxYear = r.TaxYear 
				AND rcc.CodeValue = r.ComparabilityCode AND rcc.FieldName = 'ComparabilityCode')

		INSERT RECompCodes (AssessorId, TaxYear, CodeValue, FieldName, AddUser)
		SELECT DISTINCT r.AssessorId, r.TaxYear, r.ConstructionType, 'ConstructionType', @AddUser
		FROM REComps r 
		WHERE r.AssessorId = @AssessorId AND r.TaxYear = @TaxYear
			AND ISNULL(r.ConstructionType,'') <> ''
			AND NOT EXISTS (SELECT rcc.AssessorId FROM RECompCodes rcc 
				WHERE rcc.AssessorId = r.AssessorId AND rcc.TaxYear = r.TaxYear 
				AND rcc.CodeValue = r.ConstructionType AND rcc.FieldName = 'ConstructionType')

		INSERT RECompCodes (AssessorId, TaxYear, CodeValue, FieldName, AddUser)
		SELECT DISTINCT r.AssessorId, r.TaxYear, r.AppraisalMethod, 'AppraisalMethod', @AddUser
		FROM REComps r 
		WHERE r.AssessorId = @AssessorId AND r.TaxYear = @TaxYear
			AND ISNULL(r.AppraisalMethod,'') <> ''
			AND NOT EXISTS (SELECT rcc.AssessorId FROM RECompCodes rcc 
				WHERE rcc.AssessorId = r.AssessorId AND rcc.TaxYear = r.TaxYear 
				AND rcc.CodeValue = r.AppraisalMethod AND rcc.FieldName = 'AppraisalMethod')

		INSERT RECompCodes (AssessorId, TaxYear, CodeValue, FieldName, AddUser)
		SELECT DISTINCT r.AssessorId, r.TaxYear, r.PricingMethod, 'PricingMethod', @AddUser
		FROM REComps r 
		WHERE r.AssessorId = @AssessorId AND r.TaxYear = @TaxYear
			AND ISNULL(r.PricingMethod,'') <> ''
			AND NOT EXISTS (SELECT rcc.AssessorId FROM RECompCodes rcc 
				WHERE rcc.AssessorId = r.AssessorId AND rcc.TaxYear = r.TaxYear 
				AND rcc.CodeValue = r.PricingMethod AND rcc.FieldName = 'PricingMethod')

	END

GO


