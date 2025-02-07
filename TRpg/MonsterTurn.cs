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

    public void MonstersTurn()
    {

        foreach (Monster monster in Monsterlist)
        {
            if (!monster.IsDead)
            {
                Console.Clear();
                Console.WriteLine($"{monster.name}가 공격했다!");
                int dmg = CalcDmg(monster, player);
                if (dmg == 0)
                {
                    StageClear();
                    
                }
                else
                
                Console.WriteLine($"{player.name}가 {dmg}를 받았다.");
            }            
        } playerTurn();
        
    }
}