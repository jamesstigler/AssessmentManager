USE [AssessmentManagerData]
GO

IF OBJECT_ID('spCleanFileName') IS NOT NULL
BEGIN
    DROP PROCEDURE spCleanFileName
    IF OBJECT_ID('spCleanFileName') IS NOT NULL
        PRINT '<<< FAILED DROPPING PROCEDURE spCleanFileName >>>'
END
go

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

IF OBJECT_ID('spCleanFileName') IS NULL
    PRINT '<<< FAILED CREATING PROCEDURE spCleanFileName >>>'
go


