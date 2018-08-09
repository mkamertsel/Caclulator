USE [Calculator]
GO

PRINT 'Creating login...' ;

CREATE LOGIN calculator WITH PASSWORD = '1!password';
GO

DECLARE @calculatoruser VARCHAR(256);
DECLARE @sql NVARCHAR(512);
SET @calculatoruser='calculator';

PRINT N'Creating ' + @calculatoruser + ' ...';

IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'calculator')
BEGIN
    CREATE USER calculator FOR LOGIN calculator
    EXEC sp_addrolemember N'db_owner', N'calculator'
END;

GO