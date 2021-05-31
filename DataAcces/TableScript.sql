IF((select SCHEMA_NAME from INFORMATION_SCHEMA.SCHEMATA where SCHEMA_NAME = 'Pronto') IS NULL) 
BEGIN 
EXECUTE ('CREATE SCHEMA Pronto') 
END

GO

CREATE TABLE [Pronto].[Drivers]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[DriverName] nvarchar(255)
) ON [PRIMARY]
GO
ALTER TABLE [Pronto].[Drivers] ADD CONSTRAINT [PK_Drivers] PRIMARY KEY CLUSTERED  ([ID]) ON [PRIMARY]

GO


CREATE TABLE [Pronto].[Vehicle]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[LicensePlateId] nvarchar(100),
[TruckId] nvarchar(100)
) ON [PRIMARY]
GO
ALTER TABLE [Pronto].[Vehicle] ADD CONSTRAINT [PK_Vehicle] PRIMARY KEY CLUSTERED  ([ID]) ON [PRIMARY]

GO

CREATE TABLE [Pronto].[Helper]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[HelperName] nvarchar(255)

) ON [PRIMARY]
GO
ALTER TABLE [Pronto].[Helper] ADD CONSTRAINT [PK_Helper] PRIMARY KEY CLUSTERED  ([ID]) ON [PRIMARY]

GO


