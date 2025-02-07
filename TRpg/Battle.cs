using System;


public class Battle(Player player)
{
    public  bool MonsterIsDie = false; //임시 몬스터 생존 여부

    List<Monster> MonstersList; // 몬스터 종류 담을 리스트
    List<Monster> BattleList; // 배틀이 시작하면 랜덤으로 몬스터를 

    public int killCount = 0; //몬스터 처치 수

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

        int CountMonster = random.Next(0, 4);

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
                Console.WriteLine(BattleList[i].Name);
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
            }

            if (BattleList.Count == killCount)//몬스터 생존 여부 확인
            {
                //몬스터 처치시
                battel = false;
                //배틀 종료
            }

            Console.WriteLine("몬스터 턴");
            Console.WriteLine("계속 하시려면 아무키를 입력하세요.");
            Console.ReadKey(true);
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
                        Console.WriteLine(BattleList[i].Name);
                    }


                    Console.WriteLine("");
                    Console.WriteLine("");

                    Console.WriteLine("[내정보]");
                    Console.WriteLine($"Lv.{player.Lv} {player.Name} ({player.IClass})");
                    Console.WriteLine($"HP 100/{player.Health}");


                    Console.WriteLine("\n[행동]\n");
                    Console.WriteLine("\n공격할 몬스터를 선택해주세요.");
                    Console.Write(">>");

                    int input = int.Parse(Console.ReadLine());
                    if (input > 0 && input <= BattleList.Count)
                    {
                        Console.WriteLine($"{BattleList[input - 1].Name} 공격");
                        Console.ReadKey(true);
                        playerturn = false;
                    }
                    else
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
