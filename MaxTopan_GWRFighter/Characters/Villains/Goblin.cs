﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxTopan_GWRFighter.Characters.Villains
{
    internal class Goblin : Villain
    {
        public override string Name => "Goblin";
        public override string Description => "Basic enemy. Short and weak, not very strong, not very smart.";

        public override int Health { get; protected set; } = 30;

        public override int AttackPower { get; protected set; } = 5;

        public override void TakeTurn(Character hero)
        {
            Attack(hero);
        }
    }
}
