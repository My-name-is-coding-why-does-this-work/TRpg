public void Start()
{
    // 플레이어나 몬스터가 죽었을 때
    if (player.IsDead)
    {
        OnCharacterDeath?.Invoke(player);
    }
    else if (monster.IsDead)
    {
        OnCharacterDeath?.Invoke(monster);
    }
}

// 배틀페이지 종료후(혹시 몰라서 대비는 해둠)
private void StageClear(IPlayer player)
{
    if (Player is Monster)
    {
        Console.WriteLine($"==== You Win {player.Name}가 몬스터를 물리쳤습니다! ====");
        Console.WriteLine("1. 다음 스테이지");
        Console.WriteLine("2. 마을로 이동하기");

        Console.Write("\n당신의 선택: ");

        string input = Console.ReadLine();
        switch (input)
        {
            case "1":
                player.startMassge();
                break;
            case "2":
                player.nextStage();
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
                return;
        }
    }
}