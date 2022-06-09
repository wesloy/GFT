using Microsoft.AspNetCore.Mvc;
using Test.Data;

namespace Test.Functions
{
    public static class RiskTrade
    {
        public static string getCategoryRisk(double value, string clientSector, [FromServices] TestDbContext context)
        {
            try
            {


                var rules = context.Rules.Where(x => x.ClientSector.Contains(clientSector.ToUpper())).ToList();

                var defaultCategoryRisk = "";


                foreach (var item in rules)
                {

                    if (value >= item.MinValue && value <= item.MaxValue)
                    {
                        return item.CategoryRisk;
                    }

                    if (item.MaxValue == 0 && value >= item.MinValue)
                    {
                        return item.CategoryRisk;
                    }

                    if (item.MinValue == 0 && value < item.MaxValue)
                    {
                        return item.CategoryRisk;
                    }

                }

                return defaultCategoryRisk;

            }
            catch (System.Exception)
            {

                return "";
            }
        }

    }

}