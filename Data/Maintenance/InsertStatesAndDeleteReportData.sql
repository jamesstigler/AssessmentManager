
use AssessmentManagerData
go

insert into States (StateCd,StateName) select 'AL','ALABAMA'
insert into States (StateCd,StateName) select 'AK','ALASKA'
insert into States (StateCd,StateName) select 'AZ','ARIZONA'
insert into States (StateCd,StateName) select 'AR','ARKANSAS'
insert into States (StateCd,StateName) select 'CA','CALIFORNIA'
insert into States (StateCd,StateName) select 'CD','CANADA'
insert into States (StateCd,StateName) select 'CO','COLORADO'
insert into States (StateCd,StateName) select 'CT','CONNECTICUT'
insert into States (StateCd,StateName) select 'DE','DELAWARE'
insert into States (StateCd,StateName) select 'DC','DISTRICT OF COLUMBIA'
insert into States (StateCd,StateName) select 'FL','FLORIDA'
insert into States (StateCd,StateName) select 'GA','GEORGIA'
insert into States (StateCd,StateName) select 'HI','HAWAII'
insert into States (StateCd,StateName) select 'ID','IDAHO'
insert into States (StateCd,StateName) select 'IL','ILLINOIS'
insert into States (StateCd,StateName) select 'IN','INDIANA'
insert into States (StateCd,StateName) select 'IA','IOWA'
insert into States (StateCd,StateName) select 'KS','KANSAS'
insert into States (StateCd,StateName) select 'KY','KENTUCKY'
insert into States (StateCd,StateName) select 'LA','LOUISIANA'
insert into States (StateCd,StateName) select 'ME','MAINE'
insert into States (StateCd,StateName) select 'MD','MARYLAND'
insert into States (StateCd,StateName) select 'MA','MASSACHUSETTS'
insert into States (StateCd,StateName) select 'MI','MICHIGAN'
insert into States (StateCd,StateName) select 'MN','MINNESOTA'
insert into States (StateCd,StateName) select 'MS','MISSISSIPPI'
insert into States (StateCd,StateName) select 'MO','MISSOURI'
insert into States (StateCd,StateName) select 'MT','MONTANA'
insert into States (StateCd,StateName) select 'NE','NEBRASKA'
insert into States (StateCd,StateName) select 'NV','NEVADA'
insert into States (StateCd,StateName) select 'NH','NEW HAMPSHIRE'
insert into States (StateCd,StateName) select 'NJ','NEW JERSEY'
insert into States (StateCd,StateName) select 'NM','NEW MEXICO'
insert into States (StateCd,StateName) select 'NY','NEW YORK'
insert into States (StateCd,StateName) select 'NC','NORTH CAROLINA'
insert into States (StateCd,StateName) select 'ND','NORTH DAKOTA'
insert into States (StateCd,StateName) select 'OH','OHIO'
insert into States (StateCd,StateName) select 'OK','OKLAHOMA'
insert into States (StateCd,StateName) select 'ON','ONTARIO'
insert into States (StateCd,StateName) select 'OR','OREGON'
insert into States (StateCd,StateName) select 'PA','PENNSYLVANIA'
insert into States (StateCd,StateName) select 'PR','PUERTO RICO'
insert into States (StateCd,StateName) select 'RI','RHODE ISLAND'
insert into States (StateCd,StateName) select 'SC','SOUTH CAROLINA'
insert into States (StateCd,StateName) select 'SD','SOUTH DAKOTA'
insert into States (StateCd,StateName) select 'TN','TENNESSEE'
insert into States (StateCd,StateName) select 'TX','TEXAS'
insert into States (StateCd,StateName) select 'UT','UTAH'
insert into States (StateCd,StateName) select 'VT','VERMONT'
insert into States (StateCd,StateName) select 'VA','VIRGINIA'
insert into States (StateCd,StateName) select 'WA','WASHINGTON'
insert into States (StateCd,StateName) select 'WV','WEST VIRGINIA'
insert into States (StateCd,StateName) select 'WI','WISCONSIN'
insert into States (StateCd,StateName) select 'WY','WYOMING'




USE [master]
GO

IF NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[spClearAMD]') 
AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql 
@statement = N'CREATE PROCEDURE [dbo].[spClearAMD]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DELETE FROM AssessmentManagerData.dbo.ReportData
	
END
' 
END
GO

EXEC sp_procoption N'[dbo].[spClearAMD]', 'startup', '1'

GO
