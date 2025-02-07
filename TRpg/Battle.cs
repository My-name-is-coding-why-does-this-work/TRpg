using System;
using TRpg;


public class Battle(Player player)
{
    public  bool MonsterIsDie = false; //임시 몬스터 생존 여부

    List<Monster> MonstersList; // 몬스터 종류 담을 리스트
    List<Monster> BattleList; // 배틀이 시작하면 랜덤으로 몬스터를 

    public int killCount = 0; //몬스터 처치 수

    // 수정 : 진행을 위한 각 클래스 변수 선언
    public BattleEndPg endPg = new BattleEndPg();
    public static CalcDamage dmgCalc = new CalcDamage();
    public MonsterTurn mTurn = new MonsterTurn(dmgCalc);

    public void MakeMonster()
    {
        Monster monster1 = new Monster("전사 미니언", 1, 10, 5, 50, 20, "미니언");
        Monster monster2 = new Monster("마법사 미니언", 3, 10, 7, 30, 14, "미니언");
        Monster monster3 = new Monster("탱크 미니언", 10, 10, 15, 100, 100, "미니언");
        Monster monster4 = new Monster("공허 유충", 7, 10, 10, 100, 100, "공허 유충");

        MonstersList.Add(monster1);
        MonstersList.Add(monster2);
        MonstersList.Add(monster3);
        MonstersList.Add(monster4);
    }

    public void MakeList()
    {
        MonstersList = new List<Monster>();
        BattleList = new List<Monster>();

        MakeMonster();

        Random random = new Random();

        int CountMonster = random.Next(1, 4);

        for (int i = 0; i < CountMonster; i++)
        {
            int maxVal = MonstersList.Count - 1;
            int SelectMonster = random.Next(0, maxVal);
            BattleList.Add(MonstersList[SelectMonster]);
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
                Console.WriteLine($"{BattleList[i].Name} {BattleList[i].Lv} {BattleList[i].Health}");
            }


            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("[내정보]");
            Console.WriteLine($"Lv.{player.Lv} {player.Name} ({player.IClass})");
            Console.WriteLine($"HP 100/{player.Health}");


            Console.WriteLine("\n[행동]\n");
            Console.WriteLine("1. 공격");
            Console.WriteLine("2. 방어");
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
                endPg.StageClear(player);
                //배틀 종료
                break;
            }

            Console.WriteLine("몬스터 턴");
            Console.WriteLine("계속 하시려면 아무키를 입력하세요.");
            Console.ReadKey(true);

            // 수정 : 몬스터 턴 실행
            mTurn.MonstersTurn(BattleList, player);
            if(player.IsDead) // 수정 : 몬스터의 턴 실행 후 플레이어 사망 시
            {
                endPg.StageClear(player);
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
                        Console.Write($"-{i+1} ");
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
                        int dmg = dmgCalc.CalcDmg(player, BattleList[input - 1]); 
                        if(dmg != 0)
                            Console.WriteLine($"{BattleList[input - 1].Name}이(가) {dmg} 데미지를 받았습니다.");
                        else
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
                //방어
                Console.WriteLine("방어");
                break;
        }
	}
}
