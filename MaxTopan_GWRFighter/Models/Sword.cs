using MaxTopan_GWRFighter.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MaxTopan_GWRFighter.Program;

namespace MaxTopan_GWRFighter.Models
{
    public class Sword : IWeapon
    {
        public string Name => "Sword";
        public int DamageAmount => 10;
        
        public void Use(ICharacter hero, ICharacter villain)
        {
            villain.Damage(DamageAmount);

            /* MOVE THIS TO SOMETHING THAT OWNS DIALGOUE DUE TO SRP */
            Console.WriteLine($"{hero.Name} slashes with the {Name} for {DamageAmount} damage!");
        }
    }
}
