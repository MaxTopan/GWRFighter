﻿namespace MaxTopan_GWRFighter.Characters.Villains
{
    internal class Orc : Villain
    {
        public override string Name => "Orc";

        public override string Description => "Has thick armour-like skin but can get worn down.";

        public override int Health { get; protected set; } = 40;

        public override int AttackPower { get; protected set; } = 15;

        private int _armourValue = 4;

        public override void Damage(int value)
        {
            // reduce damage due to thick skin
            base.Damage(value - _armourValue);
            if (_armourValue > 0)
            {
                _armourValue--;
                Console.WriteLine($"The {Name} blocked {_armourValue} of the damage due to its thick skin!");
            }
        }

        public override void DisplayStats()
        {
            Console.WriteLine($"{Name} [Health: {Health}, Attack Power: {AttackPower}, Armour: {_armourValue}]\r\n{Description}");
        }
    }
}
