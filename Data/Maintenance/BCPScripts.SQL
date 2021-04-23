SELECT o.name,
'bcp AssessmentManagerData..' + o.name + ' out "c:\mytempfolder\' + o.name + '.dat" -T -S T5BVDIW10DV0095\SQLEXPRESS -c' AS OutgoingBCP, 
'delete ' + o.name AS DeleteTargetSQL,
'bcp AssessmentManagerData..' + o.name + ' in "c:\mytempfolder\' + o.name + '.dat" -U vantageoneuser -P Hobbes1234! -S vantagedb.ccromwqmpo9d.us-east-2.rds.amazonaws.com,1433  -c' AS IncomingBCP
from sysobjects o
where o.type = 'U' 
order by o.name