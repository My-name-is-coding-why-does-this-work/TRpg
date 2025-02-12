using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates; // 추가
using System.Threading;
using TRpg;


internal class Program
{
    static Inventory inventory = Inventory.Instance(); // Inventory 객체를 싱글턴으로 생성

    static void Main(string[] args)
    {
        var _SingletonItemList = Inventory.Instance();
        Player player = new Player("코난", 1, 10, 5, 100, 1500, "전사"); //수정 : player를 Main 안으로
        ItemList itemList = new ItemList(); // 아이템 리스트 생성
        Program program = new Program();
        Inventory.SingletonItemList.AddItem(itemList.itemLists[0]); // 아이템을 인벤토리에 추가
        Inventory.SingletonItemList.AddItem(itemList.itemLists[1]); // 아이템을 인벤토리에 추가


        StartMessage(player); //수정 : 매개 변수 추가
    }

    static public void StartMessage(Player player) // 매개변수로 player 객체를 전달받음
    {
        Console.Clear();
        Console.WriteLine("***** 스파르타 던전에 오신것을 환영합니다! *****");
        Console.WriteLine("1. 상태 보기");
        Console.WriteLine("2. 인벤토리 보기");
        Console.WriteLine("3. 상점 보기");
        Console.WriteLine("4. 전투 시작");
        Console.WriteLine("원하시는 행동을 입력해주세요.");

        while (true)
        {
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Clear();
                    player.PlayerStatus();
                    Console.WriteLine("0. 메인 화면"); // 메인 화면으로 돌아가기 옵션
                    string statusInput = Console.ReadLine();
                    if (statusInput == "0")
                    {
                        StartMessage(player);
                        return; // StartMessage로 돌아가도록 break 대신 return 사용
                    }
                    break;

                case "2":
                    Console.Clear();
                    Inventory.SingletonItemList.ShowInventory(player); // player 객체 전달
                    break;

                case "3":
                    Console.Clear();
                    Console.WriteLine("1. 상점 보기");
                    break;

                case "4":
                    Console.WriteLine("전투를 시작합니다!");
                    Console.ReadKey();
                    Battle battle = new Battle(player);
                    battle.BattleStart();
                    break;

                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    break;
            }
        }
    }
}