namespace TRpg
{
    internal class Program
    {
        static void Main(string[] args)
        {
<<<<<<< Updated upstream
            Console.WriteLine("Hello, World!");
=======
            Lv = 1,
            Name = "코난",
            Job = "전사",
            Attack = 10,
            Defense = 5,
            Health = 100,
            Gold = 1500
        };
        monsterA = new Monster
        {
            Lv = 2,
            Name = "미니언",
            Health = 15,
            Attack = 5,
        };
        monsterB = new Monster
        {
            Lv = 3,
            Name = "공허충",
            Health = 10,
            Attack = 9,
        };
        monsterC = new Monster
        {
            Lv = 5,
            Name = "대포미니언",
            Health = 25,
            Attack = 8,
        };

        StartMessage();

    }
    //
    static void StartMessage()
    {
        Console.WriteLine("***** 스파르타 던전에 오신것을 환영합니다! *****");
        Console.WriteLine("1. 상태 보기");
        Console.WriteLine("2. 전투 시작");
        Console.WriteLine("원하시는 행동을 입력해주세요.");

        while (true)
        {
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    player.PlayerStatus();
                    break;
                case "2":
                    Console.WriteLine("전투를 시작합니다! (전투 로직은 아직 구현되지 않았습니다)");
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    break;
            }

            Console.WriteLine("원하시는 행동을 입력해주세요.");
>>>>>>> Stashed changes
        }
    }
}
