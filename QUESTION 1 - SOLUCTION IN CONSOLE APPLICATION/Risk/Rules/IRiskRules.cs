namespace Risk
{
    public interface IRiskRules
    {
        double ValueMin { get; set; }

        double ValueMax { get; set; }

        string ClientSector { get; set; }

        string Risk { get; set; }
    }

}