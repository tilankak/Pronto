IF((select SCHEMA_NAME from INFORMATION_SCHEMA.SCHEMATA where SCHEMA_NAME = 'Pronto') IS NULL) 
BEGIN 
EXECUTE ('CREATE SCHEMA Pronto') 
END

GO

CREATE TABLE [Pronto].[Drivers]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[DriverName] nvarchar(255),
[Active] bit DEFAULT 1
) ON [PRIMARY]
GO
ALTER TABLE [Pronto].[Drivers] ADD CONSTRAINT [PK_Drivers] PRIMARY KEY CLUSTERED  ([ID]) ON [PRIMARY]

GO


CREATE TABLE [Pronto].[Truck]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[TruckId] nvarchar(100),
[VehicleID]nvarchar(100) Not null,
[LicencePlateId]nvarchar(100) Not null,
[Active] bit DEFAULT 1
) ON [PRIMARY]
GO
ALTER TABLE [Pronto].[Truck] ADD CONSTRAINT [PK_Truck] PRIMARY KEY CLUSTERED  ([ID]) ON [PRIMARY]

GO

CREATE TABLE [Pronto].[Helper]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[HelperName] nvarchar(255),

[Active] bit DEFAULT 1

) ON [PRIMARY]
GO
ALTER TABLE [Pronto].[Helper] ADD CONSTRAINT [PK_Helper] PRIMARY KEY CLUSTERED  ([ID]) ON [PRIMARY]

GO


CREATE TABLE [Pronto].[Route]
(
[RootNo] [int] NOT NULL IDENTITY(1000001, 1),
[RouteDate] [datetime] not null,
[DriverID] [int] Not null,

[TruckId][int] Not null,
[DepatureTime] [datetime] not null,
[ArrivelTime] [datetime] not null,
[DepartureMilage] [int] not null default 0,
[ArrivelMilage] [int] not null default 0,
[RouteMlg]  as [ArrivelMilage]-[DepartureMilage],
[TotolCod] int not null default 0,
[CodDecrepency] int not null default 0,
[HotelInfo] nvarchar(255),
[HotelReceipt] nvarchar(255),
[BreakAStart] [datetime],
[BreakAEnd] [datetime],
[BreakBStart] [datetime],
[BreakBEnd] [datetime],
[LunchStart] [datetime],
[LunchEnd] [datetime],
[DinnerStart] [datetime],
[DinnerEnd] [datetime],
[DriverComments] Nvarchar(max)
) ON [PRIMARY]
GO
ALTER TABLE [Pronto].[Route] ADD CONSTRAINT [PK_Route] PRIMARY KEY CLUSTERED  ([RootNo]) ON [PRIMARY]

GO

CREATE TABLE [Pronto].[RouteHelpers]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[RouteId] int not null,
[HelperId] int not null,
) ON [PRIMARY]
GO
ALTER TABLE [Pronto].[RouteHelpers] ADD CONSTRAINT [PK_RouteHelpers] PRIMARY KEY CLUSTERED  ([ID]) ON [PRIMARY]

GO


CREATE TABLE [Pronto].[Customer]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[CustomerName] nvarchar(255),
[Active] bit DEFAULT 1
) ON [PRIMARY]
GO
ALTER TABLE [Pronto].[Customer] ADD CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED  ([ID]) ON [PRIMARY]

GO

CREATE TABLE [Pronto].[Service]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[ServiceType] nvarchar(60),
[Active] bit DEFAULT 1
) ON [PRIMARY]
GO
ALTER TABLE [Pronto].[Service] ADD CONSTRAINT [PK_Service] PRIMARY KEY CLUSTERED  ([ID]) ON [PRIMARY]

GO


CREATE TABLE [Pronto].[Stop]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[CustomerId] Int not null,
[ServiceId] int not null,
[RouteId] int not null,
[PtsId] nvarchar(60),
[ClientName] nvarchar(255),
[ClientAddr]nvarchar(255),
[ClientPh]nvarchar(60),
[QbDocNo]nvarchar(60),
[PadId]nvarchar(60),
[PhoneId]nvarchar(60),
[Eta]nvarchar(60),
[StopCodAmount] int,
[StopArrivalTime] datetime,
[StopDepartTime]datetime,
[StopMlgMeterRead] int,
[StopNote] nvarchar(max)

) ON [PRIMARY]
GO
ALTER TABLE [Pronto].[Stop] ADD CONSTRAINT [PK_Stop] PRIMARY KEY CLUSTERED  ([ID]) ON [PRIMARY]

GO


CREATE FUNCTION [Pronto].[GetHelpers] (
	@RouteId INT
	
	
	)
RETURNS NVARCHAR(max)
AS
BEGIN

DECLARE @listStr VARCHAR(MAX)

SELECT @listStr = COALESCE(@listStr+', ' ,'') +   HL.HelperName FROM Pronto.RouteHelpers H 
JOIN Pronto.Helper HL ON HL.ID = H.HelperId
WHERE H.RouteId = @RouteId

RETURN  @liststr
END
GO


CREATE FUNCTION [Pronto].[GetCustomer] (
	@RouteId INT
	
	
	)
RETURNS NVARCHAR(max)
AS
BEGIN

DECLARE @listStr VARCHAR(MAX)

SELECT @listStr = COALESCE(@listStr+', ' ,'') +C.CustomerName
FROM Pronto.Stop S
JOIN Pronto.Customer C ON S.CustomerId = C.ID
--JOIN Pronto.Service SV ON S.ServiceId = SV.ID
WHERE S.RouteId = @RouteId

RETURN  @liststr
END
GO

CREATE FUNCTION [Pronto].[GetServices] (
	@RouteId INT
	
	
	)
RETURNS NVARCHAR(max)
AS
BEGIN

DECLARE @listStr VARCHAR(MAX)

SELECT @listStr = COALESCE(@listStr+', ' ,'') + Sv.ServiceType
FROM Pronto.Stop S
--JOIN Pronto.Customer C ON S.CustomerId = C.ID
JOIN Pronto.Service SV ON S.ServiceId = SV.ID
WHERE S.RouteId = @RouteId

RETURN  @liststr
END
GO


CREATE FUNCTION [Pronto].[GetClients] (
	@RouteId INT
	
	
	)
RETURNS NVARCHAR(max)
AS
BEGIN

DECLARE @listStr VARCHAR(MAX)

SELECT @listStr = COALESCE(@listStr+', ' ,'') + s.ClientName
FROM Pronto.Stop S
--JOIN Pronto.Customer C ON S.CustomerId = C.ID
--JOIN Pronto.Service SV ON S.ServiceId = SV.ID
WHERE S.RouteId = @RouteId

RETURN  @liststr
END
GO

CREATE FUNCTION [Pronto].[GetPtsId] (
	@RouteId INT
	
	
	)
RETURNS NVARCHAR(max)
AS
BEGIN

DECLARE @listStr VARCHAR(MAX)

SELECT @listStr = COALESCE(@listStr+', ' ,'') + s.PtsId
FROM Pronto.Stop S
--JOIN Pronto.Customer C ON S.CustomerId = C.ID
--JOIN Pronto.Service SV ON S.ServiceId = SV.ID
WHERE S.RouteId = @RouteId

RETURN  @liststr
END
GO

CREATE TABLE [Pronto].[Users]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[UserName] nvarchar(60) not null,
[LoginType] int not null,
[Password] nvarchar(255),
[Active] bit DEFAULT 1


) ON [PRIMARY]
GO
ALTER TABLE [Pronto].[Users] ADD CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED  ([ID]) ON [PRIMARY]

GO

INSERT INTO [Pronto].[Users]([UserName] ,[LoginType],[Password]) 
VALUES 
('Administrator',0,'Administrator@#')
,('User1',1,'User1#@')
,('Median1',2,'Median1#@')



--ALTER TABLE [Pronto].[Drivers]
--ADD [Active] bit DEFAULT 1;

--ALTER TABLE [Pronto].[Customer]
--ADD [Active] bit DEFAULT 1;

--ALTER TABLE [Pronto].[Helper]
--ADD [Active] bit DEFAULT 1;

--ALTER TABLE [Pronto].[Truck]
--ADD [Active] bit DEFAULT 1;

--ALTER TABLE [Pronto].[Users]
--ADD [Active] bit DEFAULT 1;

--ALTER TABLE [Pronto].[Service]
--ADD [Active] bit DEFAULT 1;


--UPDATE [Pronto].[Drivers]
--SET [Active] = 1;

--UPDATE [Pronto].[Customer]
--SET [Active] = 1;

--UPDATE [Pronto].[Helper]
--SET [Active] = 1;

--UPDATE [Pronto].[Truck]
--SET [Active] = 1;

--UPDATE [Pronto].[Users]
--SET [Active] = 1;

--UPDATE [Pronto].[Service]
--SET [Active] = 1;


--ALTER TABLE [Pronto].[Truck]
--ADD [VehicleID]nvarchar(100) ,
--[LicencePlateId]nvarchar(100) 


--ALTER TABLE [Pronto].[Route]
--DROP COLUMN [VehicleID],[LicencePlateId]

--ALTER TABLE [Pronto].[Truck]
--ADD [VehicleID]nvarchar(100) ,


--ALTER TABLE [Pronto].[Stop]
--ADD [StopNote] nvarchar(max) 


ALTER TABLE [Pronto].[Drivers] ADD  CONSTRAINT [IX_DriverName] UNIQUE NONCLUSTERED 
(
    [DriverName] ASC
)

ALTER TABLE [Pronto].[Truck] ADD  CONSTRAINT [IX_TruckId] UNIQUE NONCLUSTERED 
(
    [TruckId] ASC
)


ALTER TABLE [Pronto].[Customer] ADD  CONSTRAINT [IX_CustomerName] UNIQUE NONCLUSTERED 
(
    [CustomerName] ASC
)

ALTER TABLE [Pronto].[Helper] ADD  CONSTRAINT [IX_HelperName] UNIQUE NONCLUSTERED 
(
    [HelperName] ASC
)

ALTER TABLE [Pronto].[Service] ADD  CONSTRAINT [IX_ServiceType] UNIQUE NONCLUSTERED 
(
    [ServiceType] ASC
)


ALTER TABLE [Pronto].[stop] 
ADD 
ClientCity nvarchar(100) ,
ClientZipCode nvarchar (100) ,
ClientState nvarchar (100)
GO


CREATE FUNCTION [Pronto].[GetClientPh] (
	@RouteId INT
	
	
	)
RETURNS NVARCHAR(max)
AS
BEGIN

DECLARE @listStr VARCHAR(MAX)

SELECT @listStr = COALESCE(@listStr+', ' ,'') + s.ClientPh
FROM Pronto.Stop S
--JOIN Pronto.Customer C ON S.CustomerId = C.ID
--JOIN Pronto.Service SV ON S.ServiceId = SV.ID
WHERE S.RouteId = @RouteId

RETURN  @liststr
END
GO

CREATE FUNCTION [Pronto].[GetClientZip] (
	@RouteId INT
	
	
	)
RETURNS NVARCHAR(max)
AS
BEGIN

DECLARE @listStr VARCHAR(MAX)

SELECT @listStr = COALESCE(@listStr+', ' ,'') + s.ClientZipCode
FROM Pronto.Stop S
--JOIN Pronto.Customer C ON S.CustomerId = C.ID
--JOIN Pronto.Service SV ON S.ServiceId = SV.ID
WHERE S.RouteId = @RouteId

RETURN  @liststr
END
GO


CREATE FUNCTION [Pronto].[GetClientCity] (
	@RouteId INT
	
	
	)
RETURNS NVARCHAR(max)
AS
BEGIN

DECLARE @listStr VARCHAR(MAX)

SELECT @listStr = COALESCE(@listStr+', ' ,'') + s.ClientCity
FROM Pronto.Stop S
--JOIN Pronto.Customer C ON S.CustomerId = C.ID
--JOIN Pronto.Service SV ON S.ServiceId = SV.ID
WHERE S.RouteId = @RouteId

RETURN  @liststr
END
GO