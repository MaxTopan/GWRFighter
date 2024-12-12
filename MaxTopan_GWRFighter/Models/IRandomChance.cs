namespace MaxTopan_GWRFighter.Models
{
    public interface IRandomChance
    {
        double Percentage { get; }
        bool ChanceTrigger();
    }
}
