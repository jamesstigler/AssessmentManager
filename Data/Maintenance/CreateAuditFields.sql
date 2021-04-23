CREATE TABLE Table
(
Id bigint not null PRIMARY KEY CLUSTERED,
AddDate datetime NOT NULL Default GETDATE(),
AddUser varchar (30) null,
ChangeDate datetime null,
ChangeUser varchar (30) null,
ChangeType tinyint null
)	

