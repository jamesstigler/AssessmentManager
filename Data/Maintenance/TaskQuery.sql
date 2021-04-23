SELECT     tml.TaskId, tml.Name AS TaskName, tml.Description, tml.TaskDate, tml.Recurrence, te.TaskDate AS TaskEventDate, te.Comment, ta.Entity, ta.EntityId, 
                      ta.EntitySpecific
FROM         dbo.TaskMasterList AS tml INNER JOIN
                      dbo.TaskAssignment AS ta ON tml.TaskId = ta.TaskId LEFT OUTER JOIN
                      dbo.TaskEvents AS te ON ta.Entity = te.Entity AND ta.EntityId = te.EntityId AND tml.TaskId = te.TaskId
WHERE     (ta.Entity = 'Client') AND (ta.EntitySpecific = 1)


union 


SELECT     tml.TaskId, tml.Name AS TaskName, tml.Description, tml.TaskDate, tml.Recurrence, te.TaskDate AS TaskEventDate, te.Comment, ta.Entity, ta.EntityId, 
                      ta.EntitySpecific
FROM         dbo.TaskMasterList AS tml INNER JOIN
                      dbo.TaskAssignment AS ta ON tml.TaskId = ta.TaskId LEFT OUTER JOIN
                      dbo.TaskEvents AS te ON ta.Entity = te.Entity AND ta.EntityId = te.EntityId AND tml.TaskId = te.TaskId
WHERE     (ta.Entity = 'Client') AND (ta.EntitySpecific = 0)


