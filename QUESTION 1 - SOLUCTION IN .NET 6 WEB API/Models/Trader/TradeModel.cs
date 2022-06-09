

using System.Text.Json.Serialization;

namespace Test.Models
{
    public class TradeModel : BaseModel
    {
        public TradeModel()
        {
            Value = 0;
            CategoryRisk = "";
            TradeDate = DateTime.Now;
        }

        public double Value { get; set; }

        public string CategoryRisk { get; set; }

        public DateTime TradeDate { get; set; }

    }

}