
public static class BattleEndPg
{
    private static List<Item> RewardItems = new List<Item> // 추가: 보상 아이템 목록(임시로 추가)
    {
        new Item("전사의 검", "칼", 15, 0, "전사들이 애용하는 검"),
        new Item("수호자의 방패", "방어구", 10, 0, "튼튼한 방패"),
        new Item("치유의 포션", "반지", 0, 0, "체력을 조금 회복시켜주는 반지")
    };


    public static void StageClear(Player player, int gold = 0)
    {
        if (!player.IsDead)
        {
            Console.WriteLine($"==== You Win {player.Name}가 몬스터를 물리쳤습니다! ====");

            player.Gold += gold;
            Console.WriteLine($"골드 {gold}G 획득!");

            // 아이템 보상 지급
            Item rewardItem = RewardItems[new Random().Next(RewardItems.Count)];
            Console.WriteLine($"아이템 획득: {rewardItem.Name} (+{rewardItem.StatBoost})");
            player.inventory.AddItem(rewardItem);

            Console.WriteLine("1. 다음 스테이지");
            Console.WriteLine("2. 마을로 이동하기");

            Console.Write("\n당신의 선택: ");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":// 수정 : 미구현 부분 주석 처리
                         //                   player.nextStage();
                         //                   break;
                    Console.WriteLine("미구현된 기능입니다. 마을로 돌아갑니다.");
                    Program.StartMessage(player);
                    break;
                case "2": 
                    Program.StartMessage(player);
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다. 1~2 사이의 숫자를 입력하세요.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("==== You Lose ====");
            Console.WriteLine("0. 게임 종료");

            Console.Write("\n당신의 선택: ");

            string input = Console.ReadLine();
            switch (input)
            {
                case "0":
                    Console.WriteLine("게임을 종료합니다.");
                    Console.ReadKey(true);
                    Environment.Exit(0);
                    break;
                default: // 수정 : 0이 아닐 때 적용
                    Console.WriteLine("미구현입니다. 게임을 종료합니다.");
                    Console.ReadKey(true);
                    Environment.Exit(0);
                    break;
            }
        }
    }
}