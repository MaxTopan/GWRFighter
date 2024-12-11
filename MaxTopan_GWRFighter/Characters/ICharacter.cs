using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxTopan_GWRFighter.Characters
{
    public interface ICharacter
    {
        string Name { get; }
        int Health { get; }
        void Heal(int value);
        void Damage(int value);
        void Attack(ICharacter character);
    }
}
