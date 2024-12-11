using MaxTopan_GWRFighter.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MaxTopan_GWRFighter.Program;

namespace MaxTopan_GWRFighter.Models
{
    public interface IWeapon
    {
        string Name { get; }
        int Damage { get; }
        void Use(ICharacter hero, ICharacter villain);

    }
}
