using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxTopan_GWRFighter.Characters.Villains
{
    internal class Orc : Villain
    {
        public override string Name => "Orc";

        public override string Description => "Big. Two tusks. Has thick armour like skin.";

        public override int Health { get; protected set; } = 40;

        public override int AttackPower { get; protected set; } = 15;

        public override void Damage(int value)
        {
            // reduce damage by 2 due to thick skin
            base.Damage(value - 2);
        }
    }
}
