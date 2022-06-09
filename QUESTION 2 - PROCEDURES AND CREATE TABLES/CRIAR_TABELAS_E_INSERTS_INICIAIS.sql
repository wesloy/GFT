USE [TEST]

CREATE TABLE [CategoryRisk] (
    [id]           INT  IDENTITY (1, 1) NOT NULL,    
    [Risk] NVARCHAR(25) NOT NULL UNIQUE,
    CONSTRAINT [PK_CategoryRisk] PRIMARY KEY CLUSTERED ([id] ASC)
)

GO

INSERT INTO [CategoryRisk]([Risk]) VALUES ('LOWRISK')
INSERT INTO [CategoryRisk]([Risk]) VALUES ('MEDIUMRISK')
INSERT INTO [CategoryRisk]([Risk]) VALUES ('HIGHRISK')
INSERT INTO [CategoryRisk]([Risk]) VALUES ('NO RISK VALIDATION RULES')

GO

CREATE TABLE [ClientSector] (
    [id]           INT  IDENTITY (1, 1) NOT NULL,    
    [Sector] NVARCHAR(20) NOT NULL UNIQUE,
    CONSTRAINT [PK_ClientSector] PRIMARY KEY CLUSTERED ([id] ASC)
)

GO

INSERT INTO [ClientSector]([Sector]) VALUES ('PRIVATE')
INSERT INTO [ClientSector]([Sector]) VALUES ('PUBLIC')


GO

CREATE TABLE [RiskRules] (
    [id]           INT  IDENTITY (1, 1) NOT NULL,
    [ClientSectorID] INT FOREIGN KEY REFERENCES ClientSector(id),
    [MinValue]     FLOAT  DEFAULT 0 NOT NULL,
    [MaxValue]     FLOAT  DEFAULT 0 NOT NULL,
    [CategoryRiskID] INT FOREIGN KEY REFERENCES CategoryRisk(id),
    CONSTRAINT [PK_RiskRules] PRIMARY KEY CLUSTERED ([id] ASC)
)

GO

INSERT INTO [RiskRules]([ClientSectorID], [MinValue], [MaxValue], [CategoryRiskID]) VALUES (2,0,1000000,1)
INSERT INTO [RiskRules]([ClientSectorID], [MinValue], [MaxValue], [CategoryRiskID]) VALUES (2,1000000,0,2)
INSERT INTO [RiskRules]([ClientSectorID], [MinValue], [MaxValue], [CategoryRiskID]) VALUES (1,1000000,0,3)

GO

CREATE TABLE [TradesCategory] (
    [id]            INT  IDENTITY (1, 1) NOT NULL,   
    [ClientSectorID] INT FOREIGN KEY REFERENCES ClientSector(id),
    [Value]     FLOAT  DEFAULT 0 NOT NULL,
    [CategoryRiskID] INT FOREIGN KEY REFERENCES CategoryRisk(id),
    CONSTRAINT [PK_TradesCategory] PRIMARY KEY CLUSTERED ([id] ASC)
)

GO