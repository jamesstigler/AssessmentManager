--2022.6 changes
-- Agencies
-- new client contact types


use AssessmentManagerData


CREATE TABLE [dbo].[Agencies](
	[AgencyId] [bigint] NOT NULL,
	[AgencyName] [varchar](255) NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUser] [varchar](30) NULL,
	[ChangeDate] [datetime] NULL,
	[ChangeUser] [varchar](30) NULL,
	[ChangeType] [tinyint] NULL,

 CONSTRAINT [PK_Agencies] PRIMARY KEY CLUSTERED 
(
	[AgencyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_Agencies] ON [dbo].[Agencies]
(
	[AgencyName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO

ALTER TABLE Clients add [AgencyId] [bigint] NULL
GO

ALTER TABLE [dbo].[Clients]  WITH CHECK ADD  CONSTRAINT [FK_Clients_Agencies] FOREIGN KEY([AgencyId])
REFERENCES [dbo].[Agencies] ([AgencyId])
GO

ALTER TABLE [dbo].[Clients] CHECK CONSTRAINT [FK_Clients_Agencies]
GO

ALTER TABLE [dbo].[Agencies] ADD  CONSTRAINT [DF_Agencies_AddDate]  DEFAULT (getdate()) FOR [AddDate]
GO

CREATE TABLE [dbo].[AgencyContacts](
	[AgencyId] [bigint] NOT NULL,
	[ContactType] [varchar](255) NOT NULL,
	[ContactName] [varchar](255) NOT NULL,
	[ContactAddress] [varchar](255) NULL,
	[ContactCity] [varchar](255) NULL,
	[ContactStateCd] [varchar](2) NULL,
	[ContactZip] [varchar](10) NULL,
	[ContactPhone] [varchar](50) NULL,
	[ContactEMail] [varchar](255) NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUser] [varchar](30) NULL,
	[ChangeDate] [datetime] NULL,
	[ChangeUser] [varchar](30) NULL,
	[ChangeType] [tinyint] NULL,
 CONSTRAINT [PK_AgencyContacts] PRIMARY KEY CLUSTERED 
(
	[AgencyId] ASC,
	[ContactType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[AgencyContacts] ADD  CONSTRAINT [DF_AgencyContacts_AddDate]  DEFAULT (getdate()) FOR [AddDate]
GO

ALTER TABLE [dbo].[AgencyContacts]  WITH CHECK ADD  CONSTRAINT [FK_AgencyContacts_AgencyContacts] FOREIGN KEY([AgencyId])
REFERENCES [dbo].[Agencies] ([AgencyId])
GO

ALTER TABLE [dbo].[AgencyContacts] CHECK CONSTRAINT [FK_AgencyContacts_AgencyContacts]
GO

exec sp_rename 'Clients.ContactInformationName','ContactBPPInfoName','column'
exec sp_rename 'Clients.ContactInformationAddress','ContactBPPInfoAddress','column'
exec sp_rename 'Clients.ContactInformationCity','ContactBPPInfoCity','column'
exec sp_rename 'Clients.ContactInformationStateCd','ContactBPPInfoStateCd','column'
exec sp_rename 'Clients.ContactInformationZip','ContactBPPInfoZip','column'
exec sp_rename 'Clients.ContactInformationPhone','ContactBPPInfoPhone','column'
exec sp_rename 'Clients.ContactInformationFax','ContactBPPInfoFax','column'
exec sp_rename 'Clients.ContactInformationEMail','ContactBPPInfoEMail','column'




ALTER TABLE Clients add [ContactAofAAuthorizationName] varchar(255) null
ALTER TABLE Clients add [ContactAofAAuthorizationAddress] varchar(255) null
ALTER TABLE Clients add [ContactAofAAuthorizationCity] varchar(255) null
ALTER TABLE Clients add [ContactAofAAuthorizationStateCd] char(2) null
ALTER TABLE Clients add [ContactAofAAuthorizationZip] varchar(10) null
ALTER TABLE Clients add [ContactAofAAuthorizationPhone] varchar(50) null
ALTER TABLE Clients add [ContactAofAAuthorizationFax] varchar(50) null
ALTER TABLE Clients add [ContactAofAAuthorizationEMail] varchar(255) null


ALTER TABLE Clients add [ContactAppealApprovalName] varchar(255) null
ALTER TABLE Clients add [ContactAppealApprovalAddress] varchar(255) null
ALTER TABLE Clients add [ContactAppealApprovalCity] varchar(255) null
ALTER TABLE Clients add [ContactAppealApprovalStateCd] char(2) null
ALTER TABLE Clients add [ContactAppealApprovalZip] varchar(10) null
ALTER TABLE Clients add [ContactAppealApprovalPhone] varchar(50) null
ALTER TABLE Clients add [ContactAppealApprovalFax] varchar(50) null
ALTER TABLE Clients add [ContactAppealApprovalEMail] varchar(255) null

ALTER TABLE Clients add [ContactREInfoName] varchar(255) null
ALTER TABLE Clients add [ContactREInfoAddress] varchar(255) null
ALTER TABLE Clients add [ContactREInfoCity]  varchar(255) null
ALTER TABLE Clients add [ContactREInfoStateCd] char(2) null
ALTER TABLE Clients add [ContactREInfoZip] varchar(10) null
ALTER TABLE Clients add [ContactREInfoPhone] varchar(50) null
ALTER TABLE Clients add [ContactREInfoFax] varchar(50) null
ALTER TABLE Clients add [ContactREInfoEMail] varchar(255) null

ALTER TABLE Clients add [ContactRenditionSignatureName]  varchar(255) null
ALTER TABLE Clients add [ContactRenditionSignatureAddress]  varchar(255) null
ALTER TABLE Clients add [ContactRenditionSignatureCity]  varchar(255) null
ALTER TABLE Clients add [ContactRenditionSignatureStateCd] char(2) null
ALTER TABLE Clients add [ContactRenditionSignatureZip] varchar(10) null
ALTER TABLE Clients add [ContactRenditionSignaturePhone] varchar(50) null
ALTER TABLE Clients add [ContactRenditionSignatureFax] varchar(50) null
ALTER TABLE Clients add [ContactRenditionSignatureEMail] varchar(255) null

ALTER TABLE Clients add [ContactReportsName]  varchar(255) null
ALTER TABLE Clients add [ContactReportsAddress]  varchar(255) null
ALTER TABLE Clients add [ContactReportsCity]  varchar(255) null
ALTER TABLE Clients add [ContactReportsStateCd] char(2) null 
ALTER TABLE Clients add [ContactReportsZip] varchar(10) null
ALTER TABLE Clients add [ContactReportsPhone] varchar(50) null
ALTER TABLE Clients add [ContactReportsFax] varchar(50) null
ALTER TABLE Clients add [ContactReportsEMail] varchar(255) null

ALTER TABLE Clients add [ContactTaxBillPaymentName]  varchar(255) null
ALTER TABLE Clients add [ContactTaxBillPaymentAddress]  varchar(255) null
ALTER TABLE Clients add [ContactTaxBillPaymentCity]  varchar(255) null
ALTER TABLE Clients add [ContactTaxBillPaymentStateCd] char(2) null
ALTER TABLE Clients add [ContactTaxBillPaymentZip] varchar(10) null
ALTER TABLE Clients add [ContactTaxBillPaymentPhone] varchar(50) null
ALTER TABLE Clients add [ContactTaxBillPaymentFax] varchar(50) null
ALTER TABLE Clients add [ContactTaxBillPaymentEMail] varchar(255) null

ALTER TABLE Clients add [ContactTaxBillTransmittalName]  varchar(255) null
ALTER TABLE Clients add [ContactTaxBillTransmittalAddress]  varchar(255) null
ALTER TABLE Clients add [ContactTaxBillTransmittalCity]  varchar(255) null
ALTER TABLE Clients add [ContactTaxBillTransmittalStateCd] char(2) null
ALTER TABLE Clients add [ContactTaxBillTransmittalZip] varchar(10) null
ALTER TABLE Clients add [ContactTaxBillTransmittalPhone] varchar(50) null
ALTER TABLE Clients add [ContactTaxBillTransmittalFax] varchar(50) null
ALTER TABLE Clients add [ContactTaxBillTransmittalEMail] varchar(255) null


ALTER TABLE AssessmentsBPP add [AgencyId] [bigint] NULL
GO
ALTER TABLE AssessmentsRE add [AgencyId] [bigint] NULL
GO
ALTER TABLE [dbo].[AssessmentsBPP]  WITH CHECK ADD  CONSTRAINT [FK_AssessmentsBPP_Agencies] FOREIGN KEY([AgencyId])
REFERENCES [dbo].[Agencies] ([AgencyId])
GO
ALTER TABLE [dbo].[AssessmentsRE]  WITH CHECK ADD  CONSTRAINT [FK_AssessmentsRE_Agencies] FOREIGN KEY([AgencyId])
REFERENCES [dbo].[Agencies] ([AgencyId])
GO
ALTER TABLE [dbo].[AssessmentsBPP] CHECK CONSTRAINT [FK_AssessmentsBPP_Agencies]
GO
ALTER TABLE [dbo].[AssessmentsRE] CHECK CONSTRAINT [FK_AssessmentsRE_Agencies]
GO




exec UpdateDataDefinition


delete FieldDataDefinition where TableName='AgencyContacts'
insert FieldDataDefinition (TableName,FieldName,FieldValue)
values ('AgencyContacts','ContactType','BPP Info'),
('AgencyContacts','ContactType','RE Info'),
('AgencyContacts','ContactType','AofA Authorization'),
('AgencyContacts','ContactType','Rendition Signature'),
('AgencyContacts','ContactType','Appeal Approval'),
('AgencyContacts','ContactType','Tax Bill Transmittal'),
('AgencyContacts','ContactType','Tax Bill Payment'),
('AgencyContacts','ContactType','Reports')


update UserQuerySelect set QueryField='ContactBPPInfoName' where QueryTable='Clients' and QueryField='ContactInformationName'
update UserQuerySelect set QueryField='ContactBPPInfoAddress'    where QueryTable='Clients' and QueryField='ContactInformationAddress'
update UserQuerySelect set QueryField='ContactBPPInfoCity'  where QueryTable='Clients' and QueryField='ContactInformationCity'
update UserQuerySelect set QueryField='ContactBPPInfoStateCd'  where QueryTable='Clients' and QueryField='ContactInformationStateCd'
update UserQuerySelect set QueryField='ContactBPPInfoZip'  where QueryTable='Clients' and QueryField='ContactInformationZip'
update UserQuerySelect set QueryField='ContactBPPInfoPhone' where QueryTable='Clients' and QueryField='ContactInformationPhone'
update UserQuerySelect set QueryField='ContactBPPInfoFax'  where QueryTable='Clients' and QueryField='ContactInformationFax'
update UserQuerySelect set QueryField='ContactBPPInfoEMail'  where QueryTable='Clients' and QueryField='ContactInformationEMail'

update FieldDefinition set QueryVisibleFl=1, QueryType=1 where TableName='Clients' and FieldName like 'ContactBPPInfo%'
update FieldDefinition set QueryVisibleFl=1, QueryType=1 where TableName='Clients' and FieldName like 'ContactAofAAuthorization%'
update FieldDefinition set QueryVisibleFl=1, QueryType=1 where TableName='Clients' and FieldName like 'ContactAppealApproval%'
update FieldDefinition set QueryVisibleFl=1, QueryType=1 where TableName='Clients' and FieldName like 'ContactREInfo%'
update FieldDefinition set QueryVisibleFl=1, QueryType=1 where TableName='Clients' and FieldName like 'ContactRenditionSignature%'
update FieldDefinition set QueryVisibleFl=1, QueryType=1 where TableName='Clients' and FieldName like 'ContactReports%'
update FieldDefinition set QueryVisibleFl=1, QueryType=1 where TableName='Clients' and FieldName like 'ContactTaxBillPayment%'
update FieldDefinition set QueryVisibleFl=1, QueryType=1 where TableName='Clients' and FieldName like 'ContactTaxBillTransmittal%'