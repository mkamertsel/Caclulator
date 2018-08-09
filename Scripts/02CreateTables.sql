USE [Calculator];
GO

PRINT N'Creating Calc...';  
GO  
CREATE SCHEMA [Calc]  
    AUTHORIZATION [dbo];  
GO  
PRINT N'Creating Calc.Operation...';  
GO  
CREATE TABLE [Calc].[Operation] (  
    OperationId		INT           IDENTITY (1, 1) NOT NULL,  
    CalculatorId	INT			    NOT NULL,  
    OperationType	TINYINT         NOT NULL,
	FirstNumber		FLOAT			NOT NULL,  
	SecondNumber	FLOAT			NOT NULL ,
	CONSTRAINT PK_Operation PRIMARY KEY (OperationId)
);  
GO  
PRINT N'Creating Calc.Log...';  
GO  
CREATE TABLE [Calc].[Log] (  
    LogRecordId		INT      IDENTITY (1, 1) NOT NULL,  
    OperationTime	DATETIME		 NULL,  
    [Message]		VARCHAR(8000)	 NULL,  
    Exception		VARCHAR(8000)	 NULL,  
    StackTrace		VARCHAR(8000)    NULL,
	CONSTRAINT PK_Log PRIMARY KEY (LogRecordId)
);  
GO  