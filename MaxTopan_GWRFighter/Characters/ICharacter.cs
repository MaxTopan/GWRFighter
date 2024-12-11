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
        int Health { get; set; }
        /// <summary>
        /// Add health to the character
        /// </summary>
        /// <param name="value">Amount of health to add</param>
        void Heal(int value) 
        {
            Health += value;
        }

        /// <summary>
        /// Remove health from the character
        /// </summary>
        /// <param name="value">Amount of health to remove</param>
        void Damage(int value)
        {
            Health -= value;
        }

        /// <summary>
        /// Attack another character
        /// </summary>
        /// <param name="character">Character to attack</param>
        void Attack(ICharacter character);
    }
}
