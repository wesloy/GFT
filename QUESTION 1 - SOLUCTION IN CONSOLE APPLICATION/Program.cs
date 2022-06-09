// See https://aka.ms/new-console-template for more information

using Trades;
using Risk;
using Categories;

// lISTA DO EXEMPLO
Trade trade1 = new Trade { Value = 2000000, ClientSector = "Private" };
Trade trade2 = new Trade { Value = 400000, ClientSector = "Public" };
Trade trade3 = new Trade { Value = 500000, ClientSector = "Public" };
Trade trade4 = new Trade { Value = 3000000, ClientSector = "Public" };

// ARMAZENANDO NO PORTIFOLIO
List<ITrade> portifolio = new List<ITrade> { trade1, trade2, trade3, trade4 };

// REGRAS DE RISCO
RiskRules risk1 = new RiskRules { ValueMin = 0, ValueMax = 1000000, ClientSector = "Public", Risk = "LOWRISK" };
RiskRules risk2 = new RiskRules { ValueMin = 1000000, ValueMax = 0, ClientSector = "Public", Risk = "MEDIUMRISK" };
RiskRules risk3 = new RiskRules { ValueMin = 1000000, ValueMax = 0, ClientSector = "Private", Risk = "HIGHRISK" };

// ARMAZENANDO REGRAS DE RISCO
List<IRiskRules> riskRules = new List<IRiskRules> { risk1, risk2, risk3 };

// CALCULANDO RISCO DA TRANSAÇÃO
RiskCalculator riskCalculator = new RiskCalculator();
List<ICategory> tradeCategorias = new List<ICategory>();
tradeCategorias = riskCalculator.getCategoryRisk(riskRules, portifolio);

foreach (var item in tradeCategorias)
{
    Console.WriteLine(item.desCategory);
}

Console.ReadKey();


