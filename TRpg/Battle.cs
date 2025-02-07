using System;


public class Battle
{
    public  bool MonsterIsDie = false; //임시 몬스터 생존 여부

    List<string> BattleList;

    

	public void BattleStart()
	{
        BattleList = new List<string>();

        BattleList.Add("Lv2 미니언");
        BattleList.Add("Lv4 미니언");
        BattleList.Add("Lv2 미니언");

        bool battel = true;
		while (battel)
		{
            Console.Clear();
            Console.WriteLine("Battle!!\n");

            for (int i = 0; i < BattleList.Count; i++)
            {
                Console.WriteLine(BattleList[i]);
            }


            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("[내정보]");
            Console.WriteLine("Lv.2 Chad (전사)");
            Console.WriteLine("HP 100/100");


            Console.WriteLine("\n[행동]\n");
            Console.WriteLine("1. 공격");
            Console.WriteLine("2. 방어");
            Console.WriteLine("\n원하시는 행동을 입력해주세요.");
            Console.Write(">>");
            
            string select = Console.ReadLine();

            if (select == "1" || select =="2") playerTurn(select);
            else
            {
                
            }

            if (MonsterIsDie == true)
            {
                //몬스터 처치시
                battel = false;
                //승리
            }

            Console.WriteLine("몬스터 턴");
            Console.WriteLine("계속 하시려면 아무키를 입력하세요.");
            Console.ReadKey(true);
        }

		

    }

	public void playerTurn(string select)
	{
		switch(select)
		{
            case "1":
                //공격
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Battle!!\n");

                    for (int i = 0; i < BattleList.Count; i++)
                    {
                        Console.Write($"-{i} ");
                        Console.WriteLine(BattleList[i]);
                    }


                    Console.WriteLine("");
                    Console.WriteLine("");

                    Console.WriteLine("[내정보]");
                    Console.WriteLine("Lv.2 Chad (전사)");
                    Console.WriteLine("HP 100/100");


                    Console.WriteLine("\n[행동]\n");
                    Console.WriteLine("1. 공격");
                    Console.WriteLine("2. 방어");
                    Console.WriteLine("\n원하시는 행동을 입력해주세요.");
                    Console.Write(">>");

                    int select = int.Parse(Console.ReadLine());
                    if (select - 1 > 0 && select - 1 < BattleList.Count)
                    {
                        Console.WriteLine($"{BattleList[select - 1]}");
                        Console.WriteLine("공격");
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
