SELECT 'BPP' as PropType,    tml.TaskId, tml.Name, tml.Description, tml.TaskDate, 
ta.EntitySpecific, te.ClientId, te.TaskDate AS TaskEventDate, 
te.Comment, ta.ClientId AS Expr1, l.Clients_Name, l.TaxYear, 
l.Address, l.Locations_Name, l.LocationId
FROM         dbo.TaskMasterList AS tml INNER JOIN
                      dbo.TaskAssignmentsBPP AS ta ON tml.TaskId = ta.TaskId INNER JOIN
                          (SELECT     c.Name AS Clients_Name, l2.TaxYear, l2.Address, l2.Name AS Locations_Name, l2.City, l2.StateCd, l2.Zip, l2.ClientId, l2.LocationId
                            FROM          dbo.Clients AS c INNER JOIN
                                                   dbo.LocationsBPP AS l2 ON c.ClientId = l2.ClientId
                            WHERE      (l2.TaxYear = 2009)) AS l ON ta.ClientId = l.ClientId LEFT OUTER JOIN
                      dbo.TaskEventsBPP AS te ON ta.TaskId = te.TaskId AND l.ClientId = te.ClientId AND l.LocationId = te.LocationId
union                     
SELECT null as PropType,   tml.TaskId, tml.Name, tml.Description, tml.TaskDate, 
NULL as EntitySpecific, te.ClientId, te.TaskDate AS TaskEventDate, 
te.Comment, ta.ClientId AS Expr1, c.Name AS Clients_Name,NULL as TaxYear,
Null as Address,null as Locations_Name,null as LocationId
FROM         dbo.TaskMasterList AS tml INNER JOIN
                      dbo.TaskAssignments AS ta ON tml.TaskId = ta.TaskId INNER JOIN
                      dbo.Clients AS c ON ta.ClientId = c.ClientId LEFT OUTER JOIN
                      dbo.TaskEvents AS te ON ta.ClientId = te.ClientId AND ta.TaskId = te.TaskId
                      
union                      
SELECT 'RE' as PropType,    tml.TaskId, tml.Name, tml.Description, tml.TaskDate, 
ta.EntitySpecific, te.ClientId, te.TaskDate AS TaskEventDate, 
te.Comment, ta.ClientId AS Expr1, l.Clients_Name, l.TaxYear, 
l.Address, l.Locations_Name, l.LocationId
FROM         dbo.TaskMasterList AS tml INNER JOIN
                      dbo.TaskAssignmentsRE AS ta ON tml.TaskId = ta.TaskId INNER JOIN
                          (SELECT     c.Name AS Clients_Name, l2.TaxYear, l2.Address, l2.Name AS Locations_Name, l2.City, l2.StateCd, l2.Zip, l2.ClientId, l2.LocationId
                            FROM          dbo.Clients AS c INNER JOIN
                                                   dbo.LocationsRE AS l2 ON c.ClientId = l2.ClientId
                            WHERE      (l2.TaxYear = 2009)) AS l ON ta.ClientId = l.ClientId LEFT OUTER JOIN
                      dbo.TaskEventsRE AS te ON ta.TaskId = te.TaskId AND l.ClientId = te.ClientId AND l.LocationId = te.LocationId                                            