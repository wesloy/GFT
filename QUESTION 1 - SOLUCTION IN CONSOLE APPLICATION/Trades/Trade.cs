namespace Trades
{
    public class Trade : ITrade
    {
        public Trade()
        {
            Value = 0;
            ClientSector = "";
        }

        public double Value { get; set; }

        public string ClientSector { get; set; }
    }
}