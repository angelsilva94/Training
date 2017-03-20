delete from Categories where 1=1
DBCC CHECKIDENT (Categories, RESEED, 0)