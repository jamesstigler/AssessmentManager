EXEC sp_configure 'show advanced options', 1;
GO
RECONFIGURE;
GO

EXEC sp_configure 'xp_cmdshell',1
GO
RECONFIGURE
GO
--Now define that share drive for SQL with the xp_cmdshell command as follows:

EXEC XP_CMDSHELL 'net use g: \\vot-file\vantage /PERSISTENT:yes'
--It should now be mapped. In order to verify the new drive, you can use the below command that will show you all files in that newly mapped drive:

EXEC XP_CMDSHELL 'Dir g:' 