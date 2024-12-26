SELECT msysobjects.LvProp, " union select '"+[name]+"' as tablename, count(*) as countofrows from "+[name] AS SelectStmt, *
FROM msysobjects
WHERE (((msysobjects.LvProp) Is Not Null) AND ((msysobjects.type)=1) AND ((msysobjects.flags)=0));
