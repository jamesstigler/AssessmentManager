USE [AssessmentManagerData]
GO

/****** Object:  StoredProcedure [dbo].[UpdateDataDefinition]    Script Date: 9/8/2015 11:34:44 AM ******/
DROP PROCEDURE [dbo].[UpdateDataDefinition]
GO

/****** Object:  StoredProcedure [dbo].[UpdateDataDefinition]    Script Date: 9/8/2015 11:34:44 AM ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO

/****** Object:  Stored Procedure dbo.UpdateDataDefinition    Script Date: 7/2/2008 4:19:29 PM ******/

CREATE proc [dbo].[UpdateDataDefinition]
	as

	set nocount on

	begin transaction

	DELETE FieldDefinition
	FROM FieldDefinition fd
	WHERE fd.FieldName NOT IN(SELECT c.name FROM sysobjects t, syscolumns c
				WHERE c.id = t.id
				AND t.type = 'U'
				AND t.name = fd.TableName)

	DELETE TableDefinition
	WHERE TableName NOT IN(SELECT name FROM sysobjects 
				WHERE type = 'U')
	
	commit transaction
	
	begin transaction

	INSERT TableDefinition (TableName) 
	SELECT t.name 
	FROM sysobjects t 
	WHERE t.type = 'U'
	AND t.name NOT IN('dtproperties')
	AND NOT EXISTS (SELECT tf.* FROM TableDefinition tf
					WHERE tf.TableName = t.name)
	
	INSERT FieldDefinition (TableName,FieldName) 
	SELECT t.name , c.name
	FROM sysobjects t, syscolumns c
	WHERE t.type = 'U'
	AND c.id = t.id
	AND t.name NOT IN('dtproperties')
	AND NOT EXISTS (SELECT fd.* FROM FieldDefinition fd
					WHERE fd.TableName = t.name
					AND fd.FieldName = c.name)
	
	commit transaction

	SELECT COUNT(TableName) FROM FieldDefinition
GO


