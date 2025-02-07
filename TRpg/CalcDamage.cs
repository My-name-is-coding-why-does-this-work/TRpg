using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRpg
{

    public class CalcDamage
    {
        int damage;
        public int CalcDmg(Player attacker,  Monster defender)
        {
            damage  = new Random().Next(attacker.Attack - 1, attacker.Attack + 2);
            defender.Health = defender.Health - damage;

            return damage;
        }

        public int CalcDmg(Monster attacker, Player defender)
        {
            damage = new Random().Next(attacker.Attack - 1, attacker.Attack + 2);
            defender.Health = defender.Health - damage;

            return damage;
        }
    }
}
