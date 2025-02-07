using System.Runtime.Remoting;

namespace TRpg;

//몬스터 공격 패턴 만들기
//위에 표시된 몬스터 먼저 공격함
//죽은 몬스터는 공격하지 않음 
//다음을 누르면 다음 몬스터가 공격을 해야 함
//몬스터 공격 차례가 끝나면 플레이어 차례로 돌아가야 함
//몬스터가 누구를 맞췄습니다
//공격력은 랜덤으로 할 건지?
//몬스터 이름, 체력, 레벨 가지고 와야 함

//Console.WriteLine -> 텍스트가 보이게 해주는 명령어

//Thread.Sleep -> 각 몬스터 사이(턴)에 진행 속도(텀이라고 보시면됨)

//Monster와 name, Lv, 공격력은 현종님이 만들어뒀으니까 필요시 불려오면 되요(예를들어 공허충이 나타났다는 쓰고싶으면 Console.WriteLine($"{mossterc.Name}'); 이런식으로 가져오면되요)

//zz 다 지워버려...?
public class MonsterTurn
{
    // 수정 : 진행을 위한 각 클래스 변수 선언
    CalcDamage calc;
    BattleEndPg endPg = new BattleEndPg();
    Battle battle;

    public MonsterTurn(CalcDamage calcDmg) { calc = calcDmg; } // 수정 : 생성자

    public void MonstersTurn(List<Monster> monsterList, Player player) // 수정 : 몬스터 리스트 매개변수
    {
        battle = new Battle(player); // 수정 : 진행을 위한 Battle 변수 선언
        Console.Clear();

        // 수정 : 몬스터 정보 출력
        for (int i = 0; i < monsterList.Count; i++)
        {
            Console.Write($"-{i + 1} ");
            Console.WriteLine($"{monsterList[i].Name} {monsterList[i].Lv} {monsterList[i].Health}"); 
        }


        Console.WriteLine("");
        Console.WriteLine("");
        
        // 수정 : 플레이어 정보 출력
        Console.WriteLine("[내정보]");
        Console.WriteLine($"Lv.{player.Lv} {player.Name} ({player.IClass})");
        Console.WriteLine($"HP {player.Health}\n");

        foreach (Monster monster in monsterList)
        {
            if (!monster.IsDead)
            {
                Console.WriteLine($"{monster.Name}이(가) 공격했습니다!");
                int dmg = calc.CalcDmg(monster, player);
                if (dmg != 0)
                {
                    Console.WriteLine($"{player.Name}이(가) {dmg}를 받았습니다.\n");
                    Console.ReadKey(true);
                }
                else
                {
                    Console.WriteLine($"{player.Name}이(가) 사망했습니다."); // 수정 : 사망 정보 출력
                }
            }            
        }
        Console.WriteLine($"{player.Name}의 체력 : {player.Health}"); // 수정 : 남은 체력 출력
        Console.WriteLine("계속 하시려면 아무키를 입력하세요.");
        Console.ReadKey(true);
        
    }
}