using System.Text.Json.Serialization;

namespace Test.Models
{
    public class RuleModelPost : BaseModel
    {
        public RuleModelPost()
        {
            MinValue = 0;
            MaxValue = 0;
            CategoryRisk = "";

        }

        [JsonIgnoreAttribute]
        public override Guid Id { get; set; }
        public double MinValue { get; set; }
        public double MaxValue { get; set; }
        public string CategoryRisk { get; set; }
    }

}