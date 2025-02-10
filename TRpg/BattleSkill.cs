using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TRpg
{
    internal class BattleSkill
    {
        public static void BattleSkillUI(Player player, List<Monster> BattleList)
        {
            bool playerturn = true;
            while (playerturn)
            {
                Console.Clear();
                Console.WriteLine("Battle!!\n");

                for (int i = 0; i < BattleList.Count; i++)
                {
                    Console.Write($"-{i + 1} ");
                    Console.WriteLine($"{BattleList[i].Name} {BattleList[i].Lv} {BattleList[i].Health}");
                }

                Console.WriteLine("");
                Console.WriteLine("");

                Console.WriteLine("[내정보]");
                Console.WriteLine($"Lv.{player.Lv} {player.Name} ({player.IClass})");
                Console.WriteLine($"HP {player.Health}");


                Console.WriteLine("\n[스킬]\n");
                for (int i = 0; i < player.SkillList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {player.SkillList[i].Name} 마나 소모 {player.SkillList[i].ManaCost} 데미지 {player.SkillList[i].Damege}");
                }
                Console.WriteLine("\n사용할 스킬을 선택해주세요.");
                Console.Write(">>");
                int input;
                while (!int.TryParse(Console.ReadLine(), out input))
                {
                    Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
                    Console.Write(">>");
                }
            }
        }
    }
}
