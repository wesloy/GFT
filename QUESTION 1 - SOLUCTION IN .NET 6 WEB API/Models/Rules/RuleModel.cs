namespace Test.Models
{
    public class RuleModel : BaseModel
    {
        public RuleModel()
        {
            MinValue = 0;
            MaxValue = 0;
            CategoryRisk = "";
        }

        public double MinValue { get; set; }
        public double MaxValue { get; set; }
        public string CategoryRisk { get; set; }
    }

}