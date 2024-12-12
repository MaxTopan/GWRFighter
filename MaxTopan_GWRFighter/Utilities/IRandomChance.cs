namespace MaxTopan_GWRFighter.Utilities
{
    public interface IRandomChance
    {
        /// <summary>
        /// Percentage chance for ChanceTrigger() to trigger (0.01 - 0.99)
        /// </summary>
        double Percentage { get; }

        /// <summary>
        /// Randomly generates a double from 0.00 - 0.99 inclusive. Checks that against a percentage chance
        /// </summary>
        /// <returns>True if the random double generated is below the Percentage</returns>
        bool ChanceTrigger()
        {
            Random r = new Random();
            return r.NextDouble() < Percentage;
        }
    }
}
