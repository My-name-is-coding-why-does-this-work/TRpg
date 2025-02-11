namespace TRpg;

public class ShopItem
{
    public string Name { get; set; }
    public int Category { get; set; }
    public int Stat { get; set; }
    public string Descript { get; set; }
    public bool Isbuy;
    public int Price;
    public string shopList { get; set; }
    

    public ShopItem(string name, int category, int stat, string desc, int price, bool isbuy)
    {
        Name = name;
        Category = category;
        Stat = stat;
        Descript = desc;
        Price = price;
        Isbuy = false;
    }
}

public class ShopList
{
    private List<ShopItem> shopList;
    private int buy;

    public ShopList()
    {
        shopList = new List<ShopItem>();
    }

    public void SettingShop()
    {
        // 아이템목록
    }

    public void ShopMenu(Player player)
    {
        int count = 0;
        do
        {
            Console.Clear();
            
            Console.WriteLine("\n-------------------------------------------\n");
            Console.WriteLine("\t\t상점");
            Console.WriteLine("\n-------------------------------------------");

            foreach (ShopItem item in shopList)
            {
                Console.WriteLine("-"+ count + " ");

                item.Inform();
                count++;
            }
            
            ShopBuy(player);
            if (buy ! = 0)
                break;
            count = 1;
            break; 
        } while(buy != 0);
    }

    public void ShopBuy(Player player)
    {
        Console.WriteLine("\n-------------------------------------------\n");
        Console.WriteLine("현재 G : " + player.Gold + "G\n");
        Console.WriteLine("구매할 아이템을 선택하세요 ( 0 - 나가기 | 1 ~ " + shopList.Count + " - 구매할 아이템 번호)");

        while (!int.TryParse(Console.ReadLine(), out buy))
        {
            Console.WriteLine("잘못된 입력입니다.");
            Console.WriteLine("구매할 아이템을 선택하세요 ( 0 - 나가기 | 1 ~ " + shopList.Count + " - 구매할 아이템 번호)");
        }
    }
}