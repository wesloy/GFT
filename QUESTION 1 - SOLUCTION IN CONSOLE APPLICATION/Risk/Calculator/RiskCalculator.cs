using Trades;
using Categories;

namespace Risk
{
    public class RiskCalculator : IRIskCalculator
    {

        public List<ICategory> getCategoryRisk(List<IRiskRules> riskRules, List<ITrade> portifolio)
        {

            List<ICategory> listCategories = new List<ICategory>();

            try
            {
                {

                    foreach (var trade in portifolio)
                    {
                        Category category = new Category();

                        foreach (var rule in riskRules)
                        {
                            if (trade.Value >= rule.ValueMin && trade.Value <= rule.ValueMax && trade.ClientSector.ToUpper() == rule.ClientSector.ToUpper())
                            {
                                category.desCategory = rule.Risk.ToUpper();
                                listCategories.Add(category);
                            }
                            else if (rule.ValueMax == 0 && trade.Value >= rule.ValueMin && trade.ClientSector.ToUpper() == rule.ClientSector.ToUpper())
                            {
                                category.desCategory = rule.Risk.ToUpper();
                                listCategories.Add(category);
                            }
                            else if (rule.ValueMin == 0 && trade.Value < rule.ValueMax && trade.ClientSector.ToUpper() == rule.ClientSector.ToUpper())
                            {
                                category.desCategory = rule.Risk.ToUpper();
                                listCategories.Add(category);
                            }
                        }

                        if (String.IsNullOrEmpty(category.desCategory))
                        {
                            category.desCategory = "NO RISK VALIDATION RULE";
                            listCategories.Add(category);
                        }

                    }


                }

                return listCategories;

            }
            catch (System.Exception)
            {

                return listCategories;
            }
        }

    }
}