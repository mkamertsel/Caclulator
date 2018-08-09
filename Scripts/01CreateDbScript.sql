USE [Master]
GO

DECLARE @dbname VARCHAR(15);
DECLARE @filepath VARCHAR(40);
SET @dbname = 'Calculator';
SET @filepath='D:\CalculatorDb\';
DECLARE @sql NVARCHAR(512);


if (DB_ID(@dbname) is not null)
begin

	PRINT N'Dropping ' + @dbname + ' ...';
	SET @sql = N'DROP DATABASE ' + @dbname;
    EXECUTE sp_executesql @sql;

end;

PRINT N'Creating [Calculator] db...';  
set @sql = N'
CREATE DATABASE ' + @dbname + '
    ON 
    PRIMARY(NAME = ' + @dbname + ', FILENAME = N''' + @filepath + @dbname + '.mdf'', size = 30MB , MAXSIZE = 1GB, FILEGROWTH = 10%)
    LOG ON (NAME = ' + @dbname + '_log, FILENAME = N''' + @filepath + @dbname + '_log.ldf'', size = 30MB , MAXSIZE = 2048GB , FILEGROWTH = 10%) 
	COLLATE SQL_Latin1_General_CP1_CI_AS';
execute sp_executesql @sql;

if (DB_ID(@dbname) is  null)
begin
    raiserror('ERROR! Cannot create database ''%s''', 10, 1, @dbname);
    set noexec on;
end;

PRINT N'CreateDB complete';

