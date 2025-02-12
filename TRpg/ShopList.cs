namespace TRpg;

public class ShopItem
{
    public string Name { get; }
    public ItemType Type { get; }
    public int Attack { get; private set; } // private 추가
    public int Defense { get; set; }
    public string Description { get; set; } // 아이템 설명
    public bool IsBuy;
    public int Price;
    public string shopList { get; set; }
    

    public ShopItem(string name, ItemType type, int attack, int defense, int price, string description, bool isBuy = false) // isbuy = false 추가
    {
        Name = name;
        Type = type;
        Attack = attack;
        Defense = defense;
        Description = description;
        Price = price;
        IsBuy = false;
    }

    public void Inform() // 2.12 아이템 정보 출력
    {
        Console.Write($"    {Name}");
        Console.Write($"    |   장비 : {Type}");
        if (Type == ItemType.Weapon) Console.Write($"   |   공격력 : {Attack}");
        else if (Type == ItemType.Armor) Console.Write($"   | 방어력 : {Defense}");
        else if (Type == ItemType.Test) Console.Write($"    | 공격력 : {Attack}     |   방어력 : {Defense}");
        Console.WriteLine($" | {Description} | {Price}");
    }

}

public class ShopList
{
    private List<ShopItem> shopList;

    public static ShopList shop; // 싱글톤 -> 수정 : 인벤토리로 이름 수정
    public static ShopList Instance()
    {
        if (shop == null)
        {
            shop = new ShopList(); // 새로운 인스턴스 생성
        }
        return shop;
    }
    public ShopList()
    {
        shopList = new List<ShopItem>();
        SettingShop();
    }

    public void SettingShop() // 2.12 아이템 정보 수정
    {
       shopList.Add(new ShopItem("롱소드", ItemType.Weapon, 20, 0, 500, "평범한 롱소드다."));
       shopList.Add(new ShopItem("낡은 방패", ItemType.Armor, 0, 10 , 500 , "평범한 방패다."));
       shopList.Add(new ShopItem("브라움의 방패", ItemType.Armor, 0, 20, 1000 , "자세히 보면 문인것 같다..."));
       shopList.Add(new ShopItem("롱소드", ItemType.Weapon , 20 , 0 , 1000 , "평범한 롱소드다."));
       shopList.Add(new ShopItem("몰락한 왕의 검", ItemType.Weapon , 0 , 30 , 1500, "몰락한 왕의 검이다 불길한 기운이 든다."));
       shopList.Add(new ShopItem("롱소드", ItemType.Weapon , 30 , 0, 1500 , "평범한 롱소드다."));
       shopList.Add(new ShopItem("롱소드", ItemType.Weapon , 20 , 0, 700 , "평범한 롱소드다."));
       shopList.Add(new ShopItem("롱소드", ItemType.Weapon , 20 , 0, 700 , "평범한 롱소드다."));

    }

    public void ShopMenu(Player player)
    {
        int count = 1;
        int act = 0;
        do
        {
            Console.Clear();
            count = 1;
            Console.WriteLine("\n-------------------------------------------\n");
            Console.WriteLine("\t\t상점");
            Console.WriteLine("\n-------------------------------------------");

            foreach (ShopItem item in shopList)
            {
                Console.Write(count + "." + " ");

                item.Inform();
                count++;
            }

            ShopBuy(player, out act);

            if (act == 0)
            {
                Console.WriteLine("0. 마을로 돌아갑니다.");
                Console.WriteLine("아무키를 입력해주세요");
                Console.ReadKey(true);
                Program.Town(player);
                break;
            }


            
            
        } while(act != 0);
    }

    public void ShopBuy(Player player, out int act)
    {
        Console.WriteLine("\n-------------------------------------------\n");
        Console.WriteLine("현재 G : " + player.Gold + "G\n");
        Console.WriteLine("구매할 아이템을 선택하세요. ( 0. 나가기  |   1 ~ " + shopList.Count + " - 구매할 아이템 번호)");

        while (!int.TryParse(Console.ReadLine(), out act))
        {
            Console.WriteLine("잘못된 입력입니다.");
            Console.WriteLine("구매할 아이템을 선택하세요. ( 0. 나가기   |   1 ~ " + shopList.Count + " - 구매할 아이템 번호)");
        }

        if (act > 0 && act <= shopList.Count) // 2.12 아이템 구매 및 나가기 시 행동 실행
        {
            act--;
            if (!shopList[act].IsBuy)
            {
                if (player.Gold >= shopList[act].Price)
                {
                    ShopItem selectItem = shopList[act];
                    player.Gold -= selectItem.Price;

                    //구매한 아이템 정보 인벤토리에 저장
                    Inventory.inventory.AddItem(BuyItem(shopList[act]));
                    selectItem.IsBuy = true;

                    Console.WriteLine("아이템을 구매하였습니다.");
                    Console.WriteLine($"플레이어의 골드 : {player.Gold}");
                }
                else
                {
                    Console.WriteLine("\n소지한 골드가 부족합니다.");
                    Console.WriteLine($"플레이어의 골드 : {player.Gold}");
                }
            }
            else
            {
                Console.WriteLine("\n이미 구매한 아이템입니다.");
            }
            act++;
            Console.WriteLine("\n아무 키나 입력하세요.");
            Console.ReadKey(true);
        }
        else if (act != 0)
        {
            Console.WriteLine("아이템 번호가 존재하지 않습니다.");
        }

    }

    private Item BuyItem(ShopItem item) // 2.12 구매한 아이템의 정보를 Item 클래스로 반환
    {
        Item buyItem = new Item(item.Name, item.Type, item.Attack, item.Defense, item.Price, item.Description);
        return buyItem;
    }
}