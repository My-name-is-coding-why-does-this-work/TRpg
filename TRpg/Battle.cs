using System;
using TRpg;


public class Battle(Player player)
{
    public  bool MonsterIsDie = false; //임시 몬스터 생존 여부

    List<Monster> MonstersList; // 몬스터 종류 담을 리스트
    List<Monster> BattleList; // 배틀이 시작하면 랜덤으로 몬스터를 

    public int killCount = 0; //몬스터 처치 수

    public void MakeList()
    {
        MonstersList = new List<Monster>();
        BattleList = new List<Monster>();

        Random random = new Random();

        int CountMonster = random.Next(1, 4);

        for (int i = 0; i < CountMonster; i++)
        {
            int maxVal = 4;
            int SelectMonster = random.Next(0, maxVal);

            switch (SelectMonster)
            {
                case 0:
                    BattleList.Add(new Monster("전사 미니언", 1, 10, 5, 50, 20, "미니언"));
                    break;
                case 1:
                    BattleList.Add(new Monster("마법사 미니언", 3, 10, 7, 30, 14, "미니언"));
                    break;
                case 2:
                    BattleList.Add(new Monster("탱크 미니언", 10, 10, 15, 100, 100, "미니언"));
                    break;
                case 3:
                    BattleList.Add(new Monster("공허 유충", 7, 10, 10, 100, 100, "공허 유충"));
                    break;
            }
        }
    }

	public void BattleStart()
	{
        MakeList();

        bool battel = true;
        while (battel)
        {
            Console.Clear();
            Console.WriteLine("Battle!!\n");

            for (int i = 0; i < BattleList.Count; i++)
            {
                if (BattleList[i].IsDead)
                    Console.ForegroundColor = ConsoleColor.Red; // 몬스터가 사망했을때 빨간색
                else
                    Console.ForegroundColor = ConsoleColor.White; // 몬스터가 사망하지않았을때 흰색
                Console.WriteLine($"{BattleList[i].Name} {BattleList[i].Lv} {BattleList[i].Health}");
            }

            Console.ResetColor(); // 색상 초기화
            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("[내정보]");
            Console.WriteLine($"Lv.{player.Lv} {player.Name} ({player.IClass})");
            Console.WriteLine($"HP {player.Health}");
            Console.WriteLine($"MP {player.Mana}");

            Console.WriteLine("\n[행동]\n");
            Console.WriteLine("1. 공격");
            Console.WriteLine("2. 스킬");
            Console.WriteLine("\n원하시는 행동을 입력해주세요.");
            Console.Write(">>");

            string select = Console.ReadLine();

            if (select == "1" || select == "2") playerTurn(select);
            else
            {
                //잘못입력 했을때
                Console.WriteLine("잘못된 입력입니다. 턴을 포기합니다.");
            }
            

            if (BattleList.Count == killCount)//몬스터 생존 여부 확인
            {
                //몬스터 처치시
                BattleEndPg.StageClear(player);
                //배틀 종료
                break;
            }

            Console.WriteLine("몬스터 턴");
            Console.WriteLine("계속 하시려면 아무키를 입력하세요.");
            Console.ReadKey(true);

            // 수정 : 몬스터 턴 실행
            MonsterTurn.MonstersTurn(BattleList, player);
            if(player.IsDead) // 수정 : 몬스터의 턴 실행 후 플레이어 사망 시
            {
                BattleEndPg.StageClear(player);
            }
        }

    }

	public void playerTurn(string select)
	{
        bool playerturn = true;
		switch(select)
		{
            case "1":
                //공격
                while (playerturn)
                {
                    Console.Clear();
                    Console.WriteLine("Battle!!\n");

                    for (int i = 0; i < BattleList.Count; i++)
                    {
                        if (BattleList[i].IsDead)
                            Console.ForegroundColor = ConsoleColor.Red; // 몬스터가 사망했을때 빨간색
                        else
                            Console.ForegroundColor = ConsoleColor.White; // 몬스터가 사망하지않았을때 흰색

                        Console.Write($"-{i+1} ");
                        Console.WriteLine($"{BattleList[i].Name} {BattleList[i].Lv} {BattleList[i].Health}");

                    }

                    Console.ResetColor(); // 색상초기화
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
                    while(!int.TryParse(Console.ReadLine(),out input))
                    {
                        Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
                        Console.Write(">>");
                    }

                    if (input > 0 && input <= BattleList.Count && !BattleList[input - 1].IsDead) // 수정 : 선택한 몬스터가 사망하지 않았을때만 실행
                    {
                        Console.WriteLine($"{BattleList[input - 1].Name} 공격");
                        Console.ReadKey(true);

                        // 수정 : 데미지 계산
                        int dmg = CalcDamage.CalcDmg(player, BattleList[input - 1]); 
                        if(dmg != -1)
                            Console.WriteLine($"{BattleList[input - 1].Name}이(가) {dmg} 데미지를 받았습니다.");
                        else Console.WriteLine($"{BattleList[input - 1].Name}이(가) 공격을 회피했습니다."); //회피 출력 추가

                        if (BattleList[input - 1].IsDead)
                        {
                            killCount++;
                            Console.WriteLine($"{BattleList[input - 1].Name}의 체력이 0이 되었습니다.");
                        }
                        playerturn = false;
                    }
                    else // 수정 : 정해진 입력이 아닐 경우 출력
                    {
                        Console.WriteLine("잘못된 입력입니다. 계속 하시려면 아무키를 입력하세요.");
                        Console.ReadKey(true);
                    }
                }                
                break;
            case "2":
                BattleSkill.BattleSkillUI(player, BattleList, ref killCount);
                break;
        }
	}
}
