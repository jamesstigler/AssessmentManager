install 64-bit version of new crystal reports, CRforVS_redist_install_64bit_13_0_23.zip

alter TABLE Clients add 
BPPConsultantName varchar(50), REConsultantName varchar(50), ClientCoordinatorName varchar(50)


update Clients set BPPConsultantName = ConsultantName, ClientCoordinatorName = ConsultantName


exec UpdateDataDefinition

update FieldDefinition set QueryType=4095, QueryVisibleFl=1 where TableName='Clients' and FieldName IN ('BPPConsultantName','REConsultantName','ClientCoordinatorName')
update FieldDefinition set QueryVisibleFl=0 where TableName='Clients' and FieldName='ConsultantName'


--run this to find any queries that contain Clients.ConsultantName in the OrderBy
SELECT [QueryName],[Description],QueryType,[AddUser],OrderBy   FROM [AssessmentManagerData].[dbo].[UserQuery]
where OrderBy like '%Clients.ConsultantName%'

--run update to replace old Clients.ConsultantName with ClientCoordinatorName
update UserQueryDetail set QueryField='Clients.ClientCoordinatorName' where QueryField='Clients.ConsultantName'
update UserQuerySelect set QueryField='ClientCoordinatorName' WHERE QueryField = 'ConsultantName' AND QueryTable = 'Clients'

