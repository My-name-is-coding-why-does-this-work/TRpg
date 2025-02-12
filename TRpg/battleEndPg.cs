
using TRpg;

public static class BattleEndPg
{
    private static List<Item> RewardItems = new List<Item> //수정 : Item 클래스에 맞게 수정
    {
        new Item("전사의 검", ItemType.Weapon, 20, 0, 500, "전사들이 애용하는 검"),
        new Item("수호자의 방패", ItemType.Armor, 20, 0, 500, "튼튼한 방패"),
        new Item("포션병", ItemType.Weapon, 20, 0, 1000,"수상할 정도로 부서지지 않는 포션병이다.")
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
            Console.WriteLine($"아이템 획득: {rewardItem.Name}");
            Inventory.inventory.AddItem(rewardItem);

            Console.WriteLine("1. 마을로 이동하기");

            Console.Write("\n당신의 선택: ");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Program.Town(player);
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