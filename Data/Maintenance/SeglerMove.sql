/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [Clients_Name]
      ,[Address]
      ,[Name]
      ,[City]
      ,[StateCd]
      ,[Assessors_Name]
      ,move.[AcctNum],b.TaxYear
  FROM [DataFixes].[dbo].[SeglerMove] move, AssessmentManagerData..AssessmentsBPP b
  where b.AcctNum=move.AcctNum and b.ClientId=471311013 and b.TaxYear=2018
