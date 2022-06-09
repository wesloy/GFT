CREATE OR ALTER PROCEDURE [spTradeCategory] 

    @ClientSector VARCHAR(20),
    @Value FLOAT

AS 

    DECLARE @SectorID INT 
    SET @SectorID = (SELECT TOP 1 [id] FROM [ClientSector] 
                        WHERE [Sector] = @ClientSector
    ) 

     

    DECLARE @RiskID INT
    SET @RiskID = (SELECT CatRiskID FROM (
                        SELECT     
                        IIF(@Value >= [RiskRules].[MinValue] AND  @Value < [RiskRules].[MaxValue], [RiskRules].[CategoryRiskID],
                                IIF([RiskRules].[MaxValue] = 0 AND @Value >= [RiskRules].[MinValue], [RiskRules].[CategoryRiskID],
                                    IIF([RiskRules].[MinValue] = 0 AND @Value < [RiskRules].[MaxValue], [RiskRules].[CategoryRiskID],
                                    0
                                ))) AS CatRiskID

                        FROM [RiskRules] 
                            WHERE [ClientSectorID] = @SectorID 

                    ) AS [VALIDATION] 
                    WHERE  [VALIDATION].CatRiskID > 0
    )


SET @RiskID = iif(@RiskID is null, 4, @RiskID)


INSERT INTO [TradesCategory]([ClientSectorID], [Value], [CategoryRiskID]) 
                VALUES (@SectorID, @Value, @RiskID)

SELECT [Risk] FROM [CategoryRisk] WHERE [id] =  @RiskID 


