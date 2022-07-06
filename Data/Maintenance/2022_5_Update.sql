--2022.5 changes
--new RE datapoints (building type, class, sqft, yearbuilt, etc)
--roll rendition comments
--allow asset service level to be over 100%
--print rendition batch pages in different order
--new activity quantity for engine hours/mileage for assets


--  ***********      spgetassetlist has been updated   **************

use AssessmentManagerData

alter table Assessors add ValueProtestAddress varchar(255) null, ValueProtestCity varchar(255) null,ValueProtestStateCd varchar(2) null,
	ValueProtestZip varchar(10) null

alter table AssessmentsRE add BuildingType varchar(255) null, BuildingClass varchar(255) null, BuildingSqFt bigint null, NetLeasableSqFt bigint null,
	GrossLeasableSqFt bigint null, YearBuilt int null, EffYearBuilt int null, LandSqFt bigint null, ExcessLandSqFt bigint null,
	ConstructionType varchar(255)

alter table Assets add ActivityQty bigint null

exec UpdateDataDefinition

--update FieldDefinition set QueryVisibleFl=1, QueryType=504
--where TableName='Assessors' and FieldName in ('ValueProtestAddress','ValueProtestCity','ValueProtestStateCd','ValueProtestZip')

update FieldDefinition set QueryVisibleFl=1, QueryType=432
where TableName='AssessmentsRE' 
and FieldName in ('BuildingType','BuildingClass','BuildingSqFt','NetLeasableSqFt','GrossLeasableSqFt','YearBuilt','EffYearBuilt',
'LandSqFt','ExcessLandSqFt','ConstructionType')


delete FieldDataDefinition where TableName='AssessmentsRE' and FieldName in ('BuildingType','BuildingClass','ConstructionType')
insert FieldDataDefinition (TableName,FieldName,FieldValue) values 
('AssessmentsRE','BuildingType','Office')
,('AssessmentsRE','BuildingType','Medical Office')
,('AssessmentsRE','BuildingType','Apartment')
,('AssessmentsRE','BuildingType','Warehouse')
,('AssessmentsRE','BuildingType','Office Showroom')
,('AssessmentsRE','BuildingType','Mini/Boat RV Storage')
,('AssessmentsRE','BuildingType','Automotive Service')
,('AssessmentsRE','BuildingType','Complex Industrial')
,('AssessmentsRE','BuildingType','Manufacturing')
,('AssessmentsRE','BuildingType','Auto Dealership')
,('AssessmentsRE','BuildingType','Freestanding Retail')
,('AssessmentsRE','BuildingType','Retail Strip Center')
,('AssessmentsRE','BuildingType','Senior Living')
,('AssessmentsRE','BuildingType','Hospitality')
,('AssessmentsRE','BuildingType','Residential')
,('AssessmentsRE','BuildingType','Land Only')
,('AssessmentsRE','BuildingType','Land AG')
,('AssessmentsRE','BuildingClass','A+')
,('AssessmentsRE','BuildingClass','A')
,('AssessmentsRE','BuildingClass','A-')
,('AssessmentsRE','BuildingClass','B+')
,('AssessmentsRE','BuildingClass','B')
,('AssessmentsRE','BuildingClass','B-')
,('AssessmentsRE','BuildingClass','C+')
,('AssessmentsRE','BuildingClass','C')
,('AssessmentsRE','BuildingClass','C-')
,('AssessmentsRE','BuildingClass','R')
,('AssessmentsRE','BuildingClass','S')
,('AssessmentsRE','ConstructionType','Fireproofed Steel')
,('AssessmentsRE','ConstructionType','Masonry Bearing')
,('AssessmentsRE','ConstructionType','Mobile Home')
,('AssessmentsRE','ConstructionType','Open Steel Skeleton')
,('AssessmentsRE','ConstructionType','Reinforced Concrete')
,('AssessmentsRE','ConstructionType','Residential')
,('AssessmentsRE','ConstructionType','Storage Tank')
,('AssessmentsRE','ConstructionType','Wood or Light Steel')
,('AssessmentsRE','ConstructionType','Multiple Types')

