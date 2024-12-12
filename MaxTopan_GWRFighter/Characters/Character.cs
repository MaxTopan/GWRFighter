namespace MaxTopan_GWRFighter.Characters
{
    public abstract class Character
    {
        public abstract string Name { get; }
        public abstract int Health { get; protected set; }

        /// <summary>
        /// Add health to the character
        /// </summary>
        /// <param name="value">Amount of health to add</param>
        public virtual void Heal(int value)
        {
            Health += value;
        }

        /// <summary>
        /// Remove health from the character
        /// </summary>
        /// <param name="value">Amount of health to remove</param>
        public virtual void Damage(int value)
        {
            Health -= value;
            if (Health < 0) Health = 0;
        }

        /// <summary>
        /// Attack another character
        /// </summary>
        /// <param name="character">Character to attack</param>
        public abstract void Attack(Character character);

        /// <summary>
        /// Show all relevent information relating to Character
        /// </summary>
        public abstract void DisplayStats();
    }
}
