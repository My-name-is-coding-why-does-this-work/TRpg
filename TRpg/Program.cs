using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TRpg;


internal class Program
{

    static void Main(string[] args)
    {
        player = new Player("코난", 1, 10, 5, 100, 100, 1500, "전사");
        StartMessage();

        StartMessage(player); //수정 : 매개 변수 추가

    }

    public static void SelectClass(string selectClass)
    {
        switch (selectClass)
        {
            case "1":
                player.Attack = 10;
                player.Defense = 10;
                player.Health = 200;
                player.Mana = 50;
                player.IClass = "전사";
                //스킬데미지는 퍼센트로 생각하고 적을게요
                player.AddSkill(new Skill("찌르기", 20, 170, false, "검으로 공격력의 170% 데미지로 찌른다"));
                player.AddSkill(new Skill("올려배기", 20, 150, false, "검으로 공격력의 150% 데미지로 올려밴다"));
                player.AddSkill(new Skill("가로배기", 20, 120, true, "검으로 공격력의 120% 데미지로 가로로 밴다"));
                break;
            case "2":
                player.Attack = 20;
                player.Defense = 5;
                player.Health = 100;
                player.Mana = 50;
                player.IClass = "궁수";
                player.AddSkill(new Skill("파워 샷", 20, 170, false, "공격력의 170% 데미지로 강력하게 쏜다"));
                player.AddSkill(new Skill("더블 샷", 20, 150, false, "빠르게 두번쏴 공격력의 150% 데미지를 준다"));
                player.AddSkill(new Skill("멀티 샷", 20, 120, true, "공격력의 120% 데미지로 여러명을 쏜다"));
                break;
            case "3":
                player.Attack = 5;
                player.Defense = 0;
                player.Health = 50;
                player.Mana = 300;
                player.IClass = "마법사";
                player.AddSkill(new Skill("체인 라이트닝", 80, 200, true, "번개를 공격력의 200% 데미지로 여려명에게 쏜다"));
                player.AddSkill(new Skill("플레임 스윕", 80, 200, true, "화염을 공격력의 200% 데미지로 여려명에게 쏜다"));
                player.AddSkill(new Skill("제네시스", 120, 300, true, "성스러운 힘으로 공격력의 300% 데미지로 여려명에게 쏜다"));
                break;
            case "4":
                player.Attack = 15;
                player.Defense = 8;
                player.Health = 130;
                player.Mana = 100;
                player.IClass = "도적";
                player.AddSkill(new Skill("럭키 세븐", 20, 170, false, "표창을 던져 공격력의 170% 데미지를 준다"));
                player.AddSkill(new Skill("더블 스탭", 20, 150, false, "두번 공격하여 공격력의 150% 데미지를 준다"));
                player.AddSkill(new Skill("슈리켄 버스트", 20, 130, true, "수리검을 공격력의 130% 데미지로 여려명에게 쏜다"));
                break;
            default:
                //잘못된 선택을 했을때 출력
                break;

        }

    }

    public static void StartMessage()
    {
        //플레이어 이름 입력 창
        Console.Clear();
        Console.WriteLine("***** 스파르타 던전에 오신것을 환영합니다! *****");
        Console.WriteLine("플레이어 이름을 입력하세요");
        Console.Write("\n>>");
        player.Name = Console.ReadLine();

        //플레이어 직업 선택 창
        Console.Clear();
        Console.WriteLine("***** 스파르타 던전에 오신것을 환영합니다! *****");
        Console.WriteLine("플레이어 직업을 선택하세요");
        Console.WriteLine("1. 전사");
        Console.WriteLine("2. 궁수");
        Console.WriteLine("3. 마법사");
        Console.WriteLine("4. 도적");
        Console.Write("\n>>");
        string inputClass = Console.ReadLine();
        SelectClass(inputClass);


        Console.Clear();
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
                    Console.Clear();
                    player.PlayerStatus();
                    Console.WriteLine("1. 상태 보기");
                    Console.WriteLine("2. 전투 시작");
                    break;
                case "2":
                    Console.WriteLine("전투를 시작합니다!");
                    Console.ReadKey();
                    Battle battle = new Battle(player);
                    battle.BattleStart();
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    break;
            }

            Console.WriteLine("원하시는 행동을 입력해주세요.");
        }
    }
}