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
        public static void BattleSkillUI(Player player, List<Monster> BattleList, ref int killCount)
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
                Console.WriteLine($"MP {player.Mana}");


                Console.WriteLine("\n[스킬]\n");
                for (int i = 0; i < player.SkillList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {player.SkillList[i].Name} | 마나 소모 {player.SkillList[i].ManaCost} | 데미지 {player.SkillList[i].Damege} | 설명 {player.SkillList[i].Description}");
                }
                Console.WriteLine("\n사용할 스킬을 선택해주세요.");
                Console.Write(">>");
                int selectSkill = 0; // 선택한 스킬
                while (!int.TryParse(Console.ReadLine(), out selectSkill) || selectSkill <= 0 || selectSkill > player.SkillList.Count) //조건 추가
                {
                    Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
                    Console.Write(">>");
                }
                

                if (selectSkill > 0 && player.SkillList[selectSkill-1].Multiple == true)// 다중 공격 // 수정 조건 추가
                {
                    player.Mana -= player.SkillList[selectSkill - 1].ManaCost; //추가 사용한 스킬 마나코스트만큼 소모

                    Console.WriteLine($"{player.SkillList[selectSkill-1].Name}사용 {player.SkillList[selectSkill - 1].ManaCost} 마나 소모");
                    //사용 스킬 텍스트 출력
                    Random random = new Random(); //수정 랜덤 값을 이용해 2명 공격

                    for (int i = 0; i < 2; i++)
                    {
                        int num = random.Next(0, BattleList.Count);
                        if (!BattleList[num].IsDead) // 수정 : 선택한 몬스터가 사망하지 않았을때만 실행
                        {
                            Console.WriteLine($"{BattleList[num].Name} 공격");
                            Console.ReadKey(true);

                            //전달해야 할 선택한 스킬 selectSkill
                            int dmg = CalcDamage.CalcDmg(player, BattleList[num], selectSkill);
                            if (dmg != -1)
                                Console.WriteLine($"{BattleList[num].Name}이(가) {dmg} 데미지를 받았습니다.");
                            else Console.WriteLine($"{BattleList[num].Name}이(가) 공격을 회피했습니다."); //회피 출력 추가

                            if (BattleList[num].IsDead)
                            {
                                killCount++;
                                Console.WriteLine($"{BattleList[num].Name}의 체력이 0이 되었습니다.");
                            }
                            
                        }
                    }
                    playerturn = false;
                    break;
                }
                else
                {
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
                        Console.WriteLine($"MP {player.Mana}");

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
                            player.Mana -= player.SkillList[selectSkill - 1].ManaCost; // 사용한 스킬 마나코스트만큼 소모
                            Console.WriteLine($"{player.SkillList[selectSkill - 1].Name} 사용 {player.SkillList[selectSkill - 1].ManaCost} 마나 소모");
                            Console.WriteLine($"{BattleList[input - 1].Name} 공격");
                            Console.ReadKey(true);

                            //전달해야 할 선택한 스킬 selectSkill
                            int dmg = CalcDamage.CalcDmg(player, BattleList[input - 1], selectSkill);
                            if (dmg != -1)
                                Console.WriteLine($"{BattleList[input - 1].Name}이(가) {dmg} 데미지를 받았습니다.");
                            else Console.WriteLine($"{BattleList[input - 1].Name}이(가) 공격을 회피했습니다."); //회피 출력 추가

                            if (BattleList[input - 1].IsDead)
                            {
                                killCount++;
                                Console.WriteLine($"{BattleList[input - 1].Name}의 체력이 0이 되었습니다.");
                            }
                            playerturn = false;
                            break;
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
}
