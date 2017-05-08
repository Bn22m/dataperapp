CREATE TABLE [scperson].[tbPerson] (
    [Identity]  INT           NOT NULL,
    [FirstName] NVARCHAR (20) NOT NULL,
    [Surname]   NVARCHAR (30) NULL,
    [Age]       INT           NULL,
    [Sex]       NVARCHAR (1)  NULL,
    [Mobile]    NVARCHAR (15) NULL,
    [Active]    NVARCHAR (6)  NULL,
    [Extra]     NVARCHAR (50) NULL
);

GO
ALTER TABLE [scperson].[tbPerson]
    ADD CONSTRAINT [PK_tbPerson] PRIMARY KEY CLUSTERED ([Identity] ASC);

GO
CREATE LOGIN [IIS APPPOOL\ASP.NET v4.0 Classic]
    FROM WINDOWS WITH DEFAULT_LANGUAGE = [us_english];

GO
CREATE LOGIN [newp2]
    WITH PASSWORD = N'pUgvz;|1x{}+eqr_tigxcjzlmsFT7_&#$!~<|kyPbhawc4dm';

GO
CREATE LOGIN [newp22]
    WITH PASSWORD = N'pgvMVz|xh{2enqrltwLUi@gxmsFT7_&#$!~<Jicj^zq|kNy}';

GO
CREATE USER [IIS APPPOOL\ASP.NET v4.0 Classic] FOR LOGIN [IIS APPPOOL\ASP.NET v4.0 Classic];

GO
CREATE USER [newp2] FOR LOGIN [newp2];

GO
CREATE USER [newp22] FOR LOGIN [newp22];

GO
ALTER ROLE [db_datareader] ADD MEMBER [newp2];

GO
ALTER ROLE [db_datareader] ADD MEMBER [IIS APPPOOL\ASP.NET v4.0 Classic];

GO
ALTER ROLE [db_datareader] ADD MEMBER [newp22];

GO
ALTER ROLE [db_datawriter] ADD MEMBER [newp2];

GO
ALTER ROLE [db_datawriter] ADD MEMBER [IIS APPPOOL\ASP.NET v4.0 Classic];

GO
ALTER ROLE [db_datawriter] ADD MEMBER [newp22];

GO
CREATE SCHEMA [scperson]
    AUTHORIZATION [dbo];

GO
GRANT ALTER TO [newp2]
    AS [dbo];

GO
GRANT CONNECT TO [IIS APPPOOL\ASP.NET v4.0 Classic]
    AS [dbo];

GO
GRANT CONNECT TO [newp2]
    AS [dbo];

GO
GRANT CONNECT TO [newp22]
    AS [dbo];

GO
GRANT CREATE TABLE TO [newp2]
    AS [dbo];

GO
GRANT CREATE TYPE TO [newp2]
    AS [dbo];

GO
GRANT CREATE VIEW TO [newp2]
    AS [dbo];

GO
GRANT CREATE XML SCHEMA COLLECTION TO [newp2]
    AS [dbo];

GO
GRANT DELETE TO [newp2]
    AS [dbo];

GO
GRANT DELETE
    ON OBJECT::[scperson].[tbPerson] TO [IIS APPPOOL\ASP.NET v4.0 Classic]
    AS [dbo];

GO
GRANT EXECUTE TO [newp2]
    AS [dbo];

GO
GRANT INSERT TO [newp2]
    AS [dbo];

GO
GRANT INSERT
    ON OBJECT::[scperson].[tbPerson] TO [IIS APPPOOL\ASP.NET v4.0 Classic]
    AS [dbo];

GO
GRANT REFERENCES
    ON OBJECT::[scperson].[tbPerson] TO [IIS APPPOOL\ASP.NET v4.0 Classic]
    AS [dbo];

GO
GRANT SELECT TO [newp2]
    AS [dbo];

GO
GRANT SELECT
    ON OBJECT::[scperson].[tbPerson] TO [IIS APPPOOL\ASP.NET v4.0 Classic]
    AS [dbo];

GO
GRANT UPDATE TO [newp2]
    AS [dbo];

GO
GRANT UPDATE
    ON OBJECT::[scperson].[tbPerson] TO [IIS APPPOOL\ASP.NET v4.0 Classic]
    AS [dbo];

GO
GRANT VIEW DATABASE STATE TO [newp2]
    AS [dbo];

GO
GRANT VIEW DEFINITION TO [newp2]
    AS [dbo];

GO
EXECUTE sp_addextendedproperty @name = N'scperson', @value = N'Contains objects related to details of the users.', @level0type = N'SCHEMA', @level0name = N'scperson';

GO
