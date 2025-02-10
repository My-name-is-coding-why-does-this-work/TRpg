using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRpg
{
    public static class CalcDamage
    {
        static int damage; //입힌 피해량
        static int margin; //공격력의 오차 범위 10%

        //데미지 처리 오버로딩으로 분리
        public static int CalcDmg(Player attacker, Monster defender)
        {

            margin = attacker.Attack / 10;
            damage = new Random().Next(attacker.Attack - margin, attacker.Attack + margin + 1);
            if (defender.Health < damage)
            {
                defender.Health = 0;
                defender.IsDead = true;
                
                return 0;
            }
            else
            {
                defender.Health = defender.Health - damage;
            }
            return damage;
        }

        public static int CalcDmg(Monster attacker, Player defender)
        {

            margin = attacker.Attack / 10;
            damage = new Random().Next(attacker.Attack - margin, attacker.Attack + margin + 1);
            if (defender.Health < damage)
            {
                defender.Health = 0;
                defender.IsDead = true;

                return 0;
            }
            else
            {
                defender.Health = defender.Health - damage;
            }
            return damage;
        }

    }
}
