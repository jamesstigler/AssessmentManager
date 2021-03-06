SELECT    c1.ClientId, c1.Name,
	CommentList = 
	ISNULL(c1.Comment,'') + '  ' + substring((SELECT ( '  ' +  c2.Comment )
	FROM ClientComments c2
	WHERE c1.clientid = c2.clientid
	ORDER BY 
	c2.clientID,c2.AddDate
	FOR XML PATH(''),type).value('.','varchar(max)'),3,1000)
	
FROM Clients c1
where c1.ProspectFl=1
GROUP BY c1.ClientId, c1.Name,  c1.Comment
order by c1.Name