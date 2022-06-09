using Trades;
using Categories;

namespace Risk
{
    public interface IRIskCalculator
    {
        public List<ICategory> getCategoryRisk(List<IRiskRules> riskRules, List<ITrade> portifolio);
    }
}