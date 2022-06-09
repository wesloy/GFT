namespace Risk
{
    public class RiskRules : IRiskRules
    {
        public RiskRules()
        {
            ValueMin = 0;
            ValueMax = 0;
            ClientSector = "";
            Risk = "";
        }

        public double ValueMin { get; set; }

        public double ValueMax { get; set; }

        public string ClientSector { get; set; }

        public string Risk { get; set; }
    }

}