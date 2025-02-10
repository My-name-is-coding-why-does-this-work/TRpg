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
        public static void BattleSkillUI(Player player, List<Monster> BattleList, int killCount)
        {
            bool playerturn = true;
            while (playerturn) // 사용할 스킬 선택 반복문
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
                    Console.WriteLine($"{i + 1}. {player.SkillList[i].Name} | 마나 소모 {player.SkillList[i].ManaCost} | 데미지 {player.SkillList[i].Damege} | 설명 {player.SkillList[i].Description}");
                }
                Console.WriteLine("\n사용할 스킬을 선택해주세요.");
                Console.Write(">>");
                int selectSkill; // 선택한 스킬
                while (!int.TryParse(Console.ReadLine(), out selectSkill))
                {
                    Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
                    Console.Write(">>");
                }
                //스킬을 사용할 몬스터 선택
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


                    Console.WriteLine("\n[행동]\n");
                    Console.WriteLine("\n공격할 몬스터를 선택해주세요.");
                    Console.Write(">>");
                    int input;
                    while (!int.TryParse(Console.ReadLine(), out input))
                    {
                        Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
                        Console.Write(">>");
                    }

                    if (input > 0 && input <= BattleList.Count && !BattleList[input - 1].IsDead) // 수정 : 선택한 몬스터가 사망하지 않았을때만 실행
                    {
                        Console.WriteLine($"{BattleList[input - 1].Name} 공격");
                        Console.ReadKey(true);

                        //전달해야 할 선택한 스킬 selectSkill
                        int dmg = CalcDamage.CalcDmg(player, BattleList[input - 1]/*, selectSkill*/);
                        if (dmg != 0)
                            Console.WriteLine($"{BattleList[input - 1].Name}이(가) {dmg} 데미지를 받았습니다.");
                        else
                        {
                            killCount++;
                            Console.WriteLine($"{BattleList[input - 1].Name}의 체력이 0이 되었습니다.");
                        }
                        playerturn = false;
                    }
                    else 
                    {
                        Console.WriteLine("잘못된 입력입니다. 계속 하시려면 아무키를 입력하세요.");
                        Console.ReadKey(true);
                    }
                }
            }
        }
    }
}
