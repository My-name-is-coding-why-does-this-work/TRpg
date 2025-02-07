
public static class BattleEndPg // 수정 : 클래스 선언 안하셨네, 클래스명 처음은 대문자로
{
    
    // 배틀페이지 종료후
    public static void StageClear(Player player) //수정 : IPlayer -> Player, public 메소드로
    {
        if (!player.IsDead) // 수정 : 플레이어가 죽지 않고 StageClear 호출
        {
            Console.WriteLine($"==== You Win {player.Name}가 몬스터를 물리쳤습니다! ====");
            Console.WriteLine("1. 다음 스테이지");
            Console.WriteLine("2. 마을로 이동하기");

            Console.Write("\n당신의 선택: ");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Program.StartMessage(player);
                    break;
                case "2": // 수정 : 미구현 부분 주석 처리
 //                   player.nextStage();
 //                   break;
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