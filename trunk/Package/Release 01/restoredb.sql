RESTORE DATABASE [csdl_qlks] FROM  DISK = N'csdl_qlks.bak' WITH  FILE = 1,  MOVE N'csdl_qlks' TO N'C:\csdl_qlks.mdf',  MOVE N'csdl_qlks_log' TO N'C:\csdl_qlks_log.ldf',  NOUNLOAD,  REPLACE,  STATS = 10
GO
