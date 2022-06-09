

using System.Text.Json.Serialization;

namespace Test.Models
{
    public class TradeModelPost : BaseModel
    {
        public TradeModelPost()
        {
            Value = 0;
            CategoryRisk = "";
            TradeDate = DateTime.Now;

        }

        [JsonIgnoreAttribute]
        public override Guid Id { get; set; }

        public double Value { get; set; }

        [JsonIgnoreAttribute]
        public string CategoryRisk { get; set; }

        [JsonIgnoreAttribute]
        public DateTime TradeDate { get; set; }

    }

}