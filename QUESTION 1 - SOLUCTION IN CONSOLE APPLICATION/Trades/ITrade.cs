namespace Trades
{
    public interface ITrade
    {
        double Value { get; set; }

        string ClientSector { get; set; }
    }

}