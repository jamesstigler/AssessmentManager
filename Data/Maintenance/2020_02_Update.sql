new spupdaterecompcodes stored proc
DCAD..spUpdateREComps


ALTER TABLE Assessors ADD 
REImportTypeCd smallint null

UPDATE Assessors SET REImportTypeCd = 1 WHERE AssessorId = 1697
exec UpdateDataDefinition

